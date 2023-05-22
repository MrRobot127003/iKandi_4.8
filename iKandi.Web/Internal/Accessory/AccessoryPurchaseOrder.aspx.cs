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
using System.Net;
using System.Net.Mail;
using System.IO;
using iTextSharp;
using Pechkin;
using iTextSharp.text.html;
using System.Xml;
using System.Runtime.CompilerServices;
using System.Web.Configuration;
using System.Text.RegularExpressions;

namespace iKandi.Web.Internal.Accessory
{
    public partial class AccessoryPurchaseOrder : BasePage
    {
        FabricController fabobj = new FabricController();

        Designation[] AuthorizedDesig = { Designation.BIPL_Fabrics_Manager };
        Designation[] JuniorDesig = { Designation.BIPL_Accessory_Manager, Designation.BIPL_Accessory_Accountant };

        public int AccessoryType
        {
            get;
            set;
        }
        public int AccessoryMasterId
        {
            get;
            set;
        }
        public string Size
        {
            get;
            set;
        }
        public string ColorPrint
        {
            get;
            set;
        }
        public int QtyToOrder
        {
            get;
            set;
        }
        public int BaseSupplierPoId
        {
            get;
            set;
        }
        public double Shrinkage;
        public double Wastage;
        string MailType = "Accessory PO";
        string PoPath = string.Empty;
        string host = "";
        AccessoryWorkingController objAccessory = new AccessoryWorkingController();
        AccessoryQualityController objAccessQuality = new AccessoryQualityController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");
            hdnUserid.Value = Convert.ToString(iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);
            getquerystring();

            if (AccessoryType == 1)
            {
                hdnStageName.Value = "Greige";
            }
            if (AccessoryType == 2)
            {
                hdnStageName.Value = "Process";
            }
            if (AccessoryType == 3)
            {
                hdnStageName.Value = "Finish";
            }



            ddlAccessUnit.Attributes.Remove("disabled");
            host = "http://" + Request.Url.Authority;

            if (!IsPostBack)
            {
                ViewState["dtEta"] = null;
                BindSupplier();
                BindDDLUnit();
                BindData();
                BindRemarks();
                Bind_Eta_History();
                DataTable dt = objAccessory.Getbipladdress("BIPLAddress4");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();


                if (JuniorDesig.Contains(ApplicationHelper.LoggedInUser.UserData.Designation))
                {
                    chkAuthorizedSignatory.Visible = false;
                }

            }
        }

        public void getquerystring()
        {
            if (Request.QueryString["AccessoryType"] != null)
            {
                AccessoryType = Convert.ToInt32(Request.QueryString["AccessoryType"]);
            }
            else
            {
                AccessoryType = 1;
            }
            if (Request.QueryString["AccessoryMasterId"] != null)
            {
                AccessoryMasterId = Convert.ToInt32(Request.QueryString["AccessoryMasterId"]);
            }
            else
            {
                AccessoryMasterId = -1;
            }
            if (Request.QueryString["Size"] != null)
            {
                Size = Request.QueryString["Size"].ToString();
            }
            else
            {
                Size = "";
            }
            if (Request.QueryString["ColorPrint"] != null)
            {
                ColorPrint = Request.QueryString["ColorPrint"].ToString();
            }
            else
            {
                ColorPrint = "";
            }
            if (Request.QueryString["QtyToOrder"] != null)
            {
                QtyToOrder = Convert.ToInt32(Request.QueryString["QtyToOrder"]);
            }
            else
            {
                QtyToOrder = -1;
            }
            if (Request.QueryString["SupplierPoId"] != null)
            {
                BaseSupplierPoId = Convert.ToInt32(Request.QueryString["SupplierPoId"]);
            }
            else
            {
                BaseSupplierPoId = -1;
            }
            if (Request.QueryString["Shrinkage"] != null)
            {
                Shrinkage = Convert.ToDouble(Request.QueryString["Shrinkage"]);
            }
            else
            {
                Shrinkage = 0;
            }
            if (Request.QueryString["Wastage"] != null)
            {
                Wastage = Convert.ToDouble(Request.QueryString["Wastage"]);
            }
            else
            {
                Wastage = 0;
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

            foreach (var AccessoryPending in AccessSupplierList)
            {
                foreach (System.Web.UI.WebControls.ListItem item in ddlSupplierName.Items)
                {
                    if (item.Value == "-1")
                        continue;
                    if (AccessoryPending.SupplierId.ToString() == item.Value)
                    {
                        if (!AccessoryPending.IsQuoted)
                        {
                            item.Attributes.Add("class", "ddlisNotQuoted");
                        }
                        else
                        {
                            item.Attributes.Add("class", "ddlisQuoted");
                        }
                    }
                }
            }


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


        public void BindRemarks()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            if (lblPoNo.Text.Trim() != "")
            {
                ds = objAccessory.GetAccessoryRemarks(lblPoNo.Text.Trim());
                dt = ds.Tables[0];
                if (!string.IsNullOrEmpty(dt.Rows[0]["AccessoryRemarks"].ToString()))
                {

                    txtAccessoryComment.InnerHtml = dt.Rows[0]["AccessoryRemarks"].ToString();



                }
            }
            else
            {

                txtAccessoryComment.InnerHtml = "";
            }




        }

        private void BindData()
        {
            List<AccessoryPending> AccessList = objAccessory.GetAccessory_SupplierPurchaseOrder(AccessoryMasterId, Size, ColorPrint, BaseSupplierPoId, AccessoryType);

            lblPoNo.Text = AccessList[0].PoNumber;
            hdnPoNo.Value = AccessList[0].PoNumber;
            hdnSupplierPoId.Value = AccessList[0].SupplierPoId.ToString();
            txtPoDate.Text = Convert.ToDateTime(AccessList[0].PoDate) == DateTime.MinValue ? DateTime.Now.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(AccessList[0].PoDate).ToString("dd MMM yy (ddd)");
            txtETADate.Text = Convert.ToDateTime(AccessList[0].PoEta) == DateTime.MinValue ? DateTime.Now.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(AccessList[0].PoEta).ToString("dd MMM yy (ddd)");
            hdnEtaDate.Value = Convert.ToDateTime(AccessList[0].PoEta) == DateTime.MinValue ? DateTime.Now.ToString("dd MMM yy (ddd)") : Convert.ToDateTime(AccessList[0].PoEta).ToString("dd MMM yy (ddd)");
            hdnSrvCount.Value = AccessList[0].SrvCount.ToString();
            lblClientCode.Text = AccessList[0].ClientCode;
            //RajeevS 13022023
            string HSNCode = AccessList[0].HSNCode;
            if(HSNCode=="")
            {
                spn_HSNCode.InnerHtml = "";
                lblHSNCode.Visible = false;
            }
            else
            {
                lblHSNCode.Visible = true;
                lblHSNCode.Text = HSNCode;
                spn_HSNCode.InnerHtml = "HSNCode";
            }
            //RajeevS
            if (AccessList[0].UnitChange)
            {
                hdnSrvQty.Value = Math.Round(AccessList[0].SRVQuantity * AccessList[0].ConversionValue, 0).ToString();
            }
            else
            {
                hdnSrvQty.Value = AccessList[0].SRVQuantity.ToString();
            }

            if (Convert.ToDateTime(AccessList[0].PoDate) != DateTime.MinValue)
            {
                txtPoDate.Attributes.Add("disabled", "disabled");
            }
            if (AccessList[0].HistoryExist == 1)
            {
                ShowImgHis.Visible = true;
            }
            hdnSupplierId.Value = AccessList[0].SupplierId.ToString();
            hdnSupplierEmail.Value = AccessList[0].SupplierEmail.ToString().Trim();
            if (AccessList[0].SupplierId > 0)
            {
                ddlSupplierName.SelectedValue = AccessList[0].SupplierId.ToString();
                ddlSupplierName.Attributes.Add("disabled", "disabled");
            }

            lblAccessoryQuality.Text = AccessList[0].AccessoryName;
            hdnAccessoryQuality.Value = AccessList[0].AccessoryName; //new line
            if (AccessList[0].Size != "")
                lblSize.Text = AccessList[0].Size == "Default" ? "" : "(" + AccessList[0].Size + ")";

            lblcolorprint.Text = AccessList[0].Color_Print;

            if (BaseSupplierPoId > 0)
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

                //}
                //else
                //{
                //    RecievedQty = SendQty;
                //    RecievedBaseQty = Convert.ToInt32(hdnSend_CalBase.Value);
                //}

                hdnReceived_CalBase.Value = RecievedBaseQty.ToString();
                hdnReceivedBase.Value = RecievedBaseQty.ToString();
                hdnReceivedQty.Value = RecievedQty.ToString();
                hdnCancel_ReceivedQty.Value = RecievedQty.ToString();
                txtReceivedqty.Text = RecievedQty.ToString("#,##0");
                txtReceivedqty.Attributes.Add("readonly", "readonly");

                double RemainingQty = AccessList[0].ConversionValue > 0 ? Math.Round(Convert.ToDouble(QtyToOrder) * AccessList[0].ConversionValue) : QtyToOrder;

                if (RemainingQty.ToString() != "0")
                {
                    AccessoryTooltipTxt.Attributes.Add("class", "tooltiptext");
                    AccessoryTooltipTxt.InnerText = "You can not enter Send Qty. more than Remaining Qty. " + RemainingQty.ToString() + "";
                }
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

            if (AccessList[0].IsJuniorSignatory == true)
            {
                divJuniorSignatorySigchk.Visible = false;
                divJuniorSignatorySig.Visible = true;
                chkJuniorSignatory.Checked = true;
                if (AccessList[0].JuniorSignatoryId > 0)
                {
                    var user = ApplicationHelper.Users.Where(x => x.UserID == AccessList[0].JuniorSignatoryId).FirstOrDefault();
                    if (user != null)
                    {
                        lblJuniorName.Text = user.FirstName + " " + user.LastName + " ";
                        imgJuniorSignatory.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                        if (AccessList[0].JuniorSignatoryApprovedOn != DateTime.MinValue)
                            lblJuniorSignatorydate.Text = AccessList[0].JuniorSignatoryApprovedOn.ToString("dd MMM yy (ddd)");

                    }
                }
            }
            else
            {
                chkJuniorSignatory.Checked = false;
            }

            if (AccessList[0].IsAuthorizedSignatory == true)
            {
                divAuthorizedSigchk.Visible = false;
                divAuthorizedSig.Visible = true;
                chkAuthorizedSignatory.Checked = true;
                if (AccessList[0].AuthorizedSignatureBy > 0)
                {
                    var user = ApplicationHelper.Users.Where(x => x.UserID == AccessList[0].AuthorizedSignatureBy).FirstOrDefault();
                    if (user != null)
                    {
                        lblAuthorizedName.Text = user.FirstName + " " + user.LastName + " ";
                        imgAuthorizedSignatory.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                        if (AccessList[0].AuthorizedSignatureDate != DateTime.MinValue)
                            lblAuthorizedDate.Text = AccessList[0].AuthorizedSignatureDate.ToString("dd MMM yy (ddd)");

                    }
                }
            }
            else
            {
                chkAuthorizedSignatory.Checked = false;
            }
            if (AccessList[0].IsPartySignature == true)
            {
                divPartySigchk.Visible = false;
                divPartySig.Visible = true;
                chkpartysignature.Checked = true;
                if (AccessList[0].PartySignatureBy > 0)
                {
                    var user = ApplicationHelper.Users.Where(x => x.UserID == AccessList[0].PartySignatureBy).FirstOrDefault();
                    if (user != null)
                    {
                        lblPartyName.Text = user.FirstName + " " + user.LastName + "</br>" + " <span style=Font-size:9px;>(On Behalf of " + AccessList[0].SupplierName + ")</span>";
                        imgpartysingature.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                        if (AccessList[0].PartySignatureDate != DateTime.MinValue)
                            lblPartyDate.Text = AccessList[0].PartySignatureDate.ToString("dd MMM yy (ddd)");
                    }
                }
            }
            else
            {
                chkpartysignature.Checked = false;
            }

            if ((AccessList[0].IsAuthorizedSignatory == true) && (AccessList[0].IsPartySignature == true))
            {
                ddlAccessUnit.Attributes.Add("disabled", "disabled");
                hdnIsUnitDisabled.Value = "1";
                dvSendMail.Style.Add("display", "inline-block");
            }

            if (hdnUnitChange.Value == "1")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "ChangeColorDropDown();", true);
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
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                    LinkButton lnkEdit = (LinkButton)e.Row.FindControl("LinkButton1");

                    if (iRowIndex == 0)
                    {
                        lnkDelete.Visible = false;
                    }
                    if (iRowIndex == 7)
                    {
                        lnkEdit.Enabled = false;
                    }


                }
            }

        }

        protected void grdQtyRange_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdQtyRange.EditIndex = e.NewEditIndex;
            Bind_Eta_History();
            if ((AccessoryType == 1) || (AccessoryType == 3))
            {
                txtsentQty.Attributes.Add("readonly", "readonly");
            }
            else
            {
                txtReceivedqty.Attributes.Add("readonly", "readonly");
            }
            if (hdnUnitChange.Value == "1")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "ChangeColorDropDown();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "BaseColorDropDown();", true);
            }

            if ((Convert.ToInt32(hdnSrvCount.Value) > 0) || (hdnIsUnitDisabled.Value == "1") || (ddlSupplierName.SelectedValue == "-1"))
                ddlAccessUnit.Attributes.Add("disabled", "disabled");
        }

        protected void grdQtyRange_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdQtyRange.EditIndex = -1;
            Bind_Eta_History();
            if (hdnUnitChange.Value == "1")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "ChangeColorDropDown();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "BaseColorDropDown();", true);
            }
            if (ddlSupplierName.SelectedValue == "-1")
            {
                ddlAccessUnit.Attributes.Add("disabled", "disabled");
            }
            if ((Convert.ToInt32(hdnSrvCount.Value) > 0) || (hdnIsUnitDisabled.Value == "1") || (ddlSupplierName.SelectedValue == "-1"))
                ddlAccessUnit.Attributes.Add("disabled", "disabled");
        }

        protected void grdQtyRange_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdQtyRange.Rows[e.RowIndex];
            HiddenField hdnRowNumber = row.FindControl("hdnRowNumber") as HiddenField;
            HiddenField hdnEtaDateId = row.FindControl("hdnSupplierPO_ETA_Id") as HiddenField;
            int RowNumber = 0;
            RowNumber = Convert.ToInt32(hdnRowNumber.Value);

            if (ViewState["dtEta"] != null)
            {
                DataTable dtEta = (DataTable)ViewState["dtEta"];

                for (int i = dtEta.Rows.Count - 1; i >= 0; i--)
                {
                    if (Convert.ToInt32(dtEta.Rows[i]["RowNumber"]) >= RowNumber)
                    {
                        DataRow dr = dtEta.Rows[i];
                        dtEta.Rows.Remove(dr);
                        dtEta.AcceptChanges();
                    }
                }
                int RowCount = dtEta.Rows.Count - 1;
                dtEta.Rows[RowCount]["ToQty"] = Convert.ToInt32(hdnReceivedQty.Value);
                dtEta.Rows[RowCount]["POETADate"] = DateTime.ParseExact(txtETADate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);



                ViewState["dtEta"] = dtEta;
                Bind_Eta_History();

                if ((Convert.ToInt32(hdnSrvCount.Value) > 0) || (hdnIsUnitDisabled.Value == "1") || (ddlSupplierName.SelectedValue == "-1"))
                    ddlAccessUnit.Attributes.Add("disabled", "disabled");

                if (hdnUnitChange.Value == "1")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "ChangeColorDropDown();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "BaseColorDropDown();", true);
                }
            }
        }

        protected void grdQtyRange_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdQtyRange.Rows[e.RowIndex];
            HiddenField hdnsupplierpoid = row.FindControl("hdnsupplierpoid") as HiddenField;
            HiddenField hdnRowNumber = row.FindControl("hdnRowNumber") as HiddenField;
            HiddenField hdnSupplierPO_ETA_Id = row.FindControl("hdnSupplierPO_ETA_Id") as HiddenField;
            TextBox txtFromQty = row.FindControl("txtFromQty") as TextBox;
            TextBox txtToQty = row.FindControl("txtToQty") as TextBox;
            TextBox txtRangeEta = row.FindControl("txtRangeEta") as TextBox;
            if (ViewState["dtEta"] != null)
            {
                DataTable dtEta = (DataTable)ViewState["dtEta"];
                DataTable dtEtaClone = dtEta.Clone();
                int RowNumber = 0, FromQty = 0, ToQty = 0, SupplierPoEtaId = 0, SupplierPo_Id = 0;
                DateTime RangeEta;

                foreach (DataRow dr in dtEta.Rows)
                {

                    if (dr["RowNumber"].ToString() == hdnRowNumber.Value.ToString())
                    {
                        RowNumber = Convert.ToInt32(hdnRowNumber.Value);
                        SupplierPo_Id = Convert.ToInt32(hdnsupplierpoid.Value);
                        SupplierPoEtaId = Convert.ToInt32(hdnSupplierPO_ETA_Id.Value);
                        FromQty = txtFromQty.Text == "" ? 0 : Convert.ToInt32(txtFromQty.Text);
                        ToQty = txtToQty.Text == "" ? 0 : Convert.ToInt32(txtToQty.Text);
                        RangeEta = DateTime.ParseExact(txtRangeEta.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);

                        DataRow drClone = dtEtaClone.NewRow();
                        drClone["RowNumber"] = RowNumber;
                        drClone["SupplierPO_Id"] = SupplierPo_Id;
                        drClone["SupplierPO_ETA_Id"] = SupplierPoEtaId;
                        drClone["FromQty"] = FromQty;
                        drClone["ToQty"] = ToQty;
                        drClone["POETADate"] = RangeEta;
                        dtEtaClone.Rows.Add(drClone);

                        if ((Convert.ToInt32(hdnSrvCount.Value) > 0) || (hdnIsUnitDisabled.Value == "1") || (ddlSupplierName.SelectedValue == "-1"))
                            ddlAccessUnit.Attributes.Add("disabled", "disabled");

                        break;
                    }
                    else
                    {
                        RowNumber = Convert.ToInt32(dr["RowNumber"]);
                        SupplierPo_Id = Convert.ToInt32(dr["SupplierPO_Id"]);
                        SupplierPoEtaId = Convert.ToInt32(dr["SupplierPO_ETA_Id"]);
                        FromQty = Convert.ToInt32(dr["FromQty"]);
                        ToQty = Convert.ToInt32(dr["ToQty"]);
                        RangeEta = Convert.ToDateTime(dr["POETADate"]);

                        DataRow drClone = dtEtaClone.NewRow();
                        drClone["RowNumber"] = RowNumber;
                        drClone["SupplierPO_Id"] = SupplierPo_Id;
                        drClone["SupplierPO_ETA_Id"] = SupplierPoEtaId;
                        drClone["FromQty"] = FromQty;
                        drClone["ToQty"] = ToQty;
                        drClone["POETADate"] = RangeEta;
                        dtEtaClone.Rows.Add(drClone);
                    }

                }
                if (ToQty == Convert.ToInt32(hdnReceivedQty.Value))
                {
                    ViewState["dtEta"] = dtEtaClone;
                    grdQtyRange.EditIndex = -1;
                    Bind_Eta_History();

                    if ((Convert.ToInt32(hdnSrvCount.Value) > 0) || (hdnIsUnitDisabled.Value == "1") || (ddlSupplierName.SelectedValue == "-1"))
                        ddlAccessUnit.Attributes.Add("disabled", "disabled");

                    if (hdnUnitChange.Value == "1")
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "ChangeColorDropDown();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "BaseColorDropDown();", true);
                    }
                    return;
                }

                DataRow drNew = dtEtaClone.NewRow();
                drNew["SupplierPO_Id"] = SupplierPo_Id;
                drNew["SupplierPO_ETA_Id"] = -1;
                drNew["RowNumber"] = RowNumber + 1;
                drNew["FromQty"] = ToQty + 1;
                drNew["ToQty"] = hdnReceivedQty.Value == "" ? -1 : Convert.ToInt32(hdnReceivedQty.Value);
                drNew["POETADate"] = DateTime.ParseExact(txtETADate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
                dtEtaClone.Rows.Add(drNew);
                ViewState["dtEta"] = dtEtaClone;

                grdQtyRange.EditIndex = -1;
                Bind_Eta_History();

                if (hdnUnitChange.Value == "1")
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "ChangeColorDropDown();", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "BaseColorDropDown();", true);
                }
            }

            if ((Convert.ToInt32(hdnSrvCount.Value) > 0) || (hdnIsUnitDisabled.Value == "1") || (ddlSupplierName.SelectedValue == "-1"))
                ddlAccessUnit.Attributes.Add("disabled", "disabled");
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Visible = false;
            try
            {
                AccessoryPending objAccessPurchase = new AccessoryPending();
                objAccessPurchase.PoNumber = hdnPoNo.Value;
                objAccessPurchase.PoDate = DateTime.ParseExact(txtPoDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
                objAccessPurchase.PoEta = DateTime.ParseExact(txtETADate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
                objAccessPurchase.SupplierId = Convert.ToInt32(hdnSupplierId.Value);
                objAccessPurchase.AccessoryMasterId = AccessoryMasterId;
                objAccessPurchase.Size = Size;
                objAccessPurchase.Color_Print = ColorPrint;
                objAccessPurchase.Shrinkage = lblShrinkage.Text == "" ? 0 : Convert.ToDouble(lblShrinkage.Text);
                objAccessPurchase.Wastage = lblWastage.Text == "" ? 0 : Convert.ToDouble(lblWastage.Text);

                if (hdnUnitChange.Value == "1")
                {
                    objAccessPurchase.GarmentUnit = Convert.ToInt32(hdnBaseAccessUnitVal.Value);
                    objAccessPurchase.SendQty = hdnSend_CalBase.Value == "" ? -1 : Convert.ToInt32(hdnSend_CalBase.Value);
                    objAccessPurchase.ReceivedQty = hdnReceived_CalBase.Value == "" ? -1 : Convert.ToInt32(hdnReceived_CalBase.Value);

                    objAccessPurchase.New_GarmentUnit = Convert.ToInt32(ddlAccessUnit.SelectedValue);
                    objAccessPurchase.New_SendQty = hdnSendQty.Value == "" ? 0 : Convert.ToInt32(hdnSendQty.Value);
                    objAccessPurchase.New_RecievedQty = hdnReceivedQty.Value == "" ? 0 : Convert.ToInt32(hdnReceivedQty.Value);
                    objAccessPurchase.ConversionValue = hdnConversionVal.Value == "" ? -1 : Convert.ToDouble(hdnConversionVal.Value);
                    objAccessPurchase.UnitChange = true;
                }
                else
                {
                    objAccessPurchase.GarmentUnit = Convert.ToInt32(ddlAccessUnit.SelectedValue);
                    objAccessPurchase.SendQty = hdnSendQty.Value == "" ? -1 : Convert.ToInt32(hdnSendQty.Value);
                    objAccessPurchase.ReceivedQty = hdnReceivedQty.Value == "" ? -1 : Convert.ToInt32(hdnReceivedQty.Value);
                    objAccessPurchase.New_GarmentUnit = -1;
                    objAccessPurchase.New_SendQty = 0;
                    objAccessPurchase.New_RecievedQty = 0;
                    objAccessPurchase.ConversionValue = 0;
                    objAccessPurchase.UnitChange = false;
                }

                objAccessPurchase.FinalRate = txtRate.Text == "" ? -1 : Convert.ToDouble(txtRate.Text);

                objAccessPurchase.IsJuniorSignatory = chkJuniorSignatory.Checked == true ? true : false;
                objAccessPurchase.IsAuthorizedSignatory = chkAuthorizedSignatory.Checked == true ? true : false;
                objAccessPurchase.IsPartySignature = chkpartysignature.Checked == true ? true : false;
                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                if (ViewState["dtEta"] != null)
                {
                    DataTable dtEta = (DataTable)ViewState["dtEta"];
                    List<AccessoryEtaRange> objAccessEtaList = new List<AccessoryEtaRange>();

                    for (int i = 0; i < dtEta.Rows.Count; i++)
                    {
                        AccessoryEtaRange objAccessEta = new AccessoryEtaRange();
                        objAccessEta.SupplierPoEtaId = dtEta.Rows[i]["SupplierPO_ETA_Id"] == DBNull.Value ? -1 : Convert.ToInt32(dtEta.Rows[i]["SupplierPO_ETA_Id"]);
                        objAccessEta.FromQty = dtEta.Rows[i]["FromQty"] == null ? -1 : Convert.ToInt32(dtEta.Rows[i]["FromQty"]);
                        objAccessEta.ToQty = dtEta.Rows[i]["ToQty"] == null ? -1 : Convert.ToInt32(dtEta.Rows[i]["ToQty"]);
                        objAccessEta.POETADate = dtEta.Rows[i]["POETADate"] == null ? DateTime.MinValue : Convert.ToDateTime(dtEta.Rows[i]["POETADate"]);

                        objAccessEtaList.Add(objAccessEta);
                    }

                    objAccessPurchase.AccessoryEtaRangeDetail = objAccessEtaList;
                }

                int NewSupplierPoId = objAccessory.SaveAccessory_PurchaseOrder(objAccessPurchase, AccessoryType, UserId);
                if (NewSupplierPoId > 0)
                {
                    objAccessory.UpdateAccessoryRemarks(hdnPoNo.Value, txtAccessoryComment.InnerText, Convert.ToInt32(hdnUserid.Value));

                    BaseSupplierPoId = NewSupplierPoId;
                    if ((objAccessPurchase.IsAuthorizedSignatory == true) && (objAccessPurchase.IsPartySignature == true) && (rbtnYes.Checked))
                    {
                        RenderHtml();

                        //string thisPath = "POAccessoryPurchaseOrder_" + BaseSupplierPoId + ".pdf";
                        //string url = host + "/Uploads/Accessory/" + thisPath;

                        // string EmailContent = HttpContent(url);

                        SendPoEmail();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
                    }
                    else if ((hdnIsUnitDisabled.Value == "1") && (rbtnYes.Checked))
                    {
                        RenderHtml();

                        //string thisPath = "POAccessoryPurchaseOrder_" + BaseSupplierPoId + ".pdf";
                        //string url = host + "/Uploads/Accessory/" + thisPath;

                        //string EmailContent = HttpContent(url);

                        SendPoEmail();
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePageWithMessage();", true);
                    }
                }
                else
                {
                    btnSubmit.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "alert('Error occured during saving');", true);
                }
            }
            catch (Exception ex)
            {
                btnSubmit.Visible = true;
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "alert('Error occured during saving');", true);
            }
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void btnUpdateGrid_Click(object sender, EventArgs e)
        {
            if (ViewState["dtEta"] != null)
            {
                DataTable dtEta = (DataTable)ViewState["dtEta"];
                dtEta.Clear();
                DataRow dr = dtEta.NewRow();
                dr["SupplierPO_ETA_Id"] = 1;
                dr["SupplierPO_Id"] = hdnSupplierPoId.Value == "" ? -1 : Convert.ToInt32(hdnSupplierPoId.Value);
                dr["RowNumber"] = 1;
                dr["FromQty"] = 1;
                dr["ToQty"] = hdnReceivedQty.Value == "" ? -1 : Convert.ToInt32(hdnReceivedQty.Value);
                dr["POETADate"] = DateTime.ParseExact(txtETADate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
                dtEta.Rows.Add(dr);
                ViewState["dtEta"] = dtEta;
                Bind_Eta_History();
            }
            lblPoNo.Text = hdnPoNo.Value;
            var ReceivedQty = hdnReceivedQty.Value == "" ? -1 : Convert.ToInt32(hdnReceivedQty.Value);
            var Rate = txtRate.Text == "" ? -1 : Convert.ToDouble(txtRate.Text);
            lblTotalAmount.Text = Math.Round(ReceivedQty * Rate, 0).ToString();

            //lblTotalAmount.Text = Convert.ToDecimal(hdnTotalAmount.Value).ToString("#,##0");// Commented By shubhendu 2/09/2021

            if ((AccessoryType == 1) || (AccessoryType == 3))
            {
                txtsentQty.Attributes.Add("readonly", "readonly");
            }
            else
            {
                txtReceivedqty.Attributes.Add("readonly", "readonly");
            }
            if ((Convert.ToInt32(hdnSrvCount.Value) > 0) || (hdnIsUnitDisabled.Value == "1"))
                ddlAccessUnit.Attributes.Add("disabled", "disabled");

            if (hdnUnitChange.Value == "1")
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "ChangeColorDropDown();", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", "BaseColorDropDown();", true);
            }

        }

        public void RenderHtml()
        {
            WebRequest Request;
            WebResponse Response;
            StreamReader reader;

            string strHTML;
            Request = WebRequest.Create(host + "/AccessoryPdfFile/AccessoryPurchaseOrderPdf.aspx?AccessoryType=" + AccessoryType + "&AccessoryMasterId=" + AccessoryMasterId + "&Size=" + Size + "&ColorPrint=" + ColorPrint + "&QtyToOrder=" + QtyToOrder + "&SupplierPoId=" + BaseSupplierPoId);

            Request.Timeout = Convert.ToInt32(99999999);
            Response = Request.GetResponse();
            reader = new StreamReader(Response.GetResponseStream());
            strHTML = reader.ReadToEnd();
            genertaePdf(strHTML, "ss");
        }

        public void genertaePdf(string HTMLCode, string PolicyFile)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Accessory/" + "POAccessory_" + hdnPoNo.Value.ToString() + ".pdf");
            HTMLCode = getImage(HTMLCode);
            getvartypeHTML(HTMLCode, strFileName);
        }

        public void getvartypeHTML(string HTMLCode, string PolicyFile)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Accessory/" + "POAccessory_" + hdnPoNo.Value.ToString() + ".pdf");

            using (IPechkin pechkin = Factory.Create(new GlobalConfig()))
            {
                var pdf = pechkin.Convert(new ObjectConfig()
                                        .SetLoadImages(true).SetZoomFactor(1.5)
                                        .SetPrintBackground(true)
                                        .SetScreenMediaType(true)
                                        .SetCreateExternalLinks(true), (HTMLCode));
                using (FileStream file = System.IO.File.Create(strFileName))
                {
                    file.Write(pdf, 0, pdf.Length);
                }
            }

        }

        public string getImage(string input)
        {
            if (input == null)
                return string.Empty;
            string tempInput = input;
            string pattern = @"<img(.|\n)+?>";
            string src = string.Empty;
            HttpContext context = HttpContext.Current;

            //Change the relative URL's to absolute URL's for an image, if any in the HTML code.
            foreach (Match m in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline |

            RegexOptions.RightToLeft))
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

                                //insert new url img tag in whole html code
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

        public static string HttpContent(string url)
        {
            string result = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Timeout = 80000000;
                req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E)";

                using (var resp = req.GetResponse())
                {
                    result = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                }

            }

            catch (Exception ex)
            {
                string err = ex.Message.ToString();
            }
            return result;
        }

        public Boolean SendPoEmail()
        {

            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                List<String> to = new List<String>();

                string email = hdnSupplierEmail.Value.ToString();
                to.Add(email);
                List<Attachment> atts = new List<Attachment>();

                if (File.Exists(Constants.ACCESSORY_FOLDER_PATH + "POAccessory_" + hdnPoNo.Value.ToString() + ".pdf"))
                {

                    PoPath = Path.Combine(Constants.ACCESSORY_FOLDER_PATH, "POAccessory_" + hdnPoNo.Value.ToString() + ".pdf");
                    atts.Add(new Attachment(PoPath));
                }

                this.SendEmail(fromName, to, atts, false, false);

                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return false;
            }
        }

        public Boolean SendEmail(String FromEmail, List<String> To, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync)
        {
            string po_Number = hdnPoNo.Value;
            string flag = "accessoryPo";
            string[] array = GetPoDetailsForMail_Accessory(po_Number, flag);

            string tradeName = array[0];
            string supplierName = array[1];
            string receivedQty = array[2];
            string rate = array[3];
            string eta = array[4];
            string Order_text = array[5];



            hdnAccessoryQuality.Value = hdnAccessoryQuality.Value.Contains('(') ? hdnAccessoryQuality.Value.Substring(0, hdnAccessoryQuality.Value.IndexOf('(')) : hdnAccessoryQuality.Value;
            //System.Diagnostics.Debugger.Break();
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = MailType + " (" + hdnPoNo.Value.ToString() + ")";
            //mailMessage.Body = "Please find attached PO copy";

            mailMessage.Body = "<p><span style='font-size:13px; font-family:Arial;'>Dear&nbsp;<b style='font-size:14px;'>" + supplierName + ",</b><br><br><strong><span style='font-size:14px;'>Greetings from BIPL.</span></strong></span></p><p></p><p>We are pleased to confirm "+Order_text +"&nbsp; <b style='color:#3727FE;font-weight:600;font-size:16px;'>" + po_Number + ",&nbsp;</b>for <b style='color:#3727FE;font-weight:600;font-size:16px;'>" + tradeName + "</b>&nbsp;of quantity <b style='color:#3727FE;fontweight:600;font-size:16px;'>" + Convert.ToDecimal(receivedQty).ToString("#,#.##") + "&nbsp;</b>@ ₹<b style='color:#37591A;font-weight:600;font-size:16px;'>" + rate + "</b> with eta <b style='color:#3727FE;font-weight:600;font-size:16px;'>" + eta + "</b> to you.</p><p><span style='color:#F489A2;'>Please read all instructions and details on PO and contact material team for any issues.</span></p><p><span style='color:#838383;font-size:13px;'>This is a system generated email so please don't reply.</span></p><p><strong>Thanks &amp; Best Regards&nbsp;</strong></p><p><strong>BIPL Team</strong></p>";
           // mailMessage.Body = "<span style='font-size:13px; font-family:Arial;'>Dear<b style='font-size:14px;'>" + suppliername + "</b><br><br><strong><span style='font-size:14px;'>Greetings from BIPL.</span></strong></span><br><br><p>We are pleased to confirm Purchase Order <b style='color:blue;font-weight:600;font-size:16px;'>" + Po_number + "</b>, on <b style='color:blue;font-weight:600;font-size:16px;'>" + tradename + "</b> for <b style='color:blue;fontweight:600;font-size:16px;'>" + receivedqty + "</b> @<b style='color:green;font-weight:600;font-size:16px;'>" + rate + "</b> with <b style='color:blue;font-weight:600;font-size:16px;'>" + eta + "</b> with you.</p><p><span style='color:orange;'>Please read all instructions and details on PO and contact material team for any issues.</span></p><p><span style='color:grey;font-size:13px;'>This is a system generated email so please don't reply.</span></p><p><strong>Thanks &amp; Best Regards&nbsp;</strong></p><p><strong>BIPL Team</strong></p>";

            mailMessage.IsBodyHtml = true;


            //AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Subject, null, "text/html");
            //mailMessage.AlternateViews.Add(htmlView);

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
                foreach (Attachment att in Attachments)
                {
                    mailMessage.Attachments.Add(att);
                }
            }

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Timeout = Constants.SMTP_TIMEOUT;

            if (Constants.SMTP_SECURE)
            {
                smtpClient.EnableSsl = true;
            }

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
                hdnMailSentStatus.Value = "1";
                ShowAlert("Mail Sent successfully");
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
                    if (Attachments != null)
                    {
                        foreach (Attachment att in Attachments)
                        {
                            att.Dispose();
                        }

                        Attachments = null;
                    }

                    foreach (Attachment att in mailMessage.Attachments)
                    {
                        att.Dispose();
                    }

                    mailMessage = null;

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
        }

        public string[] GetPoDetailsForMail_Accessory(string po_Number, string flag)
        {
            return fabobj.GetDetailsForMail(po_Number , flag);
        }

    }
}