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
using iKandi.Web.Components;
using iKandi.Common;
using System.Collections.Generic;

namespace iKandi.Web
{
    public partial class QCFaults : BaseUserControl
    {
        #region Fields

        DataTable dsSubCategories;


        #endregion

        #region members

       
        public string fault;

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            dsSubCategories = this.QualityControllerInstance.GetQualityFaultSubCategories();
        }

        protected void grdFaults_RowDataBound(object sender, GridViewRowEventArgs e)
        {


            if (e.Row.RowType == DataControlRowType.Footer)
            {
                for(int i =0; i < e.Row.Cells.Count; i++)
                {
                e.Row.Cells[i].CssClass = "CalculatedColumns";
                }
                GroupDropDownList GroupDropDownList1 = e.Row.FindControl("GroupDropDownList1") as GroupDropDownList;
                GroupDropDownList1.DataSource = dsSubCategories;
                GroupDropDownList1.DataTextField = "subcategorytype";
                GroupDropDownList1.DataValueField = "subcategoryid";
                GroupDropDownList1.DataGroupField = "categorytype";
                GroupDropDownList1.DataBind();
            }

            if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            {
                GroupDropDownList GroupDropDownList1 = e.Row.FindControl("ddlNewCategory") as GroupDropDownList;
                GroupDropDownList1.DataSource = dsSubCategories;
                GroupDropDownList1.DataTextField = "subcategorytype";
                GroupDropDownList1.DataValueField = "subcategoryid";
                GroupDropDownList1.DataGroupField = "categorytype";

                DataRowView drv = e.Row.DataItem as DataRowView;

                GroupDropDownList1.SelectedValue = drv["SubCategoryID"].ToString();

                GroupDropDownList1.DataBind();
            }
        }

        protected void grdFaults_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFaults.PageIndex = e.NewPageIndex;
            BindControls();
        }

        protected void grdFaults_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GroupDropDownList ddlCategories = this.grdFaults.Rows[e.RowIndex].FindControl("ddlNewCategory") as GroupDropDownList;

            ObjectDataSource1.UpdateParameters["SubcategoryType"].DefaultValue = ddlCategories.SelectedValue;
        }

        protected void LinkInsert_Click(object sender, EventArgs e)
        {
            ObjectDataSource1.Insert();
        }

        protected void ObjectDataSource1_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
        {
            e.InputParameters["FaultCode"] = ((TextBox)this.grdFaults.FooterRow.FindControl("txtNewFaultCode")).Text;

            e.InputParameters["FaultDescription"] = ((TextBox)this.grdFaults.FooterRow.FindControl("txtNewFault")).Text;

            GroupDropDownList ddlCategories = this.grdFaults.FooterRow.FindControl("GroupDropDownList1") as GroupDropDownList;
            e.InputParameters["SubcategoryType"] = ddlCategories.SelectedValue;

            e.InputParameters["FaultType"] = ((DropDownList)this.grdFaults.FooterRow.FindControl("ddlNewClassification")).SelectedValue;
            
            //this.AdminControllerInstance.InsertFaults(e.InputParameters["FaultCode"].ToString(), e.InputParameters["FaultDescription"].ToString(),Convert.ToInt32(e.InputParameters["SubcategoryType"]),Convert.ToInt32(e.InputParameters["FaultType"]));
        }

        protected void grdFaults_RowDeleted(Object sender, GridViewDeletedEventArgs e)
        {
            //System.Diagnostics.Debugger.Break();
            string script = string.Empty;
            if (e.Exception == null && e.AffectedRows > 0)
            {
                script = "ShowHideMessageBox(true, 'Fault deleted successfully!');";
            }
            else if (e.Exception != null || e.AffectedRows <= 0)
            {
                script = "ShowHideValidationBox(true, 'Cannot delete this fault!');";
                e.ExceptionHandled = true;
            }           

            //if (1)
            //{
            //    script = "ShowHideMessageBox(true, 'Fault deleted successfully!');";
            //}
            //else
            //{
            //    script = "ShowHideValidationBox(true, 'Cannot delete this fault!');";
            //}

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
        }

        protected void ObjectDataSource1_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            //System.Diagnostics.Debugger.Break();
            string script = string.Empty;
            if (e.Exception == null && e.AffectedRows > 0)
            {
                script = "ShowHideMessageBox(true, 'Fault deleted successfully!');";
            }
            else if (e.Exception != null || e.AffectedRows <= 0)
            {
                script = "ShowHideValidationBox(true, 'Cannot delete this fault as already being used!');";
                e.ExceptionHandled = true;
            }           

        }

        protected void grdFaults_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //System.Diagnostics.Debugger.Break();
            int original_Id = Convert.ToInt32(((HiddenField)this.grdFaults.Rows[e.RowIndex].FindControl("hiddenId")).Value);
            int isDeleted = this.AdminControllerInstance.DeleteFault(original_Id);

            string script = string.Empty;

            if (isDeleted == 1)
            {
                script = "ShowHideMessageBox(true, 'Fault deleted successfully!');";
            }
            else
            {
                script = "ShowHideValidationBox(true, 'Cannot delete this fault as already being used!');";
            }

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ShowMessage", script, true);
            e.Cancel = true;
        }

        protected void ObjectDataSource1_Deleting(object sender, ObjectDataSourceMethodEventArgs e)
        { 
            
        }

        #endregion

        #region Private Methods

        public void BindControls()
        {

            //dsFaults = this.AdminControllerInstance.GetQAFaults();

            //grdFaults.DataSource = dsFaults;
            //grdFaults.DataBind();
        }



        #endregion       

        
    }
}
