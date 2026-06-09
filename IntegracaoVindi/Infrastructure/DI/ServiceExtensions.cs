using IntegracaoVindi.Infrastructure.Factory;
using IntegracaoVindi.Infrastructure.Factory.Interfaces;
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

        public static IServiceCollection AddVindi(this IServiceCollection services)
        {
            services.AddTransient<IVindiServiceFactory, VindiServiceFactory>();

            services.AddFilters();

            services.AddHttpClient("vindi", client =>
            {
                client.BaseAddress = new Uri("https://app.vindi.com.br:443");

                if (client.DefaultRequestHeaders.Accept.Count == 0 || !client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
                    client.DefaultRequestHeaders.Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });

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
