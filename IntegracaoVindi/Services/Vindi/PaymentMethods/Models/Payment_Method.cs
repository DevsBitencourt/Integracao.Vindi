using Newtonsoft.Json;


namespace IntegracaoVindi.Services.Vindi.PaymentMethods.Models
{  /// <summary>
   /// Represents a Vindi list payment methods.
   /// </summary>
    public class Payment_Method
    {
        #region Properties

        /// <summary>
        /// list payment methods
        /// </summary>
        [JsonProperty("payment_method")]
        public PaymentMethod? PaymentMethods { get; set; }

        #endregion
    }
}
