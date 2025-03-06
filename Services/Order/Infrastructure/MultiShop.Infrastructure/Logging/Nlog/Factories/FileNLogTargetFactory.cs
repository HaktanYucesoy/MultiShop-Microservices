using NLog.Config;
using NLog.Targets;


namespace MultiShop.Order.Infrastructure.Logging.Nlog.Factories
{
    public class FileNLogTargetFactory : INLogFactory
    {
        private readonly string _fileName;
        private readonly string _layout;

        public FileNLogTargetFactory(string fileName, string layout)
        {
            _fileName = fileName;
            _layout = layout;
        }
        public void ConfigureTarget(LoggingConfiguration configuration)
        {
            var newTarget = CreateTarget();
            configuration.AddTarget(newTarget);
            configuration.AddRuleForAllLevels(newTarget);
        }

        public Target CreateTarget()
        {
            var newFileTarget = new FileTarget()
            {
                FileName = _fileName,
                Layout = _layout,
                ArchiveEvery = FileArchivePeriod.Day
            };

            return newFileTarget;
        }
    }
}
