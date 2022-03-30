using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using TikTok.ApiClient.Entities;
using TikTok.ApiClient.Services.Interfaces;

namespace TikTok.ApiClient.Services
{
    internal class AdvertiserService : BaseService, IAdvertiserService
    {
        private readonly string _getAdvertiserInfo;
        private readonly string _getAdvertiser;

        internal AdvertiserService(AuthenticationService authenticationService)
            : base(authenticationService)
        {
            _getAdvertiserInfo = $"{BaseUrl}/{Version}/advertiser/info/";
            _getAdvertiser = $"{BaseUrl}/{Version}/oauth2/advertiser/get/";
        }

        public IEnumerable<AgentAdvertiser> GetAdvertisers()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Advertiser> Get(IEnumerable<string> advertiserIds)
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("advertiser_ids", $"[{string.Join(",", advertiserIds)}]");

            var listOfFields = new[]
            {
                "id", "name", "description", "email", "contacter", "phonenumber", "role", "status", "telephone",
                "address", "reason", "license_url", "license_no", "license_province", "license_city", "company",
                "brand", "promotion_area", "promotion_center_province", "promotion_center_city", "industry", "balance"
            };
            
            queryString.Add("fields", $"[\"{string.Join("\",\"", listOfFields)}\"]");

            var message = new HttpRequestMessage(HttpMethod.Get, $"{_getAdvertiserInfo}?{queryString}");
            var response = Execute<AdvertiserRootObject>(message).GetAwaiter().GetResult();

            if (response.code == 40105)
            {
                throw new Exceptions.UnauthorizedAccessException();
            }

            var result = Extract<AdvertiserRootObject, AdvertiserWrapper, Advertiser>(response);
            return result.List;
        }

    }

}
