using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IntegracaoVindi.Tests.Fakes
{
    internal class FakeHttpHandler(
        HttpStatusCode statusCode,
        string responseBody = "") : HttpMessageHandler
    {

        #region Properties

        private readonly HttpStatusCode _statusCode = statusCode;
        private readonly string _responseBody = responseBody;

        #endregion

        #region Protected methods

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(_statusCode)
            {
                Content = new StringContent(_responseBody)
            };

            return Task.FromResult(response);
        }

        #endregion
    }
}
