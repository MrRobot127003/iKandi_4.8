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
  public partial class TargetAdmin : System.Web.UI.Page
  {
    StringBuilder htmlTable = new StringBuilder();
    int UserId = 0;
    string FilteredClientIds = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

      string baseSiteUrl = Constants.BaseSiteUrl.ToUpper().Replace("HTTP://", "").Replace("WWW.", "");
      string siteBaseUrl = Constants.SITE_BASE_URL.ToUpper().Replace("HTTP://", "").Replace("WWW.", "");
      if (baseSiteUrl.Contains(siteBaseUrl))
      {
        Page.Title = "IKANDI FASHION";
      }
      else
      {
        Page.Title = "Boutique International Pvt. Ltd.";
      }

      if (!IsPostBack)
      {
        if (Convert.ToInt32(Request.QueryString["rblHeaderValue"]) > 0)
        {
          rblHeader.SelectedValue = Convert.ToString(Request.QueryString["rblHeaderValue"]);
        }
        if (Convert.ToInt32(Request.QueryString["ddlClientsValue"]) > 0)
        {
          ddlClients.SelectedValue = Convert.ToString(Request.QueryString["ddlClientsValue"]);
        }
        if (Request.QueryString["chkAllClientsValue"] != null)
        {
          chkAllClients.Checked = Convert.ToBoolean(Request.QueryString["chkAllClientsValue"]);
        }
        GetFilteredClientDetails();

        if (Convert.ToInt32(rblHeader.SelectedValue) == 3)
        {
          ddlClients.Visible = false;
          chkAllClients.Visible = false;
          chkFilteredClient.Visible = false;
        }
      }
    }

    protected void rblHeader_SelectedIndexChanged(object sender, EventArgs e)
    {
      gvTargetAdmin.DataSource = null;
      gvTargetAdmin.DataBind();

      gvDirectTasks.DataSource = null;
      gvDirectTasks.DataBind();

      if (Convert.ToInt32(rblHeader.SelectedValue) < 3)
      {
        ddlClients.Visible = true;
        ddlClients.SelectedValue = "1";
        chkAllClients.Visible = true;
        chkAllClients.Checked = true;
        chkFilteredClient.Visible = true;
        GetFilteredClientDetails();
      }
      else
      {
        ddlClients.Visible = false;
        chkAllClients.Visible = false;
        chkFilteredClient.Visible = false;
      }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (Convert.ToInt32(rblHeader.SelectedValue) < 3)
      {
        AddClientColumns();
      }
      else
      {
        FillDirectTasks();
      }
    }

    protected void ddlClients_SelectedIndexChanged(object sender, EventArgs e)
    {
      chkAllClients.Checked = true;
      GetFilteredClientDetails();
      gvTargetAdmin.DataSource = null;
      gvTargetAdmin.DataBind();
    }

    protected void chkAllClients_CheckedChanged(object sender, EventArgs e)
    {
      gvTargetAdmin.DataSource = null;
      gvTargetAdmin.DataBind();
      foreach (ListItem item in chkFilteredClient.Items)
      {
        item.Selected = chkAllClients.Checked;
      }
    }

    private void GetFilteredClientDetails()
    {
      AdminController oAdminController = new AdminController();
      DataTable dtFilteredClient = oAdminController.GetFilteredClientDetails(Convert.ToInt32(ddlClients.SelectedValue), UserId);
      chkFilteredClient.DataSource = dtFilteredClient;
      chkFilteredClient.DataTextField = "CompanyName";
      chkFilteredClient.DataValueField = "ClientId";
      chkFilteredClient.DataBind();

      if (Request.QueryString["chkFilteredClientValue"] != null)
      {
        string[] FilteredClientIds = Convert.ToString(Request.QueryString["chkFilteredClientValue"]).Split(',');
        foreach (ListItem item in chkFilteredClient.Items)
        {
          if (FilteredClientIds.Contains(item.Value))
          {
            item.Selected = true;
          }
          else
          {
            item.Selected = false;
          }
        }  
      }
      else
      {
        foreach (ListItem item in chkFilteredClient.Items)
        {
          item.Selected = true;
        }
      }
      oAdminController = null;
    }

    private void AddClientColumns()
    {
      gvTargetAdmin.Columns.Clear();
      AdminController oAdminController = new AdminController();
      TemplateField oTemplateField = new TemplateField();
      FilteredClientIds = "";
      DataTable dtClient = new DataTable();
      foreach (ListItem item in chkFilteredClient.Items)
      {
        if (item.Selected)
        {
          FilteredClientIds += item.Value + ",";
        }
      }
      if (FilteredClientIds == "")
      {
        Page page = HttpContext.Current.Handler as Page;
        ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('Please select a Client');", true);
        return;
      }
      else
      {
        int index = FilteredClientIds.LastIndexOf(',');
        FilteredClientIds = FilteredClientIds.Remove(index, 1);
        dtClient = oAdminController.GetClientDetails(FilteredClientIds, Convert.ToInt32(rblHeader.SelectedValue), UserId);
      }
      
      if (dtClient.Rows.Count > 0)
      {
        if (Convert.ToInt32(rblHeader.SelectedValue) == 1)
        {
          oTemplateField = new TemplateField();
          oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
          oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' width='60px'><tr><td align='center' valign='middle' style='padding-top:5px; padding-bottom:5px; font-family:Arial;'>Sr No.</td></tr></table>";
          oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
          gvTargetAdmin.Columns.Add(oTemplateField);

          oTemplateField = new TemplateField();
          oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
          oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' width='200px'><tr>";
          oTemplateField.HeaderText += "<td align='center' valign='middle' style='width:50%; padding-top:5px; padding-bottom:5px; font-family:Arial;'>Status</td>";
          oTemplateField.HeaderText += "<td align='center' valign='middle' style='width:50%;'><a rel='shadowbox;width=600;height=400;' href='/Admin/UpdateStatusSorting.aspx?rblHeaderValue=" + Convert.ToInt32(rblHeader.SelectedValue) + "&ddlClientsValue=" + Convert.ToInt32(ddlClients.SelectedValue) + "&chkAllClientsValue=" + Convert.ToBoolean(chkAllClients.Checked) + "&chkFilteredClientValue=" + FilteredClientIds + "' onclick='return OpenUpdateStatusOrder(this);'><img src='../images/sort.png' alt='' title='Edit Status Order' /></a></td>";
          oTemplateField.HeaderText += "</tr></table>";
          gvTargetAdmin.Columns.Add(oTemplateField);

          oTemplateField = new TemplateField();
          oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
          oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' width='125px'><tr><td align='center' valign='middle' style='padding-top:5px; padding-bottom:5px; font-family:Arial;'>Is Relevant To NewsLetter</td></tr></table>";
          oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
          gvTargetAdmin.Columns.Add(oTemplateField);

          oTemplateField = new TemplateField();
          oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
          oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' width='125px'><tr><td align='center' valign='middle' style='padding-top:5px; padding-bottom:5px; font-family:Arial;'>Is Relevant To Delays</td></tr></table>";
          oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
          gvTargetAdmin.Columns.Add(oTemplateField);


          oTemplateField = new TemplateField();
          oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
          oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' width='115px'><tr><td align='center' valign='middle' style='padding-top:5px; padding-bottom:5px; font-family:Arial;'>From</td></tr></table>";
          oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
          gvTargetAdmin.Columns.Add(oTemplateField);
        }
        else
        {
          oTemplateField = new TemplateField();
          oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
          oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' width='60px'><tr><td align='center' valign='middle' style='padding-top:5px; padding-bottom:5px; font-family:Arial;'>Sr No.</td></tr></table>";
          oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
          gvTargetAdmin.Columns.Add(oTemplateField);

          oTemplateField = new TemplateField();
          oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
          oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' width='200px'><tr>";
          oTemplateField.HeaderText += "<td align='center' valign='middle' style='width:100%; padding-top:5px; padding-bottom:5px; font-family:Arial;'>Email</td>";
          oTemplateField.HeaderText += "</tr></table>";
          gvTargetAdmin.Columns.Add(oTemplateField);
        }

        for (int i = 0; i < dtClient.Rows.Count; i++)
        {
          oTemplateField = new TemplateField();
          oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
          if (dtClient.Rows[i]["CompanyName"].ToString() != "Task Description (Tool-Tip)" && dtClient.Rows[i]["CompanyName"].ToString() != "Plan" && dtClient.Rows[i]["CompanyName"].ToString() != "Time" && dtClient.Rows[i]["CompanyName"].ToString() != "Days" && dtClient.Rows[i]["CompanyName"].ToString() != "IsPriority" && dtClient.Rows[i]["CompanyName"].ToString() != "IsGroup")
          {
            if (Convert.ToInt32(dtClient.Rows[i]["ClientId"]) > 0 && oAdminController.GetCopyFromDataDetails(Convert.ToInt32(dtClient.Rows[i]["ClientId"])).Rows.Count > 1)
            {
              if (Convert.ToInt32(rblHeader.SelectedValue) == 1)
              {
                  oTemplateField.HeaderText = "<table border='1' cellpadding='0' cellspacing='0' align='center' style='font-size:16px;font-family:Arial;width:100%;border-collapse: collapse;border-color: #7a7a7a;border-left: transparent;border-right: transparent;'>"
                  + "<tr><td colspan='11' align='center' style='min-width:1405px;padding-top:5px;padding-bottom:5px;'>" + dtClient.Rows[i]["CompanyName"].ToString() + "<span style='padding-left:50px;font-size:14px;'>Copy From</span><a style='padding-right:5px;' id='ancUpdate_" + Convert.ToInt32(dtClient.Rows[i]["ClientId"]) + "' rel='shadowbox;width=400;height=200;' href='/Admin/CopyFrom.aspx?ClientId=" + Convert.ToInt32(dtClient.Rows[i]["ClientId"]) + "&rblHeaderValue=" + Convert.ToInt32(rblHeader.SelectedValue) + "&ddlClientsValue=" + Convert.ToInt32(ddlClients.SelectedValue) + "&chkAllClientsValue=" + Convert.ToBoolean(chkAllClients.Checked) + "&chkFilteredClientValue=" + FilteredClientIds + "' onclick='return OpenCopyFrom(this);'><img src='../images/copyFrom.png' alt='' title='Copy From' /></a></td></tr>"
                 // + "<tr><td colspan='11' align='center' style='height:1px; background-color:#7a7a7a;'></td></tr>"
                  + "<tr>"
                  + "<td align='center' style='min-width:49px;padding-top:5px;padding-bottom:5px;font-size:14px;border-right: 1px solid #7a7a7a;'>Days</td>"
                 // + "<td align='center' style='width:1px; background-color:#7a7a7a;'></td>"
                  + "<td align='center' style='min-width:149px;padding-top:5px;padding-bottom:5px;font-size:14px;border-right: 1px solid #7a7a7a;'>Predecessor</td>"
                 // + "<td align='center' style='width:1px; background-color:#7a7a7a;'></td>"
                  + "<td align='center' style='min-width:300px;padding-top:5px;padding-bottom:5px;font-size:14px;border-right: 1px solid #7a7a7a;'>Designation</td>"
                 // + "<td align='center' style='width:1px; background-color:#7a7a7a;'></td>"
                  + "<td align='center' style='min-width:299px;padding-top:5px;padding-bottom:5px;font-size:14px;border-right: 1px solid #7a7a7a;'>Notification</td>"
                 // + "<td align='center' style='width:1px; background-color:#7a7a7a;'></td>"
                  + "<td align='center' style='min-width:300px;padding-top:5px;padding-bottom:5px;font-size:14px;border-right: 1px solid #7a7a7a;'>MO Filter Notification</td>"
                 // + "<td align='center' style='width:1px; background-color:#7a7a7a;'></td>"
                  + "<td align='center' style='min-width:300px;padding-top:5px;padding-bottom:5px;font-size:14px;border-right: 1px solid #7a7a7a;'>Delay Notification</td>"
                  + "</tr>"
                  + "</table>";
                gvTargetAdmin.Columns.Add(oTemplateField);
              }
              else
              {
                oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' align='center' style='font-size:16px;font-family:Arial;width:100%;'>"
                  + "<tr><td colspan='3' align='center' style='min-width:385px;padding-top:5px;padding-bottom:5px;'>" + dtClient.Rows[i]["CompanyName"].ToString() + "<span style='padding-left:50px;font-size:14px;'>Copy From</span><a style='padding-right:5px;' id='ancUpdate_" + Convert.ToInt32(dtClient.Rows[i]["ClientId"]) + "' rel='shadowbox;width=400;height=200;' href='/Admin/CopyFrom.aspx?ClientId=" + Convert.ToInt32(dtClient.Rows[i]["ClientId"]) + "&DesignationType=Email&rblHeaderValue=" + Convert.ToInt32(rblHeader.SelectedValue) + "&ddlClientsValue=" + Convert.ToInt32(ddlClients.SelectedValue) + "&chkAllClientsValue=" + Convert.ToBoolean(chkAllClients.Checked) + "&chkFilteredClientValue=" + FilteredClientIds + "' onclick='return OpenCopyFrom(this);'><img src='../images/copyFrom.png' alt='' title='Copy From' /></a></td></tr>"
                 // + "<tr><td colspan='3' align='center' style='height:1px; background-color:#FFFFFF;'></td></tr>"
                  + "<tr>"
                  + "<td align='center' style='min-width:85px;padding-top:5px;padding-bottom:5px;font-size:14px;border-right: 1px solid #7a7a7a;'></td>"
                //  + "<td align='center' style='width:1px; background-color:#FFFFFF;'></td>"
                  + "<td align='center' style='min-width:300px;padding-top:5px;padding-bottom:5px;font-size:14px;border-right: 1px solid #7a7a7a;'>Designation</td>"
                  + "</tr>"
                  + "</table>";
                gvTargetAdmin.Columns.Add(oTemplateField);
              }
            }
            else
            {
              if (Convert.ToInt32(rblHeader.SelectedValue) == 1)
              {
                oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' align='center' style='font-size:16px;font-family:Arial;width:100%;'>"
                  + "<tr><td colspan='7' align='center' style='min-width:800px;padding-top:5px;padding-bottom:5px;'>" + dtClient.Rows[i]["CompanyName"].ToString() + "</td></tr>"
                //  + "<tr><td colspan='7' align='center' style='height:1px; background-color:#FFFFFF;'></td></tr>"
                  + "<tr>"
                  + "<td align='center' style='min-width:49px;padding-top:5px;padding-bottom:5px;font-size:14px;border-right: 1px solid #7a7a7a;'>Days</td>"
                 // + "<td align='center' style='width:1px; background-color:#FFFFFF;'></td>"
                  + "<td align='center' style='min-width:149px;padding-top:5px;padding-bottom:5px;font-size:14px;border-right: 1px solid #7a7a7a;'>Predecessor</td>"
                 // + "<td align='center' style='width:1px; background-color:#FFFFFF;'></td>"
                  + "<td align='center' style='min-width:300px;padding-top:5px;padding-bottom:5px;font-size:14px;border-right: 1px solid #7a7a7a;'>Designation</td>"
                 // + "<td align='center' style='width:1px; background-color:#FFFFFF;'></td>"
                  + "<td align='center' style='min-width:300px;padding-top:5px;padding-bottom:5px;font-size:14px;border-right: 1px solid #7a7a7a;'>Notification</td>"
                 // + "<td align='center' style='width:1px; background-color:#FFFFFF;'></td>"
                  + "<td align='center' style='min-width:300px;padding-top:5px;padding-bottom:5px;font-size:14px;border-right: 1px solid #7a7a7a;'>Delay Notification</td>"
                  + "</tr>"
                  + "</table>";
                gvTargetAdmin.Columns.Add(oTemplateField);
              }
              else
              {
                oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' align='center' style='font-size:16px;font-family:Arial;width:100%;'>"
                  + "<tr><td colspan='3' align='center' style='min-width:385px;padding-top:5px;padding-bottom:5px;'>" + dtClient.Rows[i]["CompanyName"].ToString() + "</td></tr>"
                 // + "<tr><td colspan='3' align='center' style='height:1px; background-color:#FFFFFF;'></td></tr>"
                  + "<tr>"
                  + "<td align='center' style='min-width:85px;padding-top:5px;padding-bottom:5px;font-size:14px;border-right: 1px solid #7a7a7a;'></td>"
                 // + "<td align='center' style='width:1px; background-color:#FFFFFF;'></td>"
                  + "<td align='center' style='min-width:300px;padding-top:5px;padding-bottom:5px;font-size:14px;border-right: 1px solid #7a7a7a;'>Designation</td>"
                  + "</tr>"
                  + "</table>";
                gvTargetAdmin.Columns.Add(oTemplateField);
              }
            }
          }
          else
          {
            if (Convert.ToInt32(rblHeader.SelectedValue) == 1)
            {
              oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' align='center' style='font-size:16px;font-family:Arial;width:100%;'>"
                + "<tr><td align='center' style='min-width:300px;padding-top:5px;padding-bottom:5px;'>" + dtClient.Rows[i]["CompanyName"].ToString() + "</td></tr>"
                + "</table>";
              gvTargetAdmin.Columns.Add(oTemplateField);
            }
            else
            {
              if (dtClient.Rows[i]["CompanyName"].ToString() == "Plan")
              {
                oTemplateField = new TemplateField();
                oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
                oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' width='85px'><tr><td align='center' valign='middle' style='padding-top:5px; padding-bottom:5px; font-family:Arial;'>Plan</td></tr></table>";
                oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                gvTargetAdmin.Columns.Add(oTemplateField);
              }
              else if (dtClient.Rows[i]["CompanyName"].ToString() == "Time")
              {
                oTemplateField = new TemplateField();
                oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
                oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' width='175px'><tr><td align='center' valign='middle' style='padding-top:5px; padding-bottom:5px; font-family:Arial;'>Time</td></tr></table>";
                oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                gvTargetAdmin.Columns.Add(oTemplateField);
              }
              else if (dtClient.Rows[i]["CompanyName"].ToString() == "Days")
              {
                oTemplateField = new TemplateField();
                oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
                oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' width='250px'><tr><td align='center' valign='middle' style='padding-top:5px; padding-bottom:5px; font-family:Arial;'>Days</td></tr></table>";
                oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                gvTargetAdmin.Columns.Add(oTemplateField);
              }
                  //abhishek
              else if (dtClient.Rows[i]["CompanyName"].ToString() == "IsPriority")
              {
                  oTemplateField = new TemplateField();
                  oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle;
                  oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' width='131px'><tr><td align='center' valign='middle' style='padding-top:5px; padding-bottom:5px; font-family:Arial;'>Serial</td></tr></table>";
                  oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                  gvTargetAdmin.Columns.Add(oTemplateField);
              }
              else if (dtClient.Rows[i]["CompanyName"].ToString() == "IsGroup")
              {
                  oTemplateField = new TemplateField();
                  oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Middle; 
                  oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' width='100px'><tr><td align='center' valign='middle' style='padding-top:5px; padding-bottom:5px; font-family:Arial;'>Page/View</td></tr></table>";
                  oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                  gvTargetAdmin.Columns.Add(oTemplateField);
              } 
            }
          }
        }

        oTemplateField = null;
      }
      oAdminController = null;

      FillTargetAdmin();
    }

    private void FillDirectTasks()
    {
      AdminController oAdminController = new AdminController();
      gvDirectTasks.DataSource = oAdminController.FillTargetAdmin(false);
      gvDirectTasks.DataBind();
      oAdminController = null;
    }

    protected void gvDirectTasks_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        HiddenField hdnStatusId = new HiddenField();
        hdnStatusId.ID = "hdnStatusId";
        hdnStatusId.Value = DataBinder.Eval(e.Row.DataItem, "StatusModeId").ToString();
        e.Row.Cells[1].Controls.Add(hdnStatusId);

        AdminController oAdminController = new AdminController();
        PlaceHolder DBDataPlaceHolder = new PlaceHolder();
        PlaceHolder oPlaceHolder = new PlaceHolder();
        oPlaceHolder.ID = "DBDataPlaceHolder_1";
        e.Row.Cells[1].Controls.Add(oPlaceHolder);

        DBDataPlaceHolder = (PlaceHolder)e.Row.FindControl("DBDataPlaceHolder_1");

        DataTable dtDesignationDetails = oAdminController.GetDirectTasksDesignationDetails(Convert.ToInt32(hdnStatusId.Value));
        htmlTable.Append("<table border='0' cellpadding='0' cellspacing='0' align='left' style='width:100%;height:100%;'>");
        htmlTable.Append("<tr>");
        htmlTable.Append("<td align='right' valign='middle' style='min-width:300px;'>");
        htmlTable.Append("<a style='padding-right:15px;' id='ancUpdate_" + Convert.ToInt32(hdnStatusId.Value) + "' rel='shadowbox;width=800;height=400;' href='/Admin/UpdateDesignation.aspx?StatusId=" + Convert.ToInt32(hdnStatusId.Value) + "&rblHeaderValue=" + Convert.ToInt32(rblHeader.SelectedValue) + "' onclick='return OpenUpdateDesignation(this);'><img src='../images/edit.png' alt='' title='Edit Designation' /></a>");
        htmlTable.Append("<div style='width: 95%;text-align:left;vertical-align:top;height:75px; overflow:auto;padding-left:5px; font-size:12px;font-family:Arial;'>");
        if (dtDesignationDetails.Rows.Count > 0)
        {
          for (int j = 0; j < dtDesignationDetails.Rows.Count; j++)
          {
            htmlTable.Append(dtDesignationDetails.Rows[j]["Designation"].ToString() + "<br />");
          }
        }
        htmlTable.Append("</div>");
        htmlTable.Append("</td>");
        htmlTable.Append("</tr>");
        htmlTable.Append("</table>");

        DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
        htmlTable.Length = 0;
        oAdminController = null;
      }
    }

    private void FillTargetAdmin()
    {
      AdminController oAdminController = new AdminController();
      if (Convert.ToInt32(rblHeader.SelectedValue) == 1)
      {
        gvTargetAdmin.DataSource = oAdminController.FillTargetAdmin(true);
        gvTargetAdmin.DataBind();
      }
      else
      {
        gvTargetAdmin.DataSource = oAdminController.FillEmailDetails();
        gvTargetAdmin.DataBind();
      }
      oAdminController = null;
    }

    protected void gvTargetAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        AdminController oAdminController = new AdminController();

        if (Convert.ToInt32(rblHeader.SelectedValue) == 1)
        {
          Label lblSrNo = new Label();
          lblSrNo.ID = "lblSrNo";
          lblSrNo.Text = DataBinder.Eval(e.Row.DataItem, "SrNo").ToString();
          lblSrNo.Font.Size = 10;
          lblSrNo.CssClass = "txt";
          e.Row.Cells[0].Controls.Add(lblSrNo);

          HiddenField hdnStatusId = new HiddenField();
          hdnStatusId.ID = "hdnStatusId";
          hdnStatusId.Value = DataBinder.Eval(e.Row.DataItem, "StatusModeId").ToString();
          e.Row.Cells[1].Controls.Add(hdnStatusId);

          Label lblStatus = new Label();
          lblStatus.ID = "lblStatus";
          lblStatus.Text = DataBinder.Eval(e.Row.DataItem, "StatusModeName").ToString();
          lblStatus.Font.Size = 10;
          lblStatus.CssClass = "txt";
          e.Row.Cells[1].Controls.Add(lblStatus);

          CheckBox chkNewsLetter = new CheckBox();
          chkNewsLetter.ID = "chkNewsLetter";
          chkNewsLetter.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsRelevantToNewsLetter"));
          chkNewsLetter.Attributes.Add("onclick", "UpdateIsRelevantToNewsLetter(this);");
          e.Row.Cells[2].Controls.Add(chkNewsLetter);

          CheckBox chkDelays = new CheckBox();
          chkDelays.ID = "chkDelays";
          chkDelays.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsRelevantToDelays"));
          chkDelays.Attributes.Add("onclick", "UpdateIsRelevantToDelays(this);");
          e.Row.Cells[3].Controls.Add(chkDelays);

          DropDownList ddlFromStatus = new DropDownList();
          ddlFromStatus.ID = "ddlFromStatus";
          ddlFromStatus.Font.Size = 10;
          ddlFromStatus.CssClass = "txt";
          ddlFromStatus.Width = 150;
          ddlFromStatus.Attributes.Add("onchange", "SaveFromStatus(this);");
          ddlFromStatus.Attributes.Add("onfocus", "GetPreviousValue(this);");
          ddlFromStatus.DataSource = oAdminController.FillFromStatus(Convert.ToInt32(lblSrNo.Text));
          ddlFromStatus.DataTextField = "Name";
          ddlFromStatus.DataValueField = "TypeId";
          ddlFromStatus.DataBind();
          ddlFromStatus.Items.Insert(0, new ListItem("Select", "0"));

          ddlFromStatus.Items.FindByValue(DataBinder.Eval(e.Row.DataItem, "FromStatus").ToString()).Selected = true;
          e.Row.Cells[4].Controls.Add(ddlFromStatus);

          PlaceHolder DBDataPlaceHolder = new PlaceHolder();
          for (int i = 5; i < gvTargetAdmin.Columns.Count; i++)
          {
            PlaceHolder oPlaceHolder = new PlaceHolder();
            oPlaceHolder.ID = "DBDataPlaceHolder_" + i;
            e.Row.Cells[i].Controls.Add(oPlaceHolder);

            DBDataPlaceHolder = (PlaceHolder)e.Row.FindControl("DBDataPlaceHolder_" + i);

            FilteredClientIds = "";
            foreach (ListItem item in chkFilteredClient.Items)
            {
              if (item.Selected)
              {
                FilteredClientIds += item.Value + ",";
              }
            }
            int index = FilteredClientIds.LastIndexOf(',');
            FilteredClientIds = FilteredClientIds.Remove(index, 1);
            DataTable dtClient = oAdminController.GetClientDetails(FilteredClientIds, Convert.ToInt32(rblHeader.SelectedValue), UserId);

            int ClientId = Convert.ToInt32(dtClient.Rows[i - 5]["ClientId"]);
            if ((dtClient.Rows[i - 5]["CompanyName"]).ToString() != "Task Description (Tool-Tip)")
            {
                DataTable dtDays_PredecessorDetails = oAdminController.GetDays_PredecessorDetails(Convert.ToInt32(hdnStatusId.Value), ClientId);
                DataTable dtDesignationDetails = oAdminController.GetDesignationDetails(Convert.ToInt32(hdnStatusId.Value), ClientId);
                DataTable dtNotificationDetails = oAdminController.GetNotificationDetails(Convert.ToInt32(hdnStatusId.Value), ClientId);
                DataTable dtMOFilterNotificationDetails = oAdminController.GetMOFilterNotificationDetails(Convert.ToInt32(hdnStatusId.Value), ClientId);
                DataTable dtDelayNotificationDetails = oAdminController.GetDelayNotificationDetails(Convert.ToInt32(hdnStatusId.Value), ClientId);

                int Days = 0;
                if (dtDays_PredecessorDetails.Rows.Count > 0)
                {
                    Days = Convert.ToInt32(dtDays_PredecessorDetails.Rows[0]["Days"]);
                }
                htmlTable.Append("<table border='0' cellpadding='0' cellspacing='0' align='left' style='width:100%;height:100%;'>");
                htmlTable.Append("<tr>");
                htmlTable.Append("<td style='min-width:49px;border-right: 1px solid #d9d5d5;'><input id='txt_" + Convert.ToInt32(hdnStatusId.Value) + "_" + ClientId + "' type='text' value='" + Days + "' maxlength='3' onchange='UpdateDays(this," + Convert.ToInt32(hdnStatusId.Value) + "," + ClientId + "," + UserId + ")' style='width:44px; height:15px;text-align:center;color:#7E7E7E;' /><input id='hdn_" + Convert.ToInt32(hdnStatusId.Value) + "_" + ClientId + "' type='hidden' value='" + Days + "' /></td>");
              //  htmlTable.Append("<td style='width:1px; background-color:#7E7E7E;'></td>");
                htmlTable.Append("<td align='right' valign='middle' style='min-width:149px;border-right: 1px solid #d9d5d5;'>");
                if (Convert.ToInt32(hdnStatusId.Value) > 1)
                {
                    htmlTable.Append("<a style='padding-right:15px;' id='ancUpdate_" + Convert.ToInt32(hdnStatusId.Value) + "_" + ClientId + "' rel='shadowbox;width=600;height=400;' href='/Admin/UpdatePredecessor.aspx?ClientId=" + ClientId + "&StatusId=" + Convert.ToInt32(hdnStatusId.Value) + "&rblHeaderValue=" + Convert.ToInt32(rblHeader.SelectedValue) + "&ddlClientsValue=" + Convert.ToInt32(ddlClients.SelectedValue) + "&chkAllClientsValue=" + Convert.ToBoolean(chkAllClients.Checked) + "&chkFilteredClientValue=" + FilteredClientIds + "' onclick='return OpenUpdatePredecessor(this);'><img src='../images/edit.png' alt='' title='Edit Predecessor' /></a>");
                }
                else
                {
                    htmlTable.Append("<a style='padding-right:15px;visibility:hidden;' id='ancUpdate_" + Convert.ToInt32(hdnStatusId.Value) + "_" + ClientId + "' rel='shadowbox;width=600;height=400;' href='/Admin/UpdatePredecessor.aspx?ClientId=" + ClientId + "&StatusId=" + Convert.ToInt32(hdnStatusId.Value) + "&rblHeaderValue=" + Convert.ToInt32(rblHeader.SelectedValue) + "&ddlClientsValue=" + Convert.ToInt32(ddlClients.SelectedValue) + "&chkAllClientsValue=" + Convert.ToBoolean(chkAllClients.Checked) + "&chkFilteredClientValue=" + FilteredClientIds + "' onclick='return OpenUpdatePredecessor(this);'><img src='../images/edit.png' alt='' title='Edit Predecessor' /></a>");
                }
                htmlTable.Append("<div style='width: 95%;text-align:left;vertical-align:top;height:75px; overflow:auto;padding-left:5px; font-size:12px;font-family:Arial;'>");
                if (dtDays_PredecessorDetails.Rows.Count > 0)
                {
                    for (int j = 0; j < dtDays_PredecessorDetails.Rows.Count; j++)
                    {
                        htmlTable.Append(dtDays_PredecessorDetails.Rows[j]["Predecessor"].ToString() + "<br />");
                    }
                }
                htmlTable.Append("</div>");
                htmlTable.Append("</td>");
               // htmlTable.Append("<td style='width:1px; background-color:#7E7E7E;'></td>");
                htmlTable.Append("<td align='right' valign='middle' style='min-width:300px;border-right: 1px solid #d9d5d5;'>");
                htmlTable.Append("<a style='padding-right:15px;' id='ancUpdate_" + Convert.ToInt32(hdnStatusId.Value) + "_" + ClientId + "' rel='shadowbox;width=800;height=400;' href='/Admin/UpdateDesignation.aspx?ClientId=" + ClientId + "&StatusId=" + Convert.ToInt32(hdnStatusId.Value) + "&rblHeaderValue=" + Convert.ToInt32(rblHeader.SelectedValue) + "&ddlClientsValue=" + Convert.ToInt32(ddlClients.SelectedValue) + "&chkAllClientsValue=" + Convert.ToBoolean(chkAllClients.Checked) + "&chkFilteredClientValue=" + FilteredClientIds + "' onclick='return OpenUpdateDesignation(this);'><img src='../images/edit.png' alt='' title='Edit Designation' /></a>");
                htmlTable.Append("<div style='width: 95%;text-align:left;vertical-align:top;height:75px; overflow:auto;padding-left:5px; font-size:12px;font-family:Arial;'>");
                if (dtDesignationDetails.Rows.Count > 0)
                {
                    for (int j = 0; j < dtDesignationDetails.Rows.Count; j++)
                    {
                        htmlTable.Append(dtDesignationDetails.Rows[j]["Designation"].ToString() + "<br />");
                    }
                }
                htmlTable.Append("</div>");
                htmlTable.Append("</td>");
               // htmlTable.Append("<td style='width:1px; background-color:#7E7E7E;'></td>");
                htmlTable.Append("<td align='right' valign='middle' style='min-width:299px;border-right: 1px solid #d9d5d5;'>");
                htmlTable.Append("<a style='padding-right:15px;' id='ancUpdate_" + Convert.ToInt32(hdnStatusId.Value) + "_" + ClientId + "_Notification' rel='shadowbox;width=800;height=400;' href='/Admin/UpdateDesignation.aspx?ClientId=" + ClientId + "&StatusId=" + Convert.ToInt32(hdnStatusId.Value) + "&Notification=yes&rblHeaderValue=" + Convert.ToInt32(rblHeader.SelectedValue) + "&ddlClientsValue=" + Convert.ToInt32(ddlClients.SelectedValue) + "&chkAllClientsValue=" + Convert.ToBoolean(chkAllClients.Checked) + "&chkFilteredClientValue=" + FilteredClientIds + "' onclick='return OpenUpdateDesignation(this);'><img src='../images/edit.png' alt='' title='Edit Notification' /></a>");
                htmlTable.Append("<div style='width: 95%;text-align:left;vertical-align:top;height:75px; overflow:auto;padding-left:5px; font-size:12px;font-family:Arial;'>");
                if (dtNotificationDetails.Rows.Count > 0)
                {
                    for (int j = 0; j < dtNotificationDetails.Rows.Count; j++)
                    {
                        htmlTable.Append(dtNotificationDetails.Rows[j]["Designation"].ToString() + "<br />");
                    }
                }
                htmlTable.Append("</div>");
                htmlTable.Append("</td>");
             //   htmlTable.Append("<td style='width:1px; background-color:#7E7E7E;'></td>");
                htmlTable.Append("<td align='right' valign='middle' style='min-width:300px;border-right: 1px solid #d9d5d5;'>");
                htmlTable.Append("<a style='padding-right:15px;' id='ancUpdate_" + Convert.ToInt32(hdnStatusId.Value) + "_" + ClientId + "_MOFilterNotification' rel='shadowbox;width=800;height=400;' href='/Admin/UpdateDesignation.aspx?ClientId=" + ClientId + "&StatusId=" + Convert.ToInt32(hdnStatusId.Value) + "&MOFilterNotification=yes&rblHeaderValue=" + Convert.ToInt32(rblHeader.SelectedValue) + "&ddlClientsValue=" + Convert.ToInt32(ddlClients.SelectedValue) + "&chkAllClientsValue=" + Convert.ToBoolean(chkAllClients.Checked) + "&chkFilteredClientValue=" + FilteredClientIds + "' onclick='return OpenUpdateDesignation(this);'><img src='../images/edit.png' alt='' title='Edit MO Filter Notification' /></a>");
                htmlTable.Append("<div style='width: 95%;text-align:left;vertical-align:top;height:75px; overflow:auto;padding-left:5px; font-size:12px;font-family:Arial;'>");
                if (dtMOFilterNotificationDetails.Rows.Count > 0)
                {
                  for (int j = 0; j < dtMOFilterNotificationDetails.Rows.Count; j++)
                  {
                    htmlTable.Append(dtMOFilterNotificationDetails.Rows[j]["Designation"].ToString() + "<br />");
                  }
                }
                htmlTable.Append("</div>");
                htmlTable.Append("</td>");
              //  htmlTable.Append("<td style='width:1px; background-color:#7E7E7E;'></td>");
                htmlTable.Append("<td align='right' valign='middle' style='min-width:300px;border-right: 1px solid #d9d5d5;'>");
                htmlTable.Append("<a style='padding-right:15px;' id='ancUpdate_" + Convert.ToInt32(hdnStatusId.Value) + "_" + ClientId + "_DelayNotification' rel='shadowbox;width=800;height=400;' href='/Admin/UpdateDesignation.aspx?ClientId=" + ClientId + "&StatusId=" + Convert.ToInt32(hdnStatusId.Value) + "&DelayNotification=yes&rblHeaderValue=" + Convert.ToInt32(rblHeader.SelectedValue) + "&ddlClientsValue=" + Convert.ToInt32(ddlClients.SelectedValue) + "&chkAllClientsValue=" + Convert.ToBoolean(chkAllClients.Checked) + "&chkFilteredClientValue=" + FilteredClientIds + "' onclick='return OpenUpdateDesignation(this);'><img src='../images/edit.png' alt='' title='Edit Delay Notification' /></a>");
                htmlTable.Append("<div style='width: 95%;text-align:left;vertical-align:top;height:75px; overflow:auto;padding-left:5px; font-size:12px;font-family:Arial;'>");
                if (dtDelayNotificationDetails.Rows.Count > 0)
                {
                  for (int j = 0; j < dtDelayNotificationDetails.Rows.Count; j++)
                  {
                    htmlTable.Append(dtDelayNotificationDetails.Rows[j]["Designation"].ToString() + "<br />");
                  }
                }
                htmlTable.Append("</div>");
                htmlTable.Append("</td>");
                htmlTable.Append("</tr>");
                htmlTable.Append("</table>");
            }
            else
            {
                DataTable dtDecriptionDetails = oAdminController.GetDescriptionDetails(Convert.ToInt32(hdnStatusId.Value));
                htmlTable.Append("<table border='0' cellpadding='0' cellspacing='0' align='left' style='width:100%;height:100%;'>");
                htmlTable.Append("<tr>");
                htmlTable.Append("<td align='right' valign='middle' style='min-width:300px;'>");
                htmlTable.Append("<div style='width: 95%;text-align:left;vertical-align:top;height:75px; overflow:auto;padding-left:5px; font-size:12px;font-family:Arial;'>");
                if (dtDecriptionDetails.Rows.Count > 0)
                {
                    for (int j = 0; j < dtDecriptionDetails.Rows.Count; j++)
                    {
                        htmlTable.Append("<textarea id='txt_" + Convert.ToInt32(hdnStatusId.Value) + "' cols='20' rows='2' style='color:#7E7E7E;width:265px;height:68px;text-transform:none;' onchange='UpdateDescription(this," + Convert.ToInt32(hdnStatusId.Value) + ")'>" + dtDecriptionDetails.Rows[j]["Description"].ToString() + "</textarea>");
                    }
                }
                htmlTable.Append("</div>");
                htmlTable.Append("</td>");
                htmlTable.Append("</tr>");
                htmlTable.Append("</table>");
            }
            DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
            htmlTable.Length = 0;
          }
        }
        else
        {
          Label lblSrNo = new Label();
          lblSrNo.ID = "lblSrNo";
          lblSrNo.Text = DataBinder.Eval(e.Row.DataItem, "SrNo").ToString();
          lblSrNo.Font.Size = 10;
          lblSrNo.CssClass = "txt";
          e.Row.Cells[0].Controls.Add(lblSrNo);

          HiddenField hdnEmailId = new HiddenField();
          hdnEmailId.ID = "hdnEmailId";
          hdnEmailId.Value = DataBinder.Eval(e.Row.DataItem, "EmailId").ToString();
          e.Row.Cells[1].Controls.Add(hdnEmailId);

          Label lblStatus = new Label();
          lblStatus.ID = "lblEmail";
          lblStatus.Text = DataBinder.Eval(e.Row.DataItem, "Email").ToString();
          lblStatus.Font.Size = 10;
          lblStatus.CssClass = "txt";
          e.Row.Cells[1].Controls.Add(lblStatus);

          PlaceHolder DBDataPlaceHolder = new PlaceHolder();
          for (int i = 2; i < gvTargetAdmin.Columns.Count; i++)
          {
            PlaceHolder oPlaceHolder = new PlaceHolder();
            oPlaceHolder.ID = "DBDataPlaceHolder_" + i;
            e.Row.Cells[i].Controls.Add(oPlaceHolder);

            DBDataPlaceHolder = (PlaceHolder)e.Row.FindControl("DBDataPlaceHolder_" + i);
 
            FilteredClientIds = "";
            foreach (ListItem item in chkFilteredClient.Items)
            {
              if (item.Selected)
              {
                FilteredClientIds += item.Value + ",";
              }
            }
            int index = FilteredClientIds.LastIndexOf(',');
            FilteredClientIds = FilteredClientIds.Remove(index, 1);
            DataTable dtClient = oAdminController.GetClientDetails(FilteredClientIds, Convert.ToInt32(rblHeader.SelectedValue), UserId);

            int ClientId = Convert.ToInt32(dtClient.Rows[i - 2]["ClientId"]);
            if ((dtClient.Rows[i - 2]["CompanyName"]).ToString() != "Plan" && (dtClient.Rows[i - 2]["CompanyName"]).ToString() != "Time" && (dtClient.Rows[i - 2]["CompanyName"]).ToString() != "Days" && (dtClient.Rows[i - 2]["CompanyName"]).ToString() != "IsPriority" && (dtClient.Rows[i - 2]["CompanyName"]).ToString() != "IsGroup")
            {
              DataTable dtDesignationDetails = oAdminController.GetEmailDesignationDetails(Convert.ToInt32(hdnEmailId.Value), ClientId);
              int EmailPermissionType = oAdminController.GetEmailPermissionDetails(Convert.ToInt32(hdnEmailId.Value), ClientId);

              htmlTable.Append("<table border='0' cellpadding='0' cellspacing='0' align='left' style='width:100%;height:100%;'>");
              htmlTable.Append("<tr>");
              if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Notification")))
              {
                htmlTable.Append("<td align='center' style='min-width:85px;'><select id='ddl_" + Convert.ToInt32(hdnEmailId.Value) + "_" + ClientId + "' disabled='disabled' class='txt' style='width:80px;height:20px;text-align:center;color:#7E7E7E;'><option value='7'selected='selected'>Notification</option></select></td>");
              }
              else
              {
                if (EmailPermissionType > 0)
                {
                  if (EmailPermissionType == 5)
                  {
                    htmlTable.Append("<td align='center' style='min-width:85px;'><select id='ddl_" + Convert.ToInt32(hdnEmailId.Value) + "_" + ClientId + "' disabled='disabled' class='txt' style='width:80px;height:20px;text-align:center;color:#7E7E7E;' onchange='SavePermission(this.options[this.selectedIndex].value, " + Convert.ToInt32(hdnEmailId.Value) + ", " + ClientId + ", " + UserId + ")'><option value='5' selected='selected'>Email</option><option value='6'>No</option></select></td>");
                  }
                  else
                  {
                    htmlTable.Append("<td align='center' style='min-width:85px;'><select id='ddl_" + Convert.ToInt32(hdnEmailId.Value) + "_" + ClientId + "' disabled='disabled' class='txt' style='width:80px;height:20px;text-align:center;color:#7E7E7E;' onchange='SavePermission(this.options[this.selectedIndex].value, " + Convert.ToInt32(hdnEmailId.Value) + ", " + ClientId + ", " + UserId + ")'><option value='5'>Email</option><option value='6' selected='selected'>No</option></select></td>");
                  }
                }
                else
                {
                  htmlTable.Append("<td align='center' style='min-width:85px;'><select id='ddl_" + Convert.ToInt32(hdnEmailId.Value) + "_" + ClientId + "' disabled='disabled' class='txt' style='width:80px;height:20px;text-align:center;color:#7E7E7E;' onchange='SavePermission(this.options[this.selectedIndex].value, " + Convert.ToInt32(hdnEmailId.Value) + ", " + ClientId + ", " + UserId + ")'><option value='5' selected='selected'>Email</option><option value='6'>No</option></select></td>");
                }
              }
              htmlTable.Append("<td style='width:1px; background-color:#7E7E7E;'></td>");
              htmlTable.Append("<td align='right' valign='middle' style='min-width:300px;'>");
              htmlTable.Append("<a style='padding-right:15px;' id='ancUpdate_" + Convert.ToInt32(hdnEmailId.Value) + "_" + ClientId + "' rel='shadowbox;width=800;height=400;' href='/Admin/UpdateDesignation.aspx?ClientId=" + ClientId + "&EmailId=" + Convert.ToInt32(hdnEmailId.Value) + "&DesignationType=Email&rblHeaderValue=" + Convert.ToInt32(rblHeader.SelectedValue) + "&ddlClientsValue=" + Convert.ToInt32(ddlClients.SelectedValue) + "&chkAllClientsValue=" + Convert.ToBoolean(chkAllClients.Checked) + "&chkFilteredClientValue=" + FilteredClientIds + "' onclick='return OpenUpdateDesignation(this);'><img src='../images/edit.png' alt='' title='Edit Designation' /></a>");
              htmlTable.Append("<div style='width: 95%;text-align:left;vertical-align:top;height:75px; overflow:auto;padding-left:5px; font-size:12px;font-family:Arial;'>");
              if (dtDesignationDetails.Rows.Count > 0)
              {
                for (int j = 0; j < dtDesignationDetails.Rows.Count; j++)
                {
                  htmlTable.Append(dtDesignationDetails.Rows[j]["Designation"].ToString() + "<br />");
                }
              }
              htmlTable.Append("</div>");
              htmlTable.Append("</td>");
              htmlTable.Append("</tr>");
              htmlTable.Append("</table>");
            }
            else
            {
              if ((dtClient.Rows[i - 2]["CompanyName"]).ToString() == "Plan")
              {
                htmlTable.Append("<table border='0' cellpadding='0' cellspacing='0' align='left' style='width:100%;height:100%;'>");
                htmlTable.Append("<tr>");
                htmlTable.Append("<td align='center' style='min-width:85px;'>");
                if (!Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Notification")))
                {
                  htmlTable.Append("<select id='ddl_" + Convert.ToInt32(hdnEmailId.Value) + "_Plan' class='txt' style='width:80px;height:20px;text-align:center;color:#7E7E7E;' onchange='UpdateEmailPlan(this.options[this.selectedIndex].value, " + Convert.ToInt32(hdnEmailId.Value) + ")'>");
                  DataTable dtEmailPlan = oAdminController.FillEmailPlanDetails();
                  if (dtEmailPlan.Rows.Count > 0)
                  {
                    for (int k = 0; k < dtEmailPlan.Rows.Count; k++)
                    {
                      htmlTable.Append("<option value='" + dtEmailPlan.Rows[k]["EmailPlanId"].ToString() + "'>" + dtEmailPlan.Rows[k]["EmailPlan"].ToString() + "</option>");
                    }
                  }
                  htmlTable.Append("</select>");
                }
                htmlTable.Append("</td>");
                htmlTable.Append("</tr></table>");
              }
              else if ((dtClient.Rows[i - 2]["CompanyName"]).ToString() == "Time")
              {
                htmlTable.Append("<table border='0' cellpadding='0' cellspacing='0' align='left' style='width:100%;height:100%;'>");
                htmlTable.Append("<tr>");
                htmlTable.Append("<td align='center' style='min-width:175px;'>");
                if (!Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Notification")))
                {
                  htmlTable.Append("<select id='ddl_" + Convert.ToInt32(hdnEmailId.Value) + "_Hours' class='txt' style='width:50px;height:20px;text-align:center;color:#7E7E7E;' onchange='UpdateEmailTime(this.options[this.selectedIndex].value, " + Convert.ToInt32(hdnEmailId.Value) + ")'>");
                  for (int k = 1; k <= 12; k++)
                  {
                    if (k == 1)
                    {
                      htmlTable.Append("<option value='" + k.ToString() + "'>" + (k + 11).ToString() + "</option>");
                    }
                    else
                    {
                      string Hours = (k - 1).ToString().Length == 1 ? "0" + (k - 1).ToString() : (k - 1).ToString();
                      htmlTable.Append("<option value='" + k.ToString() + "'>" + Hours + "</option>");
                    }
                  }
                  htmlTable.Append("</select>");
                  htmlTable.Append("<select id='ddl_" + Convert.ToInt32(hdnEmailId.Value) + "_Min' class='txt' style='width:50px;height:20px;text-align:center;color:#7E7E7E;' onchange='UpdateEmailTime(this.options[this.selectedIndex].value, " + Convert.ToInt32(hdnEmailId.Value) + ")'>");
                  for (int k = 1; k <= 60; k++)
                  {
                    string Min = (k - 1).ToString().Length == 1 ? "0" + (k - 1).ToString() : (k - 1).ToString();
                    htmlTable.Append("<option value='" + k.ToString() + "'>" + Min + "</option>");
                  }
                  htmlTable.Append("</select>");
                  htmlTable.Append("<select id='ddl_" + Convert.ToInt32(hdnEmailId.Value) + "_Meridian' class='txt' style='width:50px;height:20px;text-align:center;color:#7E7E7E;' onchange='UpdateEmailTime(this.options[this.selectedIndex].value, " + Convert.ToInt32(hdnEmailId.Value) + ")'>");
                  htmlTable.Append("<option value='1'>AM</option>");
                  htmlTable.Append("<option value='2'>PM</option>");
                  htmlTable.Append("</select>");
                }
                htmlTable.Append("</td>");
                htmlTable.Append("</tr></table>");
              }
              else if ((dtClient.Rows[i - 2]["CompanyName"]).ToString() == "Days")
              {
                  htmlTable.Append("<table border='0' cellpadding='0' cellspacing='0' align='left' style='width:100%;height:100%;'>");
                  htmlTable.Append("<tr>");
                  htmlTable.Append("<td align='left' style='min-width:250px;'>");
                  if (!Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Notification")))
                  {
                      htmlTable.Append("<input id='chk_" + Convert.ToInt32(hdnEmailId.Value) + "_" + DayOfWeek.Monday.ToString() + "' type='checkbox' onclick='UpdateEmailDays(this, " + Convert.ToInt32(hdnEmailId.Value) + ")' /><span class='txt' style='font-size: 12px;'>" + DayOfWeek.Monday.ToString() + "</span>&nbsp;");
                      htmlTable.Append("<input id='chk_" + Convert.ToInt32(hdnEmailId.Value) + "_" + DayOfWeek.Tuesday.ToString() + "' type='checkbox' onclick='UpdateEmailDays(this, " + Convert.ToInt32(hdnEmailId.Value) + ")' /><span class='txt' style='font-size: 12px;'>" + DayOfWeek.Tuesday.ToString() + "</span>&nbsp;");
                      htmlTable.Append("<input id='chk_" + Convert.ToInt32(hdnEmailId.Value) + "_" + DayOfWeek.Wednesday.ToString() + "' type='checkbox' onclick='UpdateEmailDays(this, " + Convert.ToInt32(hdnEmailId.Value) + ")' /><span class='txt' style='font-size: 12px;'>" + DayOfWeek.Wednesday.ToString() + "</span><br />");
                      htmlTable.Append("<input id='chk_" + Convert.ToInt32(hdnEmailId.Value) + "_" + DayOfWeek.Thursday.ToString() + "' type='checkbox' onclick='UpdateEmailDays(this, " + Convert.ToInt32(hdnEmailId.Value) + ")' /><span class='txt' style='font-size: 12px;'>" + DayOfWeek.Thursday.ToString() + "</span>&nbsp;");
                      htmlTable.Append("<input id='chk_" + Convert.ToInt32(hdnEmailId.Value) + "_" + DayOfWeek.Friday.ToString() + "' type='checkbox' onclick='UpdateEmailDays(this, " + Convert.ToInt32(hdnEmailId.Value) + ")' /><span class='txt' style='font-size: 12px;'>" + DayOfWeek.Friday.ToString() + "</span>&nbsp;");
                      htmlTable.Append("<input id='chk_" + Convert.ToInt32(hdnEmailId.Value) + "_" + DayOfWeek.Saturday.ToString() + "' type='checkbox' onclick='UpdateEmailDays(this, " + Convert.ToInt32(hdnEmailId.Value) + ")' /><span class='txt' style='font-size: 12px;'>" + DayOfWeek.Saturday.ToString() + "</span><br />");
                      htmlTable.Append("<input id='chk_" + Convert.ToInt32(hdnEmailId.Value) + "_" + DayOfWeek.Sunday.ToString() + "' type='checkbox' onclick='UpdateEmailDays(this, " + Convert.ToInt32(hdnEmailId.Value) + ")' /><span class='txt' style='font-size: 12px;'>" + DayOfWeek.Sunday.ToString() + "</span>&nbsp;");
                  }
                  htmlTable.Append("</td>");
                  htmlTable.Append("</tr></table>");
              }
               //.....added by abhishek on 18/4/2016
              else if ((dtClient.Rows[i - 2]["CompanyName"]).ToString() == "IsPriority")
              {
                  htmlTable.Append("<table border='0' cellpadding='0' cellspacing='0' align='left' style='width:100%;height:100%;'>");
                  htmlTable.Append("<tr>");
                  htmlTable.Append("<td align='center' style='min-width:131px;'>");
                  if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Notification")))
                  {
                      DataTable dt = oAdminController.GetEmailGroupPerioty(Convert.ToInt32(hdnEmailId.Value));
                     // htmlTable.Append("<asp:TextBox maxlength='" + 2 + "' runat='" + "server" + "'  OnTextChanged='" + "txt_IsPriority_TextChanged" + "' text='" + dt.Rows[0]["Priority"].ToString() + "'  id='txt_IsPriority" + Convert.ToInt32(hdnEmailId.Value) + "'CssClass='numeric' onkeypress='return isNumberKey(event)' type='text' style='text-align:center; width:60px;'></asp:TextBox>");
                      htmlTable.Append("<input maxlength='" + 2 + "' value='" + dt.Rows[0]["Priority"].ToString() + "'  id='txt_IsPriority" + "'CssClass='numeric' onkeypress='return isNumberKey(event)' type='text' onchange='UpdateEmailPerority(this.value,this, " + Convert.ToInt32(hdnEmailId.Value) + ")'   style='text-align:center; width:60px;' />");
                      
                  }
                  htmlTable.Append("</td>");
                 
                  htmlTable.Append("</tr></table>");
              }
              else if ((dtClient.Rows[i - 2]["CompanyName"]).ToString() == "IsGroup")
              {
                  htmlTable.Append("<table border='0' cellpadding='0' cellspacing='0' align='left' style='width:100%;height:100%;'>");
                  htmlTable.Append("<tr>");
                  htmlTable.Append("<td align='center' style='min-width:100px;'>");
                  if (Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Notification")))
                  {
                      DataTable dt = oAdminController.GetEmailGroupPerioty(Convert.ToInt32(hdnEmailId.Value));
                      string IsGroupChecked;
                      int a=-1;
                      if (!string.IsNullOrEmpty(dt.Rows[0]["IsGrouped"].ToString()))
                      {
                          a = Convert.ToInt32(dt.Rows[0]["IsGrouped"].ToString());
                      }
                      if (a > 1)
                      {
                          IsGroupChecked = "";

                      }
                      else if (Convert.ToInt32(dt.Rows[0]["IsGrouped"]) == 1)
                      {
                          //IsGroupChecked = "checked=checked";
                          IsGroupChecked = "selected=selected";
                         
                     
                      }
                      else
                      {
                          IsGroupChecked = "";
                      }
                         
                    
                      //htmlTable.Append("<input maxlength='" + 2 + "' runat='" + "server" + "' value='" + dt.Rows[0]["IsGrouped"].ToString() + "' id='txt_" + Convert.ToInt32(hdnEmailId.Value) + "_" + "IsGroup" + "'CssClass='numeric' onkeypress='return isNumberKey(event)' type='text' onchange='UpdateEmailIsGroup(this.value, " + Convert.ToInt32(hdnEmailId.Value) + ")'    style='text-align:center; width:60px;'/>");
                      //htmlTable.Append("<input " + IsGroupChecked + "' id='txt_" + Convert.ToInt32(hdnEmailId.Value) + "_" + "IsGroup" + "'CssClass='numeric' onkeypress='return isNumberKey(event)' type='checkbox' onclick='UpdateEmailIsGroup(this, " + Convert.ToInt32(hdnEmailId.Value) + ")'    style='text-align:center; width:60px;'/>");
                      string Disables = string.Empty; 
                      string Email = DataBinder.Eval(e.Row.DataItem, "Email").ToString().ToUpper();
                      if (Email == "Re-Allocated".ToUpper() || Email == "On Hold".ToUpper() || Email == "QA Failed".ToUpper() || Email == "Sample Pending Over a week".ToUpper() || Email == "Fits Comments Pending Over a week".ToUpper())
                      {
                          Disables = "disabled=disabled";
                      }
                      htmlTable.Append("<select " + Disables + " id='ddl_" + Convert.ToInt32(hdnEmailId.Value) + "_pv' " + IsGroupChecked + "  class='txt' style='width:60px;height:26px;left-align:center;color:#7E7E7E;' onchange='UpdateEmailIsGroup(this.options[this.selectedIndex].value, " + Convert.ToInt32(hdnEmailId.Value) + ")'>");
                      if (IsGroupChecked == "")
                      {
                          htmlTable.Append("<option '" + "selected=selected" + "' value='" + "0" + "'>" + "page" + "</option>");

                          htmlTable.Append("<option value='" + "1" + "'>" + "view" + "</option>");
                      }
                      else if (IsGroupChecked != "")
                      {                                               
                              htmlTable.Append("<option '" + "selected=selected" + "' value='" + "1" + "'>" + "view" + "</option>");
                              htmlTable.Append("<option  value='" + "0" + "'>" + "page" + "</option>");                        
                      }
                      htmlTable.Append("</select>");
                   
                  }
                  htmlTable.Append("</td>");
                 
                  htmlTable.Append("</tr></table>");
              }

            }
            DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
            htmlTable.Length = 0;
          }
        }

        oAdminController = null;
      }
    }
  }
}