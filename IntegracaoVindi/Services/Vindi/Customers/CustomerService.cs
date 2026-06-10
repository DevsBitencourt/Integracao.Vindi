using IntegracaoVindi.Services.Builders;
using IntegracaoVindi.Services.Filters;
using IntegracaoVindi.Services.Models;
using IntegracaoVindi.Services.Vindi.Customers.Models;
using IntegracaoVindi.Services.Vindi.Enums;
using IntegracaoVindi.Services.Vindi.Helpers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegracaoVindi.Services.Vindi.Customers
{
    internal sealed class CustomerService(IHttpClientFactory factory) : VindiClient(factory), ICustomerService
    {
        #region Properties

        private readonly string _endpoint = RouteHelper.GetPath(VindiRoute.Customers);

        #endregion
        #region Constructors

        #endregion

        #region Public Methods

        public Task<Response<CustomerList>> GetAll(CancellationToken ct = default, params QueryFilter[] filters)
        {
            var query = QueryBuilder.Build(filters);
            return Fetch<CustomerList>((c, t) => c.GetAsync(_endpoint + query, t), ct);
        }

        public Task<Response<Customer>> GetById(string id, CancellationToken ct = default)
        {
            return Fetch<Customer>((c, t) => c.GetAsync($"{_endpoint}/{id}", t), ct);
        }

        public Task<Response<Customer>> Delete(string id, CancellationToken ct = default)
        {
            return Fetch<Customer>((c, t) => c.DeleteAsync($"{_endpoint}/{id}", t), ct);
        }

        public Task<Response<Customer>> Create(Customer body, CancellationToken ct = default)
        {
            var json = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            return Fetch<Customer>((c, t) => c.PostAsync(_endpoint, json, t), ct);
        }

        public Task<Response<Customer>> Update(Customer body, CancellationToken ct = default)
        {
            var json = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            return Fetch<Customer>((c, t) => c.PutAsync($"{_endpoint}/{body.Id}", json, t), ct);
        }

        #endregion
    }
}
