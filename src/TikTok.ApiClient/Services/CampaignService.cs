using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TikTok.ApiClient.Entities;
using TikTok.ApiClient.Services.Interfaces;

namespace TikTok.ApiClient.Services
{
    /// <inheritdoc cref="ICampaignService"/>
    internal class CampaignService : BaseService, ICampaignService
    {
        internal CampaignService(AuthenticationService authenticationService)
            : base(authenticationService)
        {
            _getEndpoint = "https://ads.tiktok.com/open_api/v1.2/campaign/get";
        }

        private readonly string _getEndpoint;

        /// <inheritdoc />
        public async Task<IEnumerable<Campaign>> Get(CampaignRequestModel requestModel)
        {
            var campaigns = new List<Campaign>();

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            foreach (var property in requestModel.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(CampaignRequestFilter))
                {
                    var filterValue = JsonConvert.SerializeObject(property.GetValue(requestModel, null), new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                    queryString.Add("filtering", filterValue);
                }
                else if (property.Name == "AdvertiserId")
                {
                    queryString.Add("advertiser_id", property.GetValue(requestModel, null).ToString());
                }
            }

            var message = new HttpRequestMessage(HttpMethod.Get, $"{_getEndpoint}?{queryString}");

            var response = await Execute<CampaignRootObject>(message);

            if (response.code == 40105)
            {
                throw new Exceptions.UnauthorizedAccessException();
            }

            var result = Extract<CampaignRootObject, CampaignWrapper, Campaign>(response);

            await MultiplePageHandlerForHttpClient<CampaignRootObject, CampaignWrapper, Campaign>(result, message, requestModel, campaigns);

            return campaigns;
        }

        public IEnumerable<CampaignInsight> GetReport(InputModel model)
        {
            var request = new RestRequest("/2/reports/campaign/get/", Method.GET);
            var campaignInsights = new List<CampaignInsight>();

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

            var response = Execute<CampaignInsightRootObject>(request).Result;

            if (response.code == 40105)
            {
                throw new Exceptions.UnauthorizedAccessException();
            }

            var result = Extract<CampaignInsightRootObject, CampaignInsightWrapper, CampaignInsight>(response);

            MultiplePageHandlerForRestClient<CampaignInsightRootObject, CampaignInsightWrapper, CampaignInsight>(result, campaignInsights, request);

            return campaignInsights;
        }
    }
}
