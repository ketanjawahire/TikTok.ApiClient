namespace TikTok.ApiClient.Enums
{
    /// <summary>
    /// Objective Type enum
    /// See - https://ads.tiktok.com/marketing_api/docs?id=1701890985340929
    /// </summary>
    public enum ObjectiveType
    {
        /// <summary>
        /// Null Objective Type
        /// </summary>
        NONE,

        /// <summary>
        /// Get more people to install your app.
        /// </summary>
        APP_INSTALL,

        /// <summary>
        /// Drive valuable actions on your website or app.
        /// </summary>
        CONVERSIONS,

        /// <summary>
        /// Send more people to a destination on your website or app.
        /// </summary>
        TRAFFIC,

        /// <summary>
        /// Get more people to view your video content.
        /// </summary>
        VIDEO_VIEWS,

        /// <summary>
        /// Show your ad to the maximum number of people.
        /// </summary>
        REACH,

        /// <summary>
        /// Collect leads for your business or brand.
        /// </summary>
        LEAD_GENERATION,

        /// <summary>
        /// Reach and frequency buying
        /// </summary>
        RF_REACH,

        /// <summary>
        /// Get more follows or profile visits.
        /// </summary>
        ENGAGEMENT,

        /// <summary>
        /// DPA Ad%% attract users to buy your products.
        /// </summary>
        CATALOG_SALES,

        /// <summary>
        /// Get more people to view your video content in R&F ads.
        /// NOTE: In Doc its RF_VIDEO_VIEWS but in API call coming as RF_VIDEO_VIEW
        /// </summary>
        RF_VIDEO_VIEW,

        RF_TRAFFIC,

        APP_PROMOTION
    }
}
