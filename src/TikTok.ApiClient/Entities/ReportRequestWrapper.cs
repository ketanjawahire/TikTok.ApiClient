using System.Collections.Generic;
using Newtonsoft.Json;

namespace TikTok.ApiClient.Entities
{
    public class ReportResponseWrapper : IWrapper<ReportResponse>
    {
        [JsonProperty("list")]
        public List<ReportResponse> List { get; set; }
        
        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }

        [JsonProperty("total_metrics")]
        public TotalMetrics TotalMetrics { get; set;}
    }
}