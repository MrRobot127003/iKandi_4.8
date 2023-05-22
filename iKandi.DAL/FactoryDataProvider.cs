using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;

namespace iKandi.DAL
{
    public class FactoryDataProvider: BaseDataProvider
    {
        #region Ctor(s)

        public FactoryDataProvider(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

    }
}
