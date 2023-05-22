using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
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
    public partial class AccessoryDebitNote : BasePage
    {
        public int SupplierPoId
        {
            get;
            set;
        }
        public int DebitNoteId
        {
            get;
            set;
        }
        private double TotalAmount = 0;
        string host = "";
        string MailType = "Accessory Debit Note ";
        string PoPath = string.Empty;
        //private int IsPageRefresh = 0;

        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            host = "http://" + Request.Url.Authority;

            GetQueryString();
            if (!IsPostBack)
            {
                BindBillDropdownList(0);
                BindData(0);
                CalculateGrandTotal();
                DataTable dt = objAccessoryWorking.Getbipladdress("BIPLAddress4");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();
            }
        }

        private void GetQueryString()
        {
            if (Request.QueryString["SupplierPoId"] != null)
            {
                SupplierPoId = Convert.ToInt32(Request.QueryString["SupplierPoId"]);
            }
            else
            {
                SupplierPoId = 0;
            }
            if (Request.QueryString["DebitNoteId"] != null)
            {
                DebitNoteId = Convert.ToInt32(Request.QueryString["DebitNoteId"]);
            }
            else
            {
                DebitNoteId = 0;
            }
        }

        private void BindBillDropdownList(int PartyBillId)
        {
            List<Accessory_Srv_Bill> Accessory_Srv_BillList = objAccessoryWorking.GetAccessory_Srv_Bill_DropDownList(SupplierPoId, DebitNoteId);
            if (Accessory_Srv_BillList.Count > 0)
            {
                ddlBillNo.DataSource = Accessory_Srv_BillList;
                ddlBillNo.DataTextField = "BillDetails";
                ddlBillNo.DataValueField = "PartyBillId";
                ddlBillNo.DataBind();

                if (PartyBillId > 0)
                {
                    ddlBillNo.SelectedValue = PartyBillId.ToString();
                }

                //commented below by Girish on 2023-03-14

                //string BillDetails = ddlBillNo.SelectedItem.Text;
                //string[] sChar = BillDetails.Split('(');
                //string[] sChar1 = sChar[1].Split(')');
                //string sAmount = sChar1[0].ToString();
                //hdnBillAmount.Value = sAmount.Trim();

                //added by Girish on 2023-03-14
                string BillDetails = ddlBillNo.SelectedItem.Text;
                if (!string.IsNullOrEmpty(BillDetails))
                {
                    string[] sChar = BillDetails.Split('(');
                    if (sChar.Length > 1)
                    {
                        string[] sChar1 = sChar[1].Split(')');
                        if (sChar1.Length > 0)
                        {
                            string sAmount = sChar1[0].ToString();
                            hdnBillAmount.Value = sAmount.Trim();
                        }
                    }
                }
                //added by Girish on 2023-03-14


            }

        }

        private void BindData(int IsPageRefresh)
        {
            int PartyBillId = 0;
            if (ddlBillNo.SelectedValue != "")
            {
                PartyBillId = Convert.ToInt32(ddlBillNo.SelectedValue);
            }
            AccessoryDebitNoteCls objAccessoryDebitNote = objAccessoryWorking.Get_AccessoryDebitNote(SupplierPoId, DebitNoteId, PartyBillId);

            hdnDebitnotid.Value = objAccessoryDebitNote.DebitNoteId.ToString();
            lblDebitNo.Text = objAccessoryDebitNote.DebitNoteNumber;
            lblSupllierName.Text = objAccessoryDebitNote.SupplierName;

            lblSupplierGstNo.Text = objAccessoryDebitNote.SupplierGstNo;

            lblSupplierAddress.Text = objAccessoryDebitNote.SupplierAddress;
            
            txtReturnChallan.Text = objAccessoryDebitNote.ReturnChallanNumber;
            txtreturndate.Text = objAccessoryDebitNote.ChallanDate == DateTime.MinValue ? "" : objAccessoryDebitNote.ChallanDate.ToString("dd MMM yy (ddd)");
            hdnSRVQty.Value = objAccessoryDebitNote.SRVQuantity.ToString();
            hdnGarmentUnitName.Value = objAccessoryDebitNote.GarmentUnitName;
            hdnPO_Number.Value = objAccessoryDebitNote.PoNumber;
            hdnBill_Number.Value = objAccessoryDebitNote.PartyBillNumber;
            lblAccQualityName.Text = objAccessoryDebitNote.AccQualityName;
            lblColor_Print.Text = objAccessoryDebitNote.AccColor_Print;
            hdnGST_No.Value = objAccessoryDebitNote.GSTNo;
            txtIGST.Text = objAccessoryDebitNote.IGST == 0 ? "" : objAccessoryDebitNote.IGST.ToString();//new line
            txtCGST.Text = objAccessoryDebitNote.CGST == 0 ? "" : objAccessoryDebitNote.CGST.ToString();//new line
            txtSGST.Text = objAccessoryDebitNote.SGST == 0 ? "" : objAccessoryDebitNote.SGST.ToString();//new line
            //rajeevS
            string HSNCode = objAccessoryDebitNote.HSNCode;
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
            //rajeevs
       
            List<AccessoryDebitNoteParticulars> objDebitNoteParticulars = objAccessoryDebitNote.AccessoryDebitNoteParticularsList;
            grdAccessoryDebitNot.DataSource = objDebitNoteParticulars;
            grdAccessoryDebitNot.DataBind();

            if (DebitNoteId > 0)
            {
                txtDate.Text = objAccessoryDebitNote.DebitNoteDate.ToString("dd MMM yy (ddd)");
                ddlBillNo.SelectedValue = objAccessoryDebitNote.PartyBillId.ToString();
                ddlBillNo.Attributes.Add("disabled", "disabled");
            }
            else
            {
                txtDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
            }
            if (objAccessoryDebitNote.IsDebitNoteSigned)
            {
                divChkAuthorized.Visible = false;
                chkAuthorised.Checked = true;
                hdnIsChecked.Value = "1";
                divSigAuthorized.Visible = true;
                lblAuthorizedName.Text = objAccessoryDebitNote.DebitNoteSignedBy;
                imgAuthorized.ImageUrl = objAccessoryDebitNote.AuthSignature != string.Empty ? "~/Uploads/Photo/" + objAccessoryDebitNote.AuthSignature : "~/Uploads/Photo/NotSign.jpg";
                lblAuthorizedOnDate.Text = Convert.ToDateTime(objAccessoryDebitNote.DebitNoteSignDate).ToString("dd MMM yy (ddd)");
                dvSendMail.Attributes.Add("style", "display:''");
                dvSendMail.Attributes.Add("style", "float:left;font-weight: bold;margin-left:8px;");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "disablePage();", true);
                //btnSubmit.Visible = false;
            }
            if (objAccessoryDebitNote.GSTNo == "")
            {
                lblGstMsg.Text = "GST No. not available for this Supplier, hence you can not raise Debit Note!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "disablePage();", true);
                //btnSubmit.Visible = false;
            }
        }

        private void ShowHideGst()
        {
            if (hdnGST_No.Value != "0")
            {
                if (hdnGST_No.Value.Substring(0, 2) == "09")
                {
                    tdIIGST.Visible = false;
                    tdCGST.Visible = true;
                    tdSGST.Visible = true;
                }
                else
                {
                    tdIIGST.Visible = true;
                }
            }
            else
            {
                lblGstMsg.Visible = true;
                btnSubmit.Visible = false;
            }
        }

        protected void grdAccessoryDebitNot_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdAccessoryDebitNot.Rows[e.RowIndex];
            HiddenField hdnIdSelected = (HiddenField)row.FindControl("hdnId");

            HiddenField hdnParticularIdSelected = (HiddenField)row.FindControl("hdnParticularId");
            HiddenField hdnDebitNote_SRVIDSelected = (HiddenField)row.FindControl("hdnDebitNote_SRVID");
            DebitNoteId = hdnDebitnotid.Value == "" ? -1 : Convert.ToInt32(hdnDebitnotid.Value);

            AccessoryDebitNoteParticulars objDelete = new AccessoryDebitNoteParticulars();
            objDelete.DebitNoteId = DebitNoteId;
            objDelete.ParticularName = "";
            objDelete.DebitNoteParticularId = hdnParticularIdSelected.Value == "" ? -1 : Convert.ToInt32(hdnParticularIdSelected.Value);
            objDelete.Acc_DebitNote_SRVID = hdnDebitNote_SRVIDSelected.Value == "" ? -1 : Convert.ToInt32(hdnDebitNote_SRVIDSelected.Value);

            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            string stype = "DELETE";
            if (objDelete.DebitNoteParticularId > 0)
            {
                int iSave = objAccessoryWorking.Update_Accessory_DebitNotePartyCulars(objDelete, UserId, stype);
            }

            List<AccessoryDebitNoteParticulars> DebitNoteParticularsList = new List<AccessoryDebitNoteParticulars>();
            for (int AccNo = 0; AccNo < grdAccessoryDebitNot.Rows.Count; AccNo++)
            {
                AccessoryDebitNoteParticulars objDebitNoteParticulars = new AccessoryDebitNoteParticulars();

                HiddenField hdnId = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnId");
                HiddenField hdnParticularId = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnParticularId");
                HiddenField hdnDebitNote_SRVID = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnDebitNote_SRVID");
                HiddenField hdnIsExtrQty = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnIsExtrQty");
                Label lblDebitParticur = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitParticur");
                Label lblDebitQty = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitQty");
                Label lblDebitRate = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitRate");
                HiddenField hdnAmount = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnAmount");
                HiddenField hdnsrvNo = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnsrvNo");
                HiddenField HdnBillNumber = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("HdnBillNumber");


                if (hdnIdSelected.Value != hdnId.Value)
                {
                    objDebitNoteParticulars.DebitNoteParticularId = hdnParticularId.Value == "" ? 0 : Convert.ToInt32(hdnParticularId.Value);
                    objDebitNoteParticulars.Acc_DebitNote_SRVID = hdnDebitNote_SRVID.Value == "" ? 0 : Convert.ToInt32(hdnDebitNote_SRVID.Value);
                    objDebitNoteParticulars.IsExtraQty = hdnIsExtrQty.Value == "" ? -1 : Convert.ToInt32(hdnIsExtrQty.Value);
                    objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
                    objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToDouble(lblDebitQty.Text);
                    objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
                    objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);
                    objDebitNoteParticulars.SrvNo = hdnsrvNo.Value;
                    objDebitNoteParticulars.PartyBillNumber=HdnBillNumber.Value;

                    DebitNoteParticularsList.Add(objDebitNoteParticulars);
                }
            }

            grdAccessoryDebitNot.DataSource = DebitNoteParticularsList;
            grdAccessoryDebitNot.DataBind();

            CalculateGrandTotal();
            
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);
        }

        protected void grdAccessoryDebitNot_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdAccessoryDebitNot.EditIndex = e.NewEditIndex;

            List<AccessoryDebitNoteParticulars> DebitNoteParticularsList = new List<AccessoryDebitNoteParticulars>();
            for (int AccNo = 0; AccNo < grdAccessoryDebitNot.Rows.Count; AccNo++)
            {
                AccessoryDebitNoteParticulars objDebitNoteParticulars = new AccessoryDebitNoteParticulars();

                HiddenField hdnParticularId = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnParticularId");
                HiddenField hdnDebitNote_SRVID = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnDebitNote_SRVID");
                HiddenField hdnIsExtrQty = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnIsExtrQty");
                Label lblDebitParticur = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitParticur");
                Label lblDebitQty = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitQty");
                Label lblDebitRate = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitRate");
                HiddenField hdnAmount = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnAmount");
                HiddenField hdnsrvno = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnsrvNo");
                HiddenField HdnBillNumber = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("HdnBillNumber");


                objDebitNoteParticulars.DebitNoteParticularId = hdnParticularId.Value == "" ? 0 : Convert.ToInt32(hdnParticularId.Value);
                objDebitNoteParticulars.Acc_DebitNote_SRVID = hdnDebitNote_SRVID.Value == "" ? 0 : Convert.ToInt32(hdnDebitNote_SRVID.Value);
                objDebitNoteParticulars.IsExtraQty = hdnIsExtrQty.Value == "" ? -1 : Convert.ToInt32(hdnIsExtrQty.Value);
                objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
                objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToDouble(lblDebitQty.Text);
                objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
                objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);
                objDebitNoteParticulars.SrvNo = hdnsrvno.Value == "" ? "" : hdnsrvno.Value;
                objDebitNoteParticulars.PartyBillNumber = HdnBillNumber.Value == "" ? "" : HdnBillNumber.Value;

                DebitNoteParticularsList.Add(objDebitNoteParticulars);

            }

            grdAccessoryDebitNot.DataSource = DebitNoteParticularsList;
            grdAccessoryDebitNot.DataBind();

            CalculateGrandTotal();

            TextBox txtDebitQty = (TextBox)grdAccessoryDebitNot.Rows[e.NewEditIndex].FindControl("txtDebitQty");
            Label lblExtraQtyEdit = (Label)grdAccessoryDebitNot.Rows[e.NewEditIndex].FindControl("lblExtraQtyEdit");

            if ((lblExtraQtyEdit.Text == "Extra Qty") || (lblExtraQtyEdit.Text == "Fail Qty"))
            {
                txtDebitQty.Attributes.Add("readonly", "readonly");
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);
        }

        protected void grdAccessoryDebitNot_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdAccessoryDebitNot.EditIndex = -1;
            BindData(0);
            CalculateGrandTotal();
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);
        }

        protected void grdAccessoryDebitNot_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdAccessoryDebitNot.Rows[e.RowIndex];
            HiddenField hdnParticularIdEdit = (HiddenField)row.FindControl("hdnParticularIdEdit");
            HiddenField hdnDebitNote_SRVIDEdit = (HiddenField)row.FindControl("hdnDebitNote_SRVIDEdit");
            HiddenField hdnIsExtrQtyEdit = (HiddenField)row.FindControl("hdnIsExtrQtyEdit");
            TextBox txtDebitParticur = (TextBox)row.FindControl("txtDebitParticur");
            TextBox txtDebitQty = (TextBox)row.FindControl("txtDebitQty");
            TextBox txtDebitRate = (TextBox)row.FindControl("txtDebitRate");
            HiddenField hdnsrvno = (HiddenField)row.FindControl("hdnsrvNo");
            HiddenField HdnBillNumber = (HiddenField)row.FindControl("HdnBillNumber");


            Label lblsrvno = (Label)row.FindControl("lblSrvno");

            if ((txtDebitParticur.Text == "") || (txtDebitQty.Text == "") || (txtDebitRate.Text == ""))
            {
                ShowAlert("Field can not be empty!");
                return;
            }

            List<AccessoryDebitNoteParticulars> DebitNoteParticularsList = new List<AccessoryDebitNoteParticulars>();
            for (int AccNo = 0; AccNo < grdAccessoryDebitNot.Rows.Count; AccNo++)
            {
                AccessoryDebitNoteParticulars objDebitNoteParticulars = new AccessoryDebitNoteParticulars();

                HiddenField hdnParticularId = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnParticularId");
                HiddenField hdnDebitNote_SRVID = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnDebitNote_SRVID");
                HiddenField hdnIsExtrQty = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnIsExtrQty");
                Label lblDebitParticur = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitParticur");
                Label lblDebitQty = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitQty");
                Label lblDebitRate = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitRate");
                HiddenField hdnAmount = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnAmount");
                HiddenField hdnsrvNo = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnsrvNo");


                if (hdnParticularId == null)
                {
                    objDebitNoteParticulars.DebitNoteParticularId = hdnParticularIdEdit.Value == "" ? 0 : Convert.ToInt32(hdnParticularIdEdit.Value);
                    objDebitNoteParticulars.Acc_DebitNote_SRVID = hdnDebitNote_SRVIDEdit.Value == "" ? 0 : Convert.ToInt32(hdnDebitNote_SRVIDEdit.Value);
                    objDebitNoteParticulars.IsExtraQty = hdnIsExtrQtyEdit.Value == "" ? -1 : Convert.ToInt32(hdnIsExtrQtyEdit.Value);
                    objDebitNoteParticulars.ParticularName = txtDebitParticur.Text;
                    objDebitNoteParticulars.DebitQuantity = txtDebitQty.Text == "" ? 0 : Convert.ToDouble(txtDebitQty.Text);
                    objDebitNoteParticulars.DebitRate = txtDebitRate.Text == "" ? 0 : Convert.ToDouble(txtDebitRate.Text);
                    objDebitNoteParticulars.Amount = (objDebitNoteParticulars.DebitQuantity * objDebitNoteParticulars.DebitRate);
                    objDebitNoteParticulars.SrvNo = hdnsrvNo.Value;
                    objDebitNoteParticulars.PartyBillNumber = HdnBillNumber.Value;

                    DebitNoteParticularsList.Add(objDebitNoteParticulars);
                }
                else
                {
                    objDebitNoteParticulars.DebitNoteParticularId = hdnParticularId.Value == "" ? 0 : Convert.ToInt32(hdnParticularId.Value);
                    objDebitNoteParticulars.Acc_DebitNote_SRVID = hdnDebitNote_SRVID.Value == "" ? 0 : Convert.ToInt32(hdnDebitNote_SRVID.Value);
                    objDebitNoteParticulars.IsExtraQty = hdnIsExtrQty.Value == "" ? -1 : Convert.ToInt32(hdnIsExtrQty.Value);
                    objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
                    objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToDouble(lblDebitQty.Text);
                    objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
                    objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);
                    objDebitNoteParticulars.SrvNo = hdnsrvNo.Value;
                    objDebitNoteParticulars.PartyBillNumber = HdnBillNumber.Value;
                    DebitNoteParticularsList.Add(objDebitNoteParticulars);
                }
            }

            grdAccessoryDebitNot.EditIndex = -1;
            grdAccessoryDebitNot.DataSource = DebitNoteParticularsList;
            grdAccessoryDebitNot.DataBind();

            CalculateGrandTotal();
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);
        }

        protected void grdAccessoryDebitNot_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddEmpty")
            {
                Table tblgvDetail = (Table)grdAccessoryDebitNot.Controls[0];
                GridViewRow rows = (GridViewRow)tblgvDetail.Controls[0];

                TextBox txtDebitParticular_Empty = (TextBox)rows.FindControl("txtDebitParticular_Empty");
                TextBox txtDebitQty_Empty = (TextBox)rows.FindControl("txtDebitQty_Empty");
                TextBox txtDebitRate_Empty = (TextBox)rows.FindControl("txtDebitRate_Empty");
                HiddenField hdnAmount_Empty = (HiddenField)rows.FindControl("hdnAmount_Empty");
                HiddenField hdnExtrQty_Empty = (HiddenField)rows.FindControl("hdnExtrQty_Empty");
                Label lblsrvno = (Label)rows.FindControl("srvno_Empty");
                Label lblBillNo = (Label)rows.FindControl("lblBillNo_edit");
                HiddenField HdnBillNumber = (HiddenField)rows.FindControl("HdnBillNumber");

                List<AccessoryDebitNoteParticulars> DebitNoteParticularsList = new List<AccessoryDebitNoteParticulars>();
                AccessoryDebitNoteParticulars objDebitNoteParticulars = new AccessoryDebitNoteParticulars();
                objDebitNoteParticulars.ParticularName = txtDebitParticular_Empty.Text;
                objDebitNoteParticulars.IsExtraQty = hdnExtrQty_Empty.Value == "" ? -1 : Convert.ToInt32(hdnExtrQty_Empty.Value);
                objDebitNoteParticulars.DebitQuantity = txtDebitQty_Empty.Text == "" ? 0 : Convert.ToDouble(txtDebitQty_Empty.Text);
                objDebitNoteParticulars.DebitRate = txtDebitRate_Empty.Text == "" ? 0 : Convert.ToDouble(txtDebitRate_Empty.Text);
                objDebitNoteParticulars.Amount = hdnAmount_Empty.Value == "" ? 0 : Convert.ToDouble(hdnAmount_Empty.Value);
                objDebitNoteParticulars.DebitNoteParticularId = -1;
                objDebitNoteParticulars.Acc_DebitNote_SRVID = -1;
                objDebitNoteParticulars.SrvNo = lblsrvno.Text == "" ? "" : lblsrvno.Text;
                objDebitNoteParticulars.PartyBillNumber = HdnBillNumber.Value;
               

                DebitNoteParticularsList.Add(objDebitNoteParticulars);

                grdAccessoryDebitNot.DataSource = DebitNoteParticularsList;
                grdAccessoryDebitNot.DataBind();

                CalculateGrandTotal();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);
            }
            if (e.CommandName == "Insert")
            {
                int MaxId = 0;
                List<AccessoryDebitNoteParticulars> DebitNoteParticularsList = new List<AccessoryDebitNoteParticulars>();
                for (int AccNo = 0; AccNo < grdAccessoryDebitNot.Rows.Count; AccNo++)
                {
                    AccessoryDebitNoteParticulars objDebitNoteParticulars = new AccessoryDebitNoteParticulars();

                    HiddenField hdnParticularId = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnParticularId");
                    HiddenField hdnDebitNote_SRVID = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnDebitNote_SRVID");
                    HiddenField hdnIsExtrQty = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnIsExtrQty");
                    Label lblDebitParticur = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitParticur");
                    Label lblDebitQty = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitQty");
                    Label lblDebitRate = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitRate");
                    HiddenField hdnAmount = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnAmount");
                    HiddenField hdnsrvno2 = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnsrvNo");
                    Label lblBillNo = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblBillNo_edit");



                    objDebitNoteParticulars.DebitNoteParticularId = hdnParticularId.Value == "" ? 0 : Convert.ToInt32(hdnParticularId.Value);
                    objDebitNoteParticulars.Acc_DebitNote_SRVID = hdnDebitNote_SRVID.Value == "" ? 0 : Convert.ToInt32(hdnDebitNote_SRVID.Value);
                    objDebitNoteParticulars.IsExtraQty = hdnIsExtrQty.Value == "" ? -1 : Convert.ToInt32(hdnIsExtrQty.Value);
                    objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
                    objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToDouble(lblDebitQty.Text);
                    objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
                    objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);
                    objDebitNoteParticulars.SrvNo = hdnsrvno2.Value;
                    objDebitNoteParticulars.PartyBillNumber = lblBillNo.Text.Trim();
                    // objDebitNoteParticulars.SrvNo=h

                    MaxId = MaxId + AccNo + 1;

                    DebitNoteParticularsList.Add(objDebitNoteParticulars);
                }

                AccessoryDebitNoteParticulars objDebitNoteParticularsFoo = new AccessoryDebitNoteParticulars();

                TextBox txtDebitParticur_Footer = grdAccessoryDebitNot.FooterRow.FindControl("txtDebitParticur_Footer") as TextBox;
                TextBox txtDebitQty_Footer = grdAccessoryDebitNot.FooterRow.FindControl("txtDebitQty_Footer") as TextBox;
                TextBox txtDebitRate_Footer = grdAccessoryDebitNot.FooterRow.FindControl("txtDebitRate_Footer") as TextBox;
                HiddenField hdnAmount_Footer = grdAccessoryDebitNot.FooterRow.FindControl("hdnAmount_Footer") as HiddenField;
                HiddenField hdnIsExtrQtyFooter = grdAccessoryDebitNot.FooterRow.FindControl("hdnIsExtrQtyFooter") as HiddenField;
                Label lblSrvNo_Footer = grdAccessoryDebitNot.FooterRow.FindControl("lblSrvNo_Footer") as Label;
                Label lblBillNo_Footer = grdAccessoryDebitNot.FooterRow.FindControl("lblBillNo_Footer") as Label;

                objDebitNoteParticularsFoo.ParticularName = txtDebitParticur_Footer.Text;
                objDebitNoteParticularsFoo.IsExtraQty = hdnIsExtrQtyFooter.Value == "" ? -1 : Convert.ToInt32(hdnIsExtrQtyFooter.Value);
                objDebitNoteParticularsFoo.DebitQuantity = txtDebitQty_Footer.Text == "" ? 0 : Convert.ToDouble(txtDebitQty_Footer.Text);
                objDebitNoteParticularsFoo.DebitRate = txtDebitRate_Footer.Text == "" ? 0 : Convert.ToDouble(txtDebitRate_Footer.Text);
                objDebitNoteParticularsFoo.Amount = hdnAmount_Footer.Value == "" ? 0 : Convert.ToDouble(hdnAmount_Footer.Value);
                objDebitNoteParticularsFoo.DebitNoteParticularId = -1;
                objDebitNoteParticularsFoo.Acc_DebitNote_SRVID = -1;
                objDebitNoteParticularsFoo.SrvNo = lblSrvNo_Footer.Text == "" ? "" : lblSrvNo_Footer.Text;
                objDebitNoteParticularsFoo.PartyBillNumber = lblBillNo_Footer.Text;

                DebitNoteParticularsList.Add(objDebitNoteParticularsFoo);

                grdAccessoryDebitNot.DataSource = DebitNoteParticularsList;
                grdAccessoryDebitNot.DataBind();

                CalculateGrandTotal();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);
            }
        }

        protected void grdAccessoryDebitNot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                Label lblEmptyQtyHeader = (Label)e.Row.FindControl("lblEmptyQtyHeader");
                lblEmptyQtyHeader.Text = "Quantity <span style='color:gray;font-weight:600'>(" + hdnGarmentUnitName.Value + ")</span>";
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                Label lblQtyHeader = (Label)e.Row.FindControl("lblQtyHeader");
                lblQtyHeader.Text = "Quantity  <span style='color:gray;font-weight:600'>(" + hdnGarmentUnitName.Value + ")</span>";
            }
            if (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))
            {
                int IsExtrQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IsExtraQty"));
                Label lblExtraQtyEdit = (Label)e.Row.FindControl("lblExtraQtyEdit");
                if (IsExtrQty == -1)
                    lblExtraQtyEdit.Text = "N/A";
                if (IsExtrQty == 0)
                    lblExtraQtyEdit.Text = "Fail Qty";
                if (IsExtrQty == 1)
                    lblExtraQtyEdit.Text = "Extra Qty";


                double DebitQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DebitQuantity"));
                double DebitRate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DebitRate"));

                Label lblAmountEdit = (Label)e.Row.FindControl("lblAmountEdit");
                //lblAmountEdit.Text = Math.Round((DebitQuantity * DebitRate),2).ToString();
                lblAmountEdit.Text = Math.Round((DebitQuantity * DebitRate), 2).ToString("N").TrimEnd('0').TrimEnd('.');

                TextBox txtDebitQty = (TextBox)e.Row.FindControl("txtDebitQty");
                txtDebitQty.Text = (DebitQuantity).ToString("N").TrimEnd('0').TrimEnd('.');

                HiddenField hdnAmountEdit = (HiddenField)e.Row.FindControl("hdnAmountEdit");
                hdnAmountEdit.Value = (DebitQuantity * DebitRate).ToString();

                TotalAmount = TotalAmount + Convert.ToDouble(hdnAmountEdit.Value);
            }
            else if (e.Row.RowState == DataControlRowState.Edit)
            {
                int IsExtrQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IsExtraQty"));
                Label lblExtraQtyEdit = (Label)e.Row.FindControl("lblExtraQtyEdit");
                if (IsExtrQty == -1)
                    lblExtraQtyEdit.Text = "N/A";
                if (IsExtrQty == 0)
                    lblExtraQtyEdit.Text = "Fail Qty";
                if (IsExtrQty == 1)
                    lblExtraQtyEdit.Text = "Extra Qty";

                double DebitQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DebitQuantity"));
                double DebitRate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DebitRate"));

                Label lblAmountEdit = (Label)e.Row.FindControl("lblAmountEdit");
                //lblAmountEdit.Text = Math.Round((DebitQuantity * DebitRate),2).ToString();
                lblAmountEdit.Text = Math.Round((DebitQuantity * DebitRate), 2).ToString("N").TrimEnd('0').TrimEnd('.');

                TextBox txtDebitQty = (TextBox)e.Row.FindControl("txtDebitQty");
                txtDebitQty.Text = (DebitQuantity).ToString("N").TrimEnd('0').TrimEnd('.');

                HiddenField hdnAmountEdit = (HiddenField)e.Row.FindControl("hdnAmountEdit");
                hdnAmountEdit.Value = (DebitQuantity * DebitRate).ToString();

                TotalAmount = TotalAmount + Convert.ToDouble(hdnAmountEdit.Value);
            }
            else if (e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Alternate))
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int IsExtrQty = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IsExtraQty"));
                    Label lblExtraQty = (Label)e.Row.FindControl("lblExtraQty");
                    if (IsExtrQty == -1)
                        lblExtraQty.Text = "N/A";
                    if (IsExtrQty == 0)
                        lblExtraQty.Text = "Fail Qty";
                    if (IsExtrQty == 1)
                        lblExtraQty.Text = "Extra Qty";

                    double DebitQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DebitQuantity"));
                    double DebitRate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DebitRate"));

                    Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                    //lblAmount.Text = Math.Round((DebitQuantity * DebitRate),2).ToString();
                    lblAmount.Text = Math.Round((DebitQuantity * DebitRate), 2).ToString("N").TrimEnd('0').TrimEnd('.');

                    Label lblDebitQty = (Label)e.Row.FindControl("lblDebitQty");
                    lblDebitQty.Text = (DebitQuantity).ToString("N").TrimEnd('0').TrimEnd('.');

                    HiddenField hdnAmount = (HiddenField)e.Row.FindControl("hdnAmount");
                    hdnAmount.Value = (DebitQuantity * DebitRate).ToString();

                    TotalAmount = TotalAmount + Convert.ToDouble(hdnAmount.Value);
                }
            }
        }

        private void CalculateGrandTotal()
        {
            double IGSTAmount = 0, CGSTAmount = 0, SGSTAmount = 0;
            if (txtIGST.Text != "")
            {
                //IGSTAmount = Math.Round((TotalAmount * Convert.ToDouble(txtIGST.Text)) / 100, 2);
                //lblIGSTAmount.Text = IGSTAmount.ToString();
                IGSTAmount = Math.Round((TotalAmount * Convert.ToDouble(txtIGST.Text.Replace("%", "").Trim())) / 100, 2);
                lblIGSTAmount.Text = IGSTAmount.ToString("N").TrimEnd('0').TrimEnd('.');
                hdnIGSTAmount.Value = IGSTAmount.ToString();
            }
            if (lblIGSTAmount.Text != "")
            {
                lblIgstCurrency.Attributes.Add("class", "indianCurr");
            }

            if (txtCGST.Text != "")
            {
                //CGSTAmount = Math.Round((TotalAmount * Convert.ToDouble(txtCGST.Text)) / 100, 2);
                //lblCGSTAmount.Text = CGSTAmount.ToString();
                CGSTAmount = Math.Round((TotalAmount * Convert.ToDouble(txtCGST.Text.Replace("%", "").Trim())) / 100, 2);
                lblCGSTAmount.Text = CGSTAmount.ToString("N").TrimEnd('0').TrimEnd('.');
                hdnCGSTAmount.Value = CGSTAmount.ToString();
            }
            if (lblCGSTAmount.Text != "")
            {
                lblCgstCurrency.Attributes.Add("class", "indianCurr");
            }

            if (txtSGST.Text != "")
            {
                //SGSTAmount = Math.Round((TotalAmount * Convert.ToDouble(txtSGST.Text)) / 100, 2);
                //lblSGSTAmount.Text = SGSTAmount.ToString();
                SGSTAmount = Math.Round((TotalAmount * Convert.ToDouble(txtSGST.Text.Replace("%", "").Trim())) / 100, 2);
                lblSGSTAmount.Text = SGSTAmount.ToString("N").TrimEnd('0').TrimEnd('.');
                hdnSGSTAmount.Value = SGSTAmount.ToString();
            }
            if (lblSGSTAmount.Text != "")
            {
                lblSgstCurrency.Attributes.Add("class", "indianCurr");
            }

            if (TotalAmount > 0)
            {
                hdnTotalAmount.Value = TotalAmount.ToString();
                var GrandTotalAmount = Math.Round(TotalAmount + IGSTAmount + CGSTAmount + SGSTAmount, 2);
                //lblGrandTotalAmount.Text = GrandTotalAmount.ToString();
                lblGrandTotalAmount.Text = GrandTotalAmount.ToString("N").TrimEnd('0').TrimEnd('.');
                hdnGrandTotalAmount.Value = GrandTotalAmount.ToString();

                double GrandTotalAmountForText = Convert.ToDouble(Math.Round(TotalAmount + IGSTAmount + CGSTAmount + SGSTAmount, 2));
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "convertNumberToWords(" + GrandTotalAmountForText + ");", true);

            }
            if (lblGrandTotalAmount.Text != "")
            {
                lblGranTotalCurrency.Attributes.Add("class", "indianCurr");
            }
            ShowHideGst();
        }

        private void ResetGST()
        {
            txtIGST.Text = "";
            txtCGST.Text = "";
            txtSGST.Text = "";
            lblIGSTAmount.Text = "";
            hdnIGSTAmount.Value = "0";

            lblCGSTAmount.Text = "";
            hdnCGSTAmount.Value = "0";

            lblSGSTAmount.Text = "";
            hdnSGSTAmount.Value = "0";

            lblGrandTotalAmount.Text = "";
            hdnGrandTotalAmount.Value = "0";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AccessoryDebitNoteCls objAccessoryDebitNote = new AccessoryDebitNoteCls();
            double TotalAmount = hdnGrandTotalAmount.Value == "" ? 0 : Convert.ToDouble(hdnGrandTotalAmount.Value);
            double DebitQty = 0, Rate = 0;

            if (hdnIsChecked.Value == "0")
            {
                if (TotalAmount > 0)
                {
                    //AccessoryDebitNoteCls objAccessoryDebitNote = new AccessoryDebitNoteCls();
                    objAccessoryDebitNote.SupplierPoId = SupplierPoId;
                    objAccessoryDebitNote.DebitNoteId = hdnDebitnotid.Value == "" ? -1 : Convert.ToInt32(hdnDebitnotid.Value);
                    objAccessoryDebitNote.DebitNoteNumber = lblDebitNo.Text;
                    objAccessoryDebitNote.DebitNoteDate = txtDate.Text != "" ? DateTime.ParseExact(txtDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
                    objAccessoryDebitNote.PartyBillId = Convert.ToInt32(ddlBillNo.SelectedValue);
                    objAccessoryDebitNote.ReturnChallanNumber = txtReturnChallan.Text;
                    objAccessoryDebitNote.ChallanDate = txtreturndate.Text != "" ? DateTime.ParseExact(txtreturndate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;

                    if (txtSGST.Text != string.Empty && txtCGST.Text!=string.Empty)
                    {
                        objAccessoryDebitNote.SGST = Convert.ToDouble(txtSGST.Text);
                    }
                    else if (txtIGST.Text != string.Empty)
                    {

                        objAccessoryDebitNote.IGST = Convert.ToDouble(txtIGST.Text);

                    }
                   

                    objAccessoryDebitNote.TotalAmount = hdnGrandTotalAmount.Value == "" ? 0 : Convert.ToDouble(hdnGrandTotalAmount.Value);
                    if (chkAuthorised.Checked)
                        objAccessoryDebitNote.IsDebitNoteSigned = true;
                    else
                        objAccessoryDebitNote.IsDebitNoteSigned = false;

                    List<AccessoryDebitNoteParticulars> objDebitNoteParticularsList = new List<AccessoryDebitNoteParticulars>();

                    if (grdAccessoryDebitNot.Rows.Count == 0)
                    {
                        Control control = null;
                        control = grdAccessoryDebitNot.Controls[0].Controls[0];
                        if ((TextBox)control.FindControl("txtDebitParticular_Empty") != null)
                        {
                            TextBox txtDebitParticular_Empty = (TextBox)control.FindControl("txtDebitParticular_Empty");
                            TextBox txtDebitQty_Empty = (TextBox)control.FindControl("txtDebitQty_Empty");
                            TextBox txtDebitRate_Empty = (TextBox)control.FindControl("txtDebitRate_Empty");
                            HiddenField hdnExtrQty_Empty = (HiddenField)control.FindControl("hdnExtrQty_Empty");

                            DebitQty = txtDebitQty_Empty.Text == "" ? 0 : Convert.ToDouble(txtDebitQty_Empty.Text);
                            Rate = txtDebitRate_Empty.Text == "" ? 0 : Convert.ToDouble(txtDebitRate_Empty.Text);

                            if ((txtDebitParticular_Empty.Text != "") && (DebitQty != 0) && (Rate != 0))
                            {
                                AccessoryDebitNoteParticulars objDebitNoteParticulars = new AccessoryDebitNoteParticulars();

                                objDebitNoteParticulars.ParticularName = txtDebitParticular_Empty.Text;
                                objDebitNoteParticulars.IsExtraQty = hdnExtrQty_Empty.Value == "" ? -1 : Convert.ToInt32(hdnExtrQty_Empty.Value);
                                objDebitNoteParticulars.DebitQuantity = txtDebitQty_Empty.Text == "" ? 0 : Convert.ToDouble(txtDebitQty_Empty.Text);
                                objDebitNoteParticulars.DebitRate = txtDebitRate_Empty.Text == "" ? 0 : Convert.ToDouble(txtDebitRate_Empty.Text);
                                objDebitNoteParticulars.DebitNoteParticularId = -1;
                                objDebitNoteParticulars.Acc_DebitNote_SRVID = -1;

                                objDebitNoteParticularsList.Add(objDebitNoteParticulars);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < grdAccessoryDebitNot.Rows.Count; i++)
                        {
                            if (grdAccessoryDebitNot.Rows[i].RowState == DataControlRowState.Edit)
                            {
                                ShowAlert("Please remove editable mode!");
                                ShowHideGst();
                                return;
                            }
                            if (grdAccessoryDebitNot.Rows[i].RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))
                            {
                                ShowAlert("Please remove editable mode!");
                                ShowHideGst();
                                return;
                            }
                            Label lblDebitParticur = (Label)grdAccessoryDebitNot.Rows[i].FindControl("lblDebitParticur");
                            Label lblDebitQty = (Label)grdAccessoryDebitNot.Rows[i].FindControl("lblDebitQty");
                            Label lblDebitRate = (Label)grdAccessoryDebitNot.Rows[i].FindControl("lblDebitRate");
                            HiddenField hdnParticularId = (HiddenField)grdAccessoryDebitNot.Rows[i].FindControl("hdnParticularId");
                            HiddenField hdnDebitNote_SRVID = (HiddenField)grdAccessoryDebitNot.Rows[i].FindControl("hdnDebitNote_SRVID");
                            HiddenField hdnIsExtrQty = (HiddenField)grdAccessoryDebitNot.Rows[i].FindControl("hdnIsExtrQty");

                            DebitQty = lblDebitQty.Text == "" ? 0 : Convert.ToDouble(lblDebitQty.Text);
                            Rate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);

                            if ((lblDebitParticur.Text != "") && (DebitQty != 0) && (Rate != 0))
                            {
                                AccessoryDebitNoteParticulars objDebitNoteParticulars = new AccessoryDebitNoteParticulars();

                                objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
                                objDebitNoteParticulars.IsExtraQty = hdnIsExtrQty.Value == "" ? -1 : Convert.ToInt32(hdnIsExtrQty.Value);
                                objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToDouble(lblDebitQty.Text);
                                objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
                                objDebitNoteParticulars.DebitNoteParticularId = hdnParticularId.Value == "" ? -1 : Convert.ToInt32(hdnParticularId.Value);
                                objDebitNoteParticulars.Acc_DebitNote_SRVID = hdnDebitNote_SRVID.Value == "" ? -1 : Convert.ToInt32(hdnDebitNote_SRVID.Value);

                                objDebitNoteParticularsList.Add(objDebitNoteParticulars);
                            }
                        }

                        TextBox txtDebitParticur_Footer = (TextBox)grdAccessoryDebitNot.FooterRow.FindControl("txtDebitParticur_Footer");
                        TextBox txtDebitQty_Footer = (TextBox)grdAccessoryDebitNot.FooterRow.FindControl("txtDebitQty_Footer");
                        TextBox txtDebitRate_Footer = (TextBox)grdAccessoryDebitNot.FooterRow.FindControl("txtDebitRate_Footer");
                        HiddenField hdnIsExtrQtyFooter = (HiddenField)grdAccessoryDebitNot.FooterRow.FindControl("hdnIsExtrQtyFooter");
                        DebitQty = txtDebitQty_Footer.Text == "" ? 0 : Convert.ToDouble(txtDebitQty_Footer.Text);
                        Rate = txtDebitRate_Footer.Text == "" ? 0 : Convert.ToDouble(txtDebitRate_Footer.Text);

                        if ((txtDebitParticur_Footer.Text != "") && (DebitQty != 0) && (Rate != 0))
                        {
                            AccessoryDebitNoteParticulars objDebitNoteParticulars = new AccessoryDebitNoteParticulars();

                            objDebitNoteParticulars.ParticularName = txtDebitParticur_Footer.Text;
                            objDebitNoteParticulars.IsExtraQty = hdnIsExtrQtyFooter.Value == "" ? -1 : Convert.ToInt32(hdnIsExtrQtyFooter.Value);
                            objDebitNoteParticulars.DebitQuantity = txtDebitQty_Footer.Text == "" ? 0 : Convert.ToDouble(txtDebitQty_Footer.Text);
                            objDebitNoteParticulars.DebitRate = txtDebitRate_Footer.Text == "" ? 0 : Convert.ToDouble(txtDebitRate_Footer.Text);
                            objDebitNoteParticulars.DebitNoteParticularId = -1;
                            objDebitNoteParticulars.Acc_DebitNote_SRVID = -1;

                            objDebitNoteParticularsList.Add(objDebitNoteParticulars);
                        }
                    }

                    objAccessoryDebitNote.AccessoryDebitNoteParticularsList = objDebitNoteParticularsList;

                    int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                    int iSave = objAccessoryWorking.Save_Accessory_DebitNote(objAccessoryDebitNote, UserId);

                    DebitNoteId = iSave;
                    if (iSave > 0)
                    {

                        if ((objAccessoryDebitNote.IsDebitNoteSigned == true) && (rbtnYes.Checked))
                        {
                            RenderHtml();

                            //string thisPath = "DebitNote_" + DebitNoteId + "(" + hdnBill_Number.Value + ")" + ".pdf";
                            string thisPath = "DebitNote_" + DebitNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf";

                            string url = host + "/Uploads/Print/" + thisPath;

                            string EmailContent = HttpContent(url);

                            SendDebitNoteEmail("test", "kumar", EmailContent, MailType);
                        }

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "jQuery.facebox('Some error occured);", true);
                        return;
                    }
                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "jQuery.facebox('Details can not be empty');", true);
                    return;
                }
            }
            if (hdnIsChecked.Value == "1" && rbtnYes.Checked)
            {
                RenderHtml();

                //string thisPath = "DebitNote_" + DebitNoteId + "(" + hdnBill_Number.Value + ")" + ".pdf";
                string thisPath = "DebitNote_" + DebitNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf";

                string url = host + "/Uploads/Print/" + thisPath;

                string EmailContent = HttpContent(url);

                SendDebitNoteEmail("test", "kumar", EmailContent, MailType);

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
            }

            ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            BindData(1);
            CalculateGrandTotal();
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        public void RenderHtml()
        {
            WebRequest Request;
            WebResponse Response;
            StreamReader reader;

            string strHTML;
            Request = WebRequest.Create(host + "/AccessoryPdfFile/AccessoryDebitNotePdf.aspx?SupplierPoId=" + SupplierPoId + "&DebitNoteId=" + DebitNoteId + "&RupeesInWord=" + hdnRupees.Value);

            Request.Timeout = Convert.ToInt32(99999999);
            Response = Request.GetResponse();
            reader = new StreamReader(Response.GetResponseStream());
            strHTML = reader.ReadToEnd();
            genertaePdf(strHTML, "ss");
        }

        public void genertaePdf(string HTMLCode, string PolicyFile)
        {
            //string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Print/" + "DebitNote_" + DebitNoteId.ToString() + "(" + hdnBill_Number.Value + ")" + ".pdf");
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Print/" + "DebitNote_" + DebitNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf");
            HTMLCode = getImage(HTMLCode);
            getvartypeHTML(HTMLCode, strFileName);
        }

        public void getvartypeHTML(string HTMLCode, string PolicyFile)
        {
            //string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Print/" + "DebitNote_" + DebitNoteId.ToString() + "(" + hdnBill_Number.Value + ")" + ".pdf");
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Print/" + "DebitNote_" + DebitNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf");

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

        public Boolean SendDebitNoteEmail(String ClientName, String UsernamePasswordList, String ToEmail, string MailType)
        {

            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                List<String> to = new List<String>();


                //string email = hdnSupplierEmail.Value.ToString();
                string email = "itsupport@boutique.in";
                to.Add(email);
                //string[] email2 = email.Split(',');
                //foreach (string em in email2)
                //{
                //    to.Add(em);
                //}
                List<Attachment> atts = new List<Attachment>();

                //if (File.Exists(Constants.PRINT_FOLDER_PATH + "DebitNote_" + DebitNoteId.ToString() + "(" + hdnBill_Number.Value + ")" + ".pdf"))
                if (File.Exists(Constants.PRINT_FOLDER_PATH + "DebitNote_" + DebitNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf"))
                {

                    // PoPath = Path.Combine(Constants.PRINT_FOLDER_PATH, "DebitNote_" + DebitNoteId.ToString() + "(" + hdnBill_Number.Value + ")" + ".pdf");
                    PoPath = Path.Combine(Constants.PRINT_FOLDER_PATH, "DebitNote_" + DebitNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf");

                    atts.Add(new Attachment(PoPath));
                }

                this.SendEmail(fromName, to, null, null, ToEmail, MailType, atts, false, false);



                return true;


            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return false;
            }
        }

        public Boolean SendEmail(String FromEmail, List<String> To, List<String> CC, List<String> BCC, String Subject, String Content, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            //mailMessage.Subject = MailType + " " + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + " for PO (" + hdnPO_Number.Value + ")";
            mailMessage.Subject = MailType + "Against Purchase Order (" + hdnPO_Number.Value + ")";
            mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a <b>Debit note</b> is raised against <span style='color:gray'>" + "Bill No - </span></span><span style='color:#2f5597'>" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + "</span> for <span style='color:gray'>" + "Purchase Order - </span></span><span style='color:#2f5597'>" + hdnPO_Number.Value + "</span>. Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> Disclaimer: This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
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
                //mailMessage.CC.Add("ravishankar@boutique.in");
                mailMessage.CC.Add("itsupport@boutique.in");
                //mailMessage.CC.Add("raghvinder@boutique.in");

            }
            else
            {
                foreach (String to in To)
                    mailMessage.To.Add(to);
                //mailMessage.Bcc.Add("samrat@boutique.in");
                //mailMessage.CC.Add("karan@boutique.in");
                //mailMessage.CC.Add("vinaygupta@boutique.in");
                //mailMessage.CC.Add("baldev@boutique.in");
                //mailMessage.CC.Add("shivraj@boutique.in");
                //mailMessage.CC.Add("atish@boutique.in");
                //mailMessage.CC.Add("itsupport@boutique.in");

                //mailMessage.CC.Add("ravi@boutique.in");


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
                System.Diagnostics.Trace.WriteLine("Email Having Subject of --" + Subject.ToString() + " is send successfully on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                hdnMailSentStatus.Value = "1";
                ShowAlert("Mail Sent successfully");
                return true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Some error has been occur in Email having subject of ---" + Subject.ToString() + " On" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
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
    }
}