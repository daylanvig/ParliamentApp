using Microsoft.AspNetCore.Mvc;
using ParliamentApp.Infrastructure.Data;
using ParliamentApp.Models;
using System.Threading.Tasks;

namespace ParliamentApp.Utility
{
    public static class ControllerUtilities
    {
        /// <summary>
        /// Performs getbyidasync logic
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="repository"></param>
        /// <param name="id"></param>
        /// <returns>A notfoundresult if the entity is not found, else an okobjectresult with the entity data</returns>
        public static async Task<ActionResult<TEntity>> GetByIdAsync<TEntity>(IReadOnlyRepository<TEntity> repository, int id) where TEntity : Entity
        {
            var entity = await repository.GetByIdAsync(id);
            if (entity == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(entity);
        }
    }
}
