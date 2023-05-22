using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Text;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.Admin
{
  public partial class UpdateDesignationSorting : System.Web.UI.Page
  {
    int DepartmentId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
      DepartmentId = Convert.ToInt32(Request.QueryString["DepartmentId"]);
      if (!IsPostBack)
      {
        FillManageDesignation();
      }
    }

    private void FillManageDesignation()
    {
      AdminController oAdminController = new AdminController();
      gvManageDesignation.DataSource = oAdminController.FillDesignationTypeDetails(DepartmentId);
      gvManageDesignation.DataBind();
      oAdminController = null;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      AdminController oAdminController = new AdminController();
      for (int i = 0; i < gvManageDesignation.Rows.Count; i++)
      {
        TextBox txtOrder = (TextBox)gvManageDesignation.Rows[i].FindControl("txtOrder");
        HiddenField hdnDesignationId = (HiddenField)gvManageDesignation.Rows[i].FindControl("hdnDesignationId");
        if (txtOrder.Text == "")
        {
          lblValidationMessage.Text = "Please enter order.";
          return;
        }
        else if (Convert.ToInt32(txtOrder.Text) < 1 || Convert.ToInt32(txtOrder.Text) > gvManageDesignation.Rows.Count)
        {
          lblValidationMessage.Text = "Order should be in between 1 to" + gvManageDesignation.Rows.Count.ToString();
          return;
        }
        else
        {
          lblValidationMessage.Text = "";
          for (int j = 0; j < gvManageDesignation.Rows.Count; j++)
          {
            TextBox txtChkOrder = (TextBox)gvManageDesignation.Rows[j].FindControl("txtOrder");
            if (txtOrder.Text == txtChkOrder.Text && i != j)
            {
              lblValidationMessage.Text = "Duplicate order cannot be added.";
              return;
            }
          }
          
          oAdminController.UpdateDesignationOrder(Convert.ToInt32(txtOrder.Text), DepartmentId, Convert.ToInt32(hdnDesignationId.Value));
        }
      }
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/ManageDesignation.aspx');", true);
      oAdminController = null;
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/ManageDesignation.aspx');", true);
    }
  }
}