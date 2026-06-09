using IntegracaoVindi.Services.Builders;
using IntegracaoVindi.Services.Filters;
using IntegracaoVindi.Services.Handlers;
using IntegracaoVindi.Services.Models;
using IntegracaoVindi.Services.Vindi.Api.Customers.Models;
using IntegracaoVindi.Services.Vindi.Api.Helpers;
using IntegracaoVindi.Services.Vindi.Enums;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegracaoVindi.Services.Vindi.Api.Customers
{
    internal sealed class CustomerService : VindiClient, ICustomerService
    {
        #region Properties

        private readonly string _endpoint;

        #endregion

        #region Constructors

        public CustomerService(IHttpClientFactory factory) : base(factory)
        {
            _endpoint = RouteHelper.GetPath(VindiRoute.Customers);
        }

        #endregion

        #region Private Methods

        private async Task<Response<T>> Fetch<T>(Func<HttpClient, CancellationToken, Task<HttpResponseMessage>> action, CancellationToken ct = default)
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

        #region Public Methods

        public async Task<Response<CustomerList>> GetAll(QueryFilter[] filters, CancellationToken ct = default)
        {
            var query = QueryBuilder.Build(filters);
            return await Fetch<CustomerList>((c, t) => c.GetAsync(_endpoint + query, t), ct);
        }

        public async Task<Response<Customer>> GetById(string id, CancellationToken ct = default)
        {
            return await Fetch<Customer>((c, t) => c.GetAsync($"{_endpoint}/{id}", t), ct);
        }

        public async Task<Response<Customer>> Delete(string id, CancellationToken ct = default)
        {
            return await Fetch<Customer>((c, t) => c.DeleteAsync($"{_endpoint}/{id}", t), ct);
        }

        public async Task<Response<Customer>> Create(Customer body, CancellationToken ct = default)
        {
            var json = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            return await Fetch<Customer>((c, t) => c.PostAsync(_endpoint, json, t), ct);
        }

        public async Task<Response<Customer>> Update(Customer body, CancellationToken ct = default)
        {
            var json = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            return await Fetch<Customer>((c, t) => c.PutAsync($"{_endpoint}/{body.Id}", json, t), ct);
        }

        #endregion
    }
}
