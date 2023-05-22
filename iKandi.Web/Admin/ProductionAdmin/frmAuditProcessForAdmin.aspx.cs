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
using System.Collections.Generic;
using System.Text;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
namespace iKandi.Web.Admin.ProductionAdmin
{
    public partial class frmAuditProcessForAdmin : System.Web.UI.Page
    {
        DataSet dtdata = new DataSet();
        AdminController objadmin = new AdminController();
       int UserId = -1;
       int RowNo = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

            if (!IsPostBack)
            {
                ddlUnitBindData();
                getdata();
                
            }          
        }
        private void ddlUnitBindData()
        {
            ddlUnit.DataSource = objadmin.GetFactorynames(0, "AuditUnit");
            ddlUnit.DataValueField = "id";
            ddlUnit.DataTextField = "Name";
            ddlUnit.DataBind();
        }

        private void getdata()
        {
            grdComplianceAdmin.DataSource = objadmin.GetComplianceAdmin( Convert.ToInt32(ddlUnit.SelectedValue), Convert.ToInt32(rdoCompliance.SelectedValue), 0);
            grdComplianceAdmin.DataBind();

            DataSet ds = new DataSet();
            ds = objadmin.Get_AuditParameter_Admin(Convert.ToInt32(ddlUnit.SelectedValue), Convert.ToInt32(rdoCompliance.SelectedValue));
            RowNo = ds.Tables[0].Rows.Count;
            grdbindprocessadmin.DataSource = ds.Tables[0];
            grdbindprocessadmin.DataBind();
        }

        protected void grdComplianceAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Add by Surendra 2 for put loop all data rows on 04-04-2018.
                foreach (DataControlFieldCell cell in e.Row.Cells)
                {
                    // check all cells in one row
                    foreach (Control control in cell.Controls)
                    {
                        ImageButton button = control as ImageButton;
                        if (button != null && button.CommandName == "Delete")
                        {
                            // Add delete confirmation
                            button.OnClientClick = "if (!confirm('Are you sure you want to delete this record?')) return;";
                        }
                    }
                }

                Label lblComplianceProcess = (Label)e.Row.FindControl("lblComplianceProcess");                
            }
        }



        protected void grdComplianceAdmin_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {          
            
            if (e.CommandName.Equals("EmptyInsert"))
            {
                TextBox TxtComplianceProcess = grdComplianceAdmin.Controls[0].Controls[0].FindControl("TxtComplianceProcess") as TextBox;
                var ComplianceProcess = TxtComplianceProcess.Text.Trim();
                if (ComplianceProcess == "")
                {
                    string message = "Please enter the process name.";                   
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);                   
                    return;
                }
                int result = objadmin.InsertComplianceAdmin(ComplianceProcess, Convert.ToInt32(ddlUnit.SelectedValue), Convert.ToInt32(rdoCompliance.SelectedValue), 1, UserId);
                if (result > 0)
                {
                    string message = "Your details have been Add successfully.";                   
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);            
                    getdata();
                }
                else
                {
                    string message = "This Record Has Already Exist.";                   
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);                   
                    getdata();
                }
            }           
            if (e.CommandName.Equals("Insert"))
            {
                TextBox FooTxtComplianceProcess = (TextBox)grdComplianceAdmin.FooterRow.FindControl("Foo_TxtComplianceProcess") as TextBox;
                var ComplianceProcess_foo = FooTxtComplianceProcess.Text.Trim();
                if (ComplianceProcess_foo == "")
                {
                    string message = "Please enter the process name.";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                    return;
                }
                int result=objadmin.InsertComplianceAdmin(ComplianceProcess_foo, Convert.ToInt32(ddlUnit.SelectedValue), Convert.ToInt32(rdoCompliance.SelectedValue), 1, UserId);
                if (result > 0)
                {
                    string message = "Your details have been Add successfully.";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                    getdata();
                }
                else
                {
                    string message = "This Record Has Already Exist.";                    
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                    getdata();
                }
                
            }
        }
        

        protected void grdComplianceAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //dal obj = new dal();
            GridViewRow Rows = grdComplianceAdmin.Rows[e.RowIndex];
            HiddenField Edit_hdnInternal_Audit_ProcessID = Rows.FindControl("Edit_hdnInternal_Audit_ProcessID") as HiddenField;
            TextBox Edit_TxtComplianceProcess = Rows.FindControl("Edit_TxtComplianceProcess") as TextBox;
            var TxtComplianceProcess = Edit_TxtComplianceProcess.Text.Trim();
            if (TxtComplianceProcess == "")
            {
                string message = "Please enter the process name.";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                return;
            }
            int Result = objadmin.UpdateComplianceAdmin(Convert.ToInt32(Edit_hdnInternal_Audit_ProcessID.Value), TxtComplianceProcess, Convert.ToInt32(ddlUnit.SelectedValue), Convert.ToInt32(rdoCompliance.SelectedValue), 2, UserId);
            grdComplianceAdmin.EditIndex = -1;

            if (Result > 0)
            {
                string message = "Your details has been Updated successfully.";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);                
            }
            else
            {
                string message = "This Record Has Already Exist.";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);                
            }
            getdata();
        }

        protected void grdComplianceAdmin_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow Rows = grdComplianceAdmin.Rows[e.RowIndex];

            HiddenField hdnInternal_Audit_ProcessID = Rows.FindControl("hdnInternal_Audit_ProcessID") as HiddenField;
            int result = objadmin.deleteComplianceAdminData(Convert.ToInt32(hdnInternal_Audit_ProcessID.Value),3);
            if (result > 0)
            {
                string message = "Your details have been Deleted successfully.";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);               
            }
            getdata();
        }

        protected void grdComplianceAdmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdComplianceAdmin.EditIndex = e.NewEditIndex;
            getdata();
        }

        protected void grdComplianceAdmin_RowCanceling(object sender, GridViewCancelEditEventArgs e)
        {
            grdComplianceAdmin.EditIndex = -1;
            getdata();
        }

        protected void Add_data(object sender, EventArgs e)
        {

        }

        protected void btn_Go(object sender, EventArgs e)
        {
            getdata();
        }

        protected void grdbindprocessadmin_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                TextBox txtAuditParameter = (TextBox)e.Row.FindControl("txtAuditParameter");
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {               
                DropDownList ddlSequence = (DropDownList)e.Row.FindControl("ddlSequence");
                DropDownList ddlIsActive = (DropDownList)e.Row.FindControl("ddlIsActive");               
                HiddenField hdnIsActive = (HiddenField)e.Row.FindControl("hdnIsActive");
                Label lblSequence=(Label)e.Row.FindControl("lblSequence");
                              
                ArrayList Sequence = new ArrayList();
                for (int i = 1; i <= RowNo; i++)
                {
                    Sequence.Add(i);                   
                }

                foreach (object SequenceNo in Sequence)
                {
                    ddlSequence.Items.Add(new ListItem(SequenceNo.ToString(), SequenceNo.ToString()));
                }

                if (lblSequence.Text != "")
                {
                    //ddlSequence.SelectedItem.Value = lblSequence.Text;
                    ddlSequence.SelectedValue = lblSequence.Text;
                }
               
                    if (hdnIsActive.Value == "True")
                    {
                        ddlIsActive.SelectedValue = "1";                       
                    }
                    else
                    {
                        ddlIsActive.SelectedValue = "0";                        
                    }
                

            }
        }


        protected void grdbindprocessadmin_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {

                TextBox txtfooAuditParameter = (TextBox)grdbindprocessadmin.FooterRow.FindControl("txtfooAuditParameter") as TextBox;              
                DropDownList ddlFooIsActive = (DropDownList)grdbindprocessadmin.FooterRow.FindControl("ddlFooIsActive") as DropDownList;              

               
                 var fooAuditParameter = txtfooAuditParameter.Text.Trim();
                 if (fooAuditParameter == "")
                {
                    string message = "Please enter the Audit Parameter Name";
                   // string script = "window.onload = function(){ alert('";
                   // script += message;
                    //script += "')};";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                   // ClientScript.RegisterClientScriptBlock(this.GetType(), "SuccessMessage", script, true);
                    return;
                }



                 int result = objadmin.Insert_Update_AuditParameter_Admin(0, txtfooAuditParameter.Text, Convert.ToInt32(ddlUnit.SelectedValue), Convert.ToInt32(rdoCompliance.SelectedValue), RowNo + 1, Convert.ToInt32(ddlFooIsActive.SelectedItem.Value), 0);
                 if (result > 0)
                 {
                     string message = "Your details has been Updated successfully.";
                     ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                     getdata();
                 }
                 else
                 {
                     string message = "This Record Has Already Exist.";
                     ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                     getdata();
                 }

            }           
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int Result = 0;
            foreach (GridViewRow row in grdbindprocessadmin.Rows)
            {
                HiddenField QAComplaine_TypeAdminID = (HiddenField)row.FindControl("hdnQAComplaine_TypeAdminID");

                DropDownList ddlSequence = (DropDownList)row.FindControl("ddlSequence") as DropDownList;

                DropDownList ddlIsActive = (DropDownList)row.FindControl("ddlIsActive") as DropDownList;

                Label lblAuditParameter = (Label)row.FindControl("lblAuditParameter") as Label;

                 Result = objadmin.Insert_Update_AuditParameter_Admin(Convert.ToInt32(QAComplaine_TypeAdminID.Value), lblAuditParameter.Text, Convert.ToInt32(ddlUnit.SelectedValue), Convert.ToInt32(rdoCompliance.SelectedValue), Convert.ToInt32(ddlSequence.SelectedItem.Value), Convert.ToInt32(ddlIsActive.SelectedItem.Value), 1);
                //grdbindprocessadmin.EditIndex = -1;          

            }
            if (Result > 0)
            {
                string message = "Your details has been Updated successfully.";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                getdata();
            }
            else
            {
               string message = "This Record Has Already Exist.";               
               ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);             
                getdata();
            }
        }


        protected void grdbindprocessadmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdbindprocessadmin.EditIndex = e.NewEditIndex;
            getdata();
        }

        protected void grdbindprocessadmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdbindprocessadmin.EditIndex = -1;
            getdata();
        }


        protected void grdbindprocessadmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //dal obj = new dal();
            GridViewRow Rows = grdbindprocessadmin.Rows[e.RowIndex];

            HiddenField hdnQAComplaine_TypeAdminID = Rows.FindControl("hdnQAComplaine_TypeAdminID") as HiddenField;
            //HiddenField hdnInternal_Audit_ProcessID = (HiddenField)grdComplianceAdmin.Rows[e.RowIndex].FindControl("hdnInternal_Audit_ProcessID");
            TextBox txtAuditParameter = Rows.FindControl("txtAuditParameter") as TextBox;
            HiddenField hdnSequence = Rows.FindControl("hdnSequence") as HiddenField;
            HiddenField hdnIsActive = Rows.FindControl("hdnIsActive") as HiddenField;
            int IsActive;
            if (hdnIsActive.Value == "True")
            {
                IsActive = 1;
            }
            else
            {
                IsActive = 0;
            }
            var TxtComplianceProcess = txtAuditParameter.Text.Trim();
            if (TxtComplianceProcess == "")
            {
                string message = "Please enter the process name.";
                // string script = "window.onload = function(){ alert('";
                //script += message;
                //script += "')};";
                // ClientScript.RegisterClientScriptBlock(this.GetType(), "SuccessMessage", script, true);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                return;
            }
            int Result = objadmin.Insert_Update_AuditParameter_Admin(Convert.ToInt32(hdnQAComplaine_TypeAdminID.Value), TxtComplianceProcess, Convert.ToInt32(ddlUnit.SelectedValue), Convert.ToInt32(rdoCompliance.SelectedValue), Convert.ToInt32(hdnSequence.Value), IsActive, 2);
            grdbindprocessadmin.EditIndex = -1;

            if (Result > 0)
            {
                string message = "Your details has been Updated successfully.";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                getdata();
            }
            
        }


        protected void OnSelectedfactorychanged(object sender, EventArgs e)
        {
            if (ddlUnit.SelectedValue == "-1")
            {
                rdoCompliance.SelectedValue = "-1";
                rdoCompliance.Visible = false;
                btnSubmit.Visible = false;
            }
            else
            {
                rdoCompliance.Visible = true;
                btnSubmit.Visible = true;
                rdoCompliance.SelectedValue = "1";
            }
        }

    }
}