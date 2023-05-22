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
    public partial class TeamMembers : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ApplicationHelper.LoggedInUser.UserData != null)
                    this.odsUsers.SelectParameters[0].DefaultValue = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
            }
        }
    }
}