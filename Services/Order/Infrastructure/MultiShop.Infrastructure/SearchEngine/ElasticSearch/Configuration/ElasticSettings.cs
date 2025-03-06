namespace MultiShop.Order.Infrastructure.SearchEngine.ElasticSearch.Configuration
{
    public class ElasticSettings
    {
        public string Url { get; set; }
        public string DefaultIndex { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
