using TikTok.ApiClient.Entities;

namespace TikTok.ApiClient.Services
{
    using Interfaces;
    using System.Threading.Tasks;

    internal class AccessTokenService : BaseService, IAccessTokenService
    {
        private readonly AuthenticationService _authService;

        public AccessTokenService(AuthenticationService authenticationService) : base(authenticationService)
        {
            _authService = authenticationService;
        }

        public async Task<AuthResponse> Get()
        {
            return await _authService.Get();
        }
    }
}
