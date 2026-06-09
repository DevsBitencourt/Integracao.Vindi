using IntegracaoVindi.Services.Enums;
using IntegracaoVindi.Services.Enums.Customers;
using System;

namespace IntegracaoVindi.Services.Filters.Customer
{
    public interface ICustomerFilter
    {

        #region Public Methods

        ICustomerFilter Id(FilterOperator filterOperator, string value, ConditionalOperator condition = ConditionalOperator.And);

        ICustomerFilter Name(FilterOperator filterOperator, string name, ConditionalOperator condition = ConditionalOperator.And);

        ICustomerFilter Status(FilterOperator filterOperator, CustomerStatus status, ConditionalOperator condition = ConditionalOperator.And);

        ICustomerFilter Code(string code, ConditionalOperator condition = ConditionalOperator.And);

        ICustomerFilter Email(string email, ConditionalOperator condition = ConditionalOperator.And);

        ICustomerFilter RegistryCode(string registryCode, ConditionalOperator condition = ConditionalOperator.And);

        ICustomerFilter CreatedAt(FilterOperator filterOperator, DateTime date, ConditionalOperator condition = ConditionalOperator.And);

        ICustomerFilter UpdatedAt(FilterOperator filterOperator, DateTime date, ConditionalOperator condition = ConditionalOperator.And);

        QueryFilter[] ToFilters();

        #endregion
    }
}
