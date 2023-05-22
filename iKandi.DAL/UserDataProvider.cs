using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using iKandi.Common;

namespace iKandi.DAL
{
  public class UserDataProvider : BaseDataProvider
  {
    #region Ctor(s)

    public UserDataProvider(SessionInfo LoggedInUser)
      : base(LoggedInUser)
    {
    }

    #endregion

    public List<User> GetManagers(int DesignationID)
    {
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_managers";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@DesignationID", SqlDbType.Int);
        param.Value = DesignationID;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();

        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);

          users.Add(user);
        }
        return users;
      }
    }


    public List<User> GetUsersByDesignation(int ManagerID, int DesignationID)
    {

      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_users_by_designation_id_by_manager";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@DesignationID", SqlDbType.Int);
        param.Value = DesignationID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@ManagerID", SqlDbType.Int);
        param.Value = ManagerID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();
        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);

          users.Add(user);
        }
        return users;
      }
    }


    public List<User> GetUsersByDesignationIDAndManagerID(int ManagerID, int DesignationID)
    {

      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_users_by_designation_id_manager_id";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@DesignationID", SqlDbType.Int);
        param.Value = DesignationID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@ManagerID", SqlDbType.Int);
        param.Value = ManagerID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();
        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);

          users.Add(user);
        }
        return users;
      }
    }


    public List<User> GetUsersByDesignation(int DesignationID)
    {
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_users_by_designation_id";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@DesignationID", SqlDbType.Int);
        param.Value = DesignationID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();
        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);

          users.Add(user);
        }
        return users;
      }
    }
    public List<User> GetUsersByDesignation_new(int DesignationID)
    {
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_users_by_designation_id_new";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@DesignationID", SqlDbType.Int);
        param.Value = DesignationID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();
        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);

          users.Add(user);
        }
        return users;
      }
    }
    public DataTable GetUserDetails(int UserID)
    {
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        DataTable dt = null;
        string cmdText = "Usp_GetUserDetails";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Value = UserID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        if (ds != null && ds.Tables[0] != null)
        {
          dt = ds.Tables[0];
        }

        return dt;
      }
    }

    public DataTable GetUsersByDesignationDataTable(int DesignationID)
    { //manisha 21 june 2011
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        DataTable dt = null;
        // Create a SQL command object
        string cmdText = "sp_users_get_users_by_designation_id_OnlyForLinePlan";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@DesignationID", SqlDbType.Int);
        param.Value = DesignationID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        DataSet ds = new DataSet();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(ds);
        if (ds != null && ds.Tables[0] != null)
        {
          dt = ds.Tables[0];
        }

        return dt;
      }
    }



    //public DataTable BindGroupsFromDB_DAL()
    //{ 
    //    using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
    //    {
    //        cnx.Open();

    //        DataTable dt = null;

    //        string cmdText = "GetGroupName";

    //        SqlCommand cmd = new SqlCommand(cmdText, cnx);


    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.CommandTimeout =Constants.CONFIGURATION_TimeOut;



    //        DataSet ds = new DataSet();
    //        SqlDataAdapter da = new SqlDataAdapter(cmd);
    //        da.Fill(ds);
    //        if (ds != null && ds.Tables[0] != null)
    //        {
    //            dt= ds.Tables[0];
    //        }

    //        return dt;
    //    }
    //}







    public DataTable BindGroupsFromDB_DAL(string string_TableName, string string_ColumnNames, string string_WhereColumn, string string_Operator, string string_WhereValue, bool bool_WithSeleted)
    {
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        SqlCommand cmd;
        string cmdText;
        cmdText = "BindDropDownList";
        cmd = new SqlCommand(cmdText, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        SqlParameter param;
        //tableName VARCHAR(45),ColName VARCHAR(1000),IsClouse VARCHAR(100),IsClouseValue
        param = new SqlParameter("tableName", SqlDbType.VarChar);
        param.Value = string_TableName;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("ColName", SqlDbType.VarChar);
        param.Value = string_ColumnNames;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@sClouse", SqlDbType.VarChar);
        param.Value = string_WhereColumn;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@sClouseValue", SqlDbType.VarChar);
        param.Value = string_WhereValue;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@Operator", SqlDbType.VarChar);
        param.Value = string_Operator;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);


        param = new SqlParameter("@WithSelectedOption", SqlDbType.Bit);
        param.Value = bool_WithSeleted;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);


        DataSet ds = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(ds);
        cnx.Close();
        return ds.Tables[0];
      }
    }


    /// <summary>
    /// yaten : GetUserInfoCompayWise
    /// </summary>
    /// <param name="objUserIdList"></param>
    /// <param name="objDesignationList"></param>
    /// <param name="objDepartmentList"></param>
    /// <param name="ClientId"></param>
    /// <returns></returns>
    public List<User> GetUsersEmailCompanyWise(List<String> objUserIdList, List<String> objDesignationList, List<String> objDepartmentList, int ClientId, int intCompanyId)
    {
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_designationid_departmentid_ForOrderDelevered";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;

        param = new SqlParameter("@UserIDList", SqlDbType.VarChar);
        String userList = String.Empty;
        int i = 0;
        foreach (String id in objUserIdList)
        {
          if (i != 0)
          {
            userList = userList + ",";
          }
          userList = userList + id;
          i++;
        }
        param.Value = userList;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@DesignationIDList", SqlDbType.VarChar);
        String designationList = String.Empty;
        i = 0;
        foreach (String id in objDesignationList)
        {
          if (i != 0)
          {
            designationList = designationList + ",";
          }
          designationList = designationList + id;
          i++;
        }
        param.Value = designationList;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@DepartmentIDList", SqlDbType.VarChar);
        String departmentList = String.Empty;
        i = 0;
        foreach (String id in objDepartmentList)
        {
          if (i != 0)
          {
            departmentList = departmentList + ",";
          }
          departmentList = departmentList + id;
          i++;
        }
        param.Value = departmentList;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@ClientId", SqlDbType.Int);
        param.Value = ClientId;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);


        param = new SqlParameter("@CompanyId", SqlDbType.Int);
        param.Value = intCompanyId;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);




        SqlDataReader reader = cmd.ExecuteReader();
        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);
          user.Email = Convert.ToString(reader["Email"]);
          user.DesignationID = Convert.ToInt32(reader["DesignationID"]);
          user.PrimaryGroupID = Convert.ToInt32(reader["PrimaryGroupID"]);

          users.Add(user);
        }
        return users;
      }
    }


    public List<User> GetUsersEmail(List<String> objUserIdList, List<String> objDesignationList, List<String> objDepartmentList, int ClientId)
    {
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_users_by_id_designationid_departmentid";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;

        param = new SqlParameter("@UserIDList", SqlDbType.VarChar);
        String userList = String.Empty;
        int i = 0;
        foreach (String id in objUserIdList)
        {
          if (i != 0)
          {
            userList = userList + ",";
          }
          userList = userList + id;
          i++;
        }
        param.Value = userList;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@DesignationIDList", SqlDbType.VarChar);
        String designationList = String.Empty;
        i = 0;
        foreach (String id in objDesignationList)
        {
          if (i != 0)
          {
            designationList = designationList + ",";
          }
          designationList = designationList + id;
          i++;
        }
        param.Value = designationList;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@DepartmentIDList", SqlDbType.VarChar);
        String departmentList = String.Empty;
        i = 0;
        foreach (String id in objDepartmentList)
        {
          if (i != 0)
          {
            departmentList = departmentList + ",";
          }
          departmentList = departmentList + id;
          i++;
        }
        param.Value = departmentList;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@ClientId", SqlDbType.Int);
        param.Value = ClientId;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();
        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);
          user.Email = Convert.ToString(reader["Email"]);
          user.DesignationID = Convert.ToInt32(reader["DesignationID"]);
          user.PrimaryGroupID = Convert.ToInt32(reader["PrimaryGroupID"]);

          users.Add(user);
        }
        return users;
      }
    }
    public List<User> GetUsersEmailforAllocated(List<String> objUserIdList, List<String> objDesignationList, List<String> objDepartmentList, int ClientId)
    {
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_users_by_id_designationid_departmentid_Allocated";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;

        param = new SqlParameter("@UserIDList", SqlDbType.VarChar);
        String userList = String.Empty;
        int i = 0;
        foreach (String id in objUserIdList)
        {
          if (i != 0)
          {
            userList = userList + ",";
          }
          userList = userList + id;
          i++;
        }
        param.Value = userList;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@DesignationIDList", SqlDbType.VarChar);
        String designationList = String.Empty;
        i = 0;
        foreach (String id in objDesignationList)
        {
          if (i != 0)
          {
            designationList = designationList + ",";
          }
          designationList = designationList + id;
          i++;
        }
        param.Value = designationList;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@DepartmentIDList", SqlDbType.VarChar);
        String departmentList = String.Empty;
        i = 0;
        foreach (String id in objDepartmentList)
        {
          if (i != 0)
          {
            departmentList = departmentList + ",";
          }
          departmentList = departmentList + id;
          i++;
        }
        param.Value = departmentList;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@ClientId", SqlDbType.Int);
        param.Value = ClientId;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();
        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);
          user.Email = Convert.ToString(reader["Email"]);
          user.DesignationID = Convert.ToInt32(reader["DesignationID"]);
          user.PrimaryGroupID = Convert.ToInt32(reader["PrimaryGroupID"]);

          users.Add(user);
        }
        return users;
      }
    }

    public List<User> GetUsersEmailByAccountManagerIds(List<String> objUserIdList, List<String> objDesignationList, List<String> objDepartmentList, string AccountManagerids)
    {
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_users_by_accountmanagerid";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;

        param = new SqlParameter("@UserIDList", SqlDbType.VarChar);
        String userList = String.Empty;
        int i = 0;
        foreach (String id in objUserIdList)
        {
          if (i != 0)
          {
            userList = userList + ",";
          }
          userList = userList + id;
          i++;
        }
        param.Value = userList;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@DesignationIDList", SqlDbType.VarChar);
        String designationList = String.Empty;
        i = 0;
        foreach (String id in objDesignationList)
        {
          if (i != 0)
          {
            designationList = designationList + ",";
          }
          designationList = designationList + id;
          i++;
        }
        param.Value = designationList;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@DepartmentIDList", SqlDbType.VarChar);
        String departmentList = String.Empty;
        i = 0;
        foreach (String id in objDepartmentList)
        {
          if (i != 0)
          {
            departmentList = departmentList + ",";
          }
          departmentList = departmentList + id;
          i++;
        }
        param.Value = departmentList;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@accountManagerIDList", SqlDbType.VarChar);
        param.Value = AccountManagerids;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();
        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);
          user.Email = Convert.ToString(reader["Email"]);
          user.DesignationID = Convert.ToInt32(reader["DesignationID"]);
          user.PrimaryGroupID = Convert.ToInt32(reader["PrimaryGroupID"]);

          users.Add(user);
        }
        return users;
      }
    }



    public User GetUserByID(int UserID)
    {


      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_user_by_id";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Value = UserID;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();

        User user = new User();

        if (reader.Read())
        {
          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.PrimaryGroupID = Convert.ToInt32(reader["PrimaryGroupID"]);
          user.Company = (iKandi.Common.Company)Convert.ToInt32(reader["CompanyID"]);
          user.DesignationID = Convert.ToInt32(reader["DesignationID"]);
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);
          user.ManagerID = Convert.ToInt32(reader["ManagerID"]);
          user.PhotoPath = Convert.ToString(reader["PhotoPath"]);
          user.Address = Convert.ToString(reader["Address"]);
          user.Phone = Convert.ToString(reader["Phone"]);
          user.Mobile = Convert.ToString(reader["Mobile"]);
          user.Fax = Convert.ToString(reader["Fax"]);
          user.DesignerCode = (reader["DesignerCode"] == null) ? string.Empty : Convert.ToString(reader["DesignerCode"]);
          user.BirthDay = Convert.ToDateTime(reader["BirthDay"]);
          user.Anniversary = Convert.ToDateTime(reader["Anniversary"]);
          user.Username = Convert.ToString(reader["name"]);
          user.Email = Convert.ToString(reader["Email"]);
          user.Password = Convert.ToString(reader["Password"]);
        }
        return user;
      }
    }

    public int GetUserID(string UserName)
    {
      int UserID = 0;
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_user_id_by_name";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@UserName", SqlDbType.VarChar);
        param.Value = UserName;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
          UserID = Convert.ToInt32(reader["UserID"]);
        }
        return UserID;
      }
    }
    public int GetIpStatus(string Ip)
    {
      int UserID = 0;
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_Ip_status";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@p", SqlDbType.VarChar);
        param.Value = Ip;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
          UserID = Convert.ToInt32(reader["ipadd"]);
        }
        return UserID;
      }
    }
    public int GetUserStatus(string UserName)
    {
      int UserID = 0;
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_user_id_by_name_for_ip";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@UserName", SqlDbType.VarChar);
        param.Value = UserName;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
          UserID = Convert.ToInt32(reader["statuss"]);
        }
        return UserID;
      }
    }

    public User GetUserByName(string FirstName, string LastName, string UserName)
    {
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();
        User user = new User();
        // Create a SQL command object
        string cmdText = "sp_user_get_user_information_by_name";
        SqlCommand cmd = new SqlCommand(cmdText, cnx);
        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@FirstName", SqlDbType.VarChar);
        param.Value = FirstName;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@LastName", SqlDbType.VarChar);
        param.Value = LastName;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@UserName", SqlDbType.VarChar);
        param.Value = UserName;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);


        SqlDataReader reader = cmd.ExecuteReader();


        if (reader.Read())
        {

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.PrimaryGroupID = Convert.ToInt32(reader["PrimaryGroupID"]);
          user.Company = (iKandi.Common.Company)Convert.ToInt32(reader["CompanyID"]);
          user.DesignationID = Convert.ToInt32(reader["DesignationID"]);
          user.DesignationName = (reader["DesignationName"] == null) ? string.Empty : reader["DesignationName"].ToString();
          user.PrimaryGroupName = (reader["DepartmentName"] == null) ? string.Empty : reader["DepartmentName"].ToString();
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);
          user.ManagerID = Convert.ToInt32(reader["ManagerID"]);
          user.ManagerName = ((reader["DesignationName"] == null) ? string.Empty : reader["ManagerFirstName"].ToString()) + " " + ((reader["ManagerFirstName"] == null) ? string.Empty : reader["ManagerLastName"].ToString());
          user.PhotoPath = Convert.ToString(reader["PhotoPath"]);
          user.Address = Convert.ToString(reader["Address"]);
          user.Phone = Convert.ToString(reader["Phone"]);
          user.Mobile = Convert.ToString(reader["Mobile"]);
          user.Fax = Convert.ToString(reader["Fax"]);
          user.DesignerCode = (reader["DesignerCode"] == null) ? string.Empty : Convert.ToString(reader["DesignerCode"]);
          user.BirthDay = Convert.ToDateTime(reader["BirthDay"]);
          user.Anniversary = Convert.ToDateTime(reader["Anniversary"]);
          user.Username = Convert.ToString(reader["name"]);
          user.Email = Convert.ToString(reader["Email"]);
          user.Password = Convert.ToString(reader["Password"]);
          user.PersonalEmail = Convert.ToString(reader["PersonalEmail"]);


        }
        return user;
      }
    }

    public List<User> GetAllUsersForCor()
    {
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_users_Courier";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;



        SqlDataReader reader = cmd.ExecuteReader();

        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.PrimaryGroupID = Convert.ToInt32(reader["PrimaryGroupID"]);
          user.Company = (iKandi.Common.Company)Convert.ToInt32(reader["CompanyID"]);
          user.DesignationID = Convert.ToInt32(reader["DesignationID"]);
          user.DesignationName = (reader["DesignationName"] == null) ? string.Empty : reader["DesignationName"].ToString();
          user.PrimaryGroupName = (reader["DepartmentName"] == null) ? string.Empty : reader["DepartmentName"].ToString();
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);
          user.ManagerID = Convert.ToInt32(reader["ManagerID"]);
          user.ManagerName = ((reader["DesignationName"] == null) ? string.Empty : reader["ManagerFirstName"].ToString()) + " " + ((reader["ManagerFirstName"] == null) ? string.Empty : reader["ManagerLastName"].ToString());
          user.PhotoPath = Convert.ToString(reader["PhotoPath"]);
          user.Address = Convert.ToString(reader["Address"]);
          user.Phone = Convert.ToString(reader["Phone"]);
          user.Mobile = Convert.ToString(reader["Mobile"]);
          user.Fax = Convert.ToString(reader["Fax"]);
          user.DesignerCode = (reader["DesignerCode"] == null) ? string.Empty : Convert.ToString(reader["DesignerCode"]);
          user.BirthDay = Convert.ToDateTime(reader["BirthDay"]);
          user.Anniversary = Convert.ToDateTime(reader["Anniversary"]);
          user.Username = Convert.ToString(reader["name"]);
          user.Email = Convert.ToString(reader["Email"]);
          user.Password = Convert.ToString(reader["Password"]);
          user.PersonalEmail = Convert.ToString(reader["PersonalEmail"]);

          users.Add(user);
        }

        return users;
      }
    }
    public List<User> GetAllUsers()
    {
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_users";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;



        SqlDataReader reader = cmd.ExecuteReader();

        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.PrimaryGroupID = Convert.ToInt32(reader["PrimaryGroupID"]);
          user.Company = (iKandi.Common.Company)Convert.ToInt32(reader["CompanyID"]);
          user.DesignationID = Convert.ToInt32(reader["DesignationID"]);
          user.DesignationName = (reader["DesignationName"] == null) ? string.Empty : reader["DesignationName"].ToString();
          user.PrimaryGroupName = (reader["DepartmentName"] == null) ? string.Empty : reader["DepartmentName"].ToString();
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);
          user.ManagerID = Convert.ToInt32(reader["ManagerID"]);
          user.ManagerName = ((reader["DesignationName"] == null) ? string.Empty : reader["ManagerFirstName"].ToString()) + " " + ((reader["ManagerFirstName"] == null) ? string.Empty : reader["ManagerLastName"].ToString());
          user.PhotoPath = Convert.ToString(reader["PhotoPath"]);
          user.SignPath = Convert.ToString(reader["SignaturePath"]);
          user.Address = Convert.ToString(reader["Address"]);
          user.Phone = Convert.ToString(reader["Phone"]);
          user.Mobile = Convert.ToString(reader["Mobile"]);
          user.Fax = Convert.ToString(reader["Fax"]);
          user.DesignerCode = (reader["DesignerCode"] == null) ? string.Empty : Convert.ToString(reader["DesignerCode"]);
          user.BirthDay = Convert.ToDateTime(reader["BirthDay"]);
          user.Anniversary = Convert.ToDateTime(reader["Anniversary"]);
          user.Username = Convert.ToString(reader["name"]);
          user.Email = Convert.ToString(reader["Email"]);
          user.Password = Convert.ToString(reader["Password"]);
          user.PersonalEmail = Convert.ToString(reader["PersonalEmail"]);

          users.Add(user);
        }

        return users;
      }
    }

    public List<User> GetAllUsers(int PageSize, int PageIndex, out int TotalRowCount, String SearchText, int IsActive)
    {
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_user_get_all_user_with_paging";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        SqlParameter outParam;
        outParam = new SqlParameter("@Count", SqlDbType.Int);
        outParam.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(outParam);

        SqlParameter param;

        param = new SqlParameter("@PageSize", SqlDbType.Int);
        param.Value = PageSize;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@PageIndex", SqlDbType.Int);
        param.Value = PageIndex;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@SearchText", SqlDbType.VarChar);
        param.Value = SearchText;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@IsActive", SqlDbType.Int);
        param.Value = IsActive;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();

        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.PrimaryGroupID = Convert.ToInt32(reader["PrimaryGroupID"]);
          user.Company = (iKandi.Common.Company)Convert.ToInt32(reader["CompanyID"]);
          user.DesignationID = Convert.ToInt32(reader["DesignationID"]);
          user.DesignationName = (reader["DesignationName"] == null) ? string.Empty : reader["DesignationName"].ToString();
          user.PrimaryGroupName = (reader["PrimaryGroupName"] == null) ? string.Empty : reader["PrimaryGroupName"].ToString();
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);
          user.ManagerID = Convert.ToInt32(reader["ManagerID"]);
          user.ManagerName = ((reader["DesignationName"] == null) ? string.Empty : reader["ManagerFirstName"].ToString()) + " " + ((reader["ManagerFirstName"] == null) ? string.Empty : reader["ManagerLastName"].ToString());
          user.PhotoPath = Convert.ToString(reader["PhotoPath"]);
          user.Address = Convert.ToString(reader["Address"]);
          user.Phone = Convert.ToString(reader["Phone"]);
          user.Mobile = Convert.ToString(reader["Mobile"]);
          user.Fax = Convert.ToString(reader["Fax"]);
          user.DesignerCode = (reader["DesignerCode"] == null) ? string.Empty : Convert.ToString(reader["DesignerCode"]);
          user.BirthDay = Convert.ToDateTime(reader["BirthDay"]);
          user.Anniversary = Convert.ToDateTime(reader["Anniversary"]);
          user.Username = Convert.ToString(reader["name"]);
          user.Email = Convert.ToString(reader["Email"]);
          user.Password = Convert.ToString(reader["Password"]);
          user.PersonalEmail = Convert.ToString(reader["PersonalEmail"]);
          user.MembershipUserId = Convert.ToString(reader["GUID"]);
          user.WeekOff = (reader["WeekOff"] == null) ? string.Empty : reader["WeekOff"].ToString();
          user.IsStaff = (reader["IsStaff"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsStaff"]);
          users.Add(user);
        }
        reader.Close();
        TotalRowCount = Convert.ToInt32(outParam.Value);
        return users;
      }

    }


    public List<User> GetTeamMembers(int UserID)
    {
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_team_members";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Value = UserID;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();

        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.PrimaryGroupID = Convert.ToInt32(reader["PrimaryGroupID"]);
          user.Company = (iKandi.Common.Company)Convert.ToInt32(reader["CompanyID"]);
          user.DesignationID = Convert.ToInt32(reader["DesignationID"]);
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);
          user.ManagerID = Convert.ToInt32(reader["ManagerID"]);
          user.PhotoPath = Convert.ToString(reader["NewPhoto"]);
          user.Address = Convert.ToString(reader["Address"]);
          user.Phone = Convert.ToString(reader["Phone"]);
          user.Mobile = Convert.ToString(reader["Mobile"]);
          user.Fax = Convert.ToString(reader["Fax"]);
          user.DesignerCode = (reader["DesignerCode"] == null) ? string.Empty : Convert.ToString(reader["DesignerCode"]);
          user.BirthDay = Convert.ToDateTime(reader["BirthDay"]);
          user.Anniversary = Convert.ToDateTime(reader["Anniversary"]);
          user.Username = Convert.ToString(reader["name"]);
          user.Email = Convert.ToString(reader["Email"]);

          users.Add(user);
        }

        return users;
      }
    }

    public string GetUserDesignerCodeByManagerId(int managerID)
    {
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        SqlCommand cmd;
        string cmdText;

        cmdText = "sp_user_profile_get_user_designer_code_by_manager_id";
        cmd = new SqlCommand(cmdText, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

        SqlParameter param = new SqlParameter("@ManagerID", SqlDbType.Int);
        param.Value = managerID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        object obj = cmd.ExecuteScalar();
        string designerCode = "-1";

        if (obj != DBNull.Value && obj != null)
          designerCode = Convert.ToString(obj);

        return designerCode;


      }

    }


    public List<User> GetFactoryManagerByClient(int orderDetailID)
    {
      List<User> users = new List<User>();

      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        try
        {

          string cmdText = "sp_users_get_factoryManager_by_orderDetailID";
          SqlCommand cmd = new SqlCommand(cmdText, cnx);
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
          SqlParameter param;
          param = new SqlParameter("@OrderDetailID", SqlDbType.Int);
          param.Value = orderDetailID;
          param.Direction = ParameterDirection.Input;
          cmd.Parameters.Add(param);

          DataSet dsUser = new DataSet();
          SqlDataAdapter adapter = new SqlDataAdapter(cmd);

          adapter.Fill(dsUser);

          DataTable dt1 = dsUser.Tables[0];
          //DataTable dt2 = dsUser.Tables[1];



          if (dt1.Rows.Count > 0)
          {
            foreach (DataRow row1 in dt1.Rows)
            {
              User user = new User();

              user.UserID = Convert.ToInt32(row1["UserID"]);
              user.FirstName = Convert.ToString(row1["FirstName"]);
              user.LastName = Convert.ToString(row1["LastName"]);

              users.Add(user);
            }
          }

          //if (dt2.Rows.Count > 0)
          //{
          //    foreach (DataRow row1 in dt2.Rows)
          //    {

          //        User user = new User();

          //        user.UserID = Convert.ToInt32(row1["UserID"]);
          //        user.FirstName = Convert.ToString(row1["FirstName"]);
          //        user.LastName = Convert.ToString(row1["LastName"]);

          //        users.Add(user);
          //    }
          //}

        }
        catch (SqlException ex)
        {
            System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

            System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
        }
      }

      return users;
    }

    public List<User> GetUsersByDesignationByAccountManagerIDs(String ManagerID, int DesignationID)
    {

      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_users_by_designation_id_by_manager_Ids";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@DesignationID", SqlDbType.Int);
        param.Value = DesignationID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@ManagerID", SqlDbType.VarChar);
        param.Value = ManagerID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();
        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);

          users.Add(user);
        }
        return users;
      }
    }

    public List<User> GetSamplingMerchandiserByDeptID(int DepartmentId, int DesignationID)
    {

      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_users_by_designation_id_by_department";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@DesignationID", SqlDbType.Int);
        param.Value = DesignationID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@DepartmentId", SqlDbType.Int);
        param.Value = DepartmentId;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();
        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);

          users.Add(user);
        }
        return users;
      }
    }

    public List<User> GetSalesTeamByBHID(int DepartmentId, int DesignationID)
    {

      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_users_get_users_by_designation_id_by_BHID";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@DesignationID", SqlDbType.Int);
        param.Value = DesignationID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@DepartmentId", SqlDbType.Int);
        param.Value = DepartmentId;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();
        List<User> users = new List<User>();

        while (reader.Read())
        {
          User user = new User();

          user.UserID = Convert.ToInt32(reader["UserID"]);
          user.FirstName = Convert.ToString(reader["FirstName"]);
          user.LastName = Convert.ToString(reader["LastName"]);

          users.Add(user);
        }
        return users;
      }
    }


    //added for getting owners
    public List<String> Getowners(string searchValue, string Selecttype)
    {

      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_owners_by_designation_department_user_all";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //add pram

        SqlParameter param;
        param = new SqlParameter("@searchValue", SqlDbType.VarChar);
        param.Value = searchValue;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@SelectType", SqlDbType.VarChar);
        param.Value = Selecttype;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();
        List<Owners> owners = new List<Owners>();
        List<String> owne = new List<String>();
        while (reader.Read())
        {
          //Owners own = new Owners();
          string ow;
          //own.OwnerID = reader["Id"].ToString();
          //own.Ownername = Convert.ToString(reader["Name"]);
          ow = reader["Id"].ToString();
          owne.Add(ow);

        }
        return owne;
      }
    }
    //added for populating owners
    public List<Owners> Getownersforpopulat(string ownerid)
    {

      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "sp_all_owners";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        //add pram

        SqlParameter param;
        param = new SqlParameter("@Ownerids", SqlDbType.VarChar);
        int i = ownerid.IndexOf(",");
        if (i != -1)
        {

          string[] sOwnerArray = ownerid.Split(',');
          string sOwner = "";
          foreach (string s in sOwnerArray)
          {
            sOwner = sOwner + s.Trim() + ",";
          }
          if (sOwner.EndsWith(","))
          {
            sOwner = sOwner.Substring(0, sOwner.Length - 1);
          }
          param.Value = sOwner.Trim();
        }
        else
        {
          param.Value = ownerid.Trim();
        }

        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);


        SqlDataReader reader = cmd.ExecuteReader();
        List<Owners> owners = new List<Owners>();
        //List<String> owne=new List<String>();
        while (reader.Read())
        {
          Owners own = new Owners();
          //string ow;
          own.OwnerID = reader["Tempid"].ToString();
          own.Ownername = Convert.ToString(reader["Name"]);
          owners.Add(own);

        }
        return owners;
      }

    }



    //added by abhishek on 12/1/2015

    public DataTable GetCompanyName()
    {

      DataTable dt = new DataTable();
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        // Create a SQL command object
        string cmdText = "Usp_GetCompanyName";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;



        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(dt);



        cnx.Close();
        return dt;
      }
    }

    public int GetUserIdByName(string name)
    {
        int Id;
        using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        {
            cnx.Open();

            // Create a SQL command object
            string cmdText = "sp_auditor";

            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

            SqlParameter param;
            param = new SqlParameter("@status", SqlDbType.VarChar);
            param.Value = "GetUserIdByName";
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Name", SqlDbType.VarChar);
            param.Value = name;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            Id = Convert.ToInt32(cmd.ExecuteScalar());



            cnx.Close();
            return Id;
        }
    }


    //end by abhishek on 12/1/2015
    //added by abhishek on 18/6/2018

    public DataTable GetUserSque(int DeptID)
    {
      DataTable dt = new DataTable();
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();
        string cmdText = "Usp_GetUsedUserSequence";
        SqlCommand cmd = new SqlCommand(cmdText, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        SqlParameter param;
        param = new SqlParameter("@deptID", SqlDbType.Int);
        param.Value = DeptID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(dt);
        cnx.Close();
        return dt;
      }
    }
    public List<User> GetUser(string txt)
    {
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();
        SqlDataAdapter adapter = new SqlDataAdapter();
        string cmdText = "GetUserImageSearch";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        SqlParameter param;
        param = new SqlParameter("@Searchtxt", SqlDbType.VarChar);
        param.Value = txt;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);
        SqlDataReader reader = cmd.ExecuteReader();
        List<User> UserSearch = new List<User>();
        while (reader.Read())
        {
          User objuser = new User();
          objuser.UserProfilePic = (reader["PhotoPath"].ToString());
          objuser.FirstName = (reader["Names"].ToString());
          UserSearch.Add(objuser);
        }
        cnx.Close();
        return UserSearch;
      }
    }
    //Added by abhishek on 19/12/2018
    public DataTable GetAllUsersbyEmpCode(string EmpCode)
    {
      DataTable dt = new DataTable();
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();
        string cmdText = "sp_user_get_all_user_by_EmpCode";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

        SqlParameter param;

        param = new SqlParameter("@EmpCode", SqlDbType.VarChar);
        param.Value = EmpCode;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataAdapter adpt = new SqlDataAdapter(cmd);
        adpt.Fill(dt);

        cnx.Close();
        return dt;
      }

    }
    public List<User> IsValidEmpCardNo(int userID,string EmpCardNo)
    {
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();
        string cmdText = "usp_ValidateEmployeCardNo";
        SqlCommand cmd = new SqlCommand(cmdText, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        SqlParameter param;
        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Value = userID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@EmpCode", SqlDbType.Int);
        param.Value = EmpCardNo;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataReader reader = cmd.ExecuteReader();
        List<User> users = new List<User>();
        while (reader.Read())
        {
          User user = new User();
          user.IsValidEmpCardNo = Convert.ToString(reader["Result"]);
          users.Add(user);
        }
        return users;
      }
    }
     //abhishek 
    public List<User> GetAllUsersALL()
    {
        // Create a connection object and data adapter
        using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
        {
            cnx.Open();

            // Create a SQL command object
            string cmdText = "sp_suggest_for_auto_complete";
            SqlCommand cmd = new SqlCommand(cmdText, cnx);
            SqlParameter param;

            param = new SqlParameter("@searchContext", SqlDbType.VarChar);
            param.Value = "Auditor";
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@searchValue", SqlDbType.VarChar);
            param.Value = "";
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);

            
            // Set the command type to StoredProcedure
            cmd.CommandType = CommandType.StoredProcedure;



            SqlDataReader reader = cmd.ExecuteReader();

            List<User> users = new List<User>();

            while (reader.Read())
            {
                User user = new User();

                user.UserID = Convert.ToInt32(reader["UserID"]);
                user.PrimaryGroupID = Convert.ToInt32(reader["PrimaryGroupID"]);
                user.Company = (iKandi.Common.Company)Convert.ToInt32(reader["CompanyID"]);
                user.DesignationID = Convert.ToInt32(reader["DesignationID"]);
                user.DesignationName = (reader["DesignationName"] == null) ? string.Empty : reader["DesignationName"].ToString();
                user.PrimaryGroupName = (reader["DepartmentName"] == null) ? string.Empty : reader["DepartmentName"].ToString();
                user.FirstName = Convert.ToString(reader["FirstName"]);
                user.LastName = Convert.ToString(reader["LastName"]);
                user.ManagerID = Convert.ToInt32(reader["ManagerID"]);
                user.ManagerName = ((reader["DesignationName"] == null) ? string.Empty : reader["ManagerFirstName"].ToString()) + " " + ((reader["ManagerFirstName"] == null) ? string.Empty : reader["ManagerLastName"].ToString());
                user.PhotoPath = Convert.ToString(reader["PhotoPath"]);
                user.Address = Convert.ToString(reader["Address"]);
                user.Phone = Convert.ToString(reader["Phone"]);
                user.Mobile = Convert.ToString(reader["Mobile"]);
                user.Fax = Convert.ToString(reader["Fax"]);
                user.DesignerCode = (reader["DesignerCode"] == null) ? string.Empty : Convert.ToString(reader["DesignerCode"]);
                user.BirthDay = Convert.ToDateTime(reader["BirthDay"]);
                user.Anniversary = Convert.ToDateTime(reader["Anniversary"]);
                user.Username = Convert.ToString(reader["name"]);
                user.Email = Convert.ToString(reader["Email"]);
                user.Password = Convert.ToString(reader["Password"]);
                user.PersonalEmail = Convert.ToString(reader["PersonalEmail"]);

                users.Add(user);
            }

            return users;
        }
    }



  }
}


