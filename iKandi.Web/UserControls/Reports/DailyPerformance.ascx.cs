using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;
using iKandi.Common;
using System.Data;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.UserControls.Reports
{
    public partial class DailyPerformance : System.Web.UI.UserControl
    {
        ProductionController objProductionController = new ProductionController();
        string WorkingHrs = "";
        string sFinancialYear = "";
        DateTime dtDate = DateTime.Now;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //dtStartDate = Convert.ToDateTime("09/09/2015");
                WorkingHrs = objProductionController.GetMMR_WorkingHours_BAL(dtDate, DateTime.MinValue);                
                FillPeriod("", dtDate, sFinancialYear);
                FillDailyPerformance("C 47", dtDate, sFinancialYear);
                FillDailyPerformance("C 45-46", dtDate, sFinancialYear);
                FillDailyPerformance("B 45", dtDate, sFinancialYear);
                FillDailyPerformance("BIPL", dtDate, sFinancialYear);               
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

        private void FillPeriod(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            DataTable dtPeriod = objProductionController.Get_DailyPerformanceSummery_BAL(sUnitName, dtDate, sFinancialYear);
            gvPeriod.DataSource = dtPeriod;
            gvPeriod.DataBind();
        }

        private void FillDailyPerformance(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            if (sUnitName == "C 47")
            {
                DataTable dtFactoryDetails = objProductionController.Get_DailyPerformanceSummery_BAL(sUnitName, dtDate, sFinancialYear);
                gvDailyPerformance_Unit1.DataSource = dtFactoryDetails;
                gvDailyPerformance_Unit1.DataBind();
            }
            if (sUnitName == "C 45-46")
            {
                DataTable dtFactoryDetails = objProductionController.Get_DailyPerformanceSummery_BAL(sUnitName, dtDate, sFinancialYear);
                gvDailyPerformance_Unit2.DataSource = dtFactoryDetails;
                gvDailyPerformance_Unit2.DataBind();
            }
            if (sUnitName == "B 45")
            {
                DataTable dtFactoryDetails = objProductionController.Get_DailyPerformanceSummery_BAL(sUnitName, dtDate, sFinancialYear);
                gvDailyPerformance_Unit3.DataSource = dtFactoryDetails;
                gvDailyPerformance_Unit3.DataBind();
            }
            if (sUnitName == "BIPL")
            {
                DataTable dtFactoryDetails = objProductionController.Get_DailyPerformanceSummery_BAL(sUnitName, dtDate, sFinancialYear);
                gvDailyPerformance_Unit4.DataSource = dtFactoryDetails;
                gvDailyPerformance_Unit4.DataBind();

                gvCMTAchievement.DataSource = dtFactoryDetails;
                gvCMTAchievement.DataBind();
            }           
        }

        protected void gvDailyPerformance_Unit1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Cutting

                Label lblCutQtyActual = (Label)e.Row.FindControl("lblCutQtyActual");
                if (lblCutQtyActual.Text != "")
                {
                    double CutQtyActual = Convert.ToDouble(lblCutQtyActual.Text);
                    if (CutQtyActual > 0)
                    {
                        CutQtyActual = Math.Round(CutQtyActual / 1000, 1);
                        lblCutQtyActual.Text = CutQtyActual.ToString() + " k";
                    }
                    else
                    {
                        lblCutQtyActual.Text = "";
                    }
                }

                Label lblCutQtyPlan = (Label)e.Row.FindControl("lblCutQtyPlan");
                if (lblCutQtyPlan.Text != "")
                {
                    double CutQtyPlan = Convert.ToDouble(lblCutQtyPlan.Text);
                    if (CutQtyPlan > 0)
                    {
                        CutQtyPlan = Math.Round(CutQtyPlan / 1000, 1);
                        lblCutQtyPlan.Text = CutQtyPlan.ToString() + " k";
                    }
                    else
                    {
                        lblCutQtyPlan.Text = "";
                    }
                }

                Label lblCutCostPerPc = (Label)e.Row.FindControl("lblCutCostPerPc");
                if (lblCutCostPerPc.Text != "")
                {
                    double CutCostPerPc = Convert.ToDouble(lblCutCostPerPc.Text);
                    if (CutCostPerPc > 0)
                    {
                        lblCutCostPerPc.Text = "₹ " + CutCostPerPc.ToString();
                    }
                    else
                    {
                        lblCutCostPerPc.Text = "";
                    }
                }

                // Stitching Actual

                Label lblStchActualEff = (Label)e.Row.FindControl("lblStchActualEff");
                if (lblStchActualEff.Text != "")
                {
                    double StchActualEff = Convert.ToDouble(lblStchActualEff.Text);
                    if (StchActualEff > 0)
                    {
                        lblStchActualEff.Text = StchActualEff.ToString() + "%";
                    }
                    else
                    {
                        lblStchActualEff.Text = "";
                    }
                }

                Label lblStchActualAch = (Label)e.Row.FindControl("lblStchActualAch");
                if (lblStchActualAch.Text != "")
                {
                    double StchActualAch = Convert.ToDouble(lblStchActualAch.Text);
                    if (StchActualAch > 0)
                    {
                        lblStchActualAch.Text = StchActualAch.ToString() + "%";
                    }
                    else
                    {
                        lblStchActualAch.Text = "";
                    }
                }

                Label lblStchActualQty = (Label)e.Row.FindControl("lblStchActualQty");
                if (lblStchActualQty.Text != "")
                {
                    double StchActualQty = Convert.ToDouble(lblStchActualQty.Text);
                    if (StchActualQty > 0)
                    {
                        StchActualQty = Math.Round(StchActualQty / 1000, 1);
                        lblStchActualQty.Text = StchActualQty.ToString() + " k";
                    }
                    else
                    {
                        lblStchActualQty.Text = "";
                    }
                }

                // Stitching Target

                Label lblStchTargetEff = (Label)e.Row.FindControl("lblStchTargetEff");
                if (lblStchTargetEff.Text != "")
                {
                    double StchTargetEff = Convert.ToDouble(lblStchTargetEff.Text);
                    if (StchTargetEff > 0)
                    {
                        lblStchTargetEff.Text = StchTargetEff.ToString() + "%";
                    }
                    else
                    {
                        lblStchTargetEff.Text = "";
                    }
                }

                Label lblStchTargetAch = (Label)e.Row.FindControl("lblStchTargetAch");
                if (lblStchTargetAch.Text != "")
                {
                    double StchTargetAch = Convert.ToDouble(lblStchTargetAch.Text);
                    if (StchTargetAch > 0)
                    {
                        lblStchTargetAch.Text = StchTargetAch.ToString() + "%";
                    }
                    else
                    {
                        lblStchTargetAch.Text = "";
                    }
                }

                Label lblStchTargetQty = (Label)e.Row.FindControl("lblStchTargetQty");
                if (lblStchTargetQty.Text != "")
                {
                    double StchTargetQty = Convert.ToDouble(lblStchTargetQty.Text);
                    if (StchTargetQty > 0)
                    {
                        StchTargetQty = Math.Round(StchTargetQty / 1000, 1);
                        lblStchTargetQty.Text = StchTargetQty.ToString() + " k";
                    }
                    else
                    {
                        lblStchTargetQty.Text = "";
                    }
                }

                // Stitching Break Even

                Label lblStitchBreakEvenEff = (Label)e.Row.FindControl("lblStitchBreakEvenEff");
                if (lblStitchBreakEvenEff.Text != "")
                {
                    double StitchBreakEvenEff = Convert.ToDouble(lblStitchBreakEvenEff.Text);
                    if (StitchBreakEvenEff > 0)
                    {
                        lblStitchBreakEvenEff.Text = StitchBreakEvenEff.ToString() + "%";
                    }
                    else
                    {
                        lblStitchBreakEvenEff.Text = "";
                    }
                }

                Label lblStitchBreakEvenAch = (Label)e.Row.FindControl("lblStitchBreakEvenAch");
                if (lblStchTargetAch.Text != "")
                {
                    double StitchBreakEvenAch = Convert.ToDouble(lblStitchBreakEvenAch.Text);
                    if (StitchBreakEvenAch > 0)
                    {
                        lblStitchBreakEvenAch.Text = StitchBreakEvenAch.ToString() + "%";
                    }
                    else
                    {
                        lblStitchBreakEvenAch.Text = "";
                    }
                }

                Label lblStitchBreakEvenQty = (Label)e.Row.FindControl("lblStitchBreakEvenQty");
                if (lblStitchBreakEvenQty.Text != "")
                {
                    double StitchBreakEvenQty = Convert.ToDouble(lblStitchBreakEvenQty.Text);
                    if (StitchBreakEvenQty > 0)
                    {
                        StitchBreakEvenQty = Math.Round(StitchBreakEvenQty / 1000, 1);
                        lblStitchBreakEvenQty.Text = StitchBreakEvenQty.ToString() + " k";
                    }
                    else
                    {
                        lblStitchBreakEvenQty.Text = "";
                    }
                }

                // Finishing work

                Label lblFinishActualEff = (Label)e.Row.FindControl("lblFinishActualEff");
                if (lblFinishActualEff.Text != "")
                {
                    double FinishActualEff = Convert.ToDouble(lblFinishActualEff.Text);
                    if (FinishActualEff > 0)
                    {
                        lblFinishActualEff.Text = FinishActualEff.ToString() + "%";
                    }
                    else
                    {
                        lblFinishActualEff.Text = "";
                    }
                }

                Label lblFinishActualAch = (Label)e.Row.FindControl("lblFinishActualAch");
                if (lblFinishActualAch.Text != "")
                {
                    double FinishActualAch = Convert.ToDouble(lblFinishActualAch.Text);
                    if (FinishActualAch > 0)
                    {
                        lblFinishActualAch.Text = FinishActualAch.ToString() + "%";
                    }
                    else
                    {
                        lblFinishActualAch.Text = "";
                    }
                }

                Label lblFinishCost = (Label)e.Row.FindControl("lblFinishCost");
                if (lblFinishCost.Text != "")
                {
                    double FinishCost = Convert.ToDouble(lblFinishCost.Text);
                    if (FinishCost > 0)
                    {
                        lblFinishCost.Text = "₹ " + FinishCost.ToString();
                    }
                    else
                    {
                        lblFinishCost.Text = "";
                    }
                }

                Label lblFinishTgtQty = (Label)e.Row.FindControl("lblFinishTgtQty");
                if (lblFinishTgtQty.Text != "")
                {
                    double FinishTgtQty = Convert.ToDouble(lblFinishTgtQty.Text);
                    if (FinishTgtQty > 0)
                    {
                        FinishTgtQty = Math.Round(FinishTgtQty / 1000, 1);
                        lblFinishTgtQty.Text = FinishTgtQty.ToString() == "0" ? "" : FinishTgtQty.ToString() + " k";
                    }
                    else
                    {
                        lblFinishTgtQty.Text = "";
                    }
                }

                Label lblFinishActQty = (Label)e.Row.FindControl("lblFinishActQty");
                if (lblFinishActQty.Text != "")
                {
                    double FinishActQty = Convert.ToDouble(lblFinishActQty.Text);
                    if (FinishActQty > 0)
                    {
                        FinishActQty = Math.Round(FinishActQty / 1000, 1);
                        lblFinishActQty.Text = FinishActQty.ToString() + " k";
                    }
                    else
                    {
                        lblFinishActQty.Text = "";
                    }
                }

                // CMT & DHU Actual

                Label lblCMTActual = (Label)e.Row.FindControl("lblCMTActual");
                if (lblCMTActual.Text != "")
                {
                    double CMTActual = Convert.ToDouble(lblCMTActual.Text);
                    if (CMTActual > 0)
                    {
                        lblCMTActual.Text = "₹ " + CMTActual.ToString();
                    }
                    else
                    {
                        lblCMTActual.Text = "";
                    }
                }

                Label lblCMTPlan = (Label)e.Row.FindControl("lblCMTPlan");
                if (lblCMTPlan.Text != "")
                {
                    double CMTPlan = Convert.ToDouble(lblCMTPlan.Text);
                    if (CMTPlan > 0)
                    {
                        lblCMTPlan.Text = "₹ " + CMTPlan.ToString();
                    }
                    else
                    {
                        lblCMTPlan.Text = "";
                    }
                }
                Label lblFOBPrice = (Label)e.Row.FindControl("lblFOBPrice");
                if (lblFOBPrice.Text != "")
                {
                    double FOBPrice = Convert.ToDouble(lblFOBPrice.Text);
                    if (FOBPrice > 0)
                    {
                        lblFOBPrice.Text = "₹ " + FOBPrice.ToString();
                    }
                    else
                    {
                        lblFOBPrice.Text = "";
                    }
                }

                Label lblFOBStitched = (Label)e.Row.FindControl("lblFOBStitched");
                if (lblFOBStitched.Text != "")
                {
                    double FOBStitched = Convert.ToDouble(lblFOBStitched.Text);
                    if (FOBStitched > 0)
                    {
                        FOBStitched = Math.Round(FOBStitched / 100000, 1);
                        lblFOBStitched.Text = "₹ " + FOBStitched.ToString() + " L";
                    }
                    else
                    {
                        lblFOBStitched.Text = "";
                    }
                }

                // CMT & DHU %

                Label lblCMTPercent = (Label)e.Row.FindControl("lblCMTPercent");
                if (lblCMTPercent.Text != "")
                {
                    double FinishActualAch = Convert.ToDouble(lblCMTPercent.Text);
                    if (FinishActualAch > 0)
                    {
                        lblCMTPercent.Text = FinishActualAch.ToString() + "%";
                    }
                    else
                    {
                        lblCMTPercent.Text = "";
                    }
                }

                Label lblProfitLoss = (Label)e.Row.FindControl("lblProfitLoss");
                if (lblProfitLoss.Text != "")
                {
                    double ProfitLoss = Convert.ToDouble(lblProfitLoss.Text);
                    if (ProfitLoss > 0)
                    {
                        ProfitLoss = Math.Round(ProfitLoss / 100000, 1);
                        lblProfitLoss.Text = "<span style='color: green;'>₹ " + ProfitLoss.ToString() + " L</span>";
                    }
                    if (ProfitLoss < 0)
                    {
                        ProfitLoss = Math.Round(ProfitLoss / 100000, 1);
                        lblProfitLoss.Text = "<span style='color: red;'>₹ " + ProfitLoss.ToString() + " L</span>";
                    }
                    if (ProfitLoss == 0)
                    {
                        lblProfitLoss.Text = "";
                    }
                }

                Label lblBECMT = (Label)e.Row.FindControl("lblBECMT");
                if (lblBECMT.Text != "")
                {
                    double BECMT = Convert.ToDouble(lblBECMT.Text);
                    if (BECMT > 0)
                    {
                        lblBECMT.Text = "₹" + BECMT.ToString();
                    }
                    else
                    {
                        lblBECMT.Text = "";
                    }
                }

                Label lblDHU = (Label)e.Row.FindControl("lblDHU");
                if (lblDHU.Text != "")
                {
                    double DHU = Convert.ToDouble(lblDHU.Text);
                    if (DHU > 0)
                    {
                        lblDHU.Text = DHU.ToString() + "%";
                    }
                    else
                    {
                        lblDHU.Text = "";
                    }
                }

            }

        }

        protected void gvDailyPerformance_Unit2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Cutting

                Label lblCutQtyActual = (Label)e.Row.FindControl("lblCutQtyActual");
                if (lblCutQtyActual.Text != "")
                {
                    double CutQtyActual = Convert.ToDouble(lblCutQtyActual.Text);
                    if (CutQtyActual > 0)
                    {
                        CutQtyActual = Math.Round(CutQtyActual / 1000, 1);
                        lblCutQtyActual.Text = CutQtyActual.ToString() + " k";
                    }
                    else
                    {
                        lblCutQtyActual.Text = "";
                    }
                }

                Label lblCutQtyPlan = (Label)e.Row.FindControl("lblCutQtyPlan");
                if (lblCutQtyPlan.Text != "")
                {
                    double CutQtyPlan = Convert.ToDouble(lblCutQtyPlan.Text);
                    if (CutQtyPlan > 0)
                    {
                        CutQtyPlan = Math.Round(CutQtyPlan / 1000, 1);
                        lblCutQtyPlan.Text = CutQtyPlan.ToString() + " k";
                    }
                    else
                    {
                        lblCutQtyPlan.Text = "";
                    }
                }

                Label lblCutCostPerPc = (Label)e.Row.FindControl("lblCutCostPerPc");
                if (lblCutCostPerPc.Text != "")
                {
                    double CutCostPerPc = Convert.ToDouble(lblCutCostPerPc.Text);
                    if (CutCostPerPc > 0)
                    {
                        lblCutCostPerPc.Text = "₹ " + CutCostPerPc.ToString();
                    }
                    else
                    {
                        lblCutCostPerPc.Text = "";
                    }
                }

                // Stitching Actual

                Label lblStchActualEff = (Label)e.Row.FindControl("lblStchActualEff");
                if (lblStchActualEff.Text != "")
                {
                    double StchActualEff = Convert.ToDouble(lblStchActualEff.Text);
                    if (StchActualEff > 0)
                    {
                        lblStchActualEff.Text = StchActualEff.ToString() + "%";
                    }
                    else
                    {
                        lblStchActualEff.Text = "";
                    }
                }

                Label lblStchActualAch = (Label)e.Row.FindControl("lblStchActualAch");
                if (lblStchActualAch.Text != "")
                {
                    double StchActualAch = Convert.ToDouble(lblStchActualAch.Text);
                    if (StchActualAch > 0)
                    {
                        lblStchActualAch.Text = StchActualAch.ToString() + "%";
                    }
                    else
                    {
                        lblStchActualAch.Text = "";
                    }
                }

                Label lblStchActualQty = (Label)e.Row.FindControl("lblStchActualQty");
                if (lblStchActualQty.Text != "")
                {
                    double StchActualQty = Convert.ToDouble(lblStchActualQty.Text);
                    if (StchActualQty > 0)
                    {
                        StchActualQty = Math.Round(StchActualQty / 1000, 1);
                        lblStchActualQty.Text = StchActualQty.ToString() + " k";
                    }
                    else
                    {
                        lblStchActualQty.Text = "";
                    }
                }

                // Stitching Target

                Label lblStchTargetEff = (Label)e.Row.FindControl("lblStchTargetEff");
                if (lblStchTargetEff.Text != "")
                {
                    double StchTargetEff = Convert.ToDouble(lblStchTargetEff.Text);
                    if (StchTargetEff > 0)
                    {
                        lblStchTargetEff.Text = StchTargetEff.ToString() + "%";
                    }
                    else
                    {
                        lblStchTargetEff.Text = "";
                    }
                }

                Label lblStchTargetAch = (Label)e.Row.FindControl("lblStchTargetAch");
                if (lblStchTargetAch.Text != "")
                {
                    double StchTargetAch = Convert.ToDouble(lblStchTargetAch.Text);
                    if (StchTargetAch > 0)
                    {
                        lblStchTargetAch.Text = StchTargetAch.ToString() + "%";
                    }
                    else
                    {
                        lblStchTargetAch.Text = "";
                    }
                }

                Label lblStchTargetQty = (Label)e.Row.FindControl("lblStchTargetQty");
                if (lblStchTargetQty.Text != "")
                {
                    double StchTargetQty = Convert.ToDouble(lblStchTargetQty.Text);
                    if (StchTargetQty > 0)
                    {
                        StchTargetQty = Math.Round(StchTargetQty / 1000, 1);
                        lblStchTargetQty.Text = StchTargetQty.ToString() + " k";
                    }
                    else
                    {
                        lblStchTargetQty.Text = "";
                    }
                }

                // Stitching Break Even

                Label lblStitchBreakEvenEff = (Label)e.Row.FindControl("lblStitchBreakEvenEff");
                if (lblStitchBreakEvenEff.Text != "")
                {
                    double StitchBreakEvenEff = Convert.ToDouble(lblStitchBreakEvenEff.Text);
                    if (StitchBreakEvenEff > 0)
                    {
                        lblStitchBreakEvenEff.Text = StitchBreakEvenEff.ToString() + "%";
                    }
                    else
                    {
                        lblStitchBreakEvenEff.Text = "";
                    }
                }

                Label lblStitchBreakEvenAch = (Label)e.Row.FindControl("lblStitchBreakEvenAch");
                if (lblStchTargetAch.Text != "")
                {
                    double StitchBreakEvenAch = Convert.ToDouble(lblStitchBreakEvenAch.Text);
                    if (StitchBreakEvenAch > 0)
                    {
                        lblStitchBreakEvenAch.Text = StitchBreakEvenAch.ToString() + "%";
                    }
                    else
                    {
                        lblStitchBreakEvenAch.Text = "";
                    }
                }

                Label lblStitchBreakEvenQty = (Label)e.Row.FindControl("lblStitchBreakEvenQty");
                if (lblStitchBreakEvenQty.Text != "")
                {
                    double StitchBreakEvenQty = Convert.ToDouble(lblStitchBreakEvenQty.Text);
                    if (StitchBreakEvenQty > 0)
                    {
                        StitchBreakEvenQty = Math.Round(StitchBreakEvenQty / 1000, 1);
                        lblStitchBreakEvenQty.Text = StitchBreakEvenQty.ToString() + " k";
                    }
                    else
                    {
                        lblStitchBreakEvenQty.Text = "";
                    }
                }

                // Finishing work

                Label lblFinishActualEff = (Label)e.Row.FindControl("lblFinishActualEff");
                if (lblFinishActualEff.Text != "")
                {
                    double FinishActualEff = Convert.ToDouble(lblFinishActualEff.Text);
                    if (FinishActualEff > 0)
                    {
                        lblFinishActualEff.Text = FinishActualEff.ToString() + "%";
                    }
                    else
                    {
                        lblFinishActualEff.Text = "";
                    }
                }

                Label lblFinishActualAch = (Label)e.Row.FindControl("lblFinishActualAch");
                if (lblFinishActualAch.Text != "")
                {
                    double FinishActualAch = Convert.ToDouble(lblFinishActualAch.Text);
                    if (FinishActualAch > 0)
                    {
                        lblFinishActualAch.Text = FinishActualAch.ToString() + "%";
                    }
                    else
                    {
                        lblFinishActualAch.Text = "";
                    }
                }

                Label lblFinishCost = (Label)e.Row.FindControl("lblFinishCost");
                if (lblFinishCost.Text != "")
                {
                    double FinishCost = Convert.ToDouble(lblFinishCost.Text);
                    if (FinishCost > 0)
                    {
                        lblFinishCost.Text = "₹ " + FinishCost.ToString();
                    }
                    else
                    {
                        lblFinishCost.Text = "";
                    }
                }

                Label lblFinishTgtQty = (Label)e.Row.FindControl("lblFinishTgtQty");
                if (lblFinishTgtQty.Text != "")
                {
                    double FinishTgtQty = Convert.ToDouble(lblFinishTgtQty.Text);
                    if (FinishTgtQty > 0)
                    {
                        FinishTgtQty = Math.Round(FinishTgtQty / 1000, 1);
                        lblFinishTgtQty.Text = FinishTgtQty.ToString() == "0" ? "" : FinishTgtQty.ToString() + " k";
                    }
                    else
                    {
                        lblFinishTgtQty.Text = "";
                    }
                }

                Label lblFinishActQty = (Label)e.Row.FindControl("lblFinishActQty");
                if (lblFinishActQty.Text != "")
                {
                    double FinishActQty = Convert.ToDouble(lblFinishActQty.Text);
                    if (FinishActQty > 0)
                    {
                        FinishActQty = Math.Round(FinishActQty / 1000, 1);
                        lblFinishActQty.Text = FinishActQty.ToString() + " k";
                    }
                    else
                    {
                        lblFinishActQty.Text = "";
                    }
                }

                // CMT & DHU Actual

                Label lblCMTActual = (Label)e.Row.FindControl("lblCMTActual");
                if (lblCMTActual.Text != "")
                {
                    double CMTActual = Convert.ToDouble(lblCMTActual.Text);
                    if (CMTActual > 0)
                    {
                        lblCMTActual.Text = "₹ " + CMTActual.ToString();
                    }
                    else
                    {
                        lblCMTActual.Text = "";
                    }
                }

                Label lblCMTPlan = (Label)e.Row.FindControl("lblCMTPlan");
                if (lblCMTPlan.Text != "")
                {
                    double CMTPlan = Convert.ToDouble(lblCMTPlan.Text);
                    if (CMTPlan > 0)
                    {
                        lblCMTPlan.Text = "₹ " + CMTPlan.ToString();
                    }
                    else
                    {
                        lblCMTPlan.Text = "";
                    }
                }
                Label lblFOBPrice = (Label)e.Row.FindControl("lblFOBPrice");
                if (lblFOBPrice.Text != "")
                {
                    double FOBPrice = Convert.ToDouble(lblFOBPrice.Text);
                    if (FOBPrice > 0)
                    {
                        lblFOBPrice.Text = "₹ " + FOBPrice.ToString();
                    }
                    else
                    {
                        lblFOBPrice.Text = "";
                    }
                }

                Label lblFOBStitched = (Label)e.Row.FindControl("lblFOBStitched");
                if (lblFOBStitched.Text != "")
                {
                    double FOBStitched = Convert.ToDouble(lblFOBStitched.Text);
                    if (FOBStitched > 0)
                    {
                        FOBStitched = Math.Round(FOBStitched / 100000, 1);
                        lblFOBStitched.Text = "₹ " + FOBStitched.ToString() + " L";
                    }
                    else
                    {
                        lblFOBStitched.Text = "";
                    }
                }

                // CMT & DHU %

                Label lblCMTPercent = (Label)e.Row.FindControl("lblCMTPercent");
                if (lblCMTPercent.Text != "")
                {
                    double FinishActualAch = Convert.ToDouble(lblCMTPercent.Text);
                    if (FinishActualAch > 0)
                    {
                        lblCMTPercent.Text = FinishActualAch.ToString() + "%";
                    }
                    else
                    {
                        lblCMTPercent.Text = "";
                    }
                }

                Label lblProfitLoss = (Label)e.Row.FindControl("lblProfitLoss");
                if (lblProfitLoss.Text != "")
                {
                    double ProfitLoss = Convert.ToDouble(lblProfitLoss.Text);
                    if (ProfitLoss > 0)
                    {
                        ProfitLoss = Math.Round(ProfitLoss / 100000, 1);
                        lblProfitLoss.Text = "<span style='color: green;'>₹ " + ProfitLoss.ToString() + " L</span>";
                    }
                    if (ProfitLoss < 0)
                    {
                        ProfitLoss = Math.Round(ProfitLoss / 100000, 1);
                        lblProfitLoss.Text = "<span style='color: red;'>₹ " + ProfitLoss.ToString() + " L</span>";
                    }
                    if (ProfitLoss == 0)
                    {
                        lblProfitLoss.Text = "";
                    }
                }

                Label lblBECMT = (Label)e.Row.FindControl("lblBECMT");
                if (lblBECMT.Text != "")
                {
                    double BECMT = Convert.ToDouble(lblBECMT.Text);
                    if (BECMT > 0)
                    {
                        lblBECMT.Text = "₹" + BECMT.ToString();
                    }
                    else
                    {
                        lblBECMT.Text = "";
                    }
                }

                Label lblDHU = (Label)e.Row.FindControl("lblDHU");
                if (lblDHU.Text != "")
                {
                    double DHU = Convert.ToDouble(lblDHU.Text);
                    if (DHU > 0)
                    {
                        lblDHU.Text = DHU.ToString() + "%";
                    }
                    else
                    {
                        lblDHU.Text = "";
                    }
                }

            }

        }

        protected void gvDailyPerformance_Unit3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Cutting

                Label lblCutQtyActual = (Label)e.Row.FindControl("lblCutQtyActual");
                if (lblCutQtyActual.Text != "")
                {
                    double CutQtyActual = Convert.ToDouble(lblCutQtyActual.Text);
                    if (CutQtyActual > 0)
                    {
                        CutQtyActual = Math.Round(CutQtyActual / 1000, 1);
                        lblCutQtyActual.Text = CutQtyActual.ToString() + " k";
                    }
                    else
                    {
                        lblCutQtyActual.Text = "";
                    }
                }

                Label lblCutQtyPlan = (Label)e.Row.FindControl("lblCutQtyPlan");
                if (lblCutQtyPlan.Text != "")
                {
                    double CutQtyPlan = Convert.ToDouble(lblCutQtyPlan.Text);
                    if (CutQtyPlan > 0)
                    {
                        CutQtyPlan = Math.Round(CutQtyPlan / 1000, 1);
                        lblCutQtyPlan.Text = CutQtyPlan.ToString() + " k";
                    }
                    else
                    {
                        lblCutQtyPlan.Text = "";
                    }
                }

                Label lblCutCostPerPc = (Label)e.Row.FindControl("lblCutCostPerPc");
                if (lblCutCostPerPc.Text != "")
                {
                    double CutCostPerPc = Convert.ToDouble(lblCutCostPerPc.Text);
                    if (CutCostPerPc > 0)
                    {
                        lblCutCostPerPc.Text = "₹ " + CutCostPerPc.ToString();
                    }
                    else
                    {
                        lblCutCostPerPc.Text = "";
                    }
                }

                // Stitching Actual

                Label lblStchActualEff = (Label)e.Row.FindControl("lblStchActualEff");
                if (lblStchActualEff.Text != "")
                {
                    double StchActualEff = Convert.ToDouble(lblStchActualEff.Text);
                    if (StchActualEff > 0)
                    {
                        lblStchActualEff.Text = StchActualEff.ToString() + "%";
                    }
                    else
                    {
                        lblStchActualEff.Text = "";
                    }
                }

                Label lblStchActualAch = (Label)e.Row.FindControl("lblStchActualAch");
                if (lblStchActualAch.Text != "")
                {
                    double StchActualAch = Convert.ToDouble(lblStchActualAch.Text);
                    if (StchActualAch > 0)
                    {
                        lblStchActualAch.Text = StchActualAch.ToString() + "%";
                    }
                    else
                    {
                        lblStchActualAch.Text = "";
                    }
                }

                Label lblStchActualQty = (Label)e.Row.FindControl("lblStchActualQty");
                if (lblStchActualQty.Text != "")
                {
                    double StchActualQty = Convert.ToDouble(lblStchActualQty.Text);
                    if (StchActualQty > 0)
                    {
                        StchActualQty = Math.Round(StchActualQty / 1000, 1);
                        lblStchActualQty.Text = StchActualQty.ToString() + " k";
                    }
                    else
                    {
                        lblStchActualQty.Text = "";
                    }
                }

                // Stitching Target

                Label lblStchTargetEff = (Label)e.Row.FindControl("lblStchTargetEff");
                if (lblStchTargetEff.Text != "")
                {
                    double StchTargetEff = Convert.ToDouble(lblStchTargetEff.Text);
                    if (StchTargetEff > 0)
                    {
                        lblStchTargetEff.Text = StchTargetEff.ToString() + "%";
                    }
                    else
                    {
                        lblStchTargetEff.Text = "";
                    }
                }

                Label lblStchTargetAch = (Label)e.Row.FindControl("lblStchTargetAch");
                if (lblStchTargetAch.Text != "")
                {
                    double StchTargetAch = Convert.ToDouble(lblStchTargetAch.Text);
                    if (StchTargetAch > 0)
                    {
                        lblStchTargetAch.Text = StchTargetAch.ToString() + "%";
                    }
                    else
                    {
                        lblStchTargetAch.Text = "";
                    }
                }

                Label lblStchTargetQty = (Label)e.Row.FindControl("lblStchTargetQty");
                if (lblStchTargetQty.Text != "")
                {
                    double StchTargetQty = Convert.ToDouble(lblStchTargetQty.Text);
                    if (StchTargetQty > 0)
                    {
                        StchTargetQty = Math.Round(StchTargetQty / 1000, 1);
                        lblStchTargetQty.Text = StchTargetQty.ToString() + " k";
                    }
                    else
                    {
                        lblStchTargetQty.Text = "";
                    }
                }

                // Stitching Break Even

                Label lblStitchBreakEvenEff = (Label)e.Row.FindControl("lblStitchBreakEvenEff");
                if (lblStitchBreakEvenEff.Text != "")
                {
                    double StitchBreakEvenEff = Convert.ToDouble(lblStitchBreakEvenEff.Text);
                    if (StitchBreakEvenEff > 0)
                    {
                        lblStitchBreakEvenEff.Text = StitchBreakEvenEff.ToString() + "%";
                    }
                    else
                    {
                        lblStitchBreakEvenEff.Text = "";
                    }
                }

                Label lblStitchBreakEvenAch = (Label)e.Row.FindControl("lblStitchBreakEvenAch");
                if (lblStchTargetAch.Text != "")
                {
                    double StitchBreakEvenAch = Convert.ToDouble(lblStitchBreakEvenAch.Text);
                    if (StitchBreakEvenAch > 0)
                    {
                        lblStitchBreakEvenAch.Text = StitchBreakEvenAch.ToString() + "%";
                    }
                    else
                    {
                        lblStitchBreakEvenAch.Text = "";
                    }
                }

                Label lblStitchBreakEvenQty = (Label)e.Row.FindControl("lblStitchBreakEvenQty");
                if (lblStitchBreakEvenQty.Text != "")
                {
                    double StitchBreakEvenQty = Convert.ToDouble(lblStitchBreakEvenQty.Text);
                    if (StitchBreakEvenQty > 0)
                    {
                        StitchBreakEvenQty = Math.Round(StitchBreakEvenQty / 1000, 1);
                        lblStitchBreakEvenQty.Text = StitchBreakEvenQty.ToString() + " k";
                    }
                    else
                    {
                        lblStitchBreakEvenQty.Text = "";
                    }
                }

                // Finishing work

                Label lblFinishActualEff = (Label)e.Row.FindControl("lblFinishActualEff");
                if (lblFinishActualEff.Text != "")
                {
                    double FinishActualEff = Convert.ToDouble(lblFinishActualEff.Text);
                    if (FinishActualEff > 0)
                    {
                        lblFinishActualEff.Text = FinishActualEff.ToString() + "%";
                    }
                    else
                    {
                        lblFinishActualEff.Text = "";
                    }
                }

                Label lblFinishActualAch = (Label)e.Row.FindControl("lblFinishActualAch");
                if (lblFinishActualAch.Text != "")
                {
                    double FinishActualAch = Convert.ToDouble(lblFinishActualAch.Text);
                    if (FinishActualAch > 0)
                    {
                        lblFinishActualAch.Text = FinishActualAch.ToString() + "%";
                    }
                    else
                    {
                        lblFinishActualAch.Text = "";
                    }
                }

                Label lblFinishCost = (Label)e.Row.FindControl("lblFinishCost");
                if (lblFinishCost.Text != "")
                {
                    double FinishCost = Convert.ToDouble(lblFinishCost.Text);
                    if (FinishCost > 0)
                    {
                        lblFinishCost.Text = "₹ " + FinishCost.ToString();
                    }
                    else
                    {
                        lblFinishCost.Text = "";
                    }
                }

                Label lblFinishTgtQty = (Label)e.Row.FindControl("lblFinishTgtQty");
                if (lblFinishTgtQty.Text != "")
                {
                    double FinishTgtQty = Convert.ToDouble(lblFinishTgtQty.Text);
                    if (FinishTgtQty > 0)
                    {
                        FinishTgtQty = Math.Round(FinishTgtQty / 1000, 1);
                        lblFinishTgtQty.Text = FinishTgtQty.ToString() == "0" ? "" : FinishTgtQty.ToString() + " k";
                    }
                    else
                    {
                        lblFinishTgtQty.Text = "";
                    }
                }

                Label lblFinishActQty = (Label)e.Row.FindControl("lblFinishActQty");
                if (lblFinishActQty.Text != "")
                {
                    double FinishActQty = Convert.ToDouble(lblFinishActQty.Text);
                    if (FinishActQty > 0)
                    {
                        FinishActQty = Math.Round(FinishActQty / 1000, 1);
                        lblFinishActQty.Text = FinishActQty.ToString() + " k";
                    }
                    else
                    {
                        lblFinishActQty.Text = "";
                    }
                }

                // CMT & DHU Actual

                Label lblCMTActual = (Label)e.Row.FindControl("lblCMTActual");
                if (lblCMTActual.Text != "")
                {
                    double CMTActual = Convert.ToDouble(lblCMTActual.Text);
                    if (CMTActual > 0)
                    {
                        lblCMTActual.Text = "₹ " + CMTActual.ToString();
                    }
                    else
                    {
                        lblCMTActual.Text = "";
                    }
                }

                Label lblCMTPlan = (Label)e.Row.FindControl("lblCMTPlan");
                if (lblCMTPlan.Text != "")
                {
                    double CMTPlan = Convert.ToDouble(lblCMTPlan.Text);
                    if (CMTPlan > 0)
                    {
                        lblCMTPlan.Text = "₹ " + CMTPlan.ToString();
                    }
                    else
                    {
                        lblCMTPlan.Text = "";
                    }
                }
                Label lblFOBPrice = (Label)e.Row.FindControl("lblFOBPrice");
                if (lblFOBPrice.Text != "")
                {
                    double FOBPrice = Convert.ToDouble(lblFOBPrice.Text);
                    if (FOBPrice > 0)
                    {
                        lblFOBPrice.Text = "₹ " + FOBPrice.ToString();
                    }
                    else
                    {
                        lblFOBPrice.Text = "";
                    }
                }

                Label lblFOBStitched = (Label)e.Row.FindControl("lblFOBStitched");
                if (lblFOBStitched.Text != "")
                {
                    double FOBStitched = Convert.ToDouble(lblFOBStitched.Text);
                    if (FOBStitched > 0)
                    {
                        FOBStitched = Math.Round(FOBStitched / 100000, 1);
                        lblFOBStitched.Text = "₹ " + FOBStitched.ToString() + " L";
                    }
                    else
                    {
                        lblFOBStitched.Text = "";
                    }
                }

                // CMT & DHU %

                Label lblCMTPercent = (Label)e.Row.FindControl("lblCMTPercent");
                if (lblCMTPercent.Text != "")
                {
                    double FinishActualAch = Convert.ToDouble(lblCMTPercent.Text);
                    if (FinishActualAch > 0)
                    {
                        lblCMTPercent.Text = FinishActualAch.ToString() + "%";
                    }
                    else
                    {
                        lblCMTPercent.Text = "";
                    }
                }

                Label lblProfitLoss = (Label)e.Row.FindControl("lblProfitLoss");
                if (lblProfitLoss.Text != "")
                {
                    double ProfitLoss = Convert.ToDouble(lblProfitLoss.Text);                    
                    if (ProfitLoss > 0)
                    {
                        ProfitLoss = Math.Round(ProfitLoss / 100000, 1);
                        lblProfitLoss.Text = "<span style='color: green;'>₹ " + ProfitLoss.ToString() + " L</span>";
                    }
                    if (ProfitLoss < 0)
                    {
                        ProfitLoss = Math.Round(ProfitLoss / 100000, 1);
                        lblProfitLoss.Text = "<span style='color: red;'>₹ " + ProfitLoss.ToString() + " L</span>";
                    }
                    if (ProfitLoss == 0)
                    {
                        lblProfitLoss.Text = "";
                    }
                }

                Label lblBECMT = (Label)e.Row.FindControl("lblBECMT");
                if (lblBECMT.Text != "")
                {
                    double BECMT = Convert.ToDouble(lblBECMT.Text);
                    if (BECMT > 0)
                    {
                        lblBECMT.Text = "₹" + BECMT.ToString();
                    }
                    else
                    {
                        lblBECMT.Text = "";
                    }
                }

                Label lblDHU = (Label)e.Row.FindControl("lblDHU");
                if (lblDHU.Text != "")
                {
                    double DHU = Convert.ToDouble(lblDHU.Text);
                    if (DHU > 0)
                    {
                        lblDHU.Text = DHU.ToString() + "%";
                    }
                    else
                    {
                        lblDHU.Text = "";
                    }
                }

            }

        }

        protected void gvDailyPerformance_Unit4_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Cutting

                Label lblCutQtyActual = (Label)e.Row.FindControl("lblCutQtyActual");
                if (lblCutQtyActual.Text != "")
                {
                    double CutQtyActual = Convert.ToDouble(lblCutQtyActual.Text);
                    if (CutQtyActual > 0)
                    {
                        CutQtyActual = Math.Round(CutQtyActual / 1000, 1);
                        lblCutQtyActual.Text = CutQtyActual.ToString() + " k";
                    }
                    else
                    {
                        lblCutQtyActual.Text = "";
                    }
                }

                Label lblCutQtyPlan = (Label)e.Row.FindControl("lblCutQtyPlan");
                if (lblCutQtyPlan.Text != "")
                {
                    double CutQtyPlan = Convert.ToDouble(lblCutQtyPlan.Text);
                    if (CutQtyPlan > 0)
                    {
                        CutQtyPlan = Math.Round(CutQtyPlan / 1000, 1);
                        lblCutQtyPlan.Text = CutQtyPlan.ToString() + " k";
                    }
                    else
                    {
                        lblCutQtyPlan.Text = "";
                    }
                }

                Label lblCutCostPerPc = (Label)e.Row.FindControl("lblCutCostPerPc");
                if (lblCutCostPerPc.Text != "")
                {
                    double CutCostPerPc = Convert.ToDouble(lblCutCostPerPc.Text);
                    if (CutCostPerPc > 0)
                    {
                        lblCutCostPerPc.Text = "₹ " + CutCostPerPc.ToString();
                    }
                    else
                    {
                        lblCutCostPerPc.Text = "";
                    }
                }

                // Stitching Actual

                Label lblStchActualEff = (Label)e.Row.FindControl("lblStchActualEff");
                if (lblStchActualEff.Text != "")
                {
                    double StchActualEff = Convert.ToDouble(lblStchActualEff.Text);
                    if (StchActualEff > 0)
                    {
                        lblStchActualEff.Text = StchActualEff.ToString() + "%";
                    }
                    else
                    {
                        lblStchActualEff.Text = "";
                    }
                }

                Label lblStchActualAch = (Label)e.Row.FindControl("lblStchActualAch");
                if (lblStchActualAch.Text != "")
                {
                    double StchActualAch = Convert.ToDouble(lblStchActualAch.Text);
                    if (StchActualAch > 0)
                    {
                        lblStchActualAch.Text = StchActualAch.ToString() + "%";
                    }
                    else
                    {
                        lblStchActualAch.Text = "";
                    }
                }

                Label lblStchActualQty = (Label)e.Row.FindControl("lblStchActualQty");
                if (lblStchActualQty.Text != "")
                {
                    double StchActualQty = Convert.ToDouble(lblStchActualQty.Text);
                    if (StchActualQty > 0)
                    {
                        StchActualQty = Math.Round(StchActualQty / 1000, 1);
                        lblStchActualQty.Text = StchActualQty.ToString() + " k";
                    }
                    else
                    {
                        lblStchActualQty.Text = "";
                    }
                }

                // Stitching Target

                Label lblStchTargetEff = (Label)e.Row.FindControl("lblStchTargetEff");
                if (lblStchTargetEff.Text != "")
                {
                    double StchTargetEff = Convert.ToDouble(lblStchTargetEff.Text);
                    if (StchTargetEff > 0)
                    {
                        lblStchTargetEff.Text = StchTargetEff.ToString() + "%";
                    }
                    else
                    {
                        lblStchTargetEff.Text = "";
                    }
                }

                Label lblStchTargetAch = (Label)e.Row.FindControl("lblStchTargetAch");
                if (lblStchTargetAch.Text != "")
                {
                    double StchTargetAch = Convert.ToDouble(lblStchTargetAch.Text);
                    if (StchTargetAch > 0)
                    {
                        lblStchTargetAch.Text = StchTargetAch.ToString() + "%";
                    }
                    else
                    {
                        lblStchTargetAch.Text = "";
                    }
                }

                Label lblStchTargetQty = (Label)e.Row.FindControl("lblStchTargetQty");
                if (lblStchTargetQty.Text != "")
                {
                    double StchTargetQty = Convert.ToDouble(lblStchTargetQty.Text);
                    if (StchTargetQty > 0)
                    {
                        StchTargetQty = Math.Round(StchTargetQty / 1000, 1);
                        lblStchTargetQty.Text = StchTargetQty.ToString() + " k";
                    }
                    else
                    {
                        lblStchTargetQty.Text = "";
                    }
                }

                // Stitching Break Even

                Label lblStitchBreakEvenEff = (Label)e.Row.FindControl("lblStitchBreakEvenEff");
                if (lblStitchBreakEvenEff.Text != "")
                {
                    double StitchBreakEvenEff = Convert.ToDouble(lblStitchBreakEvenEff.Text);
                    if (StitchBreakEvenEff > 0)
                    {
                        lblStitchBreakEvenEff.Text = StitchBreakEvenEff.ToString() + "%";
                    }
                    else
                    {
                        lblStitchBreakEvenEff.Text = "";
                    }
                }

                Label lblStitchBreakEvenAch = (Label)e.Row.FindControl("lblStitchBreakEvenAch");
                if (lblStchTargetAch.Text != "")
                {
                    double StitchBreakEvenAch = Convert.ToDouble(lblStitchBreakEvenAch.Text);
                    if (StitchBreakEvenAch > 0)
                    {
                        lblStitchBreakEvenAch.Text = StitchBreakEvenAch.ToString() + "%";
                    }
                    else
                    {
                        lblStitchBreakEvenAch.Text = "";
                    }
                }

                Label lblStitchBreakEvenQty = (Label)e.Row.FindControl("lblStitchBreakEvenQty");
                if (lblStitchBreakEvenQty.Text != "")
                {
                    double StitchBreakEvenQty = Convert.ToDouble(lblStitchBreakEvenQty.Text);
                    if (StitchBreakEvenQty > 0)
                    {
                        StitchBreakEvenQty = Math.Round(StitchBreakEvenQty / 1000, 1);
                        lblStitchBreakEvenQty.Text = StitchBreakEvenQty.ToString() + " k";
                    }
                    else
                    {
                        lblStitchBreakEvenQty.Text = "";
                    }
                }

                // Finishing work

                Label lblFinishActualEff = (Label)e.Row.FindControl("lblFinishActualEff");
                if (lblFinishActualEff.Text != "")
                {
                    double FinishActualEff = Convert.ToDouble(lblFinishActualEff.Text);
                    if (FinishActualEff > 0)
                    {
                        lblFinishActualEff.Text = FinishActualEff.ToString() + "%";
                    }
                    else
                    {
                        lblFinishActualEff.Text = "";
                    }
                }

                Label lblFinishActualAch = (Label)e.Row.FindControl("lblFinishActualAch");
                if (lblFinishActualAch.Text != "")
                {
                    double FinishActualAch = Convert.ToDouble(lblFinishActualAch.Text);
                    if (FinishActualAch > 0)
                    {
                        lblFinishActualAch.Text = FinishActualAch.ToString() + "%";
                    }
                    else
                    {
                        lblFinishActualAch.Text = "";
                    }
                }

                Label lblFinishCost = (Label)e.Row.FindControl("lblFinishCost");
                if (lblFinishCost.Text != "")
                {
                    double FinishCost = Convert.ToDouble(lblFinishCost.Text);
                    if (FinishCost > 0)
                    {
                        lblFinishCost.Text = "₹ " + FinishCost.ToString();
                    }
                    else
                    {
                        lblFinishCost.Text = "";
                    }
                }

                Label lblFinishTgtQty = (Label)e.Row.FindControl("lblFinishTgtQty");
                if (lblFinishTgtQty.Text != "")
                {
                    double FinishTgtQty = Convert.ToDouble(lblFinishTgtQty.Text);
                    if (FinishTgtQty > 0)
                    {
                        FinishTgtQty =  Math.Round(FinishTgtQty / 1000, 1);
                        lblFinishTgtQty.Text = FinishTgtQty.ToString() == "0" ? "" : FinishTgtQty.ToString() + " k";
                    }
                    else
                    {
                        lblFinishTgtQty.Text = "";
                    }
                }

                Label lblFinishActQty = (Label)e.Row.FindControl("lblFinishActQty");
                if (lblFinishActQty.Text != "")
                {
                    double FinishActQty = Convert.ToDouble(lblFinishActQty.Text);
                    if (FinishActQty > 0)
                    {
                        FinishActQty = Math.Round(FinishActQty / 1000, 1);
                        lblFinishActQty.Text = FinishActQty.ToString() + " k";
                    }
                    else
                    {
                        lblFinishActQty.Text = "";
                    }
                }

                // CMT & DHU Actual

                Label lblCMTActual = (Label)e.Row.FindControl("lblCMTActual");
                if (lblCMTActual.Text != "")
                {
                    double CMTActual = Convert.ToDouble(lblCMTActual.Text);
                    if (CMTActual > 0)
                    {
                        lblCMTActual.Text = "₹ " + CMTActual.ToString();
                    }
                    else
                    {
                        lblCMTActual.Text = "";
                    }
                }

                Label lblCMTPlan = (Label)e.Row.FindControl("lblCMTPlan");
                if (lblCMTPlan.Text != "")
                {
                    double CMTPlan = Convert.ToDouble(lblCMTPlan.Text);
                    if (CMTPlan > 0)
                    {
                        lblCMTPlan.Text = "₹ " + CMTPlan.ToString();
                    }
                    else
                    {
                        lblCMTPlan.Text = "";
                    }
                }
                Label lblFOBPrice = (Label)e.Row.FindControl("lblFOBPrice");
                if (lblFOBPrice.Text != "")
                {
                    double FOBPrice = Convert.ToDouble(lblFOBPrice.Text);
                    if (FOBPrice > 0)
                    {
                        lblFOBPrice.Text = "₹ " + FOBPrice.ToString();
                    }
                    else
                    {
                        lblFOBPrice.Text = "";
                    }
                }

                Label lblFOBStitched = (Label)e.Row.FindControl("lblFOBStitched");
                if (lblFOBStitched.Text != "")
                {
                    double FOBStitched = Convert.ToDouble(lblFOBStitched.Text);
                    if (FOBStitched > 0)
                    {
                        FOBStitched = Math.Round(FOBStitched / 100000, 1);
                        lblFOBStitched.Text = FOBStitched.ToString() + " L";
                    }
                    else
                    {
                        lblFOBStitched.Text = "";
                    }
                }

                // CMT & DHU %

                Label lblCMTPercent = (Label)e.Row.FindControl("lblCMTPercent");
                if (lblCMTPercent.Text != "")
                {
                    double FinishActualAch = Convert.ToDouble(lblCMTPercent.Text);
                    if (FinishActualAch > 0)
                    {
                        lblCMTPercent.Text = FinishActualAch.ToString() + "%";
                    }
                    else
                    {
                        lblCMTPercent.Text = "";
                    }
                }

                Label lblProfitLoss = (Label)e.Row.FindControl("lblProfitLoss");
                if (lblProfitLoss.Text != "")
                {
                    double ProfitLoss = Convert.ToDouble(lblProfitLoss.Text);
                    if (ProfitLoss > 0)
                    {
                        ProfitLoss = Math.Round(ProfitLoss / 100000, 1);
                        lblProfitLoss.Text = "<span style='color: green;'>₹ " + ProfitLoss.ToString() + " L</span>";
                    }
                    if (ProfitLoss < 0)
                    {
                        ProfitLoss = Math.Round(ProfitLoss / 100000, 1);
                        lblProfitLoss.Text = "<span style='color: red;'>₹ " + ProfitLoss.ToString() + " L</span>";
                    }
                    if (ProfitLoss == 0)
                    {
                        lblProfitLoss.Text = "";
                    }
                }

                Label lblBECMT = (Label)e.Row.FindControl("lblBECMT");
                if (lblBECMT.Text != "")
                {
                    double BECMT = Convert.ToDouble(lblBECMT.Text);
                    if (BECMT > 0)
                    {
                        lblBECMT.Text = "₹" + BECMT.ToString();
                    }
                    else
                    {
                        lblBECMT.Text = "";
                    }
                }

                Label lblDHU = (Label)e.Row.FindControl("lblDHU");
                if (lblDHU.Text != "")
                {
                    double DHU = Convert.ToDouble(lblDHU.Text);
                    if (DHU > 0)
                    {
                        lblDHU.Text = DHU.ToString() + "%";
                    }
                    else
                    {
                        lblDHU.Text = "";
                    }
                }

            }

        }

        protected void gvCMTAchievement_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // @90

                Label lblCMTPlan90 = (Label)e.Row.FindControl("lblCMTPlan90");
                if (lblCMTPlan90.Text != "")
                {
                    double CMTPlan90 = Convert.ToDouble(lblCMTPlan90.Text);
                    if (CMTPlan90 > 0)
                    {
                        lblCMTPlan90.Text = CMTPlan90.ToString();
                    }
                    else
                    {
                        lblCMTPlan90.Text = "";
                    }
                }

                Label lblFOBPrice90 = (Label)e.Row.FindControl("lblFOBPrice90");
                if (lblFOBPrice90.Text != "")
                {
                    double FOBPrice90 = Convert.ToDouble(lblFOBPrice90.Text);
                    if (FOBPrice90 > 0)
                    {
                        lblFOBPrice90.Text = "₹ " + FOBPrice90.ToString();
                    }
                    else
                    {
                        lblFOBPrice90.Text = "";
                    }
                }

                Label lblFOBStitch90 = (Label)e.Row.FindControl("lblFOBStitch90");
                if (lblFOBStitch90.Text != "")
                {
                    double FOBStitch90 = Convert.ToDouble(lblFOBStitch90.Text);
                    if (FOBStitch90 > 0)
                    {
                        FOBStitch90 = Math.Round(FOBStitch90 / 100000, 1);
                        lblFOBStitch90.Text = "(₹ " + FOBStitch90.ToString() + " L)";                        
                    }
                    else
                    {
                        lblFOBStitch90.Text = "";
                    }
                }

                Label lblCMTPercent90 = (Label)e.Row.FindControl("lblCMTPercent90");
                if (lblCMTPercent90.Text != "")
                {
                    double CMTPercent90 = Convert.ToDouble(lblCMTPercent90.Text);
                    if (CMTPercent90 > 0)
                    {
                        lblCMTPercent90.Text = CMTPercent90.ToString() + "%";
                    }
                    else
                    {
                        lblCMTPercent90.Text = "";
                    }
                }

                Label lblProfitLoss_90 = (Label)e.Row.FindControl("lblProfitLoss_90");
                if (lblProfitLoss_90.Text != "")
                {
                    double ProfitLoss_90 = Convert.ToDouble(lblProfitLoss_90.Text);
                    if (ProfitLoss_90 > 0)
                    {
                        ProfitLoss_90 = Math.Round(ProfitLoss_90 / 100000, 1);
                        lblProfitLoss_90.Text = "(₹ " + ProfitLoss_90.ToString() + " L)";
                    }
                    else
                    {
                        lblProfitLoss_90.Text = "";
                    }
                }

                // @95

                Label lblCMTPlan95 = (Label)e.Row.FindControl("lblCMTPlan95");
                if (lblCMTPlan95.Text != "")
                {
                    double CMTPlan95 = Convert.ToDouble(lblCMTPlan95.Text);
                    if (CMTPlan95 > 0)
                    {
                        lblCMTPlan95.Text = CMTPlan95.ToString();
                    }
                    else
                    {
                        lblCMTPlan95.Text = "";
                    }
                }

                Label lblFOBPrice95 = (Label)e.Row.FindControl("lblFOBPrice95");
                if (lblFOBPrice95.Text != "")
                {
                    double FOBPrice95 = Convert.ToDouble(lblFOBPrice95.Text);
                    if (FOBPrice95 > 0)
                    {
                        lblFOBPrice95.Text = "₹ " + FOBPrice95.ToString();               
                    }
                    else
                    {
                        lblFOBPrice95.Text = "";
                    }
                }

                Label lblFOBStitch95 = (Label)e.Row.FindControl("lblFOBStitch95");
                if (lblFOBStitch95.Text != "")
                {
                    double FOBStitch95 = Convert.ToDouble(lblFOBStitch95.Text);
                    if (FOBStitch95 > 0)
                    {
                        FOBStitch95 = Math.Round(FOBStitch95 / 100000, 1);
                        lblFOBStitch95.Text = "(₹ " + FOBStitch95.ToString() + " L)"; 
                    }
                    else
                    {
                        lblFOBStitch95.Text = "";
                    }
                }

                Label lblCMTPercent95 = (Label)e.Row.FindControl("lblCMTPercent95");
                if (lblCMTPercent95.Text != "")
                {
                    double CMTPercent95 = Convert.ToDouble(lblCMTPercent95.Text);
                    if (CMTPercent95 > 0)
                    {
                        lblCMTPercent95.Text = CMTPercent95.ToString() + "%";
                    }
                    else
                    {
                        lblCMTPercent95.Text = "";
                    }
                }

                Label lblProfitLoss_95 = (Label)e.Row.FindControl("lblProfitLoss_95");
                if (lblProfitLoss_95.Text != "")
                {
                    double ProfitLoss_95 = Convert.ToDouble(lblProfitLoss_95.Text);
                    if (ProfitLoss_95 > 0)
                    {
                        ProfitLoss_95 = Math.Round(ProfitLoss_95 / 100000, 1);
                        lblProfitLoss_95.Text = "(₹ " + ProfitLoss_95.ToString() + " L)";
                    }
                    else
                    {
                        lblProfitLoss_95.Text = "";
                    }
                }

                // @100

                Label lblCMTPlan100 = (Label)e.Row.FindControl("lblCMTPlan100");
                if (lblCMTPlan100.Text != "")
                {
                    double CMTPlan100 = Convert.ToDouble(lblCMTPlan100.Text);
                    if (CMTPlan100 > 0)
                    {
                        lblCMTPlan100.Text = CMTPlan100.ToString();
                    }
                    else
                    {
                        lblCMTPlan100.Text = "";
                    }
                }

                Label lblFOBPrice100 = (Label)e.Row.FindControl("lblFOBPrice100");
                if (lblFOBPrice100.Text != "")
                {
                    double FOBPrice100 = Convert.ToDouble(lblFOBPrice100.Text);
                    if (FOBPrice100 > 0)
                    {
                        lblFOBPrice100.Text = "₹ " + FOBPrice100.ToString();
                    }
                    else
                    {
                        lblFOBPrice100.Text = "";
                    }
                }

                Label lblFOBStitch100 = (Label)e.Row.FindControl("lblFOBStitch100");
                if (lblFOBStitch100.Text != "")
                {
                    double FOBStitch100 = Convert.ToDouble(lblFOBStitch100.Text);
                    if (FOBStitch100 > 0)
                    {
                        FOBStitch100 = Math.Round(FOBStitch100 / 100000, 1);
                        lblFOBStitch100.Text = "(₹ " + FOBStitch100.ToString() + " L)";    
                    }
                    else
                    {
                        lblFOBStitch100.Text = "";
                    }
                }

                Label lblCMTPercent100 = (Label)e.Row.FindControl("lblCMTPercent100");
                if (lblCMTPercent100.Text != "")
                {
                    double CMTPercent100 = Convert.ToDouble(lblCMTPercent100.Text);
                    if (CMTPercent100 > 0)
                    {
                        lblCMTPercent100.Text = CMTPercent100.ToString() + "%";
                    }
                    else
                    {
                        lblCMTPercent100.Text = "";
                    }
                }

                Label lblProfitLoss_100 = (Label)e.Row.FindControl("lblProfitLoss_100");
                if (lblProfitLoss_100.Text != "")
                {
                    double ProfitLoss_100 = Convert.ToDouble(lblProfitLoss_100.Text);
                    if (ProfitLoss_100 > 0)
                    {
                        ProfitLoss_100 = Math.Round(ProfitLoss_100 / 100000, 1);
                        lblProfitLoss_100.Text = "(₹ " + ProfitLoss_100.ToString() + " L)";
                    }
                    else
                    {
                        lblProfitLoss_100.Text = "";
                    }
                }
            }
        }        


    }
}