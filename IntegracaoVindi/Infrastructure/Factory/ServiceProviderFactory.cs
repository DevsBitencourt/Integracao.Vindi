using IntegracaoVindi.Infrastructure.DI;
using Microsoft.Extensions.DependencyInjection;

namespace IntegracaoVindi.Infrastructure.Factory
{
    public class ServiceProviderFactory
    {
        /// <summary>
        /// If the system already has a DI container, execute the 'AddVindiIntegration()' method to register and resolve dependencies.
        /// If DI is absent, use this method to create a ServiceProvider and manage the necessary dependencies.
        /// </summary>
        /// <returns></returns>
        public static ServiceProvider Create()
        {
            var services = new ServiceCollection();
            services.AddVindiIntegration();

            var provider = services.BuildServiceProvider();

            return provider;
        }
    }
}
