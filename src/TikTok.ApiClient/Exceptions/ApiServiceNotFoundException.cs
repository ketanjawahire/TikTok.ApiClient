using System;
using System.Runtime.Serialization;

namespace TikTok.ApiClient.Exceptions
{
#pragma warning disable CA1032 // Implement standard exception constructors
    /// <summary>
    /// Represents errors occured during API service discovery.
    /// </summary>
    [Serializable]
    public class ApiServiceNotFoundException : Exception
#pragma warning restore CA1032 // Implement standard exception constructors
    {
        private Type _serviceType;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiServiceNotFoundException"/> class.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        public ApiServiceNotFoundException(Type serviceType)
            : base(serviceType != null ? $"TikTok API service of type {serviceType.Name} is not implemented yet. Please contact developer." : "Service of given type is not implemented yet. Please contact developer.")
        {
            _serviceType = serviceType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiServiceNotFoundException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="streamingContext">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected ApiServiceNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
