using Serilog;

namespace MultiShop.Order.Infrastructure.Logging.Serilog.Factory
{
    public class FileSinkFactory : ISerilogSinkFactory
    {

        private readonly string _path;
        private readonly string _template;

        public FileSinkFactory(string path, string template)
        {
            _path = path;
            _template = template;
        }
        public LoggerConfiguration ConfigureSink(LoggerConfiguration configuration)
        {
            return configuration.WriteTo.File(
                path: _path,
                outputTemplate: _template,
                rollingInterval: RollingInterval.Day
            );
        }
    }
}
