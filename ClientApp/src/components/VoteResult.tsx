// Models
import BallotVote from 'models/BallotVote';
// Elements
import Tag from 'components/elements/Tag';
import NewTabHyperLink from 'components/elements/NewTabHyperLink';
// Helpers
import Colour from 'components/helpers/Colour';
import Size from './helpers/Size';
// Utils
import DateUtils from 'utils/DateUtils';
// Styles
import './VoteResult.scss';

type VoteResultProps = {
  ballotVote: BallotVote;
};
/**
 * Render element to display the result of a vote
 * @returns 
 */
export default function VoteResult({ ballotVote }: VoteResultProps): JSX.Element {
  return (
    <article className='VoteResult'>
      <h1 className='VoteResult__BillNumber has-text-weight-light'>{ballotVote.getBillName()} ({DateUtils.formatWithoutTime(ballotVote.getDateOfVote())})</h1>
      <h2 className='VoteResult__BillName'>
        <NewTabHyperLink
          label={ballotVote.getBillSubject()}
          href={ballotVote.getHyperLinkToParliamentVote()}></NewTabHyperLink>
      </h2>
      <Tag
        size={Size.Medium}
        colour={ballotVote.getPassed() ? Colour.Success : Colour.Danger}
        label={ballotVote.getPassed() ? 'Passed' : 'Failed'}></Tag>
    </article>
  );
}