using System.Collections.Generic;
using Newtonsoft.Json;

namespace TikTok.ApiClient.Entities
{
    public class CampaignPageWrapper : IWrapper<Page<Campaign>>
    {
        [JsonProperty("list")]
        public List<Page<Campaign>> List { get; set; }
        
        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }
    }
}
