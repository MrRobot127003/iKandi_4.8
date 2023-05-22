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
    public partial class InternalAudit : System.Web.UI.Page
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
                BindddlCategory();
                DataSet ds = adminController.GetAllUnit();
                rbtUnit.DataSource = ds;
                rbtUnit.DataTextField = "UnitName";
                rbtUnit.DataValueField = "Id";
                rbtUnit.DataBind();
                if (rbtUnit.Items.Count > 0)
                    rbtUnit.Items[1].Selected = true;
                BindInternalAuditGridView();
                SaveInternalMonthlyAuditDetails();
            }
        }

        private void BindddlCategory()
        {
            auditCategories = adminController.GetAllAuditCategories(0);
            ddlcategory.DataSource = auditCategories;
            ddlcategory.DataTextField = "InternalAuditCatgName";
            ddlcategory.DataValueField = "Id";
            ddlcategory.DataBind();
        }


        private void BindInternalAuditGridView()
        {
            if (ddlcategory.SelectedValue != string.Empty && rbtUnit.SelectedValue != string.Empty)
            {
                DataTable dtInternalAudit = adminController.GetInternalAudit(Convert.ToInt32(ddlcategory.SelectedValue), Convert.ToInt32(rbtUnit.SelectedValue));
                internalAuditGD.DataSource = dtInternalAudit;
                internalAuditGD.DataBind();
                if (internalAuditGD.Rows.Count == 0)
                    btnSubmit.Visible = false;
            }
        }

        protected void internalAuditGD_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPrevMonthStatus = (Label)e.Row.FindControl("lblPrevMonthStatus");
                TextBox txtDuration = (TextBox)e.Row.FindControl("capDuration");
                RadioButton rbtFail = (RadioButton)e.Row.FindControl("rbtFail");
                RadioButton rbtPass = (RadioButton)e.Row.FindControl("rbtPass");
                HiddenField hdnDept = (HiddenField)e.Row.FindControl("hdnDeptId");
                HiddenField hdnDesigId = (HiddenField)e.Row.FindControl("hdnDesigId");
                HyperLink lnkFileUpload = (HyperLink)e.Row.FindControl("lnkFileUpload");
                HiddenField hdnQusId = (HiddenField)e.Row.FindControl("hdnQusId");

                AuditCategoryDetails auditDetail = new AuditCategoryDetails();

                bool CheckAuditor = adminController.CheckAuditor(Convert.ToInt32(hdnQusId.Value), ApplicationHelper.LoggedInUser.UserData.UserID);
                auditDetail = adminController.GetAuditDetails(Convert.ToInt32(hdnQusId.Value));

                if (!CheckAuditor)
                {
                    if (!auditDetail.AllDetailsSameCatg && auditDetail.CategoryId != Convert.ToInt32(ddlcategory.SelectedValue))
                    {
                        e.Row.Enabled = false;
                        e.Row.Cells[9].Text = "File Upload";
                    }

                    else if (!auditDetail.AllCatgAllDetails)
                    {
                        e.Row.Enabled = false;
                        e.Row.Cells[9].Text = "File Upload";
                    }

                }

                if (lblPrevMonthStatus.Text != "")
                    lblPrevMonthStatus.Text = lblPrevMonthStatus.Text == "True" ? "Pass" : "Fail";
                else
                    lblPrevMonthStatus.Text = "";

                if (rbtFail.Text == "False")
                {
                    rbtFail.Text = "Fail";
                    rbtFail.Checked = true;
                }
                if (rbtPass.Text == "True")
                {
                    rbtPass.Text = "Pass";
                    rbtPass.Checked = true;
                }
                rbtFail.Text = "Fail";
                rbtPass.Text = "Pass";

                if (txtDuration.Text != "")
                    txtDuration.Text = Convert.ToDateTime(txtDuration.Text).ToString("dd MMM yy");
                if (lblPrevMonthStatus.Text == "Pass")
                    lblPrevMonthStatus.ForeColor = System.Drawing.Color.Green;
                else if (lblPrevMonthStatus.Text == "Fail")
                    lblPrevMonthStatus.ForeColor = System.Drawing.Color.Red;
            }
        }
        public bool Validategrd()
        {
            bool result = true;
            foreach (GridViewRow gvr in internalAuditGD.Rows)
            {
                HiddenField hdnQusId = (HiddenField)gvr.FindControl("hdnQusId");
                RadioButton rbtFail = (RadioButton)gvr.FindControl("rbtFail");
                RadioButton rbtPass = (RadioButton)gvr.FindControl("rbtPass");
                TextBox txtDuration = (TextBox)gvr.FindControl("capDuration");
                TextBox txtCAP = (TextBox)gvr.FindControl("txtCAP");
                TextBox txtObservation = (TextBox)gvr.FindControl("txtObservation");
                if (rbtFail.Checked == true)
                {
                    if (txtDuration.Text == "")
                    {
                        result = false;
                    }
                }

            }
            return result;
        }
        public void Save()
        {
            if (Validategrd() == false)
            {
                ShowAlert("Select CAP Date!");
                return;
            }
            InternalMonthlyAudit monthlyAudit = new InternalMonthlyAudit();
            int iSave = 0;
            if (internalAuditGD.Rows.Count > 0)
            {
                foreach (GridViewRow gvr in internalAuditGD.Rows)
                {
                    HiddenField hdnQusId = (HiddenField)gvr.FindControl("hdnQusId");
                    RadioButton rbtFail = (RadioButton)gvr.FindControl("rbtFail");
                    RadioButton rbtPass = (RadioButton)gvr.FindControl("rbtPass");
                    TextBox txtDuration = (TextBox)gvr.FindControl("capDuration");
                    TextBox txtCAP = (TextBox)gvr.FindControl("txtCAP");
                    TextBox txtObservation = (TextBox)gvr.FindControl("txtObservation");

                    monthlyAudit.CategoryQuesId = Convert.ToInt32(hdnQusId.Value);
                    if (rbtPass.Checked)
                        monthlyAudit.MonthlyStatus = "1";
                    else if (rbtFail.Checked)
                        monthlyAudit.MonthlyStatus = "0";
                    else
                        monthlyAudit.MonthlyStatus = null;
                    if (txtDuration.Text != string.Empty)
                        monthlyAudit.CapDuration = Convert.ToDateTime(txtDuration.Text);
                    else
                        monthlyAudit.CapDuration = DateTime.MinValue;

                    monthlyAudit.Cap = txtCAP.Text;
                    monthlyAudit.Observation = txtObservation.Text;
                    monthlyAudit.UnitId = Convert.ToInt32(rbtUnit.SelectedValue);
                    monthlyAudit.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                    monthlyAudit.AuditBy = ApplicationHelper.LoggedInUser.UserData.FirstName + ' ' + ApplicationHelper.LoggedInUser.UserData.LastName;
                    iSave = adminController.SaveInternalMonthlyAudit(monthlyAudit);
                    if (iSave > 0 || iSave == -1)
                    {
                        ShowAlert("Data has save successfully!");
                        BindInternalAuditGridView();
                    }

                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void rbtUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindInternalAuditGridView();
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (internalAuditGD.Rows.Count != 0)
                btnSubmit.Visible = true;
            else
            {
                btnSubmit.Visible = false;
            }
           
            BindInternalAuditGridView();
           // SaveInternalMonthlyAuditDetails();
        }

        public void SaveInternalMonthlyAuditDetails()
        {
            // Save the detail
            InternalMonthlyAudit monthlyAudit = new InternalMonthlyAudit();
            int iSave = 0;
            if (internalAuditGD.Rows.Count > 0)
            {
                foreach (GridViewRow gvr in internalAuditGD.Rows)
                {
                    HiddenField hdnQusId = (HiddenField)gvr.FindControl("hdnQusId");
                    RadioButton rbtFail = (RadioButton)gvr.FindControl("rbtFail");
                    RadioButton rbtPass = (RadioButton)gvr.FindControl("rbtPass");
                    TextBox txtDuration = (TextBox)gvr.FindControl("capDuration");
                    TextBox txtCAP = (TextBox)gvr.FindControl("txtCAP");
                    TextBox txtObservation = (TextBox)gvr.FindControl("txtObservation");

                    monthlyAudit.CategoryQuesId = Convert.ToInt32(hdnQusId.Value);
                    if (rbtPass.Checked)
                        monthlyAudit.MonthlyStatus = "1";
                    else if (rbtFail.Checked)
                        monthlyAudit.MonthlyStatus = "0";
                    else
                        monthlyAudit.MonthlyStatus = null;
                    if (txtDuration.Text != string.Empty)
                        monthlyAudit.CapDuration = Convert.ToDateTime(txtDuration.Text);
                    monthlyAudit.Cap = txtCAP.Text;
                    monthlyAudit.Observation = txtObservation.Text;
                    monthlyAudit.UnitId = Convert.ToInt32(rbtUnit.SelectedValue);
                    monthlyAudit.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                    monthlyAudit.AuditBy = ApplicationHelper.LoggedInUser.UserData.FirstName + ' ' + ApplicationHelper.LoggedInUser.UserData.LastName;
                    iSave = adminController.SaveInternalMonthlyAudit(monthlyAudit);
                    if (iSave > 0 || iSave == -1)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:SavedSuccessfully();", true);
                    }

                }
            }
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void internalAuditGD_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            internalAuditGD.PageIndex = e.NewPageIndex;
            BindInternalAuditGridView();
        }
    }
}