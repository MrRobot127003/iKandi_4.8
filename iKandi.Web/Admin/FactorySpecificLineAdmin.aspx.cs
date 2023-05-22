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
  public partial class FactorySpecificLineAdmin : System.Web.UI.Page
  {
    int UserId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
            Response.Redirect("~/public/Login.aspx");

      UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
      hdnUserId.Value = UserId.ToString();
      if (!IsPostBack)
      {
        FillFactory();
        BindboundField();
        FillLineStatus();
      }
    }

    private void FillFactory()
    {
      AdminController oAdminController = new AdminController();
      ddlFactorySearch.DataSource = oAdminController.GetFactorynames(0, "");
      ddlFactorySearch.DataValueField = "id";
      ddlFactorySearch.DataTextField = "Name";
      ddlFactorySearch.DataBind();
      oAdminController = null;
    }

    private void FillLineStatus()
    {
      int UnitId = Convert.ToInt32(ddlFactorySearch.SelectedValue);
      DataSet ds = new DataSet();
      AdminController oAdminController = new AdminController();
      ds = oAdminController.GetFactorySpecificDetails(UnitId, 0);

      if (ds.Tables[2].Rows.Count > 0)
      {
        gvLineStatus.DataSource = ds.Tables[2];
        gvLineStatus.DataBind();
        gvLineStatus.Visible = true;
      }
      else
      {
        gvLineStatus.Visible = false;
        gvLineStatus.Visible = false;
      }
      oAdminController = null;
    }

    public void BindboundField()
    {
      AdminController oAdminController = new AdminController();
      DataSet dsDesignation = oAdminController.GetDesignationName();
      DataTable dtDesignation = dsDesignation.Tables[0];
      hdnTableCount.Value = dtDesignation.Rows.Count.ToString();

      for (int i = 0; i < dsDesignation.Tables[0].Rows.Count; i++)
      {
        hdnIdCount.Value = hdnIdCount.Value + dsDesignation.Tables[0].Rows[i]["id"].ToString() + ",";
      }

      if (dtDesignation.Rows.Count > 0)
      {
        for (int i = 0; i < dtDesignation.Rows.Count; i++)
        {
          BoundField boundField = new BoundField();
          boundField.HeaderText = "";
          gvLineStatus.Columns.Add(boundField);
        }
      }
      oAdminController = null;
    }

    protected void ddlFactorySearch_SelectedIndexChanged(object sender, EventArgs e)
    {
      FillLineStatus();
    }

    protected void gvLineStatus_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        HiddenField hdnUnitId = (HiddenField)e.Row.FindControl("hdnUnitId");
        DropDownList ddlFloor = (DropDownList)e.Row.FindControl("ddlFloor");
        Label lblLine = (Label)e.Row.FindControl("lblLine");

        int UnitId = Convert.ToInt32(ddlFactorySearch.SelectedValue);
        DataSet ds = new DataSet();
        AdminController oAdminController = new AdminController();
        ds = oAdminController.GetFactorySpecificDetails(Convert.ToInt32(hdnUnitId.Value), 0);
        DataView dv = new DataView(ds.Tables[3]);

        dv.RowFilter = "UnitID = " + Convert.ToInt32(hdnUnitId.Value);
        ddlFloor.DataSource = dv;
        ddlFloor.DataTextField = "Floor_No";
        ddlFloor.DataValueField = "Floor_No";
        ddlFloor.DataBind();

        if (ddlFloor.Items.Count > 1)
        {
          ddlFloor.Items.Insert(0, new ListItem("Select", "0"));
          ddlFloor.Enabled = true;
        }
        else
        {
          ddlFloor.Enabled = false;
        }

        DataTable dtLineFloor_IsClosedDetails = oAdminController.GetFactoryLineFloor_IsClosedDetails(Convert.ToInt32(hdnUnitId.Value), Convert.ToInt32(lblLine.Text.Replace("Line ", "")));
        if (dtLineFloor_IsClosedDetails.Rows.Count > 0)
        {
          ddlFloor.SelectedValue = dtLineFloor_IsClosedDetails.Rows[0]["FloorNo"].ToString();
        }

        int RowIndex = e.Row.RowIndex;

        DataSet dsIsClosed = new DataSet();

        DataSet dsDesignation = oAdminController.GetDesignationName();
        DataTable dtDesignation = dsDesignation.Tables[0];

        if (dtDesignation.Rows.Count > 0)
        {
          for (int i = 0; i < dtDesignation.Rows.Count; i++)
          {
            string colName = dtDesignation.Rows[i]["Name"].ToString();
            string Id = dtDesignation.Rows[i]["id"].ToString();
            gvLineStatus.HeaderRow.Cells[i + 3].Text = colName;

            Label lblName = new Label();
            lblName.EnableViewState = true;
            lblName.Enabled = true;
            lblName.ID = "lblDesigName";
            lblName.Text = colName;
            lblName.Width = 125;
            gvLineStatus.HeaderRow.Style.Add("width", "250px");
            gvLineStatus.HeaderRow.Style.Add("class", "topMenu2");
            gvLineStatus.HeaderRow.Style.Add("text-align", "center");
            gvLineStatus.HeaderRow.Cells[i + 3].Controls.Add(lblName);

            if (colName != "Is Closed")
            {
              DropDownList ddlDesig = new DropDownList();
              ddlDesig.EnableViewState = true;
              ddlDesig.Enabled = true;
              ddlDesig.ID = "ddl_" + Id;
              ddlDesig.Attributes.Add("class", "DesigName" + RowIndex + "_" + Id + " " + "DesigName" + RowIndex);
              ddlDesig.Attributes.Add("onchange", "javascript:return SaveFactoryLine(this)");
              e.Row.Cells[i + 3].Controls.Add(ddlDesig);

              DropDownList ddlDesigName = (DropDownList)e.Row.FindControl("ddl_" + Id);

              DataSet dtDesig = new DataSet();
              if (Id == "7")
              {
                dtDesig = oAdminController.GetFactorynames(Convert.ToInt32(hdnUnitId.Value), Id.ToString());
                ddlDesigName.DataSource = dtDesig.Tables[5];// dsFactory.Tables[3];
                ddlDesigName.DataValueField = "Name";
                ddlDesigName.DataTextField = "Name";
                ddlDesigName.DataBind();

                ddlDesigName.Enabled = ddlDesigName.Items.Count == 1 ? false : true;
              }
              else if (Id == "6")
              {
                dtDesig = oAdminController.GetFactorynames(Convert.ToInt32(hdnUnitId.Value), Id.ToString());
                ddlDesigName.DataSource = dtDesig.Tables[6];// dsFactory.Tables[3];
                ddlDesigName.DataValueField = "Name";
                ddlDesigName.DataTextField = "Name";
                ddlDesigName.DataBind();

                ddlDesigName.Enabled = ddlDesigName.Items.Count == 1 ? false : true;
              }
              else
              {
                dtDesig = oAdminController.GetFactorynames(Convert.ToInt32(hdnUnitId.Value), Id.ToString());
                ddlDesigName.DataSource = dtDesig.Tables[4];// dsFactory.Tables[3];
                ddlDesigName.DataValueField = "Name";
                ddlDesigName.DataTextField = "Name";
                ddlDesigName.DataBind();

                ddlDesigName.Enabled = ddlDesigName.Items.Count == 1 ? false : true;
              }

              DataTable dtFactoryLineDesignationDetails = oAdminController.GetFactoryLineDesignationDetails(Convert.ToInt32(hdnUnitId.Value), Convert.ToInt32(lblLine.Text.Replace("Line ", "")), Convert.ToInt32(Id));
              if (dtFactoryLineDesignationDetails.Rows.Count > 0)
              {
                ddlDesigName.SelectedValue = dtFactoryLineDesignationDetails.Rows[0]["DesignationName"].ToString();
              }
            }
            else
            {
              RadioButtonList rbtn = new RadioButtonList();
              rbtn.Items.Add("Yes");
              rbtn.Items.Add("No");
              rbtn.Attributes.Add("Selected", "Selected");
              rbtn.EnableViewState = true;
              rbtn.Enabled = true;
              rbtn.RepeatDirection = RepeatDirection.Horizontal;
              rbtn.ID = "rbtn";

              rbtn.Attributes.Add("class", "IsClosed" + RowIndex);
              rbtn.Enabled = true;
              rbtn.Attributes.Add("onclick", "javascript:return SaveIsClosed(this)");
              e.Row.Cells[i + 3].Controls.Add(rbtn);

              rbtn.Items[0].Selected = true;
              int FloorNo = ddlFloor.SelectedValue == "" ? 0 : Convert.ToInt32(ddlFloor.SelectedValue);
              bool IsClosed = rbtn.SelectedValue == "Yes" ? true : false;
              oAdminController.UpdateFactoryLineStatus(Convert.ToInt32(hdnUnitId.Value), FloorNo, Convert.ToInt32(lblLine.Text.Replace("Line ", "")), IsClosed, UserId);

              if (dtLineFloor_IsClosedDetails.Rows.Count > 0)
              {
                rbtn.SelectedValue = Convert.ToBoolean(dtLineFloor_IsClosedDetails.Rows[0]["IsClosed"]) == true ? "Yes" : "No";
              }
            }
          }
        }
        oAdminController = null;
      }
    }
  }
}