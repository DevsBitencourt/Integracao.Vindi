using System.Threading;
using System.Threading.Tasks;

namespace IntegracaoVindi.Infrastructure.Resolvers
{
    public interface ITenantTokenResolver
    {
        #region Methods

        Task<string> ResolverAsync(int tenantId, CancellationToken ct = default);

        #endregion
    }
}
