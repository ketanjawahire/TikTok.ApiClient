using System.Collections.Generic;

namespace TikTok.ApiClient
{
    public class AdgroupInsightWrapper : IWrapper<AdgroupInsight>
    {
        public List<AdgroupInsight> List { get; set; }
    }
}
