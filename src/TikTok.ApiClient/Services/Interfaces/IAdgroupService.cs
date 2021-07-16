using System.Collections.Generic;
using System.Threading.Tasks;
using TikTok.ApiClient.Entities;

namespace TikTok.ApiClient.Services.Interfaces
{
    public interface IAdgroupService : IApiService
    {
        Task<IEnumerable<Adgroup>> Get(AdgroupRequestModel model);
    }
}
