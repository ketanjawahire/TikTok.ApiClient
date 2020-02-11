using Newtonsoft.Json;
using System.Collections.Generic;

namespace TikTok.ApiClient.Entities
{
    public class CampaignRequestModel
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
        /// filter field, filter by advertiser if not filling in，supported fields are as below
        /// </summary>
        [JsonProperty("filtering")]
        public CampaignRequestFilter Filtering { get; set; }

        /// <summary>
        /// querying fields collection, default querying all fields
        /// </summary>
        [JsonProperty("fields")]
        public List<long> Fields { get; set; }
    }
}
