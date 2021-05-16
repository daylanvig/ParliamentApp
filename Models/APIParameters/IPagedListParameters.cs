namespace ParliamentApp.Models.Common
{
    public interface IPagedListParameters
    {
        int PageNumber { get; set; }
        int? PageSize { get; set; }
    }

    public interface IPagedListParameters<TEntity> : IPagedListParameters where TEntity : Entity
    {

    }
}