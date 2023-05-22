using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;

namespace iKandi.Web.AccessoryPdfFile
{
    public partial class AccessoryCreditNotePdf : System.Web.UI.Page
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
        public string RupeesInWord
        {
            get;
            set;
        }
        
        private double TotalAmount = 0;
        string host = "";
        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();

        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;
            GetQueryString();
            if (!IsPostBack)
            {
                BindBillDropdownList();
                BindData(0);
                //CalculateGrandTotal();

                DataTable dt = objAccessoryWorking.Getbipladdress("BIPLAddress3");
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
                //SupplierPoId = 0;
                SupplierPoId = 162;
            }
            if (Request.QueryString["CreditNoteId"] != null)
            {
                CreditNoteId = Convert.ToInt32(Request.QueryString["CreditNoteId"]);
            }
            else
            {
                //CreditNoteId = 0;
                CreditNoteId = 3;
            }

            if (Request.QueryString["RupeesInWord"] != null)
            {
                RupeesInWord = Request.QueryString["RupeesInWord"];
            }
            else
            {                
                RupeesInWord = "";
            }
        }

        private void BindData(int IsPageRefresh)
        {
            boutiqueImg.ImageUrl = host + "/images/200x50 bipllog.png";

            AccessoryCreditNoteCls objAccessoryCreditNote = objAccessoryWorking.Get_AccessoryCreditNote(SupplierPoId, CreditNoteId);
            hdnCreditnotid.Value = objAccessoryCreditNote.CreditNoteId.ToString();
            lblCreditNo.Text = objAccessoryCreditNote.CreditNoteNumber;
            lblSupllierName.Text = objAccessoryCreditNote.SupplierName;

            List<AccessoryCreditNoteParticulars> objCreditNoteParticulars = objAccessoryCreditNote.AccessoryCreditNoteParticularsList;
            grdAccessoryCreditNot.DataSource = objCreditNoteParticulars;
            grdAccessoryCreditNot.DataBind();

            hdnGST_No.Value = objAccessoryCreditNote.GSTNo.ToString();//new line
            // rajeevs 10022023            
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
            // rajeevs 10022023	

            string GstNO = hdnGST_No.Value.Substring(0, 2);
            if (GstNO == "09")
            {
                clsIGST.Attributes.Add("style", "display:none");
                clsCGST.Attributes.Add("style", "display:''");
                clsSGST.Attributes.Add("style", "display:''");
            }
            else
            {
                clsCGST.Attributes.Add("style", "display:none");
                clsSGST.Attributes.Add("style", "display:none");
                clsIGST.Attributes.Add("style", "display:''");
            }

            txtIGST.Text = objAccessoryCreditNote.IGST == 0 ? "" : objAccessoryCreditNote.IGST.ToString();
            txtCGST.Text = objAccessoryCreditNote.CGST == 0 ? "" : objAccessoryCreditNote.CGST.ToString();
            txtSGST.Text = objAccessoryCreditNote.SGST == 0 ? "" : objAccessoryCreditNote.SGST.ToString();

            if (CreditNoteId > 0)
            {
                txtDate.Text = objAccessoryCreditNote.CreditNoteDate.ToString("dd MMM yy (ddd)");
               
            }
            if (objAccessoryCreditNote.IsCreditNoteSigned)
            {
                divChkAuthorized.Visible = false;
                chkAuthorised.Checked = true;
                divSigAuthorized.Visible = true;
                lblAuthorizedName.Text = objAccessoryCreditNote.CreditNoteSignedBy;
                imgAuthorized.ImageUrl = objAccessoryCreditNote.AuthSignature != string.Empty ? host + "/Uploads/Photo/" + objAccessoryCreditNote.AuthSignature : host + "/Uploads/Photo/NotSign.jpg";
                lblAuthorizedOnDate.Text = Convert.ToDateTime(objAccessoryCreditNote.CreditNoteSignDate).ToString("dd MMM yy (ddd)");
            }
            CalculateGrandTotal();              

        }

        private void BindBillDropdownList()
        {
            string type = "";
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
            if (hdnGST_No.Value.Substring(0, 2) == "09")
            {
                IGSTAmount = 0;
            }
            else
            {
                CGSTAmount = 0; 
                SGSTAmount = 0;
            }
            if (TotalAmount > 0)
            {
                hdnTotalAmount.Value = TotalAmount.ToString();
                var GrandTotalAmount = Math.Round(TotalAmount + IGSTAmount + CGSTAmount + SGSTAmount, 2);
                lblGrandTotalAmount.Text = GrandTotalAmount.ToString();
                hdnGrandTotalAmount.Value = GrandTotalAmount.ToString();                
            }
            if (lblGrandTotalAmount.Text != "")
            {
                lblGranTotalCurrency.Attributes.Add("class", "indianCurr");
            }
            lblRupees.Text = RupeesInWord;
        }

        protected void grdAccessoryCreditNot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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

       
    }
}