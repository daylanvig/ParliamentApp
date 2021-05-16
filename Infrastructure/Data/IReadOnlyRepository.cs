using ParliamentApp.Infrastructure.QueryEvaluators;
using ParliamentApp.Models;
using ParliamentApp.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ParliamentApp.Infrastructure.Data
{
    public interface IReadOnlyRepository<TEntity> where TEntity : Entity
    {
        public Task<TEntity> GetByIdAsync(int id);
        /// <summary>
        /// List all entities in the repository
        /// </summary>
        /// <returns></returns>
        public Task<IReadOnlyList<TEntity>> ListAllAsync();
        /// <summary>
        /// List entities in the repository, with filters
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public Task<Pagination<TEntity>> ListAsync(IPagedListParameters parameters);
        /// <summary>
        /// List entities meeting the filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter);
        public IQueryable<TEntity> Queryable();
        /// <summary>
        /// Find unique entity by condition
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter);
        Task<Pagination<TEntity>> ListAsync(IPagedListParameters parameters, IResourceParameterEvaluator<TEntity> parameterEvaluator);
    }
}
