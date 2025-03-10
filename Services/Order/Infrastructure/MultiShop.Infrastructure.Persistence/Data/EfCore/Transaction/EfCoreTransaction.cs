using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MultiShop.Order.Application.Interfaces.Transaction;
using MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Context;


namespace MultiShop.Order.Infrastructure.Persistence.Data.EfCore.Transaction
{
    public class EfCoreTransaction<TContext>:ITransaction
        where TContext:DbContext
    {
        private TContext _context;
        public IDbContextTransaction _transaction { get; set; }
        public EfCoreTransaction(TContext context)
        {
            _context= context;
            _transaction = _context.Database.BeginTransaction();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            if(_transaction!=null && !String.IsNullOrEmpty(_transaction.TransactionId.ToString()))
            {
                await _transaction.CommitAsync(cancellationToken);
            }
                
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction != null && !String.IsNullOrEmpty(_transaction.TransactionId.ToString()))
            {
                await _transaction.RollbackAsync(cancellationToken);
            }          
        }
    }
}
