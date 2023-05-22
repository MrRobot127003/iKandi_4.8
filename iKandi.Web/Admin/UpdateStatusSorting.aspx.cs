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
  public partial class UpdateStatusSorting : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        FillStatus();
      }
    }

    private void FillStatus()
    {
      AdminController oAdminController = new AdminController();
      gvTargetAdminStatus.DataSource = oAdminController.FillTargetAdmin(true);
      gvTargetAdminStatus.DataBind();
      oAdminController = null;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      AdminController oAdminController = new AdminController();
      for (int i = 0; i < gvTargetAdminStatus.Rows.Count; i++)
      {
        TextBox txtOrder = (TextBox)gvTargetAdminStatus.Rows[i].FindControl("txtOrder");
        HiddenField hdnDesignationId = (HiddenField)gvTargetAdminStatus.Rows[i].FindControl("hdnStatusId");
        if (txtOrder.Text == "")
        {
          lblValidationMessage.Text = "Please enter order.";
          return;
        }
        else if (Convert.ToInt32(txtOrder.Text) < 1 || Convert.ToInt32(txtOrder.Text) > gvTargetAdminStatus.Rows.Count)
        {
          lblValidationMessage.Text = "Order should be in between 1 to" + gvTargetAdminStatus.Rows.Count.ToString();
          return;
        }
        else
        {
          lblValidationMessage.Text = "";
          for (int j = 0; j < gvTargetAdminStatus.Rows.Count; j++)
          {
            TextBox txtChkOrder = (TextBox)gvTargetAdminStatus.Rows[j].FindControl("txtOrder");
            if (txtOrder.Text == txtChkOrder.Text && i != j)
            {
              lblValidationMessage.Text = "Duplicate order cannot be added.";
              return;
            }
          }

          oAdminController.UpdateStatusOrder(Convert.ToInt32(hdnDesignationId.Value), Convert.ToInt32(txtOrder.Text));
        }
      }
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/TargetAdmin.aspx?rblHeaderValue=" + Convert.ToInt32(Request.QueryString["rblHeaderValue"]) + "&ddlClientsValue=" + Convert.ToInt32(Request.QueryString["ddlClientsValue"]) + "&chkAllClientsValue=" + Convert.ToBoolean(Request.QueryString["chkAllClientsValue"]) + "&chkFilteredClientValue=" + Convert.ToString(Request.QueryString["chkFilteredClientValue"]) + "');", true);
      oAdminController = null;
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/TargetAdmin.aspx?rblHeaderValue=" + Convert.ToInt32(Request.QueryString["rblHeaderValue"]) + "&ddlClientsValue=" + Convert.ToInt32(Request.QueryString["ddlClientsValue"]) + "&chkAllClientsValue=" + Convert.ToBoolean(Request.QueryString["chkAllClientsValue"]) + "&chkFilteredClientValue=" + Convert.ToString(Request.QueryString["chkFilteredClientValue"]) + "');", true);
    }
  }
}