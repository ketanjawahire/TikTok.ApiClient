using TikTok.ApiClient.Exceptions;
using TikTok.ApiClient.Services;
using TikTok.ApiClient.Services.Interfaces;

namespace TikTok.ApiClient
{
    public class TikTokServices
    {
        private readonly AuthenticationService _authService;

        public TikTokServices(string accessToken)
        {
            _authService = new AuthenticationService(accessToken);
        }

        /// <summary>
        /// Gets service implementation of type <typeparamref name="TEntity"/>.
        /// </summary>
        /// <typeparam name="TEntity"><see cref="IApiService"/>.</typeparam>
        /// <returns>Service implementation of type <typeparamref name="TEntity"/>.</returns>
        public TEntity GetService<TEntity>()
            where TEntity : IApiService
        {
            IApiService apiService = null;

            if (typeof(TEntity) == typeof(IAdvertiserService))
            {
                apiService = new AdvertiserService(_authService);
            }
            else if (typeof(TEntity) == typeof(IAgentService))
            {
                apiService = new AgentService(_authService);
            }
            else if (typeof(TEntity) == typeof(ICampaignService))
            {
                apiService = new CampaignService(_authService);
            }
            else if (typeof(TEntity) == typeof(IAdgroupService))
            {
                apiService = new AdgroupService(_authService);
            }
            else if (typeof(TEntity) == typeof(IAdService))
            {
                apiService = new AdService(_authService);
            }
            else if (typeof(TEntity) == typeof(IAccessTokenService))
            {
                apiService = new AccessTokenService(_authService);
            }
            else if (typeof(TEntity) == typeof(IReportService))
            {
                apiService = new ReportService(_authService);
            }
            else if (typeof(TEntity) == typeof(IImageService))
            {
                apiService = new ImageService(_authService);
            }
            else if (typeof(TEntity) == typeof(IVideoService))
            {
                apiService = new VideoService(_authService);
            }
            else
            {
                throw new ApiServiceNotFoundException(typeof(TEntity));
            }

            return (TEntity)apiService;
        }
    }

}
