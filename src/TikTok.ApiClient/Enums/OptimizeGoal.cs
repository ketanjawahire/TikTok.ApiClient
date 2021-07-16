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
        VALUE
    }
}
