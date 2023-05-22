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
using iKandi.Web.Components.Helper;
using iKandi.BLL.CmtAdmin;
using System.Net;
using iKandi.Common.Entities;
using System.Web.Services;


namespace iKandi.Web
{
    public partial class FrmDebitNotePdf : System.Web.UI.Page
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
        public static int PoUnit
        {
            get;
            set;
        }
        public int IsSignatureDone
        {
            get;
            set;
        }
        public string GstNumber
        {
            get;
            set;
        }
        FabricController objFabricWorking = new FabricController();
        string host = "";
        public string PhotoPath
        {
            get;
            set;
        }
        public DateTime DateChecked
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;
            imgboutique.ImageUrl = host + "/images/boutique-logo.png";

            GetQueryString();
            //= objFabricWorking.GetGSTByPoNumber("GST", SupplierPoId, DebitNoteId);
            //if (HttpRuntime.Cache["GSTBYPO"] == null)
            //{
            //    HttpRuntime.Cache.Insert("GSTBYPO", objFabricWorking.GetGSTByPoNumber("GST", SupplierPoId, DebitNoteId), null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
            //}
            DataTable dtgst = objFabricWorking.GetGSTByPoNumber("GST", SupplierPoId, DebitNoteId);
            txtCGST.Text = Convert.ToDouble(dtgst.Rows[0]["CGST"].ToString()).ToString();
            txtIGST.Text = Convert.ToDouble(dtgst.Rows[0]["IGST"].ToString()).ToString();
            txtSGST.Text = Convert.ToDouble(dtgst.Rows[0]["SGST"].ToString()).ToString();
            string prefixcode = dtgst.Rows[0]["Prefixcode"].ToString();
            GstNumber = dtgst.Rows[0]["GSTNumber"].ToString();
            if (GstNumber != "0")
            {
                // if (GstNumber.ToString().Substring(1) == "91")
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
               
                Session["DebitNoteParticularsList"] = null;

                BindData(0);
                CalculateGrandTotal();
                // Session["DebitNoteParticularsList"] = null;

                DataTable dt = objFabricWorking.Getbipladdress("BIPLAddress4");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();

                lblCheckerName.Text = Name;
                imgCheckerSig.ImageUrl = host + "/Uploads/Photo/" + PhotoPath;
                lblCheckedDate.Text = DateChecked.ToString("dd MMM yy (ddd)");

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
                SupplierPoId = 214;
            }
            if (Request.QueryString["DebitNoteId"] != null)
            {
                DebitNoteId = Convert.ToInt32(Request.QueryString["DebitNoteId"]);
            }
            else
            {
                //DebitNoteId = 0;
                DebitNoteId = 2;
            }
            if (Request.QueryString["PhotoPath"] != null)
            {
                PhotoPath = Request.QueryString["PhotoPath"].ToString();
            }
            if (Request.QueryString["DateChecked"] != null)
            {
                DateChecked = Convert.ToDateTime(Request.QueryString["DateChecked"].ToString());
            }
            if (Request.QueryString["Name"] != null)
            {
                Name = Request.QueryString["Name"].ToString();
            }
        }
        [WebMethod]
        public static void SetSession(string sessionval)
        {
            HttpContext.Current.Session["qtyrange"] = sessionval;
        }
        private void BindBillDropdownList(int PartyBillId)
        {
            List<Fabric_Srv_Bill> Accessory_Srv_BillList = objFabricWorking.GetAccessory_Srv_Bill_DropDownList(SupplierPoId, DebitNoteId);
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
                lblbill.Text = ddlBillNo.SelectedItem.Text;
                string[] sChar = BillDetails.Split('(');
                string[] sChar1 = sChar[1].Split(')');
                string sAmount = sChar1[0].ToString();
                hdnBillAmount.Value = sAmount.Trim();
                hdnsrvqty.Value = Accessory_Srv_BillList[0].srvdebitamount.ToString();
            }

        }



        private void BindData(int IsPageRefresh)
        {


            FabricDebitNoteCls objAccessoryDebitNote = objFabricWorking.Get_FabricDebitNote(SupplierPoId, DebitNoteId,"",0);
            hdnDebitnotid.Value = objAccessoryDebitNote.DebitNoteId.ToString();
            //txtPonumber.Text = objAccessoryDebitNote.PoNumber;
            lblDebitNo.Text = objAccessoryDebitNote.DebitNoteNumber;
            lblSupllierName.Text = objAccessoryDebitNote.SupplierName;
            lblQualityName.Text = objAccessoryDebitNote.QualityName;
            lblQualityDetails.Text = objAccessoryDebitNote.QualityDetails;           

            //txtIGST.Text = objAccessoryDebitNote.IGST == 0 ? "" : objAccessoryDebitNote.IGST.ToString();//new line
            //txtCGST.Text = objAccessoryDebitNote.CGST == 0 ? "" : objAccessoryDebitNote.CGST.ToString();//new line
            //txtSGST.Text = objAccessoryDebitNote.SGST == 0 ? "" : objAccessoryDebitNote.SGST.ToString();//new line
            if (objAccessoryDebitNote.FourPointFailQty > 0)
            {
                string d = "";
                if (objAccessoryDebitNote.ConvertToUnit != objAccessoryDebitNote.defualtunit)
                {
                    d = Math.Round((Convert.ToDecimal(objAccessoryDebitNote.FourPointFailQty) * Convert.ToDecimal(objAccessoryDebitNote.ConversionValue)), 0).ToString();
                }
                else
                {
                    d = objAccessoryDebitNote.FourPointFailQty.ToString();
                }
                lblunitcaption.Text = "Fail Qty: " + d + " " + Enum.GetName(typeof(FabricUnit), Convert.ToInt32(objAccessoryDebitNote.ConvertToUnit));
            }
            else
            {
                lblunitcaption.Visible = false;
            }
            if (objAccessoryDebitNote.ConvertToUnit != objAccessoryDebitNote.defualtunit)
            {
                PoUnit = objAccessoryDebitNote.ConvertToUnit;
            }
            else
            {
                PoUnit = objAccessoryDebitNote.defualtunit;
            }
            txtReturnChallan.Text = objAccessoryDebitNote.ReturnChallanNumber;
            if (objAccessoryDebitNote.ChallanDate.ToString() != "1/1/0001 12:00:00 AM")
            {
                txtreturndate.Text = objAccessoryDebitNote.ChallanDate.ToString("dd MMM yy (ddd)");
            }

            if (objAccessoryDebitNote.QtyCheckedBy > 0)
            {
                divCheckBox2.Visible = false;
                //divSignature2.Visible = true;
                //foreach (var user in iKandi.Web.Components.ApplicationHelper.Users)
                //{
                //    if (objAccessoryDebitNote.QtyCheckedBy == user.UserID)
                //    {
                //        lblCheckerName.Text = user.FirstName + " " + user.LastName;
                //        imgCheckerSig.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg"; ;
                //        lblCheckedDate.Text = objAccessoryDebitNote.QtyCheckedDate.ToString("dd MMM yy (ddd)");
                //    }
                //}
                IsSignatureDone = 1;
            }
            List<FabricDebitNoteParticulars> objDebitNoteParticulars = objAccessoryDebitNote.FabricDebitNoteParticularsList;
            grdAccessoryDebitNot.DataSource = objDebitNoteParticulars;
            grdAccessoryDebitNot.DataBind();
            Session["DebitNoteParticularsList"] = objDebitNoteParticulars;
            if (DebitNoteId > 0)
            {
                hdnGST_No.Value = objAccessoryDebitNote.GSTNo.ToString();//new line
                txtDate.Text = objAccessoryDebitNote.DebitNoteDate.ToString("dd MMM yy (ddd)");
                txtIGST.Text = objAccessoryDebitNote.IGST == 0 ? "" : objAccessoryDebitNote.IGST.ToString();
                txtCGST.Text = objAccessoryDebitNote.CGST == 0 ? "" : objAccessoryDebitNote.CGST.ToString();
                txtSGST.Text = objAccessoryDebitNote.SGST == 0 ? "" : objAccessoryDebitNote.SGST.ToString();

                BindBillDropdownList(objAccessoryDebitNote.PartyBillId);
                ddlBillNo.Attributes.Add("disabled", "disabled");
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
            GridViewRow row = grdAccessoryDebitNot.Rows[e.RowIndex];
            HiddenField hdnIdSelected = (HiddenField)row.FindControl("hdnId");
            DebitNoteId = hdnDebitnotid.Value == "" ? -1 : Convert.ToInt32(hdnDebitnotid.Value);

            FabricDebitNoteParticulars objDelete = new FabricDebitNoteParticulars();
            objDelete.DebitNoteId = DebitNoteId;
            objDelete.ParticularName = "";
            objDelete.DebitNoteParticularId = hdnIdSelected.Value == "" ? -1 : Convert.ToInt32(hdnIdSelected.Value);

            //int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            int UserId = 144;
            string stype = "DELETE";
            int iSave = objFabricWorking.Update_Accessory_DebitNotePartyCulars(objDelete, UserId, stype);

            ////List<FabricDebitNoteParticulars> DebitNoteParticularsList = new List<FabricDebitNoteParticulars>();
            ////for (int AccNo = 0; AccNo < grdAccessoryDebitNot.Rows.Count; AccNo++)
            ////{
            ////    FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();

            ////    HiddenField hdnId = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnId");
            ////    Label lblDebitParticur = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitParticur");
            ////    Label lblDebitQty = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitQty");
            ////    Label lblDebitRate = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitRate");
            ////    HiddenField hdnAmount = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnAmount");

            ////    if (hdnIdSelected.Value != hdnId.Value)
            ////    {
            ////        objDebitNoteParticulars.DebitNoteParticularId = hdnId.Value == "" ? 0 : Convert.ToInt32(hdnId.Value);
            ////        objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
            ////        objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToInt32(lblDebitQty.Text);
            ////        objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
            ////        objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);

            ////        DebitNoteParticularsList.Add(objDebitNoteParticulars);
            ////    }
            ////}
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
            grdAccessoryDebitNot.EditIndex = e.NewEditIndex;

            ////List<FabricDebitNoteParticulars> DebitNoteParticularsList = new List<FabricDebitNoteParticulars>();
            ////for (int AccNo = 0; AccNo < grdAccessoryDebitNot.Rows.Count; AccNo++)
            ////{
            ////    FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();

            ////    HiddenField hdnId = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnId");
            ////    Label lblDebitParticur = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitParticur");
            ////    Label lblDebitQty = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitQty");
            ////    Label lblDebitRate = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("lblDebitRate");
            ////    HiddenField hdnAmount = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnAmount");
            ////    HiddenField hdntypes = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdntypes");

            ////    objDebitNoteParticulars.DebitNoteParticularId = hdnId.Value == "" ? 0 : Convert.ToInt32(hdnId.Value);
            ////    objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
            ////    objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToInt32(lblDebitQty.Text);
            ////    objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
            ////    objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);
            ////    objDebitNoteParticulars.IsExtraQty = hdntypes.Value == "" ? -1 : Convert.ToInt32(hdntypes.Value);

            ////    DebitNoteParticularsList.Add(objDebitNoteParticulars);


            ////    if (hdnId != null && lblDebitRate != null)
            ////    {
            ////        objDebitNoteParticulars.DebitNoteParticularId = hdnId.Value == "" ? 0 : Convert.ToInt32(hdnId.Value);
            ////        objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
            ////        objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToInt32(lblDebitQty.Text);
            ////        objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
            ////        objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);
            ////        objDebitNoteParticulars.IsExtraQty = hdntypes.Value == "" ? -1 : Convert.ToInt32(hdntypes.Value);


            ////    }
            ////    else
            ////    {
            ////        HiddenField hdnIdEdit = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnIdEdit");
            ////        Label txtDebitParticur = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("txtDebitParticur");
            ////        Label txtDebitQty = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("txtDebitQty");
            ////        Label txtDebitRate = (Label)grdAccessoryDebitNot.Rows[AccNo].FindControl("txtDebitRate");
            ////        HiddenField hdnAmount = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnAmount");
            ////        HiddenField hdntypesedit = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdntypesedit");



            ////        DebitNoteId = hdnDebitnotid.Value == "" ? -1 : Convert.ToInt32(hdnDebitnotid.Value);

            ////        objDebitNoteParticulars.DebitNoteId = DebitNoteId;
            ////        objDebitNoteParticulars.DebitNoteParticularId = hdnIdEdit.Value == "" ? 0 : Convert.ToInt32(hdnIdEdit.Value);
            ////        objDebitNoteParticulars.ParticularName = txtDebitParticur.Text;
            ////        objDebitNoteParticulars.DebitQuantity = txtDebitQty.Text == "" ? 0 : Convert.ToInt32(txtDebitQty.Text);
            ////        objDebitNoteParticulars.DebitRate = txtDebitRate.Text == "" ? 0 : Convert.ToDouble(txtDebitRate.Text);
            ////        objDebitNoteParticulars.IsExtraQty = hdntypes.Value == "" ? -1 : Convert.ToInt32(hdntypes.Value);
            ////        objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);

            ////        objDebitNoteParticulars.Amount = Convert.ToDouble(Math.Round((Convert.ToDouble(objDebitNoteParticulars.DebitQuantity) * objDebitNoteParticulars.DebitRate), 1, MidpointRounding.AwayFromZero));
            ////        MaxId = MaxId + AccNo + 1;
            ////    }

            ////}



            ////grdAccessoryDebitNot.DataSource = DebitNoteParticularsList;
            ////grdAccessoryDebitNot.DataBind();

            grdAccessoryDebitNot.DataSource = (List<FabricDebitNoteParticulars>)Session["DebitNoteParticularsList"];
            grdAccessoryDebitNot.DataBind();

            CalculateGrandTotal();
            ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "HideShowGST()", true);
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void grdAccessoryDebitNot_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = grdAccessoryDebitNot.Rows[e.RowIndex];
            HiddenField hdnIdEdit = (HiddenField)row.FindControl("hdnIdEdit");
            Label txtDebitParticur = (Label)row.FindControl("txtDebitParticur");
            Label txtDebitQty = (Label)row.FindControl("txtDebitQty");
            Label txtDebitRate = (Label)row.FindControl("txtDebitRate");
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
                HiddenField hdntypes = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdntypes");
                HiddenField hdnsrvid = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnsrvid");
                if (hdnId != null && lblDebitRate != null)
                {
                    objDebitNoteParticulars.DebitNoteParticularId = hdnId.Value == "" ? 0 : Convert.ToInt32(hdnId.Value);
                    objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
                    objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToInt32(lblDebitQty.Text.Replace(",",""));
                    objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
                    objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);
                    objDebitNoteParticulars.IsExtraQty = hdntypes.Value == "" ? -1 : Convert.ToInt32(hdntypes.Value);
                    objDebitNoteParticulars.Fab_DebitNote_SRVID = Convert.ToInt32(hdnsrvid.Value);

                    MaxId = MaxId + AccNo + 1;
                }
                else
                {


                    HiddenField hdnIdSelected = (HiddenField)row.FindControl("hdnId");
                    HiddenField hdntypesedit = (HiddenField)row.FindControl("hdntypesedit");
                    HiddenField hdnsrvidedit = (HiddenField)row.FindControl("hdnsrvid");
                    DebitNoteId = hdnDebitnotid.Value == "" ? -1 : Convert.ToInt32(hdnDebitnotid.Value);

                    objDebitNoteParticulars.DebitNoteId = DebitNoteId;
                    objDebitNoteParticulars.DebitNoteParticularId = hdnIdEdit.Value == "" ? 0 : Convert.ToInt32(hdnIdEdit.Value);
                    objDebitNoteParticulars.ParticularName = txtDebitParticur.Text;
                    objDebitNoteParticulars.DebitQuantity = txtDebitQty.Text == "" ? 0 : Convert.ToInt32(txtDebitQty.Text);
                    objDebitNoteParticulars.DebitRate = txtDebitRate.Text == "" ? 0 : Convert.ToDouble(txtDebitRate.Text);

                    objDebitNoteParticulars.IsExtraQty = hdntypesedit.Value == "" ? -1 : Convert.ToInt32(hdntypesedit.Value);
                    objDebitNoteParticulars.Fab_DebitNote_SRVID = Convert.ToInt32(hdnsrvidedit.Value);

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
            ////int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            ////string stype = "UPDATE";
            ////int iSave = objFabricWorking.Update_Accessory_DebitNotePartyCulars(objDebitNoteParticulars, UserId, stype); 


            ////grdAccessoryDebitNot.EditIndex = -1;            
            ////BindData(0);
            ////CalculateGrandTotal(); 
        }

        protected void grdAccessoryDebitNot_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddEmpty")
            {
                Table tblgvDetail = (Table)grdAccessoryDebitNot.Controls[0];
                GridViewRow rows = (GridViewRow)tblgvDetail.Controls[0];

                Label txtDebitParticular_Empty = (Label)rows.FindControl("txtDebitParticular_Empty");
                Label txtDebitQty_Empty = (Label)rows.FindControl("txtDebitQty_Empty");
                Label txtDebitRate_Empty = (Label)rows.FindControl("txtDebitRate_Empty");
                HiddenField hdnAmount_Empty = (HiddenField)rows.FindControl("hdnAmount_Empty");

                List<FabricDebitNoteParticulars> DebitNoteParticularsList = new List<FabricDebitNoteParticulars>();
                FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();
                objDebitNoteParticulars.ParticularName = txtDebitParticular_Empty.Text;
                objDebitNoteParticulars.DebitQuantity = txtDebitQty_Empty.Text == "" ? 0 : Convert.ToInt32(txtDebitQty_Empty.Text);
                objDebitNoteParticulars.DebitRate = txtDebitRate_Empty.Text == "" ? 0 : Convert.ToDouble(txtDebitRate_Empty.Text);
                objDebitNoteParticulars.Amount = hdnAmount_Empty.Value == "" ? 0 : Convert.ToDouble(hdnAmount_Empty.Value);
                objDebitNoteParticulars.DebitNoteParticularId = 1;
                objDebitNoteParticulars.Fab_DebitNote_SRVID = -1;
                objDebitNoteParticulars.IsExtraQty = -1;


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
                    HiddenField hdntypes = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdntypes");
                    HiddenField hdnsrvid = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnsrvid");
                    objDebitNoteParticulars.DebitNoteParticularId = hdnId.Value == "" ? 0 : Convert.ToInt32(hdnId.Value);
                    objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
                    objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToInt32(lblDebitQty.Text.Replace(",", ""));
                    objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
                    objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);
                    objDebitNoteParticulars.IsExtraQty = hdntypes.Value == "" ? -1 : Convert.ToInt32(hdntypes.Value);
                    objDebitNoteParticulars.Fab_DebitNote_SRVID = Convert.ToInt32(hdnsrvid.Value);
                    MaxId = MaxId + AccNo + 1;

                    DebitNoteParticularsList.Add(objDebitNoteParticulars);
                }

                FabricDebitNoteParticulars objDebitNoteParticularsFoo = new FabricDebitNoteParticulars();

                Label txtDebitParticur_Footer = grdAccessoryDebitNot.FooterRow.FindControl("txtDebitParticur_Footer") as Label;
                Label txtDebitQty_Footer = grdAccessoryDebitNot.FooterRow.FindControl("txtDebitQty_Footer") as Label;
                Label txtDebitRate_Footer = grdAccessoryDebitNot.FooterRow.FindControl("txtDebitRate_Footer") as Label;
                HiddenField hdnAmount_Footer = grdAccessoryDebitNot.FooterRow.FindControl("hdnAmount_Footer") as HiddenField;

                objDebitNoteParticularsFoo.ParticularName = txtDebitParticur_Footer.Text;
                objDebitNoteParticularsFoo.DebitQuantity = txtDebitQty_Footer.Text == "" ? 0 : Convert.ToInt32(txtDebitQty_Footer.Text);
                objDebitNoteParticularsFoo.DebitRate = txtDebitRate_Footer.Text == "" ? 0 : Convert.ToDouble(txtDebitRate_Footer.Text);
                objDebitNoteParticularsFoo.Amount = hdnAmount_Footer.Value == "" ? 0 : Convert.ToDouble(hdnAmount_Footer.Value);
                objDebitNoteParticularsFoo.DebitNoteParticularId = MaxId + 1;
                objDebitNoteParticularsFoo.IsExtraQty = -1;
                objDebitNoteParticularsFoo.Fab_DebitNote_SRVID = -1;
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
            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                // e.Row.Cells[0].Text = "Quantity " + Enum.GetName(typeof(FabricUnit), PoUnit);
                Label lblqtyh = (Label)grdAccessoryDebitNot.Controls[0].Controls[0].FindControl("lblqtyh");
                lblqtyh.Text = "Quantity <span style='color:gray;font-wight:600;'>" + Enum.GetName(typeof(FabricUnit), PoUnit) + "</span>";
            }
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[3].Text = "Quantity <span style='color:gray;font-wight:600;'>" + Enum.GetName(typeof(FabricUnit), PoUnit) + "</span>";
            }
            if ((e.Row.RowState == DataControlRowState.Edit) && (e.Row.RowType == DataControlRowType.DataRow))
            {
                int DebitQuantity = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DebitQuantity"));
                Double DebitRate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DebitRate"));

                Label lblAmountEdit = (Label)e.Row.FindControl("lblAmountEdit");
                Label lbltypesedit = (Label)e.Row.FindControl("lbltypesedit");
                Label txtDebitQty = (Label)e.Row.FindControl("txtDebitQty");

                if (lbltypesedit.Text == "1")
                {
                    lbltypesedit.Text = "Extra";
                    txtDebitQty.Enabled = false;
                }
                else if (lbltypesedit.Text == "0")
                {
                    lbltypesedit.Text = "Fail";
                    txtDebitQty.Enabled = false;
                }
                else
                {
                    lbltypesedit.Text = "N/A";
                }
                lblAmountEdit.Text = (DebitQuantity * DebitRate).ToString("N0");

                HiddenField hdnAmountEdit = (HiddenField)e.Row.FindControl("hdnAmountEdit");
                hdnAmountEdit.Value = (DebitQuantity * DebitRate).ToString();

                TotalAmount = TotalAmount + Convert.ToInt32(hdnAmountEdit.Value);
            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    int DebitQuantity = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DebitQuantity"));
                    Double DebitRate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DebitRate"));

                    Label lblAmount = (Label)e.Row.FindControl("lblAmount");
                    if (lblAmount != null)
                    {
                        lblAmount.Text = (DebitQuantity * DebitRate).ToString("N0");

                        HiddenField hdnAmount = (HiddenField)e.Row.FindControl("hdnAmount");
                        hdnAmount.Value = (DebitQuantity * DebitRate).ToString();

                        TotalAmount = TotalAmount + Convert.ToDouble(hdnAmount.Value);

                        HiddenField hdntypes = (HiddenField)e.Row.FindControl("hdntypes");
                        Label lbltypes = (Label)e.Row.FindControl("lbltypes");
                        if (hdntypes.Value == "1")
                        {
                            lbltypes.Text = "Extra";

                        }
                        else if (hdntypes.Value == "0")
                        {
                            lbltypes.Text = "Fail";
                        }
                        else
                        {
                            lbltypes.Text = "N/A";
                        }

                    }
                    else
                    {
                        DebitQuantity = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DebitQuantity"));
                        DebitRate = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "DebitRate"));
                        Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DebitRate"));

                        Label lblAmountEdit = (Label)e.Row.FindControl("lblAmountEdit");
                        Label txtDebitQty = (Label)e.Row.FindControl("txtDebitQty");

                        Label lbltypesedit = (Label)e.Row.FindControl("lbltypesedit");
                        if (DataBinder.Eval(e.Row.DataItem, "IsExtraQty").ToString() == "1")
                        {
                            lbltypesedit.Text = "Extra";
                            txtDebitQty.Enabled = false;
                        }
                        else if (DataBinder.Eval(e.Row.DataItem, "IsExtraQty").ToString() == "0")
                        {
                            lbltypesedit.Text = "Fail";
                            txtDebitQty.Enabled = false;
                        }
                        else
                        {
                            lbltypesedit.Text = "N/A";
                        }
                        lblAmountEdit.Text = (DebitQuantity * DebitRate).ToString("N0");

                        HiddenField hdnAmountEdit = (HiddenField)e.Row.FindControl("hdnAmountEdit");
                        hdnAmountEdit.Value = (DebitQuantity * DebitRate).ToString();

                        TotalAmount = TotalAmount + Convert.ToDouble(hdnAmountEdit.Value);
                    }
                }
            }
        }

        private void CalculateGrandTotal()
        {
            double IGSTAmount = 0, CGSTAmount = 0, SGSTAmount = 0;

            if (txtIGST.Text != "")
            {
                IGSTAmount = Convert.ToDouble(Math.Round((TotalAmount * Convert.ToDouble(txtIGST.Text)) / 100, 1, MidpointRounding.AwayFromZero));
                lblIGSTAmount.Text = IGSTAmount.ToString("N0");
                hdnIGSTAmount.Value = IGSTAmount.ToString();

            }
            if (IGSTAmount <= 0)
            {
                lblIGSTAmount.Text = "";
                lbliGSTCurrency.Text = "";
                lbliGSTCurrency.Attributes.Remove("class");
            }
            //code add by bharat on 16-Sep-19
            if (lblIGSTAmount.Text != "")
            {
                lbliGSTCurrency.Attributes.Add("class", "indianCurr");
            }
            //end
            if (txtCGST.Text != "")
            {
                CGSTAmount = Convert.ToDouble(Math.Round((TotalAmount * Convert.ToDouble(txtCGST.Text)) / 100, 1, MidpointRounding.AwayFromZero));
                lblCGSTAmount.Text = CGSTAmount.ToString();
                hdnCGSTAmount.Value = CGSTAmount.ToString();
            }
            if (CGSTAmount <= 0)
            {
                lblCGSTAmount.Text = "";
                lblcgrstCurr.Text = "";
                lblcgrstCurr.Attributes.Remove("class");
            }
            //code add by bharat on 16-Sep-19
            if (lblCGSTAmount.Text != "")
            {
                lblcgrstCurr.Attributes.Add("class", "indianCurr");
            }
            //end
            if (txtSGST.Text != "")
            {
                SGSTAmount = Convert.ToDouble(Math.Round((TotalAmount * Convert.ToDouble(txtSGST.Text)) / 100, 1, MidpointRounding.AwayFromZero));
                lblSGSTAmount.Text = SGSTAmount.ToString();
                hdnSGSTAmount.Value = SGSTAmount.ToString();
            }
            if (SGSTAmount <= 0)
            {
                lblSGSTAmount.Text = "";
                lblISGSTCurr.Text = "";
                lblISGSTCurr.Attributes.Remove("class");
            }
            //code add by bharat on 16-Sep-19
            if (lblSGSTAmount.Text != "")
            {
                lblISGSTCurr.Attributes.Add("class", "indianCurr");
            }
            //end

            //if (TotalAmount > 0)
            //{
            hdnTotalAmount.Value = TotalAmount.ToString();
            var GrandTotalAmount = TotalAmount + IGSTAmount + CGSTAmount + SGSTAmount;
            lblGrandTotalAmount.Text = GrandTotalAmount.ToString("N0");
            hdnGrandTotalAmount.Value = GrandTotalAmount.ToString();
            // }

            if (lblGrandTotalAmount.Text != "")
            {
                lblGranCurr.Attributes.Add("class", "indianCurr");
            }
            //end
            if (lblGrandTotalAmount.Text != "")
            {
                lblrs.Text = NumWordsWrapper(Convert.ToDouble(lblGrandTotalAmount.Text.Trim()));
                //lblrs.Text = FirstLetterToUpper(lblrs.Text);
            }
            if (GrandTotalAmount <= 0)
            {
                lblGrandTotalAmount.Text = "";
                lblGranCurr.Text = "";
                lblGrandTotalAmount.Attributes.Remove("class");
                lblGranCurr.Attributes.Remove("class");
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            int TotalAmount = hdnGrandTotalAmount.Value == "" ? 0 : Convert.ToInt32(Math.Round(Convert.ToDecimal(hdnGrandTotalAmount.Value), 0));
            if (TotalAmount > 0)
            {
                FabricDebitNoteCls objAccessoryDebitNote = new FabricDebitNoteCls();
                objAccessoryDebitNote.SupplierPoId = SupplierPoId;
                objAccessoryDebitNote.DebitNoteId = hdnDebitnotid.Value == "" ? -1 : int.Parse(hdnDebitnotid.Value);
                objAccessoryDebitNote.DebitNoteNumber = lblDebitNo.Text;
                objAccessoryDebitNote.DebitNoteDate = txtDate.Text != "" ? DateTime.ParseExact(txtDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
                objAccessoryDebitNote.PartyBillId = Convert.ToInt32(ddlBillNo.SelectedValue);
                objAccessoryDebitNote.ReturnChallanNumber = txtReturnChallan.Text;
                objAccessoryDebitNote.ChallanDate = txtreturndate.Text != "" ? DateTime.ParseExact(txtreturndate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
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
                    objAccessoryDebitNote.QtyCheckedBy = 0;
                    objAccessoryDebitNote.QtyCheckedDate = DateTime.MinValue;
                }
                List<FabricDebitNoteParticulars> objDebitNoteParticularsList = new List<FabricDebitNoteParticulars>();

                if (grdAccessoryDebitNot.Rows.Count == 0)
                {
                    Control control = null;
                    control = grdAccessoryDebitNot.Controls[0].Controls[0];
                    if ((Label)control.FindControl("txtDebitParticular_Empty") != null)
                    {
                        Label txtDebitParticular_Empty = (Label)control.FindControl("txtDebitParticular_Empty");
                        Label txtDebitQty_Empty = (Label)control.FindControl("txtDebitQty_Empty");
                        Label txtDebitRate_Empty = (Label)control.FindControl("txtDebitRate_Empty");


                        FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();

                        objDebitNoteParticulars.ParticularName = txtDebitParticular_Empty.Text;
                        objDebitNoteParticulars.DebitQuantity = txtDebitQty_Empty.Text == "" ? 0 : Convert.ToInt32(txtDebitQty_Empty.Text);
                        objDebitNoteParticulars.DebitRate = txtDebitRate_Empty.Text == "" ? 0 : Convert.ToDouble(txtDebitRate_Empty.Text);
                        objDebitNoteParticulars.IsExtraQty = -1;
                        objDebitNoteParticulars.DebitNoteParticularId = -1;
                        objDebitNoteParticulars.Fab_DebitNote_SRVID = -1;

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


                        HiddenField hdntypes = (HiddenField)grdAccessoryDebitNot.Rows[i].FindControl("hdntypes");
                        HiddenField hdnId = (HiddenField)grdAccessoryDebitNot.Rows[i].FindControl("hdnId");
                        HiddenField hdnsrvid = (HiddenField)grdAccessoryDebitNot.Rows[i].FindControl("hdnsrvid");

                        FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();

                        objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
                        objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToInt32(lblDebitQty.Text.Replace(",", ""));
                        objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
                        objDebitNoteParticulars.DebitNoteParticularId = hdnId.Value == "" ? -1 : Convert.ToInt32(hdnId.Value);
                        objDebitNoteParticulars.IsExtraQty = Convert.ToInt32(hdntypes.Value);
                        objDebitNoteParticularsList.Add(objDebitNoteParticulars);
                        objDebitNoteParticulars.Fab_DebitNote_SRVID = Convert.ToInt32(hdnsrvid.Value);
                    }

                    Label txtDebitParticur_Footer = (Label)grdAccessoryDebitNot.FooterRow.FindControl("txtDebitParticur_Footer");
                    Label txtDebitQty_Footer = (Label)grdAccessoryDebitNot.FooterRow.FindControl("txtDebitQty_Footer");
                    Label txtDebitRate_Footer = (Label)grdAccessoryDebitNot.FooterRow.FindControl("txtDebitRate_Footer");
                    if ((txtDebitParticur_Footer.Text != "") && (txtDebitQty_Footer.Text != "") && (txtDebitRate_Footer.Text != ""))
                    {
                        FabricDebitNoteParticulars objDebitNoteParticulars = new FabricDebitNoteParticulars();

                        objDebitNoteParticulars.ParticularName = txtDebitParticur_Footer.Text;
                        objDebitNoteParticulars.DebitQuantity = txtDebitQty_Footer.Text == "" ? 0 : Convert.ToInt32(txtDebitQty_Footer.Text);
                        objDebitNoteParticulars.DebitRate = txtDebitRate_Footer.Text == "" ? 0 : Convert.ToDouble(txtDebitRate_Footer.Text);
                        objDebitNoteParticulars.DebitNoteParticularId = -1;
                        objDebitNoteParticulars.IsExtraQty = -1;
                        objDebitNoteParticulars.Fab_DebitNote_SRVID = -1;

                        objDebitNoteParticularsList.Add(objDebitNoteParticulars);
                    }
                }

                objAccessoryDebitNote.FabricDebitNoteParticularsList = objDebitNoteParticularsList;

                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                int iSave = objFabricWorking.Save_Accessory_DebitNote(objAccessoryDebitNote, UserId);

                if (iSave > 0)
                {
                    Session["EmailDebitID"] = DebitNoteId;
                    Session["EmailPoID"] = SupplierPoId;
                    string html = (string)Session["compareLeftContent"];
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
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

        protected void grdAccessoryDebitNot_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {


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
                Label txtDebitParticur = (Label)row.FindControl("txtDebitParticur");
                Label txtDebitQty = (Label)row.FindControl("txtDebitQty");
                Label txtDebitRate = (Label)row.FindControl("txtDebitRate");
                HiddenField hdntypesedit = (HiddenField)row.FindControl("hdntypesedit");

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
                    HiddenField hdntypes = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdntypes");
                    HiddenField hdnsrvid = (HiddenField)grdAccessoryDebitNot.Rows[AccNo].FindControl("hdnsrvid");
                    if (hdnId != null && lblDebitRate != null)
                    {
                        objDebitNoteParticulars.DebitNoteParticularId = hdnId.Value == "" ? 0 : Convert.ToInt32(hdnId.Value);
                        objDebitNoteParticulars.ParticularName = lblDebitParticur.Text;
                        objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToInt32(lblDebitQty.Text.Replace(",", ""));
                        objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
                        objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);
                        objDebitNoteParticulars.IsExtraQty = hdntypes.Value == "" ? -1 : Convert.ToInt32(hdntypes.Value);
                        objDebitNoteParticulars.Fab_DebitNote_SRVID = Convert.ToInt32(hdnsrvid.Value);
                        MaxId = MaxId + AccNo + 1;
                    }
                    else
                    {


                        HiddenField hdnIdSelected = (HiddenField)row.FindControl("hdnId");
                        HiddenField hdnsrvidedit = (HiddenField)row.FindControl("hdnsrvid");
                        DebitNoteId = hdnDebitnotid.Value == "" ? -1 : Convert.ToInt32(hdnDebitnotid.Value);

                        objDebitNoteParticulars.DebitNoteId = DebitNoteId;
                        objDebitNoteParticulars.DebitNoteParticularId = hdnIdEdit.Value == "" ? 0 : Convert.ToInt32(hdnIdEdit.Value);
                        objDebitNoteParticulars.ParticularName = txtDebitParticur.Text;
                        objDebitNoteParticulars.DebitQuantity = txtDebitQty.Text == "" ? 0 : Convert.ToInt32(txtDebitQty.Text);
                        objDebitNoteParticulars.DebitRate = txtDebitRate.Text == "" ? 0 : Convert.ToDouble(Math.Round(Convert.ToDouble(txtDebitRate.Text), 0));
                        objDebitNoteParticulars.Amount = Convert.ToDouble(Math.Round((Convert.ToDouble(objDebitNoteParticulars.DebitQuantity) * objDebitNoteParticulars.DebitRate), 0));
                        objDebitNoteParticulars.IsExtraQty = hdntypesedit.Value == "" ? -1 : Convert.ToInt32(hdntypesedit.Value);
                        objDebitNoteParticulars.Fab_DebitNote_SRVID = Convert.ToInt32(hdnsrvidedit.Value);

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
                    objDebitNoteParticulars.DebitQuantity = lblDebitQty.Text == "" ? 0 : Convert.ToInt32(lblDebitQty.Text.Replace(",", ""));
                    objDebitNoteParticulars.DebitRate = lblDebitRate.Text == "" ? 0 : Convert.ToDouble(lblDebitRate.Text);
                    objDebitNoteParticulars.Amount = hdnAmount.Value == "" ? 0 : Convert.ToDouble(hdnAmount.Value);

                    MaxId = MaxId + AccNo + 1;
                }
                DebitNoteParticularsList.Add(objDebitNoteParticulars);
            }

            grdAccessoryDebitNot.DataSource = DebitNoteParticularsList;
            grdAccessoryDebitNot.DataBind();

            // BindData(1);
            CalculateGrandTotal();
        }
        //added by abhishek==========================================================;;
        static String NumWordsWrapper(double n)
        {

            string words = "";
            double intPart;
            double decPart = 0;
            if (n == 0)
                return "zero";
            try
            {
                string[] splitter = n.ToString("N1").Split('.');
                intPart = double.Parse(splitter[0]);
                decPart = double.Parse(splitter[1]);
            }
            catch
            {
                intPart = n;
            }

            words = NumWords(intPart);

            if (decPart > 0)
            {
                if (words != "")
                    words += " and ";
                int counter = decPart.ToString().Length;
                switch (counter)
                {
                    case 1: words += NumWords(decPart) + " tenths"; break;
                    case 2: words += NumWords(decPart) + " hundredths"; break;
                    case 3: words += NumWords(decPart) + " thousandths"; break;
                    case 4: words += NumWords(decPart) + " ten-thousandths"; break;
                    case 5: words += NumWords(decPart) + " hundred-thousandths"; break;
                    case 6: words += NumWords(decPart) + " millionths"; break;
                    case 7: words += NumWords(decPart) + " ten-millionths"; break;
                }
            }
            return words;
        }
        public string FirstLetterToUpper(string str)
        {
            if (str == null)
                return null;

            if (str.Length > 1)
                return char.ToUpper(str[0]) + str.Substring(1);

            return str.ToUpper();
        }
        static String NumWords(double n) //converts double to words
        {
            string[] numbersArr = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] tensArr = new string[] { "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninty" };
            string[] suffixesArr = new string[] { "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", "Quattuordecillion", "Quindecillion", "Sexdecillion", "Septdecillion", "Octodecillion", "Novemdecillion", "Vigintillion" };
            string words = "";

            bool tens = false;

            if (n < 0)
            {
                words += "negative ";
                n *= -1;
            }

            int power = (suffixesArr.Length + 1) * 3;

            while (power > 3)
            {
                double pow = Math.Pow(10, power);
                if (n >= pow)
                {
                    if (n % pow > 0)
                    {
                        words += NumWords(Math.Floor(n / pow)) + " " + suffixesArr[(power / 3) - 1] + ", ";
                    }
                    else if (n % pow == 0)
                    {
                        words += NumWords(Math.Floor(n / pow)) + " " + suffixesArr[(power / 3) - 1];
                    }
                    n %= pow;
                }
                power -= 3;
            }
            if (n >= 1000)
            {
                if (n % 1000 > 0) words += NumWords(Math.Floor(n / 1000)) + " thousand, ";
                else words += NumWords(Math.Floor(n / 1000)) + " thousand";
                n %= 1000;
            }
            if (0 <= n && n <= 999)
            {
                if ((int)n / 100 > 0)
                {
                    words += NumWords(Math.Floor(n / 100)) + " hundred";
                    n %= 100;
                }
                if ((int)n / 10 > 1)
                {
                    if (words != "")
                        words += " ";
                    words += tensArr[(int)n / 10 - 2];
                    tens = true;
                    n %= 10;
                }

                if (n < 20 && n > 0)
                {
                    if (words != "" && tens == false)
                        words += " ";
                    words += (tens ? "-" + numbersArr[(int)n - 1] : numbersArr[(int)n - 1]);
                    n -= Math.Floor(n);
                }
            }

            return words;

        }
    }
}