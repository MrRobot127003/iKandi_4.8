using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using System.Data.SqlClient;
using System.Data;

namespace iKandi.BLL
{
    public class PermissionController : BaseController
    {
        #region Ctor(s)

        public PermissionController()
        {
        }

        public PermissionController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Permission methods

        public int SavePermission(Permission objPermission)
        {
            if (objPermission.PermissionId == -1)
            {
                return this.PermissionDataProviderInstance.InsertPermission(objPermission);

            }
            else
            {
                return this.PermissionDataProviderInstance.UpdatePermission(objPermission);

            }

            //return -1;

        }

        public List<Permission> GetPermissionByUser(int UserID)
        {
            return this.PermissionDataProviderInstance.GetPermissionByUser(UserID);
        }

        public List<Permission> GetPermissionByDesignation(int DesignationID)
        {
            return this.PermissionDataProviderInstance.GetPermissionByDesignation(DesignationID);
        }

        public List<Permission> GetPermissionByDepartment(int DepartmentID)
        {
            return this.PermissionDataProviderInstance.GetPermissionByDepartment(DepartmentID);
        }

        public List<Permission> GetColumnPermissionByUser(int UserID, int ApplicationModuleID)
        {
            return this.PermissionDataProviderInstance.GetColumnPermissionByUser(UserID, ApplicationModuleID);
        }

        public List<Permission> GetColumnPermissionByDesignation(int DesignationID, int ApplicationModuleID)
        {
            return this.PermissionDataProviderInstance.GetColumnPermissionByDesignation(DesignationID, ApplicationModuleID);
        }

        public List<Permission> GetColumnPermissionByDepartment(int DepartmentID, int ApplicationModuleID)
        {
            return this.PermissionDataProviderInstance.GetColumnPermissionByDepartment(DepartmentID, ApplicationModuleID);
        }


        #endregion


        public List<Permission> GetPermissions()
        {
            return this.PermissionDataProviderInstance.GetPermissions();
        }
        public DataTable GetDepartmentList()
        {

            return PermissionDataProviderInstance.GetDepartmentList();

        }
        public DataTable GetDesignationByDepartId(int DepartmentId)
        {

            return PermissionDataProviderInstance.GetDesignationByDepartId(DepartmentId);

        }


        public DataTable GetSectionList()
        {

            return PermissionDataProviderInstance.GetSectionList();

        }
        public DataTable GetColumnBySectionId(int SectionID)
        {

            return PermissionDataProviderInstance.GetColumnBySectionId(SectionID);

        }

        public DataTable GetSectionIdBySection(string SectionID)
        {

            return PermissionDataProviderInstance.GetSectionIdBySection(SectionID);

        }

        public DataTable GetColumnIdByColumn(string Column)
        {

            return PermissionDataProviderInstance.GetColumnIdByColumn(Column);

        }


        public void InsertMOpermissionSet(List<MOPermissionForm> MOPermissionList, int DesigID)
        {

            this.PermissionDataProviderInstance.InsertMOpermissionSet(MOPermissionList, DesigID);

        }

        public int InsertMOpermission(MOPermissionForm MOPermissionList)
        {

            return this.PermissionDataProviderInstance.InsertMOpermission(MOPermissionList);

        }
        //
        public void DeleteMoPermission(int DesignationId, int DepartmentId)
        {

            this.PermissionDataProviderInstance.DeleteMoPermission(DesignationId, DepartmentId);

        }
        public List<MOPermissionForm> GetMoPermissionList(int DesigId, int DeptId)
        {
            return PermissionDataProviderInstance.GetMoPermissionList(DesigId, DeptId);
        }


        public DataTable getPermission()
        {

            return PermissionDataProviderInstance.getPermission();

        }
        //added By Abhishek on 16/4/2015
        public DataTable GetOBSection()
        {

            return PermissionDataProviderInstance.GetOBSection();

        }

        public int SavePermissionByIds_OB(int DeptId, int DesigId, int FormsID, int SectionID, bool PermissionRead, bool PermissionWrite)
        {
            return PermissionDataProviderInstance.SavePermissionByIds_OB(DeptId, DesigId, FormsID, SectionID, PermissionRead, PermissionWrite);
        }
        public DataSet GetAllPermissionListById_For_OB(int DeptId, int DesigId, int sectionid, int columnId)//get All Permissione OB 
        {
            return PermissionDataProviderInstance.GetAllPermissionListById_OB(DeptId, DesigId, sectionid, columnId);
        }
        //Added By Ashish on 3/3/2015
        public DataTable GetMoSection()
        {

            return PermissionDataProviderInstance.GetMoSection();

        }
        //Gajendra Permission 
        #region New Permission 
        
        public DataSet GetNewMoSection(int Id)
        {
            return PermissionDataProviderInstance.GetNewMoSection(Id);
        }
        public DataSet GetNewTechnicalSection(int Id)
        {
            return PermissionDataProviderInstance.GetNewTechnicalSection(Id);
        }
        //added by raghvinder on 02-09-2020 start
        public DataSet GetUserPermission(int DeptId, int DesignationID, int MainFormID)
        {
            return PermissionDataProviderInstance.GetUserPermission(DeptId, DesignationID, MainFormID);
        }
        //added by raghvinder on 02-09-2020 start

        //added by raghvinder on 08-09-2020 start
        public DataSet GetMMRPermission(int DeptId, int DesignationID, int ApplicationModuleID)
        {
            return PermissionDataProviderInstance.GetMMRPermission(DeptId, DesignationID, ApplicationModuleID);
        }

        public DataSet GetSOPPermission(int DeptId, int DesignationID, int ColumId)
        {
            return PermissionDataProviderInstance.GetSOPPermission(DeptId, DesignationID, ColumId);
        }

        //ADDED BY RAGHVINDER ON 29-01-2021 START
        public DataSet GetAccessoryFourPointCheckPermission(int DeptId, int DesignationID, int ColumId)
        {
            return PermissionDataProviderInstance.GetAccessoryFourPointCheckPermission(DeptId, DesignationID, ColumId);
        }
        //ADDED BY RAGHVINDER ON 29-01-2021 END

        public DataSet GetLoginActivate(int UserID)
        {
            return PermissionDataProviderInstance.GetLoginActivate(UserID);
        }
        //added by raghvinder on 08-09-2020 start

        public DataSet GetNewAllPermissionList_OB(int DeptId, int DesigId, int sectionid, int columnId)
        {
            return PermissionDataProviderInstance.GetNewAllPermissionList_OB(DeptId, DesigId, sectionid, columnId);
        }
        public int SaveOBPermissionNew(int DeptId, int DesigId, int FormsID, int SectionID, bool PermissionRead, bool PermissionWrite)
        {
            return PermissionDataProviderInstance.SaveOBPermissionNew(DeptId, DesigId, FormsID, SectionID, PermissionRead, PermissionWrite);
        }
        public List<Permission> GetPermissionsNew()
        {
            return this.PermissionDataProviderInstance.GetPermissionsNew();
        }
        #endregion
        public DataTable GetMoDesignation(int Id)
        {

            return PermissionDataProviderInstance.GetMoDesignation(Id);

        }
        public int GetMoDeptcount(int Id)
        {

            return PermissionDataProviderInstance.GetMoDeptcount(Id);

        }

        public int GetMoSectionId(int Id)
        {

            return PermissionDataProviderInstance.GetMoSectionId(Id);

        }
        //
        //public DataTable GetAllPermissionList()
        //{

        //    return PermissionDataProviderInstance.GetAllPermissionList();

        //}

        public DataSet GetAllPermissionListById(int DeptId, int DesigId, int sectionid, int columnId)
        {
            return PermissionDataProviderInstance.GetAllPermissionListById(DeptId, DesigId, sectionid, columnId);
        }

        public int SavePermissionByIds(int DeptId, int DesigId, int SectionId, int ColumnId, bool PermissionRead, bool PermissionWrite)
        {
            return PermissionDataProviderInstance.SavePermissionByIds(DeptId, DesigId, SectionId, ColumnId, PermissionRead, PermissionWrite);
        }

        public int SaveAllPermissionByIds(int DeptId, int DesigId, bool PermissionRead, bool PermissionWrite)
        {
            return PermissionDataProviderInstance.SaveAllPermissionByIds(DeptId, DesigId, PermissionRead, PermissionWrite);
        }
        // update By Ravi kumar on 29/10/16 from M.O filter Permission
        public int SaveMO_OrderByFilter(int DeptId, int DesigId, int OrderBy, int Flag)
        {
            return PermissionDataProviderInstance.SaveMO_OrderByFilter(DeptId, DesigId, OrderBy, Flag);
        }

        public DataTable GetFilterPermissionById(int DeptId, int DesigId)
        {
            return PermissionDataProviderInstance.GetFilterPermissionById(DeptId, DesigId);
        }
        public DataTable GetMoDesignationgrd1(int Id)
        {

            return PermissionDataProviderInstance.GetMoDesignationgrd1(Id);

        }

        public string GetStatusByOrderId(int OrderId)
        {
            return this.PermissionDataProviderInstance.GetStatusByOrderId(OrderId);
        }

        public int IsOrderConfirm(int OrderId)
        {
            return this.PermissionDataProviderInstance.IsOrderConfirm(OrderId);
        }
    }
}
