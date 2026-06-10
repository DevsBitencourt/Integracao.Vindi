using System;

namespace IntegracaoVindi.Infrastructure.Options
{
    public class VindiOptions
    {
        #region Properties

        public VindiOptionOperator Environment { get; set; } = VindiOptionOperator.Production;

        public string BaseUri { get => GetUri(); }

        #endregion

        #region Internal Methods

        internal string GetUri()
        {
            return Environment switch
            {
                VindiOptionOperator.Production => "https://app.vindi.com.br:443",
                VindiOptionOperator.Sandbox or VindiOptionOperator.Fake => "https://sandbox.vindi.com.br",
                _ => throw new NotImplementedException(),
            };
        }

        #endregion
    }
}
