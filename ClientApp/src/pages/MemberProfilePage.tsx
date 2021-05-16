import React from 'react';
import ParliamentAPI from 'api/ParliamentAPI';
// Components
import LoadingIcon from 'components/elements/LoadingIcon';
import Size from 'components/helpers/Size';
import Title from 'components/elements/Title';
import Colour from 'components/helpers/Colour';
import PoliticianCard from 'components/PoliticianCard';
// Models
import Politician from 'models/Politician';
import BallotVote from 'models/BallotVote';

type MemberProfilePageProps = {
  memberOfParliamentId?: number;
};

type MemberProfilePageState = {
  politician?: Politician;
  politiciansVotes: BallotVote[]; // votes for currently selected politicians
  politicians: Politician[]; // all politicians (for select)
  isLoading: boolean;
};

export default class MemberProfilePage extends React.Component<MemberProfilePageProps, MemberProfilePageState> {

  constructor(props: MemberProfilePageProps) {
    super(props);
    this.state = {
      politician: undefined,
      isLoading: true,
      politicians: [],
      politiciansVotes: []
    };
  }

  async componentDidMount() {
    let politician: Politician | undefined = undefined;
    if (this.props.memberOfParliamentId !== undefined) {
      politician = await ParliamentAPI.loadPoliticianByIdAsync(this.props.memberOfParliamentId);
    }
    const politicians = await ParliamentAPI.loadPoliticiansAsync({
      parliamentNumber: 43
    });
    this.setState({
      politician,
      politicians,
      isLoading: false
    });
  }

  onPoliticianChanged(politician?: Politician) {
    this.setState({
      politician,
    });
  };

  render() {
    const renderLoader = () => {
      return <div className='is-narrow'><LoadingIcon colour={Colour.Primary} size={Size.Large}></LoadingIcon></div>;
    };

    const renderContent = () => {
      return (
        <React.Fragment>
          <div className='column is-narrow'>
            <PoliticianCard
              politicians={this.state.politicians}
              onPoliticianChanged={politician => this.onPoliticianChanged(politician)}
              includeContactInfo={true}
            ></PoliticianCard>
          </div>
          <div className='column'>
            TODO Details about politician
          </div>
        </React.Fragment>
      );
    };

    return (
      <div className='container pt-3'>
        <header>
          {this.state.isLoading ? <div></div> : <Title title={(this.state.politician?.getFullName() || ' ')}></Title>}
        </header>
        <section className='section'>
          <div className='columns is-mobile is-multiline is-centered'>
            {
              this.state.isLoading ? renderLoader() : renderContent()
            }
          </div>
        </section>
      </div>
    );
  }
}