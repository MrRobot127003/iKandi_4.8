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
  public partial class UpdatePredecessor : System.Web.UI.Page
  {
    int ClientId = 0, StatusId = 0, UserId = 0;

    ArrayList alPredecessor = new ArrayList();
    ArrayList alUpdatePredecessor = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
      UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
      ClientId = Convert.ToInt32(Request.QueryString["ClientId"]);
      StatusId = Convert.ToInt32(Request.QueryString["StatusId"]);

      if (!IsPostBack)
      {
        FillStatus();
        FillUpdatedStatus();
      }
    }

    private void FillStatus()
    {
      AdminController oAdminController = new AdminController();
      lstPredecessor.DataSource = oAdminController.FillPredecessorDetails(StatusId, ClientId);
      lstPredecessor.DataTextField = "StatusModeName";
      lstPredecessor.DataValueField = "StatusModeId";
      lstPredecessor.DataBind();
      oAdminController = null;
    }

    private void FillUpdatedStatus()
    {
      AdminController oAdminController = new AdminController();
      DataTable dtDays_PredecessorDetails = oAdminController.GetDays_PredecessorDetails(StatusId, ClientId);
      DataView dvDays_PredecessorDetails = new DataView(dtDays_PredecessorDetails);
      dvDays_PredecessorDetails.RowFilter = "StatusModeId <> 0";



      lstUpdatePredecessor.DataSource = dvDays_PredecessorDetails;
      lstUpdatePredecessor.DataTextField = "Predecessor";
      lstUpdatePredecessor.DataValueField = "StatusModeId";
      lstUpdatePredecessor.DataBind();
      oAdminController = null;
    }

    protected void btnAddAll_Click(object sender, EventArgs e)
    {
      while (lstPredecessor.Items.Count != 0)
      {
        for (int i = 0; i < lstPredecessor.Items.Count; i++)
        {
          lstUpdatePredecessor.Items.Add(lstPredecessor.Items[i]);
          lstPredecessor.Items.Remove(lstPredecessor.Items[i]);
        }
      }
    }

    protected void btnRemoveAll_Click(object sender, EventArgs e)
    {
      while (lstUpdatePredecessor.Items.Count != 0)
      {
        for (int i = 0; i < lstUpdatePredecessor.Items.Count; i++)
        {
          lstPredecessor.Items.Add(lstUpdatePredecessor.Items[i]);
          lstUpdatePredecessor.Items.Remove(lstUpdatePredecessor.Items[i]);
        }
      }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
      if (lstPredecessor.SelectedIndex >= 0)
      {
        for (int i = 0; i < lstPredecessor.Items.Count; i++)
        {
          if (lstPredecessor.Items[i].Selected)
          {
            if (!alPredecessor.Contains(lstPredecessor.Items[i]))
            {
              alPredecessor.Add(lstPredecessor.Items[i]);

            }
          }
        }
        for (int i = 0; i < alPredecessor.Count; i++)
        {
          if (!lstUpdatePredecessor.Items.Contains(((ListItem)alPredecessor[i])))
          {
            lstUpdatePredecessor.Items.Add(((ListItem)alPredecessor[i]));
          }
          lstPredecessor.Items.Remove(((ListItem)alPredecessor[i]));
        }
        lstUpdatePredecessor.SelectedIndex = -1;
      }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
      if (lstUpdatePredecessor.SelectedIndex >= 0)
      {
        for (int i = 0; i < lstUpdatePredecessor.Items.Count; i++)
        {
          if (lstUpdatePredecessor.Items[i].Selected)
          {
            if (!alUpdatePredecessor.Contains(lstUpdatePredecessor.Items[i]))
            {
              alUpdatePredecessor.Add(lstUpdatePredecessor.Items[i]);
            }
          }
        }
        for (int i = 0; i < alUpdatePredecessor.Count; i++)
        {
          if (!lstPredecessor.Items.Contains(((ListItem)alUpdatePredecessor[i])))
          {
            lstPredecessor.Items.Add(((ListItem)alUpdatePredecessor[i]));
          }
          lstUpdatePredecessor.Items.Remove(((ListItem)alUpdatePredecessor[i]));
        }
        lstPredecessor.SelectedIndex = -1;
      }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      string Predecessor = "";
      AdminController oAdminController = new AdminController();

      foreach (ListItem lst in lstUpdatePredecessor.Items)
      {
        Predecessor += lst.Value.ToString() + ",";
      }
      int index = Predecessor.LastIndexOf(',');
      Predecessor = Predecessor == "" ? "" : Predecessor.Remove(index, 1);
      oAdminController.UpdatePredecessor(StatusId, ClientId, Predecessor, UserId);
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/TargetAdmin.aspx?rblHeaderValue=" + Convert.ToInt32(Request.QueryString["rblHeaderValue"]) + "&ddlClientsValue=" + Convert.ToInt32(Request.QueryString["ddlClientsValue"]) + "&chkAllClientsValue=" + Convert.ToBoolean(Request.QueryString["chkAllClientsValue"]) + "&chkFilteredClientValue=" + Convert.ToString(Request.QueryString["chkFilteredClientValue"]) + "');", true);

      oAdminController = null;
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
      ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.top.location.replace('/Admin/TargetAdmin.aspx?rblHeaderValue=" + Convert.ToInt32(Request.QueryString["rblHeaderValue"]) + "&ddlClientsValue=" + Convert.ToInt32(Request.QueryString["ddlClientsValue"]) + "&chkAllClientsValue=" + Convert.ToBoolean(Request.QueryString["chkAllClientsValue"]) + "&chkFilteredClientValue=" + Convert.ToString(Request.QueryString["chkFilteredClientValue"]) + "');", true);
    }
  }
}