using MultiShop.Order.Application.Enums;
using MultiShop.Order.Application.Interfaces.Logging.Strategies.Database;
using MultiShop.Order.Application.Models.Logging;
using StackExchange.Redis;
using System.Text.Json;


namespace MultiShop.Order.Infrastructure.Logging.Strategies.Database
{
    public class RedisDbLogStorageStrategy : IDbLogStorageStrategy
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly string _keyPrefix;

        public RedisDbLogStorageStrategy(string connectionString, string keyPrefix)
        {
            _redis = ConnectionMultiplexer.Connect(connectionString);
            _keyPrefix = keyPrefix;
        }
        public string StorageType => "Redis";


        public async Task PurgeLogsAsync(DateTime olderThan)
        {
            var db= _redis.GetDatabase();
            var maxTicks = olderThan.Ticks;

            var keys = db.SortedSetRangeByScore($"{_keyPrefix}:time-index", 0, maxTicks);

            foreach(var key in keys)
            {
                var stringKey = (string)key!;
                var logJson=await db.StringGetAsync(stringKey);

                if (logJson.HasValue)
                {
                    var log = JsonSerializer.Deserialize<LogDetail>(logJson!);
                    await db.SetRemoveAsync($"{_keyPrefix}:level:{log!.Level}", stringKey);
                }

                await db.KeyDeleteAsync(stringKey);
            }
        }

        public async Task<IList<LogDetail>> QueryLogsAsync(DateTime startDate, DateTime endDate, LogLevel? level = null)
        {
            var db = _redis.GetDatabase();
            var startTicks = startDate.Ticks;
            var endTicks = endDate.Ticks;

            var keys = db.SortedSetRangeByScore($"{_keyPrefix}:time-index", startTicks, endTicks);

            if (level.HasValue)
            {
                var levelKeys = await db.SetMembersAsync($"{_keyPrefix}:level:{level.Value}");
                keys = keys.Intersect(levelKeys).ToArray();
            }

            var tasks = keys.Select(key => db.StringGetAsync((string)key!!=null?(string)key!:key.ToString()));
            var values = await Task.WhenAll(tasks);

            return values.Where(v => v.HasValue).Select(v => JsonSerializer.Deserialize<LogDetail>(v.ToString())).ToList()!;

        }

        public async Task StoreLogAsync(LogDetail logDetail)
        {
            var db = _redis.GetDatabase();
            var key = $"{_keyPrefix}:{logDetail.Timestamp.Ticks}:{Guid.NewGuid()}";
            var value = JsonSerializer.Serialize(logDetail);

            await db.StringSetAsync(key, value);
            await db.SortedSetAddAsync($"{_keyPrefix}:time-index", key, logDetail.Timestamp.Ticks);
            await db.SetAddAsync($"{_keyPrefix}:level:{logDetail.Level}", key);
        }
    }
}
