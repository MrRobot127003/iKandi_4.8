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
using iKandi.BLL;

namespace iKandi.Web
{
    public partial class PendingOrders : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnPagesize.Value = GridView1.PageSize.ToString();
            hdnPageIndex.Value = GridView1.PageIndex.ToString();
            if (!IsPostBack)
            {
                txtfrom.Value = DateTime.Today.AddDays(-7).ToString("dd MMM yy (ddd)");
                txtTo.Value = DateTime.Today.ToString("dd MMM yy (ddd)");
                BindControls();
            }

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            DateTime exFactory = DataBinder.Eval(e.Row.DataItem, "ExFactory") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ExFactory")) : DateTime.MinValue;
            DateTime dcDate = DataBinder.Eval(e.Row.DataItem, "DC") != DBNull.Value ? Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DC")) : DateTime.MinValue;
            int mode = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Mode"));

            if (exFactory != DateTime.MinValue)
            {
                HtmlAnchor hypSerial = e.Row.FindControl("hypSerial") as HtmlAnchor;
                (hypSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(exFactory));
            }

            Label lblMode = e.Row.FindControl("lblMode") as Label;
            (lblMode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(CommonHelper.GetDeliveryModeColor(Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Mode"))));

            if (exFactory != DateTime.MinValue)
            {
                HiddenField lblEx = e.Row.FindControl("lblEx") as HiddenField;
                (lblEx.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(CommonHelper.GetExFactoryColor(exFactory, dcDate, mode));
            }

            HiddenField hdnStatusMode = e.Row.FindControl("hdnStatusMode") as HiddenField;
            int statusModeId = Convert.ToInt32(hdnStatusMode.Value);
            if (statusModeId > 0)
            {
                (hdnStatusMode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(statusModeId));
            }
            Label lblUnit = e.Row.FindControl("lblUnit") as Label;
            string code = lblUnit.Text.ToString();
            if (code != string.Empty)
            {
                (lblUnit.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(ApplicationHelper.GetUnitColor(code));
            }

            Label lblPriceInFCSign = e.Row.FindControl("lblPriceInFCSign") as Label;
            Label lblPriceInFC = e.Row.FindControl("lblPriceInFC") as Label;
            if (lblPriceInFC.Text != string.Empty)
            {
                lblPriceInFCSign.Text = "&pound;";
            }

            Label lblAmountInFCSign = e.Row.FindControl("lblAmountInFCSign") as Label;
            Label lblAmountInFC = e.Row.FindControl("lblAmountInFC") as Label;
            if (lblAmountInFC.Text != string.Empty)
            {
                lblAmountInFCSign.Text = "&pound;";
            }

        }
        public void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindAllClients(ddlClients as ListControl);
            }
            DateTime startDate = txtfrom.Value.Trim() != string.Empty ? DateHelper.ParseDate(txtfrom.Value).Value : DateTime.MinValue;
            DateTime endDate = txtTo.Value.Trim() != string.Empty ? DateHelper.ParseDate(txtTo.Value).Value : DateTime.MaxValue;
            Session["StartDate"] = startDate;
            Session["EndDate"] = endDate;
            
            GridView1.DataBind();

            DataSet ds = new DataSet();
            int totalQuantity = 0;
            double totalAmount = 0;
            ds = this.ReportControllerInstance.GetPendingOrdersReportTotals(Convert.ToInt32(hdnPageIndex.Value), Convert.ToInt32(hdnPagesize.Value), startDate, endDate, Convert.ToInt32(ddlExFactoryDC.SelectedValue), Convert.ToInt32(ddlClients.SelectedValue), Convert.ToInt32(ddlModes.SelectedValue), out totalQuantity, out totalAmount);
            
            lblTotalQuantity.Text = totalQuantity.ToString("N0");
            lblTotalAmount.Text = totalAmount.ToString("N2");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            hdnPagesize.Value = GridView1.PageSize.ToString();
            hdnPageIndex.Value = GridView1.PageIndex.ToString();
            BindControls();
        }

        protected String GetHtmlEncode(String strFabric)
        {
            return strFabric.Replace('"', '\"');
        }

        protected void btnGo_click(object sender, EventArgs e)
        {
            GridView1.PageIndex = 0;
            BindControls();
        }
    }
}