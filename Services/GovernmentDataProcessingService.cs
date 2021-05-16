using AutoMapper;
using Microsoft.Extensions.Logging;
using ParliamentApp.GovernmentAPI;
using ParliamentApp.GovernmentAPI.Models;
using ParliamentApp.Infrastructure.Data;
using ParliamentApp.Models;
using ParliamentApp.Models.Common;
using ParliamentApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ParliamentApp.Services
{

    /// <inheritdoc cref="IGovernmentDataProcessingService"/>
    public class GovernmentDataProcessingService : IGovernmentDataProcessingService
    {
        private readonly IParliamentDataService _parliamentDataService;
        private readonly IRepository<Vote> _voteRepository;
        private readonly IRepository<MemberVote> _memberVoteRepository;
        private readonly IRepository<MemberOfParliament> _memberOfParliamentRepository;
        private readonly IRepository<ParliamentPeriod> _parliamentPeriodRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GovernmentDataProcessingService> _logger;

        public GovernmentDataProcessingService(
            IParliamentDataService parliamentDataService,
            IMapper mapper,
            ILogger<GovernmentDataProcessingService> logger,
            IRepository<Vote> voteRepository,
            IRepository<MemberVote> memberVoteRepository,
            IRepository<MemberOfParliament> memberOfParliamentRepository,
            IRepository<ParliamentPeriod> parliamentPeriodRepository)
        {
            _parliamentDataService = parliamentDataService;
            _voteRepository = voteRepository;
            _memberVoteRepository = memberVoteRepository;
            _memberOfParliamentRepository = memberOfParliamentRepository;
            _parliamentPeriodRepository = parliamentPeriodRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task StoreMembersOfParliamentAsync(int parliamentNumber)
        {
            var membersForPeriod = await _parliamentDataService.LoadMembersOfParliamentAsync(parliamentNumber);
            // existing members that are already stored (e.g. politicians who were in multiple parliaments) shouldn't be overwritten
            var existingMembers = await _memberOfParliamentRepository.ListAsync(m => membersForPeriod.Select(mp => mp.PersonId).Contains(m.ParliamentPersonId));
            var newMembers = _mapper.Map<IEnumerable<MemberOfParliament>>(membersForPeriod.Where(m => !existingMembers.Any(e => e.ParliamentPersonId == m.PersonId)));
            if (!newMembers.Any())
            {
                _logger.LogWarning($"No new members found for parliament {parliamentNumber}");
                return;
            }
            await _memberOfParliamentRepository.AddAllAsync(newMembers);
        }

        public async Task StoreVotesAsync(int parliamentNumber, int sessionNumber)
        {
            var parliamentPeriod = await _parliamentPeriodRepository.FindAsync(p => p.ParliamentNumber == parliamentNumber && p.SessionNumber == sessionNumber);
            if (parliamentPeriod == null)
            {
                throw new ArgumentException($"A parliament period for {parliamentNumber}-{sessionNumber} was not found", nameof(parliamentNumber));
            }
            IEnumerable<GovernmentVote> votesInRange = await _parliamentDataService.LoadVotesAsync(parliamentNumber, sessionNumber);
            IEnumerable<Vote> votes = votesInRange.Select(v =>
            {
                var vote = _mapper.Map<Vote>(v);
                vote.ParliamentPeriodId = parliamentPeriod.Id;
                return vote;
            });
            await _voteRepository.AddAllAsync(votes);
        }

        public async Task StoreMemberVotesAsync(int parliamentNumber, int sessionNumber, int decisionDivisionNumber)
        {
            Vote vote = await _voteRepository.FindAsync(v => v.ParliamentPeriod.ParliamentNumber == parliamentNumber &&
                                                            v.ParliamentPeriod.SessionNumber == sessionNumber &&
                                                            v.DecisionDivisionNumber == decisionDivisionNumber);

            if (vote == null)
            {
                throw new ArgumentException("Vote not found");
            }

            IEnumerable<MemberOfParliament> membersOfParliament = await _memberOfParliamentRepository.ListAllAsync();

            IEnumerable<GovernmentMemberVote> governmentMemberVotes = await _parliamentDataService.LoadMemberVotesAsync(parliamentNumber, sessionNumber, decisionDivisionNumber);
            IEnumerable<MemberVote> memberVotes = governmentMemberVotes.Select(v =>
            {
                var memberOfParliament = membersOfParliament.Single(mp => mp.ParliamentPersonId == v.PersonId);
                return new MemberVote
                {
                    MemberOfParliamentId = memberOfParliament.Id,
                    VoteId = vote.Id,
                    VoteValue = Enum.Parse<VoteDecision>(v.VoteValueName)
                };
            });
            await _memberVoteRepository.AddAllAsync(memberVotes);
        }
    }
}
