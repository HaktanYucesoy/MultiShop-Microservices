using MultiShop.Order.Application.Interfaces.Transaction;
using MultiShop.Order.Application.Interfaces.UnitOfWork;
using MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Context;
using MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Transaction;


namespace MultiShop.Order.Infrastructure.Persistence.Data.EfCore.UnitOfWork
{
    public class EfCoreUnitOfWork : IUnitOfWork
    {
        private readonly OrderContext _dbContext;
        private bool _disposed = false;
        public EfCoreUnitOfWork(OrderContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ITransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            var transaction=await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            return new EfCoreTransaction(transaction);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_dbContext.Database.CurrentTransaction != null)
                await _dbContext.Database.CurrentTransaction.CommitAsync(cancellationToken);
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
            if (_dbContext.Database.CurrentTransaction != null)
                await _dbContext.Database.CurrentTransaction.RollbackAsync(cancellationToken);
        }
    }
}
