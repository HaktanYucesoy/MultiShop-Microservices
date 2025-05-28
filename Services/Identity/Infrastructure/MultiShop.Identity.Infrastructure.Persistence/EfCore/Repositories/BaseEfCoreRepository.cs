using Microsoft.EntityFrameworkCore;
using MultiShop.Identity.Application.Exceptions.CRUD;
using MultiShop.Identity.Application.Interfaces.Repositories;
using MultiShop.Identity.Domain.Entities;
using System.Linq.Expressions;

namespace MultiShop.Identity.Infrastructure.Persistence.EfCore.Repositories
{
    public class BaseEntityFrameworkCoreRepository<TEntity> : IAsyncRepository<TEntity, int>
        where TEntity : BaseEntity<int>
    {
        private readonly MultiShopIdentityContext _dbContext;

        public BaseEntityFrameworkCoreRepository(MultiShopIdentityContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(TEntity entity)
        {   
            var existEntity= _dbContext.Set<TEntity>().Find(entity.Id);
            if (existEntity != null)
            {
                DeleteOrThrow(entity);
                if (_dbContext.SaveChanges() <= 0)
                {
                    throw new EntityDeleteFailedException(nameof(TEntity));
                }
            }
            else
            {
                throw new EntityNotFoundException(nameof(TEntity), entity.Id);
            }
        }

        public bool DeleteAndReturnDeletedStatus(TEntity entity)
        {
            var existEntity = _dbContext.Set<TEntity>().Find(entity.Id);
            if (existEntity != null)
            {
                DeleteOrThrow(entity);
                var deletedCount = _dbContext.SaveChanges();
                if (deletedCount <= 0)
                {
                    throw new EntityDeleteFailedException(nameof(TEntity));
                }

                return deletedCount > 0;
            }
            else
            {
                throw new EntityNotFoundException(nameof(TEntity), entity.Id);
            }
        }

        public async Task<bool> DeleteAndReturnDeletedStatusAsync(TEntity entity)
        {
            var existEntity = await _dbContext.Set<TEntity>().FindAsync(entity.Id);
            if (existEntity != null)
            {
                DeleteOrThrow(entity);
                var result = await _dbContext.SaveChangesAsync();
                if(result <= 0)
                {
                    throw new EntityDeleteFailedException(nameof(TEntity));
                }

                return result > 0;
            }
            else
            {
                throw new EntityNotFoundException(nameof(TEntity), entity.Id);
            }
        }

        public async Task DeleteAsync(TEntity entity)
        {
            var existEntity = await _dbContext.Set<TEntity>().FindAsync(entity.Id);
            if (existEntity != null)
            {
                DeleteOrThrow(entity);
                if (await _dbContext.SaveChangesAsync() <= 0)
                {
                    throw new EntityDeleteFailedException(nameof(TEntity));
                }
            }
            else
            {
                throw new EntityNotFoundException(nameof(TEntity), entity.Id);
            }
        }


        public IList<TEntity> GetAll()
        {
            var allEntities=_dbContext.Set<TEntity>().ToList();
            return allEntities;
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            var allEntities=await _dbContext.Set<TEntity>().ToListAsync();
            return allEntities;
        }

        public TEntity GetByFilter(Expression<Func<TEntity, bool>> predicate)
        {
            var entity=_dbContext.Set<TEntity>().FirstOrDefault(predicate);

            if (entity == null)
            {
                throw new EntityNotFoundException(nameof(TEntity));
            }
            return entity;
        }

        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
            return entity??throw new EntityNotFoundException(nameof(TEntity));
        }

        public TEntity GetById(int id)
        {
            var entity=_dbContext.Set<TEntity>().Find(id);
            return entity??throw new EntityNotFoundException(nameof(TEntity), id);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);
            return entity ?? throw new EntityNotFoundException(nameof(TEntity), id);
        }

        public IList<TEntity> GetListByFilter(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToList() ?? new List<TEntity>();
        }

        public async Task<IList<TEntity>> GetListByFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).ToListAsync() ?? new List<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            InsertOrThrow(entity);
            if (_dbContext.SaveChanges() <= 0)
            {
                throw new EntityInsertFailedException(nameof(TEntity));
            }
        }

        public TEntity InsertAndReturnInsertedValue(TEntity entity)
        {
            InsertOrThrow(entity);
            var saveChangeResult = _dbContext.SaveChanges();
            return saveChangeResult <= 0 ?
                throw new EntityInsertFailedException(nameof(TEntity)) : entity;
        }

       

        public async Task<TEntity> InsertAndReturnInsertedValueAsync(TEntity entity)
        {
            await InsertOrThrowAsync(entity);
            var saveChangeResult = await _dbContext.SaveChangesAsync();
            return saveChangeResult <= 0 && entity.Id == 0 ?
                throw new EntityInsertFailedException(nameof(TEntity)) : entity;
        }

        public async Task InsertAsync(TEntity entity)
        {
            await InsertOrThrowAsync(entity);
            var saveChangeResult = await _dbContext.SaveChangesAsync();
            if (saveChangeResult <= 0 && entity.Id == 0)
            {
                throw new EntityInsertFailedException(nameof(TEntity));
            }
        }

      

        public void Update(TEntity entity)
        {
            var existEntity = _dbContext.Set<TEntity>().Find(entity.Id);
            if (existEntity != null)
            {
                UpdateOrThrow(entity, existEntity);
                var updateResult = _dbContext.SaveChanges();
                if (updateResult <= 0)
                {
                    throw new EntityUpdateFailedException(nameof(TEntity));
                }
            }
            else
            {
                throw new EntityNotFoundException(nameof(TEntity), entity.Id);
            }
        }

        public TEntity UpdateAndReturnUpdatedValue(TEntity entity)
        {
            var existEntity = _dbContext.Set<TEntity>().Find(entity.Id);
            if (existEntity != null)
            {
                UpdateOrThrow(entity, existEntity);
                return _dbContext.SaveChanges() <= 0 ?
                    throw new EntityUpdateFailedException(nameof(TEntity)) : entity;
            }
            else
            {
                throw new EntityNotFoundException(nameof(TEntity), entity.Id);
            }
        }

        public async Task<TEntity> UpdateAndReturnUpdatedValueAsync(TEntity entity)
        {
            var existEntity = _dbContext.Set<TEntity>().Find(entity.Id);
            if (existEntity != null)
            {
                UpdateOrThrow(entity, existEntity);
                return await _dbContext.SaveChangesAsync()<=0?
                   throw new EntityUpdateFailedException(nameof(TEntity)) : entity;
            }
            else
            {
                throw new EntityNotFoundException(nameof(TEntity), entity.Id);
            }
        }

       
        public async Task UpdateAsync(TEntity entity)
        {
            var existEntity = _dbContext.Set<TEntity>().Find(entity.Id);
            if (existEntity != null)
            {
                UpdateOrThrow(entity, existEntity);
                if (await _dbContext.SaveChangesAsync() <= 0)
                    throw new EntityUpdateFailedException(nameof(TEntity));
            }
            else
            {
                throw new EntityNotFoundException(nameof(TEntity), entity.Id);
            }
        }

        private void UpdateOrThrow(TEntity entity, TEntity? existEntity)
        {
            try
            {
                _dbContext.Entry(existEntity).CurrentValues.SetValues(entity);
            }
            catch (Exception ex)
            {
                throw new EntityUpdateFailedException(nameof(TEntity), ex);
            }
        }

        private async Task InsertOrThrowAsync(TEntity entity)
        {
            try
            {
                await _dbContext.AddAsync(entity);
            }

            catch (Exception ex)
            {
                throw new EntityInsertFailedException(nameof(TEntity), ex);
            }
        }

        private void InsertOrThrow(TEntity entity)
        {
            try
            {
                _dbContext.Add(entity);
            }

            catch (Exception ex)
            {
                throw new EntityInsertFailedException(nameof(TEntity), ex);
            }
        }

        private void DeleteOrThrow(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw new EntityDeleteFailedException(nameof(TEntity), ex);
            }
        }

    }
}
