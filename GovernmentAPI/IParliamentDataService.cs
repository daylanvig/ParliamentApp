using ParliamentApp.GovernmentAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParliamentApp.GovernmentAPI
{
    public interface IParliamentDataService
    {
        /// <summary>
        /// Load members of parliament, by the parliament number
        /// </summary>
        /// <param name="parliamentNumber">Parliament number - current number is "42"</param>
        /// <returns></returns>
        Task<IEnumerable<GovernmentMemberOfParliament>> LoadMembersOfParliamentAsync(int parliamentNumber);
        /// <summary>
        /// Load Member Votes
        /// </summary>
        /// <param name="parliamentNumber"></param>
        /// <param name="sessionNumber"></param>
        /// <param name="decisionDivisionNumber"></param>
        /// <returns></returns>
        Task<IEnumerable<GovernmentMemberVote>> LoadMemberVotesAsync(int parliamentNumber, int sessionNumber, int decisionDivisionNumber);
        /// <summary>
        /// Load the list of votes held in the session
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        Task<IEnumerable<GovernmentVote>> LoadVotesAsync(int parliamentNumber, int sessionNumber);
    }
}