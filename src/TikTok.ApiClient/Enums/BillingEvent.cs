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
        [Obsolete("From v1.0, TikTok do not support oCPC and support oCPM instead. See - https://ads.tiktok.com/marketing_api/docs?id=1701890929565697")]
        OCPM,
        
        /// <summary>
        /// The GD
        /// </summary>
        GD
    }
}
