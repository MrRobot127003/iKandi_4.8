using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
  public class User
  {
    public int UserID
    {
      get;
      set;
    }
    public string error_msg
    {
      get;
      set;
    }
    public string MembershipUserId
    {
      get;
      set;
    }

    public string Username
    {
      get;
      set;
    }
    public string UserProfilePic
    {
      get;
      set;
    }
    public Company Company
    {
      get;
      set;
    }

    public int CompanyID
    {
      get;
      set;
    }
    public DateTime Actiondate
    {
      get;
      set;
    }
    public int ClientID
    {
      get;
      set;
    }

    public int ManagerID
    {
      get;
      set;
    }

    public int PrevManagerID
    {
      get;
      set;
    }

    public string ManagerName
    {
      get;
      set;
    }

    public string FirstName
    {
      get;
      set;
    }

    public string LastName
    {
      get;
      set;
    }
    public int EmpCardNo//abhishek
    {
      get;
      set;
    }
    public string IsValidEmpCardNo
    {
      get;
      set;
    }

    public string FullName
    {
      get
      {
        return string.Format("{0} {1}", (FirstName != null) ? FirstName.Trim() : string.Empty, (LastName != null) ? LastName.Trim() : string.Empty);
      }

    }

    public string Email
    {
      get;
      set;
    }

    public string Password
    {
      get;
      set;
    }

    public string PasswordQuestion
    {
      get;
      set;
    }

    public string PasswordAnswer
    {
      get;
      set;
    }

    public DateTime BirthDay
    {
      get;
      set;
    }

    public DateTime Anniversary
    {
      get;
      set;
    }

    public string Address
    {
      get;
      set;
    }
    public int IsStaff//abhishek
    {
      get;
      set;
    }
    public string WeekOff
    {
      get;
      set;
    }
    public string Intime
    {
      get;
      set;
    }
    public int OrderSeq
    {
      get;
      set;
    }
    public string Phone
    {
      get;
      set;
    }

    public string Mobile
    {
      get;
      set;
    }

    public string Fax
    {
      get;
      set;
    }

    public string PhotoPath
    {
      get;
      set;
    }

    public string SignPath
    {
        get;
        set;
    }

    public Designation Designation
    {
      get
      {
        return (Designation)this.DesignationID;
      }
    }

    public string DesignationName
    {
      get;
      set;
    }

    public int DesignationID
    {
      get;
      set;
    }

    public int Level
    {
      get;
      set;
    }

    public string DesignerCode
    {
      get;
      set;
    }

    public Group PrimaryGroup
    {
      get
      {
        return (Group)this.PrimaryGroupID;
      }

    }

    public int PrimaryGroupID
    {
      get;
      set;
    }

    public string PrimaryGroupName
    {
      get;
      set;
    }

    public List<int> AdditionalGroups
    {
      get;
      set;
    }

    public string HomePhone
    {
      get;
      set;
    }

    public string PersonalEmail
    {
      get;
      set;
    }

    public DateTime LastLoginDate
    {
      get;
      set;
    }

    public Int32 iGlobalAcc
    {
      get;
      set;
    }
    public int IsActive
    {
      get;
      set;
    }
  }

  public class Users : Collection<User>
  {

  }

  public class UserHolidayEntitlement
  {

    public User User
    {
      get;
      set;
    }

    public int ID
    {
      get;
      set;
    }

    public int Holidays
    {
      get;
      set;
    }

    public double HolidayUsed
    {
      get;
      set;
    }

  }

}
