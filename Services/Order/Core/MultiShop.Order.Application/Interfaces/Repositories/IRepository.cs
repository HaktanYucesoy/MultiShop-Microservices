using MultiShop.Order.Domain.Common;
using System.Linq.Expressions;

namespace MultiShop.Order.Application.Interfaces.Repositories
{
    public interface IRepository<T, TId> where T : BaseEntity<TId>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
        Task<IReadOnlyList<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter,
            params Expression<Func<T, object>>[] includes);

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> UpdateWithNavigationAsync(T entity, params Expression<Func<T, object>>[] includeProperties);
        Task<bool> DeleteAsync(TId id);

        Task<T> GetByIdAsync(TId id);

        Task<T> GetByIdWithIncludesAsync(TId id, params Expression<Func<T, object>>[] includes);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
