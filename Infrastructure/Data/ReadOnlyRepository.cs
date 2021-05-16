using Microsoft.EntityFrameworkCore;
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
    /// <inheritdoc cref="IReadOnlyRepository{TEntity}"/>
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : Entity
    {
        private readonly IQueryable<TEntity> _entities;

        public ReadOnlyRepository(ParliamentContext context)
        {
            _entities = context.Set<TEntity>();
        }

        public Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _entities.SingleOrDefaultAsync(filter);
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            return _entities.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IReadOnlyList<TEntity>> ListAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<Pagination<TEntity>> ListAsync(IPagedListParameters parameters, IResourceParameterEvaluator<TEntity> parameterEvaluator)
        {
            var items = parameterEvaluator == null ? _entities : await parameterEvaluator.Evaluate(_entities, parameters);
            var sizeToUse = parameters.PageSize ?? 9999;
            var results = await items
                                .Select(e => new
                                {
                                    Total = items.Count(),
                                    Values = items
                                                    .Skip((parameters.PageNumber - 1) * sizeToUse)
                                                    .Take(sizeToUse).ToList()
                                    // need to check for defaults for if query returns null
                                }).FirstOrDefaultAsync();
            if (results == null)
            {
                results = new
                {
                    Total = 0,
                    Values = new List<TEntity>()
                };
            }
            return new Pagination<TEntity>(results.Values, results.Total, parameters.PageNumber, sizeToUse);
        }

        public Task<Pagination<TEntity>> ListAsync(IPagedListParameters parameters)
        {
            return ListAsync(parameters, null);
        }

        public async Task<IEnumerable<TEntity>> ListAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _entities.Where(filter).ToListAsync();
        }

        public IQueryable<TEntity> Queryable()
        {
            return _entities;
        }
    }
}
