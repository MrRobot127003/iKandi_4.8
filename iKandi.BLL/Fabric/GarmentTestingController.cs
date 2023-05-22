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
    public class GarmentTestingController : BaseController
    {
        public GarmentTestingController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        public List<GarmentTesting> GetGarmentTesting(int StyleNumber)
        {
            return this.FITsDataProviderInstance.GetGarmentTesting(StyleNumber);
        }

        public GarmentTesting CreateGarmentTesting(GarmentTesting garmentTesting)
        {
            return this.FITsDataProviderInstance.CreateGarmentTesting(garmentTesting);
        }

        public GarmentTesting UpdateGarmentTesting(GarmentTesting garmentTesting)
        {
            return this.FITsDataProviderInstance.UpdateGarmentTesting(garmentTesting);
        }

    }
}

