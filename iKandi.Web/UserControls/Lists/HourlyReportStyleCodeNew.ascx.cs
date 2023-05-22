using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL.Production;
using System.Data;
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Web.UI.HtmlControls;
using System.Drawing;

namespace iKandi.Web.UserControls.Lists
{
    public partial class HourlyReportStyleCodeNew : System.Web.UI.UserControl
    {
        public int ProductionUnit
        {
            get;
            set;
        }
        public int SlotId
        {
            get;
            set;
        }
        public int LineNo
        {
            get;
            set;
        }
        public int StyleId
        {
            get;
            set;
        }
        public string StartDate
        {
            get;
            set;
        }

        int Total_Slot1 = 0;
        int Total_Slot2 = 0;
        int Total_Slot3 = 0;
        int Total_Slot4 = 0;
        int Total_Slot5 = 0;
        int Total_Slot6 = 0;
        int Total_Slot7 = 0;
        int Total_Slot8 = 0;
        int Total_Slot9 = 0;
        int Total_Slot10 = 0;
        int Total_Slot11 = 0;
        int Total_Slot12 = 0;
        int Total_Slot13 = 0;
        int Total_Slot14 = 0;
        int Total_Slot15 = 0;
        int Total_Slot16 = 0;

        int Slot1TotalOB = 0;
        int Slot2TotalOB = 0;
        int Slot3TotalOB = 0;
        int Slot4TotalOB = 0;
        int Slot5TotalOB = 0;
        int Slot6TotalOB = 0;
        int Slot7TotalOB = 0;
        int Slot8TotalOB = 0;
        int Slot9TotalOB = 0;
        int Slot10TotalOB = 0;
        int Slot11TotalOB = 0;
        int Slot12TotalOB = 0;
        int Slot13TotalOB = 0;
        int Slot14TotalOB = 0;
        int Slot15TotalOB = 0;
        int Slot16TotalOB = 0;

        int Total_DHU1 = 0;
        int Total_DHU2 = 0;
        int Total_DHU3 = 0;
        int Total_DHU4 = 0;
        int Total_DHU5 = 0;
        int Total_DHU6 = 0;
        int Total_DHU7 = 0;
        int Total_DHU8 = 0;
        int Total_DHU9 = 0;
        int Total_DHU10 = 0;
        int Total_DHU11 = 0;
        int Total_DHU12 = 0;
        int Total_DHU13 = 0;
        int Total_DHU14 = 0;
        int Total_DHU15 = 0;
        int Total_DHU16 = 0;

        double Total_StitchEff1 = 0;
        double Total_StitchEff2 = 0;
        double Total_StitchEff3 = 0;
        double Total_StitchEff4 = 0;
        double Total_StitchEff5 = 0;
        double Total_StitchEff6 = 0;
        double Total_StitchEff7 = 0;
        double Total_StitchEff8 = 0;
        double Total_StitchEff9 = 0;
        double Total_StitchEff10 = 0;
        double Total_StitchEff11 = 0;
        double Total_StitchEff12 = 0;
        double Total_StitchEff13 = 0;
        double Total_StitchEff14 = 0;
        double Total_StitchEff15 = 0;
        double Total_StitchEff16 = 0;


        int Total_Achievement1 = 0;
        int Total_Achievement2 = 0;
        int Total_Achievement3 = 0;
        int Total_Achievement4 = 0;
        int Total_Achievement5 = 0;
        int Total_Achievement6 = 0;
        int Total_Achievement7 = 0;
        int Total_Achievement8 = 0;
        int Total_Achievement9 = 0;
        int Total_Achievement10 = 0;
        int Total_Achievement11 = 0;
        int Total_Achievement12 = 0;
        int Total_Achievement13 = 0;
        int Total_Achievement14 = 0;
        int Total_Achievement15 = 0;
        int Total_Achievement16 = 0;

        int Slot1TargetQty = 0;
        int Slot2TargetQty = 0;
        int Slot3TargetQty = 0;
        int Slot4TargetQty = 0;
        int Slot5TargetQty = 0;
        int Slot6TargetQty = 0;
        int Slot7TargetQty = 0;
        int Slot8TargetQty = 0;
        int Slot9TargetQty = 0;
        int Slot10TargetQty = 0;
        int Slot11TargetQty = 0;
        int Slot12TargetQty = 0;
        int Slot13TargetQty = 0;
        int Slot14TargetQty = 0;
        int Slot15TargetQty = 0;
        int Slot16TargetQty = 0;

        double TotalOB = 0;

        double TotalBreakEvenQty = 0;
        int TargetEff_Total = 0;
        int TargetQty_Total = 0;
        int TodayEfficiency_Stitch_Total = 0;
        int StyleEfficiency_Stitch_Total = 0;
        int StyleEffCount = 0;
        int DHUCount = 0;
        int CMTCount = 0;
        int PercentPerformanceCount = 0;
        int PeakEffCount = 0;
        int COTValueCount = 0;

        int FactoryTotal = 0;
        int AchievementCount = 0;
        int EfficencyTotal = 0;
        double StitchSAM_Total = 0;
        double FinishSAM_Total = 0;
        double StitchSAM_TargetQty_Total = 0;

        int StitchActualOB_Total = 0;
        int StitchOB_Total = 0;
        int FinishActualOB_Total = 0;
        int FinishOB_Total = 0;
        int StitchOB_Factory = 0;
        double CostingCMT_Total = 0;

        int PeakCapecity_Total = 0;
        int PeakOB_Total = 0;
        int OrderQty_Total = 0;
        int COTValue_Total = 0;

        int PeakEff_Total = 0;
        int StitchQty_Total = 0;
        int FinishQty_Total = 0;
        int TodayPassPcsFinish_Total = 0;
        int TodayPassPcsStitch_Total = 0;
        int TodayAltPcs_Total = 0;
        int DHU_Today_Total = 0;
        int TodayAchieved_Total = 0;

        int UnitId = -1;
        int Factory_BreakEvenQty = 0;
        int Factory_StchAvgPcs = 0;

        int FabricQty_Total = 0;
        int CutQty_Total = 0;
        int PercentPerformance_Total = 0;
        int PeakCapcty_Finish_Total = 0;
        int PeakOB_Finish_Total = 0;
        int PeakEff_Finish_Total = 0;
        int TCCapcty_Total = 0;
        int TCPeakOB_Total = 0;
        int TCActualOB_Total = 0;
        int PressCapcty_Total = 0;
        int PressPeakOB_Total = 0;
        int PressActualOB_Total = 0;
        int TotalTodayFinishObatLineCluster = 0;
        int FactoryTotalTodayFinishObatLineCluster = 0;
        int BIPLTotalTodayFinishObatLineCluster = 0;

        double TodayPassFinish_BIPL = 0;

        double StitchActualAvgOB_Total = 0;
        double FinishActualAvgOB_Total = 0;
        int MaxStitchPassCount = 0;
        int MaxFinishPassCount = 0;

        double WIPBIPL_Cutting = 0;
        double WIPBIPL_Stitching = 0;
        double WIPBIPL_Finishing = 0;
        double WIPBIPL_Fabric1CheckedQty = 0;
        double WIPBIPL_PrevStitching = 0;
        double WIPBIPL_PrevFinishing = 0;
        int BIPL_Efficiency = 0;

        double CuttingPerPcsCost = 0;
        double StichingPerOBCost = 0;
        double FinishingPerOBCost = 0;
        double FinishingPerPcsCost = 0;
        double FactoryOverHeadPerPcs = 0;
        double CostPerHour = 0;
        double SlotOverHead = 0;

        double BIPLPriceSlot1 = 0;
        double BIPLPriceSlot2 = 0;
        double BIPLPriceSlot3 = 0;
        double BIPLPriceSlot4 = 0;
        double BIPLPriceSlot5 = 0;
        double BIPLPriceSlot6 = 0;
        double BIPLPriceSlot7 = 0;
        double BIPLPriceSlot8 = 0;
        double BIPLPriceSlot9 = 0;
        double BIPLPriceSlot10 = 0;
        double BIPLPriceSlot11 = 0;
        double BIPLPriceSlot12 = 0;
        double BIPLPriceSlot13 = 0;
        double BIPLPriceSlot14 = 0;
        double BIPLPriceSlot15 = 0;
        double BIPLPriceSlot16 = 0;

        int PreviousUnit = 0;
        int PassCount = 0;
        int FailCount = 0;
        int TotalPassCount = 0;
        int TotalFailCount = 0;
        string StyleCode = string.Empty;


        ProductionController objProductionController = new ProductionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Application["HourlyError"] = "Success";

                    GetStitchingSlotTime();
                    GetStitchingHourlyReport();
                    HideStitchingUnUsedSlot();
                    HideStitchingTimingUnUsedSlot();
                }
                catch (Exception Ex)
                {
                    string err = Ex.Message.ToString();
                    Application["HourlyError"] = err.ToString();
                    int Results = objProductionController.UpdateHrlyErrorLog(err.ToString(), ProductionUnit, SlotId, LineNo, StyleId);
                }
            }
        }

        #region Stitching

        private void GetStitchingSlotTime()
        {
            DataSet ds;
            ds = objProductionController.GetHourlyReportStyleCode("", "", -1, -1, -1, -1, "SlotTime");
            DataTable dt = ds.Tables[0];
            DataTable dtSlot = new DataTable();
            DataTable dtSlottiming = new DataTable();
            int SlotCount = 1;
            DataRow row = dtSlot.NewRow();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dtSlot.Columns.Add(new DataColumn("SlotStart" + SlotCount, typeof(string)));
                dtSlot.Columns.Add(new DataColumn("SlotEnd" + SlotCount, typeof(string)));

                row["SlotStart" + SlotCount] = dt.Rows[i]["SlotStart"].ToString();
                row["SlotEnd" + SlotCount] = dt.Rows[i]["SlotEnd"].ToString();

                SlotCount = SlotCount + 1;
            }
            dtSlot.Rows.Add(row);
            dtSlot.AcceptChanges();
            ViewState["dtSlot"] = dtSlot;
            if (ds.Tables[1].Rows.Count > 0)
            {
                hdnSlotId.Value = ds.Tables[1].Rows[0]["SLOTID"].ToString();
            }
            if (hdnSlotId.Value == "")
                hdnSlotId.Value = "0";
            // Now fetch the finishing OB cost
            DataTable dt1 = ds.Tables[2];
            StichingPerOBCost = Convert.ToDouble(dt1.Rows[0]["StichingPerOBCost"].ToString());
            FinishingPerOBCost = Convert.ToDouble(dt1.Rows[0]["FinishingPerOBCost"].ToString());
            CuttingPerPcsCost = Convert.ToDouble(dt1.Rows[0]["CuttingPerPcsCost"].ToString());
            FinishingPerPcsCost = Convert.ToDouble(dt1.Rows[0]["FinishingPerPcsCost"].ToString());
            FactoryOverHeadPerPcs = Convert.ToDouble(dt1.Rows[0]["FactoryOverHeadPerPcs"].ToString());
            CostPerHour = Convert.ToDouble(dt1.Rows[0]["CostPerHour"].ToString());
            SlotOverHead = Convert.ToDouble(dt1.Rows[0]["SlotOverHead"].ToString());
        }

        private void GetStitchingHourlyReport()
        {
            DataSet ds;
            Stitch1EmptyMsg.Visible = false;
            lblStitch1EmptyMsg1.Text = "";
            lblStitch1EmptyMsg2.Text = "";
            ds = objProductionController.GetHourlyReportStyleCode("", "", -1, -1, -1, -1, "HourlyReport");
            if (ds.Tables.Count > 1)
            {
                DataTable dtAchievement = ds.Tables[1];
                ViewState["dtAchievement"] = dtAchievement;
            }
            if (ds.Tables.Count > 2)
            {
                DataTable dtStitchEff = ds.Tables[2];
                ViewState["dtStitchEff"] = dtStitchEff;
            }
            if (ds.Tables.Count > 3)
            {
                DataTable dtTargetQty = ds.Tables[3];
                ViewState["dtTargetQty"] = dtTargetQty;
            }
            gvHourlyStitchingReport.DataSource = ds.Tables[0];
            gvHourlyStitchingReport.DataBind();
            grvSlotTiming.DataSource = (DataTable)ViewState["dtSlot"];
            grvSlotTiming.DataBind();


        }

        private void GetLineDesignationDataTable()
        {
            DataTable dt = (DataTable)ViewState["tblLineDesignation"];
            DataTable dtLineDesignation = new DataTable();

            dtLineDesignation.Columns.Add(new DataColumn("StyleId", typeof(int)));

            int BaseStyle = -1;
            int UniqueBaseStyle = -1;
            for (int iStyle = 0; iStyle < dt.Rows.Count; iStyle++)
            {
                DataRow row = dtLineDesignation.NewRow();
                BaseStyle = Convert.ToInt32(dt.Rows[iStyle]["StyleId"]);

                if ((UniqueBaseStyle != BaseStyle) || (UniqueBaseStyle == -1))
                {
                    UniqueBaseStyle = BaseStyle;
                    int PrevStyleId = -1;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int StyleId = Convert.ToInt32(dt.Rows[i]["StyleId"]);

                        if (PrevStyleId == -1)
                        {
                            PrevStyleId = StyleId;
                            dtLineDesignation.Columns.Add(new DataColumn(dt.Rows[i]["Name"].ToString(), typeof(string)));
                            row["StyleId"] = Convert.ToInt32(dt.Rows[i]["StyleId"]);
                            row[dt.Rows[i]["Name"].ToString()] = dt.Rows[i]["DesignationName"].ToString();
                        }
                        else
                        {
                            dtLineDesignation.Columns.Add(new DataColumn(dt.Rows[i]["Name"].ToString(), typeof(string)));
                            row[dt.Rows[i]["Name"].ToString()] = dt.Rows[i]["DesignationName"].ToString();
                        }
                    }
                    dtLineDesignation.Rows.Add(row);
                    dtLineDesignation.AcceptChanges();
                }
            }

            ViewState["dtLineDesignation"] = dtLineDesignation;
        }

        protected void gvHourlyStitchingReport_DataBound(object sender, EventArgs e)
        {
            for (int i = gvHourlyStitchingReport.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvHourlyStitchingReport.Rows[i];
                GridViewRow previousRow = gvHourlyStitchingReport.Rows[i - 1];

                Label lblUnit = (Label)row.Cells[0].FindControl("lblUnit");
                Label lblPreviousUnit = (Label)previousRow.Cells[0].FindControl("lblUnit");

            }
        }

        protected void grvSlotTiming_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            DataTable dtSlot = (DataTable)ViewState["dtSlot"];
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSlot1Timing = (Label)e.Row.FindControl("lblSlot1Timing");
                lblSlot1Timing.Text = dtSlot.Rows[0]["SlotStart1"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd1"].ToString();

                Label lblSlot2Timing = (Label)e.Row.FindControl("lblSlot2Timing");
                lblSlot2Timing.Text = dtSlot.Rows[0]["SlotStart2"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd2"].ToString();

                Label lblSlot3Timing = (Label)e.Row.FindControl("lblSlot3Timing");
                lblSlot3Timing.Text = dtSlot.Rows[0]["SlotStart3"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd3"].ToString();

                Label lblSlot4Timing = (Label)e.Row.FindControl("lblSlot4Timing");
                lblSlot4Timing.Text = dtSlot.Rows[0]["SlotStart4"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd4"].ToString();

                Label lblSlot5Timing = (Label)e.Row.FindControl("lblSlot5Timing");
                lblSlot5Timing.Text = dtSlot.Rows[0]["SlotStart5"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd5"].ToString();

                Label lblSlot6Timing = (Label)e.Row.FindControl("lblSlot6Timing");
                lblSlot6Timing.Text = dtSlot.Rows[0]["SlotStart6"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd6"].ToString();

                Label lblSlot7Timing = (Label)e.Row.FindControl("lblSlot7Timing");
                lblSlot7Timing.Text = dtSlot.Rows[0]["SlotStart7"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd7"].ToString();

                Label lblSlot8Timing = (Label)e.Row.FindControl("lblSlot8Timing");
                lblSlot8Timing.Text = dtSlot.Rows[0]["SlotStart8"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd8"].ToString();

                Label lblSlot9Timing = (Label)e.Row.FindControl("lblSlot9Timing");
                lblSlot9Timing.Text = dtSlot.Rows[0]["SlotStart9"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd9"].ToString();

                Label lblSlot10Timing = (Label)e.Row.FindControl("lblSlot10Timing");
                lblSlot10Timing.Text = dtSlot.Rows[0]["SlotStart10"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd10"].ToString();

                Label lblSlot11Timing = (Label)e.Row.FindControl("lblSlot11Timing");
                lblSlot11Timing.Text = dtSlot.Rows[0]["SlotStart11"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd11"].ToString();

                Label lblSlot12Timing = (Label)e.Row.FindControl("lblSlot12Timing");
                lblSlot12Timing.Text = dtSlot.Rows[0]["SlotStart12"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd12"].ToString();

                Label lblSlot13Timing = (Label)e.Row.FindControl("lblSlot13Timing");
                lblSlot13Timing.Text = dtSlot.Rows[0]["SlotStart13"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd13"].ToString();

                Label lblSlot14Timing = (Label)e.Row.FindControl("lblSlot14Timing");
                lblSlot14Timing.Text = dtSlot.Rows[0]["SlotStart14"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd14"].ToString();

                Label lblSlot15Timing = (Label)e.Row.FindControl("lblSlot15Timing");
                lblSlot15Timing.Text = dtSlot.Rows[0]["SlotStart15"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd15"].ToString();

                Label lblSlot16Timing = (Label)e.Row.FindControl("lblSlot16Timing");
                lblSlot16Timing.Text = dtSlot.Rows[0]["SlotStart16"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd16"].ToString();


            }
        }

        protected void gvHourlyStitchingReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[22].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {

                    HtmlTableCell tdserialno = (HtmlTableCell)e.Row.FindControl("tdserialno");
                    HiddenField hdnserialColorCode = (HiddenField)e.Row.FindControl("hdnserialColorCode");
                    HtmlTableCell tdstcpty = (HtmlTableCell)e.Row.FindControl("tdstcpty");
                    HtmlTableCell tdFncpty = (HtmlTableCell)e.Row.FindControl("tdFncpty");

                    string ClientColorCode = DataBinder.Eval(e.Row.DataItem, "ClientColorCode").ToString();
                    if (ClientColorCode != "")
                    {
                        tdserialno.Style.Add(HtmlTextWriterStyle.BackgroundColor, ClientColorCode);
                    }

                    HiddenField hdnEmptyMsg = (HiddenField)e.Row.FindControl("hdnEmptyMsg");
                    Label lblUnit = (Label)e.Row.FindControl("lblUnit");

                    Label lblDay = (Label)e.Row.FindControl("lblDay");

                    Label lblOrderQty = (Label)e.Row.FindControl("lblOrderQty");
                    Label lblRescanQty = (Label)e.Row.FindControl("lblRescanQty");

                    Label lblFabQty = (Label)e.Row.FindControl("lblFabQty");
                    Label lblCutQty = (Label)e.Row.FindControl("lblCutQty");

                    Label lblStitchQty = (Label)e.Row.FindControl("lblStitchQty");
                    Label lblFinishQty = (Label)e.Row.FindControl("lblFinishQty");

                    Label lblOutHouseCutIssue = (Label)e.Row.FindControl("lblOutHouseCutIssue");
                    Label lblOutHouseStch = (Label)e.Row.FindControl("lblOutHouseStch");


                    Label lblLineNumber = (Label)e.Row.FindControl("lblLineNumber");
                    Label lblProdDay = (Label)e.Row.FindControl("lblProdDay");
                    Label lblCOT = (Label)e.Row.FindControl("lblCOT");


                    Label lblStchSAM = (Label)e.Row.FindControl("lblStchSAM");
                    Label lblStchActOB = (Label)e.Row.FindControl("lblStchActOB");
                    Label lblStchAgreedOB = (Label)e.Row.FindControl("lblStchAgreedOB");

                    Label lblStchPkCpty = (Label)e.Row.FindControl("lblStchPkCpty");
                    Label lblStchPkEff = (Label)e.Row.FindControl("lblStchPkEff");


                    Label lblwipCutPcs = (Label)e.Row.FindControl("lblwipCutPcs");
                    Label lblWIPStichedPcs = (Label)e.Row.FindControl("lblWIPStichedPcs");
                    Label lblWIPFinishedPcs = (Label)e.Row.FindControl("lblWIPFinishedPcs");
                    HtmlTableCell tdWIPStiched = (HtmlTableCell)e.Row.FindControl("tdWIPStiched");

                    HtmlTableCell dvWipF = (HtmlTableCell)e.Row.FindControl("dvWipF");

                    HtmlTableCell tdTodayEff = (HtmlTableCell)e.Row.FindControl("tdTodayEff");
                    Label lblTargetEff = (Label)e.Row.FindControl("lblTargetEff");
                    Label lblTodayEff_Stitch = (Label)e.Row.FindControl("lblTodayEff_Stitch");
                    Label lblStyleEff_Stitch = (Label)e.Row.FindControl("lblStyleEff_Stitch");
                    Label lblTotalDHU = (Label)e.Row.FindControl("lblTotalDHU");
                    Label lblTargetQty = (Label)e.Row.FindControl("lblTargetQty");
                    Label lblBreakEvenQty = (Label)e.Row.FindControl("lblBreakEvenQty");

                    // Finishing Section               
                    Label lblFinActOB = (Label)e.Row.FindControl("lblFinActOB");
                    Label lblFinPkCpty = (Label)e.Row.FindControl("lblFinPkCpty");
                    Label lblFinPressActualOB = (Label)e.Row.FindControl("lblFinPressActualOB");
                    Label lblTodayPassFinish = (Label)e.Row.FindControl("lblTodayPassFinish");
                    Label lblTodayPassStitch = (Label)e.Row.FindControl("lblTodayPassStitch");
                    Label lblStchAvgPcsHr = (Label)e.Row.FindControl("lblStchAvgPcsHr");
                    Label lblTodayAltPcs = (Label)e.Row.FindControl("lblTodayAltPcs");
                    Label lblTodayDHU = (Label)e.Row.FindControl("lblTodayDHU");

                    Label lblFinishAvgPcs = (Label)e.Row.FindControl("lblFinishAvgPcs");
                    Label lblPercentPerformance = (Label)e.Row.FindControl("lblPercentPerformance");
                    Label lblTodayAchieved = (Label)e.Row.FindControl("lblTodayAchieved");

                    Label lblSlot1Pass = (Label)e.Row.FindControl("lblSlot1Pass");
                    Label lblSlot2Pass = (Label)e.Row.FindControl("lblSlot2Pass");
                    Label lblSlot3Pass = (Label)e.Row.FindControl("lblSlot3Pass");
                    Label lblSlot4Pass = (Label)e.Row.FindControl("lblSlot4Pass");
                    Label lblSlot5Pass = (Label)e.Row.FindControl("lblSlot5Pass");
                    Label lblSlot6Pass = (Label)e.Row.FindControl("lblSlot6Pass");
                    Label lblSlot7Pass = (Label)e.Row.FindControl("lblSlot7Pass");
                    Label lblSlot8Pass = (Label)e.Row.FindControl("lblSlot8Pass");
                    Label lblSlot9Pass = (Label)e.Row.FindControl("lblSlot9Pass");
                    Label lblSlot10Pass = (Label)e.Row.FindControl("lblSlot10Pass");
                    Label lblSlot11Pass = (Label)e.Row.FindControl("lblSlot11Pass");
                    Label lblSlot12Pass = (Label)e.Row.FindControl("lblSlot12Pass");
                    Label lblSlot13Pass = (Label)e.Row.FindControl("lblSlot13Pass");
                    Label lblSlot14Pass = (Label)e.Row.FindControl("lblSlot14Pass");
                    Label lblSlot15Pass = (Label)e.Row.FindControl("lblSlot15Pass");
                    Label lblSlot16Pass = (Label)e.Row.FindControl("lblSlot16Pass");

                    Label lblSlot1DHU = (Label)e.Row.FindControl("lblSlot1DHU");
                    Label lblSlot2DHU = (Label)e.Row.FindControl("lblSlot2DHU");
                    Label lblSlot3DHU = (Label)e.Row.FindControl("lblSlot3DHU");
                    Label lblSlot4DHU = (Label)e.Row.FindControl("lblSlot4DHU");
                    Label lblSlot5DHU = (Label)e.Row.FindControl("lblSlot5DHU");
                    Label lblSlot6DHU = (Label)e.Row.FindControl("lblSlot6DHU");
                    Label lblSlot7DHU = (Label)e.Row.FindControl("lblSlot7DHU");
                    Label lblSlot8DHU = (Label)e.Row.FindControl("lblSlot8DHU");
                    Label lblSlot9DHU = (Label)e.Row.FindControl("lblSlot9DHU");
                    Label lblSlot10DHU = (Label)e.Row.FindControl("lblSlot10DHU");
                    Label lblSlot11DHU = (Label)e.Row.FindControl("lblSlot11DHU");
                    Label lblSlot12DHU = (Label)e.Row.FindControl("lblSlot12DHU");
                    Label lblSlot13DHU = (Label)e.Row.FindControl("lblSlot13DHU");
                    Label lblSlot14DHU = (Label)e.Row.FindControl("lblSlot14DHU");
                    Label lblSlot15DHU = (Label)e.Row.FindControl("lblSlot15DHU");
                    Label lblSlot16DHU = (Label)e.Row.FindControl("lblSlot16DHU");


                    //Add By Prabhaker on 30-Apr-18//

                    lblSlot1Pass.CssClass = "font-normal";
                    lblSlot2Pass.CssClass = "font-normal";
                    lblSlot3Pass.CssClass = "font-normal";
                    lblSlot4Pass.CssClass = "font-normal";
                    lblSlot5Pass.CssClass = "font-normal";
                    lblSlot6Pass.CssClass = "font-normal";
                    lblSlot7Pass.CssClass = "font-normal";
                    lblSlot8Pass.CssClass = "font-normal";
                    lblSlot9Pass.CssClass = "font-normal";
                    lblSlot10Pass.CssClass = "font-normal";
                    lblSlot11Pass.CssClass = "font-normal";
                    lblSlot12Pass.CssClass = "font-normal";
                    lblSlot13Pass.CssClass = "font-normal";
                    lblSlot14Pass.CssClass = "font-normal";
                    lblSlot15Pass.CssClass = "font-normal";
                    lblSlot16Pass.CssClass = "font-normal";

                    CheckBox ChkLoadStitch = (CheckBox)e.Row.FindControl("ChkLoadStitch");
                    HtmlTable tblEffHide = (HtmlTable)e.Row.FindControl("tblEffHide");

                    tblEffHide.Visible = true;
                    HtmlTable tblEffShow = (HtmlTable)e.Row.FindControl("tblEffShow");
                    e.Row.Cells[22].Visible = false;

                    HiddenField hdnImgStyle = (HiddenField)e.Row.FindControl("hdnImgStyle");
                    HtmlImage imgStyle = (HtmlImage)e.Row.FindControl("imgStyle");
                    imgStyle.Src = "/uploads/style/thumb-" + hdnImgStyle.Value;

                    tblEffShow.Visible = false;
                    lblUnit.Visible = false;
                    UnitId = DataBinder.Eval(e.Row.DataItem, "UnitID") == DBNull.Value ? -1 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UnitID"));
                    int Line_No = DataBinder.Eval(e.Row.DataItem, "Line_No") == DBNull.Value ? -1 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Line_No"));
                    int IsCluster = DataBinder.Eval(e.Row.DataItem, "IsCluster") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "IsCluster"));
                    int ClusterId = DataBinder.Eval(e.Row.DataItem, "ClusterId") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ClusterId"));
                    string ClusterName = DataBinder.Eval(e.Row.DataItem, "ClusterName") == DBNull.Value ? "" : DataBinder.Eval(e.Row.DataItem, "ClusterName").ToString();
                    // WIP SECTION
                    double WIPCutting = DataBinder.Eval(e.Row.DataItem, "WIPCutting") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WIPCutting"));
                    double WIPStiched = DataBinder.Eval(e.Row.DataItem, "WIPStitching") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WIPStitching"));
                    double WIPFinished = DataBinder.Eval(e.Row.DataItem, "WIPFinished") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WIPFinished"));

                    double WIPCutQty_InProgress = DataBinder.Eval(e.Row.DataItem, "WIPCutQty_InProgress") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WIPCutQty_InProgress"));
                    double WIPStitchQty_InProgress = DataBinder.Eval(e.Row.DataItem, "WIPStitchQty_InProgress") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WIPStitchQty_InProgress"));
                    double WIPFinishQty_InProgress = DataBinder.Eval(e.Row.DataItem, "WIPFinishQty_InProgress") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WIPFinishQty_InProgress"));

                    TotalTodayFinishObatLineCluster = DataBinder.Eval(e.Row.DataItem, "TotalTodayFinishObatLineCluster") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalTodayFinishObatLineCluster"));

                    //----------------------------------------------------  STITCH SECTION ---------------------------------------------------------------------

                    int TodayPassPcsStitch = DataBinder.Eval(e.Row.DataItem, "TodayPassPcsStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayPassPcsStitch"));

                    double StitchSAM = DataBinder.Eval(e.Row.DataItem, "StitchSAM") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "StitchSAM"));
                    int StitchActualOB = DataBinder.Eval(e.Row.DataItem, "StitchActualOB") == DBNull.Value ? -1 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StitchActualOB"));
                    int StitchOB = DataBinder.Eval(e.Row.DataItem, "StitchOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StitchOB"));

                    int PeakCapecity = DataBinder.Eval(e.Row.DataItem, "PeakCapecity") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakCapecity"));
                    int PeakOB = DataBinder.Eval(e.Row.DataItem, "PeakOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakOB"));
                    int COT = DataBinder.Eval(e.Row.DataItem, "COTValue") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COTValue"));

                    int PeakEff = DataBinder.Eval(e.Row.DataItem, "PeakEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakEff"));
                    int StitchQty = DataBinder.Eval(e.Row.DataItem, "TotalStitchedQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalStitchedQty"));

                    int TodayAltPcs = DataBinder.Eval(e.Row.DataItem, "TodayAltPcs") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayAltPcs"));
                    int TodayDHU = DataBinder.Eval(e.Row.DataItem, "DHU_Today") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DHU_Today"));
                    int StchAvgPcs = DataBinder.Eval(e.Row.DataItem, "TodayAvgStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayAvgStitch"));

                    int TargetEff = DataBinder.Eval(e.Row.DataItem, "TargetEfficiency") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetEfficiency"));
                    int TargetQty = DataBinder.Eval(e.Row.DataItem, "TargetQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetQty"));
                    int TodayEfficiency_Stitch = DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Stitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Stitch"));

                    int StyleEfficiency_Stitch = DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Stitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Stitch"));
                    int BreakEvenQty = DataBinder.Eval(e.Row.DataItem, "BreakEvenQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BreakEvenQty"));
                    int ProdDay = DataBinder.Eval(e.Row.DataItem, "ProdDay") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ProdDay"));

                    int TodayAchievement = DataBinder.Eval(e.Row.DataItem, "TodayAchievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayAchievement"));

                    int ReScanPendingQty = DataBinder.Eval(e.Row.DataItem, "ReScanPendingQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ReScanPendingQty"));
                    int OutHouseCutIssue = DataBinder.Eval(e.Row.DataItem, "OutHouseCutIssue") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OutHouseCutIssue"));
                    int OutHouseStitch = DataBinder.Eval(e.Row.DataItem, "OutHouseStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OutHouseStitch"));


                    if (IsCluster != 0)
                    {
                        lblLineNumber.Text = "";
                        if (ClusterName != "")
                            lblProdDay.Text = ClusterName;
                        else
                            lblProdDay.Text = "(C " + ClusterId.ToString() + ")";

                        lblCOT.Text = "";
                    }
                    else
                    {
                        lblProdDay.Text = "(D " + lblProdDay.Text + ")";
                    }

                    if (StitchQty > 999)
                    {
                        double StitchQtyNew = Math.Round(Convert.ToDouble(StitchQty) / 1000, 1);
                        if (StitchQtyNew > 99.9)
                        {
                            lblStitchQty.Text = Math.Round(StitchQtyNew, 0).ToString() + "k";
                        }
                        else
                        {
                            lblStitchQty.Text = StitchQtyNew.ToString() + "k";
                        }
                    }
                    else
                    {
                        lblStitchQty.Text = StitchQty == 0 ? "" : StitchQty.ToString("#,##0");
                    }

                    if (OutHouseCutIssue > 999)
                    {
                        double OutHouseCutIssueNew = Math.Round(Convert.ToDouble(OutHouseCutIssue) / 1000, 1);
                        if (OutHouseCutIssueNew > 99.9)
                        {
                            lblOutHouseCutIssue.Text = Math.Round(OutHouseCutIssueNew, 0).ToString() + "k";
                        }
                        else
                        {
                            lblOutHouseCutIssue.Text = OutHouseCutIssueNew.ToString() + "k";
                        }
                    }
                    else
                    {
                        lblOutHouseCutIssue.Text = OutHouseCutIssue == 0 ? "" : OutHouseCutIssue.ToString("#,##0");
                    }

                    if (OutHouseStitch > 999)
                    {
                        double OutHouseStitchNew = Math.Round(Convert.ToDouble(OutHouseStitch) / 1000, 1);
                        if (OutHouseStitchNew > 99.9)
                        {
                            lblOutHouseStch.Text = "(" + Math.Round(OutHouseStitchNew, 0).ToString() + "k)";
                        }
                        else
                        {
                            lblOutHouseStch.Text = "(" + OutHouseStitchNew.ToString() + "k)";
                        }
                    }
                    else
                    {
                        lblOutHouseStch.Text = OutHouseStitch == 0 ? "" : "(" + OutHouseStitch.ToString("#,##0") + ")";
                    }

                    lblCOT.Text = COT == 0 ? "" : COT.ToString();

                    if (PeakCapecity == 0)
                    {
                        if (IsCluster == 0)
                        {
                            lblStchPkCpty.Text = "Cpty msng";
                            lblStchPkCpty.Style.Add("color", "red");
                            lblStchPkCpty.Style.Add("font-weight", "bold");
                        }
                    }
                    else
                    {
                        if (PeakCapecity > 999)
                        {
                            double PeakCapecityNew = Math.Round(Convert.ToDouble(PeakCapecity) / 1000, 1);
                            if (PeakCapecityNew > 99.9)
                            {
                                PeakCapecityNew = Math.Round(PeakCapecityNew, 0);
                                lblStchPkCpty.Text = PeakCapecityNew.ToString() + "k Pcs";
                            }
                            else
                            {
                                lblStchPkCpty.Text = PeakCapecityNew.ToString() + "k Pcs";
                            }
                        }
                        else
                        {
                            lblStchPkCpty.Text = PeakCapecity.ToString("#,##0") + " Pcs";
                        }
                        lblStchPkCpty.Style.Add("color", "gray");
                    }

                    lblStchPkEff.Text = PeakEff == 0 ? "" : "(" + PeakEff.ToString() + "%)";
                    lblStchSAM.Text = StitchSAM == 0 ? "" : StitchSAM.ToString();
                    lblStchActOB.Text = StitchActualOB <= 0 ? "" : StitchActualOB.ToString();

                    if (PeakOB != 0)
                    {
                        lblStchAgreedOB.Text = PeakOB == 0 ? "" : "(" + PeakOB.ToString() + ")";
                        lblStchAgreedOB.Style.Add("color", "blue");
                        StitchOB_Factory = StitchOB_Factory + PeakOB;
                        if (StitchActualOB <= PeakOB)
                            lblStchActOB.Style.Add("color", "green");
                        else
                            lblStchActOB.Style.Add("color", "red");
                    }
                    else
                    {
                        lblStchAgreedOB.Style.Add("color", "black");
                        lblStchAgreedOB.Text = StitchOB == 0 ? "" : "(" + StitchOB.ToString() + ")";

                        StitchOB_Factory = StitchOB_Factory + StitchOB;

                        if (StitchActualOB <= StitchOB)
                            lblStchActOB.Style.Add("color", "green");
                        else
                            lblStchActOB.Style.Add("color", "red");
                    }


                    if (TodayPassPcsStitch > 999)
                    {
                        double TodayPassPcsStitchNew = Math.Round(Convert.ToDouble(TodayPassPcsStitch) / 1000, 1);
                        if (TodayPassPcsStitchNew > 99.9)
                            lblTodayPassStitch.Text = Math.Round(TodayPassPcsStitchNew, 0).ToString() + "k";
                        else
                            lblTodayPassStitch.Text = TodayPassPcsStitchNew.ToString() + "k";
                    }
                    else
                    {
                        lblTodayPassStitch.Text = TodayPassPcsStitch == 0 ? "" : TodayPassPcsStitch.ToString("#,##0");
                    }
                    lblTodayAltPcs.Text = TodayAltPcs == 0 ? "" : TodayAltPcs.ToString("#,##0");
                    lblTodayDHU.Text = TodayDHU == 0 ? "" : TodayDHU.ToString() + "%";


                    lblTodayAchieved.Text = TodayAchievement == 0 ? "" : TodayAchievement.ToString() + "%";
                    if (TodayAchievement > 0 && TodayAchievement < 81)
                    {
                        lblTodayAchieved.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblTodayAchieved.ForeColor = Color.Green;
                    }
                    if (StchAvgPcs > 999)
                    {
                        double StchAvgPcsNew = Math.Round(Convert.ToDouble(StchAvgPcs) / 1000, 1);
                        if (StchAvgPcsNew > 99.9)
                        {
                            lblStchAvgPcsHr.Text = "(" + Math.Round(StchAvgPcsNew, 0).ToString() + "k pphr)";
                        }
                        else
                        {
                            lblStchAvgPcsHr.Text = "(" + StchAvgPcsNew.ToString() + "k pphr)";
                        }
                    }
                    else
                    {
                        lblStchAvgPcsHr.Text = StchAvgPcs == 0 ? "" : "(" + StchAvgPcs.ToString("#,##0") + " pphr)";
                    }

                    lblTargetEff.Text = TargetEff > 0 ? TargetEff + "%" : "";
                    lblTodayEff_Stitch.Text = TodayEfficiency_Stitch > 0 ? TodayEfficiency_Stitch + "%" : "";
                    lblStyleEff_Stitch.Text = StyleEfficiency_Stitch > 0 ? "(" + StyleEfficiency_Stitch + "%)" : "";

                    if (TargetQty > 999)
                    {
                        double TargetQtyNew = Math.Round(Convert.ToDouble(TargetQty) / 1000, 1);
                        if (TargetQtyNew > 99.9)
                        {
                            lblTargetQty.Text = Math.Round(TargetQtyNew, 0).ToString() + "k Pcs";
                        }
                        else
                        {
                            lblTargetQty.Text = TargetQtyNew.ToString() + "k Pcs";
                        }
                    }
                    else
                    {
                        lblTargetQty.Text = TargetQty > 0 ? TargetQty.ToString() + " Pcs" : "";
                    }
                    HtmlTableCell tdTargetQty = (HtmlTableCell)e.Row.FindControl("tdTargetQty");
                    if (BreakEvenQty > 0)
                    {
                        tdTargetQty.Style.Add("background-color", "#90EE90");
                        if (BreakEvenQty > 999)
                        {
                            Double BreakEvenQtyNew = Math.Round(Convert.ToDouble(BreakEvenQty) / 1000, 1);
                            if (BreakEvenQtyNew > 99.9)
                            {
                                lblBreakEvenQty.Text = Math.Round(BreakEvenQtyNew, 0).ToString() + "k Pcs";
                            }
                            else
                            {
                                lblBreakEvenQty.Text = BreakEvenQtyNew.ToString() + " Pcs";
                            }
                        }
                        else
                        {
                            lblBreakEvenQty.Text = BreakEvenQty.ToString() + " Pcs";
                        }
                    }
                    if (BreakEvenQty <= StchAvgPcs)
                    {
                        lblBreakEvenQty.Style.Add("color", "green");
                    }
                    else
                    {
                        lblBreakEvenQty.Style.Add("color", "#FF0000");
                    }

                    SlotId = Convert.ToInt32(hdnSlotId.Value);
                    StyleCode = DataBinder.Eval(e.Row.DataItem, "StyleCode").ToString();

                    int PlanStyleId = DataBinder.Eval(e.Row.DataItem, "StyleId") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StyleId"));
                    int LinePlanFrameId = DataBinder.Eval(e.Row.DataItem, "LinePlanFrameId") == DBNull.Value ? -1 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LinePlanFrameId"));

                    if (TargetQty > 0)
                    {
                        if (Math.Round((Convert.ToDouble(StchAvgPcs) / Convert.ToDouble(TargetQty)) * 100, 0) > 85)
                        {
                            lblTodayPassStitch.Style.Add("color", "green");
                            lblTodayEff_Stitch.Style.Add("color", "green");
                        }
                        else
                        {
                            lblTodayPassStitch.Style.Add("color", "#FF0000");
                            lblTodayEff_Stitch.Style.Add("color", "#FF0000");
                        }
                    }
                    else
                    {
                        lblTodayPassStitch.Style.Add("color", "Black");
                        lblTodayEff_Stitch.Style.Add("color", "Black");
                    }

                    if (TodayDHU > 5)
                        lblTodayAltPcs.Style.Add("color", "#FF0000");

                    else if (TodayDHU <= 5)
                        lblTodayAltPcs.Style.Add("color", "green");


                    if (lblSlot1Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot1Pass.Text) > 999)
                        {
                            lblSlot1Pass.Text = Math.Round(Convert.ToDouble(lblSlot1Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot1Pass.Text = lblSlot1Pass.Text == "0" ? "" : lblSlot1Pass.Text;
                        }
                    }
                    if (lblSlot2Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot2Pass.Text) > 999)
                        {
                            lblSlot2Pass.Text = Math.Round(Convert.ToDouble(lblSlot2Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot2Pass.Text = lblSlot2Pass.Text == "0" ? "" : lblSlot2Pass.Text;
                        }
                    }
                    if (lblSlot3Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot3Pass.Text) > 999)
                        {
                            lblSlot3Pass.Text = Math.Round(Convert.ToDouble(lblSlot3Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot3Pass.Text = lblSlot3Pass.Text == "0" ? "" : lblSlot3Pass.Text;
                        }
                    }
                    if (lblSlot4Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot4Pass.Text) > 999)
                        {
                            lblSlot4Pass.Text = Math.Round(Convert.ToDouble(lblSlot4Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot4Pass.Text = lblSlot4Pass.Text == "0" ? "" : lblSlot4Pass.Text;
                        }
                    }
                    if (lblSlot5Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot5Pass.Text) > 999)
                        {
                            lblSlot5Pass.Text = Math.Round(Convert.ToDouble(lblSlot5Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot5Pass.Text = lblSlot5Pass.Text == "0" ? "" : lblSlot5Pass.Text;
                        }
                    }
                    if (lblSlot6Pass.Text != "")
                    {

                        if (Convert.ToDouble(lblSlot6Pass.Text) > 999)
                        {
                            lblSlot6Pass.Text = Math.Round(Convert.ToDouble(lblSlot6Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot6Pass.Text = lblSlot6Pass.Text == "0" ? "" : lblSlot6Pass.Text;
                        }
                    }
                    if (lblSlot7Pass.Text != "")
                    {

                        if (Convert.ToDouble(lblSlot7Pass.Text) > 999)
                        {
                            lblSlot7Pass.Text = Math.Round(Convert.ToDouble(lblSlot7Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot7Pass.Text = lblSlot7Pass.Text == "0" ? "" : lblSlot7Pass.Text;
                        }
                    }
                    if (lblSlot8Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot8Pass.Text) > 999)
                        {
                            lblSlot8Pass.Text = Math.Round(Convert.ToDouble(lblSlot8Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot8Pass.Text = lblSlot8Pass.Text == "0" ? "" : lblSlot8Pass.Text;
                        }
                    }
                    if (lblSlot9Pass.Text != "")
                    {

                        if (Convert.ToDouble(lblSlot9Pass.Text) > 999)
                        {
                            lblSlot9Pass.Text = Math.Round(Convert.ToDouble(lblSlot9Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot9Pass.Text = lblSlot9Pass.Text == "0" ? "" : lblSlot9Pass.Text;
                        }
                    }
                    if (lblSlot10Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot10Pass.Text) > 999)
                        {
                            lblSlot10Pass.Text = Math.Round(Convert.ToDouble(lblSlot10Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot10Pass.Text = lblSlot10Pass.Text == "0" ? "" : lblSlot10Pass.Text;
                        }
                    }
                    if (lblSlot11Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot11Pass.Text) > 999)
                        {
                            lblSlot11Pass.Text = Math.Round(Convert.ToDouble(lblSlot11Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot11Pass.Text = lblSlot11Pass.Text == "0" ? "" : lblSlot11Pass.Text;
                        }
                    }
                    if (lblSlot12Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot12Pass.Text) > 999)
                        {
                            lblSlot12Pass.Text = Math.Round(Convert.ToDouble(lblSlot12Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot12Pass.Text = lblSlot12Pass.Text == "0" ? "" : lblSlot12Pass.Text;
                        }
                    }
                    if (lblSlot13Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot13Pass.Text) > 999)
                        {
                            lblSlot13Pass.Text = Math.Round(Convert.ToDouble(lblSlot13Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot13Pass.Text = lblSlot13Pass.Text == "0" ? "" : lblSlot13Pass.Text;
                        }
                    }
                    if (lblSlot14Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot14Pass.Text) > 999)
                        {
                            lblSlot14Pass.Text = Math.Round(Convert.ToDouble(lblSlot14Pass.Text) / 1000, 1).ToString() + "k";
                        }

                        else
                        {
                            lblSlot14Pass.Text = lblSlot10Pass.Text == "0" ? "" : lblSlot14Pass.Text;
                        }
                    }
                    if (lblSlot15Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot15Pass.Text) > 999)
                        {
                            lblSlot15Pass.Text = Math.Round(Convert.ToDouble(lblSlot15Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot15Pass.Text = lblSlot15Pass.Text == "0" ? "" : lblSlot15Pass.Text;
                        }
                    }
                    if (lblSlot16Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot16Pass.Text) > 999)
                        {
                            lblSlot16Pass.Text = Math.Round(Convert.ToDouble(lblSlot16Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot16Pass.Text = lblSlot16Pass.Text == "0" ? "" : lblSlot16Pass.Text;
                        }
                    }

                    lblSlot1DHU.Text = lblSlot1DHU.Text == "0" ? "" : lblSlot1DHU.Text + " %";
                    lblSlot2DHU.Text = lblSlot2DHU.Text == "0" ? "" : lblSlot2DHU.Text + " %";
                    lblSlot3DHU.Text = lblSlot3DHU.Text == "0" ? "" : lblSlot3DHU.Text + " %";
                    lblSlot4DHU.Text = lblSlot4DHU.Text == "0" ? "" : lblSlot4DHU.Text + " %";
                    lblSlot5DHU.Text = lblSlot5DHU.Text == "0" ? "" : lblSlot5DHU.Text + " %";
                    lblSlot6DHU.Text = lblSlot6DHU.Text == "0" ? "" : lblSlot6DHU.Text + " %";
                    lblSlot7DHU.Text = lblSlot7DHU.Text == "0" ? "" : lblSlot7DHU.Text + " %";
                    lblSlot8DHU.Text = lblSlot8DHU.Text == "0" ? "" : lblSlot8DHU.Text + " %";
                    lblSlot9DHU.Text = lblSlot9DHU.Text == "0" ? "" : lblSlot9DHU.Text + " %";
                    lblSlot10DHU.Text = lblSlot10DHU.Text == "0" ? "" : lblSlot10DHU.Text + " %";
                    lblSlot11DHU.Text = lblSlot11DHU.Text == "0" ? "" : lblSlot11DHU.Text + " %";
                    lblSlot12DHU.Text = lblSlot12DHU.Text == "0" ? "" : lblSlot12DHU.Text + " %";
                    lblSlot13DHU.Text = lblSlot13DHU.Text == "0" ? "" : lblSlot13DHU.Text + " %";
                    lblSlot14DHU.Text = lblSlot14DHU.Text == "0" ? "" : lblSlot14DHU.Text + " %";
                    lblSlot15DHU.Text = lblSlot15DHU.Text == "0" ? "" : lblSlot15DHU.Text + " %";
                    lblSlot16DHU.Text = lblSlot16DHU.Text == "0" ? "" : lblSlot16DHU.Text + " %";

                    //----------------------------------------------------  FINISH SECTION ---------------------------------------------------------------------

                    int FinishActualOB = DataBinder.Eval(e.Row.DataItem, "FinishActualOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FinishActualOB"));
                    int FinishOB = DataBinder.Eval(e.Row.DataItem, "FinishOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FinishOB"));

                    int PeakCapcty_Finish = DataBinder.Eval(e.Row.DataItem, "PeakCapcty_Finish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakCapcty_Finish"));
                    int PeakOB_Finish = DataBinder.Eval(e.Row.DataItem, "PeakOB_Finish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakOB_Finish"));
                    int PeakEff_Finish = DataBinder.Eval(e.Row.DataItem, "PeakEff_Finish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakEff_Finish"));

                    int TCActualOB = DataBinder.Eval(e.Row.DataItem, "TCActualOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TCActualOB"));
                    int TCPeakOB = DataBinder.Eval(e.Row.DataItem, "TCPeakOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TCPeakOB"));
                    int TCCapcty = DataBinder.Eval(e.Row.DataItem, "TCCapcty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TCCapcty"));

                    int PressCapcty = DataBinder.Eval(e.Row.DataItem, "PressCapcty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PressCapcty"));
                    int PressPeakOB = DataBinder.Eval(e.Row.DataItem, "PressPeakOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PressPeakOB"));
                    int PressActualOB = DataBinder.Eval(e.Row.DataItem, "PressActualOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PressActualOB"));

                    int OrderQty = DataBinder.Eval(e.Row.DataItem, "OrderQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OrderQty"));
                    int TodayPassFinish = DataBinder.Eval(e.Row.DataItem, "TodayPassPcsFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayPassPcsFinish"));

                    int FabricQty = DataBinder.Eval(e.Row.DataItem, "FabricQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FabricQty"));
                    int CutQty = DataBinder.Eval(e.Row.DataItem, "CutQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CutQty"));
                    int FinishAvgPcs = DataBinder.Eval(e.Row.DataItem, "TodayAvgFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayAvgFinish"));
                    int PercentPerformance = DataBinder.Eval(e.Row.DataItem, "PercentPerformance") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PercentPerformance"));

                    int FinishQty = DataBinder.Eval(e.Row.DataItem, "TotalFinishQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalFinishQty"));

                    if (TodayPassFinish > 999)
                    {
                        double TodayPassFinishNew = Math.Round(Convert.ToDouble(TodayPassFinish) / 1000, 1);
                        if (TodayPassFinishNew > 99.9)
                        {
                            lblTodayPassFinish.Text = Math.Round(TodayPassFinishNew, 0).ToString() + "k";
                        }
                        else
                        {
                            lblTodayPassFinish.Text = TodayPassFinishNew.ToString() + "k";
                        }
                    }
                    else
                    {
                        lblTodayPassFinish.Text = TodayPassFinish == 0 ? "" : TodayPassFinish.ToString("#,##0");
                    }

                    if (FinishQty > 999)
                    {
                        double FinishQtyNew = Math.Round(Convert.ToDouble(FinishQty) / 1000, 1);
                        if (FinishQtyNew > 99.9)
                        {
                            lblFinishQty.Text = "(" + Math.Round(FinishQtyNew, 0).ToString() + "k)";
                        }
                        else
                        {
                            lblFinishQty.Text = "(" + FinishQtyNew.ToString() + "k)";
                        }
                    }
                    else
                    {
                        lblFinishQty.Text = FinishQty == 0 ? "" : "(" + FinishQty.ToString("#,##0") + ")";
                    }

                    if (PressActualOB != 0)
                    {
                        lblFinPressActualOB.Text = PressActualOB == 0 ? "" : "(" + PressActualOB.ToString() + ")";
                    }
                    if (PeakOB_Finish != 0)
                    {

                        if (FinishActualOB <= PeakOB_Finish)
                            lblFinActOB.Style.Add("color", "green");
                        else
                            lblFinActOB.Style.Add("color", "red");
                    }
                    else
                    {

                        if (FinishActualOB <= FinishOB)
                            lblFinActOB.Style.Add("color", "green");
                        else
                            lblFinActOB.Style.Add("color", "red");
                    }

                    if (PeakCapcty_Finish == 0)
                    {
                        lblFinPkCpty.Text = "Cpty msng";
                        lblFinPkCpty.Style.Add("color", "red");
                        lblFinPkCpty.Style.Add("font-weight", "bold");

                    }
                    else
                    {
                        if (PeakCapcty_Finish > 999)
                        {
                            double PeakCapcty_FinishNew = Math.Round(Convert.ToDouble(PeakCapcty_Finish) / 1000, 1);
                            if (PeakCapcty_FinishNew > 99.9)
                            {
                                lblFinPkCpty.Text = Math.Round(PeakCapcty_FinishNew, 0).ToString() + "k Pcs";
                            }
                            else
                            {
                                lblFinPkCpty.Text = PeakCapcty_FinishNew.ToString() + "k Pcs";
                            }
                        }
                        else
                        {
                            lblFinPkCpty.Text = PeakCapcty_Finish.ToString("#,##0") + " Pcs";
                        }
                        lblFinPkCpty.Style.Add("color", "gray");
                    }

                    lblFinActOB.Text = FinishActualOB == 0 ? "" : FinishActualOB.ToString();

                    Label lblFinishCost = (Label)e.Row.FindControl("lblFinishCost");
                    HtmlControl tdFinishCost = (HtmlControl)e.Row.FindControl("tdFinishCost");
                    if (TotalTodayFinishObatLineCluster > 0 && FinishAvgPcs > 0 && TodayPassFinish > 0)
                    {
                        lblFinishCost.Text = "&#8377;" + Math.Round(((Convert.ToDouble(TotalTodayFinishObatLineCluster) * FinishingPerOBCost) / Convert.ToDouble(TodayPassFinish)), 0).ToString();
                        if (Math.Round(((Convert.ToDouble(TotalTodayFinishObatLineCluster) * FinishingPerOBCost) / Convert.ToDouble(TodayPassFinish)), 0) <= 10)
                        {
                            lblFinishCost.Style.Add("color", "green");
                        }
                        else
                        {
                            lblFinishCost.Style.Add("color", "#FF0000");
                        }
                        if (Math.Round((Convert.ToDouble(TotalTodayFinishObatLineCluster) * FinishingPerOBCost) / Convert.ToDouble(TodayPassFinish), 0) <= 12)
                        {
                            lblTodayPassFinish.Style.Add("color", "green");
                        }
                        else
                        {
                            lblTodayPassFinish.Style.Add("color", "#FF0000");
                        }
                    }
                    else
                    {
                        lblTodayPassFinish.Style.Add("color", "Black");
                    }

                    lblwipCutPcs.Text = WIPCutQty_InProgress <= 0 ? "" : WIPCutQty_InProgress + "k";
                    lblWIPStichedPcs.Text = WIPStitchQty_InProgress <= 0 ? "" : WIPStitchQty_InProgress + "k";
                    lblWIPFinishedPcs.Text = WIPFinishQty_InProgress <= 0 ? "" : WIPFinishQty_InProgress + "k";

                    if ((WIPStitchQty_InProgress > 0) && (StchAvgPcs > 0))
                    {
                        double StitchWipInProgress = WIPStitchQty_InProgress * 1000;
                        if ((StitchWipInProgress / Convert.ToDouble(StchAvgPcs)) > 33)
                            tdWIPStiched.Style.Add("background-color", "green");
                        else
                            tdWIPStiched.Style.Add("background-color", "#FF0000");
                    }
                    else if ((WIPStitchQty_InProgress > 0) && (StchAvgPcs <= 0))
                        tdWIPStiched.Style.Add("background-color", "green");

                    else if ((WIPStitchQty_InProgress <= 0) && (StchAvgPcs > 0))
                        tdWIPStiched.Style.Add("background-color", "#FF0000");

                    if (FabricQty > 999)
                    {
                        double fabricQtyNew;
                        fabricQtyNew = Math.Round(Convert.ToDouble(FabricQty) / 1000, 1);
                        if (fabricQtyNew > 99.9)
                        {
                            lblFabQty.Text = Math.Round(fabricQtyNew, 0).ToString() + "k";
                        }
                        else
                        {
                            lblFabQty.Text = fabricQtyNew.ToString() + "k";
                        }
                    }
                    else
                    {
                        lblFabQty.Text = FabricQty == 0 ? "" : FabricQty.ToString("#,##0");
                    }
                    if (CutQty > 999)
                    {
                        double CutQtyNew = Math.Round(Convert.ToDouble(CutQty) / 1000, 1);
                        if (CutQtyNew > 99.9)
                        {
                            lblCutQty.Text = "(" + Math.Round(CutQtyNew, 0).ToString() + "k)";
                        }
                        else
                        {
                            lblCutQty.Text = "(" + CutQtyNew.ToString() + "k)";
                        }
                    }
                    else
                    {
                        lblCutQty.Text = CutQty == 0 ? "" : "(" + CutQty.ToString("#,##0") + ")";  //updated rsb
                    }

                    if (OrderQty > 999)
                    {
                        double OrderQtyNew = Math.Round(Convert.ToDouble(OrderQty) / 1000, 1);
                        if (OrderQtyNew > 99.9)
                        {
                            lblOrderQty.Text = Math.Round(OrderQtyNew, 0).ToString() + "k";
                        }
                        else
                        {
                            lblOrderQty.Text = OrderQtyNew.ToString() + "k";
                        }
                    }
                    else
                    {
                        lblOrderQty.Text = OrderQty == 0 ? "" : OrderQty.ToString("#,##0");  //updated rsb
                    }

                    if (ReScanPendingQty > 999)
                    {
                        double ReScanPendingQtyNew = Math.Round(Convert.ToDouble(ReScanPendingQty) / 1000, 1);
                        if (ReScanPendingQtyNew > 99.9)
                        {
                            lblRescanQty.Text = "(" + Math.Round(ReScanPendingQtyNew, 0).ToString() + "k)";
                        }
                        else
                        {
                            lblRescanQty.Text = "(" + ReScanPendingQtyNew.ToString() + "k)";
                        }
                    }
                    else
                    {
                        lblRescanQty.Text = ReScanPendingQty == 0 ? "" : "(" + ReScanPendingQty.ToString("#,##0") + ")";  //updated rsb
                    }

                    if (FinishAvgPcs > 999)
                    {
                        Double FinishAvgPcsNew = Math.Round(Convert.ToDouble(FinishAvgPcs) / 1000, 1);
                        if (FinishAvgPcsNew > 99.9)
                        {
                            lblFinishAvgPcs.Text = "(" + Math.Round(FinishAvgPcsNew, 0).ToString() + "k pphr)";
                        }
                        else
                        {
                            lblFinishAvgPcs.Text = "(" + FinishAvgPcsNew.ToString() + "k Pphr)";
                        }
                    }
                    else
                    {
                        lblFinishAvgPcs.Text = FinishAvgPcs == 0 ? "" : "(" + FinishAvgPcs.ToString("#,##0") + " pphr)";  // updated rsb
                    }
                    lblPercentPerformance.Text = PercentPerformance == 0 ? "" : PercentPerformance.ToString() + "%";
                    if (PercentPerformance <= 85)
                        lblPercentPerformance.Style.Add("color", "Red");
                    else
                        lblPercentPerformance.Style.Add("color", "green");

                    double OrderQty_With5Percent = Math.Round(Convert.ToDouble(OrderQty) + (Convert.ToDouble(OrderQty) * 5) / 100, 0);
                    if (Convert.ToDouble(CutQty) > OrderQty_With5Percent)
                        lblCutQty.Style.Add("color", "red");
                    else
                        lblCutQty.Style.Add("color", "black");

                    if (Convert.ToDouble(FabricQty) > OrderQty_With5Percent)
                        lblFabQty.Style.Add("color", "red");
                    else
                        lblFabQty.Style.Add("color", "black");

                    if ((UnitId != -1) && (UnitId != 0))
                    {
                        if ((ViewState["dtTargetQty"] != null) && (PlanStyleId > 0))
                        {
                            DataTable dtTargetQty = (DataTable)ViewState["dtTargetQty"];
                            int SlotTargetQty = 0, SlotPass = 0;

                            for (int icount = 1; icount <= SlotId; icount++)
                            {
                                SlotTargetQty = (from r in dtTargetQty.AsEnumerable()
                                                 where r.Field<string>("StyleCode") == StyleCode &&
                                                 r.Field<int>("LinePlanFrameId") == LinePlanFrameId &&
                                                 r.Field<int>("Line_No") == Line_No &&
                                                 r.Field<int>("UnitId") == UnitId
                                                 select r.Field<int>("Slot" + icount + "TargetQty")).First<int>();
                                if (icount == 1)
                                    Slot1TargetQty = Slot1TargetQty + SlotTargetQty;
                                if (icount == 2)
                                    Slot2TargetQty = Slot2TargetQty + SlotTargetQty;
                                if (icount == 3)
                                    Slot3TargetQty = Slot3TargetQty + SlotTargetQty;
                                if (icount == 4)
                                    Slot4TargetQty = Slot4TargetQty + SlotTargetQty;
                                if (icount == 5)
                                    Slot5TargetQty = Slot5TargetQty + SlotTargetQty;
                                if (icount == 6)
                                    Slot6TargetQty = Slot6TargetQty + SlotTargetQty;
                                if (icount == 7)
                                    Slot7TargetQty = Slot7TargetQty + SlotTargetQty;
                                if (icount == 8)
                                    Slot8TargetQty = Slot8TargetQty + SlotTargetQty;
                                if (icount == 9)
                                    Slot9TargetQty = Slot9TargetQty + SlotTargetQty;
                                if (icount == 10)
                                    Slot10TargetQty = Slot10TargetQty + SlotTargetQty;
                                if (icount == 11)
                                    Slot11TargetQty = Slot11TargetQty + SlotTargetQty;
                                if (icount == 12)
                                    Slot12TargetQty = Slot12TargetQty + SlotTargetQty;
                                if (icount == 13)
                                    Slot13TargetQty = Slot13TargetQty + SlotTargetQty;
                                if (icount == 14)
                                    Slot14TargetQty = Slot14TargetQty + SlotTargetQty;
                                if (icount == 15)
                                    Slot15TargetQty = Slot15TargetQty + SlotTargetQty;
                                if (icount == 16)
                                    Slot16TargetQty = Slot16TargetQty + SlotTargetQty;

                                if (SlotTargetQty > 0)
                                {
                                    HtmlTableCell tdSlotPass = (HtmlTableCell)e.Row.FindControl("tdSlot" + icount + "Pass");
                                    SlotPass = DataBinder.Eval(e.Row.DataItem, "Slot" + icount + "Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot" + icount + "Pass"));
                                    if (SlotPass > 0)
                                    {
                                        if (((Convert.ToDecimal(SlotPass) / Convert.ToDecimal(SlotTargetQty)) * Convert.ToDecimal(100)) > 85)
                                            tdSlotPass.Style.Add("background-color", "green");
                                        else
                                            tdSlotPass.Style.Add("background-color", "#FF0000");
                                    }
                                }
                                else
                                {
                                    Label lblSlotPass = (Label)e.Row.FindControl("lblSlot" + icount + "Pass");
                                    lblSlotPass.Style.Add("color", "#000000");
                                }
                            }

                        }
                        PreviousUnit = UnitId;
                        BIPLPriceSlot1 += DataBinder.Eval(e.Row.DataItem, "Slot1_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot1_BIPLPrice"));
                        BIPLPriceSlot2 += DataBinder.Eval(e.Row.DataItem, "Slot2_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot2_BIPLPrice"));
                        BIPLPriceSlot3 += DataBinder.Eval(e.Row.DataItem, "Slot3_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot3_BIPLPrice"));
                        BIPLPriceSlot4 += DataBinder.Eval(e.Row.DataItem, "Slot4_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot4_BIPLPrice"));
                        BIPLPriceSlot5 += DataBinder.Eval(e.Row.DataItem, "Slot5_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot5_BIPLPrice"));
                        BIPLPriceSlot6 += DataBinder.Eval(e.Row.DataItem, "Slot6_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot6_BIPLPrice"));
                        BIPLPriceSlot7 += DataBinder.Eval(e.Row.DataItem, "Slot7_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot7_BIPLPrice"));
                        BIPLPriceSlot8 += DataBinder.Eval(e.Row.DataItem, "Slot8_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot8_BIPLPrice"));
                        BIPLPriceSlot9 += DataBinder.Eval(e.Row.DataItem, "Slot9_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot9_BIPLPrice"));
                        BIPLPriceSlot10 += DataBinder.Eval(e.Row.DataItem, "Slot10_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot10_BIPLPrice"));
                        BIPLPriceSlot11 += DataBinder.Eval(e.Row.DataItem, "Slot11_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot11_BIPLPrice"));
                        BIPLPriceSlot12 += DataBinder.Eval(e.Row.DataItem, "Slot12_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot12_BIPLPrice"));
                        BIPLPriceSlot13 += DataBinder.Eval(e.Row.DataItem, "Slot13_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot13_BIPLPrice"));
                        BIPLPriceSlot14 += DataBinder.Eval(e.Row.DataItem, "Slot14_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot14_BIPLPrice"));
                        BIPLPriceSlot15 += DataBinder.Eval(e.Row.DataItem, "Slot15_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot15_BIPLPrice"));
                        BIPLPriceSlot16 += DataBinder.Eval(e.Row.DataItem, "Slot16_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot16_BIPLPrice"));

                        //string StyleCode = DataBinder.Eval(e.Row.DataItem, "StyleCode").ToString();
                        //int PlanStyleId = DataBinder.Eval(e.Row.DataItem, "StyleId") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StyleId"));


                        double StitchSAM_row = DataBinder.Eval(e.Row.DataItem, "StitchSAM") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "StitchSAM"));
                        int TargetQty_row = DataBinder.Eval(e.Row.DataItem, "TargetQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetQty"));
                        int StitchActualOB_row = DataBinder.Eval(e.Row.DataItem, "StitchActualOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StitchActualOB"));

                        if (StitchActualOB_row > 0)
                            StitchSAM_TargetQty_Total = StitchSAM_TargetQty_Total + (StitchSAM_row * TargetQty_row);


                        int ProductionUnit = -1;
                        HtmlTable tblEmptyMsg1 = (HtmlTable)e.Row.FindControl("tblEmptyMsg");
                        tblEmptyMsg1.Visible = false;

                        HiddenField hdnLineNo = (HiddenField)e.Row.FindControl("hdnLineNo");

                        HiddenField hdnUnitId = (HiddenField)e.Row.FindControl("hdnUnitId");
                        HtmlTableCell tdUpcomingStyle = (HtmlTableCell)e.Row.FindControl("tdUpcomingStyle");
                        HtmlTable tableUpComingStyle = (HtmlTable)e.Row.FindControl("tableUpComingStyle");

                        if (hdnLineNo.Value != DBNull.Value.ToString())
                            LineNo = Convert.ToInt32(hdnLineNo.Value);
                        if (hdnUnitId.Value != DBNull.Value.ToString())
                            ProductionUnit = Convert.ToInt32(hdnUnitId.Value);
                        //if (IsCluster == 0)
                        //{
                        //    CuttingPerPcsCost = DataBinder.Eval(e.Row.DataItem, "CuttingPerPcsCost") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CuttingPerPcsCost"));
                        //    StichingPerOBCost = DataBinder.Eval(e.Row.DataItem, "StichingPerOBCost") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "StichingPerOBCost"));
                        //    FinishingPerOBCost = DataBinder.Eval(e.Row.DataItem, "FinishingPerOBCost") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FinishingPerOBCost"));
                        //    FinishingPerPcsCost = DataBinder.Eval(e.Row.DataItem, "FinishingPerPcsCost") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FinishingPerPcsCost"));
                        //    FactoryOverHeadPerPcs = DataBinder.Eval(e.Row.DataItem, "FactoryOverHeadPerPcs") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FactoryOverHeadPerPcs"));
                        //    CostPerHour = DataBinder.Eval(e.Row.DataItem, "CostPerHour") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CostPerHour"));
                        //}                        

                        DataSet dsGetBottleNeck;
                        dsGetBottleNeck = objProductionController.GetBottleNeck_QC_StyleCode_HourlyReport(StyleCode, LinePlanFrameId, ProductionUnit, SlotId, ClusterId);
                        DataTable dtGetBottleNeck = dsGetBottleNeck.Tables[0];

                        Repeater rptBottleNeck = e.Row.FindControl("rptBottleNeck") as Repeater;
                        rptBottleNeck.DataSource = dtGetBottleNeck;
                        rptBottleNeck.DataBind();

                        Label lblQCPassCOunt = e.Row.FindControl("lblQCPassCOunt") as Label;
                        Label lblQCFailCOunt = e.Row.FindControl("lblQCFailCOunt") as Label;
                        Label lblQCFailPercent = e.Row.FindControl("lblQCFailPercent") as Label;

                        DataTable dtPassFail = dsGetBottleNeck.Tables[1];

                        if (dtPassFail.Rows.Count > 0)
                        {
                            PassCount += dtPassFail.Rows[0]["PassCount"] == DBNull.Value ? 0 : Convert.ToInt32(dtPassFail.Rows[0]["PassCount"]);
                            FailCount += dtPassFail.Rows[0]["FailCount"] == DBNull.Value ? 0 : Convert.ToInt32(dtPassFail.Rows[0]["FailCount"]);

                            lblQCPassCOunt.Text = dtPassFail.Rows[0]["PassCount"].ToString() == "0" ? "" : dtPassFail.Rows[0]["PassCount"].ToString();
                            lblQCFailCOunt.Text = dtPassFail.Rows[0]["FailCount"].ToString() == "0" ? "" : dtPassFail.Rows[0]["FailCount"].ToString();
                            lblQCFailPercent.Text = dtPassFail.Rows[0]["FailPercent"].ToString();

                            string LastSlotStatus = dtPassFail.Rows[0]["LastSlotStatus"].ToString();
                            HtmlControl divCircle = (HtmlControl)e.Row.FindControl("divCircle");

                            int PassFail = Convert.ToInt32(dtPassFail.Rows[0]["PassCount"].ToString()) + Convert.ToInt32(dtPassFail.Rows[0]["FailCount"].ToString());
                            if (PassFail > 0)
                            {
                                if (LastSlotStatus == "1")
                                    divCircle.Style.Add("background", "green");
                                else
                                    divCircle.Style.Add("background", "red");
                            }
                        }
                        if (dsGetBottleNeck.Tables.Count > 2)
                        {
                            DataTable dtQCFaultCount = dsGetBottleNeck.Tables[2];
                            Repeater rptQCFaultDetails = e.Row.FindControl("rptQCFaultDetails") as Repeater;

                            rptQCFaultDetails.DataSource = dtQCFaultCount;
                            rptQCFaultDetails.DataBind();
                        }
                        //End Of Code
                        // Added By Ravi kumar on 5-Dec-18 to merge all function in a single function for(Inspection, LineMan, UpcomingStyle, PendingQty)

                        DataSet ds;
                        ds = objProductionController.GetProduction_SectionFor_HourlyReport(StyleCode, LinePlanFrameId, PlanStyleId, ProductionUnit, LineNo, SlotId, ProdDay, TargetQty, IsCluster, ClusterId);
                        DataTable dtInspection = ds.Tables[0];
                        DataTable dtLineMan = ds.Tables[1];
                        DataTable dtUpcomingStyle = ds.Tables[2];
                        DataTable dtPending = ds.Tables[3];

                        Repeater dlstInspection = e.Row.FindControl("dlstInspection") as Repeater;
                        dlstInspection.DataSource = dtInspection;
                        dlstInspection.DataBind();

                        DataList dlstLineDesignation = e.Row.FindControl("dlstLineDesignation") as DataList;
                        dlstLineDesignation.DataSource = dtLineMan;
                        dlstLineDesignation.DataBind();

                        Label lblUpcommingStyle = e.Row.FindControl("lblUpcommingStyle") as Label;
                        Label lblUpcomingStyleCode = e.Row.FindControl("lblUpcomingStyleCode") as Label;
                        Label lblUpcomingPndgStitchQty = e.Row.FindControl("lblUpcomingPndgStitchQty") as Label;
                        Label lblFistExFactoryDate = e.Row.FindControl("lblFistExFactoryDate") as Label;
                        Label lblLastExFactoryDate = e.Row.FindControl("lblLastExFactoryDate") as Label;
                        Label lblUpcomingCutWip = e.Row.FindControl("lblUpcomingCutWip") as Label;
                        Label lblUpcomingPndgsAM = e.Row.FindControl("lblUpcomingPndgsAM") as Label;

                        string sStyleCode = "";

                        if (dtUpcomingStyle.Rows.Count > 0)
                        {
                            string UpcomingStyle = dtUpcomingStyle.Rows[0]["StyleCode"].ToString();
                            HiddenField hdnimgStyleIdImgPath = (HiddenField)e.Row.FindControl("hdnimgStyleIdImgPath");
                            HtmlImage imgStyleIdImgPath = (HtmlImage)e.Row.FindControl("imgStyleIdImgPath");

                            if (UpcomingStyle.Trim() != "")
                            {
                                sStyleCode = dtUpcomingStyle.Rows[0]["StyleCode"].ToString();
                                lblUpcomingPndgStitchQty.Text = dtUpcomingStyle.Rows[0]["PndgStitchQty"].ToString();
                                lblFistExFactoryDate.Text = dtUpcomingStyle.Rows[0]["FstExfactoryDate"].ToString();
                                lblLastExFactoryDate.Text = dtUpcomingStyle.Rows[0]["LastExfactoryDate"].ToString();
                                lblUpcomingCutWip.Text = dtUpcomingStyle.Rows[0]["CutWip"].ToString();
                                lblUpcomingPndgsAM.Text = Math.Round(Convert.ToDouble(dtUpcomingStyle.Rows[0]["SAM"].ToString()), 1).ToString();

                                int AvgFabricQty = dtUpcomingStyle.Rows[0]["FabricQty"].ToString() == "" ? 0 : Convert.ToInt32(dtUpcomingStyle.Rows[0]["FabricQty"]);

                                string FabricTooltip = "";

                                if (dtUpcomingStyle.Rows[0]["FabricStartEndEta"].ToString() != "")
                                {
                                    FabricTooltip = dtUpcomingStyle.Rows[0]["FabricStartEndEta"].ToString();
                                }

                                HtmlTableCell tdUpcomingStyleCode = e.Row.FindControl("tdUpcomingStyleCode") as HtmlTableCell;

                                if (AvgFabricQty <= 30)
                                {
                                    if (AvgFabricQty == 0)
                                    {
                                        sStyleCode = " <span style='float:left; color:Black;padding-left:2px;'>" + sStyleCode + "</span> <span data-title=' " + FabricTooltip + "' style='float:right; background-color:Red;min-width: 14px; color:White;'>&nbsp;&nbsp;&nbsp;</span>";
                                        lblUpcomingStyleCode.Text = sStyleCode;
                                    }
                                    else
                                    {
                                        sStyleCode = " <span style='float:left; color:Black;padding-left:2px;'>" + sStyleCode + "</span> <span data-title=' " + FabricTooltip + "' style='float:right; background-color:Red;min-width: 14px; color:White;padding-right:2px;'>" + AvgFabricQty + "%</span>";
                                        lblUpcomingStyleCode.Text = sStyleCode;
                                    }
                                }
                                else if ((AvgFabricQty > 30) && (AvgFabricQty <= 90))
                                {
                                    sStyleCode = " <span style='float:left; color:Black;padding-left:2px;'>" + sStyleCode + "</span> <span data-title=' " + FabricTooltip + "' style='float:right; background-color:Orange; color:Black;padding-right:2px;'>" + AvgFabricQty + "%</span>";
                                    lblUpcomingStyleCode.Text = sStyleCode;
                                }
                                else
                                {
                                    sStyleCode = " <span style='float:left; color:Black;padding-left:2px;'>" + sStyleCode + "</span> <span style='float:right; background-color:Green; color:White;padding-right:2px;'>" + AvgFabricQty + "%</span>";
                                    lblUpcomingStyleCode.Text = sStyleCode;
                                }
                                lblUpcommingStyle.Visible = false;
                                if (dtUpcomingStyle.Rows[0]["imgStyleImgPath"].ToString() != "")
                                {
                                    hdnimgStyleIdImgPath.Value = dtUpcomingStyle.Rows[0]["imgStyleImgPath"].ToString();
                                    imgStyleIdImgPath.Src = "/uploads/style/thumb-" + hdnimgStyleIdImgPath.Value;
                                }
                            }
                        }
                        else
                        {
                            if (IsCluster == 0)
                            {
                                tdUpcomingStyle.Style.Add("background-color", "#FF0000");
                                lblUpcommingStyle.Text = "Planning Missing";
                                lblUpcommingStyle.Style.Add("color", "white");
                                tableUpComingStyle.Visible = false;
                            }
                        }

                        ViewState["IsCluster"] = IsCluster;

                        GridView gvPending = e.Row.FindControl("gvPending") as GridView;
                        ViewState["dtPending"] = dtPending;

                        gvPending.DataSource = dtPending;
                        gvPending.DataBind();

                        int ColCount = dtPending.Columns.Count;

                        for (int i = ColCount; i <= 5; i++)
                        {
                            gvPending.Columns[i].Visible = false;
                        }
                    }

                    else if (UnitId == -1)
                    {
                        e.Row.Attributes.Add("class", "yellowFactory");
                        e.Row.Cells[24].Visible = false;
                        e.Row.Cells[25].Visible = false;
                        e.Row.Cells[26].Visible = false;
                        e.Row.Cells[27].Visible = false;
                        lblUnit.Visible = true;
                        lblUnit.Text = "";

                        Label lblUnitTotal = (Label)e.Row.FindControl("lblUnitTotal");
                        lblUnitTotal.Text = "Factory Total";
                        lblTodayEff_Stitch.Style.Add("font-size", "12px");
                        imgStyle.Visible = false;
                        lblLineNumber.Visible = false;
                        lblProdDay.Visible = false;
                        lblCOT.Visible = false;

                        string FactoryName = DataBinder.Eval(e.Row.DataItem, "FactoryName").ToString();


                        int SlotTargetQty = 0, SlotPass = 0;

                        for (int icount = 1; icount <= SlotId; icount++)
                        {
                            if (icount == 1)
                                SlotTargetQty = Slot1TargetQty;
                            if (icount == 2)
                                SlotTargetQty = Slot2TargetQty;
                            if (icount == 3)
                                SlotTargetQty = Slot3TargetQty;
                            if (icount == 4)
                                SlotTargetQty = Slot4TargetQty;
                            if (icount == 5)
                                SlotTargetQty = Slot5TargetQty;
                            if (icount == 6)
                                SlotTargetQty = Slot6TargetQty;
                            if (icount == 7)
                                SlotTargetQty = Slot7TargetQty;
                            if (icount == 8)
                                SlotTargetQty = Slot8TargetQty;
                            if (icount == 9)
                                SlotTargetQty = Slot9TargetQty;
                            if (icount == 10)
                                SlotTargetQty = Slot10TargetQty;
                            if (icount == 11)
                                SlotTargetQty = Slot11TargetQty;
                            if (icount == 12)
                                SlotTargetQty = Slot12TargetQty;
                            if (icount == 13)
                                SlotTargetQty = Slot13TargetQty;
                            if (icount == 14)
                                SlotTargetQty = Slot14TargetQty;
                            if (icount == 15)
                                SlotTargetQty = Slot15TargetQty;
                            if (icount == 16)
                                SlotTargetQty = Slot16TargetQty;

                            if (SlotTargetQty > 0)
                            {
                                HtmlTableCell tdSlotPass = (HtmlTableCell)e.Row.FindControl("tdSlot" + icount + "Pass");
                                SlotPass = DataBinder.Eval(e.Row.DataItem, "Slot" + icount + "Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot" + icount + "Pass"));
                                if (SlotPass > 0)
                                {
                                    if (((Convert.ToDecimal(SlotPass) / Convert.ToDecimal(SlotTargetQty)) * Convert.ToDecimal(100)) > 85)
                                        tdSlotPass.Style.Add("background-color", "green");
                                    else
                                        tdSlotPass.Style.Add("background-color", "#FF0000");
                                }
                            }
                            else
                            {
                                Label lblSlotPass = (Label)e.Row.FindControl("lblSlot" + icount + "Pass");
                                lblSlotPass.Style.Add("color", "#000000");
                            }
                        }

                        Slot1TargetQty = 0;
                        Slot2TargetQty = 0;
                        Slot3TargetQty = 0;
                        Slot4TargetQty = 0;
                        Slot5TargetQty = 0;
                        Slot6TargetQty = 0;
                        Slot7TargetQty = 0;
                        Slot8TargetQty = 0;
                        Slot9TargetQty = 0;
                        Slot10TargetQty = 0;
                        Slot11TargetQty = 0;
                        Slot12TargetQty = 0;
                        Slot13TargetQty = 0;
                        Slot14TargetQty = 0;
                        Slot15TargetQty = 0;
                        Slot16TargetQty = 0;


                        Factory_BreakEvenQty = DataBinder.Eval(e.Row.DataItem, "BreakEvenQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BreakEvenQty"));
                        Factory_StchAvgPcs += DataBinder.Eval(e.Row.DataItem, "TodayAvgStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayAvgStitch"));

                        Total_Slot1 += DataBinder.Eval(e.Row.DataItem, "Slot1Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1Pass"));
                        Total_Slot2 += DataBinder.Eval(e.Row.DataItem, "Slot2Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2Pass"));
                        Total_Slot3 += DataBinder.Eval(e.Row.DataItem, "Slot3Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3Pass"));
                        Total_Slot4 += DataBinder.Eval(e.Row.DataItem, "Slot4Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4Pass"));
                        Total_Slot5 += DataBinder.Eval(e.Row.DataItem, "Slot5Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5Pass"));
                        Total_Slot6 += DataBinder.Eval(e.Row.DataItem, "Slot6Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6Pass"));
                        Total_Slot7 += DataBinder.Eval(e.Row.DataItem, "Slot7Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7Pass"));
                        Total_Slot8 += DataBinder.Eval(e.Row.DataItem, "Slot8Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8Pass"));
                        Total_Slot9 += DataBinder.Eval(e.Row.DataItem, "Slot9Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9Pass"));
                        Total_Slot10 += DataBinder.Eval(e.Row.DataItem, "Slot10Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10Pass"));
                        Total_Slot11 += DataBinder.Eval(e.Row.DataItem, "Slot11Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11Pass"));
                        Total_Slot12 += DataBinder.Eval(e.Row.DataItem, "Slot12Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12Pass"));
                        Total_Slot13 += DataBinder.Eval(e.Row.DataItem, "Slot13Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13Pass"));
                        Total_Slot14 += DataBinder.Eval(e.Row.DataItem, "Slot14Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14Pass"));
                        Total_Slot15 += DataBinder.Eval(e.Row.DataItem, "Slot15Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15Pass"));
                        Total_Slot16 += DataBinder.Eval(e.Row.DataItem, "Slot16Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16Pass"));


                        Total_DHU1 += DataBinder.Eval(e.Row.DataItem, "Slot1DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1DHU"));
                        Total_DHU2 += DataBinder.Eval(e.Row.DataItem, "Slot2DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2DHU"));
                        Total_DHU3 += DataBinder.Eval(e.Row.DataItem, "Slot3DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3DHU"));
                        Total_DHU4 += DataBinder.Eval(e.Row.DataItem, "Slot4DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4DHU"));
                        Total_DHU5 += DataBinder.Eval(e.Row.DataItem, "Slot5DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5DHU"));
                        Total_DHU6 += DataBinder.Eval(e.Row.DataItem, "Slot6DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6DHU"));
                        Total_DHU7 += DataBinder.Eval(e.Row.DataItem, "Slot7DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7DHU"));
                        Total_DHU8 += DataBinder.Eval(e.Row.DataItem, "Slot8DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8DHU"));
                        Total_DHU9 += DataBinder.Eval(e.Row.DataItem, "Slot9DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9DHU"));
                        Total_DHU10 += DataBinder.Eval(e.Row.DataItem, "Slot10DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10DHU"));
                        Total_DHU11 += DataBinder.Eval(e.Row.DataItem, "Slot11DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11DHU"));
                        Total_DHU12 += DataBinder.Eval(e.Row.DataItem, "Slot12DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12DHU"));
                        Total_DHU13 += DataBinder.Eval(e.Row.DataItem, "Slot13DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13DHU"));
                        Total_DHU14 += DataBinder.Eval(e.Row.DataItem, "Slot14DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14DHU"));
                        Total_DHU15 += DataBinder.Eval(e.Row.DataItem, "Slot15DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15DHU"));
                        Total_DHU16 += DataBinder.Eval(e.Row.DataItem, "Slot16DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16DHU"));

                        Slot1TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot1TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1TotalOB"));
                        Slot2TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot2TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2TotalOB"));
                        Slot3TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot3TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3TotalOB"));
                        Slot4TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot4TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4TotalOB"));
                        Slot5TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot5TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5TotalOB"));
                        Slot6TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot6TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6TotalOB"));
                        Slot7TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot7TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7TotalOB"));
                        Slot8TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot8TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8TotalOB"));
                        Slot9TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot9TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9TotalOB"));
                        Slot10TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot10TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10TotalOB"));
                        Slot11TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot11TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11TotalOB"));
                        Slot12TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot12TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12TotalOB"));
                        Slot13TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot13TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13TotalOB"));
                        Slot14TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot14TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14TotalOB"));
                        Slot15TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot15TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15TotalOB"));
                        Slot16TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot16TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16TotalOB"));


                        CostingCMT_Total += DataBinder.Eval(e.Row.DataItem, "CostingCMT") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CostingCMT"));

                        int CostingCMTFactory = DataBinder.Eval(e.Row.DataItem, "CostingCMT") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CostingCMT"));
                        if (CostingCMTFactory > 0)
                            CMTCount = CMTCount + 1;

                        StitchActualOB_Total += DataBinder.Eval(e.Row.DataItem, "StitchActualOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StitchActualOB"));

                        FinishSAM_Total += DataBinder.Eval(e.Row.DataItem, "FinishSAM") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FinishSAM"));
                        FinishActualOB_Total += DataBinder.Eval(e.Row.DataItem, "FinishActualOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FinishActualOB"));
                        FinishOB_Total += DataBinder.Eval(e.Row.DataItem, "FinishOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FinishOB"));

                        PeakCapecity_Total += DataBinder.Eval(e.Row.DataItem, "PeakCapecity") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakCapecity"));
                        PeakOB_Total += DataBinder.Eval(e.Row.DataItem, "PeakOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakOB"));
                        PeakEff_Total += DataBinder.Eval(e.Row.DataItem, "PeakEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakEff"));

                        int PeakEffFactory = DataBinder.Eval(e.Row.DataItem, "PeakEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakEff"));
                        if (PeakEffFactory > 0)
                            PeakEffCount = PeakEffCount + 1;

                        COTValue_Total += DataBinder.Eval(e.Row.DataItem, "COTValue") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COTValue"));

                        int COTValueFactory = DataBinder.Eval(e.Row.DataItem, "COTValue") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COTValue"));
                        if (COTValueFactory > 0)
                            COTValueCount = COTValueCount + 1;


                        OrderQty_Total += DataBinder.Eval(e.Row.DataItem, "OrderQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OrderQty"));
                        StitchQty_Total += DataBinder.Eval(e.Row.DataItem, "TotalStitchedQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalStitchedQty"));
                        FinishQty_Total += DataBinder.Eval(e.Row.DataItem, "TotalFinishQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalFinishQty"));

                        TodayPassPcsFinish_Total += DataBinder.Eval(e.Row.DataItem, "TodayPassPcsFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayPassPcsFinish"));
                        TodayPassPcsStitch_Total += DataBinder.Eval(e.Row.DataItem, "TodayPassPcsStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayPassPcsStitch"));
                        TodayAltPcs_Total += DataBinder.Eval(e.Row.DataItem, "TodayAltPcs") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayAltPcs"));
                        DHU_Today_Total += DataBinder.Eval(e.Row.DataItem, "DHU_Today") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DHU_Today"));

                        int DHU_TodayFactory = DataBinder.Eval(e.Row.DataItem, "DHU_Today") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DHU_Today"));
                        if (DHU_TodayFactory > 0)
                            DHUCount = DHUCount + 1;

                        TodayAchieved_Total += DataBinder.Eval(e.Row.DataItem, "TodayAchievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayAchievement"));

                        int TodayAchievementFactory = DataBinder.Eval(e.Row.DataItem, "TodayAchievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayAchievement"));
                        if (TodayAchievementFactory > 0)
                            AchievementCount = AchievementCount + 1;

                        TargetEff_Total += DataBinder.Eval(e.Row.DataItem, "TargetEfficiency") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetEfficiency"));
                        TargetQty_Total += DataBinder.Eval(e.Row.DataItem, "TargetQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetQty"));

                        TodayEfficiency_Stitch_Total += DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Stitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Stitch"));
                        StyleEfficiency_Stitch_Total += DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Stitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Stitch"));

                        int StyleEfficiency_StitchFactory = DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Stitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Stitch"));
                        if (StyleEfficiency_StitchFactory > 0)
                            StyleEffCount = StyleEffCount + 1;


                        FabricQty_Total += DataBinder.Eval(e.Row.DataItem, "FabricQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FabricQty"));
                        CutQty_Total += DataBinder.Eval(e.Row.DataItem, "CutQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CutQty"));
                        PercentPerformance_Total += DataBinder.Eval(e.Row.DataItem, "PercentPerformance") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PercentPerformance"));

                        int PercentPerformance_Factory = DataBinder.Eval(e.Row.DataItem, "PercentPerformance") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PercentPerformance"));
                        if (PercentPerformance_Factory > 0)
                            PercentPerformanceCount = PercentPerformanceCount + 1;

                        PeakCapcty_Finish_Total += DataBinder.Eval(e.Row.DataItem, "PeakCapcty_Finish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakCapcty_Finish"));
                        PeakOB_Finish_Total += DataBinder.Eval(e.Row.DataItem, "PeakOB_Finish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakOB_Finish"));
                        PeakEff_Finish_Total += DataBinder.Eval(e.Row.DataItem, "PeakEff_Finish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakEff_Finish"));

                        TCActualOB_Total += DataBinder.Eval(e.Row.DataItem, "TCActualOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TCActualOB"));
                        TCPeakOB_Total += DataBinder.Eval(e.Row.DataItem, "TCPeakOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TCPeakOB"));
                        TCCapcty_Total += DataBinder.Eval(e.Row.DataItem, "TCCapcty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TCCapcty"));

                        PressCapcty_Total += DataBinder.Eval(e.Row.DataItem, "PressCapcty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PressCapcty"));
                        PressPeakOB_Total += DataBinder.Eval(e.Row.DataItem, "PressPeakOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PressPeakOB"));
                        PressActualOB_Total += DataBinder.Eval(e.Row.DataItem, "PressActualOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PressActualOB"));

                        StitchActualAvgOB_Total += DataBinder.Eval(e.Row.DataItem, "StitchActualAvgOB") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "StitchActualAvgOB"));
                        FinishActualAvgOB_Total += DataBinder.Eval(e.Row.DataItem, "FinishActualAvgOB") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FinishActualAvgOB"));

                        TodayPassFinish_BIPL += DataBinder.Eval(e.Row.DataItem, "TodayPassPcsFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayPassPcsFinish"));

                        FactoryTotalTodayFinishObatLineCluster = DataBinder.Eval(e.Row.DataItem, "TotalTodayFinishObatLineCluster") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalTodayFinishObatLineCluster"));

                        BIPLTotalTodayFinishObatLineCluster += DataBinder.Eval(e.Row.DataItem, "TotalTodayFinishObatLineCluster") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalTodayFinishObatLineCluster"));

                        int FactoryStitchPassCount = DataBinder.Eval(e.Row.DataItem, "StitchPassCount") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StitchPassCount"));

                        if (StitchActualOB <= StitchOB_Factory)
                            lblStchActOB.Style.Add("color", "green");
                        else
                            lblStchActOB.Style.Add("color", "red");

                        if (MaxStitchPassCount == 0)
                            MaxStitchPassCount = FactoryStitchPassCount;
                        else
                        {
                            if (FactoryStitchPassCount > MaxStitchPassCount)
                                MaxStitchPassCount = FactoryStitchPassCount;
                        }

                        int FactoryFinishPassCount = DataBinder.Eval(e.Row.DataItem, "FinishPassCount") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FinishPassCount"));
                        if (MaxFinishPassCount == 0)
                            MaxFinishPassCount = FactoryFinishPassCount;
                        else
                        {
                            if (FactoryStitchPassCount > MaxFinishPassCount)
                                MaxFinishPassCount = FactoryFinishPassCount;
                        }

                        if (FactoryTotalTodayFinishObatLineCluster > 0 && FinishAvgPcs > 0 && TodayPassFinish > 0)
                        {
                            lblFinishCost.Text = "&#8377;" + Math.Round(((Convert.ToDouble(FactoryTotalTodayFinishObatLineCluster) * FinishingPerOBCost) / Convert.ToDouble(TodayPassFinish)), 0).ToString();

                            if (Math.Round(((Convert.ToDouble(FactoryTotalTodayFinishObatLineCluster) * FinishingPerOBCost) / Convert.ToDouble(TodayPassFinish)), 0) <= 10)
                            {
                                lblFinishCost.Style.Add("color", "green");
                            }
                            else
                            {
                                lblFinishCost.Style.Add("color", "#FF0000");
                            }
                            if (Math.Round((Convert.ToDouble(FactoryTotalTodayFinishObatLineCluster) * FinishingPerOBCost) / Convert.ToDouble(TodayPassFinish), 0) <= 12)
                            {
                                lblTodayPassFinish.Style.Add("color", "green");
                            }
                            else
                            {
                                lblTodayPassFinish.Style.Add("color", "#FF0000");
                            }
                        }
                        else
                        {
                            lblTodayPassFinish.Style.Add("color", "Black");

                        }

                        if (TodayDHU > 5)
                        {
                            lblTodayAltPcs.Style.Add("color", "#FF0000");
                            lblTodayDHU.Style.Add("color", "#FF0000");
                        }

                        if (TodayDHU <= 5)
                        {
                            lblTodayAltPcs.Style.Add("color", "green");
                            lblTodayDHU.Style.Add("color", "green");
                        }

                        lblStchAgreedOB.Text = StitchOB_Factory == 0 ? "" : "(" + StitchOB_Factory.ToString() + ")";
                        StitchOB_Total = StitchOB_Total + StitchOB_Factory;

                        StitchOB_Factory = 0;
                        lblwipCutPcs.Font.Bold = true;
                        lblWIPStichedPcs.Font.Bold = true;
                        lblWIPFinishedPcs.Font.Bold = true;

                        int TotalCount = (PassCount + FailCount) * 5;

                        DataSet dsGetBottleNeck;
                        dsGetBottleNeck = objProductionController.GetBottleNeck_QC_HourlyReport_ForFactory(PreviousUnit, TotalCount, SlotId);
                        DataTable dtQCFaultCount = dsGetBottleNeck.Tables[0];

                        Repeater rptQCFaultDetails = e.Row.FindControl("rptQCFaultDetails") as Repeater;

                        rptQCFaultDetails.DataSource = dtQCFaultCount;
                        rptQCFaultDetails.DataBind();

                        Label lblQCPassCOunt = e.Row.FindControl("lblQCPassCOunt") as Label;
                        Label lblQCFailCOunt = e.Row.FindControl("lblQCFailCOunt") as Label;
                        Label lblQCFailPercent = e.Row.FindControl("lblQCFailPercent") as Label;

                        lblQCPassCOunt.Text = PassCount == 0 ? "" : PassCount.ToString();
                        lblQCFailCOunt.Text = FailCount == 0 ? "" : FailCount.ToString();

                        if (Convert.ToDouble(FailCount + PassCount) > 0)
                        {
                            double FailPercent = Math.Round(Convert.ToDouble(FailCount) / Convert.ToDouble(FailCount + PassCount) * 100, 0);
                            lblQCFailPercent.Text = FailPercent > 0 ? FailPercent.ToString() + "%" : "";
                        }

                        TotalPassCount = TotalPassCount + PassCount;
                        TotalFailCount = TotalFailCount + FailCount;
                        PassCount = 0;
                        FailCount = 0;

                        HtmlTable tblOrderQty = (HtmlTable)e.Row.FindControl("tblOrderQty");
                        tblOrderQty.Visible = false;

                        FactoryTotal = FactoryTotal + 1;
                    }

                    else if (UnitId == 0)
                    {
                        e.Row.Attributes.Add("class", "yellowFactory");

                        HtmlTable tblEffHide1 = (HtmlTable)e.Row.FindControl("tblEffHide");
                        tblEffHide1.Visible = false;
                        HtmlTable tblEffShow1 = (HtmlTable)e.Row.FindControl("tblEffShow");
                        tblEffShow1.Visible = true;

                        Label lblEfficiency = (Label)e.Row.FindControl("lblEfficiency");
                        lblEfficiency.Text = "Efficiency";

                        Label lblAchievement = (Label)e.Row.FindControl("lblAchievement");
                        lblAchievement.Text = "Achievement";

                        HtmlTable tblStitch = (HtmlTable)e.Row.FindControl("tblStitch");
                        imgStyle.Visible = false;
                        lblUnit.Visible = true;
                        tblStitch.Visible = false;
                        e.Row.Cells[19].ColumnSpan = 7;
                        e.Row.Cells[19].CssClass = "ROWMERGE";
                        e.Row.Cells[20].Visible = false;
                        e.Row.Cells[21].Visible = false;
                        e.Row.Cells[22].Visible = false;
                        e.Row.Cells[23].Visible = false;
                        e.Row.Cells[24].Visible = false;
                        e.Row.Cells[25].Visible = false;
                        e.Row.Cells[26].Visible = false;
                        e.Row.Cells[27].Visible = false;


                        int Slot1Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot1Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1Stitch_Eff"));
                        int Slot2Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot2Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2Stitch_Eff"));
                        int Slot3Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot3Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3Stitch_Eff"));
                        int Slot4Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot4Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4Stitch_Eff"));
                        int Slot5Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot5Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5Stitch_Eff"));
                        int Slot6Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot6Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6Stitch_Eff"));
                        int Slot7Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot7Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7Stitch_Eff"));
                        int Slot8Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot8Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8Stitch_Eff"));
                        int Slot9Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot9Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9Stitch_Eff"));
                        int Slot10Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot10Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10Stitch_Eff"));
                        int Slot11Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot11Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11Stitch_Eff"));
                        int Slot12Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot12Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12Stitch_Eff"));
                        int Slot13Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot13Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13Stitch_Eff"));
                        int Slot14Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot14Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14Stitch_Eff"));
                        int Slot15Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot15Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15Stitch_Eff"));
                        int Slot16Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot16Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16Stitch_Eff"));

                        lblSlot1Pass.Text = Slot1Stitch_Eff == 0 ? "" : "<b>" + Slot1Stitch_Eff.ToString() + "% </b>";
                        lblSlot2Pass.Text = Slot2Stitch_Eff == 0 ? "" : "<b>" + Slot2Stitch_Eff.ToString() + "% </b>";
                        lblSlot3Pass.Text = Slot3Stitch_Eff == 0 ? "" : "<b>" + Slot3Stitch_Eff.ToString() + "% </b>";
                        lblSlot4Pass.Text = Slot4Stitch_Eff == 0 ? "" : "<b>" + Slot4Stitch_Eff.ToString() + "% </b>";
                        lblSlot5Pass.Text = Slot5Stitch_Eff == 0 ? "" : "<b>" + Slot5Stitch_Eff.ToString() + "% </b>";
                        lblSlot6Pass.Text = Slot6Stitch_Eff == 0 ? "" : "<b>" + Slot6Stitch_Eff.ToString() + "% </b>";
                        lblSlot7Pass.Text = Slot7Stitch_Eff == 0 ? "" : "<b>" + Slot7Stitch_Eff.ToString() + "% </b>";
                        lblSlot8Pass.Text = Slot8Stitch_Eff == 0 ? "" : "<b>" + Slot8Stitch_Eff.ToString() + "% </b>";
                        lblSlot9Pass.Text = Slot9Stitch_Eff == 0 ? "" : "<b>" + Slot9Stitch_Eff.ToString() + "% </b>";
                        lblSlot10Pass.Text = Slot10Stitch_Eff == 0 ? "" : "<b>" + Slot10Stitch_Eff.ToString() + "% </b>";
                        lblSlot11Pass.Text = Slot11Stitch_Eff == 0 ? "" : "<b>" + Slot11Stitch_Eff.ToString() + "% </b>";
                        lblSlot12Pass.Text = Slot12Stitch_Eff == 0 ? "" : "<b>" + Slot12Stitch_Eff.ToString() + "% </b>";
                        lblSlot13Pass.Text = Slot13Stitch_Eff == 0 ? "" : "<b>" + Slot13Stitch_Eff.ToString() + "% </b>";
                        lblSlot14Pass.Text = Slot14Stitch_Eff == 0 ? "" : "<b>" + Slot14Stitch_Eff.ToString() + "% </b>";
                        lblSlot15Pass.Text = Slot15Stitch_Eff == 0 ? "" : "<b>" + Slot15Stitch_Eff.ToString() + "% </b>";
                        lblSlot16Pass.Text = Slot16Stitch_Eff == 0 ? "" : "<b>" + Slot16Stitch_Eff.ToString() + "% </b>";

                        // Achievement

                        int Slot1_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot1_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1_Achievement"));
                        int Slot2_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot2_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2_Achievement"));
                        int Slot3_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot3_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3_Achievement"));
                        int Slot4_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot4_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4_Achievement"));
                        int Slot5_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot5_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5_Achievement"));
                        int Slot6_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot6_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6_Achievement"));
                        int Slot7_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot7_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7_Achievement"));
                        int Slot8_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot8_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8_Achievement"));
                        int Slot9_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot9_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9_Achievement"));
                        int Slot10_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot10_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10_Achievement"));
                        int Slot11_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot11_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11_Achievement"));
                        int Slot12_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot12_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12_Achievement"));
                        int Slot13_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot13_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13_Achievement"));
                        int Slot14_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot14_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14_Achievement"));
                        int Slot15_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot15_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15_Achievement"));
                        int Slot16_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot16_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16_Achievement"));


                        //Add By Prabhaker on 18-jan-18
                        HtmlTableCell td1Dhu = (HtmlTableCell)e.Row.FindControl("td1Dhu");
                        HtmlTableCell td2Dhu = (HtmlTableCell)e.Row.FindControl("td2Dhu");
                        HtmlTableCell td3Dhu = (HtmlTableCell)e.Row.FindControl("td3Dhu");
                        HtmlTableCell td4Dhu = (HtmlTableCell)e.Row.FindControl("td4Dhu");
                        HtmlTableCell td5Dhu = (HtmlTableCell)e.Row.FindControl("td5Dhu");
                        HtmlTableCell td6Dhu = (HtmlTableCell)e.Row.FindControl("td6Dhu");
                        HtmlTableCell td7Dhu = (HtmlTableCell)e.Row.FindControl("td7Dhu");
                        HtmlTableCell td8Dhu = (HtmlTableCell)e.Row.FindControl("td8Dhu");
                        HtmlTableCell td9Dhu = (HtmlTableCell)e.Row.FindControl("td9Dhu");
                        HtmlTableCell td10Dhu = (HtmlTableCell)e.Row.FindControl("td10Dhu");
                        HtmlTableCell td11Dhu = (HtmlTableCell)e.Row.FindControl("td11Dhu");
                        HtmlTableCell td12Dhu = (HtmlTableCell)e.Row.FindControl("td12Dhu");
                        HtmlTableCell td13Dhu = (HtmlTableCell)e.Row.FindControl("td13Dhu");
                        HtmlTableCell td14Dhu = (HtmlTableCell)e.Row.FindControl("td14Dhu");
                        HtmlTableCell td15Dhu = (HtmlTableCell)e.Row.FindControl("td15Dhu");
                        HtmlTableCell td16Dhu = (HtmlTableCell)e.Row.FindControl("td16Dhu");

                        if (Slot1_Achievement > 0 && Slot1_Achievement < 81)
                        {
                            td1Dhu.Style.Add("background-color", "red");
                            lblSlot1DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td1Dhu.Style.Add("background-color", "green");
                            lblSlot1DHU.ForeColor = Color.Yellow;
                        }
                        if (Slot2_Achievement > 0 && Slot2_Achievement < 81)
                        {
                            td2Dhu.Style.Add("background-color", "red");
                            lblSlot2DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td2Dhu.Style.Add("background-color", "green");
                            lblSlot2DHU.ForeColor = Color.Yellow;
                        }

                        if (Slot3_Achievement > 0 && Slot3_Achievement < 81)
                        {
                            td3Dhu.Style.Add("background-color", "red");
                            lblSlot3DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td3Dhu.Style.Add("background-color", "green");
                            lblSlot3DHU.ForeColor = Color.Yellow;
                        }

                        if (Slot4_Achievement > 0 && Slot4_Achievement < 81)
                        {
                            td4Dhu.Style.Add("background-color", "red");
                            lblSlot4DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td4Dhu.Style.Add("background-color", "green");
                            lblSlot4DHU.ForeColor = Color.Yellow;
                        }
                        if (Slot5_Achievement > 0 && Slot5_Achievement < 81)
                        {
                            td5Dhu.Style.Add("background-color", "red");
                            lblSlot5DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td5Dhu.Style.Add("background-color", "green");
                            lblSlot5DHU.ForeColor = Color.Yellow;
                        }

                        if (Slot6_Achievement > 0 && Slot6_Achievement < 81)
                        {
                            td6Dhu.Style.Add("background-color", "red");
                            lblSlot6DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td6Dhu.Style.Add("background-color", "green");
                            lblSlot6DHU.ForeColor = Color.Yellow;
                        }

                        if (Slot7_Achievement > 0 && Slot7_Achievement < 81)
                        {
                            td7Dhu.Style.Add("background-color", "red");
                            lblSlot7DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td7Dhu.Style.Add("background-color", "green");
                            lblSlot7DHU.ForeColor = Color.Yellow;
                        }

                        if (Slot8_Achievement > 0 && Slot8_Achievement < 81)
                        {
                            td8Dhu.Style.Add("background-color", "red");
                            lblSlot8DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td8Dhu.Style.Add("background-color", "green");
                            lblSlot8DHU.ForeColor = Color.Yellow;
                        }
                        if (Slot9_Achievement > 0 && Slot9_Achievement < 81)
                        {
                            td9Dhu.Style.Add("background-color", "red");
                            lblSlot9DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td9Dhu.Style.Add("background-color", "green");
                            lblSlot9DHU.ForeColor = Color.Yellow;
                        }

                        if (Slot10_Achievement > 0 && Slot10_Achievement < 81)
                        {
                            td10Dhu.Style.Add("background-color", "red");
                            lblSlot10DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td10Dhu.Style.Add("background-color", "green");
                            lblSlot10DHU.ForeColor = Color.Yellow;
                        }

                        if (Slot11_Achievement > 0 && Slot11_Achievement < 81)
                        {
                            td11Dhu.Style.Add("background-color", "red");
                            lblSlot11DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td11Dhu.Style.Add("background-color", "green");
                            lblSlot11DHU.ForeColor = Color.Yellow;
                        }

                        if (Slot12_Achievement > 0 && Slot12_Achievement < 81)
                        {
                            td12Dhu.Style.Add("background-color", "red");
                            lblSlot12DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td12Dhu.Style.Add("background-color", "green");
                            lblSlot12DHU.ForeColor = Color.Yellow;
                        }
                        if (Slot13_Achievement > 0 && Slot13_Achievement < 81)
                        {
                            td13Dhu.Style.Add("background-color", "red");
                            lblSlot13DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td13Dhu.Style.Add("background-color", "green");
                            lblSlot13DHU.ForeColor = Color.Yellow;
                        }

                        if (Slot14_Achievement > 0 && Slot14_Achievement < 81)
                        {
                            td14Dhu.Style.Add("background-color", "red");
                            lblSlot14DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td14Dhu.Style.Add("background-color", "green");
                            lblSlot14DHU.ForeColor = Color.Yellow;
                        }
                        if (Slot15_Achievement > 0 && Slot15_Achievement < 81)
                        {
                            td15Dhu.Style.Add("background-color", "red");
                            lblSlot15DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td15Dhu.Style.Add("background-color", "green");
                            lblSlot15DHU.ForeColor = Color.Yellow;
                        }


                        if (Slot16_Achievement > 0 && Slot16_Achievement < 81)
                        {
                            td16Dhu.Style.Add("background-color", "red");
                            lblSlot16DHU.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td16Dhu.Style.Add("background-color", "green");
                            lblSlot16DHU.ForeColor = Color.Yellow;
                        }
                        lblSlot1DHU.Text = Slot1_Achievement == 0 ? "" : Slot1_Achievement.ToString() + "%";
                        lblSlot2DHU.Text = Slot2_Achievement == 0 ? "" : Slot2_Achievement.ToString() + "%";
                        lblSlot3DHU.Text = Slot3_Achievement == 0 ? "" : Slot3_Achievement.ToString() + "%";
                        lblSlot4DHU.Text = Slot4_Achievement == 0 ? "" : Slot4_Achievement.ToString() + "%";
                        lblSlot5DHU.Text = Slot5_Achievement == 0 ? "" : Slot5_Achievement.ToString() + "%";
                        lblSlot6DHU.Text = Slot6_Achievement == 0 ? "" : Slot6_Achievement.ToString() + "%";
                        lblSlot7DHU.Text = Slot7_Achievement == 0 ? "" : Slot7_Achievement.ToString() + "%";
                        lblSlot8DHU.Text = Slot8_Achievement == 0 ? "" : Slot8_Achievement.ToString() + "%";
                        lblSlot9DHU.Text = Slot9_Achievement == 0 ? "" : Slot9_Achievement.ToString() + "%";
                        lblSlot10DHU.Text = Slot10_Achievement == 0 ? "" : Slot10_Achievement.ToString() + "%";
                        lblSlot11DHU.Text = Slot11_Achievement == 0 ? "" : Slot11_Achievement.ToString() + "%";
                        lblSlot12DHU.Text = Slot12_Achievement == 0 ? "" : Slot12_Achievement.ToString() + "%";
                        lblSlot13DHU.Text = Slot13_Achievement == 0 ? "" : Slot13_Achievement.ToString() + "%";
                        lblSlot14DHU.Text = Slot14_Achievement == 0 ? "" : Slot14_Achievement.ToString() + "%";
                        lblSlot15DHU.Text = Slot15_Achievement == 0 ? "" : Slot15_Achievement.ToString() + "%";
                        lblSlot16DHU.Text = Slot16_Achievement == 0 ? "" : Slot16_Achievement.ToString() + "%";

                        lblSlot1DHU.Font.Bold = true;
                        lblSlot2DHU.Font.Bold = true;
                        lblSlot3DHU.Font.Bold = true;
                        lblSlot4DHU.Font.Bold = true;
                        lblSlot5DHU.Font.Bold = true;
                        lblSlot6DHU.Font.Bold = true;
                        lblSlot7DHU.Font.Bold = true;
                        lblSlot8DHU.Font.Bold = true;
                        lblSlot9DHU.Font.Bold = true;
                        lblSlot10DHU.Font.Bold = true;
                        lblSlot11DHU.Font.Bold = true;
                        lblSlot12DHU.Font.Bold = true;
                        lblSlot13DHU.Font.Bold = true;
                        lblSlot14DHU.Font.Bold = true;
                        lblSlot15DHU.Font.Bold = true;
                        lblSlot16DHU.Font.Bold = true;


                        Total_Achievement1 += DataBinder.Eval(e.Row.DataItem, "Slot1_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1_Achievement"));
                        Total_Achievement2 += DataBinder.Eval(e.Row.DataItem, "Slot2_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2_Achievement"));
                        Total_Achievement3 += DataBinder.Eval(e.Row.DataItem, "Slot3_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3_Achievement"));
                        Total_Achievement4 += DataBinder.Eval(e.Row.DataItem, "Slot4_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4_Achievement"));
                        Total_Achievement5 += DataBinder.Eval(e.Row.DataItem, "Slot5_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5_Achievement"));
                        Total_Achievement6 += DataBinder.Eval(e.Row.DataItem, "Slot6_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6_Achievement"));
                        Total_Achievement7 += DataBinder.Eval(e.Row.DataItem, "Slot7_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7_Achievement"));
                        Total_Achievement8 += DataBinder.Eval(e.Row.DataItem, "Slot8_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8_Achievement"));
                        Total_Achievement9 += DataBinder.Eval(e.Row.DataItem, "Slot9_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9_Achievement"));
                        Total_Achievement10 += DataBinder.Eval(e.Row.DataItem, "Slot10_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10_Achievement"));
                        Total_Achievement11 += DataBinder.Eval(e.Row.DataItem, "Slot11_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11_Achievement"));
                        Total_Achievement12 += DataBinder.Eval(e.Row.DataItem, "Slot12_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12_Achievement"));
                        Total_Achievement13 += DataBinder.Eval(e.Row.DataItem, "Slot13_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13_Achievement"));
                        Total_Achievement14 += DataBinder.Eval(e.Row.DataItem, "Slot14_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14_Achievement"));
                        Total_Achievement15 += DataBinder.Eval(e.Row.DataItem, "Slot15_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15_Achievement"));
                        Total_Achievement16 += DataBinder.Eval(e.Row.DataItem, "Slot16_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16_Achievement"));


                        if (Slot1_Achievement < 85)
                            lblSlot1Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot1Pass.Style.Add("color", "green");

                        if (Slot2_Achievement < 85)
                            lblSlot2Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot2Pass.Style.Add("color", "green");

                        if (Slot3_Achievement < 85)
                            lblSlot3Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot3Pass.Style.Add("color", "green");

                        if (Slot4_Achievement < 85)
                            lblSlot4Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot4Pass.Style.Add("color", "green");

                        if (Slot5_Achievement < 85)
                            lblSlot5Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot5Pass.Style.Add("color", "green");

                        if (Slot6_Achievement < 85)
                            lblSlot6Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot6Pass.Style.Add("color", "green");

                        if (Slot7_Achievement < 85)
                            lblSlot7Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot7Pass.Style.Add("color", "green");

                        if (Slot8_Achievement < 85)
                            lblSlot8Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot8Pass.Style.Add("color", "green");

                        if (Slot9_Achievement <= 85)
                            lblSlot9Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot9Pass.Style.Add("color", "green");

                        if (Slot10_Achievement < 85)
                            lblSlot10Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot10Pass.Style.Add("color", "green");

                        if (Slot11_Achievement < 85)
                            lblSlot11Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot11Pass.Style.Add("color", "green");

                        if (Slot12_Achievement < 85)
                            lblSlot12Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot12Pass.Style.Add("color", "green");

                        if (Slot13_Achievement < 85)
                            lblSlot13Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot13Pass.Style.Add("color", "green");

                        if (Slot14_Achievement < 85)
                            lblSlot14Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot14Pass.Style.Add("color", "green");

                        if (Slot15_Achievement < 85)
                            lblSlot15Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot15Pass.Style.Add("color", "green");

                        if (Slot16_Achievement < 85)
                            lblSlot16Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot16Pass.Style.Add("color", "green");

                        EfficencyTotal = EfficencyTotal + 1;
                    }

                    else if (hdnEmptyMsg.Value != DBNull.Value.ToString())
                    {
                        HtmlTable tblEmptyMsg = (HtmlTable)e.Row.FindControl("tblEmptyMsg");
                        tblEmptyMsg.Visible = true;

                        e.Row.Cells[1].ColumnSpan = 26;
                        e.Row.Cells[2].Visible = false;
                        e.Row.Cells[3].Visible = false;
                        e.Row.Cells[4].Visible = false;
                        e.Row.Cells[5].Visible = false;
                        e.Row.Cells[6].Visible = false;
                        e.Row.Cells[7].Visible = false;
                        e.Row.Cells[8].Visible = false;
                        e.Row.Cells[9].Visible = false;
                        e.Row.Cells[10].Visible = false;
                        e.Row.Cells[11].Visible = false;
                        e.Row.Cells[12].Visible = false;
                        e.Row.Cells[13].Visible = false;
                        e.Row.Cells[14].Visible = false;
                        e.Row.Cells[15].Visible = false;
                        e.Row.Cells[16].Visible = false;
                        e.Row.Cells[17].Visible = false;
                        e.Row.Cells[18].Visible = false;
                        e.Row.Cells[19].Visible = false;

                    }

                }
                catch (Exception ex)
                {
                    string strError = ex.Message.ToString();
                    Application["HourlyError"] = strError.ToString();
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                try
                {
                    e.Row.Attributes.Add("class", "yellowFactory");
                    e.Row.Cells[24].Visible = false;
                    e.Row.Cells[25].Visible = false;
                    e.Row.Cells[26].Visible = false;
                    e.Row.Cells[27].Visible = false;

                    Label lblSlot1PassTotal = (Label)e.Row.FindControl("lblSlot1PassTotal");
                    if (Total_Slot1 != 0)
                    {
                        if (Total_Slot1 > 999)
                            lblSlot1PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot1) / 1000, 2).ToString() + "k";
                        else
                            lblSlot1PassTotal.Text = Total_Slot1.ToString("#,##0");
                    }

                    Label lblSlot2PassTotal = (Label)e.Row.FindControl("lblSlot2PassTotal");
                    if (Total_Slot2 != 0)
                    {
                        if (Total_Slot2 > 999)
                            lblSlot2PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot2) / 1000, 2).ToString() + "k";
                        else
                            lblSlot2PassTotal.Text = Total_Slot2.ToString("#,##0");
                    }

                    Label lblSlot3PassTotal = (Label)e.Row.FindControl("lblSlot3PassTotal");
                    if (Total_Slot3 != 0)
                    {
                        if (Total_Slot3 > 999)
                            lblSlot3PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot3) / 1000, 2).ToString() + "k";
                        else
                            lblSlot3PassTotal.Text = Total_Slot3.ToString("#,##0");
                    }

                    Label lblSlot4PassTotal = (Label)e.Row.FindControl("lblSlot4PassTotal");
                    if (Total_Slot4 != 0)
                    {
                        if (Total_Slot4 > 999)
                            lblSlot4PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot4) / 1000, 2).ToString() + "k";
                        else
                            lblSlot4PassTotal.Text = Total_Slot4.ToString("#,##0");
                    }

                    Label lblSlot5PassTotal = (Label)e.Row.FindControl("lblSlot5PassTotal");
                    if (Total_Slot5 != 0)
                    {
                        if (Total_Slot5 > 999)
                            lblSlot5PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot5) / 1000, 2).ToString() + "k";
                        else
                            lblSlot5PassTotal.Text = Total_Slot5.ToString("#,##0");
                    }

                    Label lblSlot6PassTotal = (Label)e.Row.FindControl("lblSlot6PassTotal");
                    if (Total_Slot6 != 0)
                    {
                        if (Total_Slot6 > 999)
                            lblSlot6PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot6) / 1000, 2).ToString() + "k";
                        else
                            lblSlot6PassTotal.Text = Total_Slot6.ToString("#,##0");
                    }

                    Label lblSlot7PassTotal = (Label)e.Row.FindControl("lblSlot7PassTotal");
                    if (Total_Slot7 != 0)
                    {
                        if (Total_Slot7 > 999)
                            lblSlot7PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot7) / 1000, 2).ToString() + "k";
                        else
                            lblSlot7PassTotal.Text = Total_Slot7.ToString("#,##0");

                    }

                    Label lblSlot8PassTotal = (Label)e.Row.FindControl("lblSlot8PassTotal");
                    if (Total_Slot8 != 0)
                    {
                        if (Total_Slot8 > 999)
                            lblSlot8PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot8) / 1000, 2).ToString() + "k";
                        else
                            lblSlot8PassTotal.Text = Total_Slot8.ToString("#,##0");
                    }

                    Label lblSlot9PassTotal = (Label)e.Row.FindControl("lblSlot9PassTotal");
                    if (Total_Slot9 != 0)
                    {
                        if (Total_Slot9 > 999)
                            lblSlot9PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot9) / 1000, 2).ToString() + "k";
                        else
                            lblSlot9PassTotal.Text = Total_Slot9.ToString("#,##0");

                    }

                    Label lblSlot10PassTotal = (Label)e.Row.FindControl("lblSlot10PassTotal");
                    if (Total_Slot10 != 0)
                    {
                        if (Total_Slot10 > 999)
                            lblSlot10PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot10) / 1000, 2).ToString() + "k";
                        else
                            lblSlot10PassTotal.Text = Total_Slot10.ToString("#,##0");
                    }

                    Label lblSlot11PassTotal = (Label)e.Row.FindControl("lblSlot11PassTotal");
                    if (Total_Slot11 != 0)
                    {
                        if (Total_Slot11 > 999)
                            lblSlot11PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot11) / 1000, 2).ToString() + "k";
                        else
                            lblSlot11PassTotal.Text = Total_Slot11.ToString("#,##0");

                    }

                    Label lblSlot12PassTotal = (Label)e.Row.FindControl("lblSlot12PassTotal");
                    if (Total_Slot12 != 0)
                    {
                        if (Total_Slot12 > 999)
                            lblSlot12PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot12) / 1000, 2).ToString() + "k";
                        else
                            lblSlot12PassTotal.Text = Total_Slot12.ToString("#,##0");

                    }
                    Label lblSlot13PassTotal = (Label)e.Row.FindControl("lblSlot13PassTotal");
                    if (Total_Slot13 != 0)
                    {
                        if (Total_Slot13 > 999)
                            lblSlot13PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot13) / 1000, 2).ToString() + "k";
                        else
                            lblSlot13PassTotal.Text = Total_Slot13.ToString("#,##0");
                    }
                    Label lblSlot14PassTotal = (Label)e.Row.FindControl("lblSlot14PassTotal");
                    if (Total_Slot14 != 0)
                    {
                        if (Total_Slot14 > 999)
                            lblSlot14PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot14) / 1000, 2).ToString() + "k";
                        else
                            lblSlot14PassTotal.Text = Total_Slot14.ToString("#,##0");
                    }

                    Label lblSlot15PassTotal = (Label)e.Row.FindControl("lblSlot15PassTotal");
                    if (Total_Slot15 != 0)
                    {
                        if (Total_Slot15 > 999)
                            lblSlot15PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot15) / 1000, 2).ToString() + "k";
                        else
                            lblSlot15PassTotal.Text = Total_Slot15.ToString("#,##0");
                    }
                    Label lblSlot16PassTotal = (Label)e.Row.FindControl("lblSlot16PassTotal");
                    if (Total_Slot16 != 0)
                    {
                        if (Total_Slot16 > 999)
                            lblSlot16PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot16) / 1000, 2).ToString() + "k";
                        else
                            lblSlot16PassTotal.Text = Total_Slot16.ToString("#,##0");
                    }
                    Label lblSlot1DHUTotal = (Label)e.Row.FindControl("lblSlot1DHUTotal");
                    if (Total_DHU1 != 0)
                        lblSlot1DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU1) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU1) / Convert.ToDouble(DHUCount), 0).ToString() + " %";

                    Label lblSlot2DHUTotal = (Label)e.Row.FindControl("lblSlot2DHUTotal");
                    if (Total_DHU2 != 0)
                        lblSlot2DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU2) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU2) / Convert.ToDouble(DHUCount), 0).ToString() + " %";

                    Label lblSlot3DHUTotal = (Label)e.Row.FindControl("lblSlot3DHUTotal");
                    if (Total_DHU3 != 0)
                        lblSlot3DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU3) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU3) / Convert.ToDouble(DHUCount), 0).ToString() + " %";

                    Label lblSlot4DHUTotal = (Label)e.Row.FindControl("lblSlot4DHUTotal");
                    if (Total_DHU4 != 0)
                        lblSlot4DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU4) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU4) / Convert.ToDouble(DHUCount), 0).ToString() + " %";

                    Label lblSlot5DHUTotal = (Label)e.Row.FindControl("lblSlot5DHUTotal");
                    if (Total_DHU5 != 0)
                        lblSlot5DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU5) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU5) / Convert.ToDouble(DHUCount), 0).ToString() + " %";

                    Label lblSlot6DHUTotal = (Label)e.Row.FindControl("lblSlot6DHUTotal");
                    if (Total_DHU6 != 0)
                        lblSlot6DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU6) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU6) / Convert.ToDouble(DHUCount), 0).ToString() + " %";

                    Label lblSlot7DHUTotal = (Label)e.Row.FindControl("lblSlot7DHUTotal");
                    if (Total_DHU7 != 0)
                        lblSlot7DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU7) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU7) / Convert.ToDouble(DHUCount), 0).ToString() + " %";

                    Label lblSlot8DHUTotal = (Label)e.Row.FindControl("lblSlot8DHUTotal");
                    if (Total_DHU8 != 0)
                        lblSlot8DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU8) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU8) / Convert.ToDouble(DHUCount), 0).ToString() + " %";

                    Label lblSlot9DHUTotal = (Label)e.Row.FindControl("lblSlot9DHUTotal");
                    if (Total_DHU9 != 0)
                        lblSlot9DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU9) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU9) / Convert.ToDouble(DHUCount), 0).ToString() + " %";

                    Label lblSlot10DHUTotal = (Label)e.Row.FindControl("lblSlot10DHUTotal");
                    if (Total_DHU10 != 0)
                        lblSlot10DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU10) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU10) / Convert.ToDouble(DHUCount), 0).ToString() + " %";

                    Label lblSlot11DHUTotal = (Label)e.Row.FindControl("lblSlot11DHUTotal");
                    if (Total_DHU11 != 0)
                        lblSlot11DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU11) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU11) / Convert.ToDouble(DHUCount), 0).ToString() + " %";

                    Label lblSlot12DHUTotal = (Label)e.Row.FindControl("lblSlot12DHUTotal");
                    if (Total_DHU12 != 0)
                        lblSlot12DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU12) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU12) / Convert.ToDouble(DHUCount), 0).ToString() + " %";

                    Label lblSlot13DHUTotal = (Label)e.Row.FindControl("lblSlot13DHUTotal");
                    if (Total_DHU13 != 0)
                        lblSlot13DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU13) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU13) / Convert.ToDouble(DHUCount), 0).ToString() + " %";

                    Label lblSlot14DHUTotal = (Label)e.Row.FindControl("lblSlot14DHUTotal");
                    if (Total_DHU14 != 0)
                        lblSlot14DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU14) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU14) / Convert.ToDouble(DHUCount), 0).ToString() + " %";

                    Label lblSlot15DHUTotal = (Label)e.Row.FindControl("lblSlot15DHUTotal");
                    if (Total_DHU15 != 0)
                        lblSlot15DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU15) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU15) / Convert.ToDouble(DHUCount), 0).ToString() + " %";

                    Label lblSlot16DHUTotal = (Label)e.Row.FindControl("lblSlot16DHUTotal");
                    if (Total_DHU16 != 0)
                        lblSlot16DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU16) / Convert.ToDouble(DHUCount), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU16) / Convert.ToDouble(DHUCount), 0).ToString() + " %";


                    double StchAvgPcs_Total = Math.Round(Convert.ToDouble(TodayPassPcsStitch_Total) / Convert.ToDouble(MaxStitchPassCount), 0);
                    double FinishAvgPcs_Total = Math.Round(Convert.ToDouble(TodayPassPcsFinish_Total) / Convert.ToDouble(MaxFinishPassCount), 0);

                    double StitchingPerPcsCost = Math.Round(((Convert.ToDouble(StitchActualOB_Total) * Convert.ToDouble(StichingPerOBCost)) / (Convert.ToDouble(StchAvgPcs_Total) == 0 ? 1 : Convert.ToDouble(StchAvgPcs_Total))), 0);

                    double CalculatedCMT = CuttingPerPcsCost + FactoryOverHeadPerPcs + StitchingPerPcsCost + FinishingPerPcsCost;

                    CostingCMT_Total = CostingCMT_Total / CMTCount;

                    double CalStitchingPerPcsCost = 0;

                    if (CalculatedCMT > CostingCMT_Total)
                    {
                        CalStitchingPerPcsCost = StitchingPerPcsCost - (CalculatedCMT - CostingCMT_Total);
                        TotalBreakEvenQty = Math.Round((StitchingPerPcsCost / (CalStitchingPerPcsCost == 0 ? 1 : CalStitchingPerPcsCost)) * Convert.ToDouble(StchAvgPcs_Total), 0);
                    }
                    else if (CalculatedCMT <= CostingCMT_Total)
                    {
                        CalStitchingPerPcsCost = StitchingPerPcsCost + (CostingCMT_Total - CalculatedCMT);
                        TotalBreakEvenQty = Math.Round((StitchingPerPcsCost / (CalStitchingPerPcsCost == 0 ? 1 : CalStitchingPerPcsCost)) * Convert.ToDouble(StchAvgPcs_Total), 0);
                    }

                    Label lblTodayPassStitch_Foo = (Label)e.Row.FindControl("lblTodayPassStitch_Foo");
                    Label lblTodayPassFinish_Foo = (Label)e.Row.FindControl("lblTodayPassFinish_Foo");
                    Label lblTodayAltPcs_Foo = (Label)e.Row.FindControl("lblTodayAltPcs_Foo");
                    Label lblTodayDHU_Foo = (Label)e.Row.FindControl("lblTodayDHU_Foo");
                    Label lblStchAvgPcsHr_foo = (Label)e.Row.FindControl("lblStchAvgPcsHr_foo");
                    Label lblFinishAvgPcs_foo = (Label)e.Row.FindControl("lblFinishAvgPcs_foo");
                    Label lblPercentPerformance_Foo = (Label)e.Row.FindControl("lblPercentPerformance_Foo");
                    Label lblTodayAchieved_Foo = (Label)e.Row.FindControl("lblTodayAchieved_Foo");

                    HtmlGenericControl dvFooter = (HtmlGenericControl)e.Row.FindControl("dvFooter");

                    if (TodayPassPcsFinish_Total != 0)
                    {
                        if (TodayPassPcsFinish_Total > 999)
                        {
                            double TodayPassPcsFinish_TotalNew = Math.Round(Convert.ToDouble(TodayPassPcsFinish_Total) / 1000, 1);
                            if (TodayPassPcsFinish_TotalNew > 99.9)
                                lblTodayPassFinish_Foo.Text = Math.Round(TodayPassPcsFinish_TotalNew, 0) + "k";
                            else
                                lblTodayPassFinish_Foo.Text = TodayPassPcsFinish_TotalNew.ToString() + "k";
                        }
                        else
                        {
                            lblTodayPassFinish_Foo.Text = TodayPassPcsFinish_Total.ToString("#,##0");
                        }
                    }

                    if (TodayPassPcsStitch_Total != 0)
                    {
                        if (TodayPassPcsStitch_Total > 999)
                        {
                            double TodayPassPcsStitch_TotalNew = Math.Round(Convert.ToDouble(TodayPassPcsStitch_Total) / 1000, 1);
                            if (TodayPassPcsStitch_TotalNew > 99.9)
                                lblTodayPassStitch_Foo.Text = Math.Round(TodayPassPcsStitch_TotalNew, 0).ToString() + "k";
                            else
                                lblTodayPassStitch_Foo.Text = TodayPassPcsStitch_TotalNew.ToString() + "k";
                        }
                        else
                        {
                            lblTodayPassStitch_Foo.Text = TodayPassPcsStitch_Total.ToString("#,##0");
                        }
                    }

                    if (TodayAltPcs_Total != 0)
                        lblTodayAltPcs_Foo.Text = TodayAltPcs_Total.ToString("#,##0");

                    if (DHU_Today_Total != 0)
                        lblTodayDHU_Foo.Text = Math.Round(Convert.ToDouble(DHU_Today_Total) / Convert.ToDouble(DHUCount), 0).ToString() + "%";
                    // Updated By Ravi kumar 19/nov/20
                    if (TodayAchieved_Total != 0)
                        lblTodayAchieved_Foo.Text = Math.Round(Convert.ToDouble(TodayAchieved_Total) / Convert.ToDouble(AchievementCount), 0).ToString() + "%";

                    AchievementCount = AchievementCount == 0 ? 1 : AchievementCount;

                    if (TodayAchieved_Total / AchievementCount > 0 && TodayAchieved_Total / AchievementCount < 81)
                    {
                        lblTodayAchieved_Foo.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblTodayAchieved_Foo.ForeColor = Color.Green;
                    }

                    //End

                    if ((TodayPassPcsStitch_Total != 0) && (MaxStitchPassCount != 0))
                    {
                        double StitchAvg_fooTotal = Convert.ToDouble(TodayPassPcsStitch_Total) / Convert.ToDouble(MaxStitchPassCount);
                        if (StitchAvg_fooTotal > 999)
                        {
                            StitchAvg_fooTotal = Math.Round(StitchAvg_fooTotal / 1000, 2);
                            if (StitchAvg_fooTotal > 99.9)
                            {
                                lblStchAvgPcsHr_foo.Text = "(" + Math.Round(StitchAvg_fooTotal, 0).ToString() + "k pphr)";
                            }
                            else
                            {
                                lblStchAvgPcsHr_foo.Text = "(" + StitchAvg_fooTotal.ToString() + "k pphr)";
                            }
                        }
                        else
                        {
                            lblStchAvgPcsHr_foo.Text = "(" + Math.Round(Convert.ToDouble(TodayPassPcsStitch_Total) / Convert.ToDouble(MaxStitchPassCount), 0).ToString("#,##0") + " pphr)";
                        }
                    }
                    if ((TodayPassPcsFinish_Total != 0) && (MaxFinishPassCount != 0))
                    {
                        double lblFinishAvgPcs_fooNew = Convert.ToDouble(TodayPassPcsFinish_Total) / Convert.ToDouble(MaxFinishPassCount);
                        if (lblFinishAvgPcs_fooNew > 999)
                        {
                            lblFinishAvgPcs_fooNew = Math.Round(lblFinishAvgPcs_fooNew / 1000, 2);
                            if (lblFinishAvgPcs_fooNew > 99.9)
                            {
                                lblFinishAvgPcs_foo.Text = "(" + Math.Round(lblFinishAvgPcs_fooNew, 0).ToString() + "k pphr)";
                            }
                            else
                            {
                                lblFinishAvgPcs_foo.Text = "(" + lblFinishAvgPcs_fooNew.ToString() + "k pphr)";
                            }
                        }
                        else
                        {
                            lblFinishAvgPcs_foo.Text = "(" + Math.Round(Convert.ToDouble(TodayPassPcsFinish_Total) / Convert.ToDouble(MaxFinishPassCount), 0).ToString("#,##0") + " pphr)";
                        }
                    }
                    if (PercentPerformance_Total != 0)
                        lblPercentPerformance_Foo.Text = Math.Round(Convert.ToDouble(PercentPerformance_Total) / Convert.ToDouble(PercentPerformanceCount), 0).ToString() + "%";


                    if (DHU_Today_Total > 5)
                    {
                        lblTodayDHU_Foo.Style.Add("color", "#FF0000");
                    }

                    if (DHU_Today_Total <= 5)
                    {
                        lblTodayDHU_Foo.Style.Add("color", "green");
                    }
                    // Footer merge section Bipl total
                    string StitchSAM_Foo = "";
                    string StchActOB_Foo = "";
                    string StchAgreedOB_Foo = "";
                    string FinActOB_Foo = "";
                    string FinAgreedOB_Foo = "";
                    string PkCpty_Foo = "";
                    string PkEff_Foo = "";
                    string COT_Foo = "";
                    string StchQty_Foo = "";
                    string FinQty_Foo = "";
                    string TargetEffTotal = "";
                    string TargetQtyTotal = "";
                    string BreakEvenQtyTotal = "";
                    string PeakCapcty_Finish_Foo = "";


                    // Finish Peak
                    if (PeakCapcty_Finish_Total != 0)
                    {
                        if (PeakCapcty_Finish_Total > 999)
                        {
                            double PeakCapcty_Finish_TotalNew = Math.Round(Convert.ToDouble(PeakCapcty_Finish_Total) / 1000, 2);
                            if (PeakCapcty_Finish_TotalNew > 99.9)
                                PeakCapcty_Finish_Foo = Math.Round(PeakCapcty_Finish_TotalNew, 0).ToString() + "k Pcs";
                            else
                                PeakCapcty_Finish_Foo = PeakCapcty_Finish_TotalNew.ToString() + "k Pcs";
                        }
                        else
                            PeakCapcty_Finish_Foo = PeakCapcty_Finish_Total.ToString("#,##0") + " Pcs";
                    }

                    string TotalPressActualOB = "";
                    if (PressActualOB_Total > 0)
                        TotalPressActualOB = "<font color='black'>(" + PressActualOB_Total.ToString() + ")</font>";

                    if (PeakOB_Finish_Total != 0)
                    {
                        FinAgreedOB_Foo = "(" + PeakOB_Finish_Total.ToString() + ")";

                    }
                    else
                    {
                        if (FinishOB_Total != 0)
                            FinAgreedOB_Foo = " (" + FinishOB_Total.ToString() + ")";

                    }

                    // End Finish section


                    if ((StitchSAM_TargetQty_Total != 0) && (TargetQty_Total != 0))
                        StitchSAM_Total = Math.Round(Convert.ToDouble(StitchSAM_TargetQty_Total) / Convert.ToDouble(TargetQty_Total), 0);

                    StitchSAM_Foo = StitchSAM_Total.ToString();

                    //Color on Actual OB
                    string styleClassObSt = "";
                    if (StitchActualOB_Total <= StitchOB_Total)
                        styleClassObSt = "ClassObStGreen";
                    else
                        styleClassObSt = "ClassObStRed";


                    if (StitchActualOB_Total != 0)
                        StchActOB_Foo = StitchActualOB_Total.ToString();

                    string clsFinActualOB = "";
                    if (FinishActualOB_Total <= FinishOB_Total)
                        clsFinActualOB = "actObGreen";
                    else
                        clsFinActualOB = "actObRed";


                    if (FinishActualOB_Total != 0)
                        FinActOB_Foo = FinishActualOB_Total.ToString();


                    if (PeakCapecity_Total != 0)
                    {
                        if (PeakCapecity_Total > 999)
                        {
                            Double PeakCapecity_TotalNew = Math.Round(Convert.ToDouble(PeakCapecity_Total) / 1000, 2);
                            if (PeakCapecity_TotalNew > 99.9)
                                PkCpty_Foo = Math.Round(PeakCapecity_TotalNew, 0).ToString() + "k Pcs";
                            else
                                PkCpty_Foo = PeakCapecity_TotalNew.ToString() + "k Pcs";
                        }
                        else
                            PkCpty_Foo = Math.Round(Convert.ToDouble(PeakCapecity_Total), 0).ToString("#,##0") + " Pcs";
                    }
                    string styleClassAgrdSt = "";
                    if (PeakOB_Total != 0)
                    {
                        StchAgreedOB_Foo = " (" + Math.Round(Convert.ToDouble(PeakOB_Total), 0).ToString() + ")";
                        styleClassAgrdSt = "AgrdOBBlue";
                    }
                    else
                    {
                        if (StitchOB_Total != 0)
                            StchAgreedOB_Foo = " (" + StitchOB_Total.ToString() + ")";
                        styleClassAgrdSt = "AgrdOBBlack";
                    }

                    if (PeakEff_Total != 0)
                        PkEff_Foo = " (" + Math.Round(Convert.ToDouble(PeakEff_Total) / Convert.ToDouble(PeakEffCount), 0).ToString() + "%)";
                    if (COTValue_Total != 0)
                        COT_Foo = Math.Round(Convert.ToDouble(COTValue_Total) / Convert.ToDouble(COTValueCount), 0).ToString();

                    if (StitchQty_Total != 0)
                        StchQty_Foo = StitchQty_Total.ToString("#,##0");
                    if (FinishQty_Total != 0)
                        FinQty_Foo = FinishQty_Total.ToString("#,##0");

                    if (StitchActualOB_Total > 0)
                        TargetEffTotal = Math.Round((Convert.ToDouble(TargetQty_Total * StitchSAM_Total) / Convert.ToDouble(StitchActualOB_Total * 60)) * 100, 0).ToString() + "%";

                    if (TargetQty_Total != 0)
                    {
                        if (TargetQty_Total > 999)
                        {
                            double TargetQty_TotalNew = Math.Round(Convert.ToDouble(TargetQty_Total) / 1000, 2);
                            if (TargetQty_TotalNew > 99.9)
                                TargetQtyTotal = Math.Round(TargetQty_TotalNew, 0).ToString() + "k Pcs";
                            else
                                TargetQtyTotal = TargetQty_TotalNew.ToString() + "k Pcs";
                        }
                        else
                            TargetQtyTotal = TargetQty_Total.ToString("#,##0") + " Pcs";
                    }

                    if (TotalBreakEvenQty > 0)
                    {
                        if (TotalBreakEvenQty > 999)
                        {
                            BreakEvenQtyTotal = Math.Round(TotalBreakEvenQty / 1000, 2).ToString() + "k Pcs";
                        }
                        else
                        {
                            BreakEvenQtyTotal = TotalBreakEvenQty.ToString("#,##0") + " Pcs";
                        }
                    }

                    if (ViewState["dtStitchEff"] != null)
                    {
                        DataTable dtBIPLWIP = (DataTable)ViewState["dtStitchEff"];
                        // WIP BIPL
                        WIPBIPL_Cutting = dtBIPLWIP.Rows[0]["WIPBIPL_Cutting"].ToString() == "0" ? 0 : Convert.ToDouble(dtBIPLWIP.Rows[0]["WIPBIPL_Cutting"]);

                        WIPBIPL_Stitching = dtBIPLWIP.Rows[0]["WIPBIPL_Stitching"].ToString() == "0" ? 0 : Convert.ToDouble(dtBIPLWIP.Rows[0]["WIPBIPL_Stitching"]);

                        WIPBIPL_Finishing = dtBIPLWIP.Rows[0]["WIPBIPL_Finishing"].ToString() == "0" ? 0 : Convert.ToDouble(dtBIPLWIP.Rows[0]["WIPBIPL_Finishing"]);

                        WIPBIPL_Fabric1CheckedQty = dtBIPLWIP.Rows[0]["WIPBIPL_Fabric1CheckedQty"].ToString() == "0" ? 0 : Convert.ToDouble(dtBIPLWIP.Rows[0]["WIPBIPL_Fabric1CheckedQty"]);

                        WIPBIPL_PrevStitching = dtBIPLWIP.Rows[0]["WIPBIPL_PrevStitching"].ToString() == "0" ? 0 : Convert.ToDouble(dtBIPLWIP.Rows[0]["WIPBIPL_PrevStitching"]);

                        WIPBIPL_PrevFinishing = dtBIPLWIP.Rows[0]["WIPBIPL_PrevFinishing"].ToString() == "0" ? 0 : Convert.ToDouble(dtBIPLWIP.Rows[0]["WIPBIPL_PrevFinishing"]);
                    }

                    if (WIPBIPL_PrevStitching == 0)
                        WIPBIPL_PrevStitching = 1;

                    double WIPCutting_Foo = Math.Round((Convert.ToDouble(WIPBIPL_Fabric1CheckedQty) - Convert.ToDouble(WIPBIPL_Cutting)) / Convert.ToDouble(WIPBIPL_PrevStitching), 0);
                    double WIPStitching_Foo = Math.Round((Convert.ToDouble(WIPBIPL_Cutting) - Convert.ToDouble(WIPBIPL_Stitching)) / Convert.ToDouble(WIPBIPL_PrevStitching), 0);

                    if (WIPBIPL_PrevFinishing == 0)
                        WIPBIPL_PrevFinishing = 1;
                    double WIPFinished_Foo = Math.Round((Convert.ToDouble(WIPBIPL_Stitching) - Convert.ToDouble(WIPBIPL_Finishing)) / Convert.ToDouble(WIPBIPL_PrevFinishing), 0);


                    double WIPCutQty_InProgressFoo = Math.Round((Convert.ToDouble(WIPBIPL_Fabric1CheckedQty) - Convert.ToDouble(WIPBIPL_Cutting)) / 1000, 0);
                    double WIPStitchQty_InProgressFoo = Math.Round((Convert.ToDouble(WIPBIPL_Cutting) - Convert.ToDouble(WIPBIPL_Stitching)) / 1000, 0);
                    double WIPFinishQty_InProgressFoo = Math.Round((Convert.ToDouble(WIPBIPL_Stitching) - Convert.ToDouble(WIPBIPL_Finishing)) / 1000, 0);

                    string clsWIPStitchBack = "";

                    if ((TodayPassPcsStitch_Total != 0) && (MaxStitchPassCount != 0))
                    {
                        double StitchAvg_foo = Convert.ToDouble(TodayPassPcsStitch_Total) / Convert.ToDouble(MaxStitchPassCount);

                        if ((WIPStitchQty_InProgressFoo > 0) && (StitchAvg_foo > 0))
                        {
                            double StitchWipInProgress = WIPStitchQty_InProgressFoo * 1000;
                            if ((StitchWipInProgress / Convert.ToDouble(StitchAvg_foo)) > 33)
                                clsWIPStitchBack = "WIPGreenBack";
                            else
                                clsWIPStitchBack = "WIPRedBack";
                        }
                        else if ((WIPStitchQty_InProgressFoo > 0) && (StitchAvg_foo <= 0))
                        {
                            clsWIPStitchBack = "WIPGreenBack";
                        }
                        else if ((WIPStitchQty_InProgressFoo <= 0) && (StitchAvg_foo > 0))
                        {
                            clsWIPStitchBack = "WIPRedBack";
                        }
                    }

                    string sWIPCutQty_InProgressFoo = WIPCutQty_InProgressFoo <= 0 ? "" : WIPCutQty_InProgressFoo.ToString() + "k";
                    string sWIPStitchQty_InProgressFoo = WIPStitchQty_InProgressFoo <= 0 ? "" : WIPStitchQty_InProgressFoo.ToString() + "k";
                    string sWIPFinishQty_InProgressFoo = WIPFinishQty_InProgressFoo <= 0 ? "" : WIPFinishQty_InProgressFoo.ToString() + "k";

                    string clsBreakEvenQty = "", FinQtyVal_footer = "";


                    if (FinishingPerOBCost > 0 && FinishActualOB_Total > 0)
                    {
                        double FinishFooterValue = Math.Round(((Convert.ToDouble(FinishingPerOBCost) * FinishActualOB_Total) / 10), 0);
                        if (FinishFooterValue > 999)
                        {
                            FinQtyVal_footer = Math.Round(FinishFooterValue / 1000, 2).ToString() + "k";
                        }
                        else
                        {
                            FinQtyVal_footer = Math.Round(((Convert.ToDouble(FinishingPerOBCost) * FinishActualOB_Total) / 10), 0).ToString();
                        }
                    }

                    if (TotalBreakEvenQty <= Factory_StchAvgPcs)
                        clsBreakEvenQty = "WIPGreen";
                    else
                        clsBreakEvenQty = "WIPRed";

                    string tablestring = "";

                    tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' width='220px' border='0' style='border-collapse:collapse;'>";

                    tablestring = tablestring + "<tr> <td  height='20px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; width:100%; text-align:center;'><table cellpadding='0' cellpadding='0' cellspacing='0' width='100%' border='0'> <tr> <td style='width:20%; border-right:1px solid #bfbfbf;height:20px;text-align:center; color:black; font-weight:bold;'>&nbsp; </td> <td style='width:30%; border-right:1px solid #bfbfbf;height:15px;text-align:center;'>&nbsp;</td> <td style='width:50%;height:15px;text-align:center;'>&nbsp;</td></tr></table></td> </tr>";
                    tablestring = tablestring + "<tr> <td  height='20px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; width:100%; text-align:center;'><table cellpadding='0' cellpadding='0' cellspacing='0' width='100%' border='0'> <tr> <td style='width:25%; border-right:1px solid #bfbfbf;height:20px;text-align:center; color:black; font-weight:bold;'>&nbsp;</td><td style='font-weight:bold; width:30%' class=" + clsBreakEvenQty + ">" + BreakEvenQtyTotal + "</td></td> <td style='width:20%; border-right:1px solid #bfbfbf;height:20px;text-align:center;font-size:11px'><b style='color:black'>" + TargetEffTotal + "</b></td> <td style='width:25%;height:20px;text-align:center;background:#90EE90; color:black;font-size: 11px !important;'>" + TargetQtyTotal + "</td> </tr></table></tr>";

                    tablestring = tablestring + "<tr> <td  height='20px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; width:210px; text-align:center;'><table cellpadding='0' cellpadding='0' cellspacing='0' width='100%' border='0'> <tr> <td style='width:25%; border-right:1px solid #bfbfbf;height:15px;text-align:center; color:black; font-weight:bold;'>" + StitchSAM_Foo + "  </td> <td style='width:25%; border-right:1px solid #bfbfbf;height:20px;text-align:center;'>";
                    tablestring = tablestring + " <span id='lblStchActOB_Foo' class=" + styleClassObSt + " >" + StchActOB_Foo + "  </span> <span id='lblStchAgreedOB_Foo' class=" + styleClassAgrdSt + " >" + StchAgreedOB_Foo + " </span></td> <td style='width:25%;height:20px;text-align:center;border-right:1px solid #bfbfbf;'>" + PkCpty_Foo + " <span style='color:gray;'>" + PkEff_Foo + " </span></td><td style='width:25%; height:20px;text-align:center; font-weight:bold;'>";
                    tablestring = tablestring + "<span id='lblFinActOB_Foo' class=" + clsFinActualOB + " >" + FinActOB_Foo + "</span> " + TotalPressActualOB + " </td></tr></table></td> </tr>";

                    tablestring = tablestring + "<tr> <td  height='14px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; width:210px; text-align:center;'><table cellpadding='0' cellpadding='0' cellspacing='0' width='100%' border='0'> <tr><td style='width:25%; border-right:1px solid #bfbfbf;height:20px;text-align:center;'>&nbsp;</td><td style='width:25%;height:20px;text-align:center;border-right:1px solid #bfbfbf;'><span style='color:black; font-weight:bold;'>" + sWIPCutQty_InProgressFoo + "</span></td> <td class='" + clsWIPStitchBack + "' style='width:25%; border-right:1px solid #bfbfbf;height:20px;text-align:center;'>&nbsp; <span style='color:yellow; font-size:11px; font-weight:bold;'> " + sWIPStitchQty_InProgressFoo + "</span></td> <td height='20px' style='width:25%; height:15px;text-align:center;border-right:1px solid #bfbfbf;'> <span style='color:black; font-weight:bold;'> " + sWIPFinishQty_InProgressFoo + " </span> </td></tr></table> </td> </tr>";

                    tablestring = tablestring + "<tr> <td height='20px' style='border-right:1px solid #bfbfbf; ' ><h3 style='font-weight:normal; font-size:12px; padding:0px; margin:0px; text-align:center;'> Efficiency  </h3> </td>  </tr>";

                    tablestring = tablestring + "<tr> <td height='20px' style='border-right:1px solid #bfbfbf; border-top:1px solid #bfbfbf;' ><h3 style='font-weight:normal; font-size:12px; padding:0px; margin:0px; text-align:center;'> Achievement  </h3> </td>  </tr>";

                    tablestring = tablestring + "<tr> <td height='20px' style='border-right:1px solid #bfbfbf; border-top:1px solid #bfbfbf;' ><h3 style='font-weight:normal; font-size:12px; padding:0px; margin:0px; text-align:center;'> BIPL Price  </h3> </td>  </tr>";

                    tablestring = tablestring + "<tr> <td height='20px' style='border-right:1px solid #bfbfbf; border-top:1px solid #bfbfbf;' ><h3 style='font-weight:normal; font-size:12px; padding:0px; margin:0px; text-align:center;'> CMT %  </h3> </td>  </tr>";

                    tablestring = tablestring + "</table>";
                    dvFooter.InnerHtml = tablestring;

                    Label lblLineFinishQty_Foo = (Label)e.Row.FindControl("lblLineFinishQty_Foo");
                    Label lblLineStitchQty_Foo = (Label)e.Row.FindControl("lblLineStitchQty_Foo");
                    Label lblLineAltVal_Foo = (Label)e.Row.FindControl("lblLineAltVal_Foo");
                    Label lblLineDHU_Foo = (Label)e.Row.FindControl("lblLineDHU_Foo");

                    Label lblTodayEff_Stitch_Foo = (Label)e.Row.FindControl("lblTodayEff_Stitch_Foo");
                    Label lblStyleEff_Finish_Foo = (Label)e.Row.FindControl("lblStyleEff_Finish_Foo");
                    Label lblStyleEff_Stitch_Foo = (Label)e.Row.FindControl("lblStyleEff_Stitch_Foo");

                    Label lblOrderQty_Foo = (Label)e.Row.FindControl("lblOrderQty_Foo");
                    Label lblFabQty_Foo = (Label)e.Row.FindControl("lblFabQty_Foo");
                    Label lblCutQty_Foo = (Label)e.Row.FindControl("lblCutQty_Foo");
                    Label lblStitchQty_Foo = (Label)e.Row.FindControl("lblStitchQty_Foo");
                    Label lblFinishQty_Foo = (Label)e.Row.FindControl("lblFinishQty_Foo");
                    lblTodayEff_Stitch_Foo.Font.Bold = true;
                    lblTodayEff_Stitch_Foo.Style.Add("font-size", "12px");

                    if ((StyleEfficiency_Stitch_Total != 0) || (StyleEfficiency_Stitch_Total != -1))
                        lblStyleEff_Stitch_Foo.Text = "(" + Math.Round(Convert.ToDouble(StyleEfficiency_Stitch_Total) / Convert.ToDouble(StyleEffCount), 0).ToString() + "%)";

                    if (OrderQty_Total != 0)
                    {
                        if (OrderQty_Total > 999)
                        {
                            double OrderQty_TotalNew = Math.Round(Convert.ToDouble(OrderQty_Total) / 1000, 2);
                            if (OrderQty_TotalNew > 99.9)
                                lblOrderQty_Foo.Text = Math.Round(OrderQty_TotalNew, 0).ToString("#,##0") + "k";
                            else
                                lblOrderQty_Foo.Text = OrderQty_TotalNew.ToString("#,##0") + "k";
                        }
                        else
                        {
                            lblOrderQty_Foo.Text = OrderQty_Total.ToString("#,##0");
                        }
                    }
                    if (FabricQty_Total != 0)
                    {
                        if (FabricQty_Total > 999)
                        {
                            double FabricQty_TotalNew = Math.Round(Convert.ToDouble(FabricQty_Total) / 1000, 2);
                            if (FabricQty_TotalNew > 99.9)
                                lblFabQty_Foo.Text = Math.Round(FabricQty_TotalNew, 0).ToString() + "k";
                            else
                                lblFabQty_Foo.Text = FabricQty_TotalNew.ToString() + "k";
                        }
                        else
                        {
                            lblFabQty_Foo.Text = FabricQty_Total.ToString("#,##0");
                        }
                    }
                    if (CutQty_Total != 0)
                    {
                        if (CutQty_Total > 999)
                        {
                            double CutQty_TotalNew = Math.Round(Convert.ToDouble(CutQty_Total) / 1000, 2);
                            if (CutQty_TotalNew > 99.9)
                                lblCutQty_Foo.Text = Math.Round(CutQty_TotalNew, 0).ToString() + "k";
                            else
                                lblCutQty_Foo.Text = CutQty_TotalNew.ToString() + "k";
                        }
                        else
                            lblCutQty_Foo.Text = CutQty_Total.ToString("#,##0");
                    }

                    if (StitchQty_Total != 0)
                    {
                        if (StitchQty_Total > 999)
                        {
                            double StitchQty_TotalNew = Math.Round(Convert.ToDouble(StitchQty_Total) / 1000, 2);
                            if (StitchQty_TotalNew > 99.9)
                                lblStitchQty_Foo.Text = Math.Round(StitchQty_TotalNew, 0).ToString() + "k";
                            else
                                lblStitchQty_Foo.Text = StitchQty_TotalNew.ToString() + "k";
                        }
                        else
                            lblStitchQty_Foo.Text = StitchQty_Total.ToString("#,##0");
                    }

                    if (FinishQty_Total != 0)
                    {
                        if (FinishQty_Total > 999)
                        {
                            double FinishQty_TotalNew = Math.Round(Convert.ToDouble(FinishQty_Total) / 1000, 2);
                            if (FinishQty_TotalNew > 99.9)
                                lblFinishQty_Foo.Text = "(" + Math.Round(FinishQty_TotalNew, 0).ToString() + "k)";
                            else
                                lblFinishQty_Foo.Text = "(" + FinishQty_TotalNew.ToString() + "k)";
                        }
                        else
                            lblFinishQty_Foo.Text = "(" + FinishQty_Total.ToString("#,##0") + ")";
                    }

                    double TotalOrderQty_With5Percent = Math.Round(Convert.ToDouble(OrderQty_Total) + (Convert.ToDouble(OrderQty_Total) * 5) / 100, 0);

                    if (Convert.ToDouble(CutQty_Total) > TotalOrderQty_With5Percent)
                        lblCutQty_Foo.Style.Add("color", "red");
                    else
                        lblCutQty_Foo.Style.Add("color", "black");

                    if (Convert.ToDouble(FabricQty_Total) > TotalOrderQty_With5Percent)
                        lblFabQty_Foo.Style.Add("color", "red");
                    else
                        lblFabQty_Foo.Style.Add("color", "black");

                    Label lblFInishCost_total = (Label)e.Row.FindControl("lblFInishCost_total");
                    HiddenField hdnFinishCost_total = (HiddenField)e.Row.FindControl("hdnFinishCost_total");
                    HtmlControl tdFinishCost_footer = (HtmlControl)e.Row.FindControl("tdFinishCost_footer");
                    if (BIPLTotalTodayFinishObatLineCluster > 0 && TodayPassFinish_BIPL > 0)
                    {
                        lblFInishCost_total.Text = "&#8377;" + Math.Round(((Convert.ToDouble(BIPLTotalTodayFinishObatLineCluster) * FinishingPerOBCost) / TodayPassFinish_BIPL), 0).ToString();
                        hdnFinishCost_total.Value = Math.Round(((Convert.ToDouble(BIPLTotalTodayFinishObatLineCluster) * FinishingPerOBCost) / TodayPassFinish_BIPL), 0).ToString();

                        if (Math.Round(((Convert.ToDouble(BIPLTotalTodayFinishObatLineCluster) * FinishingPerOBCost) / TodayPassFinish_BIPL), 0) <= 10)
                            lblFInishCost_total.Style.Add("color", "green");
                        else
                            lblFInishCost_total.Style.Add("color", "#FF0000");

                        if (Math.Round(((Convert.ToDouble(BIPLTotalTodayFinishObatLineCluster) * FinishingPerOBCost) / TodayPassFinish_BIPL), 0) <= 12)
                            lblTodayPassFinish_Foo.Style.Add("color", "green");
                        else
                            lblTodayPassFinish_Foo.Style.Add("color", "#FF0000");
                    }
                    else
                    {
                        lblTodayPassFinish_Foo.Style.Add("color", "Black");
                    }
                    //End of Prabhaker               

                    if (DHU_Today_Total > 5)
                        lblTodayAltPcs_Foo.Style.Add("color", "#FF0000");
                    if (DHU_Today_Total <= 5)
                        lblTodayAltPcs_Foo.Style.Add("color", "green");

                    // updated By Prabhaker
                    if (PercentPerformance_Total < 85)
                        lblPercentPerformance_Foo.Style.Add("color", "Red");
                    else
                        lblPercentPerformance_Foo.Style.Add("color", "green");


                    if (Convert.ToInt32(TargetQty_Total) > 0)
                    {
                        if (Math.Round((Convert.ToDouble(StchAvgPcs_Total) / Convert.ToDouble(TargetQty_Total)) * 100, 0) > 85)
                        {
                            lblTodayPassStitch_Foo.Style.Add("color", "green");
                            lblTodayEff_Stitch_Foo.Style.Add("color", "green");
                        }
                        else
                        {
                            lblTodayPassStitch_Foo.Style.Add("color", "#FF0000");
                            lblTodayEff_Stitch_Foo.Style.Add("color", "#FF0000");
                        }
                    }
                    else
                    {
                        lblTodayPassStitch_Foo.Style.Add("color", "Black");
                        lblTodayEff_Stitch_Foo.Style.Add("color", "Black");
                    }

                    HtmlTableCell tdSlot1PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot1PassTotal");
                    HtmlTableCell tdSlot2PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot2PassTotal");
                    HtmlTableCell tdSlot3PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot3PassTotal");
                    HtmlTableCell tdSlot4PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot4PassTotal");
                    HtmlTableCell tdSlot5PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot5PassTotal");
                    HtmlTableCell tdSlot6PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot6PassTotal");
                    HtmlTableCell tdSlot7PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot7PassTotal");
                    HtmlTableCell tdSlot8PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot8PassTotal");

                    HtmlTableCell tdSlot9PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot9PassTotal");
                    HtmlTableCell tdSlot10PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot10PassTotal");
                    HtmlTableCell tdSlot11PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot11PassTotal");
                    HtmlTableCell tdSlot12PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot12PassTotal");
                    HtmlTableCell tdSlot13PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot13PassTotal");
                    HtmlTableCell tdSlot14PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot14PassTotal");
                    HtmlTableCell tdSlot15PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot15PassTotal");
                    HtmlTableCell tdSlot16PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot16PassTotal");

                    Label lbl1StitchEff_Foo = (Label)e.Row.FindControl("lbl1StitchEff_Foo");
                    Label lbl2StitchEff_Foo = (Label)e.Row.FindControl("lbl2StitchEff_Foo");
                    Label lbl3StitchEff_Foo = (Label)e.Row.FindControl("lbl3StitchEff_Foo");
                    Label lbl4StitchEff_Foo = (Label)e.Row.FindControl("lbl4StitchEff_Foo");
                    Label lbl5StitchEff_Foo = (Label)e.Row.FindControl("lbl5StitchEff_Foo");
                    Label lbl6StitchEff_Foo = (Label)e.Row.FindControl("lbl6StitchEff_Foo");
                    Label lbl7StitchEff_Foo = (Label)e.Row.FindControl("lbl7StitchEff_Foo");
                    Label lbl8StitchEff_Foo = (Label)e.Row.FindControl("lbl8StitchEff_Foo");
                    Label lbl9StitchEff_Foo = (Label)e.Row.FindControl("lbl9StitchEff_Foo");
                    Label lbl10StitchEff_Foo = (Label)e.Row.FindControl("lbl10StitchEff_Foo");
                    Label lbl11StitchEff_Foo = (Label)e.Row.FindControl("lbl11StitchEff_Foo");
                    Label lbl12StitchEff_Foo = (Label)e.Row.FindControl("lbl12StitchEff_Foo");
                    Label lbl13StitchEff_Foo = (Label)e.Row.FindControl("lbl13StitchEff_Foo");
                    Label lbl14StitchEff_Foo = (Label)e.Row.FindControl("lbl14StitchEff_Foo");
                    Label lbl15StitchEff_Foo = (Label)e.Row.FindControl("lbl15StitchEff_Foo");
                    Label lbl16StitchEff_Foo = (Label)e.Row.FindControl("lbl16StitchEff_Foo");

                    if (ViewState["dtStitchEff"] != null)
                    {

                        DataTable dtStitchEff = (DataTable)ViewState["dtStitchEff"];

                        Total_StitchEff1 = dtStitchEff.Rows[0]["Slot1Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot1Stitch_Eff"]);

                        Total_StitchEff2 = dtStitchEff.Rows[0]["Slot2Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot2Stitch_Eff"]);

                        Total_StitchEff3 = dtStitchEff.Rows[0]["Slot3Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot3Stitch_Eff"]);

                        Total_StitchEff4 = dtStitchEff.Rows[0]["Slot4Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot4Stitch_Eff"]);

                        Total_StitchEff5 = dtStitchEff.Rows[0]["Slot5Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot5Stitch_Eff"]);

                        Total_StitchEff6 = dtStitchEff.Rows[0]["Slot6Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot6Stitch_Eff"]);

                        Total_StitchEff7 = dtStitchEff.Rows[0]["Slot7Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot7Stitch_Eff"]);

                        Total_StitchEff8 = dtStitchEff.Rows[0]["Slot8Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot8Stitch_Eff"]);

                        Total_StitchEff9 = dtStitchEff.Rows[0]["Slot9Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot9Stitch_Eff"]);

                        Total_StitchEff10 = dtStitchEff.Rows[0]["Slot10Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot10Stitch_Eff"]);

                        Total_StitchEff11 = dtStitchEff.Rows[0]["Slot11Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot11Stitch_Eff"]);

                        Total_StitchEff12 = dtStitchEff.Rows[0]["Slot12Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot12Stitch_Eff"]);

                        Total_StitchEff13 = dtStitchEff.Rows[0]["Slot13Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot13Stitch_Eff"]);

                        Total_StitchEff14 = dtStitchEff.Rows[0]["Slot14Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot14Stitch_Eff"]);

                        Total_StitchEff15 = dtStitchEff.Rows[0]["Slot15Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot15Stitch_Eff"]);

                        Total_StitchEff16 = dtStitchEff.Rows[0]["Slot16Stitch_Eff"].ToString() == "0" ? 0 : Convert.ToDouble(dtStitchEff.Rows[0]["Slot16Stitch_Eff"]);

                        BIPL_Efficiency = dtStitchEff.Rows[0]["TodayEfficiency_BIPL"].ToString() == "0" ? 0 : Convert.ToInt32(dtStitchEff.Rows[0]["TodayEfficiency_BIPL"]);

                    }

                    //////
                    lbl1StitchEff_Foo.Text = Total_StitchEff1 == 0 ? "" : Total_StitchEff1.ToString() + "%";

                    lbl2StitchEff_Foo.Text = Total_StitchEff2 == 0 ? "" : Total_StitchEff2.ToString() + "%";

                    lbl3StitchEff_Foo.Text = Total_StitchEff3 == 0 ? "" : Total_StitchEff3.ToString() + "%";

                    lbl4StitchEff_Foo.Text = Total_StitchEff4 == 0 ? "" : Total_StitchEff4.ToString() + "%";

                    lbl5StitchEff_Foo.Text = Total_StitchEff5 == 0 ? "" : Total_StitchEff5.ToString() + "%";

                    lbl6StitchEff_Foo.Text = Total_StitchEff6 == 0 ? "" : Total_StitchEff6.ToString() + "%";

                    lbl7StitchEff_Foo.Text = Total_StitchEff7 == 0 ? "" : Total_StitchEff7.ToString() + "%";

                    lbl8StitchEff_Foo.Text = Total_StitchEff8 == 0 ? "" : Total_StitchEff8.ToString() + "%";

                    lbl9StitchEff_Foo.Text = Total_StitchEff9 == 0 ? "" : Total_StitchEff9.ToString() + "%";

                    lbl10StitchEff_Foo.Text = Total_StitchEff10 == 0 ? "" : Total_StitchEff10.ToString() + "%";

                    lbl11StitchEff_Foo.Text = Total_StitchEff11 == 0 ? "" : Total_StitchEff11.ToString() + "%";

                    lbl12StitchEff_Foo.Text = Total_StitchEff12 == 0 ? "" : Total_StitchEff12.ToString() + "%";

                    lbl13StitchEff_Foo.Text = Total_StitchEff13 == 0 ? "" : Total_StitchEff13.ToString() + "%";

                    lbl14StitchEff_Foo.Text = Total_StitchEff14 == 0 ? "" : Total_StitchEff14.ToString() + "%";

                    lbl15StitchEff_Foo.Text = Total_StitchEff15 == 0 ? "" : Total_StitchEff15.ToString() + "%";

                    lbl16StitchEff_Foo.Text = Total_StitchEff16 == 0 ? "" : Total_StitchEff16.ToString() + "%";

                    lblTodayEff_Stitch_Foo.Text = BIPL_Efficiency == 0 ? "" : BIPL_Efficiency.ToString() + "%";

                    if (FactoryTotal == 0)
                        FactoryTotal = 1;

                    // Achievement 

                    Label lbl1Achieved_Foo = (Label)e.Row.FindControl("lbl1Achieved_Foo");
                    Label lbl2Achieved_Foo = (Label)e.Row.FindControl("lbl2Achieved_Foo");
                    Label lbl3Achieved_Foo = (Label)e.Row.FindControl("lbl3Achieved_Foo");
                    Label lbl4Achieved_Foo = (Label)e.Row.FindControl("lbl4Achieved_Foo");
                    Label lbl5Achieved_Foo = (Label)e.Row.FindControl("lbl5Achieved_Foo");
                    Label lbl6Achieved_Foo = (Label)e.Row.FindControl("lbl6Achieved_Foo");
                    Label lbl7Achieved_Foo = (Label)e.Row.FindControl("lbl7Achieved_Foo");
                    Label lbl8Achieved_Foo = (Label)e.Row.FindControl("lbl8Achieved_Foo");
                    Label lbl9Achieved_Foo = (Label)e.Row.FindControl("lbl9Achieved_Foo");
                    Label lbl10Achieved_Foo = (Label)e.Row.FindControl("lbl10Achieved_Foo");
                    Label lbl11Achieved_Foo = (Label)e.Row.FindControl("lbl11Achieved_Foo");
                    Label lbl12Achieved_Foo = (Label)e.Row.FindControl("lbl12Achieved_Foo");
                    Label lbl13Achieved_Foo = (Label)e.Row.FindControl("lbl13Achieved_Foo");
                    Label lbl14Achieved_Foo = (Label)e.Row.FindControl("lbl14Achieved_Foo");
                    Label lbl15Achieved_Foo = (Label)e.Row.FindControl("lbl15Achieved_Foo");
                    Label lbl16Achieved_Foo = (Label)e.Row.FindControl("lbl16Achieved_Foo");
                    //Updated By Prabhaker

                    if (ViewState["dtAchievement"] != null)
                    {
                        double TotalAchievement1 = 0, TotalAchievement2 = 0, TotalAchievement3 = 0, TotalAchievement4 = 0, TotalAchievement5 = 0, TotalAchievement6 = 0, TotalAchievement7 = 0, TotalAchievement8 = 0,
                            TotalAchievement9 = 0, TotalAchievement10 = 0, TotalAchievement11 = 0, TotalAchievement12 = 0, TotalAchievement13 = 0, TotalAchievement14 = 0, TotalAchievement15 = 0, TotalAchievement16 = 0;

                        DataTable dtAchievement = (DataTable)ViewState["dtAchievement"];

                        double Slot1OB = dtAchievement.Rows[0]["Slot1OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot1OB"]);
                        double Slot1WeightedEff = dtAchievement.Rows[0]["Slot1WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot1WeightedEff"]);
                        if (Slot1OB > 0)
                        {
                            TotalAchievement1 = Math.Round(Total_StitchEff1 / (Slot1WeightedEff / Slot1OB), 0);
                        }

                        double Slot2OB = dtAchievement.Rows[0]["Slot2OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot2OB"]);
                        double Slot2WeightedEff = dtAchievement.Rows[0]["Slot2WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot2WeightedEff"]);
                        if (Slot2OB > 0)
                        {
                            TotalAchievement2 = Math.Round(Total_StitchEff2 / (Slot2WeightedEff / Slot2OB), 0);
                        }

                        double Slot3OB = dtAchievement.Rows[0]["Slot3OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot3OB"]);
                        double Slot3WeightedEff = dtAchievement.Rows[0]["Slot3WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot3WeightedEff"]);
                        if (Slot3OB > 0)
                        {
                            TotalAchievement3 = Math.Round(Total_StitchEff3 / (Slot3WeightedEff / Slot3OB), 0);
                        }

                        double Slot4OB = dtAchievement.Rows[0]["Slot4OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot4OB"]);
                        double Slot4WeightedEff = dtAchievement.Rows[0]["Slot4WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot4WeightedEff"]);
                        if (Slot4OB > 0)
                        {
                            TotalAchievement4 = Math.Round(Total_StitchEff4 / (Slot4WeightedEff / Slot4OB), 0);
                        }

                        double Slot5OB = dtAchievement.Rows[0]["Slot5OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot5OB"]);
                        double Slot5WeightedEff = dtAchievement.Rows[0]["Slot5WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot5WeightedEff"]);
                        if (Slot5OB > 0)
                        {
                            TotalAchievement5 = Math.Round(Total_StitchEff5 / (Slot5WeightedEff / Slot5OB), 0);
                        }

                        double Slot6OB = dtAchievement.Rows[0]["Slot6OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot6OB"]);
                        double Slot6WeightedEff = dtAchievement.Rows[0]["Slot6WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot6WeightedEff"]);
                        if (Slot6OB > 0)
                        {
                            TotalAchievement6 = Math.Round(Total_StitchEff6 / (Slot6WeightedEff / Slot6OB), 0);
                        }

                        double Slot7OB = dtAchievement.Rows[0]["Slot7OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot7OB"]);
                        double Slot7WeightedEff = dtAchievement.Rows[0]["Slot7WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot7WeightedEff"]);
                        if (Slot7OB > 0)
                        {
                            TotalAchievement7 = Math.Round(Total_StitchEff7 / (Slot7WeightedEff / Slot7OB), 0);
                        }

                        double Slot8OB = dtAchievement.Rows[0]["Slot8OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot8OB"]);
                        double Slot8WeightedEff = dtAchievement.Rows[0]["Slot8WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot8WeightedEff"]);
                        if (Slot8OB > 0)
                        {
                            TotalAchievement8 = Math.Round(Total_StitchEff8 / (Slot8WeightedEff / Slot8OB), 0);
                        }

                        double Slot9OB = dtAchievement.Rows[0]["Slot9OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot9OB"]);
                        double Slot9WeightedEff = dtAchievement.Rows[0]["Slot9WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot9WeightedEff"]);
                        if (Slot9OB > 0)
                        {
                            TotalAchievement9 = Math.Round(Total_StitchEff9 / (Slot9WeightedEff / Slot9OB), 0);
                        }

                        double Slot10OB = dtAchievement.Rows[0]["Slot10OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot10OB"]);
                        double Slot10WeightedEff = dtAchievement.Rows[0]["Slot10WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot10WeightedEff"]);
                        if (Slot10OB > 0)
                        {
                            TotalAchievement10 = Math.Round(Total_StitchEff10 / (Slot10WeightedEff / Slot10OB), 0);
                        }

                        double Slot11OB = dtAchievement.Rows[0]["Slot11OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot11OB"]);
                        double Slot11WeightedEff = dtAchievement.Rows[0]["Slot11WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot11WeightedEff"]);
                        if (Slot11OB > 0)
                        {
                            TotalAchievement11 = Math.Round(Total_StitchEff11 / (Slot11WeightedEff / Slot11OB), 0);
                        }

                        double Slot12OB = dtAchievement.Rows[0]["Slot12OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot12OB"]);
                        double Slot12WeightedEff = dtAchievement.Rows[0]["Slot12WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot12WeightedEff"]);
                        if (Slot12OB > 0)
                        {
                            TotalAchievement12 = Math.Round(Total_StitchEff12 / (Slot12WeightedEff / Slot12OB), 0);
                        }

                        double Slot13OB = dtAchievement.Rows[0]["Slot13OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot13OB"]);
                        double Slot13WeightedEff = dtAchievement.Rows[0]["Slot13WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot13WeightedEff"]);
                        if (Slot13OB > 0)
                        {
                            TotalAchievement13 = Math.Round(Total_StitchEff13 / (Slot13WeightedEff / Slot13OB), 0);
                        }

                        double Slot14OB = dtAchievement.Rows[0]["Slot14OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot14OB"]);
                        double Slot14WeightedEff = dtAchievement.Rows[0]["Slot14WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot14WeightedEff"]);
                        if (Slot14OB > 0)
                        {
                            TotalAchievement14 = Math.Round(Total_StitchEff14 / (Slot14WeightedEff / Slot14OB), 0);
                        }

                        double Slot15OB = dtAchievement.Rows[0]["Slot15OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot15OB"]);
                        double Slot15WeightedEff = dtAchievement.Rows[0]["Slot15WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot15WeightedEff"]);
                        if (Slot15OB > 0)
                        {
                            TotalAchievement15 = Math.Round(Total_StitchEff15 / (Slot15WeightedEff / Slot15OB), 0);
                        }

                        double Slot16OB = dtAchievement.Rows[0]["Slot16OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot16OB"]);
                        double Slot16WeightedEff = dtAchievement.Rows[0]["Slot16WeightedEff"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot16WeightedEff"]);
                        if (Slot16OB > 0)
                        {
                            TotalAchievement16 = Math.Round(Total_StitchEff16 / (Slot16WeightedEff / Slot16OB), 0);
                        }

                        SlotId = Convert.ToInt32(hdnSlotId.Value);
                        if (SlotId > 0)
                        {
                            if (SlotId == 1)
                                TotalOB = Slot1OB;
                            else if (SlotId == 2)
                                TotalOB = Slot1OB + Slot2OB;
                            else if (SlotId == 3)
                                TotalOB = Slot1OB + Slot2OB + Slot3OB;
                            else if (SlotId == 4)
                                TotalOB = Slot1OB + Slot2OB + Slot3OB + Slot4OB;
                            else if (SlotId == 5)
                                TotalOB = Slot1OB + Slot2OB + Slot3OB + Slot4OB + Slot5OB;
                            else if (SlotId == 6)
                                TotalOB = Slot1OB + Slot2OB + Slot3OB + Slot4OB + Slot5OB + Slot6OB;
                            else if (SlotId == 7)
                                TotalOB = Slot1OB + Slot2OB + Slot3OB + Slot4OB + Slot5OB + Slot6OB + Slot7OB;
                            else if (SlotId == 8)
                                TotalOB = Slot1OB + Slot2OB + Slot3OB + Slot4OB + Slot5OB + Slot6OB + Slot7OB + Slot8OB;
                            else if (SlotId == 9)
                                TotalOB = Slot1OB + Slot2OB + Slot3OB + Slot4OB + Slot5OB + Slot6OB + Slot7OB + Slot8OB + Slot9OB;
                            else if (SlotId == 10)
                                TotalOB = Slot1OB + Slot2OB + Slot3OB + Slot4OB + Slot5OB + Slot6OB + Slot7OB + Slot8OB + Slot9OB + Slot10OB;
                            else if (SlotId == 11)
                                TotalOB = Slot1OB + Slot2OB + Slot3OB + Slot4OB + Slot5OB + Slot6OB + Slot7OB + Slot8OB + Slot9OB + Slot10OB + Slot11OB;
                            else if (SlotId == 12)
                                TotalOB = Slot1OB + Slot2OB + Slot3OB + Slot4OB + Slot5OB + Slot6OB + Slot7OB + Slot8OB + Slot9OB + Slot10OB + Slot11OB + Slot12OB;
                            else if (SlotId == 13)
                                TotalOB = Slot1OB + Slot2OB + Slot3OB + Slot4OB + Slot5OB + Slot6OB + Slot7OB + Slot8OB + Slot9OB + Slot10OB + Slot11OB + Slot12OB + Slot13OB;
                            else if (SlotId == 14)
                                TotalOB = Slot1OB + Slot2OB + Slot3OB + Slot4OB + Slot5OB + Slot6OB + Slot7OB + Slot8OB + Slot9OB + Slot10OB + Slot11OB + Slot12OB + Slot13OB + Slot14OB;
                            else if (SlotId == 15)
                                TotalOB = Slot1OB + Slot2OB + Slot3OB + Slot4OB + Slot5OB + Slot6OB + Slot7OB + Slot8OB + Slot9OB + Slot10OB + Slot11OB + Slot12OB + Slot13OB + Slot14OB + Slot15OB;
                            else if (SlotId == 16)
                                TotalOB = Slot1OB + Slot2OB + Slot3OB + Slot4OB + Slot5OB + Slot6OB + Slot7OB + Slot8OB + Slot9OB + Slot10OB + Slot11OB + Slot12OB + Slot13OB + Slot14OB + Slot15OB + Slot16OB;
                        }


                        //if (StitchActualOB_Total > 0)
                        //    lblTodayEff_Stitch_Foo.Text = Math.Round((Convert.ToDouble(TodayPassPcsStitch_Total * StitchSAM_Total) / Convert.ToDouble(TotalOB * 60)) * 100, 0).ToString() + "%";

                        if (Convert.ToString(TotalAchievement1) != "0" && Convert.ToString(TotalAchievement1) != "")
                            lbl1Achieved_Foo.Text = TotalAchievement1 + "%";

                        if (Convert.ToString(TotalAchievement2) != "0" && Convert.ToString(TotalAchievement2) != "")
                            lbl2Achieved_Foo.Text = TotalAchievement2 + "%";

                        if (Convert.ToString(TotalAchievement3) != "0" && Convert.ToString(TotalAchievement3) != "")
                            lbl3Achieved_Foo.Text = TotalAchievement3 + "%";

                        if (Convert.ToString(TotalAchievement4) != "0" && Convert.ToString(TotalAchievement4) != "")
                            lbl4Achieved_Foo.Text = TotalAchievement4 + "%";

                        if (Convert.ToString(TotalAchievement5) != "0" && Convert.ToString(TotalAchievement5) != "")
                            lbl5Achieved_Foo.Text = TotalAchievement5 + "%";

                        if (Convert.ToString(TotalAchievement6) != "0" && Convert.ToString(TotalAchievement6) != "")
                            lbl6Achieved_Foo.Text = TotalAchievement6 + "%";

                        if (Convert.ToString(TotalAchievement7) != "0" && Convert.ToString(TotalAchievement7) != "")
                            lbl7Achieved_Foo.Text = TotalAchievement7 + "%";

                        if (Convert.ToString(TotalAchievement8) != "0" && Convert.ToString(TotalAchievement8) != "")
                            lbl8Achieved_Foo.Text = TotalAchievement8 + "%";

                        if (Convert.ToString(TotalAchievement9) != "0" && Convert.ToString(TotalAchievement9) != "")
                            lbl9Achieved_Foo.Text = TotalAchievement9 + "%";

                        if (Convert.ToString(TotalAchievement10) != "0" && Convert.ToString(TotalAchievement10) != "")
                            lbl10Achieved_Foo.Text = TotalAchievement10 + "%";

                        if (Convert.ToString(TotalAchievement11) != "0" && Convert.ToString(TotalAchievement11) != "")
                            lbl11Achieved_Foo.Text = TotalAchievement11 + "%";

                        if (Convert.ToString(TotalAchievement12) != "0" && Convert.ToString(TotalAchievement12) != "")
                            lbl12Achieved_Foo.Text = TotalAchievement12 + "%";

                        if (Convert.ToString(TotalAchievement13) != "0" && Convert.ToString(TotalAchievement13) != "")
                            lbl13Achieved_Foo.Text = TotalAchievement13 + "%";

                        if (Convert.ToString(TotalAchievement14) != "0" && Convert.ToString(TotalAchievement14) != "")
                            lbl14Achieved_Foo.Text = TotalAchievement14 + "%";

                        if (Convert.ToString(TotalAchievement15) != "0" && Convert.ToString(TotalAchievement15) != "")
                            lbl15Achieved_Foo.Text = TotalAchievement15 + "%";

                        if (Convert.ToString(TotalAchievement16) != "0" && Convert.ToString(TotalAchievement16) != "")
                            lbl16Achieved_Foo.Text = TotalAchievement16 + "%";

                        //Add By Prabhaker on 18-jan-18

                        HtmlTableCell td1Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td1Achieved_Foo");
                        HtmlTableCell td2Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td2Achieved_Foo");
                        HtmlTableCell td3Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td3Achieved_Foo");
                        HtmlTableCell td4Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td4Achieved_Foo");
                        HtmlTableCell td5Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td5Achieved_Foo");
                        HtmlTableCell td6Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td6Achieved_Foo");
                        HtmlTableCell td7Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td7Achieved_Foo");
                        HtmlTableCell td8Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td8Achieved_Foo");
                        HtmlTableCell td9Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td9Achieved_Foo");
                        HtmlTableCell td10Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td10Achieved_Foo");
                        HtmlTableCell td11Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td11Achieved_Foo");
                        HtmlTableCell td12Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td12Achieved_Foo");
                        HtmlTableCell td13Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td13Achieved_Foo");
                        HtmlTableCell td14Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td14Achieved_Foo");
                        HtmlTableCell td15Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td15Achieved_Foo");
                        HtmlTableCell td16Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td16Achieved_Foo");


                        if (TotalAchievement1 > 0 && TotalAchievement1 < 81)
                        {
                            lbl1Achieved_Foo.ForeColor = Color.Yellow;
                            td1Achieved_Foo.Style.Add("background-color", "red");
                        }
                        else
                        {
                            td1Achieved_Foo.Style.Add("background-color", "green");
                            lbl1Achieved_Foo.ForeColor = Color.Yellow;
                        }


                        if (TotalAchievement2 > 0 && TotalAchievement2 < 81)
                        {
                            td2Achieved_Foo.Style.Add("background-color", "red");
                            lbl2Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td2Achieved_Foo.Style.Add("background-color", "green");
                            lbl2Achieved_Foo.ForeColor = Color.Yellow;
                        }

                        if (TotalAchievement3 > 0 && TotalAchievement3 < 81)
                        {
                            td3Achieved_Foo.Style.Add("background-color", "red");
                            lbl3Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td3Achieved_Foo.Style.Add("background-color", "green");
                            lbl3Achieved_Foo.ForeColor = Color.Yellow;
                        }

                        if (TotalAchievement4 > 0 && TotalAchievement4 < 81)
                        {
                            td4Achieved_Foo.Style.Add("background-color", "red");
                            lbl4Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td4Achieved_Foo.Style.Add("background-color", "green");
                            lbl4Achieved_Foo.ForeColor = Color.Yellow;
                        }

                        if (TotalAchievement5 > 0 && TotalAchievement5 < 81)
                        {
                            td5Achieved_Foo.Style.Add("background-color", "red");
                            lbl5Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td5Achieved_Foo.Style.Add("background-color", "green");
                            lbl5Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        if (TotalAchievement6 > 0 && TotalAchievement6 < 81)
                        {
                            td6Achieved_Foo.Style.Add("background-color", "red");
                            lbl6Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td6Achieved_Foo.Style.Add("background-color", "green");
                            lbl6Achieved_Foo.ForeColor = Color.Yellow;
                        }

                        if (TotalAchievement7 > 0 && TotalAchievement7 < 81)
                        {
                            td7Achieved_Foo.Style.Add("background-color", "red");
                            lbl7Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td7Achieved_Foo.Style.Add("background-color", "green");
                            lbl7Achieved_Foo.ForeColor = Color.Yellow;
                        }

                        if (TotalAchievement8 > 0 && TotalAchievement8 < 81)
                        {
                            td8Achieved_Foo.Style.Add("background-color", "red");
                            lbl8Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td8Achieved_Foo.Style.Add("background-color", "green");
                            lbl8Achieved_Foo.ForeColor = Color.Yellow;
                        }

                        if (TotalAchievement9 > 0 && TotalAchievement9 < 81)
                        {
                            td9Achieved_Foo.Style.Add("background-color", "red");
                            lbl9Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td9Achieved_Foo.Style.Add("background-color", "green");
                            lbl9Achieved_Foo.ForeColor = Color.Yellow;
                        }

                        if (TotalAchievement10 > 0 && TotalAchievement10 < 81)
                        {
                            td10Achieved_Foo.Style.Add("background-color", "red");
                            lbl10Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td10Achieved_Foo.Style.Add("background-color", "green");
                            lbl10Achieved_Foo.ForeColor = Color.Yellow;
                        }

                        if (TotalAchievement11 > 0 && TotalAchievement11 < 81)
                        {
                            td11Achieved_Foo.Style.Add("background-color", "red");
                            lbl11Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td11Achieved_Foo.Style.Add("background-color", "green");
                            lbl11Achieved_Foo.ForeColor = Color.Yellow;
                        }


                        if (TotalAchievement12 > 0 && TotalAchievement12 < 81)
                        {
                            td12Achieved_Foo.Style.Add("background-color", "red");
                            lbl12Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td12Achieved_Foo.Style.Add("background-color", "green");
                            lbl12Achieved_Foo.ForeColor = Color.Yellow;
                        }

                        if (TotalAchievement13 > 0 && TotalAchievement13 < 81)
                        {
                            td13Achieved_Foo.Style.Add("background-color", "red");
                            lbl13Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td13Achieved_Foo.Style.Add("background-color", "green");
                            lbl13Achieved_Foo.ForeColor = Color.Yellow;
                        }

                        if (TotalAchievement14 > 0 && TotalAchievement14 < 81)
                        {
                            td14Achieved_Foo.Style.Add("background-color", "red");
                            lbl14Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td14Achieved_Foo.Style.Add("background-color", "green");
                            lbl14Achieved_Foo.ForeColor = Color.Yellow;
                        }

                        if (TotalAchievement15 > 0 && TotalAchievement15 < 81)
                        {
                            td15Achieved_Foo.Style.Add("background-color", "red");
                            lbl15Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td15Achieved_Foo.Style.Add("background-color", "green");
                            lbl15Achieved_Foo.ForeColor = Color.Yellow;
                        }

                        if (TotalAchievement16 > 0 && TotalAchievement16 < 81)
                        {
                            td16Achieved_Foo.Style.Add("background-color", "red");
                            lbl16Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        else
                        {
                            td16Achieved_Foo.Style.Add("background-color", "green");
                            lbl16Achieved_Foo.ForeColor = Color.Yellow;
                        }
                        //End of  Add By Prabhaker on 18-jan-18

                        if (TotalAchievement1 > 0)
                        {
                            if (TotalAchievement1 >= 85)
                                tdSlot1PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot1PassTotal.Style.Add("background-color", "#FF0000");
                        }
                        if (TotalAchievement2 > 0)
                        {
                            if (TotalAchievement2 >= 85)
                                tdSlot2PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot2PassTotal.Style.Add("background-color", "#FF0000");
                        }
                        if (TotalAchievement3 > 0)
                        {
                            if (TotalAchievement3 >= 85)
                                tdSlot3PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot3PassTotal.Style.Add("background-color", "#FF0000");
                        }
                        if (TotalAchievement4 > 0)
                        {
                            if (TotalAchievement4 >= 85)
                                tdSlot4PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot4PassTotal.Style.Add("background-color", "#FF0000");
                        }
                        if (TotalAchievement5 > 0)
                        {
                            if (TotalAchievement5 >= 85)
                                tdSlot5PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot5PassTotal.Style.Add("background-color", "#FF0000");
                        }
                        if (TotalAchievement6 > 0)
                        {
                            if (TotalAchievement6 >= 85)
                                tdSlot6PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot6PassTotal.Style.Add("background-color", "#FF0000");
                        }
                        if (TotalAchievement7 > 0)
                        {
                            if (TotalAchievement7 >= 85)
                                tdSlot7PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot7PassTotal.Style.Add("background-color", "#FF0000");
                        }
                        if (TotalAchievement8 > 0)
                        {
                            if (TotalAchievement8 >= 85)
                                tdSlot8PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot8PassTotal.Style.Add("background-color", "#FF0000");
                        }
                        if (TotalAchievement9 > 0)
                        {
                            if (TotalAchievement9 >= 85)
                                tdSlot9PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot9PassTotal.Style.Add("background-color", "#FF0000");
                        }
                        if (TotalAchievement10 > 0)
                        {
                            if (TotalAchievement10 >= 85)
                                tdSlot10PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot10PassTotal.Style.Add("background-color", "#FF0000");
                        }
                        if (TotalAchievement11 > 0)
                        {
                            if (TotalAchievement11 >= 85)
                                tdSlot11PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot11PassTotal.Style.Add("background-color", "#FF0000");
                        }
                        if (TotalAchievement12 > 0)
                        {
                            if (TotalAchievement12 >= 85)
                                tdSlot12PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot12PassTotal.Style.Add("background-color", "#FF0000");
                        }
                        if (TotalAchievement13 > 0)
                        {
                            if (TotalAchievement13 >= 85)
                                tdSlot13PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot13PassTotal.Style.Add("background-color", "#FF0000");
                        }
                        if (TotalAchievement14 > 0)
                        {
                            if (TotalAchievement14 >= 85)
                                tdSlot14PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot14PassTotal.Style.Add("background-color", "#FF0000");
                        }
                        if (TotalAchievement15 > 0)
                        {
                            if (TotalAchievement15 >= 85)
                                tdSlot15PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot15PassTotal.Style.Add("background-color", "#FF0000");
                        }
                        if (TotalAchievement16 > 0)
                        {
                            if (TotalAchievement16 >= 85)
                                tdSlot16PassTotal.Style.Add("background-color", "green");
                            else
                                tdSlot16PassTotal.Style.Add("background-color", "#FF0000");
                        }


                        if (TotalAchievement1 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement1) < 85)
                                lbl1StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl1StitchEff_Foo.Style.Add("color", "green");

                        }
                        if (TotalAchievement2 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement2) < 85)
                                lbl2StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl2StitchEff_Foo.Style.Add("color", "green");
                        }
                        if (TotalAchievement3 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement3) < 85)
                                lbl3StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl3StitchEff_Foo.Style.Add("color", "green");
                        }

                        if (TotalAchievement4 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement4) < 85)
                                lbl4StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl4StitchEff_Foo.Style.Add("color", "green");
                        }
                        if (TotalAchievement5 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement5) < 85)
                                lbl5StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl5StitchEff_Foo.Style.Add("color", "green");
                        }
                        if (TotalAchievement6 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement6) < 85)
                                lbl6StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl6StitchEff_Foo.Style.Add("color", "green");
                        }
                        if (TotalAchievement7 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement7) < 85)
                                lbl7StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl7StitchEff_Foo.Style.Add("color", "green");
                        }
                        if (TotalAchievement8 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement8) < 85)
                                lbl8StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl8StitchEff_Foo.Style.Add("color", "green");
                        }
                        if (TotalAchievement9 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement9) < 85)
                                lbl9StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl9StitchEff_Foo.Style.Add("color", "green");
                        }
                        if (TotalAchievement10 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement10) < 85)
                                lbl10StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl10StitchEff_Foo.Style.Add("color", "green");
                        }
                        if (TotalAchievement11 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement11) < 85)
                                lbl11StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl11StitchEff_Foo.Style.Add("color", "green");
                        }
                        if (TotalAchievement12 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement12) < 85)
                                lbl12StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl12StitchEff_Foo.Style.Add("color", "green");
                        }
                        if (TotalAchievement13 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement13) < 85)
                                lbl13StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl13StitchEff_Foo.Style.Add("color", "green");
                        }
                        if (TotalAchievement14 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement14) < 85)
                                lbl14StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl14StitchEff_Foo.Style.Add("color", "green");
                        }
                        if (TotalAchievement15 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement15) < 85)
                                lbl15StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl15StitchEff_Foo.Style.Add("color", "green");
                        }
                        if (TotalAchievement16 != 0)
                        {
                            if (Convert.ToInt32(TotalAchievement16) < 85)
                                lbl16StitchEff_Foo.Style.Add("color", "#FF0000");
                            else
                                lbl16StitchEff_Foo.Style.Add("color", "green");
                        }
                    }
                    //End Of Code

                    Label lbl1BiplPrice_Foo = (Label)e.Row.FindControl("lbl1BiplPrice_Foo");
                    Label lbl2BiplPrice_Foo = (Label)e.Row.FindControl("lbl2BiplPrice_Foo");
                    Label lbl3BiplPrice_Foo = (Label)e.Row.FindControl("lbl3BiplPrice_Foo");
                    Label lbl4BiplPrice_Foo = (Label)e.Row.FindControl("lbl4BiplPrice_Foo");
                    Label lbl5BiplPrice_Foo = (Label)e.Row.FindControl("lbl5BiplPrice_Foo");
                    Label lbl6BiplPrice_Foo = (Label)e.Row.FindControl("lbl6BiplPrice_Foo");
                    Label lbl7BiplPrice_Foo = (Label)e.Row.FindControl("lbl7BiplPrice_Foo");
                    Label lbl8BiplPrice_Foo = (Label)e.Row.FindControl("lbl8BiplPrice_Foo");
                    Label lbl9BiplPrice_Foo = (Label)e.Row.FindControl("lbl9BiplPrice_Foo");
                    Label lbl10BiplPrice_Foo = (Label)e.Row.FindControl("lbl10BiplPrice_Foo");
                    Label lbl11BiplPrice_Foo = (Label)e.Row.FindControl("lbl11BiplPrice_Foo");
                    Label lbl12BiplPrice_Foo = (Label)e.Row.FindControl("lbl12BiplPrice_Foo");
                    Label lbl13BiplPrice_Foo = (Label)e.Row.FindControl("lbl13BiplPrice_Foo");
                    Label lbl14BiplPrice_Foo = (Label)e.Row.FindControl("lbl14BiplPrice_Foo");
                    Label lbl15BiplPrice_Foo = (Label)e.Row.FindControl("lbl15BiplPrice_Foo");
                    Label lbl16BiplPrice_Foo = (Label)e.Row.FindControl("lbl16BiplPrice_Foo");
                    Label lblBiplPriceTotal_foo = (Label)e.Row.FindControl("lblBiplPriceTotal_foo");

                    if (BIPLPriceSlot1 != 0)
                        lbl1BiplPrice_Foo.Text = (BIPLPriceSlot1 / 100000) > 0 ? Math.Round(BIPLPriceSlot1 / 100000, 1).ToString() + " L" : "";

                    if (BIPLPriceSlot2 != 0)
                        lbl2BiplPrice_Foo.Text = (BIPLPriceSlot2 / 100000) > 0 ? Math.Round(BIPLPriceSlot2 / 100000, 1).ToString() + " L" : "";

                    if (BIPLPriceSlot3 != 0)
                        lbl3BiplPrice_Foo.Text = (BIPLPriceSlot3 / 100000) > 0 ? Math.Round(BIPLPriceSlot3 / 100000, 1).ToString() + " L" : "";

                    if (BIPLPriceSlot4 != 0)
                        lbl4BiplPrice_Foo.Text = (BIPLPriceSlot4 / 100000) > 0 ? Math.Round(BIPLPriceSlot4 / 100000, 1).ToString() + " L" : "";

                    if (BIPLPriceSlot5 != 0)
                        lbl5BiplPrice_Foo.Text = (BIPLPriceSlot5 / 100000) > 0 ? Math.Round(BIPLPriceSlot5 / 100000, 1).ToString() + " L" : "";

                    if (BIPLPriceSlot6 != 0)
                        lbl6BiplPrice_Foo.Text = (BIPLPriceSlot6 / 100000) > 0 ? Math.Round(BIPLPriceSlot6 / 100000, 1).ToString() + " L" : "";

                    if (BIPLPriceSlot7 != 0)
                        lbl7BiplPrice_Foo.Text = (BIPLPriceSlot7 / 100000) > 0 ? Math.Round(BIPLPriceSlot7 / 100000, 1).ToString() + " L" : "";

                    if (BIPLPriceSlot8 != 0)
                        lbl8BiplPrice_Foo.Text = (BIPLPriceSlot8 / 100000) > 0 ? Math.Round(BIPLPriceSlot8 / 100000, 1).ToString() + " L" : "";

                    if (BIPLPriceSlot9 != 0)
                        lbl9BiplPrice_Foo.Text = (BIPLPriceSlot9 / 100000) > 0 ? Math.Round(BIPLPriceSlot9 / 100000, 1).ToString() + " L" : "";

                    if (BIPLPriceSlot10 != 0)
                        lbl10BiplPrice_Foo.Text = (BIPLPriceSlot10 / 100000) > 0 ? Math.Round(BIPLPriceSlot10 / 100000, 1).ToString() + " L" : "";

                    if (BIPLPriceSlot11 != 0)
                        lbl11BiplPrice_Foo.Text = (BIPLPriceSlot11 / 100000) > 0 ? Math.Round(BIPLPriceSlot11 / 100000, 1).ToString() + " L" : "";

                    if (BIPLPriceSlot12 != 0)
                        lbl12BiplPrice_Foo.Text = (BIPLPriceSlot12 / 100000) > 0 ? Math.Round(BIPLPriceSlot12 / 100000, 1).ToString() + " L" : "";

                    if (BIPLPriceSlot13 != 0)
                        lbl13BiplPrice_Foo.Text = (BIPLPriceSlot13 / 100000) > 0 ? Math.Round(BIPLPriceSlot13 / 100000, 1).ToString() + " L" : "";

                    if (BIPLPriceSlot14 != 0)
                        lbl14BiplPrice_Foo.Text = (BIPLPriceSlot14 / 100000) > 0 ? Math.Round(BIPLPriceSlot14 / 100000, 1).ToString() + " L" : "";

                    if (BIPLPriceSlot15 != 0)
                        lbl15BiplPrice_Foo.Text = (BIPLPriceSlot15 / 100000) > 0 ? Math.Round(BIPLPriceSlot15 / 100000, 1).ToString() + " L" : "";

                    if (BIPLPriceSlot16 != 0)
                        lbl16BiplPrice_Foo.Text = (BIPLPriceSlot16 / 100000) > 0 ? Math.Round(BIPLPriceSlot16 / 100000, 1).ToString() + " L" : "";

                    SlotId = Convert.ToInt32(hdnSlotId.Value);
                    double BIPLPriceTotal = 0;

                    if (SlotId == 1)
                        BIPLPriceTotal = BIPLPriceSlot1;
                    else if (SlotId == 2)
                        BIPLPriceTotal = BIPLPriceSlot1 + BIPLPriceSlot2;
                    else if (SlotId == 3)
                        BIPLPriceTotal = BIPLPriceSlot1 + BIPLPriceSlot2 + BIPLPriceSlot3;
                    else if (SlotId == 4)
                        BIPLPriceTotal = BIPLPriceSlot1 + BIPLPriceSlot2 + BIPLPriceSlot3 + BIPLPriceSlot4;
                    else if (SlotId == 5)
                        BIPLPriceTotal = BIPLPriceSlot1 + BIPLPriceSlot2 + BIPLPriceSlot3 + BIPLPriceSlot4 + BIPLPriceSlot5;
                    else if (SlotId == 6)
                        BIPLPriceTotal = BIPLPriceSlot1 + BIPLPriceSlot2 + BIPLPriceSlot3 + BIPLPriceSlot4 + BIPLPriceSlot5 + BIPLPriceSlot6;
                    else if (SlotId == 7)
                        BIPLPriceTotal = BIPLPriceSlot1 + BIPLPriceSlot2 + BIPLPriceSlot3 + BIPLPriceSlot4 + BIPLPriceSlot5 + BIPLPriceSlot6 + BIPLPriceSlot7;
                    else if (SlotId == 8)
                        BIPLPriceTotal = BIPLPriceSlot1 + BIPLPriceSlot2 + BIPLPriceSlot3 + BIPLPriceSlot4 + BIPLPriceSlot5 + BIPLPriceSlot6 + BIPLPriceSlot7 + BIPLPriceSlot8;
                    else if (SlotId == 9)
                        BIPLPriceTotal = BIPLPriceSlot1 + BIPLPriceSlot2 + BIPLPriceSlot3 + BIPLPriceSlot4 + BIPLPriceSlot5 + BIPLPriceSlot6 + BIPLPriceSlot7 + BIPLPriceSlot8 + BIPLPriceSlot9;
                    else if (SlotId == 10)
                    {
                        BIPLPriceTotal = BIPLPriceSlot1 + BIPLPriceSlot2 + BIPLPriceSlot3 + BIPLPriceSlot4 + BIPLPriceSlot5 + BIPLPriceSlot6 + BIPLPriceSlot7 + BIPLPriceSlot8
                            + BIPLPriceSlot9 + BIPLPriceSlot10;
                    }
                    else if (SlotId == 11)
                    {
                        BIPLPriceTotal = BIPLPriceSlot1 + BIPLPriceSlot2 + BIPLPriceSlot3 + BIPLPriceSlot4 + BIPLPriceSlot5 + BIPLPriceSlot6 + BIPLPriceSlot7 + BIPLPriceSlot8
                            + BIPLPriceSlot9 + BIPLPriceSlot10 + BIPLPriceSlot11;
                    }
                    else if (SlotId == 12)
                    {
                        BIPLPriceTotal = BIPLPriceSlot1 + BIPLPriceSlot2 + BIPLPriceSlot3 + BIPLPriceSlot4 + BIPLPriceSlot5 + BIPLPriceSlot6 + BIPLPriceSlot7 + BIPLPriceSlot8
                            + BIPLPriceSlot9 + BIPLPriceSlot10 + BIPLPriceSlot11 + BIPLPriceSlot12;
                    }
                    else if (SlotId == 13)
                    {
                        BIPLPriceTotal = BIPLPriceSlot1 + BIPLPriceSlot2 + BIPLPriceSlot3 + BIPLPriceSlot4 + BIPLPriceSlot5 + BIPLPriceSlot6 + BIPLPriceSlot7 + BIPLPriceSlot8
                            + BIPLPriceSlot9 + BIPLPriceSlot10 + BIPLPriceSlot11 + BIPLPriceSlot12 + BIPLPriceSlot13;
                    }
                    else if (SlotId == 14)
                    {
                        BIPLPriceTotal = BIPLPriceSlot1 + BIPLPriceSlot2 + BIPLPriceSlot3 + BIPLPriceSlot4 + BIPLPriceSlot5 + BIPLPriceSlot6 + BIPLPriceSlot7 + BIPLPriceSlot8
                            + BIPLPriceSlot9 + BIPLPriceSlot10 + BIPLPriceSlot11 + BIPLPriceSlot12 + BIPLPriceSlot13 + BIPLPriceSlot14;
                    }
                    else if (SlotId == 15)
                    {
                        BIPLPriceTotal = BIPLPriceSlot1 + BIPLPriceSlot2 + BIPLPriceSlot3 + BIPLPriceSlot4 + BIPLPriceSlot5 + BIPLPriceSlot6 + BIPLPriceSlot7 + BIPLPriceSlot8
                             + BIPLPriceSlot9 + BIPLPriceSlot10 + BIPLPriceSlot11 + BIPLPriceSlot12 + BIPLPriceSlot13 + BIPLPriceSlot14 + BIPLPriceSlot15;
                    }
                    else if (SlotId == 16)
                    {
                        BIPLPriceTotal = BIPLPriceSlot1 + BIPLPriceSlot2 + BIPLPriceSlot3 + BIPLPriceSlot4 + BIPLPriceSlot5 + BIPLPriceSlot6 + BIPLPriceSlot7 + BIPLPriceSlot8
                             + BIPLPriceSlot9 + BIPLPriceSlot10 + BIPLPriceSlot11 + BIPLPriceSlot12 + BIPLPriceSlot13 + BIPLPriceSlot14 + BIPLPriceSlot15 + BIPLPriceSlot16;
                    }

                    if (BIPLPriceTotal > 0)
                        lblBiplPriceTotal_foo.Text = (BIPLPriceTotal / 100000) > 0 ? Math.Round(BIPLPriceTotal / 100000, 1).ToString() + " L" : "";

                    // ------------------------------------------- CMT IMPLEMENTATION ---------------------------------------------------------

                    Label lbl1CMT_Foo = (Label)e.Row.FindControl("lbl1CMT_Foo");
                    Label lbl2CMT_Foo = (Label)e.Row.FindControl("lbl2CMT_Foo");
                    Label lbl3CMT_Foo = (Label)e.Row.FindControl("lbl3CMT_Foo");
                    Label lbl4CMT_Foo = (Label)e.Row.FindControl("lbl4CMT_Foo");
                    Label lbl5CMT_Foo = (Label)e.Row.FindControl("lbl5CMT_Foo");
                    Label lbl6CMT_Foo = (Label)e.Row.FindControl("lbl6CMT_Foo");
                    Label lbl7CMT_Foo = (Label)e.Row.FindControl("lbl7CMT_Foo");
                    Label lbl8CMT_Foo = (Label)e.Row.FindControl("lbl8CMT_Foo");
                    Label lbl9CMT_Foo = (Label)e.Row.FindControl("lbl9CMT_Foo");
                    Label lbl10CMT_Foo = (Label)e.Row.FindControl("lbl10CMT_Foo");
                    Label lbl11CMT_Foo = (Label)e.Row.FindControl("lbl11CMT_Foo");
                    Label lbl12CMT_Foo = (Label)e.Row.FindControl("lbl12CMT_Foo");
                    Label lbl13CMT_Foo = (Label)e.Row.FindControl("lbl13CMT_Foo");
                    Label lbl14CMT_Foo = (Label)e.Row.FindControl("lbl14CMT_Foo");
                    Label lbl15CMT_Foo = (Label)e.Row.FindControl("lbl15CMT_Foo");
                    Label lbl16CMT_Foo = (Label)e.Row.FindControl("lbl16CMT_Foo");


                    Label lblCmtTooltip1 = (Label)e.Row.FindControl("lblCmtTooltip1");
                    Label lblCmtTooltip2 = (Label)e.Row.FindControl("lblCmtTooltip2");
                    Label lblCmtTooltip3 = (Label)e.Row.FindControl("lblCmtTooltip3");
                    Label lblCmtTooltip4 = (Label)e.Row.FindControl("lblCmtTooltip4");
                    Label lblCmtTooltip5 = (Label)e.Row.FindControl("lblCmtTooltip5");
                    Label lblCmtTooltip6 = (Label)e.Row.FindControl("lblCmtTooltip6");
                    Label lblCmtTooltip7 = (Label)e.Row.FindControl("lblCmtTooltip7");
                    Label lblCmtTooltip8 = (Label)e.Row.FindControl("lblCmtTooltip8");
                    Label lblCmtTooltip9 = (Label)e.Row.FindControl("lblCmtTooltip9");
                    Label lblCmtTooltip10 = (Label)e.Row.FindControl("lblCmtTooltip10");
                    Label lblCmtTooltip11 = (Label)e.Row.FindControl("lblCmtTooltip11");
                    Label lblCmtTooltip12 = (Label)e.Row.FindControl("lblCmtTooltip12");
                    Label lblCmtTooltip13 = (Label)e.Row.FindControl("lblCmtTooltip13");
                    Label lblCmtTooltip14 = (Label)e.Row.FindControl("lblCmtTooltip14");
                    Label lblCmtTooltip15 = (Label)e.Row.FindControl("lblCmtTooltip15");
                    Label lblCmtTooltip16 = (Label)e.Row.FindControl("lblCmtTooltip16");

                    Label lblCMTTotal_foo = (Label)e.Row.FindControl("lblCMTTotal_foo");
                    Label lblCmtTooltip_foo = (Label)e.Row.FindControl("lblCmtTooltip_foo");


                    double StitchRate = 0;
                    double BasicRate = 0;
                    double FinishCost = 0;
                    double SlotOverHeadCMT = 0;
                    double StitchPerPcsRate = 0;
                    FinishCost = hdnFinishCost_total.Value == null ? 0 : Convert.ToInt32(hdnFinishCost_total.Value);
                    BasicRate = CuttingPerPcsCost + FinishCost;

                    double OBTotal = 0;
                    double CMTValue = 0;

                    if (ViewState["dtAchievement"] != null)
                    {
                        DataTable dtAchievement = (DataTable)ViewState["dtAchievement"];
                        double Slot1OB = dtAchievement.Rows[0]["Slot1OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot1OB"]);
                        if ((Slot1OB > 0) && (BIPLPriceSlot1 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot1)), 0);
                            StitchRate = Slot1OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot1) + StitchRate) / BIPLPriceSlot1) * 100, 0);
                            lbl1CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot1), 0);
                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip1.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            //lblCmtTooltip1.CssClass = "lblhover";

                            OBTotal += Slot1OB;
                        }
                        double Slot2OB = dtAchievement.Rows[0]["Slot2OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot2OB"]);
                        if ((Slot2OB > 0) && (BIPLPriceSlot2 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot2)), 0);
                            StitchRate = Slot2OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot2) + StitchRate) / BIPLPriceSlot2) * 100, 0);
                            lbl2CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot2), 0);
                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip2.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            OBTotal += Slot2OB;
                        }
                        double Slot3OB = dtAchievement.Rows[0]["Slot3OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot3OB"]);
                        if ((Slot3OB > 0) && (BIPLPriceSlot3 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot3)), 0);
                            StitchRate = Slot3OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot3) + StitchRate) / BIPLPriceSlot3) * 100, 0);
                            lbl3CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot3), 0);
                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip3.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            OBTotal += Slot3OB;
                        }
                        double Slot4OB = dtAchievement.Rows[0]["Slot4OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot4OB"]);
                        if ((Slot4OB > 0) && (BIPLPriceSlot4 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot4)), 0);
                            StitchRate = Slot4OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot4) + StitchRate) / BIPLPriceSlot4) * 100, 0);
                            lbl4CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot4), 0);
                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip4.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            OBTotal += Slot4OB;
                        }
                        double Slot5OB = dtAchievement.Rows[0]["Slot5OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot5OB"]);
                        if ((Slot5OB > 0) && (BIPLPriceSlot5 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot5)), 0);
                            StitchRate = Slot5OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot5) + StitchRate) / BIPLPriceSlot5) * 100, 0);
                            lbl5CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot5), 0);

                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip5.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            OBTotal += Slot5OB;
                        }
                        double Slot6OB = dtAchievement.Rows[0]["Slot6OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot6OB"]);
                        if ((Slot6OB > 0) && (BIPLPriceSlot6 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot6)), 0);
                            StitchRate = Slot6OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot6) + StitchRate) / BIPLPriceSlot6) * 100, 0);
                            lbl6CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot6), 0);

                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip6.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            OBTotal += Slot6OB;
                        }
                        double Slot7OB = dtAchievement.Rows[0]["Slot7OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot7OB"]);
                        if ((Slot7OB > 0) && (BIPLPriceSlot7 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot7)), 0);
                            StitchRate = Slot7OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot7) + StitchRate) / BIPLPriceSlot7) * 100, 0);
                            lbl7CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot7), 0);

                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;

                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip7.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            OBTotal += Slot7OB;
                        }
                        double Slot8OB = dtAchievement.Rows[0]["Slot8OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot8OB"]);
                        if ((Slot8OB > 0) && (BIPLPriceSlot8 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot8)), 0);
                            StitchRate = Slot8OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot8) + StitchRate) / BIPLPriceSlot8) * 100, 0);
                            lbl8CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot8), 0);

                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip8.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            OBTotal += Slot8OB;
                        }
                        double Slot9OB = dtAchievement.Rows[0]["Slot9OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot9OB"]);
                        if ((Slot9OB > 0) && (BIPLPriceSlot9 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot9)), 0);
                            StitchRate = Slot9OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot9) + StitchRate) / BIPLPriceSlot9) * 100, 0);
                            lbl9CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot9), 0);

                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip9.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            OBTotal += Slot9OB;
                        }
                        double Slot10OB = dtAchievement.Rows[0]["Slot10OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot10OB"]);
                        if ((Slot10OB > 0) && (BIPLPriceSlot10 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot10)), 0);
                            StitchRate = Slot10OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot10) + StitchRate) / BIPLPriceSlot10) * 100, 0);
                            lbl10CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot10), 0);
                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip10.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            OBTotal += Slot10OB;
                        }
                        double Slot11OB = dtAchievement.Rows[0]["Slot11OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot11OB"]);
                        if ((Slot11OB > 0) && (BIPLPriceSlot11 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot11)), 0);
                            StitchRate = Slot11OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot11) + StitchRate) / BIPLPriceSlot11) * 100, 0);
                            lbl11CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot11), 0);
                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip11.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            OBTotal += Slot11OB;
                        }
                        double Slot12OB = dtAchievement.Rows[0]["Slot12OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot12OB"]);
                        if ((Slot12OB > 0) && (BIPLPriceSlot12 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot12)), 0);
                            StitchRate = Slot12OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot12) + StitchRate) / BIPLPriceSlot12) * 100, 0);
                            lbl12CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot12), 0);
                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip12.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            OBTotal += Slot12OB;
                        }
                        double Slot13OB = dtAchievement.Rows[0]["Slot13OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot13OB"]);
                        if ((Slot13OB > 0) && (BIPLPriceSlot13 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot13)), 0);
                            StitchRate = Slot13OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot13) + StitchRate) / BIPLPriceSlot13) * 100, 0);
                            lbl13CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot13), 0);
                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip13.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            OBTotal += Slot13OB;
                        }
                        double Slot14OB = dtAchievement.Rows[0]["Slot14OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot14OB"]);
                        if ((Slot14OB > 0) && (BIPLPriceSlot14 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot14)), 0);
                            StitchRate = Slot14OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot14) + StitchRate) / BIPLPriceSlot14) * 100, 0);
                            lbl14CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot14), 0);
                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip14.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            OBTotal += Slot14OB;
                        }
                        double Slot15OB = dtAchievement.Rows[0]["Slot15OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot15OB"]);
                        if ((Slot15OB > 0) && (BIPLPriceSlot15 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot15)), 0);
                            StitchRate = Slot15OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot15) + StitchRate) / BIPLPriceSlot15) * 100, 0);
                            lbl15CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot15), 0);
                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip15.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            OBTotal += Slot15OB;
                        }
                        double Slot16OB = dtAchievement.Rows[0]["Slot16OB"] == DBNull.Value ? 0 : Convert.ToDouble(dtAchievement.Rows[0]["Slot16OB"]);
                        if ((Slot16OB > 0) && (BIPLPriceSlot16 > 0))
                        {
                            SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(Total_Slot16)), 0);
                            StitchRate = Slot16OB * CostPerHour;
                            CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * Total_Slot16) + StitchRate) / BIPLPriceSlot16) * 100, 0);
                            lbl16CMT_Foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                            StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(Total_Slot16), 0);
                            double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                            StringBuilder cmttooltipCom = new StringBuilder();
                            cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable' cellspacing='0' style='width:100%'>");
                            cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                            cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                            cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                            cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                            cmttooltipCom.Append("</table>");

                            lblCmtTooltip16.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";
                            OBTotal += Slot16OB;
                        }

                    }

                    if ((TodayPassPcsStitch_Total > 0) && (BIPLPriceTotal > 0))
                    {

                        //SlotOverHead = (SlotOverHead * SlotId) > 150000 ? 150000 : (SlotOverHead * SlotId);
                        // Updated On dated 3 oct 2022 by RSB on SAM request on Skype
                        SlotOverHead = (SlotOverHead * SlotId);

                        SlotOverHeadCMT = Math.Round((SlotOverHead / Convert.ToDouble(TodayPassPcsStitch_Total)), 0);
                        StitchRate = OBTotal * CostPerHour;
                        CMTValue = Math.Round(((((BasicRate + SlotOverHeadCMT) * TodayPassPcsStitch_Total) + StitchRate) / BIPLPriceTotal) * 100, 0);

                        lblCMTTotal_foo.Text = CMTValue > 0 ? CMTValue.ToString() + "%" : "";

                        StitchPerPcsRate = Math.Round(StitchRate / Convert.ToDouble(TodayPassPcsStitch_Total), 0);
                        double TotalRate = CuttingPerPcsCost + StitchPerPcsRate + FinishCost + SlotOverHeadCMT;
                        StringBuilder cmttooltipCom = new StringBuilder();
                        cmttooltipCom.Append("<table border='0'cellpadding='0' class='cmtTable2' cellspacing='0' style='width:100%'>");
                        cmttooltipCom.Append("<tr><th colspan='2'>Per Pcs Rate</th></tr>");
                        cmttooltipCom.Append("<tr><td>Cut</td><td> &#x20B9; " + CuttingPerPcsCost + "</td></tr>");
                        cmttooltipCom.Append("<tr><td>Stitch</td><td> &#x20B9; " + StitchPerPcsRate + "</td></tr>");
                        cmttooltipCom.Append("<tr><td>Finish</td><td> &#x20B9; " + FinishCost + "</td></tr>");
                        cmttooltipCom.Append("<tr><td>Overhead</td><td> &#x20B9; " + SlotOverHeadCMT + "</td></tr>");
                        cmttooltipCom.Append("<tr><td style='background:#fae8e8 !important;'><b>Total</b></td><td style='background:#fae8e8 !important;'><b> &#x20B9; " + TotalRate + "</b></td></tr>");
                        cmttooltipCom.Append("</table>");

                        lblCmtTooltip_foo.Text = "<span class='tooltiptext'>" + cmttooltipCom + "</span>";

                        if (SlotId == 11)
                        {
                            objProductionController.InsertDailyActualCMTPercent(CMTValue, DateTime.Now);
                        }

                    }

                    // End footer

                    int TotalCount = (TotalPassCount + TotalFailCount) * 5;

                    DataSet dsGetBottleNeck;
                    dsGetBottleNeck = objProductionController.GetBottleNeck_QC_HourlyReport_ForFactory(-1, TotalCount, SlotId);
                    DataTable dtQCFaultCount = dsGetBottleNeck.Tables[0];

                    Repeater rptQCFaultDetailsFoo = e.Row.FindControl("rptQCFaultDetailsFoo") as Repeater;

                    rptQCFaultDetailsFoo.DataSource = dtQCFaultCount;
                    rptQCFaultDetailsFoo.DataBind();

                    Label lblQCPassCountFoo = e.Row.FindControl("lblQCPassCountFoo") as Label;
                    Label lblQCFailCountFoo = e.Row.FindControl("lblQCFailCountFoo") as Label;
                    Label lblQCFailPercentFoo = e.Row.FindControl("lblQCFailPercentFoo") as Label;


                    lblQCPassCountFoo.Text = TotalPassCount == 0 ? "" : TotalPassCount.ToString();
                    lblQCFailCountFoo.Text = TotalFailCount == 0 ? "" : TotalFailCount.ToString();

                    if (Convert.ToDouble(TotalFailCount + TotalPassCount) > 0)
                    {
                        double FailPercent = Math.Round(Convert.ToDouble(TotalFailCount) / Convert.ToDouble(TotalFailCount + TotalPassCount) * 100, 0);
                        lblQCFailPercentFoo.Text = FailPercent > 0 ? FailPercent.ToString() + "%" : "";
                    }

                    HtmlTable tblOrderQtyFoo = (HtmlTable)e.Row.FindControl("tblOrderQtyFoo");
                    tblOrderQtyFoo.Visible = false;

                }

                catch (Exception ex)
                {
                    string err = ex.Message.ToString();
                    Application["HourlyError"] = err.ToString();
                    int Results = objProductionController.UpdateHrlyErrorLog(err.ToString(), ProductionUnit, SlotId, LineNo, StyleId);
                }
            }

        }

        protected void dlstInspection_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblInspectionDetails = (Label)e.Item.FindControl("lblInspectionDetails") as Label;
                HtmlTableCell tdInspectionDetails = (HtmlTableCell)e.Item.FindControl("tdInspectionDetails") as HtmlTableCell;

                if (lblInspectionDetails.Text == "")
                    tdInspectionDetails.Visible = false;

            }
        }

        protected void rptPlanning_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblClosingTime = e.Item.FindControl("lblClosingTime") as Label;
                //Label lblDelay = e.Item.FindControl("lblDelay") as Label;
                Label lblFabricCount = e.Item.FindControl("lblFabricCount") as Label;
                Label lblAccessCount = e.Item.FindControl("lblAccessCount") as Label;
                Label lblLinePlanDate = e.Item.FindControl("lblLinePlanDate") as Label;
                HtmlTableCell tdDelay = (HtmlTableCell)e.Item.FindControl("tdDelay");
                //string Delaytxt = "";

                if (lblClosingTime.Text != "")
                {
                    string[] stime = lblClosingTime.Text.Split(':');
                    int iTimeHrs = Convert.ToInt32(stime[0]);
                    int iTimeMins = Convert.ToInt32(stime[1]);
                    var timespan = new TimeSpan(iTimeHrs, iTimeMins, 00);
                    var output = new DateTime().Add(timespan).ToString("hh:mm tt");
                    lblClosingTime.Text = output;
                }

                if (lblFabricCount.Text != "0" && lblFabricCount.Text != "")
                    lblFabricCount.Text = "F(" + lblFabricCount.Text + "),";
                else
                    lblFabricCount.Text = "";

                if (lblAccessCount.Text != "0" && lblAccessCount.Text != "")
                    lblAccessCount.Text = " A(" + lblAccessCount.Text + ")";
                else
                    lblAccessCount.Text = "";

                if (lblLinePlanDate.Text != "")
                {
                    System.TimeSpan diffResult = Convert.ToDateTime(lblLinePlanDate.Text) - DateTime.Now;
                    int DelayDay = diffResult.Days;
                    if (DelayDay > -1 && DelayDay <= 4)
                    {
                        tdDelay.Style.Add("background-color", "#FF0000");
                        lblFabricCount.Style.Add("font-weight", "bold");
                        lblAccessCount.Style.Add("font-weight", "bold");
                        lblLinePlanDate.Style.Add("font-weight", "bold");
                    }
                    else
                    {
                        tdDelay.Style.Add("background-color", "White");
                        lblFabricCount.Style.Remove("font-weight");
                        lblAccessCount.Style.Remove("font-weight");
                        lblLinePlanDate.Style.Remove("font-weight");
                    }
                    lblLinePlanDate.Text = Convert.ToDateTime(lblLinePlanDate.Text).ToString("dd MMM (ddd)");
                }

            }
        }

        protected void rptPlanningDelay_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                Label lblDelay = e.Item.FindControl("lblDelay") as Label;
                Label lblLastSlotStitch = e.Item.FindControl("lblLastSlotStitch") as Label;
                Label lblLastSlotFinish = e.Item.FindControl("lblLastSlotFinish") as Label;

                HtmlTableCell tdDelay = (HtmlTableCell)e.Item.FindControl("tdDelay");
                string Delaytxt = "";


                Delaytxt = lblDelay.Text;
                if (Delaytxt.IndexOf("Days", StringComparison.CurrentCultureIgnoreCase) > -1)
                {
                    if (Delaytxt.IndexOf("-", StringComparison.CurrentCultureIgnoreCase) > -1)
                    {
                        tdDelay.Style.Add("background-color", "green");
                    }
                    else
                    {
                        tdDelay.Style.Add("background-color", "#FF0000");
                    }
                }
                else
                {
                    lblDelay.Style.Remove("Color");
                    lblDelay.Style.Add("Color", "black");
                    tdDelay.Style.Add("background-color", "#FFffff");
                }

            }
        }

        protected void BottleNeck_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblFactoryWorkSpace = (Label)e.Item.FindControl("lblFactoryWorkSpace");
                HiddenField hdnSectionName = (HiddenField)e.Item.FindControl("hdnSectionName");
                lblFactoryWorkSpace.Text = lblFactoryWorkSpace.Text + " (" + hdnSectionName.Value + ")";
            }
        }

        protected void rptQCFaultDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblFaultCode = (Label)e.Item.FindControl("lblFaultCode") as Label;
                Label lblFaultCount = (Label)e.Item.FindControl("lblFaultCount") as Label;
                Label lblFaultPercent = (Label)e.Item.FindControl("lblFaultPercent") as Label;

                if (lblFaultCount.Text != "")
                    lblFaultCount.Text = "(" + lblFaultCount.Text + ")";

                if ((lblFaultPercent.Text != "") && (lblFaultPercent.Text != "0"))
                    lblFaultPercent.Text = lblFaultPercent.Text + "%";
                else
                    lblFaultPercent.Text = "";

            }
        }

        protected void rptQCFaultDetailsFoo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblFaultCodeFoo = (Label)e.Item.FindControl("lblFaultCodeFoo") as Label;
                Label lblFaultCountFoo = (Label)e.Item.FindControl("lblFaultCountFoo") as Label;
                Label lblFaultPercentFoo = (Label)e.Item.FindControl("lblFaultPercentFoo") as Label;

                if (lblFaultCountFoo.Text != "")
                    lblFaultCountFoo.Text = "(" + lblFaultCountFoo.Text + ")";

                if ((lblFaultPercentFoo.Text != "") && (lblFaultPercentFoo.Text != "0"))
                    lblFaultPercentFoo.Text = lblFaultPercentFoo.Text + "%";
                else
                    lblFaultPercentFoo.Text = "";
            }
        }

        protected void gvPending_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataTable dtPending = (DataTable)ViewState["dtPending"];
            Int16 IsCluster = 0;
            if (ViewState["IsCluster"] != null)
                IsCluster = Convert.ToInt16(ViewState["IsCluster"]);

            int ColCount = dtPending.Columns.Count;
            int RowIndex = 0;
            string strex = string.Empty;
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 0; i < ColCount; i++)
                {
                    string ExFactory = dtPending.Columns[i].ColumnName;
                    if (i == 0)
                    {
                        e.Row.Cells[i].Text = "";
                    }
                    else if (ExFactory.Substring(0, 3) == "CEX")
                    {
                        ExFactory = ExFactory.Substring(3, 8);
                        string year = ExFactory.Substring(0, 4);
                        string Month = ExFactory.Substring(4, 2);
                        string Days = ExFactory.Substring(6, 2);
                        strex = Month + "-" + Days + "-" + year;
                        DateTime strexDT = Convert.ToDateTime(strex);

                        string HeaderText = " <span style='width:20%; background-color:#FDFD96; font-size:8px; font-weight:bold;color:Black !important;'>" + "(C) " + strexDT.ToString("dd MMM (ddd)") + "</span>";
                        e.Row.Cells[i].Text = HeaderText;
                    }
                    else
                    {
                        ExFactory = ExFactory.Substring(2, 8);
                        string year = ExFactory.Substring(0, 4);
                        string Month = ExFactory.Substring(4, 2);
                        string Days = ExFactory.Substring(6, 2);
                        strex = Month + "-" + Days + "-" + year;
                        DateTime strexDT = Convert.ToDateTime(strex);

                        string HeaderText = " <span style='width:20%; background-color:#FDFD96; font-size:8px; font-weight:bold;color:Black !important;'>" + strexDT.ToString("dd MMM (ddd)") + "</span>";
                        e.Row.Cells[i].Text = HeaderText;
                    }
                }
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPendingCol = (Label)e.Row.FindControl("lblPendingCol");
                RowIndex = e.Row.RowIndex;
                for (int i = 0; i < ColCount; i++)
                {
                    if (i != 0)
                    {
                        if (lblPendingCol.Text == "Pnd St. Qty")
                        {
                            lblPendingCol.Text = "Pnd St. Qty (fin. Qty)";
                            e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;
                        }
                        if (RowIndex == 0)
                        {
                            if (dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString() != "")
                            {
                                e.Row.Cells[i].Text = dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString();
                                e.Row.Cells[i].CssClass = "StitchPendingQty";
                            }
                        }
                        if (RowIndex == 1)
                        {
                            if (dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString() != "")
                            {
                                string sDate = dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString();
                                string sEstDate = "";
                                string EndSlot = "";
                                string sEstHrs = "";
                                string EstDateWithSlot = "";
                                int FabricQty = 0;
                                string FabricEta = "";
                                DateTime EstDate;

                                if (sDate != "")
                                {
                                    string[] ArrFabric = sDate.Split('&');
                                    if (ArrFabric.Length > 1)
                                    {
                                        FabricQty = Convert.ToInt32(ArrFabric[1].ToString());
                                        sDate = ArrFabric[0].ToString();

                                        if (ArrFabric.Length > 2)
                                            FabricEta = ArrFabric[2].ToString();
                                    }
                                    if (IsCluster == 1)
                                    {
                                        EstDate = Convert.ToDateTime(sDate);
                                        EstDateWithSlot = EstDate.ToString("dd MMM (ddd)");
                                    }
                                    else
                                    {
                                        string[] ArrsDate = sDate.Split('-');
                                        if (ArrsDate.Length > 2)
                                        {
                                            sEstDate = ArrsDate[0].ToString();
                                            EndSlot = ArrsDate[1].ToString();
                                            sEstHrs = ArrsDate[2].ToString();
                                        }
                                        else
                                        {
                                            if (ArrsDate.Length > 1)
                                            {
                                                sEstDate = ArrsDate[0].ToString();
                                                EndSlot = ArrsDate[1].ToString();
                                            }
                                            else
                                            {
                                                sEstDate = ArrsDate[0].ToString();
                                            }
                                        }
                                        EstDate = Convert.ToDateTime(sEstDate);

                                        EstDateWithSlot = EstDate.ToString("dd MMM (ddd)") + " " + EndSlot + " <span style='color:gray; font-weight:normal !important'> " + sEstHrs + "</span>";
                                        //if(i == 1)
                                        //    EstDateWithSlot = EstDate.ToString("dd MMM (ddd)") + " " + EndSlot + " <span style='color:gray; font-weight:normal !important'> " + sEstHrs + "</span>";
                                        //else
                                        //    EstDateWithSlot = EstDate.ToString("dd MMM (ddd)");
                                    }

                                    string ExFactory = dtPending.Columns[i].ColumnName;
                                    if (ExFactory.Substring(0, 3) == "CEX")
                                    {
                                        ExFactory = ExFactory.Substring(3, 8);
                                        string year = ExFactory.Substring(0, 4);
                                        string Month = ExFactory.Substring(4, 2);
                                        string Days = ExFactory.Substring(6, 2);
                                        strex = Month + "-" + Days + "-" + year;
                                        DateTime strexDT = Convert.ToDateTime(strex);

                                        if (EstDate.Date <= strexDT.Date)
                                            e.Row.Cells[i].CssClass = "EstDateLessExFactoryRowindex1";
                                        else
                                            e.Row.Cells[i].CssClass = "EstDateGreaterExFactoryRowindex1";

                                        string sHeaderText = ((GridView)sender).HeaderRow.Cells[i].Text;

                                        if (FabricQty == 0)
                                            sHeaderText = sHeaderText + " <span data-title=' " + FabricEta + "' style='float:right; background-color:Red;min-width: 14px; color:White;'>&nbsp;&nbsp;&nbsp;</span>";

                                        else if ((FabricQty <= 30) && (FabricQty > 0))
                                            sHeaderText = sHeaderText + " <span data-title=' " + FabricEta + "' style='float:right; background-color:Red;min-width: 14px; color:White;'>" + FabricQty.ToString() + "%</span>";


                                        else if ((FabricQty > 30) && (FabricQty <= 90))
                                            sHeaderText = sHeaderText + " <span data-title=' " + FabricEta + "' style='float:right; background-color:Orange; color:Black;'>" + FabricQty.ToString() + "%</span>";

                                        else if (FabricQty > 90)
                                            sHeaderText = sHeaderText + " <span style='float:right; background-color:Green; color:White;'>" + FabricQty.ToString() + "%</span>";


                                        ((GridView)sender).HeaderRow.Cells[i].Text = sHeaderText;
                                        e.Row.Cells[i].Text = EstDateWithSlot;
                                    }
                                    else
                                    {
                                        ExFactory = ExFactory.Substring(2, 8);
                                        string year = ExFactory.Substring(0, 4);
                                        string Month = ExFactory.Substring(4, 2);
                                        string Days = ExFactory.Substring(6, 2);
                                        strex = Month + "-" + Days + "-" + year;

                                        DateTime strexDT = Convert.ToDateTime(strex);

                                        if (EstDate.Date <= strexDT.Date)
                                            e.Row.Cells[i].CssClass = "EstDateLessExFactoryRowindex1";
                                        else
                                            e.Row.Cells[i].CssClass = "EstDateGreaterExFactoryRowindex1";

                                        e.Row.Cells[i].Text = EstDateWithSlot;

                                        string sHeaderText = ((GridView)sender).HeaderRow.Cells[i].Text;

                                        if (FabricQty == 0)
                                            sHeaderText = sHeaderText + " <span data-title=' " + FabricEta + "' style='float:right; background-color:Red;min-width: 14px; color:White;'>&nbsp;&nbsp;&nbsp;</span>";

                                        else if ((FabricQty <= 30) && (FabricQty > 0))
                                            sHeaderText = sHeaderText + " <span data-title=' " + FabricEta + "' style='float:right; background-color:Red;min-width: 14px; color:White;'>" + FabricQty.ToString() + "%</span>";


                                        else if ((FabricQty > 30) && (FabricQty <= 90))
                                            sHeaderText = sHeaderText + " <span data-title=' " + FabricEta + "' style='float:right; background-color:Orange; color:Black;'>" + FabricQty.ToString() + "%</span>";

                                        else if (FabricQty > 90)
                                            sHeaderText = sHeaderText + " <span style='float:right; background-color:Green; color:White;'>" + FabricQty.ToString() + "%</span>";

                                        ((GridView)sender).HeaderRow.Cells[i].Text = sHeaderText;
                                    }
                                }
                            }
                        }
                        if (RowIndex == 2)
                        {
                            if (dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString() != "")
                            {
                                string sDate = dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString();
                                string sEstDate = "";
                                string EndSlot = "";
                                string sEstHrs = "";
                                string EstDateWithSlot = "";
                                DateTime EstDate;

                                if (sDate != "")
                                {
                                    string[] ArrsDate = sDate.Split('-');
                                    if (ArrsDate.Length > 2)
                                    {
                                        sEstDate = ArrsDate[0].ToString();
                                        EndSlot = ArrsDate[1].ToString();
                                        sEstHrs = ArrsDate[2].ToString();
                                    }
                                    else
                                    {
                                        if (ArrsDate.Length > 1)
                                        {
                                            sEstDate = ArrsDate[0].ToString();
                                            EndSlot = ArrsDate[1].ToString();
                                        }
                                        else
                                        {
                                            sEstDate = ArrsDate[0].ToString();
                                        }
                                    }
                                    EstDate = Convert.ToDateTime(sEstDate);

                                    EstDateWithSlot = EstDate.ToString("dd MMM (ddd)") + " " + EndSlot + " <span style='color:gray; font-weight:normal !important'> " + sEstHrs + "</span>";

                                    //if (i == 1)
                                    //    EstDateWithSlot = EstDate.ToString("dd MMM (ddd)") + " " + EndSlot + " <span style='color:gray'> " + sEstHrs + "</span>";
                                    //else
                                    //    EstDateWithSlot = EstDate.ToString("dd MMM (ddd)");


                                    string ExFactory = dtPending.Columns[i].ColumnName;
                                    if (ExFactory.Substring(0, 3) == "CEX")
                                    {
                                        ExFactory = ExFactory.Substring(3, 8);
                                        string year = ExFactory.Substring(0, 4);
                                        string Month = ExFactory.Substring(4, 2);
                                        string Days = ExFactory.Substring(6, 2);
                                        strex = Month + "-" + Days + "-" + year;
                                        DateTime strexDT = Convert.ToDateTime(strex);
                                        if (EstDate.Date <= strexDT.Date)
                                            e.Row.Cells[i].CssClass = "EstDateLessExFactory";
                                        else
                                            e.Row.Cells[i].CssClass = "EstDateGreaterExFactory";

                                        e.Row.Cells[i].Text = EstDateWithSlot;
                                    }
                                    else
                                    {
                                        ExFactory = ExFactory.Substring(2, 8);
                                        string year = ExFactory.Substring(0, 4);
                                        string Month = ExFactory.Substring(4, 2);
                                        string Days = ExFactory.Substring(6, 2);
                                        strex = Month + "-" + Days + "-" + year;
                                        DateTime strexDT = Convert.ToDateTime(strex);

                                        if (EstDate.Date <= strexDT.Date)
                                            e.Row.Cells[i].CssClass = "EstDateLessExFactory";
                                        else
                                            e.Row.Cells[i].CssClass = "EstDateGreaterExFactory";

                                        e.Row.Cells[i].Text = EstDateWithSlot;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void HideStitchingUnUsedSlot()
        {
            SlotId = Convert.ToInt32(hdnSlotId.Value);
            SlotId = SlotId + 3;
            for (int i = SlotId; i < 19; i++)
            {
                gvHourlyStitchingReport.Columns[i].Visible = false;
                gvHourlyStitchingReport.Width = Convert.ToInt32(hdnSlotId.Value) * 35 + 1365;
            }
        }

        private void HideStitchingTimingUnUsedSlot()
        {
            SlotId = Convert.ToInt32(hdnSlotId.Value);
            //SlotId = SlotId + 5;
            for (int i = SlotId; i < 16; i++)
            {
                grvSlotTiming.Columns[i].Visible = false;
            }
        }

        #endregion Stitching


        public string GetGridviewData(GridView gv)
        {
            StringBuilder strBuilder = new StringBuilder();
            StringWriter strWriter = new StringWriter(strBuilder);
            HtmlTextWriter htw = new HtmlTextWriter(strWriter);
            gv.RenderControl(htw);
            return strBuilder.ToString();
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            string strMailBody = GetGridviewData(gvHourlyStitchingReport);
        }
        }
    }
