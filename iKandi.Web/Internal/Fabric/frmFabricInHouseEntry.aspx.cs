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
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace iKandi.Web.Internal.Fabric
{
  public partial class frmFabricInHouseEntry : System.Web.UI.Page
  {
    public static int FabricType
    {
      get;
      set;
    }
    public static int RequiredQty
    {
      get;
      set;
    }
    public  int OrderDetailID
    {
      get;
      set;
    }
    public static int UserId
    {
      get;
      set;
    }
    public static int InHouseEnteredEntryQty
    {
      get;
      set;
    }
    public static string IsPageSubmit
    {
      get;
      set;
    }
    public static string IsSub
    {
      get;
      set;
    }
    AdminController oAdminController = new AdminController();
    OrderController od = new OrderController();
    bool Ishsipeed = false;
    bool IsCutting = false;
    protected void Page_Load(object sender, EventArgs e)
    {
      GetQueryString();
      if (OrderDetailID==0)
      {
        OrderDetailID=  Convert.ToInt32(hdnorderdeta.Value);
        
      }
      
        if (Session["ErrorSession"] != null)
        {
          //ShowAlert(Session["ErrorSession"].ToString());
          ScriptManager.RegisterStartupScript(this, GetType(), "displayalertmessage", "Showalert();", true);        
          Session["ErrorSession"] = null;
        }
      if (Session["Issub"] != null)
      {
        if (Session["Issub"].ToString() == "YES")
        {
          Session["Issub"] = null;
          PlaceHolder1.Visible = true;
          divfb.Visible = false;
          if (Session["SelectedDate"] != null)
          {
            BindFabrRshuffle(Convert.ToDateTime(Session["SelectedDate"].ToString()));
            Session["SelectedDate"] = null;
          }
        }
      }
     
      if (!IsPostBack)
      {
        
        GetQueryString();
        GetFabReqQty();
        Bindgrd();
        SetInitialRow();
        Ishsipeed = od.CheckShippedOrder(OrderDetailID);
        IsCutting = od.CheckCutting_QtyAbove90_Percent(OrderDetailID);
          
        if (Ishsipeed == true)
        {
            btnSubmit.Visible = false;
            btnRecreate.Visible = false;
        }
        else
        {
            btnSubmit.Visible = true;
            if (IsCutting==true)
                btnRecreate.Visible = false;
            else
                btnRecreate.Visible = true;
        }

      
      }
      IsComplete = 0;
     
    }
    public void GetQueryString()
    {
      // UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

      if (Request.QueryString["FabricType"] != null)
      {
        FabricType = Convert.ToInt32(Request.QueryString["FabricType"]);
      }
      //if (Request.QueryString["RequiredQty"] != null)
      //{
      //  RequiredQty = Convert.ToInt32(Request.QueryString["RequiredQty"].ToString().Replace("," , ""));
      //}
      if (Request.QueryString["OrderDetailID"] != null)
      {
        OrderDetailID = Convert.ToInt32(Request.QueryString["OrderDetailID"]);
        hdnorderdeta.Value = Request.QueryString["OrderDetailID"];
       
      }

    }
    public void ShowAlert(string stringAlertMsg)
    {
      string myStringVariable = string.Empty;
      myStringVariable = stringAlertMsg;
      ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
    }
    public void GetFabReqQty()
    {
      DataTable dt = oAdminController.GetFabricInHouseQtyDetails(OrderDetailID, FabricType);
      if (dt.Rows.Count > 0)
      {
        RequiredQty = Convert.ToInt32(dt.Rows[0]["FabReqiredQty"].ToString().Replace(",", ""));
      }
      else
      {
        RequiredQty = 0;
      }
      lblReuired.Text = RequiredQty.ToString("N0");

    }
    public void BindFabPlannedQty()
    {
      if (RequiredQty > 0)
      {
        decimal Reqqty = Math.Round(Convert.ToDecimal(RequiredQty) / 1000, 1, MidpointRounding.AwayFromZero);
        lblinhouse_ReqQty.Text = Reqqty + "k";
        lblinhouse_ReqQty.ToolTip = RequiredQty.ToString("N0");
      }
    }
    public void Bindgrd()
    {
      DataTable dt = oAdminController.GetFabricInHouseQty(OrderDetailID, FabricType);
      UpdateENDEta(dt);
      var value = "";
      var PendingQty = "";
      if (dt.Rows.Count > 0)
      {
        foreach (DataRow row in dt.Rows)
        {
          if (row["EntryInHoseDates"].ToString() == "Total")
          {
            value = row["InHouseQty"].ToString();
          }
        }
        foreach (DataRow row in dt.Rows)
        {
          if (row["EntryInHoseDates"].ToString() == "Pending Required")
          {
            PendingQty = row["InHouseQty"].ToString();
          }
        }
        value = (value == "" ? "0" : value); PendingQty = (PendingQty == "" ? lblReuired.Text.Replace(",", "") : PendingQty);
        decimal InHouseqty = Math.Round(Convert.ToDecimal(value) / 1000, 1, MidpointRounding.AwayFromZero);
        decimal PendingQtyFab = Math.Round(Convert.ToDecimal(PendingQty) / 1000, 1, MidpointRounding.AwayFromZero);
        lblinhouse_FabInHouseTotalQty.Text = InHouseqty + "k";
        if (Convert.ToDecimal(value) > 0)
          lblinhouse_FabInHouseTotalQty.ToolTip = Convert.ToInt32(value).ToString("N0");

        lblinhouse_FabInHouseTotalQty.Text = (lblinhouse_FabInHouseTotalQty.Text == "0k" ? "" : (Convert.ToDecimal(lblinhouse_FabInHouseTotalQty.Text.Trim().Replace("k", "")).ToString("0.##") + "k"));
        //if (Convert.ToDecimal(PendingQty) > 0)
        // lblinhouse_Pending.ToolTip = Convert.ToInt32(PendingQty).ToString("N0");       
        lblinhouse_Pending.ToolTip = Convert.ToInt32(PendingQty.Replace(",", "")).ToString("N0");

        lblinhouse_Pending.Text = PendingQtyFab + "k";
        lblinhouse_Pending.Text = (lblinhouse_Pending.Text == "0k" ? "" : (Convert.ToDecimal(lblinhouse_Pending.Text.Trim().Replace("k", "")).ToString("0.##") + "k"));
        grdFabricInhouse.DataSource = dt;
        grdFabricInhouse.DataBind();
        BindFabPlannedQty();

        foreach (GridViewRow row in grdFabricInhouse.Rows)
        {
          Label lblEntryDate = (Label)row.FindControl("lblEntryDate");
          Label lblInHouse = (Label)row.FindControl("lblInHouse");
          if (!string.IsNullOrEmpty(lblEntryDate.Text))
          {
            if (lblEntryDate.Text == "Total")
            {
              lbloverallinhouseQty.Text = lblInHouse.Text.Replace(",", "");
              hdninhouseqty.Value = lblInHouse.Text.Replace(",","");
            }
          }
        }


      }
    }
    protected void btnadd_Click(object sender, EventArgs e)
    {
      int InhouseQty = 0, issue_issueQty = 0, OnholdQty = 0, RejectQty = 0; string issue_Challan = "";
      if (ChlIsInHouse.Checked)
      {
        if (!string.IsNullOrEmpty(txtInhouse.Text.Trim()))
        {
          if (Convert.ToDouble(txtInhouse.Text.Trim()) > 0)
          {
            InhouseQty = Convert.ToInt32(txtInhouse.Text.Trim().Replace(",", ""));
          }
          else
          {
            ShowAlert("Inhouse quantity cannot be zero.");
            txtInhouse.Text = "";
            return;
          }
        }

      }
      //if (string.IsNullOrEmpty(txtInhouse.Text.Trim()))
      //{
      //  ShowAlert("Inhouse quantity cannot be empty.");
      //  return;
      //}
      if (chkIsissue.Checked)
      {
        if (txtissue_issue.Text.Trim() == string.Empty || txtissue_challan.Text.Trim() == "")
        {
          ShowAlert("Issued quantity and challan no. cannot be empty.");
          txtissue_issue.Text = ""; txtissue_challan.Text = ""; chkIsissue.Checked = false;
          return;
        }
      }
      if (chkIsissue.Checked)
      {

        if (txtissue_issue.Text.Trim() != string.Empty)
        {
          if (Convert.ToDouble(txtissue_issue.Text.Trim()) > 0)
          {
            issue_issueQty = Convert.ToInt32(txtissue_issue.Text.Trim());
          }
          else
          {
            ShowAlert("Issued quantity cannot be zero.");
            txtissue_issue.Text = "";
            return;
          }
        }
      }
      if (chkIsissue.Checked)
      {
        if (!string.IsNullOrEmpty(txtissue_challan.Text.Trim().Trim()))
          issue_Challan = txtissue_challan.Text.Trim();
      }

      if (ChkHoldchk.Checked)
      {
        if (!string.IsNullOrEmpty(txtonhold.Text.Trim()))
        {
          if (Convert.ToDouble(txtonhold.Text.Trim()) > 0)
          {
            OnholdQty = Convert.ToInt32(txtonhold.Text.Trim());
          }
          else
          {
            ShowAlert("Onhold quantity cannot be zero.");
            txtonhold.Text = "";
            return;
          }
        }
      }
      if (chkRjectchk.Checked)
      {
        if (!string.IsNullOrEmpty(txtreject.Text.Trim()))
        {
          if (Convert.ToDouble(txtreject.Text.Trim()) > 0)
          {
            RejectQty = Convert.ToInt32(txtreject.Text.Trim());
          }
          else
          {
            txtreject.Text = "";
            ShowAlert("Rejected quantity cannot be zero.");
            return;
          }
        }
      }
      if (InhouseQty == 0 && issue_issueQty == 0 && string.IsNullOrEmpty(issue_Challan) && OnholdQty == 0 && RejectQty == 0)
      {
        //blabla..
      }
      else
      {
        ////if (ValidateInHouseEntry(out res))
        ////{
        int Isave = oAdminController.UpdateFabricInHouseQty(OrderDetailID, FabricType, InhouseQty, issue_issueQty, issue_Challan, OnholdQty, RejectQty, ApplicationHelper.LoggedInUser.UserData.UserID);
          if (Isave > 0)
          {
            Response.Redirect(Request.RawUrl, false);
          }
        }
        ////else
        ////{

        ////  ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage(" + res + ");", true);
        ////  disbalectl(false);
        ////  return;

        ////  // ShowAlert("You can't enter qty more then available inhouse qty available inhouse qty :" + res);         
        ////}
      ////}
    }
    protected void btnAddnew_Click(object sender, EventArgs e)
    {
      AddNewRow();
      IsPageSubmit = "";
    }

    protected void btnDelete_Click(object sender, System.EventArgs e)
    {
      ImageButton btn = (ImageButton)sender;
      GridViewRow gvr = (GridViewRow)btn.NamingContainer;
      HiddenField hdnP_ID = (HiddenField)gvr.FindControl("hdnP_ID");
      HiddenField hdnplannedETA = (HiddenField)gvr.FindControl("hdnplannedETA");

      string confirmValue = Request.Form["confirm_value"];
      string[] con = confirmValue.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
      confirmValue = con[con.Length - 1];

      if (confirmValue == "Yes")
      {
        if (hdnP_ID.Value == "" && hdnplannedETA.Value == "")
        {
          Response.Redirect(Request.RawUrl, true);
        }
        int IsDelete = oAdminController.DeleteFabricInHouseETA(Convert.ToInt32(hdnP_ID.Value), Convert.ToDateTime(hdnplannedETA.Value));
        Response.Redirect(Request.RawUrl, true);
        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
      }
      else
      {
        //this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
      }


    }
    private void SetInitialRow()
    {
      DataTable dt = new DataTable();
      dt = oAdminController.GetFabricInHousePlannedQty(OrderDetailID, FabricType, "BLANK");
      ViewState["planneddt"] = dt;
      grdfabInhousePlanned.DataSource = dt;
      grdfabInhousePlanned.DataBind();
    }
    private void AddNewRow()
    {
      DataTable dtplanned = (DataTable)ViewState["planneddt"];
      int iBlankRow = 0;
      int F_plaanedID = 0;
      DateTime plannedETA = DateTime.Now;
      int Qty = 0;
      int Iscomplete = 0;
      int delaysday = 0;
      foreach (GridViewRow row in grdfabInhousePlanned.Rows)
      {
        HiddenField hdnP_ID = (HiddenField)row.FindControl("hdnP_ID");
        TextBox txtplannedETA = (TextBox)row.FindControl("txtplannedETA");
        TextBox txtQty = (TextBox)row.FindControl("txtQty");
        CheckBox ChkIscomplete = (CheckBox)row.FindControl("ChkIscomplete");
        DropDownList ddldelaysday = (DropDownList)row.FindControl("ddldelaysday");
        if (string.IsNullOrEmpty(txtplannedETA.Text))
        {
          iBlankRow++;
        }
      }
      if (iBlankRow > 0)
      {
       
        //ShowAlert("Planned ETA and quantity cannot be empty.");
        ShowAlert("Please Select Plan ETA!");
        //tdMessage.Visible = true;
        return;
      }
      else
      {
        int isave = 0;
        foreach (GridViewRow row in grdfabInhousePlanned.Rows)
        {
          F_plaanedID = 0;
          plannedETA = DateTime.Now;
          Qty = 0;
          Iscomplete = 0;
          delaysday = 0;

          HiddenField hdnP_ID = (HiddenField)row.FindControl("hdnP_ID");
          TextBox txtplannedETA = (TextBox)row.FindControl("txtplannedETA");
          TextBox txtQty = (TextBox)row.FindControl("txtQty");
          CheckBox ChkIscomplete = (CheckBox)row.FindControl("ChkIscomplete");
          DropDownList ddldelaysday = (DropDownList)row.FindControl("ddldelaysday");
          HiddenField hdnplannedETA = (HiddenField)row.FindControl("hdnplannedETA");


          if (hdnP_ID != null && hdnP_ID.Value != "-1" && hdnP_ID.Value != "")
          {
            F_plaanedID = Convert.ToInt32(hdnP_ID.Value);
          }
          if (txtplannedETA != null && txtplannedETA.Text != "")
          {
            try
            {
              //plannedETA = DateHelper.ParseDate(txtplannedETA.Text).Value;
                plannedETA = DateTime.ParseExact(txtplannedETA.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);

              //string[] dd = txtplannedETA.Text.Split('-');
              //string stringdate = dd[0] + "/" + dd[1] + "/" + dd[2];
              //DateTime date = ConvertToDateTime(stringdate);
              ////plannedETA = DateTime.ParseExact(txtplannedETA.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
              //plannedETA = date;
            }
            catch (Exception ex)
            {
              DateTime date = Convert.ToDateTime(hdnplannedETA.Value.Substring(0, 9));
              //plannedETA = DateTime.ParseExact(txtplannedETA.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
              plannedETA = date;
              //DateTime date = ConvertToDateTime(txtplannedETA.Text);
              ShowAlert("Some error is occured while saving data " + ex.Message.ToString());
            }
          }
          delaysday = Convert.ToInt32(ddldelaysday.SelectedValue);
          if (!string.IsNullOrEmpty(txtQty.Text.Trim()))
          Qty = Convert.ToInt32(txtQty.Text.Trim().Replace(",", ""));

          ////if (txtQty.Text.Trim().Replace(",", "") != "")
          ////{
          ////  if (Convert.ToDecimal(txtQty.Text.Trim().Replace(",", "")) <= 0)
          ////  {
          ////    ShowAlert("Fabric planned quantity cannot be zero.");
          ////    return;
          ////  }
          ////}
          Iscomplete = (ChkIscomplete.Checked == true ? 1 : 0);
          try
          {
            isave = oAdminController.UpdateFabricPlannedQty(OrderDetailID, FabricType, F_plaanedID, plannedETA, delaysday, Qty, Iscomplete);
          }
          catch (Exception exs)
          {
            ShowAlert("Some error is occured while saving data!" + exs.Message.ToString());
          }
        }
        if (isave > 0)
        {         
          if (IsPageSubmit == "YES")
          {
            IsPageSubmit = "";
            ShowAlert("Saved Successfully.");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.parent.Shadowbox.close();", true);
            //Response.Redirect(Request.RawUrl, true);
          }
          else
          {
            DataRow EmptyRow = null;
            dtplanned = oAdminController.GetFabricInHousePlannedQty(OrderDetailID, FabricType, "BLANK");
            if (dtplanned.Rows.Count > 0)
            {
              EmptyRow = dtplanned.NewRow();
              for (int i = 0; i < EmptyRow.ItemArray.Length; i++)
              {
                if (i == 1)
                {
                  EmptyRow.ItemArray.SetValue((string)"01-01-0001", i);
                }
                else
                {
                  EmptyRow.ItemArray.SetValue((string)"", i);
                }
              }
            }
            dtplanned.Rows.Add(EmptyRow);
            grdfabInhousePlanned.DataSource = dtplanned;
            grdfabInhousePlanned.DataBind();

            

          }
        }
      }
    }
    private DateTime ConvertToDateTime(string strDateTime)
    {
      DateTime dtFinaldate; string sDateTime;
      //try { dtFinaldate = Convert.ToDateTime(strDateTime); }
      //catch (Exception e)
      //{
      string[] sDate = strDateTime.Split('/');
      sDateTime = sDate[1] + '/' + sDate[0] + '/' + sDate[2];
      dtFinaldate = Convert.ToDateTime(sDateTime);
      // }
      return dtFinaldate;
    }
    static int IsComplete = 0;

    protected void grdfabInhousePlanned_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        DropDownList ddldelaysday = (DropDownList)e.Row.FindControl("ddldelaysday");
        HiddenField hdnP_DelaysDays = (HiddenField)e.Row.FindControl("hdnP_DelaysDays");
        TextBox txtplannedETA = (TextBox)e.Row.FindControl("txtplannedETA");
        CheckBox ChkIscomplete = (CheckBox)e.Row.FindControl("ChkIscomplete");
        HiddenField hdnisComplete = (HiddenField)e.Row.FindControl("hdnisComplete");

        if (!string.IsNullOrEmpty(hdnisComplete.Value))
        {
          if (hdnisComplete.Value == "True" || hdnisComplete.Value == "true")
          {
            IsComplete += 1;
            ChkIscomplete.Checked = true;
            // ImageButton btnAddnew = (grdfabInhousePlanned.FooterRow.FindControl("btnAddnew") as ImageButton);                            
          }
        }
        if (hdnP_DelaysDays != null && hdnP_DelaysDays.Value != "0" && hdnP_DelaysDays.Value != "-1" && hdnP_DelaysDays.Value != "")
        {
          ddldelaysday.SelectedValue = hdnP_DelaysDays.Value;
        }
        if (txtplannedETA.Text != "")
        {
          txtplannedETA.Text = Convert.ToDateTime(txtplannedETA.Text).ToString("dd-MM-yyyy");
          //txtplannedETA.Enabled = false;
          //txtplannedETA.ToolTip = "Planned ETA cannot be change!";
        }
      }
      if (e.Row.RowType == DataControlRowType.Footer)
      {
        ImageButton btnAddnew = (ImageButton)e.Row.FindControl("btnAddnew");
        if (IsComplete > 0)
        {
          btnAddnew.Enabled = false;
        }
      }
    }
    protected void grdfabInhousePlanned_PreRender(object sender, EventArgs e)
    {
      GridViewRow row = grdfabInhousePlanned.Rows[grdfabInhousePlanned.Rows.Count - 1];
      CheckBox ChkIscomplete = (CheckBox)row.FindControl("ChkIscomplete");
      ChkIscomplete.Visible = true;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      IsPageSubmit = "YES";
      AddNewRow();
      
    }
    protected void btnRecreate_Click(object sender, EventArgs e)
    {
        //IsPageSubmit = "YES";
        //AddNewRow();
        foreach (GridViewRow row in grdfabInhousePlanned.Rows)
        {
           
            
            int Qty = 0;
            int iSave = 0;
            int delaysday = 0;
            TextBox txtplannedETA = (TextBox)row.FindControl("txtplannedETA");
            TextBox txtQty = (TextBox)row.FindControl("txtQty");
            DropDownList ddldelaysday = (DropDownList)row.FindControl("ddldelaysday");
            DateTime plannedETA = DateTime.ParseExact(txtplannedETA.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            delaysday = Convert.ToInt32(ddldelaysday.SelectedValue);
            if (!string.IsNullOrEmpty(txtQty.Text.Trim()))
                Qty = Convert.ToInt32(txtQty.Text.Trim().Replace(",", ""));
            iSave = oAdminController.UpdateRevisedQty(OrderDetailID, FabricType, plannedETA, delaysday, Qty);
            break;
        }
        ShowAlert("Saved Successfully.");
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Close", "window.parent.Shadowbox.close();", true);

    }
    protected void grdFabricInhouse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblEntryDate = (Label)e.Row.FindControl("lblEntryDate");
        Label lblChallan = (Label)e.Row.FindControl("lblChallan");
        ImageButton hypedit = (ImageButton)e.Row.FindControl("hypedit");
        Label lblReject = (Label)e.Row.FindControl("lblReject");
        Label lblOnhold = (Label)e.Row.FindControl("lblOnhold");
        Label lblInHouse = (Label)e.Row.FindControl("lblInHouse");
        Label lblQty = (Label)e.Row.FindControl("lblQty");

        int sum = (lblReject.Text == "" ? 0 : Convert.ToInt32(lblReject.Text.Replace(",", ""))) + 
          (lblOnhold.Text == "" ? 0 : Convert.ToInt32(lblOnhold.Text.Replace(",", ""))) + (lblInHouse.Text == "" ? 0 : Convert.ToInt32(lblInHouse.Text.Replace(",", ""))) + (lblQty.Text == "" ? 0 : Convert.ToInt32(lblQty.Text.Replace(",", "")));

        ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(hypedit);

        if (lblChallan != null && lblChallan.Text != "")
        {
          string[] ss = lblChallan.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
          int iCount = 1;
          StringBuilder builderss = new StringBuilder();
          foreach (string a in ss)
          {
            builderss.Append(iCount + ": " + a + " ");
            iCount += 1;
          }
          StringBuilder builder = new StringBuilder();
          foreach (string a in ss)
          {
            if (!string.Equals(lblEntryDate.Text, "Total", StringComparison.CurrentCultureIgnoreCase) && !string.Equals(lblEntryDate.Text, "Pending Required", StringComparison.CurrentCultureIgnoreCase))
            {
              builder.Append("<DIV Class='tooltip challandiv' title='All challan numbers for Date: " + lblEntryDate.Text + " " + builderss.ToString() + "'>").AppendFormat(a).Append("</DIV>");
            }
          }
          lblChallan.Text = builder.ToString();
        }
        if (string.Equals(lblEntryDate.Text, "Total", StringComparison.CurrentCultureIgnoreCase))
        {
          e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
          e.Row.Cells[0].Font.Bold = true;
          e.Row.Cells[1].Font.Bold = true;
          e.Row.Cells[2].Font.Bold = true;
          e.Row.Cells[4].Font.Bold = true;
          e.Row.Cells[5].Font.Bold = true;
        }
        if (string.Equals(lblEntryDate.Text, "Pending Required", StringComparison.CurrentCultureIgnoreCase))
        {
          e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
        }
        if (sum <= 0)
        {
          hypedit.Enabled = false;
        }
      }
    }
    protected void TxtId_TextChanged(object sender, EventArgs e)
    {
        TextBox txtqntygrds = (TextBox)sender;
        GridViewRow row1 = (GridViewRow)txtqntygrds.NamingContainer;
        TextBox txtplannedETA = (TextBox)row1.FindControl("txtplannedETA");
        //DateTime plannedETA = DateHelper.ParseDate(txtplannedETA.Text).Value;
        DateTime plannedETA = DateTime.ParseExact(txtplannedETA.Text, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        string Res = oAdminController.ValidateExsitingPlannedDate(plannedETA, OrderDetailID, FabricType);
        if (!string.IsNullOrEmpty(Res) && Res == "1")
        {
            ShowAlert("Selected planned ETA already exist!");
            txtplannedETA.Text = "";
        }
    }
    protected void hypedit_Click(object sender, EventArgs e)
    {
      ImageButton txtqntygrds = (ImageButton)sender;
      GridViewRow row1 = (GridViewRow)txtqntygrds.NamingContainer;
      Label lblEntryDate = (Label)row1.FindControl("lblEntryDate");
     
      if (Session["Issub"] == null)
      {
        Session["Issub"] = "YES";
        if (Session["SelectedDate"] == null)
        {
          Session["SelectedDate"] = lblEntryDate.Text.Substring(0, 9);
        }
      }
      Response.Redirect(Request.RawUrl, true);
      //PlaceHolder1.Visible = true;
      //divfb.Visible = false;
      //Updatepanel1.Update();
    }
    static object sumObjectInhouse=null;
    static object sumObjectIssued = null;
    static object sumObjectOnhold = null;
    static object sumObjectReject = null;
    static int total = 0;


    public void BindFabrRshuffle(DateTime EntryDate)
    {
      DataTable dt = oAdminController.GetBindFabrRshuffle(OrderDetailID, FabricType, EntryDate);
      if (dt.Rows.Count > 0)
      {
        sumObjectInhouse = dt.Compute("Sum(InHouseQty)", "");
        sumObjectIssued = dt.Compute("Sum(IssueQty)", "");
        sumObjectOnhold = dt.Compute("Sum(OnHoldQty)", "");
        sumObjectReject = dt.Compute("Sum(RejectQty)", "");

        total = Convert.ToInt32(sumObjectIssued) + Convert.ToInt32(sumObjectOnhold) + Convert.ToInt32(sumObjectReject);

        grdfabinhouse_resuffle.DataSource = dt;
        grdfabinhouse_resuffle.DataBind();
        
      }
    }
    protected void grdfabinhouse_resuffle_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        HiddenField hdndate = (HiddenField)e.Row.FindControl("hdndate");
        Label lblInHouseQty = (Label)e.Row.FindControl("lblInHouseQty");
        Label lblhold = (Label)e.Row.FindControl("lblhold");
        Label lblreject = (Label)e.Row.FindControl("lblreject");
        Label lblIssuedQty = (Label)e.Row.FindControl("lblIssuedQty");
        TextBox txtholdsub = (TextBox)e.Row.FindControl("txtholdsub");
        TextBox txtInhousesub = (TextBox)e.Row.FindControl("txtInhousesub");
        TextBox txtRejectQtysub = (TextBox)e.Row.FindControl("txtRejectQtysub");
        TextBox txtIssuedsub = (TextBox)e.Row.FindControl("txtIssuedsub");


        //if ((bool)DataBinder.Eval(e.Row.DataItem, "IsAllow") == false)
        //  txtInhousesub.Enabled = (bool)DataBinder.Eval(e.Row.DataItem, "IsAllow");
        if (Convert.ToInt32(sumObjectInhouse) < total)
          txtInhousesub.Enabled = (bool)DataBinder.Eval(e.Row.DataItem, "IsAllow");
        else
        {
          if (lblInHouseQty.Text == "")
          {
            txtInhousesub.Enabled = false;
          }
        }       
        if (lblhold.Text == "")
        {                  
            txtholdsub.Enabled = false;
        }
        if (lblreject.Text == "")
        {
          txtRejectQtysub.Enabled = false;
          //e.Row.Enabled = false;
        }
        if (lblIssuedQty.Text == "")
        {
          txtIssuedsub.Enabled = false;       
        }
      }
    }
    protected void Button2sav_Click(object sender, EventArgs e)
    {
      UpdateFabPlannedHoldQty();
    }
    protected void Button3close_Click(object sender, EventArgs e)
    {
      Session["Issub"] = null;
      Session["SelectedDate"] = null;
      Response.Redirect(Request.RawUrl, true);
    }
    public void UpdateFabPlannedHoldQty()
    {
      string res = "";
      if (ValidateInHouseEntry_new(out res))
      {

      }
      else
      {
        Session["ErrorSession"] = "Value not save inhouse qty can't be less then issued qty!";
        Session["Issub"] = null;
        Session["SelectedDate"] = null;
        Response.Redirect(Request.RawUrl, true);
        return; 
      }
      //SqlTransaction transaction = null;
      try
      {
        foreach (GridViewRow row in grdfabinhouse_resuffle.Rows)
        {
          HiddenField p_id = (HiddenField)row.FindControl("p_id");
          TextBox txtholdsub = (TextBox)row.FindControl("txtholdsub");
          TextBox txtInhousesub = (TextBox)row.FindControl("txtInhousesub");
          TextBox txtRejectQtysub = (TextBox)row.FindControl("txtRejectQtysub");
          TextBox txtIssuedsub = (TextBox)row.FindControl("txtIssuedsub");
        
          txtholdsub.Text = (txtholdsub.Text == "" ? "0" : txtholdsub.Text);       
          txtInhousesub.Text = (txtInhousesub.Text == "" ? "0" : txtInhousesub.Text);       
          txtRejectQtysub.Text = (txtRejectQtysub.Text == "" ? "0" : txtRejectQtysub.Text);
          txtIssuedsub.Text = (txtIssuedsub.Text == "" ? "0" : txtIssuedsub.Text);
          int Isave = oAdminController.UpdateFabPlannedHoldQty(Convert.ToInt32(p_id.Value), Convert.ToInt32(txtholdsub.Text), Convert.ToInt32(txtInhousesub.Text), Convert.ToInt32(txtRejectQtysub.Text), Convert.ToInt32(txtIssuedsub.Text),ApplicationHelper.LoggedInUser.UserData.UserID);
        }
        ShowAlert("Quantity updated successfully.");
        //foreach (GridViewRow row in grdfabinhouse_resuffle.Rows)
        //{          
        //  TextBox txtholdsub = (TextBox)row.FindControl("txtholdsub");
        //  txtholdsub.Text
        //}
        //BindFabrRshuffle(Convert.ToDateTime(Session["SelectedDate"].ToString()));
        Session["Issub"] = null;
        Session["SelectedDate"] = null;
        Response.Redirect(Request.RawUrl, true);
      }
      catch (Exception ex)
      {
        ShowAlert(ex.Message);
        //transaction.Rollback();
      }
    }
    public void UpdateENDEta(DataTable dt)
    {
      try
      {
        var InHouseQty = "";
        var InHouseIssueQty = "";
        if (dt.Rows.Count > 0)
        {
          foreach (DataRow row in dt.Rows)
          {
            if (row["EntryInHoseDates"].ToString() == "Total")
            {
              InHouseQty = row["InHouseQty"].ToString();
            }
          }
          foreach (DataRow row in dt.Rows)
          {
            if (row["EntryInHoseDates"].ToString() == "Total")
            {
              InHouseIssueQty = row["IssueQty"].ToString();
            }
          }
          decimal per = 0;
          if (RequiredQty > 0 && InHouseQty != "")
          {
              per = ((Convert.ToDecimal(InHouseQty) / Convert.ToDecimal(RequiredQty)) * 100);
            if (per >= 90)
            {
              //grdfabInhousePlanned.Enabled = false;
              //btnSubmit.Enabled = false;
              int iUpdate = oAdminController.UptfabEND_Eta(OrderDetailID, FabricType);
            }
          }
        }
      }
      catch (Exception exc)
      {
        ShowAlert(exc.ToString());
      }
    }
    public bool ValidateInHouseEntry(out string ReSuffleAvilQty)
    {
      bool res = true;
      DataTable dt = oAdminController.GetFabricInHouseQty(OrderDetailID, FabricType);
      var InHouseQty = "";
      var InHouseIssueQty = "";
      var holdQty = "";
      var RejectQty = "";
      int txtInHouse = 0, txtIssued = 0, txtOnHold = 0, txtReject = 0;
      int TotalInhouseQty = 0, TotalReSuffleAvilQty = 0;
      if (dt.Rows.Count > 0)
      {
        foreach (DataRow row in dt.Rows)
        {
          if (row["EntryInHoseDates"].ToString() == "Total")
          {
            InHouseQty = row["InHouseQty"].ToString();
          }
          if (row["EntryInHoseDates"].ToString() == "Total")
          {
            InHouseIssueQty = row["IssueQty"].ToString();
          }
          if (row["EntryInHoseDates"].ToString() == "Total")
          {
            holdQty = row["OnHoldQty"].ToString();
          }
          if (row["EntryInHoseDates"].ToString() == "Total")
          {
            RejectQty = row["RejectQty"].ToString();
          }
        }
      }
      InHouseQty = (InHouseQty == "" ? "0" : InHouseQty);
      InHouseIssueQty = (InHouseIssueQty == "" ? "0" : InHouseIssueQty);
      holdQty = (holdQty == "" ? "0" : holdQty);
      RejectQty = (RejectQty == "" ? "0" : RejectQty);

      txtInHouse = (txtInhouse.Text == "" ? 0 : Convert.ToInt32(txtInhouse.Text));

      txtIssued = (txtissue_issue.Text == "" ? 0 : Convert.ToInt32(txtissue_issue.Text));
      txtOnHold = (txtonhold.Text == "" ? 0 : Convert.ToInt32(txtonhold.Text));
      txtReject = (txtreject.Text == "" ? 0 : Convert.ToInt32(txtreject.Text));
      TotalInhouseQty = Convert.ToInt32(InHouseQty) + txtInHouse;
      TotalReSuffleAvilQty = (TotalInhouseQty - (Convert.ToInt32(InHouseIssueQty) + Convert.ToInt32(holdQty) + Convert.ToInt32(RejectQty) + txtIssued + txtOnHold + txtReject));
      ReSuffleAvilQty = (TotalInhouseQty - (Convert.ToInt32(InHouseIssueQty) + Convert.ToInt32(holdQty) + Convert.ToInt32(RejectQty))).ToString();
      if (TotalReSuffleAvilQty < 0)
      {
        //ShowAlert("You can't enter qty more then available inhouse qty available inhouse qty :" + TotalReSuffleAvilQty);
        res = false;
      }
      return res;
    }
    public void disbalectl(bool yes)
    {
      ChlIsInHouse.Checked = yes;
      chkIsissue.Checked = yes;
      ChkHoldchk.Checked = yes;
      chkRjectchk.Checked = yes;

      txtInhouse.Text = "";
      txtissue_issue.Text = "";
      txtissue_challan.Text = "";
      txtonhold.Text = "";
      txtreject.Text = "";


    }
    protected void grdfabinhouse_resuffle_RowCreated(object sender, GridViewRowEventArgs e)
    {

      if (e.Row.RowType == DataControlRowType.Header)
      {

        GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
        
        TableCell HeaderCell2 = new TableCell();
        HeaderCell2.Text = "Sequence";
        //HeaderCell2.ColumnSpan = 2;
        HeaderCell2.RowSpan = 2;
        HeaderRow.Cells.Add(HeaderCell2);



        HeaderCell2 = new TableCell();
        HeaderCell2.Text = "Date";
       // HeaderCell2.ColumnSpan = 2;
        HeaderCell2.RowSpan = 2;
        HeaderRow.Cells.Add(HeaderCell2);



        HeaderCell2 = new TableCell();
        HeaderCell2.Text = "Inhouse Qty";
        HeaderCell2.ColumnSpan = 2;
        HeaderRow.Cells.Add(HeaderCell2);

        HeaderCell2 = new TableCell();
        HeaderCell2.Text = "Issued Qty";
        HeaderCell2.ColumnSpan = 2;
        HeaderRow.Cells.Add(HeaderCell2);


        HeaderCell2 = new TableCell();
        HeaderCell2.Text = "Onhold Qty";
        HeaderCell2.ColumnSpan = 2;
        HeaderRow.Cells.Add(HeaderCell2);

        HeaderCell2 = new TableCell();
        HeaderCell2.Text = "Reject Qty";
        HeaderCell2.ColumnSpan = 2;
        HeaderRow.Cells.Add(HeaderCell2);

        grdfabinhouse_resuffle.Controls[0].Controls.AddAt(0, HeaderRow);
        GridViewRow HeaderRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        TableCell HeaderCell = new TableCell();
       // HeaderCell.Text = "";
       //// HeaderCell.RowSpan = 2;
       // HeaderRow1.Cells.Add(HeaderCell);

       // HeaderCell = new TableCell();
       // HeaderCell.Text = "";
       //// HeaderCell.RowSpan = 2;
       // HeaderRow1.Cells.Add(HeaderCell);

        HeaderCell = new TableCell();
        HeaderCell.Text = "Qty";
        HeaderRow1.Cells.Add(HeaderCell);



        HeaderCell = new TableCell();
        HeaderCell.Text = "Subtract Qty";
        HeaderRow1.Cells.Add(HeaderCell);



        HeaderCell = new TableCell();
        HeaderCell.Text = "Qty";
        HeaderRow1.Cells.Add(HeaderCell);



        HeaderCell = new TableCell();
        HeaderCell.Text = "Subtract Qty";
        HeaderRow1.Cells.Add(HeaderCell);

        HeaderCell = new TableCell();
        HeaderCell.Text = "Qty";
        HeaderRow1.Cells.Add(HeaderCell);



        HeaderCell = new TableCell();
        HeaderCell.Text = "Subtract Qty";
        HeaderRow1.Cells.Add(HeaderCell);


        HeaderCell = new TableCell();
        HeaderCell.Text = "Qty";
        HeaderRow1.Cells.Add(HeaderCell);


        HeaderCell = new TableCell();
        HeaderCell.Text = "Subtract Qty";
        HeaderRow1.Cells.Add(HeaderCell);


        HeaderRow.Attributes.Add("class", "header");
        HeaderRow1.Attributes.Add("class", "header");
        grdfabinhouse_resuffle.Controls[0].Controls.AddAt(1, HeaderRow1);

      }
    }
    protected void txtInhousesub_TextChanged(object sender, EventArgs e)
    {
     
      /*int sum = 0;
      foreach (GridViewRow row in grdfabinhouse_resuffle.Rows)
      {
        TextBox txtInhousesub_1 = (TextBox)row.FindControl("txtInhousesub");
        sum += Convert.ToInt32(txtInhousesub_1.Text == "" ? 0 : Convert.ToInt32(txtInhousesub_1.Text));
      }
      
      if(lbloverallinhouseQty.Text=="")
        lbloverallinhouseQty.Text = "0";

      sum=sum + Convert.ToInt32(lbloverallinhouseQty.Text);
      if (sum > Convert.ToInt32(lbloverallinhouseQty.Text))
      {
      
        ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage2(" + "d" + ");", true);
        return;
      }*/
   
      
    }
    public bool ValidateInHouseEntry_new(out string result)
    {
      result = "";
      bool res = true;
      DataTable dt = oAdminController.GetFabricInHouseQty(OrderDetailID, FabricType);
      var InHouseQty = "";
      var InHouseIssueQty = "";
      var holdQty = "";
      var RejectQty = "";
      
      if (dt.Rows.Count > 0)
      {
        foreach (DataRow row in dt.Rows)
        {
          if (row["EntryInHoseDates"].ToString() == "Total")
          {
            InHouseQty = row["InHouseQty"].ToString();
          }
          if (row["EntryInHoseDates"].ToString() == "Total")
          {
            InHouseIssueQty = row["IssueQty"].ToString();
          }
          if (row["EntryInHoseDates"].ToString() == "Total")
          {
            holdQty = row["OnHoldQty"].ToString();
          }
          if (row["EntryInHoseDates"].ToString() == "Total")
          {
            RejectQty = row["RejectQty"].ToString();
          }
        }
      }
      InHouseQty = (InHouseQty == "" ? "0" : InHouseQty);
      InHouseIssueQty = (InHouseIssueQty == "" ? "0" : InHouseIssueQty);
      holdQty = (holdQty == "" ? "0" : holdQty);
      RejectQty = (RejectQty == "" ? "0" : RejectQty);

      int sum = 0;
      foreach (GridViewRow row in grdfabinhouse_resuffle.Rows)
      {
        TextBox txtInhousesub_1 = (TextBox)row.FindControl("txtInhousesub");
        sum += Convert.ToInt32(txtInhousesub_1.Text == "" ? 0 : Convert.ToInt32(txtInhousesub_1.Text));
      }

      if (lbloverallinhouseQty.Text == "")
        lbloverallinhouseQty.Text = "0";
      sum = sum - Convert.ToInt32(InHouseQty);
      //if (Math.Abs(sum) < (Convert.ToInt32(InHouseIssueQty) + Convert.ToInt32(holdQty) + Convert.ToInt32(RejectQty)))
      //{
      //  result = "";
      //  //ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alertMessage2(" + "d" + ");", true);
      //  res = false;
      //}
      return res;
    }
  
  }
}
