using System.Threading.Tasks;

namespace ParliamentApp.Services
{
    /// <summary>
    /// Service to receive data from government of canada api, process it, and store in local database
    /// </summary>
    public interface IGovernmentDataProcessingService
    {
        /// <summary>
        /// Check for new data, updating databases
        /// </summary>
        /// <returns></returns>
        Task StoreMembersOfParliamentAsync(int parliamentNumber);
        Task StoreMemberVotesAsync(int parliamentNumber, int sessionNumber, int decisionDivisionNumber);
        Task StoreVotesAsync(int parliamentNumber, int sessionNumber);
    }
}
