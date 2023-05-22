using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using iKandi.Web.Components;
using System.Data;

namespace iKandi.Web.Internal.Accessory
{
    public partial class AccessoryPoSrv : BasePage
    {
        public int SupplierPoId
        {
            get;
            set;
        }
        public int SrvId
        {
            get;
            set;
        }
        public static int SupplierMasterID
        {
            get;
            set;
        }
        public int Status
        {
            get;
            set;
        }
        iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();
        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
        protected void Page_Load(object sender, EventArgs e)
        {
            GetQueryString();
            if (!IsPostBack)
            {
                BindUnit();
                BindData();
                PartyBillNo();
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
            if (Request.QueryString["SrvId"] != null)
            {
                SrvId = Convert.ToInt32(Request.QueryString["SrvId"]);
            }
            else
            {
                SrvId = 0;
            }
            if (Request.QueryString["Status"] != null)
            {
                Status = Convert.ToInt32(Request.QueryString["Status"]);
            }
            else
            {
                Status = 0;
            }
        }

        private void BindUnit()
        {
            DropdownHelper.BindUnitReports(ddlunitname);
            ddlunitname.SelectedValue = "11";// default unit C45-46;
        }

        private void BindData()
        {
            AccessorySRV objAccessorySRV = objAccessoryWorking.Get_AccessorySRV(SupplierPoId, SrvId);
            if (SrvId > 0)
            {
                lblReivingVoucherNo.Text = objAccessorySRV.SRV_Id.ToString();
                txtSrvDate.Text = objAccessorySRV.SRVDate.ToString("dd MMM yy (ddd)");
                lblPartyBillNo.Text = objAccessorySRV.PartyBillNumber;
                lblBillDate.Text = objAccessorySRV.PartyBillDate == DateTime.MinValue ? "" : objAccessorySRV.PartyBillDate.ToString("dd MMM yy (ddd)");
                lblAmount.Text = objAccessorySRV.Amount > 0 ? objAccessorySRV.Amount.ToString("N0") : "";

                hdnPartyBillId.Value = objAccessorySRV.PartyBillId.ToString();
                txtPartyBillNo.Text = objAccessorySRV.PartyBillNumber.ToString();
                txtPartyBillDate.Text = objAccessorySRV.PartyBillDate == DateTime.MinValue ? "" : objAccessorySRV.PartyBillDate.ToString("dd MMM yy (ddd)");
                txtAmount.Text = objAccessorySRV.Amount > 0 ? objAccessorySRV.Amount.ToString("N0") : "";
                SupplierMasterID = objAccessorySRV.SupplierId;

                hdnReceivingVoucherNo.Value = objAccessorySRV.SRV_Id.ToString();
                hdnSrvDate.Value = objAccessorySRV.SRVDate.ToString("dd MMM yy (ddd)");
                hdnPartyChallanNo.Value = objAccessorySRV.PartyChallanNumber;
                hdnGateNo.Value = objAccessorySRV.GateNo.ToString();
                hdnRecievedUnit.Value = objAccessorySRV.ReceivedUnit.ToString();
                hdnRemart.Value = objAccessorySRV.srvRemark.ToString();
                hdnRate.Value = objAccessorySRV.FinalRate.ToString();

                tblpartysection.Visible = true;
                if (objAccessorySRV.IsFourPointCheckedByGM)
                {
                    hdnIsFourPointCheckedByGM.Value = "1";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "disablePage();", true);
                }
            }
            else
            {
                tblpartysection.Visible = false;

                lblReivingVoucherNo.Text = objAccessorySRV.Receiving_Voucher_No.ToString();
                txtSrvDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");
            }

            if (objAccessorySRV.QtyCheckedBy > 0)
            {
                divCheckBox2.Visible = false;
                divSignature2.Visible = true;
                foreach (var user in ApplicationHelper.Users)
                {
                    if (objAccessorySRV.QtyCheckedBy == user.UserID)
                    {
                        lblCheckerName.Text = user.FirstName + " " + user.LastName;
                        imgCheckerSig.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg"; ;
                        lblCheckedDate.Text = objAccessorySRV.QtyCheckedDate.ToString("dd MMM yy (ddd)");
                        txtSrvDate.Enabled=false;
                        txtPartyChallanNo.Enabled = false;
                        txtGateEntryNo.Enabled = false;
                        ddlunitname.Enabled = false;
                        txtReceivedqty.Enabled = false;
                        txtRemark.Enabled = false;
                    }
                }
            }
            lblSupllierName.Text = objAccessorySRV.SupplierName;
            txtPartyChallanNo.Text = objAccessorySRV.PartyChallanNumber;
            txtGateEntryNo.Text = objAccessorySRV.GateNo.ToString();

            if (objAccessorySRV.ReceivedUnit > 0)
                ddlunitname.SelectedValue = objAccessorySRV.ReceivedUnit.ToString();
            lblPoNo.Text = objAccessorySRV.PoNumber;

            string AccessoryDetail = objAccessorySRV.AccessoryName;

            if (objAccessorySRV.Size != "Default")
                AccessoryDetail = "<span style='color:blue;'>" + AccessoryDetail + "</span><span style='color:gray;'> (" + objAccessorySRV.Size + ")</span>";

            AccessoryDetail = AccessoryDetail + "</br>" + "<span style='color:black;font-weight:600'>" + objAccessorySRV.Color_Print.ToString() + "</span>";
            lblAccessDetails.Text = AccessoryDetail;

            txtReceivedqty.Text = objAccessorySRV.ReceivedQty != 0 ? Math.Round(objAccessorySRV.ReceivedQty,2).ToString() : "";
            hdnReceivedqty.Value = objAccessorySRV.ReceivedQty != 0 ? objAccessorySRV.ReceivedQty.ToString() : "";
            lblUnit.Text = objAccessorySRV.GarmentUnitName;
            hdnConversionVal.Value = objAccessorySRV.ConversionValue.ToString();
            hdnIsUnitChange.Value = objAccessorySRV.UnitChange == true ? "1" : "0";
            if (objAccessorySRV.UnitChange == true)
            {
                double afterDecimal = objAccessorySRV.DefaultRecievedQty - Math.Floor(objAccessorySRV.DefaultRecievedQty);
                if (afterDecimal > 0)
                    lblDefaultRecievedQty.Text = objAccessorySRV.DefaultRecievedQty > 0 ? "" + objAccessorySRV.DefaultRecievedQty.ToString() : "";
                else
                    lblDefaultRecievedQty.Text = objAccessorySRV.DefaultRecievedQty > 0 ? "" + objAccessorySRV.DefaultRecievedQty.ToString("N0") : "";
                hdnDefaultRecievedQty.Value = objAccessorySRV.DefaultRecievedQty.ToString();
                lblDefaultUnit.Text = objAccessorySRV.DefaultGarmentUnitName.ToString() + "";
            }

            txtRemark.Text = objAccessorySRV.srvRemark;

            if (objAccessorySRV.ActualReceivedQty > 0 && objAccessorySRV.DefaultRecievedQty != objAccessorySRV.ActualReceivedQty)
            {
                trActualSRV.Visible = true;
                lblActualSrv.Text = objAccessorySRV.ActualReceivedQty.ToString("N0");
            }

            divbipladdress.InnerHtml = objAccessorySRV.BIPLAddress;
            if ((Status == 1) || (Status == 2))
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "disablePage();", true);
            }

        }

        private void PartyBillNo()
        {

            int PartyBillId = hdnPartyBillId.Value == "" ? -1 : Convert.ToInt32(hdnPartyBillId.Value);
            DataTable dtbilldetails = obj_ProcessController.Accgetmaxvouchernumber(SupplierPoId, "", "BILL_DETAIL", PartyBillId, txtPartyBillNo.Text.Trim(), SupplierMasterID);
            if (dtbilldetails.Rows.Count > 0)
            {
                grdPartyBill.DataSource = dtbilldetails;
                grdPartyBill.DataBind();

                for (int i = 0; i < grdPartyBill.Rows.Count; i++)
                {
                    Label lblSrvNo = (Label)grdPartyBill.Rows[i].FindControl("lblSrvNo");
                    Label lblChallanNo = (Label)grdPartyBill.Rows[i].FindControl("lblChallanNo");
                    CheckBox chkSelect = (CheckBox)grdPartyBill.Rows[i].FindControl("chkSelect");

                    if (SrvId <= 0)
                    {
                        tblpartysection.Visible = false;
                        lnkpartybill.Attributes.Remove("onclick");
                        break;
                    }
                }
            }
            else
            {
                tblpartysection.Visible = false;
            }
            if (txtPartyBillNo.Text != "")
            {
                txtPartyBillNo.Enabled = false;
                txtPartyBillDate.Enabled = false;
                txtAmount.Enabled = false;
            }
            DataTable dtbill = obj_ProcessController.Accgetmaxvouchernumber(SupplierPoId, "", "ASSOCIATEDBILLNO", PartyBillId, txtPartyBillNo.Text.Trim());
            if (dtbill.Rows.Count > 0)
            {
                grdassociatedbill.DataSource = dtbill;
                grdassociatedbill.DataBind();
            }
            else
            {
                grdassociatedbill.Visible = false;
            }
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

                headerRow1.Cells.Add(HeaderCell);
                grdassociatedbill.Controls[0].Controls.AddAt(0, headerRow1);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
            }

        }

        protected void btnSrvSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                AccessorySRV objAccessorySRV = new AccessorySRV();
                objAccessorySRV.SupplierPoId = SupplierPoId;
                if (SrvId == 0)
                    objAccessorySRV.SRV_Id = lblReivingVoucherNo.Text == "" ? -1 : Convert.ToInt32(lblReivingVoucherNo.Text);
                else
                    objAccessorySRV.SRV_Id = SrvId;

                if ((Status == 1) || (Status == 2) || (hdnIsFourPointCheckedByGM.Value == "1"))
                {
                    objAccessorySRV.SRVDate = hdnSrvDate.Value != "" ? DateTime.ParseExact(hdnSrvDate.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
                    objAccessorySRV.PartyChallanNumber = hdnPartyChallanNo.Value.ToString();
                    objAccessorySRV.GateNo = hdnGateNo.Value.ToString();
                    objAccessorySRV.ReceivedUnit = hdnRecievedUnit.Value == "" ? -1 : Convert.ToInt32(hdnRecievedUnit.Value);
                    objAccessorySRV.srvRemark = hdnRemart.Value.ToString();

                    if (hdnIsUnitChange.Value == "1")
                        objAccessorySRV.ReceivedQty = hdnDefaultRecievedQty.Value == "" ? -1 : Convert.ToDouble(hdnDefaultRecievedQty.Value);     //modified by raghvinder on 09-11-2020         
                    else
                        objAccessorySRV.ReceivedQty = hdnReceivedqty.Value == "" ? -1 : Convert.ToDouble(hdnReceivedqty.Value);

                }
                else
                {
                    objAccessorySRV.SRVDate = txtSrvDate.Text != "" ? DateTime.ParseExact(txtSrvDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
                    objAccessorySRV.PartyChallanNumber = txtPartyChallanNo.Text.ToString();
                    objAccessorySRV.GateNo = txtGateEntryNo.Text.ToString();
                    objAccessorySRV.ReceivedUnit = Convert.ToInt32(ddlunitname.SelectedValue);
                    objAccessorySRV.srvRemark = txtRemark.Text;

                    if (hdnIsUnitChange.Value == "1")
                        objAccessorySRV.ReceivedQty = hdnDefaultRecievedQty.Value == "" ? -1 : Convert.ToDouble(hdnDefaultRecievedQty.Value);     //modified by raghvinder on 09-11-2020         
                    else
                        objAccessorySRV.ReceivedQty = txtReceivedqty.Text == "" ? -1 : Convert.ToDouble(txtReceivedqty.Text.Replace(",", ""));// modified bu shubhendu 19/11/2022


                }

                if (divCheckBox2.Visible == true && chkQtyCheckedBy.Checked == true)
                {
                    objAccessorySRV.QtyCheckedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                    objAccessorySRV.QtyCheckedDate = DateTime.Now;
                }
                else
                {
                    objAccessorySRV.QtyCheckedBy = 0;
                    objAccessorySRV.QtyCheckedDate = DateTime.MinValue;
                }

                List<Accessory_Srv_Bill> objSrv_BillCollection = new List<Accessory_Srv_Bill>();

                for (int i = 0; i < grdPartyBill.Rows.Count; i++)
                {
                    Accessory_Srv_Bill objSrvBill = new Accessory_Srv_Bill();
                    Label lblSrvNo = (Label)grdPartyBill.Rows[i].FindControl("lblSrvNo");
                    Label lblChallanNo = (Label)grdPartyBill.Rows[i].FindControl("lblChallanNo");
                    CheckBox chkSelect = (CheckBox)grdPartyBill.Rows[i].FindControl("chkSelect");
                    if (chkSelect.Checked)
                    {
                        objSrvBill.SRV_Id = Convert.ToInt32(lblSrvNo.Text);
                        objSrvBill.PartyChallanNumber = lblChallanNo.Text;
                        objSrvBill.IsChecked = chkSelect.Checked;

                        objSrvBill.SupplierPoId = SupplierPoId;
                        objSrvBill.PartyBillId = hdnPartyBillId.Value == "" ? -1 : Convert.ToInt32(hdnPartyBillId.Value);
                        objSrvBill.PartyBillNumber = txtPartyBillNo.Text;
                        objSrvBill.PartyBillDate = txtPartyBillDate.Text != "" ? DateTime.ParseExact(txtPartyBillDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
                        objSrvBill.Amount = txtAmount.Text != "" ? Convert.ToInt32(txtAmount.Text.Replace(",", "")) : 0;

                        objSrv_BillCollection.Add(objSrvBill);
                    }
                }
                objAccessorySRV.Accessory_Srv_BillList = objSrv_BillCollection;

                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
                if (lblCheckerName.Text != "")
                {

                    objAccessorySRV.IsSigned = "Signed";
                }
                else
                {
                    objAccessorySRV.IsSigned = chkQtyCheckedBy.Checked == true ? "Signed" : "NotSigned";

                }
                
                int iSave = objAccessoryWorking.SaveAccessory_Srv(objAccessorySRV, UserId);
                if (iSave > 0)
                {
                    SrvId = objAccessorySRV.SRV_Id;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "alert(" + ex.Message + ");", true);
            }
            BindUnit();
            BindData();
            PartyBillNo();

        }

        protected void grdPartyBill_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
                if (chkSelect.Checked)
                    chkSelect.Enabled = false;
            }
        }

        protected void btnhideclick_SRVClivk(object sender, EventArgs e)
        {
            int PartyBillId = -1;

            txtSrvDate.Text = hdnSrvDate.Value;
            txtPartyChallanNo.Text = hdnPartyChallanNo.Value;
            txtGateEntryNo.Text = hdnGateNo.Value;
            ddlunitname.SelectedValue = hdnRecievedUnit.Value.ToString();
            txtReceivedqty.Text = hdnReceivedqty.Value != "" ? Convert.ToDecimal(hdnReceivedqty.Value).ToString("N0") : "";
            txtRemark.Text = hdnRemart.Value;

            PartyBillId = hdnPartyBillId.Value == "" ? -1 : Convert.ToInt32(hdnPartyBillId.Value);

            DataTable dtcheck = obj_ProcessController.getmaxvouchernumbeAcc(SupplierPoId, "", "CHECKSUPPLIER", PartyBillId, txtPartyBillNo.Text.Trim(), SupplierMasterID);

            if (dtcheck.Rows.Count > 0)
            {
                if (dtcheck.Rows[0]["Result"].ToString() == "NOTVALID")
                {
                    txtAmount.Text = "";
                    txtPartyBillNo.Text = "";
                    txtPartyBillDate.Text = "";
                    grdassociatedbill.Visible = false;
                    ClientScript.RegisterStartupScript(GetType(), "hwa", "PartyBillNo();", true);
                    ShowAlert("Entered bill no. already associated with diff. supplier");

                    return;
                }
            }

            DataTable dtamt = obj_ProcessController.GetPartyBillAmt(SupplierMasterID, txtPartyBillNo.Text.Trim());
            if (dtamt.Rows.Count > 0)
            {
                txtPartyBillDate.Text = Convert.ToDateTime(dtamt.Rows[0]["PartyBillDate"].ToString()).ToString("dd MMM yy (ddd)");
                txtAmount.Text = dtamt.Rows[0]["Amount"].ToString();

                if (PartyBillId <= 0)
                {
                    PartyBillId = Convert.ToInt32(dtamt.Rows[0]["PartyBillId"].ToString());
                }
            }

            DataTable dtbilldetails = obj_ProcessController.Accgetmaxvouchernumber(SupplierPoId, "", "BILL_DETAIL", PartyBillId, txtPartyBillNo.Text.Trim(), SupplierMasterID);
            if (dtbilldetails.Rows.Count > 0)
            {
                grdPartyBill.DataSource = dtbilldetails;
                grdPartyBill.DataBind();
            }
            ClientScript.RegisterStartupScript(GetType(), "hwa", "PartyBillNo();", true);


            DataTable dtbill = obj_ProcessController.Accgetmaxvouchernumber(SupplierPoId, "", "ASSOCIATEDBILLNO", PartyBillId, txtPartyBillNo.Text.Trim(), SupplierMasterID);
            if (dtbill.Rows.Count > 0)
            {
                grdassociatedbill.DataSource = dtbill;
                grdassociatedbill.DataBind();
                grdassociatedbill.Visible = true;
            }
            else
            {
                grdassociatedbill.Visible = false;
            }
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
    }
}