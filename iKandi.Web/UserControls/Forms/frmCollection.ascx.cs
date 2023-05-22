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
    public partial class frmCollection : System.Web.UI.UserControl
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
            ds = objAdminController.GetCollectionAdmin(txtSearch.Text.Trim());
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdCollectionAdmin.DataSource = dt;
                grdCollectionAdmin.DataBind();
            }

        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void grdCollectionAdmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCollectionAdmin.EditIndex = -1;
            BindGrid();
        }


        protected void grdCollectionAdmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCollectionAdmin.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void grdCollectionAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = grdCollectionAdmin.Rows[e.RowIndex];

            HiddenField hdnId = (HiddenField)Rows.FindControl("hdnId");
            TextBox txCollectionName = (TextBox)Rows.FindControl("txCollectionName");
            CheckBox cbIsActiveEdit = (CheckBox)Rows.FindControl("cbIsActive");

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            // int UserId = 646;

            int iSave = objAdminController.SaveCollectionMarketingAdmin1(Convert.ToInt32(hdnId.Value), txCollectionName.Text, cbIsActiveEdit.Checked == true ? true : false, "Update", UserId);
            
            if (iSave > 0)
            {
            }

            else
            {
                string message = "Duplicate record found!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
                
            }
            grdCollectionAdmin.EditIndex = -1;
            BindGrid();
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnAdd_Marketing_Click(object sender, ImageClickEventArgs e)
        {
            if (txCollectionName.Text == "")
            {
                ShowAlert("Collection cannot empty!");
                return;
            }

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            //int UserId = 646;

            int iSave = objAdminController.SaveCollectionMarketingAdmin(txCollectionName.Text.Trim(), cbIsActive.Checked == true ? true : false, "Save", UserId);
            if (iSave > 0)
            {
            }
            else
            {
                string message = "Duplicate record found!";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + message + "');", true);
            }
            txCollectionName.Text = string.Empty;
            cbIsActive.Checked = false;
            BindGrid();
        }
    }
}