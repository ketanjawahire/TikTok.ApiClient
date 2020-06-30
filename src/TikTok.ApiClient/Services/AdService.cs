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
    internal class AdService : BaseService, IAdService
    {
        internal AdService(AuthenticationService authenticationService)
            : base(authenticationService)
        {
        }

        public async Task<IEnumerable<Ad>> Get(AdRequestModel model)
        {
            var ads = new List<Ad>();

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            foreach (var property in model.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(AdRequestFilter))
                {
                    var filterValue = JsonConvert.SerializeObject(property.GetValue(model, null), new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                    queryString.Add("filtering", filterValue);
                }
                else if (property.Name == "AdvertiserId")
                {
                    queryString.Add("advertiser_id", property.GetValue(model, null).ToString());
                }
            }

            var message = new HttpRequestMessage(HttpMethod.Get, $"https://ads.tiktok.com/open_api/2/ad/get/?{queryString}");

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

            request.AddQueryParameter("advertiser_id", model.AdvertiserId.ToString());
            request.AddQueryParameter("start_date", model.StartDate.Value.ToString("yyyy-MM-dd"));
            request.AddQueryParameter("end_date", model.EndDate.Value.ToString("yyyy-MM-dd"));

            if (model.Page != null)
                request.AddQueryParameter("page", model.Page.Value.ToString());

            if (model.PageSize != null)
                request.AddQueryParameter("page_size", model.PageSize.Value.ToString());

            if (model.GroupBy != null)
                request.AddQueryParameter("group_by", "[\"" + string.Join("\",\"", model.GroupBy.Select(e => e.ToString())) + "\"]");

            if (model.TimeGranularity != null)
                request.AddQueryParameter("time_granuarity", model.TimeGranularity.Value.ToString());

            if (!string.IsNullOrEmpty(model.OrderField))
                request.AddQueryParameter("order_field", model.OrderField);

            if (model.OrderType != null)
                request.AddQueryParameter("order_type", model.OrderType.Value.ToString());

            if (model.Fields != null)
                request.AddQueryParameter("fields", "[\"" + string.Join("\",\"", model.Fields.Select(e => e.ToString())) + "\"]");

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
