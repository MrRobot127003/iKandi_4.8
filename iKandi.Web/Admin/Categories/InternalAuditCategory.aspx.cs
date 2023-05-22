using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.BLL.Production;
using System.Data;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.Admin.Categories
{
    public partial class InternalAuditCategory : System.Web.UI.Page
    {
        IList<AuditCategory> auditCategories = new List<AuditCategory>();
        AdminController adminController = new AdminController();
        int UserId = -1;        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

            if (!IsPostBack)
            {                
                BindAllInternalAuditCategory();
                BindAuditCatgGridView();
                BindAuditCatgDetailsGridView();
            }
        }

        private void BindAuditCatgGridView()
        {
            auditCategories = adminController.GetAllAuditCategories(0);
            auditCatg.DataSource = auditCategories;
            auditCatg.DataBind();
        }
        private void BindAuditCatgDetailsGridView()
        {
           
            if (ddlCategory.SelectedValue != "--Select--")
            {
                DataTable dtInternalAuditDetails = adminController.GetAuditCategoryDetails(Convert.ToInt32(ddlCategory.SelectedValue));
                auditCatgDetails.DataSource = dtInternalAuditDetails;
                auditCatgDetails.DataBind();
            }
        }

        private void BindAllInternalAuditCategory()
        {
            auditCategories = adminController.GetAllAuditCategories(1);

            ddlCategory.DataSource = auditCategories;
            ddlCategory.DataTextField = "InternalAuditCatgName";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();
        }
        private void BindDll(DropDownList ddls, string types, int deptSelected)
        {
            DataTable dt = new DataTable();
            if (types == "dept")
            {
                dt = adminController.BindDepartmentDdl();
                ddls.DataSource = dt;
                ddls.DataTextField = "Name";
                ddls.DataValueField = "Id";
                ddls.DataBind();
                ddls.Items.Insert(0, "--Select--");
            }
            else if (types == "designation")
            {
                dt = adminController.BindDesignationDdl(deptSelected);
                ddls.DataSource = dt;
                ddls.DataTextField = "Name";
                ddls.DataValueField = "Id";
                ddls.DataBind();
               
            }

        }

        protected void auditCatgDetails_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DropDownList ddlDept = (DropDownList)e.Row.FindControl("ddlDepartment");
                DropDownList ddlDesig = (DropDownList)e.Row.FindControl("ddlDesignation");
                HiddenField hdnDepartmentId = (HiddenField)e.Row.FindControl("hdnDepartmentId");
                HiddenField hdnDesignationId = (HiddenField)e.Row.FindControl("hdnDesignationId");

                BindDll(ddlDept, "dept", 0);
                ddlDept.SelectedValue = hdnDepartmentId.Value;
                BindDll(ddlDesig, "designation", Convert.ToInt32(ddlDept.SelectedValue));
                ddlDesig.SelectedValue = hdnDesignationId.Value;

                GridView grvAuditor = (GridView)e.Row.FindControl("grvAuditor");
                HiddenField hdnId = (HiddenField)e.Row.FindControl("hdnCategoryQuesId");
                DataTable dtAuditor = adminController.GetAuditorsByCatgQusId(Convert.ToInt32(hdnId.Value));
                grvAuditor.DataSource = dtAuditor;
                grvAuditor.DataBind();

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DropDownList ddlDeptFooter = (DropDownList)e.Row.FindControl("ddlDepartmentFooter");
                DropDownList ddlDesigFooter = (DropDownList)e.Row.FindControl("ddlDesignationFooter");

                BindDll(ddlDeptFooter, "dept", 0);
                BindDll(ddlDesigFooter, "designation", -1);



            }

            if (e.Row.RowType == DataControlRowType.EmptyDataRow)
            {
                DropDownList ddlDeptEmpty = (DropDownList)e.Row.FindControl("ddlDepartmentEmpty");
                DropDownList ddlDesigEmpty = (DropDownList)e.Row.FindControl("ddlDesignationEmpty");

                BindDll(ddlDeptEmpty, "dept", 0);
                BindDll(ddlDesigEmpty, "designation", -1);

            }

        }

        protected void auditCatgDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddRow")
            {
                auditCatgDetails.PageIndex = 0;
                auditCatgDetails.EditIndex = -1;
                CreateAuditCategoryDetails();
            }
        }

        private void CreateAuditCategoryDetails()
        {
            try
            {
                AuditCategoryDetails category = new AuditCategoryDetails();
                if (auditCatgDetails.Rows.Count == 0)
                {
                    TextBox txtQuestionNameEmpty = auditCatgDetails.Controls[0].Controls[0].FindControl("txtQuestionNameEmpty") as TextBox;
                    DropDownList ddlDeptEmpty = auditCatgDetails.Controls[0].Controls[0].FindControl("ddlDepartmentEmpty") as DropDownList;
                    DropDownList ddlDesignationEmpty = auditCatgDetails.Controls[0].Controls[0].FindControl("ddlDesignationEmpty") as DropDownList;
                   
                    category.QuestionName = txtQuestionNameEmpty.Text;
                    category.DepartmentId = Convert.ToInt32(ddlDeptEmpty.SelectedValue);
                    category.DesignationId = Convert.ToInt32(ddlDesignationEmpty.SelectedValue);
                    category.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
                    category.CreatedBy = UserId.ToString();
                    category.CategoryQuesId = adminController.SaveAuditCategoryDetails(category);
                }

                else
                {
                    TextBox QuestionName = (TextBox)auditCatgDetails.FooterRow.FindControl("txtQuestionNameFooter");
                    DropDownList Department = (DropDownList)auditCatgDetails.FooterRow.FindControl("ddlDepartmentFooter");
                    DropDownList Designation = (DropDownList)auditCatgDetails.FooterRow.FindControl("ddlDesignationFooter");

                    category.QuestionName = QuestionName.Text;
                    category.DepartmentId = Convert.ToInt32(Department.SelectedValue);
                    category.DesignationId = Convert.ToInt32(Designation.SelectedValue);
                    category.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
                    category.CreatedBy = UserId.ToString();
                    category.CategoryQuesId = adminController.SaveAuditCategoryDetails(category);
                }

                if (category.CategoryId > 0)
                {
                    BindAuditCatgDetailsGridView();
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        protected void auditCatg_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddRow")
            {
                auditCatg.PageIndex = 0;
                auditCatg.EditIndex = -1;
                CreateAuditCategory();
                BindAuditCatgGridView();
            }
        }

        private void CreateAuditCategory()
        {
            try
            {
                AuditCategory category = new AuditCategory();
                if (auditCatg.Rows.Count == 0)
                {
                    TextBox AuditCatgNameEmpty = auditCatg.Controls[0].Controls[0].FindControl("InternalAuditCatgNameEmpty") as TextBox;

                    category.InternalAuditCatgName = AuditCatgNameEmpty.Text;
                    category.CreatedBy = UserId;
                    category = SaveAudit_Category(category);
                }

                else
                {
                    TextBox InternalAuditCatgName = (TextBox)auditCatg.FooterRow.FindControl("tbAuditCategoryName");

                    category.InternalAuditCatgName = InternalAuditCatgName.Text;
                    category.CreatedBy = UserId;
                    category = SaveAudit_Category(category);
                }


                if (category.Id > 0)
                {
                    BindAuditCatgGridView();
                    BindAllInternalAuditCategory();
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        public AuditCategory SaveAudit_Category(AuditCategory category)
        {
            int AuditCategoryID = -1;
            if (category.Id == -1)
            {
                AuditCategoryID = adminController.DeleteAuditCategory(category);
            }
            else
            {

                AuditCategoryID = adminController.CreateAuditCategory(category);
                category.Id = AuditCategoryID;
            }

            return category;
        }

        public AuditCategoryDetails SaveAuditCategoryDetails(AuditCategoryDetails category)
        {
            int AuditCategoryID = -1;
            if (category.CategoryQuesId == -1)
            {
                AuditCategoryID = adminController.DeleteAuditCategoryDetails(category);
            }
            else
            {

                AuditCategoryID = adminController.CreateAuditCategoryDetails(category);
                category.CategoryQuesId = AuditCategoryID;
            }

            return category;
        }

        protected void auditCatg_RowEditing(object sender, GridViewEditEventArgs e)
        {
            auditCatgDetails.EditIndex = -1;
            BindAuditCatgDetailsGridView();
            auditCatg.EditIndex = e.NewEditIndex;
            BindAuditCatgGridView();
        }

        protected void auditCatgDetails_RowEditing(object sender, GridViewEditEventArgs e)
        {
            auditCatg.EditIndex = -1;
            BindAuditCatgGridView();
            auditCatgDetails.EditIndex = e.NewEditIndex;
            BindAuditCatgDetailsGridView();
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the master DropDownList and its value
            DropDownList ddlDept = (DropDownList)sender;
            string deptId = ddlDept.SelectedValue;

            // Get the GridViewRow in which this master DropDownList exists
            GridViewRow row = (GridViewRow)ddlDept.NamingContainer;

            // Find all of the other DropDownLists within the same row and bind them
            DropDownList ddlDesig = (DropDownList)row.FindControl("ddlDesignation");
            if (ddlDept.SelectedValue != "--Select--")
            {
                DataTable dtDesig = adminController.BindDesignationDdl(Convert.ToInt32(deptId));
                ddlDesig.DataSource = dtDesig;
                ddlDesig.DataTextField = "Name";
                ddlDesig.DataValueField = "Id";
                ddlDesig.DataBind();
            }
            else
            {
                ddlDesig.Items.Clear();
                ddlDesig.Items.Insert(0, new ListItem("--Select--", "0"));
            }

        }

        protected void auditCatg_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow Rows = auditCatg.Rows[e.RowIndex];

            AuditCategory objCategory = new AuditCategory();

            HiddenField hdnId = (HiddenField)Rows.FindControl("hdnId");
            TextBox InternalAuditCatgName = (TextBox)Rows.FindControl("txtInternalAuditCatgName");


            if (InternalAuditCatgName.Text == "")
            {
                ShowAlert("Please enter audit category name!");
                InternalAuditCatgName.Focus();
                return;
            }

            objCategory.Id = Convert.ToInt32(hdnId.Value);
            objCategory.InternalAuditCatgName = InternalAuditCatgName.Text.Trim();
            objCategory.CreatedBy = UserId;

            objCategory = this.adminController.SaveAuditCategory(objCategory);

            if (objCategory.Id > 0)
            {
                ShowAlert("Data has been updated successfully.");
                auditCatg.EditIndex = -1;
                BindAuditCatgGridView();
            }
            else
            {
                ShowAlert("Category Name cannot Duplicate!");
                return;
            }
            BindAllInternalAuditCategory();
        }

        protected void auditCatgDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow Rows = auditCatgDetails.Rows[e.RowIndex];

            AuditCategoryDetails objCategory = new AuditCategoryDetails();

            HiddenField hdnId = (HiddenField)Rows.FindControl("hdnCategoryQuesId");
            TextBox QuestionName = (TextBox)Rows.FindControl("txtQuestionName");
            DropDownList Department = (DropDownList)Rows.FindControl("ddlDepartment");
            DropDownList Designation = (DropDownList)Rows.FindControl("ddlDesignation");


            if (QuestionName.Text == "")
            {
                ShowAlert("Please enter audit category name!");
                QuestionName.Focus();
                return;
            }

            if (Department.SelectedValue == "--Select--")
            {
                ShowAlert("Please select department!");
                Department.Focus();
                return;
            }

            if (Designation.SelectedValue == "-1")
            {
                ShowAlert("Please select designation!");
                Designation.Focus();
                return;
            }

            objCategory.CategoryQuesId = Convert.ToInt32(hdnId.Value);
            objCategory.QuestionName = QuestionName.Text.Trim();
            objCategory.DepartmentId = Convert.ToInt32(Department.SelectedValue);
            objCategory.CategoryId = Convert.ToInt32(ddlCategory.SelectedValue);
            objCategory.DesignationId = Convert.ToInt32(Designation.SelectedValue);
            objCategory.UpdatedBy = UserId.ToString();

            objCategory = SaveAuditCategoryDetails(objCategory);
            if (objCategory.CategoryQuesId > 0)
            {
                ShowAlert("Data has been updated successfully.");
                auditCatgDetails.EditIndex = -1;
                BindAuditCatgDetailsGridView();
            }
            else
            {
                ShowAlert("For Same Category, Department and Designation Question Cannot Duplicate!");
            }
            auditCatg.EditIndex = -1;
            BindAuditCatgGridView();
        }


        protected void auditCatg_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            auditCatg.PageIndex = e.NewPageIndex;
            BindAuditCatgGridView();
        }

        protected void auditCatgDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            auditCatgDetails.PageIndex = e.NewPageIndex;
            BindAuditCatgDetailsGridView();
        }

        protected void auditCatg_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            auditCatg.EditIndex = -1;
            BindAuditCatgGridView();
        }

        protected void auditCatgDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            auditCatgDetails.EditIndex = -1;
            BindAuditCatgDetailsGridView();
        }

        protected void auditCatg_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            AuditCategory objCategory = new AuditCategory();
            GridViewRow row = (GridViewRow)auditCatg.Rows[e.RowIndex];
            HiddenField hdnId = (HiddenField)row.FindControl("hdnId");

            objCategory.Id = Convert.ToInt32(hdnId.Value);

            objCategory.Id = this.adminController.DeleteAuditCategory(objCategory);
            if (objCategory.Id == -1)
            {
                ShowAlert("Audit Category can't be deleted until all Audit category will be deleted!");
            }
            else
            {
                BindAuditCatgGridView();
                BindAllInternalAuditCategory();
            }
        }

        protected void auditCatgDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            AuditCategoryDetails objCategory = new AuditCategoryDetails();
            GridViewRow row = (GridViewRow)auditCatgDetails.Rows[e.RowIndex];
            HiddenField hdnId = (HiddenField)row.FindControl("hdnCategoryQuesId");

            objCategory.CategoryQuesId = Convert.ToInt32(hdnId.Value);

            objCategory.CategoryQuesId = this.adminController.DeleteAuditCategoryDetails(objCategory);
            BindAuditCatgDetailsGridView();
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void btnShowAuditDetails_Click(object sender, EventArgs e)
        {
            BindAuditCatgDetailsGridView();
        }

        protected void ddlDepartmentEmpty_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (auditCatgDetails.Rows.Count == 0)
            {
                DropDownList ddlDeptEmpty = auditCatgDetails.Controls[0].Controls[0].FindControl("ddlDepartmentEmpty") as DropDownList;
                DropDownList ddlDesignationEmpty = auditCatgDetails.Controls[0].Controls[0].FindControl("ddlDesignationEmpty") as DropDownList;

                if (ddlDeptEmpty.SelectedValue != "--Select--")
                {
                    DataTable dtDesig = adminController.BindDesignationDdl(Convert.ToInt32(ddlDeptEmpty.SelectedValue));
                    ddlDesignationEmpty.DataSource = dtDesig;
                    ddlDesignationEmpty.DataTextField = "Name";
                    ddlDesignationEmpty.DataValueField = "Id";
                    ddlDesignationEmpty.DataBind();
                }
                else
                {
                    ddlDesignationEmpty.Items.Clear();
                    ddlDesignationEmpty.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
        }

        protected void ddlDepartmentFooter_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlDeptFooter = auditCatgDetails.FooterRow.FindControl("ddlDepartmentFooter") as DropDownList;
            DropDownList ddlDesigFooter = auditCatgDetails.FooterRow.FindControl("ddlDesignationFooter") as DropDownList;

             DataTable dtDesig;
             if (ddlDeptFooter.SelectedValue != "--Select--")
             {
                 dtDesig = adminController.BindDesignationDdl(Convert.ToInt32(ddlDeptFooter.SelectedValue));
                 ddlDesigFooter.DataSource = dtDesig;
                 ddlDesigFooter.DataTextField = "Name";
                 ddlDesigFooter.DataValueField = "Id";
                 ddlDesigFooter.DataBind();
             }
             else
             {
                 ddlDesigFooter.Items.Clear();
                 ddlDesigFooter.Items.Insert(0, new ListItem("--Select--", "0"));
             }
        }


    }
}