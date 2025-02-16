using MultiShop.Order.Application.Interfaces.Transaction;

namespace MultiShop.Order.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<ITransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}
