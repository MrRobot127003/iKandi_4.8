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
    public partial class UserfrmGarmenttype : System.Web.UI.UserControl
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
            DataSet ds = objAdminController.GetGarmentsTypeBAL();//here
            grdGarments.DataSource = ds.Tables[0];
            grdGarments.DataBind();

        }
        protected void grdGarments_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdGarments.EditIndex = -1;

            bindgrd();
        }

        protected void grdGarments_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            AdminController objAdminController = new AdminController();
            GridViewRow Rows = grdGarments.Rows[e.RowIndex];

            HiddenField hdnGarmentTypeID = Rows.FindControl("hdnGarmentTypeID") as HiddenField;
            TextBox txt_GarmentType = Rows.FindControl("txt_GarmentType") as TextBox;
            //Label txtCurrencySymbol = Rows.FindControl("txtCurrencySymbol") as Label;
            TextBox txt_GarmentDescription = Rows.FindControl("txt_GarmentDescription") as TextBox;



            int id = Convert.ToInt32(hdnGarmentTypeID.Value);



            int Result;

            Result = objAdminController.UpdateGarmentsBAL(txt_GarmentType.Text, txt_GarmentDescription.Text, CurrentLoggedInUserID, id);
            if (Result == 3)
            {

                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Garment type already exists','Garment Types');";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                grdGarments.EditIndex = -1;
                bindgrd();
                
            }
            if (Result> 0)
            {
               
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Garment type updated successfully','Garment Types');";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);

                grdGarments.EditIndex = -1;
                bindgrd();

            }
            else
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Record Not updated ','Garment Types');";
                // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                grdGarments.EditIndex = -1;
                bindgrd();

            }



        }

        protected void grdGarments_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdGarments.EditIndex = e.NewEditIndex;

            bindgrd();

            GridViewRow Rows = grdGarments.Rows[e.NewEditIndex];

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            AdminController objAdminController = new AdminController();


            int result = objAdminController.InsertUpdateGarmentsBAL(txtgarmenttype.Value.Trim(), txtdiscription.Value.Trim(), CurrentLoggedInUserID);
            if (result ==3)
            {

                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Garment type already exists','Garment Types');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "RestControlVal();", true);
                txtgarmenttype.Value = "";
                txtdiscription.Value = "";
                txtgarmenttype.Focus();

               

            }
            if (result == 1)
            {

                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Garment type save successfully','Garment Types');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "RestControlVal();", true);
                txtgarmenttype.Value = "";
                txtdiscription.Value = "";
                txtgarmenttype.Focus();

                bindgrd();

            }
            else
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Garment type not Save .','Garment Types');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                // Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "RestControlVal();", true);
                txtgarmenttype.Value = "";
                txtdiscription.Value = "";
                txtgarmenttype.Focus();

                bindgrd();

            }




        }

        protected void grdGarments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void grdGarments_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            
        }

        protected void grdGarments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            bindgrd();
            grdGarments.PageIndex = e.NewPageIndex;
            grdGarments.DataBind(); 
        }
    }
}
