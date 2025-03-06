using MultiShop.Order.Application.Interfaces.Logging;
using MultiShop.Order.Application.Models.Logging;
using MultiShop.Order.Infrastructure.SearchEngine.ElasticSearch.Interfaces;

namespace MultiShop.Order.Infrastructure.Logging.ElasticSearch
{
    public class ElasticSearchLogHandler : ILogHandler
    {
        private ILogDetailElasticSearchEngineService _logDetailElasticSearchEngineService;

        public ElasticSearchLogHandler(ILogDetailElasticSearchEngineService logDetailElasticSearchEngineService)
        {
            _logDetailElasticSearchEngineService = logDetailElasticSearchEngineService;
        }

        public async Task HandleLogAsync(LogDetail logdetail)
        {
            await _logDetailElasticSearchEngineService.CreateIndexIfNotExistsAsync("order-logs");
            await _logDetailElasticSearchEngineService.AddOrUpdate(logdetail);
        }
    }
}
