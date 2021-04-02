namespace ParliamentAPI.Models.Common
{
    public abstract class PagedListParameters : IPagedListParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
