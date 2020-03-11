using System.Collections.Generic;
using Newtonsoft.Json;

namespace TikTok.ApiClient.Entities
{
    public class AgentAdvertiserWrapper : IWrapper<AgentAdvertiser>
    {
        [JsonProperty("list")]
        public List<AgentAdvertiser> List { get; set; }

        [JsonProperty("page_info")] 
        public PageInfo PageInfo { get; set; }
    }
}
