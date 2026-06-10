using IntegracaoVindi.Services.Builders;
using IntegracaoVindi.Services.Filters;
using IntegracaoVindi.Services.Models;
using IntegracaoVindi.Services.Vindi.Enums;
using IntegracaoVindi.Services.Vindi.Helpers;
using IntegracaoVindi.Services.Vindi.PaymentMethods.Models;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IntegracaoVindi.Services.Vindi.PaymentMethods
{
    internal class PaymentMethodsService(IHttpClientFactory factory) : VindiClient(factory), IPaymentMethodsService
    {
        #region Properties

        private readonly string _endpoint = RouteHelper.GetPath(VindiRoute.PaymentMethods);

        #endregion

        #region Public Methods

        public Task<Response<PaymentMethodsList>> GetAll(CancellationToken ct = default, params QueryFilter[] filters)
        {
            var query = QueryBuilder.Build(filters);
            return Fetch<PaymentMethodsList>((c, t) => c.GetAsync(_endpoint + query, t), ct);
        }

        public Task<Response<Payment_Methods>> GetById(string id, CancellationToken ct = default)
        {
            return Fetch<Payment_Methods>((c, t) => c.GetAsync($"{_endpoint}/{id}", t), ct);
        }

        #endregion
    }
}
