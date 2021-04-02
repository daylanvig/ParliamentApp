namespace ParliamentAPI.Models.Common
{
    public interface IPagedListParameters
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
    }
}