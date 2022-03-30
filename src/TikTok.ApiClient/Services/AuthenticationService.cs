using System;

namespace TikTok.ApiClient.Services
{
    internal class AuthenticationService
    {
        private readonly string _accessToken;

        internal AuthenticationService(string accessToken)
        {
            if (string.IsNullOrEmpty(accessToken))
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            _accessToken = accessToken;
        }

        public string Get()
        {
            return _accessToken;
        }
    }
}
