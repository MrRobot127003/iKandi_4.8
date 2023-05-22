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
    public partial class Auditors : System.Web.UI.Page
    {

        string CategoryQusId;
        Auditor auditor = new Auditor();
        AdminController adminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["CategoryQuesId"] != null)
            {
                CategoryQusId = Request.QueryString["CategoryQuesId"].ToString();
            }
            else CategoryQusId = "0";
            if (!Page.IsPostBack)
                Bindgrv();
        }

        protected void grdAuditor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddRow")
            {
                CreateAuditorsList();
            }
        }

        private void CreateAuditorsList()
        {
            if (grdAuditor.Rows.Count == 0)
            {
                TextBox txtAuditor = grdAuditor.Controls[0].Controls[0].FindControl("txtAuditorEmpty") as TextBox;
                int iSave = 0;
                UserController userController = new UserController();
                int Id = userController.GetUserIdByName(txtAuditor.Text);
                auditor.CategoryQusId = Convert.ToInt32(CategoryQusId);
                auditor.UserId = Id;
                if (Id != 0)
                {
                    iSave = adminController.SaveAuditors(auditor);
                }
                else
                {
                    txtAuditor.Text = string.Empty;
                }
                if (iSave > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:SavedSuccessfully();", true);
                }
            }

            else
            {
                TextBox txtAuditor = (TextBox)grdAuditor.FooterRow.FindControl("txtAuditor");
                int iSave = 0;
                UserController userController = new UserController();
                int Id = userController.GetUserIdByName(txtAuditor.Text);
                auditor.CategoryQusId = Convert.ToInt32(CategoryQusId);
                auditor.UserId = Id;
                if (Id != 0)
                {
                    iSave = adminController.SaveAuditors(auditor);
                }
                else
                {
                    txtAuditor.Text = string.Empty;
                }
                if (iSave > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:SavedSuccessfully();", true);
                }
            }

            Bindgrv();
        }

        private void Bindgrv()
        {
            AuditCategoryDetails auditDetails = new AuditCategoryDetails();
            auditDetails = adminController.GetAuditDetails(Convert.ToInt32(CategoryQusId));
            if (auditDetails.AllDetailsSameCatg)
                rbtAllDetailsForSameCatg.Checked = true;
            if (auditDetails.AllCatgAllDetails)
                rbtAllCatsAllDetails.Checked = true;
            DataTable dtAuditor = adminController.GetAuditorsByCatgQusId(Convert.ToInt32(CategoryQusId));

            grdAuditor.DataSource = dtAuditor;
            grdAuditor.DataBind();
        }



        protected void grdAuditor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = 0;
            GridViewRow row = (GridViewRow)grdAuditor.Rows[e.RowIndex];
            HiddenField hdnId = (HiddenField)row.FindControl("hdnUserID");

            Id = adminController.DeleteAuditorById(Convert.ToInt32(hdnId.Value));
            Bindgrv();
        }

        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            AuditCategoryDetails auditCatg = new AuditCategoryDetails();
            int CatgQusId = 0;
            auditCatg.CategoryQuesId = Convert.ToInt32(CategoryQusId);
            if (rbtAllDetailsForSameCatg.Checked)
                auditCatg.AllDetailsSameCatg = true;
            else
                auditCatg.AllCatgAllDetails = true;

            auditCatg.UpdatedBy = Convert.ToString(ApplicationHelper.LoggedInUser.UserData.UserID);
            CatgQusId = adminController.UpdateAuditDetails(auditCatg);
            Page.ClientScript.RegisterStartupScript(typeof(Page), "ShowMsg", "CallBackParentPage();", true);
        }
    }
}