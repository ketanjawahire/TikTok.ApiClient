using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TikTok.ApiClient.Enums;

namespace TikTok.ApiClient.Entities
{
    /// <summary>
    /// Contain campaign metrics available at TikTok endpoint.
    /// See <a href="https://ads.tiktok.com/marketing_api/docs?id=1701890926865410"></a>
    /// </summary>
    public class Campaign : IApiEntity
    {
        /// <summary>
        /// advertiser_id
        /// </summary>
        [JsonProperty("advertiser_id")]
        public string AdvertiserId { get; set; }

        /// <summary>
        /// campaign_id
        /// </summary>
        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }

        /// <summary>
        /// campaign_name
        /// </summary>
        [JsonProperty("campaign_name")]
        public string CampaignName { get; set; }

        /// <summary>
        /// The campaign status
        /// </summary>
        [JsonProperty("status")]
        public CampaignStatus CampaignStatus { get; set; }

        /// <summary>
        /// budget
        /// </summary>
        [JsonProperty("budget")]
        public decimal Budget { get; set; }

        /// <summary>
        /// budget_mode
        /// </summary>
        [JsonProperty("budget_mode")]
        [JsonConverter(typeof(StringEnumConverter))]
        public BudgetMode BudgetMode { get; set; }

        /// <summary>
        /// objective
        /// </summary>
        [JsonProperty("objective")]
        public string Objective { get; set; }

        /// <summary>
        /// objective_type
        /// </summary>
        [JsonProperty("objective_type")]
        public string ObjectiveType { get; set; }

        public ObjectiveType CampaignObjectiveType
        {
            get
            {
                if (ObjectiveType == null)
                {
                    return Enums.ObjectiveType.NONE;
                }

                return (ObjectiveType) Enum.Parse(typeof(ObjectiveType), this.ObjectiveType);
            }
        }

        /// <summary>
        /// create_time
        /// </summary>
        [JsonProperty("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// modify_time
        /// </summary>
        [JsonProperty("modify_time")]
        public string ModifyTime { get; set; }

        /// <summary>
        /// Campaign Type, indicates the campaign is a regular campaign or iOS 14 campaign. Enum values: REGULAR_CAMPAIGN and IOS14_CAMPAIGN.
        /// </summary>
        [JsonProperty("campaign_type")]
        public string Type { get; set; }

        public CampaignType CampaignType => (CampaignType) Enum.Parse(typeof(CampaignType), Type);

        /// <summary>
        /// "Operation status
        /// </summary>
        [JsonProperty("opt_status")]
        public string OptStatus { get; set; }

        /// <summary>
        /// Whether Campaign Budget Optimization is enabled. Return only when Campaign Budget Optimization is enabled.
        /// </summary>
        [JsonProperty("budget_optimize_switch")]
        public int BudgetOptimizeSwitch { get; set; }

        /// <summary>
        /// Bidding strategy on the campaign level. Return only when Campaign Budget Optimization is enabled.
        /// </summary>
        [JsonProperty("bid_type")]
        public string BidType { get; set; }

        /// <summary>
        /// Optimization goal. Return only when Campaign Budget Optimization is enabled.
        /// </summary>
        [JsonProperty("optimize_goal")]
        public string OptimizeGoal { get; set; }

        /// <summary>
        /// "Split Test variables. Optional values: TARGETING
        /// </summary>
        [JsonProperty("split_test_variable")]
        public string SplitTestVariable { get; set; }

        /// <summary>
        /// Whether the campaign is a new structure (for the same campaign, the structure of campaign, adgroups and ads are the same)
        /// </summary>
        [JsonProperty("is_new_structure")]
        public bool IsNewStructure { get; set; }
    }
}
