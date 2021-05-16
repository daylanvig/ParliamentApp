using ParliamentApp.Models.Common;

namespace ParliamentApp.Models.APIParameters
{
    public class MembersOfParliamentResourceParameters : PagedListParameters, IMembersOfParliamentResourceParameters
    {
        public override int? PageSize { get; set; } = null;
        public int? ParliamentNumber { get; set; }
    }
}
