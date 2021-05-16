using ParliamentApp.Infrastructure.Data;
using ParliamentApp.Models;
using ParliamentApp.Models.APIParameters;
using ParliamentApp.Models.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ParliamentApp.Infrastructure.QueryEvaluators
{

    public class MemberVotesResourceParameterQueryEvaluator : IMemberVotesResourceParameterQueryEvaluator
    {
        private readonly IReadOnlyRepository<Vote> _voteRepository;

        public MemberVotesResourceParameterQueryEvaluator(IReadOnlyRepository<Vote> voteRepository)
        {
            _voteRepository = voteRepository;
        }

        public Task<IQueryable<MemberVote>> Evaluate(IQueryable<MemberVote> items, IMemberVoteResourceParameters queryParameters)
        {
            var query = items;
            if (queryParameters.MemberOfParliamentId.HasValue)
            {
                query = items.Where(mv => mv.MemberOfParliamentId == queryParameters.MemberOfParliamentId.Value);
            }

            if (queryParameters.ParliamentNumber.HasValue)
            {
                query = query.Where(mv => mv.Vote.ParliamentPeriod.ParliamentNumber == queryParameters.ParliamentNumber.Value);
            }

            return Task.FromResult(query);
        }

        public Task<IQueryable<MemberVote>> Evaluate(IQueryable<MemberVote> items, IPagedListParameters pagedListParameters)
        {
            return Evaluate(items, pagedListParameters as IMemberVoteResourceParameters);
        }
    }
}
