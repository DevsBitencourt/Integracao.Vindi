using IntegracaoVindi.Infrastructure.Factory;
using IntegracaoVindi.Infrastructure.Factory.Interfaces;
using IntegracaoVindi.Services.Enums;
using IntegracaoVindi.Services.Filters.Interfaces;
using IntegracaoVindi.Services.Vindi.Customers;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace IntegracaoVindi.Tests.Customers
{
    public class CustomerTests
    {
        private ICustomerService _customer;
        private ICustomerFilter _filter;

        private ServiceProvider _provider;

        [SetUp]
        public void Setup()
        {
            _provider = ServiceProviderFactory.Create();

            var _factory = _provider.GetRequiredService<IVindiServiceFactory>();

            _customer = _factory.Customers("");
            _filter = _provider.GetRequiredService<ICustomerFilter>();

        }

        [Test(Description = "Customer listing")]
        public async Task CustomersList()
        {
            _filter
                .Name(FilterOperator.Contains, "", ConditionalOperator.And)
                .CreatedAt(FilterOperator.GreaterThan, new DateTime(2018, 08, 21))
                .RegistryCode("", ConditionalOperator.Or);

            using var cts = new System.Threading.CancellationTokenSource();
            
            var response = await _customer.GetAll(cts.Token, _filter.ToFilters());

            Assert.That(response.Success, Is.True, response.Error);
        }

        [Test(Description = "Customer by Id")]
        public async Task CustomerById()
        {
            var response = await _customer.GetById("");

            Assert.That(response.Success, Is.True, response.Error);
        }

        [Test(Description = "Delete customer by Id")]
        public async Task DeleteCustomerById()
        {
            var response = await _customer.Delete("");

            Assert.That(response.Success, Is.True, response.Error);
        }
    }
}
