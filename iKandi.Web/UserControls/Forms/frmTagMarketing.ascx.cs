using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;
using iKandi.Web.Components;

namespace iKandi.Web.UserControls.Forms
{
    public partial class frmTagMarketing : System.Web.UI.UserControl
    {
        AdminController objAdminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objAdminController.GetMarketingAdmin(txtSearch.Text.Trim());
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdMarketingAdmin.DataSource = dt;
                grdMarketingAdmin.DataBind();
            }
        }


        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void btnAdd_Marketing_Click(object sender, ImageClickEventArgs e)
        {

            if (txMarketingName.Text == "")
            {
                ShowAlert("Marketing cannot empty!");

                return;
            }

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            //int UserId = 646;

            int iSave = objAdminController.SaveMarketingAdmin(txMarketingName.Text.Trim(), cbIsActive.Checked == true ? true : false, "Save", UserId);
            if (iSave > 0)
            {
            }
            else
            {
                string message = "Duplicate record found!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
            }
            txMarketingName.Text = string.Empty;
            cbIsActive.Checked = false;
            BindGrid();

        }

        protected void grdMarketingAdmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdMarketingAdmin.EditIndex = e.NewEditIndex;
            BindGrid();

        }

        protected void grdMarketingAdmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdMarketingAdmin.EditIndex = -1;
            BindGrid();
        }


        protected void grdMarketingAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdMarketingAdmin.Rows[e.RowIndex];

            HiddenField hdnId = (HiddenField)Rows.FindControl("hdnId");
            TextBox txtMarketingName = (TextBox)Rows.FindControl("txtMarketingName");
            CheckBox cbIsActiveEdit = (CheckBox)Rows.FindControl("cbIsActive");

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            // int UserId = 646;

            int iSave = objAdminController.SaveMarketingAdmin1(Convert.ToInt32(hdnId.Value), txtMarketingName.Text, cbIsActiveEdit.Checked == true ? true : false, "Update", UserId);
            if (iSave > 0)
            {
            }

            else
            {
                string message = "Duplicate record found!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
            }
            grdMarketingAdmin.EditIndex = -1;
            BindGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}