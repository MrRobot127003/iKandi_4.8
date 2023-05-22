using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.Common;
using System.Data;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.Internal.OrderProcessing
{
    public partial class MMR_Reports_DateRange : System.Web.UI.Page
    {
        DateTime dtStartDate = DateTime.Now, dtEndDate = DateTime.Now;

        string sFinancialYear = "";
        BuyingHouseController objBuyingHouseController = new BuyingHouseController();
        double TotalManPowerBudget = 0;
        double TotalManPowerActual = 0;
        double CPAMBudget1 = 0;
        double CPAMActual1 = 0;

        double CPAMBudget2 = 0;
        double CPAMActual2 = 0;

        double CPAMBudget3 = 0;
        double CPAMActual3 = 0;

        double CPAMBudget4 = 0;
        double CPAMActual4 = 0;

        double TotalCostBudget = 0;
        double TotalCostActual = 0;
        string WorkingDays = "";
        string WorkingHrs = "";
        double FactoryCost1 = 0;
        double FactoryCost2 = 0;
        double FactoryCost3 = 0;

        double OverHead1 = 0;
        double OverHead2 = 0;
        double OverHead3 = 0;
        double OverHead4 = 0;

        double ActualTotal1 = 0;
        double ActualTotal2 = 0;
        double ActualTotal3 = 0;
        double ActualTotal4 = 0;

        double TotalManPowerBudget1 = 0;
        double TotalManPowerBudget2 = 0;
        double TotalManPowerBudget3 = 0;
        double TotalManPowerBudget4 = 0;

        double BudgetwithMachine1 = 0;
        double BudgetwithMachine2 = 0;
        double BudgetwithMachine3 = 0;
        double BudgetwithMachine4 = 0;

        double TotalManPowerActual1 = 0;
        double TotalManPowerActual2 = 0;
        double TotalManPowerActual3 = 0;
        double TotalManPowerActual4 = 0;

        double ActualwithMachine1 = 0;
        double ActualwithMachine2 = 0;
        double ActualwithMachine3 = 0;
        double ActualwithMachine4 = 0;

        double DateRange = 0;
        double AvailMinsActual = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDateFrom.Attributes.Add("readonly", "readonly");
                txtworkingHour.Attributes.Add("readonly", "readonly");

                dtStartDate = DateTime.Now.Date;
                dtEndDate = DateTime.Now.Date;
                lblDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)") + " To " + DateTime.Now.ToString("dd MMM yy (ddd)");
                WorkingDays = objBuyingHouseController.GetWorkingDays_BAL();

                WorkingHrs = objBuyingHouseController.GetMMR_WorkingHours_BAL(dtStartDate, dtEndDate);

                if (WorkingHrs != "")
                {
                    txtworkingHour.Text = WorkingHrs;
                }

                // Fill Budget Summary

                FillBudgetFactoryUnitName();
                FillBudgetSummaryStaffDept("", dtStartDate, dtEndDate, sFinancialYear);

                FillBudgetSummary("C 47", dtStartDate, dtEndDate, sFinancialYear);
                FillBudgetSummary("C 45-46", dtStartDate, dtEndDate, sFinancialYear);
                FillBudgetSummary("B 45", dtStartDate, dtEndDate, sFinancialYear);                
                FillBudgetSummary("BIPL", dtStartDate, dtEndDate, sFinancialYear);

                FillUnitName();
                FillWorkerType("", dtStartDate, dtEndDate, sFinancialYear);                

                FillFactoryDetails("C 47", dtStartDate, dtEndDate, sFinancialYear);
                FillFactoryDetails("C 45-46", dtStartDate, dtEndDate, sFinancialYear);
                FillFactoryDetails("B 45", dtStartDate, dtEndDate, sFinancialYear);                
                FillFactoryDetails("BIPL", dtStartDate, dtEndDate, sFinancialYear);

                // Fill CMT Data FillCMTReports 

                FillCMTUnitName();
                FillStaffDept("", dtStartDate, dtEndDate, sFinancialYear);

                FillCMTReports("C 47", dtStartDate, dtEndDate, sFinancialYear);
                FillCMTReports("C 45-46", dtStartDate, dtEndDate, sFinancialYear);
                FillCMTReports("B 45", dtStartDate, dtEndDate, sFinancialYear);                
                FillCMTReports("BIPL", dtStartDate, dtEndDate, sFinancialYear);

                // Fill MMR Summary

                FillMMRFactoryUnitName();
                FillMMRSummaryStaff("", dtStartDate, dtEndDate, sFinancialYear);

                FillMMRSummary("C 47", dtStartDate, dtEndDate, sFinancialYear);
                FillMMRSummary("C 45-46", dtStartDate, dtEndDate, sFinancialYear);
                FillMMRSummary("B 45", dtStartDate, dtEndDate, sFinancialYear);                
                FillMMRSummary("BIPL", dtStartDate, dtEndDate, sFinancialYear);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            WorkingDays = objBuyingHouseController.GetWorkingDays_BAL();

            if ((txtDateFrom.Text != "") && (txtDateTo.Text != ""))
            {
                dtStartDate = DateTime.ParseExact(txtDateFrom.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture).Date;
                dtEndDate = DateTime.ParseExact(txtDateTo.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture).Date;
                //if (dtEndDate < dtStartDate)
                //{
                //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", "alert('To date cann't be less than From date');", true);
                //    Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scr", "alert('To date cann't be less than From date');", true);
                //    return;
                //}
                lblDate.Text = txtDateFrom.Text + " To " + txtDateTo.Text;
                DateRange = (dtEndDate - dtStartDate).TotalDays + 1;
            }
            else
            {
                dtStartDate = DateTime.Now.Date;
                dtEndDate = DateTime.Now.Date;
                lblDate.Text = DateTime.Now.ToString("dd MMM yy (ddd)") + " To " + DateTime.Now.ToString("dd MMM yy (ddd)");
            }

            WorkingHrs = objBuyingHouseController.GetMMR_WorkingHours_BAL(dtStartDate, dtEndDate);
            if (WorkingHrs != "")
            {
                txtworkingHour.Text = WorkingHrs;
            }

            // Fill Budget Summary

            FillBudgetFactoryUnitName();
            FillBudgetSummaryStaffDept("", dtStartDate, dtEndDate, sFinancialYear);

            FillBudgetSummary("C 47", dtStartDate, dtEndDate, sFinancialYear);
            FillBudgetSummary("C 45-46", dtStartDate, dtEndDate, sFinancialYear);
            FillBudgetSummary("B 45", dtStartDate, dtEndDate, sFinancialYear);            
            FillBudgetSummary("BIPL", dtStartDate, dtEndDate, sFinancialYear);

            FillUnitName();
            FillWorkerType("", dtStartDate, dtEndDate, sFinancialYear);

            FillFactoryDetails("C 47", dtStartDate, dtEndDate, sFinancialYear);
            FillFactoryDetails("C 45-46", dtStartDate, dtEndDate, sFinancialYear);
            FillFactoryDetails("B 45", dtStartDate, dtEndDate, sFinancialYear);            
            FillFactoryDetails("BIPL", dtStartDate, dtEndDate, sFinancialYear);

            // Fill CMT Data FillCMTReports
            FillCMTUnitName();
            FillStaffDept("", dtStartDate, dtEndDate, sFinancialYear);

            FillCMTReports("C 47", dtStartDate, dtEndDate, sFinancialYear);
            FillCMTReports("C 45-46", dtStartDate, dtEndDate, sFinancialYear);
            FillCMTReports("B 45", dtStartDate, dtEndDate, sFinancialYear);            
            FillCMTReports("BIPL", dtStartDate, dtEndDate, sFinancialYear);

            // Fill MMR Summary

            FillMMRFactoryUnitName();
            FillMMRSummaryStaff("", dtStartDate, dtEndDate, sFinancialYear);

            FillMMRSummary("C 47", dtStartDate, dtEndDate, sFinancialYear);
            FillMMRSummary("C 45-46", dtStartDate, dtEndDate, sFinancialYear);
            FillMMRSummary("B 45", dtStartDate, dtEndDate, sFinancialYear);           
            FillMMRSummary("BIPL", dtStartDate, dtEndDate, sFinancialYear);


        }

        #region BudgetSummary

        private void FillBudgetFactoryUnitName()
        {
            DataTable dtUnitName = objBuyingHouseController.GetBiplUNITNAMEBAL();
            DataTable dt2 = new DataTable();
            for (int i = 0; i <= dtUnitName.Rows.Count; i++)
            {
                dt2.Columns.Add();
            }
            for (int i = 0; i < dtUnitName.Columns.Count; i++)
            {
                dt2.Rows.Add();
                dt2.Rows[i][0] = dtUnitName.Columns[i].ColumnName;
            }
            for (int i = 0; i < dtUnitName.Columns.Count; i++)
            {
                for (int j = 0; j < dtUnitName.Rows.Count; j++)
                {
                    dt2.Rows[i][j + 1] = dtUnitName.Rows[j][i];
                }
            }
            gvFactoryBudgetSummary.DataSource = dt2;
            gvFactoryBudgetSummary.DataBind();
        }

        private void FillBudgetSummaryStaffDept(string sUnitName, DateTime dtFromDate, DateTime dtToDate, string sFinancialYear)
        {
            DataTable dtStaffDept = objBuyingHouseController.GetMMR_BudgetSummary_DateRange_BAL(sUnitName, dtFromDate, dtToDate, sFinancialYear);
            gvBudgetSummaryStaffDept.DataSource = dtStaffDept;
            gvBudgetSummaryStaffDept.DataBind();
        }

        private void FillBudgetSummary(string sUnitName, DateTime dtFromDate, DateTime dtToDate, string sFinancialYear)
        {
            if (sUnitName == "C 47")
            {
                DataTable dtFactoryDetails = objBuyingHouseController.GetMMR_BudgetSummary_DateRange_BAL(sUnitName, dtFromDate, dtToDate, sFinancialYear);
                gvBudgetSummary1.DataSource = dtFactoryDetails;
                gvBudgetSummary1.DataBind();
            }
            if (sUnitName == "C 45-46")
            {
                DataTable dtFactoryDetails = objBuyingHouseController.GetMMR_BudgetSummary_DateRange_BAL(sUnitName, dtFromDate, dtToDate, sFinancialYear);
                gvBudgetSummary2.DataSource = dtFactoryDetails;
                gvBudgetSummary2.DataBind();
            }
            if (sUnitName == "B 45")
            {
                DataTable dtFactoryDetails = objBuyingHouseController.GetMMR_BudgetSummary_DateRange_BAL(sUnitName, dtFromDate, dtToDate, sFinancialYear);
                gvBudgetSummary3.DataSource = dtFactoryDetails;
                gvBudgetSummary3.DataBind();
            }
            if (sUnitName == "BIPL")
            {
                DataTable dtFactoryDetails = objBuyingHouseController.GetMMR_BudgetSummary_DateRange_BAL(sUnitName, dtFromDate, dtToDate, sFinancialYear);
                gvBudgetSummary4.DataSource = dtFactoryDetails;
                gvBudgetSummary4.DataBind();
            }
        }

        protected void gvFactoryBudgetSummary_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 0)
            {
                e.Row.BackColor = System.Drawing.Color.FromName("#dddfe4");
                e.Row.Cells[0].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[1].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[2].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[3].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[4].ForeColor = System.Drawing.Color.FromName("#575759");
            }
            else
            {
                e.Row.Visible = false;
            }
        }

        protected void gvBudgetSummary1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell ManPowerCell = new TableCell();
                ManPowerCell.Text = "ManPower";
                ManPowerCell.HorizontalAlign = HorizontalAlign.Center;
                ManPowerCell.Font.Bold = true;
                ManPowerCell.ColumnSpan = 3;
                TableCell CostCell = new TableCell();
                CostCell.Text = "Financial";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 3;
                gvrow.Cells.Add(ManPowerCell);
                gvrow.Cells.Add(CostCell);
                gvBudgetSummary1.Controls[0].Controls.AddAt(0, gvrow);
            }
        }

        protected void gvBudgetSummary1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnOverHead = (HiddenField)e.Row.FindControl("hdnOverHead");

                Label lblManPowerBudget = (Label)e.Row.FindControl("lblManPowerBudget");
                Label lblManPowerActual = (Label)e.Row.FindControl("lblManPowerActual");
                Label lblCostBudget = (Label)e.Row.FindControl("lblCostBudget");
                Label lblCostActual = (Label)e.Row.FindControl("lblCostActual");

                HtmlGenericControl dvManPowerDiff = e.Row.FindControl("dvManPowerDiff") as HtmlGenericControl;
                HtmlGenericControl dvCostDiff = e.Row.FindControl("dvCostDiff") as HtmlGenericControl;

                Label lblManPowerDifferences = (Label)e.Row.FindControl("lblManPowerDifferences");
                Label lblCostDifferences = (Label)e.Row.FindControl("lblCostDifferences");

                if (Math.Round(Convert.ToDouble(lblCostDifferences.Text) / 100000, 1) == 0)
                {
                    lblCostDifferences.Text = "";
                }
                else
                {
                    lblCostDifferences.Text = "₹ " + Math.Round(Convert.ToDouble(lblCostDifferences.Text) / 100000, 1) + " L";
                }

                if ((lblManPowerBudget.Text != "") && (lblManPowerActual.Text != ""))
                {
                    if (Convert.ToInt32(lblManPowerBudget.Text) - Convert.ToInt32(lblManPowerActual.Text) >= 0)
                    {
                        dvManPowerDiff.Style.Add("background-color", "#008000");
                        lblManPowerDifferences.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        dvManPowerDiff.Style.Add("background-color", "#FF0000");
                        lblManPowerDifferences.ForeColor = System.Drawing.Color.White;
                    }
                }

                if ((lblCostBudget.Text != "") && (lblCostActual.Text != ""))
                {
                    if (Convert.ToDouble(lblCostBudget.Text) - Convert.ToDouble(lblCostActual.Text) >= 0)
                    {
                        dvCostDiff.Style.Add("background-color", "#008000");
                        lblCostDifferences.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        dvCostDiff.Style.Add("background-color", "#FF0000");
                        lblCostDifferences.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblManPowerBudget.Text != "")
                {
                    TotalManPowerBudget = TotalManPowerBudget + Convert.ToInt32(lblManPowerBudget.Text);
                    if (Convert.ToInt32(lblManPowerBudget.Text) == 0)
                    {
                        lblManPowerBudget.Text = "";
                    }
                }
                if (lblManPowerActual.Text != "")
                {
                    TotalManPowerActual = TotalManPowerActual + Convert.ToInt32(lblManPowerActual.Text);
                    if (Convert.ToInt32(lblManPowerActual.Text) == 0)
                    {
                        lblManPowerActual.Text = "";
                    }
                }

                if (lblCostBudget.Text != "")
                {
                    TotalCostBudget = TotalCostBudget + Convert.ToDouble(lblCostBudget.Text);
                    if (Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) == 0)
                    {
                        lblCostBudget.Text = "";
                    }
                    else
                    {
                        lblCostBudget.Text = "₹ " + Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) + " L";
                    }
                }
                if (lblCostActual.Text != "")
                {
                    TotalCostActual = TotalCostActual + Convert.ToDouble(lblCostActual.Text);
                    if (Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) == 0)
                    {
                        lblCostActual.Text = "";
                    }
                    else
                    {
                        lblCostActual.Text = "₹ " + Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) + " L";
                    }
                }

                if (hdnOverHead != null)
                {
                    OverHead1 = Convert.ToDouble(hdnOverHead.Value);
                }
                if (lblManPowerBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerBudget.Text);
                    lblManPowerBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerActual.Text);
                    lblManPowerActual.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerDifferences.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerDifferences.Text);
                    lblManPowerDifferences.Text = ManPower.ToString("#,##0");
                } 
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblManPowerTotalBudget = (Label)e.Row.FindControl("lblManPowerTotalBudget");
                Label lblManPowerTotalActual = (Label)e.Row.FindControl("lblManPowerTotalActual");
                Label lblTotalManPowerDiff = (Label)e.Row.FindControl("lblTotalManPowerDiff");

                Label lblTotalCostBudget = (Label)e.Row.FindControl("lblTotalCostBudget");
                Label lblTotalCostActual = (Label)e.Row.FindControl("lblTotalCostActual");
                Label lblTotalCostDiff = (Label)e.Row.FindControl("lblTotalCostDiff");

                Label lblOverHeadBudget = (Label)e.Row.FindControl("lblOverHeadBudget");
                Label lblOverHeadActual = (Label)e.Row.FindControl("lblOverHeadActual");
                Label lblOverHeadCostDiff = (Label)e.Row.FindControl("lblOverHeadCostDiff");


                HtmlTableCell tdTotalManpowerDiff = e.Row.FindControl("tdTotalManpowerDiff") as HtmlTableCell;
                HtmlTableCell tdTotalCostDiff = e.Row.FindControl("tdTotalCostDiff") as HtmlTableCell;

                TotalCostBudget = TotalCostBudget + OverHead1;
                TotalCostActual = TotalCostActual + OverHead1;

                lblTotalManPowerDiff.Text = (TotalManPowerBudget - TotalManPowerActual) == 0 ? "" : (TotalManPowerBudget - TotalManPowerActual).ToString();

                lblTotalCostDiff.Text = Math.Round((TotalCostBudget - TotalCostActual) / 100000, 1) == 0 ? "" : "₹ " + Math.Round((TotalCostBudget - TotalCostActual) / 100000, 1).ToString() + " L";
                // Period Total
                if (TotalManPowerActual <= TotalManPowerBudget)
                {
                    tdTotalManpowerDiff.Style.Add("background-color", "#008000");
                    lblTotalManPowerDiff.ForeColor = System.Drawing.Color.White;
                }
                if (TotalManPowerActual > TotalManPowerBudget)
                {
                    tdTotalManpowerDiff.Style.Add("background-color", "#FF0000");
                    lblTotalManPowerDiff.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual <= TotalCostBudget)
                {
                    tdTotalCostDiff.Style.Add("background-color", "#008000");
                    lblTotalCostDiff.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual > TotalCostBudget)
                {
                    tdTotalCostDiff.Style.Add("background-color", "#FF0000");
                    lblTotalCostDiff.ForeColor = System.Drawing.Color.White;
                }

                lblManPowerTotalBudget.Text = TotalManPowerBudget == 0 ? "" : TotalManPowerBudget.ToString();
                lblManPowerTotalActual.Text = TotalManPowerActual == 0 ? "" : TotalManPowerActual.ToString();

                TotalManPowerBudget1 = TotalManPowerBudget;
                TotalManPowerActual1 = TotalManPowerActual;

                if (Math.Round(TotalCostBudget / 100000, 1) != 0)
                {
                    lblTotalCostBudget.Text = "₹ " + Math.Round(TotalCostBudget / 100000, 1) + " L";
                }
                if (Math.Round(TotalCostActual / 100000, 1) != 0)
                {
                    lblTotalCostActual.Text = "₹ " + Math.Round(TotalCostActual / 100000, 1) + " L";
                }

                lblOverHeadBudget.Text = Math.Round(OverHead1 / 100000, 1) == 0 ? "" : "₹ " + Math.Round(OverHead1 / 100000, 1) + " L";
                lblOverHeadActual.Text = Math.Round(OverHead1 / 100000, 1) == 0 ? "" : "₹ " + Math.Round(OverHead1 / 100000, 1) + " L";

                if (lblManPowerTotalBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerTotalBudget.Text);
                    lblManPowerTotalBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerTotalActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerTotalActual.Text);
                    lblManPowerTotalActual.Text = ManPower.ToString("#,##0");
                }
                if (lblTotalManPowerDiff.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblTotalManPowerDiff.Text);
                    lblTotalManPowerDiff.Text = ManPower.ToString("#,##0");
                } 

                TotalManPowerBudget = 0;
                TotalManPowerActual = 0;
                TotalCostBudget = 0;
                TotalCostActual = 0;
                OverHead1 = 0;
            }
        }

        protected void gvBudgetSummary2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell ManPowerCell = new TableCell();
                ManPowerCell.Text = "ManPower";
                ManPowerCell.HorizontalAlign = HorizontalAlign.Center;
                ManPowerCell.Font.Bold = true;
                ManPowerCell.ColumnSpan = 3;
                TableCell CostCell = new TableCell();
                CostCell.Text = "Financial";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 3;
                gvrow.Cells.Add(ManPowerCell);
                gvrow.Cells.Add(CostCell);
                gvBudgetSummary2.Controls[0].Controls.AddAt(0, gvrow);
            }
        }

        protected void gvBudgetSummary2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnOverHead = (HiddenField)e.Row.FindControl("hdnOverHead");

                Label lblManPowerBudget = (Label)e.Row.FindControl("lblManPowerBudget");
                Label lblManPowerActual = (Label)e.Row.FindControl("lblManPowerActual");
                Label lblCostBudget = (Label)e.Row.FindControl("lblCostBudget");
                Label lblCostActual = (Label)e.Row.FindControl("lblCostActual");

                HtmlGenericControl dvManPowerDiff = e.Row.FindControl("dvManPowerDiff") as HtmlGenericControl;
                HtmlGenericControl dvCostDiff = e.Row.FindControl("dvCostDiff") as HtmlGenericControl;

                Label lblManPowerDifferences = (Label)e.Row.FindControl("lblManPowerDifferences");
                Label lblCostDifferences = (Label)e.Row.FindControl("lblCostDifferences");

                if (Math.Round(Convert.ToDouble(lblCostDifferences.Text) / 100000, 1) == 0)
                {
                    lblCostDifferences.Text = "";
                }
                else
                {
                    lblCostDifferences.Text = "₹ " + Math.Round(Convert.ToDouble(lblCostDifferences.Text) / 100000, 1) + " L";
                }

                if ((lblManPowerBudget.Text != "") && (lblManPowerActual.Text != ""))
                {
                    if (Convert.ToInt32(lblManPowerBudget.Text) - Convert.ToInt32(lblManPowerActual.Text) >= 0)
                    {
                        dvManPowerDiff.Style.Add("background-color", "#008000");
                        lblManPowerDifferences.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        dvManPowerDiff.Style.Add("background-color", "#FF0000");
                        lblManPowerDifferences.ForeColor = System.Drawing.Color.White;
                    }
                }

                if ((lblCostBudget.Text != "") && (lblCostActual.Text != ""))
                {
                    if (Convert.ToDouble(lblCostBudget.Text) - Convert.ToDouble(lblCostActual.Text) >= 0)
                    {
                        dvCostDiff.Style.Add("background-color", "#008000");
                        lblCostDifferences.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        dvCostDiff.Style.Add("background-color", "#FF0000");
                        lblCostDifferences.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblManPowerBudget.Text != "")
                {
                    TotalManPowerBudget = TotalManPowerBudget + Convert.ToInt32(lblManPowerBudget.Text);
                    if (Convert.ToInt32(lblManPowerBudget.Text) == 0)
                    {
                        lblManPowerBudget.Text = "";
                    }
                }
                if (lblManPowerActual.Text != "")
                {
                    TotalManPowerActual = TotalManPowerActual + Convert.ToInt32(lblManPowerActual.Text);
                    if (Convert.ToInt32(lblManPowerActual.Text) == 0)
                    {
                        lblManPowerActual.Text = "";
                    }
                }

                if (lblCostBudget.Text != "")
                {
                    TotalCostBudget = TotalCostBudget + Convert.ToDouble(lblCostBudget.Text);
                    if (Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) == 0)
                    {
                        lblCostBudget.Text = "";
                    }
                    else
                    {
                        lblCostBudget.Text = "₹ " + Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) + " L";
                    }
                }
                if (lblCostActual.Text != "")
                {
                    TotalCostActual = TotalCostActual + Convert.ToDouble(lblCostActual.Text);
                    if (Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) == 0)
                    {
                        lblCostActual.Text = "";
                    }
                    else
                    {
                        lblCostActual.Text = "₹ " + Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) + " L";
                    }
                }

                if (hdnOverHead != null)
                {
                    OverHead2 = Convert.ToDouble(hdnOverHead.Value);
                }
                if (lblManPowerBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerBudget.Text);
                    lblManPowerBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerActual.Text);
                    lblManPowerActual.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerDifferences.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerDifferences.Text);
                    lblManPowerDifferences.Text = ManPower.ToString("#,##0");
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblManPowerTotalBudget = (Label)e.Row.FindControl("lblManPowerTotalBudget");
                Label lblManPowerTotalActual = (Label)e.Row.FindControl("lblManPowerTotalActual");
                Label lblTotalManPowerDiff = (Label)e.Row.FindControl("lblTotalManPowerDiff");

                Label lblTotalCostBudget = (Label)e.Row.FindControl("lblTotalCostBudget");
                Label lblTotalCostActual = (Label)e.Row.FindControl("lblTotalCostActual");
                Label lblTotalCostDiff = (Label)e.Row.FindControl("lblTotalCostDiff");

                Label lblOverHeadBudget = (Label)e.Row.FindControl("lblOverHeadBudget");
                Label lblOverHeadActual = (Label)e.Row.FindControl("lblOverHeadActual");
                Label lblOverHeadCostDiff = (Label)e.Row.FindControl("lblOverHeadCostDiff");


                HtmlTableCell tdTotalManpowerDiff = e.Row.FindControl("tdTotalManpowerDiff") as HtmlTableCell;
                HtmlTableCell tdTotalCostDiff = e.Row.FindControl("tdTotalCostDiff") as HtmlTableCell;

                TotalCostBudget = TotalCostBudget + OverHead2;
                TotalCostActual = TotalCostActual + OverHead2;

                lblTotalManPowerDiff.Text = (TotalManPowerBudget - TotalManPowerActual) == 0 ? "" : (TotalManPowerBudget - TotalManPowerActual).ToString();

                lblTotalCostDiff.Text = Math.Round((TotalCostBudget - TotalCostActual) / 100000, 1) == 0 ? "" : "₹ " + Math.Round((TotalCostBudget - TotalCostActual) / 100000, 1).ToString() + " L";
                // Period Total
                if (TotalManPowerActual <= TotalManPowerBudget)
                {
                    tdTotalManpowerDiff.Style.Add("background-color", "#008000");
                    lblTotalManPowerDiff.ForeColor = System.Drawing.Color.White;
                }
                if (TotalManPowerActual > TotalManPowerBudget)
                {
                    tdTotalManpowerDiff.Style.Add("background-color", "#FF0000");
                    lblTotalManPowerDiff.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual <= TotalCostBudget)
                {
                    tdTotalCostDiff.Style.Add("background-color", "#008000");
                    lblTotalCostDiff.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual > TotalCostBudget)
                {
                    tdTotalCostDiff.Style.Add("background-color", "#FF0000");
                    lblTotalCostDiff.ForeColor = System.Drawing.Color.White;
                }

                lblManPowerTotalBudget.Text = TotalManPowerBudget == 0 ? "" : TotalManPowerBudget.ToString();
                lblManPowerTotalActual.Text = TotalManPowerActual == 0 ? "" : TotalManPowerActual.ToString();

                TotalManPowerBudget2 = TotalManPowerBudget;
                TotalManPowerActual2 = TotalManPowerActual;

                if (Math.Round(TotalCostBudget / 100000, 1) != 0)
                {
                    lblTotalCostBudget.Text = "₹ " + Math.Round(TotalCostBudget / 100000, 1) + " L";
                }
                if (Math.Round(TotalCostActual / 100000, 1) != 0)
                {
                    lblTotalCostActual.Text = "₹ " + Math.Round(TotalCostActual / 100000, 1) + " L";
                }

                lblOverHeadBudget.Text = Math.Round(OverHead2 / 100000, 1) == 0 ? "" : "₹ " + Math.Round(OverHead2 / 100000, 1) + " L";
                lblOverHeadActual.Text = Math.Round(OverHead2 / 100000, 1) == 0 ? "" : "₹ " + Math.Round(OverHead2 / 100000, 1) + " L";
                if (lblManPowerTotalBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerTotalBudget.Text);
                    lblManPowerTotalBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerTotalActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerTotalActual.Text);
                    lblManPowerTotalActual.Text = ManPower.ToString("#,##0");
                }
                if (lblTotalManPowerDiff.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblTotalManPowerDiff.Text);
                    lblTotalManPowerDiff.Text = ManPower.ToString("#,##0");
                } 


                TotalManPowerBudget = 0;
                TotalManPowerActual = 0;
                TotalCostBudget = 0;
                TotalCostActual = 0;
                OverHead2 = 0;
            }
        }

        protected void gvBudgetSummary3_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell ManPowerCell = new TableCell();
                ManPowerCell.Text = "ManPower";
                ManPowerCell.HorizontalAlign = HorizontalAlign.Center;
                ManPowerCell.Font.Bold = true;
                ManPowerCell.ColumnSpan = 3;
                TableCell CostCell = new TableCell();
                CostCell.Text = "Financial";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 3;
                gvrow.Cells.Add(ManPowerCell);
                gvrow.Cells.Add(CostCell);
                gvBudgetSummary3.Controls[0].Controls.AddAt(0, gvrow);
            }
        }

        protected void gvBudgetSummary3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnOverHead = (HiddenField)e.Row.FindControl("hdnOverHead");

                Label lblManPowerBudget = (Label)e.Row.FindControl("lblManPowerBudget");
                Label lblManPowerActual = (Label)e.Row.FindControl("lblManPowerActual");
                Label lblCostBudget = (Label)e.Row.FindControl("lblCostBudget");
                Label lblCostActual = (Label)e.Row.FindControl("lblCostActual");

                HtmlGenericControl dvManPowerDiff = e.Row.FindControl("dvManPowerDiff") as HtmlGenericControl;
                HtmlGenericControl dvCostDiff = e.Row.FindControl("dvCostDiff") as HtmlGenericControl;

                Label lblManPowerDifferences = (Label)e.Row.FindControl("lblManPowerDifferences");
                Label lblCostDifferences = (Label)e.Row.FindControl("lblCostDifferences");

                if (Math.Round(Convert.ToDouble(lblCostDifferences.Text) / 100000, 1) == 0)
                {
                    lblCostDifferences.Text = "";
                }
                else
                {
                    lblCostDifferences.Text = "₹ " + Math.Round(Convert.ToDouble(lblCostDifferences.Text) / 100000, 1) + " L";
                }

                if ((lblManPowerBudget.Text != "") && (lblManPowerActual.Text != ""))
                {
                    if (Convert.ToInt32(lblManPowerBudget.Text) - Convert.ToInt32(lblManPowerActual.Text) >= 0)
                    {
                        dvManPowerDiff.Style.Add("background-color", "#008000");
                        lblManPowerDifferences.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        dvManPowerDiff.Style.Add("background-color", "#FF0000");
                        lblManPowerDifferences.ForeColor = System.Drawing.Color.White;
                    }
                }

                if ((lblCostBudget.Text != "") && (lblCostActual.Text != ""))
                {
                    if (Convert.ToDouble(lblCostBudget.Text) - Convert.ToDouble(lblCostActual.Text) >= 0)
                    {
                        dvCostDiff.Style.Add("background-color", "#008000");
                        lblCostDifferences.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        dvCostDiff.Style.Add("background-color", "#FF0000");
                        lblCostDifferences.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblManPowerBudget.Text != "")
                {
                    TotalManPowerBudget = TotalManPowerBudget + Convert.ToInt32(lblManPowerBudget.Text);
                    if (Convert.ToInt32(lblManPowerBudget.Text) == 0)
                    {
                        lblManPowerBudget.Text = "";
                    }
                }
                if (lblManPowerActual.Text != "")
                {
                    TotalManPowerActual = TotalManPowerActual + Convert.ToInt32(lblManPowerActual.Text);
                    if (Convert.ToInt32(lblManPowerActual.Text) == 0)
                    {
                        lblManPowerActual.Text = "";
                    }
                }

                if (lblCostBudget.Text != "")
                {
                    TotalCostBudget = TotalCostBudget + Convert.ToDouble(lblCostBudget.Text);
                    if (Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) == 0)
                    {
                        lblCostBudget.Text = "";
                    }
                    else
                    {
                        lblCostBudget.Text = "₹ " + Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) + " L";
                    }
                }
                if (lblCostActual.Text != "")
                {
                    TotalCostActual = TotalCostActual + Convert.ToDouble(lblCostActual.Text);
                    if (Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) == 0)
                    {
                        lblCostActual.Text = "";
                    }
                    else
                    {
                        lblCostActual.Text = "₹ " + Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) + " L";
                    }
                }

                if (hdnOverHead != null)
                {
                    OverHead3 = Convert.ToDouble(hdnOverHead.Value);
                }

                if (lblManPowerBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerBudget.Text);
                    lblManPowerBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerActual.Text);
                    lblManPowerActual.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerDifferences.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerDifferences.Text);
                    lblManPowerDifferences.Text = ManPower.ToString("#,##0");
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblManPowerTotalBudget = (Label)e.Row.FindControl("lblManPowerTotalBudget");
                Label lblManPowerTotalActual = (Label)e.Row.FindControl("lblManPowerTotalActual");
                Label lblTotalManPowerDiff = (Label)e.Row.FindControl("lblTotalManPowerDiff");

                Label lblTotalCostBudget = (Label)e.Row.FindControl("lblTotalCostBudget");
                Label lblTotalCostActual = (Label)e.Row.FindControl("lblTotalCostActual");
                Label lblTotalCostDiff = (Label)e.Row.FindControl("lblTotalCostDiff");

                Label lblOverHeadBudget = (Label)e.Row.FindControl("lblOverHeadBudget");
                Label lblOverHeadActual = (Label)e.Row.FindControl("lblOverHeadActual");
                Label lblOverHeadCostDiff = (Label)e.Row.FindControl("lblOverHeadCostDiff");


                HtmlTableCell tdTotalManpowerDiff = e.Row.FindControl("tdTotalManpowerDiff") as HtmlTableCell;
                HtmlTableCell tdTotalCostDiff = e.Row.FindControl("tdTotalCostDiff") as HtmlTableCell;

                TotalCostBudget = TotalCostBudget + OverHead3;
                TotalCostActual = TotalCostActual + OverHead3;

                lblTotalManPowerDiff.Text = (TotalManPowerBudget - TotalManPowerActual) == 0 ? "" : (TotalManPowerBudget - TotalManPowerActual).ToString();

                lblTotalCostDiff.Text = Math.Round((TotalCostBudget - TotalCostActual) / 100000, 1) == 0 ? "" : "₹ " + Math.Round((TotalCostBudget - TotalCostActual) / 100000, 1).ToString() + " L";
                // Period Total
                if (TotalManPowerActual <= TotalManPowerBudget)
                {
                    tdTotalManpowerDiff.Style.Add("background-color", "#008000");
                    lblTotalManPowerDiff.ForeColor = System.Drawing.Color.White;
                }
                if (TotalManPowerActual > TotalManPowerBudget)
                {
                    tdTotalManpowerDiff.Style.Add("background-color", "#FF0000");
                    lblTotalManPowerDiff.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual <= TotalCostBudget)
                {
                    tdTotalCostDiff.Style.Add("background-color", "#008000");
                    lblTotalCostDiff.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual > TotalCostBudget)
                {
                    tdTotalCostDiff.Style.Add("background-color", "#FF0000");
                    lblTotalCostDiff.ForeColor = System.Drawing.Color.White;
                }

                lblManPowerTotalBudget.Text = TotalManPowerBudget == 0 ? "" : TotalManPowerBudget.ToString();
                lblManPowerTotalActual.Text = TotalManPowerActual == 0 ? "" : TotalManPowerActual.ToString();

                TotalManPowerBudget3 = TotalManPowerBudget;
                TotalManPowerActual3 = TotalManPowerActual;

                if (Math.Round(TotalCostBudget / 100000, 1) != 0)
                {
                    lblTotalCostBudget.Text = "₹ " + Math.Round(TotalCostBudget / 100000, 1) + " L";
                }
                if (Math.Round(TotalCostActual / 100000, 1) != 0)
                {
                    lblTotalCostActual.Text = "₹ " + Math.Round(TotalCostActual / 100000, 1) + " L";
                }

                lblOverHeadBudget.Text = Math.Round(OverHead3 / 100000, 1) == 0 ? "" : "₹ " + Math.Round(OverHead3 / 100000, 1) + " L";
                lblOverHeadActual.Text = Math.Round(OverHead3 / 100000, 1) == 0 ? "" : "₹ " + Math.Round(OverHead3 / 100000, 1) + " L";

                if (lblManPowerTotalBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerTotalBudget.Text);
                    lblManPowerTotalBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerTotalActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerTotalActual.Text);
                    lblManPowerTotalActual.Text = ManPower.ToString("#,##0");
                }
                if (lblTotalManPowerDiff.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblTotalManPowerDiff.Text);
                    lblTotalManPowerDiff.Text = ManPower.ToString("#,##0");
                } 

                TotalManPowerBudget = 0;
                TotalManPowerActual = 0;
                TotalCostBudget = 0;
                TotalCostActual = 0;
                OverHead3 = 0;
            }
        }

        protected void gvBudgetSummary4_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell ManPowerCell = new TableCell();
                ManPowerCell.Text = "ManPower";
                ManPowerCell.HorizontalAlign = HorizontalAlign.Center;
                ManPowerCell.Font.Bold = true;
                ManPowerCell.ColumnSpan = 3;
                TableCell CostCell = new TableCell();
                CostCell.Text = "Financial";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 3;
                gvrow.Cells.Add(ManPowerCell);
                gvrow.Cells.Add(CostCell);
                gvBudgetSummary4.Controls[0].Controls.AddAt(0, gvrow);
            }
        }

        protected void gvBudgetSummary4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnOverHead = (HiddenField)e.Row.FindControl("hdnOverHead");

                Label lblManPowerBudget = (Label)e.Row.FindControl("lblManPowerBudget");
                Label lblManPowerActual = (Label)e.Row.FindControl("lblManPowerActual");
                Label lblCostBudget = (Label)e.Row.FindControl("lblCostBudget");
                Label lblCostActual = (Label)e.Row.FindControl("lblCostActual");

                HtmlGenericControl dvManPowerDiff = e.Row.FindControl("dvManPowerDiff") as HtmlGenericControl;
                HtmlGenericControl dvCostDiff = e.Row.FindControl("dvCostDiff") as HtmlGenericControl;

                Label lblManPowerDifferences = (Label)e.Row.FindControl("lblManPowerDifferences");
                Label lblCostDifferences = (Label)e.Row.FindControl("lblCostDifferences");

                if (Math.Round(Convert.ToDouble(lblCostDifferences.Text) / 100000, 1) == 0)
                {
                    lblCostDifferences.Text = "";
                }
                else
                {
                    lblCostDifferences.Text = "₹ " + Math.Round(Convert.ToDouble(lblCostDifferences.Text) / 100000, 1) + " L";
                }

                if ((lblManPowerBudget.Text != "") && (lblManPowerActual.Text != ""))
                {
                    if (Convert.ToInt32(lblManPowerBudget.Text) - Convert.ToInt32(lblManPowerActual.Text) >= 0)
                    {
                        dvManPowerDiff.Style.Add("background-color", "#008000");
                        lblManPowerDifferences.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        dvManPowerDiff.Style.Add("background-color", "#FF0000");
                        lblManPowerDifferences.ForeColor = System.Drawing.Color.White;
                    }
                }

                if ((lblCostBudget.Text != "") && (lblCostActual.Text != ""))
                {
                    if (Convert.ToDouble(lblCostBudget.Text) - Convert.ToDouble(lblCostActual.Text) >= 0)
                    {
                        dvCostDiff.Style.Add("background-color", "#008000");
                        lblCostDifferences.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        dvCostDiff.Style.Add("background-color", "#FF0000");
                        lblCostDifferences.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblManPowerBudget.Text != "")
                {
                    TotalManPowerBudget = TotalManPowerBudget + Convert.ToInt32(lblManPowerBudget.Text);
                    if (Convert.ToInt32(lblManPowerBudget.Text) == 0)
                    {
                        lblManPowerBudget.Text = "";
                    }
                }
                if (lblManPowerActual.Text != "")
                {
                    TotalManPowerActual = TotalManPowerActual + Convert.ToInt32(lblManPowerActual.Text);
                    if (Convert.ToInt32(lblManPowerActual.Text) == 0)
                    {
                        lblManPowerActual.Text = "";
                    }
                }

                if (lblCostBudget.Text != "")
                {
                    TotalCostBudget = TotalCostBudget + Convert.ToDouble(lblCostBudget.Text);
                    if (Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) == 0)
                    {
                        lblCostBudget.Text = "";
                    }
                    else
                    {
                        lblCostBudget.Text = "₹ " + Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) + " L";
                    }
                }
                if (lblCostActual.Text != "")
                {
                    TotalCostActual = TotalCostActual + Convert.ToDouble(lblCostActual.Text);
                    if (Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) == 0)
                    {
                        lblCostActual.Text = "";
                    }
                    else
                    {
                        lblCostActual.Text = "₹ " + Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) + " L";
                    }
                }

                if (hdnOverHead != null)
                {
                    OverHead4 = Convert.ToDouble(hdnOverHead.Value);
                }
                if (lblManPowerBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerBudget.Text);
                    lblManPowerBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerActual.Text);
                    lblManPowerActual.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerDifferences.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerDifferences.Text);
                    lblManPowerDifferences.Text = ManPower.ToString("#,##0");
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblManPowerTotalBudget = (Label)e.Row.FindControl("lblManPowerTotalBudget");
                Label lblManPowerTotalActual = (Label)e.Row.FindControl("lblManPowerTotalActual");
                Label lblTotalManPowerDiff = (Label)e.Row.FindControl("lblTotalManPowerDiff");

                Label lblTotalCostBudget = (Label)e.Row.FindControl("lblTotalCostBudget");
                Label lblTotalCostActual = (Label)e.Row.FindControl("lblTotalCostActual");
                Label lblTotalCostDiff = (Label)e.Row.FindControl("lblTotalCostDiff");

                Label lblOverHeadBudget = (Label)e.Row.FindControl("lblOverHeadBudget");
                Label lblOverHeadActual = (Label)e.Row.FindControl("lblOverHeadActual");
                Label lblOverHeadCostDiff = (Label)e.Row.FindControl("lblOverHeadCostDiff");


                HtmlTableCell tdTotalManpowerDiff = e.Row.FindControl("tdTotalManpowerDiff") as HtmlTableCell;
                HtmlTableCell tdTotalCostDiff = e.Row.FindControl("tdTotalCostDiff") as HtmlTableCell;

                TotalCostBudget = TotalCostBudget + OverHead4;
                TotalCostActual = TotalCostActual + OverHead4;

                lblTotalManPowerDiff.Text = (TotalManPowerBudget - TotalManPowerActual) == 0 ? "" : (TotalManPowerBudget - TotalManPowerActual).ToString();

                lblTotalCostDiff.Text = Math.Round((TotalCostBudget - TotalCostActual) / 100000, 1) == 0 ? "" : "₹ " + Math.Round((TotalCostBudget - TotalCostActual) / 100000, 1).ToString() + " L";
                // Period Total
                if (TotalManPowerActual <= TotalManPowerBudget)
                {
                    tdTotalManpowerDiff.Style.Add("background-color", "#008000");
                    lblTotalManPowerDiff.ForeColor = System.Drawing.Color.White;
                }
                if (TotalManPowerActual > TotalManPowerBudget)
                {
                    tdTotalManpowerDiff.Style.Add("background-color", "#FF0000");
                    lblTotalManPowerDiff.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual <= TotalCostBudget)
                {
                    tdTotalCostDiff.Style.Add("background-color", "#008000");
                    lblTotalCostDiff.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual > TotalCostBudget)
                {
                    tdTotalCostDiff.Style.Add("background-color", "#FF0000");
                    lblTotalCostDiff.ForeColor = System.Drawing.Color.White;
                }

                lblManPowerTotalBudget.Text = TotalManPowerBudget == 0 ? "" : TotalManPowerBudget.ToString();
                lblManPowerTotalActual.Text = TotalManPowerActual == 0 ? "" : TotalManPowerActual.ToString();

                TotalManPowerBudget4 = TotalManPowerBudget;
                TotalManPowerActual4 = TotalManPowerActual;

                if (Math.Round(TotalCostBudget / 100000, 1) != 0)
                {
                    lblTotalCostBudget.Text = "₹ " + Math.Round(TotalCostBudget / 100000, 1) + " L";
                }
                if (Math.Round(TotalCostActual / 100000, 1) != 0)
                {
                    lblTotalCostActual.Text = "₹ " + Math.Round(TotalCostActual / 100000, 1) + " L";
                }

                lblOverHeadBudget.Text = Math.Round(OverHead4 / 100000, 1) == 0 ? "" : "₹ " + Math.Round(OverHead4 / 100000, 1) + " L";
                lblOverHeadActual.Text = Math.Round(OverHead4 / 100000, 1) == 0 ? "" : "₹ " + Math.Round(OverHead4 / 100000, 1) + " L";

                if (lblManPowerTotalBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerTotalBudget.Text);
                    lblManPowerTotalBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerTotalActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerTotalActual.Text);
                    lblManPowerTotalActual.Text = ManPower.ToString("#,##0");
                }
                if (lblTotalManPowerDiff.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblTotalManPowerDiff.Text);
                    lblTotalManPowerDiff.Text = ManPower.ToString("#,##0");
                }         

                TotalManPowerBudget = 0;
                TotalManPowerActual = 0;
                TotalCostBudget = 0;
                TotalCostActual = 0;
                OverHead4 = 0;
            }
        }

        #endregion

        #region DailyMMR report

        private void FillUnitName()
        {
            DataTable dtUnitName = objBuyingHouseController.GetBiplUNITNAMEBAL();
            DataTable dt2 = new DataTable();
            for (int i = 0; i <= dtUnitName.Rows.Count; i++)
            {
                dt2.Columns.Add();
            }
            for (int i = 0; i < dtUnitName.Columns.Count; i++)
            {
                dt2.Rows.Add();
                dt2.Rows[i][0] = dtUnitName.Columns[i].ColumnName;
            }
            for (int i = 0; i < dtUnitName.Columns.Count; i++)
            {
                for (int j = 0; j < dtUnitName.Rows.Count; j++)
                {
                    dt2.Rows[i][j + 1] = dtUnitName.Rows[j][i];
                }
            }
            gvAvailMin.DataSource = dt2;
            gvAvailMin.DataBind();
        }

        protected void gvAvailMin_rowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 0)
            {
                e.Row.BackColor = System.Drawing.Color.FromName("#dddfe4");
                e.Row.Cells[0].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[1].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[2].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[3].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[4].ForeColor = System.Drawing.Color.FromName("#575759");
            }
            else
            {
                e.Row.Visible = false;
            }
        }

        private void GetFactoryCost(string sUnitName, DateTime dtStartDate, DateTime dtEnddate)
        {
            if (sUnitName == "C 47")
            {
                string sFactoryCost1 = objBuyingHouseController.GetCostedProductionCost_BAL(dtStartDate, DateTime.MinValue, sUnitName);
                if (sFactoryCost1 != "")
                {
                    FactoryCost1 = Convert.ToDouble(sFactoryCost1);
                }
            }
            if (sUnitName == "B 45")
            {
                string sFactoryCost2 = objBuyingHouseController.GetCostedProductionCost_BAL(dtStartDate, DateTime.MinValue, sUnitName);
                if (sFactoryCost2 != "")
                {
                    FactoryCost2 = Convert.ToDouble(sFactoryCost2);
                }
            }
            if (sUnitName == "C 45-46")
            {
                string sFactoryCost3 = objBuyingHouseController.GetCostedProductionCost_BAL(dtStartDate, DateTime.MinValue, sUnitName);
                if (sFactoryCost3 != "")
                {
                    FactoryCost3 = Convert.ToDouble(sFactoryCost3);
                }
            }
        }

        private void FillWorkerType(string sUnitName, DateTime dtFromDate, DateTime dtToDate, string sFinancialYear)
        {
            DataTable dtWorkerType = objBuyingHouseController.GetDaily_MMR_Report_BAL(sUnitName, dtFromDate, dtToDate, sFinancialYear);
            gvWorkerType.DataSource = dtWorkerType;
            gvWorkerType.DataBind();
        }

        protected void gvWorkerType_DataBound(object sender, EventArgs e)
        {
            for (int i = gvWorkerType.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvWorkerType.Rows[i];
                GridViewRow previousRow = gvWorkerType.Rows[i - 1];

                for (int j = 0; j < row.Cells.Count - 1; j++)
                {
                    Label lblStaffDept = (Label)row.Cells[j].FindControl("lblStaffDept");
                    Label lblPreviousStaffDept = (Label)previousRow.Cells[j].FindControl("lblStaffDept");

                    if (lblStaffDept.Text == lblPreviousStaffDept.Text)
                    {
                        if (previousRow.Cells[j].RowSpan == 0)
                        {
                            if (row.Cells[j].RowSpan == 0)
                            {
                                previousRow.Cells[j].RowSpan += 2;
                            }
                            else
                            {
                                previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
                            }
                            row.Cells[j].Visible = false;
                        }
                    }
                }
            }
           
        }

        protected void gvWorkerType_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //string sDept = e.Row.Cells[0].Text;
            //string sWorkerType = e.Row.Cells[1].Text;

            //if (sDept == "z")
            //{
            //    e.Row.Cells[0].Text = "";
            //}
            //if (sWorkerType == "z")
            //{
            //    e.Row.Cells[1].Text = "Overhead";
            //}
            //}
        }

        private void FillFactoryDetails(string sUnitName, DateTime dtFromDate, DateTime dtToDate, string sFinancialYear)
        {
            if (sUnitName == "C 47")
            {
                DataTable dtFactoryDetails = objBuyingHouseController.GetDaily_MMR_Report_BAL(sUnitName, dtFromDate, dtToDate, sFinancialYear);
                gvFactoryDetails1.DataSource = dtFactoryDetails;
                gvFactoryDetails1.DataBind();
            }
            if (sUnitName == "C 45-46")
            {
                DataTable dtFactoryDetails = objBuyingHouseController.GetDaily_MMR_Report_BAL(sUnitName, dtFromDate, dtToDate, sFinancialYear);
                gvFactoryDetails2.DataSource = dtFactoryDetails;
                gvFactoryDetails2.DataBind();
            }
            if (sUnitName == "B 45")
            {
                DataTable dtFactoryDetails = objBuyingHouseController.GetDaily_MMR_Report_BAL(sUnitName, dtFromDate, dtToDate, sFinancialYear);
                gvFactoryDetails3.DataSource = dtFactoryDetails;
                gvFactoryDetails3.DataBind();
            }
            if (sUnitName == "BIPL")
            {
                DataTable dtFactoryDetails = objBuyingHouseController.GetDaily_MMR_Report_BAL(sUnitName, dtFromDate, dtToDate, sFinancialYear);
                gvFactoryDetails4.DataSource = dtFactoryDetails;
                gvFactoryDetails4.DataBind();
            }
        }

        protected void gvFactoryDetails1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell ManPowerCell = new TableCell();
                ManPowerCell.Text = "Man Power";
                ManPowerCell.HorizontalAlign = HorizontalAlign.Center;
                ManPowerCell.Font.Bold = true;
                ManPowerCell.ColumnSpan = 2;
                TableCell CostCell = new TableCell();
                CostCell.Text = "Cost";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 2;
                gvrow.Cells.Add(ManPowerCell);
                gvrow.Cells.Add(CostCell);
                gvFactoryDetails1.Controls[0].Controls.AddAt(0, gvrow);
            }
        }

        protected void gvFactoryDetails1_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (DateRange == 0)
                DateRange = 1;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnMachineCount = (HiddenField)e.Row.FindControl("hdnMachineCount");
                Label lblManPowerBudget = (Label)e.Row.FindControl("lblManPowerBudget");
                Label lblManPowerActual = (Label)e.Row.FindControl("lblManPowerActual");

                Label lblCostBudget = (Label)e.Row.FindControl("lblCostBudget");
                Label lblCostActual = (Label)e.Row.FindControl("lblCostActual");

                HtmlGenericControl dvManPowerActual = e.Row.FindControl("dvManPowerActual") as HtmlGenericControl;
                HtmlGenericControl dvCostActual = e.Row.FindControl("dvCostActual") as HtmlGenericControl;

                if (lblManPowerBudget.Text != "")
                {
                    TotalManPowerBudget = TotalManPowerBudget + Convert.ToInt32(lblManPowerBudget.Text);
                    if (Convert.ToInt32(hdnMachineCount.Value) == 1)
                    {
                        BudgetwithMachine1 = BudgetwithMachine1 + Convert.ToDouble(lblManPowerBudget.Text);
                    }
                    lblManPowerBudget.Text = Convert.ToInt32(lblManPowerBudget.Text) == 0 ? "" : lblManPowerBudget.Text;
                }
                if (lblManPowerActual.Text != "")
                {
                    TotalManPowerActual = TotalManPowerActual + Convert.ToInt32(lblManPowerActual.Text);
                    if (Convert.ToInt32(hdnMachineCount.Value) == 1)
                    {
                        ActualwithMachine1 = ActualwithMachine1 + Convert.ToDouble(lblManPowerActual.Text);
                    }
                    lblManPowerActual.Text = Convert.ToInt32(lblManPowerActual.Text) == 0 ? "" : lblManPowerActual.Text;
                }
                if ((lblManPowerBudget.Text == "") && (lblManPowerActual.Text == ""))
                {
                }
                else
                {
                    if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManPowerActual")) <= Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManPowerBudget")))
                    {
                        dvManPowerActual.Style.Add("background-color", "#008000");
                        lblManPowerActual.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        dvManPowerActual.Style.Add("background-color", "#FF0000");
                        lblManPowerActual.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) <= Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1))
                {
                    if (Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) > 0)
                    {
                        dvCostActual.Style.Add("background-color", "#008000");
                        lblCostActual.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    dvCostActual.Style.Add("background-color", "#FF0000");
                    lblCostActual.ForeColor = System.Drawing.Color.White;
                }


                TotalCostBudget = TotalCostBudget + Convert.ToDouble(lblCostBudget.Text);
                lblCostBudget.Text = Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) == 0 ? "" : "₹ " + Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) + " L";


                TotalCostActual = TotalCostActual + Convert.ToDouble(lblCostActual.Text);
                lblCostActual.Text = Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) == 0 ? "" : "₹ " + Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) + " L";

                if (lblManPowerBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerBudget.Text);
                    lblManPowerBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerActual.Text);
                    lblManPowerActual.Text = ManPower.ToString("#,##0");
                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalManPowerBudget = (Label)e.Row.FindControl("lblTotalManPowerBudget");
                Label lblTotalManPowerActual = (Label)e.Row.FindControl("lblTotalManPowerActual");
                Label lblTotalCostBudget = (Label)e.Row.FindControl("lblTotalCostBudget");
                Label lblTotalCostActual = (Label)e.Row.FindControl("lblTotalCostActual");

                Label lblTotalMonthlyBudgetCount = (Label)e.Row.FindControl("lblTotalMonthlyBudgetCount");
                Label lblMonthlyTotalActual = (Label)e.Row.FindControl("lblMonthlyTotalActual");
                Label lblTotalMonthlyCostBudget = (Label)e.Row.FindControl("lblTotalMonthlyCostBudget");
                Label lblTotalMonthlyCostActual = (Label)e.Row.FindControl("lblTotalMonthlyCostActual");

                HtmlTableCell tdTotalManPowerActual = e.Row.FindControl("tdTotalManPowerActual") as HtmlTableCell;
                HtmlTableCell tdMonthlyTotalActual = e.Row.FindControl("tdMonthlyTotalActual") as HtmlTableCell;
                HtmlTableCell tdTotalCostActual = e.Row.FindControl("tdTotalCostActual") as HtmlTableCell;
                HtmlTableCell tdTotalMonthlyCostActual = e.Row.FindControl("tdTotalMonthlyCostActual") as HtmlTableCell;
                // Period Total
                if (TotalManPowerActual <= TotalManPowerBudget)
                {
                    tdTotalManPowerActual.Style.Add("background-color", "#008000");
                    lblTotalManPowerActual.ForeColor = System.Drawing.Color.White;
                    tdMonthlyTotalActual.Style.Add("background-color", "#008000");
                    lblMonthlyTotalActual.ForeColor = System.Drawing.Color.White;
                }
                if (TotalManPowerActual > TotalManPowerBudget)
                {
                    tdTotalManPowerActual.Style.Add("background-color", "#FF0000");
                    lblTotalManPowerActual.ForeColor = System.Drawing.Color.White;
                    tdMonthlyTotalActual.Style.Add("background-color", "#FF0000");
                    lblMonthlyTotalActual.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual <= TotalCostBudget)
                {
                    tdTotalCostActual.Style.Add("background-color", "#008000");
                    lblTotalCostActual.ForeColor = System.Drawing.Color.White;
                    tdTotalMonthlyCostActual.Style.Add("background-color", "#008000");
                    lblTotalMonthlyCostActual.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual > TotalCostBudget)
                {
                    tdTotalCostActual.Style.Add("background-color", "#FF0000");
                    lblTotalCostActual.ForeColor = System.Drawing.Color.White;
                    tdTotalMonthlyCostActual.Style.Add("background-color", "#FF0000");
                    lblTotalMonthlyCostActual.ForeColor = System.Drawing.Color.White;
                }

                lblTotalManPowerBudget.Text = TotalManPowerBudget == 0 ? "" : TotalManPowerBudget.ToString("#,##0");
                lblTotalManPowerActual.Text = TotalManPowerActual == 0 ? "" : TotalManPowerActual.ToString("#,##0");

                if (Math.Round(TotalCostBudget / 100000, 1) != 0)
                {
                    lblTotalCostBudget.Text = "₹ " + Math.Round(TotalCostBudget / 100000, 1) + " L";
                }
                if (Math.Round(TotalCostActual / 100000, 1) != 0)
                {
                    lblTotalCostActual.Text = "₹ " + Math.Round(TotalCostActual / 100000, 1) + " L";
                }
                if (WorkingDays != "")
                {
                    if (TotalManPowerBudget > 0)
                    {
                        lblTotalMonthlyBudgetCount.Text = Math.Round(Convert.ToDouble(TotalManPowerBudget) * Convert.ToDouble(WorkingDays), 0) == 0 ? "" : Math.Round(Convert.ToDouble(TotalManPowerBudget) * Convert.ToDouble(WorkingDays), 0).ToString("#,##0");
                    }
                    if (TotalManPowerActual > 0)
                    {
                        lblMonthlyTotalActual.Text = Math.Round(Convert.ToDouble(TotalManPowerActual) * Convert.ToDouble(WorkingDays), 0) == 0 ? "" : Math.Round((Convert.ToDouble(TotalManPowerActual) * Convert.ToDouble(WorkingDays)) / DateRange, 0).ToString("#,##0");
                    }
                    if (TotalCostBudget > 0)
                    {
                        lblTotalMonthlyCostBudget.Text = Math.Round((Convert.ToDouble(TotalCostBudget) * Convert.ToDouble(WorkingDays)) / 100000, 1) == 0 ? "" : "₹ " + Math.Round((Convert.ToDouble(TotalCostBudget) * Convert.ToDouble(WorkingDays)) / DateRange / 100000, 1).ToString("#,##0") + " L";
                    }
                    if (TotalCostActual > 0)
                    {
                        lblTotalMonthlyCostActual.Text = Math.Round((Convert.ToDouble(TotalCostActual) * Convert.ToDouble(WorkingDays)) / 100000, 1) == 0 ? "" : "₹ " + Math.Round((Convert.ToDouble(TotalCostActual) * Convert.ToDouble(WorkingDays)) / DateRange / 100000, 1).ToString("#,##0") + " L";
                    }
                }
               
                TotalManPowerBudget = 0;
                TotalManPowerActual = 0;
                TotalCostBudget = 0;
                TotalCostActual = 0;
            }
        }

        protected void gvFactoryDetails2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell ManPowerCell = new TableCell();
                ManPowerCell.Text = "Man Power";
                ManPowerCell.HorizontalAlign = HorizontalAlign.Center;
                ManPowerCell.Font.Bold = true;
                ManPowerCell.ColumnSpan = 2;
                TableCell CostCell = new TableCell();
                CostCell.Text = "Cost";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 2;
                gvrow.Cells.Add(ManPowerCell);
                gvrow.Cells.Add(CostCell);
                gvFactoryDetails2.Controls[0].Controls.AddAt(0, gvrow);
            }
        }

        protected void gvFactoryDetails2_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (DateRange == 0)
                DateRange = 1;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnMachineCount = (HiddenField)e.Row.FindControl("hdnMachineCount");
                Label lblManPowerBudget = (Label)e.Row.FindControl("lblManPowerBudget");
                Label lblManPowerActual = (Label)e.Row.FindControl("lblManPowerActual");

                Label lblCostBudget = (Label)e.Row.FindControl("lblCostBudget");
                Label lblCostActual = (Label)e.Row.FindControl("lblCostActual");

                HtmlGenericControl dvManPowerActual = e.Row.FindControl("dvManPowerActual") as HtmlGenericControl;
                HtmlGenericControl dvCostActual = e.Row.FindControl("dvCostActual") as HtmlGenericControl;

                if (lblManPowerBudget.Text != "")
                {
                    TotalManPowerBudget = TotalManPowerBudget + Convert.ToInt32(lblManPowerBudget.Text);
                    if (Convert.ToInt32(hdnMachineCount.Value) == 1)
                    {
                        BudgetwithMachine2 = BudgetwithMachine2 + Convert.ToDouble(lblManPowerBudget.Text);
                    }
                    lblManPowerBudget.Text = Convert.ToInt32(lblManPowerBudget.Text) == 0 ? "" : lblManPowerBudget.Text;
                }
                if (lblManPowerActual.Text != "")
                {
                    TotalManPowerActual = TotalManPowerActual + Convert.ToInt32(lblManPowerActual.Text);
                    if (Convert.ToInt32(hdnMachineCount.Value) == 1)
                    {
                        ActualwithMachine2 = ActualwithMachine2 + Convert.ToDouble(lblManPowerActual.Text);
                    }
                    lblManPowerActual.Text = Convert.ToInt32(lblManPowerActual.Text) == 0 ? "" : lblManPowerActual.Text;
                }
                if ((lblManPowerBudget.Text == "") && (lblManPowerActual.Text == ""))
                {
                }
                else
                {
                    if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManPowerActual")) <= Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManPowerBudget")))
                    {
                        dvManPowerActual.Style.Add("background-color", "#008000");
                        lblManPowerActual.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        dvManPowerActual.Style.Add("background-color", "#FF0000");
                        lblManPowerActual.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) <= Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1))
                {
                    if (Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) > 0)
                    {
                        dvCostActual.Style.Add("background-color", "#008000");
                        lblCostActual.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    dvCostActual.Style.Add("background-color", "#FF0000");
                    lblCostActual.ForeColor = System.Drawing.Color.White;
                }


                TotalCostBudget = TotalCostBudget + Convert.ToDouble(lblCostBudget.Text);
                lblCostBudget.Text = Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) == 0 ? "" : "₹ " + Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) + " L";


                TotalCostActual = TotalCostActual + Convert.ToDouble(lblCostActual.Text);
                lblCostActual.Text = Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) == 0 ? "" : "₹ " + Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) + " L";

                if (lblManPowerBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerBudget.Text);
                    lblManPowerBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerActual.Text);
                    lblManPowerActual.Text = ManPower.ToString("#,##0");
                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalManPowerBudget = (Label)e.Row.FindControl("lblTotalManPowerBudget");
                Label lblTotalManPowerActual = (Label)e.Row.FindControl("lblTotalManPowerActual");
                Label lblTotalCostBudget = (Label)e.Row.FindControl("lblTotalCostBudget");
                Label lblTotalCostActual = (Label)e.Row.FindControl("lblTotalCostActual");

                Label lblTotalMonthlyBudgetCount = (Label)e.Row.FindControl("lblTotalMonthlyBudgetCount");
                Label lblMonthlyTotalActual = (Label)e.Row.FindControl("lblMonthlyTotalActual");
                Label lblTotalMonthlyCostBudget = (Label)e.Row.FindControl("lblTotalMonthlyCostBudget");
                Label lblTotalMonthlyCostActual = (Label)e.Row.FindControl("lblTotalMonthlyCostActual");

                //Label lblActualProd_vs_Budget = (Label)e.Row.FindControl("lblActualProd_vs_Budget");

                HtmlTableCell tdTotalManPowerActual = e.Row.FindControl("tdTotalManPowerActual") as HtmlTableCell;
                HtmlTableCell tdMonthlyTotalActual = e.Row.FindControl("tdMonthlyTotalActual") as HtmlTableCell;
                HtmlTableCell tdTotalCostActual = e.Row.FindControl("tdTotalCostActual") as HtmlTableCell;
                HtmlTableCell tdTotalMonthlyCostActual = e.Row.FindControl("tdTotalMonthlyCostActual") as HtmlTableCell;
                // Period Total
                if (TotalManPowerActual <= TotalManPowerBudget)
                {
                    tdTotalManPowerActual.Style.Add("background-color", "#008000");
                    lblTotalManPowerActual.ForeColor = System.Drawing.Color.White;
                    tdMonthlyTotalActual.Style.Add("background-color", "#008000");
                    lblMonthlyTotalActual.ForeColor = System.Drawing.Color.White;
                }
                if (TotalManPowerActual > TotalManPowerBudget)
                {
                    tdTotalManPowerActual.Style.Add("background-color", "#FF0000");
                    lblTotalManPowerActual.ForeColor = System.Drawing.Color.White;
                    tdMonthlyTotalActual.Style.Add("background-color", "#FF0000");
                    lblMonthlyTotalActual.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual <= TotalCostBudget)
                {
                    tdTotalCostActual.Style.Add("background-color", "#008000");
                    lblTotalCostActual.ForeColor = System.Drawing.Color.White;
                    tdTotalMonthlyCostActual.Style.Add("background-color", "#008000");
                    lblTotalMonthlyCostActual.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual > TotalCostBudget)
                {
                    tdTotalCostActual.Style.Add("background-color", "#FF0000");
                    lblTotalCostActual.ForeColor = System.Drawing.Color.White;
                    tdTotalMonthlyCostActual.Style.Add("background-color", "#FF0000");
                    lblTotalMonthlyCostActual.ForeColor = System.Drawing.Color.White;
                }

                lblTotalManPowerBudget.Text = TotalManPowerBudget == 0 ? "" : TotalManPowerBudget.ToString("#,##0");
                lblTotalManPowerActual.Text = TotalManPowerActual == 0 ? "" : TotalManPowerActual.ToString("#,##0");

                if (Math.Round(TotalCostBudget / 100000, 1) != 0)
                {
                    lblTotalCostBudget.Text = "₹ " + Math.Round(TotalCostBudget / 100000, 1) + " L";
                }
                if (Math.Round(TotalCostActual / 100000, 1) != 0)
                {
                    lblTotalCostActual.Text = "₹ " + Math.Round(TotalCostActual / 100000, 1) + " L";
                }
                if (WorkingDays != "")
                {
                    if (TotalManPowerBudget > 0)
                    {
                        lblTotalMonthlyBudgetCount.Text = Math.Round(Convert.ToDouble(TotalManPowerBudget) * Convert.ToDouble(WorkingDays), 0) == 0 ? "" : Math.Round(Convert.ToDouble(TotalManPowerBudget) * Convert.ToDouble(WorkingDays), 0).ToString("#,##0");
                    }
                    if (TotalManPowerActual > 0)
                    {
                        lblMonthlyTotalActual.Text = Math.Round(Convert.ToDouble(TotalManPowerActual) * Convert.ToDouble(WorkingDays), 0) == 0 ? "" : Math.Round((Convert.ToDouble(TotalManPowerActual) * Convert.ToDouble(WorkingDays)) / DateRange, 0).ToString("#,##0");
                    }
                    if (TotalCostBudget > 0)
                    {
                        lblTotalMonthlyCostBudget.Text = Math.Round((Convert.ToDouble(TotalCostBudget) * Convert.ToDouble(WorkingDays)) / 100000, 1) == 0 ? "" : "₹ " + Math.Round((Convert.ToDouble(TotalCostBudget) * Convert.ToDouble(WorkingDays)) / DateRange / 100000, 1).ToString("#,##0") + " L";
                    }
                    if (TotalCostActual > 0)
                    {
                        lblTotalMonthlyCostActual.Text = Math.Round((Convert.ToDouble(TotalCostActual) * Convert.ToDouble(WorkingDays)) / 100000, 1) == 0 ? "" : "₹ " + Math.Round((Convert.ToDouble(TotalCostActual) * Convert.ToDouble(WorkingDays)) / DateRange / 100000, 1).ToString("#,##0") + " L";
                    }
                }
               
                TotalManPowerBudget = 0;
                TotalManPowerActual = 0;
                TotalCostBudget = 0;
                TotalCostActual = 0;
            }
        }

        protected void gvFactoryDetails3_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell ManPowerCell = new TableCell();
                ManPowerCell.Text = "Man Power";
                ManPowerCell.HorizontalAlign = HorizontalAlign.Center;
                ManPowerCell.Font.Bold = true;
                ManPowerCell.ColumnSpan = 2;
                TableCell CostCell = new TableCell();
                CostCell.Text = "Cost";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 2;
                gvrow.Cells.Add(ManPowerCell);
                gvrow.Cells.Add(CostCell);
                gvFactoryDetails3.Controls[0].Controls.AddAt(0, gvrow);
            }
        }


        protected void gvFactoryDetails3_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (DateRange == 0)
                DateRange = 1;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnMachineCount = (HiddenField)e.Row.FindControl("hdnMachineCount");
                Label lblManPowerBudget = (Label)e.Row.FindControl("lblManPowerBudget");
                Label lblManPowerActual = (Label)e.Row.FindControl("lblManPowerActual");

                Label lblCostBudget = (Label)e.Row.FindControl("lblCostBudget");
                Label lblCostActual = (Label)e.Row.FindControl("lblCostActual");

                HtmlGenericControl dvManPowerActual = e.Row.FindControl("dvManPowerActual") as HtmlGenericControl;
                HtmlGenericControl dvCostActual = e.Row.FindControl("dvCostActual") as HtmlGenericControl;

                if (lblManPowerBudget.Text != "")
                {
                    TotalManPowerBudget = TotalManPowerBudget + Convert.ToInt32(lblManPowerBudget.Text);
                    if (Convert.ToInt32(hdnMachineCount.Value) == 1)
                    {
                        BudgetwithMachine3 = BudgetwithMachine3 + Convert.ToDouble(lblManPowerBudget.Text);
                    }
                    lblManPowerBudget.Text = Convert.ToInt32(lblManPowerBudget.Text) == 0 ? "" : lblManPowerBudget.Text;
                }
                if (lblManPowerActual.Text != "")
                {
                    TotalManPowerActual = TotalManPowerActual + Convert.ToInt32(lblManPowerActual.Text);
                    if (Convert.ToInt32(hdnMachineCount.Value) == 1)
                    {
                        ActualwithMachine3 = ActualwithMachine3 + Convert.ToDouble(lblManPowerActual.Text);
                    }
                    lblManPowerActual.Text = Convert.ToInt32(lblManPowerActual.Text) == 0 ? "" : lblManPowerActual.Text;
                }
                if ((lblManPowerBudget.Text == "") && (lblManPowerActual.Text == ""))
                {
                }
                else
                {
                    if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManPowerActual")) <= Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManPowerBudget")))
                    {
                        dvManPowerActual.Style.Add("background-color", "#008000");
                        lblManPowerActual.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        dvManPowerActual.Style.Add("background-color", "#FF0000");
                        lblManPowerActual.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) <= Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1))
                {
                    if (Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) > 0)
                    {
                        dvCostActual.Style.Add("background-color", "#008000");
                        lblCostActual.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    dvCostActual.Style.Add("background-color", "#FF0000");
                    lblCostActual.ForeColor = System.Drawing.Color.White;
                }


                TotalCostBudget = TotalCostBudget + Convert.ToDouble(lblCostBudget.Text);
                lblCostBudget.Text = Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) == 0 ? "" : "₹ " + Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) + " L";


                TotalCostActual = TotalCostActual + Convert.ToDouble(lblCostActual.Text);
                lblCostActual.Text = Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) == 0 ? "" : "₹ " + Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) + " L";

                if (lblManPowerBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerBudget.Text);
                    lblManPowerBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerActual.Text);
                    lblManPowerActual.Text = ManPower.ToString("#,##0");
                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalManPowerBudget = (Label)e.Row.FindControl("lblTotalManPowerBudget");
                Label lblTotalManPowerActual = (Label)e.Row.FindControl("lblTotalManPowerActual");
                Label lblTotalCostBudget = (Label)e.Row.FindControl("lblTotalCostBudget");
                Label lblTotalCostActual = (Label)e.Row.FindControl("lblTotalCostActual");

                Label lblTotalMonthlyBudgetCount = (Label)e.Row.FindControl("lblTotalMonthlyBudgetCount");
                Label lblMonthlyTotalActual = (Label)e.Row.FindControl("lblMonthlyTotalActual");
                Label lblTotalMonthlyCostBudget = (Label)e.Row.FindControl("lblTotalMonthlyCostBudget");
                Label lblTotalMonthlyCostActual = (Label)e.Row.FindControl("lblTotalMonthlyCostActual");

                //Label lblActualProd_vs_Budget = (Label)e.Row.FindControl("lblActualProd_vs_Budget");

                HtmlTableCell tdTotalManPowerActual = e.Row.FindControl("tdTotalManPowerActual") as HtmlTableCell;
                HtmlTableCell tdMonthlyTotalActual = e.Row.FindControl("tdMonthlyTotalActual") as HtmlTableCell;
                HtmlTableCell tdTotalCostActual = e.Row.FindControl("tdTotalCostActual") as HtmlTableCell;
                HtmlTableCell tdTotalMonthlyCostActual = e.Row.FindControl("tdTotalMonthlyCostActual") as HtmlTableCell;
                // Period Total
                if (TotalManPowerActual <= TotalManPowerBudget)
                {
                    tdTotalManPowerActual.Style.Add("background-color", "#008000");
                    lblTotalManPowerActual.ForeColor = System.Drawing.Color.White;
                    tdMonthlyTotalActual.Style.Add("background-color", "#008000");
                    lblMonthlyTotalActual.ForeColor = System.Drawing.Color.White;
                }
                if (TotalManPowerActual > TotalManPowerBudget)
                {
                    tdTotalManPowerActual.Style.Add("background-color", "#FF0000");
                    lblTotalManPowerActual.ForeColor = System.Drawing.Color.White;
                    tdMonthlyTotalActual.Style.Add("background-color", "#FF0000");
                    lblMonthlyTotalActual.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual <= TotalCostBudget)
                {
                    tdTotalCostActual.Style.Add("background-color", "#008000");
                    lblTotalCostActual.ForeColor = System.Drawing.Color.White;
                    tdTotalMonthlyCostActual.Style.Add("background-color", "#008000");
                    lblTotalMonthlyCostActual.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual > TotalCostBudget)
                {
                    tdTotalCostActual.Style.Add("background-color", "#FF0000");
                    lblTotalCostActual.ForeColor = System.Drawing.Color.White;
                    tdTotalMonthlyCostActual.Style.Add("background-color", "#FF0000");
                    lblTotalMonthlyCostActual.ForeColor = System.Drawing.Color.White;
                }

                lblTotalManPowerBudget.Text = TotalManPowerBudget == 0 ? "" : TotalManPowerBudget.ToString("#,##0");
                lblTotalManPowerActual.Text = TotalManPowerActual == 0 ? "" : TotalManPowerActual.ToString("#,##0");

                if (Math.Round(TotalCostBudget / 100000, 1) != 0)
                {
                    lblTotalCostBudget.Text = "₹ " + Math.Round(TotalCostBudget / 100000, 1) + " L";
                }
                if (Math.Round(TotalCostActual / 100000, 1) != 0)
                {
                    lblTotalCostActual.Text = "₹ " + Math.Round(TotalCostActual / 100000, 1) + " L";
                }
                if (WorkingDays != "")
                {
                    if (TotalManPowerBudget > 0)
                    {
                        lblTotalMonthlyBudgetCount.Text = Math.Round(Convert.ToDouble(TotalManPowerBudget) * Convert.ToDouble(WorkingDays), 0) == 0 ? "" : Math.Round(Convert.ToDouble(TotalManPowerBudget) * Convert.ToDouble(WorkingDays), 0).ToString("#,##0");
                    }
                    if (TotalManPowerActual > 0)
                    {
                        lblMonthlyTotalActual.Text = Math.Round(Convert.ToDouble(TotalManPowerActual) * Convert.ToDouble(WorkingDays), 0) == 0 ? "" : Math.Round((Convert.ToDouble(TotalManPowerActual) * Convert.ToDouble(WorkingDays)) / DateRange, 0).ToString("#,##0");
                    }
                    if (TotalCostBudget > 0)
                    {
                        lblTotalMonthlyCostBudget.Text = Math.Round((Convert.ToDouble(TotalCostBudget) * Convert.ToDouble(WorkingDays)) / 100000, 1) == 0 ? "" : "₹ " + Math.Round((Convert.ToDouble(TotalCostBudget) * Convert.ToDouble(WorkingDays)) / DateRange / 100000, 1).ToString("#,##0") + " L";
                    }
                    if (TotalCostActual > 0)
                    {
                        lblTotalMonthlyCostActual.Text = Math.Round((Convert.ToDouble(TotalCostActual) * Convert.ToDouble(WorkingDays)) / 100000, 1) == 0 ? "" : "₹ " + Math.Round((Convert.ToDouble(TotalCostActual) * Convert.ToDouble(WorkingDays)) / DateRange / 100000, 1).ToString("#,##0") + " L";
                    }
                }
             
                TotalManPowerBudget = 0;
                TotalManPowerActual = 0;
                TotalCostBudget = 0;
                TotalCostActual = 0;
            }
        }

        protected void gvFactoryDetails4_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell ManPowerCell = new TableCell();
                ManPowerCell.Text = "Man Power";
                ManPowerCell.HorizontalAlign = HorizontalAlign.Center;
                ManPowerCell.Font.Bold = true;
                ManPowerCell.ColumnSpan = 2;
                TableCell CostCell = new TableCell();
                CostCell.Text = "Cost";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 2;
                gvrow.Cells.Add(ManPowerCell);
                gvrow.Cells.Add(CostCell);
                gvFactoryDetails4.Controls[0].Controls.AddAt(0, gvrow);
            }
        }


        protected void gvFactoryDetails4_RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if (DateRange == 0)
                DateRange = 1;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnMachineCount = (HiddenField)e.Row.FindControl("hdnMachineCount");
                Label lblManPowerBudget = (Label)e.Row.FindControl("lblManPowerBudget");
                Label lblManPowerActual = (Label)e.Row.FindControl("lblManPowerActual");

                Label lblCostBudget = (Label)e.Row.FindControl("lblCostBudget");
                Label lblCostActual = (Label)e.Row.FindControl("lblCostActual");

                HtmlGenericControl dvManPowerActual = e.Row.FindControl("dvManPowerActual") as HtmlGenericControl;
                HtmlGenericControl dvCostActual = e.Row.FindControl("dvCostActual") as HtmlGenericControl;

                if (lblManPowerBudget.Text != "")
                {
                    TotalManPowerBudget = TotalManPowerBudget + Convert.ToInt32(lblManPowerBudget.Text);
                    if (Convert.ToInt32(hdnMachineCount.Value) == 1)
                    {
                        BudgetwithMachine4 = BudgetwithMachine4 + Convert.ToDouble(lblManPowerBudget.Text);
                    }
                    lblManPowerBudget.Text = Convert.ToInt32(lblManPowerBudget.Text) == 0 ? "" : lblManPowerBudget.Text;
                }
                if (lblManPowerActual.Text != "")
                {
                    TotalManPowerActual = TotalManPowerActual + Convert.ToInt32(lblManPowerActual.Text);
                    if (Convert.ToInt32(hdnMachineCount.Value) == 1)
                    {
                        ActualwithMachine4 = ActualwithMachine4 + Convert.ToDouble(lblManPowerActual.Text);
                    }
                    lblManPowerActual.Text = Convert.ToInt32(lblManPowerActual.Text) == 0 ? "" : lblManPowerActual.Text;
                }
                if ((lblManPowerBudget.Text == "") && (lblManPowerActual.Text == ""))
                {
                }
                else
                {
                    if (Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManPowerActual")) <= Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "ManPowerBudget")))
                    {
                        dvManPowerActual.Style.Add("background-color", "#008000");
                        lblManPowerActual.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        dvManPowerActual.Style.Add("background-color", "#FF0000");
                        lblManPowerActual.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) <= Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1))
                {
                    if (Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) > 0)
                    {
                        dvCostActual.Style.Add("background-color", "#008000");
                        lblCostActual.ForeColor = System.Drawing.Color.White;
                    }
                }
                else
                {
                    dvCostActual.Style.Add("background-color", "#FF0000");
                    lblCostActual.ForeColor = System.Drawing.Color.White;
                }


                TotalCostBudget = TotalCostBudget + Convert.ToDouble(lblCostBudget.Text);
                lblCostBudget.Text = Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) == 0 ? "" : "₹ " + Math.Round(Convert.ToDouble(lblCostBudget.Text) / 100000, 1) + " L";


                TotalCostActual = TotalCostActual + Convert.ToDouble(lblCostActual.Text);
                lblCostActual.Text = Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) == 0 ? "" : "₹ " + Math.Round(Convert.ToDouble(lblCostActual.Text) / 100000, 1) + " L";

                if (lblManPowerBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerBudget.Text);
                    lblManPowerBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblManPowerActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblManPowerActual.Text);
                    lblManPowerActual.Text = ManPower.ToString("#,##0");
                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalManPowerBudget = (Label)e.Row.FindControl("lblTotalManPowerBudget");
                Label lblTotalManPowerActual = (Label)e.Row.FindControl("lblTotalManPowerActual");
                Label lblTotalCostBudget = (Label)e.Row.FindControl("lblTotalCostBudget");
                Label lblTotalCostActual = (Label)e.Row.FindControl("lblTotalCostActual");

                Label lblTotalMonthlyBudgetCount = (Label)e.Row.FindControl("lblTotalMonthlyBudgetCount");
                Label lblMonthlyTotalActual = (Label)e.Row.FindControl("lblMonthlyTotalActual");
                Label lblTotalMonthlyCostBudget = (Label)e.Row.FindControl("lblTotalMonthlyCostBudget");
                Label lblTotalMonthlyCostActual = (Label)e.Row.FindControl("lblTotalMonthlyCostActual");

                //Label lblActualProd_vs_Budget = (Label)e.Row.FindControl("lblActualProd_vs_Budget");

                HtmlTableCell tdTotalManPowerActual = e.Row.FindControl("tdTotalManPowerActual") as HtmlTableCell;
                HtmlTableCell tdMonthlyTotalActual = e.Row.FindControl("tdMonthlyTotalActual") as HtmlTableCell;
                HtmlTableCell tdTotalCostActual = e.Row.FindControl("tdTotalCostActual") as HtmlTableCell;
                HtmlTableCell tdTotalMonthlyCostActual = e.Row.FindControl("tdTotalMonthlyCostActual") as HtmlTableCell;
                // Period Total
                if (TotalManPowerActual <= TotalManPowerBudget)
                {
                    tdTotalManPowerActual.Style.Add("background-color", "#008000");
                    lblTotalManPowerActual.ForeColor = System.Drawing.Color.White;
                    tdMonthlyTotalActual.Style.Add("background-color", "#008000");
                    lblMonthlyTotalActual.ForeColor = System.Drawing.Color.White;
                }
                if (TotalManPowerActual > TotalManPowerBudget)
                {
                    tdTotalManPowerActual.Style.Add("background-color", "#FF0000");
                    lblTotalManPowerActual.ForeColor = System.Drawing.Color.White;
                    tdMonthlyTotalActual.Style.Add("background-color", "#FF0000");
                    lblMonthlyTotalActual.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual <= TotalCostBudget)
                {
                    tdTotalCostActual.Style.Add("background-color", "#008000");
                    lblTotalCostActual.ForeColor = System.Drawing.Color.White;
                    tdTotalMonthlyCostActual.Style.Add("background-color", "#008000");
                    lblTotalMonthlyCostActual.ForeColor = System.Drawing.Color.White;
                }
                if (TotalCostActual > TotalCostBudget)
                {
                    tdTotalCostActual.Style.Add("background-color", "#FF0000");
                    lblTotalCostActual.ForeColor = System.Drawing.Color.White;
                    tdTotalMonthlyCostActual.Style.Add("background-color", "#FF0000");
                    lblTotalMonthlyCostActual.ForeColor = System.Drawing.Color.White;
                }

                lblTotalManPowerBudget.Text = TotalManPowerBudget == 0 ? "" : TotalManPowerBudget.ToString("#,##0");
                lblTotalManPowerActual.Text = TotalManPowerActual == 0 ? "" : TotalManPowerActual.ToString("#,##0");

                if (Math.Round(TotalCostBudget / 100000, 1) != 0)
                {
                    lblTotalCostBudget.Text = "₹ " + Math.Round(TotalCostBudget / 100000, 1) + " L";
                }
                if (Math.Round(TotalCostActual / 100000, 1) != 0)
                {
                    lblTotalCostActual.Text = "₹ " + Math.Round(TotalCostActual / 100000, 1) + " L";
                }
                if (WorkingDays != "")
                {
                    if (TotalManPowerBudget > 0)
                    {
                        lblTotalMonthlyBudgetCount.Text = Math.Round(Convert.ToDouble(TotalManPowerBudget) * Convert.ToDouble(WorkingDays), 0) == 0 ? "" : Math.Round(Convert.ToDouble(TotalManPowerBudget) * Convert.ToDouble(WorkingDays), 0).ToString("#,##0");
                    }
                    if (TotalManPowerActual > 0)
                    {
                        lblMonthlyTotalActual.Text = Math.Round(Convert.ToDouble(TotalManPowerActual) * Convert.ToDouble(WorkingDays), 0) == 0 ? "" : Math.Round((Convert.ToDouble(TotalManPowerActual) * Convert.ToDouble(WorkingDays)) / DateRange, 0).ToString("#,##0");
                    }
                    if (TotalCostBudget > 0)
                    {
                        lblTotalMonthlyCostBudget.Text = Math.Round((Convert.ToDouble(TotalCostBudget) * Convert.ToDouble(WorkingDays)) / 100000, 1) == 0 ? "" : "₹ " + Math.Round((Convert.ToDouble(TotalCostBudget) * Convert.ToDouble(WorkingDays)) / DateRange / 100000, 1).ToString("#,##0") + " L";
                    }
                    if (TotalCostActual > 0)
                    {
                        lblTotalMonthlyCostActual.Text = Math.Round((Convert.ToDouble(TotalCostActual) * Convert.ToDouble(WorkingDays)) / 100000, 1) == 0 ? "" : "₹ " + Math.Round((Convert.ToDouble(TotalCostActual) * Convert.ToDouble(WorkingDays)) / DateRange / 100000, 1).ToString("#,##0") + " L";
                    }
                }
                
                TotalManPowerBudget = 0;
                TotalManPowerActual = 0;
                TotalCostBudget = 0;
                TotalCostActual = 0;
            }
        }        

        #endregion

        #region CMT Reports

        private void FillCMTUnitName()
        {
            DataTable dtUnitName = objBuyingHouseController.GetBiplUNITNAMEBAL();
            DataTable dt2 = new DataTable();
            for (int i = 0; i <= dtUnitName.Rows.Count; i++)
            {
                dt2.Columns.Add();
            }
            for (int i = 0; i < dtUnitName.Columns.Count; i++)
            {
                dt2.Rows.Add();
                dt2.Rows[i][0] = dtUnitName.Columns[i].ColumnName;
            }
            for (int i = 0; i < dtUnitName.Columns.Count; i++)
            {
                for (int j = 0; j < dtUnitName.Rows.Count; j++)
                {
                    dt2.Rows[i][j + 1] = dtUnitName.Rows[j][i];
                }
            }
            gvFactory.DataSource = dt2;
            gvFactory.DataBind();
        }

        private void FillStaffDept(string sUnitName, DateTime dtDateFrom, DateTime dtDateTo, string sFinancialYear)
        {
            DataTable dtStaffDept = objBuyingHouseController.GetMMR_CMT_Report_DateRange_BAL(sUnitName, dtDateFrom, dtDateTo, sFinancialYear);
            gvStaffDept.DataSource = dtStaffDept;
            gvStaffDept.DataBind();
        }

        private void FillCMTReports(string sUnitName, DateTime dtDateFrom, DateTime dtDateTo, string sFinancialYear)
        {
            if (sUnitName == "C 47")
            {
                DataTable dtFactoryDetails = objBuyingHouseController.GetMMR_CMT_Report_DateRange_BAL(sUnitName, dtDateFrom, dtDateTo, sFinancialYear);
                gvCMTFactory1.DataSource = dtFactoryDetails;
                gvCMTFactory1.DataBind();
            }
            if (sUnitName == "C 45-46")
            {
                DataTable dtFactoryDetails = objBuyingHouseController.GetMMR_CMT_Report_DateRange_BAL(sUnitName, dtDateFrom, dtDateTo, sFinancialYear);
                gvCMTFactory2.DataSource = dtFactoryDetails;
                gvCMTFactory2.DataBind();
            }
            if (sUnitName == "B 45")
            {
                DataTable dtFactoryDetails = objBuyingHouseController.GetMMR_CMT_Report_DateRange_BAL(sUnitName, dtDateFrom, dtDateTo, sFinancialYear);
                gvCMTFactory3.DataSource = dtFactoryDetails;
                gvCMTFactory3.DataBind();
            }
            if (sUnitName == "BIPL")
            {
                DataTable dtFactoryDetails = objBuyingHouseController.GetMMR_CMT_Report_DateRange_BAL(sUnitName, dtDateFrom, dtDateTo, sFinancialYear);
                gvCMTFactory4.DataSource = dtFactoryDetails;
                gvCMTFactory4.DataBind();
            }
        }

        protected void gvFactory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 0)
            {
                e.Row.BackColor = System.Drawing.Color.FromName("#dddfe4");
                e.Row.Cells[0].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[1].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[2].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[3].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[4].ForeColor = System.Drawing.Color.FromName("#575759");
            }
            else
            {
                e.Row.Visible = false;
            }
        }

        protected void gvStaffDept_DataBound(object sender, EventArgs e)
        {
            //for (int i = gvStaffDept.Rows.Count - 1; i > 0; i--)
            //{
            //    GridViewRow row = gvStaffDept.Rows[i];
            //    GridViewRow previousRow = gvStaffDept.Rows[i - 1];
            //    for (int j = 0; j < row.Cells.Count; j++)
            //    {
            //        if (row.Cells[j].Text == previousRow.Cells[j].Text)
            //        {
            //            if (previousRow.Cells[j].RowSpan == 0)
            //            {
            //                if (row.Cells[j].RowSpan == 0)
            //                {
            //                    previousRow.Cells[j].RowSpan += 2;
            //                }
            //                else
            //                {
            //                    previousRow.Cells[j].RowSpan = row.Cells[j].RowSpan + 1;
            //                }
            //                row.Cells[j].Visible = false;
            //            }
            //        }
            //    }
            //}
        }

        protected void gvCMTFactory1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell ManPowerCell = new TableCell();
                ManPowerCell.Text = "CPAM";
                ManPowerCell.HorizontalAlign = HorizontalAlign.Center;
                ManPowerCell.Font.Bold = true;
                ManPowerCell.ColumnSpan = 2;
                TableCell CostCell = new TableCell();
                CostCell.Text = "CMT Cost";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 2;
                gvrow.Cells.Add(ManPowerCell);
                gvrow.Cells.Add(CostCell);
                gvCMTFactory1.Controls[0].Controls.AddAt(0, gvrow);
            }
        }

        protected void gvCMTFactory1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnOverHead = (HiddenField)e.Row.FindControl("hdnOverHead");
                HiddenField hdnTotalActual = (HiddenField)e.Row.FindControl("hdnTotalActual");

                Label lblManPowerBudget = (Label)e.Row.FindControl("lblManPowerBudget");
                Label lblManPowerActual = (Label)e.Row.FindControl("lblManPowerActual");
                Label lblCostBudget = (Label)e.Row.FindControl("lblCostBudget");
                Label lblCostActual = (Label)e.Row.FindControl("lblCostActual");

                if (lblManPowerBudget.Text != "")
                {
                    TotalManPowerBudget = TotalManPowerBudget + Convert.ToDouble(lblManPowerBudget.Text);
                    lblManPowerBudget.Text = Convert.ToDouble(lblManPowerBudget.Text) == 0 ? "" : "₹ " + lblManPowerBudget.Text;
                }
                if (lblManPowerActual.Text != "")
                {
                    TotalManPowerActual = TotalManPowerActual + Convert.ToDouble(lblManPowerActual.Text);
                    lblManPowerActual.Text = Convert.ToDouble(lblManPowerActual.Text) == 0 ? "" : "₹ " + lblManPowerActual.Text;
                }
                if (lblCostBudget.Text != "")
                {
                    TotalCostBudget = TotalCostBudget + Convert.ToDouble(lblCostBudget.Text);
                    double CostBudget = Convert.ToDouble(lblCostBudget.Text);
                    lblCostBudget.Text = Convert.ToDouble(lblCostBudget.Text) == 0 ? "" : "₹ " + CostBudget.ToString("#,##0");
                }
                if (lblCostActual.Text != "")
                {
                    TotalCostActual = TotalCostActual + Convert.ToDouble(lblCostActual.Text);
                    double CostActual = Convert.ToDouble(lblCostActual.Text);
                    lblCostActual.Text = Convert.ToDouble(lblCostActual.Text) == 0 ? "" : "₹ " + CostActual.ToString("#,##0");
                }

                if (hdnOverHead != null)
                {
                    OverHead1 = Convert.ToDouble(hdnOverHead.Value);
                }
                if (hdnTotalActual != null)
                {
                    ActualTotal1 = ActualTotal1 + Convert.ToDouble(hdnTotalActual.Value);
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblOverHeadBudget = (Label)e.Row.FindControl("lblOverHeadBudget");
                Label lblOverHeadActual = (Label)e.Row.FindControl("lblOverHeadActual");

                Label lblCMTTotalBudget = (Label)e.Row.FindControl("lblCMTTotalBudget");
                Label lblCMTTotalActual = (Label)e.Row.FindControl("lblCMTTotalActual");
                Label lblCMTTotalCostBudget = (Label)e.Row.FindControl("lblCMTTotalCostBudget");
                Label lblCMTTotalCostActual = (Label)e.Row.FindControl("lblCMTTotalCostActual");

                if (WorkingHrs != "")
                {
                    if (BudgetwithMachine1 > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead1) / ((BudgetwithMachine1 * Convert.ToDouble(WorkingHrs) * 60));
                        lblOverHeadBudget.Text = Math.Round(overhead, 2) == 0 ? "" : "₹ " + Math.Round(overhead, 2).ToString();
                        TotalManPowerBudget = Math.Round(TotalManPowerBudget + overhead, 2);
                    }

                    if (ActualTotal1 > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead1) / ActualTotal1;
                        lblOverHeadActual.Text = Math.Round(overhead, 2) == 0 ? "" : "₹ " + Math.Round(overhead, 2).ToString();
                        TotalManPowerActual = Math.Round(TotalManPowerActual + overhead, 2);
                    }
                }

                lblCMTTotalBudget.Text = TotalManPowerBudget == 0 ? "" : "₹ " + TotalManPowerBudget.ToString();
                lblCMTTotalActual.Text = TotalManPowerActual == 0 ? "" : "₹ " + TotalManPowerActual.ToString();

                lblCMTTotalCostBudget.Text = TotalCostBudget == 0 ? "" : "₹ " + TotalCostBudget.ToString("#,##0");
                lblCMTTotalCostActual.Text = TotalCostActual == 0 ? "" : "₹ " + TotalCostActual.ToString("#,##0");

                CPAMBudget1 = TotalManPowerBudget;
                CPAMActual1 = TotalManPowerActual;

                TotalManPowerBudget = 0;
                TotalManPowerActual = 0;
                TotalCostBudget = 0;
                TotalCostActual = 0;
            }
        }

        protected void gvCMTFactory2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell ManPowerCell = new TableCell();
                ManPowerCell.Text = "CPAM";
                ManPowerCell.HorizontalAlign = HorizontalAlign.Center;
                ManPowerCell.Font.Bold = true;
                ManPowerCell.ColumnSpan = 2;
                TableCell CostCell = new TableCell();
                CostCell.Text = "CMT Cost";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 2;
                gvrow.Cells.Add(ManPowerCell);
                gvrow.Cells.Add(CostCell);
                gvCMTFactory2.Controls[0].Controls.AddAt(0, gvrow);
            }
        }

        protected void gvCMTFactory2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnOverHead = (HiddenField)e.Row.FindControl("hdnOverHead");
                HiddenField hdnTotalActual = (HiddenField)e.Row.FindControl("hdnTotalActual");

                Label lblManPowerBudget = (Label)e.Row.FindControl("lblManPowerBudget");
                Label lblManPowerActual = (Label)e.Row.FindControl("lblManPowerActual");
                Label lblCostBudget = (Label)e.Row.FindControl("lblCostBudget");
                Label lblCostActual = (Label)e.Row.FindControl("lblCostActual");

                if (lblManPowerBudget.Text != "")
                {
                    TotalManPowerBudget = TotalManPowerBudget + Convert.ToDouble(lblManPowerBudget.Text);
                    lblManPowerBudget.Text = Convert.ToDouble(lblManPowerBudget.Text) == 0 ? "" : "₹ " + lblManPowerBudget.Text;
                }
                if (lblManPowerActual.Text != "")
                {
                    TotalManPowerActual = TotalManPowerActual + Convert.ToDouble(lblManPowerActual.Text);
                    lblManPowerActual.Text = Convert.ToDouble(lblManPowerActual.Text) == 0 ? "" : "₹ " + lblManPowerActual.Text;
                }
                if (lblCostBudget.Text != "")
                {
                    TotalCostBudget = TotalCostBudget + Convert.ToDouble(lblCostBudget.Text);
                    double CostBudget = Convert.ToDouble(lblCostBudget.Text);
                    lblCostBudget.Text = Convert.ToDouble(lblCostBudget.Text) == 0 ? "" : "₹ " + CostBudget.ToString("#,##0");
                }
                if (lblCostActual.Text != "")
                {
                    TotalCostActual = TotalCostActual + Convert.ToDouble(lblCostActual.Text);
                    double CostActual = Convert.ToDouble(lblCostActual.Text);
                    lblCostActual.Text = Convert.ToDouble(lblCostActual.Text) == 0 ? "" : "₹ " + CostActual.ToString("#,##0");
                }

                if (hdnOverHead != null)
                {
                    OverHead2 = Convert.ToDouble(hdnOverHead.Value);
                }
                if (hdnTotalActual != null)
                {
                    ActualTotal2 = ActualTotal2 + Convert.ToDouble(hdnTotalActual.Value);
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblOverHeadBudget = (Label)e.Row.FindControl("lblOverHeadBudget");
                Label lblOverHeadActual = (Label)e.Row.FindControl("lblOverHeadActual");

                Label lblCMTTotalBudget = (Label)e.Row.FindControl("lblCMTTotalBudget");
                Label lblCMTTotalActual = (Label)e.Row.FindControl("lblCMTTotalActual");
                Label lblCMTTotalCostBudget = (Label)e.Row.FindControl("lblCMTTotalCostBudget");
                Label lblCMTTotalCostActual = (Label)e.Row.FindControl("lblCMTTotalCostActual");

                if (WorkingHrs != "")
                {
                    if (BudgetwithMachine2 > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead2) / ((BudgetwithMachine2 * Convert.ToDouble(WorkingHrs) * 60));
                        lblOverHeadBudget.Text = Math.Round(overhead, 2) == 0 ? "" : "₹ " + Math.Round(overhead, 2).ToString();
                        TotalManPowerBudget = Math.Round(TotalManPowerBudget + overhead, 2);
                    }
                    if (ActualTotal2 > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead2) / ActualTotal2;
                        lblOverHeadActual.Text = Math.Round(overhead, 2) == 0 ? "" : "₹ " + Math.Round(overhead, 2).ToString();
                        TotalManPowerActual = Math.Round(TotalManPowerActual + overhead, 2);
                    }
                }
                lblCMTTotalBudget.Text = TotalManPowerBudget == 0 ? "" : "₹ " + TotalManPowerBudget.ToString();
                lblCMTTotalActual.Text = TotalManPowerActual == 0 ? "" : "₹ " + TotalManPowerActual.ToString();

                lblCMTTotalCostBudget.Text = TotalCostBudget == 0 ? "" : "₹ " + TotalCostBudget.ToString("#,##0");
                lblCMTTotalCostActual.Text = TotalCostActual == 0 ? "" : "₹ " + TotalCostActual.ToString("#,##0");

                CPAMBudget2 = TotalManPowerBudget;
                CPAMActual2 = TotalManPowerActual;
                TotalManPowerBudget = 0;
                TotalManPowerActual = 0;
                TotalCostBudget = 0;
                TotalCostActual = 0;

            }
        }

        protected void gvCMTFactory3_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell ManPowerCell = new TableCell();
                ManPowerCell.Text = "CPAM";
                ManPowerCell.HorizontalAlign = HorizontalAlign.Center;
                ManPowerCell.Font.Bold = true;
                ManPowerCell.ColumnSpan = 2;
                TableCell CostCell = new TableCell();
                CostCell.Text = "CMT Cost";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 2;
                gvrow.Cells.Add(ManPowerCell);
                gvrow.Cells.Add(CostCell);
                gvCMTFactory3.Controls[0].Controls.AddAt(0, gvrow);
            }
        }

        protected void gvCMTFactory3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnOverHead = (HiddenField)e.Row.FindControl("hdnOverHead");
                HiddenField hdnTotalActual = (HiddenField)e.Row.FindControl("hdnTotalActual");

                Label lblManPowerBudget = (Label)e.Row.FindControl("lblManPowerBudget");
                Label lblManPowerActual = (Label)e.Row.FindControl("lblManPowerActual");
                Label lblCostBudget = (Label)e.Row.FindControl("lblCostBudget");
                Label lblCostActual = (Label)e.Row.FindControl("lblCostActual");

                if (lblManPowerBudget.Text != "")
                {
                    TotalManPowerBudget = TotalManPowerBudget + Convert.ToDouble(lblManPowerBudget.Text);
                    lblManPowerBudget.Text = Convert.ToDouble(lblManPowerBudget.Text) == 0 ? "" : "₹ " + lblManPowerBudget.Text;
                }
                if (lblManPowerActual.Text != "")
                {
                    TotalManPowerActual = TotalManPowerActual + Convert.ToDouble(lblManPowerActual.Text);
                    lblManPowerActual.Text = Convert.ToDouble(lblManPowerActual.Text) == 0 ? "" : "₹ " + lblManPowerActual.Text;
                }
                if (lblCostBudget.Text != "")
                {
                    TotalCostBudget = TotalCostBudget + Convert.ToDouble(lblCostBudget.Text);
                    double CostBudget = Convert.ToDouble(lblCostBudget.Text);
                    lblCostBudget.Text = Convert.ToDouble(lblCostBudget.Text) == 0 ? "" : "₹ " + CostBudget.ToString("#,##0");
                }
                if (lblCostActual.Text != "")
                {
                    TotalCostActual = TotalCostActual + Convert.ToDouble(lblCostActual.Text);
                    double CostActual = Convert.ToDouble(lblCostActual.Text);
                    lblCostActual.Text = Convert.ToDouble(lblCostActual.Text) == 0 ? "" : "₹ " + CostActual.ToString("#,##0");
                }

                if (hdnOverHead != null)
                {
                    OverHead3 = Convert.ToDouble(hdnOverHead.Value);
                }
                if (hdnTotalActual != null)
                {
                    ActualTotal3 = ActualTotal3 + Convert.ToDouble(hdnTotalActual.Value);
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblOverHeadBudget = (Label)e.Row.FindControl("lblOverHeadBudget");
                Label lblOverHeadActual = (Label)e.Row.FindControl("lblOverHeadActual");

                Label lblCMTTotalBudget = (Label)e.Row.FindControl("lblCMTTotalBudget");
                Label lblCMTTotalActual = (Label)e.Row.FindControl("lblCMTTotalActual");
                Label lblCMTTotalCostBudget = (Label)e.Row.FindControl("lblCMTTotalCostBudget");
                Label lblCMTTotalCostActual = (Label)e.Row.FindControl("lblCMTTotalCostActual");

                if (WorkingHrs != "")
                {
                    if (BudgetwithMachine3 > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead3) / ((BudgetwithMachine3 * Convert.ToDouble(WorkingHrs) * 60));
                        lblOverHeadBudget.Text = Math.Round(overhead, 2) == 0 ? "" : "₹ " + Math.Round(overhead, 2).ToString();
                        TotalManPowerBudget = Math.Round(TotalManPowerBudget + overhead, 2);
                    }
                    if (ActualTotal3 > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead3) / ActualTotal3;
                        lblOverHeadActual.Text = Math.Round(overhead, 2) == 0 ? "" : "₹ " + Math.Round(overhead, 2).ToString();
                        TotalManPowerActual = Math.Round(TotalManPowerActual + overhead, 2);
                    }
                }
                lblCMTTotalBudget.Text = TotalManPowerBudget == 0 ? "" : "₹ " + TotalManPowerBudget.ToString();
                lblCMTTotalActual.Text = TotalManPowerActual == 0 ? "" : "₹ " + TotalManPowerActual.ToString();

                lblCMTTotalCostBudget.Text = TotalCostBudget == 0 ? "" : "₹ " + TotalCostBudget.ToString("#,##0");
                lblCMTTotalCostActual.Text = TotalCostActual == 0 ? "" : "₹ " + TotalCostActual.ToString("#,##0");

                CPAMBudget3 = TotalManPowerBudget;
                CPAMActual3 = TotalManPowerActual;
                TotalManPowerBudget = 0;
                TotalManPowerActual = 0;
                TotalCostBudget = 0;
                TotalCostActual = 0;
            }
        }

        protected void gvCMTFactory4_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell ManPowerCell = new TableCell();
                ManPowerCell.Text = "CPAM";
                ManPowerCell.HorizontalAlign = HorizontalAlign.Center;
                ManPowerCell.Font.Bold = true;
                ManPowerCell.ColumnSpan = 2;
                TableCell CostCell = new TableCell();
                CostCell.Text = "CMT Cost";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 2;
                gvrow.Cells.Add(ManPowerCell);
                gvrow.Cells.Add(CostCell);
                gvCMTFactory4.Controls[0].Controls.AddAt(0, gvrow);
            }
        }

        protected void gvCMTFactory4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnOverHead = (HiddenField)e.Row.FindControl("hdnOverHead");
                HiddenField hdnTotalActual = (HiddenField)e.Row.FindControl("hdnTotalActual");

                Label lblManPowerBudget = (Label)e.Row.FindControl("lblManPowerBudget");
                Label lblManPowerActual = (Label)e.Row.FindControl("lblManPowerActual");
                Label lblCostBudget = (Label)e.Row.FindControl("lblCostBudget");
                Label lblCostActual = (Label)e.Row.FindControl("lblCostActual");

                if (lblManPowerBudget.Text != "")
                {
                    TotalManPowerBudget = TotalManPowerBudget + Convert.ToDouble(lblManPowerBudget.Text);
                    lblManPowerBudget.Text = Convert.ToDouble(lblManPowerBudget.Text) == 0 ? "" : "₹ " + lblManPowerBudget.Text;
                }
                if (lblManPowerActual.Text != "")
                {
                    TotalManPowerActual = TotalManPowerActual + Convert.ToDouble(lblManPowerActual.Text);
                    lblManPowerActual.Text = Convert.ToDouble(lblManPowerActual.Text) == 0 ? "" : "₹ " + lblManPowerActual.Text;
                }
                if (lblCostBudget.Text != "")
                {
                    TotalCostBudget = TotalCostBudget + Convert.ToDouble(lblCostBudget.Text);
                    double CostBudget = Convert.ToDouble(lblCostBudget.Text);
                    lblCostBudget.Text = Convert.ToDouble(lblCostBudget.Text) == 0 ? "" : "₹ " + CostBudget.ToString("#,##0");
                }
                if (lblCostActual.Text != "")
                {
                    TotalCostActual = TotalCostActual + Convert.ToDouble(lblCostActual.Text);
                    double CostActual = Convert.ToDouble(lblCostActual.Text);
                    lblCostActual.Text = Convert.ToDouble(lblCostActual.Text) == 0 ? "" : "₹ " + CostActual.ToString("#,##0");
                }  

                if (hdnOverHead != null)
                {
                    OverHead4 = Convert.ToDouble(hdnOverHead.Value);
                }
                if (hdnTotalActual != null)
                {
                    ActualTotal4 = ActualTotal4 + Convert.ToDouble(hdnTotalActual.Value);
                }
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblOverHeadBudget = (Label)e.Row.FindControl("lblOverHeadBudget");
                Label lblOverHeadActual = (Label)e.Row.FindControl("lblOverHeadActual");

                Label lblCMTTotalBudget = (Label)e.Row.FindControl("lblCMTTotalBudget");
                Label lblCMTTotalActual = (Label)e.Row.FindControl("lblCMTTotalActual");
                Label lblCMTTotalCostBudget = (Label)e.Row.FindControl("lblCMTTotalCostBudget");
                Label lblCMTTotalCostActual = (Label)e.Row.FindControl("lblCMTTotalCostActual");

                if (WorkingHrs != "")
                {
                    if (BudgetwithMachine4 > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead4) / ((BudgetwithMachine4 * Convert.ToDouble(WorkingHrs) * 60));
                        lblOverHeadBudget.Text = Math.Round(overhead, 2) == 0 ? "" : "₹ " + Math.Round(overhead, 2).ToString();
                        TotalManPowerBudget = Math.Round(TotalManPowerBudget + overhead, 2);
                    }
                    if (ActualTotal4 > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead4) / ActualTotal4;
                        lblOverHeadActual.Text = Math.Round(overhead, 2) == 0 ? "" : "₹ " + Math.Round(overhead, 2).ToString();
                        TotalManPowerActual = Math.Round(TotalManPowerActual + overhead, 2);
                    }
                }

                lblCMTTotalBudget.Text = TotalManPowerBudget == 0 ? "" : "₹ " + TotalManPowerBudget.ToString();
                lblCMTTotalActual.Text = TotalManPowerActual == 0 ? "" : "₹ " + TotalManPowerActual.ToString();

                lblCMTTotalCostBudget.Text = TotalCostBudget == 0 ? "" : "₹ " + TotalCostBudget.ToString("#,##0");
                lblCMTTotalCostActual.Text = TotalCostActual == 0 ? "" : "₹ " + TotalCostActual.ToString("#,##0");

                CPAMBudget4 = TotalManPowerBudget;
                CPAMActual4 = TotalManPowerActual;
                TotalManPowerBudget = 0;
                TotalManPowerActual = 0;
                TotalCostBudget = 0;
                TotalCostActual = 0;

            }
        }

        #endregion

        #region MMR summary

        private void FillMMRFactoryUnitName()
        {
            DataTable dtUnitName = objBuyingHouseController.GetBiplUNITNAMEBAL();
            DataTable dt2 = new DataTable();
            for (int i = 0; i <= dtUnitName.Rows.Count; i++)
            {
                dt2.Columns.Add();
            }
            for (int i = 0; i < dtUnitName.Columns.Count; i++)
            {
                dt2.Rows.Add();
                dt2.Rows[i][0] = dtUnitName.Columns[i].ColumnName;
            }
            for (int i = 0; i < dtUnitName.Columns.Count; i++)
            {
                for (int j = 0; j < dtUnitName.Rows.Count; j++)
                {
                    dt2.Rows[i][j + 1] = dtUnitName.Rows[j][i];
                }
            }
            gvMMRFactory.DataSource = dt2;
            gvMMRFactory.DataBind();
        }

        private void FillMMRSummaryStaff(string sUnitName, DateTime dtFromDate, DateTime dtToDate, string sFinancialYear)
        {
            DataTable dtStaffDept = objBuyingHouseController.GetMMR_Summary_DateRange_BAL(sUnitName, dtFromDate, dtToDate, sFinancialYear);
            gvMMRSummaryStaff.DataSource = dtStaffDept;
            gvMMRSummaryStaff.DataBind();
        }

        private void FillMMRSummary(string sUnitName, DateTime dtFromDate, DateTime dtToDate, string sFinancialYear)
        {
            if (sUnitName == "C 47")
            {
                DataTable dtMMRSummary = objBuyingHouseController.GetMMR_Summary_DateRange_BAL(sUnitName, dtFromDate, dtToDate, sFinancialYear);
                if (dtMMRSummary.Rows.Count > 0)
                {
                    AvailMinsActual = dtMMRSummary.Rows[0]["AvailMinsActual"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["AvailMinsActual"]);
                }
                gvMMRSummary1.DataSource = dtMMRSummary;
                gvMMRSummary1.DataBind();
            }
            if (sUnitName == "C 45-46")
            {
                DataTable dtMMRSummary = objBuyingHouseController.GetMMR_Summary_DateRange_BAL(sUnitName, dtFromDate, dtToDate, sFinancialYear);
                if (dtMMRSummary.Rows.Count > 0)
                {
                    AvailMinsActual = dtMMRSummary.Rows[0]["AvailMinsActual"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["AvailMinsActual"]);
                }
                gvMMRSummary2.DataSource = dtMMRSummary;
                gvMMRSummary2.DataBind();
            }
            if (sUnitName == "B 45")
            {
                DataTable dtMMRSummary = objBuyingHouseController.GetMMR_Summary_DateRange_BAL(sUnitName, dtFromDate, dtToDate, sFinancialYear);
                if (dtMMRSummary.Rows.Count > 0)
                {
                    AvailMinsActual = dtMMRSummary.Rows[0]["AvailMinsActual"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["AvailMinsActual"]);
                }
                gvMMRSummary3.DataSource = dtMMRSummary;
                gvMMRSummary3.DataBind();
            }
            if (sUnitName == "BIPL")
            {
                DataTable dtMMRSummary = objBuyingHouseController.GetMMR_Summary_DateRange_BAL(sUnitName, dtFromDate, dtToDate, sFinancialYear);
                if (dtMMRSummary.Rows.Count > 0)
                {
                    AvailMinsActual = dtMMRSummary.Rows[0]["AvailMinsActual"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["AvailMinsActual"]);
                }
                gvMMRSummary4.DataSource = dtMMRSummary;
                gvMMRSummary4.DataBind();
            }
        }

        protected void gvMMRFactory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 0)
            {
                e.Row.BackColor = System.Drawing.Color.FromName("#dddfe4");
                e.Row.Cells[0].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[1].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[2].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[3].ForeColor = System.Drawing.Color.FromName("#575759");
                e.Row.Cells[4].ForeColor = System.Drawing.Color.FromName("#575759");
            }
            else
            {
                e.Row.Visible = false;
            }
        }

        protected void gvMMRSummary1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblBudgetMMR = (Label)e.Row.FindControl("lblBudgetMMR");
                if (BudgetwithMachine1 > 0)
                {
                    lblBudgetMMR.Text = Math.Round((TotalManPowerBudget1 / BudgetwithMachine1), 2).ToString();
                }

                Label lblActualMMR = (Label)e.Row.FindControl("lblActualMMR");
                if (ActualwithMachine1 > 0)
                {
                    lblActualMMR.Text = Math.Round((TotalManPowerActual1 / ActualwithMachine1), 2).ToString();
                }

                Label lblDiff = (Label)e.Row.FindControl("lblDiff");
                if ((lblBudgetMMR.Text != "") && (lblActualMMR.Text != ""))
                {
                    lblDiff.Text = Math.Round((Convert.ToDouble(lblBudgetMMR.Text) - Convert.ToDouble(lblActualMMR.Text)),2).ToString();
                }


                Label lblProMachineBudget = (Label)e.Row.FindControl("lblProMachineBudget");
                if (BudgetwithMachine1 > 0)
                {                  
                    lblProMachineBudget.Text = BudgetwithMachine1.ToString();
                }

                Label lblProMachineActual = (Label)e.Row.FindControl("lblProMachineActual");
                if (ActualwithMachine1 > 0)
                {                   
                    lblProMachineActual.Text = ActualwithMachine1.ToString();
                }

                Label lblProMachineDiff = (Label)e.Row.FindControl("lblProMachineDiff");
                if ((BudgetwithMachine1 > 0) || (ActualwithMachine1 > 0))
                {
                    lblProMachineDiff.Text = Math.Round((BudgetwithMachine1 - ActualwithMachine1), 2).ToString();
                }

                Label lblAvailMinsBudget = (Label)e.Row.FindControl("lblAvailMinsBudget");
                double AvailBudget = 0;
                if (WorkingHrs != "")
                {
                    AvailBudget = BudgetwithMachine1 * Convert.ToDouble(WorkingHrs) * 60;
                    lblAvailMinsBudget.Text = Math.Round(Convert.ToDouble(AvailBudget) / 100000, 1).ToString() + " L";                   
                }

                Label lblAvailMinsActual = (Label)e.Row.FindControl("lblAvailMinsActual");
                if (AvailMinsActual > 0)
                {
                    lblAvailMinsActual.Text = Math.Round(Convert.ToDouble(AvailMinsActual) / 100000, 1).ToString() + " L";                   
                }

                Label lblAvailMinsDiff = (Label)e.Row.FindControl("lblAvailMinsDiff");
                if (AvailMinsActual > 0)
                {
                    lblAvailMinsDiff.Text = Math.Round(Convert.ToDouble(AvailBudget - AvailMinsActual) / 100000, 1).ToString() + " L";                    
                }

                Label lblCPAMBudget = (Label)e.Row.FindControl("lblCPAMBudget");
                Label lblCPAMActual = (Label)e.Row.FindControl("lblCPAMActual");
                Label lblCPAMDiff = (Label)e.Row.FindControl("lblCPAMDiff");
                

                HtmlTableCell tdDiff = e.Row.FindControl("tdDiff") as HtmlTableCell;
                HtmlTableCell tdProMachineDiff = e.Row.FindControl("tdProMachineDiff") as HtmlTableCell;
                HtmlTableCell tdAvailMinsDiff = e.Row.FindControl("tdAvailMinsDiff") as HtmlTableCell;
                HtmlTableCell tdCPAMDiff = e.Row.FindControl("tdCPAMDiff") as HtmlTableCell;

                if (lblDiff.Text != "")
                {
                    if (Convert.ToDouble(lblDiff.Text) >= 0)
                    {
                        tdDiff.Style.Add("background-color", "#008000");
                        lblDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdDiff.Style.Add("background-color", "#FF0000");
                        lblDiff.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblProMachineDiff.Text != "")
                {
                    if (Convert.ToDouble(lblProMachineDiff.Text) >= 0)
                    {
                        tdProMachineDiff.Style.Add("background-color", "#008000");
                        lblProMachineDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdProMachineDiff.Style.Add("background-color", "#FF0000");
                        lblProMachineDiff.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblAvailMinsDiff.Text != "")
                {
                    if (Convert.ToDouble(AvailBudget - AvailMinsActual) >= 0)
                    {
                        tdAvailMinsDiff.Style.Add("background-color", "#008000");
                        lblAvailMinsDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdAvailMinsDiff.Style.Add("background-color", "#FF0000");
                        lblAvailMinsDiff.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblCPAMDiff.Text != "")
                {
                    if (Convert.ToDouble(lblCPAMDiff.Text) >= 0)
                    {
                        tdCPAMDiff.Style.Add("background-color", "#008000");
                        lblCPAMDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdCPAMDiff.Style.Add("background-color", "#FF0000");
                        lblCPAMDiff.ForeColor = System.Drawing.Color.White;
                    }
                }
                if (CPAMBudget1 > 0)
                {
                    lblCPAMBudget.Text = "₹ " + CPAMBudget1.ToString();
                }

                if (CPAMActual1 > 0)
                {
                    lblCPAMActual.Text = "₹ " + CPAMActual1.ToString();
                }

                if ((CPAMBudget1 > 0) || (CPAMActual1 > 0))
                {
                    lblCPAMDiff.Text = "₹ " + Math.Round((CPAMBudget1 - CPAMActual1), 2).ToString();
                }

                if (lblProMachineBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblProMachineBudget.Text);
                    lblProMachineBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblProMachineActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblProMachineActual.Text);
                    lblProMachineActual.Text = ManPower.ToString("#,##0");
                }
                if (lblProMachineDiff.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblProMachineDiff.Text);
                    lblProMachineDiff.Text = ManPower.ToString("#,##0");
                }

            }
        }

        protected void gvMMRSummary2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblBudgetMMR = (Label)e.Row.FindControl("lblBudgetMMR");
                if (BudgetwithMachine2 > 0)
                {
                    lblBudgetMMR.Text = Math.Round((TotalManPowerBudget2 / BudgetwithMachine2), 2).ToString();
                }

                Label lblActualMMR = (Label)e.Row.FindControl("lblActualMMR");
                if (ActualwithMachine2 > 0)
                {
                    lblActualMMR.Text = Math.Round((TotalManPowerActual2 / ActualwithMachine2), 2).ToString();
                }

                Label lblDiff = (Label)e.Row.FindControl("lblDiff");
                if ((lblBudgetMMR.Text != "") && (lblActualMMR.Text != ""))
                {
                    lblDiff.Text = Math.Round((Convert.ToDouble(lblBudgetMMR.Text) - Convert.ToDouble(lblActualMMR.Text)),2).ToString();
                }


                Label lblProMachineBudget = (Label)e.Row.FindControl("lblProMachineBudget");
                if (BudgetwithMachine2 > 0)
                {                    
                    lblProMachineBudget.Text = BudgetwithMachine2.ToString();
                }

                Label lblProMachineActual = (Label)e.Row.FindControl("lblProMachineActual");
                if (ActualwithMachine2 > 0)
                {                   
                    lblProMachineActual.Text = ActualwithMachine2.ToString();
                }

                Label lblProMachineDiff = (Label)e.Row.FindControl("lblProMachineDiff");
                if ((BudgetwithMachine2 > 0) || (ActualwithMachine2 > 0))
                {
                    lblProMachineDiff.Text = Math.Round((BudgetwithMachine2 - ActualwithMachine2), 2).ToString();
                }


                Label lblAvailMinsBudget = (Label)e.Row.FindControl("lblAvailMinsBudget");
                double AvailBudget = 0;
                if (WorkingHrs != "")
                {
                    AvailBudget = BudgetwithMachine2 * Convert.ToDouble(WorkingHrs) * 60;
                    lblAvailMinsBudget.Text = Math.Round(Convert.ToDouble(AvailBudget) / 100000, 1).ToString() + " L";                    
                }

                Label lblAvailMinsActual = (Label)e.Row.FindControl("lblAvailMinsActual");
                if (AvailMinsActual > 0)
                {
                    lblAvailMinsActual.Text = Math.Round(Convert.ToDouble(AvailMinsActual) / 100000, 1).ToString() + " L";                   
                }

                Label lblAvailMinsDiff = (Label)e.Row.FindControl("lblAvailMinsDiff");
                if (AvailMinsActual > 0)
                {
                    lblAvailMinsDiff.Text = Math.Round(Convert.ToDouble(AvailBudget - AvailMinsActual) / 100000, 1).ToString() + " L";                    
                }

                Label lblCPAMBudget = (Label)e.Row.FindControl("lblCPAMBudget");
                Label lblCPAMActual = (Label)e.Row.FindControl("lblCPAMActual");
                Label lblCPAMDiff = (Label)e.Row.FindControl("lblCPAMDiff");                

                HtmlTableCell tdDiff = e.Row.FindControl("tdDiff") as HtmlTableCell;
                HtmlTableCell tdProMachineDiff = e.Row.FindControl("tdProMachineDiff") as HtmlTableCell;
                HtmlTableCell tdAvailMinsDiff = e.Row.FindControl("tdAvailMinsDiff") as HtmlTableCell;
                HtmlTableCell tdCPAMDiff = e.Row.FindControl("tdCPAMDiff") as HtmlTableCell;

                if (lblDiff.Text != "")
                {
                    if (Convert.ToDouble(lblDiff.Text) >= 0)
                    {
                        tdDiff.Style.Add("background-color", "#008000");
                        lblDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdDiff.Style.Add("background-color", "#FF0000");
                        lblDiff.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblProMachineDiff.Text != "")
                {
                    if (Convert.ToDouble(lblProMachineDiff.Text) >= 0)
                    {
                        tdProMachineDiff.Style.Add("background-color", "#008000");
                        lblProMachineDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdProMachineDiff.Style.Add("background-color", "#FF0000");
                        lblProMachineDiff.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblAvailMinsDiff.Text != "")
                {
                    if (Convert.ToDouble(AvailBudget - AvailMinsActual) >= 0)
                    {
                        tdAvailMinsDiff.Style.Add("background-color", "#008000");
                        lblAvailMinsDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdAvailMinsDiff.Style.Add("background-color", "#FF0000");
                        lblAvailMinsDiff.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblCPAMDiff.Text != "")
                {
                    if (Convert.ToDouble(lblCPAMDiff.Text) >= 0)
                    {
                        tdCPAMDiff.Style.Add("background-color", "#008000");
                        lblCPAMDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdCPAMDiff.Style.Add("background-color", "#FF0000");
                        lblCPAMDiff.ForeColor = System.Drawing.Color.White;
                    }
                }
                if (CPAMBudget2 > 0)
                {
                    lblCPAMBudget.Text = "₹ " + CPAMBudget2.ToString();
                }

                if (CPAMActual2 > 0)
                {
                    lblCPAMActual.Text = "₹ " + CPAMActual2.ToString();
                }

                if ((CPAMBudget2 > 0) || (CPAMActual2 > 0))
                {
                    lblCPAMDiff.Text = "₹ " + Math.Round((CPAMBudget2 - CPAMActual2), 2).ToString();
                }

                if (lblProMachineBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblProMachineBudget.Text);
                    lblProMachineBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblProMachineActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblProMachineActual.Text);
                    lblProMachineActual.Text = ManPower.ToString("#,##0");
                }
                if (lblProMachineDiff.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblProMachineDiff.Text);
                    lblProMachineDiff.Text = ManPower.ToString("#,##0");
                }
            }
        }

        protected void gvMMRSummary3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblBudgetMMR = (Label)e.Row.FindControl("lblBudgetMMR");
                if (BudgetwithMachine3 > 0)
                {
                    lblBudgetMMR.Text = Math.Round((TotalManPowerBudget3 / BudgetwithMachine3), 2).ToString();
                }

                Label lblActualMMR = (Label)e.Row.FindControl("lblActualMMR");
                if (ActualwithMachine3 > 0)
                {
                    lblActualMMR.Text = Math.Round((TotalManPowerActual3 / ActualwithMachine3), 2).ToString();
                }

                Label lblDiff = (Label)e.Row.FindControl("lblDiff");
                if ((lblBudgetMMR.Text != "") && (lblActualMMR.Text != ""))
                {
                    lblDiff.Text = Math.Round((Convert.ToDouble(lblBudgetMMR.Text) - Convert.ToDouble(lblActualMMR.Text)),2).ToString();
                }


                Label lblProMachineBudget = (Label)e.Row.FindControl("lblProMachineBudget");
                if (BudgetwithMachine3 > 0)
                {                   
                    lblProMachineBudget.Text = BudgetwithMachine3.ToString();
                }

                Label lblProMachineActual = (Label)e.Row.FindControl("lblProMachineActual");
                if (ActualwithMachine3 > 0)
                {                    
                    lblProMachineActual.Text = ActualwithMachine3.ToString();
                }

                Label lblProMachineDiff = (Label)e.Row.FindControl("lblProMachineDiff");
                if ((BudgetwithMachine3 > 0) || (ActualwithMachine3 > 0))
                {
                    lblProMachineDiff.Text = Math.Round((BudgetwithMachine3 - ActualwithMachine3), 2).ToString();
                }


                Label lblAvailMinsBudget = (Label)e.Row.FindControl("lblAvailMinsBudget");
                double AvailBudget = 0;
                if (WorkingHrs != "")
                {
                    AvailBudget = BudgetwithMachine3 * Convert.ToDouble(WorkingHrs) * 60;
                    lblAvailMinsBudget.Text = Math.Round(Convert.ToDouble(AvailBudget) / 100000, 1).ToString() + " L";                    
                }

                Label lblAvailMinsActual = (Label)e.Row.FindControl("lblAvailMinsActual");
                if (AvailMinsActual > 0)
                {
                    lblAvailMinsActual.Text = Math.Round(Convert.ToDouble(AvailMinsActual) / 100000, 1).ToString() + " L";                 
                }

                Label lblAvailMinsDiff = (Label)e.Row.FindControl("lblAvailMinsDiff");
                if (AvailMinsActual > 0)
                {
                    lblAvailMinsDiff.Text = Math.Round(Convert.ToDouble(AvailBudget - AvailMinsActual) / 100000, 1).ToString() + " L";                    
                }

                Label lblCPAMBudget = (Label)e.Row.FindControl("lblCPAMBudget");
                Label lblCPAMActual = (Label)e.Row.FindControl("lblCPAMActual");
                Label lblCPAMDiff = (Label)e.Row.FindControl("lblCPAMDiff");                


                HtmlTableCell tdDiff = e.Row.FindControl("tdDiff") as HtmlTableCell;
                HtmlTableCell tdProMachineDiff = e.Row.FindControl("tdProMachineDiff") as HtmlTableCell;
                HtmlTableCell tdAvailMinsDiff = e.Row.FindControl("tdAvailMinsDiff") as HtmlTableCell;
                HtmlTableCell tdCPAMDiff = e.Row.FindControl("tdCPAMDiff") as HtmlTableCell;

                if (lblDiff.Text != "")
                {
                    if (Convert.ToDouble(lblDiff.Text) >= 0)
                    {
                        tdDiff.Style.Add("background-color", "#008000");
                        lblDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdDiff.Style.Add("background-color", "#FF0000");
                        lblDiff.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblProMachineDiff.Text != "")
                {
                    if (Convert.ToDouble(lblProMachineDiff.Text) >= 0)
                    {
                        tdProMachineDiff.Style.Add("background-color", "#008000");
                        lblProMachineDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdProMachineDiff.Style.Add("background-color", "#FF0000");
                        lblProMachineDiff.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblAvailMinsDiff.Text != "")
                {
                    if (Convert.ToDouble(AvailBudget - AvailMinsActual) >= 0)
                    {
                        tdAvailMinsDiff.Style.Add("background-color", "#008000");
                        lblAvailMinsDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdAvailMinsDiff.Style.Add("background-color", "#FF0000");
                        lblAvailMinsDiff.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblCPAMDiff.Text != "")
                {
                    if (Convert.ToDouble(lblCPAMDiff.Text) >= 0)
                    {
                        tdCPAMDiff.Style.Add("background-color", "#008000");
                        lblCPAMDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdCPAMDiff.Style.Add("background-color", "#FF0000");
                        lblCPAMDiff.ForeColor = System.Drawing.Color.White;
                    }
                }
                if (CPAMBudget3 > 0)
                {
                    lblCPAMBudget.Text = "₹ " + CPAMBudget3.ToString();
                }

                if (CPAMActual3 > 0)
                {
                    lblCPAMActual.Text = "₹ " + CPAMActual3.ToString();
                }

                if ((CPAMBudget3 > 0) || (CPAMActual3 > 0))
                {
                    lblCPAMDiff.Text = "₹ " + Math.Round((CPAMBudget3 - CPAMActual3), 2).ToString();
                }

                if (lblProMachineBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblProMachineBudget.Text);
                    lblProMachineBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblProMachineActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblProMachineActual.Text);
                    lblProMachineActual.Text = ManPower.ToString("#,##0");
                }
                if (lblProMachineDiff.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblProMachineDiff.Text);
                    lblProMachineDiff.Text = ManPower.ToString("#,##0");
                }
            }
        }

        protected void gvMMRSummary4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblBudgetMMR = (Label)e.Row.FindControl("lblBudgetMMR");
                if (BudgetwithMachine4 > 0)
                {
                    lblBudgetMMR.Text = Math.Round((TotalManPowerBudget4 / BudgetwithMachine4), 2).ToString();
                }

                Label lblActualMMR = (Label)e.Row.FindControl("lblActualMMR");
                if (ActualwithMachine4 > 0)
                {
                    lblActualMMR.Text = Math.Round((TotalManPowerActual4 / ActualwithMachine4), 2).ToString();
                }

                Label lblDiff = (Label)e.Row.FindControl("lblDiff");
                if ((lblBudgetMMR.Text != "") && (lblActualMMR.Text != ""))
                {
                    lblDiff.Text = Math.Round((Convert.ToDouble(lblBudgetMMR.Text) - Convert.ToDouble(lblActualMMR.Text)),2).ToString();
                }


                Label lblProMachineBudget = (Label)e.Row.FindControl("lblProMachineBudget");
                if (BudgetwithMachine4 > 0)
                {                    
                    lblProMachineBudget.Text = BudgetwithMachine4.ToString();
                }

                Label lblProMachineActual = (Label)e.Row.FindControl("lblProMachineActual");
                if (ActualwithMachine4 > 0)
                {                    
                    lblProMachineActual.Text = ActualwithMachine4.ToString();
                }

                Label lblProMachineDiff = (Label)e.Row.FindControl("lblProMachineDiff");
                if ((BudgetwithMachine4 > 0) || (ActualwithMachine4 > 0))
                {
                    lblProMachineDiff.Text = Math.Round((BudgetwithMachine4 - ActualwithMachine4), 2).ToString();
                }

                Label lblAvailMinsBudget = (Label)e.Row.FindControl("lblAvailMinsBudget");
                double AvailBudget = 0;
                if (WorkingHrs != "")
                {
                    AvailBudget = BudgetwithMachine4 * Convert.ToDouble(WorkingHrs) * 60;
                    lblAvailMinsBudget.Text = Math.Round(Convert.ToDouble(AvailBudget) / 100000, 1).ToString() + " L";                   
                }

                Label lblAvailMinsActual = (Label)e.Row.FindControl("lblAvailMinsActual");
                if (AvailMinsActual > 0)
                {
                    lblAvailMinsActual.Text = Math.Round(Convert.ToDouble(AvailMinsActual) / 100000, 1).ToString() + " L";                
                }

                Label lblAvailMinsDiff = (Label)e.Row.FindControl("lblAvailMinsDiff");
                if (AvailMinsActual > 0)
                {
                    lblAvailMinsDiff.Text = Math.Round(Convert.ToDouble(AvailBudget - AvailMinsActual) / 100000, 1).ToString() + " L";                 
                }

                Label lblCPAMBudget = (Label)e.Row.FindControl("lblCPAMBudget");
                Label lblCPAMActual = (Label)e.Row.FindControl("lblCPAMActual");
                Label lblCPAMDiff = (Label)e.Row.FindControl("lblCPAMDiff");                

                HtmlTableCell tdDiff = e.Row.FindControl("tdDiff") as HtmlTableCell;
                HtmlTableCell tdProMachineDiff = e.Row.FindControl("tdProMachineDiff") as HtmlTableCell;
                HtmlTableCell tdAvailMinsDiff = e.Row.FindControl("tdAvailMinsDiff") as HtmlTableCell;
                HtmlTableCell tdCPAMDiff = e.Row.FindControl("tdCPAMDiff") as HtmlTableCell;

                if (lblDiff.Text != "")
                {
                    if (Convert.ToDouble(lblDiff.Text) >= 0)
                    {
                        tdDiff.Style.Add("background-color", "#008000");
                        lblDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdDiff.Style.Add("background-color", "#FF0000");
                        lblDiff.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblProMachineDiff.Text != "")
                {
                    if (Convert.ToDouble(lblProMachineDiff.Text) >= 0)
                    {
                        tdProMachineDiff.Style.Add("background-color", "#008000");
                        lblProMachineDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdProMachineDiff.Style.Add("background-color", "#FF0000");
                        lblProMachineDiff.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblAvailMinsDiff.Text != "")
                {
                    if (Convert.ToDouble(AvailBudget - AvailMinsActual) >= 0)
                    {
                        tdAvailMinsDiff.Style.Add("background-color", "#008000");
                        lblAvailMinsDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdAvailMinsDiff.Style.Add("background-color", "#FF0000");
                        lblAvailMinsDiff.ForeColor = System.Drawing.Color.White;
                    }
                }

                if (lblCPAMDiff.Text != "")
                {
                    if (Convert.ToDouble(lblCPAMDiff.Text) >= 0)
                    {
                        tdCPAMDiff.Style.Add("background-color", "#008000");
                        lblCPAMDiff.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        tdCPAMDiff.Style.Add("background-color", "#FF0000");
                        lblCPAMDiff.ForeColor = System.Drawing.Color.White;
                    }
                }
                if (CPAMBudget4 > 0)
                {
                    lblCPAMBudget.Text = "₹ " + CPAMBudget4.ToString();
                }

                if (CPAMActual4 > 0)
                {
                    lblCPAMActual.Text = "₹ " + CPAMActual4.ToString();
                }

                if ((CPAMBudget4 > 0) || (CPAMActual4 > 0))
                {
                    lblCPAMDiff.Text = "₹ " + Math.Round((CPAMBudget4 - CPAMActual4), 2).ToString();
                }

                if (lblProMachineBudget.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblProMachineBudget.Text);
                    lblProMachineBudget.Text = ManPower.ToString("#,##0");
                }
                if (lblProMachineActual.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblProMachineActual.Text);
                    lblProMachineActual.Text = ManPower.ToString("#,##0");
                }
                if (lblProMachineDiff.Text != "")
                {
                    int ManPower = Convert.ToInt32(lblProMachineDiff.Text);
                    lblProMachineDiff.Text = ManPower.ToString("#,##0");
                }

            }
        }

        #endregion
    }
}