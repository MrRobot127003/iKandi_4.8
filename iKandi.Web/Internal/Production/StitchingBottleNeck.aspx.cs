//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using iKandi.BLL;
//using iKandi.BLL.Production;
//using System.Data;
//using iKandi.Common;
//using iKandi.Web.Components;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.BLL;
using System.IO;
using iKandi.BLL.Production;
using System.Collections.Generic;
using System.Web.Services;

namespace iKandi.Web.Internal.Production
{

  public partial class StitchingBottleNeck : System.Web.UI.Page
  {
    int SlotId = -1, StyleId = -1, LineNo = -1, OrderDetailId = -1, LinePlanningId = -1;
    string SerialNo = "";
    string SlotDate;
    public string StyleID_Session
    {
      get;
      set;
    }


    ProductionController objProductionController = new ProductionController();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
            Response.Redirect("~/public/Login.aspx");

      GetQueryString();
      if (!IsPostBack)
      {
        //Session["oprationsession"] = "";
        //Session["StyleIdsession"] = "";
        GetOBSection_ByStyle();
        GetBottleNeck();
      }

    }

    private void GetQueryString()
    {
      if (null != Request.QueryString["SlotId"])
      {
        SlotId = Convert.ToInt32(Request.QueryString["SlotId"]);
      }
      if (null != Request.QueryString["StyleId"])
      {
        StyleId = Convert.ToInt32(Request.QueryString["StyleId"]);
        hdnStyleId.Value = StyleId.ToString();
        StyleID_Session = StyleId.ToString();
      }
      if (null != Request.QueryString["LineNo"])
      {
        LineNo = Convert.ToInt32(Request.QueryString["LineNo"]);
        lblLineNo.Text = "Line " + LineNo.ToString();
      }
      if (null != Request.QueryString["SerialNo"])
      {
        SerialNo = Request.QueryString["SerialNo"].ToString();
        lblSerialNo.Text = SerialNo;
      }
      if (null != Request.QueryString["OrderDetailId"])
      {
        OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);
      }
      if (null != Request.QueryString["LinePlanningId"])
      {
        LinePlanningId = Convert.ToInt32(Request.QueryString["LinePlanningId"]);
      }
      if (null != Request.QueryString["SlotDate"])
      {
        SlotDate = Request.QueryString["SlotDate"].ToString();
      }
    }

    private void GetBottleNeck()
    {
      BottleNeck objBottleNeck = new BottleNeck();
      objBottleNeck.OrderDetailId = OrderDetailId;
      objBottleNeck.LinePlanningId = LinePlanningId;
      if (ViewState["dtBottleNeck"] != null)
      {
        DataTable dtBottleNeck = (DataTable)ViewState["dtBottleNeck"];
        if (dtBottleNeck.Rows.Count > 0)
        {
          grdBottleNeck.DataSource = dtBottleNeck;
          grdBottleNeck.DataBind();
        }
        else
        {
          grdBottleNeck.DataSource = null;
          grdBottleNeck.DataBind();

        }

      }
      else
      {
        DataTable dtBottleNeck = objProductionController.GetStitching_BottleNeck(objBottleNeck);
        if (dtBottleNeck.Rows.Count > 0)
        {
          grdBottleNeck.DataSource = dtBottleNeck;
          grdBottleNeck.DataBind();
          ViewState["dtBottleNeck"] = dtBottleNeck;
        }
        else
        {
          grdBottleNeck.DataSource = null;
          grdBottleNeck.DataBind();
        }
      }
    }
    private void GetOBSection_ByStyle()
    {
      List<BottleNeck> objOB_Section = objProductionController.GetOB_Section_ByStyle(StyleId);
      ViewState["OBSection"] = objOB_Section;
    }
    //private void GetOBOperation_ByStyle()
    //{
    //    List<BottleNeck> objOB_Operation = objProductionController.GetOB_Operation_ByStyle(StyleId);
    //    ViewState["OBOperation"] = objOB_Operation;
    //}
    protected void grdBottleNeck_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.EmptyDataRow)
      {
        DropDownList ddlOBSection_Empty = (DropDownList)e.Row.FindControl("ddlOBSection_Empty");
        DropDownList ddlOBoperation_Empty = (DropDownList)e.Row.FindControl("ddlOBoperation_Empty");
        TextBox txtOBOpration__Empty = (TextBox)e.Row.FindControl("txtOBOpration__Empty");
        if (chkwk.Checked == false)
        {
          ddlOBoperation_Empty.Style.Add("display", "block");
          //ddlOBoperation_Empty.Visible = true;
          txtOBOpration__Empty.Visible = false;
        }
        if (ViewState["OBSection"] != null)
        {
          List<BottleNeck> objOB_Section = (List<BottleNeck>)ViewState["OBSection"];
          if (objOB_Section.Count > 0)
          {
            ddlOBSection_Empty.DataSource = objOB_Section;
            ddlOBSection_Empty.DataTextField = "OBSectionName";
            ddlOBSection_Empty.DataValueField = "OBSectionName";
            ddlOBSection_Empty.DataBind();
            ddlOBSection_Empty.Items.Insert(0, new ListItem("Select", "Select"));
          }
        }

        if (ViewState["OBOperation"] != null)
        {
          List<BottleNeck> objOB_Operation = (List<BottleNeck>)ViewState["OBOperation"];
          if (objOB_Operation.Count > 0)
          {
            ddlOBoperation_Empty.DataSource = objOB_Operation;
            ddlOBoperation_Empty.DataTextField = "FactoryWorkSpace";
            ddlOBoperation_Empty.DataValueField = "FactoryWorkSpace";
            ddlOBoperation_Empty.DataBind();
            ddlOBoperation_Empty.Items.Insert(0, new ListItem("Select", "Select"));
          }
        }

      }
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        DropDownList ddlOBSection = (DropDownList)e.Row.FindControl("ddlOBSection");
        DropDownList ddlOBoperation = (DropDownList)e.Row.FindControl("ddlOBoperation");
        TextBox txtDumpPcs = (TextBox)e.Row.FindControl("txtDumpPcs");
        TextBox txtAgreed = (TextBox)e.Row.FindControl("txtAgreed");
        TextBox txtPerHrPcs = (TextBox)e.Row.FindControl("txtPerHrPcs");
        HiddenField hdnOBSection = (HiddenField)e.Row.FindControl("hdnOBSection");
        HiddenField hdnOBOperation = (HiddenField)e.Row.FindControl("hdnOBOperation");

        string OBSectionName = DataBinder.Eval(e.Row.DataItem, "OBSectionName").ToString();
        string FactoryWorkSpace = DataBinder.Eval(e.Row.DataItem, "FactoryWorkSpace").ToString();
        TextBox txtOBOpration_Item = (TextBox)e.Row.FindControl("txtOBOpration_Item");
        if (chkwk.Checked == false)
        {
          ddlOBoperation.Style.Add("display", "block");
          txtOBOpration_Item.Visible = false;
        }
        if (ViewState["OBSection"] != null)
        {
          List<BottleNeck> objOB_Section = (List<BottleNeck>)ViewState["OBSection"];

          if (objOB_Section.Count > 0)
          {
            ddlOBSection.DataSource = objOB_Section;
            ddlOBSection.DataTextField = "OBSectionName";
            ddlOBSection.DataValueField = "OBSectionName";
            ddlOBSection.DataBind();
            ddlOBSection.Items.Insert(0, new ListItem("Select", "Select"));
          }
          ddlOBSection.SelectedValue = OBSectionName;
          hdnOBSection.Value = OBSectionName;
        }


        List<BottleNeck> objOB_Operation = objProductionController.GetOB_Operation_ByStyle(StyleId, OBSectionName);
        if (objOB_Operation.Count > 0)
        {
          ddlOBoperation.DataSource = objOB_Operation;
          ddlOBoperation.DataTextField = "FactoryWorkSpace";
          ddlOBoperation.DataValueField = "FactoryWorkSpace";
          ddlOBoperation.DataBind();
          //ddlOBoperation.SelectedItem.Value = FactoryWorkSpace;
          //ddlOBoperation.SelectedItem.Text = FactoryWorkSpace;

          ddlOBoperation.Items.Insert(0, new ListItem("Select", "Select"));
          foreach (ListItem items in ddlOBoperation.Items)
          {
            if (string.Equals(FactoryWorkSpace.Trim(), items.Text.Trim(), StringComparison.OrdinalIgnoreCase))
            {
              ddlOBoperation.ClearSelection();
              items.Selected = true;
            }
          }
          hdnOBOperation.Value = FactoryWorkSpace;
        }


        if (txtDumpPcs.Text != "")
          txtDumpPcs.Text = txtDumpPcs.Text == "-1" ? "" : txtDumpPcs.Text;

        if (txtAgreed.Text != "")
          txtAgreed.Text = txtAgreed.Text == "-1" ? "" : txtAgreed.Text;

        if (txtPerHrPcs.Text != "")
          txtPerHrPcs.Text = txtPerHrPcs.Text == "-1" ? "" : txtPerHrPcs.Text;
      }

      if (e.Row.RowType == DataControlRowType.Footer)
      {
        DropDownList ddlOBSection_Footer = (DropDownList)e.Row.FindControl("ddlOBSection_Footer");
        DropDownList ddlOBoperation_Footer = (DropDownList)e.Row.FindControl("ddlOBoperation_Footer");
        TextBox txtOBOpration_Foter = (TextBox)e.Row.FindControl("txtOBOpration_Foter");
        if (chkwk.Checked == false)
        {
          ddlOBoperation_Footer.Style.Add("display", "block");
          txtOBOpration_Foter.Visible = false;
        }
        if (ViewState["OBSection"] != null)
        {
          List<BottleNeck> objOB_Section = (List<BottleNeck>)ViewState["OBSection"];

          if (objOB_Section.Count > 0)
          {
            ddlOBSection_Footer.DataSource = objOB_Section;
            ddlOBSection_Footer.DataTextField = "OBSectionName";
            ddlOBSection_Footer.DataValueField = "OBSectionName";
            ddlOBSection_Footer.DataBind();
            ddlOBSection_Footer.Items.Insert(0, new ListItem("Select", "Select"));
          }
        }

      }
    }

    protected void grdBottleNeck_RowCommand(object sender, GridViewCommandEventArgs e)
    {
      if (e.CommandName == "AddEmpty")
      {
        Table tblGrdviewApplet = (Table)grdBottleNeck.Controls[0];
        GridViewRow rows = (GridViewRow)tblGrdviewApplet.Controls[0];

        DropDownList ddlOBSection_Empty = (DropDownList)rows.FindControl("ddlOBSection_Empty");
        DropDownList ddlOBoperation_Empty = (DropDownList)rows.FindControl("ddlOBoperation_Empty");
        CheckBox chkBottleneck_Empty = (CheckBox)rows.FindControl("chkBottleneck_Empty");
        TextBox txtDumpPcs_Empty = (TextBox)rows.FindControl("txtDumpPcs_Empty");
        TextBox txtAgreed_Empty = (TextBox)rows.FindControl("txtAgreed_Empty");
        TextBox txtPerHrPcs_Empty = (TextBox)rows.FindControl("txtPerHrPcs_Empty");
        TextBox txtOBOpration__Empty = (TextBox)rows.FindControl("txtOBOpration__Empty");

        BottleNeck objBottleNeck = new BottleNeck();
        objBottleNeck.OBSectionName = ddlOBSection_Empty.SelectedValue;
        if (chkwk.Checked == false)
        {
          objBottleNeck.FactoryWorkSpace = ddlOBoperation_Empty.SelectedValue;
        }
        else
        {
          objBottleNeck.FactoryWorkSpace = txtOBOpration__Empty.Text.Trim();

        }
        //abhishek
        if (ddlOBSection_Empty.SelectedValue == "Select")
        {
          ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please select OB Section!');", true);
          return;
        }

        if (chkwk.Checked == false)
        {
          if (ddlOBoperation_Empty.SelectedValue == "Select")
          {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please select OB Operation!');", true);
            return;
          }
        }
        else
        {
          if (string.IsNullOrEmpty(txtOBOpration__Empty.Text.Trim()))
          {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please select OB Operation!');", true);
            return;
          }
        }
        if (txtAgreed_Empty.Text == "")
        {
          ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please Add Tgt. Agrd. Qty!');", true);
          return;
        }
        if (chkBottleneck_Empty.Checked == false)
        {
          ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please check bottle neck!');", true);
          chkBottleneck_Empty.Focus();
          chkBottleneck_Empty.CssClass = "BackgroundColor";
          return;
        }
        //end
        //objBottleNeck.FactoryWorkSpace = ddlOBoperation_Empty.SelectedValue;
        objBottleNeck.IsBottleNeck = chkBottleneck_Empty.Checked;
        objBottleNeck.DumpPcs = txtDumpPcs_Empty.Text == "" ? -1 : Convert.ToInt32(txtDumpPcs_Empty.Text);
        objBottleNeck.TgtAgrdQuantity = txtAgreed_Empty.Text == "" ? -1 : Convert.ToInt32(txtAgreed_Empty.Text);
        objBottleNeck.PerHrPcs = txtPerHrPcs_Empty.Text == "" ? -1 : Convert.ToInt32(txtPerHrPcs_Empty.Text);

        DataTable dtBottleNeck = new DataTable();
        dtBottleNeck.Columns.Add("BottleNeckId", typeof(System.Int32));
        dtBottleNeck.Columns.Add("OBSectionName", typeof(System.String));
        dtBottleNeck.Columns.Add("FactoryWorkSpace", typeof(System.String));
        dtBottleNeck.Columns.Add("IsBottleNeck", typeof(System.Boolean));
        dtBottleNeck.Columns.Add("DumpPcs", typeof(System.Int32));
        dtBottleNeck.Columns.Add("TgtAgrdQuantity", typeof(System.Int32));
        dtBottleNeck.Columns.Add("PerHrPcs", typeof(System.Int32));

        DataRow dr = dtBottleNeck.NewRow();
        dr["BottleNeckId"] = 0;
        dr["OBSectionName"] = objBottleNeck.OBSectionName;
        dr["FactoryWorkSpace"] = objBottleNeck.FactoryWorkSpace;
        dr["IsBottleNeck"] = objBottleNeck.IsBottleNeck;
        dr["DumpPcs"] = objBottleNeck.DumpPcs;
        dr["TgtAgrdQuantity"] = objBottleNeck.TgtAgrdQuantity;
        dr["PerHrPcs"] = objBottleNeck.PerHrPcs;

        dtBottleNeck.Rows.Add(dr);
        ViewState["dtBottleNeck"] = dtBottleNeck;
        GetBottleNeck();

      }

      if (e.CommandName == "AddFooter")
      {

        DropDownList ddlOBSection_Footer = (DropDownList)grdBottleNeck.FooterRow.FindControl("ddlOBSection_Footer");
        DropDownList ddlOBoperation_Footer = (DropDownList)grdBottleNeck.FooterRow.FindControl("ddlOBoperation_Footer");
        CheckBox chkBottleneck_Footer = (CheckBox)grdBottleNeck.FooterRow.FindControl("chkBottleneck_Footer");
        TextBox txtDumpPcs_Footer = (TextBox)grdBottleNeck.FooterRow.FindControl("txtDumpPcs_Footer");
        TextBox txtAgreed_Footer = (TextBox)grdBottleNeck.FooterRow.FindControl("txtAgreed_Footer");
        TextBox txtPerHrPcs_Footer = (TextBox)grdBottleNeck.FooterRow.FindControl("txtPerHrPcs_Footer");
        TextBox txtOBOpration_Foter = (TextBox)grdBottleNeck.FooterRow.FindControl("txtOBOpration_Foter");

        BottleNeck objBottleNeck = new BottleNeck();
        objBottleNeck.OBSectionName = ddlOBSection_Footer.SelectedValue;
        if (chkwk.Checked == false)
        {
          objBottleNeck.FactoryWorkSpace = ddlOBoperation_Footer.SelectedValue;
        }
        else
        {
          objBottleNeck.FactoryWorkSpace = txtOBOpration_Foter.Text.Trim();
        }
        objBottleNeck.IsBottleNeck = chkBottleneck_Footer.Checked;
        objBottleNeck.DumpPcs = txtDumpPcs_Footer.Text == "" ? -1 : Convert.ToInt32(txtDumpPcs_Footer.Text);
        objBottleNeck.TgtAgrdQuantity = txtAgreed_Footer.Text == "" ? -1 : Convert.ToInt32(txtAgreed_Footer.Text);
        objBottleNeck.PerHrPcs = txtPerHrPcs_Footer.Text == "" ? -1 : Convert.ToInt32(txtPerHrPcs_Footer.Text);
        //abhishek
        if (ddlOBSection_Footer.SelectedValue == "Select")
        {
          // ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please select OB Section!');", true);
          ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "ErrorAlert('" + "Please select OB Section" + "');", true);
          return;
        }

        if (chkwk.Checked == false)
        {
          if (ddlOBoperation_Footer.SelectedValue == "Select")
          {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please select OB Operation!');", true);
            return;
          }
        }
        else
        {
          if (string.IsNullOrEmpty(txtOBOpration_Foter.Text.Trim()))
          {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please select OB Operation!');", true);
            return;
          }
        }
        if (txtAgreed_Footer.Text == "")
        {
          ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please Add Tgt. Agrd. Qty!');", true);
          return;
        }
        if (chkBottleneck_Footer.Checked == false)
        {
          ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please check bottle neck!');", true);
          chkBottleneck_Footer.Focus();
          chkBottleneck_Footer.CssClass = "BackgroundColor";
          return;
        }
        //end
        if (ViewState["dtBottleNeck"] != null)
        {
          DataTable dtBottleNeckFooter = (DataTable)ViewState["dtBottleNeck"];
          for (int irow = 0; irow < grdBottleNeck.Rows.Count; irow++)
          {
            HiddenField hdnBottleNeckId = (HiddenField)grdBottleNeck.Rows[irow].FindControl("hdnBottleNeckId");
            dtBottleNeckFooter.Rows[irow]["BottleNeckId"] = hdnBottleNeckId.Value;

            DropDownList ddlOBSection = (DropDownList)grdBottleNeck.Rows[irow].FindControl("ddlOBSection");
            if (ddlOBSection.SelectedValue != "Select")
            {
              dtBottleNeckFooter.Rows[irow]["OBSectionName"] = ddlOBSection.SelectedValue;
            }

            DropDownList ddlOBoperation = (DropDownList)grdBottleNeck.Rows[irow].FindControl("ddlOBoperation");
            TextBox txtOBOpration_Item = (TextBox)grdBottleNeck.Rows[irow].FindControl("txtOBOpration_Item");

            if (chkwk.Checked == false)
            {
              if (ddlOBoperation.SelectedValue != "Select")
              {
                dtBottleNeckFooter.Rows[irow]["FactoryWorkSpace"] = ddlOBoperation.SelectedValue;
              }
            }
            else
            {
              if (txtOBOpration_Item.Text.Trim() != "")
              {
                dtBottleNeckFooter.Rows[irow]["FactoryWorkSpace"] = txtOBOpration_Item.Text.Trim();
              }
            }
            CheckBox chkBottleneck = (CheckBox)grdBottleNeck.Rows[irow].FindControl("chkBottleneck");
            dtBottleNeckFooter.Rows[irow]["IsBottleNeck"] = chkBottleneck.Checked;

            TextBox txtDumpPcs = (TextBox)grdBottleNeck.Rows[irow].FindControl("txtDumpPcs");
            dtBottleNeckFooter.Rows[irow]["DumpPcs"] = txtDumpPcs.Text == "" ? -1 : Convert.ToInt32(txtDumpPcs.Text);

            TextBox txtAgreed = (TextBox)grdBottleNeck.Rows[irow].FindControl("txtAgreed");
            dtBottleNeckFooter.Rows[irow]["TgtAgrdQuantity"] = txtAgreed.Text == "" ? -1 : Convert.ToInt32(txtAgreed.Text);

            TextBox txtPerHrPcs = (TextBox)grdBottleNeck.Rows[irow].FindControl("txtPerHrPcs");
            dtBottleNeckFooter.Rows[irow]["PerHrPcs"] = txtPerHrPcs.Text == "" ? -1 : Convert.ToInt32(txtPerHrPcs.Text);

            dtBottleNeckFooter.AcceptChanges();

          }

          DataRow dr = dtBottleNeckFooter.NewRow();
          dr["BottleNeckId"] = 0;
          dr["OBSectionName"] = objBottleNeck.OBSectionName;
          dr["FactoryWorkSpace"] = objBottleNeck.FactoryWorkSpace;
          dr["IsBottleNeck"] = objBottleNeck.IsBottleNeck;
          dr["DumpPcs"] = objBottleNeck.DumpPcs;
          dr["TgtAgrdQuantity"] = objBottleNeck.TgtAgrdQuantity;
          dr["PerHrPcs"] = objBottleNeck.PerHrPcs;

          dtBottleNeckFooter.Rows.Add(dr);
          ViewState["dtBottleNeck"] = dtBottleNeckFooter;
          GetBottleNeck();

        }

      }
    }

    protected void grdBottleNeck_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      GridViewRow row = grdBottleNeck.Rows[e.RowIndex];

      DropDownList ddlOBSection = (DropDownList)row.FindControl("ddlOBSection");
      DropDownList ddlOBOperation = (DropDownList)row.FindControl("ddlOBOperation");
      HiddenField hdnBottleNeckId = (HiddenField)row.FindControl("hdnBottleNeckId");

      BottleNeck objBottleNeck = new BottleNeck();

      if ((ddlOBSection.SelectedValue != "Select") && (ddlOBOperation.SelectedValue != "Select"))
      {
        objBottleNeck.BottleNeckId = Convert.ToInt32(hdnBottleNeckId.Value);


        objBottleNeck.OBSectionName = ddlOBSection.SelectedValue.Trim();
        objBottleNeck.FactoryWorkSpace = ddlOBOperation.SelectedValue.Trim();

        if (ViewState["dtBottleNeck"] != null)
        {
          DataTable dtBottleNeck = (DataTable)ViewState["dtBottleNeck"];
          if (dtBottleNeck.Rows.Count > 0)
          {
            for (int i = dtBottleNeck.Rows.Count - 1; i >= 0; i--)
            {
              DataRow dr = dtBottleNeck.Rows[i];
              if ((dr["OBSectionName"].ToString().Trim() == objBottleNeck.OBSectionName) && (dr["FactoryWorkSpace"].ToString().Trim() == objBottleNeck.FactoryWorkSpace))
              {
                dr.Delete();
                int iDelete = objProductionController.Delete_BottleNeck(objBottleNeck);
                dtBottleNeck.AcceptChanges();
              }
            }
          }
          ViewState["dtQCFault"] = dtBottleNeck;
          GetBottleNeck();
        }
      }
    }

    protected void ddlOBSection_Empty_SelectedIndexChanged(Object sender, EventArgs e)
    {
      string OBSection = ((DropDownList)sender).SelectedValue;
      DropDownList ddlOBoperation_Empty = (DropDownList)grdBottleNeck.Controls[0].Controls[0].FindControl("ddlOBoperation_Empty");
      TextBox txtOBOpration__Empty = (TextBox)grdBottleNeck.Controls[0].Controls[0].FindControl("txtOBOpration__Empty");
      if (chkwk.Checked == false)
      {
        if (OBSection != "Select")
        {
          List<BottleNeck> objOB_Operation = objProductionController.GetOB_Operation_ByStyle(StyleId, OBSection);
          if (objOB_Operation.Count > 0)
          {
            ddlOBoperation_Empty.DataSource = objOB_Operation;
            ddlOBoperation_Empty.DataTextField = "FactoryWorkSpace";
            ddlOBoperation_Empty.DataValueField = "FactoryWorkSpace";
            ddlOBoperation_Empty.DataBind();
            ddlOBoperation_Empty.Items.Insert(0, new ListItem("Select", "Select"));
          }
        }
        else
        {
          ddlOBoperation_Empty.Items.Clear();
          ddlOBoperation_Empty.Items.Insert(0, new ListItem("Select", "Select"));
        }
      }
      else
      {
        txtOBOpration__Empty.Text = "";
      }
    }

    protected void ddlOBSection_Footer_SelectedIndexChanged(Object sender, EventArgs e)
    {
      string OBSection = ((DropDownList)sender).SelectedValue;
      List<BottleNeck> objOB_Operation = objProductionController.GetOB_Operation_ByStyle(StyleId, OBSection);
      Control FooterRow = null;
      FooterRow = grdBottleNeck.FooterRow;
      DropDownList ddlOBoperation_Footer = (DropDownList)grdBottleNeck.FooterRow.FindControl("ddlOBoperation_Footer");
      TextBox txtOBOpration_Foter = (TextBox)grdBottleNeck.FooterRow.FindControl("txtOBOpration_Foter");
      if (chkwk.Checked == false)
      {
        if (OBSection != "Select")
        {
          if (objOB_Operation.Count > 0)
          {
            ddlOBoperation_Footer.DataSource = objOB_Operation;
            ddlOBoperation_Footer.DataTextField = "FactoryWorkSpace";
            ddlOBoperation_Footer.DataValueField = "FactoryWorkSpace";
            ddlOBoperation_Footer.DataBind();
            ddlOBoperation_Footer.Items.Insert(0, new ListItem("Select", "Select"));
          }
        }
        else
        {
          ddlOBoperation_Footer.Items.Clear();
          ddlOBoperation_Footer.Items.Insert(0, new ListItem("Select", "Select"));
        }
      }
      else
      {
        txtOBOpration_Foter.Text = "";
      }
    }

    protected void ddlOBSection_SelectedIndexChanged(Object sender, EventArgs e)
    {
      DropDownList ddlOBSection = (DropDownList)sender;
      GridViewRow row = (GridViewRow)ddlOBSection.NamingContainer;
      string OBSection = ((DropDownList)sender).SelectedValue;

      List<BottleNeck> objOB_Operation = objProductionController.GetOB_Operation_ByStyle(StyleId, OBSection);

      DropDownList ddlOBOperation = (DropDownList)row.FindControl("ddlOBOperation");
      HiddenField hdnOBSection = (HiddenField)row.FindControl("hdnOBSection");
      TextBox txtOBOpration_Item = (TextBox)row.FindControl("txtOBOpration_Item");

      hdnOBSection.Value = OBSection;
      if (chkwk.Checked == false)
      {
        if (OBSection != "Select")
        {
          if (objOB_Operation.Count > 0)
          {

            ddlOBOperation.DataSource = objOB_Operation;
            ddlOBOperation.DataTextField = "FactoryWorkSpace";
            ddlOBOperation.DataValueField = "FactoryWorkSpace";
            ddlOBOperation.DataBind();
            ddlOBOperation.Items.Insert(0, new ListItem("Select", "Select"));
          }
        }
        else
        {
          ddlOBOperation.Items.Clear();
          ddlOBOperation.Items.Insert(0, new ListItem("Select", "Select"));
        }
      }
      else
      {
        txtOBOpration_Item.Text = "";
      }
    }
    protected void btnsetval_Click(object sender, EventArgs e)
    {
      //int styleid = 0;
      //string SectionName = "";
      //if (Application["StyleIdsession"] != null)
      //{
      //  styleid = Convert.ToInt32(Application["StyleIdsession"].ToString());
      //}
      //if (Application["oprationsession"] != null)
      //{
      //  SectionName = Application["oprationsession"].ToString();
      //}
      //Constants.StyleID = hdnStyleiDss.Value;
      //Constants.SectionName = hdnSectionName.Value;

    }

    [WebMethod]
    public static void setsession(string ON, string styleid)
    {
      System.Web.HttpContext.Current.Application["oprationsession"] = ON;
      System.Web.HttpContext.Current.Application["StyleIdsession"] = styleid;
    }
    //[WebMethod]
    //public static void ValidateWorkForceName(string ON, string styleid)
    //{
    //  System.Web.HttpContext.Current.Application["oprationsession"] = ON;
    //  System.Web.HttpContext.Current.Application["StyleIdsession"] = styleid;
    //}
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      if (chkwk.Checked)
      {
        bool result;
        ValidateduplicateRecird(out result);
        if (result == false)
        {
          return;
        }
      }
      int iSave = 0;
      if (grdBottleNeck.Rows.Count > 0)
      {
        foreach (GridViewRow gvr in grdBottleNeck.Rows)
        {
          HiddenField hdnBottleNeckId = (HiddenField)gvr.FindControl("hdnBottleNeckId");
          DropDownList ddlOBSection = (DropDownList)gvr.FindControl("ddlOBSection");
          DropDownList ddlOBoperation = (DropDownList)gvr.FindControl("ddlOBoperation");
          CheckBox chkBottleneck = (CheckBox)gvr.FindControl("chkBottleneck");
          TextBox txtDumpPcs = (TextBox)gvr.FindControl("txtDumpPcs");
          TextBox txtAgreed = (TextBox)gvr.FindControl("txtAgreed");
          TextBox txtPerHrPcs = (TextBox)gvr.FindControl("txtPerHrPcs");
          TextBox txtOBOpration_Item = (TextBox)gvr.FindControl("txtOBOpration_Item");

          if (ddlOBSection.SelectedValue == "Select")
          {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please select OB Section!');", true);
            return;
          }
          if (chkwk.Checked == false)
          {
            if (ddlOBoperation.SelectedValue == "Select")
            {
              ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please select OB Operation!');", true);
              return;
            }
          }
          else
          {
            if (string.IsNullOrEmpty(txtOBOpration_Item.Text))
            {
              ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please select OB Operation!');", true);
              return;
            }
          }
          if (txtAgreed.Text == "")
          {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please Add Tgt. Agrd. Qty!');", true);
            return;
          }
          if (chkBottleneck.Checked == false)
          {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please check bottle neck!');", true);
            chkBottleneck.Focus();
            chkBottleneck.CssClass = "BackgroundColor";
            return;
          }
          BottleNeck objBottleNeck = new BottleNeck();
          objBottleNeck.BottleNeckId = Convert.ToInt32(hdnBottleNeckId.Value == "0" ? 1 : Convert.ToInt32(hdnBottleNeckId.Value));
          objBottleNeck.OBSectionName = ddlOBSection.SelectedValue;
          if (chkwk.Checked == true)
            objBottleNeck.FactoryWorkSpace = txtOBOpration_Item.Text.Trim();
          else
            objBottleNeck.FactoryWorkSpace = ddlOBoperation.SelectedValue;

          objBottleNeck.IsBottleNeck = chkBottleneck.Checked;
          objBottleNeck.DumpPcs = txtDumpPcs.Text == "" ? -1 : Convert.ToInt32(txtDumpPcs.Text);
          objBottleNeck.TgtAgrdQuantity = txtAgreed.Text == "" ? -1 : Convert.ToInt32(txtAgreed.Text);
          objBottleNeck.PerHrPcs = txtPerHrPcs.Text == "" ? -1 : Convert.ToInt32(txtPerHrPcs.Text);

          objBottleNeck.SlotId = SlotId;
          objBottleNeck.OrderDetailId = OrderDetailId;
          objBottleNeck.LinePlanningId = LinePlanningId;

          int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
          iSave = objProductionController.SaveStitching_BottleNeck(objBottleNeck, SlotDate, UserId);
        }

        Control FooterRow = null;
        if (grdBottleNeck.FooterRow != null)
        {
          FooterRow = grdBottleNeck.FooterRow;

          DropDownList ddlOBSection_Footer = (DropDownList)grdBottleNeck.FooterRow.FindControl("ddlOBSection_Footer");
          DropDownList ddlOBoperation_Footer = (DropDownList)grdBottleNeck.FooterRow.FindControl("ddlOBoperation_Footer");
          CheckBox chkBottleneck_Footer = (CheckBox)grdBottleNeck.FooterRow.FindControl("chkBottleneck_Footer");
          TextBox txtDumpPcs_Footer = (TextBox)grdBottleNeck.FooterRow.FindControl("txtDumpPcs_Footer");
          TextBox txtAgreed_Footer = (TextBox)grdBottleNeck.FooterRow.FindControl("txtAgreed_Footer");
          TextBox txtPerHrPcs_Footer = (TextBox)grdBottleNeck.FooterRow.FindControl("txtPerHrPcs_Footer");
          TextBox txtOBOpration_Foter = (TextBox)grdBottleNeck.FooterRow.FindControl("txtOBOpration_Foter");
          if (ddlOBSection_Footer.SelectedValue != "Select")
          {
            if (ddlOBSection_Footer.SelectedValue == "Select")
            {
              ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Please select OB Section!');", true);
              //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "popupScript", "javascript:alert('Please select OB Section!');", true);
              return;
            }

            if (chkwk.Checked == false)
            {
              if (ddlOBoperation_Footer.SelectedValue == "Select")
              {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Please select OB Operation!');", true);
                //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "popupScript", "javascript:alert('Please select OB Operation!');", true);
                return;
              }
            }
            else
            {
              if (string.IsNullOrEmpty(txtOBOpration_Foter.Text))
              {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Please select OB Operation!');", true);
                //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "popupScript", "javascript:alert('Please select OB Operation');", true);
                return;
              }
            }
            if (txtAgreed_Footer.Text == "")
            {
              ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Please Add Tgt. Agrd. Qty!');", true);
              //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "popupScript", "javascript:alert('Please Add Tgr. Agrd. Qty');", true);
              return;
            }
            if (chkBottleneck_Footer.Checked == false)
            {
              ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please check bottle neck!');", true);
              chkBottleneck_Footer.Focus();
              chkBottleneck_Footer.CssClass = "BackgroundColor";
              return;
            }
            BottleNeck objBottleNeck = new BottleNeck();
            objBottleNeck.BottleNeckId = 1;
            objBottleNeck.OBSectionName = ddlOBSection_Footer.SelectedValue;
            if (chkwk.Checked == true)
              objBottleNeck.FactoryWorkSpace = txtOBOpration_Foter.Text.Trim();
            else
              objBottleNeck.FactoryWorkSpace = ddlOBoperation_Footer.SelectedValue;

            objBottleNeck.IsBottleNeck = chkBottleneck_Footer.Checked;
            objBottleNeck.DumpPcs = txtDumpPcs_Footer.Text == "" ? -1 : Convert.ToInt32(txtDumpPcs_Footer.Text);
            objBottleNeck.TgtAgrdQuantity = txtAgreed_Footer.Text == "" ? -1 : Convert.ToInt32(txtAgreed_Footer.Text);
            objBottleNeck.PerHrPcs = txtPerHrPcs_Footer.Text == "" ? -1 : Convert.ToInt32(txtPerHrPcs_Footer.Text);

            objBottleNeck.SlotId = SlotId;
            objBottleNeck.OrderDetailId = OrderDetailId;
            objBottleNeck.LinePlanningId = LinePlanningId;

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

            iSave = objProductionController.SaveStitching_BottleNeck(objBottleNeck, SlotDate, UserId);
          }

          if (iSave > 0)
          {
            //Response.Redirect(Request.RawUrl, true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:SavedSuccessfully();", true);
          }
        }
      }
      else
      {
        DropDownList ddlOBSection_Empty = (DropDownList)grdBottleNeck.Controls[0].Controls[0].FindControl("ddlOBSection_Empty");
        DropDownList ddlOBoperation_Empty = (DropDownList)grdBottleNeck.Controls[0].Controls[0].FindControl("ddlOBoperation_Empty");
        CheckBox chkBottleneck_Empty = (CheckBox)grdBottleNeck.Controls[0].Controls[0].FindControl("chkBottleneck_Empty");
        TextBox txtDumpPcs_Empty = (TextBox)grdBottleNeck.Controls[0].Controls[0].FindControl("txtDumpPcs_Empty");
        TextBox txtAgreed_Empty = (TextBox)grdBottleNeck.Controls[0].Controls[0].FindControl("txtAgreed_Empty");
        TextBox txtPerHrPcs_Empty = (TextBox)grdBottleNeck.Controls[0].Controls[0].FindControl("txtPerHrPcs_Empty");
        TextBox txtOBOpration__Empty = (TextBox)grdBottleNeck.Controls[0].Controls[0].FindControl("txtOBOpration__Empty");

       
          if (ddlOBSection_Empty.SelectedValue == "Select")
          {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Please select OB Section!');", true);
            return;
          }

          if (chkwk.Checked == false)
          {
            if (ddlOBoperation_Empty.SelectedValue == "Select")
            {
              ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Please select OB Operation!');", true);
              return;
            }
          }
          else
          {
            if (string.IsNullOrEmpty(txtOBOpration__Empty.Text))
            {
              ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Please select OB Operation!');", true);
              txtOBOpration__Empty.Focus();
              txtOBOpration__Empty.CssClass = "BackgroundColor";
              return;
            }
          }
          if (chkBottleneck_Empty.Checked == false)
          {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:alert('Please check bottle neck!');", true);
            chkBottleneck_Empty.Focus();
            chkBottleneck_Empty.CssClass = "BackgroundColor";
            return;
          }
          if (txtAgreed_Empty.Text == "")
          {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowStatus", "javascript:alert('Please Add Tgt. Agrd. Qty!');", true);
            txtAgreed_Empty.Focus();
            txtAgreed_Empty.CssClass = "BackgroundColor";
            return;
          }
          BottleNeck objBottleNeck = new BottleNeck();
          objBottleNeck.BottleNeckId = 1;
          objBottleNeck.OBSectionName = ddlOBSection_Empty.SelectedValue;
          if (chkwk.Checked == true)
          {
            objBottleNeck.FactoryWorkSpace = txtOBOpration__Empty.Text.Trim();
          }
          else
          {
            objBottleNeck.FactoryWorkSpace = ddlOBoperation_Empty.SelectedValue;
          }
          objBottleNeck.IsBottleNeck = chkBottleneck_Empty.Checked;
          objBottleNeck.DumpPcs = txtDumpPcs_Empty.Text == "" ? -1 : Convert.ToInt32(txtDumpPcs_Empty.Text);
          objBottleNeck.TgtAgrdQuantity = txtAgreed_Empty.Text == "" ? -1 : Convert.ToInt32(txtAgreed_Empty.Text);
          objBottleNeck.PerHrPcs = txtPerHrPcs_Empty.Text == "" ? -1 : Convert.ToInt32(txtPerHrPcs_Empty.Text);

          objBottleNeck.SlotId = SlotId;
          objBottleNeck.OrderDetailId = OrderDetailId;
          objBottleNeck.LinePlanningId = LinePlanningId;

          int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

          iSave = objProductionController.SaveStitching_BottleNeck(objBottleNeck, SlotDate, UserId);

          if (iSave > 0)
          {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popupScript", "javascript:SavedSuccessfully();", true);
          }
        
      }
    }

    protected void chkwk_CheckedChanged(object sender, EventArgs e)
    {
      GetBottleNeck();
    }
    public void ValidateduplicateRecird(out bool IsValid)
    {
      IsValid = true;
      int Count = 0;
      foreach (GridViewRow row in grdBottleNeck.Rows)
      {
        string OBOpration = "";
        TextBox txtOBOpration_Item = (TextBox)row.FindControl("txtOBOpration_Item");
        DropDownList ddlOBSection = (DropDownList)row.FindControl("ddlOBSection");
        OBOpration = ddlOBSection.SelectedValue + txtOBOpration_Item.Text.Trim();
        if (txtOBOpration_Item != null)
        {
          Count = 0;
          if (txtOBOpration_Item.Text != "")
          {
            foreach (GridViewRow rows in grdBottleNeck.Rows)
            {
              string OBOpration_nextrow = "";
              TextBox txtFaultname_nextrow = (TextBox)rows.FindControl("txtOBOpration_Item");
              DropDownList ddlOBSection_nextrow = (DropDownList)row.FindControl("ddlOBSection");
              OBOpration_nextrow = ddlOBSection_nextrow.SelectedValue + txtFaultname_nextrow.Text.Trim();
              if (txtFaultname_nextrow != null)
              {
                if (txtFaultname_nextrow.Text != "")
                {
                  if (OBOpration.ToLower() == OBOpration_nextrow.ToLower())
                  {
                    Count += 1;

                    if (Count > 1)
                    {
                      txtFaultname_nextrow.BorderColor = System.Drawing.Color.Red;
                      txtFaultname_nextrow.BorderWidth = 1;
                      ShowAlert("Duplicate Operation name found " + ddlOBSection_nextrow.SelectedValue + " " + txtFaultname_nextrow.Text.Trim());
                      IsValid = false;
                      return;
                    }
                  }
                }
              }
            }

          }
        }
      }
    }
    public void ShowAlert(string stringAlertMsg)
    {
      string myStringVariable = string.Empty;
      myStringVariable = stringAlertMsg;
      ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
    }


  }
}