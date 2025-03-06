using Elastic.Clients.Elasticsearch;
using Microsoft.Extensions.Options;
using MultiShop.Order.Infrastructure.SearchEngine.ElasticSearch.Configuration;
using MultiShop.Order.Infrastructure.SearchEngine.ElasticSearch.Interfaces;

namespace MultiShop.Order.Infrastructure.SearchEngine.ElasticSearch.Implemantations
{
    public class BaseElasticSearchEngineService<T> : IElasticSearchEngineService<T>
    {
        protected readonly ElasticsearchClient _elasticSearchClient;
        private readonly ElasticSettings _elasticSettings;

        public BaseElasticSearchEngineService(IOptions<ElasticSettings> elasticSettings)
        {
            _elasticSettings = elasticSettings.Value;
            var settings = new ElasticsearchClientSettings(new Uri(_elasticSettings.Url))
            .DefaultIndex(_elasticSettings.DefaultIndex);

            _elasticSearchClient = new ElasticsearchClient(settings);

        }
        public async Task<bool> AddOrUpdate(T entity)
        {
            var response = await _elasticSearchClient.IndexAsync(entity, (idx) =>
            {
                idx.Index(_elasticSettings.DefaultIndex)
                .OpType(OpType.Index);
            });

            return response.IsValidResponse;
        }

        public async Task<bool> AddOrUpdateBulkAsync(IEnumerable<T> entities, string indexName)
        {
            var response = await _elasticSearchClient.BulkAsync(b =>
            {
                b.Index(_elasticSettings.DefaultIndex)
                 .UpdateMany(entities, (ud, u) =>
                 {
                     ud.Doc(u).DocAsUpsert(true);
                 });
            });

            return response.IsValidResponse;
        }

        public async Task CreateIndexIfNotExistsAsync(string indexName)
        {
            if (!_elasticSearchClient.Indices.ExistsAsync(indexName).Result.Exists)
            {
                await _elasticSearchClient.Indices.CreateAsync(indexName);
            }
        }

        public async Task<bool> Delete(string key)
        {
            var deleteResponse = await _elasticSearchClient.DeleteAsync<T>(key, d =>
            {
                d.Index(_elasticSettings.DefaultIndex);
            });

            return deleteResponse.Result == Result.Deleted || deleteResponse.IsValidResponse;
        }

        public async Task<long?> DeleteAll()
        {
            var deleteAllResponse = await _elasticSearchClient.DeleteByQueryAsync<T>(d =>
            {
                d.Indices(_elasticSettings.DefaultIndex);
            });

            return deleteAllResponse.Deleted;
        }

        public async Task<T> Get(string key)
        {
            var response = await _elasticSearchClient.GetAsync<T>(key, (idx) =>
            {
                idx.Index(_elasticSettings.DefaultIndex);
            });

            return response.Source!;
        }

        public async Task<IList<T>> GetAll()
        {
            var response = await _elasticSearchClient.SearchAsync<T>(s =>
            {
                s.Index(_elasticSettings.DefaultIndex);
            });

            return response.Documents.ToList();
        }
    }
}
