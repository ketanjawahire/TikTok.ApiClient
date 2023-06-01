using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTok.ApiClient.Entities
{
    public class Video : BaseImage
    {
        /// <summary>
        /// video id
        /// </summary>
        [JsonProperty("video_id")]
        public string VideoId { get; set; }

        /// <summary>
        /// video cover url
        /// </summary>
        [JsonProperty("video_cover_url")]
        public string ImageUrl { get; set; }
    }
}
