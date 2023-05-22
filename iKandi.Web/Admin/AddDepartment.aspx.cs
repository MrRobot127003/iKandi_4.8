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
  public partial class AddDepartment : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        FillManageDesignation();
      }
    }

    private void FillManageDesignation()
    {
      AdminController oAdminController = new AdminController();
      ddlDivision.DataSource = oAdminController.FillDivisionDetails();
      ddlDivision.DataTextField = "DivisionName";
      ddlDivision.DataValueField = "ManageDivisionID";
      ddlDivision.DataBind();
      oAdminController = null;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (Convert.ToInt32(ddlDivision.SelectedValue) == 0)
      {
        lblValidationMessage.Text = "Please select a Division.";
        return;
      }
      else if (txtDepartment.Text == "")
      {
        lblValidationMessage.Text = "Please enter a Department Name.";
        return;
      }
      else
      {
        lblValidationMessage.Text = "";
        AdminController oAdminController = new AdminController();
        int iResult = oAdminController.AddDepartment(txtDepartment.Text, Convert.ToInt32(ddlDivision.SelectedValue), chkIsActive.Checked);
        if (iResult > 0)
        {
          ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/ManageDesignation.aspx');", true);
        }
        else
        {
          ScriptManager.RegisterStartupScript(this, this.GetType(), "err_msg", "alert('You cannot be added Duplicate Department Name. Please Check.');", true);
        }
        oAdminController = null;
      }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/ManageDesignation.aspx');", true);
    }
  }
}