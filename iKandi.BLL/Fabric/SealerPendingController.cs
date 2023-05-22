using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using System.Web.Security;
using iKandi.BLL.Security;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.BLL
{
    public class SealerPendingController : BaseController
    {
        public SealerPendingController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        public SealerPending GetSealerPendingInfo(string styleNumber, int departmentId)
        {
            return this.FITsDataProviderInstance.GetSealerPendingInfo(styleNumber, departmentId);
        }        
    }
}
