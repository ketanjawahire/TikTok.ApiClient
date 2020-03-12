using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TikTok.ApiClient.Entities;
using TikTok.ApiClient.Services.Interfaces;

namespace TikTok.ApiClient.Services
{
    internal class CampaignService : BaseService, ICampaignService
    {
        internal CampaignService(AuthenticationService authenticationService)
            : base(authenticationService)
        {
        }

        public async Task<IEnumerable<Campaign>> Get(CampaignRequestModel requestModel)
        {
            var campaigns = new List<Campaign>();

            var message = new HttpRequestMessage(HttpMethod.Get, "https://ads.tiktok.com/open_api/2/campaign/get/")
            {
                Content = new StringContent(
                    JsonConvert.SerializeObject(requestModel,
                        new JsonSerializerSettings() {NullValueHandling = NullValueHandling.Ignore}), Encoding.UTF8,
                    "application/json")
            };

            var response = await Execute<CampaignRootObject>(message);

            var result = Extract<CampaignRootObject, CampaignWrapper, Campaign>(response);

            await MultiplePageHandlerForHttpClient<CampaignRootObject, CampaignWrapper, Campaign>(result, message, requestModel, campaigns);

            return campaigns;
        }

        public IEnumerable<CampaignInsight> GetReport(InputModel model)
        {
            var request = new RestRequest("/2/reports/campaign/get/", Method.GET);
            var campaignInsights = new List<CampaignInsight>();

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


            var response = Execute<CampaignInsightRootObject>(request).Result;

            var result = Extract<CampaignInsightRootObject, CampaignInsightWrapper, CampaignInsight>(response);

            MultiplePageHandlerForRestClient<CampaignInsightRootObject, CampaignInsightWrapper, CampaignInsight>(result, campaignInsights, request);

            return campaignInsights;
        }
    }
}
