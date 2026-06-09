using IntegracaoVindi.Services.Vindi.Enums;
using System.Collections.Generic;

namespace IntegracaoVindi.Services.Vindi.Helpers
{
    internal static class RouteHelper
    {
        #region Properties

        private static readonly IDictionary<VindiRoute, string> _routes =
            new Dictionary<VindiRoute, string>
            {
                { VindiRoute.Customers, "api/v1/customers" }
            };

        #endregion

        #region Methods

        internal static string GetPath(VindiRoute route) => _routes[route];

        #endregion
    }
}
