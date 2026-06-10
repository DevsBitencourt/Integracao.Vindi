using IntegracaoVindi.Infrastructure.Exceptions;
using IntegracaoVindi.Infrastructure.Factory.Interfaces;
using IntegracaoVindi.Infrastructure.Resolvers;
using IntegracaoVindi.Services.Vindi.Customers;
using IntegracaoVindi.Services.Vindi.PaymentMethods;
using System.Threading;
using System.Threading.Tasks;

namespace IntegracaoVindi.Services.Vindi
{
    public sealed class VindiTenantService
    {
        #region Properties

        private readonly IVindiServiceFactory _factory;
        private readonly ITenantTokenResolver _resolver;

        #endregion

        #region Constructors

        public VindiTenantService(
            IVindiServiceFactory factory,
            ITenantTokenResolver resolver)
        {
            _factory = factory;
            _resolver = resolver;
        }

        #endregion

        #region Public Methods


        public async Task<ICustomerService> CustomersAsync(
            int tenantId, CancellationToken ct = default)
        {
            var token = await ResolverTokenAsync(tenantId, ct);
            return _factory.Customers(token);
        }

        public async Task<IPaymentMethodsService> PaymentsAsync(
            int tenantId, CancellationToken ct = default)
        {
            var token = await ResolverTokenAsync(tenantId, ct);
            return _factory.Payments(token);
        }

        #endregion

        #region Private Methods

        private async Task<string> ResolverTokenAsync(int tenantId, CancellationToken ct)
        {
            var token = await _resolver.ResolverAsync(tenantId, ct);

            if (string.IsNullOrWhiteSpace(token))
                throw new IntegrationCredentialsException(
                    $"Token not found for tenant {tenantId}.");

            return token;
        }

        #endregion

    }
}
