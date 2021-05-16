namespace ParliamentApp.Models.APIParameters
{
    public interface IMemberVoteResourceParameters
    {
        int? MemberOfParliamentId { get; set; }
        int? PageSize { get; set; }
        int? ParliamentNumber { get; set; }
    }
}