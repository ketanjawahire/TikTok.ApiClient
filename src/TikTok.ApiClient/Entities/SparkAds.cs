using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTok.ApiClient.Entities
{
    /// <summary>
    /// Spark ads
    /// </summary>
    public class SparkAds : IApiEntity
    {
        /// <summary>
        /// advertiser id
        /// </summary>
        [JsonProperty("item_info")]
        public ItemInfo ItemInfo { get; set; }

        /// <summary>
        /// advertiser id
        /// </summary>
        [JsonProperty("video_info")]
        public VideoInfo VideoInfo { get; set; }
    }
}
