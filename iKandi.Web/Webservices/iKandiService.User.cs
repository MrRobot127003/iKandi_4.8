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
using iKandi.BLL;


using System.Collections.Generic;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class iKandiService
    {
        //Added for geting ownners by US
        [WebMethod(EnableSession = true)]
        public List<String> Getowners(string searchValue, string Selecttype)
        {
            return this.UserDataProviderInstance.Getowners(searchValue, Selecttype);
        }
        //Added for retriving owners by US
        [WebMethod(EnableSession = true)]
        public List<Owners> Getownersforpopulat(string ownerid)
        {
            return this.UserDataProviderInstance.Getownersforpopulat(ownerid);
        }
        [WebMethod(EnableSession = true)]
        public bool IsEmailUnique(string email)
        {
            MembershipUserCollection users = Membership.FindUsersByEmail(email);

            return (users.Count == 0);
        }

        [WebMethod(EnableSession = true)]
        public bool IsUsernameUnique(string username)
        {
            MembershipUserCollection users = Membership.FindUsersByName(username);

            return (users.Count == 0);
        }

        [WebMethod(EnableSession = true)]
        public bool IsUsernameAndEmailUnique(string email)
        {
            if (this.IsUsernameUnique(email) && this.IsEmailUnique(email))
                return true;
            else
                return false;
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestAuditors(string q, int limit)
        {
            List<string> allauditors = SuggestForAutoComplete(q, AutoComplete.Auditor.ToString(), limit);

            return allauditors;
           
        }


        [WebMethod(EnableSession = true)]
        public List<User> GetManagers(int DesignationID)
        {
            return this.UserControllerInstance.GetManagers(DesignationID);
        }

        [WebMethod(EnableSession = true)]
        public List<UserDesignation> GetDesignations(int DepartmentID)
        {

            return this.DesignationControllerInstance.GetDesignationsByDepartment(DepartmentID);
        }

        [WebMethod(EnableSession = true)]
        public List<Department> GetDepartments(int CompanyID)
        {
            return this.DepartmentControllerInstance.GetDepartmentsByCompany(CompanyID);
        }

        [WebMethod(EnableSession = true)]
        public List<User> GetClientAccMgrByClientID(int DepartmentId)
        {
            return this.ClientControllerInstance.GetClientAccMgrByClientID(DepartmentId);
        }

        [WebMethod(EnableSession = true)]
        public List<User> GetSamplingMerchandiserByAccMgrID(int AccountManagerID)
        {
            return this.UserControllerInstance.GetUsersByDesignation(AccountManagerID, (int)Designation.BIPL_Merchandising_SamplingMerchant);
        }

        [WebMethod(EnableSession = true)]
        public List<User> GetFitMerchantByAccMgrID(String AccountManagerID)
        {
            return this.UserControllerInstance.GetUsersByDesignationByAccountManagerIDs(AccountManagerID, (int)Designation.BIPL_Merchandising_FitMerchant);
        }

        [WebMethod(EnableSession = true)]
        public List<User> GetAllUsers()
        {
          
            return this.UserControllerInstance.GetAllUsers();
        }
       
        [WebMethod(EnableSession = true)]
        public string GetUserInformationView(int UserID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("UserID", UserID);

            return PageHelper.GetControlHtml("~/UserControls/Forms/UserAccountInformation.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestUsers(string q, int limit)
        {
            List<string> filteredSearchResults = new List<string>();

            // Looping through the datasource to select the items that match
            foreach (User user in ApplicationHelper.Users)
            {
                if (user.FirstName.ToLower().Contains(q.ToLower()) || user.LastName.ToLower().Contains(q.ToLower()))
                {
                    filteredSearchResults.Add(user.FullName);
                }
            }

            // Sort the list
            filteredSearchResults.Sort();

            // Return the items that contained the text in alphabetical order
            return filteredSearchResults;
        }

        [WebMethod(EnableSession = true)]
        public int GetUserID(string UserName)
        {
            return this.UserControllerInstance.GetUserID(UserName);
        }
        [WebMethod(EnableSession = true)]
        public int GetUserStatus(string UserName)
        {
            return this.UserControllerInstance.GetUserStatus(UserName);
        }

        [WebMethod(EnableSession = true)]
        public int GetIpStatus(string Ip)
        {
            return this.UserControllerInstance.GetIpStatus(Ip);
        }
        [WebMethod(EnableSession = true)]
        public User GetUserInfornationByName(string UserName)
        {
            string firstName = string.Empty; 
            string lastName = string.Empty;
            if (UserName.Trim().LastIndexOf(" ") > -1)
            {
                firstName = UserName.ToString().Substring(0, UserName.IndexOf(" "));
                firstName = firstName.ToUpper().Trim();
                lastName = UserName.Substring(UserName.IndexOf(" "));
                lastName = lastName.ToUpper().Trim();
            }
            else
            {
                firstName = UserName;
            }


            return this.UserControllerInstance.GetUserByName(firstName, lastName, UserName.ToUpper().Trim());
        }

        [WebMethod(EnableSession = true)]
        public bool deleteInlinePPMFile(int ID)
        {

            return this.InlinePPMControllerInstance.DeleteInlinePPMFile(ID);
        }

        [WebMethod(EnableSession = true)]
        public List<User> GetSamplingMerchandiserByDeptID(int DepartmentId)
        {
            return this.UserControllerInstance.GetSamplingMerchandiserByDeptID(DepartmentId, 32); //Gajendra Design
            //return this.UserControllerInstance.GetSamplingMerchandiserByDeptID(DepartmentId, (int)Designation.BIPL_Merchandising_SamplingMerchant);
        }

        /// <summary>
        /// Yaten : Get all Task by User and Task Id
        /// </summary>
        /// <param name="TaskId"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetTaskByIdByDept(int TaskId, int MyTask)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            string html;
            if (TaskId == 1001)
                html = PageHelper.GetControlHtml("~/UserControls/Lists/UserTasksReminder.ascx", properties);
            else
            {
                properties.Add("TaskId", Convert.ToInt32(TaskId));
                properties.Add("MyTask", Convert.ToInt32(MyTask));
                html = PageHelper.GetControlHtmlWithForm("~/UserControls/Lists/UserTasksNew.ascx", properties);
            }
            return html;
        }

        [WebMethod(EnableSession = true)]
        public string GetTaskByIdNew(int TaskId, int MainTaskID, string TaskName)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("TaskId", Convert.ToInt32(TaskId));
            properties.Add("MainTaskID", Convert.ToInt32(MainTaskID));
            properties.Add("TaskName", TaskName);
            return PageHelper.GetControlHtmlWithForm("~/UserControls/Forms/FnATasks.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetTeamTasks()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            string ret = PageHelper.GetControlHtmlWithForm("~/UserControls/Lists/TeamTasks.ascx", properties);
            return ret;
        }

        [WebMethod(EnableSession = true)]
        public string GetMyTasks()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            string ret = PageHelper.GetControlHtmlWithForm("~/UserControls/Lists/MyTasks.ascx", properties);
            return ret;
        }
        [WebMethod(EnableSession = true)]//abhishek 
        public List<Department> GetSerialNumber(string StyleNumber)
        {
            return this.DepartmentControllerInstance.GetSerialNumber(StyleNumber);
           
        }
        [WebMethod(EnableSession = true)]//abhishek 
        public List<Department> GetPrintColorQty(int OrderID)
        {
            return this.DepartmentControllerInstance.GetPrintColorQty(OrderID);

        }
        [WebMethod(EnableSession = true)]//abhishek 
        public string Getfinishingsam(int OrderdetailsID = 0, int OrderID = 0, int UnitID = 0, string Flag = "")
        {
            return this.DepartmentControllerInstance.Getfinishingsam(OrderdetailsID, OrderID, UnitID, Flag);

        }
        [WebMethod(EnableSession = true)]//abhishek 
        public List<Department> getUsp_GetOderID(string flag,string StyleNumber)
        {
            return this.DepartmentControllerInstance.getUsp_GetOderID(flag, StyleNumber);

        }
        //abhishek===================================================================================================================//
        // fro Factory Representatives====================================================//
        //[WebMethod(EnableSession = true)]
        //public List<string> GetUserName_ByDptID_Factory(string searchValue, int limit)
        //{
        //    int Deptid = 0;//TODO Remove hard cord value

        //    List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(searchValue, Deptid);
        //    List<string> filteredSearchResults = new List<string>();
        //    foreach (string result in searchResults)
        //    {
        //        if (result.ToLower().Contains(searchValue.ToLower()))
        //        {
        //            filteredSearchResults.Add(result);
        //        }
        //    }
        //    filteredSearchResults.Sort();
        //    return filteredSearchResults;
        //}
        // fro QA Representatives====================================================//
        //[WebMethod(EnableSession = true)]
        //public List<string> GetUserName_ByDptID_QA(string searchValue, int limit)
        //{
        //    int Deptid = 9;//TODO Remove hard cord value

        //    List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(searchValue, Deptid);
        //    List<string> filteredSearchResults = new List<string>();
        //    foreach (string result in searchResults)
        //    {
        //        if (result.ToLower().Contains(searchValue.ToLower()))
        //        {
        //            filteredSearchResults.Add(result);
        //        }
        //    }
        //    filteredSearchResults.Sort();
        //    return filteredSearchResults;
        //}
        // fro Merchandiser Representatives====================================================//
        //[WebMethod(EnableSession = true)]
        //public List<string> GetUserName_ByDptID_Merchandiser(string searchValue, int limit)
        //{
        //    int Deptid = 6;//TODO Remove hard cord value

        //    List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(searchValue, Deptid);
        //    List<string> filteredSearchResults = new List<string>();
        //    foreach (string result in searchResults)
        //    {
        //        if (result.ToLower().Contains(searchValue.ToLower()))
        //        {
        //            filteredSearchResults.Add(result);
        //        }
        //    }
        //    filteredSearchResults.Sort();
        //    return filteredSearchResults;
        //}
        // fro IE Representatives====================================================//
        //[WebMethod(EnableSession = true)]
        //public List<string> GetUserName_ByDptID_IE(string searchValue, int limit)
        //{
        //    int Deptid = 15;//TODO Remove hard cord value

        //    List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(searchValue, Deptid);
        //    List<string> filteredSearchResults = new List<string>();
        //    foreach (string result in searchResults)
        //    {
        //        if (result.ToLower().Contains(searchValue.ToLower()))
        //        {
        //            filteredSearchResults.Add(result);
        //        }
        //    }
        //    filteredSearchResults.Sort();
        //    return filteredSearchResults;
        //}
        // fro Sampling Representatives====================================================//
        //[WebMethod(EnableSession = true)]
        //public List<string> GetUserName_ByDptID_Sampling(string searchValue, int limit)
        //{
        //    int Deptid = 0;//TODO Remove hard cord value

        //    List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(searchValue, Deptid);
        //    List<string> filteredSearchResults = new List<string>();
        //    foreach (string result in searchResults)
        //    {
        //        if (result.ToLower().Contains(searchValue.ToLower()))
        //        {
        //            filteredSearchResults.Add(result);
        //        }
        //    }
        //    filteredSearchResults.Sort();
        //    return filteredSearchResults;
        //}
        //// fro Fabric Representatives====================================================//
        //[WebMethod(EnableSession = true)]
        //public List<string> GetUserName_ByDptID_Fabric(string searchValue, int limit)
        //{
        //    int Deptid = 7;//TODO Remove hard cord value

        //    List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(searchValue, Deptid);
        //    List<string> filteredSearchResults = new List<string>();
        //    foreach (string result in searchResults)
        //    {
        //        if (result.ToLower().Contains(searchValue.ToLower()))
        //        {
        //            filteredSearchResults.Add(result);
        //        }
        //    }
        //    filteredSearchResults.Sort();
        //    return filteredSearchResults;
        //}
        //// fro Accessory Representatives====================================================//
        //[WebMethod(EnableSession = true)]
        //public List<string> GetUserName_ByDptID_Accessory(string searchValue, int limit)
        //{
        //    int Deptid = 8;//TODO Remove hard cord value

        //    List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(searchValue, Deptid);
        //    List<string> filteredSearchResults = new List<string>();
        //    foreach (string result in searchResults)
        //    {
        //        if (result.ToLower().Contains(searchValue.ToLower()))
        //        {
        //            filteredSearchResults.Add(result);
        //        }
        //    }
        //    filteredSearchResults.Sort();
        //    return filteredSearchResults;
        //}
        //// fro Out Representatives====================================================//
        //[WebMethod(EnableSession = true)]
        //public List<string> GetUserName_ByDptID_Out(string searchValue, int limit)
        //{
        //    int Deptid = 0;//TODO Remove hard cord value

        //    List<string> searchResults = this.CommonControllerInstance.GetUserNameByDeptID(searchValue, Deptid);
        //    List<string> filteredSearchResults = new List<string>();
        //    foreach (string result in searchResults)
        //    {
        //        if (result.ToLower().Contains(searchValue.ToLower()))
        //        {
        //            filteredSearchResults.Add(result);
        //        }
        //    }
        //    filteredSearchResults.Sort();
        //    return filteredSearchResults;
        //}

        [WebMethod(EnableSession = true)]//abhishek 
        public string ValidateFactoryWorkSpace(string FactoryWorkSpace)
        {
          return this.DepartmentControllerInstance.ValidateFactoryWorkSpace(FactoryWorkSpace);

        }
        [WebMethod(EnableSession = true)]//test 
        public List<User> GetUser(string txt)
        {
          return this.UserControllerInstance.GetUser(txt);
        }
        [WebMethod(EnableSession = true)]//abhishek 
        public List<User> IsValidEmpCardNo(int userID, string EmpCardNo)
        {
          return this.UserControllerInstance.IsValidEmpCardNo(userID, EmpCardNo); 

        }
        [WebMethod(EnableSession = true)]//abhishek 
        public bool UpdatedealydayCountTask(int StatusMode_id)
        {
          AdminController objadmin = new AdminController();
          return objadmin.UpdatedealydayCountTask(StatusMode_id);

        }
    }
}
