using System.Collections.Generic;
using TikTok.ApiClient.Entities;
using static TikTok.ApiClient.TikTokServices;

namespace TikTok.ApiClient.Services.Interfaces
{
    public interface ICampaignService : IApiService
    {
        IEnumerable<CampaignInsight> GetReport(InputModel model);

        IEnumerable<Adgroup> Get(CampaignRequestModel requestModel);
    }
}
