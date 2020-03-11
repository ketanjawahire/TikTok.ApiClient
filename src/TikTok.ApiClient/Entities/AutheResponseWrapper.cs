using System.Collections.Generic;
using Newtonsoft.Json;

namespace TikTok.ApiClient.Entities
{
    public class AuthResponseWrapper : IWrapper<AuthResponse>
    {
        [JsonProperty("list")]
        public List<AuthResponse> List { get; set; }

        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }
    }
}
