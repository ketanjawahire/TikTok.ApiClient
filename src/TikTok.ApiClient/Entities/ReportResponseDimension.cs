using Newtonsoft.Json;

namespace TikTok.ApiClient.Entities
{
    public class ReportResponseDimension : IApiEntity
    {
        /// <summary>
        /// Group by Advertiser ID
        /// </summary>
        [JsonProperty("advertiser_id")]
        public long AdvertiserId { get; set; }

        /// <summary>
        /// Group by Campaign ID
        /// </summary>
        [JsonProperty("campaign_id")]
        public long CampaignId { get; set; }

        /// <summary>
        /// Group by Ad Group ID
        /// </summary>
        [JsonProperty("adgroup_id")]
        public long AdgroupId { get; set; }

        /// <summary>
        /// Group by Ad ID
        /// </summary>
        [JsonProperty("ad_id")]
        public long AdId { get; set; }

        /// <summary>
        /// Group by day
        /// </summary>
        [JsonProperty("stat_time_day")]
        public string StatTimeDay { get; set; }

        /// <summary>
        /// Group by hour
        /// </summary>
        [JsonProperty("stat_time_hour")]
        public string StatTimeHour { get; set; }
    }
}
