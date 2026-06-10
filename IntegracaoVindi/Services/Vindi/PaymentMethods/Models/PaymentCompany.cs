using Newtonsoft.Json;

namespace IntegracaoVindi.Services.Vindi.PaymentMethods.Models
{
    public class PaymentCompany
    {
        #region Properties

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("code")]
        public string Code { get; set; } = string.Empty;

        #endregion
    }
}
