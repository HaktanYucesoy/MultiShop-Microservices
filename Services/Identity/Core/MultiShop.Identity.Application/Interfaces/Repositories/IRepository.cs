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
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity InsertAndReturnInsertedValue(TEntity entity);
        TEntity UpdateAndReturnUpdatedValue(TEntity entity);
        bool DeleteAndReturnDeletedStatus(TEntity entity);




    }
}
