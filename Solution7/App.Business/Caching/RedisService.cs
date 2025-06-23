using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Business.Caching
{
    public class RedisService(IConnectionMultiplexer redis) : ICacheService
    {
        private readonly IDatabase _database = redis.GetDatabase();

        public async Task SetAsync<T>(string key, T value, TimeSpan? expTimeSpan = null)
        {
            var json = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value));
            await _database.StringSetAsync(key, json, expTimeSpan);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var json = await _database.StringGetAsync(key);
            return json.HasValue ? JsonSerializer.Deserialize<T>(json) : default;
        }
        public Task<bool> AnyAsync(string key)
        {
            return Task.FromResult(_database.KeyExists(key));
        }

        public async Task RemoveAsync(string key)
        {
            await _database.KeyDeleteAsync(key);
        }

        public void RemoveAll()
        {
            var redisEndPoints = redis.GetEndPoints(true);
            foreach (var redisEndPoint in redisEndPoints)
            {
                var redisServer = redis.GetServer(redisEndPoint);
                redisServer.FlushAllDatabases();
            };
        }
    }
}
