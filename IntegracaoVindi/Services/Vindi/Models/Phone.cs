using Newtonsoft.Json;

namespace IntegracaoVindi.Services.Vindi.Api.Models
{
    public sealed class Phone
    {
        #region Properties

        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "phone_type")]
        public string? PhoneType { get; set; }

        [JsonProperty(PropertyName = "number")]
        public string? Number { get; set; }

        [JsonProperty(PropertyName = "extension")]
        public string? Extension { get; set; }

        [JsonProperty(PropertyName = "_destroy")]
        public string? Destroy { get; set; }

        #endregion
    }
}
