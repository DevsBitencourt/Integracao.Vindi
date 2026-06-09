using IntegracaoVindi.Services.Vindi.Api.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IntegracaoVindi.Services.Vindi.Api.Customers.Models
{
    public sealed class Customer
    {
        #region Properties

        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string? Email { get; set; }

        [JsonProperty(PropertyName = "registry_code")]
        public string? RegistryCode { get; set; }

        [JsonProperty(PropertyName = "address")]
        public Address? Address { get; set; }

        [JsonProperty(PropertyName = "phones")]
        public IList<Phone>? Phones { get; set; }

        #endregion
    }
}
