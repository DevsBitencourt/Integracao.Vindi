using IntegracaoVindi.Services.Vindi.Api.Customers;

namespace IntegracaoVindi.Infrastructure.Factory.Interfaces
{
    /// <summary>
    /// Factory for resolving Vindi services scoped to a specific tenant token.
    /// </summary>
    public interface IVindiServiceFactory
    {
        #region Public Methods

        /// <summary>
        /// Returns a <see cref="ICustomerService"/> configured with the provided API token.
        /// </summary>
        /// <param name="token">Vindi API key for the target tenant.</param>
        ICustomerService Customers(string token);

        #endregion
    }
}
