using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iKandi.Web
{
    public partial class frmDailyMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/EmailReport.aspx?Flag=" + "Direct" + "&MailType=" + "Daily report");
        }
    }
}