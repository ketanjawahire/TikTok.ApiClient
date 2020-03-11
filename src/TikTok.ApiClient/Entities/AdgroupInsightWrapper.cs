using System.Collections.Generic;
using Newtonsoft.Json;

namespace TikTok.ApiClient.Entities
{
    public class AdgroupInsightWrapper : IWrapper<AdgroupInsight>
    {
        [JsonProperty("list")]
        public List<AdgroupInsight> List { get; set; }
        
        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }
    }
}
