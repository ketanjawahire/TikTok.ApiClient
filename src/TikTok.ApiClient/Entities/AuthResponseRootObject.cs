using Newtonsoft.Json;

namespace TikTok.ApiClient
{
    public class AuthResponseRootObject
    {
        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("data")]
        public AuthResponse Data { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }
}
