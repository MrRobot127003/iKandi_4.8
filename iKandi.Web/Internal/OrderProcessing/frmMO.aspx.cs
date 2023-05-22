using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using Style = iKandi.Common.Style;

namespace iKandi.Web
{
    public partial class frmMO : BasePage
    {
        //Added By abhishek 23/4/2015
        public int UcompanyId
        {
            get;
            set;
        }

        //END
        public int desigId
        {
            get;
            set;
        }
        public int DeptId
        {
            get;
            set;
        }
        public string UserId
        {
            get;
            set;
        }
        public string SessionId
        {
            get;
            set;
        }
        public int ClientId
        {
            get;
            set;
        }
        public int AM
        {
            get;
            set;
        }

        //Added Abhishek
        public bool IsClient_
        {
            get
            {
                return IsClient;
            }
            set
            {
                IsClient = value;
            }

        }
        public bool IsClientDept_
        {
            get
            {
                return IsClientDept;
            }
            set
            {
                IsClientDept = value;
            }

        }
        #region Event Handlers

        private bool IsBtnSeach;
        private bool IsTabClicked;
        private string tabvalue = "";
        private bool IsClient = false;
        private bool IsClientDept = false;

        BuyingHouseController objBuyingHouseController = new BuyingHouseController();
        OrderController objOrderController = new OrderController();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Page.Form.DefaultFocus = btn_search.ClientID;

            // Edit by surendra on 20 may 2013
            this.desigId = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.Designation);
            this.DeptId = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID);
            this.UserId = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
            this.SessionId = System.Web.HttpContext.Current.Session.SessionID;
            this.UcompanyId = ApplicationHelper.LoggedInUser.UserData.CompanyID;//abhi
            //ddlClients.Items.Insert(0, new ListItem("ALL", "0"));
            string dclient = ddlClients.SelectedValue;
            string dept = ddlDepartment.SelectedValue;
            string ParentDept = ddlParentDeptID.SelectedValue;


            if (!IsPostBack)
            {
                BindSalesYear();
                BindBuyingHouse();
                BindAMList();

                if (Request.QueryString["DelayStatusId"] != null)
                {
                    mb.DelayStatusId = Convert.ToInt32(Request.QueryString["DelayStatusId"].ToString());
                }

                if (Request.QueryString["TaskCompleteOrderDetailId"] != null)
                {
                    mb.TaskCompleteOrderDetailId = Convert.ToInt32(Request.QueryString["TaskCompleteOrderDetailId"].ToString());
                }

                if (Request.QueryString["StyleNumber"] != null)
                {
                    mb.StyleNumber = Convert.ToString(Request.QueryString["StyleNumber"].ToString());
                }

                if (Request.QueryString["OrderDetailId"] != null)
                {
                    mb.OutHouseOrderDetailIds = Request.QueryString["OrderDetailId"].ToString();
                    IsBtnSeach = false;
                }
                //addded by uday
                int iUserId = 0;
                string Flag = string.Empty;
                string v = Request.QueryString["Emailid"];
                if (v != null && v != "")
                {
                    Flag = v;
                    if (ApplicationHelper.LoggedInUser.UserData != null)

                        iUserId = ApplicationHelper.LoggedInUser.UserData.UserID;

                    UserDetails usd = new UserDetails();


                    SessionInfo sessionInfo = new SessionInfo();

                    iKandi.Common.User user = null;

                    user = this.MembershipControllerInstance.GetUser(Convert.ToInt32(iUserId));
                    ApplicationHelper objApplicationHelper = new ApplicationHelper();
                    DataSet ds = objApplicationHelper.GetNotifactionRemarks(user.DesignationID, Convert.ToInt32(Flag), "Form", iUserId);
                }

                //end added by uday
                // ddlDepartment.SelectedItem.Text = "all";
                //ddlDepartment.Items.Insert(0, new ListItem("ALL", "0"));
                // ddlDepartment.SelectedValue = "1";

                if (Session["Client"] != null)
                {
                    if (Convert.ToInt32(Session["Client"]) == 1)
                    {
                        string[] ClientDept = this.ClientControllerInstance.GetClientDeptByUserId(ApplicationHelper.LoggedInUser.UserData.UserID);

                        this.ClientId = Convert.ToInt32(ClientDept[0]);
                        this.DeptId = Convert.ToInt32(ClientDept[1]);
                        if (ApplicationHelper.LoggedInUser.UserData.ClientID == 0)
                            IsClient = true;
                        if (this.DeptId != 0)
                        {
                            IsClientDept = true;
                        }

                        ddlDateType.SelectedValue = "1";

                        //Added By Ashish on 14/4/2015
                        //DropdownHelper.FillDropDownClient(ddlClients, Convert.ToInt32(ddlBH.SelectedValue), true, this.ClientId);

                        DropdownHelper.FillDropDownClientDetails(ddlClients, Convert.ToInt32(ddlBH.SelectedValue), true, this.ClientId, Convert.ToInt32(ddlDateType.SelectedValue), ddlYear.SelectedItem.Text, ApplicationHelper.LoggedInUser.UserData.UserID, Convert.ToInt32(Ddlam.SelectedValue));
                        //END
                        //Added By Ashish on 16/4/2015
                        //DropdownHelper.FillDropDownDepartment(ddlDepartment, this.ClientId, ApplicationHelper.LoggedInUser.UserData.UserID, true, IsClient, IsClientDept);
                        DropdownHelper.FillParentDepartmentID(ddlParentDeptID, this.ClientId, ApplicationHelper.LoggedInUser.UserData.UserID, true, IsClient, IsClientDept, Convert.ToInt32(ddlDateType.SelectedValue), ddlYear.SelectedItem.Text, Convert.ToInt32(Ddlam.SelectedValue));
                        DropdownHelper.FillDropDownDepartmentById(ddlDepartment, this.ClientId, ApplicationHelper.LoggedInUser.UserData.UserID, true, IsClient, IsClientDept, Convert.ToInt32(ddlDateType.SelectedValue), ddlYear.SelectedItem.Text, Convert.ToInt32(Ddlam.SelectedValue), Convert.ToInt32(ddlParentDeptID.SelectedValue));

                        //END
                    }

                    else
                    {
                        if (ApplicationHelper.LoggedInUser.UserData.CompanyID == 2)
                        {
                            ddlDateType.SelectedValue = "1";
                            //Added By Ashish on 14/4/2015
                            //DropdownHelper.FillDropDownClient(ddlClients, Convert.ToInt32(ddlBH.SelectedValue), true, 0);
                            DropdownHelper.FillDropDownClientDetails(ddlClients, Convert.ToInt32(ddlBH.SelectedValue), true, this.ClientId, Convert.ToInt32(ddlDateType.SelectedValue), ddlYear.SelectedItem.Text, ApplicationHelper.LoggedInUser.UserData.UserID, Convert.ToInt32(Ddlam.SelectedValue));
                            //END
                        }
                        if (ApplicationHelper.LoggedInUser.UserData.CompanyID == 1)
                        {
                            ddlDateType.SelectedValue = "2";
                            // DropdownHelper.BindClientsIkandi(ddlClients as ListControl);
                            DropdownHelper.BindClientsForIkandi(ddlClients as ListControl, Convert.ToInt32(ddlBH.SelectedValue), this.ClientId, Convert.ToInt32(ddlDateType.SelectedValue), ddlYear.SelectedItem.Text, ApplicationHelper.LoggedInUser.UserData.UserID);

                            int level = ApplicationHelper.LoggedInUser.UserData.Level;

                            if (level == 1 || level == 2 || level == 3 || level == 4)
                            {
                                ddlClients.Items.Insert(0, new ListItem("ALL", "0"));
                                //  ddlDepartment.Items.Insert(0, new ListItem("ALL", "0"));
                            }
                        }
                    }
                }


                DropdownHelper.FillUnit(ddlUnit, ApplicationHelper.LoggedInUser.UserData.DesignationID, ApplicationHelper.LoggedInUser.UserData.UserID);
                if (!string.IsNullOrEmpty(Request.Params["ClientID"]))
                {
                    int ClientID = Convert.ToInt32(Request.Params["ClientID"]);

                    if (ddlClients.Items.FindByValue(ClientID.ToString()) != null)
                        ddlClients.SelectedValue = ClientID.ToString();
                }
                if (!string.IsNullOrEmpty(Request.Params["AM"]))
                {
                    int AM = Convert.ToInt32(Request.Params["AM"]);

                    if (Ddlam.Items.FindByValue(AM.ToString()) != null)
                        Ddlam.SelectedValue = AM.ToString();
                }

                // Edit by surendra on 20 may 2013
                if (!string.IsNullOrEmpty(Request.Params["ClientParentDeptId"]))
                {
                    int ClientParentDeptId = Convert.ToInt32(Request.Params["ClientParentDeptId"]);

                    if (ddlParentDeptID.Items.FindByValue(ClientParentDeptId.ToString()) != null)
                        ddlParentDeptID.SelectedValue = ClientParentDeptId.ToString();
                }
                if (!string.IsNullOrEmpty(Request.Params["ClientDeptId"]))
                {
                    int ClientDeptId = Convert.ToInt32(Request.Params["ClientDeptId"]);

                    if (ddlDepartment.Items.FindByValue(ClientDeptId.ToString()) != null)
                        ddlDepartment.SelectedValue = ClientDeptId.ToString();
                }

                if (!string.IsNullOrEmpty(Request.Params["UnitId"]))
                {
                    int UnitId = Convert.ToInt32(Request.Params["UnitId"]);

                    if (ddlUnit.Items.FindByValue(UnitId.ToString()) != null)
                        ddlUnit.SelectedValue = UnitId.ToString();
                }
                if (!string.IsNullOrEmpty(Request.Params["OutHouse"]))
                {
                    int OutHouse = Convert.ToInt32(Request.Params["OutHouse"]);

                    if (ddlOutHouse.Items.FindByValue(OutHouse.ToString()) != null)
                        ddlOutHouse.SelectedValue = OutHouse.ToString();
                }
                // ------------------Edit BY SURENDRA ON SHIPPED VALUE----------------------------
                //if (!string.IsNullOrEmpty(Request.Params["IsUnShipped"]))
                //{
                //    bool IsUnShipped =Convert.ToBoolean(Request.Params["IsUnShipped"]);

                //    if (ChkIsUnShipped.FindControl(IsUnShipped.ToString()) != null)
                //        ChkIsUnShipped.Checked = IsUnShipped;
                //}
                //---------------------end-----------------------------------------------------------

                if (!string.IsNullOrEmpty(Request.Params["SerialNumber"]))
                {
                    txtsearch.Value = Request.Params["SerialNumber"];
                }

                DropdownHelper.BindFilteredStatusMode(ddlStatusMode, ApplicationHelper.LoggedInUser.UserData.DesignationID);
                if (mb.DelayStatusId > 0 || mb.TaskCompleteOrderDetailId > 0)
                {
                    DropdownHelper.BindFilteredStatusModeBySequence(ddlStatusModeSequence, ApplicationHelper.LoggedInUser.UserData.DesignationID, true);
                }
                else
                {
                    DropdownHelper.BindFilteredStatusModeBySequence(ddlStatusModeSequence, ApplicationHelper.LoggedInUser.UserData.DesignationID, false);
                }
                //by surendra on 20 may 2013


                if (ddlStatusModeSequence.Items.IndexOf(
                                 ddlStatusModeSequence.Items.FindByValue(((int)TaskMode.EXFACTORIED).ToString())) >
                             -1)
                {
                    ddlStatusModeSequence.SelectedValue = ((int)TaskMode.Approved_toEx).ToString();
                }
                else
                {
                    int countStatusModeSequenceDropDown = ddlStatusModeSequence.Items.Count;

                    ddlStatusModeSequence.SelectedIndex = countStatusModeSequenceDropDown - 1;
                }

                ViewState["__StatusMode"] = ddlStatusModeSequence.SelectedValue;

                GetPermissionFilter();

                //if (ApplicationHelper.LoggedInUser.UserData.CompanyID == 2)
                //{
                //  ddlOrder1.SelectedValue = "4";
                //  ddlOrder2.SelectedValue = "1";
                //  ddlOrder3.SelectedValue = "2";
                //  ddlOrder4.SelectedValue = "3";
                //  //ddlOrder5.SelectedValue = "-1";
                //}
                //else
                //{
                //  ddlOrder1.SelectedValue = "6";
                //  ddlOrder2.SelectedValue = "1";
                //  ddlOrder3.SelectedValue = "2";
                //  ddlOrder4.SelectedValue = "3";
                //}

                Session["Sales"] = "0";
                tabMerch.Visible = true;


            }
            Page.Form.DefaultButton = btn_search.UniqueID;
            Page.Form.DefaultButton = btn_Bottom_search.UniqueID;
            //if (txtsearch.Value != "" || ddlClients.SelectedIndex > 0 ||
            //    Convert.ToInt16(ddlStatusMode.SelectedValue) > 0 ||
            //    ddlStatusModeSequence.SelectedValue != Convert.ToString(ViewState["__StatusMode"]) || ddlUnit.SelectedIndex > 0)
            if (txtsearch.Value != "" || ddlClients.SelectedIndex > 0 ||
             Convert.ToDouble(ddlStatusMode.SelectedValue) > 0 ||
             ddlStatusModeSequence.SelectedValue != Convert.ToString(ViewState["__StatusMode"]) || ddlUnit.SelectedIndex > 0)
            {
                IsBtnSeach = true;
            }

            string eventTarget = (Request["__EVENTTARGET"] == null) ? string.Empty : Request["__EVENTTARGET"];
            if (eventTarget == "ChildWindowPostBack" || eventTarget.Contains("btn_search"))
            {
            }
            if (eventTarget == "ChildWindowPostBack" || eventTarget.Contains("btn_Bottom_search"))
            {
            }
            int ii = Convert.ToInt32(hdn_btnSearch.Value);
            if (ii == 0)
            {
                Session["btn_check"] = 0;
            }
            if (Session["btn_check"] != null)
            {
                if (Convert.ToInt32(Session["btn_check"]) == 1)
                {
                    if (Session["Flag"] != null)
                    {
                        bool flag = Convert.ToBoolean(Session["Flag"]);
                        if (flag)
                        {
                            string strSeaVal = "";
                            strSeaVal = Request.QueryString["SeaVal"];
                            if (strSeaVal == "Yes")
                            {
                                if (Session["SearchValues"] != null)
                                {
                                    var dtTemp = (DataTable)Session["SearchValues"];
                                    string[] s1 = dtTemp.Rows[0]["dcFromDate"].ToString().Split(' ');
                                    string[] s2 = dtTemp.Rows[0]["dcFromDate"].ToString().Split(' ');
                                    var obj = new BuyingHouseController();
                                    txtfrom.Value = obj.GetDateInStringFormatBLL(s1[0]);
                                    if (txtfrom.Value == "01 Jan 01 (Mon)")
                                        txtfrom.Value = "";
                                    txtTo.Value = obj.GetDateInStringFormatBLL(s2[0]);
                                    if (txtTo.Value == "01 Jan 01 (Mon)")
                                        txtfrom.Value = "";
                                    txtsearch.Value = dtTemp.Rows[0]["dcsearchText"].ToString();
                                    txtFabric.Value = dtTemp.Rows[0]["dcFabricName"].ToString();
                                }
                            }
                        }
                    }
                }
            }
            if (Request.QueryString["winopn"] != "a")
            {
                Session["OrderDetailIds" + ApplicationHelper.LoggedInUser.UserData.UserID] = "";
            }

            tabvalue = hdntabvalue.Value;
            if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Production_FactoryManager &&
                tabvalue == "Tab10")
            {
                MakeTabVisible();
            }
            HandleCallbacks();
            if (IsBtnSeach == false || hdntabvalue.Value == "Tab10")
            {
                if (eventTarget == "")
                {
                    if (!Page.IsPostBack)
                    {
                        BindControls();
                    }

                }
                else
                {
                    //if (Convert.ToInt32(hdnClientId.Value) != -1)
                    //{
                    DropdownHelper.FillDropDownClientDetails(ddlClients, Convert.ToInt32(ddlBH.SelectedValue), true, this.ClientId, Convert.ToInt32(ddlDateType.SelectedValue), ddlYear.SelectedItem.Text, ApplicationHelper.LoggedInUser.UserData.UserID, Convert.ToInt32(Ddlam.SelectedValue));
                    ddlClients.SelectedValue = hdnClientId.Value;
                    //ddlBH.SelectedValue = hdnBH.Value;
                    //DropdownHelper.FillDropDownDepartmentById(ddlDepartment, Convert.ToInt32(ddlClients.SelectedValue), ApplicationHelper.LoggedInUser.UserData.UserID, true, IsClient, IsClientDept, Convert.ToInt32(ddlDateType.SelectedValue), ddlYear.SelectedItem.Text);
                    //ddlDepartment.SelectedValue = hdnDDLDepartment.Value;
                    //}
                }

            }

            else
            {
                if (Convert.ToInt32(hdnClientId.Value) != -1)
                {
                    DropdownHelper.FillDropDownClientDetails(ddlClients, Convert.ToInt32(ddlBH.SelectedValue), true, this.ClientId, Convert.ToInt32(ddlDateType.SelectedValue), ddlYear.SelectedItem.Text, ApplicationHelper.LoggedInUser.UserData.UserID, Convert.ToInt32(Ddlam.SelectedValue));
                    ddlClients.SelectedValue = hdnClientId.Value;
                    //ddlBH.SelectedValue = hdnBH.Value;
                }
                //if (Convert.ToInt32(hdnDDLDepartment.Value) != -1)
                //{
                DropdownHelper.FillParentDepartmentID(ddlParentDeptID, Convert.ToInt32(ddlClients.SelectedValue), ApplicationHelper.LoggedInUser.UserData.UserID, true, IsClient, IsClientDept, Convert.ToInt32(ddlDateType.SelectedValue), ddlYear.SelectedItem.Text, Convert.ToInt32(Ddlam.SelectedValue));
                ddlParentDeptID.SelectedValue = hdnParentDepartment.Value;

                DropdownHelper.FillDropDownDepartmentById(ddlDepartment, Convert.ToInt32(ddlClients.SelectedValue), ApplicationHelper.LoggedInUser.UserData.UserID, true, IsClient, IsClientDept, Convert.ToInt32(ddlDateType.SelectedValue), ddlYear.SelectedItem.Text, Convert.ToInt32(Ddlam.SelectedValue), Convert.ToInt32(hdnParentDepartment.Value));
                ddlDepartment.SelectedValue = hdnDDLDepartment.Value;


                //}
                //if (Convert.ToInt32(hdnStatusMode.Value) != -1)
                //{
                //    DropdownHelper.BindFilteredStatusMode(ddlStatusMode, ApplicationHelper.LoggedInUser.UserData.DesignationID);
                //    ddlStatusMode.SelectedValue = hdnStatusMode.Value;
                //}
                //if (Convert.ToInt32(hdnStatusModeTo.Value) != -1)
                //{
                //    DropdownHelper.BindFilteredStatusModeBySequence(ddlStatusModeSequence, ApplicationHelper.LoggedInUser.UserData.DesignationID, true);
                //    ddlStatusModeSequence.SelectedValue = hdnStatusModeTo.Value;
                //}


            }



            if (IsBtnSeach && (hdntabvalue.Value == "Tab2" || hdntabvalue.Value == "Tab3"))
            {
                if (eventTarget == "")
                {
                    if (!Page.IsPostBack)
                    {
                        BindControls();
                    }
                }
            }
            if (eventTarget == "ChildWindowPostBack" && hdntabvalue.Value == "Tab3")
            {
                BindControls();
            }

            if (eventTarget.EndsWith("mb$GridView1") || eventTarget.EndsWith("mf$GridView1") ||
                eventTarget.EndsWith("ma$GridAccessories") || eventTarget.EndsWith("mc$GridView1") ||
                eventTarget.EndsWith("ms$GridView1") || eventTarget.EndsWith("ShipmentOffer1$GridView1"))
            {
                BindControls();
            }

            else if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Production_FactoryManager &&
                     tabvalue == "Tab5")
            {
                BindControls();
            }
            else if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Production_Assistant &&
                     tabvalue == "Tab4")
            {
                BindControls();
            }


            if (Session["Flag"] != null)
            {
                bool flag = Convert.ToBoolean(Session["Flag"]);
                if (flag)
                {
                    string strSeaVal = "";
                    strSeaVal = Request.QueryString["SeaVal"];
                    if (strSeaVal == "Yes")
                    {
                        if (Session["SearchValues"] != null)
                        {
                            var dtTemp = (DataTable)Session["SearchValues"];
                            ddlBH.SelectedValue = Convert.ToString(dtTemp.Rows[0]["dcBuyingHouseId"]);
                            ddlClients.SelectedValue = Convert.ToString(dtTemp.Rows[0]["dcClientId"]);
                            Ddlam.SelectedValue = Convert.ToString(dtTemp.Rows[0]["dcAM"]);
                            ddlDepartment.SelectedValue = Convert.ToString(dtTemp.Rows[0]["dcClientDeptId"]);
                            ddlParentDeptID.SelectedValue = Convert.ToString(dtTemp.Rows[0]["dcClientParentDeptId"]);

                            // Edit by surendra on 20 may 2013
                            ddlUnit.SelectedValue = Convert.ToString(dtTemp.Rows[0]["dcUnitId"]);
                            ddlOutHouse.SelectedValue = Convert.ToString(dtTemp.Rows[0]["dcOutHouse"]);
                            // ------------------Edit BY SURENDRA ON SHIPPED VALUE----------------------------

                            //ChkIsUnShipped.Checked = Convert.ToBoolean(dtTemp.Rows[0]["IsUnShipped"]);
                            //----------------------------end
                            ddlStatusMode.SelectedValue = Convert.ToString(dtTemp.Rows[0]["dcStatusMode"]);
                            ddlStatusModeSequence.SelectedValue =
                                Convert.ToString(dtTemp.Rows[0]["dcStatusModeSequence"]);
                            ddlOrder1.SelectedValue = Convert.ToString(dtTemp.Rows[0]["dcOrderBy1"]);
                            ddlOrder2.SelectedValue = Convert.ToString(dtTemp.Rows[0]["dcOrderBy2"]);
                            ddlOrder3.SelectedValue = Convert.ToString(dtTemp.Rows[0]["dcOrderBy3"]);
                            ddlOrder4.SelectedValue = Convert.ToString(dtTemp.Rows[0]["dcOrderBy4"]);

                        }
                    }
                }
            }

            //btn_search_Click(null, null);
            if (!IsPostBack)
            {
                if (txtsearch.Value != "")
                {
                    btn_search_Click(null, null);
                  
                }
            }

        }

        #endregion

        #region Private Methods

        private void MakeTabVisible()
        {
            //  tabStitch.Visible = true;
            //ms.Visible = true;
            //tabShipmentOffer.Visible = true;
        }

        // Callback routing handler
        private void BindControls()
        {
            //if (!IsPostBack)
            //{



            //    //hdnSales.Value = "0";

            //}
            SelectTabs();
        }

        private void SelectTabs()
        {
            ////hdn_btnSearch.Value = "1";
            int UserID = ApplicationHelper.LoggedInUser.UserData.UserID;
            if (tabvalue == "Tab1" || tabvalue == "Tab2" || tabvalue == "Tab3" || tabvalue == "Tab4" ||
                tabvalue == "Tab5" || tabvalue == "Tab6" || tabvalue == "Tab7" || tabvalue == "Tab8" ||
                tabvalue == "Tab9" || tabvalue == "Tab10")
            {
                ShowTab(tabvalue);
            }
            else if (tabMerch.Visible)
            {
                ShowTab("Tab1");
            }


            else
            {
                ShowTab("Tab1");
            }
        }

        protected void lnkBtnTab_Click(object sender, CommandEventArgs e)
        {
            lnkBtnTab.CssClass = "";

            IsTabClicked = true;
            ShowTab(e.CommandName);
            ((LinkButton)sender).CssClass = "selectedTabs";
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            if (Session["PageIndex"] != null)
                Session["PageIndex"] = "0";
            objOrderController.DeleteSession(System.Web.HttpContext.Current.Session.SessionID);
            int ii = Convert.ToInt32(hdn_btnSearch.Value);
            if (ii == 0)
            {
                Session["btn_check"] = 0;
            }
            //hdnWeekFrom.Value = ddlWeekFrom.SelectedValue;
            //hdnWeekTo.Value = ddlWeekTo.SelectedValue; 

            //added by abhishek on 29/1/2016
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "BindClientFromPage();", true);
           // Page.ClientScript.RegisterStartupScript(Page.GetType(), "popup", "BindDllStatusModeddlSequenceFromPage();", true);
            //end by abhishek on 29/1/2016

            int UserID = ApplicationHelper.LoggedInUser.UserData.UserID;
            if (tabvalue == "Tab1" || tabvalue == "Tab2" || tabvalue == "Tab3" || tabvalue == "Tab4" ||
                tabvalue == "Tab5" || tabvalue == "Tab6" || tabvalue == "Tab7" || tabvalue == "Tab8" ||
                tabvalue == "Tab9")
            {
                ShowTab(tabvalue);
            }
            else if (tabMerch.Visible)
            {
                ShowTab("Tab1");
            }

            else
            {
                ShowTab("Tab1");
            }
            hdn_btnSearch.Value = "1";
            // Add by Ravi kumar



        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            // SaveAccessoriesData();        
        }

        private void ShowTab(string Tab)
        {
            if (Tab == "Tab1")
            {
                lnkBtnTab.CssClass = "selectedTabs";
                hdntabvalue.Value = "Tab1";
                mb.Visible = true;

                mb.searchText = txtsearch.Value;
                mb.FabricName = txtFabric.Value;

                mb.DateType = Convert.ToInt32(ddlDateType.SelectedValue);

                //comment By Ravi on 7 oct 2014

                mb.Years = ddlYear.SelectedValue.ToString();
                mb.FromDate = DateHelper.ParseDate(txtfrom.Value).Value;
                mb.ToDate = DateHelper.ParseDate(txtTo.Value).Value;

                mb.BuyingHouseId = BindIntPropertyWithDropDownSelectedValue(ddlBH, 0);
                // mb.ClientId = BindIntPropertyWithDropDownSelectedValue(ddlClients, 0);
                mb.ClientId = Convert.ToInt32(hdnClientId.Value);
                mb.AM = BindIntPropertyWithDropDownSelectedValue(Ddlam, 0);
                mb.AM = BindIntPropertyWithDropDownSelectedValue(Ddlam, 0);
                mb.ClientDeptId = Convert.ToInt32(hdnDDLDepartment.Value);
                mb.ClientParentDeptId = Convert.ToInt32(hdnParentDepartment.Value);

                // Edit by surendra on 20 may 2013
                //edited by abhishek on 29/1/2016
                mb.UnitId = BindIntPropertyWithDropDownSelectedValue(ddlUnit, 0);
                // ------------------Edit BY SURENDRA ON SHIPPED VALUE----------------------------
                mb.OutHouse = BindIntPropertyWithDropDownSelectedValue(ddlOutHouse, 0);
                mb.IsUnShipped = ChkIsUnShipped.Checked == true ? 1 : 2;
                //----------------------End
                // mb.StatusMode = BindIntPropertyWithDropDownSelectedValue(ddlStatusMode, 0);
                mb.StatusMode_ForIntial = Convert.ToDouble(ddlStatusMode.SelectedValue);
                // mb.StatusMode_ForDouble = Convert.ToDouble(ddlStatusMode.SelectedValue);
                // hdnStatusMode.Value = Convert.ToString(mb.StatusMode);
                hdnStatusMode.Value = Convert.ToString(mb.StatusMode_ForIntial);

                //mb.StatusModeSequence = BindIntPropertyWithDropDownSelectedValue(ddlStatusModeSequence,
                //                                                                      (int)
                //                                                                      TaskMode.Approved_toEx
                //                                                                          );
                mb.StatusMode_ForDouble = Convert.ToDouble(ddlStatusModeSequence.SelectedValue);
                // hdnStatusModeTo.Value = Convert.ToString(mb.StatusModeSequence);
                hdnStatusModeTo.Value = Convert.ToString(mb.StatusMode_ForDouble);
                //end by abhishek 29/1/2016
                //added by abhishek on 4/11/2016
                mb.OrderTypes = BindIntPropertyWithDropDownSelectedValue(ddlordertype, 0);

                mb.OrderBy1 = Convert.ToInt32(ddlOrder1.SelectedValue);
                mb.OrderBy2 = Convert.ToInt32(ddlOrder2.SelectedValue);
                mb.OrderBy3 = Convert.ToInt32(ddlOrder3.SelectedValue);
                mb.OrderBy4 = Convert.ToInt32(ddlOrder4.SelectedValue);

                //if (ApplicationHelper.LoggedInUser.UserData.CompanyID == 2)
                //{
                //  mb.OrderBy1 = BindIntPropertyWithDropDownSelectedValue(ddlOrder1, 4);
                //  mb.OrderBy2 = BindIntPropertyWithDropDownSelectedValue(ddlOrder2, 1);
                //  mb.OrderBy3 = BindIntPropertyWithDropDownSelectedValue(ddlOrder3, 2);
                //  mb.OrderBy4 = BindIntPropertyWithDropDownSelectedValue(ddlOrder4, 3);
                //}
                //else
                //{
                //  mb.OrderBy1 = BindIntPropertyWithDropDownSelectedValue(ddlOrder1, 6);
                //  mb.OrderBy2 = BindIntPropertyWithDropDownSelectedValue(ddlOrder2, 1);
                //  mb.OrderBy3 = BindIntPropertyWithDropDownSelectedValue(ddlOrder3, 2);
                //  mb.OrderBy4 = BindIntPropertyWithDropDownSelectedValue(ddlOrder4, 3);
                //}



                mb.OrderDetailIds =
                    Convert.ToString(Session["OrderDetailIds" + ApplicationHelper.LoggedInUser.UserData.UserID]);
                string eventTarget = (Request["__EVENTTARGET"] == null) ? string.Empty : Request["__EVENTTARGET"];
                if (eventTarget == "" || IsTabClicked)
                {
                    //if (hdn_btnSearch.Value == "0")
                    //{
                    (mb).MOPagingFromMainPage(1);
                    hdn_btnSearch.Value = "1";
                    //}
                }
                hdnSelectFilter.Value = "0";

            }


        }

        private void HandleCallbacks()
        {
            string callback = Request.Params["callback"];

            if (string.IsNullOrEmpty(callback))
                return;

            // *** We have an action try and match it to a handler

        }


        private void BindBuyingHouse()
        {
            // Change by Ravi kumar on 07-oct-2014
            //ddlBH.DataSource = objBuyingHouseController.GetAllBuyingHouseBAL(ApplicationHelper.LoggedInUser.UserData.CompanyID);
            ddlBH.DataSource = objBuyingHouseController.GetBuyingHouseById(ApplicationHelper.LoggedInUser.UserData.CompanyID, Convert.ToInt32(ddlDateType.SelectedValue), ddlYear.SelectedItem.Text);
            ddlBH.DataTextField = "CompanyName";
            ddlBH.DataValueField = "ID";
            ddlBH.DataBind();

        }

        private void BindAMList()
        {
            Ddlam.DataSource = objBuyingHouseController.GetAMList(Convert.ToInt32(ddlDateType.SelectedValue), ddlYear.SelectedItem.Text);
            Ddlam.DataTextField = "UserName";
            Ddlam.DataValueField = "ID";
            Ddlam.DataBind();
        }

        // Create By Ravi kumar on 07-oct-2014
        private void BindSalesYear()
        {
            DataTable dtYear = objBuyingHouseController.GetAllSalesYearBAL();
            ddlYear.DataSource = dtYear;
            ddlYear.DataTextField = "YearRange";
            ddlYear.DataValueField = "Years";
            ddlYear.DataBind();
            string sYear = Convert.ToString(DateTime.Now.Year);
            for (int i = 0; i < dtYear.Rows.Count; i++)
            {
                string[] YearArray = dtYear.Rows[i]["Years"].ToString().Split(',');
                string FromYear = YearArray[0].Trim().ToString();
                string ToYear = YearArray[1].Trim().ToString();
                if (sYear == FromYear)
                {
                    ddlYear.SelectedValue = dtYear.Rows[i]["Years"].ToString();
                }
                else if (sYear == ToYear)
                {
                    ddlYear.SelectedValue = dtYear.Rows[i]["Years"].ToString();
                }

            }
            // for temprary set 15,16 year
            ddlYear.SelectedValue = "2023,2024";
        }

        private int BindIntPropertyWithDropDownSelectedValue(DropDownList ddl, int defaultValue)
        {
            int value = 0;
            int oValue;

            if (ddl == null)
            {
                value = defaultValue;
            }
            else
            {
                if (int.TryParse(ddl.SelectedValue, out oValue))
                {
                    if (oValue == 0 && defaultValue == 0)
                    {
                        value = oValue;
                    }
                    else if (oValue == 0 && defaultValue != 0)
                    {
                        value = defaultValue;
                    }
                    else
                    {
                        value = oValue;
                    }
                }
            }

            return value;
        }

        //private double BinddoublePropertyWithDropDownSelectedValue(DropDownList ddl, int defaultValue)
        //{
        //    int value = 0;
        //    int oValue;

        //    if (ddl == null)
        //    {
        //        value = defaultValue;
        //    }
        //    else
        //    {
        //        if (double.TryParse(ddl.SelectedValue, out oValue))
        //        {
        //            if (oValue == 0 && defaultValue == 0)
        //            {
        //                value = oValue;
        //            }
        //            else if (oValue == 0 && defaultValue != 0)
        //            {
        //                value = defaultValue;
        //            }
        //            else
        //            {
        //                value = oValue;
        //            }
        //        }
        //    }

        //    return value;
        //}

        #endregion

        //protected void ddlBH_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    //Added By Ashish on 14/4/2015
        //    //DropdownHelper.FillDropDownClient(ddlClients, Convert.ToInt32(ddlBH.SelectedValue), true, 0);
        //    DropdownHelper.FillDropDownClientDetails(ddlClients, Convert.ToInt32(ddlBH.SelectedValue), true, this.ClientId, Convert.ToInt32(ddlDateType.SelectedValue), ddlYear.SelectedItem.Text, ApplicationHelper.LoggedInUser.UserData.UserID);
        //    DropdownHelper.FillDropDownDepartmentById(ddlDepartment, Convert.ToInt32(ddlClients.SelectedValue), ApplicationHelper.LoggedInUser.UserData.UserID, true, IsClient, IsClientDept, Convert.ToInt32(ddlDateType.SelectedValue), ddlYear.SelectedItem.Text);
        //    //END
        //}

        protected void btnHidden_Click(object sender, EventArgs e)
        {
            int UserID = ApplicationHelper.LoggedInUser.UserData.UserID;
            if (hdnDelayOrderDetailIds.Value != "0")
            {
                mb.OutHouseOrderDetailIds = hdnDelayOrderDetailIds.Value;
                IsBtnSeach = false;
            }

            if (tabvalue == "Tab1" || tabvalue == "Tab2" || tabvalue == "Tab3" || tabvalue == "Tab4" ||
                tabvalue == "Tab5" || tabvalue == "Tab6" || tabvalue == "Tab7" || tabvalue == "Tab8" ||
                tabvalue == "Tab9")
            {
                ShowTab(tabvalue);
            }
            else if (tabMerch.Visible)
            {
                ShowTab("Tab1");
            }

            else
            {
                ShowTab("Tab1");
            }
        }

        protected void GetPermissionFilter()
        {
            List<MOOrderDetails> mop = new List<MOOrderDetails>();
            int DeptId = ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID;
            int DesigId = ApplicationHelper.LoggedInUser.UserData.DesignationID;
            DataTable dtpermission = new DataTable();
            //dtpermission = objOrderController.GetMOPermissionFilter(DeptId, DesigId);
            dtpermission = objOrderController.GetMO_OrderByFilter(DeptId, DesigId);
            if (dtpermission.Rows.Count > 0)
            {
                ddlOrder1.SelectedValue = dtpermission.Rows[0]["OrderBy1"].ToString() == "" ? "0" : dtpermission.Rows[0]["OrderBy1"].ToString();
                ddlOrder2.SelectedValue = dtpermission.Rows[0]["OrderBy2"].ToString() == "" ? "0" : dtpermission.Rows[0]["OrderBy2"].ToString();
                ddlOrder3.SelectedValue = dtpermission.Rows[0]["OrderBy3"].ToString() == "" ? "0" : dtpermission.Rows[0]["OrderBy3"].ToString();
                ddlOrder4.SelectedValue = dtpermission.Rows[0]["OrderBy4"].ToString() == "" ? "0" : dtpermission.Rows[0]["OrderBy4"].ToString();

            }
            else
            {
                if (ApplicationHelper.LoggedInUser.UserData.CompanyID == 2)
                {
                    ddlOrder1.SelectedValue = "4";
                    ddlOrder2.SelectedValue = "1";
                    ddlOrder3.SelectedValue = "2";
                    ddlOrder4.SelectedValue = "3";
                    //mb.OrderBy1 = BindIntPropertyWithDropDownSelectedValue(ddlOrder1, 4);
                    //mb.OrderBy2 = BindIntPropertyWithDropDownSelectedValue(ddlOrder2, 1);
                    //mb.OrderBy3 = BindIntPropertyWithDropDownSelectedValue(ddlOrder3, 2);
                    //mb.OrderBy4 = BindIntPropertyWithDropDownSelectedValue(ddlOrder4, 3);
                }
                else
                {
                    ddlOrder1.SelectedValue = "6";
                    ddlOrder2.SelectedValue = "1";
                    ddlOrder3.SelectedValue = "2";
                    ddlOrder4.SelectedValue = "3";
                    //mb.OrderBy1 = BindIntPropertyWithDropDownSelectedValue(ddlOrder1, 6);
                    //mb.OrderBy2 = BindIntPropertyWithDropDownSelectedValue(ddlOrder2, 1);
                    //mb.OrderBy3 = BindIntPropertyWithDropDownSelectedValue(ddlOrder3, 2);
                    //mb.OrderBy4 = BindIntPropertyWithDropDownSelectedValue(ddlOrder4, 3);
                }
            }
        }         
    }
}