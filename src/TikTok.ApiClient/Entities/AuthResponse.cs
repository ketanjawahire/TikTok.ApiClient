using Newtonsoft.Json;

namespace TikTok.ApiClient
{
    public class AuthResponse : IApiEntity
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token_expires_in")]
        public string RefreshTokenExpiresIn { get; set; }

        [JsonProperty("expires_in")]
        public string ExpiresIn { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
    }
}
