using System.Data;

namespace MultiShop.Order.Application.Interfaces.Logging.Strategies.Database
{
    public interface IRelationalDbLogStorageStrategy:IDbLogStorageStrategy
    {
        string GetProviderName();
        string GetConnectionString(string connectionString);
        string GetInsertCommandText(string tableName);
        IDbConnection CreateConnection(string connectionString);
    }
}
