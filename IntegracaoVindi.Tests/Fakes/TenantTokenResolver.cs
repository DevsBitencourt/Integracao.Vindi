using IntegracaoVindi.Infrastructure.Resolvers;
using System.Threading;
using System.Threading.Tasks;

namespace IntegracaoVindi.Tests.Fakes
{
    internal class TenantTokenResolver : ITenantTokenResolver
    {
        public Task<string> ResolverAsync(int tenantId, CancellationToken ct = default)
        {
            return Task.FromResult("token:fake");
        }
    }
}
