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

namespace iKandi.Web.UserControls.Lists
{
    public partial class HourlyStitchingReportNewUser : System.Web.UI.UserControl
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

        int Total_PassFinish1 = 0;
        int Total_PassFinish2 = 0;
        int Total_PassFinish3 = 0;
        int Total_PassFinish4 = 0;
        int Total_PassFinish5 = 0;
        int Total_PassFinish6 = 0;
        int Total_PassFinish7 = 0;
        int Total_PassFinish8 = 0;
        int Total_PassFinish9 = 0;
        int Total_PassFinish10 = 0;
        int Total_PassFinish11 = 0;
        int Total_PassFinish12 = 0;
        int Total_PassFinish13 = 0;
        int Total_PassFinish14 = 0;
        int Total_PassFinish15 = 0;
        int Total_PassFinish16 = 0;
        int Total_PassFinish17 = 0;
        int Total_PassFinish18 = 0;
        int Total_PassFinish19 = 0;
        int Total_PassFinish20 = 0;
        int Total_PassFinish21 = 0;
        int Total_PassFinish22 = 0;
        int Total_PassFinish23 = 0;
        int Total_PassFinish24 = 0;

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

        int Total_FinishEff1 = 0;
        int Total_FinishEff2 = 0;
        int Total_FinishEff3 = 0;
        int Total_FinishEff4 = 0;
        int Total_FinishEff5 = 0;
        int Total_FinishEff6 = 0;
        int Total_FinishEff7 = 0;
        int Total_FinishEff8 = 0;
        int Total_FinishEff9 = 0;
        int Total_FinishEff10 = 0;
        int Total_FinishEff11 = 0;
        int Total_FinishEff12 = 0;
        int Total_FinishEff13 = 0;
        int Total_FinishEff14 = 0;
        int Total_FinishEff15 = 0;
        int Total_FinishEff16 = 0;
        int Total_FinishEff17 = 0;
        int Total_FinishEff18 = 0;
        int Total_FinishEff19 = 0;
        int Total_FinishEff20 = 0;
        int Total_FinishEff21 = 0;
        int Total_FinishEff22 = 0;
        int Total_FinishEff23 = 0;
        int Total_FinishEff24 = 0;

        int Total_StitchEff1 = 0;
        int Total_StitchEff2 = 0;
        int Total_StitchEff3 = 0;
        int Total_StitchEff4 = 0;
        int Total_StitchEff5 = 0;
        int Total_StitchEff6 = 0;
        int Total_StitchEff7 = 0;
        int Total_StitchEff8 = 0;
        int Total_StitchEff9 = 0;
        int Total_StitchEff10 = 0;
        int Total_StitchEff11 = 0;
        int Total_StitchEff12 = 0;
        int Total_StitchEff13 = 0;
        int Total_StitchEff14 = 0;
        int Total_StitchEff15 = 0;
        int Total_StitchEff16 = 0;
        int Total_StitchEff17 = 0;
        int Total_StitchEff18 = 0;
        int Total_StitchEff19 = 0;
        int Total_StitchEff20 = 0;
        int Total_StitchEff21 = 0;
        int Total_StitchEff22 = 0;
        int Total_StitchEff23 = 0;
        int Total_StitchEff24 = 0;

        int TotalBreakEvenQty = 0;
        int ActiveSlotCount = 0;

        int TargetEff_Total = 0;
        int TargetQty_Total = 0;
        int BreakEvenEff_Total = 0;
        int BreakEvenQty_Total = 0;
        int TodayEfficiency_Stitch_Total = 0;
        int TodayEfficiency_Finish_Total = 0;
        int StyleEfficiency_Stitch_Total = 0;
        int StyleEfficiency_Finish_Total = 0;           
        int FactoryTotal = 0;
        int EfficencyTotal = 0;
        double StitchSAM_Total = 0;
        double FinishSAM_Total = 0;
        int StitchActualOB_Total = 0;
        int StitchOB_Total = 0;
        int FinishActualOB_Total = 0;
        int FinishOB_Total = 0;

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

        int LineStitchedQty_Total = 0;
        int LineFinishedQty_Total = 0;
        int LineAltValue_Total = 0;
        int Line_DHU_Total = 0;

        int UnitId = -1;
        int Factory_BreakEvenQty = 0;
        int Factory_BreakEvenEff = 0;
        int WIPSTotCut = 0;
        int WIPSTotStitch = 0;
        int WIPSTotFin = 0;
        int WIPSPredayFin = 0;
        int WIPSPredayStitch = 0;
        int WIPFTotStitch = 0;
        ProductionController objProductionController = new ProductionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                GetStitchingSlotTime();
                GetStitchingHourlyReport();             
                HideStitchingUnUsedSlot();
                HideStitchingTimingUnUsedSlot();

                //GetFinishingHourlyReport();
                //HideFinishingUnUsedSlot();


            }

        }
        #region Stitching

        private void GetStitchingSlotTime()
        {
            DataSet ds;
            ds = objProductionController.GetHourlyStitchingReportUser("", -1, -1, -1, -1, -1, "SlotTime");
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
        }

        private void GetStitchingHourlyReport()
        {
            DataSet ds;   
            Stitch1EmptyMsg.Visible = false;
            lblStitch1EmptyMsg1.Text = "";
            lblStitch1EmptyMsg2.Text = "";
            ds = objProductionController.GetHourlyStitchingReportUser("", StyleId, LineNo, -1, -1, -1, "HourlyReport");                    
            gvHourlyStitchingReport1.DataSource = ds.Tables[0];
            gvHourlyStitchingReport1.DataBind();
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

        protected void gvHourlyStitchingReport1_DataBound(object sender, EventArgs e)
        {
            for (int i = gvHourlyStitchingReport1.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = gvHourlyStitchingReport1.Rows[i];
                GridViewRow previousRow = gvHourlyStitchingReport1.Rows[i - 1];
                
                    Label lblUnit = (Label)row.Cells[0].FindControl("lblUnit");
                    Label lblPreviousUnit = (Label)previousRow.Cells[0].FindControl("lblUnit");

                    if (lblUnit.Text == lblPreviousUnit.Text)
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

                //Label lblSlot24Timing = (Label)e.Row.FindControl("lblSlot24Timing");
                //lblSlot24Timing.Text = dtSlot.Rows[0]["SlotStart24"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd24"].ToString();

            }
        }

        protected void gvHourlyStitchingReport1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            //DataTable dtSlot = (DataTable)ViewState["dtSlot"];
            //if (e.Row.RowType == DataControlRowType.Header)
            //{
            //    // Changes done as per request from SAM to hide the slot timing in header Ravi Dated 17th oct 2016
            //    //Label lblSlot1Time = (Label)e.Row.FindControl("lblSlot1Time");
            //    //lblSlot1Time.Text = dtSlot.Rows[0]["SlotStart1"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd1"].ToString();

            //    //Label lblSlot2Time = (Label)e.Row.FindControl("lblSlot2Time");
            //    //lblSlot2Time.Text = dtSlot.Rows[0]["SlotStart2"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd2"].ToString();

            //    //Label lblSlot3Time = (Label)e.Row.FindControl("lblSlot3Time");
            //    //lblSlot3Time.Text = dtSlot.Rows[0]["SlotStart3"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd3"].ToString();

            //    //Label lblSlot4Time = (Label)e.Row.FindControl("lblSlot4Time");
            //    //lblSlot4Time.Text = dtSlot.Rows[0]["SlotStart4"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd4"].ToString();

            //    //Label lblSlot5Time = (Label)e.Row.FindControl("lblSlot5Time");
            //    //lblSlot5Time.Text = dtSlot.Rows[0]["SlotStart5"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd5"].ToString();

            //    //Label lblSlot6Time = (Label)e.Row.FindControl("lblSlot6Time");
            //    //lblSlot6Time.Text = dtSlot.Rows[0]["SlotStart6"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd6"].ToString();

            //    //Label lblSlot7Time = (Label)e.Row.FindControl("lblSlot7Time");
            //    //lblSlot7Time.Text = dtSlot.Rows[0]["SlotStart7"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd7"].ToString();

            //    //Label lblSlot8Time = (Label)e.Row.FindControl("lblSlot8Time");
            //    //lblSlot8Time.Text = dtSlot.Rows[0]["SlotStart8"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd8"].ToString();

            //    //Label lblSlot9Time = (Label)e.Row.FindControl("lblSlot9Time");
            //    //lblSlot9Time.Text = dtSlot.Rows[0]["SlotStart9"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd9"].ToString();

            //    //Label lblSlot10Time = (Label)e.Row.FindControl("lblSlot10Time");
            //    //lblSlot10Time.Text = dtSlot.Rows[0]["SlotStart10"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd10"].ToString();

            //    //Label lblSlot11Time = (Label)e.Row.FindControl("lblSlot11Time");
            //    //lblSlot11Time.Text = dtSlot.Rows[0]["SlotStart11"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd11"].ToString();

            //    //Label lblSlot12Time = (Label)e.Row.FindControl("lblSlot12Time");
            //    //lblSlot12Time.Text = dtSlot.Rows[0]["SlotStart12"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd12"].ToString();

            //    //Label lblSlot13Time = (Label)e.Row.FindControl("lblSlot13Time");
            //    //lblSlot13Time.Text = dtSlot.Rows[0]["SlotStart13"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd13"].ToString();

            //    //Label lblSlot14Time = (Label)e.Row.FindControl("lblSlot14Time");
            //    //lblSlot14Time.Text = dtSlot.Rows[0]["SlotStart14"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd14"].ToString();

            //    //Label lblSlot15Time = (Label)e.Row.FindControl("lblSlot15Time");
            //    //lblSlot15Time.Text = dtSlot.Rows[0]["SlotStart15"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd15"].ToString();

            //    //Label lblSlot16Time = (Label)e.Row.FindControl("lblSlot16Time");
            //    //lblSlot16Time.Text = dtSlot.Rows[0]["SlotStart16"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd16"].ToString();

            //    //Label lblSlot17Time = (Label)e.Row.FindControl("lblSlot17Time");
            //    //lblSlot17Time.Text = dtSlot.Rows[0]["SlotStart17"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd17"].ToString();

            //    //Label lblSlot18Time = (Label)e.Row.FindControl("lblSlot18Time");
            //    //lblSlot18Time.Text = dtSlot.Rows[0]["SlotStart18"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd18"].ToString();

            //    //Label lblSlot19Time = (Label)e.Row.FindControl("lblSlot19Time");
            //    //lblSlot19Time.Text = dtSlot.Rows[0]["SlotStart19"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd19"].ToString();

            //    //Label lblSlot20Time = (Label)e.Row.FindControl("lblSlot20Time");
            //    //lblSlot20Time.Text = dtSlot.Rows[0]["SlotStart20"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd20"].ToString();

            //    //Label lblSlot21Time = (Label)e.Row.FindControl("lblSlot21Time");
            //    //lblSlot21Time.Text = dtSlot.Rows[0]["SlotStart21"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd21"].ToString();

            //    //Label lblSlot22Time = (Label)e.Row.FindControl("lblSlot22Time");
            //    //lblSlot22Time.Text = dtSlot.Rows[0]["SlotStart22"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd22"].ToString();

            //    //Label lblSlot23Time = (Label)e.Row.FindControl("lblSlot23Time");
            //    //lblSlot23Time.Text = dtSlot.Rows[0]["SlotStart23"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd23"].ToString();

            //    //Label lblSlot24Time = (Label)e.Row.FindControl("lblSlot24Time");
            //    //lblSlot24Time.Text = dtSlot.Rows[0]["SlotStart24"].ToString() + "-" + dtSlot.Rows[0]["SlotEnd24"].ToString();
            //    // End of Changes done as per request from SAM to hide the slot timing in header Ravi Dated 17th oct 2016
            //}
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HtmlTableCell tdserialno = (HtmlTableCell)e.Row.FindControl("tdserialno");
                HiddenField hdnserialColorCode = (HiddenField)e.Row.FindControl("hdnserialColorCode");
                HiddenField hdnorderdeid = (HiddenField)e.Row.FindControl("hdnorderdeid");               
            
                if (hdnorderdeid.Value != "")
                {
                    DataTable dt = objProductionController.GetClientColorCode(Convert.ToInt32(hdnorderdeid.Value));
                    tdserialno.Style.Add(HtmlTextWriterStyle.BackgroundColor, dt.Rows[0]["ClientColorCode"].ToString());
                    //tdserialno.Style.Add("background-color", dt.Rows[0]["ClientColorCode"].ToString());                    
                }
                ActiveSlotCount = 0;
                int TotalZeroProductivity = 0;
                HiddenField hdnEmptyMsg = (HiddenField)e.Row.FindControl("hdnEmptyMsg");
                Label lblUnit = (Label)e.Row.FindControl("lblUnit");
                Label lblStchSAM = (Label)e.Row.FindControl("lblStchSAM");
                Label lblFinSAM = (Label)e.Row.FindControl("lblFinSAM");

                Label lblStchActOB = (Label)e.Row.FindControl("lblStchActOB");
                Label lblStchAgreedOB = (Label)e.Row.FindControl("lblStchAgreedOB");

                Label lblFinActOB = (Label)e.Row.FindControl("lblFinActOB");
                Label lblFinAgreedOB = (Label)e.Row.FindControl("lblFinAgreedOB");

                Label lblDay = (Label)e.Row.FindControl("lblDay");               
                Label lblOrderQty = (Label)e.Row.FindControl("lblOrderQty");
                Label lblPkCpty = (Label)e.Row.FindControl("lblPkCpty");
                Label lblPkOB = (Label)e.Row.FindControl("lblPkOB");
                Label lblCOT = (Label)e.Row.FindControl("lblCOT");
                Label lblPkEff = (Label)e.Row.FindControl("lblPkEff");
                // edit by ravi
                Label lblWIPStiched = (Label)e.Row.FindControl("lblWIPStiched");
                Label lblWIPFinished = (Label)e.Row.FindControl("lblWIPFinished");
                HtmlTableCell dvWipS=(HtmlTableCell)e.Row.FindControl("dvWipS");
                HtmlTableCell dvWipF = (HtmlTableCell)e.Row.FindControl("dvWipF");              

                //

                Label lblStitchQty = (Label)e.Row.FindControl("lblStitchQty");
                Label lblFinishQty = (Label)e.Row.FindControl("lblFinishQty");

                HtmlTable tblEffHide = (HtmlTable)e.Row.FindControl("tblEffHide");
                tblEffHide.Attributes.Add("class", "show-table line_td");

                HtmlTable tblEffShow = (HtmlTable)e.Row.FindControl("tblEffShow");
                tblEffShow.Attributes.Add("class", "hide-table line_td");

                UnitId = DataBinder.Eval(e.Row.DataItem, "UnitID") == DBNull.Value ? -1 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "UnitID"));

                double StitchSAM = DataBinder.Eval(e.Row.DataItem, "StitchSAM") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "StitchSAM"));
                double FinishSAM = DataBinder.Eval(e.Row.DataItem, "FinishSAM") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "FinishSAM"));
                int StitchActualOB = DataBinder.Eval(e.Row.DataItem, "StitchActualOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StitchActualOB"));
                int StitchOB = DataBinder.Eval(e.Row.DataItem, "StitchOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StitchOB"));
                int FinishActualOB = DataBinder.Eval(e.Row.DataItem, "FinishActualOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FinishActualOB"));
                int FinishOB = DataBinder.Eval(e.Row.DataItem, "FinishOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FinishOB"));
                
                int PeakCapecity = DataBinder.Eval(e.Row.DataItem, "PeakCapecity") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakCapecity"));
                int PeakOB = DataBinder.Eval(e.Row.DataItem, "PeakOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakOB"));
                int COT = DataBinder.Eval(e.Row.DataItem, "COTValue") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "COTValue"));
                // edit by ravi
                int WIPStiched = DataBinder.Eval(e.Row.DataItem, "WIPStitching") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "WIPStitching"));
                int WIPFinished = DataBinder.Eval(e.Row.DataItem, "WIPFinished") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "WIPFinished"));

                int StitchDoubleOB = DataBinder.Eval(e.Row.DataItem, "StitchDoubleOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StitchDoubleOB"));
                int FinishDoubleOB = DataBinder.Eval(e.Row.DataItem, "FinishDoubleOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "FinishDoubleOB"));

                if (WIPStiched == 0)
                    lblWIPStiched.Text = "";
                else
                    lblWIPStiched.Text = WIPStiched + " D";
                if (WIPFinished == 0)
                    lblWIPFinished.Text = "";
                else
                    lblWIPFinished.Text = WIPFinished + " D";

                if ((WIPStiched >= 0 && WIPStiched <= 2))
                {
                    dvWipS.Attributes.Add("style", "background-color:red;");
                    lblWIPStiched.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    lblWIPStiched.ForeColor = System.Drawing.Color.Black;
                    dvWipS.Attributes.Add("style", "background-color:green;");
                }
                if (WIPFinished == 0)
                {
                    dvWipF.Attributes.Add("style", "background-color:green;");
                    lblWIPFinished.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    dvWipF.Attributes.Add("style", "background-color:red;");
                    lblWIPFinished.ForeColor = System.Drawing.Color.Black;
                }
                //
                int PeakEff = DataBinder.Eval(e.Row.DataItem, "PeakEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PeakEff"));
                int StitchQty = DataBinder.Eval(e.Row.DataItem, "TotalStitchedQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalStitchedQty"));
                int FinishQty = DataBinder.Eval(e.Row.DataItem, "TotalFinishQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalFinishQty"));

                lblStitchQty.Text = StitchQty == 0 ? "" : StitchQty.ToString("#,##0");
                lblFinishQty.Text = FinishQty == 0 ? "" : FinishQty.ToString("#,##0");
                lblPkCpty.Text = PeakCapecity == 0 ? "" : PeakCapecity.ToString();
                lblPkOB.Text = PeakOB == 0 ? "" : "(" + PeakOB.ToString() + ")";
                lblCOT.Text = COT == 0 ? "" : COT.ToString();
                lblPkEff.Text = PeakEff == 0 ? "" : "(" + PeakEff.ToString() + "%)";
                lblStchSAM.Text = StitchSAM == 0 ? "" : StitchSAM.ToString();
                lblFinSAM.Text = FinishSAM == 0 ? "" : FinishSAM.ToString();
                lblStchActOB.Text = StitchActualOB == 0 ? "" : StitchActualOB.ToString();

                if(StitchDoubleOB == 1)
                    lblStchAgreedOB.Text = StitchOB == 0 ? "" : "(" + StitchOB.ToString() + " D)";
                else
                    lblStchAgreedOB.Text = StitchOB == 0 ? "" : "(" + StitchOB.ToString() + ")";

                lblFinActOB.Text = FinishActualOB == 0 ? "" : FinishActualOB.ToString();
                
                if(FinishDoubleOB == 1)
                    lblFinAgreedOB.Text = FinishOB == 0 ? "" : "(" + FinishOB.ToString() + " D)";
                else
                    lblFinAgreedOB.Text = FinishOB == 0 ? "" : "(" + FinishOB.ToString() + ")";

                if(StitchActualOB <= StitchOB)
                    lblStchActOB.Style.Add("color", "green");
                else
                    lblStchActOB.Style.Add("color", "red");

                if (FinishActualOB <= FinishOB)
                    lblFinActOB.Style.Add("color", "green");
                else
                    lblFinActOB.Style.Add("color", "red");

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
                               
               
                lblSlot1Pass.Text = lblSlot1Pass.Text == "0" ? "" :  lblSlot1Pass.Text;
                lblSlot1Pass.CssClass = "font-normal";
                lblSlot2Pass.Text = lblSlot2Pass.Text == "0" ? "" :  lblSlot2Pass.Text;
                lblSlot2Pass.CssClass = "font-normal";
                lblSlot3Pass.Text = lblSlot3Pass.Text == "0" ? "" :  lblSlot3Pass.Text;
                lblSlot3Pass.CssClass = "font-normal";
                lblSlot4Pass.Text = lblSlot4Pass.Text == "0" ? "" :  lblSlot4Pass.Text;
                lblSlot4Pass.CssClass = "font-normal";
                lblSlot5Pass.Text = lblSlot5Pass.Text == "0" ? "" :  lblSlot5Pass.Text;
                lblSlot5Pass.CssClass = "font-normal";
                lblSlot6Pass.Text = lblSlot6Pass.Text == "0" ? "" :  lblSlot6Pass.Text;
                lblSlot6Pass.CssClass = "font-normal";
                lblSlot7Pass.Text = lblSlot7Pass.Text == "0" ? "" :  lblSlot7Pass.Text;
                lblSlot7Pass.CssClass = "font-normal";
                lblSlot8Pass.Text = lblSlot8Pass.Text == "0" ? "" :  lblSlot8Pass.Text;
                lblSlot8Pass.CssClass = "font-normal";
                lblSlot9Pass.Text = lblSlot9Pass.Text == "0" ? "" :  lblSlot9Pass.Text;
                lblSlot9Pass.CssClass = "font-normal";
                lblSlot10Pass.Text = lblSlot10Pass.Text == "0" ? "" :  lblSlot10Pass.Text;
                lblSlot10Pass.CssClass = "font-normal";
                lblSlot11Pass.Text = lblSlot11Pass.Text == "0" ? "" :  lblSlot11Pass.Text;
                lblSlot11Pass.CssClass = "font-normal";
                lblSlot12Pass.Text = lblSlot12Pass.Text == "0" ? "" :  lblSlot12Pass.Text;
                lblSlot12Pass.CssClass = "font-normal";
                lblSlot13Pass.Text = lblSlot13Pass.Text == "0" ? "" :  lblSlot13Pass.Text;
                lblSlot13Pass.CssClass = "font-normal";
                lblSlot14Pass.Text = lblSlot14Pass.Text == "0" ? "" :  lblSlot14Pass.Text;
                lblSlot14Pass.CssClass = "font-normal";
                lblSlot15Pass.Text = lblSlot15Pass.Text == "0" ? "" :  lblSlot15Pass.Text;
                lblSlot15Pass.CssClass = "font-normal";
                lblSlot16Pass.Text = lblSlot16Pass.Text == "0" ? "" :  lblSlot16Pass.Text;
                lblSlot16Pass.CssClass = "font-normal";
                lblSlot17Pass.Text = lblSlot17Pass.Text == "0" ? "" :  lblSlot17Pass.Text;
                lblSlot17Pass.CssClass = "font-normal";
                lblSlot18Pass.Text = lblSlot18Pass.Text == "0" ? "" :  lblSlot18Pass.Text;
                lblSlot18Pass.CssClass = "font-normal";
                lblSlot19Pass.Text = lblSlot19Pass.Text == "0" ? "" :  lblSlot19Pass.Text;
                lblSlot19Pass.CssClass = "font-normal";
                lblSlot20Pass.Text = lblSlot20Pass.Text == "0" ? "" :  lblSlot20Pass.Text;
                lblSlot20Pass.CssClass = "font-normal";
                lblSlot21Pass.Text = lblSlot21Pass.Text == "0" ? "" :  lblSlot21Pass.Text;
                lblSlot21Pass.CssClass = "font-normal";
                lblSlot22Pass.Text = lblSlot22Pass.Text == "0" ? "" :  lblSlot22Pass.Text;
                lblSlot22Pass.CssClass = "font-normal";
                lblSlot23Pass.Text = lblSlot23Pass.Text == "0" ? "" :  lblSlot23Pass.Text;
                lblSlot23Pass.CssClass = "font-normal";
                lblSlot24Pass.Text = lblSlot24Pass.Text == "0" ? "" :  lblSlot24Pass.Text;
                lblSlot24Pass.CssClass = "font-normal";

               

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

                // Today Qty
                Label lblTodayPassFinish = (Label)e.Row.FindControl("lblTodayPassFinish");
                Label lblTodayPassStitch = (Label)e.Row.FindControl("lblTodayPassStitch");
                Label lblTodayAltPcs = (Label)e.Row.FindControl("lblTodayAltPcs");
                Label lblTodayDHU = (Label)e.Row.FindControl("lblTodayDHU");

                int TodayPassFinish = DataBinder.Eval(e.Row.DataItem, "TodayPassPcsFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayPassPcsFinish"));
                int TodayPassPcsStitch = DataBinder.Eval(e.Row.DataItem, "TodayPassPcsStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayPassPcsStitch"));
                int TodayAltPcs = DataBinder.Eval(e.Row.DataItem, "TodayAltPcs") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayAltPcs"));
                int TodayDHU = DataBinder.Eval(e.Row.DataItem, "DHU_Today") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "DHU_Today"));


                lblTodayPassFinish.Text = TodayPassFinish == 0 ? "" : "[" + TodayPassFinish.ToString() + "]";
                lblTodayPassStitch.Text = TodayPassPcsStitch == 0 ? "" : TodayPassPcsStitch.ToString();
                lblTodayAltPcs.Text = TodayAltPcs == 0 ? "" : TodayAltPcs.ToString();
                lblTodayDHU.Text = TodayDHU == 0 ? "" : "(" + TodayDHU.ToString() + "%)";


                // Line Qty
                Label lblLineFinishQty = (Label)e.Row.FindControl("lblLineFinishQty");
                Label lblLineStitchQty = (Label)e.Row.FindControl("lblLineStitchQty");
                Label lblLineAltVal = (Label)e.Row.FindControl("lblLineAltVal");
                Label lblLineDHU = (Label)e.Row.FindControl("lblLineDHU");

                int LineFinishedQty = DataBinder.Eval(e.Row.DataItem, "LineFinishedQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LineFinishedQty"));
                int LineStitchedQty = DataBinder.Eval(e.Row.DataItem, "LineStitchedQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LineStitchedQty"));
                int LineAltValue = DataBinder.Eval(e.Row.DataItem, "LineAltValue") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LineAltValue"));
                int Line_DHU = DataBinder.Eval(e.Row.DataItem, "Line_DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Line_DHU"));

                if (LineFinishedQty != 0)
                    lblLineFinishQty.Text = Math.Round(Convert.ToDouble(LineFinishedQty) / 1000, 1) == 0 ? "" : "[" + Math.Round(Convert.ToDouble(LineFinishedQty) / 1000, 1).ToString() + "k" + "]";
                else
                    lblLineFinishQty.Text = "";

                if (LineStitchedQty != 0)
                    lblLineStitchQty.Text = Math.Round(Convert.ToDouble(LineStitchedQty) / 1000, 1) == 0 ? "" : Math.Round(Convert.ToDouble(LineStitchedQty) / 1000, 1).ToString() + "k";
                else
                    lblLineStitchQty.Text = "";


                lblLineAltVal.Text = LineAltValue == 0 ? "" : LineAltValue.ToString();
                lblLineDHU.Text = Line_DHU == 0 ? "" : "(" + Line_DHU.ToString() + "%)";               
                               
                
                int BreakEvenEff = 0;
                int TargetEff = 0;
                int TodayEfficiency_Finish = 0;
                int TodayEfficiency_Stitch = 0;
                int StyleEfficiency_Finish = 0;
                int StyleEfficiency_Stitch = 0;                
                HtmlTableCell tdTodayEff = (HtmlTableCell)e.Row.FindControl("tdTodayEff");

                TargetEff = DataBinder.Eval(e.Row.DataItem, "TargetEfficiency") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetEfficiency"));
                BreakEvenEff = DataBinder.Eval(e.Row.DataItem, "BreakEvenEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BreakEvenEff"));
                TodayEfficiency_Finish = DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Finish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Finish"));
                TodayEfficiency_Stitch = DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Stitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Stitch"));
                StyleEfficiency_Finish = DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Finish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Finish"));
                StyleEfficiency_Stitch = DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Stitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Stitch"));

                // changed by ravi dated 14 oct
                if (TodayEfficiency_Stitch >= BreakEvenEff)
                    tdTodayEff.Style.Add("color", "green");
                else
                    tdTodayEff.Style.Add("color", "#FF0000");

                Label lblBreakEvenEff = (Label)e.Row.FindControl("lblBreakEvenEff");
                Label lblTargetEff = (Label)e.Row.FindControl("lblTargetEff");
                Label lblTodayEff_Finish = (Label)e.Row.FindControl("lblTodayEff_Finish");
                Label lblTodayEff_Stitch = (Label)e.Row.FindControl("lblTodayEff_Stitch");

                Label lblStyleEff_Finish = (Label)e.Row.FindControl("lblStyleEff_Finish");
                Label lblStyleEff_Stitch = (Label)e.Row.FindControl("lblStyleEff_Stitch");

                Label lblTotalDHU = (Label)e.Row.FindControl("lblTotalDHU");

                lblTargetEff.Text = TargetEff > 0 ? lblTargetEff.Text + "%" : "";
                lblBreakEvenEff.Text = BreakEvenEff > 0 ? lblBreakEvenEff.Text + "%" : "";

                lblTodayEff_Finish.Text = TodayEfficiency_Finish > 0 ? "[" + TodayEfficiency_Finish + "%]" : "";
                lblTodayEff_Stitch.Text = TodayEfficiency_Stitch > 0 ? TodayEfficiency_Stitch + "%" : "";

                lblStyleEff_Finish.Text = StyleEfficiency_Finish > 0 ? "[" + StyleEfficiency_Finish + "%]" : "";
                lblStyleEff_Stitch.Text = StyleEfficiency_Stitch > 0 ? StyleEfficiency_Stitch + "%" : "";              
              

                int BreakEvenQty = 0;
                             
                BreakEvenQty = DataBinder.Eval(e.Row.DataItem, "BreakEvenQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BreakEvenQty"));
                
                if (BreakEvenQty > 0)
                {
                    HtmlTableCell tdSlot1Pass = (HtmlTableCell)e.Row.FindControl("tdSlot1Pass");
                    Slot1 = DataBinder.Eval(e.Row.DataItem, "Slot1Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1Pass"));
                    if (Slot1 >= BreakEvenQty)
                        tdSlot1Pass.Style.Add("background-color", "green");
                    else
                        tdSlot1Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot2Pass = (HtmlTableCell)e.Row.FindControl("tdSlot2Pass");
                    Slot2 = DataBinder.Eval(e.Row.DataItem, "Slot2Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2Pass"));
                    if (Slot2 >= BreakEvenQty)
                        tdSlot2Pass.Style.Add("background-color", "green");
                    else
                        tdSlot2Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot3Pass = (HtmlTableCell)e.Row.FindControl("tdSlot3Pass");
                    Slot3 = DataBinder.Eval(e.Row.DataItem, "Slot3Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3Pass"));
                    if (Slot3 >= BreakEvenQty)
                        tdSlot3Pass.Style.Add("background-color", "green");
                    else
                        tdSlot3Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot4Pass = (HtmlTableCell)e.Row.FindControl("tdSlot4Pass");
                    Slot4 = DataBinder.Eval(e.Row.DataItem, "Slot4Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4Pass"));
                    if (Slot4 >= BreakEvenQty)
                        tdSlot4Pass.Style.Add("background-color", "green");
                    else
                        tdSlot4Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot5Pass = (HtmlTableCell)e.Row.FindControl("tdSlot5Pass");
                    Slot5 = DataBinder.Eval(e.Row.DataItem, "Slot5Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5Pass"));
                    if (Slot5 >= BreakEvenQty)
                        tdSlot5Pass.Style.Add("background-color", "green");
                    else
                        tdSlot5Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot6Pass = (HtmlTableCell)e.Row.FindControl("tdSlot6Pass");
                    Slot6 = DataBinder.Eval(e.Row.DataItem, "Slot6Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6Pass"));
                    if (Slot6 >= BreakEvenQty)
                        tdSlot6Pass.Style.Add("background-color", "green");
                    else
                        tdSlot6Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot7Pass = (HtmlTableCell)e.Row.FindControl("tdSlot7Pass");
                    Slot7 = DataBinder.Eval(e.Row.DataItem, "Slot7Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7Pass"));
                    if (Slot7 >= BreakEvenQty)
                        tdSlot7Pass.Style.Add("background-color", "green");
                    else
                        tdSlot7Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot8Pass = (HtmlTableCell)e.Row.FindControl("tdSlot8Pass");
                    Slot8 = DataBinder.Eval(e.Row.DataItem, "Slot8Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8Pass"));
                    if (Slot8 >= BreakEvenQty)
                        tdSlot8Pass.Style.Add("background-color", "green");
                    else
                        tdSlot8Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot9Pass = (HtmlTableCell)e.Row.FindControl("tdSlot9Pass");
                    Slot9 = DataBinder.Eval(e.Row.DataItem, "Slot9Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9Pass"));
                    if (Slot9 >= BreakEvenQty)
                        tdSlot9Pass.Style.Add("background-color", "green");
                    else
                        tdSlot9Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot10Pass = (HtmlTableCell)e.Row.FindControl("tdSlot10Pass");
                    Slot10 = DataBinder.Eval(e.Row.DataItem, "Slot10Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10Pass"));
                    if (Slot10 >= BreakEvenQty)
                        tdSlot10Pass.Style.Add("background-color", "green");
                    else
                        tdSlot10Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot11Pass = (HtmlTableCell)e.Row.FindControl("tdSlot11Pass");
                    Slot11 = DataBinder.Eval(e.Row.DataItem, "Slot11Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11Pass"));
                    if (Slot11 >= BreakEvenQty)
                        tdSlot11Pass.Style.Add("background-color", "green");
                    else
                        tdSlot11Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot12Pass = (HtmlTableCell)e.Row.FindControl("tdSlot12Pass");
                    Slot12 = DataBinder.Eval(e.Row.DataItem, "Slot12Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12Pass"));
                    if (Slot12 >= BreakEvenQty)
                        tdSlot12Pass.Style.Add("background-color", "green");
                    else
                        tdSlot12Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot13Pass = (HtmlTableCell)e.Row.FindControl("tdSlot13Pass");
                    Slot13 = DataBinder.Eval(e.Row.DataItem, "Slot13Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13Pass"));
                    if (Slot13 >= BreakEvenQty)
                        tdSlot13Pass.Style.Add("background-color", "green");
                    else
                        tdSlot13Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot14Pass = (HtmlTableCell)e.Row.FindControl("tdSlot14Pass");
                    Slot14 = DataBinder.Eval(e.Row.DataItem, "Slot14Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14Pass"));
                    if (Slot14 >= BreakEvenQty)
                        tdSlot14Pass.Style.Add("background-color", "green");
                    else
                        tdSlot14Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot15Pass = (HtmlTableCell)e.Row.FindControl("tdSlot15Pass");
                    Slot15 = DataBinder.Eval(e.Row.DataItem, "Slot15Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15Pass"));
                    if (Slot15 >= BreakEvenQty)
                        tdSlot15Pass.Style.Add("background-color", "green");
                    else
                        tdSlot15Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot16Pass = (HtmlTableCell)e.Row.FindControl("tdSlot16Pass");
                    Slot16 = DataBinder.Eval(e.Row.DataItem, "Slot16Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16Pass"));
                    if (Slot16 >= BreakEvenQty)
                        tdSlot16Pass.Style.Add("background-color", "green");
                    else
                        tdSlot16Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot17Pass = (HtmlTableCell)e.Row.FindControl("tdSlot17Pass");
                    Slot17 = DataBinder.Eval(e.Row.DataItem, "Slot17Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17Pass"));
                    if (Slot17 >= BreakEvenQty)
                        tdSlot17Pass.Style.Add("background-color", "green");
                    else
                        tdSlot17Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot18Pass = (HtmlTableCell)e.Row.FindControl("tdSlot18Pass");
                    Slot18 = DataBinder.Eval(e.Row.DataItem, "Slot18Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18Pass"));
                    if (Slot18 >= BreakEvenQty)
                        tdSlot18Pass.Style.Add("background-color", "green");
                    else
                        tdSlot18Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot19Pass = (HtmlTableCell)e.Row.FindControl("tdSlot19Pass");
                    Slot19 = DataBinder.Eval(e.Row.DataItem, "Slot19Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19Pass"));
                    if (Slot19 >= BreakEvenQty)
                        tdSlot19Pass.Style.Add("background-color", "green");
                    else
                        tdSlot19Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot20Pass = (HtmlTableCell)e.Row.FindControl("tdSlot20Pass");
                    Slot20 = DataBinder.Eval(e.Row.DataItem, "Slot20Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20Pass"));
                    if (Slot20 >= BreakEvenQty)
                        tdSlot20Pass.Style.Add("background-color", "green");
                    else
                        tdSlot20Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot21Pass = (HtmlTableCell)e.Row.FindControl("tdSlot21Pass");
                    Slot21 = DataBinder.Eval(e.Row.DataItem, "Slot21Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21Pass"));
                    if (Slot21 >= BreakEvenQty)
                        tdSlot21Pass.Style.Add("background-color", "green");
                    else
                        tdSlot21Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot22Pass = (HtmlTableCell)e.Row.FindControl("tdSlot22Pass");
                    Slot22 = DataBinder.Eval(e.Row.DataItem, "Slot22Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22Pass"));
                    if (Slot22 >= BreakEvenQty)
                        tdSlot22Pass.Style.Add("background-color", "green");
                    else
                        tdSlot22Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot23Pass = (HtmlTableCell)e.Row.FindControl("tdSlot23Pass");
                    Slot23 = DataBinder.Eval(e.Row.DataItem, "Slot23Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23Pass"));
                    if (Slot23 >= BreakEvenQty)
                        tdSlot23Pass.Style.Add("background-color", "green");
                    else
                        tdSlot23Pass.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot24Pass = (HtmlTableCell)e.Row.FindControl("tdSlot24Pass");
                    Slot24 = DataBinder.Eval(e.Row.DataItem, "Slot24Pass") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24Pass"));
                    if (Slot24 >= BreakEvenQty)
                        tdSlot24Pass.Style.Add("background-color", "green");
                    else
                        tdSlot24Pass.Style.Add("background-color", "#FF0000");
                }

                TotalZeroProductivity = 0;//DataBinder.Eval(e.Row.DataItem, "TotalZeroProductivityPcs") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalZeroProductivityPcs"));

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
                    HtmlTableCell tdTotalPass = (HtmlTableCell)e.Row.FindControl("tdTotalPass");
                    if (lblTodayPassFinish.Text != "")
                    {
                        int TotalPassThis = Convert.ToInt32(lblTodayPassFinish.Text.Replace("[","").Replace("]",""));
                        if (TotalPassThis >= TotalBreakEvenQtyThis)
                            tdTotalPass.Style.Add("color", "green");
                        else
                            tdTotalPass.Style.Add("color", "#FF0000");
                    }
              

                if (hdnEmptyMsg.Value != DBNull.Value.ToString())
                {                    
                    HtmlTable tblEmptyMsg = (HtmlTable)e.Row.FindControl("tblEmptyMsg");
                    tblEmptyMsg.Visible = true;
                    HtmlTable tblLinePlan = (HtmlTable)e.Row.FindControl("tblLinePlan");
                    tblLinePlan.Visible = false;
                   
                    e.Row.Cells[1].ColumnSpan = 36;
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
                    e.Row.Cells[36].Visible = false;
                    e.Row.Cells[37].Visible = false; 
                }
                if ((lblUnit.Text == "")&&(UnitId != 0))
                {                  
                    e.Row.Cells[0].ColumnSpan = 2;                    
                    e.Row.Cells[1].Visible = false;
                    e.Row.Attributes.Add("class", "yellowFactory");
                    e.Row.Cells[32].ColumnSpan = 6;
                    e.Row.Cells[32].CssClass = "ROWMERGE";
                    e.Row.Cells[33].Visible = false;
                    e.Row.Cells[34].Visible = false;
                    e.Row.Cells[35].Visible = false;
                    e.Row.Cells[36].Visible = false;
                    e.Row.Cells[37].Visible = false;         
                  
                    Label lblUnitTotal = (Label)e.Row.FindControl("lblUnitTotal");
                    lblUnitTotal.Text = "Factory Total";
                                    
                  
                   
                    TotalBreakEvenQty += DataBinder.Eval(e.Row.DataItem, "BreakEvenQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BreakEvenQty"));

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


                    Total_PassFinish1 += DataBinder.Eval(e.Row.DataItem, "Slot1PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1PassFinish"));
                    Total_PassFinish2 += DataBinder.Eval(e.Row.DataItem, "Slot2PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2PassFinish"));
                    Total_PassFinish3 += DataBinder.Eval(e.Row.DataItem, "Slot3PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3PassFinish"));
                    Total_PassFinish4 += DataBinder.Eval(e.Row.DataItem, "Slot4PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4PassFinish"));
                    Total_PassFinish5 += DataBinder.Eval(e.Row.DataItem, "Slot5PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5PassFinish"));
                    Total_PassFinish6 += DataBinder.Eval(e.Row.DataItem, "Slot6PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6PassFinish"));
                    Total_PassFinish7 += DataBinder.Eval(e.Row.DataItem, "Slot7PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7PassFinish"));
                    Total_PassFinish8 += DataBinder.Eval(e.Row.DataItem, "Slot8PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8PassFinish"));
                    Total_PassFinish9 += DataBinder.Eval(e.Row.DataItem, "Slot9PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9PassFinish"));
                    Total_PassFinish10 += DataBinder.Eval(e.Row.DataItem, "Slot10PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10PassFinish"));
                    Total_PassFinish11 += DataBinder.Eval(e.Row.DataItem, "Slot11PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11PassFinish"));
                    Total_PassFinish12 += DataBinder.Eval(e.Row.DataItem, "Slot12PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12PassFinish"));
                    Total_PassFinish13 += DataBinder.Eval(e.Row.DataItem, "Slot13PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13PassFinish"));
                    Total_PassFinish14 += DataBinder.Eval(e.Row.DataItem, "Slot14PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14PassFinish"));
                    Total_PassFinish15 += DataBinder.Eval(e.Row.DataItem, "Slot15PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15PassFinish"));
                    Total_PassFinish16 += DataBinder.Eval(e.Row.DataItem, "Slot16PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16PassFinish"));
                    Total_PassFinish17 += DataBinder.Eval(e.Row.DataItem, "Slot17PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17PassFinish"));
                    Total_PassFinish18 += DataBinder.Eval(e.Row.DataItem, "Slot18PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18PassFinish"));
                    Total_PassFinish19 += DataBinder.Eval(e.Row.DataItem, "Slot19PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19PassFinish"));
                    Total_PassFinish20 += DataBinder.Eval(e.Row.DataItem, "Slot20PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20PassFinish"));
                    Total_PassFinish21 += DataBinder.Eval(e.Row.DataItem, "Slot21PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21PassFinish"));
                    Total_PassFinish22 += DataBinder.Eval(e.Row.DataItem, "Slot22PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22PassFinish"));
                    Total_PassFinish23 += DataBinder.Eval(e.Row.DataItem, "Slot23PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23PassFinish"));
                    Total_PassFinish24 += DataBinder.Eval(e.Row.DataItem, "Slot24PassFinish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24PassFinish"));


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



                    StitchSAM_Total += DataBinder.Eval(e.Row.DataItem, "StitchSAM") == DBNull.Value ? 0 : Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "StitchSAM"));                  
                    StitchActualOB_Total += DataBinder.Eval(e.Row.DataItem, "StitchActualOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StitchActualOB"));
                    StitchOB_Total += DataBinder.Eval(e.Row.DataItem, "StitchOB") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StitchOB"));

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

                    TargetEff_Total += DataBinder.Eval(e.Row.DataItem, "TargetEfficiency") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetEfficiency"));
                    TargetQty_Total += DataBinder.Eval(e.Row.DataItem, "TargetQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TargetQty"));
                    BreakEvenEff_Total += DataBinder.Eval(e.Row.DataItem, "BreakEvenEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BreakEvenEff"));
                    BreakEvenQty_Total += DataBinder.Eval(e.Row.DataItem, "BreakEvenQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BreakEvenQty"));

                    TodayEfficiency_Finish_Total += DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Finish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Finish"));
                    TodayEfficiency_Stitch_Total += DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Stitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TodayEfficiency_Stitch"));
                    StyleEfficiency_Finish_Total += DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Finish") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Finish"));
                    StyleEfficiency_Stitch_Total += DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Stitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "StyleEfficiency_Stitch"));

                    LineStitchedQty_Total += DataBinder.Eval(e.Row.DataItem, "LineStitchedQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LineStitchedQty"));
                    LineFinishedQty_Total += DataBinder.Eval(e.Row.DataItem, "LineFinishedQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LineFinishedQty"));
                    LineAltValue_Total += DataBinder.Eval(e.Row.DataItem, "LineAltValue") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "LineAltValue"));
                    Line_DHU_Total += DataBinder.Eval(e.Row.DataItem, "Line_DHU") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Line_DHU"));                    

                    Factory_BreakEvenQty = DataBinder.Eval(e.Row.DataItem, "BreakEvenQty") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BreakEvenQty"));
                    Factory_BreakEvenEff = DataBinder.Eval(e.Row.DataItem, "BreakEvenEff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "BreakEvenEff"));
                    
                    if (Slot1 >= Factory_BreakEvenQty)                   
                        lblSlot1Pass.Style.Add("color", "green"); 
                    else                    
                        lblSlot1Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot2 >= Factory_BreakEvenQty)
                        lblSlot2Pass.Style.Add("color", "green");                        
                    else                   
                        lblSlot2Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot3 >= Factory_BreakEvenQty)
                        lblSlot3Pass.Style.Add("color", "green");                        
                    else                
                        lblSlot3Pass.Style.Add("color", "#FF0000");
                      
                    if (Slot4 >= Factory_BreakEvenQty)                
                        lblSlot4Pass.Style.Add("color", "green");                       
                    else                 
                        lblSlot4Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot5 >= Factory_BreakEvenQty)                  
                        lblSlot5Pass.Style.Add("color", "green");                       
                    else                  
                        lblSlot5Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot6 >= Factory_BreakEvenQty)                  
                        lblSlot6Pass.Style.Add("color", "green");                        
                    else                   
                        lblSlot6Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot7 >= Factory_BreakEvenQty)                   
                        lblSlot7Pass.Style.Add("color", "green");                        
                    else                   
                        lblSlot7Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot8 >= Factory_BreakEvenQty)                 
                        lblSlot8Pass.Style.Add("color", "green");                   
                    else                  
                        lblSlot8Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot9 >= Factory_BreakEvenQty)                  
                        lblSlot9Pass.Style.Add("color", "green");                       
                    else                
                        lblSlot9Pass.Style.Add("color", "#FF0000");
                     
                    if (Slot10 >= Factory_BreakEvenQty)                
                        lblSlot10Pass.Style.Add("color", "green");                       
                    else                  
                        lblSlot10Pass.Style.Add("color", "#FF0000");
                      
                    if (Slot11 >= Factory_BreakEvenQty)                  
                        lblSlot11Pass.Style.Add("color", "green");                        
                    else                
                        lblSlot11Pass.Style.Add("color", "#FF0000");
                      
                    if (Slot12 >= Factory_BreakEvenQty)                
                        lblSlot12Pass.Style.Add("color", "green");                        
                    else                 
                        lblSlot12Pass.Style.Add("color", "#FF0000");
                      
                    if (Slot13 >= Factory_BreakEvenQty)                   
                        lblSlot13Pass.Style.Add("color", "green");                      
                    else                  
                        lblSlot13Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot14 >= Factory_BreakEvenQty)                  
                        lblSlot14Pass.Style.Add("color", "green");                      
                    else                  
                        lblSlot14Pass.Style.Add("color", "#FF0000");
                      
                    if (Slot15 >= Factory_BreakEvenQty)                   
                        lblSlot15Pass.Style.Add("color", "green");                      
                    else                
                        lblSlot15Pass.Style.Add("color", "#FF0000");
                      
                    if (Slot16 >= Factory_BreakEvenQty)                   
                        lblSlot16Pass.Style.Add("color", "green");                       
                    else                
                        lblSlot16Pass.Style.Add("color", "#FF0000");
                     
                    if (Slot17 >= Factory_BreakEvenQty)                  
                        lblSlot17Pass.Style.Add("color", "green");                       
                    else                 
                        lblSlot17Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot18 >= Factory_BreakEvenQty)                  
                        lblSlot18Pass.Style.Add("color", "green");                       
                    else                  
                        lblSlot18Pass.Style.Add("color", "#FF0000");
                     
                    if (Slot19 >= Factory_BreakEvenQty)                   
                        lblSlot19Pass.Style.Add("color", "green");                       
                    else                  
                        lblSlot19Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot20 >= Factory_BreakEvenQty)                 
                        lblSlot20Pass.Style.Add("color", "green");                     
                    else                  
                        lblSlot20Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot21 >= Factory_BreakEvenQty)                  
                        lblSlot21Pass.Style.Add("color", "green");                        
                    else                  
                        lblSlot21Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot22 >= Factory_BreakEvenQty)                  
                        lblSlot22Pass.Style.Add("color", "green");                       
                    else                   
                        lblSlot22Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot23 >= Factory_BreakEvenQty)                
                        lblSlot23Pass.Style.Add("color", "green");                      
                    else            
                        lblSlot23Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot24 >= Factory_BreakEvenQty)                  
                        lblSlot24Pass.Style.Add("color", "green");                       
                    else                   
                        lblSlot24Pass.Style.Add("color", "#FF0000");                       

                    //dvWipS.Attributes.Add("style", "background-color:white;");
                    //dvWipF.Attributes.Add("style", "background-color:white;");

                    FactoryTotal = FactoryTotal + 1;
                }
                if ((hdnEmptyMsg.Value == DBNull.Value.ToString()) && (lblUnit.Text != ""))
                {                   
                    int OrderDetailId = -1;
                    int LinePlanningId = -1;
                    int ProductionUnit = -1;
                    HtmlTable tblEmptyMsg = (HtmlTable)e.Row.FindControl("tblEmptyMsg");
                    tblEmptyMsg.Visible = false;
                    HtmlTable tblLinePlan = (HtmlTable)e.Row.FindControl("tblLinePlan");
                    tblLinePlan.Visible = true;

                    HiddenField hdnStyleId = (HiddenField)e.Row.FindControl("hdnStyleId");
                    HiddenField hdnLineNo = (HiddenField)e.Row.FindControl("hdnLineNo");
                    HiddenField hdnOrderDetailId = (HiddenField)e.Row.FindControl("hdnOrderDetailId");
                    HiddenField hdnLinePlanningId = (HiddenField)e.Row.FindControl("hdnLinePlanningId");
                    HiddenField hdnUnitId = (HiddenField)e.Row.FindControl("hdnUnitId");
                    HtmlTableCell tdUpcomingStyle = (HtmlTableCell)e.Row.FindControl("tdUpcomingStyle");

                    if (hdnStyleId.Value != DBNull.Value.ToString())
                        StyleId = Convert.ToInt32(hdnStyleId.Value);
                    if (hdnLineNo.Value != DBNull.Value.ToString())
                        LineNo = Convert.ToInt32(hdnLineNo.Value);
                    if (hdnOrderDetailId.Value != DBNull.Value.ToString())
                        OrderDetailId = Convert.ToInt32(hdnOrderDetailId.Value);
                    if (hdnLinePlanningId.Value != DBNull.Value.ToString())
                        LinePlanningId = Convert.ToInt32(hdnLinePlanningId.Value);
                    if (hdnUnitId.Value != DBNull.Value.ToString())
                        ProductionUnit = Convert.ToInt32(hdnUnitId.Value);

                    DataSet ds;
                    ds = objProductionController.GetHourlyStitchingReportUser(lblUnit.Text, StyleId, LineNo, OrderDetailId, LinePlanningId, ProductionUnit, "LinePlanning");
                    DataList dlstLineDesignation = e.Row.FindControl("dlstLineDesignation") as DataList;
                    dlstLineDesignation.DataSource = ds.Tables[0];
                    dlstLineDesignation.DataBind();
                    // edit by surendra on 28-june-2016 add for upcomming style details
                    Label lblUpcommingStyle = e.Row.FindControl("lblUpcommingStyle") as Label;
                    if (Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UpCommingStyle")).ToString().Trim() != "")
                    {
                        lblUpcommingStyle.Text = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "UpCommingStyle")).ToString();
                    }
                    else
                    {
                        tdUpcomingStyle.Style.Add("background-color", "#FF0000");
                        lblUpcommingStyle.Text = "Planning Missing";
                        lblUpcommingStyle.Style.Add("color", "white");
                    }
                    //
                    DataSet dsInspection;
                    dsInspection = objProductionController.GetHourlyStitchingReportUser(lblUnit.Text, StyleId, LineNo, OrderDetailId, LinePlanningId, ProductionUnit, "Inspection");
                    DataList dlstInspection = e.Row.FindControl("dlstInspection") as DataList;
                    dlstInspection.DataSource = dsInspection.Tables[0];
                    dlstInspection.DataBind();

                    DataSet dsFaults;
                    dsFaults = objProductionController.GetHourlyStitchingReportUser(lblUnit.Text, StyleId, LineNo, OrderDetailId, LinePlanningId, ProductionUnit, "Faults");
                    DataList dlstFaults = e.Row.FindControl("dlstFaults") as DataList;
                    dlstFaults.DataSource = dsFaults.Tables[0];
                    dlstFaults.DataBind();

                    DataSet dsProductionPlan;
                    dsProductionPlan = objProductionController.GetHourlyStitchingReportUser(lblUnit.Text, StyleId, LineNo, OrderDetailId, LinePlanningId, ProductionUnit, "ProductionPlan");
                    Repeater rptPlanning = e.Row.FindControl("rptPlanning") as Repeater;
                    rptPlanning.DataSource = dsProductionPlan.Tables[0];
                    rptPlanning.DataBind();

                    Repeater rptPlanningDelay = e.Row.FindControl("rptPlanningDelay") as Repeater;
                    rptPlanningDelay.DataSource = dsProductionPlan.Tables[0];
                    rptPlanningDelay.DataBind();

                    WIPSTotCut += DataBinder.Eval(e.Row.DataItem, "WIPSTotCut") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "WIPSTotCut"));
                    WIPSTotStitch += DataBinder.Eval(e.Row.DataItem, "WIPSTotStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "WIPSTotStitch"));
                    WIPSTotFin += DataBinder.Eval(e.Row.DataItem, "WIPSTotFin") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "WIPSTotFin"));
                    WIPSPredayFin += DataBinder.Eval(e.Row.DataItem, "WIPSPredayFin") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "WIPSPredayFin"));
                    WIPSPredayStitch += DataBinder.Eval(e.Row.DataItem, "WIPSPredayStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "WIPSPredayStitch"));
                    WIPFTotStitch += DataBinder.Eval(e.Row.DataItem, "WIPFTotStitch") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "WIPFTotStitch"));
                                       
              
                }

                if (UnitId == 0)
                {
                    e.Row.Cells[0].ColumnSpan = 2;
                    e.Row.Cells[1].Visible = false;
                    e.Row.Attributes.Add("class", "yellowFactory");

                    e.Row.Cells[2].ColumnSpan = 3;
                    e.Row.Cells[3].Visible = false;
                    e.Row.Cells[4].Visible = false;
                    //e.Row.Cells[5].Visible = false;

                    HtmlTable tblEffHide1 = (HtmlTable)e.Row.FindControl("tblEffHide");
                    tblEffHide1.Attributes.Add("class", "hide-table line_td");                    

                    HtmlTable tblEffShow1 = (HtmlTable)e.Row.FindControl("tblEffShow");
                    tblEffShow1.Attributes.Add("class", "show-table line_td");

                    Label lblEfficiency = (Label)e.Row.FindControl("lblEfficiency");
                    lblEfficiency.Text = "Efficiency";

                    e.Row.Cells[29].ColumnSpan = 9;
                    e.Row.Cells[29].CssClass = "ROWMERGE";
                    e.Row.Cells[30].Visible = false;
                    e.Row.Cells[31].Visible = false;
                    e.Row.Cells[32].Visible = false;
                    e.Row.Cells[33].Visible = false;
                    e.Row.Cells[34].Visible = false;
                    e.Row.Cells[35].Visible = false;
                    e.Row.Cells[36].Visible = false;
                    e.Row.Cells[37].Visible = false;

                    HtmlTableRow tr1 = (HtmlTableRow)e.Row.FindControl("tr1");
                    HtmlTableRow tr2 = (HtmlTableRow)e.Row.FindControl("tr2");
                    HtmlTableRow tr3 = (HtmlTableRow)e.Row.FindControl("tr3");
                    HtmlTableRow tr4 = (HtmlTableRow)e.Row.FindControl("tr4");
                    HtmlTableRow tr5 = (HtmlTableRow)e.Row.FindControl("tr5");
                    HtmlTableRow tr6 = (HtmlTableRow)e.Row.FindControl("tr6");
                    HtmlTableRow tr7 = (HtmlTableRow)e.Row.FindControl("tr7");
                    HtmlTableRow tr8 = (HtmlTableRow)e.Row.FindControl("tr8");
                    HtmlTableRow tr9 = (HtmlTableRow)e.Row.FindControl("tr9");
                    HtmlTableRow tr10 = (HtmlTableRow)e.Row.FindControl("tr10");
                    HtmlTableRow tr11 = (HtmlTableRow)e.Row.FindControl("tr11");
                    HtmlTableRow tr12 = (HtmlTableRow)e.Row.FindControl("tr12");
                    HtmlTableRow tr13 = (HtmlTableRow)e.Row.FindControl("tr13");
                    HtmlTableRow tr14 = (HtmlTableRow)e.Row.FindControl("tr14");
                    HtmlTableRow tr15 = (HtmlTableRow)e.Row.FindControl("tr15");
                    HtmlTableRow tr16 = (HtmlTableRow)e.Row.FindControl("tr16");
                    HtmlTableRow tr17 = (HtmlTableRow)e.Row.FindControl("tr17");
                    HtmlTableRow tr18 = (HtmlTableRow)e.Row.FindControl("tr18");
                    HtmlTableRow tr19 = (HtmlTableRow)e.Row.FindControl("tr19");
                    HtmlTableRow tr20 = (HtmlTableRow)e.Row.FindControl("tr20");
                    HtmlTableRow tr21 = (HtmlTableRow)e.Row.FindControl("tr21");
                    HtmlTableRow tr22 = (HtmlTableRow)e.Row.FindControl("tr22");
                    HtmlTableRow tr23 = (HtmlTableRow)e.Row.FindControl("tr23");
                    HtmlTableRow tr24 = (HtmlTableRow)e.Row.FindControl("tr24");
                    HtmlTableRow trTotal = (HtmlTableRow)e.Row.FindControl("trTotal");  
                    tr1.Visible = false;
                    tr2.Visible = false;
                    tr3.Visible = false;
                    tr4.Visible = false;
                    tr5.Visible = false;
                    tr6.Visible = false;
                    tr7.Visible = false;
                    tr8.Visible = false;
                    tr9.Visible = false;
                    tr10.Visible = false;
                    tr11.Visible = false;
                    tr12.Visible = false;
                    tr13.Visible = false;
                    tr14.Visible = false;
                    tr15.Visible = false;
                    tr16.Visible = false;
                    tr17.Visible = false;
                    tr18.Visible = false;
                    tr19.Visible = false;
                    tr20.Visible = false;
                    tr21.Visible = false;
                    tr22.Visible = false;
                    tr23.Visible = false;
                    tr24.Visible = false;
                    trTotal.Visible = false;

                    int Slot1Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot1Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1Finish_Eff"));
                    int Slot2Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot2Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2Finish_Eff"));
                    int Slot3Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot3Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3Finish_Eff"));
                    int Slot4Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot4Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4Finish_Eff"));
                    int Slot5Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot5Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5Finish_Eff"));
                    int Slot6Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot6Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6Finish_Eff"));
                    int Slot7Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot7Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7Finish_Eff"));
                    int Slot8Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot8Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8Finish_Eff"));
                    int Slot9Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot9Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9Finish_Eff"));
                    int Slot10Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot10Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10Finish_Eff"));
                    int Slot11Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot11Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11Finish_Eff"));
                    int Slot12Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot12Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12Finish_Eff"));
                    int Slot13Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot13Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13Finish_Eff"));
                    int Slot14Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot14Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14Finish_Eff"));
                    int Slot15Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot15Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15Finish_Eff"));
                    int Slot16Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot16Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16Finish_Eff"));
                    int Slot17Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot17Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17Finish_Eff"));
                    int Slot18Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot18Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18Finish_Eff"));
                    int Slot19Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot19Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19Finish_Eff"));
                    int Slot20Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot20Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20Finish_Eff"));
                    int Slot21Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot21Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21Finish_Eff"));
                    int Slot22Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot22Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22Finish_Eff"));
                    int Slot23Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot23Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23Finish_Eff"));
                    int Slot24Finish_Eff = DataBinder.Eval(e.Row.DataItem, "Slot24Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24Finish_Eff"));

                    
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

                    if (Slot1Finish_Eff >= Factory_BreakEvenEff)               
                        lblSlot1Pass.Style.Add("color", "green"); 
                    else
                        lblSlot1Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot2Finish_Eff >= Factory_BreakEvenEff)
                        lblSlot2Pass.Style.Add("color", "green");                        
                    else                   
                        lblSlot2Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot3Finish_Eff >= Factory_BreakEvenEff)                   
                        lblSlot3Pass.Style.Add("color", "green");                     
                    else              
                        lblSlot3Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot4Finish_Eff >= Factory_BreakEvenEff)
                       lblSlot4Pass.Style.Add("color", "green");                        
                    else                  
                        lblSlot4Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot5Finish_Eff >= Factory_BreakEvenEff)                   
                        lblSlot5Pass.Style.Add("color", "green");                      
                    else                 
                        lblSlot5Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot6Finish_Eff >= Factory_BreakEvenEff)                  
                        lblSlot6Pass.Style.Add("color", "green");                        
                    else                 
                        lblSlot6Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot7Finish_Eff >= Factory_BreakEvenEff)                  
                        lblSlot7Pass.Style.Add("color", "green");                        
                    else                   
                        lblSlot7Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot8Finish_Eff >= Factory_BreakEvenEff)                  
                        lblSlot8Pass.Style.Add("color", "green");                        
                    else                 
                        lblSlot8Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot9Finish_Eff >= Factory_BreakEvenEff)                   
                        lblSlot9Pass.Style.Add("color", "green");                       
                    else                   
                        lblSlot9Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot10Finish_Eff >= Factory_BreakEvenEff)                  
                        lblSlot10Pass.Style.Add("color", "green");                       
                    else                   
                        lblSlot10Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot11Finish_Eff >= Factory_BreakEvenEff)                    
                        lblSlot11Pass.Style.Add("color", "green");                        
                    else                  
                        lblSlot11Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot12Finish_Eff >= Factory_BreakEvenEff)                  
                        lblSlot12Pass.Style.Add("color", "green");                       
                    else                 
                        lblSlot12Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot13Finish_Eff >= Factory_BreakEvenEff)                 
                        lblSlot13Pass.Style.Add("color", "green");                        
                    else                
                        lblSlot13Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot14Finish_Eff >= Factory_BreakEvenEff)                   
                        lblSlot14Pass.Style.Add("color", "green");                        
                    else                   
                        lblSlot14Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot15Finish_Eff >= Factory_BreakEvenEff)                
                        lblSlot15Pass.Style.Add("color", "green");                        
                    else                   
                        lblSlot15Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot16Finish_Eff >= Factory_BreakEvenEff)                
                        lblSlot16Pass.Style.Add("color", "green");                     
                    else                  
                        lblSlot16Pass.Style.Add("color", "#FF0000");
                      
                    if (Slot17Finish_Eff >= Factory_BreakEvenEff)                 
                        lblSlot17Pass.Style.Add("color", "green");                       
                    else                  
                        lblSlot17Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot18Finish_Eff >= Factory_BreakEvenEff)                   
                        lblSlot18Pass.Style.Add("color", "green");                      
                    else                  
                        lblSlot18Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot19Finish_Eff >= Factory_BreakEvenEff)                 
                        lblSlot19Pass.Style.Add("color", "green");                        
                    else                
                        lblSlot19Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot20Finish_Eff >= Factory_BreakEvenEff)                  
                        lblSlot20Pass.Style.Add("color", "green");                       
                    else               
                        lblSlot20Pass.Style.Add("color", "#FF0000");
                      
                    if (Slot21Finish_Eff >= Factory_BreakEvenEff)                  
                        lblSlot21Pass.Style.Add("color", "green");                       
                    else
                       lblSlot21Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot22Finish_Eff >= Factory_BreakEvenEff)                  
                        lblSlot22Pass.Style.Add("color", "green");                       
                    else                    
                        lblSlot22Pass.Style.Add("color", "#FF0000");
                        
                    if (Slot23Finish_Eff >= Factory_BreakEvenEff)                  
                        lblSlot23Pass.Style.Add("color", "green");                      
                    else                   
                        lblSlot23Pass.Style.Add("color", "#FF0000");
                       
                    if (Slot24Finish_Eff >= Factory_BreakEvenEff)                   
                        lblSlot24Pass.Style.Add("color", "green");                      
                    else                  
                        lblSlot24Pass.Style.Add("color", "#FF0000");
                        

                    Total_FinishEff1 += DataBinder.Eval(e.Row.DataItem, "Slot1Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1Finish_Eff"));
                    Total_FinishEff2 += DataBinder.Eval(e.Row.DataItem, "Slot2Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2Finish_Eff"));
                    Total_FinishEff3 += DataBinder.Eval(e.Row.DataItem, "Slot3Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3Finish_Eff"));
                    Total_FinishEff4 += DataBinder.Eval(e.Row.DataItem, "Slot4Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4Finish_Eff"));
                    Total_FinishEff5 += DataBinder.Eval(e.Row.DataItem, "Slot5Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5Finish_Eff"));
                    Total_FinishEff6 += DataBinder.Eval(e.Row.DataItem, "Slot6Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6Finish_Eff"));
                    Total_FinishEff7 += DataBinder.Eval(e.Row.DataItem, "Slot7Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7Finish_Eff"));
                    Total_FinishEff8 += DataBinder.Eval(e.Row.DataItem, "Slot8Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8Finish_Eff"));
                    Total_FinishEff9 += DataBinder.Eval(e.Row.DataItem, "Slot9Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9Finish_Eff"));
                    Total_FinishEff10 += DataBinder.Eval(e.Row.DataItem, "Slot10Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10Finish_Eff"));
                    Total_FinishEff11 += DataBinder.Eval(e.Row.DataItem, "Slot11Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11Finish_Eff"));
                    Total_FinishEff12 += DataBinder.Eval(e.Row.DataItem, "Slot12Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12Finish_Eff"));
                    Total_FinishEff13 += DataBinder.Eval(e.Row.DataItem, "Slot13Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13Finish_Eff"));
                    Total_FinishEff14 += DataBinder.Eval(e.Row.DataItem, "Slot14Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14Finish_Eff"));
                    Total_FinishEff15 += DataBinder.Eval(e.Row.DataItem, "Slot15Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15Finish_Eff"));
                    Total_FinishEff16 += DataBinder.Eval(e.Row.DataItem, "Slot16Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16Finish_Eff"));
                    Total_FinishEff17 += DataBinder.Eval(e.Row.DataItem, "Slot17Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17Finish_Eff"));
                    Total_FinishEff18 += DataBinder.Eval(e.Row.DataItem, "Slot18Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18Finish_Eff"));
                    Total_FinishEff19 += DataBinder.Eval(e.Row.DataItem, "Slot19Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19Finish_Eff"));
                    Total_FinishEff20 += DataBinder.Eval(e.Row.DataItem, "Slot20Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20Finish_Eff"));
                    Total_FinishEff21 += DataBinder.Eval(e.Row.DataItem, "Slot21Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21Finish_Eff"));
                    Total_FinishEff22 += DataBinder.Eval(e.Row.DataItem, "Slot22Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22Finish_Eff"));
                    Total_FinishEff23 += DataBinder.Eval(e.Row.DataItem, "Slot23Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23Finish_Eff"));
                    Total_FinishEff24 += DataBinder.Eval(e.Row.DataItem, "Slot24Finish_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24Finish_Eff"));

                    Total_StitchEff1 += DataBinder.Eval(e.Row.DataItem, "Slot1Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot1Stitch_Eff"));
                    Total_StitchEff2 += DataBinder.Eval(e.Row.DataItem, "Slot2Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot2Stitch_Eff"));
                    Total_StitchEff3 += DataBinder.Eval(e.Row.DataItem, "Slot3Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot3Stitch_Eff"));
                    Total_StitchEff4 += DataBinder.Eval(e.Row.DataItem, "Slot4Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot4Stitch_Eff"));
                    Total_StitchEff5 += DataBinder.Eval(e.Row.DataItem, "Slot5Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot5Stitch_Eff"));
                    Total_StitchEff6 += DataBinder.Eval(e.Row.DataItem, "Slot6Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot6Stitch_Eff"));
                    Total_StitchEff7 += DataBinder.Eval(e.Row.DataItem, "Slot7Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot7Stitch_Eff"));
                    Total_StitchEff8 += DataBinder.Eval(e.Row.DataItem, "Slot8Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot8Stitch_Eff"));
                    Total_StitchEff9 += DataBinder.Eval(e.Row.DataItem, "Slot9Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot9Stitch_Eff"));
                    Total_StitchEff10 += DataBinder.Eval(e.Row.DataItem, "Slot10Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot10Stitch_Eff"));
                    Total_StitchEff11 += DataBinder.Eval(e.Row.DataItem, "Slot11Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot11Stitch_Eff"));
                    Total_StitchEff12 += DataBinder.Eval(e.Row.DataItem, "Slot12Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot12Stitch_Eff"));
                    Total_StitchEff13 += DataBinder.Eval(e.Row.DataItem, "Slot13Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot13Stitch_Eff"));
                    Total_StitchEff14 += DataBinder.Eval(e.Row.DataItem, "Slot14Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot14Stitch_Eff"));
                    Total_StitchEff15 += DataBinder.Eval(e.Row.DataItem, "Slot15Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot15Stitch_Eff"));
                    Total_StitchEff16 += DataBinder.Eval(e.Row.DataItem, "Slot16Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot16Stitch_Eff"));
                    Total_StitchEff17 += DataBinder.Eval(e.Row.DataItem, "Slot17Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot17Stitch_Eff"));
                    Total_StitchEff18 += DataBinder.Eval(e.Row.DataItem, "Slot18Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot18Stitch_Eff"));
                    Total_StitchEff19 += DataBinder.Eval(e.Row.DataItem, "Slot19Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot19Stitch_Eff"));
                    Total_StitchEff20 += DataBinder.Eval(e.Row.DataItem, "Slot20Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot20Stitch_Eff"));
                    Total_StitchEff21 += DataBinder.Eval(e.Row.DataItem, "Slot21Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot21Stitch_Eff"));
                    Total_StitchEff22 += DataBinder.Eval(e.Row.DataItem, "Slot22Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot22Stitch_Eff"));
                    Total_StitchEff23 += DataBinder.Eval(e.Row.DataItem, "Slot23Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot23Stitch_Eff"));
                    Total_StitchEff24 += DataBinder.Eval(e.Row.DataItem, "Slot24Stitch_Eff") == DBNull.Value ? 0 : Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Slot24Stitch_Eff"));

                    EfficencyTotal = EfficencyTotal + 1;

                    
                  

                }

            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[0].ColumnSpan = 2;
                e.Row.Cells[1].Visible = false;
                e.Row.Attributes.Add("class", "yellowFactory");
                e.Row.Cells[32].ColumnSpan = 6;
                e.Row.Cells[32].CssClass = "ROWMERGE";
                e.Row.Cells[33].Visible = false;
                e.Row.Cells[34].Visible = false;
                e.Row.Cells[35].Visible = false;
                e.Row.Cells[36].Visible = false;
                e.Row.Cells[37].Visible = false;

                e.Row.Cells[2].ColumnSpan = 3;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;

                Label lblSlot1PassTotal = (Label)e.Row.FindControl("lblSlot1PassTotal");            
                if (Total_Slot1 != 0)
                    lblSlot1PassTotal.Text = Total_Slot1.ToString();               

                Label lblSlot2PassTotal = (Label)e.Row.FindControl("lblSlot2PassTotal");              
                if (Total_Slot2 != 0)
                    lblSlot2PassTotal.Text = Total_Slot2.ToString();                

                Label lblSlot3PassTotal = (Label)e.Row.FindControl("lblSlot3PassTotal");               
                if (Total_Slot3 != 0)
                    lblSlot3PassTotal.Text =Total_Slot3.ToString();             

                Label lblSlot4PassTotal = (Label)e.Row.FindControl("lblSlot4PassTotal");               
                if (Total_Slot4 != 0)
                    lblSlot4PassTotal.Text =Total_Slot4.ToString();            

                Label lblSlot5PassTotal = (Label)e.Row.FindControl("lblSlot5PassTotal");              
                if (Total_Slot5 != 0)
                    lblSlot5PassTotal.Text = Total_Slot5.ToString();              

                Label lblSlot6PassTotal = (Label)e.Row.FindControl("lblSlot6PassTotal");              
                if (Total_Slot6 != 0)
                    lblSlot6PassTotal.Text = Total_Slot6.ToString();               

                Label lblSlot7PassTotal = (Label)e.Row.FindControl("lblSlot7PassTotal");              
                if (Total_Slot7 != 0)
                    lblSlot7PassTotal.Text = Total_Slot7.ToString();                

                Label lblSlot8PassTotal = (Label)e.Row.FindControl("lblSlot8PassTotal");             
                if (Total_Slot8 != 0)
                    lblSlot8PassTotal.Text = Total_Slot8.ToString();               

                Label lblSlot9PassTotal = (Label)e.Row.FindControl("lblSlot9PassTotal");               
                if (Total_Slot9 != 0)
                    lblSlot9PassTotal.Text = Total_Slot9.ToString();              

                Label lblSlot10PassTotal = (Label)e.Row.FindControl("lblSlot10PassTotal");               
                if (Total_Slot10 != 0)
                    lblSlot10PassTotal.Text = Total_Slot10.ToString();
             
                Label lblSlot11PassTotal = (Label)e.Row.FindControl("lblSlot11PassTotal");               
                if (Total_Slot11 != 0)
                    lblSlot11PassTotal.Text = Total_Slot11.ToString();              

                Label lblSlot12PassTotal = (Label)e.Row.FindControl("lblSlot12PassTotal");              
                if (Total_Slot12 != 0)
                    lblSlot12PassTotal.Text = Total_Slot12.ToString();
            
                Label lblSlot13PassTotal = (Label)e.Row.FindControl("lblSlot13PassTotal");            
                if (Total_Slot13 != 0)
                    lblSlot13PassTotal.Text = Total_Slot13.ToString();
               
                Label lblSlot14PassTotal = (Label)e.Row.FindControl("lblSlot14PassTotal");              
                if (Total_Slot14 != 0)
                    lblSlot14PassTotal.Text = Total_Slot14.ToString();               

                Label lblSlot15PassTotal = (Label)e.Row.FindControl("lblSlot15PassTotal");              
                if (Total_Slot15 != 0)
                    lblSlot15PassTotal.Text = Total_Slot15.ToString();               

                Label lblSlot16PassTotal = (Label)e.Row.FindControl("lblSlot16PassTotal");             
                if (Total_Slot16 != 0)
                    lblSlot16PassTotal.Text = Total_Slot16.ToString();          

                Label lblSlot17PassTotal = (Label)e.Row.FindControl("lblSlot17PassTotal");              
                if (Total_Slot17 != 0)
                    lblSlot17PassTotal.Text = Total_Slot17.ToString();             

                Label lblSlot18PassTotal = (Label)e.Row.FindControl("lblSlot18PassTotal");              
                if (Total_Slot18 != 0)
                    lblSlot18PassTotal.Text = Total_Slot18.ToString();         

                Label lblSlot19PassTotal = (Label)e.Row.FindControl("lblSlot19PassTotal");             
                if (Total_Slot19 != 0)
                    lblSlot19PassTotal.Text = Total_Slot19.ToString();              

                Label lblSlot20PassTotal = (Label)e.Row.FindControl("lblSlot20PassTotal");              
                if (Total_Slot20 != 0)
                    lblSlot20PassTotal.Text = Total_Slot20.ToString();
               
                Label lblSlot21PassTotal = (Label)e.Row.FindControl("lblSlot21PassTotal");                
                if (Total_Slot21 != 0)
                    lblSlot21PassTotal.Text = Total_Slot21.ToString();
               
                Label lblSlot22PassTotal = (Label)e.Row.FindControl("lblSlot22PassTotal");              
                if (Total_Slot22 != 0)
                    lblSlot22PassTotal.Text = Total_Slot22.ToString();              

                Label lblSlot23PassTotal = (Label)e.Row.FindControl("lblSlot23PassTotal");              
                if (Total_Slot23 != 0)
                    lblSlot23PassTotal.Text = Total_Slot23.ToString();           

                Label lblSlot24PassTotal = (Label)e.Row.FindControl("lblSlot24PassTotal");             
                if (Total_Slot24 != 0)
                    lblSlot24PassTotal.Text = Total_Slot24.ToString();
              

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
                    lblSlot24DHUTotal.Text = Math.Round(Convert.ToDouble(Total_DHU24) / Convert.ToDouble(FactoryTotal), 0).ToString() == "0" ? "" : Math.Round(Convert.ToDouble(Total_DHU24) / Convert.ToDouble(FactoryTotal), 0).ToString()+ " %";  


                if (TotalBreakEvenQty > 0)
                {
                    HtmlTableCell tdSlot1PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot1PassTotal");
                    if (Total_PassFinish1 >= TotalBreakEvenQty)
                        tdSlot1PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot1PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot2PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot2PassTotal");
                    if (Total_PassFinish2 >= TotalBreakEvenQty)
                        tdSlot2PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot2PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot3PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot3PassTotal");
                    if (Total_PassFinish3 >= TotalBreakEvenQty)
                        tdSlot3PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot3PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot4PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot4PassTotal");
                    if (Total_PassFinish4 >= TotalBreakEvenQty)
                        tdSlot4PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot4PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot5PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot5PassTotal");
                    if (Total_PassFinish5 >= TotalBreakEvenQty)
                        tdSlot5PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot5PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot6PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot6PassTotal");
                    if (Total_PassFinish6 >= TotalBreakEvenQty)
                        tdSlot6PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot6PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot7PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot7PassTotal");
                    if (Total_PassFinish7 >= TotalBreakEvenQty)
                        tdSlot7PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot7PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot8PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot8PassTotal");
                    if (Total_PassFinish8 >= TotalBreakEvenQty)
                        tdSlot8PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot8PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot9PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot9PassTotal");
                    if (Total_PassFinish9 >= TotalBreakEvenQty)
                        tdSlot9PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot9PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot10PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot10PassTotal");
                    if (Total_PassFinish10 >= TotalBreakEvenQty)
                        tdSlot10PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot10PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot11PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot11PassTotal");
                    if (Total_PassFinish11 >= TotalBreakEvenQty)
                        tdSlot11PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot11PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot12PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot12PassTotal");
                    if (Total_PassFinish12 >= TotalBreakEvenQty)
                        tdSlot12PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot12PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot13PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot13PassTotal");
                    if (Total_PassFinish13 >= TotalBreakEvenQty)
                        tdSlot13PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot13PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot14PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot14PassTotal");
                    if (Total_PassFinish14 >= TotalBreakEvenQty)
                        tdSlot14PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot14PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot15PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot15PassTotal");
                    if (Total_PassFinish15 >= TotalBreakEvenQty)
                        tdSlot15PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot15PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot16PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot16PassTotal");
                    if (Total_PassFinish16 >= TotalBreakEvenQty)
                        tdSlot16PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot16PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot17PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot17PassTotal");
                    if (Total_PassFinish17 >= TotalBreakEvenQty)
                        tdSlot17PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot17PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot18PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot18PassTotal");
                    if (Total_PassFinish18 >= TotalBreakEvenQty)
                        tdSlot18PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot18PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot19PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot19PassTotal");
                    if (Total_PassFinish19 >= TotalBreakEvenQty)
                        tdSlot19PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot19PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot20PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot20PassTotal");
                    if (Total_PassFinish20 >= TotalBreakEvenQty)
                        tdSlot20PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot20PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot21PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot21PassTotal");
                    if (Total_PassFinish21 >= TotalBreakEvenQty)
                        tdSlot21PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot21PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot22PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot22PassTotal");
                    if (Total_PassFinish22 >= TotalBreakEvenQty)
                        tdSlot22PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot22PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot23PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot23PassTotal");
                    if (Total_PassFinish23 >= TotalBreakEvenQty)
                        tdSlot23PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot23PassTotal.Style.Add("background-color", "#FF0000");

                    HtmlTableCell tdSlot24PassTotal = (HtmlTableCell)e.Row.FindControl("tdSlot24PassTotal");
                    if (Total_PassFinish24 >= TotalBreakEvenQty)
                        tdSlot24PassTotal.Style.Add("background-color", "green");
                    else
                        tdSlot24PassTotal.Style.Add("background-color", "#FF0000");

                }
                TotalBreakEvenQty = TotalBreakEvenQty * ActiveSlotCount;

                HtmlTableCell tdSlotAllPassTotal = (HtmlTableCell)e.Row.FindControl("tdSlotAllPassTotal");
                if (TodayPassPcsFinish_Total >= TotalBreakEvenQty)
                    tdSlotAllPassTotal.Style.Add("color", "green");
                else
                    tdSlotAllPassTotal.Style.Add("color", "#FF0000");

                Label lblTodayPassStitch_Foo = (Label)e.Row.FindControl("lblTodayPassStitch_Foo");
                Label lblTodayPassFinish_Foo = (Label)e.Row.FindControl("lblTodayPassFinish_Foo");
                Label lblTodayAltPcs_Foo = (Label)e.Row.FindControl("lblTodayAltPcs_Foo");
                Label lblTodayDHU_Foo = (Label)e.Row.FindControl("lblTodayDHU_Foo");
                HtmlGenericControl dvFooter = (HtmlGenericControl)e.Row.FindControl("dvFooter");

                if (TodayPassPcsFinish_Total != 0)
                    lblTodayPassFinish_Foo.Text = "[" + TodayPassPcsFinish_Total.ToString() + "]";

                if (TodayPassPcsStitch_Total != 0)
                    lblTodayPassStitch_Foo.Text = TodayPassPcsStitch_Total.ToString();

                if (TodayAltPcs_Total != 0)
                    lblTodayAltPcs_Foo.Text = TodayAltPcs_Total.ToString();

                if (DHU_Today_Total != 0)
                    lblTodayDHU_Foo.Text = "(" + Math.Round(Convert.ToDouble(DHU_Today_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + ")";

                // Footer merge section Bipl total

                string StitchSAM_Foo = "";
                string StchActOB_Foo = "";
                string StchAgreedOB_Foo = "";
                string FinishSAM_Foo = "";
                string FinActOB_Foo = "";
                string FinAgreedOB_Foo = "";
                string PkCpty_Foo = "";
                string PkOB_Foo = "";
                string PkEff_Foo = "";
                string OrderQty_Foo = "";
                string COT_Foo = "";
                string StchQty_Foo = "";
                string FinQty_Foo = "";
                string TargetEffTotal = "";
                string TargetQtyTotal = "";
                string BreakEvenEffTotal = "";
                string BreakEvenQtyTotal = "";

                if (StitchSAM_Total != 0)
                    StitchSAM_Foo = Math.Round(Convert.ToDouble(StitchSAM_Total) / Convert.ToDouble(FactoryTotal), 2).ToString();

                //Color on Actual OB
                string styleClassObSt = "", styleClassObFn = "";
                if (StitchActualOB_Total <= StitchOB_Total)
                    styleClassObSt = "actObGreen";
                else
                    styleClassObSt = "actObRed";

                if (FinishActualOB_Total <= FinishOB_Total)
                    styleClassObFn = "actObGreen";
                else
                    styleClassObFn = "actObRed";

                if (StitchActualOB_Total != 0)
                    StchActOB_Foo = StitchActualOB_Total.ToString();
                if (StitchOB_Total != 0)
                    StchAgreedOB_Foo = " (" + StitchOB_Total.ToString() + ")";

                if (FinishSAM_Total != 0)
                    FinishSAM_Foo = Math.Round(Convert.ToDouble(FinishSAM_Total) / Convert.ToDouble(FactoryTotal), 2).ToString();
                if (FinishActualOB_Total != 0)
                    FinActOB_Foo = FinishActualOB_Total.ToString();
                if (FinishOB_Total != 0)
                    FinAgreedOB_Foo = " (" + FinishOB_Total.ToString() + ")";
                

                if (PeakCapecity_Total != 0)
                    PkCpty_Foo = Math.Round(Convert.ToDouble(PeakCapecity_Total),0).ToString(); /// Convert.ToDouble(FactoryTotal), 0).ToString();
                if (PeakOB_Total != 0)
                    PkOB_Foo = " (" + Math.Round(Convert.ToDouble(PeakOB_Total),0).ToString() + ")"; /// Convert.ToDouble(FactoryTotal), 0).ToString() + ")";
                if (PeakEff_Total != 0)
                    PkEff_Foo = " (" + Math.Round(Convert.ToDouble(PeakEff_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%)";
                if (OrderQty_Total != 0)
                    OrderQty_Foo = OrderQty_Total.ToString("#,##0");
                if (COTValue_Total != 0)
                    COT_Foo = Math.Round(Convert.ToDouble(COTValue_Total) / Convert.ToDouble(FactoryTotal), 0).ToString();

                if (StitchQty_Total != 0)
                    StchQty_Foo = StitchQty_Total.ToString("#,##0");
                if (FinishQty_Total != 0)
                    FinQty_Foo = FinishQty_Total.ToString("#,##0");

                if (TargetEff_Total != 0)
                    TargetEffTotal = Math.Round(Convert.ToDouble(TargetEff_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%";

                if (TargetQty_Total != 0)
                    TargetQtyTotal = TargetQty_Total.ToString() + " Pcs";

                if (BreakEvenEff_Total != 0)
                    BreakEvenEffTotal = Math.Round(Convert.ToDouble(BreakEvenEff_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%";

                if (BreakEvenQty_Total != 0)
                    BreakEvenQtyTotal = BreakEvenQty_Total.ToString() + " Pcs";
                if (WIPSPredayStitch == 0)
                    WIPSPredayStitch = 1;
                double WIPStitching = Math.Round((Convert.ToDouble(WIPSTotCut) - Convert.ToDouble(WIPSTotStitch)) / Convert.ToDouble(WIPSPredayStitch),0);

                if (WIPSPredayFin == 0)
                    WIPSPredayFin = 1;
                double WIPFinished = Math.Round((Convert.ToDouble(WIPFTotStitch) - Convert.ToDouble(WIPSTotFin)) / Convert.ToDouble(WIPSPredayFin),0);

                string sWIPStitching = WIPStitching == 0 ? "" : WIPStitching.ToString() + " D";
                string sWIPFinished = WIPFinished == 0 ? "" : WIPFinished.ToString() + " D";

                string clsWIPStitching = "", clsWIPFinished = "";               

                if ((WIPStitching >= 0 && WIPStitching <= 2))
                    clsWIPStitching = "WIPRed";                           
                else
                    clsWIPStitching = "WIPGreen";                 
               
                if (WIPFinished == 0)
                    clsWIPFinished = "WIPGreen";
                else
                    clsWIPFinished = "WIPRed";
                

                string tablestring = "";

                tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' width='100%' border='0' style='border-collapse:collapse;'>";

                tablestring = tablestring + "<tr> <td width='40px' height='20px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;'>" + StitchSAM_Foo + " </td> <td id='tdStchActOB' runat='server' width='60px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;color:black;'> " + "<span id='lblStchActOB_Foo' class=" + styleClassObSt + " >" + StchActOB_Foo + "</span>" + StchAgreedOB_Foo + "</td> <td width='80px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;' colspan='2'> <span style='color:blue; font-weight:bold'> " + PkCpty_Foo + " </span> <span style='color:black;'>" + PkOB_Foo + " </span> </td> <td width='60px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;'> " + OrderQty_Foo + "</td> <td width='36px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;'> " + TargetEffTotal + "</td> <td width='54px' style='border-bottom:1px solid #bfbfbf; background:#90EE90; color:black;font-size: 11px !important;'> " + TargetQtyTotal + "</td> </tr>";
                tablestring = tablestring + "<tr> <td height='27px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;' rowspan='2'>" + FinishSAM_Foo + " </td> <td id='tdFinActOB' runat='server' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; color:black;' rowspan='2'> " + "<span id='lblFinActOB_Foo' class=" + styleClassObFn + " >" + FinActOB_Foo + "</span>" + FinAgreedOB_Foo + "</td> <td style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;' colspan='2'> <span style='color:black'> " + COT_Foo + " </span> <span style='color:blue;'>" + PkEff_Foo + " </span>     </td> <td style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;'> <div style='border-bottom:1px solid #ccc;'> " + StchQty_Foo + "</div>  </td> <td style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;' rowspan='2'> " + BreakEvenEffTotal + "</td> <td style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;' rowspan='2'>" + BreakEvenQtyTotal + " </td> </tr>";
                tablestring = tablestring + "<tr><td style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; width:40px;'  class=" + clsWIPStitching + " >" + sWIPStitching + " </td> <td class=" + clsWIPFinished + " style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf; width:40px;'> " + sWIPFinished + "  </td> <td style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;'> " + FinQty_Foo + "</td>";
                tablestring = tablestring + "<tr> <td colspan='7' height='20px' style='border-right:1px solid #bfbfbf;' ><h3 style='font-weight:normal; font-size:12px; padding:0px; margin:0px; text-align:center;'> Efficiency  </h3> </td>  </tr>";
                tablestring = tablestring + "</table>";                
                dvFooter.InnerHtml = tablestring;
 
                Label lblLineFinishQty_Foo = (Label)e.Row.FindControl("lblLineFinishQty_Foo");
                Label lblLineStitchQty_Foo = (Label)e.Row.FindControl("lblLineStitchQty_Foo");
                Label lblLineAltVal_Foo = (Label)e.Row.FindControl("lblLineAltVal_Foo");
                Label lblLineDHU_Foo = (Label)e.Row.FindControl("lblLineDHU_Foo");

               
                Label lblTodayEff_Finish_Foo = (Label)e.Row.FindControl("lblTodayEff_Finish_Foo");
                Label lblTodayEff_Stitch_Foo = (Label)e.Row.FindControl("lblTodayEff_Stitch_Foo");

                Label lblStyleEff_Finish_Foo = (Label)e.Row.FindControl("lblStyleEff_Finish_Foo");
                Label lblStyleEff_Stitch_Foo = (Label)e.Row.FindControl("lblStyleEff_Stitch_Foo");

                

                if (LineFinishedQty_Total != 0)
                    lblLineFinishQty_Foo.Text = Math.Round(Convert.ToDouble(LineFinishedQty_Total) / 1000, 1) == 0 ? "" : "[" + Math.Round(Convert.ToDouble(LineFinishedQty_Total) / 1000, 1).ToString() + "k" + "]"; 

                if (LineStitchedQty_Total != 0)
                    lblLineStitchQty_Foo.Text = Math.Round(Convert.ToDouble(LineStitchedQty_Total) / 1000, 1) == 0 ? "" : Math.Round(Convert.ToDouble(LineStitchedQty_Total) / 1000, 1).ToString() + "k" ;

                if (LineAltValue_Total != 0)
                    lblLineAltVal_Foo.Text = LineAltValue_Total.ToString();

                if (Line_DHU_Total != 0)
                    lblLineDHU_Foo.Text = "(" + Math.Round(Convert.ToDouble(Line_DHU_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%)";

                if (TodayEfficiency_Finish_Total != 0)
                    lblTodayEff_Finish_Foo.Text = "[" + Math.Round(Convert.ToDouble(TodayEfficiency_Finish_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%]";

                if ((TodayEfficiency_Stitch_Total != 0) || (TodayEfficiency_Stitch_Total != -1))
                    lblTodayEff_Stitch_Foo.Text = Math.Round(Convert.ToDouble(TodayEfficiency_Stitch_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%";

                if (StyleEfficiency_Finish_Total != 0)
                    lblStyleEff_Finish_Foo.Text = "[" + Math.Round(Convert.ToDouble(StyleEfficiency_Finish_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%]";

                if ((StyleEfficiency_Stitch_Total != 0) || (StyleEfficiency_Stitch_Total != -1))
                    lblStyleEff_Stitch_Foo.Text = Math.Round(Convert.ToDouble(StyleEfficiency_Stitch_Total) / Convert.ToDouble(FactoryTotal), 0).ToString() + "%";


                HtmlTableCell tdTodayEffTotal = (HtmlTableCell)e.Row.FindControl("tdTodayEffTotal");
                // Change by Ravi on dated 14 Oct
                if (TodayEfficiency_Stitch_Total >= BreakEvenEff_Total)
                    tdTodayEffTotal.Style.Add("color", "green");
                else
                    tdTodayEffTotal.Style.Add("color", "#FF0000");

           

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


                
                lbl1StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff1) / EfficencyTotal,0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff1) / EfficencyTotal,0).ToString() + "%";

                lbl2StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff2) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff2) / EfficencyTotal, 0).ToString() + "%";

                lbl3StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff3) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff3) / EfficencyTotal, 0).ToString() + "%";

                lbl4StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff4) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff4) / EfficencyTotal, 0).ToString() + "%";

                lbl5StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff5) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff5) / EfficencyTotal, 0).ToString() + "%";

                lbl6StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff6) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff6) / EfficencyTotal, 0).ToString() + "%";

                lbl7StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff7) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff7) / EfficencyTotal, 0).ToString() + "%";

                lbl8StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff8) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff8) / EfficencyTotal, 0).ToString() + "%";

                lbl9StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff9) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff9) / EfficencyTotal, 0).ToString() + "%";

                lbl10StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff10) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff10) / EfficencyTotal, 0).ToString() + "%";

                lbl11StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff11) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff11) / EfficencyTotal, 0).ToString() + "%";

                lbl12StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff12) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff12) / EfficencyTotal, 0).ToString() + "%";

                lbl13StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff13) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff13) / EfficencyTotal, 0).ToString() + "%";

                lbl14StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff14) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff14) / EfficencyTotal, 0).ToString() + "%";

                lbl15StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff15) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff15) / EfficencyTotal, 0).ToString() + "%";

                lbl16StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff16) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff16) / EfficencyTotal, 0).ToString() + "%";

                lbl17StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff17) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff17) / EfficencyTotal, 0).ToString() + "%";

                lbl18StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff18) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff18) / EfficencyTotal, 0).ToString() + "%";
          
                lbl19StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff19) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff19) / EfficencyTotal, 0).ToString() + "%";

                lbl20StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff20) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff20) / EfficencyTotal, 0).ToString() + "%";

                lbl21StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff21) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff21) / EfficencyTotal, 0).ToString() + "%";

                lbl22StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff22) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff22) / EfficencyTotal, 0).ToString() + "%";

                lbl23StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff23) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff23) / EfficencyTotal, 0).ToString() + "%";
                            
                lbl24StitchEff_Foo.Text = Math.Round(Convert.ToDouble(Total_StitchEff24) / EfficencyTotal, 0) == 0 ? "" : Math.Round(Convert.ToDouble(Total_StitchEff24) / EfficencyTotal, 0).ToString() + "%";
                if (FactoryTotal == 0)
                    FactoryTotal = 1;

                int BreakEvenEff_Foo = Convert.ToInt32( Math.Round(Convert.ToDouble(BreakEvenEff_Total) / Convert.ToDouble(FactoryTotal), 0));

                if (Total_FinishEff1 >= BreakEvenEff_Foo)              
                    lbl1StitchEff_Foo.Style.Add("color", "green");                    
                else             
                    lbl1StitchEff_Foo.Style.Add("color", "#FF0000");
                   
                if (Total_FinishEff2 >= BreakEvenEff_Foo)              
                    lbl2StitchEff_Foo.Style.Add("color", "green");                
                else              
                    lbl2StitchEff_Foo.Style.Add("color", "#FF0000");
                   
                if (Total_FinishEff2 >= BreakEvenEff_Foo)               
                    lbl3StitchEff_Foo.Style.Add("color", "green");                   
                else           
                    lbl3StitchEff_Foo.Style.Add("color", "#FF0000");
                   
                if (Total_FinishEff4 >= BreakEvenEff_Foo)             
                    lbl4StitchEff_Foo.Style.Add("color", "green");                   
                else              
                    lbl4StitchEff_Foo.Style.Add("color", "#FF0000");
                
                if (Total_FinishEff5 >= BreakEvenEff_Foo)              
                    lbl5StitchEff_Foo.Style.Add("color", "green");                    
                else
                   lbl5StitchEff_Foo.Style.Add("color", "#FF0000");
                   
                if (Total_FinishEff6 >= BreakEvenEff_Foo)            
                    lbl6StitchEff_Foo.Style.Add("color", "green");                   
                else              
                    lbl6StitchEff_Foo.Style.Add("color", "#FF0000");
                   
                if (Total_FinishEff7 >= BreakEvenEff_Foo)              
                    lbl7StitchEff_Foo.Style.Add("color", "green");                  
                else              
                    lbl7StitchEff_Foo.Style.Add("color", "#FF0000");
                  
                if (Total_FinishEff8 >= BreakEvenEff_Foo)            
                    lbl8StitchEff_Foo.Style.Add("color", "green");                    
                else            
                    lbl8StitchEff_Foo.Style.Add("color", "#FF0000");  
                  
                if (Total_FinishEff9 >= BreakEvenEff_Foo)            
                    lbl9StitchEff_Foo.Style.Add("color", "green");                  
                else              
                    lbl9StitchEff_Foo.Style.Add("color", "#FF0000");
                  
                if (Total_FinishEff10 >= BreakEvenEff_Foo)               
                    lbl10StitchEff_Foo.Style.Add("color", "green");                   
                else              
                    lbl10StitchEff_Foo.Style.Add("color", "#FF0000");
                
                if (Total_FinishEff11 >= BreakEvenEff_Foo)              
                    lbl11StitchEff_Foo.Style.Add("color", "green");                   
                else             
                    lbl11StitchEff_Foo.Style.Add("color", "#FF0000");
                  
                if (Total_FinishEff12 >= BreakEvenEff_Foo)              
                    lbl12StitchEff_Foo.Style.Add("color", "green");                    
                else              
                    lbl12StitchEff_Foo.Style.Add("color", "#FF0000");
                   
                if (Total_FinishEff13 >= BreakEvenEff_Foo)             
                    lbl13StitchEff_Foo.Style.Add("color", "green");                  
                else              
                    lbl13StitchEff_Foo.Style.Add("color", "#FF0000");
                   
                if (Total_FinishEff14 >= BreakEvenEff_Foo)              
                    lbl14StitchEff_Foo.Style.Add("color", "green");                    
                else             
                    lbl14StitchEff_Foo.Style.Add("color", "#FF0000");
                    
                if (Total_FinishEff15 >= BreakEvenEff_Foo)              
                    lbl15StitchEff_Foo.Style.Add("color", "green");                    
                else             
                    lbl15StitchEff_Foo.Style.Add("color", "#FF0000");
                  
                if (Total_FinishEff16 >= BreakEvenEff_Foo)           
                    lbl16StitchEff_Foo.Style.Add("color", "green");                    
                else              
                    lbl16StitchEff_Foo.Style.Add("color", "#FF0000");
                 
                if (Total_FinishEff17 >= BreakEvenEff_Foo)            
                    lbl17StitchEff_Foo.Style.Add("color", "green");                  
                else            
                    lbl17StitchEff_Foo.Style.Add("color", "#FF0000");
                    
                if (Total_FinishEff18 >= BreakEvenEff_Foo)              
                    lbl18StitchEff_Foo.Style.Add("color", "green");                   
                else               
                    lbl18StitchEff_Foo.Style.Add("color", "#FF0000");
                   
                if (Total_FinishEff19 >= BreakEvenEff_Foo)             
                    lbl19StitchEff_Foo.Style.Add("color", "green");                   
                else              
                    lbl19StitchEff_Foo.Style.Add("color", "#FF0000");
                   
                if (Total_FinishEff20 >= BreakEvenEff_Foo)              
                    lbl20StitchEff_Foo.Style.Add("color", "green");                    
                else           
                    lbl20StitchEff_Foo.Style.Add("color", "#FF0000");
                   
                if (Total_FinishEff21 >= BreakEvenEff_Foo)               
                    lbl21StitchEff_Foo.Style.Add("color", "green");                   
                else             
                    lbl21StitchEff_Foo.Style.Add("color", "#FF0000");
                   
                if (Total_FinishEff22 >= BreakEvenEff_Foo)              
                    lbl22StitchEff_Foo.Style.Add("color", "green");                   
                else             
                    lbl22StitchEff_Foo.Style.Add("color", "#FF0000");
                   
                if (Total_FinishEff23 >= BreakEvenEff_Foo)              
                    lbl23StitchEff_Foo.Style.Add("color", "green");                  
                else              
                    lbl23StitchEff_Foo.Style.Add("color", "#FF0000");
                    
                if (Total_FinishEff24 >= BreakEvenEff_Foo)             
                    lbl24StitchEff_Foo.Style.Add("color", "green");                   
                else            
                    lbl24StitchEff_Foo.Style.Add("color", "#FF0000");
                   
                               

                Total_Slot1 = 0;
                Total_Slot2 = 0;
                Total_Slot3 = 0;
                Total_Slot4 = 0;
                Total_Slot5 = 0;
                Total_Slot6 = 0;
                Total_Slot7 = 0;
                Total_Slot8 = 0;
                Total_Slot9 = 0;
                Total_Slot10 = 0;
                Total_Slot11 = 0;
                Total_Slot12 = 0;
                Total_Slot13 = 0;
                Total_Slot14 = 0;
                Total_Slot15 = 0;
                Total_Slot16 = 0;
                Total_Slot17 = 0;
                Total_Slot18 = 0;
                Total_Slot19 = 0;
                Total_Slot20 = 0;
                Total_Slot21 = 0;
                Total_Slot22 = 0;
                Total_Slot23 = 0;
                Total_Slot24 = 0;

                Total_PassFinish1 = 0;
                Total_PassFinish2 = 0;
                Total_PassFinish3 = 0;
                Total_PassFinish4 = 0;
                Total_PassFinish5 = 0;
                Total_PassFinish6 = 0;
                Total_PassFinish7 = 0;
                Total_PassFinish8 = 0;
                Total_PassFinish9 = 0;
                Total_PassFinish10 = 0;
                Total_PassFinish11 = 0;
                Total_PassFinish12 = 0;
                Total_PassFinish13 = 0;
                Total_PassFinish14 = 0;
                Total_PassFinish15 = 0;
                Total_PassFinish16 = 0;
                Total_PassFinish17 = 0;
                Total_PassFinish18 = 0;
                Total_PassFinish19 = 0;
                Total_PassFinish20 = 0;
                Total_PassFinish21 = 0;
                Total_PassFinish22 = 0;
                Total_PassFinish23 = 0;
                Total_PassFinish24 = 0;
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
                //Delaytxt = lblDelay.Text;
                //if (Delaytxt.IndexOf("Days", StringComparison.CurrentCultureIgnoreCase) > -1)
                //{
                //    if (Delaytxt.IndexOf("-", StringComparison.CurrentCultureIgnoreCase) > -1)
                //    {
                //        lblDelay.Style.Add("Color", "green");
                //    }
                //    else
                //    {
                //        lblDelay.Style.Add("Color", "red");
                //    }
                //}
                //else
                //{
                //    lblDelay.Style.Remove("Color");
                //    lblDelay.Style.Add("Color", "black");
                //}
                //if (lblDelay.Text != "")
                //{
                //    tdDelay.Style.Add("background-color", "#FF0000");
                //}

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
                    lblAccessCount.Text = " A(" + lblAccessCount.Text + "),";
                }
                else
                {
                    //lblAccessCount.Text = " A";
                    lblAccessCount.Text = "";
                }
               
                if (lblLinePlanDate.Text != "")
                {
                    lblLinePlanDate.Text = Convert.ToDateTime(lblLinePlanDate.Text).ToString("MM-dd-yyyy");
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
                    
                }
               
            }
        }

        protected void rptPlanningDelay_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //Label lblClosingTime = e.Item.FindControl("lblClosingTime") as Label;
                Label lblDelay = e.Item.FindControl("lblDelay") as Label;
                //Label lblFabricCount = e.Item.FindControl("lblFabricCount") as Label;
                //Label lblAccessCount = e.Item.FindControl("lblAccessCount") as Label;
                //Label lblLinePlanDate = e.Item.FindControl("lblLinePlanDate") as Label;
                HtmlTableCell tdDelay = (HtmlTableCell)e.Item.FindControl("tdDelay");
                string Delaytxt = "";

                //if (lblClosingTime.Text != "")
                //{
                //    string[] stime = lblClosingTime.Text.Split(':');
                //    int iTimeHrs = Convert.ToInt32(stime[0]);
                //    int iTimeMins = Convert.ToInt32(stime[1]);
                //    var timespan = new TimeSpan(iTimeHrs, iTimeMins, 00);
                //    var output = new DateTime().Add(timespan).ToString("hh:mm tt");
                //    lblClosingTime.Text = output;
                //}
                Delaytxt = lblDelay.Text;
                if (Delaytxt.IndexOf("Days", StringComparison.CurrentCultureIgnoreCase) > -1)
                {
                    if (Delaytxt.IndexOf("-", StringComparison.CurrentCultureIgnoreCase) > -1)
                    {
                        //lblDelay.Style.Add("Color", "green");
                        tdDelay.Style.Add("background-color", "green");
                    }
                    else
                    {
                        //lblDelay.Style.Add("Color", "red");
                        tdDelay.Style.Add("background-color", "#FF0000");
                    }
                }
                else
                {
                    lblDelay.Style.Remove("Color");
                    lblDelay.Style.Add("Color", "black");
                    tdDelay.Style.Add("background-color", "#FFffff");
                }
                //if (lblDelay.Text != "")
                //{
                //    tdDelay.Style.Add("background-color", "#FF0000");
                //}

                //if (lblFabricCount.Text != "0")
                //{
                //    lblFabricCount.Text = "F(" + lblFabricCount.Text + "),";
                //}
                //else
                //{
                //    //lblFabricCount.Text = "F,";
                //    lblFabricCount.Text = "";
                //}
                //if (lblAccessCount.Text != "0")
                //{
                //    lblAccessCount.Text = " A(" + lblAccessCount.Text + "),";
                //}
                //else
                //{
                //    //lblAccessCount.Text = " A";
                //    lblAccessCount.Text = "";
                //}

                //if (lblLinePlanDate.Text != "")
                //{
                //    lblLinePlanDate.Text = Convert.ToDateTime(lblLinePlanDate.Text).ToString("dd-MM-yyyy");
                //}
            }
        }

        private void HideStitchingUnUsedSlot()
        {
            SlotId = Convert.ToInt32(hdnSlotId.Value);
            SlotId = SlotId + 5;
            for (int i = SlotId; i < 29; i++)
            {
                gvHourlyStitchingReport1.Columns[i].Visible = false;     
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
            string strMailBody = GetGridviewData(gvHourlyStitchingReport1);
        }

       
               
        
    }
}