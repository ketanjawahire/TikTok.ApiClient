using System.Collections.Generic;
using Newtonsoft.Json;

namespace TikTok.ApiClient.Entities
{
    public class CampaignInsightWrapper : IWrapper<CampaignInsight>
    {
        [JsonProperty("list")]
        public List<CampaignInsight> List { get; set; }
        
        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }
    }
}
