using Newtonsoft.Json;

namespace TikTok.ApiClient.Entities
{
    public class PageInfo
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("page_size")]
        public int PageSize { get; set; }

        [JsonProperty("total_number")]
        public int TotalNumber { get; set; }

        [JsonProperty("total_page")]
        public int TotalPage { get; set; }
    }
}
