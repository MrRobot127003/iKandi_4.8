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
    public partial class frmUserOBSection : System.Web.UI.UserControl
    {
        int CurrentLoggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgrd();

            }
        }
        public void bindgrd()
        {

            AdminController objAdminController = new AdminController();
            DataSet ds = objAdminController.GetOBSectionBAL();//here
            grdOb.DataSource = ds.Tables[0];
            grdOb.DataBind();

        }
        protected void grdOb_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdOb.EditIndex = -1;

            bindgrd();
        }
        protected void grdOb_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            AdminController objAdminController = new AdminController();
            GridViewRow Rows = grdOb.Rows[e.RowIndex];

            HiddenField hdnOBSectionID = Rows.FindControl("hdnOBSectionID") as HiddenField;
            TextBox txt_OBSection = Rows.FindControl("txt_OBSection") as TextBox;
            //Label txtCurrencySymbol = Rows.FindControl("txtCurrencySymbol") as Label;
            TextBox txt_SectionDescription = Rows.FindControl("txt_SectionDescription") as TextBox;



            int id = Convert.ToInt32(hdnOBSectionID.Value);

            

            int Result;

            Result = objAdminController.UpdateOBSectionBAL(txt_OBSection.Text.Trim(), txt_SectionDescription.Text.Trim(), CurrentLoggedInUserID, id);
            if (Result ==3)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Section name already exists','Cutting Ob form');";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                grdOb.EditIndex = -1;
                bindgrd();

            }
            if (Result>0)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Section name updated successfully','Cutting Ob form');";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                grdOb.EditIndex = -1;
                bindgrd();

            }
            else
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Record not save','Cutting Ob form');";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                grdOb.EditIndex = -1;
                bindgrd();

            }



        }
        protected void grdOb_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdOb.EditIndex = e.NewEditIndex;

            bindgrd();

            GridViewRow Rows = grdOb.Rows[e.NewEditIndex];

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            AdminController objAdminController = new AdminController();


            int result = objAdminController.InsertOBSectionBAL(txtSection.Value.Trim(), txtdiscription.Value.Trim(), CurrentLoggedInUserID);
            if (result == 3)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Section name already exists','Cutting Ob form');";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                grdOb.EditIndex = -1;
                bindgrd();

            }
            if (result ==1 )
            {

                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Section save successfully','Cutting Ob form');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "RestControlVal();", true);
                txtSection.Value = "";
                txtdiscription.Value = "";
                txtSection.Focus();

                bindgrd();

            }

            else
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Record  not Save .','Cutting Ob form');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                // Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "RestControlVal();", true);
                txtSection.Value = "";
                txtdiscription.Value = "";
                txtSection.Focus();

                bindgrd();

            }




        }
        protected void grdOb_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType != DataControlRowType.DataRow)
            //    return;
            //RadioButtonList rbtnPriceQuoted1 = (RadioButtonList)e.Row.FindControl("rbtnPriceQuoted1");
            //HiddenField hdnPriceQuoted = (HiddenField)e.Row.FindControl("hdnPriceQuoted");
            //if (hdnPriceQuoted != null)
            //{

            //    if (hdnPriceQuoted.Value == "True")
            //    {
            //        rbtnPriceQuoted1.SelectedValue = "1";
            //    }
            //    else
            //    {
            //        rbtnPriceQuoted1.SelectedValue = "0";
            //    }


            //    if (rbtnPriceQuoted1 != null)
            //    {
            //        rbtnPriceQuoted1.Enabled = false;
            //    }
        }
        protected void grdOb_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {


        }
        protected void grdOb_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            bindgrd();
            grdOb.PageIndex = e.NewPageIndex;
            grdOb.DataBind();
        }





    }
}