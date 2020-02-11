using System.Collections.Generic;
using TikTok.ApiClient.Entities;
using static TikTok.ApiClient.TikTokServices;

namespace TikTok.ApiClient.Services.Interfaces
{
    public interface IAdgroupService : IApiService
    {
        IEnumerable<Adgroup> Get(AdgroupRequestModel model);
    }
}
