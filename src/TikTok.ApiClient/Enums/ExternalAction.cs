namespace TikTok.ApiClient.Enums
{
    /// <summary>
    /// Conversion Events Enum
    /// See Link - https://ads.tiktok.com/marketing_api/docs?id=1701890988826626
    /// In v1.3 External Action are now called optimization_event - https://ads.tiktok.com/marketing_api/docs?id=1739361474981889
    /// </summary>
    public enum ExternalAction
    {
        /// <summary>
        /// Activate
        /// </summary>
        ACTIVE,

        /// <summary>
        /// Successful registration
        /// </summary>
        ACTIVE_REGISTER,

        /// <summary>
        /// Create a role
        /// </summary>
        CREATE_GAMEROLE,

        /// <summary>
        /// Log in successfully
        /// </summary>
        LOGIN,

        /// <summary>
        /// Complete the tutorial
        /// </summary>
        COMPLETE_TUTORIAL,

        /// <summary>
        /// Day 1 retention
        /// </summary>
        NEXT_DAY_OPEN,

        /// <summary>
        /// In-app Add to cart
        /// </summary>
        IN_APP_CART,

        /// <summary>
        /// Add to wish list
        /// </summary>
        ADD_TO_WISHLIST,

        /// <summary>
        /// Open app
        /// </summary>
        LAUNCH_APP,

        /// <summary>
        /// View details
        /// </summary>
        IN_APP_DETAIL_UV,

        /// <summary>
        /// Create a group
        /// </summary>
        CREATE_GROUP,

        /// <summary>
        /// Get sales leads
        /// </summary>
        SALES_LEAD,

        /// <summary>
        /// In-app ad clicks
        /// </summary>
        IN_APP_AD_CLICK,

        /// <summary>
        /// In-app ad impressions
        /// </summary>
        IN_APP_AD_IMPR,

        /// <summary>
        /// Join a group
        /// </summary>
        JOIN_GROUP,

        /// <summary>
        /// Achieve a level. This event is named achieve_level in TikTok Ads Manager.
        /// </summary>
        UPDATE_LEVEL,

        /// <summary>
        /// Issue a loan
        /// </summary>
        LOAN_COMPLETION,

        /// <summary>
        /// Rate
        /// </summary>
        RATE,

        /// <summary>
        /// Search
        /// </summary>
        SEARCH,

        /// <summary>
        /// Spending credits
        /// </summary>
        SPEND_CREDITS,

        /// <summary>
        /// Unlock achievement
        /// </summary>
        UNLOCK_ACHIEVEMENT,

        /// <summary>
        /// Time spent staying in the live shopping room. Valid when promotion_type is LIVE_SHOPPING and optimization_goal is MT_LIVE_ROOM. This event is managed by allowlist.
        /// </summary>
        LIVE_STAY_TIME,

        /// <summary>
        /// Number of clicks on the product links during the live shopping sessions. Valid when promotion_type is LIVE_SHOPPING and optimization_goal is PRODUCT_CLICK_IN_LIVE. This event is managed by allowlist.
        /// </summary>
        LIVE_CLICK_PRODUCT_ACTION,

        /// <summary>
        /// 6-second views (Focused view).
        /// The number of times your video has been played at least 6 seconds, or received at least 1 engagement within 1 day of the user seeing a paid ad. Engagements to be measured: Likes, shares, follows, profile visits, clicks, hashtag clicks, music clicks, anchor clicks, and interactive add-ons activity clicks.
        /// Valid when optimization_goal is ENGAGED_VIEW.
        /// </summary>
        ENGAGED_VIEW,

        /// <summary>
        /// 15-second views (Focused view).
        /// The number of times your video has been played at least 15 seconds, or received at least 1 engagement within 1 day of the user seeing a paid ad. Engagements to be measured: Likes, shares, follows, profile visits, clicks, hashtag clicks, music clicks, anchor clicks, and interactive add-ons activity clicks.
        /// Valid when optimization_goal is ENGAGED_VIEW_FIFTEEN. This event is managed by allowlist.
        /// </summary>
        ENGAGED_VIEW_FIFTEEN,

        /// <summary>
        /// Successfully complete a payment
        /// </summary>
        ACTIVE_PAY,

        /// <summary>
        /// Add payment info
        /// </summary>
        ADD_PAYMENT_INFO,

        /// <summary>
        /// In-app purchase
        /// </summary>
        IN_APP_ORDER,

        /// <summary>
        /// Apply for a loan
        /// </summary>
        LOAN_APPLY,

        /// <summary>
        /// Start trial
        /// </summary>
        START_TRIAL,

        /// <summary>
        /// Subscrib
        /// </summary>
        SUBSCRIBE,

        /// <summary>
        /// View content
        /// </summary>
        VIEW,

        /// <summary>
        /// Click button
        /// </summary>
        BUTTON,

        /// <summary>
        /// Consult
        /// </summary>
        CONSULT,

        /// <summary>
        /// Complete user registration
        /// </summary>
        ON_WEB_REGISTER,

        /// <summary>
        /// Browse product details page
        /// </summary>
        ON_WEB_DETAIL,

        /// <summary>
        /// Add to cart
        /// </summary>
        ON_WEB_CART,

        /// <summary>
        /// Place an order
        /// </summary>
        ON_WEB_ORDER,

        /// <summary>
        /// Complete a payment
        /// </summary>
        SHOPPING,

        /// <summary>
        /// Browse details page (form submission)
        /// </summary>
        FORM_DETAIL,

        /// <summary>
        /// Click button (form submission)
        /// </summary>
        FORM_BUTTON,

        /// <summary>
        /// Form submission
        /// </summary>
        FORM,

        /// <summary>
        /// Browse details page (phone consultation)
        /// </summary>
        PHONE_DETAIL,

        /// <summary>
        /// Click button (phone consultation)
        /// </summary>
        PHONE_BUTTON,

        /// <summary>
        /// Phone consultation
        /// </summary>
        PHONE,

        /// <summary>
        /// Browse details page (app promotion)
        /// </summary>
        DOWNLOAD_DETAIL,

        /// <summary>
        /// Click button (app promotion)
        /// </summary>
        DOWNLOAD_BUTTON,

        /// <summary>
        /// Click to download (app promotion)
        /// </summary>
        DOWNLOAD_START,

        /// <summary>
        /// Landing Page View. The user clicks and loads the landing page successfully.
        /// </summary>
        LANDING_PAGE_VIEW
    }
}
