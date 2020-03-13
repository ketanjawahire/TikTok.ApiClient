using Newtonsoft.Json;
using System.Collections.Generic;
using TikTok.ApiClient.Entities;

namespace TikTok.ApiClient
{
    public class AdvertiserWrapper : IWrapper<Advertiser>
    {
        [JsonProperty("list")]
        public List<Advertiser> List { get; set; }

        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }
    }
}
