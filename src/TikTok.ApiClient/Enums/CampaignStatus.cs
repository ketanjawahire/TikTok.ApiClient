namespace TikTok.ApiClient.Enums
{
    /// <summary>
    /// Campaign Status Enum
    /// See Link - https://ads.tiktok.com/marketing_api/docs?id=1701890985340929
    /// </summary>
    public enum CampaignStatus
    {
        /// <summary>
        /// Deleted
        /// </summary>
        CAMPAIGN_STATUS_DELETE,

        /// <summary>
        /// Advertiser review failed
        /// </summary>
        CAMPAIGN_STATUS_ADVERTISER_AUDIT_DENY,

        /// <summary>
        /// Advertiser review in progress
        /// </summary>
        CAMPAIGN_STATUS_ADVERTISER_AUDIT,

        /// <summary>
        /// Advertiser contract has not taken effect
        /// </summary>
        ADVERTISER_CONTRACT_PENDING,

        /// <summary>
        /// Over budget
        /// </summary>
        CAMPAIGN_STATUS_BUDGET_EXCEED,

        /// <summary>
        /// Suspended
        /// </summary>
        CAMPAIGN_STATUS_DISABLE,

        /// <summary>
        /// Advertising in delivery
        /// </summary>
        CAMPAIGN_STATUS_ENABLE,

        /// <summary>
        /// "All statuses (including ""Deleted"")"
        /// </summary>
        CAMPAIGN_STATUS_ALL,

        /// <summary>
        /// "All statuses (excluding ""Deleted"")"
        /// </summary>
        CAMPAIGN_STATUS_NOT_DELETE,

        /// <summary>
        /// The advertiser account punish
        /// </summary>
        ADVERTISER_ACCOUNT_PUNISH,

        /// <summary>
        /// Awaiting release. The SKAN 4.0 Dedicated Campaign is under postback. Tiktok recommends to wait a few days to release this campaign for reporting accuracy.
        /// </summary>
        CAMPAIGN_STATUS_AWAITING_RELEASE
    }
}
