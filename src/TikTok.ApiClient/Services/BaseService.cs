using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
        public string Version = "v1.2";

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

                switch ((int) response.StatusCode)
                {
                    case 200:
                    {
                        var result = Deserialize<TEntity>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
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
                        var apiError = Deserialize<ApiError>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                        throw new ApiException(apiError, response.StatusCode);
                    }
                }
            }
        }

        public async Task MultiplePageHandlerForHttpClient<TRoot, TWrapper, TEntity>(TWrapper wrapper, string resourceUrl, BaseRequestModel model, List<TEntity> entityList)
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
                var queryString = HttpUtility.ParseQueryString(string.Empty);
                foreach (var property in model.GetType().GetProperties())
                {
                    switch (property.Name)
                    {
                        case "Filtering":
                        {
                            var filterValue = JsonConvert.SerializeObject(property.GetValue(model, null), new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                            queryString.Add("filtering", filterValue);
                            break;
                        }
                        case "AdvertiserId":
                            queryString.Add("advertiser_id", property.GetValue(model, null).ToString());
                            break;
                        case nameof(BaseRequestModel.Page):
                            queryString.Add("page", currentPage.ToString());
                            break;
                        case nameof(BaseRequestModel.PageSize):
                            queryString.Add("page_size", wrapper.PageInfo.PageSize.ToString());
                            break;
                    }
                }
                var message = new HttpRequestMessage(HttpMethod.Get, $"{resourceUrl}?{queryString}");
                var currentPageResponse = await Execute<TRoot>(message);
                var currentPageResult = Extract<TRoot, TWrapper, TEntity>(currentPageResponse);
                entityList.AddRange(currentPageResult.List);
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
