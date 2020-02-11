using Newtonsoft.Json;
using System.Collections.Generic;

namespace TikTok.ApiClient.Entities
{
    public class CampaignWrapper : IWrapper<Campaign>
    {
        [JsonProperty("list")]
        public List<Campaign> List { get; set; }

        [JsonProperty("advertiser_id")]
        public PageInfo PageInfo { get; set; }
    }
}
