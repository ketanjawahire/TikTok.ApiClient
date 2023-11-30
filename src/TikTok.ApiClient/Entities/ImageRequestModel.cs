using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTok.ApiClient.Entities
{
    public class ImageRequestModel : BaseRequestModel
    {
        /// <summary>
        /// filter field, filter by advertiser if not filling in，supported fields are as below
        /// </summary>
        [JsonProperty("filtering")]
        public ImageRequestFilter Filtering { get; set; }
    }
}
