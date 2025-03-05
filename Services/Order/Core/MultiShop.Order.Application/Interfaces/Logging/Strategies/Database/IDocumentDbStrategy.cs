
namespace MultiShop.Order.Application.Interfaces.Logging.Strategies.Database
{
    public interface IDocumentDbLogStorageStrategy:IDbLogStorageStrategy
    {
        string GetCollectionName();
        Task EnsureCollectionExistsAsync();
    }
}
