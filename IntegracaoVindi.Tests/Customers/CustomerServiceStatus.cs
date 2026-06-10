namespace IntegracaoVindi.Tests.Customers
{
    internal enum CustomerServiceStatus : byte
    {
        #region Values

        Unknown = 0,
        GetAll_Success = 1,
        GetById_WhenSuccess = 2,
        Delete_WhenSuccess = 3,

        #endregion
    }
}
