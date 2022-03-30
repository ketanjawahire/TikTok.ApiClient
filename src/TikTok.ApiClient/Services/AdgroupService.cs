using Newtonsoft.Json;
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
        private readonly string _getAdGroupEndpoint;

        internal AdgroupService(AuthenticationService authenticationService)
            : base(authenticationService)
        {
            _getAdGroupEndpoint = $"{BaseUrl}/{Version}/adgroup/get";
        }

        public async Task<IEnumerable<Adgroup>> Get(AdgroupRequestModel model)
        {
            var adGroups = new List<Adgroup>();
            
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
                else if (property.Name == nameof(BaseRequestModel.Page))
                {
                    queryString.Add("page", property.GetValue(model, null).ToString());
                }
                else if (property.Name == nameof(BaseRequestModel.PageSize))
                {
                    queryString.Add("page_size", property.GetValue(model, null).ToString());
                }
            }

            var message = new HttpRequestMessage(HttpMethod.Get, $"{_getAdGroupEndpoint}?{queryString}");

            var response = await Execute<AdgroupRootObject>(message);

            if (response.code == 40105)
            {
                throw new Exceptions.UnauthorizedAccessException();
            }

            var result = Extract<AdgroupRootObject, AdgroupWrapper, Adgroup>(response);

            await MultiplePageHandler<AdgroupRootObject, AdgroupWrapper, Adgroup>(result, _getAdGroupEndpoint, model, adGroups);

            return adGroups;
        }
    }
}
