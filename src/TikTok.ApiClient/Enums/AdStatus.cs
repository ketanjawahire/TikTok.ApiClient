namespace TikTok.ApiClient.Enums
{
    /// <summary>
    /// Ad Status Enum
    /// See Link - https://ads.tiktok.com/marketing_api/docs?id=1701890985340929
    /// </summary>
    public enum AdStatus
    {
        /// <summary>
        /// Campaign deleted
        /// </summary>
        AD_STATUS_CAMPAIGN_DELETE,

        /// <summary>
        /// Ad group deleted
        /// </summary>
        AD_STATUS_ADGROUP_DELETE,

        /// <summary>
        /// Deleted
        /// </summary>
        AD_STATUS_DELETE,

        /// <summary>
        /// Account review failed
        /// </summary>
        AD_STATUS_ADVERTISER_AUDIT_DENY,

        /// <summary>
        /// Account review summary released
        /// </summary>
        AD_STATUS_ADVERTISER_AUDIT,

        /// <summary>
        /// Advertiser contract has not taken effect
        /// </summary>
        ADVERTISER_CONTRACT_PENDING,

        /// <summary>
        /// Insufficient account balance
        /// </summary>
        AD_STATUS_BALANCE_EXCEED,

        /// <summary>
        /// Campaign over budget
        /// </summary>
        AD_STATUS_CAMPAIGN_EXCEED,

        /// <summary>
        /// Ad group over budget
        /// </summary>
        AD_STATUS_BUDGET_EXCEED,

        /// <summary>
        /// Under review
        /// </summary>
        AD_STATUS_AUDIT,

        /// <summary>
        /// Modifications under review
        /// </summary>
        AD_STATUS_REAUDIT,

        /// <summary>
        /// Review failed
        /// </summary>
        AD_STATUS_AUDIT_DENY,

        /// <summary>
        /// Ad group review failed
        /// </summary>
        AD_STATUS_ADGROUP_AUDIT_DENY,

        /// <summary>
        /// The scheduled delivery time has not started
        /// </summary>
        AD_STATUS_NOT_START,

        /// <summary>
        /// Completed
        /// </summary>
        AD_STATUS_DONE,

        /// <summary>
        /// Campaign suspended
        /// </summary>
        AD_STATUS_CAMPAIGN_DISABLE,

        /// <summary>
        /// Ad group suspended
        /// </summary>
        AD_STATUS_ADGROUP_DISABLE,

        /// <summary>
        /// Ad suspended
        /// </summary>
        AD_STATUS_DISABLE,

        /// <summary>
        /// Advertising in delivery
        /// </summary>
        AD_STATUS_DELIVERY_OK,

        /// <summary>
        /// All statuses (including "Deleted")
        /// </summary>
        AD_STATUS_ALL,
    }
}
