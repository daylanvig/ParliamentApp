export default class DateUtils {

  /**
   * Return display formatted date
   * @param date 
   * @returns The date, formatted for human display (MMM dd yyyy)
   */
  public static formatWithoutTime(date: Date): string {
    const dateParts = new Intl.DateTimeFormat('en-US', { day: 'numeric', month: 'short', year: 'numeric' }).formatToParts(date);
    return `${dateParts.find(d => d.type === 'month')?.value} ${dateParts.find(d => d.type === 'day')?.value} ${dateParts.find(d => d.type === 'year')?.value}`;
  }
}