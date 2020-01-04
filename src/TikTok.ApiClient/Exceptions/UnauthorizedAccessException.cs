using System;
using System.Runtime.Serialization;

namespace TikTok.ApiClient.Exceptions
{
#pragma warning disable CA1032 // Implement standard exception constructors
    /// <summary>
    /// Represents unauthorized access errors occured during API call.
    /// </summary>
    [Serializable]
    public class UnauthorizedAccessException : Exception
#pragma warning restore CA1032 // Implement standard exception constructors
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorizedAccessException"/> class.
        /// </summary>
        public UnauthorizedAccessException()
            : base(Constants.UNAUTHORIZED_USER)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnauthorizedAccessException"/> class.
        /// </summary>
        /// <param name="serializationInfo">The System.Runtime.Serialization.SerializationInfo that holds the serialized object data about the exception being thrown.</param>
        /// <param name="streamingContext">The System.Runtime.Serialization.StreamingContext that contains contextual information about the source or destination.</param>
        protected UnauthorizedAccessException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
