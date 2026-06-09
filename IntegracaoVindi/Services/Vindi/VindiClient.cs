using IntegracaoVindi.Infrastructure.Exceptions;
using System;
using System.Net.Http;
using System.Text;

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
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return _client;
        }

        #endregion

        #region Private Methods

        private string GetToken()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(_token));
        }

        #endregion
    }
}
