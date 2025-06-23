using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Core.Caching
{
    public class RedisService(IConnectionMultiplexer redis) : ICacheService
    {
        private readonly IDatabase database = redis.GetDatabase();


        public async Task SetAsync<T>(string cacheKey, T value, TimeSpan? expireTime = null)
        {
            var json = JsonConvert.SerializeObject(value);
            await database.StringSetAsync(cacheKey, json, expireTime);
        }

        public async Task<T?> GetAsync<T>(string cacheKey)
        {
            var json = await database.StringGetAsync(cacheKey);
            return json.HasValue ? JsonConvert.DeserializeObject<T>(json) : default;
        }

        public Task<bool> AnyAsync(string cacheKey)
        {
            return Task.FromResult(database.KeyExists(cacheKey));
        }

        public async Task RemoveAsync(string cacheKey)
        {
            await database.KeyDeleteAsync(cacheKey);
        }

        public void RemoveAllAsync()
        {
            foreach (var redisEndpoint in redis.GetEndPoints())
            {
                redis.GetServer(redisEndpoint).FlushAllDatabases();
            }
        }
    }
}
