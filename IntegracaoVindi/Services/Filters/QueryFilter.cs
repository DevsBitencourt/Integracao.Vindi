using IntegracaoVindi.Services.Enums;

namespace IntegracaoVindi.Services.Filters
{
    /// <summary>
    /// Represents a single filter condition for Vindi API queries.
    /// </summary>
    public class QueryFilter
    {
        #region Properties

        /// <summary>Field name to filter on.</summary>
        public string Field { get; set; } = string.Empty;
        /// <summary>Value to compare against.</summary>
        public string Value { get; set; } = string.Empty;
        /// <summary>Comparison operator. Defaults to <see cref="FilterOperator.None"/>.</summary>
        public FilterOperator Operator { get; set; }
        /// <summary>Logical operator combining this filter with others. Defaults to <see cref="ConditionalOperator.And"/>.</summary>
        public ConditionalOperator Condition { get; set; } = ConditionalOperator.And;

        #endregion
    }
}
