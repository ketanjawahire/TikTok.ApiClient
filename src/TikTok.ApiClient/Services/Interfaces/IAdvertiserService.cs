using System.Collections.Generic;
using static TikTok.ApiClient.TikTokServices;

namespace TikTok.ApiClient.Services.Interfaces
{
    public interface IAdvertiserService : IApiService
    {
        IEnumerable<AgentAdvertiser> GetAdvertiers();
        IEnumerable<Advertiser> Get(IEnumerable<string> advertiserIds);
    }
}
