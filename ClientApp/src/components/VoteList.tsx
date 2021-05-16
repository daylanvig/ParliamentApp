import BallotVote from '../models/BallotVote';

type VoteListProps = {
  ballotVotes: BallotVote[];
};

/**
 * Component for display list of votes
 * @returns 
 */
function VoteList({ ballotVotes }: VoteListProps): JSX.Element {
  function renderBallotVoteItem(ballotVote: BallotVote): JSX.Element {
    return (
      <dd key={ballotVote.getId()}>
        <a target="_blank" rel="noreferrer" href={ballotVote.getHyperLinkToParliamentVote()}>{ballotVote.getBillName()}</a>
        <span>{ballotVote.getVotedDisplayLabel()}</span>
      </dd>
    );
  }
  return (
    <dl>
      <dt>Votes</dt>
      {
        ballotVotes.map(bv => renderBallotVoteItem(bv))
      }
    </dl>
  );
}
export default VoteList;