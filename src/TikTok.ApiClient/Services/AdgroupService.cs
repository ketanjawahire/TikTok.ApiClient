using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TikTok.ApiClient.Entities;
using TikTok.ApiClient.Services.Interfaces;

namespace TikTok.ApiClient.Services
{
    internal class AdgroupService : BaseService, IAdgroupService
    {
        internal AdgroupService(AuthenticationService authenticationService)
            : base(authenticationService)
        {
        }

        public async Task<IEnumerable<Adgroup>> Get(AdgroupRequestModel model)
        {
            var adgroups = new List<Adgroup>();
            
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            foreach (var property in model.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(AdgroupRequestFilter))
                {
                    var filterValue = JsonConvert.SerializeObject(property.GetValue(model, null), new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore});
                    queryString.Add("filtering", filterValue);
                }
                else if (property.Name == "AdvertiserId")
                {
                    queryString.Add("advertiser_id", property.GetValue(model, null).ToString());
                }
            }

            var message = new HttpRequestMessage(HttpMethod.Get, $"https://ads.tiktok.com/open_api/2/adgroup/get/?{queryString}");

            var response = await Execute<AdgroupRootObject>(message);

            if (response.code == 40105)
            {
                throw new Exceptions.UnauthorizedAccessException();
            }

            var result = Extract<AdgroupRootObject, AdgroupWrapper, Adgroup>(response);

            await MultiplePageHandlerForHttpClient<AdgroupRootObject, AdgroupWrapper, Adgroup>(result, message, model, adgroups);

            return adgroups;
        }

        public IEnumerable<AdgroupInsight> GetReport(InputModel model)
        {
            var request = new RestRequest("/2/reports/adgroup/get/", Method.GET);
            var adgroupInsights = new List<AdgroupInsight>();

            //TODO : Throw exception if advertiserId, startDate, endDate value is null
            request.AddQueryParameter("advertiser_id", model.AdvertiserId.ToString());
            request.AddQueryParameter("start_date", model.StartDate.Value.ToString("yyyy-MM-dd"));
            request.AddQueryParameter("end_date", model.EndDate.Value.ToString("yyyy-MM-dd"));


            if (model.Page.HasValue)
                request.AddQueryParameter("page", model.Page.Value.ToString());

            if (model.PageSize.HasValue)
                request.AddQueryParameter("page_size", model.PageSize.Value.ToString());

            if (model.GroupBy.Any())
                request.AddQueryParameter("group_by", "[\"" + string.Join("\",\"", model.GroupBy.Select(e => e.ToString())) + "\"]");

            if (model.TimeGranularity.HasValue)
                request.AddQueryParameter("time_granuarity", model.TimeGranularity.Value.ToString());

            if (!string.IsNullOrEmpty(model.OrderField))
                request.AddQueryParameter("order_field", model.OrderField);

            if (model.OrderType.HasValue)
                request.AddQueryParameter("order_type", model.OrderType.Value.ToString());

            var response = Execute<AdgroupInsightRootObject>(request).Result;

            if (response.code == 40105)
            {
                throw new Exceptions.UnauthorizedAccessException();
            }

            var result = Extract<AdgroupInsightRootObject, AdgroupInsightWrapper, AdgroupInsight>(response);

            MultiplePageHandlerForRestClient<AdgroupInsightRootObject, AdgroupInsightWrapper, AdgroupInsight>(result, adgroupInsights, request);

            return adgroupInsights;
        }
    }

}
