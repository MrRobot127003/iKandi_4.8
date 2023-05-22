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
using iKandi.Common;

namespace iKandi.Web.Components
{
    public class PermissionHelper
    {
       
        /* Utkarsh: Commented on 31th May, 2010. these methods not required.
         
        public static bool IsReadPermitted(User user, int ApplicationID)
        {
            ApplicationModule appModule = ApplicationHelper.ApplicationModules.Find(delegate(ApplicationModule am)
            {
                return (am.ApplicationModuleID == ApplicationID);
            });

            bool isSetup = appModule.SubPhaseID == (int)SubPhase.SETUP;
            bool isAdmin = Roles.IsUserInRole(ApplicationHelper.LoggedInUser.UserData.Username, Role.Admin.ToString());

            if (isAdmin)
                return true;
            else if (IsTopManagement() && isSetup)
                return false;
            else if (IsTopManagement() && !isSetup)
                return true;

            iKandi.Common.Permission permission = GetUserPermission(user, ApplicationID);

            if (permission != null && (permission.Read == true || permission.Write == true))
                return true;
            else
                return (IsAdditionalTopManagement() && !isSetup);
        }

        public static bool IsWritePermitted(User user, int ApplicationID)
        {
            ApplicationModule appModule = ApplicationHelper.ApplicationModules.Find(delegate(ApplicationModule am)
            {
                return (am.ApplicationModuleID == ApplicationID);
            });

            bool isSetup = appModule.SubPhaseID == (int)SubPhase.SETUP;
            bool isAdmin = Roles.IsUserInRole(ApplicationHelper.LoggedInUser.UserData.Username, Role.Admin.ToString());

            if (isAdmin && isSetup)
                return true;
            else if (isAdmin && !isSetup)
                return false;
            else if (IsTopManagement())
                return false;

            iKandi.Common.Permission permission = GetUserPermission(user, ApplicationID);

            if (permission != null && (permission.Write == true))
                return true;
            else
                return false;
        }
        */

        public static bool IsReadPermittedOnColumn(User user, int ApplicationColumnID)
        {
            //if (IsTopManagement())
            //    return true;

            iKandi.Common.Permission permission = GetUserPermissionOnColumn(user, ApplicationColumnID);

            if (permission != null && (permission.Read == true || permission.Write == true))
                return true;
            else
                return false;
        }

        public static bool IsWritePermittedOnColumn(User user, int ApplicationColumnID)
        {
            //if (IsTopManagement())
            //    return false;

            iKandi.Common.Permission permission = GetUserPermissionOnColumn(user, ApplicationColumnID);

            if (permission != null && (permission.Write == true))
                return true;
            else
                return false;
        }
        public static bool IsExfactoryWritePermittedOnColumn(int ApplicationColumnID)
        {
             iKandi.BLL.OrderController oc = new iKandi.BLL.OrderController();
          

            bool PermissionExfactory = false;
            PermissionExfactory = oc.ExfactoryPermission(ApplicationHelper.LoggedInUser.UserData.UserID, ApplicationColumnID);
            if(PermissionExfactory==true)
                return true;
            else
                return false;

            //iKandi.Common.Permission permission = GetUserPermissionOnColumn(user, ApplicationColumnID);

            //if (permission != null && (permission.Write == true))
            //    return true;
            //else
            //    return false;
        }


        public static bool IsReadPermitted(int ApplicationID) // NTD
        {

            if (ApplicationHelper.LoggedInUser.UserData == null)
                return false;

            ApplicationModule appModule = ApplicationHelper.ApplicationModules.Find(delegate(ApplicationModule am)
            {
                return (am.ApplicationModuleID == ApplicationID);
            });

            bool isSetup = true;
            bool isAdmin = Roles.IsUserInRole(ApplicationHelper.LoggedInUser.UserData.Username, Role.Admin.ToString());

            if (isAdmin)
                return true;
            else if (IsTopManagement() && isSetup)
                return false;
            else if (IsTopManagement() && !isSetup)
                return true;

            iKandi.Common.Permission permission = GetUserPermission(ApplicationHelper.LoggedInUser.UserData, ApplicationID);

            if (permission != null && (permission.Read == true || permission.Write == true))
                return true;
            else
                return (IsAdditionalTopManagement() && !isSetup);
        }

        public static bool IsWritePermitted(int ApplicationID)
        {
            if (ApplicationHelper.LoggedInUser.UserData == null)
                return false;

            //if (IsTopManagement())
            //    return false;

            iKandi.Common.Permission permission = GetUserPermission(ApplicationHelper.LoggedInUser.UserData, ApplicationID);

            if (permission != null && (permission.Write == true))
                return true;
            else
                return false;
        }

        public static bool IsReadPermittedOnColumn(int ApplicationColumnID)
        {
            if (ApplicationHelper.LoggedInUser.UserData == null)
                return false;

            //if (IsTopManagement())
            //    return true;

            iKandi.Common.Permission permission = GetUserPermissionOnColumn(ApplicationHelper.LoggedInUser.UserData, ApplicationColumnID);

            if (permission != null && (permission.Read == true || permission.Write == true))
                return true;
            else
                return false;
        }
        //added by abhishek for hide filed visibility---
        public static bool IsVisiblePermittedOnColumn(int ApplicationColumnID) 
        {
            if (ApplicationHelper.LoggedInUser.UserData == null)
                return false;

            //if (IsTopManagement())
            //    return false;

            iKandi.Common.Permission permission = GetUserPermissionOnColumn(ApplicationHelper.LoggedInUser.UserData, ApplicationColumnID);

            if (permission == null || (permission.Read == true))
                return false;
            else 
                return true;
            
                
        }
        //edn 

        public static bool IsWritePermittedOnColumn(int ApplicationColumnID)
        {
            if (ApplicationHelper.LoggedInUser.UserData == null)
                return false;

            //if (IsTopManagement())
            //    return false;

            iKandi.Common.Permission permission = GetUserPermissionOnColumn(ApplicationHelper.LoggedInUser.UserData, ApplicationColumnID);

            if (permission != null && (permission.Write == true))
                return true;
            else
                return false;
        }

        public static bool IsWritePermittedOnAnyColumn(int ApplicationID)// NTD
        {
            if (ApplicationHelper.LoggedInUser.UserData == null)
                return false;

            ApplicationModule appModule = ApplicationHelper.ApplicationModules.Find(delegate(ApplicationModule am)
            {
                return (am.ApplicationModuleID == ApplicationID);
            });

            bool isSetup = appModule.SubPhaseID == (int)SubPhase.SETUP;
            bool isAdmin = Roles.IsUserInRole(ApplicationHelper.LoggedInUser.UserData.Username, Role.Admin.ToString());

            if (isAdmin && isSetup)
                return true;
            else if (isAdmin && !isSetup)
                return false;
            else if (IsTopManagement() && isSetup)
                return false;
            else if (IsTopManagement() && !isSetup)
                return false;

            if (appModule == null)
                return true;

            foreach (ApplicationModuleColumn column in appModule.Columns)
            {
                iKandi.Common.Permission permission = GetUserPermissionOnColumn(ApplicationHelper.LoggedInUser.UserData, column.ApplicationModuleColumnID);

                if (permission != null && permission.Write == true)
                    return true;
            }

            return false;
        }

        public static bool IsTopManagement() // NTD
        {
            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_TopManagement_Manager
                || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_TopManagement_Manager)
                return true;

            return false;
        }

        public static bool IsAdditionalTopManagement() // NTD
        {
            if (ApplicationHelper.LoggedInUser.UserData.AdditionalGroups != null && ApplicationHelper.LoggedInUser.UserData.AdditionalGroups.Exists(delegate(int deptID)
            {
                return (deptID == (int)Group.BIPL_TopManagement || deptID == (int)Group.iKandi_TopManagement);
            }))
            {
                return true;
            }

            return false;
        }

        #region Private Methods
        //Gajendra Permission
        private static iKandi.Common.Permission GetUserPermission(User user, int ApplicationID)
        {

            iKandi.Common.Permission permission = ApplicationHelper.Permissions.Find(
               delegate(iKandi.Common.Permission perm)
               {
                   return (perm.ApplicationModuleID == ApplicationID &&
                        perm.DepartmentID == user.PrimaryGroupID && perm.DesignationID == user.DesignationID);
               });
            return permission;

            #region Gajendra
            //iKandi.Common.Permission permission = ApplicationHelper.Permissions.Find(
            //    delegate(iKandi.Common.Permission perm)
            //    {
            //        return (perm.ApplicationModuleID == ApplicationID &&
            //            perm.UserID == user.UserID && (perm.PermissionType == 1 || perm.PermissionType == 2));
            //    });

            //if (permission == null)
            //    permission = ApplicationHelper.Permissions.Find(
            //    delegate(iKandi.Common.Permission perm)
            //    {
            //        return (perm.ApplicationModuleID == ApplicationID &&
            //            perm.DesignationID == user.DesignationID && (perm.PermissionType == 1 || perm.PermissionType == 2));
            //    });

            //if (permission == null)
            //    permission = ApplicationHelper.Permissions.Find(
            //    delegate(iKandi.Common.Permission perm)
            //    {
            //        if (perm.ApplicationModuleID == ApplicationID && perm.DepartmentID == user.PrimaryGroupID && (perm.PermissionType == 1 || perm.PermissionType == 2))
            //            return true;

            //        if (user.AdditionalGroups != null)
            //        {
            //            foreach (int deptID in user.AdditionalGroups)
            //            {
            //                if (perm.ApplicationModuleID == ApplicationID && perm.DepartmentID == deptID && (perm.PermissionType == 1 || perm.PermissionType == 2))
            //                    return true;
            //            }
            //        }

            //        return false;
            //    });
            #endregion

        }
        //Gajendra Permission
        private static iKandi.Common.Permission GetUserPermissionOnColumn(User user, int ApplicationColumnID)
        {
            iKandi.Common.Permission permission = ApplicationHelper.Permissions.Find(
                delegate(iKandi.Common.Permission perm)
                {
                    return (perm.ApplicationModuleColumnID == ApplicationColumnID &&
                         perm.DepartmentID == user.PrimaryGroupID && perm.DesignationID == user.DesignationID);
                });

            return permission;

            #region Gajendra
            //iKandi.Common.Permission permission = ApplicationHelper.Permissions.Find(
            //    delegate(iKandi.Common.Permission perm)
            //    {
            //        return (perm.ApplicationModuleColumnID == ApplicationColumnID &&
            //            perm.UserID == user.UserID);
            //    });

            //if (permission == null)
            //    permission = ApplicationHelper.Permissions.Find(
            //    delegate(iKandi.Common.Permission perm)
            //    {
            //        return (perm.ApplicationModuleColumnID == ApplicationColumnID &&
            //            perm.DesignationID == user.DesignationID);
            //    });

            //if (permission == null)
            //    permission = ApplicationHelper.Permissions.Find(
            //    delegate(iKandi.Common.Permission perm)
            //    {
            //        if (perm.ApplicationModuleColumnID == ApplicationColumnID && perm.DepartmentID == user.PrimaryGroupID)
            //            return true;

            //        if (user.AdditionalGroups != null)
            //        {
            //            foreach (int deptID in user.AdditionalGroups)
            //            {
            //                if (perm.ApplicationModuleColumnID == ApplicationColumnID && perm.DepartmentID == deptID)
            //                    return true;
            //            }
            //        }

            //        return false;
            //    });

            #endregion
        }
        #endregion      
    }
}
