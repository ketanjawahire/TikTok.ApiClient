namespace TikTok.ApiClient.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IAccessTokenService : IApiService
    {
        Task<AuthResponse> Get();
    }
}
