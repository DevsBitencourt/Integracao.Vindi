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

        private async Task<Response<T>> Fetch<T>(Func<HttpClient, Task<HttpResponseMessage>> action)
        {
            var client = CreateHttpClient();
            using var response = await action(client);

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

        public async Task<Response<CustomerList>> GetAll(params QueryFilter[] filters)
        {
            var query = QueryBuilder.Build(filters);
            return await Fetch<CustomerList>(c => c.GetAsync(_endpoint + query));
        }

        public async Task<Response<Customer>> GetById(string id)
        {
            return await Fetch<Customer>(c => c.GetAsync($"{_endpoint}/{id}"));
        }

        public async Task<Response<Customer>> Delete(string id)
        {
            return await Fetch<Customer>(c => c.DeleteAsync($"{_endpoint}/{id}"));
        }

        public async Task<Response<Customer>> Create(Customer body)
        {
            var json = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            return await Fetch<Customer>(c => c.PostAsync(_endpoint, json));
        }

        public async Task<Response<Customer>> Update(Customer body)
        {
            var json = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            return await Fetch<Customer>(c => c.PutAsync($"{_endpoint}/{body.Id}", json));
        }

        #endregion
    }
}
