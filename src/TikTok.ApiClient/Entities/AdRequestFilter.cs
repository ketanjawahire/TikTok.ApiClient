using Newtonsoft.Json;
using System.Collections.Generic;

namespace TikTok.ApiClient.Entities
{
    public class AdRequestFilter
    {
        /// <summary>
        /// filter by ads id.
        /// </summary>
        [JsonProperty("ad_ids")]
        public List<long> AdIds { get; set; }

        /// <summary>
        /// filter by adgroup id.
        /// </summary>
        [JsonProperty("adgroup_ids")]
        public List<long> AdgroupIds { get; set; }

        /// <summary>
        /// filter by campaign id.
        /// </summary>
        [JsonProperty("campaign_ids")]
        public List<long> CampaignIds { get; set; }

        /// <summary>
        /// campaign campaign objective, for details, please refer to【appendix-campaign objective（new）】
        /// </summary>
        [JsonProperty("objective_type")]
        public string ObjectiveType { get; set; }

        /// <summary>
        /// filter by ad status,details please find details from appendix[ad status]
        /// </summary>
        [JsonProperty("secondary_status")]
        public string Status { get; set; }

        /// <summary>
        /// filter by billing events,details please find details from appendix[billing events]
        /// </summary>
        [JsonProperty("billing_events")]
        public List<long> BillingEvents { get; set; }

        /// <summary>
        /// search by image mode, please find examples from appendix[image mode]
        /// </summary>
        [JsonProperty("image_mode")]
        public string ImageMode { get; set; }

        /// <summary>
        /// fuzzy search by adgroup name
        /// </summary>
        [JsonProperty("ad_text")]
        public string AdText { get; set; }

    }
}
