using IntegracaoVindi.Infrastructure.DI;
using IntegracaoVindi.Infrastructure.Exceptions;
using IntegracaoVindi.Infrastructure.Factory.Interfaces;
using IntegracaoVindi.Tests.Fakes;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace IntegracaoVindi.Tests.Customers
{
    [TestFixture]
    public class CustomerServiceTests
    {
        // monta o container apontando o HttpClient para o handler fake
        private static IVindiServiceFactory BuildFactory(
            HttpStatusCode statusCode,
            string body = "")
        {
            var services = new ServiceCollection();

            services
                .AddHttpClient("vindi_fake")
                .ConfigurePrimaryHttpMessageHandler(
                    () => new FakeHttpHandler(statusCode, body));

            services.AddVindi();

            return services
                .BuildServiceProvider()
                .GetRequiredService<IVindiServiceFactory>();
        }

        // ── GetAll ────────────────────────────────────────────────

        [Test]
        public async Task GetAll_WhenSuccess_ReturnsSuccessResponse()
        {
            const string json = "{\"customers\":[{\"id\":1,\"name\":\"João Silva\"}]}";
            var factory = BuildFactory(HttpStatusCode.OK, json);
            var customers = factory.Customers("valid_token:");

            var response = await customers.GetAll();

            Assert.That(response.Success, Is.True);
            Assert.That(response.Data?.Customers, Has.Count.EqualTo(1));
            Assert.That(response.Data!.Customers![0].Name, Is.EqualTo("João Silva"));
        }

        [Test]
        public async Task GetAll_WhenNotFound_ReturnsFailureResponse()
        {
            var factory = BuildFactory(HttpStatusCode.NotFound);
            var customers = factory.Customers("valid_token:");

            var response = await customers.GetAll();

            Assert.That(response.Success, Is.False);
            Assert.That(response.Error, Does.Contain("404"));
        }

        // ── GetById ───────────────────────────────────────────────

        [Test]
        public async Task GetById_WhenSuccess_ReturnsCustomer()
        {
            const string json = "{\"customer\":{\"id\":42,\"name\":\"Maria\"}}";
            var factory = BuildFactory(HttpStatusCode.OK, json);
            var customers = factory.Customers("valid_token:");

            var response = await customers.GetById("42");

            Assert.That(response.Success, Is.True);
        }

        // ── Exceptions ────────────────────────────────────────────

        [Test]
        public async Task GetAll_WhenUnauthorized_ThrowsIntegrationAuthorizationException()
        {
            var factory = BuildFactory(HttpStatusCode.Unauthorized);
            var customers = factory.Customers("invalid_token:");

            try
            {
                await customers.GetAll();
                Assert.Fail("Expected IntegrationAuthorizationException but no exception was thrown.");
            }
            catch (IntegrationAuthorizationException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public async Task GetAll_WhenForbidden_ThrowsIntegrationForbiddenException()
        {
            var factory = BuildFactory(HttpStatusCode.Forbidden);
            var customers = factory.Customers("limited_token:");

            try
            {
                await customers.GetAll();
                Assert.Fail("Expected IntegrationForbiddenException but no exception was thrown.");
            }
            catch (IntegrationForbiddenException)
            {
                Assert.Pass();
            }
        }

        [Test]
        public async Task Customers_WhenTokenIsEmpty_ThrowsIntegrationCredentialsException()
        {
            var factory = BuildFactory(HttpStatusCode.OK);

            try
            {
                await factory.Customers(string.Empty).GetAll();
                Assert.Fail("Expected IntegrationCredentialsException but no exception was thrown.");
            }
            catch (IntegrationCredentialsException)
            {
                Assert.Pass();
            }
        }

        // ── Delete ────────────────────────────────────────────────

        [Test]
        public async Task Delete_WhenSuccess_ReturnsSuccessResponse()
        {
            const string json = "{\"customer\":{\"id\":1}}";
            var factory = BuildFactory(HttpStatusCode.OK, json);
            var customers = factory.Customers("valid_token:");

            var response = await customers.Delete("1");

            Assert.That(response.Success, Is.True);
        }

        // ── CancellationToken ─────────────────────────────────────

        [Test]
        public async Task GetById_WhenCancelled_ThrowsTaskCancelledException()
        {
            var factory = BuildFactory(HttpStatusCode.OK, "{}");
            var customers = factory.Customers("valid_token:");

            using var cts = new System.Threading.CancellationTokenSource();
            cts.Cancel();

            try
            {
                await customers.GetById("1", cts.Token);
                Assert.Fail("Expected TaskCanceledException but no exception was thrown.");
            }
            catch (TaskCanceledException)
            {
                Assert.Pass();
            }
        }
    }
}
