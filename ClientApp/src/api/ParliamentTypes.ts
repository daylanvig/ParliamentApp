

export interface Pagination<TData> {
  items: TData[];
  currentPage: number;
  totalPages: number;
  pageSize: number;
  totalCount: number;
  hasPrevious: boolean;
  hasNext: boolean;
}

export enum Province {
  Alberta,
  BritishColumbia,
  Manitoba,
  NewBrunswick,
  NewfoundlandAndLabrador,
  NorthwestTerritories,
  NovaScotia,
  Nunavut,
  Ontario,
  PrinceEdwardIsland,
  Quebec,
  Saskatchewan,
  Yukon
}

export enum VoteDecision {
  Yea,
  Nay,
  Paired,
  DidntVote
}

export interface MemberOfParliament {
  id: number;
  parliamentPersonId: number;
  personShortHonorific: string;
  personOfficialFirstName: string;
  personOfficialLastName: string;
  constituencyName: string;
  constituencyProvinceTerritoryName: Province;
  caucusShortName: string;
  fromDateTime: string;
  toDateTime: string | null;
}

export interface ParliamentPeriod {
  id: number;
  parliamentNumber: number;
  sessionNumber: number;
  startDate: string;
  endDate: string | null;
}

export interface MemberVote {
  id: number;
  voteId: number;
  memberOfParliamentId: number;
  voteValue: VoteDecision;
}

export interface Vote {
  id: number;
  parliamentPeriodId: number;
  billNumberCode: string;
  decisionEventDateTime: string;
  decisionDivisionNumber: number;
  decisionDivisionSubject: string;
  decisionResultName: string;
  decisionDivisionNumberOfYeas: number;
  decisionDivisionNumberOfNays: number;
  decisionDivisionNumberOfPaired: number;
  decisionDivisionDocumentTypeName: string;
  decisionDivisionDocumentTypeId: number;
}

export interface PagedListParameters {
  pageNumber?: number; // default is 1
  pageSize?: number;
}

export interface MemberOfParliamentResourceParameters extends PagedListParameters {
  parliamentNumber?: number;
}

export interface VoteResourceParameters extends PagedListParameters {
  // todo add properties here as needed
}

export interface MemberVoteResourceParameters extends PagedListParameters {
  memberOfParliamentId?: number;
  parliamentNumber?: number;
}