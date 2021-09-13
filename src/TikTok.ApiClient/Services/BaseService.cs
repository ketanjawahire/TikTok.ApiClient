using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TikTok.ApiClient.Entities;
using TikTok.ApiClient.Exceptions;
using TikTok.ApiClient.Helpers;
using TikTok.ApiClient.Services.Interfaces;
using UnauthorizedAccessException = TikTok.ApiClient.Exceptions.UnauthorizedAccessException;

namespace TikTok.ApiClient.Services
{
    internal abstract class BaseService : IApiService
    {
        private const string _apiRequestBaseUrl = "https://business-api.tiktok.com/open_api/";

        private AuthenticationService _authService;
        private RestClient _restClient;

        internal BaseService(AuthenticationService authenticationService)
        {
            _authService = authenticationService;
            _restClient = new RestClient(_apiRequestBaseUrl);
        }

        public async Task<TEntity> Execute<TEntity>(HttpRequestMessage message)
            where TEntity : class, new()
        {
            var accessToken = _authService.Get();

            using (var client = new HttpClient())
            {
                message.Headers.TryAddWithoutValidation("Content-Type", "application/json");
                message.Headers.TryAddWithoutValidation("Access-Token", $"{accessToken}");

                var response = await client.SendAsync(message);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var result = Deserialize<TEntity>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                    return result;
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }

                // TODO : move deserialize into seperate method
                var apiError = Deserialize<ApiError>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult());

                throw new ApiException(apiError, response.StatusCode);
            }
        }

        public async Task<TEntity> Execute<TEntity>(IRestRequest restRequest)
            where TEntity : class, new()
        {
            Authorize();

            var response = _restClient.Execute(restRequest);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var result = Deserialize<TEntity>(response.Content);
                return result;
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedAccessException();
            }

            // TODO : move deserialize into seperate method
            var apiError = Deserialize<ApiError>(response.Content);

            throw new ApiException(apiError, response.StatusCode);
        }

        //protected static string GetRestReqestUrlFromPagingUrl(string pagingUrl)
        //{
        //    return string.IsNullOrEmpty(pagingUrl) ? pagingUrl : pagingUrl.Replace($"{_apiRequestBaseUrl}{_apiVersion}", string.Empty);
        //}

        //TODO : Fix paging
        //protected IEnumerable<TEntity> ExecutePagedRequest<TRoot, TEntity>(string url, PagingOption pagingOption)
        //    where TRoot : class, IRootObject<TEntity>, new()
        //    where TEntity : class, IApiEntity, new()
        //{
        //    if (pagingOption is null)
        //    {
        //        throw new ArgumentNullException(nameof(pagingOption), Constants.INVALID_PAGEOPTIONS);
        //    }

        //    List<TEntity> entities = null;
        //    var counter = 0;

        //    do
        //    {
        //        var request = new RestRequest(url, Method.GET);

        //        var response = Execute<TRoot>(request);
        //        var tmpEntities = Extract<TRoot, TWrapper, TEntity>(response);

        //        if (!tmpEntities.Any())
        //        {
        //            break;
        //        }

        //        if (entities == null)
        //        {
        //            entities = new List<TEntity>();
        //        }

        //        entities.AddRange(tmpEntities);

        //        if (string.IsNullOrEmpty(response.Paging.NextLink))
        //        {
        //            break;
        //        }

        //        url = GetRestReqestUrlFromPagingUrl(response.Paging.NextLink);

        //        counter++;
        //    }
        //    while (counter < pagingOption.NumberOfPages);

        //    return entities;
        //}

        public void MultiplePageHandlerForRestClient<TRoot, TWrapper, TEntity>(TWrapper wrapper, List<TEntity> entityList, IRestRequest request)
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
                request.AddOrUpdateParameter("page", currentPage);
                var currentPageResponse = Execute<TRoot>(request).Result;
                var currentPageResult = Extract<TRoot, TWrapper, TEntity>(currentPageResponse);
                entityList.AddRange(currentPageResult.List);
            }
        }

        public async Task MultiplePageHandlerForHttpClient<TRoot, TWrapper, TEntity>(TWrapper wrapper, HttpRequestMessage message, BaseRequestModel model, List<TEntity> entityList)
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
                model.Page = currentPage;
                message.Content = new StringContent(JsonConvert.SerializeObject(model, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");
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

        private void Authorize()
        {
            var accessToken = _authService.Get();

            _restClient.Authenticator = new TikTokAuthenticator(accessToken);
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
