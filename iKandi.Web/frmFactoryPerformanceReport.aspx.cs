using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iKandi.Web
{
    public partial class frmFactoryPerformanceReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             Response.Redirect("~/SendMailDirectFacotryPerformance.aspx?Flag=" + "Direct" + "&MailType=" + "Facotry Performance");
        }
    }
}