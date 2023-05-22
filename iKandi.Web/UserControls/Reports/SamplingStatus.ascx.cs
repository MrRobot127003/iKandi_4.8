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
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Collections.Generic;


namespace iKandi.Web
{
    public partial class SamplingStatusReport : BaseUserControl
    {
        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
           // if (!IsPostBack)
                BindControls();
        }

        private void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindClients(ddlClients);
                if (ddlClients.Items.Count > 1)
                    ddlClients.SelectedIndex = 1;
            }

            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {
                this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
            }
            else
            {
                this.HyperLinkPager1.PageIndex = 0;
            }

            int TotalRowCount = 0;

            int styleID = -1;

            if (!string.IsNullOrEmpty(Request.Params[ddlStyles.UniqueID]))
                styleID = Convert.ToInt32(Request.Params[ddlStyles.UniqueID]);

            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            if (!string.IsNullOrEmpty(txtFromDate.Text))
                //fromDate = Convert.ToDateTime(txtFromDate.Text);
            fromDate = DateHelper.ParseDate(txtFromDate.Text).Value;
            if (!string.IsNullOrEmpty(txtToDate.Text))
                //toDate = Convert.ToDateTime(txtToDate.Text);
            toDate = DateHelper.ParseDate(txtFromDate.Text).Value;

            ////System.Diagnostics.Debugger.Break();

            ds = this.ReportControllerInstance.GetSamplingStatusReport(HyperLinkPager1.PageSize, (!string.IsNullOrEmpty(Request.QueryString["PageIndex"])) ? Convert.ToInt32(Request.QueryString["PageIndex"]) : 0, out TotalRowCount, Convert.ToInt32(ddlClients.SelectedValue), styleID, fromDate, toDate, txtSearchText.Text);

            grdSamplingStatus.DataSource = ds.Tables[0];
            grdSamplingStatus.DataBind();

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();

            PageHelper.RemoveJScriptVariable("currentStyleID");
            PageHelper.AddJScriptVariable("currentStyleID", styleID);

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }

        protected void grdSamplingStatus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            String priority = Constants.GetSamplingStatusPriority(Convert.ToDateTime(ds.Tables[0].Rows[e.Row.RowIndex]["ETA"]));

            Label lblPriority = e.Row.FindControl("lblPriority") as Label;
            lblPriority.Text = priority;
            (lblPriority.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStyleSamplingPriorityColor(priority));
                       

        }
    }
}