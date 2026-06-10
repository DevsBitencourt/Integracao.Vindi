namespace IntegracaoVindi.Services.Models
{
    /// <summary>
    /// Represents the result of a Vindi API operation.
    /// </summary>
    /// <typeparam name="T">Type of the returned data.</typeparam>
    public class Response<T>
    {
        #region Properties

        /// <summary>Indicates whether the operation succeeded.</summary>
        public bool Success { get; set; }

        /// <summary>Error description when <see cref="Success"/> is <c>false</c>.</summary>
        public string? Error { get; set; }

        /// <summary>Deserialized response data when <see cref="Success"/> is <c>true</c>.</summary>
        public T? Data { get; set; }

        #endregion
    }
}
