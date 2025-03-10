using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Application.Interfaces.Transaction;
using MultiShop.Order.Application.Interfaces.UnitOfWork;
using MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Transaction;


namespace MultiShop.Order.Infrastructure.Persistence.Data.EfCore.UnitOfWork
{
    public class EfCoreUnitOfWork<TContext> : IUnitOfWork
        where TContext:DbContext
    {
        private readonly TContext _dbContext;
        private EfCoreTransaction<TContext> _efCoreTransaction;
        private bool _disposed = false;
        public EfCoreUnitOfWork(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ITransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                _efCoreTransaction = new EfCoreTransaction<TContext>(_dbContext);
                
            });

            return _efCoreTransaction;
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {        
            await _efCoreTransaction.CommitAsync(cancellationToken);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // DbContext'i dispose et
                    _dbContext.Dispose();
                }

                _disposed = true;
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _efCoreTransaction.RollbackAsync(cancellationToken);
        }
    }
}
