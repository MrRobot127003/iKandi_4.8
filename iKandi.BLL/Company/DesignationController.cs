using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;

namespace iKandi.BLL
{
    public class DesignationController: BaseController
    {
        #region

        public DesignationController()
        {
        }

        public DesignationController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion
        public List<UserDesignation> GetDesignationsByDepartment(int DepartmentID)
        {
            // TODO: Implement Cache
            return this.DesignationDataProviderInstance.GetDesignationsByDepartment(DepartmentID);
        }
        public List<UserDesignation> GetDesignationsByDepartment_new(int DepartmentID)
        {
          
          return this.DesignationDataProviderInstance.GetDesignationsByDepartment_new(DepartmentID);
        }
    }
}
