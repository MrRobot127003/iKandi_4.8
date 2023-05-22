using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.BLL;
namespace iKandi.Web.UserControls.Forms
{
  public partial class FactorySpecificLineAdmin : System.Web.UI.UserControl
  {
    AdminController obj_AdminController = new AdminController();
    DataSet dsDesignation = new DataSet();
    DataTable dtDesignation = new DataTable();
    DataTable dtmerge = new DataTable();
    DataSet dtBindGrid = new DataSet();
    DataSet dsDropDown = new DataSet();


    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindboundField();
        BindGrd();
      }
    }


    public void BindboundField()
    {
      dsDesignation = obj_AdminController.GetDesignationName();
      dtDesignation = dsDesignation.Tables[0];
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
          grdLine.Columns.Add(boundField);
        }
      }
    }

    public void BindGrd()
    {
      DataSet dt = new DataSet();

      dsDropDown = obj_AdminController.GetFactorynames(0, "");
      ddlSearch.DataSource = dsDropDown.Tables[0];
      ddlSearch.DataValueField = "id";
      ddlSearch.DataTextField = "Name";
      ddlSearch.DataBind();

      int UnitId = Convert.ToInt32(ddlSearch.SelectedValue);
      if (UnitId == -1)
      {
        dt = obj_AdminController.GetFactorySpecificDetails(0, 0);
        grdLine.DataSource = dt;
        grdLine.DataBind();
      }
      else
      {
        dt = obj_AdminController.GetFactorySpecificDetails(UnitId, 0);
        grdLine.DataSource = dt.Tables[2];
        grdLine.DataBind();
      }
    }

    protected void btnFactory_Click(object sender, EventArgs e)
    {
      DataSet dt = new DataSet();
      dt = obj_AdminController.GetFactorySpecificDetails(0, 0);
      grdLine.DataSource = dt;
      grdLine.DataBind();
    }
    protected void grdLine_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType != DataControlRowType.DataRow)
        return;

      DropDownList ddlFactory = (DropDownList)e.Row.FindControl("ddlFactory");
      DropDownList ddlFloor = (DropDownList)e.Row.FindControl("ddlFloor");
      DropDownList ddlLine = (DropDownList)e.Row.FindControl("ddlLine");
      HiddenField hdnFactoryLineId = (HiddenField)e.Row.FindControl("hdnFactoryLineId");
      HiddenField hdnUnitId = (HiddenField)e.Row.FindControl("hdnUnitId");

      int RowIndex = e.Row.RowIndex;

      DataSet dsIsClosed = new DataSet();
      DataSet ds = new DataSet();
      ddlFloor.Attributes.Add("class", "Floor" + RowIndex);
      ddlLine.Attributes.Add("class", "Line" + RowIndex);
      ddlFloor.CssClass = "Floor" + RowIndex;

      DataSet dsFactory = new DataSet();

      int SelectFactoryId = 0;
      int SelectFloorId = 0;
      int SelectLineId = 0;
      string DesigName = "";
      bool IsClosed = false;
      int FactoryId = 0;

      if (hdnFactoryLineId != null)
      {
        if (hdnFactoryLineId.Value != "")
        {
          ds = obj_AdminController.GetFactorySpecificDetails(Convert.ToInt32(hdnFactoryLineId.Value), 0);
          SelectFactoryId = Convert.ToInt32(ds.Tables[0].Rows[0]["UnitID"]);
          SelectFloorId = Convert.ToInt32(ds.Tables[0].Rows[0]["FloorNo"]);
          SelectLineId = Convert.ToInt32(ds.Tables[0].Rows[0]["NoOfLines"]);
        }
      }

      if (hdnUnitId.Value != null)
      {
        if (hdnUnitId.Value != "")
        {
          FactoryId = Convert.ToInt32(hdnUnitId.Value);
          dsFactory = obj_AdminController.GetFactorynames(FactoryId, "");

          ddlFloor.DataSource = dsFactory.Tables[1];
          ddlFloor.DataValueField = "id";
          ddlFloor.DataTextField = "Name";
          ddlFloor.DataBind();

          ddlLine.DataSource = dsFactory.Tables[2];
          ddlLine.DataValueField = "id";
          ddlLine.DataTextField = "Name";
          ddlLine.DataBind();
        }
        else
        {
          dsFactory = obj_AdminController.GetFactorynames(0, "");
        }
      }

      ddlFactory.DataSource = dsFactory.Tables[0];
      ddlFactory.DataValueField = "id";
      ddlFactory.DataTextField = "Name";
      ddlFactory.DataBind();

      ddlFactory.SelectedValue = SelectFactoryId.ToString();

      ddlFloor.SelectedValue = SelectFloorId.ToString();
      ddlLine.SelectedValue = SelectLineId.ToString();

      dsDesignation = obj_AdminController.GetDesignationName();
      dtDesignation = dsDesignation.Tables[0];

      if (dtDesignation.Rows.Count > 0)
      {
        for (int i = 0; i < dtDesignation.Rows.Count; i++)
        {
          string colName = dtDesignation.Rows[i]["Name"].ToString();
          string Id = dtDesignation.Rows[i]["id"].ToString();
          grdLine.HeaderRow.Cells[i + 3].Text = colName;

          Label lblName = new Label();
          lblName.EnableViewState = true;
          lblName.Enabled = true;
          lblName.ID = "lblDesigName" + i;
          lblName.Text = colName;
          lblName.Width = 125;
          grdLine.HeaderRow.Style.Add("width", "250px");
          grdLine.HeaderRow.Style.Add("class", "topMenu2");
          grdLine.HeaderRow.Style.Add("text-align", "center");
          grdLine.HeaderRow.Cells[i + 3].Controls.Add(lblName);

          if (colName != "Is Closed")
          {
            DropDownList ddlDesig = new DropDownList();
            ddlDesig.EnableViewState = true;
            ddlDesig.Enabled = true;
            ddlDesig.ID = "ddl_" + Id + "_" + i;
            ddlDesig.Attributes.Add("class", "DesigName" + RowIndex + "_" + Id + " " + "DesigName" + RowIndex);
            ddlDesig.Attributes.Add("onchange", "javascript:return SaveFactoryLine(this)");
            e.Row.Cells[i + 3].Controls.Add(ddlDesig);

            DropDownList ddlDesigName = (DropDownList)e.Row.FindControl("ddl_" + Id + "_" + i);

            // FIll DropdownList for Line Designation Name
            if (hdnFactoryLineId.Value != "")
            {
              DataSet dtDesig = new DataSet();
              if (Id == "7")
              {
                dtDesig = obj_AdminController.GetFactorynames(Convert.ToInt32(hdnUnitId.Value), Id.ToString());
                ddlDesigName.DataSource = dtDesig.Tables[5];// dsFactory.Tables[3];
                ddlDesigName.DataValueField = "Name";
                ddlDesigName.DataTextField = "Name";
                ddlDesigName.DataBind();
              }
              else if (Id == "6")
              {
                dtDesig = obj_AdminController.GetFactorynames(Convert.ToInt32(hdnUnitId.Value), Id.ToString());
                ddlDesigName.DataSource = dtDesig.Tables[6];// dsFactory.Tables[3];
                ddlDesigName.DataValueField = "Name";
                ddlDesigName.DataTextField = "Name";
                ddlDesigName.DataBind();
              }
              else
              {
                dtDesig = obj_AdminController.GetFactorynames(Convert.ToInt32(hdnUnitId.Value), Id.ToString());
                ddlDesigName.DataSource = dtDesig.Tables[4];// dsFactory.Tables[3];
                ddlDesigName.DataValueField = "Name";
                ddlDesigName.DataTextField = "Name";
                ddlDesigName.DataBind();
              }

              ds = obj_AdminController.GetFactorySpecificDetails(Convert.ToInt32(hdnFactoryLineId.Value), Convert.ToInt32(Id));
              if (ds.Tables[1].Rows.Count > 0)
              {
                DesigName = ds.Tables[1].Rows[0]["DesignationName"].ToString();
                ddlDesigName.SelectedValue = DesigName;
              }
            }
          }

          if (colName == "Is Closed")
          {
            RadioButtonList rbtn = new RadioButtonList();
            rbtn.Items.Add("Yes");
            rbtn.Items.Add("No");
            rbtn.Attributes.Add("Selected", "Selected");
            rbtn.EnableViewState = true;
            rbtn.Enabled = true;
            rbtn.RepeatDirection = RepeatDirection.Horizontal;
            rbtn.ID = "rbtn_" + i;

            rbtn.Attributes.Add("class", "IsClosed" + RowIndex);
            rbtn.Enabled = true;
            rbtn.Attributes.Add("onclick", "javascript:return SaveIsClosed(this)");
            e.Row.Cells[i + 3].Controls.Add(rbtn);

            RadioButtonList rbtnlst = (RadioButtonList)e.Row.FindControl("rbtn_" + i);

            if (hdnFactoryLineId.Value != "")
            {
              dsIsClosed = obj_AdminController.GetFactorySpecificDetails(Convert.ToInt32(hdnFactoryLineId.Value), Convert.ToInt32(Id));
            }

            if (hdnFactoryLineId.Value != "")
            {

              if (dsIsClosed.Tables[0].Rows.Count > 0)
              {
                IsClosed = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsClosed"].ToString());
                if (IsClosed == true)
                {
                  rbtnlst.Items[0].Selected = true;
                  rbtnlst.Enabled = false;
                }
                else
                {
                  rbtnlst.Items[1].Selected = true;
                  rbtnlst.Enabled = false;
                }
              }
            }
            else
            {
              rbtnlst.Items[0].Selected = true;
              rbtnlst.Enabled = true;
            }
          }
        }
      }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
      if (ViewState["dtnew"] != null)
      {
        DataSet dtnew = new DataSet();
        dtnew = obj_AdminController.GetFactorySpecificDetails(0, 0);
        //dtnew = (DataTable)(ViewState["dtnew"]);
        DataRow newrow = dtnew.Tables[0].NewRow();
        dtnew.Tables[0].Rows.Add(newrow);
        dtmerge = dtnew.Tables[0];
        grdLine.DataSource = dtmerge;
        grdLine.DataBind();
        ViewState["dtnew"] = dtmerge;
      }
      else
      {
        dtBindGrid = obj_AdminController.GetFactorySpecificDetails(0, 0);
        DataRow newrow = dtBindGrid.Tables[0].NewRow();
        dtBindGrid.Tables[0].Rows.Add(newrow);
        dtmerge = dtBindGrid.Tables[0];
        grdLine.DataSource = dtmerge;
        grdLine.DataBind();
        ViewState["dtnew"] = dtmerge;
      }
    }

    protected void ddlFactory_SelectedIndexChanged(object sender, EventArgs e)
    {
      GridViewRow row = ((DropDownList)sender).NamingContainer as GridViewRow;
      DropDownList ddlFactory = (DropDownList)row.FindControl("ddlFactory");

      DropDownList ddlFloor = (DropDownList)row.FindControl("ddlFloor");
      DropDownList ddlLine = (DropDownList)row.FindControl("ddlLine");
      int Factory = Convert.ToInt32(ddlFactory.SelectedValue);
      DataSet dsTables = new DataSet();
      dsTables = obj_AdminController.GetFactorynames(Factory, "");

      ddlFloor.DataSource = dsTables.Tables[1];
      ddlFloor.DataValueField = "id";
      ddlFloor.DataTextField = "Name";
      ddlFloor.DataBind();

      ddlLine.DataSource = dsTables.Tables[2];
      ddlLine.DataValueField = "id";
      ddlLine.DataTextField = "Name";
      ddlLine.DataBind();
    }

    protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
      int UnitId = Convert.ToInt32(ddlSearch.SelectedValue);
      DataSet dt = new DataSet();
      dt = obj_AdminController.GetFactorySpecificDetails(UnitId, 0);


      if (dt.Tables[2].Rows.Count > 0)
      {
        grdLine.DataSource = dt.Tables[2];
        grdLine.DataBind();
        grdLine.Visible = true;
        divgrd.Visible = true;
        lblIsRecordFound.Visible = false;
      }
      else
      {
        grdLine.Visible = false;
        divgrd.Visible = false;
        lblIsRecordFound.Visible = true;
      }
    }

  }
}