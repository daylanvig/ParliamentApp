using ParliamentApp.Models.Common;

namespace ParliamentApp.Models.APIParameters
{
    public interface IMembersOfParliamentResourceParameters : IPagedListParameters
    {
        int? ParliamentNumber { get; set; }
    }
}