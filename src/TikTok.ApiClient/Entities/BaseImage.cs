using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TikTok.ApiClient.Entities
{
    public class BaseImage : IApiEntity
    {
        /// <summary>
        /// material id
        /// </summary>
        [JsonProperty("material_id")]
        public string MaterialId { get; set; }

        /// <summary>
        /// format
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// signature
        /// </summary>
        [JsonProperty("signature")]
        public string Signature { get; set; }

        /// <summary>
        /// file name
        /// </summary>
        [JsonProperty("file_name")]
        public string FileName { get; set; }

        /// <summary>
        /// create time
        /// </summary>
        [JsonProperty("create_time")]
        public string CreateTime { get; set; }

        /// <summary>
        /// modify time
        /// </summary>
        [JsonProperty("modify_time")]
        public string ModifyTime { get; set; }

        /// <summary>
        /// width
        /// </summary>
        [JsonProperty("width")]
        public long Width { get; set; }

        /// <summary>
        /// heightS
        /// </summary>
        [JsonProperty("height")]
        public long Height { get; set; }

        /// <summary>
        /// size
        /// </summary>
        [JsonProperty("size")]
        public long Size { get; set; }

        /// <summary>
        /// displayable
        /// </summary>
        [JsonProperty("displayable")]
        public bool Displayable { get; set; }
    }
}
