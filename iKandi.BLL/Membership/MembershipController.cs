using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using iKandi.BLL.Security;
using iKandi.Common;
using iKandi.DAL;
using System.Data;

namespace iKandi.BLL
{
  public class MembershipController : BaseController
  {
    #region

    public MembershipController()
    {
    }

    public MembershipController(SessionInfo LoggedInUser)
      : base(LoggedInUser)
    {
    }

    #endregion

    public User SaveUser(User InternalUser)
    {

      // Save User Membership

      if (InternalUser.UserID == -1)
      {

        MembershipCreateStatus status;

        string password = Membership.GeneratePassword(6, 0);

        if (InternalUser.Company == Company.Boutique)
        {
          password = "bipl01";
        }
        else if (InternalUser.Company == Company.iKandi)
        {
          password = "ikandi01";
        }
        else
        {
          //password = "xny01";
          password = "bipl01";
        }
        InternalUser.PasswordQuestion = "Company Name";
        InternalUser.PasswordAnswer = "Boutiqe";

        MembershipUser mUser = Membership.CreateUser(InternalUser.Email, password, InternalUser.Email, InternalUser.PasswordQuestion, InternalUser.PasswordAnswer, true, out status);

        if (mUser == null)
        {
          GetErrorMessage(status);
          InternalUser.error_msg = GetErrorMessage(status);

        }
        else
        {
          if (InternalUser.DesignationID != (int)Designation.BIPL_Supplier)//abhishek
          {
            if (InternalUser.Company == Company.Boutique)
            {
              Roles.AddUserToRole(mUser.UserName, Role.BIPL.ToString());
            }
            else
            {
              Roles.AddUserToRole(mUser.UserName, Role.iKandi.ToString());
            }
          }
          else if (InternalUser.DesignationID == (int)Designation.BIPL_Supplier)
          {
            Roles.AddUserToRole(mUser.UserName, Role.Supplier.ToString());
          }

          InternalUser.MembershipUserId = mUser.ProviderUserKey.ToString();

          //Save User Profile
          this.CreateUserProfile(InternalUser);

          UserDetails usd = new UserDetails();
          InternalUser.UserID = usd.GetUserId(mUser.UserName);

          // Add user to roles
          if (InternalUser.DesignationID != (int)Designation.BIPL_Supplier)
          {
            foreach (int deptID in InternalUser.AdditionalGroups)
            {
              this.DepartmentDataProviderInstance.AddUserDepartment(InternalUser.UserID, deptID);
            }
          }

          this.NotificationControllerInstance.SendUserRegistrationEmail(InternalUser.FullName, password, InternalUser.Email);

        }

        // 26th Feb 2010: Now onward if a user with primary designtation as Top Manager is created then role will not be Admin any more now.
        //if (InternalUser.DesignationID == (int)Designation.BIPL_TopManagement_Manager || InternalUser.DesignationID == (int)Designation.iKandi_TopManagement_Manager)
        //{
        //    Roles.AddUserToRole(mUser.UserName, Role.Admin.ToString());
        //}
        //else

        //{
        //    if (InternalUser.Company == Company.Boutique)
        //    {
        //        Roles.AddUserToRole(mUser.UserName, Role.BIPL.ToString());
        //    }
        //    else
        //    {
        //        Roles.AddUserToRole(mUser.UserName, Role.iKandi.ToString());
        //    }
        //}

        //InternalUser.UserID = Convert.ToInt32(mUser.ProviderUserKey);

      }
      else
      {
        MembershipUser mUser = Membership.GetUser(InternalUser.Username);

        // Email Address changes then do we want to change the Username also??
        mUser.Email = InternalUser.Email;

        //mUser.ChangePasswordQuestionAndAnswer(InternalUser.Password, InternalUser.PasswordQuestion, InternalUser.PasswordAnswer);

        // Do we want to change the password here or us the ChangePassword Control
        //if (mUser.GetPassword() != InternalUser.Password)
        //    mUser.ChangePassword();

        Membership.UpdateUser(mUser);

        //Update User Profile
        this.UpdateUserProfile(InternalUser);

        this.DepartmentDataProviderInstance.DeleteUserDepartment(InternalUser.UserID);

        if (InternalUser.ManagerID != InternalUser.PrevManagerID)
          this.DepartmentDataProviderInstance.DeleteUserCDA(InternalUser.UserID);

        // Add user to roles
        foreach (int deptID in InternalUser.AdditionalGroups)
        {
          this.DepartmentDataProviderInstance.AddUserDepartment(InternalUser.UserID, deptID);
        }
      }


      return InternalUser;
    }

    public User GetUserId(string UserName)
    {
      User user = this.GetUserId(UserName);
      return user;
    }

    public User GetUser(int UserID)
    {
      User user = this.MembershipDataProviderInstance.GetUserProfile(UserID);

      MembershipUser mUser = Membership.GetUser(user.Username);


      user.Username = mUser.UserName;
      //user.Password = mUser.GetPassword();
      user.Email = mUser.Email;
      user.LastLoginDate = mUser.LastLoginDate;
      // user.FailedPasswordAttemptCount=
      user.AdditionalGroups = this.DepartmentDataProviderInstance.GetUserDepartments(UserID);

      return user;
    }
    //added by abhishek 6/6/2016
    public void ResetLoginfailCount(string UserEmail)
    {
      this.MembershipDataProviderInstance.ResetLoginfailCount(UserEmail);
    }
    //end 
    public User GetUserProfile(int UserID)
    {
      return this.MembershipDataProviderInstance.GetUserProfile(UserID);
    }

    public bool CreateUserProfile(User InternalUser)
    {

      return this.MembershipDataProviderInstance.CreateUserProfile(InternalUser);

    }

    public bool UpdateUserProfile(User InternalUser)
    {
      return this.MembershipDataProviderInstance.UpdateUserProfile(InternalUser); ;
    }

    public int IsFirstTimeLogin(int UserId)
    {
      return this.MembershipDataProviderInstance.IsFirstTimeLogin(UserId);
    }

    public int InsertLoginHistory(int UserId, string ip)
    {
      return this.MembershipDataProviderInstance.InsertLoginHistory(UserId, ip);
    }

    public void InsertPageHistory(int UserId, string pageName)
    {
      this.MembershipDataProviderInstance.InsertPageHistory(UserId, pageName);
    }

    public void SetIsFirstTime(int UserId)
    {
      this.MembershipDataProviderInstance.SetIsFirstTime(UserId);
    }

    public string GetErrorMessage(MembershipCreateStatus status)
    {
      switch (status)
      {
        case MembershipCreateStatus.DuplicateUserName:
          return "User name already exists. Please enter a different user name.";

        case MembershipCreateStatus.DuplicateEmail:
          return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

        case MembershipCreateStatus.InvalidPassword:
          return "The password provided is invalid. Please enter a valid password value.";

        case MembershipCreateStatus.InvalidEmail:
          return "The e-mail address provided is invalid. Please check the value and try again.";

        case MembershipCreateStatus.InvalidAnswer:
          return "The password retrieval answer provided is invalid. Please check the value and try again.";

        case MembershipCreateStatus.InvalidQuestion:
          return "The password retrieval question provided is invalid. Please check the value and try again.";

        case MembershipCreateStatus.InvalidUserName:
          return "The user name provided is invalid. Please check the value and try again.";

        case MembershipCreateStatus.ProviderError:
          return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

        case MembershipCreateStatus.UserRejected:
          return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

        default:
          return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
      }
    }
    //added by abhishek on 1/7/2015 for getfailloginattemp
    public DataSet GetFaildLoginCount(string userEmail)
    {
      return this.MembershipDataProviderInstance.GetFaildLoginCount(userEmail); ;
    }
    public DataSet GetFaildLoginCountEmilcheck(string userEmail)
    {
      return this.MembershipDataProviderInstance.GetFaildLoginCountEmilcheck(userEmail); ;
    }
    public DataSet GetInactiveuser(int ClientID, int UserID, int types, string StrUserID = "")
    {
      return this.MembershipDataProviderInstance.GetInactiveuser(ClientID, UserID, types, StrUserID); ;
    }
  }
}
