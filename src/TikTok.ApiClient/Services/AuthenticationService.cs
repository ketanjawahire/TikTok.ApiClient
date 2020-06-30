using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serialization;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TikTok.ApiClient.Entities;
using TikTok.ApiClient.Exceptions;

namespace TikTok.ApiClient.Services
{
    internal class AuthenticationService
    {
        private string _accessToken;

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
