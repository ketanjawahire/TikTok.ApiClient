using Newtonsoft.Json;
using System.Collections.Generic;

namespace TikTok.ApiClient
{
    public class AgentAdvertiserWrapper : IWrapper<AgentAdvertiser>
    {
        [JsonProperty("list")]
        public List<AgentAdvertiser> List { get; set; }
    }
}
