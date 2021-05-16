import ParliamentAPIUtils from 'api/ParliamentAPIUtils';
import { MemberOfParliament } from 'api/ParliamentTypes';

/**
 * Politician Model
 */
export default class Politician {
  private static readonly BASE_URL = 'MemberProfile';

  private readonly _parliamentPolitician: MemberOfParliament;

  constructor(parliamentPolitician: MemberOfParliament) {
    this._parliamentPolitician = parliamentPolitician;
  }

  /**
   * Get the unique identifier for this politician
   * */
  public getId(): number {
    return this._parliamentPolitician.id;
  }

  /**
   * Get link to the view URL for this politician
   * @returns The full link to their profile
   */
  public getLinkToProfile(): string {
    return ParliamentAPIUtils.getViewURL(`${Politician.BASE_URL}/${this.getId()}`);
  }


  /**
   * Gets the english party name of this politician
   */
  public getPartyName(): string {
    return this._parliamentPolitician.caucusShortName;
  }

  // #region Contact Info
  /**
   * Get the politicans phone number
   * @returns 
   */
  public getPhoneNumber(): string {
    // todo implement
    return 'TODO: Get phone numbers';
  }

  /**
   * Get politicians twitter url, if known
   */
  public getTwitterUrl(): string | undefined {
    return 'TODO get twitterurl';
  }

  /**
   * Get politicians facebook url, if known
   */
  public getFacebookUrl(): string | undefined {
    // todo get this value
    return 'TODO get facebook';
  }

  // #endregion Contact Info
  /**
   * Get the photo url of this politician
   */
  public getPhotoURL(): string | undefined {
    return undefined;
    // return ParliamentAPIUtils.getAPIURL(this._parliamentPolitician.image);
  }

  /**
   * Get this politicians full name
   */
  public getFullName(): string {
    return `${this._parliamentPolitician.personOfficialFirstName} ${this._parliamentPolitician.personOfficialLastName}`;
  }

  /**
   * Get the riding this politician represents
   */
  public getRiding(): string {
    return `${this._parliamentPolitician.constituencyName} (${this._parliamentPolitician.constituencyProvinceTerritoryName})`;
  }
}