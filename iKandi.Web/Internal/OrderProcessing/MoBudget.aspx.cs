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

namespace iKandi.Web.Internal.OrderProcessing
{
  public partial class MoBudget : System.Web.UI.Page
  {
    int UserId = 0;

    DateTime dtStartDate = DateTime.Now, dtEndDate = DateTime.Now;
    int iFromWeekNo = 0, iToWeekNo = 0;
    string sFinancialYear = "";

    BuyingHouseController objBuyingHouseController = new BuyingHouseController();

    protected void Page_Load(object sender, EventArgs e)
    {
      UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

      txtStartDate.Attributes.Add("readonly", "readonly");
      txtEndDate.Attributes.Add("readonly", "readonly");
      txtworkingHour.Attributes.Add("readonly", "readonly");

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
        FillBudgetDetails();
      }
    }

    private void RefershControls()
    {
      lblMessage.Text = "Manpower Budget";
      btnSubmit.Visible = false;
      lblFinalize.Visible = false;
      chkFinalize.Visible = false;
      txtworkingHour.Text = "";
      dvWorkerType.Visible = false;
      trLine_Floor.Visible = false;
      gvAvailMin.DataSource = null;
      gvAvailMin.DataBind();
      gvWorkingHours.DataSource = null;
      gvWorkingHours.DataBind();
      gvWorkerType.DataSource = null;
      gvWorkerType.DataBind();
      gvStaffDept.DataSource = null;
      gvStaffDept.DataBind();
      gvFactoryDetails1.DataSource = null;
      gvFactoryDetails1.DataBind();
      gvFactoryDetails2.DataSource = null;
      gvFactoryDetails2.DataBind();
      //gvFactoryDetails3.DataSource = null;
      //gvFactoryDetails3.DataBind();
      gvFactoryDetails4.DataSource = null;
      gvFactoryDetails4.DataBind();
      gvCPAMHeader.DataSource = null;
      gvCPAMHeader.DataBind();
      gvCPAMFactory1.DataSource = null;
      gvCPAMFactory1.DataBind();
      gvCPAMFactory2.DataSource = null;
      gvCPAMFactory2.DataBind();
      //gvCPAMFactory3.DataSource = null;
      //gvCPAMFactory3.DataBind();
      gvCPAMFactory4.DataSource = null;
      gvCPAMFactory4.DataBind();
      gvBudMmr.DataSource = null;
      gvBudMmr.DataBind();
      gvBudgetMMRDetails.DataSource = null;
      gvBudgetMMRDetails.DataBind();
    }

    protected void btnViewPanel_Click(object sender, EventArgs e)
    {
      btnCreatePanel.Visible = true;
      btnViewPanel.Visible = false;
      pnlCreatePanel.Visible = false;
      pnlViewPanel.Visible = true;
      FillBudgetDetails();

      RefershControls();
    }

    protected void btnCreatePanel_Click(object sender, EventArgs e)
    {
      btnCreatePanel.Visible = false;
      btnViewPanel.Visible = true;
      pnlCreatePanel.Visible = true;
      pnlViewPanel.Visible = false;

      RefershControls();
    }

    private void FillBudgetDetails()
    {
      DataTable dt = new DataTable();
      ViewState["FillBudgetDetails"] = dt = objBuyingHouseController.FillBudgetDetailsBAL();
      DataView dv = new DataView(dt);
      if (dv.ToTable(true, "FromWeekCount", "BudgetDetails").Rows.Count > 0)
      {
        ddlViewBudget.DataSource = dv.ToTable(true, "FromWeekCount", "BudgetDetails");
        ddlViewBudget.DataValueField = "FromWeekCount";
        ddlViewBudget.DataTextField = "BudgetDetails";
        ddlViewBudget.DataBind();
        ddlViewBudget.Items.Insert(0, new ListItem("-- Select Budget --", "0"));
      }
      else
      {
        ddlViewBudget.Items.Insert(0, new ListItem("-- Select Budget --", "0"));
        ddlViewBudget.Enabled = false;
      }
    }

    protected void ddlViewBudget_SelectedIndexChanged(object sender, EventArgs e)
    {
      RefershControls();
      
      if (Convert.ToInt32(ddlViewBudget.SelectedValue) > 0)
      {
        DataTable dt = (DataTable)ViewState["FillBudgetDetails"];
        DataView dv = new DataView(dt);
        dv.RowFilter = "FromWeekCount = " + Convert.ToInt32(ddlViewBudget.SelectedValue);

        ViewState["dtStartDate"] = dtStartDate = Convert.ToDateTime(dv.ToTable().Rows[0]["FromWeek"]);
        dtEndDate = Convert.ToDateTime(dv.ToTable().Rows[0]["ToWeek"]);
        ViewState["dtEndDate"] = dtEndDate = dtEndDate.AddDays(-5);

        ViewState["FromWeekNo"] = iFromWeekNo = Convert.ToInt32(dv.ToTable().Rows[0]["FromWeekCount"]);
        ViewState["ToWeekNo"] = iToWeekNo = Convert.ToInt32(dv.ToTable().Rows[0]["ToWeekCount"]);
        ViewState["FinancialYear"] = sFinancialYear = dv.ToTable().Rows[0]["FinancialYear"].ToString();

        lblMessage.Text = dv.ToTable().Rows[0]["BudgetMessage"].ToString();

        btnSubmit.Visible = true;
        lblFinalize.Visible = true;
        chkFinalize.Visible = true;
        bool IsEnabled = objBuyingHouseController.CheckIsEnabledBudgetBAL(iFromWeekNo, iToWeekNo);
        txtAbsentism.Text = objBuyingHouseController.GetAbsentismBAL(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo).ToString();
        FillWorkingHours(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo);
        chkFinalize.Checked = objBuyingHouseController.CheckIsFinalizeBudgetBAL(dtStartDate, dtEndDate);
        chkFinalize.Attributes.Clear();
        if (chkFinalize.Checked)
        {
          chkFinalize.Attributes.Add("onclick", "if (!confirm('If You uncheck the Finalize Budget and Click on Submit then Bus Count and Bud Cost will reset based on Work Force Admin. Please Confirm?')) return false;");
        }
        else
        {
          chkFinalize.Attributes.Add("onclick", "if (!confirm('If You Finalize Budget then No. of Lines, No. of Floors for all Units and Avg Working Hours will get freeze. Please Confirm?')) return false;");
        }

        FillHeader();
        gvCPAMHeader.Visible = false;
        gvBudMmr.Visible = false;
        trLine_Floor.Visible = true;
        FillBudgetLineFloorDetails("C 47", dtStartDate, dtEndDate);
        FillBudgetLineFloorDetails("C 45-46", dtStartDate, dtEndDate);
      //  FillBudgetLineFloorDetails("B 45", dtStartDate, dtEndDate);
        FillBudgetLineFloorDetails("BIPL", dtStartDate, dtEndDate);
        gvFactoryLine_FloorDetails1.Enabled = IsEnabled == true ? true : false;
        gvFactoryLine_FloorDetails2.Enabled = IsEnabled == true ? true : false;
        //gvFactoryLine_FloorDetails3.Enabled = IsEnabled == true ? true : false;
        txtAbsentism.Enabled = IsEnabled == true ? true : false;
        chkFinalize.Enabled = IsEnabled == true ? true : false;
        gvWorkingHours.Enabled = IsEnabled == true ? true : false;

        if (IsEnabled)
        {
          if (chkFinalize.Checked)
          {
            gvWorkingHours.Enabled = false;
            gvFactoryLine_FloorDetails1.Enabled = false;
            gvFactoryLine_FloorDetails2.Enabled = false;
            //gvFactoryLine_FloorDetails3.Enabled = false;
          }
          else
          {
            gvWorkingHours.Enabled = true;
            gvFactoryLine_FloorDetails1.Enabled = true;
            gvFactoryLine_FloorDetails2.Enabled = true;
            //gvFactoryLine_FloorDetails3.Enabled = true;
          }
        }
      }
    }

    protected void btnCreate_Click(object sender, EventArgs e)
    {
      RefershControls();
      ViewState["dtStartDate"] = dtStartDate = Convert.ToDateTime(txtStartDate.Text, new CultureInfo("en-GB"));
      ViewState["dtEndDate"] = dtEndDate = Convert.ToDateTime(txtEndDate.Text, new CultureInfo("en-GB"));
      CheckTimeFrame(dtStartDate.Date, dtEndDate.Date);
    }

    private void CheckTimeFrame(DateTime dtStartDate, DateTime dtEndDate)
    {
      DataTable dtValidation = objBuyingHouseController.CheckTimeFrameBAL(dtStartDate, dtEndDate);
      if (dtValidation.Rows.Count > 0)
      {
        if (Convert.ToBoolean(dtValidation.Rows[0]["IsValidate"]) == false)
        {
          Page page = HttpContext.Current.Handler as Page;
          ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + dtValidation.Rows[0]["ValidationMessage"].ToString() + "');", true);
        }
        else
        {
          ViewState["FromWeekNo"] = iFromWeekNo = Convert.ToInt32(dtValidation.Rows[0]["FromWeekCount"]);
          ViewState["ToWeekNo"] = iToWeekNo = Convert.ToInt32(dtValidation.Rows[0]["ToWeekCount"]);
          ViewState["FinancialYear"] = sFinancialYear = dtValidation.Rows[0]["FinancialYear"].ToString();
          lblMessage.Text = "Manpower Budgeting From Wk-" + iFromWeekNo.ToString() + " (" + dtValidation.Rows[0]["FromWeekDate"].ToString() + ") To Wk-" + iToWeekNo.ToString() + " (" + dtValidation.Rows[0]["ToWeekDate"].ToString() + ")";

          btnSubmit.Visible = true;
          lblFinalize.Visible = true;
          chkFinalize.Visible = true;
          FillWorkingHours(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo);
          FillHeader();
          gvCPAMHeader.Visible = false;
          gvBudMmr.Visible = false;
          trLine_Floor.Visible = true;
          FillBudgetLineFloorDetails("C 47", dtStartDate, dtEndDate);
          FillBudgetLineFloorDetails("C 45-46", dtStartDate, dtEndDate);
         // FillBudgetLineFloorDetails("B 45", dtStartDate, dtEndDate);
          FillBudgetLineFloorDetails("BIPL", dtStartDate, dtEndDate);
        }
      }
    }

    private void FillWorkingHours(DateTime dtStartDate, DateTime dtEndDate, int iFromWeekNo, int iToWeekNo)
    {
      DataTable dtWorkingHours = objBuyingHouseController.GetWorkingHoursBAL(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo);

      ViewState["OT1"] = dtWorkingHours.Rows[0]["OT1"];
      ViewState["OT2"] = dtWorkingHours.Rows[0]["OT2"];
      ViewState["OT3"] = dtWorkingHours.Rows[0]["OT3"];
      ViewState["OT4"] = dtWorkingHours.Rows[0]["OT4"];

      gvWorkingHours.DataSource = dtWorkingHours;
      gvWorkingHours.DataBind();
    }

    protected void gvWorkingHours_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.Header)
      {
        Label lblOT1 = (Label)e.Row.FindControl("lblOT1");
        Label lblOT2 = (Label)e.Row.FindControl("lblOT2");
        Label lblOT3 = (Label)e.Row.FindControl("lblOT3");
        Label lblOT4 = (Label)e.Row.FindControl("lblOT4");

        lblOT1.Text = ViewState["OT1"].ToString();
        lblOT2.Text = ViewState["OT2"].ToString();
        lblOT3.Text = ViewState["OT3"].ToString();
        lblOT4.Text = ViewState["OT4"].ToString();
      }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
      dtStartDate = Convert.ToDateTime(ViewState["dtStartDate"]);
      dtEndDate = Convert.ToDateTime(ViewState["dtEndDate"]);

      iFromWeekNo = Convert.ToInt32(ViewState["FromWeekNo"]);
      iToWeekNo = Convert.ToInt32(ViewState["ToWeekNo"]);
      sFinancialYear = ViewState["FinancialYear"].ToString();

      CalculateWorkingHours();
      gvCPAMHeader.Visible = true;
      gvBudMmr.Visible = true;
      CalculateLine_Floors("C 47");
      CalculateLine_Floors("C 45-46");
    //  CalculateLine_Floors("B 45");
      FillWorkerType();

      FillFactoryDetails("C 47", dtStartDate, dtEndDate, Convert.ToDecimal(txtAbsentism.Text), Convert.ToDecimal(txtworkingHour.Text), iFromWeekNo, iToWeekNo, sFinancialYear);
      FillFactoryDetails("C 45-46", dtStartDate, dtEndDate, Convert.ToDecimal(txtAbsentism.Text), Convert.ToDecimal(txtworkingHour.Text), iFromWeekNo, iToWeekNo, sFinancialYear);
     // FillFactoryDetails("B 45", dtStartDate, dtEndDate, Convert.ToDecimal(txtAbsentism.Text), Convert.ToDecimal(txtworkingHour.Text), iFromWeekNo, iToWeekNo, sFinancialYear);
      FillFactoryDetails("BIPL", dtStartDate, dtEndDate, Convert.ToDecimal(txtAbsentism.Text), Convert.ToDecimal(txtworkingHour.Text), iFromWeekNo, iToWeekNo, sFinancialYear);

      PreserveOldValues();

      FillBudgetCPAMDetails(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo, Convert.ToDecimal(txtworkingHour.Text), "C 47");
      FillBudgetCPAMDetails(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo, Convert.ToDecimal(txtworkingHour.Text), "C 45-46");
     // FillBudgetCPAMDetails(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo, Convert.ToDecimal(txtworkingHour.Text), "B 45");
      FillBudgetCPAMDetails(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo, Convert.ToDecimal(txtworkingHour.Text), "");
      FillBudgetMMRDetails(dtStartDate, dtEndDate);

      bool IsEnabled = objBuyingHouseController.CheckIsEnabledBudgetBAL(iFromWeekNo, iToWeekNo);
      gvFactoryDetails1.Enabled = IsEnabled ? true : false;
      gvFactoryDetails2.Enabled = IsEnabled ? true : false;
     // gvFactoryDetails3.Enabled = IsEnabled ? true : false;

      chkFinalize.Attributes.Clear();
      if (chkFinalize.Checked)
      {
        chkFinalize.Attributes.Add("onclick", "if (!confirm('If You uncheck the Finalize Budget and Click on Submit then Bus Count and Bud Cost will reset based on Work Force Admin. Please Confirm?')) return false;");
      }
      else
      {
        chkFinalize.Attributes.Add("onclick", "if (!confirm('If You Finalize Budget then No. of Lines, No. of Floors for all Units and Avg Working Hours will get freeze. Please Confirm?')) return false;");
      }

      if (IsEnabled)
      {
        if (chkFinalize.Checked)
        {
          gvWorkingHours.Enabled = false;
          gvFactoryLine_FloorDetails1.Enabled = false;
          gvFactoryLine_FloorDetails2.Enabled = false;
          //gvFactoryLine_FloorDetails3.Enabled = false;

          gvFactoryDetails1.Enabled = true;
          gvFactoryDetails2.Enabled = true;
          //gvFactoryDetails3.Enabled = true;
        }
        else
        {
          gvWorkingHours.Enabled = true;
          gvFactoryLine_FloorDetails1.Enabled = true;
          gvFactoryLine_FloorDetails2.Enabled = true;
          //gvFactoryLine_FloorDetails3.Enabled = true;

          gvFactoryDetails1.Enabled = false;
          gvFactoryDetails2.Enabled = false;
         // gvFactoryDetails3.Enabled = false;
        }
      }
    }

    private void CalculateWorkingHours()
    {
      decimal dWorkingHours = 0, dTotalNormalHours = 0;
      int iOT1 = 0, iOT2 = 0, iOT3 = 0, iOT4 = 0;

      for (int iOrderId = 0; iOrderId < gvWorkingHours.Rows.Count; iOrderId++)
      {
        Label lblNormalHours = (Label)gvWorkingHours.Rows[iOrderId].FindControl("lblNormalHours");
        TextBox txtOT1 = (TextBox)gvWorkingHours.Rows[iOrderId].FindControl("txtOT1");
        TextBox txtOT2 = (TextBox)gvWorkingHours.Rows[iOrderId].FindControl("txtOT2");
        TextBox txtOT3 = (TextBox)gvWorkingHours.Rows[iOrderId].FindControl("txtOT3");
        TextBox txtOT4 = (TextBox)gvWorkingHours.Rows[iOrderId].FindControl("txtOT4");

        txtOT1.Text = txtOT1.Text == "" ? "0" : txtOT1.Text;
        txtOT2.Text = txtOT2.Text == "" ? "0" : txtOT2.Text;
        txtOT3.Text = txtOT3.Text == "" ? "0" : txtOT3.Text;
        txtOT4.Text = txtOT4.Text == "" ? "0" : txtOT4.Text;

        dTotalNormalHours = Convert.ToDecimal(lblNormalHours.Text);
        iOT1 = Convert.ToInt32(txtOT1.Text);
        iOT2 = Convert.ToInt32(txtOT2.Text);
        iOT3 = Convert.ToInt32(txtOT3.Text);
        iOT4 = Convert.ToInt32(txtOT4.Text);

        objBuyingHouseController.UpdateWorkingHours(iOrderId, Convert.ToDecimal(txtAbsentism.Text), Convert.ToInt32(txtOT1.Text), Convert.ToInt32(txtOT2.Text), Convert.ToInt32(txtOT3.Text), Convert.ToInt32(txtOT4.Text), dtStartDate, dtEndDate, chkFinalize.Checked, UserId);

        txtOT1.Text = txtOT1.Text == "0" ? "" : txtOT1.Text;
        txtOT2.Text = txtOT2.Text == "0" ? "" : txtOT2.Text;
        txtOT3.Text = txtOT3.Text == "0" ? "" : txtOT3.Text;
        txtOT4.Text = txtOT4.Text == "0" ? "" : txtOT4.Text;
      }

      Label lblOT1 = (Label)gvWorkingHours.HeaderRow.FindControl("lblOT1");
      Label lblOT2 = (Label)gvWorkingHours.HeaderRow.FindControl("lblOT2");
      Label lblOT3 = (Label)gvWorkingHours.HeaderRow.FindControl("lblOT3");
      Label lblOT4 = (Label)gvWorkingHours.HeaderRow.FindControl("lblOT4");


      dWorkingHours = (((8 * dTotalNormalHours) + (Convert.ToDecimal(lblOT1.Text) * iOT1) + (Convert.ToDecimal(lblOT2.Text) * iOT2) + (Convert.ToDecimal(lblOT3.Text) * iOT3) + (Convert.ToDecimal(lblOT4.Text) * iOT4)) / dTotalNormalHours);
      txtworkingHour.Text = Math.Round(dWorkingHours, 2).ToString();
    }

    private void CalculateLine_Floors(string sUnitName)
    {
      if (sUnitName == "C 47")
      {
        for (int i = 0; i < gvFactoryLine_FloorDetails1.Rows.Count; i++)
        {
          Label lblMode = (Label)gvFactoryLine_FloorDetails1.Rows[i].FindControl("lblMode");
          TextBox txtCutting = (TextBox)gvFactoryLine_FloorDetails1.Rows[i].FindControl("txtCutting");
          TextBox txtStitching = (TextBox)gvFactoryLine_FloorDetails1.Rows[i].FindControl("txtStitching");
          TextBox txtFinishing = (TextBox)gvFactoryLine_FloorDetails1.Rows[i].FindControl("txtFinishing");

          txtCutting.Text = txtCutting.Text == "" ? "0" : txtCutting.Text;
          txtStitching.Text = txtStitching.Text == "" ? "0" : txtStitching.Text;
          txtFinishing.Text = txtFinishing.Text == "" ? "0" : txtFinishing.Text;

          if (lblMode.Text == "No. of Lines")
          {
            objBuyingHouseController.UpdateBudgetLines_Floor(sUnitName, lblMode.Text, 0, Convert.ToInt32(txtStitching.Text), 0, dtStartDate, dtEndDate);
          }
          else
          {
            objBuyingHouseController.UpdateBudgetLines_Floor(sUnitName, lblMode.Text, Convert.ToInt32(txtCutting.Text), Convert.ToInt32(txtStitching.Text), Convert.ToInt32(txtFinishing.Text), dtStartDate, dtEndDate);
          }

          txtCutting.Text = txtCutting.Text == "0" ? "" : txtCutting.Text;
          txtStitching.Text = txtStitching.Text == "0" ? "" : txtStitching.Text;
          txtFinishing.Text = txtFinishing.Text == "0" ? "" : txtFinishing.Text;
        }
      }
      if (sUnitName == "C 45-46")
      {
        for (int i = 0; i < gvFactoryLine_FloorDetails2.Rows.Count; i++)
        {
          Label lblMode = (Label)gvFactoryLine_FloorDetails2.Rows[i].FindControl("lblMode");
          TextBox txtCutting = (TextBox)gvFactoryLine_FloorDetails2.Rows[i].FindControl("txtCutting");
          TextBox txtStitching = (TextBox)gvFactoryLine_FloorDetails2.Rows[i].FindControl("txtStitching");
          TextBox txtFinishing = (TextBox)gvFactoryLine_FloorDetails2.Rows[i].FindControl("txtFinishing");

          txtCutting.Text = txtCutting.Text == "" ? "0" : txtCutting.Text;
          txtStitching.Text = txtStitching.Text == "" ? "0" : txtStitching.Text;
          txtFinishing.Text = txtFinishing.Text == "" ? "0" : txtFinishing.Text;

          if (lblMode.Text == "No. of Lines")
          {
            objBuyingHouseController.UpdateBudgetLines_Floor(sUnitName, lblMode.Text, 0, Convert.ToInt32(txtStitching.Text), 0, dtStartDate, dtEndDate);
          }
          else
          {
            objBuyingHouseController.UpdateBudgetLines_Floor(sUnitName, lblMode.Text, Convert.ToInt32(txtCutting.Text), Convert.ToInt32(txtStitching.Text), Convert.ToInt32(txtFinishing.Text), dtStartDate, dtEndDate);
          }

          txtCutting.Text = txtCutting.Text == "0" ? "" : txtCutting.Text;
          txtStitching.Text = txtStitching.Text == "0" ? "" : txtStitching.Text;
          txtFinishing.Text = txtFinishing.Text == "0" ? "" : txtFinishing.Text;
        }
      }
     // if (sUnitName == "B 45")
      //{
      //  for (int i = 0; i < gvFactoryLine_FloorDetails3.Rows.Count; i++)
      //  {
      //    Label lblMode = (Label)gvFactoryLine_FloorDetails3.Rows[i].FindControl("lblMode");
      //    TextBox txtCutting = (TextBox)gvFactoryLine_FloorDetails3.Rows[i].FindControl("txtCutting");
      //    TextBox txtStitching = (TextBox)gvFactoryLine_FloorDetails3.Rows[i].FindControl("txtStitching");
      //    TextBox txtFinishing = (TextBox)gvFactoryLine_FloorDetails3.Rows[i].FindControl("txtFinishing");

      //    txtCutting.Text = txtCutting.Text == "" ? "0" : txtCutting.Text;
      //    txtStitching.Text = txtStitching.Text == "" ? "0" : txtStitching.Text;
      //    txtFinishing.Text = txtFinishing.Text == "" ? "0" : txtFinishing.Text;

      //    if (lblMode.Text == "No. of Lines")
      //    {
      //      objBuyingHouseController.UpdateBudgetLines_Floor(sUnitName, lblMode.Text, 0, Convert.ToInt32(txtStitching.Text), 0, dtStartDate, dtEndDate);
      //    }
      //    else
      //    {
      //      objBuyingHouseController.UpdateBudgetLines_Floor(sUnitName, lblMode.Text, Convert.ToInt32(txtCutting.Text), Convert.ToInt32(txtStitching.Text), Convert.ToInt32(txtFinishing.Text), dtStartDate, dtEndDate);
      //    }

      //    txtCutting.Text = txtCutting.Text == "0" ? "" : txtCutting.Text;
      //    txtStitching.Text = txtStitching.Text == "0" ? "" : txtStitching.Text;
      //    txtFinishing.Text = txtFinishing.Text == "0" ? "" : txtFinishing.Text;
      //  }
      //}
    }

    private void FillHeader()
    {
      DataTable dtAvailMin = objBuyingHouseController.GetBiplAvailMinBAL();
      DataTable dtAvailMinChangeOrder = new DataTable();
      for (int i = 0; i <= dtAvailMin.Rows.Count; i++)
      {
        dtAvailMinChangeOrder.Columns.Add();
      }
      for (int i = 0; i < dtAvailMin.Columns.Count; i++)
      {
        dtAvailMinChangeOrder.Rows.Add();
        dtAvailMinChangeOrder.Rows[i][0] = dtAvailMin.Columns[i].ColumnName;
      }
      for (int i = 0; i < dtAvailMin.Columns.Count; i++)
      {
        for (int j = 0; j < dtAvailMin.Rows.Count; j++)
        {
          dtAvailMinChangeOrder.Rows[i][j + 1] = dtAvailMin.Rows[j][i];
        }
      }
      gvAvailMin.DataSource = dtAvailMinChangeOrder;
      gvAvailMin.DataBind();

      gvCPAMHeader.DataSource = dtAvailMinChangeOrder;
      gvCPAMHeader.DataBind();

      gvBudMmr.DataSource = dtAvailMinChangeOrder;
      gvBudMmr.DataBind();
    }

    protected void gvAvailMin_rowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowIndex == 2)
      {
        e.Row.Visible = true;
      }
      else
      {
        e.Row.Visible = false;
      }
    }

    protected void gvCPAMHeader_rowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowIndex < 2)
      {
        e.Row.Visible = false;
      }
    }

    protected void gvBudMmr_rowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowIndex < 2)
      {
        e.Row.Visible = false;
      }
    }

    private void FillBudgetLineFloorDetails(string sUnitName, DateTime dtStartDate, DateTime dtEndDate)
    {
      DataTable dtBudgetLineFloorDetails = objBuyingHouseController.GetBudgetLineFloorDetailsBAL(sUnitName, dtStartDate, dtEndDate);
      if (sUnitName == "C 47")
      {
        gvFactoryLine_FloorDetails1.DataSource = dtBudgetLineFloorDetails;
        gvFactoryLine_FloorDetails1.DataBind();
      }
      if (sUnitName == "C 45-46")
      {
        gvFactoryLine_FloorDetails2.DataSource = dtBudgetLineFloorDetails;
        gvFactoryLine_FloorDetails2.DataBind();
      }
      //if (sUnitName == "B 45")
      //{
      //  gvFactoryLine_FloorDetails3.DataSource = dtBudgetLineFloorDetails;
      //  gvFactoryLine_FloorDetails3.DataBind();
      //}
      if (sUnitName == "BIPL")
      {
        gvFactoryLine_FloorDetails4.DataSource = dtBudgetLineFloorDetails;
        gvFactoryLine_FloorDetails4.DataBind();
      }
    }

    protected void gvFactoryLine_FloorDetails1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblMode = (Label)e.Row.FindControl("lblMode");
        TextBox txtCutting = (TextBox)e.Row.FindControl("txtCutting");
        TextBox txtFinishing = (TextBox)e.Row.FindControl("txtFinishing");

        if (lblMode.Text == "No. of Lines")
        {
          txtCutting.Visible = false;
          txtFinishing.Visible = false;
        }
      }
    }

    protected void gvFactoryLine_FloorDetails2_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblMode = (Label)e.Row.FindControl("lblMode");
        TextBox txtCutting = (TextBox)e.Row.FindControl("txtCutting");
        TextBox txtFinishing = (TextBox)e.Row.FindControl("txtFinishing");

        if (lblMode.Text == "No. of Lines")
        {
          txtCutting.Visible = false;
          txtFinishing.Visible = false;
        }
      }
    }

    protected void gvFactoryLine_FloorDetails3_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblMode = (Label)e.Row.FindControl("lblMode");
        TextBox txtCutting = (TextBox)e.Row.FindControl("txtCutting");
        TextBox txtFinishing = (TextBox)e.Row.FindControl("txtFinishing");

        if (lblMode.Text == "No. of Lines")
        {
          txtCutting.Visible = false;
          txtFinishing.Visible = false;
        }
      }
    }

    protected void gvFactoryLine_FloorDetails4_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblMode = (Label)e.Row.FindControl("lblMode");
        Label lblCutting = (Label)e.Row.FindControl("lblCutting");
        Label lblFinishing = (Label)e.Row.FindControl("lblFinishing");

        if (lblMode.Text == "No. of Lines")
        {
          lblCutting.Visible = false;
          lblFinishing.Visible = false;
        }
      }
    }

    private void FillWorkerType()
    {
      dtStartDate = Convert.ToDateTime(ViewState["dtStartDate"]);
      dtEndDate = Convert.ToDateTime(ViewState["dtEndDate"]);

      DataTable dtWorkerType = new DataTable();
      if (pnlViewPanel.Visible)
      {
        dtWorkerType = objBuyingHouseController.GetBiplAlreadyCreatedBudgetWorkerTypeBAL(dtStartDate, dtEndDate, pnlViewPanel.Visible);
        gvWorkerType.DataSource = dtWorkerType;
        gvWorkerType.DataBind();
      }
      else
      {
        dtWorkerType = objBuyingHouseController.GetBiplWorkerTypeBAL();
        gvWorkerType.DataSource = dtWorkerType;
        gvWorkerType.DataBind();
      }      
      dvWorkerType.Visible = true;

      DataView dvStaffDept = new DataView(dtWorkerType);
      //dvStaffDept.RowFilter = "PartofMachineCount = 1";
      gvStaffDept.DataSource = dvStaffDept.ToTable(true, "StaffDept");
      gvStaffDept.DataBind();
    }

    protected void gvWorkerType_DataBound(object sender, EventArgs e)
    {
      for (int i = gvWorkerType.Rows.Count - 1; i > 0; i--)
      {
        DataTable dtWorkerType = objBuyingHouseController.GetBiplWorkerTypeBAL();
        DataView dvStaffDept = new DataView(dtWorkerType);

        GridViewRow row = gvWorkerType.Rows[i];
        GridViewRow previousRow = gvWorkerType.Rows[i - 1];

        Label lblStaffDept = (Label)row.Cells[0].FindControl("lblStaffDept");
        Label lblPreviousStaffDept = (Label)previousRow.Cells[0].FindControl("lblStaffDept");

        dvStaffDept.RowFilter = "StaffDept = '" + lblStaffDept.Text + "'";
        if (dvStaffDept.ToTable().Rows.Count < 6)
        {
          lblStaffDept.CssClass = "";
        }

        if (lblStaffDept.Text == lblPreviousStaffDept.Text)
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

    protected void gvWorkerType_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblStaffDept = (Label)e.Row.FindControl("lblStaffDept");
        Label lblWorkerType = (Label)e.Row.FindControl("lblWorkerType");
        string sDept = lblStaffDept.Text;
        string sWorkerType = lblWorkerType.Text;

        if (sDept == "z")
        {
          lblStaffDept.Text = "";
        }
        if (sWorkerType == "z")
        {
          lblWorkerType.Text = "Over Head";
        }
      }
    }

    protected void gvStaffDept_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblStaffDept = (Label)e.Row.FindControl("lblStaffDept");
        string sDept = lblStaffDept.Text;
        if (sDept == "z")
        {
          lblStaffDept.Text = "Over Head";
        }
      }
    }

    private void FillFactoryDetails(string sUnitName, DateTime dtStartDate, DateTime dtEndDate, decimal dAbsentism, decimal dWorkingHours, int iFromWeek, int iToWeek, string sFinancialYear)
    {
      DataTable dtFactoryDetails = objBuyingHouseController.GetBiplFactoryDetailsBAL(sUnitName, dtStartDate, dtEndDate, dAbsentism, dWorkingHours, iFromWeek, iToWeek, sFinancialYear, chkFinalize.Checked, UserId);
      if (sUnitName == "C 47")
      {
        gvFactoryDetails1.DataSource = dtFactoryDetails;
        gvFactoryDetails1.DataBind();
      }
      if (sUnitName == "C 45-46")
      {
        gvFactoryDetails2.DataSource = dtFactoryDetails;
        gvFactoryDetails2.DataBind();
      }
      //if (sUnitName == "B 45")
      //{
      //  gvFactoryDetails3.DataSource = dtFactoryDetails;
      //  gvFactoryDetails3.DataBind();
      //}
      if (sUnitName == "BIPL")
      {
        gvFactoryDetails4.DataSource = dtFactoryDetails;
        gvFactoryDetails4.DataBind();
      }
    }

    private void FillBudgetCPAMDetails(DateTime dtStartDate, DateTime dtEndDate, int iFromWeekNo, int iToWeekNo, decimal dWorkingHours, string sFactoryName)
    {
      DataTable dtBudgetCPAMDetails = objBuyingHouseController.GetBiplBudgetCPAMDetailsBAL(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo, dWorkingHours, sFactoryName);
      if (sFactoryName == "C 47")
      {
        gvCPAMFactory1.DataSource = dtBudgetCPAMDetails;
        gvCPAMFactory1.DataBind();
      }
      if (sFactoryName == "C 45-46")
      {
        gvCPAMFactory2.DataSource = dtBudgetCPAMDetails;
        gvCPAMFactory2.DataBind();
      }
      //if (sFactoryName == "B 45")
      //{
      //  gvCPAMFactory3.DataSource = dtBudgetCPAMDetails;
      //  gvCPAMFactory3.DataBind();
      //}
      if (sFactoryName == "")
      {
        gvCPAMFactory4.DataSource = dtBudgetCPAMDetails;
        gvCPAMFactory4.DataBind();
      }
    }

    private void FillBudgetMMRDetails(DateTime dtStartDate, DateTime dtEndDate)
    {
      DataTable dtBudgetMMRDetails = objBuyingHouseController.GetBiplBudgetMMRDetailsBAL(dtStartDate, dtEndDate);
      DataTable dtBudgetMMRDetailsChangeOrder = new DataTable();
      for (int i = 0; i <= dtBudgetMMRDetails.Rows.Count; i++)
      {
        dtBudgetMMRDetailsChangeOrder.Columns.Add();
      }
      for (int i = 0; i < dtBudgetMMRDetails.Columns.Count; i++)
      {
        dtBudgetMMRDetailsChangeOrder.Rows.Add();
        dtBudgetMMRDetailsChangeOrder.Rows[i][0] = dtBudgetMMRDetails.Columns[i].ColumnName;
      }
      for (int i = 0; i < dtBudgetMMRDetails.Columns.Count; i++)
      {
        for (int j = 0; j < dtBudgetMMRDetails.Rows.Count; j++)
        {
          dtBudgetMMRDetailsChangeOrder.Rows[i][j + 1] = dtBudgetMMRDetails.Rows[j][i];
        }
      }
      gvBudgetMMRDetails.DataSource = dtBudgetMMRDetailsChangeOrder;
      gvBudgetMMRDetails.DataBind();
    }

    protected void gvBudgetMMRDetails_rowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowIndex < 2)
      {
        e.Row.Visible = false;
      }

      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblHeader = (Label)e.Row.FindControl("lblHeader");
        Label lblUnitDetails1 = (Label)e.Row.FindControl("lblUnitDetails1");
        Label lblUnitDetails2 = (Label)e.Row.FindControl("lblUnitDetails2");
        Label lblUnitDetails3 = (Label)e.Row.FindControl("lblUnitDetails3");
        Label lblUnitDetails4 = (Label)e.Row.FindControl("lblUnitDetails4");

        if (lblHeader.Text == "Bud MMR")
        {
          lblUnitDetails1.Text = lblUnitDetails1.Text == "0.00" ? "" : lblUnitDetails1.Text;
          lblUnitDetails2.Text = lblUnitDetails2.Text == "0.00" ? "" : lblUnitDetails2.Text;
          lblUnitDetails3.Text = lblUnitDetails3.Text == "0.00" ? "" : lblUnitDetails3.Text;
          lblUnitDetails4.Text = lblUnitDetails4.Text == "0.00" ? "" : lblUnitDetails4.Text;
        }

        if (lblHeader.Text == "Total No. of Minutes (Lacs)")
        {
          lblUnitDetails1.ForeColor = System.Drawing.Color.Black;
          lblUnitDetails2.ForeColor = System.Drawing.Color.Black;
          lblUnitDetails3.ForeColor = System.Drawing.Color.Black;
          lblUnitDetails4.ForeColor = System.Drawing.Color.Black;

          lblUnitDetails1.Font.Bold = true;
          lblUnitDetails2.Font.Bold = true;
          lblUnitDetails3.Font.Bold = true;
          lblUnitDetails4.Font.Bold = true;

          lblUnitDetails1.Text = lblUnitDetails1.Text == "0.00" ? "" : Convert.ToDecimal(lblUnitDetails1.Text).ToString("#,#.##", CultureInfo.InvariantCulture) + " L";
          lblUnitDetails2.Text = lblUnitDetails2.Text == "0.00" ? "" : Convert.ToDecimal(lblUnitDetails2.Text).ToString("#,#.##", CultureInfo.InvariantCulture) + " L";
          lblUnitDetails3.Text = lblUnitDetails3.Text == "0.00" ? "" : Convert.ToDecimal(lblUnitDetails3.Text).ToString("#,#.##", CultureInfo.InvariantCulture) + " L";
          lblUnitDetails4.Text = lblUnitDetails4.Text == "0.00" ? "" : Convert.ToDecimal(lblUnitDetails4.Text).ToString("#,#.##", CultureInfo.InvariantCulture) + " L";
        }

        if (lblHeader.Text == "Total Ordered Quantity")
        {
          lblUnitDetails1.Text = Convert.ToInt32(lblUnitDetails1.Text).ToString("#,#", CultureInfo.InvariantCulture);
          lblUnitDetails2.Text = Convert.ToInt32(lblUnitDetails2.Text).ToString("#,#", CultureInfo.InvariantCulture);
          lblUnitDetails3.Text = Convert.ToInt32(lblUnitDetails3.Text).ToString("#,#", CultureInfo.InvariantCulture);
          lblUnitDetails4.Text = Convert.ToInt32(lblUnitDetails4.Text).ToString("#,#", CultureInfo.InvariantCulture);
        }

        if (lblHeader.Text == "Average SAM (Minutes)")
        {
          lblUnitDetails1.ForeColor = System.Drawing.Color.Black;
          lblUnitDetails2.ForeColor = System.Drawing.Color.Black;
          lblUnitDetails3.ForeColor = System.Drawing.Color.Black;
          lblUnitDetails4.ForeColor = System.Drawing.Color.Black;

          lblUnitDetails1.Font.Bold = true;
          lblUnitDetails2.Font.Bold = true;
          lblUnitDetails3.Font.Bold = true;
          lblUnitDetails4.Font.Bold = true;

          lblUnitDetails1.Text = lblUnitDetails1.Text == "0" ? "" : Convert.ToInt32(lblUnitDetails1.Text).ToString("#,#", CultureInfo.InvariantCulture);
          lblUnitDetails2.Text = lblUnitDetails2.Text == "0" ? "" : Convert.ToInt32(lblUnitDetails2.Text).ToString("#,#", CultureInfo.InvariantCulture);
          lblUnitDetails3.Text = lblUnitDetails3.Text == "0" ? "" : Convert.ToInt32(lblUnitDetails3.Text).ToString("#,#", CultureInfo.InvariantCulture);
          lblUnitDetails4.Text = lblUnitDetails4.Text == "0" ? "" : Convert.ToInt32(lblUnitDetails4.Text).ToString("#,#", CultureInfo.InvariantCulture);
        }

        if (lblHeader.Text == "Average CMT" || lblHeader.Text == "Average Budget CMT" || lblHeader.Text == "Average FOB Price")
        {
          lblUnitDetails1.ForeColor = System.Drawing.Color.FromName("#405D99");
          lblUnitDetails2.ForeColor = System.Drawing.Color.FromName("#405D99");
          lblUnitDetails3.ForeColor = System.Drawing.Color.FromName("#405D99");
          lblUnitDetails4.ForeColor = System.Drawing.Color.FromName("#405D99");

          lblUnitDetails1.Text = lblUnitDetails1.Text == "0.00" ? "" : "₹ " + Convert.ToDecimal(lblUnitDetails1.Text).ToString("#,#.##", CultureInfo.InvariantCulture);
          lblUnitDetails2.Text = lblUnitDetails2.Text == "0.00" ? "" : "₹ " + Convert.ToDecimal(lblUnitDetails2.Text).ToString("#,#.##", CultureInfo.InvariantCulture);
          lblUnitDetails3.Text = lblUnitDetails3.Text == "0.00" ? "" : "₹ " + Convert.ToDecimal(lblUnitDetails3.Text).ToString("#,#.##", CultureInfo.InvariantCulture);
          lblUnitDetails4.Text = lblUnitDetails4.Text == "0.00" ? "" : "₹ " + Convert.ToDecimal(lblUnitDetails4.Text).ToString("#,#.##", CultureInfo.InvariantCulture);
        }

        if (lblHeader.Text == "Sale FOB Value")
        {
          lblUnitDetails1.ForeColor = System.Drawing.Color.FromName("#405D99");
          lblUnitDetails2.ForeColor = System.Drawing.Color.FromName("#405D99");
          lblUnitDetails3.ForeColor = System.Drawing.Color.FromName("#405D99");
          lblUnitDetails4.ForeColor = System.Drawing.Color.FromName("#405D99");

          lblUnitDetails1.Text = lblUnitDetails1.Text == "0.00" ? "" : "₹ " + Convert.ToDecimal(lblUnitDetails1.Text).ToString("#,#.##", CultureInfo.InvariantCulture) + " L";
          lblUnitDetails2.Text = lblUnitDetails2.Text == "0.00" ? "" : "₹ " + Convert.ToDecimal(lblUnitDetails2.Text).ToString("#,#.##", CultureInfo.InvariantCulture) + " L";
          lblUnitDetails3.Text = lblUnitDetails3.Text == "0.00" ? "" : "₹ " + Convert.ToDecimal(lblUnitDetails3.Text).ToString("#,#.##", CultureInfo.InvariantCulture) + " L";
          lblUnitDetails4.Text = lblUnitDetails4.Text == "0.00" ? "" : "₹ " + Convert.ToDecimal(lblUnitDetails4.Text).ToString("#,#.##", CultureInfo.InvariantCulture) + " L";
        }

        if (lblHeader.Text == "Budgeted Break even efficiency (%)")
        {
          lblUnitDetails1.Text = Math.Round((Convert.ToDecimal(lblUnitDetails1.Text) * dCPAM4), 2).ToString() == "0.00" ? "" : Math.Round((Convert.ToDecimal(lblUnitDetails1.Text) * dCPAM4), 2).ToString() + "%";
          lblUnitDetails2.Text = Math.Round((Convert.ToDecimal(lblUnitDetails2.Text) * dCPAM4), 2).ToString() == "0.00" ? "" : Math.Round((Convert.ToDecimal(lblUnitDetails2.Text) * dCPAM4), 2).ToString() + "%";
          lblUnitDetails3.Text = Math.Round((Convert.ToDecimal(lblUnitDetails3.Text) * dCPAM4), 2).ToString() == "0.00" ? "" : Math.Round((Convert.ToDecimal(lblUnitDetails3.Text) * dCPAM4), 2).ToString() + "%";
          lblUnitDetails4.Text = Math.Round((Convert.ToDecimal(lblUnitDetails4.Text) * dCPAM4), 2).ToString() == "0.00" ? "" : Math.Round((Convert.ToDecimal(lblUnitDetails4.Text) * dCPAM4), 2).ToString() + "%";
        }

        if (lblHeader.Text == "Costed CMT %" || lblHeader.Text == "Budgeted CMT % to Sale")
        {
          lblUnitDetails1.Text = Math.Round((Convert.ToDecimal(lblUnitDetails1.Text))).ToString() == "0" ? "" : Math.Round((Convert.ToDecimal(lblUnitDetails1.Text))).ToString("#,#.##", CultureInfo.InvariantCulture) + "%";
          lblUnitDetails2.Text = Math.Round((Convert.ToDecimal(lblUnitDetails2.Text))).ToString() == "0" ? "" : Math.Round((Convert.ToDecimal(lblUnitDetails2.Text))).ToString("#,#.##", CultureInfo.InvariantCulture) + "%";
          lblUnitDetails3.Text = Math.Round((Convert.ToDecimal(lblUnitDetails3.Text))).ToString() == "0" ? "" : Math.Round((Convert.ToDecimal(lblUnitDetails3.Text))).ToString("#,#.##", CultureInfo.InvariantCulture) + "%";
          lblUnitDetails4.Text = Math.Round((Convert.ToDecimal(lblUnitDetails4.Text))).ToString() == "0" ? "" : Math.Round((Convert.ToDecimal(lblUnitDetails4.Text))).ToString("#,#.##", CultureInfo.InvariantCulture) + "%";
        }
      }
    }

    private void PreserveOldValues()
    {
      for (int i = 0; i < gvFactoryDetails1.Rows.Count; i++)
      {
        HiddenField hdnOldBudCount = (HiddenField)gvFactoryDetails1.Rows[i].FindControl("hdnOldBudCount");
        HiddenField hdnOldBudCost = (HiddenField)gvFactoryDetails1.Rows[i].FindControl("hdnOldBudCost");
        TextBox txtBudCount = (TextBox)gvFactoryDetails1.Rows[i].FindControl("txtBudCount");
        Label lblBudCost = (Label)gvFactoryDetails1.Rows[i].FindControl("lblBudCost");
        hdnOldBudCount.Value = txtBudCount.Text;
        hdnOldBudCost.Value = lblBudCost.Text;
      }

      for (int i = 0; i < gvFactoryDetails2.Rows.Count; i++)
      {
        HiddenField hdnOldBudCount = (HiddenField)gvFactoryDetails2.Rows[i].FindControl("hdnOldBudCount");
        HiddenField hdnOldBudCost = (HiddenField)gvFactoryDetails2.Rows[i].FindControl("hdnOldBudCost");
        TextBox txtBudCount = (TextBox)gvFactoryDetails2.Rows[i].FindControl("txtBudCount");
        Label lblBudCost = (Label)gvFactoryDetails2.Rows[i].FindControl("lblBudCost");
        hdnOldBudCount.Value = txtBudCount.Text;
        hdnOldBudCost.Value = lblBudCost.Text;
      }

      //for (int i = 0; i < gvFactoryDetails3.Rows.Count; i++)
      //{
      //  HiddenField hdnOldBudCount = (HiddenField)gvFactoryDetails3.Rows[i].FindControl("hdnOldBudCount");
      //  HiddenField hdnOldBudCost = (HiddenField)gvFactoryDetails3.Rows[i].FindControl("hdnOldBudCost");
      //  TextBox txtBudCount = (TextBox)gvFactoryDetails3.Rows[i].FindControl("txtBudCount");
      //  Label lblBudCost = (Label)gvFactoryDetails3.Rows[i].FindControl("lblBudCost");
      //  hdnOldBudCount.Value = txtBudCount.Text;
      //  hdnOldBudCost.Value = lblBudCost.Text;
      //}
    }

    private void GetCombinedBudgetDetails()
    {
      int iBudCount = 0;
      decimal dTotalBudCost = 0;

      for (int i = 0; i < gvFactoryDetails4.Rows.Count; i++)
      {
        Label lblBudCount = (Label)gvFactoryDetails4.Rows[i].FindControl("lblBudCount");
        Label lblBudCost = (Label)gvFactoryDetails4.Rows[i].FindControl("lblBudCost");

        lblBudCount.Text = lblBudCount.Text == "" ? "0" : lblBudCount.Text;
        lblBudCost.Text = lblBudCost.Text == "" ? "0.0" : lblBudCost.Text;

        if (lblBudCount.Text != "")
        {
          iBudCount = iBudCount + Convert.ToInt32(lblBudCount.Text.Replace(",",""));
        }

        dTotalBudCost = dTotalBudCost + Convert.ToDecimal(lblBudCost.Text.Replace("₹ ", "").Replace(" L", ""));

        if (lblBudCost.Text == "₹ 0.0 L")
        {
          lblBudCost.Text = "0.0";
        }
        lblBudCount.Text = lblBudCount.Text == "0" ? "" : Convert.ToInt32(lblBudCount.Text.Replace(",", "")).ToString("#,#", CultureInfo.InvariantCulture); ;
        lblBudCost.Text = lblBudCost.Text == "0.0" ? "" : lblBudCost.Text;
      }
      Label lblTotalBudCount = (Label)gvFactoryDetails4.FooterRow.FindControl("lblTotalBudCount");
      Label lblTotalBudCost = (Label)gvFactoryDetails4.FooterRow.FindControl("lblTotalBudCost");
      Label lblMonthlyTotalBudCount = (Label)gvFactoryDetails4.FooterRow.FindControl("lblMonthlyTotalBudCount");
      Label lblTotalMonthlyBudCost = (Label)gvFactoryDetails4.FooterRow.FindControl("lblTotalMonthlyBudCost");

      lblMonthlyTotalBudCount.Text = iBudCount > 0 ? iBudCount.ToString("##,###") : "0";
      dTotalBudCost = ((dTotalBudCost * 100000) / 10000000);
      lblTotalMonthlyBudCost.Text = "₹ " + Math.Round(dTotalBudCost, 2).ToString() + " CR";
      lblTotalBudCount.Text = iBudCount > 0 ? ((iBudCount / 4) * (iToWeekNo - iFromWeekNo + 1)).ToString("##,###") : "0";
      lblTotalBudCost.Text = "₹ " + Math.Round(((dTotalBudCost / 4) * (iToWeekNo - iFromWeekNo + 1)), 2).ToString() + " CR";
    }

    protected void txtBudCount1_TextChanged(object sender, EventArgs e)
    {
      int iTotalBudCount = 0;
      decimal dBudCost = 0;
      decimal dTotalBudCost = 0;

      dtStartDate = Convert.ToDateTime(ViewState["dtStartDate"]);
      dtEndDate = Convert.ToDateTime(ViewState["dtEndDate"]);
      iFromWeekNo = Convert.ToInt32(ViewState["FromWeekNo"]);
      iToWeekNo = Convert.ToInt32(ViewState["ToWeekNo"]);

      TextBox txt = sender as TextBox;
      string s = txt.Text;
      GridViewRow row = txt.NamingContainer as GridViewRow;
      int rowIndex = row.RowIndex;

      Label lblTotalBudCount = (Label)gvFactoryDetails1.FooterRow.FindControl("lblTotalBudCount");
      Label lblTotalBudCost = (Label)gvFactoryDetails1.FooterRow.FindControl("lblTotalBudCost");
      Label lblMonthlyTotalBudCount = (Label)gvFactoryDetails1.FooterRow.FindControl("lblMonthlyTotalBudCount");
      Label lblTotalMonthlyBudCost = (Label)gvFactoryDetails1.FooterRow.FindControl("lblTotalMonthlyBudCost");
      Label lblTotalBudPrdCost = (Label)gvFactoryDetails1.FooterRow.FindControl("lblTotalBudPrdCost");

      lblMonthlyTotalBudCount.Text = lblMonthlyTotalBudCount.Text == "" ? "0" : lblMonthlyTotalBudCount.Text;
      iTotalBudCount = Convert.ToInt32(lblMonthlyTotalBudCount.Text.Replace(",", ""));
      dTotalBudCost = Convert.ToDecimal(lblTotalMonthlyBudCost.Text.Replace("₹ ", "").Replace(" CR", ""));

      for (int i = 0; i < gvFactoryDetails1.Rows.Count; i++)
      {
        HiddenField hdnRowId = (HiddenField)gvFactoryDetails1.Rows[i].FindControl("hdnRowId");
        HiddenField hdnUnitId = (HiddenField)gvFactoryDetails1.Rows[i].FindControl("hdnUnitId");
        hdnRowId.Value = hdnRowId.Value == "" ? "0" : hdnRowId.Value;
        if (rowIndex == (Convert.ToInt32(hdnRowId.Value)) - 1)
        {
          HiddenField hdnWorkerTypeId = (HiddenField)gvFactoryDetails1.Rows[i].FindControl("hdnWorkerTypeId");
          HiddenField hdnValuesToBudCost = (HiddenField)gvFactoryDetails1.Rows[i].FindControl("hdnValuesToBudCost");
          HiddenField hdnOldBudCount = (HiddenField)gvFactoryDetails1.Rows[i].FindControl("hdnOldBudCount");
          HiddenField hdnOldBudCost = (HiddenField)gvFactoryDetails1.Rows[i].FindControl("hdnOldBudCost");

          TextBox txtBudCount1 = (TextBox)gvFactoryDetails1.Rows[i].FindControl("txtBudCount");
          TextBox txtBudCount2 = (TextBox)gvFactoryDetails2.Rows[i].FindControl("txtBudCount");
          //TextBox txtBudCount3 = (TextBox)gvFactoryDetails3.Rows[i].FindControl("txtBudCount");

          Label lblBudCount = (Label)gvFactoryDetails4.Rows[i].FindControl("lblBudCount");

          Label lblBudCost1 = (Label)gvFactoryDetails1.Rows[i].FindControl("lblBudCost");
          Label lblBudCost2 = (Label)gvFactoryDetails2.Rows[i].FindControl("lblBudCost");
          //Label lblBudCost3 = (Label)gvFactoryDetails3.Rows[i].FindControl("lblBudCost");
          Label lblBudCost4 = (Label)gvFactoryDetails4.Rows[i].FindControl("lblBudCost");

          lblBudCost1.Text = lblBudCost1.Text == "" ? "0.0" : lblBudCost1.Text;
          lblBudCost2.Text = lblBudCost2.Text == "" ? "0.0" : lblBudCost2.Text;
         // lblBudCost3.Text = lblBudCost3.Text == "" ? "0.0" : lblBudCost3.Text;
          lblBudCost4.Text = lblBudCost4.Text == "" ? "0.0" : lblBudCost4.Text;

          if (hdnValuesToBudCost.Value != "")
          {
            int iBudCount1 = txtBudCount1.Text == "" ? 0 : Convert.ToInt32(txtBudCount1.Text);
            int iBudCount2 = txtBudCount2.Text == "" ? 0 : Convert.ToInt32(txtBudCount2.Text);
           // int iBudCount3 = txtBudCount3.Text == "" ? 0 : Convert.ToInt32(txtBudCount3.Text);
            lblBudCount.Text = (iBudCount1 + iBudCount2 ).ToString();

            hdnOldBudCount.Value = hdnOldBudCount.Value == "" ? "0" : hdnOldBudCount.Value;
            iTotalBudCount = iTotalBudCount + iBudCount1 - Convert.ToInt32(hdnOldBudCount.Value);
            hdnOldBudCount.Value = txtBudCount1.Text;

            dBudCost = iBudCount1 * Convert.ToDecimal(hdnValuesToBudCost.Value);
            lblBudCost1.Text = (dBudCost > 0) ? "₹ " + Math.Round((dBudCost / 100000), 1).ToString() + " L" : "0.0";

            hdnOldBudCost.Value = hdnOldBudCost.Value == "" ? "0" : hdnOldBudCost.Value;

            dTotalBudCost = dTotalBudCost + (dBudCost / 10000000) - (((Convert.ToDecimal(hdnOldBudCost.Value.Replace("₹ ", "").Replace(" L", ""))) * 100000) / 10000000);
            hdnOldBudCost.Value = lblBudCost1.Text;

            lblBudCost4.Text = "₹ " + Math.Round((Convert.ToDecimal(lblBudCost1.Text.Replace("₹ ", "").Replace(" L", "")) + Convert.ToDecimal(lblBudCost2.Text.Replace("₹ ", "").Replace(" L", ""))), 1).ToString() + " L";

            if (lblBudCost4.Text == "₹  L")
            {
              lblBudCost4.Text = "₹ 0.0 L";
            }

            lblBudCost1.Text = lblBudCost1.Text == "0.0" ? "" : lblBudCost1.Text;
            lblBudCost2.Text = lblBudCost2.Text == "0.0" ? "" : lblBudCost2.Text;
          //  lblBudCost3.Text = lblBudCost3.Text == "0.0" ? "" : lblBudCost3.Text;
            lblBudCost4.Text = lblBudCost4.Text == "0.0" ? "" : lblBudCost4.Text;

            Label lblCalcCount = (Label)gvFactoryDetails1.Rows[i].FindControl("lblCalcCount");

            objBuyingHouseController.UpdateBudgetDetails(Convert.ToInt32(hdnRowId.Value), Convert.ToInt32(hdnWorkerTypeId.Value), Convert.ToInt32(hdnUnitId.Value), iFromWeekNo, iToWeekNo, iBudCount1, Math.Round((dBudCost / 100000), 1), 0, UserId);
          }
        }
      }
      
      lblMonthlyTotalBudCount.Text = iTotalBudCount > 0 ? iTotalBudCount.ToString("##,###") : "0";
      lblTotalMonthlyBudCost.Text = "₹ " + Math.Round(dTotalBudCost, 2).ToString() + " CR";
      lblTotalMonthlyBudCost.Text = lblTotalMonthlyBudCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalMonthlyBudCost.Text;

      lblTotalBudCount.Text = iTotalBudCount > 0 ? (iTotalBudCount / 4 * (iToWeekNo - iFromWeekNo + 1)).ToString("##,###") : "0";
      lblTotalBudCost.Text = "₹ " + Math.Round((dTotalBudCost / 4 * (iToWeekNo - iFromWeekNo + 1)), 2).ToString() + " CR";
      lblTotalBudCost.Text = lblTotalBudCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalBudCost.Text;
      lblTotalBudPrdCost.Text = "₹ " + Math.Round(dTotalBudCost, 2).ToString() + " CR";
      lblTotalBudPrdCost.Text = lblTotalBudPrdCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalBudPrdCost.Text;

      GetCombinedBudgetDetails();
      FillBudgetCPAMDetails(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo, Convert.ToDecimal(txtworkingHour.Text), "C 47");
      FillBudgetCPAMDetails(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo, Convert.ToDecimal(txtworkingHour.Text), "");
      FillBudgetMMRDetails(dtStartDate, dtEndDate);
    }

    protected void txtBudCount2_TextChanged(object sender, EventArgs e)
    {
      int iTotalBudCount = 0;
      decimal dBudCost = 0;
      decimal dTotalBudCost = 0;

      dtStartDate = Convert.ToDateTime(ViewState["dtStartDate"]);
      dtEndDate = Convert.ToDateTime(ViewState["dtEndDate"]);
      iFromWeekNo = Convert.ToInt32(ViewState["FromWeekNo"]);
      iToWeekNo = Convert.ToInt32(ViewState["ToWeekNo"]);

      TextBox txt = sender as TextBox;
      GridViewRow row = txt.NamingContainer as GridViewRow;
      int rowIndex = row.RowIndex;

      Label lblTotalBudCount = (Label)gvFactoryDetails2.FooterRow.FindControl("lblTotalBudCount");
      Label lblTotalBudCost = (Label)gvFactoryDetails2.FooterRow.FindControl("lblTotalBudCost");
      Label lblMonthlyTotalBudCount = (Label)gvFactoryDetails2.FooterRow.FindControl("lblMonthlyTotalBudCount");
      Label lblTotalMonthlyBudCost = (Label)gvFactoryDetails2.FooterRow.FindControl("lblTotalMonthlyBudCost");
      Label lblTotalBudPrdCost = (Label)gvFactoryDetails2.FooterRow.FindControl("lblTotalBudPrdCost");

      lblMonthlyTotalBudCount.Text = lblMonthlyTotalBudCount.Text == "" ? "0" : lblMonthlyTotalBudCount.Text;
      iTotalBudCount = Convert.ToInt32(lblMonthlyTotalBudCount.Text.Replace(",", ""));
      dTotalBudCost = Convert.ToDecimal(lblTotalMonthlyBudCost.Text.Replace("₹ ", "").Replace(" CR", ""));

      for (int i = 0; i < gvFactoryDetails2.Rows.Count; i++)
      {
        HiddenField hdnRowId = (HiddenField)gvFactoryDetails2.Rows[i].FindControl("hdnRowId");
        HiddenField hdnUnitId = (HiddenField)gvFactoryDetails2.Rows[i].FindControl("hdnUnitId");
        hdnRowId.Value = hdnRowId.Value == "" ? "0" : hdnRowId.Value;
        if (rowIndex == (Convert.ToInt32(hdnRowId.Value)) - 1)
        {
          HiddenField hdnWorkerTypeId = (HiddenField)gvFactoryDetails2.Rows[i].FindControl("hdnWorkerTypeId");
          HiddenField hdnValuesToBudCost = (HiddenField)gvFactoryDetails2.Rows[i].FindControl("hdnValuesToBudCost");
          HiddenField hdnOldBudCount = (HiddenField)gvFactoryDetails2.Rows[i].FindControl("hdnOldBudCount");
          HiddenField hdnOldBudCost = (HiddenField)gvFactoryDetails2.Rows[i].FindControl("hdnOldBudCost");

          TextBox txtBudCount1 = (TextBox)gvFactoryDetails1.Rows[i].FindControl("txtBudCount");
          TextBox txtBudCount2 = (TextBox)gvFactoryDetails2.Rows[i].FindControl("txtBudCount");
          //TextBox txtBudCount3 = (TextBox)gvFactoryDetails3.Rows[i].FindControl("txtBudCount");

          Label lblBudCount = (Label)gvFactoryDetails4.Rows[i].FindControl("lblBudCount");

          Label lblBudCost1 = (Label)gvFactoryDetails1.Rows[i].FindControl("lblBudCost");
          Label lblBudCost2 = (Label)gvFactoryDetails2.Rows[i].FindControl("lblBudCost");
          //Label lblBudCost3 = (Label)gvFactoryDetails3.Rows[i].FindControl("lblBudCost");
          Label lblBudCost4 = (Label)gvFactoryDetails4.Rows[i].FindControl("lblBudCost");

          lblBudCost1.Text = lblBudCost1.Text == "" ? "0.0" : lblBudCost1.Text;
          lblBudCost2.Text = lblBudCost2.Text == "" ? "0.0" : lblBudCost2.Text;
          //lblBudCost3.Text = lblBudCost3.Text == "" ? "0.0" : lblBudCost3.Text;
          lblBudCost4.Text = lblBudCost4.Text == "" ? "0.0" : lblBudCost4.Text;

          if (hdnValuesToBudCost.Value != "")
          {
            int iBudCount1 = txtBudCount1.Text == "" ? 0 : Convert.ToInt32(txtBudCount1.Text);
            int iBudCount2 = txtBudCount2.Text == "" ? 0 : Convert.ToInt32(txtBudCount2.Text);
            //int iBudCount3 = txtBudCount3.Text == "" ? 0 : Convert.ToInt32(txtBudCount3.Text);
           // lblBudCount.Text = (iBudCount1 + iBudCount2 + iBudCount3).ToString();
            lblBudCount.Text = (iBudCount1 + iBudCount2 ).ToString();

            hdnOldBudCount.Value = hdnOldBudCount.Value == "" ? "0" : hdnOldBudCount.Value;
            iTotalBudCount = iTotalBudCount + iBudCount2 - Convert.ToInt32(hdnOldBudCount.Value);
            hdnOldBudCount.Value = txtBudCount2.Text;

            dBudCost = iBudCount2 * Convert.ToDecimal(hdnValuesToBudCost.Value);
            lblBudCost2.Text = (dBudCost > 0) ? "₹ " + Math.Round((dBudCost / 100000), 1).ToString() + " L" : "0.0";

            hdnOldBudCost.Value = hdnOldBudCost.Value == "" ? "0" : hdnOldBudCost.Value;

            dTotalBudCost = dTotalBudCost + (dBudCost / 10000000) - (((Convert.ToDecimal(hdnOldBudCost.Value.Replace("₹ ", "").Replace(" L", ""))) * 100000) / 10000000);
            hdnOldBudCost.Value = lblBudCost2.Text;

            lblBudCost4.Text = "₹ " + Math.Round((Convert.ToDecimal(lblBudCost1.Text.Replace("₹ ", "").Replace(" L", "")) + Convert.ToDecimal(lblBudCost2.Text.Replace("₹ ", "").Replace(" L", ""))), 1).ToString() + " L";

            if (lblBudCost4.Text == "₹  L")
            {
              lblBudCost4.Text = "₹ 0.0 L";
            }

            lblBudCost1.Text = lblBudCost1.Text == "0.0" ? "" : lblBudCost1.Text;
            lblBudCost2.Text = lblBudCost2.Text == "0.0" ? "" : lblBudCost2.Text;
           // lblBudCost3.Text = lblBudCost3.Text == "0.0" ? "" : lblBudCost3.Text;
            lblBudCost4.Text = lblBudCost4.Text == "0.0" ? "" : lblBudCost4.Text;

            Label lblCalcCount = (Label)gvFactoryDetails2.Rows[i].FindControl("lblCalcCount");

            objBuyingHouseController.UpdateBudgetDetails(Convert.ToInt32(hdnRowId.Value), Convert.ToInt32(hdnWorkerTypeId.Value), Convert.ToInt32(hdnUnitId.Value), iFromWeekNo, iToWeekNo, iBudCount2, Math.Round((dBudCost / 100000), 1), 0, UserId);
          }
        }
      }

      lblMonthlyTotalBudCount.Text = iTotalBudCount > 0 ? iTotalBudCount.ToString("##,###") : "0";
      lblTotalMonthlyBudCost.Text = "₹ " + Math.Round(dTotalBudCost, 2).ToString() + " CR";
      lblTotalMonthlyBudCost.Text = lblTotalMonthlyBudCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalMonthlyBudCost.Text;

      lblTotalBudCount.Text = iTotalBudCount > 0 ? (iTotalBudCount / 4 * (iToWeekNo - iFromWeekNo + 1)).ToString("##,###") : "0";
      lblTotalBudCost.Text = "₹ " + Math.Round((dTotalBudCost / 4 * (iToWeekNo - iFromWeekNo + 1)), 2).ToString() + " CR";
      lblTotalBudCost.Text = lblTotalBudCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalBudCost.Text;
      lblTotalBudPrdCost.Text = "₹ " + Math.Round(dTotalBudCost, 2).ToString() + " CR";
      lblTotalBudPrdCost.Text = lblTotalBudPrdCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalBudPrdCost.Text;

      GetCombinedBudgetDetails();
      FillBudgetCPAMDetails(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo, Convert.ToDecimal(txtworkingHour.Text), "C 45-46");
      FillBudgetCPAMDetails(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo, Convert.ToDecimal(txtworkingHour.Text), "");
      FillBudgetMMRDetails(dtStartDate, dtEndDate);
    }

    //protected void txtBudCount3_TextChanged(object sender, EventArgs e)
    //{
    //  int iTotalBudCount = 0;
    //  decimal dBudCost = 0;
    //  decimal dTotalBudCost = 0;

    //  dtStartDate = Convert.ToDateTime(ViewState["dtStartDate"]);
    //  dtEndDate = Convert.ToDateTime(ViewState["dtEndDate"]);
    //  iFromWeekNo = Convert.ToInt32(ViewState["FromWeekNo"]);
    //  iToWeekNo = Convert.ToInt32(ViewState["ToWeekNo"]);

    //  TextBox txt = sender as TextBox;
    //  GridViewRow row = txt.NamingContainer as GridViewRow;
    //  int rowIndex = row.RowIndex;

    //  //Label lblTotalBudCount = (Label)gvFactoryDetails3.FooterRow.FindControl("lblTotalBudCount");
    //  Label lblTotalBudCost = (Label)gvFactoryDetails3.FooterRow.FindControl("lblTotalBudCost");
    //  Label lblMonthlyTotalBudCount = (Label)gvFactoryDetails3.FooterRow.FindControl("lblMonthlyTotalBudCount");
    //  Label lblTotalMonthlyBudCost = (Label)gvFactoryDetails3.FooterRow.FindControl("lblTotalMonthlyBudCost");
    //  Label lblTotalBudPrdCost = (Label)gvFactoryDetails3.FooterRow.FindControl("lblTotalBudPrdCost");

    //  lblMonthlyTotalBudCount.Text = lblMonthlyTotalBudCount.Text == "" ? "0" : lblMonthlyTotalBudCount.Text;
    //  iTotalBudCount = Convert.ToInt32(lblMonthlyTotalBudCount.Text.Replace(",", ""));
    //  dTotalBudCost = Convert.ToDecimal(lblTotalMonthlyBudCost.Text.Replace("₹ ", "").Replace(" CR", ""));

    //  for (int i = 0; i < gvFactoryDetails3.Rows.Count; i++)
    //  {
    //    HiddenField hdnRowId = (HiddenField)gvFactoryDetails3.Rows[i].FindControl("hdnRowId");
    //    HiddenField hdnUnitId = (HiddenField)gvFactoryDetails3.Rows[i].FindControl("hdnUnitId");
    //    hdnRowId.Value = hdnRowId.Value == "" ? "0" : hdnRowId.Value;
    //    if (rowIndex == (Convert.ToInt32(hdnRowId.Value)) - 1)
    //    {
    //      HiddenField hdnWorkerTypeId = (HiddenField)gvFactoryDetails3.Rows[i].FindControl("hdnWorkerTypeId");
    //      HiddenField hdnValuesToBudCost = (HiddenField)gvFactoryDetails3.Rows[i].FindControl("hdnValuesToBudCost");
    //      HiddenField hdnOldBudCount = (HiddenField)gvFactoryDetails3.Rows[i].FindControl("hdnOldBudCount");
    //      HiddenField hdnOldBudCost = (HiddenField)gvFactoryDetails3.Rows[i].FindControl("hdnOldBudCost");

    //      TextBox txtBudCount1 = (TextBox)gvFactoryDetails1.Rows[i].FindControl("txtBudCount");
    //      TextBox txtBudCount2 = (TextBox)gvFactoryDetails2.Rows[i].FindControl("txtBudCount");
    //      //TextBox txtBudCount3 = (TextBox)gvFactoryDetails3.Rows[i].FindControl("txtBudCount");

    //      Label lblBudCount = (Label)gvFactoryDetails4.Rows[i].FindControl("lblBudCount");

    //      Label lblBudCost1 = (Label)gvFactoryDetails1.Rows[i].FindControl("lblBudCost");
    //      Label lblBudCost2 = (Label)gvFactoryDetails2.Rows[i].FindControl("lblBudCost");
    //     // Label lblBudCost3 = (Label)gvFactoryDetails3.Rows[i].FindControl("lblBudCost");
    //      Label lblBudCost4 = (Label)gvFactoryDetails4.Rows[i].FindControl("lblBudCost");

    //      lblBudCost1.Text = lblBudCost1.Text == "" ? "0.0" : lblBudCost1.Text;
    //      lblBudCost2.Text = lblBudCost2.Text == "" ? "0.0" : lblBudCost2.Text;
    //    //  lblBudCost3.Text = lblBudCost3.Text == "" ? "0.0" : lblBudCost3.Text;
    //      lblBudCost4.Text = lblBudCost4.Text == "" ? "0.0" : lblBudCost4.Text;

    //      if (hdnValuesToBudCost.Value != "")
    //      {
    //        int iBudCount1 = txtBudCount1.Text == "" ? 0 : Convert.ToInt32(txtBudCount1.Text);
    //        int iBudCount2 = txtBudCount2.Text == "" ? 0 : Convert.ToInt32(txtBudCount2.Text);
    //       // int iBudCount3 = txtBudCount3.Text == "" ? 0 : Convert.ToInt32(txtBudCount3.Text);
    //        //lblBudCount.Text = (iBudCount1 + iBudCount2 + iBudCount3).ToString();
    //        lblBudCount.Text = (iBudCount1 + iBudCount2).ToString();

    //        hdnOldBudCount.Value = hdnOldBudCount.Value == "" ? "0" : hdnOldBudCount.Value;
    //        //iTotalBudCount = iTotalBudCount + iBudCount3 - Convert.ToInt32(hdnOldBudCount.Value);
    //        iTotalBudCount = iTotalBudCount + 0 - Convert.ToInt32(hdnOldBudCount.Value);
    //        //hdnOldBudCount.Value = txtBudCount3.Text;
    //        hdnOldBudCount.Value = "0";

    //        //dBudCost = iBudCount3 * Convert.ToDecimal(hdnValuesToBudCost.Value);
    //        dBudCost = 0 * Convert.ToDecimal(hdnValuesToBudCost.Value);
    //       // lblBudCost3.Text = (dBudCost > 0) ? "₹ " + Math.Round((dBudCost / 100000), 1).ToString() + " L" : "0.0";

    //        hdnOldBudCost.Value = hdnOldBudCost.Value == "" ? "0" : hdnOldBudCost.Value;

    //        dTotalBudCost = dTotalBudCost + (dBudCost / 10000000) - (((Convert.ToDecimal(hdnOldBudCost.Value.Replace("₹ ", "").Replace(" L", ""))) * 100000) / 10000000);
    //       // hdnOldBudCost.Value = lblBudCost3.Text;
    //        hdnOldBudCost.Value = "0";

    //        lblBudCost4.Text = "₹ " + Math.Round((Convert.ToDecimal(lblBudCost1.Text.Replace("₹ ", "").Replace(" L", "")) + Convert.ToDecimal(lblBudCost2.Text.Replace("₹ ", "").Replace(" L", "")) + Convert.ToDecimal(lblBudCost3.Text.Replace("₹ ", "").Replace(" L", ""))), 1).ToString() + " L";

    //        if (lblBudCost4.Text == "₹  L")
    //        {
    //          lblBudCost4.Text = "₹ 0.0 L";
    //        }

    //        lblBudCost1.Text = lblBudCost1.Text == "0.0" ? "" : lblBudCost1.Text;
    //        lblBudCost2.Text = lblBudCost2.Text == "0.0" ? "" : lblBudCost2.Text;
    //       // lblBudCost3.Text = lblBudCost3.Text == "0.0" ? "" : lblBudCost3.Text;
    //        lblBudCost4.Text = lblBudCost4.Text == "0.0" ? "" : lblBudCost4.Text;

    //        Label lblCalcCount = (Label)gvFactoryDetails3.Rows[i].FindControl("lblCalcCount");

    //        objBuyingHouseController.UpdateBudgetDetails(Convert.ToInt32(hdnRowId.Value), Convert.ToInt32(hdnWorkerTypeId.Value), Convert.ToInt32(hdnUnitId.Value), iFromWeekNo, iToWeekNo,0, Math.Round((dBudCost / 100000), 1), 0, UserId);
    //      }
    //    }
    //  }

    //  lblMonthlyTotalBudCount.Text = iTotalBudCount > 0 ? iTotalBudCount.ToString("##,###") : "0";
    //  lblTotalMonthlyBudCost.Text = "₹ " + Math.Round(dTotalBudCost, 2).ToString() + " CR";
    //  lblTotalMonthlyBudCost.Text = lblTotalMonthlyBudCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalMonthlyBudCost.Text;

    //  lblTotalBudCount.Text = iTotalBudCount > 0 ? (iTotalBudCount / 4 * (iToWeekNo - iFromWeekNo + 1)).ToString("##,###") : "0";
    //  lblTotalBudCost.Text = "₹ " + Math.Round((dTotalBudCost / 4 * (iToWeekNo - iFromWeekNo + 1)), 2).ToString() + " CR";
    //  lblTotalBudCost.Text = lblTotalBudCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalBudCost.Text;
    //  lblTotalBudPrdCost.Text = "₹ " + Math.Round(dTotalBudCost, 2).ToString() + " CR";
    //  lblTotalBudPrdCost.Text = lblTotalBudPrdCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalBudPrdCost.Text;

    //  GetCombinedBudgetDetails();
    // // FillBudgetCPAMDetails(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo, Convert.ToDecimal(txtworkingHour.Text), "B 45");
    //  FillBudgetCPAMDetails(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo, Convert.ToDecimal(txtworkingHour.Text), "");
    //  FillBudgetMMRDetails(dtStartDate, dtEndDate);
    //}

    protected void gvFactoryDetails1_RowCreated(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.Header)
      {
        GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        TableCell Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.Font.Size = 10;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Cost";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.Font.Size = 10;
        gvrow.Cells.Add(Cell);

        gvFactoryDetails1.Controls[0].Controls.AddAt(0, gvrow);
      }
    }

    int iTotalCalcCount1 = 0;
    int iTotalBudCount1 = 0;
    decimal dTotalCalcCost1 = 0;
    decimal dTotalBudCost1 = 0;
    
    decimal dTotalCostedPrdCost1 = 0;
    protected void gvFactoryDetails1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {     
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        HiddenField hdnValuesToBudCost = (HiddenField)e.Row.FindControl("hdnValuesToBudCost");
        TextBox txtBudCount = (TextBox)e.Row.FindControl("txtBudCount");
        Label lblCalcCount = (Label)e.Row.FindControl("lblCalcCount");
        if (Convert.ToDecimal(hdnValuesToBudCost.Value) > 0)
        {
          txtBudCount.Visible = true;
          lblCalcCount.Visible = true;

          lblCalcCount.Text = lblCalcCount.Text == "" ? "" : Convert.ToInt32(lblCalcCount.Text).ToString("#,#", CultureInfo.InvariantCulture);
        }
        else
        {
          txtBudCount.Visible = false;
          lblCalcCount.Visible = false;
        }
        iTotalCalcCount1 += DataBinder.Eval(e.Row.DataItem, "CalcCount").ToString() == "" ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CalcCount"));
        dTotalCalcCost1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CalcCost"));
        dTotalBudCost1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BudCost"));
        txtBudCount.Text = DataBinder.Eval(e.Row.DataItem, "BudCount").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "BudCount").ToString();
        iTotalBudCount1 += DataBinder.Eval(e.Row.DataItem, "BudCount").ToString() == "" ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BudCount"));

        dTotalCostedPrdCost1 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CostedProductionCost"));

        Label lblCalcCost = (Label)e.Row.FindControl("lblCalcCost");
        Label lblBudCost = (Label)e.Row.FindControl("lblBudCost");
        if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CalcCost")) > 0)
        {
          lblCalcCost.Text = "₹ " + DataBinder.Eval(e.Row.DataItem, "CalcCost").ToString() + " L";
        }
        if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BudCost")) > 0)
        {
          lblBudCost.Text = "₹ " + DataBinder.Eval(e.Row.DataItem, "BudCost").ToString() + " L";
        }
      }

      if (e.Row.RowType == DataControlRowType.Footer)
      {
        Label lblTotalCalcCount = (Label)e.Row.FindControl("lblTotalCalcCount");
        Label lblTotalBudCount = (Label)e.Row.FindControl("lblTotalBudCount");
        Label lblTotalCalcCost = (Label)e.Row.FindControl("lblTotalCalcCost");
        Label lblTotalBudCost = (Label)e.Row.FindControl("lblTotalBudCost");

        Label lblTotalMonthlyCalcCount = (Label)e.Row.FindControl("lblTotalMonthlyCalcCount");
        Label lblMonthlyTotalBudCount = (Label)e.Row.FindControl("lblMonthlyTotalBudCount");
        Label lblTotalMonthlyCalcCost = (Label)e.Row.FindControl("lblTotalMonthlyCalcCost");
        Label lblTotalMonthlyBudCost = (Label)e.Row.FindControl("lblTotalMonthlyBudCost");

        Label lblTotalCostedPrdCost = (Label)e.Row.FindControl("lblTotalCostedPrdCost");
        Label lblTotalBudPrdCost = (Label)e.Row.FindControl("lblTotalBudPrdCost");

        lblTotalMonthlyCalcCount.Text = iTotalCalcCount1.ToString("#,#", CultureInfo.InvariantCulture);
        lblTotalCalcCount.Text = ((iTotalCalcCount1 / 4) * (iToWeekNo - iFromWeekNo + 1)).ToString("#,#", CultureInfo.InvariantCulture);

        lblMonthlyTotalBudCount.Text = iTotalBudCount1.ToString("#,#", CultureInfo.InvariantCulture);
        lblTotalBudCount.Text = ((iTotalBudCount1 / 4) * (iToWeekNo - iFromWeekNo + 1)).ToString("#,#", CultureInfo.InvariantCulture);
        
        dTotalCalcCost1 = ((dTotalCalcCost1 * 100000) / 10000000);
        lblTotalMonthlyCalcCost.Text = "₹ " + Math.Round(dTotalCalcCost1, 2).ToString() + " CR";
        lblTotalMonthlyCalcCost.Text = lblTotalMonthlyCalcCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalMonthlyCalcCost.Text;

        lblTotalCalcCost.Text = "₹ " + Math.Round(((dTotalCalcCost1 / 4) * (iToWeekNo - iFromWeekNo + 1)), 2).ToString() + " CR";
        lblTotalCalcCost.Text = lblTotalCalcCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalCalcCost.Text;
        lblTotalCostedPrdCost.Text = "₹ " + dTotalCostedPrdCost1.ToString() + " CR";
        lblTotalCostedPrdCost.Text = lblTotalCostedPrdCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalCostedPrdCost.Text;

        dTotalBudCost1 = ((dTotalBudCost1 * 100000) / 10000000);     
        lblTotalMonthlyBudCost.Text = "₹ " + Math.Round(dTotalBudCost1, 2).ToString() + " CR";
        lblTotalMonthlyBudCost.Text = lblTotalMonthlyBudCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalMonthlyBudCost.Text;

        lblTotalBudCost.Text = "₹ " + Math.Round(((dTotalBudCost1 / 4) * (iToWeekNo - iFromWeekNo + 1)), 2).ToString() + " CR";
        lblTotalBudCost.Text = lblTotalBudCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalBudCost.Text;
        lblTotalBudPrdCost.Text = "₹ " + Math.Round(dTotalBudCost1, 2).ToString() + " CR";
        lblTotalBudPrdCost.Text = lblTotalBudPrdCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalBudPrdCost.Text;
      }
    }

    protected void gvFactoryDetails2_RowCreated(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.Header)
      {
        GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        TableCell Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.Font.Size = 10;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Cost";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.Font.Size = 10;
        gvrow.Cells.Add(Cell);

        gvFactoryDetails2.Controls[0].Controls.AddAt(0, gvrow);
      }
    }

    int iTotalCalcCount2 = 0;
    int iTotalBudCount2 = 0;
    decimal dTotalCalcCost2 = 0;
    decimal dTotalBudCost2 = 0;
   
    decimal dTotalCostedPrdCost2 = 0;
    protected void gvFactoryDetails2_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        HiddenField hdnValuesToBudCost = (HiddenField)e.Row.FindControl("hdnValuesToBudCost");
        TextBox txtBudCount = (TextBox)e.Row.FindControl("txtBudCount");
        Label lblCalcCount = (Label)e.Row.FindControl("lblCalcCount");
        if (Convert.ToDecimal(hdnValuesToBudCost.Value) > 0)
        {
          txtBudCount.Visible = true;
          lblCalcCount.Visible = true;

          lblCalcCount.Text = lblCalcCount.Text == "" ? "" : Convert.ToInt32(lblCalcCount.Text).ToString("#,#", CultureInfo.InvariantCulture);
        }
        else
        {
          txtBudCount.Visible = false;
          lblCalcCount.Visible = false;
        }
        iTotalCalcCount2 += DataBinder.Eval(e.Row.DataItem, "CalcCount").ToString() == "" ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CalcCount"));
        dTotalCalcCost2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CalcCost"));
        dTotalBudCost2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BudCost"));
        txtBudCount.Text = DataBinder.Eval(e.Row.DataItem, "BudCount").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "BudCount").ToString();
        iTotalBudCount2 += DataBinder.Eval(e.Row.DataItem, "BudCount").ToString() == "" ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BudCount"));

        dTotalCostedPrdCost2 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CostedProductionCost"));

        Label lblCalcCost = (Label)e.Row.FindControl("lblCalcCost");
        Label lblBudCost = (Label)e.Row.FindControl("lblBudCost");
        if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CalcCost")) > 0)
        {
          lblCalcCost.Text = "₹ " + DataBinder.Eval(e.Row.DataItem, "CalcCost").ToString() + " L";
        }
        if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BudCost")) > 0)
        {
          lblBudCost.Text = "₹ " + DataBinder.Eval(e.Row.DataItem, "BudCost").ToString() + " L";
        }
      }

      if (e.Row.RowType == DataControlRowType.Footer)
      {
        Label lblTotalCalcCount = (Label)e.Row.FindControl("lblTotalCalcCount");
        Label lblTotalBudCount = (Label)e.Row.FindControl("lblTotalBudCount");
        Label lblTotalCalcCost = (Label)e.Row.FindControl("lblTotalCalcCost");
        Label lblTotalBudCost = (Label)e.Row.FindControl("lblTotalBudCost");

        Label lblTotalMonthlyCalcCount = (Label)e.Row.FindControl("lblTotalMonthlyCalcCount");
        Label lblMonthlyTotalBudCount = (Label)e.Row.FindControl("lblMonthlyTotalBudCount");
        Label lblTotalMonthlyCalcCost = (Label)e.Row.FindControl("lblTotalMonthlyCalcCost");
        Label lblTotalMonthlyBudCost = (Label)e.Row.FindControl("lblTotalMonthlyBudCost");

        Label lblTotalCostedPrdCost = (Label)e.Row.FindControl("lblTotalCostedPrdCost");
        Label lblTotalBudPrdCost = (Label)e.Row.FindControl("lblTotalBudPrdCost");

        lblTotalMonthlyCalcCount.Text = iTotalCalcCount2.ToString("#,#", CultureInfo.InvariantCulture);
        lblTotalCalcCount.Text = ((iTotalCalcCount2 / 4) * (iToWeekNo - iFromWeekNo + 1)).ToString("#,#", CultureInfo.InvariantCulture);

        lblMonthlyTotalBudCount.Text = iTotalBudCount2.ToString("#,#", CultureInfo.InvariantCulture);
        lblTotalBudCount.Text = ((iTotalBudCount2 / 4) * (iToWeekNo - iFromWeekNo + 1)).ToString("#,#", CultureInfo.InvariantCulture);

        dTotalCalcCost2 = ((dTotalCalcCost2 * 100000) / 10000000);
        lblTotalMonthlyCalcCost.Text = "₹ " + Math.Round(dTotalCalcCost2, 2).ToString() + " CR";
        lblTotalMonthlyCalcCost.Text = lblTotalMonthlyCalcCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalMonthlyCalcCost.Text;

        lblTotalCalcCost.Text = "₹ " + Math.Round(((dTotalCalcCost2 / 4) * (iToWeekNo - iFromWeekNo + 1)), 2).ToString() + " CR";
        lblTotalCalcCost.Text = lblTotalCalcCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalCalcCost.Text;
        lblTotalCostedPrdCost.Text = "₹ " + dTotalCostedPrdCost2.ToString() + " CR";
        lblTotalCostedPrdCost.Text = lblTotalCostedPrdCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalCostedPrdCost.Text;

        dTotalBudCost2 = ((dTotalBudCost2 * 100000) / 10000000);
        lblTotalMonthlyBudCost.Text = "₹ " + Math.Round(dTotalBudCost2, 2).ToString() + " CR";
        lblTotalMonthlyBudCost.Text = lblTotalMonthlyBudCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalMonthlyBudCost.Text;

        lblTotalBudCost.Text = "₹ " + Math.Round(((dTotalBudCost2 / 4) * (iToWeekNo - iFromWeekNo + 1)), 2).ToString() + " CR";
        lblTotalBudCost.Text = lblTotalBudCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalBudCost.Text;
        lblTotalBudPrdCost.Text = "₹ " + Math.Round(dTotalBudCost2, 2).ToString() + " CR";
        lblTotalBudPrdCost.Text = lblTotalBudPrdCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalBudPrdCost.Text;
      }
    }

    //protected void gvFactoryDetails3_RowCreated(object sender, GridViewRowEventArgs e)
    //{
    //  if (e.Row.RowType == DataControlRowType.Header)
    //  {
    //    GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

    //    TableCell Cell = new TableCell();
    //    Cell.Text = "Man Power";
    //    Cell.HorizontalAlign = HorizontalAlign.Center;
    //    Cell.Font.Bold = true;
    //    Cell.ColumnSpan = 1;
    //    Cell.Font.Size = 10;
    //    gvrow.Cells.Add(Cell);

    //    Cell = new TableCell();
    //    Cell.Text = "Cost";
    //    Cell.HorizontalAlign = HorizontalAlign.Center;
    //    Cell.Font.Bold = true;
    //    Cell.ColumnSpan = 1;
    //    Cell.Font.Size = 10;
    //    gvrow.Cells.Add(Cell);

    //    gvFactoryDetails3.Controls[0].Controls.AddAt(0, gvrow);
    //  }
    //}

    
    
   
   
   
    
    //protected void gvFactoryDetails3_RowDataBound(Object sender, GridViewRowEventArgs e)
    //{
    //  if (e.Row.RowType == DataControlRowType.DataRow)
    //  {
    //    HiddenField hdnValuesToBudCost = (HiddenField)e.Row.FindControl("hdnValuesToBudCost");
    //    TextBox txtBudCount = (TextBox)e.Row.FindControl("txtBudCount");
    //    Label lblCalcCount = (Label)e.Row.FindControl("lblCalcCount");
    //    if (Convert.ToDecimal(hdnValuesToBudCost.Value) > 0)
    //    {
    //      txtBudCount.Visible = true;
    //      lblCalcCount.Visible = true;

    //      lblCalcCount.Text = lblCalcCount.Text == "" ? "" : Convert.ToInt32(lblCalcCount.Text).ToString("#,#", CultureInfo.InvariantCulture);
    //    }
    //    else
    //    {
    //      txtBudCount.Visible = false;
    //      lblCalcCount.Visible = false;
    //    }
    //    iTotalCalcCount3 += DataBinder.Eval(e.Row.DataItem, "CalcCount").ToString() == "" ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CalcCount"));
    //    dTotalCalcCost3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CalcCost"));
    //    dTotalBudCost3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BudCost"));
    //    txtBudCount.Text = DataBinder.Eval(e.Row.DataItem, "BudCount").ToString() == "0" ? "" : DataBinder.Eval(e.Row.DataItem, "BudCount").ToString();
    //    iTotalBudCount3 += DataBinder.Eval(e.Row.DataItem, "BudCount").ToString() == "" ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BudCount"));

    //    dTotalCostedPrdCost3 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CostedProductionCost"));

    //    Label lblCalcCost = (Label)e.Row.FindControl("lblCalcCost");
    //    Label lblBudCost = (Label)e.Row.FindControl("lblBudCost");
    //    if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CalcCost")) > 0)
    //    {
    //      lblCalcCost.Text = "₹ " + DataBinder.Eval(e.Row.DataItem, "CalcCost").ToString() + " L";
    //    }
    //    if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BudCost")) > 0)
    //    {
    //      lblBudCost.Text = "₹ " + DataBinder.Eval(e.Row.DataItem, "BudCost").ToString() + " L";
    //    }
    //  }

    //  if (e.Row.RowType == DataControlRowType.Footer)
    //  {
    //    Label lblTotalCalcCount = (Label)e.Row.FindControl("lblTotalCalcCount");
    //    Label lblTotalBudCount = (Label)e.Row.FindControl("lblTotalBudCount");
    //    Label lblTotalCalcCost = (Label)e.Row.FindControl("lblTotalCalcCost");
    //    Label lblTotalBudCost = (Label)e.Row.FindControl("lblTotalBudCost");

    //    Label lblTotalMonthlyCalcCount = (Label)e.Row.FindControl("lblTotalMonthlyCalcCount");
    //    Label lblMonthlyTotalBudCount = (Label)e.Row.FindControl("lblMonthlyTotalBudCount");
    //    Label lblTotalMonthlyCalcCost = (Label)e.Row.FindControl("lblTotalMonthlyCalcCost");
    //    Label lblTotalMonthlyBudCost = (Label)e.Row.FindControl("lblTotalMonthlyBudCost");

    //    Label lblTotalCostedPrdCost = (Label)e.Row.FindControl("lblTotalCostedPrdCost");
    //    Label lblTotalBudPrdCost = (Label)e.Row.FindControl("lblTotalBudPrdCost");

    //    lblTotalMonthlyCalcCount.Text = iTotalCalcCount3.ToString("#,#", CultureInfo.InvariantCulture);
    //    lblTotalCalcCount.Text = ((iTotalCalcCount3 / 4) * (iToWeekNo - iFromWeekNo + 1)).ToString("#,#", CultureInfo.InvariantCulture);

    //    lblMonthlyTotalBudCount.Text = iTotalBudCount3.ToString("#,#", CultureInfo.InvariantCulture);
    //    lblTotalBudCount.Text = ((iTotalBudCount3 / 4) * (iToWeekNo - iFromWeekNo + 1)).ToString("#,#", CultureInfo.InvariantCulture);

    //    dTotalCalcCost3 = ((dTotalCalcCost3 * 100000) / 10000000);
    //    lblTotalMonthlyCalcCost.Text = "₹ " + Math.Round(dTotalCalcCost3, 2).ToString() + " CR";
    //    lblTotalMonthlyCalcCost.Text = lblTotalMonthlyCalcCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalMonthlyCalcCost.Text;

    //    lblTotalCalcCost.Text = "₹ " + Math.Round(((dTotalCalcCost3 / 4) * (iToWeekNo - iFromWeekNo + 1)), 2).ToString() + " CR";
    //    lblTotalCalcCost.Text = lblTotalCalcCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalCalcCost.Text;
    //    lblTotalCostedPrdCost.Text = "₹ " + dTotalCostedPrdCost3.ToString() + " CR";
    //    lblTotalCostedPrdCost.Text = lblTotalCostedPrdCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalCostedPrdCost.Text;

    //    dTotalBudCost3 = ((dTotalBudCost3 * 100000) / 10000000);
    //    lblTotalMonthlyBudCost.Text = "₹ " + Math.Round(dTotalBudCost3, 2).ToString() + " CR";
    //    lblTotalMonthlyBudCost.Text = lblTotalMonthlyBudCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalMonthlyBudCost.Text;

    //    lblTotalBudCost.Text = "₹ " + Math.Round(((dTotalBudCost3 / 4) * (iToWeekNo - iFromWeekNo + 1)), 2).ToString() + " CR";
    //    lblTotalBudCost.Text = lblTotalBudCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalBudCost.Text;
    //    lblTotalBudPrdCost.Text = "₹ " + Math.Round(dTotalBudCost3, 2).ToString() + " CR";
    //    lblTotalBudPrdCost.Text = lblTotalBudPrdCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalBudPrdCost.Text;
    //  }
    //}

    protected void gvFactoryDetails4_RowCreated(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.Header)
      {
        GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        TableCell Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.Font.Size = 10;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Cost";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.Font.Size = 10;
        gvrow.Cells.Add(Cell);

        gvFactoryDetails4.Controls[0].Controls.AddAt(0, gvrow);
      }
    }

    int iTotalCalcCount4 = 0;
    int iTotalBudCount4 = 0;
    decimal dTotalCalcCost4 = 0;
    decimal dTotalBudCost4 = 0;
    
    decimal dTotalCostedPrdCost4 = 0;
    protected void gvFactoryDetails4_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblCalcCount = (Label)e.Row.FindControl("lblCalcCount");
        Label lblBudCount = (Label)e.Row.FindControl("lblBudCount");
        lblCalcCount.Text = lblCalcCount.Text == "" ? "" : Convert.ToInt32(lblCalcCount.Text).ToString("#,#", CultureInfo.InvariantCulture);
        lblBudCount.Text = lblBudCount.Text == "" ? "" : Convert.ToInt32(lblBudCount.Text).ToString("#,#", CultureInfo.InvariantCulture);

        iTotalCalcCount4 += DataBinder.Eval(e.Row.DataItem, "CalcCount").ToString() == "" ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CalcCount"));
        dTotalCalcCost4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CalcCost"));
        dTotalBudCost4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BudCost"));
        iTotalBudCount4 += DataBinder.Eval(e.Row.DataItem, "BudCount").ToString() == "" ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BudCount"));

        dTotalCostedPrdCost4 = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CostedProductionCost"));

        Label lblCalcCost = (Label)e.Row.FindControl("lblCalcCost");
        Label lblBudCost = (Label)e.Row.FindControl("lblBudCost");
        if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CalcCost")) > 0)
        {
          lblCalcCost.Text = "₹ " + DataBinder.Eval(e.Row.DataItem, "CalcCost").ToString() + " L";
        }
        if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "BudCost")) > 0)
        {
          lblBudCost.Text = "₹ " + DataBinder.Eval(e.Row.DataItem, "BudCost").ToString() + " L";
        }
      }

      if (e.Row.RowType == DataControlRowType.Footer)
      {
        Label lblTotalCalcCount = (Label)e.Row.FindControl("lblTotalCalcCount");
        Label lblTotalBudCount = (Label)e.Row.FindControl("lblTotalBudCount");
        Label lblTotalCalcCost = (Label)e.Row.FindControl("lblTotalCalcCost");
        Label lblTotalBudCost = (Label)e.Row.FindControl("lblTotalBudCost");

        Label lblTotalMonthlyCalcCount = (Label)e.Row.FindControl("lblTotalMonthlyCalcCount");
        Label lblMonthlyTotalBudCount = (Label)e.Row.FindControl("lblMonthlyTotalBudCount");
        Label lblTotalMonthlyCalcCost = (Label)e.Row.FindControl("lblTotalMonthlyCalcCost");
        Label lblTotalMonthlyBudCost = (Label)e.Row.FindControl("lblTotalMonthlyBudCost");

        Label lblTotalCostedPrdCost = (Label)e.Row.FindControl("lblTotalCostedPrdCost");
        Label lblTotalBudPrdCost = (Label)e.Row.FindControl("lblTotalBudPrdCost");

        lblTotalMonthlyCalcCount.Text = iTotalCalcCount4.ToString("#,#", CultureInfo.InvariantCulture);
        lblTotalCalcCount.Text = ((iTotalCalcCount4 / 4) * (iToWeekNo - iFromWeekNo + 1)).ToString("#,#", CultureInfo.InvariantCulture);

        lblMonthlyTotalBudCount.Text = iTotalBudCount4.ToString("#,#", CultureInfo.InvariantCulture);
        lblTotalBudCount.Text = ((iTotalBudCount4 / 4) * (iToWeekNo - iFromWeekNo + 1)).ToString("#,#", CultureInfo.InvariantCulture);

        dTotalCalcCost4 = ((dTotalCalcCost4 * 100000) / 10000000);
        lblTotalMonthlyCalcCost.Text = "₹ " + Math.Round(dTotalCalcCost4, 2).ToString() + " CR";
        lblTotalMonthlyCalcCost.Text = lblTotalMonthlyCalcCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalMonthlyCalcCost.Text;

        lblTotalCalcCost.Text = "₹ " + Math.Round(((dTotalCalcCost4 / 4) * (iToWeekNo - iFromWeekNo + 1)), 2).ToString() + " CR";
        lblTotalCalcCost.Text = lblTotalCalcCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalCalcCost.Text;
        lblTotalCostedPrdCost.Text = "₹ " + dTotalCostedPrdCost4.ToString() + " CR";
        lblTotalCostedPrdCost.Text = lblTotalCostedPrdCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalCostedPrdCost.Text;

        dTotalBudCost4 = ((dTotalBudCost4 * 100000) / 10000000);
        lblTotalMonthlyBudCost.Text = "₹ " + Math.Round(dTotalBudCost4, 2).ToString() + " CR";
        lblTotalMonthlyBudCost.Text = lblTotalMonthlyBudCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalMonthlyBudCost.Text;

        lblTotalBudCost.Text = "₹ " + Math.Round(((dTotalBudCost4 / 4) * (iToWeekNo - iFromWeekNo + 1)), 2).ToString() + " CR";
        lblTotalBudCost.Text = lblTotalBudCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalBudCost.Text;
        lblTotalBudPrdCost.Text = "₹ " + Math.Round(dTotalBudCost4, 2).ToString() + " CR";
        lblTotalBudPrdCost.Text = lblTotalBudPrdCost.Text == "₹  CR" ? "₹ 0.00 CR" : lblTotalBudPrdCost.Text;
      }
    }

    decimal dCPAM1 = 0, dCMTCost1 = 0;
    protected void gvCPAMFactory1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblCPAM = (Label)e.Row.FindControl("lblCPAM");
        Label lblCMTCost = (Label)e.Row.FindControl("lblCMTCost");

        dCPAM1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CPAM"));
        dCMTCost1 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CMTCost"));

        lblCPAM.Text = "₹ " + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CPAM")).ToString();
        e.Row.Cells[1].Text = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Share")).ToString() + "%";
        lblCMTCost.Text = "₹ " + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CMTCost")).ToString();

        lblCPAM.Text = lblCPAM.Text == "₹ 0.00" ? "" : lblCPAM.Text;
        e.Row.Cells[1].Text = e.Row.Cells[1].Text == "0%" ? "" : e.Row.Cells[1].Text;
        lblCMTCost.Text = lblCMTCost.Text == "₹ 0.00" ? "" : lblCMTCost.Text;
      }
      if (e.Row.RowType == DataControlRowType.Footer)
      {
        Label lblTotalCPAM = (Label)e.Row.FindControl("lblTotalCPAM");
        Label lblTotalCMTCost = (Label)e.Row.FindControl("lblTotalCMTCost");

        lblTotalCPAM.Text = "₹ " + dCPAM1.ToString();
        lblTotalCMTCost.Text = "₹ " + dCMTCost1.ToString();
      }
    }

    decimal dCPAM2 = 0, dCMTCost2 = 0;
    protected void gvCPAMFactory2_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblCPAM = (Label)e.Row.FindControl("lblCPAM");
        Label lblCMTCost = (Label)e.Row.FindControl("lblCMTCost");

        dCPAM2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CPAM"));
        dCMTCost2 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CMTCost"));

        lblCPAM.Text = "₹ " + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CPAM")).ToString();
        e.Row.Cells[1].Text = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Share")).ToString() + "%";
        lblCMTCost.Text = "₹ " + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CMTCost")).ToString();

        lblCPAM.Text = lblCPAM.Text == "₹ 0.00" ? "" : lblCPAM.Text;
        e.Row.Cells[1].Text = e.Row.Cells[1].Text == "0%" ? "" : e.Row.Cells[1].Text;
        lblCMTCost.Text = lblCMTCost.Text == "₹ 0.00" ? "" : lblCMTCost.Text;
      }
      if (e.Row.RowType == DataControlRowType.Footer)
      {
        Label lblTotalCPAM = (Label)e.Row.FindControl("lblTotalCPAM");
        Label lblTotalCMTCost = (Label)e.Row.FindControl("lblTotalCMTCost");

        lblTotalCPAM.Text = "₹ " + dCPAM2.ToString();
        lblTotalCMTCost.Text = "₹ " + dCMTCost2.ToString();
      }
    }

    decimal dCPAM3 = 0, dCMTCost3 = 0;
    protected void gvCPAMFactory3_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblCPAM = (Label)e.Row.FindControl("lblCPAM");
        Label lblCMTCost = (Label)e.Row.FindControl("lblCMTCost");

        dCPAM3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CPAM"));
        dCMTCost3 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CMTCost"));

        lblCPAM.Text = "₹ " + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CPAM")).ToString();
        e.Row.Cells[1].Text = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Share")).ToString() + "%";
        lblCMTCost.Text = "₹ " + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CMTCost")).ToString();

        lblCPAM.Text = lblCPAM.Text == "₹ 0.00" ? "" : lblCPAM.Text;
        e.Row.Cells[1].Text = e.Row.Cells[1].Text == "0%" ? "" : e.Row.Cells[1].Text;
        lblCMTCost.Text = lblCMTCost.Text == "₹ 0.00" ? "" : lblCMTCost.Text;
      }
      if (e.Row.RowType == DataControlRowType.Footer)
      {
        Label lblTotalCPAM = (Label)e.Row.FindControl("lblTotalCPAM");
        Label lblTotalCMTCost = (Label)e.Row.FindControl("lblTotalCMTCost");

        lblTotalCPAM.Text = "₹ " + dCPAM3.ToString();
        lblTotalCMTCost.Text = "₹ " + dCMTCost3.ToString();
      }
    }

    decimal dCPAM4 = 0, dCMTCost4 = 0;
    protected void gvCPAMFactory4_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        Label lblCPAM = (Label)e.Row.FindControl("lblCPAM");
        Label lblCMTCost = (Label)e.Row.FindControl("lblCMTCost");

        dCPAM4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CPAM"));
        dCMTCost4 += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CMTCost"));

        lblCPAM.Text = "₹ " + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CPAM")).ToString();
        e.Row.Cells[1].Text = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Share")).ToString() + "%";
        lblCMTCost.Text = "₹ " + Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "CMTCost")).ToString();

        lblCPAM.Text = lblCPAM.Text == "₹ 0.00" ? "" : lblCPAM.Text;
        e.Row.Cells[1].Text = e.Row.Cells[1].Text == "0%" ? "" : e.Row.Cells[1].Text;
        lblCMTCost.Text = lblCMTCost.Text == "₹ 0.00" ? "" : lblCMTCost.Text;
      }
      if (e.Row.RowType == DataControlRowType.Footer)
      {
        Label lblTotalCPAM = (Label)e.Row.FindControl("lblTotalCPAM");
        Label lblTotalCMTCost = (Label)e.Row.FindControl("lblTotalCMTCost");

        lblTotalCPAM.Text = "₹ " + dCPAM4.ToString();
        lblTotalCMTCost.Text = "₹ " + dCMTCost4.ToString();
      }
    }
  }
}