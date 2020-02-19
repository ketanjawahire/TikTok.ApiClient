using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TikTok.ApiClient.Enums;

namespace TikTok.ApiClient.Entities
{
    /// <summary>
    /// <a href="https://ads.tiktok.com/marketing_api/docs?id=199"></a>
    /// </summary>
    public class Campaign  : IApiEntity
    {
        /// <summary>
        /// advertiser_id
        /// </summary>
        [JsonProperty("advertiser_id")]
        public long AdvertiserId { get; set; }

        /// <summary>
        /// campaign_id
        /// </summary>
        [JsonProperty("campaign_id")]
        public long CampaignId { get; set; }

        /// <summary>
        /// campaign_name
        /// </summary>
        [JsonProperty("campaign_name")]
        public string CampaignName { get; set; }

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
    }
}
