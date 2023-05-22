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
using System.Collections.Generic;
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;



namespace iKandi.Web.UserControls.Lists
{
    public partial class ManageCategories : System.Web.UI.UserControl
    {
        IList<iKandi.Common.Category> categories = new List<iKandi.Common.Category>();
        int TotalRowCount = 0;
        int UserId = -1;
        string CountConstruction = "";

        AdminController adminController = new AdminController();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            HndUserid.Value = UserId.ToString();

            tbCategoryCode.Attributes.Add("readonly", "readonly");
            string QueryString = string.Empty;
            if (!IsPostBack)
            {
                hdnUserId.Value = "0";
                BindDropDownLists();
                BindAdminUnit();
                BindGridView();
                addpnl.Visible = false;
                hlnkHistory.Text = "Show History";
            }
        }


        private void BindGridView()
        {
            Category searchCriteria = new Category();
            searchCriteria.Type = Convert.ToInt32(ddlTypes.SelectedValue);
            searchCriteria.CategoryID = Convert.ToInt32(ddlParentCategories.SelectedValue);

            categories = adminController.GetAllCategories_New(searchCriteria);
            gvCategories.DataSource = categories;
            gvCategories.DataBind();
        }

        private void BindgvCategory()
        {
            Category searchCriteria = new Category();
            searchCriteria.Type = Convert.ToInt32(ddlTypes.SelectedValue);
            searchCriteria.CategoryID = Convert.ToInt32(ddlParentCategories.SelectedValue);
            searchCriteria.LoggedInUser = 0;
            if (hdnUserId.Value.ToString() == "1")
            {
                searchCriteria.LoggedInUser = ApplicationHelper.LoggedInUser.UserData.UserID;
            }
            Session["CategorySearchCriteria"] = searchCriteria;
            gvCategories.DataBind();

            if (ViewState["CategoryID"] != null)
            {
                foreach (GridViewRow gr in gvCategories.Rows)
                {
                    if (ViewState["CategoryID"].ToString() == gvCategories.DataKeys[gr.RowIndex].Value.ToString())
                    {
                        gvCategories.SelectedIndex = gr.RowIndex;
                    }
                }
            }
            else
            {
                gvCategories.SelectedIndex = -1;
            }
            addpnl.Visible = false;
            gvCategories.Visible = true;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvCategories.EditIndex = -1;
            gvCategories.PageIndex = 0;
            addpnl.Visible = false;
            BindGridView();
        }

        protected void ddlTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDDLParentCategories();
            if (ddlTypes.SelectedValue == "1")
                hlnkHistory.Text = "Show Fabric History";

            else if (ddlTypes.SelectedValue == "2")
                hlnkHistory.Text = "Show Accessory History";
            else
                hlnkHistory.Text = "Show History";

        }

        private void BindAdminUnit()
        {
            DataSet dsUnit = adminController.GetAllAdminUnit(ddlTypes.SelectedValue);
            if (dsUnit.Tables[0].Rows.Count > 0)
            {
                ViewState["dsUnit"] = dsUnit;
                ddlUnit.DataSource = dsUnit;
                ddlUnit.DataTextField = "UnitName";
                ddlUnit.DataValueField = "GroupUnitID";
                ddlUnit.DataBind();
            }
        }

        private void BindDropDownLists()
        {
            BindDDLTypes();
            BindDDLParentCategories();
        }

        private void BindDDLParentCategories()
        {
            ddlParentCategories.Items.Clear();
            DropdownHelper.BindCategories_New(ddlParentCategories as ListControl, Convert.ToInt32(ddlTypes.SelectedValue));
            ddlParentCategories.Items.Insert(0, new ListItem("All", "-1"));
        }

        private void BindDDLTypes()
        {
            ddlTypes.Items.Clear();
            //ddlTypes.Items.Insert(0, new ListItem("All", "-1"));
            ddlTypes.Items.Insert(0, new ListItem("Fabric", "1"));
            ddlTypes.Items.Insert(1, new ListItem("Accessory", "2"));
        }

        protected void gvCategories_RodataBound(object sender, GridViewRowEventArgs e)
        {           
            #region header            
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (Convert.ToInt32(ddlTypes.SelectedValue) == 1)
                {
                    //Code Updated By Girish on 2023-04-02 Start   -- IF any column added or removed need to update the code
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[24].Visible = false;
                    e.Row.Cells[25].Visible = false;
                    e.Row.Cells[26].Visible = false;

                    e.Row.Cells[6].Visible = true;
                    e.Row.Cells[7].Visible = true;
                    e.Row.Cells[10].Visible = true;
                    e.Row.Cells[11].Visible = true;
                    e.Row.Cells[12].Visible = true;
                    e.Row.Cells[13].Visible = true;
                    e.Row.Cells[14].Visible = true;
                    e.Row.Cells[15].Visible = true;
                    e.Row.Cells[16].Visible = true;
                    e.Row.Cells[17].Visible = true;
                    e.Row.Cells[18].Visible = true;
                    e.Row.Cells[19].Visible = true;
                    e.Row.Cells[20].Visible = true;
                    e.Row.Cells[21].Visible = true;                    

                    HtmlTableCell thGroupDescription = (HtmlTableCell)e.Row.FindControl("thGroupDescription");
                    HtmlTableCell thETADays = (HtmlTableCell)e.Row.FindControl("thETADays");
                    HtmlTableCell thGeneralDescription = (HtmlTableCell)e.Row.FindControl("thGeneralDescription");

                    thGroupDescription.Attributes.Add("colspan", "3");
                    thETADays.Attributes.Add("colspan", "16");
                    thGeneralDescription.Attributes.Add("colspan", "5");
                    // End
                }
                else if (Convert.ToInt32(ddlTypes.SelectedValue) == 2)
                {
                    //Code Updated By Girish on 2023-04-02 Start
                    e.Row.Cells[8].Visible = true;
                    e.Row.Cells[9].Visible = true;
                    e.Row.Cells[25].Visible = true;
                    e.Row.Cells[26].Visible = true;

                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[10].Visible = false;
                    e.Row.Cells[11].Visible = false;
                    e.Row.Cells[14].Visible = false;
                    e.Row.Cells[15].Visible = false;
                    e.Row.Cells[16].Visible = false;
                    e.Row.Cells[17].Visible = false;
                    e.Row.Cells[18].Visible = false;
                    e.Row.Cells[19].Visible = false;
                    e.Row.Cells[20].Visible = false;
                    e.Row.Cells[21].Visible = false;

                    e.Row.Cells[27].Text = "Finish GST %";                    

                    HtmlTableCell thGroupDescription = (HtmlTableCell)e.Row.FindControl("thGroupDescription");
                    HtmlTableCell thETADays = (HtmlTableCell)e.Row.FindControl("thETADays");
                    HtmlTableCell thGeneralDescription = (HtmlTableCell)e.Row.FindControl("thGeneralDescription");

                    thGroupDescription.Attributes.Add("colspan", "3");
                    thETADays.Attributes.Add("colspan", "6");
                    thGeneralDescription.Attributes.Add("colspan", "7");
                    // End
                }

            }
            #endregion header

            #region EditState
            else if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                TextBox txtCategoryCode = (TextBox)e.Row.FindControl("txtCategoryCode");
                DropDownList ddlUnit = (DropDownList)e.Row.FindControl("ddlUnit");
                DropDownList ddlCANDC = (DropDownList)e.Row.FindControl("ddlCANDC");
                HiddenField hdnUnit = (HiddenField)e.Row.FindControl("hdnUnit");
                HiddenField hdnIsCANDC = (HiddenField)e.Row.FindControl("hdnIsCANDC");
                HiddenField hdnCategoryID = (HiddenField)e.Row.FindControl("hdnCategoryID");

                DataTable dtCC = new DataTable();
                dtCC = adminController.GetFabricCountConstruction(Convert.ToInt32(hdnCategoryID.Value));

                List<String> list = new List<String>();

                foreach (DataRow row in dtCC.Rows)
                    list.Add(row["CountConstruction"].ToString());

                if (list.Contains("") && hdnIsCANDC.Value == "False")
                    ddlCANDC.Enabled = false;

                else
                    ddlCANDC.Enabled = true;

                CountConstruction = dtCC.Rows[0]["CountConstruction"].ToString();

                if (Convert.ToInt32(ddlTypes.SelectedValue) == 1)
                {
                    //Code Updated By Girish on 2023-04-02 Start
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[24].Visible = false;
                    e.Row.Cells[25].Visible = false;
                    e.Row.Cells[26].Visible = false;

                    e.Row.Cells[6].Visible = true;
                    e.Row.Cells[7].Visible = true;
                    e.Row.Cells[10].Visible = true;
                    e.Row.Cells[11].Visible = true;
                    e.Row.Cells[12].Visible = true;
                    e.Row.Cells[13].Visible = true;
                    e.Row.Cells[14].Visible = true;
                    e.Row.Cells[15].Visible = true;
                    e.Row.Cells[16].Visible = true;
                    e.Row.Cells[17].Visible = true;
                    e.Row.Cells[18].Visible = true;
                    e.Row.Cells[19].Visible = true;
                    e.Row.Cells[20].Visible = true;
                    //e.Row.Cells[21].Visible = false;
                    //end

                }
                else if (Convert.ToInt32(ddlTypes.SelectedValue) == 2)
                {
                    //Code Updated By Girish on 2023-04-02 Start
                    e.Row.Cells[8].Visible = true;
                    e.Row.Cells[9].Visible = true;
                    e.Row.Cells[25].Visible = true;
                    e.Row.Cells[26].Visible = true;

                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[10].Visible = false;
                    e.Row.Cells[11].Visible = false;
                    e.Row.Cells[14].Visible = false;
                    e.Row.Cells[15].Visible = false;
                    e.Row.Cells[16].Visible = false;
                    e.Row.Cells[17].Visible = false;
                    e.Row.Cells[18].Visible = false;
                    e.Row.Cells[19].Visible = false;
                    e.Row.Cells[20].Visible = false;
                    e.Row.Cells[21].Visible = false;
                    //end
                }

                DataTable dt = new DataTable();
                dt = adminController.GetApprovedUnit(Convert.ToInt32(ddlTypes.SelectedValue));
                ddlUnit.DataSource = dt;
                ddlUnit.DataTextField = "UnitName";
                ddlUnit.DataValueField = "GroupUnitID";
                ddlUnit.DataBind();
                ddlUnit.SelectedValue = hdnUnit.Value;

                DataTable freezeUnit_dt = adminController.FreezeUnit(Convert.ToInt32(hdnCategoryID.Value), Convert.ToInt32(ddlTypes.SelectedValue));
                if (freezeUnit_dt.Rows.Count > 0)
                    ddlUnit.Enabled = false;

                else
                    ddlUnit.Enabled = true;

                txtCategoryCode.Attributes.Add("readonly", "readonly");

                if (hdnIsCANDC.Value == "True")
                    ddlCANDC.SelectedValue = "1";

                else
                    ddlCANDC.SelectedValue = "0";
            }

            #endregion EditState

            #region DataRow
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnIsCANDC = (HiddenField)e.Row.FindControl("hdnIsCANDC");
                DropDownList ddlCANDC = (DropDownList)e.Row.FindControl("ddlCANDC");
                HiddenField hdncategoryID2 = e.Row.FindControl("hdncategoryID2") as HiddenField;

                if (Convert.ToInt32(ddlTypes.SelectedValue) == 1)
                {
                    //Code Updated By Girish on 2023-04-02 Start
                    e.Row.Cells[8].Visible = false;
                    e.Row.Cells[9].Visible = false;
                    e.Row.Cells[24].Visible = false;
                    e.Row.Cells[25].Visible = false;
                    e.Row.Cells[26].Visible = false;

                    e.Row.Cells[6].Visible = true;
                    e.Row.Cells[7].Visible = true;
                    e.Row.Cells[10].Visible = true;
                    e.Row.Cells[11].Visible = true;
                    e.Row.Cells[12].Visible = true;
                    e.Row.Cells[13].Visible = true;
                    e.Row.Cells[14].Visible = true;
                    e.Row.Cells[15].Visible = true;
                    e.Row.Cells[16].Visible = true;
                    e.Row.Cells[17].Visible = true;
                    e.Row.Cells[18].Visible = true;
                    e.Row.Cells[19].Visible = true;
                    e.Row.Cells[20].Visible = true;
                    e.Row.Cells[21].Visible = true;
                    //end

                }
                else if (Convert.ToInt32(ddlTypes.SelectedValue) == 2)
                {
                    //Code Updated By Girish on 2023-04-02 Start
                    e.Row.Cells[8].Visible = true;
                    e.Row.Cells[9].Visible = true;
                    e.Row.Cells[25].Visible = true;
                    e.Row.Cells[26].Visible = true;

                    e.Row.Cells[6].Visible = false;
                    e.Row.Cells[7].Visible = false;
                    e.Row.Cells[10].Visible = false;
                    e.Row.Cells[11].Visible = false;
                    e.Row.Cells[14].Visible = false;
                    e.Row.Cells[15].Visible = false;
                    e.Row.Cells[16].Visible = false;
                    e.Row.Cells[17].Visible = false;
                    e.Row.Cells[18].Visible = false;
                    e.Row.Cells[19].Visible = false;
                    e.Row.Cells[20].Visible = false;
                    e.Row.Cells[21].Visible = false;
                    //end
                }

            }
            #endregion DataRow
        }

        protected void gvCategories_PageIndexChanged(object sender, EventArgs e)
        {
            string QueryString = string.Empty;
            if (Request.QueryString["qst"] == null)
            {
                Button btnPrint = (Button)this.FindControl("btnPrint");
                QueryString = "?qst=" + ddlTypes.SelectedValue;
                QueryString += "&qspc=" + ddlParentCategories.SelectedValue;
                QueryString += "&qscp=" + gvCategories.PageIndex;
                btnPrint.Attributes.Add("onclick", "PrintPDFQueryString('','','','" + QueryString + "')");
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            gvCategories.EditIndex = -1;
            addpnl.Visible = true;
            BindControls();
            BindGridView();

            BindAdminUnit();

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if ((ddlUnit.Text == "-1") ||(ddlUnit.Text == "Select Unit"))
            {
                ShowAlert("Unit is required");
                return;
            }
            hdnUserId.Value = "1";
            gvCategories.PageIndex = 0;
            gvCategories.EditIndex = -1;
            CreateCategory();
            BindDDLParentCategories();
        }

        private void Bindgvcategoryredata()
        {
            categories = adminController.GetAllCategories_New_Submit(UserId, out TotalRowCount);
            gvCategories.DataBind();
        }

        private void BindControls()
        {
            ddlCategoryType.Items.Clear();

            DropdownHelper.BindCategoryTypesNew(ddlCategoryType as ListControl);

            ddlCategoryType.SelectedValue = ddlTypes.SelectedValue;

            BindDDLParentCategories();

            if (ddlCategoryType.SelectedValue == "1")
            {
                tdwastageMeg.Visible = false;
                tdGriegeGst_header.Visible = false;
                tdProcessGst_header.Visible = false;
                tdGstNoMeg.InnerHtml = "GST %<span class='da_astrx_mand'>*</span>";

                tdwastagetextbox.Visible = false;
                tdGriegeGST.Visible = false;
                tdProcessGST.Visible = false;
            }
            else if (ddlCategoryType.SelectedValue == "2")
            {
                tdwastageMeg.Visible = true;
                tdGriegeGst_header.Visible = true;
                tdProcessGst_header.Visible = true;
                tdGstNoMeg.InnerHtml = "Finish GST %<span class='da_astrx_mand'>*</span>";

                tdwastagetextbox.Visible = true;
                tdGriegeGST.Visible = true;
                tdProcessGST.Visible = true;

            }

            tbCategoryName.Text = "";
            tbCategoryCode.Text = string.Empty;
            ddlCANDC1.SelectedValue = "0";
            ddlUnit.SelectedValue = "-1";
            txtwastage.Text = string.Empty;
            txtGriegeGST.Text = string.Empty;
            txtProcessGST.Text = string.Empty;
            txtGST.Text = string.Empty;
            //RajeevS code for HSNCode implementation
            //txtHSNCode.Text = string.Empty;
        }

        private void CreateCategory()
        {
            try
            {
                Category category = new Category();
                //RajeevS code for HSNCode implementation
                //category.HSNCode = txtHSNCode.Text;
                category.CategoryName = tbCategoryName.Text;
                category.CategoryCode = tbCategoryCode.Text;
                category.Type = Convert.ToInt32(ddlCategoryType.SelectedValue);
                category.CategoryID = Convert.ToInt32(ddlParentCategories.SelectedValue);

                if (category.Type == 1)
                {
                    if (txtGST.Text == "")
                    {
                        ShowAlert("Please Enter GST");
                        return;
                    }
                    else
                        category.GST = Convert.ToDecimal(txtGST.Text);

                    category.wastage = -1;
                }
                else if (category.Type == 2)
                {
                    if (txtwastage.Text == "")
                    {
                        ShowAlert("Please fill wastage value!");
                        return;
                    }
                    else
                        category.wastage = Convert.ToSingle(txtwastage.Text);

                    if (txtGriegeGST.Text == "")
                    {
                        ShowAlert("Please Enter Griege GST.");
                        return;
                    }
                    else category.GriegeGST = Convert.ToDecimal(txtGriegeGST.Text);

                    if (txtProcessGST.Text == "")
                    {
                        ShowAlert("Please Enter Process GST.");
                        return;
                    }
                    else category.ProcessGST = Convert.ToDecimal(txtProcessGST.Text);

                    if (txtGST.Text == "")
                    {
                        ShowAlert("Please fill Finish GST");
                        return;
                    }
                    else category.GST = Convert.ToDecimal(txtGST.Text);

                   

                }

                if (tbCategoryCode.Text == "")
                {
                    ShowAlert("Category code is required!");
                    return;
                }
                if (ddlUnit.SelectedValue.ToString() == "-1")
                {
                    ShowAlert("Please Select Unit.");
                    return;
                }
                else category.unit = ddlUnit.SelectedValue.ToString();
                //RajeevS code for HSNCode implementation
                //if (txtHSNCode.Text == "")
                //{
                //    ShowAlert("HSNCode code is required!");
                //    return;
                //}


                category.Is_CANDC = Convert.ToBoolean(ddlCANDC1.SelectedItem.Text);
                category.LoggedInUser = UserId;
                category = this.adminController.SaveCategoryNew(category);

                if (category.CategoryID > 0)
                {
                    ShowAlert("Data has been saved successfully.");
                    BindGridView();
                    gvCategories.Visible = true;
                    addpnl.Visible = false;
                    return;
                }
                else
                {
                    ShowAlert("Group name or code should not be duplicate!");
                    return;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        protected void ddlCategoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCategoryType.SelectedValue == "1")
            {
                tdwastageMeg.Visible = false;
                tdGriegeGst_header.Visible = false;
                tdProcessGst_header.Visible = false;
                tdGstNoMeg.InnerHtml = "GST %<span class='da_astrx_mand'>*</span>";

                tdwastagetextbox.Visible = false;
                tdGriegeGST.Visible = false;
                tdProcessGST.Visible = false;
            }
            else if (ddlCategoryType.SelectedValue == "2")
            {
                tdwastageMeg.Visible = true;
                tdGriegeGst_header.Visible = true;
                tdProcessGst_header.Visible = true;
                tdGstNoMeg.InnerHtml = "Finish GST %<span class='da_astrx_mand'>*</span>";

                tdwastagetextbox.Visible = true;
                tdGriegeGST.Visible = true;
                tdProcessGST.Visible = true;

            }

            DataSet dsUnit = adminController.GetAllAdminUnit(ddlCategoryType.SelectedValue);

            if (dsUnit.Tables[0].Rows.Count > 0)
            {
                ddlUnit.DataSource = dsUnit;
                ddlUnit.DataTextField = "UnitName";
                ddlUnit.DataValueField = "GroupUnitID";
                ddlUnit.DataBind();
            }

            ddlTypes.SelectedValue = ddlCategoryType.SelectedValue;

            BindGridView();
            BindDDLParentCategories();

            addpnl.Visible = true;
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void tbCategoryName_TextChanged(object sender, EventArgs e)
        {
            string finalstring = string.Empty;
            if (tbCategoryName.Text.Length > 0)
            {
                string[] value = tbCategoryName.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (value.Length == 1)
                {
                    if (value[0].ToString().Length > 2)
                    {
                        finalstring += value[0].Substring(0, 3);
                    }
                    else
                    {
                        ShowAlert("Please enter at least three character!");
                        tbCategoryName.Focus();
                    }
                }
                else
                {
                    foreach (string s in value)
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(s.Substring(0, 1), "^[a-zA-Z0-9\x20]+$"))
                        {
                            finalstring += s.Substring(0, 1);
                            if (s.Length > 1)
                            {
                                finalstring += s.Substring(1, 1);
                            }
                        }
                    }
                }
                tbCategoryCode.Text = finalstring != string.Empty ? finalstring : "";
                tbCategoryCode.Text = tbCategoryCode.Text != "" ? tbCategoryCode.Text.ToUpper() : "";
                addpnl.Visible = true;
            }
            else
            {
                tbCategoryCode.Text = string.Empty;
                ddlCANDC1.SelectedValue = "0";
                ddlUnit.SelectedValue = "-1";
                txtwastage.Text = string.Empty;
                txtGriegeGST.Text = string.Empty;
                txtProcessGST.Text = string.Empty;
                txtGST.Text = string.Empty;
                //RajeevS code for HSNCode implementation
                //txtHSNCode.Text = string.Empty;

            }
        }

        protected void gvCategories_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCategories.PageIndex = e.NewPageIndex;
            gvCategories.EditIndex = -1;
            BindGridView();
        }

        protected void gvCategories_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCategories.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void gvCategories_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = gvCategories.Rows[e.RowIndex];

            Category objCategory = new Category();
            //RajeevS code for HSNCode implementation
            //TextBox txtHSNCodeUpdate = (TextBox)Rows.FindControl("txtHSNCodeUpdate");
            HiddenField hdnCategoryID = (HiddenField)Rows.FindControl("hdnCategoryID");
            TextBox txtCategoryName = (TextBox)Rows.FindControl("txtCategoryName");
            TextBox txtCategoryCode = (TextBox)Rows.FindControl("txtCategoryCode");
            DropDownList ddlUnit = (DropDownList)Rows.FindControl("ddlUnit");
            TextBox txtWastage = (TextBox)Rows.FindControl("txtWastage");

            TextBox txtGriegeGSTNo = (TextBox)Rows.FindControl("txtGriegeGSTNo");
            TextBox txtProcessGSTNo = (TextBox)Rows.FindControl("txtProcessGSTNo");
            TextBox txtFinishGSTNo = (TextBox)Rows.FindControl("txtFinishGSTNo");

            DropDownList ddlCANDC = (DropDownList)Rows.FindControl("ddlCANDC");

            if (txtCategoryName.Text == "")
            {
                ShowAlert("Please enter group name!");
                txtCategoryName.Focus();
                return;
            }
            if (txtCategoryCode.Text == "")
            {
                ShowAlert("Category code is required!");
                txtCategoryCode.Focus();
                return;
            }
            if (ddlTypes.SelectedValue == "2")
            {
                if (txtWastage.Text == "")
                {
                    ShowAlert("Please Enter wastage value.");
                    return;
                }
                if (txtGriegeGSTNo.Text == "")
                {
                    ShowAlert("Please Enter Griege GST.");
                    return;
                }
                if (txtProcessGSTNo.Text == "")
                {
                    ShowAlert("Please Enter Process GST.");
                    return;
                }
                if (txtFinishGSTNo.Text == "")
                {
                    ShowAlert("Please Enter Finish GST.");
                    return;
                }
                //RajeevS code for HSNCode implementation
                //if (txtHSNCodeUpdate.Text == "")
                //{
                //    ShowAlert("Please Enter HSNCode.");
                //    return;
                //}
            }
            //RajeevS code for HSNCode implementation
            //objCategory.HSNCode = txtHSNCodeUpdate.Text.Trim();
            objCategory.Type = Convert.ToInt32(ddlTypes.SelectedValue);
            objCategory.CategoryID =hdnCategoryID.Value == null ? -1 : Convert.ToInt32(hdnCategoryID.Value);
            objCategory.CategoryName = txtCategoryName.Text.Trim();
            objCategory.CategoryCode = txtCategoryCode.Text.Trim();
            objCategory.UnitId = Convert.ToInt32(ddlUnit.SelectedValue);
            objCategory.wastage = txtWastage.Text == "" ? -1 : (float)Convert.ToDouble(txtWastage.Text);

            objCategory.GriegeGST = txtGriegeGSTNo.Text == "" ? 0 : Convert.ToDecimal(txtGriegeGSTNo.Text);
            objCategory.ProcessGST = txtProcessGSTNo.Text == "" ? 0 : Convert.ToDecimal(txtProcessGSTNo.Text);
            objCategory.GST = txtFinishGSTNo.Text == "" ? 0 : Convert.ToDecimal(txtFinishGSTNo.Text);

            objCategory.Is_CANDC = Convert.ToBoolean(ddlCANDC.SelectedItem.Text);

            objCategory.LoggedInUser = UserId;
            objCategory = this.adminController.SaveCategoryNew(objCategory);

            //if (objCategory.CategoryID > 0)
            //{
                gvCategories.EditIndex = -1;
                BindGridView();
            //}
            //else
            //{
            //    ShowAlert("Group name or code should not be duplicate!");
            //    return;
            //}
        }

        protected void gvCategories_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCategories.EditIndex = -1;
            BindGridView();
        }
    }
}