using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Linq;
using TikTok.ApiClient.Enums;
using TikTok.ApiClient.Services;

namespace TikTok.ApiClient.Entities
{
    public class Adgroup : IApiEntity
    {
        /// <summary>
        /// advertiser id
        /// </summary>
        [JsonProperty("advertiser_id")]
        public long AdvertiserId { get; set; }

        /// <summary>
        /// adgroup id
        /// </summary>
        [JsonProperty("adgroup_id")]
        public long AdgroupId { get; set; }

        /// <summary>
        /// adgroup name
        /// </summary>
        [JsonProperty("adgroup_name")]
        public string AdgroupName { get; set; }

        /// <summary>
        /// Adgroup status
        /// </summary>
        [JsonProperty("status")]
        public AdgroupStatus AdgroupStatus { get; set; }

        /// <summary>
        /// campaign id
        /// </summary>
        [JsonProperty("campaign_id")]
        public long CampaignId { get; set; }

        /// <summary>
        /// campaign name
        /// </summary>
        [JsonProperty("campaign_name")]
        public string CampaignName { get; set; }

        /// <summary>
        /// placement, please see detail from appendix[placement]
        /// </summary>
        [JsonProperty("placement")]
        public List<string> Placement { get; set; }

        /// <summary>
        /// Gets the tik tok placements.
        /// </summary>
        /// <value>
        /// The tik tok placements into list of Placements enum.
        /// </value>
        public List<Placements> TikTokPlacements
        {
            get { return this.Placement.Select(item => (Placements) Enum.Parse(typeof(Placements), item)).ToList(); }
        }

        /// <summary>
        /// landing page URL will return, when campaign objective is CONVERSIONS；And when campaign objective TRAFFIC and choose landing_page_url, it will return.
        /// </summary>
        [JsonProperty("landing_page_url")]
        public string LandingPageUrl { get; set; }

        /// <summary>
        /// display name will return,when campaign objective is CONVERSIONS;And when campaign objective TRAFFIC and choose landing_page_url, it will return.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// app id
        /// </summary>
        [JsonProperty("app_id")]
        public string AppId { get; set; }

        /// <summary>
        /// download URL will return,when campaign objective is APP_INSTALL; when campaign objective TRAFFIC and choose app_download_url, will return.
        /// </summary>
        [JsonProperty("app_download_url")]
        public string AppDownloadUrl { get; set; }

        /// <summary>
        /// app name will return,when campaign objective is APP; when campaign objective TRAFFIC and choose app_download_url, will return.
        /// </summary>
        [JsonProperty("app_name")]
        public string AppName { get; set; }

        /// <summary>
        /// profile image
        /// </summary>
        [JsonProperty("profile_image")]
        public string ProfileImage { get; set; }

        /// <summary>
        /// app type
        /// </summary>
        [JsonProperty("app_type")]
        public string AppType { get; set; }

        /// <summary>
        /// package name
        /// </summary>
        [JsonProperty("package")]
        public string Package { get; set; }

        /// <summary>
        /// category
        /// </summary>
        [JsonProperty("category")]
        public int Category { get; set; }

        /// <summary>
        /// keywords
        /// </summary>
        [JsonProperty("keywords")]
        public List<string> Keywords { get; set; }


        /// <summary>
        /// whether to ban comments
        /// </summary>
        [JsonProperty("is_comment_disable")]
        public int IsCommentDisable { get; set; }

        /// <summary>
        /// audience id list is unlimited if it is null
        /// </summary>
        [JsonProperty("audience")]
        public List<int> Audience { get; set; }

        /// <summary>
        /// excluded audience id list is unlimited if it is null
        /// </summary>
        [JsonProperty("excluded_audience")]
        public List<int> ExcludedAudience { get; set; }

        /// <summary>
        /// gender is unlimited if it is null, please see detail from appendix[audience gender]
        /// </summary>
        [JsonProperty("gender")]
        public string Gender { get; set; }

        /// <summary>
        /// location id list
        /// </summary>
        [JsonProperty("location")]
        public List<int> Location { get; set; }

        /// <summary>
        /// age is unlimited if it is null,please see detail from appendix[age range of audience]
        /// </summary>
        [JsonProperty("age")]
        public List<string> Age { get; set; }

        public List<AgeGroups> TikTokAgeGroups
        {
            get { return this.Age.Select(item => (AgeGroups) Enum.Parse(typeof(AgeGroups), item)).ToList(); }
        }

        /// <summary>
        /// language is unlimited if it is null
        /// </summary>
        [JsonProperty("languages")]
        public List<string> Languages { get; set; }

        /// <summary>
        /// connection type is unlimited if it is null,please see detail from appendix[connection type of audience]
        /// </summary>
        [JsonProperty("connection_type")]
        public List<string> ConnectionType { get; set; }

        /// <summary>
        /// operation system is unlimited if it is null,please see detail from appendix[operation system of audience]
        /// </summary>
        [JsonProperty("operation_system")]
        public List<string> OperationSystem { get; set; }

        /// <summary>
        /// budget
        /// </summary>
        [JsonProperty("budget")]
        public decimal Budget { get; set; }

        /// <summary>
        /// budget mode, please see detail from appendix[budget mode]
        /// </summary>
        [JsonProperty("budget_mode")]
        public BudgetMode BudgetMode { get; set; }

        /// <summary>
        /// pacing speed, please see detail from appendix [pacing speed]
        /// </summary>
        [JsonProperty("pacing")]
        public Pacing Pacing { get; set; }

        ///// <summary>
        ///// schedule type, please see detail from appendix [schedule type]
        ///// </summary>
        //[JsonProperty("schedule_type")]
        //public string ScheduleType { get; set; }

        /// <summary>
        /// Optimization goalEnum value:CONVERT: ConversionCLICK: ClickSHOW: ShowREACH: reachVIDEO_VIEW: video viewingINSTALL: installIN_APP_EVENT: in-app event
        /// </summary>
        [JsonProperty("optimize_goal")]
        [JsonConverter(typeof(StringEnumConverter))]
        public OptimizeGoal OptimizeGoal { get; set; }

        /// <summary>
        /// event, please see detail from appendix[billing event]
        /// </summary>
        [JsonProperty("billing_event")]
        public BillingEvent BillingEvent { get; set; }

        /// <summary>
        /// CPC, CPM bid, oCPC learning bid
        /// </summary>
        [JsonProperty("bid")]
        public decimal Bid { get; set; }

        /// <summary>
        /// schedule start time,UTC, format: YYYY-MM-DD HH:mm:ss
        /// </summary>
        [JsonProperty("schedule_start_time")]
        public DateTime ScheduleStartTime { get; set; }

        /// <summary>
        /// schedule end time,UTC, format: YYYY-MM-DD HH:mm:ss
        /// </summary>
        [JsonProperty("schedule_end_time")]
        public DateTime ScheduleEndTime { get; set; }

        /// <summary>
        /// ad serving period, which is delivered by default at full time. The format is 48*7-bit string and both are 0 or 1. The minimum granularity is half an hour. From Monday to Sunday, it is divided into 48 sections, 0 is not delivered, 1 is delivery, no transmission, all transmission 0, and all transmission 1 are all stand for full time delivery.
        /// </summary>
        [JsonProperty("dayparting")]
        public string Dayparting { get; set; }

        /// <summary>
        /// conversion id
        /// </summary>
        [JsonProperty("conversion_id")]
        public int ConversionId { get; set; }

        /// <summary>
        /// 1/0，whether skip learning phase
        /// </summary>
        [JsonProperty("skip_learning_phase")]
        public int SkipLearningPhase { get; set; }

        /// <summary>
        /// oCPC conversion bid
        /// </summary>
        [JsonProperty("conversion_bid")]
        public float ConversionBid { get; set; }

        /// <summary>
        /// show tracking url
        /// </summary>
        [JsonProperty("impression_tracking_url")]
        public string ImpressionTrackingUrl { get; set; }

        /// <summary>
        /// click tracking url
        /// </summary>
        [JsonProperty("click_tracking_url")]
        public string ClickTrackingUrl { get; set; }

        /// <summary>
        /// tracking url of video view
        /// </summary>
        [JsonProperty("video_view_tracking_url")]
        public string VideoViewTrackingUrl { get; set; }

        /// <summary>
        /// create time
        /// </summary>
        [JsonProperty("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// modify time
        /// </summary>
        [JsonProperty("modify_time")]
        public string ModifyTime { get; set; }

        /// <summary>
        /// creative，for details, please refer to【appendix-material creation method】
        /// </summary>
        [JsonProperty("creative_material_mode")]
        public string CreativeMaterialMode { get; set; }

        /// <summary>
        /// Shallow eventEnum:ACTIVE: activateACTIVE_REGISTER: activate and registerCREATE_GAMEROLE: Activate and create a characterLOGIN: login successfullyCOMPLETE_TUTORIAL: Complete the tutorial
        /// </summary>
        [JsonProperty("external_action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ExternalAction ExternalAction { get; set; }

        /// <summary>
        /// Deep conversion eventEnum:ACTIVE_PAY: activate and make paymentADD_PAYMENT_INFO: Add payment informationLOAN_APPLY: Apply for a loanSTART_TRIAL: start trialSUBSCRIBE: SubscribeIN_APP_ORDER: Place order in app
        /// </summary>
        [JsonProperty("deep_external_action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public DeepExternalAction DeepExternalAction { get; set; }

        /// <summary>
        /// Deep bidding typesEnum:DEFAULT: standard biddingMIN: Custom biddingPACING: Dynamic bidding
        /// </summary>
        [JsonProperty("deep_bid_type")]
        public DeepBidType DeepBidType { get; set; }

        /// <summary>Gets or sets the target string.</summary>
        /// <value>The target string.</value>
        public string TargetString { get; set; }
    }
}
