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
using System.IO;
using System.Globalization;

namespace iKandi.Web.UserControls.Forms
{
    public partial class FrmUserAttachment : System.Web.UI.UserControl
    {
        int CurrentLoggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)

                bindgrd();
        }
        public void bindgrd()
        {

            AdminController objAdminController = new AdminController();
            DataSet ds = objAdminController.Getattchmentdetails();

            grdCurrency.DataSource = ds.Tables[0];
            grdCurrency.DataBind();

        }
        protected void grdCurrency_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCurrency.EditIndex = -1;

            bindgrd();
        }
        protected void grdCurrency_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            AdminController objAdminController = new AdminController();
            GridViewRow Rows = grdCurrency.Rows[e.RowIndex];

            HiddenField hdnworkerType = Rows.FindControl("hdnattchemntID") as HiddenField;
            TextBox txtAttchment = Rows.FindControl("txtatt") as TextBox;

            TextBox txtName = Rows.FindControl("txtName") as TextBox;
            TextBox txtDiscription = Rows.FindControl("txtDiscription") as TextBox;



            int id = Convert.ToInt32(hdnworkerType.Value);



            int Result;

            Result = objAdminController.UpdateAttchmentBAL(txtAttchment.Text.Trim(), txtDiscription.Text.Trim(), CurrentLoggedInUserID, id);
            if (Result == 3)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Attachment name already exists','Attachment form');";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);


            }
            if (Result > 0)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Attachment name updated successfully','Attachment form');";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);


            }
            else
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Attachment name not updated','Attachment form');";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                //grdCurrency.EditIndex = -1;
            }


            grdCurrency.EditIndex = -1;
            bindgrd();

        }
        protected void grdCurrency_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCurrency.EditIndex = e.NewEditIndex;

            bindgrd();

            //GridViewRow Rows = grdCurrency.Rows[e.NewEditIndex];

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            AdminController objAdminController = new AdminController();


            int result = objAdminController.InsertAttchmentBAL(txtattachment1.Value.Trim(), txtDiscription1.Value.Trim(), CurrentLoggedInUserID);
            if (result == 3)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Attachment already exists','Attachment form');";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                txtattachment1.Value = "";

                txtDiscription1.Value = "";
                txtattachment1.Focus();

                bindgrd();

            }
            if (result > 0)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Attachment save successfully','Attachment form');";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                txtattachment1.Value = "";

                txtDiscription1.Value = "";
                txtattachment1.Focus();

                bindgrd();

            }
            else
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Record  not save .','Attachment form');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                txtattachment1.Value = "";

                txtDiscription1.Value = "";
                txtattachment1.Focus();

                bindgrd();

            }


        }

        protected void grdCurrency_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdCurrency_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            bindgrd();
            grdCurrency.PageIndex = e.NewPageIndex;
            grdCurrency.DataBind();
        }

    }
}