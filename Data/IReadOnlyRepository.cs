using ParliamentAPI.Models.Common;
using System.Collections.Generic;

namespace ParliamentAPI.Data
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        public IReadOnlyList<TEntity> ListAllAsync();
        public IReadOnlyList<TEntity> ListAsync(IPagedListParameters parameters);
    }
}
