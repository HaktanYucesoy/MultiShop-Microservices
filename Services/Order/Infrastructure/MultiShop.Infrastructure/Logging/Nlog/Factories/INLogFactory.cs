using NLog.Config;
using NLog.Targets;

namespace MultiShop.Order.Infrastructure.Logging.Nlog.Factories
{
    public interface INLogFactory
    {
        Target CreateTarget();
        void ConfigureTarget(LoggingConfiguration configuration);
    }
}
