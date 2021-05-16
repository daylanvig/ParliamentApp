import BallotVote from 'models/BallotVote';
import MathUtils from './MathUtils';

type BallotVoteDifference = {
  ballotVoteA: BallotVote;
  ballotVoteB: BallotVote;
};

type BallotVoteComparisonResults = {
  sameVotes: BallotVote[];
  differentVotes: BallotVoteDifference[];
  /**
   * missingVotesA - The vote ids where a didn't have a vote record but b did (different from "didnt vote", which still has a record).
   * missing votes occur if mps weren't seated for the exact same periods (e.g. special election)
   */
  missingVotesA: number[];
  /**
   * missingVotesA - The vote ids where a didn't have a vote record but b did
   */
  missingVotesB: number[];
  percentageDifferent: number;
};

export default class BallotVoteUtils {
  /**
   * Get the differences between two ballot votes
   * @param ballotVotesA An array of how one politician has voted
   * @param ballotVotesB An array of how another has voted
   * @returns An array containing objects for any ballots where politicians did not vote the same
   */
  public static compareVotes(ballotVotesA: BallotVote[], ballotVotesB: BallotVote[]): BallotVoteComparisonResults {
    const results: BallotVoteComparisonResults = {
      differentVotes: [],
      missingVotesA: [],
      missingVotesB: [],
      percentageDifferent: 0,
      sameVotes: []
    };

    // first we iterate over 
    for (let i = 0; i < ballotVotesA.length; i += 1) {
      const ballotVoteA = ballotVotesA[i];
      const ballotVoteB = ballotVotesB.find(bv => bv.isSameBill(ballotVoteA));
      if (ballotVoteB == null) {
        results.missingVotesB.push(ballotVoteA.getVoteId());
        continue;
      }

      // Voted differently, store results of each
      if (ballotVoteA.getVoted() !== ballotVoteB.getVoted()) {
        results.differentVotes.push({
          ballotVoteA,
          ballotVoteB
        });
      }
      // FUTURE: maybe store a "Vote" rather than a ballotVote
      // Voted same, store result (doesn't matter which)
      else {
        results.sameVotes.push(ballotVoteA);
      }
    }

    // then we need to verify that all items for politician B have been checked
    for (let i = 0; i < ballotVotesB.length; i += 1) {
      const ballotVoteB = ballotVotesB[i];
      const ballotVoteA = ballotVotesA.find(bv => bv.isSameBill(ballotVoteB));
      if (ballotVoteA == null) {
        results.missingVotesA.push(ballotVoteB.getVoteId());
      }
      // no other logic needed, just need to check missing since same/difference would have been checked above
    }
    const differentVoteCount = results.differentVotes.length;
    const sameVoteCount = results.sameVotes.length;
    results.percentageDifferent = MathUtils.calculatePercentageDifference(differentVoteCount, differentVoteCount + sameVoteCount);
    results.differentVotes = results.differentVotes.sort((voteA, voteB) => +voteA.ballotVoteA.getDateOfVote() - +voteB.ballotVoteA.getDateOfVote());
    return results;
  }
}