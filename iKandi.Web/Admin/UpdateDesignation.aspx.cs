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
  public partial class UpdateDesignation : System.Web.UI.Page
  {
    int ClientId = 0, StatusId = 0, UserId = 0, EmailId = 0;
    string DesignationType = "";

    ArrayList alDesignation = new ArrayList();
    ArrayList alUpdatedDesignation = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
      UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
      ClientId = Convert.ToInt32(Request.QueryString["ClientId"]);
      StatusId = Convert.ToInt32(Request.QueryString["StatusId"]);
      EmailId = Convert.ToInt32(Request.QueryString["EmailId"]);
      DesignationType = Convert.ToString(Request.QueryString["DesignationType"]);

      if (!IsPostBack)
      {
        FillDesignation();
        FillUpdatedDesignation();
      }
    }

    private void FillDesignation()
    {
      AdminController oAdminController = new AdminController();
      if (DesignationType == "Email")
      {
        lstDesignation.DataSource = oAdminController.FillEmailDesignationDetails(EmailId, ClientId);
        lstDesignation.DataTextField = "Designation";
        lstDesignation.DataValueField = "DesignationId";
        lstDesignation.DataBind();
      }
      else
      {
        if ((ClientId > 0 || ClientId == -1) && Convert.ToString(Request.QueryString["Notification"]) == "yes")
        {
          lstDesignation.DataSource = oAdminController.FillNotificationDetails(StatusId, ClientId);
          lstDesignation.DataTextField = "Designation";
          lstDesignation.DataValueField = "DesignationId";
          lstDesignation.DataBind();
        }
        else if ((ClientId > 0 || ClientId == -1) && Convert.ToString(Request.QueryString["MOFilterNotification"]) == "yes")
        {
          lstDesignation.DataSource = oAdminController.FillMOFilterNotificationDetails(StatusId, ClientId);
          lstDesignation.DataTextField = "Designation";
          lstDesignation.DataValueField = "DesignationId";
          lstDesignation.DataBind();
        }
        else if ((ClientId > 0 || ClientId == -1) && Convert.ToString(Request.QueryString["DelayNotification"]) == "yes")
        {
          lstDesignation.DataSource = oAdminController.FillDelayNotificationDetails(StatusId, ClientId);
          lstDesignation.DataTextField = "Designation";
          lstDesignation.DataValueField = "DesignationId";
          lstDesignation.DataBind();
        }
        else
        {
          if (ClientId > 0 || ClientId == -1)
          {
            lstDesignation.DataSource = oAdminController.FillDesignationDetails(StatusId, ClientId);
            lstDesignation.DataTextField = "Designation";
            lstDesignation.DataValueField = "DesignationId";
            lstDesignation.DataBind();
          }
          else
          {
            lstDesignation.DataSource = oAdminController.FillDirectTaskDesignationDetails(StatusId);
            lstDesignation.DataTextField = "Designation";
            lstDesignation.DataValueField = "DesignationId";
            lstDesignation.DataBind();
          }
        }
      }
      oAdminController = null;
    }

    private void FillUpdatedDesignation()
    {
      AdminController oAdminController = new AdminController();
      if (DesignationType == "Email")
      {
        lstUpdatedDesignation.DataSource = oAdminController.GetEmailDesignationDetails(EmailId, ClientId);
        lstUpdatedDesignation.DataTextField = "Designation";
        lstUpdatedDesignation.DataValueField = "DesignationId";
        lstUpdatedDesignation.DataBind();
      }
      else
      {
        if ((ClientId > 0 || ClientId == -1) && Convert.ToString(Request.QueryString["Notification"]) == "yes")
        {
          lstUpdatedDesignation.DataSource = oAdminController.GetNotificationDetails(StatusId, ClientId);
          lstUpdatedDesignation.DataTextField = "Designation";
          lstUpdatedDesignation.DataValueField = "DesignationId";
          lstUpdatedDesignation.DataBind();
        }
        else if ((ClientId > 0 || ClientId == -1) && Convert.ToString(Request.QueryString["MOFilterNotification"]) == "yes")
        {
          lstUpdatedDesignation.DataSource = oAdminController.GetMOFilterNotificationDetails(StatusId, ClientId);
          lstUpdatedDesignation.DataTextField = "Designation";
          lstUpdatedDesignation.DataValueField = "DesignationId";
          lstUpdatedDesignation.DataBind();
        }
        else if ((ClientId > 0 || ClientId == -1) && Convert.ToString(Request.QueryString["DelayNotification"]) == "yes")
        {
          lstUpdatedDesignation.DataSource = oAdminController.GetDelayNotificationDetails(StatusId, ClientId);
          lstUpdatedDesignation.DataTextField = "Designation";
          lstUpdatedDesignation.DataValueField = "DesignationId";
          lstUpdatedDesignation.DataBind();
        }
        else
        {
          if (ClientId > 0 || ClientId == -1)
          {
            lstUpdatedDesignation.DataSource = oAdminController.GetDesignationDetails(StatusId, ClientId);
            lstUpdatedDesignation.DataTextField = "Designation";
            lstUpdatedDesignation.DataValueField = "DesignationId";
            lstUpdatedDesignation.DataBind();
          }
          else
          {
            lstUpdatedDesignation.DataSource = oAdminController.GetDirectTasksDesignationDetails(StatusId);
            lstUpdatedDesignation.DataTextField = "Designation";
            lstUpdatedDesignation.DataValueField = "DesignationId";
            lstUpdatedDesignation.DataBind();
          }
        }
      }
      oAdminController = null;
    }

    protected void btnAddAll_Click(object sender, EventArgs e)
    {
      while (lstDesignation.Items.Count != 0)
      {
        for (int i = 0; i < lstDesignation.Items.Count; i++)
        {
          lstUpdatedDesignation.Items.Add(lstDesignation.Items[i]);
          lstDesignation.Items.Remove(lstDesignation.Items[i]);
        }
      }
    }

    protected void btnRemoveAll_Click(object sender, EventArgs e)
    {
      while (lstUpdatedDesignation.Items.Count != 0)
      {
        for (int i = 0; i < lstUpdatedDesignation.Items.Count; i++)
        {
          lstDesignation.Items.Add(lstUpdatedDesignation.Items[i]);
          lstUpdatedDesignation.Items.Remove(lstUpdatedDesignation.Items[i]);
        }
      }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
      if (lstDesignation.SelectedIndex >= 0)
      {
        for (int i = 0; i < lstDesignation.Items.Count; i++)
        {
          if (lstDesignation.Items[i].Selected)
          {
            if (!alDesignation.Contains(lstDesignation.Items[i]))
            {
              alDesignation.Add(lstDesignation.Items[i]);

            }
          }
        }
        for (int i = 0; i < alDesignation.Count; i++)
        {
          if (!lstUpdatedDesignation.Items.Contains(((ListItem)alDesignation[i])))
          {
            lstUpdatedDesignation.Items.Add(((ListItem)alDesignation[i]));
          }
          lstDesignation.Items.Remove(((ListItem)alDesignation[i]));
        }
        lstUpdatedDesignation.SelectedIndex = -1;
      }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
      if (lstUpdatedDesignation.SelectedIndex >= 0)
      {
        for (int i = 0; i < lstUpdatedDesignation.Items.Count; i++)
        {
          if (lstUpdatedDesignation.Items[i].Selected)
          {
            if (!alUpdatedDesignation.Contains(lstUpdatedDesignation.Items[i]))
            {
              alUpdatedDesignation.Add(lstUpdatedDesignation.Items[i]);
            }
          }
        }
        for (int i = 0; i < alUpdatedDesignation.Count; i++)
        {
          if (!lstDesignation.Items.Contains(((ListItem)alUpdatedDesignation[i])))
          {
            lstDesignation.Items.Add(((ListItem)alUpdatedDesignation[i]));
          }
          lstUpdatedDesignation.Items.Remove(((ListItem)alUpdatedDesignation[i]));
        }
        lstDesignation.SelectedIndex = -1;
      }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string DesignationId = "";
        AdminController oAdminController = new AdminController();
        if (lstUpdatedDesignation.Items.Count > 0)
        {
            foreach (ListItem lst in lstUpdatedDesignation.Items)
            {
                DesignationId += lst.Value.ToString() + ",";
            }
            int index = DesignationId.LastIndexOf(',');
            DesignationId = DesignationId.Remove(index, 1);
        }

        if (DesignationType == "Email")
        {
            oAdminController.UpdateEmailDesignation(EmailId, ClientId, DesignationId, UserId);
        }
        else
        {
            if ((ClientId > 0 || ClientId == -1) && Convert.ToString(Request.QueryString["Notification"]) == "yes")
            {
                oAdminController.UpdateNotification(StatusId, ClientId, DesignationId, UserId);
            }
            else if ((ClientId > 0 || ClientId == -1) && Convert.ToString(Request.QueryString["MOFilterNotification"]) == "yes")
            {
              oAdminController.UpdateMOFilterNotification(StatusId, ClientId, DesignationId, UserId);
            }
            else if ((ClientId > 0 || ClientId == -1) && Convert.ToString(Request.QueryString["DelayNotification"]) == "yes")
            {
              oAdminController.UpdateDelayNotification(StatusId, ClientId, DesignationId, UserId);
            }
            else
            {
              if (ClientId > 0 || ClientId == -1)
              {
                oAdminController.UpdateDesignation(StatusId, ClientId, DesignationId, UserId);
              }
              else
              {
                oAdminController.UpdateDirectTaskDesignation(StatusId, DesignationId);
              }
            }
        }

        if (ClientId > 0 || ClientId == -1)
        {
          ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/TargetAdmin.aspx?rblHeaderValue=" + Convert.ToInt32(Request.QueryString["rblHeaderValue"]) + "&ddlClientsValue=" + Convert.ToInt32(Request.QueryString["ddlClientsValue"]) + "&chkAllClientsValue=" + Convert.ToBoolean(Request.QueryString["chkAllClientsValue"]) + "&chkFilteredClientValue=" + Convert.ToString(Request.QueryString["chkFilteredClientValue"]) + "');", true);
        }
        else
        {
          ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/TargetAdmin.aspx?rblHeaderValue=" + Convert.ToInt32(Request.QueryString["rblHeaderValue"]) + "');", true);
        }
        oAdminController = null;
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
      if (ClientId > 0 || ClientId == -1)
      {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/TargetAdmin.aspx?rblHeaderValue=" + Convert.ToInt32(Request.QueryString["rblHeaderValue"]) + "&ddlClientsValue=" + Convert.ToInt32(Request.QueryString["ddlClientsValue"]) + "&chkAllClientsValue=" + Convert.ToBoolean(Request.QueryString["chkAllClientsValue"]) + "&chkFilteredClientValue=" + Convert.ToString(Request.QueryString["chkFilteredClientValue"]) + "');", true);
      }
      else
      {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/TargetAdmin.aspx?rblHeaderValue=" + Convert.ToInt32(Request.QueryString["rblHeaderValue"]) + "');", true);
      }
    }
  }
}