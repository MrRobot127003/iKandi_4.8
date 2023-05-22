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

namespace iKandi.Web.Internal.Fabric
{
    public partial class FrmCreditNotes : System.Web.UI.Page
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

        string host = "";
        string MailType = "Fabric Credit Note Against Debit Note ";
        string PoPath = string.Empty;
        FabricController objFabricWorking = new FabricController();
        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;
            GetQueryString();
            DataTable dtgst = objFabricWorking.GetGSTByPoNumber("GST", SupplierPoId, DebitNoteId);
            txtCGST.Text = Convert.ToDouble(dtgst.Rows[0]["CGST"].ToString()).ToString();
            txtIGST.Text = Convert.ToDouble(dtgst.Rows[0]["IGST"].ToString()).ToString();
            txtSGST.Text = Convert.ToDouble(dtgst.Rows[0]["SGST"].ToString()).ToString();
            string prefixcode = dtgst.Rows[0]["Prefixcode"].ToString();
            GstNumber = dtgst.Rows[0]["GSTNumber"].ToString();
            if (GstNumber != "0")
            {
                //if (GstNumber.ToString().Substring(1) == "91")
                if (prefixcode == "09")
                {
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

            if (!IsPostBack)
            {
                //txtCGST.Text = iKandi.Web.Components.ApplicationHelper.CGST.ToString();
                //txtSGST.Text = iKandi.Web.Components.ApplicationHelper.SGST.ToString();
                //txtIGST.Text = iKandi.Web.Components.ApplicationHelper.IGST.ToString();


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
        protected void OnCheckChanged(object sender, EventArgs e)
        {
            BindBillDropdownList(0);

        }
        protected void ddltypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBillDropdownList(0);
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

        //private void BindBillDropdownList()
        //{
        //    List<Fabric_Srv_Bill> Accessory_Srv_BillList = objFabricWorking.GetAccessory_Srv_Bill_DropDownList(SupplierPoId, DebitNoteId);
        //    if (Accessory_Srv_BillList.Count > 0)
        //    {
        //        ddlBillNo.DataSource = Accessory_Srv_BillList;
        //        ddlBillNo.DataTextField = "BillDetails";
        //        ddlBillNo.DataValueField = "PartyBillId";
        //        ddlBillNo.DataBind();
        //        if (DebitNoteId > 0)
        //        {
        //            ddlBillNo.Enabled = false;
        //        }
        //        string BillDetails = Accessory_Srv_BillList[0].BillDetails;
        //        string[] sChar = BillDetails.Split('(');
        //        string[] sChar1 = sChar[1].Split(')');
        //        string sAmount = sChar1[0].ToString();
        //        hdnBillAmount.Value = sAmount.Trim();
        //    }
        //}

        private void BindData(int IsPageRefresh)
        {
            FabricDebitNoteCls objAccessoryDebitNote = objFabricWorking.Get_FabCreditNote(SupplierPoId, DebitNoteId);
            hdnDebitnotid.Value = objAccessoryDebitNote.DebitNoteId.ToString();
            hdndbptids.Value = objAccessoryDebitNote.Debptid.ToString();
            //txtPonumber.Text = objAccessoryDebitNote.PoNumber;
            lblDebitNo.Text = objAccessoryDebitNote.DebitNoteNumber;
            lblSupllierName.Text = objAccessoryDebitNote.SupplierName;
            lblgstno.Text = objAccessoryDebitNote.GSTNo;
            lbladdress.Text = objAccessoryDebitNote.Address;
            //txtHSNCode.Text = objAccessoryDebitNote.HSNCode;      

            hdnDebitNoteNumber.Value = objAccessoryDebitNote.DebitNoteNumber.ToString();
            hdnPO_Number.Value = objAccessoryDebitNote.PoNumber;

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
                        hdnIsChecked.Value = "1";
                        lblCheckerName.Text = user.FirstName + " " + user.LastName;
                        imgCheckerSig.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg"; ;
                        lblCheckedDate.Text = objAccessoryDebitNote.QtyCheckedDate.ToString("dd MMM yy (ddd)");
                        chkQtyCheckedBy.Checked = true;
                        CheckedDate = objAccessoryDebitNote.QtyCheckedDate;
                        dvSendMail.Attributes.Add("style", "display:''");
                        dvSendMail.Attributes.Add("style", "float:left;font-weight: bold;margin-left:8px;");
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

        protected void grdAccessoryDebitNot_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //GridViewRow row = grdAccessoryDebitNot.Rows[e.RowIndex];
            //HiddenField hdnIdSelected = (HiddenField)row.FindControl("hdnId");
            //DebitNoteId = hdnDebitnotid.Value == "" ? -1 : Convert.ToInt32(hdnDebitnotid.Value);

            //FabricDebitNoteParticulars objDelete = new FabricDebitNoteParticulars();
            //objDelete.DebitNoteId = DebitNoteId;
            //objDelete.ParticularName = "";
            //objDelete.DebitNoteParticularId = hdnIdSelected.Value == "" ? -1 : Convert.ToInt32(hdnIdSelected.Value);

            //int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            //string stype = "DELETE";
            //int iSave = objFabricWorking.Update_Accessory_DebitNotePartyCulars(objDelete, UserId, stype);

            //List<FabricDebitNoteParticulars> DebitNoteParticularsList = new List<FabricDebitNoteParticulars>();
            //for (int AccNo = 0; AccNo < grdAccessoryDebitNot.Rows.Count; AccNo++)
            //{
            //    FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();

            //    HiddenField hdnId = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnId");
            //    Label lblDebitParticur = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitParticur");
            //    Label lblDebitQty = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitQty");
            //    Label lblDebitRate = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitRate");
            //    HiddenField hdnAmount = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnAmount");

            //    if (hdnIdSelected.Value != hdnId.Value)
            //    {
            //        objDebitNoteParticulars.DebitNoteParticularId = hdnId.Value == "" ? 0 : Convert.ToInt32(hdnId.Value);
            //        objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
            //        objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToInt32(lblDebitQty.Text);
            //        objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
            //        objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);

            //        DebitNoteParticularsList.Add(objDebitNoteParticulars);
            //    }
            //}

            //grdAccessoryDebitNot.DataSource = DebitNoteParticularsList;
            //grdAccessoryDebitNot.DataBind();
            //Session["DebitNoteParticularsList"] = DebitNoteParticularsList;
            //CalculateGrandTotal();
            //ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);


            GridViewRow row = grdAccessoryDebitNot.Rows[e.RowIndex];
            HiddenField hdnIdSelected = (HiddenField)row.FindControl("hdnId");
            DebitNoteId = hdnDebitnotid.Value == "" ? -1 : Convert.ToInt32(hdnDebitnotid.Value);

            FabricDebitNoteParticulars objDelete = new FabricDebitNoteParticulars();
            objDelete.DebitNoteId = DebitNoteId;
            objDelete.ParticularName = "";
            objDelete.DebitNoteParticularId = hdnIdSelected.Value == "" ? -1 : Convert.ToInt32(hdnIdSelected.Value);

            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            string stype = "DELETE";
            int iSave = objFabricWorking.Update_Accessory_DebitNotePartyCulars(objDelete, UserId, stype);


            List<FabricDebitNoteParticulars> DebitNoteParticularsList = (List<FabricDebitNoteParticulars>)Session["DebitNoteParticularsList"];
            DebitNoteParticularsList.RemoveAt(e.RowIndex);
            Session["DebitNoteParticularsList"] = DebitNoteParticularsList;
            grdAccessoryDebitNot.DataSource = (List<FabricDebitNoteParticulars>)Session["DebitNoteParticularsList"];
            grdAccessoryDebitNot.DataBind();
            hdnGrandTotalAmount.Value = DebitNoteParticularsList.Count == 0 ? 0.ToString() : hdnGrandTotalAmount.Value;
            //Session["DebitNoteParticularsList"] = DebitNoteParticularsList;
            CalculateGrandTotal();
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);


        }

        protected void grdAccessoryDebitNot_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // grdAccessoryDebitNot.EditIndex = e.NewEditIndex;

            //List<FabricDebitNoteParticulars> DebitNoteParticularsList = new List<FabricDebitNoteParticulars>();
            //for (int AccNo = 0; AccNo < grdAccessoryDebitNot.Rows.Count; AccNo++)
            //{
            //    FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();

            //    HiddenField hdnId = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnId");
            //    Label lblDebitParticur = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitParticur");
            //    Label lblDebitQty = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitQty");
            //    Label lblDebitRate = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitRate");
            //    HiddenField hdnAmount = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnAmount");

            //    objDebitNoteParticulars.DebitNoteParticularId = hdnId.Value == "" ? 0 : Convert.ToInt32(hdnId.Value);
            //    objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
            //    objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToInt32(lblDebitQty.Text);
            //    objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
            //    objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);

            //    DebitNoteParticularsList.Add(objDebitNoteParticulars);

            //}

            //grdAccessoryDebitNot.DataSource = DebitNoteParticularsList;
            //grdAccessoryDebitNot.DataBind();

            //CalculateGrandTotal();
            //ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);


            grdAccessoryDebitNot.EditIndex = e.NewEditIndex;


            grdAccessoryDebitNot.DataSource = (List<FabricDebitNoteParticulars>)Session["DebitNoteParticularsList"];
            grdAccessoryDebitNot.DataBind();

            CalculateGrandTotal();
            //ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);


        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void grdAccessoryDebitNot_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // GridViewRow row = grdAccessoryDebitNot.Rows[e.RowIndex];
            // HiddenField hdnIdEdit = (HiddenField)row.FindControl("hdnIdEdit");
            // TextBox txtDebitParticur = (TextBox)row.FindControl("txtDebitParticur");
            // TextBox txtDebitQty = (TextBox)row.FindControl("txtDebitQty");
            // TextBox txtDebitRate = (TextBox)row.FindControl("txtDebitRate");
            // if ((txtDebitParticur.Text == "") || (txtDebitQty.Text == "") || (txtDebitRate.Text == ""))
            // {
            //     ShowAlert("Field can not be empty!");
            //     return;
            // }


            // HiddenField hdnIdSelected = (HiddenField)row.FindControl("hdnId");
            // DebitNoteId = hdnDebitnotid.Value == "" ? -1 : Convert.ToInt32(hdnDebitnotid.Value);

            // FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();
            // objDebitNoteParticulars.DebitNoteId = DebitNoteId;
            // objDebitNoteParticulars.DebitNoteParticularId = hdnIdEdit.Value == "" ? 0 : Convert.ToInt32(hdnIdEdit.Value);
            // objDebitNoteParticulars.ParticularName = txtDebitParticur.Text;
            // objDebitNoteParticulars.DebitQuantity = txtDebitQty.Text == "" ? 0 : Convert.ToInt32(txtDebitQty.Text);
            // objDebitNoteParticulars.DebitRate = txtDebitRate.Text == "" ? 0 : Convert.ToDouble(txtDebitRate.Text);
            // objDebitNoteParticulars.Amount = Convert.ToDouble(Math.Round((Convert.ToDouble(objDebitNoteParticulars.DebitQuantity) * objDebitNoteParticulars.DebitRate), 1, MidpointRounding.AwayFromZero));


            // grdAccessoryDebitNot.EditIndex = -1;
            // grdAccessoryDebitNot.DataSource = DebitNoteParticularsList;
            // grdAccessoryDebitNot.DataBind();

            // CalculateGrandTotal();

            // Session["DebitNoteParticularsList"] = DebitNoteParticularsList;

            // int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            // string stype = "UPDATE";
            // int iSave = objFabricWorking.Update_Accessory_DebitNotePartyCulars(objDebitNoteParticulars, UserId, stype);


            // grdAccessoryDebitNot.EditIndex = -1;
            //// BindData(0);
            // CalculateGrandTotal();



            GridViewRow row = grdAccessoryDebitNot.Rows[e.RowIndex];
            HiddenField hdnIdEdit = (HiddenField)row.FindControl("hdnIdEdit");
            TextBox txtDebitParticur = (TextBox)row.FindControl("txtDebitParticur");
            TextBox txtDebitQty = (TextBox)row.FindControl("txtDebitQty");
            TextBox txtDebitRate = (TextBox)row.FindControl("txtDebitRate");
            if ((txtDebitParticur.Text == "") || (txtDebitQty.Text == "") || (txtDebitRate.Text == ""))
            {
                ShowAlert("Field can not be empty!");
                return;
            }

            int MaxId = 0;
            List<FabricDebitNoteParticulars> DebitNoteParticularsList = new List<FabricDebitNoteParticulars>();
            for (int AccNo = 0; AccNo < grdAccessoryDebitNot.Rows.Count; AccNo++)
            {
                FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();

                HiddenField hdnId = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnId");
                Label lblDebitParticur = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitParticur");
                Label lblDebitQty = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitQty");
                Label lblDebitRate = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitRate");
                HiddenField hdnAmount = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnAmount");
                if (hdnId != null && lblDebitRate != null)
                {
                    objDebitNoteParticulars.DebitNoteParticularId = hdnId.Value == "" ? 0 : Convert.ToInt32(hdnId.Value);
                    objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
                    objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToInt32(lblDebitQty.Text);
                    objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
                    objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);

                    MaxId = MaxId + AccNo + 1;
                }
                else
                {


                    HiddenField hdnIdSelected = (HiddenField)row.FindControl("hdnId");
                    DebitNoteId = hdnDebitnotid.Value == "" ? -1 : Convert.ToInt32(hdnDebitnotid.Value);

                    objDebitNoteParticulars.DebitNoteId = DebitNoteId;
                    objDebitNoteParticulars.DebitNoteParticularId = hdnIdEdit.Value == "" ? 0 : Convert.ToInt32(hdnIdEdit.Value);
                    objDebitNoteParticulars.ParticularName = txtDebitParticur.Text;
                    objDebitNoteParticulars.DebitQuantity = txtDebitQty.Text == "" ? 0 : Convert.ToInt32(txtDebitQty.Text);
                    objDebitNoteParticulars.DebitRate = txtDebitRate.Text == "" ? 0 : Convert.ToDouble(txtDebitRate.Text);

                    objDebitNoteParticulars.Amount = Convert.ToDouble(Math.Round((Convert.ToDouble(objDebitNoteParticulars.DebitQuantity) * objDebitNoteParticulars.DebitRate), 1, MidpointRounding.AwayFromZero));
                    MaxId = MaxId + AccNo + 1;
                }
                DebitNoteParticularsList.Add(objDebitNoteParticulars);
            }
            grdAccessoryDebitNot.EditIndex = -1;
            grdAccessoryDebitNot.DataSource = DebitNoteParticularsList;
            grdAccessoryDebitNot.DataBind();

            CalculateGrandTotal();

            Session["DebitNoteParticularsList"] = DebitNoteParticularsList;
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

                List<FabricDebitNoteParticulars> DebitNoteParticularsList = new List<FabricDebitNoteParticulars>();
                FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();
                objDebitNoteParticulars.ParticularName = txtDebitParticular_Empty.Text;
                objDebitNoteParticulars.DebitQuantity = txtDebitQty_Empty.Text == "" ? 0 : Convert.ToInt32(txtDebitQty_Empty.Text);
                objDebitNoteParticulars.DebitRate = txtDebitRate_Empty.Text == "" ? 0 : Convert.ToDouble(txtDebitRate_Empty.Text);
                objDebitNoteParticulars.Amount = hdnAmount_Empty.Value == "" ? 0 : Convert.ToDouble(hdnAmount_Empty.Value);
                objDebitNoteParticulars.DebitNoteParticularId = 1;

                DebitNoteParticularsList.Add(objDebitNoteParticulars);

                grdAccessoryDebitNot.DataSource = DebitNoteParticularsList;
                grdAccessoryDebitNot.DataBind();
                Session["DebitNoteParticularsList"] = DebitNoteParticularsList;
                CalculateGrandTotal();
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);
            }
            if (e.CommandName == "Insert")
            {
                int MaxId = 0;
                List<FabricDebitNoteParticulars> DebitNoteParticularsList = new List<FabricDebitNoteParticulars>();
                for (int AccNo = 0; AccNo < grdAccessoryDebitNot.Rows.Count; AccNo++)
                {
                    FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();

                    HiddenField hdnId = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnId");
                    Label lblDebitParticur = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitParticur");
                    Label lblDebitQty = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitQty");
                    Label lblDebitRate = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitRate");
                    HiddenField hdnAmount = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnAmount");

                    objDebitNoteParticulars.DebitNoteParticularId = hdnId.Value == "" ? 0 : Convert.ToInt32(hdnId.Value);
                    objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
                    objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToInt32(lblDebitQty.Text);
                    objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
                    objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);

                    MaxId = MaxId + AccNo + 1;

                    DebitNoteParticularsList.Add(objDebitNoteParticulars);
                }

                FabricDebitNoteParticulars objDebitNoteParticularsFoo = new FabricDebitNoteParticulars();

                TextBox txtDebitParticur_Footer = grdAccessoryDebitNot.FooterRow.FindControl("txtDebitParticur_Footer") as TextBox;
                TextBox txtDebitQty_Footer = grdAccessoryDebitNot.FooterRow.FindControl("txtDebitQty_Footer") as TextBox;
                TextBox txtDebitRate_Footer = grdAccessoryDebitNot.FooterRow.FindControl("txtDebitRate_Footer") as TextBox;
                HiddenField hdnAmount_Footer = grdAccessoryDebitNot.FooterRow.FindControl("hdnAmount_Footer") as HiddenField;

                objDebitNoteParticularsFoo.ParticularName = txtDebitParticur_Footer.Text;
                objDebitNoteParticularsFoo.DebitQuantity = txtDebitQty_Footer.Text == "" ? 0 : Convert.ToInt32(txtDebitQty_Footer.Text);
                objDebitNoteParticularsFoo.DebitRate = txtDebitRate_Footer.Text == "" ? 0 : Convert.ToDouble(txtDebitRate_Footer.Text);
                objDebitNoteParticularsFoo.Amount = hdnAmount_Footer.Value == "" ? 0 : Convert.ToDouble(hdnAmount_Footer.Value);
                objDebitNoteParticularsFoo.DebitNoteParticularId = MaxId + 1;

                DebitNoteParticularsList.Add(objDebitNoteParticularsFoo);

                grdAccessoryDebitNot.DataSource = DebitNoteParticularsList;
                grdAccessoryDebitNot.DataBind();

                CalculateGrandTotal();
                Session["DebitNoteParticularsList"] = DebitNoteParticularsList;
                ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);
            }
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
                    lblAmount.Text = (DebitQuantity * DebitRate).ToString("N0");

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
                lblIGSTAmount.Text = IGSTAmount.ToString("#,#.##");
                hdnIGSTAmount.Value = IGSTAmount.ToString("#,#.##");
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
                lblGrandTotalAmount.Text = GrandTotalAmount.ToString("N0");
                hdnGrandTotalAmount.Value = GrandTotalAmount.ToString("N0");
            }
            //add code by bharat on 19-Sep-19
            if (lblGrandTotalAmount.Text != "")
            {
                if (lblGrandTotalAmount.Text != "0")
                {
                    lblGranToCurrency.Attributes.Add("class", "indianCurr");
                    lblGrandTotalAmount_currency.Attributes.Add("class", "indianCurr");
                }
                else
                {
                    lblGrandTotalAmount.Text = "";
                    lblGrandTotalAmount_currency.Text = "";

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
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Double TotalAmount = hdnGrandTotalAmount.Value == "" ? 0 : Convert.ToDouble(Math.Round(Convert.ToDecimal(hdnGrandTotalAmount.Value), 1, MidpointRounding.AwayFromZero));

            if (hdnIsChecked.Value == "0")
            {
                if (TotalAmount > 0)
                {
                    FabricDebitNoteCls objAccessoryDebitNote = new FabricDebitNoteCls();
                    if (ddltypes.SelectedValue == "0")
                    {
                        objAccessoryDebitNote.Debptid = int.Parse(ddlBillNo.SelectedValue);
                        //objAccessoryDebitNote.Debptid = DebitNoteId;
                        objAccessoryDebitNote.PartyBillId = -1;
                    }
                    else
                    {
                        objAccessoryDebitNote.PartyBillId = Convert.ToInt32(ddlBillNo.SelectedValue);
                        objAccessoryDebitNote.Debptid = -1;
                    }

                    objAccessoryDebitNote.SupplierPoId = SupplierPoId;
                    objAccessoryDebitNote.DebitNoteId = hdnDebitnotid.Value == "" ? -1 : int.Parse(hdnDebitnotid.Value);
                    objAccessoryDebitNote.DebitNoteNumber = lblDebitNo.Text;
                    objAccessoryDebitNote.DebitNoteDate = txtDate.Text != "" ? DateTime.ParseExact(txtDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;

                    //objAccessoryDebitNote.ReturnChallanNumber = txtReturnChallan.Text;
                    //objAccessoryDebitNote.ChallanDate = txtreturndate.Text != "" ? DateTime.ParseExact(txtreturndate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;

                    objAccessoryDebitNote.ReturnChallanNumber = "";
                    objAccessoryDebitNote.ChallanDate = DateTime.Now;


                    objAccessoryDebitNote.IGST = txtIGST.Text == "" ? 0 : Convert.ToDouble(txtIGST.Text);
                    objAccessoryDebitNote.CGST = txtCGST.Text == "" ? 0 : Convert.ToDouble(txtCGST.Text);
                    objAccessoryDebitNote.SGST = txtSGST.Text == "" ? 0 : Convert.ToDouble(txtSGST.Text);
                    objAccessoryDebitNote.TotalAmount = hdnGrandTotalAmount.Value == "" ? 0 : Convert.ToDouble(Math.Round(Convert.ToDecimal(hdnGrandTotalAmount.Value), 1, MidpointRounding.AwayFromZero));
                    if (divCheckBox2.Visible == true && chkQtyCheckedBy.Checked == true)
                    {
                        objAccessoryDebitNote.QtyCheckedBy = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                        objAccessoryDebitNote.QtyCheckedDate = DateTime.Now;
                    }
                    else
                    {
                        if (chkQtyCheckedBy.Checked)
                        {
                            objAccessoryDebitNote.QtyCheckedBy = 1;
                            objAccessoryDebitNote.QtyCheckedDate = CheckedDate;
                        }
                        else
                        {
                            objAccessoryDebitNote.QtyCheckedBy = 0;
                            objAccessoryDebitNote.QtyCheckedDate = DateTime.MinValue;
                        }
                    }
                    List<FabricDebitNoteParticulars> objDebitNoteParticularsList = new List<FabricDebitNoteParticulars>();

                    if (grdAccessoryDebitNot.Rows.Count == 0)
                    {
                        Control control = null;
                        control = grdAccessoryDebitNot.Controls[0].Controls[0];
                        if ((TextBox)control.FindControl("txtDebitParticular_Empty") != null)
                        {
                            TextBox txtDebitParticular_Empty = (TextBox)control.FindControl("txtDebitParticular_Empty");
                            TextBox txtDebitQty_Empty = (TextBox)control.FindControl("txtDebitQty_Empty");
                            TextBox txtDebitRate_Empty = (TextBox)control.FindControl("txtDebitRate_Empty");

                            FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();

                            objDebitNoteParticulars.ParticularName = txtDebitParticular_Empty.Text;
                            objDebitNoteParticulars.DebitQuantity = txtDebitQty_Empty.Text == "" ? 0 : Convert.ToInt32(txtDebitQty_Empty.Text);
                            objDebitNoteParticulars.DebitRate = txtDebitRate_Empty.Text == "" ? 0 : Convert.ToDouble(txtDebitRate_Empty.Text);
                            objDebitNoteParticulars.DebitNoteParticularId = -1;

                            objDebitNoteParticularsList.Add(objDebitNoteParticulars);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < grdAccessoryDebitNot.Rows.Count; i++)
                        {
                            Label lblDebitParticur = (Label)grdAccessoryDebitNot.Rows[i].FindControl("lblDebitParticur");
                            Label lblDebitQty = (Label)grdAccessoryDebitNot.Rows[i].FindControl("lblDebitQty");
                            Label lblDebitRate = (Label)grdAccessoryDebitNot.Rows[i].FindControl("lblDebitRate");
                            HiddenField hdnId = (HiddenField)grdAccessoryDebitNot.Rows[i].FindControl("hdnId");

                            FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();

                            objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
                            objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToInt32(lblDebitQty.Text);
                            objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
                            objDebitNoteParticulars.DebitNoteParticularId = hdnId.Value == "" ? -1 : Convert.ToInt32(hdnId.Value);

                            objDebitNoteParticularsList.Add(objDebitNoteParticulars);
                        }

                        TextBox txtDebitParticur_Footer = (TextBox)grdAccessoryDebitNot.FooterRow.FindControl("txtDebitParticur_Footer");
                        TextBox txtDebitQty_Footer = (TextBox)grdAccessoryDebitNot.FooterRow.FindControl("txtDebitQty_Footer");
                        TextBox txtDebitRate_Footer = (TextBox)grdAccessoryDebitNot.FooterRow.FindControl("txtDebitRate_Footer");
                        if ((txtDebitParticur_Footer.Text != "") && (txtDebitQty_Footer.Text != "") && (txtDebitRate_Footer.Text != ""))
                        {
                            FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();

                            objDebitNoteParticulars.ParticularName = txtDebitParticur_Footer.Text;
                            objDebitNoteParticulars.DebitQuantity = txtDebitQty_Footer.Text == "" ? 0 : Convert.ToInt32(txtDebitQty_Footer.Text);
                            objDebitNoteParticulars.DebitRate = txtDebitRate_Footer.Text == "" ? 0 : Convert.ToDouble(txtDebitRate_Footer.Text);
                            objDebitNoteParticulars.DebitNoteParticularId = -1;

                            objDebitNoteParticularsList.Add(objDebitNoteParticulars);
                        }
                    }

                    objAccessoryDebitNote.FabricDebitNoteParticularsList = objDebitNoteParticularsList;

                    int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                    int iSave = objFabricWorking.Save_fabric_CreditNote(objAccessoryDebitNote, UserId);

                    //if (iSave > 0)
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "jQuery.facebox('Some error occured);", true);
                    //    return;
                    //}

                    if (iSave > 0)
                    {
                        if (chkQtyCheckedBy.Checked && rbtnYes.Checked)
                        {
                            RenderHtml();
                            string PdfFilePath = "CreditNote_" + DebitNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf";
                            string url = host + "/Uploads/Print/" + PdfFilePath;
                            string EmailContent = HttpContent(url);
                            SendCreditNoteEmail("test", "kumar", EmailContent);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "jQuery.facebox('Some error occured);", true);
                        return;
                    }
                }
            }
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "jQuery.facebox('Details can not be empty');", true);
            //    return;
            //}

            if (hdnIsChecked.Value == "1" && rbtnYes.Checked)
            {
                RenderHtml();
                string PdfFilePath = "CreditNote_" + DebitNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf";
                string url = host + "/Uploads/Print/" + PdfFilePath;
                string EmailContent = HttpContent(url);
                SendCreditNoteEmail("test", "kumar", EmailContent);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
        }

        protected void grdAccessoryDebitNot_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //grdAccessoryDebitNot.EditIndex = -1;
            //BindData(0);
            //CalculateGrandTotal();

            if (Session["DebitNoteParticularsList"] != null)
            {
                grdAccessoryDebitNot.EditIndex = -1;
                grdAccessoryDebitNot.DataSource = (List<FabricDebitNoteParticulars>)Session["DebitNoteParticularsList"];
                grdAccessoryDebitNot.DataBind();

                // Session["DebitNoteParticularsList"] = null;
            }
            else
            {
                GridViewRow row = grdAccessoryDebitNot.Rows[e.RowIndex];
                HiddenField hdnIdEdit = (HiddenField)row.FindControl("hdnIdEdit");
                TextBox txtDebitParticur = (TextBox)row.FindControl("txtDebitParticur");
                TextBox txtDebitQty = (TextBox)row.FindControl("txtDebitQty");
                TextBox txtDebitRate = (TextBox)row.FindControl("txtDebitRate");

                int MaxId = 0;
                List<FabricDebitNoteParticulars> DebitNoteParticularsList = new List<FabricDebitNoteParticulars>();
                for (int AccNo = 0; AccNo < grdAccessoryDebitNot.Rows.Count; AccNo++)
                {
                    FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();

                    HiddenField hdnId = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnId");
                    Label lblDebitParticur = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitParticur");
                    Label lblDebitQty = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitQty");
                    Label lblDebitRate = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitRate");
                    HiddenField hdnAmount = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnAmount");
                    if (hdnId != null && lblDebitRate != null)
                    {
                        objDebitNoteParticulars.DebitNoteParticularId = hdnId.Value == "" ? 0 : Convert.ToInt32(hdnId.Value);
                        objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
                        objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToInt32(lblDebitQty.Text);
                        objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
                        objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);

                        MaxId = MaxId + AccNo + 1;
                    }
                    else
                    {


                        HiddenField hdnIdSelected = (HiddenField)row.FindControl("hdnId");
                        DebitNoteId = hdnDebitnotid.Value == "" ? -1 : Convert.ToInt32(hdnDebitnotid.Value);

                        objDebitNoteParticulars.DebitNoteId = DebitNoteId;
                        objDebitNoteParticulars.DebitNoteParticularId = hdnIdEdit.Value == "" ? 0 : Convert.ToInt32(hdnIdEdit.Value);
                        objDebitNoteParticulars.ParticularName = txtDebitParticur.Text;
                        objDebitNoteParticulars.DebitQuantity = txtDebitQty.Text == "" ? 0 : Convert.ToInt32(txtDebitQty.Text);
                        objDebitNoteParticulars.DebitRate = txtDebitRate.Text == "" ? 0 : Convert.ToDouble(Convert.ToDouble(txtDebitRate.Text));
                        objDebitNoteParticulars.Amount = Convert.ToDouble(Math.Round((Convert.ToDouble(objDebitNoteParticulars.DebitQuantity) * objDebitNoteParticulars.DebitRate), 1, MidpointRounding.AwayFromZero));

                        MaxId = MaxId + AccNo + 1;
                    }

                    DebitNoteParticularsList.Add(objDebitNoteParticulars);
                }
                grdAccessoryDebitNot.EditIndex = -1;
                grdAccessoryDebitNot.DataSource = DebitNoteParticularsList;
                grdAccessoryDebitNot.DataBind();
            }


            // BindData(0);
            CalculateGrandTotal();
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            BindData(1);
            CalculateGrandTotal();
        }

        public void RenderHtml()
        {
            WebRequest Request;
            WebResponse Response;
            StreamReader Reader;
            string strHTML;

            Request = WebRequest.Create(host + "/FabricPdfFile/FabricCreditNotePdf.aspx?SupplierPoId=" + SupplierPoId + "&DebitNoteId=" + DebitNoteId + "&RupeesInWord=" + hdnRupees.Value);
            Request.Timeout = 99999999;
            Response = Request.GetResponse();
            Reader = new StreamReader(Response.GetResponseStream());
            strHTML = Reader.ReadToEnd();
            generatePDF(strHTML);
        }

        public void generatePDF(string strHTML)
        {
            string PdfFilePath = HttpContext.Current.Server.MapPath("~/Uploads/Print/CreditNote_" + DebitNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf");
            strHTML = getImage(strHTML);
            getvartypeHTML(strHTML, PdfFilePath);
        }

        public void getvartypeHTML(string strHTML, string PdfFilePath)
        {
            string FilePath = HttpContext.Current.Server.MapPath("~/Uploads/Print/CreditNote_" + DebitNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf");
            using (IPechkin pechkin = Factory.Create(new GlobalConfig()))
            {
                var pdf = pechkin.Convert(new ObjectConfig()
                                         .SetCreateExternalLinks(true)
                                         .SetZoomFactor(1.5)
                                         .SetPrintBackground(true)
                                         .SetScreenMediaType(true)
                                         .SetCreateExternalLinks(true)
                                         .SetLoadImages(true), strHTML);

                using (FileStream file = File.Create(FilePath))
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
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2";
                req.Timeout = 99999999;
                using (var resp = req.GetResponse())
                {
                    result = new StreamReader(resp.GetResponseStream()).ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                result = ex.Message.ToString();
            }
            return result;
        }

        public Boolean SendCreditNoteEmail(string ClientName, string UserPassword, string MailContent)
        {
            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                List<string> to = new List<string>();
                string email = "itsupport@boutique.in";
                to.Add(email);

                List<Attachment> attachment = new List<Attachment>();
                if (File.Exists(Constants.PRINT_FOLDER_PATH + "CreditNote_" + DebitNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf"))
                {
                    PoPath = Path.Combine(Constants.PRINT_FOLDER_PATH, "CreditNote_" + DebitNoteId.ToString() + "(" + ddlBillNo.SelectedItem.Text.Substring(0, ddlBillNo.SelectedItem.Text.IndexOf('-')) + ")" + ".pdf");
                    attachment.Add(new Attachment(PoPath));
                }
                SendEmail(fromName, to, null, null, MailContent, attachment, false, false);

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
            mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a <b>Credit note</b> is raised against <span style='color:gray'>" + "Debit No - </span></span><span style='color:#2f5597'>" + hdnDebitNoteNumber.Value + "</span> for  <span style='color:gray'>" + "Purchase Order - </span></span><span style='color:#2f5597'>" + hdnPO_Number.Value + "</span>. Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> Disclaimer: This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
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
                mailMessage.CC.Add("itsupport@boutique.in,bipl_fabric@boutique.in");

            }
            else
            {
                foreach (String to in To)
                {
                    mailMessage.To.Add(to);
                }

                mailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.CC.Add("bipl_fabric@boutique.in");     
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