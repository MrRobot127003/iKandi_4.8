using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using System.Data;
using iKandi.Web.Components;

namespace iKandi.Web.Internal.Accessory
{
    public partial class AccessoryPurchaseOrderView : BasePage
    {
        public int SupplierPoId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["SupplierPoId"]))
                {
                    return Convert.ToInt32(Request.QueryString["SupplierPoId"]);
                }
                return -1;
            }
        }
        public int AccessoryMasterId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["AccessoryMasterId"]))
                {
                    return Convert.ToInt32(Request.QueryString["AccessoryMasterId"]);
                }
                return -1;
            }
        }
        public string Size
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Size"]))
                {
                    return Request.QueryString["Size"].ToString();
                }
                return "";
            }
        }
        public string ColorPrint
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["ColorPrint"]))
                {
                    return Request.QueryString["ColorPrint"].ToString();
                }
                return "";
            }
        }
        public int AccessoryType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["AccessoryType"]))
                {
                    return Convert.ToInt32(Request.QueryString["AccessoryType"]);
                }
                return -1;
            }
        }
        public int QtyToOrder
        {
            get;
            set;
        }

        public double Shrinkage;
        public double Wastage;

        AccessoryWorkingController objAccessory = new AccessoryWorkingController();
        AccessoryQualityController objAccessQuality = new AccessoryQualityController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (!IsPostBack)
            {
                hdnSupplierPoId.Value = SupplierPoId.ToString();
                ViewState["dtEta"] = null;
                BindSupplier();
                BindDDLUnit();
                BindData();
                Bind_Eta_History();
                DataTable dt = objAccessory.Getbipladdress("BIPLAddress4");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();
            }
        }

        private void BindSupplier()
        {
            List<AccessoryPending> AccessSupplierList = objAccessory.GetAccessory_ListedSupplier(AccessoryMasterId, Size, ColorPrint, AccessoryType);
            ddlSupplierName.DataSource = AccessSupplierList;
            ddlSupplierName.DataValueField = "SupplierId";
            ddlSupplierName.DataTextField = "SupplierNameWithRate";
            ddlSupplierName.DataBind();
            ddlSupplierName.Items.Insert(0, new ListItem("Select", "-1"));
        }

        private void BindDDLUnit()
        {
            DataTable dt = objAccessory.Get_AccessoryUnit(-1);
            ddlAccessUnit.DataSource = dt;
            ddlAccessUnit.DataTextField = "UnitName";
            ddlAccessUnit.DataValueField = "GroupUnitID";
            ddlAccessUnit.DataBind();
            ddlAccessUnit.Items.Insert(0, new ListItem("Select", "-1"));
        }

        private void BindData()
        {
            List<AccessoryPending> AccessList = objAccessory.GetAccessory_SupplierPurchaseOrder(AccessoryMasterId, Size, ColorPrint, SupplierPoId, AccessoryType);


            if (AccessList[0].Status == 1) { PoWaterMark.Visible = true; }

            lblPoNo.Text = AccessList[0].PoNumber;
            hdnPoNo.Value = AccessList[0].PoNumber;
            hdnSupplierPoId.Value = AccessList[0].SupplierPoId.ToString();
            txtPoDate.Text = Convert.ToDateTime(AccessList[0].PoDate) == DateTime.MinValue ? DateTime.Now.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(AccessList[0].PoDate).ToString("dd MMM yy (ddd)");
            txtETADate.Text = Convert.ToDateTime(AccessList[0].PoEta) == DateTime.MinValue ? DateTime.Now.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(AccessList[0].PoEta).ToString("dd MMM yy (ddd)");
            hdnEtaDate.Value = Convert.ToDateTime(AccessList[0].PoEta) == DateTime.MinValue ? DateTime.Now.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(AccessList[0].PoEta).ToString("dd MMM yy (ddd)");
            hdnSrvCount.Value = AccessList[0].SrvCount.ToString();
            lblRemarksAcc.Text = AccessList[0].AccessoryRemarks;
            lblClientCode.Text = AccessList[0].ClientCode;
            //RajeevS 13022023
            string HSNCode = AccessList[0].HSNCode;
            if (HSNCode == "")
            { 
                spn_HSNCode.InnerHtml = "";
                lblHSNCode.Visible = false;
            
            }
            else
            {
                lblHSNCode.Visible = true;
                lblHSNCode.Text = HSNCode;
                spn_HSNCode.InnerHtml = "HSNcode";

            }
            //RajeevS

            if (Convert.ToDateTime(AccessList[0].PoDate) != DateTime.MinValue)
            {
                txtPoDate.Attributes.Add("disabled", "disabled");
            }
            if (AccessList[0].HistoryExist == 1)
            {
                ShowImgHis.Visible = true;
            }
            hdnSupplierId.Value = AccessList[0].SupplierId.ToString();
            if (AccessList[0].SupplierId > 0)
            {
                ddlSupplierName.SelectedValue = AccessList[0].SupplierId.ToString();
                ddlSupplierName.Attributes.Add("disabled", "disabled");
            }

            lblAccessoryQuality.Text = AccessList[0].AccessoryName;
            if (AccessList[0].Size != "")
                lblSize.Text = AccessList[0].Size == "Default" ? "" : "(" + AccessList[0].Size + ")";

            lblcolorprint.Text = AccessList[0].Color_Print;

            if (SupplierPoId > 0)
            {
                lblShrinkage.Text = AccessList[0].Shrinkage == 0 ? "" : AccessList[0].Shrinkage.ToString();
                hdnShrinkage.Value = AccessList[0].Shrinkage.ToString();
                lblWastage.Text = AccessList[0].Wastage == 0 ? "" : AccessList[0].Wastage.ToString();
            }
            else
            {
                lblShrinkage.Text = Shrinkage == 0 ? "" : Shrinkage.ToString();
                hdnShrinkage.Value = Shrinkage.ToString();
                lblWastage.Text = Wastage == 0 ? "" : Wastage.ToString();
            }

            if (AccessoryType == 1)
            {
                lblAccessType.Text = "Greige";
                Order_text.InnerHtml = "Purchase Order";
            }
            else if (AccessoryType == 2)
            {
                lblAccessType.Text = "Process";
                Order_text.InnerHtml = "Process Order";

            }
            else if (AccessoryType == 3)
            {
                lblAccessType.Text = "Finish";
                Order_text.InnerHtml = "Purchase Order";

            }
            if (AccessoryType == 2)
            {
                if (AccessList[0].SendQty > 0)
                {
                    if (AccessList[0].UnitChange)
                    {
                        txtsentQty.Text = AccessList[0].New_SendQty.ToString("#,##0");
                        hdnSendQty.Value = AccessList[0].New_SendQty.ToString();
                        hdnCancel_SendQty.Value = AccessList[0].New_SendQty.ToString();
                        hdnConversionVal.Value = AccessList[0].ConversionValue.ToString();
                    }
                    else
                    {
                        txtsentQty.Text = AccessList[0].SendQty.ToString("#,##0");
                        hdnSendQty.Value = AccessList[0].SendQty.ToString();
                        hdnCancel_SendQty.Value = AccessList[0].SendQty.ToString();
                    }

                    hdnSendBase.Value = (AccessList[0].SendQty + QtyToOrder).ToString();
                    hdnSend_CalBase.Value = AccessList[0].SendQty.ToString();
                }
                else
                {
                    hdnSendBase.Value = QtyToOrder.ToString();
                    hdnSend_CalBase.Value = QtyToOrder.ToString();
                    hdnSendQty.Value = QtyToOrder.ToString();
                    hdnCancel_SendQty.Value = QtyToOrder.ToString();
                    txtsentQty.Text = QtyToOrder == 0 ? "" : QtyToOrder.ToString("#,##0");
                }
                int SendQty = Convert.ToInt32(hdnSendQty.Value);
                int RecievedQty = 0;
                int RecievedBaseQty = 0;
                //if (AccessList[0].Shrinkage > 0)
                //{
                //    RecievedQty = Convert.ToInt32(Convert.ToDouble(SendQty) - ((Convert.ToDouble(SendQty) * Convert.ToDouble(AccessList[0].Shrinkage)) / 100));
                //    RecievedBaseQty = Convert.ToInt32(Convert.ToDouble(hdnSend_CalBase.Value) - ((Convert.ToDouble(hdnSend_CalBase.Value) * Convert.ToDouble(AccessList[0].Shrinkage)) / 100));
                //}
                //else
                //{
                //    RecievedQty = SendQty;
                //    RecievedBaseQty = Convert.ToInt32(hdnSend_CalBase.Value);
                //}
                Shrinkage = AccessList[0].Shrinkage == 0 ? Shrinkage : AccessList[0].Shrinkage;
                if (Shrinkage > 0)
                {
                    RecievedQty = Convert.ToInt32(Convert.ToDouble(SendQty) - ((Convert.ToDouble(SendQty) * Convert.ToDouble(Shrinkage)) / 100));
                    RecievedBaseQty = Convert.ToInt32(Convert.ToDouble(hdnSend_CalBase.Value) - ((Convert.ToDouble(hdnSend_CalBase.Value) * Convert.ToDouble(Shrinkage)) / 100));
                }
                else
                {
                    RecievedQty = SendQty;
                    RecievedBaseQty = Convert.ToInt32(hdnSend_CalBase.Value);
                }

                hdnReceived_CalBase.Value = RecievedBaseQty.ToString();
                hdnReceivedBase.Value = RecievedBaseQty.ToString();
                hdnReceivedQty.Value = RecievedQty.ToString();
                hdnCancel_ReceivedQty.Value = RecievedQty.ToString();
                txtReceivedqty.Text = RecievedQty.ToString("#,##0");
                txtReceivedqty.Attributes.Add("readonly", "readonly");
            }
            else
            {
                if (AccessList[0].ReceivedQty > 0)
                {
                    if (AccessList[0].UnitChange)
                    {
                        hdnUnitChange.Value = "1";
                        hdnReceivedQty.Value = AccessList[0].New_RecievedQty.ToString();
                        hdnCancel_ReceivedQty.Value = AccessList[0].New_RecievedQty.ToString();
                        txtReceivedqty.Text = AccessList[0].New_RecievedQty.ToString("#,##0");
                        hdnConversionVal.Value = AccessList[0].ConversionValue.ToString();
                    }
                    else
                    {
                        hdnUnitChange.Value = "0";
                        hdnReceivedQty.Value = AccessList[0].ReceivedQty.ToString();
                        hdnCancel_ReceivedQty.Value = AccessList[0].ReceivedQty.ToString();
                        txtReceivedqty.Text = AccessList[0].ReceivedQty.ToString("#,##0");
                    }

                    hdnReceivedBase.Value = (AccessList[0].ReceivedQty + QtyToOrder).ToString();
                    hdnReceived_CalBase.Value = AccessList[0].ReceivedQty.ToString();
                }
                else
                {
                    hdnReceivedBase.Value = QtyToOrder.ToString();
                    hdnReceived_CalBase.Value = QtyToOrder.ToString();
                    hdnReceivedQty.Value = QtyToOrder.ToString();
                    hdnCancel_ReceivedQty.Value = QtyToOrder.ToString();
                    txtReceivedqty.Text = QtyToOrder == 0 ? "" : QtyToOrder.ToString("#,##0");
                }
            }
            if (AccessList[0].GarmentUnit > 0)
            {
                if (AccessList[0].UnitChange)
                {
                    hdnUnitChange.Value = "1";
                    ddlAccessUnit.SelectedValue = AccessList[0].New_GarmentUnit.ToString();
                    hdnAccessUnitVal.Value = AccessList[0].New_GarmentUnit.ToString();
                }
                else
                {
                    ddlAccessUnit.SelectedValue = AccessList[0].GarmentUnit.ToString();
                    hdnAccessUnitVal.Value = AccessList[0].GarmentUnit.ToString();
                    hdnUnitChange.Value = "0";
                }
                hdnBaseAccessUnitVal.Value = AccessList[0].GarmentUnit.ToString();
                hdnAccessUnitName.Value = AccessList[0].GarmentUnitName;

                if (AccessList[0].SupplierId > 0)
                {
                    ddlAccessUnit.Attributes.Remove("disabled");
                }
                else
                {
                    ddlAccessUnit.Attributes.Add("disabled", "disabled");
                }
            }

            if (AccessList[0].FinalRate > 0)
            {
                txtRate.Text = AccessList[0].FinalRate.ToString();
                if (AccessList[0].UnitChange)
                {
                    lblTotalAmount.Text = (AccessList[0].New_RecievedQty * AccessList[0].FinalRate).ToString("#,##0");
                }
                else
                {
                    lblTotalAmount.Text = (AccessList[0].ReceivedQty * AccessList[0].FinalRate).ToString("#,##0");
                }
                AddIndianCurrency.Attributes.Add("class", "AddCuurency");
            }

            if (AccessList[0].IsAuthorizedSignatory == true)
            {
                divAuthorizedSigchk.Visible = false;
                divAuthorizedSig.Visible = true;
                foreach (var user in ApplicationHelper.Users)
                {
                    if (AccessList[0].AuthorizedSignatureBy == user.UserID)
                    {
                        lblAuthorizedName.Text = user.FirstName + " " + user.LastName;
                        imgAuthorizedSignatory.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                        if (AccessList[0].AuthorizedSignatureDate != DateTime.MinValue)
                            lblAuthorizedDate.Text = AccessList[0].AuthorizedSignatureDate.ToString("dd MMM yy (ddd)");
                    }
                }
            }

            if (AccessList[0].IsPartySignature == true)
            {
                divPartySigchk.Visible = false;
                divPartySig.Visible = true;
                //foreach (var user in ApplicationHelper.Users)
                //{
                //    if (AccessList[0].PartySignatureBy == user.UserID)
                //    {
                //        lblPartyName.Text = user.FirstName + " " + user.LastName;
                //        imgpartysingature.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                //        if (AccessList[0].PartySignatureDate != DateTime.MinValue)
                //            lblPartyDate.Text = AccessList[0].PartySignatureDate.ToString("dd MMM yy (ddd)");
                //    }
                //}
                if (AccessList[0].PartySignatureBy > 0)
                {
                    var user = ApplicationHelper.Users.Where(x => x.UserID == AccessList[0].PartySignatureBy).FirstOrDefault();
                    if (user != null)
                    {
                        lblPartyName.Text = user.FirstName + " " + user.LastName + "</br>" + " <span style=Font-size:8px;>(On Behalf of " + AccessList[0].SupplierName + ")</span>";

                        //lblPartyName.Style.Add("font-size", "8px");

                        imgpartysingature.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                        if (AccessList[0].PartySignatureDate != DateTime.MinValue)
                            lblPartyDate.Text = AccessList[0].PartySignatureDate.ToString("dd MMM yy (ddd)");

                    }
                }
            }
            if ((AccessList[0].IsAuthorizedSignatory == true) && (AccessList[0].IsPartySignature == true))
            {
                ddlAccessUnit.Attributes.Add("disabled", "disabled");
            }

            if (hdnUnitChange.Value == "1")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "ChangeColorDropDown();", true);
                //ddlAccessUnit.ToolTip = "yellow color for you have moved to different unit " + ddlAccessUnit.SelectedItem.Text + " " + Math.Round(AccessList[0].ConversionValue, 3);
                ddlAccessUnit.ToolTip = "Unit Changed (Conversion Value: " + Math.Round(AccessList[0].ConversionValue, 3) + ")";
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "BaseColorDropDown();", true);
            }
        }

        private void Bind_Eta_History()
        {
            DataTable dtEta = new DataTable();
            int SupplierPoId = hdnSupplierPoId.Value == "" ? -1 : Convert.ToInt32(hdnSupplierPoId.Value);
            DataSet ds = objAccessory.GetAccessory_SupplierPurchase_Eta_History(SupplierPoId, AccessoryType);
            DataTable dtHistory = ds.Tables[0];

            if (dtHistory.Rows.Count > 0)
            {
                grdHistoryQty.DataSource = dtHistory;
                grdHistoryQty.DataBind();
                dvHeader.InnerHtml = "History Of Revise Purchase Order";
                dvHeader.Style.Add("display", "");
                if ((AccessoryType == 1) || (AccessoryType == 3))
                {
                    grdHistoryQty.Columns[1].Visible = false;
                }
            }
            if (ViewState["dtEta"] == null)
            {
                dtEta = ds.Tables[1];
                if (dtEta.Rows.Count > 0)
                {
                    ViewState["dtEta"] = dtEta;
                }
                else
                {
                    DataRow dr = dtEta.NewRow();
                    dr["SupplierPO_ETA_Id"] = 1;
                    dr["SupplierPO_Id"] = SupplierPoId;
                    dr["RowNumber"] = 1;
                    dr["FromQty"] = 1;
                    dr["ToQty"] = hdnReceivedQty.Value == "" ? -1 : Convert.ToInt32(hdnReceivedQty.Value);

                    dr["POETADate"] = DateTime.ParseExact(txtETADate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
                    dtEta.Rows.Add(dr);
                    ViewState["dtEta"] = dtEta;
                }
            }
            dtEta = (DataTable)ViewState["dtEta"];
            grdQtyRange.DataSource = dtEta;
            grdQtyRange.DataBind();

            DataTable dtPOInstruction = ds.Tables[2];
            divguidline.InnerHtml = dtPOInstruction.Rows[0]["value"].ToString();
        }

        protected void grdQtyRange_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int iRowIndex = e.Row.RowIndex;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label lblHdrFromQty = (Label)e.Row.FindControl("lblHdrFromQty");
                Label lblHdrToQty = (Label)e.Row.FindControl("lblHdrToQty");
                if (ddlAccessUnit.SelectedValue != "-1")
                {
                    lblHdrFromQty.Text = "From Qty." + " (" + ddlAccessUnit.SelectedItem.Text.Trim() + ")";
                    lblHdrToQty.Text = "To Qty." + " (" + ddlAccessUnit.SelectedItem.Text.Trim() + ")";
                }
                else
                {
                    lblHdrFromQty.Text = "From Qty.";
                    lblHdrToQty.Text = "To Qty.";
                }
            }
            if ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == DataControlRowState.Alternate))
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblFromQty = (Label)e.Row.FindControl("lblFromQty");
                    Label lblToQty = (Label)e.Row.FindControl("lblToQty");
                    if (lblFromQty.Text != "")
                    {
                        lblFromQty.Text = Convert.ToInt32(lblFromQty.Text).ToString("N0");
                    }
                    if (lblToQty.Text != "")
                    {
                        lblToQty.Text = Convert.ToInt32(lblToQty.Text).ToString("N0");
                    }

                }
            }

        }

        protected void grdHistoryQty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSendQty = (Label)e.Row.FindControl("lblSendQty");
                Label lblPoQuantity = (Label)e.Row.FindControl("lblPoQuantity");

                int SendQty = DataBinder.Eval(e.Row.DataItem, "SendQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "SendQty"));
                int POQuantity = DataBinder.Eval(e.Row.DataItem, "POQuantity") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "POQuantity"));
                string UnitName = DataBinder.Eval(e.Row.DataItem, "UnitName").ToString();

                if (SendQty != 0)
                {
                    string sQuantity = SendQty.ToString("#,##0") + " <span style='color:gray;font-weight:600'>" + UnitName + "</span>";
                    lblSendQty.Text = sQuantity;
                }
                if (POQuantity != 0)
                {
                    string sQuantity = POQuantity.ToString("#,##0") + " <span style='color:gray;font-weight:600'>" + UnitName + "</span>";
                    lblPoQuantity.Text = sQuantity;
                }
            }
        }


    }
}