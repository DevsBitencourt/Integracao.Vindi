using IntegracaoVindi.Infrastructure.Factory;
using IntegracaoVindi.Infrastructure.Factory.Interfaces;
using IntegracaoVindi.Services.Filters;
using IntegracaoVindi.Services.Filters.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IntegracaoVindi.Infrastructure.DI
{
    public static class ServiceExtensions
    {

        #region Public Methods

        public static IServiceCollection AddVindi(this IServiceCollection services)
        {
            services.AddTransient<IVindiServiceFactory, VindiServiceFactory>();
            services.AddScoped<ICustomerFilter, CustomerFilter>();

            services.AddHttpClient("vindi", client =>
            {
                client.BaseAddress = new Uri("https://app.vindi.com.br:443");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }

        #endregion
    }
}
