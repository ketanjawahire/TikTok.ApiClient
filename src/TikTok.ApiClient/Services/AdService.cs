using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TikTok.ApiClient.Entities;
using TikTok.ApiClient.Services.Interfaces;

namespace TikTok.ApiClient.Services
{
    internal class AdService : BaseService, IAdService
    {
        private readonly string _resourceUrl;

        internal AdService(AuthenticationService authenticationService)
            : base(authenticationService)
        {
            _resourceUrl = $"{BaseUrl}/{Version}/ad/get/";
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
                else if (property.Name == nameof(BaseRequestModel.Page))
                {
                    queryString.Add("page", property.GetValue(model,null).ToString());
                }
                else if (property.Name == nameof(BaseRequestModel.PageSize))
                {
                    queryString.Add("page_size", property.GetValue(model, null).ToString());
                }
            }

            var message = new HttpRequestMessage(HttpMethod.Get, $"{_resourceUrl}?{queryString}");

            var response = await Execute<AdRootObject>(message);

            if (response.code == 40105)
            {
                throw new Exceptions.UnauthorizedAccessException();
            }

            var result = Extract<AdRootObject, AdWrapper, Ad>(response);

            await MultiplePageHandlerForHttpClient<AdRootObject, AdWrapper, Ad>(result, _resourceUrl, model, ads);

            return ads;
        }
    }
}
