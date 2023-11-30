using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTok.ApiClient.Entities;

namespace TikTok.ApiClient.Services.Interfaces
{
    /// <summary>
    /// class that handle spark ads methods
    /// </summary>
    public interface ISparkAdsService : IApiService
    {
        /// <summary>
        /// Fetch spark ads data
        /// </summary>
        /// <param name="model">Request model</param>
        /// <returns>Spark ads</returns>
        Task<IEnumerable<SparkAds>> Get(BaseRequestModel model);
    }
}
