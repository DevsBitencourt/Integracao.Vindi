using IntegracaoVindi.Services.Enums;

namespace IntegracaoVindi.Services.Filters.PaymentMethod
{
    internal class PaymentMethodFilter : FilterBase, IPaymentMethodFilter
    {
        #region Public Methods

        public IPaymentMethodFilter Id(FilterOperator filterOperator, string value, ConditionalOperator condition = ConditionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "id",
                Operator = filterOperator,
                Value = value,
                Condition = condition
            });
            return this;
        }

        public IPaymentMethodFilter Name(FilterOperator filterOperator, string name, ConditionalOperator condition = ConditionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "name",
                Operator = filterOperator,
                Value = $"'{name}'",
                Condition = condition
            });
            return this;
        }

        public IPaymentMethodFilter Code(string code, ConditionalOperator condition = ConditionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "code",
                Operator = FilterOperator.None,
                Value = code,
                Condition = condition
            });
            return this;
        }

        #endregion
    }
}
