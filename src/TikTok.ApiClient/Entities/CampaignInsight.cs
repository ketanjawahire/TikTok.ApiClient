using Newtonsoft.Json;

namespace TikTok.ApiClient.Entities
{
    public class CampaignInsight : IApiEntity
    {
        [JsonProperty("active_register")]
        public long ActiveRegister { get; set; }

        [JsonProperty("skip")]
        public long Skip { get; set; }

        [JsonProperty("convert_rate")]
        public long ConvertRate { get; set; }

        [JsonProperty("active_register_rate")]
        public long ActiveRegisterRate { get; set; }

        [JsonProperty("active_rate")]
        public long ActiveRate { get; set; }

        [JsonProperty("active_show")]
        public long ActiveShow { get; set; }

        [JsonProperty("active_pay_avg_amount")]
        public long ActivePayAvgAmount { get; set; }

        [JsonProperty("dy_comment")]
        public long DyComment { get; set; }

        [JsonProperty("active_pay_cost")]
        public long ActivePayCost { get; set; }

        [JsonProperty("conversion_rate")]
        public long ConversionRate { get; set; }

        [JsonProperty("show_uv")]
        public long ShowUv { get; set; }

        [JsonProperty("ecpm")]
        public long Ecpm { get; set; }

        [JsonProperty("campaign_name")]
        public string CampaignName { get; set; }

        [JsonProperty("active_register_click_cost")]
        public long ActiveRegisterClickCost { get; set; }

        [JsonProperty("show_cnt")]
        public long ShowCnt { get; set; }

        [JsonProperty("active_register_click")]
        public long ActiveRegisterClick { get; set; }

        [JsonProperty("active_click_cost")]
        public long ActiveClickCost { get; set; }

        [JsonProperty("stat_cost")]
        public long StatCost { get; set; }

        [JsonProperty("active_pay_click_cost")]
        public long ActivePayClickCost { get; set; }

        [JsonProperty("active_register_cost")]
        public long ActiveRegisterCost { get; set; }

        [JsonProperty("active_pay_click")]
        public long ActivePayClick { get; set; }

        [JsonProperty("convert_cost")]
        public long ConvertCost { get; set; }

        [JsonProperty("total_play")]
        public long TotalPlay { get; set; }

        [JsonProperty("dy_like")]
        public long DyLike { get; set; }

        [JsonProperty("dy_share")]
        public long DyShare { get; set; }

        [JsonProperty("click_cost")]
        public long ClickCost { get; set; }

        [JsonProperty("campaign_id")]
        public long CampaignId { get; set; }

        [JsonProperty("active_click")]
        public long ActiveClick { get; set; }

        [JsonProperty("active")]
        public long Active { get; set; }

        [JsonProperty("convert_cnt")]
        public long ConvertCnt { get; set; }

        [JsonProperty("active_register_show_cost")]
        public long ActiveRegisterShowCost { get; set; }

        [JsonProperty("average_video_play")]
        public long AverageVideoPlay { get; set; }

        [JsonProperty("active_pay_rate")]
        public long ActivePayRate { get; set; }

        [JsonProperty("activate_cost")]
        public long ActivateCost { get; set; }

        [JsonProperty("ctr")]
        public long Ctr { get; set; }

        [JsonProperty("active_pay")]
        public long ActivePay { get; set; }

        [JsonProperty("click_cnt")]
        public long ClickCnt { get; set; }

        [JsonProperty("active_register_show")]
        public long ActiveRegisterShow { get; set; }

        [JsonProperty("active_pay_amount")]
        public long ActivePayAmount { get; set; }

        [JsonProperty("active_pay_show_cost")]
        public long ActivePayShowCost { get; set; }

        [JsonProperty("dy_home_visited")]
        public long DyHomeVisited { get; set; }

        [JsonProperty("activate_rate")]
        public long ActivateRate { get; set; }

        [JsonProperty("active_cost")]
        public long ActiveCost { get; set; }

        [JsonProperty("active_pay_show")]
        public long ActivePayShow { get; set; }

        [JsonProperty("active_show_cost")]
        public long ActiveShowCost { get; set; }
    }
}
