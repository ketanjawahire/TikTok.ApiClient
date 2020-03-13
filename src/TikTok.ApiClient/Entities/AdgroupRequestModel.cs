using Newtonsoft.Json;
using System.Collections.Generic;

namespace TikTok.ApiClient.Entities
{
    public class AdgroupRequestModel : BaseRequestModel
    {
        /// <summary>
        /// filter field, filter by advertiser if not filling in，supported fields are as below
        /// </summary>
        [JsonProperty("filtering")]
        public AdgroupRequestFilter Filtering { get; set; }
    }
}
