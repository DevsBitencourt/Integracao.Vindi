using IntegracaoVindi.Infrastructure.Factory;
using IntegracaoVindi.Infrastructure.Factory.Interfaces;
using IntegracaoVindi.Infrastructure.Options;
using IntegracaoVindi.Services.Filters.Customer;
using IntegracaoVindi.Services.Filters.PaymentMethod;
using IntegracaoVindi.Services.Vindi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http.Headers;

namespace IntegracaoVindi.Infrastructure.DI
{
    public static class ServiceExtensions
    {

        #region Public Methods

        public static IServiceCollection AddVindi(this IServiceCollection services, VindiOptions? configure = null)
        {
            configure ??= new VindiOptions();
            services.AddSingleton(configure);
            services.AddTransient<IVindiServiceFactory, VindiServiceFactory>();

            services.AddTransient<VindiTenantService>();

            services
                .AddFilters()
                .AddHttpsClient(configure);

            return services;
        }

        private static IServiceCollection AddFilters(this IServiceCollection services)
        {
            services.AddScoped<ICustomerFilter, CustomerFilter>();
            services.AddScoped<IPaymentMethodFilter, PaymentMethodFilter>();

            return services;
        }

        private static IServiceCollection AddHttpsClient(this IServiceCollection services, VindiOptions configure)
        {
            if (configure.Environment != VindiOptionOperator.Fake)
            {
                services.AddHttpClient("vindi", client =>
                {
                    client.BaseAddress = new Uri(configure.BaseUri);

                    if (client.DefaultRequestHeaders.Accept.Count == 0 || !client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
                        client.DefaultRequestHeaders.Accept
                            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                });
            }
            return services;
        }

        #endregion
    }
}
