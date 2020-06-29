using TikTok.ApiClient.Entities;

namespace TikTok.ApiClient.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IAccessTokenService : IApiService
    {
        string Get();
    }
}
