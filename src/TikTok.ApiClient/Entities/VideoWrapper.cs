using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTok.ApiClient.Entities
{
    public class VideoWrapper : IWrapper<Video>
    {
        [JsonProperty("list")]
        public List<Video> List { get; set; }

        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }
    }
}
