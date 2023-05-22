using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace iKandi.Web
{
    public partial class press : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        //{
        //    if (Login1.UserName.Contains("@")) //Email Login
        //    {
        //        string username = Membership.GetUserNameByEmail(Login1.UserName);
        //        if (username != null)
        //        {
        //            if (Membership.ValidateUser(username, Login1.Password))
        //            {
        //                Login1.UserName = username;
        //                e.Authenticated = true;
        //            }
        //            else e.Authenticated = false;
        //        }
        //    }
        //    else  //Standard Username & Password Login
        //    {
        //        if (Membership.ValidateUser(Login1.UserName, Login1.Password)) e.Authenticated = true;
        //        else e.Authenticated = false;
        //    }

        //}
    }
}
