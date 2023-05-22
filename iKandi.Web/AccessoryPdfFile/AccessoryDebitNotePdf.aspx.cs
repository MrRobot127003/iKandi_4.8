using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using iKandi.Common;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;

namespace iKandi.Web.AccessoryPdfFile
{
    public partial class AccessoryDebitNotePdf : System.Web.UI.Page
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
                BindBillDropdownList(0);
                BindData(0);
                CalculateGrandTotal();
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
                SupplierPoId = 156;
            }
            if (Request.QueryString["DebitNoteId"] != null)
            {
                DebitNoteId = Convert.ToInt32(Request.QueryString["DebitNoteId"]);
            }
            else
            {
                //DebitNoteId = 0;
                DebitNoteId = 28;
            }
            if (Request.QueryString["RupeesInWord"] != null)
            {
                RupeesInWord = Request.QueryString["RupeesInWord"].ToString();
            }
            else
            {
                RupeesInWord = "";
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
                string BillDetails = ddlBillNo.SelectedItem.Text;
                string[] sChar = BillDetails.Split('(');
                string[] sChar1 = sChar[1].Split(')');
                string sAmount = sChar1[0].ToString();
                hdnBillAmount.Value = sAmount.Trim();
            }

        }

        private void BindData(int IsPageRefresh)
        {
            boutiqueImg.ImageUrl = host + "/images/200x50 bipllog.png";

            int PartyBillId = Convert.ToInt32(ddlBillNo.SelectedValue);
            //int PartyBillId = PartyBillNo;
            AccessoryDebitNoteCls objAccessoryDebitNote = objAccessoryWorking.Get_AccessoryDebitNote(SupplierPoId, DebitNoteId, PartyBillId);

            hdnDebitnotid.Value = objAccessoryDebitNote.DebitNoteId.ToString();
            lblDebitNo.Text = objAccessoryDebitNote.DebitNoteNumber;
            lblSupllierName.Text = objAccessoryDebitNote.SupplierName;
            txtReturnChallan.Text = objAccessoryDebitNote.ReturnChallanNumber;
            txtreturndate.Text = objAccessoryDebitNote.ChallanDate == DateTime.MinValue ? "" : objAccessoryDebitNote.ChallanDate.ToString("dd MMM yy (ddd)");
            hdnSRVQty.Value = objAccessoryDebitNote.SRVQuantity.ToString();
            hdnGarmentUnitName.Value = objAccessoryDebitNote.GarmentUnitName;
            //rajeevs
            string HSNCode = objAccessoryDebitNote.HSNCode;
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
            //rajeevs
            hdnGST_No.Value = objAccessoryDebitNote.GSTNo;
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
            txtIGST.Text = objAccessoryDebitNote.IGST == 0 ? "" : objAccessoryDebitNote.IGST.ToString() + " %";//new line
            txtCGST.Text = objAccessoryDebitNote.CGST == 0 ? "" : objAccessoryDebitNote.CGST.ToString() + " %";//new line
            txtSGST.Text = objAccessoryDebitNote.SGST == 0 ? "" : objAccessoryDebitNote.SGST.ToString() + " %";//new line
            lblRupees.Text = RupeesInWord;

            //if (objAccessoryDebitNote.TotalFailQty > 0)
            //    lblFailQty.Text = "<span style='color:gray;'> Fail Qty : </span>" + objAccessoryDebitNote.TotalFailQty.ToString() + " " + objAccessoryDebitNote.GarmentUnitName;

            List<AccessoryDebitNoteParticulars> objDebitNoteParticulars = objAccessoryDebitNote.AccessoryDebitNoteParticularsList;
            grdAccessoryDebitNot.DataSource = objDebitNoteParticulars;
            grdAccessoryDebitNot.DataBind();

            if (DebitNoteId > 0)
            {
                txtDate.Text = objAccessoryDebitNote.DebitNoteDate.ToString("dd MMM yy (ddd)");
                ddlBillNo.SelectedValue = objAccessoryDebitNote.PartyBillId.ToString();
                //ddlBillNo.SelectedItem.Text = PartyBill.ToString();
                // ddlBillNo.Attributes.Add("disabled", "disabled");
            }
            else
            {
                txtDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
            }
            if (objAccessoryDebitNote.IsDebitNoteSigned)
            {
                divChkAuthorized.Visible = false;
                chkAuthorised.Checked = true;
                divSigAuthorized.Visible = true;
                lblAuthorizedName.Text = objAccessoryDebitNote.DebitNoteSignedBy;
                imgAuthorized.ImageUrl = objAccessoryDebitNote.AuthSignature != string.Empty ? host + "/Uploads/Photo/" + objAccessoryDebitNote.AuthSignature : host + "/Uploads/Photo/NotSign.jpg";
                lblAuthorizedOnDate.Text = Convert.ToDateTime(objAccessoryDebitNote.DebitNoteSignDate).ToString("dd MMM yy (ddd)");

                ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "disablePage();", true);

            }
            if (objAccessoryDebitNote.GSTNo == "")
            {
                lblGstMsg.Text = "GST No. not available for this Supplier, hence you can not raise Debit Note!";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "disablePage();", true);

            }
        }

        private void CalculateGrandTotal()
        {
            double IGSTAmount = 0, CGSTAmount = 0, SGSTAmount = 0;
            if (txtIGST.Text != "")
            {
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
                lblGrandTotalAmount.Text = GrandTotalAmount.ToString("N").TrimEnd('0').TrimEnd('.');
                hdnGrandTotalAmount.Value = GrandTotalAmount.ToString();

                double GrandTotalAmountForText = Convert.ToDouble(Math.Round(TotalAmount + IGSTAmount + CGSTAmount + SGSTAmount, 2));
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "convertNumberToWords(" + GrandTotalAmountForText + ");", true);

            }
            if (lblGrandTotalAmount.Text != "")
            {
                lblGranTotalCurrency.Attributes.Add("class", "indianCurr");
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
                lblAmountEdit.Text = Math.Round((DebitQuantity * DebitRate), 2).ToString("N").TrimEnd('0').TrimEnd('.');

                Label lblDebitQty = (Label)e.Row.FindControl("lblDebitQty");
                lblDebitQty.Text = (DebitQuantity).ToString("N").TrimEnd('0').TrimEnd('.');


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
                lblAmountEdit.Text = Math.Round((DebitQuantity * DebitRate), 2).ToString("N").TrimEnd('0').TrimEnd('.');

                Label lblDebitQty = (Label)e.Row.FindControl("lblDebitQty");
                lblDebitQty.Text = (DebitQuantity).ToString("N").TrimEnd('0').TrimEnd('.');

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
                    lblAmount.Text = Math.Round((DebitQuantity * DebitRate), 2).ToString("N").TrimEnd('0').TrimEnd('.');

                    Label lblDebitQty = (Label)e.Row.FindControl("lblDebitQty");
                    lblDebitQty.Text = (DebitQuantity).ToString("N").TrimEnd('0').TrimEnd('.');

                    HiddenField hdnAmount = (HiddenField)e.Row.FindControl("hdnAmount");
                    hdnAmount.Value = (DebitQuantity * DebitRate).ToString();

                    TotalAmount = TotalAmount + Convert.ToDouble(hdnAmount.Value);
                }
            }
        }
    }
}