using MultiShop.Identity.Application.Interfaces.Repositories;
using MultiShop.Identity.Domain.Entities;


namespace MultiShop.Identity.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork:IDisposable,IAsyncDisposable
    {
        
            IAsyncRepository<TEntity, TKey> Repository<TEntity,TKey>()
                where TEntity : BaseEntity<TKey>;

            /* Commit & Transaction */
            Task<int> CommitAsync(CancellationToken ct = default);
            int Commit();
            Task ExecuteInTransactionAsync(Func<CancellationToken, Task> work,
                                           CancellationToken ct = default);
        

    }
}
