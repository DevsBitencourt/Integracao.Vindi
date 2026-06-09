namespace IntegracaoVindi.Services.Enums
{
    /// <summary>
    /// Comparison operators available for query filters.
    /// </summary>
    public enum FilterOperator : byte
    {
        #region Values

        /// <summary>Partial match (field:value).</summary>
        Contains,

        /// <summary>Exact match (field=value).</summary>
        Equals,

        /// <summary>Greater than (field>value).</summary>
        GreaterThan,

        /// <summary>Greater than or equal (field>=value).</summary>
        GreaterThanOrEqual,

        /// <summary>Less than (field&lt;value).</summary>
        LessThan,

        // <summary>Less than or equal (field&lt;=value).</summary>
        LessThanOrEqual,

        /// <summary>Negation (-field:value).</summary>
        Not,

        /// <summary>Quoted exact match ("value").</summary>
        None

        #endregion
    }
}
