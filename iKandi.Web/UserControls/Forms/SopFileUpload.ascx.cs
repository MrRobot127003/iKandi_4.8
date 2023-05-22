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
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;
using System.Collections.Generic;

namespace iKandi.Web.UserControls.Forms
{
    public partial class SopFileUpload : System.Web.UI.UserControl
    {
        String ProductionFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"];
        AdminController objadmin = new AdminController();
        PermissionController objPermissionController = new PermissionController();
        bool PermissionFlag = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");
            UserPermission();
            if (!IsPostBack)
            {
                
                bindgrd();
            }

        }

        private void UserPermission()
        {
            DataTable dtLabspecimen = objPermissionController.GetSOPPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, 141).Tables[0];

            if (dtLabspecimen.Rows.Count > 0)
            {
                //LinkButton lnkDelete = (LinkButton)grdshopedit.FindControl("lnkDelete");
                if (Convert.ToBoolean(dtLabspecimen.Rows[0]["PermisionWrite"]) == true)
                {
                    PermissionFlag = true; 
                    btnsubmit.Enabled = true;
                    fileUpload.Enabled = true;
                    ddlTypeEntry.Enabled = true;
                }
                else
                {
                    btnsubmit.Enabled = false;
                    fileUpload.Enabled = false;
                    ddlTypeEntry.Enabled = false;
                }
            }
        }

        public void bindgrd()
        {
            DataSet ds = objadmin.GetShopDetails();
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            DataTable dt2 = ds.Tables[2];
            if (dt.Rows.Count > 0) {
                grdshopedit.DataSource = dt;
                grdshopedit.DataBind();
            }
            if (dt1.Rows.Count > 0)
            {
                grdkipedit.DataSource = dt1;
                grdkipedit.DataBind();
            }
            if (dt2.Rows.Count > 0)
            {
                grdPolicyedit.DataSource = dt2;
                grdPolicyedit.DataBind();
            }
         

        }
        protected void grdshopedit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

            if (e.CommandName == "Edit")
            {
                Table tblGrdviewApplet = (Table)grdshopedit.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];

                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                //Label lbOrderId = (Label)gvRow.FindControl("ansLabel");

                FileUpload fileuploadgrd = (FileUpload)gvRow.FindControl("fileuploadgrd");
                HiddenField hdnfilename = (HiddenField)gvRow.FindControl("hdnfilename");
                HiddenField hdnshopId = (HiddenField)gvRow.FindControl("hdnshopId");
                TextBox txtShopNameGrd = (TextBox)gvRow.FindControl("txtShopNameGrd");
                //DropDownList ddlType = (DropDownList)gvRow.FindControl("ddlType");

                if (!fileuploadgrd.HasFile && hdnfilename.Value.Trim().Length == 0)
                {
                    ShowAlert("Please select file");
                    return;
                }

                //if (ddlType.SelectedValue == "0")
                //{
                //    ShowAlert("Please select Type");
                //    return;
                //}
                if (txtShopNameGrd.Text == "")
                {
                    ShowAlert("Please Insert Name");
                    return;
                }
                string filename = string.Empty;
                if (fileuploadgrd.HasFile)
                {


                    filename = "SOP_" + fileuploadgrd.FileName;


                    fileuploadgrd.SaveAs(Server.MapPath(ProductionFolderPath) + filename);

                    //hlkViewSnap1.Visible = true;
                    //hlkViewSnap1.NavigateUrl = (string.IsNullOrEmpty(objProductionUnit.FileUploadUrl1)) ? "" : ProductionFolderPath + objProductionUnit.FileUploadUrl1;
                    // objProductionUnit.FileUploadUrl1 = fileNameStyle1;
                }
                else if (hdnfilename.Value.Trim().Length > 0)
                {
                    filename = hdnfilename.Value;  
                }
                int Result = objadmin.InsertUpdateShop(Convert.ToString(txtShopNameGrd.Text), filename, Convert.ToInt32(hdnshopId.Value), "UPDATED", UserID,-1);
                if (Result > 0)
                {
                    ShowAlert("Record Updated successfully");
                }
                else
                {
                    ShowAlert("Record not added please check again! may be you are using duplicate Name or connection lost.");
                }

            }
            grdshopedit.EditIndex = -1;
            bindgrd(); 


        }
        protected void grdshopedit_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HyperLink hlkViewSnap1 = (HyperLink)e.Row.FindControl("hlkViewSnap1");
                HiddenField hdnfilename = (HiddenField)e.Row.FindControl("hdnfilename");
                Label lbllastmodifiedgrd = (Label)e.Row.FindControl("lbllastmodifiedgrd");
                //DropDownList ddlType = (DropDownList)e.Row.FindControl("ddlType");
                //HiddenField hdnTypeId = (HiddenField)e.Row.FindControl("hdnTypeId");

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                FileUpload fileuploadgrd = (FileUpload)e.Row.FindControl("fileuploadgrd");
                fileuploadgrd.Enabled = PermissionFlag == true ? true : false; 
                lnkDelete.Enabled = PermissionFlag == true ? true : false;                


                hlkViewSnap1.NavigateUrl = hdnfilename.Value == "" ? "" : ProductionFolderPath + hdnfilename.Value;

                lbllastmodifiedgrd.Text = Convert.ToDateTime(lbllastmodifiedgrd.Text).ToString("dd MMM yy (ddd)");

                //ddlType.SelectedValue = hdnTypeId.Value;


            }
        }
     //code update by bhrat on 26-Aug
        protected void grdkipedit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

            if (e.CommandName == "Edit")
            {
                Table tblGrdviewApplet = (Table)grdshopedit.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];

                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                //Label lbOrderId = (Label)gvRow.FindControl("ansLabel");

                FileUpload fileuploadgrd = (FileUpload)gvRow.FindControl("fileuploadgrd");
                HiddenField hdnfilename = (HiddenField)gvRow.FindControl("hdnfilename");
                HiddenField hdnshopId = (HiddenField)gvRow.FindControl("hdnshopId");
                TextBox txtShopNameGrd = (TextBox)gvRow.FindControl("txtShopNameGrd");
                //DropDownList ddlType = (DropDownList)gvRow.FindControl("ddlType");

                if (!fileuploadgrd.HasFile && hdnfilename.Value.Trim().Length == 0)
                {
                    ShowAlert("Please select file");
                    return;
                }

                //if (ddlType.SelectedValue == "0")
                //{
                //    ShowAlert("Please select Type");
                //    return;
                //}
                if (txtShopNameGrd.Text == "") {
                    ShowAlert("Please Insert Name");
                    return;
                }
                string filename = string.Empty;
                if (fileuploadgrd.HasFile)
                {


                    filename = "SOP_" + fileuploadgrd.FileName;


                    fileuploadgrd.SaveAs(Server.MapPath(ProductionFolderPath) + filename);

                    //hlkViewSnap1.Visible = true;
                    //hlkViewSnap1.NavigateUrl = (string.IsNullOrEmpty(objProductionUnit.FileUploadUrl1)) ? "" : ProductionFolderPath + objProductionUnit.FileUploadUrl1;
                    // objProductionUnit.FileUploadUrl1 = fileNameStyle1;
                }
                else if (hdnfilename.Value.Trim().Length > 0)
                {
                    filename = hdnfilename.Value;
                }
                int Result = objadmin.InsertUpdateShop(Convert.ToString(txtShopNameGrd.Text), filename, Convert.ToInt32(hdnshopId.Value), "UPDATED", UserID,-1);
                if (Result > 0)
                {
                    ShowAlert("Record Updated successfully");
                }
                else
                {
                    ShowAlert("Record not added please check again! may be you are using duplicate Name or connection lost.");
                }

            }
            grdkipedit.EditIndex = -1;
            bindgrd();


        }
        protected void grdkipedit_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HyperLink hlkViewSnap1 = (HyperLink)e.Row.FindControl("hlkViewSnap1");
                HiddenField hdnfilename = (HiddenField)e.Row.FindControl("hdnfilename");
                Label lbllastmodifiedgrd = (Label)e.Row.FindControl("lbllastmodifiedgrd");
                //DropDownList ddlType = (DropDownList)e.Row.FindControl("ddlType");
                //HiddenField hdnTypeId = (HiddenField)e.Row.FindControl("hdnTypeId");

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                FileUpload fileuploadgrd = (FileUpload)e.Row.FindControl("fileuploadgrd");
                fileuploadgrd.Enabled = PermissionFlag == true ? true : false; 
                lnkDelete.Enabled = PermissionFlag == true ? true : false;
                

                hlkViewSnap1.NavigateUrl = hdnfilename.Value == "" ? "" : ProductionFolderPath + hdnfilename.Value;

                lbllastmodifiedgrd.Text = Convert.ToDateTime(lbllastmodifiedgrd.Text).ToString("dd MMM yy (ddd)");

                //ddlType.SelectedValue = hdnTypeId.Value;


            }
        }

        protected void grdPolicyedit_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

            if (e.CommandName == "Edit")
            {
                Table tblGrdviewApplet = (Table)grdshopedit.Controls[0];
                GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];

                GridViewRow gvRow = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                //Label lbOrderId = (Label)gvRow.FindControl("ansLabel");

                FileUpload fileuploadgrd = (FileUpload)gvRow.FindControl("fileuploadgrd");
                HiddenField hdnfilename = (HiddenField)gvRow.FindControl("hdnfilename");
                HiddenField hdnshopId = (HiddenField)gvRow.FindControl("hdnshopId");
                TextBox txtShopNameGrd = (TextBox)gvRow.FindControl("txtShopNameGrd");
                //DropDownList ddlType = (DropDownList)gvRow.FindControl("ddlType");

                if (!fileuploadgrd.HasFile && hdnfilename.Value.Trim().Length == 0)
                {
                    ShowAlert("Please select file");
                    return;
                }

                //if (ddlType.SelectedValue == "0")
                //{
                //    ShowAlert("Please select Type");
                //    return;
                //}

                string filename = string.Empty;
                if (fileuploadgrd.HasFile)
                {


                    filename = "SOP_" + fileuploadgrd.FileName;


                    fileuploadgrd.SaveAs(Server.MapPath(ProductionFolderPath) + filename);

                    //hlkViewSnap1.Visible = true;
                    //hlkViewSnap1.NavigateUrl = (string.IsNullOrEmpty(objProductionUnit.FileUploadUrl1)) ? "" : ProductionFolderPath + objProductionUnit.FileUploadUrl1;
                    // objProductionUnit.FileUploadUrl1 = fileNameStyle1;
                }
                else if (hdnfilename.Value.Trim().Length > 0)
                {
                    filename = hdnfilename.Value;
                }
                int Result = objadmin.InsertUpdateShop(Convert.ToString(txtShopNameGrd.Text), filename, Convert.ToInt32(hdnshopId.Value), "UPDATED", UserID,-1);
                if (Result > 0)
                {
                    ShowAlert("Record Updated successfully");
                }
                else
                {
                    ShowAlert("Record not added please check again! may be you are using duplicate Name or connection lost.");
                }

            }
            grdkipedit.EditIndex = -1;
            bindgrd();


        }
        protected void grdPolicyedit_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HyperLink hlkViewSnap1 = (HyperLink)e.Row.FindControl("hlkViewSnap1");
                HiddenField hdnfilename = (HiddenField)e.Row.FindControl("hdnfilename");
                Label lbllastmodifiedgrd = (Label)e.Row.FindControl("lbllastmodifiedgrd");
                //DropDownList ddlType = (DropDownList)e.Row.FindControl("ddlType");
                //HiddenField hdnTypeId = (HiddenField)e.Row.FindControl("hdnTypeId");

                LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
                FileUpload fileuploadgrd = (FileUpload)e.Row.FindControl("fileuploadgrd");
                fileuploadgrd.Enabled = PermissionFlag == true ? true : false; 
                lnkDelete.Enabled = PermissionFlag == true ? true : false; 

                hlkViewSnap1.NavigateUrl = hdnfilename.Value == "" ? "" : ProductionFolderPath + hdnfilename.Value;

                lbllastmodifiedgrd.Text = Convert.ToDateTime(lbllastmodifiedgrd.Text).ToString("dd MMM yy (ddd)");

                //ddlType.SelectedValue = hdnTypeId.Value;


            }
        } 
     //end   
        
        protected void btnsubmit_Click(object sender, EventArgs e)
        {

            string Username = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            int UserID = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.UserID;

            string filename = string.Empty;
            string sopname = txtsopname.Text;
            if (txtsopname.Text == "")
            {
                ShowAlert("Please enter name");
                return;
            }
            if (!fileUpload.HasFile)
            {
                ShowAlert("Please select file");
                return;
            }
            if (ddlTypeEntry.SelectedValue == "0")
            {
                ShowAlert("Please select Type");
                return;
            }
            if (fileUpload.HasFile)
            {


                filename = "SOP_" + fileUpload.FileName;


                fileUpload.SaveAs(Server.MapPath(ProductionFolderPath) + filename);

                //hlkViewSnap1.Visible = true;
                //hlkViewSnap1.NavigateUrl = (string.IsNullOrEmpty(objProductionUnit.FileUploadUrl1)) ? "" : ProductionFolderPath + objProductionUnit.FileUploadUrl1;
                // objProductionUnit.FileUploadUrl1 = fileNameStyle1;
            }
            int Result = objadmin.InsertUpdateShop(txtsopname.Text.Trim(), filename, 0, "INSERT", UserID, Convert.ToInt32(ddlTypeEntry.SelectedValue));

            if (Result > 0)
            {
                ShowAlert("Record added successfully");
                txtsopname.Text = "";
                //Response.Redirect("../../Internal/OrderProcessing/frmMO.aspx");
            }
            else
            {
                ShowAlert("Record not added please check again! may be you are using duplicate Name or connection lost.");
            }

            bindgrd(); 

        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        protected void grdshopedit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //GridView1.EditIndex = e.NewEditIndex;
            //BindGrid();
        }
        //code update by bhrat on 26-Aug
        protected void grdkipedit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //GridView1.EditIndex = e.NewEditIndex;
            //BindGrid();
        }
        protected void grdPolicyedit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //GridView1.EditIndex = e.NewEditIndex;
            //BindGrid();
        }
    //end
    }
}