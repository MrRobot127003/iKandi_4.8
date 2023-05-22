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
    public partial class HourlyStitchingReport : System.Web.UI.UserControl
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
        //declare the variable for finishperobcost
        Double finishperobcost = 0;

        int Slot1 = 0;
        int Slot2 = 0;
        int Slot3 = 0;
        int Slot4 = 0;
        int Slot5 = 0;
        int Slot6 = 0;
        int Slot7 = 0;
        int Slot8 = 0;
        int Slot9 = 0;
        int Slot10 = 0;
        int Slot11 = 0;
        int Slot12 = 0;
        int Slot13 = 0;
        int Slot14 = 0;
        int Slot15 = 0;
        int Slot16 = 0;
        int Slot17 = 0;
        int Slot18 = 0;
        int Slot19 = 0;
        int Slot20 = 0;
        int Slot21 = 0;
        int Slot22 = 0;
        int Slot23 = 0;
        int Slot24 = 0;

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
        int Total_Slot17 = 0;
        int Total_Slot18 = 0;
        int Total_Slot19 = 0;
        int Total_Slot20 = 0;
        int Total_Slot21 = 0;
        int Total_Slot22 = 0;
        int Total_Slot23 = 0;
        int Total_Slot24 = 0;

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
        int Slot17TotalOB = 0;
        int Slot18TotalOB = 0;
        int Slot19TotalOB = 0;
        int Slot20TotalOB = 0;
        int Slot21TotalOB = 0;
        int Slot22TotalOB = 0;
        int Slot23TotalOB = 0;
        int Slot24TotalOB = 0;


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
        int Total_DHU17 = 0;
        int Total_DHU18 = 0;
        int Total_DHU19 = 0;
        int Total_DHU20 = 0;
        int Total_DHU21 = 0;
        int Total_DHU22 = 0;
        int Total_DHU23 = 0;
        int Total_DHU24 = 0;

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
        double Total_StitchEff17 = 0;
        double Total_StitchEff18 = 0;
        double Total_StitchEff19 = 0;
        double Total_StitchEff20 = 0;
        double Total_StitchEff21 = 0;
        double Total_StitchEff22 = 0;
        double Total_StitchEff23 = 0;
        double Total_StitchEff24 = 0;

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
        int Total_Achievement17 = 0;
        int Total_Achievement18 = 0;
        int Total_Achievement19 = 0;
        int Total_Achievement20 = 0;
        int Total_Achievement21 = 0;
        int Total_Achievement22 = 0;
        int Total_Achievement23 = 0;
        int Total_Achievement24 = 0;

        double TotalBreakEvenQty = 0;
        double TotalBreakEvenEff = 0;

        int ActiveSlotCount = 0;

        int TargetEff_Total = 0;
        int TargetQty_Total = 0;
        int TodayEfficiency_Stitch_Total = 0;        
        int StyleEfficiency_Stitch_Total = 0;

        int FactoryTotal = 0;
        int EfficencyTotal = 0;
        double StitchSAM_Total = 0;
        double FinishSAM_Total = 0;
        double StitchSAM_OB_Total = 0;
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
        int Factory_BreakEvenEff = 0;
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

        double CuttingPerPcsCost = 0;
        double StichingPerOBCost = 0;
        double FinishingPerOBCost = 0;
        double FactoryOverHeadPerPcs = 0;

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
        double BIPLPriceSlot17 = 0;
        double BIPLPriceSlot18 = 0;
        double BIPLPriceSlot19 = 0;
        double BIPLPriceSlot20 = 0;
        double BIPLPriceSlot21 = 0;
        double BIPLPriceSlot22 = 0;
        double BIPLPriceSlot23 = 0;
        double BIPLPriceSlot24 = 0;

        int PreviousUnit = 0;
        int PassCount = 0;
        int FailCount = 0;
        int TotalPassCount = 0;
        int TotalFailCount = 0;

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
            ds = objProductionController.GetHourlyStitchingReport("", -1, -1, -1, -1, -1, -1, "SlotTime");
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
            finishperobcost = Convert.ToDouble(dt1.Rows[0]["FinishingPerOBCost"].ToString());

        }

        private void GetStitchingHourlyReport()
        {
            DataSet ds;
            Stitch1EmptyMsg.Visible = false;
            lblStitch1EmptyMsg1.Text = "";
            lblStitch1EmptyMsg2.Text = "";
            ds = objProductionController.GetHourlyStitchingReport("", StyleId, -1, -1, -1, -1, -1, "HourlyReport");
            if(ds.Tables.Count > 1)
            {
                DataTable dtAchievement = ds.Tables[1];
                ViewState["dtAchievement"] = dtAchievement;
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

                //if (lblUnit.Text == lblPreviousUnit.Text)
                //{
                //    if (previousRow.Cells[0].RowSpan == 0)
                //    {
                //        if (row.Cells[0].RowSpan == 0)
                //        {
                //            previousRow.Cells[0].RowSpan += 2;
                //        }
                //        else
                //        {
                //            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                //        }
                //        row.Cells[0].Visible = false;
                //    }
                //}


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

                Label lblSlot17Timing = (Label)e.Row.FindControl("lblSlot17Timing");
                lblSlot17Timing.Text = dtSlot.Rows[0]["SlotStart17"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd17"].ToString();

                Label lblSlot18Timing = (Label)e.Row.FindControl("lblSlot18Timing");
                lblSlot18Timing.Text = dtSlot.Rows[0]["SlotStart18"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd18"].ToString();

                Label lblSlot19Timing = (Label)e.Row.FindControl("lblSlot19Timing");
                lblSlot19Timing.Text = dtSlot.Rows[0]["SlotStart19"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd19"].ToString();

                Label lblSlot20Timing = (Label)e.Row.FindControl("lblSlot20Timing");
                lblSlot20Timing.Text = dtSlot.Rows[0]["SlotStart20"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd20"].ToString();

                Label lblSlot21Timing = (Label)e.Row.FindControl("lblSlot21Timing");
                lblSlot21Timing.Text = dtSlot.Rows[0]["SlotStart21"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd21"].ToString();

                Label lblSlot22Timing = (Label)e.Row.FindControl("lblSlot22Timing");
                lblSlot22Timing.Text = dtSlot.Rows[0]["SlotStart22"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd22"].ToString();

                Label lblSlot23Timing = (Label)e.Row.FindControl("lblSlot23Timing");
                lblSlot23Timing.Text = dtSlot.Rows[0]["SlotStart23"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd23"].ToString();


            }
        }

        protected void gvHourlyStitchingReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[30].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {

                    HtmlTableCell tdserialno = (HtmlTableCell)e.Row.FindControl("tdserialno");
                    HiddenField hdnserialColorCode = (HiddenField)e.Row.FindControl("hdnserialColorCode");
                    HiddenField hdnOrderId = (HiddenField)e.Row.FindControl("hdnOrderId");
                    HtmlTableCell tdstcpty = (HtmlTableCell)e.Row.FindControl("tdstcpty");
                    HtmlTableCell tdFncpty = (HtmlTableCell)e.Row.FindControl("tdFncpty");                   

                    string ClientColorCode = DataBinder.Eval(e.Row.DataItem, "ClientColorCode").ToString();
                    if (ClientColorCode != "")
                    {
                        tdserialno.Style.Add(HtmlTextWriterStyle.BackgroundColor, ClientColorCode);
                    }
                    ActiveSlotCount = 0;
                    int TotalZeroProductivity = 0;
                    HiddenField hdnEmptyMsg = (HiddenField)e.Row.FindControl("hdnEmptyMsg");
                    Label lblUnit = (Label)e.Row.FindControl("lblUnit");

                    Label lblDay = (Label)e.Row.FindControl("lblDay");
                    Label lblOrderQty = (Label)e.Row.FindControl("lblOrderQty");

                    Label lblLineNumber = (Label)e.Row.FindControl("lblLineNumber");
                    Label lblProdDay = (Label)e.Row.FindControl("lblProdDay");
                    Label lblCOT = (Label)e.Row.FindControl("lblCOT");
                    Label lblFinishQty = (Label)e.Row.FindControl("lblFinishQty");

                    Label lblStchSAM = (Label)e.Row.FindControl("lblStchSAM");
                    Label lblStchActOB = (Label)e.Row.FindControl("lblStchActOB");
                    Label lblStchAgreedOB = (Label)e.Row.FindControl("lblStchAgreedOB");

                    Label lblStchPkCpty = (Label)e.Row.FindControl("lblStchPkCpty");
                    //Label lblStchPkOB = (Label)e.Row.FindControl("lblStchPkOB");
                    Label lblStchPkEff = (Label)e.Row.FindControl("lblStchPkEff");
                    Label lblStitchQty = (Label)e.Row.FindControl("lblStitchQty");

                  //  Label lblWIPCut = (Label)e.Row.FindControl("lblWIPCut");
                   // Label lblWIPStiched = (Label)e.Row.FindControl("lblWIPStiched");
                   // Label lblWIPFinished = (Label)e.Row.FindControl("lblWIPFinished");

                    Label lblwipCutPcs = (Label)e.Row.FindControl("lblwipCutPcs");
                    Label lblWIPStichedPcs = (Label)e.Row.FindControl("lblWIPStichedPcs");
                    Label lblWIPFinishedPcs = (Label)e.Row.FindControl("lblWIPFinishedPcs");

                   // HtmlTableCell dvWipS = (HtmlTableCell)e.Row.FindControl("dvWipS");
                    HtmlTableCell dvWipF = (HtmlTableCell)e.Row.FindControl("dvWipF");

                    HtmlTableCell tdTodayEff = (HtmlTableCell)e.Row.FindControl("tdTodayEff");
                    //Label lblBreakEvenEff = (Label)e.Row.FindControl("lblBreakEvenEff");
                    Label lblTargetEff = (Label)e.Row.FindControl("lblTargetEff");
                    Label lblTodayEff_Stitch = (Label)e.Row.FindControl("lblTodayEff_Stitch");
                    Label lblStyleEff_Stitch = (Label)e.Row.FindControl("lblStyleEff_Stitch");
                    Label lblTotalDHU = (Label)e.Row.FindControl("lblTotalDHU");
                    Label lblTargetQty = (Label)e.Row.FindControl("lblTargetQty");
                    Label lblBreakEvenQty = (Label)e.Row.FindControl("lblBreakEvenQty");

                    //Label lblFinQtyVal = (Label)e.Row.FindControl("lblFinQtyVal");
                    // Finishing Section               
                    Label lblFinActOB = (Label)e.Row.FindControl("lblFinActOB");
                   // Label lblFinAgreedOB = (Label)e.Row.FindControl("lblFinAgreedOB");
                    Label lblFinPkCpty = (Label)e.Row.FindControl("lblFinPkCpty");
                    Label lblFinPressActualOB = (Label)e.Row.FindControl("lblFinPressActualOB");
                    Label lblTodayPassFinish = (Label)e.Row.FindControl("lblTodayPassFinish");
                    Label lblTodayPassStitch = (Label)e.Row.FindControl("lblTodayPassStitch");
                    Label lblStchAvgPcsHr = (Label)e.Row.FindControl("lblStchAvgPcsHr");
                    Label lblTodayAltPcs = (Label)e.Row.FindControl("lblTodayAltPcs");
                    Label lblTodayDHU = (Label)e.Row.FindControl("lblTodayDHU");
                    Label lblFabQty = (Label)e.Row.FindControl("lblFabQty");
                    Label lblCutQty = (Label)e.Row.FindControl("lblCutQty");
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
                    Label lblSlot17Pass = (Label)e.Row.FindControl("lblSlot17Pass");
                    Label lblSlot18Pass = (Label)e.Row.FindControl("lblSlot18Pass");
                    Label lblSlot19Pass = (Label)e.Row.FindControl("lblSlot19Pass");
                    Label lblSlot20Pass = (Label)e.Row.FindControl("lblSlot20Pass");
                    Label lblSlot21Pass = (Label)e.Row.FindControl("lblSlot21Pass");
                    Label lblSlot22Pass = (Label)e.Row.FindControl("lblSlot22Pass");
                    Label lblSlot23Pass = (Label)e.Row.FindControl("lblSlot23Pass");
                    Label lblSlot24Pass = (Label)e.Row.FindControl("lblSlot24Pass");


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
                    Label lblSlot17DHU = (Label)e.Row.FindControl("lblSlot17DHU");
                    Label lblSlot18DHU = (Label)e.Row.FindControl("lblSlot18DHU");
                    Label lblSlot19DHU = (Label)e.Row.FindControl("lblSlot19DHU");
                    Label lblSlot20DHU = (Label)e.Row.FindControl("lblSlot20DHU");
                    Label lblSlot21DHU = (Label)e.Row.FindControl("lblSlot21DHU");
                    Label lblSlot22DHU = (Label)e.Row.FindControl("lblSlot22DHU");
                    Label lblSlot23DHU = (Label)e.Row.FindControl("lblSlot23DHU");
                    Label lblSlot24DHU = (Label)e.Row.FindControl("lblSlot24DHU");

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
                    lblSlot17Pass.CssClass = "font-normal";
                    lblSlot18Pass.CssClass = "font-normal";
                    lblSlot19Pass.CssClass = "font-normal";
                    lblSlot20Pass.CssClass = "font-normal";
                    lblSlot21Pass.CssClass = "font-normal";
                    lblSlot22Pass.CssClass = "font-normal";
                    lblSlot23Pass.CssClass = "font-normal";
                    lblSlot24Pass.CssClass = "font-normal";



                    //End Of Code//

                    CheckBox ChkLoadStitch = (CheckBox)e.Row.FindControl("ChkLoadStitch");
                    HtmlTable tblEffHide = (HtmlTable)e.Row.FindControl("tblEffHide");
                    // tblEffHide.Attributes.Add("class", "show-table");
                    tblEffHide.Visible = true;
                    HtmlTable tblEffShow = (HtmlTable)e.Row.FindControl("tblEffShow");
                    //tblEffShow.Attributes.Add("class", "hide-table");
                    e.Row.Cells[30].Visible = false;

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

                    // WIP BIPL
                    if (WIPBIPL_Cutting == 0)
                        WIPBIPL_Cutting = DataBinder.Eval(e.Row.DataItem, "WIPBIPL_Cutting") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WIPBIPL_Cutting"));

                    if (WIPBIPL_Stitching == 0)
                        WIPBIPL_Stitching = DataBinder.Eval(e.Row.DataItem, "WIPBIPL_Stitching") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WIPBIPL_Stitching"));

                    if (WIPBIPL_Finishing == 0)
                        WIPBIPL_Finishing = DataBinder.Eval(e.Row.DataItem, "WIPBIPL_Finishing") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WIPBIPL_Finishing"));

                    if (WIPBIPL_Fabric1CheckedQty == 0)
                        WIPBIPL_Fabric1CheckedQty = DataBinder.Eval(e.Row.DataItem, "WIPBIPL_Fabric1CheckedQty") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WIPBIPL_Fabric1CheckedQty"));

                    if (WIPBIPL_PrevStitching == 0)
                        WIPBIPL_PrevStitching = DataBinder.Eval(e.Row.DataItem, "WIPBIPL_PrevStitching") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WIPBIPL_PrevStitching"));

                    if (WIPBIPL_PrevFinishing == 0)
                        WIPBIPL_PrevFinishing = DataBinder.Eval(e.Row.DataItem, "WIPBIPL_PrevFinishing") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "WIPBIPL_PrevFinishing"));


                    //----------------------------------------------------  STITCH SECTION ---------------------------------------------------------------------


                    int TodayPassPcsStitch = DataBinder.Eval(e.Row.DataItem, "TodayPassPcsStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayPassPcsStitch"));

                    double StitchSAM = DataBinder.Eval(e.Row.DataItem, "StitchSAM") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "StitchSAM"));
                    int StitchActualOB = DataBinder.Eval(e.Row.DataItem, "StitchActualOB") == DBNull.Value ? -1 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StitchActualOB"));
                    int StitchOB = DataBinder.Eval(e.Row.DataItem, "StitchOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StitchOB"));

                    int PeakCapecity = DataBinder.Eval(e.Row.DataItem, "PeakCapecity") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakCapecity"));
                    int PeakOB = DataBinder.Eval(e.Row.DataItem, "PeakOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakOB"));
                    int COT = DataBinder.Eval(e.Row.DataItem, "COTValue") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COTValue"));

                    int StitchDoubleOB = DataBinder.Eval(e.Row.DataItem, "StitchDoubleOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StitchDoubleOB"));

                    int PeakEff = DataBinder.Eval(e.Row.DataItem, "PeakEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakEff"));
                    int StitchQty = DataBinder.Eval(e.Row.DataItem, "TotalStitchedQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalStitchedQty"));

                    int TodayAltPcs = DataBinder.Eval(e.Row.DataItem, "TodayAltPcs") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayAltPcs"));
                    int TodayDHU = DataBinder.Eval(e.Row.DataItem, "DHU_Today") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DHU_Today"));
                    int StchAvgPcs = DataBinder.Eval(e.Row.DataItem, "TodayAvgStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayAvgStitch"));

                    int TargetEff = DataBinder.Eval(e.Row.DataItem, "TargetEfficiency") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetEfficiency"));
                    int BreakEvenEff = DataBinder.Eval(e.Row.DataItem, "BreakEvenEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BreakEvenEff"));
                    int TargetQty = DataBinder.Eval(e.Row.DataItem, "TargetQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetQty"));
                    int TodayEfficiency_Stitch = DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Stitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Stitch"));

                    int StyleEfficiency_Stitch = DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Stitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Stitch"));
                    int BreakEvenQty = DataBinder.Eval(e.Row.DataItem, "BreakEvenQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BreakEvenQty"));
                    int ProdDay = DataBinder.Eval(e.Row.DataItem, "ProdDay") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ProdDay"));

                    int TodayAchievement = DataBinder.Eval(e.Row.DataItem, "TodayAchievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayAchievement"));


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
                        double StitchQtyNew = Math.Round(Convert.ToDouble(StitchQty) / 1000,1);
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
                    //if (StitchActualOB == 0)
                    //    StitchActualOB = -1;

                    if (StitchActualOB != -1)
                    {
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
                                double PeakCapecityNew = Math.Round(Convert.ToDouble(PeakCapecity) / 1000,1);
                                if (PeakCapecityNew > 99.9)
                                {
                                    PeakCapecityNew = Math.Round(PeakCapecityNew, 0);
                                    lblStchPkCpty.Text = PeakCapecityNew.ToString() +"k Pcs";
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

                        lblStchActOB.Text = StitchActualOB == 0 ? "" : StitchActualOB.ToString();

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
                            if (StitchDoubleOB == 1)
                                lblStchAgreedOB.Text = StitchOB == 0 ? "" : "(" + StitchOB.ToString() + " D)";
                            else
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
                        // updated rsb
                        lblTodayAltPcs.Text = TodayAltPcs == 0 ? "" : TodayAltPcs.ToString("#,##0");  // updated rsb
                        lblTodayDHU.Text = TodayDHU == 0 ? "" : TodayDHU.ToString() + "%";

                       
                        lblTodayAchieved.Text = TodayAchievement == 0 ? "" : TodayAchievement.ToString() + "%";
                        //Updated By Prabhaker on 24/may/18
                        if (TodayAchievement > 0 && TodayAchievement < 81)
                        {
                            lblTodayAchieved.ForeColor = Color.Red;
                        }
                        //if (TodayAchievement > 79 && TodayAchievement < 86)
                        //{
                        //    lblTodayAchieved.ForeColor = Color.Orange;
                        //}
                        //if (TodayAchievement > 85)
                        else
                        {
                            lblTodayAchieved.ForeColor = Color.Green;
                        }

                        //End


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
                            lblStchAvgPcsHr.Text = StchAvgPcs == 0 ? "" : "(" + StchAvgPcs.ToString("#,##0") + " pphr)"; // updated rsb 
                        }

                        // Update by RSB on dated 22 september 2017 for color change when BE Eff or BE Pcs are <=0
                        //if (BreakEvenEff > 0)
                        //{
                        //    if (TodayEfficiency_Stitch >= BreakEvenEff)
                        //        lblTodayEff_Stitch.Style.Add("color", "green");
                        //    else
                        //        lblTodayEff_Stitch.Style.Add("color", "#FF0000");
                        //}
                        //else
                        //{
                        //    lblTodayEff_Stitch.Style.Add("color", "Black");
                        //}
                        // End of Update by RSB on dated 22 september 2017 for color change when BE Eff or BE Pcs are <=0                 

                        lblTargetEff.Text = TargetEff > 0 ? TargetEff + "%" : "";
                       // lblBreakEvenEff.Text = BreakEvenEff > 0 ? BreakEvenEff + "%" : "";
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
                                Double BreakEvenQtyNew = Math.Round( Convert.ToDouble(BreakEvenQty) / 1000,1);
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
                        //Add By Prabhaker code  07-Nov-2017
                        if (BreakEvenQty <= StchAvgPcs)
                        {
                            lblBreakEvenQty.Style.Add("color", "green");
                        }
                        else
                        {
                            lblBreakEvenQty.Style.Add("color", "#FF0000");
                        }
                        //End of Prabhaker

                        if (TargetQty > 0)
                        {
                            HtmlTableCell tdSlot1Pass = (HtmlTableCell)e.Row.FindControl("tdSlot1Pass");

                            Slot1 = DataBinder.Eval(e.Row.DataItem, "Slot1Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1Pass"));
                            if (Slot1 > 0)
                            {

                                if (((Convert.ToDecimal(Slot1) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot1Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot1Pass.Style.Add("background-color", "#FF0000");
                            }

                            HtmlTableCell tdSlot2Pass = (HtmlTableCell)e.Row.FindControl("tdSlot2Pass");
                            Slot2 = DataBinder.Eval(e.Row.DataItem, "Slot2Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2Pass"));
                            if (Slot2 > 0)
                            {
                                if (((Convert.ToDecimal(Slot2) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot2Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot2Pass.Style.Add("background-color", "#FF0000");
                            }

                            HtmlTableCell tdSlot3Pass = (HtmlTableCell)e.Row.FindControl("tdSlot3Pass");
                            Slot3 = DataBinder.Eval(e.Row.DataItem, "Slot3Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3Pass"));
                            if (Slot3 > 0)
                            {
                                if (((Convert.ToDecimal(Slot3) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot3Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot3Pass.Style.Add("background-color", "#FF0000");
                            }

                            HtmlTableCell tdSlot4Pass = (HtmlTableCell)e.Row.FindControl("tdSlot4Pass");
                            Slot4 = DataBinder.Eval(e.Row.DataItem, "Slot4Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4Pass"));
                            if (Slot4 > 0)
                            {
                                if (((Convert.ToDecimal(Slot4) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)

                                    tdSlot4Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot4Pass.Style.Add("background-color", "#FF0000");
                            }


                            HtmlTableCell tdSlot5Pass = (HtmlTableCell)e.Row.FindControl("tdSlot5Pass");
                            Slot5 = DataBinder.Eval(e.Row.DataItem, "Slot5Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5Pass"));
                            if (Slot5 > 0)
                            {
                                if (((Convert.ToDecimal(Slot5) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot5Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot5Pass.Style.Add("background-color", "#FF0000");
                            }



                            HtmlTableCell tdSlot6Pass = (HtmlTableCell)e.Row.FindControl("tdSlot6Pass");
                            Slot6 = DataBinder.Eval(e.Row.DataItem, "Slot6Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6Pass"));
                            if (Slot6 > 0)
                            {
                                if (((Convert.ToDecimal(Slot6) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot6Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot6Pass.Style.Add("background-color", "#FF0000");
                            }


                            HtmlTableCell tdSlot7Pass = (HtmlTableCell)e.Row.FindControl("tdSlot7Pass");
                            Slot7 = DataBinder.Eval(e.Row.DataItem, "Slot7Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7Pass"));
                            if (Slot7 > 0)
                            {
                                if (((Convert.ToDecimal(Slot7) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot7Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot7Pass.Style.Add("background-color", "#FF0000");
                            }

                            HtmlTableCell tdSlot8Pass = (HtmlTableCell)e.Row.FindControl("tdSlot8Pass");
                            Slot8 = DataBinder.Eval(e.Row.DataItem, "Slot8Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8Pass"));
                            if (Slot8 > 0)
                            {
                                if (((Convert.ToDecimal(Slot8) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot8Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot8Pass.Style.Add("background-color", "#FF0000");
                            }


                            HtmlTableCell tdSlot9Pass = (HtmlTableCell)e.Row.FindControl("tdSlot9Pass");
                            Slot9 = DataBinder.Eval(e.Row.DataItem, "Slot9Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9Pass"));
                            if (Slot9 > 0)
                            {
                                if (((Convert.ToDecimal(Slot9) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot9Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot9Pass.Style.Add("background-color", "#FF0000");
                            }

                            HtmlTableCell tdSlot10Pass = (HtmlTableCell)e.Row.FindControl("tdSlot10Pass");
                            Slot10 = DataBinder.Eval(e.Row.DataItem, "Slot10Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10Pass"));
                            if (Slot10 > 0)
                            {
                                if (((Convert.ToDecimal(Slot10) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot10Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot10Pass.Style.Add("background-color", "#FF0000");
                            }

                            HtmlTableCell tdSlot11Pass = (HtmlTableCell)e.Row.FindControl("tdSlot11Pass");
                            Slot11 = DataBinder.Eval(e.Row.DataItem, "Slot11Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11Pass"));
                            if (Slot11 > 0)
                            {
                                if (((Convert.ToDecimal(Slot11) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot11Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot11Pass.Style.Add("background-color", "#FF0000");
                            }


                            HtmlTableCell tdSlot12Pass = (HtmlTableCell)e.Row.FindControl("tdSlot12Pass");
                            Slot12 = DataBinder.Eval(e.Row.DataItem, "Slot12Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12Pass"));
                            if (Slot12 > 0)
                            {
                                if (((Convert.ToDecimal(Slot12) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot12Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot12Pass.Style.Add("background-color", "#FF0000");
                            }


                            HtmlTableCell tdSlot13Pass = (HtmlTableCell)e.Row.FindControl("tdSlot13Pass");
                            Slot13 = DataBinder.Eval(e.Row.DataItem, "Slot13Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13Pass"));
                            if (Slot13 > 0)
                            {
                                if (((Convert.ToDecimal(Slot13) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot13Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot13Pass.Style.Add("background-color", "#FF0000");
                            }



                            HtmlTableCell tdSlot14Pass = (HtmlTableCell)e.Row.FindControl("tdSlot14Pass");
                            Slot14 = DataBinder.Eval(e.Row.DataItem, "Slot14Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14Pass"));
                            if (Slot14 > 0)
                            {
                                if (((Convert.ToDecimal(Slot14) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot14Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot14Pass.Style.Add("background-color", "#FF0000");
                            }


                            HtmlTableCell tdSlot15Pass = (HtmlTableCell)e.Row.FindControl("tdSlot15Pass");
                            Slot15 = DataBinder.Eval(e.Row.DataItem, "Slot15Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15Pass"));
                            if (Slot15 > 0)
                            {
                                if (((Convert.ToDecimal(Slot15) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot15Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot15Pass.Style.Add("background-color", "#FF0000");

                            }

                            HtmlTableCell tdSlot16Pass = (HtmlTableCell)e.Row.FindControl("tdSlot16Pass");
                            Slot16 = DataBinder.Eval(e.Row.DataItem, "Slot16Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16Pass"));
                            if (Slot16 > 0)
                            {
                                if (((Convert.ToDecimal(Slot16) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot16Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot16Pass.Style.Add("background-color", "#FF0000");
                            }


                            HtmlTableCell tdSlot17Pass = (HtmlTableCell)e.Row.FindControl("tdSlot17Pass");
                            Slot17 = DataBinder.Eval(e.Row.DataItem, "Slot17Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17Pass"));
                            if (Slot17 > 0)
                            {
                                if (((Convert.ToDecimal(Slot17) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot17Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot17Pass.Style.Add("background-color", "#FF0000");
                            }


                            HtmlTableCell tdSlot18Pass = (HtmlTableCell)e.Row.FindControl("tdSlot18Pass");
                            Slot18 = DataBinder.Eval(e.Row.DataItem, "Slot18Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18Pass"));
                            if (Slot18 > 0)
                            {
                                if (((Convert.ToDecimal(Slot18) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot18Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot18Pass.Style.Add("background-color", "#FF0000");
                            }


                            HtmlTableCell tdSlot19Pass = (HtmlTableCell)e.Row.FindControl("tdSlot19Pass");
                            Slot19 = DataBinder.Eval(e.Row.DataItem, "Slot19Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19Pass"));
                            if (Slot19 > 0)
                            {
                                if (((Convert.ToDecimal(Slot19) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot19Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot19Pass.Style.Add("background-color", "#FF0000");
                            }


                            HtmlTableCell tdSlot20Pass = (HtmlTableCell)e.Row.FindControl("tdSlot20Pass");
                            Slot20 = DataBinder.Eval(e.Row.DataItem, "Slot20Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20Pass"));
                            if (Slot20 > 0)
                            {
                                if (((Convert.ToDecimal(Slot20) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot20Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot20Pass.Style.Add("background-color", "#FF0000");

                            }

                            HtmlTableCell tdSlot21Pass = (HtmlTableCell)e.Row.FindControl("tdSlot21Pass");
                            Slot21 = DataBinder.Eval(e.Row.DataItem, "Slot21Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21Pass"));
                            if (Slot21 > 0)
                            {
                                if (((Convert.ToDecimal(Slot21) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot21Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot21Pass.Style.Add("background-color", "#FF0000");

                            }

                            HtmlTableCell tdSlot22Pass = (HtmlTableCell)e.Row.FindControl("tdSlot22Pass");
                            Slot22 = DataBinder.Eval(e.Row.DataItem, "Slot22Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22Pass"));
                            if (Slot22 > 0)
                            {
                                if (((Convert.ToDecimal(Slot22) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot22Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot22Pass.Style.Add("background-color", "#FF0000");

                            }

                            HtmlTableCell tdSlot23Pass = (HtmlTableCell)e.Row.FindControl("tdSlot23Pass");
                            Slot23 = DataBinder.Eval(e.Row.DataItem, "Slot23Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23Pass"));
                            if (Slot23 > 0)
                            {
                                if (((Convert.ToDecimal(Slot23) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot23Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot23Pass.Style.Add("background-color", "#FF0000");
                            }


                            HtmlTableCell tdSlot24Pass = (HtmlTableCell)e.Row.FindControl("tdSlot24Pass");
                            Slot24 = DataBinder.Eval(e.Row.DataItem, "Slot24Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24Pass"));
                            if (Slot24 > 0)
                            {
                                if (((Convert.ToDecimal(Slot24) / Convert.ToDecimal(TargetQty)) * Convert.ToDecimal(100)) > 85)
                                    tdSlot24Pass.Style.Add("background-color", "green");
                                else
                                    tdSlot24Pass.Style.Add("background-color", "#FF0000");

                            }

                        }

                        // End Of Update by RSB on dated 07 November 2017 for color change when (slot production/Target Qty)*100 > 85%
                        // write the code
                        else
                        {
                            lblSlot1Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot2Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot3Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot4Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot5Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot6Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot7Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot8Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot9Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot10Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot11Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot12Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot13Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot14Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot15Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot16Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot17Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot18Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot19Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot20Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot21Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot22Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot23Pass.ForeColor = System.Drawing.Color.Black;
                            lblSlot24Pass.ForeColor = System.Drawing.Color.Black;
                        }

                        TotalZeroProductivity = 0;

                        if (Slot1 > 0)
                            ActiveSlotCount += 1;
                        if (Slot2 > 0)
                            ActiveSlotCount += 1;
                        if (Slot3 > 0)
                            ActiveSlotCount += 1;
                        if (Slot4 > 0)
                            ActiveSlotCount += 1;
                        if (Slot5 > 0)
                            ActiveSlotCount += 1;
                        if (Slot6 > 0)
                            ActiveSlotCount += 1;
                        if (Slot7 > 0)
                            ActiveSlotCount += 1;
                        if (Slot8 > 0)
                            ActiveSlotCount += 1;
                        if (Slot9 > 0)
                            ActiveSlotCount += 1;
                        if (Slot10 > 0)
                            ActiveSlotCount += 1;
                        if (Slot11 > 0)
                            ActiveSlotCount += 1;
                        if (Slot12 > 0)
                            ActiveSlotCount += 1;
                        if (Slot13 > 0)
                            ActiveSlotCount += 1;
                        if (Slot14 > 0)
                            ActiveSlotCount += 1;
                        if (Slot15 > 0)
                            ActiveSlotCount += 1;
                        if (Slot16 > 0)
                            ActiveSlotCount += 1;
                        if (Slot17 > 0)
                            ActiveSlotCount += 1;
                        if (Slot18 > 0)
                            ActiveSlotCount += 1;
                        if (Slot19 > 0)
                            ActiveSlotCount += 1;
                        if (Slot20 > 0)
                            ActiveSlotCount += 1;
                        if (Slot21 > 0)
                            ActiveSlotCount += 1;
                        if (Slot22 > 0)
                            ActiveSlotCount += 1;
                        if (Slot23 > 0)
                            ActiveSlotCount += 1;
                        if (Slot24 > 0)
                            ActiveSlotCount += 1;

                        ActiveSlotCount = ActiveSlotCount + TotalZeroProductivity;

                        int TotalBreakEvenQtyThis = BreakEvenQty * ActiveSlotCount;
                        // Update by RSB on dated 22 september 2017 for color change when BE Eff or BE Pcs are <=0
                        //if (BreakEvenQty > 0)
                        //{
                        //    if (StchAvgPcs >= BreakEvenQty)
                        //        lblTodayPassStitch.Style.Add("color", "green");
                        //    else
                        //        lblTodayPassStitch.Style.Add("color", "#FF0000");
                        //}
                        //else
                        //{
                        //    lblTodayPassStitch.Style.Add("color", "Black");
                        //}
                        // updated By Prabhaker
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

                        // end of Update by RSB on dated 22 september 2017 for color change when BE Eff or BE Pcs are <=0

                        if (TodayDHU > 5)
                            lblTodayAltPcs.Style.Add("color", "#FF0000");

                        else if (TodayDHU <= 5)
                            lblTodayAltPcs.Style.Add("color", "green");

                    }
                    //End Of Code updated By Prabhaker

                    //lblSlot1Pass.Text = lblSlot3Pass.Text == "0" ? "" : lblSlot1Pass.Text;
                    //lblSlot2Pass.Text = lblSlot4Pass.Text == "0" ? "" : lblSlot2Pass.Text;
                    //lblSlot3Pass.Text = lblSlot3Pass.Text == "0" ? "" : lblSlot3Pass.Text;
                    //lblSlot4Pass.Text = lblSlot4Pass.Text == "0" ? "" : lblSlot4Pass.Text;
                    //lblSlot5Pass.Text = lblSlot5Pass.Text == "0" ? "" : lblSlot5Pass.Text;
                    //lblSlot6Pass.Text = lblSlot6Pass.Text == "0" ? "" : lblSlot6Pass.Text;
                    //lblSlot7Pass.Text = lblSlot7Pass.Text == "0" ? "" : lblSlot7Pass.Text;
                    //lblSlot8Pass.Text = lblSlot8Pass.Text == "0" ? "" : lblSlot8Pass.Text;
                    //lblSlot9Pass.Text = lblSlot9Pass.Text == "0" ? "" : lblSlot9Pass.Text;
                    //lblSlot10Pass.Text = lblSlot10Pass.Text == "0" ? "" : lblSlot10Pass.Text;
                    //lblSlot11Pass.Text = lblSlot11Pass.Text == "0" ? "" : lblSlot11Pass.Text;
                    //lblSlot12Pass.Text = lblSlot12Pass.Text == "0" ? "" : lblSlot12Pass.Text;
                    //lblSlot13Pass.Text = lblSlot13Pass.Text == "0" ? "" : lblSlot13Pass.Text;
                    //lblSlot14Pass.Text = lblSlot14Pass.Text == "0" ? "" : lblSlot14Pass.Text;
                    //lblSlot15Pass.Text = lblSlot15Pass.Text == "0" ? "" : lblSlot15Pass.Text;
                    //lblSlot16Pass.Text = lblSlot16Pass.Text == "0" ? "" : lblSlot16Pass.Text;
                    //lblSlot17Pass.Text = lblSlot17Pass.Text == "0" ? "" : lblSlot17Pass.Text;
                    //lblSlot18Pass.Text = lblSlot18Pass.Text == "0" ? "" : lblSlot18Pass.Text;
                    //lblSlot19Pass.Text = lblSlot19Pass.Text == "0" ? "" : lblSlot19Pass.Text;
                    //lblSlot20Pass.Text = lblSlot20Pass.Text == "0" ? "" : lblSlot20Pass.Text;
                    //lblSlot21Pass.Text = lblSlot21Pass.Text == "0" ? "" : lblSlot21Pass.Text;
                    //lblSlot22Pass.Text = lblSlot22Pass.Text == "0" ? "" : lblSlot22Pass.Text;
                    //lblSlot23Pass.Text = lblSlot23Pass.Text == "0" ? "" : lblSlot23Pass.Text;
                    //lblSlot24Pass.Text = lblSlot24Pass.Text == "0" ? "" : lblSlot24Pass.Text;

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
                    if (lblSlot17Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot17Pass.Text) > 999)
                        {
                            lblSlot17Pass.Text = Math.Round(Convert.ToDouble(lblSlot17Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot17Pass.Text = lblSlot17Pass.Text == "0" ? "" : lblSlot17Pass.Text;
                        }
                    }
                    if (lblSlot18Pass.Text != "")
                    {

                        if (Convert.ToDouble(lblSlot18Pass.Text) > 999)
                        {
                            lblSlot18Pass.Text = Math.Round(Convert.ToDouble(lblSlot18Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot18Pass.Text = lblSlot18Pass.Text == "0" ? "" : lblSlot18Pass.Text;
                        }
                    }
                    if (lblSlot19Pass.Text != "")
                    {

                        if (Convert.ToDouble(lblSlot19Pass.Text) > 999)
                        {
                            lblSlot19Pass.Text = Math.Round(Convert.ToDouble(lblSlot19Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot19Pass.Text = lblSlot19Pass.Text == "0" ? "" : lblSlot19Pass.Text;
                        }
                    }
                    if (lblSlot20Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot20Pass.Text) > 999)
                        {
                            lblSlot20Pass.Text = Math.Round(Convert.ToDouble(lblSlot20Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot20Pass.Text = lblSlot20Pass.Text == "0" ? "" : lblSlot20Pass.Text;
                        }
                    }
                    if (lblSlot21Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot21Pass.Text) > 999)
                        {
                            lblSlot21Pass.Text = Math.Round(Convert.ToDouble(lblSlot21Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot21Pass.Text = lblSlot21Pass.Text == "0" ? "" : lblSlot21Pass.Text;
                        }
                    }
                    if (lblSlot22Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot22Pass.Text) > 999)
                        {
                            lblSlot22Pass.Text = Math.Round(Convert.ToDouble(lblSlot22Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot22Pass.Text = lblSlot22Pass.Text == "0" ? "" : lblSlot22Pass.Text;
                        }
                    }
                    if (lblSlot23Pass.Text != "")
                    {
                        if (Convert.ToDouble(lblSlot23Pass.Text) > 999)
                        {
                            lblSlot23Pass.Text = Math.Round(Convert.ToDouble(lblSlot23Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot23Pass.Text = lblSlot23Pass.Text == "0" ? "" : lblSlot23Pass.Text;
                        }
                    }
                    if (lblSlot24Pass.Text != "")
                    {

                        if (Convert.ToDouble(lblSlot24Pass.Text) > 999)
                        {
                            lblSlot24Pass.Text = Math.Round(Convert.ToDouble(lblSlot24Pass.Text) / 1000, 1).ToString() + "k";
                        }
                        else
                        {
                            lblSlot24Pass.Text = lblSlot24Pass.Text == "0" ? "" : lblSlot24Pass.Text;
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
                    lblSlot17DHU.Text = lblSlot17DHU.Text == "0" ? "" : lblSlot17DHU.Text + " %";
                    lblSlot18DHU.Text = lblSlot18DHU.Text == "0" ? "" : lblSlot18DHU.Text + " %";
                    lblSlot19DHU.Text = lblSlot19DHU.Text == "0" ? "" : lblSlot19DHU.Text + " %";
                    lblSlot20DHU.Text = lblSlot20DHU.Text == "0" ? "" : lblSlot20DHU.Text + " %";
                    lblSlot21DHU.Text = lblSlot21DHU.Text == "0" ? "" : lblSlot21DHU.Text + " %";
                    lblSlot22DHU.Text = lblSlot22DHU.Text == "0" ? "" : lblSlot22DHU.Text + " %";
                    lblSlot23DHU.Text = lblSlot23DHU.Text == "0" ? "" : lblSlot23DHU.Text + " %";
                    lblSlot24DHU.Text = lblSlot24DHU.Text == "0" ? "" : lblSlot24DHU.Text + " %";

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

                    int FinishDoubleOB = DataBinder.Eval(e.Row.DataItem, "FinishDoubleOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FinishDoubleOB"));
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
                            lblTodayPassFinish.Text =  TodayPassFinishNew.ToString() + "k";
                        }
                    }
                    else
                    {
                        lblTodayPassFinish.Text = TodayPassFinish == 0 ? "" : TodayPassFinish.ToString("#,##0");
                    }
                    if (FinishQty > 999)
                    {
                        double FinishQtyNew = Math.Round(Convert.ToDouble(FinishQty) / 1000,1);
                        if (FinishQtyNew > 99.9)
                        {
                            lblFinishQty.Text = "("+ Math.Round(FinishQtyNew, 0).ToString() + "k)";
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
                       // lblFinAgreedOB.Text = PeakOB_Finish == 0 ? "" : "(" + PeakOB_Finish.ToString() + ")";
                       // lblFinAgreedOB.Style.Add("color", "blue");

                        if (FinishActualOB <= PeakOB_Finish)
                            lblFinActOB.Style.Add("color", "green");
                        else
                            lblFinActOB.Style.Add("color", "red");
                    }
                    else
                    {
                       // lblFinAgreedOB.Style.Add("color", "black");
                        //if (FinishDoubleOB == 1)
                        //    lblFinAgreedOB.Text = FinishOB == 0 ? "" : "(" + FinishOB.ToString() + " D)";
                        //else
                        //    lblFinAgreedOB.Text = FinishOB == 0 ? "" : "(" + FinishOB.ToString() + ")";

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
                            double PeakCapcty_FinishNew = Math.Round(Convert.ToDouble(PeakCapcty_Finish) / 1000,1);
                            if (PeakCapcty_FinishNew > 99.9)
                            {
                                lblFinPkCpty.Text = Math.Round(PeakCapcty_FinishNew,0).ToString() + "k Pcs";
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


                    // Update by RSB on dated 22 september 2017 for color change when BE Eff or BE Pcs are <=0
                    //if (BreakEvenQty > 0)
                    //{
                    //    if (FinishAvgPcs >= BreakEvenQty)
                    //    {
                    //        lblTodayPassFinish.Style.Add("color", "green");
                    //    }
                    //    else
                    //    {
                    //        lblTodayPassFinish.Style.Add("color", "#FF0000");
                    //    }
                    //}
                    //else
                    //{
                    //    lblTodayPassFinish.Style.Add("color", "Black");
                    //}

                    //Add By Prabhaker code  07-Nov-2017
                    Label lblFinishCost = (Label)e.Row.FindControl("lblFinishCost");

                    HtmlControl tdFinishCost = (HtmlControl)e.Row.FindControl("tdFinishCost");
                    if (TotalTodayFinishObatLineCluster > 0 && FinishAvgPcs > 0)
                    {
                        lblFinishCost.Text = "&#8377;" + Math.Round(((Convert.ToDouble(TotalTodayFinishObatLineCluster) * finishperobcost) / Convert.ToDouble(TodayPassFinish)), 0).ToString();
                        if (Math.Round(((Convert.ToDouble(TotalTodayFinishObatLineCluster) * finishperobcost) / Convert.ToDouble(TodayPassFinish)), 0) <= 10)
                        {
                           // tdFinishCost.Style.Add("background", "green");
                            lblFinishCost.Style.Add("color", "green");
                        }
                        //else if (Math.Round(((Convert.ToDouble(TotalTodayFinishObatLineCluster) * finishperobcost) / Convert.ToDouble(TodayPassFinish)), 0) < 13 && Math.Round(((Convert.ToDouble(TotalTodayFinishObatLineCluster) * finishperobcost) / Convert.ToDouble(TodayPassFinish)), 0) > 9)
                        //{
                        //   // tdFinishCost.Style.Add("background", "Orange");
                        //    lblFinishCost.Style.Add("color", "Orange");
                        //}
                        else
                        {
                           // tdFinishCost.Style.Add("background", "#FF0000");
                            lblFinishCost.Style.Add("color", "#FF0000");
                        }


                        if (Math.Round((Convert.ToDouble(TotalTodayFinishObatLineCluster) * finishperobcost) / Convert.ToDouble(TodayPassFinish), 0) <= 12)
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
                    //End of Prabhaker

                    // end of Update by RSB on dated 22 september 2017 for color change when BE Eff or BE Pcs are <=0



                    //Comment Code For Finish Value On 18-jan 17


                    //if (finishperobcost > 0 && FinishActualOB > 0)
                    //{
                    //    double finishValue = Math.Round(((Convert.ToDouble(finishperobcost) * FinishActualOB) / 10), 0);
                    //    if (finishValue > 999)
                    //    {
                    //        finishValue = Math.Round(finishValue / 1000, 1);
                    //        if (finishValue > 99.9)
                    //        {
                    //            lblFinQtyVal.Text = Math.Round(finishValue, 0).ToString() + "k";
                    //        }
                    //        else
                    //        {
                    //            lblFinQtyVal.Text = Math.Round(finishValue, 0).ToString() + "k";
                    //        }
                    //    }
                    //    else
                    //    {
                    //        lblFinQtyVal.Text = Math.Round(((Convert.ToDouble(finishperobcost) * FinishActualOB) / 10), 0).ToString();
                    //    }
                    //}

                    //End of Comment Code For Finish Value On 18-jan 17

                   // lblWIPCut.Text = WIPCutting <= 0 ? "" : WIPCutting + " D";
                   // lblWIPStiched.Text = WIPStiched <= 0 ? "" : WIPStiched + " D";
                   // lblWIPFinished.Text = WIPFinished <= 0 ? "" : WIPFinished + " D";
                    lblwipCutPcs.Text = WIPCutQty_InProgress <= 0 ? "" : WIPCutQty_InProgress + "k";
                    lblWIPStichedPcs.Text = WIPStitchQty_InProgress <= 0 ? "" : WIPStitchQty_InProgress + "k";
                    lblWIPFinishedPcs.Text = WIPFinishQty_InProgress <= 0 ? "" : WIPFinishQty_InProgress + "k";

                    //if (WIPCutting >= WIPStiched)
                    //{
                    //    lblWIPCut.ForeColor = System.Drawing.Color.Red;
                    //    lblWIPCut.Font.Bold = true;
                    //}
                    //else
                    //{
                    //    lblWIPCut.ForeColor = System.Drawing.Color.Green;
                    //}

                    //if ((WIPStiched >= 0 && WIPStiched <= 2))
                    //{
                    //    lblWIPStiched.ForeColor = System.Drawing.Color.Red;
                    //    lblWIPStiched.Font.Bold = true;
                    //}
                    //else
                    //{
                    //    lblWIPStiched.ForeColor = System.Drawing.Color.Green;
                    //}

                    //if (WIPFinished == 0)
                    //{
                    //    lblWIPFinished.ForeColor = System.Drawing.Color.Green;
                    //}
                    //else
                    //{
                    //    lblWIPFinished.ForeColor = System.Drawing.Color.Red;
                    //    lblWIPFinished.Font.Bold = true;
                    //}
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
                      // updated rsb
                    if (CutQty > 999)
                    {
                        double CutQtyNew = Math.Round(Convert.ToDouble(CutQty) / 1000, 1);
                        if (CutQtyNew > 99.9)
                        {
                            lblCutQty.Text = Math.Round(CutQtyNew, 0).ToString() + "k";
                        }
                        else
                        {
                            lblCutQty.Text = CutQtyNew.ToString() + "k";
                        }
                    }
                    else
                    {
                        lblCutQty.Text = CutQty == 0 ? "" : CutQty.ToString("#,##0");  //updated rsb
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

                    if (FinishAvgPcs > 999)
                    {
                        Double FinishAvgPcsNew = Math.Round(Convert.ToDouble(FinishAvgPcs) / 1000,1);
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
                    // updated By Prabhaker
                    if (PercentPerformance <= 85)
                        lblPercentPerformance.Style.Add("color", "Red");
                    else
                        lblPercentPerformance.Style.Add("color", "green");
                    // End Code updated By Prabhaker
                    double OrderQty_With5Percent = Math.Round(Convert.ToDouble(OrderQty) + (Convert.ToDouble(OrderQty) * 5) / 100, 0);
                    if (Convert.ToDouble(CutQty) > OrderQty_With5Percent)
                        lblCutQty.Style.Add("color", "red");
                    else
                        lblCutQty.Style.Add("color", "black");

                    if (Convert.ToDouble(FabricQty) > OrderQty_With5Percent)
                        lblFabQty.Style.Add("color", "red");
                    else
                        lblFabQty.Style.Add("color", "black");


                    if (hdnEmptyMsg.Value != DBNull.Value.ToString())
                    {
                        HtmlTable tblEmptyMsg = (HtmlTable)e.Row.FindControl("tblEmptyMsg");
                        tblEmptyMsg.Visible = true;
                        //HtmlTable tblLinePlan = (HtmlTable)e.Row.FindControl("tblLinePlan");
                        //tblLinePlan.Visible = false;

                        e.Row.Cells[1].ColumnSpan = 34;
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
                        e.Row.Cells[20].Visible = false;
                        e.Row.Cells[21].Visible = false;
                        e.Row.Cells[22].Visible = false;
                        e.Row.Cells[23].Visible = false;
                        e.Row.Cells[24].Visible = false;
                        e.Row.Cells[25].Visible = false;
                        e.Row.Cells[26].Visible = false;
                        e.Row.Cells[27].Visible = false;
                        e.Row.Cells[28].Visible = false;
                        e.Row.Cells[29].Visible = false;
                        e.Row.Cells[30].Visible = false;
                        e.Row.Cells[31].Visible = false;
                        e.Row.Cells[32].Visible = false;
                        e.Row.Cells[33].Visible = false;
                        e.Row.Cells[34].Visible = false;
                        e.Row.Cells[35].Visible = false;
                    }
                    //if ((lblUnit.Text == "") && (UnitId != 0))
                    if (UnitId == -1)
                    {                      
                        e.Row.Attributes.Add("class", "yellowFactory");              
                        //e.Row.Cells[28].Visible = false;
                        //e.Row.Cells[29].Visible = false;
                        //e.Row.Cells[30].Visible = false;
                        //e.Row.Cells[31].Visible = false;
                        e.Row.Cells[32].Visible = false;
                        e.Row.Cells[33].Visible = false;
                        e.Row.Cells[34].Visible = false;
                        e.Row.Cells[35].Visible = false;
                        lblUnit.Visible = true;
                        lblUnit.Text = "";

                        Label lblUnitTotal = (Label)e.Row.FindControl("lblUnitTotal");
                        lblUnitTotal.Text = "Factory Total";
                       // lblTodayEff_Stitch.Font.Bold = true;
                        lblTodayEff_Stitch.Style.Add("font-size", "12px");
                     
                        imgStyle.Visible = false;
                        lblLineNumber.Visible = false;
                        lblProdDay.Visible = false;
                        lblCOT.Visible = false;
                        

                        Factory_BreakEvenQty = DataBinder.Eval(e.Row.DataItem, "BreakEvenQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BreakEvenQty"));
                        Factory_BreakEvenEff = DataBinder.Eval(e.Row.DataItem, "BreakEvenEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BreakEvenEff"));
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
                        Total_Slot17 += DataBinder.Eval(e.Row.DataItem, "Slot17Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17Pass"));
                        Total_Slot18 += DataBinder.Eval(e.Row.DataItem, "Slot18Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18Pass"));
                        Total_Slot19 += DataBinder.Eval(e.Row.DataItem, "Slot19Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19Pass"));
                        Total_Slot20 += DataBinder.Eval(e.Row.DataItem, "Slot20Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20Pass"));
                        Total_Slot21 += DataBinder.Eval(e.Row.DataItem, "Slot21Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21Pass"));
                        Total_Slot22 += DataBinder.Eval(e.Row.DataItem, "Slot22Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22Pass"));
                        Total_Slot23 += DataBinder.Eval(e.Row.DataItem, "Slot23Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23Pass"));
                        Total_Slot24 += DataBinder.Eval(e.Row.DataItem, "Slot24Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24Pass"));


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
                        Total_DHU17 += DataBinder.Eval(e.Row.DataItem, "Slot17DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17DHU"));
                        Total_DHU18 += DataBinder.Eval(e.Row.DataItem, "Slot18DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18DHU"));
                        Total_DHU19 += DataBinder.Eval(e.Row.DataItem, "Slot19DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19DHU"));
                        Total_DHU20 += DataBinder.Eval(e.Row.DataItem, "Slot20DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20DHU"));
                        Total_DHU21 += DataBinder.Eval(e.Row.DataItem, "Slot21DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21DHU"));
                        Total_DHU22 += DataBinder.Eval(e.Row.DataItem, "Slot22DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22DHU"));
                        Total_DHU23 += DataBinder.Eval(e.Row.DataItem, "Slot23DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23DHU"));
                        Total_DHU24 += DataBinder.Eval(e.Row.DataItem, "Slot24DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24DHU"));

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
                        Slot17TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot17TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17TotalOB"));
                        Slot18TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot18TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18TotalOB"));
                        Slot19TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot19TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19TotalOB"));
                        Slot20TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot20TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20TotalOB"));
                        Slot21TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot21TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21TotalOB"));
                        Slot22TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot22TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22TotalOB"));
                        Slot23TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot23TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23TotalOB"));
                        Slot24TotalOB += DataBinder.Eval(e.Row.DataItem, "Slot24TotalOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24TotalOB"));


                        CostingCMT_Total += DataBinder.Eval(e.Row.DataItem, "CostingCMT") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CostingCMT"));

                        StitchActualOB_Total += DataBinder.Eval(e.Row.DataItem, "StitchActualOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StitchActualOB"));
                        StitchSAM_OB_Total += DataBinder.Eval(e.Row.DataItem, "StitchSAM_OB") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "StitchSAM_OB"));

                        FinishSAM_Total += DataBinder.Eval(e.Row.DataItem, "FinishSAM") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FinishSAM"));
                        FinishActualOB_Total += DataBinder.Eval(e.Row.DataItem, "FinishActualOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FinishActualOB"));
                        FinishOB_Total += DataBinder.Eval(e.Row.DataItem, "FinishOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FinishOB"));

                        PeakCapecity_Total += DataBinder.Eval(e.Row.DataItem, "PeakCapecity") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakCapecity"));
                        PeakOB_Total += DataBinder.Eval(e.Row.DataItem, "PeakOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakOB"));
                        PeakEff_Total += DataBinder.Eval(e.Row.DataItem, "PeakEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakEff"));
                        COTValue_Total += DataBinder.Eval(e.Row.DataItem, "COTValue") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COTValue"));


                        OrderQty_Total += DataBinder.Eval(e.Row.DataItem, "OrderQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "OrderQty"));
                        StitchQty_Total += DataBinder.Eval(e.Row.DataItem, "TotalStitchedQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalStitchedQty"));
                        FinishQty_Total += DataBinder.Eval(e.Row.DataItem, "TotalFinishQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalFinishQty"));

                        TodayPassPcsFinish_Total += DataBinder.Eval(e.Row.DataItem, "TodayPassPcsFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayPassPcsFinish"));
                        TodayPassPcsStitch_Total += DataBinder.Eval(e.Row.DataItem, "TodayPassPcsStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayPassPcsStitch"));
                        TodayAltPcs_Total += DataBinder.Eval(e.Row.DataItem, "TodayAltPcs") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayAltPcs"));
                        DHU_Today_Total += DataBinder.Eval(e.Row.DataItem, "DHU_Today") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DHU_Today"));
                        TodayAchieved_Total += DataBinder.Eval(e.Row.DataItem, "TodayAchievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayAchievement"));

                        TargetEff_Total += DataBinder.Eval(e.Row.DataItem, "TargetEfficiency") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetEfficiency"));
                        TargetQty_Total += DataBinder.Eval(e.Row.DataItem, "TargetQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetQty"));

                        TodayEfficiency_Stitch_Total += DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Stitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Stitch"));
                        StyleEfficiency_Stitch_Total += DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Stitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Stitch"));


                        FabricQty_Total += DataBinder.Eval(e.Row.DataItem, "FabricQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FabricQty"));
                        CutQty_Total += DataBinder.Eval(e.Row.DataItem, "CutQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CutQty"));
                        //FinishAvgPcs_Total += DataBinder.Eval(e.Row.DataItem, "TodayAvgFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayAvgFinish"));
                        PercentPerformance_Total += DataBinder.Eval(e.Row.DataItem, "PercentPerformance") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PercentPerformance"));

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
                        if (FactoryTotalTodayFinishObatLineCluster > 0 && FinishAvgPcs > 0)
                        {
                            lblFinishCost.Text = "&#8377;" + Math.Round(((Convert.ToDouble(FactoryTotalTodayFinishObatLineCluster) * finishperobcost) / Convert.ToDouble(TodayPassFinish)), 0).ToString();

                            if (Math.Round(((Convert.ToDouble(FactoryTotalTodayFinishObatLineCluster) * finishperobcost) / Convert.ToDouble(TodayPassFinish)), 0) <= 10)
                            {                              
                                lblFinishCost.Style.Add("color", "green");
                            }                           
                            else
                            {                               
                                lblFinishCost.Style.Add("color", "#FF0000");
                            }

                            if (Math.Round((Convert.ToDouble(FactoryTotalTodayFinishObatLineCluster) * finishperobcost) / Convert.ToDouble(TodayPassFinish), 0) <= 12)
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
                        int Slot17_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot17_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17_Achievement"));
                        int Slot18_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot18_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18_Achievement"));
                        int Slot19_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot19_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19_Achievement"));
                        int Slot20_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot20_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20_Achievement"));
                        int Slot21_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot21_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21_Achievement"));
                        int Slot22_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot22_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22_Achievement"));
                        int Slot23_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot23_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23_Achievement"));
                        int Slot24_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot24_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24_Achievement"));

                        if (Slot1_Achievement > 0)
                        {
                            if (Slot1_Achievement >= 85)
                                lblSlot1Pass.Style.Add("color", "green");
                            else
                                lblSlot1Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot1Pass.Style.Add("color", "BLACK");

                        if (Slot2_Achievement > 0)
                        {
                            if (Slot2_Achievement >= 85)
                                lblSlot2Pass.Style.Add("color", "green");
                            else
                                lblSlot2Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot2Pass.Style.Add("color", "BLACK");

                        if (Slot3_Achievement > 0)
                        {
                            if (Slot3_Achievement >= 85)
                                lblSlot3Pass.Style.Add("color", "green");
                            else
                                lblSlot3Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot3Pass.Style.Add("color", "BLACK");

                        if (Slot4_Achievement > 0)
                        {
                            if (Slot4_Achievement >= 85)
                                lblSlot4Pass.Style.Add("color", "green");
                            else
                                lblSlot4Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot4Pass.Style.Add("color", "BLACK");

                        if (Slot5_Achievement > 0)
                        {
                            if (Slot5_Achievement >= 85)
                                lblSlot5Pass.Style.Add("color", "green");
                            else
                                lblSlot5Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot5Pass.Style.Add("color", "BLACK");

                        if (Slot6_Achievement > 0)
                        {
                            if (Slot6_Achievement >= 85)
                                lblSlot6Pass.Style.Add("color", "green");
                            else
                                lblSlot6Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot6Pass.Style.Add("color", "BLACK");

                        if (Slot7_Achievement > 0)
                        {
                            if (Slot7_Achievement >= 85)
                                lblSlot7Pass.Style.Add("color", "green");
                            else
                                lblSlot7Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot7Pass.Style.Add("color", "BLACK");

                        if (Slot8_Achievement > 0)
                        {
                            if (Slot8_Achievement >= 85)
                                lblSlot8Pass.Style.Add("color", "green");
                            else
                                lblSlot8Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot8Pass.Style.Add("color", "BLACK");

                        if (Slot9_Achievement > 0)
                        {
                            if (Slot9_Achievement >= 85)
                                lblSlot9Pass.Style.Add("color", "green");
                            else
                                lblSlot9Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot9Pass.Style.Add("color", "BLACK");

                        if (Slot10_Achievement > 0)
                        {
                            if (Slot10_Achievement >= 85)
                                lblSlot10Pass.Style.Add("color", "green");
                            else
                                lblSlot10Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot10Pass.Style.Add("color", "BLACK");

                        if (Slot11_Achievement > 0)
                        {
                            if (Slot11_Achievement >= 85)
                                lblSlot11Pass.Style.Add("color", "green");
                            else
                                lblSlot11Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot11Pass.Style.Add("color", "BLACK");

                        if (Slot12_Achievement > 0)
                        {
                            if (Slot12_Achievement >= 85)
                                lblSlot12Pass.Style.Add("color", "green");
                            else
                                lblSlot12Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot12Pass.Style.Add("color", "BLACK");

                        if (Slot13_Achievement > 0)
                        {
                            if (Slot13_Achievement >= 85)
                                lblSlot13Pass.Style.Add("color", "green");
                            else
                                lblSlot13Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot13Pass.Style.Add("color", "BLACK");

                        if (Slot14_Achievement > 0)
                        {
                            if (Slot14_Achievement >= 85)
                                lblSlot14Pass.Style.Add("color", "green");
                            else
                                lblSlot14Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot14Pass.Style.Add("color", "BLACK");

                        if (Slot15_Achievement > 0)
                        {
                            if (Slot15_Achievement >= 85)
                                lblSlot15Pass.Style.Add("color", "green");
                            else
                                lblSlot15Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot15Pass.Style.Add("color", "BLACK");

                        if (Slot16_Achievement > 0)
                        {
                            if (Slot16_Achievement >= 85)
                                lblSlot16Pass.Style.Add("color", "green");
                            else
                                lblSlot16Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot16Pass.Style.Add("color", "BLACK");

                        if (Slot17_Achievement > 0)
                        {
                            if (Slot17_Achievement >= 85)
                                lblSlot17Pass.Style.Add("color", "green");
                            else
                                lblSlot17Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot17Pass.Style.Add("color", "BLACK");

                        if (Slot18_Achievement > 0)
                        {
                            if (Slot18_Achievement >= 85)
                                lblSlot18Pass.Style.Add("color", "green");
                            else
                                lblSlot18Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot18Pass.Style.Add("color", "BLACK");

                        if (Slot18_Achievement > 0)
                        {
                            if (Slot18_Achievement >= 85)
                                lblSlot18Pass.Style.Add("color", "green");
                            else
                                lblSlot18Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot18Pass.Style.Add("color", "BLACK");

                        if (Slot19_Achievement > 0)
                        {
                            if (Slot19_Achievement >= 85)
                                lblSlot19Pass.Style.Add("color", "green");
                            else
                                lblSlot19Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot19Pass.Style.Add("color", "BLACK");

                        if (Slot20_Achievement > 0)
                        {
                            if (Slot20_Achievement >= 85)
                                lblSlot20Pass.Style.Add("color", "green");
                            else
                                lblSlot20Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot20Pass.Style.Add("color", "BLACK");

                        if (Slot21_Achievement > 0)
                        {
                            if (Slot21_Achievement >= 85)
                                lblSlot21Pass.Style.Add("color", "green");
                            else
                                lblSlot21Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot21Pass.Style.Add("color", "BLACK");

                        if (Slot22_Achievement > 0)
                        {
                            if (Slot22_Achievement >= 85)
                                lblSlot22Pass.Style.Add("color", "green");
                            else
                                lblSlot22Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot22Pass.Style.Add("color", "BLACK");

                        if (Slot23_Achievement > 0)
                        {
                            if (Slot23_Achievement >= 85)
                                lblSlot23Pass.Style.Add("color", "green");
                            else
                                lblSlot23Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot23Pass.Style.Add("color", "BLACK");

                        if (Slot24_Achievement > 0)
                        {
                            if (Slot24_Achievement >= 85)
                                lblSlot24Pass.Style.Add("color", "green");
                            else
                                lblSlot24Pass.Style.Add("color", "#FF0000");
                        }
                        else
                            lblSlot24Pass.Style.Add("color", "BLACK");


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
                    
                    if ((UnitId != -1) && (UnitId != 0))
                    {
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
                        BIPLPriceSlot17 += DataBinder.Eval(e.Row.DataItem, "Slot17_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot17_BIPLPrice"));
                        BIPLPriceSlot18 += DataBinder.Eval(e.Row.DataItem, "Slot18_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot18_BIPLPrice"));
                        BIPLPriceSlot19 += DataBinder.Eval(e.Row.DataItem, "Slot19_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot19_BIPLPrice"));
                        BIPLPriceSlot20 += DataBinder.Eval(e.Row.DataItem, "Slot20_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot20_BIPLPrice"));
                        BIPLPriceSlot21 += DataBinder.Eval(e.Row.DataItem, "Slot21_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot21_BIPLPrice"));
                        BIPLPriceSlot22 += DataBinder.Eval(e.Row.DataItem, "Slot22_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot22_BIPLPrice"));
                        BIPLPriceSlot23 += DataBinder.Eval(e.Row.DataItem, "Slot23_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot23_BIPLPrice"));
                        BIPLPriceSlot24 += DataBinder.Eval(e.Row.DataItem, "Slot24_BIPLPrice") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Slot24_BIPLPrice"));

                        string StyleCode = DataBinder.Eval(e.Row.DataItem, "StyleCode").ToString();

                        double StitchSAM_row = DataBinder.Eval(e.Row.DataItem, "StitchSAM") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "StitchSAM"));
                        int TargetQty_row = DataBinder.Eval(e.Row.DataItem, "TargetQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetQty"));
                        int StitchActualOB_row = DataBinder.Eval(e.Row.DataItem, "StitchActualOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StitchActualOB"));
                        
                        if (StitchActualOB_row > 0)
                            StitchSAM_TargetQty_Total = StitchSAM_TargetQty_Total + (StitchSAM_row * TargetQty_row);

                        int OrderId = -1;
                        //int LinePlanningId = -1;
                        int ProductionUnit = -1;
                        HtmlTable tblEmptyMsg = (HtmlTable)e.Row.FindControl("tblEmptyMsg");
                        tblEmptyMsg.Visible = false;
                       // HtmlTable tblLinePlan = (HtmlTable)e.Row.FindControl("tblLinePlan");
                        //tblLinePlan.Visible = true;

                        HiddenField hdnStyleId = (HiddenField)e.Row.FindControl("hdnStyleId");
                        HiddenField hdnLineNo = (HiddenField)e.Row.FindControl("hdnLineNo");

                        HiddenField hdnUnitId = (HiddenField)e.Row.FindControl("hdnUnitId");
                        HtmlTableCell tdUpcomingStyle = (HtmlTableCell)e.Row.FindControl("tdUpcomingStyle");
                        HtmlTable tableUpComingStyle=(HtmlTable)e.Row.FindControl("tableUpComingStyle");

                        if (hdnStyleId.Value != DBNull.Value.ToString())
                            StyleId = Convert.ToInt32(hdnStyleId.Value);
                        if (hdnLineNo.Value != DBNull.Value.ToString())
                            LineNo = Convert.ToInt32(hdnLineNo.Value);
                        if (hdnOrderId.Value != DBNull.Value.ToString())
                            OrderId = Convert.ToInt32(hdnOrderId.Value);
                        if (hdnUnitId.Value != DBNull.Value.ToString())
                            ProductionUnit = Convert.ToInt32(hdnUnitId.Value);
                        if (IsCluster == 0)
                        {
                            CuttingPerPcsCost = DataBinder.Eval(e.Row.DataItem, "CuttingPerPcsCost") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "CuttingPerPcsCost"));
                            StichingPerOBCost = DataBinder.Eval(e.Row.DataItem, "StichingPerOBCost") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "StichingPerOBCost"));
                            FinishingPerOBCost = DataBinder.Eval(e.Row.DataItem, "FinishingPerOBCost") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FinishingPerOBCost"));
                            FactoryOverHeadPerPcs = DataBinder.Eval(e.Row.DataItem, "FactoryOverHeadPerPcs") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FactoryOverHeadPerPcs"));
                        }
                        SlotId = Convert.ToInt32(hdnSlotId.Value);
                        //Add By Prabhaker on 09 - may -18// 
                        DataSet dsGetBottleNeck;
                        dsGetBottleNeck = objProductionController.GetBottleNeck_Operation_OrderID(OrderId, ProductionUnit, LineNo, SlotId, ClusterId);
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
                         if (PassFail >0)
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
                        DataSet ds;
                        ds = objProductionController.GetHourlyStitchingReport(lblUnit.Text, StyleId, OrderId, LineNo, ProductionUnit, IsCluster, ClusterId, "LinePlanning");
                        DataList dlstLineDesignation = e.Row.FindControl("dlstLineDesignation") as DataList;
                        dlstLineDesignation.DataSource = ds.Tables[0];
                        dlstLineDesignation.DataBind();

                        Label lblUpcommingStyle = e.Row.FindControl("lblUpcommingStyle") as Label;

                        //Add By Prabhaker 09-Apr-18
                        DataSet dsUpcomingStyle= new DataSet();

                        dsUpcomingStyle = objProductionController.GetUpcomingStyle(StyleCode, UnitId, LineNo);
                        Label lblUpcomingStyleCode = e.Row.FindControl("lblUpcomingStyleCode") as Label;
                        Label lblUpcomingPndgStitchQty = e.Row.FindControl("lblUpcomingPndgStitchQty") as Label;
                        Label lblUpcomingEstEndDate = e.Row.FindControl("lblUpcomingEstEndDate") as Label;
                        Label lblUpcomingStitchDays = e.Row.FindControl("lblUpcomingStitchDays") as Label;
                        Label lblUpcomingCutWip = e.Row.FindControl("lblUpcomingCutWip") as Label;
                        Label lblUpcomingPndgsAM = e.Row.FindControl("lblUpcomingPndgsAM") as Label;

                        if(dsUpcomingStyle.Tables[0].Rows.Count > 0)
                        {
                            string UpcomingStyle = dsUpcomingStyle.Tables[0].Rows[0]["StyleCode"].ToString();
                            HiddenField hdnimgStyleIdImgPath = (HiddenField)e.Row.FindControl("hdnimgStyleIdImgPath");
                            HtmlImage imgStyleIdImgPath = (HtmlImage)e.Row.FindControl("imgStyleIdImgPath");
                            if (UpcomingStyle.Trim() != "")
                            {
                               // lblUpcommingStyle.Text = UpcomingStyle;
                              //  lblUpcommingStyle.Style.Add("color", "black");
                                lblUpcomingStyleCode.Text = dsUpcomingStyle.Tables[0].Rows[0]["StyleCode"].ToString();
                                lblUpcomingPndgStitchQty.Text = dsUpcomingStyle.Tables[0].Rows[0]["PndgStitchQty"].ToString();
                                lblUpcomingEstEndDate.Text = dsUpcomingStyle.Tables[0].Rows[0]["EstEndDate"].ToString();
                                lblUpcomingStitchDays.Text = dsUpcomingStyle.Tables[0].Rows[0]["StitchDays"].ToString();
                                lblUpcomingCutWip.Text = dsUpcomingStyle.Tables[0].Rows[0]["CutWip"].ToString();
                                lblUpcomingPndgsAM.Text = Math.Round(Convert.ToDouble(dsUpcomingStyle.Tables[0].Rows[0]["SAM"].ToString()), 1).ToString();

                                lblUpcommingStyle.Visible = false;
                                if (dsUpcomingStyle.Tables.Count > 1)
                                {
                                    hdnimgStyleIdImgPath.Value = dsUpcomingStyle.Tables[1].Rows[0]["imgStyleImgPath"].ToString();
                                    imgStyleIdImgPath.Src = "/uploads/style/thumb-" + hdnimgStyleIdImgPath.Value;
                                }                        
                            }
                        }
                        
                        // End of code Prabhaker 09-Apr-18
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

                        DataSet dsInspection;
                        dsInspection = objProductionController.GetHourlyStitchingReport(lblUnit.Text, StyleId, OrderId, LineNo, ProductionUnit, -1, -1, "Inspection");
                        Repeater dlstInspection = e.Row.FindControl("dlstInspection") as Repeater;
                        dlstInspection.DataSource = dsInspection.Tables[0];
                        dlstInspection.DataBind();

                       
                                                
                        ViewState["IsCluster"] = IsCluster;
                        // updated by rsb and ravik
                        if (IsCluster == 0)
                        {
                            int OB = 0;
                            if (StitchActualOB == 0)
                                OB = PeakOB == 0 ? StitchOB : PeakOB;
                            else
                                OB = StitchActualOB;

                            DataSet dsExFactory;
                            dsExFactory = objProductionController.GetStitch_PendingQty_ByStyleCode(StyleCode, ProductionUnit, LineNo, ProdDay, TargetQty, StyleId);
                            GridView gvPending = e.Row.FindControl("gvPending") as GridView;
                            DataTable dtPending = dsExFactory.Tables[0];
                            ViewState["dtPending"] = dtPending;                           

                            gvPending.DataSource = dtPending;
                            gvPending.DataBind();

                            int ColCount = dtPending.Columns.Count;

                            for (int i = ColCount; i <= 3; i++)
                            {
                                gvPending.Columns[i].Visible = false;
                            }
                        }
                        else
                        {
                            DataSet dsClusterExFactory;
                            dsClusterExFactory = objProductionController.GetCluster_PendingQty_ByStyleCode(StyleCode, ClusterId);
                            GridView gvPending = e.Row.FindControl("gvPending") as GridView;
                            DataTable dtPending = dsClusterExFactory.Tables[0];
                            ViewState["dtPending"] = dtPending;

                            gvPending.DataSource = dtPending;
                            gvPending.DataBind();

                            int ColCount = dtPending.Columns.Count;

                            for (int i = ColCount; i <= 3; i++)
                            {
                                gvPending.Columns[i].Visible = false;
                            }
                        }
                    }

                    if (UnitId == 0)
                    {
                        //e.Row.Cells[0].ColumnSpan = 2;
                       // e.Row.Cells[1].Visible = false;
                        e.Row.Attributes.Add("class", "yellowFactory");

                        //e.Row.Cells[2].ColumnSpan = 2;
                        //e.Row.Cells[3].Visible = false;

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
                        e.Row.Cells[27].ColumnSpan = 7;
                        e.Row.Cells[27].CssClass = "ROWMERGE";
                        e.Row.Cells[28].Visible = false;
                        e.Row.Cells[29].Visible = false;      
                        e.Row.Cells[30].Visible = false;
                        e.Row.Cells[31].Visible = false;
                        e.Row.Cells[32].Visible = false;
                        e.Row.Cells[33].Visible = false;
                        e.Row.Cells[34].Visible = false;
                        e.Row.Cells[35].Visible = false;


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
                        int Slot17Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot17Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17Stitch_Eff"));
                        int Slot18Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot18Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18Stitch_Eff"));
                        int Slot19Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot19Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19Stitch_Eff"));
                        int Slot20Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot20Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20Stitch_Eff"));
                        int Slot21Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot21Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21Stitch_Eff"));
                        int Slot22Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot22Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22Stitch_Eff"));
                        int Slot23Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot23Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23Stitch_Eff"));
                        int Slot24Stitch_Eff = DataBinder.Eval(e.Row.DataItem, "Slot24Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24Stitch_Eff"));

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
                        lblSlot17Pass.Text = Slot17Stitch_Eff == 0 ? "" : "<b>" + Slot17Stitch_Eff.ToString() + "% </b>";
                        lblSlot18Pass.Text = Slot18Stitch_Eff == 0 ? "" : "<b>" + Slot18Stitch_Eff.ToString() + "% </b>";
                        lblSlot19Pass.Text = Slot19Stitch_Eff == 0 ? "" : "<b>" + Slot19Stitch_Eff.ToString() + "% </b>";
                        lblSlot20Pass.Text = Slot20Stitch_Eff == 0 ? "" : "<b>" + Slot20Stitch_Eff.ToString() + "% </b>";
                        lblSlot21Pass.Text = Slot21Stitch_Eff == 0 ? "" : "<b>" + Slot21Stitch_Eff.ToString() + "% </b>";
                        lblSlot22Pass.Text = Slot22Stitch_Eff == 0 ? "" : "<b>" + Slot22Stitch_Eff.ToString() + "% </b>";
                        lblSlot23Pass.Text = Slot23Stitch_Eff == 0 ? "" : "<b>" + Slot23Stitch_Eff.ToString() + "% </b>";
                        lblSlot24Pass.Text = Slot24Stitch_Eff == 0 ? "" : "<b>" + Slot24Stitch_Eff.ToString() + "% </b>";


                        //Total_StitchEff1 += DataBinder.Eval(e.Row.DataItem, "Slot1Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1Stitch_Eff"));
                        //Total_StitchEff2 += DataBinder.Eval(e.Row.DataItem, "Slot2Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2Stitch_Eff"));
                        //Total_StitchEff3 += DataBinder.Eval(e.Row.DataItem, "Slot3Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3Stitch_Eff"));
                        //Total_StitchEff4 += DataBinder.Eval(e.Row.DataItem, "Slot4Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4Stitch_Eff"));
                        //Total_StitchEff5 += DataBinder.Eval(e.Row.DataItem, "Slot5Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5Stitch_Eff"));
                        //Total_StitchEff6 += DataBinder.Eval(e.Row.DataItem, "Slot6Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6Stitch_Eff"));
                        //Total_StitchEff7 += DataBinder.Eval(e.Row.DataItem, "Slot7Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7Stitch_Eff"));
                        //Total_StitchEff8 += DataBinder.Eval(e.Row.DataItem, "Slot8Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8Stitch_Eff"));
                        //Total_StitchEff9 += DataBinder.Eval(e.Row.DataItem, "Slot9Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9Stitch_Eff"));
                        //Total_StitchEff10 += DataBinder.Eval(e.Row.DataItem, "Slot10Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10Stitch_Eff"));
                        //Total_StitchEff11 += DataBinder.Eval(e.Row.DataItem, "Slot11Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11Stitch_Eff"));
                        //Total_StitchEff12 += DataBinder.Eval(e.Row.DataItem, "Slot12Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12Stitch_Eff"));
                        //Total_StitchEff13 += DataBinder.Eval(e.Row.DataItem, "Slot13Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13Stitch_Eff"));
                        //Total_StitchEff14 += DataBinder.Eval(e.Row.DataItem, "Slot14Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14Stitch_Eff"));
                        //Total_StitchEff15 += DataBinder.Eval(e.Row.DataItem, "Slot15Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15Stitch_Eff"));
                        //Total_StitchEff16 += DataBinder.Eval(e.Row.DataItem, "Slot16Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16Stitch_Eff"));
                        //Total_StitchEff17 += DataBinder.Eval(e.Row.DataItem, "Slot17Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17Stitch_Eff"));
                        //Total_StitchEff18 += DataBinder.Eval(e.Row.DataItem, "Slot18Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18Stitch_Eff"));
                        //Total_StitchEff19 += DataBinder.Eval(e.Row.DataItem, "Slot19Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19Stitch_Eff"));
                        //Total_StitchEff20 += DataBinder.Eval(e.Row.DataItem, "Slot20Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20Stitch_Eff"));
                        //Total_StitchEff21 += DataBinder.Eval(e.Row.DataItem, "Slot21Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21Stitch_Eff"));
                        //Total_StitchEff22 += DataBinder.Eval(e.Row.DataItem, "Slot22Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22Stitch_Eff"));
                        //Total_StitchEff23 += DataBinder.Eval(e.Row.DataItem, "Slot23Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23Stitch_Eff"));
                        //Total_StitchEff24 += DataBinder.Eval(e.Row.DataItem, "Slot24Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24Stitch_Eff"));

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
                        int Slot17_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot17_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17_Achievement"));
                        int Slot18_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot18_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18_Achievement"));
                        int Slot19_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot19_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19_Achievement"));
                        int Slot20_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot20_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20_Achievement"));
                        int Slot21_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot21_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21_Achievement"));
                        int Slot22_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot22_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22_Achievement"));
                        int Slot23_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot23_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23_Achievement"));
                        int Slot24_Achievement = DataBinder.Eval(e.Row.DataItem, "Slot24_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24_Achievement"));


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
                        HtmlTableCell td17Dhu = (HtmlTableCell)e.Row.FindControl("td17Dhu");
                        HtmlTableCell td18Dhu = (HtmlTableCell)e.Row.FindControl("td18Dhu");
                        HtmlTableCell td19Dhu = (HtmlTableCell)e.Row.FindControl("td19Dhu");
                        HtmlTableCell td20Dhu = (HtmlTableCell)e.Row.FindControl("td20Dhu");
                        HtmlTableCell td21Dhu = (HtmlTableCell)e.Row.FindControl("td21Dhu");
                        HtmlTableCell td22Dhu = (HtmlTableCell)e.Row.FindControl("td22Dhu");
                        HtmlTableCell td23Dhu = (HtmlTableCell)e.Row.FindControl("td23Dhu");
                        HtmlTableCell td24Dhu = (HtmlTableCell)e.Row.FindControl("td24Dhu");



                        if (Slot1_Achievement>0 && Slot1_Achievement < 81)
                        {
                            td1Dhu.Style.Add("background-color", "red");
                            lblSlot1DHU.ForeColor = Color.Yellow;
                        }
                        //if (Slot1_Achievement > 79 && Slot1_Achievement < 86)
                        //{
                        //    td1Dhu.Style.Add("background-color", "orange");
                        //    lblSlot1DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot1_Achievement > 85)
                        else
                        {
                            td1Dhu.Style.Add("background-color", "green");
                            lblSlot1DHU.ForeColor = Color.Yellow;
                        }


                        if (Slot2_Achievement>0 && Slot2_Achievement < 81)
                        {
                            td2Dhu.Style.Add("background-color", "red");
                            lblSlot2DHU.ForeColor = Color.Yellow;
                        }
                        else
                        //if (Slot2_Achievement > 79 && Slot2_Achievement < 86)
                        //{
                        //    td2Dhu.Style.Add("background-color", "orange");
                        //    lblSlot2DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot2_Achievement > 85)
                        {
                            td2Dhu.Style.Add("background-color", "green");
                            lblSlot2DHU.ForeColor = Color.Yellow;
                        }

                        if (Slot3_Achievement > 0 &&  Slot3_Achievement < 81)
                        {
                            td3Dhu.Style.Add("background-color", "red");
                            lblSlot3DHU.ForeColor = Color.Yellow;
                        }
                        //if (Slot3_Achievement > 79 && Slot3_Achievement < 86)
                        //{
                        //    td3Dhu.Style.Add("background-color", "orange");
                        //    lblSlot3DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot3_Achievement > 85)
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
                        //if (Slot4_Achievement > 79 && Slot4_Achievement < 86)
                        //{
                        //    td4Dhu.Style.Add("background-color", "orange");
                        //    lblSlot4DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot4_Achievement > 85)
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
                        //if (Slot5_Achievement > 79 && Slot5_Achievement < 86)
                        //{
                        //    td5Dhu.Style.Add("background-color", "orange");
                        //    lblSlot5DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot5_Achievement > 85)
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
                        //if (Slot6_Achievement > 79 && Slot6_Achievement < 86)
                        //{
                        //    td6Dhu.Style.Add("background-color", "orange");
                        //    lblSlot6DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot6_Achievement > 85)
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
                        //if (Slot7_Achievement > 79 && Slot7_Achievement < 86)
                        //{
                        //    td7Dhu.Style.Add("background-color", "orange");
                        //    lblSlot7DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot7_Achievement > 85)
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
                        //if (Slot8_Achievement > 79 && Slot8_Achievement < 86)
                        //{
                        //    td8Dhu.Style.Add("background-color", "orange");
                        //    lblSlot8DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot8_Achievement > 85)
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
                        //if (Slot9_Achievement > 79 && Slot9_Achievement < 86)
                        //{
                        //    td9Dhu.Style.Add("background-color", "orange");
                        //    lblSlot9DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot9_Achievement > 85)
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
                        //if (Slot10_Achievement > 79 && Slot10_Achievement < 86)
                        //{
                        //    td10Dhu.Style.Add("background-color", "orange");
                        //    lblSlot10DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot10_Achievement > 85)
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
                        //if (Slot11_Achievement > 79 && Slot11_Achievement < 86)
                        //{
                        //    td11Dhu.Style.Add("background-color", "orange");
                        //    lblSlot11DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot11_Achievement > 85)
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
                        //if (Slot12_Achievement > 79 && Slot12_Achievement < 86)
                        //{
                        //    td12Dhu.Style.Add("background-color", "orange");
                        //    lblSlot12DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot12_Achievement > 85)
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
                        //if (Slot13_Achievement > 79 && Slot13_Achievement < 86)
                        //{
                        //    td13Dhu.Style.Add("background-color", "orange");
                        //    lblSlot13DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot13_Achievement > 85)
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
                        //if (Slot14_Achievement > 79 && Slot14_Achievement < 86)
                        //{
                        //    td14Dhu.Style.Add("background-color", "orange");
                        //    lblSlot14DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot14_Achievement > 85)
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
                        //if (Slot15_Achievement > 79 && Slot15_Achievement < 86)
                        //{
                        //    td15Dhu.Style.Add("background-color", "orange");
                        //    lblSlot15DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot15_Achievement > 85)
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
                        //if (Slot16_Achievement > 79 && Slot16_Achievement < 86)
                        //{
                        //    td16Dhu.Style.Add("background-color", "orange");
                        //    lblSlot16DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot16_Achievement > 85)
                        else
                        {
                            td16Dhu.Style.Add("background-color", "green");
                            lblSlot16DHU.ForeColor = Color.Yellow;
                        }

                        if (Slot17_Achievement > 0 && Slot17_Achievement < 81)
                        {
                            td17Dhu.Style.Add("background-color", "red");
                            lblSlot17DHU.ForeColor = Color.Yellow;
                        }
                        //if (Slot17_Achievement > 79 && Slot17_Achievement < 86)
                        //{
                        //    td17Dhu.Style.Add("background-color", "orange");
                        //    lblSlot17DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot17_Achievement > 85)
                        else
                        {
                            td17Dhu.Style.Add("background-color", "green");
                            lblSlot17DHU.ForeColor = Color.Yellow;
                        }

                        if (Slot18_Achievement > 0 && Slot18_Achievement < 81)
                        {
                            td18Dhu.Style.Add("background-color", "red");
                            lblSlot18DHU.ForeColor = Color.Yellow;
                        }
                        //if (Slot18_Achievement > 79 && Slot18_Achievement < 86)
                        //{
                        //    td18Dhu.Style.Add("background-color", "orange");
                        //    lblSlot18DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot18_Achievement > 85)
                        else
                        {
                            td18Dhu.Style.Add("background-color", "green");
                            lblSlot18DHU.ForeColor = Color.Yellow;
                        }


                        if (Slot19_Achievement > 0 && Slot19_Achievement < 81)
                        {
                            td19Dhu.Style.Add("background-color", "red");
                            lblSlot19DHU.ForeColor = Color.Yellow;
                        }
                        //if (Slot19_Achievement > 79 && Slot19_Achievement < 86)
                        //{
                        //    td19Dhu.Style.Add("background-color", "orange");
                        //    lblSlot19DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot19_Achievement > 85)
                        else
                        {
                            td19Dhu.Style.Add("background-color", "green");
                            lblSlot19DHU.ForeColor = Color.Yellow;
                        }
                        if (Slot20_Achievement > 0 && Slot20_Achievement < 81)
                        {
                            td20Dhu.Style.Add("background-color", "red");
                            lblSlot20DHU.ForeColor = Color.Yellow;
                        }
                        //if (Slot20_Achievement > 79 && Slot19_Achievement < 86)
                        //{
                        //    td20Dhu.Style.Add("background-color", "orange");
                        //    lblSlot20DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot20_Achievement > 85)
                        else
                        {
                            td20Dhu.Style.Add("background-color", "green");
                            lblSlot20DHU.ForeColor = Color.Yellow;
                        }
                        if (Slot21_Achievement > 0 && Slot21_Achievement < 81)
                        {
                            td21Dhu.Style.Add("background-color", "red");
                            lblSlot21DHU.ForeColor = Color.Yellow;
                        }
                        //if (Slot21_Achievement > 79 && Slot21_Achievement < 86)
                        //{
                        //    td21Dhu.Style.Add("background-color", "orange");
                        //    lblSlot21DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot21_Achievement > 85)
                        else
                        {
                            td21Dhu.Style.Add("background-color", "green");
                            lblSlot21DHU.ForeColor = Color.Yellow;
                        }
                        if (Slot22_Achievement > 0 && Slot22_Achievement < 81)
                        {
                            td22Dhu.Style.Add("background-color", "red");
                            lblSlot22DHU.ForeColor = Color.Yellow;
                        }
                        //if (Slot22_Achievement > 79 && Slot22_Achievement < 86)
                        //{
                        //    td22Dhu.Style.Add("background-color", "orange");
                        //    lblSlot22DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot22_Achievement > 85)
                        else
                        {
                            td22Dhu.Style.Add("background-color", "green");
                            lblSlot22DHU.ForeColor = Color.Yellow;
                        }
                        if (Slot23_Achievement > 0 && Slot23_Achievement < 81)
                        {
                            td23Dhu.Style.Add("background-color", "red");
                            lblSlot23DHU.ForeColor = Color.Yellow;
                        }
                        //if (Slot23_Achievement > 79 && Slot23_Achievement < 86)
                        //{
                        //    td23Dhu.Style.Add("background-color", "orange");
                        //    lblSlot23DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot23_Achievement > 85)
                        else
                        {
                            td23Dhu.Style.Add("background-color", "green");
                            lblSlot23DHU.ForeColor = Color.Yellow;
                        }
                        if (Slot24_Achievement > 0 && Slot24_Achievement < 81)
                        {
                            td24Dhu.Style.Add("background-color", "red");
                            lblSlot24DHU.ForeColor = Color.Yellow;
                        }
                        //if (Slot24_Achievement > 79 && Slot24_Achievement < 86)
                        //{
                        //    td24Dhu.Style.Add("background-color", "orange");
                        //    lblSlot24DHU.ForeColor = Color.Black;
                        //}
                        //if (Slot24_Achievement > 85)
                        else
                        {
                            td24Dhu.Style.Add("background-color", "green");
                            lblSlot24DHU.ForeColor = Color.Yellow;
                        }
                        //End Of Code on 18-jan-18
                        lblSlot1DHU.Text = Slot1_Achievement == 0 ? "" :Slot1_Achievement.ToString() + "%";
                        lblSlot2DHU.Text = Slot2_Achievement == 0 ? "" :Slot2_Achievement.ToString() + "%";
                        lblSlot3DHU.Text = Slot3_Achievement == 0 ? "" :Slot3_Achievement.ToString() + "%";
                        lblSlot4DHU.Text = Slot4_Achievement == 0 ? "" :Slot4_Achievement.ToString() + "%";
                        lblSlot5DHU.Text = Slot5_Achievement == 0 ? "" :Slot5_Achievement.ToString() + "%";
                        lblSlot6DHU.Text = Slot6_Achievement == 0 ? "" :Slot6_Achievement.ToString() + "%";
                        lblSlot7DHU.Text = Slot7_Achievement == 0 ? "" :Slot7_Achievement.ToString() + "%";
                        lblSlot8DHU.Text = Slot8_Achievement == 0 ? "" :Slot8_Achievement.ToString() + "%";
                        lblSlot9DHU.Text = Slot9_Achievement == 0 ? "" :Slot9_Achievement.ToString() + "%";
                        lblSlot10DHU.Text = Slot10_Achievement == 0 ? "" :Slot10_Achievement.ToString() + "%";
                        lblSlot11DHU.Text = Slot11_Achievement == 0 ? "" :Slot11_Achievement.ToString() + "%";
                        lblSlot12DHU.Text = Slot12_Achievement == 0 ? "" :Slot12_Achievement.ToString() + "%";
                        lblSlot13DHU.Text = Slot13_Achievement == 0 ? "" :Slot13_Achievement.ToString() + "%";
                        lblSlot14DHU.Text = Slot14_Achievement == 0 ? "" :Slot14_Achievement.ToString() + "%";
                        lblSlot15DHU.Text = Slot15_Achievement == 0 ? "" :Slot15_Achievement.ToString() + "%";
                        lblSlot16DHU.Text = Slot16_Achievement == 0 ? "" :Slot16_Achievement.ToString() + "%";
                        lblSlot17DHU.Text = Slot17_Achievement == 0 ? "" :Slot17_Achievement.ToString() + "%";
                        lblSlot18DHU.Text = Slot18_Achievement == 0 ? "" :Slot18_Achievement.ToString() + "%";
                        lblSlot19DHU.Text = Slot19_Achievement == 0 ? "" :Slot19_Achievement.ToString() + "%";
                        lblSlot20DHU.Text = Slot20_Achievement == 0 ? "" :Slot20_Achievement.ToString() + "%";
                        lblSlot21DHU.Text = Slot21_Achievement == 0 ? "" :Slot21_Achievement.ToString() + "%";
                        lblSlot22DHU.Text = Slot22_Achievement == 0 ? "" :Slot22_Achievement.ToString() + "%";
                        lblSlot23DHU.Text = Slot23_Achievement == 0 ? "" :Slot23_Achievement.ToString() + "%";
                        lblSlot24DHU.Text = Slot24_Achievement == 0 ? "" :Slot24_Achievement.ToString() + "%";


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
                        lblSlot17DHU.Font.Bold = true;
                        lblSlot18DHU.Font.Bold = true;
                        lblSlot19DHU.Font.Bold = true;
                        lblSlot20DHU.Font.Bold = true;
                        lblSlot21DHU.Font.Bold = true;
                        lblSlot22DHU.Font.Bold = true;
                        lblSlot23DHU.Font.Bold = true;
                        lblSlot24DHU.Font.Bold = true;

                        //lblSlot1DHU.CssClass = "Achievement";
                        //lblSlot2DHU.CssClass = "Achievement";
                        //lblSlot3DHU.CssClass = "Achievement";
                        //lblSlot4DHU.CssClass = "Achievement";
                        //lblSlot5DHU.CssClass = "Achievement";
                        //lblSlot6DHU.CssClass = "Achievement";
                        //lblSlot7DHU.CssClass = "Achievement";
                        //lblSlot8DHU.CssClass = "Achievement";
                        //lblSlot9DHU.CssClass = "Achievement";
                        //lblSlot10DHU.CssClass = "Achievement";
                        //lblSlot11DHU.CssClass = "Achievement";
                        //lblSlot12DHU.CssClass = "Achievement";
                        //lblSlot13DHU.CssClass = "Achievement";
                        //lblSlot14DHU.CssClass = "Achievement";
                        //lblSlot15DHU.CssClass = "Achievement";
                        //lblSlot16DHU.CssClass = "Achievement";
                        //lblSlot17DHU.CssClass = "Achievement";
                        //lblSlot18DHU.CssClass = "Achievement";
                        //lblSlot19DHU.CssClass = "Achievement";
                        //lblSlot20DHU.CssClass = "Achievement";
                        //lblSlot21DHU.CssClass = "Achievement";
                        //lblSlot22DHU.CssClass = "Achievement";
                        //lblSlot23DHU.CssClass = "Achievement";

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
                        Total_Achievement17 += DataBinder.Eval(e.Row.DataItem, "Slot17_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17_Achievement"));
                        Total_Achievement18 += DataBinder.Eval(e.Row.DataItem, "Slot18_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18_Achievement"));
                        Total_Achievement19 += DataBinder.Eval(e.Row.DataItem, "Slot19_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19_Achievement"));
                        Total_Achievement20 += DataBinder.Eval(e.Row.DataItem, "Slot20_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20_Achievement"));
                        Total_Achievement21 += DataBinder.Eval(e.Row.DataItem, "Slot21_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21_Achievement"));
                        Total_Achievement22 += DataBinder.Eval(e.Row.DataItem, "Slot22_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22_Achievement"));
                        Total_Achievement23 += DataBinder.Eval(e.Row.DataItem, "Slot23_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23_Achievement"));
                        Total_Achievement24 += DataBinder.Eval(e.Row.DataItem, "Slot24_Achievement") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24_Achievement"));

                        //Updated By Prabhaker

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


                        if (Slot17_Achievement < 85)
                            lblSlot17Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot17Pass.Style.Add("color", "green");


                        if (Slot18_Achievement < 85)
                            lblSlot18Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot18Pass.Style.Add("color", "green");


                        if (Slot19_Achievement < 85)
                            lblSlot19Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot19Pass.Style.Add("color", "green");


                        if (Slot20_Achievement < 85)
                            lblSlot20Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot20Pass.Style.Add("color", "green");


                        if (Slot21_Achievement < 85)
                            lblSlot21Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot21Pass.Style.Add("color", "green");


                        if (Slot22_Achievement < 85)
                            lblSlot22Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot22Pass.Style.Add("color", "green");


                        if (Slot23_Achievement < 85)
                            lblSlot23Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot23Pass.Style.Add("color", "green");


                        if (Slot24_Achievement < 85)
                            lblSlot24Pass.Style.Add("color", "#FF0000");
                        else
                            lblSlot24Pass.Style.Add("color", "green");

                        //End Of Updated By Prabhaker


                        EfficencyTotal = EfficencyTotal + 1;

                    }

                 
                    // End Of Code//
                }
                catch (Exception ex)
                {
                    string strError = ex.Message.ToString();
                    Application["HourlyError"] = strError.ToString();     
                }


            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {              
                e.Row.Attributes.Add("class", "yellowFactory");                
                //e.Row.Cells[28].Visible = false;
                //e.Row.Cells[29].Visible = false;
                //e.Row.Cells[30].Visible = false;
                //e.Row.Cells[31].Visible = false;
                e.Row.Cells[32].Visible = false;
                e.Row.Cells[33].Visible = false;
                e.Row.Cells[34].Visible = false;
              e.Row.Cells[35].Visible = false;
               
                Label lblSlot1PassTotal = (Label)e.Row.FindControl("lblSlot1PassTotal");
                if (Total_Slot1 != 0)
                {
                    if (Total_Slot1 > 999)
                    {
                        lblSlot1PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot1) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot1PassTotal.Text = Total_Slot1.ToString("#,##0");
                    }
                }

                Label lblSlot2PassTotal = (Label)e.Row.FindControl("lblSlot2PassTotal");
                if (Total_Slot2 != 0)
                {
                    if (Total_Slot2 > 999)
                    {
                        lblSlot2PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot2) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot2PassTotal.Text = Total_Slot2.ToString("#,##0");
                    }
                }

                Label lblSlot3PassTotal = (Label)e.Row.FindControl("lblSlot3PassTotal");
                if (Total_Slot3 != 0)
                {
                    if (Total_Slot3 > 999)
                    {
                        lblSlot3PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot3) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot3PassTotal.Text = Total_Slot3.ToString("#,##0");
                    }
                    
                }

                Label lblSlot4PassTotal = (Label)e.Row.FindControl("lblSlot4PassTotal");
                if (Total_Slot4 != 0)
                {
                    if (Total_Slot4 > 999)
                    {
                        lblSlot4PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot4) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot4PassTotal.Text = Total_Slot4.ToString("#,##0");
                    }
                    
                }

                Label lblSlot5PassTotal = (Label)e.Row.FindControl("lblSlot5PassTotal");
                if (Total_Slot5 != 0)
                {
                    if (Total_Slot5 > 999)
                    {
                        lblSlot5PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot5) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot5PassTotal.Text = Total_Slot5.ToString("#,##0");
                    }
                    
                }

                Label lblSlot6PassTotal = (Label)e.Row.FindControl("lblSlot6PassTotal");
                if (Total_Slot6 != 0)
                {
                    if (Total_Slot6 > 999)
                    {
                        lblSlot6PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot6) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot6PassTotal.Text = Total_Slot6.ToString("#,##0");
                    }
                    
                }

                Label lblSlot7PassTotal = (Label)e.Row.FindControl("lblSlot7PassTotal");
                if (Total_Slot7 != 0)
                {
                    if (Total_Slot7 > 999)
                    {
                        lblSlot7PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot7) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot7PassTotal.Text = Total_Slot7.ToString("#,##0");
                    }
                    
                }

                Label lblSlot8PassTotal = (Label)e.Row.FindControl("lblSlot8PassTotal");
                if (Total_Slot8 != 0)
                {
                    if (Total_Slot8 > 999)
                    {
                        lblSlot8PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot8) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot8PassTotal.Text = Total_Slot8.ToString("#,##0");
                    }
                   
                }

                Label lblSlot9PassTotal = (Label)e.Row.FindControl("lblSlot9PassTotal");
                if (Total_Slot9 != 0)
                {
                    if (Total_Slot9 > 999)
                    {
                        lblSlot9PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot9) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot9PassTotal.Text = Total_Slot9.ToString("#,##0");
                    }
                    
                }

                Label lblSlot10PassTotal = (Label)e.Row.FindControl("lblSlot10PassTotal");
                if (Total_Slot10 != 0)
                {
                    if (Total_Slot10 > 999)
                    {
                        lblSlot10PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot10) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot10PassTotal.Text = Total_Slot10.ToString("#,##0");
                    }
                   
                }

                Label lblSlot11PassTotal = (Label)e.Row.FindControl("lblSlot11PassTotal");
                if (Total_Slot11 != 0)
                {
                    if (Total_Slot11 > 999)
                    {
                        lblSlot11PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot11) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot11PassTotal.Text = Total_Slot11.ToString("#,##0");
                    }
                    
                }

                Label lblSlot12PassTotal = (Label)e.Row.FindControl("lblSlot12PassTotal");
                if (Total_Slot12 != 0)
                {
                    if (Total_Slot12 > 999)
                    {
                        lblSlot12PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot12) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot12PassTotal.Text = Total_Slot12.ToString("#,##0");
                    }
                    
                }

                Label lblSlot13PassTotal = (Label)e.Row.FindControl("lblSlot13PassTotal");
                if (Total_Slot13 != 0)
                {
                    if (Total_Slot13 > 999)
                    {
                        lblSlot13PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot13) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot13PassTotal.Text = Total_Slot13.ToString("#,##0");
                    }
                    
                }

                Label lblSlot14PassTotal = (Label)e.Row.FindControl("lblSlot14PassTotal");
                if (Total_Slot14 != 0)
                {
                    if (Total_Slot14 > 999)
                    {
                        lblSlot14PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot14) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot14PassTotal.Text = Total_Slot14.ToString("#,##0");
                    }
                   
                }

                Label lblSlot15PassTotal = (Label)e.Row.FindControl("lblSlot15PassTotal");
                if (Total_Slot15 != 0)
                {
                    if (Total_Slot15 > 999)
                    {
                        lblSlot15PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot15) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot15PassTotal.Text = Total_Slot15.ToString("#,##0");
                    }
                    
                }

                Label lblSlot16PassTotal = (Label)e.Row.FindControl("lblSlot16PassTotal");
                if (Total_Slot16 != 0)
                {
                    if (Total_Slot16 > 999)
                    {
                        lblSlot16PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot16) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot16PassTotal.Text = Total_Slot16.ToString("#,##0");
                    }
                    
                }

                Label lblSlot17PassTotal = (Label)e.Row.FindControl("lblSlot17PassTotal");
                if (Total_Slot17 != 0)
                {
                    if (Total_Slot17 > 999)
                    {
                        lblSlot17PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot17) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot17PassTotal.Text = Total_Slot17.ToString("#,##0");
                    }
                    
                }

                Label lblSlot18PassTotal = (Label)e.Row.FindControl("lblSlot18PassTotal");
                if (Total_Slot18 != 0)
                {
                    if (Total_Slot18 > 999)
                    {
                        lblSlot18PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot18) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot18PassTotal.Text = Total_Slot18.ToString("#,##0");
                    }
                    
                }

                Label lblSlot19PassTotal = (Label)e.Row.FindControl("lblSlot19PassTotal");
                if (Total_Slot19 != 0)
                {
                    if (Total_Slot19 > 999)
                    {
                        lblSlot19PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot19) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot19PassTotal.Text = Total_Slot19.ToString("#,##0");
                    }
                    
                }

                Label lblSlot20PassTotal = (Label)e.Row.FindControl("lblSlot20PassTotal");
                if (Total_Slot20 != 0)
                {
                    if (Total_Slot20 > 999)
                    {
                        lblSlot20PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot20) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot20PassTotal.Text = Total_Slot20.ToString("#,##0");
                    }
                    
                }

                Label lblSlot21PassTotal = (Label)e.Row.FindControl("lblSlot21PassTotal");
                if (Total_Slot21 != 0)
                {
                    if (Total_Slot21 > 999)
                    {
                        lblSlot21PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot21) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot21PassTotal.Text = Total_Slot21.ToString("#,##0");
                    }
                    
                }

                Label lblSlot22PassTotal = (Label)e.Row.FindControl("lblSlot22PassTotal");
                if (Total_Slot22 != 0)
                {
                    if (Total_Slot22 > 999)
                    {
                        lblSlot22PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot22) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot22PassTotal.Text = Total_Slot22.ToString("#,##0");
                    }
                    
                }

                Label lblSlot23PassTotal = (Label)e.Row.FindControl("lblSlot23PassTotal");
                if (Total_Slot23 != 0)
                {
                    if (Total_Slot23 > 999)
                    {
                        lblSlot23PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot23) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot23PassTotal.Text = Total_Slot23.ToString("#,##0");
                    }
                   
                }

                Label lblSlot24PassTotal = (Label)e.Row.FindControl("lblSlot24PassTotal");
                if (Total_Slot24 != 0)
                {
                    if (Total_Slot24 > 999)
                    {
                        lblSlot24PassTotal.Text = Math.Round(Convert.ToDouble(Total_Slot24) / 1000, 2).ToString() + "k";
                    }
                    else
                    {
                        lblSlot24PassTotal.Text = Total_Slot24.ToString("#,##0");
                    }
                   
                }

                Label lblSlot1DHUTotal = (Label)e.Row.FindControl("lblSlot1DHUTotal");
                if (Total_DHU1 != 0)
                    lblSlot1DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU1) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU1) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot2DHUTotal = (Label)e.Row.FindControl("lblSlot2DHUTotal");
                if (Total_DHU2 != 0)
                    lblSlot2DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU2) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU2) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot3DHUTotal = (Label)e.Row.FindControl("lblSlot3DHUTotal");
                if (Total_DHU3 != 0)
                    lblSlot3DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU3) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU3) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot4DHUTotal = (Label)e.Row.FindControl("lblSlot4DHUTotal");
                if (Total_DHU4 != 0)
                    lblSlot4DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU4) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU4) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot5DHUTotal = (Label)e.Row.FindControl("lblSlot5DHUTotal");
                if (Total_DHU5 != 0)
                    lblSlot5DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU5) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU5) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot6DHUTotal = (Label)e.Row.FindControl("lblSlot6DHUTotal");
                if (Total_DHU6 != 0)
                    lblSlot6DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU6) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU6) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot7DHUTotal = (Label)e.Row.FindControl("lblSlot7DHUTotal");
                if (Total_DHU7 != 0)
                    lblSlot7DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU7) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU7) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot8DHUTotal = (Label)e.Row.FindControl("lblSlot8DHUTotal");
                if (Total_DHU8 != 0)
                    lblSlot8DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU8) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU8) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot9DHUTotal = (Label)e.Row.FindControl("lblSlot9DHUTotal");
                if (Total_DHU9 != 0)
                    lblSlot9DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU9) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU9) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot10DHUTotal = (Label)e.Row.FindControl("lblSlot10DHUTotal");
                if (Total_DHU10 != 0)
                    lblSlot10DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU10) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU10) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot11DHUTotal = (Label)e.Row.FindControl("lblSlot11DHUTotal");
                if (Total_DHU11 != 0)
                    lblSlot11DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU11) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU11) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot12DHUTotal = (Label)e.Row.FindControl("lblSlot12DHUTotal");
                if (Total_DHU12 != 0)
                    lblSlot12DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU12) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU12) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot13DHUTotal = (Label)e.Row.FindControl("lblSlot13DHUTotal");
                if (Total_DHU13 != 0)
                    lblSlot13DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU13) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU13) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot14DHUTotal = (Label)e.Row.FindControl("lblSlot14DHUTotal");
                if (Total_DHU14 != 0)
                    lblSlot14DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU14) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU14) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot15DHUTotal = (Label)e.Row.FindControl("lblSlot15DHUTotal");
                if (Total_DHU15 != 0)
                    lblSlot15DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU15) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU15) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot16DHUTotal = (Label)e.Row.FindControl("lblSlot16DHUTotal");
                if (Total_DHU16 != 0)
                    lblSlot16DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU16) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU16) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot17DHUTotal = (Label)e.Row.FindControl("lblSlot17DHUTotal");
                if (Total_DHU17 != 0)
                    lblSlot17DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU17) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU17) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot18DHUTotal = (Label)e.Row.FindControl("lblSlot18DHUTotal");
                if (Total_DHU18 != 0)
                    lblSlot18DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU18) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU18) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot19DHUTotal = (Label)e.Row.FindControl("lblSlot19DHUTotal");
                if (Total_DHU19 != 0)
                    lblSlot19DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU19) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU19) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot20DHUTotal = (Label)e.Row.FindControl("lblSlot20DHUTotal");
                if (Total_DHU20 != 0)
                    lblSlot20DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU20) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU20) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot21DHUTotal = (Label)e.Row.FindControl("lblSlot21DHUTotal");
                if (Total_DHU21 != 0)
                    lblSlot21DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU21) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU21) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot22DHUTotal = (Label)e.Row.FindControl("lblSlot22DHUTotal");
                if (Total_DHU22 != 0)
                    lblSlot22DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU22) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU22) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot23DHUTotal = (Label)e.Row.FindControl("lblSlot23DHUTotal");
                if (Total_DHU23 != 0)
                    lblSlot23DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU23) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU23) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                Label lblSlot24DHUTotal = (Label)e.Row.FindControl("lblSlot24DHUTotal");
                if (Total_DHU24 != 0)
                    lblSlot24DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU24) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU24) / Convert.ToDouble(FactoryTotal), 0).ToString() + " %";

                double StchAvgPcs_Total = Math.Round(Convert.ToDouble(TodayPassPcsStitch_Total) / Convert.ToDouble(MaxStitchPassCount), 0);
                double FinishAvgPcs_Total = Math.Round(Convert.ToDouble(TodayPassPcsFinish_Total) / Convert.ToDouble(MaxFinishPassCount), 0);

                double StitchingPerPcsCost = Math.Round(((Convert.ToDouble(StitchActualOB_Total) * Convert.ToDouble(StichingPerOBCost)) / (Convert.ToDouble(StchAvgPcs_Total) == 0 ? 1 : Convert.ToDouble(StchAvgPcs_Total))), 0);
                double FinishingPerPcsCost = Math.Round(((Convert.ToDouble(FinishActualOB_Total) * Convert.ToDouble(FinishingPerOBCost)) / (Convert.ToDouble(FinishAvgPcs_Total) == 0 ? 1 : Convert.ToDouble(FinishAvgPcs_Total))), 0);

                double CalculatedCMT = CuttingPerPcsCost + FactoryOverHeadPerPcs + StitchingPerPcsCost + FinishingPerPcsCost;

                CostingCMT_Total = CostingCMT_Total / FactoryTotal;

                double CalStitchingPerPcsCost = 0;

                if (CalculatedCMT > CostingCMT_Total)
                {
                    CalStitchingPerPcsCost = StitchingPerPcsCost - (CalculatedCMT - CostingCMT_Total);
                    TotalBreakEvenQty = Math.Round((StitchingPerPcsCost / (CalStitchingPerPcsCost == 0 ? 1 : CalStitchingPerPcsCost)) * Convert.ToDouble(StchAvgPcs_Total), 0);
                    TotalBreakEvenEff = Math.Round((StitchingPerPcsCost / (CalStitchingPerPcsCost == 0 ? 1 : CalStitchingPerPcsCost)) * (Convert.ToDouble(TodayEfficiency_Stitch_Total) / Convert.ToDouble(FactoryTotal)), 0);
                }
                else if (CalculatedCMT <= CostingCMT_Total)
                {
                    CalStitchingPerPcsCost = StitchingPerPcsCost + (CostingCMT_Total - CalculatedCMT);
                    TotalBreakEvenQty = Math.Round((StitchingPerPcsCost / (CalStitchingPerPcsCost == 0 ? 1 : CalStitchingPerPcsCost)) * Convert.ToDouble(StchAvgPcs_Total), 0);
                    TotalBreakEvenEff = Math.Round((StitchingPerPcsCost / (CalStitchingPerPcsCost == 0 ? 1 : CalStitchingPerPcsCost)) * (Convert.ToDouble(TodayEfficiency_Stitch_Total) / Convert.ToDouble(FactoryTotal)), 0);
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
                    lblTodayDHU_Foo.Text = Math.Round(Convert.ToDouble(DHU_Today_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%";
                // Updated By Prabhaker 24/may/18
                if (TodayAchieved_Total != 0)
                    lblTodayAchieved_Foo.Text = Math.Round(Convert.ToDouble(TodayAchieved_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%";

                if (TodayAchieved_Total / FactoryTotal > 0 && TodayAchieved_Total / FactoryTotal < 81)
                {
                    lblTodayAchieved_Foo.ForeColor = Color.Red;
                }
                //if (TodayAchieved_Total / FactoryTotal > 79 && TodayAchieved_Total / FactoryTotal < 86)
                //{
                //    lblTodayAchieved_Foo.ForeColor = Color.Orange;
                //}
                //if (TodayAchieved_Total / FactoryTotal > 85)
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
                        StitchAvg_fooTotal = Math.Round(StitchAvg_fooTotal / 1000,2);
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
                        lblFinishAvgPcs_fooNew = Math.Round(lblFinishAvgPcs_fooNew / 1000,2);
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
                    lblPercentPerformance_Foo.Text = Math.Round(Convert.ToDouble(PercentPerformance_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%";


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
                //string FinishSAM_Foo = "";
                string FinActOB_Foo = "";
                string FinAgreedOB_Foo = "";
                string PkCpty_Foo = "";
                string PkEff_Foo = "";
                string COT_Foo = "";
                string StchQty_Foo = "";
                string FinQty_Foo = "";
                string TargetEffTotal = "";
                string TargetQtyTotal = "";
                string BreakEvenEffTotal = "";
                string BreakEvenQtyTotal = "";
                string PeakCapcty_Finish_Foo = "";


                // Finish Peak
                if (PeakCapcty_Finish_Total != 0)
                {
                    if (PeakCapcty_Finish_Total > 999)
                    {
                        double PeakCapcty_Finish_TotalNew = Math.Round(Convert.ToDouble(PeakCapcty_Finish_Total) / 1000,2);
                        if (PeakCapcty_Finish_TotalNew > 99.9)
                        {
                            PeakCapcty_Finish_Foo = Math.Round(PeakCapcty_Finish_TotalNew, 0).ToString() + "k Pcs";
                        }
                        else
                        {
                            PeakCapcty_Finish_Foo = PeakCapcty_Finish_TotalNew.ToString() + "k Pcs";
                        }
                    }
                    else
                    {
                        PeakCapcty_Finish_Foo = PeakCapcty_Finish_Total.ToString("#,##0") + " Pcs";
                    }
                }

                string TotalPressActualOB="";
                if (PressActualOB_Total > 0)
                {
                    TotalPressActualOB = "("+PressActualOB_Total.ToString() + ")";
                }
                //string styleClassAgrdFn = "";
                if (PeakOB_Finish_Total != 0)
                {
                    FinAgreedOB_Foo = "(" + PeakOB_Finish_Total.ToString() + ")";
                    //styleClassAgrdFn = "AgrdOBBlue";
                }
                else
                {
                    if (FinishOB_Total != 0)
                        FinAgreedOB_Foo = " (" + FinishOB_Total.ToString() + ")";
                    //styleClassAgrdFn = "AgrdOBBlack";
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
                       Double PeakCapecity_TotalNew = Math.Round(Convert.ToDouble(PeakCapecity_Total) / 1000,2);
                       if (PeakCapecity_TotalNew > 99.9)
                       {
                           PkCpty_Foo = Math.Round(PeakCapecity_TotalNew, 0).ToString() + "k Pcs"; /// Convert.ToDouble(FactoryTotal), 0).ToString();
               
                       }
                       else
                       {
                           PkCpty_Foo = PeakCapecity_TotalNew.ToString() + "k Pcs"; /// Convert.ToDouble(FactoryTotal), 0).ToString();
               
                       }
                    }
                    else
                    {
                      PkCpty_Foo = Math.Round(Convert.ToDouble(PeakCapecity_Total), 0).ToString("#,##0") + " Pcs"; /// Convert.ToDouble(FactoryTotal), 0).ToString();
                     }
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
                    PkEff_Foo = " (" + Math.Round(Convert.ToDouble(PeakEff_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%)";
                if (COTValue_Total != 0)
                    COT_Foo = Math.Round(Convert.ToDouble(COTValue_Total) / Convert.ToDouble(FactoryTotal), 0).ToString();

                if (StitchQty_Total != 0)
                    StchQty_Foo = StitchQty_Total.ToString("#,##0");
                if (FinishQty_Total != 0)
                    FinQty_Foo = FinishQty_Total.ToString("#,##0");

                if (TargetEff_Total != 0)
                    TargetEffTotal = Math.Round(Convert.ToDouble(TargetEff_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%";

                if (TargetQty_Total != 0)
                {
                  if (TargetQty_Total > 999)
                    {
                        double TargetQty_TotalNew = Math.Round(Convert.ToDouble(TargetQty_Total) / 1000, 2);
                          if(TargetQty_TotalNew>99.9)
                          {
                              TargetQtyTotal =  Math.Round(TargetQty_TotalNew,0).ToString() + "k Pcs";
                          }
                      else
                          {
                              TargetQtyTotal = TargetQty_TotalNew.ToString() + "k Pcs";
                          }
                    }
                  else
                  {
                    TargetQtyTotal = TargetQty_Total.ToString("#,##0") + " Pcs";
                  }
                }

                if (TotalBreakEvenEff > 0)

                    BreakEvenEffTotal = Math.Round(TotalBreakEvenEff, 0).ToString() + "%";

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


               // string sWIP_Cutting = WIPCutting_Foo <= 0 ? "" : WIPCutting_Foo.ToString() + " D";
               // string sWIPStitching = WIPStitching_Foo <= 0 ? "" : WIPStitching_Foo.ToString() + " D";
               // string sWIPFinished = WIPFinished_Foo <= 0 ? "" : WIPFinished_Foo.ToString() + " D";

                string sWIPCutQty_InProgressFoo = WIPCutQty_InProgressFoo <= 0 ? "" : WIPCutQty_InProgressFoo.ToString() + "k";
                string sWIPStitchQty_InProgressFoo = WIPStitchQty_InProgressFoo <= 0 ? "" : WIPStitchQty_InProgressFoo.ToString() + "k";
                string sWIPFinishQty_InProgressFoo = WIPFinishQty_InProgressFoo <= 0 ? "" : WIPFinishQty_InProgressFoo.ToString() + "k";

                string clsBreakEvenQty = "", FinQtyVal_footer="";

             


                //if (WIPCutting_Foo >= WIPStitching_Foo)
                //    clsWIPCutting = "WIPRed";
                //else
                //    clsWIPCutting = "WIPGreen";

                //if ((WIPStitching_Foo >= 0 && WIPStitching_Foo <= 2))
                //    clsWIPStitching = "WIPRed";
                //else
                //    clsWIPStitching = "WIPGreen";

                //if (WIPFinished_Foo == 0)
                //    clsWIPFinished = "WIPGreen";
                //else
                //    clsWIPFinished = "WIPRed";


                if (finishperobcost > 0 && FinishActualOB_Total > 0)
                {
                    double FinishFooterValue = Math.Round(((Convert.ToDouble(finishperobcost) * FinishActualOB_Total) / 10), 0);
                    if (FinishFooterValue > 999)
                    {
                        FinQtyVal_footer = Math.Round(FinishFooterValue / 1000,2).ToString() + "k";
                    }
                    else
                    {
                        FinQtyVal_footer = Math.Round(((Convert.ToDouble(finishperobcost) * FinishActualOB_Total) / 10), 0).ToString();
                
                    }
                   }

                if (TotalBreakEvenQty <= Factory_StchAvgPcs)
                    clsBreakEvenQty = "WIPGreen";
                else
                    clsBreakEvenQty = "WIPRed";

                string tablestring = "";

                tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' width='220px' border='0' style='border-collapse:collapse;'>";

                //-----------Edited Code-------------//

                tablestring = tablestring + "<tr> <td  height='20px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; width:100%; text-align:center;'><table cellpadding='0' cellpadding='0' cellspacing='0' width='100%' border='0'> <tr> <td style='width:20%; border-right:1px solid #bfbfbf;height:20px;text-align:center; color:black; font-weight:bold;'>&nbsp; </td> <td style='width:30%; border-right:1px solid #bfbfbf;height:15px;text-align:center;'>&nbsp;</td> <td style='width:50%;height:15px;text-align:center;'>&nbsp;</td></tr></table></td> </tr>";
                tablestring = tablestring + "<tr> <td  height='20px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; width:100%; text-align:center;'><table cellpadding='0' cellpadding='0' cellspacing='0' width='100%' border='0'> <tr> <td style='width:25%; border-right:1px solid #bfbfbf;height:20px;text-align:center; color:black; font-weight:bold;'>&nbsp;</td><td style='font-weight:bold; width:30%' class=" + clsBreakEvenQty + ">" + BreakEvenQtyTotal + "</td> <td style='width:20%; border-right:1px solid #bfbfbf;height:20px;text-align:center;'><b style='color:black;font-size:11px;'>" + TargetEffTotal + "</b></td> <td style='width:25%;height:20px;text-align:center;background:#90EE90; color:black;font-size: 11px !important;'>" + TargetQtyTotal + "</td></tr></table></td> </tr>";


                //           End Of Code               //




                tablestring = tablestring + "<tr> <td  height='20px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; width:210px; text-align:center;'><table cellpadding='0' cellpadding='0' cellspacing='0' width='100%' border='0'> <tr> <td style='width:25%; border-right:1px solid #bfbfbf;height:15px;text-align:center; color:black; font-weight:bold;'>" + StitchSAM_Foo + "  </td> <td style='width:25%; border-right:1px solid #bfbfbf;height:20px;text-align:center;'>";
                tablestring = tablestring + " <span id='lblStchActOB_Foo' class=" + styleClassObSt + " >" + StchActOB_Foo + "  </span> <span id='lblStchAgreedOB_Foo' class=" + styleClassAgrdSt + " >" + StchAgreedOB_Foo + " </span></td> <td style='width:25%;height:20px;text-align:center;border-right:1px solid #bfbfbf;'>" + PkCpty_Foo + " <span style='color:gray;'>" + PkEff_Foo + " </span></td><td style='width:25%; height:20px;text-align:center; font-weight:bold;'>";
                tablestring = tablestring + "<span id='lblFinActOB_Foo' class=" + clsFinActualOB + " >" + FinActOB_Foo + "</span> " + TotalPressActualOB + " </td></tr></table></td> </tr>";
                 
              
               // tablestring = tablestring + "<tr> <td  height='20px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; width:210px; text-align:center;'><table cellpadding='0' cellpadding='0' cellspacing='0' width='100%' border='0'> <tr> <td style='width:50%; border-right:1px solid #bfbfbf;height:15px;text-align:center; font-weight:bold;'><span id='lblFinActOB_Foo' class=" + clsFinActualOB + " >" + FinActOB_Foo + "</span> <span id='lblFinAgrdOB_Foo' class=" + styleClassAgrdFn + " >" + FinAgreedOB_Foo + "</span></td><td style='width:50%;height:15px;text-align:center;'>&nbsp;" + PeakCapcty_Finish_Foo + " </td> </tr> </table></td> </tr>";



                tablestring = tablestring + "<tr> <td  height='14px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; width:210px; text-align:center;'><table cellpadding='0' cellpadding='0' cellspacing='0' width='100%' border='0'> <tr><td style='width:25%; border-right:1px solid #bfbfbf;height:20px;text-align:center;'>&nbsp;</td><td style='width:25%;height:20px;text-align:center;border-right:1px solid #bfbfbf;'><span style='color:black; font-weight:bold;'>" + sWIPCutQty_InProgressFoo + "</span></td> <td style='width:25%; border-right:1px solid #bfbfbf;height:20px;text-align:center;'>&nbsp; <span style='color:black; font-weight:bold;'> " + sWIPStitchQty_InProgressFoo + "</span></td> <td height='20px' style='width:25%; height:15px;text-align:center;'> <span style='color:black; font-weight:bold;'> " + sWIPFinishQty_InProgressFoo + " </span> </td></tr></table> </td> </tr>";



               // tablestring = tablestring + "<tr> <td  height='14px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; width:210px; text-align:center;'><table cellpadding='0' cellpadding='0' cellspacing='0' width='100%' border='0'> <tr><td  style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; width:25%'> <b style='color:black'>" + TargetEffTotal + "</b></td> <td  style='border-bottom:1px solid #bfbfbf; background:#90EE90; color:black;font-size: 11px !important; width:25%'> " + TargetQtyTotal + "</td>  <td style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; width:25%'> " + BreakEvenEffTotal + "</td> <td style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; font-weight:bold; width:25%' class=" + clsBreakEvenQty + ">" + BreakEvenQtyTotal + "</td></tr></table> </td> </tr>";
                  


                tablestring = tablestring + "<tr> <td height='20px' style='border-right:1px solid #bfbfbf; ' ><h3 style='font-weight:normal; font-size:12px; padding:0px; margin:0px; text-align:center;'> Efficiency  </h3> </td>  </tr>";



                tablestring = tablestring + "<tr> <td height='20px' style='border-right:1px solid #bfbfbf; border-top:1px solid #bfbfbf;' ><h3 style='font-weight:normal; font-size:12px; padding:0px; margin:0px; text-align:center;'> Achievement  </h3> </td>  </tr>";



                tablestring = tablestring + "<tr> <td height='20px' style='border-right:1px solid #bfbfbf; border-top:1px solid #bfbfbf;' ><h3 style='font-weight:normal; font-size:12px; padding:0px; margin:0px; text-align:center;'> BIPL Price  </h3> </td>  </tr>";

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
                if ((TodayEfficiency_Stitch_Total != 0) || (TodayEfficiency_Stitch_Total > 0))
                    lblTodayEff_Stitch_Foo.Text = Math.Round(Convert.ToDouble(TodayEfficiency_Stitch_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%";


                if ((StyleEfficiency_Stitch_Total != 0) || (StyleEfficiency_Stitch_Total != -1))
                    lblStyleEff_Stitch_Foo.Text = "(" + Math.Round(Convert.ToDouble(StyleEfficiency_Stitch_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%)";

                if (OrderQty_Total != 0)
                {
                    if (OrderQty_Total > 999)
                    {
                        double OrderQty_TotalNew = Math.Round(Convert.ToDouble(OrderQty_Total) / 1000,2);
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
                    {
                        lblCutQty_Foo.Text =CutQty_Total.ToString("#,##0");
                    }
                }

                if (StitchQty_Total != 0)
                {
                    if (StitchQty_Total > 999)
                    {
                        double StitchQty_TotalNew = Math.Round(Convert.ToDouble(StitchQty_Total) / 1000,2);
                        if (StitchQty_TotalNew > 99.9)
                            lblStitchQty_Foo.Text = Math.Round(StitchQty_TotalNew, 0).ToString() + "k";
                        else
                            lblStitchQty_Foo.Text = StitchQty_TotalNew.ToString() + "k";
                    }
                    else
                    {
                        lblStitchQty_Foo.Text = StitchQty_Total.ToString("#,##0");
                    }
                }

                if (FinishQty_Total != 0)                    
                {
                    if (FinishQty_Total > 999)
                    {
                        double FinishQty_TotalNew = Math.Round(Convert.ToDouble(FinishQty_Total) / 1000,2);
                        if (FinishQty_TotalNew > 99.9)
                            lblFinishQty_Foo.Text ="("+ Math.Round(FinishQty_TotalNew, 0).ToString() + "k)";
                        else
                            lblFinishQty_Foo.Text = "(" + FinishQty_TotalNew.ToString() + "k)";                       
                    }
                    else
                    {
                        lblFinishQty_Foo.Text = "(" + FinishQty_Total.ToString("#,##0") + ")";
                    }
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
                HtmlControl tdFinishCost_footer = (HtmlControl)e.Row.FindControl("tdFinishCost_footer");               
                if (BIPLTotalTodayFinishObatLineCluster > 0 && TodayPassFinish_BIPL > 0)
                {
                    lblFInishCost_total.Text = "&#8377;" + Math.Round(((Convert.ToDouble(BIPLTotalTodayFinishObatLineCluster) * finishperobcost) / TodayPassFinish_BIPL), 0).ToString();

                    if (Math.Round(((Convert.ToDouble(BIPLTotalTodayFinishObatLineCluster) * finishperobcost) / TodayPassFinish_BIPL), 0) <= 10)
                    {
                       // tdFinishCost_footer.Style.Add("background", "green");
                        lblFInishCost_total.Style.Add("color", "green");
                    }
                    //else if (Math.Round(((Convert.ToDouble(BIPLTotalTodayFinishObatLineCluster) * finishperobcost) / TodayPassFinish_BIPL), 0) < 13 && Math.Round(((Convert.ToDouble(BIPLTotalTodayFinishObatLineCluster) * finishperobcost) / TodayPassFinish_BIPL), 0) > 9)
                    //{
                    //   // tdFinishCost_footer.Style.Add("background", "Orange");
                    //    lblFInishCost_total.Style.Add("color", "Orange");
                    //}
                    else
                    {
                       // tdFinishCost_footer.Style.Add("background", "#FF0000");
                        lblFInishCost_total.Style.Add("color", "#FF0000");
                    }

                    if (Math.Round(((Convert.ToDouble(BIPLTotalTodayFinishObatLineCluster) * finishperobcost) / TodayPassFinish_BIPL), 0) <= 12)
                    {
                        lblTodayPassFinish_Foo.Style.Add("color", "green");
                    }
                    else
                    {
                        lblTodayPassFinish_Foo.Style.Add("color", "#FF0000");

                    }
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

                HtmlTableCell tdSlot17PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot17PassTotal");
                HtmlTableCell tdSlot18PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot18PassTotal");
                HtmlTableCell tdSlot19PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot19PassTotal");
                HtmlTableCell tdSlot20PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot20PassTotal");
                HtmlTableCell tdSlot21PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot21PassTotal");
                HtmlTableCell tdSlot22PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot22PassTotal");
                HtmlTableCell tdSlot23PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot23PassTotal");
                HtmlTableCell tdSlot24PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot24PassTotal");                

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
                Label lbl17StitchEff_Foo = (Label)e.Row.FindControl("lbl17StitchEff_Foo");
                Label lbl18StitchEff_Foo = (Label)e.Row.FindControl("lbl18StitchEff_Foo");
                Label lbl19StitchEff_Foo = (Label)e.Row.FindControl("lbl19StitchEff_Foo");
                Label lbl20StitchEff_Foo = (Label)e.Row.FindControl("lbl20StitchEff_Foo");
                Label lbl21StitchEff_Foo = (Label)e.Row.FindControl("lbl21StitchEff_Foo");
                Label lbl22StitchEff_Foo = (Label)e.Row.FindControl("lbl22StitchEff_Foo");
                Label lbl23StitchEff_Foo = (Label)e.Row.FindControl("lbl23StitchEff_Foo");
                Label lbl24StitchEff_Foo = (Label)e.Row.FindControl("lbl24StitchEff_Foo");

                Total_StitchEff1 = Total_Slot1 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot1) * StitchSAM_Total) / (Convert.ToDouble(Slot1TotalOB) * 60)) * 100, 0);

                Total_StitchEff2 = Total_Slot2 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot2) * StitchSAM_Total) / (Convert.ToDouble(Slot2TotalOB) * 60)) * 100, 0);

                Total_StitchEff3 = Total_Slot3 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot3) * StitchSAM_Total) / (Convert.ToDouble(Slot3TotalOB) * 60)) * 100, 0);

                Total_StitchEff4 = Total_Slot4 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot4) * StitchSAM_Total) / (Convert.ToDouble(Slot4TotalOB) * 60)) * 100, 0);

                Total_StitchEff5 = Total_Slot5 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot5) * StitchSAM_Total) / (Convert.ToDouble(Slot5TotalOB) * 60)) * 100, 0);

                Total_StitchEff6 = Total_Slot6 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot6) * StitchSAM_Total) / (Convert.ToDouble(Slot6TotalOB) * 60)) * 100, 0);

                Total_StitchEff7 = Total_Slot7 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot7) * StitchSAM_Total) / (Convert.ToDouble(Slot7TotalOB) * 60)) * 100, 0);

                Total_StitchEff8 = Total_Slot8 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot8) * StitchSAM_Total) / (Convert.ToDouble(Slot8TotalOB) * 60)) * 100, 0);

                Total_StitchEff9 = Total_Slot9 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot9) * StitchSAM_Total) / (Convert.ToDouble(Slot9TotalOB) * 60)) * 100, 0);

                Total_StitchEff10 = Total_Slot10 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot10) * StitchSAM_Total) / (Convert.ToDouble(Slot10TotalOB) * 60)) * 100, 0);

                Total_StitchEff11 = Total_Slot11 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot11) * StitchSAM_Total) / (Convert.ToDouble(Slot11TotalOB) * 60)) * 100, 0);

                Total_StitchEff12 = Total_Slot12 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot12) * StitchSAM_Total) / (Convert.ToDouble(Slot12TotalOB) * 60)) * 100, 0);

                Total_StitchEff13 = Total_Slot13 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot13) * StitchSAM_Total) / (Convert.ToDouble(Slot13TotalOB) * 60)) * 100, 0);

                Total_StitchEff14 = Total_Slot14 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot14) * StitchSAM_Total) / (Convert.ToDouble(Slot14TotalOB) * 60)) * 100, 0);

                Total_StitchEff15 = Total_Slot15 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot15) * StitchSAM_Total) / (Convert.ToDouble(Slot15TotalOB) * 60)) * 100, 0);

                Total_StitchEff16 = Total_Slot16 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot16) * StitchSAM_Total) / (Convert.ToDouble(Slot16TotalOB) * 60)) * 100, 0);

                Total_StitchEff17 = Total_Slot17 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot17) * StitchSAM_Total) / (Convert.ToDouble(Slot17TotalOB) * 60)) * 100, 0);

                Total_StitchEff18 = Total_Slot18 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot18) * StitchSAM_Total) / (Convert.ToDouble(Slot18TotalOB) * 60)) * 100, 0);

                Total_StitchEff19 = Total_Slot19 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot19) * StitchSAM_Total) / (Convert.ToDouble(Slot19TotalOB) * 60)) * 100, 0);

                Total_StitchEff20 = Total_Slot20 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot20) * StitchSAM_Total) / (Convert.ToDouble(Slot20TotalOB) * 60)) * 100, 0);

                Total_StitchEff21 = Total_Slot21 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot21) * StitchSAM_Total) / (Convert.ToDouble(Slot21TotalOB) * 60)) * 100, 0);

                Total_StitchEff22 = Total_Slot22 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot22) * StitchSAM_Total) / (Convert.ToDouble(Slot22TotalOB) * 60)) * 100, 0);

                Total_StitchEff23 = Total_Slot23 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot23) * StitchSAM_Total) / (Convert.ToDouble(Slot23TotalOB) * 60)) * 100, 0);

                Total_StitchEff24 = Total_Slot24 == 0 ? 0 : Math.Round(((Convert.ToDouble(Total_Slot24) * StitchSAM_Total) / (Convert.ToDouble(Slot24TotalOB) * 60)) * 100, 0);


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

                lbl17StitchEff_Foo.Text = Total_StitchEff17 == 0 ? "" : Total_StitchEff17.ToString() + "%";

                lbl18StitchEff_Foo.Text = Total_StitchEff18 == 0 ? "" : Total_StitchEff18.ToString() + "%";

                lbl19StitchEff_Foo.Text = Total_StitchEff19 == 0 ? "" : Total_StitchEff19.ToString() + "%";

                lbl20StitchEff_Foo.Text = Total_StitchEff20 == 0 ? "" : Total_StitchEff20.ToString() + "%";

                lbl21StitchEff_Foo.Text = Total_StitchEff21 == 0 ? "" : Total_StitchEff21.ToString() + "%";

                lbl22StitchEff_Foo.Text = Total_StitchEff22 == 0 ? "" : Total_StitchEff22.ToString() + "%";

                lbl23StitchEff_Foo.Text = Total_StitchEff23 == 0 ? "" : Total_StitchEff23.ToString() + "%";

                lbl24StitchEff_Foo.Text = Total_StitchEff24 == 0 ? "" : Total_StitchEff24.ToString() + "%";
                
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
                Label lbl17Achieved_Foo = (Label)e.Row.FindControl("lbl17Achieved_Foo");
                Label lbl18Achieved_Foo = (Label)e.Row.FindControl("lbl18Achieved_Foo");
                Label lbl19Achieved_Foo = (Label)e.Row.FindControl("lbl19Achieved_Foo");
                Label lbl20Achieved_Foo = (Label)e.Row.FindControl("lbl20Achieved_Foo");
                Label lbl21Achieved_Foo = (Label)e.Row.FindControl("lbl21Achieved_Foo");
                Label lbl22Achieved_Foo = (Label)e.Row.FindControl("lbl22Achieved_Foo");
                Label lbl23Achieved_Foo = (Label)e.Row.FindControl("lbl23Achieved_Foo");
                Label lbl24Achieved_Foo = (Label)e.Row.FindControl("lbl24Achieved_Foo");

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
                    HtmlTableCell td17Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td17Achieved_Foo");
                    HtmlTableCell td18Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td18Achieved_Foo");
                    HtmlTableCell td19Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td19Achieved_Foo");
                    HtmlTableCell td20Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td20Achieved_Foo");
                    HtmlTableCell td21Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td21Achieved_Foo");
                    HtmlTableCell td22Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td22Achieved_Foo");
                    HtmlTableCell td23Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td23Achieved_Foo");
                    HtmlTableCell td24Achieved_Foo = (HtmlTableCell)e.Row.FindControl("td24Achieved_Foo");


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
                Label lbl17BiplPrice_Foo = (Label)e.Row.FindControl("lbl17BiplPrice_Foo");
                Label lbl18BiplPrice_Foo = (Label)e.Row.FindControl("lbl18BiplPrice_Foo");
                Label lbl19BiplPrice_Foo = (Label)e.Row.FindControl("lbl19BiplPrice_Foo");
                Label lbl20BiplPrice_Foo = (Label)e.Row.FindControl("lbl20BiplPrice_Foo");
                Label lbl21BiplPrice_Foo = (Label)e.Row.FindControl("lbl21BiplPrice_Foo");
                Label lbl22BiplPrice_Foo = (Label)e.Row.FindControl("lbl22BiplPrice_Foo");
                Label lbl23BiplPrice_Foo = (Label)e.Row.FindControl("lbl23BiplPrice_Foo");
                Label lbl24BiplPrice_Foo = (Label)e.Row.FindControl("lbl24BiplPrice_Foo");

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

                if (BIPLPriceSlot17 != 0)
                    lbl17BiplPrice_Foo.Text = (BIPLPriceSlot17 / 100000) > 0 ? Math.Round(BIPLPriceSlot17 / 100000, 1).ToString() + " L" : "";

                if (BIPLPriceSlot18 != 0)
                    lbl18BiplPrice_Foo.Text = (BIPLPriceSlot18 / 100000) > 0 ? Math.Round(BIPLPriceSlot18 / 100000, 1).ToString() + " L" : "";

                if (BIPLPriceSlot19 != 0)
                    lbl19BiplPrice_Foo.Text = (BIPLPriceSlot19 / 100000) > 0 ? Math.Round(BIPLPriceSlot19 / 100000, 1).ToString() + " L" : "";

                if (BIPLPriceSlot20 != 0)
                    lbl20BiplPrice_Foo.Text = (BIPLPriceSlot20 / 100000) > 0 ? Math.Round(BIPLPriceSlot20 / 100000, 1).ToString() + " L" : "";

                if (BIPLPriceSlot21 != 0)
                    lbl21BiplPrice_Foo.Text = (BIPLPriceSlot21 / 100000) > 0 ? Math.Round(BIPLPriceSlot21 / 100000, 1).ToString() + " L" : "";

                if (BIPLPriceSlot22 != 0)
                    lbl22BiplPrice_Foo.Text = (BIPLPriceSlot22 / 100000) > 0 ? Math.Round(BIPLPriceSlot22 / 100000, 1).ToString() + " L" : "";

                if (BIPLPriceSlot23 != 0)
                    lbl23BiplPrice_Foo.Text = (BIPLPriceSlot23 / 100000) > 0 ? Math.Round(BIPLPriceSlot23 / 100000, 1).ToString() + " L" : "";

                if (BIPLPriceSlot24 != 0)
                    lbl24BiplPrice_Foo.Text = (BIPLPriceSlot24 / 100000) > 0 ? Math.Round(BIPLPriceSlot24 / 100000, 1).ToString() + " L" : "";            
               
                // hello footer
                int TotalCount = (TotalPassCount + TotalFailCount) * 5;

                DataSet dsGetBottleNeck;
                dsGetBottleNeck = objProductionController.GetBottleNeck_QC_HourlyReport_ForFactory(-1, TotalCount,SlotId);
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

        }

        protected void dlstInspection_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblInspectionDetails = (Label)e.Item.FindControl("lblInspectionDetails") as Label;
                HtmlTableCell tdInspectionDetails=(HtmlTableCell)e.Item.FindControl("tdInspectionDetails") as HtmlTableCell;

                if (lblInspectionDetails.Text == "")
                {
                    tdInspectionDetails.Visible = false;
                }
              
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
                {
                    lblFabricCount.Text = "F(" + lblFabricCount.Text + "),";
                }
                else
                {
                    //lblFabricCount.Text = "F,";
                    lblFabricCount.Text = "";
                }
                if (lblAccessCount.Text != "0" && lblAccessCount.Text != "")
                {
                    lblAccessCount.Text = " A(" + lblAccessCount.Text + ")";
                }
                else
                {
                    //lblAccessCount.Text = " A";
                    lblAccessCount.Text = "";
                }

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
                //if (lblLastSlotFinish.Text != "")
                //{
                //    lblLastSlotFinish.Text = ", " + lblLastSlotFinish.Text; ViewState["GetQCFaultCount"]
                //}

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

                if ((lblFaultCode.Text != "") && (lblFaultCode.Text != "Other"))
                {
                    string splitFaultCode = lblFaultCode.Text;
                    string[] QCFaultCode = splitFaultCode.Split('-');
                    lblFaultCode.Text = QCFaultCode[1].ToString();
                }

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

                if ((lblFaultCodeFoo.Text != "") && (lblFaultCodeFoo.Text != "Other"))
                {
                    string splitFaultCode = lblFaultCodeFoo.Text;
                    string[] QCFaultCode = splitFaultCode.Split('-');
                    lblFaultCodeFoo.Text = QCFaultCode[1].ToString();
                }

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
                    else if (ExFactory.Substring(0, 6) == "LastBy")
                    {                        
                        ExFactory = ExFactory.Substring(6, 8);
                        string year = ExFactory.Substring(0, 4);
                        string Month = ExFactory.Substring(4, 2);
                        string Days = ExFactory.Substring(6, 2);
                        strex = Month + "-" + Days + "-" + year;
                        DateTime strexDT = Convert.ToDateTime(strex);

                        e.Row.Cells[i].Text = "Last By " + strexDT.ToString("dd MMM (ddd)");
                       // e.Row.Cells[i].Width = 100;
                        e.Row.Cells[i].Attributes.Add("style" , "width:33%");
                    }
                    else if (ExFactory.Substring(0,7) == "Delayed")
                    {
                        ExFactory = ExFactory.Substring(9, 8);
                        string year = ExFactory.Substring(0, 4);
                        string Month = ExFactory.Substring(4, 2);
                        string Days = ExFactory.Substring(6, 2);
                        strex = Month + "-" + Days + "-" + year;

                        DateTime strexDT = Convert.ToDateTime(strex);
                        string sExFactory = strexDT.ToString("dd MMM (ddd)");

                        e.Row.Cells[i].Text = "Dlyd Frm " + sExFactory;
                        e.Row.Cells[i].Attributes.Add("style", "width:33%");
                    }
                    else
                    {
                        ExFactory = ExFactory.Substring(2, 8);
                        string year = ExFactory.Substring(0, 4);
                        string Month = ExFactory.Substring(4, 2);
                        string Days = ExFactory.Substring(6, 2);
                        strex = Month + "-" + Days + "-" + year;

                        DateTime strexDT = Convert.ToDateTime(strex);
                        e.Row.Cells[i].Text = strexDT.ToString("dd MMM (ddd)");
                       // e.Row.Cells[i].Width = 100;
                        e.Row.Cells[i].Attributes.Add("style", "width:33%");
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
                           // e.Row.Cells[i].Font.Bold = true;
                            lblPendingCol.Text = "Pnd St. Qty (fin. Qty)";
                            e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;
                        }
                        if (RowIndex == 0)
                        {
                            if (dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString() != "")
                            {
                              
                                e.Row.Cells[i].Text = dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString();//iQuantity.ToString() == "0" ? "" : iQuantity.ToString("#,##0");
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
                                DateTime EstDate;

                                if (sDate != "")
                                {
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
                                        EstDateWithSlot = EstDate.ToString("dd MMM (ddd)") + " " + EndSlot + " <span style='color:gray'> " + sEstHrs +"</span>";
                                    }

                                    string ExFactory = dtPending.Columns[i].ColumnName;
                                    if (ExFactory.Substring(0, 7) == "Delayed")
                                    {
                                        e.Row.Cells[i].Text = EstDateWithSlot;
                                        e.Row.Cells[i].CssClass = "EstDateGreaterExFactory";
                                        ((GridView)sender).HeaderRow.Cells[i].CssClass = "bgred";
                                        ((GridView)sender).HeaderRow.Cells[i].ForeColor = System.Drawing.Color.Yellow;
                                    }
                                    else if (ExFactory.Substring(0, 6) == "LastBy")
                                    {
                                        ExFactory = ExFactory.Substring(6, 8);
                                        string year = ExFactory.Substring(0, 4);
                                        string Month = ExFactory.Substring(4, 2);
                                        string Days = ExFactory.Substring(6, 2);
                                        strex = Month + "-" + Days + "-" + year;
                                        DateTime strexDT = Convert.ToDateTime(strex);
                                        if (EstDate.Date <= strexDT.Date)
                                        {
                                            ((GridView)sender).HeaderRow.Cells[i].CssClass = "bggreen";
                                            ((GridView)sender).HeaderRow.Cells[i].ForeColor = System.Drawing.Color.Yellow;
                                            e.Row.Cells[i].CssClass = "EstDateLessExFactory";
                                        }
                                        else
                                        {
                                            ((GridView)sender).HeaderRow.Cells[i].CssClass = "bgred";
                                            ((GridView)sender).HeaderRow.Cells[i].ForeColor = System.Drawing.Color.Yellow;
                                            e.Row.Cells[i].CssClass = "EstDateGreaterExFactory";
                                        }

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
                                        {
                                            e.Row.Cells[i].Text = EstDateWithSlot;
                                            e.Row.Cells[i].CssClass = "EstDateLessExFactory";
                                            ((GridView)sender).HeaderRow.Cells[i].CssClass = "bggreen";
                                            ((GridView)sender).HeaderRow.Cells[i].ForeColor = System.Drawing.Color.Yellow;
                                        }
                                        else
                                        {
                                            e.Row.Cells[i].Text = EstDateWithSlot;
                                            e.Row.Cells[i].CssClass = "EstDateGreaterExFactory";
                                            ((GridView)sender).HeaderRow.Cells[i].CssClass = "bgred";
                                            ((GridView)sender).HeaderRow.Cells[i].ForeColor = System.Drawing.Color.Yellow;
                                        }
                                       
                                    }

                                }

                            }
                        }
                        if (RowIndex == 2)
                        {
                            //if (dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString() != "")
                            //{
                            //    string sDate = dtPending.Rows[RowIndex][dtPending.Columns[i].ColumnName].ToString();
                            //    e.Row.Cells[i].Text = sDate;
                            //    e.Row.Cells[i].CssClass = "EstHours";
                            //}
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
                                    //if (IsCluster == 1)
                                    //{
                                    //    EstDate = Convert.ToDateTime(sDate);
                                    //    EstDateWithSlot = EstDate.ToString("dd MMM (ddd)");
                                    //}
                                    //else
                                    //{
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
                                        EstDateWithSlot = EstDate.ToString("dd MMM (ddd)") + " " + EndSlot + " <span style='color:gray'>" + sEstHrs + "</span>";
                                    //}

                                    string ExFactory = dtPending.Columns[i].ColumnName;
                                    if (ExFactory.Substring(0, 7) == "Delayed")
                                    {
                                        e.Row.Cells[i].Text = EstDateWithSlot;
                                        e.Row.Cells[i].CssClass = "EstDateGreaterExFactory";
                                        ((GridView)sender).HeaderRow.Cells[i].CssClass = "bgred";
                                        ((GridView)sender).HeaderRow.Cells[i].ForeColor = System.Drawing.Color.Yellow;
                                    }
                                    else if (ExFactory.Substring(0, 6) == "LastBy")
                                    {
                                        ExFactory = ExFactory.Substring(6, 8);
                                        string year = ExFactory.Substring(0, 4);
                                        string Month = ExFactory.Substring(4, 2);
                                        string Days = ExFactory.Substring(6, 2);
                                        strex = Month + "-" + Days + "-" + year;
                                        DateTime strexDT = Convert.ToDateTime(strex);
                                        if (EstDate.Date <= strexDT.Date)
                                        {
                                            ((GridView)sender).HeaderRow.Cells[i].CssClass = "bggreen";
                                            ((GridView)sender).HeaderRow.Cells[i].ForeColor = System.Drawing.Color.Yellow;
                                            e.Row.Cells[i].CssClass = "EstDateLessExFactory";
                                        }
                                        else
                                        {
                                            ((GridView)sender).HeaderRow.Cells[i].CssClass = "bgred";
                                            ((GridView)sender).HeaderRow.Cells[i].ForeColor = System.Drawing.Color.Yellow;
                                            e.Row.Cells[i].CssClass = "EstDateGreaterExFactory";
                                        }

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
                                        {
                                            e.Row.Cells[i].Text = EstDateWithSlot;
                                            e.Row.Cells[i].CssClass = "EstDateLessExFactory";
                                            ((GridView)sender).HeaderRow.Cells[i].CssClass = "bggreen";
                                            ((GridView)sender).HeaderRow.Cells[i].ForeColor = System.Drawing.Color.Yellow;
                                        }
                                        else
                                        {
                                            e.Row.Cells[i].Text = EstDateWithSlot;
                                            e.Row.Cells[i].CssClass = "EstDateGreaterExFactory";
                                            ((GridView)sender).HeaderRow.Cells[i].CssClass = "bgred";
                                            ((GridView)sender).HeaderRow.Cells[i].ForeColor = System.Drawing.Color.Yellow;
                                        }

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
            for (int i = SlotId; i < 27; i++)
            {
                gvHourlyStitchingReport.Columns[i].Visible = false;
                gvHourlyStitchingReport.Width = Convert.ToInt32(hdnSlotId.Value) * 35 + 1220;
            }
        }
        private void HideStitchingTimingUnUsedSlot()
        {
            SlotId = Convert.ToInt32(hdnSlotId.Value);
            //SlotId = SlotId + 5;
            for (int i = SlotId; i < 24; i++)
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