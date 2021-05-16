import axios from 'axios';
import Configuration from 'Configuration';
import 'api/ParliamentTypes';
import Politician from 'models/Politician';
import BallotVote from 'models/BallotVote';
import { MemberOfParliament, MemberOfParliamentResourceParameters, MemberVote, MemberVoteResourceParameters, Pagination, Vote, VoteResourceParameters } from 'api/ParliamentTypes';


/**
 * ParliamentAPI wrapper
 */
export default class ParliamentAPI {

  private static readonly _api = axios.create({
    baseURL: Configuration.apiUrl,
  });

  private static _votesPromise: Promise<Vote[]>;

  // FUTURE: remove this and replace with a proper cache
  // key is url params, value is data returned 
  private static _loadedData: Record<string, any> = {};

  // #region Common
  private static async getAsync<TData>(url: string, useCache: boolean): Promise<TData> {
    // TODO: use a better cache system, this is just for ease of development
    if (useCache) {
      const existingValue = this._loadedData[url];
      if (existingValue != null) {
        return existingValue as TData;
      }
    }
    const result = await this._api.get(url);
    if (result.status !== 200) {
      throw new Error(result.statusText);
    }
    this._loadedData[url] = result.data;
    return result.data as TData;
  }

  /**
   * Helper function to build url resource params from object
   * @param data 
   * @returns 
   */
  private static getQueryParams(data?: object | null): string {
    if (data == null) {
      return '';
    }
    return Object.keys(data).map(key => {
      // @ts-ignore
      const value = data[key];
      return `${key}=${value || ''}`;
    }).join('&');
  }

  // #endregion Common
  /**
   * Load a politician by their entity id
   * @param id the id of the member of parliament
   * @returns 
   */
  public static async loadPoliticianByIdAsync(id: number): Promise<Politician> {
    const politician = await this.getAsync<MemberOfParliament>(`/MembersOfParliament/${id}`, false);
    return new Politician(politician);
  }

  /**
   * Load list of politicians, by query params
   * @param queryParameters 
   * @returns 
   */
  public static async loadPoliticiansAsync(queryParameters?: MemberOfParliamentResourceParameters): Promise<Politician[]> {
    const results = await this.getAsync<Pagination<MemberOfParliament>>(`/MembersOfParliament?${this.getQueryParams(queryParameters)}`, true);
    return results.items.map(p => new Politician(p)).sort((a, b) => a.getFullName().localeCompare(b.getFullName()));
  }

  public static async loadVotesAsync(queryParameters?: VoteResourceParameters): Promise<Vote[]> {
    // todo: vote type separate from api interface (?)
    const results = await this.getAsync<Pagination<Vote>>(`/Votes?${this.getQueryParams(queryParameters)}`, true);
    return results.items;
  }

  // FUTURE: filtering on this rather than loading all
  private static loadAllVotes() {
    if (this._votesPromise == null) {
      this._votesPromise = this.loadVotesAsync({
        pageSize: 999
      });
    }
    return this._votesPromise;
  }

  /**
   * Load member votes matching resource params
   * @param queryParameters 
   * @returns 
   */
  public static async loadMemberVotesAsync(queryParameters?: MemberVoteResourceParameters): Promise<BallotVote[]> {
    const memberVotes = await this.getAsync<Pagination<MemberVote>>(`/MemberVotes?${this.getQueryParams(queryParameters)}`, false);
    const votes = await this.loadAllVotes();
    return memberVotes.items.map(v => {
      const vote = votes.find(vo => vo.id === v.voteId);
      if (vote == null) {
        throw new Error(`Invalid vote. No vote found with id ${v.voteId}`);
      }
      return new BallotVote(v, vote);
    });
  }
}