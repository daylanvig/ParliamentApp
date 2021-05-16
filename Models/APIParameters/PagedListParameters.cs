namespace ParliamentApp.Models.Common
{
    public class PagedListParameters : IPagedListParameters
    {
        public int PageNumber { get; set; } = 1;
        public virtual int? PageSize { get; set; } = 10;
    }
}
