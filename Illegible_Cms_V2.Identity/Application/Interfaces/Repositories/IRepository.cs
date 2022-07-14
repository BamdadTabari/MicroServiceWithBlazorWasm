using Illegible_Cms_V2.Shared.BasicShared.Models;
using System.Linq.Expressions;

namespace Illegible_Cms_V2.Identity.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<bool> ExistsAsync(int id);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
    }
}
