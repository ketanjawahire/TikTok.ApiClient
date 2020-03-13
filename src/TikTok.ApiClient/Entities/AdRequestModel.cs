using Newtonsoft.Json;
using System.Collections.Generic;

namespace TikTok.ApiClient.Entities
{
    public class AdRequestModel : BaseRequestModel
    {
        /// <summary>
        /// filter field, filter by advertiser if not filling in，supported fields are as below
        /// </summary>
        [JsonProperty("filtering")]
        public AdRequestFilter Filtering { get; set; }
    }
}
