using IntegracaoVindi.Infrastructure.Factory.Interfaces;
using IntegracaoVindi.Services.Vindi.Api.Customers;
using System.Net.Http;

namespace IntegracaoVindi.Infrastructure.Factory
{
    internal sealed class VindiServiceFactory : IVindiServiceFactory
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VindiServiceFactory(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public ICustomerService Customers(string token)
        {
            var service = new CustomerService(_httpClientFactory);
            service.SetCredentials(token);
            return service;
        }
    }
}
