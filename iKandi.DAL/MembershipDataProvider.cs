using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using iKandi.Common;
using System.Data;

namespace iKandi.DAL
{
  public class MembershipDataProvider : BaseDataProvider
  {
    #region Ctor(s)

    public MembershipDataProvider(SessionInfo LoggedInUser)
      : base(LoggedInUser)
    {
    }

    #endregion

    /// <summary>
    /// Creates the User Profile in the database
    /// </summary>
    /// <param name="InternalUser"></param>
    /// <returns></returns>
    public bool CreateUserProfile(User InternalUser)
    {
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        SqlDataAdapter adapter = new SqlDataAdapter();

        // Create a SQL command object
        string cmdText = "sp_users_create_profile";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@UserID", SqlDbType.VarChar);
        param.Value = InternalUser.MembershipUserId;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@FirstName", SqlDbType.VarChar);
        param.Value = InternalUser.FirstName;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@LastName", SqlDbType.VarChar);
        param.Value = InternalUser.LastName;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@ManagerID", SqlDbType.Int);
        param.Value = (int)InternalUser.ManagerID;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@CompanyID", SqlDbType.Int);
        param.Value = (int)InternalUser.Company;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Value = InternalUser.PhotoPath == null ? "" : InternalUser.PhotoPath;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);//shubhendu

        param = new SqlParameter("@SignPath", SqlDbType.VarChar);
        param.Value = InternalUser.SignPath == null ? "" : InternalUser.SignPath;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@Address", SqlDbType.VarChar);
        param.Value = InternalUser.Address == null ? "" : InternalUser.Address;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@Phone", SqlDbType.VarChar);
        param.Value = InternalUser.Phone == null ? "" : InternalUser.Phone;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@Mobile", SqlDbType.VarChar);
        param.Value = InternalUser.Mobile == null ? "" : InternalUser.Mobile;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@Fax", SqlDbType.VarChar);
        param.Value = InternalUser.Fax == null ? "" : InternalUser.Fax;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@PrimaryGroupID", SqlDbType.Int);
        param.Value = InternalUser.PrimaryGroupID;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@DesignationID", SqlDbType.Int);
        param.Value = (int)InternalUser.DesignationID;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@DesignerCode", SqlDbType.VarChar);
        param.Value = InternalUser.DesignerCode;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@BirthDay", SqlDbType.Date);
        param.Value = InternalUser.BirthDay;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@Anniversary", SqlDbType.Date);
        param.Value = InternalUser.Anniversary;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@HomePhone", SqlDbType.VarChar);
        param.Value = InternalUser.HomePhone == null ? "" : InternalUser.HomePhone;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@PersonalEmail", SqlDbType.VarChar);
        param.Value = InternalUser.PersonalEmail == null ? "" : InternalUser.PersonalEmail;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        //Below code Added for Acessess restriction
        param = new SqlParameter("@GlobalAcc", SqlDbType.Int);
        param.Value = InternalUser.iGlobalAcc;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);


        param = new SqlParameter("@WeekOff", SqlDbType.VarChar);
        param.Value = InternalUser.WeekOff == null ? "" : InternalUser.WeekOff;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@IsStaff", SqlDbType.Bit);
        param.Value = InternalUser.IsStaff;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@OrderSeq", SqlDbType.Int);
        param.Value = InternalUser.OrderSeq;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        int result = cmd.ExecuteNonQuery();

        cnx.Close();

      }

      return true;

    }


    /// <summary>
    /// Updates the User Profile in the database
    /// </summary>
    /// <param name="InternalUser"></param>
    /// <returns></returns>
    public bool UpdateUserProfile(User InternalUser)
    {
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        SqlDataAdapter adapter = new SqlDataAdapter();

        // Create a SQL command object
        string cmdText = "sp_users_update_profile";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Value = InternalUser.UserID;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@FirstName", SqlDbType.VarChar);
        param.Value = InternalUser.FirstName;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@LastName", SqlDbType.VarChar);
        param.Value = InternalUser.LastName;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@ManagerID", SqlDbType.Int);
        param.Value = (int)InternalUser.ManagerID;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@CompanyID", SqlDbType.Int);
        param.Value = (int)InternalUser.Company;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@PhotoPath", SqlDbType.VarChar);
        param.Value = InternalUser.PhotoPath;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@SignPath", SqlDbType.VarChar);
        param.Value = InternalUser.SignPath;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@Address", SqlDbType.VarChar);
        param.Value = InternalUser.Address;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@Phone", SqlDbType.VarChar);
        param.Value = InternalUser.Phone;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@Mobile", SqlDbType.VarChar);
        param.Value = InternalUser.Mobile;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@Fax", SqlDbType.VarChar);
        param.Value = InternalUser.Fax == null ? "" : InternalUser.Fax;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@PrimaryGroupID", SqlDbType.Int);
        param.Value = (int)InternalUser.PrimaryGroupID;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@DesignationID", SqlDbType.Int);
        param.Value = (int)InternalUser.DesignationID;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@DesignerCode", SqlDbType.VarChar);
        param.Value = InternalUser.DesignerCode;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@BirthDay", SqlDbType.Date);
        param.Value = InternalUser.BirthDay;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@Anniversary", SqlDbType.Date);
        param.Value = InternalUser.Anniversary;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@HomePhone", SqlDbType.VarChar);
        param.Value = InternalUser.HomePhone;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@PersonalEmail", SqlDbType.VarChar);
        param.Value = InternalUser.PersonalEmail;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        //Below code Added for Acessess restriction
        param = new SqlParameter("@GlobalAcc", SqlDbType.Int);
        param.Value = InternalUser.iGlobalAcc;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);


        //abhishek
        param = new SqlParameter("@IsActive", SqlDbType.Int);
        param.Value = InternalUser.IsActive;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@WeekOff", SqlDbType.VarChar);
        param.Value = InternalUser.WeekOff == null ? "" : InternalUser.WeekOff;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@IsStaff", SqlDbType.Bit);
        param.Value = InternalUser.IsStaff;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@InTime", SqlDbType.VarChar);
        param.Value = InternalUser.Intime;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@OrderSeq", SqlDbType.Int);
        param.Value = InternalUser.OrderSeq;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@EmpCardNo", SqlDbType.Int);
        param.Value = InternalUser.EmpCardNo;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);


        int result = cmd.ExecuteNonQuery();

        cnx.Close();

      }

      return true;

    }


    public User GetUserId(string UserName)
    {
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        SqlDataAdapter adapter = new SqlDataAdapter();
        string cmdText = "sp_GetUserIdByUserName";
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
          User user = new User();
          user.UserID = (reader["UserID"] == null) ? -1 : Convert.ToInt32(reader["UserID"]);
          return user;
        }
        cnx.Close();
      }

      return null;
    }

    public User GetUserProfile(int UserID)
    {
      // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        SqlDataAdapter adapter = new SqlDataAdapter();
        string cmdText = "sp_users_get_user_profile_by_id";
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

        if (reader.Read())
        {
          User user = new User();

          user.Address = (reader["Address"] == null) ? string.Empty : reader["Address"].ToString();
          user.Anniversary = (reader["Anniversary"] == null) ? DateTime.MinValue : Convert.ToDateTime(reader["Anniversary"]);
          user.BirthDay = (reader["BirthDay"] == null) ? DateTime.MinValue : Convert.ToDateTime(reader["BirthDay"]);
          user.CompanyID = (reader["CompanyID"] == null) ? -1 : Convert.ToInt32(reader["CompanyID"]);
          user.Company = (Company)user.CompanyID;
          user.DesignationID = (reader["DesignationID"] == null) ? -1 : Convert.ToInt32(reader["DesignationID"]);
          user.Level = (reader["Level"] == null) ? -1 : Convert.ToInt32(reader["Level"]);
          user.DesignerCode = (reader["DesignerCode"] == null) ? string.Empty : Convert.ToString(reader["DesignerCode"]);
          user.PersonalEmail = (reader["PersonalEmail"] == null) ? string.Empty : reader["PersonalEmail"].ToString();
          user.Phone = (reader["Phone"] == null) ? string.Empty : reader["Phone"].ToString();
          user.HomePhone = (reader["HomePhone"] == null) ? string.Empty : reader["HomePhone"].ToString();
          user.PhotoPath = (reader["PhotoPath"] == null) ? string.Empty : reader["PhotoPath"].ToString();

          if ((cnx.Database == "SamratDemo14May") || (cnx.Database == "donttouch") || (cnx.Database == "SamratDemo27Aug") || (cnx.Database == "Final_Migration") || (cnx.Database == "SanjeevStockissue") || (cnx.Database == "Material_Migration") || (cnx.Database == "Testing_Final_New"))
              user.SignPath = (reader["SignaturePath"] == null) ? string.Empty : reader["SignaturePath"].ToString();
         

         

          user.PrimaryGroupID = (reader["PrimaryGroupID"] == null) ? -1 : Convert.ToInt32(reader["PrimaryGroupID"]);
          user.UserID = UserID;
          user.FirstName = (reader["FirstName"] == null) ? string.Empty : reader["FirstName"].ToString();
          user.LastName = (reader["LastName"] == null) ? string.Empty : reader["LastName"].ToString();
          user.ManagerID = (reader["ManagerID"] == null) ? -1 : Convert.ToInt32(reader["ManagerID"]);
          user.Mobile = (reader["Mobile"] == null) ? string.Empty : reader["Mobile"].ToString();
          user.iGlobalAcc = (reader["statuss"] == null) ? 0 : Convert.ToInt32(reader["statuss"]);
          user.Username = (reader["UserName"] == null) ? string.Empty : reader["UserName"].ToString();
          //abhishek 6/6/2016
          user.Password = (reader["Password"] == null) ? string.Empty : reader["Password"].ToString();
          user.ClientID = Convert.ToInt32(reader["CompanyID"]);
          user.IsActive = Convert.ToInt32(reader["IsActive"]);
          user.WeekOff = (reader["WeekOff"] == null) ? string.Empty : reader["WeekOff"].ToString();
          user.IsStaff = (reader["IsStaff"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["IsStaff"]);
          user.Intime = (reader["InTime"] == null) ? string.Empty : reader["InTime"].ToString();
          user.OrderSeq = (reader["OrderSeq"] == null) ? 0 : Convert.ToInt32(reader["OrderSeq"].ToString());
          user.EmpCardNo = (reader["EmployeCardNo"] == null) ? 0 : Convert.ToInt32(reader["EmployeCardNo"].ToString());
          return user;
        }

        cnx.Close();
      }

      return null;
    }

    public int IsFirstTimeLogin(int UserId)
    { // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        SqlDataAdapter adapter = new SqlDataAdapter();

        // Create a SQL command object
        string cmdText = "sp_Login_IsFirstTime";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@UserId", SqlDbType.Int);
        param.Value = UserId;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        SqlParameter oparam;
        oparam = new SqlParameter("@oIsFirstLogin", SqlDbType.Int);
        oparam.Direction = ParameterDirection.Output;

        cmd.Parameters.Add(oparam);

        cmd.ExecuteNonQuery();

        return Convert.ToInt32(oparam.Value);
      }
    }

    public int InsertLoginHistory(int UserId, string ip)
    { // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        SqlDataAdapter adapter = new SqlDataAdapter();

        // Create a SQL command object
        string cmdText = "sp_Login_History";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Value = UserId;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@ClientIp", SqlDbType.VarChar);
        param.Value = ip;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        SqlParameter oparam;
        oparam = new SqlParameter("@oId", SqlDbType.Int);
        oparam.Direction = ParameterDirection.Output;

        cmd.Parameters.Add(oparam);

        cmd.ExecuteNonQuery();

        return Convert.ToInt32(oparam.Value);
      }
    }

    public void InsertPageHistory(int UserId, string pageName)
    { // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        SqlDataAdapter adapter = new SqlDataAdapter();

        // Create a SQL command object
        string cmdText = "sp_Login_PageHistory";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@d", SqlDbType.Int);
        param.Value = UserId;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        param = new SqlParameter("@PageName", SqlDbType.VarChar);
        param.Value = pageName;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);

        cmd.ExecuteNonQuery();
      }
    }

    public void SetIsFirstTime(int UserId)
    { // Create a connection object and data adapter
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();

        SqlDataAdapter adapter = new SqlDataAdapter();

        // Create a SQL command object
        string cmdText = "sp_Login_SetIsFirstTime";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);

        // Set the command type to StoredProcedure
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        // Add parameters
        SqlParameter param;
        param = new SqlParameter("@UserId", SqlDbType.Int);
        param.Value = UserId;
        param.Direction = ParameterDirection.Input;

        cmd.Parameters.Add(param);
        cmd.ExecuteNonQuery();
      }
    }
    //added by abhishek on 1/7/2015 for getfailloginattemp
    public DataSet GetFaildLoginCount(string userEmail)
    {
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        DataSet dsCount = new DataSet();

        cnx.Open();
        SqlCommand cmd;
        string cmdText;

        cmdText = "GetloginfailurerCount";
        cmd = new SqlCommand(cmdText, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        SqlParameter param;
        param = new SqlParameter("@Email", SqlDbType.VarChar);
        param.Value = userEmail;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        adapter.Fill(dsCount);
        return (dsCount);

      }

    }
    //added by abhishek on 6/6/2016
    public void ResetLoginfailCount(string UserEmail)
    {

      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        cnx.Open();
        SqlDataAdapter adapter = new SqlDataAdapter();
        string cmdText = "Usp_ResetUserLoginFailCount";

        SqlCommand cmd = new SqlCommand(cmdText, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

        SqlParameter param;
        param = new SqlParameter("@UserEmail", SqlDbType.VarChar);
        param.Value = UserEmail;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);
        int result = cmd.ExecuteNonQuery();

        cnx.Close();

      }



    }
    public DataSet GetFaildLoginCountEmilcheck(string userEmail)
    {
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        DataSet dsCount = new DataSet();

        cnx.Open();
        SqlCommand cmd;
        string cmdText;

        cmdText = "GetloginfailurerCount_";
        cmd = new SqlCommand(cmdText, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        SqlParameter param;
        param = new SqlParameter("@Email", SqlDbType.VarChar);
        param.Value = userEmail;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        adapter.Fill(dsCount);
        return (dsCount);

      }

    }
    public DataSet GetInactiveuser(int ClientID, int UserID, int types, string StrUserID = "")
    {
      using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
      {
        DataSet dsCount = new DataSet();

        cnx.Open();
        SqlCommand cmd;
        string cmdText;

        cmdText = "Usp_Update_InActive_User";
        cmd = new SqlCommand(cmdText, cnx);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
        SqlParameter param;
        param = new SqlParameter("@UserID", SqlDbType.Int);
        param.Value = UserID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);


        param = new SqlParameter("@Type", SqlDbType.Int);
        param.Value = types;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);


        param = new SqlParameter("@strUserID", SqlDbType.VarChar);
        param.Value = StrUserID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        param = new SqlParameter("@ClientID", SqlDbType.Int);
        param.Value = ClientID;
        param.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(param);

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        adapter.Fill(dsCount);
        return (dsCount);

      }

    }
  }
}
