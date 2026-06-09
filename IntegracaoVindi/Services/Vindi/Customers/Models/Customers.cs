using Newtonsoft.Json;
using System.Collections.Generic;

namespace IntegracaoVindi.Services.Vindi.Customers.Models
{
    /// <summary>
    /// Represents a Vindi list customers.
    /// </summary>
    public class CustomerList
    {
        #region Properties

        /// <summary>List customers</summary>
        [JsonProperty(PropertyName = "customers")]
        public IList<Customer>? Customers { get; set; }

        #endregion
    }
}