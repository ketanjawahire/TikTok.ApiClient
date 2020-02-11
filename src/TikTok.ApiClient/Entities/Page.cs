using Newtonsoft.Json;
using System.Collections.Generic;

namespace TikTok.ApiClient.Entities
{
    public class Page<T> : IApiEntity where T: IApiEntity, new()
    {
        [JsonProperty("list")]
        public List<T> List { get; set; }

        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }
    }
}
