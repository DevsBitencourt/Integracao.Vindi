using IntegracaoVindi.Services.Enums;

namespace IntegracaoVindi.Services.Filters
{
    public class QueryFilter
    {
        #region Properties

        public string Field { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public FilterOperator Operator { get; set; }
        public ConditionalOperator Condition { get; set; } = ConditionalOperator.And;

        #endregion
    }
}
