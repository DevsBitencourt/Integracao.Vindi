using IntegracaoVindi.Infrastructure.Exceptions;
using IntegracaoVindi.Services.Vindi.Customers;
using IntegracaoVindi.Tests.Fakes;
using IntegracaoVindi.Tests.Fixtures;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace IntegracaoVindi.Tests.Customers
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private Task<ICustomerService> ServiceLoad(CustomerServiceStatus status, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            string json = string.Empty;

            switch (status)
            {
                case CustomerServiceStatus.GetAll_Success:
                    json = FixtureLoader.Load("Customers/customers_list_success.json");
                    break;

                case CustomerServiceStatus.GetById_WhenSuccess:
                    json = FixtureLoader.Load("Customers/customer_getbyid_success.json");
                    break;

                case CustomerServiceStatus.Delete_WhenSuccess:
                    json = FixtureLoader.Load("Customers/customer_delete_id_success.json");
                    break;

                default:
                    json = "{}";
                    break;
            }

            var resolver = FakeDIHandler.BuildFactory(statusCode, json);
            return resolver.CustomersAsync(4375);
        }


        // ── GetAll ────────────────────────────────────────────────

        [Test]
        public async Task GetAll_WhenSuccess_ReturnsSuccessResponse()
        {
            var customers = await ServiceLoad(CustomerServiceStatus.GetAll_Success);
            var response = await customers.GetAll();

            Assert.That(response.Success, Is.True);
            Assert.That(response.Data?.Customers, Has.Count.EqualTo(1));
            Assert.That(response.Data!.Customers![0].Name, Is.EqualTo("João Silva"));
        }

        [Test]
        public async Task GetAll_WhenNotFound_ReturnsFailureResponse()
        {
            var customers = await ServiceLoad(CustomerServiceStatus.Unknown, HttpStatusCode.NotFound);

            var response = await customers.GetAll();

            Assert.That(response.Success, Is.False);
            Assert.That(response.Error, Does.Contain("404"));
        }

        // ── GetById ───────────────────────────────────────────────

        [Test]
        public async Task GetById_WhenSuccess_ReturnsCustomer()
        {
            var customers = await ServiceLoad(CustomerServiceStatus.GetById_WhenSuccess);
            var response = await customers.GetById("42");

            Assert.That(response.Success, Is.True);
        }

        // ── Exceptions ────────────────────────────────────────────

        [Test]
        public async Task GetAll_WhenUnauthorized_ThrowsIntegrationAuthorizationException()
        {
            var customers = await ServiceLoad(CustomerServiceStatus.Unknown, HttpStatusCode.Unauthorized);

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
            var customers = await ServiceLoad(CustomerServiceStatus.Unknown, HttpStatusCode.Forbidden);
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

        // ── Delete ────────────────────────────────────────────────

        [Test]
        public async Task Delete_WhenSuccess_ReturnsSuccessResponse()
        {
            var customers = await ServiceLoad(CustomerServiceStatus.Delete_WhenSuccess);

            var response = await customers.Delete("1");

            Assert.That(response.Success, Is.True);
        }

        // ── CancellationToken ─────────────────────────────────────

        [Test]
        public async Task GetById_WhenCancelled_ThrowsTaskCancelledException()
        {
            var customers = await ServiceLoad(CustomerServiceStatus.Unknown);

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
