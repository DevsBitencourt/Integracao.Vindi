using IntegracaoVindi.Services.Filters;
using IntegracaoVindi.Services.Models;
using IntegracaoVindi.Services.Vindi.Api.Customers.Models;
using System.Threading;
using System.Threading.Tasks;

namespace IntegracaoVindi.Services.Vindi.Api.Customers
{
    /// <summary>
    /// Defines operations for managing customers in the Vindi API.
    /// </summary>
    public interface ICustomerService
    {
        #region Public Methods

        /// <summary>
        /// Returns a list of customers with optional filters.
        /// </summary>
        /// <param name="ct">Token to cancel the operation.</param>
        /// <param name="filters">Query filters. Combined with AND by default.</param>
        Task<Response<CustomerList>> GetAll(QueryFilter[] filters, CancellationToken ct = default);

        /// <summary>
        /// Retrieves a customer by unique identifier.
        /// </summary>
        /// <param name="id">Customer ID in Vindi.</param>
        /// <param name="ct">Token to cancel the operation.</param>
        Task<Response<Customer>> GetById(string id, CancellationToken ct = default);

        /// <summary>
        /// Deletes a customer by unique identifier.
        /// </summary>
        /// <param name="id">Customer ID in Vindi.</param>
        /// <param name="ct">Token to cancel the operation.</param>
        Task<Response<Customer>> Delete(string id, CancellationToken ct = default);

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        /// <param name="body">Customer data to create.</param>
        /// <param name="ct">Token to cancel the operation.</param>
        Task<Response<Customer>> Create(Customer body, CancellationToken ct = default);

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="body">Updated customer data. <see cref="Customer.Id"/> is required.</param>
        /// <param name="ct">Token to cancel the operation.</param>
        Task<Response<Customer>> Update(Customer body, CancellationToken ct = default);

        #endregion
    }
}
