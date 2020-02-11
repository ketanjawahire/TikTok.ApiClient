using Newtonsoft.Json;
using System.Collections.Generic;

namespace TikTok.ApiClient.Entities
{
    public class AdWrapper : IWrapper<Ad>
    {
        [JsonProperty("list")]
        public List<Ad> List { get; set; }

        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }
    }
}
