using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;
using iKandi.Web.Components;
using iKandi.Common;

namespace iKandi.Web.Admin
{
    public partial class QCAdmin : System.Web.UI.Page
    {
        AdminController objAdminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //BindDDL();                
                BindGrid();
            }
        }
        protected void BindGrid()
        {
            
            DataTable dt = new DataTable();
            dt = objAdminController.GetQCAdmin(txtSearch.Text.Trim());
            
            if (dt.Rows.Count > 0)
            {
                grdQCAdmin.DataSource = dt;
                grdQCAdmin.DataBind();
            }
        }

        //protected void BindDDL()
        //{
        //    DataTable dt = objAdminController.GetLineDesignation("QC");
        //    if (dt.Rows.Count > 0)
        //    {
        //        ddlQCType.DataSource = dt;
        //        ddlQCType.DataTextField = "Name";
        //        ddlQCType.DataValueField = "LineDesignationID";
        //        ddlQCType.DataBind();

        //        ddlQCTypeSearch.DataSource = dt;
        //        ddlQCTypeSearch.DataTextField = "Name";
        //        ddlQCTypeSearch.DataValueField = "LineDesignationID";
        //        ddlQCTypeSearch.DataBind();
        //        ddlQCTypeSearch.Items.Insert(0, new ListItem("Select", "-1"));
        //    }
        //}

        protected void btnAdd_Empty_Click(object sender, ImageClickEventArgs e)
        {
            int gridRowCount = grdQCAdmin.Rows.Count;
            if (txtQCName.Text == string.Empty)
            {
                ShowAlert("QC Name cannot empty!");
                return;
            }

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;          

            int iSave = objAdminController.SaveQCAdmin(-1, txtQCName.Text.Trim(), cbIsActive.Checked == true ? true : false, "Save", UserId);
            txtQCName.Text = string.Empty;            
            cbIsActive.Checked = false;
            BindGrid();
        }

        protected void grdQCAdmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdQCAdmin.EditIndex = e.NewEditIndex;
            BindGrid();
        }
        protected void grdQCAdmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdQCAdmin.EditIndex = -1;
            BindGrid();
        }
        protected void grdQCAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int rowindex = e.RowIndex;
            GridViewRow Rows = grdQCAdmin.Rows[e.RowIndex];

            HiddenField hdnQCId = (HiddenField)Rows.FindControl("hdnQCId");            
            CheckBox cbIsActiveEdit = (CheckBox)Rows.FindControl("cbIsActive");
            TextBox txtQCName = (TextBox)Rows.FindControl("txtQCName");

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            if (txtQCName.Text == "")
            {
                ShowAlert("Name can not be Empty");
                return;
            }
            else
            {
                for (int i = 0; i < grdQCAdmin.Rows.Count; i++ )
                {
                    if (i != rowindex)
                    {
                        Label lblQCName = (Label)grdQCAdmin.Rows[i].FindControl("lblQCName");
                        if (txtQCName.Text.Trim().ToLower() == lblQCName.Text.Trim().ToLower())
                        {
                            ShowAlert("This QC already exist, Please update new");
                            return;
                        }
                    }

                }
            }

            int iSave = objAdminController.SaveQCAdmin(Convert.ToInt32(hdnQCId.Value), txtQCName.Text, cbIsActiveEdit.Checked == true ? true : false, "Update", UserId);
            grdQCAdmin.EditIndex = -1;
            BindGrid();
        }

        //protected void grdQCAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        HiddenField hdnQCType = (HiddenField)e.Row.FindControl("hdnQCType");
        //        DropDownList ddlQCType = (DropDownList)e.Row.FindControl("ddlQCType");

        //        DataTable dt = objAdminController.GetLineDesignation("QC");
        //        ddlQCType.DataSource = dt;
        //        ddlQCType.DataTextField = "Name";
        //        ddlQCType.DataValueField = "LineDesignationID";
        //        ddlQCType.DataBind();

        //        ddlQCType.SelectedValue = hdnQCType.Value;
        //    }
        //}

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        
    }
}