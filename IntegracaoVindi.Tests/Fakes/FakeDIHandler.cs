using IntegracaoVindi.Infrastructure.DI;
using IntegracaoVindi.Infrastructure.Factory.Interfaces;
using IntegracaoVindi.Infrastructure.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;

namespace IntegracaoVindi.Tests.Fakes
{
    internal static class FakeDIHandler
    {
        // monta o container apontando o HttpClient para o handler fake
        internal static IVindiServiceFactory BuildFactory(
            HttpStatusCode statusCode,
            string body = "")
        {
            var services = new ServiceCollection();

            services
                .AddHttpClient("vindi", client =>
                {
                    client.BaseAddress = new Uri("https://sandbox.vindi.com.br/api/v1"); // qualquer uri válida
                })
                .ConfigurePrimaryHttpMessageHandler(
                    () => new FakeHttpHandler(statusCode, body));

            var options = new VindiOptions()
            {
                SandBox = true
            };

            services.AddVindi(options);

            return services
                .BuildServiceProvider()
                .GetRequiredService<IVindiServiceFactory>();
        }
    }
}
