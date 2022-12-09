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
        public List<string> CampaignIds { get; set; }

        /// <summary>
        /// campaign campaign objective, for details, please refer to【appendix-campaign objective（new）】
        /// </summary>
        [JsonProperty("objective_type")]
        public string ObjectiveType { get; set; }

        /// <summary>
        /// filter by ad group objective, please find details from appendix[adgroup objectives].
        /// NOTE: If you wish to query deleted campaigns in your request, either specify the value of STATUS_DELETE in the primary_status field or CAMPAIGN_STATUS_DELETE in the secondary_status field. Deleted data are by default not queried.
        /// </summary>
        [JsonProperty("secondary_status")]
        public string Status { get; set; }

        /// <summary>
        /// fuzzy search by campaign name
        /// </summary>
        [JsonProperty("campaign_name")]
        public string CampaignName { get; set; }

        /// <summary>
        /// Use this field to filter regular campaigns or iOS 14 campaigns. Valid values: REGULAR_CAMPAIGN and IOS14_CAMPAIGN.
        /// </summary>
        [JsonProperty("campaign_type")]
        public string CampaignType { get; set; }

        /// <summary>
        /// Filter by ad status. See doc for more info - https://ads.tiktok.com/marketing_api/docs?id=100641.
        /// NOTE: If you wish to query deleted campaigns in your request, either specify the value of STATUS_DELETE in the primary_status field or CAMPAIGN_STATUS_DELETE in the secondary_status field. Deleted data are by default not queried.
        /// </summary>
        [JsonProperty("primary_status")]
        public string PrimaryStatus { get; set; }
    }
}
