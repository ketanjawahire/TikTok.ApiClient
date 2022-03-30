using System.Collections.Generic;
using System.Threading.Tasks;
using TikTok.ApiClient.Entities;

namespace TikTok.ApiClient.Services.Interfaces
{
    public interface IAdService : IApiService
    {
        Task<IEnumerable<Ad>> Get(AdRequestModel model);
    }
}
