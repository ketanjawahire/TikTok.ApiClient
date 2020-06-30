using System;
using System.Runtime.Caching;

namespace TikTok.ApiClient.Services
{
    /// <summary>
    /// Represents cache provider used to cache API access tokens.
    /// </summary>
    internal class AccessTokenCacheProvider : IDisposable
    {
        private const int _cacheItemLifeTimeInMinutes = 30;
        private const string _cacheName = "TikTok.ApiClient.AccessTokens";
        private MemoryCache _memoryCache;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccessTokenCacheProvider"/> class.
        /// </summary>
        internal AccessTokenCacheProvider()
        {
            if (_memoryCache is null)
            {
                _memoryCache = new MemoryCache(_cacheName);
            }
        }

        /// <summary>
        /// Add access token to cache. Here refresh token will be used as key.
        /// </summary>
        /// <param name="key">Key.</param>
        /// <param name="accessToken">Access token.</param>
        /// <returns>true if the insertion try succeeds, or false if there is an already an entry in the cache with the same key as key.</returns>
        public bool Add(string key, string accessToken)
        {
            if (_memoryCache.Contains(accessToken))
            {
                _memoryCache.Remove(accessToken);
            }

            return _memoryCache.Add(key, accessToken, new CacheItemPolicy() { AbsoluteExpiration = GetTokenExpirationTime() });
        }

        /// <summary>
        /// Returns access token value from cache.
        /// </summary>
        /// <param name="refreshToken">Refresh token.</param>
        /// <returns>A reference to the cache entry that is identified by key, if the entry exists; otherwise, null.</returns>
        public string Get(string refreshToken)
        {
            return _memoryCache.Get(refreshToken).ToString();
        }

        /// <summary>
        /// Determines whether a cache entry exists in the cache.
        /// </summary>
        /// <param name="refreshToken">Refresh token.</param>
        /// <returns>true if the cache contains a cache entry whose key matches key; otherwise, false.</returns>
        public bool Contains(string refreshToken)
        {
            return _memoryCache.Contains(refreshToken);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _memoryCache.Dispose();
        }

        private static DateTimeOffset GetTokenExpirationTime()
        {
            var inputTime = DateTime.SpecifyKind(DateTime.Now.AddMinutes(_cacheItemLifeTimeInMinutes), DateTimeKind.Unspecified);
            var expirationTime = new DateTimeOffset(inputTime);

            return expirationTime;
        }
    }
}
