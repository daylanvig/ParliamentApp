import { Component, Fragment } from 'react';
import Politician from 'models/Politician';
import ProfilePhoto from './ProfilePhoto';
import PoliticianSelect from './PoliticianSelect';
import './PoliticianCard.scss';
import NewTabHyperLink from './elements/NewTabHyperLink';

type PoliticianCardProps = {
  politicians: Politician[];
  onPoliticianChanged(politician?: Politician): void;
  includeContactInfo?: boolean;
};

type PoliticianCardState = {
  selectedPolitican?: Politician;
};

export default class PoliticianCard extends Component<PoliticianCardProps, PoliticianCardState> {

  /**
   * ctor
   * @param props 
   */
  constructor(props: PoliticianCardProps) {
    super(props);
    this.handlePoliticianSelectChanged = this.handlePoliticianSelectChanged.bind(this);
    this.state = {
      selectedPolitican: undefined,
    };
  }

  /**
   * Callback to handle select element being changed
   * @param selectedPolitician 
   */
  public async handlePoliticianSelectChanged(selectedPolitician?: Politician) {
    this.props.onPoliticianChanged(selectedPolitician);
    this.setState({
      selectedPolitican: selectedPolitician,
    });
  }

  private static formatFooterLabel(labelText: string, value: string | JSX.Element): JSX.Element {
    return (
      <Fragment>
        <label className='label pr-2'>{labelText}</label>
        <span>{value}</span>
      </Fragment>
    );
  }

  /**
   * Format contact info for card, if requested
   * @returns 
   */
  private formatContactInfo(): JSX.Element {
    const politician = this.state.selectedPolitican;
    if (!this.props.includeContactInfo || politician == null) {
      return <Fragment></Fragment>;
    }

    const formatLinkUrl = (label: string, url: string | undefined): JSX.Element => {
      if (url === undefined) {
        return <Fragment></Fragment>;
      }
      return <NewTabHyperLink className='button' href={url} label={label}></NewTabHyperLink>;
    };

    return (
      <div className='PoliticianCardSocialLinks'>
        {formatLinkUrl('Facebook', politician.getTwitterUrl())}
        {formatLinkUrl('Twitter', politician.getTwitterUrl())}
      </div>
    );
  }

  private renderDetails(): JSX.Element {
    const politician = this.state.selectedPolitican;

    if (politician == null) {
      return <Fragment></Fragment>;
    }

    return (
      <div className='PoliticianCardFooter'>
        {PoliticianCard.formatFooterLabel('Party', politician.getPartyName())}
        {PoliticianCard.formatFooterLabel('Riding', politician.getRiding())}
        {this.props.includeContactInfo ? PoliticianCard.formatFooterLabel('Phone', politician.getPhoneNumber()) : <Fragment></Fragment>}
      </div>
    );
  }

  render(): JSX.Element {
    return (
      <div className="PoliticianCard">
        <ProfilePhoto
          politician={this.state.selectedPolitican}></ProfilePhoto>
        <PoliticianSelect politicians={this.props.politicians} onChange={this.handlePoliticianSelectChanged}></PoliticianSelect>
        {this.renderDetails()}
        {this.formatContactInfo()}
      </div>
    );
  }
}


