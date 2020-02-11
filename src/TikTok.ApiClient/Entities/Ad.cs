using Newtonsoft.Json;
using System.Collections.Generic;

namespace TikTok.ApiClient.Entities
{
    /// <summary>
    /// https://ads.tiktok.com/marketing_api/docs?id=207
    /// </summary>
    public class Ad : IApiEntity
    {
        /// <summary>
        /// advertiser id
        /// </summary>
        [JsonProperty("advertiser_id")]
        public long AdvertiserId { get; set; }

        /// <summary>
        /// ad id
        /// </summary>
        [JsonProperty("ad_id")]
        public long AdId { get; set; }

        /// <summary>
        /// ad name
        /// </summary>
        [JsonProperty("ad_name")]
        public string AdName { get; set; }

        /// <summary>
        /// ad text
        /// </summary>
        [JsonProperty("ad_text")]
        public string AdText { get; set; }

        /// <summary>
        /// adgroup id
        /// </summary>
        [JsonProperty("adgroup_id")]
        public long AdgroupId { get; set; }

        /// <summary>
        /// adgroup name
        /// </summary>
        [JsonProperty("adgroup_name")]
        public string AdgroupName { get; set; }

        /// <summary>
        /// campaign id
        /// </summary>
        [JsonProperty("campaign_id")]
        public long CampaignId { get; set; }

        /// <summary>
        /// campaign name
        /// </summary>
        [JsonProperty("campaign_name")]
        public string CampaignName { get; set; }

        /// <summary>
        /// image mode, please see more details from appendix [image mode]
        /// </summary>
        [JsonProperty("image_mode")]
        public string ImageMode { get; set; }

        /// <summary>
        /// image id
        /// </summary>
        [JsonProperty("image_ids")]
        public List<string> ImageIds { get; set; }

        /// <summary>
        /// video id
        /// </summary>
        [JsonProperty("video_id")]
        public string VideoId { get; set; }

        /// <summary>
        /// call to action text
        /// </summary>
        [JsonProperty("call_to_action")]
        public string CallToAction { get; set; }

        /// <summary>
        /// create time
        /// </summary>
        [JsonProperty("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// modify time
        /// </summary>
        [JsonProperty("modify_time")]
        public string ModifyTime { get; set; }
    }
}
