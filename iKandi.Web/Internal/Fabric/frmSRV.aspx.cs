using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.Common;
using iKandi.Web.Components;
using System.Collections.Generic;
using iKandi.BLL;



namespace iKandi.Web.Internal.Fabric
{
    public partial class frmSRV : System.Web.UI.Page
    {
        iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();
        FabricController fabobj = new FabricController();
        InlinePPM inlinePPM = new InlinePPM();


        public int PoDetailID
        {
            get;
            set;
        }

        public int SrvId
        {
            get;
            set;
        }
        public int Challan_ID
        {
            get;
            set;
        }
        public string Fabtype
        {
            get;
            set;
        }
        public static int SupplierMasterID
        {
            get;
            set;
        }

        public static int postatus
        {
            get;
            set;
        }
        static InlinePPMOrderContract SrvDetails;
        protected void Page_Load(object sender, EventArgs e)
        {

            GetQueryString();

            if (!IsPostBack)
            {
                BindUnit();
                this.txtSrvDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
                BindHistorySection();

                DataTable dtstatus = fabobj.GetRaisedPOWorkingDetails("GETPOSTATUS", "", PoDetailID).Tables[0];
                postatus = Convert.ToInt32(dtstatus.Rows[0]["postatus"].ToString());
                if ((FabricPOStatus)Convert.ToInt32(dtstatus.Rows[0]["postatus"].ToString()) == FabricPOStatus.Cancel || (FabricPOStatus)Convert.ToInt32(dtstatus.Rows[0]["postatus"].ToString()) == FabricPOStatus.Close)
                {
                    ddlunitname.Enabled = false;

                    txtPartyChallanNo.Enabled = false;
                    txtGateEntryNo.Enabled = false;
                    ddlunitname.Enabled = false;

                    //chkQtyCheckedBy.Enabled = false;
                    chkStoreIncharge.Enabled = false;
                    srvgrid.Enabled = false;
                    //tblpartysection.Visible = true;
                    grdassociatedbill.Enabled = true;
                    btnSrvSubmit.Visible = true;
                    foreach (Control c in Page.Controls)
                    {
                        foreach (Control ctrl in c.Controls)
                        {
                            if (ctrl is TextBox)
                                ((TextBox)ctrl).Enabled = false;
                        }
                    }
                }
                // Added By Surendra on 04 Jan 2021 for hide party bill section if fresh srv then always hide..
                if (Request.QueryString["Challan_ID"] == null)
                {
                    //tblpartysection.Visible = false;
                }
                // end
            }
        }
        private void BindUnit()
        {
            DropdownHelper.BindUnitReports(ddlunitname);
            ddlunitname.SelectedValue = "11";// default unit C45-46;
        }

        protected void btnshow_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmWorkingOnRaisedPO.aspx");
        }

        private void GetQueryString()
        {
            if (null != Request.QueryString["Fabtype"])
            {
                Fabtype = Request.QueryString["Fabtype"].ToString();
            }
            if (null != Request.QueryString["PoDetailID"])
            {
                PoDetailID = Convert.ToInt32(Request.QueryString["PoDetailID"].ToString());
                HttpContext.Current.Session["SupplierPO_Id"] = PoDetailID.ToString();
                HttpContext.Current.Session["imgurlsset"] = "../../images/plus_icon.gif";
            }
            if (null != Request.QueryString["Challan_ID"])
            {
                Challan_ID = Convert.ToInt32(Request.QueryString["Challan_ID"].ToString());
                HttpContext.Current.Session["SupplierPO_Id"] = Challan_ID.ToString();
                HttpContext.Current.Session["imgurlsset"] = "../../images/plus_icon.gif";
            }
        }

        protected void txtpartybillno_TextChanged(object sender, EventArgs e)
        {

        }

        private void BindHistorySection()
        {

            if (Challan_ID == 0)
            {
                inlinePPM = obj_ProcessController.Get_Srv_details(PoDetailID, "BIPLAddress2", "empty");
                DataTable dtvoucher = obj_ProcessController.getmaxvouchernumber(PoDetailID, "BIPLAddress2", "empty", 0, "", SupplierMasterID);
                lblReceivingVoucherNo.Text = dtvoucher.Rows[0]["Receiving_Voucher_No"].ToString();
            }
            else
                inlinePPM = obj_ProcessController.Get_Srv_details(Challan_ID, "BIPLAddress2", "ChallanType");

            InlinePPMOrderContract SrvDetail = new InlinePPMOrderContract();

            DataTable dt = obj_ProcessController.Getbipladdress(PoDetailID, "BIPLAddress4", "POType");
            divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();

            if (inlinePPM.OrderContracts.Count > 0)
            {

                srvgrid.DataSource = inlinePPM.OrderContracts;
                srvgrid.DataBind();

                decimal ReceivedQty = Convert.ToDecimal(inlinePPM.OrderContracts[0].ReceivedQty);
                decimal ActualReceivedQty = Convert.ToDecimal(inlinePPM.OrderContracts[0].ActualReceivedQty);
                if (ActualReceivedQty > 0 && ReceivedQty != ActualReceivedQty) { tableActualSRV.Visible = true; } else { tableActualSRV.Visible = false; }
                lblActualSrv.Text = Convert.ToDecimal(inlinePPM.OrderContracts[0].ActualReceivedQty).ToString("N0");


                SrvDetail = inlinePPM.OrderContracts[0];
                hdnpartychallanQue.Value = SrvDetail.PartyChallanQue;
                lblReceivingVoucherNo.Text = SrvDetail.Receiving_Voucher_No.ToString();


                if (SrvDetail.SRVDate.Year != 1)
                    txtSrvDate.Text = SrvDetail.SRVDate.ToString("dd MMM yy (ddd)");

                lblSupllierName.Text = SrvDetail.SupplierName.ToString();
                txtPartyChallanNo.Text = SrvDetail.PartyChallanNumber.ToString();

                ddlunitname.SelectedValue = SrvDetail.ReceivedUnit.ToString();
                txtGateEntryNo.Text = SrvDetail.GateNumber.ToString();
                SupplierMasterID = SrvDetail.SupplierMasterID;

                if (SrvDetail.StoreInchargeId > 0)
                {
                    divCheckBox1.Visible = false;
                    divSignature1.Visible = true;
                    foreach (var user in ApplicationHelper.Users)
                    {
                        if (SrvDetail.StoreInchargeId == user.UserID)
                        {
                            lblInchargeName.Text = user.FirstName + " " + user.LastName;
                            imgInchargeSig.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                            lblCheckedInchargeDate.Text = SrvDetail.StoreInchargeCheckedDate.ToString("dd MMM yy (ddd)");
                        }
                    }
                }

                //if (SrvDetail.QtyCheckedBy > 0)
                //{
                //    divCheckBox2.Visible = false;
                //    divSignature2.Visible = true;
                //    foreach (var user in ApplicationHelper.Users)
                //    {
                //        if (SrvDetail.QtyCheckedBy == user.UserID)
                //        {
                //            lblCheckerName.Text = user.FirstName + " " + user.LastName;
                //            imgCheckerSig.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg"; ;
                //            lblCheckedDate.Text = SrvDetail.QtyCheckedDate.ToString("dd MMM yy (ddd)");
                //        }
                //    }
                //}

                //txtpartybillno.Text = SrvDetail.PartyBillNumber.ToString();

                //commented below code on 2023-01-31

                //if (Challan_ID != 0)
                //{
                //    lblPartyBillNo.Text = SrvDetail.PartyBillNumber.ToString();

                //    txtpartybillno.Text = SrvDetail.PartyBillNumber.ToString();
                //    hdnPartyBillId.Value = SrvDetail.PartyBillId.ToString();

                //    txtPartyBillDate.Text = SrvDetail.Billdate.ToString("dd MMM yy (ddd)");
                //    hdnPartyBillDate.Value = SrvDetail.Billdate.ToString("dd MMM yy (ddd)");

                //    txtAmount.Text = SrvDetail.PartyAmount.ToString();
                //    hdnAmount.Value = SrvDetail.PartyAmount.ToString();

                //    lblAmount.Text = SrvDetail.PartyAmount.ToString();

                //    if (txtPartyBillDate.Text == "01 Jan 01 (Mon)")
                //    {
                //        txtPartyBillDate.Text = "";
                //    }

                //    lblBillDate.Text = txtPartyBillDate.Text;
                //    txtAmount.Text = SrvDetail.PartyAmount.ToString();
                //}

                
                //new work start girish
                SrvId = Convert.ToInt32(lblReceivingVoucherNo.Text);
                String BillNumber="";

                DataTable DataToBindIngrdbill = obj_ProcessController.getDataToBindGridWithId_grdbill(PoDetailID, SrvId, "", "Add_PartyBill");
                if (DataToBindIngrdbill.Rows.Count > 0)
                {
                    grdbill.DataSource = DataToBindIngrdbill;
                    grdbill.DataBind();
                    DataRow firstRow = DataToBindIngrdbill.Rows[0];
                    BillNumber = firstRow["PartyBillNo"].ToString();
                    lnkpartybill.Visible = true;
                }                

                DataTable dtbilldetails = obj_ProcessController.getDataToBindGridWithId_grdbill(PoDetailID, SrvId, BillNumber, "ShowSRV_List");


                //int PartyBillId = hdnPartyBillId.Value == "" ? -1 : Convert.ToInt32(hdnPartyBillId.Value);

                //DataTable dtbilldetails = obj_ProcessController.getmaxvouchernumber(PoDetailID, "", "BILL_DETAIL", PartyBillId, txtpartybillno.Text.Trim(), SupplierMasterID);
                if (dtbilldetails.Rows.Count > 0)
                {
                    grdPartyBill.DataSource = dtbilldetails;
                    grdPartyBill.DataBind();

                    //for (int i = 0; i < grdPartyBill.Rows.Count; i++)
                    //{
                    //    Label lblSrvNo = (Label)grdPartyBill.Rows[i].FindControl("lblSrvNo");
                    //    Label lblChallanNo = (Label)grdPartyBill.Rows[i].FindControl("lblChallanNo");
                    //    CheckBox chkSelect = (CheckBox)grdPartyBill.Rows[i].FindControl("chkSelect");

                    //    //if (Challan_ID <= 0)
                    //    //{
                    //    //    tblpartysection.Disabled = true;
                    //    //    lnkpartybill.Attributes.Remove("onclick");
                    //    //    break;
                    //    //}
                    //}
                }
                //else
                //{
                //tblpartysection.Visible = false;
                //}

                //commented below on 2023-01-31

                //if (txtpartybillno.Text != "")
                //{
                //    txtpartybillno.Enabled = false;
                //    txtPartyBillDate.Enabled = false;
                //    txtAmount.Enabled = false;
                //}


                //DataTable dtbill = obj_ProcessController.getmaxvouchernumber(PoDetailID, "", "ASSOCIATEDBILLNO", PartyBillId, txtpartybillno.Text.Trim(), SupplierMasterID);
                //if (dtbill.Rows.Count > 0)
                //{
                //    grdassociatedbill.DataSource = dtbill;
                //    grdassociatedbill.DataBind();
                //}
                //else
                //{
                //    grdassociatedbill.Visible = false;
                //}

                //new work end girish

            }

            chkStoreIncharge.Enabled = true;
            //chkQtyCheckedBy.Enabled = true;
        }

        //new work start Girish

        protected void RefreshGridWithID_grdPartyBill(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            if (chk != null)
            {
                HiddenField hdnBillNumber = chk.Parent.FindControl("hdnBillNumber") as HiddenField;

                if (hdnBillNumber != null)
                {
                    string BillNumber = hdnBillNumber.Value;
                    SrvId = Convert.ToInt32(lblReceivingVoucherNo.Text);

                    if (chk.Checked)
                    {
                        DataTable dtbilldetails = obj_ProcessController.getDataToBindGridWithId_grdbill(PoDetailID, SrvId, BillNumber, "ShowSRV_List");
                        if (dtbilldetails.Rows.Count > 0)
                        {                           
                            grdPartyBill.DataSource = dtbilldetails;
                            grdPartyBill.DataBind();
                        }

                        foreach (GridViewRow row in grdbill.Rows)
                        {
                            CheckBox cb = row.FindControl("chkSelectBill") as CheckBox;
                            TextBox txtBillNumber = row.FindControl("txtBillNumber") as TextBox;
                            TextBox txtBillDate = row.FindControl("txtBillDate") as TextBox;
                            HiddenField CheckForNewRow = row.FindControl("CheckForNewRow") as HiddenField;
                            HiddenField hdnBillDateEnabledValue = row.FindControl("hdnBillDateEnabledValue") as HiddenField;  


                            if (cb != null && cb != chk)
                            {
                                cb.Checked = false;
                                txtBillNumber.ReadOnly = true;
                                hdnBillDateEnabledValue.Value = "false";
                            }
                            else if (cb == chk)
                            {
                                if (txtBillNumber != null && cb.Checked && (CheckForNewRow.Value.ToLower() == "TRUE".ToLower()))
                                {
                                    txtBillNumber.ReadOnly = false;
                                    txtBillNumber.Attributes.Add("class", "costing-style");
                                }                                
                            }
                        }                        
                    }
                    else
                    {
                        grdPartyBill.DataSource = null;
                        grdPartyBill.DataBind();
                    }
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "PartyBillNo", "PartyBillNo()", true);
                }
            }
        }
        protected void grdbill_RowDataBound(object sender, GridViewRowEventArgs e)
        {           
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtBillNumber = (TextBox)e.Row.FindControl("txtBillNumber");

                CheckBox chkSelectBill = (CheckBox)e.Row.FindControl("chkSelectBill");

                if (!(txtBillNumber.ReadOnly))
                {
                    txtBillNumber.Attributes.Add("class", "costing-style");
                }

                if (!(chkSelectBill.Visible))
                {
                    grdbill.Columns[0].Visible = false;
                }
                else
                {
                    grdbill.Columns[0].Visible  = true;
                }
            }
        }
        //new work start Girish


        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void srvgrid_RowDatabound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SrvDetails = inlinePPM.OrderContracts[e.Row.RowIndex];
                DropDownList ddlUnit = e.Row.FindControl("ddlUnit") as DropDownList;
                TextBox txtReceivedqty = e.Row.FindControl("txtReceivedqty") as TextBox;
                Label lbldefualtunitreceiveQty = e.Row.FindControl("lbldefualtunitreceiveQty") as Label;

                Label lblColorPrint = e.Row.FindControl("lblColorPrint") as Label;
                Label lblunitconvert = e.Row.FindControl("lblunitconvert") as Label;
                Label lblUnit = e.Row.FindControl("lblUnit") as Label;
                HiddenField hdnReceivedqty = e.Row.FindControl("hdnReceivedqty") as HiddenField;

                if (Fabtype.ToLower() == "Gerige".ToLower())
                {
                    lblColorPrint.Text = "N/A";
                }
                //lblUnit.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(SrvDetails.DefaultUnit));
                if (SrvDetails != null)
                {

                    if (SrvDetails.DefaultUnit != SrvDetails.ConverToUnit)
                    {

                        txtReceivedqty.Text = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ReceivedQty").ToString()) * Convert.ToDecimal(SrvDetails.ConversionValue)), 0).ToString("N0");
                        hdnReceivedqty.Value = Math.Round((Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ReceivedQty").ToString()) * Convert.ToDecimal(SrvDetails.ConversionValue)), 0).ToString();
                        lblunitconvert.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(SrvDetails.ConverToUnit));
                    }
                    else
                    {
                        lbldefualtunitreceiveQty.Style.Add("display", "none;");
                        lblunitconvert.Text = Enum.GetName(typeof(FabricUnit), Convert.ToInt32(SrvDetails.ConverToUnit));//new line                        
                        lblUnit.Style.Add("display", "none;");//new line
                    }
                }
                if (SrvDetails.IsFabricGMCheckDone == 1)
                {
                    if (Challan_ID > 0)
                    {
                        txtReceivedqty.Enabled = false;
                    }
                }
                if (txtReceivedqty.Text != "")
                {
                    if (Convert.ToDecimal(txtReceivedqty.Text) <= 0)
                    {
                        //txtReceivedqty.Text = "";
                    }
                }
                if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ReceivedQty").ToString()) <= 0)
                {
                    lblUnit.Text = "";
                    lbldefualtunitreceiveQty.Text = "";
                }
            }

        }

        // private int GetUnitIndex(string Unit)
        // {
        //     switch (Unit)
        //     {

        //         case "KG":
        //             return 0;
        //         case "Meter":
        //             return 1;



        //}
        //     return 0;
        // }
        //protected void btnhideclick_SRVClivk(object sender, EventArgs e)
        //{
        //    //int PartyBillId = hdnPartyBillId.Value == "" ? -1 : Convert.ToInt32(hdnPartyBillId.Value);
        //    DataTable dtcheck = obj_ProcessController.getmaxvouchernumber(PoDetailID, "", "CHECKSUPPLIER", PartyBillId, txtpartybillno.Text.Trim(), SupplierMasterID);

        //    if (dtcheck.Rows.Count > 0)
        //    {
        //        if (dtcheck.Rows[0]["Result"].ToString() == "NOTVALID")
        //        {
        //            txtAmount.Text = "";
        //            //hdnAmount.Value = "";

        //            txtpartybillno.Text = "";

        //            txtPartyBillDate.Text = "";
        //            //hdnPartyBillDate.Value = "";

        //            ClientScript.RegisterStartupScript(GetType(), "hwa", "PartyBillNo();", true);
        //            ShowAlert("Entered bill no. already associated with diff. supplier");
        //            return;
        //        }
        //    }

        //    DataTable dtbilldetails = obj_ProcessController.getmaxvouchernumber(PoDetailID, "", "BILL_DETAIL", PartyBillId, txtpartybillno.Text.Trim(), SupplierMasterID);
        //    if (dtbilldetails.Rows.Count > 0)
        //    {
        //        grdPartyBill.DataSource = dtbilldetails;
        //        grdPartyBill.DataBind();
        //    }
        //    ClientScript.RegisterStartupScript(GetType(), "hwa", "PartyBillNo();", true);

        //    DataTable dtbill = obj_ProcessController.getmaxvouchernumber(PoDetailID, "", "ASSOCIATEDBILLNO", PartyBillId, txtpartybillno.Text.Trim(), SupplierMasterID);
        //    if (dtbill.Rows.Count > 0)
        //    {
        //        grdassociatedbill.DataSource = dtbill;
        //        grdassociatedbill.DataBind();

        //        grdassociatedbill.Visible = true;
        //    }
        //    else
        //    {
        //        grdassociatedbill.Visible = false;
        //    }

        //}

        protected void btn_SRVClivk(object sender, EventArgs e)
        {
            InlinePPMOrderContract SrvDetail = new InlinePPMOrderContract();
            //string GateEntryNo = txtGateEntryNo.Text;
            //string UnitName = txtUnitName.Text;
            //string PartyBillNo = txtPartyBillNo.Text;
            //string PartyChallanNo = txtPartyChallanNo.Text;
            if (Challan_ID == 0)
            {
                SrvDetail.PoDetailID = PoDetailID;
                SrvDetail.SRV_Flag = "POType";
            }
            else
            {
                //SrvDetail.PoDetailID = Challan_ID;
                SrvDetail.PoDetailID = PoDetailID;
                SrvDetail.SRV_Flag = "ChallanType";
            }
            //SrvDetails.SignFlag = chkStoreIncharge.Checked ? "Signed" : "NotSigned";
            SrvDetail.Receiving_Voucher_No = lblReceivingVoucherNo.Text;
            SrvDetail.GateNumber = txtGateEntryNo.Text;
            //SrvDetail.PartyBillNumber = txtpartybillno.Text;
            SrvDetail.PartyChallanNumber = txtPartyChallanNo.Text;
            SrvDetail.ReceivedUnit = ddlunitname.SelectedValue;
            SrvDetail.SRVDate = txtSrvDate.Text != "" ? DateTime.ParseExact(txtSrvDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
            SrvDetail.SrvMasterID = Challan_ID;
            if (divCheckBox1.Visible == true && chkStoreIncharge.Checked == true)
            {
                SrvDetail.StoreInchargeId = ApplicationHelper.LoggedInUser.UserData.UserID;
                SrvDetail.StoreInchargeCheckedDate = DateTime.Now;
            }
            else
            {
                SrvDetail.StoreInchargeId = 0;
                SrvDetail.StoreInchargeCheckedDate = DateTime.MinValue;
            }

            //if (divCheckBox2.Visible == true && chkQtyCheckedBy.Checked == true)
            //{
            //    SrvDetail.QtyCheckedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
            //    SrvDetail.QtyCheckedDate = DateTime.Now;
            //}
            //else
            //{
            //    SrvDetail.QtyCheckedBy = 0;
            //    SrvDetail.QtyCheckedDate = DateTime.MinValue;
            //}

            foreach (GridViewRow row in srvgrid.Rows)
            {
                if (row.RowType != DataControlRowType.DataRow) continue;

                TextBox Receivedqty = row.FindControl("txtReceivedqty") as TextBox;
                TextBox SrvRemark = row.FindControl("txtRemark") as TextBox;
                Label lbldefualtunitreceiveQty = row.FindControl("lbldefualtunitreceiveQty") as Label;
                if (SrvDetails.DefaultUnit != SrvDetails.ConverToUnit)
                {
                    //SrvDetail.ReceivedQty = lbldefualtunitreceiveQty.Text.Replace(",", "");
                    SrvDetail.ReceivedQty = Math.Round((Convert.ToDecimal(Receivedqty.Text.Replace(",", "")) / Convert.ToDecimal(SrvDetails.ConversionValue)), 0).ToString();
                    // SrvDetail.ReceivedQty = Receivedqty.Text;
                }
                else
                {
                    SrvDetail.ReceivedQty = Receivedqty.Text;
                }

                // SrvDetail.ReceivedQty = Receivedqty.Text;
                SrvDetail.SRVRemarks = SrvRemark.Text;
            }
            SrvDetail.SignFlag = chkStoreIncharge.Checked ? "Signed" : "NotSigned";
            if (SrvDetail.SignFlag == "NotSigned")
            {
                SrvDetail.SignFlag = lblInchargeName.Text != "" ? "Signed" : "NotSigned";
            }

            //new work start Girish
            DateTime PartyBillDate = DateTime.MinValue;
            int Amount = 0;
            string PartyBillNumber = "";

            int isNeedToUpdate = 0;

            for (int i = 0; i < grdbill.Rows.Count; i++)
            {
                TextBox txtBillNumber = (TextBox)grdbill.Rows[i].FindControl("txtBillNumber");
                HiddenField hdnBillNumber = (HiddenField)grdbill.Rows[i].FindControl("hdnBillNumber");

                TextBox txtBillDate = (TextBox)grdbill.Rows[i].FindControl("txtBillDate");
                HiddenField hdnBillDate = (HiddenField)grdbill.Rows[i].FindControl("hdnBillDate");
                HiddenField hdnBillDateEnabledValue = (HiddenField)grdbill.Rows[i].FindControl("hdnBillDateEnabledValue");


                TextBox txtBillAmount = (TextBox)grdbill.Rows[i].FindControl("txtBillAmount");
                HiddenField hdnBillAmount = (HiddenField)grdbill.Rows[i].FindControl("hdnBillAmount");

                if (txtBillNumber.Enabled && (hdnBillDateEnabledValue.Value.ToLower() == "True".ToLower()))
                {
                    SrvDetail.PartyBillNumber = txtBillNumber.Text;
                    PartyBillNumber = txtBillNumber.Text;

                    if (txtBillDate.Enabled && !(txtBillDate.ReadOnly))
                        PartyBillDate = txtBillDate.Text != "" ? DateTime.ParseExact(txtBillDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;

                    else
                        PartyBillDate = hdnBillDate.Value != "" ? DateTime.ParseExact(hdnBillDate.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;

                    if (txtBillAmount.Enabled && !(txtBillDate.ReadOnly))
                        Amount = txtBillAmount.Text != "" ? Convert.ToInt32(txtBillAmount.Text.Replace(",", "")) : 0;

                    else
                        Amount = hdnBillAmount.Value != "" ? Convert.ToInt32(hdnBillAmount.Value.Replace(",", "")) : 0;

                    isNeedToUpdate = 1;
                }
                
            }

            this.obj_ProcessController.SaveSrv(SrvDetail);
            int x = 0;

            for (int i = 0; i < grdPartyBill.Rows.Count; i++)
            {
                Label lblSrvNo = (Label)grdPartyBill.Rows[i].FindControl("lblSrvNo");
                Label lblChallanNo = (Label)grdPartyBill.Rows[i].FindControl("lblChallanNo");
                CheckBox chkSelect = (CheckBox)grdPartyBill.Rows[i].FindControl("chkSelect");
                if (chkSelect.Checked)
                {
                    if (lblSrvNo.Text != "")
                    {
                        int SRV_Id = Convert.ToInt32(lblSrvNo.Text);
                        string PartyChallanNumber = lblChallanNo.Text;
                        bool IsChecked = chkSelect.Checked;

                        int SupplierPoId = PoDetailID;
                        //int PartyBillId = hdnPartyBillId.Value == "" ? -1 : Convert.ToInt32(hdnPartyBillId.Value);
                        //string PartyBillNumber = txtpartybillno.Text;
                        if (isNeedToUpdate == 1)
                        {
                            x = fabobj.Save_Fabric_Bill(SRV_Id, PartyChallanNumber, IsChecked, SupplierPoId, 0, PartyBillNumber, PartyBillDate, Amount, iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID);
                        }
                    }

                }
            }

            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "callparentpage(" + postatus + ")", true);

            //new work End Girish


        }

        protected void grdPartyBill_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }


        protected void grdassociatedbill_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();


                HeaderCell = new TableCell();
                HeaderCell.Text = "Other PO challan with same Bill No.";
                HeaderCell.Attributes.Add("class", "HeadeOtherPo");
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 3;
                //HeaderCell.Attributes.Add("class", "displaynone");
                //HeaderCell.Attributes.Add("style", "background:#b1acac");
                headerRow1.Cells.Add(HeaderCell);
                grdassociatedbill.Controls[0].Controls.AddAt(0, headerRow1);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                //if (chkSelect.Checked)
                //    chkSelect.Enabled = false;
            }

        }

    }

}