using IntegracaoVindi.Services.Filters;
using IntegracaoVindi.Services.Models;
using IntegracaoVindi.Services.Vindi.PaymentMethods.Models;
using System.Threading;
using System.Threading.Tasks;

namespace IntegracaoVindi.Services.Vindi.PaymentMethods
{
    /// <summary>
    /// Defines operations for managing payment methods in the Vindi API.
    /// </summary>
    public interface IPaymentMethodsService
    {
        #region Public Methods

        /// <summary>
        /// Returns a list of payment methods with optional filters.
        /// </summary>
        /// <param name="ct">Token to cancel the operation.</param>
        /// <param name="filters">Query filters. Combined with AND by default.</param>
        Task<Response<PaymentMethodsList>> GetAll(CancellationToken ct = default, params QueryFilter[] filters);

        /// <summary>
        /// Retrieves a payment method by unique identifier.
        /// </summary>
        /// <param name="id">Payment method ID in Vindi.</param>
        /// <param name="ct">Token to cancel the operation.</param>
        Task<Response<Payment_Methods>> GetById(string id, CancellationToken ct = default);

        #endregion
    }
}
