using Newtonsoft.Json;
using System.Collections.Generic;

namespace TikTok.ApiClient.Entities
{
    public class AdgroupWrapper : IWrapper<Adgroup>
    {
        [JsonProperty("list")]
        public List<Adgroup> List { get; set; }

        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }
    }
}
