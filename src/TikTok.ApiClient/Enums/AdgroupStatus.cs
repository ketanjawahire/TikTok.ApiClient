using System;
using System.Collections.Generic;
using System.Text;

namespace TikTok.ApiClient.Enums
{
    /// <summary>
    /// Ad Group Status Enum
    /// See Link - https://ads.tiktok.com/marketing_api/docs?id=1701890985340929
    /// </summary>
    public enum AdgroupStatus
    {
        /// <summary>
        /// Deleted
        /// </summary>
        ADGROUP_STATUS_DELETE,

        /// <summary>
        /// Campaign deleted
        /// </summary>
        ADGROUP_STATUS_CAMPAIGN_DELETE,

        /// <summary>
        /// Advertiser review failed
        /// </summary>
        ADGROUP_STATUS_ADVERTISER_AUDIT_DENY,

        /// <summary>
        /// Advertiser review in progress
        /// </summary>
        ADGROUP_STATUS_ADVERTISER_AUDIT,

        /// <summary>
        /// Advertiser contract has not taken effect
        /// </summary>
        ADVERTISER_CONTRACT_PENDING,

        /// <summary>
        /// Campaign over budget
        /// </summary>
        ADGROUP_STATUS_CAMPAIGN_EXCEED,

        /// <summary>
        /// Ad group over budget
        /// </summary>
        ADGROUP_STATUS_BUDGET_EXCEED,

        /// <summary>
        /// Insufficient account balance
        /// </summary>
        ADGROUP_STATUS_BALANCE_EXCEED,

        /// <summary>
        /// Ad group review failed
        /// </summary>
        ADGROUP_STATUS_AUDIT_DENY,

        /// <summary>
        /// Review of modifications in progress
        /// </summary>
        ADGROUP_STATUS_REAUDIT,

        /// <summary>
        /// New review created
        /// </summary>
        ADGROUP_STATUS_AUDIT,

        /// <summary>
        /// New ad group created
        /// </summary>
        ADGROUP_STATUS_CREATE,

        /// <summary>
        /// The scheduled delivery time has not started
        /// </summary>
        ADGROUP_STATUS_NOT_START,

        /// <summary>
        /// Completed
        /// </summary>
        ADGROUP_STATUS_TIME_DONE,

        /// <summary>
        /// Campaign suspended
        /// </summary>
        ADGROUP_STATUS_CAMPAIGN_DISABLE,

        /// <summary>
        /// Suspended
        /// </summary>
        ADGROUP_STATUS_DISABLE,

        /// <summary>
        /// Advertising in delivery
        /// </summary>
        ADGROUP_STATUS_DELIVERY_OK,

        /// <summary>
        /// Ad group in re-review progress
        /// </summary>
        ADGROUP_STATUS_SHADOW_ADGROUP_REAUDIT,

        /// <summary>
        /// "All statuses (including ""Deleted"")"
        /// </summary>
        ADGROUP_STATUS_ALL,

        /// <summary>
        /// "All statuses (excluding ""Deleted"")"
        /// </summary>
        ADGROUP_STATUS_NOT_DELETE
    }
}
