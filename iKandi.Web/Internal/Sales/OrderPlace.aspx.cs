using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using iKandi.Web.Components;
using iKandi.BLL;
using iKandi.Common;
using System.Data;

namespace iKandi.Web.Internal.Sales
{
    [Serializable]
    public partial class OrderPlace : System.Web.UI.Page
    {
        public int OrderID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["orderid"]))
                {
                    return Convert.ToInt32(Request.QueryString["orderid"]);
                }
                return -1;
            }
        }

        OrderPlaceController objOrderPlaceController = new OrderPlaceController();
        ClientController objClientController = new ClientController();
        PermissionController objPermissionController = new PermissionController();

        String OrderFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["order.folder"];

        string Status = string.Empty;
        int Rowcount = 0;
        int SplitNo = 0;
        bool IsOldHistory = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            hdnuserid.Value = Convert.ToString(ApplicationHelper.LoggedInUser.UserData.UserID);
            bool deptPermission = PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_PARENT_DEPARTMENT);

            if (!IsPostBack)
            {
                UserPermission();
                BindControls();
                PopulateOrderData(null);

            }
        }

        private void UserPermission()
        {
            DataTable dt = objPermissionController.GetUserPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, (int)iKandi.Common.AppModuleColumn.ORDER_FORM_SUBMIT_BUTTON).Tables[0];
            bool readPermission = false;
            bool writePermission = false;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                readPermission = Convert.ToBoolean(dt.Rows[i]["PermisionRead"]);
                writePermission = Convert.ToBoolean(dt.Rows[i]["PermisionWrite"]);
            }


            if (writePermission == false)
            {
                btnSubmit.Enabled = false;

            }
            else
            {
                btnSubmit.Enabled = true;
            }
        }

        private void BindControls()
        {
            lblOrderDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
            hdnExpectedDate.Value = DateHelper.GetNextMondayDate().ToString();
            DropdownHelper.BindAllClients(ddlClient as ListControl);
        }

        private void BindMode(bool isIkandiClient, int CostingId, int ClientId, int DepartmentId, DropDownList ddlMode, int ModeId, int OrderDetailId)
        {
            List<iKandi.Common.OrderPlace> objList = objOrderPlaceController.Get_modes_For_OrderPlace(isIkandiClient, CostingId, ClientId, DepartmentId, OrderDetailId);
            ddlMode.DataSource = objList;
            ddlMode.DataTextField = "ModeCode";
            ddlMode.DataValueField = "ModeId";
            ddlMode.DataBind();
            ddlMode.Items.Insert(0, new ListItem("Select ...", "-1"));
            ddlMode.SelectedValue = ModeId.ToString();
            if (isIkandiClient)
            {
                int j = 1;
                for (int i = 0; i < objList.Count; i++)
                {
                    if (objList[i].EnableMode == false) { ddlMode.Items[j].Attributes.Add("disabled", "disabled"); }
                    j++;
                }
            }
        }

        private void BindCountryCode(int ClientId, DropDownList ddlCountryCode, int CountryCodeId)
        {
            List<ClientCountryCode> objCountyCodeList = objOrderPlaceController.GetClientCountryCode(ClientId);
            if (objCountyCodeList.Count > 0)
            {
                ddlCountryCode.DataSource = objCountyCodeList;
                ddlCountryCode.DataTextField = "CountryCode";
                ddlCountryCode.DataValueField = "CountryId";
                ddlCountryCode.DataBind();

                if (CountryCodeId > 0)
                    ddlCountryCode.SelectedValue = CountryCodeId.ToString();
            }
        }

        private void PopulateOrderData(List<ContractDetails> orderDetailCollection)
        {
            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            hdnOrderId.Value = this.OrderID.ToString();
            iKandi.Common.OrderPlace order = new Common.OrderPlace();
            if (orderDetailCollection == null)
            {
                if (this.OrderID == -1)
                {
                    gvDetailSection.DataSource = null;
                    gvDetailSection.DataBind();
                    txtStyleNumber.Attributes.Remove("disabled");
                }
                else
                {
                    hdnIsEmptyRow.Value = "0";
                    order = objOrderPlaceController.Get_order_by_OrderId_ForOrderPlace(OrderID, UserId);
                    IsOldHistory = objOrderPlaceController.IsOldHistoryCommentsValid(OrderID);
                    if (IsOldHistory)
                    {
                        divOldHistory.Visible = true;
                        divOldComment.Visible = true;
                    }

                    lblOrderDate.Text = order.OrderDate.ToString("dd MMM yy (ddd)");
                    txtStyleNumber.Text = order.Style.StyleNumber;
                    txtStyleNumber.Attributes.Add("disabled", "disabled");
                    hdnStyleNumber.Value = order.Style.StyleNumber;
                    hdnStyleID.Value = order.StyleID.ToString();
                    hdnOldStyleId.Value = order.StyleID.ToString();
                    txtSerialNo.Text = order.SerialNumber;
                    hdnIsIkandiUser.Value = order.IsIkandiUser.ToString().ToLower();
                    hdnCostingId.Value = order.Costing.CostingID.ToString();
                    hdnIsIkandiClient.Value = order.IsIkandiClient.ToString().ToLower();
                    hdnConversionRate.Value = order.ConversionRate.ToString();
                    hdnCurrencySign.Value = order.Costing.CurrencySign;
                    ddlDeliverType.SelectedValue = order.DeliveryType.ToString();

                    if (order.TotalOrderPrice > 0)
                    {
                        txtTotalOrderValue.Text = order.TotalOrderPrice >= 100000 ? "₹ (" + Math.Round(order.TotalOrderPrice / 100000, 2).ToString() + " L)" : "(" + order.TotalOrderPrice.ToString() + ")";
                    }
                    txtTotalQty.Text = order.TotalQuantity > 0 ? order.TotalQuantity.ToString("N0") : "";
                    lblTotQtyUnit.Text = order.TotalQuantity > 0 ? "Pcs." : "";
                    txtAccntMgr.Text = order.AccountManagerName;

                    hdnStatusModeSequence.Value = order.StatusModeSequence.ToString();
                    ddlClient.SelectedValue = order.ClientID.ToString();
                    hdnClientId.Value = order.ClientID.ToString();

                    FillParentDepartment(order.ClientID, order.ParentDepartmentID);

                    hdnParentDeptName.Value = order.ParentDepartmentName;

                    if (order.Style.SampleImageURL1 != string.Empty)
                    {
                        imgFront.ImageUrl = ResolveUrl("~/Uploads/Style/thumb-" + order.Style.SampleImageURL1);
                        imgFront.CssClass = "";
                    }

                    if (order.Style.SampleImageURL2 != string.Empty)
                    {
                        imgBack.ImageUrl = ResolveUrl("~/Uploads/Style/thumb-" + order.Style.SampleImageURL2);
                        imgBack.CssClass = "";
                    }
                    if (order.Print.ImageUrl != string.Empty)
                    {
                        imagePrint.ImageUrl = ResolveUrl("~/Uploads/Print/thumb-" + order.Print.ImageUrl);
                        imagePrint.CssClass = "";
                    }

                    hypBiplPrice.NavigateUrl = "/Internal/Sales/CostingSheetNew.aspx?sn=" + order.Style.StyleNumber + "&SingleVersion=1";

                    if (order.IsBiplAgreement == 1)
                    {
                        lblBiplPriceComments.Text = " BIPL Agreement Pending.";
                    }
                    else if (order.IsBiplAgreement == 0)
                    {
                        lblBiplPriceComments.Text = " Price Agreed.";
                    }
                    else if (order.IsBiplAgreement == 2)
                    {
                        lblBiplPriceComments.Text = "";
                    }
                    int IsAgreement = 0;

                    if (order.IsIkandiUser == false)
                    {
                        if (order.AgreementId > 0)
                        {
                            chkagree.Visible = true;
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "CheckAgreementFromPage();", true);

                            IsAgreement = 1;
                            btnAgree.Visible = true;
                            btnSubmit.Visible = false;

                            txtDescription.Text = order.Description_d;
                            ddlordrType.SelectedValue = order.OrderType_d.ToString();
                            Status = Convert.ToString(order.IsApproved);
                            hdnOrderType.Value = Status;

                            FillParentDepartment(order.ClientID, order.ParrentDepartmentID_d);
                            hdnParentDeptName.Value = order.ParentDepartmentName_d;

                            FillDepartment(order.ClientID, order.ParrentDepartmentID_d, order.DepartmentID_d);
                            hdnDeptName.Value = order.DepartmentName_d;

                            if (order.ParentDepartmentID != order.ParrentDepartmentID_d)
                            {
                                lblAgrmntParentDept.Text = "<span class='tooltiptext_M'>" + order.ParentDepartmentName + "</span>";
                                lblAgrmntParentDept.CssClass = "lblhover";
                            }

                            if (order.DepartmentID != order.DepartmentID_d)
                            {
                                lblAgrmntDept.Text = "<span class='tooltiptext_M'>" + order.DepartmentName + "</span>";
                                lblAgrmntDept.CssClass = "lblhover";
                            }

                            if (order.Description.Trim() != order.Description_d.Trim())
                            {
                                lblAgrmntDescription.Text = "<span class='tooltiptext_L'>" + order.Description + "</span>";
                                lblAgrmntDescription.CssClass = "lblhover";
                            }

                            if (order.OrderTypes != order.OrderType_d)
                            {
                                lblAgrmntOrderType.Text = "<span class='tooltiptext_M'>" + OrderType(order.OrderTypes) + "</span>";
                                lblAgrmntOrderType.CssClass = "lblhover";
                            }
                        }
                        //if (order.IsIkandiClient == true)
                        //{
                        //    btnSubmit.Visible = false;
                        //}
                    }
                    if (IsAgreement == 0)
                    {
                        txtDescription.Text = order.Description;
                        ddlordrType.SelectedValue = order.OrderTypes.ToString();
                        Status = Convert.ToString(order.IsApproved);
                        hdnOrderType.Value = Status;

                        FillDepartment(order.ClientID, order.ParentDepartmentID, order.DepartmentID);
                        hdnDeptName.Value = order.DepartmentName;
                    }

                    chkBiplManager.Checked = Convert.ToBoolean(order.ApprovedBySalesBIPL);
                    chkAcountManager.Checked = Convert.ToBoolean(order.ApprovedByMerchandiserManager);
                    chkFabricManager.Checked = Convert.ToBoolean(order.ApprovedByFabricManager);
                    chkAccessManager.Checked = Convert.ToBoolean(order.ApprovedByAccessoryManager);
                    if (chkBiplManager.Checked && order.ApprovedBySalesBIPLOn != DateTime.MinValue)
                    {
                        lblbiplManageron.Text = Convert.ToString(order.ApprovedBySalesBIPLOn.ToString("dd MMM yy  hh:mm:ss tt"));
                    }
                    if (chkAcountManager.Checked && order.ApprovedByMerchandiserManagerOn != DateTime.MinValue)
                    {

                        lblAcountManageron.Text = Convert.ToString(order.ApprovedByMerchandiserManagerOn.ToString("dd MMM yy  hh:mm:ss tt"));
                    }
                    if (chkFabricManager.Checked && order.ApprovedByFabricManagerOn != DateTime.MinValue)
                    {
                        lblFabricManageron.Text = Convert.ToString(order.ApprovedByFabricManagerOn.ToString("dd MMM yy  hh:mm:ss tt"));
                    }
                    if (chkAccessManager.Checked && order.ApprovedByAccessoryManagerOn != DateTime.MinValue)
                    {
                        lblAccessManageron.Text = Convert.ToString(order.ApprovedByAccessoryManagerOn.ToString("dd MMM yy  hh:mm:ss tt"));
                    }


                    ApplyPermissions(order);

                    Rowcount = order.ContractDetail.Count;

                    gvDetailSection.DataSource = order.ContractDetail;
                    gvDetailSection.DataBind();
                    if (chkFabricManager.Checked == false && chkFabricManager.Enabled == false && (ApplicationHelper.LoggedInUser.UserData.DesignationID == 15))// added by shubhendu 18/1/2022
                    {
                        chkFabricManager.ToolTip = "AM Signature Not Done";
                    }
                    else if (chkAccessManager.Checked == false && chkAccessManager.Enabled == false && (ApplicationHelper.LoggedInUser.UserData.DesignationID == 16))
                    {
                        chkAccessManager.ToolTip = "AM Signature Not Done";
                    }

                    if (order.IsBiplAgreement == 1)
                    {
                        chkBiplManager.Enabled = false;
                        chkAcountManager.Enabled = false;
                        chkFabricManager.Enabled = false;
                        chkAccessManager.Enabled = false;
                    }

                }
            }
            else
            {
                order.ClientID = Convert.ToInt32(hdnClientId.Value);
                order.ParentDepartmentID = Convert.ToInt32(hdnParentDeptId.Value);
                order.DepartmentID = Convert.ToInt32(hdnDeptId.Value);

                ddlClient.SelectedValue = order.ClientID.ToString();
                FillParentDepartment(order.ClientID, order.ParentDepartmentID);
                FillDepartment(order.ClientID, order.ParentDepartmentID, order.DepartmentID);


                lblRuppes.Text = "&#8377;";

                Rowcount = orderDetailCollection.Count;

                gvDetailSection.DataSource = orderDetailCollection;
                gvDetailSection.DataBind();
                hdnIsEmptyRow.Value = "0";

                dvComment.Style.Add("display", "none");
                dvHistory.Style.Add("display", "");
            }
        }

        private void FillParentDepartment(int ClientId, int ParentDeptId)
        {
            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            List<ClientDepartment> cd = objClientController.GetClientDeptsByClientID_ForDesignForm(ClientId, UserId, -1, "Parent");

            foreach (ClientDepartment client in cd)
            {
                ddlParentDept.Items.Add(new ListItem(client.Name, client.DeptID.ToString()));
            }
            ddlParentDept.SelectedValue = ParentDeptId.ToString();
            hdnParentDeptId.Value = ParentDeptId.ToString();
        }

        private void FillDepartment(int ClientId, int ParentDepartmentId, int DepartmentId)
        {
            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            List<ClientDepartment> cDepartment = objClientController.GetClientDeptsByClientID_ForDesignForm(ClientId, UserId, ParentDepartmentId, "SubParent");

            foreach (ClientDepartment client in cDepartment)
            {
                ddlDepartment.Items.Add(new ListItem(client.Name, client.DeptID.ToString()));
            }
            ddlDepartment.SelectedValue = DepartmentId.ToString();
            hdnDeptId.Value = DepartmentId.ToString();
        }

        private void ApplyPermissions(iKandi.Common.OrderPlace order)
        {
            string CurentStatus = objPermissionController.GetStatusByOrderId(order.OrderID);

            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_AccountManager) && (!chkAcountManager.Checked))
            {
                chkAcountManager.Enabled = true;
            }
            //end
            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Sales_Manager) && (!chkBiplManager.Checked))
            {
                chkBiplManager.Enabled = true;
            }
            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Sales_Manager) && (!chkAcountManager.Checked))
            {
                chkAcountManager.Enabled = true;
            }
            if (((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Fabrics_Manager) && (!chkFabricManager.Checked) && (order.IsFabricAvgDone)) && (order.StatusModeSequence >= 11))
            {
                chkFabricManager.Enabled = true;
            }
            if (((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Accessory_Manager) && (!chkAccessManager.Checked) && (order.IsAccessoriesAvgDone)) && (order.StatusModeSequence >= 11))
            {
                chkAccessManager.Enabled = true;
            }

            if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_Manager || ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Sales_SalesManager) && order.StatusModeSequence >= 11) //temp need to manage it with DB
            {
                //btnSubmit.Visible = false;
            }
            if ((order.IsIkandiUser == true) && (chkBiplManager.Checked) && (chkAcountManager.Checked))// and order is confirmed
            {
                btnSubmit.Visible = false;
                btnsentProposal.Visible = true;

                if (order.AgreementId > 0)
                    btnsentProposal.Visible = false;

                txtStyleNumber.Attributes.Add("disabled", "disabled");
            }
            //  if ((chkBiplManager.Checked) && (chkAcountManager.Checked))// Order confirmed
            //  {
            ddlParentDept.Attributes.Add("disabled", "disabled");
            ddlDepartment.Attributes.Add("disabled", "disabled");
            //  }

            if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_STYLE_NUMBER))
                txtStyleNumber.CssClass = "hide_me";
            else
            {
                if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_STYLE_NUMBER))
                    txtStyleNumber.CssClass = "do-not-allow-typing Bold_Black";
            }

            if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_PARENT_DEPARTMENT))
                ddlParentDept.CssClass = "hide_me";
            else
            {
                if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_PARENT_DEPARTMENT))
                    ddlParentDept.CssClass = "disable-dropdown";
            }

            if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_DEPARTMENT))
                ddlDepartment.CssClass = "hide_me";
            else
            {
                if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_DEPARTMENT))
                    ddlDepartment.CssClass = "disable-dropdown";
            }

            if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_DESCRIPTION))
                txtDescription.CssClass = "hide_me";
            else
            {
                if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_DESCRIPTION))
                    txtDescription.CssClass = "do-not-allow-typing";
            }

            if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_ORDER_TYPE))
                ddlordrType.CssClass = "hide_me";
            else
            {
                if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_ORDER_TYPE))
                    ddlordrType.CssClass = "disable-dropdown";
            }

            if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_TOTAL_ORDER_VALUE))
            {
                lblRuppes.CssClass = "hide_me";
                txtTotalOrderValue.CssClass = "hide_me";
            }
            if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_TOTAL_ORDER_QTY))
            {
                txtTotalQty.CssClass = "hide_me";
            }
            if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_PRICE_AGREED_LINK))
            {
                hypBiplPrice.CssClass = "hide_me";
            }
            else
            {
                if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_PRICE_AGREED_LINK))
                    hypBiplPrice.Attributes.Remove("onclick");
            }

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_TOP_MANAGER))
                chkBiplManager.Enabled = false;

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_ACCOUNT_MANAGER))
                chkAcountManager.Enabled = false;

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC_MANAGER))
                chkFabricManager.Enabled = false;

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_ACCESSORY_MANAGER))
                chkAccessManager.Enabled = false;

            //---------------------------------------- HISTORY SECTION -----------------------------------

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_HISTORY_ALL))
                divHistory.Attributes.Remove("onclick");

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_HISTORY_ALL))
                hlnkAll_History.Attributes.Remove("onclick");

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_HISTORY_HEADER))
                hlnkOrderHeader_History.Attributes.Remove("onclick");

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_HISTORY_EXFACTORY))
                hlnkExFactory_History.Attributes.Remove("onclick");

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_HISTORY_FINANCE))
                hlnkPrice_History.Attributes.Remove("onclick");

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_HISTORY_FABRIC))
                hlnkFabric_History.Attributes.Remove("onclick");

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_HISTORY_ACCESSORY))
                hlnkAccessories_History.Attributes.Remove("onclick");

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_HISTORY_OTHER))
                hlnkOther_History.Attributes.Remove("onclick");


            //---------------------------------------- COMMENT SECTION -----------------------------------

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_COMMENT_ALL))
                divComment.Attributes.Remove("onclick");

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_COMMENT_ALL))
                hlnkAll_Comment.Attributes.Remove("onclick");

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_COMMENT_HEADER))
                hlnkOrderHeader_Comment.Attributes.Remove("onclick");

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_COMMENT_EXFACTORY))
                hlnkExFactory_Comment.Attributes.Remove("onclick");

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_COMMENT_FINANCE))
                hlnkPrice_Comment.Attributes.Remove("onclick");

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_COMMENT_FABRIC))
                hlnkFabric_Comment.Attributes.Remove("onclick");

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_COMMENT_ACCESSORY))
                hlnkAccessories_Comment.Attributes.Remove("onclick");

            if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_COMMENT_OTHER))
                hlnkOther_Comment.Attributes.Remove("onclick");

        }


        protected void gvDetailSection_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddEmpty")
            {
                Table tblgvDetail = (Table)gvDetailSection.Controls[0];
                GridViewRow rows = (GridViewRow)tblgvDetail.Controls[0];

                // Basic Section

                TextBox txtLineNo_Empty = (TextBox)rows.FindControl("txtLineNo_Empty");
                TextBox txtContractNo_Empty = (TextBox)rows.FindControl("txtContractNo_Empty");
                TextBox txtQty_Empty = (TextBox)rows.FindControl("txtQty_Empty");
                TextBox txtBIPLPrice_Empty = (TextBox)rows.FindControl("txtBIPLPrice_Empty");
                TextBox txtikandiPrice_Empty = (TextBox)rows.FindControl("txtikandiPrice_Empty");
                HiddenField hdnExFactoryWeek_Empty = (HiddenField)rows.FindControl("hdnExFactoryWeek_Empty");
                HiddenField hdnDCWeek_Empty = (HiddenField)rows.FindControl("hdnDCWeek_Empty");
                TextBox txtDelivery_Empty = (TextBox)rows.FindControl("txtDelivery_Empty");
                HiddenField hdnMode_Empty = (HiddenField)rows.FindControl("hdnMode_Empty");
                TextBox txtExFactory_Empty = (TextBox)rows.FindControl("txtExFactory_Empty");
                TextBox txtDC_Empty = (TextBox)rows.FindControl("txtDC_Empty");
                HiddenField hdnExFactoryColor_Empty = (HiddenField)rows.FindControl("hdnExFactoryColor_Empty");
                DropDownList ddlDelivery_Empty = (DropDownList)rows.FindControl("ddlDelivery_Empty");
                HiddenField hdnPoUpload1_Empty = (HiddenField)rows.FindControl("hdnPoUpload1_Empty");
                HiddenField hdnPoUpload2_Empty = (HiddenField)rows.FindControl("hdnPoUpload2_Empty");
                HiddenField hdnCountryCodeId_Empty = (HiddenField)rows.FindControl("hdnCountryCodeId_Empty");
                HiddenField hdnLeadTime_Empty = (HiddenField)rows.FindControl("hdnLeadTime_Empty");


                List<ContractDetails> orderDetailCollection = new List<ContractDetails>();
                ContractDetails orderdetail = new ContractDetails();

                orderdetail.OrderDetailId = -1;
                orderdetail.OrderDetailId_Ref = -1;
                orderdetail.isSplit = 0;
                orderdetail.isSplitted = 0;
                orderdetail.LineItemNumber = txtLineNo_Empty.Text;
                orderdetail.ContractNumber = txtContractNo_Empty.Text;
                orderdetail.PoUpload1 = hdnPoUpload1_Empty.Value;
                orderdetail.PoUpload2 = hdnPoUpload2_Empty.Value;
                orderdetail.Quantity = txtQty_Empty.Text == "" ? 0 : Convert.ToInt32(txtQty_Empty.Text);
                orderdetail.BiplPrice = txtBIPLPrice_Empty.Text == "" ? 0 : Convert.ToDouble(txtBIPLPrice_Empty.Text);
                orderdetail.ikandiPrice = txtikandiPrice_Empty.Text == "" ? 0 : Convert.ToDouble(txtikandiPrice_Empty.Text);
                orderdetail.ExFactory = txtExFactory_Empty.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtExFactory_Empty.Text.Trim()).Value;
                orderdetail.DC = txtDC_Empty.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtDC_Empty.Text).Value;
                orderdetail.ExFactoryWeek = hdnExFactoryWeek_Empty.Value == "" ? 0 : Convert.ToInt32(hdnExFactoryWeek_Empty.Value);
                orderdetail.DCWeek = hdnDCWeek_Empty.Value == "" ? 0 : Convert.ToInt32(hdnDCWeek_Empty.Value);
                orderdetail.ExFactoryColor = hdnExFactoryColor_Empty.Value;
                orderdetail.DeliveryInstruction = DeliveryInstruction(txtDelivery_Empty.Text);
                orderdetail.ModeId = hdnMode_Empty.Value == "" ? -1 : Convert.ToInt32(hdnMode_Empty.Value);
                orderdetail.typeofpacking = Convert.ToInt32(ddlDelivery_Empty.SelectedValue);
                orderdetail.CountryCodeId = hdnCountryCodeId_Empty.Value == "" ? 0 : Convert.ToInt32(hdnCountryCodeId_Empty.Value);
                orderdetail.LeadTime = hdnLeadTime_Empty.Value == "" ? 0 : Convert.ToInt32(hdnLeadTime_Empty.Value);

                orderdetail.LineItemNumber_d = string.Empty;
                orderdetail.ContractNumber_d = string.Empty;
                orderdetail.PoUpload1_d = string.Empty;
                orderdetail.PoUpload2_d = string.Empty;
                orderdetail.Quantity_d = 0;
                orderdetail.BiplPrice_d = 0;
                orderdetail.ikandiPrice_d = 0;
                orderdetail.ExFactory_d = DateTime.MinValue;
                orderdetail.ExFactoryWeek_d = 0;
                orderdetail.DC_d = DateTime.MinValue;
                orderdetail.DCWeek_d = 0;
                orderdetail.DeliveryInstruction_d = 0;
                orderdetail.typeofpacking_d = 0;
                orderdetail.ModeCode_d = string.Empty;
                orderdetail.CountryCode_d = string.Empty;

                //Start Fabric Section                   

                List<ContractDetailFabric> objFabricCollection = new List<ContractDetailFabric>();
                HiddenField hdnFabricCount = (HiddenField)rows.FindControl("hdnFabricCount");
                int FabricCount = hdnFabricCount.Value == "" ? 0 : Convert.ToInt32(hdnFabricCount.Value);
                if (FabricCount > 0)
                {
                    for (int fabNo = 1; fabNo <= FabricCount; fabNo++)
                    {
                        HiddenField hdnFabric = (HiddenField)rows.FindControl("hdnFabric" + fabNo);
                        TextBox txtFabric = (TextBox)rows.FindControl("txtFabric" + fabNo);
                        HiddenField hdnCountCnstr = (HiddenField)rows.FindControl("hdnCountCnstr" + fabNo);
                        HiddenField hdnGSM = (HiddenField)rows.FindControl("hdnGSM" + fabNo);
                        HiddenField hdnFabriQualityId = (HiddenField)rows.FindControl("hdnFabriQualityId" + fabNo);
                        HiddenField hdnFabricType = (HiddenField)rows.FindControl("hdnFabricType" + fabNo);
                        TextBox txtFabricType = (TextBox)rows.FindControl("txtFabricType" + fabNo);
                        TextBox txtFabricDetail = (TextBox)rows.FindControl("txtFabricDetail" + fabNo);

                        ContractDetailFabric orderDetailFabric = new ContractDetailFabric();

                        orderDetailFabric.FabricId = hdnFabric.Value == "" ? -1 : Convert.ToInt32(hdnFabric.Value);
                        orderDetailFabric.FabricName = txtFabric.Text;
                        orderDetailFabric.CountConstruct = hdnCountCnstr.Value;
                        orderDetailFabric.GSM = hdnGSM.Value == "" ? -1 : Convert.ToDouble(hdnGSM.Value);
                        orderDetailFabric.fabric_qualityID = hdnFabriQualityId.Value == "" ? -1 : Convert.ToInt32(hdnFabriQualityId.Value);
                        orderDetailFabric.FabTypeId = Convert.ToInt32(hdnFabricType.Value);
                        orderDetailFabric.FabType = txtFabricType.Text;
                        orderDetailFabric.FabricDetail = txtFabricDetail.Text;
                        orderDetailFabric.FabricDetail_d = txtFabricDetail.Text;

                        objFabricCollection.Add(orderDetailFabric);
                    }

                }
                orderdetail.ContractFabric = objFabricCollection;
                // End Fabric Section

                //Start Accessories Section

                List<ContractDetailAccessories> objAccessCollection = new List<ContractDetailAccessories>();
                HiddenField hdnAccessCount = (HiddenField)rows.FindControl("hdnAccessCount");
                int AccessCount = hdnAccessCount.Value == "" ? 0 : Convert.ToInt32(hdnAccessCount.Value);
                if (AccessCount > 0)
                {
                    for (int AccNo = 1; AccNo <= AccessCount; AccNo++)
                    {
                        HtmlInputHidden hdnAccessId = (HtmlInputHidden)rows.FindControl("hdnAccessId_" + AccNo);
                        HiddenField hdnAccessName = (HiddenField)rows.FindControl("hdnAccessName_" + AccNo);
                        TextBox txtAccessName = (TextBox)rows.FindControl("txtAccessName_" + AccNo);
                        HiddenField hdnAccessSizeId = (HiddenField)rows.FindControl("hdnAccessSizeId_" + AccNo);
                        HiddenField hdnAccessSize = (HiddenField)rows.FindControl("hdnAccessSize_" + AccNo);
                        TextBox txtAccessVal = (TextBox)rows.FindControl("txtAccessVal_" + AccNo);
                        CheckBox chkDTM = (CheckBox)rows.FindControl("chkDTM" + AccNo);
                     //   HiddenField HdnISSrvReceived = (HiddenField)rows.FindControl("HdnISSrvReceived" + AccNo);

                        if (txtAccessName.Text != "")
                        {
                            ContractDetailAccessories orderDetailAccess = new ContractDetailAccessories();
                            orderDetailAccess.AccessoriesId = hdnAccessId.Value == "" ? -1 : Convert.ToInt32(hdnAccessId.Value);
                            orderDetailAccess.AccessoriesName = hdnAccessName.Value;
                            orderDetailAccess.SizeId = hdnAccessSizeId.Value == "" ? -1 : Convert.ToInt32(hdnAccessSizeId.Value);
                            orderDetailAccess.Size = hdnAccessSize.Value;
                            orderDetailAccess.ColorPrint = txtAccessVal.Text == "" ? DBNull.Value.ToString() : txtAccessVal.Text;
                            orderDetailAccess.IsDtm = chkDTM.Checked;
                            orderDetailAccess.SeqId = AccNo;

                            objAccessCollection.Add(orderDetailAccess);

                        }
                    }

                }
                orderdetail.ContractAccessories = objAccessCollection;

                // End Accessories Section

                orderDetailCollection.Add(orderdetail);

                ContractDetails orderdetailnew = new ContractDetails();
                orderdetailnew.OrderDetailId = -1;
                orderdetail.OrderDetailId_Ref = -1;
                orderdetail.isSplit = 0;
                orderdetail.isSplitted = 0;
                orderdetailnew.LineItemNumber = string.Empty;
                orderdetailnew.ContractNumber = string.Empty;
                orderdetailnew.PoUpload1 = string.Empty;
                orderdetailnew.PoUpload2 = string.Empty;
                orderdetailnew.Quantity = 0;
                orderdetailnew.BiplPrice = txtBIPLPrice_Empty.Text == "" ? 0 : Convert.ToDouble(txtBIPLPrice_Empty.Text);
                orderdetailnew.ikandiPrice = 0;
                orderdetailnew.ExFactory = DateTime.MinValue;
                orderdetailnew.DC = DateTime.MinValue;
                orderdetailnew.ExFactoryWeek = 0;
                orderdetailnew.DCWeek = 0;
                orderdetailnew.ExFactoryColor = string.Empty;
                orderdetailnew.DeliveryInstruction = 0;
                orderdetailnew.ModeId = -1;
                orderdetailnew.typeofpacking = 0;
                orderdetailnew.CountryCodeId = 0;
                orderdetailnew.LeadTime = 0;

                orderdetailnew.LineItemNumber_d = string.Empty;
                orderdetailnew.ContractNumber_d = string.Empty;
                orderdetailnew.PoUpload1_d = string.Empty;
                orderdetailnew.PoUpload2_d = string.Empty;
                orderdetailnew.Quantity_d = 0;
                orderdetailnew.BiplPrice_d = -1;
                orderdetailnew.ikandiPrice_d = -1;
                orderdetailnew.ExFactory_d = DateTime.MinValue;
                orderdetailnew.ExFactoryWeek_d = -1;
                orderdetailnew.DC_d = DateTime.MinValue;
                orderdetailnew.DCWeek_d = -1;
                orderdetailnew.DeliveryInstruction_d = -1;
                orderdetailnew.typeofpacking_d = -1;
                orderdetailnew.ModeCode_d = string.Empty;
                orderdetailnew.CountryCode_d = string.Empty;

                orderdetailnew.ContractFabric = objFabricCollection;
                orderdetailnew.ContractAccessories = objAccessCollection;

                orderDetailCollection.Add(orderdetailnew);

                PopulateOrderData(orderDetailCollection);


            }
            if (e.CommandName == "AddRow")
            {
                List<ContractDetails> orderDetailCollection = new List<ContractDetails>();
                double Last_BiplPrice = 0;
                double Last_ikandiPrice = 0;
                int Last_CountryCodeId = -1;
                int Last_DeliveryInstruct = 0;
                int Last_ModeId = -1;
                DateTime Last_ExFactory = DateTime.MinValue;
                int Last_ExFactoryWeek = 0;
                string Last_ExFactoryColor = "";

                DateTime Last_DC = DateTime.MinValue;
                int Last_DCWeek = 0;
                int Last_Typeofpacking = -1;
                string Last_CountryCode = "";
                int Last_LeadTime = 0;

                string FileUpload1 = "";
                string FileUpload2 = "";

                for (int i = 0; i < gvDetailSection.Rows.Count; i++)
                {
                    HiddenField hdnOrderDetailid = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnOrderDetailid");
                    HiddenField hdnOrderDetailid_Ref = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnOrderDetailid_Ref");
                    TextBox txtLineNo = (TextBox)gvDetailSection.Rows[i].FindControl("txtLineNo");
                    TextBox txtContractNo = (TextBox)gvDetailSection.Rows[i].FindControl("txtContractNo");
                    HiddenField hdnPoUpload1 = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnPoUpload1");
                    HiddenField hdnPoUpload2 = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnPoUpload2");

                    TextBox txtQty = (TextBox)gvDetailSection.Rows[i].FindControl("txtQty");
                    TextBox txtBIPLPrice = (TextBox)gvDetailSection.Rows[i].FindControl("txtBIPLPrice");
                    TextBox txtikandiPrice = (TextBox)gvDetailSection.Rows[i].FindControl("txtikandiPrice");
                    HiddenField hdnExFactoryWeek = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnExFactoryWeek");
                    HiddenField hdnDCWeek = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnDCWeek");
                    TextBox txtDelivery = (TextBox)gvDetailSection.Rows[i].FindControl("txtDelivery");
                    HiddenField hdnMode = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnMode");
                    TextBox txtExFactory = (TextBox)gvDetailSection.Rows[i].FindControl("txtExFactory");
                    TextBox txtDC = (TextBox)gvDetailSection.Rows[i].FindControl("txtDC");
                    HiddenField hdnExFactoryColor = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnExFactoryColor");
                    DropDownList ddlDelivery = (DropDownList)gvDetailSection.Rows[i].FindControl("ddlDelivery");
                    HiddenField hdnSizeQty = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnSizeQty");
                    HiddenField hdnIsSplit = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnIsSplit");
                    HiddenField hdnIsSplited = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnIsSplited");
                    HiddenField hdnCountry_CodeId = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnCountry_CodeId");
                    HiddenField hdnCountryCode = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnCountryCode");
                    HiddenField hdnLeadTime = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnLeadTime");

                    Last_BiplPrice = txtBIPLPrice.Text == "" ? 0 : Convert.ToDouble(txtBIPLPrice.Text);
                    Last_ikandiPrice = txtikandiPrice.Text == "" ? 0 : Convert.ToDouble(txtikandiPrice.Text);
                    Last_CountryCodeId = hdnCountry_CodeId.Value == "" ? 0 : Convert.ToInt32(hdnCountry_CodeId.Value);
                    Last_DeliveryInstruct = DeliveryInstruction(txtDelivery.Text);
                    Last_ModeId = hdnMode.Value == "" ? -1 : Convert.ToInt32(hdnMode.Value);
                    Last_ExFactory = txtExFactory.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtExFactory.Text.Trim()).Value;
                    Last_ExFactoryWeek = hdnExFactoryWeek.Value == "" ? -1 : Convert.ToInt32(hdnExFactoryWeek.Value);
                    Last_ExFactoryColor = hdnExFactoryColor.Value;
                    Last_DC = txtDC.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtDC.Text).Value;
                    Last_DCWeek = hdnDCWeek.Value == "" ? -1 : Convert.ToInt32(hdnDCWeek.Value);
                    Last_Typeofpacking = Convert.ToInt32(ddlDelivery.SelectedValue);
                    Last_CountryCode = hdnCountryCode.Value;
                    Last_LeadTime = hdnLeadTime.Value == "" ? 0 : Convert.ToInt32(hdnLeadTime.Value);

                    ContractDetails orderdetail = new ContractDetails();
                    FileUpload1 = hdnPoUpload1.Value;
                    FileUpload2 = hdnPoUpload2.Value;

                    orderdetail.OrderDetailId = hdnOrderDetailid.Value == "" ? -1 : Convert.ToInt32(hdnOrderDetailid.Value);
                    orderdetail.OrderDetailId_Ref = hdnOrderDetailid_Ref.Value == "" ? -1 : Convert.ToInt32(hdnOrderDetailid_Ref.Value);
                    orderdetail.LineItemNumber = txtLineNo.Text;
                    orderdetail.ContractNumber = txtContractNo.Text;
                    orderdetail.PoUpload1 = FileUpload1;
                    orderdetail.PoUpload2 = FileUpload2;
                    orderdetail.Quantity = txtQty.Text == "" ? 0 : Convert.ToInt32(txtQty.Text);
                    orderdetail.BiplPrice = txtBIPLPrice.Text == "" ? -1 : Convert.ToDouble(txtBIPLPrice.Text);
                    orderdetail.ikandiPrice = txtikandiPrice.Text == "" ? -1 : Convert.ToDouble(txtikandiPrice.Text);
                    orderdetail.ExFactory = txtExFactory.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtExFactory.Text.Trim()).Value;
                    orderdetail.DC = txtDC.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtDC.Text).Value;
                    orderdetail.ExFactoryWeek = hdnExFactoryWeek.Value == "" ? -1 : Convert.ToInt32(hdnExFactoryWeek.Value);
                    orderdetail.DCWeek = hdnDCWeek.Value == "" ? -1 : Convert.ToInt32(hdnDCWeek.Value);
                    orderdetail.DeliveryInstruction = DeliveryInstruction(txtDelivery.Text);
                    orderdetail.ModeId = hdnMode.Value == "" ? -1 : Convert.ToInt32(hdnMode.Value);
                    orderdetail.ExFactoryColor = hdnExFactoryColor.Value;
                    orderdetail.typeofpacking = Convert.ToInt32(ddlDelivery.SelectedValue);
                    orderdetail.SizeQty = hdnSizeQty.Value == "" ? 0 : Convert.ToInt32(hdnSizeQty.Value);
                    orderdetail.isSplit = hdnIsSplit.Value == "" ? 0 : Convert.ToInt32(hdnIsSplit.Value);
                    orderdetail.isSplitted = hdnIsSplited.Value == "" ? 0 : Convert.ToInt32(hdnIsSplited.Value);
                    orderdetail.CountryCodeId = hdnCountry_CodeId.Value == "" ? 0 : Convert.ToInt32(hdnCountry_CodeId.Value);
                    orderdetail.CountryCode = hdnCountryCode.Value;
                    orderdetail.LeadTime = hdnLeadTime.Value == "" ? 0 : Convert.ToInt32(hdnLeadTime.Value);

                    // Find Agreement Value
                    HiddenField hdnLineNo_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnLineNo_agree");
                    HiddenField hdnQty_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnQty_agree");
                    HiddenField hdnAgreementMode = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnAgreementMode");
                    HiddenField hdnContactNo_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnContactNo_agree");
                    HiddenField hdnBiplPrice_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnBiplPrice_agree");
                    HiddenField hdnExFactory_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnExFactory_agree");
                    HiddenField hdnExFactoryWeek_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnExFactoryWeek_agree");
                    HiddenField hdnPoUpload1_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnPoUpload1_agree");
                    HiddenField hdnikandiPrice_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnikandiPrice_agree");
                    HiddenField hdnDC_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnDC_agree");
                    HiddenField hdnDCWeek_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnDCWeek_agree");
                    HiddenField hdnPoUpload2_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnPoUpload2_agree");
                    HiddenField hdnDeliver_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnDeliver_agree");
                    HiddenField hdnddlDelivery_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnddlDelivery_agree");
                    HiddenField hdnCountryCode_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnCountryCode_agree");

                    orderdetail.LineItemNumber_d = hdnLineNo_agree.Value;
                    orderdetail.ContractNumber_d = hdnContactNo_agree.Value;
                    orderdetail.PoUpload1_d = hdnPoUpload1_agree.Value;
                    orderdetail.PoUpload2_d = hdnPoUpload2_agree.Value;
                    orderdetail.Quantity_d = hdnQty_agree.Value == "" ? -1 : Convert.ToInt32(hdnQty_agree.Value);
                    orderdetail.BiplPrice_d = hdnBiplPrice_agree.Value == "" ? -1 : Convert.ToDouble(hdnBiplPrice_agree.Value);
                    orderdetail.ikandiPrice_d = hdnikandiPrice_agree.Value == "" ? -1 : Convert.ToDouble(hdnikandiPrice_agree.Value); ;
                    orderdetail.ExFactory_d = hdnExFactory_agree.Value == "" ? DateTime.MinValue : DateHelper.ParseDate(hdnExFactory_agree.Value).Value;
                    orderdetail.ExFactoryWeek_d = hdnExFactoryWeek_agree.Value == "" ? -1 : Convert.ToInt32(hdnExFactoryWeek_agree.Value);
                    orderdetail.DC_d = hdnDC_agree.Value == "" ? DateTime.MinValue : DateHelper.ParseDate(hdnDC_agree.Value).Value;
                    orderdetail.DCWeek_d = hdnDCWeek_agree.Value == "" ? -1 : Convert.ToInt32(hdnDCWeek_agree.Value);
                    orderdetail.DeliveryInstruction_d = hdnDeliver_agree.Value == "" ? -1 : Convert.ToInt32(hdnDeliver_agree.Value);
                    orderdetail.typeofpacking_d = hdnddlDelivery_agree.Value == "" ? -1 : Convert.ToInt32(hdnddlDelivery_agree.Value);
                    orderdetail.ModeCode_d = hdnAgreementMode.Value.ToString();
                    orderdetail.CountryCode_d = hdnCountryCode_agree.Value;

                    // Start Fabric Section 

                    List<ContractDetailFabric> objFabricCollection = new List<ContractDetailFabric>();

                    DataList dlstFabric = (DataList)gvDetailSection.Rows[i].FindControl("dlstFabric");

                    for (int fabNo = 0; fabNo < dlstFabric.Items.Count; fabNo++)
                    {
                        HiddenField hdnFabric = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnFabric");
                        TextBox txtFabric = (TextBox)dlstFabric.Items[fabNo].FindControl("txtFabric");
                        HiddenField hdnCountCnstr = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnCountCnstr");
                        HiddenField hdnGSM = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnGSM");
                        HiddenField hdnFabriQualityId = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnFabriQualityId");
                        HtmlInputHidden hdnFabricType = (HtmlInputHidden)dlstFabric.Items[fabNo].FindControl("hdnFabricType");
                        TextBox txtFabricType = (TextBox)dlstFabric.Items[fabNo].FindControl("txtFabricType");
                        TextBox txtFabricDetail = (TextBox)dlstFabric.Items[fabNo].FindControl("txtFabricDetail");
                        HiddenField hdnFabricDetail_d = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnFabricDetail_d");

                        ContractDetailFabric orderDetailFabric = new ContractDetailFabric();

                        orderDetailFabric.FabricId = hdnFabric.Value == "" ? -1 : Convert.ToInt32(hdnFabric.Value);
                        orderDetailFabric.FabricName = txtFabric.Text;
                        orderDetailFabric.CountConstruct = hdnCountCnstr.Value;
                        orderDetailFabric.GSM = hdnGSM.Value == "" ? -1 : Convert.ToDouble(hdnGSM.Value);
                        orderDetailFabric.fabric_qualityID = hdnFabriQualityId.Value == "" ? -1 : Convert.ToInt32(hdnFabriQualityId.Value);
                        orderDetailFabric.FabTypeId = Convert.ToInt32(hdnFabricType.Value);
                        orderDetailFabric.FabType = txtFabricType.Text;
                        orderDetailFabric.FabricDetail = txtFabricDetail.Text;
                        orderDetailFabric.FabricDetail_d = hdnFabricDetail_d.Value;
                        objFabricCollection.Add(orderDetailFabric);
                    }

                    orderdetail.ContractFabric = objFabricCollection;
                    // End Fabric Section 

                    //Start Accessories Section

                    List<ContractDetailAccessories> objAccessCollection = new List<ContractDetailAccessories>();

                    DataList dlstAccessories = (DataList)gvDetailSection.Rows[i].FindControl("dlstAccessories");

                    for (int AccNo = 0; AccNo < dlstAccessories.Items.Count; AccNo++)
                    {
                        HtmlInputHidden hdnAccessId = (HtmlInputHidden)dlstAccessories.Items[AccNo].FindControl("hdnAccessId_");
                        HiddenField hdnAccessName = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnAccessName_");
                        HiddenField hdnAccessSizeId = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnAccessSizeId_");
                        HiddenField hdnAccessSize = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnAccessSize_");
                        TextBox txtAccessVal = (TextBox)dlstAccessories.Items[AccNo].FindControl("txtAccessVal_");
                        CheckBox chkDTM = (CheckBox)dlstAccessories.Items[AccNo].FindControl("chkDTM");
                        HiddenField hdnAccessColorPrint_d = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnAccessColorPrint_d");
                        HiddenField hdnIsDTM_d = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnIsDTM_d");
                     //   HiddenField HdnISSrvReceived = (HiddenField)dlstAccessories.Items[AccNo].FindControl("HdnISSrvReceived");

                        ContractDetailAccessories orderDetailAccess = new ContractDetailAccessories();
                        orderDetailAccess.AccessoriesId = hdnAccessId.Value == "" ? -1 : Convert.ToInt32(hdnAccessId.Value);
                        orderDetailAccess.AccessoriesName = hdnAccessName.Value;
                        orderDetailAccess.SizeId = hdnAccessSizeId.Value == "" ? -1 : Convert.ToInt32(hdnAccessSizeId.Value);
                        orderDetailAccess.Size = hdnAccessSize.Value;
                        orderDetailAccess.ColorPrint = txtAccessVal.Text == "" ? "N/A" : txtAccessVal.Text;
                        orderDetailAccess.IsDtm = chkDTM.Checked;
                        orderDetailAccess.ColorPrint_d = hdnAccessColorPrint_d.Value;
                        orderDetailAccess.IsDtm_d = hdnIsDTM_d.Value;
                        orderDetailAccess.SeqId = AccNo;

                        objAccessCollection.Add(orderDetailAccess);
                    }

                    orderdetail.ContractAccessories = objAccessCollection;
                    // End Accessories Section

                    orderDetailCollection.Add(orderdetail);
                }

                ContractDetails orderdetailnew = new ContractDetails();
                orderdetailnew.OrderDetailId = -1;
                orderdetailnew.OrderDetailId_Ref = -1;
                orderdetailnew.isSplit = 0;
                orderdetailnew.isSplitted = 0;
                orderdetailnew.LineItemNumber = string.Empty;
                orderdetailnew.ContractNumber = string.Empty;
                orderdetailnew.PoUpload1 = string.Empty;
                orderdetailnew.PoUpload2 = string.Empty;
                orderdetailnew.Quantity = 0;
                orderdetailnew.BiplPrice = Last_BiplPrice;
                orderdetailnew.ikandiPrice = Last_ikandiPrice;
                orderdetailnew.ExFactory = Last_ExFactory;
                orderdetailnew.DC = Last_DC;
                orderdetailnew.ExFactoryWeek = Last_ExFactoryWeek;
                orderdetailnew.DCWeek = Last_DCWeek;
                orderdetailnew.DeliveryInstruction = Last_DeliveryInstruct;
                orderdetailnew.ModeId = Last_ModeId;
                orderdetailnew.ExFactoryColor = Last_ExFactoryColor;
                orderdetailnew.typeofpacking = Last_Typeofpacking;
                orderdetailnew.SizeQty = 0;
                orderdetailnew.CountryCodeId = Last_CountryCodeId;
                orderdetailnew.CountryCode = Last_CountryCode;
                orderdetailnew.LeadTime = Last_LeadTime;

                orderdetailnew.LineItemNumber_d = string.Empty;
                orderdetailnew.ContractNumber_d = string.Empty;
                orderdetailnew.PoUpload1_d = string.Empty;
                orderdetailnew.PoUpload2_d = string.Empty;
                orderdetailnew.Quantity_d = 0;
                orderdetailnew.BiplPrice_d = -1;
                orderdetailnew.ikandiPrice_d = -1;
                orderdetailnew.ExFactory_d = DateTime.MinValue;
                orderdetailnew.ExFactoryWeek_d = -1;
                orderdetailnew.DC_d = DateTime.MinValue;
                orderdetailnew.DCWeek_d = -1;
                orderdetailnew.DeliveryInstruction_d = -1;
                orderdetailnew.typeofpacking_d = -1;
                orderdetailnew.ModeCode_d = string.Empty;
                orderdetailnew.CountryCode_d = string.Empty;

                //Start Fabric Section

                List<ContractDetailFabric> objFabricCollectionNew = new List<ContractDetailFabric>();

                int gridRow = gvDetailSection.Rows.Count - 1;

                DataList dlstFabricNew = (DataList)gvDetailSection.Rows[gridRow].FindControl("dlstFabric");

                for (int fabNo = 0; fabNo < dlstFabricNew.Items.Count; fabNo++)
                {
                    HiddenField hdnFabric = (HiddenField)dlstFabricNew.Items[fabNo].FindControl("hdnFabric");
                    TextBox txtFabric = (TextBox)dlstFabricNew.Items[fabNo].FindControl("txtFabric");
                    HiddenField hdnCountCnstr = (HiddenField)dlstFabricNew.Items[fabNo].FindControl("hdnCountCnstr");
                    HiddenField hdnGSM = (HiddenField)dlstFabricNew.Items[fabNo].FindControl("hdnGSM");
                    HiddenField hdnFabriQualityId = (HiddenField)dlstFabricNew.Items[fabNo].FindControl("hdnFabriQualityId");
                    HtmlInputHidden hdnFabricType = (HtmlInputHidden)dlstFabricNew.Items[fabNo].FindControl("hdnFabricType");
                    TextBox txtFabricType = (TextBox)dlstFabricNew.Items[fabNo].FindControl("txtFabricType");
                    TextBox txtFabricDetail = (TextBox)dlstFabricNew.Items[fabNo].FindControl("txtFabricDetail");
                    HiddenField hdnFabricDetail_d = (HiddenField)dlstFabricNew.Items[fabNo].FindControl("hdnFabricDetail_d");

                    ContractDetailFabric orderDetailFabric = new ContractDetailFabric();

                    orderDetailFabric.FabricId = hdnFabric.Value == "" ? -1 : Convert.ToInt32(hdnFabric.Value);
                    orderDetailFabric.FabricName = txtFabric.Text;
                    orderDetailFabric.CountConstruct = hdnCountCnstr.Value;
                    orderDetailFabric.GSM = hdnGSM.Value == "" ? -1 : Convert.ToDouble(hdnGSM.Value);
                    orderDetailFabric.fabric_qualityID = hdnFabriQualityId.Value == "" ? -1 : Convert.ToInt32(hdnFabriQualityId.Value);
                    orderDetailFabric.FabTypeId = Convert.ToInt32(hdnFabricType.Value);
                    orderDetailFabric.FabType = txtFabricType.Text;
                    orderDetailFabric.FabricDetail = txtFabricDetail.Text;
                    orderDetailFabric.FabricDetail_d = hdnFabricDetail_d.Value;
                    objFabricCollectionNew.Add(orderDetailFabric);
                }

                orderdetailnew.ContractFabric = objFabricCollectionNew;
                //End Fabric Section

                //Start Accessories Section

                List<ContractDetailAccessories> objAccessCollectionNew = new List<ContractDetailAccessories>();

                DataList dlstAccessoriesNew = (DataList)gvDetailSection.Rows[gridRow].FindControl("dlstAccessories");

                for (int AccNo = 0; AccNo < dlstAccessoriesNew.Items.Count; AccNo++)
                {
                    HtmlInputHidden hdnAccessId = (HtmlInputHidden)dlstAccessoriesNew.Items[AccNo].FindControl("hdnAccessId_");
                    HiddenField hdnAccessName = (HiddenField)dlstAccessoriesNew.Items[AccNo].FindControl("hdnAccessName_");
                    HiddenField hdnAccessSizeId = (HiddenField)dlstAccessoriesNew.Items[AccNo].FindControl("hdnAccessSizeId_");
                    HiddenField hdnAccessSize = (HiddenField)dlstAccessoriesNew.Items[AccNo].FindControl("hdnAccessSize_");
                    TextBox txtAccessVal = (TextBox)dlstAccessoriesNew.Items[AccNo].FindControl("txtAccessVal_");
                    CheckBox chkDTM = (CheckBox)dlstAccessoriesNew.Items[AccNo].FindControl("chkDTM");
                    HiddenField hdnAccessColorPrint_d = (HiddenField)dlstAccessoriesNew.Items[AccNo].FindControl("hdnAccessColorPrint_d");
                    HiddenField hdnIsDTM_d = (HiddenField)dlstAccessoriesNew.Items[AccNo].FindControl("hdnIsDTM_d");

                    ContractDetailAccessories orderDetailAccess = new ContractDetailAccessories();
                    orderDetailAccess.AccessoriesId = hdnAccessId.Value == "" ? -1 : Convert.ToInt32(hdnAccessId.Value);
                    orderDetailAccess.AccessoriesName = hdnAccessName.Value;
                    orderDetailAccess.SizeId = hdnAccessSizeId.Value == "" ? -1 : Convert.ToInt32(hdnAccessSizeId.Value);
                    orderDetailAccess.Size = hdnAccessSize.Value;
                    orderDetailAccess.ColorPrint = txtAccessVal.Text == "" ? "N/A" : txtAccessVal.Text;
                    orderDetailAccess.IsDtm = chkDTM.Checked;
                    orderDetailAccess.ColorPrint_d = hdnAccessColorPrint_d.Value;
                    orderDetailAccess.IsDtm_d = hdnIsDTM_d.Value;
                    orderDetailAccess.SeqId = AccNo;

                    objAccessCollectionNew.Add(orderDetailAccess);
                }

                orderdetailnew.ContractAccessories = objAccessCollectionNew;

                // End Accessories Section

                orderDetailCollection.Add(orderdetailnew);

                PopulateOrderData(orderDetailCollection);

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "PopulateOnPageLoad();", true);
                //UpdatePanel1.Update();
            }

            if (e.CommandName == "DeleteRow")
            {
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                HiddenField hdnOrderDetailid = (HiddenField)row.FindControl("hdnOrderDetailid");
                HiddenField ThisIndex = (HiddenField)row.FindControl("hdnIndex");

                if (Convert.ToInt32(hdnOrderDetailid.Value) > 0)
                {
                    int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
                    string ErrorMsg = objOrderPlaceController.DeleteOrderDetail(Convert.ToInt32(hdnOrderDetailid.Value), UserId);
                    if ((ErrorMsg == "") || (ErrorMsg == string.Empty))
                    {
                        PopulateOrderData(null);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "jQuery.facebox('" + ErrorMsg + "');", true);
                        return;
                    }
                }
                else
                {
                    List<ContractDetails> orderDetailCollection = new List<ContractDetails>();
                    double BiplPrice = 0;
                    string FileUpload1 = "";
                    string FileUpload2 = "";

                    for (int i = 0; i < gvDetailSection.Rows.Count; i++)
                    {
                        HiddenField hdnIndex = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnIndex");
                        HiddenField hdnOrderDetailidRow = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnOrderDetailid");
                        TextBox txtLineNo = (TextBox)gvDetailSection.Rows[i].FindControl("txtLineNo");
                        TextBox txtContractNo = (TextBox)gvDetailSection.Rows[i].FindControl("txtContractNo");
                        HiddenField hdnPoUpload1 = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnPoUpload1");
                        HiddenField hdnPoUpload2 = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnPoUpload2");
                        TextBox txtQty = (TextBox)gvDetailSection.Rows[i].FindControl("txtQty");
                        TextBox txtBIPLPrice = (TextBox)gvDetailSection.Rows[i].FindControl("txtBIPLPrice");
                        TextBox txtikandiPrice = (TextBox)gvDetailSection.Rows[i].FindControl("txtikandiPrice");
                        HiddenField hdnExFactoryWeek = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnExFactoryWeek");
                        HiddenField hdnDCWeek = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnDCWeek");
                        HiddenField hdnExFactoryColor = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnExFactoryColor");
                        TextBox txtDelivery = (TextBox)gvDetailSection.Rows[i].FindControl("txtDelivery");
                        HiddenField hdnMode = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnMode");
                        TextBox txtExFactory = (TextBox)gvDetailSection.Rows[i].FindControl("txtExFactory");
                        TextBox txtDC = (TextBox)gvDetailSection.Rows[i].FindControl("txtDC");
                        DropDownList ddlDelivery = (DropDownList)gvDetailSection.Rows[i].FindControl("ddlDelivery");
                        HiddenField hdnOrderDetailid_Ref = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnOrderDetailid_Ref");
                        HiddenField hdnIsSplit = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnIsSplit");
                        HiddenField hdnIsSplited = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnIsSplited");
                        HiddenField hdnSizeQty = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnSizeQty");
                        HiddenField hdnCountry_CodeId = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnCountry_CodeId");
                        HiddenField hdnCountryCode = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnCountryCode");
                        HiddenField hdnLeadTime = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnLeadTime");

                        if (ThisIndex.Value != hdnIndex.Value)
                        {
                            BiplPrice = txtBIPLPrice.Text == "" ? 0 : Convert.ToDouble(txtBIPLPrice.Text);
                            FileUpload1 = hdnPoUpload1.Value;
                            FileUpload2 = hdnPoUpload2.Value;

                            ContractDetails orderdetail = new ContractDetails();

                            orderdetail.OrderDetailId = hdnOrderDetailidRow.Value == "" ? -1 : Convert.ToInt32(hdnOrderDetailidRow.Value);
                            orderdetail.OrderDetailId_Ref = hdnOrderDetailid_Ref.Value == "" ? -1 : Convert.ToInt32(hdnOrderDetailid_Ref.Value);
                            orderdetail.LineItemNumber = txtLineNo.Text;
                            orderdetail.ContractNumber = txtContractNo.Text;
                            orderdetail.PoUpload1 = FileUpload1;
                            orderdetail.PoUpload2 = FileUpload2;
                            orderdetail.Quantity = txtQty.Text == "" ? 0 : Convert.ToInt32(txtQty.Text);
                            orderdetail.BiplPrice = txtBIPLPrice.Text == "" ? -1 : Convert.ToDouble(txtBIPLPrice.Text);
                            orderdetail.ikandiPrice = txtikandiPrice.Text == "" ? -1 : Convert.ToDouble(txtikandiPrice.Text);
                            orderdetail.ExFactory = txtExFactory.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtExFactory.Text.Trim()).Value;
                            orderdetail.DC = txtDC.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtDC.Text).Value;
                            orderdetail.ExFactoryWeek = hdnExFactoryWeek.Value == "" ? -1 : Convert.ToInt32(hdnExFactoryWeek.Value);
                            orderdetail.DCWeek = hdnDCWeek.Value == "" ? -1 : Convert.ToInt32(hdnDCWeek.Value);
                            orderdetail.DeliveryInstruction = DeliveryInstruction(txtDelivery.Text);
                            orderdetail.ModeId = hdnMode.Value == "" ? -1 : Convert.ToInt32(hdnMode.Value);
                            orderdetail.ExFactoryColor = hdnExFactoryColor.Value;
                            orderdetail.typeofpacking = Convert.ToInt32(ddlDelivery.SelectedValue);
                            orderdetail.SizeQty = hdnSizeQty.Value == "" ? -1 : Convert.ToInt32(hdnSizeQty.Value);
                            orderdetail.isSplit = hdnIsSplit.Value == "" ? -1 : Convert.ToInt32(hdnIsSplit.Value);
                            orderdetail.isSplitted = hdnIsSplited.Value == "" ? 0 : Convert.ToInt32(hdnIsSplited.Value);
                            orderdetail.CountryCodeId = hdnCountry_CodeId.Value == "" ? 0 : Convert.ToInt32(hdnCountry_CodeId.Value);
                            orderdetail.CountryCode = hdnCountryCode.Value;
                            orderdetail.LeadTime = hdnLeadTime.Value == "" ? 0 : Convert.ToInt32(hdnLeadTime.Value);

                            // Find Agreement Value
                            HiddenField hdnLineNo_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnLineNo_agree");
                            HiddenField hdnQty_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnQty_agree");
                            HiddenField hdnAgreementMode = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnAgreementMode");
                            HiddenField hdnContactNo_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnContactNo_agree");
                            HiddenField hdnBiplPrice_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnBiplPrice_agree");
                            HiddenField hdnExFactory_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnExFactory_agree");
                            HiddenField hdnExFactoryWeek_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnExFactoryWeek_agree");
                            HiddenField hdnPoUpload1_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnPoUpload1_agree");
                            HiddenField hdnikandiPrice_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnikandiPrice_agree");
                            HiddenField hdnDC_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnDC_agree");
                            HiddenField hdnDCWeek_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnDCWeek_agree");
                            HiddenField hdnPoUpload2_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnPoUpload2_agree");
                            HiddenField hdnDeliver_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnDeliver_agree");
                            HiddenField hdnddlDelivery_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnddlDelivery_agree");
                            HiddenField hdnCountryCode_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnCountryCode_agree");

                            orderdetail.LineItemNumber_d = hdnLineNo_agree.Value;
                            orderdetail.ContractNumber_d = hdnContactNo_agree.Value;
                            orderdetail.PoUpload1_d = hdnPoUpload1_agree.Value;
                            orderdetail.PoUpload2_d = hdnPoUpload2_agree.Value;
                            orderdetail.Quantity_d = hdnQty_agree.Value == "" ? -1 : Convert.ToInt32(hdnQty_agree.Value);
                            orderdetail.BiplPrice_d = hdnBiplPrice_agree.Value == "" ? -1 : Convert.ToDouble(hdnBiplPrice_agree.Value);
                            orderdetail.ikandiPrice_d = hdnikandiPrice_agree.Value == "" ? -1 : Convert.ToDouble(hdnikandiPrice_agree.Value); ;
                            orderdetail.ExFactory_d = hdnExFactory_agree.Value == "" ? DateTime.MinValue : DateHelper.ParseDate(hdnExFactory_agree.Value).Value;
                            orderdetail.ExFactoryWeek_d = hdnExFactoryWeek_agree.Value == "" ? -1 : Convert.ToInt32(hdnExFactoryWeek_agree.Value);
                            orderdetail.DC_d = hdnDC_agree.Value == "" ? DateTime.MinValue : DateHelper.ParseDate(hdnDC_agree.Value).Value;
                            orderdetail.DCWeek_d = hdnDCWeek_agree.Value == "" ? -1 : Convert.ToInt32(hdnDCWeek_agree.Value);
                            orderdetail.DeliveryInstruction_d = hdnDeliver_agree.Value == "" ? -1 : Convert.ToInt32(hdnDeliver_agree.Value);
                            orderdetail.typeofpacking_d = hdnddlDelivery_agree.Value == "" ? -1 : Convert.ToInt32(hdnddlDelivery_agree.Value);
                            orderdetail.ModeCode_d = hdnAgreementMode.Value.ToString();
                            orderdetail.CountryCode_d = hdnCountryCode_agree.Value.ToString();

                            // Fabric Section 

                            List<ContractDetailFabric> objFabricCollection = new List<ContractDetailFabric>();

                            DataList dlstFabric = (DataList)gvDetailSection.Rows[i].FindControl("dlstFabric");

                            for (int fabNo = 0; fabNo < dlstFabric.Items.Count; fabNo++)
                            {
                                HiddenField hdnFabric = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnFabric");
                                TextBox txtFabric = (TextBox)dlstFabric.Items[fabNo].FindControl("txtFabric");
                                HiddenField hdnCountCnstr = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnCountCnstr");
                                HiddenField hdnGSM = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnGSM");
                                HiddenField hdnFabriQualityId = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnFabriQualityId");
                                HtmlInputHidden hdnFabricType = (HtmlInputHidden)dlstFabric.Items[fabNo].FindControl("hdnFabricType");
                                TextBox txtFabricType = (TextBox)dlstFabric.Items[fabNo].FindControl("txtFabricType");
                                TextBox txtFabricDetail = (TextBox)dlstFabric.Items[fabNo].FindControl("txtFabricDetail");
                                HiddenField hdnFabricDetail_d = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnFabricDetail_d");

                                ContractDetailFabric orderDetailFabric = new ContractDetailFabric();

                                orderDetailFabric.FabricId = hdnFabric.Value == "" ? -1 : Convert.ToInt32(hdnFabric.Value);
                                orderDetailFabric.FabricName = txtFabric.Text;
                                orderDetailFabric.CountConstruct = hdnCountCnstr.Value;
                                orderDetailFabric.GSM = hdnGSM.Value == "" ? -1 : Convert.ToDouble(hdnGSM.Value);
                                orderDetailFabric.fabric_qualityID = hdnFabriQualityId.Value == "" ? -1 : Convert.ToInt32(hdnFabriQualityId.Value);
                                orderDetailFabric.FabTypeId = Convert.ToInt32(hdnFabricType.Value);
                                orderDetailFabric.FabType = txtFabricType.Text;
                                orderDetailFabric.FabricDetail = txtFabricDetail.Text;
                                orderDetailFabric.FabricDetail_d = hdnFabricDetail_d.Value;
                                objFabricCollection.Add(orderDetailFabric);
                            }

                            orderdetail.ContractFabric = objFabricCollection;

                            //Start Accessories Section

                            List<ContractDetailAccessories> objAccessCollection = new List<ContractDetailAccessories>();

                            DataList dlstAccessories = (DataList)gvDetailSection.Rows[i].FindControl("dlstAccessories");

                            for (int AccNo = 0; AccNo < dlstAccessories.Items.Count; AccNo++)
                            {
                                HtmlInputHidden hdnAccessId = (HtmlInputHidden)dlstAccessories.Items[AccNo].FindControl("hdnAccessId_");
                                HiddenField hdnAccessName = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnAccessName_");
                                HiddenField hdnAccessSizeId = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnAccessSizeId_");
                                HiddenField hdnAccessSize = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnAccessSize_");
                                TextBox txtAccessVal = (TextBox)dlstAccessories.Items[AccNo].FindControl("txtAccessVal_");
                                CheckBox chkDTM = (CheckBox)dlstAccessories.Items[AccNo].FindControl("chkDTM");
                                HiddenField hdnAccessColorPrint_d = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnAccessColorPrint_d");
                                HiddenField hdnIsDTM_d = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnIsDTM_d");

                                ContractDetailAccessories orderDetailAccess = new ContractDetailAccessories();
                                orderDetailAccess.AccessoriesId = hdnAccessId.Value == "" ? -1 : Convert.ToInt32(hdnAccessId.Value);
                                orderDetailAccess.AccessoriesName = hdnAccessName.Value;
                                orderDetailAccess.SizeId = hdnAccessSizeId.Value == "" ? -1 : Convert.ToInt32(hdnAccessSizeId.Value);
                                orderDetailAccess.Size = hdnAccessSize.Value;
                                orderDetailAccess.ColorPrint = txtAccessVal.Text == "" ? DBNull.Value.ToString() : txtAccessVal.Text;
                                orderDetailAccess.IsDtm = chkDTM.Checked;
                                orderDetailAccess.ColorPrint_d = hdnAccessColorPrint_d.Value;
                                orderDetailAccess.IsDtm_d = hdnIsDTM_d.Value;
                                orderDetailAccess.SeqId = AccNo;

                                objAccessCollection.Add(orderDetailAccess);
                            }


                            orderdetail.ContractAccessories = objAccessCollection;

                            orderDetailCollection.Add(orderdetail);
                        }
                    }
                    PopulateOrderData(orderDetailCollection);
                    //UpdatePanel1.Update();
                }

                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "PopulateOnPageLoad();", true);

            }
        }

        protected void gvDetailSection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            int iRowIndex = e.Row.RowIndex;
            ContractDetails od = (e.Row.DataItem as ContractDetails);

            if (e.Row.RowType == DataControlRowType.Header)
            {
                HtmlGenericControl FabricDetailsLink = (HtmlGenericControl)e.Row.FindControl("FabricDetailsLink");
                HtmlGenericControl AccessoryDetailLink = (HtmlGenericControl)e.Row.FindControl("AccessoryDetailLink");
                // Below check is Added by Sanjeev on 26/08/2021 (for no link untill aproval of both BiplManager && AcountManager ) 
                if ((chkAcountManager.Checked) && (chkAcountManager.Enabled == false) && (chkBiplManager.Checked) && (chkBiplManager.Enabled == false))
                {
                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC_DETAILS))
                        FabricDetailsLink.Attributes.Add("class", "hide_me");

                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_ACCESSORY_DETAIL))
                        AccessoryDetailLink.Attributes.Add("class", "hide_me");

                    if (btnAgree.Visible == true)
                    {
                        FabricDetailsLink.Attributes.Add("class", "hide_me");
                        AccessoryDetailLink.Attributes.Add("class", "hide_me");
                    }
                }
                else
                {
                    FabricDetailsLink.Attributes.Add("class", "hide_me");
                    AccessoryDetailLink.Attributes.Add("class", "hide_me");
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnOrderDetailid = (HiddenField)e.Row.FindControl("hdnOrderDetailid");
                HiddenField hdnOrderDetailid_Ref = (HiddenField)e.Row.FindControl("hdnOrderDetailid_Ref");
                HiddenField hdnIndex = (HiddenField)e.Row.FindControl("hdnIndex");
                TextBox txtLineNo = (TextBox)e.Row.FindControl("txtLineNo");
                TextBox txtContractNo = (TextBox)e.Row.FindControl("txtContractNo");
                HyperLink hlkPoUpload1 = (HyperLink)e.Row.FindControl("hlkPoUpload1");
                HyperLink hlkPoUpload2 = (HyperLink)e.Row.FindControl("hlkPoUpload2");
                HiddenField hdnPoUpload1 = (HiddenField)e.Row.FindControl("hdnPoUpload1");
                HiddenField hdnPoUpload2 = (HiddenField)e.Row.FindControl("hdnPoUpload2");

                TextBox txtQty = (TextBox)e.Row.FindControl("txtQty");
                TextBox txtBIPLPrice = (TextBox)e.Row.FindControl("txtBIPLPrice");
                TextBox txtikandiPrice = (TextBox)e.Row.FindControl("txtikandiPrice");
                TextBox txtExFactoryWeek = (TextBox)e.Row.FindControl("txtExFactoryWeek");
                TextBox txtDCWeek = (TextBox)e.Row.FindControl("txtDCWeek");
                TextBox txtDelivery = (TextBox)e.Row.FindControl("txtDelivery");
                HiddenField hdnExFactoryWeek = (HiddenField)e.Row.FindControl("hdnExFactoryWeek");
                HiddenField hdnDCWeek = (HiddenField)e.Row.FindControl("hdnDCWeek");
                HiddenField hdnSizeQty = (HiddenField)e.Row.FindControl("hdnSizeQty");

                DropDownList ddlMode = (DropDownList)e.Row.FindControl("ddlMode");
                HiddenField hdnMode = (HiddenField)e.Row.FindControl("hdnMode");
                DropDownList ddlCountryCode = (DropDownList)e.Row.FindControl("ddlCountryCode");
                HiddenField hdnCountry_CodeId = (HiddenField)e.Row.FindControl("hdnCountry_CodeId");
                HiddenField hdnCountryCode_agree = (HiddenField)e.Row.FindControl("hdnCountryCode_agree");
                HiddenField hdnCountryCode = (HiddenField)e.Row.FindControl("hdnCountryCode");

                TextBox txtExFactory = (TextBox)e.Row.FindControl("txtExFactory");
                TextBox txtDC = (TextBox)e.Row.FindControl("txtDC");
                HiddenField hdnDC = (HiddenField)e.Row.FindControl("hdnDC");
                DropDownList ddlDelivery = (DropDownList)e.Row.FindControl("ddlDelivery");
                Label lblSymblBIPLPrice = (Label)e.Row.FindControl("lblSymblBIPLPrice");
                Label lblSymblikandiPrice = (Label)e.Row.FindControl("lblSymblikandiPrice");
                Label lblQtyPcs = (Label)e.Row.FindControl("lblQtyPcs");
                ImageButton imgbtnAdd = (ImageButton)e.Row.FindControl("imgbtnAdd");
                ImageButton imgbtnDel = (ImageButton)e.Row.FindControl("imgbtnDel");
                HiddenField hdnExFactoryColor = (HiddenField)e.Row.FindControl("hdnExFactoryColor");
                HtmlTableCell tdExFactory = e.Row.FindControl("tdExFactory") as HtmlTableCell;
                HyperLink hlnkSize = e.Row.FindControl("hlnkSize") as HyperLink;
                HiddenField hdnIsSplit = (HiddenField)e.Row.FindControl("hdnIsSplit");
                HiddenField hdnIsSplited = (HiddenField)e.Row.FindControl("hdnIsSplited");
                HtmlGenericControl FileUpload1 = (HtmlGenericControl)e.Row.FindControl("FileUpload1");
                HtmlImage imgSplit = (HtmlImage)e.Row.FindControl("imgSplit");


                int CostingId = hdnCostingId != null ? Convert.ToInt32(hdnCostingId.Value) : -1;
                bool IsIkandiClient = hdnIsIkandiClient.Value != null ? Convert.ToBoolean(hdnIsIkandiClient.Value) : false;
                int clientId = Convert.ToInt32(ddlClient.SelectedValue);
                int DepartmentId = Convert.ToInt32(hdnDeptId.Value);

                hdnOrderDetailid.Value = DataBinder.Eval(e.Row.DataItem, "OrderDetailId") == DBNull.Value ? "-1" : DataBinder.Eval(e.Row.DataItem, "OrderDetailId").ToString();
                hdnOrderDetailid_Ref.Value = DataBinder.Eval(e.Row.DataItem, "OrderDetailId_Ref") == DBNull.Value ? "-1" : DataBinder.Eval(e.Row.DataItem, "OrderDetailId_Ref").ToString();
                hdnIsSplit.Value = DataBinder.Eval(e.Row.DataItem, "isSplit") == DBNull.Value ? "-1" : DataBinder.Eval(e.Row.DataItem, "isSplit").ToString();
                hdnIsSplited.Value = DataBinder.Eval(e.Row.DataItem, "isSplitted") == DBNull.Value ? "-1" : DataBinder.Eval(e.Row.DataItem, "isSplitted").ToString();

                txtLineNo.Text = DataBinder.Eval(e.Row.DataItem, "LineItemNumber").ToString();
                txtContractNo.Text = DataBinder.Eval(e.Row.DataItem, "ContractNumber").ToString();
                hlkPoUpload1.Visible = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "PoUpload1").ToString())) ? false : true;
                hlkPoUpload1.NavigateUrl = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "PoUpload1").ToString())) ? "" : OrderFolderPath + DataBinder.Eval(e.Row.DataItem, "PoUpload1").ToString();
                hdnPoUpload1.Value = DataBinder.Eval(e.Row.DataItem, "PoUpload1").ToString();

                hlkPoUpload2.Visible = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "PoUpload2").ToString())) ? false : true;
                hlkPoUpload2.NavigateUrl = (string.IsNullOrEmpty(DataBinder.Eval(e.Row.DataItem, "PoUpload2").ToString())) ? "" : OrderFolderPath + DataBinder.Eval(e.Row.DataItem, "PoUpload2").ToString();
                hdnPoUpload2.Value = DataBinder.Eval(e.Row.DataItem, "PoUpload2").ToString();

                txtQty.Text = DataBinder.Eval(e.Row.DataItem, "Quantity").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "Quantity").ToString();
                txtBIPLPrice.Text = String.Format("{0:0.00}", DataBinder.Eval(e.Row.DataItem, "BiplPrice"));
                txtikandiPrice.Text = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ikandiPrice")) > 0 ? String.Format("{0:0.00}", DataBinder.Eval(e.Row.DataItem, "ikandiPrice")) : "";

                int dlinst = DataBinder.Eval(e.Row.DataItem, "DeliveryInstruction") == DBNull.Value ? -1 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DeliveryInstruction"));
                txtDelivery.Text = DeliveryInstruction(dlinst);

                hdnExFactoryWeek.Value = DataBinder.Eval(e.Row.DataItem, "ExFactoryWeek").ToString();
                hdnDCWeek.Value = DataBinder.Eval(e.Row.DataItem, "DCWeek").ToString();

                txtExFactoryWeek.Text = DataBinder.Eval(e.Row.DataItem, "ExFactoryWeek").ToString() == "-1" ? "" : "(" + DataBinder.Eval(e.Row.DataItem, "ExFactoryWeek").ToString() + ")";
                txtDCWeek.Text = DataBinder.Eval(e.Row.DataItem, "DCWeek").ToString() == "-1" ? "" : "(" + DataBinder.Eval(e.Row.DataItem, "DCWeek").ToString() + ")";

                int ModeId = DataBinder.Eval(e.Row.DataItem, "ModeId").ToString() == "" ? -1 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ModeId"));

                hdnMode.Value = ModeId.ToString();

                if ((hdnIsSplit.Value == "1") && (Convert.ToInt32(hdnOrderDetailid.Value) <= 0))
                {
                    BindMode(IsIkandiClient, CostingId, clientId, DepartmentId, ddlMode, ModeId, Convert.ToInt32(hdnOrderDetailid_Ref.Value));
                }
                else
                {
                    BindMode(IsIkandiClient, CostingId, clientId, DepartmentId, ddlMode, ModeId, Convert.ToInt32(hdnOrderDetailid.Value));
                }

                int CountryCodeID = DataBinder.Eval(e.Row.DataItem, "CountryCodeId").ToString() == "" ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CountryCodeId"));
                hdnCountry_CodeId.Value = CountryCodeID.ToString();
                BindCountryCode(clientId, ddlCountryCode, CountryCodeID);

                string CountryCode_d = DataBinder.Eval(e.Row.DataItem, "CountryCode_d").ToString();
                hdnCountryCode_agree.Value = CountryCode_d.ToString();

                string CountryCode = DataBinder.Eval(e.Row.DataItem, "CountryCode").ToString();
                hdnCountryCode.Value = CountryCode;

                if ((ddlMode.SelectedItem.Text == "L-A/F(SH-FOB)") || (ddlMode.SelectedItem.Text == "L-S/F(SH-FOB)"))
                {
                    ddlCountryCode.Attributes.Add("disabled", "disabled");
                }

                DateTime dtExFactory = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ExFactory"));
                txtExFactory.Text = dtExFactory == DateTime.MinValue ? "" : dtExFactory.ToString("dd MMM yy (ddd)");

                DateTime dtDC = Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DC"));
                txtDC.Text = dtDC == DateTime.MinValue ? "" : dtDC.ToString("dd MMM yy (ddd)");
                hdnDC.Value = dtDC == DateTime.MinValue ? "" : dtDC.ToString("dd MMM yy (ddd)");

                txtExFactory.Attributes.Add("readonly", "readonly");
                txtDC.Attributes.Add("readonly", "readonly");

                //txtDC.CssClass = "DC DCDate do-not-allow-typing hasDatepicker";

                ddlDelivery.SelectedValue = DataBinder.Eval(e.Row.DataItem, "typeofpacking").ToString();


                lblSymblBIPLPrice.Text = txtBIPLPrice.Text == "" ? "" : hdnCurrencySign.Value.ToString();
                lblSymblikandiPrice.Text = txtikandiPrice.Text == "" ? "" : hdnCurrencySign.Value.ToString();
                lblQtyPcs.Text = txtQty.Text == "" ? "" : "Pcs";

                string ExFactoryColor = DataBinder.Eval(e.Row.DataItem, "ExFactoryColor").ToString();
                hdnExFactoryColor.Value = ExFactoryColor;
                tdExFactory.Style.Add("background-color", ExFactoryColor);

                if (hdnIsIkandiUser.Value == "true")
                    txtBIPLPrice.CssClass = "do-not-allow-typing";

                if (IsIkandiClient == false)
                    txtikandiPrice.Attributes.Add("readonly", "readonly");


                // Find Agreement Value
                HiddenField hdnLineNo_agree = (HiddenField)e.Row.FindControl("hdnLineNo_agree");
                HiddenField hdnQty_agree = (HiddenField)e.Row.FindControl("hdnQty_agree");
                HiddenField hdnAgreementMode = (HiddenField)e.Row.FindControl("hdnAgreementMode");
                HiddenField hdnContactNo_agree = (HiddenField)e.Row.FindControl("hdnContactNo_agree");
                HiddenField hdnBiplPrice_agree = (HiddenField)e.Row.FindControl("hdnBiplPrice_agree");
                HiddenField hdnExFactory_agree = (HiddenField)e.Row.FindControl("hdnExFactory_agree");
                HiddenField hdnExFactoryWeek_agree = (HiddenField)e.Row.FindControl("hdnExFactoryWeek_agree");
                HiddenField hdnPoUpload1_agree = (HiddenField)e.Row.FindControl("hdnPoUpload1_agree");
                HiddenField hdnikandiPrice_agree = (HiddenField)e.Row.FindControl("hdnikandiPrice_agree");
                HiddenField hdnDC_agree = (HiddenField)e.Row.FindControl("hdnDC_agree");
                HiddenField hdnDCWeek_agree = (HiddenField)e.Row.FindControl("hdnDCWeek_agree");
                HiddenField hdnPoUpload2_agree = (HiddenField)e.Row.FindControl("hdnPoUpload2_agree");
                HiddenField hdnDeliver_agree = (HiddenField)e.Row.FindControl("hdnDeliver_agree");
                HiddenField hdnddlDelivery_agree = (HiddenField)e.Row.FindControl("hdnddlDelivery_agree");

                hdnLineNo_agree.Value = DataBinder.Eval(e.Row.DataItem, "LineItemNumber_d").ToString();
                hdnQty_agree.Value = DataBinder.Eval(e.Row.DataItem, "Quantity_d").ToString();
                hdnAgreementMode.Value = DataBinder.Eval(e.Row.DataItem, "ModeCode_d").ToString();
                hdnContactNo_agree.Value = DataBinder.Eval(e.Row.DataItem, "ContractNumber_d").ToString();
                hdnBiplPrice_agree.Value = DataBinder.Eval(e.Row.DataItem, "BiplPrice_d").ToString();

                hdnExFactory_agree.Value = DataBinder.Eval(e.Row.DataItem, "ExFactory_d").ToString();
                hdnExFactoryWeek_agree.Value = DataBinder.Eval(e.Row.DataItem, "ExFactoryWeek_d").ToString();
                hdnPoUpload1_agree.Value = DataBinder.Eval(e.Row.DataItem, "PoUpload1_d").ToString();
                hdnikandiPrice_agree.Value = DataBinder.Eval(e.Row.DataItem, "ikandiPrice_d").ToString();
                hdnDC_agree.Value = DataBinder.Eval(e.Row.DataItem, "DC_d").ToString();
                hdnDCWeek_agree.Value = DataBinder.Eval(e.Row.DataItem, "DCWeek_d").ToString();
                hdnPoUpload2_agree.Value = DataBinder.Eval(e.Row.DataItem, "PoUpload2_d").ToString();
                hdnDeliver_agree.Value = DataBinder.Eval(e.Row.DataItem, "DeliveryInstruction_d").ToString();
                hdnddlDelivery_agree.Value = DataBinder.Eval(e.Row.DataItem, "typeofpacking_d").ToString();

                Label lblLineNo_agree = (Label)e.Row.FindControl("lblLineNo_agree");
                Label lblQty_agree = (Label)e.Row.FindControl("lblQty_agree");
                Label lblMode_agree = (Label)e.Row.FindControl("lblMode_agree");
                Label lblContactNo_agree = (Label)e.Row.FindControl("lblContactNo_agree");
                Label lblBiplPrice_agree = (Label)e.Row.FindControl("lblBiplPrice_agree");
                Label lblExFactory_agree = (Label)e.Row.FindControl("lblExFactory_agree");
                Label lblExFactoryWeek_agree = (Label)e.Row.FindControl("lblExFactoryWeek_agree");
                Label lblPoUpload1_agree = (Label)e.Row.FindControl("lblPoUpload1_agree");
                Label lblikandiPrice_agree = (Label)e.Row.FindControl("lblikandiPrice_agree");
                Label lblDC_agree = (Label)e.Row.FindControl("lblDC_agree");
                Label lblDCWeek_agree = (Label)e.Row.FindControl("lblDCWeek_agree");
                Label lblPoUpload2_agree = (Label)e.Row.FindControl("lblPoUpload2_agree");
                Label lblDeliver_agree = (Label)e.Row.FindControl("lblDeliver_agree");
                Label lblddlDelivery_agree = (Label)e.Row.FindControl("lblddlDelivery_agree");
                Label lblCountryCode_agree = (Label)e.Row.FindControl("lblCountryCode_agree");

                if ((hdnLineNo_agree.Value != "") && (hdnLineNo_agree.Value != txtLineNo.Text))
                {
                    lblLineNo_agree.Text = "<span class='tooltiptext_M'>" + hdnLineNo_agree.Value + "</span>";
                    lblLineNo_agree.CssClass = "lblhover";
                }
                if ((Convert.ToInt32(hdnQty_agree.Value) > 0) && (Convert.ToInt32(hdnQty_agree.Value) != Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quantity"))))
                {
                    lblQty_agree.Text = "<span class='tooltiptext_S'>" + hdnQty_agree.Value + "</span>";
                    lblQty_agree.CssClass = "lblhover";
                }
                if ((hdnAgreementMode.Value != "") && (hdnAgreementMode.Value.Trim() != ddlMode.SelectedItem.Text.Trim()))
                {
                    lblMode_agree.Text = "<span class='tooltiptext_M'>" + hdnAgreementMode.Value + "</span>";
                    lblMode_agree.CssClass = "lblhover";
                }
                if ((hdnContactNo_agree.Value != "") && (hdnContactNo_agree.Value.Trim() != txtContractNo.Text.Trim()))
                {
                    lblContactNo_agree.Text = "<span class='tooltiptext_M'>" + hdnContactNo_agree.Value + "</span>";
                    lblContactNo_agree.CssClass = "lblhover";
                }
                if ((Convert.ToDouble(hdnBiplPrice_agree.Value) > 0) && (Convert.ToDouble(hdnBiplPrice_agree.Value) != Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "BiplPrice"))))
                {
                    lblBiplPrice_agree.Text = "<span class='tooltiptext_S'>" + hdnBiplPrice_agree.Value + "</span>";
                    lblBiplPrice_agree.CssClass = "lblhover";
                }
                if ((Convert.ToDouble(hdnikandiPrice_agree.Value) > 0) && (Convert.ToDouble(hdnikandiPrice_agree.Value) != Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "ikandiPrice"))))
                {
                    lblikandiPrice_agree.Text = "<span class='tooltiptext_S'>" + hdnikandiPrice_agree.Value + "</span>";
                    lblikandiPrice_agree.CssClass = "lblhover";
                }
                string ExFactoryDetails = "";
                if ((Convert.ToDateTime(hdnExFactory_agree.Value) != DateTime.MinValue) && (Convert.ToDateTime(hdnExFactory_agree.Value) != Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "ExFactory"))))
                {
                    ExFactoryDetails = Convert.ToDateTime(hdnExFactory_agree.Value).ToString("dd MMM yy (ddd)");

                }
                if ((Convert.ToInt32(hdnExFactoryWeek_agree.Value) > 0) && (Convert.ToInt32(hdnExFactoryWeek_agree.Value) != Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ExFactoryWeek"))))
                {
                    ExFactoryDetails = ExFactoryDetails + " (" + hdnExFactoryWeek_agree.Value + ")";

                    //lblExFactoryWeek_agree.Text = "<span class='tooltiptext_Day'>(" + hdnExFactoryWeek_agree.Value + ")</span>";
                    //lblExFactoryWeek_agree.CssClass = "lblhover";
                }
                if (ExFactoryDetails != "")
                {
                    lblExFactory_agree.Text = "<span class='tooltiptext_M'>" + ExFactoryDetails + "</span>";
                    lblExFactory_agree.CssClass = "lblhover";
                }
                if ((Convert.ToDateTime(hdnDC_agree.Value) != DateTime.MinValue) && (Convert.ToDateTime(hdnDC_agree.Value) != Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "DC"))))
                {
                    lblDC_agree.Text = "<span class='tooltiptext_M'>" + Convert.ToDateTime(hdnDC_agree.Value).ToString("dd MMM yy (ddd)") + "</span>";
                    lblDC_agree.CssClass = "lblhover";
                }

                if ((Convert.ToInt32(hdnDCWeek_agree.Value) > 0) && (Convert.ToInt32(hdnDCWeek_agree.Value) != Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DCWeek"))))
                {
                    lblDCWeek_agree.Text = "<span class='tooltiptext_Day'>(" + hdnDCWeek_agree.Value + ")</span>";
                    lblDCWeek_agree.CssClass = "lblhover";
                }
                if ((Convert.ToInt32(hdnddlDelivery_agree.Value) > 0) && (Convert.ToInt32(hdnddlDelivery_agree.Value) != Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "typeofpacking"))))
                {
                    lblddlDelivery_agree.Text = "<span class='tooltiptext_S'>(" + TypeOfPacking(Convert.ToInt32(hdnddlDelivery_agree.Value)) + ")</span>";
                    lblddlDelivery_agree.CssClass = "lblhover";
                }

                if ((hdnPoUpload1_agree.Value != "") && (hdnPoUpload1_agree.Value != DataBinder.Eval(e.Row.DataItem, "PoUpload1").ToString()))
                {
                    string sPath = "../../Uploads/Order/" + hdnPoUpload1_agree.Value;
                    lblPoUpload1_agree.Attributes.Add("onclick", "javascript:return DownloadFile('" + sPath + "')");
                    lblPoUpload1_agree.CssClass = "lblhover Pointer";
                }
                if ((hdnPoUpload2_agree.Value != "") && (hdnPoUpload2_agree.Value != DataBinder.Eval(e.Row.DataItem, "PoUpload2").ToString()))
                {
                    string sPath = "../../Uploads/Order/" + hdnPoUpload2_agree.Value;
                    lblPoUpload2_agree.Attributes.Add("onclick", "javascript:return DownloadFile('" + sPath + "')");
                    lblPoUpload2_agree.CssClass = "lblhover Pointer";
                }

                if ((hdnCountryCode_agree.Value != "") && (hdnCountryCode_agree.Value.Trim() != hdnCountryCode.Value.Trim()))
                {
                    lblCountryCode_agree.Text = "<span class='tooltiptext_S'>" + hdnCountryCode_agree.Value + "</span>";
                    lblCountryCode_agree.CssClass = "lblhover";
                }

                string newDelivery = Convert.ToInt32(hdnDeliver_agree.Value) > 0 ? DeliveryInstruction(Convert.ToInt32(hdnDeliver_agree.Value)) : "";

                if ((newDelivery != "") && (newDelivery != txtDelivery.Text))
                {
                    lblDeliver_agree.Text = "<span class='tooltiptext_S'>" + newDelivery + "</span>";
                    lblDeliver_agree.CssClass = "lblhover";
                }

                DataList dlstFabric = (DataList)e.Row.FindControl("dlstFabric");
                dlstFabric.DataSource = od.ContractFabric;
                dlstFabric.DataBind();

                DataList dlstAccessories = (DataList)e.Row.FindControl("dlstAccessories");
                double floatCount = Convert.ToDouble(od.ContractAccessories.Count) / 4;
                double afterDecimal = floatCount - Math.Floor(floatCount);

                int AccessoriesCount = od.ContractAccessories.Count / 4;

                if (afterDecimal > 0)
                    AccessoriesCount = AccessoriesCount + 1;

                dlstAccessories.DataSource = od.ContractAccessories;
                dlstAccessories.DataBind();
                dlstAccessories.RepeatColumns = AccessoriesCount;

                int SizeQty = hdnSizeQty.Value == "" ? 0 : Convert.ToInt32(hdnSizeQty.Value);
                int IsSplited = hdnIsSplited.Value == "" ? 0 : Convert.ToInt32(hdnIsSplited.Value);

                int Quantity = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Quantity"));

                int IsOrderConfirm = 0;

                if ((chkAcountManager.Checked) && (chkAcountManager.Enabled == false) && (chkBiplManager.Checked) && (chkBiplManager.Enabled == false))
                    IsOrderConfirm = 1;

                if ((Quantity + 1) == SizeQty)
                    Quantity = Quantity + 1;

                if ((Quantity - 1) == SizeQty)
                    Quantity = Quantity - 1;

                if (IsOrderConfirm == 1)
                {
                    if (IsSplited <= 0)
                    {
                        if (SizeQty > 0)
                        {
                            hlnkSize.Text = "Edit";

                            if (Quantity != SizeQty)
                                hlnkSize.ForeColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            if (Convert.ToInt32(hdnOrderDetailid.Value) > 0)
                            {
                                hlnkSize.Text = "Create";
                            }
                        }
                    }
                    imgbtnDel.CssClass = "hide_me";
                }

                hdnIndex.Value = iRowIndex.ToString();
                if ((iRowIndex == (Rowcount - 1)) && (chkAcountManager.Checked == false) && (chkBiplManager.Checked == false))
                {
                    imgbtnAdd.Visible = true;
                }

                if (btnAgree.Visible == true)
                {
                    imgbtnDel.CssClass = "hide_me";
                    imgSplit.Attributes.Add("class", "hide_me");
                    imgbtnAdd.Attributes.Add("class", "hide_me");
                }
                if (iRowIndex == 0)
                    imgbtnDel.CssClass = "hide_me";

                //---------------------------------------- APPLY PERMISSION ---------------------------------------------------


                if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_LINE_NO))
                    txtLineNo.CssClass = "hide_me";
                else
                {
                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_LINE_NO))
                        txtLineNo.CssClass = "do-not-allow-typing";
                }
                if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QTY))
                {
                    txtQty.CssClass = "hide_me";
                    lblQtyPcs.CssClass = "hide_me";
                }
                else
                {
                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_QTY))
                        txtQty.CssClass = "do-not-allow-typing";
                }

                if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_MODE))
                    ddlMode.CssClass = "hide_me";
                else
                {
                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_MODE))
                        ddlMode.CssClass = "disable-dropdown";
                }

                if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_CONTRACT_NO))
                    txtContractNo.CssClass = "hide_me";
                else
                {
                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_CONTRACT_NO))
                        txtContractNo.CssClass = "do-not-allow-typing";
                }

                if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_BIPL_PRICE))
                {
                    txtBIPLPrice.CssClass = "hide_me";
                    lblSymblBIPLPrice.CssClass = "hide_me";
                }
                else
                {
                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_BIPL_PRICE))
                        txtBIPLPrice.CssClass = "do-not-allow-typing";
                }

                if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_IKANDI_PRICE))
                {
                    txtikandiPrice.CssClass = "hide_me";
                    lblSymblikandiPrice.CssClass = "hide_me";
                }
                else
                {
                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_IKANDI_PRICE))
                        txtikandiPrice.CssClass = "do-not-allow-typing";
                }
                if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_PO_UPLOAD))
                    FileUpload1.Attributes.Add("class", "hide_me");
                else
                {
                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_PO_UPLOAD))
                        FileUpload1.Attributes.Add("class", "hide_me");
                }

                if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_EX_FACTORY))
                {
                    txtExFactory.CssClass = "hide_me";
                    txtExFactoryWeek.CssClass = "hide_me";
                }

                if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_DC_DATE))
                {
                    txtDC.CssClass = "hide_me";
                    txtDCWeek.CssClass = "hide_me";
                }
                else
                {
                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_DC_DATE))
                        txtDC.CssClass = "do-not-allow-typing";
                }

                if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_DILIVER_INSTRUCTION))
                    ddlDelivery.CssClass = "hide_me";
                else
                {
                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_DILIVER_INSTRUCTION))
                        ddlDelivery.CssClass = "disable-dropdown";
                }

                if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_COUNTRY_CODE))
                    ddlCountryCode.CssClass = "hide_me";
                else
                {
                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_COUNTRY_CODE))
                        ddlCountryCode.CssClass = "disable-dropdown";
                }

                if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SIZE))
                    hlnkSize.CssClass = "hide_me";
                else
                {
                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SIZE))
                        hlnkSize.CssClass = "hide_me";
                }

                if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SPLIT))
                    imgSplit.Attributes.Add("class", "hide_me");
                else
                {
                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_SPLIT))
                        imgSplit.Attributes.Add("class", "hide_me");
                }

                if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_CONTRACT_DELETE))
                    imgbtnDel.CssClass = "hide_me";
                else
                {
                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_CONTRACT_DELETE))
                        imgbtnDel.CssClass = "hide_me";
                }

                if (!PermissionHelper.IsReadPermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_CONTRACT_ADD))
                    imgbtnAdd.CssClass = "hide_me";
                else
                {
                    if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_CONTRACT_ADD))
                        imgbtnAdd.CssClass = "hide_me";
                }

            }
        }

        protected void dlstFabric_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string fabricType = (DataBinder.Eval(e.Item.DataItem, "FabTypeId")).ToString();

                TextBox txtFabricDetail = (TextBox)e.Item.FindControl("txtFabricDetail");
                HiddenField hdnstage1 = ((HiddenField)e.Item.FindControl("hdnstage1"));
                HiddenField hdnstage2 = ((HiddenField)e.Item.FindControl("hdnstage2"));
                HiddenField hdnStage3 = ((HiddenField)e.Item.FindControl("hdnstage3"));
                HiddenField hdnStage4 = ((HiddenField)e.Item.FindControl("hdnstage4"));

                HiddenField hdnCanChangeColorPrint = ((HiddenField)e.Item.FindControl("hdnCanChangeColorPrint"));

                //added by raghvinder on 21-09-2020 start
                TextBox txtFabric = (TextBox)e.Item.FindControl("txtFabric");
                HiddenField hdnFabricQualityDetailsID = (HiddenField)e.Item.FindControl("hdnFabricQualityDetailsID");
                Label lblGSM = (Label)e.Item.FindControl("lblGSM");


                int fabricQualityID = hdnFabricQualityDetailsID != null ? Convert.ToInt32(hdnFabricQualityDetailsID.Value) : -1;
                if (fabricQualityID >= 20000)
                {
                    txtFabric.Attributes.Add("Style", "");
                    chkAcountManager.Enabled = false;
                    chkBiplManager.Enabled = false;
                    lblMsgUnRegister.Text = "* To confirm the order, Make sure All Fabric/Accessories Quality should be registered!";
                }

                if (txtFabric.Text != "")
                {
                    txtFabric.ToolTip = txtFabric.Text;
                }
                // added by raghvinder on 21-09-2020 end
                string ss = "";
                if (txtFabricDetail.Text.Length > 4)
                    ss = txtFabricDetail.Text.Substring(0, 4);
                else
                    ss = txtFabricDetail.Text;

                if (fabricType == "0")
                {
                    txtFabricDetail.CssClass = "DyedRow";
                }
                else if (fabricType == "1")
                {
                    txtFabricDetail.CssClass = "ScreenPrntRow";
                }
                else if (fabricType == "2")
                {
                    txtFabricDetail.CssClass = "DigitalPrntRow";
                }

                string fabricDetail = (DataBinder.Eval(e.Item.DataItem, "FabricDetail")).ToString();
                string fabricDetail_d = (DataBinder.Eval(e.Item.DataItem, "FabricDetail_d")).ToString();

                Label lblFabricDetail_agree = (Label)e.Item.FindControl("lblFabricDetail_agree");
                if ((fabricDetail_d != "") && (fabricDetail_d != fabricDetail))
                {
                    lblFabricDetail_agree.Text = "<span class='fabric_detail'>" + fabricDetail_d + "</span>";
                    lblFabricDetail_agree.CssClass = "lblhover";
                }

                if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_FABRIC_COLOR_PRINT))
                    txtFabricDetail.CssClass = "do-not-allow-typing";

                //if ((chkFabricManager.Enabled == false) && (chkFabricManager.Checked == true) && (txtFabricDetail.Text.ToUpper() != "TBD"))
                //{
                //    txtFabricDetail.CssClass = "do-not-allow-typing";
                //}
                if (hdnCanChangeColorPrint.Value == "False")
                {
                    txtFabricDetail.CssClass = "do-not-allow-typing";
                }
                else
                {

                    txtFabricDetail.Attributes.Remove("class");
                }
                lblGSM.Text = lblGSM.Text == "0" ? "" : lblGSM.Text;
            }
        }

        protected void dlstAccessories_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hdnAccessName = (HiddenField)e.Item.FindControl("hdnAccessName_");
                HiddenField hdnAccessSizeId = (HiddenField)e.Item.FindControl("hdnAccessSizeId_");
                string size = (DataBinder.Eval(e.Item.DataItem, "Size")).ToString();
                TextBox txtAccessName = (TextBox)e.Item.FindControl("txtAccessName_");
                TextBox txtAccessVal_ = (TextBox)e.Item.FindControl("txtAccessVal_");
                  HiddenField HdnISSrvReceived=(HiddenField)e.Item.FindControl("HdnISSrvReceived");

                //added by raghvinder on 21-09-2020 start                
                HiddenField hdnAccessoriesId = (HiddenField)e.Item.FindControl("hdnAccessoriesId");
                int fabricQualityID = hdnAccessoriesId != null ? Convert.ToInt32(hdnAccessoriesId.Value) : -1;
                if (fabricQualityID >= 40000)
                {
                    txtAccessName.Attributes.Add("Style", "background-color:#bfbfbf !important");
                    chkAcountManager.Enabled = false;
                    chkBiplManager.Enabled = false;
                    lblMsgUnRegister.Text = "* To confirm the order, Make sure All Fabric/Accessories Quality should be registered!";
                }
                if (txtAccessVal_.Text != "")
                {
                    txtAccessVal_.ToolTip = txtAccessVal_.Text;
                }

                CheckBox chkDTM = (CheckBox)e.Item.FindControl("chkDTM");

                HiddenField hdnAfterOrderConfirmation = (HiddenField)e.Item.FindControl("hdnAfterOrderConfirmation");
                HiddenField hdnIsAnyAccessoryAdded = (HiddenField)e.Item.FindControl("hdnIsAnyAccessoryAdded");

                string AccessName = hdnAccessName.Value;

                if (size != "")
                {
                    txtAccessName.Text = AccessName + " (" + size + ")";
                    txtAccessName.ToolTip = hdnAccessName.Value + " (" + size + ")";
                }
                else
                {
                    txtAccessName.Text = AccessName;
                    txtAccessName.ToolTip = hdnAccessName.Value;
                }

                string AccessAgree = "";
                string ColorPrint = (DataBinder.Eval(e.Item.DataItem, "ColorPrint")).ToString();
                string ColorPrint_d = (DataBinder.Eval(e.Item.DataItem, "ColorPrint_d")).ToString();
                string IsDTM = DataBinder.Eval(e.Item.DataItem, "IsDtm").ToString();
                string IsDTM_d = DataBinder.Eval(e.Item.DataItem, "IsDtm_d").ToString();
                if ((ColorPrint_d != "") && (ColorPrint_d != ColorPrint))
                {
                    AccessAgree = ColorPrint_d;
                }
                if ((IsDTM_d != "") && (IsDTM_d != IsDTM))
                {
                    AccessAgree = AccessAgree + " (" + IsDTM_d + ")";
                }

                Label lblAccessDetail_agree = (Label)e.Item.FindControl("lblAccessDetail_agree");
                if (AccessAgree != "")
                {
                    lblAccessDetail_agree.Text = "<span class='Accessory_detail'>" + AccessAgree + "</span>";
                    lblAccessDetail_agree.CssClass = "lblhover";
                }

                if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_ACCESSORY_COLOR_PRINT))
                    txtAccessVal_.CssClass = "do-not-allow-typing";

                if (!PermissionHelper.IsWritePermittedOnColumn((int)iKandi.Common.AppModuleColumn.ORDER_FORM_ACCESSORY_ISDTM))
                    chkDTM.Enabled = false;

                if (((chkAccessManager.Enabled == false) && (chkAccessManager.Checked == true) && (txtAccessVal_.Text.ToUpper() != "TBD") && (txtAccessVal_.Text.ToUpper() != "N/A")) ||Convert.ToInt32(HdnISSrvReceived.Value)>0)
                {
                    txtAccessVal_.CssClass = "do-not-allow-typing";
                    chkDTM.Enabled = false;
                }
                else
                {
                    txtAccessVal_.Attributes.Remove("class");
                    chkDTM.Enabled = true;
                }
                if ((Convert.ToBoolean(hdnIsAnyAccessoryAdded.Value) == true) && (Convert.ToBoolean(hdnAfterOrderConfirmation.Value) == false))
                {
                    if (txtAccessVal_.Text.ToUpper() == "TBD" || txtAccessVal_.Text.ToUpper() == "N/A")
                    {
                        txtAccessVal_.Attributes.Remove("class");
                        chkDTM.Enabled = true;

                    }
                    else
                    {
                        txtAccessVal_.CssClass = "do-not-allow-typing";
                        chkDTM.Enabled = false;
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool bcheck = false;
            bool bCheckUpdate = false;
            SaveOrder(1, 0, 0, ref bcheck, ref bCheckUpdate);
            //btnSubmit.Style.Add("display", "block");
        }

        protected void btnsentProposal_Click(object sender, EventArgs e)
        {
            bool bcheck = false;
            bool bCheckUpdate = false;
            SaveOrder(1, 1, 0, ref bcheck, ref bCheckUpdate);
        }

        protected void btnAgree_Click(object sender, EventArgs e)
        {
            bool bcheck = false;
            bool bCheckUpdate = false;
            SaveOrder(1, 0, 1, ref bcheck, ref bCheckUpdate);
        }

        private string SaveUploadedFile(FileUpload FileUploadCtrl, String fileName)
        {
            if (FileUploadCtrl.HasFile)
            {
                fileName = fileName.Replace(fileName.Substring(fileName.LastIndexOf(".")), "");
                return FileHelper.SaveFile(FileUploadCtrl.PostedFile.InputStream, FileUploadCtrl.FileName, Constants.ORDER_FOLDER_PATH, false, fileName);
            }
            else
            {
                return "";
            }
        }

        private int DeliveryInstruction(string DeliveryType)
        {
            switch (DeliveryType)
            {
                case "Hanging":
                    return 1;

                case "Flat":
                    return 2;

                case "Box Hanging":
                    return 3;

            }
            return 1;
        }

        private string DeliveryInstruction(int DeliveryType)
        {
            switch (DeliveryType)
            {
                case 1:
                    return "Hanging";
                case 2:
                    return "Flat";
                case 3:
                    return "Box Hanging";
            }
            return "Hanging";
        }

        private string OrderType(int type)
        {
            switch (type)
            {
                case 1:
                    return "BIPL";
                case 3:
                    return "Kasuka";
                case 4:
                    return "Value Added Style";
                case 5:
                    return "Gratitude exports";
            }
            return "";
        }

        private string TypeOfPacking(int type)
        {
            switch (type)
            {
                case 1:
                    return "BDCM";
                case 2:
                    return "COFFIN BOX";
                case 3:
                    return "HANGER";
            }
            return "";
        }

        private void CreateOrderHistory(iKandi.Common.OrderPlace Neworder)
        {
            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            iKandi.Common.OrderPlace order = objOrderPlaceController.Get_order_by_OrderId_ForOrderPlace(OrderID, UserId);

            Neworder.TypeFlag = 1;

            if (Neworder.ParentDepartmentName != order.ParentDepartmentName)
            {
                Neworder.IsParentDept_Change = true;
                Neworder.ParentDept_OldValue = order.ParentDepartmentName;
                Neworder.ParentDept_NewValue = Neworder.ParentDepartmentName;
                Neworder.IsOrderHistoryCreated = true;
            }
            if (Neworder.DepartmentName != order.DepartmentName)
            {
                Neworder.IsDept_Change = true;
                Neworder.Dept_OldValue = order.DepartmentName;
                Neworder.Dept_NewValue = Neworder.DepartmentName;
                Neworder.ParentDept_OldId = order.ParentDepartmentID;
                Neworder.ParentDept_NewId = Neworder.ParentDepartmentID;
                Neworder.IsOrderHistoryCreated = true;
            }
            Neworder.Description = Neworder.Description == null ? string.Empty : Neworder.Description;
            if (Neworder.Description != order.Description)
            {
                Neworder.IsDescription_Change = true;
                Neworder.Description_OldValue = order.Description;
                Neworder.Description_NewValue = Neworder.Description;
                Neworder.IsOrderHistoryCreated = true;
            }
            if (OrderType(Neworder.OrderTypes) != OrderType(order.OrderTypes))
            {
                Neworder.IsOrderType_Change = true;
                Neworder.OrderType_OldValue = OrderType(order.OrderTypes);
                Neworder.OrderType_NewValue = OrderType(Neworder.OrderTypes);
                Neworder.IsOrderHistoryCreated = true;
            }
            if (Neworder.ApprovedBySalesBIPL != order.ApprovedBySalesBIPL)
            {
                Neworder.IsBiplManagerChecked = true;
                Neworder.IsOrderHistoryCreated = true;
            }
            if (Neworder.ApprovedByMerchandiserManager != order.ApprovedByMerchandiserManager)
            {
                Neworder.IsAccountManagerChecked = true;
                Neworder.IsOrderHistoryCreated = true;
            }
            if (Neworder.ApprovedByFabricManager != order.ApprovedByFabricManager)
            {
                Neworder.IsFabricManagerChecked = true;
                Neworder.IsOrderHistoryCreated = true;
            }
            if (Neworder.ApprovedByAccessoryManager != order.ApprovedByAccessoryManager)
            {
                Neworder.IsAccessoryManagerChecked = true;
                Neworder.IsOrderHistoryCreated = true;
            }

            if (order.ContractDetail != null && order.ContractDetail.Count > 0)
            {
                int i = 0;

                foreach (ContractDetails od in Neworder.ContractDetail)
                {
                    if (order.ContractDetail.Count >= i + 1)
                    {
                        if (order.ContractDetail[i].OrderDetailId == Neworder.ContractDetail[i].OrderDetailId)
                        {
                            if (order.ContractDetail[i].LineItemNumber != Neworder.ContractDetail[i].LineItemNumber)
                            {
                                Neworder.ContractDetail[i].IsLineNumber_Change = true;
                                Neworder.ContractDetail[i].LineNumber_OldValue = order.ContractDetail[i].LineItemNumber;
                                Neworder.ContractDetail[i].LineNumber_NewValue = Neworder.ContractDetail[i].LineItemNumber;
                                Neworder.ContractDetail[i].IsContractHistoryCreated = true;
                            }
                            if (order.ContractDetail[i].ContractNumber != Neworder.ContractDetail[i].ContractNumber)
                            {
                                Neworder.ContractDetail[i].IsContractNumber_Change = true;
                                Neworder.ContractDetail[i].ContractNumber_OldValue = order.ContractDetail[i].ContractNumber;
                                Neworder.ContractDetail[i].ContractNumber_NewValue = Neworder.ContractDetail[i].ContractNumber;
                                Neworder.ContractDetail[i].IsContractHistoryCreated = true;
                            }
                            if (order.ContractDetail[i].Quantity != Neworder.ContractDetail[i].Quantity)
                            {
                                Neworder.ContractDetail[i].IsQuantity_Change = true;
                                Neworder.ContractDetail[i].Quantity_OldValue = order.ContractDetail[i].Quantity.ToString();
                                Neworder.ContractDetail[i].Quantity_NewValue = Neworder.ContractDetail[i].Quantity.ToString();
                                Neworder.ContractDetail[i].IsContractHistoryCreated = true;
                            }
                            if (order.ContractDetail[i].ModeCode != Neworder.ContractDetail[i].ModeCode)
                            {
                                Neworder.ContractDetail[i].IsMode_Change = true;
                                Neworder.ContractDetail[i].Mode_OldValue = order.ContractDetail[i].ModeCode;
                                Neworder.ContractDetail[i].Mode_NewValue = Neworder.ContractDetail[i].ModeCode;
                                Neworder.ContractDetail[i].IsContractHistoryCreated = true;
                            }
                            if (order.ContractDetail[i].ExFactory != Neworder.ContractDetail[i].ExFactory)
                            {
                                Neworder.ContractDetail[i].IsExFactory_Change = true;
                                Neworder.ContractDetail[i].ExFactory_OldValue = order.ContractDetail[i].ExFactory.ToString() == "" ? "" : order.ContractDetail[i].ExFactory.ToString("dd MMM yy (ddd)");
                                Neworder.ContractDetail[i].ExFactory_NewValue = Neworder.ContractDetail[i].ExFactory.ToString() == "" ? "" : Neworder.ContractDetail[i].ExFactory.ToString("dd MMM yy (ddd)");
                                Neworder.ContractDetail[i].IsContractHistoryCreated = true;
                            }
                            if (order.ContractDetail[i].DC != Neworder.ContractDetail[i].DC)
                            {
                                Neworder.ContractDetail[i].IsDC_Change = true;
                                Neworder.ContractDetail[i].DC_OldValue = order.ContractDetail[i].DC.ToString() == "" ? "" : order.ContractDetail[i].DC.ToString("dd MMM yy (ddd)");
                                Neworder.ContractDetail[i].DC_NewValue = Neworder.ContractDetail[i].DC.ToString() == "" ? "" : Neworder.ContractDetail[i].DC.ToString("dd MMM yy (ddd)");
                                Neworder.ContractDetail[i].IsContractHistoryCreated = true;
                            }
                            if (order.ContractDetail[i].BiplPrice != Neworder.ContractDetail[i].BiplPrice)
                            {
                                Neworder.ContractDetail[i].IsBIPLPrice_Change = true;
                                Neworder.ContractDetail[i].BIPLPrice_OldValue = order.ContractDetail[i].BiplPrice.ToString();
                                Neworder.ContractDetail[i].BIPLPrice_NewValue = Neworder.ContractDetail[i].BiplPrice.ToString();
                                Neworder.ContractDetail[i].IsContractHistoryCreated = true;
                            }
                            if (order.ContractDetail[i].ikandiPrice != Neworder.ContractDetail[i].ikandiPrice)
                            {
                                Neworder.ContractDetail[i].IsIkandiPrice_Change = true;
                                Neworder.ContractDetail[i].IkandiPrice_OldValue = order.ContractDetail[i].ikandiPrice.ToString();
                                Neworder.ContractDetail[i].IkandiPrice_NewValue = Neworder.ContractDetail[i].ikandiPrice.ToString();
                                Neworder.ContractDetail[i].IsContractHistoryCreated = true;
                            }
                            if (order.ContractDetail[i].DeliveryInstruction != Neworder.ContractDetail[i].DeliveryInstruction)
                            {
                                Neworder.ContractDetail[i].IsDeliveryInstruct_Change = true;
                                Neworder.ContractDetail[i].DeliveryInstruct_OldValue = DeliveryInstruction(order.ContractDetail[i].DeliveryInstruction);
                                Neworder.ContractDetail[i].DeliveryInstruct_NewValue = DeliveryInstruction(Neworder.ContractDetail[i].DeliveryInstruction);
                                Neworder.ContractDetail[i].IsContractHistoryCreated = true;
                            }
                            if (order.ContractDetail[i].typeofpacking != Neworder.ContractDetail[i].typeofpacking)
                            {
                                Neworder.ContractDetail[i].IsTypeofpacking_Change = true;
                                Neworder.ContractDetail[i].Typeofpacking_OldValue = TypeOfPacking(order.ContractDetail[i].typeofpacking);
                                Neworder.ContractDetail[i].Typeofpacking_NewValue = TypeOfPacking(Neworder.ContractDetail[i].typeofpacking);
                                Neworder.ContractDetail[i].IsContractHistoryCreated = true;
                            }
                            if (order.ContractDetail[i].CountryCode != Neworder.ContractDetail[i].CountryCode)
                            {
                                Neworder.ContractDetail[i].IsCountryCodeChange = true;
                                Neworder.ContractDetail[i].CountryCode_OldValue = order.ContractDetail[i].CountryCode;
                                Neworder.ContractDetail[i].CountryCode_NewValue = Neworder.ContractDetail[i].CountryCode;
                                Neworder.ContractDetail[i].IsContractHistoryCreated = true;
                            }

                            int j = 0;
                            foreach (ContractDetailFabric odf in Neworder.ContractDetail[i].ContractFabric)
                            {
                                if (order.ContractDetail[i].ContractFabric.Count >= j + 1)
                                {

                                    if (order.ContractDetail[i].ContractFabric[j].FabricDetail != Neworder.ContractDetail[i].ContractFabric[j].FabricDetail)
                                    {
                                        Neworder.ContractDetail[i].ContractFabric[j].IsFabricDetail_Change = true;
                                        Neworder.ContractDetail[i].ContractFabric[j].FabricDetail_OldValue = order.ContractDetail[i].ContractFabric[j].FabricDetail;
                                        Neworder.ContractDetail[i].ContractFabric[j].FabricDetail_NewValue = Neworder.ContractDetail[i].ContractFabric[j].FabricDetail;
                                        Neworder.ContractDetail[i].ContractFabric[j].IsFabricHistoryCreated = true;
                                    }
                                    Neworder.ContractDetail[i].ContractFabric[j].FabricDetailSeq = j + 1;
                                }
                                j++;
                            }
                            if (IsAccessSubmit.Value == "0")
                            {
                                int k = 0;
                                foreach (ContractDetailAccessories oda in Neworder.ContractDetail[i].ContractAccessories)
                                {
                                    if (order.ContractDetail[i].ContractAccessories.Count >= k + 1)
                                    {
                                        if (order.ContractDetail[i].ContractAccessories[k].ColorPrint != Neworder.ContractDetail[i].ContractAccessories[k].ColorPrint)
                                        {
                                            Neworder.ContractDetail[i].ContractAccessories[k].IsColorPrint_Change = true;
                                            Neworder.ContractDetail[i].ContractAccessories[k].ColorPrint_OldValue = order.ContractDetail[i].ContractAccessories[k].ColorPrint;
                                            Neworder.ContractDetail[i].ContractAccessories[k].ColorPrint_NewValue = Neworder.ContractDetail[i].ContractAccessories[k].ColorPrint;

                                            Neworder.ContractDetail[i].ContractAccessories[k].IsAccessoryHistoryCreated = true;
                                        }
                                        if (order.ContractDetail[i].ContractAccessories[k].IsDtm != Neworder.ContractDetail[i].ContractAccessories[k].IsDtm)
                                        {
                                            Neworder.ContractDetail[i].ContractAccessories[k].IsDtm_Change = true;
                                            Neworder.ContractDetail[i].ContractAccessories[k].IsDtm_OldValue = order.ContractDetail[i].ContractAccessories[k].IsDtm == true ? "Checked" : "Unchecked";
                                            Neworder.ContractDetail[i].ContractAccessories[k].IsDtm_NewValue = Neworder.ContractDetail[i].ContractAccessories[k].IsDtm == true ? "Checked" : "Unchecked"; ;

                                            Neworder.ContractDetail[i].ContractAccessories[k].IsAccessoryHistoryCreated = true;
                                        }
                                        Neworder.ContractDetail[i].ContractAccessories[k].AccessSeq = k + 1;
                                    }
                                    k++;
                                }
                            }
                        }
                    }
                    i++;
                }
                //}
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

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            string FileUpload1 = "";
            string FileUpload2 = "";
            int rowno = hdnFileUpload.Value == null ? 0 : Convert.ToInt16(hdnFileUpload.Value);

            if (rowno == 0)
            {
                Control control = null;
                control = gvDetailSection.Controls[0].Controls[0];
                HiddenField hdnPoUpload1_Empty = (HiddenField)control.FindControl("hdnPoUpload1_Empty");
                HiddenField hdnPoUpload2_Empty = (HiddenField)control.FindControl("hdnPoUpload2_Empty");

                if (PoUpload1.HasFile)
                {
                    FileUpload1 = txtSerialNo.Text + "_ACN_" + rowno + "_" + PoUpload1.FileName;
                    SaveUploadedFile(PoUpload1, FileUpload1);
                    hdnPoUpload1_Empty.Value = FileUpload1;
                }
                if (PoUpload2.HasFile)
                {
                    FileUpload2 = txtSerialNo.Text + "_ACN_" + rowno + "_" + PoUpload2.FileName;
                    SaveUploadedFile(PoUpload2, FileUpload2);
                    hdnPoUpload2_Empty.Value = FileUpload2;
                }
            }
            else
            {
                txtStyleNumber.Text = hdnStyleNumber.Value;
                rowno = rowno - 1;
                HiddenField hdnPoUpload1 = (HiddenField)gvDetailSection.Rows[rowno].FindControl("hdnPoUpload1");
                HiddenField hdnPoUpload2 = (HiddenField)gvDetailSection.Rows[rowno].FindControl("hdnPoUpload2");

                HiddenField hdnMode = (HiddenField)gvDetailSection.Rows[rowno].FindControl("hdnMode");
                DropDownList ddlMode = (DropDownList)gvDetailSection.Rows[rowno].FindControl("ddlMode");

                int ClientId = Convert.ToInt32(ddlClient.SelectedValue);
                int DepartmentId = Convert.ToInt32(hdnDeptId.Value);
                bool IsIkandiClient = hdnIsIkandiClient.Value != null ? Convert.ToBoolean(hdnIsIkandiClient.Value) : false;
                int CostingId = hdnCostingId != null ? Convert.ToInt32(hdnCostingId.Value) : -1;
                int ModeId = Convert.ToInt32(hdnMode.Value);


                BindMode(IsIkandiClient, CostingId, ClientId, DepartmentId, ddlMode, ModeId, -1);

                if (PoUpload1.HasFile)
                {
                    FileUpload1 = txtSerialNo.Text + "_ACN_" + rowno + "_" + PoUpload1.FileName;
                    SaveUploadedFile(PoUpload1, FileUpload1);
                    hdnPoUpload1.Value = FileUpload1;
                }
                if (PoUpload2.HasFile)
                {
                    FileUpload2 = txtSerialNo.Text + "_ACN_" + rowno + "_" + PoUpload2.FileName;
                    SaveUploadedFile(PoUpload2, FileUpload2);
                    hdnPoUpload2.Value = FileUpload2;
                }
            }
            ddlParentDept.SelectedValue = hdnParentDeptId.Value.ToString();
            ddlDepartment.SelectedValue = hdnDeptId.Value.ToString();
        }

        protected void btnSplitOk_Click(object sender, EventArgs e)
        {
            SplitNo = txtSplitNo.Text == "" ? 0 : Convert.ToInt16(txtSplitNo.Text);
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SplitNo", typeof(string)));
            if (SplitNo > 0)
            {
                int i = 1;
                while (i <= SplitNo)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = i.ToString();
                    dt.Rows.Add(dr);
                    i++;
                }
                rptSplit.DataSource = dt;
                rptSplit.DataBind();
                ddlSplitType.Visible = true;
                btnSubmitSplit.Visible = true;

            }
            else
            {
                rptSplit.DataSource = null;
                rptSplit.DataBind();
                ddlSplitType.Visible = false;
                btnSubmitSplit.Visible = false;
            }
        }

        protected void rptSplit_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Label lblSplit = (Label)e.Item.FindControl("lblSplit");
            lblSplit.Text = "Split " + (e.Item.ItemIndex + 1).ToString() + ":";
        }

        protected void btnSubmitSplit_Click(object sender, EventArgs e)
        {
            try
            {
                int SplitOrderDetailId = hdnOrderDetailId_Split.Value == "" ? 0 : Convert.ToInt32(hdnOrderDetailId_Split.Value);
                int SplitType = Convert.ToInt32(ddlSplitType.SelectedValue);
                if (SplitOrderDetailId > 0)
                {
                    List<ContractDetails> orderDetailCollection = new List<ContractDetails>();
                    double BiplPrice = 0;
                    string FileUpload1 = "";
                    string FileUpload2 = "";

                    for (int i = 0; i < gvDetailSection.Rows.Count; i++)
                    {
                        HiddenField hdnOrderDetailid = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnOrderDetailid");
                        TextBox txtLineNo = (TextBox)gvDetailSection.Rows[i].FindControl("txtLineNo");
                        TextBox txtContractNo = (TextBox)gvDetailSection.Rows[i].FindControl("txtContractNo");
                        HiddenField hdnPoUpload1 = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnPoUpload1");
                        HiddenField hdnPoUpload2 = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnPoUpload2");

                        TextBox txtQty = (TextBox)gvDetailSection.Rows[i].FindControl("txtQty");
                        TextBox txtBIPLPrice = (TextBox)gvDetailSection.Rows[i].FindControl("txtBIPLPrice");
                        TextBox txtikandiPrice = (TextBox)gvDetailSection.Rows[i].FindControl("txtikandiPrice");
                        HiddenField hdnExFactoryWeek = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnExFactoryWeek");
                        HiddenField hdnDCWeek = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnDCWeek");
                        TextBox txtDelivery = (TextBox)gvDetailSection.Rows[i].FindControl("txtDelivery");
                        HiddenField hdnMode = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnMode");
                        TextBox txtExFactory = (TextBox)gvDetailSection.Rows[i].FindControl("txtExFactory");
                        TextBox txtDC = (TextBox)gvDetailSection.Rows[i].FindControl("txtDC");
                        DropDownList ddlDelivery = (DropDownList)gvDetailSection.Rows[i].FindControl("ddlDelivery");
                        HiddenField hdnSizeQty = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnSizeQty");
                        HiddenField hdnExFactoryColor = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnExFactoryColor");
                        HiddenField hdnCountry_CodeId = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnCountry_CodeId");
                        HiddenField hdnCountryCode = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnCountryCode");
                        HiddenField hdnLeadTime = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnLeadTime");

                        BiplPrice = txtBIPLPrice.Text == "" ? 0 : Convert.ToDouble(txtBIPLPrice.Text);
                        FileUpload1 = hdnPoUpload1.Value;
                        FileUpload2 = hdnPoUpload2.Value;

                        ContractDetails orderdetail = new ContractDetails();

                        orderdetail.OrderDetailId = hdnOrderDetailid.Value == "" ? -1 : Convert.ToInt32(hdnOrderDetailid.Value);
                        orderdetail.LineItemNumber = txtLineNo.Text;
                        orderdetail.ContractNumber = txtContractNo.Text;
                        orderdetail.PoUpload1 = FileUpload1;
                        orderdetail.PoUpload2 = FileUpload2;
                        orderdetail.Quantity = txtQty.Text == "" ? 0 : Convert.ToInt32(txtQty.Text);
                        orderdetail.BiplPrice = txtBIPLPrice.Text == "" ? -1 : Convert.ToDouble(txtBIPLPrice.Text);
                        orderdetail.ikandiPrice = txtikandiPrice.Text == "" ? -1 : Convert.ToDouble(txtikandiPrice.Text);
                        orderdetail.ExFactory = txtExFactory.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtExFactory.Text.Trim()).Value;
                        orderdetail.DC = txtDC.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtDC.Text).Value;
                        orderdetail.ExFactoryWeek = hdnExFactoryWeek.Value == "" ? -1 : Convert.ToInt32(hdnExFactoryWeek.Value);
                        orderdetail.DCWeek = hdnDCWeek.Value == "" ? -1 : Convert.ToInt32(hdnDCWeek.Value);
                        orderdetail.DeliveryInstruction = DeliveryInstruction(txtDelivery.Text);
                        orderdetail.ModeId = hdnMode.Value == "" ? -1 : Convert.ToInt32(hdnMode.Value);
                        orderdetail.typeofpacking = Convert.ToInt32(ddlDelivery.SelectedValue);
                        orderdetail.SizeQty = hdnSizeQty.Value == "" ? 0 : Convert.ToInt32(hdnSizeQty.Value);
                        orderdetail.ExFactoryColor = hdnExFactoryColor.Value;
                        orderdetail.CountryCodeId = hdnCountry_CodeId.Value == "" ? 0 : Convert.ToInt32(hdnCountry_CodeId.Value);
                        orderdetail.CountryCode = hdnCountryCode.Value;
                        orderdetail.LeadTime = hdnLeadTime.Value == "" ? 0 : Convert.ToInt32(hdnLeadTime.Value);

                        // Find Agreement Value
                        HiddenField hdnLineNo_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnLineNo_agree");
                        HiddenField hdnQty_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnQty_agree");
                        HiddenField hdnAgreementMode = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnAgreementMode");
                        HiddenField hdnContactNo_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnContactNo_agree");
                        HiddenField hdnBiplPrice_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnBiplPrice_agree");
                        HiddenField hdnExFactory_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnExFactory_agree");
                        HiddenField hdnExFactoryWeek_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnExFactoryWeek_agree");
                        HiddenField hdnPoUpload1_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnPoUpload1_agree");
                        HiddenField hdnikandiPrice_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnikandiPrice_agree");
                        HiddenField hdnDC_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnDC_agree");
                        HiddenField hdnDCWeek_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnDCWeek_agree");
                        HiddenField hdnPoUpload2_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnPoUpload2_agree");
                        HiddenField hdnDeliver_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnDeliver_agree");
                        HiddenField hdnddlDelivery_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnddlDelivery_agree");
                        HiddenField hdnCountryCode_agree = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnCountryCode_agree");

                        orderdetail.LineItemNumber_d = hdnLineNo_agree.Value;
                        orderdetail.ContractNumber_d = hdnContactNo_agree.Value;
                        orderdetail.PoUpload1_d = hdnPoUpload1_agree.Value;
                        orderdetail.PoUpload2_d = hdnPoUpload2_agree.Value;
                        orderdetail.Quantity_d = hdnQty_agree.Value == "" ? -1 : Convert.ToInt32(hdnQty_agree.Value);
                        orderdetail.BiplPrice_d = hdnBiplPrice_agree.Value == "" ? -1 : Convert.ToDouble(hdnBiplPrice_agree.Value);
                        orderdetail.ikandiPrice_d = hdnikandiPrice_agree.Value == "" ? -1 : Convert.ToDouble(hdnikandiPrice_agree.Value); ;
                        orderdetail.ExFactory_d = hdnExFactory_agree.Value == "" ? DateTime.MinValue : DateHelper.ParseDate(hdnExFactory_agree.Value).Value;
                        orderdetail.ExFactoryWeek_d = hdnExFactoryWeek_agree.Value == "" ? -1 : Convert.ToInt32(hdnExFactoryWeek_agree.Value);
                        orderdetail.DC_d = hdnDC_agree.Value == "" ? DateTime.MinValue : DateHelper.ParseDate(hdnDC_agree.Value).Value;
                        orderdetail.DCWeek_d = hdnDCWeek_agree.Value == "" ? -1 : Convert.ToInt32(hdnDCWeek_agree.Value);
                        orderdetail.DeliveryInstruction_d = hdnDeliver_agree.Value == "" ? -1 : Convert.ToInt32(hdnDeliver_agree.Value);
                        orderdetail.typeofpacking_d = hdnddlDelivery_agree.Value == "" ? -1 : Convert.ToInt32(hdnddlDelivery_agree.Value);
                        orderdetail.ModeCode_d = hdnAgreementMode.Value.ToString();
                        orderdetail.CountryCode_d = hdnCountryCode_agree.Value;

                        // Start Fabric Section 

                        List<ContractDetailFabric> objFabricCollection = new List<ContractDetailFabric>();

                        DataList dlstFabric = (DataList)gvDetailSection.Rows[i].FindControl("dlstFabric");

                        for (int fabNo = 0; fabNo < dlstFabric.Items.Count; fabNo++)
                        {
                            HiddenField hdnFabric = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnFabric");
                            TextBox txtFabric = (TextBox)dlstFabric.Items[fabNo].FindControl("txtFabric");
                            HiddenField hdnCountCnstr = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnCountCnstr");
                            HiddenField hdnGSM = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnGSM");
                            HiddenField hdnFabriQualityId = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnFabriQualityId");
                            HtmlInputHidden hdnFabricType = (HtmlInputHidden)dlstFabric.Items[fabNo].FindControl("hdnFabricType");
                            TextBox txtFabricType = (TextBox)dlstFabric.Items[fabNo].FindControl("txtFabricType");
                            TextBox txtFabricDetail = (TextBox)dlstFabric.Items[fabNo].FindControl("txtFabricDetail");
                            HiddenField hdnFabricDetail_d = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnFabricDetail_d");

                            ContractDetailFabric orderDetailFabric = new ContractDetailFabric();

                            orderDetailFabric.FabricId = hdnFabric.Value == "" ? -1 : Convert.ToInt32(hdnFabric.Value);
                            orderDetailFabric.FabricName = txtFabric.Text;
                            orderDetailFabric.CountConstruct = hdnCountCnstr.Value;
                            orderDetailFabric.GSM = hdnGSM.Value == "" ? -1 : Convert.ToDouble(hdnGSM.Value);
                            orderDetailFabric.fabric_qualityID = hdnFabriQualityId.Value == "" ? -1 : Convert.ToInt32(hdnFabriQualityId.Value);
                            orderDetailFabric.FabTypeId = Convert.ToInt32(hdnFabricType.Value);
                            orderDetailFabric.FabType = txtFabricType.Text;
                            orderDetailFabric.FabricDetail = txtFabricDetail.Text;
                            orderDetailFabric.FabricDetail_d = hdnFabricDetail_d.Value;
                            objFabricCollection.Add(orderDetailFabric);
                        }

                        orderdetail.ContractFabric = objFabricCollection;
                        // End Fabric Section 

                        //Start Accessories Section

                        List<ContractDetailAccessories> objAccessCollection = new List<ContractDetailAccessories>();

                        DataList dlstAccessories = (DataList)gvDetailSection.Rows[i].FindControl("dlstAccessories");

                        for (int AccNo = 0; AccNo < dlstAccessories.Items.Count; AccNo++)
                        {
                            HtmlInputHidden hdnAccessId = (HtmlInputHidden)dlstAccessories.Items[AccNo].FindControl("hdnAccessId_");
                            HiddenField hdnAccessName = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnAccessName_");
                            HiddenField hdnAccessSizeId = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnAccessSizeId_");
                            HiddenField hdnAccessSize = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnAccessSize_");
                            TextBox txtAccessVal = (TextBox)dlstAccessories.Items[AccNo].FindControl("txtAccessVal_");
                            CheckBox chkDTM = (CheckBox)dlstAccessories.Items[AccNo].FindControl("chkDTM");
                            HiddenField hdnAccessColorPrint_d = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnAccessColorPrint_d");
                            HiddenField hdnIsDTM_d = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnIsDTM_d");

                            ContractDetailAccessories orderDetailAccess = new ContractDetailAccessories();
                            orderDetailAccess.AccessoriesId = hdnAccessId.Value == "" ? -1 : Convert.ToInt32(hdnAccessId.Value);
                            orderDetailAccess.AccessoriesName = hdnAccessName.Value;
                            orderDetailAccess.SizeId = hdnAccessSizeId.Value == "" ? -1 : Convert.ToInt32(hdnAccessSizeId.Value);
                            orderDetailAccess.Size = hdnAccessSize.Value;
                            orderDetailAccess.ColorPrint = txtAccessVal.Text == "" ? DBNull.Value.ToString() : txtAccessVal.Text;
                            orderDetailAccess.IsDtm = chkDTM.Checked;
                            orderDetailAccess.ColorPrint_d = hdnAccessColorPrint_d.Value;
                            orderDetailAccess.IsDtm_d = hdnIsDTM_d.Value;
                            orderDetailAccess.SeqId = AccNo;

                            objAccessCollection.Add(orderDetailAccess);
                        }

                        orderdetail.ContractAccessories = objAccessCollection;
                        // End Accessories Section

                        orderDetailCollection.Add(orderdetail);
                    }
                    for (int itemNo = 0; itemNo < orderDetailCollection.Count; itemNo++)
                    {
                        if (SplitOrderDetailId == orderDetailCollection[itemNo].OrderDetailId)
                        {
                            int arrno = itemNo + 1;
                            hdnSplittedContractCount.Value = rptSplit.Items.Count.ToString();

                            for (int i = 0; i < rptSplit.Items.Count; i++)
                            {
                                TextBox txtSplitQty = (TextBox)rptSplit.Items[i].FindControl("txtSplitQty");
                                if (i == 0)
                                {
                                    orderDetailCollection[itemNo].Quantity = txtSplitQty.Text == "" ? 0 : Convert.ToInt32(txtSplitQty.Text);
                                    orderDetailCollection[itemNo].sortType = SplitType;
                                    orderDetailCollection[itemNo].isSplitted = 1;
                                }
                                else
                                {
                                    ContractDetails orderdetailnew = new ContractDetails();
                                    orderdetailnew.OrderDetailId = -1;
                                    orderdetailnew.OrderDetailId_Ref = SplitOrderDetailId;
                                    orderdetailnew.isSplit = 1;
                                    orderdetailnew.isSplitted = 1;
                                    orderdetailnew.LineItemNumber = orderDetailCollection[itemNo].LineItemNumber;
                                    orderdetailnew.ContractNumber = orderDetailCollection[itemNo].ContractNumber;
                                    orderdetailnew.PoUpload1 = orderDetailCollection[itemNo].PoUpload1;
                                    orderdetailnew.PoUpload2 = orderDetailCollection[itemNo].PoUpload2;
                                    orderdetailnew.Quantity = txtSplitQty.Text == "" ? 0 : Convert.ToInt32(txtSplitQty.Text);
                                    orderdetailnew.BiplPrice = orderDetailCollection[itemNo].BiplPrice;
                                    orderdetailnew.ikandiPrice = orderDetailCollection[itemNo].ikandiPrice;
                                    orderdetailnew.ExFactory = orderDetailCollection[itemNo].ExFactory;
                                    orderdetailnew.DC = orderDetailCollection[itemNo].DC;
                                    orderdetailnew.ExFactoryWeek = orderDetailCollection[itemNo].ExFactoryWeek;
                                    orderdetailnew.DCWeek = orderDetailCollection[itemNo].DCWeek;
                                    orderdetailnew.DeliveryInstruction = orderDetailCollection[itemNo].DeliveryInstruction;
                                    orderdetailnew.ModeId = orderDetailCollection[itemNo].ModeId;
                                    orderdetailnew.typeofpacking = orderDetailCollection[itemNo].typeofpacking;
                                    orderdetailnew.SizeQty = 0;
                                    orderdetailnew.ExFactoryColor = orderDetailCollection[itemNo].ExFactoryColor;
                                    orderdetailnew.CountryCodeId = orderDetailCollection[itemNo].CountryCodeId;
                                    orderdetailnew.CountryCode = orderDetailCollection[itemNo].CountryCode;
                                    orderdetailnew.LeadTime = orderDetailCollection[itemNo].LeadTime;

                                    orderdetailnew.LineItemNumber_d = orderDetailCollection[itemNo].LineItemNumber_d;
                                    orderdetailnew.ContractNumber_d = orderDetailCollection[itemNo].ContractNumber_d;
                                    orderdetailnew.PoUpload1_d = orderDetailCollection[itemNo].PoUpload1_d;
                                    orderdetailnew.PoUpload2_d = orderDetailCollection[itemNo].PoUpload2_d;
                                    orderdetailnew.Quantity_d = orderDetailCollection[itemNo].Quantity_d;
                                    orderdetailnew.BiplPrice_d = orderDetailCollection[itemNo].BiplPrice_d;
                                    orderdetailnew.ikandiPrice_d = orderDetailCollection[itemNo].ikandiPrice_d;
                                    orderdetailnew.ExFactory_d = orderDetailCollection[itemNo].ExFactory_d;
                                    orderdetailnew.ExFactoryWeek_d = orderDetailCollection[itemNo].ExFactoryWeek_d;
                                    orderdetailnew.DC_d = orderDetailCollection[itemNo].DC_d;
                                    orderdetailnew.DCWeek_d = orderDetailCollection[itemNo].DCWeek_d;
                                    orderdetailnew.DeliveryInstruction_d = orderDetailCollection[itemNo].DeliveryInstruction_d;
                                    orderdetailnew.typeofpacking_d = orderDetailCollection[itemNo].typeofpacking_d;
                                    orderdetailnew.ModeCode_d = orderDetailCollection[itemNo].ModeCode_d;
                                    orderdetailnew.CountryCode_d = orderDetailCollection[itemNo].CountryCode_d;
                                    orderdetailnew.sortType = SplitType;


                                    //Start Fabric Section

                                    List<ContractDetailFabric> objFabricCollectionNew = new List<ContractDetailFabric>();

                                    for (int fabNo = 0; fabNo < orderDetailCollection[itemNo].ContractFabric.Count; fabNo++)
                                    {
                                        ContractDetailFabric orderDetailFabric = new ContractDetailFabric();

                                        orderDetailFabric.FabricId = orderDetailCollection[itemNo].ContractFabric[fabNo].FabricId;
                                        orderDetailFabric.FabricName = orderDetailCollection[itemNo].ContractFabric[fabNo].FabricName;
                                        orderDetailFabric.CountConstruct = orderDetailCollection[itemNo].ContractFabric[fabNo].CountConstruct;
                                        orderDetailFabric.GSM = orderDetailCollection[itemNo].ContractFabric[fabNo].GSM;
                                        orderDetailFabric.fabric_qualityID = orderDetailCollection[itemNo].ContractFabric[fabNo].fabric_qualityID;
                                        orderDetailFabric.FabType = orderDetailCollection[itemNo].ContractFabric[fabNo].FabType;
                                        orderDetailFabric.FabricDetail = orderDetailCollection[itemNo].ContractFabric[fabNo].FabricDetail;
                                        orderDetailFabric.FabricDetail_d = orderDetailCollection[itemNo].ContractFabric[fabNo].FabricDetail_d;
                                        objFabricCollectionNew.Add(orderDetailFabric);
                                    }
                                    orderdetailnew.ContractFabric = objFabricCollectionNew;
                                    //End Fabric Section

                                    //Start Accessories Section

                                    List<ContractDetailAccessories> objAccessCollectionNew = new List<ContractDetailAccessories>();

                                    for (int AccNo = 0; AccNo < orderDetailCollection[itemNo].ContractAccessories.Count; AccNo++)
                                    {
                                        ContractDetailAccessories orderDetailAccess = new ContractDetailAccessories();
                                        orderDetailAccess.AccessoriesId = orderDetailCollection[itemNo].ContractAccessories[AccNo].AccessoriesId;
                                        orderDetailAccess.AccessoriesName = orderDetailCollection[itemNo].ContractAccessories[AccNo].AccessoriesName;
                                        orderDetailAccess.SizeId = orderDetailCollection[itemNo].ContractAccessories[AccNo].SizeId;
                                        orderDetailAccess.Size = orderDetailCollection[itemNo].ContractAccessories[AccNo].Size;
                                        orderDetailAccess.ColorPrint = orderDetailCollection[itemNo].ContractAccessories[AccNo].ColorPrint;
                                        orderDetailAccess.IsDtm = orderDetailCollection[itemNo].ContractAccessories[AccNo].IsDtm;
                                        orderDetailAccess.ColorPrint_d = orderDetailCollection[itemNo].ContractAccessories[AccNo].ColorPrint_d;
                                        orderDetailAccess.IsDtm_d = orderDetailCollection[itemNo].ContractAccessories[AccNo].IsDtm_d;
                                        orderDetailAccess.SeqId = orderDetailCollection[itemNo].ContractAccessories[AccNo].SeqId;

                                        objAccessCollectionNew.Add(orderDetailAccess);
                                    }

                                    orderdetailnew.ContractAccessories = objAccessCollectionNew;
                                    orderDetailCollection.Insert(arrno, orderdetailnew);
                                    arrno++;
                                }
                            }
                            lblLineNo.Text = "";
                            lblContractNo.Text = "";
                            txtTotalSplitQty.Text = "";
                            txtSplitNo.Text = "";
                            rptSplit.DataSource = null;
                            rptSplit.DataBind();
                            rptSplit.Visible = false;
                            ddlSplitType.Visible = false;
                            btnSubmitSplit.Visible = false;
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "SpiltContactClose();", true);
                            break;
                        }
                    }

                    PopulateOrderData(orderDetailCollection);
                    //UpdatePanel1.Update();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        private void SaveOrder(int type, Int16 SendProposal, Int16 AcceptProposal, ref bool bCheckOrderSAM, ref bool bCheckUpdate)
        {
            iKandi.Common.OrderPlace order = new iKandi.Common.OrderPlace();
            order.OrderID = this.OrderID;
            order.Style = new iKandi.Common.Style();

            order.StyleID = Convert.ToInt32(hdnStyleID.Value);
            order.OldStyleId = Convert.ToInt32(hdnStyleID.Value);
            order.Style.StyleNumber = txtStyleNumber.Text;

            order.ClientID = hdnClientId.Value == null ? -1 : Convert.ToInt32(hdnClientId.Value);
            order.ParentDepartmentID = hdnParentDeptId == null ? -1 : Convert.ToInt32(hdnParentDeptId.Value);
            order.DepartmentID = hdnDeptId == null ? -1 : Convert.ToInt32(hdnDeptId.Value);
            order.ParentDepartmentName = hdnParentDeptName.Value == "-1" ? "" : hdnParentDeptName.Value.ToString();
            order.DepartmentName = hdnDeptName.Value == "-1" ? "" : hdnDeptName.Value.ToString();
            order.DeliveryType = Convert.ToInt32(ddlDeliverType.SelectedValue);

            if (!string.IsNullOrEmpty(lblOrderDate.Text))
                order.OrderDate = DateHelper.ParseDate(lblOrderDate.Text).Value;

            if (!string.IsNullOrEmpty(txtSerialNo.Text))
                order.SerialNumber = txtSerialNo.Text;

            if (!string.IsNullOrEmpty(txtDescription.Text))
                order.Description = txtDescription.Text;

            order.OrderTypes = Convert.ToInt32(ddlordrType.SelectedValue);

            order.SplittedContractCount = Convert.ToInt32(hdnSplittedContractCount.Value);

            //------------------------------------------------------------- Contract Section --------------------------------------------
            // Empty Data
            order.ContractDetail = new List<ContractDetails>();
            if (hdnIsEmptyRow.Value == "1")
            {
                Control control = null;
                control = gvDetailSection.Controls[0].Controls[0];
                ContractDetails orderdetail = new ContractDetails();

                if ((TextBox)control.FindControl("txtQty_Empty") != null)
                {
                    TextBox txtLineNo_Empty = (TextBox)control.FindControl("txtLineNo_Empty");
                    TextBox txtContractNo_Empty = (TextBox)control.FindControl("txtContractNo_Empty");
                    HiddenField hdnPoUpload1_Empty = (HiddenField)control.FindControl("hdnPoUpload1_Empty");
                    HiddenField hdnPoUpload2_Empty = (HiddenField)control.FindControl("hdnPoUpload2_Empty");

                    TextBox txtQty_Empty = (TextBox)control.FindControl("txtQty_Empty");
                    TextBox txtBIPLPrice_Empty = (TextBox)control.FindControl("txtBIPLPrice_Empty");
                    TextBox txtikandiPrice_Empty = (TextBox)control.FindControl("txtikandiPrice_Empty");
                    HiddenField hdnExFactoryWeek_Empty = (HiddenField)control.FindControl("hdnExFactoryWeek_Empty");
                    HiddenField hdnDCWeek_Empty = (HiddenField)control.FindControl("hdnDCWeek_Empty");

                    TextBox txtDelivery_Empty = (TextBox)control.FindControl("txtDelivery_Empty");
                    HiddenField hdnMode_Empty = (HiddenField)control.FindControl("hdnMode_Empty");
                    TextBox txtExFactory_Empty = (TextBox)control.FindControl("txtExFactory_Empty");
                    TextBox txtDC_Empty = (TextBox)control.FindControl("txtDC_Empty");
                    DropDownList ddlDelivery_Empty = (DropDownList)control.FindControl("ddlDelivery_Empty");
                    HiddenField hdnCountryCodeId_Empty = (HiddenField)control.FindControl("hdnCountryCodeId_Empty");

                    orderdetail.OrderDetailId = -1;
                    orderdetail.LineItemNumber = txtLineNo_Empty.Text.Trim();
                    orderdetail.ContractNumber = txtContractNo_Empty.Text.Trim();
                    orderdetail.Quantity = txtQty_Empty.Text == "" ? 0 : Convert.ToInt32(txtQty_Empty.Text);
                    orderdetail.BiplPrice = txtBIPLPrice_Empty.Text == "" ? 0 : Convert.ToDouble(txtBIPLPrice_Empty.Text);
                    if (txtikandiPrice_Empty.Text != "N/A")
                        orderdetail.ikandiPrice = txtikandiPrice_Empty.Text == "" ? 0 : Convert.ToDouble(txtikandiPrice_Empty.Text);
                    else
                        orderdetail.ikandiPrice = 0;

                    orderdetail.ExFactory = txtExFactory_Empty.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtExFactory_Empty.Text.Trim()).Value;
                    orderdetail.DC = txtDC_Empty.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtDC_Empty.Text.Trim()).Value;
                    orderdetail.ExFactoryWeek = hdnExFactoryWeek_Empty.Value == "" ? -1 : Convert.ToInt32(hdnExFactoryWeek_Empty.Value);
                    orderdetail.DCWeek = hdnDCWeek_Empty.Value == "" ? -1 : Convert.ToInt32(hdnDCWeek_Empty.Value);
                    orderdetail.DeliveryInstruction = DeliveryInstruction(txtDelivery_Empty.Text.Trim());
                    orderdetail.ModeId = hdnMode_Empty.Value == "" ? -1 : Convert.ToInt32(hdnMode_Empty.Value);
                    orderdetail.CountryCodeId = hdnCountryCodeId_Empty.Value == "" ? -1 : Convert.ToInt32(hdnCountryCodeId_Empty.Value);
                    orderdetail.typeofpacking = Convert.ToInt32(ddlDelivery_Empty.SelectedValue);

                    orderdetail.PoUpload1 = hdnPoUpload1_Empty.Value.ToString();
                    orderdetail.PoUpload2 = hdnPoUpload2_Empty.Value.ToString();

                    orderdetail.SendProposal = SendProposal;
                    orderdetail.AcceptProposal = AcceptProposal;
                    order.SplittedOrderDetailId = -1;
                    //orderdetail.SplittedContractCount = 0;

                    List<ContractDetailFabric> objFabricCollection = new List<ContractDetailFabric>();

                    HiddenField hdnFabricCount = (HiddenField)control.FindControl("hdnFabricCount");
                    int FabricCount = hdnFabricCount.Value == "" ? 0 : Convert.ToInt32(hdnFabricCount.Value);
                    if (FabricCount > 0)
                    {
                        for (int fabNo = 1; fabNo <= FabricCount; fabNo++)
                        {
                            HiddenField hdnFabric = (HiddenField)control.FindControl("hdnFabric" + fabNo);
                            TextBox txtFabric = (TextBox)control.FindControl("txtFabric" + fabNo);
                            HiddenField hdnCountCnstr = (HiddenField)control.FindControl("hdnCountCnstr" + fabNo);
                            HiddenField hdnGSM = (HiddenField)control.FindControl("hdnGSM" + fabNo);
                            HiddenField hdnFabriQualityId = (HiddenField)control.FindControl("hdnFabriQualityId" + fabNo);
                            HiddenField hdnFabricType = (HiddenField)control.FindControl("hdnFabricType" + fabNo);
                            TextBox txtFabricDetail = (TextBox)control.FindControl("txtFabricDetail" + fabNo);

                            ContractDetailFabric orderdetailfabric = new ContractDetailFabric();
                            orderdetailfabric.FabricId = hdnFabric.Value == "" ? -1 : Convert.ToInt32(hdnFabric.Value);
                            orderdetailfabric.FabricName = txtFabric.Text;
                            orderdetailfabric.CountConstruct = hdnCountCnstr.Value;
                            orderdetailfabric.GSM = hdnGSM.Value == "" ? -1 : Convert.ToDouble(hdnGSM.Value);
                            orderdetailfabric.fabric_qualityID = hdnFabriQualityId.Value == "" ? -1 : Convert.ToInt32(hdnFabriQualityId.Value);
                            orderdetailfabric.FabTypeId = Convert.ToInt32(hdnFabricType.Value);
                            orderdetailfabric.FabricDetail = txtFabricDetail.Text;
                            orderdetailfabric.SeqId = fabNo;
                            orderdetailfabric.SendProposal = SendProposal;
                            orderdetailfabric.AcceptProposal = AcceptProposal;

                            objFabricCollection.Add(orderdetailfabric);
                        }
                    }

                    orderdetail.ContractFabric = objFabricCollection;

                    //Start Accessories Section

                    List<ContractDetailAccessories> objAccessCollection = new List<ContractDetailAccessories>();
                    HiddenField hdnAccessCount = (HiddenField)control.FindControl("hdnAccessCount");
                    int AccessCount = hdnAccessCount.Value == "" ? 0 : Convert.ToInt32(hdnAccessCount.Value);
                    if (AccessCount > 0)
                    {
                        for (int AccNo = 1; AccNo <= AccessCount; AccNo++)
                        {
                            HtmlInputHidden hdnAccessId = (HtmlInputHidden)control.FindControl("hdnAccessId_" + AccNo);
                            HiddenField hdnAccessName = (HiddenField)control.FindControl("hdnAccessName_" + AccNo);
                            TextBox txtAccessName = (TextBox)control.FindControl("txtAccessVal_" + AccNo);
                            HiddenField hdnAccessSizeId = (HiddenField)control.FindControl("hdnAccessSizeId_" + AccNo);
                            HiddenField hdnAccessSize = (HiddenField)control.FindControl("hdnAccessSize_" + AccNo);
                            TextBox txtAccessVal = (TextBox)control.FindControl("txtAccessVal_" + AccNo);
                            CheckBox chkDTM = (CheckBox)control.FindControl("chkDTM" + AccNo);
                            if (txtAccessName.Text != "")
                            {
                                ContractDetailAccessories orderDetailAccess = new ContractDetailAccessories();
                                orderDetailAccess.AccessoriesId = hdnAccessId.Value == "" ? -1 : Convert.ToInt32(hdnAccessId.Value);
                                orderDetailAccess.AccessoriesName = hdnAccessName.Value;
                                orderDetailAccess.SizeId = hdnAccessSizeId.Value == "" ? -1 : Convert.ToInt32(hdnAccessSizeId.Value);
                                orderDetailAccess.Size = hdnAccessSize.Value;
                                orderDetailAccess.ColorPrint = txtAccessVal.Text == "" ? DBNull.Value.ToString() : txtAccessVal.Text;
                                orderDetailAccess.IsDtm = chkDTM.Checked;
                                orderDetailAccess.SeqId = AccNo;
                                orderDetailAccess.SendProposal = SendProposal;
                                orderDetailAccess.AcceptProposal = AcceptProposal;

                                objAccessCollection.Add(orderDetailAccess);
                            }
                        }
                    }
                    orderdetail.ContractAccessories = objAccessCollection;
                    // End Accessories Section
                    order.ContractDetail.Add(orderdetail);
                }
            }
            else
            {
                for (int i = 0; i < gvDetailSection.Rows.Count; i++)
                {
                    ContractDetails orderdetail = new ContractDetails();
                    HiddenField hdnOrderDetailid = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnOrderDetailid");
                    HiddenField hdnOrderDetailid_Ref = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnOrderDetailid_Ref");
                    HiddenField hdnIsSplit = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnIsSplit");
                    HiddenField hdnIsSplited = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnIsSplited");
                    TextBox txtLineNo = (TextBox)gvDetailSection.Rows[i].FindControl("txtLineNo");
                    TextBox txtContractNo = (TextBox)gvDetailSection.Rows[i].FindControl("txtContractNo");
                    HiddenField hdnPoUpload1 = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnPoUpload1");
                    HiddenField hdnPoUpload2 = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnPoUpload2");

                    TextBox txtQty = (TextBox)gvDetailSection.Rows[i].FindControl("txtQty");
                    TextBox txtBIPLPrice = (TextBox)gvDetailSection.Rows[i].FindControl("txtBIPLPrice");
                    TextBox txtikandiPrice = (TextBox)gvDetailSection.Rows[i].FindControl("txtikandiPrice");
                    HiddenField hdnExFactoryWeek = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnExFactoryWeek");
                    HiddenField hdnDCWeek = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnDCWeek");

                    DropDownList ddlMode = (DropDownList)gvDetailSection.Rows[i].FindControl("ddlMode");
                    HiddenField hdnMode = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnMode");
                    TextBox txtExFactory = (TextBox)gvDetailSection.Rows[i].FindControl("txtExFactory");
                    TextBox txtDC = (TextBox)gvDetailSection.Rows[i].FindControl("txtDC");
                    DropDownList ddlDelivery = (DropDownList)gvDetailSection.Rows[i].FindControl("ddlDelivery");
                    TextBox txtDelivery = (TextBox)gvDetailSection.Rows[i].FindControl("txtDelivery");
                    HiddenField hdnCountry_CodeId = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnCountry_CodeId");
                    HiddenField hdnCountryCode = (HiddenField)gvDetailSection.Rows[i].FindControl("hdnCountryCode");

                    orderdetail.OrderDetailId = hdnOrderDetailid.Value == "" ? -1 : Convert.ToInt32(hdnOrderDetailid.Value);
                    orderdetail.OrderDetailId_Ref = hdnOrderDetailid_Ref.Value == "" ? -1 : Convert.ToInt32(hdnOrderDetailid_Ref.Value);
                    orderdetail.isSplit = hdnIsSplit.Value == "" ? 0 : Convert.ToInt32(hdnIsSplit.Value);
                    orderdetail.isSplitted = hdnIsSplited.Value == "" ? 0 : Convert.ToInt32(hdnIsSplited.Value);

                    orderdetail.LineItemNumber = txtLineNo.Text.Trim();
                    orderdetail.ContractNumber = txtContractNo.Text.Trim();
                    orderdetail.Quantity = txtQty.Text == "" ? 0 : Convert.ToInt32(txtQty.Text);
                    orderdetail.BiplPrice = txtBIPLPrice.Text == "" ? 0 : Convert.ToDouble(txtBIPLPrice.Text);
                    if (txtikandiPrice.Text != "N/A")
                        orderdetail.ikandiPrice = txtikandiPrice.Text == "" ? 0 : Convert.ToDouble(txtikandiPrice.Text);
                    else
                        orderdetail.ikandiPrice = 0;
                    orderdetail.ExFactory = txtExFactory.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtExFactory.Text.Trim()).Value;
                    orderdetail.DC = txtDC.Text == "" ? DateTime.MinValue : DateHelper.ParseDate(txtDC.Text.Trim()).Value;
                    orderdetail.ExFactoryWeek = hdnExFactoryWeek.Value == "" ? -1 : Convert.ToInt32(hdnExFactoryWeek.Value);
                    orderdetail.DCWeek = hdnDCWeek.Value == "" ? -1 : Convert.ToInt32(hdnDCWeek.Value);

                    orderdetail.DeliveryInstruction = DeliveryInstruction(txtDelivery.Text.Trim());
                    orderdetail.ModeId = hdnMode.Value == "" ? -1 : Convert.ToInt32(hdnMode.Value);
                    orderdetail.ModeCode = ddlMode.SelectedItem.Text;
                    orderdetail.typeofpacking = Convert.ToInt32(ddlDelivery.SelectedValue);

                    orderdetail.PoUpload1 = hdnPoUpload1.Value.ToString();
                    orderdetail.PoUpload2 = hdnPoUpload2.Value.ToString();
                    orderdetail.CountryCodeId = hdnCountry_CodeId.Value == "" ? 0 : Convert.ToInt32(hdnCountry_CodeId.Value);
                    orderdetail.CountryCode = hdnCountryCode.Value;

                    orderdetail.SendProposal = SendProposal;
                    orderdetail.AcceptProposal = AcceptProposal;

                    if (order.SplittedOrderDetailId <= 0)
                    {
                        order.SplittedOrderDetailId = hdnOrderDetailid_Ref.Value == "" ? -1 : Convert.ToInt32(hdnOrderDetailid_Ref.Value);
                    }

                    List<ContractDetailFabric> objFabricCollection = new List<ContractDetailFabric>();

                    DataList dlstFabric = (DataList)gvDetailSection.Rows[i].FindControl("dlstFabric");

                    for (int fabNo = 0; fabNo < dlstFabric.Items.Count; fabNo++)
                    {
                        HiddenField hdnFabric = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnFabric");
                        TextBox txtFabric = (TextBox)dlstFabric.Items[fabNo].FindControl("txtFabric");
                        HiddenField hdnCountCnstr = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnCountCnstr");
                        HiddenField hdnGSM = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnGSM");
                        HiddenField hdnFabriQualityId = (HiddenField)dlstFabric.Items[fabNo].FindControl("hdnFabriQualityId");
                        HtmlInputHidden hdnFabricType = (HtmlInputHidden)dlstFabric.Items[fabNo].FindControl("hdnFabricType");
                        TextBox txtFabricDetail = (TextBox)dlstFabric.Items[fabNo].FindControl("txtFabricDetail");

                        ContractDetailFabric orderdetailfabric = new ContractDetailFabric();
                        orderdetailfabric.FabricId = hdnFabric.Value == "" ? -1 : Convert.ToInt32(hdnFabric.Value);
                        orderdetailfabric.FabricName = txtFabric.Text;
                        orderdetailfabric.CountConstruct = hdnCountCnstr.Value;
                        orderdetailfabric.GSM = hdnGSM.Value == "" ? -1 : Convert.ToDouble(hdnGSM.Value);
                        orderdetailfabric.fabric_qualityID = hdnFabriQualityId.Value == "" ? -1 : Convert.ToInt32(hdnFabriQualityId.Value);
                        orderdetailfabric.FabTypeId = Convert.ToInt32(hdnFabricType.Value);
                        orderdetailfabric.FabricDetail = txtFabricDetail.Text;
                        orderdetailfabric.SendProposal = SendProposal;
                        orderdetailfabric.AcceptProposal = AcceptProposal;
                        orderdetailfabric.SeqId = fabNo + 1;

                        objFabricCollection.Add(orderdetailfabric);
                    }

                    orderdetail.ContractFabric = objFabricCollection;
                    //Start Accessories Section

                    if (IsAccessSubmit.Value == "0")
                    {
                        List<ContractDetailAccessories> objAccessCollection = new List<ContractDetailAccessories>();

                        DataList dlstAccessories = (DataList)gvDetailSection.Rows[i].FindControl("dlstAccessories");

                        for (int AccNo = 0; AccNo < dlstAccessories.Items.Count; AccNo++)
                        {
                            HtmlInputHidden hdnAccessId = (HtmlInputHidden)dlstAccessories.Items[AccNo].FindControl("hdnAccessId_");
                            HiddenField hdnAccessName = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnAccessName_");
                            HiddenField hdnAccessSizeId = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnAccessSizeId_");
                            HiddenField hdnAccessSize = (HiddenField)dlstAccessories.Items[AccNo].FindControl("hdnAccessSize_");
                            TextBox txtAccessVal = (TextBox)dlstAccessories.Items[AccNo].FindControl("txtAccessVal_");
                            CheckBox chkDTM = (CheckBox)dlstAccessories.Items[AccNo].FindControl("chkDTM");

                            ContractDetailAccessories orderDetailAccess = new ContractDetailAccessories();
                            orderDetailAccess.AccessoriesId = hdnAccessId.Value == "" ? -1 : Convert.ToInt32(hdnAccessId.Value);
                            orderDetailAccess.AccessoriesName = hdnAccessName.Value;
                            orderDetailAccess.SizeId = hdnAccessSizeId.Value == "" ? -1 : Convert.ToInt32(hdnAccessSizeId.Value);
                            orderDetailAccess.Size = hdnAccessSize.Value;
                            orderDetailAccess.ColorPrint = txtAccessVal.Text == "" ? DBNull.Value.ToString() : txtAccessVal.Text;
                            orderDetailAccess.IsDtm = chkDTM.Checked;
                            orderDetailAccess.SeqId = AccNo;
                            orderDetailAccess.SendProposal = SendProposal;
                            orderDetailAccess.AcceptProposal = AcceptProposal;

                            objAccessCollection.Add(orderDetailAccess);
                        }
                        orderdetail.ContractAccessories = objAccessCollection;
                    }
                    order.ContractDetail.Add(orderdetail);
                }
            }

            // IF ORDER CONFERMEED AND USER IS IKANDI THEN PROPOSAL WILL SEND           
            order.SendProposal = SendProposal;
            order.AcceptProposal = AcceptProposal;
            order.History = "";

            if (order.IsIkandiUser)
                order.ApprovedBySalesIkandi = chkBiplManager.Checked == true ? 1 : 0;
            else
                order.ApprovedBySalesBIPL = chkBiplManager.Checked == true ? 1 : 0;

            order.ApprovedByMerchandiserManager = chkAcountManager.Checked == true ? 1 : 0;
            order.ApprovedByFabricManager = chkFabricManager.Checked == true ? 1 : 0;
            order.ApprovedByAccessoryManager = chkAccessManager.Checked == true ? 1 : 0;

            if ((chkAcountManager.Checked == true) && (chkAcountManager.Enabled))
            {
                order.ApprovedByMerchandiserManagerOn = DateTime.Now;
            }

            if ((chkBiplManager.Checked == true) && (chkBiplManager.Enabled))
            {
                order.ApprovedBySalesBIPLOn = DateTime.Now;
            }

            if ((chkFabricManager.Checked == true) && (chkFabricManager.Enabled))
            {
                order.ApprovedByFabricManagerOn = DateTime.Now;
            }

            if ((chkAccessManager.Checked == true) && (chkAccessManager.Enabled))
            {
                order.ApprovedByAccessoryManagerOn = DateTime.Now;
            }

            int NewOrderID = 0;
            if (hdnOldStyleId.Value != "" && hdnStyleID.Value != "")
            {
                if (hdnOldStyleId.Value != hdnStyleID.Value)
                {
                    order.OldStyleId = Convert.ToInt32(hdnOldStyleId.Value);
                }
            }
            if (hdnRepeatWithChanges.Value == "1")
            {
                int ParentStyleID = -1;
                string ParentStyleNumber = "";
                if (hdnParentStyleID.Value != "")
                {
                    ParentStyleID = Convert.ToInt32(hdnParentStyleID.Value);
                }
                if (hdnParentStyleNumber.Value != "")
                {
                    ParentStyleNumber = hdnParentStyleNumber.Value;
                    order.BaseStyle = ParentStyleNumber;
                }

                StyleController StyleController = new StyleController();
                int ClientID = Convert.ToInt32(ddlClient.SelectedValue);
                int DeptID = Convert.ToInt32(ddlDepartment.SelectedValue);

                order.StyleID = StyleController.CloneStyleNumberByOrder(ParentStyleID, ParentStyleNumber, order.Style.StyleNumber, ClientID, DeptID);
            }

            if (btnAgree.Visible == false)
            {
                CreateOrderHistory(order);
            }

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            int iAfterUpdation = 0;

            bool sucess = objOrderPlaceController.AddOrder(order, UserId, ref bCheckOrderSAM, ref NewOrderID, ref iAfterUpdation, Convert.ToInt32(hdnRepeatWithChanges.Value));
            if (sucess)
            {
                if ((ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Sales_Manager) || (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_AccountManager))
                {
                    bool IsIkandiClient = hdnIsIkandiClient.Value != null ? Convert.ToBoolean(hdnIsIkandiClient.Value) : false;

                    if ((chkBiplManager.Checked == true) && (chkAcountManager.Checked == true) && (IsIkandiClient == true))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "OpenForikandiBox();", true);
                    }
                }
                btnSubmit.Style.Add("display", "");
                pnlForm.Visible = false;
                pnlMessage.Visible = true;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "SpinnHide();", true);
            }
            else
            {
                btnSubmit.Style.Add("display", "");
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('Order could not be saved due to some error occured');", true);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "SpinnHide();", true);
                return;
            }

        }

    }
}