using Newtonsoft.Json;
using System.Collections.Generic;
using TikTok.ApiClient.Enums;

namespace TikTok.ApiClient.Services
{
    public class Filtering
    {
        [JsonProperty("ad_ids")]
        public IList<long> AdIds { get; set; }
        [JsonProperty("adgroup_ids")]
        public IList<long> AdgroupIds { get; set; }
        [JsonProperty("campaign_ids")]
        public IList<long> CampaignIds { get; set; }
        [JsonProperty("objective_type")]
        public CampaignObjective? ObjetiveType { get; set; }
        [JsonProperty("status")]
        public AdStatus? Status { get; set; }
        [JsonProperty("billing_event")]
        public IList<BillingEvent> BilingEvents { get; set; }
        [JsonProperty("ad_text")]
        public string AdText { get; set; }
    }
}
