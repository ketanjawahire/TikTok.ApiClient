using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using TikTok.ApiClient.Entities;
using TikTok.ApiClient.Services.Interfaces;

namespace TikTok.ApiClient.Services
{
    internal class ReportService : BaseService, IReportService, IApiService
    {
        private readonly string _resourceUrl;

        /// <inheritdoc />
        public ReportService(AuthenticationService authenticationService) 
            : base(authenticationService)
        {
            _resourceUrl = $"{BaseUrl}/{Version}/report/integrated/get/";
        }

        /// <inheritdoc />
        public IEnumerable<ReportResponse> GetBasicReport(ReportInputModel model)
        {
            // Validate all Required Parameters
            if (model.AdvertiserId == default)
                throw new ArgumentException("advertiser_id cannot be left 0.", nameof(model.AdvertiserId));

            if (model.ReportType == default) 
                throw new ArgumentNullException(nameof(model.ReportType));

            if (model.Dimensions == default)
                throw new ArgumentNullException(nameof(model.Dimensions));

            var queryString = HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("advertiser_id", model.AdvertiserId.ToString());
            queryString.Add("report_type", model.ReportType);
            queryString.Add("dimensions", $"[\"{string.Join("\",\"", model.Dimensions)}\"]");

            // Page
            if (model.Page.HasValue)
                queryString.Add("page", model.Page.Value.ToString());

            if (model.PageSize.HasValue)
                queryString.Add("page_size", model.PageSize.Value.ToString());

            if (!string.IsNullOrEmpty(model.ServiceType))
                queryString.Add("service_type", model.ServiceType);

            if (!string.IsNullOrEmpty(model.DataLevel))
                queryString.Add("data_level", model.DataLevel);

            if (model.Metrics != null && model.Metrics.Any())
                queryString.Add("metrics", $"[\"{string.Join("\",\"", model.Metrics)}\"]");

            if (model.StartDate.HasValue)
                queryString.Add("start_date", model.StartDate?.ToString("yyyy-MM-dd"));

            if (model.EndDate.HasValue)
                queryString.Add("end_date", model.EndDate?.ToString("yyyy-MM-dd"));

            if (!string.IsNullOrEmpty(model.OrderField))
                queryString.Add("order_field", model.OrderField);

            if (!string.IsNullOrEmpty(model.OrderType))
                queryString.Add("order_type", model.OrderType);

            if (model.Filters != null && model.Filters.Any())
                queryString.Add("filtering", JsonConvert.SerializeObject(model.Filters));

            var message = new HttpRequestMessage(HttpMethod.Get, $"{_resourceUrl}?{queryString}");
            var response = Execute<ReportResponseRootObject>(message).GetAwaiter().GetResult();

            if (response.code == 40105 || response.code == 40001) 
                throw new Exceptions.UnauthorizedAccessException();

            var result = Extract<ReportResponseRootObject, ReportResponseWrapper, ReportResponse>(response);
            var insight = new List<ReportResponse>();

            if (result.List is null)
            {
                return insight;
            }

            MultiplePageHandler<ReportResponseRootObject, ReportResponseWrapper, ReportResponse>(result, _resourceUrl, queryString, insight).GetAwaiter().GetResult();

            return insight;
        }
    }
}
