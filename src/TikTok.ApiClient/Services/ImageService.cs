using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TikTok.ApiClient.Entities;
using TikTok.ApiClient.Services.Interfaces;

namespace TikTok.ApiClient.Services
{
    internal class ImageService : BaseService, IImageService
    {
        private readonly string _resourceUrl;

        internal ImageService(AuthenticationService authenticationService)
            : base(authenticationService)
        {
            _resourceUrl = $"{BaseUrl}/{Version}/file/image/ad/search/";
        }

        public async Task<IEnumerable<Image>> Get(ImageRequestModel model)
        {
            var images = new List<Image>();

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            foreach (var property in model.GetType().GetProperties())
            {
                if(property.PropertyType == typeof(ImageRequestFilter))
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
                    queryString.Add("page", property.GetValue(model, null).ToString());
                }
                else if (property.Name == nameof(BaseRequestModel.PageSize))
                {
                    queryString.Add("page_size", property.GetValue(model, null).ToString());
                }
            }

            var message = new HttpRequestMessage(HttpMethod.Get, $"{_resourceUrl}?{queryString}");

            var response = await Execute<ImageRootObject>(message);

            if (response.code == 40105)
            {
                throw new Exceptions.UnauthorizedAccessException();
            }

            var result = Extract<ImageRootObject, ImageWrapper, Image>(response);
            await MultiplePageHandler<ImageRootObject, ImageWrapper, Image>(result, _resourceUrl, queryString, images);

            return images;
        }
    }
}
