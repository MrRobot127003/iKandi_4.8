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
using iKandi.Common;

namespace iKandi.Web
{
    public partial class PendingBuyingSamples : BaseUserControl
    {
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }

        public void BindControls()
        {

            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            if (!string.IsNullOrEmpty(txtfrom.Text))
                fromDate = DateHelper.ParseDate(txtfrom.Text).Value;

            if (!string.IsNullOrEmpty(txtTo.Text))
                toDate = DateHelper.ParseDate(txtTo.Text).Value;

            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {
                this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
            }
            else
            {
                this.HyperLinkPager1.PageIndex = 0;
            }

            int TotalRowCount = 0;

            ds = this.ReportControllerInstance.GetPendingBuyingSamplesReport(HyperLinkPager1.PageSize, (!string.IsNullOrEmpty(Request.QueryString["PageIndex"])) ? Convert.ToInt32(Request.QueryString["PageIndex"]) : 0, out TotalRowCount, txtStyleNo.Text, fromDate, toDate);
            grdPendingSamples.DataSource = ds;
            grdPendingSamples.DataBind();

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();  
        }

        protected void grdPendingSamples_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            Label lblDueDate = e.Row.FindControl("lblDueDate") as Label;
            if (ds.Tables[0].Rows[e.Row.RowIndex]["DueDate"] == DBNull.Value || Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["DueDate"]) == DateTime.MinValue)
                lblDueDate.Text = string.Empty;
            else
                lblDueDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["DueDate"]).ToString("dd MMM yy (ddd)");
        }
    }
}