using MultiShop.Order.Application.Interfaces.Logging.Strategies.Database;
using MultiShop.Order.Application.Models.Logging;
using NLog;
using NLog.Config;
using NLog.Targets;
namespace MultiShop.Order.Infrastructure.Logging.Nlog.Factories
{
    public class DatabaseNLogFactory : INLogFactory
    {
        private readonly IDbLogStorageStrategy _dbLogStrategy;
        private readonly string _targetName;
        private readonly LogLevel _minLevel;

        public DatabaseNLogFactory(IDbLogStorageStrategy dbLogStrategy, LogLevel minLevel, string targetName = "database")
        {
            _dbLogStrategy = dbLogStrategy ?? throw new ArgumentNullException(nameof(dbLogStrategy));
            _targetName = targetName;
            _minLevel = minLevel;
        }

        public void ConfigureTarget(LoggingConfiguration configuration)
        {
            var target = CreateTarget();
            configuration.AddTarget(target);
            var rule = new LoggingRule("*", LogLevel.FromOrdinal(_minLevel.Ordinal), target);
            configuration.LoggingRules.Add(rule);
        }

        public Target CreateTarget()
        {
            var target = new MethodCallTarget(_targetName)
            {
                ClassName=typeof(DatabaseNLogTargetHelper).AssemblyQualifiedName,
                MethodName=nameof(DatabaseNLogTargetHelper.WriteLog),
                Parameters=
                {
                    new MethodCallParameter("level", "${level}"),
                    new MethodCallParameter("message", "${message}"),
                    new MethodCallParameter("exception", "${exception}"),
                    new MethodCallParameter("properties", "${all-event-properties}")
                }
            };

            DatabaseNLogTargetHelper.RegisteryStrategy(_dbLogStrategy);

            return target;
        }

        //previousCode
        //private void OnLogEvent(LogEventInfo info, object[] parameters)
        //{
        //    var newLogDetail = new LogDetail()
        //    {
        //        AdditionalData = ExtractToAdditionalData(info),
        //        Exception = info.Exception,
        //        Level = MapToApplicationLogLevel(info.Level),
        //        Message = info.Message,
        //        Timestamp = info.TimeStamp,
        //        MethodName = info.Properties.ContainsKey("MethodName") ? (string)info.Properties["MethodName"] : "",
        //        TraceId = info.Properties.ContainsKey("TraceId") ? (string)info.Properties["TraceId"] : ""
        //    };

        //     _=_dbLogStrategy.StoreLogAsync(newLogDetail);
        //}

        //private Application.Enums.LogLevel MapToApplicationLogLevel(LogLevel level)
        //{
        //    if (level == LogLevel.Debug) return Application.Enums.LogLevel.Debug;
        //    if (level == LogLevel.Info) return Application.Enums.LogLevel.Information;
        //    if (level == LogLevel.Warn) return Application.Enums.LogLevel.Warning;
        //    if (level == LogLevel.Error) return Application.Enums.LogLevel.Error;

        //    return Application.Enums.LogLevel.Information;
        //}

        //private Dictionary<string, object> ExtractToAdditionalData(LogEventInfo logEventInfo)
        //{
        //    var result = new Dictionary<string, object>();

        //    foreach (var logEvent in logEventInfo.Properties)
        //    {
        //        string key = (string)logEvent.Key;
        //        if (key != "TraceId" && key != "MethodName")
        //        {
        //            result[key] = logEvent.Value;
        //        }
        //    }

        //    if (logEventInfo.Parameters != null)
        //    {
        //        for (int i = 0; i < logEventInfo.Parameters.Length; i++)
        //        {
        //            result[$"param{i}"] = logEventInfo.Parameters[i];
        //        }


        //    }

        //    return result;
        //}


    }

    public static class DatabaseNLogTargetHelper
    {
        private static IDbLogStorageStrategy _dbLogStorageStrategy;

        public static void RegisteryStrategy(IDbLogStorageStrategy dbLogStorageStrategy)
        {
            _dbLogStorageStrategy = dbLogStorageStrategy;
        }

        public static void WriteLog(string level, string message, Exception exception, IDictionary<object, object> properties)
        {
            if (_dbLogStorageStrategy == null)
                return;


            var newLogDetail = new LogDetail()
            {
                Timestamp = DateTime.Now,
                Level = ParseLogLevel(level),
                Message= message,
                MethodName = properties.ContainsKey("MethodName") ? properties["MethodName"]?.ToString():"",
                TraceId = properties.ContainsKey("TraceId") ?
                properties["TraceId"]?.ToString():"",
                AdditionalData=ExtractAdditionalData(properties)
            };

            _=_dbLogStorageStrategy.StoreLogAsync(newLogDetail);
        }

        private static IDictionary<string, object> ExtractAdditionalData(IDictionary<object, object> properties)
        {
            var result = new Dictionary<string, object>();

            if (properties == null)
                return result;

            foreach (var kvp in properties)
            {
                var key = kvp.Key.ToString();
                if (key != "TraceId" && key != "MethodName")
                {
                    result[key!] = kvp.Value;
                }
            }

            return result;
        }

        private static Application.Enums.LogLevel ParseLogLevel(string level)
        {
            return level.ToLowerInvariant() switch
            {           
                "debug" => Application.Enums.LogLevel.Debug,
                "info" => Application.Enums.LogLevel.Information,
                "warn" => Application.Enums.LogLevel.Warning,
                "error" => Application.Enums.LogLevel.Error,
                _ => Application.Enums.LogLevel.Information
            };
        }
    }
}
