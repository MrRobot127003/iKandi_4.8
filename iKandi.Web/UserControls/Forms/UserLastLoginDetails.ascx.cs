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
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class UserLastLoginDetails : System.Web.UI.UserControl
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindControls(); //test
        }

        #region Private Methods

        private void BindControls()
        {
            if (ApplicationHelper.LoggedInUser != null && ApplicationHelper.LoggedInUser.UserData != null)
            {
                this.lblDate.Text = ApplicationHelper.LoggedInUser.UserData.LastLoginDate.ToString("dd MMM yy (ddd)");
                this.lblTime.Text = ApplicationHelper.LoggedInUser.UserData.LastLoginDate.ToString("hh:mm");
            }
        }

        #endregion

        #endregion
    }
}