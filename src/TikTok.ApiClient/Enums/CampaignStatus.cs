namespace TikTok.ApiClient.Enums
{
    public enum CampaignStatus
    {
        /// <summary>
        /// Paused
        /// </summary>
        CAMPAIGN_STATUS_DISABLE,

        /// <summary>
        /// Enabled
        /// </summary>
        CAMPAIGN_STATUS_ENABLE,

        /// <summary>
        /// Deleted
        /// </summary>
        CAMPAIGN_STATUS_DELETE,

        /// <summary>
        /// All (Including deleted)
        /// </summary>
        CAMPAIGN_STATUS_ALL,

        /// <summary>
        /// All (excluding deleted)
        /// </summary>
        CAMPAIGN_STATUS_NOT_DELETE
    }
}
