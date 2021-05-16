using ParliamentApp.Infrastructure.Data;
using ParliamentApp.Models;
using ParliamentApp.Models.APIParameters;
using ParliamentApp.Models.Common;
using ParliamentApp.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace ParliamentApp.Infrastructure.QueryEvaluators
{
    public class MembersOfParliamentResourceParameterQueryEvaluator : IMembersOfParliamentResourceParameterQueryEvaluator
    {
        private readonly IReadOnlyRepository<ParliamentPeriod> _parliamentPeriodRepository;

        public MembersOfParliamentResourceParameterQueryEvaluator(IReadOnlyRepository<ParliamentPeriod> parliamentPeriodRepository)
        {
            _parliamentPeriodRepository = parliamentPeriodRepository;
        }


        public async Task<IQueryable<MemberOfParliament>> Evaluate(IQueryable<MemberOfParliament> members, IMembersOfParliamentResourceParameters queryParameters)
        {
            var query = members;
            if (queryParameters.ParliamentNumber.HasValue)
            {
                var parliamentPeriods = await _parliamentPeriodRepository.ListAsync(p => p.ParliamentNumber == queryParameters.ParliamentNumber.Value);
                var earliestStart = parliamentPeriods.Min(p => p.StartDate);
                var latestEnd = parliamentPeriods.Any(p => p.EndDate == null) ? null : parliamentPeriods.Max(p => p.EndDate);
                if (latestEnd == null)
                {
                    // they're currently active (no end)
                    query = members.Where(m => m.ToDateTime == null ||
                    // or they ended inside the period
                                                 m.ToDateTime > earliestStart);
                }
                else
                {
                    // to be active in the period
                    // they need to have started before on at the start of the period
                    // and ended during or after the end of the period
                    query = members.Where(m =>
                                 (m.FromDateTime <= earliestStart && (m.ToDateTime == null || m.ToDateTime > earliestStart))
                           );
                }
            }


            return query;
        }

        public Task<IQueryable<MemberOfParliament>> Evaluate(IQueryable<MemberOfParliament> items, IPagedListParameters pagedListParameters)
        {
            return Evaluate(items, pagedListParameters as IMembersOfParliamentResourceParameters);
        }
    }
}
