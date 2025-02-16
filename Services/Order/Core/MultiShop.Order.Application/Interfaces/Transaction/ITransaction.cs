
namespace MultiShop.Order.Application.Interfaces.Transaction
{
    public interface ITransaction : IDisposable
    {
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}
