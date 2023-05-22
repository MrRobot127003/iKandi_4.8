using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Data.SqlClient;
using System.Web.Security;
using System.Configuration;
using System.Data;
using System.Reflection;

namespace iKandi.BLL.Security
{
    [Serializable]
    public class UserProfile : ProfileBase
    {

        #region Properties

        #region General Info


        [System.Web.Profile.SettingsAllowAnonymous(true)]
        public string FirstName
        {
            get { return (String)(base["FirstName"]); }
            set { base["FirstName"] = value; }
        }

        [System.Web.Profile.SettingsAllowAnonymous(true)]
        public string MiddleName
        {
            get { return (String)(base["MiddleName"]); }
            set { base["MiddleName"] = value; }
        }

        [System.Web.Profile.SettingsAllowAnonymous(true)]
        public string LastName
        {
            get { return (String)(base["LastName"]); }
            set { base["LastName"] = value; }
        }

        [System.Web.Profile.SettingsAllowAnonymous(true)]
        public string Email
        {
            get { return (string)(base["Email"]); }
            set { base["Email"] = value; }
        }

        [System.Web.Profile.SettingsAllowAnonymous(true)]
        public int Industry
        {
            get { return Convert.ToInt32((base["Industry"])); }
            set { base["Industry"] = value; }
        }

        [System.Web.Profile.SettingsAllowAnonymous(true)]
        public string Work
        {
            get { return (string)(base["Work"]); }
            set { base["Work"] = value; }
        }

        [System.Web.Profile.SettingsAllowAnonymous(true)]
        public string Address1
        {
            get { return (string)(base["Address1"]); }
            set { base["Address1"] = value; }
        }

        [System.Web.Profile.SettingsAllowAnonymous(true)]
        public string Address2
        {
            get { return (string)(base["Address2"]); }
            set { base["Address2"] = value; }
        }

        [System.Web.Profile.SettingsAllowAnonymous(true)]
        public string CityProvince
        {
            get { return (string)(base["CityProvince"]); }
            set { base["CityProvince"] = value; }
        }

        [System.Web.Profile.SettingsAllowAnonymous(true)]
        public string State
        {
            get { return (string)(base["State"]); }
            set { base["State"] = value; }
        }

        [System.Web.Profile.SettingsAllowAnonymous(true)]
        public string Country
        {
            get { return (string)(base["Country"]); }
            set { base["Country"] = value; }
        }

        [System.Web.Profile.SettingsAllowAnonymous(true)]
        public string PhoneNumber
        {
            get { return (string)(base["PhoneNumber"]); }
            set { base["PhoneNumber"] = value; }
        }

        [System.Web.Profile.SettingsAllowAnonymous(true)]
        public string Company
        {
            get { return (string)(base["Company"]); }
            set { base["Company"] = value; }
        }

        [System.Web.Profile.SettingsAllowAnonymous(true)]
        public string AreaOfPCInterest
        {
            get { return (string)(base["AreaOfPCInterest"]); }
            set { base["AreaOfPCInterest"] = value; }
        }

        #endregion

        #endregion


    }
}
