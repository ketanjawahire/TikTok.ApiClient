using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTok.ApiClient.Entities
{
    /// <summary>
    /// Spark ads wrapper
    /// </summary>
    public class SparkAdsWrapper : IWrapper<SparkAds>
    {
        [JsonProperty("list")]
        public List<SparkAds> List { get; set; }

        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }
    }
}
