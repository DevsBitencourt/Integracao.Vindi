using IntegracaoVindi.Infrastructure.Factory;
using IntegracaoVindi.Infrastructure.Factory.Interfaces;
using IntegracaoVindi.Infrastructure.Options;
using IntegracaoVindi.Services.Filters.Customer;
using IntegracaoVindi.Services.Filters.PaymentMethod;
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
            services.AddTransient<IVindiServiceFactory, VindiServiceFactory>();

            configure ??= new VindiOptions();
            services.AddSingleton(configure);

            services.AddFilters();

            if (configure.SandBox == false)
            {
                services.AddHttpClient("vindi", client =>
                {
                    client.BaseAddress = new Uri(configure.Uri);

                    if (client.DefaultRequestHeaders.Accept.Count == 0 || !client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
                        client.DefaultRequestHeaders.Accept
                            .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                });
            }

            return services;
        }

        private static IServiceCollection AddFilters(this IServiceCollection services)
        {
            services.AddScoped<ICustomerFilter, CustomerFilter>();
            services.AddScoped<IPaymentMethodFilter, PaymentMethodFilter>();

            return services;
        }

        #endregion
    }
}
