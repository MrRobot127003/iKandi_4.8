using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using System.Data;
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
    public partial class AccessoryInternalChallan : BasePage
    {
        public string flag
        {
            get;
            set;
        }

        public string flagOption
        {
            get;
            set;
        }

        public string SerialNumber
        {
            get;
            set;
        }

        public string ChallanNumber
        {
            get;
            set;
        }
        public string ChallanType
        {
            get;
            set;
        }

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
        public int ChallanId
        {
            get;
            set;
        }
        public int OrderDetailId
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

        public decimal AvailableQty
        {
            get;
            set;
        }

        string host = "";
        string MailType = "Accessory Debit Send Challan ";
        string PoPath = string.Empty;

        AccessoryWorkingController objAccessoryWorking = new AccessoryWorkingController();
        AccessoryQualityController ObjAccessoryQlty = new AccessoryQualityController();
        protected void Page_Load(object sender, EventArgs e)
        {
            host = "http://" + Request.Url.Authority;
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            GetQueryString();
            if (!IsPostBack)
            {
                BindProductionUnit();
                BindChallanProcess();
                BindData();
                DataTable dt = objAccessoryWorking.Getbipladdress("BIPLAddress4");
                divbipladdress.InnerHtml = dt.Rows[0]["VALUE"].ToString();
            }
        }

        private void GetQueryString()
        {
            if (Request.QueryString["flag"] != null)
                flag = Request.QueryString["flag"].ToString();
            else flag = "";

            if (Request.QueryString["flagOption"] != null)
                flagOption = Request.QueryString["flagOption"].ToString();
            else flagOption = "";

            if (Request.QueryString["SerialNumber"] != null)
                SerialNumber = Request.QueryString["SerialNumber"].ToString();
            else SerialNumber = "";

            if (Request.QueryString["ChallanNumber"] != null)
                ChallanNumber = Request.QueryString["ChallanNumber"].ToString();
            else ChallanNumber = "";

            if (Request.QueryString["ChallanType"] != null)
                ChallanType = Request.QueryString["ChallanType"].ToString();
            else ChallanType = "";

            if (Request.QueryString["SupplierPoId"] != null)
                SupplierPoId = Convert.ToInt32(Request.QueryString["SupplierPoId"]);
            else SupplierPoId = 0;

            if (Request.QueryString["DebitNoteId"] != null)
                DebitNoteId = Convert.ToInt32(Request.QueryString["DebitNoteId"]);
            else DebitNoteId = 0;

            if (Request.QueryString["ChallanId"] != null)
                ChallanId = Convert.ToInt32(Request.QueryString["ChallanId"]);
            else ChallanId = 0;

            if (Request.QueryString["OrderDetailId"] != null)
                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
            else OrderDetailId = 0;

            if (Request.QueryString["AccessoryMasterId"] != null)
                AccessoryMasterId = Convert.ToInt32(Request.QueryString["AccessoryMasterId"]);
            else AccessoryMasterId = 0;

            if (Request.QueryString["Size"] != null)
                Size = Request.QueryString["Size"].ToString();
            else Size = "";

            if (Request.QueryString["ColorPrint"] != null)
                ColorPrint = Request.QueryString["ColorPrint"].ToString();
            else ColorPrint = "";

            if (Request.QueryString["AvailableQty"] != null)
                AvailableQty = Convert.ToDecimal(Request.QueryString["AvailableQty"]);
            else AvailableQty = 0;

        }

        private void BindProductionUnit()
        {

            DataTable dt = ObjAccessoryQlty.Get_AccessoryProductionUnit();
            if (dt.Rows.Count > 0)
            {
                ddlProductionUnit.DataSource = dt;
                ddlProductionUnit.DataTextField = "UnitName";
                ddlProductionUnit.DataValueField = "Id";
                ddlProductionUnit.DataBind();
                ddlProductionUnit.Items.Insert(0, new ListItem("Select", "-1"));

            }
        }

        private void BindChallanProcess()
        {
            if (ChallanType.ToLower() != "INTERNAL_CHALLAN".ToLower())
            {
                List<ChallanProcess> ChallanProcessList = objAccessoryWorking.GetChallanProcessList(ChallanId);
                chkProcess.DataSource = ChallanProcessList;
                chkProcess.DataTextField = "ProcessName";
                chkProcess.DataValueField = "ChallanProcessId";
                chkProcess.DataBind();

                for (int i = 0; i < chkProcess.Items.Count; i++)
                {
                    chkProcess.Items[i].Selected = ChallanProcessList[i].IsChecked;
                }
            }
        }

        private void BindData()
        {
            //New Work Start :Girish
            #region INTERNAL_CHALLAN
            if (ChallanType.ToLower() == "INTERNAL_CHALLAN".ToLower())
            {
               // tdCompanyType.Attributes.Add("style", "display:none");
                //rajeevS   
                spn_HSNCode.InnerHtml = "";
                lblHSNCode.Visible = false;
                //RajeevS
                trPO.Visible = false;
                gstt.Visible = false;
                aaddress.Visible = false;
                fabric_challan_rategst.Visible = false;

                DataTable dt = objAccessoryWorking.GetBasicDetailsForAccessoryInternalChallan(SerialNumber, ChallanNumber);

                ddlProductionUnit.SelectedValue = dt.Rows[0]["UnitID"].ToString();
                hdnSelectedSupplier.Value = dt.Rows[0]["UnitID"].ToString();

                //new work start(Showing GST No in Internal Challan): Girish

                hdnInternalUnitIds.Value = dt.Rows[0]["InternalUnitIds"].ToString();

                if (Convert.ToBoolean(dt.Rows[0]["IsAuthorized"]) && Convert.ToBoolean(dt.Rows[0]["IsReceived"]))
                {
                    if (dt.Rows[0]["GSTNo"].ToString() == "")
                    {
                        divToShowGSTNoForInternalChallan.Attributes.Add("style", "display:none;");
                    }
                    else
                    {
                        divToShowGSTNoForInternalChallan.Attributes.Add("style", "display:block;");
                        txtGSTNoForInternalChallan.Text = dt.Rows[0]["GSTNo"].ToString();
                        hdnGSTNoForInternalChallan.Value = dt.Rows[0]["GSTNo"].ToString();
                        txtGSTNoForInternalChallan.Enabled = false;
                        txtGSTNoForInternalChallan.Attributes.Add("style", "margin-top: 10px;margin-bottom:10px;border:none;background-color:white;");
                    }
                }
                else
                {
                    if (!dt.AsEnumerable().Any(row => row.Field<string>("InternalUnitIds").Split(',').Any(val => val.Trim() == ddlProductionUnit.SelectedValue)))
                    {
                        divToShowGSTNoForInternalChallan.Attributes.Add("style", "display:block;");

                        txtGSTNoForInternalChallan.Text = dt.Rows[0]["GSTNo"].ToString();
                        hdnGSTNoForInternalChallan.Value = dt.Rows[0]["GSTNo"].ToString();
                    }
                }
                //new work End : Girish

                List<ChallanProcess> ChallanProcessList = objAccessoryWorking.GetChallanProcessList(Convert.ToInt32(dt.Rows[0]["Challan_Id"]));
                chkProcess.DataSource = ChallanProcessList;
                chkProcess.DataTextField = "ProcessName";
                chkProcess.DataValueField = "ChallanProcessId";
                chkProcess.DataBind();

                if (ChallanNumber == "")
                {
                    foreach (ListItem item in chkProcess.Items)
                    {
                        if (item.Text == "Cutting")
                        {
                            item.Selected = true;
                            break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < chkProcess.Items.Count; i++)
                    {
                        chkProcess.Items[i].Selected = ChallanProcessList[i].IsChecked;
                    }
                }

                lblChallan.Text = dt.Rows[0]["ChallanNumber"].ToString();
                txtChallanDate.Text = Convert.ToDateTime(dt.Rows[0]["ChallanDate"]).ToString("dd MMM yy (ddd)");

                ddlType.SelectedValue = "2";
                ddlType.Enabled = false;
                lblStyleNo.Text = dt.Rows[0]["StyleNumber"].ToString();
                lblSerialNo.Text = dt.Rows[0]["SerialNumber"].ToString();

                if (Convert.ToBoolean(dt.Rows[0]["IsAuthorized"]))
                {
                    chkAuthorised.Checked = true;
                    chkAuthorised.Enabled = false;
                    chkAuthorised.Visible = false;
                    divSigAuthorized.Visible = true;

                    foreach (var user in ApplicationHelper.Users)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["AuthorisedBy"]) == user.UserID)
                        {
                            hdnAuthoriseIsChecked.Value = "1";
                            lblAuthorizedName.Text = user.FirstName + " " + user.LastName;
                            imgAuthorized.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                            lblAuthorizedOnDate.Text = Convert.ToDateTime(dt.Rows[0]["AuthorizedDate"]).ToString("dd MMM yy (ddd)");
                        }
                    }
                }
                if (Convert.ToBoolean(dt.Rows[0]["IsReceived"]))
                {
                    chkrecivegood.Checked = true;
                    chkrecivegood.Enabled = false;
                    chkrecivegood.Visible = false;
                    divSigReceive.Visible = true;

                    foreach (var user in ApplicationHelper.Users)
                    {
                        if (Convert.ToInt32(dt.Rows[0]["ReceivedBy"]) == user.UserID)
                        {
                            hdnReceiverIsChecked.Value = "1";
                            lblReceiverName.Text = user.FirstName + " " + user.LastName;
                            imgReceiver.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                            lblReceivedOnDate.Text = Convert.ToDateTime(dt.Rows[0]["ReceivedDate"]).ToString("dd MMM yy (ddd)");
                        }
                    }
                }

                if (Convert.ToBoolean(dt.Rows[0]["IsReceived"]) && Convert.ToBoolean(dt.Rows[0]["IsAuthorized"]))
                {
                    //btnSubmit.Visible = false; -- commented by Girish on 2023-03-15 for returned Qty Implementation
                    ddlProductionUnit.Enabled = false;
                    chkProcess.Enabled = false;
                }

                DataTable dt1 = objAccessoryWorking.GetDataForAccessoryInternalChallanGrid(flag, flagOption, SerialNumber, ChallanNumber);
                if (dt1.Rows.Count > 0)
                {
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "trigger", "calculateTotal('txtNoOfItems');calculateTotal('txtQtyToIssue');", true);
                }
                div_TotalNoOfItems.Visible = true;
                div_TotalIssuedQty.Visible = true;
            }
            #endregion INTERNAL_CHALLAN
            //New Work End


            #region region1
            else
            {
                old_table.Visible = true;
                old_description.Visible = true;
                tr_StyleNo.Visible = false;
                tr_SerialNo.Visible = false;
                AccessoryChallanCls objAccessoryChallan = new AccessoryChallanCls();
                AccessoryGstRateTotalAmount objAccessoryGstRateTotalAmount = new AccessoryGstRateTotalAmount();

                if (SupplierPoId <= 0)
                {
                    gstt.Visible = false;
                    aaddress.Visible = false;
                }

                objAccessoryGstRateTotalAmount = objAccessoryWorking.AccessoryGstRateTotalAmount(SupplierPoId, ChallanId, "INTRATEGST");

                if (OrderDetailId > 0)
                {
                    dvSupplier.Visible = false;
                    trPO.Visible = false;
                    objAccessoryChallan = objAccessoryWorking.Get_AccessoryChallan(ChallanId, OrderDetailId, AccessoryMasterId, Size, ColorPrint);
                    hdnAccessoryMasterId.Value = Convert.ToString(objAccessoryChallan.AccessoryMasterId);
                }
                if (DebitNoteId > 0)
                {
                    dvStyle.Visible = false;
                    objAccessoryChallan = objAccessoryWorking.Get_AccessoryChallan(SupplierPoId, DebitNoteId, ChallanId);
                    hdnSupplyType.Value = objAccessoryChallan.SupplyType.ToString();
                }
                //rajeevs
                string HSNCode = objAccessoryChallan.HSNCode;
                //if (HSNCode == "")
                if ((Convert.ToBoolean(objAccessoryChallan.IsPartySignature) || Convert.ToBoolean(objAccessoryChallan.IsAuthorizedSignatory)) && ((HSNCode == null) || (HSNCode == "")))
                {
                    spn_HSNCode.InnerHtml = "";
                    lblHSNCode.Visible = false;
                }
                else
                {
                    if (Convert.ToBoolean(objAccessoryChallan.IsPartySignature) || Convert.ToBoolean(objAccessoryChallan.IsAuthorizedSignatory))
                    {
                        lblHSNCode.BorderStyle = BorderStyle.None;
                    }
                    lblHSNCode.Visible = true;
                    lblHSNCode.Text = HSNCode;
                    spn_HSNCode.InnerHtml = "HSNCode";
                }
                //rajeevs

                if (objAccessoryChallan.IsAuthorizedSignatory == true)
                {
                    divChkAuthorized.Visible = false;
                    divSigAuthorized.Visible = true;
                    foreach (var user in ApplicationHelper.Users)
                    {
                        if (Convert.ToInt32(objAccessoryChallan.AuthoriseBy) == user.UserID)
                        {
                            hdnAuthoriseIsChecked.Value = "1";
                            lblAuthorizedName.Text = user.FirstName + " " + user.LastName;
                            imgAuthorized.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                            lblAuthorizedOnDate.Text = Convert.ToDateTime(objAccessoryChallan.AuthorizedDate).ToString("dd MMM yy (ddd)");
                        }
                    }
                }
                if (objAccessoryChallan.IsPartySignature == true)
                {
                    divChkReceive.Visible = false;
                    divSigReceive.Visible = true;
                    foreach (var user in ApplicationHelper.Users)
                    {
                        if (Convert.ToInt32(objAccessoryChallan.RecievedBy) == user.UserID)
                        {
                            hdnReceiverIsChecked.Value = "1";
                            lblReceiverName.Text = user.FirstName + " " + user.LastName;
                            imgReceiver.ImageUrl = user.SignPath != string.Empty ? "~/Uploads/Photo/" + user.SignPath : "~/Uploads/Photo/NotSign.jpg";
                            lblReceivedOnDate.Text = Convert.ToDateTime(objAccessoryChallan.ReceivedDate).ToString("dd MMM yy (ddd)");
                        }
                    }
                }

                hdnChallan.Value = objAccessoryChallan.ChallanId.ToString();

                if (DebitNoteId > 0)
                {
                    lblPoNo.Text = objAccessoryChallan.PoNumber.ToString();

                    lblSupplierName.Text = objAccessoryChallan.SupplierName;

                    lblSupplierGstNo.Text = objAccessoryChallan.SupplierGstNo;
                    lblSupplierAddress.Text = objAccessoryChallan.SupplierAddress;

                }
                lblChallan.Text = objAccessoryChallan.ChallanNumber;

                hdnPO_Number.Value = objAccessoryChallan.PoNumber;              //new line
                hdnChallan_Number.Value = objAccessoryChallan.ChallanNumber;    //new line
                hdnAccessoryQuality.Value = objAccessoryChallan.AccessoryName;  //new line 

                lblAccessoryQuality.Text = objAccessoryChallan.AccessoryName;
                if (OrderDetailId > 0)
                {
                    lblStyleNo.Text = objAccessoryChallan.StyleNumber;
                    lblSerialNo.Text = objAccessoryChallan.SerialNumber;
                }
                hdnSize.Value = objAccessoryChallan.Size;
                if (objAccessoryChallan.Size != "")
                    lblSize.Text = objAccessoryChallan.Size == "Default" ? "" : "(" + objAccessoryChallan.Size + ")";

                lblcolorprint.Text = objAccessoryChallan.Color_Print;
                txtDescription.Text = objAccessoryChallan.ChallanDesc;

                if (ChallanId > 0)
                {
                    txtChallanDate.Text = objAccessoryChallan.ChallanDate.ToString("dd MMM yy (ddd)");
                    ddlProductionUnit.SelectedValue = objAccessoryChallan.ProductionUnitId.ToString();
                }
                else
                {
                    txtChallanDate.Text = DateTime.Today.ToString("dd MMM yy (ddd)");

                    for (int i = 0; i < chkProcess.Items.Count; i++)
                    {
                        if (chkProcess.Items[i].Value == "7" && DebitNoteId > 0)// By default Rejection Retrurned checked
                        {
                            chkProcess.Items[i].Selected = true;
                        }
                        else if (chkProcess.Items[i].Value == "8" && OrderDetailId > 0)
                        {
                            chkProcess.Items[i].Selected = true;
                        }
                    }
                }
                if (DebitNoteId > 0)
                {
                    ddlType.SelectedValue = "1";
                    ddlType.Attributes.Add("disabled", "disabled");
                    dvUnit.Visible = false;
                    hdnType.Value = "1";
                }
                if (OrderDetailId > 0)
                {
                    ddlType.SelectedValue = "2";
                    ddlType.Attributes.Add("disabled", "disabled");
                    hdnType.Value = "2";
                }

                txtTotalUnit.Text = objAccessoryChallan.UnitCount > 0 ? objAccessoryChallan.UnitCount.ToString() : "";
                txtChallanQty.Text = objAccessoryChallan.TotalRecChallanQty > 0 ? objAccessoryChallan.TotalRecChallanQty.ToString("N") : "";
                hdnTotalPcs.Value = objAccessoryChallan.TotalRecChallanQty.ToString();
                lblUnitName.Text = objAccessoryChallan.GarmentUnitName;
                DataTable Dt = objAccessoryWorking.Get_AccessoryPODetail(SupplierPoId);
                if (Dt.Rows.Count > 0)
                {
                    if (Dt.Rows[0]["PoStatus"].ToString() != "2")
                    {
                        lblrate.Text = objAccessoryGstRateTotalAmount.Rate.ToString();
                        decimal gst = objAccessoryGstRateTotalAmount.Gst;
                        //if (objAccessoryGstRateTotalAmount.GSTno != null)
                        //{
                        string gstno = objAccessoryGstRateTotalAmount.GSTno.ToString().Substring(0, 2);
                        if (gstno == "09")
                        {

                            lblsgst.Text = (gst / 2).ToString();
                            lblcgst.Text = (gst / 2).ToString();
                            igst.Visible = false;
                            lblTotalAmount.Text = objAccessoryGstRateTotalAmount.TotalAmount.ToString();
                        }
                        else
                        {

                            lbligst.Text = gst.ToString();
                            licgst.Visible = false;
                            lisgst.Visible = false;
                            lblTotalAmount.Text = objAccessoryGstRateTotalAmount.TotalAmount.ToString();
                        }
                        //}

                    }
                    else
                    {

                        fabric_challan_rategst.Visible = false;
                    }
                }
                if (lblChallan.Text != "")
                    if (lblChallan.Text.Substring(0, 3) == "INT")
                        fabric_challan_rategst.Visible = false;


                if (AvailableQty > 0)
                {
                    lblAvailableQty.Text = AvailableQty.ToString("N");
                    hdnRemainingQty.Value = AvailableQty.ToString();
                    lblAvailableQtyUnit.Text = objAccessoryChallan.GarmentUnitName;
                }
                else
                {
                    lblAvailableQty.Text = objAccessoryChallan.BalanceQty > 0 ? objAccessoryChallan.BalanceQty.ToString("N") : "";
                    hdnRemainingQty.Value = objAccessoryChallan.BalanceQty.ToString();
                    lblAvailableQtyUnit.Text = objAccessoryChallan.BalanceQty > 0 ? objAccessoryChallan.GarmentUnitName : "";
                }
                if (lblAvailableQty.Text == "")
                {
                    tdAvailableQty.Attributes.Add("style", "display:none");
                }


                if ((objAccessoryChallan.IsPartySignature == true) && (objAccessoryChallan.IsAuthorizedSignatory == true))
                {
                    dvSendMail.Attributes.Add("style", "display:'';font-weight:bold;width:400px;");

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "disablePage();", true);
                    //btnSubmit.Visible = false;
                }
            }
            #endregion region1
        }

        //merging logic For InternalChallan Grid Start:Girish
        protected void GridView1_DataBoundEvent(Object sender, EventArgs e)
        {
            GridView gridview = (GridView)sender;

            for (int i = gridview.Rows.Count - 2; i >= 0; i--)
            {
                GridViewRow row = gridview.Rows[i];
                GridViewRow previousRow = gridview.Rows[i + 1];

                string currentRowAccessoryName = "", previousRowAccessoryName = "";

                currentRowAccessoryName = currentRowAccessoryName + ((HiddenField)row.FindControl("hdnAccessoryMasterId")).Value + ((HiddenField)row.FindControl("hdnSize")).Value;
                previousRowAccessoryName = previousRowAccessoryName + ((HiddenField)previousRow.FindControl("hdnAccessoryMasterId")).Value + ((HiddenField)previousRow.FindControl("hdnSize")).Value;

                if (currentRowAccessoryName.ToLower() == previousRowAccessoryName.ToLower())
                {
                    row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 : previousRow.Cells[0].RowSpan + 1;
                    previousRow.Cells[0].Visible = false;

                    row.Cells[1].RowSpan = previousRow.Cells[1].RowSpan < 2 ? 2 : previousRow.Cells[1].RowSpan + 1;
                    previousRow.Cells[1].Visible = false;
                }
            }

            if (hdnAuthoriseIsChecked.Value == "1" && hdnReceiverIsChecked.Value == "1")
            {
                gridview.Columns[5].Visible = false;
                gridview.Columns[8].Visible = true;
            }
        }
        //merging logic For InternalChallan Grid End:Girish      

        //added on 2023-03-15 by Girish for validating ReturnedQty in Internal Challan  (<%--AutoPostBack is set to false as validating Returned Qty through javascript so there's no need to PostBack--%>)
        protected void ReturnedQty_TextChanged(object sender, EventArgs e)
        {
            GridViewRow gridViewRow = ((sender as TextBox).NamingContainer as GridViewRow);
            if (gridViewRow != null)
            {
                TextBox txtReturnedQty = gridViewRow.FindControl("txtReturnedQty") as TextBox;
                HiddenField hdnReturnedQty = gridViewRow.FindControl("hdnReturnedQty") as HiddenField;
                HiddenField hdnMinimumQtyThatCanBeReturned = gridViewRow.FindControl("hdnMinimumQtyThatCanBeReturned") as HiddenField;
                HiddenField hdnMaximumQtyThatCanBeReturned = gridViewRow.FindControl("hdnMaximumQtyThatCanBeReturned") as HiddenField;

                if (txtReturnedQty != null)
                {
                    Decimal ReturnedQty = txtReturnedQty.Text == "" ? 0 : Convert.ToDecimal(txtReturnedQty.Text);
                    Decimal OriginalReturnedQty = hdnReturnedQty.Value == "" ? 0 : Convert.ToDecimal(hdnReturnedQty.Value);
                    Decimal MaximumQtyThatCanBeReturned = hdnMaximumQtyThatCanBeReturned.Value == "" ? 0 : Convert.ToDecimal(hdnMaximumQtyThatCanBeReturned.Value);
                    Decimal MinimumQtyThatCanBeReturned = hdnMinimumQtyThatCanBeReturned.Value == "" ? 0 : Convert.ToDecimal(hdnMinimumQtyThatCanBeReturned.Value);

                    if (ReturnedQty > MaximumQtyThatCanBeReturned)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "alert('You Cannot Return more than " + MaximumQtyThatCanBeReturned.ToString(".##") + "');calculateTotal('txtNoOfItems');calculateTotal('txtQtyToIssue');", true);
                        txtReturnedQty.Text = OriginalReturnedQty == 0 ? "" : OriginalReturnedQty.ToString(".##");
                        return;
                    }
                    else if (ReturnedQty < OriginalReturnedQty)
                    {
                        if (ReturnedQty < MinimumQtyThatCanBeReturned)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "alert('You Cannot Return less than " + MinimumQtyThatCanBeReturned.ToString(".##") + "');calculateTotal('txtNoOfItems');calculateTotal('txtQtyToIssue');", true);
                            txtReturnedQty.Text = OriginalReturnedQty == 0 ? "" : OriginalReturnedQty.ToString(".##");
                            return;
                        }
                    }
                }
            }
        }
        //added on 2023-03-15




        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //new Work Stat : Girish
            if (ChallanType.ToLower() == "INTERNAL_CHALLAN".ToLower())
            {
                SaveAccessoryInternalChallan SaveAccessoryInternalChallan = new SaveAccessoryInternalChallan();

                if (Convert.ToInt32(ddlProductionUnit.SelectedValue) == -1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "alert('Please Select M/S.');calculateTotal('txtNoOfItems');calculateTotal('txtQtyToIssue');", true);
                    return;
                }
                Boolean CheckBox = false;

                foreach (ListItem item in chkProcess.Items)
                {
                    if (item.Selected)
                    {
                        CheckBox = true;
                        SaveAccessoryInternalChallan.ProcessIds = SaveAccessoryInternalChallan.ProcessIds + item.Value + ",";
                    }
                }

                if (!CheckBox)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "alert('Please Select at Least One Check Box.');calculateTotal('txtNoOfItems');calculateTotal('txtQtyToIssue');", true);
                    return;
                }

                if (txtGSTNoForInternalChallan.Enabled)
                {
                    SaveAccessoryInternalChallan.GSTNo = txtGSTNoForInternalChallan.Text;
                }
                else
                {
                    SaveAccessoryInternalChallan.GSTNo = hdnGSTNoForInternalChallan.Value;
                }

                SaveAccessoryInternalChallan.ChallanNumber = lblChallan.Text;
                ChallanNumber = lblChallan.Text;
                hdnChallan_Number.Value = lblChallan.Text;

                SaveAccessoryInternalChallan.ChallanDate = txtChallanDate.Text != "" ? DateTime.ParseExact(txtChallanDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
                SaveAccessoryInternalChallan.ProductionUnitId = Convert.ToInt32(ddlProductionUnit.SelectedValue);


                int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                SaveAccessoryInternalChallan.IsPartySignature = (chkrecivegood.Checked == true || hdnReceiverIsChecked.Value == "1" ? true : false);
                if (SaveAccessoryInternalChallan.IsPartySignature == true)
                    SaveAccessoryInternalChallan.ReceivedDate = DateTime.Now;

                SaveAccessoryInternalChallan.IsAuthorizedSignatory = (chkAuthorised.Checked == true || hdnAuthoriseIsChecked.Value == "1" ? true : false);
                if (SaveAccessoryInternalChallan.IsAuthorizedSignatory == true)
                    SaveAccessoryInternalChallan.AuthorizedDate = DateTime.Now;


                List<AccessoryInternalChallanGridData> listToStoreGridData = new List<AccessoryInternalChallanGridData>();

                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    TextBox txtQtyToIssue = (TextBox)GridView1.Rows[i].FindControl("txtQtyToIssue");

                    if (txtQtyToIssue.Text != "" && txtQtyToIssue.Text != "0")
                    {
                        AccessoryInternalChallanGridData AccessoryInternalChallanGridData = new AccessoryInternalChallanGridData();

                        AccessoryInternalChallanGridData.QtyToIssue = Convert.ToDecimal(txtQtyToIssue.Text);

                        TextBox txtNoOfItems = (TextBox)GridView1.Rows[i].FindControl("txtNoOfItems");
                        AccessoryInternalChallanGridData.NoOfItems = txtNoOfItems.Text == "" ? 1 : Convert.ToInt32(txtNoOfItems.Text);

                        TextBox txtDescription = (TextBox)GridView1.Rows[i].FindControl("txtDescription");
                        AccessoryInternalChallanGridData.Description = txtDescription.Text;

                        HiddenField hdnAccessoryMasterId = (HiddenField)GridView1.Rows[i].FindControl("hdnAccessoryMasterId");
                        AccessoryInternalChallanGridData.AccessoryMasterId = Convert.ToInt32(hdnAccessoryMasterId.Value);

                        HiddenField hdnSize = (HiddenField)GridView1.Rows[i].FindControl("hdnSize");
                        AccessoryInternalChallanGridData.Size = hdnSize.Value.ToString();

                        HiddenField hdnColorPrint = (HiddenField)GridView1.Rows[i].FindControl("hdnColorPrint");
                        AccessoryInternalChallanGridData.ColorPrint = hdnColorPrint.Value.ToString();

                        HiddenField hdnOrderDetailId = (HiddenField)GridView1.Rows[i].FindControl("hdnOrderDetailId");
                        AccessoryInternalChallanGridData.OrderDetailId = Convert.ToInt32(hdnOrderDetailId.Value);

                        TextBox txtReturnedQty = (TextBox)GridView1.Rows[i].FindControl("txtReturnedQty");
                        AccessoryInternalChallanGridData.ReturnedQty = txtReturnedQty.Text == "" ? 0 : Convert.ToDecimal(txtReturnedQty.Text);
              

                        listToStoreGridData.Add(AccessoryInternalChallanGridData);
                    }
                }

                SaveAccessoryInternalChallan.GridData = listToStoreGridData;

                Boolean Success = false;
                if (listToStoreGridData.Count >= 1)
                {
                    Success = objAccessoryWorking.Save_Accessory_Internal_Challan(SaveAccessoryInternalChallan, UserId);
                    if (Success)
                    {
                        if (SaveAccessoryInternalChallan.IsPartySignature && SaveAccessoryInternalChallan.IsAuthorizedSignatory && rbtnYes.Checked)
                        {
                            RenderHtml();

                            string thisPath = "Challan_" + hdnChallan_Number.Value + ".pdf";
                            string url = host + "/Uploads/Accessory/" + thisPath;

                            string EmailContent = HttpContent(url);

                            SendDebitNoteEmail("test", "kumar", EmailContent, MailType);
                        }

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);

                    }
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "alert('something went wrong.please close this page and try again.');", true);

                }
            }
            //new Work End
            else
            {
                int ProductionUnit = 0;
                if ((Convert.ToInt32(hdnType.Value) == 2) && (ddlProductionUnit.SelectedValue == "-1"))
                {
                    ProductionUnit = -1;
                }

                if (hdnAuthoriseIsChecked.Value == "0" || hdnReceiverIsChecked.Value == "0")
                {
                    if (((DebitNoteId > 0) || (OrderDetailId > 0)) && (txtChallanQty.Text != "") && (ProductionUnit != -1))
                    {
                        AccessoryChallanCls objAccessoryChallan = new AccessoryChallanCls();
                        if (DebitNoteId > 0)
                        {
                            objAccessoryChallan.SupplierPoId = SupplierPoId;
                            objAccessoryChallan.DebitNoteId = DebitNoteId;
                        }
                        objAccessoryChallan.ChallanId = hdnChallan.Value == "" ? -1 : Convert.ToInt32(hdnChallan.Value);
                        objAccessoryChallan.ChallanNumber = lblChallan.Text;
                        objAccessoryChallan.ChallanDate = txtChallanDate.Text != "" ? DateTime.ParseExact(txtChallanDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
                        objAccessoryChallan.ChallanType = Convert.ToInt32(hdnType.Value);
                        objAccessoryChallan.ChallanDesc = txtDescription.Text;
                        objAccessoryChallan.TotalRecChallanQty = txtChallanQty.Text == "" ? 0 : Convert.ToDecimal(txtChallanQty.Text.Replace(",", ""));
                        objAccessoryChallan.UnitCount = txtTotalUnit.Text == "" ? 0 : Convert.ToInt32(txtTotalUnit.Text);
                        objAccessoryChallan.HSNCode = lblHSNCode.Text;
                        objAccessoryChallan.ProductionUnitId = Convert.ToInt32(ddlProductionUnit.SelectedValue);
                        objAccessoryChallan.SendQty = -1;
                        if (OrderDetailId > 0)
                        {
                            objAccessoryChallan.AccessoryMasterId = Convert.ToInt32(hdnAccessoryMasterId.Value);
                            //char[] charsToTrim = { '(', ')' };
                            objAccessoryChallan.Color_Print = lblcolorprint.Text;
                            objAccessoryChallan.Size = hdnSize.Value.ToString();
                            objAccessoryChallan.OrderDetailId = OrderDetailId;
                        }

                        List<ChallanProcess> objChallanProcessList = new List<ChallanProcess>();
                        for (int i = 0; i < chkProcess.Items.Count; i++)
                        {
                            ChallanProcess objProcess = new ChallanProcess();
                            if (chkProcess.Items[i].Selected)
                            {
                                objProcess.ChallanProcessId = Convert.ToInt32(chkProcess.Items[i].Value);
                                objChallanProcessList.Add(objProcess);
                            }
                        }
                        objAccessoryChallan.ChallanProcessList = objChallanProcessList;


                        int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

                        objAccessoryChallan.IsPartySignature = (chkrecivegood.Checked == true ? true : false);
                        if (objAccessoryChallan.IsPartySignature == true)
                        {
                            objAccessoryChallan.ReceivedDate = DateTime.Now;
                        }
                        objAccessoryChallan.IsAuthorizedSignatory = (chkAuthorised.Checked == true ? true : false);
                        if (objAccessoryChallan.IsAuthorizedSignatory == true)
                        {
                            objAccessoryChallan.AuthorizedDate = DateTime.Now;
                        }

                        int iSave = objAccessoryWorking.Save_Accessory_Challan(objAccessoryChallan, UserId);

                        ChallanId = iSave;

                        if (iSave > 0)
                        {
                            if (chkAuthorised.Checked && chkrecivegood.Checked && rbtnYes.Checked)
                            {

                                RenderHtml();

                                string thisPath = "Challan_" + hdnChallan_Number.Value + ".pdf";
                                string url = host + "/Uploads/Accessory/" + thisPath;

                                string EmailContent = HttpContent(url);

                                SendDebitNoteEmail("test", "kumar", EmailContent, MailType);
                            }
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "jQuery.facebox('Some error occured);", true);
                            return;
                        }
                    }
                }
                if (hdnAuthoriseIsChecked.Value == "1" && hdnReceiverIsChecked.Value == "1" && (rbtnYes.Checked))
                {
                    RenderHtml();

                    string thisPath = "Challan_" + hdnChallan_Number.Value + ".pdf";
                    string url = host + "/Uploads/Accessory/" + thisPath;

                    string EmailContent = HttpContent(url);

                    SendDebitNoteEmail("test", "kumar", EmailContent, MailType);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
                }

            }

        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        //    int ProductionUnit = 0;
        //    if ((Convert.ToInt32(hdnType.Value) == 2) && (ddlProductionUnit.SelectedValue == "-1"))
        //    {
        //        ProductionUnit = -1;
        //    }

        //    if (hdnAuthoriseIsChecked.Value == "0" || hdnReceiverIsChecked.Value == "0")
        //    {
        //        if (((DebitNoteId > 0) || (OrderDetailId > 0)) && (txtChallanQty.Text != "") && (ProductionUnit != -1))
        //        {
        //            AccessoryChallanCls objAccessoryChallan = new AccessoryChallanCls();
        //            if (DebitNoteId > 0)
        //            {
        //                objAccessoryChallan.SupplierPoId = SupplierPoId;
        //                objAccessoryChallan.DebitNoteId = DebitNoteId;
        //            }
        //            objAccessoryChallan.ChallanId = hdnChallan.Value == "" ? -1 : Convert.ToInt32(hdnChallan.Value);
        //            objAccessoryChallan.ChallanNumber = lblChallan.Text;
        //            objAccessoryChallan.ChallanDate = txtChallanDate.Text != "" ? DateTime.ParseExact(txtChallanDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
        //            objAccessoryChallan.ChallanType = Convert.ToInt32(hdnType.Value);
        //            objAccessoryChallan.ChallanDesc = txtDescription.Text;
        //            objAccessoryChallan.TotalRecChallanQty = txtChallanQty.Text == "" ? 0 : Convert.ToDecimal(txtChallanQty.Text.Replace(",", ""));
        //            objAccessoryChallan.UnitCount = txtTotalUnit.Text == "" ? 0 : Convert.ToInt32(txtTotalUnit.Text);

        //            objAccessoryChallan.ProductionUnitId = Convert.ToInt32(ddlProductionUnit.SelectedValue);
        //            objAccessoryChallan.SendQty = -1;
        //            if (OrderDetailId > 0)
        //            {
        //                objAccessoryChallan.AccessoryMasterId = Convert.ToInt32(hdnAccessoryMasterId.Value);
        //                //char[] charsToTrim = { '(', ')' };
        //                objAccessoryChallan.Color_Print = lblcolorprint.Text;
        //                objAccessoryChallan.Size = hdnSize.Value.ToString();
        //                objAccessoryChallan.OrderDetailId = OrderDetailId;
        //            }

        //            List<ChallanProcess> objChallanProcessList = new List<ChallanProcess>();
        //            for (int i = 0; i < chkProcess.Items.Count; i++)
        //            {
        //                ChallanProcess objProcess = new ChallanProcess();
        //                if (chkProcess.Items[i].Selected)
        //                {
        //                    objProcess.ChallanProcessId = Convert.ToInt32(chkProcess.Items[i].Value);
        //                    objChallanProcessList.Add(objProcess);
        //                }
        //            }
        //            objAccessoryChallan.ChallanProcessList = objChallanProcessList;


        //            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

        //            objAccessoryChallan.IsPartySignature = (chkrecivegood.Checked == true ? true : false);
        //            if (objAccessoryChallan.IsPartySignature == true)
        //            {
        //                objAccessoryChallan.ReceivedDate = DateTime.Now;
        //            }
        //            objAccessoryChallan.IsAuthorizedSignatory = (chkAuthorised.Checked == true ? true : false);
        //            if (objAccessoryChallan.IsAuthorizedSignatory == true)
        //            {
        //                objAccessoryChallan.AuthorizedDate = DateTime.Now;
        //            }

        //            int iSave = objAccessoryWorking.Save_Accessory_Challan(objAccessoryChallan, UserId);

        //            ChallanId = iSave;

        //            if (iSave > 0)
        //            {
        //                if (chkAuthorised.Checked && chkrecivegood.Checked && rbtnYes.Checked)
        //                {

        //                    RenderHtml();

        //                    string thisPath = "Challan_" + hdnChallan_Number.Value + ".pdf";
        //                    string url = host + "/Uploads/Accessory/" + thisPath;

        //                    string EmailContent = HttpContent(url);

        //                    SendDebitNoteEmail("test", "kumar", EmailContent, MailType);
        //                }
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "jQuery.facebox('Some error occured);", true);
        //                return;
        //            }
        //        }
        //    }
        //    if (hdnAuthoriseIsChecked.Value == "1" && hdnReceiverIsChecked.Value == "1" && (rbtnYes.Checked))
        //    {
        //        RenderHtml();

        //        string thisPath = "Challan_" + hdnChallan_Number.Value + ".pdf";
        //        string url = host + "/Uploads/Accessory/" + thisPath;

        //        string EmailContent = HttpContent(url);

        //        SendDebitNoteEmail("test", "kumar", EmailContent, MailType);
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "closePage();", true);
        //    }
        //}

        public void RenderHtml()
        {
            WebRequest Request;
            WebResponse Response;
            StreamReader reader;
            int UserId = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;
            string strHTML;
            Request = WebRequest.Create(host + "/AccessoryPdfFile/AccessoryInternalChallanPdf.aspx?SupplierPoId=" + SupplierPoId + "&ChallanId=" + ChallanId + "&UserId=" + UserId + "&OrderDetailId=" + OrderDetailId + "&DebitNoteId=" + DebitNoteId + "&ChallanType=" + ChallanType + "&AccessoryMasterId=" + AccessoryMasterId + "&Size=" + Size + "&ColorPrint=" + ColorPrint + "&AvailableQty=" + AvailableQty + "&flag=" + "GetChallanDetails" + "&ChallanNumber=" + ChallanNumber + "&SerialNumber=" + SerialNumber);

            Request.Timeout = Convert.ToInt32(99999999);
            Response = Request.GetResponse();
            reader = new StreamReader(Response.GetResponseStream());
            strHTML = reader.ReadToEnd();
            genertaePdf(strHTML, "ss");
        }

        public void genertaePdf(string HTMLCode, string PolicyFile)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Accessory/" + "Challan_" + hdnChallan_Number.Value + ".pdf");
            HTMLCode = getImage(HTMLCode);
            getvartypeHTML(HTMLCode, strFileName);
        }

        public void getvartypeHTML(string HTMLCode, string PolicyFile)
        {
            string strFileName = HttpContext.Current.Server.MapPath("~/Uploads/Accessory/" + "Challan_" + hdnChallan_Number.Value + ".pdf");

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
                //req.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E)";
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
                string email = "ravi@boutique.in";
                to.Add(email);
                //string[] email2 = email.Split(',');
                //foreach (string em in email2)
                //{
                //    to.Add(em);
                //}
                List<Attachment> atts = new List<Attachment>();

                if (File.Exists(Constants.ACCESSORY_FOLDER_PATH + "Challan_" + hdnChallan_Number.Value + ".pdf"))
                {

                    PoPath = Path.Combine(Constants.ACCESSORY_FOLDER_PATH, "Challan_" + hdnChallan_Number.Value + ".pdf");
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
            string SupplyType = "";
            int iSupplyType = hdnSupplyType.Value == null ? 0 : Convert.ToInt32(hdnSupplyType.Value);
            if (iSupplyType == 1)
                SupplyType = "Greige.";
            else if (iSupplyType == 2)
                SupplyType = "Process.";
            else if (iSupplyType == 3)
                SupplyType = "Finish.";

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = MailType + "Against (" + hdnPO_Number.Value + ")";

            if (ChallanType.ToLower() == "Internal_Challan".ToLower())
            {
                mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Team, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, <span style='color:gray'> An Internal Challan </span>" + "<b>" + hdnChallan_Number.Value + "</b>" + " is raised for Accessory Quality for Final stage. Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> Disclaimer: This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
                mailMessage.Subject = "Accessory Internal Challan (" + hdnChallan_Number.Value + ")";
            }
            else
                mailMessage.Body = "<span style='font-size:13px; font-family:Arial'>Dear Supplier, <br><br> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; With due respect, a <span style='color:gray'> Debit Send Challan </span>" + "<b>" + hdnChallan_Number.Value + "</b> for " + "Purchase Order - " + hdnPO_Number.Value + " is raised for <span style='color:gray'> Accessory Quality </span>" + "<span style='color:#2f5597'>" + hdnAccessoryQuality.Value + "</span> for stage <span style='color:#2f5597'>" + SupplyType + "</span>" + " Please find the attached PDF File having all details. <br> <br> <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style='font-size:10px;font-family:Arial;'> Disclaimer: This is system generated mail, for detail communicate at <span style='color:blue'> +91 120 67979 </span> </span> <br><br><b> Thanks & Regards </b> <br> BIPL Team</span>";
            //mailMessage.Body = "Dear Supplier, \n \n \t With due respect, a challan is raised against for PO NO - " + hdnPO_Number.Value + ". Please find attached file. \n \n \n \t " + content + "\n \n Thanks & Regards \n BIPL Team";

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
                //mailMessage.CC.Add("ravi@boutique.in");
                mailMessage.CC.Add("ravi@boutique.in");

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
                System.Diagnostics.Trace.WriteLine("Email having subject of --" + Subject.ToString() + " is send successfully on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
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

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

    }
}
