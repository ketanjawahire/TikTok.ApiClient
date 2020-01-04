using System.Collections.Generic;
using static TikTok.ApiClient.TikTokServices;

namespace TikTok.ApiClient.Services.Interfaces
{
    public interface IAdService : IApiService
    {
        IEnumerable<AdInsight> GetReport(InputModel model);
    }
}
