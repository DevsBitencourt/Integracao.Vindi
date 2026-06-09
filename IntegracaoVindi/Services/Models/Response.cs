namespace IntegracaoVindi.Services.Models
{
    public class Response<T>
    {
        #region Properties

        public bool Success { get; set; }
        public string? Error { get; set; }
        public T? Data { get; set; }

        #endregion
    }
}
