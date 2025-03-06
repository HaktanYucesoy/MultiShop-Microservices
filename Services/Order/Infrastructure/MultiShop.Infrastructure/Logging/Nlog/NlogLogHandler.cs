using MultiShop.Order.Application.Interfaces.Logging;
using MultiShop.Order.Application.Models.Logging;
using MultiShop.Order.Infrastructure.Logging.Nlog.Factories;
using NLog;
using NLog.Config;

namespace MultiShop.Order.Infrastructure.Logging.Nlog
{
    public class NlogLogHandler : ILogHandler
    {
        private readonly Logger _logger;

        public NlogLogHandler(IEnumerable<INLogFactory> factories)
        {
            var config = new LoggingConfiguration();

            foreach(var factory in factories)
            {
                factory.ConfigureTarget(config);
            }

            LogManager.Configuration=config;
            _logger = LogManager.GetCurrentClassLogger();
        }
        public async Task HandleLogAsync(LogDetail logdetail)
        {
            var logEvent= new LogEventInfo
            {
                Level = MapToNLogLevel(logdetail.Level),
                Message = logdetail.Message,
                Exception = logdetail.Exception,
                TimeStamp = logdetail.Timestamp
            };

            if (logdetail.AdditionalData != null)
            {
                foreach (var data in logdetail.AdditionalData)
                {
                    logEvent.Properties[data.Key]=data.Value;
                }
            }

            if (!string.IsNullOrEmpty(logdetail.TraceId))
            {
                logEvent.Properties["TraceId"] = logdetail.TraceId;
            }

            if(!string.IsNullOrEmpty(logdetail.MethodName))
            {
                logEvent.Properties["MethodName"] = logdetail.MethodName;
            }

            _logger.Log(logEvent);

            await Task.CompletedTask;
        }

        private NLog.LogLevel MapToNLogLevel(Application.Enums.LogLevel level) => level switch
        {
            
            Application.Enums.LogLevel.Debug => LogLevel.Debug,
            Application.Enums.LogLevel.Information => LogLevel.Info,
            Application.Enums.LogLevel.Warning => NLog.LogLevel.Warn,
            Application.Enums.LogLevel.Error => NLog.LogLevel.Error,
            _ => NLog.LogLevel.Info
        };
    }
}
