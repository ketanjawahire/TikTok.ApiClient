using System.Collections.Generic;
using System.Threading.Tasks;
using TikTok.ApiClient.Entities;
using static TikTok.ApiClient.TikTokServices;

namespace TikTok.ApiClient.Services.Interfaces
{
    public interface IAdgroupService : IApiService
    {
        Task<IEnumerable<Adgroup>> Get(AdgroupRequestModel model);
    }
}
