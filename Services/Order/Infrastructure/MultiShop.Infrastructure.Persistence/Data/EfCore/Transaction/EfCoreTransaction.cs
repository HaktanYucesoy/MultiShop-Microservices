using Microsoft.EntityFrameworkCore.Storage;
using MultiShop.Order.Application.Interfaces.Transaction;


namespace MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Transaction
{
    public class EfCoreTransaction : ITransaction
    {
        private readonly IDbContextTransaction _transaction;

        public EfCoreTransaction(IDbContextTransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.CommitAsync(cancellationToken);
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await _transaction.RollbackAsync(cancellationToken);
        }
    }
}
