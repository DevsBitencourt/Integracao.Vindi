using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IntegracaoVindi.Services.Vindi.PaymentMethods.Models
{
    public class PaymentMethod
    {
        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("public_name")]
        public string PublicName { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("code")]
        public string Code { get; set; } = string.Empty;

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("settings")]
        public PaymentMethodSettings? Settings { get; set; }

        [JsonProperty("set_subscription_on_success")]
        public string SetSubscriptionOnSuccess { get; set; } = string.Empty;

        [JsonProperty("allow_as_alternative")]
        public bool AllowAsAlternative { get; set; }

        [JsonProperty("payment_companies")]
        public List<PaymentCompany>? PaymentCompanies { get; set; }

        [JsonProperty("maximum_attempts")]
        public int? MaximumAttempts { get; set; }

        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTime UpdatedAt { get; set; }

        #endregion
    }
}
