using Newtonsoft.Json;
using System.Collections.Generic;

namespace TikTok.ApiClient.Entities
{
    public class ImageRequestFilter
    {
        /// <summary>
        /// filter by account id.
        /// </summary>
        [JsonProperty("advertiser_id")]
        public string AdvertiserId { get; set; }

        /// <summary>
        /// filter by image id.
        /// </summary>
        [JsonProperty("image_ids")]
        public List<string> ImageIds { get; set; }
    }
}
