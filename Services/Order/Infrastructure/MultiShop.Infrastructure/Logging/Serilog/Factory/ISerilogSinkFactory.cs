using Serilog.Core;
using Serilog;

namespace MultiShop.Order.Infrastructure.Logging.Serilog.Factory
{
    public interface ISerilogSinkFactory
    {
        LoggerConfiguration ConfigureSink(LoggerConfiguration configuration);
    }
}
