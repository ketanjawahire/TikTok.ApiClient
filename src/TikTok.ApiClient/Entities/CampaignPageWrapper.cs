using System.Collections.Generic;

namespace TikTok.ApiClient.Entities
{
    public class CampaignPageWrapper : IWrapper<Page<Campaign>>
    {
        public List<Page<Campaign>> List { get; set; }
    }
}
