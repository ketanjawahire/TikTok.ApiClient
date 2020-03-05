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

        public async Task<AuthResponse> Get()
        {
            if (GetAccessTokenFromCache(out AuthResponse cachedResponse))
            {
                return cachedResponse;
            }

            var response = GetAccessTokenFromApi(_refreshToken);

            var authResponse = await response;

            AddTokenToCache(authResponse.Data);

            return authResponse.Data;
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

        private async Task<AuthResponseRootObject> GetAccessTokenFromApi(string refreshToken)
        {
            var result = new AuthResponseRootObject();
            var response = new HttpResponseMessage();
            var responseBody = string.Empty;

            var requestBody = new
            {
                app_id = _appId,
                secret = _clientSecret,
                grant_type = "refresh_token",
                refresh_token = refreshToken
            };

            var request = new HttpRequestMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, ContentType.Json),
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://ads.tiktok.com/open_api/oauth2/refresh_token/")
            };

            using (var httpClient = new HttpClient())
            {
                response = await httpClient.SendAsync(request);
                responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                result = JsonConvert.DeserializeObject<AuthResponseRootObject>(responseBody);
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                if (result.Code == 40103)
                {
                    throw new Exceptions.UnauthorizedAccessException();
                }

                return result;
            }

            // TODO : move deserialize into separate method
            var apiError = Deserialize<ErrorResponse>(responseBody);

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
