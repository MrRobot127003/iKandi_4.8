using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using System.Data;

namespace iKandi.BLL
{
    public class DepartmentController: BaseController
    {
        #region

        public DepartmentController()
        {
        }

        public DepartmentController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion
        public List<Department> GetDepartmentsByCompany_new(int CompanyID)
        {
          return this.DepartmentDataProviderInstance.GetDepartmentsByCompany_new(CompanyID);
        }
        public List<Department> GetDepartmentsByCompany(int CompanyID)
        {
          return this.DepartmentDataProviderInstance.GetDepartmentsByCompany(CompanyID);
        }
        public List<Department> GetSerialNumber(string StyleNumber)
        {
            return this.DepartmentDataProviderInstance.GetSerialNumber(StyleNumber);
        }
        public List<Department> GetPrintColorQty(int OrderID)
        {
            return this.DepartmentDataProviderInstance.GetPrintColorQty(OrderID);
        }
        public DataTable GetSerialNumbercluster(string StyleNumber)
        {
            return this.DepartmentDataProviderInstance.GetSerialNumbercluster(StyleNumber);
        }
        public DataTable GetPrintColorQtycluster(int OrderID)
        {
            return this.DepartmentDataProviderInstance.GetPrintColorQtycluster(OrderID);
        }
        public string Getfinishingsam(int OrderdetailsID = 0, int OrderID = 0, int UnitID = 0, string Flag = "")
        {
            return this.DepartmentDataProviderInstance.Getfinishingsam(OrderdetailsID, OrderID, UnitID, Flag);
        }
        //public string getUsp_GetOderID(int flag, string serialNumber = "")
        //{
        //    return this.DepartmentDataProviderInstance.getUsp_GetOderID(flag, serialNumber);
        //}
        public List<Department> getUsp_GetOderID(string flag, string serialNumber = "")
        {
            return this.DepartmentDataProviderInstance.getUsp_GetOderID(flag,  serialNumber);
        }
        public List<Department> getUsp_GetOderIDnew(string flag, string serialNumber = "")
        {
            return this.DepartmentDataProviderInstance.getUsp_GetOderIDnew(flag, serialNumber);
        }
        //public string getUsp_GetOderIDd_new(string flag, string StyleNumber)
        //{
        //    return this.DepartmentControllerInstance.getUsp_GetOderIDd_new(flag, StyleNumber);

        //}
        public string ValidateFactoryWorkSpace(string FactoryWorkSpace)
        {
          return this.DepartmentDataProviderInstance.ValidateFactoryWorkSpace(FactoryWorkSpace);
        }
        
    }
}
