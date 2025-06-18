using MultiShop.Identity.Domain.Entities;
using System.Linq.Expressions;

namespace MultiShop.Identity.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        TEntity GetById(TKey id);
        TEntity GetByFilter(Expression<Func<TEntity,bool>> predicate);
        IList<TEntity> GetAll();
        IList<TEntity> GetListByFilter(Expression<Func<TEntity, bool>> predicate);
        void Insert(TEntity entity,bool save = false);
        void Update(TEntity entity, bool save = false);
        void Delete(TEntity entity, bool save = false);
        TEntity InsertAndReturnInsertedValue(TEntity entity,bool save=false);
        TEntity UpdateAndReturnUpdatedValue(TEntity entity,bool save=false);
        bool DeleteAndReturnDeletedStatus(TEntity entity, bool save = false);




    }
}
