using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTok.ApiClient.Entities;

namespace TikTok.ApiClient.Services.Interfaces
{
    public interface IImageService : IApiService
    {
        Task<IEnumerable<Image>> Get(ImageRequestModel model);
    }
}
