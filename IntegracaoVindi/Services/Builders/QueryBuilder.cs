using IntegracaoVindi.Services.Enums;
using IntegracaoVindi.Services.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IntegracaoVindi.Services.Builders
{
    internal class QueryBuilder
    {
        #region Public Methods

        public static string Build(IEnumerable<QueryFilter> filters)
        {
            if (filters == null || !filters.Any())
                return string.Empty;

            var conditions = CreateConditions();

            foreach (var filter in filters)
            {
                var built = BuildFilter(filter);
                conditions[filter.Condition].Add(built);
            }

            var query = GetQuery(conditions);

            if (string.IsNullOrEmpty(query)) return string.Empty;

            return $"?query={Uri.EscapeDataString(query)}";
        }

        #endregion

        #region Private Methods

        private static Dictionary<ConditionalOperator, List<string>> CreateConditions()
        {
            return new Dictionary<ConditionalOperator, List<string>>()
            {
                { ConditionalOperator.And, new List<string>() },
                { ConditionalOperator.Or, new List<string>() }
            };
        }

        private static string GetQuery(Dictionary<ConditionalOperator, List<string>> conditions)
        {
            var andPart = string.Join(" AND ", conditions[ConditionalOperator.And]);
            var orPart = string.Join(" OR ", conditions[ConditionalOperator.Or]);

            if (conditions[ConditionalOperator.And].Count > 0 && conditions[ConditionalOperator.Or].Count == 0)
                return andPart;

            if (conditions[ConditionalOperator.And].Count == 0 && conditions[ConditionalOperator.Or].Count > 0)
                return orPart;

            return $"({andPart})OR({orPart})";
        }

        private static string BuildFilter(QueryFilter filter)
        {
            var value = FormatValue(filter);

            return filter.Operator switch
            {
                FilterOperator.Contains => $"{filter.Field}:{value}",
                FilterOperator.Equals => $"{filter.Field}={value}",
                FilterOperator.GreaterThan => $"{filter.Field}>{value}",
                FilterOperator.GreaterThanOrEqual => $"{filter.Field}>={value}",
                FilterOperator.LessThan => $"{filter.Field}<{value}",
                FilterOperator.LessThanOrEqual => $"{filter.Field}<={value}",
                FilterOperator.Not => $"-{filter.Field}:{value}",
                FilterOperator.None => $"{filter.Field}={value}",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private static string FormatValue(QueryFilter filter)
        {
            bool mustQuote = filter.Operator == FilterOperator.Equals && filter.Value.Contains(' ');
            bool isExactMatch = filter.Operator == FilterOperator.None;

            return mustQuote || isExactMatch
                ? $"\"{filter.Value}\""
                : filter.Value;
        }

        #endregion
    }
}
