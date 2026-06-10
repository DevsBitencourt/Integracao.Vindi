using IntegracaoVindi.Tests.Fakes;
using IntegracaoVindi.Tests.Fixtures;
using NUnit.Framework;
using System.Net;
using System.Threading.Tasks;

namespace IntegracaoVindi.Tests.PaymentMethods
{
    [TestFixture]
    public class PaymentMethodsServiceTests
    {

        // ── GetAll ────────────────────────────────────────────────

        [Test]
        public async Task GetAll_WhenSuccess_ReturnsSuccessResponse()
        {
            var json = FixtureLoader.Load("PaymentMethods/paymentMethod_list_success.json");
            var factory = FakeDIHandler.BuildFactory(HttpStatusCode.OK, json);
            var payment = factory.Payments("valid_token:");

            var response = await payment.GetAll();

            using (Assert.EnterMultipleScope())
            {
                Assert.That(response.Success, Is.True);
                Assert.That(response.Data?.Payment_Methods, Has.Count.EqualTo(6));
                Assert.That(response.Data!.Payment_Methods![0].Id, Is.EqualTo(42654));
            }
        }

        [Test]
        public async Task GetById_WhenSuccess_ReturnsSuccessResponse()
        {
            var json = FixtureLoader.Load("PaymentMethods/paymentMethod_getById_success.json");
            var factory = FakeDIHandler.BuildFactory(HttpStatusCode.OK, json);
            var payment = factory.Payments("valid_token:");

            var response = await payment.GetById("42654");

            Assert.That(response.Success, Is.True);
        }

    }
}
