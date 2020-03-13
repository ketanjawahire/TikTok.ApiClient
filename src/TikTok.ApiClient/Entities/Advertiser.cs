using Newtonsoft.Json;

namespace TikTok.ApiClient.Entities
{
    public class Advertiser : IApiEntity
    {
        /// <summary>
        /// account id
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }


        /// <summary>
        /// account name
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }


        /// <summary>
        /// brand description, the marketing content
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }


        /// <summary>
        /// email
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }


        /// <summary>
        /// contact person
        /// </summary>
        [JsonProperty("contacter")]
        public string Contacter { get; set; }


        /// <summary>
        /// phone number
        /// </summary>
        [JsonProperty("phonenumber")]
        public string Phonenumber { get; set; }


        /// <summary>
        /// role, please see details from [appendix-advertiser role]
        /// </summary>
        [JsonProperty("role")]
        public string Role { get; set; }


        /// <summary>
        /// status, please see details from [appendix-advertiser status]
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }


        /// <summary>
        /// telephone
        /// </summary>
        [JsonProperty("telephone")]
        public string Telephone { get; set; }


        /// <summary>
        /// address
        /// </summary>
        [JsonProperty("address")]
        public string Address { get; set; }


        /// <summary>
        /// the address of license preview (validity for 1 hour by default )
        /// </summary>
        [JsonProperty("license_url")]
        public string LicenseUrl { get; set; }


        /// <summary>
        /// license number
        /// </summary>
        [JsonProperty("license_no")]
        public string LicenseNo { get; set; }


        /// <summary>
        /// license province
        /// </summary>
        [JsonProperty("license_province")]
        public string LicenseProvince { get; set; }


        /// <summary>
        /// license city
        /// </summary>
        [JsonProperty("license_city")]
        public string LicenseCity { get; set; }


        /// <summary>
        /// company name
        /// </summary>
        [JsonProperty("company")]
        public string Company { get; set; }


        /// <summary>
        /// business categroy
        /// </summary>
        [JsonProperty("brand")]
        public string Brand { get; set; }


        /// <summary>
        /// promotion area
        /// </summary>
        [JsonProperty("promotion_area")]
        public string PromotionArea { get; set; }


        /// <summary>
        /// promotion province
        /// </summary>
        [JsonProperty("promotion_center_province")]
        public string PromotionCenterProvince { get; set; }


        /// <summary>
        /// promotion city
        /// </summary>
        [JsonProperty("promotion_center_city")]
        public string PromotionCenterCity { get; set; }


        /// <summary>
        /// industry
        /// </summary>
        [JsonProperty("industry")]
        public string Industry { get; set; }


        /// <summary>
        /// rejected reason
        /// </summary>
        [JsonProperty("reason")]
        public string Reason { get; set; }


        /// <summary>
        /// available balance of account(units, yuan)
        /// </summary>
        [JsonProperty("balance")]
        public string Balance { get; set; }


        /// <summary>
        /// timezone 
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
