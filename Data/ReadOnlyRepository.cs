using ParliamentAPI.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParliamentAPI.Data
{
    public abstract class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        public IReadOnlyList<TEntity> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<TEntity> ListAsync(IPagedListParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
