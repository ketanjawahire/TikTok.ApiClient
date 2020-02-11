using Newtonsoft.Json;
using System.Collections.Generic;

namespace TikTok.ApiClient.Entities
{
    public class CampaignRequestFilter
    {
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
        /// fuzzy search by campaign name
        /// </summary>
        [JsonProperty("campaign_name")]
        public string CampaignName { get; set; }

    }
}
