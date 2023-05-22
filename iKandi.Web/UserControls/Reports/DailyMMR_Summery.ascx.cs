using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using iKandi.BLL.Production;
using iKandi.Common;
using System.Data;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.UserControls.Reports
{
    public partial class DailyMMR_Summery : System.Web.UI.UserControl
    {        
        ProductionController objProductionController = new ProductionController();

        
        string WorkingHrs = "";
        string sFinancialYear = "";

        #region MMR Summery
        double OverHead1 = 0;
        double OverHead2 = 0;
        double OverHead3 = 0;
        double OverHead4 = 0;
        double TotalManPowerBudget = 0;
        double TotalManPowerActual = 0;
        double TotalCostBudget = 0;
        double TotalCostActual = 0;
        double TotalManPowerActual1 = 0;
        double TotalManPowerActual2 = 0;
        double TotalManPowerActual3 = 0;
        double TotalManPowerActual4 = 0;
        double TotalManPowerBudget1 = 0;
        double TotalManPowerBudget2 = 0;
        double TotalManPowerBudget3 = 0;
        double TotalManPowerBudget4 = 0;
        double BudgetwithMachine = 0;
        double ActualwithMachine = 0;
        double CPAMBudget = 0;
        double CPAMActual = 0;
        double AvailMinsActual = 0;
        double TotalCostBudget_CPAM1 = 0;
        double TotalCostActual_CPAM1 = 0;
        double TotalCostBudget_CPAM2 = 0;
        double TotalCostActual_CPAM2 = 0;
        double TotalCostBudget_CPAM3 = 0;
        double TotalCostActual_CPAM3 = 0;
        double TotalCostBudget_CPAM4 = 0;
        double TotalCostActual_CPAM4 = 0;
        #endregion

        DateTime dtStartDate = DateTime.Now, dtEndDate = DateTime.Now;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //dtStartDate = Convert.ToDateTime("09/09/2015");
                WorkingHrs = objProductionController.GetMMR_WorkingHours_BAL(dtStartDate, DateTime.MinValue);

                GetMMRSummery(dtStartDate, WorkingHrs);
            }
        }

        private void GetMMRSummery(DateTime dtDate, string WrkingHrs)
        {
            FillBudgetFactoryUnitName();
            FillBudgetSummaryStaffDept("", dtDate, sFinancialYear);

            FillBudgetSummary("C 47", dtDate, sFinancialYear);
            FillBudgetSummary("C 45-46", dtDate, sFinancialYear);
            FillBudgetSummary("B 45", dtDate, sFinancialYear);
            FillBudgetSummary("BIPL", dtDate, sFinancialYear);

            FillMMRFactoryUnitName();
            FillMMRSummaryStaff("", dtDate, sFinancialYear);

            FillMMRSummary("C 47", dtDate, sFinancialYear);
            FillMMRSummary("C 45-46", dtDate, sFinancialYear);
            FillMMRSummary("B 45", dtDate, sFinancialYear);
            FillMMRSummary("BIPL", dtDate, sFinancialYear);
        }

        #region BudgetSummary

        private void FillBudgetFactoryUnitName()
        {
            DataTable dtUnitName = objProductionController.GetBiplUNITNAMEBAL();
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

        private void FillBudgetSummaryStaffDept(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            DataTable dtStaffDept = objProductionController.GetMMR_BudgetSummary_Daily_BAL(sUnitName, dtDate, sFinancialYear);
            gvBudgetSummaryStaffDept.DataSource = dtStaffDept;
            gvBudgetSummaryStaffDept.DataBind();
        }

        private void FillBudgetSummary(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            if (sUnitName == "C 47")
            {
                DataTable dtFactoryDetails = objProductionController.GetMMR_BudgetSummary_Daily_BAL(sUnitName, dtDate, sFinancialYear);
                gvBudgetSummary1.DataSource = dtFactoryDetails;
                gvBudgetSummary1.DataBind();
            }
            if (sUnitName == "C 45-46")
            {
                DataTable dtFactoryDetails = objProductionController.GetMMR_BudgetSummary_Daily_BAL(sUnitName, dtDate, sFinancialYear);
                gvBudgetSummary2.DataSource = dtFactoryDetails;
                gvBudgetSummary2.DataBind();
            }
            if (sUnitName == "B 45")
            {
                DataTable dtFactoryDetails = objProductionController.GetMMR_BudgetSummary_Daily_BAL(sUnitName, dtDate, sFinancialYear);
                gvBudgetSummary3.DataSource = dtFactoryDetails;
                gvBudgetSummary3.DataBind();
            }
            if (sUnitName == "BIPL")
            {
                DataTable dtFactoryDetails = objProductionController.GetMMR_BudgetSummary_Daily_BAL(sUnitName, dtDate, sFinancialYear);
                gvBudgetSummary4.DataSource = dtFactoryDetails;
                gvBudgetSummary4.DataBind();
            }
        }

        protected void gvFactoryBudgetSummary_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 0)
            {
                e.Row.BackColor = System.Drawing.Color.FromName("#405D99");
                e.Row.Cells[0].ForeColor = System.Drawing.Color.FromName("#FFFFFF");
                e.Row.Cells[1].ForeColor = System.Drawing.Color.FromName("#FFFFFF");
                e.Row.Cells[2].ForeColor = System.Drawing.Color.FromName("#FFFFFF");
                e.Row.Cells[3].ForeColor = System.Drawing.Color.FromName("#FFFFFF");
                e.Row.Cells[4].ForeColor = System.Drawing.Color.FromName("#FFFFFF");
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
                ManPowerCell.Height = 30;
                TableCell CostCell = new TableCell();
                CostCell.Text = "Financial";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 3;
                ManPowerCell.Height = 30;
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

                lblCostDifferences.Text = Math.Round(Convert.ToDouble(lblCostDifferences.Text) / 100000, 1) == 0 ? "" : "₹ " + Math.Round(Convert.ToDouble(lblCostDifferences.Text) / 100000, 1) + " L";

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
                TotalCostBudget_CPAM1 = TotalCostBudget;
                TotalCostActual_CPAM1 = TotalCostActual;

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
                ManPowerCell.Height = 30;
                TableCell CostCell = new TableCell();
                CostCell.Text = "Financial";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 3;
                ManPowerCell.Height = 30;
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

                TotalCostBudget_CPAM2 = TotalCostBudget;
                TotalCostActual_CPAM2 = TotalCostActual;
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
                ManPowerCell.Height = 30;
                TableCell CostCell = new TableCell();
                CostCell.Text = "Financial";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 3;
                ManPowerCell.Height = 30;
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
                TotalCostBudget_CPAM3 = TotalCostBudget;
                TotalCostActual_CPAM3 = TotalCostActual;

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
                ManPowerCell.Height = 30;
                TableCell CostCell = new TableCell();
                CostCell.Text = "Financial";
                CostCell.HorizontalAlign = HorizontalAlign.Center;
                CostCell.Font.Bold = true;
                CostCell.ColumnSpan = 3;
                ManPowerCell.Height = 30;
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

                TotalCostBudget_CPAM4 = TotalCostBudget;
                TotalCostActual_CPAM4 = TotalCostActual;

                TotalManPowerBudget = 0;
                TotalManPowerActual = 0;
                TotalCostBudget = 0;
                TotalCostActual = 0;
                OverHead4 = 0;
            }
        }

        #endregion

        #region MMR summary

        private void FillMMRFactoryUnitName()
        {
            DataTable dtUnitName = objProductionController.GetBiplUNITNAMEBAL();
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

        private void FillMMRSummaryStaff(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            DataTable dtStaffDept = objProductionController.GetMMR_Summary_Daily_BAL(sUnitName, dtDate, sFinancialYear);
            gvMMRSummaryStaff.DataSource = dtStaffDept;
            gvMMRSummaryStaff.DataBind();
        }

        private void FillMMRSummary(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            if (sUnitName == "C 47")
            {
                DataTable dtMMRSummary = objProductionController.GetMMR_Summary_Daily_BAL(sUnitName, dtDate, sFinancialYear);
                if (dtMMRSummary.Rows.Count > 0)
                {
                    AvailMinsActual = dtMMRSummary.Rows[0]["AvailMinsActual"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["AvailMinsActual"]);
                    BudgetwithMachine = dtMMRSummary.Rows[0]["ManPowerbudget"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["ManPowerbudget"]);
                    ActualwithMachine = dtMMRSummary.Rows[0]["ManPowerActual"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["ManPowerActual"]);
                }
                gvMMRSummary1.DataSource = dtMMRSummary;
                gvMMRSummary1.DataBind();
            }
            if (sUnitName == "C 45-46")
            {
                DataTable dtMMRSummary = objProductionController.GetMMR_Summary_Daily_BAL(sUnitName, dtDate, sFinancialYear);
                if (dtMMRSummary.Rows.Count > 0)
                {
                    AvailMinsActual = dtMMRSummary.Rows[0]["AvailMinsActual"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["AvailMinsActual"]);
                    BudgetwithMachine = dtMMRSummary.Rows[0]["ManPowerbudget"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["ManPowerbudget"]);
                    ActualwithMachine = dtMMRSummary.Rows[0]["ManPowerActual"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["ManPowerActual"]);
                }
                gvMMRSummary2.DataSource = dtMMRSummary;
                gvMMRSummary2.DataBind();
            }
            if (sUnitName == "B 45")
            {
                DataTable dtMMRSummary = objProductionController.GetMMR_Summary_Daily_BAL(sUnitName, dtDate, sFinancialYear);
                if (dtMMRSummary.Rows.Count > 0)
                {
                    AvailMinsActual = dtMMRSummary.Rows[0]["AvailMinsActual"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["AvailMinsActual"]);
                    BudgetwithMachine = dtMMRSummary.Rows[0]["ManPowerbudget"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["ManPowerbudget"]);
                    ActualwithMachine = dtMMRSummary.Rows[0]["ManPowerActual"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["ManPowerActual"]);
                }
                gvMMRSummary3.DataSource = dtMMRSummary;
                gvMMRSummary3.DataBind();
            }
            if (sUnitName == "BIPL")
            {
                DataTable dtMMRSummary = objProductionController.GetMMR_Summary_Daily_BAL(sUnitName, dtDate, sFinancialYear);
                if (dtMMRSummary.Rows.Count > 0)
                {
                    AvailMinsActual = dtMMRSummary.Rows[0]["AvailMinsActual"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["AvailMinsActual"]);
                    BudgetwithMachine = dtMMRSummary.Rows[0]["ManPowerbudget"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["ManPowerbudget"]);
                    ActualwithMachine = dtMMRSummary.Rows[0]["ManPowerActual"] == DBNull.Value ? 0 : Convert.ToDouble(dtMMRSummary.Rows[0]["ManPowerActual"]);
                }
                gvMMRSummary4.DataSource = dtMMRSummary;
                gvMMRSummary4.DataBind();
            }
        }

        protected void gvMMRFactory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex == 0)
            {
                e.Row.BackColor = System.Drawing.Color.FromName("#405D99");
                e.Row.Cells[0].ForeColor = System.Drawing.Color.FromName("#FFFFFF");
                e.Row.Cells[1].ForeColor = System.Drawing.Color.FromName("#FFFFFF");
                e.Row.Cells[2].ForeColor = System.Drawing.Color.FromName("#FFFFFF");
                e.Row.Cells[3].ForeColor = System.Drawing.Color.FromName("#FFFFFF");
                e.Row.Cells[4].ForeColor = System.Drawing.Color.FromName("#FFFFFF");
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
                if (BudgetwithMachine > 0)
                {
                    lblBudgetMMR.Text = Math.Round((TotalManPowerBudget1 / BudgetwithMachine), 2).ToString();
                }

                Label lblActualMMR = (Label)e.Row.FindControl("lblActualMMR");
                if (ActualwithMachine > 0)
                {
                    lblActualMMR.Text = Math.Round((TotalManPowerActual1 / ActualwithMachine), 2).ToString();
                }

                Label lblDiff = (Label)e.Row.FindControl("lblDiff");
                if ((lblBudgetMMR.Text != "") && (lblActualMMR.Text != ""))
                {
                    lblDiff.Text = Math.Round((Convert.ToDouble(lblBudgetMMR.Text) - Convert.ToDouble(lblActualMMR.Text)), 2).ToString();
                }


                Label lblProMachineBudget = (Label)e.Row.FindControl("lblProMachineBudget");
                if (BudgetwithMachine > 0)
                {
                    //lblProMachineBudget.Text = "₹ " + Math.Round(Convert.ToDouble(BudgetwithMachine) / 100000, 1) + " L";
                    lblProMachineBudget.Text = BudgetwithMachine.ToString();
                }

                Label lblProMachineActual = (Label)e.Row.FindControl("lblProMachineActual");
                if (ActualwithMachine > 0)
                {
                    //lblProMachineActual.Text = "₹ " + Math.Round(Convert.ToDouble(ActualwithMachine) / 100000, 1) + " L";
                    lblProMachineActual.Text = ActualwithMachine.ToString();
                }

                Label lblProMachineDiff = (Label)e.Row.FindControl("lblProMachineDiff");
                if ((BudgetwithMachine > 0) || (ActualwithMachine > 0))
                {
                    lblProMachineDiff.Text = Math.Round((BudgetwithMachine - ActualwithMachine), 2).ToString();
                }

                Label lblAvailMinsBudget = (Label)e.Row.FindControl("lblAvailMinsBudget");
                double AvailBudget = 0;
                if (WorkingHrs != "")
                {
                    AvailBudget = BudgetwithMachine * Convert.ToDouble(WorkingHrs) * 60;
                    lblAvailMinsBudget.Text = Math.Round(Convert.ToDouble(AvailBudget) / 100000, 1).ToString() + " L"; ;
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


                if (WorkingHrs != "")
                {
                    if (BudgetwithMachine > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead1) / ((BudgetwithMachine * Convert.ToDouble(WorkingHrs) * 60));
                        TotalManPowerBudget = Math.Round(TotalManPowerBudget1 + overhead, 2);
                    }

                    if (ActualwithMachine > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead1) / ActualwithMachine;
                        TotalManPowerActual = Math.Round(TotalManPowerActual1 + overhead, 2);
                    }
                }
                AvailBudget = AvailBudget == 0 ? 1 : AvailBudget;
                CPAMBudget = TotalCostBudget_CPAM1 / AvailBudget;
                AvailMinsActual = AvailMinsActual == 0 ? 1 : AvailMinsActual;
                CPAMActual = TotalCostActual_CPAM1 / AvailMinsActual;

                if (CPAMBudget > 0)
                {
                    lblCPAMBudget.Text = "₹ " + Math.Round(CPAMBudget, 2).ToString();
                }

                if (CPAMActual > 0)
                {
                    lblCPAMActual.Text = "₹ " + Math.Round(CPAMActual, 2).ToString();
                }

                if ((CPAMBudget > 0) || (CPAMActual > 0))
                {
                    lblCPAMDiff.Text = "₹ " + Math.Round((CPAMBudget - CPAMActual), 2).ToString();
                }

                if (lblCPAMDiff.Text != "")
                {
                    if (Convert.ToDouble(CPAMBudget - CPAMActual) >= 0)
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
                if (BudgetwithMachine > 0)
                {
                    lblBudgetMMR.Text = Math.Round((TotalManPowerBudget2 / BudgetwithMachine), 2).ToString();
                }

                Label lblActualMMR = (Label)e.Row.FindControl("lblActualMMR");
                if (ActualwithMachine > 0)
                {
                    lblActualMMR.Text = Math.Round((TotalManPowerActual2 / ActualwithMachine), 2).ToString();
                }

                Label lblDiff = (Label)e.Row.FindControl("lblDiff");
                if ((lblBudgetMMR.Text != "") && (lblActualMMR.Text != ""))
                {
                    lblDiff.Text = Math.Round((Convert.ToDouble(lblBudgetMMR.Text) - Convert.ToDouble(lblActualMMR.Text)), 2).ToString();
                }


                Label lblProMachineBudget = (Label)e.Row.FindControl("lblProMachineBudget");
                if (BudgetwithMachine > 0)
                {
                    lblProMachineBudget.Text = BudgetwithMachine.ToString();
                }

                Label lblProMachineActual = (Label)e.Row.FindControl("lblProMachineActual");
                if (ActualwithMachine > 0)
                {
                    lblProMachineActual.Text = ActualwithMachine.ToString();
                }

                Label lblProMachineDiff = (Label)e.Row.FindControl("lblProMachineDiff");
                if ((BudgetwithMachine > 0) || (ActualwithMachine > 0))
                {
                    lblProMachineDiff.Text = Math.Round((BudgetwithMachine - ActualwithMachine), 2).ToString();
                }


                Label lblAvailMinsBudget = (Label)e.Row.FindControl("lblAvailMinsBudget");
                double AvailBudget = 0;
                if (WorkingHrs != "")
                {
                    AvailBudget = BudgetwithMachine * Convert.ToDouble(WorkingHrs) * 60;
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


                if (WorkingHrs != "")
                {
                    if (BudgetwithMachine > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead2) / ((BudgetwithMachine * Convert.ToDouble(WorkingHrs) * 60));
                        TotalManPowerBudget = Math.Round(TotalManPowerBudget2 + overhead, 2);
                    }

                    if (ActualwithMachine > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead2) / ActualwithMachine;
                        TotalManPowerActual = Math.Round(TotalManPowerActual2 + overhead, 2);
                    }
                }

                AvailBudget = AvailBudget == 0 ? 1 : AvailBudget;
                CPAMBudget = TotalCostBudget_CPAM2 / AvailBudget;

                AvailMinsActual = AvailMinsActual == 0 ? 1 : AvailMinsActual;
                CPAMActual = TotalCostActual_CPAM2 / AvailMinsActual;

                if (CPAMBudget > 0)
                {
                    lblCPAMBudget.Text = "₹ " + Math.Round(CPAMBudget, 2).ToString();
                }

                if (CPAMActual > 0)
                {
                    lblCPAMActual.Text = "₹ " + Math.Round(CPAMActual, 2).ToString();
                }

                if ((CPAMBudget > 0) || (CPAMActual > 0))
                {
                    lblCPAMDiff.Text = "₹ " + Math.Round((CPAMBudget - CPAMActual), 2).ToString();
                }

                if (lblCPAMDiff.Text != "")
                {
                    if (Convert.ToDouble(CPAMBudget - CPAMActual) >= 0)
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
                if (BudgetwithMachine > 0)
                {
                    lblBudgetMMR.Text = Math.Round((TotalManPowerBudget3 / BudgetwithMachine), 2).ToString();
                }

                Label lblActualMMR = (Label)e.Row.FindControl("lblActualMMR");
                if (ActualwithMachine > 0)
                {
                    lblActualMMR.Text = Math.Round((TotalManPowerActual3 / ActualwithMachine), 2).ToString();
                }

                Label lblDiff = (Label)e.Row.FindControl("lblDiff");
                if ((lblBudgetMMR.Text != "") && (lblActualMMR.Text != ""))
                {
                    lblDiff.Text = Math.Round((Convert.ToDouble(lblBudgetMMR.Text) - Convert.ToDouble(lblActualMMR.Text)), 2).ToString();
                }


                Label lblProMachineBudget = (Label)e.Row.FindControl("lblProMachineBudget");
                if (BudgetwithMachine > 0)
                {
                    lblProMachineBudget.Text = BudgetwithMachine.ToString();
                }

                Label lblProMachineActual = (Label)e.Row.FindControl("lblProMachineActual");
                if (ActualwithMachine > 0)
                {
                    lblProMachineActual.Text = ActualwithMachine.ToString();
                }

                Label lblProMachineDiff = (Label)e.Row.FindControl("lblProMachineDiff");
                if ((BudgetwithMachine > 0) || (ActualwithMachine > 0))
                {
                    lblProMachineDiff.Text = Math.Round((BudgetwithMachine - ActualwithMachine), 2).ToString();
                }


                Label lblAvailMinsBudget = (Label)e.Row.FindControl("lblAvailMinsBudget");
                double AvailBudget = 0;
                if (WorkingHrs != "")
                {
                    AvailBudget = BudgetwithMachine * Convert.ToDouble(WorkingHrs) * 60;
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


                if (WorkingHrs != "")
                {
                    if (BudgetwithMachine > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead3) / ((BudgetwithMachine * Convert.ToDouble(WorkingHrs) * 60));
                        TotalManPowerBudget = Math.Round(TotalManPowerBudget3 + overhead, 2);
                    }

                    if (ActualwithMachine > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead3) / ActualwithMachine;
                        TotalManPowerActual = Math.Round(TotalManPowerActual3 + overhead, 2);
                    }
                }

                AvailBudget = AvailBudget == 0 ? 1 : AvailBudget;
                CPAMBudget = TotalCostBudget_CPAM3 / AvailBudget;

                AvailMinsActual = AvailMinsActual == 0 ? 1 : AvailMinsActual;
                CPAMActual = TotalCostActual_CPAM3 / AvailMinsActual;

                if (CPAMBudget > 0)
                {
                    lblCPAMBudget.Text = "₹ " + Math.Round(CPAMBudget, 2).ToString();
                }

                if (CPAMActual > 0)
                {
                    lblCPAMActual.Text = "₹ " + Math.Round(CPAMActual, 2).ToString();
                }

                if ((CPAMBudget > 0) || (CPAMActual > 0))
                {
                    lblCPAMDiff.Text = "₹ " + Math.Round((CPAMBudget - CPAMActual), 2).ToString();
                }

                if (lblCPAMDiff.Text != "")
                {
                    if (Convert.ToDouble(CPAMBudget - CPAMActual) >= 0)
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
                if (BudgetwithMachine > 0)
                {
                    lblBudgetMMR.Text = Math.Round((TotalManPowerBudget4 / BudgetwithMachine), 2).ToString();
                }

                Label lblActualMMR = (Label)e.Row.FindControl("lblActualMMR");
                if (ActualwithMachine > 0)
                {
                    lblActualMMR.Text = Math.Round((TotalManPowerActual4 / ActualwithMachine), 2).ToString();
                }

                Label lblDiff = (Label)e.Row.FindControl("lblDiff");
                if ((lblBudgetMMR.Text != "") && (lblActualMMR.Text != ""))
                {
                    lblDiff.Text = Math.Round((Convert.ToDouble(lblBudgetMMR.Text) - Convert.ToDouble(lblActualMMR.Text)), 2).ToString();
                }


                Label lblProMachineBudget = (Label)e.Row.FindControl("lblProMachineBudget");
                if (BudgetwithMachine > 0)
                {
                    lblProMachineBudget.Text = BudgetwithMachine.ToString();
                }

                Label lblProMachineActual = (Label)e.Row.FindControl("lblProMachineActual");
                if (ActualwithMachine > 0)
                {
                    lblProMachineActual.Text = ActualwithMachine.ToString();
                }

                Label lblProMachineDiff = (Label)e.Row.FindControl("lblProMachineDiff");
                if ((BudgetwithMachine > 0) || (ActualwithMachine > 0))
                {
                    lblProMachineDiff.Text = Math.Round((BudgetwithMachine - ActualwithMachine), 2).ToString();
                }

                Label lblAvailMinsBudget = (Label)e.Row.FindControl("lblAvailMinsBudget");
                double AvailBudget = 0;
                if (WorkingHrs != "")
                {
                    AvailBudget = BudgetwithMachine * Convert.ToDouble(WorkingHrs) * 60;
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

                if (WorkingHrs != "")
                {
                    if (BudgetwithMachine > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead4) / ((BudgetwithMachine * Convert.ToDouble(WorkingHrs) * 60));
                        TotalManPowerBudget = Math.Round(TotalManPowerBudget4 + overhead, 2);
                    }

                    if (ActualwithMachine > 0)
                    {
                        double overhead = Convert.ToDouble(OverHead4) / ActualwithMachine;
                        TotalManPowerActual = Math.Round(TotalManPowerActual4 + overhead, 2);
                    }
                }

                AvailBudget = AvailBudget == 0 ? 1 : AvailBudget;
                CPAMBudget = TotalCostBudget_CPAM4 / AvailBudget;

                AvailMinsActual = AvailMinsActual == 0 ? 1 : AvailMinsActual;
                CPAMActual = TotalCostActual_CPAM4 / AvailMinsActual;

                if (CPAMBudget > 0)
                {
                    lblCPAMBudget.Text = "₹ " + Math.Round(CPAMBudget, 2).ToString();
                }

                if (CPAMActual > 0)
                {
                    lblCPAMActual.Text = "₹ " + Math.Round(CPAMActual, 2).ToString();
                }

                if ((CPAMBudget > 0) || (CPAMActual > 0))
                {
                    lblCPAMDiff.Text = "₹ " + Math.Round((CPAMBudget - CPAMActual), 2).ToString();
                }

                if (lblCPAMDiff.Text != "")
                {
                    if (Convert.ToDouble(CPAMBudget - CPAMActual) >= 0)
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