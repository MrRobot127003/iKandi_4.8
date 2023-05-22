using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Text;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.Internal.Accessory
{
    public partial class CutIssuePendingReport : System.Web.UI.Page
    {
        int OrderID;
        string SearchString;
        bool IsRequestPending = false;
        bool IsIssueRequest = false;
        bool IsCompleteIssue = false;
        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            OrderID = -1;

            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            IsRequestPending = rbRequestPending.Checked;
            IsIssueRequest = rbIssueRequest.Checked;
            IsCompleteIssue = rbIssueComplete.Checked;
            List<AccessoryQualityIssuing> objAccessoriesDetails = objAccessoryWorking.GetAccessoriesQualityIssuing(SearchString, IsRequestPending, IsIssueRequest, IsCompleteIssue, OrderID);
            grdAccessory.DataSource = objAccessoriesDetails;
            grdAccessory.DataBind();
        }

        protected void grdAccessory_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                PlaceHolder phChallan = (PlaceHolder)e.Row.FindControl("phChallan");
                CheckBox cbIssueRequest = (CheckBox)e.Row.FindControl("cbIssueRequest");
                CheckBox cbIssueComplete = (CheckBox)e.Row.FindControl("cbIssueComplete");
                HiddenField hdnOrderDetailId = (HiddenField)e.Row.FindControl("hdnOrderDetailId");
                HiddenField hdnAccessoryMasterId = (HiddenField)e.Row.FindControl("hdnAccessoryMasterId");
                HiddenField hdnIssueRequest = (HiddenField)e.Row.FindControl("hdnIssueRequest");
                HiddenField hdnIssueComplete = (HiddenField)e.Row.FindControl("hdnIssueComplete");
                Label lblIssueCompleteDate = (Label)e.Row.FindControl("lblIssueCompleteDate");
                Label lblRequestDate = (Label)e.Row.FindControl("lblRequestDate");
                Label lblColorPrint = (Label)e.Row.FindControl("lblColorPrint");
                Label lblSize = (Label)e.Row.FindControl("lblSize");
                Label lblAvailableQtyToIssue = (Label)e.Row.FindControl("lblAvailableQtyToIssue");
                Label lblTotalAccessoriesRequired = (Label)e.Row.FindControl("lblTotalAccessoriesRequired");
                Label lblRequiredQty = (Label)e.Row.FindControl("lblRequiredQty");
                Label lblStockQty = (Label)e.Row.FindControl("lblStockQty");
                Label lblDebitQty = (Label)e.Row.FindControl("lblDebitQty");
                Label Unit1 = (Label)e.Row.FindControl("Unit1");
                Label Unit2 = (Label)e.Row.FindControl("Unit2");
                Label Unit3 = (Label)e.Row.FindControl("Unit3");


                if (lblTotalAccessoriesRequired.Text != "")
                {
                    lblTotalAccessoriesRequired.Text = Convert.ToInt32(lblTotalAccessoriesRequired.Text) == 0 ? "" : Convert.ToInt32(lblTotalAccessoriesRequired.Text).ToString("N0");
                }
                if (lblAvailableQtyToIssue.Text != "")
                {
                    lblAvailableQtyToIssue.Text = Convert.ToInt32(lblAvailableQtyToIssue.Text) == 0 ? "" : Convert.ToInt32(lblAvailableQtyToIssue.Text).ToString("N0");
                }
                if (lblRequiredQty.Text != "" && lblRequiredQty.Text != "0.000")
                {
                    lblRequiredQty.Text = Convert.ToDecimal(lblRequiredQty.Text) == 0 ? "" : Convert.ToDecimal(lblRequiredQty.Text).ToString("N0");
                }

                if (lblTotalAccessoriesRequired.Text == "")
                {
                    Unit1.Text = "";
                }
                if (lblAvailableQtyToIssue.Text == "")
                {
                    Unit2.Text = "";
                }
                if (lblRequiredQty.Text == "")
                {
                    Unit3.Text = "";
                }

                if (lblSize.Text != "")
                    lblSize.Text = lblSize.Text == "Default" ? "" : "(" + lblSize.Text + ")";


                lblRequestDate.Text = DataBinder.Eval(e.Row.DataItem, "IssueRequestDate") == DBNull.Value ? "" : Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "IssueRequestDate")).ToString("dd MMM");

                if (hdnIssueRequest.Value == "1")
                    cbIssueRequest.Checked = true;
                if (hdnIssueComplete.Value == "1")
                    cbIssueComplete.Checked = true;

                DateTime dtIssueCompleteDate = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "IssueCompleteDate"));
                lblIssueCompleteDate.Text = dtIssueCompleteDate == DateTime.MinValue ? "" : dtIssueCompleteDate.ToString("dd MMM");

                int OrderDetailId = Convert.ToInt32(hdnOrderDetailId.Value);
                int AccessoryMasterId = Convert.ToInt32(hdnAccessoryMasterId.Value);
                string Size = DataBinder.Eval(e.Row.DataItem, "Size").ToString();
                string ColorPrint = DataBinder.Eval(e.Row.DataItem, "Color_Print").ToString();
                string GarmentUnitName = DataBinder.Eval(e.Row.DataItem, "GarmentUnitName").ToString();

                HtmlGenericControl dvChallanDetails = (HtmlGenericControl)e.Row.FindControl("dvChallanDetails");

                List<AccessoryQualityIssuing> objAccessoryQualityIssuing = objAccessoryWorking.GetChallanDetailsByOrderDetailId(OrderDetailId, AccessoryMasterId, Size, ColorPrint);
                if (objAccessoryQualityIssuing.Count > 0)
                {
                    StringBuilder sblChallan = new StringBuilder();
                    sblChallan.Append("<table cellspacing='0' border='0' cellpedding='0' style='width:100%'>");

                    for (int i = 0; i < objAccessoryQualityIssuing.Count; i++)
                    {
                        string ChallanNo = objAccessoryQualityIssuing[i].ChallanNumber;
                        string SerialNumber = objAccessoryQualityIssuing[i].SerialNumber;
                        string ChallanQty = Convert.ToInt32(objAccessoryQualityIssuing[i].ChallanQty).ToString("N0");
                        string ChallanDate = objAccessoryQualityIssuing[i].ChallanDateWithFormat;
                        string flagoption = "";
                        string ViewChalan = "<a onclick='OpenChallan(" + "&apos;" + ChallanNo + "&apos;" + "," + "&apos;" + flagoption + "&apos;" + "," + "&apos;" + SerialNumber + "&apos;" +")' style='color:blue;cursor:pointer' >" + objAccessoryQualityIssuing[i].ChallanNumber + "</a>";

                        //string ViewChalan = "<a onclick='OpenChallan(" +  OrderDetailId + ", " + AccessoryMasterId + ", " + "&apos;" + ColorPrint + "&apos;" + ", " + "&apos;" + Size + "&apos;" + ", " + objAccessoryQualityIssuing[i].ChallanId + ")' style='color:blue;cursor:pointer' >" + objAccessoryQualityIssuing[i].ChallanNumber + "</a>";
                        sblChallan.Append("<tr><td style='border-right: 1px solid #dbd8d8; width:51px; height:34px; color:blue;'>" + ViewChalan + "</td>");
                        sblChallan.Append("<td style='border-right: 1px solid #dbd8d8; width:50px; height:34px;'>" + ChallanQty + " <span style='font-weight:bold; color:gray'>" + GarmentUnitName + "</span></td>");
                        sblChallan.Append("<td style='width:50px; height:34px; border-right: 0px;'>" + ChallanDate + "</td></tr>");
                    }
                    sblChallan.Append("</table>");
                    dvChallanDetails.InnerHtml = sblChallan.ToString();
                }

                int StockQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StockQty"));
                int DebitQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DebitQty"));

                if (StockQty > 0)
                {
                    lblStockQty.Text = "Usable Stock Qty: <span style='color:black;'>" + StockQty.ToString("N0") + "</span>" + " <span style='font-weight:bold; color:gray'>" + GarmentUnitName + "</span><br>";
                }
                if (DebitQty > 0)
                {
                    lblDebitQty.Text = "Debit Qty: <span style='color:black;'>" + DebitQty.ToString("N0") + "</span>" + " <span style='font-weight:bold; color:gray'>" + GarmentUnitName + "</span>";
                }
                //else {
                //    lblDebitQty.Text = "Debit Qty:"; 
                //}

            }
        }

        protected void grdAccessory_DataBound(object sender, EventArgs e)
        {
            for (int i = grdAccessory.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdAccessory.Rows[i];
                GridViewRow previousRow = grdAccessory.Rows[i - 1];

                Label lblStyleNumber = (Label)row.Cells[0].FindControl("lblStyleNumber");
                Label lblPreviousStyleNumber = (Label)previousRow.Cells[0].FindControl("lblStyleNumber");

                Label lblSerial = (Label)row.Cells[1].FindControl("lblSerial");
                Label lblPreviousSerial = (Label)previousRow.Cells[1].FindControl("lblSerial");



                if (lblStyleNumber.Text == lblPreviousStyleNumber.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                }
                if (lblSerial.Text == lblPreviousSerial.Text)
                {
                    if (previousRow.Cells[1].RowSpan == 0)
                    {
                        if (row.Cells[1].RowSpan == 0)
                        {
                            previousRow.Cells[1].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
                        }
                        row.Cells[1].Visible = false;
                    }
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchString = txtsearchkeyswords.Text.Trim();
            BindGrid();
        }

    }
}