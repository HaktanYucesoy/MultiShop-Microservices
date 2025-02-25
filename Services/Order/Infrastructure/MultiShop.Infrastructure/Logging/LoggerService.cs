using MultiShop.Order.Application.Enums;
using MultiShop.Order.Application.Interfaces.Logging;
using MultiShop.Order.Application.Models.Logging;
using System.Diagnostics;

namespace MultiShop.Order.Infrastructure.Logging
{
    public class LoggerService : ILoggerService
    {
        private readonly IEnumerable<ILogHandler> _logHandlers;

        public LoggerService(IEnumerable<ILogHandler> logHandlers)
        {
            _logHandlers = logHandlers;
        }

        public async Task LogDebugAsync(string message, string methodName, IDictionary<string, object> additionalData = null)
        {
            await LogAsync(message, LogLevel.Debug, methodName: methodName, additionalData: additionalData);
        }

        public async Task LogErrorAsync(string message, string methodName, Exception exception = null, IDictionary<string, object> additionalData = null)
        {
           await LogAsync(message, LogLevel.Error, exception, methodName, additionalData);
        }

        public async Task LogInformationAsync(string message, string methodName, IDictionary<string, object> additionalData = null)
        {
            await LogAsync(message, LogLevel.Information, methodName: methodName, additionalData: additionalData);
        }

        public async Task LogWarningAsync(string message, string methodName, IDictionary<string, object> additionalData = null)
        {
            await LogAsync(message, LogLevel.Warning, methodName: methodName, additionalData: additionalData);
        }

        private async Task LogAsync(string message,LogLevel level,Exception exception = null,string methodName = null,IDictionary<string, object> additionalData = null)
        {
            var logDetail = new LogDetail
            {
                Message = message,
                Level = level,
                Timestamp = DateTime.UtcNow,
                Exception = exception,
                AdditionalData = additionalData,
                TraceId = Activity.Current?.Id ?? Guid.NewGuid().ToString(),
                MethodName = methodName
            };

            foreach (var handler in _logHandlers)
            {
                await handler.HandleLogAsync(logDetail);
            }
        }
    }
}
