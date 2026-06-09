using System;

namespace IntegracaoVindi.Infrastructure.Exceptions
{
    internal class IntegrationException : Exception
    {

        #region Properties

        public int? StatusCode { get; }
        public string? ErrorCode { get; }

        #endregion

        #region Constructors

        public IntegrationException(string message)
            : base(message) { }

        public IntegrationException(string message, Exception innerException)
            : base(message, innerException) { }

        public IntegrationException(string message, int statusCode, string? errorCode = null)
            : base(message)
        {
            StatusCode = statusCode;
            ErrorCode = errorCode;
        }

        #endregion
    }
}
