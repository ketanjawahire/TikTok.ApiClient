using System;
using Newtonsoft.Json;

namespace TikTok.ApiClient.Entities
{
    public class AdInsight : IApiEntity
    {
        [JsonProperty("active_register")]
        public long ActiveRegister { get; set; }

        [JsonProperty("skip")]
        public decimal Skip { get; set; }

        [JsonProperty("active_register_rate")]
        public decimal ActiveRegisterRate { get; set; }

        [JsonProperty("active_rate")]
        public decimal ActiveRate { get; set; }

        [JsonProperty("active_show")]
        public decimal ActiveShow { get; set; }

        [JsonProperty("active_pay_avg_amount")]
        public decimal ActivePayAvgAmount { get; set; }

        [JsonProperty("dy_comment")]
        public decimal DyComment { get; set; }

        [JsonProperty("active_pay_cost")]
        public decimal ActivePayCost { get; set; }

        [JsonProperty("ad_name")]
        public string AdName { get; set; }

        [JsonProperty("conversion_rate")]
        public decimal ConversionRate { get; set; }

        [JsonProperty("show_uv")]
        public long ShowUv { get; set; }

        [JsonProperty("ecpm")]
        public decimal Ecpm { get; set; }

        [JsonProperty("campaign_name")]
        public string CampaignName { get; set; }

        [JsonProperty("active_register_click_cost")]
        public decimal ActiveRegisterClickCost { get; set; }

        [JsonProperty("adgroup_id")]
        public long AdgroupId { get; set; }

        [JsonProperty("show_cnt")]
        public long ShowCnt { get; set; }

        [JsonProperty("active_register_click")]
        public decimal ActiveRegisterClick { get; set; }

        [JsonProperty("active_click_cost")]
        public decimal ActiveClickCost { get; set; }

        [JsonProperty("adgroup_name")]
        public string AdgroupName { get; set; }

        [JsonProperty("stat_cost")]
        public decimal StatCost { get; set; }

        [JsonProperty("active_pay_click_cost")]
        public decimal ActivePayClickCost { get; set; }

        [JsonProperty("active_register_cost")]
        public decimal ActiveRegisterCost { get; set; }

        [JsonProperty("active_pay_click")]
        public decimal ActivePayClick { get; set; }

        [JsonProperty("conversion_cost")]
        public decimal ConversionCost { get; set; }

        [JsonProperty("ad_id")]
        public long AdId { get; set; }

        [JsonProperty("total_play")]
        public long TotalPlay { get; set; }

        [JsonProperty("dy_like")]
        public decimal DyLike { get; set; }

        [JsonProperty("dy_share")]
        public decimal DyShare { get; set; }

        [JsonProperty("ad_text")]
        public string AdText { get; set; }

        [JsonProperty("click_cost")]
        public decimal ClickCost { get; set; }

        [JsonProperty("campaign_id")]
        public long CampaignId { get; set; }

        [JsonProperty("active_click")]
        public decimal ActiveClick { get; set; }

        [JsonProperty("active")]
        public decimal Active { get; set; }

        [JsonProperty("convert_cnt")]
        public long ConvertCnt { get; set; }

        [JsonProperty("active_register_show_cost")]
        public decimal ActiveRegisterShowCost { get; set; }

        [JsonProperty("average_video_play")]
        public decimal AverageVideoPlay { get; set; }

        [JsonProperty("active_pay_rate")]
        public decimal ActivePayRate { get; set; }

        [JsonProperty("activate_cost")]
        public decimal ActivateCost { get; set; }

        [JsonProperty("ctr")]
        public decimal Ctr { get; set; }

        [JsonProperty("active_pay")]
        public decimal ActivePay { get; set; }

        [JsonProperty("click_cnt")]
        public long ClickCnt { get; set; }

        [JsonProperty("active_register_show")]
        public decimal ActiveRegisterShow { get; set; }

        [JsonProperty("active_pay_amount")]
        public decimal ActivePayAmount { get; set; }

        [JsonProperty("active_pay_show_cost")]
        public decimal ActivePayShowCost { get; set; }

        [JsonProperty("dy_home_visited")]
        public decimal DyHomeVisited { get; set; }

        [JsonProperty("activate_rate")]
        public decimal ActivateRate { get; set; }

        [JsonProperty("active_cost")]
        public decimal ActiveCost { get; set; }

        [JsonProperty("active_pay_show")]
        public decimal ActivePayShow { get; set; }

        [JsonProperty("active_show_cost")]
        public decimal ActiveShowCost { get; set; }

        [JsonProperty("stat_datetime")]
        public DateTime StatDateTime { get; set; }

        [JsonProperty("time_attr_convert_cnt")]
        public decimal TimeAttrConvertCnt { get; set; }
    }
}
