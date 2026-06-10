using Newtonsoft.Json;


namespace IntegracaoVindi.Services.Vindi.PaymentMethods.Models
{  /// <summary>
   /// Represents a Vindi list payment methods.
   /// </summary>
    public class PaymentMethodResponse
    {
        #region Properties

        /// <summary>
        /// list payment methods
        /// </summary>
        [JsonProperty("payment_method")]
        public PaymentMethod? PaymentMethod { get; set; }

        #endregion
    }
}
