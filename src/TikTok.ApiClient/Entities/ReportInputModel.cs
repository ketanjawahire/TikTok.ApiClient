using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TikTok.ApiClient.Entities
{
    public class ReportInputModel
    {
        /// <summary>
        /// Advertiser ID
        /// </summary>
        [JsonProperty("advertiser_id")]
        public long AdvertiserId { get; set; }

        /// <summary>
        /// Ad service type. Optional values:AUCTION,RESERVATION. See below [Enumeration Value-Advertising Service Type] for details. Default: AUCTION
        /// </summary>
        [JsonProperty("service_type")]
        public string ServiceType { get; set; }

        /// <summary>
        /// Report type. Optional values: basic report BASIC, audience analysis report AUDIENCE, playable ads report PLAYABLE_MATERIAL, dpa report CATALOG, see below [Enumeration Value-Report Type] for details. Supports only BASIC report when 'service_type = RESERVATION'
        /// </summary>
        [JsonProperty("report_type")]
        public string ReportType { get; set; }

        /// <summary>
        /// Reporting data level. Required when report_type is BASIC,AUDIENCE or CATALOG. Optional values: AUCTION_AD,AUCTION_ADGROUP,AUCTION_ADVERTISER,AUCTION_CAMPAIGN,RESERVATION_AD,RESERVATION_ADGROUP,RESERVATION_ADVERTISER,RESERVATION_CAMPAIGN, see below [Enumeration Value-Report Data Level]
        /// </summary>
        [JsonProperty("data_level")]
        public string DataLevel { get; set; }

        /// <summary>
        /// Grouping conditions. Auction and Reservation Ads support different dimensions. For enumeration and combinations of support, see Auction Advertising Report Supplement-Supported Dimensions and Reservation Ads Report Supplement-Supported Dimensions, for example: [""campaign_id,"" ""stat_time_day""] indicates that both campaign_id and stat_time_day (days) are grouped
        /// Note: When dimensions contain stat_time_day, the query time range can not exceed 30 days, and when dimensions contain stat_time_hour, the query time range cannot exceed 1 day
        /// See link - https://ads.tiktok.com/marketing_api/docs?id=1701890951192578
        /// </summary>
        [JsonProperty("dimensions")]
        public List<string> Dimensions { get; set; }

        /// <summary>
        /// "Metrics to query. Auction and Reservation Ads support different metrics, see Auction Ads Report Supplement-Supported Metrics and Reservation Ads Report Supplement-Supported Metrics. Defaut: [""spend,"" ""impressions""]"
        /// See link - https://ads.tiktok.com/marketing_api/docs?id=1701890951192578
        /// </summary>
        [JsonProperty("metrics")]
        public List<string> Metrics { get; set; }

        /// <summary>
        /// Query start date (closed interval) in the format of YYYY-MM-DD. The date is based on the ad account time zone. This field is required when lifetime is false.
        /// </summary>
        [JsonProperty("start_date")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Query end date (closed interval) in the format of YYYY-MM-DD. The date is based on the ad account time zone. This field is required when lifetime is false.
        /// </summary>
        [JsonProperty("end_date")]
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Whether to request the lifetime metrics. The lifetime metric name is the same as the normal one. If lifetime = true, the start_date and end_date parameters will be ignored.
        /// Note: Breakdown by time is not supported when query for lifetime metrics, and the Reservation Ads report does not support lifetime metrics. Default value: false
        /// </summary>
        [JsonProperty("lifetime")]
        public bool? Lifetime { get; set; }

        /// <summary>
        /// Sort field. All supported metrics (excluding attribute metrics) support sorting, not sorting by default
        /// </summary>
        [JsonProperty("order_field")]
        public string OrderField { get; set; }

        /// <summary>
        /// Sort. Optional value: ASC, DESC. Default value: DESC
        /// </summary>
        [JsonProperty("order_type")]
        public string OrderType { get; set; }

		/// <summary>
		/// Filter criteria. Supported filtering criteria vary according to 'service_type' and 'data_level', see Auction Ads Report Supplement-Supported Filters and Reservation Ads Report Supplement-Supported filters
		/// </summary>
		[JsonProperty("filters")]
		public List<ReportInputFilter> Filters { get; set; }

		/// <summary>
		/// Current int of pages. Default value: 1
		/// </summary>
		[JsonProperty("page")]
        public int? Page { get; set; }

        /// <summary>
        /// Pagination size. Value range: 1-1000. Default value: 10
        /// </summary>
        [JsonProperty("page_size")]
        public int? PageSize { get; set; }
    }

    public class ReportInputFilter
    {
        /// <summary>
        /// Filter field name
        /// </summary>
        [JsonProperty("field_name")]
        public string FieldName { get; set; }

        /// <summary>
        /// Filter type, optional values: IN, MATCH, GREATER_EQUAL, GREATER_THAN, LOWER_EQUAL, LOWER_THAN.
        /// </summary>
        [JsonProperty("filter_type")]
        public string FilterType { get; set; }

        /// <summary>
        /// The value to filter. When filter_type = IN, filter_value needs to be a valid JSON array character string
        /// </summary>
        [JsonProperty("filter_value")]
        public string FilterValue { get; set; }
    }
}
