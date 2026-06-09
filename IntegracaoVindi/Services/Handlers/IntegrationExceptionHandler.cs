using IntegracaoVindi.Infrastructure.Exceptions;
using System.Net;
using System.Net.Http;

namespace IntegracaoVindi.Services.Handlers
{
    internal static class IntegrationExceptionHandler
    {
        #region Public Methods

        public static void ThrowIfUnauthorized(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
                throw new IntegrationAuthorizationException(
                    "Invalid or expired token. Please check your credentials.");

            if (response.StatusCode == HttpStatusCode.Forbidden)
                throw new IntegrationForbiddenException(
                    "No permission to access this resource.");
        }

        #endregion
    }
}
