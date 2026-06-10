namespace IntegracaoVindi.Infrastructure.Options
{
    public class VindiOptions
    {
        #region Properties

        public bool SandBox { get; set; } = false;

        public string Uri { get; set; } = "https://app.vindi.com.br:443";

        #endregion 
    }
}
