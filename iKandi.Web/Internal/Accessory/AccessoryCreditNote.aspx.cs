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
    public partial class AccessoryCreditNote : System.Web.UI.Page
    {
        public int SupplierPoId
        {
            get;
            set;
        }
        public int CreditNoteId
        {
            get;
            set;
        }
        private double TotalAmount = 0;
        string host = "";
        string MailType = "Accessory Credit Note Against Debit Note ";
        string PoPath = string.Empty;
        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();

        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;
            GetQueryString();
            if (!IsPostBack)
            {
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
            if (Request.QueryString["CreditNoteId"] != null)
            {
                CreditNoteId = Convert.ToInt32(Request.QueryString["CreditNoteId"]);
            }
            else
            {
                CreditNoteId = 0;
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBillDropdownList(ddlType.SelectedValue, CreditNoteId);
        }

        private void BindBillDropdownList(string type, int CreditNoteId)
        {
            if (CreditNoteId > 0)
                type = "ByCreditId";

            List<Accessory_Srv_Bill> Accessory_Srv_BillList = objAccessoryWorking.GetAccessory_List_Against_Debit_Bill(SupplierPoId, CreditNoteId, type);
            if (Accessory_Srv_BillList.Count > 0)
            {
                ddlBillNo.DataSource = Accessory_Srv_BillList;
                ddlBillNo.DataTextField = "BillDetails";
                ddlBillNo.DataValueField = "PartyBillId";
                ddlBillNo.DataBind();

                if (CreditNoteId > 0)
                {
                    ddlBillNo.SelectedValue = CreditNoteId.ToString();
                }
                string BillDetails = ddlBillNo.SelectedItem.Text;
                string[] sChar = BillDetails.Split('(');
                string[] sChar1 = sChar[1].Split(')');
                string sAmount = sChar1[0].ToString();
                hdnBillAmount.Value = sAmount.Trim();
            }
            else
            {
                ddlBillNo.Items.Clear();
                ddlBillNo.Items.Add(new ListItem("----------Select-----------", "0", true));
                hdnBillAmount.Value = "0";
            }

        }

        private void BindData(int IsPageRefresh)
        {
            AccessoryCreditNoteCls objAccessoryCreditNote = objAccessoryWorking.Get_AccessoryCreditNote(SupplierPoId, CreditNoteId);

            IsCreditNoteSigned.Value = objAccessoryCreditNote.IsCreditNoteSigned.ToString();

            hdnCreditnotid.Value = objAccessoryCreditNote.CreditNoteId.ToString();
            lblCreditNo.Text = objAccessoryCreditNote.CreditNoteNumber;
            lblSupllierName.Text = objAccessoryCreditNote.SupplierName;

            lblSupplierGstNo.Text = objAccessoryCreditNote.GSTNo;
            lblSupplierAddress.Text = objAccessoryCreditNote.SupplierAddress;
            // rajeevs 14022023            
            string HSNCode = objAccessoryCreditNote.HSNCode.ToString();
            if (HSNCode == "")
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
            // rajeevs 14022023	
            hdnPO_Number.Value = objAccessoryCreditNote.PoNumber;            

            List<AccessoryCreditNoteParticulars> objCreditNoteParticulars = objAccessoryCreditNote.AccessoryCreditNoteParticularsList;
            grdAccessoryCreditNot.DataSource = objCreditNoteParticulars;
            grdAccessoryCreditNot.DataBind();

            hdnGST_No.Value = objAccessoryCreditNote.GSTNo.ToString();
            hdnDebitNoteNumber.Value = objAccessoryCreditNote.DebitNoteNumber.ToString();
            
             
            if ((hdnGST_No.Value != "") && (hdnGST_No.Value != "0"))
            {
                string StateId = hdnGST_No.Value.Substring(0, 2);
                if (StateId == "09")
                {
                    objAccessoryCreditNote.IGST = 0;
                }
                else
                {
                    objAccessoryCreditNote.CGST = 0;
                    objAccessoryCreditNote.SGST = 0;
                }
            }
            txtIGST.Text = objAccessoryCreditNote.IGST == 0 ? "" : objAccessoryCreditNote.IGST.ToString();
            txtCGST.Text = objAccessoryCreditNote.CGST == 0 ? "" : objAccessoryCreditNote.CGST.ToString();
            txtSGST.Text = objAccessoryCreditNote.SGST == 0 ? "" : objAccessoryCreditNote.SGST.ToString();

            if (CreditNoteId > 0)
            {
                txtDate.Text = objAccessoryCreditNote.CreditNoteDate.ToString("dd MMM yy (ddd)");
                BindBillDropdownList(ddlType.SelectedValue, CreditNoteId);
                ddlType.Attributes.Add("disabled", "disabled");
                ddlBillNo.Attributes.Add("disabled", "disabled");
            }
            else
            {
                txtDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                if (IsPageRefresh == 0)
                {
                    BindBillDropdownList(ddlType.SelectedValue, CreditNoteId);
                }
            }
            if (objAccessoryCreditNote.IsCreditNoteSigned)
            {
                divChkAuthorized.Visible = false;
                chkAuthorised.Checked = true;
                divSigAuthorized.Visible = true;
                hdnIsChecked.Value = "1";
                lblAuthorizedName.Text = objAccessoryCreditNote.CreditNoteSignedBy;
                imgAuthorized.ImageUrl = objAccessoryCreditNote.AuthSignature != string.Empty ? "~/Uploads/Photo/" + objAccessoryCreditNote.AuthSignature : "~/Uploads/Photo/NotSign.jpg";
                lblAuthorizedOnDate.Text = Convert.ToDateTime(objAccessoryCreditNote.CreditNoteSignDate).ToString("dd MMM yy (ddd)");

                dvSendMail.Attributes.Add("style", "display:''");
                dvSendMail.Attributes.Add("style", "float:left;font-weight: bold;margin-left:8px;");
            }
            //CalculateGrandTotal();              

        }

        protected void grdAccessoryCreditNot_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdAccessoryCreditNot.Rows[e.RowIndex];
            HiddenField hdnIdSelected = (HiddenField)row.FindControl("hdnId");
            HiddenField hdnParticularIdSelected = (HiddenField)row.FindControl("hdnParticularId");

            CreditNoteId = hdnCreditnotid.Value == "" ? -1 : Convert.ToInt32(hdnCreditnotid.Value);

            AccessoryCreditNoteParticulars objDelete = new AccessoryCreditNoteParticulars();
            objDelete.CreditNoteId = CreditNoteId;
            objDelete.ParticularName = "";
            objDelete.CreditNoteParticularId = hdnParticularIdSelected.Value == "" ? -1 : Convert.ToInt32(hdnParticularIdSelected.Value);

            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            string stype = "DELETE";
            if (objDelete.CreditNoteParticularId > 0)
            {
                int iSave = objAccessoryWorking.Update_Accessory_CreditNotePartyCulars(objDelete, UserId, stype);
            }

            List<AccessoryCreditNoteParticulars> CreditNoteParticularsList = new List<AccessoryCreditNoteParticulars>();
            for (int AccNo = 0; AccNo < grdAccessoryCreditNot.Rows.Count; AccNo++)
            {
                AccessoryCreditNoteParticulars objCreditNoteParticulars = new AccessoryCreditNoteParticulars();

                HiddenField hdnId = (HiddenField)grdAccessoryCreditNot.Rows[AccNo].FindControl("hdnId");
                HiddenField hdnParticularId = (HiddenField)grdAccessoryCreditNot.Rows[AccNo].FindControl("hdnParticularId");
                Label lblCreditParticur = (Label)grdAccessoryCreditNot.Rows[AccNo].FindControl("lblCreditParticur");
                Label lblCreditQty = (Label)grdAccessoryCreditNot.Rows[AccNo].FindControl("lblCreditQty");
                Label lblCreditRate = (Label)grdAccessoryCreditNot.Rows[AccNo].FindControl("lblCreditRate");
                HiddenField hdnAmount = (HiddenField)grdAccessoryCreditNot.Rows[AccNo].FindControl("hdnAmount");

                if (hdnIdSelected.Value != hdnId.Value)
                {
                    objCreditNoteParticulars.CreditNoteParticularId = hdnParticularId.Value == "" ? 0 : Convert.ToInt32(hdnParticularId.Value);
                    objCreditNoteParticulars.ParticularName = lblCreditParticur.Text;
                    objCreditNoteParticulars.CreditQuantity = lblCreditQty.Text == "" ? 0 : Convert.ToDouble(lblCreditQty.Text);
                    objCreditNoteParticulars.CreditRate = lblCreditRate.Text == "" ? 0 : Convert.ToDouble(lblCreditRate.Text);
                    objCreditNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);

                    CreditNoteParticularsList.Add(objCreditNoteParticulars);
                }
            }

            grdAccessoryCreditNot.DataSource = CreditNoteParticularsList;
            grdAccessoryCreditNot.DataBind();

            CalculateGrandTotal();
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);
        }

        protected void grdAccessoryCreditNot_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdAccessoryCreditNot.EditIndex = e.NewEditIndex;

            List<AccessoryCreditNoteParticulars> CreditNoteParticularsList = new List<AccessoryCreditNoteParticulars>();
            for (int AccNo = 0; AccNo < grdAccessoryCreditNot.Rows.Count; AccNo++)
            {
                AccessoryCreditNoteParticulars objCreditNoteParticulars = new AccessoryCreditNoteParticulars();

                HiddenField hdnParticularId = (HiddenField)grdAccessoryCreditNot.Rows[AccNo].FindControl("hdnParticularId");
                Label lblCreditParticur = (Label)grdAccessoryCreditNot.Rows[AccNo].FindControl("lblCreditParticur");
                Label lblCreditQty = (Label)grdAccessoryCreditNot.Rows[AccNo].FindControl("lblCreditQty");
                Label lblCreditRate = (Label)grdAccessoryCreditNot.Rows[AccNo].FindControl("lblCreditRate");
                HiddenField hdnAmount = (HiddenField)grdAccessoryCreditNot.Rows[AccNo].FindControl("hdnAmount");

                objCreditNoteParticulars.CreditNoteParticularId = hdnParticularId.Value == "" ? 0 : Convert.ToInt32(hdnParticularId.Value);
                objCreditNoteParticulars.ParticularName = lblCreditParticur.Text;
                objCreditNoteParticulars.CreditQuantity = lblCreditQty.Text == "" ? 0 : Convert.ToDouble(lblCreditQty.Text);
                objCreditNoteParticulars.CreditRate = lblCreditRate.Text == "" ? 0 : Convert.ToDouble(lblCreditRate.Text);
                objCreditNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);

                CreditNoteParticularsList.Add(objCreditNoteParticulars);
            }

            grdAccessoryCreditNot.DataSource = CreditNoteParticularsList;
            grdAccessoryCreditNot.DataBind();

            CalculateGrandTotal();
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);
        }

        protected void grdAccessoryCreditNot_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdAccessoryCreditNot.EditIndex = -1;
            List<AccessoryCreditNoteParticulars> CreditNoteParticularsList = new List<AccessoryCreditNoteParticulars>();
            for (int AccNo = 0; AccNo < grdAccessoryCreditNot.Rows.Count; AccNo++)
            {
                AccessoryCreditNoteParticulars objCreditNoteParticulars = new AccessoryCreditNoteParticulars();

                HiddenField hdnParticularId = (HiddenField)grdAccessoryCreditNot.Rows[AccNo].FindControl("hdnParticularId");
                Label lblCreditParticur = (Label)grdAccessoryCreditNot.Rows[AccNo].FindControl("lblCreditParticur");
                Label lblCreditQty = (Label)grdAccessoryCreditNot.Rows[AccNo].FindControl("lblCreditQty");
                Label lblCreditRate = (Label)grdAccessoryCreditNot.Rows[AccNo].FindControl("lblCreditRate");
                HiddenField hdnAmount = (HiddenField)grdAccessoryCreditNot.Rows[AccNo].FindControl("hdnAmount");

                if (hdnParticularId == null)
                {
                    HiddenField hdnParticularIdEdit = (HiddenField)grdAccessoryCreditNot.Rows[AccNo].FindControl("hdnParticularIdEdit");
                    TextBox txtCreditParticur = (TextBox)grdAccessoryCreditNot.Rows[AccNo].FindControl("txtCreditParticur");
                    TextBox txtCreditQty = (TextBox)grdAccessoryCreditNot.Rows[AccNo].FindControl("txtCreditQty");
                    TextBox txtCreditRate = (TextBox)grdAccessoryCreditNot.Rows[AccNo].FindControl("txtCreditRate");
                    if ((txtCreditParticur.Text == "") || (txtCreditQty.Text == "") || (txtCreditRate.Text == ""))
                    {
                        ShowAlert("Field can not be empty!");
                        return;
                    }

                    objCreditNoteParticulars.CreditNoteParticularId = hdnParticularIdEdit.Value == "" ? 0 : Convert.ToInt32(hdnParticularIdEdit.Value);
                    objCreditNoteParticulars.ParticularName = txtCreditParticur.Text;
                    objCreditNoteParticulars.CreditQuantity = txtCreditQty.Text == "" ? 0 : Convert.ToDouble(txtCreditQty.Text);
                    objCreditNoteParticulars.CreditRate = txtCreditRate.Text == "" ? 0 : Convert.ToDouble(txtCreditRate.Text);
                    objCreditNoteParticulars.Amount = (objCreditNoteParticulars.CreditQuantity * objCreditNoteParticulars.CreditRate);

                    CreditNoteParticularsList.Add(objCreditNoteParticulars);
                }
                else
                {
                    objCreditNoteParticulars.CreditNoteParticularId = hdnParticularId.Value == "" ? 0 : Convert.ToInt32(hdnParticularId.Value);
                    objCreditNoteParticulars.ParticularName = lblCreditParticur.Text;
                    objCreditNoteParticulars.CreditQuantity = lblCreditQty.Text == "" ? 0 : Convert.ToDouble(lblCreditQty.Text);
                    objCreditNoteParticulars.CreditRate = lblCreditRate.Text == "" ? 0 : Convert.ToDouble(lblCreditRate.Text);
                    objCreditNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);

                    CreditNoteParticularsList.Add(objCreditNoteParticulars);
                }

            }

            grdAccessoryCreditNot.DataSource = CreditNoteParticularsList;
            grdAccessoryCreditNot.DataBind();
            CalculateGrandTotal();
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);
        }

        protected void grdAccessoryCreditNot_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdAccessoryCreditNot.Rows[e.RowIndex];
            HiddenField hdnParticularIdEdit = (HiddenField)row.FindControl("hdnParticularIdEdit");
            TextBox txtCreditParticur = (TextBox)row.FindControl("txtCreditParticur");
            TextBox txtCreditQty = (TextBox)row.FindControl("txtCreditQty");
            TextBox txtCreditRate = (TextBox)row.FindControl("txtCreditRate");
            if ((txtCreditParticur.Text == "") || (txtCreditQty.Text == "") || (txtCreditRate.Text == ""))
            {
                ShowAlert("Field can not be empty!");
                return;
            }

            List<AccessoryCreditNoteParticulars> CreditNoteParticularsList = new List<AccessoryCreditNoteParticulars>();
            for (int AccNo = 0; AccNo < grdAccessoryCreditNot.Rows.Count; AccNo++)
            {
                AccessoryCreditNoteParticulars objCreditNoteParticulars = new AccessoryCreditNoteParticulars();

                HiddenField hdnParticularId = (HiddenField)grdAccessoryCreditNot.Rows[AccNo].FindControl("hdnParticularId");
                Label lblCreditParticur = (Label)grdAccessoryCreditNot.Rows[AccNo].FindControl("lblCreditParticur");
                Label lblCreditQty = (Label)grdAccessoryCreditNot.Rows[AccNo].FindControl("lblCreditQty");
                Label lblCreditRate = (Label)grdAccessoryCreditNot.Rows[AccNo].FindControl("lblCreditRate");
                HiddenField hdnAmount = (HiddenField)grdAccessoryCreditNot.Rows[AccNo].FindControl("hdnAmount");

                if (hdnParticularId == null)
                {
                    objCreditNoteParticulars.CreditNoteParticularId = hdnParticularIdEdit.Value == "" ? 0 : Convert.ToInt32(hdnParticularIdEdit.Value);
                    objCreditNoteParticulars.ParticularName = txtCreditParticur.Text;
                    objCreditNoteParticulars.CreditQuantity = txtCreditQty.Text == "" ? 0 : Convert.ToDouble(txtCreditQty.Text);
                    objCreditNoteParticulars.CreditRate = txtCreditRate.Text == "" ? 0 : Convert.ToDouble(txtCreditRate.Text);
                    objCreditNoteParticulars.Amount = (objCreditNoteParticulars.CreditQuantity * objCreditNoteParticulars.CreditRate);

                    CreditNoteParticularsList.Add(objCreditNoteParticulars);
                }
                else
                {
                    objCreditNoteParticulars.CreditNoteParticularId = hdnParticularId.Value == "" ? 0 : Convert.ToInt32(hdnParticularId.Value);
                    objCreditNoteParticulars.ParticularName = lblCreditParticur.Text;
                    objCreditNoteParticulars.CreditQuantity = lblCreditQty.Text == "" ? 0 : Convert.ToDouble(lblCreditQty.Text);
                    objCreditNoteParticulars.CreditRate = lblCreditRate.Text == "" ? 0 : Convert.ToDouble(lblCreditRate.Text);
                    objCreditNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);

                    CreditNoteParticularsList.Add(objCreditNoteParticulars);
                }
            }

            grdAccessoryCreditNot.EditIndex = -1;
            grdAccessoryCreditNot.DataSource = CreditNoteParticularsList;
            grdAccessoryCreditNot.DataBind();

            CalculateGrandTotal();
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);

        }

        protected void grdAccessoryCreditNot_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddEmpty")
            {
                Table tblgvDetail = (Table)grdAccessoryCreditNot.Controls[0];
                GridViewRow rows = (GridViewRow)tblgvDetail.Controls[0];

                TextBox txtCreditParticular_Empty = (TextBox)rows.FindControl("txtCreditParticular_Empty");
                TextBox txtCreditQty_Empty = (TextBox)rows.FindControl("txtCreditQty_Empty");
                TextBox txtCreditRate_Empty = (TextBox)rows.FindControl("txtCreditRate_Empty");
                HiddenField hdnAmount_Empty = (HiddenField)rows.FindControl("hdnAmount_Empty");

                List<AccessoryCreditNoteParticulars> CreditNoteParticularsList = new List<AccessoryCreditNoteParticulars>();
                AccessoryCreditNoteParticulars objCreditNoteParticulars = new AccessoryCreditNoteParticulars();
                objCreditNoteParticulars.ParticularName = txtCreditParticular_Empty.Text;
                objCreditNoteParticulars.CreditQuantity = txtCreditQty_Empty.Text == "" ? 0 : Convert.ToDouble(txtCreditQty_Empty.Text);
                objCreditNoteParticulars.CreditRate = txtCreditRate_Empty.Text == "" ? 0 : Convert.ToDouble(txtCreditRate_Empty.Text);
                objCreditNoteParticulars.Amount = hdnAmount_Empty.Value == "" ? 0 : Convert.ToDouble(hdnAmount_Empty.Value);
                objCreditNoteParticulars.CreditNoteParticularId = -1;

                CreditNoteParticularsList.Add(objCreditNoteParticulars);

                grdAccessoryCreditNot.DataSource = CreditNoteParticularsList;
                grdAccessoryCreditNot.DataBind();

                CalculateGrandTotal();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);
            }
            if (e.CommandName == "Insert")
            {
                int MaxId = 0;
                List<AccessoryCreditNoteParticulars> CreditNoteParticularsList = new List<AccessoryCreditNoteParticulars>();
                for (int AccNo = 0; AccNo < grdAccessoryCreditNot.Rows.Count; AccNo++)
                {
                    AccessoryCreditNoteParticulars objCreditNoteParticulars = new AccessoryCreditNoteParticulars();

                    HiddenField hdnParticularId = (HiddenField)grdAccessoryCreditNot.Rows[AccNo].FindControl("hdnParticularId");
                    Label lblCreditParticur = (Label)grdAccessoryCreditNot.Rows[AccNo].FindControl("lblCreditParticur");
                    Label lblCreditQty = (Label)grdAccessoryCreditNot.Rows[AccNo].FindControl("lblCreditQty");
                    Label lblCreditRate = (Label)grdAccessoryCreditNot.Rows[AccNo].FindControl("lblCreditRate");
                    HiddenField hdnAmount = (HiddenField)grdAccessoryCreditNot.Rows[AccNo].FindControl("hdnAmount");

                    objCreditNoteParticulars.CreditNoteParticularId = hdnParticularId.Value == "" ? 0 : Convert.ToInt32(hdnParticularId.Value);
                    objCreditNoteParticulars.ParticularName = lblCreditParticur.Text;
                    objCreditNoteParticulars.CreditQuantity = lblCreditQty.Text == "" ? 0 : Convert.ToDouble(lblCreditQty.Text);
                    objCreditNoteParticulars.CreditRate = lblCreditRate.Text == "" ? 0 : Convert.ToDouble(lblCreditRate.Text);
                    objCreditNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);

                    MaxId = MaxId + AccNo + 1;

                    CreditNoteParticularsList.Add(objCreditNoteParticulars);
                }

                AccessoryCreditNoteParticulars objCreditNoteParticularsFoo = new AccessoryCreditNoteParticulars();

                TextBox txtCreditParticur_Footer = grdAccessoryCreditNot.FooterRow.FindControl("txtCreditParticur_Footer") as TextBox;
                TextBox txtCreditQty_Footer = grdAccessoryCreditNot.FooterRow.FindControl("txtCreditQty_Footer") as TextBox;
                TextBox txtCreditRate_Footer = grdAccessoryCreditNot.FooterRow.FindControl("txtCreditRate_Footer") as TextBox;
                HiddenField hdnAmount_Footer = grdAccessoryCreditNot.FooterRow.FindControl("hdnAmount_Footer") as HiddenField;

                objCreditNoteParticularsFoo.ParticularName = txtCreditParticur_Footer.Text;
                objCreditNoteParticularsFoo.CreditQuantity = txtCreditQty_Footer.Text == "" ? 0 : Convert.ToDouble(txtCreditQty_Footer.Text);
                objCreditNoteParticularsFoo.CreditRate = txtCreditRate_Footer.Text == "" ? 0 : Convert.ToDouble(txtCreditRate_Footer.Text);
                objCreditNoteParticularsFoo.Amount = hdnAmount_Footer.Value == "" ? 0 : Convert.ToDouble(hdnAmount_Footer.Value);
                objCreditNoteParticularsFoo.CreditNoteParticularId = -1;

                CreditNoteParticularsList.Add(objCreditNoteParticularsFoo);

                grdAccessoryCreditNot.DataSource = CreditNoteParticularsList;
                grdAccessoryCreditNot.DataBind();

                CalculateGrandTotal();

                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);

            }
        }

        protected void grdAccessoryCreditNot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowState == DataControlRowState.Edit)
            //{
            //    double CreditQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CreditQuantity"));
            //    double CreditRate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CreditRate"));

            //    Label lblAmountEdit = (Label)e.Row.FindControl("lblAmountEdit");
            //    lblAmountEdit.Text = (CreditQuantity * CreditRate).ToString();

            //    HiddenField hdnAmountEdit = (HiddenField)e.Row.FindControl("hdnAmountEdit");
            //    hdnAmountEdit.Value = (CreditQuantity * CreditRate).ToString();

            //    TotalAmount = TotalAmount + Convert.ToDouble(hdnAmountEdit.Value);
            // }
            //else if (e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Alternate))
            //{
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        double CreditQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CreditQuantity"));
            //        double CreditRate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CreditRate"));

            //            Label lblAmount = (Label)e.Row.FindControl("lblAmount");
            //            lblAmount.Text = (CreditQuantity * CreditRate).ToString();

            //            HiddenField hdnAmount = (HiddenField)e.Row.FindControl("hdnAmount");
            //            hdnAmount.Value = (CreditQuantity * CreditRate).ToString();

            //            TotalAmount = TotalAmount + Convert.ToDouble(hdnAmount.Value);                  

            //    }
            //}

         
            if (IsCreditNoteSigned.Value == "True")
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lkedit = (LinkButton)e.Row.FindControl("lkedit");
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");

                    Image lkEditImage = (Image)e.Row.FindControl("lkEditImage");
                    Image lnkDeleteImage = (Image)e.Row.FindControl("lnkDeleteImage");

                    lkedit.Enabled = false;
                    lnkDelete.Enabled = false;
                    lkEditImage.Enabled = false;
                    lnkDeleteImage.Enabled = false;
                }
                grdAccessoryCreditNot.ShowFooter = false;
            }

            if (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))
            {
                double CreditQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CreditQuantity"));
                double CreditRate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CreditRate"));

                Label lblAmountEdit = (Label)e.Row.FindControl("lblAmountEdit");
                lblAmountEdit.Text = Math.Round((CreditQuantity * CreditRate), 2).ToString();

                HiddenField hdnAmountEdit = (HiddenField)e.Row.FindControl("hdnAmountEdit");
                hdnAmountEdit.Value = (CreditQuantity * CreditRate).ToString();

                TotalAmount = TotalAmount + Convert.ToDouble(hdnAmountEdit.Value);
            }
            else if (e.Row.RowState == DataControlRowState.Edit)
            {
                double CreditQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CreditQuantity"));
                double CreditRate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CreditRate"));

                Label lblAmountEdit = (Label)e.Row.FindControl("lblAmountEdit");
                lblAmountEdit.Text = Math.Round((CreditQuantity * CreditRate), 2).ToString();

                HiddenField hdnAmountEdit = (HiddenField)e.Row.FindControl("hdnAmountEdit");
                hdnAmountEdit.Value = (CreditQuantity * CreditRate).ToString();

                TotalAmount = TotalAmount + Convert.ToDouble(hdnAmountEdit.Value);
            }
            else if (e.Row.RowState != (DataControlRowState.Edit | DataControlRowState.Alternate))
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    double CreditQuantity = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CreditQuantity"));
                    double CreditRate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CreditRate"));

                    Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                    lblAmount.Text = Math.Round((CreditQuantity * CreditRate), 2).ToString();

                    HiddenField hdnAmount = (HiddenField)e.Row.FindControl("hdnAmount");
                    hdnAmount.Value = (CreditQuantity * CreditRate).ToString();

                    TotalAmount = TotalAmount + Convert.ToDouble(hdnAmount.Value);
                }
            }

            
        }

     
        private void CalculateGrandTotal()
        {
            double IGSTAmount = 0, CGSTAmount = 0, SGSTAmount = 0;
            if (txtIGST.Text != "")
            {
                IGSTAmount = Math.Round((TotalAmount * Convert.ToDouble(txtIGST.Text)) / 100, 2);
                hdnIGSTAmount.Value = IGSTAmount.ToString();
                if (IGSTAmount > 0)
                    lblIGSTAmount.Text = IGSTAmount.ToString();

            }
            if (lblIGSTAmount.Text != "")
            {
                lblIgstCurrency.Attributes.Add("class", "indianCurr");
            }

            if (txtCGST.Text != "")
            {
                CGSTAmount = Math.Round((TotalAmount * Convert.ToDouble(txtCGST.Text)) / 100, 2);
                hdnCGSTAmount.Value = CGSTAmount.ToString();
                if (CGSTAmount > 0)
                    lblCGSTAmount.Text = CGSTAmount.ToString();

            }
            if (lblCGSTAmount.Text != "")
            {
                lblCgstCurrency.Attributes.Add("class", "indianCurr");
            }

            if (txtSGST.Text != "")
            {
                SGSTAmount = Math.Round((TotalAmount * Convert.ToDouble(txtSGST.Text)) / 100, 2);
                hdnSGSTAmount.Value = SGSTAmount.ToString();
                if (SGSTAmount > 0)
                    lblSGSTAmount.Text = SGSTAmount.ToString();

            }
            if (lblSGSTAmount.Text != "")
            {
                lblSgstCurrency.Attributes.Add("class", "indianCurr");
            }

            if (TotalAmount > 0)
            {
                hdnTotalAmount.Value = TotalAmount.ToString();
                var GrandTotalAmount = Math.Round(TotalAmount + IGSTAmount + CGSTAmount + SGSTAmount, 2);
                lblGrandTotalAmount.Text = GrandTotalAmount.ToString();
                hdnGrandTotalAmount.Value = GrandTotalAmount.ToString();

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "convertNumberToWords(" + GrandTotalAmount + ");", true);  //new line
            }
            if (lblGrandTotalAmount.Text != "")
            {
                lblGranTotalCurrency.Attributes.Add("class", "indianCurr");
            }
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
            double TotalAmount = hdnGrandTotalAmount.Value == "" ? 0 : Convert.ToDouble(hdnGrandTotalAmount.Value);

            if (hdnIsChecked.Value == "0")
            {
                if (TotalAmount > 0)
                {
                    AccessoryCreditNoteCls objAccessoryCreditNote = new AccessoryCreditNoteCls();
                    objAccessoryCreditNote.SupplierPoId = SupplierPoId;
                    objAccessoryCreditNote.CreditNoteId = hdnCreditnotid.Value == "" ? -1 : Convert.ToInt32(hdnCreditnotid.Value);
                    objAccessoryCreditNote.CreditNoteNumber = lblCreditNo.Text;
                    objAccessoryCreditNote.CreditNoteDate = txtDate.Text != "" ? DateTime.ParseExact(txtDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;

                    if (ddlType.SelectedValue == "DEBIT")
                    {
                        objAccessoryCreditNote.DebitNoteId = Convert.ToInt32(ddlBillNo.SelectedValue);
                        objAccessoryCreditNote.PartyBillId = 0;
                    }
                    else if (ddlType.SelectedValue == "BILL")
                    {
                        objAccessoryCreditNote.PartyBillId = Convert.ToInt32(ddlBillNo.SelectedValue);
                        objAccessoryCreditNote.DebitNoteId = 0;
                    }

                    objAccessoryCreditNote.IGST = txtIGST.Text == "" ? 0 : Convert.ToDouble(txtIGST.Text);
                    objAccessoryCreditNote.CGST = txtCGST.Text == "" ? 0 : Convert.ToDouble(txtCGST.Text);
                    objAccessoryCreditNote.SGST = txtSGST.Text == "" ? 0 : Convert.ToDouble(txtSGST.Text);
                    objAccessoryCreditNote.TotalAmount = hdnGrandTotalAmount.Value == "" ? 0 : Convert.ToDouble(hdnGrandTotalAmount.Value);

                    List<AccessoryCreditNoteParticulars> objCreditNoteParticularsList = new List<AccessoryCreditNoteParticulars>();

                    if (grdAccessoryCreditNot.Rows.Count == 0)
                    {
                        Control control = null;
                        control = grdAccessoryCreditNot.Controls[0].Controls[0];
                        if ((TextBox)control.FindControl("txtCreditParticular_Empty") != null)
                        {
                            TextBox txtCreditParticular_Empty = (TextBox)control.FindControl("txtCreditParticular_Empty");
                            TextBox txtCreditQty_Empty = (TextBox)control.FindControl("txtCreditQty_Empty");
                            TextBox txtCreditRate_Empty = (TextBox)control.FindControl("txtCreditRate_Empty");

                            AccessoryCreditNoteParticulars objCreditNoteParticulars = new AccessoryCreditNoteParticulars();

                            objCreditNoteParticulars.ParticularName = txtCreditParticular_Empty.Text;
                            objCreditNoteParticulars.CreditQuantity = txtCreditQty_Empty.Text == "" ? 0 : Convert.ToDouble(txtCreditQty_Empty.Text);
                            objCreditNoteParticulars.CreditRate = txtCreditRate_Empty.Text == "" ? 0 : Convert.ToDouble(txtCreditRate_Empty.Text);
                            objCreditNoteParticulars.CreditNoteParticularId = -1;

                            objCreditNoteParticularsList.Add(objCreditNoteParticulars);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < grdAccessoryCreditNot.Rows.Count; i++)
                        {
                            if (grdAccessoryCreditNot.Rows[i].RowState == DataControlRowState.Edit)
                            {
                                ShowAlert("Please remove editable mode!");
                                return;
                            }
                            Label lblCreditParticur = (Label)grdAccessoryCreditNot.Rows[i].FindControl("lblCreditParticur");
                            Label lblCreditQty = (Label)grdAccessoryCreditNot.Rows[i].FindControl("lblCreditQty");
                            Label lblCreditRate = (Label)grdAccessoryCreditNot.Rows[i].FindControl("lblCreditRate");
                            HiddenField hdnParticularId = (HiddenField)grdAccessoryCreditNot.Rows[i].FindControl("hdnParticularId");

                            AccessoryCreditNoteParticulars objCreditNoteParticulars = new AccessoryCreditNoteParticulars();

                            objCreditNoteParticulars.ParticularName = lblCreditParticur.Text;
                            objCreditNoteParticulars.CreditQuantity = lblCreditQty.Text == "" ? 0 : Convert.ToDouble(lblCreditQty.Text);
                            objCreditNoteParticulars.CreditRate = lblCreditRate.Text == "" ? 0 : Convert.ToDouble(lblCreditRate.Text);
                            objCreditNoteParticulars.CreditNoteParticularId = hdnParticularId.Value == "" ? -1 : Convert.ToInt32(hdnParticularId.Value);

                            objCreditNoteParticularsList.Add(objCreditNoteParticulars);
                        }

                        TextBox txtCreditParticur_Footer = (TextBox)grdAccessoryCreditNot.FooterRow.FindControl("txtCreditParticur_Footer");
                        TextBox txtCreditQty_Footer = (TextBox)grdAccessoryCreditNot.FooterRow.FindControl("txtCreditQty_Footer");
                        TextBox txtCreditRate_Footer = (TextBox)grdAccessoryCreditNot.FooterRow.FindControl("txtCreditRate_Footer");

                        if ((txtCreditParticur_Footer.Text != "") && (txtCreditQty_Footer.Text != "") && (txtCreditRate_Footer.Text != ""))
                        {
                            if ((txtCreditQty_Footer.Text != "0") && (txtCreditRate_Footer.Text != "0"))
                            {
                                AccessoryCreditNoteParticulars objCreditNoteParticulars = new AccessoryCreditNoteParticulars();

                                objCreditNoteParticulars.ParticularName = txtCreditParticur_Footer.Text;
                                objCreditNoteParticulars.CreditQuantity = txtCreditQty_Footer.Text == "" ? 0 : Convert.ToDouble(txtCreditQty_Footer.Text);
                                objCreditNoteParticulars.CreditRate = txtCreditRate_Footer.Text == "" ? 0 : Convert.ToDouble(txtCreditRate_Footer.Text);
                                objCreditNoteParticulars.CreditNoteParticularId = -1;

                                objCreditNoteParticularsList.Add(objCreditNoteParticulars);
                            }
                        }
                    }

                    if (chkAuthorised.Checked)
                        objAccessoryCreditNote.IsCreditNoteSigned = true;
                    else
                        objAccessoryCreditNote.IsCreditNoteSigned = false;

                    objAccessoryCreditNote.AccessoryCreditNoteParticularsList = objCreditNoteParticularsList;

                    int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                    int iSave = objAccessoryWorking.Save_Accessory_CreditNote(objAccessoryCreditNote, UserId);

                    if (iSave > 0)
                    {
                        //   ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
                        if ((objAccessoryCreditNote.IsCreditNoteSigned == true) && (rbtnYes.Checked))
                        {
                            RenderHtml();
                            string thisPath = "CreditNote_" + CreditNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf";
                            string url = host + "/Uploads/Print/" + thisPath;
                            string EmailContent = HttpContent(url);
                            SendDebitNoteEmail("test", "kumar", EmailContent);
                        }

                        //ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "jQuery.facebox('Some error occured);", true);
                        return;
                    }
                }
            }

            if (hdnIsChecked.Value == "1" && rbtnYes.Checked)
            {
                RenderHtml();
                string thisPath = "CreditNote_" + CreditNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf";
                string url = host + "/Uploads/Print/" + thisPath;
                string EmailContent = HttpContent(url);
                SendDebitNoteEmail("test", "kumar", EmailContent);
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

            Request = WebRequest.Create(host + "/AccessoryPdfFile/AccessoryCreditNotePdf.aspx?SupplierPoId=" + SupplierPoId + "&CreditNoteId=" + CreditNoteId + "&RupeesInWord=" + hdnRupees.Value);
            Request.Timeout = 99999999;
            Response = Request.GetResponse();
            reader = new StreamReader(Response.GetResponseStream());
            strHTML = reader.ReadToEnd();

            generatePDF(strHTML);
        }

        public void generatePDF(string HTMLCode)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Print/" + "CreditNote_" + CreditNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf");

            HTMLCode = getImage(HTMLCode);
            getvartypeHTML(HTMLCode, strFileName);

        }

        public void getvartypeHTML(string HTMLCode, string PolicyFile)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Print/" + "CreditNote_" + CreditNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf");

            using (IPechkin pechkin = Factory.Create(new GlobalConfig()))
            {

                var pdf = pechkin.Convert(new ObjectConfig()
                                        .SetLoadImages(true)
                                        .SetZoomFactor(1.5)
                                        .SetPrintBackground(true)
                                        .SetScreenMediaType(true)
                                        .SetCreateExternalLinks(true), (HTMLCode));
                using (FileStream file = File.Create(strFileName))
                {
                    file.Write(pdf, 0, pdf.Length);
                }
            }
        }

        public string HttpContent(string url)
        {
            string result = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Timeout = 80000000;
                //req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E)";
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";

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

        public Boolean SendDebitNoteEmail(string ClientName, string UserPassword, string ToEmail)
        {
            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                List<string> to = new List<string>();
                string email = "itsupport@boutique.in";
                to.Add(email);

                List<Attachment> attachment = new List<Attachment>();

                if (File.Exists(Constants.PRINT_FOLDER_PATH + "CreditNote_" + CreditNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf"))
                {
                    PoPath = Path.Combine(Constants.PRINT_FOLDER_PATH, "CreditNote_" + CreditNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf");

                    attachment.Add(new Attachment(PoPath));
                }

                this.SendEmail(fromName, to, null, null, ToEmail, attachment, false, false);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean SendEmail(string FromEmail, List<String> To, List<String> CC, List<String> BCC, String Content, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            //mailMessage.Subject = MailType + " " + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + " for PO (" + hdnPO_Number.Value + ")";
            mailMessage.Subject = MailType + "(" + hdnDebitNoteNumber.Value + ")";
            mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a <b>Credit note</B> is raised against <span style='color:gray'>" + "Debit No - </span></span><span style='color:#2f5597'>" + hdnDebitNoteNumber.Value + "</span> for  <span style='color:gray'>" + "Purchase Order - </span></span><span style='color:#2f5597'>" + hdnPO_Number.Value + "</span>. Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> Disclaimer: This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
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
                //mailMessage.CC.Add("ravi@boutique.in");
                mailMessage.CC.Add("itsupport@boutique.in");

            }
            else
            {
                foreach (String to in To)
                {
                    mailMessage.To.Add(to);
                }

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
                System.Diagnostics.Trace.WriteLine("Email Having Subject of --" + Content.ToString() + " is send successfully on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                hdnMailSentStatus.Value = "1";
                ShowAlert("Mail Sent successfully");
                return true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Some error has been occur in Email having subject of ---" + Content.ToString() + " On" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
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
    }
}