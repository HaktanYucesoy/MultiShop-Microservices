
namespace MultiShop.Order.Application.Interfaces.SearchEngine
{
    public interface ISearchEngineService<T,TKey>
    {
        Task<bool> AddOrUpdate(T entity);
        Task<T> Get(TKey key);

        Task<IList<T>> GetAll();
        Task<bool> Delete(TKey key);
        Task<long?> DeleteAll();

    }
}
