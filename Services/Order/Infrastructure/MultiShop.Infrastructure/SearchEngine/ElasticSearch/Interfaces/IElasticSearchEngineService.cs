using MultiShop.Order.Application.Interfaces.SearchEngine;


namespace MultiShop.Order.Infrastructure.SearchEngine.ElasticSearch.Interfaces
{
    public interface IElasticSearchEngineService<T>:ISearchEngineService<T,string>
    {
        Task CreateIndexIfNotExistsAsync(string indexName);
        Task<bool> AddOrUpdateBulkAsync(IEnumerable<T> entities, string indexName);
    }
}
