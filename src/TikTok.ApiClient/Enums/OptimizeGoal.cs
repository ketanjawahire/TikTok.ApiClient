namespace TikTok.ApiClient.Services
{
    public enum OptimizeGoal
    {
        /// <summary>
        /// Click
        /// </summary>
        CLICK,

        /// <summary>
        /// Conversion
        /// </summary>
        CONVERT,

        /// <summary>
        /// Installation
        /// </summary>
        INSTALL,

        /// <summary>
        /// In-app event
        /// </summary>
        IN_APP_EVENT,

        /// <summary>
        /// Impression
        /// </summary>
        SHOW,

        /// <summary>
        /// Play video
        /// </summary>
        VIDEO_VIEW,

        /// <summary>
        /// Reach
        /// </summary>
        REACH,

        /// <summary>
        /// Leads
        /// </summary>
        LEAD_GENERATION,

        /// <summary>
        /// Follows
        /// </summary>
        FOLLOWERS,

        /// <summary>
        /// Profile Visits
        /// </summary>
        PROFILE_VIEWS,

        /// <summary>
        /// Maximize ROAS (Return on Ad Spend). Currently, it only support App Install and Catalog Sales objectives, and can only be used for Andorid apps. When this optimization goal is used, your ads cannot be deployed to Pangle placement only. skip_learning_phase cannot be set to NO_SKIP.
        /// </summary>
        VALUE,

        ENGAGED_VIEW,

        /// <summary>
        /// Live shopping room viewer retention. This goal is applicable to live shopping scenario. The corresponding optimization_event is LIVE_STAY_TIME
        /// </summary>
        MT_LIVE_ROOM,

        /// <summary>
        /// Product link clicks during a live session. This goal is applicable to live shopping scenario. The corresponding optimization_event is LIVE_CLICK_PRODUCT_ACTION
        /// </summary>
        PRODUCT_CLICK_IN_LIVE,

        /// <summary>
        /// 15-second views (Focused view). The number of times your video has been played at least 15 seconds, or received at least 1 engagement within 1 day of the user seeing a paid ad.
        /// </summary>
        ENGAGED_VIEW_FIFTEEN,

        /// <summary>
        /// Landing Page View. The user clicks and loads the landing page successfully. The corresponding optimization_event is LANDING_PAGE_VIEW.
        /// </summary>
        TRAFFIC_LANDING_PAGE_VIEW
    }
}
