using System;
using System.Net;
using System.Runtime.Serialization;

namespace TikTok.ApiClient.Exceptions
{
#pragma warning disable CA1032 // Implement standard exception constructors
    /// <summary>
    /// Represents any error returned by Snapchat API.
    /// </summary>
    [Serializable]
    public class ApiException : Exception
#pragma warning restore CA1032 // Implement standard exception constructors
    {
        private readonly HttpStatusCode _statusCode;
        private readonly ApiError _apiError;
        private readonly ErrorResponse _errorResponse;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="apiError">Object of type <see cref="ApiError"/>.</param>
        /// <param name="statusCode"><see cref="HttpStatusCode"/> returned by API HTTP request.</param>
        public ApiException(ApiError apiError, HttpStatusCode statusCode)
            : base(apiError != null ? $"{apiError.Message}. Check ApiError for more details." : string.Empty)
        {
            _statusCode = statusCode;
            _apiError = apiError;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="errorResponse">Object of type <see cref="ErrorResponse"/>.</param>
        /// <param name="statusCode"><see cref="HttpStatusCode"/> returned by API HTTP request.</param>
        public ApiException(ErrorResponse errorResponse, HttpStatusCode statusCode)
            : base(errorResponse != null ? errorResponse.ErrorDescription : string.Empty)
        {
            _statusCode = statusCode;
            _errorResponse = errorResponse;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="streamingContext">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected ApiException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ApiException"/> class.
        /// </summary>
        /// <param name="message">The Exception message</param>
        /// <param name="apiError">Object of type <see cref="ApiError"/>.</param>
        public ApiException(string message, ApiError apiError) : base(message) {
            _apiError = apiError;
        }

        /// <summary>
        /// Gets HTTP status code returned by HTTP request.
        /// </summary>
        public HttpStatusCode HttpStatusCode
        {
            get { return _statusCode; }
        }

        /// <summary>
        /// Gets error returned by API call.
        /// </summary>
        public ApiError ApiError
        {
            get { return _apiError; }
        }
    }
}
