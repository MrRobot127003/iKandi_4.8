using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.Admin
{
    public partial class AddDesignation : System.Web.UI.Page
    {
        int DepartmentId = 0, DesignationId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            DepartmentId = Convert.ToInt32(Request.QueryString["DepartmentId"]);
            DesignationId = Convert.ToInt32(Request.QueryString["DesignationId"]);
            AdminController oAdminController = new AdminController();
            DataTable dtDepartment = oAdminController.FillDepartmentDetails(DepartmentId);
            lblDivision.Text = dtDepartment.Rows[0]["DivisionName"].ToString();
            lblDepartment.Text = dtDepartment.Rows[0]["DepartmentName"].ToString();
            if (!IsPostBack)
            {
                FillLineDepartmentDetails();
                ddlLineDepartment.SelectedValue = DepartmentId.ToString();
                if (Convert.ToInt32(ddlLineDepartment.SelectedValue) > 0)
                {
                    FillLineDesignationDetails(Convert.ToInt32(ddlLineDepartment.SelectedValue));
                }
                FillDesignationTypeDetails();
                if (DesignationId > 0)
                {
                    FillDesignationDetails(DesignationId);
                    lblHeader.Text = "Update Designation";
                }
                else
                {
                    lblHeader.Text = "Add Designation";
                }
            }
            oAdminController = null;
        }

        private void FillDesignationDetails(int DesignationId)
        {
            AdminController oAdminController = new AdminController();
            DataTable dtDesignation = oAdminController.GetDesignationDetails(DesignationId);
            if (dtDesignation.Rows.Count > 0)
            {
                txtDesignation.Text = dtDesignation.Rows[0]["Name"].ToString();
                ddlLineDepartment.SelectedValue = dtDesignation.Rows[0]["LineDepartmentId"].ToString();
                FillLineDesignationDetails(Convert.ToInt32(ddlLineDepartment.SelectedValue));
                if (Convert.ToInt32(ddlLineDepartment.SelectedValue) != DepartmentId)
                {
                    ddlLineDesignation.Items.FindByValue("0").Text = "Select";
                }
                else
                {
                    ddlLineDesignation.Items.FindByValue("0").Text = "Self";
                }
                ddlLineDesignation.SelectedValue = dtDesignation.Rows[0]["LineDesignationID"].ToString();
                ddlDesignationType.SelectedValue = dtDesignation.Rows[0]["GlobalType"].ToString();
            }
            oAdminController = null;
        }

        private void FillLineDepartmentDetails()
        {
            AdminController oAdminController = new AdminController();
            ddlLineDepartment.DataSource = oAdminController.FillDepartmentDetails(0);
            ddlLineDepartment.DataTextField = "DepartmentName";
            ddlLineDepartment.DataValueField = "DepartmentId";
            ddlLineDepartment.DataBind();
            oAdminController = null;
        }

        protected void ddlLineDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblValidationMessage.Text = "";
            if (Convert.ToInt32(ddlLineDepartment.SelectedValue) > 0)
            {
                FillLineDesignationDetails(Convert.ToInt32(ddlLineDepartment.SelectedValue));
                ddlLineDesignation.Enabled = true;
                if (Convert.ToInt32(ddlLineDepartment.SelectedValue) != DepartmentId)
                {
                    ddlLineDesignation.Items.FindByValue("0").Text = "Select";
                }
                else
                {
                    ddlLineDesignation.Items.FindByValue("0").Text = "Self";
                }
            }
            else
            {
                ddlLineDesignation.Items.Clear();
                ddlLineDesignation.Items.Insert(0, new ListItem("Select", "0"));
                ddlLineDesignation.Enabled = false;
            }
        }

        private void FillLineDesignationDetails(int DepartmentId)
        {
            AdminController oAdminController = new AdminController();
            ddlLineDesignation.DataSource = oAdminController.FillDesignationDetails(DepartmentId);
            ddlLineDesignation.DataTextField = "DesignationName";
            ddlLineDesignation.DataValueField = "DesignationId";
            ddlLineDesignation.DataBind();
            oAdminController = null;
        }

        private void FillDesignationTypeDetails()
        {
            AdminController oAdminController = new AdminController();
            ddlDesignationType.DataSource = oAdminController.FillDesignationTypeDetails();
            ddlDesignationType.DataTextField = "DesignationType";
            ddlDesignationType.DataValueField = "DesignationTypeId";
            ddlDesignationType.DataBind();
            oAdminController = null;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtDesignation.Text == "")
            {
                lblValidationMessage.Text = "Please enter a Designation Name.";
                return;
            }
            else if (Convert.ToInt32(ddlLineDepartment.SelectedValue) == 0)
            {
                lblValidationMessage.Text = "Please select Line Department.";
                return;
            }
            else if (Convert.ToInt32(ddlLineDepartment.SelectedValue) > 0 && Convert.ToInt32(ddlLineDesignation.SelectedValue) == 0 && Convert.ToInt32(ddlLineDepartment.SelectedValue) != DepartmentId)
            {
                lblValidationMessage.Text = "Please select Line Designation.";
                return;
            }

            else
            {
                lblValidationMessage.Text = "";
                AdminController oAdminController = new AdminController();
                if (DesignationId > 0)
                {
                    if (oAdminController.CheckIsLineDesignationAvailable(DesignationId, Convert.ToInt32(ddlLineDesignation.SelectedValue)))
                    {
                        //Gajendra Designation
                        try
                        {
                        oAdminController.UpdateDesignation(DesignationId, txtDesignation.Text, Convert.ToInt32(ddlDesignationType.SelectedValue), Convert.ToInt32(ddlLineDesignation.SelectedValue));
                        }
                        catch (Exception ex)
                        {
                            lblValidationMessage.Text = ex.Message;
                            return;
                        }
                    }
                    else
                    {
                        lblValidationMessage.Text = "Selected Line Designation is not available for this Designation.";
                        return;
                    }
                }
                else
                {
                    if (oAdminController.CheckIsDesignationAvailable(DepartmentId, txtDesignation.Text))
                    {
                        lblValidationMessage.Text = "Duplicate Designation cannot be added.";
                        return;
                    }
                    else
                    {
                            oAdminController.AddDesignation(txtDesignation.Text, DepartmentId, Convert.ToInt32(ddlDesignationType.SelectedValue), Convert.ToInt32(ddlLineDesignation.SelectedValue));                      
                    }

                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/ManageDesignation.aspx');", true);
                oAdminController = null;
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/ManageDesignation.aspx');", true);
        }
    }
}