using System;
using System.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace TikTok.ApiClient.Helpers
{
    public class TikTokAuthenticator : IAuthenticator
    {
        private string _accessToken;
        public TikTokAuthenticator(string accessToken)
        {
            _accessToken = accessToken;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            foreach (var parameter in request.Parameters.Where(p => p.Name.Equals("Access-Token", StringComparison.OrdinalIgnoreCase)).ToList())
            {
                request.Parameters.Remove(parameter);
            }
            request.AddHeader("Access-Token", _accessToken);
        }
    }
}
