using System.Collections.Generic;
using TikTok.ApiClient.Entities;
using static TikTok.ApiClient.TikTokServices;

namespace TikTok.ApiClient.Services.Interfaces
{
    public interface IAdService : IApiService
    {
        IEnumerable<Ad> Get(AdRequestModel model);
        IEnumerable<AdInsight> GetReport(InputModel model);
    }
}
