using System;
using Microsoft.Extensions.Caching.Distributed;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CyberAge.Authorization.Jwt.Abstractions;

namespace CyberAge.Authorization.Jwt.Providers
{
    /// <summary>
    /// Реализация сервиса хранения cookie при помощи кэша
    /// </summary>
    public class CookieStorageService : ICookieStorage
    {
        private readonly IDistributedCache _cache;

        /// <summary/>
        public CookieStorageService(IDistributedCache cache)
        {
            _cache = cache;
        }

        /// <inheritdoc />
        public async Task SaveCookie(Guid cookieGuid, CookieContainer cookie)
        {
            var binaryFormatter = new BinaryFormatter();
            var resultDataStream = new MemoryStream();
            binaryFormatter.Serialize(resultDataStream, cookie);
            await _cache.SetAsync($"_session_{cookieGuid}", resultDataStream.ToArray(), new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1) });
        }

        /// <inheritdoc />
        public async Task<CookieContainer> GetCookie(Guid cookieGuid)
        {
            var binaryFormatter = new BinaryFormatter();
            var buffer = await _cache.GetAsync($"_session_{cookieGuid}");
            if (buffer == null)
            {
                return null;
            }
            var cookie = binaryFormatter.Deserialize(new MemoryStream(buffer)) as CookieContainer;
            return cookie;
        }
    }
}
