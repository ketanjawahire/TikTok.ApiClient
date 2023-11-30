using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TikTok.ApiClient.Entities
{
    public class ImageWrapper : IWrapper<Image>
    {
        [JsonProperty("list")]
        public List<Image> List { get; set; }

        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }
    }
}
