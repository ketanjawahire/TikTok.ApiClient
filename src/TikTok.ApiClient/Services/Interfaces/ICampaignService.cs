using System.Collections.Generic;
using System.Threading.Tasks;
using TikTok.ApiClient.Entities;
using static TikTok.ApiClient.TikTokServices;

namespace TikTok.ApiClient.Services.Interfaces
{
    public interface ICampaignService : IApiService
    {
        IEnumerable<CampaignInsight> GetReport(InputModel model);

        Task<IEnumerable<Campaign>> Get(CampaignRequestModel requestModel);
    }
}
