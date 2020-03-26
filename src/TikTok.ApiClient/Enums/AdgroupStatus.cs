using System;
using System.Collections.Generic;
using System.Text;

namespace TikTok.ApiClient.Enums
{
    public enum AdgroupStatus
    {
        /// <summary>
        /// Pause
        /// </summary>
        ADGROUP_STATUS_DISABLE,

        /// <summary>
        /// Delivering
        /// </summary>
        ADGROUP_STATUS_DELIVERY_OK,

        /// <summary>
        /// Not reach the start time
        /// </summary>
        ADGROUP_STATUS_NOT_START,

        /// <summary>
        /// Campaign was paused
        /// </summary>
        ADGROUP_STATUS_CAMPAIGN_DISABLE,

        /// <summary>
        /// Campaign exceed budget
        /// </summary>
        ADGROUP_STATUS_CAMPAIGN_EXCEED,

        /// <summary>
        /// Auditing
        /// </summary>
        ADGROUP_STATUS_AUDIT,

        /// <summary>
        /// Audit as for modification
        /// </summary>
        ADGROUP_STATUS_REAUDIT,

        /// <summary>
        /// Delete
        /// </summary>
        ADGROUP_STATUS_DELETE,

        /// <summary>
        /// Done
        /// </summary>
        ADGROUP_STATUS_DONE,

        /// <summary>
        /// Create new ad group
        /// </summary>
        ADGROUP_STATUS_CREATE,

        /// <summary>
        /// Audit deny
        /// </summary>
        ADGROUP_STATUS_AUDIT_DENY,

        /// <summary>
        /// Account balance is not enough
        /// </summary>
        ADGROUP_STATUS_BALANCE_EXCEED,

        /// <summary>
        /// Exceed budget
        /// </summary>
        ADGROUP_STATUS_BUDGET_EXCEED,

        /// <summary>
        /// Completed
        /// </summary>
        ADGROUP_STATUS_TIME_DONE,

        /// <summary>
        /// All (Including deleted)
        /// </summary>
        ADGROUP_STATUS_ALL,

        /// <summary>
        /// All (Not including deleted)
        /// </summary>
        ADGROUP_STATUS_NOT_DELETE,
    }
}
