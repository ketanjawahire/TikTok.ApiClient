namespace TikTok.ApiClient
{
    /// <summary>
    /// Represents string constants used across SDK.
    /// </summary>
    internal static class Constants
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA2211 // Non-constant fields should not be visible
#pragma warning disable SA1401 // Fields should be private
#pragma warning disable SA1310 // Field names should not contain underscore
        /// <summary>
        /// Invalid page option message.
        /// </summary>
        public static string INVALID_PAGEOPTIONS = "Invalid PageOptions";

        /// <summary>
        /// Unauthorization user message.
        /// </summary>
        public static string UNAUTHORIZED_USER = "User is not authorized to perform given operation.";
#pragma warning restore SA1310 // Field names should not contain underscore
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore CA2211 // Non-constant fields should not be visible
#pragma warning restore CA1707 // Identifiers should not contain underscores
    }
}
