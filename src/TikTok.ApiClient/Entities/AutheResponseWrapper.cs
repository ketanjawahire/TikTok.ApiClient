using Newtonsoft.Json;
using System.Collections.Generic;

namespace TikTok.ApiClient
{
    public class AutheResponseWrapper : IWrapper<AuthResponse>
    {
        [JsonProperty("list")]
        public List<AuthResponse> List { get; set; }
    }
}
