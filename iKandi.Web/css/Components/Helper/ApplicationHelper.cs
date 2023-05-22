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
using System.Collections.Generic;
using iKandi.BLL;
using System.Web.Caching;
using System.Collections;
using System.Data;
using iKandi.BLL.CmtAdmin;

namespace iKandi.Web.Components
{
    public class ApplicationHelper
    {
        #region Properties
        public static decimal IGST { get; set; }
        public static decimal CGST { get; set; }
        public static decimal SGST { get; set; } 
        public static SessionInfo LoggedInUser
        {
            get
            {
                try
                {
                    SessionInfo info = HttpContext.Current.Session["UserInfo"] as SessionInfo;
                    return info;
                }
                catch
                {
                    SessionInfo info = new SessionInfo();
                    info.UserData = new User();
                    info.UserData.UserID = 13;
                    info.UserData.DesignationID = (int)Designation.BIPL_Sales_Manager;
                    info.UserData.DesignationID = (int)Designation.iKandi_Design_Designers;
                    info.UserData.Username = "Samrat";
                    
                   // HttpContext.Current.Response.Redirect("~/public/Login.aspx", true);
                    return info;

                }

                //SessionInfo info = HttpContext.Current.Session["UserInfo"] as SessionInfo;
                 //// TODO, just to test
                //if (info == null)
                //{
                //    info = new SessionInfo();
                //    info.UserData = new User();
                //    info.UserData.UserID = 13;
                //    info.UserData.DesignationID = (int)Designation.BIPL_Sales_Manager;
                //    //info.UserData.DesignationID = (int)Designation.iKandi_Design_Designers;
                //}

                //return info;
            }
            set
            {
                HttpContext.Current.Session["UserInfo"] = value;
            }
        }

        public static bool IsPrintRequest
        {
            get
            {
                return ( HttpContext.Current.Session["IsPrintRequest"] == null) ? false : true;
            }
            set
            {
                HttpContext.Current.Session["IsPrintRequest"] = value;
            }
        
        }
        //added by abhishek on 15/jan
        public void  GetCms()
        {
            CmtAdminController obj_CmtAdmin = new CmtAdminController();
            DataTable dtCmt = new DataTable();
           
            if (HttpRuntime.Cache["CMT"] == null)
            {
                HttpRuntime.Cache.Insert("CMT", obj_CmtAdmin.GetCmt(), null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
            }
            dtCmt = (DataTable)HttpRuntime.Cache["CMT"];

            IGST = Convert.ToDecimal(dtCmt.Rows[0]["CGST"].ToString());
            IGST = Convert.ToDecimal(dtCmt.Rows[0]["IGST"].ToString());
            SGST = Convert.ToDecimal(dtCmt.Rows[0]["SGST"].ToString());

        }

        
        public static List<iKandi.Common.Permission> Permissions
        {
            get
            {
                PermissionController controller = new PermissionController();
                if (HttpRuntime.Cache["PERMISSION"] == null)
                {                  
                    HttpRuntime.Cache.Insert("PERMISSION", controller.GetPermissionsNew(), null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);//Gajendra Permission 
                }
                //return (controller.GetPermissionsNew() as List<iKandi.Common.Permission>); 
                return (HttpRuntime.Cache["PERMISSION"] as List<iKandi.Common.Permission>); //Need to remove this comments for deployment
                
            }
        }

        public static WorkFlowPhaseCollection Phases
        {
            get
            {
                if (HttpRuntime.Cache["WORKFLOWPHASE"] == null)
                {
                    AdminController controller = new AdminController();


                    //if (ApplicationHelper.LoggedInUser.UserData != null)

                    //   //int DeptID = ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID;


                    HttpRuntime.Cache.Insert("WORKFLOWPHASE", controller.GetPhases(ApplicationHelper.LoggedInUser.UserData.UserID), null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }

                return (HttpRuntime.Cache["WORKFLOWPHASE"] as WorkFlowPhaseCollection);
            }
        }

        public static List<ApplicationModule> ApplicationModules
        {
            get
            {
                if (HttpRuntime.Cache["APPLICATIONMODULE"] == null)
                {
                    AdminController controller = new AdminController();
                    HttpRuntime.Cache.Insert("APPLICATIONMODULE", controller.GetAllApplicationModule(), null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }

                return (HttpRuntime.Cache["APPLICATIONMODULE"] as List<ApplicationModule>);
            }
        }

        public static List<User> Users
        {
            get
            {
                if (HttpRuntime.Cache["APPLICATIONUSERS"] == null)
                {
                    UserController controller = new UserController();
                    HttpRuntime.Cache.Insert("APPLICATIONUSERS", controller.GetAllUsers(), null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }

                return (HttpRuntime.Cache["APPLICATIONUSERS"] as List<User>);
            }
        }
        //added by abhishek 26/10/2019
        public static List<User> UsersAll
        {
            get
            {
                if (HttpRuntime.Cache["APPLICATIONUSERSALL"] == null)
                {
                    UserController controller = new UserController();
                    HttpRuntime.Cache.Insert("APPLICATIONUSERSALL", controller.GetAllUsersALL(), null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }

                return (HttpRuntime.Cache["APPLICATIONUSERSALL"] as List<User>);
            }
        }
        public static AllocationCollection AllocatedUnitData
        {
            get
            {
                //if (HttpRuntime.Cache["ALLOCATEDUNITDATA"] == null)
                //{
                    AllocationController controller = new AllocationController();
                    HttpRuntime.Cache.Insert("ALLOCATEDUNITDATA", controller.AllocatedUnitData(), null, DateTime.Now.AddMinutes(15), System.Web.Caching.Cache.NoSlidingExpiration);
                //}

                return (HttpRuntime.Cache["ALLOCATEDUNITDATA"] as AllocationCollection);
            }
        }

        public DataSet GetlandingpageandDesgination(int Departid, int desginationid, int UserId, int FromLogin)
        {
            //if (HttpRuntime.Cache["LANDINGPAGE"] == null)
            //{

            //    DataSet ds = new DataSet();
            //    WorkflowController objWorkflowController = new WorkflowController();
            //    ds = objWorkflowController.GetGlobalandlanding(Departid, desginationid);

            //    HttpRuntime.Cache.Insert("LANDINGPAGE", objWorkflowController.GetGlobalandlanding(Departid, desginationid), null, DateTime.Now.AddMinutes(20), System.Web.Caching.Cache.NoSlidingExpiration);
            //}

            //return (HttpRuntime.Cache["LANDINGPAGE"] as DataSet);

            DataSet ds = new DataSet();
            WorkflowController objWorkflowController = new WorkflowController();

            ds = objWorkflowController.GetGlobalandlanding(Departid, desginationid, UserId, FromLogin);

            return ds;     
           
        }



        public DataSet GetNotifactionRemarks(int desginationid, int TaskId, string type, int iUserId)
        {
            //if (HttpRuntime.Cache["LANDINGPAGE"] == null)
            //{

            //    DataSet ds = new DataSet();
            //    WorkflowController objWorkflowController = new WorkflowController();
            //    ds = objWorkflowController.GetGlobalandlanding(Departid, desginationid);

            //    HttpRuntime.Cache.Insert("LANDINGPAGE", objWorkflowController.GetGlobalandlanding(Departid, desginationid), null, DateTime.Now.AddMinutes(20), System.Web.Caching.Cache.NoSlidingExpiration);
            //}

            //return (HttpRuntime.Cache["LANDINGPAGE"] as DataSet);

            DataSet ds = new DataSet();
            WorkflowController objWorkflowController = new WorkflowController();

            ds = objWorkflowController.GetNotifactionRemarks(desginationid, TaskId, type, iUserId);

            return ds;


        }




        public DataSet GetTaskCompletebyTask(int TaskId)
        {
            //if (HttpRuntime.Cache["LANDINGPAGE"] == null)
            //{

            //    DataSet ds = new DataSet();
            //    WorkflowController objWorkflowController = new WorkflowController();
            //    ds = objWorkflowController.GetGlobalandlanding(Departid, desginationid);

            //    HttpRuntime.Cache.Insert("LANDINGPAGE", objWorkflowController.GetGlobalandlanding(Departid, desginationid), null, DateTime.Now.AddMinutes(20), System.Web.Caching.Cache.NoSlidingExpiration);
            //}

            //return (HttpRuntime.Cache["LANDINGPAGE"] as DataSet);

            DataSet ds = new DataSet();
            WorkflowController objWorkflowController = new WorkflowController();

            ds = objWorkflowController.GetTaskCompletebyTask(TaskId);

            return ds;




        }


        private static Hashtable ProductionUnitColors
        {
            get
            {
                if (HttpRuntime.Cache["PRODUCTION_UNIT_COLORS"] == null)
                {
                    AllocationController controller = new AllocationController();
                    ProductionUnitCollection objProductionUnitCollection = controller.GetProductionUnits("%%");

                    Hashtable productionUnitColorsHashTable = new Hashtable();

                    foreach (ProductionUnit unit in objProductionUnitCollection)
                    {
                        productionUnitColorsHashTable.Add(unit.FactoryCode, unit.ProductionUnitColor);
                    }

                    HttpRuntime.Cache.Insert("PRODUCTION_UNIT_COLORS", productionUnitColorsHashTable, null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }

                return (HttpRuntime.Cache["PRODUCTION_UNIT_COLORS"] as Hashtable);
            }
        }

        #endregion

        #region Methods

        public static string GetUnitColor(string factoryCode)
        {
            return (null == ApplicationHelper.ProductionUnitColors[factoryCode]) ? "#FFFFFF" : ApplicationHelper.ProductionUnitColors[factoryCode].ToString();
        }
        
        public static void ClearProductionUnitColorsCache()
        {
            if (HttpRuntime.Cache["PRODUCTION_UNIT_COLORS"] != null)
                HttpRuntime.Cache.Remove("PRODUCTION_UNIT_COLORS");
        }

        public static void ClearUsersCache()
        {
            if (HttpRuntime.Cache["APPLICATIONUSERS"] != null)
                HttpRuntime.Cache.Remove("APPLICATIONUSERS");
        }

        public static ApplicationModule GetApplicationModuleIDByURL(string URL)
        {
            //System.Diagnostics.Debugger.Break();

            foreach (WorkflowPhase phase in ApplicationHelper.Phases)
            {
                foreach (WorkflowSubPhase subphase in phase.SubPhase)
                {
                    foreach (ApplicationModule appModule in subphase.Files)
                    {
                        if (URL.ToLower().IndexOf(appModule.Path.ToLower()) > -1)
                            return appModule;
                    }

                    foreach (ApplicationModule appModule in subphase.Forms)
                    {
                        if (URL.ToLower().IndexOf(appModule.Path.ToLower()) > -1)
                            return appModule;
                    }

                    foreach (ApplicationModule appModule in subphase.Reports)
                    { 
                        if (URL.ToLower().IndexOf(appModule.Path.ToLower()) > -1)
                            return appModule;
                    }
                }
            }

            return null;
        }

        public static ApplicationModule GetApplicationModuleByID(int AppID)
        {
            foreach (WorkflowPhase phase in ApplicationHelper.Phases)
            {
                foreach (WorkflowSubPhase subphase in phase.SubPhase)
                {
                    foreach (ApplicationModule appModule in subphase.Files)
                    {
                        if (AppID == appModule.ApplicationModuleID)
                            return appModule;
                    }

                    foreach (ApplicationModule appModule in subphase.Forms)
                    {
                        if (AppID == appModule.ApplicationModuleID)
                            return appModule;
                    }

                    foreach (ApplicationModule appModule in subphase.Reports)
                    {
                        if (AppID == appModule.ApplicationModuleID)
                            return appModule;
                    }
                }
            }

            return null;
        }

        public static void ClearPermissions()
        {
            if (HttpRuntime.Cache["PERMISSION"] != null)
                HttpRuntime.Cache.Remove("PERMISSION");
        }
    }

        #endregion

}
