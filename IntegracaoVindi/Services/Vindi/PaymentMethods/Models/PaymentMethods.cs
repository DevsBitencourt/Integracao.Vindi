using Newtonsoft.Json;
using System.Collections.Generic;

namespace IntegracaoVindi.Services.Vindi.PaymentMethods.Models
{
    /// <summary>
    /// Represents a Vindi list payment methods.
    /// </summary>
    public class PaymentMethodsList
    {
        #region Properties

        /// <summary>
        /// list payment methods
        /// </summary>
        [JsonProperty("payment_methods")]
        public List<PaymentMethod>? Payment_Methods { get; set; }

        #endregion
    }

    /// <summary>
    /// Represents a Vindi list payment methods.
    /// </summary>
    public class Payment_Methods
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
