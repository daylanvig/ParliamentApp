import { MemberVote, Vote, VoteDecision } from 'api/ParliamentTypes';
import Colour, { ColourType } from 'components/helpers/Colour';
import StringUtils from 'utils/StringUtils';


/**
 * A ballot vote is a single vote completed by one individual.
 */
export default class BallotVote {
  private readonly _parliamentBallotVote: MemberVote;
  private readonly _parliamentVote: Vote;

  /**
   * ctor
   * @param parliamentBallotVote This is the MPs individual vote
   * @param parliamentVote This is the overall vote
   * @param parliamentBill The bill being voted on, if applicable. Certain budget measures don't have a bill, in which case this value will be undefined.
   */
  constructor(parliamentBallotVote: MemberVote, parliamentVote: Vote) {
    this._parliamentBallotVote = parliamentBallotVote;
    this._parliamentVote = parliamentVote;
  }


  /**
   * Get unique id
   * @returns The unique id for this ballot vote (specific for the member)
   */
  public getId(): number {
    return this._parliamentBallotVote.id;
  }

  /**
   * Get the id for the vote.
   * The vote id is used to identify that two ballotVotes were voting on the same bill (by different members of parliament)
   * @returns the vote id
   */
  public getVoteId(): number {
    return this._parliamentVote.id;
  }

  /**
   * Check if two ballot votes are voting on the same piece of legislation
   * @param compareVote the vote to compare against
   * @returns true if they have the same vote id, else false
   */
  public isSameBill(compareVote: BallotVote): boolean {
    return this.getVoteId() === compareVote.getVoteId();
  }
  /**
   * Get the vote URL
   * @returns The url to reference the vote
   */
  public getVoteURL(): string {
    // FUTURE: support to link to vote url
    return '';
    // return this._parliamentBallotVote.vote_url;
  }

  /**
   * Check the passed status of the bill
   * @returns True if the measure being voted on has passed
   */
  public getPassed(): boolean {
    // todo enum
    return this._parliamentVote.decisionResultName === 'Agreed To';
  }

  /**
   * Get how this ballot voted (enum)
   * Possible values are 'Yes', 'No', 'Paired', and 'Didn't Vote'
   */
  public getVoted(): VoteDecision {
    return this._parliamentBallotVote.voteValue;
  }

  /**
   * Get the label for how this ballot was voted by this politician
   * @returns A human readable label displaying how this politician voted
   */
  public getVotedDisplayLabel(): string {
    const voted = this.getVoted();
    switch (voted) {
      case VoteDecision.Yea:
        return 'Yea';
      case VoteDecision.Nay:
        return 'Nay';
      case VoteDecision.Paired:
        return 'Paired';
      case VoteDecision.DidntVote:
        return "Didn't Vote";
      default:
        throw new Error(`Invalid vote decision - ${voted}`);
    }
  }

  /**
   * Get colour used to display this vote decision
   * @returns 
   */
  public getVotedColour(): ColourType {
    const voted = this.getVoted();
    switch (voted) {
      case VoteDecision.Yea:
        return Colour.Success;
      case VoteDecision.Nay:
        return Colour.Danger;
      case VoteDecision.DidntVote:
      case VoteDecision.Paired:
        return Colour.Info;
      default:
        throw new Error('Invalid voted by');
    }
  }

  /**
   * 
   * @returns A fully formatted url (https:..) that links the the openparliament page for this vote
   */
  public getHyperLinkToParliamentVote(): string {
    // FUTURE: link to vote
    return '';
    //return ParliamentAPIUtils.getViewURL(this._parliamentBallotVote.vote_url);
  }

  /**
   * Get the name of the bill
   */
  public getBillName(): string {
    if (StringUtils.isNullOrEmpty(this._parliamentVote.billNumberCode)) {
      return 'Special Vote';
    }
    return `Bill ${this._parliamentVote.billNumberCode}`;
  }

  /**
   * Get the subject of the bill
   * @returns 
   */
  public getBillSubject(): string {
    return this._parliamentVote.decisionDivisionSubject;
  }

  public getDateOfVote(): Date {
    return new Date(this._parliamentVote.decisionEventDateTime);
  }
}