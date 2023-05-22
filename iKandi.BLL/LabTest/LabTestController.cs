using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.DAL;
using iKandi.Common;
using System.Data;

namespace iKandi.BLL
{
    public class LabTestController : BaseController
    {
        #region

        public LabTestController()
        {
        }

        public LabTestController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Methods

        public iKandi.Common.LabTest GetBasicInformationByOrderDetailId(int OrderDetailID)
        {
            return this.LabTestDataProviderInstance.GetBasicInformationByOrderDetailId(OrderDetailID);
        }

        public iKandi.Common.LabTest GetLabTestDataByLabTestId(int LabTestID)
        {
            return this.LabTestDataProviderInstance.GetLabTestDataById(LabTestID);
        }

        public bool Save(LabTest LabTest)
        {
            this.LabTestDataProviderInstance.SaveLabTest(LabTest);         

            return true;
        }

        public List<LabTest> GetBulkOrGarmetTestPendingEmail()
        {
            return this.LabTestDataProviderInstance.GetBulkOrGarmetTestPendingEmail();
        }
       //
       // public DataTable GetNotificationTask3(int id)
       // {
       //     //return this.LabTestDataProviderInstance.GetNotificationTask(id);
       // }
        //
        #endregion

    }
}
