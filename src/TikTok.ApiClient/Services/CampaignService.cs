using Newtonsoft.Json;
using System.Collections.Generic;
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
            _getEndpoint = $"{BaseUrl}/{Version}/campaign/get";
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
                else if (property.Name == nameof(BaseRequestModel.Page))
                {
                    queryString.Add("page", property.GetValue(requestModel, null).ToString());
                }
                else if (property.Name == nameof(BaseRequestModel.PageSize))
                {
                    queryString.Add("page_size", property.GetValue(requestModel, null).ToString());
                }
            }

            var message = new HttpRequestMessage(HttpMethod.Get, $"{_getEndpoint}?{queryString}");

            var response = await Execute<CampaignRootObject>(message);

            if (response.code == 40105)
            {
                throw new Exceptions.UnauthorizedAccessException();
            }

            var result = Extract<CampaignRootObject, CampaignWrapper, Campaign>(response);

            await MultiplePageHandlerForHttpClient<CampaignRootObject, CampaignWrapper, Campaign>(result, _getEndpoint, requestModel, campaigns);

            return campaigns;
        }
    }
}
