using IntegracaoVindi.Infrastructure.DI;
using IntegracaoVindi.Infrastructure.Options;
using IntegracaoVindi.Infrastructure.Resolvers;
using IntegracaoVindi.Services.Vindi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;

namespace IntegracaoVindi.Tests.Fakes
{
    internal static class FakeDIHandler
    {
        // monta o container apontando o HttpClient para o handler fake
        internal static VindiTenantService BuildFactory(
            HttpStatusCode statusCode,
            string body = "")
        {
            var services = new ServiceCollection();

            var options = new VindiOptions()
            {
                Environment = VindiOptionOperator.Fake
            };

            services.AddVindi(options);

            if (options.Environment == VindiOptionOperator.Fake)
            {
                services
                    .AddHttpClient("vindi", client =>
                    {
                        client.BaseAddress = new Uri("https://sandbox.vindi.com.br/api/v1"); // qualquer uri válida
                    })
                    .ConfigurePrimaryHttpMessageHandler(
                        () => new FakeHttpHandler(statusCode, body));
            }

            services.AddScoped<ITenantTokenResolver, TenantTokenResolver>();

            return services
                .BuildServiceProvider()
                .GetRequiredService<VindiTenantService>();
        }
    }
}
