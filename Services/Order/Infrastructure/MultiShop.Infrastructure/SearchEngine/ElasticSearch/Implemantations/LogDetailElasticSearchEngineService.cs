using Microsoft.Extensions.Options;
using MultiShop.Order.Application.Models.Logging;
using MultiShop.Order.Infrastructure.SearchEngine.ElasticSearch.Configuration;
using MultiShop.Order.Infrastructure.SearchEngine.ElasticSearch.Interfaces;

namespace MultiShop.Order.Infrastructure.SearchEngine.ElasticSearch.Implemantations
{
    public class LogDetailElasticSearchEngineService : BaseElasticSearchEngineService<LogDetail>,
        ILogDetailElasticSearchEngineService
    {
        public LogDetailElasticSearchEngineService(IOptions<ElasticSettings> elasticSettings) : base(elasticSettings)
        {
            
        }
    }
}
