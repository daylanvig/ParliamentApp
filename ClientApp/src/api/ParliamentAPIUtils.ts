import Configuration from 'Configuration';
import StringUtils from 'utils/StringUtils';
import URLUtils from 'utils/URLUtils';
import ArgumentError from 'errors/ArgumentError';

/**
 * Utility functions involving the API
 */
export default class ParliamentAPIUtils {
  private static readonly BASE_API_URL = Configuration.apiUrl;
  private static readonly BASE_VIEW_URL = Configuration.baseUrl;

  /**
   * Get the url to build the api path
   * @param relativePath 
   */
  public static getAPIURL(relativePath: string): string {
    if (StringUtils.isNullOrEmpty(relativePath)) {
      throw new ArgumentError('relativePath', relativePath, 'Value can not be null or empty');
    }
    return URLUtils.buildURL(this.BASE_API_URL, relativePath);
  }

  /**
   * Get the url to view the path on openparliament.ca
   * @param relativePath 
   */
  public static getViewURL(relativePath: string): string {
     if (StringUtils.isNullOrEmpty(relativePath)) {
       throw new ArgumentError('relativePath', relativePath, 'Value can not be null or empty');
     }
     return URLUtils.buildURL(this.BASE_VIEW_URL, relativePath);
  }
}