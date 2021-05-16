using AutoMapper;
using ParliamentApp.GovernmentAPI.Models;
using ParliamentApp.Models;

namespace ParliamentApp.MappingProfiles
{
    /// <summary>
    /// Map models retrieved from government API to core models
    /// </summary>
    public class GovernmentDataMappingProfile : Profile
    {
        public GovernmentDataMappingProfile()
        {
            CreateMap<GovernmentMemberOfParliament, MemberOfParliament>()
                .ForMember(d => d.ParliamentPersonId, o => o.MapFrom(s => s.PersonId))
                .Ignore(d => d.Id);
            CreateMap<GovernmentVote, Vote>()
                .Ignore(d => d.ParliamentPeriodId)
                .Ignore(d => d.ParliamentPeriod)
                .Ignore(d => d.MemberVotes)
                .Ignore(d => d.Id);
        }
    }
}
