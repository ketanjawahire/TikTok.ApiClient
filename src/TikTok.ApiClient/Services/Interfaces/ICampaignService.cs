using System.Collections.Generic;
using static TikTok.ApiClient.TikTokServices;

namespace TikTok.ApiClient.Services.Interfaces
{
    public interface ICampaignService : IApiService
    {
        IEnumerable<CampaignInsight> GetReport(InputModel model);
    }
}
