using System.Collections.ObjectModel;

namespace IntegracaoVindi.Services.Filters
{
    internal abstract class FilterBase
    {
        #region Properties

        protected Collection<QueryFilter> Filters { get; set; } = [];

        #endregion

        #region Public Methods

        public virtual QueryFilter[] ToFilters()
        {
            return [.. Filters];
        }

        #endregion

    }
}