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

namespace iKandi.Web.UserControls.Forms
{
    public partial class FactorySpecificLineAdminControl : BaseUserControl
  {
        static int UnitId;
    protected void Page_Load(object sender, EventArgs e)
    {
      // UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
      hdnUserId.Value = ApplicationHelper.LoggedInUser.UserData.UserID.ToString();
      if (!IsPostBack)
      {
        //BindboundField();
        //FillFactory();
        //BindboundField();
        //FillLineStatus();
      }

      if (Session["Productidid"] != null)
      {

        int id = Convert.ToInt32(Session["Productidid"].ToString());
        UnitId=Convert.ToInt32(Session["Productidid"].ToString());
        ViewState["id"] = id;
        FillFactory();
        BindboundField();
        FillLineStatus();
        BindboundFieldcluster();
        FillLineStatuscluster();

        Session["Productidid"] = null;
          //---cluster----------------------------------------//
        //FillFactorycluster();
        
          //-------------------------------------------------
      }

      AdminController objAdmincontroller = new AdminController();

      //DataTable dt = new DataTable();

      //dt = objAdmincontroller.getProdctionID_get();

      if (ViewState["id"] != null)
      {
          string ProdID = ViewState["id"].ToString();
          Boolean Inhouse = false;
          if (!string.IsNullOrEmpty(ProdID))
          {
              Inhouse = objAdmincontroller.getProdctionIDInhouse(ProdID);
          }
          //  string ProdID = dt.Rows[0]["Prod_id"].ToString();
          if (!string.IsNullOrEmpty(ProdID) && (Inhouse == true))
          {
              FillFactory();
              //FillFactorycluster();

              ddlFactorySearch.SelectedValue = ProdID;
              ddlFactorySearch_SelectedIndexChanged(this, e);
              ddlFactorySearch.Enabled = false;
              tblserver.Visible = true;


          }
          else
          {
              ddlFactorySearch.SelectedValue = "-1";
              ddlFactorySearch_SelectedIndexChanged(this, e);
              ddlFactorySearch.Enabled = true;
              tblserver.Visible = false;
          }

          ddlFactorySearch.Enabled = false;
      }
      else
      {
          tblserver.Visible = false;
      }
    }

    private void FillFactory()
    {
      //ddlFactorySearch.Items.Clear();
      AdminController oAdminController = new AdminController();
      ddlFactorySearch.DataSource = oAdminController.GetFactorynames(0, "");
      ddlFactorySearch.DataValueField = "id";
      ddlFactorySearch.DataTextField = "Name";
      ddlFactorySearch.DataBind();
      oAdminController = null;
    }

    private void FillLineStatus()
    {
      AdminController objAdmincontroller = new AdminController();
      DataTable dt = new DataTable();

      // UnitId = Convert.ToInt32(ddlFactorySearch.SelectedValue);

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
        HiddenField hdnFloor = (HiddenField)e.Row.FindControl("hdnFloor");

        HiddenField hdnmanPower = (HiddenField)e.Row.FindControl("hdnmanPower");


        TextBox txtmanpower = (TextBox)e.Row.FindControl("txtmanpower");
          
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
          //updated abhishek 19/9/2016
        DataTable dtLineFloor_IsClosedDetails = oAdminController.GetFactoryLineFloor_IsClosedDetails(Convert.ToInt32(hdnUnitId.Value), Convert.ToInt32(lblLine.Text.Replace("Line ", "")));
        if (dtLineFloor_IsClosedDetails.Rows.Count > 0)
        {
          ddlFloor.SelectedValue = dtLineFloor_IsClosedDetails.Rows[0]["FloorNo"].ToString();
          hdnFloor.Value = dtLineFloor_IsClosedDetails.Rows[0]["FloorNo"].ToString();

          txtmanpower.Text = dtLineFloor_IsClosedDetails.Rows[0]["ManPower"].ToString();
          hdnmanPower.Value = dtLineFloor_IsClosedDetails.Rows[0]["ManPower"].ToString();
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
            gvLineStatus.HeaderRow.Cells[i + 4].Text = colName;

            Label lblName = new Label();
            lblName.EnableViewState = true;
            lblName.Enabled = true;
            lblName.ID = "lblDesigName";
            lblName.Text = colName;
            lblName.Width = 125;
            gvLineStatus.HeaderRow.Style.Add("width", "250px");
            gvLineStatus.HeaderRow.Style.Add("class", "topMenu2");
            gvLineStatus.HeaderRow.Style.Add("text-align", "center");
            gvLineStatus.HeaderRow.Cells[i + 4].Controls.Add(lblName);

            if (colName != "Is Closed")
            {
              DropDownList ddlDesig = new DropDownList();
              ddlDesig.EnableViewState = true;
              ddlDesig.Enabled = true;
              ddlDesig.ID = "ddl_" + Id;
              ddlDesig.Attributes.Add("class", "DesigName" + RowIndex + "_" + Id + " " + "DesigName" + RowIndex);
              ddlDesig.Attributes.Add("onchange", "javascript:return SaveFactoryLine(this)");
              e.Row.Cells[i + 4].Controls.Add(ddlDesig);

              DropDownList ddlDesigName = (DropDownList)e.Row.FindControl("ddl_" + Id);

              DataTable dtUsersByDesg = new DataTable();
              //if (Id == "7")
              //{
             // dtDesig = oAdminController.GetFactorynames(Convert.ToInt32(hdnUnitId.Value), Id.ToString());
              dtUsersByDesg=  this.UserControllerInstance.GetUsersByDesignationDataTable(Convert.ToInt32(Id));

              ddlDesigName.DataSource = dtUsersByDesg;
              ddlDesigName.DataValueField = "UserID";
              ddlDesigName.DataTextField = "FLName" ;
              ddlDesigName.DataBind();
              ListItem li = new ListItem();
              li.Text = "Select";
              li.Value = "0";
              ddlDesigName.Items.Insert(0, li);

              //ddlDesigName.Enabled = ddlDesigName.Items.Count == 1 ? false : true; Gajendra ProductionUnit

              DataTable dtFactoryLineDesignationDetails = oAdminController.GetFactoryLineDesignationDetails(Convert.ToInt32(hdnUnitId.Value), Convert.ToInt32(lblLine.Text.Replace("Line ", "")), Convert.ToInt32(Id));
              if (dtFactoryLineDesignationDetails.Rows.Count > 0)
              {
                ddlDesigName.SelectedValue = dtFactoryLineDesignationDetails.Rows[0]["UserID"].ToString();
              }
              //}
              //else if (Id == "6")
              //{
              //    dtDesig = oAdminController.GetFactorynames(Convert.ToInt32(hdnUnitId.Value), Id.ToString());
              //    ddlDesigName.DataSource = dtDesig.Tables[6];// dsFactory.Tables[3];
              //    ddlDesigName.DataValueField = "Name";
              //    ddlDesigName.DataTextField = "Name";
              //    ddlDesigName.DataBind();

              //    ddlDesigName.Enabled = ddlDesigName.Items.Count == 1 ? false : true;
              //}
              //else
              //{
              //    dtDesig = oAdminController.GetFactorynames(Convert.ToInt32(hdnUnitId.Value), Id.ToString());
              //    ddlDesigName.DataSource = dtDesig.Tables[4];// dsFactory.Tables[3];
              //    ddlDesigName.DataValueField = "Name";
              //    ddlDesigName.DataTextField = "Name";
              //    ddlDesigName.DataBind();

              //    ddlDesigName.Enabled = ddlDesigName.Items.Count == 1 ? false : true;
              //}
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
              e.Row.Cells[i + 4].Controls.Add(rbtn);

              rbtn.Items[0].Selected = true;
              int FloorNo = ddlFloor.SelectedValue == "" ? 0 : Convert.ToInt32(ddlFloor.SelectedValue);
              bool IsClosed = rbtn.SelectedValue == "Yes" ? true : false;
              oAdminController.UpdateFactoryLineStatus(Convert.ToInt32(hdnUnitId.Value), FloorNo, Convert.ToInt32(lblLine.Text.Replace("Line ", "")), IsClosed, ApplicationHelper.LoggedInUser.UserData.UserID);

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
        //-------------------------------------------------------cluster---------------------------//
    //private void FillFactorycluster()
    //{
    //    //ddlFactorySearch.Items.Clear();
    //    AdminController oAdminController = new AdminController();
    //    ddlFactorySearch.DataSource = oAdminController.GetFactorynames(0, "");
    //    ddlFactorySearch.DataValueField = "id";
    //    ddlFactorySearch.DataTextField = "Name";
    //    ddlFactorySearch.DataBind();
    //    oAdminController = null;
    //}

    private void FillLineStatuscluster()
    {
        AdminController objAdmincontroller = new AdminController();
        DataTable dt = new DataTable();

        //int UnitId = Convert.ToInt32(ddlFactorySearch.SelectedValue);

        DataSet ds = new DataSet();
        AdminController oAdminController = new AdminController();
        ds = oAdminController.GetFactorySpecificDetailsforcluster(UnitId, 0);

        if (ds.Tables[0].Rows.Count > 0)
        {
            gvLineStatusCluster.DataSource = ds.Tables[0];
            gvLineStatusCluster.DataBind();
            gvLineStatusCluster.Visible = true;

        }
        else
        {
            gvLineStatusCluster.Visible = false;
            gvLineStatusCluster.Visible = false;
        }
        oAdminController = null;
    }

    public void BindboundFieldcluster()
    {
        AdminController oAdminController = new AdminController();
        DataSet dsDesignation = oAdminController.GetDesignationNamecluster();
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
                gvLineStatusCluster.Columns.Add(boundField);
            }
        }
        oAdminController = null;
    }

    protected void ddlFactorySearchcluster_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillLineStatuscluster();
    }
    string check = string.Empty;
    protected void gvLineStatusCluster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdnUnitId = (HiddenField)e.Row.FindControl("hdnUnitId");
            DropDownList ddlFloor = (DropDownList)e.Row.FindControl("ddlFloor");
            Label lblLine = (Label)e.Row.FindControl("lblLine");
            HiddenField hdnFloor = (HiddenField)e.Row.FindControl("hdnFloor");

            HiddenField hdnmanPower = (HiddenField)e.Row.FindControl("hdnmanPower");


            TextBox txtmanpower = (TextBox)e.Row.FindControl("txtmanpower");

            int UnitId = Convert.ToInt32(ddlFactorySearch.SelectedValue);

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataTable dtitemval = new DataTable();
            AdminController oAdminController = new AdminController();
            ds = oAdminController.GetFactorySpecificDetailsforcluster(Convert.ToInt32(hdnUnitId.Value), Convert.ToInt32(lblLine.Text.Replace("Cluster ","")));
            //DataView dv = new DataView(ds.Tables[3]);
            dtitemval = ds.Tables[0];
            dt = ds.Tables[1];

            check = ds.Tables[2].Rows[0]["finishCheck"].ToString();
           // dv.RowFilter = "UnitID = " + Convert.ToInt32(hdnUnitId.Value);

            ddlFloor.DataSource = dt;
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
            if (check == "1")
            {
                ddlFloor.Enabled = true;
                txtmanpower.Enabled = true;
            }
            //updated abhishek 19/9/2016
            //DataTable dtLineFloor_IsClosedDetails = oAdminController.GetFactoryLineFloor_IsClosedDetails(Convert.ToInt32(hdnUnitId.Value), Convert.ToInt32(lblLine.Text.Replace("Line ", "")));
            //if (dtLineFloor_IsClosedDetails.Rows.Count > 0)
            //{
            //    ddlFloor.SelectedValue = dtLineFloor_IsClosedDetails.Rows[0]["FloorNo"].ToString();
            //    hdnFloor.Value = dtLineFloor_IsClosedDetails.Rows[0]["FloorNo"].ToString();

            //    txtmanpower.Text = dtLineFloor_IsClosedDetails.Rows[0]["ManPower"].ToString();
            //    hdnmanPower.Value = dtLineFloor_IsClosedDetails.Rows[0]["ManPower"].ToString();
            //}

            if (dtitemval.Rows.Count > 0)
            {
                ddlFloor.SelectedValue = dtitemval.Rows[0]["FloorNo"].ToString();
                hdnFloor.Value = dtitemval.Rows[0]["FloorNo"].ToString();

                txtmanpower.Text = dtitemval.Rows[0]["ManPower"].ToString();
                hdnmanPower.Value = dtitemval.Rows[0]["ManPower"].ToString();
            }
           

            int RowIndex = e.Row.RowIndex;

            DataSet dsIsClosed = new DataSet();

            DataSet dsDesignation = oAdminController.GetDesignationNamecluster();
            DataTable dtDesignation = dsDesignation.Tables[0];

            if (dtDesignation.Rows.Count > 0)
            {
                for (int i = 0; i < dtDesignation.Rows.Count; i++)
                {
                    string colName = dtDesignation.Rows[i]["Name"].ToString();
                    string Id = dtDesignation.Rows[i]["id"].ToString();
                    gvLineStatusCluster.HeaderRow.Cells[i + 5].Text = colName;

                    Label lblName = new Label();
                    lblName.EnableViewState = true;
                    lblName.Enabled = true;
                    lblName.ID = "lblDesigName";
                    lblName.Text = colName;
                    lblName.Width = 125;
                    gvLineStatusCluster.HeaderRow.Style.Add("width", "250px");
                    gvLineStatusCluster.HeaderRow.Style.Add("class", "topMenu2");
                    gvLineStatusCluster.HeaderRow.Style.Add("text-align", "center");
                    gvLineStatusCluster.HeaderRow.Cells[i + 5].Controls.Add(lblName);

                    if (colName != "Is Closed")
                    {
                        DropDownList ddlDesig = new DropDownList();
                        ddlDesig.EnableViewState = true;
                        ddlDesig.Enabled = true;
                        ddlDesig.ID = "ddl_" + Id;
                        ddlDesig.Attributes.Add("class", "DesigName" + RowIndex + "_" + Id + " " + "DesigName" + RowIndex);
                        ddlDesig.Attributes.Add("onchange", "javascript:return SaveFactoryLinecluster(this)");
                        e.Row.Cells[i + 5].Controls.Add(ddlDesig);

                        DropDownList ddlDesigName = (DropDownList)e.Row.FindControl("ddl_" + Id);

                        DataTable dtUsersByDesg = new DataTable();
                        //if (Id == "7")
                        //{
                        // dtDesig = oAdminController.GetFactorynames(Convert.ToInt32(hdnUnitId.Value), Id.ToString());
                        dtUsersByDesg = this.UserControllerInstance.GetUsersByDesignationDataTable(Convert.ToInt32(Id));

                        ddlDesigName.DataSource = dtUsersByDesg;
                        ddlDesigName.DataValueField = "UserID";
                        ddlDesigName.DataTextField = "FLName";
                        ddlDesigName.DataBind();
                        ListItem li = new ListItem();
                        li.Text = "Select";
                        li.Value = "0";
                        ddlDesigName.Items.Insert(0, li);

                        //ddlDesigName.Enabled = ddlDesigName.Items.Count == 1 ? false : true; Gajendra ProductionUnit

                        DataTable dtFactoryLineDesignationDetails = oAdminController.GetFactoryLineDesignationDetailscluster(Convert.ToInt32(hdnUnitId.Value), Convert.ToInt32(lblLine.Text.Replace("Cluster ", "")), Convert.ToInt32(Id));
                        if (dtFactoryLineDesignationDetails.Rows.Count > 0)
                        {
                            ddlDesigName.SelectedValue = dtFactoryLineDesignationDetails.Rows[0]["UserID"].ToString();
                        }
                        if (check == "1")
                        {
                            ddlDesigName.Enabled = true;
                            ddlDesig.Enabled = true;
                        }
                        //}
                        //else if (Id == "6")
                        //{
                        //    dtDesig = oAdminController.GetFactorynames(Convert.ToInt32(hdnUnitId.Value), Id.ToString());
                        //    ddlDesigName.DataSource = dtDesig.Tables[6];// dsFactory.Tables[3];
                        //    ddlDesigName.DataValueField = "Name";
                        //    ddlDesigName.DataTextField = "Name";
                        //    ddlDesigName.DataBind();

                        //    ddlDesigName.Enabled = ddlDesigName.Items.Count == 1 ? false : true;
                        //}
                        //else
                        //{
                        //    dtDesig = oAdminController.GetFactorynames(Convert.ToInt32(hdnUnitId.Value), Id.ToString());
                        //    ddlDesigName.DataSource = dtDesig.Tables[4];// dsFactory.Tables[3];
                        //    ddlDesigName.DataValueField = "Name";
                        //    ddlDesigName.DataTextField = "Name";
                        //    ddlDesigName.DataBind();

                        //    ddlDesigName.Enabled = ddlDesigName.Items.Count == 1 ? false : true;
                        //}
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
                        rbtn.Attributes.Add("onclick", "javascript:return SaveIsClosedcluster(this)");
                        e.Row.Cells[i + 5].Controls.Add(rbtn);

                        rbtn.Items[0].Selected = true;
                        int FloorNo = ddlFloor.SelectedValue == "" ? 0 : Convert.ToInt32(ddlFloor.SelectedValue);
                        bool IsClosed = rbtn.SelectedValue == "Yes" ? true : false;
                        //oAdminController.UpdateFactoryLineStatus(Convert.ToInt32(hdnUnitId.Value), FloorNo, Convert.ToInt32(lblLine.Text.Replace("Line ", "")), IsClosed, ApplicationHelper.LoggedInUser.UserData.UserID);

                        if (dtitemval.Rows.Count > 0)
                        {
                            rbtn.SelectedValue = Convert.ToBoolean(dtitemval.Rows[0]["IsClosed"]) == true ? "Yes" : "No";
                        }
                        rbtn.SelectedValue = Convert.ToBoolean(dtitemval.Rows[0]["IsClosed"]) == true ? "Yes" : "No";

                        if (check == "1")
                        {
                            rbtn.Enabled = false;

                        }

                    }

                }
            }
            oAdminController = null;
            //if (check == "1")
            //{
            //    e.Row.Enabled = false;

            //}
        }
    }
  }
}