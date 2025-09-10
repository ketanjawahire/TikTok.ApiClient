using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TikTok.ApiClient.Entities;
using TikTok.ApiClient.Exceptions;
using TikTok.ApiClient.Services.Interfaces;
using UnauthorizedAccessException = TikTok.ApiClient.Exceptions.UnauthorizedAccessException;

namespace TikTok.ApiClient.Services
{
    internal abstract class BaseService : IApiService
    {
        public string BaseUrl = "https://business-api.tiktok.com/open_api";
        public string Version = "v1.3";

        private readonly AuthenticationService _authService;

        internal BaseService(AuthenticationService authenticationService)
        {
            _authService = authenticationService;
        }

        public async Task<TEntity> Execute<TEntity>(HttpRequestMessage message)
            where TEntity : class, new()
        {
            var accessToken = _authService.Get();

            var httpClientHandler = new HttpClientHandler {AllowAutoRedirect = true, MaxAutomaticRedirections = 10};
            using (var client = new HttpClient(httpClientHandler))
            {
                message.Headers.TryAddWithoutValidation("Content-Type", "application/json");
                message.Headers.TryAddWithoutValidation("Access-Token", $"{accessToken}");
                
                var response = await client.SendAsync(message);
                var content = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                switch ((int) response.StatusCode)
                {
                    case 200:
                    {
                        var result = Deserialize<TEntity>(content);
                        return result;
                    }
                    case 401:
                        throw new UnauthorizedAccessException();
                    case 308:
                    case 307:
                        // Get the location header
                        var newMessage = new HttpRequestMessage(message.Method, message.RequestUri);
                        newMessage.RequestUri = response.Headers.Location;
                        return await Execute<TEntity>(newMessage);
                    default:
                    {
                        var apiError = Deserialize<ApiError>(content);
                        throw new ApiException(apiError, response.StatusCode);
                    }
                }
            }
        }

        public async Task MultiplePageHandler<TRoot, TWrapper, TEntity>(TWrapper wrapper, string resourceUrl, NameValueCollection queryStringCollection, List<TEntity> entityList)
            where TRoot : class, IRootObject<TWrapper, TEntity>, new()
            where TWrapper : class, IWrapper<TEntity>, new()
            where TEntity : class, IApiEntity, new()
        {
            entityList.AddRange(wrapper.List);

            var pageInfo = wrapper.PageInfo;
            var currentPage = pageInfo.Page;
            var totalPages = pageInfo.TotalPage;

            while (currentPage < totalPages)
            {
                currentPage++;
                if (queryStringCollection["page"] is null)
                {
                    queryStringCollection.Add("page", currentPage.ToString());
                }
                else
                {
                    queryStringCollection["page"] = currentPage.ToString();
                }
                
                if (queryStringCollection["page_size"] is null)
                {
                    queryStringCollection.Add("page_size", wrapper.PageInfo.PageSize.ToString());
                }
                else
                {
                    queryStringCollection["page_size"] = wrapper.PageInfo.PageSize.ToString();
                }
                
                var message = new HttpRequestMessage(HttpMethod.Get, $"{resourceUrl}?{queryStringCollection}");
                var currentPageResponse = await Execute<TRoot>(message);
                var currentPageResult = Extract<TRoot, TWrapper, TEntity>(currentPageResponse);
                if(currentPageResponse.code == 0)
                {
                    entityList.AddRange(currentPageResult.List);
                }
                else
                {
                    throw new ApiException($"ApiResponseCode: {currentPageResponse.code}, ErrorMessage: {currentPageResponse.Message}",new ApiError { Code = currentPageResponse.code, Data = currentPageResponse.Data, Message = currentPageResponse.Message });
                }
            }
        }

        protected TWrapper Extract<TRoot, TWrapper, TEntity>(TRoot response)
            where TRoot : class, IRootObject<TWrapper, TEntity>, new()
            where TWrapper : class, IWrapper<TEntity>, new()
            where TEntity : class, IApiEntity, new()
        {
            if (response is null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            return response.Data;
        }

        private static JsonSerializer GetJsonSerializer()
        {
            var jsonSerializer = new JsonSerializer
            {
                CheckAdditionalContent = true,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ConstructorHandling = ConstructorHandling.Default,
                ObjectCreationHandling = ObjectCreationHandling.Auto,
                NullValueHandling = NullValueHandling.Ignore
            };

            return jsonSerializer;
        }
        
        private static T Deserialize<T>(string content)
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
 