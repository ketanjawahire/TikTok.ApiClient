using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TikTok.ApiClient.Entities;
using static TikTok.ApiClient.TikTokServices;

namespace TikTok.ApiClient.Services.Interfaces
{
    public interface IAdService : IApiService
    {
        Task<IEnumerable<Ad>> Get(AdRequestModel model);
        
        [Obsolete("Use Report Service to fetch insights. See - https://ads.tiktok.com/marketing_api/docs?id=1701890949889025")]
        IEnumerable<AdInsight> GetReport(InputModel model);
    }
}
