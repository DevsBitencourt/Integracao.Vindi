using IntegracaoVindi.Services.Vindi.PaymentMethods;
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

        private Task<IPaymentMethodsService> ServiceLoad(PaymentMethodStatus status, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            string json = string.Empty;

            switch (status)
            {
                case PaymentMethodStatus.GetAll_Success:
                    json = FixtureLoader.Load("PaymentMethods/paymentMethod_list_success.json");
                    break;

                case PaymentMethodStatus.GetById_Success:
                    json = FixtureLoader.Load("PaymentMethods/paymentMethod_getById_success.json");
                    break;

            }

            var resolver = FakeDIHandler.BuildFactory(statusCode, json);
            return resolver.PaymentsAsync(4375);
        }

        [Test]
        public async Task GetAll_WhenSuccess_ReturnsSuccessResponse()
        {
            var payment = await ServiceLoad(PaymentMethodStatus.GetAll_Success);

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
            var payment = await ServiceLoad(PaymentMethodStatus.GetById_Success);
            var response = await payment.GetById("42654");

            Assert.That(response.Success, Is.True);
        }

    }
}
