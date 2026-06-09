using IntegracaoVindi.Services.Enums;

namespace IntegracaoVindi.Services.Filters.PaymentMethod
{
    internal interface IPaymentMethodFilter
    {
        #region Public Methods

        IPaymentMethodFilter Id(FilterOperator filterOperator, string value, ConditionalOperator condition = ConditionalOperator.And);

        IPaymentMethodFilter Name(FilterOperator filterOperator, string name, ConditionalOperator condition = ConditionalOperator.And);

        IPaymentMethodFilter Code(string code, ConditionalOperator condition = ConditionalOperator.And);

        #endregion
    }
}
