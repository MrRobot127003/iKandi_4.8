using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Text;
using System.Collections;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.Admin
{
  public partial class CopyFrom : System.Web.UI.Page
  {
    int ClientId = 0, UserId = 0;
    string DesignationType = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      ClientId = Convert.ToInt32(Request.QueryString["ClientId"]);
      DesignationType = Convert.ToString(Request.QueryString["DesignationType"]);
      UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
      if (!IsPostBack)
      {
        FillDesignation();
      }
    }

    private void FillDesignation()
    {
      AdminController oAdminController = new AdminController();
      if (DesignationType == "Email")
      {
        ddlCopyFrom.DataSource = oAdminController.GetCopyFromEmailDataDetails(ClientId);
        ddlCopyFrom.DataTextField = "CompanyName";
        ddlCopyFrom.DataValueField = "ClientID";
        ddlCopyFrom.DataBind();
      }
      else
      {
        ddlCopyFrom.DataSource = oAdminController.GetCopyFromDataDetails(ClientId);
        ddlCopyFrom.DataTextField = "CompanyName";
        ddlCopyFrom.DataValueField = "ClientID";
        ddlCopyFrom.DataBind();
      }
      oAdminController = null;
    }

    protected void ddlCopyFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
      AdminController oAdminController = new AdminController();
      string confirmValue = Request.Form["confirm_value"];
      if (confirmValue == "Yes")
      {
        if (Convert.ToInt32(ddlCopyFrom.SelectedValue) > -2)
        {
          if (DesignationType == "Email")
          {
            oAdminController.UpdateCopyFromEmail(ClientId, Convert.ToInt32(ddlCopyFrom.SelectedValue), UserId);
          }
          else
          {
            oAdminController.UpdateCopyFrom(ClientId, Convert.ToInt32(ddlCopyFrom.SelectedValue), UserId);
          }
          ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/TargetAdmin.aspx?rblHeaderValue=" + Convert.ToInt32(Request.QueryString["rblHeaderValue"]) + "&ddlClientsValue=" + Convert.ToInt32(Request.QueryString["ddlClientsValue"]) + "&chkAllClientsValue=" + Convert.ToBoolean(Request.QueryString["chkAllClientsValue"]) + "&chkFilteredClientValue=" + Convert.ToString(Request.QueryString["chkFilteredClientValue"]) + "');", true);
        }
      }
      else
      {
        ddlCopyFrom.SelectedValue = "-2";
      }
      oAdminController = null;
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/TargetAdmin.aspx?rblHeaderValue=" + Convert.ToInt32(Request.QueryString["rblHeaderValue"]) + "&ddlClientsValue=" + Convert.ToInt32(Request.QueryString["ddlClientsValue"]) + "&chkAllClientsValue=" + Convert.ToBoolean(Request.QueryString["chkAllClientsValue"]) + "&chkFilteredClientValue=" + Convert.ToString(Request.QueryString["chkFilteredClientValue"]) + "');", true);
    }
  }
}