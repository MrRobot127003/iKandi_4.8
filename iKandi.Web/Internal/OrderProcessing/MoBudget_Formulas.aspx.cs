using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iKandi.Web.Internal.OrderProcessing
{
  public partial class MoBudget_Formulas : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Request.QueryString["show"].ToString() == "Budget")
      {
        pnlBudget.Visible = true;
        pnlMMRDailyReport.Visible = false;
        pnlMMRReportDateRange.Visible = false;
      }
      else if (Request.QueryString["show"].ToString() == "MMRDailyReport")
      {
        pnlBudget.Visible = false;
        pnlMMRDailyReport.Visible = true;
        pnlMMRReportDateRange.Visible = false;
      }
      else if (Request.QueryString["show"].ToString() == "MMRReportDateRange")
      {
        pnlBudget.Visible = false;
        pnlMMRDailyReport.Visible = false;
        pnlMMRReportDateRange.Visible = true;
      }
      else
      {
        pnlBudget.Visible = false;
        pnlMMRDailyReport.Visible = false;
        pnlMMRReportDateRange.Visible = false;
      }
    }
  }
}