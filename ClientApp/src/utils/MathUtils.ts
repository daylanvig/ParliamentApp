export default class MathUtils {

  /**
   * Calculate the percentage difference of the provided values
   * @param numerator 
   * @param denominator 
   */
  public static calculatePercentageDifference(numerator: number, denominator: number): number {
    if (denominator === 0) {
      throw new Error('Unable to divide by 0');
    }
    return 100 - (numerator / denominator) * 100;
  }
}