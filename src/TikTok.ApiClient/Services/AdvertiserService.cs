using RestSharp;
using System.Collections.Generic;
using System.Linq;
using TikTok.ApiClient.Entities;
using TikTok.ApiClient.Services.Interfaces;

namespace TikTok.ApiClient.Services
{
    internal class AdvertiserService : BaseService, IAdvertiserService
    {
        internal AdvertiserService(AuthenticationService authenticationService)
            : base(authenticationService)
        {
        }

        public IEnumerable<AgentAdvertiser> GetAdvertisers()
        {
            var request = new RestRequest("/oauth2/advertiser/get/", Method.GET);

            //TODO : need to get access token here
            request.AddObject(new { access_token = "ACCESS_TOKEN_HERE", app_id = "APP_ID_HERE", secret = "SECRET_HERE" });

            var response = Execute<AgentAdvertiserRootObject>(request).Result;

            if (response.code == 40105)
            {
                throw new Exceptions.UnauthorizedAccessException();
            }

            var result = Extract<AgentAdvertiserRootObject, AgentAdvertiserWrapper, AgentAdvertiser>(response);

            return result.List;
        }

        //TODO : fix it. Its not working 
        public IEnumerable<Advertiser> Get(IEnumerable<string> advertiserIds)
        {
            var request = new RestRequest("/2/advertiser/info", Method.GET);

            request.AddObject(new { advertiser_ids = advertiserIds.ToArray(), fields = new[] { "id", "name", "description", "email", "contacter", "phonenumber", "role", "status", "telephone", "address", "reason", "license_url", "license_no", "license_province", "license_city", "company", "brand", "promotion_area", "promotion_center_province", "promotion_center_city", "industry", "balance" } });

            var response = Execute<AdvertiserRootObject>(request).Result;

            if (response.code == 40105)
            {
                throw new Exceptions.UnauthorizedAccessException();
            }

            var result = Extract<AdvertiserRootObject, AdvertiserWrapper, Advertiser>(response);

            return result.List;
        }

    }

}
