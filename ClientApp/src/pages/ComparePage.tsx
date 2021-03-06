import React from 'react';
import ParliamentAPI from 'api/ParliamentAPI';
import Title from 'components/elements/Title';
import LoadingIcon from 'components/elements/LoadingIcon';
import PoliticianCard from 'components/PoliticianCard';
import Politician from 'models/Politician';
import BallotVote from 'models/BallotVote';
import VoteCompareList from 'components/VoteCompareList';
import Colour from 'components/helpers/Colour';

type ComparePageState = {
  isLoading: boolean;
  selectedPoliticianOne?: Politician;
  selectedPoliticianOneBallotVotes: BallotVote[];
  selectedPoliticianTwo?: Politician;
  selectedPoliticianTwoBallotVotes: BallotVote[];
  politicians: Politician[];
  parliamentNumber: number;
};

export default class ComparePage extends React.Component<{}, ComparePageState> {

  /**
   * Ctor
   * @param props 
   */
  constructor(props: {}) {
    super(props);
    this.state = {
      isLoading: true,
      selectedPoliticianOne: undefined,
      selectedPoliticianOneBallotVotes: [],
      selectedPoliticianTwo: undefined,
      selectedPoliticianTwoBallotVotes: [],
      politicians: [],
      parliamentNumber: 43
    };
    this.onPoliticianChanged = this.onPoliticianChanged.bind(this);
  }

  /**
   * On mount precache. This is for dev purposes (future can lazy load)
   */
  async componentDidMount() {
    const politicians = await ParliamentAPI.loadPoliticiansAsync({
      parliamentNumber: this.state.parliamentNumber,
      pageNumber: 1
    });
    this.setState({
      isLoading: false,
      politicians,
    });
  }

  async onPoliticianChanged(isPoliticianOne: boolean, selectedPolitician?: Politician) {
    const ballotVotes = selectedPolitician == null ? [] : await ParliamentAPI.loadMemberVotesAsync({ memberOfParliamentId: selectedPolitician.getId(), parliamentNumber: this.state.parliamentNumber });

    if (isPoliticianOne) {
      this.setState({
        selectedPoliticianOne: selectedPolitician,
        selectedPoliticianOneBallotVotes: ballotVotes
      });
    } else {
      this.setState({
        selectedPoliticianTwo: selectedPolitician,
        selectedPoliticianTwoBallotVotes: ballotVotes
      });
    }
  }

  render() {
    const renderLoader = () => {
      return <div className='is-narrow'><LoadingIcon colour={Colour.Primary} size="is-large"></LoadingIcon></div>;
    };
    // render the content once items have been precached (prevents flash of unstyle contents from the select elements)
    const renderContent = () => {
      return (
        <React.Fragment>
          {
            // The politcians here are filtered so people can not compare them against themselves
          }
          <div className="column is-8-mobile is-6-tablet">
            <PoliticianCard
              politicians={this.state.politicians.filter(p => p !== this.state.selectedPoliticianTwo)}
              onPoliticianChanged={politician => this.onPoliticianChanged(true, politician)}
            ></PoliticianCard>
          </div>
          <div className="column is-8-mobile is-6-tablet">
            <PoliticianCard
              politicians={this.state.politicians.filter(p => p !== this.state.selectedPoliticianOne)}
              onPoliticianChanged={politician => this.onPoliticianChanged(false, politician)}></PoliticianCard>
          </div>
        </React.Fragment >
      );
    };

    const renderComparisons = () => {
      if (this.state.selectedPoliticianOne == null || this.state.selectedPoliticianTwo == null) {
        return <React.Fragment></React.Fragment>;
      }

      // TODO: Option to show all vs just showing differences
      return (
        <div className="column is-8-desktop is-10-tablet is-12-mobile">
          <VoteCompareList
            ballotVotesA={this.state.selectedPoliticianOneBallotVotes}
            ballotVotesB={this.state.selectedPoliticianTwoBallotVotes}></VoteCompareList>
        </div>
      );

    };

    return (
      <div className='container pt-3'>
        <header>
          <Title title='Compare Voting Patterns'></Title>
        </header>
        <section className='section'>
          <div className='columns is-mobile is-multiline is-centered'>
            {
              this.state.isLoading ? renderLoader() : renderContent()
            }
            {
              renderComparisons()
            }
          </div>
        </section>
      </div>
    );
  }
}