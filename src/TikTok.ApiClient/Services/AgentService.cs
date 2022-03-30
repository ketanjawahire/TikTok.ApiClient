using System.Collections.Generic;
using TikTok.ApiClient.Services.Interfaces;

namespace TikTok.ApiClient.Services
{
    internal class AgentService : BaseService, IAgentService
    {
        internal AgentService(AuthenticationService authenticationService)
            : base(authenticationService)
        {
        }
    }
}
