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
    public partial class CurrencyAdmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                bindgrd();

        }
        public void bindgrd()
        {

            AdminController objAdminController = new AdminController();
            DataSet ds = objAdminController.GetCurrencyBAL();
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

            HiddenField hdid = Rows.FindControl("hdnId") as HiddenField;
            TextBox txtCurrencyType = Rows.FindControl("txtCurrencyType") as TextBox;
            Label txtCurrencySymbol = Rows.FindControl("txtCurrencySymbol") as Label;
            TextBox txtConversionRate = Rows.FindControl("txtConversionRate") as TextBox;
            TextBox txtExportConversionRate = Rows.FindControl("txtExportConversionRate") as TextBox;
            RadioButtonList rbtnPriceQuotedEdit = Rows.FindControl("rbtnPriceQuotedEdit") as RadioButtonList;
            bool IsPriceQuoted;
            if (rbtnPriceQuotedEdit.SelectedValue == "0")
            {
                IsPriceQuoted = false;
            }
            //if (rbtnPriceQuotedEdit.SelectedValue == "1")
            else
            {
                IsPriceQuoted = true;
            }


            int id = Convert.ToInt32(hdid.Value);
            string type = Convert.ToString(txtCurrencyType.Text.Trim());
            string sym = Convert.ToString(txtCurrencySymbol.Text.Trim());

            bool IsValid = true;
            //if (type == "")
            //{
            //    string script = string.Empty;
            //    script = "ShowHideMessageBox(true, 'Enter Currency Type.');";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true); IsValid = false;
            //}
            //if (sym == "")
            //{
            //    string script = string.Empty;
            //    script = "ShowHideMessageBox(true, 'Enter Currency Symbol.');";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true); IsValid = false;
            //}
            //if (txtConversionRate.Text.Trim() == "")
            //{
            //    string script = string.Empty;
            //    script = "ShowHideMessageBox(true, 'Enter Conversion Rate.');";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true); IsValid = false;
            //}
            //if (txtExportConversionRate.Text.Trim() == "")
            //{
            //    string script = string.Empty;
            //    script = "ShowHideMessageBox(true, 'Enter Export Conversion Rate.');";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true); IsValid = false;
            //}
            //if (rbtnPriceQuotedEdit.SelectedValue == "")
            //{
            //    string script = string.Empty;
            //    script = "ShowHideMessageBox(true, 'Please Check Radio Button For IsPriceQuoted Or IsExportConverSion.');";
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true); IsValid = false;
            //}









            if (IsValid)
            {
                double con = Convert.ToDouble(txtConversionRate.Text.Trim());
                double ExportCon = Convert.ToDouble(txtExportConversionRate.Text.Trim());
                int i = objAdminController.InsertUpdateCurrencyBAL(id, con, ExportCon, type, sym, IsPriceQuoted);


                if (i == 1)
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Duplicate Entry Found.','Currency Admin');";
                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);


                }


                if (i == 0)
                {
                    string script = string.Empty;
                    script = "ShowHideMessageBox(true, 'Update successfully.','Currency Admin');";
                   // ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
                    grdCurrency.EditIndex = -1;
                    bindgrd();
                }
            }
            else
            {
                // grdCurrency.EditIndex = -1;
                // bindgrd();
            }

        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        protected void grdCurrency_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCurrency.EditIndex = e.NewEditIndex;

            bindgrd();

            GridViewRow Rows = grdCurrency.Rows[e.NewEditIndex];
            HiddenField hd = Rows.FindControl("hdnId") as HiddenField;
            int id = Convert.ToInt32(hd.Value);


            TextBox txtCurrencyType = Rows.FindControl("txtCurrencyType") as TextBox;
            txtCurrencyType.MaxLength = 10;
            Label txtCurrencySymbol = Rows.FindControl("txtCurrencySymbol") as Label;
            //txtCurrencySymbol.MaxLength = 3; 

            TextBox txtConversionRate = Rows.FindControl("txtConversionRate") as TextBox;
            txtConversionRate.Attributes["onkeyup"] = "extractNumber(this,2,true);";


            TextBox txtExportConversionRate = Rows.FindControl("txtExportConversionRate") as TextBox;
            txtExportConversionRate.Attributes["onkeyup"] = "extractNumber(this,2,true);";


            RadioButtonList rbtnPriceQuotedEdit = Rows.FindControl("rbtnPriceQuotedEdit") as RadioButtonList;
            HiddenField hdnPriceQuotedEdit = Rows.FindControl("hdnPriceQuotedEdit") as HiddenField;
            if (hdnPriceQuotedEdit != null)
            {
                if (hdnPriceQuotedEdit.Value == "False")
                {
                    rbtnPriceQuotedEdit.SelectedValue = "0";
                }
                else
                {
                    rbtnPriceQuotedEdit.SelectedValue = "1";
                }
            }
            // ddlEntryType.Attributes["onChange"] = "ddlValidation();"; onkeyup="extractNumber(this,2,true);"
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            AdminController objAdminController = new AdminController();
            bool IsPriceQuoted;
            if (rbtnIsCosting.SelectedValue == "0")
            {
                IsPriceQuoted = false;
            }
            else
            {
                IsPriceQuoted = true;
            }
            int i = objAdminController.InsertUpdateCurrencyBAL(0, Convert.ToDouble(txtCon.Value.Trim()), Convert.ToDouble(txtExpCon.Value.Trim()), txtTag.Value.Trim(), txtSym.Value.Trim(), IsPriceQuoted);
            if (i == 1)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Duplicate Entry Found.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                txtSym.Value = "";
                txtTag.Value = "";
                txtCon.Value = "";
                txtExpCon.Value = "";
            }


            if (i == 0)
            {
                string script = string.Empty;
                script = "ShowHideMessageBox(true, 'Enter successfully.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
                bindgrd();
                txtSym.Value = "";
                txtTag.Value = "";
                txtCon.Value = "";
                txtExpCon.Value = "";
            }
        }

        protected void grdCurrency_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            RadioButtonList rbtnPriceQuoted1 = (RadioButtonList)e.Row.FindControl("rbtnPriceQuoted1");
            HiddenField hdnPriceQuoted = (HiddenField)e.Row.FindControl("hdnPriceQuoted");
            if (hdnPriceQuoted != null)
            {

                if (hdnPriceQuoted.Value == "True")
                {
                    rbtnPriceQuoted1.SelectedValue = "1";
                }
                else
                {
                    rbtnPriceQuoted1.SelectedValue = "0";
                }


                if (rbtnPriceQuoted1 != null)
                {
                    rbtnPriceQuoted1.Enabled = false;
                }
            }
        }
    }
}