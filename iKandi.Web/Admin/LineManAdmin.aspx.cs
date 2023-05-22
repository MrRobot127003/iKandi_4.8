using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;
using iKandi.Web.Components;

namespace iKandi.Web.Admin
{
    public partial class LineManAdmin : System.Web.UI.Page
    {
        AdminController objAdminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (!Page.IsPostBack)
            {
                BindDDL();
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objAdminController.GetLineManAdmin(txtSearch.Text.Trim(), Convert.ToInt32(ddlLineManTypeSearch.SelectedValue));
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdLineManAdmin.DataSource = dt;
                grdLineManAdmin.DataBind();
            }
        }

        protected void btnAdd_Empty_Click(object sender, ImageClickEventArgs e)
        {
           
            if (txtLineManName.Text == string.Empty)
                ShowAlert("LineMan Name cannot empty!");
            

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            //int UserId = 646;

            int iSave = objAdminController.SaveLineManAdmin(txtLineManName.Text.Trim(), ddlLineManType.SelectedValue, cbIsActive.Checked == true ? true : false, "Save", UserId);
            txtLineManName.Text = string.Empty;            
            cbIsActive.Checked = false;
            BindGrid();
        }

        protected void grdLineManAdmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdLineManAdmin.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void grdLineManAdmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdLineManAdmin.EditIndex = -1;
            BindGrid();
        }

        protected void grdLineManAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdLineManAdmin.Rows[e.RowIndex];

            HiddenField hdnId = (HiddenField)Rows.FindControl("hdnId");
            DropDownList ddlLineManTypeEdit = (DropDownList)Rows.FindControl("ddlLineManType");
            CheckBox cbIsActiveEdit = (CheckBox)Rows.FindControl("cbIsActive");

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            // int UserId = 646;

            int iSave = objAdminController.SaveLineManAdmin(hdnId.Value, ddlLineManTypeEdit.SelectedValue, cbIsActiveEdit.Checked == true ? true : false, "Update", UserId);
            grdLineManAdmin.EditIndex = -1;
            BindGrid();
        }

        protected void grdLineManAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnLineManType = (HiddenField)e.Row.FindControl("hdnLineManType");
                DropDownList ddlLineManType = (DropDownList)e.Row.FindControl("ddlLineManType");

                DataTable dt = objAdminController.GetLineDesignation("Line");
                ddlLineManType.DataSource = dt;
                ddlLineManType.DataTextField = "Name";
                ddlLineManType.DataValueField = "LineDesignationID";
                ddlLineManType.DataBind();

                ddlLineManType.SelectedValue = hdnLineManType.Value;
            }
        }

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

        protected void BindDDL()
        {
            DataTable dt = objAdminController.GetLineDesignation("Line");
            if (dt.Rows.Count > 0)
            {
                ddlLineManType.DataSource = dt;
                ddlLineManType.DataTextField = "Name";
                ddlLineManType.DataValueField = "LineDesignationID";
                ddlLineManType.DataBind();

                ddlLineManTypeSearch.DataSource = dt;
                ddlLineManTypeSearch.DataTextField = "Name";
                ddlLineManTypeSearch.DataValueField = "LineDesignationID";
                ddlLineManTypeSearch.DataBind();
                ddlLineManTypeSearch.Items.Insert(0, new ListItem("Select", "-1"));
            }
        }
        

    }
}