using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.DAL;
using iKandi.Common;
using System.Data;



namespace iKandi.BLL
{

    public class UserController : BaseController
    {
        #region

        public UserController()
        {
        }

        public UserController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public List<User> GetManagers(int DesignationID)
        {


            return this.UserDataProviderInstance.GetManagers(DesignationID);
        }

        public User GetUserByID(int UserID)
        {


            return this.UserDataProviderInstance.GetUserByID(UserID);
        }

        public DataTable GetUserDetails(int UserID)
        {
          return this.UserDataProviderInstance.GetUserDetails(UserID);
        }

        public List<User> GetAllUsers()
        {
            return this.UserDataProviderInstance.GetAllUsers();
        }
        public List<User> GetAllUsersALL()
        {
            return this.UserDataProviderInstance.GetAllUsersALL();
        }
        public List<User> GetAllUsersForCor()
        {
          return this.UserDataProviderInstance.GetAllUsersForCor();
        }
      
        public List<User> GetAllUsers(int PageSize, int PageIndex, out int TotalPageCount, String SearchText, int IsActive)
        {
            return this.UserDataProviderInstance.GetAllUsers(PageSize, PageIndex, out TotalPageCount, SearchText,  IsActive);
        }

        public List<User> GetUsersByDesignation(int DesignationID)
        {
            return this.UserDataProviderInstance.GetUsersByDesignation(DesignationID);
        }
        public List<User> GetUsersByDesignation_new(int DesignationID)
        {
          return this.UserDataProviderInstance.GetUsersByDesignation_new(DesignationID);
        }
        public System.Data.DataTable GetUsersByDesignationDataTable(int DesignationID)
        {
            return this.UserDataProviderInstance.GetUsersByDesignationDataTable(DesignationID);
        }
        

        public List<User> GetUsersByDesignation(int ManagerID, int DesignationID)
        {
            return this.UserDataProviderInstance.GetUsersByDesignation(ManagerID, DesignationID);
        }

        public List<User> GetUsersByDesignationIDAndManagerID(int ManagerID, int DesignationID)
        {
            return this.UserDataProviderInstance.GetUsersByDesignationIDAndManagerID(ManagerID, DesignationID);
        }

        public List<User> GetTeamMembers(int UserID)
        {
            return this.UserDataProviderInstance.GetTeamMembers(UserID);
        }

        public string GetUserDesignerCodeByManagerID(int ManagerID)
        {
            return this.UserDataProviderInstance.GetUserDesignerCodeByManagerId(ManagerID);
        }

        public List<User> GetFactoryManagerByClient(int iOrderDetailId)
        {
            return this.UserDataProviderInstance.GetFactoryManagerByClient(iOrderDetailId);
        }
        public int GetUserID(string UserName)
        {
            return this.UserDataProviderInstance.GetUserID(UserName);
        }
        public int GetUserStatus(string UserName)
        {
            return this.UserDataProviderInstance.GetUserStatus(UserName);
        }
        public int GetIpStatus(string IP)
        {
            return this.UserDataProviderInstance.GetIpStatus(IP);
        }


        public User GetUserByName(string FirstName, string LastName, string UserName)
        {
            return this.UserDataProviderInstance.GetUserByName(FirstName, LastName, UserName);
        }

        public List<User> GetUsersByDesignationByAccountManagerIDs(String ManagerID, int DesignationID)
        {
            return this.UserDataProviderInstance.GetUsersByDesignationByAccountManagerIDs(ManagerID, DesignationID);
        }

        public List<User> GetSamplingMerchandiserByDeptID(int DepartmentId, int DesignationID)
        {
            return this.UserDataProviderInstance.GetSamplingMerchandiserByDeptID(DepartmentId, DesignationID);
        }

        public List<User> GetSalesTeamByBHID( int DepartmentId, int DesignationID)
        {
            return this.UserDataProviderInstance.GetSalesTeamByBHID(DepartmentId, DesignationID);
        }

        public List<String> Getowners(string searchValue, string Selecttype)
        {
            return this.UserDataProviderInstance.Getowners(searchValue, Selecttype);
        }
        public List<Owners> Getownersforpopulat(string ownerid)
        {
            return this.UserDataProviderInstance.Getownersforpopulat(ownerid);
        }
        public System.Data.DataTable BindGroupsFromDB(string string_TableName, string string_ColumnNames, string string_WhereColumn, string string_Operator, string string_WhereValue, bool bool_WithSeleted)
        {
            return this.UserDataProviderInstance.BindGroupsFromDB_DAL(string_TableName, string_ColumnNames, string_WhereColumn, string_Operator, string_WhereValue, bool_WithSeleted);
        }

       
       
        
        //added by abhishek on 12/1/2015
        public DataTable GetCompanyName()
        {
            return this.UserDataProviderInstance.GetCompanyName();
        }
        //end by abhishek on 18/6/2018
        public DataTable GetUserSque(int DeptID)
        {
          return this.UserDataProviderInstance.GetUserSque(DeptID);
        }
        public List<User> GetUser(string txt)
        {

          return UserDataProviderInstance.GetUser(txt);
        }
        //added by abhishek on 20/1/2018
        public DataTable GetAllUsersbyEmpCode(string EmpCode)
        {
          return this.UserDataProviderInstance.GetAllUsersbyEmpCode(EmpCode);
        }
        //added by abhishek on 31/12/2018
        public List<User> IsValidEmpCardNo(int userID, string EmpCardNo)
        {
          return this.UserDataProviderInstance.IsValidEmpCardNo(userID, EmpCardNo);
        }



        public int GetUserIdByName(string name)
        {
            return this.UserDataProviderInstance.GetUserIdByName(name);
        }

    }
}
