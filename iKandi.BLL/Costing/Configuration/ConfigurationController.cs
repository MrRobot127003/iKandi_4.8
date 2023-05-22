using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;

namespace iKandi.BLL
{
    public class ConfigurationController : BaseController
    {
        #region

        public ConfigurationController()
        {
        }

        public ConfigurationController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion
    }
}
