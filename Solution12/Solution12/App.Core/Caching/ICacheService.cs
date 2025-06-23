using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.Caching
{
    public interface ICacheService
    {
        Task SetAsync<T>(string cacheKey, T value, TimeSpan? expireTime = null);
        Task<T?> GetAsync<T>(string cacheKey);

        Task<bool> AnyAsync(string cacheKey);
        Task RemoveAsync(string cacheKey);
        void RemoveAllAsync();
    }
}
