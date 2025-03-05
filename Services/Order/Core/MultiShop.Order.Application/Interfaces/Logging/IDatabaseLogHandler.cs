using MultiShop.Order.Application.Enums;
using MultiShop.Order.Application.Models.Logging;

namespace MultiShop.Order.Application.Interfaces.Logging
{
    public interface IDatabaseLogHandler:ILogHandler
    {
        Task<IEnumerable<LogDetail>> QueryLogsAsync(DateTime startDate, DateTime endDate, LogLevel? level = null);
        Task PurgeLogsAsync(DateTime olderThan);
    }
}
