using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;
using TikTok.ApiClient.Entities;
using TikTok.ApiClient.Services.Interfaces;

namespace TikTok.ApiClient.Services
{
    internal class ReportService : BaseService, IReportService, IApiService
    {
        /// <inheritdoc />
        public IEnumerable<ReportResponse> GetBasicReport(ReportInputModel model)
        {
            var request = new RestRequest("/v1.2/reports/integrated/get", Method.GET);

            // Validate all Required Parameters
            if (model.AdvertiserId == default)
                throw new ArgumentException("advertiser_id cannot be left 0.", nameof(model.AdvertiserId));
            if (model.ReportType == default) throw new ArgumentNullException(nameof(model.ReportType));
            if (model.Dimensions == default) throw new ArgumentNullException(nameof(model.Dimensions));

            request.AddQueryParameter("advertiser_id", model.AdvertiserId.ToString());
            request.AddQueryParameter("report_type", model.ReportType);
            request.AddQueryParameter("dimensions", $"[\"{string.Join("\",\"", model.Dimensions)}\"]");

            // Page
            if (model.Page.HasValue)
                request.AddQueryParameter("page", model.Page.Value.ToString());

            if (model.PageSize.HasValue)
                request.AddQueryParameter("page_size", model.PageSize.Value.ToString());

            if (!string.IsNullOrEmpty(model.ServiceType))
                request.AddQueryParameter("service_type", model.ServiceType);

            if (!string.IsNullOrEmpty(model.DataLevel))
                request.AddQueryParameter("data_level", model.DataLevel);

            if (model.Metrics != null && model.Metrics.Any())
                request.AddQueryParameter("metrics", $"[\"{string.Join("\",\"", model.Metrics)}\"]");

            if (model.StartDate.HasValue)
                request.AddQueryParameter("start_date", model.StartDate?.ToString("yyyy-MM-dd"));

            if (model.EndDate.HasValue)
                request.AddQueryParameter("end_date", model.EndDate?.ToString("yyyy-MM-dd"));

            if (model.Lifetime.HasValue)
                request.AddQueryParameter("lifetime", model.Lifetime.Value ? "true" : "false");

            if (!string.IsNullOrEmpty(model.OrderField))
                request.AddQueryParameter("order_field", model.OrderField);

            if (!string.IsNullOrEmpty(model.OrderType))
                request.AddQueryParameter("order_type", model.OrderType);

            if (model.Filters != null && model.Filters.Any())
                request.AddQueryParameter("filters", JsonConvert.SerializeObject(model.Filters));

            var response = Execute<ReportResponseRootObject>(request).GetAwaiter().GetResult();

            if (response.code == 40105) throw new Exceptions.UnauthorizedAccessException();

            var result = Extract<ReportResponseRootObject, ReportResponseWrapper, ReportResponse>(response);

            var insight = new List<ReportResponse>();
            MultiplePageHandlerForRestClient<ReportResponseRootObject, ReportResponseWrapper, ReportResponse>(result,
                insight, request);

            return insight;
        }

        /// <inheritdoc />
        public ReportService(AuthenticationService authenticationService) 
            : base(authenticationService)
        {
        }
    }
}
