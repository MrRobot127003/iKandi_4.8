using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;

namespace iKandi.Web.Internal.Client
{
    public partial class Create_Department : System.Web.UI.Page
    {

        public int ClientID
        {
            get
            {
                if (Request.QueryString["ClientID"] == null || Request.QueryString["ClientID"].Trim() == string.Empty)
                    return -1;

                return Convert.ToInt32(Request.QueryString["ClientID"]);
            }
        }

        DataSet dtdata = new DataSet();
        AdminController objadmin = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdata();
            }
        }

        private void getdata()
        {
            grdDepartmentAdmin.DataSource = objadmin.GetParentDepartment(ClientID, 1);
            grdDepartmentAdmin.DataBind();

        }

        //protected void grdDepartmentAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        // Add by Surendra 2 for put loop all data rows on 04-04-2018.
        //        foreach (DataControlFieldCell cell in e.Row.Cells)
        //        {
        //            // check all cells in one row
        //            foreach (Control control in cell.Controls)
        //            {
        //                ImageButton button = control as ImageButton;
        //                if (button != null && button.CommandName == "Delete")
        //                {
        //                    // Add delete confirmation
        //                    button.OnClientClick = "if (!confirm('Are you sure you want to delete this record?')) return;";
        //                }
        //            }
        //        }               
        //    }
        //}

        protected void grdDepartmentAdmin_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.Equals("EmptyInsert"))
            {
                TextBox TxtDeptName = grdDepartmentAdmin.Controls[0].Controls[0].FindControl("TxtDeptName") as TextBox;
                var DeptName = TxtDeptName.Text.Trim();
                if (DeptName == "")
                {
                    string message = "Please enter the department name.";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                    return;
                }
                try
                {
                    int result = objadmin.InsertParentDept(DeptName, ClientID);
                    if (result > 0)
                    {
                        string message = "Your details have been Add successfully.";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                        getdata();
                    }
                    else
                    {
                        string message = "Some Error in Inserting data.";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                        getdata();
                    }
                }
                catch (Exception ex)
                {
                    var script_fail2 = "";
                    string er = ex.Message.Substring(0, ex.Message.Length - 3);
                    if (er == "Record already exists.")
                        script_fail2 = "Record already exists.";
                    else
                        script_fail2 = "Some error has occured, Error is : " + ex.Message.ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + script_fail2 + "');", true);
                }
               
            }
            if (e.CommandName.Equals("Insert"))
            {
                TextBox Foo_TxtDeptName = (TextBox)grdDepartmentAdmin.FooterRow.FindControl("Foo_TxtDeptName") as TextBox;
                var DeptName = Foo_TxtDeptName.Text.Trim();
                if (DeptName == "")
                {
                    string message = "Please enter the department name.";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                    return;
                }
                try
                {
                    int result = objadmin.InsertParentDept(DeptName, ClientID);
                    if (result > 0)
                    {
                        string message = "Your details have been Add successfully.";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                        getdata();
                    }
                    else
                    {
                        string message = "Some Error in Inserting data.";
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                        getdata();
                    }
                }
                catch (Exception ex)
                {
                    var script_fail2 = "";
                    string er = ex.Message.Substring(0, ex.Message.Length - 3);
                    if (er == "Record already exists.")
                        script_fail2 = "Record already exists.";
                    else
                        script_fail2 = "Some error has occured, Error is : " + ex.Message.ToString();
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + script_fail2 + "');", true);
                }

            }
        }

        protected void grdDepartmentAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //dal obj = new dal();
            GridViewRow Rows = grdDepartmentAdmin.Rows[e.RowIndex];
            HiddenField Edit_hdnDeptID = Rows.FindControl("Edit_hdnDeptID") as HiddenField;
            //TextBox Edit_TxtDeptName = Rows.FindControl("Edit_TxtDeptName") as TextBox;
            TextBox txtUname = (TextBox)grdDepartmentAdmin.Rows[e.RowIndex].FindControl("Edit_TxtDeptName");
            var DeptName = txtUname.Text.Trim();
            if (DeptName == "")
            {
                string message = "Please enter the department name.";
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                return;
            }

            try
            {
                int Result = objadmin.UpdateParentDept(Convert.ToInt32(Edit_hdnDeptID.Value), DeptName);
                grdDepartmentAdmin.EditIndex = -1;
                if (Result > 0)
                {
                    string message = "Your details has been Updated successfully.";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                }
                else
                {
                    string message = "Some Error in Updateing data.";
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
                }
                getdata();
            }
            catch (Exception ex)
            {
                var script_fail2 = "";
                string er = ex.Message.Substring(0, ex.Message.Length - 3);
                if (er == "Record already exists.")
                    script_fail2 = "Record already exists.";
                else
                    script_fail2 = "Some error has occured, Error is : " + ex.Message.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + script_fail2 + "');", true);
            }            
        }

        //protected void grdDepartmentAdmin_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    GridViewRow Rows = grdDepartmentAdmin.Rows[e.RowIndex];

        //    HiddenField hdnInternal_Audit_ProcessID = Rows.FindControl("hdnInternal_Audit_ProcessID") as HiddenField;
        //    int result = objadmin.deleteComplianceAdminData(Convert.ToInt32(hdnInternal_Audit_ProcessID.Value), 3);
        //    if (result > 0)
        //    {
        //        string message = "Your details have been Deleted successfully.";
        //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "SuccessMessage", "javascript:ShowAlert('" + message + "');", true);
        //    }
        //    getdata();
        //}

        protected void grdDepartmentAdmin_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdDepartmentAdmin.EditIndex = e.NewEditIndex;
            getdata();
        }

        protected void grdDepartmentAdmin_RowCanceling(object sender, GridViewCancelEditEventArgs e)
        {
            grdDepartmentAdmin.EditIndex = -1;
            getdata();
        }
    }
}