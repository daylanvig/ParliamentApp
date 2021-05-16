using Microsoft.EntityFrameworkCore;
using ParliamentApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParliamentApp.Infrastructure.Data
{
    /// <inheritdoc cref="IRepository{TEntity}"/>
    public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity> where TEntity : Entity
    {
        private readonly ParliamentContext _context;
        private readonly DbSet<TEntity> _table;


        public Repository(ParliamentContext context) : base(context)
        {
            _table = context.Set<TEntity>();
            _context = context;
        }

        #region PublicAPI Methods
        public Task<int> AddAsync(TEntity entity)
        {
            _table.Add(entity);
            return SaveChangesAsync();
        }

        public async Task<int> AddAllAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
            return await SaveChangesAsync();
        }


        public Task<int> EditAllAsync(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
            return SaveChangesAsync();
        }

        public Task<int> EditAsync(TEntity entity)
        {
            _table.Update(entity);
            return _context.SaveChangesAsync();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Save all changes in database
        /// </summary>
        /// <returns>Number of saved changes</returns>
        private Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        #endregion
    }
}
