using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using System.Data;
using iKandi.Common.Entities;

namespace iKandi.Web.FabricPdfFile
{
    public partial class FabricCreditNotePdf : System.Web.UI.Page
    {
        public int SupplierPoId
        {
            get;
            set;
        }
        public static int DebitNoteId
        {
            get;
            set;
        }
        public static DateTime CheckedDate
        {
            get;
            set;
        }
        public int IsSignatureDone
        {
            get;
            set;
        }
        private double TotalAmount = 0;

        public string GstNumber
        {
            get;
            set;
        }
        public string RupeesInWord
        {
            get;
            set;
        }

        string host = "";
        FabricController objFabricWorking = new FabricController();

        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;
            GetQueryString();
            DataTable dtgst = objFabricWorking.GetGSTByPoNumber("GST", SupplierPoId, DebitNoteId);
            txtCGST.Text = Convert.ToDouble(dtgst.Rows[0]["CGST"].ToString()).ToString();
            txtIGST.Text = Convert.ToDouble(dtgst.Rows[0]["IGST"].ToString()).ToString();
            txtSGST.Text = Convert.ToDouble(dtgst.Rows[0]["SGST"].ToString()).ToString();
            string prefixcode = Convert.ToDecimal(dtgst.Rows[0]["Prefixcode"].ToString()).ToString();
            GstNumber = dtgst.Rows[0]["GSTNumber"].ToString();            
            if (GstNumber != "0")
            {
                if (GstNumber.ToString().Substring(0, 2) == "09")
                {
                    tdCGST.Visible = true;
                    tdSGST.Visible = true;
                }
                else
                {
                    tdIIGST.Visible = true;
                }
            }
           
            if (!IsPostBack)
            {
                Session["DebitNoteParticularsList"] = null;
                BindData(0);
                CalculateGrandTotal();

                DataTable dt = objFabricWorking.Getbipladdress("BIPLAddress4");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();
            }
            if (txtCGST.Text != "")
            {
                if (Convert.ToDecimal(txtCGST.Text) <= 0)
                {
                    txtCGST.Text = "";
                }

            }
            if (txtSGST.Text != "")
            {
                if (Convert.ToDecimal(txtSGST.Text) <= 0)
                {
                    txtSGST.Text = "";
                }

            }
            if (txtIGST.Text != "")
            {
                if (Convert.ToDecimal(txtIGST.Text) <= 0)
                {
                    txtIGST.Text = "";
                }

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
                SupplierPoId = 154;
            }
            if (Request.QueryString["DebitNoteId"] != null)
            {
                DebitNoteId = Convert.ToInt32(Request.QueryString["DebitNoteId"]);
            }
            else
            {
                //DebitNoteId = 0;
                DebitNoteId = 6;
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

        private void BindBillDropdownList(int PartyBillId)
        {
            string str = "";
            if (ddltypes.SelectedValue == "0")
            {
                str = "DEBITNOT";
            }
            else
            {
                str = "PARTYBILL";
            }
            List<Fabric_Srv_Bill> Accessory_Srv_BillList = objFabricWorking.Get_Credit_Srv_Bill_DropDownList(SupplierPoId, DebitNoteId, str);
            if (Accessory_Srv_BillList.Count > 0)
            {
                ddlBillNo.DataSource = Accessory_Srv_BillList;
                ddlBillNo.DataTextField = "BillDetails";
                ddlBillNo.DataValueField = "PartyBillId";
                ddlBillNo.DataBind();

                if (PartyBillId > 0)
                {

                }
                if (ddltypes.SelectedValue == "0")
                {
                    str = "DEBITNOT";
                    if (hdndbptids.Value != "-1")
                        ddlBillNo.SelectedValue = hdndbptids.Value;
                }
                else
                {
                    str = "PARTYBILL";
                    if (PartyBillId > 0)
                    {
                        ddlBillNo.SelectedValue = PartyBillId.ToString();
                    }
                }
                string BillDetails = ddlBillNo.SelectedItem.Text;
                string[] sChar = BillDetails.Split('(');
                string[] sChar1 = sChar[1].Split(')');
                string sAmount = sChar1[0].ToString();
                hdnBillAmount.Value = sAmount.Trim();
            }
            else
            {
                if (Convert.ToInt32(hdndbptids.Value) > 0 || PartyBillId > 0)
                {
                    DataSet st = objFabricWorking.Getbills(SupplierPoId);
                    DataTable dt = st.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        ddlBillNo.DataSource = dt;
                        ddlBillNo.DataTextField = "BillDetails";
                        ddlBillNo.DataValueField = "PartyBillId";
                        ddlBillNo.DataBind();

                        if (PartyBillId > 0)
                        {

                        }
                        if (ddltypes.SelectedValue == "0")
                        {
                            str = "DEBITNOT";
                            ddlBillNo.SelectedValue = hdndbptids.Value;

                            ListItem match = ddlBillNo.Items.FindByValue(hdndbptids.Value);
                            if (match != null)
                                ddlBillNo.SelectedValue = hdndbptids.Value;
                        }
                        else
                        {
                            if (PartyBillId > 0)
                            {
                                str = "PARTYBILL";

                            }
                            ListItem match = ddlBillNo.Items.FindByValue(PartyBillId.ToString());
                            if (match != null)
                                ddlBillNo.SelectedValue = PartyBillId.ToString();
                        }
                        string BillDetails = ddlBillNo.SelectedItem.Text;
                        string[] sChar = BillDetails.Split('(');
                        string[] sChar1 = sChar[1].Split(')');
                        string sAmount = sChar1[0].ToString();
                        hdnBillAmount.Value = sAmount.Trim();

                    }
                }
                else
                {
                    ddlBillNo.Items.Clear();
                }
            }



        }

        private void BindData(int IsPageRefresh)
        {
            boutiqueImg.ImageUrl = host + "/images/200x50 bipllog.png";

            FabricDebitNoteCls objAccessoryDebitNote = objFabricWorking.Get_FabCreditNote(SupplierPoId, DebitNoteId);
            hdnDebitnotid.Value = objAccessoryDebitNote.DebitNoteId.ToString();
            hdndbptids.Value = objAccessoryDebitNote.Debptid.ToString();
            //txtPonumber.Text = objAccessoryDebitNote.PoNumber;
            lblDebitNo.Text = objAccessoryDebitNote.DebitNoteNumber;
            lblSupllierName.Text = objAccessoryDebitNote.SupplierName;
            //txtIGST.Text = objAccessoryDebitNote.IGST == 0 ? "" : objAccessoryDebitNote.IGST.ToString();//new line
            //txtCGST.Text = objAccessoryDebitNote.CGST == 0 ? "" : objAccessoryDebitNote.CGST.ToString();//new line
            //txtSGST.Text = objAccessoryDebitNote.SGST == 0 ? "" : objAccessoryDebitNote.SGST.ToString();//new line

            List<FabricDebitNoteParticulars> objDebitNoteParticulars = objAccessoryDebitNote.FabricDebitNoteParticularsList;
            grdAccessoryDebitNot.DataSource = objDebitNoteParticulars;
            Session["DebitNoteParticularsList"] = objDebitNoteParticulars;

            grdAccessoryDebitNot.DataBind();

            if (objAccessoryDebitNote.QtyCheckedBy > 0)
            {
                divCheckBox2.Visible = false;
                divSignature2.Visible = true;
                foreach (var user in iKandi.Web.Components.ApplicationHelper.Users)
                {
                    if (objAccessoryDebitNote.QtyCheckedBy == user.UserID)
                    {
                        lblCheckerName.Text = user.FirstName + " " + user.LastName;
                        imgCheckerSig.ImageUrl = user.SignPath != string.Empty ? host + "/Uploads/Photo/" + user.SignPath : host + "/Uploads/Photo/NotSign.jpg"; ;
                        lblCheckedDate.Text = objAccessoryDebitNote.QtyCheckedDate.ToString("dd MMM yy (ddd)");
                        chkQtyCheckedBy.Checked = true;
                        CheckedDate = objAccessoryDebitNote.QtyCheckedDate;
                    }
                }
                //grdAccessoryDebitNot.Enabled=false;
                //btnSubmit.Visible = false;
                IsSignatureDone = 1;
            }

            if (DebitNoteId > 0)
            {
                hdnGST_No.Value = objAccessoryDebitNote.GSTNo.ToString();//new line
                txtDate.Text = objAccessoryDebitNote.DebitNoteDate.ToString("dd MMM yy (ddd)");
                txtIGST.Text = objAccessoryDebitNote.IGST <= 0 ? "" : objAccessoryDebitNote.IGST.ToString();
                txtCGST.Text = objAccessoryDebitNote.CGST <= 0 ? "" : objAccessoryDebitNote.CGST.ToString();
                txtSGST.Text = objAccessoryDebitNote.SGST <= 0 ? "" : objAccessoryDebitNote.SGST.ToString();

                if (Convert.ToInt32(hdndbptids.Value) > 0)
                {
                    BindBillDropdownList(Convert.ToInt32(hdndbptids.Value));

                    ddlBillNo.Attributes.Add("disabled", "disabled");
                    ddlBillNo.SelectedValue = "0";
                    ddlBillNo.Enabled = false;
                }
                else if ((objAccessoryDebitNote.PartyBillId > 0))
                {
                    BindBillDropdownList(objAccessoryDebitNote.PartyBillId);

                    ddlBillNo.Attributes.Add("disabled", "disabled");
                    ddlBillNo.SelectedValue = "1";
                    ddlBillNo.Enabled = false;
                }
                if (txtCGST.Text != "")
                {
                    if (Convert.ToDecimal(txtCGST.Text) <= 0)
                    {
                        txtCGST.Text = "";
                    }

                }
                if (txtSGST.Text != "")
                {
                    if (Convert.ToDecimal(txtSGST.Text) <= 0)
                    {
                        txtSGST.Text = "";
                    }

                }
                if (txtIGST.Text != "")
                {
                    if (Convert.ToDecimal(txtIGST.Text) <= 0)
                    {
                        txtIGST.Text = "";
                    }

                }
            }
            else
            {
                txtDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                if (IsPageRefresh == 0)
                {
                    BindBillDropdownList(0);
                }
            }

            //CalculateGrandTotal();

        }

        protected void grdAccessoryDebitNot_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowState == DataControlRowState.Edit)
            {
                double DebitQuantity = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DebitQuantity"));
                double DebitRate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DebitRate"));

                Label lblAmountEdit = (Label)e.Row.FindControl("lblAmountEdit");
                lblAmountEdit.Text = (DebitQuantity * DebitRate).ToString();

                HiddenField hdnAmountEdit = (HiddenField)e.Row.FindControl("hdnAmountEdit");
                hdnAmountEdit.Value = Convert.ToDouble(Math.Round((DebitQuantity * DebitRate), 1, MidpointRounding.AwayFromZero)).ToString();

                //TotalAmount = TotalAmount + Convert.ToDouble(hdnAmountEdit.Value);
                //TotalAmount = Convert.ToDouble(Math.Round(Convert.ToDouble(TotalAmount), 1, MidpointRounding.AwayFromZero));
            }
            //else
            //{
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                double DebitQuantity = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DebitQuantity"));
                double DebitRate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DebitRate"));

                Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                if (lblAmount != null)
                {
                    lblAmount.Text = (DebitQuantity * DebitRate).ToString();

                    HiddenField hdnAmount = (HiddenField)e.Row.FindControl("hdnAmount");
                    hdnAmount.Value = Convert.ToDouble(Math.Round((DebitQuantity * DebitRate), 1, MidpointRounding.AwayFromZero)).ToString();
                    TotalAmount = TotalAmount + Convert.ToDouble(hdnAmount.Value);
                    TotalAmount = Convert.ToDouble(Math.Round(Convert.ToDouble(TotalAmount), 1, MidpointRounding.AwayFromZero));
                }
                else
                {
                    Label lblAmountEdit = (Label)e.Row.FindControl("lblAmountEdit");
                    lblAmountEdit.Text = (DebitQuantity * DebitRate).ToString();

                    HiddenField hdnAmountEdit = (HiddenField)e.Row.FindControl("hdnAmountEdit");
                    hdnAmountEdit.Value = Convert.ToDouble(Math.Round((DebitQuantity * DebitRate), 1, MidpointRounding.AwayFromZero)).ToString();

                    TotalAmount = TotalAmount + Convert.ToDouble(hdnAmountEdit.Value);
                    TotalAmount = Convert.ToDouble(Math.Round(Convert.ToDouble(TotalAmount), 1, MidpointRounding.AwayFromZero));
                }
            }
            //}
        }

        private void CalculateGrandTotal()
        {
            double IGSTAmount = 0, CGSTAmount = 0, SGSTAmount = 0;
            if (txtIGST.Text != "")
            {
                IGSTAmount = Convert.ToDouble(Math.Round((TotalAmount * Convert.ToDouble(txtIGST.Text)) / 100, 1, MidpointRounding.AwayFromZero));
                lblIGSTAmount.Text = IGSTAmount.ToString();
                hdnIGSTAmount.Value = IGSTAmount.ToString();
            }
            //add code by bharat on 19-Sep-19
            if (lblIGSTAmount.Text != "")
            {
                if (lblIGSTAmount.Text != "0")
                {
                    lblIgstACurrency.Attributes.Add("class", "indianCurr");
                }
                else
                {
                    lblIGSTAmount.Text = "";
                }
            }
            //end
            if (txtCGST.Text != "")
            {
                CGSTAmount = Convert.ToDouble(Math.Round((TotalAmount * Convert.ToDouble(txtCGST.Text)) / 100, 1, MidpointRounding.AwayFromZero));
                lblCGSTAmount.Text = CGSTAmount.ToString();
                hdnCGSTAmount.Value = CGSTAmount.ToString();
            }
            //add code by bharat on 19-Sep-19
            if (lblCGSTAmount.Text != "")
            {
                if (lblCGSTAmount.Text != "0")
                {
                    lblCGSTACurrentcy.Attributes.Add("class", "indianCurr");
                }
                else
                {
                    lblCGSTAmount.Text = "";
                }
            }
            //end
            if (txtSGST.Text != "")
            {
                SGSTAmount = Convert.ToDouble(Math.Round((TotalAmount * Convert.ToDouble(txtSGST.Text)) / 100, 1, MidpointRounding.AwayFromZero));
                lblSGSTAmount.Text = SGSTAmount.ToString();
                hdnSGSTAmount.Value = SGSTAmount.ToString();
            }
            //add code by bharat on 19-Sep-19
            if (lblSGSTAmount.Text != "")
            {

                if (Convert.ToString(lblSGSTAmount.Text) != "0")
                {
                    lblSGSTACurrentcy.Attributes.Add("class", "indianCurr");
                }
                else
                {
                    lblSGSTAmount.Text = "";
                }
            }
            //end
            if (TotalAmount > 0)
            {
                hdnTotalAmount.Value = TotalAmount.ToString();
                var GrandTotalAmount = TotalAmount + IGSTAmount + CGSTAmount + SGSTAmount;
                lblGrandTotalAmount.Text = GrandTotalAmount.ToString();
                hdnGrandTotalAmount.Value = GrandTotalAmount.ToString();
            }
            //add code by bharat on 19-Sep-19
            if (lblGrandTotalAmount.Text != "")
            {
                if (lblGrandTotalAmount.Text != "0")
                {
                    lblGranToCurrency.Attributes.Add("class", "indianCurr");
                }
                else
                {
                    lblGrandTotalAmount.Text = "";
                }
                //lblrs.Text = NumWordsWrapper(Convert.ToDouble(lblGrandTotalAmount.Text.Trim()));
                //lblrs.Text = FirstLetterToUpper(lblrs.Text);
            }
            if (txtCGST.Text != "")
            {
                if (Convert.ToDecimal(txtCGST.Text) <= 0)
                {
                    txtCGST.Text = "";
                }

            }
            if (txtSGST.Text != "")
            {
                if (Convert.ToDecimal(txtSGST.Text) <= 0)
                {
                    txtSGST.Text = "";
                }

            }
            if (txtIGST.Text != "")
            {
                if (Convert.ToDecimal(txtIGST.Text) <= 0)
                {
                    txtIGST.Text = "";
                }

            }
            lblrs.Text = RupeesInWord;
        }

    }
}