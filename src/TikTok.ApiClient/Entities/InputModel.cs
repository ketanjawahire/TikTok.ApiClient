using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TikTok.ApiClient.Enums;

namespace TikTok.ApiClient.Services
{
    public class InputModel
    {
        [JsonProperty("advertiser_id")]
        public long AdvertiserId { get; set; }
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }
        [JsonProperty("end_date")]
        public DateTime? EndDate { get; set; }
        [JsonProperty("page")]
        public int? Page { get; set; }
        [JsonProperty("page_size")]
        public int? PageSize{ get; set; }
        [JsonProperty("group_by")]
        public IList<GroupByOption> GroupBy{ get; set; }
        [JsonProperty("time_granularity")]
        public TimeGranularity? TimeGranularity { get; set; }
        [JsonProperty("order_field")]
        public string OrderField { get; set; }
        [JsonProperty("order_type")]
        public OrderType? OrderType { get; set; }
        [JsonProperty("filtering")]
        public Filtering Filtering { get; set; }
        [JsonProperty("fields")]
        public List<AdInsightFields> Fields { get; set; }
    }
}
