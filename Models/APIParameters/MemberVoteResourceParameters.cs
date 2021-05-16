using ParliamentApp.Models.Common;

namespace ParliamentApp.Models.APIParameters
{
    public class MemberVoteResourceParameters : PagedListParameters, IMemberVoteResourceParameters
    {
        public override int? PageSize { get; set; } = 9999;
        public int? MemberOfParliamentId { get; set; }
        public int? ParliamentNumber { get; set; }
    }
}
