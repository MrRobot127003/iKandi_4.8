using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;

namespace iKandi.Web
{
    public partial class frmProductionMail : System.Web.UI.Page
    {
        ProductionController objProductionController = new ProductionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            bool bCheckEvent = false;
            bCheckEvent = objProductionController.bCheckCalenderEvent();
            if (bCheckEvent == true)
                Response.Redirect("~/Mailhourlyreport.aspx?Flag=" + "Direct" + "&MailType=" + "Hourly report");
        }
    }
}