using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTok.ApiClient.Entities
{
    public class VideoRequestModel : BaseRequestModel
    {
        /// <summary>
        /// filter field, filter by advertiser if not filling in，supported fields are as below
        /// </summary>
        [JsonProperty("filtering")]
        public VideoRequestFilter Filtering { get; set; }
    }
}
