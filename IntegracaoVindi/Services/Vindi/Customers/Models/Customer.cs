using IntegracaoVindi.Services.Vindi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace IntegracaoVindi.Services.Vindi.Customers.Models
{
    /// <summary>
    /// Represents a Vindi customer.
    /// </summary>
    public sealed class Customer
    {
        #region Properties

        /// <summary>Unique identifier assigned by Vindi.</summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>Full name of the customer.</summary>
        [JsonProperty(PropertyName = "name")]
        public string? Name { get; set; }

        /// <summary>Email address.</summary>
        [JsonProperty(PropertyName = "email")]
        public string? Email { get; set; }

        /// <summary>CPF or CNPJ.</summary>
        [JsonProperty(PropertyName = "registry_code")]
        public string? RegistryCode { get; set; }

        /// <summary>Customer address.</summary>
        [JsonProperty(PropertyName = "address")]
        public Address? Address { get; set; }

        /// <summary>List of phone numbers.</summary>
        [JsonProperty(PropertyName = "phones")]
        public IList<Phone>? Phones { get; set; }

        #endregion
    }
}
