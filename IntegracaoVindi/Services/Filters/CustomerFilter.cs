using IntegracaoVindi.Services.Enums;
using IntegracaoVindi.Services.Enums.Customers;
using IntegracaoVindi.Services.Filters.Interfaces;
using System;

namespace IntegracaoVindi.Services.Filters
{
    internal sealed class CustomerFilter : FilterBase, ICustomerFilter
    {

        #region Public Methods

        public ICustomerFilter Id(FilterOperator filterOperator, string value, ConditionalOperator condition = ConditionalOperator.And)
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

        public ICustomerFilter Name(FilterOperator filterOperator, string name, ConditionalOperator condition = ConditionalOperator.And)
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

        public ICustomerFilter Status(FilterOperator filterOperator, CustomerStatus status, ConditionalOperator condition = ConditionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "status",
                Operator = filterOperator,
                Value = status == CustomerStatus.Active ? "active" : "inactive",
                Condition = condition
            });
            return this;
        }

        public ICustomerFilter Code(string code, ConditionalOperator condition = ConditionalOperator.And)
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

        public ICustomerFilter Email(string email, ConditionalOperator condition = ConditionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "email",
                Operator = FilterOperator.None,
                Value = email,
                Condition = condition
            });
            return this;
        }

        public ICustomerFilter RegistryCode(string registryCode, ConditionalOperator condition = ConditionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "registry_code",
                Operator = FilterOperator.None,
                Value = registryCode,
                Condition = condition
            });
            return this;
        }

        public ICustomerFilter CreatedAt(FilterOperator filterOperator, DateTime date, ConditionalOperator condition = ConditionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "created_at",
                Operator = filterOperator,
                Value = date.ToString("yyyy-MM-dd"),
                Condition = condition
            });
            return this;
        }

        public ICustomerFilter UpdatedAt(FilterOperator filterOperator, DateTime date, ConditionalOperator condition = ConditionalOperator.And)
        {
            Filters.Add(new QueryFilter()
            {
                Field = "updated_at",
                Operator = filterOperator,
                Value = date.ToString("yyyy-MM-dd"),
                Condition = condition
            });
            return this;
        }

        public override QueryFilter[] ToFilters()
        {
            return base.ToFilters();
        }

        #endregion
    }
}
