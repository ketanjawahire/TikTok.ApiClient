using System.Collections.Generic;
using Newtonsoft.Json;
using TikTok.ApiClient.Entities;

namespace TikTok.ApiClient
{
    public class AdInsightWrapper : IWrapper<AdInsight>
    {
        [JsonProperty("list")]
        public List<AdInsight> List { get; set; }
        
        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }
    }
}
