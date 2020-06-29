using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TikTok.ApiClient.Entities;
using TikTok.ApiClient.Services.Interfaces;

namespace TikTok.ApiClient.Services
{
    internal class AdService : BaseService, IAdService
    {
        internal AdService(AuthenticationService authenticationService)
            : base(authenticationService)
        {
        }

        public async Task<IEnumerable<Ad>> Get(AdRequestModel model)
        {
            var ads = new List<Ad>();

            var message = new HttpRequestMessage(HttpMethod.Get, "https://ads.tiktok.com/open_api/2/ad/get/")
            {
                Content = new StringContent(
                    JsonConvert.SerializeObject(model,
                        new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore}), Encoding.UTF8,
                    "application/json")
            };

            var response = await Execute<AdRootObject>(message);

            if (response.code == 40105)
            {
                throw new Exceptions.UnauthorizedAccessException();
            }

            var result = Extract<AdRootObject, AdWrapper, Ad>(response);

            await MultiplePageHandlerForHttpClient<AdRootObject, AdWrapper, Ad>(result, message, model, ads);

            return ads;
        }

        public IEnumerable<AdInsight> GetReport(InputModel model)
        {
            //TODO : Throw exception if advertiserId, startDate, endDate value is null
            if (model.AdvertiserId == 0 || model.StartDate == null || model.EndDate == null)
            {
                return new List<AdInsight>();
            }

            var adInsights = new List<AdInsight>();

            var request = new RestRequest("/2/reports/ad/get/", Method.GET);

            request.AddParameter("advertiser_id", model.AdvertiserId);
            request.AddParameter("start_date", model.StartDate.Value.ToString("yyyy-MM-dd"));
            request.AddParameter("end_date", model.EndDate.Value.ToString("yyyy-MM-dd"));

            if (model.Page != null)
                request.AddParameter("page", model.Page.Value);

            if (model.PageSize != null)
                request.AddParameter("page_size", model.PageSize.Value);

            if (model.GroupBy != null)
                request.AddParameter("group_by", "[\"" + string.Join("\",\"", model.GroupBy.Select(e => e.ToString())) + "\"]");

            if (model.TimeGranularity != null)
                request.AddParameter("time_granuarity", model.TimeGranularity.Value);

            if (!string.IsNullOrEmpty(model.OrderField))
                request.AddParameter("order_field", model.OrderField);

            if (model.OrderType != null)
                request.AddParameter("order_type", model.OrderType.Value.ToString());

            if (model.Fields != null)
                request.AddParameter("fields", "[\"" + string.Join("\",\"", model.Fields.Select(e => e.ToString())) + "\"]");

            var response = Execute<AdInsightRootObject>(request).Result;

            if (response.code == 40105)
            {
                throw new Exceptions.UnauthorizedAccessException();
            }

            var result = Extract<AdInsightRootObject, AdInsightWrapper, AdInsight>(response);

            MultiplePageHandlerForRestClient<AdInsightRootObject, AdInsightWrapper, AdInsight>(result, adInsights, request);

            return adInsights;
        }
    }
}
