using ParliamentApp.Models;
using ParliamentApp.Models.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ParliamentApp.Infrastructure.QueryEvaluators
{
    public interface IResourceParameterEvaluator<TEntity> where TEntity : Entity
    {
        Task<IQueryable<TEntity>> Evaluate(IQueryable<TEntity> items, IPagedListParameters pagedListParameters);
    }
}
