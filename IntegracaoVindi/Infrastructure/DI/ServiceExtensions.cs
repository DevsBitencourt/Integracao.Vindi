using IntegracaoVindi.Services.Filters;
using IntegracaoVindi.Services.Filters.Interfaces;
using IntegracaoVindi.Services.Vindi.Api.Customers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IntegracaoVindi.Infrastructure.DI
{
    public static class ServiceExtensions
    {

        #region Public Methods

        public static IServiceCollection AddVindiIntegration(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
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
