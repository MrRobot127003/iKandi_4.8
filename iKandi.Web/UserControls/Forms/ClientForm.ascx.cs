using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;
using System.Text;


namespace iKandi.Web
{
    public partial class ClientForm : BaseUserControl
    {
        #region Properties

        public int ClientID
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["clientid"]))
                {
                    return Convert.ToInt32(Request.QueryString["clientid"]);
                }

                return -1;
            }
        }

        #endregion

        #region Event Handlers
        public int flag = 0;
        public string ColorCodr
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {


            ColorCodr = txtColorPickerValue.Text;
            tdColorPicker.Attributes.Add("style", "background-color:" + ColorCodr + "");
            if (Convert.ToString(Request.QueryString["btn"]) == "1")
            {
                HtmlInputButton htmbtn = (HtmlInputButton)this.FindControl("btnPrint");
                htmbtn.Attributes.Add("style", "display:none");
                btnSubmit.Visible = false;
            }

            if (!IsPostBack)
            {
                BindControls();
                if (ClientID != -1)
                {
                    //flag = this.BuyingHouseController.GetBuyingHouseStyleData(ClientID); //comnted by abhishek 9/2/2016
                    //if (flag != 0)
                    //{
                    //    lblBuyingHouse.Visible = true;
                    //    ddlBuyingHouse.Visible = false;
                    //}
                    PopulateClientData();
                    AdminController objadmin = new AdminController();
                    DataSet ds = objadmin.GetParentDepartment(ClientID, 1);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = this.ClientControllerInstance.GetClientByIdDataTable(ClientID);
                        if (dt.Rows.Count > 0)
                        {
                            Repeater1.DataSource = dt;
                            Repeater1.DataBind();
                            ViewState["dtView"] = maintainViewState();
                        }
                        else BindDefaultRows();
                    }
                    else
                    {
                        BindDefaultRows();
                        Repeater1.Visible = false;
                    }
                    // PopulateClientData();
                }
                else
                {
                    //BindDefaultRows();
                }
            }
        }

        private void BindDefaultRows()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DepartmentName");
            dt.Columns.Add("ID");
            dt.Columns.Add("ParentID");
            dt.Columns.Add("Email");
            dt.Columns.Add("Password");
            dt.Columns.Add("Mon");
            dt.Columns.Add("Tue");
            dt.Columns.Add("Wed");
            dt.Columns.Add("Thu");
            dt.Columns.Add("Fri");

            //dt.Columns.Add("Sales");
            //dt.Columns.Add("Tech");
            //dt.Columns.Add("Design");
            //dt.Columns.Add("Shipping");
            //dt.Columns.Add("Account");
            //dt.Columns.Add("Delivery");
            //dt.Columns.Add("Sample");
            //dt.Columns.Add("Client");
            //dt.Columns.Add("Fit");

            dt.Columns.Add("Remove");

            DataRow dr = dt.NewRow();
            dr["DepartmentName"] = "";
            dr["ID"] = "0";
            dr["ParentID"] = "0";
            dr["Email"] = "";
            dr["Password"] = "";
            dr["Mon"] = "0";
            dr["Tue"] = "0";
            dr["Wed"] = "0";
            dr["Thu"] = "0";
            dr["Fri"] = "0";
            dr["Remove"] = "0";
            dt.Rows.Add(dr);
            dt.AcceptChanges();
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            ViewState["dtView"] = dt;

            DataTable dtExt = new DataTable();
            dtExt.Columns.Add("Name");
            dtExt.Columns.Add("ContactID");
            dtExt.Columns.Add("Email");
            dtExt.Columns.Add("Phone");
            dtExt.Columns.Add("Remove");

            DataRow drExt = dtExt.NewRow();
            drExt["Name"] = "";
            drExt["ContactID"] = "0";
            drExt["Phone"] = "";
            drExt["Email"] = "";
            drExt["Remove"] = "0";
            dtExt.Rows.Add(drExt);
            dtExt.AcceptChanges();
            ViewState["dtViewExt"] = dtExt;
            Repeater2.DataSource = dtExt;
            Repeater2.DataBind();
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            CreateClientDataTable();
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", "<script language='javascript'>Reload();</script>");
            //CreateClient();
        }

        //protected void ddlBuyingHouse_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string ddlVal = ddlBuyingHouse.SelectedValue;

        //    BindControls();
        //    if (ClientID != -1)
        //    {
        //        PopulateClientData();
        //    }
        //    if (Convert.ToInt32(ddlVal) > 1)
        //    {
        //        lblFitMer1.Text = "FIT Merchant/ Technologist*:";
        //        lblFitMer2.Text = "FIT Merchant/ Technologist*:";
        //        lblFitMer3.Text = "FIT Merchant/ Technologist*:";
        //        lblSamplingMer1.Text = "Sampling Merchant/ Designer*:";
        //        lblSamplingMer2.Text = "Sampling Merchant/ Designer*:";
        //        lblSamplingMer3.Text = "Sampling Merchant/ Designer*:";
        //    }
        //    else
        //    {
        //        lblFitMer1.Text = "FIT Merchant*:";
        //        lblFitMer2.Text = "FIT Merchant*:";
        //        lblFitMer3.Text = "FIT Merchant*:";
        //        lblSamplingMer1.Text = "Sampling Merchant*:";
        //        lblSamplingMer2.Text = "Sampling Merchant*:";
        //        lblSamplingMer3.Text = "Sampling Merchant*:";
        //    }
        //    ddlBuyingHouse.SelectedValue = ddlVal;
        //    lblBuyingHouse.Text = ddlBuyingHouse.SelectedItem.Text;
        //}

        protected void imgRemove_Click(object sender, ImageClickEventArgs e)
        {
            ColorCodr = txtColorPickerValue.Text;
            DataTable dtUserList = new DataTable();
            dtUserList.Columns.Add("TDeptID");
            dtUserList.Columns.Add("TDeginationID");
            dtUserList.Columns.Add("TUserList");
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                Panel Panel11 = (Panel)Repeater1.Items[i].FindControl("Panel1");
                Repeater rptListBox = (Repeater)Panel11.FindControl("rptListBox");
                foreach (RepeaterItem rptitem in rptListBox.Items)
                {
                    DataRow dr = dtUserList.NewRow();
                    dr["TDeptID"] = i;
                    dr["TDeginationID"] = ((HiddenField)rptitem.FindControl("hdnfldDeginationID")).Value;
                    dr["TUserList"] = ListBoxGetSelected((ListBox)rptitem.FindControl("LBdesignation"));
                    dtUserList.Rows.Add(dr);
                    dtUserList.AcceptChanges();
                }
            }


            ImageButton imgRemove = (ImageButton)sender;
            HiddenField hdnDelete = (HiddenField)imgRemove.Parent.FindControl("hdnDelete");
            Panel Panel1 = (Panel)imgRemove.Parent.FindControl("Panel1");
            hdnDelete.Value = "1";
            Panel1.Visible = false;

            DataTable dt = maintainViewState();
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToString(dr["Remove"]) == "1" && Convert.ToString(dr["ID"]) == "0")
                {
                    dr.Delete();
                }
            }
            dt.AcceptChanges();
            ViewState["dtView"] = dt;
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            txtClient.CssClass = "input_in date-picker date_style";


            // string DivisionID = ddlDivisionName.SelectedValue;
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                Panel Panel12 = (Panel)Repeater1.Items[i].FindControl("Panel1");
                Repeater rptListBox = (Repeater)Panel12.FindControl("rptListBox");
                HiddenField hdnDeptID = (HiddenField)Panel12.FindControl("hdnDeptID");
                DataTable dt2 = this.ClientControllerInstance.GetDesignationByDivision(ClientID.ToString());
                rptListBox.DataSource = dt2;
                rptListBox.DataBind();

                foreach (RepeaterItem rptitem in rptListBox.Items)
                {
                    dtUserList.DefaultView.RowFilter = "TDeptID=" + i;
                    DataView Tdv = dtUserList.DefaultView;
                    DataTable userlist = Tdv.ToTable();

                    string Lbvalues = null;
                    ListBox LBdesignation = (ListBox)rptitem.FindControl("LBdesignation");
                    HiddenField hdnfldDeginationID = (HiddenField)rptitem.FindControl("hdnfldDeginationID");

                    userlist.DefaultView.RowFilter = "TDeginationID=" + hdnfldDeginationID.Value;
                    DataView dv = userlist.DefaultView;
                    if (dv.Count > 0)
                        Lbvalues = dv.ToTable().Rows[0]["TUserList"].ToString();
                    BindListBoxList(LBdesignation, Convert.ToInt32(hdnfldDeginationID.Value), Lbvalues);
                }
            }

        }

        protected void imgAddDept_Click(object sender, ImageClickEventArgs e)
        {

            ColorCodr = txtColorPickerValue.Text;
            //tdColorPicker.BgColor = System.Drawing.ColorTranslator.FromHtml(ColorCodr).ToString();
            tdColorPicker.Attributes.Add("style", "background-color:" + ColorCodr + "");
            DataTable dtUserList = new DataTable();
            dtUserList.Columns.Add("TDeptID");
            dtUserList.Columns.Add("TDeginationID");
            dtUserList.Columns.Add("TUserList");
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                Panel Panel1 = (Panel)Repeater1.Items[i].FindControl("Panel1");
                Repeater rptListBox = (Repeater)Panel1.FindControl("rptListBox");
                foreach (RepeaterItem rptitem in rptListBox.Items)
                {
                    DataRow dr = dtUserList.NewRow();
                    dr["TDeptID"] = i;
                    dr["TDeginationID"] = ((HiddenField)rptitem.FindControl("hdnfldDeginationID")).Value;
                    dr["TUserList"] = ListBoxGetSelected((ListBox)rptitem.FindControl("LBdesignation"));
                    dtUserList.Rows.Add(dr);
                    dtUserList.AcceptChanges();
                }
            }

            DataTable dt = maintainViewState();
            DataRow foot = dt.NewRow();
            foot["ID"] = "0";
            foot["Remove"] = "0";
            dt.Rows.Add(foot);
            dt.AcceptChanges();
            ViewState["dtView"] = dt;
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
            txtClient.CssClass = "input_in date-picker date_style";

            //string DivisionID = ddlDivisionName.SelectedValue;
            for (int i = 0; i < Repeater1.Items.Count; i++)
            {
                Panel Panel1 = (Panel)Repeater1.Items[i].FindControl("Panel1");
                Repeater rptListBox = (Repeater)Panel1.FindControl("rptListBox");
                HiddenField hdnDeptID = (HiddenField)Panel1.FindControl("hdnDeptID");
                DataTable dt2 = this.ClientControllerInstance.GetDesignationByDivision(ClientID.ToString());
                rptListBox.DataSource = dt2;
                rptListBox.DataBind();

                foreach (RepeaterItem rptitem in rptListBox.Items)
                {


                    dtUserList.DefaultView.RowFilter = "TDeptID=" + i;
                    DataView Tdv = dtUserList.DefaultView;
                    DataTable userlist = Tdv.ToTable();

                    string Lbvalues = null;
                    ListBox LBdesignation = (ListBox)rptitem.FindControl("LBdesignation");
                    HiddenField hdnfldDeginationID = (HiddenField)rptitem.FindControl("hdnfldDeginationID");

                    userlist.DefaultView.RowFilter = "TDeginationID=" + hdnfldDeginationID.Value;
                    DataView dv = userlist.DefaultView;
                    if (dv.Count > 0)
                        Lbvalues = dv.ToTable().Rows[0]["TUserList"].ToString();
                    BindListBoxList(LBdesignation, Convert.ToInt32(hdnfldDeginationID.Value), Lbvalues);
                }
            }
        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Find the DropDownList in the Repeater Item.
                AdminController objadmin = new AdminController();
                DropDownList ddlPDept = (e.Item.FindControl("ddlPDept") as DropDownList);
                ddlPDept.DataSource = objadmin.GetParentDepartment(ClientID, 1);
                ddlPDept.DataTextField = "DepartmentName";
                ddlPDept.DataValueField = "Id";
                ddlPDept.DataBind();

                //Add Default Item in the DropDownList.
                ddlPDept.Items.Insert(0, new ListItem("Select", "-1"));

                //Select the Country of Customer in DropDownList.
                string id = (e.Item.DataItem as DataRowView)["ParentID"].ToString();
                ddlPDept.SelectedValue = id;
            }
            Panel Panel1 = (Panel)e.Item.FindControl("Panel1");
            if (((HiddenField)e.Item.FindControl("hdnDelete")).Value == "1")
            {
                // Panel1.Visible = false;
            }
            HiddenField hdnDeptID = (HiddenField)e.Item.FindControl("hdnDeptID");
            HiddenField hdnParendDeptId = (HiddenField)e.Item.FindControl("hdnParendDeptId");
            ClientDepartment cda = new ClientDepartment();
            if (ViewState["dtView"] != null)
            {
                int index;
                DataTable dtFilter = (DataTable)ViewState["dtView"];
                DataTable dt = null;
                if (hdnDeptID.Value == "0")
                {
                    index = e.Item.ItemIndex;
                    dt = dtFilter;
                }
                else
                {
                    index = 0;
                    dtFilter.DefaultView.RowFilter = "ID=" + hdnDeptID.Value;
                    DataView dv = dtFilter.DefaultView;
                    dt = dv.ToTable();
                }

                #region Gajendra
                //if (dt.Rows.Count > 0 && index <= e.Item.ItemIndex)
                //{
                //    cda.SalesManagerIDs = Convert.ToString(dt.Rows[index]["Sales"]);
                //    cda.TechnologistIDs = Convert.ToString(dt.Rows[index]["Tech"]);
                //    cda.DesignerIDs = Convert.ToString(dt.Rows[index]["Design"]);
                //    cda.ShippingManagerIDs = Convert.ToString(dt.Rows[index]["Shipping"]);
                //    cda.AccountManagerIDs = Convert.ToString(dt.Rows[index]["Account"]);
                //    cda.DeliveryManagerIDs = Convert.ToString(dt.Rows[index]["Delivery"]);
                //    cda.SamplingMerchantIDs = Convert.ToString(dt.Rows[index]["Sample"]);
                //    cda.ClientHeadIDs = Convert.ToString(dt.Rows[index]["Client"]);
                //    cda.FITMerchantIDs = Convert.ToString(dt.Rows[index]["Fit"]);
                //}
                #endregion
            }
            else if (ClientID != -1)
            {
                Repeater rptListBox = (Repeater)Panel1.FindControl("rptListBox");
                DataTable dtDesignation = this.ClientControllerInstance.GetDesignationByDivision(ClientID.ToString());
                rptListBox.DataSource = dtDesignation;
                rptListBox.DataBind();
                foreach (RepeaterItem rptitem in rptListBox.Items)
                {
                    DataTable userlist = this.ClientControllerInstance.GetUserListByDeptid(hdnDeptID.Value);
                    string Lbvalues = null;
                    ListBox LBdesignation = (ListBox)rptitem.FindControl("LBdesignation");
                    HiddenField hdnfldDeginationID = (HiddenField)rptitem.FindControl("hdnfldDeginationID");
                    userlist.DefaultView.RowFilter = "DesignationID=" + hdnfldDeginationID.Value;
                    DataView dv = userlist.DefaultView;
                    if (dv.Count > 0)
                        Lbvalues = dv.ToTable().Rows[0]["UserList"].ToString();
                    if (LBdesignation.Items.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(Lbvalues))
                        {
                            string[] accMgr = Lbvalues.Split(',');
                            foreach (string mgr in accMgr)
                            {
                                if (mgr != "")
                                {
                                    ListItem l = LBdesignation.Items.FindByValue(mgr);
                                    if (l != null)
                                    {
                                        l.Selected = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                        BindListBoxList(LBdesignation, Convert.ToInt32(hdnfldDeginationID.Value), Lbvalues);

                }
            }
            # region gajendra
            // ListBox ddSales1 = (ListBox)e.Item.FindControl("ddSales1");
            //if (ddlBuyingHouse.SelectedValue == "1")
            //{
            //    BindListBoxList(ddSales1, Convert.ToInt32(Designation.iKandi_Sales_SalesManager), cda.SalesManagerIDs);
            //    //ListItem li=new ListItem();
            //    //    li.Text="Vikrant Verma";
            //    //    li.Value="5";
            //    //    ddSales1.Items.Add(li);
            //}
            //else
            //{
            //    BindListBoxList(ddSales1, Convert.ToInt32(Designation.BIPL_Sales_Manager), cda.SalesManagerIDs);
            //}

            //ListBox ddTechnologist1 = (ListBox)e.Item.FindControl("ddTechnologist1");
            //BindListBoxList(ddTechnologist1, Convert.ToInt32(Designation.iKandi_Technical_Technologist), cda.TechnologistIDs);

            //ListBox ddDesigner1 = (ListBox)e.Item.FindControl("ddDesigner1");
            //BindListBoxList(ddDesigner1, Convert.ToInt32(Designation.iKandi_Design_Designers), cda.DesignerIDs);

            //ListBox ddShippingManager1 = (ListBox)e.Item.FindControl("ddShippingManager1");
            //BindListBoxList(ddShippingManager1, Convert.ToInt32(Designation.BIPL_Logistics_ShippingManager), cda.ShippingManagerIDs);

            //ListBox ddAccountManager1 = (ListBox)e.Item.FindControl("ddAccountManager1");
            //BindListBoxList(ddAccountManager1, Convert.ToInt32(Designation.BIPL_Merchandising_AccountManager), cda.AccountManagerIDs);

            //ListBox ddDeliveryManager1 = (ListBox)e.Item.FindControl("ddDeliveryManager1");
            //BindListBoxList(ddDeliveryManager1, Convert.ToInt32(Designation.BIPL_Logistics_DeliveryManager), cda.DeliveryManagerIDs);

            //ListBox ddSamplingMerchant1 = (ListBox)e.Item.FindControl("ddSamplingMerchant1");
            //BindListBoxList(ddSamplingMerchant1, Convert.ToInt32(Designation.BIPL_Merchandising_SamplingMerchant), cda.SamplingMerchantIDs);

            //ListBox ddClientHead1 = (ListBox)e.Item.FindControl("ddClientHead1");
            //BindListBoxList(ddClientHead1, Convert.ToInt32(Designation.BIPL_Client_Head), cda.ClientHeadIDs);

            ////string id = ListBoxGetSelected(ddAccountManager1);
            ////if (!string.IsNullOrEmpty(id))
            ////{
            ////    //   setFitMerchant(ddAccountManager1, cda.FITMerchantIDs);ddFITMerchant1
            ////    ListBox ddClientHead1 = (ListBox)e.Item.FindControl("ddClientHead1");
            ////}
            ////else
            //{
            //    ListBox ddFITMerchant1 = (ListBox)e.Item.FindControl("ddFITMerchant1");
            //    BindListBoxList(ddFITMerchant1, Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant), cda.FITMerchantIDs);
            //}

            //if (ddlBuyingHouse.SelectedItem.Value != "1")
            //{
            //    setVisible(0, ddClientHead1);
            //}

            # endregion

            setCheckBox((CheckBox)e.Item.FindControl("chkMon"), (HiddenField)e.Item.FindControl("hdnMon"));
            setCheckBox((CheckBox)e.Item.FindControl("chkTue"), (HiddenField)e.Item.FindControl("hdnTue"));
            setCheckBox((CheckBox)e.Item.FindControl("chkWed"), (HiddenField)e.Item.FindControl("hdnWed"));
            setCheckBox((CheckBox)e.Item.FindControl("chkThu"), (HiddenField)e.Item.FindControl("hdnThu"));
            setCheckBox((CheckBox)e.Item.FindControl("chkFri"), (HiddenField)e.Item.FindControl("hdnFri"));


        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Panel Panel2 = (Panel)e.Item.FindControl("Panel2");
            if (((HiddenField)e.Item.FindControl("hdnDelete")).Value == "1")
            {
                Panel2.Visible = false;
            }
        }

        protected void imgRemoveExt_Click(object sender, ImageClickEventArgs e)
        {
            ColorCodr = txtColorPickerValue.Text;
            //tdColorPicker.BgColor = System.Drawing.ColorTranslator.FromHtml(ColorCodr).ToString();
            tdColorPicker.Attributes.Add("style", "background-color:" + ColorCodr + "");
            ImageButton imgRemove = (ImageButton)sender;
            HiddenField hdnDelete = (HiddenField)imgRemove.Parent.FindControl("hdnDelete");
            Panel Panel2 = (Panel)imgRemove.Parent.FindControl("Panel2");
            hdnDelete.Value = "1";
            Panel2.Visible = false;

            DataTable dt = maintainViewStateExt();
            foreach (DataRow dr in dt.Rows)
            {
                if (Convert.ToString(dr["Remove"]) == "1" && Convert.ToString(dr["ContactID"]) == "0")
                {
                    dr.Delete();
                }
            }
            ViewState["dtViewExt"] = dt;
            Repeater2.DataSource = dt;
            Repeater2.DataBind();
        }

        protected void imgAddExt_Click(object sender, ImageClickEventArgs e)
        {
            ColorCodr = txtColorPickerValue.Text;
            tdColorPicker.BgColor = System.Drawing.ColorTranslator.FromHtml(ColorCodr).ToString();

            DataTable dt = maintainViewStateExt();
            DataRow foot = dt.NewRow();
            foot["ContactID"] = "0";
            foot["Remove"] = "0";
            dt.Rows.Add(foot);
            dt.AcceptChanges();
            ViewState["dtViewExt"] = dt;
            Repeater2.DataSource = dt;
            Repeater2.DataBind();
        }

        #endregion

        #region Private Methods
        private void BindControls()
        {
            bindDivisionName();
            bindCountry();
            DataTable dt = this.PrintControllerInstance.GetAllAqlStans();
            ddlAQLStandards.DataSource = dt;
            ddlAQLStandards.DataTextField = "AQLValue";
            ddlAQLStandards.DataValueField = "AQLValue";
            ddlAQLStandards.DataBind();
            DropdownHelper.FourPointCheckAcceptanceCriteria(ddlfpc);
            hdnfldClientID.Value = ClientID.ToString();
            //Gajendra Client Form Updates
            if (ClientID == -1)
            {
                AdminController oAdminController = new AdminController();
                divDept.Visible = false;
                divCopyFrom1.Visible = true;
                divCopyFrom2.Visible = true;
                ddlCopyFrom.DataSource = oAdminController.GetCopyFromDataDetails(ClientID);
                ddlCopyFrom.DataTextField = "CompanyName";
                ddlCopyFrom.DataValueField = "ClientID";
                ddlCopyFrom.DataBind();
            }
            else
            {
                divDept.Visible = true;
                divCopyFrom1.Visible = false;
                divCopyFrom2.Visible = false;
            }
        }
        private void bindDivisionName()
        {
            DataTable dt = this.PrintControllerInstance.GetDivisionName();
            ddlDivisionName.DataSource = dt;
            ddlDivisionName.DataTextField = "DivisionName";
            ddlDivisionName.DataValueField = "ManageDivisionID";
            ddlDivisionName.DataBind();
            ddlDivisionName.Items.RemoveAt(0);
            ListItem li = new ListItem();
            li.Text = "Select";
            li.Value = "0";
            ddlDivisionName.Items.Insert(0, li);
        }

        private void bindCountry()
        {
            DataTable dt = this.PrintControllerInstance.CountryCode();
            LBcountry.DataSource = dt;
            LBcountry.DataTextField = "Country_Code";
            LBcountry.DataValueField = "Country_Code_Id";
            LBcountry.DataBind();
        }

        private void bindBuyingHouse(string DivisionID)
        {
            DataTable dt = this.PrintControllerInstance.GetBuyingHouseByDivision(DivisionID);
            ddlBuyingHouse.DataSource = dt;
            ddlBuyingHouse.DataTextField = "CompanyName";
            ddlBuyingHouse.DataValueField = "ID";
            ddlBuyingHouse.DataBind();
            ddlBuyingHouse.Items.RemoveAt(0);
            ListItem li = new ListItem();
            li.Text = "Select";
            li.Value = "0";
            ddlBuyingHouse.Items.Insert(0, li);
        }
        private void PopulateClientData()
        {
            Client client = this.ClientControllerInstance.GetClientById(ClientID);

            txtCompany.Text = client.CompanyName;
            txtWebsite.Text = client.Website;
            txtAddress.Text = client.Address;
            txtCode.Text = client.ClientCode.ToString();
            txtEmail.Text = client.Email;
            txtPhone.Text = client.Phone;
            ddlfpc.SelectedValue = Convert.ToString(client.FPCAcceptanceCriteria);
            ddlDivisionName.SelectedValue = client.DivisionID;
            //ViewState["DivisionIDView"] = client.DivisionID;
            bindBuyingHouse(client.DivisionID);
            ddlBuyingHouse.SelectedValue = client.BuyingHouseId.ToString();
            lblBuyingHouse.Text = ddlBuyingHouse.SelectedItem.Text;

            DataSet ds = this.ClientControllerInstance.GetCountryCodesByClientID(ClientID);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem l = LBcountry.Items.FindByValue(ds.Tables[0].Rows[i]["CountryCodeid"].ToString());
                if (l != null)
                {
                    l.Selected = true;
                }
            }

            ColorCodr = client.ClientColorCode;
            tdColorPicker.Attributes.Add("style", "background-color:" + client.ClientColorCode + "");

            if (Convert.ToInt32(ddlBuyingHouse.SelectedValue) > 1)
            {
                lblFitMer1.Text = "Production  Merchandiser/ Technologist*:";
                lblSamplingMer1.Text = "Sampling Merchant/ Designer*:";
            }
            else
            {
                lblFitMer1.Text = "Production  Merchandiser*:";
                lblSamplingMer1.Text = "Sampling Merchant*:";
            }
            if (client.Aql.ToString() == "4")
            {
                ddlAQLStandards.SelectedValue = "4.0";
            }
            else
            {
                ddlAQLStandards.SelectedValue = client.Aql.ToString();
            }
            chkMDA.Checked = Convert.ToBoolean(client.IsMDARequired);
            chkPPSample.Checked = Convert.ToBoolean(client.IsPPSampleRequired);
            txt_Discount.Text = client.Discount.ToString();
            txt_Payment.Text = client.PaymentTerms.ToString();
            txtOfficialName.Text = client.OfficialName;
            txtBillingAddess.Text = client.BillingAddess;//abhishek
            if (Convert.ToDateTime(client.ClientSince) != DateTime.MinValue && Convert.ToDateTime(client.ClientSince) != Convert.ToDateTime("1/1/1900") &&
                Convert.ToDateTime(client.ClientSince) != Convert.ToDateTime("01-01-0001") && Convert.ToDateTime(client.ClientSince) != Convert.ToDateTime("01-01-1753"))
            {
                txtClient.Text = client.ClientSince.ToString("dd MMM yy (ddd)");
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("ContactID");
            dt.Columns.Add("Email");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Remove");
            foreach (ClientContact cc in client.Contacts)
            {
                DataRow dr = dt.NewRow();
                dr["Name"] = cc.Name;
                dr["ContactID"] = cc.ContactID;
                dr["Phone"] = cc.Phone;
                dr["Email"] = cc.Email;
                dr["Remove"] = cc.IsDeletedContact;
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            ViewState["dtViewExt"] = dt;
            Repeater2.DataSource = dt;
            Repeater2.DataBind();

        }
        private void CreateClient()
        {
            Client client = new Client();
            client.ClientID = this.ClientID;
            client.CompanyName = txtCompany.Text;
            client.Website = txtWebsite.Text;
            client.Address = txtAddress.Text;
            client.ClientCode = txtCode.Text;
            client.Email = txtEmail.Text;
            client.Phone = txtPhone.Text;
            client.Aql = Convert.ToDouble(ddlAQLStandards.SelectedValue);
            client.BuyingHouseId = Convert.ToInt32(ddlBuyingHouse.SelectedValue);
            client.IsMDARequired = Convert.ToInt32(chkMDA.Checked);
            client.IsPPSampleRequired = Convert.ToInt32(chkPPSample.Checked);
            if (!string.IsNullOrEmpty(txt_Discount.Text))
                client.Discount = Convert.ToDecimal(txt_Discount.Text);
            if (!string.IsNullOrEmpty(txt_Payment.Text))
                client.PaymentTerms = Convert.ToInt32(txt_Payment.Text);
            client.BillingAddess = txtBillingAddess.Text;
            client.OfficialName = txtOfficialName.Text;
            client.ClientSince = DateHelper.ParseDate(txtClient.Text).Value;


            client.Departments = new List<ClientDepartment>();
            int i = 1;
            while (!string.IsNullOrEmpty(Request.Params["txtDept" + i.ToString()]))
            {
                // System.Diagnostics.Debugger.Break();
                ClientDepartment dept = new ClientDepartment();
                dept.Name = Request.Params["txtDept" + i.ToString()];
                dept.Username = Request.Params["txtUsername" + i.ToString()];
                dept.Password = Request.Params["txtPwd" + i.ToString()];

                if (!(null == Request.Params["chkMon" + i.ToString()]))
                    dept.Mon = 1;
                if (!(null == Request.Params["chkTue" + i.ToString()]))
                    dept.Tue = 1;
                if (!(null == Request.Params["chkWed" + i.ToString()]))
                    dept.Wed = 1;
                if (!(null == Request.Params["chkThu" + i.ToString()]))
                    dept.Thu = 1;
                if (!(null == Request.Params["chkFri" + i.ToString()]))
                    dept.Fri = 1;

                if (!string.IsNullOrEmpty(Request.Params["txtIsDeletedDept" + i.ToString().Trim()]))
                {
                    dept.IsDeletedDept = Convert.ToInt32(Request.Params["txtIsDeletedDept" + i.ToString()]);
                }
                if (!string.IsNullOrEmpty(Request.Params["txtDepartmentID" + i.ToString()]))
                {
                    dept.DeptID = Convert.ToInt32(Request.Params["txtDepartmentID" + i.ToString()]);
                }
                else
                {
                    dept.DeptID = -1;
                }

                dept.ClientDepartmentAssociation = new List<ClientDepartmentAssociation>();

                if (!(null == Request.Params["ddSales" + i.ToString()]))
                {
                    String SalesManagerID = Request.Params["ddSales" + i.ToString()];
                    var salesManagerID = SalesManagerID.Split(',');
                    for (int k = 1; k <= salesManagerID.Length; k++)
                    {
                        ClientDepartmentAssociation cda = new ClientDepartmentAssociation();
                        cda.Id = -1;
                        cda.DeptID = -1;
                        cda.DesignationId = Convert.ToInt32(Designation.iKandi_Sales_SalesManager);
                        cda.UserId = Convert.ToInt32(salesManagerID[k - 1]);
                        dept.ClientDepartmentAssociation.Add(cda);
                    }
                }

                if (!(null == Request.Params["ddDesigner" + i.ToString()]))
                {
                    String DesignerID = Request.Params["ddDesigner" + i.ToString()];
                    var designerID = DesignerID.Split(',');
                    for (int k = 1; k <= designerID.Length; k++)
                    {
                        ClientDepartmentAssociation cda = new ClientDepartmentAssociation();
                        cda.Id = -1;
                        cda.DeptID = -1;
                        cda.DesignationId = Convert.ToInt32(Designation.iKandi_Design_Designers);
                        cda.UserId = Convert.ToInt32(designerID[k - 1]);
                        dept.ClientDepartmentAssociation.Add(cda);
                    }
                }

                if (!(null == Request.Params["ddAccountManager" + i.ToString()]))
                {
                    String AccountManagerID = Request.Params["ddAccountManager" + i.ToString()];
                    var accountManagerID = AccountManagerID.Split(',');
                    for (int k = 1; k <= accountManagerID.Length; k++)
                    {
                        ClientDepartmentAssociation cda = new ClientDepartmentAssociation();
                        cda.Id = -1;
                        cda.DeptID = -1;
                        cda.DesignationId = Convert.ToInt32(Designation.BIPL_Merchandising_AccountManager);
                        cda.UserId = Convert.ToInt32(accountManagerID[k - 1]);
                        dept.ClientDepartmentAssociation.Add(cda);
                    }
                }

                if (!(null == Request.Params["ddTechnologist" + i.ToString()]))
                {
                    String TechnologistID = Request.Params["ddTechnologist" + i.ToString()];
                    var technologistID = TechnologistID.Split(',');
                    for (int k = 1; k <= technologistID.Length; k++)
                    {
                        ClientDepartmentAssociation cda = new ClientDepartmentAssociation();
                        cda.Id = -1;
                        cda.DeptID = -1;
                        cda.DesignationId = Convert.ToInt32(Designation.iKandi_Technical_Technologist);
                        cda.UserId = Convert.ToInt32(technologistID[k - 1]);
                        dept.ClientDepartmentAssociation.Add(cda);
                    }
                }

                if (!(null == Request.Params["ddShippingManager" + i.ToString()]))
                {
                    String ShippingManagerID = Request.Params["ddShippingManager" + i.ToString()];
                    var shippingManagerID = ShippingManagerID.Split(',');
                    for (int k = 1; k <= shippingManagerID.Length; k++)
                    {
                        ClientDepartmentAssociation cda = new ClientDepartmentAssociation();
                        cda.Id = -1;
                        cda.DeptID = -1;
                        cda.DesignationId = Convert.ToInt32(Designation.BIPL_Logistics_ShippingManager);
                        cda.UserId = Convert.ToInt32(shippingManagerID[k - 1]);
                        dept.ClientDepartmentAssociation.Add(cda);
                    }
                }

                if (!(null == Request.Params["ddDeliveryManager" + i.ToString()]))
                {
                    String DeliveryManagerID = Request.Params["ddDeliveryManager" + i.ToString()];
                    var deliveryManagerID = DeliveryManagerID.Split(',');
                    for (int k = 1; k <= deliveryManagerID.Length; k++)
                    {
                        ClientDepartmentAssociation cda = new ClientDepartmentAssociation();
                        cda.Id = -1;
                        cda.DeptID = -1;
                        cda.DesignationId = Convert.ToInt32(Designation.BIPL_Logistics_DeliveryManager);
                        cda.UserId = Convert.ToInt32(deliveryManagerID[k - 1]);
                        dept.ClientDepartmentAssociation.Add(cda);
                    }
                }

                if (!(null == Request.Params["ddFITMerchant" + i.ToString()]))
                {
                    String FITMerchantID = Request.Params["ddFITMerchant" + i.ToString()];
                    var fITMerchantID = FITMerchantID.Split(',');
                    for (int k = 1; k <= fITMerchantID.Length; k++)
                    {
                        ClientDepartmentAssociation cda = new ClientDepartmentAssociation();
                        cda.Id = -1;
                        cda.DeptID = -1;
                        cda.DesignationId = Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant);
                        cda.UserId = Convert.ToInt32(fITMerchantID[k - 1]);
                        dept.ClientDepartmentAssociation.Add(cda);
                    }
                }

                if (!(null == Request.Params["ddSamplingMerchant" + i.ToString()]))
                {
                    String SamplingMerchantID = Request.Params["ddSamplingMerchant" + i.ToString()];
                    var samplingMerchantID = SamplingMerchantID.Split(',');
                    for (int k = 1; k <= samplingMerchantID.Length; k++)
                    {
                        ClientDepartmentAssociation cda = new ClientDepartmentAssociation();
                        cda.Id = -1;
                        cda.DeptID = -1;
                        cda.DesignationId = Convert.ToInt32(Designation.BIPL_Merchandising_SamplingMerchant);
                        cda.UserId = Convert.ToInt32(samplingMerchantID[k - 1]);
                        dept.ClientDepartmentAssociation.Add(cda);
                    }
                }

                if (!(null == Request.Params["ddClientHead" + i.ToString()]))
                {
                    String ClientHeadID = Request.Params["ddClientHead" + i.ToString()];
                    var clientHeadID = ClientHeadID.Split(',');
                    for (int k = 1; k <= clientHeadID.Length; k++)
                    {
                        ClientDepartmentAssociation cda = new ClientDepartmentAssociation();
                        cda.Id = -1;
                        cda.DeptID = -1;
                        cda.DesignationId = Convert.ToInt32(Designation.BIPL_Client_Head);
                        cda.UserId = Convert.ToInt32(clientHeadID[k - 1]);
                        dept.ClientDepartmentAssociation.Add(cda);
                    }
                }
                client.Departments.Add(dept);
                i++;
            }


            client.Contacts = new List<ClientContact>();

            int j = 1;

            while (!string.IsNullOrEmpty(Request.Params["txtName" + j.ToString()]))
            {

                ClientContact ccontact = new ClientContact();
                ccontact.Name = Request.Params["txtName" + j.ToString()];
                ccontact.Email = Request.Params["txtEmail" + j.ToString()];
                ccontact.Phone = Request.Params["txtPhone" + j.ToString()];
                if (!string.IsNullOrEmpty(Request.Params["txtIsDeletedContact" + j.ToString()]))
                {
                    ccontact.IsDeletedContact = Convert.ToInt32(Request.Params["txtIsDeletedContact" + j.ToString()]);
                }
                if (!string.IsNullOrEmpty(Request.Params["txtContactID" + j.ToString()]))
                {
                    ccontact.ContactID = Convert.ToInt32(Request.Params["txtContactID" + j.ToString()]);
                }
                else
                {
                    ccontact.ContactID = -1;

                }
                client.Contacts.Add(ccontact);

                j++;
            }

            this.ClientControllerInstance.SaveClient(client);

            pnlForm.Visible = false;
            pnlMessage.Visible = true;
        }
        private void CreateClientDataTable()
        {
            Client client = new Client();
            client.ClientID = this.ClientID;
            client.CompanyName = txtCompany.Text;
            client.Website = txtWebsite.Text;
            client.Address = txtAddress.Text;
            client.ClientCode = txtCode.Text;
            if (ddlfpc.SelectedValue != "")
            {
                client.FPCAcceptanceCriteria = Convert.ToInt32(ddlfpc.SelectedValue);
            }
            client.Email = txtEmail.Text;
            client.Phone = txtPhone.Text;
            client.Aql = Convert.ToDouble(ddlAQLStandards.SelectedValue);
            client.BuyingHouseId = Convert.ToInt32(ddlBuyingHouse.SelectedValue);
            client.DivisionID = ddlDivisionName.SelectedValue;
            client.IsMDARequired = Convert.ToInt32(chkMDA.Checked);
            client.IsPPSampleRequired = Convert.ToInt32(chkPPSample.Checked);
            if (!string.IsNullOrEmpty(txt_Discount.Text))
                client.Discount = Convert.ToDecimal(txt_Discount.Text);
            if (!string.IsNullOrEmpty(txt_Payment.Text))
                client.PaymentTerms = Convert.ToInt32(txt_Payment.Text);
            client.BillingAddess = txtBillingAddess.Text;
            client.OfficialName = txtOfficialName.Text;
            client.ClientSince = DateHelper.ParseDate(txtClient.Text).Value;
            client.ClientColorCode = txtColorPickerValue.Text.Trim();
            client.Departments = new List<ClientDepartment>();
            DataTable dt = maintainViewState();
            # region //Gajendra
            //ClientDepartment dept = new ClientDepartment();
            //            foreach (DataRow dr in dt.Rows)
            //            {               



            //                //if (!string.IsNullOrEmpty(Convert.ToString(dr["Sales"])))
            //                //{
            //                //    dept = saveDept(dept, Convert.ToString(dr["Sales"]), Convert.ToInt32(Designation.iKandi_Sales_SalesManager));
            //                //}
            //                //if (!string.IsNullOrEmpty(Convert.ToString(dr["Design"])) && client.BuyingHouseId == 1)
            //                //{
            //                //    dept = saveDept(dept, Convert.ToString(dr["Design"]), Convert.ToInt32(Designation.iKandi_Design_Designers));
            //                //}
            //                //if (!string.IsNullOrEmpty(Convert.ToString(dr["Account"])))
            //                //{
            //                //    dept = saveDept(dept, Convert.ToString(dr["Account"]), Convert.ToInt32(Designation.BIPL_Merchandising_AccountManager));
            //                //}
            //                //if (!string.IsNullOrEmpty(Convert.ToString(dr["Tech"])) && client.BuyingHouseId == 1)
            //                //{
            //                //    dept = saveDept(dept, Convert.ToString(dr["Tech"]), Convert.ToInt32(Designation.iKandi_Technical_Technologist));
            //                //}

            //                //if (!string.IsNullOrEmpty(Convert.ToString(dr["Shipping"])))
            //                //{
            //                //    dept = saveDept(dept, Convert.ToString(dr["Shipping"]), Convert.ToInt32(Designation.BIPL_Logistics_ShippingManager));
            //                //}

            //                //if (!string.IsNullOrEmpty(Convert.ToString(dr["Delivery"])))
            //                //{
            //                //    dept = saveDept(dept, Convert.ToString(dr["Delivery"]), Convert.ToInt32(Designation.BIPL_Logistics_DeliveryManager));
            //                //}

            //                //if (!string.IsNullOrEmpty(Convert.ToString(dr["Fit"])))
            //                //{
            //                //    dept = saveDept(dept, Convert.ToString(dr["Fit"]), Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant));
            //                //}

            //                //if (!string.IsNullOrEmpty(Convert.ToString(dr["Sample"])))
            //                //{
            //                //    dept = saveDept(dept, Convert.ToString(dr["Sample"]), Convert.ToInt32(Designation.BIPL_Merchandising_SamplingMerchant));
            //                //}

            //                //if (!string.IsNullOrEmpty(Convert.ToString(dr["Client"])))
            //                //{
            //                //    dept = saveDept(dept, Convert.ToString(dr["Client"]), Convert.ToInt32(Designation.BIPL_Client_Head));
            //                //}
            //
            //            }
            # endregion

            foreach (RepeaterItem ri in Repeater1.Items)
            {
                ClientDepartment dept = new ClientDepartment();
                dept.ClientDepartmentAssociation = new List<ClientDepartmentAssociation>();

                var ID = ((HiddenField)ri.FindControl("hdnDeptID")).Value;
                var hdnParentID = ((HiddenField)ri.FindControl("hdnParendDeptId")).Value;
                var Remove = ((HiddenField)ri.FindControl("hdnDelete")).Value;
                var DepartmentName = ((TextBox)ri.FindControl("txtDept1")).Text;
                var Email = ((TextBox)ri.FindControl("txtUsername1")).Text;
                var Parentid = ((DropDownList)ri.FindControl("ddlPDept")).SelectedValue.ToString();

                var Mon = getCheckBox((CheckBox)ri.FindControl("chkMon"));
                var Tue = getCheckBox((CheckBox)ri.FindControl("chkTue"));
                var Wed = getCheckBox((CheckBox)ri.FindControl("chkWed"));
                var Thu = getCheckBox((CheckBox)ri.FindControl("chkThu"));
                var Fri = getCheckBox((CheckBox)ri.FindControl("chkFri"));



                dept.Name = DepartmentName;
                dept.Name = dept.Name.Replace(' ', '_');
                string strCompany = txtCompany.Text.Replace(' ', '_');

                if (Email == "")
                {
                    dept.Username = dept.Name + "@" + strCompany;
                }
                else
                {
                    dept.Username = Email;
                }
                //dept.Password = Convert.ToString(dr["Password"]);

                if (Mon == "1")
                    dept.Mon = 1;
                if (Tue == "1")
                    dept.Tue = 1;
                if (Wed == "1")
                    dept.Wed = 1;
                if (Thu == "1")
                    dept.Thu = 1;
                if (Fri == "1")
                    dept.Fri = 1;
                if (Remove == "")
                {
                    dept.IsDeletedDept = 0;
                }
                else
                {
                    dept.IsDeletedDept = Convert.ToInt32(Remove);
                }

                Panel Panel1 = (Panel)ri.FindControl("Panel1");
                Repeater rptListBox = (Repeater)Panel1.FindControl("rptListBox");
                var deptid = ((HiddenField)ri.FindControl("hdnDeptID")).Value;
                foreach (RepeaterItem rptLBitems in rptListBox.Items)
                {
                    ListBox LBdesignation = (ListBox)rptLBitems.FindControl("LBdesignation");
                    HiddenField hdnfldDeginationID = (HiddenField)rptLBitems.FindControl("hdnfldDeginationID");
                    var Lbvalues = ListBoxGetSelected(LBdesignation);
                    dept = saveDept(dept, Lbvalues, Convert.ToInt32(hdnfldDeginationID.Value));
                }
                if (Convert.ToInt32(deptid) > 0)
                {
                    dept.DeptID = Convert.ToInt32(deptid);
                }
                else { dept.DeptID = -1; }

                dept.ParentId = Convert.ToInt32(Parentid);

                client.Departments.Add(dept);
            }

            client.Contacts = new List<ClientContact>();
            DataTable dtContacts = maintainViewStateExt();
            foreach (DataRow drContacts in dtContacts.Rows)
            {
                ClientContact ccontact = new ClientContact();
                ccontact.Name = Convert.ToString(drContacts["Name"]);
                ccontact.Email = Convert.ToString(drContacts["Email"]);
                ccontact.Phone = Convert.ToString(drContacts["Phone"]);
                ccontact.IsDeletedContact = Convert.ToInt32(drContacts["Remove"]);


                if (Convert.ToInt32(drContacts["ContactID"]) > 0)
                {
                    ccontact.ContactID = Convert.ToInt32(drContacts["ContactID"]);
                }
                else { ccontact.ContactID = -1; }

                client.Contacts.Add(ccontact);
            }
           

            Client cl = this.ClientControllerInstance.SaveClient(client);
            int id = this.ClientControllerInstance.SaveCountryCodes(cl.ClientID, 0, "DeleteCountryCode");
            foreach (ListItem item in LBcountry.Items)
            {
                if (item.Selected)
                {
                    int Id = this.ClientControllerInstance.SaveCountryCodes(cl.ClientID, Convert.ToInt32(item.Value), "SaveCountryCode");
                }
            }

            pnlForm.Visible = false;
            pnlMessage.Visible = true;
            if (cl.ClientID > 0 && ClientID == -1)
            {
                AdminController oAdminController = new AdminController();
                oAdminController.UpdateCopyFrom(cl.ClientID, Convert.ToInt32(ddlCopyFrom.SelectedValue), ApplicationHelper.LoggedInUser.UserData.UserID);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "RefreshParentPage", "<script language='javascript'>Reload();</script>");
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('../Admin/TargetAdmin.aspx", true);
            }
        }

        #region Repeater1Department
        private ClientDepartment saveDept(ClientDepartment dept, string deptId, int designationID)
        {
            if (!string.IsNullOrEmpty(deptId))
            {
                var deptIds = deptId.Split(',');
                for (int k = 1; k <= deptIds.Length; k++)
                {
                    if (deptIds[k - 1] != "")
                    {
                        ClientDepartmentAssociation cda = new ClientDepartmentAssociation();
                        cda.Id = -1;
                        cda.DeptID = -1;
                        //if (Convert.ToInt32(deptIds[k - 1]) == 5)
                        //{
                        //    designationID = 3;
                        //}
                        cda.DesignationId = designationID;
                        cda.UserId = Convert.ToInt32(deptIds[k - 1]);
                        dept.ClientDepartmentAssociation.Add(cda);
                    }
                }
            }
            return dept;
        }
        private DataTable maintainViewState()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("DepartmentName");
            dt.Columns.Add("ID");
            dt.Columns.Add("ParentID");
            dt.Columns.Add("Email");
            dt.Columns.Add("Password");
            dt.Columns.Add("Mon");
            dt.Columns.Add("Tue");
            dt.Columns.Add("Wed");
            dt.Columns.Add("Thu");
            dt.Columns.Add("Fri");
            #region gajendra
            //dt.Columns.Add("Sales");
            //dt.Columns.Add("Tech");
            //dt.Columns.Add("Design");
            //dt.Columns.Add("Shipping");
            //dt.Columns.Add("Account");
            //dt.Columns.Add("Delivery");
            //dt.Columns.Add("Sample");
            //dt.Columns.Add("Client");
            //dt.Columns.Add("Fit");
            #endregion
            dt.Columns.Add("Remove");

            foreach (RepeaterItem ri in Repeater1.Items)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = ((HiddenField)ri.FindControl("hdnDeptID")).Value;
                dr["ParentID"] = ((DropDownList)ri.FindControl("ddlPDept")).SelectedValue.ToString();
                dr["Remove"] = ((HiddenField)ri.FindControl("hdnDelete")).Value;
                dr["DepartmentName"] = ((TextBox)ri.FindControl("txtDept1")).Text;
                dr["Email"] = ((TextBox)ri.FindControl("txtUsername1")).Text;
                // dr["Password"] = ((TextBox)ri.FindControl("txtPassword1")).Text;
                dr["Mon"] = getCheckBox((CheckBox)ri.FindControl("chkMon"));
                dr["Tue"] = getCheckBox((CheckBox)ri.FindControl("chkTue"));
                dr["Wed"] = getCheckBox((CheckBox)ri.FindControl("chkWed"));
                dr["Thu"] = getCheckBox((CheckBox)ri.FindControl("chkThu"));
                dr["Fri"] = getCheckBox((CheckBox)ri.FindControl("chkFri"));

                #region gajendra
                //dr["Sales"] = ListBoxGetSelected((ListBox)ri.FindControl("ddSales1"));
                //dr["Tech"] = ListBoxGetSelected((ListBox)ri.FindControl("ddTechnologist1"));
                //dr["Design"] = ListBoxGetSelected((ListBox)ri.FindControl("ddDesigner1"));
                //dr["Shipping"] = ListBoxGetSelected((ListBox)ri.FindControl("ddShippingManager1"));
                //dr["Account"] = ListBoxGetSelected((ListBox)ri.FindControl("ddAccountManager1"));
                //dr["Delivery"] = ListBoxGetSelected((ListBox)ri.FindControl("ddDeliveryManager1"));
                //dr["Sample"] = ListBoxGetSelected((ListBox)ri.FindControl("ddSamplingMerchant1"));
                //dr["Client"] = ListBoxGetSelected((ListBox)ri.FindControl("ddClientHead1"));
                //dr["Fit"] = ListBoxGetSelected((ListBox)ri.FindControl("ddFITMerchant1"));
                #endregion

                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            return dt;
        }
        /*Functions for ListBoxes*/
        private void BindListBox(ListBox lb, int designation)
        {
            DataTable dt = new DataTable();

            dt = this.UserControllerInstance.GetUsersByDesignationDataTable(designation);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ListItem li = new ListItem();
                    li.Text = Convert.ToString(dr["FirstName"]) + " " + Convert.ToString(dr["LastName"]);
                    li.Value = Convert.ToString(dr["UserID"]);
                    lb.Items.Add(li);
                }
            }
            lb.DataBind();
            dt.Dispose();
        }
        private void BindListBoxList(ListBox lb, int designation, string userID)
        {
            DataTable dt = new DataTable();

            List<User> user = this.UserControllerInstance.GetUsersByDesignation(designation);
            foreach (User ui in user)
            {
                ListItem li = new ListItem();
                li.Text = ui.FirstName + " " + ui.LastName;
                li.Value = Convert.ToString(ui.UserID);
                lb.Items.Add(li);
            }
            lb.DataBind();

            # region Gajendra
            //if (designation == 4)
            //{
            //    ListItem li = new ListItem();
            //    li.Text = "Vikrant Verma";
            //    li.Value = "5";
            //    lb.Items.Add(li);
            //}
            # endregion

            if (!string.IsNullOrEmpty(userID))
            {
                string[] accMgr = userID.Split(',');
                foreach (string mgr in accMgr)
                {
                    if (mgr != "")
                    {
                        ListItem l = lb.Items.FindByValue(mgr);
                        if (l != null)
                        {
                            l.Selected = true;
                        }
                    }
                }
            }
            dt.Dispose();
        }

        //private void BindListBoxList(ListBox lb, int designation)
        //{
        //    DataTable dt = new DataTable();

        //    List<User> user = this.UserControllerInstance.GetUsersByDesignation(designation);
        //    foreach (User ui in user)
        //    {
        //        ListItem li = new ListItem();
        //        li.Text = ui.FirstName + " " + ui.LastName;
        //        li.Value = Convert.ToString(ui.UserID);
        //        lb.Items.Add(li);
        //    }
        //    lb.DataBind();
        //    dt.Dispose();
        //}
        private string ListBoxGetSelected(ListBox lb)
        {
            string str = string.Empty;

            foreach (ListItem li in lb.Items)
            {
                if (li.Selected == true)
                {
                    str = str + "," + li.Value;
                }
            }

            return str;
        }
        private ListBox DeleteAll(ListBox lb)
        {
            int count = lb.Items.Count;
            for (int i = count; i > 0; i--)
            {
                lb.Items.RemoveAt(i - 1);
            }
            return lb;
        }
        private void setFitMerchant(ListBox lb, string userID)
        {
            string id = ListBoxGetSelected(lb);
            ListBox fit = (ListBox)((lb).Parent.FindControl("ddFITMerchant1"));
            fit = DeleteAll(fit);
            List<User> users = this.UserControllerInstance.GetUsersByDesignationByAccountManagerIDs(id, Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant));
            foreach (User ui in users)
            {
                ListItem li = new ListItem();
                li.Text = ui.FirstName + " " + ui.LastName;
                li.Value = Convert.ToString(ui.UserID);
                fit.Items.Add(li);
            }
            fit.DataBind();

            if (!string.IsNullOrEmpty(userID))
            {
                string[] accMgr = (userID).Split(',');
                foreach (string mgr in accMgr)
                {
                    if (mgr != "")
                    {
                        ListItem l = fit.Items.FindByValue(mgr);
                        if (l != null)
                        {
                            l.Selected = true;
                        }
                    }
                }
            }
            if (ddlBuyingHouse.SelectedItem.Value != "1")
            {
                setVisible(0, lb);
            }
            else
            {
                setVisible(1, lb);
            }
        }
        /*Ends*/

        private void setVisible(int buyingHouse, ListBox lb)
        {
            Panel panel = (Panel)lb.Parent;
            string visible;
            if (buyingHouse == 1)
            {
                visible = "display:block";
                Label lbl = (Label)panel.FindControl("lblFitMer1");
                lbl.Text = "Production  Merchandiser";
                lbl = (Label)panel.FindControl("lblSamplingMer1");
                lbl.Text = "Sampling Merchant";
            }
            else
            {
                visible = "display:none";
                Label lbl = (Label)panel.FindControl("lblFitMer1");
                lbl.Text = "Production  Merchandiser/ Technologist";
                lbl = (Label)panel.FindControl("lblSamplingMer1");
                lbl.Text = "Sampling Merchant/Designer";
            }
            HtmlTableCell htc = (HtmlTableCell)panel.FindControl("tdDes");
            htc.Attributes.Add("style", visible);
            htc = (HtmlTableCell)panel.FindControl("tdDes1");
            htc.Attributes.Add("style", visible);
            htc = (HtmlTableCell)panel.FindControl("tdTech");
            htc.Attributes.Add("style", visible);
            htc = (HtmlTableCell)panel.FindControl("tdTech1");
            htc.Attributes.Add("style", visible);
        }

        /*Functions for Checkboxes*/
        private void setCheckBox(CheckBox chk, HiddenField hdnChk)
        {
            if (hdnChk.Value == "1")
            {
                chk.Checked = true;
            }
            else
            { chk.Checked = false; }
        }
        private string getCheckBox(CheckBox chk)
        {
            if (chk.Checked == true)
                return "1";
            else return "0";
        }
        protected void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            string id = (chk.ID).Substring(3);
            if (chk.Checked == true)
            {
                ((HiddenField)chk.Parent.FindControl("hdn" + id)).Value = "1";
            }
            else
            {
                ((HiddenField)chk.Parent.FindControl("hdn" + id)).Value = "0";
            }
        }
        /* ends*/
        #endregion

        #region Repeater2External
        private DataTable maintainViewStateExt()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("ContactID");
            dt.Columns.Add("Email");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Remove");

            foreach (RepeaterItem ri in Repeater2.Items)
            {
                DataRow dr = dt.NewRow();
                dr["ContactID"] = ((HiddenField)ri.FindControl("hdnContactID1")).Value;
                dr["Remove"] = ((HiddenField)ri.FindControl("hdnDelete")).Value;
                dr["Name"] = ((TextBox)ri.FindControl("txtName1")).Text;
                dr["Email"] = ((TextBox)ri.FindControl("txtEmail1")).Text;
                dr["Phone"] = ((TextBox)ri.FindControl("txtPhone1")).Text;
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            return dt;

        }
        #endregion

        protected void ddlAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = ListBoxGetSelected((ListBox)sender);
            ListBox fit = (ListBox)(((ListBox)sender).Parent.FindControl("ddl_Fitmerchant"));
            fit = DeleteAll(fit);
            List<User> users = this.UserControllerInstance.GetUsersByDesignationByAccountManagerIDs(id, Convert.ToInt32(Designation.BIPL_Merchandising_FitMerchant));
            foreach (User ui in users)
            {
                ListItem li = new ListItem();
                li.Text = ui.FirstName + " " + ui.LastName;
                li.Value = Convert.ToString(ui.UserID);
                fit.Items.Add(li);
            }
            fit.DataBind();
        }

        //protected void ddAccount_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //   //Gajendra setFitMerchant((ListBox)sender, null);
        //}

        #endregion

        protected void ddlDivisionName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string DivisionID = ddlDivisionName.SelectedValue;
            bindBuyingHouse(DivisionID);
            //for (int i = 0; i < Repeater1.Items.Count; i++)
            //{
            //    Panel Panel1 = (Panel)Repeater1.Items[i].FindControl("Panel1");
            //    Repeater rptListBox = (Repeater)Panel1.FindControl("rptListBox");
            //    HiddenField hdnDeptID = (HiddenField)Panel1.FindControl("hdnDeptID");
            //    DataTable dt = this.ClientControllerInstance.GetDesignationByDivision(DivisionID);            
            //        rptListBox.DataSource = dt;
            //        rptListBox.DataBind();
            //        Panel1.Visible = true;

            //        foreach (RepeaterItem rptitem in rptListBox.Items)
            //        {
            //            ListBox LBdesignation = (ListBox)rptitem.FindControl("LBdesignation");
            //            HiddenField hdnfldDeginationID = (HiddenField)rptitem.FindControl("hdnfldDeginationID");
            //            BindListBoxList(LBdesignation, Convert.ToInt32(hdnfldDeginationID.Value), null);
            //        }
            //}

        }
        # region Gajendra
        //protected void ddlBuyingHouse_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < Repeater1.Items.Count; i++)
        //    {
        //        Panel Panel1 = (Panel)Repeater1.Items[i].FindControl("Panel1");
        //        int deptId;
        //        if (((HiddenField)Panel1.FindControl("hdnDeptID")).Value != "")
        //        {
        //            deptId = Convert.ToInt32(((HiddenField)Panel1.FindControl("hdnDeptID")).Value);
        //        }
        //        else deptId = 0;
        //        
        //        //ListBox ddSales1 = (ListBox)Panel1.FindControl("ddSales1");
        //        //ddSales1 = DeleteAll(ddSales1);
        //        //if (ddlBuyingHouse.SelectedItem.Value == "1")
        //        //{
        //        //    BindListBoxList(ddSales1, Convert.ToInt32(Designation.iKandi_Sales_SalesManager), null);
        //        //    //ListItem li = new ListItem();
        //        //    //li.Text = "Vikrant Verma";
        //        //    //li.Value = "5";
        //        //    //ddSales1.Items.Add(li);
        //        //    setVisible(1, ddSales1);

        //        //    //List<User> users = this.UserControllerInstance.GetSalesTeamByBHID(deptId, Convert.ToInt32(Designation.iKandi_Sales_SalesManager));
        //        //}
        //        //else
        //        //{
        //        //    BindListBoxList(ddSales1, Convert.ToInt32(Designation.BIPL_Sales_Manager), null);
        //        //    setVisible(0, ddSales1);
        //        //    //List<User> users = this.UserControllerInstance.GetSalesTeamByBHID(deptId, Convert.ToInt32(Designation.BIPL_Sales_Manager));
        //        //}
        //        
        //    }
        //}
        # endregion
    }

}