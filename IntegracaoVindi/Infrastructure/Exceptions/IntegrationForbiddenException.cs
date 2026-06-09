using System;

namespace IntegracaoVindi.Infrastructure.Exceptions
{
    public class IntegrationForbiddenException : IntegrationException
    {

        #region Constructors

        public IntegrationForbiddenException(string message) : base(message)
        {
        }

        public IntegrationForbiddenException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public IntegrationForbiddenException(string message, int statusCode, string? errorCode = null) : base(message, statusCode, errorCode)
        {
        }

        #endregion
    }
}
