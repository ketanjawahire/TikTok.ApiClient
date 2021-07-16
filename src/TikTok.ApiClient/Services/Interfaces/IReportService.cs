using System.Collections.Generic;
using TikTok.ApiClient.Entities;

namespace TikTok.ApiClient.Services.Interfaces
{
    public interface IReportService : IApiService
    {
        IEnumerable<ReportResponse> GetBasicReport(ReportInputModel model);
    }
}
