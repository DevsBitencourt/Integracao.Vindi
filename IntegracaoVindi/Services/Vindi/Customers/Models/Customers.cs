using Newtonsoft.Json;
using System.Collections.Generic;

namespace IntegracaoVindi.Services.Vindi.Customers.Models
{
    public class CustomerList
    {
        #region Properties

        [JsonProperty(PropertyName = "customers")]
        public IList<Customer>? Customers { get; set; }

        #endregion
    }
}