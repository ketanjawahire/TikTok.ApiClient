using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TikTok.ApiClient.Entities
{
    public class BaseRequestModel
    {
        /// <summary>
        /// advertiser id
        /// </summary>
        [JsonProperty("advertiser_id")]
        public long AdvertiserId { get; set; }

        /// <summary>
        /// search page. Default value: 1. Size range: ≥ 0
        /// </summary>
        [JsonProperty("page")]
        public long? Page { get; set; }

        /// <summary>
        /// data amount on one page. Default value: 10. Size range: 1-1000
        /// </summary>
        [JsonProperty("page_size")]
        public long? PageSize { get; set; }

        /// <summary>
        /// querying fields collection, default querying all fields
        /// </summary>
        [JsonProperty("fields")]
        public List<long> Fields { get; set; }
    }
}
