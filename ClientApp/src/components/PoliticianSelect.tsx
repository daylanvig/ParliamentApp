import React from 'react';
import Politician from 'models/Politician';
import Select from 'components/elements/Select';

type PoliticianSelectProps = {
  onChange(selectedPolitician?: Politician): void;
  politicians: Politician[];
};

type PoliticianSelectState = {
  selectedValue?: number;
};

export default class PoliticianSelect extends React.Component<PoliticianSelectProps, PoliticianSelectState> {

  /**
   * ctor
   * @param props 
   */
  constructor(props: PoliticianSelectProps) {
    super(props);
    this.state = {
      selectedValue: undefined
    };
    this.handleChange = this.handleChange.bind(this);
  }

  private handleChange(e: React.ChangeEvent<HTMLSelectElement>) {
    const selectedPoliticianId = Number(e.target.value);
    this.props.onChange(this.props.politicians.find(p => p.getId() === selectedPoliticianId));
    this.setState({ selectedValue: selectedPoliticianId });
  }

  render() {
    const selectItems = this.props.politicians.map(p => ({ value: p.getId().toString(), label: p.getFullName() }));
    return (
      <Select items={selectItems} onChange={this.handleChange} selectedValue={this.state.selectedValue?.toString()}></Select>
    );
  }
}