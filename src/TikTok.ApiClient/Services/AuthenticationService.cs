using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using TikTok.ApiClient.Exceptions;

namespace TikTok.ApiClient.Services
{
    internal class AuthenticationService
    {
        private static AccessTokenCacheProvider _accessTokenCacheProvider;
        private readonly string _appId;
        private readonly string _clientSecret;
        private readonly IRestClient _restClient;
        private string _refreshToken;

        internal AuthenticationService(string appId, string clientSecret, string refreshToken)
        {
            _appId = appId;
            _clientSecret = clientSecret;
            _refreshToken = refreshToken;

            _restClient = new RestClient("https://ads.tiktok.com");

            if (_accessTokenCacheProvider is null)
            {
                _accessTokenCacheProvider = new AccessTokenCacheProvider();
            }
        }

        public AuthResponse Get()
        {
            if (GetAccessTokenFromCache(out AuthResponse cachedResponse))
            {
                return cachedResponse;
            }

            var response = GetAccessTokenFromApi(_refreshToken);

            var authResponse = response.Data;

            AddTokenToCache(authResponse);

            return authResponse;
        }

        private static JsonSerializer GetJsonSerializer()
        {
            var jsonSerializer = new JsonSerializer
            {
                CheckAdditionalContent = true,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ConstructorHandling = ConstructorHandling.Default,
                ObjectCreationHandling = ObjectCreationHandling.Auto,
            };

            return jsonSerializer;
        }

        private static string Serialize(object input)
        {
            var jsonSerializer = GetJsonSerializer();
            var result = new StringBuilder();

            using (var writer = new JsonTextWriter(new StringWriter(result)) { Formatting = Formatting.None })
                jsonSerializer.Serialize(writer, input);

            return result.ToString();
        }

        private AuthResponseRootObject GetAccessTokenFromApi(string refreshToken)
        {
            var request = new RestRequest("/open_api/oauth2/refresh_token/", Method.POST);

            request.AddJsonBody(new { app_id = _appId, secret = _clientSecret, grant_type = "refresh_token", refresh_token = refreshToken });

            var response = _restClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = Deserialize<AuthResponseRootObject>(response.Content);
                return result;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException();

            // TODO : move deserialize into seperate method
            var apiError = Deserialize<ErrorResponse>(response.Content);

            throw new ApiException(apiError, response.StatusCode);
        }

        private bool GetAccessTokenFromCache(out AuthResponse authResponse)
        {
            authResponse = new AuthResponse();

            if (_accessTokenCacheProvider.Contains(_refreshToken))
            {
                var cachedValue = _accessTokenCacheProvider.Get(_refreshToken);

                if (!string.IsNullOrEmpty(cachedValue))
                {
                    authResponse = Deserialize<AuthResponse>(cachedValue);

                    return true;
                }
            }

            return false;
        }

        private void AddTokenToCache(AuthResponse authResponse)
        {
            _accessTokenCacheProvider.Add(_refreshToken, Serialize(authResponse));
        }

        private T Deserialize<T>(string content)
            where T : class, new()
        {
            var jsonSerializer = GetJsonSerializer();

            using (var reader = new JTokenReader(JToken.Parse(content)))
            {
                var result = jsonSerializer.Deserialize<T>(reader);

                return result;
            }
        }
    }
}
