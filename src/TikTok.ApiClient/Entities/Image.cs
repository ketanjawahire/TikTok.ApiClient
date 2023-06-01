using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTok.ApiClient.Entities
{
    public class Image : BaseImage
    {
        /// <summary>
        /// image id
        /// </summary>
        [JsonProperty("image_id")]
        public string ImageId { get; set; }

        /// <summary>
        /// image url
        /// </summary>
        [JsonProperty("image_url")]
        public string ImageUrl { get; set; }
    }
}
