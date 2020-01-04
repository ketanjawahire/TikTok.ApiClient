using System.Collections.Generic;

namespace TikTok.ApiClient
{
    public class CampaignInsightWrapper : IWrapper<CampaignInsight>
    {
        public List<CampaignInsight> List { get; set; }
    }
}
