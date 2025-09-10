using Newtonsoft.Json;

namespace TikTok.ApiClient
{
    /// <summary>
    /// Represents errors receives from API.
    /// </summary>
    public class ApiError
    {
        /// <summary>
        /// Gets or sets debug message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets error code.
        /// </summary>
        [JsonProperty("code")]
        public long Code { get; set; }

        /// <summary>
        /// Gets or sets error code.
        /// </summary>
        [JsonProperty("data")]
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets error code.
        /// </summary>
        [JsonProperty("request_id")]
        public string RequestId { get; set; }
    }
}
