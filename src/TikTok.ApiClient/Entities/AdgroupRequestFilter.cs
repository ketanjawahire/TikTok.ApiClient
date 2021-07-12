using Newtonsoft.Json;
using System.Collections.Generic;

namespace TikTok.ApiClient.Entities
{
    public class AdgroupRequestFilter
    {
        /// <summary>
        /// filter by adgroup id.
        /// </summary>
        [JsonProperty("adgroup_ids")]
        public List<long> AdGroupIds { get; set; }

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
        /// filter by ad group objective, please find details from appendix[adgroup objectives]
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// filter by billing events,details please find details from appendix[billing events]
        /// </summary>
        [JsonProperty("billing_events")]
        public List<long> BillingEvents { get; set; }

        /// <summary>
        /// fuzzy search by adgroup name
        /// </summary>
        [JsonProperty("adgroup_name")]
        public string AdgroupName { get; set; }
        
        /// <summary>
        /// Ad group status. Filter ad groups based on their status.
        /// </summary>
        [JsonProperty("primary_status")]
        public string PrimaryStatus { get; set; }
    }
}
