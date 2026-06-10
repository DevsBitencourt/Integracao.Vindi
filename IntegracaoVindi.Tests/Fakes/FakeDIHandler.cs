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
            return services
                .BuildServiceProvider()
                .GetRequiredService<IVindiServiceFactory>();
        }
    }
}
