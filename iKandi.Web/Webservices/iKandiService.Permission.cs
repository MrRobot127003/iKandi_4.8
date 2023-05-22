using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using System.Collections.Generic;
using iKandi.Common;
using iKandi.BLL;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class iKandiService
    {
        [WebMethod(EnableSession = true)]
        public int SavePermission(int permissionId, int userId, int designationId, bool read, bool write, int applicationModuleId, int applicationModuleColumnId, int departmentId)
        {
            iKandi.Common.Permission objPermission = new iKandi.Common.Permission();
            objPermission.PermissionId = permissionId;
            objPermission.UserID = userId;
            objPermission.DesignationID = designationId;
            objPermission.Read = read;
            objPermission.Write = write;
            objPermission.ApplicationModuleID = applicationModuleId;
            objPermission.ApplicationModuleColumnID = applicationModuleColumnId;
            objPermission.DepartmentID = departmentId;
            int success = this.PermissionControllerInstance.SavePermission(objPermission);

            // Invalidate Permission in Cache
            ApplicationHelper.ClearPermissions();

            return success;
        }

        [WebMethod(EnableSession = true)]
        public List<MOPermissionForm> GetMoPermissionList(int DesigId, int DeptId)
        {
            PermissionController obj_MOPermissionForm = new PermissionController();
            return obj_MOPermissionForm.GetMoPermissionList(DesigId, DeptId);


        }

        [WebMethod(EnableSession = true)]
        public int SavePermissionByIds(int DeptId, int DesigId, int SectionId, int ColumnId, bool PermissionRead, bool PermissionWrite)
        {
            PermissionController obj_MOPermissionForm = new PermissionController();
            return obj_MOPermissionForm.SavePermissionByIds(DeptId, DesigId, SectionId, ColumnId, PermissionRead, PermissionWrite);


        }

        [WebMethod(EnableSession = true)]
        public int SaveAllPermissionByIds(int DeptId, int DesigId, bool PermissionRead, bool PermissionWrite)
        {
            PermissionController obj_MOPermissionForm = new PermissionController();
            return obj_MOPermissionForm.SaveAllPermissionByIds(DeptId, DesigId, PermissionRead, PermissionWrite);
        }
        // Update By Ravi kumar on 29/10/16 from M.O filter Permission
        [WebMethod(EnableSession = true)]
        public int SaveMO_OrderByFilter(int DeptId, int DesigId, int OrderBy, int Flag)
        {
            PermissionController obj_MOPermissionForm = new PermissionController();
            return obj_MOPermissionForm.SaveMO_OrderByFilter(DeptId, DesigId, OrderBy, Flag);


        }
        //Added By Abhishek 20/4/2015 for OB Admin
        [WebMethod(EnableSession = true)]
        public int SaveOBPermission(int DeptId, int DesigId, int FormsID, int SectionID, bool PermissionRead, bool PermissionWrite)
        {
            PermissionController obj_MOPermissionForm = new PermissionController();
            return obj_MOPermissionForm.SavePermissionByIds_OB(DeptId, DesigId, FormsID, SectionID, PermissionRead, PermissionWrite);
        }

        //Gajendra Permission 
        [WebMethod(EnableSession = true)]
        public int SaveOBPermissionNew(int DeptId, int DesigId, int FormsID, int SectionID, bool PermissionRead, bool PermissionWrite)
        {
            PermissionController obj_MOPermissionForm = new PermissionController();
            return obj_MOPermissionForm.SaveOBPermissionNew(DeptId, DesigId, FormsID, SectionID, PermissionRead, PermissionWrite);
        }
    }
}