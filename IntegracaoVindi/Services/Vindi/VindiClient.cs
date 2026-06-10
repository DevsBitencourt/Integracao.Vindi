using IntegracaoVindi.Infrastructure.Exceptions;
using IntegracaoVindi.Services.Handlers;
using IntegracaoVindi.Services.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegracaoVindi.Services.Vindi
{
    internal abstract class VindiClient(IHttpClientFactory factory) : IVindiClient
    {
        #region Properties

        private string _token = string.Empty;

        private readonly HttpClient _client = factory.CreateClient("vindi");

        #endregion

        #region Constructor

        #endregion

        #region Public Methods

        public void SetCredentials(string credentials)
        {
            _token = credentials;
        }

        #endregion

        #region Protected Methods

        protected virtual HttpClient CreateHttpClient()
        {
            if (string.IsNullOrEmpty(_token))
                throw new IntegrationCredentialsException();

            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", GetToken());

            return _client;
        }

        #endregion

        #region Private Methods

        private string GetToken()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(_token));
        }

        #region Private Methods

        protected async Task<Response<T>> Fetch<T>(Func<HttpClient, CancellationToken, Task<HttpResponseMessage>> action, CancellationToken ct = default)
        {
            var client = CreateHttpClient();
            using var response = await action(client, ct);

            if (!response.IsSuccessStatusCode)
                return HandleError<T>(response);

            var content = await response.Content.ReadAsStringAsync();
            return new Response<T>
            {
                Data = JsonConvert.DeserializeObject<T>(content),
                Success = true
            };
        }

        private static Response<T> HandleError<T>(HttpResponseMessage response)
        {
            IntegrationExceptionHandler.ThrowIfUnauthorized(response);

            return new Response<T>
            {
                Success = false,
                Error = $"{(int)response.StatusCode} - {response.ReasonPhrase}"
            };
        }

        #endregion


        #endregion
    }
}
