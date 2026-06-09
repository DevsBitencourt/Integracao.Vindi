using Newtonsoft.Json;

namespace IntegracaoVindi.Services.Vindi.Models
{
    public sealed class Address
    {
        #region Properties

        [JsonProperty(PropertyName = "street")]
        public string? Street { get; set; }

        [JsonProperty(PropertyName = "number")]
        public string? Number { get; set; }

        [JsonProperty(PropertyName = "additional_details")]
        public string? AdditionalDetails { get; set; }

        [JsonProperty(PropertyName = "zipcode")]
        public string? ZipCode { get; set; }

        [JsonProperty(PropertyName = "neighborhood")]
        public string? Neighborhood { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string? City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string? State { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string? Country { get; set; }

        #endregion
    }
}
