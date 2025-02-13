using System.Linq.Expressions;

namespace MultiShop.Order.Application.Interfaces.Repositories
{
    public interface IRepository<T, TId> where T : class

    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(TId id);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(TId id);

        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);
    }
}
