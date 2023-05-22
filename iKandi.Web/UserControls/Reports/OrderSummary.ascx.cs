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
    public partial class OrderSummary : BaseUserControl
    {
        #region Properties

       
        #endregion

        int OrderBy = -1;
        int OrderBy2 = -1;
        int OrderBy3 = -1;
        int OrderBy4 = -1;
        int ClientId = -1;
        int FactoryManagerUserId = -1;
        int loggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;
        DateTime fromExDate = DateTime.MinValue;
        DateTime toExDate = DateTime.MinValue;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindClients(ddlClient as ListControl);
                DropdownHelper.BindUsersByDesignation(ddlProductionUnitManager, (int)Designation.BIPL_Production_FactoryManager);
            }
            
            BindControls();        
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            OrderDetail od = (e.Row.DataItem as OrderDetail);

            HtmlAnchor hypSerial = e.Row.FindControl("hypSerial") as HtmlAnchor;
            (hypSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(od.ExFactory));

            Label lblMode = e.Row.FindControl("lblMode") as Label;
            (lblMode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetDeliveryModeColor(od.Mode));

            Label lblEx = e.Row.FindControl("lblEx") as Label;
            (lblEx.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode));

            HtmlAnchor hypstatusmode = e.Row.FindControl("hypstatusmode") as HtmlAnchor;
            (hypstatusmode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(od.ParentOrder.WorkflowInstanceDetail.StatusModeID));

            Label lblSealDate = e.Row.FindControl("lblSealDate") as Label;
            (lblSealDate.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(od.FitStatusBgColor.ToString());

            HtmlAnchor hypUnit = e.Row.FindControl("hypUnit") as HtmlAnchor;
            (hypUnit.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(ApplicationHelper.GetUnitColor(od.Unit.FactoryCode));

            Label lblMon = e.Row.FindControl("lblMon") as Label;
            if (Convert.ToInt32(od.ParentOrder.Style.cdept.Mon) > 0)
            {
                lblMon.CssClass = "status_meeting_day_selected_style";
            }
            else
            {
                lblMon.CssClass = "status_meeting_day__style";
            }

            Label lblTue = e.Row.FindControl("lblTue") as Label;
            if (Convert.ToInt32(od.ParentOrder.Style.cdept.Tue) > 0)
            {
                lblTue.CssClass = "status_meeting_day_selected_style";
            }
            else
            {
                lblTue.CssClass = "status_meeting_day__style";
            }

            Label lblWed = e.Row.FindControl("lblWed") as Label;
            if (Convert.ToInt32(od.ParentOrder.Style.cdept.Wed) > 0)
            {
                lblWed.CssClass = "status_meeting_day_selected_style";
            }
            else
            {
                lblWed.CssClass = "status_meeting_day__style";
            }

            Label lblThu = e.Row.FindControl("lblThu") as Label;
            if (Convert.ToInt32(od.ParentOrder.Style.cdept.Thu) > 0)
            {
                lblThu.CssClass = "status_meeting_day_selected_style";
            }
            else
            {
                lblThu.CssClass = "status_meeting_day__style";
            }

            Label lblFri = e.Row.FindControl("lblFri") as Label;
            if (Convert.ToInt32(od.ParentOrder.Style.cdept.Fri) > 0)
            {
                lblFri.CssClass = "status_meeting_day_selected_style";
            }
            else
            {
                lblFri.CssClass = "status_meeting_day__style";
            }
        }


        private void BindControls()
        {
            ClientId = Convert.ToInt32(ddlClient.SelectedValue);
            OrderBy = Convert.ToInt32(ddlSortedBy.SelectedValue);
            OrderBy2 = Convert.ToInt32(ddlOrder2.SelectedValue);
            OrderBy3 = Convert.ToInt32(ddlOrder3.SelectedValue);
            OrderBy4 = Convert.ToInt32(ddlOrder4.SelectedValue);
            hdnLoogedinUserID.Value = Convert.ToString(loggedInUserID);

            fromExDate = DateHelper.ParseDate(txtExDateFrom.Text).Value;
            toExDate = DateHelper.ParseDate(txtExDateTo.Text).Value;

            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Production_FactoryManager)
            {
                FactoryManagerUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                hdnProductionUnitManager.Value = FactoryManagerUserId.ToString();
                ddlProductionUnitManager.SelectedValue = hdnProductionUnitManager.Value;
                ddlProductionUnitManager.Enabled = false;
            }
            else
            {
                FactoryManagerUserId = Convert.ToInt32(ddlProductionUnitManager.SelectedValue);
                hdnProductionUnitManager.Value = ddlProductionUnitManager.SelectedValue;
                ddlProductionUnitManager.Enabled = true;
                ddlProductionUnitManager.CssClass = "do-not-disable";
            }

            hdnLoogedinUserID.Value = Convert.ToString(loggedInUserID);
            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {
                this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
            }
            else
            {
                this.HyperLinkPager1.PageIndex = 0;
            }
            
            int TotalRowCount = 0;
            int TotalQuantity = 0;
            
            GridView1.DataSource = this.ReportControllerInstance.GetOrderSummaryReport(HyperLinkPager1.PageSize, (!string.IsNullOrEmpty(Request.QueryString["PageIndex"])) ? Convert.ToInt32(Request.QueryString["PageIndex"]) : 0, out TotalRowCount,"", ClientId, OrderBy, OrderBy2, OrderBy3, OrderBy4, out TotalQuantity, FactoryManagerUserId, loggedInUserID, fromExDate, toExDate );
            GridView1.DataBind();

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();

            lblTotalQuantity.Text = TotalQuantity.ToString("N0");
            hdnTotalQuantity.Value = TotalQuantity.ToString();
        }

    }
}