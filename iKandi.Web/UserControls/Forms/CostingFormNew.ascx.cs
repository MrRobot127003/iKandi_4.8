using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Collections.Generic;
using iKandi.Web.Components;
using iKandi.Common;
using System.Text;
using System.Linq;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;
using System.Drawing;
namespace iKandi.Web.UserControls.Forms
{
    public partial class CostingFormNew : BaseUserControl
    {
        #region Fields

        UserTask _CostingConfirmationTask = null;
        UserTask _CostingPriceUpdate = null;
        UserTask _CostingConfirmedTask = null;
        public int FLAG = 0;

        #endregion

        #region Constants

        const string COSTING_SHEET_URL = "/Internal/Sales/TabCostingSheetNew.aspx";

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
                            //btnSave.Visible = true;
                            //btnSaveIkandi.Visible = true;
                            //btniKandiUpdatePrice.Visible = true;
                            //btnCostConfirmation.Visible = true;
                            //btnUpdatePrice.Visible = true;
                            //btnCostConfirmed.Visible = (CostingConfirmationTask.ID > 0);
                            ViewState["cid"] = cid;
                            return cid;
                        }
                    }
                }

                if (Role == 1)
                {
                    //btnSave.Visible = false;
                    //btnCostConfirmation.Visible = false;
                    //btnUpdatePrice.Visible = false;
                    //btnBIPLPrint.Visible = false;

                    //btniKandiUpdatePrice.Visible = false;
                    //btnSaveIkandi.Visible = false;
                    //btnCostConfirmed.Visible = false;
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
                if (this.CostingObject != null && this.CostingObject.ClientID > 0)
                    return this.CostingObject.ClientID;

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
            get;
            set;
            //get
            //{
            //    if (Role == 0 && null != ViewState["isBIPLUserAccessingIKandiData"])
            //        return (bool)ViewState["isBIPLUserAccessingIKandiData"];

            //    return false;
            //}
            //set
            //{
            //    ViewState["isBIPLUserAccessingIKandiData"] = value;
            //}
        }

        private bool IsCostingOpen
        {
            get
            {
                if (Role == 0 && null != ViewState["IsCostingOpen"])
                    return (bool)ViewState["IsCostingOpen"];

                return false;
            }
            set
            {
                ViewState["IsCostingOpen"] = value;
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
        public int AccessoryCount = 0;

        #endregion

        bool IsOldHistory = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ApplicationHelper.LoggedInUser == null)
                Response.Redirect("~/internal/Logout.aspx");

            Session["StyleId"] = Convert.ToString(this.StyleID);
            int inrStyleId = Convert.ToInt32(Session["StyleId"]);
            hdnuserid.Value = Convert.ToString(ApplicationHelper.LoggedInUser.UserData.UserID);
            hdnCosting.Value = Convert.ToString(CostingId); //added on 09-12-2020
            string Pricequoted = string.Empty;
            double LP = this.CostingControllerInstanceNew.Get_LP_New(this.StyleID);
            if (LP != 0)
            {
                txtLastPrice.Text = LP.ToString();
                trLP.Visible = false;
            }
            else
            {
                txtLastPrice.Text = "";
                trLP.Visible = false;
            }
            if (!IsPostBack)
            {
                ViewState["dtDeleteAccess"] = null;
                CostingObject = null;
                DataTable dt = this.CostingControllerInstanceNew.GetCurrencyBAL_New();

                for (int x = 0; x <= dt.Rows.Count - 1; x++)
                {
                    if (Convert.ToInt32(dt.Rows[x]["Id"]) == 4)
                        ddlConvTo.Items.Add(new ListItem("€", Convert.ToString(dt.Rows[x]["Id"])));
                    else
                        ddlConvTo.Items.Add(new ListItem(Convert.ToString(dt.Rows[x]["CurrencySymbol"]), Convert.ToString(dt.Rows[x]["Id"])));
                }

                SetupControls();

                if ((CostingId <= 0 && ParentCostingId <= 0) || (CostingId >= 0 && ParentCostingId <= 0) ||
                    CostingId <= 0 || (CostingId <= 0 && ParentCostingId > 0))
                    BindFormWithDefaultData();

                if (CostingId > 0)
                {
                    CostingCollection objCostingCollection = this.CostingControllerInstanceNew.GetCosting_New(CostingId);
                    IsOldHistory = CostingControllerInstanceNew.IsCostingOldHistoryValid(CostingId);
                    if (IsOldHistory)
                    {
                        lnkHistory.Visible = true;
                        lnkComment.Visible = true;
                    }

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

                    IsCostingOpen = CostingObject.IsCostingOpen == 1 ? true : false;

                    Pricequoted = Convert.ToString(objCostingCollection[0].PriceQuoted);
                    //hdnPriceQuoted.Value = objCostingCollection[0].PriceQuoted.ToString();

                    hypviewObfile.NavigateUrl = "~/Uploads/Photo/" + CostingObject.FileName;
                    hypviewObfile.Visible = CostingObject.FileName == "" ? false : true;

                    BindFormWithCostingData(CostingObject);


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
                        DataTable dt_Yellow_Remarks_Fabric = this.CostingControllerInstanceNew.GetYello_Remarks(ParentStyleId, ChildCostingId, "Fabric");
                        if (dt_Yellow_Remarks_Fabric.Rows.Count > 0)
                        {
                            string desc = "";
                            for (int i = 0; i < dt_Yellow_Remarks_Fabric.Rows.Count; i++)
                            {
                                if (desc == "")
                                {
                                    desc = desc + dt_Yellow_Remarks_Fabric.Rows[i]["FabDescription"].ToString();
                                }
                                else
                                {
                                    desc = desc + "<br>" + dt_Yellow_Remarks_Fabric.Rows[i]["FabDescription"].ToString();
                                }
                            }
                            lblFabricTooltip.Text = lblFabricTooltip.Text + "<span class='DeleteFabricName'>" + "" + desc + "";
                            lblFabricTooltip.CssClass = "Change_DeleteFabricName DeleteFabrictooltip";
                        }

                        DataTable dt_Yellow_Remarks_Acc = this.CostingControllerInstanceNew.GetYello_Remarks(ParentStyleId, ChildCostingId, "Acc");

                        if (dt_Yellow_Remarks_Acc.Rows.Count > 0)
                        {
                            string desc = "";
                            for (int i = 0; i < dt_Yellow_Remarks_Acc.Rows.Count; i++)
                            {
                                if (desc == "")
                                {
                                    desc = desc + dt_Yellow_Remarks_Acc.Rows[i]["AccDescription"].ToString();
                                }
                                else
                                {
                                    desc = desc + "<br>" + dt_Yellow_Remarks_Acc.Rows[i]["AccDescription"].ToString();
                                }
                            }
                            lblAccessoryTooltip.Text = lblAccessoryTooltip.Text + "<span class='DeleteAccessoryName'>" + "" + desc + "";
                            lblAccessoryTooltip.CssClass = "Change_DeleteAccessoryName DeleteAccessorytooltip";
                        }

                        DataTable dt_Yellow_Remarks_Process = this.CostingControllerInstanceNew.GetYello_Remarks(ParentStyleId, ChildCostingId, "Process");
                        if (dt_Yellow_Remarks_Process.Rows.Count > 0)
                        {
                            string desc = "";
                            for (int i = 0; i < dt_Yellow_Remarks_Process.Rows.Count; i++)
                            {
                                if (desc == "")
                                {
                                    desc = desc + dt_Yellow_Remarks_Process.Rows[i]["ProDescription"].ToString();
                                }
                                else
                                {
                                    desc = desc + "<br>" + dt_Yellow_Remarks_Process.Rows[i]["ProDescription"].ToString();
                                }
                            }
                            lblProcessTooltip.Text = lblProcessTooltip.Text + "<span class='DeleteAccessoryName'>" + "" + desc + "";
                            lblProcessTooltip.CssClass = "Change_DeleteAccessoryName DeleteAccessorytooltip";
                        }

                    }
                    else
                    {
                        IsBIPLUserAccessingIKandiData = false;
                    }
                    SetCurrencyConRate();
                    hdnIsPricequoted.Value = Pricequoted;
                    if (Pricequoted == "" || Pricequoted == "0")
                    {
                        BindFormWithDefaultDataWithout_PriceQuote();
                    }

                }
                else
                {
                    //ddlBuyer.SelectedValue = this.ClientID.ToString();
                    CostingObject = null;
                    txtStyleId.Text = inrStyleId.ToString();

                    //ddlChargeValue.Items.Remove(ddlChargeValue.Items.FindByValue("-1"));
                }



                if (ApplicationHelper.IsPrintRequest)
                {
                    //GetDepartmentDropdownInformationAtPrint(ddlBuyer.SelectedValue);
                }
                GetMsg();
                SetControlsVisibility(CostingObject);
            }


        }


        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        public void SetMsg(string MsgType, string Msg)
        {
            HttpCookie CostingMsg = new HttpCookie("CostingMsg");
            CostingMsg["MsgType"] = MsgType;
            CostingMsg["Msg"] = Msg;
            CostingMsg.Expires.Add(new TimeSpan(0, 0, 0, 30));
            Response.Cookies.Add(CostingMsg);
        }
        public void GetMsg()
        {
            HttpCookie reqCookies = Request.Cookies["CostingMsg"];
            if (reqCookies != null)
            {
                if (reqCookies["Msg"] != null && reqCookies["Msg"].ToString() != "")
                {
                    LblCostingMsg.Visible = true;
                    string Msg = reqCookies["Msg"].ToString();
                    LblCostingMsg.Text = Msg;
                    string MsgType = reqCookies["MsgType"].ToString();
                    if (MsgType.ToLower() == "success") { LblCostingMsg.ForeColor = System.Drawing.ColorTranslator.FromHtml("#69d72c"); }
                    else if (MsgType.ToLower() == "error") { LblCostingMsg.ForeColor = System.Drawing.Color.Red; }
                    else if (MsgType.ToLower() == "warning") { LblCostingMsg.ForeColor = System.Drawing.Color.Yellow; }
                    else if (MsgType.ToLower() == "info") { LblCostingMsg.ForeColor = System.Drawing.Color.BlueViolet; }
                }
                else { LblCostingMsg.Visible = false; }
            }
            else { LblCostingMsg.Visible = false; }

            HttpCookie CostingMsg = new HttpCookie("CostingMsg");
            CostingMsg["MsgType"] = "";
            CostingMsg["Msg"] = "";
            CostingMsg.Expires.Add(new TimeSpan(0, 0, 0, 30));
            Response.Cookies.Add(CostingMsg);
        }

        public void ShowMsg(string MsgType, string Msg)
        {
            LblCostingMsg.Visible = true;
            LblCostingMsg.Text = Msg;
            if (MsgType.ToLower() == "success") { LblCostingMsg.ForeColor = System.Drawing.Color.LightSeaGreen; }
            else if (MsgType.ToLower() == "error") { LblCostingMsg.ForeColor = System.Drawing.Color.Red; }
            else if (MsgType.ToLower() == "warning") { LblCostingMsg.ForeColor = System.Drawing.Color.Yellow; }
            else if (MsgType.ToLower() == "info") { LblCostingMsg.ForeColor = System.Drawing.Color.BlueViolet; }
        }
        //added by abhishek======12/5/2017
        public void SetCurrencyConRate()
        {

            DataTable dts = CostingControllerInstanceNew.GetCostingVariance_new(Convert.ToInt32(ddlConvTo.SelectedValue));
            if (dts.Rows.Count > 0)
            {
                hdnfromvari.Value = dts.Rows[0]["FromVarraice"].ToString();
                hdntovari.Value = dts.Rows[0]["ToVarraice"].ToString();

                //string gp_from = "USD";
                //string gp_to = "INR";
                //double gp_amount = 1.0;

                //if (ddlConvTo.SelectedValue == "1") gp_from = "USD";
                //else if (ddlConvTo.SelectedValue == "2") gp_from = "GBP";
                //else if (ddlConvTo.SelectedValue == "3") gp_from = "INR";
                //else if (ddlConvTo.SelectedValue == "4") gp_from = "EUR"; else if (ddlConvTo.SelectedValue == "5") gp_from = "SEK"; else if (ddlConvTo.SelectedValue == "6") gp_from = "AUD";

                //WebClient web = new WebClient();
                ////string url = string.Format("https://www.google.com/finance/converter?from={0}&to={1}&a={2}", gp_from, gp_to, 1);
                //string url = string.Format("http://free.currencyconverterapi.com/api/v5/convert?q=USD_INR&compact=y");

                //string response = web.DownloadString(url);
                //Regex regex = new Regex("<span class=bld>(.*?)</span>");

                var result = "67.6";
                try
                {
                    string[] res = result.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    double Rate = Convert.ToDouble(67.66);


                    double r = Rate;
                    decimal d = (decimal)r;
                    decimal truncated = decimal.Truncate(d * 100m) / 100m;

                    result = truncated.ToString();


                    if (Rate.ToString() != "0" || Rate.ToString() != "0.0" || Rate.ToString() != "")
                    {
                        hdnConvRate.Value = result.ToString();
                        hdnConvernew.Value = result.ToString();
                    }
                    else
                    {
                        hdnConvRate.Value = "1.0";
                        hdnConvernew.Value = "1.0";
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }


            }
            //string htmltooltip="<p>Default Guideline:</p><p>Factor1:<br />Check Latest PO Type <br /> if Finish <br /> (Max rate of latest 3 PO of finish type <br /> + apply Max wastage of latest 3 PO applicable <br /> + Barrier % as applicable)<br /> Else<br /> ((Max Latest 3 greige PO Rate + Max latest 3 Process Po rate) <br /> + apply Max Shrinkage and wastage of latest 3 PO applicable <br /> + Barrier % as Applicable)</p><p>Factor2:<br /> Latest Costing Rate for the quality</p><p>We will show the Max of Factor1 vsFactor2 in Rate Accordingly</p></body></html>";
            //imgtooltip.Attributes.Add("title", htmltooltip);


        }
        //public decimal TruncateDecimal(decimal value, int precision)
        //{
        //    decimal step = (decimal)Math.Pow(10, precision);
        //    decimal tmp = Math.Truncate(step * value);
        //    return tmp / step;
        //}
        //end================
        private void SetupControls()
        {
            //DropdownHelper.BindZipDetails(ddlAccessoriesItem4);
            //DropdownHelper.BindZipSize(ddlAccessoriesRate4);

            DropdownHelper.BindAllClients(ddlBuyer);
            ddlBuyer.Items.Insert(0, new ListItem("Select --", "0"));




            ClientController controller = new ClientController(ApplicationHelper.LoggedInUser);
            List<Client> clients = controller.GetAllClients();

            foreach (Client client in clients)
            {
                if (!client.IsActive)
                {
                    foreach (ListItem item in ddlBuyer.Items)
                    {
                        if (client.ClientID == Convert.ToInt32(item.Value))
                        {
                            item.Attributes.Add("class", "inactive");
                        }
                    }
                }
            }





            ddlPrintType1.SelectedIndex =
            ddlPrintType2.SelectedIndex =
            ddlPrintType3.SelectedIndex =
            ddlPrintType4.SelectedIndex =
            ddlPrintType5.SelectedIndex =
            ddlPrintType6.SelectedIndex =
            ddlPrintType7.SelectedIndex =
            ddlPrintType8.SelectedIndex = 1;

            txtPriceQuoted.DataBind();

            Common.Style styleForGarmetCode = this.StyleControllerInstance.GetStyleByStyleId_New(this.StyleID);
            if (styleForGarmetCode != null && !string.IsNullOrEmpty(styleForGarmetCode.StyleNumber) &&
                styleForGarmetCode.StyleNumber.Length > 2)
            {
                string code = styleForGarmetCode.StyleNumber.Substring(0, 2).ToUpper();
                lblGarmetType.Text = this.CostingControllerInstanceNew.GetGarmentNameOption_New(code);
            }
            hdnBuyingHouse.Text = styleForGarmetCode.IsIkandiClient.ToString();

            if (Role == 0 && styleForGarmetCode != null && !string.IsNullOrEmpty(styleForGarmetCode.StyleNumber) &&
                styleForGarmetCode.StyleNumber.IndexOf("$") > -1)
            {
                //hypOrdersByVariations.Visible = true;
                //hypOrdersByVariations.NavigateUrl = "javascript:void(0)";
                //hypOrdersByVariations.Attributes.Remove("onclick");
                //hypOrdersByVariations.Attributes.Add("onclick",
                //                                     "LaunchExistingOrdersByStyleVariation(" + this.CostingId.ToString() +
                //                                     ",'" + styleForGarmetCode.StyleNumber + "');return false;");
            }
            else
            {
                // hypOrdersByVariations.Visible = false;
            }
            hlinkSAM.Visible = true;
            hlinkSAM.NavigateUrl = "~/Internal/OrderProcessing/OrderProcessFlow.aspx?styleid=" + StyleID + "&stylenumber=" + styleForGarmetCode.StyleNumber + "&FitsStyle=&StyleCode=" + styleForGarmetCode.StyleNumber + "&ClientID=" + ClientID + "&DeptId=" + DepartmentID + "&showOBFORM=Yes";
            //GetMakingDropdownInformation();
            //ddlMaking.Items.Insert(0, "Select");

            if (Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID) == 5 || Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID) == 6 || Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID) == 8 || Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID) == 15 || Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID) == 145)
            {
                //tdDC.Style.Add("display", "");
                //tdDCValue.Style.Add("display", "");
            }
            string stylecode = string.Empty;
            stylecode = this.StyleControllerInstance.GetStyleByCode(this.StyleID);
            hdStyleCOdeValue.Value = stylecode;
            //hdStyleCOdeValue.Value = stylecode;
            //---------------------------------------------------------------
        }

        #region  below is comented by sanjeev on 23/02/2022 to organize the control visiblity
        //private void SetControlsVisibility(Costing objCosting)
        //{
        //    int IsIkandiClient = objCosting.IsIkandiClient;
        //    bool bCheckVisibilty = false;
        //    bool BcheckCMT_ReadOnly = false;
        //    string pairedCosting = string.Empty;
        //    bCheckVisibilty = this.CostingControllerInstanceNew.bCheck_Update_Price_Visibilty_New(CostingId);
        //    BcheckCMT_ReadOnly = this.CostingControllerInstanceNew.bCheck_CMT_ReadOnly(ClientID, DepartmentID, Convert.ToInt32(hdnParentDeptId.Value));
        //    if (BcheckCMT_ReadOnly == true)
        //        txtChargesValue1.Attributes.Add("readonly", "readonly");
        //    if (CostingId != -1)
        //    {
        //        bCheckVisibilty = this.CostingControllerInstance.bCheck_Update_Price_Visibilty(CostingId);
        //        pairedCosting = this.CostingControllerInstance.GetPairedCosting(CostingId);
        //        if (pairedCosting == "")
        //            lblPairedCosting.Text = "No Costing Paired";
        //        else
        //            lblPairedCosting.Text = "Paired Costing :<span style='color:black;'>" + pairedCosting + "</span>";
        //    }
        //    else
        //    {
        //        lblPairedCosting.Visible = false;
        //    }
        //    if (Role == 1 && IsIkandiClient == 1)
        //    {
        //        divIKandi.Visible = true;
        //        btnCostConfirmed.Visible = (CostingConfirmationTask.ID > 0) && PermissionHelper.IsWritePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_COST);
        //        btnSave.Visible = false;
        //        btnSaveConfirm.Visible = false;
        //        btnUpdatePrice.Visible = false;
        //        btnCostConfirmation.Visible = false;
        //        btnBIPLHistory.Visible = true;
        //        btniKandiHistory.Visible = true;
        //        //btnBIPLPrint.Visible = false;

        //        btnOpenCosting.Visible = false;
        //        btnAcceptClose.Visible = false;
        //    }
        //    else
        //    {
        //        divIKandi.Visible = false;
        //        btnUpdatePrice.Visible = (CostingId > 0) && PermissionHelper.IsWritePermittedOnColumn((int)AppModuleColumn.COSTING_UPDATE_PRICE_BIPL);
        //        btnSave.Visible = PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_SUBMIT);
        //        btnCostConfirmation.Visible = false;//(CostingId > 0) && (CostingConfirmationTask.ID == 0);
        //        btnCostConfirmation.Visible = false;//(CostingId > 0) && PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_REQUEST_COST_CONFIRMATION);
        //        if (objCosting.PriceQuoted > 0)
        //        {
        //            if (IsIkandiClient == 1)
        //            {
        //                btnSaveConfirm.Visible = false;//true;
        //                btnSave.Visible = false;

        //                if (IsCostingOpen)
        //                {
        //                    btnOpenCosting.Visible = false;
        //                    btnAcceptClose.Visible = false;
        //                    btnAcceptClose.Text = "Accept and Close Agreement";
        //                    if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 14 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 104 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 13)
        //                    {
        //                        btnAcceptClose.Visible = true;
        //                    }

        //                }
        //                else
        //                {
        //                    btnOpenCosting.Visible = false;
        //                    btnAcceptClose.Visible = false;
        //                    btnAcceptClose.Text = "Save";
        //                    if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 14 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 104 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 13)
        //                    {
        //                        btnOpenCosting.Visible = true;
        //                        btnAcceptClose.Visible = true;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                btnSaveConfirm.Visible = false;
        //                btnOpenCosting.Visible = false;
        //                btnAcceptClose.Visible = false;
        //            }
        //        }
        //        else
        //        {
        //            if (IsIkandiClient == 1 && (ApplicationHelper.LoggedInUser.UserData.DesignationID == 14 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 104 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 13))
        //            {
        //                btnSaveConfirm.Visible = false;//true;
        //                btnSave.Visible = false;
        //                if (IsCostingOpen)
        //                {
        //                    btnOpenCosting.Visible = false;
        //                    btnAcceptClose.Visible = true;
        //                    btnAcceptClose.Text = "Accept and Close Agreement";
        //                }
        //                else
        //                {
        //                    btnOpenCosting.Visible = true;
        //                    btnAcceptClose.Visible = true;
        //                    btnAcceptClose.Text = "Save";
        //                }
        //            }
        //            else
        //            {
        //                btnSaveConfirm.Visible = false;
        //                btnOpenCosting.Visible = false;
        //                btnAcceptClose.Visible = false;
        //                btnSave.Visible = PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_SUBMIT);
        //            }
        //        }
        //        lblCostConfirmationRequestText.Visible = (CostingConfirmationTask.ID > 0 || CostingConfirmedTask.ID > 0);

        //        if (CostingConfirmationTask.ID > 0)
        //            lblCostConfirmationRequestText.Text = string.Format("Cost confirmation requested by {0} for {1} {2} on {3}", CostingConfirmationTask.CreatedByUsername, ddlConvTo.SelectedItem.Text, CostingConfirmationTask.TextField2, CostingConfirmationTask.CreatedOn.ToString("dd MMM yy (ddd)"));
        //        else if (CostingConfirmedTask.ID > 0)
        //        {
        //            if (CostingConfirmedTask.IntField3 == 1)
        //                lblCostConfirmationRequestText.Text = string.Format("Cost confirmed by {0} for {1} {2} on {3}", CostingConfirmedTask.ActionedByUsername, ddlConvTo.SelectedItem.Text, CostingConfirmedTask.TextField2, CostingConfirmedTask.ActionDate.ToString("dd MMM yy (ddd)"));
        //            else
        //                lblCostConfirmationRequestText.Text = string.Format("Cost Decline by {0} for {1} {2} on {3}", CostingConfirmedTask.ActionedByUsername, ddlConvTo.SelectedItem.Text, CostingConfirmedTask.TextField2, CostingConfirmedTask.ActionDate.ToString("dd MMM yy (ddd)"));
        //        }

        //        btnBIPLHistory.Visible = true;
        //        btniKandiHistory.Visible = false;
        //        //btnBIPLPrint.Visible = true;
        //    }

        //    if (IsBIPLUserAccessingIKandiData)
        //    {
        //        //radioBtnAgree.Visible = true;
        //        if (ApplicationHelper.LoggedInUser.UserData.DesignationID.ToString() == "13" || ApplicationHelper.LoggedInUser.UserData.DesignationID.ToString() == "104")
        //        {
        //            btnAgree.Visible = true;
        //        }
        //        else
        //        {
        //            btnAgree.Visible = false;
        //        }
        //        btnDisagree.Visible = false;

        //        btnSaveConfirm.Visible = false;
        //        btnSave.Visible = false;
        //        btnUpdatePrice.Visible = false;
        //        btnCostConfirmation.Visible = false;

        //        btnOpenCosting.Visible = false;
        //        btnAcceptClose.Visible = false;
        //    }
        //    else
        //    {
        //        //radioBtnAgree.Visible = false;
        //        btnAgree.Visible = false;
        //        btnDisagree.Visible = false;
        //    }

        //    PendingCostingMsg.Visible = false;

        //    if (Role == 1)
        //    {
        //        if (Convert.ToString(CostingObject.PriceQuoted) == "0" && CostingObject.ParentCostingID == -1 && CostingObject.IsVersion == false)
        //        {
        //            divIKandi.Visible = false;
        //            BIPLCosting.Visible = false;
        //            PendingCostingMsg.Visible = true;
        //        }
        //        else if (Convert.ToString(CostingObject.PriceQuoted) == "0" && CostingObject.ParentCostingID != -1 && CostingObject.IsVersion == false)
        //        {
        //            divIKandi.Visible = false;
        //            BIPLCosting.Visible = false;
        //            PendingCostingMsg.Visible = true;
        //        }
        //    }
        //    else
        //    {
        //        int checkshowhide = CostingControllerInstanceNew.Check_UpdateBiplPrice_ShowHide_New(CostingObject.CostingID);
        //        if (checkshowhide == 0)
        //        {
        //            btnUpdatePrice.Visible = false;
        //        }
        //    }

        //    if (IsIkandiClient != 1)
        //    {
        //        btnCostConfirmation.Visible = false;
        //    }
        //}
        #endregion
        private void SetControlsVisibility(Costing objCosting)
        {
            int[] AgrimentLevelDesig = { 13, 14, 104, 21, 83 };
            int[] NonAgrimentLevelDesig = { 32 };

            // by default all false
            btnBIPLHistory.Visible = false;
            btniKandiHistory.Visible = false;
            btnCostConfirmation.Visible = false;
            btnSaveConfirm.Visible = false;
            btnSave.Visible = false;
            btnOpenCosting.Visible = false;
            btnAcceptClose.Visible = false;
            btnUpdatePrice.Visible = false;
            btniKandiUpdatePrice.Visible = false;
            btnAgree.Visible = false;
            btnDisagree.Visible = false;
            lblPairedCosting.Visible = false;
            divIKandi.Visible = false;
            BIPLCosting.Visible = true;
            PendingCostingMsg.Visible = false;

            int IsIkandiClient = objCosting.IsIkandiClient;
            bool bCheckVisibilty = false;
            bool BcheckCMT_ReadOnly = false;
            string pairedCosting = string.Empty;
            bCheckVisibilty = this.CostingControllerInstanceNew.bCheck_Update_Price_Visibilty_New(CostingId);
            BcheckCMT_ReadOnly = this.CostingControllerInstanceNew.bCheck_CMT_ReadOnly(ClientID, DepartmentID, Convert.ToInt32(hdnParentDeptId.Value));


            if (BcheckCMT_ReadOnly == true)
                txtChargesValue1.Attributes.Add("readonly", "readonly");
            if (CostingId != -1)
            {
                bCheckVisibilty = this.CostingControllerInstanceNew.bCheck_Update_Price_Visibilty_New(CostingId);
                pairedCosting = this.CostingControllerInstance.GetPairedCosting(CostingId);
                if (pairedCosting == "")
                    lblPairedCosting.Text = "No Costing Paired";
                else
                    lblPairedCosting.Text = "Paired Costing :<span style='color:black;'>" + pairedCosting + "</span>";
                lblPairedCosting.Visible = true;
            }

            if (Role == 1 && IsIkandiClient == 1)
            {
                divIKandi.Visible = true;
                btnCostConfirmed.Visible = (CostingConfirmationTask.ID > 0) && PermissionHelper.IsWritePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_COST);
                btnBIPLHistory.Visible = true;
                btniKandiHistory.Visible = true;
                //if (Convert.ToBoolean(CostingControllerInstanceNew.Check_UpdateBiplPrice_ShowHide_New(CostingObject.CostingID))
                //   && PermissionHelper.IsWritePermittedOnColumn((int)AppModuleColumn.COSTING_UPDATE_PRICE_IKANDI)
                //   && CostingId > 0)
                //{
                //    btniKandiUpdatePrice.Visible = true;
                //}
            }
            else
            {
                btnBIPLHistory.Visible = true;
                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 13
                    && Convert.ToBoolean(CostingControllerInstanceNew.Check_UpdateBiplPrice_ShowHide_New(CostingObject.CostingID))
                    && PermissionHelper.IsWritePermittedOnColumn((int)AppModuleColumn.COSTING_UPDATE_PRICE_BIPL)
                    && CostingId > 0)
                {
                    btnUpdatePrice.Visible = true;
                }

                if (IsBIPLUserAccessingIKandiData)
                {
                    if (AgrimentLevelDesig.Contains(ApplicationHelper.LoggedInUser.UserData.DesignationID))
                    {
                        btnAgree.Visible = PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_SUBMIT);
                    }
                }

                if (objCosting.PriceQuoted > 0)
                {
                    if (IsIkandiClient == 1)
                    {
                        if (IsCostingOpen)
                        {
                            btnAcceptClose.Text = "Accept and Close Agreement";
                            if (AgrimentLevelDesig.Contains(ApplicationHelper.LoggedInUser.UserData.DesignationID))// for PD Manager,Head of PD and Marketing and BIPL Director only
                            {
                                if (!IsBIPLUserAccessingIKandiData)
                                {
                                    btnAcceptClose.Visible = PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_SUBMIT);
                                }
                            }
                            else if (NonAgrimentLevelDesig.Contains(ApplicationHelper.LoggedInUser.UserData.DesignationID)) // for PD Merchandiser and Account Manager only 
                            {
                                if (!IsBIPLUserAccessingIKandiData)
                                {
                                    btnSave.Visible = PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_SUBMIT);
                                }
                                else
                                {
                                    ShowMsg("info", "Costing is in Agreement!!");
                                }
                            }
                        }
                        else
                        {
                            btnAcceptClose.Text = "Save";
                            if (AgrimentLevelDesig.Contains(ApplicationHelper.LoggedInUser.UserData.DesignationID)) // for PD Manager,Head of PD and Marketing and BIPL Director only
                            {
                                if (IsBIPLUserAccessingIKandiData == false)
                                {
                                    btnOpenCosting.Visible = PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_SUBMIT);
                                    btnAcceptClose.Visible = PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_SUBMIT);
                                }
                            }
                            else if (NonAgrimentLevelDesig.Contains(ApplicationHelper.LoggedInUser.UserData.DesignationID)) // for PD Merchandiser and Account Manager only 
                            {
                                if (!IsBIPLUserAccessingIKandiData)
                                {
                                    btnSave.Visible = PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_SUBMIT);
                                }
                                else
                                {
                                    ShowMsg("info", "Costing is in Agreement!!");
                                }
                            }
                        }
                    }
                    else
                    {
                        btnSave.Visible = PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_SUBMIT);
                    }
                }
                else
                {
                    if (IsIkandiClient == 1 && AgrimentLevelDesig.Contains(ApplicationHelper.LoggedInUser.UserData.DesignationID))
                    {
                        if (IsCostingOpen)
                        {
                            btnAcceptClose.Visible = PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_SUBMIT);
                            btnAcceptClose.Text = "Accept and Close Agreement";
                        }
                        else
                        {
                            btnOpenCosting.Visible = PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_SUBMIT);
                            btnAcceptClose.Visible = PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_SUBMIT);
                            btnAcceptClose.Text = "Save";
                        }
                    }
                    else
                    {
                        btnSave.Visible = PermissionHelper.IsVisiblePermittedOnColumn((int)AppModuleColumn.COSTING_CONFIRM_SUBMIT);
                    }
                }

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
            }



            if (Role == 1)
            {
                if (Convert.ToString(CostingObject.PriceQuoted) == "0" && (CostingObject.ParentCostingID == -1 || CostingObject.ParentCostingID != -1) && CostingObject.IsVersion == false)
                {
                    BIPLCosting.Visible = false;
                    PendingCostingMsg.Visible = true;
                }
            }


        }
        private void BindFormWithDefaultData()
        {
            DataTable dtAccessory;
            DataTable dtClientCosting = new DataTable();
            DataTable dtLandedCosting = new DataTable();
            DataTable dtDirectCosting = new DataTable();
            dtClientCosting = AdminControllerInstance.GetClientCosting_By_Client_Dept(this.ClientID, this.DepartmentID, this.StyleID);
            dtLandedCosting = AdminControllerInstance.GetLandedCosting_By_Client_Dept(this.ClientID, this.DepartmentID, this.CostingId);
            dtDirectCosting = AdminControllerInstance.GetDirectCosting_By_Client_Dept(this.ClientID, this.DepartmentID, this.CostingId);
            dtAccessory = CostingControllerInstanceNew.GetCostingDefaultBy_Client_Dept_New(this.ClientID, this.DepartmentID, this.StyleID);
            if (CostingId <= 0)
            {
                AccessoryCount = dtAccessory.Rows.Count;
                gdvAccessory.DataSource = dtAccessory;
                gdvAccessory.DataBind();

                gvdProcessDetails.DataSource = null;// CreateProcessTable();
                gvdProcessDetails.DataBind();

            }


            if (ParentCostingId <= 0)
            {
                if (dtLandedCosting.Rows.Count > 0)
                {
                    grdLandedCosting.DataSource = dtLandedCosting;
                    grdLandedCosting.DataBind();
                }
                else
                {
                    grdLandedCosting.DataSource = null;
                    grdLandedCosting.DataBind();
                }
                if (dtDirectCosting.Rows.Count > 0)
                {
                    grdDirectCosting.DataSource = dtDirectCosting;
                    grdDirectCosting.DataBind();
                }
                else
                {
                    grdDirectCosting.DataSource = null;
                    grdDirectCosting.DataBind();
                }

            }

            if (dtClientCosting.Rows.Count > 0)
            {

                ddlConvTo.SelectedValue = dtClientCosting.Rows[0]["CONVERSIONTO"].ToString(); // itemValue;
                hdnConvertTo.Value = dtClientCosting.Rows[0]["CONVERSIONTO"].ToString();

                if (!string.IsNullOrEmpty(dtClientCosting.Rows[0]["CONVERSIONTO"].ToString()))
                {
                    double rate = CommonHelper.GetCurrencyRate((Currency)Convert.ToInt32(dtClientCosting.Rows[0]["CONVERSIONTO"].ToString()), Currency.INR);
                    txtConvRate.Text = rate.ToString();
                    hdnConvRate.Value = rate.ToString();
                    //hdnCostingConversionRate.Value = rate.ToString();
                }

                if (string.IsNullOrEmpty(txtConvRate.Text))
                {
                    txtConvRate.Text = "65";
                    hdnConvRate.Value = "65";
                }

                txtMarkupOnUnitCtc.Text = dtClientCosting.Rows[0]["PROFITMARGIN"].ToString();


                txtOverHead.Text = dtClientCosting.Rows[0]["OVERHEADCOST"].ToString();

                DataTable dtClientCosting_ExpectedQty = new DataTable();
                //// Change By Ravi kumar on 9/9/2014          
                dtClientCosting_ExpectedQty = AdminControllerInstance.GetClientCosting_By_Client_Dept_ForExpectedQty(this.ClientID, this.DepartmentID, 0);
                ddlExpectedQty.DataSource = dtClientCosting_ExpectedQty;
                ddlExpectedQty.DataTextField = "EXPECTEDQTY";
                ddlExpectedQty.DataValueField = "ExpectedValue";
                ddlExpectedQty.DataBind();
                ddlExpectedQty.SelectedValue = dtClientCosting.Rows[0]["EXPECTEDQTY"].ToString();

                txtExpectedQuant.Text = dtClientCosting.Rows[0]["EXPECTEDQTY"].ToString();

                //txtFrtUptoFinalDest.Text = dtClientCosting.Rows[0]["FRTUPTOPORT"].ToString();
                txtFrtUptoFinalDest.Text = dtClientCosting.Rows[0]["FRTUPTOPORT"].ToString() == "0" ? "" : dtClientCosting.Rows[0]["FRTUPTOPORT"].ToString();

                hdnAch.Value = dtClientCosting.Rows[0]["ACHIEVEMENT"].ToString();
                hdnMinCMT.Value = dtClientCosting.Rows[0]["MinCMT"].ToString();

                txtDesingCommission.Text = dtClientCosting.Rows[0]["DESIGNCOMM"].ToString();

                txtComm.Text = dtClientCosting.Rows[0]["COMMISION"].ToString();
                txtGCW.Text = dtClientCosting.Rows[0]["CostingCutWastage"].ToString();
            }
        }

        private void BindFormWithDefaultDataWithout_PriceQuote()
        {
            DataTable dtClientCosting = new DataTable();
            dtClientCosting = AdminControllerInstance.GetClientCosting_By_Client_Dept(this.ClientID, this.DepartmentID, this.StyleID);
            if (dtClientCosting.Rows.Count > 0)
            {
                ddlConvTo.SelectedValue = dtClientCosting.Rows[0]["CONVERSIONTO"].ToString(); // itemValue;
                hdnConvertTo.Value = dtClientCosting.Rows[0]["CONVERSIONTO"].ToString();

                if (!string.IsNullOrEmpty(dtClientCosting.Rows[0]["CONVERSIONTO"].ToString()))
                {
                    double rate = CommonHelper.GetCurrencyRate((Currency)Convert.ToInt32(dtClientCosting.Rows[0]["CONVERSIONTO"].ToString()), Currency.INR);
                    txtConvRate.Text = rate.ToString();
                    hdnConvRate.Value = rate.ToString();
                    //hdnCostingConversionRate.Value = rate.ToString();
                }

                if (string.IsNullOrEmpty(txtConvRate.Text))
                {
                    txtConvRate.Text = "65";
                    hdnConvRate.Value = "65";
                }

                txtMarkupOnUnitCtc.Text = dtClientCosting.Rows[0]["PROFITMARGIN"].ToString();
                txtOverHead.Text = dtClientCosting.Rows[0]["OVERHEADCOST"].ToString();
                txtExpectedQuant.Text = dtClientCosting.Rows[0]["EXPECTEDQTY"].ToString();
                txtFrtUptoFinalDest.Text = dtClientCosting.Rows[0]["FRTUPTOPORT"].ToString();
                hdnAch.Value = dtClientCosting.Rows[0]["ACHIEVEMENT"].ToString();
                txtDesingCommission.Text = dtClientCosting.Rows[0]["DESIGNCOMM"].ToString();
                txtComm.Text = dtClientCosting.Rows[0]["COMMISION"].ToString();
                txtGCW.Text = dtClientCosting.Rows[0]["CostingCutWastage"].ToString();
            }
        }

        private void BindFormWithCostingData(Costing objCosting)
        {
            bool bCheckReadOnly = false;
            if (objCosting.CostingTask != 0)
            {
                // btnAcknowledgment.Attributes.Add("style", "display;");
            }
            hdnBuyingHouse.Text = objCosting.IsIkandiClient.ToString();
            txtStyleId.Text = objCosting.StyleID.ToString();
            txtStyleNumber.Text = txtIkandiStyle.Text = objCosting.StyleNumber;
            if (objCosting.StyleNumber.Length > 2)
            {
                string code = objCosting.StyleNumber.Substring(0, 2).ToUpper();
                lblGarmetType.Text = this.CostingControllerInstanceNew.GetGarmentNameOption_New(code);
            }
            if (this.CostingControllerInstanceNew.bCheckOB_New(objCosting.StyleID) == false)
            {
                bCheckReadOnly = true;
            }
            txtOrderId.Text = objCosting.OrderId.ToString();
            txtCurrentStatusID.Text = objCosting.CurrentStatusID.ToString();
            ddlBuyer.SelectedValue = objCosting.ClientID.ToString();
            hdnbuyer.Value = objCosting.ClientID.ToString();
            hdnDeptId.Value = objCosting.DepartmentID.ToString();
            hdnParentDeptId.Value = objCosting.ParentDepartmentID.ToString();
            ddlParentDept.SelectedValue = objCosting.ParentDepartmentID.ToString();

            txtWeight.Text = objCosting.Weight.ToString() == "0" ? "" : objCosting.Weight.ToString();
            if (objCosting.Weight_ReadOnly == 1)
                txtWeight.ReadOnly = true;

            txtPriceQuoted.Text = (objCosting.PriceQuoted == 0) ? "" : objCosting.PriceQuoted.ToString("");
            txtPriceAgreed.Text = (objCosting.AgreedPrice == 0) ? "" : objCosting.AgreedPrice.ToString("0.00");
            CurrencySymbol.InnerText = objCosting.CurrencySymbol;


            hiddenStyleId.Value = objCosting.StyleID.ToString();
            lblStatus.Text = Constants.GetStatusModeName(objCosting.CurrentStatusID);
            lblStatus.ToolTip = "Action By " + objCosting.ActionBy;
            tdStatus.Style.Add("background-color", Constants.GetStatusModeColor(objCosting.CurrentStatusID));

            txtOB.Text = objCosting.OB_WS.ToString() == "0" ? "" : objCosting.OB_WS.ToString();
            txtChargesValue11.Text = objCosting.SAM.ToString() == "0" ? "" : objCosting.SAM.ToString();
            txtChargesValue1.Text = objCosting.CMTF.ToString() == "0" ? "" : objCosting.CMTF.ToString();
            lblTotalAmountB.Text = objCosting.CMTF.ToString() == "0" ? "" : objCosting.CMTF.ToString();
            txtGCW.Text = objCosting.CostingCutWastage.ToString() == "0" ? "" : objCosting.CostingCutWastage.ToString();
            txtGVW.Text = objCosting.CostingVAWastage.ToString() == "0" ? "" : objCosting.CostingVAWastage.ToString();

            if (bCheckReadOnly == false)
            {
                txtOB.ReadOnly = true;
            }
            hdnOBCount.Value = Convert.ToInt32(objCosting.OB_WS / 40).ToString();

            hdnAch.Value = objCosting.Achivement.ToString() == "0" ? "70" : objCosting.Achivement.ToString();
            //Disable the  price Quoted if user is Ikandi and Price quoted Not done in base costing                 
            if (objCosting.PriceQuotedVisibility == 0 && Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.CompanyID) == 1)
            {
                txtPriceQuoted.CssClass = txtPriceQuoted.CssClass + " do-not-allow-typing";
                txtPriceQuoted.Attributes.Add("placeholder", "Pndg.BIPL");
                txtPriceQuoted.Attributes.Add("style", "pointer-events: none;font-size:8px;text-transform:none !important;");
            }
            tdCounterComplete.InnerText = objCosting.CounterComplete ? "Counter Complete" : "Counter Pending";
            tdCounterComplete.Style.Add("background-color", objCosting.CounterComplete ? "Green" : "Red");

            txtFrtUptoFinalDest.Text = objCosting.FrieghtUptoFinalDestination.ToString() == "0" ? "" : objCosting.FrieghtUptoFinalDestination.ToString();

            //txtFrtUptoPort.Text = objCosting.FrieghtUptoPort.ToString();

            ddlConvTo.SelectedValue = objCosting.ConvertTo.ToString();
            hdnConvertTo.Value = objCosting.ConvertTo.ToString();
            txtMarkupOnUnitCtc.Text = objCosting.MarkupOnUnitCTC.ToString();
            txtOverHead.Text = objCosting.OverHead.ToString();//
            txtDesingCommission.Text = objCosting.DesignCommission.ToString();

            //ddlMaking.SelectedValue = objCosting.MakingType;

            txtExpectedQuant.Text = Convert.ToString(objCosting.ExpectedQty);
            DataTable dtClientCosting_ExpectedQty = AdminControllerInstance.GetClientCosting_By_Client_Dept_ForExpectedQty(this.ClientID, this.DepartmentID, 1);
            ddlExpectedQty.DataSource = dtClientCosting_ExpectedQty;
            ddlExpectedQty.DataTextField = "EXPECTEDQTY";
            ddlExpectedQty.DataValueField = "ExpectedValue";
            ddlExpectedQty.DataBind();
            ddlExpectedQty.SelectedValue = Convert.ToString(objCosting.ExpectedQty);
            txtComm.Text = objCosting.CommisionPercent.ToString();
            txtConvRate.Text = objCosting.ConversionRate.ToString();
            hdnConvRate.Value = objCosting.ConversionRate.ToString();
            hdnCostingConversionRate.Value = objCosting.DefaultConversionRate.ToString();       //added by raghvinder

            if (!string.IsNullOrEmpty(objCosting.OverallComments) && objCosting.OverallComments.LastIndexOf("$$") > -1)
            {
                string[] comments = objCosting.OverallComments.Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < comments.Length; i++)
                {
                    if (lblOverallCommentsHistory.Text == "")
                        lblOverallCommentsHistory.Text = comments[i];
                    else
                        lblOverallCommentsHistory.Text = lblOverallCommentsHistory.Text + "<br />" + comments[i];
                }
            }
            else
            {
                lblOverallCommentsHistory.Text = objCosting.OverallComments;
            }

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

            imgSampleImageUrl1.Src = (objCosting.SampleImageURL1 == string.Empty) ? "~/App_Themes/ikandi/images/preview.png" : "~/Uploads/Style/" + objCosting.SampleImageURL1;

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "StylePhoto", "$('.sample-image').attr('href', 'javascript:showStylePhotoWithOutScroll_Costing(" + objCosting.StyleID + ",-1,-1)');", true);


            iKandiService proxy = new iKandiService();
            string currencySymbol = proxy.GetCurrencySumbol(objCosting.TargetPriceCurrency);

            if (objCosting.TargetPrice > 0)
            {
                // Edit By surendra for Remove .00 of target price..
                lbltargetprice.Text = currencySymbol + " " + string.Format("{0:G29}", decimal.Parse(objCosting.TargetPrice.ToString()));
            }
            else
            {
                lbltargetprice.Text = currencySymbol;
            }

            ParentCostingId = objCosting.ParentCostingID;
            // This code is added to handle the visibility of the fabric rows
            int s = 0;

            if (objCosting.FabricCostingItems.Count == 1)
            {
                tr_fab1.Attributes.Add("style", "display:;");
            }
            else if (objCosting.FabricCostingItems.Count == 2)
            {
                tr_fab1.Attributes.Add("style", "display:;");
                tr_fab2.Attributes.Add("style", "display:;");
            }
            else if (objCosting.FabricCostingItems.Count == 3)
            {
                tr_fab1.Attributes.Add("style", "display:;");
                tr_fab2.Attributes.Add("style", "display:;");
                tr_fab3.Attributes.Add("style", "display:;");
            }
            else if (objCosting.FabricCostingItems.Count == 4)
            {
                tr_fab1.Attributes.Add("style", "display:;");
                tr_fab2.Attributes.Add("style", "display:;");
                tr_fab3.Attributes.Add("style", "display:;");
                tr_fab4.Attributes.Add("style", "display:;");
            }
            else if (objCosting.FabricCostingItems.Count == 5)
            {
                tr_fab1.Attributes.Add("style", "display:;");
                tr_fab2.Attributes.Add("style", "display:;");
                tr_fab3.Attributes.Add("style", "display:;");
                tr_fab4.Attributes.Add("style", "display:;");
                tr_fab5.Attributes.Add("style", "display:;");
            }
            else if (objCosting.FabricCostingItems.Count == 6)
            {
                tr_fab1.Attributes.Add("style", "display:;");
                tr_fab2.Attributes.Add("style", "display:;");
                tr_fab3.Attributes.Add("style", "display:;");
                tr_fab4.Attributes.Add("style", "display:;");
                tr_fab5.Attributes.Add("style", "display:;");
                tr_fab6.Attributes.Add("style", "display:;");
            }
            else if (objCosting.FabricCostingItems.Count == 7)
            {
                tr_fab1.Attributes.Add("style", "display:;");
                tr_fab2.Attributes.Add("style", "display:;");
                tr_fab3.Attributes.Add("style", "display:;");
                tr_fab4.Attributes.Add("style", "display:;");
                tr_fab5.Attributes.Add("style", "display:;");
                tr_fab6.Attributes.Add("style", "display:;");
                tr_fab7.Attributes.Add("style", "display:;");
            }
            else if (objCosting.FabricCostingItems.Count == 8)
            {
                tr_fab1.Attributes.Add("style", "display:;");
                tr_fab2.Attributes.Add("style", "display:;");
                tr_fab3.Attributes.Add("style", "display:;");
                tr_fab4.Attributes.Add("style", "display:;");
                tr_fab5.Attributes.Add("style", "display:;");
                tr_fab6.Attributes.Add("style", "display:;");
                tr_fab7.Attributes.Add("style", "display:;");
                tr_fab8.Attributes.Add("style", "display:;");
            }
            // Added code By Bharat on 18-Dec-20
            int countFabRowData = objCosting.FabricCostingItems.Count;
            //hdnDisableAcc.Value = objCosting.Disabled_ACC.ToString();
            hdnDeleteButtonCount.Value = countFabRowData.ToString();
            int countAccRowData = objCosting.AccessoryItems.Count;
            hdnAccDeleteButtonCount.Value = countAccRowData.ToString();
            int CountProcessRow = objCosting.ProcessItems.Count;
            hndProDeleteButton.Value = CountProcessRow.ToString();

            // End
            foreach (FabricCosting item in objCosting.FabricCostingItems)
            {

                DropDownList ddlPrintType = tblCostingDetails.FindControl("ddlPrintType" + item.SequenceNumber) as DropDownList;
                TextBox txtFabric = tblCostingDetails.FindControl("txtFabric" + item.SequenceNumber) as TextBox;
                TextBox txtWidth = tblCostingDetails.FindControl("txtWidth" + item.SequenceNumber) as TextBox;

                Label lblWidthCM = tblCostingDetails.FindControl("lblWidthCM" + item.SequenceNumber) as Label;
                TextBox txtAverage = tblCostingDetails.FindControl("txtAverage" + item.SequenceNumber) as TextBox;
                TextBox txtRate = tblCostingDetails.FindControl("txtRate" + item.SequenceNumber) as TextBox;
                TextBox txtAmount = tblCostingDetails.FindControl("txtAmount" + item.SequenceNumber) as TextBox;
                TextBox txtWaste = tblCostingDetails.FindControl("txtWaste" + item.SequenceNumber) as TextBox;
                TextBox txtTotal = tblCostingDetails.FindControl("txtTotal" + item.SequenceNumber) as TextBox;
                TextBox hdncurr = tblCostingDetails.FindControl("hdn" + item.SequenceNumber) as TextBox;
                TextBox hdnprev = tblCostingDetails.FindControl("hdn" + item.SequenceNumber + "Prev") as TextBox;
                Label lblCurr = tblCostingDetails.FindControl("lbl" + item.SequenceNumber) as Label;
                HiddenField hiddenRadioMode = tblCostingDetails.FindControl("hiddenRadioMode" + item.SequenceNumber) as HiddenField;
                //Image img = tblCostingDetails.FindControl("imgFab" + item.SequenceNumber) as 'Image';
                HyperLink lnkLayFile = tblCostingDetails.FindControl("viewolay" + item.SequenceNumber) as HyperLink;
                FileUpload LayUploadFile = tblCostingDetails.FindControl("LayFile" + item.SequenceNumber) as FileUpload;

                HyperLink ViewCad = tblCostingDetails.FindControl("ViewCad" + item.SequenceNumber) as HyperLink;
                HyperLink ViewStc = tblCostingDetails.FindControl("ViewStc" + item.SequenceNumber) as HyperLink;
                Label lblcst = tblCostingDetails.FindControl("lblcst" + item.SequenceNumber) as Label;
                Label lblcad = tblCostingDetails.FindControl("lblcad" + item.SequenceNumber) as Label;
                Label lblmarker = tblCostingDetails.FindControl("lblmarker" + item.SequenceNumber) as Label;
                Label lblTotalfabric = tblCostingDetails.FindControl("lblTotalfabric" + item.SequenceNumber) as Label;
                TextBox lblTotalPrice = tblCostingDetails.FindControl("lblTotalPrice" + item.SequenceNumber) as TextBox;

                HiddenField hdnFabricID = tblCostingDetails.FindControl("hdnFabricID" + item.SequenceNumber) as HiddenField;
                TextBox lblRS = tblCostingDetails.FindControl("lblRS" + item.SequenceNumber) as TextBox;
                DropDownList DDLFabricType = tblCostingDetails.FindControl("DDLFabricType" + item.SequenceNumber) as DropDownList;

                HiddenField hdnDyedRate = tblCostingDetails.FindControl("hdnDyedRate" + item.SequenceNumber) as HiddenField;
                HiddenField hdnPrintRate = tblCostingDetails.FindControl("hdnPrintRate" + item.SequenceNumber) as HiddenField;
                HiddenField hdnDigitalPrintRate = tblCostingDetails.FindControl("hdnDigitalPrintRate" + item.SequenceNumber) as HiddenField;

                DropDownList ddlValueAddition1 = tblCostingDetails.FindControl("ddlValueAddition" + item.SequenceNumber + "_1") as DropDownList;
                DropDownList ddlValueAddition2 = tblCostingDetails.FindControl("ddlValueAddition" + item.SequenceNumber + "_2") as DropDownList;

                HiddenField hdnValueAdditionId1 = tblCostingDetails.FindControl("hdnValueAdditionId" + item.SequenceNumber + "_1") as HiddenField;
                HiddenField hdnValueAdditionId2 = tblCostingDetails.FindControl("hdnValueAdditionId" + item.SequenceNumber + "_2") as HiddenField;

                TextBox txtVAWastage1 = tblCostingDetails.FindControl("txtVAWastage" + item.SequenceNumber + "_1") as TextBox;
                TextBox txtVAWastage2 = tblCostingDetails.FindControl("txtVAWastage" + item.SequenceNumber + "_2") as TextBox;

                TextBox txtVARate1 = tblCostingDetails.FindControl("txtVARate" + item.SequenceNumber + "_1") as TextBox;
                TextBox txtVARate2 = tblCostingDetails.FindControl("txtVARate" + item.SequenceNumber + "_2") as TextBox;

                Label lblVaCurrency1 = tblCostingDetails.FindControl("lblVaCurrency" + item.SequenceNumber + "_1") as Label;
                Label lblVaCurrency2 = tblCostingDetails.FindControl("lblVaCurrency" + item.SequenceNumber + "_2") as Label;

                HiddenField hdnCOUNTCON;
                HiddenField hdnGSML;
                Label lblCOUNTCON;
                Label lblGSML;
                if (item.SequenceNumber == 1)
                {
                    lblCOUNTCON = tblCostingDetails.FindControl("COUNTCON") as Label;
                    lblGSML = tblCostingDetails.FindControl("GSML") as Label;
                    hdnCOUNTCON = tblCostingDetails.FindControl("hdnCOUNTCON") as HiddenField;
                    hdnGSML = tblCostingDetails.FindControl("hdnGSML") as HiddenField;
                }
                else
                {
                    lblCOUNTCON = tblCostingDetails.FindControl("COUNTCON" + item.SequenceNumber) as Label;
                    lblGSML = tblCostingDetails.FindControl("GSML" + item.SequenceNumber) as Label;
                    hdnCOUNTCON = tblCostingDetails.FindControl("hdnCOUNTCON" + item.SequenceNumber) as HiddenField;
                    hdnGSML = tblCostingDetails.FindControl("hdnGSML" + item.SequenceNumber) as HiddenField;
                }
                if (item.CountConstruct != "0")
                {
                    lblCOUNTCON.Text = item.CountConstruct;
                }
                if (item.GSM.ToString() != "0")
                {
                    lblGSML.Text = "&nbsp;(" + item.GSM.ToString() + ")";
                }
                hdnCOUNTCON.Value = item.CountConstruct;
                hdnGSML.Value = item.GSM.ToString();
                //if (item.isMultiple == "Y")
                //    img.Visible = true;
                DDLFabricType.SelectedValue = item.FabTypeId;
                hdnFabricID.Value = item.FabricQualityId;

                hdnDyedRate.Value = item.DyedRate.ToString();
                hdnPrintRate.Value = item.PrintRate.ToString();
                hdnDigitalPrintRate.Value = item.DigitalPrintRate.ToString();

                ddlPrintType.SelectedValue = item.PrintType;
                if (Convert.ToInt32(hdnFabricID.Value) >= 20000)
                {

                    txtFabric.Attributes.Add("style", "background-color:#bfbfbf !important;color:#FF0000!important;");
                }
                if (item.Disabled_Fabric == true)
                {

                    txtFabric.Attributes.Add("readonly", "readonly");
                    // txtFabric.Attributes.Remove("class");
                    // txtFabric.CssClass = "costing-fabric alin per ac_input";
                }

                txtFabric.Text = item.Fabric;

                if (item.Fabric != "")
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
                if (s == 4)
                {
                    txtFabricType5.Value = item.specialFabricDetails.Trim() == ""
                                             ? item.FabricType
                                             : item.specialFabricDetails;
                }
                if (s == 5)
                {
                    txtFabricType6.Value = item.specialFabricDetails.Trim() == ""
                                             ? item.FabricType
                                             : item.specialFabricDetails;
                }
                if (s == 6)
                {
                    txtFabricType7.Value = item.specialFabricDetails.Trim() == ""
                                             ? item.FabricType
                                             : item.specialFabricDetails;
                }
                if (s == 7)
                {
                    txtFabricType8.Value = item.specialFabricDetails.Trim() == ""
                                             ? item.FabricType
                                             : item.specialFabricDetails;
                }
                txtWidth.Text = item.Width.ToString();
                lblWidthCM.Text = Math.Round(item.Width * 2.54).ToString();
                lblRS.Text = item.ResidualShrinkage.ToString();
                txtAverage.Text = (item.Average == 0) ? "0.00" : item.Average.ToString("0.000");
                txtRate.Text = item.Rate.ToString();
                txtAmount.Text = item.Amount.ToString();
                txtWaste.Text = item.Waste.ToString();
                txtTotal.Text = item.Total.ToString("0.00");
                lblTotalfabric.Text = item.TotalFabric.ToString("0.00");
                lblTotalPrice.Text = item.TotalPrice.ToString("0.00");
                hiddenRadioMode.Value = Convert.ToInt32(item.IsAir).ToString();
                hdncurr.Text = item.FabPrintNumber;
                hdnprev.Text = "";

                lnkLayFile.NavigateUrl = "~/Uploads/Photo/" + item.LayFileName;
                ViewCad.NavigateUrl = "~/Uploads/Photo/" + item.CadFileName;
                ViewStc.NavigateUrl = "~/Uploads/Photo/" + item.StcFileName;

                if (!String.IsNullOrEmpty(item.LayFileName))
                {
                    lblcst.Attributes.Add("style", "display:block;");
                    lnkLayFile.Attributes.Add("style", "display:block;");
                }

                if (!String.IsNullOrEmpty(item.CadFileName))
                {
                    lblcad.Attributes.Add("style", "display:none;");
                    ViewCad.Attributes.Add("style", "display:none;");
                }
                if (!String.IsNullOrEmpty(item.StcFileName))
                {
                    lblmarker.Attributes.Add("style", "display:none;");
                    ViewStc.Attributes.Add("style", "display:none;");
                }
                if (item.IsPrint == 1)
                {
                    lblCurr.Text = "PRD: ";
                }

                List<ValueAddition> ValueAdditionList = this.CostingControllerInstanceNew.GetValueAdditionDDL(0);
                if (ValueAdditionList.Count > 0)
                {
                    ddlValueAddition1.Items.Clear();
                    ddlValueAddition1.DataSource = ValueAdditionList;
                    ddlValueAddition1.DataTextField = "ValueAdditionName";
                    ddlValueAddition1.DataValueField = "ValueAdditionID";
                    ddlValueAddition1.DataBind();
                    ddlValueAddition1.Items.Insert(0, new ListItem("Select", "-1"));


                    ddlValueAddition2.Items.Clear();
                    ddlValueAddition2.DataSource = ValueAdditionList;
                    ddlValueAddition2.DataTextField = "ValueAdditionName";
                    ddlValueAddition2.DataValueField = "ValueAdditionID";
                    ddlValueAddition2.DataBind();
                    ddlValueAddition2.Items.Insert(0, new ListItem("Select", "-1"));

                    if (item.ValueAdditionId1 > 0)
                        ddlValueAddition1.SelectedValue = item.ValueAdditionId1.ToString();

                    if (item.ValueAdditionId2 > 0)
                        ddlValueAddition2.SelectedValue = item.ValueAdditionId2.ToString();

                    hdnValueAdditionId1.Value = item.ValueAdditionId1.ToString();
                    hdnValueAdditionId2.Value = item.ValueAdditionId2.ToString();

                }
                txtVAWastage1.Text = item.VAWastage1 > 0 ? item.VAWastage1.ToString() + " %" : "";
                txtVAWastage2.Text = item.VAWastage2 > 0 ? item.VAWastage2.ToString() + " %" : "";

                txtVARate1.Text = item.VARate1 > 0 ? item.VARate1.ToString() : "";
                txtVARate2.Text = item.VARate2 > 0 ? item.VARate2.ToString() : "";

                if (item.VARate1 > 0)
                    lblVaCurrency1.CssClass = "addRupeesym";

                if (item.VARate2 > 0)
                    lblVaCurrency2.CssClass = "addRupeesym";


                //this.CostingControllerInstanceNew.GetGarmentNameOption_New(code);

                s = s + 1;
            }
            AccessoryCount = objCosting.AccessoryItems.Count;
            gdvAccessory.DataSource = objCosting.AccessoryItems;
            gdvAccessory.DataBind();

            if (objCosting.ProcessItems.Count > 0)
                gvdProcessDetails.DataSource = objCosting.ProcessItems;
            else
                gvdProcessDetails.DataSource = null;

            gvdProcessDetails.DataBind();

            DataTable dtLandedCosting = new DataTable();
            dtLandedCosting.Columns.Add(new DataColumn("ModeId", typeof(string)));
            dtLandedCosting.Columns.Add(new DataColumn("Code", typeof(string)));
            dtLandedCosting.Columns.Add(new DataColumn("FOBBoutique", typeof(string)));
            dtLandedCosting.Columns.Add(new DataColumn("FOBIkandi", typeof(string)));
            dtLandedCosting.Columns.Add(new DataColumn("Duty", typeof(string)));
            dtLandedCosting.Columns.Add(new DataColumn("Handling", typeof(string)));
            dtLandedCosting.Columns.Add(new DataColumn("Delivery", typeof(string)));
            dtLandedCosting.Columns.Add(new DataColumn("Margin", typeof(string)));
            dtLandedCosting.Columns.Add(new DataColumn("Discount", typeof(string)));
            dtLandedCosting.Columns.Add(new DataColumn("ModeCost", typeof(string)));
            dtLandedCosting.Columns.Add(new DataColumn("ProcessCost", typeof(string)));
            dtLandedCosting.Columns.Add(new DataColumn("GrandTotal", typeof(string)));
            dtLandedCosting.Columns.Add(new DataColumn("QuotedPrice", typeof(string)));
            dtLandedCosting.Columns.Add(new DataColumn("AgreedPrice", typeof(string)));

            foreach (LandedCosting item in objCosting.LandedCostingItems)
            {
                DataRow dr = dtLandedCosting.NewRow();
                dr[0] = item.ModeId;
                dr[1] = item.Code;
                dr[2] = item.FOBBoutique;
                dr[3] = item.FOBIkandi;
                dr[4] = item.Duty;
                dr[5] = item.Handling;
                dr[6] = item.Delivery;
                dr[7] = item.Margin.ToString();
                dr[8] = item.Discount.ToString();
                dr[9] = item.ModeCost;
                dr[10] = item.ProcessCost;
                dr[11] = item.GrandTotal;
                dr[12] = item.QuotedPrice == 0 ? "" : item.QuotedPrice.ToString();
                dr[13] = item.AgreedPrice == 0 ? "" : item.AgreedPrice.ToString();

                dtLandedCosting.Rows.Add(dr);

            }
            if (objCosting.LandedCostingItems.Count > 0)
            {
                grdLandedCosting.DataSource = dtLandedCosting;
                grdLandedCosting.DataBind();
            }

            DataTable dtDirectCosting = new DataTable();
            dtDirectCosting.Columns.Add(new DataColumn("ModeId", typeof(string)));
            dtDirectCosting.Columns.Add(new DataColumn("Code", typeof(string)));
            dtDirectCosting.Columns.Add(new DataColumn("FOBDelhi", typeof(string)));
            dtDirectCosting.Columns.Add(new DataColumn("HaulageCharges", typeof(string)));
            dtDirectCosting.Columns.Add(new DataColumn("FOBMargin", typeof(string)));
            dtDirectCosting.Columns.Add(new DataColumn("Discount", typeof(string)));
            dtDirectCosting.Columns.Add(new DataColumn("GrandTotal", typeof(string)));
            dtDirectCosting.Columns.Add(new DataColumn("QuotedPrice", typeof(string)));
            dtDirectCosting.Columns.Add(new DataColumn("AgreedPrice", typeof(string)));

            foreach (FOBPricing item in objCosting.FOBPricingItemNew)
            {
                DataRow dr = dtDirectCosting.NewRow();
                dr[0] = item.ModeId;
                dr[1] = item.Code;
                dr[2] = item.FOBDelhi;
                dr[3] = item.HaulageCharges;
                dr[4] = item.FOBMargin;
                dr[5] = item.Discount;
                dr[6] = item.GrandTotal;
                dr[7] = item.QuotedPrice == 0 ? "" : item.QuotedPrice.ToString();
                dr[8] = item.AgreedPrice == 0 ? "" : item.AgreedPrice.ToString();

                dtDirectCosting.Rows.Add(dr);
            }

            if (objCosting.FOBPricingItemNew.Count > 0)
            {
                grdDirectCosting.DataSource = dtDirectCosting;
                grdDirectCosting.DataBind();
            }

            hdnIsOrderConfirmed.Value = objCosting.IsOrderConfirmed == 1 ? "1" : "0";

            //if (objCosting.IsOrderConfirmed == 1)
            //{

            //    ddlBuyer.Attributes.Add("disabled", "disabled");
            //    ddlParentDept.Attributes.Add("disabled", "disabled");
            //    ddlDept.Attributes.Add("disabled", "disabled");
            //    //ddlExpectedQty.Attributes.Add("disabled", "disabled");
            //}

            //lblLastUpdatedDate.Text = "Updated On: " + objCosting.UpdatedOn.ToString("dd MMM yy (ddd)");
            lblBIPLHistory.Text = LowercaseFirst(objCosting.BIPlChangesHistory.Replace("$$", "<br/>").Replace("<br/><br/>", "<br/>"));
            lbliKandiHistory.Text = LowercaseFirst(objCosting.iKandiChangesHistory.Replace("$$", "<br/>").Replace("<br/><br/>", "<br/>"));
        }

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

        private DataTable CreateAccessoryTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("AccessoryQualityID", typeof(string)));
            dt.Columns.Add(new DataColumn("Item", typeof(string)));
            dt.Columns.Add(new DataColumn("Quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("TotalQuantity", typeof(string)));
            dt.Columns.Add(new DataColumn("Rate", typeof(string)));
            dt.Columns.Add(new DataColumn("Wastage", typeof(string)));
            dt.Columns.Add(new DataColumn("Amount", typeof(string)));
            dt.Columns.Add(new DataColumn("TotalPrice", typeof(string)));
            dt.Columns.Add(new DataColumn("Unit", typeof(string)));
            dt.Columns.Add(new DataColumn("AccessoryID", typeof(string)));
            dt.Columns.Add(new DataColumn("remarks", typeof(string)));
            dt.Columns.Add(new DataColumn("Disabled_ACC", typeof(string)));
            dt.Columns.Add(new DataColumn("IsDefaultAccessory", typeof(int)));
            dt.Columns.Add(new DataColumn("ClientId", typeof(int)));
            dt.Columns.Add(new DataColumn("ParentDepartmentId", typeof(int)));
            dt.Columns.Add(new DataColumn("DepartmentId", typeof(int)));
            return dt;
        }

        private void AccessoriesTable()
        {
            if (ViewState["dtDeleteAccess"] == null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("AccessoryQualityID", typeof(string)));
                dt.Columns.Add(new DataColumn("Item", typeof(string)));
                dt.Columns.Add(new DataColumn("AccessoryID", typeof(string)));

                //added by raghvinder on 09-10-2020
                dt.Columns.Add(new DataColumn("Disabled_ACC", typeof(string)));

                ViewState["dtDeleteAccess"] = dt;
            }
        }

        protected void lnkAddAccessary_Click(object sender, EventArgs e)
        {
            try
            {

                if (gdvAccessory.Rows.Count == 28)
                {

                    //ImageButton LinkButton1 = (ImageButton)gdvAccessory.FindControl("LinkButton1");
                    //LinkButton1.Attributes.Add("readonly", "readonly");
                    //LinkButton1.Enabled = false;
                    ShowAlert("Can not add more than 28 Accessory!");
                    return;
                }
                DataTable dt = CreateAccessoryTable();
                foreach (GridViewRow gdvrow in gdvAccessory.Rows)
                {
                    HiddenField hdnID = (HiddenField)gdvrow.FindControl("hdnID");
                    TextBox txtItems = (TextBox)gdvrow.FindControl("txtItems");
                    TextBox txtUnitQty = (TextBox)gdvrow.FindControl("txtUnitQty");
                    TextBox lblTotalQuantity = (TextBox)gdvrow.FindControl("lblTotalQuantity");
                    TextBox txtRate = (TextBox)gdvrow.FindControl("txtRate");
                    TextBox lblWastage = (TextBox)gdvrow.FindControl("lblWastage");
                    TextBox lblTotalAmount = (TextBox)gdvrow.FindControl("lblTotalAmount");
                    TextBox lblTotalPriceAcc = (TextBox)gdvrow.FindControl("lblTotalPriceAcc");
                    TextBox lblUnit = (TextBox)gdvrow.FindControl("lblUnit");
                    HiddenField hdnRemak = (HiddenField)gdvrow.FindControl("hdnRemak");

                    HiddenField hdnDisableAcc = (HiddenField)gdvrow.FindControl("hdnDisableAcc");
                    HiddenField hdnIsDefaultAccessory = (HiddenField)gdvrow.FindControl("hdnIsDefaultAccessory");
                    HiddenField hdnAccClientId = (HiddenField)gdvrow.FindControl("hdnAccClientId");
                    HiddenField hdnAccParentDeptId = (HiddenField)gdvrow.FindControl("hdnAccParentDeptId");
                    HiddenField hdnAccDeptId = (HiddenField)gdvrow.FindControl("hdnAccDeptId");


                    DataRow dr = dt.NewRow();
                    dr[0] = hdnID.Value;
                    dr[1] = txtItems.Text;
                    dr[2] = txtUnitQty.Text;
                    dr[3] = lblTotalQuantity.Text;
                    dr[4] = txtRate.Text;
                    dr[5] = lblWastage.Text;
                    dr[6] = lblTotalAmount.Text;
                    dr[7] = lblTotalPriceAcc.Text;
                    dr[8] = lblUnit.Text;
                    dr[9] = gdvAccessory.DataKeys[gdvrow.RowIndex].Value;
                    dr[10] = hdnRemak.Value;
                    dr[11] = hdnDisableAcc.Value;
                    dr[12] = hdnIsDefaultAccessory.Value == null ? 0 : Convert.ToInt32(hdnIsDefaultAccessory.Value);
                    dr[13] = Convert.ToInt32(hdnAccClientId.Value);
                    dr[14] = Convert.ToInt32(hdnAccParentDeptId.Value);
                    dr[15] = Convert.ToInt32(hdnAccDeptId.Value);
                    dt.Rows.Add(dr);
                }
                if (dt.Rows.Count > 0)
                {
                    string name = dt.Rows[dt.Rows.Count - 1]["Item"].ToString();
                    if (name == "")
                    {
                        ShowAlert("Accessory should not be blank!");
                        return;
                    }
                }
                DataRow dr1 = dt.NewRow();
                dr1[0] = "";
                dr1[1] = "";
                dr1[2] = "";
                dr1[3] = "";
                dr1[4] = "";
                dr1[5] = "";
                dr1[6] = "";
                dr1[7] = "";
                dr1[8] = "";
                dr1[9] = "0";
                dr1[10] = "";
                dr1[11] = "False";
                dr1[12] = 0;
                dr1[13] = -1;
                dr1[14] = -1;
                dr1[15] = -1;

                dt.Rows.Add(dr1);
                AccessoryCount = dt.Rows.Count;
                gdvAccessory.DataSource = dt;
                gdvAccessory.DataBind();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HiddenField hdnID = (HiddenField)gdvAccessory.Rows[i].FindControl("hdnID");
                    TextBox txtItems = (TextBox)gdvAccessory.Rows[i].FindControl("txtItems");
                    TextBox txtUnitQty = (TextBox)gdvAccessory.Rows[i].FindControl("txtUnitQty");
                    TextBox lblTotalQuantity = (TextBox)gdvAccessory.Rows[i].FindControl("lblTotalQuantity");
                    TextBox txtRate = (TextBox)gdvAccessory.Rows[i].FindControl("txtRate");
                    TextBox lblWastage = (TextBox)gdvAccessory.Rows[i].FindControl("lblWastage");
                    TextBox lblTotalAmount = (TextBox)gdvAccessory.Rows[i].FindControl("lblTotalAmount");
                    TextBox lblTotalPriceAcc = (TextBox)gdvAccessory.Rows[i].FindControl("lblTotalPriceAcc");
                    TextBox lblUnit = (TextBox)gdvAccessory.Rows[i].FindControl("lblUnit");
                    HiddenField hdnRemak = (HiddenField)gdvAccessory.Rows[i].FindControl("hdnRemak");

                    txtItems.Text = dt.Rows[i]["Item"].ToString();
                    txtUnitQty.Text = dt.Rows[i]["Quantity"].ToString();
                    lblTotalQuantity.Text = dt.Rows[i]["TotalQuantity"].ToString();
                    txtRate.Text = dt.Rows[i]["Rate"].ToString();
                    lblWastage.Text = dt.Rows[i]["Wastage"].ToString();
                    lblTotalAmount.Text = dt.Rows[i]["Amount"].ToString();
                    lblTotalPriceAcc.Text = dt.Rows[i]["TotalPrice"].ToString();
                    lblUnit.Text = dt.Rows[i]["Unit"].ToString();
                    hdnRemak.Value = dt.Rows[i]["remarks"].ToString();
                }
                decimal a = 0, p = 0;
                decimal TotalAmount = dt.AsEnumerable().Where(r => decimal.TryParse(r.Field<string>("Amount"), out a)).Sum(r => a);
                decimal TotalPrice = dt.AsEnumerable().Where(r => decimal.TryParse(r.Field<string>("TotalPrice"), out p)).Sum(r => p);

                lblTotalAmountC.Text = TotalAmount.ToString("0.00");
                lblTotalPriceC.Text = TotalPrice.ToString("0.00");
            }
            catch
            {

            }

        }

        //added by raghvinder on 18-09-2020 start
        protected void gdvAccessory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int countrow = AccessoryCount;
            int OrderId = txtOrderId.Text == "" ? -1 : Convert.ToInt32(txtOrderId.Text);
            hdnAccDeleteButtonCount.Value = countrow.ToString();

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtItems = (TextBox)e.Row.FindControl("txtItems");
                HiddenField hdnAccessoryQualityID = (HiddenField)e.Row.FindControl("hdnAccessoryQualityID");
                HiddenField hdnDisableAcc = (HiddenField)e.Row.FindControl("hdnDisableAcc");
                ImageButton imgBtndelete = (ImageButton)e.Row.FindControl("imgBtndelete");
                if (hdnAccessoryQualityID.Value != "")
                {

                    if (Convert.ToInt32(hdnAccessoryQualityID.Value) >= 40000)
                    {
                        txtItems.Attributes.Add("Style", "background-color:#bfbfbf !important;color:#FF0000!important;");
                    }

                    if (hdnDisableAcc.Value != "")
                    {
                        if (Convert.ToBoolean(hdnDisableAcc.Value) == true)
                        {
                            txtItems.Attributes.Add("readonly", "readonly");
                        }
                    }
                }

                if (OrderId <= 0)
                {
                    imgBtndelete.CssClass = "ShowButton";
                }
                else
                {
                    if (e.Row.RowIndex == (countrow - 1))
                    {
                        imgBtndelete.CssClass = "ShowButton";
                    }
                    else
                    {
                        imgBtndelete.CssClass = "HideButton";
                    }
                }
            }


        }
        //added by raghvinder on 18-09-2020 end

        protected void imgBtndelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GridViewRow gdvrow1 = (GridViewRow)(((Control)sender).NamingContainer);
                HiddenField hfID = (HiddenField)gdvrow1.FindControl("hdnID");
                TextBox txtItemsMain = (TextBox)gdvrow1.FindControl("txtItems");
                string delAccessory = hdnDeleteAccessory.Value.ToString();
                if (delAccessory == "")
                {
                    delAccessory = txtItemsMain.Text.Trim();
                }
                else
                {
                    delAccessory = delAccessory + "!!!!!" + txtItemsMain.Text.Trim();
                }
                hdnDeleteAccessory.Value = delAccessory;

                DataTable dt = CreateAccessoryTable();
                foreach (GridViewRow gdvrow in gdvAccessory.Rows)
                {
                    HiddenField hdnID = (HiddenField)gdvrow.FindControl("hdnID");
                    TextBox txtItems = (TextBox)gdvrow.FindControl("txtItems");
                    TextBox txtUnitQty = (TextBox)gdvrow.FindControl("txtUnitQty");
                    TextBox lblTotalQuantity = (TextBox)gdvrow.FindControl("lblTotalQuantity");
                    TextBox txtRate = (TextBox)gdvrow.FindControl("txtRate");
                    TextBox lblWastage = (TextBox)gdvrow.FindControl("lblWastage");
                    TextBox lblTotalAmount = (TextBox)gdvrow.FindControl("lblTotalAmount");
                    TextBox lblTotalPriceAcc = (TextBox)gdvrow.FindControl("lblTotalPriceAcc");
                    TextBox lblUnit = (TextBox)gdvrow.FindControl("lblUnit");
                    HiddenField hdnRemak = (HiddenField)gdvrow.FindControl("hdnRemak");

                    //added by raghvinder on 09-10-2020 start
                    HiddenField hdnDisableAcc = (HiddenField)gdvrow.FindControl("hdnDisableAcc");
                    HiddenField hdnIsDefaultAccessory = (HiddenField)gdvrow.FindControl("hdnIsDefaultAccessory");
                    HiddenField hdnAccClientId = (HiddenField)gdvrow.FindControl("hdnAccClientId");
                    HiddenField hdnAccParentDeptId = (HiddenField)gdvrow.FindControl("hdnAccParentDeptId");
                    HiddenField hdnAccDeptId = (HiddenField)gdvrow.FindControl("hdnAccDeptId");

                    DataRow dr = dt.NewRow();
                    dr[0] = hdnID.Value;
                    dr[1] = txtItems.Text;
                    dr[2] = txtUnitQty.Text;
                    dr[3] = lblTotalQuantity.Text;
                    dr[4] = txtRate.Text;
                    dr[5] = lblWastage.Text;
                    dr[6] = lblTotalAmount.Text;
                    dr[7] = lblTotalPriceAcc.Text;
                    dr[8] = lblUnit.Text;
                    dr[9] = gdvAccessory.DataKeys[gdvrow.RowIndex].Value;
                    dr[10] = hdnRemak.Value;
                    dr[11] = hdnDisableAcc.Value;
                    dr[12] = hdnIsDefaultAccessory.Value == null ? 0 : Convert.ToInt32(hdnIsDefaultAccessory.Value);
                    dr[13] = Convert.ToInt32(hdnAccClientId.Value);
                    dr[14] = Convert.ToInt32(hdnAccParentDeptId.Value);
                    dr[15] = Convert.ToInt32(hdnAccDeptId.Value);
                    dt.Rows.Add(dr);
                }

                AccessoriesTable();
                DataTable dtDeleteAcc = (DataTable)ViewState["dtDeleteAccess"];
                DataRow drDelete = dtDeleteAcc.NewRow();
                drDelete[0] = dt.Rows[gdvrow1.RowIndex]["AccessoryQualityID"];
                drDelete[1] = dt.Rows[gdvrow1.RowIndex]["Item"];
                drDelete[2] = dt.Rows[gdvrow1.RowIndex]["AccessoryID"];

                drDelete[3] = dt.Rows[gdvrow1.RowIndex]["Disabled_ACC"]; //added by raghvinder on 09-10-2020
                dtDeleteAcc.Rows.Add(drDelete);

                ViewState["dtDeleteAccess"] = dtDeleteAcc;

                dt.Rows[gdvrow1.RowIndex].Delete();
                if (dt.Rows.Count > 0)
                {
                    AccessoryCount = dt.Rows.Count;
                    gdvAccessory.DataSource = dt;
                    gdvAccessory.DataBind();
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = "";
                    dr[1] = "";
                    dr[2] = "";
                    dr[3] = "";
                    dr[4] = "";
                    dr[5] = "";
                    dr[6] = "";
                    dr[7] = "";
                    dr[8] = "";
                    dr[9] = "";
                    dr[10] = "";
                    dr[11] = "False";
                    dr[12] = 0;
                    dr[13] = -1;
                    dr[14] = -1;
                    dr[15] = -1;
                    dt.Rows.Add(dr);

                    AccessoryCount = dt.Rows.Count;
                    gdvAccessory.DataSource = dt;
                    gdvAccessory.DataBind();
                }

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HiddenField hdnID = (HiddenField)gdvAccessory.Rows[i].FindControl("hdnID");
                    TextBox txtItems = (TextBox)gdvAccessory.Rows[i].FindControl("txtItems");
                    TextBox txtUnitQty = (TextBox)gdvAccessory.Rows[i].FindControl("txtUnitQty");
                    TextBox lblTotalQuantity = (TextBox)gdvAccessory.Rows[i].FindControl("lblTotalQuantity");
                    TextBox txtRate = (TextBox)gdvAccessory.Rows[i].FindControl("txtRate");
                    TextBox lblWastage = (TextBox)gdvAccessory.Rows[i].FindControl("lblWastage");
                    TextBox lblTotalAmount = (TextBox)gdvAccessory.Rows[i].FindControl("lblTotalAmount");
                    TextBox lblTotalPriceAcc = (TextBox)gdvAccessory.Rows[i].FindControl("lblTotalPriceAcc");
                    TextBox lblUnit = (TextBox)gdvAccessory.Rows[i].FindControl("lblUnit");

                    txtItems.Text = dt.Rows[i]["Item"].ToString();
                    txtUnitQty.Text = dt.Rows[i]["Quantity"].ToString();
                    lblTotalQuantity.Text = dt.Rows[i]["TotalQuantity"].ToString();
                    txtRate.Text = dt.Rows[i]["Rate"].ToString();
                    lblWastage.Text = dt.Rows[i]["Wastage"].ToString();
                    lblTotalAmount.Text = dt.Rows[i]["Amount"].ToString();
                    lblTotalPriceAcc.Text = dt.Rows[i]["TotalPrice"].ToString();
                    lblUnit.Text = dt.Rows[i]["Unit"].ToString();
                }

                decimal a = 0, p = 0;
                decimal TotalAmount = dt.AsEnumerable().Where(r => decimal.TryParse(r.Field<string>("Amount"), out a)).Sum(r => a);
                decimal TotalPrice = dt.AsEnumerable().Where(r => decimal.TryParse(r.Field<string>("TotalPrice"), out p)).Sum(r => p);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "TotalAccessoriesAmountFromServer(" + TotalAmount + ", " + TotalPrice + ")", true);
            }
            catch
            {

            }
        }

        private DataTable CreateProcessTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("ProcessCostingId", typeof(string)));
            dt.Columns.Add(new DataColumn("ValueAdditionID", typeof(string)));
            dt.Columns.Add(new DataColumn("Item", typeof(string)));
            dt.Columns.Add(new DataColumn("FromStatus", typeof(string)));
            dt.Columns.Add(new DataColumn("ToStatus", typeof(string)));
            dt.Columns.Add(new DataColumn("Amount", typeof(string)));
            dt.Columns.Add(new DataColumn("CostingVAWastage", typeof(string)));
            dt.Columns.Add(new DataColumn("Rate", typeof(string)));
            dt.Columns.Add(new DataColumn("Wastage", typeof(string)));

            if (gvdProcessDetails.Rows.Count <= 0)
            {
                DataRow dr = dt.NewRow();
                dr[0] = "";
                dr[1] = "";
                dr[2] = "";
                dr[3] = "";
                dr[4] = "";
                dr[5] = "";
                dr[6] = "";
                dr[7] = "";
                dr[8] = "";
                dt.Rows.Add(dr);
            }

            return dt;
        }

        protected void lnkAddProcess_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = CreateProcessTable();
                foreach (GridViewRow gdvrow in gvdProcessDetails.Rows)
                {
                    HiddenField hdnValueAdditionID = (HiddenField)gdvrow.FindControl("hdnValueAdditionID");
                    TextBox txtPItems = (TextBox)gdvrow.FindControl("txtPItems");
                    TextBox txtFromStatus = (TextBox)gdvrow.FindControl("txtFromStatus");
                    TextBox txtToStatus = (TextBox)gdvrow.FindControl("txtToStatus");
                    TextBox lblTotalAmount = (TextBox)gdvrow.FindControl("lblTotalAmount");
                    HiddenField hdnCostingVAWastage = (HiddenField)gdvrow.FindControl("hdnCostingVAWastage");
                    TextBox txtRate = (TextBox)gdvrow.FindControl("txtRate");
                    TextBox txtWastage = (TextBox)gdvrow.FindControl("txtWastage");

                    DataRow dr = dt.NewRow();
                    dr[0] = gvdProcessDetails.DataKeys[gdvrow.RowIndex].Value;
                    dr[1] = hdnValueAdditionID.Value;
                    dr[2] = txtPItems.Text;
                    dr[3] = txtFromStatus.Text;
                    dr[4] = txtToStatus.Text;
                    dr[5] = lblTotalAmount.Text;
                    dr[6] = hdnCostingVAWastage.Value;
                    dr[7] = txtRate.Text;
                    dr[8] = txtWastage.Text;
                    dt.Rows.Add(dr);
                }
                if (gvdProcessDetails.Rows.Count > 0)
                {
                    string name = dt.Rows[dt.Rows.Count - 1]["Item"].ToString();
                    if (name == "")
                    {
                        return;
                    }
                }
                else
                {
                    gvdProcessDetails.DataSource = dt;
                    gvdProcessDetails.DataBind();
                    return;
                }

                DataRow dr1 = dt.NewRow();
                dr1[0] = "";
                dr1[1] = "";
                dr1[2] = "";
                dr1[3] = "";
                dr1[4] = "";
                dr1[5] = "";
                dr1[6] = "";
                dr1[7] = "";
                dr1[8] = "";

                dt.Rows.Add(dr1);
                gvdProcessDetails.DataSource = dt;
                gvdProcessDetails.DataBind();

                int CountProcessRow = gvdProcessDetails.Rows.Count;
                hndProDeleteButton.Value = CountProcessRow.ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox txtPItems = (TextBox)gvdProcessDetails.Rows[i].FindControl("txtPItems");
                    TextBox txtFromStatus = (TextBox)gvdProcessDetails.Rows[i].FindControl("txtFromStatus");
                    TextBox txtToStatus = (TextBox)gvdProcessDetails.Rows[i].FindControl("txtToStatus");
                    TextBox lblTotalAmount = (TextBox)gvdProcessDetails.Rows[i].FindControl("lblTotalAmount");
                    TextBox txtRate = (TextBox)gvdProcessDetails.Rows[i].FindControl("txtRate");
                    TextBox txtWastage = (TextBox)gvdProcessDetails.Rows[i].FindControl("txtWastage");

                    txtPItems.Text = dt.Rows[i]["Item"].ToString();
                    txtFromStatus.Text = dt.Rows[i]["FromStatus"].ToString();
                    txtToStatus.Text = dt.Rows[i]["ToStatus"].ToString();
                    lblTotalAmount.Text = dt.Rows[i]["Amount"].ToString();
                    txtRate.Text = dt.Rows[i]["Rate"].ToString();
                    txtWastage.Text = dt.Rows[i]["Wastage"].ToString();

                }
                decimal a = 0;
                decimal TotalAmount = dt.AsEnumerable().Where(r => decimal.TryParse(r.Field<string>("Amount"), out a)).Sum(r => a);
                lblTotalAmountD.Text = TotalAmount.ToString("0.00");


            }
            catch
            {

            }
        }

        protected void ProcessimgBtndelete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GridViewRow gdvrow1 = (GridViewRow)(((Control)sender).NamingContainer);

                TextBox txtItemsMain = (TextBox)gdvrow1.FindControl("txtPItems");
                string delProcess = hdnDeleteProcess.Value.ToString();
                if (delProcess == "")
                {
                    delProcess = txtItemsMain.Text.Trim();
                }
                else
                {
                    delProcess = delProcess + "!!!!!" + txtItemsMain.Text.Trim();
                }
                hdnDeleteProcess.Value = delProcess;

                DataTable dt = CreateProcessTable();
                foreach (GridViewRow gdvrow in gvdProcessDetails.Rows)
                {
                    HiddenField hdnValueAdditionID = (HiddenField)gdvrow.FindControl("hdnValueAdditionID");
                    TextBox txtPItems = (TextBox)gdvrow.FindControl("txtPItems");
                    TextBox txtFromStatus = (TextBox)gdvrow.FindControl("txtFromStatus");
                    TextBox txtToStatus = (TextBox)gdvrow.FindControl("txtToStatus");
                    TextBox lblTotalAmount = (TextBox)gdvrow.FindControl("lblTotalAmount");
                    HiddenField hdnCostingVAWastage = (HiddenField)gdvrow.FindControl("hdnCostingVAWastage");
                    TextBox txtRate = (TextBox)gdvrow.FindControl("txtRate");
                    TextBox txtWastage = (TextBox)gdvrow.FindControl("txtWastage");

                    DataRow dr = dt.NewRow();
                    dr[0] = gvdProcessDetails.DataKeys[gdvrow.RowIndex].Value;
                    dr[1] = hdnValueAdditionID.Value;
                    dr[2] = txtPItems.Text;
                    dr[3] = txtFromStatus.Text;
                    dr[4] = txtToStatus.Text;
                    dr[5] = lblTotalAmount.Text;
                    dr[6] = hdnCostingVAWastage.Value;
                    dr[7] = txtRate.Text;
                    dr[8] = txtWastage.Text;
                    dt.Rows.Add(dr);
                }

                dt.Rows[gdvrow1.RowIndex].Delete();
                if (dt.Rows.Count > 0)
                {
                    gvdProcessDetails.DataSource = dt;
                    gvdProcessDetails.DataBind();
                }
                else
                {
                    //DataRow dr = dt.NewRow();
                    //dr[0] = "";
                    //dr[1] = "";
                    //dr[2] = "";
                    //dr[3] = "";
                    //dr[4] = "";
                    //dr[5] = "";
                    //dr[6] = "";
                    //dr[7] = "";
                    //dr[8] = "";
                    //dt.Rows.Add(dr);
                    gvdProcessDetails.DataSource = null;// dt;
                    gvdProcessDetails.DataBind();
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox txtPItems = (TextBox)gvdProcessDetails.Rows[i].FindControl("txtPItems");
                    TextBox txtFromStatus = (TextBox)gvdProcessDetails.Rows[i].FindControl("txtFromStatus");
                    TextBox txtToStatus = (TextBox)gvdProcessDetails.Rows[i].FindControl("txtToStatus");
                    TextBox lblTotalAmount = (TextBox)gvdProcessDetails.Rows[i].FindControl("lblTotalAmount");
                    TextBox txtRate = (TextBox)gvdProcessDetails.Rows[i].FindControl("txtRate");
                    TextBox txtWastage = (TextBox)gvdProcessDetails.Rows[i].FindControl("txtWastage");

                    txtPItems.Text = dt.Rows[i]["Item"].ToString();
                    txtFromStatus.Text = dt.Rows[i]["FromStatus"].ToString();
                    txtToStatus.Text = dt.Rows[i]["ToStatus"].ToString();
                    lblTotalAmount.Text = dt.Rows[i]["Amount"].ToString();
                    txtRate.Text = dt.Rows[i]["Rate"].ToString();
                    txtWastage.Text = dt.Rows[i]["Wastage"].ToString();
                }

                int CountProcessRow = gvdProcessDetails.Rows.Count;
                hndProDeleteButton.Value = CountProcessRow.ToString();
                decimal a = 0, b = 0;
                decimal TotalAmount = dt.AsEnumerable().Where(r => decimal.TryParse(r.Field<string>("Amount"), out a)).Sum(r => a);
                decimal TotalCostingVAWastage = dt.AsEnumerable().Where(r => decimal.TryParse(r.Field<string>("CostingVAWastage"), out b)).Sum(r => b);
                lblTotalAmountD.Text = TotalAmount.ToString("0.00");
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "TotalProcessAmountFromServer(" + TotalAmount + "," + TotalCostingVAWastage + ")", true);
            }
            catch
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)//GC
        {


            string script = string.Empty;

            for (int i = 1; i <= 8; i++)
            {
                string febricType = "";
                TextBox txtFabric = tblCostingDetails.FindControl("txtFabric" + i) as TextBox;
                DropDownList ddlFebType = tblCostingDetails.FindControl("DDLFabricType" + i) as DropDownList;
                if (i == 1)
                {
                    febricType = txtFabricType1.Value.ToString().Trim();
                }
                else if (i == 2)
                {
                    febricType = txtFabricType2.Value.ToString().Trim();
                }
                else if (i == 3)
                {
                    febricType = txtFabricType3.Value.ToString().Trim();
                }
                else if (i == 4)
                {
                    febricType = txtFabricType4.Value.ToString().Trim();
                }
                else if (i == 5)
                {
                    febricType = txtFabricType5.Value.ToString().Trim();
                }
                else if (i == 6)
                {
                    febricType = txtFabricType6.Value.ToString().Trim();
                }
                else if (i == 7)
                {
                    febricType = txtFabricType7.Value.ToString().Trim();
                }
                else if (i == 8)
                {
                    febricType = txtFabricType8.Value.ToString().Trim();
                }

                if (txtFabric.Text != "")
                {
                    DataSet ds = this.CostingControllerInstanceNew.GetRegisterFabric_Details(txtFabric.Text.Trim());
                    if (ddlFebType.SelectedValue.ToString() == "3" || ddlFebType.SelectedValue.ToString() == "4")
                    {
                        string[] Print = febricType.Split(new[] { " --- " }, StringSplitOptions.None);
                        if (Print.Length > 1)
                        {
                            DataSet ds1 = this.CostingControllerInstanceNew.GetRegisterPrint_Details(Print[1].Trim());
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                            }
                            else
                            {
                                divConfirmBox.Visible = false;
                                script = "ShowHideValidationBox(true, 'Please fill registered Print for fabric " + i + ".', 'Costing Sheet');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                                return;
                            }
                        }
                        else
                        {
                            divConfirmBox.Visible = false;
                            script = "ShowHideValidationBox(true, 'Please fill registered Print for fabric " + i + ".', 'Costing Sheet');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                            return;
                        }
                    }
                }
            }

            for (int p = 0; p < gvdProcessDetails.Rows.Count; p++)
            {
                TextBox txtItems = gvdProcessDetails.Rows[p].FindControl("txtPItems") as TextBox;
                if (txtItems.Text != "")
                {
                    string item = txtItems.Text.Trim();
                    DataSet ds = this.CostingControllerInstanceNew.GetRegisterProcess_Details(item);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        divConfirmBox.Visible = false;
                        script = "ShowHideValidationBox(true, 'Please fill registered Process item for Process item " + (p + 1) + ".', 'Costing Sheet');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                        return;
                    }
                }
            }

            if (SaveCostingData("BIPL"))
            {
                string url = COSTING_SHEET_URL + "?cid=" + CostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();
                Response.Redirect(url, false);
                SetMsg("success", "Costing Sheet Saved Successfully.");
            }
            else
            {
                divConfirmBox.Visible = false;
                ShowMsg("error", "Some error occurred in saving Costing Sheet.");
            }

        }

        protected void btnCostConfirmation_Click(object sender, EventArgs e)
        {
            string script = string.Empty;

            try
            {
                if (SaveCostingData("CostConfirmation"))
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

                    // lblMsg.Text = "Costing Confirmation Request sent successfully.";
                    // lblMsg.ForeColor = System.Drawing.Color.Green;

                    // var script_success = "ShowHideMessageBox(true, '" + "Costing Confirmation Request sent successfully." + "');";
                    // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);

                    ShowMsg("success", "Costing Confirmation Request sent successfully.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        protected void btnBIPLUpdatePrice_Click(object sender, EventArgs e)
        {
            string script = string.Empty;

            try
            {
                FLAG = 1;

                // if (SaveCostingData("BIPLUpdatePrice"))
                if (1 == 1)
                {
                    string orderIDList = this.CostingControllerInstanceNew.UpdateBIPLPriceOnOrders_New(this.CostingId);

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

                    DataTable DT = this.CostingControllerInstanceNew.Get_OrderDetailBy_StyleId_New(StyleID);
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
                    txtPriceAgreed.Text = txtPriceQuoted.Text;
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "$(function(){showBIPLOrderPrice('" + StyleID + "')});", true);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                divConfirmBox.Visible = false;
                // script = "ShowHideValidationBox(true, 'Some error occurred in updating BIPL Price.', 'Costing Sheet');";
                // ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                ShowMsg("error", "Some error occurred in updating BIPL Price.");
            }
        }

        protected void btniKandiUpdatePriceUpdatePrice_Click(object sender, EventArgs e)
        {
            string script = string.Empty;
            try
            {
                if (SaveCostingData("IkandiUpdatePrice"))
                {

                    string s = hdnConIds.Value;
                    string orderIDList = string.Empty;

                    //orderIDList = this.CostingControllerInstanceNew.UpdateiKandiPriceOnOrders_Old_New(this.CostingId, ckhAF.Checked, chkAH.Checked, ckhSF.Checked, ckhSH.Checked, ckhDC.Checked);

                    //if (ckhAF.Checked)
                    //    txtAFAgreedPrice.Text = txtAFQuotedPrice.Text;

                    //if (chkAH.Checked)
                    //    txtAHAgreedPrice.Text = txtAHQuotedPrice.Text;

                    //if (ckhSF.Checked)
                    //    txtSFAgreedPrice.Text = txtSFQuotedPrice.Text;

                    //if (ckhSH.Checked)
                    //    txtSHAgreedPrice.Text = txtSHQuotedPrice.Text;

                    //if (ckhDC.Checked)
                    //    txtDCAgreedPrice.Text = txtDCQuotedPrice.Text;
                    hdnConIds.Value = "";

                    //script = "showAffectedOrdersOnPriceUpdate('" + txtStyleNumber.Text + "','" + orderIDList + "')";

                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "startupscript", "$(function(){showIkandiBIPLOrderPrice('" + StyleID + "')});", true);

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                divConfirmBox.Visible = false;
                script = "ShowHideValidationBox(true, 'Some error occurred in updating BIPL Price.', 'Costing Sheet');";

                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            }
        }

        protected void btnCostConfirmed_Click(object sender, EventArgs e)
        {
            string script = string.Empty;

            try
            {
                if (SaveCostingData("CostConfirm"))
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
                    }
                    lblMsg.Text = "Costing Confirmed successfully.";
                    lblMsg.ForeColor = System.Drawing.Color.Green;

                }
                else
                {
                    divConfirmBox.Visible = false;
                    script = "ShowHideValidationBox(true, 'Some error occurred in updating BIPL Price.', 'Costing Sheet');";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                divConfirmBox.Visible = false;
                script = "ShowHideValidationBox(true, 'Some error occurred in confirming BIPL price.', 'Costing Sheet');";
            }
        }

        protected void btnSaveIkandi_Click(object sender, EventArgs e)
        {

            string script = string.Empty;
            for (int i = 1; i <= 8; i++)
            {
                string febricType = "";
                TextBox txtFabric = tblCostingDetails.FindControl("txtFabric" + i) as TextBox;
                DropDownList ddlFebType = tblCostingDetails.FindControl("DDLFabricType" + i) as DropDownList;
                if (i == 1)
                {
                    febricType = txtFabricType1.Value.ToString().Trim();
                }
                else if (i == 2)
                {
                    febricType = txtFabricType2.Value.ToString().Trim();
                }
                else if (i == 3)
                {
                    febricType = txtFabricType3.Value.ToString().Trim();
                }
                else if (i == 4)
                {
                    febricType = txtFabricType4.Value.ToString().Trim();
                }
                else if (i == 5)
                {
                    febricType = txtFabricType5.Value.ToString().Trim();
                }
                else if (i == 6)
                {
                    febricType = txtFabricType6.Value.ToString().Trim();
                }
                else if (i == 7)
                {
                    febricType = txtFabricType7.Value.ToString().Trim();
                }
                else if (i == 8)
                {
                    febricType = txtFabricType8.Value.ToString().Trim();
                }

                if (txtFabric.Text != "")
                {
                    DataSet ds = this.CostingControllerInstanceNew.GetRegisterFabric_Details(txtFabric.Text.Trim());
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //}
                    //else
                    //{
                    //    divConfirmBox.Visible = false;
                    //    script = "ShowHideValidationBox(true, 'Please fill registered fabric for fabric " + i + ".', 'Costing Sheet');";
                    //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                    //    return;
                    //}
                    if (ddlFebType.SelectedValue.ToString() == "3" || ddlFebType.SelectedValue.ToString() == "4")
                    {
                        string[] Print = febricType.Split(new[] { " --- " }, StringSplitOptions.None);
                        if (Print.Length > 1)
                        {
                            DataSet ds1 = this.CostingControllerInstanceNew.GetRegisterPrint_Details(Print[1].Trim());
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                            }
                            else
                            {
                                divConfirmBox.Visible = false;
                                script = "ShowHideValidationBox(true, 'Please fill registered Print for fabric " + i + ".', 'Costing Sheet');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                                return;
                            }
                        }
                        else
                        {
                            divConfirmBox.Visible = false;
                            script = "ShowHideValidationBox(true, 'Please fill registered Print for fabric " + i + ".', 'Costing Sheet');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                            return;
                        }
                    }
                }
                currencusymbol();//Add code by bharat feb-7
            }
            //for (int a = 0; a < gdvAccessory.Rows.Count; a++)
            //{
            //    TextBox txtItems = gdvAccessory.Rows[a].FindControl("txtItems") as TextBox;
            //    if (txtItems.Text != "")
            //    {
            //        string item = txtItems.Text.Trim();
            //        string[] items = item.Split('(');
            //        string itemVal = items[0];
            //        if (itemVal.Trim() == "TBD")
            //        {
            //            divConfirmBox.Visible = false;
            //            script = "ShowHideValidationBox(true, 'Please fill registered accessories  " + (a + 1) + " instead of TBD.', 'Costing Sheet');";
            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
            //            return;
            //        }
            //        else
            //        {
            //            DataSet ds = this.CostingControllerInstanceNew.GetRegisterAccessory_Details(itemVal.Trim());
            //            if (ds.Tables[0].Rows.Count > 0)
            //            {
            //            }
            //            else
            //            {
            //                divConfirmBox.Visible = false;
            //                script = "ShowHideValidationBox(true, 'Please fill registered Accessries for Accessries " + (a + 1) + ".', 'Costing Sheet');";
            //                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
            //                return;
            //            }
            //        }
            //    }
            //}
            for (int p = 0; p < gvdProcessDetails.Rows.Count; p++)
            {
                TextBox txtItems = gvdProcessDetails.Rows[p].FindControl("txtPItems") as TextBox;
                if (txtItems.Text != "")
                {
                    string item = txtItems.Text.Trim();
                    DataSet ds = this.CostingControllerInstanceNew.GetRegisterProcess_Details(item);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        divConfirmBox.Visible = false;
                        script = "ShowHideValidationBox(true, 'Please fill registered Process item for Process item " + (p + 1) + ".', 'Costing Sheet');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                        return;
                    }
                }
            }
            if (SaveCostingData("IKANDI"))
            {
                HiddenField hdnOpenCosting = tblCostingDetails.FindControl("hdnOpenCosting") as HiddenField;
                //string url = COSTING_SHEET_URL + "?cid=" + CostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();
                //script = "ShowHideMessageBox(true, 'Costing Sheet saved successfully.', 'Costing Sheet', RedirectToUrl, '" + url + "');";
                ////var script_success = "ShowHideMessageBox(true, '" + "Costing Sheet saved successfully." + "');";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                if (hdnOpenCosting.Value == "1")
                {
                    hdnOpenCosting.Value = "0";
                    this.CostingControllerInstanceNew.OpenCosing(StyleID, 1, ApplicationHelper.LoggedInUser.UserData.UserID);
                    //divConfirmBox.Attributes.Add("style", "display: block !important");

                }

                else
                {
                    hdnOpenCosting.Value = "0";
                    this.CostingControllerInstanceNew.OpenCosing(StyleID, 0, ApplicationHelper.LoggedInUser.UserData.UserID);

                    //divConfirmBox.Visible = false;
                    //script = "ShowHideValidationBox(true, 'Some error occurred in saving Costing Sheet.', 'Costing Sheet');";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);

                    //string url = COSTING_SHEET_URL + "?cid=" + CostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();
                    //script = "ShowHideMessageBox(true, 'Costing Sheet saved successfully.', 'Costing Sheet', RedirectToUrl, '" + url + "');";
                    //var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                }

                //string url = COSTING_SHEET_URL + "?cid=" + CostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();
                //script = "ShowHideMessageBox(true, 'Costing Sheet saved successfully.', 'Costing Sheet', RedirectToUrl, '" + url + "');";
                ////var script_success = "ShowHideMessageBox(true, '" + "Costing Sheet saved successfully." + "');";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                string url = COSTING_SHEET_URL + "?cid=" + CostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();
                //script = "ShowHideMessageBox(true, 'Costing Sheet saved successfully.', 'Costing Sheet', RedirectToUrl, '" + url + "');";
                //var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                //Page currentPage = (Page)HttpContext.Current.Handler;
                // lblsuccess.Attributes.Add("Style", "display: block;color:Green;");
                // lblsuccess.Text = "Costing Sheet saved successfully.";


                // string url = COSTING_SHEET_URL + "?cid=" + CostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();
                //script = "ShowHideMessageBox(true, 'Costing Sheet saved successfully.', 'Costing Sheet', RedirectToUrl, '" + url + "');";
                //var script_success = "ShowHideMessageBox(true, '" + "Information saved successfully." + "');";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                //Page currentPage = (Page)HttpContext.Current.Handler;
                // lblsuccess.Attributes.Add("Style", "display: block;color:Green;");
                // lblsuccess.Text = "Costing Sheet saved successfully.";


                SetMsg("success", "Costing Sheet saved successfully.");
                Response.Redirect(url);
            }
            else
            {
                //HiddenField hdnOpenCosting = FindControl("HiddenField") as HiddenField;
                divConfirmBox.Visible = false;
                //  script = "ShowHideValidationBox(true, 'Some error occurred in saving Costing Sheet.', 'Costing Sheet');";
                //  ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);

                SetMsg("error", "Some error occurred in saving Costing Sheet.");
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {
            Costing objCosting = new Costing();
            GetAgreeHistory(ref objCosting);
            if (this.CostingControllerInstanceNew.AgreeForIKandiCostingData_New(ChildCostingId, CostingId, ParentStyleId, objCosting))
            {
                string url = COSTING_SHEET_URL + "?cid=" + ChildCostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();
                Response.Redirect(url, false);
                SetMsg("success", "Costing sheet agreement accepted and saved successfully.");
            }
            else
            {
                ShowMsg("error", "Some error occurred in executing Agree operation.");
            }
        }


        public void GetAgreeHistory(ref Costing objCosting)
        {
            if (null == objCosting.CommetHistoryItems)
                objCosting.CommetHistoryItems = new List<CommentHistory>();

            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                       + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + " Costing Sheet" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Accept & Close by" + " " + "</span>"
                       + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToLower() + " " + "</span>"
                       + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "at " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + DateTime.Now.ToString("hh:mm tt") + "</span>";

            CommentHistory commenthistory = new CommentHistory();
            commenthistory.TypeFlag = 118;
            commenthistory.FieldName = "Accept Costing Sheet";
            commenthistory.OldValue = "";
            commenthistory.NewValue = "";
            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            commenthistory.UpdatedOn = DateTime.Now.ToString();
            commenthistory.DetailDescription = x;
            commenthistory.isBipl = true;
            commenthistory.isPriceQuote = true;

            objCosting.CommetHistoryItems.Add(commenthistory);
        }

        protected void btnDisagree_Click(object sender, EventArgs e)
        {
            string script = string.Empty;
            Costing objCosting = new Costing();
            GetDisagreeHistory(ref objCosting);
            if (this.CostingControllerInstanceNew.DisagreeForIKandiCostingData_New(ChildCostingId, CostingId, ParentStyleId, objCosting))
            {
                string url = COSTING_SHEET_URL + "?cid=" + CostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();
                script = "ShowHideMessageBox(true, 'Disagree operation executed successfully.', 'Costing Sheet', RedirectToUrl, '" + url + "');";
                lblMsg.Text = "Disagree operation executed successfully.";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                script = "ShowHideMessageBox(true, 'Some error occurred in executing Disagree operation.', 'Costing Sheet');";
            }
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
        }

        public void GetDisagreeHistory(ref Costing objCosting)
        {
            if (null == objCosting.CommetHistoryItems)
                objCosting.CommetHistoryItems = new List<CommentHistory>();

            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                       + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + " Costing Sheet" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Disagree by" + " " + "</span>"
                       + "<span style='font-size:10px !important; color:#000000;'>" + ApplicationHelper.LoggedInUser.UserData.FullName.ToLower() + " " + "</span>"
                       + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "at " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + DateTime.Now.ToString("hh:mm tt") + "</span>";

            CommentHistory commenthistory = new CommentHistory();
            commenthistory.TypeFlag = 119;
            commenthistory.FieldName = "Disagree Costing Sheet";
            commenthistory.OldValue = "";
            commenthistory.NewValue = "";
            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            commenthistory.UpdatedOn = DateTime.Now.ToString();
            commenthistory.DetailDescription = x;
            commenthistory.isBipl = true;
            commenthistory.isPriceQuote = true;

            objCosting.CommetHistoryItems.Add(commenthistory);
        }
        //protected void btnExportToExcel_Click(object sender, EventArgs e)
        //{
        //    Response.Clear();
        //    Response.AddHeader("content-disposition", "attachment;filename=CostingSheet.xls");
        //    Response.ContentType = "application/ms-excel";
        //    Response.Charset = "";
        //    Response.ContentEncoding = Encoding.Default;
        //    string str = hfexcelval.Value;
        //    str = str.Replace("~!", "<");
        //    str = str.Replace("!~", ">");
        //    str = str.Replace("DIRECT COST (+)", "");
        //    Response.Write(str);
        //    Response.End();
        //}

        protected void btnAcknowledgment_Click(object sender, EventArgs e)
        {
            int IsConfirm = WorkflowControllerInstance.Close_AcknowledgeTask(this.StyleID, TaskMode.Acknowledgement_Costing, ApplicationHelper.LoggedInUser.UserData.UserID);
            if (IsConfirm == 1)
            {
                lblMsg.Text = "Acknowledge Confirmed.";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
        }

        private bool SaveCostingData(string Type)
        {
            int result = 0;
            Costing objCosting = new Costing();
            objCosting.ClientID = int.TryParse(ddlBuyer.SelectedValue, out result) ? result : 0;
            if (objCosting.ClientID == 0)
                objCosting.ClientID = hdnbuyer.Value != null ? Convert.ToInt32(hdnbuyer.Value) : 0;

            if (hdnIsOrderConfirmed.Value == "1")
            {
                objCosting.DepartmentID = CostingObject.DepartmentID;
                objCosting.ParentDepartmentID = CostingObject.ParentDepartmentID;
            }
            else
            {
                objCosting.DepartmentID = int.TryParse(hdnDeptId.Value, out result) ? result : 0;
                objCosting.ParentDepartmentID = int.TryParse(hdnParentDeptId.Value, out result) ? result : 0;
            }
            objCosting.StyleID = int.TryParse(txtStyleId.Text, out result) ? result : 0;
            //objCosting.Quantity = int.TryParse(txtQuantity.Text, out result) ? result : 0;
            objCosting.Weight = int.TryParse(txtWeight.Text, out result) ? result : 0;
            objCosting.IsIkandiClient = Convert.ToInt32(hdnBuyingHouse.Text);
            //objCosting.IsBestSeller = chkIsBestSeller.Checked;
            objCosting.ExpectedQty = int.TryParse(ddlExpectedQty.SelectedValue, out result) ? result : 0;//abhishek
            objCosting.ExpectedQty = Convert.ToInt32(ddlExpectedQty.SelectedValue);
            objCosting.ParentCostingID = CostingId;
            objCosting.PrintIds = string.Empty;

            objCosting.PriceQuoted = Convert.ToDouble(txtPriceQuoted.Text == string.Empty ? "0" : txtPriceQuoted.Text);
            objCosting.AgreedPrice = Convert.ToDouble(txtPriceAgreed.Text == string.Empty ? "0" : txtPriceAgreed.Text);


            objCosting.FrieghtUptoFinalDestination = Convert.ToDouble(txtFrtUptoFinalDest.Text == string.Empty ? "0" : txtFrtUptoFinalDest.Text);
            //objCosting.FrieghtUptoPort = Convert.ToDouble(txtFrtUptoPort.Text == string.Empty ? "0" : txtFrtUptoPort.Text);

            objCosting.OverHead = Convert.ToDouble(txtOverHead.Text == string.Empty ? "0" : txtOverHead.Text);
            //objCosting.MakingType = ddlMaking.SelectedValue;
            objCosting.OB_WS = txtOB.Text == "" ? 0 : Convert.ToInt32(txtOB.Text);
            objCosting.SAM = txtChargesValue11.Text == "" ? 0 : Convert.ToDouble(txtChargesValue11.Text);
            objCosting.CMTF = txtChargesValue1.Text == "" ? 0 : Convert.ToDouble(txtChargesValue1.Text);
            objCosting.DesignCommission = Convert.ToDouble(txtDesingCommission.Text == string.Empty ? "0" : txtDesingCommission.Text);

            objCosting.ConvertTo = Convert.ToInt32(hdnConvertTo.Value);
            objCosting.MarkupOnUnitCTC = Convert.ToDouble(txtMarkupOnUnitCtc.Text == string.Empty ? "0.0" : txtMarkupOnUnitCtc.Text);
            objCosting.CommisionPercent = Convert.ToDouble(txtComm.Text == string.Empty ? "0.0" : txtComm.Text);
            objCosting.ConversionRate = Convert.ToDouble(txtConvRate.Text == string.Empty ? "0" : txtConvRate.Text);

            objCosting.CostingCutWastage = Convert.ToDouble(txtGCW.Text == string.Empty ? "0.0" : txtGCW.Text);
            objCosting.CostingVAWastage = Convert.ToDouble(txtGVW.Text == string.Empty ? "0.0" : txtGVW.Text);
            if (!string.IsNullOrEmpty(txtOverallComments.Text))
                objCosting.OverallComments = ApplicationHelper.LoggedInUser.UserData.FirstName + " ( " +
                                             DateTime.Today.ToString("dd MMM yy") + ") :" + txtOverallComments.Text;
            else
                objCosting.OverallComments = string.Empty;


            AddFabricCostings(ref objCosting);
            AddAccessoryCostings(ref objCosting);
            AddProcessCostings(ref objCosting);

            DeleteAccessoryCosting(ref objCosting);

            int statusid = 0;

            if (this.CostingObject != null)
                statusid = this.CostingObject.CurrentStatusID;

            if (Role == 1)
            {
                AddLandedCosting(ref objCosting);
                AddFOBPricing(ref objCosting);

                GetBIPLChangesHistory(ref objCosting);
                GetiKandiChangesHistory(ref objCosting);

                objCosting.iKandiChangesHistory = string.Empty;
                objCosting.BIPlChangesHistory = string.Empty;
            }
            else
            {
                GetBIPLChangesHistory(ref objCosting);
                objCosting.BIPlChangesHistory = string.Empty;
                objCosting.iKandiChangesHistory = string.Empty;
            }

            bool isDiffernt = false;
            if (Role == 1 && ParentCostingId <= 0)
            {
                isDiffernt = IsDifferent(objCosting);
            }
            if (isDiffernt == false)
            {
                if (Role == 1 && ParentCostingId <= 0)
                {
                    isDiffernt = IsDifferent_ForIkandiUser(objCosting);
                }
            }

            objCosting.isDiffernt = isDiffernt;

            DateTime dt = DateTime.Now;
            string s = String.Format("{0:G}", dt);
            s = s.Replace(" ", "_");
            s = s.Replace(':', '/');
            s = s.Replace('/', '-');
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
                // updateFabQuality();

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
                return this.CostingControllerInstanceNew.UpdateCosting_New(objCosting, Role, Type);
            }

            objCosting.iKandiChangesHistory = CostingObject.iKandiChangesHistory + string.Empty;

            objCosting.BIPlChangesHistory = CostingObject.BIPlChangesHistory + string.Empty;

            objCosting.OverallComments = lblOverallCommentsHistory.Text + "$$" + objCosting.OverallComments;

            //if (CostingId==-1)
            CostingId = this.CostingControllerInstanceNew.InsertCosting_New(objCosting, Role, Type);


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

        private bool IsDifferent(Costing objCosting)
        {
            CostingCollection lObjCostingCollection = this.CostingControllerInstanceNew.GetCosting_New(CostingId);

            if (lObjCostingCollection.Count == 0 || lObjCostingCollection.Count > 1)
            {
                return false;
            }
            Costing lObjCosting = lObjCostingCollection[0];

            int i = 0;
            FabricCosting newFabricCosting = null;
            FabricCosting oldFabricCosting = null;

            for (i = 0; i < 8; i++)
            {
                newFabricCosting = null;
                oldFabricCosting = null;

                if (objCosting.FabricCostingItems != null && objCosting.FabricCostingItems.Count > 0)
                {
                    newFabricCosting = objCosting.FabricCostingItems.Find(delegate(FabricCosting FC) { return FC.SequenceNumber == (i + 1); });
                }

                if (CostingObject.FabricCostingItems != null && CostingObject.FabricCostingItems.Count > 0)
                {
                    oldFabricCosting = CostingObject.FabricCostingItems.Find(delegate(FabricCosting FC) { return FC.SequenceNumber == (i + 1); });
                }

                if (oldFabricCosting == null && newFabricCosting != null)
                {
                    if (newFabricCosting.Fabric != null && newFabricCosting.Fabric.Trim() != string.Empty)
                    {
                        return true;
                    }
                    if (newFabricCosting.FabricType != null && newFabricCosting.FabricType.Trim() != string.Empty)
                    {
                        return true;
                    }
                    if (newFabricCosting.Average != 0)
                    {
                        return true;
                    }
                    if (newFabricCosting.Rate != 0)
                    {
                        return true;
                    }
                }

                if (oldFabricCosting != null && newFabricCosting == null)
                {
                    if (oldFabricCosting.Fabric != null && oldFabricCosting.Fabric.Trim() != string.Empty)
                    {
                        return true;
                    }
                    if (oldFabricCosting.FabricType != null && oldFabricCosting.FabricType.Trim() != string.Empty)
                    {
                        return true;
                    }
                    if (oldFabricCosting.Average != 0)
                    {
                        return true;
                    }
                    if (oldFabricCosting.Rate != 0)
                    {
                        return true;
                    }
                }

                if (oldFabricCosting != null && newFabricCosting != null)
                {
                    if (newFabricCosting.Fabric.Trim().ToLower() != oldFabricCosting.Fabric.Trim().ToLower())
                    {
                        return true;
                    }
                    if (newFabricCosting.FabricType.Trim().ToLower() != oldFabricCosting.FabricType.Trim().ToLower())
                    {
                        return true;
                    }
                    if (oldFabricCosting.Average != newFabricCosting.Average)
                    {
                        return true;
                    }
                    if (oldFabricCosting.Rate != newFabricCosting.Rate)
                    {
                        return true;//code commented by bharat on 27-Oct-2020
                    }
                }
                if ((lObjCosting.FabricCostingItems.Count > i) && (objCosting.FabricCostingItems.Count > i))
                {
                    if (lObjCosting.FabricCostingItems[i].ValueAdditionId1 != objCosting.FabricCostingItems[i].ValueAdditionId1)
                    {
                        return true;
                    }
                    if (lObjCosting.FabricCostingItems[i].ValueAdditionId2 != objCosting.FabricCostingItems[i].ValueAdditionId2)
                    {
                        return true;
                    }
                    if (lObjCosting.FabricCostingItems[i].VAWastage1 != objCosting.FabricCostingItems[i].VAWastage1)
                    {
                        return true;
                    }
                    if (lObjCosting.FabricCostingItems[i].VAWastage2 != objCosting.FabricCostingItems[i].VAWastage2)
                    {
                        return true;
                    }
                    if (lObjCosting.FabricCostingItems[i].VARate1 != objCosting.FabricCostingItems[i].VARate1)
                    {
                        return true;
                    }
                    if (lObjCosting.FabricCostingItems[i].VARate2 != objCosting.FabricCostingItems[i].VARate2)
                    {
                        return true;
                    }
                }

            }
            //end Fabric

            if (objCosting.OB_WS != CostingObject.OB_WS)
            {
                return true;
            }
            if (objCosting.SAM != CostingObject.SAM)
            {
                return true;
            }
            if (objCosting.CMTF != CostingObject.CMTF)
            {
                return true;
            }

            i = 0;

            Accessories newAccessories = null;
            Accessories oldAccessories = null;

            for (i = 0; i < gdvAccessory.Rows.Count; i++)
            {
                newAccessories = null;
                oldAccessories = null;

                if (objCosting.AccessoryItems != null && objCosting.AccessoryItems.Count > 0)
                {
                    newAccessories = objCosting.AccessoryItems.Find(delegate(Accessories ACC) { return ACC.SequenceNumber == (i + 1); });
                }

                if (CostingObject.AccessoryItems != null && CostingObject.AccessoryItems.Count > 0)
                {
                    oldAccessories = CostingObject.AccessoryItems.Find(delegate(Accessories ACC) { return ACC.SequenceNumber == (i + 1); });
                }

                if (oldAccessories == null && newAccessories != null)
                {
                    if (!string.IsNullOrEmpty(newAccessories.Item))
                    {
                        return true;
                    }

                    if (newAccessories.Rate != 0)
                    {
                        return true;
                    }
                }

                if (oldAccessories != null && newAccessories != null)
                {
                    if (!string.IsNullOrEmpty(oldAccessories.Item) && !string.IsNullOrEmpty(newAccessories.Item) && oldAccessories.Item.Trim().ToLower() != newAccessories.Item.Trim().ToLower())
                    {
                        return true;
                    }

                    if (newAccessories.Rate != oldAccessories.Rate)
                    {
                        return true;
                    }
                }

            }
            //End Accessories.

            i = 0;

            Processes newProcesses = null;
            Processes oldProcesses = null;

            for (i = 0; i < gvdProcessDetails.Rows.Count; i++)
            {
                newProcesses = null;
                oldProcesses = null;

                if (objCosting.ProcessItems != null && objCosting.ProcessItems.Count > 0)
                {
                    newProcesses = objCosting.ProcessItems.Find(delegate(Processes PC) { return PC.SeqNo == (i + 1); });
                }

                if (CostingObject.ProcessItems != null && CostingObject.ProcessItems.Count > 0)
                {
                    oldProcesses = CostingObject.ProcessItems.Find(delegate(Processes PC) { return PC.SeqNo == (i + 1); });
                }

                if (oldProcesses == null && newProcesses != null)
                {
                    if (!string.IsNullOrEmpty(newProcesses.Item))
                    {
                        return true;
                    }

                    if (newProcesses.Amount != 0)
                    {
                        return true;
                    }
                }

                if (oldProcesses != null && newProcesses != null)
                {
                    if (!string.IsNullOrEmpty(oldProcesses.Item) && !string.IsNullOrEmpty(newProcesses.Item) && oldProcesses.Item.ToLower() != newProcesses.Item.ToLower())
                    {
                        return true;
                    }

                    if (newProcesses.Amount != oldProcesses.Amount)
                    {
                        return true;
                    }
                }

            }
            //End Process.

            if (objCosting.FrieghtUptoFinalDestination != CostingObject.FrieghtUptoFinalDestination)
            {
                return true;// code commented by Bharat on 27-Oct-2020
            }
            if (objCosting.CostingCutWastage != CostingObject.CostingCutWastage)
            {
                return true;// code commented by Bharat on 27-Oct-2020
            }
            if (objCosting.CostingVAWastage != CostingObject.CostingVAWastage)
            {
                return true;// code commented by Bharat on 27-Oct-2020
            }
            if (objCosting.OverHead != CostingObject.OverHead)
            {
                return true;// code commented by Bharat on 27-Oct-2020
            }
            if (objCosting.ConversionRate != CostingObject.ConversionRate)
            {
                return true;// code commented by Bharat on 27-Oct-2020
            }
            if (objCosting.MarkupOnUnitCTC != CostingObject.MarkupOnUnitCTC)
            {
                return true;// code commented by Bharat on 27-Oct-2020
            }
            if (objCosting.CommisionPercent != CostingObject.CommisionPercent)
            {
                return true;// code commented by Bharat on 27-Oct-2020
            }
            if (objCosting.PriceQuoted != CostingObject.PriceQuoted)
            {
                return true;// code commented by Bharat on 27-Oct-2020
            }

            return false;
        }
        private bool IsDifferent_ForIkandiUser(Costing objCosting)
        {
            CostingCollection lObjCostingCollection = this.CostingControllerInstanceNew.GetCosting_New(CostingId);

            if (lObjCostingCollection.Count == 0 || lObjCostingCollection.Count > 1)
            {
                return false;
            }
            Costing lObjCosting = lObjCostingCollection[0];


            if (lObjCosting.FabricCostingItems.Count != objCosting.FabricCostingItems.Count)
            {
                return true;
            }
            if (lObjCosting.AccessoryItems.Count != objCosting.AccessoryItems.Count)
            {
                return true;
            }
            if (lObjCosting.ProcessItems.Count != objCosting.ProcessItems.Count)
            {
                return true;
            }

            return false;
        }

        private void AddFabricCostings(ref Costing objCosting)
        {
            if (null == objCosting.FabricCostingItems)
                objCosting.FabricCostingItems = new List<FabricCosting>();

            int j = 1;

            for (int i = 1; i <= 8; i++)
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
                //Image img = tblCostingDetails.FindControl("imgFab" + i) as Image;
                FileUpload UploadLayFile = tblCostingDetails.FindControl("LayFile" + i) as FileUpload;
                HyperLink lnkLayFile = tblCostingDetails.FindControl("viewolay" + i) as HyperLink;
                HyperLink ViewCad = tblCostingDetails.FindControl("ViewCad" + i) as HyperLink;
                HyperLink ViewStc = tblCostingDetails.FindControl("ViewStc" + i) as HyperLink;
                DropDownList DDLFabricType = tblCostingDetails.FindControl("DDLFabricType" + i) as DropDownList;
                HiddenField hdnFabricID = tblCostingDetails.FindControl("hdnFabricID" + i) as HiddenField;
                TextBox lblRS = tblCostingDetails.FindControl("lblRS" + i) as TextBox;
                HiddenField hdnDyedRate = tblCostingDetails.FindControl("hdnDyedRate" + i) as HiddenField;
                HiddenField hdnPrintRate = tblCostingDetails.FindControl("hdnPrintRate" + i) as HiddenField;
                HiddenField hdnDigitalPrintRate = tblCostingDetails.FindControl("hdnDigitalPrintRate" + i) as HiddenField;

                HiddenField hdnValueAdditionId1 = tblCostingDetails.FindControl("hdnValueAdditionId" + i + "_1") as HiddenField;
                HiddenField hdnValueAdditionId2 = tblCostingDetails.FindControl("hdnValueAdditionId" + i + "_2") as HiddenField;

                TextBox txtVAWastage1 = tblCostingDetails.FindControl("txtVAWastage" + i + "_1") as TextBox;
                TextBox txtVAWastage2 = tblCostingDetails.FindControl("txtVAWastage" + i + "_2") as TextBox;

                TextBox txtVARate1 = tblCostingDetails.FindControl("txtVARate" + i + "_1") as TextBox;
                TextBox txtVARate2 = tblCostingDetails.FindControl("txtVARate" + i + "_2") as TextBox;

                HiddenField hdnCOUNTCON;
                HiddenField hdnGSML;
                Label COUNTCON;
                Label GSML;
                if (i == 1)
                {
                    hdnCOUNTCON = tblCostingDetails.FindControl("hdnCOUNTCON") as HiddenField;
                    hdnGSML = tblCostingDetails.FindControl("hdnGSML") as HiddenField;

                    COUNTCON = tblCostingDetails.FindControl("COUNTCON") as Label;
                    GSML = tblCostingDetails.FindControl("GSML") as Label;
                }
                else
                {
                    hdnCOUNTCON = tblCostingDetails.FindControl("hdnCOUNTCON" + i) as HiddenField;
                    hdnGSML = tblCostingDetails.FindControl("hdnGSML" + i) as HiddenField;
                    COUNTCON = tblCostingDetails.FindControl("COUNTCON" + i) as Label;
                    GSML = tblCostingDetails.FindControl("GSML" + i) as Label;
                }


                // if (ddlPrintType.SelectedIndex > 0 && txtFabric.Text.Trim() != string.Empty)
                // Print type Conditional is removed by sanjeev on 11/04/2022
                if (txtFabric.Text.Trim() != string.Empty)
                {
                    FabricCosting objFabricCosting = new FabricCosting();
                    objFabricCosting.CostingQueryType = QueryType.Insert;
                    objFabricCosting.PrintType = ddlPrintType.SelectedValue;

                    var txtFab = txtFabric.Text.Trim().Split('{');
                    objFabricCosting.Fabric = txtFab[0].Trim();
                    if (txtFab.Length > 1)
                        objFabricCosting.SupplierName = txtFab[1].Trim().Replace("}", "");

                    if (i == 1)
                    {
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

                        //objFabricCosting.GSM = (GSML.Text == string.Empty) ? 0 : Convert.ToDouble(GSML.Text);

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

                        //objFabricCosting.GSM= (GSML2.Text == string.Empty) ? 0 : Convert.ToDouble(GSML2.Text);
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
                        //objFabricCosting.GSM = (GSML3.Text == string.Empty) ? 0 : Convert.ToDouble(GSML3.Text);
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
                        //objFabricCosting.GSM = (GSML4.Text == string.Empty) ? 0 : Convert.ToDouble(GSML4.Text);
                    }
                    if (i == 5)
                    {
                        if (txtFabricType5.Value.Contains(" --- "))
                        {
                            string str = txtFabricType5.Value.Replace(" --- ", "#");
                            string[] s1 = str.Split('#');
                            objFabricCosting.FabricType = s1[1];
                        }
                        else if (txtFabricType5.Value.Contains("("))
                        {
                            string[] s1 = txtFabricType5.Value.Split('(');
                            objFabricCosting.FabricType = s1[0];
                        }
                        else
                            objFabricCosting.FabricType = txtFabricType5.Value;
                        //objFabricCosting.GSM = (GSML4.Text == string.Empty) ? 0 : Convert.ToDouble(GSML4.Text);
                    }
                    if (i == 6)
                    {
                        if (txtFabricType6.Value.Contains(" --- "))
                        {
                            string str = txtFabricType6.Value.Replace(" --- ", "#");
                            string[] s1 = str.Split('#');
                            objFabricCosting.FabricType = s1[1];
                        }
                        else if (txtFabricType6.Value.Contains("("))
                        {
                            string[] s1 = txtFabricType6.Value.Split('(');
                            objFabricCosting.FabricType = s1[0];
                        }
                        else
                            objFabricCosting.FabricType = txtFabricType6.Value;
                        //objFabricCosting.GSM = (GSML4.Text == string.Empty) ? 0 : Convert.ToDouble(GSML4.Text);
                    }
                    if (i == 7)
                    {
                        if (txtFabricType7.Value.Contains(" --- "))
                        {
                            string str = txtFabricType7.Value.Replace(" --- ", "#");
                            string[] s1 = str.Split('#');
                            objFabricCosting.FabricType = s1[1];
                        }
                        else if (txtFabricType7.Value.Contains("("))
                        {
                            string[] s1 = txtFabricType7.Value.Split('(');
                            objFabricCosting.FabricType = s1[0];
                        }
                        else
                            objFabricCosting.FabricType = txtFabricType7.Value;
                        //objFabricCosting.GSM = (GSML4.Text == string.Empty) ? 0 : Convert.ToDouble(GSML4.Text);
                    }
                    if (i == 8)
                    {
                        if (txtFabricType8.Value.Contains(" --- "))
                        {
                            string str = txtFabricType8.Value.Replace(" --- ", "#");
                            string[] s1 = str.Split('#');
                            objFabricCosting.FabricType = s1[1];
                        }
                        else if (txtFabricType8.Value.Contains("("))
                        {
                            string[] s1 = txtFabricType8.Value.Split('(');
                            objFabricCosting.FabricType = s1[0];
                        }
                        else
                            objFabricCosting.FabricType = txtFabricType8.Value;
                    }

                    objFabricCosting.ValueAdditionId1 = Convert.ToInt32(hdnValueAdditionId1.Value);
                    objFabricCosting.ValueAdditionId2 = Convert.ToInt32(hdnValueAdditionId2.Value);
                    objFabricCosting.VAWastage1 = (txtVAWastage1.Text == string.Empty) ? 0 : Convert.ToDouble(txtVAWastage1.Text.Split('%')[0].Trim());
                    objFabricCosting.VAWastage2 = (txtVAWastage2.Text == string.Empty) ? 0 : Convert.ToDouble(txtVAWastage2.Text.Split('%')[0].Trim());
                    objFabricCosting.VARate1 = (txtVARate1.Text == string.Empty) ? 0 : Convert.ToDouble(txtVARate1.Text);
                    objFabricCosting.VARate2 = (txtVARate2.Text == string.Empty) ? 0 : Convert.ToDouble(txtVARate2.Text);

                    objFabricCosting.Width = (txtWidth.Text == string.Empty) ? 0 : Convert.ToDouble(txtWidth.Text);
                    objFabricCosting.Average = (txtAverage.Text == string.Empty) ? 0 : Convert.ToDouble(txtAverage.Text);
                    objFabricCosting.Rate = (txtRate.Text == string.Empty) ? 0 : Convert.ToDouble(txtRate.Text);
                    objFabricCosting.Amount = (txtAmount.Text == string.Empty) ? 0 : Convert.ToDouble(txtAmount.Text);
                    objFabricCosting.Total = (txtTotal.Text == string.Empty) ? 0 : Convert.ToDouble(txtTotal.Text);
                    objFabricCosting.IsAir = (hdnIsAir.Value == "1") ? true : false;
                    objFabricCosting.SequenceNumber = j;

                    objFabricCosting.FabTypeId = DDLFabricType.SelectedValue;
                    objFabricCosting.FabricQualityId = hdnFabricID.Value;
                    objFabricCosting.DyedRate = Convert.ToDouble(hdnDyedRate.Value.ToString());
                    //objFabricCosting.PrintRate = Convert.ToDouble(hdnPrintRate.Value.ToString());
                    //objFabricCosting.DigitalPrintRate = Convert.ToDouble(hdnDigitalPrintRate.Value.ToString());
                    objFabricCosting.CostWidth = (txtWidth.Text == string.Empty) ? 0 : Convert.ToDouble(txtWidth.Text);
                    objFabricCosting.GSM = (hdnGSML.Value == string.Empty) ? 0 : Convert.ToDouble(hdnGSML.Value);
                    objFabricCosting.CountConstruct = hdnCOUNTCON.Value.Trim();
                    objFabricCosting.ResidualShrinkage = (lblRS.Text == string.Empty) ? 0 : Convert.ToDouble(lblRS.Text);
                    COUNTCON.Text = hdnCOUNTCON.Value.Trim();
                    GSML.Text = "&nbsp;(" + hdnGSML.Value.ToString() + ")";
                    txtIkandiStyle.Text = txtStyleNumber.Text;

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
                    j++;
                }
            }
        }

        private void AddAccessoryCostings(ref Costing objCosting)
        {
            if (null == objCosting.AccessoryItems)
                objCosting.AccessoryItems = new List<Accessories>();

            int i = 1;

            foreach (GridViewRow gdvrow in gdvAccessory.Rows)
            {
                Accessories objAccessories = new Accessories();

                HiddenField hdnID = (HiddenField)gdvrow.FindControl("hdnID");
                TextBox txtItems = (TextBox)gdvrow.FindControl("txtItems");
                TextBox txtUnitQty = (TextBox)gdvrow.FindControl("txtUnitQty");
                TextBox txtRate = (TextBox)gdvrow.FindControl("txtRate");
                TextBox lblWastage = (TextBox)gdvrow.FindControl("lblWastage");
                HiddenField hdnIsDefaultAccessory = (HiddenField)gdvrow.FindControl("hdnIsDefaultAccessory");

                var item = "";
                if (hdnID.Value == "15001" || hdnID.Value == "15002" || hdnID.Value == "15003" || hdnID.Value == "15004" || hdnID.Value == "15005")
                    item = txtItems.Text.Trim();
                else
                {
                    var txtItem = txtItems.Text.Trim().Split('{');
                    item = txtItem[0].Trim();
                }
                objAccessories.Item = item;
                objAccessories.AccessoryQualityID = hdnID.Value;
                objAccessories.IsDefaultAccessory = hdnIsDefaultAccessory.Value == null ? 0 : Convert.ToInt32(hdnIsDefaultAccessory.Value);
                objAccessories.Quantity = (txtUnitQty.Text == string.Empty) ? 0 : (txtUnitQty.Text == "." ? 0 : Convert.ToDouble(txtUnitQty.Text));
                objAccessories.Rate = (txtRate.Text == string.Empty) ? 0 : (txtRate.Text == "." ? 0 : Convert.ToDouble(txtRate.Text));
                objAccessories.Wastage = (lblWastage.Text == string.Empty) ? 0 : Convert.ToDouble(lblWastage.Text);
                objAccessories.SequenceNumber = i;
                objCosting.AccessoryItems.Add(objAccessories);

                i++;
            }
        }

        private void DeleteAccessoryCosting(ref Costing objCosting)
        {
            if (ViewState["dtDeleteAccess"] != null)
            {
                if (null == objCosting.DeleteAccessoriesItem)
                    objCosting.DeleteAccessoriesItem = new List<DeleteAccessoris>();

                DataTable dtDeleteAccess = (DataTable)ViewState["dtDeleteAccess"];
                foreach (DataRow dr in dtDeleteAccess.Rows)
                {
                    DeleteAccessoris objAccess = new DeleteAccessoris();

                    //objAccess.AccessoryQualitySizeID = Convert.ToInt32(dr["AccessoryQualityID"]);
                    objAccess.AccessoryQualitySizeID = dr["AccessoryQualityID"].ToString() == "" ? 0 : Convert.ToInt32(dr["AccessoryQualityID"]);
                    objAccess.AccessoryName = dr["Item"].ToString();
                    objAccess.AccessoryMasterId = Convert.ToInt32(dr["AccessoryID"]);

                    objCosting.DeleteAccessoriesItem.Add(objAccess);
                }
            }
        }

        private void AddProcessCostings(ref Costing objCosting)
        {
            if (null == objCosting.ProcessItems)
                objCosting.ProcessItems = new List<Processes>();
            int i = 1;
            foreach (GridViewRow gdvrow in gvdProcessDetails.Rows)
            {
                Processes objProcesses = new Processes();

                HiddenField hdnValueAdditionID = (HiddenField)gdvrow.FindControl("hdnValueAdditionID");
                TextBox txtPItems = (TextBox)gdvrow.FindControl("txtPItems");
                TextBox txtFromStatus = (TextBox)gdvrow.FindControl("txtFromStatus");
                TextBox txtToStatus = (TextBox)gdvrow.FindControl("txtToStatus");
                TextBox lblTotalAmount = (TextBox)gdvrow.FindControl("lblTotalAmount");
                TextBox txtRate = (TextBox)gdvrow.FindControl("txtRate");
                TextBox txtWastage = (TextBox)gdvrow.FindControl("txtWastage");

                if (txtPItems.Text != string.Empty)
                {
                    objProcesses.ValueAdditionID = hdnValueAdditionID.Value;
                    objProcesses.Item = txtPItems.Text;
                    objProcesses.FromStatus = txtFromStatus.Text;
                    objProcesses.ToStatus = txtToStatus.Text;
                    objProcesses.Amount = (lblTotalAmount.Text == string.Empty) ? 0 : Convert.ToDouble(lblTotalAmount.Text);
                    objProcesses.Rate = (txtRate.Text == string.Empty) ? 0 : Convert.ToDouble(txtRate.Text);
                    objProcesses.Wastage = (txtWastage.Text == string.Empty) ? 0 : Convert.ToDouble(txtWastage.Text);
                    objProcesses.SeqNo = i;
                    objCosting.ProcessItems.Add(objProcesses);
                }
                i++;
            }
        }

        private void AddLandedCosting(ref Costing objCosting)
        {
            if (null == objCosting.LandedCostingItems)
                objCosting.LandedCostingItems = new List<LandedCosting>();

            string context = string.Empty;
            int i = 1;
            foreach (GridViewRow row in grdLandedCosting.Rows)
            {
                HiddenField hdnModeId = row.FindControl("hdnModeId") as HiddenField;
                TextBox txtFobBoutique = row.FindControl("txtFobBoutique") as TextBox;
                TextBox txtFobIkandi = row.FindControl("txtFobIkandi") as TextBox;
                TextBox txtModeCost = row.FindControl("txtModeCost") as TextBox;   // mode cost
                TextBox txtDuty = row.FindControl("txtDuty") as TextBox;
                TextBox txtHandling = row.FindControl("txtHandling") as TextBox;
                TextBox txtDelivery = row.FindControl("txtDelivery") as TextBox;
                TextBox txtProcessCost = row.FindControl("txtProcessCost") as TextBox; // process cost
                TextBox txtMargin = row.FindControl("txtMargin") as TextBox;
                TextBox txtDiscount = row.FindControl("txtDiscount") as TextBox;
                TextBox txtGrandTotal = row.FindControl("txtGrandTotal") as TextBox;
                TextBox txtQuotedPrice = row.FindControl("txtQuotedPrice") as TextBox;
                TextBox txtAgreedPrice = row.FindControl("txtAgreedPrice") as TextBox;
                CheckBox ckhLandedCosting = row.FindControl("ckhLandedCosting") as CheckBox;
                Label lblMode = row.FindControl("lblMode") as Label;

                if (ckhLandedCosting.Checked)
                {
                    txtAgreedPrice.Text = txtQuotedPrice.Text;
                }


                if (txtFobBoutique.Text != string.Empty && txtFobIkandi.Text != string.Empty)
                {
                    LandedCosting objLandedCosting = new LandedCosting();
                    objLandedCosting.CostingQueryType = QueryType.Insert;
                    objLandedCosting.Mode = context;
                    objLandedCosting.Code = lblMode.Text.Trim();
                    objLandedCosting.ModeId = Convert.ToInt32(hdnModeId.Value.ToString());
                    objLandedCosting.FOBBoutique = txtFobBoutique.Text;
                    objLandedCosting.FOBIkandi = txtFobIkandi.Text;
                    objLandedCosting.ModeCost = txtModeCost.Text; //ddlModeCost.SelectedItem.Text;
                    objLandedCosting.ModeCostID = 0; //Convert.ToInt32(ddlModeCost.SelectedValue.ToString());
                    objLandedCosting.Duty = txtDuty.Text;
                    objLandedCosting.Handling = txtHandling.Text;
                    objLandedCosting.Delivery = txtDelivery.Text;
                    objLandedCosting.ProcessCost = txtProcessCost.Text;
                    //objLandedCosting.ProcessCostId = Convert.ToInt32(ddlProcessCost.SelectedValue.ToString());
                    objLandedCosting.Margin = (txtMargin.Text == string.Empty) ? 0 : Convert.ToDouble(txtMargin.Text);
                    objLandedCosting.Discount = (txtDiscount.Text == string.Empty) ? 0 : Convert.ToDouble(txtDiscount.Text);
                    objLandedCosting.GrandTotal = (txtGrandTotal.Text == string.Empty) ? 0 : Convert.ToDouble(txtGrandTotal.Text);
                    objLandedCosting.QuotedPrice = (txtQuotedPrice.Text == string.Empty) ? 0 : Convert.ToDouble(txtQuotedPrice.Text);
                    objLandedCosting.AgreedPrice = (txtAgreedPrice.Text == string.Empty) ? 0 : Convert.ToDouble(txtAgreedPrice.Text);
                    objLandedCosting.SequenceNumber = i;

                    objCosting.LandedCostingItems.Add(objLandedCosting);

                }
                i++;
            }
        }
        private void AddFOBPricing(ref Costing objCosting)
        {
            if (null == objCosting.FOBPricingItemNew)
            {
                objCosting.FOBPricingItemNew = new List<FOBPricing>();
            }
            int i = 1;
            foreach (GridViewRow row in grdDirectCosting.Rows)
            {
                HiddenField hdnModeId = row.FindControl("hdnModeId") as HiddenField;
                TextBox txtFobBoutique = row.FindControl("txtFobBoutique") as TextBox;
                TextBox txtHaulage = row.FindControl("txtHaulage") as TextBox;
                TextBox txtMargin = row.FindControl("txtMargin") as TextBox;
                TextBox txtDiscount = row.FindControl("txtDiscount") as TextBox;
                TextBox txtGrandTotal = row.FindControl("txtGrandTotal") as TextBox;
                TextBox txtQuotedPrice = row.FindControl("txtQuotedPrice") as TextBox;
                TextBox txtAgreedPrice = row.FindControl("txtAgreedPrice") as TextBox;
                CheckBox ckhDirectCosting = row.FindControl("ckhDirectCosting") as CheckBox;
                Label lblMode = row.FindControl("lblMode") as Label;

                if (ckhDirectCosting.Checked)
                {
                    txtAgreedPrice.Text = txtQuotedPrice.Text;
                }

                if (txtFobBoutique.Text != string.Empty)
                {
                    FOBPricing objFobCosting = new FOBPricing();
                    objFobCosting.CostingQueryType = QueryType.Insert;
                    objFobCosting.FOBDelhi = txtFobBoutique.Text;
                    objFobCosting.ModeId = Convert.ToInt32(hdnModeId.Value.ToString());
                    objFobCosting.Code = lblMode.Text.Trim();
                    objFobCosting.HaulageCharges = (txtHaulage.Text == string.Empty) ? 0 : Convert.ToDouble(txtHaulage.Text);
                    objFobCosting.FOBMargin = (txtMargin.Text == string.Empty) ? 0 : Convert.ToDouble(txtMargin.Text);
                    objFobCosting.Discount = (txtDiscount.Text == string.Empty) ? 0 : Convert.ToDouble(txtDiscount.Text);
                    objFobCosting.GrandTotal = (txtGrandTotal.Text == string.Empty) ? 0 : Convert.ToDouble(txtGrandTotal.Text);
                    objFobCosting.QuotedPrice = (txtQuotedPrice.Text == string.Empty) ? 0 : Convert.ToDouble(txtQuotedPrice.Text);
                    objFobCosting.AgreedPrice = (txtAgreedPrice.Text == string.Empty) ? 0 : Convert.ToDouble(txtAgreedPrice.Text);
                    objFobCosting.SequenceNumber = i;
                    objCosting.FOBPricingItemNew.Add(objFobCosting);


                }
                i++;
            }
        }
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
        protected void IkandiCostConfirmation_Click() //GC
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
                lblMsg.Text = "Costing Confirmation Request sent successfully.";
                lblMsg.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }
        public static string FirstCharToUpper(string s)
        {
            // Check for empty string.  
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.  
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        private void GetBIPLChangesHistory(ref Costing newCosting)//GC
        {
            int i = -1;
            if (null == newCosting.CommetHistoryItems)
                newCosting.CommetHistoryItems = new List<CommentHistory>();

            StringBuilder sb = new StringBuilder();
            if (CostingId > 0)
            {
                CostingCollection objCostingCollection = this.CostingControllerInstanceNew.GetCosting_New(CostingId);
                if (objCostingCollection.Count == 2) { CostingObject = objCostingCollection[1]; }
                else { CostingObject = objCostingCollection[0]; }

                if (!string.IsNullOrEmpty(txtPriceQuoted.Text) && Convert.ToDouble(txtPriceQuoted.Text) > 0)
                {

                    // add first portion created by acbhisek. when price quote is done.
                    if (CostingObject.Weight != newCosting.Weight)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                                    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Weight" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                                    + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                                    + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.Weight + "</span>"
                                                    + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.Weight + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 1119;
                        commenthistory.FieldName = "Weight";
                        commenthistory.OldValue = CostingObject.Weight.ToString();
                        commenthistory.NewValue = newCosting.Weight.ToString();
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;
                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }
                    if (CostingObject.ExpectedQty != newCosting.ExpectedQty)
                    {

                        DataTable dtnew = this.CostingControllerInstanceNew.GetClientDeptName(newCosting.ExpectedQty, "Exp");
                        DataTable dtold = this.CostingControllerInstanceNew.GetClientDeptName(CostingObject.ExpectedQty, "Exp");

                        string strnew = dtnew.Rows[0]["Expected_Qty"].ToString();
                        string strold = dtold.Rows[0]["Expected_Qty"].ToString();

                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                                    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Expected Qty" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                                    + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                                    + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + strnew + "</span>"
                                                    + "<span style='font-size:10px !important; color:#000000;'> was " + strold + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 1119;
                        commenthistory.FieldName = "ExpectedQty";
                        commenthistory.OldValue = strold;
                        commenthistory.NewValue = strnew;
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;
                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }
                    if (CostingObject.ClientID != newCosting.ClientID)
                    {
                        DataTable dtnew = this.CostingControllerInstanceNew.GetClientDeptName(newCosting.ClientID, "CLIENT");
                        DataTable dtold = this.CostingControllerInstanceNew.GetClientDeptName(CostingObject.ClientID, "CLIENT");
                        string strnew = dtnew.Rows[0]["CompanyName"].ToString();
                        string strold = dtold.Rows[0]["CompanyName"].ToString();


                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Client name" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + strnew + "</span>"
                                                     + "<span style='font-size:10px !important; color:#000000;'> was " + strold + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 1119;
                        commenthistory.FieldName = "ClientName";
                        commenthistory.OldValue = strold;
                        commenthistory.NewValue = strnew;
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;

                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }
                    if (CostingObject.DepartmentID != newCosting.DepartmentID)
                    {
                        DataTable dtnew = this.CostingControllerInstanceNew.GetClientDeptName(newCosting.DepartmentID, "sub");
                        DataTable dtold = this.CostingControllerInstanceNew.GetClientDeptName(CostingObject.DepartmentID, "sub");
                        string strnew = dtnew.Rows[0]["DepartmentName"].ToString();
                        string strold = dtold.Rows[0]["DepartmentName"].ToString();


                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Sub Department" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + strnew + "</span>"
                                                     + "<span style='font-size:10px !important; color:#000000;'> was " + strold + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 1119;
                        commenthistory.FieldName = "Department";
                        commenthistory.OldValue = strold;
                        commenthistory.NewValue = strnew;
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;

                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }
                    if (CostingObject.ParentDepartmentID != newCosting.ParentDepartmentID)
                    {
                        DataTable dtnew = this.CostingControllerInstanceNew.GetClientDeptName(newCosting.ParentDepartmentID, "sub");
                        DataTable dtold = this.CostingControllerInstanceNew.GetClientDeptName(CostingObject.ParentDepartmentID, "sub");
                        string strnew = dtnew.Rows[0]["DepartmentName"].ToString();
                        string strold = dtold.Rows[0]["DepartmentName"].ToString();


                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Parent Department" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + strnew + "</span>"
                                                     + "<span style='font-size:10px !important; color:#000000;'> was " + strold + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 1119;
                        commenthistory.FieldName = "ParentDepartment";
                        commenthistory.OldValue = strold;
                        commenthistory.NewValue = strnew;
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;

                        newCosting.CommetHistoryItems.Add(commenthistory);

                    }


                    FabricCosting newFabricCosting = null;
                    FabricCosting oldFabricCosting = null;

                    #region  for create history for delete Fabric, created by Surendra2 on 25-12-2018.

                    int countdelfeb = 0;
                    string deleteValue = hdnDeleteFabric.Value.ToString();
                    if (deleteValue != "")
                    {
                        string[] deletevalArray = deleteValue.Split(new[] { "!!!!!" }, StringSplitOptions.None);
                        for (int l = 0; l < deletevalArray.Length; l++)
                        {
                            string[] delExactval = deletevalArray[l].Split(new[] { "@#$:~#@" }, StringSplitOptions.None);
                            string FabricName = delExactval[0].ToString();
                            string FabricTypeId = delExactval[1].ToString();
                            string FabricTypeName = delExactval[2].ToString();
                            for (int k = 0; k < CostingObject.FabricCostingItems.Count; k++)
                            {
                                FabricCosting fabcosting = CostingObject.FabricCostingItems.Find(delegate(FabricCosting FC) { return FC.SequenceNumber == (k + 1); });
                                if (FabricName == fabcosting.Fabric && FabricTypeId == fabcosting.FabTypeId && FabricTypeName == fabcosting.FabricType)
                                {
                                    string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (k + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "deleted by" + " " + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + fabcosting.Fabric + "</span>";


                                    CommentHistory commenthistory = new CommentHistory();
                                    commenthistory.TypeFlag = 1;
                                    commenthistory.FieldName = "Delete Fabric" + (k + 1);
                                    commenthistory.OldValue = fabcosting.Fabric;
                                    commenthistory.NewValue = "";
                                    commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                    commenthistory.UpdatedOn = DateTime.Now.ToString();
                                    commenthistory.DetailDescription = x;
                                    commenthistory.isBipl = true;
                                    commenthistory.isPriceQuote = true;

                                    newCosting.CommetHistoryItems.Add(commenthistory);

                                    CostingObject.FabricCostingItems.RemoveAt(k);
                                    countdelfeb++;
                                }
                            }
                        }

                        int pl = 1;
                        for (int t = 0; t < CostingObject.FabricCostingItems.Count + countdelfeb; t++)
                        {
                            FabricCosting fabcosting = CostingObject.FabricCostingItems.Find(delegate(FabricCosting FC) { return FC.SequenceNumber == (t + 1); });
                            if (fabcosting != null)
                            {
                                fabcosting.SequenceNumber = pl;
                                pl++;
                            }
                        }
                        hdnDeleteFabric.Value = "";
                    }


                    for (i = 0; i < 8; i++)
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

                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Add Fabric by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Fabric + "</span>";
                                // + "<span style='font-size:10px !important; color:#000000;'> was " + "''" + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Add Fabric" + (i + 1);
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newFabricCosting.Fabric;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                            if (newFabricCosting.FabricType != null && newFabricCosting.FabricType.Trim() != string.Empty)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Add fabric type by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.FabricType + "</span>";
                                // + "<span style='font-size:10px !important; color:#000000;'> was " + "''" + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Add FabricType";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newFabricCosting.FabricType;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                            if (newFabricCosting.Average != 0)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Add Average by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Average.ToString("N2") + "</span>";
                                //+ "<span style='font-size:10px !important; color:#000000;'> was " + " 0" + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Add Average";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newFabricCosting.Average.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                            if (newFabricCosting.Rate != 0)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Add Rate by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Rate.ToString("N2") + "</span>";
                                //+ "<span style='font-size:10px !important; color:#000000;'> was " + " 0" + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Add Rate";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newFabricCosting.Rate.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }

                            //added by raghvinder on 30-10-2020 start
                            if (newFabricCosting.VAWastage1 != 0)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Add VA Wastage by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.VAWastage1.ToString("N2") + "</span>";
                                //+ "<span style='font-size:10px !important; color:#000000;'> was " + " 0" + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Add VA Wastage";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newFabricCosting.VAWastage1.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }

                            if (newFabricCosting.VARate1 != 0)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Add VA Rate by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.VARate1.ToString("N2") + "</span>";
                                //+ "<span style='font-size:10px !important; color:#000000;'> was " + " 0" + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Add VA Rate";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newFabricCosting.VARate1.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }

                            if (newFabricCosting.VAWastage2 != 0)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Add VA Wastage by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.VAWastage2.ToString("N2") + "</span>";
                                //+ "<span style='font-size:10px !important; color:#000000;'> was " + " 0" + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Add VA Wastage";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newFabricCosting.VAWastage2.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }

                            if (newFabricCosting.VARate2 != 0)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Add VA Rate by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.VARate2.ToString("N2") + "</span>";
                                //+ "<span style='font-size:10px !important; color:#000000;'> was " + " 0" + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Add VA Rate";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newFabricCosting.VARate2.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                            //added by raghvinder on 30-10-2020 end
                        }

                        if (oldFabricCosting != null && newFabricCosting == null)
                        {
                            if (oldFabricCosting.Fabric != null && oldFabricCosting.Fabric.Trim() != string.Empty)
                            {
                                sb.Append("$$ "
                                + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric " + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "''" + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Fabric + "</span>");

                            }
                            if (oldFabricCosting.FabricType != null && oldFabricCosting.FabricType.Trim() != string.Empty)
                            {
                                sb.Append("$$ "
                                + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  detail changed by  " + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "''" + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.FabricType + "</span>");

                            }
                            if (oldFabricCosting.Average != 0)
                            {
                                sb.Append("$$ "
                                + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Avg changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Average.ToString("N2") + "</span>");

                            }
                            if (oldFabricCosting.Rate != 0)
                            {
                                sb.Append("$$ "
                                + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Rate changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Rate.ToString("N2") + "</span>");

                            }

                            //added by raghvinder on 30-10-2020 start
                            if (oldFabricCosting.VAWastage1 != 0)
                            {
                                sb.Append("$$ "
                                + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " VA Wastage changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.VAWastage1.ToString("N2") + "</span>");
                            }

                            if (oldFabricCosting.VARate1 != 0)
                            {
                                sb.Append("$$ "
                                + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " VA Rate changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.VARate1.ToString("N2") + "</span>");

                            }

                            if (oldFabricCosting.VAWastage2 != 0)
                            {
                                sb.Append("$$ "
                                + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " VA Wastage changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.VAWastage2.ToString("N2") + "</span>");
                            }

                            if (oldFabricCosting.VARate2 != 0)
                            {
                                sb.Append("$$ "
                                + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " VA Rate changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.VARate2.ToString("N2") + "</span>");

                            }
                            //added by raghvinder on 30-10-2020 end
                        }

                        if (oldFabricCosting != null && newFabricCosting != null)
                        {
                            if (newFabricCosting.Fabric.Trim().ToLower() != oldFabricCosting.Fabric.Trim().ToLower())
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric " + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Fabric + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Fabric + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Fabric" + (i + 1);
                                commenthistory.OldValue = oldFabricCosting.Fabric;
                                commenthistory.NewValue = newFabricCosting.Fabric;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                            if (newFabricCosting.FabricType.Trim().ToLower() != oldFabricCosting.FabricType.Trim().ToLower())
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " detail changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.FabricType + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.FabricType + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "FebricType";
                                commenthistory.OldValue = oldFabricCosting.FabricType;
                                commenthistory.NewValue = newFabricCosting.FabricType;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                            if (oldFabricCosting.Average != newFabricCosting.Average)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Avg changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Average.ToString("N2") + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Average.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Average";
                                commenthistory.OldValue = oldFabricCosting.Average.ToString("N2");
                                commenthistory.NewValue = newFabricCosting.Average.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                            if (oldFabricCosting.Rate != newFabricCosting.Rate)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Rate changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Rate.ToString("N2") + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Rate.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Rate";
                                commenthistory.OldValue = oldFabricCosting.Rate.ToString("N2");
                                commenthistory.NewValue = newFabricCosting.Rate.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }

                            //added by raghvinder on 30-10-2020 start
                            if (oldFabricCosting.VAWastage1 != newFabricCosting.VAWastage1)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " VA Wastage changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.VAWastage1.ToString("N2") + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.VAWastage1.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "VA Wastage";
                                commenthistory.OldValue = oldFabricCosting.VAWastage1.ToString("N2");
                                commenthistory.NewValue = newFabricCosting.VAWastage1.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }

                            if (oldFabricCosting.VARate1 != newFabricCosting.VARate1)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " VA Rate changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.VARate1.ToString("N2") + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.VARate1.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "VA Rate";
                                commenthistory.OldValue = oldFabricCosting.VARate1.ToString("N2");
                                commenthistory.NewValue = newFabricCosting.VARate1.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }


                            if (oldFabricCosting.VAWastage2 != newFabricCosting.VAWastage2)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " VA Wastage changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.VAWastage2.ToString("N2") + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.VAWastage2.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "VA Wastage";
                                commenthistory.OldValue = oldFabricCosting.VAWastage2.ToString("N2");
                                commenthistory.NewValue = newFabricCosting.VAWastage2.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }

                            if (oldFabricCosting.VARate2 != newFabricCosting.VARate2)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " VA Rate changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.VARate2.ToString("N2") + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.VARate2.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "VA Rate";
                                commenthistory.OldValue = oldFabricCosting.VARate2.ToString("N2");
                                commenthistory.NewValue = newFabricCosting.VARate2.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                            //added by raghvinder on 30-10-2020 end

                            if (oldFabricCosting.Width != newFabricCosting.Width)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Width changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Width.ToString("N2") + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Width.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Width";
                                commenthistory.OldValue = oldFabricCosting.Width.ToString("N2");
                                commenthistory.NewValue = newFabricCosting.Width.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                        }

                    }
                    #endregion end Fabric

                    if (newCosting.OB_WS != CostingObject.OB_WS)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                              + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  OB changed by" + " " + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                              + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.OB_WS.ToString("N2") + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.OB_WS.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 2;
                        commenthistory.FieldName = "OB";
                        commenthistory.OldValue = CostingObject.OB_WS.ToString("N2");
                        commenthistory.NewValue = newCosting.OB_WS.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;

                        newCosting.CommetHistoryItems.Add(commenthistory);

                    }
                    if (newCosting.SAM != CostingObject.SAM)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                              + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  SAM changed by" + " " + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                              + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.SAM.ToString("N2") + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.SAM.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 2;
                        commenthistory.FieldName = "SAM";
                        commenthistory.OldValue = CostingObject.SAM.ToString("N2");
                        commenthistory.NewValue = newCosting.SAM.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;

                        newCosting.CommetHistoryItems.Add(commenthistory);

                    }
                    if (newCosting.CMTF != CostingObject.CMTF)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                              + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  CMT changed by" + " " + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                              + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.CMTF.ToString("N2") + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.CMTF.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 2;
                        commenthistory.FieldName = "CMT";
                        commenthistory.OldValue = CostingObject.CMTF.ToString("N2");
                        commenthistory.NewValue = newCosting.CMTF.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;

                        newCosting.CommetHistoryItems.Add(commenthistory);

                    }

                    i = 0;

                    Accessories newAccessories = null;
                    Accessories oldAccessories = null;

                    #region for create history for delete accessories, created by Surendra2 on 26-12-2018.

                    int countdelAccess = 0;
                    string deleteAccessValue = hdnDeleteAccessory.Value.ToString();

                    if (deleteAccessValue != "")
                    {
                        string[] deleteAccessvalArray = deleteAccessValue.Split(new[] { "!!!!!" }, StringSplitOptions.None);
                        for (int l = 0; l < deleteAccessvalArray.Length; l++)
                        {
                            string AccessoryName = deleteAccessvalArray[l].ToString();

                            for (int k = 0; k < CostingObject.AccessoryItems.Count; k++)
                            {
                                Accessories Accesscosting = CostingObject.AccessoryItems.Find(delegate(Accessories ACC) { return ACC.SequenceNumber == (k + 1); });
                                string sAccessoryVal = "";
                                if (Accesscosting != null)
                                    sAccessoryVal = Accesscosting.Item.Trim();

                                if (AccessoryName.Trim() == sAccessoryVal)
                                {
                                    string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Accessory " + (k + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "deleted by" + " " + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:grey;'> Item : </span>"

                                     + "<span style='font-size:10px !important; font-weight: bold; color:red;'>" + Accesscosting.Item + "</span>";

                                    CommentHistory commenthistory = new CommentHistory();
                                    commenthistory.TypeFlag = 3;
                                    commenthistory.FieldName = "Delete Accessory" + Accesscosting.Item;
                                    commenthistory.OldValue = Accesscosting.Item;
                                    commenthistory.NewValue = "";
                                    commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                    commenthistory.UpdatedOn = DateTime.Now.ToString();
                                    commenthistory.DetailDescription = x;
                                    commenthistory.isBipl = true;
                                    commenthistory.isPriceQuote = true;

                                    newCosting.CommetHistoryItems.Add(commenthistory);

                                    CostingObject.AccessoryItems.RemoveAt(k);
                                    countdelAccess++;
                                }
                            }
                        }

                        int plAccess = 1;
                        for (int t = 0; t < CostingObject.AccessoryItems.Count + countdelAccess; t++)
                        {
                            Accessories Accesscosting = CostingObject.AccessoryItems.Find(delegate(Accessories ACC) { return ACC.SequenceNumber == (t + 1); });
                            if (Accesscosting != null)
                            {
                                Accesscosting.SequenceNumber = plAccess;
                                plAccess++;
                            }
                        }
                        hdnDeleteAccessory.Value = "";
                    }



                    for (i = 0; i < gdvAccessory.Rows.Count; i++)
                    {
                        newAccessories = null;
                        oldAccessories = null;

                        if (newCosting.AccessoryItems != null && newCosting.AccessoryItems.Count > 0)
                        {
                            newAccessories = newCosting.AccessoryItems.Find(delegate(Accessories ACC) { return ACC.SequenceNumber == (i + 1); });
                            //newAccessories.ToString().Trim();
                        }

                        if (CostingObject.AccessoryItems != null && CostingObject.AccessoryItems.Count > 0)
                        {
                            oldAccessories = CostingObject.AccessoryItems.Find(delegate(Accessories ACC) { return ACC.SequenceNumber == (i + 1); });
                            //oldAccessories.ToString().Trim();
                        }

                        if (oldAccessories == null && newAccessories != null)
                        {
                            if (!string.IsNullOrEmpty(newAccessories.Item))
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  Accessories item : " + newAccessories.Item + " added by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>";
                                //+ "<span style='font-size:10px !important; color:#000000;'> was " + newAccessories.Item + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 3;
                                commenthistory.FieldName = "Add Items";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newAccessories.Item;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }

                            if (newAccessories.Rate != 0)
                            {

                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'> Item : " + newAccessories.Item + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Added Rate : " + newAccessories.Rate.ToString("N2") + " by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 3;
                                commenthistory.FieldName = "Add Rate";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newAccessories.Rate.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                        }

                        if (oldAccessories != null && newAccessories != null)
                        {
                            if (!string.IsNullOrEmpty(oldAccessories.Item) && !string.IsNullOrEmpty(newAccessories.Item) && oldAccessories.Item.Trim().ToLower() != newAccessories.Item.Trim().ToLower())
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Accessories Items changed by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Item + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Item + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 3;
                                commenthistory.FieldName = "Items";
                                commenthistory.OldValue = oldAccessories.Item;
                                commenthistory.NewValue = newAccessories.Item;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                            if (newAccessories.Quantity != oldAccessories.Quantity)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newAccessories.Item + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Quantity changed by" + " " + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Quantity.ToString("N2") + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Quantity.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 3;
                                commenthistory.FieldName = "Quantity";
                                commenthistory.OldValue = oldAccessories.Rate.ToString("N2");
                                commenthistory.NewValue = newAccessories.Rate.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);


                            }
                            if (newAccessories.Rate != oldAccessories.Rate)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newAccessories.Item + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Rate changed by" + " " + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Rate.ToString("N2") + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Rate.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 3;
                                commenthistory.FieldName = "Rate";
                                commenthistory.OldValue = oldAccessories.Rate.ToString("N2");
                                commenthistory.NewValue = newAccessories.Rate.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);


                            }
                        }

                    }
                    #endregion End Accessories.

                    i = 0;

                    Processes newProcesses = null;
                    Processes oldProcesses = null;

                    #region for create history for delete Processes, created by Surendra2 on 26-12-2018.

                    int countdelProcess = 0;
                    string deleteProcessValue = hdnDeleteProcess.Value.ToString();
                    if (deleteProcessValue != "")
                    {
                        string[] deleteProcessvalArray = deleteProcessValue.Split(new[] { "!!!!!" }, StringSplitOptions.None);
                        for (int l = 0; l < deleteProcessvalArray.Length; l++)
                        {
                            string ProcessName = deleteProcessvalArray[l].ToString();

                            for (int k = 0; k < CostingObject.ProcessItems.Count; k++)
                            {
                                Processes Processcosting = CostingObject.ProcessItems.Find(delegate(Processes PC) { return PC.SeqNo == (k + 1); });
                                if (ProcessName == Processcosting.Item)
                                {
                                    string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Process " + (k + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "deleted by" + " " + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + Processcosting.Item + "</span>";


                                    CommentHistory commenthistory = new CommentHistory();
                                    commenthistory.TypeFlag = 4;
                                    commenthistory.FieldName = "Delete Process" + Processcosting.Item;
                                    commenthistory.OldValue = Processcosting.Item;
                                    commenthistory.NewValue = "";
                                    commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                    commenthistory.UpdatedOn = DateTime.Now.ToString();
                                    commenthistory.DetailDescription = x;
                                    commenthistory.isBipl = true;
                                    commenthistory.isPriceQuote = true;

                                    newCosting.CommetHistoryItems.Add(commenthistory);

                                    CostingObject.ProcessItems.RemoveAt(k);
                                    countdelProcess++;
                                }
                            }
                        }

                        int plProcess = 1;
                        for (int t = 0; t < CostingObject.ProcessItems.Count + countdelProcess; t++)
                        {
                            Processes Processcosting = CostingObject.ProcessItems.Find(delegate(Processes PC) { return PC.SeqNo == (t + 1); });
                            if (Processcosting != null)
                            {
                                Processcosting.SeqNo = plProcess;
                                plProcess++;
                            }
                        }
                        hdnDeleteProcess.Value = "";

                    }


                    for (i = 0; i < gvdProcessDetails.Rows.Count; i++)
                    {
                        newProcesses = null;
                        oldProcesses = null;

                        if (newCosting.ProcessItems != null && newCosting.ProcessItems.Count > 0)
                        {
                            newProcesses = newCosting.ProcessItems.Find(delegate(Processes PC) { return PC.SeqNo == (i + 1); });
                        }

                        if (CostingObject.ProcessItems != null && CostingObject.ProcessItems.Count > 0)
                        {
                            oldProcesses = CostingObject.ProcessItems.Find(delegate(Processes PC) { return PC.SeqNo == (i + 1); });
                        }

                        if (oldProcesses == null && newProcesses != null)
                        {
                            if (!string.IsNullOrEmpty(newProcesses.Item))
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  Item :" + "<span style='font-size:10px !important; color:#000000;'> " + newProcesses.Item + "</span>" + " added by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>";
                                //+ "<span style='font-size:10px !important; color:#000000;'> was " + newProcesses.Item + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 4;
                                commenthistory.FieldName = "Add Items";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newProcesses.Item;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }

                            if (newProcesses.Amount != 0)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newProcesses.Item + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Add Amount " + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newProcesses.Amount.ToString("N2") + "</span>" + " by" + " " + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>";

                                //+ "<span style='font-size:10px !important; color:#000000;'> was " + "0" + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 4;
                                commenthistory.FieldName = "Add Amount";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newProcesses.Amount.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                        }

                        if (oldProcesses != null && newProcesses != null)
                        {
                            if (!string.IsNullOrEmpty(oldProcesses.Item) && !string.IsNullOrEmpty(newProcesses.Item) && oldProcesses.Item.ToLower() != newProcesses.Item.ToLower())
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Process Items changed by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newProcesses.Item + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'> was " + oldProcesses.Item + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 4;
                                commenthistory.FieldName = "Items";
                                commenthistory.OldValue = oldProcesses.Item;
                                commenthistory.NewValue = newProcesses.Item;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }

                            if (newProcesses.Amount != oldProcesses.Amount)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newProcesses.Item + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Process amount changed by" + " " + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newProcesses.Amount.ToString("N2") + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'> was " + oldProcesses.Amount.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 4;
                                commenthistory.FieldName = "Amount";
                                commenthistory.OldValue = oldProcesses.Amount.ToString("N2");
                                commenthistory.NewValue = newProcesses.Amount.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = true;

                                newCosting.CommetHistoryItems.Add(commenthistory);


                            }
                        }

                    }
                    #endregion End Process.

                    if (newCosting.FrieghtUptoFinalDestination != CostingObject.FrieghtUptoFinalDestination)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Freight upto changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.FrieghtUptoFinalDestination.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.FrieghtUptoFinalDestination.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "Freight upto";
                        commenthistory.OldValue = CostingObject.FrieghtUptoFinalDestination.ToString("N2");
                        commenthistory.NewValue = newCosting.FrieghtUptoFinalDestination.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;
                        newCosting.CommetHistoryItems.Add(commenthistory);

                    }
                    if (newCosting.CostingCutWastage != CostingObject.CostingCutWastage)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Cut wastage changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.CostingCutWastage.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.CostingCutWastage.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "Cut Wastage";
                        commenthistory.OldValue = CostingObject.CostingCutWastage.ToString("N2");
                        commenthistory.NewValue = newCosting.CostingCutWastage.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;
                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }
                    if (newCosting.CostingVAWastage != CostingObject.CostingVAWastage)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "VA wastage changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.CostingVAWastage.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.CostingVAWastage.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "VA Wastage";
                        commenthistory.OldValue = CostingObject.CostingVAWastage.ToString("N2");
                        commenthistory.NewValue = newCosting.CostingVAWastage.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;
                        newCosting.CommetHistoryItems.Add(commenthistory);

                    }
                    if (newCosting.OverHead != CostingObject.OverHead)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "OverHead changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.OverHead.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.OverHead.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "OverHead";
                        commenthistory.OldValue = CostingObject.OverHead.ToString("N2");
                        commenthistory.NewValue = newCosting.OverHead.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;
                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }
                    if (newCosting.ConversionRate != CostingObject.ConversionRate)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Conversion Rate changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.ConversionRate.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.ConversionRate.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "Conversion Rate";
                        commenthistory.OldValue = CostingObject.ConversionRate.ToString("N2");
                        commenthistory.NewValue = newCosting.ConversionRate.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;
                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }
                    if (newCosting.MarkupOnUnitCTC != CostingObject.MarkupOnUnitCTC)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Profit Margin Changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.MarkupOnUnitCTC.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.MarkupOnUnitCTC.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "Profit Margin";
                        commenthistory.OldValue = CostingObject.MarkupOnUnitCTC.ToString("N2");
                        commenthistory.NewValue = newCosting.MarkupOnUnitCTC.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;
                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }
                    if (newCosting.CommisionPercent != CostingObject.CommisionPercent)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                        + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Commision changed by" + " " + "</span>"
                        + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                        + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.CommisionPercent.ToString("N2") + "</span>"
                        + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.CommisionPercent.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "Commision";
                        commenthistory.OldValue = CostingObject.CommisionPercent.ToString("N2");
                        commenthistory.NewValue = newCosting.CommisionPercent.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;
                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }
                    if (newCosting.PriceQuoted != CostingObject.PriceQuoted)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                              + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Price Quoted" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                              + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.PriceQuoted.ToString("N2") + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.PriceQuoted.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "Price Quoted";
                        commenthistory.OldValue = CostingObject.PriceQuoted.ToString("N2");
                        commenthistory.NewValue = newCosting.PriceQuoted.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = true;
                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }

                }
                else
                {

                    // add first portion created by abhishek 26/12/2018. when price quote is null or blank.

                    if (CostingObject.Weight != newCosting.Weight)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Weight" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                    + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                    + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.Weight + "</span>"
                                    + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.Weight + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 1119;
                        commenthistory.FieldName = "Weight";
                        commenthistory.OldValue = CostingObject.Weight.ToString();
                        commenthistory.NewValue = newCosting.Weight.ToString();
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;
                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }
                    if (CostingObject.ExpectedQty != newCosting.ExpectedQty)
                    {
                        DataTable dtnew = this.CostingControllerInstanceNew.GetClientDeptName(newCosting.ExpectedQty, "Exp");
                        DataTable dtold = this.CostingControllerInstanceNew.GetClientDeptName(CostingObject.ExpectedQty, "Exp");
                        string strnew = "";
                        string strold = "";
                        if (dtnew.Rows.Count > 0)
                        {
                            strnew = dtnew.Rows[0]["Expected_Qty"].ToString();
                        }
                        if (dtold.Rows.Count > 0)
                        {
                            strold = dtold.Rows[0]["Expected_Qty"].ToString();
                        }

                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Expected Qty" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                    + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                    + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + strnew + "</span>"
                                    + "<span style='font-size:10px !important; color:#000000;'> was " + strold + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 1119;
                        commenthistory.FieldName = "ExpectedQty";
                        commenthistory.OldValue = strold;
                        commenthistory.NewValue = strnew;
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;
                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }
                    if (CostingObject.ClientID != newCosting.ClientID)
                    {
                        DataTable dtnew = this.CostingControllerInstanceNew.GetClientDeptName(newCosting.ClientID, "CLIENT");
                        DataTable dtold = this.CostingControllerInstanceNew.GetClientDeptName(CostingObject.ClientID, "CLIENT");
                        string strnew = dtnew.Rows[0]["CompanyName"].ToString();
                        string strold = dtold.Rows[0]["CompanyName"].ToString();

                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Client name" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                    + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                    + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + strnew + "</span>"
                                    + "<span style='font-size:10px !important; color:#000000;'> was " + strold + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 1119;
                        commenthistory.FieldName = "ClientName";
                        commenthistory.OldValue = strold;
                        commenthistory.NewValue = strnew;
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;
                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }
                    if (CostingObject.DepartmentID != newCosting.DepartmentID)
                    {
                        DataTable dtnew = this.CostingControllerInstanceNew.GetClientDeptName(newCosting.DepartmentID, "sub");
                        DataTable dtold = this.CostingControllerInstanceNew.GetClientDeptName(CostingObject.DepartmentID, "sub");
                        string strnew = dtnew.Rows[0]["DepartmentName"].ToString();
                        string strold = dtold.Rows[0]["DepartmentName"].ToString();

                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Sub Department" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                    + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                    + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + strnew + "</span>"
                                    + "<span style='font-size:10px !important; color:#000000;'> was " + strold + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 1119;
                        commenthistory.FieldName = "Department";
                        commenthistory.OldValue = strold;
                        commenthistory.NewValue = strnew;
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;
                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }
                    if (CostingObject.ParentDepartmentID != newCosting.ParentDepartmentID)
                    {
                        DataTable dtnew = this.CostingControllerInstanceNew.GetClientDeptName(newCosting.ParentDepartmentID, "sub");
                        DataTable dtold = this.CostingControllerInstanceNew.GetClientDeptName(CostingObject.ParentDepartmentID, "sub");
                        string strnew = dtnew.Rows[0]["DepartmentName"].ToString();
                        string strold = dtold.Rows[0]["DepartmentName"].ToString();

                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Parent Department" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                    + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                    + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + strnew + "</span>"
                                    + "<span style='font-size:10px !important; color:#000000;'> was " + strold + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 1119;
                        commenthistory.FieldName = "ParentDepartment";
                        commenthistory.OldValue = strold;
                        commenthistory.NewValue = strnew;
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;
                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }

                    FabricCosting newFabricCosting = null;
                    FabricCosting oldFabricCosting = null;

                    #region for create history for delete Fabric, created by Surendra2 on 25-12-2018.

                    int countdelfeb = 0;
                    string deleteValue = hdnDeleteFabric.Value.ToString();
                    if (deleteValue != "")
                    {
                        string[] deletevalArray = deleteValue.Split(new[] { "!!!!!" }, StringSplitOptions.None);
                        for (int l = 0; l < deletevalArray.Length; l++)
                        {
                            string[] delExactval = deletevalArray[l].Split(new[] { "@#$:~#@" }, StringSplitOptions.None);
                            string FabricName = delExactval[0].ToString();
                            string FabricTypeId = delExactval[1].ToString();
                            string FabricTypeName = delExactval[2].ToString();
                            for (int k = 0; k < CostingObject.FabricCostingItems.Count; k++)
                            {
                                FabricCosting fabcosting = CostingObject.FabricCostingItems.Find(delegate(FabricCosting FC) { return FC.SequenceNumber == (k + 1); });
                                if (FabricName == fabcosting.Fabric && FabricTypeId == fabcosting.FabTypeId && FabricTypeName == fabcosting.FabricType)
                                {
                                    string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (k + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "deleted by" + " " + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + fabcosting.Fabric + "</span>";

                                    CommentHistory commenthistory = new CommentHistory();
                                    commenthistory.TypeFlag = 1;
                                    commenthistory.FieldName = "Delete Fabric" + (k + 1);
                                    commenthistory.OldValue = fabcosting.Fabric;
                                    commenthistory.NewValue = "";
                                    commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                    commenthistory.UpdatedOn = DateTime.Now.ToString();
                                    commenthistory.DetailDescription = x;
                                    commenthistory.isBipl = true;
                                    commenthistory.isPriceQuote = false;
                                    newCosting.CommetHistoryItems.Add(commenthistory);

                                    CostingObject.FabricCostingItems.RemoveAt(k);
                                    countdelfeb++;
                                }
                            }
                        }

                        int pl = 1;
                        for (int t = 0; t < CostingObject.FabricCostingItems.Count + countdelfeb; t++)
                        {
                            FabricCosting fabcosting = CostingObject.FabricCostingItems.Find(delegate(FabricCosting FC) { return FC.SequenceNumber == (t + 1); });
                            if (fabcosting != null)
                            {
                                fabcosting.SequenceNumber = pl;
                                pl++;
                            }
                        }
                        hdnDeleteFabric.Value = "";
                    }


                    for (i = 0; i < 8; i++)
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

                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric" + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Fabric + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'> was " + "''" + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Add Fabric" + (i + 1);
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newFabricCosting.Fabric;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;
                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                            if (newFabricCosting.FabricType != null && newFabricCosting.FabricType.Trim() != string.Empty)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.FabricType + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + "''" + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Add FabricType";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newFabricCosting.FabricType;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;
                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                            if (newFabricCosting.Average != 0)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Average.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Add Average";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newFabricCosting.Average.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;
                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                            if (newFabricCosting.Rate != 0)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Rate changed by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Rate.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Add Rate";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newFabricCosting.Rate.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;
                                newCosting.CommetHistoryItems.Add(commenthistory);
                            }
                        }

                        if (oldFabricCosting != null && newFabricCosting == null)
                        {
                            if (oldFabricCosting.Fabric != null && oldFabricCosting.Fabric.Trim() != string.Empty)
                            {
                                sb.Append("$$ "
                                + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric " + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "''" + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Fabric + "</span>");
                            }
                            if (oldFabricCosting.FabricType != null && oldFabricCosting.FabricType.Trim() != string.Empty)
                            {
                                sb.Append("$$ "
                                + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + oldFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  detail changed by  " + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "''" + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.FabricType + "</span>");
                            }
                            if (oldFabricCosting.Average != 0)
                            {
                                sb.Append("$$ "
                                + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + oldFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Avg changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Average.ToString("N2") + "</span>");
                            }
                            if (oldFabricCosting.Rate != 0)
                            {
                                sb.Append("$$ "
                                + "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + oldFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Rate changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + "0" + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Rate.ToString("N2") + "</span>");
                            }
                        }

                        if (oldFabricCosting != null && newFabricCosting != null)
                        {
                            if (newFabricCosting.Fabric.Trim().ToLower() != oldFabricCosting.Fabric.Trim().ToLower())
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Fabric " + (i + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Fabric + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Fabric + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Fabric" + (i + 1);
                                commenthistory.OldValue = oldFabricCosting.Fabric;
                                commenthistory.NewValue = newFabricCosting.Fabric;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;
                                newCosting.CommetHistoryItems.Add(commenthistory);
                            }
                            if (newFabricCosting.FabricType.Trim().ToLower() != oldFabricCosting.FabricType.Trim().ToLower())
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " detail changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.FabricType + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.FabricType + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "FebricType";
                                commenthistory.OldValue = oldFabricCosting.FabricType;
                                commenthistory.NewValue = newFabricCosting.FabricType;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;
                                newCosting.CommetHistoryItems.Add(commenthistory);
                            }
                            if (oldFabricCosting.Average != newFabricCosting.Average)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Avg changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Average.ToString("N2") + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Average.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Average";
                                commenthistory.OldValue = oldFabricCosting.Average.ToString("N2");
                                commenthistory.NewValue = newFabricCosting.Average.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                            if (oldFabricCosting.Rate != newFabricCosting.Rate)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newFabricCosting.Fabric + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Rate changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFabricCosting.Rate.ToString("N2") + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + oldFabricCosting.Rate.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 1;
                                commenthistory.FieldName = "Rate";
                                commenthistory.OldValue = oldFabricCosting.Rate.ToString("N2");
                                commenthistory.NewValue = newFabricCosting.Rate.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;
                                newCosting.CommetHistoryItems.Add(commenthistory);
                            }
                        }

                    }
                    #endregion end Fabric

                    if (newCosting.OB_WS != CostingObject.OB_WS)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                              + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  OB changed by" + " " + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                              + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.OB_WS.ToString("N2") + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.OB_WS.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 2;
                        commenthistory.FieldName = "OB";
                        commenthistory.OldValue = CostingObject.OB_WS.ToString("N2");
                        commenthistory.NewValue = newCosting.OB_WS.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;
                        newCosting.CommetHistoryItems.Add(commenthistory);

                    }
                    if (newCosting.SAM != CostingObject.SAM)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                              + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  SAM changed by" + " " + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                              + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.SAM.ToString("N2") + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.SAM.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 2;
                        commenthistory.FieldName = "SAM";
                        commenthistory.OldValue = CostingObject.SAM.ToString("N2");
                        commenthistory.NewValue = newCosting.SAM.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;
                        newCosting.CommetHistoryItems.Add(commenthistory);

                    }
                    if (newCosting.CMTF != CostingObject.CMTF)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                              + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  CMT changed by" + " " + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                              + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.CMTF.ToString("N2") + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.CMTF.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 2;
                        commenthistory.FieldName = "CMT";
                        commenthistory.OldValue = CostingObject.CMTF.ToString("N2");
                        commenthistory.NewValue = newCosting.CMTF.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;
                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }

                    i = 0;

                    Accessories newAccessories = null;
                    Accessories oldAccessories = null;

                    #region for create history for delete accessories, created by Surendra2 on 26-12-2018.

                    int countdelAccess = 0;
                    string deleteAccessValue = hdnDeleteAccessory.Value.ToString();
                    if (deleteAccessValue != "")
                    {
                        string[] deleteAccessvalArray = deleteAccessValue.Split(new[] { "!!!!!" }, StringSplitOptions.None);
                        for (int l = 0; l < deleteAccessvalArray.Length; l++)
                        {
                            string AccessoryName = deleteAccessvalArray[l].ToString();

                            for (int k = 0; k < CostingObject.AccessoryItems.Count; k++)
                            {
                                Accessories Accesscosting = CostingObject.AccessoryItems.Find(delegate(Accessories ACC) { return ACC.SequenceNumber == (k + 1); });
                                if (AccessoryName == Accesscosting.Item)
                                {
                                    string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Accessory " + (k + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "deleted by" + " " + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + Accesscosting.Item + "</span>";


                                    CommentHistory commenthistory = new CommentHistory();
                                    commenthistory.TypeFlag = 3;
                                    commenthistory.FieldName = "Delete Accessory" + Accesscosting.Item;
                                    commenthistory.OldValue = Accesscosting.Item;
                                    commenthistory.NewValue = "";
                                    commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                    commenthistory.UpdatedOn = DateTime.Now.ToString();
                                    commenthistory.DetailDescription = x;
                                    commenthistory.isBipl = true;
                                    commenthistory.isPriceQuote = false;
                                    newCosting.CommetHistoryItems.Add(commenthistory);
                                    countdelAccess++;
                                }
                            }
                        }

                        int plAccess = 1;
                        for (int t = 0; t < CostingObject.AccessoryItems.Count + countdelAccess; t++)
                        {
                            Accessories Accesscosting = CostingObject.AccessoryItems.Find(delegate(Accessories ACC) { return ACC.SequenceNumber == (t + 1); });
                            if (Accesscosting != null)
                            {
                                Accesscosting.SequenceNumber = plAccess;
                                plAccess++;
                            }
                        }
                        hdnDeleteAccessory.Value = "";
                    }


                    for (i = 0; i < gdvAccessory.Rows.Count; i++)
                    {
                        newAccessories = null;
                        oldAccessories = null;

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
                            if (!string.IsNullOrEmpty(newAccessories.Item))
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  Accessories item : " + newAccessories.Item + "added by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 3;
                                commenthistory.FieldName = "Add Items";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newAccessories.Item;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;

                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }

                            if (newAccessories.Rate != 0)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'> Item : " + newAccessories.Item + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Added Rate : " + newAccessories.Rate.ToString("N2") + " by" + " " + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 3;
                                commenthistory.FieldName = "Add Rate";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newAccessories.Rate.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;
                                newCosting.CommetHistoryItems.Add(commenthistory);
                            }
                        }

                        if (oldAccessories != null && newAccessories != null)
                        {
                            if (!string.IsNullOrEmpty(oldAccessories.Item) && !string.IsNullOrEmpty(newAccessories.Item) && oldAccessories.Item.Trim().ToLower() != newAccessories.Item.Trim().ToLower())
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Accessories Items changed by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Item + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Item + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 3;
                                commenthistory.FieldName = "Items";
                                commenthistory.OldValue = oldAccessories.Item;
                                commenthistory.NewValue = newAccessories.Item;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;
                                newCosting.CommetHistoryItems.Add(commenthistory);
                            }

                            if (newAccessories.Rate != oldAccessories.Rate)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newAccessories.Item + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Rate changed by" + " " + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newAccessories.Rate.ToString("N2") + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'> was " + oldAccessories.Rate.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 3;
                                commenthistory.FieldName = "Rate";
                                commenthistory.OldValue = oldAccessories.Rate.ToString("N2");
                                commenthistory.NewValue = newAccessories.Rate.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;
                                newCosting.CommetHistoryItems.Add(commenthistory);
                            }
                        }

                    }
                    #endregion End Accessories.

                    i = 0;

                    Processes newProcesses = null;
                    Processes oldProcesses = null;

                    #region for create history for delete Processes, created by Surendra2 on 26-12-2018.

                    int countdelProcess = 0;
                    string deleteProcessValue = hdnDeleteProcess.Value.ToString();
                    if (deleteProcessValue != "")
                    {
                        string[] deleteProcessvalArray = deleteProcessValue.Split(new[] { "!!!!!" }, StringSplitOptions.None);
                        for (int l = 0; l < deleteProcessvalArray.Length; l++)
                        {
                            string ProcessName = deleteProcessvalArray[l].ToString();

                            for (int k = 0; k < CostingObject.ProcessItems.Count; k++)
                            {
                                Processes Processcosting = CostingObject.ProcessItems.Find(delegate(Processes PC) { return PC.SeqNo == (k + 1); });
                                if (ProcessName == Processcosting.Item)
                                {
                                    string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Process " + (k + 1) + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "deleted by" + " " + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + Processcosting.Item + "</span>";

                                    CommentHistory commenthistory = new CommentHistory();
                                    commenthistory.TypeFlag = 4;
                                    commenthistory.FieldName = "Delete Process" + Processcosting.Item;
                                    commenthistory.OldValue = Processcosting.Item;
                                    commenthistory.NewValue = "";
                                    commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                    commenthistory.UpdatedOn = DateTime.Now.ToString();
                                    commenthistory.DetailDescription = x;
                                    commenthistory.isBipl = true;
                                    commenthistory.isPriceQuote = false;

                                    newCosting.CommetHistoryItems.Add(commenthistory);
                                    countdelProcess++;
                                }
                            }
                        }
                        int plProcess = 1;
                        for (int t = 0; t < CostingObject.ProcessItems.Count + countdelProcess; t++)
                        {
                            Processes Processcosting = CostingObject.ProcessItems.Find(delegate(Processes PC) { return PC.SeqNo == (t + 1); });
                            if (Processcosting != null)
                            {
                                Processcosting.SeqNo = plProcess;
                                plProcess++;
                            }
                        }
                        hdnDeleteProcess.Value = "";
                    }


                    for (i = 0; i < gvdProcessDetails.Rows.Count; i++)
                    {
                        newProcesses = null;
                        oldProcesses = null;

                        if (newCosting.ProcessItems != null && newCosting.ProcessItems.Count > 0)
                        {
                            newProcesses = newCosting.ProcessItems.Find(delegate(Processes PC) { return PC.SeqNo == (i + 1); });
                        }

                        if (CostingObject.ProcessItems != null && CostingObject.ProcessItems.Count > 0)
                        {
                            oldProcesses = CostingObject.ProcessItems.Find(delegate(Processes PC) { return PC.SeqNo == (i + 1); });
                        }

                        if (oldProcesses == null && newProcesses != null)
                        {
                            if (!string.IsNullOrEmpty(newProcesses.Item))
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "  Items added by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'> was " + newProcesses.Item + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 4;
                                commenthistory.FieldName = "Add Items";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newProcesses.Item;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;
                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }

                            if (newProcesses.Amount != 0)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newProcesses.Item + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Add amount by" + " " + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newProcesses.Amount.ToString("N2") + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'> was " + "0" + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 4;
                                commenthistory.FieldName = "Add Amount";
                                commenthistory.OldValue = "";
                                commenthistory.NewValue = newProcesses.Amount.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;
                                newCosting.CommetHistoryItems.Add(commenthistory);
                            }
                        }

                        if (oldProcesses != null && newProcesses != null)
                        {
                            if (!string.IsNullOrEmpty(oldProcesses.Item) && !string.IsNullOrEmpty(newProcesses.Item) && oldProcesses.Item.ToLower() != newProcesses.Item.ToLower())
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + " Process Items changed by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newProcesses.Item + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'> was " + oldProcesses.Item + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 4;
                                commenthistory.FieldName = "Items";
                                commenthistory.OldValue = oldProcesses.Item;
                                commenthistory.NewValue = newProcesses.Item;
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;
                                newCosting.CommetHistoryItems.Add(commenthistory);
                            }

                            if (newProcesses.Amount != oldProcesses.Amount)
                            {
                                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + newProcesses.Item + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Process amount changed by" + " " + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                     + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newProcesses.Amount.ToString("N2") + "</span>"
                                     + "<span style='font-size:10px !important; color:#000000;'> was " + oldProcesses.Amount.ToString("N2") + "</span>";

                                CommentHistory commenthistory = new CommentHistory();
                                commenthistory.TypeFlag = 4;
                                commenthistory.FieldName = "Amount";
                                commenthistory.OldValue = oldProcesses.Amount.ToString("N2");
                                commenthistory.NewValue = newProcesses.Amount.ToString("N2");
                                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                                commenthistory.UpdatedOn = DateTime.Now.ToString();
                                commenthistory.DetailDescription = x;
                                commenthistory.isBipl = true;
                                commenthistory.isPriceQuote = false;
                                newCosting.CommetHistoryItems.Add(commenthistory);

                            }
                        }

                    }
                    #endregion End Process.

                    if (newCosting.FrieghtUptoFinalDestination != CostingObject.FrieghtUptoFinalDestination)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Freight upto changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.FrieghtUptoFinalDestination.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.FrieghtUptoFinalDestination.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "Freight upto";
                        commenthistory.OldValue = CostingObject.FrieghtUptoFinalDestination.ToString("N2");
                        commenthistory.NewValue = newCosting.FrieghtUptoFinalDestination.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;

                        newCosting.CommetHistoryItems.Add(commenthistory);

                    }
                    if (newCosting.CostingCutWastage != CostingObject.CostingCutWastage)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Cut wastage changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.CostingCutWastage.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.CostingCutWastage.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "Cut Wastage";
                        commenthistory.OldValue = CostingObject.CostingCutWastage.ToString("N2");
                        commenthistory.NewValue = newCosting.CostingCutWastage.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;

                        newCosting.CommetHistoryItems.Add(commenthistory);

                    }
                    if (newCosting.CostingVAWastage != CostingObject.CostingVAWastage)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "VA wastage changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.CostingVAWastage.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.CostingVAWastage.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "VA Wastage";
                        commenthistory.OldValue = CostingObject.CostingVAWastage.ToString("N2");
                        commenthistory.NewValue = newCosting.CostingVAWastage.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;

                        newCosting.CommetHistoryItems.Add(commenthistory);

                    }
                    if (newCosting.OverHead != CostingObject.OverHead)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "OverHead changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.OverHead.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.OverHead.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "OverHead";
                        commenthistory.OldValue = CostingObject.OverHead.ToString("N2");
                        commenthistory.NewValue = newCosting.OverHead.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;

                        newCosting.CommetHistoryItems.Add(commenthistory);

                    }
                    if (newCosting.ConversionRate != CostingObject.ConversionRate)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Conversion Rate changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.ConversionRate.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.ConversionRate.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "Conversion Rate";
                        commenthistory.OldValue = CostingObject.ConversionRate.ToString("N2");
                        commenthistory.NewValue = newCosting.ConversionRate.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;

                        newCosting.CommetHistoryItems.Add(commenthistory);

                    }
                    if (newCosting.MarkupOnUnitCTC != CostingObject.MarkupOnUnitCTC)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Profit Margin Changed by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.MarkupOnUnitCTC.ToString("N2") + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.MarkupOnUnitCTC.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "Profit Margin";
                        commenthistory.OldValue = CostingObject.MarkupOnUnitCTC.ToString("N2");
                        commenthistory.NewValue = newCosting.MarkupOnUnitCTC.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;

                        newCosting.CommetHistoryItems.Add(commenthistory);

                    }
                    if (newCosting.CommisionPercent != CostingObject.CommisionPercent)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                        + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Commision changed by" + " " + "</span>"
                        + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                        + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.CommisionPercent.ToString("N2") + "</span>"
                        + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.CommisionPercent.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "Commision";
                        commenthistory.OldValue = CostingObject.CommisionPercent.ToString("N2");
                        commenthistory.NewValue = newCosting.CommisionPercent.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;

                        newCosting.CommetHistoryItems.Add(commenthistory);

                    }
                    if (newCosting.PriceQuoted != CostingObject.PriceQuoted)
                    {
                        string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                              + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Price Quoted" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                              + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newCosting.PriceQuoted.ToString("N2") + "</span>"
                              + "<span style='font-size:10px !important; color:#000000;'> was " + CostingObject.PriceQuoted.ToString("N2") + "</span>";

                        CommentHistory commenthistory = new CommentHistory();
                        commenthistory.TypeFlag = 5;
                        commenthistory.FieldName = "Price Quoted";
                        commenthistory.OldValue = CostingObject.PriceQuoted.ToString("N2");
                        commenthistory.NewValue = newCosting.PriceQuoted.ToString("N2");
                        commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory.UpdatedOn = DateTime.Now.ToString();
                        commenthistory.DetailDescription = x;
                        commenthistory.isBipl = true;
                        commenthistory.isPriceQuote = false;

                        newCosting.CommetHistoryItems.Add(commenthistory);
                    }
                }
            }
            else
            {
                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                         + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "BIPL Costing Sheet" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Saved by" + " " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                         + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + " AT " + "</span>"
                         + "<span style='font-size:10px !important; color:#000000;'>" + DateTime.Now.ToString("hh:mm tt") + "</span>";

                //sb.Append("$$ " + x);

                CommentHistory commenthistory = new CommentHistory();
                commenthistory.TypeFlag = 1119;
                commenthistory.FieldName = "BIPL Costing Sheet";
                commenthistory.OldValue = "";
                commenthistory.NewValue = "";
                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                commenthistory.UpdatedOn = DateTime.Now.ToString();
                commenthistory.DetailDescription = x;
                commenthistory.isBipl = true;
                commenthistory.isPriceQuote = false;

                newCosting.CommetHistoryItems.Add(commenthistory);
            }
        }

        private void GetiKandiChangesHistory(ref Costing newCosting)//GC
        {
            if (null == newCosting.CommetHistoryItems)
                newCosting.CommetHistoryItems = new List<CommentHistory>();

            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(txtPriceQuoted.Text) && Convert.ToDouble(txtPriceQuoted.Text) > 0 && CostingObject.LandedCostingItems.Count > 0)
            {
                int i = 0;

                LandedCosting newLandedCosting = null;
                LandedCosting oldLandedCosting = null;
                double result = 0;
                double result2 = 0;

                for (i = 0; i < grdLandedCosting.Rows.Count; i++)
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

                    //added by raghvinder on 01 Dec 2020 start
                    if (ApplicationHelper.LoggedInUser.UserData.UserID == 5)
                    {
                        string x1 = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                     + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Costing saved by " + "</span>" +
                                      "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>";

                        CommentHistory commenthistory1 = new CommentHistory();
                        commenthistory1.TypeFlag = 6;
                        commenthistory1.FieldName = "Ikandi Costing";
                        commenthistory1.OldValue = "";
                        commenthistory1.NewValue = "";
                        commenthistory1.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                        commenthistory1.UpdatedOn = DateTime.Now.ToString();
                        commenthistory1.DetailDescription = x1;
                        commenthistory1.isBipl = false;
                        commenthistory1.isPriceQuote = true;
                        newCosting.CommetHistoryItems.Add(commenthistory1);
                    }
                    //added by raghvinder on 01 Dec 2020 end

                    if (oldLandedCosting == null && newLandedCosting != null)
                    {
                        if (newLandedCosting.ModeCost != "" && Double.TryParse(newLandedCosting.ModeCost, out result) && result != 0)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Mode Cost (" + newLandedCosting.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString() + " " + "</span>"
                                 + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>";
                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 6;
                            commenthistory.FieldName = "Mode Cost";
                            commenthistory.OldValue = "";
                            commenthistory.NewValue = result.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }
                        if (newLandedCosting.Duty != "" && Double.TryParse(newLandedCosting.Duty, out result) && result != 0)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Duty (" + newLandedCosting.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString() + " " + "</span>"
                                 + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>";
                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 6;
                            commenthistory.FieldName = "Duty";
                            commenthistory.OldValue = "";
                            commenthistory.NewValue = result.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }
                        if (newLandedCosting.Handling != "" && Double.TryParse(newLandedCosting.Handling, out result) && result != 0)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Handling (" + newLandedCosting.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString() + " " + "</span>"
                                + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>";
                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 6;
                            commenthistory.FieldName = "Handling";
                            commenthistory.OldValue = "";
                            commenthistory.NewValue = result.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }

                        if (newLandedCosting.Delivery != "" && Double.TryParse(newLandedCosting.Delivery, out result) && result != 0)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Delivery (" + newLandedCosting.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString() + " " + "</span>"
                                + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 6;
                            commenthistory.FieldName = "Delivery";
                            commenthistory.OldValue = "";
                            commenthistory.NewValue = result.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }

                        if (newLandedCosting.Processing != "" && Double.TryParse(newLandedCosting.Processing, out result) && result != 0)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Processing (" + newLandedCosting.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString() + " " + "</span>"
                                + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 6;
                            commenthistory.FieldName = "Processing";
                            commenthistory.OldValue = "";
                            commenthistory.NewValue = result.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }
                        if (newLandedCosting.Margin != 0)
                        {

                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + " Margin (" + newLandedCosting.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newLandedCosting.Margin.ToString() + " " + "</span>"
                                + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 6;
                            commenthistory.FieldName = "Margin";
                            commenthistory.OldValue = "";
                            commenthistory.NewValue = newLandedCosting.Margin.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }
                        if (newLandedCosting.Discount != 0)
                        {

                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + " Discount (" + newLandedCosting.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newLandedCosting.Discount.ToString() + " " + "</span>"
                                + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 6;
                            commenthistory.FieldName = "Discount";
                            commenthistory.OldValue = "";
                            commenthistory.NewValue = newLandedCosting.Discount.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }
                        if (newLandedCosting.QuotedPrice != 0)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + " Price Quoted (" + newLandedCosting.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newLandedCosting.QuotedPrice.ToString() + " " + "</span>"
                                + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 6;
                            commenthistory.FieldName = "Discount";
                            commenthistory.OldValue = "";
                            commenthistory.NewValue = newLandedCosting.Discount.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }
                    }

                    if (oldLandedCosting != null && newLandedCosting != null)
                    {
                        if (newLandedCosting.ModeCost != "" && Double.TryParse(newLandedCosting.ModeCost, out result) && oldLandedCosting.ModeCost != "" && Double.TryParse(oldLandedCosting.ModeCost, out result2) && result != result2)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Mode Cost (" + newLandedCosting.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                    + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                    + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString() + " " + "</span>"
                                    + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + result2.ToString() + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 6;
                            commenthistory.FieldName = "Mode Cost";
                            commenthistory.OldValue = result2.ToString();
                            commenthistory.NewValue = result.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }
                        if (newLandedCosting.Duty != "" && Double.TryParse(newLandedCosting.Duty, out result) && oldLandedCosting.Duty != "" && Double.TryParse(oldLandedCosting.Duty, out result2) && result != result2)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Duty (" + newLandedCosting.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                    + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                    + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString() + " " + "</span>"
                                    + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + result2.ToString() + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 6;
                            commenthistory.FieldName = "Duty";
                            commenthistory.OldValue = result2.ToString();
                            commenthistory.NewValue = result.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }
                        if (newLandedCosting.Handling != "" && Double.TryParse(newLandedCosting.Handling, out result) && oldLandedCosting.Handling != "" && Double.TryParse(oldLandedCosting.Handling, out result2) && result != result2)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                  + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Handling (" + newLandedCosting.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                  + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                  + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString() + " " + "</span>"
                                  + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + result2.ToString() + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 6;
                            commenthistory.FieldName = "Handling";
                            commenthistory.OldValue = result2.ToString();
                            commenthistory.NewValue = result.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }

                        if (newLandedCosting.Delivery != "" && Double.TryParse(newLandedCosting.Delivery, out result) && oldLandedCosting.Delivery != "" && Double.TryParse(oldLandedCosting.Delivery, out result2) && result != result2)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Delivery (" + newLandedCosting.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString() + " " + "</span>"
                                 + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + result2.ToString() + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 6;
                            commenthistory.FieldName = "Delivery";
                            commenthistory.OldValue = result2.ToString();
                            commenthistory.NewValue = result.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }

                        if (newLandedCosting.Processing != "" && Double.TryParse(newLandedCosting.Processing, out result) && oldLandedCosting.Processing != "" && Double.TryParse(oldLandedCosting.Processing, out result2) && result != result2)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Processing (" + newLandedCosting.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString() + " " + "</span>"
                                + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + result2.ToString() + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 6;
                            commenthistory.FieldName = "Processing";
                            commenthistory.OldValue = result2.ToString();
                            commenthistory.NewValue = result.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }

                        if (newLandedCosting.Margin != oldLandedCosting.Margin)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Margin (" + newLandedCosting.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newLandedCosting.Margin.ToString() + " " + "</span>"
                                + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + oldLandedCosting.Margin.ToString() + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 6;
                            commenthistory.FieldName = "Margin";
                            commenthistory.OldValue = oldLandedCosting.Margin.ToString();
                            commenthistory.NewValue = newLandedCosting.Margin.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;

                            newCosting.CommetHistoryItems.Add(commenthistory);

                        }


                        if (newLandedCosting.QuotedPrice != oldLandedCosting.QuotedPrice)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Price Quoted (" + newLandedCosting.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newLandedCosting.QuotedPrice.ToString() + " " + "</span>"
                                + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + oldLandedCosting.QuotedPrice.ToString() + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 6;
                            commenthistory.FieldName = "Price Quoted";
                            commenthistory.OldValue = oldLandedCosting.QuotedPrice.ToString();
                            commenthistory.NewValue = newLandedCosting.QuotedPrice.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }
                    }
                }

                i = 0;
                FOBPricing newFOBPricing = null;
                FOBPricing oldFOBPricing = null;
                result = 0;
                result2 = 0;

                for (i = 0; i < grdDirectCosting.Rows.Count; i++)
                {
                    newLandedCosting = null;
                    oldLandedCosting = null;


                    if (newCosting.FOBPricingItemNew != null && newCosting.FOBPricingItemNew.Count > 0 && i < newCosting.FOBPricingItemNew.Count)
                    {
                        newFOBPricing = newCosting.FOBPricingItemNew.Find(delegate(FOBPricing LC) { return LC.SequenceNumber == (i + 1); });
                    }

                    if (CostingObject.FOBPricingItemNew != null && CostingObject.FOBPricingItemNew.Count > 0 && i < CostingObject.FOBPricingItemNew.Count)
                    {
                        oldFOBPricing = CostingObject.FOBPricingItemNew.Find(delegate(FOBPricing LC) { return LC.SequenceNumber == (i + 1); });
                    }

                    if (oldFOBPricing == null && newFOBPricing != null)
                    {
                        if (newFOBPricing.HaulageCharges.ToString() != "" && Double.TryParse(newFOBPricing.HaulageCharges.ToString(), out result) && result != 0)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                 + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "Haulage Charges (" + newFOBPricing.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                 + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                 + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString() + " " + "</span>"
                                 + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>";
                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 7;
                            commenthistory.FieldName = "Haulage Charges";
                            commenthistory.OldValue = "";
                            commenthistory.NewValue = result.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }

                        if (newFOBPricing.FOBMargin != 0)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + " Margin (" + newFOBPricing.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"

                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFOBPricing.FOBMargin.ToString() + " " + "</span>"

                                + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 7;
                            commenthistory.FieldName = "Margin";
                            commenthistory.OldValue = "";
                            commenthistory.NewValue = newFOBPricing.FOBMargin.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;

                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }
                        if (newFOBPricing.Discount != 0)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + " Discount (" + newFOBPricing.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFOBPricing.Discount.ToString() + " " + "</span>"
                                + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 7;
                            commenthistory.FieldName = "Discount";
                            commenthistory.OldValue = "";
                            commenthistory.NewValue = newFOBPricing.Discount.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }
                        if (newFOBPricing.QuotedPrice != 0)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + " Price Quoted (" + newFOBPricing.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFOBPricing.QuotedPrice.ToString() + " " + "</span>"
                                + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + "0" + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 7;
                            commenthistory.FieldName = "Price Quoted";
                            commenthistory.OldValue = "";
                            commenthistory.NewValue = newFOBPricing.QuotedPrice.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }
                    }
                    if (oldFOBPricing != null && newFOBPricing != null)
                    {
                        if (newFOBPricing.HaulageCharges.ToString() != "" && Double.TryParse(newFOBPricing.HaulageCharges.ToString(), out result) && oldFOBPricing.HaulageCharges.ToString() != "" && Double.TryParse(oldFOBPricing.HaulageCharges.ToString(), out result2) && result != result2)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                    + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Haulage Charges (" + newFOBPricing.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                    + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                    + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + result.ToString() + " " + "</span>"
                                    + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + result2.ToString() + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 7;
                            commenthistory.FieldName = "Haulage Charges";
                            commenthistory.OldValue = result2.ToString();
                            commenthistory.NewValue = result.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }
                        if (newFOBPricing.FOBMargin != oldFOBPricing.FOBMargin)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Margin (" + newFOBPricing.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFOBPricing.FOBMargin.ToString() + " " + "</span>"
                                + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + oldFOBPricing.FOBMargin.ToString() + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 7;
                            commenthistory.FieldName = "Margin";
                            commenthistory.OldValue = oldFOBPricing.FOBMargin.ToString();
                            commenthistory.NewValue = newFOBPricing.FOBMargin.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }
                        if (newFOBPricing.Discount != oldFOBPricing.Discount)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Discount (" + newFOBPricing.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFOBPricing.Discount.ToString() + " " + "</span>"
                                + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + oldFOBPricing.Discount.ToString() + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 7;
                            commenthistory.FieldName = "Discount";
                            commenthistory.OldValue = oldFOBPricing.Discount.ToString();
                            commenthistory.NewValue = newFOBPricing.Discount.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }

                        if (newFOBPricing.QuotedPrice != oldFOBPricing.QuotedPrice)
                        {
                            string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                                + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  Price Quoted (" + newFOBPricing.Code + ")" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "changed by" + " " + "</span>"
                                + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                                + "<span style='font-size:10px !important; font-weight: bold; color:#0000FF;'>" + newFOBPricing.QuotedPrice.ToString() + " " + "</span>"
                                + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "was " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + oldFOBPricing.QuotedPrice.ToString() + "</span>";

                            CommentHistory commenthistory = new CommentHistory();
                            commenthistory.TypeFlag = 7;
                            commenthistory.FieldName = "Price Quoted";
                            commenthistory.OldValue = oldFOBPricing.QuotedPrice.ToString();
                            commenthistory.NewValue = newFOBPricing.QuotedPrice.ToString();
                            commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                            commenthistory.UpdatedOn = DateTime.Now.ToString();
                            commenthistory.DetailDescription = x;
                            commenthistory.isBipl = false;
                            commenthistory.isPriceQuote = true;
                            newCosting.CommetHistoryItems.Add(commenthistory);
                        }
                    }
                }
            }
            else
            {
                string x = "<span style='font-size:10px !important; color:#A9A9A9;'>"
                        + DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + " </span>" + "<span style='font-size:10px !important; color:#000000;'>" + "  iKandi Costing Sheet" + " " + "</span>" + "<span style='font-size:10px !important; color:#A9A9A9;'>" + "Saved by" + " " + "</span>"
                        + "<span style='font-size:10px !important; color:#000000;'>" + FirstCharToUpper(ApplicationHelper.LoggedInUser.UserData.FullName) + " " + "</span>"
                        + "<span style='font-size:10px !important;color:#A9A9A9;'>" + "at " + "</span>" + "<span style='font-size:10px !important; font-weight: bold; color:#000000;'>" + DateTime.Now.ToString("hh:mm tt") + "</span>";

                CommentHistory commenthistory = new CommentHistory();
                commenthistory.TypeFlag = 1118;
                commenthistory.FieldName = "iKandi Costing Sheet";
                commenthistory.OldValue = "";
                commenthistory.NewValue = "";
                commenthistory.UpdatedByUserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                commenthistory.UpdatedOn = DateTime.Now.ToString();
                commenthistory.DetailDescription = x;
                commenthistory.isBipl = false;
                commenthistory.isPriceQuote = true;
                newCosting.CommetHistoryItems.Add(commenthistory);
            }
        }

        private void BindFormWithiKandiCostingData(Costing objCosting)//SKS
        {
            bool isValueChanged = false;
            bool isTotalChanged = false;

            double total = 0;
            double totalABC = 0;

            Label lbl;
            TextBox txt;
            TextBox txtRate;
            DropDownList ddl;
            bool IsVaChange = false;
            string ValueAdditionString = string.Empty;
            string VAWastageStr = "";
            string VARateStr = "";
            chkTooltip.Visible = true;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "CheckAgreementFromPage();", true);

            foreach (FabricCosting item in objCosting.FabricCostingItems)
            {
                ddl = tblCostingDetails.FindControl("ddlPrintType" + item.SequenceNumber.ToString()) as DropDownList;

                if (ddl.SelectedValue != item.PrintType)
                {
                    ListItem li = ddl.Items.FindByValue(item.PrintType);
                    lbl = tblCostingDetails.FindControl("lblPrintType" + item.SequenceNumber.ToString()) as Label;

                    lbl.Text = (li != null) ? lbl.Text + "<span class='tooltiptext'>" + "(" + li.Text + ")" + "</span>" : lbl.Text + "<span class='tooltiptext'>(Modified)</span>"; ;
                    lbl.CssClass = "changed_valueNew tooltip";
                }

                txt = tblCostingDetails.FindControl("txtFabric" + item.SequenceNumber.ToString()) as TextBox;

                if (txt.Text != item.Fabric)
                {
                    lbl = tblCostingDetails.FindControl("lblFabric" + item.SequenceNumber.ToString()) as Label;
                    lbl.Text = lbl.Text + "<span class='tooltiptextFabric'>" + "(" + item.Fabric + ")";
                    lbl.CssClass = "changed_valueNew tooltip";
                }

                if (item.SequenceNumber.ToString() == "1")
                {
                    if (txtFabricType1.Value != item.FabricType)
                    {
                        lbl = tblCostingDetails.FindControl("lblFabricType" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = lbl.Text + "<span class='tooltiptext'>" + "(" + item.FabricType + ")";
                        lbl.CssClass = "changed_valueNew tooltip";
                    }
                }
                else if (item.SequenceNumber.ToString() == "2")
                {
                    if (txtFabricType2.Value != item.FabricType)
                    {
                        lbl = tblCostingDetails.FindControl("lblFabricType" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = lbl.Text + "<span class='tooltiptext'>" + "(" + item.FabricType + ")";
                        lbl.CssClass = "changed_valueNew tooltip";
                    }
                }
                else if (item.SequenceNumber.ToString() == "3")
                {
                    if (txtFabricType3.Value != item.FabricType)
                    {
                        lbl = tblCostingDetails.FindControl("lblFabricType" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = lbl.Text + "<span class='tooltiptext'>" + "(" + item.FabricType + ")";
                        lbl.CssClass = "changed_valueNew tooltip";
                    }
                }
                else if (item.SequenceNumber.ToString() == "4")
                {
                    if (txtFabricType4.Value != item.FabricType)
                    {
                        lbl = tblCostingDetails.FindControl("lblFabricType" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = lbl.Text + "<span class='tooltiptext'>" + "(" + item.FabricType + ")";
                        lbl.CssClass = "changed_valueNew tooltip";
                    }
                }
                else if (item.SequenceNumber.ToString() == "5")
                {
                    if (txtFabricType5.Value != item.FabricType)
                    {
                        lbl = tblCostingDetails.FindControl("lblFabricType" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = lbl.Text + "<span class='tooltiptext'>" + "(" + item.FabricType + ")";
                        lbl.CssClass = "changed_valueNew tooltip";
                    }
                }
                else if (item.SequenceNumber.ToString() == "6")
                {
                    if (txtFabricType6.Value != item.FabricType)
                    {
                        lbl = tblCostingDetails.FindControl("lblFabricType" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = lbl.Text + "<span class='tooltiptext'>" + "(" + item.FabricType + ")";
                        lbl.CssClass = "changed_valueNew tooltip";
                    }
                }
                else if (item.SequenceNumber.ToString() == "7")
                {
                    if (txtFabricType7.Value != item.FabricType)
                    {
                        lbl = tblCostingDetails.FindControl("lblFabricType" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = lbl.Text + "<span class='tooltiptext'>" + "(" + item.FabricType + ")";
                        lbl.CssClass = "changed_valueNew tooltip";
                    }
                }
                else if (item.SequenceNumber.ToString() == "8")
                {
                    if (txtFabricType8.Value != item.FabricType)
                    {
                        lbl = tblCostingDetails.FindControl("lblFabricType" + item.SequenceNumber.ToString()) as Label;
                        lbl.Text = lbl.Text + "<span class='tooltiptext'>" + "(" + item.FabricType + ")";
                        lbl.CssClass = "changed_valueNew tooltip";
                    }
                }
                // Value Addition 1_1
                ddl = tblCostingDetails.FindControl("ddlValueAddition" + item.SequenceNumber + "_1") as DropDownList;
                txt = tblCostingDetails.FindControl("txtVAWastage" + item.SequenceNumber + "_1") as TextBox;
                txtRate = tblCostingDetails.FindControl("txtVARate" + item.SequenceNumber + "_1") as TextBox;

                string[] txtWastage1 = txt.Text.Split('%');

                IsVaChange = false;
                ValueAdditionString = string.Empty;



                if (ddl.SelectedValue != "")
                {
                    if (Convert.ToInt32(ddl.SelectedValue) != item.ValueAdditionId1)
                    {
                        IsVaChange = true;
                        ListItem li = ddl.Items.FindByValue(item.ValueAdditionId1.ToString());
                        if (li.Text == "Select")
                            ValueAdditionString += "V.A: " + " " + ",";
                        else
                            ValueAdditionString += "V.A: " + li.Text + ",";
                    }
                }
                if (((txtWastage1[0].Trim() == string.Empty) ? 0 : Convert.ToDouble(txtWastage1[0].Trim())) != item.VAWastage1)
                {
                    IsVaChange = true;
                    VAWastageStr = item.VAWastage1 == 0 ? " " : item.VAWastage1.ToString();

                    if (ValueAdditionString == string.Empty)
                        ValueAdditionString += "V.A Wastage: " + VAWastageStr + ",";
                    else
                        ValueAdditionString += " Wastage: " + VAWastageStr + ",";
                }
                if (((txtRate.Text == string.Empty) ? 0 : Convert.ToDouble(txtRate.Text)) != item.VARate1)
                {
                    IsVaChange = true;
                    VARateStr = item.VARate1 == 0 ? " " : item.VARate1.ToString();

                    if (ValueAdditionString == string.Empty)
                        ValueAdditionString += "V.A Rate: " + VARateStr;
                    else
                        ValueAdditionString += " Rate: " + VARateStr;
                }
                ValueAdditionString = ValueAdditionString.TrimEnd(',');
                if (IsVaChange)
                {
                    lbl = tblCostingDetails.FindControl("lblValueAddition" + item.SequenceNumber + "_1") as Label;
                    lbl.Text = lbl.Text + "<span class='AvlueAddtextFabricavrage'>" + "(" + ValueAdditionString + ")";
                    lbl.CssClass = "changed_ValueAdd Valtooltip";
                }

                IsVaChange = false;
                ValueAdditionString = string.Empty;
                // Value Addition 1_2
                ddl = tblCostingDetails.FindControl("ddlValueAddition" + item.SequenceNumber + "_2") as DropDownList;
                txt = tblCostingDetails.FindControl("txtVAWastage" + item.SequenceNumber + "_2") as TextBox;
                txtRate = tblCostingDetails.FindControl("txtVARate" + item.SequenceNumber + "_2") as TextBox;

                string[] txtWastage2 = txt.Text.Split('%');

                if (ddl.SelectedValue != "")
                {
                    if (Convert.ToInt32(ddl.SelectedValue) != item.ValueAdditionId2)
                    {
                        IsVaChange = true;
                        ListItem li = ddl.Items.FindByValue(item.ValueAdditionId2.ToString());
                        if (li.Text == "Select")
                            ValueAdditionString += "V.A: " + " " + ",";
                        else
                            ValueAdditionString += "V.A: " + li.Text + ",";
                    }
                }
                if (((txtWastage2[0].Trim() == string.Empty) ? 0 : Convert.ToDouble(txtWastage2[0].Trim())) != item.VAWastage2)
                {
                    IsVaChange = true;
                    VAWastageStr = item.VAWastage2 == 0 ? " " : item.VAWastage2.ToString();

                    if (ValueAdditionString == string.Empty)
                        ValueAdditionString += "V.A Wastage: " + VAWastageStr + ",";
                    else
                        ValueAdditionString += " Wastage: " + VAWastageStr + ",";
                }
                if (((txtRate.Text == string.Empty) ? 0 : Convert.ToDouble(txtRate.Text)) != item.VARate2)
                {
                    IsVaChange = true;
                    VARateStr = item.VARate2 == 0 ? " " : item.VARate2.ToString();

                    if (ValueAdditionString == string.Empty)
                        ValueAdditionString += "V.A Rate: " + VARateStr;
                    else
                        ValueAdditionString += " Rate: " + VARateStr;
                }
                ValueAdditionString = ValueAdditionString.TrimEnd(',');
                if (IsVaChange)
                {
                    lbl = tblCostingDetails.FindControl("lblValueAddition" + item.SequenceNumber + "_2") as Label;
                    lbl.Text = lbl.Text + "<span class='AvlueAddtextFabricavrage'>" + "(" + ValueAdditionString + ")";
                    lbl.CssClass = "changed_ValueAdd Valtooltip";
                }

                txt = tblCostingDetails.FindControl("txtWidth" + item.SequenceNumber.ToString()) as TextBox;

                if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != item.Width)
                {
                    lbl = tblCostingDetails.FindControl("lblWidth" + item.SequenceNumber.ToString()) as Label;
                    lbl.Text = lbl.Text + "<span class='tooltiptextFabricavrage'>" + "(" + item.Width.ToString() + ")";
                    lbl.CssClass = "changed_valueNew tooltip";
                }

                txt = tblCostingDetails.FindControl("txtAverage" + item.SequenceNumber.ToString()) as TextBox;

                if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != item.Average)
                {
                    lbl = tblCostingDetails.FindControl("lblAverage" + item.SequenceNumber.ToString()) as Label;
                    lbl.Text = lbl.Text + "<span class='tooltiptextFabricavrage'>" + "(" + item.Average.ToString("0.000") + ")";
                    lbl.CssClass = "changed_valueNew tooltip";
                }

                txt = tblCostingDetails.FindControl("txtRate" + item.SequenceNumber.ToString()) as TextBox;

                if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != item.Rate)
                {
                    lbl = tblCostingDetails.FindControl("lblRate" + item.SequenceNumber.ToString()) as Label;
                    lbl.Text = lbl.Text + "<span class='tooltiptext'>" + "(" + item.Rate.ToString() + ")";
                    lbl.CssClass = "changed_valueNew tooltip";
                }

                txt = tblCostingDetails.FindControl("txtAmount" + item.SequenceNumber.ToString()) as TextBox;

                if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != item.Amount)
                {
                    lbl = tblCostingDetails.FindControl("lblAmount" + item.SequenceNumber.ToString()) as Label;
                    lbl.Text = lbl.Text + "<span class='tooltiptext'>" + "(" + item.Amount.ToString() + ")";
                    lbl.CssClass = "changed_valueNew tooltip";
                }

                txt = tblCostingDetails.FindControl("lblTotalPrice" + item.SequenceNumber.ToString()) as TextBox;

                if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != Math.Round(item.Total))
                {
                    lbl = tblCostingDetails.FindControl("lblTPrice" + item.SequenceNumber.ToString()) as Label;
                    lbl.Text = lbl.Text + "<span class='tooltiptext'>" + "(" + Math.Round(item.Total).ToString() + ")";
                    lbl.CssClass = "changed_valueNew tooltip";
                    isValueChanged = true;
                }

                total = total + Math.Round(item.Total);
            }

            if (isValueChanged)
            {
                lblTotalA.Text = lblTotalA.Text + "<span class='tooltiptext'>" + "(" + total.ToString() + ")";
                lblTotalA.CssClass = "changed_valueNew tooltip";
                isTotalChanged = true;
            }

            totalABC = total;

            total = 0;
            isValueChanged = false;

            //CMT ------------

            if (((txtChargesValue11.Text == string.Empty) ? 0 : Convert.ToDouble(txtChargesValue11.Text)) != objCosting.SAM)
            {
                lblChargesValue11.Text = lblChargesValue11.Text + "<span class='tooltiptextF'>" + "(" + objCosting.SAM.ToString("0.0") + ")" + "</span>";
                lblChargesValue11.CssClass = "changed_valueNew tooltip";
            }
            if (((txtOB.Text == string.Empty) ? 0 : Convert.ToDouble(txtOB.Text)) != objCosting.OB_WS)
            {
                lblOB.Text = lblOB.Text + "<span class='tooltiptextFabricavrage'>" + "(" + objCosting.OB_WS.ToString() + ")" + "</span>";
                lblOB.CssClass = "changed_valueNew tooltip";
            }
            if (((txtChargesValue1.Text == string.Empty) ? 0 : Convert.ToDouble(txtChargesValue1.Text)) != objCosting.CMTF)
            {
                lblChargesValue1.Text = lblChargesValue1.Text + "<span class='tooltiptextFabricavrage'>" + "(" + objCosting.CMTF.ToString("0.00") + ")" + "</span>";
                lblChargesValue1.CssClass = "changed_valueNew tooltip";
                isValueChanged = true;
            }
            total = total + Math.Round(objCosting.CMTF);

            if (isValueChanged)
            {
                lblTotalB.Text = lblTotalB.Text + "<span class='tooltiptextFabricavrage'>" + "(" + total.ToString() + ")";
                lblTotalB.CssClass = "changed_valueNew tooltip";
                isTotalChanged = true;
            }

            totalABC = totalABC + total;
            total = 0;
            isValueChanged = false;
            if (objCosting != null)
            {
                for (int irow = 0; irow < gdvAccessory.Rows.Count; irow++)
                {
                    txt = gdvAccessory.Rows[irow].FindControl("txtItems") as TextBox;

                    if (objCosting.AccessoryItems.Count > irow)
                    {

                        if (txt.Text != objCosting.AccessoryItems[irow].Item)
                        {
                            lbl = gdvAccessory.Rows[irow].FindControl("lblItems") as Label;
                            lbl.Text = lbl.Text + "<span class='tooltiptextFabric'>" + "(" + objCosting.AccessoryItems[irow].Item + ")";
                            lbl.CssClass = "changed_valueNew tooltip";
                        }

                        txt = gdvAccessory.Rows[irow].FindControl("txtUnitQty") as TextBox;

                        if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != objCosting.AccessoryItems[irow].Quantity)
                        {
                            lbl = gdvAccessory.Rows[irow].FindControl("lblUnitQty") as Label;
                            lbl.Text = lbl.Text + "<span class='tooltiptextAccessory'>" + "(" + objCosting.AccessoryItems[irow].Quantity.ToString("0.00") + ")";
                            lbl.CssClass = "changed_valueNew tooltip";
                        }

                        txt = gdvAccessory.Rows[irow].FindControl("txtRate") as TextBox;

                        if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != objCosting.AccessoryItems[irow].Rate)
                        {
                            lbl = gdvAccessory.Rows[irow].FindControl("lblRate") as Label;
                            lbl.Text = lbl.Text + "<span class='tooltiptextAccessory'>" + "(" + objCosting.AccessoryItems[irow].Rate.ToString("0.00") + ")";
                            lbl.CssClass = "changed_valueNew tooltip";
                        }


                        txt = gdvAccessory.Rows[irow].FindControl("lblTotalAmount") as TextBox;

                        if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != Math.Round(objCosting.AccessoryItems[irow].Amount))
                        {
                            lbl = gdvAccessory.Rows[irow].FindControl("lblAmount") as Label;
                            lbl.Text = lbl.Text + "<span class='tooltiptextRightShort'>" + "(" + objCosting.AccessoryItems[irow].Amount.ToString() + ")";
                            lbl.CssClass = "changed_valueNew tooltip";
                            isValueChanged = true;
                        }

                        total = total + Math.Round(objCosting.AccessoryItems[irow].Amount);
                    }
                }
            }

            if (isValueChanged)
            {
                lblTotalC.Text = lblTotalC.Text + "<span class='tooltiptextFabricavrage'>" + "(" + total.ToString() + ")";
                lblTotalC.CssClass = "changed_valueNew tooltip";
                isTotalChanged = true;
            }

            totalABC = totalABC + total;
            total = 0;
            isValueChanged = false;
            if (objCosting != null)
            {
                foreach (Processes item in objCosting.ProcessItems)
                {
                    if (item.SeqNo != 11)
                    {
                        if (item.SeqNo > objCosting.ProcessItems.Count)
                        {
                            txt = gvdProcessDetails.Rows[item.SeqNo - 1].FindControl("txtPItems") as TextBox;

                            if (txt.Text != item.Item)
                            {
                                lbl = gvdProcessDetails.Rows[item.SeqNo - 1].FindControl("lblPItems") as Label;
                                lbl.Text = lbl.Text + "<span class='tooltiptextFabric'>" + "(" + item.Item.ToString() + ")";
                                lbl.CssClass = "changed_valueNew tooltip";
                            }

                            txt = gvdProcessDetails.Rows[item.SeqNo - 1].FindControl("lblTotalAmount") as TextBox;

                            if (((txt.Text == string.Empty) ? 0 : Convert.ToDouble(txt.Text)) != item.Amount)
                            {
                                lbl = gvdProcessDetails.Rows[item.SeqNo - 1].FindControl("lblTAmount") as Label;
                                lbl.Text = lbl.Text + "<span class='tooltiptextRightShort'>" + "(" + item.Amount.ToString() + ")";
                                lbl.CssClass = "changed_valueNew tooltip";
                                isValueChanged = true;
                            }
                        }
                    }
                    total = total + Math.Round(item.Amount);
                }
            }
            if (isValueChanged)
            {
                lblTotalD.Text = lblTotalC.Text + "<span class='tooltiptextFabricavrage'>" + "(" + total.ToString() + ")";
                lblTotalD.CssClass = "changed_valueNew tooltip";
                isTotalChanged = true;
            }

            totalABC = totalABC + total;
            total = 0;
            isValueChanged = false;

            totalABC = totalABC + total;
            isValueChanged = false;

            if (isTotalChanged)
            {
                lblTotalABC.Text = lblTotalABC.Text + "<span class='tooltiptextF'>" + "(" + totalABC.ToString("0.00") + ")" + "</span>";
                lblTotalABC.CssClass = "changed_valueNew tooltip";
            }

            isTotalChanged = false;

            if (((txtFrtUptoFinalDest.Text == string.Empty) ? 0 : Convert.ToDouble(txtFrtUptoFinalDest.Text)) != objCosting.FrieghtUptoFinalDestination)
            {
                lblFrtUptoFinalDest.Text = lblFrtUptoFinalDest.Text + "<span class='tooltiptextF'>" + "(" + objCosting.FrieghtUptoFinalDestination.ToString("0.00") + ")" + "</span>";
                lblFrtUptoFinalDest.CssClass = "changed_valueNew tooltip";
            }
            if (((txtGCW.Text == string.Empty) ? 0 : Convert.ToDouble(txtGCW.Text)) != objCosting.CostingCutWastage)
            {
                lblGCW.Text = lblGCW.Text + "<span class='tooltiptextF'>" + "(" + objCosting.CostingCutWastage.ToString("0.00") + ")" + "</span>";
                lblGCW.CssClass = "changed_valueNew tooltip";
            }
            if (((txtGVW.Text == string.Empty) ? 0 : Convert.ToDouble(txtGVW.Text)) != objCosting.CostingVAWastage)
            {
                lblGVW.Text = lblGCW.Text + "<span class='tooltiptextF'>" + "(" + objCosting.CostingVAWastage.ToString("0.00") + ")" + "</span>";
                lblGVW.CssClass = "changed_valueNew tooltip";
            }
            if (((txtMarkupOnUnitCtc.Text == string.Empty) ? 0 : Convert.ToDouble(txtMarkupOnUnitCtc.Text)) != objCosting.MarkupOnUnitCTC)
            {
                lblMarkupOnUnitCtc.Text = lblMarkupOnUnitCtc.Text + "<span class='tooltiptextF'>" + "(" + objCosting.MarkupOnUnitCTC.ToString("0.00") + ")" + "</span>";
                lblMarkupOnUnitCtc.CssClass = "changed_valueNew tooltip";
            }
            if (((txtComm.Text == string.Empty) ? 0 : Convert.ToDouble(txtComm.Text)) != objCosting.CommisionPercent)
            {
                lblComm.Text = lblComm.Text + "<span class='tooltiptextF'>" + "(" + objCosting.CommisionPercent.ToString("0.00") + ")" + "</span>";
                lblComm.CssClass = "changed_valueNew tooltip";
            }
            if (((txtConvRate.Text == string.Empty) ? 0 : Convert.ToDouble(txtConvRate.Text)) != objCosting.ConversionRate)
            {
                lblConvRate.Text = lblConvRate.Text + "<span class='tooltiptextF'>" + "(" + objCosting.ConversionRate.ToString("0.00") + ")" + "</span>";
                lblConvRate.CssClass = "changed_valueNew tooltip";
            }
            if (((txtPriceQuoted.Text == string.Empty) ? 0 : Convert.ToDouble(txtPriceQuoted.Text)) != objCosting.PriceQuoted)
            {
                lblPriceQuoted.Text = lblPriceQuoted.Text + "<span class='tooltiptextF'>" + "(" + objCosting.PriceQuoted.ToString("0.00") + ")" + "</span>";
                lblPriceQuoted.CssClass = "changed_valueNew tooltip";
            }

            lbliKandiHistory.Text = objCosting.iKandiChangesHistory.Replace("$$", "<br/>").Replace("<br/><br/>", "<br/>");
        }

        protected void grdLandedCosting_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DataRowView rowView = (DataRowView)e.Row.DataItem;

                int Mode = 0;
                int Process = 0;
                //if (rowView["ModeCostID"].ToString() != "")
                //{
                //    Mode = Convert.ToInt32(rowView["ModeCostID"].ToString());
                //}
                //else
                //{
                //    Mode = -1;
                //}
                //if (rowView["ProcessCostId"].ToString() != "")
                //{
                //    Process = Convert.ToInt32(rowView["ProcessCostId"].ToString());
                //}
                //else
                //{
                //    Process = -1;
                //}
                TextBox txtModeCost = (TextBox)e.Row.FindControl("txtModeCost");
                TextBox txtProcessCost = (TextBox)e.Row.FindControl("txtProcessCost");
                //DataTable dtMode = AdminControllerInstance.GetBindModeCost();
                //DropDownList ddlModeCost = e.Row.FindControl("ddlModeCost") as DropDownList;
                //ddlModeCost.DataSource = dtMode;
                //ddlModeCost.DataTextField = "ModeCost";
                //ddlModeCost.DataValueField = "Id";
                //ddlModeCost.DataBind();
                //ddlModeCost.Items.Insert(0, new ListItem("Select", "-1"));

                //if (Mode == -1)
                //{
                //    ddlModeCost.SelectedValue = "1";
                //}
                //else
                //{
                //    ddlModeCost.SelectedValue = Mode.ToString();
                //}

                //DataTable dtProcess = AdminControllerInstance.GetBindProcessCost();
                //DropDownList ddlProcessCost = e.Row.FindControl("ddlProcessCost") as DropDownList;
                //ddlProcessCost.DataSource = dtProcess;
                //ddlProcessCost.DataTextField = "ProcessCost";
                //ddlProcessCost.DataValueField = "ID";
                //ddlProcessCost.DataBind();
                //ddlProcessCost.Items.Insert(0, new ListItem("Select", "-1"));

                //if (Process == -1)
                //{
                //    ddlProcessCost.SelectedValue = "1";
                //}
                //else
                //{
                //    ddlProcessCost.SelectedValue = Process.ToString();
                //}

                double PriceQuoted = txtPriceQuoted.Text == "" ? 0 : Convert.ToDouble(txtPriceQuoted.Text);
                TextBox txtAgreedPrice = (TextBox)e.Row.FindControl("txtAgreedPrice");
                CheckBox ckhLandedCosting = (CheckBox)e.Row.FindControl("ckhLandedCosting");
                if (PriceQuoted <= 0)
                {
                    txtAgreedPrice.Attributes.Add("disabled", "disabled");
                    ckhLandedCosting.InputAttributes.Add("disabled", "disabled");
                }

            }
            currencusymbol();//Add code by bharat feb-7
        }
        //Add code by bharat feb-7
        protected void currencusymbol()
        {
            foreach (GridViewRow row in grdLandedCosting.Rows)
            {

                TextBox txtFobBoutique = row.FindControl("txtFobBoutique") as TextBox;
                Label lblcur = row.FindControl("lblcur") as Label;
                TextBox txtHandling = row.FindControl("txtHandling") as TextBox;
                Label lblprocesscurr = row.FindControl("lblprocesscurr") as Label;
                string cu = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(ClientID);
                if (string.IsNullOrEmpty(txtFobBoutique.Text))
                {

                    txtFobBoutique.Text = cu + "  " + txtFobBoutique.Text;
                }
                TextBox txtFobIkandi = row.FindControl("txtFobIkandi") as TextBox;
                if (string.IsNullOrEmpty(txtFobIkandi.Text))
                {
                    string fob = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType(Convert.ToInt32(ClientID));
                    txtFobIkandi.Text = fob + "  " + txtFobIkandi.Text;
                }

                lblcur.Text = cu;
                lblprocesscurr.Text = cu;


            }
        }
        //End Code

        protected void btnSaveConfirm_Click(object sender, EventArgs e)
        {
            //divConfirmBox.Visible = true;
            divConfirmBox.Attributes.Add("style", "display: block !important");
        }

        protected void btnOpenCosting_Click(object sender, EventArgs e)
        {
            string script = string.Empty;
            for (int i = 1; i <= 8; i++)
            {
                string febricType = "";
                TextBox txtFabric = tblCostingDetails.FindControl("txtFabric" + i) as TextBox;
                DropDownList ddlFebType = tblCostingDetails.FindControl("DDLFabricType" + i) as DropDownList;
                if (i == 1)
                {
                    febricType = txtFabricType1.Value.ToString().Trim();
                }
                else if (i == 2)
                {
                    febricType = txtFabricType2.Value.ToString().Trim();
                }
                else if (i == 3)
                {
                    febricType = txtFabricType3.Value.ToString().Trim();
                }
                else if (i == 4)
                {
                    febricType = txtFabricType4.Value.ToString().Trim();
                }
                else if (i == 5)
                {
                    febricType = txtFabricType5.Value.ToString().Trim();
                }
                else if (i == 6)
                {
                    febricType = txtFabricType6.Value.ToString().Trim();
                }
                else if (i == 7)
                {
                    febricType = txtFabricType7.Value.ToString().Trim();
                }
                else if (i == 8)
                {
                    febricType = txtFabricType8.Value.ToString().Trim();
                }

                if (txtFabric.Text != "")
                {
                    DataSet ds = this.CostingControllerInstanceNew.GetRegisterFabric_Details(txtFabric.Text.Trim());
                    if (ddlFebType.SelectedValue.ToString() == "3" || ddlFebType.SelectedValue.ToString() == "4")
                    {
                        string[] Print = febricType.Split(new[] { " --- " }, StringSplitOptions.None);
                        if (Print.Length > 1)
                        {
                            DataSet ds1 = this.CostingControllerInstanceNew.GetRegisterPrint_Details(Print[1].Trim());
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                            }
                            else
                            {
                                divConfirmBox.Visible = false;
                                script = "ShowHideValidationBox(true, 'Please fill registered Print for fabric " + i + ".', 'Costing Sheet');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                                return;
                            }
                        }
                        else
                        {
                            divConfirmBox.Visible = false;
                            script = "ShowHideValidationBox(true, 'Please fill registered Print for fabric " + i + ".', 'Costing Sheet');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                            return;
                        }
                    }
                }
            }

            for (int p = 0; p < gvdProcessDetails.Rows.Count; p++)
            {
                TextBox txtItems = gvdProcessDetails.Rows[p].FindControl("txtPItems") as TextBox;
                if (txtItems.Text != "")
                {
                    string item = txtItems.Text.Trim();
                    DataSet ds = this.CostingControllerInstanceNew.GetRegisterProcess_Details(item);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        divConfirmBox.Visible = false;
                        script = "ShowHideValidationBox(true, 'Please fill registered Process item for Process item " + (p + 1) + ".', 'Costing Sheet');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                        return;
                    }
                }
            }
            if (SaveCostingData("OpenCostingBIPL"))
            {
                divConfirmBox.Attributes.Add("style", "display: none !important");
                string url = COSTING_SHEET_URL + "?cid=" + CostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();
                Response.Redirect(url, false);
                SetMsg("success", "Costing Sheet saved successfully.");
            }
            else
            {
                divConfirmBox.Visible = false;
                ShowMsg("error", "Some error occurred in saving Costing Sheet.");
            }
        }

        protected void btnAcceptClose_Click(object sender, EventArgs e)
        {
            string script = string.Empty;
            for (int i = 1; i <= 8; i++)
            {
                string febricType = "";
                TextBox txtFabric = tblCostingDetails.FindControl("txtFabric" + i) as TextBox;
                DropDownList ddlFebType = tblCostingDetails.FindControl("DDLFabricType" + i) as DropDownList;
                if (i == 1)
                {
                    febricType = txtFabricType1.Value.ToString().Trim();
                }
                else if (i == 2)
                {
                    febricType = txtFabricType2.Value.ToString().Trim();
                }
                else if (i == 3)
                {
                    febricType = txtFabricType3.Value.ToString().Trim();
                }
                else if (i == 4)
                {
                    febricType = txtFabricType4.Value.ToString().Trim();
                }
                else if (i == 5)
                {
                    febricType = txtFabricType5.Value.ToString().Trim();
                }
                else if (i == 6)
                {
                    febricType = txtFabricType6.Value.ToString().Trim();
                }
                else if (i == 7)
                {
                    febricType = txtFabricType7.Value.ToString().Trim();
                }
                else if (i == 8)
                {
                    febricType = txtFabricType8.Value.ToString().Trim();
                }

                if (txtFabric.Text != "")
                {
                    DataSet ds = this.CostingControllerInstanceNew.GetRegisterFabric_Details(txtFabric.Text.Trim());
                    if (ddlFebType.SelectedValue.ToString() == "3" || ddlFebType.SelectedValue.ToString() == "4")
                    {
                        string[] Print = febricType.Split(new[] { " --- " }, StringSplitOptions.None);
                        if (Print.Length > 1)
                        {
                            DataSet ds1 = this.CostingControllerInstanceNew.GetRegisterPrint_Details(Print[1].Trim());
                            if (ds1.Tables[0].Rows.Count > 0)
                            {
                            }
                            else
                            {
                                divConfirmBox.Visible = false;
                                script = "ShowHideValidationBox(true, 'Please fill registered Print for fabric " + i + ".', 'Costing Sheet');";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                                return;
                            }
                        }
                        else
                        {
                            divConfirmBox.Visible = false;
                            script = "ShowHideValidationBox(true, 'Please fill registered Print for fabric " + i + ".', 'Costing Sheet');";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                            return;
                        }
                    }
                }
            }

            for (int p = 0; p < gvdProcessDetails.Rows.Count; p++)
            {
                TextBox txtItems = gvdProcessDetails.Rows[p].FindControl("txtPItems") as TextBox;
                if (txtItems.Text != "")
                {
                    string item = txtItems.Text.Trim();
                    DataSet ds = this.CostingControllerInstanceNew.GetRegisterProcess_Details(item);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                    }
                    else
                    {
                        divConfirmBox.Visible = false;
                        script = "ShowHideValidationBox(true, 'Please fill registered Process item for Process item " + (p + 1) + ".', 'Costing Sheet');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                        return;
                    }
                }
            }
            if (SaveCostingData("CloseCostingBIPL"))
            {
                divConfirmBox.Attributes.Add("style", "display: none !important");
                string url = COSTING_SHEET_URL + "?cid=" + CostingId + "&StyleID=" + this.StyleID.ToString() + "&ClientID=" + this.ClientID.ToString() + "&DepartmentID=" + this.DepartmentID.ToString();
                Response.Redirect(url, false);
                SetMsg("success", "Costing Sheet saved successfully.");
            }
            else
            {
                divConfirmBox.Visible = false;
                ShowMsg("error", "Some error occurred in saving Costing Sheet.");
            }
        }

        protected void btnUpdateAccessoryGrd_Click(object sender, EventArgs e)
        {
            gdvAccessory.DataSource = null;
            gdvAccessory.DataBind();
            int thisClientId = Convert.ToInt32(ddlBuyer.SelectedValue);
            int thisDeptId = Convert.ToInt32(hdnDeptId.Value);
            int thisCostingId = Convert.ToInt32(hdnCosting.Value);
            List<Accessories> objAccessCollection = CostingControllerInstanceNew.GetAccessoryBy_Client_Dept_Change(thisClientId, thisDeptId, thisCostingId);
            AccessoryCount = objAccessCollection.Count;
            gdvAccessory.DataSource = objAccessCollection;
            gdvAccessory.DataBind();
            UpdPnlAccessary.Update();
        }
    }
}