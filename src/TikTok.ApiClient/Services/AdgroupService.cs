using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        public IEnumerable<Adgroup> Get(AdgroupRequestModel model)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, "https://ads.tiktok.com/open_api/2/adgroup/get/");

            message.Content = new StringContent(JsonConvert.SerializeObject(model, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }), Encoding.UTF8, "application/json");

            var response = Execute<AdgroupRootObject>(message);

            var result = Extract<AdgroupRootObject, AdgroupWrapper, Adgroup>(response);

            return result;
        }

        public IEnumerable<AdgroupInsight> GetReport(InputModel model)
        {
            var request = new RestRequest("/2/reports/adgroup/get/", Method.GET);

            //TODO : Throw exception if advertiserId, startDate, endDate value is null
            request.AddParameter("advertiser_id", model.AdvertiserId);
            request.AddParameter("start_date", model.StartDate.Value.ToString("yyyy-MM-dd"));
            request.AddParameter("end_date", model.EndDate.Value.ToString("yyyy-MM-dd"));


            if (model.Page.HasValue)
                request.AddParameter("page", model.Page.Value);

            if (model.PageSize.HasValue)
                request.AddParameter("page_size", model.PageSize.Value);

            if (model.GroupBy.Any())
                request.AddParameter("group_by", "[\"" + string.Join("\",\"", model.GroupBy.Select(e => e.ToString())) + "\"]");

            if (model.TimeGranularity.HasValue)
                request.AddParameter("time_granuarity", model.TimeGranularity.Value);

            if (!string.IsNullOrEmpty(model.OrderField))
                request.AddParameter("order_field", model.OrderField);

            if (model.OrderType.HasValue)
                request.AddParameter("order_type", model.OrderType.Value.ToString());


            var response = Execute<AdgroupInsightRootObject>(request);

            var result = Extract<AdgroupInsightRootObject, AdgroupInsightWrapper, AdgroupInsight>(response);

            return result;
        }
    }

}
