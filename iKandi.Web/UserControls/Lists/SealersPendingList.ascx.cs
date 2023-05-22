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
    public partial class SealersPendingList : BaseUserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
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

            Label lblSerial = e.Row.FindControl("lblSerial") as Label;
            (lblSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(od.ExFactory));

            Label lblMode = e.Row.FindControl("lblMode") as Label;
            // (lblMode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetDeliveryModeColor(od.Mode));

            HyperLink hypfitstatus = new HyperLink();

            if (od.FitStatus != string.Empty)
            {
                hypfitstatus.Text = od.FitStatus;
                string stylecode = string.Empty;
                if (od.ParentOrder.Fits.StyleCodeVersion == string.Empty)
                    stylecode = Constants.GetFiveDigitStyleCodeByStyleCode(od.ParentOrder.Fits.StyleCode);
                else
                    stylecode = od.ParentOrder.Fits.StyleCodeVersion;

                hypfitstatus.Style.Add("width", "100px ! important");
                hypfitstatus.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + stylecode + "','" + od.ParentOrder.DepartmentID + "','" + od.OrderDetailID + "')");
            }
            else
            {
                hypfitstatus.Text = "Show Sealer Pending Form";
                hypfitstatus.Target = "SealingForm";
                hypfitstatus.Style.Add("width", "100px ! important");

                if (!string.IsNullOrEmpty(od.ParentOrder.Fits.StyleCodeVersion) && od.ParentOrder.Fits.StyleCodeVersion.Length >= 5)
                    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + od.ParentOrder.Fits.StyleCodeVersion + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;
                else
                    hypfitstatus.NavigateUrl = "~/Internal/Fabric/FITsEdit.aspx?StyleCodeVersion=" + Constants.GetFiveDigitStyleCodeByStyleCode(od.ParentOrder.Style.StyleCode) + "&DeptId=" + od.ParentOrder.Style.cdept.DeptID;

            }
            Label lblFitsStatus = e.Row.FindControl("lblFitsStatus") as Label;
            (lblFitsStatus.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(od.FitStatusBgColor.ToString());
            lblFitsStatus.Controls.Add(hypfitstatus);

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
            int ClientID = 0;
            int DeptID = 0;

            GridView1.Columns[13].Visible = PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.SEALERS_PENDING_SEALER_REMARKS_BIPL);
            GridView1.Columns[14].Visible = PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.SEALERS_PENDING_SEALER_REMARKS_IKANDI);

            string searchText = txtsearch.Text;
            ClientID = Convert.ToInt32(ddlClients.SelectedValue);
            DeptID = Convert.ToInt32(hiddenDeptId.Value);

            if (!IsPostBack)
            {
                DropdownHelper.BindClients(ddlClients);
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

            List<OrderDetail> objOrderDetail = this.OrderControllerInstance.GetSealerPendingOrders(HyperLinkPager1.PageSize, (!string.IsNullOrEmpty(Request.QueryString["PageIndex"])) ? Convert.ToInt32(Request.QueryString["PageIndex"]) : 0, out TotalRowCount, searchText, ClientID, DeptID);
            GridView1.DataSource = objOrderDetail;
            GridView1.DataBind();

            PageHelper.RemoveJScriptVariable("selectedDeptID");
            PageHelper.AddJScriptVariable("selectedDeptID", Convert.ToInt32(hiddenDeptId.Value));

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();
        }

    }
}