using MultiShop.Order.Application.Enums;
using MultiShop.Order.Application.Interfaces.Logging;
using MultiShop.Order.Application.Models.Logging;
using MultiShop.Order.Infrastructure.Logging.Serilog.Factory;
using Serilog;
using Serilog.Events;
using Serilog.Parsing;


namespace MultiShop.Order.Infrastructure.Logging.Serilog
{
    public class SerilogLogHandler : ILogHandler
    {
        private readonly ILogger _logger;

        public SerilogLogHandler(IEnumerable<ISerilogSinkFactory> factories)
        {
            var configuration = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .Enrich.WithThreadId()
                .Enrich.WithEnvironmentUserName();

            foreach (var factory in factories)
            {
                configuration = factory.ConfigureSink(configuration);
            }

            _logger = configuration.CreateLogger();

        }
        public async Task HandleLogAsync(LogDetail logdetail)
        {
            if(logdetail == null)
              throw new ArgumentNullException(nameof(logdetail));
       
            LogEvent logEvent = CreateLogEvent(logdetail);
            _logger.Write(logEvent);
            await Task.CompletedTask;
        }

        private LogEvent CreateLogEvent(LogDetail logDetail)
        {
            var level = MapLogLevel(logDetail.Level);
            var properties = new List<LogEventProperty>();

            if (logDetail.AdditionalData != null)
            {
                foreach (var data in logDetail.AdditionalData)
                {
                    properties.Add(new LogEventProperty(data.Key, new ScalarValue(data.Value)));
                }
            }

            if (!string.IsNullOrEmpty(logDetail.MethodName))
            {
                properties.Add(new LogEventProperty("MethodName", new ScalarValue(logDetail.MethodName)));
            }

            if (!string.IsNullOrEmpty(logDetail.TraceId))
            {
                properties.Add(new LogEventProperty("TraceId", new ScalarValue(logDetail.TraceId)));
            }

            return new LogEvent(
                timestamp: logDetail.Timestamp,
                level: level,
                exception: logDetail.Exception,
                messageTemplate: new MessageTemplate(logDetail.Message, new List<MessageTemplateToken>()),
                properties: properties
            );
        }

        private LogEventLevel MapLogLevel(LogLevel level) => level switch
        {
            LogLevel.Debug => LogEventLevel.Debug,
            LogLevel.Information => LogEventLevel.Information,
            LogLevel.Warning => LogEventLevel.Warning,
            LogLevel.Error => LogEventLevel.Error,
            _ => LogEventLevel.Information
        };
    }
}
