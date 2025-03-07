using Serilog;
using Serilog.Formatting.Elasticsearch;
using Serilog.Formatting.Json;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.File;

namespace MultiShop.Order.Infrastructure.Logging.Serilog.Factory
{
    public class ElasticSearchSinkFactory : ISerilogSinkFactory
    {
        private string elasticSearchUri;
        private string failureSinkPath;
        private string elasticSearchUserName;
        private string elasticSearchPassword;

        public ElasticSearchSinkFactory(
            string elasticSearchUri, 
            string failureSinkPath,
            string elasticSearchUserName, 
            string elasticSearchPassword)
        {
            this.elasticSearchUri = elasticSearchUri;
            this.failureSinkPath = failureSinkPath;
            this.elasticSearchUserName = elasticSearchUserName;
            this.elasticSearchPassword = elasticSearchPassword;
        }

        public LoggerConfiguration ConfigureSink(LoggerConfiguration configuration)
        {
            var sinkOptions = new ElasticsearchSinkOptions(new Uri(elasticSearchUri))
            {
                AutoRegisterTemplate = true,
                OverwriteTemplate = true,
                DetectElasticsearchVersion = true,
                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv8,
                IndexFormat = "order-logs-{0:yyyy.MM.dd}",
                NumberOfReplicas = 1,
                NumberOfShards = 2,
                EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog|
                                   EmitEventFailureHandling.WriteToFailureSink |
                                   EmitEventFailureHandling.RaiseCallback|
                                   EmitEventFailureHandling.ThrowException,
                FailureSink=new FileSink(failureSinkPath,new JsonFormatter(),null,null),
                FailureCallback = (e,ex) =>
                {
                    Console.WriteLine("Unable to submit event " + e.MessageTemplate);
                    Console.WriteLine("Unable to submit event exception detail: " + ex.Message);
                },
                CustomFormatter =new ExceptionAsObjectJsonFormatter(renderMessage: true),
                FormatStackTraceAsArray=true
              

            };

            if(!string.IsNullOrEmpty(elasticSearchUserName) && !string.IsNullOrEmpty(elasticSearchPassword))
            {
                sinkOptions.ModifyConnectionSettings = connectionConfiguration =>
                    connectionConfiguration.BasicAuthentication(elasticSearchUserName, elasticSearchPassword);
            }

            return configuration.WriteTo.Elasticsearch(sinkOptions);
        }
    }
}
