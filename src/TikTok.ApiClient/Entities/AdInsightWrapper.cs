using System.Collections.Generic;

namespace TikTok.ApiClient
{
    public class AdInsightWrapper : IWrapper<AdInsight>
    {
        public List<AdInsight> List { get; set; }
    }
}
