namespace IntegracaoVindi.Services.Enums
{
    /// <summary>
    /// Logical operators for combining multiple query filters.
    /// </summary>
    public enum ConditionalOperator : byte
    {
        #region Values

        /// <summary>All conditions must match.</summary>
        And,

        /// <summary>At least one condition must match.</summary>
        Or

        #endregion
    }
}
