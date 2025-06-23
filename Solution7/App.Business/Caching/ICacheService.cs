using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Business.Caching
{
    public interface ICacheService
    {
        Task SetAsync<T>(string key, T value, TimeSpan? expTimeSpan = null);
        Task<T?> GetAsync<T>(string key);

        Task<bool> AnyAsync(string key);

        Task RemoveAsync(string key);
        void RemoveAll();

    }
}
