using Serilog;


namespace MultiShop.Order.Infrastructure.Logging.Serilog.Factory
{
    public class ConsoleSinkFactory:ISerilogSinkFactory
    {
        private readonly string _outputTemplate;

        public ConsoleSinkFactory(string outputTemplate)
        {
            _outputTemplate = outputTemplate;
        }
        public LoggerConfiguration ConfigureSink(LoggerConfiguration configuration)
        {
            return configuration.WriteTo.Console(
                outputTemplate: _outputTemplate
            );
        }
    }
}
