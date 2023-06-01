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
    internal class VideoService : BaseService, IVideoService
    {
        private readonly string _resourceUrl;

        internal VideoService(AuthenticationService authenticationService)
            : base(authenticationService)
        {
            _resourceUrl = $"{BaseUrl}/{Version}/file/video/ad/search/";
        }

        public async Task<IEnumerable<Video>> Get(VideoRequestModel model)
        {
            var videos = new List<Video>();

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            foreach (var property in model.GetType().GetProperties())
            {
                if (property.PropertyType == typeof(VideoRequestFilter))
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

            var response = await Execute<VideoRootObject>(message);

            if (response.code == 40105)
            {
                throw new Exceptions.UnauthorizedAccessException();
            }

            var result = Extract<VideoRootObject, VideoWrapper, Video>(response);
            await MultiplePageHandler<VideoRootObject, VideoWrapper, Video>(result, _resourceUrl, queryString, videos);

            return videos;
        }
    }
}
