using IntegracaoVindi.Services.Filters;
using IntegracaoVindi.Services.Models;
using IntegracaoVindi.Services.Vindi.Api.Customers.Models;
using System.Threading.Tasks;

namespace IntegracaoVindi.Services.Vindi.Api.Customers
{
    public interface ICustomerService : IVindiClient
    {
        #region Public Methods

        Task<Response<CustomerList>> GetAll(params QueryFilter[] filters);

        Task<Response<Customer>> GetById(string id);

        Task<Response<Customer>> Delete(string id);

        Task<Response<Customer>> Create(Customer body);

        Task<Response<Customer>> Update(Customer body);

        #endregion
    }
}
