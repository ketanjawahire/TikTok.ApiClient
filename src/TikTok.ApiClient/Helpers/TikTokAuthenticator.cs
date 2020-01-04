using RestSharp;
using RestSharp.Authenticators;

namespace TikTok.ApiClient.Services
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
            request.AddHeader("Access-Token", _accessToken);
        }
    }
}
