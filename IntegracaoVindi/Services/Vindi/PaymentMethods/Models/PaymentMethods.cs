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

}
