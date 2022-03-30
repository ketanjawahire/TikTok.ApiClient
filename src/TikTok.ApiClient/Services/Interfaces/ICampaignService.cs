using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TikTok.ApiClient.Entities;

namespace TikTok.ApiClient.Services.Interfaces
{
    /// <summary>
    /// Contain methods to retrieve campaign related data from TikTok API.
    /// </summary>
    public interface ICampaignService : IApiService
    {
        /// <summary>
        /// Get Campaigns available at TikTok using API.
        /// </summary>
        /// <param name="requestModel">Request Model</param>
        /// <returns>Collection of <see cref="Campaign"/></returns>
        Task<IEnumerable<Campaign>> Get(CampaignRequestModel requestModel);
    }
}
