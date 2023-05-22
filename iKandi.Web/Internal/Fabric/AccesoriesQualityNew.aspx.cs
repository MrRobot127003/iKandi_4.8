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
using iKandi.Web.Components;
namespace iKandi.Web.Internal.Fabric
{
    public partial class AccesoriesQualityNew : System.Web.UI.Page
    {
        public static int AccMasterID { get; set; }
        public static string CostingValidation { get; set; }
        public static string CategoryName { get; set; }
        public static string QualityName { get; set; }
        public static string EditFlag { get; set; }
        public static string Shrinkageval { get; set; }
        public static string Wastgae { get; set; }
        public static string UploadTestFilePath { get; set; }
        public static string UploadFilePath { get; set; }

        public static Boolean IsDefault { get; set; }
        String ProductionFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"];
        AdminController onjadminCon = new AdminController();
        AccessoryQualityController acccontroler = new AccessoryQualityController();
        int Count = 0;
        int totalLoop = 0;
        int LastRowCount = 0;
        int UserId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {          

            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            Page.ClientScript.RegisterOnSubmitStatement(this.GetType(), "val", "validateAndHighlight();");

            if (!Page.IsPostBack)
            {
                AccMasterID = 0;
                CategoryName = "";
                QualityName = "";
                BindDdlCatagory(ddlgroupSrach, "ALL");
                BindAccQaulityGrd();
                BindUnit(null, ddlunitsearch);

                #region AccSize
                BindAccSizeGrd();
                #endregion
                BindHeaderSizeGrd();
            }
            else
            {
                BindHeaderSizeGrd();
            }
            divFinish.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "none";
            //SetSizeDelete();
        }

        public void SetSizeDelete()
        {

            DataTable dt2 = new DataTable();

            foreach (GridViewRow grv in grdsize.Rows)
            {
                HiddenField hdnSize = (HiddenField)grv.FindControl("hdnSize");
                LinkButton lnkDelete = (LinkButton)grv.FindControl("lnkDelete");
                HiddenField hdnaccessory_quality_SizeIDs = (HiddenField)grv.FindControl("hdnaccessory_quality_SizeIDs");
                dt2 = onjadminCon.GetAccSizeValueSetSizeDelete(Convert.ToInt32(hdnaccessory_quality_SizeIDs.Value), hdnSize.Value);
                if (dt2.Rows.Count > 0)
                {
                    lnkDelete.Enabled = false;
                    lnkDelete.ToolTip = "Can't delete this supplier, already using in costing.!";
                    lnkDelete.Attributes.Add("onclick", "javascript:return");
                    lnkDelete.Style.Add("background", "gray; !important");
                    lnkDelete.Visible = false;

                }
            }
        }

        protected void grdsizedynamic_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //GridViewRow row = grdsizedynamic.Rows[e.RowIndex];
            //HiddenField hdnAccIDitem = (HiddenField)row.FindControl("hdnAccIDitem");
            /*HiddenField hdnAccIDitem = (HiddenField)row.FindControl("hdnAccIDitem");
            // HiddenField hdnAccID = (HiddenField)GrdCatgoryAdd.Rows[e.RowIndex].FindControl("hdnAccID");
            if (hdnAccIDitem != null)
            {
              int i = onjadminCon.DeleteAccMasterByID(Convert.ToInt32(hdnAccIDitem.Value));
              if (i > 0)
              {
                ShowAlert("Deleted successfully");
              }
            }
            GrdCatgoryAdd.EditIndex = -1;
            BindAccQaulityGrd();*/
        }

        protected void GrdCatgoryAdd_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GrdCatgoryAdd.Rows[e.RowIndex];
            HiddenField hdnAccIDitem = (HiddenField)row.FindControl("hdnAccIDitem");            
            if (hdnAccIDitem != null)
            {
                int i = onjadminCon.DeleteAccMasterByID(Convert.ToInt32(hdnAccIDitem.Value));
                if (i > 0)
                {
                    ShowAlert("Deleted successfully.");
                }
                else
                {
                    ShowAlert("This accessory is using some where! so can not delete it");
                }
            }
            GrdCatgoryAdd.EditIndex = -1;
            BindAccQaulityGrd();
        }
       
        protected void GrdCatgoryAdd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblwastage = (Label)e.Row.FindControl("lblwastage");
                Label lblShrinkage = (Label)e.Row.FindControl("lblShrinkage");
                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete"); 

                int IsAccessoryUsing = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IsAccessoryUsing"));
                if (IsAccessoryUsing == 1)
                    lnkDelete.Visible = false;

                if (lblwastage.Text != "0" && lblwastage.Text != "")
                {
                    lblwastage.Text = lblwastage.Text + "%";
                }
                else
                {
                    lblwastage.Text = "";
                }

                if (lblShrinkage.Text != "0" && lblShrinkage.Text != "")
                {
                    lblShrinkage.Text = lblShrinkage.Text + "%"; ;
                }
                else
                {
                    lblShrinkage.Text = "";
                }
            }
        }

        protected void GrdCatgoryAdd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Select"))
            {
                GrdCatgoryAdd.EditIndex = -1;
                grdsize.EditIndex = -1;
                BindAccQaulityGrd();
                GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                int RowIndex = gvr.RowIndex;
                Label lblUnit = (Label)GrdCatgoryAdd.Rows[RowIndex].FindControl("lblunit");
                lblUnit.Font.Bold = true;
                HiddenField hdnAccIDitem = (HiddenField)GrdCatgoryAdd.Rows[RowIndex].FindControl("hdnAccIDitem");
                Label lblcatagory = (Label)GrdCatgoryAdd.Rows[RowIndex].FindControl("lblcatagory");
                Label lblAccQName = (Label)GrdCatgoryAdd.Rows[RowIndex].FindControl("lblAccQName");
                Label lblwastage = (Label)GrdCatgoryAdd.Rows[RowIndex].FindControl("lblwastage");
                Label lblShrinkage = (Label)GrdCatgoryAdd.Rows[RowIndex].FindControl("lblShrinkage");
                CheckBox chkIsdefaultRow = (CheckBox)GrdCatgoryAdd.Rows[RowIndex].FindControl("chkIsdefaultRow");

                IsDefault = chkIsdefaultRow.Checked;
                hdnIsdefault.Value = IsDefault.ToString();
                if (hdnAccIDitem != null)
                    AccMasterID = Convert.ToInt32(hdnAccIDitem.Value);

                if (lblcatagory != null)
                {
                    CategoryName = lblcatagory.Text;
                }
                if (lblAccQName != null)
                {
                    QualityName = lblAccQName.Text;
                }
                hdnwastage.Value = lblwastage.Text.Replace("%", "");
                hdnshrinkage.Value = lblShrinkage.Text.Replace("%", "");

                if (lblwastage.Text != "")
                {
                    lblWast.Text = "Wstg " + lblwastage.Text;
                }
                else
                {
                    lblWast.Text = "Wstg ";
                }
                if (lblShrinkage.Text != "")
                {
                    lblshry.Text = "Shrnkg " + lblShrinkage.Text;
                }
                else
                {
                    lblshry.Text = "Shrnkg ";
                }
                BindAccSizeGrd();
                BindHeader();
                BindHeaderSizeGrd();                
            }
        }
      
        private void BindUnit(DataTable dt, DropDownList ddl)
        {
            if (dt == null)
            {
                dt = acccontroler.GetUnit().Tables[0];
            }
            ddl.DataSource = dt;
            ddl.DataTextField = "UnitName";
            ddl.DataValueField = "GroupUnitID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("ALL", "-1"));
        }
       
        protected void btn_Go(object sender, EventArgs e)
        {            
            AccMasterID = 0;
            GrdCatgoryAdd.EditIndex = -1;
            BindAccQaulityGrd();

            ResetSuppliergrd();
           
        }
       
        public void BindDdlCatagory(DropDownList ddlcat, string IsSelect = "")
        {
            DataSet ds = new DataSet();
            DataTable dtcat = new DataTable();
            ds = onjadminCon.GetCatagory(1);
            dtcat = ds.Tables[0];
            ddlcat.DataSource = dtcat;
            ddlcat.DataTextField = "Name";
            ddlcat.DataValueField = "id";
            ddlcat.DataBind();
            if (IsSelect != "NoSelect")
            {
                if (IsSelect == "")
                {
                    ddlcat.Items.Insert(0, new ListItem(IsSelect, "-1"));
                }
                else
                {
                    ddlcat.Items.Insert(0, new ListItem(IsSelect, "-1"));
                }
            }

        }
       
        public void BindAccQaulityGrd()
        {
            DataTable dtcat = new DataTable();
            int Unit = Convert.ToInt32(ddlunitsearch.SelectedValue);
            dtcat = onjadminCon.GetCatagoryFilter(7, Convert.ToInt32(ddlgroupSrach.SelectedValue), txtQualitySearch.Text.Trim(), Unit, Convert.ToInt32(ddlIsDefault.SelectedValue));
            if (dtcat.Rows.Count > 0)
            {
                GrdCatgoryAdd.DataSource = dtcat;
                GrdCatgoryAdd.DataBind();

                BindDdlCatagory(ddlGroup, "ALL");
                DropdownHelper.BindAllClientCode(ddlClient);
            }
            else
            {
                GrdCatgoryAdd.DataSource = null;
                GrdCatgoryAdd.DataBind();
            }
        }
       
        public string ValidategroupQualitysize()
        {
            string Msg = "";
            if (grdsize.Rows.Count > 0)
            {

                foreach (GridViewRow grv in grdsize.Rows)
                {
                    Label Sizelable = (Label)grv.FindControl("Sizelable");


                    if (string.Equals(txtsizeAdd.Text.Trim(), Sizelable.Text.Trim(), StringComparison.CurrentCultureIgnoreCase))
                    {
                        Msg = "Duplicate found";
                    }
                }
            }
            return Msg;
        }

        protected void lnkAddSize_Click(object sender, EventArgs e)
        {
            grdsize.EditIndex = -1;

            //  string SizeVal = IsDefault == true ? ddlISdefaultFooter.SelectedItem.Text : txtsizeAdd.Text.Trim();
            //AddAccsessory();
            //BindAccQaulityGrd();
            //string str = ValidategroupQualitysize();
            //if (str != "")
            //{
            //  divFinish.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "block";
            //  ShowAlert("Duplicate found!");
            //  txtsizeAdd.Text = "";
            //  return;

            //}

            //ddlgrouptypeAdd.SelectedValue = "0";
            //txtQtyAdd.Text = "";
            //lblunitadd.Text = "";

            UpdateSizeDetails();
            txtsizeAdd.Text = "";

            // Response.Redirect(Request.RawUrl);



        }

        public void BindAccSizeGrd()
        {
            DataTable dtAccSize = onjadminCon.GetAccSizedetails(19, AccMasterID);
            if (dtAccSize.Rows.Count > 0)
            {
                grdsize.DataSource = dtAccSize;
                grdsize.DataBind();
            }
            else
            {
                grdsize.DataSource = new string[] { };
                grdsize.DataBind();
            }
        }

        public void UpdateSizeDetails()
        {
            string SizeName = "";
            decimal Greige = 0; decimal procees = 0; decimal Finish = 0;
            string SizeVal = txtsizeAdd.Text.Trim();
            //if (!string.IsNullOrEmpty(txtsizeAdd.Text.Trim()))
            //  SizeName = txtsizeAdd.Text.Trim();
            if (SizeVal == "")
            {
                ShowAlert("Please enter size name!");
                return;
            }
            if (!string.IsNullOrEmpty(SizeVal))
                SizeName = SizeVal;
            else
            {
                ShowAlert("Please enter size name!");
                divFinish.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "block";
                return;
            }
            if (onjadminCon.UpdateAccSizeValidate(SizeName, AccMasterID) != "")
            {

                ShowAlert("Duplicate size name found!");

                divFinish.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "block";
                return;
            }
            if (!string.IsNullOrEmpty(txtgreigeAdd.Text.Trim()))
                Greige = Convert.ToDecimal(txtgreigeAdd.Text.Trim());
            if (!string.IsNullOrEmpty(txtprocessAdd.Text.Trim()))
                procees = Convert.ToDecimal(txtprocessAdd.Text.Trim());

            if (!string.IsNullOrEmpty(txtfinishAdd.Text.Trim()))
                Finish = Convert.ToDecimal(txtfinishAdd.Text.Trim());



            int iSave = onjadminCon.UpdateAccSize(9, AccMasterID, SizeName, "0", Greige, procees, Finish, 0, UserId);
            if (iSave > 0)
            {
                txtsizeAdd.Text = "";
                txtgreigeAdd.Text = "";
                txtprocessAdd.Text = "";
                txtfinishAdd.Text = "";

                ShowAlert("Saved successfully.");
                BindAccSizeGrd();

                txtsizeAdd.Text = "";
                BindHeader();
                BindHeaderSizeGrd();
                divFinish.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "block";
                //SetSizeDelete();
            }
            divFinish.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "block";

        }

        public void ShowAlert(string mag)
        {
            var script_success = "ShowHideMessageBox(true, '" + mag + "');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script_success, true);
        }

        protected void grdsize_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = grdsize.Rows[e.RowIndex];
            HiddenField hdnAccQualitySizeID = (HiddenField)row.FindControl("hdnAccQualitySizeID");
            HiddenField hdnAccMasterID = (HiddenField)row.FindControl("hdnAccMasterID");
            HiddenField hdnSize = (HiddenField)row.FindControl("hdnSize");
            // HiddenField hdnAccMasterID = (HiddenField)row.FindControl("hdnAccMasterID");
            if (hdnSize != null)
            {
                int iSave = onjadminCon.DeleteAccSize(AccMasterID, 0, hdnSize.Value.Trim());

                ShowAlert("Deleted successfully.");
                grdsize.EditIndex = -1;
                BindAccSizeGrd();
                txtsizeAdd.Text = "";
                BindHeader();
                BindHeaderSizeGrd();
                //SetSizeDelete();
            }
        }

        public void BindHeader()
        {
            divsizeheader.InnerHtml = "";
            DataTable dtAccSize = onjadminCon.GetAccSizedetails(16, AccMasterID);
            string strbuilder = "";
            //StringBuilder strbuilder = new StringBuilder();
            DataTable dtAccSizeDtata = onjadminCon.GetAccSizedetails(19, AccMasterID);
            int count = 0;
            int width;
            if (dtAccSize.Rows.Count > 0)
            {
                count = dtAccSize.Rows.Count;
                hdnSizeCount.Value = count.ToString();
                width = 760 + 60 * count * 3 + 7 + count * 3;
            }
            else
            {
                width = 760 + 60 + 7;
            }
            grdsizedynamic.Width = width;
            int colspanTop = count * 3;
           
            strbuilder = strbuilder + "<table cellpading='0' cellspacing='0' border='1'  class='item_list1 bottom_boder1' style='border-bottom:1px solid #999 !important;margin:0 auto;width:" + width + "px;'>";
            strbuilder = strbuilder + "<tr><th style='width:119px'> Category</th> <th style='width:120px'>Quality</th>  <th rowspan='4' style='width:90px;border-bottom:none !important;'>MOQ</th>";
            if (colspanTop == 0)
            {
                strbuilder = strbuilder + "<th rowspan='4' style='width:90px;border-bottom:none !important;'>Add Size <span ><img onclick='ShowSizeDiv();' src='../../App_Themes/ikandi/images/plus.gif' width='10px' height='10px' style='cursor:pointer'></span></th>";
            }
            else
            {
                strbuilder = strbuilder + "<th colspan='" + colspanTop + "'>Add Size <span><img onclick='ShowSizeDiv();' src='../../App_Themes/ikandi/images/plus.gif' width='11px' style='cursor:pointer'></span></th>";
            }
            strbuilder = strbuilder + "<th rowspan='4' style='width:50px;border-bottom:none !important;'>Lead Time (Days)</th><th colspan='2'> Limitation </th> <th rowspan='4' style='width:100px;border-bottom:none !important;'>Upload File</th><th rowspan='4' style='width:100px;border-bottom:none !important;'>Action</th></tr>";
            strbuilder = strbuilder + "<tr><td rowspan='2' style='border-left-color:#a8a3a3;border-right-color:#a8a3a3'>" + CategoryName + "</td><td rowspan='2' style='border-right-color:#a8a3a3'>" + QualityName + "</td>";
            for (int i = 0; i < count; i++)
            {
                strbuilder = strbuilder + "<th colspan='3'>" + dtAccSize.Rows[i]["Size"].ToString() + "</th>";
            }
            strbuilder = strbuilder + "<th rowspan='3' style='width:90px;border-bottom:none !important;'>Upload Test Report</th><th rowspan='3' style='width:90px;border-bottom:none !important;'>Test Date </th></tr>";

            strbuilder = strbuilder + "<tr>";
            for (int i = 0; i < count; i++)
            {
                strbuilder = strbuilder + "<th  style='border-bottom:none !important;width:60px;'>Greige</th><th  style='border-bottom:none !important;width:60px;'>Process</th><th  style='border-bottom:none !important;width:60px;'>Finish</th>";
            }

            strbuilder = strbuilder + "</tr><tr><th colspan='2' style='border-bottom:none !important;'>Supplier</th>";
            for (int i = 0; i < count; i++)
            {
                if (dtAccSizeDtata.Rows.Count > 0)
                {
                    string grie = dtAccSizeDtata.Rows[i]["GreigeRate"].ToString();
                    string process = dtAccSizeDtata.Rows[i]["ProcessRate"].ToString();
                    string FinishRate = dtAccSizeDtata.Rows[i]["FinishRate"].ToString();

                    if (grie != "0" && grie != "")
                    {
                        grie = "₹ " + grie;
                    }
                    else
                    {
                        grie = "";
                    }
                    if (process != "0" && process != "")
                    {
                        process = "₹ " + process;
                    }
                    else
                    {
                        process = "";
                    }
                    if (FinishRate != "0" && FinishRate != "")
                    {
                        FinishRate = "₹ " + FinishRate;
                    }
                    else
                    {
                        FinishRate = "";
                    }
                    strbuilder = strbuilder + "<th  style='border-bottom:none !important;'>" + "<span style='color: green;'>" + grie + "</span>" + "</th><th  style='border-bottom:none !important;'>" + "<span style='color: green;'>" + process + "</span>" + "</th><th  style='border-bottom:none !important;'>" + "<span style='color: green;'>" + FinishRate + "</span>" + "</th>";
                }
            }
            strbuilder = strbuilder + "</tr>";
            strbuilder = strbuilder + "</table>";

            divsizeheader.InnerHtml = strbuilder;

        }

        protected void btnreturnF_Click(object sender, EventArgs e)
        {
            //divFinish.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "block";
            divFinish.Attributes.Remove("style");
            //BindFabricQualityHeader(Convert.ToInt32(ViewState["FQMID"].ToString()));
            BindHeader();
            BindHeaderSizeGrd();      
        }

        protected void btnshowsize_Click(object sender, EventArgs e)
        {
            //divshowsize.Visible = true;
        }

        public void BindDropdownSupplier()
        {

        }

        protected void ViewDetails(object sender, EventArgs e)
        {
            LinkButton lnkView = (sender as LinkButton);
            GridViewRow row = (lnkView.NamingContainer as GridViewRow);
            string accessory_qualityID = lnkView.CommandArgument;
            // string name = row.Cells[0].Text;
            string SupplierName = (row.FindControl("SupplierName") as DropDownList).SelectedValue;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('accessory_qualityID: " + accessory_qualityID + " AccMasterID: " + AccMasterID + " SupplierName: " + SupplierName + "')", true);
            ShowAlert(accessory_qualityID + " " + SupplierName);
        }

        public void BindSizeSupplierNameDdl(string flagIsselect, DropDownList ddl)
        {
            DataTable dt = onjadminCon.GetAccSizedetails(15, AccMasterID);
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataTextField = "SupplierName";
                ddl.DataValueField = "supplier_master_Id";
                ddl.DataBind();

                if (flagIsselect == "")
                {
                    //ddl.Items.Insert(0, new ListItem("", "0"));
                }
                else
                {
                    ddl.Items.Insert(0, new ListItem("Select", "0"));
                }

            }
            else
            {
                if (flagIsselect == "")
                    ddl.Items.Insert(0, new ListItem("", "0"));
                else
                {
                    ddl.Items.Insert(0, new ListItem("Select", "0"));
                }
            }

        }

        public void BindSizeTypeNameDdl(string flagIsselect, DropDownList ddl)
        {
            DataTable dt = onjadminCon.GetAccSizedetails(14, AccMasterID);
            if (dt.Rows.Count > 0)
            {
                ddl.DataSource = dt;
                ddl.DataTextField = "Typess";
                ddl.DataValueField = "Typess";
                ddl.DataBind();
                if (flagIsselect == "")
                {
                    ddl.Items.Insert(0, new ListItem("", "0"));
                }
                else
                {
                    ddl.Items.Insert(0, new ListItem("Select", "0"));
                }
            }
            else
            {
                if (flagIsselect == "")
                    ddl.Items.Insert(0, new ListItem("", "0"));
                else
                {
                    ddl.Items.Insert(0, new ListItem("Select", "0"));
                }
            }
        }

        protected void GrdCatgoryAdd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdCatgoryAdd.PageIndex = e.NewPageIndex;
            GrdCatgoryAdd.EditIndex = -1;
            GrdCatgoryAdd.SelectedIndex = -1;
            BindAccQaulityGrd();
            ResetSuppliergrd();
        }

        protected void grdsizedynamic_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int rowIndex = e.NewEditIndex;
            GridViewRow rw = (GridViewRow)grdsizedynamic.Rows[e.NewEditIndex];            

            HiddenField hdnQualityId = grdsizedynamic.Rows[e.NewEditIndex].FindControl("hdnAccessQualityId") as HiddenField;

            int AccessoryQualityId = hdnQualityId == null ? -1: Convert.ToInt32(hdnQualityId.Value);
           
            DropDownList SupplierName = grdsizedynamic.Rows[e.NewEditIndex].FindControl("SupplierName") as DropDownList;

            Label lblsupplerrow = grdsizedynamic.Rows[e.NewEditIndex].FindControl("lblsupplerrow") as Label;
           
            TextBox TestDate = grdsizedynamic.Rows[e.NewEditIndex].FindControl("TestDate") as TextBox;
            TextBox MOQ = grdsizedynamic.Rows[e.NewEditIndex].FindControl("MOQ") as TextBox;
            TextBox LeadTimeDays = grdsizedynamic.Rows[e.NewEditIndex].FindControl("LeadTimeDays") as TextBox;
            LinkButton Upd = grdsizedynamic.Rows[e.NewEditIndex].FindControl("Upd") as LinkButton;
            LinkButton lnkedit = grdsizedynamic.Rows[e.NewEditIndex].FindControl("lnkedit") as LinkButton;
          
            LinkButton Del = grdsizedynamic.Rows[e.NewEditIndex].FindControl("Del") as LinkButton;
            LinkButton lnkcancel = grdsizedynamic.Rows[e.NewEditIndex].FindControl("lnkcancel") as LinkButton;
            HyperLink hyltestreport = grdsizedynamic.Rows[e.NewEditIndex].FindControl("hyltestreport") as HyperLink;
            HyperLink hypuploads = grdsizedynamic.Rows[e.NewEditIndex].FindControl("hypuploads") as HyperLink;

            
            hyltestreport.Attributes.Add("onclick", "javascript:showhideFileupload(" + AccMasterID + ", " + AccessoryQualityId + ", this)");
            hypuploads.Attributes.Add("onclick", "javascript:showhideFileupload(" + AccMasterID + ", " + AccessoryQualityId + ", this)");

            DataTable DtSizeName = onjadminCon.GetAccSizedetails(16, AccMasterID);
            int CountRow = Convert.ToInt32(DtSizeName.Rows.Count) - 1;

            if (Convert.ToInt32(DtSizeName.Rows.Count) > 0)
            {
                for (int i = 0; i <= CountRow; i++)
                {      
                    CheckBox chkGrigete = (CheckBox)grdsizedynamic.Rows[e.NewEditIndex].FindControl("chkGrigete_" + i.ToString());
                    CheckBox chckProcess = (CheckBox)grdsizedynamic.Rows[e.NewEditIndex].FindControl("chkchckProcess_" + i.ToString());
                    CheckBox FinalPrice = (CheckBox)grdsizedynamic.Rows[e.NewEditIndex].FindControl("chkFinalPrice_" + i.ToString());

                    chkGrigete.Enabled = true;
                    chckProcess.Enabled = true;
                    FinalPrice.Enabled = true;
                }
            } 
          
            SupplierName.Style.Add("display", "block");
            TestDate.Enabled = true;
            MOQ.Enabled = true;
            Upd.Visible = true;

            lblsupplerrow.Visible = false;
            LeadTimeDays.Visible = true;
            LeadTimeDays.ReadOnly = false;
            LeadTimeDays.Enabled = true;
            LeadTimeDays.CssClass = "inputborder";
            lnkedit.Visible = false;
            Del.Visible = false;
            lnkcancel.Visible = true;
            
            if (Del.Enabled == false)
            {                
                SupplierName.Enabled = false;               
                Del.Enabled = false;
                Del.ToolTip = "Can't delete this supplier, already using in costing.!";
                SupplierName.BackColor = System.Drawing.ColorTranslator.FromHtml("#f1eded");               
                rw.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#f1eded");
                rw.Cells[totalLoop + 9].BackColor = System.Drawing.ColorTranslator.FromHtml("#f1eded");       
            }            
        }

        protected void grdsizedynamic_RowDataBound(object sender, GridViewRowEventArgs e)
        {            
            DataTable dtAccSize = onjadminCon.GetAccSizedetails(16, AccMasterID);
            DataTable dtAccSizeUality = null;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem;
                GridView gridView = (GridView)sender;

                int colCount = grdsizedynamic.Columns.Count;                
                string BottomRow = drv.Row.ItemArray[0] == DBNull.Value ? "" : drv.Row.ItemArray[11].ToString();
                DropDownList SupplierName = e.Row.FindControl("SupplierName") as DropDownList;              
                TextBox TestDate = e.Row.FindControl("TestDate") as TextBox;
                TestDate.CssClass = "th2";
                TextBox LeadTimeDays = e.Row.FindControl("LeadTimeDays") as TextBox;
                LeadTimeDays.MaxLength = 3;

                dtAccSizeUality = onjadminCon.GetAccSizedetailsNew(AccMasterID, Convert.ToInt32(drv.Row.ItemArray[0].ToString()));

                SupplierName.Attributes.Add("onchange", "chkSelection(this,'" + drv.Row.ItemArray[5].ToString() + "');");

                SupplierName.CssClass = "SuppCheck";
                TextBox MOQ = e.Row.FindControl("MOQ") as TextBox;

                LinkButton Upd = e.Row.FindControl("Upd") as LinkButton;
                LinkButton Del = e.Row.FindControl("Del") as LinkButton;

                Upd.CssClass = "UpdateBtn";                
                Del.CssClass = "DeleteBtn";
                Upd.Text = "";
                Del.Text = "";

                HiddenField hdnQualityId = new HiddenField();
                hdnQualityId.ID = "hdnAccessQualityId";
                hdnQualityId.Value = drv.Row.ItemArray[0].ToString();
               
                Label lblsupplier = new Label();
                lblsupplier.Text = "";
                lblsupplier.Visible = false;
                lblsupplier.ID = "lblsupplerrow";
              
                Label lbltype = new Label();
                lbltype.Text = "";
                lbltype.Visible = false;
                lbltype.ID = "lbltyperow";

                LeadTimeDays.Enabled = false;
                TestDate.Enabled = false;
                MOQ.Enabled = false;               
                Upd.Visible = false;

                LinkButton lnkViewEdit = new LinkButton();
                lnkViewEdit.ID = "lnkedit";
                lnkViewEdit.Text = "Edit";
                lnkViewEdit.Controls.Add(new Image { ImageUrl = "../../images/edit2.png" });
                lnkViewEdit.CommandArgument = (e.Row.DataItem as DataRowView).Row["accessory_qualityID"].ToString();
                lnkViewEdit.CommandName = "EDIT";

                e.Row.Cells[0].Controls.Add(lblsupplier);
                e.Row.Cells[0].Controls.Add(hdnQualityId);
                e.Row.Cells[1].Controls.Add(lbltype);
               
                if (drv.Row.ItemArray[8].ToString() != "")
                {
                    TestDate.Text = Convert.ToDateTime(drv.Row.ItemArray[8].ToString()).ToString("dd/MM/yyyy");
                }              

                int AccessoryQualityId = Convert.ToInt32(drv.Row.ItemArray[0].ToString());

                HyperLink hyplnkTestreport = new HyperLink();
                hyplnkTestreport.ID = "hyltestreport";               
                hyplnkTestreport.Target = "_blank";
                hyplnkTestreport.ImageUrl = "../../images/uploadimg.png";
                hyplnkTestreport.ToolTip = "Upload Files";
                hyplnkTestreport.CssClass = "lnkCursor";
                hyplnkTestreport.Attributes.Add("onclick", "javascript:showhideFileupload(" + AccMasterID + ", " + AccessoryQualityId + ", this)");

                HyperLink hypupload = new HyperLink();
                hypupload.ID = "hypuploads";               
                hypupload.Target = "_blank";
                hypupload.ImageUrl = "../../images/uploadimg.png";
                hypupload.ToolTip = "Upload Files";
                hypupload.CssClass = "lnkCursor";
                hypupload.Attributes.Add("onclick", "javascript:showhideFileupload(" + AccMasterID + ", " + AccessoryQualityId + ", this)");


                e.Row.Cells[totalLoop + 5].Controls.Add(hyplnkTestreport);
                e.Row.Cells[totalLoop + 7].Controls.Add(hypupload);
                
                if (SupplierName != null)
                {
                    if (BottomRow != "0")
                    { 
                        Upd.Visible = false;
                        LeadTimeDays.Enabled = true;
                        TestDate.Enabled = true;
                        MOQ.Enabled = true;                       
                       
                        LeadTimeDays.Attributes.Add("onpaste", "return false;");
                        LeadTimeDays.Attributes.Add("onkeypress", "return isNumberKey(event)");

                        if (Upd != null)
                        {
                            Upd.Visible = false;
                        }
                        BindSizeSupplierNameDdl("Select", SupplierName);

                        e.Row.Cells[LastRowCount - 1].ColumnSpan = 2;
                        e.Row.Cells[LastRowCount].Visible = false;
                        e.Row.Cells[LastRowCount - 1].Width = 101;

                        LinkButton lnkView = new LinkButton();
                        lnkView.ID = "lnkAddNew";
                        lnkView.Text = "";                        
                        lnkView.Controls.Add(new Image {ImageUrl = "../../images/add-butt.png" });

                        lnkView.CommandArgument = (e.Row.DataItem as DataRowView).Row["accessory_qualityID"].ToString();
                        lnkView.CommandName = "ADDNEW";
                        e.Row.Cells[LastRowCount - 1].Controls.Add(lnkView);                       
                    }
                    else
                    {                        
                        e.Row.Cells[LastRowCount - 1].Controls.Add(lnkViewEdit);                        
                        SupplierName.Style.Add("display", "none");

                        lblsupplier.Visible = true;
                        lbltype.Visible = true;
                        
                        LinkButton lnkcancel = new LinkButton();
                        lnkcancel.ID = "lnkCancel";
                        lnkcancel.Text = "";                       
                        lnkcancel.Controls.Add(new Image { ImageUrl = "../../App_Themes/ikandi/images/cancel1.png" });
                        lnkcancel.CommandName = "Cancel";
                        lnkcancel.Attributes.Add("style", "width:24px");
                        lnkcancel.CssClass = "CancelButton";
                        e.Row.Cells[LastRowCount].Controls.Add(lnkcancel);
                        lnkcancel.Visible = false;

                        Upd.CommandArgument = (e.Row.DataItem as DataRowView).Row["accessory_qualityID"].ToString();
                        Upd.CommandName = "ADDNEW";
                        Del.CommandArgument = (e.Row.DataItem as DataRowView).Row["accessory_qualityID"].ToString();
                        Del.CommandName = "Delete";

                        BindSizeSupplierNameDdl("", SupplierName);

                        string TypeID = drv.Row.ItemArray[3] == DBNull.Value ? "" : drv.Row.ItemArray[3].ToString();

                        string SupplierID = drv.Row.ItemArray[5] == DBNull.Value ? "" : drv.Row.ItemArray[5].ToString();
                        if (SupplierName.Items.FindByValue(SupplierID) != null)
                        {
                            SupplierName.SelectedValue = SupplierID;
                            lblsupplier.Text = SupplierName.SelectedItem.Text;
                        }
                        else
                        {
                            SupplierName.SelectedValue = "0";
                        }

                        if (drv.Row.ItemArray[12].ToString() == "EXISTS")
                        {
                            SupplierName.Enabled = false;                           
                            Del.Enabled = false;
                            Del.ToolTip = "Can't delete this supplier, already using in costing.!";
                            SupplierName.BackColor = System.Drawing.ColorTranslator.FromHtml("#f1eded");                           
                            e.Row.Cells[totalLoop + 9].BackColor = System.Drawing.ColorTranslator.FromHtml("#f1eded");                           
                            e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#f1eded");
                        }
                        else
                        {
                            Del.OnClientClick = "return confirm('Are you sure want to delete this supplier?');";
                        }

                        if (Convert.ToInt32(dtAccSizeUality.Rows.Count) > 0)
                        {
                            for (int i = 0; i <= dtAccSize.Rows.Count - 1; i++)
                            {                                
                                int accessory_quality_SizeID = 0;                                
                                string SizeName = dtAccSize.Rows[i]["Size"].ToString();

                                CheckBox chkGrigete = e.Row.FindControl("chkGrigete_" + i.ToString()) as CheckBox;
                                CheckBox chckProcess = e.Row.FindControl("chkchckProcess_" + i.ToString()) as CheckBox;
                                CheckBox FinalPrice = e.Row.FindControl("chkFinalPrice_" + i.ToString()) as CheckBox;

                                chkGrigete.Enabled = false;
                                chckProcess.Enabled = false;
                                FinalPrice.Enabled = false;

                                DataTable dtsize = onjadminCon.GetAccSizeHistory("SIZEDATA", accessory_quality_SizeID, AccMasterID, Convert.ToInt32(drv.Row.ItemArray[0].ToString()), SizeName);
                                if (dtsize.Rows.Count > 0)
                                {
                                    string IsGreigeSupply = dtsize.Rows[0]["IsGreigeSupply"].ToString();
                                    string IsProcessSupply = dtsize.Rows[0]["IsProcessSupply"].ToString();
                                    string IsFinishSupply = dtsize.Rows[0]["IsFinishSupply"].ToString();
                                    if (IsGreigeSupply == "False")
                                    {
                                        chkGrigete.Checked = false;
                                    }
                                    else
                                    {
                                        chkGrigete.Checked = true;
                                    }

                                    if (IsProcessSupply == "False")
                                    {
                                        chckProcess.Checked = false;
                                    }
                                    else
                                    {
                                        chckProcess.Checked = true;
                                    }
                                    if (IsFinishSupply == "False")
                                    {
                                        FinalPrice.Checked = false;
                                    }
                                    else
                                    {
                                        FinalPrice.Checked = true;
                                    }
                                }
                                else
                                {
                                    string Suplytype = onjadminCon.GetSupplierSelectedType(Convert.ToInt32(SupplierName.SelectedValue));
                                    if (Suplytype != "0")
                                    {
                                        string[] splitsupplytype = Suplytype.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                                        foreach (string a in splitsupplytype)
                                        {
                                            if (a == "4")
                                            {
                                                chkGrigete.Checked = true;
                                            }
                                            else if (a == "5")
                                            {
                                                chckProcess.Checked = true;
                                            }
                                            else if (a == "7")
                                            {
                                                FinalPrice.Checked = true;
                                            }
                                        }

                                    }
                                }
                            }
                        }

                        LeadTimeDays.Attributes.Add("onpaste", "return false;");
                        LeadTimeDays.Attributes.Add("onkeypress", "return isNumberKey(event)");

                        string LeadTimeDaysval = drv.Row.ItemArray[6] == DBNull.Value ? "" : drv.Row.ItemArray[6].ToString();
                        if (LeadTimeDaysval == "" || LeadTimeDaysval == "0")
                        {
                            LeadTimeDays.Text = "";
                        }
                        else
                        {
                            LeadTimeDays.Text = LeadTimeDaysval;
                        }

                        string MOQval = drv.Row.ItemArray[9] == DBNull.Value ? "" : drv.Row.ItemArray[9].ToString();
                        if (MOQval == "" || MOQval == "0")
                        {
                            MOQ.Text = "";
                        }
                        else
                        {
                            MOQ.Text = MOQval;
                        }
                    }
                }
                EditFlag = "-1";
            }

        }
       
        protected void grdsizedynamic_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            DataTable dtAccSize = onjadminCon.GetAccSizedetails(8, AccMasterID);
            DataTable DtSizeName = onjadminCon.GetAccSizedetails(16, AccMasterID);
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            int RowIndex = gvr.RowIndex;
            int accessoryMasterqualityID = 0;
            int accessory_qualityID = 0;
            double AccesoriesWastage = 0;
            double Accesories_ShrinkageWastage = 0;
            string AccesoriesType = "";
            int AccessoryMaster_ID = 0;
            int SupplierID = 0;
            int LeadTime = 0;
            string UploadBaseTestFile = "";
            DateTime TestConductedOn = DateTime.MinValue;
            double MinimumOrderQuality = 0;
            string UploadFile = "";

            int IsGreige = 0;
            int IsProcess = 0;
            int IsFinish = 0;

            double GreigePrice = 0;
            double ProcessPrice = 0;
            double FinishPrice = 0;


            if (e.CommandName == "Delete")
            {
                accessory_qualityID = Convert.ToInt32(e.CommandArgument.ToString());

                bool IsDelete = onjadminCon.deleteAccQualityMaster(accessory_qualityID, AccMasterID);
                ShowAlert("Supplier deleted Successfully.");
                BindAccSizeGrd();
                BindHeader();
                BindHeaderSizeGrd();

            }           
            if (e.CommandName == "Cancel")
            {
                BindHeader();
                BindHeaderSizeGrd();
            }
            if (e.CommandName == "ADDNEW")
            {
                accessory_qualityID = Convert.ToInt32(e.CommandArgument.ToString());
                AccessoryMaster_ID = AccMasterID;
                DropDownList SupplierName = (DropDownList)grdsizedynamic.Rows[RowIndex].FindControl("SupplierName");
                TextBox LeadTimeDays = (TextBox)grdsizedynamic.Rows[RowIndex].FindControl("LeadTimeDays");               
                TextBox TestDate = (TextBox)grdsizedynamic.Rows[RowIndex].FindControl("TestDate");
                TextBox MOQ = (TextBox)grdsizedynamic.Rows[RowIndex].FindControl("MOQ");              

                HiddenField FileUploadTestReport = (HiddenField)grdsizedynamic.Rows[RowIndex].FindControl("FileUploadTestReport");
                HiddenField FileUpload = (HiddenField)grdsizedynamic.Rows[RowIndex].FindControl("FileUpload");                
                Count = Convert.ToInt32(DtSizeName.Rows.Count) - 1;

                string result;
                if (SupplierName.SelectedValue == "0")
                {
                    ShowAlert("Please select supplier name!");
                    return;
                }
                if (accessory_qualityID == -1)
                {
                    ValidateSupplierName("", out result);
                    if (result != "")
                    {
                        ShowAlert(result);
                        return;
                    }
                }
                else
                {
                    ValidateSupplierName("1", out result);
                    if (result != "")
                    {
                        ShowAlert(result);
                        return;
                    }
                }
                if (Convert.ToInt32(dtAccSize.Rows.Count) > 0)
                {
                   
                }
                else
                {
                    ShowAlert("Please select atleast 1 size!");
                    return;
                }
                if (SupplierName != null)
                {
                    if (SupplierName.SelectedValue == "0")
                    {
                        ShowAlert("Please select supplier name!");
                        return;
                    }
                    else
                    {
                        SupplierID = Convert.ToInt32(SupplierName.SelectedValue);
                    }
                }

                if (LeadTimeDays.Text.Trim() != "")
                {
                    LeadTime = Convert.ToInt32(LeadTimeDays.Text.Trim());
                }

                if (Session["TestReportFileName"] != null)
                {
                    UploadBaseTestFile = Session["TestReportFileName"].ToString();
                    Session["TestReportFileName"] = null;
                }               
               
                if (TestDate.Text != "")
                {
                    TestConductedOn = DateTime.ParseExact(TestDate.Text.Trim(), "dd/MM/yyyy", null);                    
                }
                else
                {
                    TestConductedOn = DateTime.MinValue;
                }
                if (MOQ.Text.Trim() != "")
                {
                    MinimumOrderQuality = Convert.ToDouble(MOQ.Text);
                }
                if (Session["UploadFileName"] != null)
                {
                    UploadFile = Session["UploadFileName"].ToString();
                    Session["UploadFileName"] = null;
                }
                
                accessoryMasterqualityID = onjadminCon.UpdateAccSupplier("ACC", accessory_qualityID, AccesoriesWastage, Accesories_ShrinkageWastage, AccesoriesType,
                AccessoryMaster_ID, SupplierID, LeadTime, UploadBaseTestFile, TestConductedOn, MinimumOrderQuality, UploadFile, UserId);

                if (accessoryMasterqualityID > 0)
                {
                    int IsSave = 0;
                    if (Convert.ToInt32(DtSizeName.Rows.Count) > 0)
                    {
                        for (int i = 0; i <= Count; i++)
                        {
                            CheckBox chkGrigete = (CheckBox)grdsizedynamic.Rows[RowIndex].FindControl("chkGrigete_" + i.ToString());
                            CheckBox chckProcess = (CheckBox)grdsizedynamic.Rows[RowIndex].FindControl("chkchckProcess_" + i.ToString());
                            CheckBox FinalPrice = (CheckBox)grdsizedynamic.Rows[RowIndex].FindControl("chkFinalPrice_" + i.ToString());

                            if (chkGrigete.Checked == true)
                            {
                                IsGreige = 1;
                            }
                            else
                            {
                                IsGreige = 0;
                            }
                            if (chckProcess.Checked == true)
                            {
                                IsProcess = 1;
                            }
                            else
                            {
                                IsProcess = 0;
                            }
                            if (FinalPrice.Checked == true)
                            {
                                IsFinish = 1;
                            }
                            else
                            {
                                IsFinish = 0;
                            }

                            int accessory_quality_SizeID = Convert.ToInt32(dtAccSize.Rows[i]["accessory_quality_SizeID"].ToString());
                            string SizeName = DtSizeName.Rows[i]["Size"].ToString();
                            DataTable dt2 = new DataTable();
                            dt2 = onjadminCon.GetAccSizeValue(AccMasterID, SizeName);

                            if (dt2.Rows.Count > 0)
                            {
                                if (dt2.Rows[0]["GreigeRate"].ToString() != "")
                                {
                                    GreigePrice = Convert.ToDouble(dt2.Rows[0]["GreigeRate"].ToString());
                                }
                                if (dt2.Rows[0]["ProcessRate"].ToString() != "")
                                {
                                    ProcessPrice = Convert.ToDouble(dt2.Rows[0]["ProcessRate"].ToString());
                                }
                                if (dt2.Rows[0]["FinishRate"].ToString() != "")
                                {
                                    FinishPrice = Convert.ToDouble(dt2.Rows[0]["FinishRate"].ToString());
                                }
                            }
                            Double D_price = 0;
                            Double D_Finalprice = 0;
                            IsSave = onjadminCon.UpdateAccSupplierSizetable("SIZE", accessoryMasterqualityID, D_price, D_Finalprice, UserId, AccMasterID, accessory_quality_SizeID, SizeName, IsGreige, IsProcess, IsFinish, GreigePrice, ProcessPrice, FinishPrice);

                        }
                    }
                    if (IsSave > 0)
                    {
                        //ShowAlert("Saved Successfully.");           
                        BindHeader();
                        BindHeaderSizeGrd();
                    }
                }
            }

        }

        protected void grdsizedynamic_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //grdsizedynamic.EditIndex = -1;
            //BIndGrid();
        }

        protected void BindHeaderSizeGrd()
        {
            if (AccMasterID > 0)
            {
                DataSet ds = new DataSet();
                ds = onjadminCon.GetAccSizegrd(AccMasterID);
                DataTable dtAccSize = onjadminCon.GetAccSizedetails(16, AccMasterID);
                if (grdsizedynamic.Columns.Count > 0)
                {
                    grdsizedynamic.Columns.Clear();
                }

                if (dtAccSize.Rows.Count > 0)
                {
                    TemplateField Supplier = new TemplateField();
                    Supplier.ItemTemplate = new iKandi.Common.GridViewTemplate("Dropdown", "SupplierName", "SupplierName");
                    Supplier.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    grdsizedynamic.Columns.Insert(0, Supplier);
                    Supplier.ItemStyle.Width = 240;
                    Supplier.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");

                    TemplateField MOQ = new TemplateField();
                    MOQ.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "MOQ", "MOQ");
                    grdsizedynamic.Columns.Insert(1, MOQ);
                    MOQ.ItemStyle.Width = 90;
                    MOQ.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");


                    int Icheck = 0;
                    Count = Convert.ToInt32(dtAccSize.Rows.Count) - 1;
                    totalLoop = Count * 3 + 1;
                    int idchek = 0;
                    if (Convert.ToInt32(dtAccSize.Rows.Count) > 0)
                    {
                        for (int i = 0; i <= Count; i++)
                        {

                            TemplateField ChkGrigete = new TemplateField();
                            ChkGrigete.ItemTemplate = new iKandi.Common.GridViewTemplate("checkbox", "chkGrigete_" + i.ToString(), "chkGrigete_" + i.ToString());
                            ChkGrigete.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                            grdsizedynamic.Columns.Insert(idchek + 2, ChkGrigete);
                            Icheck = i + 2;
                            ChkGrigete.ItemStyle.Width = 60;
                            ChkGrigete.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");



                            TemplateField chckProcess = new TemplateField();
                            chckProcess.ItemTemplate = new iKandi.Common.GridViewTemplate("checkbox", "chkchckProcess_" + i.ToString(), "chkchckProcess_" + i.ToString());
                            chckProcess.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                            grdsizedynamic.Columns.Insert(idchek + 3, chckProcess);
                            Icheck = i + 3;
                            chckProcess.ItemStyle.Width = 60;
                            chckProcess.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");

                            TemplateField chkFinalPrice = new TemplateField();
                            chkFinalPrice.ItemTemplate = new iKandi.Common.GridViewTemplate("checkbox", "chkFinalPrice_" + i.ToString(), "chkFinalPrice_" + i.ToString());
                            chkFinalPrice.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                            grdsizedynamic.Columns.Insert(idchek + 4, chkFinalPrice);
                            Icheck = i + 4;
                            chkFinalPrice.ItemStyle.Width = 60;
                            chkFinalPrice.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");


                            idchek = idchek + 3;
                        }
                    }
                    TemplateField LeadTimeDays = new TemplateField();
                    LeadTimeDays.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "LeadTimeDays", "LeadTimeDays");
                    grdsizedynamic.Columns.Insert(totalLoop + 4, LeadTimeDays);
                    LeadTimeDays.ItemStyle.Width = 50;
                    LeadTimeDays.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");

                    TemplateField UploadTestReport = new TemplateField();
                    UploadTestReport.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "UploadTestReport", "UploadTestReport");
                    grdsizedynamic.Columns.Insert(totalLoop + 5, UploadTestReport);
                    UploadTestReport.ItemStyle.Width = 90;
                    UploadTestReport.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");

                    TemplateField TestDate = new TemplateField();
                    TestDate.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "TestDate", "TestDate");
                    grdsizedynamic.Columns.Insert(totalLoop + 6, TestDate);
                    TestDate.ItemStyle.Width = 90;
                    TestDate.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");

                    TemplateField Uploads = new TemplateField();
                    Uploads.ItemTemplate = new iKandi.Common.GridViewTemplate("text", "Uploads", "Uploads");
                    grdsizedynamic.Columns.Insert(totalLoop + 7, Uploads);
                    Uploads.ItemStyle.Width = 100;
                    Uploads.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");


                    TemplateField UpdateLink = new TemplateField();
                    UpdateLink.ItemTemplate = new iKandi.Common.GridViewTemplate("LinkButton", "Upd", "Upd");
                    grdsizedynamic.Columns.Insert(totalLoop + 8, UpdateLink);
                    UpdateLink.ItemStyle.Width = 50;
                    UpdateLink.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");

                    TemplateField DeleteLink = new TemplateField();
                    DeleteLink.ItemTemplate = new iKandi.Common.GridViewTemplate("LinkButton", "Del", "Del");
                    grdsizedynamic.Columns.Insert(totalLoop + 9, DeleteLink);
                    DeleteLink.ItemStyle.Width = 49;
                    DeleteLink.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
                    LastRowCount = totalLoop + 9;

                    grdsizedynamic.DataSource = ds.Tables[0];
                    grdsizedynamic.DataBind();
                }
                else
                {
                    grdsizedynamic.DataSource = null;
                    grdsizedynamic.DataBind();
                }
            }          
        }

        public void ValidateSupplierName(string FlaglastRow, out string results)
        {
            results = "";

            int Count = 0;
            foreach (GridViewRow row in grdsizedynamic.Rows)
            {
                DropDownList SupplierName = (DropDownList)row.FindControl("SupplierName");
                if (FlaglastRow == "1")
                {
                    Count = 0;
                    foreach (GridViewRow rows in grdsizedynamic.Rows)
                    {
                        DropDownList SupplierNameNext = (DropDownList)rows.FindControl("SupplierName");

                        if (SupplierNameNext.SelectedItem.Text == SupplierName.SelectedItem.Text)
                        {
                            Count += 1;
                            if (Count > 1)
                            {
                                SupplierNameNext.BorderColor = System.Drawing.Color.Red;
                                SupplierNameNext.BorderWidth = 1;
                                results = "Duplicate supplier name not allowed";
                                return;
                            }
                        }
                    }
                }
                else
                {
                    Count = 0;
                    foreach (GridViewRow rows in grdsizedynamic.Rows)
                    {
                        DropDownList SupplierNameNext = (DropDownList)rows.FindControl("SupplierName");

                        if (SupplierNameNext.SelectedItem.Text == SupplierName.SelectedItem.Text)
                        {
                            Count += 1;

                            if (Count > 1)
                            {
                                SupplierNameNext.BorderColor = System.Drawing.Color.Red;
                                SupplierNameNext.BorderWidth = 1;
                                results = "Duplicate supplier name not allowed";
                                return;

                            }
                        }
                    }
                }
            }

        }        

        public void ResetSuppliergrd()
        {
            divsizeheader.InnerHtml = "";
            grdsizedynamic.DataSource = null;
            grdsizedynamic.DataBind();
        }       

        protected void grdsize_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdsize.EditIndex = e.NewEditIndex;
            BindAccSizeGrd();
        }

        protected void grdsize_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdsize.EditIndex = -1;
            BindAccSizeGrd();
            divFinish.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "block";
        }

        protected void grdsize_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Edit"))
            {
                grdsize.EditIndex = -1;
                BindAccSizeGrd();
            }
            divFinish.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "block";
        }

        protected void grdsize_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {           
            try
            {
                TextBox txtsize = grdsize.Rows[grdsize.EditIndex].FindControl("txtsize") as TextBox;
                HiddenField hdnSizes = grdsize.Rows[grdsize.EditIndex].FindControl("hdnSizes") as HiddenField;
                HiddenField hdnaccessory_quality_SizeID = grdsize.Rows[grdsize.EditIndex].FindControl("hdnaccessory_quality_SizeID") as HiddenField;
                TextBox txteditgreige = grdsize.Rows[grdsize.EditIndex].FindControl("txteditgreige") as TextBox;
                TextBox txteditProcess = grdsize.Rows[grdsize.EditIndex].FindControl("txteditProcess") as TextBox;
                TextBox txteditFinish = grdsize.Rows[grdsize.EditIndex].FindControl("txteditFinish") as TextBox;
                HiddenField hdnOptionNo = grdsize.Rows[grdsize.EditIndex].FindControl("hdnOptionNo") as HiddenField;
                
                decimal greige = 0; decimal Process = 0; decimal Finish = 0;
                if (txteditgreige.Text.Trim() != "")
                {
                    greige = Convert.ToDecimal(txteditgreige.Text.Trim());
                }
                if (txteditProcess.Text.Trim() != "")
                {
                    Process = Convert.ToDecimal(txteditProcess.Text.Trim());
                }
                if (txteditFinish.Text.Trim() != "")
                {
                    Finish = Convert.ToDecimal(txteditFinish.Text.Trim());
                }

                int OptionNo = hdnOptionNo.Value == "" ? 0 : Convert.ToInt32(hdnOptionNo.Value);
                string SizeVal = txtsize.Text.Trim();
                int iSave = onjadminCon.UpdateAccSize(12, AccMasterID, SizeVal, hdnSizes.Value, greige, Process, Finish, OptionNo, UserId);

                grdsize.EditIndex = -1;

                txtsizeAdd.Text = "";
                BindAccSizeGrd();
                BindHeader();
                BindHeaderSizeGrd();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                ShowAlert("Some error occured during update.");
                return;
            }
            divFinish.Attributes.CssStyle[HtmlTextWriterStyle.Display] = "block";

        }

        protected void grdsize_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                TextBox txteditgreige = (TextBox)e.Row.FindControl("txteditgreige");
                TextBox txteditProcess = (TextBox)e.Row.FindControl("txteditProcess");
                TextBox txteditFinish = (TextBox)e.Row.FindControl("txteditFinish");
                TextBox txtsize = (TextBox)e.Row.FindControl("txtsize");
                HiddenField hdnClientId = (HiddenField)e.Row.FindControl("hdnClientId");

                if (DataBinder.Eval(e.Row.DataItem, "IsAccSizeUsing").ToString() == "0")
                {
                    //e.Row.Enabled = false;
                    e.Row.ToolTip = "You cannot delete this accessory size becasue already associated with costing and design form";

                }
                if (txteditgreige.Text != "" && txteditgreige.Text != "0")
                {
                    //txteditProcess.Attributes.Remove("disabled");
                    txteditProcess.Enabled = true;
                }
                else
                {
                    txteditgreige.Text = "";
                }

            }
            else
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblgreige = (Label)e.Row.FindControl("lblgreige");
                    Label lblprocess = (Label)e.Row.FindControl("lblprocess");
                    Label lblFinish = (Label)e.Row.FindControl("lblFinish");
                    LinkButton btnedit = (LinkButton)e.Row.FindControl("btnedit");
                    LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");                  
                    //if (IsDefault == true)
                    //{
                    //    txtsizeAdd.Text = "Default";
                    //}                   
                    if (lblgreige.Text == "0")
                    {
                        lblgreige.Text = "";
                    }
                    if (lblprocess.Text == "0")
                    {
                        lblprocess.Text = "";
                    }
                    if (lblFinish.Text == "0")
                    {
                        lblFinish.Text = "";
                    }
                    btnedit.Visible = true;
                    lnkDelete.Visible = true;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
               

    }
}