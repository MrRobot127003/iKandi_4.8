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
  public partial class ManageDesignation : System.Web.UI.Page
  {
    StringBuilder htmlTable = new StringBuilder();
    int UserId = 0;

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
        AddDepartmentColumns();
        FillManageDesignation();
      }
    }

    protected void btnAddApplicationModule_OnClick(object sender, EventArgs e)
    {
      AdminController oAdminController = new AdminController();
      oAdminController.AddApplicationModule();
      oAdminController = null;

      Response.Redirect("/Admin/ManageDesignation.aspx");
    }

    private void AddDepartmentColumns()
    {
      AdminController oAdminController = new AdminController();
      DataTable dtDepartment = oAdminController.FillDepartmentDetails(0);
      if (dtDepartment.Rows.Count > 0)
      {
        for (int i = 0; i < dtDepartment.Rows.Count; i++)
        {
          if (dtDepartment.Rows[i]["DepartmentName"].ToString() != "Select")
          {
            TemplateField oTemplateField = new TemplateField();
            oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Top;
            oTemplateField.HeaderText = "<table border='0' cellpadding='0' cellspacing='0' align='center' style='font-size:14px;font-family:Arial;width:100%;'>"
              + "<tr><td align='center' style='min-width:400px;background-color:#405D99;color:#FFFFFF;padding-top: 11px;padding-bottom: 10px;'>"
              + "<span>Division: </span><span style='font-weight:normal;'>" + dtDepartment.Rows[i]["DivisionName"].ToString() + "</span><br />"
              + "<span>Department: </span><span style='font-weight:normal;'>" + dtDepartment.Rows[i]["DepartmentName"].ToString() + "</span>";
            if (Convert.ToBoolean(dtDepartment.Rows[i]["IsActive"]))
            {
              if (oAdminController.CheckDepartmentIsAciveEnable(Convert.ToInt32(dtDepartment.Rows[i]["DepartmentId"])))
              {
                oTemplateField.HeaderText += "<input type='checkbox' checked='checked' id='checkbox" + dtDepartment.Rows[i]["DepartmentId"].ToString() + "' disabled='disabled' onclick='UpdateDeparmentActive(this, " + dtDepartment.Rows[i]["DepartmentId"].ToString() + ")'>"
                + "&nbsp;&nbsp;&nbsp;&nbsp;<a id='chkAdd_" + dtDepartment.Rows[i]["DepartmentId"].ToString() + "' rel='shadowbox;width=750;height=225;' href='/Admin/AddDesignation.aspx?DepartmentId=" + Convert.ToInt32(dtDepartment.Rows[i]["DepartmentId"]) + "' onclick='return OpenAddDesignation(this);'><img src='../images/add-butt-white.png' alt=''  title='Add Designation' /></a>"
                + "&nbsp;&nbsp;&nbsp;&nbsp;<a id='chkOrder_" + dtDepartment.Rows[i]["DepartmentId"].ToString() + "' rel='shadowbox;width=750;height=400;' href='/Admin/UpdateDesignationSorting.aspx?DepartmentId=" + Convert.ToInt32(dtDepartment.Rows[i]["DepartmentId"]) + "' onclick='return OpenUpdateDesignationOrder(this);'><img src='../images/sort.png' alt=''  title='Edit Designation Order' /></a><br />";
              }
              else
              {
                oTemplateField.HeaderText += "<input type='checkbox' checked='checked' id='checkbox" + dtDepartment.Rows[i]["DepartmentId"].ToString() + "' onclick='UpdateDeparmentActive(this, " + dtDepartment.Rows[i]["DepartmentId"].ToString() + ")'>"
                + "&nbsp;&nbsp;&nbsp;&nbsp;<a id='chkAdd_" + dtDepartment.Rows[i]["DepartmentId"].ToString() + "' rel='shadowbox;width=750;height=225;' href='/Admin/AddDesignation.aspx?DepartmentId=" + Convert.ToInt32(dtDepartment.Rows[i]["DepartmentId"]) + "' onclick='return OpenAddDesignation(this);'><img src='../images/add-butt-white.png' alt=''  title='Add Designation' /></a>"
                + "&nbsp;&nbsp;&nbsp;&nbsp;<a id='chkOrder_" + dtDepartment.Rows[i]["DepartmentId"].ToString() + "' rel='shadowbox;width=750;height=400;' href='/Admin/UpdateDesignationSorting.aspx?DepartmentId=" + Convert.ToInt32(dtDepartment.Rows[i]["DepartmentId"]) + "' onclick='return OpenUpdateDesignationOrder(this);'><img src='../images/sort.png' alt=''  title='Edit Designation Order' /></a><br />";
              }
            }
            else
            {
              oTemplateField.HeaderText += "<input type='checkbox' id='checkbox" + dtDepartment.Rows[i]["DepartmentId"].ToString() + "' onclick='UpdateDeparmentActive(this, " + dtDepartment.Rows[i]["DepartmentId"].ToString() + ")'>"
              + "&nbsp;&nbsp;&nbsp;&nbsp;<a id='chkAdd_" + dtDepartment.Rows[i]["DepartmentId"].ToString() + "' rel='shadowbox;width=750;height=225;' href='/Admin/AddDepartment.aspx' onclick='return OpenAddDesignation(this);'style='visibility: hidden;'><img src='../images/add-butt-white.png' alt='' title='Add Designation' /></a>"
              + "&nbsp;&nbsp;&nbsp;&nbsp;<a id='chkOrder_" + dtDepartment.Rows[i]["DepartmentId"].ToString() + "' rel='shadowbox;width=750;height=400;' href='/Admin/UpdateDesignationSorting.aspx' onclick='return OpenUpdateDesignationOrder(this);'style='visibility: hidden;'><img src='../images/sort.png' alt=''  title='Edit Designation Order'  /></a><br />";
            }
            DataTable dtDesignation = oAdminController.FillDesignationTypeDetails(Convert.ToInt32(dtDepartment.Rows[i]["DepartmentId"]));
            oTemplateField.HeaderText += "</td></tr>"
              + "<tr><td valign='top' align='center' style='min-width:300px;'>";
            if (dtDesignation.Rows.Count > 0)
            {
              oTemplateField.HeaderText += "<table border='0' cellpadding='0' cellspacing='0' align='left'><tr>";
              oTemplateField.HeaderText += "<td style='width:25px;'><input id='chk_" + Convert.ToInt32(dtDepartment.Rows[i]["DepartmentId"]) + "' type='checkbox' style='display:none;' /></td>";
              for (int j = 0; j < dtDesignation.Rows.Count; j++)
              {
                oTemplateField.HeaderText += "<td valign='top' style='width:150px;background-color:#F2F2F2;color:#7E7E7E;font-size:10px;padding-top:10px; padding-left:3px;'>"
                  + "<span>Desig: </span><span style='font-weight:normal;'>" + dtDesignation.Rows[j]["DesignationName"].ToString() + "</span><br />";
                if (Convert.ToInt32(dtDesignation.Rows[j]["DepartmentID"]) != Convert.ToInt32(dtDesignation.Rows[j]["LineDepartmentId"]) && dtDesignation.Rows[j]["LineDesignationName"].ToString() != "Self")
                {
                  oTemplateField.HeaderText += "<span>Line Dept: </span><span style='font-weight:normal;'>" + dtDesignation.Rows[j]["LineDepartmentName"].ToString() + "</span><br />";
                }
                oTemplateField.HeaderText += "<span>Line Mgr: </span><span style='font-weight:normal;'>" + dtDesignation.Rows[j]["LineDesignationName"].ToString() + "</span><br />"
                  + "<span>Type: </span><span style='font-weight:normal;'>" + dtDesignation.Rows[j]["DesignationType"].ToString() + "</span>&nbsp;&nbsp;"
                  + "<a id='chkUpdate_" + dtDesignation.Rows[j]["DesignationId"].ToString() + "' rel='shadowbox;width=750;height=225;' href='/Admin/AddDesignation.aspx?DepartmentId=" + Convert.ToInt32(dtDepartment.Rows[i]["DepartmentId"]) + "&DesignationId=" + Convert.ToInt32(dtDesignation.Rows[j]["DesignationId"]) + "' onclick='return OpenAddDesignation(this);'><img src='../images/edit.png' alt='' title='Edit Designation' /></a><br />"
                  + "</td>";
              }
              oTemplateField.HeaderText += "</tr></table>";
            }
            oTemplateField.HeaderText += "</td></tr></table>";
            gvManageDesignation.Columns.Add(oTemplateField);
            oTemplateField = null;
          }
        }
      }
      oAdminController = null;
    }

    private void FillManageDesignation()
    {
      AdminController oAdminController = new AdminController();
      gvManageDesignation.DataSource = oAdminController.FillManageDesignation();
      gvManageDesignation.DataBind();
      oAdminController = null;
    }

    protected void gvManageDesignation_DataBound(object sender, EventArgs e)
    {
      for (int i = gvManageDesignation.Rows.Count - 1; i > 0; i--)
      {
        GridViewRow row = gvManageDesignation.Rows[i];
        GridViewRow previousRow = gvManageDesignation.Rows[i - 1];

        Label lblEntity = (Label)row.Cells[0].FindControl("lblEntity");
        Label lblPreviousEntity = (Label)previousRow.Cells[0].FindControl("lblEntity");

        if (lblEntity.Text == lblPreviousEntity.Text)
        {
          if (previousRow.Cells[0].RowSpan == 0)
          {
            if (row.Cells[0].RowSpan == 0)
            {
              previousRow.Cells[0].RowSpan += 2;
            }
            else
            {
              previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
            }
            row.Cells[0].Visible = false;
          }
        }
      }
    }

    protected void gvManageDesignation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        AdminController oAdminController = new AdminController();

        HiddenField hdnEntity = (HiddenField)e.Row.FindControl("hdnEntity");
        HiddenField hdnModuleId = (HiddenField)e.Row.FindControl("hdnModuleId");
        Label lblName = (Label)e.Row.FindControl("lblName");
        DropDownList ddlDepartment = (DropDownList)e.Row.FindControl("ddlDepartment");
        CheckBox chkIsActive = (CheckBox)e.Row.FindControl("chkIsActive");
        Image imgApplication = (Image)e.Row.FindControl("imgApplication");

        if (hdnEntity.Value == "Menu Icons")
        {
          imgApplication.Visible = true;
          imgApplication.ImageUrl = "~/" + System.Configuration.ConfigurationManager.AppSettings["photo.folder"] + ""+ DataBinder.Eval(e.Row.DataItem, "ImagePath");
        }
        else
        {
          imgApplication.Visible = false;
        }

        lblName.Font.Bold = Convert.ToInt32(hdnModuleId.Value) > 0 ? false : true;

        if (Convert.ToInt32(hdnModuleId.Value) == 0)
        {
          lblName.Font.Size = 13;
        }

        if (Convert.ToString(hdnEntity.Value) == "Forms" || Convert.ToString(hdnEntity.Value) == "File" || Convert.ToString(hdnEntity.Value) == "Reports")
        {
          ddlDepartment.Visible = true;
          ddlDepartment.DataSource = oAdminController.GetMenuShowDepartmentDetails();
          ddlDepartment.DataTextField = "DepartmentName";
          ddlDepartment.DataValueField = "DepartmentId";
          ddlDepartment.DataBind();

          ddlDepartment.Items.FindByValue(oAdminController.GetMenuShowDepartment(Convert.ToInt32(hdnModuleId.Value)).ToString()).Selected = true;
        }
        else
        {
          ddlDepartment.Visible = false;
        }

        chkIsActive.Checked = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "IsActive"));
        chkIsActive.Visible = Convert.ToInt32(hdnModuleId.Value) > 0 ? true : false;

        PlaceHolder DBDataPlaceHolder = new PlaceHolder();
        for (int i = 4; i < gvManageDesignation.Columns.Count; i++)
        {
          PlaceHolder oPlaceHolder = new PlaceHolder();
          oPlaceHolder.ID = "DBDataPlaceHolder_" + i;
          e.Row.Cells[i].Controls.Add(oPlaceHolder);

          DBDataPlaceHolder = (PlaceHolder)e.Row.FindControl("DBDataPlaceHolder_" + i);
          DataTable dtDepartment = oAdminController.FillDepartmentDetails(0);
          int DepartmentId = Convert.ToInt32(dtDepartment.Rows[i - 3]["DepartmentId"]);
          bool IsDepartmentActive = Convert.ToBoolean(dtDepartment.Rows[i - 3]["IsActive"]);
          DataTable dtDesignation = oAdminController.FillDesignationTypeDetails(DepartmentId);
          htmlTable.Append("<table border='0' cellpadding='0' cellspacing='0' align='left'>");
          htmlTable.Append("<tr>");
          htmlTable.Append("<td valign='top' style='width:25px;'>");
          if (dtDesignation.Rows.Count > 0)
          {
            if (Convert.ToInt32(hdnModuleId.Value) > 0)
            {
              if (chkIsActive.Checked)
              {
                if (oAdminController.GetRestrictDepartment(Convert.ToInt32(hdnModuleId.Value), DepartmentId))
                {
                  if (IsDepartmentActive)
                  {
                    htmlTable.Append("<input id='chk_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "' type='checkbox' style='width:16px;' onclick='Check_UpdateRestrictDepartment(this, " + Convert.ToInt32(hdnModuleId.Value) + ", " + DepartmentId + ")' checked='checked' />");
                  }
                  else
                  {
                    htmlTable.Append("<input id='chk_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "' type='checkbox' style='width:16px;' onclick='Check_UpdateRestrictDepartment(this, " + Convert.ToInt32(hdnModuleId.Value) + ", " + DepartmentId + ")' checked='checked' disabled='disabled' />");
                  }
                }
                else
                {
                  if (IsDepartmentActive)
                  {
                    htmlTable.Append("<input id='chk_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "' type='checkbox' style='width:16px;' onclick='Check_UpdateRestrictDepartment(this, " + Convert.ToInt32(hdnModuleId.Value) + ", " + DepartmentId + ")' />");
                  }
                  else
                  {
                    htmlTable.Append("<input id='chk_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "' type='checkbox' style='width:16px;' onclick='Check_UpdateRestrictDepartment(this, " + Convert.ToInt32(hdnModuleId.Value) + ", " + DepartmentId + ")' disabled='disabled' />");
                  }
                }
              }
              else
              {
                htmlTable.Append("<input id='chk_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "' type='checkbox' style='width:16px;' onclick='Check_UpdateRestrictDepartment(this, " + Convert.ToInt32(hdnModuleId.Value) + ", " + DepartmentId + ")' disabled='disabled' />");
              }
            }
          }
          htmlTable.Append("</td>");
          int PermissionType = 0;
          for (int k = 0; k < dtDesignation.Rows.Count; k++)
          {
            PermissionType = oAdminController.GetPermissionType(DepartmentId, Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]), Convert.ToInt32(hdnModuleId.Value));
            if (Convert.ToString(hdnEntity.Value) == "Forms" || Convert.ToString(hdnEntity.Value) == "File")
            {
              htmlTable.Append("<td valign='top'>");
              if (PermissionType == 1)
              {
                if (IsDepartmentActive)
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")' id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:block;'><option value='1' selected='selected'>Read</option><option value='2'>Write</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='Restrict' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:none;' />");
                }
                else
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select disabled='disabled' onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")' id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:block;'><option value='1' selected='selected'>Read</option><option value='2'>Write</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='Restrict' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:none;' />");
                }
              }
              else if (PermissionType == 2)
              {
                if (IsDepartmentActive)
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:block;'><option value='1'>Read</option><option value='2' selected='selected'>Write</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='Restrict' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:none;' />");
                }
                else
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select disabled='disabled' onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:block;'><option value='1'>Read</option><option value='2' selected='selected'>Write</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='Restrict' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:none;' />");
                }
              }
              else if (PermissionType == 8)
              {
                if (IsDepartmentActive)
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:none;'><option value='1' selected='selected'>Read</option><option value='2'>Write</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='Restrict' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:block;' />");
                }
                else
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select disabled='disabled' onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:none;'><option value='1' selected='selected'>Read</option><option value='2'>Write</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='Restrict' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:block;' />");
                }
              }
              htmlTable.Append("</td>");
            }
            else if (Convert.ToString(hdnEntity.Value) == "Reports")
            {
              htmlTable.Append("<td valign='top'>");
              if (PermissionType == 3)
              {
                if (IsDepartmentActive)
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:block;'><option value='3' selected='selected'>Enable</option><option value='4'>Disable</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='No Permission' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:None;' />");
                }
                else
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select disabled='disabled' onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:block;'><option value='3' selected='selected'>Enable</option><option value='4'>Disable</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='No Permission' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:None;' />");
                }
              }
              else if (PermissionType == 4)
              {
                if (IsDepartmentActive)
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:block;'><option value='3'>Enable</option><option value='4' selected='selected'>Disable</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='No Permission' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:None;' />");
                }
                else
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select disabled='disabled' onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:block;'><option value='3'>Enable</option><option value='4' selected='selected'>Disable</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='No Permission' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:None;' />");
                }
              }
              else if (PermissionType == 9)
              {
                if (IsDepartmentActive)
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:none;'><option value='3' selected='selected'>Enable</option><option value='4'>Disable</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='No Permission' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:block;' />");
                }
                else
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select disabled='disabled' onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:none;'><option value='3' selected='selected'>Enable</option><option value='4'>Disable</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='No Permission' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:block;' />");
                }
              }
              htmlTable.Append("</td>");
            }
            else if (Convert.ToString(hdnEntity.Value) == "Menu Icons")
            {
              htmlTable.Append("<td valign='top'>");
              if (PermissionType == 5)
              {
                if (IsDepartmentActive)
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:block;'><option value='5' selected='selected'>Yes</option><option value='6'>No</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='No Permission' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:none;' />");
                }
                else
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select disabled='disabled' onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:block;'><option value='5' selected='selected'>Yes</option><option value='6'>No</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='No Permission' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:none;' />");
                }
              }
              else if (PermissionType == 6)
              {
                if (IsDepartmentActive)
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:block;'><option value='5'>Yes</option><option value='6' selected='selected'>No</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='No Permission' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:none;' />");
                }
                else
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select disabled='disabled' onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:block;'><option value='5'>Yes</option><option value='6' selected='selected'>No</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='No Permission' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:none;' />");
                }
              }
              else if (PermissionType == 9)
              {
                if (IsDepartmentActive)
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:none;'><option value='5' selected='selected'>Yes</option><option value='6'>No</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='No Permission' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:block;' />");
                }
                else
                {
                  htmlTable.Append("<input id='hdn_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + PermissionType + "' /><select disabled='disabled' onchange='SavePermission(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ", " + Convert.ToInt32(hdnModuleId.Value) + ")'  id='ddl_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;display:none;'><option value='5' selected='selected'>Yes</option><option value='6'>No</option></select><input id='txt_" + Convert.ToInt32(hdnModuleId.Value) + "_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='text' value='No Permission' disabled='disabled' style='font-weight:bold;width:146px;height:21px;text-align: center;display:block;' />");
                }
              }
              htmlTable.Append("</td>");
            }
            else
            {
              htmlTable.Append("<td valign='top'>");
              int ApplicationDEfaultLandingPageId = oAdminController.GetApplicationDEfaultLandingPageId(DepartmentId, Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]));

              if (IsDepartmentActive)
              {
                htmlTable.Append("<input id='hdn_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + ApplicationDEfaultLandingPageId + "' /><select onchange='SaveDefaultLanding(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ")'  id='ddl_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;'>");
                DataTable dtApplicationModuleDetails = oAdminController.GetApplicationModuleDetails();
                if (dtApplicationModuleDetails.Rows.Count > 0)
                {
                  for (int a = 0; a < dtApplicationModuleDetails.Rows.Count; a++)
                  {
                    if (ApplicationDEfaultLandingPageId == Convert.ToInt32(dtApplicationModuleDetails.Rows[a]["ApplicationModuleId"]))
                    {
                      htmlTable.Append("<option selected='selected' value='" + dtApplicationModuleDetails.Rows[a]["ApplicationModuleId"].ToString() + "'>" + dtApplicationModuleDetails.Rows[a]["ApplicationModule"].ToString() + "</option>");
                    }
                    else
                    {
                      htmlTable.Append("<option value='" + dtApplicationModuleDetails.Rows[a]["ApplicationModuleId"].ToString() + "'>" + dtApplicationModuleDetails.Rows[a]["ApplicationModule"].ToString() + "</option>");
                    }
                  }
                }
                htmlTable.Append("</select>");
              }
              else
              {
                htmlTable.Append("<input id='hdn_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' type='hidden' value='" + ApplicationDEfaultLandingPageId + "' /><select  disabled='disabled' onchange='SaveDefaultLanding(this.options[this.selectedIndex].value, " + DepartmentId + ", " + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + ")'  id='ddl_" + DepartmentId + "_" + Convert.ToInt32(dtDesignation.Rows[k]["DesignationId"]) + "' class='txt' style='width:150px;height:25px;'>");
                DataTable dtApplicationModuleDetails = oAdminController.GetApplicationModuleDetails();
                if (dtApplicationModuleDetails.Rows.Count > 0)
                {
                  for (int a = 0; a < dtApplicationModuleDetails.Rows.Count; a++)
                  {
                    if (ApplicationDEfaultLandingPageId == Convert.ToInt32(dtApplicationModuleDetails.Rows[a]["ApplicationModuleId"]))
                    {
                      htmlTable.Append("<option selected='selected' value='" + dtApplicationModuleDetails.Rows[a]["ApplicationModuleId"].ToString() + "'>" + dtApplicationModuleDetails.Rows[a]["ApplicationModule"].ToString() + "</option>");
                    }
                    else
                    {
                      htmlTable.Append("<option value='" + dtApplicationModuleDetails.Rows[a]["ApplicationModuleId"].ToString() + "'>" + dtApplicationModuleDetails.Rows[a]["ApplicationModule"].ToString() + "</option>");
                    }
                  }
                }
                htmlTable.Append("</select>");
              }
              htmlTable.Append("</td>");
            }
          }
          htmlTable.Append("</tr>");
          htmlTable.Append("</table>");
          DBDataPlaceHolder.Controls.Add(new Literal { Text = htmlTable.ToString() });
          htmlTable.Length = 0;
        }
      }
    }
  }
}