using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serialization;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TikTok.ApiClient.Entities;
using TikTok.ApiClient.Exceptions;

namespace TikTok.ApiClient.Services
{
    internal class AuthenticationService
    {
        private static AccessTokenCacheProvider _accessTokenCacheProvider;
        private readonly string _appId;
        private readonly string _clientSecret;
        private string _accessToken;
        private const string _accessTokenKey = "AccessToken";

        internal AuthenticationService(string appId, string clientSecret, string accessToken)
        {
            _appId = appId;
            _clientSecret = clientSecret;
            _accessToken = accessToken;

            if (_accessTokenCacheProvider is null)
            {
                _accessTokenCacheProvider = new AccessTokenCacheProvider();
                AddTokenToCache();
            }
        }

        public string Get()
        {
            if (GetAccessTokenFromCache(out string accessToken))
            {
                return accessToken;
            }

            throw new Exceptions.UnauthorizedAccessException();
        }

        private bool GetAccessTokenFromCache(out string accessToken)
        {
            accessToken = string.Empty;

            if (_accessTokenCacheProvider.Contains(_accessTokenKey))
            {
                var cachedValue = _accessTokenCacheProvider.Get(_accessTokenKey);

                if (!string.IsNullOrEmpty(cachedValue))
                {
                    accessToken = cachedValue;

                    return true;
                }
            }

            return false;
        }

        private void AddTokenToCache()
        {
            _accessTokenCacheProvider.Add(_accessTokenKey, _accessToken);
        }
    }
}
