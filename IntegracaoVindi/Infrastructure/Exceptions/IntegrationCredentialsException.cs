namespace IntegracaoVindi.Infrastructure.Exceptions
{
    internal class IntegrationCredentialsException : IntegrationException
    {
        #region Properties

        public string? ParameterName { get; }

        #endregion

        #region Constructors

        public IntegrationCredentialsException()
            : base("Credentials not provided") { }

        public IntegrationCredentialsException(string message)
            : base(message) { }

        public IntegrationCredentialsException(string message, string parameterName)
            : base(message)
        {
            ParameterName = parameterName;
        }

        #endregion
    }
}
