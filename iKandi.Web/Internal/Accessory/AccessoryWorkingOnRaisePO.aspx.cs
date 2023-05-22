using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Common;
using iKandi.BLL;
using iKandi.Web.Components;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Net;
using System.IO;
using Pechkin;
using System.Text.RegularExpressions;
using System.Net.Mail;


namespace iKandi.Web.Internal.Accessory
{
    public partial class AccessoryWorkingOnRaisePO : BasePage
    {
        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
        private int SupplierPoId = 0;
        private int OrderDetailId = 0;
        string host = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");
            host = "http://" + Request.Url.Authority;
            if (Request.QueryString["OrderDetailId"] != null)
            {
                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
            }
            else
            {
                OrderDetailId = 0;
            }
            if (Request.QueryString["SupplierPoId"] != null)
            {
                SupplierPoId = Convert.ToInt32(Request.QueryString["SupplierPoId"]);
            }
            else
            {
                SupplierPoId = 0;
            }            

            if (!IsPostBack)
            {
                if (Request.QueryString["PONumber"] != null)
                {
                    txtsearchkeyswords.Text = Request.QueryString["PONumber"];
                    ddlSearchOption.SelectedValue = "4";

                }
                BindData(0);
            }
        }

        private void BindData(int FromSearch)
        {
            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Store_Accountant)
            {
                lnkPendingOrderSuppary.Style.Add("display", "none");
                lnkSupplierQuotation.Style.Add("display", "none");
                lnkRaisePo.Style.Add("display", "none");
                ddlstatus.Attributes.Add("disabled", "disabled");

                string SearchVal = txtsearchkeyswords.Text.Trim();
                if ((SearchVal == "") && (FromSearch == 1))
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('Please Enter PO Number');", true);
                }
                else if ((SearchVal != "") && (FromSearch == 1))
                {
                    List<AccessoryPending> AccessList = objAccessoryWorking.GetRaisedPO_AccessoryWorking(SupplierPoId, OrderDetailId, txtsearchkeyswords.Text.Trim(), Convert.ToInt32(ddlstatus.SelectedValue), "WorkingOnRaisePo", Convert.ToInt32(ddlSearchOption.SelectedValue));
                    grdraisedpoworking.DataSource = AccessList;
                    grdraisedpoworking.DataBind();
                }
            }
            else
            {
                List<AccessoryPending> AccessList = objAccessoryWorking.GetRaisedPO_AccessoryWorking(SupplierPoId, OrderDetailId, txtsearchkeyswords.Text.Trim(), Convert.ToInt32(ddlstatus.SelectedValue), "WorkingOnRaisePo", Convert.ToInt32(ddlSearchOption.SelectedValue));
                grdraisedpoworking.DataSource = AccessList;
                grdraisedpoworking.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData(1);
        }

        protected void grdraisedpoworking_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow CurrentRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            LinkButton lnkplus = (LinkButton)CurrentRow.FindControl("lnkplus");
            LinkButton lnkminus = (LinkButton)CurrentRow.FindControl("lnkminus");
            HiddenField hdnSupplierPoId = (HiddenField)CurrentRow.FindControl("hdnSupplierPoId");
            Label lblAccesstype = (Label)CurrentRow.FindControl("lblAccesstype");

            SupplierPoId = hdnSupplierPoId != null ? Convert.ToInt32(hdnSupplierPoId.Value) : 0;

            HiddenField hdnStatus = (HiddenField)CurrentRow.FindControl("hdnStatus");
            int Status = Convert.ToInt32(hdnStatus.Value);

            foreach (GridViewRow gvr in grdraisedpoworking.Rows)
            {

                HiddenField hdnSrvCount = (HiddenField)gvr.FindControl("hdnSrvCount");
                LinkButton lnkplusRow = (LinkButton)gvr.FindControl("lnkplus");
                LinkButton lnkminusRow = (LinkButton)gvr.FindControl("lnkminus");
                Label lblAccesstypeRow = (Label)gvr.FindControl("lblAccesstype");
                Label lblCloseMsg = (Label)gvr.FindControl("lblCloseMsg");
                Label lblOnHoldqty = (Label)gvr.FindControl("lblOnHoldqty");
                if (lblOnHoldqty.Text != "")
                {
                    lblOnHoldqty.Attributes.Add("class", "backColorYellow");
                }
                int AccessTypeRow = 1;

                if (lblAccesstypeRow.Text.Trim() == "Greige")
                    AccessTypeRow = 1;
                else if (lblAccesstypeRow.Text.Trim() == "Process")
                    AccessTypeRow = 2;
                else if (lblAccesstypeRow.Text.Trim() == "Finish")
                    AccessTypeRow = 3;

                HiddenField hdnSupplierPoId_Row = (HiddenField)gvr.FindControl("hdnSupplierPoId");
                HiddenField hdnSrvReceiveqty = (HiddenField)gvr.FindControl("hdnSrvReceiveqty");
                HiddenField hdnTotalCheckedQty = (HiddenField)gvr.FindControl("hdnTotalCheckedQty");
                HiddenField hdnTotalPassQty = (HiddenField)gvr.FindControl("hdnTotalPassQty");
                HiddenField hdnTotalHoldQty = (HiddenField)gvr.FindControl("hdnTotalHoldQty");
                HiddenField hdnTotalFailQty = (HiddenField)gvr.FindControl("hdnTotalFailQty");
                HiddenField hdnGreigePassQty = (HiddenField)gvr.FindControl("hdnGreigePassQty");

                HiddenField hdnSendQty = (HiddenField)gvr.FindControl("hdnSendQty");
                HiddenField hdnTotalSendChallanQty = (HiddenField)gvr.FindControl("hdnTotalSendChallanQty");
                LinkButton lnkSrv = (LinkButton)gvr.FindControl("lnkSrv");

                HiddenField hdAccessoryMasterId = (HiddenField)gvr.FindControl("hdAccessoryMasterId");
                HiddenField hdnAccessoryQualitySize = (HiddenField)gvr.FindControl("hdnAccessoryQualitySize");
                HiddenField hdnColorprint = (HiddenField)gvr.FindControl("hdnColorprint");

                int AccessoryMasterId = hdAccessoryMasterId.Value == "" ? 0 : Convert.ToInt32(hdAccessoryMasterId.Value);
                string Size = hdnAccessoryQualitySize.Value.ToString();
                string Color_Print = hdnColorprint.Value.ToString();

                decimal SendQty = hdnSendQty.Value == "0.000" || hdnSendQty.Value == "" ? 0 : Convert.ToDecimal(hdnSendQty.Value);
                decimal SendChallanQty = hdnTotalSendChallanQty.Value == "" || hdnTotalSendChallanQty.Value == "0.000" ? 0 : Convert.ToDecimal(hdnTotalSendChallanQty.Value);
                decimal GreigePassQty = Convert.ToDecimal(hdnGreigePassQty.Value);
                decimal MinimumSendQty = 0;
                if (SendQty > GreigePassQty)
                    MinimumSendQty = GreigePassQty;
                else
                    MinimumSendQty = SendQty;

                decimal RemainingSendQty = MinimumSendQty - SendChallanQty;

                int SupplierPoId_Row = hdnSupplierPoId_Row.Value == "" ? 0 : Convert.ToInt32(hdnSupplierPoId_Row.Value);

                if (AccessTypeRow == 2)
                {
                    List<AccessoryChallanCls> AccessoryChallanList = objAccessoryWorking.GetRaisedPO_Challan_Detail(SupplierPoId_Row, "SendChallan");
                    int ChallanCount = AccessoryChallanList.Count;

                    if (ChallanCount == 0)
                    {
                        lnkSrv.Style.Add("display", "none");

                        StringBuilder sblSendChallan = new StringBuilder();
                        sblSendChallan.Append("<table id='data' style='width:100%' >");
                        if (RemainingSendQty > 0)
                        {
                            //sblSendChallan.Append("<tr><td class='process' style='min-width: 40px;border-bottom: 1px solid #dbd8d8;'><img src='../../images/edit.png' style='width:12px; cursor:pointer;' onclick='javascript:ShowAccessorySendChallan(" + SupplierPoId_Row + ", " + 0 + ", " + AccessoryMasterId + "," + "&apos;" + Size.Trim() + "&apos;" + "," + "&apos;" + Color_Print.Trim() + "&apos;)'></td></tr>");
                            sblSendChallan.Append("<tr><td class='process' style='min-width: 40px;border-bottom: 1px solid #dbd8d8;'><img src='../../images/edit.png' style='width:12px; cursor:pointer;' onclick='javascript:ShowAccessorySendChallan(" + SupplierPoId_Row + ", " + 0 + ")'></td></tr>");
                        }

                        sblSendChallan.Append("</table>");
                        gvr.Cells[8].Text = sblSendChallan.ToString();
                    }

                    if (ChallanCount == 1)
                    {
                        int SendChallanId = Convert.ToInt32(AccessoryChallanList[0].ChallanId);
                        string SendChallanNumber = AccessoryChallanList[0].ChallanNumber;

                        StringBuilder sblSendChallan = new StringBuilder();
                        sblSendChallan.Append("<table id='data' style='width:100%' >");
                        if (SendChallanId > 0)
                        {
                            //sblSendChallan.Append("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #dbd8d8;'><span style='color:blue;cursor:pointer;' onclick='javascript:ShowAccessorySendChallan(" + SupplierPoId_Row + ", " + SendChallanId + ", " + AccessoryMasterId + "," + "&apos;" + Size.Trim() + "&apos;" + "," + "&apos;" + Color_Print.Trim() + "&apos;)'>" + SendChallanNumber + "</span></td></tr>");
                            sblSendChallan.Append("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #dbd8d8;'><span style='color:blue;cursor:pointer;' onclick='javascript:ShowAccessorySendChallan(" + SupplierPoId_Row + ", " + SendChallanId + ")'>" + SendChallanNumber + "</span></td></tr>");
                        }
                        if (RemainingSendQty > 0)
                        {
                            //sblSendChallan.Append("<tr><td class='process' style='width: 40px;border-bottom: 1px solid #dbd8d8;'><img src='../../images/edit.png' style='width:12px; cursor:pointer;' onclick='javascript:ShowAccessorySendChallan(" + SupplierPoId_Row + ", " + 0 + ", " + AccessoryMasterId + "," + "&apos;" + Size.Trim() + "&apos;" + "," + "&apos;" + Color_Print.Trim() + "&apos;)'></td></tr>");
                            sblSendChallan.Append("<tr><td class='process' style='width: 40px;border-bottom: 1px solid #dbd8d8;'><img src='../../images/edit.png' style='width:12px; cursor:pointer;' onclick='javascript:ShowAccessorySendChallan(" + SupplierPoId_Row + ", " + 0 + ")'></td></tr>");
                        }

                        sblSendChallan.Append("</table>");
                        gvr.Cells[8].Text = sblSendChallan.ToString();
                    }
                    else if (ChallanCount > 1)
                    {
                        gvr.Cells[8].Text = "<span style='color:blue;' title='Expend for View'> <img src='../../images/Arrow-Down2.png'></span>";
                    }
                }

                int SrvCount = Convert.ToInt32(hdnSrvCount.Value);

                if (SrvCount > 1)
                {
                    lnkplusRow.Attributes.Add("style", "display:block;");
                    lnkminusRow.Attributes.Add("style", "display:none;");

                    gvr.Cells[9].Text = "<span style='color:blue;' title='Expend for View'> <img src='../../images/Arrow-Down2.png'></span>";
                    gvr.Cells[10].Text = "<span style='color:blue;' title='Expend for View'> <img src='../../images/Arrow-Down2.png'></span>";
                    gvr.Cells[15].Text = hdnSrvReceiveqty.Value;

                    //For Checked Qty
                    StringBuilder sblMergeCheckedQty = new StringBuilder();
                    sblMergeCheckedQty.Append("<table cellspacing='0' cellpadding='0' id='data' style='width:100%' >");

                    sblMergeCheckedQty.Append("<tr><td class='process' style='width: 30px !important;border-bottom: 1px solid #dbd8d8;'>" +
                        "<input readonly type='text' style='cursor:pointer;color:blue;width: 89% !important;' class='test' value='" + (hdnTotalCheckedQty.Value == "0.000" ? "" : hdnTotalCheckedQty.Value) + "' />" + "</td></tr>");


                    sblMergeCheckedQty.Append("</table>");
                    gvr.Cells[16].Text = sblMergeCheckedQty.ToString();

                    gvr.Cells[17].Text = "<span style='color:green'>" + (hdnTotalPassQty.Value == "0.000" ? "" : hdnTotalPassQty.Value) + "</span>";
                    if (hdnTotalHoldQty.Value != "")
                    {
                        gvr.Cells[18].Text = "<span class='backColorYellow'>" + (hdnTotalHoldQty.Value == "0.000" ? "" : hdnTotalHoldQty.Value) + "</span>";
                    }
                    else
                    {
                        gvr.Cells[18].Text = "<span>" + (hdnTotalHoldQty.Value == "0.000" ? "" : hdnTotalHoldQty.Value) + "</span>";
                    }
                    gvr.Cells[19].Text = "<span style='color:red'>" + (hdnTotalFailQty.Value == "0.000" ? "" : hdnTotalFailQty.Value) + "</span>";
                }
                if (ddlstatus.SelectedValue == "1")
                {
                    gvr.CssClass = "rowBackCancel";
                }
                else if (ddlstatus.SelectedValue == "2")
                {
                    gvr.CssClass = "rowBackClose";
                }
                else
                {

                    if (lblCloseMsg.Text == "Cancelled")
                    {
                        System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#fbcba2");
                        String strHtmlColor = System.Drawing.ColorTranslator.ToHtml(c);
                        gvr.BackColor = c;
                    }
                    else if (lblCloseMsg.Text == "Closed")
                    {
                        System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#FFC9C6");
                        String strHtmlColor = System.Drawing.ColorTranslator.ToHtml(c);
                        gvr.BackColor = c;
                    }
                    else
                    {
                        gvr.CssClass = "Unhighlighted";
                        CurrentRow.CssClass = "highlighted";
                    }
                }
            }

            if (e.CommandName == "Plus")
            {

                lnkplus.Attributes.Add("style", "display:none;");
                lnkminus.Attributes.Add("style", "display:block;");

                HiddenField hdnSendQty = (HiddenField)CurrentRow.FindControl("hdnSendQty");
                HiddenField hdnTotalSendChallanQty = (HiddenField)CurrentRow.FindControl("hdnTotalSendChallanQty");
                HiddenField hdnGreigePassQty = (HiddenField)CurrentRow.FindControl("hdnGreigePassQty");
                decimal SendQty = hdnSendQty.Value == "" ? 0 : Convert.ToDecimal(hdnSendQty.Value);
                decimal SendChallanQty = hdnTotalSendChallanQty.Value == "" ? 0 : Convert.ToDecimal(hdnTotalSendChallanQty.Value);
                decimal GreigePassQty = Convert.ToDecimal(hdnGreigePassQty.Value);

                HiddenField hdAccessoryMasterId = (HiddenField)CurrentRow.FindControl("hdAccessoryMasterId");
                HiddenField hdnAccessoryQualitySize = (HiddenField)CurrentRow.FindControl("hdnAccessoryQualitySize");
                HiddenField hdnColorprint = (HiddenField)CurrentRow.FindControl("hdnColorprint");

                int AccessoryMasterId = hdAccessoryMasterId.Value == "" ? 0 : Convert.ToInt32(hdAccessoryMasterId.Value);
                string Size = hdnAccessoryQualitySize.Value.ToString();
                string Color_Print = hdnColorprint.Value.ToString();

                decimal MinimumSendQty = 0;
                if (SendQty > GreigePassQty)
                    MinimumSendQty = GreigePassQty;
                else
                    MinimumSendQty = SendQty;

                decimal RemainingSendQty = MinimumSendQty - SendChallanQty;

                //int RemainingSendQty = SendQty - SendChallanQty;

                int AccessType = 1;

                if (lblAccesstype.Text.Trim() == "Greige")
                    AccessType = 1;
                else if (lblAccesstype.Text.Trim() == "Process")
                    AccessType = 2;
                else if (lblAccesstype.Text.Trim() == "Finish")
                    AccessType = 3;

                if (AccessType == 2)
                {
                    List<AccessoryChallanCls> AccessoryChallanList = objAccessoryWorking.GetRaisedPO_Challan_Detail(SupplierPoId, "SendChallan");

                    if (AccessoryChallanList.Count > 0)
                    {
                        StringBuilder sblSendChallan = new StringBuilder();
                        sblSendChallan.Append("<table cellspacing='0' cellpadding='0' id='data' style='width:100%' >");

                        for (int ChallanNo = 0; ChallanNo < AccessoryChallanList.Count; ChallanNo++)
                        {
                            int SendChallanId = Convert.ToInt32(AccessoryChallanList[ChallanNo].ChallanId);
                            string SendChallanNumber = AccessoryChallanList[ChallanNo].ChallanNumber;

                            if (SendChallanId > 0)
                            {
                                sblSendChallan.Append("<tr><td class='process' style='width: 77px;border-bottom: 1px solid #dbd8d8;'><span style='color:blue;cursor:pointer;' onclick='javascript:ShowAccessorySendChallan(" + SupplierPoId + ", " + SendChallanId + ")'>" + SendChallanNumber + "</span></td></tr>");
                            }
                        }

                        if (RemainingSendQty > 0)
                        {
                            sblSendChallan.Append("<tr><td class='process' style='width: 40px;border-bottom: 1px solid #dbd8d8;'><img src='../../images/edit.png' style='width:12px; cursor:pointer;' onclick='javascript:ShowAccessorySendChallan(" + SupplierPoId + ", " + 0 + ")'></td></tr>");
                        }

                        sblSendChallan.Append("</table>");
                        CurrentRow.Cells[8].Text = sblSendChallan.ToString();
                    }
                }


                List<AccessorySRV> AccessSrvList = objAccessoryWorking.GetRaisedPO_SRV_Detail(SupplierPoId, "SRV");

                //For Unit Gate no
                StringBuilder sblUnitNo = new StringBuilder();
                sblUnitNo.Append("<table id='data' style='width:100%' >");
                for (int SrvNo = 0; SrvNo < AccessSrvList.Count; SrvNo++)
                {
                    sblUnitNo.Append("<tr><td class='process' style='width: 45px;border-bottom: 1px solid #dbd8d8;'>" + AccessSrvList[SrvNo].ReceivedUnitName + " (" + AccessSrvList[SrvNo].GateNo.ToString() + ")</td></tr>");
                }
                sblUnitNo.Append("</table>");
                CurrentRow.Cells[9].Text = sblUnitNo.ToString();

                //For Challan No.(SRV)
                StringBuilder sblChallanNo = new StringBuilder();
                sblChallanNo.Append("<table id='data' style='width:100%' >");
                for (int SrvNo = 0; SrvNo < AccessSrvList.Count; SrvNo++)
                {
                    int SrvId = Convert.ToInt32(AccessSrvList[SrvNo].SRV_Id);
                    sblChallanNo.Append("<tr><td class='process' style='width: 45px;border-bottom: 1px solid #dbd8d8;'><span style='color:blue;cursor:pointer;' onclick='javascript:ShowSrvPopup(" + SupplierPoId + ", " + SrvId + ", " + Status + ")'>A-" + AccessSrvList[SrvNo].SRV_Id.ToString() + "</span></td></tr>");
                }
                sblChallanNo.Append("</table>");
                CurrentRow.Cells[10].Text = sblChallanNo.ToString();

                //For Srv Recieved Qty
                StringBuilder sblRecievedQty = new StringBuilder();
                sblRecievedQty.Append("<table id='data' style='width:100%' >");
                for (int SrvNo = 0; SrvNo < AccessSrvList.Count; SrvNo++)
                {
                    sblRecievedQty.Append("<tr><td class='process' style='width: 45px;border-bottom: 1px solid #dbd8d8;'>" + AccessSrvList[SrvNo].ReceivedQty.ToString() + "</td></tr>");
                }
                sblRecievedQty.Append("</table>");
                CurrentRow.Cells[15].Text = sblRecievedQty.ToString();

                //For Checked Qty
                StringBuilder sblCheckedQty = new StringBuilder();
                sblCheckedQty.Append("<table cellspacing='0' cellpadding='0' id='data' style='width:100%' >");
                for (int SrvNo = 0; SrvNo < AccessSrvList.Count; SrvNo++)
                {
                    int SrvId = Convert.ToInt32(AccessSrvList[SrvNo].SRV_Id);
                    decimal CheckQty = AccessSrvList[SrvNo].InspectionCheckedQty;
                    int UnitId = AccessSrvList[SrvNo].ReceivedUnit;

                    if (CheckQty != 0)
                    {

                        sblCheckedQty.Append("<tr><td class='process' style='width: 30px !important;border-bottom: 1px solid #dbd8d8;'>" +
                           "<input readonly type='text' style='cursor:pointer;color:blue;width: 89% !important;' class='test' value='" + CheckQty.ToString() + "' onclick='javascript:ShowAccessInspectionPopup(" + SupplierPoId + ", " + SrvId + ", " + Status + ", " + UnitId + ")' />" + "</td></tr>");
                    }
                    else
                    {
                        sblCheckedQty.Append("<tr> <td class='process' style='width: 30px !important;border-bottom: 1px solid #dbd8d8;'>" +
                                    "<input readonly type='text' style='cursor:pointer;color:blue;width: 89% !important;' class='test' title='' value='" + "" +
                                    "' onclick='javascript:ShowAccessInspectionPopup(" + SupplierPoId + ", " + SrvId + ", " + Status + ", " + UnitId + ")'/>" + "</td></tr>");
                    }

                }
                sblCheckedQty.Append("</table>");
                CurrentRow.Cells[16].Text = sblCheckedQty.ToString();

                //For Pass Qty
                StringBuilder sblPassQty = new StringBuilder();
                sblPassQty.Append("<table cellspacing='0' cellpadding='0' id='data' style='width:100%' >");
                for (int SrvNo = 0; SrvNo < AccessSrvList.Count; SrvNo++)
                {
                    decimal PassQty = AccessSrvList[SrvNo].PassQty;
                    decimal InspectRaisedDebit = Convert.ToDecimal(AccessSrvList[SrvNo].InspectionRaisedDebit);
                    decimal InspectUsableStock = Convert.ToDecimal(AccessSrvList[SrvNo].InspectionUsableStock);

                    if (PassQty != 0)
                    {
                        if ((InspectRaisedDebit > 0) || (InspectUsableStock > 0))
                        {
                            StringBuilder sRaiseDebit = new StringBuilder();
                            sRaiseDebit.Append("<table cellspacing='0' cellpadding='0' id='data' style='width:100%' >");
                            if (InspectRaisedDebit > 0)
                            {
                                sRaiseDebit.Append("<tr><td><span style='color:white;'>Raise Debit: </span><span style='color:yellow;'>" + InspectRaisedDebit.ToString() + "</span></td></tr>");
                            }
                            if (InspectUsableStock > 0)
                            {
                                sRaiseDebit.Append("<tr><td><span style='color:white;'>Usable Stock: </span><span style='color:black;'>" + InspectUsableStock.ToString() + "</span></td></tr>");
                            }
                            sRaiseDebit.Append("</table>");


                            sblPassQty.Append("<tr><td class='process' style='width: 30px !important;border-bottom: 1px solid #dbd8d8;'><div class='RaiseDebitTooltip'>" +
                            "<span style='color:green; width: 89% !important;' class='test'>" + PassQty.ToString() + "</span>" +
                            "<span id='spnDebittooltip' class='RaiseDebitTooltipText'>" + sRaiseDebit + "</span></td></tr>");
                        }
                        else
                        {
                            sblPassQty.Append("<tr><td class='process' style='width: 30px !important;border-bottom: 1px solid #dbd8d8;'>" +
                            "<span style='color:green; width: 89% !important;' class='test'>" + PassQty.ToString() + "</span>" + "</td></tr>");
                        }
                    }
                    else
                    {
                        sblPassQty.Append("<tr><td class='process' style='width: 30px !important;border-bottom: 1px solid #dbd8d8;'>" +
                        "<span style='color:green; width: 89% !important;' class='test'></span>" + "</td></tr>");
                    }
                }
                sblPassQty.Append("</table>");
                CurrentRow.Cells[17].Text = sblPassQty.ToString();

                //For Hold Qty
                StringBuilder sblHoldQty = new StringBuilder();
                sblHoldQty.Append("<table cellspacing='0' cellpadding='0' id='data' style='width:100%' >");
                for (int SrvNo = 0; SrvNo < AccessSrvList.Count; SrvNo++)
                {
                    decimal HoldQty = AccessSrvList[SrvNo].HoldQty;
                    if (HoldQty != 0)
                    {
                        sblHoldQty.Append("<tr><td class='process' style='width: 30px !important;border-bottom: 1px solid #dbd8d8;'>" +
                        "<span style='width: 89% !important;' class='test backColorYellow'>" + HoldQty.ToString() + "</span>" + "</td></tr>");
                    }
                    else
                    {
                        sblHoldQty.Append("<tr><td class='process' style='width: 30px !important;border-bottom: 1px solid #dbd8d8;'>" +
                        "<span style='width: 89% !important;' class='test'></span>" + "</td></tr>");
                    }
                }
                sblHoldQty.Append("</table>");
                CurrentRow.Cells[18].Text = sblHoldQty.ToString();


                //For Fail Qty
                StringBuilder sblFailQty = new StringBuilder();
                sblFailQty.Append("<table cellspacing='0' cellpadding='0' id='data' style='width:100%' >");
                for (int SrvNo = 0; SrvNo < AccessSrvList.Count; SrvNo++)
                {
                    decimal FailQty = AccessSrvList[SrvNo].FailQty;
                    if (FailQty != 0)
                    {
                        sblFailQty.Append("<tr><td class='process' style='width: 30px !important;border-bottom: 1px solid #dbd8d8;'>" +
                        "<span style='color:red; width: 89% !important;' class='test'>" + FailQty.ToString() + "</span>" + "</td></tr>");// changed FailQty.ToString("N0") 
                    }
                    else
                    {
                        sblFailQty.Append("<tr><td class='process' style='width: 30px !important;border-bottom: 1px solid #dbd8d8;'>" +
                        "<span style='color:red; width: 89% !important;' class='test'></span>" + "</td></tr>");
                    }
                }
                sblFailQty.Append("</table>");
                CurrentRow.Cells[19].Text = sblFailQty.ToString();

            }
            else if (e.CommandName == "Minus")
            {
                HiddenField hdnSrvReceiveqty = (HiddenField)CurrentRow.FindControl("hdnSrvReceiveqty");
                HiddenField hdnTotalCheckedQty = (HiddenField)CurrentRow.FindControl("hdnTotalCheckedQty");
                HiddenField hdnTotalPassQty = (HiddenField)CurrentRow.FindControl("hdnTotalPassQty");
                HiddenField hdnTotalHoldQty = (HiddenField)CurrentRow.FindControl("hdnTotalHoldQty");
                HiddenField hdnTotalFailQty = (HiddenField)CurrentRow.FindControl("hdnTotalFailQty");

                Label lblunitgatenumber = (Label)CurrentRow.FindControl("lblunitgatenumber");
                Label lblChallanNo = (Label)CurrentRow.FindControl("lblChallanNo");
                Label lblSrvReceiveqty = (Label)CurrentRow.FindControl("lblSrvReceiveqty");
                TextBox txtCheckedQty = (TextBox)CurrentRow.FindControl("txtCheckedQty");
                Label lblPassqty = (Label)CurrentRow.FindControl("lblPassqty");
                Label lblOnHoldqty = (Label)CurrentRow.FindControl("lblOnHoldqty");
                Label lblfailqty = (Label)CurrentRow.FindControl("lblfailqty");

                lnkplus.Attributes.Add("style", "display:block;");
                lnkminus.Attributes.Add("style", "display:none;");


                List<AccessorySRV> AccessSrvList = objAccessoryWorking.GetRaisedPO_SRV_Detail(SupplierPoId, "SRV");

                if (AccessSrvList.Count == 1)
                {
                    txtCheckedQty.Visible = true;
                    if (AccessSrvList.Count > 0)
                    {
                        int SrvId = Convert.ToInt32(AccessSrvList[0].SRV_Id);
                        lblunitgatenumber.Text = AccessSrvList[0].ReceivedUnitName + " (" + AccessSrvList[0].GateNo.ToString() + ")";
                        lblSrvReceiveqty.Text = AccessSrvList[0].ReceivedQty.ToString("N0");
                        txtCheckedQty.Text = AccessSrvList[0].InspectionCheckedQty.ToString("N0");

                        lblChallanNo.Text = "<span style='color:blue;cursor:pointer;' onclick='javascript:ShowSrvPopup(" + SupplierPoId + ", " + SrvId + ", " + Status + ")'> A-" + AccessSrvList[0].SRV_Id.ToString() + "</span>";

                        txtCheckedQty.Attributes.Add("onclick", "javascript:ShowAccessInspectionPopup(" + SupplierPoId + ", " + SrvId + ", " + Status + ", " + AccessSrvList[0].ReceivedUnit + ")");

                        if (txtCheckedQty.Text == "0")
                        {
                            txtCheckedQty.Text = "";
                        }
                        lblPassqty.Text = Convert.ToDecimal(AccessSrvList[0].PassQty) == 0 ? "" : Convert.ToDecimal(AccessSrvList[0].PassQty).ToString("N0");
                        lblOnHoldqty.Text = Convert.ToDecimal(AccessSrvList[0].HoldQty) == 0 ? "" : Convert.ToDecimal(AccessSrvList[0].HoldQty).ToString();

                        lblfailqty.Text = Convert.ToDecimal(AccessSrvList[0].FailQty) == 0 ? "" : Convert.ToDecimal(AccessSrvList[0].FailQty).ToString();
                    }
                }
                if (AccessSrvList.Count > 1)
                {
                    CurrentRow.Cells[9].Text = "<span style='color:blue;' title='Expend for View'> <img src='../../images/Arrow-Down2.png'></span>";
                    CurrentRow.Cells[10].Text = "<span style='color:blue;' title='Expend for View'> <img src='../../images/Arrow-Down2.png'></span>";
                }

                CurrentRow.Cells[15].Text = (hdnSrvReceiveqty.Value == "0.000" ? "" : hdnSrvReceiveqty.Value);

                //For Checked Qty
                StringBuilder sblMergeCheckedQty = new StringBuilder();
                sblMergeCheckedQty.Append("<table cellspacing='0' cellpadding='0' id='data' style='width:100%' >");

                sblMergeCheckedQty.Append("<tr><td class='process' style='width: 30px !important;border-bottom: 1px solid #dbd8d8;'>" +
                    "<input readonly type='text' style='cursor:pointer;color:blue;width: 89% !important;' class='test' value='" + (hdnTotalCheckedQty.Value == "0.000" ? "" : hdnTotalCheckedQty.Value) + "' />" + "</td></tr>");


                sblMergeCheckedQty.Append("</table>");
                CurrentRow.Cells[16].Text = sblMergeCheckedQty.ToString();

                CurrentRow.Cells[17].Text = "<span style='color:green'>" + (hdnTotalPassQty.Value == "0.000" ? "" : hdnTotalPassQty.Value) + "</span>";
                if (hdnTotalHoldQty.Value != "" && hdnTotalHoldQty.Value != "0.000")
                {
                    CurrentRow.Cells[18].Text = "<span class='backColorYellow'>" + (hdnTotalHoldQty.Value == "0.000" ? "" : hdnTotalHoldQty.Value) + "</span>";
                }
                else
                {
                    CurrentRow.Cells[18].Text = "<span>" + (hdnTotalHoldQty.Value == "0.000" ? "" : hdnTotalHoldQty.Value) + "</span>";
                }

                CurrentRow.Cells[19].Text = "<span style='color:red'>" + (hdnTotalFailQty.Value == "0.000" ? "" : hdnTotalFailQty.Value) + "</span>";
            }

            else if (e.CommandName == "SendMail")
            {
                SendAccessoryPoMail(SupplierPoId);
            }
        }

        protected void grdraisedpoworking_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSize = (Label)e.Row.FindControl("lblSize");

                if (lblSize.Text != "")
                    lblSize.Text = lblSize.Text == "Default" ? "" : "(" + lblSize.Text + ")";

                Label lblPoNumber = (Label)e.Row.FindControl("lblPoNumber");
                Label lblAccesstype = (Label)e.Row.FindControl("lblAccesstype");
                Label lblbiplsign = (Label)e.Row.FindControl("lblbiplsign");
                Label lblsuppliersign = (Label)e.Row.FindControl("lblsuppliersign");
                Label lblbalanceQty = (Label)e.Row.FindControl("lblbalanceQty");
                Label lblunits = (Label)e.Row.FindControl("lblunits");

                LinkButton lnkplus = (LinkButton)e.Row.FindControl("lnkplus") as LinkButton;
                LinkButton lnkminus = (LinkButton)e.Row.FindControl("lnkminus") as LinkButton;
                LinkButton lnkSrv = (LinkButton)e.Row.FindControl("lnkSrv");
                GridView grdpo = (GridView)e.Row.FindControl("grdpo");
                HyperLink hplk = (HyperLink)e.Row.FindControl("hplk");

                int AccessType = 1;
                int SupplierPoId = DataBinder.Eval(e.Row.DataItem, "SupplierPoId") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SupplierPoId"));
                DataTable dtpo = objAccessoryWorking.Get_SerailNumber_Against_PO(SupplierPoId);
                if (dtpo.Rows.Count > 0)
                {
                    grdpo.DataSource = dtpo;
                    grdpo.DataBind();
                }
                else
                {
                    hplk.Visible = false;
                }
                bool IsPartySignature = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsPartySignature"));
                bool IsAuthorizedSignatory = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsAuthorizedSignatory"));
                int Status = DataBinder.Eval(e.Row.DataItem, "Status") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Status"));

                decimal SendQty = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "SendQty"));
                decimal SendChallanQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalSendChallanQty"));
                decimal GreigePassQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "GreigePassQty"));

                decimal MinimumSendQty = 0;
                if (SendQty > GreigePassQty)
                    MinimumSendQty = GreigePassQty;
                else
                    MinimumSendQty = SendQty;

                decimal RemainingSendQty = MinimumSendQty - SendChallanQty;

                //int RemainingSendQty = SendQty - SendChallanQty;

                int AccessoryMasterId = DataBinder.Eval(e.Row.DataItem, "AccessoryMasterId") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "AccessoryMasterId"));
                string Size = DataBinder.Eval(e.Row.DataItem, "Size").ToString();
                string Color_Print = DataBinder.Eval(e.Row.DataItem, "Color_Print").ToString();
                decimal PoQuantity = DataBinder.Eval(e.Row.DataItem, "ReceivedQty") == DBNull.Value ? 0 : Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ReceivedQty"));
                decimal SrvRecievedQty = DataBinder.Eval(e.Row.DataItem, "TotalQtyRecieved") == DBNull.Value ? 0 : Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalQtyRecieved"));
                decimal ReceivedChallanQty = DataBinder.Eval(e.Row.DataItem, "TotalRecChallanQty") == DBNull.Value ? 0 : Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalRecChallanQty"));
                double ConversionValue = DataBinder.Eval(e.Row.DataItem, "ConversionValue") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ConversionValue"));
                string NewGarmentUnitName = DataBinder.Eval(e.Row.DataItem, "GarmentUnitName").ToString();
                string sDefaultGarmentUnitName = DataBinder.Eval(e.Row.DataItem, "DefaultGarmentUnitName").ToString();
                decimal UsableStock = DataBinder.Eval(e.Row.DataItem, "UsableStockQty") == DBNull.Value ? 0 : Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "UsableStockQty"));
                decimal InspectUsableStockQty = DataBinder.Eval(e.Row.DataItem, "InspectUsableStock") == DBNull.Value ? 0 : Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "InspectUsableStock"));
                // added by rsb on dated 7 june 2022
                decimal TotalFailedQty = DataBinder.Eval(e.Row.DataItem, "TotalFailQty") == DBNull.Value ? 0 : Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalFailQty"));
                // end
                Label lblAccUnitTooltip = (Label)e.Row.FindControl("lblAccUnitTooltip");
                bool IsUnitChange = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "UnitChange"));
                Boolean IsAccessoryGM = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsAccessoryGM"));
                if (IsUnitChange == true)
                {
                    lblunits.Style.Add("background-color", "yellow");
                    string tooltipVal = "This PO moved to different (<span style='color:yellow'> " + sDefaultGarmentUnitName + "</span> to <span style='color:yellow'>" + NewGarmentUnitName + ")</span> unit conversion Value: <span style='color:yellow'>" + ConversionValue.ToString() + "</span>";

                    lblAccUnitTooltip.Attributes.Add("class", "Acctooltiptext");
                    lblAccUnitTooltip.Text = tooltipVal;
                }

                if (lblPoNumber.Text != "")
                {
                    decimal BalanceQty = 0;
                    // Updated TotalFailedQty  by rsb on dated 7 june 2022
                    if (IsAccessoryGM == true)
                    {
                        BalanceQty = PoQuantity - (SrvRecievedQty - ReceivedChallanQty + TotalFailedQty) - UsableStock + TotalFailedQty;
                    }
                    else
                    {
                        BalanceQty = PoQuantity - (SrvRecievedQty - ReceivedChallanQty + TotalFailedQty) - UsableStock + InspectUsableStockQty + TotalFailedQty;
                    }
                    // End
                    //if ((BalanceQty != PoQuantity) && (BalanceQty != 0))
                    if ((BalanceQty <= PoQuantity) && (BalanceQty != 0))
                        lblbalanceQty.Text = BalanceQty.ToString();

                    if (lblAccesstype.Text.Trim() == "Greige")
                        AccessType = 1;
                    else if (lblAccesstype.Text.Trim() == "Process")
                        AccessType = 2;
                    else if (lblAccesstype.Text.Trim() == "Finish")
                        AccessType = 3;

                    string sLink = "ShowPurchaseOrder(" + AccessoryMasterId + ", '" + Size + "', '" + Color_Print + "', " + SupplierPoId + ", " + AccessType + ")";

                    lblPoNumber.Attributes.Add("onclick", sLink);

                    if (IsAuthorizedSignatory != true)
                    {
                        lblbiplsign.Text = "Pndg GM Conf.";
                        lblbiplsign.ForeColor = System.Drawing.Color.Red;
                    }
                    else { lblbiplsign.Text = ""; }
                    if (IsPartySignature != true)
                    {
                        lblsuppliersign.Text = "<br /> Pndg. Supp. conf.";
                        lblsuppliersign.ForeColor = System.Drawing.Color.Red;
                    }
                    else { lblsuppliersign.Text = ""; }

                    if ((lblbiplsign.Text != "") || (lblsuppliersign.Text != ""))
                    {
                        lnkSrv.Style.Add("display", "none");
                    }
                }

                //if ((AccessType == 2) && (Status <= 0))
                if (AccessType == 2)
                {
                    List<AccessoryChallanCls> AccessoryChallanList = objAccessoryWorking.GetRaisedPO_Challan_Detail(SupplierPoId, "SendChallan");
                    int ChallanCount = AccessoryChallanList.Count;

                    if (ChallanCount == 0)
                    {
                        lnkSrv.Style.Add("display", "none");
                        if ((IsAuthorizedSignatory == true) && (IsPartySignature == true))
                        {
                            StringBuilder sblSendChallan = new StringBuilder();
                            sblSendChallan.Append("<table id='data' style='width:100%' >");
                            if (RemainingSendQty > 0)
                            {
                                sblSendChallan.Append("<tr><td class='process' style='min-width: 40px;border-bottom: 1px solid #dbd8d8;'><img src='../../images/edit.png' style='width:12px; cursor:pointer;' onclick='javascript:ShowAccessorySendChallan(" + SupplierPoId + ", " + 0 + ")'></td></tr>");
                            }

                            sblSendChallan.Append("</table>");
                            e.Row.Cells[8].Text = sblSendChallan.ToString();
                        }
                    }

                    if (ChallanCount > 1)
                    {
                        lnkplus.Attributes.Add("style", "display:block;");
                        lnkminus.Attributes.Add("style", "display:none;");

                        e.Row.Cells[8].Text = "<span style='color:blue;' title='Expend for View'> <img src='../../images/Arrow-Down2.png'></span>";
                        if (AccessoryChallanList[0].IsChallanRecieved == false)
                        {
                            lnkSrv.Style.Add("display", "none");
                        }
                    }

                    if ((ChallanCount == 1) && (IsAuthorizedSignatory == true) && (IsPartySignature == true))
                    {
                        if (AccessoryChallanList[0].IsChallanRecieved == false)
                        {
                            lnkSrv.Style.Add("display", "none");
                        }
                        if (AccessoryChallanList.Count > 0)
                        {
                            int SendChallanId = Convert.ToInt32(AccessoryChallanList[0].ChallanId);
                            string SendChallanNumber = AccessoryChallanList[0].ChallanNumber;

                            StringBuilder sblSendChallan = new StringBuilder();
                            sblSendChallan.Append("<table id='data' style='width:100%' >");
                            if (SendChallanId > 0)
                            {
                                sblSendChallan.Append("<tr><td class='process' style='min-width: 40px;border-bottom: 1px solid #dbd8d8;'><span style='color:blue;cursor:pointer;' onclick='javascript:ShowAccessorySendChallan(" + SupplierPoId + ", " + SendChallanId + ")'>" + SendChallanNumber + "</span></td></tr>");
                            }
                            if (RemainingSendQty > 0)
                            {
                                sblSendChallan.Append("<tr><td class='process' style='min-width: 40px;border-bottom: 1px solid #dbd8d8;'><img src='../../images/edit.png' style='width:12px; cursor:pointer;' onclick='javascript:ShowAccessorySendChallan(" + SupplierPoId + ", " + 0 + ")'></td></tr>");
                            }

                            sblSendChallan.Append("</table>");
                            e.Row.Cells[8].Text = sblSendChallan.ToString();
                        }
                    }
                }

                //add code by bharat on 22/10/19 for cancel and close row color
                var selectVal = Convert.ToInt32(ddlstatus.SelectedValue);
                if (Convert.ToString(selectVal) == "1")
                {
                    System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#fbcba2");
                    String strHtmlColor = System.Drawing.ColorTranslator.ToHtml(c);
                    e.Row.BackColor = c;
                }
                if (Convert.ToString(selectVal) == "2")
                {
                    System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#ffc9c6");
                    String strHtmlColor = System.Drawing.ColorTranslator.ToHtml(c);
                    e.Row.BackColor = c;
                }
                //end
                Label lblunitgatenumber = (Label)e.Row.FindControl("lblunitgatenumber");
                Label lblChallanNo = (Label)e.Row.FindControl("lblChallanNo");
                Label lblSrvReceiveqty = (Label)e.Row.FindControl("lblSrvReceiveqty");
                TextBox txtCheckedQty = (TextBox)e.Row.FindControl("txtCheckedQty");
                Label lblPassqty = (Label)e.Row.FindControl("lblPassqty");
                Label lblOnHoldqty = (Label)e.Row.FindControl("lblOnHoldqty");
                Label lblfailqty = (Label)e.Row.FindControl("lblfailqty");

                if (lblOnHoldqty.Text != "")
                {
                    lblOnHoldqty.Attributes.Add("class", "backColorYellow");
                }
                LinkButton lnkCancel = (LinkButton)e.Row.FindControl("lnkCancel") as LinkButton;
                LinkButton lnkClose = (LinkButton)e.Row.FindControl("lnkClose") as LinkButton;

                List<AccessorySRV> AccessSrvList = objAccessoryWorking.GetRaisedPO_SRV_Detail(SupplierPoId, "SRV");


                int SrvCount = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SrvCount"));
                int TotalCheckedQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalCheckedQty"));
                int TotalHoldQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalHoldQty"));

                if (SrvCount == 0)
                {
                    lnkCancel.Attributes.Add("style", "display:block;");
                    lnkCancel.Attributes.Add("OnClick", "javascript:fncCancelPO(" + SupplierPoId + ", 'Cancel')");
                }

                if ((SrvCount > 0) && (SrvRecievedQty == TotalCheckedQty))
                {

                    lnkCancel.Attributes.Add("style", "display:block;");
                    lnkCancel.Attributes.Add("OnClick", "javascript:fncCancelPO(" + SupplierPoId + ", 'Cancel')");
                }
                if (SrvCount > 1)
                {
                    lnkplus.Attributes.Add("style", "display:block;");
                    lnkminus.Attributes.Add("style", "display:none;");

                    e.Row.Cells[9].Text = "<span style='color:blue;' title='Expend for View'> <img src='../../images/Arrow-Down2.png'></span>";
                    e.Row.Cells[10].Text = "<span style='color:blue;' title='Expend for View'> <img src='../../images/Arrow-Down2.png'></span>";
                }
                if (SrvCount == 1)
                {
                    txtCheckedQty.Visible = true;
                    if (AccessSrvList.Count > 0)
                    {
                        int SrvId = Convert.ToInt32(AccessSrvList[0].SRV_Id);
                        lblunitgatenumber.Text = AccessSrvList[0].ReceivedUnitName + " (" + AccessSrvList[0].GateNo.ToString() + ")";
                        lblSrvReceiveqty.Text = AccessSrvList[0].ReceivedQty.ToString("N0");
                        txtCheckedQty.Text = AccessSrvList[0].InspectionCheckedQty.ToString("N0");

                        lblChallanNo.Text = "<span style='color:blue;cursor:pointer;' onclick='javascript:ShowSrvPopup(" + SupplierPoId + ", " + SrvId + ", " + Status + ")'>A-" + AccessSrvList[0].SRV_Id.ToString() + "</span>";

                        txtCheckedQty.Attributes.Add("onclick", "javascript:ShowAccessInspectionPopup(" + SupplierPoId + ", " + SrvId + ", " + Status + ", " + AccessSrvList[0].ReceivedUnit + ")");

                        if (txtCheckedQty.Text == "0")
                        {
                            txtCheckedQty.Text = "";
                        }
                        lblPassqty.Text = Convert.ToDecimal(AccessSrvList[0].PassQty) == 0 ? "" : Convert.ToDecimal(AccessSrvList[0].PassQty).ToString("N0");
                        lblOnHoldqty.Text = Convert.ToDecimal(AccessSrvList[0].HoldQty) == 0 ? "" : Convert.ToDecimal(AccessSrvList[0].HoldQty).ToString();
                        lblfailqty.Text = Convert.ToDecimal(AccessSrvList[0].FailQty) == 0 ? "" : Convert.ToDecimal(AccessSrvList[0].FailQty).ToString();

                        decimal InspectRaisedDebit = Convert.ToDecimal(AccessSrvList[0].InspectionRaisedDebit);
                        decimal InspectUsableStock = Convert.ToDecimal(AccessSrvList[0].InspectionUsableStock);
                        Label lblInspectionTootip = (Label)e.Row.FindControl("lblInspectionTootip");

                        if ((InspectRaisedDebit > 0) || (InspectUsableStock > 0))
                        {
                            StringBuilder sblRaiseDebit = new StringBuilder();
                            sblRaiseDebit.Append("<table cellspacing='0' cellpadding='0' id='data' style='width:100%' >");
                            if (InspectRaisedDebit > 0)
                            {
                                sblRaiseDebit.Append("<tr><td style='border-right:0px !important'><span style='color:white;'>Raise Debit: </span><span style='color:yellow;'>" + InspectRaisedDebit.ToString() + "</span></td></tr>");
                            }
                            if (InspectUsableStock > 0)
                            {
                                sblRaiseDebit.Append("<tr><td style='border-right:0px !important'><span style='color:white;'>Usable Stock: </span><span style='color:black;'>" + InspectUsableStock.ToString() + "</span></td></tr>");
                            }
                            sblRaiseDebit.Append("</table>");
                            lblInspectionTootip.Text = sblRaiseDebit.ToString();
                            lblInspectionTootip.Attributes.Add("class", "RaiseDebitTooltipText");
                        }
                    }
                }

                Label lblDebitNote = (Label)e.Row.FindControl("lblDebitNote");
                Image imgEdit = (Image)e.Row.FindControl("imgEdit");

                List<Accessory_Srv_Bill> Accessory_Debit_BillList = objAccessoryWorking.GetAccessory_Srv_Bill_DropDownList(SupplierPoId, 1);
                if (Accessory_Debit_BillList.Count > 0)
                {
                    var DebitNoteId = 0;
                    lblDebitNote.Text = "<span style='color:blue;cursor:pointer;' title='Show debit Note' onclick='javascript:ShowDebitNotePopup(" + SupplierPoId + ", " + DebitNoteId + ", " + AccessoryMasterId + ")'>Debit Note</span>";
                }
                else
                {
                    lblDebitNote.ToolTip = "No Bill generated hence you can not see the Debit Note";
                }

                List<Accessory_Srv_Bill> Accessory_Credit_BillList = objAccessoryWorking.GetAccessory_List_Against_Debit_Bill(SupplierPoId, 0, "LIST");
                if (Accessory_Credit_BillList.Count > 0)
                {
                    var CreditNoteId = 0;
                    imgEdit.Style.Add("cursor", "pointer");
                    imgEdit.ToolTip = "Show Credit Note";
                    imgEdit.ImageUrl = "../../images/edit.png";
                    imgEdit.Attributes.Add("onclick", "javascript:ShowCreditNotePopup(" + SupplierPoId + ", " + CreditNoteId + ")");
                }
                else
                {
                    imgEdit.Visible = false;
                }

                Label lblCloseMsg = (Label)e.Row.FindControl("lblCloseMsg");
                if ((Status == 1) || (Status == 2))
                {
                    lnkSrv.Style.Add("display", "none");
                    lnkCancel.Attributes.Add("style", "display:none;");
                    lnkClose.Attributes.Add("style", "display:none;");

                    //txtCheckedQty.Attributes.Remove("onclick");
                    if (Status == 1)
                    {
                        lblCloseMsg.Text = "Cancelled";
                        grdraisedpoworking.Columns[21].Visible = true;

                        System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#fbcba2");
                        String strHtmlColor = System.Drawing.ColorTranslator.ToHtml(c);
                        e.Row.BackColor = c;
                    }
                    else if (Status == 2)
                    {
                        lblCloseMsg.Text = "Closed";
                        //grdraisedpoworking.Columns[21].Visible = false;

                        System.Drawing.Color c = System.Drawing.ColorTranslator.FromHtml("#FFC9C6");
                        String strHtmlColor = System.Drawing.ColorTranslator.ToHtml(c);
                        e.Row.BackColor = c;
                    }
                }
                else
                {
                    lnkSrv.Attributes.Add("onclick", "ShowSrvPopup(" + SupplierPoId + ", 0, " + Status + ")");
                    //grdraisedpoworking.Columns[21].Visible = false;
                }

                if (TotalHoldQty > 0)
                {
                    lnkCancel.Attributes.Add("style", "display:none;");
                    lnkClose.Attributes.Add("style", "display:none;");
                }
            }
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            //bindgrd();
        }

        protected void grdraisedpoworking_DataBound(object sender, EventArgs e)
        {
            for (int i = grdraisedpoworking.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdraisedpoworking.Rows[i];
                GridViewRow previousRow = grdraisedpoworking.Rows[i - 1];
                string CurrentAccessory = "";
                string PreviousAccessory = "";

                HiddenField hdAccessoryMasterId = (HiddenField)row.FindControl("hdAccessoryMasterId");
                HiddenField hdnAccessoryQualitySize = (HiddenField)row.FindControl("hdnAccessoryQualitySize");
                HiddenField hdnColorprint = (HiddenField)row.FindControl("hdnColorprint");
                CurrentAccessory = hdAccessoryMasterId.Value + hdnAccessoryQualitySize.Value.Trim() + hdnColorprint.Value.Trim();

                HiddenField hdAccessoryMasterId_Previous = (HiddenField)previousRow.FindControl("hdAccessoryMasterId");
                HiddenField hdnAccessoryQualitySize_Previous = (HiddenField)previousRow.FindControl("hdnAccessoryQualitySize");
                HiddenField hdnColorprint_Previous = (HiddenField)previousRow.FindControl("hdnColorprint");
                PreviousAccessory = hdAccessoryMasterId_Previous.Value + hdnAccessoryQualitySize_Previous.Value.Trim() + hdnColorprint_Previous.Value.Trim();

                if (CurrentAccessory == PreviousAccessory)
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

            }

        }



        #region Mail Function by sanjeev

        public void SendAccessoryPoMail(int SupplierPO_Id)
        {
            AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
            DataTable Dt = objAccessoryWorking.Get_AccessoryPODetail(SupplierPO_Id);
            if (Dt.Rows.Count > 0)
            {
                string PO_Number = Dt.Rows[0]["PO_Number"].ToString();
                string AccessoryType = Dt.Rows[0]["AccessoryType"].ToString();
                string AccessoryStage = Dt.Rows[0]["AccessoryStage"].ToString();
                string AccessoryMasterId = Dt.Rows[0]["AccessoryMasterId"].ToString();
                string Size = Dt.Rows[0]["Size"].ToString();
                string Color_Print = Dt.Rows[0]["Color_Print"].ToString();
                string PoStatus = Dt.Rows[0]["PoStatus"].ToString();
                string SupplierEmail = Dt.Rows[0]["SupplierEmail"].ToString();
                string AccessoryQualityName = Dt.Rows[0]["AccessoryQualityName"].ToString();
                randorccessoryHtmlAndSendMail(PO_Number, AccessoryType, AccessoryStage, AccessoryMasterId, AccessoryQualityName, Size, Color_Print, SupplierPO_Id.ToString(), PoStatus, SupplierEmail);
            }

        }
        public void randorccessoryHtmlAndSendMail(string AccessoryPoNo, string AccessoryType, string AccessoryStage, string AccessoryMasterId, string AccessoryQualityName, string Size, string ColorPrint, string SupplierPoId, string PoStatus, string SupplierEmail)
        {
            LogFileWrite("Render Html Start");
            WebRequest Request;
            WebResponse Response;
            StreamReader reader;
            string strHTML;
            string RequestUrl = host + "/AccessoryPdfFile/AccessoryPurchaseOrderPdf.aspx?AccessoryType=" + AccessoryType + "&AccessoryMasterId=" + AccessoryMasterId + "&Size=" + Size + "&ColorPrint=" + ColorPrint + "&SupplierPoId=" + SupplierPoId;
            Request = WebRequest.Create(RequestUrl);
            LogFileWrite("Request Url:- " + RequestUrl);
            Request.Timeout = Convert.ToInt32(99999999);
            Response = Request.GetResponse();
            reader = new StreamReader(Response.GetResponseStream());
            strHTML = reader.ReadToEnd();
            LogFileWrite("Response Html:- " + strHTML);
            genertaeAccessoryPdf(strHTML, "ss", AccessoryPoNo);
            SendAccessoryPoEmail(AccessoryPoNo, SupplierEmail, AccessoryQualityName, AccessoryStage, PoStatus);
        }

        public void genertaeAccessoryPdf(string HTMLCode, string PolicyFile, string AccessoryPoNo)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Accessory/" + "POAccessory_" + AccessoryPoNo + ".pdf");
            HTMLCode = getAccessoryImage(HTMLCode);
            getvartypeAccessoryHTML(HTMLCode, strFileName, AccessoryPoNo);
        }

        public void getvartypeAccessoryHTML(string HTMLCode, string PolicyFile, string AccessoryPoNo)
        {
            try
            {
                LogFileWrite("getvartypeAccessoryHTML Start:- ");
                string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Accessory/" + "POAccessory_" + AccessoryPoNo + ".pdf");
                LogFileWrite("getvartypeAccessoryHTML FileName:- " + strFileName);
                using (IPechkin pechkin = Factory.Create(new GlobalConfig()))
                {
                    var pdf = pechkin.Convert(new ObjectConfig()
                                            .SetLoadImages(true)
                                            .SetZoomFactor(1.5)
                                            .SetPrintBackground(true)
                                            .SetScreenMediaType(true)
                                            .SetCreateExternalLinks(true), (HTMLCode));
                    LogFileWrite("pechkin Pdf Start:- ");
                    using (FileStream file = System.IO.File.Create(strFileName))
                    {
                        file.Write(pdf, 0, pdf.Length);
                    }
                }
                LogFileWrite("getvartypeAccessoryHTML End:- ");
            }
            catch (Exception ex)
            {
                LogFileWrite("Error occur in getvartypeAccessoryHTML on :- " + ex.Message);
            }
        }
        public string getAccessoryImage(string input)
        {
            if (input == null)
                return string.Empty;
            string tempInput = input;
            string pattern = @"<img(.|\n)+?>";
            string src = string.Empty;
            HttpContext context = HttpContext.Current;
            foreach (Match m in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.RightToLeft))
            {
                if (m.Success)
                {
                    string tempM = m.Value;
                    string pattern1 = "src=[\'|\"](.+?)[\'|\"]";
                    Regex reImg = new Regex(pattern1, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    Match mImg = reImg.Match(m.Value);
                    if (mImg.Success)
                    {
                        src = mImg.Value.ToLower().Replace("src=", "").Replace("\"", "");
                        if (src == "../../signatured.jpg" || src == "../signatured.jpg")
                        {
                            string imgsrc = @Server.MapPath("~/Signature/SignatureD.jpg");
                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src == "../../signdt.jpg" || src == "../signdt.jpg")
                        {
                            string imgsrc = @Server.MapPath("~/Signature/signdt.jpg");
                            src = "src=\"" + imgsrc + "\"";
                        }
                        if (src.ToLower().Contains("http://") == false)
                        {
                            try
                            {
                                tempM = tempM.Remove(mImg.Index, mImg.Length);
                                tempM = tempM.Insert(mImg.Index, src);
                                tempInput = tempInput.Remove(m.Index, m.Length);
                                tempInput = tempInput.Insert(m.Index, tempM);
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                            }
                        }
                    }
                }
            }
            return tempInput;
        }


        public Boolean SendAccessoryPoEmail(string AccessoryPoNo, string SupplierEmail, string AccessoryQualityName, string AccessoryStage, string PoStatus)
        {
            try
            {
                LogFileWrite("SendAccessoryPoEmail Start:- ");
                string PoPath = string.Empty;
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                List<String> to = new List<String>();
                string email = SupplierEmail;
                to.Add(email);
                List<Attachment> atts = new List<Attachment>();
                if (File.Exists(Constants.ACCESSORY_FOLDER_PATH + "POAccessory_" + AccessoryPoNo + ".pdf"))
                {
                    PoPath = Path.Combine(Constants.ACCESSORY_FOLDER_PATH, "POAccessory_" + AccessoryPoNo + ".pdf");
                    atts.Add(new Attachment(PoPath));
                }
                this.SendAccessoryEmail(fromName, to, atts, false, false, AccessoryPoNo, AccessoryQualityName, AccessoryStage, PoStatus);
                LogFileWrite("SendAccessoryPoEmail End:- ");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return false;
            }
        }

        public Boolean SendAccessoryEmail(String FromEmail, List<String> To, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync, string AccessoryPoNo, string AccessoryQualityName, string AccessoryStage, string PoStatus)
        {
            string MailType = "Accessory PO";
            AccessoryQualityName = AccessoryQualityName.Contains('(') ? AccessoryQualityName.Substring(0, AccessoryQualityName.IndexOf('(')) : AccessoryQualityName;
            //System.Diagnostics.Debugger.Break();
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = MailType + " (" + AccessoryPoNo + ")";
            if (PoStatus == "1")
            {
                mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a <span style='color:gray'>Purchase Order</span><span style='color:#2f5597'> " + AccessoryPoNo + "</span> is canceled for <span style='color:gray'>" + "Accessory Quality - </span><span style='color:#2f5597'>" + AccessoryQualityName + "</span><span style='color:gray'> for stage </span> <span style='color:#2f5597'> " + AccessoryStage + "</span>. Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> Disclaimer: This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
            }
            else
            {
                mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a <span style='color:gray'>Purchase Order</span><span style='color:#2f5597'> " + AccessoryPoNo + "</span> is raised for <span style='color:gray'>" + "Accessory Quality - </span><span style='color:#2f5597'>" + AccessoryQualityName + "</span><span style='color:gray'> for stage </span> <span style='color:#2f5597'> " + AccessoryStage + "</span>. Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> Disclaimer: This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
            }
            mailMessage.IsBodyHtml = true;

            if (hasAppendAttachment && Attachments != null)
            {
                int i = 1;
                foreach (Attachment attachment in Attachments)
                {
                    if (attachment.ContentStream.Length > 0)
                    {
                        LinkedResource imageId = new LinkedResource(attachment.ContentStream, "image/jpeg");
                        imageId.ContentId = "imageId" + i.ToString();
                        imageId.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
                        //htmlView.LinkedResources.Add(imageId);
                    }
                    i++;
                }
            }
            else
            {
                mailMessage.Body = mailMessage.Body;
            }
            Boolean isDebug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);
            //Boolean isDebug = false;
            if (isDebug)
            {
                // TODO
                mailMessage.To.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.Bcc.Add(Constants.WEBMASTER_EMAIL);
                mailMessage.CC.Add("itsupport@boutique.in");
            }
            else
            {
                foreach (String to in To)
                    mailMessage.To.Add(to);
                mailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.CC.Add("bipl_accessories@boutique.in");
            }
            SmtpClient smtpClient = new SmtpClient(Constants.SMTP_HOST, Constants.SMTP_PORT);
            if (!hasAppendAttachment && Attachments != null)
            {
                foreach (Attachment att in Attachments) { mailMessage.Attachments.Add(att); }
            }
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Timeout = Constants.SMTP_TIMEOUT;

            if (Constants.SMTP_SECURE) { smtpClient.EnableSsl = true; }

            if (Constants.SMTP_IS_AUTH_REQUIRED)
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(Constants.SMTP_USERNAME, Constants.SMTP_PASSWORD);
            }
            try
            {
                smtpClient.Timeout = 300000;
                smtpClient.Send(mailMessage);
                System.Diagnostics.Trace.WriteLine("Email Having Subject of --" + MailType.ToString() + " is send successfully on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Some error has been occur in Email having subject of ---" + MailType.ToString() + " On" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                System.Diagnostics.Trace.WriteLine("Sorry !! Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                return false;
            }
            finally
            {
                try
                {
                    if (Attachments != null) { foreach (Attachment att in Attachments) { att.Dispose(); } Attachments = null; }
                    foreach (Attachment att in mailMessage.Attachments) { att.Dispose(); }
                    mailMessage = null;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
        }

        public static void LogFileWrite(string message)
        {
            FileStream fileStream = null;
            StreamWriter streamWriter = null;
            try
            {
                string logFilewithname = "POAccessory_SanjeevTest" + ".txt";
                string logFilePath = HttpContext.Current.Server.MapPath("~/Uploads/fits/" + "" + logFilewithname);

                if (logFilePath.Equals("")) return;
                #region Create the Log file directory if it does not exists
                DirectoryInfo logDirInfo = null;
                FileInfo logFileInfo = new FileInfo(logFilePath);
                logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
                if (!logDirInfo.Exists) logDirInfo.Create();
                #endregion Create the Log file directory if it does not exists


                if (!logFileInfo.Exists) { fileStream = logFileInfo.Create(); }
                else { fileStream = new FileStream(logFilePath, FileMode.Append); }
                streamWriter = new StreamWriter(fileStream);
                streamWriter.WriteLine("Datetime of Log : " + DateTime.Now.ToString() + Environment.NewLine + " Message:- " + message + Environment.NewLine + Environment.NewLine);

            }
            catch
            {
            }
            finally
            {
                if (streamWriter != null) streamWriter.Close();
                if (fileStream != null) fileStream.Close();
            }
        }

        #endregion
    }
}