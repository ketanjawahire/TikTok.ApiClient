using Newtonsoft.Json;
using System.Collections.Generic;

namespace TikTok.ApiClient
{
    public class AdvertiserWrapper : IWrapper<Advertiser>
    {
        [JsonProperty("list")]
        public List<Advertiser> List { get; set; }
    }
}
