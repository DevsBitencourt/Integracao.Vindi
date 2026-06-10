using Newtonsoft.Json;


namespace IntegracaoVindi.Services.Vindi.PaymentMethods.Models
{
    public class PaymentMethodSettings
    {
        #region Properties

        [JsonProperty("automatic_bill_charge")]
        public bool AutomaticBillCharge { get; set; }

        [JsonProperty("payment_profile_updater")]
        public bool PaymentProfileUpdater { get; set; }

        [JsonProperty("require_cvv")]
        public bool RequireCvv { get; set; }

        [JsonProperty("subscription_billing_delay_days")]
        public string SubscriptionBillingDelayDays { get; set; } = string.Empty;

        [JsonProperty("soft_descriptor")]
        public string SoftDescriptor { get; set; } = string.Empty;

        [JsonProperty("attempt_near_pay_days")]
        public string AttemptNearPayDays { get; set; } = string.Empty;

        [JsonProperty("attempt_fallback_acquirer")]
        public bool AttemptFallbackAcquirer { get; set; }

        [JsonProperty("payment_profile_attempt")]
        public string PaymentProfileAttempt { get; set; } = string.Empty;

        [JsonProperty("due_days")]
        public object? DueDays { get; set; }

        [JsonProperty("require_gateway")]
        public bool? RequireGateway { get; set; }

        [JsonProperty("voidable")]
        public bool? Voidable { get; set; }

        #endregion
    }
}
