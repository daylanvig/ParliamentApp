using ParliamentApp.Models.Common;

namespace ParliamentApp.Models.APIParameters
{
    public class VotePagedListParameters : PagedListParameters
    {
        public int? MemberOfParliamentId { get; set; }
    }
}
