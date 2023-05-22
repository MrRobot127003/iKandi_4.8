using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
namespace iKandi.Web.Internal.OrderProcessing
{
    public partial class Feeding : System.Web.UI.Page
    {
        OrderController objOrderController = new OrderController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        /*
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string extarget = "", exactual = "", exdelay = "";
            if (chbextar.Checked)
            {
                extarget = "ExTarget";
                // System.Web.HttpContext.Current.Session.SessionID
            }
            if (chbexact.Checked)
            {
                exactual = "ExActual";
            }
            if (chbexdel.Checked)
            {
                exdelay = "ExDelay";
            }

            objOrderController.InsertFeedingSelection(extarget, exactual, exdelay, System.Web.HttpContext.Current.Session.SessionID);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "UpdateManageOrder", "UpdateManageOrder();", true);
        }
        */

    }
}