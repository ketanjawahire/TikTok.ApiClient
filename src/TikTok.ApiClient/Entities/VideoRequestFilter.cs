using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTok.ApiClient.Entities
{
    public class VideoRequestFilter
    {
        /// <summary>
        /// filter by account id.
        /// </summary>
        [JsonProperty("advertiser_id")]
        public string AdvertiserId { get; set; }

        /// <summary>
        /// filter by video id.
        /// </summary>
        [JsonProperty("video_ids")]
        public List<string> VideoIds { get; set; }
    }
}
