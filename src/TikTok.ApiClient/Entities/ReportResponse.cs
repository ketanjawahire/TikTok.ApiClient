using Newtonsoft.Json;

namespace TikTok.ApiClient.Entities
{
    public class ReportResponse : IApiEntity
    {
        [JsonProperty("metrics")] 
        public ReportResponseMetric Metric { get; set; }

        [JsonProperty("dimensions")] 
        public ReportResponseDimension Dimension { get; set; }
    }
}
