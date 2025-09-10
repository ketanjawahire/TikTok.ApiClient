using System;

namespace TikTok.ApiClient.Enums
{
    public enum DeepBidType
    {
        /// <summary>
        /// No deep event bid
        /// </summary>
        DEFAULT,

        /// <summary>
        /// Double bid. Operation Method: Tiktok Ads platform will bid to keep your average cost around your target, including installation and target costs. Recommended for: Maintaining a stable cost on your bid for both installation costs and your target costs.
        /// Note This might cause a lower install volume.
        /// </summary>
        MIN,

        /// <summary>
        /// Automatic optimization. Operation method: Tiktok Ads platform will bid to keep your average instalation cost around your target goal, while aiming to get you the maximum number of target events.
        /// Recommended for: Maintaining a stable cost around your installation bid and getting an optimized cost for your target goal.
        /// Note The cost for your target goal might be higher than that from Multi Bid mode.
        /// </summary>
        PACING,

        /// <summary>
        /// AEO
        /// </summary>
        [Obsolete]
        AEO,

        /// <summary>
        /// When optimize_goal is VALUE, the deep event bidding type must be ROI_PACING
        /// </summary>
        ROI_PACING,

        /// <summary>
        /// Bid without cost cap or ROAS goal. Valid only for Value Optimization (optimization_goal = VALUE).
        /// For more details, <see href="https://ads.tiktok.com/marketing_api/docs?id=1739381743067137">Value Optimization</see>
        /// </summary>
        VO_HIGHEST_VALUE
    }
}
