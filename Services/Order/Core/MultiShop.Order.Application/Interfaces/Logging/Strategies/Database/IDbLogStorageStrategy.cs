using MultiShop.Order.Application.Enums;
using MultiShop.Order.Application.Models.Logging;

namespace MultiShop.Order.Application.Interfaces.Logging.Strategies.Database
{
    public interface IDbLogStorageStrategy
    {
        string StorageType { get; }
        Task StoreLogAsync(LogDetail logDetail);
        Task<IList<LogDetail>> QueryLogsAsync(DateTime startDate, DateTime endDate, LogLevel? level = null);
        Task PurgeLogsAsync(DateTime olderThan);
    }
}
