

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Collections.Generic;
using iKandi.Web.Components;
using iKandi.Common;
using System.Text;
using System.Web.UI.HtmlControls;


namespace iKandi.Web
{
    public partial class CostingForm : BaseUserControl
    {
        #region Fields

        UserTask _CostingConfirmationTask = null;
        UserTask _CostingPriceUpdate = null;
        UserTask _CostingConfirmedTask = null;
        public int FLAG = 0;

        #endregion

        #region Constants

        const string COSTING_SHEET_URL = "/Internal/Sales/TabCostingSheet.aspx";

        #endregion

        #region Properties

        public int CostingId
        {
            get
            {
                int cid;

                if (null != ViewState["cid"])
                {
                    if (int.TryParse(ViewState["cid"].ToString(), out cid))
                    {
                        if (cid > 0)
                            return cid;
                    }
                }
                else if (null != Request.QueryString["cid"])
                {
                    if (int.TryParse(Request.QueryString["cid"].ToString(), out cid))
                    {
                        if (cid > 0)
                        {
                            btnSave.Visible = true;
                            btnSaveIkandi.Visible = true;
                            btniKandiUpdatePrice.Visible = true;
                            btnCostConfirmation.Visible = true;
                            btnUpdatePrice.Visible = true;
                            //btnCostConfirmed.Visible = (CostingConfirmationTask.ID > 0);
                            ViewState["cid"] = cid;
                            return cid;
                        }
                    }
                }

                if (Role == 1)
                {
                    btnSave.Visible = false;
                    btnCostConfirmation.Visible = false;
                    btnUpdatePrice.Visible = false;
                    btnBIPLPrint.Visible = false;

                    btniKandiUpdatePrice.Visible = false;
                    btnSaveIkandi.Visible = false;
                    btnCostConfirmed.Visible = false;
                }

                return -1;
            }
            set
            {
                ViewState["cid"] = value;
            }
        }

        public int ClientID
        {
            get
            {
                if (Request.QueryString["ClientID"] == null || Request.QueryString["ClientID"].Trim() == string.Empty)
                    return -1;

                return Convert.ToInt32(Request.QueryString["ClientID"]);
            }
        }

        public int StyleID
        {
            get
            {
                if (Request.QueryString["StyleID"] == null || Request.QueryString["StyleID"].Trim() == string.Empty)
                    return -1;

                return Convert.ToInt32(Request.QueryString["StyleID"]);
            }
        }

        public int DepartmentID
        {
            get
            {
                if (this.CostingObject != null && this.CostingObject.DepartmentID > 0)
                    return this.CostingObject.DepartmentID;

                if (Request.QueryString["DepartmentID"] == null || Request.QueryString["DepartmentID"].Trim() == string.Empty)
                    return -1;

                return Convert.ToInt32(Request.QueryString["DepartmentID"]);
            }
        }
        public int IsUcknowledge
        {
            get
            {
                if (Request.QueryString["IsUcknowledge"] == null || Request.QueryString["IsUcknowledge"].Trim() == string.Empty)
                    return 0;

                return Convert.ToInt32(Request.QueryString["IsUcknowledge"]);
            }
        }

        private int Role
        {
            get
            {
                switch (ApplicationHelper.LoggedInUser.UserData.DesignationID)
                {
                    case (int)Designation.BIPL_Sales_Manager:
                    case (int)Designation.BIPL_Merchandising_Manager:
                    case (int)Designation.BIPL_Sales_Advisor:
                    case (int)Designation.BIPL_FITs_Manager:
                    case (int)Designation.BIPL_Merchandising_AccountManager:
                        return 0;
                    case (int)Designation.iKandi_Sales_Manager:
                    case (int)Designation.iKandi_Sales_SalesManager:
                        return 1;
                    default:
                        return -1;
                }
            }
        }

        private bool IsBIPLUserAccessingIKandiData
        {
            get
            {
                if (Role == 0 && null != ViewState["isBIPLUserAccessingIKandiData"])
                    return (bool)ViewState["isBIPLUserAccessingIKandiData"];

                return false;
            }
            set
            {
                ViewState["isBIPLUserAccessingIKandiData"] = value;
            }
        }

        private int ParentCostingId
        {
            get
            {
                if (null != ViewState["pcid"])
                {
                    int pcid;

                    if (int.TryParse(ViewState["pcid"].ToString(), out pcid))
                    {
                        if (pcid > 0)
                            return pcid;
                    }
                }

                return -1;
            }
            set
            {
                ViewState["pcid"] = value;
            }
        }

        private int ChildCostingId
        {
            get
            {
                if (null != ViewState["ccid"])
                {
                    int ccid;

                    if (int.TryParse(ViewState["ccid"].ToString(), out ccid))
                    {
                        if (ccid > 0)
                            return ccid;
                    }
                }

                return -1;
            }
            set
            {
                ViewState["ccid"] = value;
            }
        }

        private Costing CostingObject
        {
            get
            {
                if (null == Session["costing" + this.StyleID])
                {
                    return new Costing();
                }

                return (Costing)Session["costing" + this.StyleID];
            }
            set
            {
                Session["costing" + this.StyleID] = value;
            }
        }

        private int ParentStyleId
        {
            get
            {
                if (null != ViewState["psid"])
                {
                    int psid;

                    if (int.TryParse(ViewState["psid"].ToString(), out psid))
                    {
                        if (psid > 0)
                            return psid;
                    }
                }

                return -1;
            }
            set
            {
                ViewState["psid"] = value;
            }
        }

        public UserTask CostingConfirmationTask
        {
            get
            {
                if (_CostingConfirmationTask == null)
                    _CostingConfirmationTask = this.UserTaskControllerInstance.GetUserTasksByStyleID(this.StyleID, UserTaskType.CostConfirmation);

                return _CostingConfirmationTask;
            }
        }

        public UserTask CostingPriceUpdate
        {
            get
            {
                if (_CostingPriceUpdate == null)
                    _CostingPriceUpdate = this.UserTaskControllerInstance.GetUserTasksByStyleID(this.StyleID, UserTaskType.PriceUpdate);

                return _CostingPriceUpdate;
            }
        }

        public UserTask CostingConfirmedTask
        {
            get
            {
                if (_CostingConfirmedTask == null)
                    _CostingConfirmedTask = this.UserTaskControllerInstance.GetUserCompletedTasksByStyleID(this.StyleID, UserTaskType.CostConfirmation);

                return _CostingConfirmedTask;
            }
        }

        public int IsCMT = 0;

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["StyleId"] = Convert.ToString(this.StyleID);
            int inrStyleId = Convert.ToInt32(Session["StyleId"]);
            hdnuserid.Value = Convert.ToString(ApplicationHelper.LoggedInUser.UserData.UserID);
            string Pricequoted = string.Empty;

            if (hdnuserid.Value == "99999")
            {

                txtWaste1.Attributes.Add("class", "costing-waste costing-landed-costing-percent numeric-field-without-decimal-places lightbg1");
                txtWaste1.Attributes.Add("style", "border-style:None;font-size:13px;width:30px;color:black;");
                txtWaste2.Attributes.Add("class", "costing-waste costing-landed-costing-percent numeric-field-without-decimal-places lightbg1");
                txtWaste2.Attributes.Add("style", "border-style:None;font-size:13px;width:30px;color:black;");
                txtWaste3.Attributes.Add("class", "costing-waste costing-landed-costing-percent numeric-field-without-decimal-places lightbg1");
                txtWaste3.Attributes.Add("style", "border-style:None;font-size:13px;width:30px;color:black;");
                txtWaste4.Attributes.Add("class", "costing-waste costing-landed-costing-percent numeric-field-without-decimal-places lightbg1");
                txtWaste4.Attributes.Add("style", "border-style:None;font-size:13px;width:30px;color:black;");

            }
            else
            {
                txtWaste1.Attributes.Add("class", "costing-waste costing-landed-costing-percent numeric-field-without-decimal-places do-not-allow-typing lightbg1");
                txtWaste2.Attributes.Add("class", "costing-waste costing-landed-costing-percent numeric-field-without-decimal-places do-not-allow-typing lightbg1");
                txtWaste3.Attributes.Add("class", "costing-waste costing-landed-costing-percent numeric-field-without-decimal-places do-not-allow-typing lightbg1");
                txtWaste4.Attributes.Add("class", "costing-waste costing-landed-costing-percent numeric-field-without-decimal-places do-not-allow-typing lightbg1");

            }

            if (!IsPostBack)
            {
                //ddlChargeValue.DataSource = this.CostingControllerInstance.GetChargeValue();
                //ddlChargeValue.DataValueField = "Id";
                //ddlChargeValue.DataTextField = "sam";
                //ddlChargeValue.DataBind();

                CostingObject = null;
                DataTable dt = this.CostingControllerInstance.GetCurrencyBAL();
                for (int x = 0; x <= dt.Rows.Count - 1; x++)
                {

                    if (Convert.ToInt32(dt.Rows[x]["Id"]) == 4)
                        ddlConvTo.Items.Add(new ListItem("€", Convert.ToString(dt.Rows[x]["Id"])));
                    else
                        ddlConvTo.Items.Add(new ListItem(Convert.ToString(dt.Rows[x]["CurrencySymbol"]),
                                                         Convert.ToString(dt.Rows[x]["Id"])));

                }

                SetupControls();

                if ((CostingId <= 0 && ParentCostingId <= 0) || (CostingId >= 0 && ParentCostingId <= 0) ||
                    CostingId <= 0 || (CostingId <= 0 && ParentCostingId > 0))
                    BindFormWithDefaultData();

                //hlkViewMe.Visible = String.IsNullOrEmpty(CostingObject.FileName) ? false : true;

                if (CostingId > 0)
                {
                    CostingCollection objCostingCollection = this.CostingControllerInstance.GetCosting(CostingId,Convert.ToInt32( ApplicationHelper.LoggedInUser.UserData.UserID));

                    if (objCostingCollection.Count == 0)
                    {
                        throw new Exception("Costing Id " + CostingId + " does not exists.");
                    }

                    if (objCostingCollection.Count == 2)
                    {
                        CostingObject = objCostingCollection[1];
                    }
                    else
                    {
                        CostingObject = objCostingCollection[0];
                    }
                    if (!string.IsNullOrEmpty(CostingObject.TeckFileDoc))
                    {
                        lnktackpack.NavigateUrl = ResolveUrl("~/Uploads/Style/" + CostingObject.TeckFileDoc);
                        lnktackpack.Visible = true;
                        lbltech.Visible = true;
                    }
                    Pricequoted = Convert.ToString(objCostingCollection[0].PriceQuoted);
                    hdnPriceQuoted.Value = objCostingCollection[0].PriceQuoted.ToString();
                    if (objCostingCollection[0].VerifyCosting == 1)
                        chkverifiedCosting.Visible = true;
                    else
                        chkverifiedCosting.Visible = false;
                    //hlkViewMe.NavigateUrl = "~/Uploads/Photo/" + CostingObject.FileName;
                    //hlkViewMe.Visible = String.IsNullOrEmpty(CostingObject.FileName) ? false : true;

                    //hlkViewLayFile.NavigateUrl = "~/Uploads/Photo/" + CostingObject.LayFileName;
                    //hlkViewLayFile.Visible = String.IsNullOrEmpty(CostingObject.LayFileName) ? false : true;
                    hypviewObfile.NavigateUrl = "~/Uploads/Photo/" + CostingObject.FileName;
                    hypviewObfile.Visible = CostingObject.FileName == "" ? false : true;

                    BindFormWithCostingData(CostingObject);

                    // Add by Ravi kumar on 29/7/15 for OB And SAM validation
                    if (txtPriceAgreed.Text != "")
                    {
                        txtChargesValue11.Attributes.Add("readonly", "readonly");
                        txtOB.Attributes.Add("readonly", "readonly");
                    }

                    if (objCostingCollection.Count == 2)
                    {
                        IsBIPLUserAccessingIKandiData = true;
                        ChildCostingId = objCostingCollection[1].CostingID;
                        ParentStyleId = objCostingCollection[0].StyleID;


                        BindFormWithiKandiCostingData(objCostingCollection[0]);
                    }
                    //if (Pricequoted == "" || Pricequoted == "0")
                    //{
                    //    BindFormWithDefaultData();
                    //}
                }
                else
                {
                    CostingObject = null;
                    ddlChargeValue.Items.Remove(ddlChargeValue.Items.FindByValue("-1"));
                }

                SetControlsVisibility(CostingObject.IsIkandiClient);

                if (ApplicationHelper.IsPrintRequest)
                {
                    GetParentDepartmentDropdownInformationAtPrint(ddlBuyer.SelectedValue);
                }


            }

            // txtOB.Attributes.Add("readonly", "readonly");
            // txtExpectedQuant.Attributes.Add("readonly", "readonly");
            txtQuantity.Attributes.Add("readonly", "readonly");
            // GetExpectedWastageQty("-1");
        } //GC

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string script = string.Empty;
            //if (hdnSave.Value == "0")
            //    return;
            //if (hdnClientCostingSave.Value == "1")
            //{
            //    GetCMTValue();
            //    GetCurrencyConversion();
            //}
            if (SaveCostingData())
            {
                lblMsg.Text = "Costing Sheet saved successfully.";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Visible = true;
            }
            else
            {
                script = "ShowHideValidationBox(true, 'Some error occurred in saving Costing Sheet.', 'Costing Sheet');";
            }

        }

        private void GetCMTValue(int Clientid, int Deptid)
        {
            Costing objCosting = new Costing();
            objCosting.ClientID = Clientid;
            objCosting.DepartmentID = Deptid;
            objCosting.SAM = txtChargesValue11.Text == "" ? 0 : Convert.ToDouble(txtChargesValue11.Text);
            objCosting.OB_WS = txtOB.Text == "" ? 0 : Convert.ToInt32(txtOB.Text);
            objCosting.Achivement = hdnAch.Value == "" ? 0 : Convert.ToInt32(hdnAch.Value);
            objCosting.Quantity = txtExpectedQuant.Text == "" ? 0 : Convert.ToInt32(txtExpectedQuant.Text);
            objCosting.StyleID = StyleID;
            string[] strCMTValue = CostingControllerInstance.GetCMT_Value(objCosting.SAM, objCosting.OB_WS, objCosting.Achivement, objCosting.ClientID, objCosting.DepartmentID, objCosting.StyleID, objCosting.Quantity);
            if (strCMTValue.Length > 0)
            {
                txtChargesValue1.Text = strCMTValue[0].ToString();
            }
        }

        private void GetCurrencyConversion()
        {
            double rate = CommonHelper.GetCurrencyRate((Currency)Convert.ToInt32(hdnConvertTo.Value), Currency.INR);
            txtConvRate.Text = rate.ToString();
        }

        protected void btnCostConfirmation_Click(object sender, EventArgs e)
        {
            string script = string.Empty;

            try
            {
                if (SaveCostingData())
                {

                    UserTask task = new UserTask();

                    task.AssignedToDesigntation = (int)Designation.BIPL_Sales_Manager;
                    task.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                    task.CreatedOn = DateTime.Now;
                    task.ETA = DateTime.Now.AddDays(3);
                    task.Style = new iKandi.Common.Style();
                    task.Style.StyleID = this.StyleID;
                    task.TextField2 = txtPriceQuoted.Text.ToString();
                    task.Type = UserTaskType.CostConfirmation;
                    if (rdAccept.Checked)
                        task.IntField3 = 1;
                    else
                        task.IntField3 = 0;
                    this.UserTaskControllerInstance.UpdateCostingUserTask(task);
                    task.AssignedToDesigntation = (int)Designation.iKandi_Sales_SalesManager;
                    this.UserTaskControllerInstance.InsertUserTask(task);

                    // Edit by Ashish

                    //string url = COSTING_SHEET_URL + "?cid=" + CostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();

                    //script = "ShowHideMessageBox(true, 'Costing Confirmation Request sent successfully.', 'Request Costing Confirmation', RedirectToUrl, '" + url + "');";
                    lblMsg.Text = "Costing Confirmation Request sent successfully.";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + " " + ex.StackTrace);
            }
        }

        protected void btnBIPLUpdatePrice_Click(object sender, EventArgs e)
        {
            string script = string.Empty;

            try
            {
                FLAG = 1;

                if (SaveCostingData())
                {

                    string orderIDList = this.CostingControllerInstance.UpdateBIPLPriceOnOrders(this.CostingId);

                    if (CostingPriceUpdate.ID > 0)
                    {
                        CostingPriceUpdate.ActionDate = DateTime.Now;
                        CostingPriceUpdate.ActionedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                        CostingPriceUpdate.TextField2 = txtPriceQuoted.Text.ToString();
                        if (rdAccept.Checked)
                            CostingConfirmationTask.IntField3 = 1;
                        else
                            CostingConfirmationTask.IntField3 = 0;
                        this.UserTaskControllerInstance.UpdateUserTaskForCostingAction(CostingPriceUpdate);
                    }

                    //Send Mail 
                    //DataTable DT = this.ReportControllerInstance.GetAllOrdersOnStyleNew(StyleID).Tables[0];
                    DataTable DT = this.CostingControllerInstance.Get_OrderDetailBy_StyleId(StyleID);
                    foreach (DataRow dr in DT.Rows)
                    {
                        NotificationEmailHistory NEH = new NotificationEmailHistory();
                        NEH.Type = "5";
                        NEH.EmailID = "16";
                        NEH.OrderDetailsID = dr["OrderDetailId"].ToString();
                        NEH.OrderID = dr["OrderID"].ToString();
                        if (hdnPriceQuoted.Value != null)
                            NEH.OldBIPL = Convert.ToDouble(hdnPriceQuoted.Value);
                        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    }
                    //Commented Email 22-03-2016
                    //this.NotificationControllerInstance.SendMailOrderRateChange(txtStyleNumber.Text, orderIDList);
                    //Send Mail

                    script = "showBIPLOrderPrice('" + StyleID + "')";

                    txtPriceAgreed.Text = txtPriceQuoted.Text;

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "showBIPLOrderPrice", script, true);
                }
            }
            catch (Exception ex)
            {
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + " " + ex.StackTrace);
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                script = "ShowHideValidationBox(true, 'Some error occurred in updating BIPL Price.', 'Costing Sheet');";

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            }
        }

        protected void btniKandiUpdatePriceUpdatePrice_Click(object sender, EventArgs e)
        {
            string script = string.Empty;




            try
            {
                if (SaveCostingData())
                {

                    string s = hdnConIds.Value;
                    string orderIDList = string.Empty;

                    // if (s == "")
                    orderIDList = this.CostingControllerInstance.UpdateiKandiPriceOnOrders_Old(this.CostingId, ckhAF.Checked, chkAH.Checked, ckhSF.Checked, ckhSH.Checked, ckhFOB.Checked);
                    //  else
                    // orderIDList = this.CostingControllerInstance.UpdateiKandiPriceOnOrders(s, this.CostingId, ckhAF.Checked, chkAH.Checked, ckhSF.Checked, ckhSH.Checked, ckhFOB.Checked);

                    if (ckhAF.Checked)
                        txtAFAgreedPrice.Text = txtAFQuotedPrice.Text;

                    if (chkAH.Checked)
                        txtAHAgreedPrice.Text = txtAHQuotedPrice.Text;

                    if (ckhSF.Checked)
                        txtSFAgreedPrice.Text = txtSFQuotedPrice.Text;

                    if (ckhSH.Checked)
                        txtSHAgreedPrice.Text = txtSHQuotedPrice.Text;

                    if (ckhFOB.Checked)
                        txtFOBAgreedPrice.Text = txtFOBQuotedPrice.Text;
                    hdnConIds.Value = "";
                    // script = "showAffectedOrdersOnPriceUpdate_New('" + "Updated" + "')";
                    //
                    //  ScriptManager.RegisterStartupScript(Page, typeof(Page), "showAffectedOrdersOnPriceUpdate", script, true);


                    script = "showAffectedOrdersOnPriceUpdate('" + txtStyleNumber.Text + "','" + orderIDList + "')";

                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "showAffectedOrdersOnPriceUpdate", script, true);

                }
            }
            catch (Exception ex)
            {
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + " " + ex.StackTrace);
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                script = "ShowHideValidationBox(true, 'Some error occurred in updating BIPL Price.', 'Costing Sheet');";

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            }
        }

        protected void btnCostConfirmed_Click(object sender, EventArgs e)
        {
            string script = string.Empty;

            try
            {
                if (SaveCostingData())
                {

                    if (CostingConfirmationTask.ID > 0)
                    {
                        CostingConfirmationTask.ActionDate = DateTime.Now;
                        CostingConfirmationTask.ActionedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                        CostingConfirmationTask.TextField2 = txtPriceQuoted.Text.ToString();
                        if (rdAccept.Checked)
                        {
                            CostingConfirmationTask.IntField3 = 1;
                            this.UserTaskControllerInstance.UpdateUserTaskForCostingAction(CostingConfirmationTask);
                            IkandiCostConfirmation_Click();
                            btnCostConfirmed.Visible = false;
                        }
                        else
                        {
                            CostingConfirmationTask.IntField3 = 0;
                            this.UserTaskControllerInstance.UpdateUserTaskForCostingAction(CostingConfirmationTask);
                            IkandiCostConfirmation_Click();
                            btnCostConfirmed.Visible = false;
                        }
                        // Send email mail cost confirmation stopped  COSTCONFIRMED = 47,
                        //this.NotificationControllerInstance.SendEmailForCostConfirmed(txtStyleNumber.Text, txtCostConfirmationComments.Text, rdAccept.Checked, Convert.ToDouble(txtPriceQuoted.Text), this.ClientID);
                    }

                    // Edit by Ashish
                    //string url = COSTING_SHEET_URL + "?cid=" + CostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();

                    //script = "ShowHideMessageBox(true, 'Costing Confirmed successfully.', 'Costing Confirmation', RedirectToUrl, '" + url + "');";
                    lblMsg.Text = "Costing Confirmed successfully.";
                    lblMsg.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    script = "ShowHideValidationBox(true, 'Some error occurred in updating BIPL Price.', 'Costing Sheet');";
                }
            }
            catch (Exception ex)
            {
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + " " + ex.StackTrace);
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                script = "ShowHideValidationBox(true, 'Some error occurred in confirming BIPL price.', 'Costing Sheet');";
            }

            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
        }

        protected void btnSaveIkandi_Click(object sender, EventArgs e)
        {
            string script = string.Empty;

            if (SaveCostingData())
            {
                // Edit by Ashish
                //string url = COSTING_SHEET_URL + "?cid=" + CostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();
                //script = "ShowHideMessageBox(true, 'Costing Sheet saved successfully.', 'Costing Sheet', RedirectToUrl, '" + url + "');";
                lblMsg.Text = "Costing Sheet saved successfully.";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                script = "ShowHideValidationBox(true, 'Some error occurred in saving Costing Sheet.', 'Costing Sheet');";
            }

            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {
            //System.Diagnostics.Debugger.Break();

            string script;

            if (this.CostingControllerInstance.AgreeForIKandiCostingData(ChildCostingId, CostingId, ParentStyleId))
            {
                // Edit by Ashish
                string url = COSTING_SHEET_URL + "?cid=" + ChildCostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();
                script = "ShowHideMessageBox(true, 'Agree operation executed successfully.', 'Costing Sheet', RedirectToUrl, '" + url + "');";
                lblMsg.Text = "Agree operation executed successfully.";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                script = "ShowHideMessageBox(true, 'Some error occurred in executing Agree operation.', 'Costing Sheet');";
            }

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
        }

        protected void btnDisagree_Click(object sender, EventArgs e)
        {
            string script = string.Empty;

            if (this.CostingControllerInstance.DisagreeForIKandiCostingData(ChildCostingId, CostingId, ParentStyleId))
            {
                // Edit by Ashish
                string url = COSTING_SHEET_URL + "?cid=" + CostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();
                script = "ShowHideMessageBox(true, 'Disagree operation executed successfully.', 'Costing Sheet', RedirectToUrl, '" + url + "');";
                lblMsg.Text = "Disagree operation executed successfully.";
                lblMsg.ForeColor = System.Drawing.Color.Green;

                //Page.Response.Redirect(Page.Request.Url.ToString(), true);
            }
            else
            {
                script = "ShowHideMessageBox(true, 'Some error occurred in executing Disagree operation.', 'Costing Sheet');";
            }

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=CostingSheet.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            Response.ContentEncoding = Encoding.Default;
            string str = hfexcelval.Value;
            str = str.Replace("~!", "<");
            str = str.Replace("!~", ">");
            str = str.Replace("DIRECT COST (+)", "");
            Response.Write(str);
            Response.End();
        }

        protected void btnAcknowledgment_Click(object sender, EventArgs e)
        {
            //bool IsConfirm = this.WorkflowControllerInstance.Update_userTaskFor_Acknowledgment(14, StyleID, -1, DateTime.Now, ApplicationHelper.LoggedInUser.UserData.UserID);
            int IsConfirm = WorkflowControllerInstance.Close_AcknowledgeTask(this.StyleID, TaskMode.Acknowledgement_Costing, ApplicationHelper.LoggedInUser.UserData.UserID);
            if (IsConfirm == 1)
            {
                lblMsg.Text = "Acknowledge Confirmed.";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
        }

        #endregion

        #region Private Methods

        private void SetupControls()
        {
            DropdownHelper.BindZipDetails(ddlAccessoriesItem4);
            DropdownHelper.BindZipSize(ddlAccessoriesRate4);

            DropdownHelper.BindAllClients(ddlBuyer);
            ddlBuyer.Items.Insert(0, string.Empty);

            ddlPrintType1.SelectedIndex =
                ddlPrintType2.SelectedIndex = ddlPrintType3.SelectedIndex = ddlPrintType4.SelectedIndex = 1;

            txtPriceQuoted.DataBind();

            Common.Style styleForGarmetCode = this.StyleControllerInstance.GetStyleByStyleId(this.StyleID);
            if (styleForGarmetCode != null && !string.IsNullOrEmpty(styleForGarmetCode.StyleNumber) &&
                styleForGarmetCode.StyleNumber.Length > 2)
            {
                string code = styleForGarmetCode.StyleNumber.Substring(0, 2).ToUpper();
                lblGarmetType.Text = this.CostingControllerInstance.GetGarmentNameOption(code);
            }
            hdnBuyingHouse.Text = styleForGarmetCode.IsIkandiClient.ToString();

            if (Role == 0 && styleForGarmetCode != null && !string.IsNullOrEmpty(styleForGarmetCode.StyleNumber) &&
                styleForGarmetCode.StyleNumber.IndexOf("$") > -1)
            {
                hypOrdersByVariations.Visible = true;
                hypOrdersByVariations.NavigateUrl = "javascript:void(0)";
                hypOrdersByVariations.Attributes.Remove("onclick");
                hypOrdersByVariations.Attributes.Add("onclick",
                                                     "LaunchExistingOrdersByStyleVariation(" + this.CostingId.ToString() +
                                                     ",'" + styleForGarmetCode.StyleNumber + "');return false;");
            }
            else
            {
                hypOrdersByVariations.Visible = false;
            }
            hlinkSAM.Visible = true;
            hlinkSAM.NavigateUrl = "~/Internal/OrderProcessing/OrderProcessFlow.aspx?styleid=" + StyleID + "&stylenumber=" + styleForGarmetCode.StyleNumber + "&FitsStyle=&StyleCode=" + styleForGarmetCode.StyleNumber + "&ClientID=" + ClientID + "&DeptId=" + DepartmentID + "&showOBFORM=Yes";
            GetMakingDropdownInformation();
            ddlMaking.Items.Insert(0, "Select");
            //Add By Prabhaker//
            string stylecode = string.Empty;
            stylecode = this.StyleControllerInstance.GetStyleByCode(this.StyleID);
            hdStyleCOdeValue.Value = stylecode;


            //hdnCostingId.Value = this.CostingControllerInstance.bCheck_Update_Price_Visibilty(CostingId);

            // Edit by surendra on 19 Feb 2013
            //if (Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID) == 5 || Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID) == 6 || Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID) == 15 || Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID) == 145 || Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID) == 8)
            //{
            //    tdOverHeadValue.Style.Add("display", "");
            //    tdOverHead.Style.Add("display", "");
            //}
            //if (Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID) == 5 || Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID) == 6 || Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID) == 8 || Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID) == 15 || Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID) == 145)
            //{
            //    tdDC.Style.Add("display", "");
            //    tdDCValue.Style.Add("display", "");
            //}

            //---------------------------------------------------------------
        } //GC

        /// <summary>
        /// Called after Costing object is read from DB
        /// </summary>
        private void SetControlsVisibility(int IsIkandiClient)
        {
            string pairedCosting = string.Empty;
            bool bCheckVisibilty = false;
            //if (IsUcknowledge == 1)
            //{
            //    btnAcknowledgment.Visible = true;
            //}
            if (CostingId != -1)
            {
                bCheckVisibilty = this.CostingControllerInstance.bCheck_Update_Price_Visibilty(CostingId);
                pairedCosting = this.CostingControllerInstance.GetPairedCosting(CostingId);
                if (pairedCosting == "")
                    lblPairedCosting.Text = "No Costing Paired";
                else
                    lblPairedCosting.Text = "Paired Costing :<span style='color:black;'>" + pairedCosting + "</span>";
            }
            else
            {
                lblPairedCosting.Visible = false;
            }
            if (Role == 1 && IsIkandiClient == 1)
            {
                divIKandi.Visible = true;
                btnCostConfirmed.Visible = (CostingConfirmationTask.ID > 0) && PermissionHelper.IsWritePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_COST);
                btnSave.Visible = false;
                btnUpdatePrice.Visible = false;
                btnCostConfirmation.Visible = false;
                btnBIPLHistory.Visible = true;
                btniKandiHistory.Visible = true;
                btnBIPLPrint.Visible = false;
            }
            else
            {
                divIKandi.Visible = false;
                btnUpdatePrice.Visible = (CostingId > 0) && PermissionHelper.IsWritePermittedOnColumn((int)AppModuleColumn.COSTING_UPDATE_PRICE_BIPL);
                //updated by abhishek 7/6/2016
                //btnSave.Visible = true;<== old code
                btnSave.Visible = PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_SUBMIT);
                btnCostConfirmation.Visible = (CostingId > 0) && (CostingConfirmationTask.ID == 0);
                btnCostConfirmation.Visible = (CostingId > 0) && PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_REQUEST_COST_CONFIRMATION);
                //end 

                lblCostConfirmationRequestText.Visible = (CostingConfirmationTask.ID > 0 || CostingConfirmedTask.ID > 0);

                if (CostingConfirmationTask.ID > 0)
                    lblCostConfirmationRequestText.Text = string.Format("Cost confirmation requested by {0} for {1} {2} on {3}", CostingConfirmationTask.CreatedByUsername, ddlConvTo.SelectedItem.Text, CostingConfirmationTask.TextField2, CostingConfirmationTask.CreatedOn.ToString("dd MMM yy (ddd)"));
                else if (CostingConfirmedTask.ID > 0)
                {
                    if (CostingConfirmedTask.IntField3 == 1)
                        lblCostConfirmationRequestText.Text = string.Format("Cost confirmed by {0} for {1} {2} on {3}", CostingConfirmedTask.ActionedByUsername, ddlConvTo.SelectedItem.Text, CostingConfirmedTask.TextField2, CostingConfirmedTask.ActionDate.ToString("dd MMM yy (ddd)"));
                    else
                        lblCostConfirmationRequestText.Text = string.Format("Cost Decline by {0} for {1} {2} on {3}", CostingConfirmedTask.ActionedByUsername, ddlConvTo.SelectedItem.Text, CostingConfirmedTask.TextField2, CostingConfirmedTask.ActionDate.ToString("dd MMM yy (ddd)"));
                }

                btnBIPLHistory.Visible = true;
                btniKandiHistory.Visible = false;
                btnBIPLPrint.Visible = true;
            }

            if (IsBIPLUserAccessingIKandiData)
            {
                radioBtnAgree.Visible = true;
                btnAgree.Visible = true;
                btnDisagree.Visible = true;

                btnSave.Visible = false;
                btnUpdatePrice.Visible = false;
                btnCostConfirmation.Visible = false;
            }
            else
            {
                radioBtnAgree.Visible = false;
                btnAgree.Visible = false;
                btnDisagree.Visible = false;
                //if (Convert.ToString(ViewState["pcid"]) != "-1" || ViewState["pcid"] !=null)
                //    btnSave.Visible = false;
                if (ViewState["pcid"] == null)
                {
                    btnSave.Visible = true;
                }
                else
                {
                    if (Convert.ToString(ViewState["pcid"]) != "-1")
                        btnSave.Visible = false;
                    else
                        if ((ApplicationHelper.LoggedInUser.UserData.DesignationID == 102) || (ApplicationHelper.LoggedInUser.UserData.DesignationID == 4))
                            btnSave.Visible = false;
                        else
                            btnSave.Visible = true;
                }



            }

            PendingCostingMsg.Visible = false;

            if (Role == 1)
            {
                if (Convert.ToString(CostingObject.PriceQuoted) == "0" && CostingObject.ParentCostingID == -1 && CostingObject.IsVersion == false)
                {
                    divIKandi.Visible = false;
                    BIPLCosting.Visible = false;
                    PendingCostingMsg.Visible = true;
                }
                else if (Convert.ToString(CostingObject.PriceQuoted) == "0" && CostingObject.ParentCostingID != -1 && CostingObject.IsVersion == false)
                {
                    divIKandi.Visible = false;
                    BIPLCosting.Visible = false;
                    PendingCostingMsg.Visible = true;
                }
            }
            else
            {
                int checkshowhide = CostingControllerInstance.Check_UpdateBiplPrice_ShowHide(CostingObject.CostingID);
                if (checkshowhide == 0)
                {
                    btnUpdatePrice.Visible = false;
                }
            }

            //if (Role == 1 && CostingObject.CurrentStatusID <= (int)TaskMode.COSTEDBIPL)
            //{
            //    divIKandi.Visible = false;
            //    BIPLCosting.Visible = false;
            //    PendingCostingMsg.Visible = true;
            //}

            if (IsIkandiClient != 1)
            {
                btnCostConfirmation.Visible = false;
            }
        }

        private void BindFormWithDefaultData()
        {
            //string itemValue = string.Empty;
            DataTable dtClientCosting = new DataTable();
            // Change By Ravi kumar on 9/9/2014          
            dtClientCosting = AdminControllerInstance.GetClientCosting_By_Client_Dept(this.ClientID, this.DepartmentID,this.StyleID);

            if (CostingId <= 0)
            {
                txtChargesName4.Text = dtClientCosting.Rows[0]["ApplicableCoffinBox"].ToString();
                //itemValue = CommonHelper.GetClientCostingDefaultValue(this.ClientID, this.DepartmentID, ClientCostingItem.FINISH);

                //txtChargesValue4.Text = dtClientCosting.Rows[0]["COFFIN_BOX"].ToString(); // (itemValue != string.Empty) ? itemValue : "0";//Coffin box default value changed from 5 to 0
                txtChargesValue4.Text = dtClientCosting.Rows[0]["ApplicableCoffinBoxValue"].ToString();

                txtChargesValue2.Text = "";//(itemValue != string.Empty) ? itemValue : "0";

                //itemValue = CommonHelper.GetClientCostingDefaultValue(this.ClientID, this.DepartmentID, ClientCostingItem.LBL_TAGS);

                txtChargesValue3.Text = dtClientCosting.Rows[0]["LBL_TAGS"].ToString(); // (itemValue != string.Empty) ? itemValue : "20";

                //itemValue = CommonHelper.GetClientCostingDefaultValue(this.ClientID, this.DepartmentID, ClientCostingItem.TEST);

                txtChargesValue5.Text = dtClientCosting.Rows[0]["TEST"].ToString(); // (itemValue != string.Empty) ? itemValue : "5";

                //itemValue = CommonHelper.GetClientCostingDefaultValue(this.ClientID, this.DepartmentID, ClientCostingItem.HANGERS);

                txtChargesValue6.Text = dtClientCosting.Rows[0]["HANGERS"].ToString();


                if (this.ClientID == 2)
                    txtAccessoriesQuantity7.Text = "";// "1";
                else
                    txtAccessoriesQuantity7.Text = "1";


                //itemValue = CommonHelper.GetClientCostingDefaultValue(this.ClientID, this.DepartmentID, ClientCostingItem.HANGER_LOOPS);


                if (this.ClientID == 2)
                {
                    txtAccessoriesRate7.Text = dtClientCosting.Rows[0]["HANGERLOOPS"].ToString(); //(itemValue != string.Empty && itemValue != "0") ? itemValue : "";// "1.00";

                    if (txtAccessoriesRate7.Text == "")
                    {
                        txtAccessoriesAmount7.Text = "";
                    }
                    else
                        if (txtAccessoriesQuantity7.Text == "")
                        {
                            txtAccessoriesAmount7.Text = (Convert.ToInt32("0") * Convert.ToDouble(txtAccessoriesRate7.Text)).ToString("#.00");
                        }
                        else
                        {
                            txtAccessoriesAmount7.Text = (Convert.ToInt32(txtAccessoriesQuantity7.Text) * Convert.ToDouble(txtAccessoriesRate7.Text)).ToString("#.00");
                        }
                }
                else
                {
                    txtAccessoriesRate7.Text = dtClientCosting.Rows[0]["HANGERLOOPS"].ToString() == "0" ? "1.00" : dtClientCosting.Rows[0]["HANGERLOOPS"].ToString(); //(itemValue != string.Empty) ? itemValue : "1.00";
                    txtAccessoriesAmount7.Text = (Convert.ToInt32(txtAccessoriesQuantity7.Text) * Convert.ToDouble(txtAccessoriesRate7.Text)).ToString("#.00");
                }
            }

            if (ParentCostingId <= 0)
            {
                txtAFModeCost.Text = txtAHModeCost.Text = Constants.GetDefaultModeCost("a/f").ToString();
                txtSFModeCost.Text = txtSHModeCost.Text = Constants.GetDefaultModeCost("s/f").ToString();

                txtAFDuty.Text = txtAHDuty.Text = txtSFDuty.Text = txtSHDuty.Text = "10";

                txtAFHandling.Text = txtAHHandling.Text = txtSFHandling.Text = txtSHHandling.Text = "0.15";
                txtAFDelivery.Text = txtAHDelivery.Text = txtSFDelivery.Text = txtSHDelivery.Text = "0.15";

                txtAHProcessing.Text = txtSHProcessing.Text = "0.60";

                txtAFMargin.Text = txtAHMargin.Text = txtSFMargin.Text = txtSHMargin.Text = "22";

                txtAFModeDelivery.Text = CommonHelper.GetDefaultLeadTime("A/F").ToString();
                txtAHModeDelivery.Text = CommonHelper.GetDefaultLeadTime("A/H").ToString();
                txtSFModeDelivery.Text = CommonHelper.GetDefaultLeadTime("S/F").ToString();
                txtSHModeDelivery.Text = CommonHelper.GetDefaultLeadTime("S/H").ToString();
                txtFOBModeDelivery.Text = CommonHelper.GetDefaultLeadTime("FOB").ToString();

                txtAFExpectedBookingDate.Text = txtAHExpectedBookingDate.Text = txtSFExpectedBookingDate.Text =
                txtSHExpectedBookingDate.Text = txtFOBBookingDate.Text = DateHelper.GetNextMondayDate();
            }

            txtConvRate.Text = BLLCache.GetConfigurationKeyValue("CONVERSION_RATE");

            // itemValue = CommonHelper.GetClientCostingDefaultValue(this.ClientID, this.DepartmentID, ClientCostingItem.CONVERSION_TO);


            ddlConvTo.SelectedValue = dtClientCosting.Rows[0]["CONVERSIONTO"].ToString(); // itemValue;
            hdnConvertTo.Value = dtClientCosting.Rows[0]["CONVERSIONTO"].ToString();

            if (!string.IsNullOrEmpty(dtClientCosting.Rows[0]["CONVERSIONTO"].ToString()))
            {
                double rate = CommonHelper.GetCurrencyRate((Currency)Convert.ToInt32(dtClientCosting.Rows[0]["CONVERSIONTO"].ToString()), Currency.INR);
                txtConvRate.Text = rate.ToString();
            }

            //if (string.IsNullOrEmpty(txtConvRate.Text) || txtConvRate.Text == "1")
            //    txtConvRate.Text = "65";

            if (string.IsNullOrEmpty(txtConvRate.Text))
                txtConvRate.Text = "65";

            //itemValue = CommonHelper.GetClientCostingDefaultValue(this.ClientID, this.DepartmentID, ClientCostingItem.MARKUP_ON_UNIT_CTC);

            txtMarkupOnUnitCtc.Text = dtClientCosting.Rows[0]["PROFITMARGIN"].ToString();  //(itemValue != string.Empty) ? itemValue : "7";

            //itemValue = CommonHelper.GetClientCostingDefaultValue(this.ClientID, this.DepartmentID, ClientCostingItem.OVERHEAD);

            txtOverHead.Text = dtClientCosting.Rows[0]["OVERHEADCOST"].ToString();  //(itemValue != string.Empty) ? itemValue : "0";

            DataTable dtClientCosting_ExpectedQty = new DataTable();
            //// Change By Ravi kumar on 9/9/2014          
            dtClientCosting_ExpectedQty = AdminControllerInstance.GetClientCosting_By_Client_Dept_ForExpectedQty(this.ClientID, this.DepartmentID, 0);
            ddlExpectedQty.DataSource = dtClientCosting_ExpectedQty;
            ddlExpectedQty.DataTextField = "EXPECTEDQTY";
            ddlExpectedQty.DataValueField = "ExpectedValue";
            ddlExpectedQty.DataBind();
            ddlExpectedQty.SelectedValue = dtClientCosting.Rows[0]["EXPECTEDQTY"].ToString();
            //txtFrtUptoPort.Text = "10";
            txtFrtUptoPort.Text = dtClientCosting.Rows[0]["FRTUPTOPORT"].ToString();
            txtFrtUptoFinalDest.Text = dtClientCosting.Rows[0]["Costing_waste"].ToString();
            //txtOB.Text = "40";

            hdnAch.Value = dtClientCosting.Rows[0]["ACHIEVEMENT"].ToString();
            //Added by ashish ON 26/2/2014
            //if (this.ClientID == 2)
            //{
            //itemValue = CommonHelper.GetClientCostingDefaultValue(this.ClientID, this.DepartmentID, ClientCostingItem.DESIGNCOMMISSION);

            txtDesingCommission.Text = dtClientCosting.Rows[0]["DESIGNCOMM"].ToString(); // (itemValue != string.Empty) ? itemValue : "10";
            //}
            //else
            //{
            //    itemValue = CommonHelper.GetClientCostingDefaultValue(this.ClientID, this.DepartmentID, ClientCostingItem.DESIGNCOMMISSION);
            //    txtDesingCommission.Text = (itemValue != string.Empty) ? itemValue : "0";
            //}

            // itemValue = CommonHelper.GetClientCostingDefaultValue(this.ClientID, this.DepartmentID, ClientCostingItem.COMMISION);
            txtComm.Text = dtClientCosting.Rows[0]["COMMISION"].ToString(); // (itemValue != string.Empty) ? itemValue : "10";


            //txtChargesValue4.Text = dtClientCosting.Rows[0]["COFFIN_BOX"].ToString();

            //txtChargesValue2.Text = "";//(itemValue != string.Empty) ? itemValue : "0";

            ////itemValue = CommonHelper.GetClientCostingDefaultValue(this.ClientID, this.DepartmentID, ClientCostingItem.LBL_TAGS);

            //txtChargesValue3.Text = dtClientCosting.Rows[0]["LBL_TAGS"].ToString(); // (itemValue != string.Empty) ? itemValue : "20";

            ////itemValue = CommonHelper.GetClientCostingDefaultValue(this.ClientID, this.DepartmentID, ClientCostingItem.TEST);

            //txtChargesValue5.Text = dtClientCosting.Rows[0]["TEST"].ToString(); // (itemValue != string.Empty) ? itemValue : "5";

            ////itemValue = CommonHelper.GetClientCostingDefaultValue(this.ClientID, this.DepartmentID, ClientCostingItem.HANGERS);

            //txtChargesValue6.Text = dtClientCosting.Rows[0]["HANGERS"].ToString();

            //GetCMTValue(this.ClientID, this.DepartmentID);
        }//GC

        private void AddFabricCostings(ref Costing objCosting)
        {
            if (null == objCosting.FabricCostingItems)
                objCosting.FabricCostingItems = new List<FabricCosting>();

            for (int i = 1; i <= 4; i++)
            {
                DropDownList ddlPrintType = tblCostingDetails.FindControl("ddlPrintType" + i) as DropDownList;
                TextBox txtFabric = tblCostingDetails.FindControl("txtFabric" + i) as TextBox;
                TextBox txtWidth = tblCostingDetails.FindControl("txtWidth" + i) as TextBox;
                TextBox txtAverage = tblCostingDetails.FindControl("txtAverage" + i) as TextBox;
                TextBox txtRate = tblCostingDetails.FindControl("txtRate" + i) as TextBox;
                TextBox txtAmount = tblCostingDetails.FindControl("txtAmount" + i) as TextBox;
                TextBox txtWaste = tblCostingDetails.FindControl("txtWaste" + i) as TextBox;
                TextBox txtTotal = tblCostingDetails.FindControl("txtTotal" + i) as TextBox;
                HiddenField hdnIsAir = tblCostingDetails.FindControl("hiddenRadioMode" + i) as HiddenField;
                Image img = tblCostingDetails.FindControl("imgFab" + i) as Image;
                FileUpload UploadLayFile = tblCostingDetails.FindControl("LayFile" + i) as FileUpload;
                HyperLink lnkLayFile = tblCostingDetails.FindControl("viewolay" + i) as HyperLink;
                //Added by uday
                HyperLink ViewCad = tblCostingDetails.FindControl("ViewCad" + i) as HyperLink;
                HyperLink ViewStc = tblCostingDetails.FindControl("ViewStc" + i) as HyperLink;

                //End by uday

                if (ddlPrintType.SelectedIndex > 0 && txtFabric.Text.Trim() != string.Empty)
                {
                    FabricCosting objFabricCosting = new FabricCosting();
                    objFabricCosting.CostingQueryType = QueryType.Insert;

                    objFabricCosting.PrintType = ddlPrintType.SelectedValue;
                    objFabricCosting.Fabric = txtFabric.Text;
                    if (i == 1)
                    {
                        // objFabricCosting.FabricType = txtFabricType1.Value;
                        if (txtFabricType1.Value.Contains(" --- "))
                        {
                            string str = txtFabricType1.Value.Replace(" --- ", "#");
                            string[] s1 = str.Split('#');
                            objFabricCosting.FabricType = s1[1];
                        }
                        else if (txtFabricType1.Value.Contains("("))
                        {
                            string[] s1 = txtFabricType1.Value.Split('(');
                            objFabricCosting.FabricType = s1[0];
                        }
                        else
                            objFabricCosting.FabricType = txtFabricType1.Value;

                    }
                    if (i == 2)
                    {
                        if (txtFabricType2.Value.Contains(" --- "))
                        {
                            string str = txtFabricType2.Value.Replace(" --- ", "#");
                            string[] s1 = str.Split('#');
                            objFabricCosting.FabricType = s1[1];
                        }
                        else if (txtFabricType2.Value.Contains("("))
                        {
                            string[] s1 = txtFabricType2.Value.Split('(');
                            objFabricCosting.FabricType = s1[0];
                        }
                        else
                            objFabricCosting.FabricType = txtFabricType2.Value;
                    }
                    if (i == 3)
                    {
                        if (txtFabricType3.Value.Contains(" --- "))
                        {
                            string str = txtFabricType3.Value.Replace(" --- ", "#");
                            string[] s1 = str.Split('#');
                            objFabricCosting.FabricType = s1[1];
                        }
                        else if (txtFabricType3.Value.Contains("("))
                        {
                            string[] s1 = txtFabricType3.Value.Split('(');
                            objFabricCosting.FabricType = s1[0];
                        }
                        else
                            objFabricCosting.FabricType = txtFabricType3.Value;
                    }
                    if (i == 4)
                    {
                        if (txtFabricType4.Value.Contains(" --- "))
                        {
                            string str = txtFabricType4.Value.Replace(" --- ", "#");
                            string[] s1 = str.Split('#');
                            objFabricCosting.FabricType = s1[1];
                        }
                        else if (txtFabricType4.Value.Contains("("))
                        {
                            string[] s1 = txtFabricType4.Value.Split('(');
                            objFabricCosting.FabricType = s1[0];
                        }
                        else
                            objFabricCosting.FabricType = txtFabricType4.Value;
                    }
                    objFabricCosting.Width = (txtWidth.Text == string.Empty) ? 0 : Convert.ToDouble(txtWidth.Text);
                    objFabricCosting.Average = (txtAverage.Text == string.Empty) ? 0 : Convert.ToDouble(txtAverage.Text);
                    objFabricCosting.Rate = (txtRate.Text == string.Empty) ? 0 : Convert.ToDouble(txtRate.Text);
                    objFabricCosting.Amount = (txtAmount.Text == string.Empty) ? 0 : Convert.ToDouble(txtAmount.Text);
                    //objFabricCosting.Waste = (txtWaste.Text == string.Empty) ? 0 : Convert.ToDouble(txtWaste.Text);
                    objFabricCosting.Total = (txtTotal.Text == string.Empty) ? 0 : Convert.ToDouble(txtTotal.Text);
                    objFabricCosting.IsAir = (hdnIsAir.Value == "1") ? true : false;
                    objFabricCosting.SequenceNumber = i;
                    objFabricCosting.isMultiple = img.Visible == false ? "N" : "Y";
                    //abhishek 9/8/2016
                    DateTime dt = DateTime.Now;
                    string s = String.Format("{0:G}", dt);
                    s = s.Replace(" ", "_");
                    s = s.Replace(':', '/');
                    s = s.Replace('/', '-');

                    string stringLayFileName = UploadLayFile.FileName;
                    string sLayFileName = lnkLayFile.NavigateUrl.ToString();
                    string Exten = System.IO.Path.GetExtension(UploadLayFile.FileName);
                    if (UploadLayFile.HasFile)
                    {
                        string timestamp = DateTime.Now.ToString("hh.mm.ss.ffffff");
                        if (txtStyleNumber.Text != "")
                        {
                            stringLayFileName = i.ToString() + "_CAD_" + timestamp + "_" + txtStyleNumber.Text.ToUpper() + Exten;
                        }
                        else
                        {
                            stringLayFileName = i.ToString() + "_CAD_" + s + timestamp + "_" + Exten;

                        }
                        UploadLayFile.SaveAs(Server.MapPath("~/Uploads/Photo/") + stringLayFileName);
                        objFabricCosting.LayFileName = stringLayFileName == "" ? "" : stringLayFileName;
                    }
                    else
                    {
                        if (sLayFileName != "")
                        {
                            string[] sName = sLayFileName.Split(new char[] { '/' });
                            sLayFileName = sName[3].ToString();
                            objFabricCosting.LayFileName = sLayFileName == "" ? "" : sLayFileName;
                        }
                    }

                    objCosting.FabricCostingItems.Add(objFabricCosting);
                    //end by abhishek 
                }
            }
        }

        private void AddCharges(ref Costing objCosting)
        {
            if (null == objCosting.ChargesItems)
                objCosting.ChargesItems = new List<Charges>();

            for (int i = 1; i <= 11; i++)
            {
                Charges objCharges = new Charges();
                TextBox txtChargesName = tblCostingDetails.FindControl("txtChargesName" + (i == 11 ? 10 : i)) as TextBox;

                TextBox txtChargesValue = tblCostingDetails.FindControl("txtChargesValue" + (i == 11 ? 10 : i)) as TextBox;
                if (i == 11)
                    if (txtChargesValue.Text == string.Empty)
                        txtChargesValue.Text = "0";
                //if (i == 11)
                //        {
                //            objCharges.CostingQueryType = QueryType.Insert;
                //            objCharges.ChargeName = i == 11 ? "SAM Value" : txtChargesName.Text;

                //            objCharges.SequenceNumber = i;
                //            bool b;
                //          //  b = "MANUAL".Contains(txtChargesValue.Text.ToUpper());
                //            b = "MANUAL".Contains(ddlChargeValue.SelectedItem.Text.ToUpper());
                //            if (b)
                //            {
                //                objCharges.ChargeValue = -1;
                //            }
                //            else
                //            {
                //             //   objCharges.ChargeValue = (txtChargesValue.Text == string.Empty) ? 0 : Convert.ToInt32(txtChargesValue.Text);

                //                objCharges.ChargeValue = Convert.ToInt32(ddlChargeValue.SelectedValue); // (txtChargesValue.Text == string.Empty) ? 0 : Convert.ToInt32(txtChargesValue.Text);
                //            }
                //            objCosting.ChargesItems.Add(objCharges);
                //        }
                if (((null != txtChargesName && txtChargesName.Text != string.Empty)) && txtChargesValue.Text != string.Empty)
                {

                    if (!(i == 6 && (txtChargesValue.Text == string.Empty || txtChargesValue.Text.Trim() == "0")))
                    {
                        objCharges.CostingQueryType = QueryType.Insert;
                        objCharges.ChargeName = i == 11 ? "SAM Value" : txtChargesName.Text;

                        objCharges.SequenceNumber = i;

                        if (i == 11)
                        {
                            bool b;
                            //  b = "MANUAL".Contains(txtChargesValue.Text.ToUpper());
                            b = "MANUAL".Contains(txtChargesValue11.Text.ToUpper());
                            if (b)
                            {
                                objCharges.ChargeValue = -1;
                            }
                            if (txtChargesValue11.Text == "NaN")
                            {
                                objCharges.ChargeValue = -1;
                            }
                            else
                            {
                                //   objCharges.ChargeValue = (txtChargesValue.Text == string.Empty) ? 0 : Convert.ToInt32(txtChargesValue.Text);
                                objCharges.ChargeValue = Convert.ToDouble(txtChargesValue11.Text.ToUpper()); // (txtChargesValue.Text == string.Empty) ? 0 : Convert.ToInt32(txtChargesValue.Text);
                            }
                        }
                        else
                            objCharges.ChargeValue = (txtChargesValue.Text == string.Empty) ? 0 : Convert.ToDouble(txtChargesValue.Text);
                        if ((i == 10) && (txtChargesName.Text == "MACHINE EMB.") && (txtChargesValue.Text == "0"))
                        {
                        }
                        else
                        {
                            objCosting.ChargesItems.Add(objCharges);
                        }

                    }
                }
            }
        }

        private void AddAccessories(ref Costing objCosting)
        {
            if (null == objCosting.AccessoryItems)
                objCosting.AccessoryItems = new List<Accessories>();

            for (int i = 1; i <= 10; i++)
            {
                TextBox txtAccessoriesItem = null;
                TextBox txtAccessoriesQuantity = null;
                TextBox txtAccessoriesRate = null;
                TextBox txtAccessoriesAmount = null;

                if (i != 4)
                {
                    txtAccessoriesItem = tblCostingDetails.FindControl("txtAccessoriesItem" + i) as TextBox;
                    txtAccessoriesQuantity = tblCostingDetails.FindControl("txtAccessoriesQuantity" + i) as TextBox;
                    txtAccessoriesRate = tblCostingDetails.FindControl("txtAccessoriesRate" + i) as TextBox;
                }

                txtAccessoriesAmount = tblCostingDetails.FindControl("txtAccessoriesAmount" + i) as TextBox;

                if ((i == 4 && ddlAccessoriesItem4.SelectedIndex > 0 && ddlAccessoriesQuantity4.SelectedIndex > 0) ||
                    (null != txtAccessoriesItem && txtAccessoriesItem.Text != string.Empty && txtAccessoriesQuantity.Text != string.Empty))
                {
                    Accessories objAccessories = new Accessories();
                    objAccessories.CostingQueryType = QueryType.Insert;

                    if (i == 4)
                    {
                        objAccessories.Item = ddlAccessoriesItem4.SelectedValue;
                        objAccessories.Quantity = Convert.ToInt32(ddlAccessoriesQuantity4.SelectedValue);
                        objAccessories.Rate = Convert.ToDouble(ddlAccessoriesRate4.SelectedValue);
                    }
                    else
                    {
                        objAccessories.Item = txtAccessoriesItem.Text;
                        objAccessories.Quantity = (txtAccessoriesQuantity.Text == string.Empty) ? 0 : Convert.ToDouble(txtAccessoriesQuantity.Text);
                        objAccessories.Rate = (txtAccessoriesRate.Text == string.Empty) ? 0 : Convert.ToDouble(txtAccessoriesRate.Text);
                    }

                    objAccessories.Amount = (txtAccessoriesAmount.Text == string.Empty) ? 0 : Convert.ToDouble(txtAccessoriesAmount.Text);
                    objAccessories.SequenceNumber = i;

                    if (i == 9)
                        objAccessories.AccessoryPercent = (ddlAccessoriesPercent1.SelectedValue == "-1") ? 0 : Convert.ToInt32(ddlAccessoriesPercent1.SelectedValue);
                    else if (i == 10)
                        objAccessories.AccessoryPercent = (ddlAccessoriesPercent2.SelectedValue == "-1") ? 0 : Convert.ToInt32(ddlAccessoriesPercent2.SelectedValue);
                    else
                        objAccessories.AccessoryPercent = 0;

                    objCosting.AccessoryItems.Add(objAccessories);
                }
            }
        }

        private void AddLandedCosting(ref Costing objCosting)
        {
            if (null == objCosting.LandedCostingItems)
                objCosting.LandedCostingItems = new List<LandedCosting>();

            string context = string.Empty;

            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        context = "AF";
                        break;

                    case 2:
                        context = "AH";
                        break;

                    case 3:
                        context = "SF";
                        break;

                    case 4:
                        context = "SH";
                        break;
                }

                TextBox txtFobBoutique = tblCostingDetails.FindControl("txt" + context + "FobBoutique") as TextBox;
                TextBox txtFobIkandi = tblCostingDetails.FindControl("txt" + context + "FobIkandi") as TextBox;
                TextBox txtModeCost = tblCostingDetails.FindControl("txt" + context + "ModeCost") as TextBox;
                TextBox txtDuty = tblCostingDetails.FindControl("txt" + context + "Duty") as TextBox;
                TextBox txtHandling = tblCostingDetails.FindControl("txt" + context + "Handling") as TextBox;
                TextBox txtDelivery = tblCostingDetails.FindControl("txt" + context + "Delivery") as TextBox;
                TextBox txtProcessing = tblCostingDetails.FindControl("txt" + context + "Processing") as TextBox;
                TextBox txtMargin = tblCostingDetails.FindControl("txt" + context + "Margin") as TextBox;
                TextBox txtDiscount = tblCostingDetails.FindControl("txt" + context + "Discount") as TextBox;
                TextBox txtGrandTotal = tblCostingDetails.FindControl("txt" + context + "GrandTotal") as TextBox;
                TextBox txtQuotedPrice = tblCostingDetails.FindControl("txt" + context + "QuotedPrice") as TextBox;
                TextBox txtAgreedPrice = tblCostingDetails.FindControl("txt" + context + "AgreedPrice") as TextBox;
                TextBox txtModeDeliveryTime = tblCostingDetails.FindControl("txt" + context + "ModeDelivery") as TextBox;
                TextBox txtExpectedBookingDate = tblCostingDetails.FindControl("txt" + context + "ExpectedBookingDate") as TextBox;
                TextBox txtCalculatedDeliveryDate = tblCostingDetails.FindControl("txt" + context + "CalculatedDeliveryDate") as TextBox;

                if (txtFobBoutique.Text != string.Empty && txtFobIkandi.Text != string.Empty)
                {
                    LandedCosting objLandedCosting = new LandedCosting();
                    objLandedCosting.CostingQueryType = QueryType.Insert;
                    objLandedCosting.Mode = context;
                    objLandedCosting.FOBBoutique = txtFobBoutique.Text;
                    objLandedCosting.FOBIkandi = txtFobIkandi.Text;
                    objLandedCosting.ModeCost = txtModeCost.Text;
                    objLandedCosting.Duty = txtDuty.Text;
                    objLandedCosting.Handling = txtHandling.Text;
                    objLandedCosting.Delivery = txtDelivery.Text;
                    objLandedCosting.Processing = txtProcessing.Text;
                    objLandedCosting.Margin = (txtMargin.Text == string.Empty) ? 0 : Convert.ToDouble(txtMargin.Text);
                    objLandedCosting.Discount = (txtDiscount.Text == string.Empty) ? 0 : Convert.ToDouble(txtDiscount.Text);
                    objLandedCosting.GrandTotal = (txtGrandTotal.Text == string.Empty) ? 0 : Convert.ToDouble(txtGrandTotal.Text);
                    objLandedCosting.QuotedPrice = (txtQuotedPrice.Text == string.Empty) ? 0 : Convert.ToDouble(txtQuotedPrice.Text);
                    objLandedCosting.AgreedPrice = (txtAgreedPrice.Text == string.Empty) ? 0 : Convert.ToDouble(txtAgreedPrice.Text);
                    objLandedCosting.ModeDeliveryTime = (txtModeDeliveryTime.Text == string.Empty) ? 0 : Convert.ToInt32(txtModeDeliveryTime.Text);
                    objLandedCosting.ExpectedBookingDate = (txtExpectedBookingDate.Text == string.Empty) ? DateTime.MinValue : DateHelper.ParseDate(txtExpectedBookingDate.Text).Value;
                    objLandedCosting.CalculatedDeliveryDate = (txtCalculatedDeliveryDate.Text == string.Empty) ? DateTime.MinValue : DateHelper.ParseDate(txtCalculatedDeliveryDate.Text).Value;
                    objLandedCosting.SequenceNumber = i;

                    objCosting.LandedCostingItems.Add(objLandedCosting);
                }
            }
        }

        private void AddFOBPricing(ref Costing objCosting)
        {
            if (txtFOBDelhi.Text != string.Empty)
            {
                if (null == objCosting.FOBPricingItem || objCosting.FOBPricingItem.CostingID != CostingId)
                {
                    objCosting.FOBPricingItem = new FOBPricing();
                    objCosting.FOBPricingItem.CostingQueryType = QueryType.Insert;
                }
                else
                {
                    objCosting.FOBPricingItem.CostingQueryType = QueryType.Update;
                }

                objCosting.FOBPricingItem.FOBDelhi = txtFOBDelhi.Text;
                objCosting.FOBPricingItem.HaulageCharges = (txtHaulageCharges.Text == string.Empty) ? 0 : Convert.ToDouble(txtHaulageCharges.Text);
                objCosting.FOBPricingItem.FOBMargin = (txtFOBIkandiMargin.Text == string.Empty) ? 0 : Convert.ToDouble(txtFOBIkandiMargin.Text);
                objCosting.FOBPricingItem.Discount = (txtFOBDiscount.Text == string.Empty) ? 0 : Convert.ToDouble(txtFOBDiscount.Text);
                objCosting.FOBPricingItem.GrandTotal = (txtFOBGrandTotal.Text == string.Empty) ? 0 : Convert.ToDouble(txtFOBGrandTotal.Text);
                objCosting.FOBPricingItem.QuotedPrice = (txtFOBQuotedPrice.Text == string.Empty) ? 0 : Convert.ToDouble(txtFOBQuotedPrice.Text);
                objCosting.FOBPricingItem.AgreedPrice = (txtFOBAgreedPrice.Text == string.Empty) ? 0 : Convert.ToDouble(txtFOBAgreedPrice.Text);
                objCosting.FOBPricingItem.ModeDelivery = (txtFOBModeDelivery.Text == string.Empty) ? 0 : Convert.ToInt32(txtFOBModeDelivery.Text);
                objCosting.FOBPricingItem.ExpectedBookingDate = (txtFOBBookingDate.Text == string.Empty) ? DateTime.MinValue : DateHelper.ParseDate(txtFOBBookingDate.Text).Value;
                objCosting.FOBPricingItem.CalculatedDeliveryDate = (txtFOBDeliveryDate.Text == string.Empty) ? DateTime.MinValue : DateHelper.ParseDate(txtFOBDeliveryDate.Text).Value;
            }
        }

        private bool SaveCostingData()
        {

            int result = 0;

            Costing objCosting = new Costing();
            objCosting.ClientID = int.TryParse(ddlBuyer.SelectedValue, out result) ? result : 0;
            objCosting.DepartmentID = int.TryParse(hdnDeptId.Value, out result) ? result : 0;
            objCosting.ParentDepartmentID = int.TryParse(hdnParentDeptId.Value, out result) ? result : 0;
            objCosting.StyleID = int.TryParse(txtStyleId.Text, out result) ? result : 0;
            objCosting.Quantity = int.TryParse(txtQuantity.Text, out result) ? result : 0;
            objCosting.Weight = int.TryParse(txtWeight.Text, out result) ? result : 0;
            objCosting.IsIkandiClient = Convert.ToInt32(hdnBuyingHouse.Text);
            objCosting.IsBestSeller = chkIsBestSeller.Checked;
            objCosting.ExpectedQty = int.TryParse(ddlExpectedQty.SelectedValue, out result) ? result : 0;//abhishek
            objCosting.ExpectedQty = Convert.ToInt32(ddlExpectedQty.SelectedValue);
            if (chkverifiedCosting.Checked)
                objCosting.VerifyCosting = 1;
            else
                objCosting.VerifyCosting = 0;

            objCosting.ParentCostingID = CostingId;
            objCosting.PrintIds = string.Empty;

            objCosting.PriceQuoted = Convert.ToDouble(txtPriceQuoted.Text == string.Empty ? "0" : txtPriceQuoted.Text);
            objCosting.AgreedPrice = Convert.ToDouble(txtPriceAgreed.Text == string.Empty ? "0" : txtPriceAgreed.Text);


            objCosting.FrieghtUptoFinalDestination =
                Convert.ToDouble(txtFrtUptoFinalDest.Text == string.Empty ? "0" : txtFrtUptoFinalDest.Text);
            objCosting.FrieghtUptoPort =
              Convert.ToDouble(txtFrtUptoPort.Text == string.Empty ? "0" : txtFrtUptoPort.Text);
            //  Edit by surendra on 02 june
            //if (Convert.ToInt32(objCosting.CurrentStatusID) <= 4)
            //{
            //    objCosting.FrieghtUptoPort =
            //  Convert.ToDouble(txtFrtUptoPort.Text == string.Empty ? "10" : txtFrtUptoPort.Text);
            //}
            //else
            //{
            //    objCosting.FrieghtUptoPort =
            //  Convert.ToDouble(txtFrtUptoPort.Text == string.Empty ? "0" : txtFrtUptoPort.Text);
            //}
            //-----------------end

            objCosting.OverHead = Convert.ToDouble(txtOverHead.Text == string.Empty ? "0" : txtOverHead.Text); // 
            objCosting.MakingType = ddlMaking.SelectedValue;
            // update by surendra for technical module
            objCosting.OB_WS = txtOB.Text == "" ? 0 : Convert.ToInt32(txtOB.Text);
            //Added By Ashish on 26/2/2014
            objCosting.DesignCommission = Convert.ToDouble(txtDesingCommission.Text == string.Empty ? "0" : txtDesingCommission.Text); // 
            //End
            //if (!string.IsNullOrEmpty(txtExpectedQuant.Text))
            //    objCosting.ExpectedQty = Convert.ToInt32(txtExpectedQuant.Text);// Convert.ToInt32(txtExpectedQuant.Text); DesignCommission

            objCosting.ConvertTo = Convert.ToInt32(hdnConvertTo.Value);
            objCosting.MarkupOnUnitCTC =
                Convert.ToDouble(txtMarkupOnUnitCtc.Text == string.Empty ? "0.0" : txtMarkupOnUnitCtc.Text);
            objCosting.CommisionPercent = Convert.ToDouble(txtComm.Text == string.Empty ? "0.0" : txtComm.Text);
            objCosting.ConversionRate = Convert.ToDouble(txtConvRate.Text == string.Empty ? "0" : txtConvRate.Text);

            if (!string.IsNullOrEmpty(txtOverallComments.Text))
                objCosting.OverallComments = ApplicationHelper.LoggedInUser.UserData.FirstName + " ( " +
                                             DateTime.Today.ToString("dd MMM") + ") :" + txtOverallComments.Text;
            else
                objCosting.OverallComments = string.Empty;

            objCosting.Comments = txtComments.Text;

            AddFabricCostings(ref objCosting);
            AddCharges(ref objCosting);
            AddAccessories(ref objCosting);

            int statusid = 0;

            if (this.CostingObject != null)
                statusid = this.CostingObject.CurrentStatusID;

            if (Role == 1)
            {
                AddLandedCosting(ref objCosting);
                AddFOBPricing(ref objCosting);
                objCosting.iKandiChangesHistory = (CostingId > 0)
                                                      ? this.GetiKandiChangesHistory(objCosting, statusid)
                                                      : string.Empty;
                objCosting.BIPlChangesHistory = string.Empty;
            }
            else
            {
                objCosting.BIPlChangesHistory = (CostingId > 0 && !string.IsNullOrEmpty(txtPriceQuoted.Text) &&
                                                 Convert.ToDouble(txtPriceQuoted.Text) > 0)
                                                    ? this.GetBIPLChangesHistory(objCosting, statusid)
                                                    : string.Empty;
                objCosting.iKandiChangesHistory = string.Empty;
            }

            bool isDiffernt = false;
            if (Role == 1 && ParentCostingId <= 0)
                isDiffernt = IsDifferent(objCosting);


            DateTime dt = DateTime.Now;
            string s = String.Format("{0:G}", dt);
            s = s.Replace(" ", "_");
            s = s.Replace(':', '/');
            s = s.Replace('/', '-');
            //string stringOwnerFileName = Ownerfile.FileName;
            //if (stringOwnerFileName != "")
            //    Ownerfile.SaveAs(Server.MapPath("~/Uploads/Photo/") + s + stringOwnerFileName);
            //objCosting.FileName = "";

            //string stringLayFile = LayFile.FileName;
            //if (stringLayFile != "")
            //{
            //    LayFile.SaveAs(Server.MapPath("~/Uploads/Photo/") + s + stringLayFile);
            //}

            //objCosting.LayFileName = stringLayFile == "" ? "NOT" : s + stringLayFile;

            //objCosting.OB_WS = txtOB.Text == "" ? 0 : Convert.ToInt32(txtOB.Text) * Convert.ToInt32(hdnOBCount.Value);
            string stringOwnerFileName = uploadob.FileName;
            if (stringOwnerFileName != "")
            {
                uploadob.SaveAs(Server.MapPath("~/Uploads/Photo/") + s + stringOwnerFileName);
                objCosting.FileName = (stringOwnerFileName == "" ? "NOT" : s + stringOwnerFileName);
                hypviewObfile.NavigateUrl = "~/Uploads/Photo/" + s + stringOwnerFileName;
                hypviewObfile.Visible = true;
            }
            objCosting.Achivement = hdnAch.Value == "" ? 0 : Convert.ToInt32(hdnAch.Value);

            if (isDiffernt == false && CostingId > 0)
            {
                objCosting.CostingID = CostingId;
                updateFabQuality();

                if (!string.IsNullOrEmpty(txtPriceAgreed.Text.Trim()) && !string.IsNullOrEmpty(txtPriceQuoted.Text.Trim()))
                {
                    Double OldPriceQuoted = string.IsNullOrEmpty(hdnPriceQuoted.Value) ? 0.0 : Convert.ToDouble(hdnPriceQuoted.Value);
                    if ((Convert.ToDouble(txtPriceAgreed.Text.Trim()) != Convert.ToDouble(txtPriceQuoted.Text.Trim())) && OldPriceQuoted != Convert.ToDouble(txtPriceQuoted.Text.Trim()))
                    {
                        NotificationEmailHistory NEH = new NotificationEmailHistory();
                        NEH.Type = "5";
                        NEH.EmailID = "15";
                        NEH.OrderDetailsID = "0";
                        NEH.CostingID = CostingId.ToString();
                        NEH.OldBIPL = Convert.ToDouble(txtPriceQuoted.Text.Trim());
                        this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                    }
                }

                return this.CostingControllerInstance.UpdateCosting(objCosting, Role);
            }
            objCosting.iKandiChangesHistory = CostingObject.iKandiChangesHistory +
                                              ((CostingId > 0)
                                                   ? this.GetiKandiChangesHistory(objCosting, statusid)
                                                   : string.Empty);
            objCosting.BIPlChangesHistory = CostingObject.BIPlChangesHistory +
                                            ((CostingId > 0 && !string.IsNullOrEmpty(txtPriceQuoted.Text) &&
                                              Convert.ToDouble(txtPriceQuoted.Text) > 0)
                                                 ? this.GetBIPLChangesHistory(objCosting, statusid)
                                                 : string.Empty);
            objCosting.OverallComments = lblOverallCommentsHistory.Text + "$$" + objCosting.OverallComments;
            //}
            updateFabQuality();



            CostingId = this.CostingControllerInstance.InsertCosting(objCosting, Role);
            if (!string.IsNullOrEmpty(txtPriceAgreed.Text.Trim()) && !string.IsNullOrEmpty(txtPriceQuoted.Text.Trim()))
            {
                Double OldPriceQuoted = string.IsNullOrEmpty(hdnPriceQuoted.Value) ? 0.0 : Convert.ToDouble(hdnPriceQuoted.Value);
                if ((Convert.ToDouble(txtPriceAgreed.Text.Trim()) != Convert.ToDouble(txtPriceQuoted.Text.Trim())) && OldPriceQuoted != Convert.ToDouble(txtPriceQuoted.Text.Trim()))
                {
                    NotificationEmailHistory NEH = new NotificationEmailHistory();
                    NEH.Type = "5";
                    NEH.EmailID = "15";
                    NEH.OrderDetailsID = "0";
                    NEH.CostingID = CostingId.ToString();
                    NEH.OldBIPL = Convert.ToDouble(txtPriceQuoted.Text.Trim());
                    this.NotificationControllerInstance.NotificationEmailHistory_Ins(NEH);
                }
            }
            return (CostingId > 0);
        }

        private void updateFabQuality()
        {

            string[] tradeName = new string[4];
            tradeName[0] = txtFabric1.Text;
            tradeName[1] = txtFabric2.Text;
            tradeName[2] = txtFabric3.Text;
            tradeName[3] = txtFabric4.Text;

            string[] count = new string[4];
            count[0] = txtCOUNTCON1.Text;
            count[1] = txtCOUNTCON2.Text;
            count[2] = txtCOUNTCON3.Text;
            count[3] = txtCOUNTCON4.Text;

            if (txtGSML1.Text == "")
            { txtGSML1.Text = "0"; }
            if (txtGSML2.Text == "")
            { txtGSML2.Text = "0"; }
            if (txtGSML3.Text == "")
            { txtGSML3.Text = "0"; }
            if (txtGSML4.Text == "")
            { txtGSML4.Text = "0"; }

            double[] gsm = new double[4];
            gsm[0] = Convert.ToDouble(txtGSML1.Text);
            gsm[1] = Convert.ToDouble(txtGSML2.Text);
            gsm[2] = Convert.ToDouble(txtGSML3.Text);
            gsm[3] = Convert.ToDouble(txtGSML4.Text);
        }

        private bool IsDifferent(Costing objCosting)
        {
            CostingCollection lObjCostingCollection = this.CostingControllerInstance.GetCosting(CostingId, Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID));

            if (lObjCostingCollection.Count == 0 || lObjCostingCollection.Count > 1)
            {
                return false;
            }
            Costing lObjCosting = lObjCostingCollection[0];

            if (objCosting.PriceQuoted.ToString("N2") != lObjCosting.PriceQuoted.ToString("N2"))
                return true;

            if (objCosting.FrieghtUptoFinalDestination.ToString("N2") != lObjCosting.FrieghtUptoFinalDestination.ToString("N2"))
                return true;

            if (objCosting.FrieghtUptoPort.ToString("N2") != lObjCosting.FrieghtUptoPort.ToString("N2"))
                return true;

            if (objCosting.FincCost.ToString("N2") != lObjCosting.FincCost.ToString("N2"))
                return true;

            if (objCosting.DirectCost.ToString("N2") != lObjCosting.DirectCost.ToString("N2"))
                return true;

            if (objCosting.ConvertTo != lObjCosting.ConvertTo)
                return true;

            if (objCosting.MarkupOnUnitCTC != lObjCosting.MarkupOnUnitCTC)
                return true;

            if (objCosting.CommisionPercent != lObjCosting.CommisionPercent)
                return true;

            if (objCosting.ConversionRate.ToString("N2") != lObjCosting.ConversionRate.ToString("N2"))
                return true;


            for (int i = 0; i < 4; i++)
            {
                if (objCosting.FabricCostingItems == null && lObjCosting.FabricCostingItems == null)
                    break;

                if (objCosting.FabricCostingItems == null && lObjCosting.FabricCostingItems != null)
                {
                    return true;
                }
                if (objCosting.FabricCostingItems != null && lObjCosting.FabricCostingItems == null)
                    return true;

                if (objCosting.FabricCostingItems.Count != lObjCosting.FabricCostingItems.Count)
                    return true;

                if (objCosting.FabricCostingItems != null && lObjCosting.FabricCostingItems != null)
                {
                    if (objCosting.FabricCostingItems.Count >= (i + 1) && lObjCosting.FabricCostingItems.Count >= (i + 1))
                    {
                        if (objCosting.FabricCostingItems[i].PrintType == null && lObjCosting.FabricCostingItems[i].PrintType != null)
                            return true;
                        if (objCosting.FabricCostingItems[i].PrintType != null && lObjCosting.FabricCostingItems[i].PrintType == null)
                            return true;
                        if (objCosting.FabricCostingItems[i].PrintType.Trim().ToLower() != lObjCosting.FabricCostingItems[i].PrintType.Trim().ToLower())
                            return true;

                        if (objCosting.FabricCostingItems[i].Fabric == null && lObjCosting.FabricCostingItems[i].Fabric != null)
                            return true;
                        if (objCosting.FabricCostingItems[i].Fabric != null && lObjCosting.FabricCostingItems[i].Fabric == null)
                            return true;
                        if (objCosting.FabricCostingItems[i].Fabric.Trim().ToLower() != lObjCosting.FabricCostingItems[i].Fabric.Trim().ToLower())
                            return true;

                        if (objCosting.FabricCostingItems[i].FabricType == null && lObjCosting.FabricCostingItems[i].FabricType != null)
                            return true;
                        if (objCosting.FabricCostingItems[i].FabricType != null && lObjCosting.FabricCostingItems[i].FabricType == null)
                            return true;
                        if (objCosting.FabricCostingItems[i].FabricType.Trim().ToLower() != lObjCosting.FabricCostingItems[i].FabricType.Trim().ToLower())
                            return true;

                        if (objCosting.FabricCostingItems[i].Width.ToString("N2") != lObjCosting.FabricCostingItems[i].Width.ToString("N2"))
                            return true;

                        if (objCosting.FabricCostingItems[i].Average.ToString("N3") != lObjCosting.FabricCostingItems[i].Average.ToString("N3"))
                            return true;

                        if (objCosting.FabricCostingItems[i].Rate.ToString("N2") != lObjCosting.FabricCostingItems[i].Rate.ToString("N2"))
                            return true;

                        if (objCosting.FabricCostingItems[i].Amount.ToString("N2") != lObjCosting.FabricCostingItems[i].Amount.ToString("N2"))
                            return true;

                        //if (objCosting.FabricCostingItems[i].Waste.ToString("N0") != lObjCosting.FabricCostingItems[i].Waste.ToString("N0"))
                        //    return true;

                        if (objCosting.FabricCostingItems[i].Total.ToString("N2") != lObjCosting.FabricCostingItems[i].Total.ToString("N2"))
                            return true;

                        if (objCosting.FabricCostingItems[i].IsAir != lObjCosting.FabricCostingItems[i].IsAir)
                            return true;
                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                if (objCosting.ChargesItems == null && lObjCosting.ChargesItems == null)
                    break;
                if (objCosting.ChargesItems == null && lObjCosting.ChargesItems != null)
                    return true;
                if (objCosting.ChargesItems != null && lObjCosting.ChargesItems == null)
                    return true;
                if (objCosting.ChargesItems.Count != lObjCosting.ChargesItems.Count)
                    return true;
                if (objCosting.ChargesItems.Count >= (i + 1) && lObjCosting.ChargesItems.Count >= (i + 1))
                {
                    if (objCosting.ChargesItems[i].ChargeName != null && lObjCosting.ChargesItems[i].ChargeName == null)
                        return true;
                    if (objCosting.ChargesItems[i].ChargeName == null && lObjCosting.ChargesItems[i].ChargeName != null)
                        return true;
                    if (objCosting.ChargesItems[i].ChargeName.ToString().Trim().ToLower() != lObjCosting.ChargesItems[i].ChargeName.ToString().Trim().ToLower())
                        return true;
                    string TempChargeName = objCosting.ChargesItems[i].ChargeName.ToString().Trim().ToLower();
                    if (TempChargeName == "SAM Value".ToString().Trim().ToLower())
                    {
                        if (string.Format("{0:0.0}", objCosting.ChargesItems[i].ChargeValue) != string.Format("{0:0.0}", lObjCosting.ChargesItems[i].ChargeValue))
                            return true;

                    }
                    else
                    {
                        if (objCosting.ChargesItems[i].ChargeValue != lObjCosting.ChargesItems[i].ChargeValue)
                            return true;
                    }

                }
            }

            for (int i = 0; i < 10; i++)
            {
                if (objCosting.AccessoryItems == null && lObjCosting.AccessoryItems == null)
                    break;
                if (objCosting.AccessoryItems == null && lObjCosting.AccessoryItems != null)
                    return true;
                if (objCosting.AccessoryItems != null && lObjCosting.AccessoryItems == null)
                    return true;
                if (objCosting.AccessoryItems.Count != lObjCosting.AccessoryItems.Count)
                    return true;
                if (objCosting.AccessoryItems.Count >= (i + 1) && lObjCosting.AccessoryItems.Count >= (i + 1))
                {
                    if (objCosting.AccessoryItems[i].Item != null && lObjCosting.AccessoryItems[i].Item == null)
                        return true;

                    if (objCosting.AccessoryItems[i].Item == null && lObjCosting.AccessoryItems[i].Item != null)
                        return true;

                    if (objCosting.AccessoryItems[i].Item.ToString().Trim().ToLower() != lObjCosting.AccessoryItems[i].Item.ToString().Trim().ToLower())
                        return true;

                    if (objCosting.AccessoryItems[i].Quantity != lObjCosting.AccessoryItems[i].Quantity)
                        return true;

                    if (objCosting.AccessoryItems[i].Rate.ToString("N3") != lObjCosting.AccessoryItems[i].Rate.ToString("N3"))
                        return true;

                    if (objCosting.AccessoryItems[i].AccessoryPercent != lObjCosting.AccessoryItems[i].AccessoryPercent)
                        return true;
                }
            }

            return false;
        }

        private void BindFormWithCostingData(Costing objCosting)
        {
            bool bCheckReadOnly = false;
            if (objCosting.CostingTask != 0)
            {
                btnAcknowledgment.Attributes.Add("style", "display:;");
            }
            hdnBuyingHouse.Text = objCosting.IsIkandiClient.ToString();
            txtStyleId.Text = objCosting.StyleID.ToString();
            txtStyleNumber.Text = txtIkandiStyle.Text = objCosting.StyleNumber;
            if (objCosting.StyleNumber.Length > 2)
            {
                string code = objCosting.StyleNumber.Substring(0, 2).ToUpper();
                lblGarmetType.Text = this.CostingControllerInstance.GetGarmentNameOption(code);
            }
            // edit by surendra technical module
            if (this.CostingControllerInstance.bCheckOB(objCosting.StyleID) == false)
            {
                bCheckReadOnly = true;
            }
            // end
            txtOrderId.Text = objCosting.OrderId.ToString();
            txtCurrentStatusID.Text = objCosting.CurrentStatusID.ToString();

            chkIsBestSeller.Checked = objCosting.IsBestSeller;

            ddlBuyer.SelectedValue = objCosting.ClientID.ToString();
            hdnDeptId.Value = objCosting.DepartmentID.ToString();
            hdnParentDeptId.Value = objCosting.ParentDepartmentID.ToString();
            ddlParentDept.SelectedValue = objCosting.ParentDepartmentID.ToString();
            GetDepartmentDropdownInformationAtPrint(ddlBuyer.SelectedValue);
            txtQuantity.Text = objCosting.AllQuantity.ToString();
            anchorQuantity.InnerText = objCosting.AllQuantity.ToString("N0");
            txtWeight.Text = objCosting.Weight.ToString();
            if (objCosting.Weight_ReadOnly == 1)
                 txtWeight.ReadOnly = true;

            txtPriceQuoted.Text = (objCosting.PriceQuoted == 0) ? "" : objCosting.PriceQuoted.ToString("");
            txtPriceAgreed.Text = (objCosting.AgreedPrice == 0) ? "" : objCosting.AgreedPrice.ToString("");

            hiddenStyleId.Value = objCosting.StyleID.ToString();
            lblStatus.Text = Constants.GetStatusModeName(objCosting.CurrentStatusID);
            tdStatus.BgColor = Constants.GetStatusModeColor(objCosting.CurrentStatusID);

            // Added By Ravi kumar on 26/8/14
            txtOB.Text = objCosting.OB_WS.ToString() == "0" ? "" : objCosting.OB_WS.ToString();
            if (bCheckReadOnly == false)
            {
                txtOB.ReadOnly = true;
            }
            //lblOBCount.Text = Convert.ToInt32(objCosting.OB_WS / 40).ToString();

            hdnOBCount.Value = Convert.ToInt32(objCosting.OB_WS / 40).ToString();

            hdnAch.Value = objCosting.Achivement.ToString() == "0" ? "70" : objCosting.Achivement.ToString();

            // End By Ravi kumar

            //Disable the  price Quoted if user is Ikandi and Price quoted Not done in base costing                 
            if (objCosting.PriceQuotedVisibility == 0 && Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.CompanyID) == 1)
            {
                txtPriceQuoted.CssClass = txtPriceQuoted.CssClass + " do-not-allow-typing";
                txtPriceQuoted.Attributes.Add("placeholder", "Pndg.BIPL");
                txtPriceQuoted.Attributes.Add("style", "pointer-events: none;font-size:8px;text-transform:none !important;");
            }

            tdCounterComplete.InnerText = objCosting.CounterComplete ? "Counter Complete" : "Counter Pending";
            tdCounterComplete.BgColor = objCosting.CounterComplete ? "Green" : "Red";

            txtFrtUptoFinalDest.Text = objCosting.FrieghtUptoFinalDestination.ToString();
            // edit by surendra on 02 jun
            txtFrtUptoPort.Text = objCosting.FrieghtUptoPort.ToString();

            //if (objCosting.FrieghtUptoPort == 10 && Convert.ToInt32(objCosting.CurrentStatusID)<=4)
            //{
            //    txtFrtUptoPort.Text = "10";
            //}
            //else
            //{
            //    txtFrtUptoPort.Text = objCosting.FrieghtUptoPort.ToString();
            //}
            //--------------------end
            //         edit by surendra on o5 march 2014
            ddlConvTo.SelectedValue = objCosting.ConvertTo.ToString();
            hdnConvertTo.Value = objCosting.ConvertTo.ToString();
            txtMarkupOnUnitCtc.Text = objCosting.MarkupOnUnitCTC.ToString();
            txtOverHead.Text = objCosting.OverHead.ToString();//
            txtDesingCommission.Text = objCosting.DesignCommission.ToString();
            //------------end
            //txtDesingCommission.Text = Convert.ToDouble(0).ToString();
            //if (objCosting.DesignCommission == 0)
            //{
            //    // if this is style version then get value from base version
            //    if (this.ClientID == 2 && Convert.ToDateTime(objCosting.CreatedOn) > Convert.ToDateTime("02/27/2014") && objCosting.ParentCostingID == -1)
            //    {
            //        txtDesingCommission.Text = Convert.ToDouble(10).ToString();
            //    }
            //    else
            //    {
            //        txtDesingCommission.Text = objCosting.DesignCommission.ToString();
            //    }
            //}
            //else
            //{
            //    txtDesingCommission.Text = objCosting.DesignCommission.ToString();
            //}

            //End
            ddlMaking.SelectedValue = objCosting.MakingType;

            txtExpectedQuant.Text = Convert.ToString(objCosting.ExpectedQty);
            ddlExpectedQty.SelectedValue = Convert.ToString(objCosting.ExpectedQty);
            //ddlExpectedQty.SelectedValue = objCosting.ExpectedQty > 12 ? this.CostingControllerInstance.CostingExpectedQtyBAL(objCosting.ExpectedQty) : Convert.ToString(objCosting.ExpectedQty);
            DataTable dtClientCosting_ExpectedQty = AdminControllerInstance.GetClientCosting_By_Client_Dept_ForExpectedQty(this.ClientID, this.DepartmentID, 1);
            ddlExpectedQty.DataSource = dtClientCosting_ExpectedQty;
            ddlExpectedQty.DataTextField = "EXPECTEDQTY";
            ddlExpectedQty.DataValueField = "ExpectedValue";
            ddlExpectedQty.DataBind();



            txtComm.Text = objCosting.CommisionPercent.ToString();
            txtConvRate.Text = objCosting.ConversionRate.ToString();

            if (!string.IsNullOrEmpty(objCosting.OverallComments) && objCosting.OverallComments.LastIndexOf("$$") > -1)
            {
                string[] comments = objCosting.OverallComments.Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);

                if (comments.Length >= 2)
                {
                    lblOverallCommentsHistory.Text = comments[comments.Length - 2] + "<br />" + comments[comments.Length - 1];
                }
                else if (comments.Length >= 1)
                {
                    lblOverallCommentsHistory.Text = comments[comments.Length - 1];
                }
            }
            else
            {
                lblOverallCommentsHistory.Text = objCosting.OverallComments;
            }

            hdnComments.InnerHtml = objCosting.OverallComments.Replace("$$", "<br/>");

            txtComments.Text = string.IsNullOrEmpty(objCosting.Comments) ? "COMMENTS" : objCosting.Comments;

            HyperLink hypfitstatus = new HyperLink();

            if (objCosting.FITsStatus != string.Empty)
            {
                hypfitstatus.Text = objCosting.FITsStatus;
                int styleCode = -1;
                int oStyleCode;
                if (int.TryParse(objCosting.StyleNumber.Substring(3, 5).Trim(), out oStyleCode))
                    styleCode = oStyleCode;

                hypfitstatus.Attributes.Add("onclick", "javascript:ShowFitsPopup('" + styleCode + "','" + objCosting.DepartmentID + "','" + objCosting.OrderDetailId + "')");
            }

            lblFitsStatus.Controls.Add(hypfitstatus);

            AddFabricCostings(ref objCosting);
            //    AddCharges(ref objCosting);
            AddAccessories(ref objCosting);

            imgSampleImageUrl1.Src = (objCosting.SampleImageURL1 == string.Empty) ? "~/App_Themes/ikandi/images/preview.png" : "~/Uploads/Style/" + objCosting.SampleImageURL1;
            //imgSampleImageUrl2.Src = (objCosting.SampleImageURL2 == string.Empty) ? "~/App_Themes/ikandi/images/preview.png" : "~/Uploads/Style/" + objCosting.SampleImageURL2;

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StylePhoto", "$('.sample-image').attr('href', 'javascript:showStylePhotoWithOutScroll_Costing(" + objCosting.StyleID + ",-1,-1)');", true);

            tdDesigner.InnerText = objCosting.DesignerName;

            anchorQuantity.InnerText = objCosting.AllQuantity.ToString("N0");
            txtQuantity.Text = objCosting.AllQuantity.ToString();
            txtAFDiscount.Text = txtAHDiscount.Text = txtSFDiscount.Text = txtSHDiscount.Text = objCosting.Discount.ToString();

            iKandiService proxy = new iKandiService();
            string currencySymbol = proxy.GetCurrencySumbol(objCosting.TargetPriceCurrency);
            tdTargetPrice.InnerText = currencySymbol + " " + objCosting.TargetPrice.ToString("N2");

            ParentCostingId = objCosting.ParentCostingID;
            int s = 0;
            foreach (FabricCosting item in objCosting.FabricCostingItems)
            {

                DropDownList ddlPrintType = tblCostingDetails.FindControl("ddlPrintType" + item.SequenceNumber) as DropDownList;
                TextBox txtFabric = tblCostingDetails.FindControl("txtFabric" + item.SequenceNumber) as TextBox;
                TextBox txtWidth = tblCostingDetails.FindControl("txtWidth" + item.SequenceNumber) as TextBox;
                TextBox txtAverage = tblCostingDetails.FindControl("txtAverage" + item.SequenceNumber) as TextBox;
                TextBox txtRate = tblCostingDetails.FindControl("txtRate" + item.SequenceNumber) as TextBox;
                TextBox txtAmount = tblCostingDetails.FindControl("txtAmount" + item.SequenceNumber) as TextBox;
                TextBox txtWaste = tblCostingDetails.FindControl("txtWaste" + item.SequenceNumber) as TextBox;
                TextBox txtTotal = tblCostingDetails.FindControl("txtTotal" + item.SequenceNumber) as TextBox;
                TextBox hdncurr = tblCostingDetails.FindControl("hdn" + item.SequenceNumber) as TextBox;
                TextBox hdnprev = tblCostingDetails.FindControl("hdn" + item.SequenceNumber + "Prev") as TextBox;
                Label lblCurr = tblCostingDetails.FindControl("lbl" + item.SequenceNumber) as Label;
                HiddenField hiddenRadioMode = tblCostingDetails.FindControl("hiddenRadioMode" + item.SequenceNumber) as HiddenField;
                Image img = tblCostingDetails.FindControl("imgFab" + item.SequenceNumber) as Image;
                HyperLink lnkLayFile = tblCostingDetails.FindControl("viewolay" + item.SequenceNumber) as HyperLink;
                FileUpload LayUploadFile = tblCostingDetails.FindControl("LayFile" + item.SequenceNumber) as FileUpload;
                //Added By uday
                HyperLink ViewCad = tblCostingDetails.FindControl("ViewCad" + item.SequenceNumber) as HyperLink;
                HyperLink ViewStc = tblCostingDetails.FindControl("ViewStc" + item.SequenceNumber) as HyperLink;
                Label lblcst = tblCostingDetails.FindControl("lblcst" + item.SequenceNumber) as Label;
                Label lblcad = tblCostingDetails.FindControl("lblcad" + item.SequenceNumber) as Label;
                Label lblmarker = tblCostingDetails.FindControl("lblmarker" + item.SequenceNumber) as Label;

                //Ended Added by uday

                if (item.isMultiple == "Y")
                    img.Visible = true;

                ddlPrintType.SelectedValue = item.PrintType;
                txtFabric.Text = item.Fabric;
                if (txtFabric.Text != "")
                {
                    LayUploadFile.Attributes.Add("style", "display:block;");
                }
                if (s == 0)
                {
                    txtFabricType1.Value = item.specialFabricDetails.Trim() == ""
                                             ? item.FabricType
                                             : item.specialFabricDetails;
                }
                if (s == 1)
                {
                    txtFabricType2.Value = item.specialFabricDetails.Trim() == ""
                                             ? item.FabricType
                                             : item.specialFabricDetails;
                }
                if (s == 2)
                {
                    txtFabricType3.Value = item.specialFabricDetails.Trim() == ""
                                             ? item.FabricType
                                             : item.specialFabricDetails;
                }
                if (s == 3)
                {
                    txtFabricType4.Value = item.specialFabricDetails.Trim() == ""
                                             ? item.FabricType
                                             : item.specialFabricDetails;
                }
                txtWidth.Text = item.Width.ToString();
                txtAverage.Text = (item.Average == 0) ? "0.00" : item.Average.ToString("0.000");
                txtRate.Text = item.Rate.ToString();
                txtAmount.Text = item.Amount.ToString();
                txtWaste.Text = item.Waste.ToString();
                txtTotal.Text = item.Total.ToString("0.00");
                hiddenRadioMode.Value = Convert.ToInt32(item.IsAir).ToString();
                hdncurr.Text = item.FabPrintNumber;
                hdnprev.Text = "";

                lnkLayFile.NavigateUrl = "~/Uploads/Photo/" + item.LayFileName;
                //Added by uday
                ViewCad.NavigateUrl = "~/Uploads/Photo/" + item.CadFileName;
                ViewStc.NavigateUrl = "~/Uploads/Photo/" + item.StcFileName;

                if (!String.IsNullOrEmpty(item.LayFileName))
                {

                    lblcst.Attributes.Add("style", "display:block;");
                    lnkLayFile.Attributes.Add("style", "display:block;");
                }

                if (!String.IsNullOrEmpty(item.CadFileName))
                {
                    lblcad.Attributes.Add("style", "display:block;");
                    ViewCad.Attributes.Add("style", "display:block;");
                }


                if (!String.IsNullOrEmpty(item.StcFileName))
                {



                    lblmarker.Attributes.Add("style", "display:block;");
                    ViewStc.Attributes.Add("style", "display:block;");
                }

                //Ended by uday
                //lnkLayFile.Visible = String.IsNullOrEmpty(item.LayFileName) ? false : true;

                if (item.IsPrint == 1)
                {
                    lblCurr.Text = "PRD: ";
                }
                s = s + 1;
            }

            foreach (Charges item in objCosting.ChargesItems)
            {
                TextBox txtChargesName = tblCostingDetails.FindControl("txtChargesName" + item.SequenceNumber) as TextBox;

                TextBox txtChargesValue = tblCostingDetails.FindControl("txtChargesValue" + item.SequenceNumber) as TextBox;

                if (item.SequenceNumber == 1)
                    hdnManualValue.Value = item.ChargeValue.ToString();

                if (item.SequenceNumber != 11)
                    txtChargesName.Text = item.SequenceNumber == 1 ? "SAM" : item.ChargeName;
                if (item.SequenceNumber == 11)
                {
                    // edit by surendra technical module
                    txtChargesValue.Text = Math.Round(item.ChargeValue, 1).ToString();
                    if (bCheckReadOnly == false)
                    {
                        txtChargesValue.ReadOnly = true;
                    }

                }
                else
                {
                    txtChargesValue.Text = item.ChargeValue.ToString();
                }



                // txtChargesValue.Text = item.ChargeValue.ToString();
                //if (item.SequenceNumber == 11)
                //{
                //    if (item.ChargeValue == -1)
                //    {
                //        txtChargesValue.Text = "Manual";
                //        ddlChargeValue.SelectedValue = "-1";
                //        ddlChargeValue.Items.Remove(ddlChargeValue.Items.FindByValue("-2"));
                //    }
                //    else
                //    {
                //        ddlChargeValue.SelectedValue = item.ChargeValue.ToString();
                //        ddlChargeValue.Items.Remove(ddlChargeValue.Items.FindByValue("-1"));
                //        ddlChargeValue.Items.Remove(ddlChargeValue.Items.FindByValue("-2"));
                //    }
                //}

            }


            foreach (Accessories item in objCosting.AccessoryItems)
            {
                TextBox txtAccessoriesAmount = null;

                if (item.SequenceNumber == 4)
                {
                    DropDownList ddlAccessoriesItem = tblCostingDetails.FindControl("ddlAccessoriesItem" + item.SequenceNumber) as DropDownList;
                    DropDownList ddlAccessoriesQuantity = tblCostingDetails.FindControl("ddlAccessoriesQuantity" + item.SequenceNumber) as DropDownList;
                    DropDownList ddlAccessoriesRate = tblCostingDetails.FindControl("ddlAccessoriesRate" + item.SequenceNumber.ToString()) as DropDownList;
                    txtAccessoriesAmount = tblCostingDetails.FindControl("txtAccessoriesAmount" + item.SequenceNumber) as TextBox;

                    ddlAccessoriesItem.SelectedValue = item.Item;
                    ddlAccessoriesQuantity.SelectedValue = item.Quantity.ToString();
                    ddlAccessoriesRate.SelectedValue = item.Rate.ToString();
                    txtAccessoriesAmount.Text = item.Amount.ToString();

                    continue;
                }

                TextBox txtAccessoriesItem = tblCostingDetails.FindControl("txtAccessoriesItem" + item.SequenceNumber) as TextBox;
                TextBox txtAccessoriesQuantity = tblCostingDetails.FindControl("txtAccessoriesQuantity" + item.SequenceNumber) as TextBox;
                TextBox txtAccessoriesRate = tblCostingDetails.FindControl("txtAccessoriesRate" + item.SequenceNumber) as TextBox;
                txtAccessoriesAmount = tblCostingDetails.FindControl("txtAccessoriesAmount" + item.SequenceNumber) as TextBox;

                txtAccessoriesItem.Text = item.Item;
                txtAccessoriesQuantity.Text = item.Quantity.ToString();
                txtAccessoriesRate.Text = item.Rate.ToString();
                txtAccessoriesAmount.Text = item.Amount.ToString("0.00");

                if (item.SequenceNumber == 9)
                    ddlAccessoriesPercent1.SelectedValue = item.AccessoryPercent.ToString();
                else if (item.SequenceNumber == 10)
                    ddlAccessoriesPercent2.SelectedValue = item.AccessoryPercent.ToString();
            }

            foreach (LandedCosting item in objCosting.LandedCostingItems)
            {
                TextBox txtFobBoutique = tblCostingDetails.FindControl("txt" + item.Mode + "FobBoutique") as TextBox;
                TextBox txtFobIkandi = tblCostingDetails.FindControl("txt" + item.Mode + "FobIkandi") as TextBox;
                TextBox txtModeCost = tblCostingDetails.FindControl("txt" + item.Mode + "ModeCost") as TextBox;
                TextBox txtDuty = tblCostingDetails.FindControl("txt" + item.Mode + "Duty") as TextBox;
                TextBox txtHandling = tblCostingDetails.FindControl("txt" + item.Mode + "Handling") as TextBox;
                TextBox txtDelivery = tblCostingDetails.FindControl("txt" + item.Mode + "Delivery") as TextBox;
                TextBox txtProcessing = tblCostingDetails.FindControl("txt" + item.Mode + "Processing") as TextBox;
                TextBox txtMargin = tblCostingDetails.FindControl("txt" + item.Mode + "Margin") as TextBox;
                TextBox txtDiscount = tblCostingDetails.FindControl("txt" + item.Mode + "Discount") as TextBox;
                TextBox txtGrandTotal = tblCostingDetails.FindControl("txt" + item.Mode + "GrandTotal") as TextBox;
                TextBox txtQuotedPrice = tblCostingDetails.FindControl("txt" + item.Mode + "QuotedPrice") as TextBox;
                TextBox txtAgreedPrice = tblCostingDetails.FindControl("txt" + item.Mode + "AgreedPrice") as TextBox;
                TextBox txtModeDeliveryTime = tblCostingDetails.FindControl("txt" + item.Mode + "ModeDelivery") as TextBox;
                TextBox txtExpectedBookingDate = tblCostingDetails.FindControl("txt" + item.Mode + "ExpectedBookingDate") as TextBox;
                TextBox txtCalculatedDeliveryDate = tblCostingDetails.FindControl("txt" + item.Mode + "CalculatedDeliveryDate") as TextBox;

                txtFobBoutique.Text = item.FOBBoutique;
                txtFobIkandi.Text = item.FOBIkandi;
                txtModeCost.Text = item.ModeCost;
                txtDuty.Text = item.Duty;
                txtHandling.Text = item.Handling;
                txtDelivery.Text = item.Delivery;
                txtProcessing.Text = item.Processing;
                txtMargin.Text = item.Margin.ToString();

                txtDiscount.Text = item.Discount.ToString();
                txtGrandTotal.Text = item.GrandTotal.ToString();
                txtQuotedPrice.Text = item.QuotedPrice.ToString("0.00");
                txtAgreedPrice.Text = item.AgreedPrice.ToString("0.00");
                txtModeDeliveryTime.Text = item.ModeDeliveryTime.ToString();
                txtExpectedBookingDate.Text = item.ExpectedBookingDate.ToString("dd MMM yy (ddd)");
                txtCalculatedDeliveryDate.Text = item.CalculatedDeliveryDate.ToString("dd MMM yy (ddd)");
            }

            if (null != objCosting.FOBPricingItem && null != objCosting.FOBPricingItem &&
                !string.IsNullOrEmpty(objCosting.FOBPricingItem.FOBDelhi))
            {
                txtFOBDelhi.Text = objCosting.FOBPricingItem.FOBDelhi;
                txtHaulageCharges.Text = objCosting.FOBPricingItem.HaulageCharges.ToString("0.00");
                txtFOBIkandiMargin.Text = objCosting.FOBPricingItem.FOBMargin.ToString("0.00");
                txtFOBDiscount.Text = objCosting.FOBPricingItem.Discount.ToString("0.00");
                txtFOBGrandTotal.Text = objCosting.FOBPricingItem.GrandTotal.ToString("0.00");
                txtFOBQuotedPrice.Text = objCosting.FOBPricingItem.QuotedPrice.ToString("0.00");
                txtFOBAgreedPrice.Text = objCosting.FOBPricingItem.AgreedPrice.ToString("0.00");
                txtFOBModeDelivery.Text = objCosting.FOBPricingItem.ModeDelivery.ToString();
                txtFOBBookingDate.Text = objCosting.FOBPricingItem.ExpectedBookingDate.ToString("dd MMM yy (ddd)");
                txtFOBDeliveryDate.Text = objCosting.FOBPricingItem.CalculatedDeliveryDate.ToString("dd MMM yy (ddd)");
            }

            lblLastUpdatedDate.Text = "Updated On: " + objCosting.UpdatedOn.ToString("dd MMM yy (ddd)");

            lblBIPLHistory.Text = LowercaseFirst(objCosting.BIPlChangesHistory.Replace("$$", "<br/>").Replace("<br/><br/>", "<br/>"));
            lbliKandiHistory.Text = LowercaseFirst(objCosting.iKandiChangesHistory.Replace("$$", "<br/>").Replace("<br/><br/>", "<br/>"));
        } //GC
        public string LowercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            char[] a = s.ToCharArray();
            a[0] = char.ToLower(a[0]);

            return new string(a);
        }
        private void BindFormWithiKandiCostingData(Costing objCosting)
        {
            bool isValueChanged = false;
            bool isTotalChanged = false;

            double total = 0;
            double totalABC = 0;

            Label lbl;
            TextBox txt;
            DropDownList ddl;

            foreach (FabricCosting item in objCosting.FabricCostingItems)
            {
                ddl = tblCostingDetails.FindControl("ddlPrintType" + item.SequenceNumber.ToString()) as DropDownList;

                if (ddl.SelectedValue != item.PrintType)
                {
                    ListItem li = ddl.Items.FindByValue(item.PrintType);
                    lbl = tblCostingDetails.FindControl("lblPrintType" + item.SequenceNumber.ToString()) as Label;
                    lbl.Text = (li != null) ? "(was " + li.Text + ")" : "(Modified)";
                    lbl.CssClass = "changed_value";
                }

                txt = tblCostingDetails.FindControl("txtFabric" + item.SequenceNumber.ToString()) as TextBox;

                if (txt.Text != item.Fabric)
                {
                    lbl = tblCostingDetails.FindControl("lblFabric" + item.SequenceNumber.ToString()) as Label;
                    lbl.Text = "(was " + item.Fabric + ")";
                    lbl.CssClass = "changed_value";
                }

                if (item.SequenceNumber == 1)
                {
                    if (txtFabricType1.Value != item.FabricType)
                    {
                        lbl = tblCostingDetails.FindControl("lblFabricType" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = "(was " + item.FabricType + ")";
                        lbl.CssClass = "changed_value";
                    }
                }
                if (item.SequenceNumber == 1)
                {
                    if (txtFabricType1.Value != item.FabricType)
                    {
                        lbl = tblCostingDetails.FindControl("lblFabricType" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = "(was " + item.FabricType + ")";
                        lbl.CssClass = "changed_value";
                    }
                }
                if (item.SequenceNumber == 2)
                {
                    if (txtFabricType2.Value != item.FabricType)
                    {
                        lbl = tblCostingDetails.FindControl("lblFabricType" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = "(was " + item.FabricType + ")";
                        lbl.CssClass = "changed_value";
                    }
                }
                if (item.SequenceNumber == 3)
                {
                    if (txtFabricType3.Value != item.FabricType)
                    {
                        lbl = tblCostingDetails.FindControl("lblFabricType" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = "(was " + item.FabricType + ")";
                        lbl.CssClass = "changed_value";
                    }
                }
                if (item.SequenceNumber == 4)
                {
                    if (txtFabricType4.Value != item.FabricType)
                    {
                        lbl = tblCostingDetails.FindControl("lblFabricType" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = "(was " + item.FabricType + ")";
                        lbl.CssClass = "changed_value";
                    }
                }

                txt = tblCostingDetails.FindControl("txtWidth" + item.SequenceNumber.ToString()) as TextBox;

                if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != item.Width)
                {
                    lbl = tblCostingDetails.FindControl("lblWidth" + item.SequenceNumber.ToString()) as Label;
                    lbl.Text = "(was " + item.Width.ToString() + ")";
                    lbl.CssClass = "changed_value";
                }

                txt = tblCostingDetails.FindControl("txtAverage" + item.SequenceNumber.ToString()) as TextBox;

                if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != item.Average)
                {
                    lbl = tblCostingDetails.FindControl("lblAverage" + item.SequenceNumber.ToString()) as Label;
                    lbl.Text = "(was " + item.Average.ToString("0.000") + ")";
                    lbl.CssClass = "changed_value";
                }

                txt = tblCostingDetails.FindControl("txtRate" + item.SequenceNumber.ToString()) as TextBox;

                if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != item.Rate)
                {
                    lbl = tblCostingDetails.FindControl("lblRate" + item.SequenceNumber.ToString()) as Label;
                    lbl.Text = "(was " + item.Rate.ToString() + ")";
                    lbl.CssClass = "changed_value";
                }

                txt = tblCostingDetails.FindControl("txtAmount" + item.SequenceNumber.ToString()) as TextBox;

                if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != item.Amount)
                {
                    lbl = tblCostingDetails.FindControl("lblAmount" + item.SequenceNumber.ToString()) as Label;
                    lbl.Text = "(was " + item.Amount.ToString() + ")";
                    lbl.CssClass = "changed_value";
                }

                txt = tblCostingDetails.FindControl("txtWaste" + item.SequenceNumber.ToString()) as TextBox;

                if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != item.Waste)
                {
                    lbl = tblCostingDetails.FindControl("lblWaste" + item.SequenceNumber.ToString()) as Label;
                    lbl.Text = "(was " + item.Waste.ToString() + ")";
                    lbl.CssClass = "changed_value";
                }

                txt = tblCostingDetails.FindControl("txtTotal" + item.SequenceNumber.ToString()) as TextBox;


                if (((txt.Text == string.Empty) ? false : (txt.Text != item.Total.ToString("N2"))))  //Convert.ToDouble(txt.Text)) != Math.Round(item.Total, 2)
                {
                    lbl = tblCostingDetails.FindControl("lblTotal" + item.SequenceNumber.ToString()) as Label;
                    lbl.Text = "(was " + item.Total.ToString("0.00") + ")";
                    lbl.CssClass = "changed_value";
                    isValueChanged = true;
                }

                total = total + item.Total;
            }

            if (isValueChanged)
            {
                lblTotalA.Text = "(was " + total.ToString("0.00") + ")";
                lblTotalA.CssClass = "changed_value";
                isTotalChanged = true;
            }

            totalABC = total;

            total = 0;
            isValueChanged = false;

            foreach (Charges item in objCosting.ChargesItems)
            {
                if (item.SequenceNumber != 11)
                {
                    txt = tblCostingDetails.FindControl("txtChargesName" + item.SequenceNumber.ToString()) as TextBox;

                    if (txt.Text != item.ChargeName)
                    {
                        lbl = tblCostingDetails.FindControl("lblChargesName" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = "(was " + item.ChargeName + ")";
                        lbl.CssClass = "changed_value";
                    }

                    txt = tblCostingDetails.FindControl("txtChargesValue" + item.SequenceNumber.ToString()) as TextBox;

                    if (((txt.Text == string.Empty) ? 0 : Convert.ToInt32(txt.Text)) != item.ChargeValue)
                    {
                        lbl = tblCostingDetails.FindControl("lblChargesValue" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = "(was " + item.ChargeValue + ")";
                        lbl.CssClass = "changed_value";
                        isValueChanged = true;
                    }
                    total = total + item.ChargeValue;
                }

            }
            if (isValueChanged)
            {
                lblTotalB.Text = "(was " + total.ToString() + ")";
                lblTotalB.CssClass = "changed_value";
                isTotalChanged = true;
            }

            totalABC = totalABC + total;

            total = 0;
            isValueChanged = false;

            foreach (Accessories item in objCosting.AccessoryItems)
            {
                if (item.SequenceNumber == 4)
                {
                    if (ddlAccessoriesItem4.SelectedValue != item.Item)
                    {
                        ListItem li = ddlAccessoriesItem4.Items.FindByValue(item.Item);
                        lblAccessoriesItem4.Text = (li != null) ? "(was " + li.Text + ")" : "(Modified)";
                        lblAccessoriesItem4.CssClass = "changed_value";
                    }

                    if (Convert.ToDouble(ddlAccessoriesQuantity4.SelectedValue) != item.Quantity)
                    {
                        ListItem li = ddlAccessoriesQuantity4.Items.FindByValue(item.Quantity.ToString());
                        lblAccessoriesQuantity4.Text = (li != null) ? "(was " + li.Text + ")" : "(Modified)";
                        lblAccessoriesQuantity4.CssClass = "changed_value";
                    }

                    if (Convert.ToDouble(ddlAccessoriesRate4.SelectedValue) != item.Rate)
                    {
                        ListItem li = ddlAccessoriesRate4.Items.FindByValue(item.Rate.ToString());
                        lblAccessoriesRate4.Text = (li != null) ? "(was " + li.Text + ")" : "(Modified)";
                        lblAccessoriesRate4.CssClass = "changed_value";
                    }
                }
                else
                {
                    txt = tblCostingDetails.FindControl("txtAccessoriesItem" + item.SequenceNumber.ToString()) as TextBox;

                    if (txt.Text != item.Item)
                    {
                        lbl = tblCostingDetails.FindControl("lblAccessoriesItem" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = "(was " + item.Item + ")";
                        lbl.CssClass = "changed_value";
                    }

                    txt = tblCostingDetails.FindControl("txtAccessoriesQuantity" + item.SequenceNumber.ToString()) as TextBox;

                    if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != item.Quantity)
                    {
                        lbl = tblCostingDetails.FindControl("lblAccessoriesQuantity" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = "(was " + item.Quantity.ToString("0.000") + ")";
                        lbl.CssClass = "changed_value";
                    }

                    txt = tblCostingDetails.FindControl("txtAccessoriesRate" + item.SequenceNumber.ToString()) as TextBox;

                    if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != item.Rate)
                    {
                        lbl = tblCostingDetails.FindControl("lblAccessoriesRate" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = "(was " + item.Rate.ToString("0.00") + ")";
                        lbl.CssClass = "changed_value";
                    }
                }

                txt = tblCostingDetails.FindControl("txtAccessoriesAmount" + item.SequenceNumber.ToString()) as TextBox;

                if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != Math.Round(item.Amount, 2, MidpointRounding.AwayFromZero))
                {
                    lbl = tblCostingDetails.FindControl("lblAccessoriesAmount" + item.SequenceNumber.ToString()) as Label;
                    lbl.Text = "(was " + item.Amount.ToString("0.00") + ")";
                    lbl.CssClass = "changed_value";
                    isValueChanged = true;
                }


                total = total + item.Amount;
            }

            if (isValueChanged)
            {
                lblTotalC.Text = "(was " + total.ToString("0.00") + ")";
                lblTotalC.CssClass = "changed_value";
                isTotalChanged = true;
            }

            totalABC = totalABC + total;
            isValueChanged = false;

            if (isTotalChanged)
            {
                lblTotalABC.Text = "(was " + totalABC.ToString("0.00") + ")";
                lblTotalABC.CssClass = "changed_value";
            }

            isTotalChanged = false;

            if (((txtConvRate.Text == string.Empty) ? 0 : Convert.ToDouble(txtConvRate.Text)) != objCosting.ConversionRate)
            {
                lblConvRate.Text = "(was " + objCosting.ConversionRate.ToString("0.00") + ")";
                lblConvRate.CssClass = "changed_value";
            }

            if (((txtMarkupOnUnitCtc.Text == string.Empty) ? 0 : Convert.ToDouble(txtMarkupOnUnitCtc.Text)) != objCosting.MarkupOnUnitCTC)
            {
                lblMarkupOnUnitCtc.Text = "(was " + objCosting.MarkupOnUnitCTC + ")";
                lblMarkupOnUnitCtc.CssClass = "changed_value";
            }
            if (((txtFrtUptoFinalDest.Text == string.Empty) ? 0 : Convert.ToDouble(txtFrtUptoFinalDest.Text)) != objCosting.FrieghtUptoFinalDestination)
            {
                LblWastage.Text = "(was " + objCosting.FrieghtUptoFinalDestination + ")";
                LblWastage.CssClass = "changed_value";
            }
            if (((txtFrtUptoPort.Text == string.Empty) ? 0 : Convert.ToDouble(txtFrtUptoPort.Text)) != objCosting.FrieghtUptoPort)
            {
                lblFrtUptoPort.Text = "(was " + objCosting.FrieghtUptoPort + ")";
                lblFrtUptoPort.CssClass = "changed_value";
            }


            if (((txtComm.Text == string.Empty) ? 0 : Convert.ToDouble(txtComm.Text)) != objCosting.CommisionPercent)
            {
                lblComm.Text = "(was " + objCosting.CommisionPercent + ")";
                lblComm.CssClass = "changed_value";
            }

            if (((txtPriceQuoted.Text == string.Empty) ? 0 : Convert.ToDouble(txtPriceQuoted.Text)) != objCosting.PriceQuoted)
            {
                lblPriceQuoted.Text = "(was " + objCosting.PriceQuoted.ToString("0.00") + ")";
                lblPriceQuoted.CssClass = "changed_value";
            }

            lbliKandiHistory.Text = objCosting.iKandiChangesHistory.Replace("$$", "<br/>").Replace("<br/><br/>", "<br/>");
        }

        private string GetBIPLChangesHistory(Costing newCosting, int StatusModeID)
        {

            if (CostingObject == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            //if (StatusModeID >= (int)TaskMode.COSTING_BIPL)
            if (true == true)
            {
                int i = 0;

                FabricCosting newFabricCosting = null;
                FabricCosting oldFabricCosting = null;

                for (i = 0; i < 4; i++)
                {
                    newFabricCosting = null;
                    oldFabricCosting = null;

                    if (newCosting.FabricCostingItems != null && newCosting.FabricCostingItems.Count > 0)
                    {
                        newFabricCosting = newCosting.FabricCostingItems.Find(delegate(FabricCosting FC) { return FC.SequenceNumber == (i + 1); });
                    }

                    if (CostingObject.FabricCostingItems != null && CostingObject.FabricCostingItems.Count > 0)
                    {
                        oldFabricCosting = CostingObject.FabricCostingItems.Find(delegate(FabricCosting FC) { return FC.SequenceNumber == (i + 1); });
                    }

                    if (oldFabricCosting == null && newFabricCosting != null)
                    {
                        if (newFabricCosting.Fabric != null && newFabricCosting.Fabric.Trim() != string.Empty)
                        {
                            //sb.Append("$$ "
                            // + "<span style='font-size:10px !important; color:#807f80;'>"
                            // + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "Fabric " + (i + 1) + " changed by "
                            // + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                            // + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newFabricCosting.Fabric + "</span>"
                            // + "<span style='font-size:10px !important; color:#807f80;'> was " + "''" + "</span>");

                            //sb.Append("$$ "
                            // + "<span style='font-size:10px !important; color:#000000;'>"
                            // + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + "Fabric " + (i + 1) + " changed by" + " " + "</span>"
                            // + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                            // + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Fabric + "</span>"
                            // + "<span style='font-size:10px !important; color:#000000;'> was " + "''" + "</span>");

                            //updated by abhishek on 20/8/2015
                            sb.Append("$$ "
                         + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Fabric + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + "''" + "</span>");
                            //end by abhishek 20/8/2015



                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "Fabric " + (i + 1) + " changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper()+ " " + newFabricCosting.Fabric + " was ''");
                        }
                        if (newFabricCosting.FabricType != null && newFabricCosting.FabricType.Trim() != string.Empty)
                        {
                            //sb.Append("$$ "
                            // + "<span style='font-size:10px !important; color:#807f80;'>"
                            // + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newFabricCosting.Fabric + " detail changed by "
                            // + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                            // + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newFabricCosting.FabricType + "</span>"
                            // + "<span style='font-size:10px !important; color:#807f80;'> was " + "''" + "</span>");

                            //sb.Append("$$ "
                            //+ "<span style='font-size:10px !important; color:#000000;'>"
                            //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + newFabricCosting.Fabric + " detail changed by " + " " + "</span>"
                            //+ "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                            //+ "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.FabricType + "</span>"
                            //+ "<span style='font-size:10px !important; color:#000000;'> was " + "''" + "</span>");




                            //updated by abhishek on 20/8/2015
                            sb.Append("$$ "
                         + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Fabric + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + "''" + "</span>");
                            //end by abhishek 20/8/2015


                            // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newFabricCosting.Fabric + " detail changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newFabricCosting.FabricType + " was ''");
                        }
                        if (newFabricCosting.Average != 0)
                        {
                            //sb.Append("$$ "
                            // + "<span style='font-size:10px !important; color:#807f80;'>"
                            // + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newFabricCosting.Fabric + " Avg changed by "
                            // + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                            // + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newFabricCosting.Average.ToString("N2") + "</span>"
                            // + "<span style='font-size:10px !important; color:#807f80;'> was " + " 0" + "</span>");



                            // sb.Append("$$ "
                            //+ "<span style='font-size:10px !important; color:#000000;'>"
                            //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + newFabricCosting.Fabric + " Avg changed by " + " " + "</span>"
                            //+ "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                            //+ "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Average.ToString("N2") + "</span>"
                            //+ "<span style='font-size:10px !important; color:#000000;'> was " + " 0" + "</span>");



                            //updated by abhishek on 20/8/2015
                            sb.Append("$$ "
                         + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Fabric + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + " 0" + "</span>");
                            //end by abhishek 20/8/2015

                            //  sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newFabricCosting.Fabric + " Avg changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newFabricCosting.Average.ToString("N2") + " was 0");
                        }
                        if (newFabricCosting.Rate != 0)
                        {




                            //sb.Append("$$ "
                            // + "<span style='font-size:10px !important; color:#807f80;'>"
                            // + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newFabricCosting.Fabric + " Rate changed by "
                            // + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                            // + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newFabricCosting.Rate.ToString("N2") + "</span>"
                            // + "<span style='font-size:10px !important; color:#807f80;'> was " + " 0" + "</span>");




                            //   sb.Append("$$ "
                            //+ "<span style='font-size:10px !important; color:#000000;'>"
                            //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + newFabricCosting.Fabric + "  Rate changed by  " + " " + "</span>"
                            //+ "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                            //+ "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Rate.ToString("N2") + "</span>"
                            //+ "<span style='font-size:10px !important; color:#000000;'> was " + " 0" + "</span>");



                            //updated by abhishek on 20/8/2015
                            sb.Append("$$ "
                         + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Rate changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Rate.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + " 0" + "</span>");
                            //end by abhishek 20/8/2015

                            // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newFabricCosting.Fabric + " Rate changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newFabricCosting.Rate.ToString("N2") + " was 0");
                        }
                    }

                    if (oldFabricCosting != null && newFabricCosting == null)
                    {
                        if (oldFabricCosting.Fabric != null && oldFabricCosting.Fabric.Trim() != string.Empty)
                        {
                            //sb.Append("$$ "
                            // + "<span style='font-size:10px !important; color:#807f80;'>"
                            // + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "Fabric " + (i + 1) + " changed by "
                            // + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                            // + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + "''" + "</span>"
                            // + "<span style='font-size:10px !important; color:#807f80;'> was " + oldFabricCosting.Fabric + "</span>");



                            //       sb.Append("$$ "
                            //+ "<span style='font-size:10px !important; color:#000000;'>"
                            //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + "Fabric " + (i + 1) + "  changed by  " + " " + "</span>"
                            //+ "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                            //+ "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "''" + "</span>"
                            //+ "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Fabric + "</span>");

                            //updated by abhishek on 20/8/2015
                            sb.Append("$$ "
                         + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric " + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "''" + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Fabric + "</span>");
                            //end by abhishek 20/8/2015

                            // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "Fabric " + (i + 1) + " changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " ''" + " was " + oldFabricCosting.Fabric);
                        }
                        if (oldFabricCosting.FabricType != null && oldFabricCosting.FabricType.Trim() != string.Empty)
                        {
                            //sb.Append("$$ "
                            // + "<span style='font-size:10px !important; color:#807f80;'>"
                            // + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + oldFabricCosting.Fabric + " detail changed by "
                            // + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                            // + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + "''" + "</span>"
                            // + "<span style='font-size:10px !important; color:#807f80;'> was " + oldFabricCosting.FabricType + "</span>");




                            //         sb.Append("$$ "
                            //+ "<span style='font-size:10px !important; color:#000000;'>"
                            //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + oldFabricCosting.Fabric + "  detail changed by  " + " " + "</span>"
                            //+ "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                            //+ "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "''" + "</span>"
                            //+ "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.FabricType + "</span>");



                            //updated by abhishek on 20/8/2015
                            sb.Append("$$ "
                         + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + oldFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  detail changed by  " + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "''" + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.FabricType + "</span>");
                            //end by abhishek 20/8/2015

                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + oldFabricCosting.Fabric + " detail changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " ''" + " was " + oldFabricCosting.FabricType);
                        }
                        if (oldFabricCosting.Average != 0)
                        {
                            //sb.Append("$$ "
                            //  + "<span style='font-size:10px !important; color:#807f80;'>"
                            //  + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + oldFabricCosting.Fabric + " Avg changed by "
                            //  + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                            //  + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + "0" + "</span>"
                            //  + "<span style='font-size:10px !important; color:#807f80;'> was " + oldFabricCosting.Average.ToString("N2") + "</span>");


                            //          sb.Append("$$ "
                            //+ "<span style='font-size:10px !important; color:#000000;'>"
                            //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + oldFabricCosting.Fabric + " Avg changed by" + " " + "</span>"
                            //+ "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                            //+ "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                            //+ "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Average.ToString("N2") + "</span>");

                            //updated by abhishek on 20/8/2015
                            sb.Append("$$ "
                         + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + oldFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Avg changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Average.ToString("N2") + "</span>");
                            //end by abhishek 20/8/2015


                            // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + oldFabricCosting.Fabric + " Avg changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " 0" + " was " + oldFabricCosting.Average.ToString("N2"));
                        }
                        if (oldFabricCosting.Rate != 0)
                        {
                            //sb.Append("$$ "
                            //   + "<span style='font-size:10px !important; color:#807f80;'>"
                            //   + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + oldFabricCosting.Fabric + " Rate changed by "
                            //   + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                            //   + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + "0" + "</span>"
                            //   + "<span style='font-size:10px !important; color:#807f80;'> was " + oldFabricCosting.Rate.ToString("N2") + "</span>");


                            //             sb.Append("$$ "
                            //+ "<span style='font-size:10px !important; color:#000000;'>"
                            //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + oldFabricCosting.Fabric + " Rate changed by" + " " + "</span>"
                            //+ "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                            //+ "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                            //+ "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Rate.ToString("N2") + "</span>");


                            //updated by abhishek on 20/8/2015
                            sb.Append("$$ "
                         + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + oldFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Rate changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Rate.ToString("N2") + "</span>");
                            //end by abhishek 20/8/2015

                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + oldFabricCosting.Fabric + " Rate changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " 0" + " was " + oldFabricCosting.Rate.ToString("N2"));
                        }
                    }

                    if (oldFabricCosting != null && newFabricCosting != null)
                    {
                        if (newFabricCosting.Fabric.Trim().ToLower() != oldFabricCosting.Fabric.Trim().ToLower())
                        {
                            //sb.Append("$$ "
                            //   + "<span style='font-size:10px !important; color:#807f80;'>"
                            //   + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "Fabric " + (i + 1) + " changed by "
                            //   + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                            //   + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newFabricCosting.Fabric + "</span>"
                            //   + "<span style='font-size:10px !important; color:#807f80;'> was " + oldFabricCosting.Fabric + "</span>");



                            //             sb.Append("$$ "
                            //+ "<span style='font-size:10px !important; color:#000000;'>"
                            //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + "Fabric " + (i + 1) + " changed by" + " " + "</span>"
                            //+ "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                            //+ "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Fabric + "</span>"
                            //+ "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Fabric + "</span>");


                            //updated by abhishek on 20/8/2015
                            sb.Append("$$ "
                         + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric " + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Fabric + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Fabric + "</span>");
                            //end by abhishek 20/8/2015


                            // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "Fabric " + (i + 1) + " changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newFabricCosting.Fabric + " was " + oldFabricCosting.Fabric);
                        }
                        if (newFabricCosting.FabricType.Trim().ToLower() != oldFabricCosting.FabricType.Trim().ToLower())
                        {
                            //sb.Append("$$ "
                            //   + "<span style='font-size:10px !important; color:#807f80;'>"
                            //   + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newFabricCosting.Fabric + " detail changed by "
                            //   + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                            //   + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newFabricCosting.Fabric + "</span>"
                            //   + "<span style='font-size:10px !important; color:#807f80;'> was " + oldFabricCosting.FabricType + "</span>");

                            //             sb.Append("$$ "
                            //+ "<span style='font-size:10px !important; color:#000000;'>"
                            //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + newFabricCosting.Fabric + " detail changed by" + " " + "</span>"
                            //+ "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                            //+ "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Fabric + "</span>"
                            //+ "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.FabricType + "</span>");

                            //updated by abhishek on 20/8/2015
                            sb.Append("$$ "
                         + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " detail changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Fabric + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.FabricType + "</span>");
                            //end by abhishek 20/8/2015


                            // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newFabricCosting.Fabric + " detail changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newFabricCosting.Fabric + " was " + oldFabricCosting.FabricType);
                        }
                        if (oldFabricCosting.Average != newFabricCosting.Average)
                        {
                            //sb.Append("$$ "
                            //    + "<span style='font-size:10px !important; color:#807f80;'>"
                            //    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newFabricCosting.Fabric + " Avg changed by "
                            //    + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                            //    + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newFabricCosting.Average.ToString("N2") + "</span>"
                            //    + "<span style='font-size:10px !important; color:#807f80;'> was " + oldFabricCosting.Average.ToString("N2") + "</span>");


                            //               sb.Append("$$ "
                            //+ "<span style='font-size:10px !important; color:#000000;'>"
                            //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + newFabricCosting.Fabric + " Avg changed by" + " " + "</span>"
                            //+ "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                            //+ "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Average.ToString("N2") + "</span>"
                            //+ "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Average.ToString("N2") + "</span>");



                            //updated by abhishek on 20/8/2015
                            sb.Append("$$ "
                         + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Avg changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Average.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Average.ToString("N2") + "</span>");
                            //end by abhishek 20/8/2015
                        }
                        if (oldFabricCosting.Rate != newFabricCosting.Rate)
                        {
                            //sb.Append("$$"
                            //    + "<span style='font-size:10px !important; color:#807f80;'>"
                            //    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newFabricCosting.Fabric + " Rate changed by "
                            //    + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                            //    + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newFabricCosting.Rate.ToString("N2") + "</span>"
                            //    + "<span style='font-size:10px !important; color:#807f80;'> was " + oldFabricCosting.Rate.ToString("N2") + "</span>");

                            //                sb.Append("$$ "
                            //+ "<span style='font-size:10px !important; color:#000000;'>"
                            //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + newFabricCosting.Fabric + " Rate changed by" + " " + "</span>"
                            //+ "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                            //+ "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Rate.ToString("N2") + "</span>"
                            //+ "<span style='font-size:10px !important; color:#0000FF;'> was " + oldFabricCosting.Rate.ToString("N2") + "</span>");



                            //updated by abhishek on 20/8/2015
                            sb.Append("$$ "
                         + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Rate changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Rate.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Rate.ToString("N2") + "</span>");
                            //end by abhishek 20/8/2015
                        }
                    }

                }


                i = 0;

                Charges newCharges = null;
                Charges oldCharges = null;

                for (i = 0; i <= 10; i++)
                {
                    newCharges = null;
                    oldCharges = null;

                    if ((i >= 0 && i <= 2) || (i >= 8 && i <= 10))
                    {
                        if (newCosting.ChargesItems != null && newCosting.ChargesItems.Count > 0)
                        {
                            newCharges = newCosting.ChargesItems.Find(delegate(Charges C) { return C.SequenceNumber == (i + 1); });
                        }

                        if (CostingObject.ChargesItems != null && CostingObject.ChargesItems.Count > 0)
                        {
                            oldCharges = CostingObject.ChargesItems.Find(delegate(Charges C) { return C.SequenceNumber == (i + 1); });
                        }

                        if (oldCharges == null && newCharges != null)
                        {
                            if (newCharges.ChargeValue != 0)
                            {
                                // update by surendra for technical module
                                //if (newCharges.ChargeName == "SAM")
                                //    newCharges.ChargeName = "CMT";
                                // sb.Append("$$"
                                //+ "<span style='font-size:10px !important; color:#807f80;'>"
                                //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newCharges.ChargeName + " changed by "
                                //+ ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                                //+ "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newCharges.ChargeValue.ToString("N1") + "</span>"
                                //+ "<span style='font-size:10px !important; color:#807f80;'> was " + " 0" + "</span>");

                                //                     sb.Append("$$ "
                                //+ "<span style='font-size:10px !important; color:#000000;'>"
                                //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + newCharges.ChargeName + " changed by" + " " + "</span>"
                                //+ "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                                //+ "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCharges.ChargeValue.ToString("N1") + "</span>"
                                //+ "<span style='font-size:10px !important; color:#000000;'> was " + " 0" + "</span>");
                                //  sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newCharges.ChargeName + " changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newCharges.ChargeValue.ToString("N0") + " was 0");


                                //updated by abhishek on 20/8/2015

                                string newchar = newCharges.ChargeName.ToString() == "SAM" ? "CMT" : newCharges.ChargeName.ToString();

                                sb.Append("$$ "
                             + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                             + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newchar + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " changed by" + " " + "</span>"
                             + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                             + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCharges.ChargeValue.ToString("N1") + "</span>"
                             + "<span style='font-size:10px !important; color:#000000;'> was " + " 0" + "</span>");
                                //end by abhishek 20/8/2015
                            }
                        }
                        // end

                        if (oldCharges != null && newCharges == null)
                        {
                            if (oldCharges.ChargeValue != 0)
                            {
                                // update by surendra for technical module
                                //if (oldCharges.ChargeName == "SAM")
                                //    oldCharges.ChargeName = "CMT";
                                //  sb.Append("$$"
                                //+ "<span style='font-size:10px !important; color:#807f80;'>"
                                //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + oldCharges.ChargeName + " changed by "
                                //+ ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                                //+ "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + "0" + "</span>"
                                //+ "<span style='font-size:10px !important; color:#807f80;'> was " + oldCharges.ChargeValue.ToString("N1") + "</span>");

                                //sb.Append("$$ "
                                //           + "<span style='font-size:10px !important; color:#000000;'>"
                                //           + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + oldCharges.ChargeName + " changed by" + " " + "</span>"
                                //           + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                                //           + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                                //           + "<span style='font-size:10px !important; color:#000000;'> was " + oldCharges.ChargeValue.ToString("N1") + "</span>");




                                //updated by abhishek on 20/8/2015

                                string old = oldCharges.ChargeName.ToString() == "SAM" ? "CMT" : oldCharges.ChargeName.ToString();

                                sb.Append("$$ "
                             + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                             + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + old + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " changed by" + " " + "</span>"
                             + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                             + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                             + "<span style='font-size:10px !important; color:#000000;'> was " + oldCharges.ChargeValue.ToString("N1") + "</span>");
                                //end by abhishek 20/8/2015

                                // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + oldCharges.ChargeName + " changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " 0 " + " was " + oldCharges.ChargeValue.ToString("N0"));
                            }
                        }
                        // end

                        if (oldCharges != null && newCharges != null)
                        {
                            if (newCharges.ChargeValue != oldCharges.ChargeValue)
                            // update by surendra for technical module
                            {
                                //if (newCharges.ChargeName == "SAM")
                                //    newCharges.ChargeName = "CMT";
                                //     sb.Append("$$"
                                //+ "<span style='font-size:10px !important; color:#807f80;'>"
                                //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newCharges.ChargeName + " changed by "
                                //+ ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                                //+ "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newCharges.ChargeValue.ToString("N1") + "</span>"
                                //+ "<span style='font-size:10px !important; color:#807f80;'> was " + oldCharges.ChargeValue.ToString("N1") + "</span>");



                                //sb.Append("$$ "
                                //          + "<span style='font-size:10px !important; color:#000000;'>"
                                //          + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + newCharges.ChargeName + " changed by" + " " + "</span>"
                                //          + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                                //          + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCharges.ChargeValue.ToString("N1") + "</span>"
                                //          + "<span style='font-size:10px !important; color:#000000;'> was " + oldCharges.ChargeValue.ToString("N1") + "</span>");


                                string ss = newCharges.ChargeName.ToString() == "SAM" ? "CMT" : newCharges.ChargeName.ToString();


                                //updated by abhishek on 20/8/2015
                                sb.Append("$$ "
                             + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                             + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + ss + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " changed by" + " " + "</span>"
                             + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                             + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCharges.ChargeValue.ToString("N1") + "</span>"
                             + "<span style='font-size:10px !important; color:#000000;'> was " + oldCharges.ChargeValue.ToString("N1") + "</span>");
                                //end by abhishek 20/8/2015



                                //  sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newCharges.ChargeName + " changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newCharges.ChargeValue.ToString("N0") + " was " + oldCharges.ChargeValue.ToString("N0"));
                            }
                        }
                        // end
                    }
                }


                i = 0;

                Accessories newAccessories = null;
                Accessories oldAccessories = null;

                for (i = 0; i < 10; i++)
                {
                    newAccessories = null;
                    oldAccessories = null;

                    if (i == 3 || i == 8 || i == 9)
                    {
                        if (newCosting.AccessoryItems != null && newCosting.AccessoryItems.Count > 0)
                        {
                            newAccessories = newCosting.AccessoryItems.Find(delegate(Accessories ACC) { return ACC.SequenceNumber == (i + 1); });
                        }

                        if (CostingObject.AccessoryItems != null && CostingObject.AccessoryItems.Count > 0)
                        {
                            oldAccessories = CostingObject.AccessoryItems.Find(delegate(Accessories ACC) { return ACC.SequenceNumber == (i + 1); });
                        }

                        if (oldAccessories == null && newAccessories != null)
                        {
                            if (i == 3 && !string.IsNullOrEmpty(newAccessories.Item))
                            {
                                //      sb.Append("$$"
                                //+ "<span style='font-size:10px !important; color:#807f80;'>"
                                //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": Zip selected by " 
                                //+ ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newAccessories.Item +"</span>");


                                //sb.Append("$$ "
                                //          + "<span style='font-size:10px !important; color:#000000;'>"
                                //          + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + " Zip selected by " + " " + "</span>"
                                //          + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                                //          + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Item + "</span>"
                                //          );





                                //updated by abhishek on 20/8/2015
                                sb.Append("$$ "
                             + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                             + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  Zip selected by" + " " + "</span>"
                             + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"


                             + "<span style='font-size:10px !important; color:#000000;'> was " + newAccessories.Item + "</span>");
                                //end by abhishek 20/8/2015

                                // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Zip selected by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newAccessories.Item);
                            }

                            if (newAccessories.Rate != 0)
                            {
                                if (i == 3)
                                    //            sb.Append("$$"
                                    //+ "<span style='font-size:10px !important; color:#807f80;'>"
                                    //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": "+ newAccessories.Item + " Size selected by "
                                    //+ ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newAccessories.Rate +"</span>"); 

                                    //sb.Append("$$ "
                                    //     + "<span style='font-size:10px !important; color:#000000;'>"
                                    //     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + " Size selected by " + " " + "</span>"
                                    //     + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                                    //     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Rate + "</span>"
                                    //     )
                                    //     ;

                                    //updated by abhishek on 20/8/2015
                                    sb.Append("$$ "
                                 + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Size selected by " + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"


                                 + "<span style='font-size:10px !important; color:#000000;'> was " + newAccessories.Rate + "</span>");
                                //end by abhishek 20/8/2015



                                   // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newAccessories.Item + " Size selected by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newAccessories.Rate);
                                else
                                    //          sb.Append("$$"
                                    //+ "<span style='font-size:10px !important; color:#807f80;'>"
                                    //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newAccessories.Item + " changed by "
                                    //+ ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                                    //+ "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newAccessories.Rate.ToString("N2") + "</span>"
                                    //+ "<span style='font-size:10px !important; color:#807f80;'> was  0 </span>");

                                    //sb.Append("$$ "
                                    //    + "<span style='font-size:10px !important; color:#000000;'>"
                                    //    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + newAccessories.Item + " changed by" + " " + "</span>"
                                    //    + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                                    //    + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Rate.ToString("N2") + "</span>"
                                    //    + "<span style='font-size:10px !important; color:#000000;'> was " + "0" + "</span>");

                                    //updated by abhishek on 20/8/2015
                                    sb.Append("$$ "
                                 + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newAccessories.Item + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " changed by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Rate.ToString("N2") + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'> was " + "0" + "</span>");
                                //end by abhishek 20/8/2015

                                // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newAccessories.Item + " changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newAccessories.Rate.ToString("N2") + " was 0");
                            }
                        }

                        if (oldAccessories != null && newAccessories == null)
                        {
                            if (i == 3 && !string.IsNullOrEmpty(oldAccessories.Item))
                            {
                                //        sb.Append("$$"
                                //  + "<span style='font-size:10px !important; color:#807f80;'>"
                                //  + DateTime.Now.ToString("dd MMM yy (ddd)") + ":  Zip removed by "
                                //  + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                                ////  + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newAccessories.Rate.ToString("N2") + "</span>"
                                //  + "<span style='font-size:10px !important; color:#807f80;'> was " + oldAccessories.Item + "</span>");


                                //sb.Append("$$ "
                                //       + "<span style='font-size:10px !important; color:#000000;'>"
                                //       + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + "  Zip removed by" + " " + "</span>"
                                //       + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                                //       + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Rate.ToString("N2") + "</span>"
                                //       + "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Item + "</span>");



                                //updated by abhishek on 20/8/2015
                                if (newAccessories == null)
                                    sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Zip removed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " was " + oldAccessories.Item);
                                else
                                    sb.Append("$$ "
                                 + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  Zip removed by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Rate.ToString("N2") + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Item + "</span>");
                                //end by abhishek 20/8/2015



                            }

                            if (oldAccessories.Rate != 0)
                            {
                                if (i == 3)
                                {
                                    //sb.Append("$$"
                                    //    + "<span style='font-size:10px !important; color:#807f80;'>"
                                    //    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + oldAccessories.Item + " Size unselected by "
                                    //    + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                                    //   // + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newAccessories.Rate.ToString("N2") + "</span>"
                                    //    + "<span style='font-size:10px !important; color:#807f80;'> was " + oldAccessories.Rate + "</span>");

                                    //sb.Append("$$ "
                                    //   + "<span style='font-size:10px !important; color:#000000;'>"
                                    //   + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + "  Size unselected by" + " " + "</span>"
                                    //   + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                                    //   + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Rate.ToString("N2") + "</span>"
                                    //   + "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Rate + "</span>");

                                    //updated by abhishek on 20/8/2015
                                    if (newAccessories == null)
                                        sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + oldAccessories.Item + " Size unselected by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " was " + oldAccessories.Rate);
                                    else
                                        sb.Append("$$ "
                                     + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  Size unselected by" + " " + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Rate.ToString("N2") + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Rate + "</span>");
                                    //end by abhishek 20/8/2015



                                    // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + oldAccessories.Item + " Size unselected by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " was " + oldAccessories.Rate);
                                }
                                else
                                {
                                    //sb.Append("$$"
                                    //    + "<span style='font-size:10px !important; color:#807f80;'>"
                                    //    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + oldAccessories.Item + " changed by "
                                    //    + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                                    //     + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + "0" + "</span>"
                                    //    + "<span style='font-size:10px !important; color:#807f80;'> was " + oldAccessories.Rate.ToString("N2") + "</span>");

                                    //sb.Append("$$ "
                                    //  + "<span style='font-size:10px !important; color:#000000;'>"
                                    //  + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + oldAccessories.Item + " changed by" + " " + "</span>"
                                    //  + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                                    //  + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                                    //  + "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Rate.ToString("N2") + "</span>");
                                    //updated by abhishek on 20/8/2015


                                    sb.Append("$$ "
                         + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + oldAccessories.Item + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Rate.ToString("N2") + "</span>");
                                    //end by abhishek 20/8/2015



                                    // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + oldAccessories.Item + " changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " 0 " + " was " + oldAccessories.Rate.ToString("N2"));
                                }
                            }
                        }

                        if (oldAccessories != null && newAccessories != null)
                        {
                            if (i == 3 && !string.IsNullOrEmpty(oldAccessories.Item) && !string.IsNullOrEmpty(newAccessories.Item) && oldAccessories.Item.ToLower() != newAccessories.Item.ToLower())
                            {
                                //sb.Append("$$"
                                //        + "<span style='font-size:10px !important; color:#807f80;'>"
                                //        + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Zip changed by "
                                //        + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                                //         + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newAccessories.Item + "</span>"
                                //        + "<span style='font-size:10px !important; color:#807f80;'> was " + oldAccessories.Item + "</span>");

                                //sb.Append("$$ "
                                //    + "<span style='font-size:10px !important; color:#000000;'>"
                                //    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + " Zip changed by" + " " + "</span>"
                                //    + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                                //    + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Item + "</span>"
                                //    + "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Item + "</span>");

                                //updated by abhishek on 20/8/2015
                                sb.Append("$$ "
                       + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                       + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Zip changed by" + " " + "</span>"
                       + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                       + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Item + "</span>"
                       + "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Item + "</span>");

                                //end by abhishek 20/8/2015

                                //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Zip changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newAccessories.Item + " was " + oldAccessories.Item);

                            }

                            if (newAccessories.Rate != oldAccessories.Rate)
                            {
                                if (i == 3)
                                {
                                    //sb.Append("$$"
                                    //    + "<span style='font-size:10px !important; color:#807f80;'>"
                                    //    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newAccessories.Item + " changed by "
                                    //    + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                                    //     + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newAccessories.Rate + "</span>"
                                    //    + "<span style='font-size:10px !important; color:#807f80;'> was " + oldAccessories.Rate + "</span>");


                                    //  sb.Append("$$ "
                                    //+ "<span style='font-size:10px !important; color:#000000;'>"
                                    //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + newAccessories.Item + " changed by" + " " + "</span>"
                                    //+ "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                                    //+ "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Rate + "</span>"
                                    //+ "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Rate + "</span>");

                                    //updated by abhishek on 20/8/2015
                                    sb.Append("$$ "
                         + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newAccessories.Item + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Rate + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Rate + "</span>");
                                    //end by abhishek 20/8/2015


                                    // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newAccessories.Item + " changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newAccessories.Rate + " was " + oldAccessories.Rate);
                                }
                                else
                                {
                                    //sb.Append("$$"
                                    //    + "<span style='font-size:10px !important; color:#807f80;'>"
                                    //    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newAccessories.Item + " changed by "
                                    //    + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                                    //     + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newAccessories.Rate.ToString("N2") + "</span>"
                                    //    + "<span style='font-size:10px !important; color:#807f80;'> was " + oldAccessories.Rate.ToString("N2") + "</span>");


                                    //  sb.Append("$$ "
                                    //+ "<span style='font-size:10px !important; color:#000000;'>"
                                    //+ DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + newAccessories.Item + " changed by" + " " + "</span>"
                                    //+ "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                                    //+ "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Rate.ToString("N2") + "</span>"
                                    //+ "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Rate.ToString("N2") + "</span>");

                                    //updated by abhishek on 20/8/2015
                                    sb.Append("$$ "
                        + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                        + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newAccessories.Item + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                        + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                        + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Rate.ToString("N2") + "</span>"
                        + "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Rate.ToString("N2") + "</span>");
                                    //end by abhishek 20/8/2015


                                    // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + newAccessories.Item + " changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newAccessories.Rate.ToString("N2") + " was " + oldAccessories.Rate.ToString("N2"));
                                }
                            }
                        }
                    }
                }
                //abhishek continue 
                if (newCosting.ConversionRate != CostingObject.ConversionRate)
                {
                    //sb.Append("$$"
                    //                    + "<span style='font-size:10px !important; color:#807f80;'>"
                    //                    + DateTime.Now.ToString("dd MMM yy (ddd)") + " : Conversion Rate changed by "
                    //                    + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                    //                     + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newCosting.ConversionRate.ToString("N2") + "</span>"
                    //                    + "<span style='font-size:10px !important; color:#807f80;'> was " + CostingObject.ConversionRate.ToString("N2") + "</span>");

                    //sb.Append("$$ "
                    //            + "<span style='font-size:10px !important; color:#000000;'>"
                    //            + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + " Conversion Rate changed by" + " " + "</span>"
                    //            + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                    //            + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.ConversionRate.ToString("N2") + "</span>"
                    //            + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.ConversionRate.ToString("N2") + "</span>");



                    //updated by abhishek on 20/8/2015
                    sb.Append("$$ "
        + "<span style='font-size:10px !important; color:#A9A9A9;'>"
        + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Conversion Rate changed by" + " " + "</span>"
        + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

        + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.ConversionRate.ToString("N2") + "</span>"
        + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.ConversionRate.ToString("N2") + "</span>");
                    //end by abhishek 20/8/2015



                    // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Conversion Rate changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newCosting.ConversionRate.ToString("N2") + " was " + CostingObject.ConversionRate.ToString("N2"));
                }
                if (newCosting.MarkupOnUnitCTC != CostingObject.MarkupOnUnitCTC)
                {
                    //sb.Append("$$"
                    //                    + "<span style='font-size:10px !important; color:#807f80;'>"
                    //                    + DateTime.Now.ToString("dd MMM yy (ddd)") + " : Markup On Unit CTC changed by" + " " 
                    //                    + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                    //                    + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newCosting.MarkupOnUnitCTC.ToString("N2") + "</span>"
                    //                    + "<span style='font-size:10px !important; color:#807f80;'> was " + CostingObject.MarkupOnUnitCTC.ToString("N2") + "</span>");
                    //sb.Append("$$ "
                    //           + "<span style='font-size:10px !important; color:#000000;'>"
                    //           + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + "  Markup On Unit CTC changed by" + " " + "</span>"
                    //           + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                    //           + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.MarkupOnUnitCTC.ToString("N2") + "</span>"
                    //           + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.MarkupOnUnitCTC.ToString("N2") + "</span>");



                    //updated by abhishek on 20/8/2015
                    sb.Append("$$ "
        + "<span style='font-size:10px !important; color:#A9A9A9;'>"
        + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Profit Margin Changed by" + " " + "</span>"
        + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

        + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.MarkupOnUnitCTC.ToString("N2") + "</span>"
        + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.MarkupOnUnitCTC.ToString("N2") + "</span>");
                    //end by abhishek 20/8/2015

                    // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Markup On Unit CTC changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newCosting.MarkupOnUnitCTC.ToString("N2") + " was " + CostingObject.MarkupOnUnitCTC.ToString("N2"));
                }
                if (newCosting.CommisionPercent != CostingObject.CommisionPercent)
                {
                    //sb.Append("$$"
                    //                    + "<span style='font-size:10px !important; color:#807f80;'>"
                    //                    + DateTime.Now.ToString("dd MMM yy (ddd)") + " : Commision changed by " + " " 
                    //                    + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                    //                    + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newCosting.CommisionPercent.ToString("N0") + "</span>"
                    //                    + "<span style='font-size:10px !important; color:#807f80;'> was " + CostingObject.CommisionPercent.ToString("N0") + "</span>");

                    //sb.Append("$$ "
                    //         + "<span style='font-size:10px !important; color:#000000;'>"
                    //         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + "  Commision changed by" + " " + "</span>"
                    //         + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                    //         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.CommisionPercent.ToString("N0") + "</span>"
                    //         + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.CommisionPercent.ToString("N0") + "</span>");





                    //updated by abhishek on 20/8/2015
                    sb.Append("$$ "
        + "<span style='font-size:10px !important; color:#A9A9A9;'>"
        + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Commision changed by" + " " + "</span>"
        + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

        + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.CommisionPercent.ToString("N0") + "</span>"
        + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.CommisionPercent.ToString("N0") + "</span>");
                    //end by abhishek 20/8/2015

                    // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Commision changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newCosting.CommisionPercent.ToString("N0") + " was " + CostingObject.CommisionPercent.ToString("N0"));
                }
                if (newCosting.PriceQuoted != CostingObject.PriceQuoted)
                {
                    //sb.Append("$$"
                    //                    + "<span style='font-size:10px !important; color:#807f80;'>"
                    //                    + DateTime.Now.ToString("dd MMM yy (ddd)") + " : Price Quoted changed by" + " " 
                    //                    + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                    //                    + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newCosting.PriceQuoted.ToString("N2") + "</span>"
                    //                    + "<span style='font-size:10px !important; color:#807f80;'> was " + CostingObject.PriceQuoted.ToString("N2") + "</span>");

                    //added by abhishek on 19/8/2015

                    //sb.Append("$$ "
                    //      + "<span style='font-size:10px !important; color:#000000;'>"
                    //      + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + "  Price Quoted changed by" + " " + "</span>"
                    //      + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                    //      + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.PriceQuoted.ToString("N2") + "</span>"
                    //      + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.PriceQuoted.ToString("N2") + "</span>");

                    //added by abhishek on 19/8/2015
                    sb.Append("$$ "
                         + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Price Quoted" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.PriceQuoted.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.PriceQuoted.ToString("N2") + "</span>");
                    // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Price Quoted changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newCosting.PriceQuoted.ToString("N2") + " was " + CostingObject.PriceQuoted.ToString("N2"));
                    //end on 19/8/2015
                }
            }

            //sb.Append("$$"
            //                            + "<span style='font-size:10px !important; color:#807f80;'>"
            //                            + DateTime.Now.ToString("dd MMM yy (ddd)") + " : BIPL Costing Sheet Saved by" + " "
            //                            + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " at " + DateTime.Now.ToString("hh:mm tt") + "</span>");


            //sb.Append("$$ "
            //              + "<span style='font-size:10px !important; color:#000000;'>"
            //              + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + "  BIPL Costing Sheet Saved by" + " " + "</span>"
            //              + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

            //              + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "AT" + " " + "</span>"
            //              + "<span style='font-size:10px !important; color:#000000;'>" + DateTime.Now.ToString("hh:mm tt") + "</span>");


            //added by abhishek on 19/8/2015
            sb.Append("$$ "
                     + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "BIPL Costing Sheet" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Saved by" + " " + "</span>"
                     + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + " AT " + "</span>"
                     + "<span style='font-size:10px !important; color:#000000;'>" + DateTime.Now.ToString("hh:mm tt") + "</span>");
            // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Price Quoted changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newCosting.PriceQuoted.ToString("N2") + " was " + CostingObject.PriceQuoted.ToString("N2"));
            //end on 19/8/2015




            // update by surendra for technical module
            if (newCosting.OB_WS != CostingObject.OB_WS)
            {
                //sb.Append("$$"
                //               + "<span style='font-size:10px !important; color:#807f80;'>"
                //                        + DateTime.Now.ToString("dd MMM yy (ddd)") + " : OB changed by" + " " 
                //                        + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"
                //                        + "<span style='font-size:10px !important; font-weight: bold; color:#00e ;'>" + newCosting.OB_WS.ToString("N2") + "</span>"
                //                        + "<span style='font-size:10px !important; color:#807f80;'> was " + CostingObject.OB_WS.ToString("N2") + "</span>");

                //sb.Append("$$ "
                //        + "<span style='font-size:10px !important; color:#000000;'>"
                //        + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + "</span>" + "<span style='font-size:10px !important; color:#82b2fa;'>" + "  OB changed by" + " " + "</span>"
                //        + "<span style='font-size:10px !important; color:#4422EE;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                //        + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.OB_WS.ToString("N2") + "</span>"
                //        + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.OB_WS.ToString("N2") + "</span>");


                //added by abhishek on 19/8/2015
                sb.Append("$$ "
                     + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  OB changed by" + " " + "</span>"
                     + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.OB_WS.ToString("N2") + "</span>"
                     + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.OB_WS.ToString("N2") + "</span>");
                // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Price Quoted changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newCosting.PriceQuoted.ToString("N2") + " was " + CostingObject.PriceQuoted.ToString("N2"));
                //end on 19/8/2015

            }

            // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": BIPL Costing Sheet Saved by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " at " + DateTime.Now.ToString("hh:mm tt"));

            return sb.ToString();
        }

        // updated by abhishek on 24/8/2015
        private string GetiKandiChangesHistory(Costing newCosting, int StatusModeID)
        {
            if (CostingObject == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            //if (StatusModeID > (int)TaskMode.COSTING_BIPL)
            if (true == true)
            {
                int i = 0;

                LandedCosting newLandedCosting = null;
                LandedCosting oldLandedCosting = null;
                double result = 0;
                double result2 = 0;

                for (i = 0; i < 4; i++)
                {
                    newLandedCosting = null;
                    oldLandedCosting = null;


                    if (newCosting.LandedCostingItems != null && newCosting.LandedCostingItems.Count > 0 && i < newCosting.LandedCostingItems.Count)
                    {
                        newLandedCosting = newCosting.LandedCostingItems.Find(delegate(LandedCosting LC) { return LC.SequenceNumber == (i + 1); });
                    }

                    if (CostingObject.LandedCostingItems != null && CostingObject.LandedCostingItems.Count > 0 && i < CostingObject.LandedCostingItems.Count)
                    {
                        oldLandedCosting = CostingObject.LandedCostingItems.Find(delegate(LandedCosting LC) { return LC.SequenceNumber == (i + 1); });
                    }

                    if (oldLandedCosting == null && newLandedCosting != null)
                    {
                        if (newLandedCosting.ModeCost != "" && Double.TryParse(newLandedCosting.ModeCost, out result) && result != 0)

                            //added by abhishek on 24/8/2015
                            // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Mode Cost (" + newLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + result.ToString("#.00") + " was 0");






                            sb.Append("$$ "
                             + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                             + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Mode Cost (" + newLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                             + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                             + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString("#.00") + " " + "</span>"

                         + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>");
                        //end on 24/8/2015


                        if (newLandedCosting.Handling != "" && Double.TryParse(newLandedCosting.Handling, out result) && result != 0)
                            //added by abhishek on 24/8/2015
                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Handling (" + newLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + result.ToString("#.00") + " was 0");






                            sb.Append("$$ "
                             + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                             + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Handling (" + newLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                             + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                             + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString("#.00") + " " + "</span>"

                         + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>");
                        //end on 24/8/2015



                        if (newLandedCosting.Delivery != "" && Double.TryParse(newLandedCosting.Delivery, out result) && result != 0)
                            //added by abhishek on 24/8/2015
                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Delivery (" + newLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + result.ToString("#.00") + " was 0");






                            sb.Append("$$ "
                             + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                             + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Delivery (" + newLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                             + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                             + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString("#.00") + " " + "</span>"

                         + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>");
                        //end on 24/8/2015


                        if (newLandedCosting.Processing != "" && Double.TryParse(newLandedCosting.Processing, out result) && result != 0)
                            //added by abhishek on 24/8/2015

                            // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Processing (" + newLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + result.ToString("#.00") + " was 0");


                            sb.Append("$$ "
                             + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                             + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Processing (" + newLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                             + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                             + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString("#.00") + " " + "</span>"

                         + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>");
                        //end on 24/8/2015

                        if (newLandedCosting.Margin != 0)

                            //added by abhishek on 24/8/2015
                            // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Margin (" + newLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newLandedCosting.Margin.ToString("#.00") + " was 0");


                            sb.Append("$$ "
                             + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                             + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + " Margin (" + newLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                             + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                             + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newLandedCosting.Margin.ToString("#.00") + " " + "</span>"

                         + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>");
                        //end on 24/8/2015


                        if (newLandedCosting.QuotedPrice != 0)
                            //added by abhishek on 24/8/2015
                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Price Quoted (" + newLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newLandedCosting.QuotedPrice.ToString("#.00") + " was 0");

                            sb.Append("$$ "
                        + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                        + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + " Price Quoted (" + newLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                        + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                        + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newLandedCosting.QuotedPrice.ToString("#.00") + " " + "</span>"

                    + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>");



                        //end on 24/8/2015
                    }

                    if (oldLandedCosting != null && newLandedCosting == null)
                    {
                        if (oldLandedCosting.ModeCost != "" && Double.TryParse(oldLandedCosting.ModeCost, out result))
                            //added by abhishek on 24/8/2015
                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Mode Cost (" + oldLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " 0" + " was " + result.ToString("#.00"));
                            sb.Append("$$ "
                        + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                        + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + " Mode Cost (" + oldLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                        + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                        + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + 0 + " " + "</span>"

                    + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + result.ToString("#.00") + "</span>");


                        //end on 24/8/2015


                        if (oldLandedCosting.Handling != "" && Double.TryParse(oldLandedCosting.Handling, out result) && result != 0)
                            //added by abhishek on 24/8/2015
                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Handling (" + oldLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " 0" + " was " + result.ToString("#.00"));
                            sb.Append("$$ "
                       + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                       + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + " Handling (" + oldLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                       + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                       + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + 0 + " " + "</span>"

                   + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + result.ToString("#.00") + "</span>");
                        //end on 24/8/2015

                        if (oldLandedCosting.Delivery != "" && Double.TryParse(oldLandedCosting.Delivery, out result) && result != 0)
                            //added by abhishek on 24/8/2015
                            //    sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Delivery (" + oldLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " 0" + " was " + result.ToString("#.00"));


                            sb.Append("$$ "
                      + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                      + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Delivery (" + oldLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                      + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                      + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + 0 + " " + "</span>"

                  + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + result.ToString("#.00") + "</span>");


                        //end on 24/8/2015


                        if (oldLandedCosting.Processing != "" && Double.TryParse(oldLandedCosting.Processing, out result) && result != 0)

                            //added by abhishek on 24/8/2015
                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Processing (" + oldLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " 0" + " was " + result.ToString("#.00"));


                            sb.Append("$$ "
                     + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Processing (" + oldLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                     + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + 0 + " " + "</span>"

                 + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + result.ToString("#.00") + "</span>");

                        //end on 24/8/2015


                        if (oldLandedCosting.Margin != 0)
                            //added by abhishek on 24/8/2015
                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Margin (" + oldLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " 0" + " was " + oldLandedCosting.Margin.ToString("#.00"));



                            sb.Append("$$ "
                 + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "   Margin (" + oldLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                 + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + 0 + " " + "</span>"

             + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + result.ToString("#.00") + "</span>");
                        //end on 24/8/2015

                        if (oldLandedCosting.QuotedPrice != 0)
                            //added by abhishek on 24/8/2015
                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Price Quoted (" + oldLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " 0" + " was " + oldLandedCosting.Margin.ToString("#.00"));



                            sb.Append("$$ "
                + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Price Quoted (" + oldLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + 0 + " " + "</span>"

            + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + oldLandedCosting.Margin.ToString("#.00") + "</span>");
                        //end on 24/8/2015

                    }

                    if (oldLandedCosting != null && newLandedCosting != null)
                    {

                        if (newLandedCosting.ModeCost != "" && Double.TryParse(newLandedCosting.ModeCost, out result) && oldLandedCosting.ModeCost != "" && Double.TryParse(oldLandedCosting.ModeCost, out result2) && result != result2)
                            //added by abhishek on 24/8/2015
                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Mode Cost (" + newLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + result.ToString("#.00") + " was " + result2.ToString("#.00"));
                            sb.Append("$$ "
               + "<span style='font-size:10px !important; color:#A9A9A9;'>"
               + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Mode Cost (" + newLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
               + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

               + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString("#.00") + " " + "</span>"

           + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + result2.ToString("#.00") + "</span>");

                        //end on 24/8/2015

                        if (newLandedCosting.Handling != "" && Double.TryParse(newLandedCosting.Handling, out result) && oldLandedCosting.Handling != "" && Double.TryParse(oldLandedCosting.Handling, out result2) && result != result2)
                            //added by abhishek on 24/8/2015
                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Handling (" + newLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + result.ToString("#.00") + " was " + result2.ToString("#.00"));



                            sb.Append("$$ "
              + "<span style='font-size:10px !important; color:#A9A9A9;'>"
              + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Handling (" + newLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
              + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

              + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString("#.00") + " " + "</span>"

          + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + result2.ToString("#.00") + "</span>");
                        //end on 24/8/2015

                        if (newLandedCosting.Delivery != "" && Double.TryParse(newLandedCosting.Delivery, out result) && oldLandedCosting.Delivery != "" && Double.TryParse(oldLandedCosting.Delivery, out result2) && result != result2)
                            //added by abhishek on 24/8/2015
                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Delivery (" + newLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + result.ToString("#.00") + " was " + result2.ToString("#.00"));

                            sb.Append("$$ "
             + "<span style='font-size:10px !important; color:#A9A9A9;'>"
             + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Delivery (" + newLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
             + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

             + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString("#.00") + " " + "</span>"

         + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + result2.ToString("#.00") + "</span>");


                        //end on 24/8/2015

                        if (newLandedCosting.Processing != "" && Double.TryParse(newLandedCosting.Processing, out result) && oldLandedCosting.Processing != "" && Double.TryParse(oldLandedCosting.Processing, out result2) && result != result2)
                            //added by abhishek on 24/8/2015
                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Processing (" + newLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + result.ToString("#.00") + " was " + result2.ToString("#.00"));


                            sb.Append("$$ "
             + "<span style='font-size:10px !important; color:#A9A9A9;'>"
             + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Processing (" + newLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
             + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

             + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString("#.00") + " " + "</span>"

         + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + result2.ToString("#.00") + "</span>");


                        //end on 24/8/2015

                        if (newLandedCosting.Margin != oldLandedCosting.Margin)

                            //added by abhishek on 24/8/2015
                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Margin (" + newLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newLandedCosting.Margin.ToString("#.00") + " was " + oldLandedCosting.Margin.ToString("#.00"));
                            sb.Append("$$ "
           + "<span style='font-size:10px !important; color:#A9A9A9;'>"
           + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Margin (" + newLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
           + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

           + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newLandedCosting.Margin.ToString("#.00") + " " + "</span>"

       + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + oldLandedCosting.Margin.ToString("#.00") + "</span>");



                        //end on 24/8/2015


                        if (newLandedCosting.QuotedPrice != oldLandedCosting.QuotedPrice)

                            //added by abhishek on 24/8/2015
                            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": Price Quoted (" + newLandedCosting.Mode + ") changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newLandedCosting.QuotedPrice.ToString("#.00") + " was " + oldLandedCosting.QuotedPrice.ToString("#.00"));
                            sb.Append("$$ "
          + "<span style='font-size:10px !important; color:#A9A9A9;'>"
          + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Price Quoted (" + newLandedCosting.Mode + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
          + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

          + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newLandedCosting.QuotedPrice.ToString("#.00") + " " + "</span>"

      + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + oldLandedCosting.QuotedPrice.ToString("#.00") + "</span>");
                        //end on 24/8/2015
                    }
                }

                if (CostingObject.FOBPricingItem == null && newCosting.FOBPricingItem != null)
                {
                    if (newCosting.FOBPricingItem.FOBMargin != 0)
                        //added by abhishek on 24/8/2015
                        // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": FOB Margin changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newCosting.FOBPricingItem.FOBMargin.ToString("N2") + " was 0");

                        sb.Append("$$ "
        + "<span style='font-size:10px !important; color:#A9A9A9;'>"
        + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  FOB Margin" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
        + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

        + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.FOBPricingItem.FOBMargin.ToString("N2") + " " + "</span>"

    + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + 0 + "</span>");


                    //end on 24/8/2015
                    if (newCosting.FOBPricingItem.QuotedPrice != 0)
                        //added by abhishek on 24/8/2015

                        //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": FOB Price Quoated changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newCosting.FOBPricingItem.QuotedPrice.ToString("N2") + " was 0");

                        sb.Append("$$ "
       + "<span style='font-size:10px !important; color:#A9A9A9;'>"
       + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  FOB Price Quoated" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
       + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

       + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.FOBPricingItem.QuotedPrice.ToString("N2") + " " + "</span>"

   + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + 0 + "</span>");


                    //end on 24/8/2015
                }

                if (CostingObject.FOBPricingItem != null && newCosting.FOBPricingItem == null)
                {
                    if (CostingObject.FOBPricingItem.FOBMargin != 0)

                        //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": FOB Margin changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " 0 " + " was " + CostingObject.FOBPricingItem.FOBMargin.ToString("N2"));

                        sb.Append("$$ "
      + "<span style='font-size:10px !important; color:#A9A9A9;'>"
      + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  FOB Margin" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
      + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

      + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + 0 + " " + "</span>"

  + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + CostingObject.FOBPricingItem.FOBMargin.ToString("N2") + "</span>");


                    if (CostingObject.FOBPricingItem.QuotedPrice != 0)


                        // sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": FOB Price Quoated changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " 0 " + " was " + CostingObject.FOBPricingItem.QuotedPrice.ToString("N2"));
                        sb.Append("$$ "
     + "<span style='font-size:10px !important; color:#A9A9A9;'>"
     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  FOB Price Quoated" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
     + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + 0 + " " + "</span>"

 + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + CostingObject.FOBPricingItem.QuotedPrice.ToString("N2") + "</span>");


                }

                if (CostingObject.FOBPricingItem != null && newCosting.FOBPricingItem != null)
                {
                    if (newCosting.FOBPricingItem.FOBMargin != CostingObject.FOBPricingItem.FOBMargin)
                        //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": FOB Margin changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newCosting.FOBPricingItem.FOBMargin.ToString("N2") + " was " + CostingObject.FOBPricingItem.FOBMargin.ToString("N2"));
                        sb.Append("$$ "
    + "<span style='font-size:10px !important; color:#A9A9A9;'>"
    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  FOB Margin " + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
    + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

    + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.FOBPricingItem.FOBMargin.ToString("N2") + " " + "</span>"

+ "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + CostingObject.FOBPricingItem.FOBMargin.ToString("N2") + "</span>");



                    if (newCosting.FOBPricingItem.QuotedPrice != CostingObject.FOBPricingItem.QuotedPrice)

                        //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": FOB Price Quoated changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + newCosting.FOBPricingItem.QuotedPrice.ToString("N2") + " was " + CostingObject.FOBPricingItem.QuotedPrice.ToString("N2"));

                        sb.Append("$$ "
    + "<span style='font-size:10px !important; color:#A9A9A9;'>"
    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  FOB Price Quoated" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
    + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"

    + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.FOBPricingItem.QuotedPrice.ToString("N2") + " " + "</span>"

+ "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + CostingObject.FOBPricingItem.QuotedPrice.ToString("N2") + "</span>");


                }
            }
            //sb.Append("$$" + DateTime.Now.ToString("dd MMM yy (ddd)") + ": iKandi Costing Sheet Saved by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " at " + DateTime.Now.ToString("hh:mm tt"));
            sb.Append("$$ "
    + "<span style='font-size:10px !important; color:#A9A9A9;'>"
    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  iKandi Costing Sheet" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Saved by" + " " + "</span>"
    + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + "</span>"



+ "<span style='font-size:10px !important;color:#A9A9A9;'>" + "at " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + DateTime.Now.ToString("hh:mm tt") + "</span>");


            return sb.ToString();
        }
        // End by abhishek on 24/8/2015

        private void GetDepartmentDropdownInformationAtPrint(string BuyerSelectedValue)
        {
            List<ClientDepartment> objClientDepartment = this.ClientControllerInstance.GetClientDeptsByClientID_ForDesignForm(Convert.ToInt32(BuyerSelectedValue), -1, Convert.ToInt32(ddlParentDept.SelectedValue), "SubParent");

            foreach (ClientDepartment cdept in objClientDepartment)
            {
                ddlDept.Items.Add(new ListItem(cdept.Name, cdept.DeptID.ToString()));

            }

            ddlDept.SelectedValue = hdnDeptId.Value;
        }
        private void GetParentDepartmentDropdownInformationAtPrint(string BuyerSelectedValue)
        {
            List<ClientDepartment> objClientDepartment = this.ClientControllerInstance.GetClientDeptsByClientID_ForDesignForm(Convert.ToInt32(BuyerSelectedValue), -1, -1, "Parent");

            foreach (ClientDepartment cdept in objClientDepartment)
            {
                ddlParentDept.Items.Add(new ListItem(cdept.Name, cdept.DeptID.ToString()));

            }

            ddlParentDept.SelectedValue = hdnParentDeptId.Value;
        }
        private void GetMakingDropdownInformation()
        {
            DataTable dt = this.CostingControllerInstance.GetGarmentTypeOption(lblGarmetType.Text);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ddlMaking.Items.Add(new ListItem(dr["Option"].ToString(), dr["id"].ToString()));
                }
                ddlMaking.DataBind();
                ddlMaking.SelectedValue = hdnMaking.Value;
            }
        }

        protected void IkandiCostConfirmation_Click()
        {
            string script = string.Empty;

            try
            {
                UserTask task = new UserTask();
                task.AssignedToDesigntation = (int)Designation.BIPL_Sales_Manager;
                task.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                task.CreatedOn = DateTime.Now;
                task.ETA = DateTime.Now.AddDays(3);
                task.Style = new iKandi.Common.Style();
                task.Style.StyleID = this.StyleID;
                task.TextField2 = txtPriceQuoted.Text.ToString();
                task.Type = UserTaskType.PriceUpdate;
                if (rdAccept.Checked)
                    task.IntField3 = 1;
                else
                    task.IntField3 = 0;

                this.UserTaskControllerInstance.InsertUserTask(task);

                // string url = COSTING_SHEET_URL + "?cid=" + CostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();

                //script = "ShowHideMessageBox(true, 'Costing Confirmation Request sent successfully.', 'Request Costing Confirmation', RedirectToUrl, '" + url + "');";


                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);                
                lblMsg.Text = "Costing Confirmation Request sent successfully.";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                // this.NotificationControllerInstance.SendErrorEmail(ex.Message + " " + ex.StackTrace);
            }
        }
        //abhishek 18 sep 
        //private void GetExpectedWastageQty(string SelectedValue)
        //{
        //    if (ddlDept.SelectedValue != "-1" && ddlDept.SelectedValue != "" && ddlDept.SelectedValue != "0")
        //    {
        //        List<Costing> objGetExpWastageQty = this.CostingControllerInstance.GetExpWastageQty(Convert.ToInt32(ddlBuyer.SelectedValue), Convert.ToInt32(ddlDept.SelectedValue));
        //        int QtyID = 0;
        //        foreach (Costing WastageQty in objGetExpWastageQty)
        //        {
        //            ddlExpectedQty.Items.Add(new ListItem(WastageQty.WastageQty, WastageQty.ExpectedID.ToString()));
        //            QtyID = WastageQty.WastageID;
        //        }
        //        ddlExpectedQty.SelectedValue = QtyID.ToString();
        //    }


        //}
        #endregion
    }
}