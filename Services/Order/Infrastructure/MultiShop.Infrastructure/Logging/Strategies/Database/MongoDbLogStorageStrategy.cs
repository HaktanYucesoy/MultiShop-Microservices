using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Order.Application.Enums;
using MultiShop.Order.Application.Interfaces.Logging.Strategies.Database;
using MultiShop.Order.Application.Models.Logging;


namespace MultiShop.Order.Infrastructure.Logging.Strategies.Database
{
    public class MongoDbLogStorageStrategy : IDocumentDbLogStorageStrategy
    {
        private readonly string _connectionString;
        private readonly string _databaseName;
        private readonly string _collectionName;
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDbLogStorageStrategy(string connectionString, string databaseName, string collectionName)
        {
            _connectionString = connectionString;
            _databaseName = databaseName;
            _collectionName = collectionName;

            _mongoClient = new MongoClient(_connectionString);
            _mongoDatabase = _mongoClient.GetDatabase(_databaseName);
        }

        public string StorageType => "MongoDB";

        public async Task EnsureCollectionExistsAsync()
        {
            var filter = new BsonDocument("name", _collectionName);
            var collections = await _mongoDatabase.ListCollectionsAsync(new ListCollectionsOptions { Filter = filter });

            if (!await collections.AnyAsync())
            {
                await _mongoDatabase.CreateCollectionAsync(_collectionName);
            }
        }

        public string GetCollectionName() => _collectionName;

        public async Task PurgeLogsAsync(DateTime olderThan)
        {
            var _collection = _mongoDatabase.GetCollection<BsonDocument>(_collectionName);
            var filter = Builders<BsonDocument>.Filter.Lt("Timestamp", olderThan);
            await _collection.DeleteManyAsync(filter);
        }

        public async Task<IList<LogDetail>> QueryLogsAsync(DateTime startDate, DateTime endDate, LogLevel? level = null)
        {
            var _collection= _mongoDatabase.GetCollection<BsonDocument>(_collectionName);
            var filterBuilder = Builders<BsonDocument>.Filter;
            var filter = filterBuilder.Gte("Timestamp", startDate) & filterBuilder.Lte("Timestamp", endDate);

            if(level.HasValue)
            {
                filter &= filterBuilder.Eq("Level", level.Value.ToString());
            }

            var documents=await _collection.Find(filter).ToListAsync();

            return documents.Select(doc => new LogDetail
            {
                Message = doc["Message"].AsString,
                Level = ParseLogLevel(doc["Level"].AsString),
                Timestamp = doc["Timestamp"].ToUniversalTime(),
                Exception = doc.Contains("Exception") ? new Exception(doc["Exception"].AsString) : null!,
                AdditionalData = doc.Contains("AdditionalData") ? ConvertBsonToDict(doc["AdditionalData"].AsBsonDocument) : null,
                TraceId = doc.Contains("TraceId") ? doc["TraceId"].AsString : null,
                MethodName = doc.Contains("MethodName") ? doc["MethodName"].AsString : null
            }).ToList();

        }

        public async Task StoreLogAsync(LogDetail logDetail)
        {
            var _collection = _mongoDatabase.GetCollection<BsonDocument>(_collectionName);

            var document = new BsonDocument()
            {
                {"Message", logDetail.Message},
                {"Level", logDetail.Level.ToString()},
                {"Timestamp", logDetail.Timestamp},
                {"Exception", logDetail.Exception?.Message},
                {"TraceId", logDetail.TraceId},
                {"MethodName", logDetail.MethodName }
            };

            if (logDetail.AdditionalData != null)
            {
                var additionalData = new BsonDocument();
                foreach (var (key, value) in logDetail.AdditionalData)
                {
                    additionalData.Add(key, BsonValue.Create(value));
                }
                document.Add("AdditionalData", additionalData);

            }

            await _collection.InsertOneAsync(document);
        }

        private LogLevel ParseLogLevel(string levelString)
        {
            return Enum.TryParse<LogLevel>(levelString, out var level) ? level : LogLevel.Information;
        }

        private Dictionary<string, object> ConvertBsonToDict(BsonDocument document)
        {
            Dictionary<string,object> result = new Dictionary<string, object>();
            foreach (var element in document)
            {
                result[element.Name] = BsonTypeMapper.MapToDotNetValue(element.Value);
            }

            return result;
        }
    }
}
