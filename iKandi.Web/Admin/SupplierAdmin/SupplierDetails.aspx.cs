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
using System.Text;
using System.Collections.Generic;
using iKandi.BLL;
using System.Text.RegularExpressions;
using System.Web.Caching;
using iKandi.Common;
using System.Globalization;
using iKandi.Web.Components;




namespace iKandi.Web.Admin.SupplierAdmin
{
    public partial class SupplierDetails : System.Web.UI.Page
    {

        public static int SuppliarID
        {
            get;
            set;
        }
        public static string SupplierName
        {
            get;
            set;
        }
        public string FlagEdit//LIST EDIT
        {
            get;
            set;
        }
        public string HideColumn
        {
            get;
            set;
        }
        public static string MasterID_
        {
            get;
            set;
        }
        public static int UserID
        {
            get;
            set;
        }

        string SignatureUploadPath = "";
        AdminController onjadminCon = new AdminController();
        MembershipController objmem = new BLL.MembershipController(ApplicationHelper.LoggedInUser);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetQueryString();
                if (ViewState["VA"] == null)
                {
                    ViewState["VA"] = onjadminCon.GetSuppliarContactDetails_new(4, 0).Tables[0];
                }
                SuppliarID = 0;
                SupplierName = "";
                BindData();
                BIndUserdetails();
                bindcheck();
                UserID = -1;

            }
        }
        public void GetQueryString()
        {
            if (Request.QueryString["FlagEdit"] != null)
            {
                FlagEdit = Request.QueryString["FlagEdit"].ToString();
            }
            else
            {
                FlagEdit = "LIST";
            }
        }

        public void bindcheck()
        {
            DataSet ds = new DataSet();
            DataTable dtgrid = new DataTable();
            DataSet ds_contact = new DataSet();
            int SupplyTypeID_ = Convert.ToInt32(ddlgrouptype.SelectedValue);
            ds = onjadminCon.GetSuppliarDetails_new(1, SupplyTypeID_);

            ddlDeliveryType.SelectedValue = "0";

            if (ds.Tables[0].Rows.Count > 0)
            {
                RepeaterSupplierType.DataSource = ds.Tables[0];
                RepeaterSupplierType.DataBind();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                RepeaterVA.DataSource = ds.Tables[1];
                RepeaterVA.DataBind();
            }

            string[] ArrayIDProcess = null;
            string[] ArrayIDSupllertype = null;

            if (ViewState["Viewstate_ProcessID"] != null)
            {
                ArrayIDProcess = ViewState["Viewstate_ProcessID"].ToString().Split(',');
            }
            if (ViewState["Viewstate_uppliertypeID"] != null)
            {
                ArrayIDSupllertype = ViewState["Viewstate_uppliertypeID"].ToString().Split(',');
            }
            foreach (RepeaterItem item in RepeaterVA.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkVa = (CheckBox)item.FindControl("chkVa");
                    HiddenField hdnVaid = (HiddenField)item.FindControl("hdnVaid");

                    if (chkVa != null && chkVa != null)
                    {
                        if (ArrayIDProcess != null)
                        {
                            foreach (string str in ArrayIDProcess)
                            {
                                if (str == hdnVaid.Value)
                                {
                                    chkVa.Checked = true;
                                }
                            }
                        }
                    }
                }

            }
            foreach (RepeaterItem item in RepeaterSupplierType.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkSupplierType = (CheckBox)item.FindControl("chkSupplierType");
                    HiddenField hdnVaidSupplierType = (HiddenField)item.FindControl("hdnVaidSupplierType");

                    if (chkSupplierType != null && chkSupplierType != null)
                    {
                        if (ArrayIDSupllertype != null)
                        {
                            foreach (string str in ArrayIDSupllertype)
                            {
                                if (str == hdnVaidSupplierType.Value)
                                {
                                    chkSupplierType.Checked = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        public void BindData(int SupplieMasterID = 0)
        {
            hdnSupplieMasterID.Value = SupplieMasterID.ToString();
            DataSet ds = new DataSet();
            DataTable dtgrid = new DataTable();
            DataSet ds_contact = new DataSet();
            int SupplyTypeID_ = Convert.ToInt32(ddlgrouptype.SelectedValue);
            ds = onjadminCon.GetSuppliarDetails_new(1, SupplyTypeID_);
            ds_contact = onjadminCon.GetSuppliarContactDetails_new(2, SuppliarID);

            if (SupplyTypeID_ == 1 || SupplyTypeID_ == 3)
            {
                ddlDeliveryType.Enabled = true;
            }
            else
            {
                ddlDeliveryType.Enabled = false;
            }
            if (SupplyTypeID_ == 1 || SupplyTypeID_ == 2)
            {
                divVA.Style["display"] = "none";
                divtypes.Style["display"] = "block";

                divtypes.Visible = true;
                if (SupplyTypeID_ == 1)
                {
                    //spanSupplyType.Visible = true;
                    lblsuppliercatagory.Text = "Fabric";
                    lblsuppliercatagory2.Text = "Fabric";
                }
                else if (SupplyTypeID_ == 2)
                {
                    //spanSupplyType.Visible = true;
                    lblsuppliercatagory.Text = "Accessory";
                    lblsuppliercatagory2.Text = "Accessory";
                }
            }
            else
            {
                if (SupplyTypeID_ == 3)
                {
                    divVA.Style["display"] = "block";
                    divtypes.Style["display"] = "none";
                    DataSet dsva = new DataSet();
                    DataTable dtva = new DataTable();
                    dtva = (DataTable)ViewState["VA"];

                    grdva.DataSource = dtva;
                    grdva.DataBind();

                }
            }
            if (ViewState["datatable"] != null)
            {
                grdcontactDetails.DataSource = (DataTable)ViewState["datatable"];
                grdcontactDetails.DataBind();
            }
            else
            {
                if (ds_contact.Tables[0].Rows.Count > 0)
                {
                    grdcontactDetails.DataSource = ds_contact.Tables[0];
                    grdcontactDetails.DataBind();
                    ViewState["datatable"] = ds.Tables[0];
                }
                else
                {
                    grdcontactDetails.DataSource = null;
                    grdcontactDetails.DataBind();
                    ViewState["datatable"] = ds_contact.Tables[0];
                }
            }
            if (ds_contact.Tables[1].Rows.Count > 0)
            {
                ddlgrouptype.SelectedValue = ds_contact.Tables[1].Rows[0]["Type"].ToString();
                txtgroupcode.Text = ds_contact.Tables[1].Rows[0]["SupplierName"].ToString();
                txtsuppliarIntial.Text = ds_contact.Tables[1].Rows[0]["SupplierIntial"].ToString();
                txtGstNo.Text = ds_contact.Tables[1].Rows[0]["GstNo"].ToString();   //new line
                txtaddress.Text = ds_contact.Tables[1].Rows[0]["Address"].ToString();
                txtpaymentdays.Text = ds_contact.Tables[1].Rows[0]["PaymentTerms"].ToString();
                txtgrade.Text = ds_contact.Tables[1].Rows[0]["Fabric_Grade"].ToString();

                string SignaturePath = ds_contact.Tables[1].Rows[0]["UploadSignature"].ToString();
                if (SignaturePath != "")
                {
                    hdnSignatureUpload.Value = ds_contact.Tables[1].Rows[0]["UploadSignature"].ToString();
                    if ((System.IO.File.Exists(Constants.PHOTO_FOLDER_PATH + SignaturePath)))
                    {
                        imgSignature.ImageUrl = "~/Uploads/Photo/" + SignaturePath;
                    }
                    else
                    {
                        imgSignature.ImageUrl = "";
                    }
                }
                else
                {
                    imgSignature.ImageUrl = "";
                }
            }
        }

        public void BIndUserdetails()
        {
            string SelectedCheckBoz = "";
            foreach (ListItem item in chklist.Items)
            {
                if (item.Selected)
                {
                    SelectedCheckBoz = SelectedCheckBoz + item.Value + ",";
                }
            }
            SelectedCheckBoz = SelectedCheckBoz.TrimEnd(',');
            HideColumn = SelectedCheckBoz;
            DataSet ds_contact = new DataSet();
            ds_contact = onjadminCon.GetSuppliarContactDetails_new(3, 0, SelectedCheckBoz, Convert.ToInt32(DdlsearchIsActive.SelectedValue), txtsearchinput.Text.Trim());

            if (ds_contact.Tables[0].Rows.Count > 0)
            {
                grdEditView.DataSource = ds_contact.Tables[0];
                grdEditView.DataBind();
            }
            else
            {
                grdEditView.DataSource = null;
                grdEditView.DataBind();
                //grdEditView.Rows[0].Cells[2].Text = "<img src='../../images/sorry.png' alt='No record found' >";//"No Record Found";
            }
        }

        public void BindDataOnLInk(int SupplieMasterID = 0)
        {
            hdnSupplieMasterID.Value = SupplieMasterID.ToString();
            DataSet ds = new DataSet();
            DataTable dtgrid = new DataTable();
            ds = onjadminCon.GetSuppliarDetails(SupplieMasterID);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grdcontactDetails.DataSource = ds.Tables[0];
                grdcontactDetails.DataBind();
                ViewState["datatable"] = ds.Tables[0];
                UserID = -1;
                foreach (DataRow dtRow in ds.Tables[0].Rows)
                {
                    if (dtRow["SupplierLoginID"].ToString() != "-1")
                    {
                        UserID = Convert.ToInt32(dtRow["SupplierLoginID"].ToString());
                    }
                }
            }
            else
            {
                UserID = -1;
                grdcontactDetails.DataSource = null;
                grdcontactDetails.DataBind();
            }

            if (ds.Tables[1].Rows.Count > 0)
            {
                RepeaterVA.DataSource = ds.Tables[1];
                RepeaterVA.DataBind();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                RepeaterSupplierType.DataSource = ds.Tables[2];
                RepeaterSupplierType.DataBind();
            }

            if (ds.Tables[4].Rows.Count > 0)
            {
                ddlgrouptype.SelectedValue = ds.Tables[4].Rows[0]["Type"].ToString();
                txtgroupcode.Text = ds.Tables[4].Rows[0]["SupplierName"].ToString();
                txtsuppliarIntial.Text = ds.Tables[4].Rows[0]["SupplierIntial"].ToString();
                txtGstNo.Text = ds.Tables[4].Rows[0]["GstNo"] == DBNull.Value ? "" : ds.Tables[4].Rows[0]["GstNo"].ToString();//new line
                txtaddress.Text = ds.Tables[4].Rows[0]["Address"].ToString();
                txtpaymentdays.Text = ds.Tables[4].Rows[0]["PaymentTerms"].ToString();
                txtgrade.Text = ds.Tables[4].Rows[0]["Fabric_Grade"].ToString();
                ddlDeliveryType.SelectedValue = ds.Tables[4].Rows[0]["DeliveryType"].ToString();


                string SignaturePath = ds.Tables[4].Rows[0]["UploadSignature"].ToString();
                if (SignaturePath != "")
                {
                    hdnSignatureUpload.Value = ds.Tables[4].Rows[0]["UploadSignature"].ToString();
                    if ((System.IO.File.Exists(Constants.PHOTO_FOLDER_PATH + SignaturePath)))
                    {
                        imgSignature.ImageUrl = "~/Uploads/Photo/" + SignaturePath;
                    }
                    else
                    { imgSignature.ImageUrl = ""; }
                }
                else
                {
                    imgSignature.ImageUrl = "";
                }

                ViewState["Viewstate_ProcessID"] = ds.Tables[4].Rows[0]["Process"].ToString();
                ViewState["Viewstate_uppliertypeID"] = ds.Tables[4].Rows[0]["SupplyType"].ToString();

            }


            string[] ArrayIDProcess = null;
            string[] ArrayIDSupllertype = null;

            if (ViewState["Viewstate_ProcessID"] != null)
            {
                ArrayIDProcess = ViewState["Viewstate_ProcessID"].ToString().Split(',');
            }
            if (ViewState["Viewstate_uppliertypeID"] != null)
            {
                ArrayIDSupllertype = ViewState["Viewstate_uppliertypeID"].ToString().Split(',');
            }
            foreach (RepeaterItem item in RepeaterVA.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkVa = (CheckBox)item.FindControl("chkVa");
                    HiddenField hdnVaid = (HiddenField)item.FindControl("hdnVaid");

                    if (chkVa != null && chkVa != null)
                    {
                        if (ArrayIDProcess != null)
                        {
                            foreach (string str in ArrayIDProcess)
                            {
                                if (str == hdnVaid.Value)
                                {
                                    chkVa.Checked = true;
                                }
                            }
                        }
                    }
                }

            }
            foreach (RepeaterItem item in RepeaterSupplierType.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    CheckBox chkSupplierType = (CheckBox)item.FindControl("chkSupplierType");
                    HiddenField hdnVaidSupplierType = (HiddenField)item.FindControl("hdnVaidSupplierType");

                    if (chkSupplierType != null && chkSupplierType != null)
                    {
                        if (ArrayIDSupllertype != null)
                        {
                            foreach (string str in ArrayIDSupllertype)
                            {
                                if (str == hdnVaidSupplierType.Value)
                                {
                                    chkSupplierType.Checked = true;
                                }
                            }
                        }
                    }
                }

            }
            if (ds.Tables[5].Rows.Count > 0)
            {
                ViewState["VAVALUE"] = ds.Tables[5];
            }
            if (ddlgrouptype.SelectedValue == "1" || ddlgrouptype.SelectedValue == "2")
            {
                divVA.Style["display"] = "none";
                divtypes.Style["display"] = "block";

                divtypes.Visible = true;
                if (ddlgrouptype.SelectedValue == "1")
                {
                    lblsuppliercatagory.Text = "Fabric";
                    lblsuppliercatagory2.Text = "Fabric";
                }
                else if (ddlgrouptype.SelectedValue == "2")
                {
                    lblsuppliercatagory.Text = "Accessory";
                    lblsuppliercatagory2.Text = "Accessory";
                }
            }
            else
            {
                if (ddlgrouptype.SelectedValue == "3")
                {
                    divVA.Style["display"] = "block";
                    divtypes.Style["display"] = "none";
                    DataSet dsva = new DataSet();
                    DataTable dtva = new DataTable();
                    dtva = (DataTable)ViewState["VA"];
                    grdva.DataSource = dtva;
                    grdva.DataBind();
                }
            }
        }
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("contactNo", typeof(int)));
            dt.Columns.Add(new DataColumn("Email", typeof(string)));
            dt.Columns.Add(new DataColumn("PhoneNo", typeof(int)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dt.Rows.Add(dr);
            //dr = dt.NewRow();

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;
            grdcontactDetails.DataSource = dt;
            grdcontactDetails.DataBind();
        }
        public static bool isValidEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        protected void grdcontactDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdcontactDetails.Rows[e.RowIndex];

            HiddenField hdnsupid = (HiddenField)row.FindControl("hdnsupid");
            DataTable dtnew = new DataTable();

            if (ViewState["datatable"] != null)
            {
                dtnew = (DataTable)(ViewState["datatable"]);
                if (hdnsupid.Value != "0")
                {
                    dtnew.Rows.Remove(dtnew.Select("supplier_Details_Id=" + hdnsupid.Value)[0]);
                    //int IsDelete = obj_ProcessController.DeleteHoppmRemarkById(Convert.ToInt32(hdnRiskFabricId.Value), RemarksType);
                }
                else
                {
                    dtnew.Rows.Remove(dtnew.Select("dataTableId=" + hdnsupid.Value)[0]);
                }
                ViewState["datatable"] = dtnew;
            }


            grdcontactDetails.EditIndex = -1;
            grdcontactDetails.DataSource = dtnew;
            grdcontactDetails.DataBind();
            //BindData();

        }
        protected void grdcontactDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Insert")
            {
                TextBox txtRemarkFooter = grdcontactDetails.FooterRow.FindControl("txtRemarkFooter") as TextBox;
                LinkButton abtnAdd = grdcontactDetails.FooterRow.FindControl("abtnAdd") as LinkButton;
                TextBox txtcontactpersonEmpty = grdcontactDetails.FooterRow.FindControl("txtcontactpersonFooter") as TextBox;
                TextBox txtemailfoter = grdcontactDetails.FooterRow.FindControl("txtemailfoter") as TextBox;
                TextBox txtphonenoEmpty = grdcontactDetails.FooterRow.FindControl("txtPhoneNoFooter") as TextBox;
                TextBox txtRemarksFooter = grdcontactDetails.FooterRow.FindControl("txtRemarksFooter") as TextBox;
                HiddenField hdnIDfoter = grdcontactDetails.FooterRow.FindControl("hdnAutoincretmentfoter") as HiddenField;
                DataTable dtnew = new DataTable();

                string PersoneContactNo = string.Empty;
                string email = string.Empty;
                string phoneNo = txtphonenoEmpty.Text.Trim();
                string Remark = txtRemarksFooter.Text.Trim();

                if (txtcontactpersonEmpty != null && txtcontactpersonEmpty.Text == string.Empty)
                {
                    ShowAlert("Enter person contact");
                    return;
                }
                else
                {
                    PersoneContactNo = txtcontactpersonEmpty.Text;
                }
                if (txtcontactpersonEmpty != null && txtcontactpersonEmpty.Text != string.Empty)
                {
                    PersoneContactNo = txtcontactpersonEmpty.Text;
                    bool IsValidEmil = isValidEmail(txtemailfoter.Text);
                    if (IsValidEmil == false)
                    {
                        ShowAlert("Please enter valid email");
                        return;
                    }
                    else
                    {
                        email = txtemailfoter.Text;
                    }
                }

                if (ViewState["datatable"] != null)
                {
                    dtnew = (DataTable)(ViewState["datatable"]);
                    int i = 0;

                    int InCountCheck = 0;
                    for (int x = 0; x < grdcontactDetails.Rows.Count; x++)
                    {
                        if (((TextBox)grdcontactDetails.Rows[x].FindControl("txtemail")).Text.Trim().ToLower() == txtemailfoter.Text.Trim().ToLower())
                        {
                            InCountCheck = InCountCheck + 1;
                        }
                    }
                    if (InCountCheck > 0)
                    {
                        ShowAlert("Contact person and email cannot be duplicate!");
                        return;
                    }
                    for (; i < grdcontactDetails.Rows.Count; i++)
                    {
                        dtnew.Rows[i]["ContactPerson"] = ((TextBox)grdcontactDetails.Rows[i].FindControl("txtcontactperson")).Text;
                        dtnew.Rows[i]["Email"] = ((TextBox)grdcontactDetails.Rows[i].FindControl("txtemail")).Text;
                        dtnew.Rows[i]["PhoneNo"] = ((TextBox)grdcontactDetails.Rows[i].FindControl("txtPhoneNo")).Text;
                        dtnew.Rows[i]["Remarks"] = ((TextBox)grdcontactDetails.Rows[i].FindControl("txtRemarks")).Text;
                    }
                    dtnew.AcceptChanges();
                    dtnew.Rows.Add(i + 1, SuppliarID, PersoneContactNo, email, phoneNo, Remark);
                    ViewState["datatable"] = dtnew;
                }

                BindData();
                string[] ArrayIDProcess = null;
                string[] ArrayIDSupllertype = null;

                if (ViewState["Viewstate_ProcessID"] != null)
                {
                    ArrayIDProcess = ViewState["Viewstate_ProcessID"].ToString().Split(',');
                }
                if (ViewState["Viewstate_uppliertypeID"] != null)
                {
                    ArrayIDSupllertype = ViewState["Viewstate_uppliertypeID"].ToString().Split(',');
                }
                foreach (RepeaterItem item in RepeaterVA.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        CheckBox chkVa = (CheckBox)item.FindControl("chkVa");
                        HiddenField hdnVaid = (HiddenField)item.FindControl("hdnVaid");

                        if (chkVa != null && chkVa != null)
                        {
                            if (ArrayIDProcess != null)
                            {
                                foreach (string str in ArrayIDProcess)
                                {
                                    if (str == hdnVaid.Value)
                                    {
                                        chkVa.Checked = true;
                                    }
                                }
                            }
                        }
                    }
                }
                foreach (RepeaterItem item in RepeaterSupplierType.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        CheckBox chkSupplierType = (CheckBox)item.FindControl("chkSupplierType");
                        HiddenField hdnVaidSupplierType = (HiddenField)item.FindControl("hdnVaidSupplierType");

                        if (chkSupplierType != null && chkSupplierType != null)
                        {
                            if (ArrayIDSupllertype != null)
                            {
                                foreach (string str in ArrayIDSupllertype)
                                {
                                    if (str == hdnVaidSupplierType.Value)
                                    {
                                        chkSupplierType.Checked = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (e.CommandName == "addnew")
            {

                Table tblGrdviewApplet = (Table)grdcontactDetails.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];

                TextBox txtcontactpersonEmpty = (TextBox)rows.FindControl("txtcontactpersonEmpty");
                TextBox txtemailEnpty = (TextBox)rows.FindControl("txtemailEnpty");
                TextBox txtphonenoEmpty = (TextBox)rows.FindControl("txtphonenoEmpty");
                TextBox txtAddressEmpty = (TextBox)rows.FindControl("txtAddressEmpty");
                TextBox txtRemarksEnpty = (TextBox)rows.FindControl("txtRemarksEnpty");
                CheckBox chkUserLoginEmpty = (CheckBox)rows.FindControl("chkUserLoginEmpty");

                DataTable dtnew = new DataTable();
                string PersoneContactNo = txtcontactpersonEmpty.Text.Trim();
                string email = txtemailEnpty.Text.Trim();
                string phoneNo = txtphonenoEmpty.Text.Trim();
                string Remark = txtRemarksEnpty.Text.Trim();
                bool IsLogin = chkUserLoginEmpty.Checked;

                if (ViewState["datatable"] != null)
                {
                    dtnew = (DataTable)(ViewState["datatable"]);
                    int InCountCheck = 0;
                    for (int i = 0; i < grdcontactDetails.Rows.Count; i++)
                    {
                        if (((TextBox)grdcontactDetails.Rows[i].FindControl("Email")).Text.Trim().ToLower() == txtemailEnpty.Text.Trim().ToLower())
                        {
                            InCountCheck = InCountCheck + 1;
                        }
                    }
                    if (InCountCheck > 0)
                    {
                        ShowAlert("Contact person and email cannot be duplicate!");
                        return;
                    }
                    for (int i = 0; i < grdcontactDetails.Rows.Count; i++)
                    {
                        dtnew.Rows[i]["ContactPerson"] = ((TextBox)grdcontactDetails.Rows[i].FindControl("ContactPerson")).Text;
                        dtnew.Rows[i]["Email"] = ((TextBox)grdcontactDetails.Rows[i].FindControl("Email")).Text;
                        dtnew.Rows[i]["PhoneNo"] = ((TextBox)grdcontactDetails.Rows[i].FindControl("PhoneNo")).Text;
                        dtnew.Rows[i]["Remarks"] = ((TextBox)grdcontactDetails.Rows[i].FindControl("Remarks")).Text;
                        dtnew.Rows[i]["IsUserLogin"] = ((CheckBox)grdcontactDetails.Rows[i].FindControl("chkUserloginItem")).Checked;
                    }
                    dtnew.AcceptChanges();
                    //sl = dtnew.Rows.Count;
                    dtnew.Rows.Add(1, SuppliarID, PersoneContactNo, email, phoneNo, Remark, null, IsLogin);
                    ViewState["datatable"] = dtnew;
                }
                BindData();
            }
        }
        protected void grdcontactDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {


        }
        #region "METHOD FOR SHOW ALERT"
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        #endregion


        protected void ddlgrouptype_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtgroupcode.Text = "";
            txtsuppliarIntial.Text = "";
            txtpaymentdays.Text = "";
            txtgrade.Text = "";
            txtaddress.Text = "";
            txtGstNo.Text = "";//new line
            imgSignature.ImageUrl = "";

            ViewState["datatable"] = null;
            SuppliarID = 0;
            SupplierName = "";
            BindData();
            bindcheck();
        }

        private string SaveUploadedFile(FileUpload FileUploadCtrl, String fileName)
        {
            if (FileUploadCtrl.HasFile)
            {
                return FileHelper.SaveFile(FileUploadCtrl.PostedFile.InputStream, FileUploadCtrl.FileName, Constants.PHOTO_FOLDER_PATH, false, fileName);
            }
            else
            {
                return "";
            }
        }


        public void SaveSupplierDetailsAccAndFab()
        {
            // try
            // {
            #region BasicDetails
            string Types = string.Empty;
            string SupplierCode = string.Empty;
            string SupplierName = string.Empty;
            string SupplierIntial = string.Empty;
            string Addresss = string.Empty;
            string GstNo = string.Empty;//new line
            #endregion End

            #region ContactDetails
            string Contact_Type = string.Empty;
            string Conatact_email = string.Empty;
            string Contact_no = string.Empty;
            string Contact_Remarks = string.Empty;
            #endregion End

            #region FabricDetails
            string FabricProcess_Type = string.Empty;
            string Fabric_suppliertype = string.Empty;
            int Fabric__Paymentteram = 0;
            string Fabric_Grade = string.Empty;
            #endregion End

            #region DeliveryTypeDetails
            int DeliveryType = Convert.ToInt32(ddlDeliveryType.SelectedValue);
            #endregion DeliveryTypeDetails

            if (grdcontactDetails.Rows.Count == 0)
            {
                TextBox txtemailfoter = grdcontactDetails.Controls[0].Controls[0].FindControl("txtemailEnpty") as TextBox;
                Conatact_email = txtemailfoter.Text;
            }
            else
            {
                Conatact_email = ((TextBox)grdcontactDetails.FooterRow.FindControl("txtemailfoter")).Text;
            }
            DataTable dtfooter = new DataTable();

            if (ViewState["datatable"] != null)
            {
                dtfooter = (DataTable)(ViewState["datatable"]);
                int InCountCheck = 0;
                for (int i = 0; i < dtfooter.Rows.Count; i++)
                {
                    if (dtfooter.Rows[i]["Email"].ToString().ToLower() == Conatact_email.Trim().ToLower())
                    {
                        InCountCheck = InCountCheck + 1;
                    }
                }
                if (InCountCheck > 0)
                {
                    ShowAlert("Contact person and email cannot be duplicate!");
                    return;
                }
            }
            //End of Code
            if (GetSelectedContact() > 1)
            {
                ShowAlert("Only one Checkbox you can select");
                return;
            }
            else if (GetSelectedContact() <= 0)
            {
                ShowAlert("please select at least one checkbox for supplier details");
                return;
            }
            Types = ddlgrouptype.SelectedValue;
            SupplierName = txtgroupcode.Text.Trim();
            SupplierIntial = txtsuppliarIntial.Text.Trim();
            Addresss = txtaddress.Text.Trim();
            GstNo = txtGstNo.Text.Trim();   //new line


            if (txtpaymentdays.Text.Trim() != "")
            {
                Fabric__Paymentteram = Convert.ToInt32(txtpaymentdays.Text);
            }
            Fabric_Grade = txtgrade.Text.Trim();

            if (SupplierName == "" || SupplierName == string.Empty)
            {
                ShowAlert("Enter Supplier name  first.");
                return;
            }
            if (SupplierIntial == "" || SupplierIntial == string.Empty)
            {
                ShowAlert("Enter Intial Details first.");
                return;
            }
            

            if (SignatureUpload.HasFile)
            {
                if (SignatureUpload.PostedFile.ContentLength > 1000000)
                {
                    ShowAlert("File size can not be greater than 1 mb");
                    return;
                }
                SignatureUploadPath = SaveUploadedFile(SignatureUpload, "");
            }
            else if (hdnSignatureUpload.Value != "")
            {
                SignatureUploadPath = hdnSignatureUpload.Value;
            }
            DataTable dtRecord = new DataTable();

            if (ddlgrouptype.SelectedValue != "3")
            {
                int CountCheck = 0, countCheckVa = 0;
                string CategoryType = "";
                foreach (RepeaterItem item in RepeaterSupplierType.Items)
                {
                    if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                    {
                        CheckBox chkSupplierType = (CheckBox)item.FindControl("chkSupplierType");
                        if (chkSupplierType.Checked)
                            CountCheck += 1;
                    }
                }
                foreach (RepeaterItem item in RepeaterVA.Items)
                {
                    if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
                    {
                        CheckBox chkVa = (CheckBox)item.FindControl("chkVa");
                        if (chkVa.Checked)
                            countCheckVa += 1;
                    }
                }

                if (ddlDeliveryType.SelectedValue == "0" && ddlgrouptype.SelectedValue != "2")
                {
                    ShowAlert("Please Select Delivery Type.");
                    return;
                }
                if (ddlgrouptype.SelectedValue == "1" || ddlgrouptype.SelectedValue == "2")
                {
                    if (ddlgrouptype.SelectedValue == "1")
                        CategoryType = "Fabric";
                    else if (ddlgrouptype.SelectedValue == "2")
                        CategoryType = "Accessories";

                    if (CountCheck == 0)
                    {
                        ShowAlert("You must have to select at least one supply type for " + CategoryType + ".");
                        return;
                    }
                    if (countCheckVa == 0)
                    {
                        ShowAlert("You must have to select at least one " + CategoryType + " category for " + CategoryType + ".");
                        return;
                    }
                }
            }
            else
            {
                if (ddlgrouptype.SelectedValue == "3")
                {
                    if (ValidateVA() == false)
                    {
                        ShowAlert("You must have to select at least one VA.");
                        return;
                    }
                }
            }

            if (ViewState["datatable"] != null)
            {
                dtRecord = (DataTable)ViewState["datatable"];

                if (dtRecord.Rows.Count > 0)
                {
                    foreach (DataRow row in dtRecord.Rows)
                    {
                        foreach (DataColumn col in dtRecord.Columns)
                        {
                            if (row["ContactPerson"].ToString() == string.Empty || row["ContactPerson"] == DBNull.Value)
                            {
                                ShowAlert("Contact person name could not be  blank");
                                return;
                            }
                            else if (row["Email"].ToString() == string.Empty || row["Email"] == DBNull.Value)
                            {
                                ShowAlert("Contact person Email could not be  blank");
                                return;
                            }
                        }
                    }
                }
            }
            if (ddlgrouptype.SelectedValue != "3")
            {
                foreach (RepeaterItem item in RepeaterVA.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        CheckBox chkVa = (CheckBox)item.FindControl("chkVa");
                        HiddenField hdnVaid = (HiddenField)item.FindControl("hdnVaid");
                        if (chkVa != null && hdnVaid != null)
                        {
                            if (chkVa.Checked == true)
                            {
                                FabricProcess_Type += hdnVaid.Value + ",";
                            }
                        }
                    }
                }

                FabricProcess_Type = FabricProcess_Type.TrimEnd(',');
                ViewState["Viewstate_ProcessID"] = FabricProcess_Type;

                foreach (RepeaterItem item in RepeaterSupplierType.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        CheckBox chkSupplierType = (CheckBox)item.FindControl("chkSupplierType");
                        HiddenField hdnVaidSupplierType = (HiddenField)item.FindControl("hdnVaidSupplierType");
                        if (chkSupplierType != null && chkSupplierType != null)
                        {
                            if (chkSupplierType.Checked == true)
                            {
                                Fabric_suppliertype += hdnVaidSupplierType.Value + ",";
                            }
                        }
                    }
                }
                Fabric_suppliertype = Fabric_suppliertype.TrimEnd(',');
                ViewState["Viewstate_uppliertypeID"] = Fabric_suppliertype;
            }

            if (AvoidDuplicate() > 0)
            {
                ShowAlert("Contact person and email cannot be duplicate!");
                return;
            }
            int MasterID = 0;
            int results = 0;

            foreach (GridViewRow row in grdcontactDetails.Rows)
            {
                TextBox txtcontactperson = (TextBox)row.FindControl("txtcontactperson");
                TextBox txtemail = (TextBox)row.FindControl("txtemail");
                TextBox txtPhoneNo = (TextBox)row.FindControl("txtPhoneNo");
                TextBox txtRemarks = (TextBox)row.FindControl("txtRemarks");

                Contact_Type = txtcontactperson.Text.Trim();
                Conatact_email = txtemail.Text.Trim();
                Contact_no = txtPhoneNo.Text.Trim();
                Contact_Remarks = txtRemarks.Text.Trim();

                if (Contact_Type == "")
                {
                    ShowAlert("Contact Person!");
                    return;
                }
                if (Conatact_email == "")
                {
                    ShowAlert("Email Person!");
                    return;
                }
            }

            if (Convert.ToBoolean(onjadminCon.Check_SupplierType(SupplierName, Fabric_suppliertype, Convert.ToInt32(Types), "SuppliType")) == true)
            {
                ShowAlert("Supply Type Already associate with Quality!");
                return;
            }
            if (Convert.ToBoolean(onjadminCon.Check_SupplierType(SupplierName, FabricProcess_Type, Convert.ToInt32(Types), "CategoryType")) == true)
            {
                ShowAlert("Supply Type Already associate with Quality!");
                return;
            }

            results = onjadminCon.InsertSupplierDetails(Types, SupplierName, SupplierIntial, Addresss, GstNo, Fabric_suppliertype, Fabric__Paymentteram, FabricProcess_Type, 1, Fabric_Grade, SignatureUploadPath, SuppliarID, out  MasterID,DeliveryType);

            if (MasterID > 0)
            {
                if (dtRecord.Rows.Count > 0)
                {
                    int resulldetlet = onjadminCon.deleteSupplierDetails(MasterID);

                    foreach (GridViewRow row in grdcontactDetails.Rows)
                    {
                        TextBox txtcontactperson = (TextBox)row.FindControl("txtcontactperson");
                        TextBox txtemail = (TextBox)row.FindControl("txtemail");
                        TextBox txtPhoneNo = (TextBox)row.FindControl("txtPhoneNo");
                        TextBox txtRemarks = (TextBox)row.FindControl("txtRemarks");
                        CheckBox chkUserloginItem = (CheckBox)row.FindControl("chkUserloginItem");

                        Contact_Type = txtcontactperson.Text.Trim();
                        Conatact_email = txtemail.Text.Trim();
                        Contact_no = txtPhoneNo.Text.Trim();
                        Contact_Remarks = txtRemarks.Text.Trim();

                        if (Contact_Type != "" && Conatact_email != "")
                        {
                            results = onjadminCon.InsertSupplierConactDetailsDetails(MasterID, Contact_Type, Conatact_email, Contact_no, Contact_Remarks, 2, Types, (chkUserloginItem.Checked == true ? 1 : 0));

                            if (chkUserloginItem.Checked)
                            {
                                SaveUser(Conatact_email.ToString(), Contact_Type.ToString(), Contact_no.ToString());
                            }
                        }
                    }
                }
                if (grdcontactDetails.Rows.Count == 0)
                {
                    TextBox txtcontactpersonFooter = grdcontactDetails.Controls[0].Controls[0].FindControl("txtcontactpersonEmpty") as TextBox;
                    TextBox txtemailfoter = grdcontactDetails.Controls[0].Controls[0].FindControl("txtemailEnpty") as TextBox;
                    TextBox txtPhoneNoFooter = grdcontactDetails.Controls[0].Controls[0].FindControl("txtphonenoEmpty") as TextBox;
                    TextBox txtRemarksFooter = grdcontactDetails.Controls[0].Controls[0].FindControl("txtRemarksEnpty") as TextBox;
                    CheckBox chkUserLoginEmpty = grdcontactDetails.Controls[0].Controls[0].FindControl("chkUserLoginEmpty") as CheckBox;
                    if (txtcontactpersonFooter != null && txtemailfoter != null && txtPhoneNoFooter != null && txtRemarksFooter != null)
                    {
                        Contact_Type = txtcontactpersonFooter.Text.Trim();
                        Conatact_email = txtemailfoter.Text.Trim();
                        Contact_no = txtPhoneNoFooter.Text.Trim();
                        Contact_Remarks = txtRemarksFooter.Text.Trim();

                        if (Contact_Type != "" && Conatact_email != "")
                        {
                            results = onjadminCon.InsertSupplierConactDetailsDetails(MasterID, Contact_Type, Conatact_email, Contact_no, Contact_Remarks, 2, Types, (chkUserLoginEmpty.Checked == true ? 1 : 0));
                            if (chkUserLoginEmpty.Checked)
                            {
                                SaveUser(txtemailfoter.Text.ToString(), txtcontactpersonFooter.Text.ToString(), txtPhoneNoFooter.Text.ToString());
                            }
                        }
                    }
                }
                else
                {
                    Contact_Type = ((TextBox)grdcontactDetails.FooterRow.FindControl("txtcontactpersonFooter")).Text;
                    Conatact_email = ((TextBox)grdcontactDetails.FooterRow.FindControl("txtemailfoter")).Text;
                    Contact_no = ((TextBox)grdcontactDetails.FooterRow.FindControl("txtPhoneNoFooter")).Text;
                    Contact_Remarks = ((TextBox)grdcontactDetails.FooterRow.FindControl("txtRemarksFooter")).Text;
                    CheckBox chkUserlogfoter = ((CheckBox)grdcontactDetails.FooterRow.FindControl("chkUserlogfoter"));

                    if (Contact_Type != "" && Conatact_email != "")
                    {
                        results = onjadminCon.InsertSupplierConactDetailsDetails(MasterID, Contact_Type, Conatact_email, Contact_no, Contact_Remarks, 2, Types, (chkUserlogfoter.Checked == true ? 1 : 0));
                        if (chkUserlogfoter.Checked)
                        {
                            SaveUser(Conatact_email.Trim(), Contact_Type.Trim(), Contact_no.Trim());
                        }
                    }
                }
                if (ddlgrouptype.SelectedValue == "3")
                {
                    foreach (GridViewRow gvr in grdva.Rows)
                    {
                        HiddenField hdnvaid = (HiddenField)gvr.FindControl("hdnvaid");
                        CheckBox chkva = (CheckBox)gvr.FindControl("chkva");
                        if (chkva.Checked)
                        {
                            results = onjadminCon.InsertSupplierConactDetailsDetailsVA(MasterID, Convert.ToInt32(hdnvaid.Value), 1);
                        }
                        else
                        {
                            results = onjadminCon.InsertSupplierConactDetailsDetailsVA(MasterID, Convert.ToInt32(hdnvaid.Value), 2);
                        }
                    }
                }

                if (results > 0 || results == -1)
                {
                    ViewState["datatable"] = null;
                    ViewState["Viewstate_uppliertypeID"] = null;
                    ViewState["Viewstate_ProcessID"] = null;

                    ddlgrouptype.SelectedValue = "2";
                    txtgroupcode.Text = "";
                    txtsuppliarIntial.Text = "";
                    txtpaymentdays.Text = "";
                    txtgrade.Text = "";
                    txtaddress.Text = "";
                    txtGstNo.Text = ""; //new line
                    imgSignature.ImageUrl = "";
                    grdcontactDetails.DataSource = null;
                    grdcontactDetails.DataBind();
                    SuppliarID = 0;
                    BindData();
                    BIndUserdetails();
                    bindcheck();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:myFunction();", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:showalert('" + "Supplier name and Supplier Initials already exists.please try another" + "');", true);
                return;
            }
            //}
            //  catch (Exception ex)
            // {
            //ShowAlert(ex.ToString());
            // }
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            SaveSupplierDetailsAccAndFab();
        }
        public bool ValidateVA()
        {
            int iCount = 0;
            foreach (GridViewRow gvr in grdva.Rows)
            {
                HiddenField hdnvaid = (HiddenField)gvr.FindControl("hdnvaid");
                CheckBox chkva = (CheckBox)gvr.FindControl("chkva");
                if (chkva.Checked)
                {
                    iCount = iCount + 1;
                }
            }
            if (iCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void rptedit_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                LinkButton abtnAdd = (LinkButton)e.Item.FindControl("abtnAdd");
                HiddenField hdnprocessId = (HiddenField)e.Item.FindControl("hdnprocessId");
                HiddenField hdnSupplyType = (HiddenField)e.Item.FindControl("hdnSupplyType");
                if (hdnprocessId != null && hdnprocessId.Value != "")
                {
                    string[] ArrayIDProcess;
                    string[] ArrayIDSupllertype;

                    if (ViewState["Viewstate_ProcessID"] != null)
                    {
                        ArrayIDProcess = ViewState["Viewstate_ProcessID"].ToString().Split(',');
                    }
                    else
                    {
                        ArrayIDProcess = hdnprocessId.Value.Split(',');
                    }

                    if (ViewState["Viewstate_uppliertypeID"] != null)
                    {
                        ArrayIDSupllertype = ViewState["Viewstate_uppliertypeID"].ToString().Split(',');
                    }
                    else
                    {
                        ArrayIDSupllertype = hdnSupplyType.Value.Split(',');
                    }
                    foreach (RepeaterItem item in RepeaterVA.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            CheckBox chkVa = (CheckBox)item.FindControl("chkVa");
                            HiddenField hdnVaid = (HiddenField)item.FindControl("hdnVaid");

                            if (chkVa != null && chkVa != null)
                            {
                                foreach (string str in ArrayIDProcess)
                                {
                                    if (str == hdnVaid.Value)
                                    {
                                        chkVa.Checked = true;
                                    }
                                }
                            }
                        }
                    }
                    foreach (RepeaterItem item in RepeaterSupplierType.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            CheckBox chkSupplierType = (CheckBox)item.FindControl("chkSupplierType");
                            HiddenField hdnVaidSupplierType = (HiddenField)item.FindControl("hdnVaidSupplierType");

                            if (chkSupplierType != null && chkSupplierType != null)
                            {
                                foreach (string str in ArrayIDSupllertype)
                                {
                                    if (str == hdnVaidSupplierType.Value)
                                    {
                                        chkSupplierType.Checked = true;
                                    }
                                }
                            }
                        }

                    }
                }
            }
        }
        protected void grdEditView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            BIndUserdetails();
            GridViewRow gvr = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            int rowIndex = gvr.RowIndex;
            Label lblsupplierName = (Label)grdEditView.Rows[rowIndex].FindControl("lblsupplierName");
            if (!string.IsNullOrEmpty(lblsupplierName.Text))
            {
                SupplierName = lblsupplierName.Text;
            }
            foreach (GridViewRow row in grdEditView.Rows)
            {
                row.BackColor = row.RowIndex.Equals(rowIndex) ? System.Drawing.ColorTranslator.FromHtml("#FAFCCA") : System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
            }

            if (e.CommandName == "View")
            {

                string strProceesID = string.Empty;
                string SupplieTypeID = string.Empty;
                Label lblSuppllerInitials = (Label)grdEditView.Rows[rowIndex].FindControl("lblSuppllerInitials");
                Label lblGstNo = (Label)grdEditView.Rows[rowIndex].FindControl("lblGstNo"); //new line
                HiddenField hdnMasterID = (HiddenField)grdEditView.Rows[rowIndex].FindControl("hdnMasterID");                

                hdnsupplierInitinal.Value = lblSuppllerInitials.Text;                
                foreach (RepeaterItem item in RepeaterVA.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        CheckBox chkVa = (CheckBox)item.FindControl("chkVa");
                        HiddenField hdnVaid = (HiddenField)item.FindControl("hdnVaid");
                        if (chkVa != null && hdnVaid != null)
                        {
                            if (chkVa.Checked == true)
                            {
                                strProceesID += hdnVaid.Value + ",";

                            }
                        }
                    }

                }
                strProceesID = strProceesID.TrimEnd(',');
                ViewState["Viewstate_ProcessID"] = strProceesID;

                foreach (RepeaterItem item in RepeaterSupplierType.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        CheckBox chkSupplierType = (CheckBox)item.FindControl("chkSupplierType");
                        HiddenField hdnVaidSupplierType = (HiddenField)item.FindControl("hdnVaidSupplierType");
                        if (chkSupplierType != null && chkSupplierType != null)
                        {
                            if (chkSupplierType.Checked == true)
                            {
                                SupplieTypeID += hdnVaidSupplierType.Value + ",";

                            }
                        }
                    }

                }
                SupplieTypeID = SupplieTypeID.TrimEnd(',');
                ViewState["Viewstate_uppliertypeID"] = SupplieTypeID;
                int SupplieMasterID = Convert.ToInt32(e.CommandArgument);
                if (SupplieMasterID != 0)
                {
                    SuppliarID = SupplieMasterID;
                }
                BindDataOnLInk(SupplieMasterID);

            }
            if (e.CommandName == "Delete")
            {
                DataTable dt = onjadminCon.SetActiveSupplierMaster(5, Convert.ToInt32(e.CommandArgument), 0);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["Result"].ToString() == "EXISTS")
                    {
                        ShowAlert("Supplier already in use cannot be delete");
                        return;
                    }
                    else
                    {
                        Response.Redirect("~/Admin/SupplierAdmin/SupplierDetails.aspx");
                    }

                }
            }
        }

        protected void DdlIsActive_Change(object sender, EventArgs e)
        {
            GridViewRow row = (GridViewRow)(((Control)sender).NamingContainer);
            HiddenField MasterId = (HiddenField)row.FindControl("hdnMasterID");
            DropDownList DdlIsActive = (DropDownList)row.FindControl("DdlIsActive");

            DataTable dt = onjadminCon.SetActiveSupplierMaster(5, Convert.ToInt32(MasterId.Value), Convert.ToInt32(DdlIsActive.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Result"].ToString() == "EXISTS")
                {
                    ShowAlert("Supplier already in use cannot be change");
                    return;
                }
                else
                {
                    BIndUserdetails();
                }

            }
        }

        public static void DisableLinkButton(LinkButton linkButton)
        {
            linkButton.Attributes.Remove("href");
            linkButton.Attributes.CssStyle[HtmlTextWriterStyle.Color] = "gray";
            linkButton.Attributes.CssStyle[HtmlTextWriterStyle.Cursor] = "default";
            if (linkButton.Enabled != false)
            {
                linkButton.Enabled = false;
            }

            if (linkButton.OnClientClick != null)
            {
                linkButton.OnClientClick = null;
            }
        }

        
        protected void grdEditView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                grdEditView.Columns[4].Visible = true;
                grdEditView.Columns[7].Visible = true;
                grdEditView.Columns[8].Visible = true;

                StringBuilder VName = new StringBuilder();
                VName.Append("<table borer='0' width='100%' class='AddClassSup_Table' cellspan='0' cellpadding='0'>");
                VName.Append("<tr><th style='border-right:1px;'>From To Status</th><th>VA Name</th></tr>");
                VName.Append("</table>");
               
                grdEditView.Columns[8].HeaderText = VName.ToString();
                grdEditView.Columns[8].HeaderStyle.CssClass = "SupllierTD";

                //grdEditView.Columns[9].Visible = true;

                if (HideColumn == "1,2" || HideColumn == "1" || HideColumn == "2")
                {
                    grdEditView.Columns[8].Visible = false;
                    //grdEditView.Columns[9].Visible = false;
                }
                else if (HideColumn == "3")
                {
                    grdEditView.Columns[4].Visible = false;
                    grdEditView.Columns[7].Visible = false;
                    grdEditView.Columns[8].Visible = true;                   
                   
                }
                else
                {
                    grdEditView.Columns[4].Visible = true;
                    grdEditView.Columns[7].Visible = true;
                    grdEditView.Columns[8].Visible = true;
                    //grdEditView.Columns[9].Visible = true;
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblProcess = (Label)e.Row.FindControl("lblProcess");
                Label lblSupplyType = (Label)e.Row.FindControl("lblSupplyType");
                HiddenField hdnMasterID = (HiddenField)e.Row.FindControl("hdnMasterID");
                HiddenField hdnfromToStatus = (HiddenField)e.Row.FindControl("hdnfromToStatus");

                Label lblfromtostatus = (Label)e.Row.FindControl("lblfromtostatus");
                Label lblvaname = (Label)e.Row.FindControl("lblvaname");
                Label lblType = (Label)e.Row.FindControl("lblType");

                LinkButton lnkdele = (LinkButton)e.Row.FindControl("lnkdele");

                DropDownList ddlIsActive = (DropDownList)e.Row.FindControl("DdlIsActive");
                HiddenField hdnIsActive = (HiddenField)e.Row.FindControl("hdnIsActive");
                if (hdnIsActive.Value == "True")
                {
                    ddlIsActive.SelectedValue = "1";
                }
                else
                {
                    ddlIsActive.SelectedValue = "0";
                }


                DataSet ds = new DataSet();
                ds = onjadminCon.GetProccesNameWithSuppleType(lblProcess.Text, lblSupplyType.Text);
                DataTable dtprocess = new DataTable();
                DataTable dtSupplieType = new DataTable();
                dtprocess = ds.Tables[0];
                dtSupplieType = ds.Tables[1];
                // e.Row.Cells[0].Visible = false;

                DataTable dst = onjadminCon.SetActiveSupplierMaster(6, Convert.ToInt32(hdnMasterID.Value), 0);
                if (dst.Rows.Count > 0)
                {
                    if (dst.Rows[0]["Result"].ToString() == "EXISTS")
                    {
                        e.Row.Cells[11].BackColor = System.Drawing.ColorTranslator.FromHtml("#f1eded");
                        lnkdele.Enabled = false;
                        lnkdele.ToolTip = "Supplier already in use cannot be delete";
                        lnkdele.Attributes.Remove("onclick");
                        ddlIsActive.Enabled = false;

                        e.Row.Cells[11].ToolTip = "Supplier already in use cannot be change";
                        lnkdele.Attributes.Add("OnClientClick", "return alert('Cannot change this supplier already using in Accesories.!')");
                        //lnkDelete.Attributes.Add("OnClientClick", "false");
                        //lnkDelete.Attributes.Add("disabled", "disabled");
                        //lnkDelete.Visible = false;
                        DisableLinkButton(lnkdele);
                    }
                }

                if (dtprocess.Rows.Count > 0)
                {

                    string str1 = string.Empty;
                    foreach (DataRow row in dtprocess.Rows)
                    {
                        str1 += row["ValueAdditionName"].ToString() + ",";
                    }
                    lblProcess.Text = str1.TrimEnd(',');

                    if (lblProcess != null && lblProcess.Text != "")
                    {
                        string[] ss = lblProcess.Text.Replace("Lbls,Tgs,Pcg & Ins.", "Lbls Tgs Pcg & Ins.").Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                        StringBuilder builder = new StringBuilder();
                        int icountpro = 1;
                        foreach (string a in ss)
                        {
                            
                            if (icountpro == ss.Length)
                                builder.Append("<DIV style='min-height: 18px;margin-top: 10px;'>").Append(a == "Lbls Tgs Pcg & Ins." ? "Lbls,Tgs,Pcg & Ins." : a).Append("</DIV>");
                            else
                                builder.Append("<DIV style='border-bottom: 1px solid #dad5d5;min-height:18px;margin-top: 10px;'>").Append(a == "Lbls Tgs Pcg & Ins." ? "Lbls,Tgs,Pcg & Ins." : a).Append("</DIV>");

                            icountpro += 1;
                        }
                        lblProcess.Text = builder.ToString();
                    }

                }

                if (dtSupplieType.Rows.Count > 0)
                {
                    string str1 = string.Empty;
                    foreach (DataRow row in dtSupplieType.Rows)
                    {
                        str1 += row["Name"].ToString() + ",";
                    }
                    lblSupplyType.Text = str1.TrimEnd(',');
                }

                if (lblType.Text == "VA")
                {
                    DataTable dt = onjadminCon.GetSuppliarContactDetails_new(4, Convert.ToInt32(hdnMasterID.Value)).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        string Status = string.Empty;                      
                        StringBuilder StatusName = new StringBuilder();                        
                        int flag = 0;
                        int Duplicate = 0;
                        StatusName.Append("<table borer='0' class='AddClassSup_Table' cellspan='0' cellpadding='0'>");
                        for(int icount = 0; icount < dt.Rows.Count; icount ++)
                        {
                            if (icount > 0)
                            {
                                string CurrentStatus = dt.Rows[icount]["StatusName"].ToString();
                                string PrevStatus = dt.Rows[icount - 1]["StatusName"].ToString();
                                if (CurrentStatus == PrevStatus)
                                {
                                    Duplicate = Duplicate + 1;
                                    flag = flag + 1;
                                }
                                else
                                {
                                    Duplicate = 0;
                                    flag = 0;
                                }
                            }
                            if (Convert.ToInt32(dt.Rows[icount]["StatusCount"]) > 1)
                            {
                                if ((Duplicate == 0) && (flag == 0))
                                {
                                    StatusName.Append("<tr>");
                                    StatusName.Append("<td rowspan='" + dt.Rows[icount]["StatusCount"].ToString() + "'>" + dt.Rows[icount]["StatusName"].ToString() + "</td>");
                                    StatusName.Append("<td>" + dt.Rows[icount]["ValueAddtionName"].ToString() + "</td>");
                                    StatusName.Append("</tr>");
                                }                                
                                else
                                {
                                    StatusName.Append("<tr>");
                                    StatusName.Append("<td>" + dt.Rows[icount]["ValueAddtionName"].ToString() + "</td>");
                                    StatusName.Append("</tr>");
                                }
                            }
                            else
                            {
                                StatusName.Append("<tr>");
                                StatusName.Append("<td rowspan='" + dt.Rows[icount]["StatusCount"].ToString() + "'>" + dt.Rows[icount]["StatusName"].ToString() + "</td>");
                                StatusName.Append("<td>" + dt.Rows[icount]["ValueAddtionName"].ToString() + "</td>");
                                StatusName.Append("</tr>");
                            }    
                           
                        }
                        StatusName.Append("</table>");
                        e.Row.Cells[8].Text = StatusName.ToString();
                        e.Row.Cells[8].Attributes.Add("class","SupllierTD");  
                    }
                }
            }
        }

        public void HideShowControl(int id)
        {
            Response.Redirect("~/Admin/SupplierAdmin/SupplierDetails.aspx");//reset all control      
        }
        protected void txtgroupcode_TextChanged1(object sender, EventArgs e)
        {
            //string Types = "";
            //if (ddlgrouptype.SelectedValue == "1")
            //{
            //    Types = "Fabric";
            //}
            //if (ddlgrouptype.SelectedValue == "2")
            //{
            //    Types = "Accessoires";
            //}
            //if (ddlgrouptype.SelectedValue == "3")
            //{
            //    Types = "VA";
            //}
        }

        protected void grdva_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnvaid = (HiddenField)e.Row.FindControl("hdnvaid");
                CheckBox chkva = (CheckBox)e.Row.FindControl("chkva");
                if (ViewState["VAVALUE"] != null)
                {
                    DataTable dt = (DataTable)ViewState["VAVALUE"];
                    DataRow[] result = dt.Select("ValueAdditionID=" + hdnvaid.Value);
                    foreach (DataRow row in result)
                    {
                        if (hdnvaid.Value == row["ValueAdditionID"].ToString())
                        {
                            chkva.Checked = true;
                        }
                    }
                }

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            BIndUserdetails();
        }
        protected void grdva_DataBound(object sender, EventArgs e)
        {
            for (int i = grdva.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdva.Rows[i];
                GridViewRow previousRow = grdva.Rows[i - 1];

                Label lblFromStatus_ToStatus = (Label)row.Cells[0].FindControl("lblstatusname");
                Label lblPreviousFromStatus_ToStatus = (Label)previousRow.Cells[0].FindControl("lblstatusname");
                if (lblFromStatus_ToStatus.Text == lblPreviousFromStatus_ToStatus.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                }
            }
        }
        private int AvoidDuplicate()
        {
            int CheckDuplicateCount = 0;
            for (int i = 0; i < grdcontactDetails.Rows.Count; i++)
            {
                TextBox txtcontactperson = grdcontactDetails.Rows[i].FindControl("txtcontactperson") as TextBox;
                string ConatactName = txtcontactperson.Text.ToString().Trim();

                TextBox txtemail = grdcontactDetails.Rows[i].FindControl("txtemail") as TextBox;
                string ConatctEmail = txtemail.Text.ToString().Trim();

                if (ConatactName != "" && ConatctEmail != "")
                {
                    string Contact_Type_ = ((TextBox)grdcontactDetails.FooterRow.FindControl("txtcontactpersonFooter")).Text;
                    string Conatact_email_ = ((TextBox)grdcontactDetails.FooterRow.FindControl("txtemailfoter")).Text;
                    if (!string.IsNullOrEmpty(Contact_Type_) && !string.IsNullOrEmpty(Conatact_email_))
                    {
                        if (ConatactName != Contact_Type_ && ConatctEmail != Conatact_email_)
                        {
                            // grdcontactDetails.Rows[i].Visible = true;
                        }
                        else
                        {
                            CheckDuplicateCount += 1;
                            break;
                        }
                    }

                    for (int j = i + 1; j < grdcontactDetails.Rows.Count; j++)
                    {
                        TextBox txtnewcontactperson = grdcontactDetails.Rows[j].FindControl("txtcontactperson") as TextBox;
                        string newvaluecontactperson = txtnewcontactperson.Text.ToString().Trim();

                        TextBox txtnewemail = grdcontactDetails.Rows[j].FindControl("txtemail") as TextBox;
                        string newvaluetxtnewemail = txtnewemail.Text.ToString().Trim();

                        if (ConatactName == newvaluecontactperson && ConatctEmail == newvaluetxtnewemail)
                        {
                            CheckDuplicateCount += 1;
                            break;
                        }
                    }
                }
            }
            return CheckDuplicateCount;
        }


        public int GetSelectedContact()
        {
            int counts = 0;
            if (grdcontactDetails.Rows.Count == 0)
            {
               
                CheckBox chkUserLoginEmpty = grdcontactDetails.Controls[0].Controls[0].FindControl("chkUserLoginEmpty") as CheckBox;
                //CheckBox chkUserLoginEmpty = grdcontactDetails.FooterRow.FindControl("chkUserLoginEmpty") as CheckBox;
                if (chkUserLoginEmpty.Checked == false)
                {
                    //ShowAlert("Select atleast one check box");
                }
                else
                {
                    counts += 1;
                }
            }
            else
            {
                foreach (GridViewRow row in grdcontactDetails.Rows)
                {
                    CheckBox chkUserloginItem = (CheckBox)row.FindControl("chkUserloginItem");

                    if (chkUserloginItem.Checked)
                    {
                        counts += 1;
                    }
                }
            }
            return counts;

        }
        private void SaveUser(string SupplierEmail, string SupplierContactName, string phoneNo)
        {
            UserID = UserID == 0 ? -1 : UserID;
            string fileID = string.Empty;
            User user = null;

            if (UserID == -1)
                user = new User();
            else
                user = objmem.GetUser(UserID);

            user.error_msg = "sucess";
            user.UserID = UserID;
            user.Address = txtaddress.Text.Trim();
            user.IsStaff = 0;
            user.Anniversary = DateTime.MinValue;
            user.BirthDay = DateTime.MinValue;
            user.EmpCardNo = 0;
            user.DesignationID = 143;
            user.Email = SupplierEmail;
            user.DesignerCode = "S";
            user.Company = (iKandi.Common.Company)Convert.ToInt32(2);
            user.PhotoPath = "";

            //end
            string[] SupplierNamesDetails = SupplierContactName.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            user.FirstName = SupplierNamesDetails[0].ToString();
            user.LastName = SupplierNamesDetails.Length > 1 ? SupplierNamesDetails[1].ToString() : "";
            user.iGlobalAcc = 1;
            user.ManagerID = -1;
            user.PrimaryGroupID = 49;
            user.Mobile = phoneNo;
            user.HomePhone = phoneNo;
            user.PersonalEmail = SupplierEmail;
            user.SignPath = SignatureUploadPath;
            objmem.SaveUser(user);
            if (user.error_msg != "sucess")
            {
                Page page = HttpContext.Current.Handler as Page;
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + user.error_msg + "');", true);
                return;
            }
        }
    }

}
