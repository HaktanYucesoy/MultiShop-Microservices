using MultiShop.Identity.Domain.Entities;
using System.Linq.Expressions;

namespace MultiShop.Identity.Application.Interfaces.Repositories
{
    public interface IAsyncRepository<TEntity,TKey>:IRepository<TEntity,TKey>
        where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> GetAllAsync();
        Task<IList<TEntity>> GetListByFilterAsync(Expression<Func<TEntity, bool>> predicate);
        Task InsertAsync(TEntity entity,bool save=false);
        Task UpdateAsync(TEntity entity,bool save=false);
        Task DeleteAsync(TEntity entity, bool save = false);
        Task<TEntity> InsertAndReturnInsertedValueAsync(TEntity entity, bool save = false);
        Task<TEntity> UpdateAndReturnUpdatedValueAsync(TEntity entity, bool save = false);
        Task<bool> DeleteAndReturnDeletedStatusAsync(TEntity entity, bool save = false);
    }
}
