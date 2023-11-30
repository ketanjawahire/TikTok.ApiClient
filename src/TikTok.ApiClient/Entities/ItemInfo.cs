using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTok.ApiClient.Entities
{
    /// <summary>
    /// Spark ads item info
    /// </summary>
    public class ItemInfo
    {
        /// <summary>
        /// advertiser id
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// ad id
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; set; }
    }
}
