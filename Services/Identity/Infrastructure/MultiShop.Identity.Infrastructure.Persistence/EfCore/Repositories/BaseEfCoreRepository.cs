using Microsoft.EntityFrameworkCore;
using MultiShop.Identity.Application.Exceptions.CRUD;
using MultiShop.Identity.Application.Interfaces.Repositories;
using MultiShop.Identity.Domain.Entities;
using System.Linq.Expressions;

namespace MultiShop.Identity.Infrastructure.Persistence.EfCore.Repositories
{
    /// <summary>
    /// Generic EF Core repository **Track‑Only** sürümü.
    /// SaveChanges / SaveChangesAsync çağrılarını içermez; kalıcılık IUnitOfWork
    /// tarafından tek noktadan (Commit / ExecuteInTransactionAsync) sağlanır.
    /// </summary>
    public class BaseEntityFrameworkCoreRepository<TEntity> : IAsyncRepository<TEntity, int>

        where TEntity : BaseEntity<int>
    {
        private readonly MultiShopIdentityContext _dbContext;

        public BaseEntityFrameworkCoreRepository(MultiShopIdentityContext dbContext)
        {
            _dbContext = dbContext;
        }

        /* ----------------------------------------------------------- */
        /* CRUD – sadece Track eder, commit IUnitOfWork’e bırakılır   */
        /* ----------------------------------------------------------- */

        #region Insert
        public void Insert(TEntity entity, bool save = false)
        {
            InsertOrThrow(entity);
            CommitIfRequested(save);
        }

        public async Task InsertAsync(TEntity entity, bool save = false)
        {
            await InsertOrThrowAsync(entity);
            await CommitIfRequestedAsync(save);
        }

        /// <summary>
        /// Eski semantiği korumak için: hemen DB’ye yazılması gerekiyorsa
        /// IUnitOfWork yerine doğrudan DbContext kullanmak isterseniz bu
        /// metodu <em>opsiyonel</em> olarak çağırabilirsiniz.
        /// </summary>
        public TEntity InsertAndReturnInsertedValue(TEntity entity,bool save=false)
        {
            InsertOrThrow(entity);
            CommitIfRequested(save);
            return entity;
        }

        public async Task<TEntity> InsertAndReturnInsertedValueAsync(TEntity entity,bool save=false)
        {
            await InsertOrThrowAsync(entity);
            await CommitIfRequestedAsync(save);
            return entity;
        }
        #endregion

        #region Update
        public void Update(TEntity entity, bool save = false)
        {
            var existEntity = _dbContext.Set<TEntity>().Find(entity.Id)
                               ?? throw new EntityNotFoundException(nameof(TEntity), entity.Id);
            UpdateOrThrow(entity, existEntity);
            CommitIfRequested(save);
        }

        public async Task UpdateAsync(TEntity entity, bool save = false)
        {
            var existEntity = await _dbContext.Set<TEntity>().FindAsync(entity.Id)
                               ?? throw new EntityNotFoundException(nameof(TEntity), entity.Id);
            UpdateOrThrow(entity, existEntity);
            await CommitIfRequestedAsync(save);
        }

        public TEntity UpdateAndReturnUpdatedValue(TEntity entity, bool save)
        {
            var existEntity = _dbContext.Set<TEntity>().Find(entity.Id)
                                         ?? throw new EntityNotFoundException(nameof(TEntity), entity.Id);
            UpdateOrThrow(entity, existEntity);
            CommitIfRequested(save);
            return entity;
        }



        public async Task<TEntity> UpdateAndReturnUpdatedValueAsync(TEntity entity,bool save=false)
        {
            var existEntity = await _dbContext.Set<TEntity>().FindAsync(entity.Id)
                               ?? throw new EntityNotFoundException(nameof(TEntity), entity.Id);
            UpdateOrThrow(entity, existEntity);
            await CommitIfRequestedAsync(save);
            return entity;
        }
        #endregion

        #region Delete
        public void Delete(TEntity entity, bool save = false)
        {
            var existEntity = _dbContext.Set<TEntity>().Find(entity.Id)
                               ?? throw new EntityNotFoundException(nameof(TEntity), entity.Id);
            DeleteOrThrow(existEntity);
            CommitIfRequested(save);
        }

        public async Task DeleteAsync(TEntity entity, bool save = false)
        {
            var existEntity = await _dbContext.Set<TEntity>().FindAsync(entity.Id)
                               ?? throw new EntityNotFoundException(nameof(TEntity), entity.Id);
            DeleteOrThrow(existEntity);
            await CommitIfRequestedAsync(save);
        }

        public bool DeleteAndReturnDeletedStatus(TEntity entity, bool save = false)
        {
            Delete(entity,save);
            var state = _dbContext.Entry(entity).State;
            return state == EntityState.Deleted
                || state == EntityState.Detached;
        }

        public async Task<bool> DeleteAndReturnDeletedStatusAsync(TEntity entity, bool save = false)
        {
            await DeleteAsync(entity,save);
            var state = _dbContext.Entry(entity).State;
            return state == EntityState.Deleted
                || state == EntityState.Detached;
        }
        #endregion

        public IList<TEntity> GetAll() => _dbContext.Set<TEntity>().ToList();

        public async Task<IList<TEntity>> GetAllAsync() => await _dbContext.Set<TEntity>().ToListAsync();

        public TEntity GetById(int id) => _dbContext.Set<TEntity>().Find(id)
                                         ?? throw new EntityNotFoundException(nameof(TEntity), id);

        public async Task<TEntity> GetByIdAsync(int id) => await _dbContext.Set<TEntity>().FindAsync(id)
                                                 ?? throw new EntityNotFoundException(nameof(TEntity), id);

        public TEntity GetByFilter(Expression<Func<TEntity, bool>> predicate) =>
            _dbContext.Set<TEntity>().FirstOrDefault(predicate)
            ?? throw new EntityNotFoundException(nameof(TEntity));

        public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate) =>
            await _dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate)
            ?? throw new EntityNotFoundException(nameof(TEntity));

        public IList<TEntity> GetListByFilter(Expression<Func<TEntity, bool>> predicate) =>
            _dbContext.Set<TEntity>().Where(predicate).ToList();

        public async Task<IList<TEntity>> GetListByFilterAsync(Expression<Func<TEntity, bool>> predicate) =>
            await _dbContext.Set<TEntity>().Where(predicate).ToListAsync();

        /* ----------------------------------------------------------- */
        /* Private Helper Metotlar                                     */
        /* ----------------------------------------------------------- */
        private async Task InsertOrThrowAsync(TEntity entity)
        {
            try { await _dbContext.AddAsync(entity); }
            catch (Exception ex) { throw new EntityInsertFailedException(nameof(TEntity), ex); }
        }

        private void InsertOrThrow(TEntity entity)
        {
            try { _dbContext.Add(entity); }
            catch (Exception ex) { throw new EntityInsertFailedException(nameof(TEntity), ex); }
        }

        private void UpdateOrThrow(TEntity entity, TEntity existEntity)
        {
            try { _dbContext.Entry(existEntity).CurrentValues.SetValues(entity); }
            catch (Exception ex) { throw new EntityUpdateFailedException(nameof(TEntity), ex); }
        }

        private void DeleteOrThrow(TEntity entity)
        {
            try { _dbContext.Remove(entity); }
            catch (Exception ex) { throw new EntityDeleteFailedException(nameof(TEntity), ex); }
        }

        private void CommitIfRequested(bool commit)
        {
            if (commit) _dbContext.SaveChanges();
        }
        private async Task CommitIfRequestedAsync(bool commit)
        {
            if (commit) await _dbContext.SaveChangesAsync();
        }
    }
}
