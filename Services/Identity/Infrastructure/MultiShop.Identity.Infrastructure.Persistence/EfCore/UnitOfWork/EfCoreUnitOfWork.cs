using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using MultiShop.Identity.Application.Interfaces.Repositories;
using MultiShop.Identity.Application.Interfaces.UnitOfWork;
using MultiShop.Identity.Domain.Entities;

namespace MultiShop.Identity.Infrastructure.Persistence.EfCore.UnitOfWork
{
    public class EfCoreUnitOfWork : IUnitOfWork
    {
        private readonly MultiShopIdentityContext _ctx;
        private readonly IServiceProvider _sp;
        private IDbContextTransaction? _tx;

        public EfCoreUnitOfWork(MultiShopIdentityContext ctx, IServiceProvider sp)
        {
            _ctx = ctx;
            _sp = sp;
        }
        public IAsyncRepository<TEntity, TKey> Repository<TEntity, TKey>()
        where TEntity : BaseEntity<TKey>
        => _sp.GetRequiredService<IAsyncRepository<TEntity, TKey>>();
        public int Commit() => _ctx.SaveChanges();

        public Task<int> CommitAsync(CancellationToken ct = default)
            => _ctx.SaveChangesAsync(ct);

        public void Dispose() => _ctx.Dispose();
        public ValueTask DisposeAsync() => _ctx.DisposeAsync();

        public async Task ExecuteInTransactionAsync(
            Func<CancellationToken, Task> work,
            CancellationToken ct = default)
        {
            _tx ??= await _ctx.Database.BeginTransactionAsync(ct);

            try
            {
                await work(ct);          
                await CommitAsync(ct);  
                await _tx.CommitAsync(ct);
            }
            catch
            {
                await _tx.RollbackAsync(ct);
                throw;
            }
            finally
            {
                await _tx.DisposeAsync();
                _tx = null;
            }
        }


    }
}
