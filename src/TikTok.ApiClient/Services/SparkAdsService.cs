using Newtonsoft.Json;
using System;
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
    /// <summary>
    /// class that handle spark ads methods
    /// </summary>
    internal class SparkAdsService : BaseService, ISparkAdsService
    {
        private readonly string _resourceUrl;

        internal SparkAdsService(AuthenticationService authenticationService)
            : base(authenticationService)
        {
            _resourceUrl = $"{BaseUrl}/{Version}/tt_video/list/";
        }

        /// <summary>
        /// Fetch spark ads data
        /// </summary>
        /// <param name="model">Request model</param>
        /// <returns>Spark ads</returns>
        public async Task<IEnumerable<SparkAds>> Get(BaseRequestModel model)
        {
            var ads = new List<SparkAds>();

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            foreach (var property in model.GetType().GetProperties())
            {
                if (property.Name == "AdvertiserId")
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

            var message = new HttpRequestMessage(HttpMethod.Get, $"{_resourceUrl}?{queryString}");

            var response = await Execute<SparkAdsRootObject>(message);

            if (response.code == 40105)
            {
                throw new Exceptions.UnauthorizedAccessException();
            }

            var result = Extract<SparkAdsRootObject, SparkAdsWrapper, SparkAds>(response);

            await MultiplePageHandler<SparkAdsRootObject, SparkAdsWrapper, SparkAds>(result, _resourceUrl, queryString, ads);

            return ads;
        }
    }
}
