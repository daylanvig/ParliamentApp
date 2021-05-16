// Models
import BallotVote from 'models/BallotVote';
// Utils
import BallotVoteUtils from 'utils/BallotVoteUtils';
// Elements
import ProgressBar from 'components/elements/ProgressBar';
import Tag from 'components/elements/Tag';
import VoteResult from 'components/VoteResult';
// Helpers
import Colour from 'components/helpers/Colour';
import Size from 'components/helpers/Size';
// Styles
import './VoteCompareList.scss';


type VoteCompareListProps = {
  ballotVotesA: BallotVote[];
  ballotVotesB: BallotVote[];
};

/**
 * Renders a list displaying the differences between how two politicians voted
 * @returns 
 */
function VoteCompareList({ ballotVotesA, ballotVotesB }: VoteCompareListProps): JSX.Element {
  const comparisonResults = BallotVoteUtils.compareVotes(ballotVotesA, ballotVotesB);

  const renderVotedTag = (ballotVote: BallotVote) => {
    return <Tag colour={ballotVote.getVotedColour()} label={ballotVote.getVotedDisplayLabel()} size={Size.Medium}></Tag>;
  };

  const renderDifference = (ballotVoteA: BallotVote, ballotVoteB: BallotVote) => {
    return (
      <dd className="VoteCompareList__Row" key={ballotVoteA.getId()}>
        <div className='VoteCompareList__VoteDetails'>{renderVotedTag(ballotVoteA)}</div>
        <div className='VoteCompareList__BillDetails'>
          <VoteResult ballotVote={ballotVoteA}></VoteResult>
        </div>
        <div className='VoteCompareList__VoteDetails'>{renderVotedTag(ballotVoteB)}</div>
      </dd>
    );
  };
  return (
    <section className="section VoteCompareList">
      <ProgressBar colour={Colour.Success} percentage={comparisonResults.percentageDifferent} size='large'></ProgressBar>
      <dl>
        <dt className="title is-4 has-text-centered">Here's where they voted differently</dt>
        {
          comparisonResults.differentVotes.map(difference => renderDifference(difference.ballotVoteA, difference.ballotVoteB))
        }
      </dl>
    </section>
  );

}


export default VoteCompareList;