using Newtonsoft.Json;

namespace TikTok.ApiClient
{
    /// <summary>
    /// Represents api error reseponse.
    /// </summary>
    public class ErrorResponse
    {
        /// <summary>
        /// Gets or sets error.
        /// </summary>
        [JsonProperty("error")]
        public string Error { get; set; }

        /// <summary>
        /// Gets or sets error description.
        /// </summary>
        [JsonProperty("error_description")]
        public string ErrorDescription { get; set; }
    }
}
