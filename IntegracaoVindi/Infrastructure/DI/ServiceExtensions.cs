using IntegracaoVindi.Infrastructure.Factory;
using IntegracaoVindi.Infrastructure.Factory.Interfaces;
using IntegracaoVindi.Services.Filters;
using IntegracaoVindi.Services.Filters.Interfaces;
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
            services.AddScoped<ICustomerFilter, CustomerFilter>();

            services.AddHttpClient("vindi", client =>
            {
                client.BaseAddress = new Uri("https://app.vindi.com.br:443");

                if (client.DefaultRequestHeaders.Accept.Count == 0 || !client.DefaultRequestHeaders.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
                    client.DefaultRequestHeaders.Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            });

            return services;
        }

        #endregion
    }
}
