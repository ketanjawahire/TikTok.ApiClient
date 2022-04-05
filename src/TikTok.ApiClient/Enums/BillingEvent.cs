using System;

namespace TikTok.ApiClient.Services
{
    /// <summary>
    /// Billing Event Enum
    /// </summary>
    public enum BillingEvent
    {
        /// <summary>
        /// The CPM
        /// </summary>
        CPM,

        /// <summary>
        /// The CPV
        /// </summary>
        CPV,

        /// <summary>
        /// The CPC
        /// </summary>
        CPC,

        /// <summary>
        /// The OCPM
        /// </summary>
        OCPM,
        
        /// <summary>
        /// The GD
        /// </summary>
        GD,

        /// <summary>
        /// CPA is equal to oCPC
        /// </summary>
        CPA,

        /// <summary>
        /// oCPC (CPA is equal to oCPC)
        /// </summary>
        [Obsolete("From v1.0, TikTok do not support oCPC and support oCPM instead. See - https://ads.tiktok.com/marketing_api/docs?id=1701890929565697")]
        OCPC
    }
}
