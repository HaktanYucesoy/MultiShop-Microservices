using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Exceptions.Common;
using MultiShop.Order.Application.Interfaces.Repositories;
using MultiShop.Order.Domain.Common;
using MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Context;
using System.Linq.Expressions;


namespace MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Repositories
{
    public class BaseEfCoreRepository<T> : IRepository<T, int>
        where T:BaseEntity<int>
    {
        protected readonly OrderContext _orderContext;
        public BaseEfCoreRepository(OrderContext orderContext)
        {
            _orderContext= orderContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            _orderContext.Set<T>().Add(entity);
            await _orderContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _orderContext.Set<T>().FindAsync(id);
            if (entity == null)
                return false;

            _orderContext.Set<T>().Remove(entity);
            return await _orderContext.SaveChangesAsync() > 0;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _orderContext.Set<T>().ToListAsync();
        }

        public virtual async Task<IReadOnlyList<T>> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes)
        {
            var query = _orderContext.Set<T>().AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) =>
                    current.Include(include));
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            var response=await _orderContext.Set<T>()
                .FirstOrDefaultAsync(filter);

            if (response == null)
                return null!;

            return response;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var response= await _orderContext.Set<T>().FindAsync(id);
            if (response == null)
                return null!;

            return response;
        }

        public virtual async Task<T> GetByIdWithIncludesAsync(int id, params Expression<Func<T, object>>[] includes)
        {
            var query = _orderContext.Set<T>().AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) =>
                    current.Include(include));
            }

            var response= await query.FirstOrDefaultAsync(e => e.Id == id);
            if (response == null)
                return null!;

            return response;
        }

        public async Task<IReadOnlyList<T>> GetListByFilterAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            var query = _orderContext.Set<T>().AsQueryable();

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) =>
                    current.Include(include));
            }

            return await query.Where(filter).ToListAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingEntity = await _orderContext.Set<T>()
                .FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (existingEntity == null)
                throw new NotFoundException(typeof(T).Name, entity.Id);

            _orderContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _orderContext.SaveChangesAsync();

            return existingEntity;
        }

        public async Task<T> UpdateWithNavigationAsync(T entity, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _orderContext.Set<T>().AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            var existingEntity = await query.FirstOrDefaultAsync(e => e.Id == entity.Id);

            if (existingEntity == null)
                return null!;

            _orderContext.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _orderContext.SaveChangesAsync();

            return existingEntity;
        }

      
    }
}
