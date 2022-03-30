using System.Collections.Generic;
using TikTok.ApiClient.Entities;

namespace TikTok.ApiClient.Services.Interfaces
{
    public interface IAdvertiserService : IApiService
    {
        IEnumerable<AgentAdvertiser> GetAdvertisers();

        IEnumerable<Advertiser> Get(IEnumerable<string> advertiserIds);
    }
}
