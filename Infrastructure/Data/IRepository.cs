using ParliamentApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParliamentApp.Infrastructure.Data
{
    /// <summary>
    /// Repository for manipulating data
    /// </summary>
    /// <remarks>
    /// This repository is separated from the 
    /// </remarks>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>number of saved results, from context.SaveChangesAsync</returns>
        Task<int> AddAsync(TEntity entity);
        /// <summary>
        /// Add entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>number of saved results, from context.SaveChangesAsync</returns>
        Task<int> AddAllAsync(IEnumerable<TEntity> entities);
        /// <summary>
        /// Edit entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Number of saved changes, from context.SaveChangesAsync</returns>
        Task<int> EditAsync(TEntity entity);
        /// <summary>
        /// Edit entities
        /// </summary>
        /// <param name="entities"></param>
        /// <returns>number of saved results, from context.SaveChangesAsync</returns>
        Task<int> EditAllAsync(IEnumerable<TEntity> entities);
    }
}