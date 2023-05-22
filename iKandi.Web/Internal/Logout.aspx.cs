using System;
using System.Web.Security;
using System.Web.UI;
using iKandi.BLL;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class Logout : Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

           // AdminController Acntrl = new AdminController();
           // Acntrl.MMRLogOut(ApplicationHelper.LoggedInUser.UserData.UserID, 0);
            Session.Clear();
            Session.Abandon();
            Context.User = null;
            FormsAuthentication.SignOut();           
            Response.Redirect("~/public/login.aspx");
        }
    }
}