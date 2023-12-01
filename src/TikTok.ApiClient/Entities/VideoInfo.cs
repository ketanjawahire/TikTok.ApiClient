using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTok.ApiClient.Entities
{
    /// <summary>
    /// Spark ads video info
    /// </summary>
    public class VideoInfo
    {
        /// <summary>
        /// signature
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; }

        /// <summary>
        /// file name
        /// </summary>
        [JsonProperty("preview_url")]
        public string PreviewUrl { get; set; }

        /// <summary>
        /// modify time
        /// </summary>
        [JsonProperty("poster_url")]
        public string PosterUrl { get; set; }

        /// <summary>
        /// width
        /// </summary>
        [JsonProperty("width")]
        public long Width { get; set; }

        /// <summary>
        /// heightS
        /// </summary>
        [JsonProperty("height")]
        public long Height { get; set; }

        /// <summary>
        /// size
        /// </summary>
        [JsonProperty("size")]
        public long Size { get; set; }
    }
}
