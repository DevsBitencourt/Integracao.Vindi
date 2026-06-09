using System;

namespace IntegracaoVindi.Infrastructure.Exceptions
{
    public class IntegrationAuthorizationException : IntegrationException
    {
        #region Constructors

        public IntegrationAuthorizationException(string message) : base(message)
        {
        }

        public IntegrationAuthorizationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public IntegrationAuthorizationException(string message, int statusCode, string? errorCode = null) : base(message, statusCode, errorCode)
        {
        }

        #endregion

    }
}
