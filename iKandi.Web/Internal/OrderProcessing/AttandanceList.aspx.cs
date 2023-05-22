using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Drawing;
using iKandi.BLL;
using iKandi.Common;

namespace iKandi.Web.Internal.OrderProcessing
{
  public partial class AttandanceList : System.Web.UI.Page
  {
    DateTime dtStartDate = DateTime.Now, dtEndDate = DateTime.Now;
    string sDept = "", sWorkerType = "";

    BuyingHouseController objBuyingHouseController = new BuyingHouseController();

    protected void Page_Load(object sender, EventArgs e)
    {
      txtStartDate.Attributes.Add("readonly", "readonly");
      txtEndDate.Attributes.Add("readonly", "readonly");

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
        FillBudgetPeriodDetails();

        ddlDept.Items.Clear();
        ddlDept.Items.Insert(0, new ListItem("All", "0"));
        ddlDept.Enabled = false;

        ddlWorkerType.Items.Clear();
        ddlWorkerType.Items.Insert(0, new ListItem("All", "0"));
        ddlWorkerType.Enabled = false;
      }
    }

    private void FillBudgetPeriodDetails()
    {
      DataTable dtBudgetPeriod = new DataTable();

      ViewState["FillBudgetDetails"] = dtBudgetPeriod = objBuyingHouseController.FillBudgetDetailsBAL();
      DataView dv = new DataView(dtBudgetPeriod);
      ddlBudgetPeriod.DataSource = dv.ToTable(true, "FromWeekCount", "BudgetDetails");
      ddlBudgetPeriod.DataValueField = "FromWeekCount";
      ddlBudgetPeriod.DataTextField = "BudgetDetails";
      ddlBudgetPeriod.DataBind();
      ddlBudgetPeriod.Items.Insert(0, new ListItem("-- Select Budget --", "0"));
    }

    protected void ddlBudgetPeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
      string sStaffDept = "";
      if (Convert.ToInt32(ddlBudgetPeriod.SelectedValue) > 0)
      {
        DataTable dt = (DataTable)ViewState["FillBudgetDetails"];
        DataView dv = new DataView(dt);
        dv.RowFilter = "FromWeekCount = " + Convert.ToInt32(ddlBudgetPeriod.SelectedValue);

        ViewState["StartDate"] = dtStartDate = Convert.ToDateTime(dv.ToTable().Rows[0]["FromWeek"]);
        ViewState["EndDate"] = dtEndDate = Convert.ToDateTime(dv.ToTable().Rows[0]["ToWeek"]);
        hdnStartDate.Value = dtStartDate.ToString("dd/M/yyyy");
        hdnEndDate.Value = dtEndDate.ToString("dd/M/yyyy");

        txtStartDate.Text = hdnStartDate.Value;
        txtEndDate.Text = hdnEndDate.Value;

        FillDepartmentDetails();
        ddlDept.Enabled = true;
        FillWorkerTypeDetails(sStaffDept);
        ddlWorkerType.Enabled = true;

        CheckFactoryOTColumn();
        FillAttandanceList();
      }
      else
      {
        hdnStartDate.Value = txtStartDate.Text = "";
        hdnEndDate.Value = txtEndDate.Text = "";

        ddlDept.Items.Clear();
        ddlDept.Items.Insert(0, new ListItem("All", "0"));
        ddlDept.Enabled = false;

        ddlWorkerType.Items.Clear();
        ddlWorkerType.Items.Insert(0, new ListItem("All", "0"));
        ddlWorkerType.Enabled = false;

        gvAttandanceList.DataSource = null;
        gvAttandanceList.DataBind();
      }
    }

    protected void txtStartDate_TextChanged(object sender, EventArgs e)
    {
      CheckFactoryOTColumn();
      FillAttandanceList();
    }

    protected void txtEndDate_TextChanged(object sender, EventArgs e)
    {
      CheckFactoryOTColumn();
      FillAttandanceList();
    }

    private void FillDepartmentDetails()
    {
      DataTable dtDepartment = new DataTable();
      dtDepartment = objBuyingHouseController.FillDepartmentDetailsBAL();
      ddlDept.DataSource = dtDepartment;
      ddlDept.DataValueField = "Id";
      ddlDept.DataTextField = "StaffDept";
      ddlDept.DataBind();
      ddlDept.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
      string sStaffDept = "";
      if (Convert.ToInt32(ddlDept.SelectedValue) > 0)
      {
        sStaffDept = ddlDept.SelectedItem.Text;
        FillWorkerTypeDetails(sStaffDept);
      }
      else
      {
        FillWorkerTypeDetails(sStaffDept);
      }
      CheckFactoryOTColumn();
      FillAttandanceList();
    }

    private void FillWorkerTypeDetails(string sStaffDept)
    {
      DataTable dtWorkerType = new DataTable();
      dtWorkerType = objBuyingHouseController.FillWorkerTypeDetailsBAL(sStaffDept);
      ddlWorkerType.DataSource = dtWorkerType;
      ddlWorkerType.DataValueField = "FactoryWorkSpace";
      ddlWorkerType.DataTextField = "WorkerType";
      ddlWorkerType.DataBind();
      ddlWorkerType.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void ddlWorkerType_SelectedIndexChanged(object sender, EventArgs e)
    {
      CheckFactoryOTColumn();
      FillAttandanceList();
    }

    private void CheckFactoryOTColumn()
    {
      dtStartDate = Convert.ToDateTime(txtStartDate.Text, new CultureInfo("en-GB"));
      dtEndDate = Convert.ToDateTime(txtEndDate.Text, new CultureInfo("en-GB"));
      sDept = ddlDept.SelectedItem.Text;
      sWorkerType = ddlWorkerType.SelectedItem.Text;

      DataTable dtAttandanceList1 = objBuyingHouseController.GetAttandanceListBAL("C 47 (Check OT3-OT4)", dtStartDate, dtEndDate, sDept, sWorkerType);
      if (dtAttandanceList1.Rows.Count == 1)
      {
        if (Convert.ToInt32(dtAttandanceList1.Rows[0]["ManPower_OT3_C_47"]) == 0 && Convert.ToInt32(dtAttandanceList1.Rows[0]["TotalBudget_OT3_C_47"]) == 0)
        {
          hdnHideColumnC47OT3.Value = "false";
        }
        else
        {
          hdnHideColumnC47OT3.Value = "true";
        }

        if (Convert.ToInt32(dtAttandanceList1.Rows[0]["ManPower_OT4_C_47"]) == 0 && Convert.ToInt32(dtAttandanceList1.Rows[0]["TotalBudget_OT4_C_47"]) == 0)
        {
          hdnHideColumnC47OT4.Value = "false";
        }
        else
        {
          hdnHideColumnC47OT4.Value = "true";
        }
      }

      DataTable dtAttandanceList2 = objBuyingHouseController.GetAttandanceListBAL("C 45-46 (Check OT3-OT4)", dtStartDate, dtEndDate, sDept, sWorkerType);
      if (dtAttandanceList2.Rows.Count == 1)
      {
        if (Convert.ToInt32(dtAttandanceList2.Rows[0]["ManPower_OT3_C_45_46"]) == 0 && Convert.ToInt32(dtAttandanceList2.Rows[0]["TotalBudget_OT3_C_45_46"]) == 0)
        {
          hdnHideColumnC45_46OT3.Value = "false";
        }
        else
        {
          hdnHideColumnC45_46OT3.Value = "true";
        }

        if (Convert.ToInt32(dtAttandanceList2.Rows[0]["ManPower_OT4_C_45_46"]) == 0 && Convert.ToInt32(dtAttandanceList2.Rows[0]["TotalBudget_OT4_C_45_46"]) == 0)
        {
          hdnHideColumnC45_46OT4.Value = "false";
        }
        else
        {
          hdnHideColumnC45_46OT4.Value = "true";
        }
      }

      DataTable dtAttandanceList3 = objBuyingHouseController.GetAttandanceListBAL("B 45 (Check OT3-OT4)", dtStartDate, dtEndDate, sDept, sWorkerType);
      if (dtAttandanceList3.Rows.Count == 1)
      {
        if (Convert.ToInt32(dtAttandanceList3.Rows[0]["ManPower_OT3_B_45"]) == 0 && Convert.ToInt32(dtAttandanceList3.Rows[0]["TotalBudget_OT3_B_45"]) == 0)
        {
          hdnHideColumnB45OT3.Value = "false";
        }
        else
        {
          hdnHideColumnB45OT3.Value = "true";
        }

        if (Convert.ToInt32(dtAttandanceList3.Rows[0]["ManPower_OT4_B_45"]) == 0 && Convert.ToInt32(dtAttandanceList3.Rows[0]["TotalBudget_OT4_B_45"]) == 0)
        {
          hdnHideColumnB45OT4.Value = "false";
        }
        else
        {
          hdnHideColumnB45OT4.Value = "true";
        }
      }

      DataTable dtAttandanceList4 = objBuyingHouseController.GetAttandanceListBAL("BIPL (Check OT3-OT4)", dtStartDate, dtEndDate, sDept, sWorkerType);
      if (dtAttandanceList4.Rows.Count == 1)
      {
        if (Convert.ToInt32(dtAttandanceList4.Rows[0]["ManPower_OT3"]) == 0 && Convert.ToInt32(dtAttandanceList4.Rows[0]["TotalBudget_OT3"]) == 0)
        {
          hdnHideColumnBIPLOT3.Value = "false";
        }
        else
        {
          hdnHideColumnBIPLOT3.Value = "true";
        }

        if (Convert.ToInt32(dtAttandanceList4.Rows[0]["ManPower_OT4"]) == 0 && Convert.ToInt32(dtAttandanceList4.Rows[0]["TotalBudget_OT4"]) == 0)
        {
          hdnHideColumnBIPLOT4.Value = "false";
        }
        else
        {
          hdnHideColumnBIPLOT4.Value = "true";
        }
      }
    }

    private void FillAttandanceList()
    {
      dtStartDate = Convert.ToDateTime(txtStartDate.Text, new CultureInfo("en-GB"));
      dtEndDate = Convert.ToDateTime(txtEndDate.Text, new CultureInfo("en-GB"));
      sDept = ddlDept.SelectedItem.Text;
      sWorkerType = ddlWorkerType.SelectedItem.Text;

      DataTable dtAttandanceList1 = objBuyingHouseController.GetAttandanceListBAL("C 47", dtStartDate, dtEndDate, sDept, sWorkerType);
      DataTable dtAttandanceList2 = objBuyingHouseController.GetAttandanceListBAL("C 45-46", dtStartDate, dtEndDate, sDept, sWorkerType);
      DataTable dtAttandanceList3 = objBuyingHouseController.GetAttandanceListBAL("B 45", dtStartDate, dtEndDate, sDept, sWorkerType);
      DataTable dtAttandanceList4 = objBuyingHouseController.GetAttandanceListBAL("", dtStartDate, dtEndDate, sDept, sWorkerType);

      DataTable dt = new DataTable();

      dt = MergeDataTables(dtAttandanceList1, dtAttandanceList2, dtAttandanceList3, dtAttandanceList4);

      gvAttandanceList.DataSource = dt;
      gvAttandanceList.DataBind();
    }

    protected void gvAttandanceList_DataBound(object sender, EventArgs e)
    {
      for (int i = gvAttandanceList.Rows.Count - 1; i > 0; i--)
      {
        GridViewRow row = gvAttandanceList.Rows[i];
        GridViewRow previousRow = gvAttandanceList.Rows[i - 1];

        Label lblAttandenceDate = (Label)row.Cells[0].FindControl("lblAttandenceDate");
        Label lblPreviousAttandenceDate = (Label)previousRow.Cells[0].FindControl("lblAttandenceDate");

        if (lblAttandenceDate.Text == lblPreviousAttandenceDate.Text)
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

    static DataTable MergeDataTables(DataTable dt1, DataTable dt2, DataTable dt3, DataTable dt4)
    {
        DataTable dtFinal = new DataTable();

        foreach (DataColumn dc in dt1.Columns)
        {
            dtFinal.Columns.Add(dc.ColumnName).DataType = dc.DataType;
        }

        foreach (DataColumn dc in dt2.Columns)
        {
            dtFinal.Columns.Add(dc.ColumnName).DataType = dc.DataType;
        }

        foreach (DataColumn dc in dt3.Columns)
        {
            dtFinal.Columns.Add(dc.ColumnName).DataType = dc.DataType;
        }

        foreach (DataColumn dc in dt4.Columns)
        {
            dtFinal.Columns.Add(dc.ColumnName).DataType = dc.DataType;
        }

        for (int i = 0; i < dt1.Rows.Count; i++)
        {
            DataRow dr = dtFinal.NewRow();
            foreach (DataColumn dc in dt1.Columns)
            {
                string col = dc.ColumnName;
                dr[col] = dt1.Rows[i][col];
            }

            foreach (DataColumn dc in dt2.Columns)
            {
                string col = dc.ColumnName;
                if (dt2.Rows.Count > i)
                    dr[col] = dt2.Rows[i][col];
                else
                    dr[col] = "0";

            }

            foreach (DataColumn dc in dt3.Columns)
            {
                string col = dc.ColumnName;
                if (dt3.Rows.Count > i)
                    dr[col] = dt3.Rows[i][col];
                else
                    dr[col] = "0";
            }

            foreach (DataColumn dc in dt4.Columns)
            {
                string col = dc.ColumnName;
                if (dt3.Rows.Count > i)
                    dr[col] = dt4.Rows[i][col];
                else
                    dr[col] = "0";
            }
            dtFinal.Rows.Add(dr);
        }

        return dtFinal;
    }

    private string GetAttandanceSummary(string sFactoryName)
    {
      string sAttandanceSummary = "";
      DataTable dt = objBuyingHouseController.GetAttandanceSummaryBAL(sFactoryName, Convert.ToDateTime(ViewState["StartDate"]), Convert.ToDateTime(ViewState["EndDate"]));

      if (dt.Rows.Count == 1)
      {
          sAttandanceSummary = "<span style='font-size: 9pt'><span style='color: #0F18BD'>Total Budget:</span> " + dt.Rows[0]["TotalBudget"].ToString() + " Hrs (" + dt.Rows[0]["TotalBudgetCost"].ToString() + " Cr), <span style='color:#0F18BD'>Total Consumed:</span> " + dt.Rows[0]["TotalConsumed"].ToString() + " Hrs (" + dt.Rows[0]["TotalConsumedCost"].ToString() + " Cr),<br /><span style='color:#0F18BD'>Per Day Budget:</span> " + dt.Rows[0]["PerDayBudget"].ToString() + " Hrs (" + dt.Rows[0]["PerDayBudgetCost"].ToString() + " L), <span style='color:#0F18BD'>Avg. Per Day Consumed:</span> " + dt.Rows[0]["PerDayConsumed"].ToString() + " Hrs (" + dt.Rows[0]["PerDayConsumedCost"].ToString() + " L)</span>";
      }

      return sAttandanceSummary;
    }

    protected void gvAttandanceList_RowCreated(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.Header)
      {
        GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        TableCell Cell = new TableCell();
        Cell.Text = "Date";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.FromName("#dddfe4");
        Cell.ForeColor = Color.FromName("#575759");
        Cell.Font.Size = 15;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Worker Type";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.FromName("#dddfe4");
        Cell.ForeColor = Color.FromName("#575759");
        Cell.Font.Size = 15;
        gvrow.Cells.Add(Cell);
        
        ////////////////////////////////////////////////////////////////////////////////////////////

        Label lblAttandanceSummary = new Label();

        int iColumnSpan1 = 0;
        if (hdnHideColumnC47OT3.Value == "false")
        {
          iColumnSpan1 = iColumnSpan1 + 2;
        }
        if (hdnHideColumnC47OT4.Value == "false")
        {
          iColumnSpan1 = iColumnSpan1 + 2;
        }

        lblAttandanceSummary.Text = GetAttandanceSummary("C 47");
        Cell = new TableCell();
        Cell.Controls.Add(lblAttandanceSummary);
        Cell.Text = "C 47 " + lblAttandanceSummary.Text;
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 9 - iColumnSpan1;
        Cell.BackColor = Color.FromName("#dddfe4");
        Cell.ForeColor = Color.FromName("#575759");
        Cell.Font.Size = 15;
        gvrow.Cells.Add(Cell);

        ////////////////////////////////////////////////////////////////////////////////////////////

        int iColumnSpan2 = 0;
        if (hdnHideColumnC45_46OT3.Value == "false")
        {
          iColumnSpan2 = iColumnSpan2 + 2;
        }
        if (hdnHideColumnC45_46OT4.Value == "false")
        {
          iColumnSpan2 = iColumnSpan2 + 2;
        }

        lblAttandanceSummary.Text = GetAttandanceSummary("C 45-46");
        Cell = new TableCell();
        Cell.Text = "C 45-46 " + lblAttandanceSummary.Text;
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 9 - iColumnSpan2;
        Cell.BackColor = Color.FromName("#dddfe4");
        Cell.ForeColor = Color.FromName("#575759");
        Cell.Font.Size = 15;
        gvrow.Cells.Add(Cell);

        ////////////////////////////////////////////////////////////////////////////////////////////

        int iColumnSpan3 = 0;
        if (hdnHideColumnB45OT3.Value == "false")
        {
          iColumnSpan3 = iColumnSpan3 + 2;
        }
        if (hdnHideColumnB45OT4.Value == "false")
        {
          iColumnSpan3 = iColumnSpan3 + 2;
        }

        lblAttandanceSummary.Text = GetAttandanceSummary("B 45");
        Cell = new TableCell();
        Cell.Text = "B 45 " + lblAttandanceSummary.Text;
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 9 - iColumnSpan3;
        Cell.BackColor = Color.FromName("#dddfe4");
        Cell.ForeColor = Color.FromName("#575759");
        Cell.Font.Size = 15;
        gvrow.Cells.Add(Cell);

        ////////////////////////////////////////////////////////////////////////////////////////////

        int iColumnSpan4 = 0;
        if (hdnHideColumnBIPLOT3.Value == "false")
        {
          iColumnSpan4 = iColumnSpan4 + 2;
        }
        if (hdnHideColumnBIPLOT4.Value == "false")
        {
          iColumnSpan4 = iColumnSpan4 + 2;
        }

        lblAttandanceSummary.Text = GetAttandanceSummary("");
        Cell = new TableCell();
        Cell.Text = "BIPL " + lblAttandanceSummary.Text;
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 9 - iColumnSpan4;
        Cell.BackColor = Color.FromName("#dddfe4");
        Cell.ForeColor = Color.FromName("#575759");
        Cell.Font.Size = 15;
        gvrow.Cells.Add(Cell);     

        gvAttandanceList.Controls[0].Controls.AddAt(0, gvrow);

        ////////////////////////////////////////////////////////////////////////////////////////////

        gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        Cell = new TableCell();
        Cell.Text = "";
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#7E7E7E");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "";
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#7E7E7E");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Normal";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT1";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT2";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT3";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.Font.Size = 13;
        Cell.CssClass = "C47OT3";
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT4";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.Font.Size = 13;
        Cell.CssClass = "C47OT4";
        gvrow.Cells.Add(Cell);

        ////////////////////////////////////////////////////////////////////////////////////////////

        Cell = new TableCell();
        Cell.Text = "Normal";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT1";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT2";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT3";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.Font.Size = 13;
        Cell.CssClass = "C45_46OT3";
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT4";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "C45_46OT4";
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        ////////////////////////////////////////////////////////////////////////////////////////////

        Cell = new TableCell();
        Cell.Text = "Normal";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT1";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT2";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT3";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "B45OT3";
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT4";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "B45OT4";
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        ////////////////////////////////////////////////////////////////////////////////////////////

        Cell = new TableCell();
        Cell.Text = "Normal";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT1";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT2";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT3";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "BIPLOT3";
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "OT4";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.ColumnSpan = 2;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "BIPLOT4";
        Cell.Font.Size = 13;
        gvrow.Cells.Add(Cell);

        gvAttandanceList.Controls[0].Controls.AddAt(1, gvrow);

        gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        Cell = new TableCell();
        Cell.Text = "";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#7E7E7E");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#7E7E7E");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "C47OT3";
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "C47OT3";
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "C47OT4";
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.CssClass = "C47OT4";
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        ////////////////////////////////////////////////////////////////////////////////////////////

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "C45_46OT3";
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "C45_46OT3";
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "C45_46OT4";
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "C45_46OT4";
        gvrow.Cells.Add(Cell);

        ////////////////////////////////////////////////////////////////////////////////////////////

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "B45OT3";
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "B45OT3";
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "B45OT4";
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "B45OT4";
        gvrow.Cells.Add(Cell);

        ////////////////////////////////////////////////////////////////////////////////////////////

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "BIPLOT3";
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "BIPLOT3";
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Man Power";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "BIPLOT4";
        gvrow.Cells.Add(Cell);

        Cell = new TableCell();
        Cell.Text = "Total Hours";
        Cell.HorizontalAlign = HorizontalAlign.Center;
        Cell.Font.Bold = true;
        Cell.ColumnSpan = 1;
        Cell.BackColor = Color.White;
        Cell.ForeColor = Color.FromName("#405D99");
        Cell.CssClass = "BIPLOT4";
        gvrow.Cells.Add(Cell);

        gvAttandanceList.Controls[0].Controls.AddAt(2, gvrow);
      }
    }

    protected void gvAttandanceList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == DataControlRowType.DataRow)
      {
        HyperLink hlEdit = (HyperLink)e.Row.FindControl("hlEdit");
        HiddenField hdnAttandenceDate = (HiddenField)e.Row.FindControl("hdnAttandenceDate");

        if (hdnAttandenceDate != null)
        {
          if (hdnAttandenceDate.Value != "")
          {
            DateTime dtDate = Convert.ToDateTime(hdnAttandenceDate.Value, new CultureInfo("en-GB"));

            if (objBuyingHouseController.CheckLatestBudgetBAL(dtDate) == Convert.ToDateTime(hdnStartDate.Value, new CultureInfo("en-GB")))
            {
              if (dtDate.Date == DateTime.Today.Date)
              {
                hlEdit.Enabled = true;
              }
              if (DateTime.Today.AddDays(-1).DayOfWeek.ToString() == "Sunday" && dtDate == DateTime.Today.AddDays(-2).Date)
              {
                hlEdit.Enabled = true;
              }
              if (dtDate == DateTime.Today.AddDays(-1).Date)
              {
                hlEdit.Enabled = true;
              }
            }
            else
            {
              hlEdit.Enabled = false;
            }
          }
        }

        //if (e.Row.Cells.Count)
        for (int i = 0; i < e.Row.Cells.Count; i++)
        {
          if (e.Row.Cells[i].Text == "0" || e.Row.Cells[i].Text == "0 (0.00)")
          {
            e.Row.Cells[i].Text = "";
          }
        }
      }
    }
  }
}