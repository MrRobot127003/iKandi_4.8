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
using System.Globalization;
using System.Threading;
using System.Drawing;
using System.IO;
//using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iKandi.BLL;


namespace iKandi.Web
{
    public partial class FrmActivityQALaxmanReport : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        CommonController objCommon = new CommonController();

        DataTable dtitem = new DataTable();
        DataTable dtitemfoter = new DataTable();


        DataTable dtitem_ic = new DataTable();
        DataTable dtitem_ic_foter = new DataTable();


        DataTable dtitem_pending = new DataTable();
        DataTable dtitem_ic_foterpening = new DataTable();



        DataSet ds = new DataSet();


        DataSet ds_ic = new DataSet();
        DataSet ds_p = new DataSet();
        //------------------fourthgrid

        DataSet ds_cumlative = new DataSet();
        DataTable dt_cumlaive = new DataTable();

        //---------------------5th gridHoppm

        DataSet ds_hoppm = new DataSet();
        DataTable dtitem_hoppm = new DataTable();
        DataTable dtfoter_hoppm = new DataTable();

        DataTable dtpendingCount = new DataTable();
        DataTable dtpendingCountQaDone = new DataTable();



        public static int GetFaultqtySum = 0;
        public static double GetCtslVlaueSum = 0;

        public int DoneCountHoppm = 0;
        public int DoneCountRisk = 0;
        public int DoneCountTopSent = 0;
        public int DoneCountInline = 0;
        public int DoneCountOnline = 0;
        public int DoneCountFinal = 0;


        DataTable dtWeekRangeFoter = new DataTable();

        public int RiskCountC7 = 0;
        public int HOPPMCountC7 = 0;
        public int TopSentCountC7 = 0;
        public int InlineCountC7 = 0;
        public int OnlineCountC7 = 0;
        public int FinalCountC7 = 0;

        public int RiskCountC4647 = 0;
        public int HOPPMCountC4647 = 0;
        public int TopSentCountC4647 = 0;
        public int InlineCountC4647 = 0;
        public int OnlineCountC4647 = 0;
        public int FinalCountC4647 = 0;

        public int RiskCountbipl = 0;
        public int HOPPMCountbipl = 0;
        public int TopSentCountbipl = 0;
        public int InlineCountbipl = 0;
        public int OnlineCountbipl = 0;
        public int FinalCountbipl = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            //lbldate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
            //lbldates.Text = DateTime.Now.ToString("dd-MMM");
            //  Bindgrd();
            GetFaultqtySum = 0;
            GetCtslVlaueSum = 0;

            DateTime CommonDate = objCommon.GetCommonRptDateOnPage();

            if (CommonDate.Day == 1)
            {
                CommonDate = CommonDate.AddDays(-1);
            }

            Label3.Text = CommonDate.ToString("dd MMM yy (ddd)");
            // BindTopFaultGrd();
            tbllastMonth.Visible = false;
            tbllastDay.Visible = false;
            monthlyHead.Visible = false;
            //Add By Prabhaker
            string ComplienceAuditReport_UnitId_3_ProcessType_1_ReportHtml = "";
            string ComplienceAuditReport_UnitId_3_ProcessType_2_ReportHtml = "";
            string ComplienceAuditReport_UnitId_11_ProcessType_1_ReportHtml = "";
            string ComplienceAuditReport_UnitId_11_ProcessType_2_ReportHtml = "";
            string ComplienceAuditReport_UnitId_169_ProcessType_1_ReportHtml = "";
            string ComplienceAuditReport_UnitId_169_ProcessType_2_ReportHtml = "";
            //string ComplienceAuditReport_UnitId_120_ProcessType_1_ReportHtml = "";
            //string ComplienceAuditReport_UnitId_120_ProcessType_2_ReportHtml = "";
            //string Factory_SecifyQcFaultSummary_Reporthtml = "";
            string FactoryQC_Performance_ReportHtml = "";
            string LineManPerformance_Reporthtml = "";
            //string LineManAchievementPerformance_ReportHtml = "";
            string FrmQualityAudit_ReportHtml = "";
            string FrmComplianceAudit_ReportHtml = "";

            //DateTime now = DateTime.Now;

            

            string Day = CommonDate.ToString("dd");
            string Month = CommonDate.ToString("MMM");

            ComplienceAuditReport_UnitId_3_ProcessType_1_ReportHtml = "ComplienceAuditReport_UnitId_3_ProcessType_1_" + Day + "_" + Month + ".html";
            ComplienceAuditReport_UnitId_169_ProcessType_1_ReportHtml = "ComplienceAuditReport_UnitId_169_ProcessType_1_" + Day + "_" + Month + ".html";
            //ComplienceAuditReport_UnitId_120_ProcessType_1_ReportHtml = "ComplienceAuditReport_UnitId_120_ProcessType_1_" + Day + "_" + Month + ".html";
            QAComplienceMailunitId_3_Process_1.NavigateUrl = "http://boutique.in/Uploads/Audit_Report/" + ComplienceAuditReport_UnitId_3_ProcessType_1_ReportHtml;
            // QAComplienceMailunitId_3_Process_1.NavigateUrl = "http://www.boutique.in/Uploads/Audit_Report/" + ComplienceAuditReport_UnitId_3_ProcessType_1_ReportHtml;

            ComplienceAuditReport_UnitId_3_ProcessType_2_ReportHtml = "ComplienceAuditReport_UnitId_3_ProcessType_2_" + Day + "_" + Month + ".html";
            QAComplienceMailunitId_3_Process_2.NavigateUrl = "http://boutique.in/Uploads/Audit_Report/" + ComplienceAuditReport_UnitId_3_ProcessType_2_ReportHtml;
            // QAComplienceMailunitId_3_Process_2.NavigateUrl = "http://www.boutique.in/Uploads/Audit_Report/" + ComplienceAuditReport_UnitId_3_ProcessType_2_ReportHtml;

            ComplienceAuditReport_UnitId_11_ProcessType_1_ReportHtml = "ComplienceAuditReport_UnitId_11_ProcessType_1_" + Day + "_" + Month + ".html";
            QAComplienceMailunitId_11_Process_1.NavigateUrl = "http://boutique.in/Uploads/Audit_Report/" + ComplienceAuditReport_UnitId_11_ProcessType_1_ReportHtml;
            //QAComplienceMailunitId_169_Process_1.NavigateUrl = "http://boutique.in/Uploads/Audit_Report/" + ComplienceAuditReport_UnitId_169_ProcessType_1_ReportHtml;
            //QAComplienceMailunitId_120_Process_1.NavigateUrl = "http://boutique.in/Uploads/Audit_Report/" + ComplienceAuditReport_UnitId_120_ProcessType_1_ReportHtml;
            // QAComplienceMailunitId_11_Process_1.NavigateUrl = "http://www.boutique.in/Uploads/Audit_Report/" + ComplienceAuditReport_UnitId_11_ProcessType_1_ReportHtml;

            ComplienceAuditReport_UnitId_11_ProcessType_2_ReportHtml = "ComplienceAuditReport_UnitId_11_ProcessType_2_" + Day + "_" + Month + ".html";
            ComplienceAuditReport_UnitId_169_ProcessType_2_ReportHtml = "ComplienceAuditReport_UnitId_169_ProcessType_2_" + Day + "_" + Month + ".html";
            //ComplienceAuditReport_UnitId_120_ProcessType_2_ReportHtml = "ComplienceAuditReport_UnitId_120_ProcessType_2_" + Day + "_" + Month + ".html";
            QAComplienceMailunitId_11_Process_2.NavigateUrl = "http://boutique.in/Uploads/Audit_Report/" + ComplienceAuditReport_UnitId_11_ProcessType_2_ReportHtml;
           // QAComplienceMailunitId_169_Process_2.NavigateUrl = "http://boutique.in/Uploads/Audit_Report/" + ComplienceAuditReport_UnitId_169_ProcessType_2_ReportHtml;
            //QAComplienceMailunitId_120_Process_2.NavigateUrl = "http://boutique.in/Uploads/Audit_Report/" + ComplienceAuditReport_UnitId_120_ProcessType_2_ReportHtml;

            //Factory_SecifyQcFaultSummary_Reporthtml = "FrmProductionPerformanceQCFaultReport_" + Day + "_" + Month + ".html";
            //FactorySecifyQcFaultSummaryReport.NavigateUrl = "http://www.boutique.in/uploads/ProductionPerformance_Report/" + Factory_SecifyQcFaultSummary_Reporthtml;

            FactoryQC_Performance_ReportHtml = "FrmQCPerformanceReport_" + Day + "_" + Month + ".html";
            FrmQCPerformance_Report.NavigateUrl = "http://www.boutique.in/uploads/ProductionPerformance_Report/" + FactoryQC_Performance_ReportHtml;

            LineManPerformance_Reporthtml = "FrmLineManSumReport_" + Day + "_" + Month + ".html";
            LineManPerformanceReport.NavigateUrl = "http://www.boutique.in/uploads/ProductionPerformance_Report/" + LineManPerformance_Reporthtml;

            //LineManAchievementPerformance_ReportHtml = "FrmLineManAchivementPerReport_" + Day + "_" + Month + ".html";
            //LineManAchievementPerformanceReport.NavigateUrl = "http://www.boutique.in/uploads/ProductionPerformance_Report/" + LineManAchievementPerformance_ReportHtml;

            FrmComplianceAudit_ReportHtml = "FrmComplianceAuditC47_Report_" + Day + "_" + Month + ".html";
            FrmComplianceAudit.NavigateUrl = "http://www.boutique.in/uploads/ProductionPerformance_Report/" + FrmComplianceAudit_ReportHtml;

            FrmQualityAudit_ReportHtml = "FrmComplianceAuditC45_Report_" + Day + "_" + Month + ".html";
            FrmQualityAudit.NavigateUrl = "http://www.boutique.in/uploads/ProductionPerformance_Report/" + FrmQualityAudit_ReportHtml;



            // QAComplienceMailunitId_11_Process_2.NavigateUrl = "http://www.boutique.in:82/Uploads/Audit_Report/" + ComplienceAuditReport_UnitId_11_ProcessType_2_ReportHtml;
            //End Of Code

            DateTime d = CommonDate;
            if (!System.IO.Directory.Exists(Constants.PHOTO_FOLDER_PATH))
                System.IO.Directory.CreateDirectory(Constants.PHOTO_FOLDER_PATH);

            //     string fileName = d.ToString("D") + "_TopFualtPieChart_BIPL.png";
            //string FilePath = System.IO.Path.Combine(Constants.PHOTO_FOLDER_PATH, fileName);

            //string strpath = "http://www.boutique.in:82/Uploads/Photo/";
            //string strpath = "http://http://192.168.0.4/Uploads/Photo/";

            string fileName47 = "TopFualtPieChart_C47.png";
            string FilePath47 = System.IO.Path.Combine("http://192.168.0.4:81/pic/", fileName47);

            string fileName45 = "TopFualtPieChart_C45.png";
            string FilePath45 = System.IO.Path.Combine("http://192.168.0.4:81/pic/", fileName45);

            string fileName169 = "TopFualtPieChart_D_169.png";
            string FilePath169 = System.IO.Path.Combine("http://192.168.0.4:81/pic/", fileName169);

            string fileNameBipl = "TopFualtPieChart_BIPL.png";
            string FilePathbipl = System.IO.Path.Combine("http://192.168.0.4:81/pic/", fileNameBipl);

            //string fileNameCompliance47 = "Compliance_PieChart_C47.png";
            //string FilePathCompliance47 = System.IO.Path.Combine("http://192.168.0.4:81/pic/", fileNameCompliance47);

            //string fileNameCompliance45 = "Compliance_PieChart_C45.png";
            //string FilePathCompliance45 = System.IO.Path.Combine("http://192.168.0.4:81/pic/", fileNameCompliance45);

            //string fileNameComplianceBipl = "Compliance_PieChart_BIPL.png";
            //string FilePathCompliancebipl = System.IO.Path.Combine("http://192.168.0.4:81/pic/", fileNameComplianceBipl);


            string fileNameQA47 = "QC_PieChart_C47.png";
            string FilePathQA47 = System.IO.Path.Combine("http://192.168.0.4:81/pic/", fileNameQA47);

            string fileNameQAD169 = "QC_PieChart_D_169.png";
            string FilePathQAD169 = System.IO.Path.Combine("http://192.168.0.4:81/pic/", fileNameQAD169);

            string fileNameQA45 = "QC_PieChart_C45.png";
            string FilePathQA45 = System.IO.Path.Combine("http://192.168.0.4:81/pic/", fileNameQA45);

            string fileNameQABipl = "QC_PieChart_BIPL.png";
            string FilePathQAbipl = System.IO.Path.Combine("http://192.168.0.4:81/pic/", fileNameQABipl);

            string BIPLMonthlyCQDPASS_File = "BIPLMonthlyCQDPASS.png";
            string BIPLMonthlyCQDPASS_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", BIPLMonthlyCQDPASS_File);

            string BIPLMonthlyEff_File = "BIPLMonthlyEff.png";
            string BIPLMonthlyEff_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", BIPLMonthlyEff_File);

            string BIPLMonthlyFinishRate_File = "BIPLMonthlyFinishRate.png";
            string BIPLMonthlyFinishRate_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", BIPLMonthlyFinishRate_File);

            string BIPLMonthlyRescan_File = "BIPLMonthlyRescan.png";
            string BIPLMonthlyRescan_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", BIPLMonthlyRescan_File);

            string BIPLHRAuditMonthly_File = "BIPLHRAuditMonthly" + CommonDate.ToString("dd-MM-yyyy") + ".png";
            string BIPLHRAuditMonthly_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", BIPLHRAuditMonthly_File);

            string BIPLQualityAuditMonthly_File = "BIPLQualityAuditMonthly" + CommonDate.ToString("dd-MM-yyyy") + ".png";
            string BIPLQualityAuditMonthly_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", BIPLQualityAuditMonthly_File);

            string Cutting_Rate = "BIPLMonthlyCutRate.png";
            string Cutting_Rate_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", Cutting_Rate);

            string FinishedRate = "BIPLMonthlyEff.png";
            string FinishedRate_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", FinishedRate);
          //add code by Bharat on 09-Dec-19
            string BIPLCQDFaultsPackedMonthly_File = "BIPLCQDFaultsPackedMonthly" + CommonDate.ToString("dd-MM-yyyy") + ".png";
            string BIPLCQDFaultsPackedMonthly_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", BIPLCQDFaultsPackedMonthly_File);

            string BIPLMonthlyAchievement_File = "BIPLMonthlyAchievement.png";
            string BIPLMonthlyAchievement_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", BIPLMonthlyAchievement_File);

            //end
            c47.Src = FilePath47;
            c45.Src = FilePath45;
            d169.Src = FilePath169;
            bipl.Src = FilePathbipl;


            BIPLMonthlyAchievement.Src = BIPLMonthlyAchievement_Path;
            BIPLCQDFaultsPackedMonthly.Src = BIPLCQDFaultsPackedMonthly_Path;
            BIPLMonthlyCQDPASS.Src = BIPLMonthlyCQDPASS_Path;
            BIPLMonthlyEff.Src = BIPLMonthlyEff_Path;
            BIPLMonthlyFinishRate.Src = BIPLMonthlyFinishRate_Path;
            BIPLMonthlyRescan.Src = BIPLMonthlyRescan_Path;
            BIPLHRAuditMonthly.Src = BIPLHRAuditMonthly_Path;
            BIPLQualityAuditMonthly.Src = BIPLQualityAuditMonthly_Path;
            BIPL_CuttingRate.Src = Cutting_Rate_Path;
            BIPL_FinishedRate.Src = FinishedRate_Path;

            //Compliance_c47.Src = FilePathCompliance47;
            //Compliance_c45.Src = FilePathCompliance45;
            //Compliance_bipl.Src = FilePathCompliancebipl;

            QA_c47.Src = FilePathQA47;
            QA_c45.Src = FilePathQA45;
            QA_d169.Src = FilePathQAD169;
            QA_bipl.Src = FilePathQAbipl;
        }
        //public void BindTopFaultGrd()
        //{
        //    DataTable table = new DataTable();
        //    table.Columns.Add("Duration", typeof(int));
        //    table.Columns.Add("Last", typeof(string));
        //    table.Columns.Add("Month", typeof(string));


        //    table.Rows.Add(1, "Last 1", "Month");
        //    table.Rows.Add(3, "Last 3", "Month");
        // table.Rows.Add(12, "Last", "Year");

        //grdtopFaultDetails.DataSource = table;
        //grdtopFaultDetails.DataBind();

        //grdtopFaultDetails46.DataSource = table;
        //grdtopFaultDetails46.DataBind();

        //grdtopFaultDetailsbipl.DataSource = table;
        //grdtopFaultDetailsbipl.DataBind();



        //}
        public void Bindgrd()
        {

            ds = objadmin.GetShipmetReport("DAILYSHIPMENT");

            dtitem = ds.Tables[0];
            dtitemfoter = ds.Tables[1];
            //grdshipmentBydate.DataSource = dtitem;
            //grdshipmentBydate.DataBind();

            //second grid for icbipl

            ds_ic = objadmin.GetShipmetReport("ICREPORT");

            dtitem_ic = ds_ic.Tables[0];
            dtitem_ic_foter = ds_ic.Tables[1];
            //grdShipmentICbipl.DataSource = dtitem_ic;
            //grdShipmentICbipl.DataBind();


            //third grid for shipment pending

            ds_p = objadmin.GetShipmetReport("SHIPMENTPLANING");

            dtitem_pending = ds_p.Tables[0];
            dtitem_ic_foterpening = ds_p.Tables[1];
            //grdpendingshipment.DataSource = dtitem_pending;
            //grdpendingshipment.DataBind();


            //fourth grid for shipment pending

            ds_cumlative = objadmin.GetShipmetReport("SHIPMENTREPORTCUMLATIV");
            dt_cumlaive = ds_cumlative.Tables[0];
            gridshipemtNew.DataSource = dt_cumlaive;
            gridshipemtNew.DataBind();
            getShipmentReportCummlative();



            DataSet ds_hoppm = new DataSet();
            DataTable dtitem_hoppm = new DataTable();
            DataTable dtfoter_hoppm = new DataTable();
            //5th grid hoppm-------------//

            ds_hoppm = objadmin.GetShipmetReport("HOPPM");
            dtitem_hoppm = ds_hoppm.Tables[0];
            dtfoter_hoppm = ds_hoppm.Tables[1];


            //-------------sum count-------------------//
            object sumObjecthoppm;
            sumObjecthoppm = dtitem_hoppm.Compute("Sum(HoppmPendingCount)", "");

            if (sumObjecthoppm.ToString() == "0" || sumObjecthoppm.ToString() == "")
            {
                sumObjecthoppm = Convert.ToString(0);
            }
            object sumObjectrisk;
            sumObjectrisk = dtitem_hoppm.Compute("Sum(RiskPendingCount)", "");

            if (sumObjectrisk.ToString() == "0" || sumObjectrisk.ToString() == "")
            {
                sumObjectrisk = Convert.ToString(0);
            }
            object sumObjectTopSent;
            sumObjectTopSent = dtitem_hoppm.Compute("Sum(TopSentPendingCount)", "");

            if (sumObjectTopSent.ToString() == "0" || sumObjectTopSent.ToString() == "")
            {
                sumObjectTopSent = Convert.ToString(0);
            }
            object sumObjectinline;
            sumObjectinline = dtitem_hoppm.Compute("Sum(inlinePendingCount)", "");

            if (sumObjectinline.ToString() == "0" || sumObjectinline.ToString() == "")
            {
                sumObjectinline = Convert.ToString(0);
            }


            object sumObjectonline;
            sumObjectonline = dtitem_hoppm.Compute("Sum(OnlinePendingCount)", "");

            if (sumObjectonline.ToString() == "0" || sumObjectonline.ToString() == "")
            {
                sumObjectonline = Convert.ToString(0);
            }
            object sumObjectfinal;
            sumObjectfinal = dtitem_hoppm.Compute("Sum(finalPendingCount)", "");

            if (sumObjectfinal.ToString() == "0" || sumObjectfinal.ToString() == "")
            {
                sumObjectfinal = Convert.ToString(0);
            }
            //-------------sum count end-------------------//




            dtpendingCount.Columns.Add("hoppm");
            dtpendingCount.Columns.Add("Risk");

            dtpendingCount.Columns.Add("topsent");
            dtpendingCount.Columns.Add("inline");
            dtpendingCount.Columns.Add("online");
            dtpendingCount.Columns.Add("finish");


            dtpendingCount.Rows.Add(new object[] { sumObjecthoppm, sumObjectrisk, sumObjectTopSent, sumObjectinline, sumObjectonline, sumObjectfinal });
            dtpendingCount.AcceptChanges();

            grdhoppminspection.DataSource = dtitem_hoppm;
            grdhoppminspection.DataBind();
            grdhoppminspection.Visible = false;

            //-------------------------------------QA pending last day---------------------------------------------//

            DataSet ds_qapending = new DataSet();
            DataTable dtitem_qapending = new DataTable();
            DataTable dtfoter_qapending = new DataTable();
            //5th grid hoppm-------------//

            ds_qapending = objadmin.GetShipmetReport("QAPENDING");
            dtitem_qapending = ds_qapending.Tables[0];
            dtfoter_qapending = ds_qapending.Tables[1];



            //-------------sum count-------------------//
            object sumObjectQadone;
            sumObjectQadone = dtitem_hoppm.Compute("Sum(HoppmPendingCount)", "");

            if (sumObjectQadone.ToString() == "0" || sumObjectQadone.ToString() == "")
            {
                sumObjectQadone = Convert.ToString(0);
            }
            object sumObjectriskQadone;
            sumObjectriskQadone = dtitem_hoppm.Compute("Sum(RiskPendingCount)", "");

            if (sumObjectriskQadone.ToString() == "0" || sumObjectriskQadone.ToString() == "")
            {
                sumObjectriskQadone = Convert.ToString(0);
            }
            object sumObjectTopSentQadone;
            sumObjectTopSentQadone = dtitem_hoppm.Compute("Sum(TopSentPendingCount)", "");

            if (sumObjectTopSentQadone.ToString() == "0" || sumObjectTopSentQadone.ToString() == "")
            {
                sumObjectTopSentQadone = Convert.ToString(0);
            }
            object sumObjectinlineQadone;
            sumObjectinlineQadone = dtitem_hoppm.Compute("Sum(inlinePendingCount)", "");

            if (sumObjectinlineQadone.ToString() == "0" || sumObjectinlineQadone.ToString() == "")
            {
                sumObjectinlineQadone = Convert.ToString(0);
            }


            object sumObjectonlineQadone;
            sumObjectonlineQadone = dtitem_hoppm.Compute("Sum(OnlinePendingCount)", "");

            if (sumObjectonlineQadone.ToString() == "0" || sumObjectonlineQadone.ToString() == "")
            {
                sumObjectonlineQadone = Convert.ToString(0);
            }
            object sumObjectfinalQadone;
            sumObjectfinalQadone = dtitem_hoppm.Compute("Sum(finalPendingCount)", "");

            if (sumObjectfinalQadone.ToString() == "0" || sumObjectfinalQadone.ToString() == "")
            {
                sumObjectfinalQadone = Convert.ToString(0);
            }





            dtpendingCountQaDone.Columns.Add("hoppm");
            dtpendingCountQaDone.Columns.Add("Risk");

            dtpendingCountQaDone.Columns.Add("topsent");
            dtpendingCountQaDone.Columns.Add("inline");
            dtpendingCountQaDone.Columns.Add("online");
            dtpendingCountQaDone.Columns.Add("finish");


            dtpendingCountQaDone.Rows.Add(new object[] { sumObjectQadone, sumObjectriskQadone, sumObjectTopSentQadone, sumObjectinlineQadone, sumObjectonlineQadone, sumObjectfinalQadone });
            dtpendingCountQaDone.AcceptChanges();

            //-------------sum count end-------------------//


            if (dtitem_qapending.Rows.Count > 0)
            {
                grdqadone.DataSource = dtitem_qapending;
                grdqadone.DataBind();
                grdqadone.Visible = false;
            }
            else
            {
                grdqadone.DataSource = null;
                grdqadone.DataBind();
                grdqadone.Visible = false;
            }

        }
        
        protected void grdshipmentBydate_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Footer)
            {

                HtmlGenericControl sptotcalcut = (HtmlGenericControl)e.Row.FindControl("sptotcalcut");
                HtmlGenericControl sptotalcontract = (HtmlGenericControl)e.Row.FindControl("sptotalcontract");

                HtmlGenericControl spTotalStitch = (HtmlGenericControl)e.Row.FindControl("spTotalStitch");
                HtmlGenericControl spTotalShippedQty = (HtmlGenericControl)e.Row.FindControl("spTotalShippedQty");
                HtmlGenericControl CTSL = (HtmlGenericControl)e.Row.FindControl("CTSL");
                HtmlGenericControl spShippedValue = (HtmlGenericControl)e.Row.FindControl("spShippedValue");
                HtmlGenericControl spCIF = (HtmlGenericControl)e.Row.FindControl("spCIF");

                HtmlGenericControl spInspection = (HtmlGenericControl)e.Row.FindControl("spInspection");
                HtmlGenericControl spTotalPenalty = (HtmlGenericControl)e.Row.FindControl("spTotalPenalty");

                HtmlGenericControl spPenalty = (HtmlGenericControl)e.Row.FindControl("spPenalty");
                HtmlGenericControl spExpressAirline = (HtmlGenericControl)e.Row.FindControl("spExpressAirline");
                HtmlGenericControl sp50CIF = (HtmlGenericControl)e.Row.FindControl("sp50CIF");
                HtmlGenericControl sptotalAirToMumbai = (HtmlGenericControl)e.Row.FindControl("sptotalAirToMumbai");

                HtmlGenericControl spctslqntySum = (HtmlGenericControl)e.Row.FindControl("spctslqntySum");
                HtmlGenericControl spvalue = (HtmlGenericControl)e.Row.FindControl("spvalue");

                if (GetFaultqtySum != 0)
                {
                    spctslqntySum.InnerText = GetFaultqtySum.ToString();
                }
                if (GetCtslVlaueSum.ToString() != "0" && GetCtslVlaueSum.ToString() != "0.0")
                {
                    spvalue.InnerText = "\u20B9 " + GetCtslVlaueSum.ToString() + " k";
                }

                //HtmlGenericControl sppenaltypercentage = (HtmlGenericControl)e.Row.FindControl("spTotalPenalty");
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[0].Attributes.Add("colspan", "2");

                if (dtitemfoter.Rows[0]["totalcutQty"].ToString() != "" && dtitemfoter.Rows[0]["totalcutQty"].ToString() != "0" && dtitemfoter.Rows[0]["totalcutQty"].ToString() != "0.0")
                {
                    sptotcalcut.InnerText = Convert.ToInt32(dtitemfoter.Rows[0]["totalcutQty"].ToString()).ToString("N0") + " " + "Pcs";

                }

                if (dtitemfoter.Rows[0]["totalstichQty"].ToString() != "" && dtitemfoter.Rows[0]["totalstichQty"].ToString() != "0" && dtitemfoter.Rows[0]["totalstichQty"].ToString() != "0.0")
                {
                    spTotalStitch.InnerText = Convert.ToInt32(dtitemfoter.Rows[0]["totalstichQty"].ToString()).ToString("N0") + " " + "Pcs";
                }


                if (dtitemfoter.Rows[0]["totalshippedqty"].ToString() != "" && dtitemfoter.Rows[0]["totalshippedqty"].ToString() != "0" && dtitemfoter.Rows[0]["totalshippedqty"].ToString() != "0.0")
                {
                    spTotalShippedQty.InnerText = Convert.ToInt32(dtitemfoter.Rows[0]["totalshippedqty"].ToString()).ToString("N0") + " " + "Pcs";
                }

                if (dtitemfoter.Rows[0]["totalCtsl"].ToString() != "" && dtitemfoter.Rows[0]["totalCtsl"].ToString() != "0" && dtitemfoter.Rows[0]["totalCtsl"].ToString() != "0.0")
                {
                    CTSL.InnerText = dtitemfoter.Rows[0]["totalCtsl"].ToString() + "%";
                }

                if (dtitemfoter.Rows[0]["ShippedValueFoter"].ToString() != "" && dtitemfoter.Rows[0]["ShippedValueFoter"].ToString() != "0" && dtitemfoter.Rows[0]["ShippedValueFoter"].ToString() != "0.0")
                {
                    spShippedValue.InnerText = "\u20B9 " + dtitemfoter.Rows[0]["ShippedValueFoter"].ToString() + " Cr";
                }

                if (dtitemfoter.Rows[0]["totalCIFAirFoter"].ToString() != "" && dtitemfoter.Rows[0]["totalCIFAirFoter"].ToString() != "0" && dtitemfoter.Rows[0]["totalCIFAirFoter"].ToString() != "0.0")
                {
                    spCIF.InnerText = "\u20B9 " + Convert.ToInt32(dtitemfoter.Rows[0]["totalCIFAirFoter"].ToString()).ToString("N0");
                }

                if (dtitemfoter.Rows[0]["Totoal_InspectionFailandTransport"].ToString() != "" && dtitemfoter.Rows[0]["Totoal_InspectionFailandTransport"].ToString() != "0" && dtitemfoter.Rows[0]["Totoal_InspectionFailandTransport"].ToString() != "0.0")
                {
                    spInspection.InnerText = "\u20B9 " + dtitemfoter.Rows[0]["Totoal_InspectionFailandTransport"].ToString();
                }

                if (dtitemfoter.Rows[0]["totalExpressAirline"].ToString() != "" && dtitemfoter.Rows[0]["totalExpressAirline"].ToString() != "0" && dtitemfoter.Rows[0]["totalExpressAirline"].ToString() != "0.0")
                {
                    spExpressAirline.InnerText = "\u20B9 " + dtitemfoter.Rows[0]["totalExpressAirline"].ToString();
                }


                if (dtitemfoter.Rows[0]["totalAirToMumbai"].ToString() != "" && dtitemfoter.Rows[0]["totalAirToMumbai"].ToString() != "0" && dtitemfoter.Rows[0]["totalAirToMumbai"].ToString() != "0.0")
                {
                    //sptotalAirToMumbai.InnerText = dtitemfoter.Rows[0]["totalAirToMumbai"].ToString();
                    sptotalAirToMumbai.InnerText = "\u20B9 " + Math.Round(Convert.ToDouble(dtitemfoter.Rows[0]["totalAirToMumbai"].ToString()), 3, MidpointRounding.AwayFromZero).ToString("N0");
                }


                if (dtitemfoter.Rows[0]["TotalFiftyPercentCIFAir"].ToString() != "" && dtitemfoter.Rows[0]["TotalFiftyPercentCIFAir"].ToString() != "0" && dtitemfoter.Rows[0]["TotalFiftyPercentCIFAir"].ToString() != "0.0")
                {
                    //sp50CIF.InnerText = "\u20B9 " + dtitemfoter.Rows[0]["TotalFiftyPercentCIFAir"].ToString();
                    sp50CIF.InnerText = "\u20B9 " + Math.Round(Convert.ToDouble(dtitemfoter.Rows[0]["TotalFiftyPercentCIFAir"].ToString()), 3, MidpointRounding.AwayFromZero).ToString("N0");
                }
                //if (dtitemfoter.Rows[0]["TotalPenalty"].ToString() != "" && dtitemfoter.Rows[0]["TotalPenalty"].ToString() != "0")
                //{
                //    spPenalty.InnerText = "\u20B9 " + dtitemfoter.Rows[0]["TotalPenalty"].ToString()+"Lac";
                //}

                if (dtitemfoter.Rows[0]["totalPelantyAge"].ToString() != "" && dtitemfoter.Rows[0]["totalPelantyAge"].ToString() != "0" && dtitemfoter.Rows[0]["totalPelantyAge"].ToString() != "0.0")
                {
                    spPenalty.InnerText = dtitemfoter.Rows[0]["totalPelantyAge"].ToString() + "" + "%";
                }
                if (dtitemfoter.Rows[0]["TotalPenalty"].ToString() != "" && dtitemfoter.Rows[0]["TotalPenalty"].ToString() != "0" && dtitemfoter.Rows[0]["TotalPenalty"].ToString() != "0.0")
                {
                    spTotalPenalty.InnerText = "\u20B9 " + dtitemfoter.Rows[0]["TotalPenalty"].ToString() + "" + " Lacs";
                }
                if (dtitemfoter.Rows[0]["ContractQty"].ToString() != "" && dtitemfoter.Rows[0]["ContractQty"].ToString() != "0" && dtitemfoter.Rows[0]["ContractQty"].ToString() != "0.0")
                {
                    sptotalcontract.InnerText = Convert.ToInt32(dtitemfoter.Rows[0]["ContractQty"].ToString()).ToString("N0") + " " + "Pcs";
                }

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                Label lblContactNo = (Label)e.Row.FindControl("lblContactNo");
                Label lblLineitemNo = (Label)e.Row.FindControl("lblLineitemNo");

                HiddenField OrderDeatilID = (HiddenField)e.Row.FindControl("OrderDeatilID");

                Label lbltotalcutqty = (Label)e.Row.FindControl("lbltotalcutqty");
                Label lblctsldetaild = (Label)e.Row.FindControl("lblctsldetaild");


                DataSet ds = new DataSet();
                DataTable dt_c45 = new DataTable();
                DataTable dtfoterfualt = new DataTable();
                ds = objadmin.GetFualtName(Convert.ToInt32(OrderDeatilID.Value));
                dt_c45 = ds.Tables[0];
                dtfoterfualt = ds.Tables[1];

                //lblctsldetaild.Text = dt_c45.Rows[0][0].ToString();

                Label lblqntysum = (Label)e.Row.FindControl("lblqntysum");
                Label lblctslsum = (Label)e.Row.FindControl("lblctslsum");
                Label lblvaluetotal = (Label)e.Row.FindControl("lblvaluetotal");

                Repeater rptctsldetails = e.Row.FindControl("rptctsldetails") as Repeater;
                Label lblctsl = (Label)rptctsldetails.FindControl("lblctsl");


                HtmlTableRow tdrp = (HtmlTableRow)e.Row.FindControl("tdrp");

                if (rptctsldetails != null)
                {
                    if (dt_c45.Rows.Count > 0)
                    {
                        rptctsldetails.DataSource = dt_c45;
                        rptctsldetails.DataBind();

                        //lblctsl.Text = lblctsl.Text + "%";
                    }
                    else
                    {
                        tdrp.Visible = false;
                    }
                    lblqntysum.Text = dtfoterfualt.Rows[0]["sumqty"].ToString();
                    if (dtfoterfualt.Rows[0]["sumctsl"].ToString() == "0" || dtfoterfualt.Rows[0]["sumctsl"].ToString() == "0.0")
                    {
                        lblctslsum.Text = "";
                    }
                    else
                    {
                        lblctslsum.Text = dtfoterfualt.Rows[0]["sumctsl"].ToString() + "%";
                    }

                    if (dtfoterfualt.Rows[0]["Ctslweektotal"].ToString() == "0" || dtfoterfualt.Rows[0]["Ctslweektotal"].ToString() == "0.0")
                    {
                        lblvaluetotal.Text = "";
                    }
                    else
                    {
                        lblvaluetotal.Text = "\u20B9 " + dtfoterfualt.Rows[0]["Ctslweektotal"].ToString() + " k";
                    }

                }



                if (lbltotalcutqty.Text != "" && lbltotalcutqty.Text != "0" && lbltotalcutqty.Text != "0.0")
                {
                    lbltotalcutqty.Text = Convert.ToInt32(lbltotalcutqty.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lbltotalcutqty.Text = "";
                }

                Label lbltotalcontractqty = (Label)e.Row.FindControl("lbltotalcontractqty");
                if (lbltotalcontractqty.Text != "" && lbltotalcontractqty.Text != "0" && lbltotalcontractqty.Text != "0.0")
                {
                    lbltotalcontractqty.Text = Convert.ToInt32(lbltotalcontractqty.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lbltotalcontractqty.Text = "";
                }



                Label lbltotalstich = (Label)e.Row.FindControl("lbltotalstich");

                if (lbltotalstich.Text != "" && lbltotalstich.Text != "0" && lbltotalstich.Text != "0.0")
                {
                    lbltotalstich.Text = Convert.ToInt32(lbltotalstich.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lbltotalstich.Text = "";
                }


                Label lblTotalShippedQty = (Label)e.Row.FindControl("lblTotalShippedQty");

                if (lblTotalShippedQty.Text != "" && lblTotalShippedQty.Text != "0" && lblTotalShippedQty.Text != "0.0")
                {
                    lblTotalShippedQty.Text = Convert.ToInt32(lblTotalShippedQty.Text).ToString("N0") + " pcs";
                }
                else
                {
                    lblTotalShippedQty.Text = "";
                }


                Label lblCTSL = (Label)e.Row.FindControl("lblCTSL");


                if (lblCTSL.Text != "" && lblCTSL.Text != "0" && lblCTSL.Text != "0.0")
                {
                    lblCTSL.Text = lblCTSL.Text.ToString() + " %";
                }
                else
                {
                    lblCTSL.Text = "";
                }

                Label lblPrice = (Label)e.Row.FindControl("lblPrice");
                HiddenField hdnCurrenyTag = (HiddenField)e.Row.FindControl("hdnCurrenyTag");

                string StrTag = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType((Convert.ToInt32(hdnCurrenyTag.Value)));

                if (lblPrice.Text != "" && lblPrice.Text != "0" && lblPrice.Text != "0.0")
                {
                    lblPrice.Text = StrTag + " " + Math.Round(Convert.ToDouble(lblPrice.Text), 2, MidpointRounding.AwayFromZero).ToString();
                    //lblPrice.Text = StrTag+" "+ lblPrice.Text.ToString();
                }
                else
                {
                    lblPrice.Text = "";
                }

                Label lblShippedValue = (Label)e.Row.FindControl("lblShippedValue");

                if (lblShippedValue.Text != "" && lblShippedValue.Text != "0" && lblShippedValue.Text != "0.0")
                {
                    //lblShippedValue.Text = "\u20B9 " + lblShippedValue.Text.ToString();
                    lblShippedValue.Text = "\u20B9 " + Math.Round(Convert.ToDouble(lblShippedValue.Text), 2, MidpointRounding.AwayFromZero);
                }
                else
                {
                    lblShippedValue.Text = "";
                }

                Label lblExpressAirline = (Label)e.Row.FindControl("lblExpressAirline");

                if (lblExpressAirline.Text != "" && lblExpressAirline.Text != "0" && lblExpressAirline.Text != "0.0")
                {
                    lblExpressAirline.Text = "\u20B9" + " " + lblExpressAirline.Text.ToString();
                }
                else
                {
                    lblExpressAirline.Text = "";
                }
                Label lblCIFAir = (Label)e.Row.FindControl("lblCIFAir");
                if (lblCIFAir.Text != "" && lblCIFAir.Text != "0" && lblCIFAir.Text != "0.0")
                {

                    lblCIFAir.Text = "\u20B9 " + Math.Round(Convert.ToDouble(lblCIFAir.Text), 3, MidpointRounding.AwayFromZero).ToString("N0");
                }
                else
                {
                    lblCIFAir.Text = "";
                }
                Label lbl50CIF = (Label)e.Row.FindControl("lbl50CIF");

                if (lbl50CIF.Text != "" && lbl50CIF.Text != "0" && lbl50CIF.Text != "0.0")
                {
                    lbl50CIF.Text = "\u20B9 " + Math.Round(Convert.ToDouble(lbl50CIF.Text), 3, MidpointRounding.AwayFromZero).ToString("N0");
                }
                else
                {
                    lbl50CIF.Text = "";
                }

                Label lblAirToMumbai = (Label)e.Row.FindControl("lblAirToMumbai");

                if (lblAirToMumbai.Text != "" && lblAirToMumbai.Text != "0" && lblAirToMumbai.Text != "0.0")
                {
                    lblAirToMumbai.Text = "\u20B9 " + Math.Round(Convert.ToDouble(lblAirToMumbai.Text), 3, MidpointRounding.AwayFromZero).ToString("N0");
                }
                else
                {
                    lblAirToMumbai.Text = "";
                }



                Label lblInspectionFailandTransport = (Label)e.Row.FindControl("lblInspectionFailandTransport");

                if (lblInspectionFailandTransport.Text != "" && lblInspectionFailandTransport.Text != "0" && lblInspectionFailandTransport.Text != "0.0")
                {
                    lblInspectionFailandTransport.Text = "\u20B9 " + Math.Round(Convert.ToDouble(lblInspectionFailandTransport.Text), 3, MidpointRounding.AwayFromZero).ToString("N0");
                }
                else
                {
                    lblInspectionFailandTransport.Text = "";
                }


                Label lblTotalPenalty = (Label)e.Row.FindControl("lblTotalPenalty");

                if (lblTotalPenalty.Text != "" && lblTotalPenalty.Text != "0" && lblTotalPenalty.Text != "0.0")
                {
                    lblTotalPenalty.Text = "\u20B9 " + Math.Round(Convert.ToDouble(lblTotalPenalty.Text), 3, MidpointRounding.AwayFromZero).ToString("N0");

                }
                else
                {
                    lblTotalPenalty.Text = "";
                }



                Label lblPenaltyPercentAge = (Label)e.Row.FindControl("lblPenaltyPercentAge");

                if (lblPenaltyPercentAge.Text != "" && lblPenaltyPercentAge.Text != "0" && lblPenaltyPercentAge.Text != "0.0")
                {
                    lblPenaltyPercentAge.Text = lblPenaltyPercentAge.Text + "%";

                    //lblPenaltyPercentAge.Text = Math.Round(Convert.ToDouble(lblPenaltyPercentAge.Text), 3, MidpointRounding.AwayFromZero).ToString("N0") + "%";
                }
                else
                {
                    lblPenaltyPercentAge.Text = "";
                }

                //Label lblinlineinspectiondate_Name = (Label)e.Row.FindControl("lblinlineinspectiondate_Name");
                //Label lblMidinspectiondateand_Name = (Label)e.Row.FindControl("lblMidinspectiondateand_Name");
                //Label lblFinalinspectiondate_Name = (Label)e.Row.FindControl("lblFinalinspectiondate_Name");
                //Label lblFinalBIHinspectiondate_Name = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name");


                //lblinlineinspectiondate_Name.Text = lblinlineinspectiondate_Name.Text != "" ? Convert.ToDateTime(lblinlineinspectiondate_Name.Text).ToString("dd MMM yy (ddd)") : "";
                //lblMidinspectiondateand_Name.Text = lblMidinspectiondateand_Name.Text != "" ? Convert.ToDateTime(lblMidinspectiondateand_Name.Text).ToString("dd MMM yy (ddd)") : "";
                //lblFinalinspectiondate_Name.Text = lblFinalinspectiondate_Name.Text != "" ? Convert.ToDateTime(lblFinalinspectiondate_Name.Text).ToString("dd MMM yy (ddd)") : "";
                //lblFinalBIHinspectiondate_Name.Text = lblFinalBIHinspectiondate_Name.Text != "" ? Convert.ToDateTime(lblFinalBIHinspectiondate_Name.Text).ToString("dd MMM yy (ddd)") : "";

                ////string strInline;
                ////Label lblinlineinspectiondate_Name_username = (Label)e.Row.FindControl("lblinlineinspectiondate_Name_username");

                ////if (lblinlineinspectiondate_Name_username.Text != "")
                ////{

                ////    string[] str = lblinlineinspectiondate_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                ////    if (str.Length > 1)
                ////    {
                ////        if (str[1].ToString() != "" && str.Length == 2)
                ////        {
                ////            lblinlineinspectiondate_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
                ////            strInline="Inline fail"
                ////        }

                ////    }
                ////    if (str.Length > 1)
                ////    {
                ////        if (str[0].ToString() != "" && str.Length == 2)
                ////        {
                ////            lblinlineinspectiondate_Name_username.Text = str[0].ToString();


                ////        } 
                ////    }



                ////}
                ////Label lblMidinspectiondateand_Name_username = (Label)e.Row.FindControl("lblMidinspectiondateand_Name_username");

                ////if (lblMidinspectiondateand_Name_username.Text != "")
                ////{

                ////    string[] str = lblMidinspectiondateand_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                ////    if (str[0].ToString() != "" && str.Length == 2)
                ////    {
                ////        lblMidinspectiondateand_Name_username.Text = str[0].ToString();
                ////    }
                ////    if (str.Length > 1)
                ////    {
                ////        if (str[1].ToString() != "" && str.Length == 2)
                ////        {
                ////            lblMidinspectiondateand_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
                ////        }
                ////    }

                ////}

                ////Label lblFinalinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalinspectiondate_Name_username");

                ////if (lblFinalinspectiondate_Name_username.Text != "")
                ////{

                ////    string[] str = lblFinalinspectiondate_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                ////    if (str.Length > 1)
                ////    {
                ////        if (str[0].ToString() != "" && str.Length == 2)
                ////        {
                ////            lblFinalinspectiondate_Name_username.Text = str[0].ToString();
                ////        }
                ////    }
                ////    if (str.Length > 1)
                ////    {
                ////        if (str[1].ToString() != "" && str.Length == 2)
                ////        {
                ////            lblFinalinspectiondate_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
                ////        }
                ////    }

                ////}

                ////Label lblFinalBIHinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name_username");

                ////if (lblFinalBIHinspectiondate_Name_username.Text != "")
                ////{

                ////    string[] str = lblFinalBIHinspectiondate_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                ////    if (str[0].ToString() != "" && str.Length == 2)
                ////    {
                ////        lblFinalBIHinspectiondate_Name_username.Text = str[0].ToString();
                ////    }
                ////    if (str.Length > 1)
                ////    {
                ////        if (str[1].ToString() != "" && str.Length == 2)
                ////        {
                ////            lblFinalBIHinspectiondate_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
                ////        }
                ////    }


                ////}
                Label lblinlineinspectiondate_Name_username = (Label)e.Row.FindControl("lblinlineinspectiondate_Name_username");
                Label lblMidinspectiondateand_Name_username = (Label)e.Row.FindControl("lblMidinspectiondateand_Name_username");
                Label lblFinalinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalinspectiondate_Name_username");
                Label lblFinalBIHinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name_username");

                if (lblinlineinspectiondate_Name_username.Text == "")
                {
                    lblinlineinspectiondate_Name_username.Visible = false;
                }
                if (lblMidinspectiondateand_Name_username.Text == "")
                {
                    lblMidinspectiondateand_Name_username.Visible = false;
                }
                if (lblFinalinspectiondate_Name_username.Text == "")
                {
                    lblFinalinspectiondate_Name_username.Visible = false;
                }
                if (lblFinalBIHinspectiondate_Name_username.Text == "")
                {
                    lblFinalBIHinspectiondate_Name_username.Visible = false;
                }
                Label lblexfactdate = (Label)e.Row.FindControl("lblexfactdate");
                if (lblexfactdate.Text != "" && lblexfactdate != null)
                {
                    lblexfactdate.Text = Convert.ToDateTime(lblexfactdate.Text).ToString("dd MMM yy (ddd)");
                }


            }

        }

        protected void grdShipmentICbipl_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                HtmlGenericControl spanICTotalCut = (HtmlGenericControl)e.Row.FindControl("spanICTotalCut");
                HtmlGenericControl spanICstichTotal = (HtmlGenericControl)e.Row.FindControl("spanICstichTotal");
                HtmlGenericControl spanicfinsidhtotal = (HtmlGenericControl)e.Row.FindControl("spanicfinsidhtotal");
                HtmlGenericControl spOrderValueIctotal = (HtmlGenericControl)e.Row.FindControl("spOrderValueIctotal");

                HtmlGenericControl Strong8 = (HtmlGenericControl)e.Row.FindControl("spOrderValueIctotal");
                HtmlGenericControl spanICTotalContract = (HtmlGenericControl)e.Row.FindControl("spanICTotalContract");

                e.Row.Cells[1].Visible = false;
                e.Row.Cells[0].Attributes.Add("colspan", "2");

                if (dtitem_ic_foter.Rows[0]["totalcutQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["totalcutQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["totalcutQty"].ToString() != "0.0")
                {
                    spanICTotalCut.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["totalcutQty"].ToString()).ToString("N0") + " " + "Pcs";
                }

                if (dtitem_ic_foter.Rows[0]["totalstichQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["totalstichQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["totalstichQty"].ToString() != "0.0")
                {
                    spanICstichTotal.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["totalstichQty"].ToString()).ToString("N0") + " " + "Pcs";
                }


                if (dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString() != "0.0")
                {
                    spanicfinsidhtotal.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString()).ToString("N0") + " " + "Pcs";
                }



                if (dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "" && dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "0" && dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "0.0" && dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "0.00")
                {
                    spOrderValueIctotal.InnerText = "\u20B9 " + dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() + " Cr";
                }
                if (dtitem_ic_foter.Rows[0]["ContractQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["ContractQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["ContractQty"].ToString() != "0.0")
                {
                    spanICTotalContract.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["ContractQty"].ToString()).ToString("N0") + " " + "Pcs";
                }


            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblContactNo = (Label)e.Row.FindControl("lblContactNo");
                Label lblLineitemNo = (Label)e.Row.FindControl("lblLineitemNo");


                Label lbltotalcutqty = (Label)e.Row.FindControl("lbltotalcutqty");


                if (lbltotalcutqty.Text != "" && lbltotalcutqty.Text != "0")
                {
                    lbltotalcutqty.Text = Convert.ToInt32(lbltotalcutqty.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lbltotalcutqty.Text = "";
                }

                Label lblPrice = (Label)e.Row.FindControl("lblPrice");
                HiddenField hdnCurrenyTag = (HiddenField)e.Row.FindControl("hdnCurrenyTag");

                string StrTag = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType((Convert.ToInt32(hdnCurrenyTag.Value)));

                if (lblPrice.Text != "" && lblPrice.Text != "0" && lblPrice.Text != "0.0")
                {

                    lblPrice.Text = StrTag + " " + Math.Round(Convert.ToDouble(lblPrice.Text), 2, MidpointRounding.AwayFromZero).ToString();
                }
                else
                {
                    lblPrice.Text = "";
                }

                Label lbltotalcontractqty = (Label)e.Row.FindControl("lbltotalcontractqty");

                if (lbltotalcontractqty.Text != "" && lbltotalcontractqty.Text != "0" && lbltotalcontractqty.Text != "0.0")
                {
                    lbltotalcontractqty.Text = Convert.ToInt32(lbltotalcontractqty.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lbltotalcontractqty.Text = "";
                }


                Label lbltotalstich = (Label)e.Row.FindControl("lbltotalstich");

                if (lbltotalstich.Text != "" && lbltotalstich.Text != "0" && lbltotalstich.Text != "0.0")
                {
                    lbltotalstich.Text = Convert.ToInt32(lbltotalstich.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lbltotalstich.Text = "";
                }


                Label lblTotalFinishedQty = (Label)e.Row.FindControl("lblTotalFinishedQty");

                if (lblTotalFinishedQty.Text != "" && lblTotalFinishedQty.Text != "0" && lblTotalFinishedQty.Text != "0.0")
                {
                    lblTotalFinishedQty.Text = Convert.ToInt32(lblTotalFinishedQty.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lblTotalFinishedQty.Text = "";
                }

                Label lblOrderValueValue = (Label)e.Row.FindControl("lblOrderValueValue");

                if (lblOrderValueValue.Text != "" && lblOrderValueValue.Text != "0" && lblOrderValueValue.Text != "0.0")
                {
                    lblOrderValueValue.Text = "\u20B9 " + Math.Round((Convert.ToDouble(lblOrderValueValue.Text)), 2, MidpointRounding.AwayFromZero).ToString();


                }
                else
                {
                    lblOrderValueValue.Text = "";
                }
                HiddenField hdnOrderDetailsID = (HiddenField)e.Row.FindControl("hdnOrderDetailsID");
                Label lblinlineinspectiondate_Name = (Label)e.Row.FindControl("lblinlineinspectiondate_Name");
                Label lblMidinspectiondateand_Name = (Label)e.Row.FindControl("lblMidinspectiondateand_Name");
                Label lblFinalinspectiondate_Name = (Label)e.Row.FindControl("lblFinalinspectiondate_Name");
                Label lblFinalBIHinspectiondate_Name = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name");


                //lblinlineinspectiondate_Name.Text = lblinlineinspectiondate_Name.Text != "" ? Convert.ToDateTime(lblinlineinspectiondate_Name.Text).ToString("dd MMM yy (ddd)") : "";
                //lblMidinspectiondateand_Name.Text = lblMidinspectiondateand_Name.Text != "" ? Convert.ToDateTime(lblMidinspectiondateand_Name.Text).ToString("dd MMM yy (ddd)") : "";
                //lblFinalinspectiondate_Name.Text = lblFinalinspectiondate_Name.Text != "" ? Convert.ToDateTime(lblFinalinspectiondate_Name.Text).ToString("dd MMM yy (ddd)") : "";
                //lblFinalBIHinspectiondate_Name.Text = lblFinalBIHinspectiondate_Name.Text != "" ? Convert.ToDateTime(lblFinalBIHinspectiondate_Name.Text).ToString("dd MMM yy (ddd)") : "";







                //Label lblinlineinspectiondate_Name_username = (Label)e.Row.FindControl("lblinlineinspectiondate_Name_username");


                //if (lblinlineinspectiondate_Name_username.Text != "")
                //{

                //    string[] str = lblinlineinspectiondate_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                //    if (str.Length == 1)
                //    {
                //        if (str[0].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblinlineinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblinlineinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");


                //        }
                //    }
                //    if (str.Length == 2)
                //    {
                //        if (str[1].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            lblinlineinspectiondate_Name_username.Text = str[0].ToString();
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblinlineinspectiondate_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblinlineinspectiondate_Name.Text = "";


                //        }
                //    }


                //}

                //Label lblMidinspectiondateand_Name_username = (Label)e.Row.FindControl("lblMidinspectiondateand_Name_username");


                //if (lblMidinspectiondateand_Name_username.Text != "")
                //{

                //    string[] str = lblMidinspectiondateand_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                //    if (str.Length == 1)
                //    {
                //        if (str[0].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblMidinspectiondateand_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblMidinspectiondateand_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");


                //        }
                //    }
                //    if (str.Length == 2)
                //    {
                //        if (str[1].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            lblMidinspectiondateand_Name_username.Text = str[0].ToString();
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblMidinspectiondateand_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblMidinspectiondateand_Name.Text = "";


                //        }
                //    }


                //}


                //Label lblFinalinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalinspectiondate_Name_username");

                //if (lblFinalinspectiondate_Name_username.Text != "")
                //{

                //    string[] str = lblFinalinspectiondate_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                //    if (str.Length == 1)
                //    {
                //        if (str[0].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblFinalinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblFinalinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");


                //        }
                //    }
                //    if (str.Length == 2)
                //    {
                //        if (str[1].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            lblFinalinspectiondate_Name_username.Text = str[0].ToString();
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblFinalinspectiondate_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblFinalinspectiondate_Name.Text = "";


                //        }
                //    }


                //}

                //Label lblFinalBIHinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name_username");


                //if (lblFinalBIHinspectiondate_Name_username.Text != "")
                //{

                //    string[] str = lblFinalBIHinspectiondate_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                //    if (str.Length == 1)
                //    {
                //        if (str[0].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblFinalBIHinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblFinalBIHinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");


                //        }
                //    }
                //    if (str.Length == 2)
                //    {
                //        if (str[1].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            lblFinalBIHinspectiondate_Name_username.Text = str[0].ToString();
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblFinalBIHinspectiondate_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblFinalBIHinspectiondate_Name.Text = "";


                //        }
                //    }


                //}
                Label lblinlineinspectiondate_Name_username = (Label)e.Row.FindControl("lblinlineinspectiondate_Name_username");
                Label lblMidinspectiondateand_Name_username = (Label)e.Row.FindControl("lblMidinspectiondateand_Name_username");
                Label lblFinalinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalinspectiondate_Name_username");
                Label lblFinalBIHinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name_username");


                Label lblexfactdate = (Label)e.Row.FindControl("lblexfactdate");
                if (lblexfactdate.Text != "" && lblexfactdate != null)
                {
                    lblexfactdate.Text = Convert.ToDateTime(lblexfactdate.Text).ToString("dd MMM yy (ddd)");
                }

                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                if (hdnOrderDetailsID != null && hdnOrderDetailsID.Value != "")
                {
                    ds = objadmin.GetShipmentReportByICBIPL_ordring(Convert.ToInt32(hdnOrderDetailsID.Value), "ICBIPL");
                    dt = ds.Tables[0];
                    if (dt.Rows.Count == 1)
                    {
                        lblinlineinspectiondate_Name_username.Text = dt.Rows[0]["StatusName"].ToString();
                    }
                    if (dt.Rows.Count == 2)
                    {
                        lblinlineinspectiondate_Name_username.Text = dt.Rows[0]["StatusName"].ToString();
                        lblFinalinspectiondate_Name_username.Text = dt.Rows[1]["StatusName"].ToString();
                    }
                    if (dt.Rows.Count == 3)
                    {
                        lblinlineinspectiondate_Name_username.Text = dt.Rows[0]["StatusName"].ToString();
                        lblFinalinspectiondate_Name_username.Text = dt.Rows[1]["StatusName"].ToString();
                        lblMidinspectiondateand_Name_username.Text = dt.Rows[2]["StatusName"].ToString();
                    }
                    if (dt.Rows.Count == 4)
                    {
                        lblinlineinspectiondate_Name_username.Text = dt.Rows[0]["StatusName"].ToString();
                        lblFinalinspectiondate_Name_username.Text = dt.Rows[1]["StatusName"].ToString();
                        lblMidinspectiondateand_Name_username.Text = dt.Rows[2]["StatusName"].ToString();
                        lblFinalBIHinspectiondate_Name_username.Text = dt.Rows[3]["StatusName"].ToString();
                    }

                }




            }
        }
        public bool IsValidDateTime(string dateTime)
        {
            string[] formats = { "MM/dd/yyyy" };
            DateTime parsedDateTime;
            return DateTime.TryParseExact(dateTime, formats, new CultureInfo("en-US"),
                                           DateTimeStyles.None, out parsedDateTime);
        }
        protected void grdpendingshipment_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                HtmlGenericControl spanICTotalCut_p = (HtmlGenericControl)e.Row.FindControl("spanICTotalCut_p");
                HtmlGenericControl panICstichTotal_p = (HtmlGenericControl)e.Row.FindControl("panICstichTotal_p");
                HtmlGenericControl spanicfinsidhtotal_p = (HtmlGenericControl)e.Row.FindControl("spanicfinsidhtotal_p");
                HtmlGenericControl spOrderValueIctotal_p = (HtmlGenericControl)e.Row.FindControl("spOrderValueIctotal_p");
                HtmlGenericControl Strong5 = (HtmlGenericControl)e.Row.FindControl("Strong5");
                HtmlGenericControl spanICTotalContract_p = (HtmlGenericControl)e.Row.FindControl("spanICTotalContract_p");
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[0].Attributes.Add("colspan", "2");

                if (dtitem_ic_foterpening.Rows[0]["ContractQty"].ToString() != "" && dtitem_ic_foterpening.Rows[0]["ContractQty"].ToString() != "0" && dtitem_ic_foterpening.Rows[0]["ContractQty"].ToString() != "0.0")
                {
                    spanICTotalContract_p.InnerText = Convert.ToInt32(dtitem_ic_foterpening.Rows[0]["ContractQty"].ToString()).ToString("N0") + " " + "Pcs";
                }


                if (dtitem_ic_foterpening.Rows[0]["totalcutQty"].ToString() != "" && dtitem_ic_foterpening.Rows[0]["totalcutQty"].ToString() != "0" && dtitem_ic_foterpening.Rows[0]["totalcutQty"].ToString() != "0.0")
                {
                    spanICTotalCut_p.InnerText = Convert.ToInt32(dtitem_ic_foterpening.Rows[0]["totalcutQty"].ToString()).ToString("N0") + " " + "Pcs";
                }

                if (dtitem_ic_foterpening.Rows[0]["totalstichQty"].ToString() != "" && dtitem_ic_foterpening.Rows[0]["totalstichQty"].ToString() != "0" && dtitem_ic_foterpening.Rows[0]["totalstichQty"].ToString() != "0.0")
                {
                    panICstichTotal_p.InnerText = Convert.ToInt32(dtitem_ic_foterpening.Rows[0]["totalstichQty"].ToString()).ToString("N0") + " " + "Pcs";
                }


                if (dtitem_ic_foterpening.Rows[0]["TotalFoterFinsishedQty"].ToString() != "" && dtitem_ic_foterpening.Rows[0]["TotalFoterFinsishedQty"].ToString() != "0" && dtitem_ic_foterpening.Rows[0]["TotalFoterFinsishedQty"].ToString() != "0.0")
                {
                    spanicfinsidhtotal_p.InnerText = Convert.ToInt32(dtitem_ic_foterpening.Rows[0]["TotalFoterFinsishedQty"].ToString()).ToString("N0") + " " + "Pcs";
                }



                if (dtitem_ic_foterpening.Rows[0]["fotertotalOrderValue"].ToString() != "" && dtitem_ic_foterpening.Rows[0]["fotertotalOrderValue"].ToString() != "0" && dtitem_ic_foterpening.Rows[0]["fotertotalOrderValue"].ToString() != "0.0")
                {
                    spOrderValueIctotal_p.InnerText = "\u20B9 " + dtitem_ic_foterpening.Rows[0]["fotertotalOrderValue"].ToString() + " Cr";
                }


            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblContactNo = (Label)e.Row.FindControl("lblContactNo");
                Label lblLineitemNo = (Label)e.Row.FindControl("lblLineitemNo");


                Label lbltotalcutqty = (Label)e.Row.FindControl("lbltotalcutqty");


                if (lbltotalcutqty.Text != "" && lbltotalcutqty.Text != "0")
                {
                    lbltotalcutqty.Text = Convert.ToInt32(lbltotalcutqty.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lbltotalcutqty.Text = "";
                }
                Label lbltotalcontractqty = (Label)e.Row.FindControl("lbltotalcontractqty");

                if (lbltotalcontractqty.Text != "" && lbltotalcontractqty.Text != "0" && lbltotalcontractqty.Text != "0.0")
                {
                    lbltotalcontractqty.Text = Convert.ToInt32(lbltotalcontractqty.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lbltotalcontractqty.Text = "";
                }

                Label lblinlineinspectiondate_Name = (Label)e.Row.FindControl("lblinlineinspectiondate_Name");
                Label lblMidinspectiondateand_Name = (Label)e.Row.FindControl("lblMidinspectiondateand_Name");
                Label lblFinalinspectiondate_Name = (Label)e.Row.FindControl("lblFinalinspectiondate_Name");
                Label lblFinalBIHinspectiondate_Name = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name");





                //Label lblinlineinspectiondate_Name_username = (Label)e.Row.FindControl("lblinlineinspectiondate_Name_username");

                //if (lblinlineinspectiondate_Name_username.Text != "")
                //{

                //        string[] str = lblinlineinspectiondate_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                //        if (str[0].ToString() != "" && str.Length == 2)
                //        {
                //            lblinlineinspectiondate_Name_username.Text = str[0].ToString();
                //        }
                //        if (str[1].ToString() != "" && str.Length == 2)
                //        {
                //            lblinlineinspectiondate_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
                //        }

                //}

                //if (lblinlineinspectiondate_Name_username.Text != "")
                //{

                //    string[] str = lblinlineinspectiondate_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                //    if (str.Length == 1)
                //    {
                //        if (str[0].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblinlineinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblinlineinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");


                //        }
                //    }
                //    if (str.Length == 2)
                //    {
                //        if (str[1].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            lblinlineinspectiondate_Name_username.Text = str[0].ToString();
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblinlineinspectiondate_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblinlineinspectiondate_Name.Text = "";


                //        }
                //    }


                //}
                //Label lblMidinspectiondateand_Name_username = (Label)e.Row.FindControl("lblMidinspectiondateand_Name_username");


                //if (lblMidinspectiondateand_Name_username.Text != "")
                //{

                //    string[] str = lblMidinspectiondateand_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                //    if (str.Length == 1)
                //    {
                //        if (str[0].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblMidinspectiondateand_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblMidinspectiondateand_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");


                //        }
                //    }
                //    if (str.Length == 2)
                //    {
                //        if (str[1].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            lblMidinspectiondateand_Name_username.Text = str[0].ToString();
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblMidinspectiondateand_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblMidinspectiondateand_Name.Text = "";


                //        }
                //    }


                //}

                //Label lblFinalinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalinspectiondate_Name_username");



                //if (lblFinalinspectiondate_Name_username.Text != "")
                //{

                //    string[] str = lblFinalinspectiondate_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                //    if (str.Length == 1)
                //    {
                //        if (str[0].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblFinalinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblFinalinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");


                //        }
                //    }
                //    if (str.Length == 2)
                //    {
                //        if (str[1].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            lblFinalinspectiondate_Name_username.Text = str[0].ToString();
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblFinalinspectiondate_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblFinalinspectiondate_Name.Text = "";


                //        }
                //    }


                //}

                //Label lblFinalBIHinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name_username");



                //if (lblFinalBIHinspectiondate_Name_username.Text != "")
                //{

                //    string[] str = lblFinalBIHinspectiondate_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                //    if (str.Length == 1)
                //    {
                //        if (str[0].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblFinalBIHinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblFinalBIHinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");


                //        }
                //    }
                //    if (str.Length == 2)
                //    {
                //        if (str[1].ToString() != "")
                //        {
                //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
                //            lblFinalBIHinspectiondate_Name_username.Text = str[0].ToString();
                //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
                //            if (dt != DateTime.MinValue)
                //                lblFinalBIHinspectiondate_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
                //            else
                //                lblFinalBIHinspectiondate_Name.Text = "";


                //        }
                //    }


                //}


                Label lbltotalstich = (Label)e.Row.FindControl("lbltotalstich");

                if (lbltotalstich.Text != "" && lbltotalstich.Text != "0")
                {
                    lbltotalstich.Text = Convert.ToInt32(lbltotalstich.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lbltotalstich.Text = "";
                }

                Label lblPrice = (Label)e.Row.FindControl("lblPrice");
                HiddenField hdnCurrenyTag = (HiddenField)e.Row.FindControl("hdnCurrenyTag");

                string StrTag = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType((Convert.ToInt32(hdnCurrenyTag.Value)));

                if (lblPrice.Text != "" && lblPrice.Text != "0")
                {
                    lblPrice.Text = StrTag + " " + Math.Round(Convert.ToDouble(lblPrice.Text), 2, MidpointRounding.AwayFromZero).ToString();
                }
                else
                {
                    lblPrice.Text = "";
                }

                Label lblTotalFinishedQty = (Label)e.Row.FindControl("lblTotalFinishedQty");

                if (lblTotalFinishedQty.Text != "" && lblTotalFinishedQty.Text != "0")
                {
                    lblTotalFinishedQty.Text = Convert.ToInt32(lblTotalFinishedQty.Text).ToString("N0") + " pcs";
                }
                else
                {
                    lblTotalFinishedQty.Text = "";
                }

                Label lblOrderValueValue = (Label)e.Row.FindControl("lblOrderValueValue");

                if (lblOrderValueValue.Text != "" && lblOrderValueValue.Text != "0")
                {
                    lblOrderValueValue.Text = "\u20B9 " + Math.Round((Convert.ToDouble(lblOrderValueValue.Text)), 2, MidpointRounding.AwayFromZero).ToString();


                }
                else
                {
                    lblOrderValueValue.Text = "";
                }

                //Label lblinlineinspectiondate_Name = (Label)e.Row.FindControl("lblinlineinspectiondate_Name");
                //Label lblMidinspectiondateand_Name = (Label)e.Row.FindControl("lblMidinspectiondateand_Name");
                //Label lblFinalinspectiondate_Name = (Label)e.Row.FindControl("lblFinalinspectiondate_Name");
                //Label lblFinalBIHinspectiondate_Name = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name");


                //lblinlineinspectiondate_Name.Text = lblinlineinspectiondate_Name.Text != "" ? Convert.ToDateTime(lblinlineinspectiondate_Name.Text).ToString("dd MMM yy (ddd)") : "";
                //lblMidinspectiondateand_Name.Text = lblMidinspectiondateand_Name.Text != "" ? Convert.ToDateTime(lblMidinspectiondateand_Name.Text).ToString("dd MMM yy (ddd)") : "";
                //lblFinalinspectiondate_Name.Text = lblFinalinspectiondate_Name.Text != "" ? Convert.ToDateTime(lblFinalinspectiondate_Name.Text).ToString("dd MMM yy (ddd)") : "";
                //lblFinalBIHinspectiondate_Name.Text = lblFinalBIHinspectiondate_Name.Text != "" ? Convert.ToDateTime(lblFinalBIHinspectiondate_Name.Text).ToString("dd MMM yy (ddd)") : "";


                Label lblinlineinspectiondate_Name_username = (Label)e.Row.FindControl("lblinlineinspectiondate_Name_username");
                Label lblMidinspectiondateand_Name_username = (Label)e.Row.FindControl("lblMidinspectiondateand_Name_username");
                Label lblFinalinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalinspectiondate_Name_username");
                Label lblFinalBIHinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name_username");


                HiddenField hdnOrderDetailsID = (HiddenField)e.Row.FindControl("hdnOrderDetailsID");
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                if (hdnOrderDetailsID != null && hdnOrderDetailsID.Value != "")
                {
                    ds = objadmin.GetShipmentReportByICBIPL_ordring(Convert.ToInt32(hdnOrderDetailsID.Value), "ICBIPL");
                    dt = ds.Tables[0];
                    if (dt.Rows.Count == 1)
                    {
                        lblinlineinspectiondate_Name_username.Text = dt.Rows[0]["StatusName"].ToString();
                    }
                    if (dt.Rows.Count == 2)
                    {
                        lblinlineinspectiondate_Name_username.Text = dt.Rows[0]["StatusName"].ToString();
                        lblFinalinspectiondate_Name_username.Text = dt.Rows[1]["StatusName"].ToString();
                    }
                    if (dt.Rows.Count == 3)
                    {
                        lblinlineinspectiondate_Name_username.Text = dt.Rows[0]["StatusName"].ToString();
                        lblFinalinspectiondate_Name_username.Text = dt.Rows[1]["StatusName"].ToString();
                        lblMidinspectiondateand_Name_username.Text = dt.Rows[2]["StatusName"].ToString();
                    }
                    if (dt.Rows.Count == 4)
                    {
                        lblinlineinspectiondate_Name_username.Text = dt.Rows[0]["StatusName"].ToString();
                        lblFinalinspectiondate_Name_username.Text = dt.Rows[1]["StatusName"].ToString();
                        lblMidinspectiondateand_Name_username.Text = dt.Rows[2]["StatusName"].ToString();
                        lblFinalBIHinspectiondate_Name_username.Text = dt.Rows[3]["StatusName"].ToString();
                    }

                }
                //if (lblinlineinspectiondate_Name_username.Text == "")
                //{
                //    lblinlineinspectiondate_Name_username.Visible = false;
                //}
                //if (lblMidinspectiondateand_Name_username.Text == "")
                //{
                //    lblMidinspectiondateand_Name_username.Visible = false;
                //}
                //if (lblFinalinspectiondate_Name_username.Text == "")
                //{
                //    lblFinalinspectiondate_Name_username.Visible = false;
                //}
                //if (lblFinalBIHinspectiondate_Name_username.Text == "")
                //{
                //    lblFinalBIHinspectiondate_Name_username.Visible = false;
                //}
                Label lblexfactdate = (Label)e.Row.FindControl("lblexfactdate");
                if (lblexfactdate.Text != "" && lblexfactdate != null)
                {
                    lblexfactdate.Text = Convert.ToDateTime(lblexfactdate.Text).ToString("dd MMM yy (ddd)");
                }
            }
        }

        //---------------------------------c47---------------------------------------//
      
        
      
       
       
    
      

        public static double CutQty47total;
        public static double StitchQty47total;
        public static double FinishQty47total;
        public static double ShipeQty47total;
        public static double ShipeValue47total;
        public static double ctsl4747total;
        public static double PendingQty_47total;
        public static double pedPendingVal_47total;



      


        public static double CutQtyCtsl_C47total;



        //---------------------------------C46C47---------------------------------------//
      
     
        
        double ShipeQty46C47 = 0;
      
    
        
       


        public static double CutQty46C47total;
        public static double StitchQty46C47total;
        public static double FinishQty46C47total;
        public static double ShipeQty46C47total;
        public static double ShipeValue46C47total;
        public static double ctsl46C47total;
        public static double PendingQty46C47total;
        public static double pedPendingVal46C47total;


        


        public static double CutQtyCtsl_46C47total;
        //---------------------------------BIPL---------------------------------------//

       
       
      
        double ShipeQtyBIPL = 0;
       
        
       
        



        public static double CutQtyBIPLtotal = 0;
        public static double StitchQtyBIPLtotal = 0;
        public static double FinishQtyBIPLtotal = 0;
        public static double ShipeQtyBIPLtotal = 0;
        public static double ShipeValueBIPLtotal = 0;
        public static double ctslBIPLtotal = 0;
        public static double PendingQtyBIPLtotal = 0;
        public static double pedPendingValBIPLtotal = 0;


        


        public static double CutQtyCtsl_BIPLtotal;

        public void getShipmentReportCummlative()
        {

            // ----------------------------------------C47--------------------------------------------------------//

            foreach (GridViewRow row in gridshipemtNew.Rows)
            {
                Label lblcountrisk47 = (Label)row.FindControl("lblcountrisk47");
                Label lblcounthoppm47 = (Label)row.FindControl("lblcounthoppm47");
                Label lblcounttopsent47 = (Label)row.FindControl("lblcounttopsent47");
                Label lblcountInline47 = (Label)row.FindControl("lblcountInline47");
                Label lblcountOnline47 = (Label)row.FindControl("lblcountOnline47");
                Label lblcountFinal47 = (Label)row.FindControl("lblcountFinal47");

                if (lblcountrisk47 != null)
                {
                    if (lblcountrisk47.Text != "")
                    {
                        lblcountrisk47.Text = lblcountrisk47.Text == "0" ? "" : lblcountrisk47.Text;

                        if (lblcountrisk47.Text != "")
                        {
                            RiskCountC7 = RiskCountC7 + Convert.ToInt32(lblcountrisk47.Text);


                        }
                    }
                }
                if (lblcounthoppm47 != null)
                {
                    if (lblcounthoppm47.Text != "")
                    {
                        lblcounthoppm47.Text = lblcounthoppm47.Text == "0" ? "" : lblcounthoppm47.Text;

                        if (lblcounthoppm47.Text != "")
                        {
                            HOPPMCountC7 = HOPPMCountC7 + Convert.ToInt32(lblcounthoppm47.Text);


                        }
                    }
                }
                if (lblcounttopsent47 != null)
                {
                    if (lblcounttopsent47.Text != "")
                    {
                        lblcounttopsent47.Text = lblcounttopsent47.Text == "0" ? "" : lblcounttopsent47.Text;

                        if (lblcounttopsent47.Text != "")
                        {
                            TopSentCountC7 = TopSentCountC7 + Convert.ToInt32(lblcounttopsent47.Text);


                        }
                    }
                }
                if (lblcountInline47 != null)
                {
                    if (lblcountInline47.Text != "")
                    {
                        lblcountInline47.Text = lblcountInline47.Text == "0" ? "" : lblcountInline47.Text;

                        if (lblcountInline47.Text != "")
                        {
                            InlineCountC7 = InlineCountC7 + Convert.ToInt32(lblcountInline47.Text);


                        }
                    }
                }
                if (lblcountOnline47 != null)
                {
                    if (lblcountOnline47.Text != "")
                    {
                        lblcountOnline47.Text = lblcountOnline47.Text == "0" ? "" : lblcountOnline47.Text;

                        if (lblcountOnline47.Text != "")
                        {
                            OnlineCountC7 = OnlineCountC7 + Convert.ToInt32(lblcountOnline47.Text);


                        }
                    }
                }
                if (lblcountFinal47 != null)
                {
                    if (lblcountFinal47.Text != "")
                    {
                        lblcountFinal47.Text = lblcountFinal47.Text == "0" ? "" : lblcountFinal47.Text;

                        if (lblcountFinal47.Text != "")
                        {
                            FinalCountC7 = FinalCountC7 + Convert.ToInt32(lblcountFinal47.Text);


                        }
                    }
                }
                //--C45-C46
                Label lblcountrisk4546 = (Label)row.FindControl("lblcountrisk4546");
                Label lblcounthoppm4546 = (Label)row.FindControl("lblcounthoppm4546");
                Label lblcounttopsent4546 = (Label)row.FindControl("lblcounttopsent4546");
                Label lblcountInline4546 = (Label)row.FindControl("lblcountInline4546");
                Label lblcountOnline4546 = (Label)row.FindControl("lblcountOnline4546");
                Label lblcountFinal4546 = (Label)row.FindControl("lblcountFinal4546");

                if (lblcountrisk4546 != null)
                {
                    if (lblcountrisk4546.Text != "")
                    {
                        lblcountrisk4546.Text = lblcountrisk4546.Text == "0" ? "" : lblcountrisk4546.Text;

                        if (lblcountrisk4546.Text != "")
                        {
                            RiskCountC4647 = RiskCountC4647 + Convert.ToInt32(lblcountrisk4546.Text);


                        }
                    }
                }
                if (lblcounthoppm4546 != null)
                {
                    if (lblcounthoppm4546.Text != "")
                    {
                        lblcounthoppm4546.Text = lblcounthoppm4546.Text == "0" ? "" : lblcounthoppm4546.Text;

                        if (lblcounthoppm4546.Text != "")
                        {
                            HOPPMCountC4647 = HOPPMCountC4647 + Convert.ToInt32(lblcounthoppm4546.Text);


                        }
                    }
                }
                if (lblcounttopsent4546 != null)
                {
                    if (lblcounttopsent4546.Text != "")
                    {
                        lblcounttopsent4546.Text = lblcounttopsent4546.Text == "0" ? "" : lblcounttopsent4546.Text;

                        if (lblcounttopsent4546.Text != "")
                        {
                            TopSentCountC4647 = TopSentCountC4647 + Convert.ToInt32(lblcounttopsent4546.Text);


                        }
                    }
                }
                if (lblcountInline4546 != null)
                {
                    if (lblcountInline4546.Text != "")
                    {
                        lblcountInline4546.Text = lblcountInline4546.Text == "0" ? "" : lblcountInline4546.Text;

                        if (lblcountInline4546.Text != "")
                        {
                            InlineCountC4647 = InlineCountC4647 + Convert.ToInt32(lblcountInline4546.Text);


                        }
                    }
                }
                if (lblcountOnline4546 != null)
                {
                    if (lblcountOnline4546.Text != "")
                    {
                        lblcountOnline4546.Text = lblcountOnline4546.Text == "0" ? "" : lblcountOnline4546.Text;

                        if (lblcountOnline4546.Text != "")
                        {
                            OnlineCountC4647 = OnlineCountC4647 + Convert.ToInt32(lblcountOnline4546.Text);


                        }
                    }
                }
                if (lblcountFinal4546 != null)
                {
                    if (lblcountFinal4546.Text != "")
                    {
                        lblcountFinal4546.Text = lblcountFinal4546.Text == "0" ? "" : lblcountFinal4546.Text;

                        if (lblcountFinal4546.Text != "")
                        {
                            FinalCountC4647 = FinalCountC4647 + Convert.ToInt32(lblcountFinal4546.Text);


                        }
                    }
                }
                //--Bipl
                Label lblcountriskBipl = (Label)row.FindControl("lblcountriskBipl");
                Label lblcounthoppmBipl = (Label)row.FindControl("lblcounthoppmBipl");
                Label lblcounttopsentBipl = (Label)row.FindControl("lblcounttopsentBipl");
                Label lblcountInlineBipl = (Label)row.FindControl("lblcountInlineBipl");
                Label lblcountOnlineBipl = (Label)row.FindControl("lblcountOnlineBipl");
                Label lblcountFinalBipl = (Label)row.FindControl("lblcountFinalBipl");

                if (lblcountriskBipl != null)
                {
                    if (lblcountriskBipl.Text != "")
                    {
                        lblcountriskBipl.Text = lblcountriskBipl.Text == "0" ? "" : lblcountriskBipl.Text;

                        if (lblcountriskBipl.Text != "")
                        {
                            RiskCountbipl = RiskCountbipl + Convert.ToInt32(lblcountriskBipl.Text);


                        }
                    }
                }
                if (lblcounthoppmBipl != null)
                {
                    if (lblcounthoppmBipl.Text != "")
                    {
                        lblcounthoppmBipl.Text = lblcounthoppmBipl.Text == "0" ? "" : lblcounthoppmBipl.Text;

                        if (lblcounthoppmBipl.Text != "")
                        {
                            HOPPMCountbipl = HOPPMCountbipl + Convert.ToInt32(lblcounthoppmBipl.Text);


                        }
                    }
                }
                if (lblcounttopsentBipl != null)
                {
                    if (lblcounttopsentBipl.Text != "")
                    {
                        lblcounttopsentBipl.Text = lblcounttopsentBipl.Text == "0" ? "" : lblcounttopsentBipl.Text;

                        if (lblcounttopsentBipl.Text != "")
                        {
                            TopSentCountbipl = TopSentCountbipl + Convert.ToInt32(lblcounttopsentBipl.Text);


                        }
                    }
                }
                if (lblcountInlineBipl != null)
                {
                    if (lblcountInlineBipl.Text != "")
                    {
                        lblcountInlineBipl.Text = lblcountInlineBipl.Text == "0" ? "" : lblcountInlineBipl.Text;

                        if (lblcountInlineBipl.Text != "")
                        {
                            InlineCountbipl = InlineCountbipl + Convert.ToInt32(lblcountInlineBipl.Text);


                        }
                    }
                }
                if (lblcountOnlineBipl != null)
                {
                    if (lblcountOnlineBipl.Text != "")
                    {
                        lblcountOnlineBipl.Text = lblcountOnlineBipl.Text == "0" ? "" : lblcountOnlineBipl.Text;

                        if (lblcountOnlineBipl.Text != "")
                        {
                            OnlineCountbipl = OnlineCountbipl + Convert.ToInt32(lblcountOnlineBipl.Text);


                        }
                    }
                }
                if (lblcountFinalBipl != null)
                {
                    if (lblcountFinalBipl.Text != "")
                    {
                        lblcountFinalBipl.Text = lblcountFinalBipl.Text == "0" ? "" : lblcountFinalBipl.Text;

                        if (lblcountFinalBipl.Text != "")
                        {
                            FinalCountbipl = FinalCountbipl + Convert.ToInt32(lblcountFinalBipl.Text);


                        }
                    }
                }

            }
            //Foter Sum C47========//
            Label lblcountriskfoter47 = (Label)gridshipemtNew.FooterRow.FindControl("lblcountriskfoter47");
            Label lblcounthoppmfoter47 = (Label)gridshipemtNew.FooterRow.FindControl("lblcounthoppmfoter47");
            Label lblcounttopsentfoter47 = (Label)gridshipemtNew.FooterRow.FindControl("lblcounttopsentfoter47");
            Label lblcountInlinefoter47 = (Label)gridshipemtNew.FooterRow.FindControl("lblcountInlinefoter47");
            Label lblcountOnlinefoter47 = (Label)gridshipemtNew.FooterRow.FindControl("lblcountOnlinefoter47");
            Label lblcountFinalfoter47 = (Label)gridshipemtNew.FooterRow.FindControl("lblcountFinalfoter47");

            lblcountriskfoter47.Text = RiskCountC7 == 0 ? "" : RiskCountC7.ToString();
            lblcounthoppmfoter47.Text = HOPPMCountC7 == 0 ? "" : HOPPMCountC7.ToString();
            lblcounttopsentfoter47.Text = TopSentCountC7 == 0 ? "" : TopSentCountC7.ToString();
            lblcountInlinefoter47.Text = InlineCountC7 == 0 ? "" : InlineCountC7.ToString();
            lblcountOnlinefoter47.Text = OnlineCountC7 == 0 ? "" : OnlineCountC7.ToString();
            lblcountFinalfoter47.Text = FinalCountC7 == 0 ? "" : FinalCountC7.ToString();

            //Foter Sum C46C47========//
            Label lblcountriskfoter4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblcountriskfoter4546");
            Label lblcounthoppmfoter4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblcounthoppmfoter4546");
            Label lblcounttopsentfoter4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblcounttopsentfoter4546");
            Label lblcountInlinefoter4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblcountInlinefoter4546");
            Label lblcountOnlinefoter4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblcountOnlinefoter4546");
            Label lblcountFinalfoter4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblcountFinalfoter4546");

            lblcountriskfoter4546.Text = RiskCountC4647 == 0 ? "" : RiskCountC4647.ToString();
            lblcounthoppmfoter4546.Text = HOPPMCountC4647 == 0 ? "" : HOPPMCountC4647.ToString();
            lblcounttopsentfoter4546.Text = TopSentCountC4647 == 0 ? "" : TopSentCountC4647.ToString();
            lblcountInlinefoter4546.Text = InlineCountC4647 == 0 ? "" : InlineCountC4647.ToString();
            lblcountOnlinefoter4546.Text = OnlineCountC4647 == 0 ? "" : OnlineCountC4647.ToString();
            lblcountFinalfoter4546.Text = FinalCountC4647 == 0 ? "" : FinalCountC4647.ToString();


            //Foter Sum Bipl========//
            Label lblcountriskfoterBipl = (Label)gridshipemtNew.FooterRow.FindControl("lblcountriskfoterBipl");
            Label lblcounthoppmfoterBipl = (Label)gridshipemtNew.FooterRow.FindControl("lblcounthoppmfoterBipl");
            Label lblcounttopsentfoterBipl = (Label)gridshipemtNew.FooterRow.FindControl("lblcounttopsentfoterBipl");
            Label lblcountInlinefoterBipl = (Label)gridshipemtNew.FooterRow.FindControl("lblcountInlinefoterBipl");
            Label lblcountOnlinefoterBipl = (Label)gridshipemtNew.FooterRow.FindControl("lblcountOnlinefoterBipl");
            Label lblcountFinalfoterBipl = (Label)gridshipemtNew.FooterRow.FindControl("lblcountFinalfoterBipl");

            lblcountriskfoterBipl.Text = RiskCountbipl == 0 ? "" : RiskCountbipl.ToString();
            lblcounthoppmfoterBipl.Text = HOPPMCountbipl == 0 ? "" : HOPPMCountbipl.ToString();
            lblcounttopsentfoterBipl.Text = TopSentCountbipl == 0 ? "" : TopSentCountbipl.ToString();
            lblcountInlinefoterBipl.Text = InlineCountbipl == 0 ? "" : InlineCountbipl.ToString();
            lblcountOnlinefoterBipl.Text = OnlineCountbipl == 0 ? "" : OnlineCountbipl.ToString();
            lblcountFinalfoterBipl.Text = FinalCountbipl == 0 ? "" : FinalCountbipl.ToString();

        }


        //    //HtmlGenericControl spCurrentWeekCumulativeSum_c45 = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentWeekCumulativeSum_c45");
        //    //HtmlGenericControl spCurrentWeekCumulativeSum_c46 = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentWeekCumulativeSum_c46");
        //    //HtmlGenericControl spCurrentWeekCumulativeSum_out = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentWeekCumulativeSum_out");
        //    //HtmlGenericControl spCurrentWeekCumulativeSum_Bipl = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentWeekCumulativeSum_Bipl");
        //    //HtmlGenericControl spctslCumulativeSum = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spctslCumulativeSum");

        //    ////spCurrentWeekCumulativeSum_c45.InnerText = qntyc45total == 0 ? "" : qntyc45total.ToString()+" K ";
        //    ////spCurrentWeekCumulativeSum_c46.InnerText = qntyc46total == 0 ? "" : qntyc46total.ToString() + " K "; ;
        //    ////spCurrentWeekCumulativeSum_out.InnerText = qntycouttotal == 0 ? "" : qntycouttotal.ToString() + " K "; ;
        //    ////spCurrentWeekCumulativeSum_Bipl.InnerText = qntycbipltotal == 0 ? "" : qntycbipltotal.ToString() + " K "; ;

        //    ////spctslCumulativeSum.InnerText = qntyctsltotal == 0 ? "" : qntyctsltotal.ToString();

        //    ////HtmlGenericControl spctsl46 = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spctsl46");
        //    ////HtmlGenericControl spctsl47 = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spctsl47");
        //    ////HtmlGenericControl spctslout = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spctslout");
        //    ////HtmlGenericControl spctslbipl = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spctslbipl");

        //    ////spctsl46.InnerText = qntyc45totalctsl == 0 ? "" : "("+qntyc45totalctsl.ToString()+"%)";
        //    ////spctsl47.InnerText = qntyc46totalctsl == 0 ? "" : "(" + qntyc46totalctsl.ToString() + "%)";
        //    ////spctslout.InnerText = qntycouttotalctsl == 0 ? "" : "(" + qntycouttotalctsl.ToString() + "%)";
        //    ////spctslbipl.InnerText = qntycbipltotalctsl == 0 ? "" : "(" + qntycbipltotalctsl.ToString() + "%)";


        //    ////HtmlGenericControl spCurrentValueCumulativeSum_c45 = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentValueCumulativeSum_c45");
        //    ////HtmlGenericControl spCurrentValueCumulativeSum_c46 = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentValueCumulativeSum_c46");
        //    ////HtmlGenericControl spCurrentValueCumulativeSum_out = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentValueCumulativeSum_out");
        //    ////HtmlGenericControl spCurrentValueCumulativeSum_bipl = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentValueCumulativeSum_bipl");



        //    //////spCurrentValueCumulativeSum_c45.InnerText = qntytotal_cum.ToString("N0") + " " + "pcs";
        //    ////spCurrentValueCumulativeSum_c45.InnerText = val_cum45total == 0 ? "" : "\u20B9 " + val_cum45total;
        //    ////spCurrentValueCumulativeSum_c46.InnerText = val_cum46total == 0 ? "" : "\u20B9 " + val_cum46total;
        //    ////spCurrentValueCumulativeSum_out.InnerText = val_cumouttotal == 0 ? "" : "\u20B9 " + val_cumouttotal;
        //    ////spCurrentValueCumulativeSum_bipl.InnerText = val_cumbipltotal == 0 ? "" : "\u20B9 " + val_cumbipltotal;

        //    BindFoterSum();

        //}
        public void BindFoterSum()
        {
            //--------------------------------------C47-------------------------------------------------------------//
            //Label lblutQtyTotal_47 = (Label)gridshipemtNew.FooterRow.FindControl("lblutQtyTotal_47");
            //Label lblstitchQtyTotal_47 = (Label)gridshipemtNew.FooterRow.FindControl("lblstitchQtyTotal_47");
            //Label lblFinishQtyTotal_47 = (Label)gridshipemtNew.FooterRow.FindControl("lblFinishQtyTotal_47");
            //Label lblShipedQtyTotal_c47 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedQtyTotal_c47");
            //Label lblShipedValTotal_c47 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedValTotal_c47");
            //Label lblCtslTotal_c47 = (Label)gridshipemtNew.FooterRow.FindControl("lblCtslTotal_c47");
            //Label lblShipedPendingQtyTotal_c47 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingQtyTotal_c47");
            //Label lblShipedPendingValTotal_c47 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingValTotal_c47");

            //lblutQtyTotal_47.Text = CutQty47total == 0 ? "" : CutQty47total.ToString() + " k ";
            //lblstitchQtyTotal_47.Text = StitchQty47total == 0 ? "" : StitchQty47total.ToString() + " k "; ;
            //lblFinishQtyTotal_47.Text = FinishQty47total == 0 ? "" : FinishQty47total.ToString() + " k "; ;
            //lblShipedQtyTotal_c47.Text = ShipeQty47total == 0 ? "" : ShipeQty47total.ToString() + " k "; ;
            //lblShipedValTotal_c47.Text = ShipeValue47total == 0 ? "" : "\u20B9 " + ShipeValue47total.ToString();
            ////lblCtslTotal_c47.Text = ctsl4747total == 0 ? "" : "(" + ctsl4747total.ToString() + " % )"; ;
            //lblShipedPendingQtyTotal_c47.Text = PendingQty_47total == 0 ? "" : PendingQty_47total.ToString() + " k "; ;
            //lblShipedPendingValTotal_c47.Text = pedPendingVal_47total == 0 ? "" : " \u20B9 " + pedPendingVal_47total.ToString();





            //if ((CutQty47total != 0 & CutQty47total != 0.0) && (ShipeQty47total != 0 & ShipeQty47total != 0.0))
            //{
            //    string C47Ctsl = Math.Round(Convert.ToDouble((((CutQty47total - ShipeQty47total)*100) / Convert.ToDouble(CutQty47total))), 1, MidpointRounding.AwayFromZero).ToString();
            //    lblCtslTotal_c47.Text = C47Ctsl == "0" ? "" : "(" + C47Ctsl + " % )"; 

            //}

            if ((CutQtyCtsl_C47total != 0 & CutQtyCtsl_C47total != 0.0) && (ShipeQty47total != 0 & ShipeQty47total != 0.0))
            {
                string C47Ctsl = Math.Round(Convert.ToDouble((((CutQtyCtsl_C47total - ShipeQty47total) * 100) / Convert.ToDouble(CutQtyCtsl_C47total))), 1, MidpointRounding.AwayFromZero).ToString();
                //lblCtslTotal_c47.Text = C47Ctsl == "0" ? "" : C47Ctsl + " %";

            }



            //--------------------------------------C46C47-------------------------------------------------------------//

            //Label lblutQtyTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblutQtyTotal_4546");
            //Label lblstitchQtyTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblstitchQtyTotal_4546");
            //Label lblFinishQtyTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblFinishQtyTotal_4546");
            //Label lblShipedQtyTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedQtyTotal_4546");
            //Label lblShipedValTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedValTotal_4546");
            //Label lblCtslTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblCtslTotal_4546");
            //Label lblShipedPendingQtyTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingQtyTotal_4546");
            //Label lblShipedPendingValTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingValTotal_4546");

            //lblutQtyTotal_4546.Text = CutQty46C47 == 0 ? "" : CutQty46C47.ToString() + " k ";
            //lblstitchQtyTotal_4546.Text = StitchQty46C47 == 0 ? "" : StitchQty46C47.ToString() + " k "; ;
            //lblFinishQtyTotal_4546.Text = FinishQty46C47 == 0 ? "" : FinishQty46C47.ToString() + " k "; ;
            //lblShipedQtyTotal_4546.Text = ShipeQty46C47 == 0 ? "" : ShipeQty46C47.ToString() + " k "; ;
            //lblShipedValTotal_4546.Text = ShipeValue46C47 == 0 ? "" : "\u20B9 " + ShipeValue46C47.ToString();
            //// lblCtslTotal_4546.Text = ctsl46C47 == 0 ? "" : "(" + ctsl46C47.ToString() + " % )"; ;
            //lblShipedPendingQtyTotal_4546.Text = PendingQty46C47total == 0 ? "" : PendingQty46C47total.ToString() + " k "; ;
            //lblShipedPendingValTotal_4546.Text = pedPendingVal46C47total == 0 ? "" : " \u20B9 " + pedPendingVal46C47total.ToString();

            //if ((CutQty46C47 != 0 & CutQty46C47 != 0.0) && (ShipeQty46C47 != 0 & ShipeQty46C47 != 0.0))
            //{
            //    string C46C47Ctsl = Math.Round(Convert.ToDouble((((CutQty46C47 - ShipeQty46C47)*100) / Convert.ToDouble(CutQty46C47))), 1, MidpointRounding.AwayFromZero).ToString();

            //    lblCtslTotal_4546.Text = C46C47Ctsl == "0" ? "" : "(" + C46C47Ctsl.ToString() + " % )"; ;
            //}
            if ((CutQtyCtsl_46C47total != 0 & CutQtyCtsl_46C47total != 0.0) && (ShipeQty46C47 != 0 & ShipeQty46C47 != 0.0))
            {
                string C46C47Ctsl = Math.Round(Convert.ToDouble((((CutQtyCtsl_46C47total - ShipeQty46C47) * 100) / Convert.ToDouble(CutQtyCtsl_46C47total))), 1, MidpointRounding.AwayFromZero).ToString();

                //lblCtslTotal_4546.Text = C46C47Ctsl == "0" ? "" : C46C47Ctsl.ToString() + "%";
            }
            //--------------------------------------BIPL-------------------------------------------------------------//

            //Label lblutQtyTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblutQtyTotal_BIPL");
            //Label lblstitchQtyTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblstitchQtyTotal_BIPL");
            //Label lblFinishQtyTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblFinishQtyTotal_BIPL");
            //Label lblShipedQtyTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedQtyTotal_BIPL");
            //Label lblShipedValTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedValTotal_BIPL");
            //Label lblCtslTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblCtslTotal_BIPL");
            //Label lblShipedPendingQtyTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingQtyTotal_BIPL");
            //Label lblShipedPendingValTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingValTotal_BIPL");

            //lblutQtyTotal_BIPL.Text = CutQtyBIPL == 0 ? "" : CutQtyBIPL.ToString() + " k ";
            //lblstitchQtyTotal_BIPL.Text = StitchQtyBIPL == 0 ? "" : StitchQtyBIPL.ToString() + " k "; ;
            //lblFinishQtyTotal_BIPL.Text = FinishQtyBIPL == 0 ? "" : FinishQtyBIPL.ToString() + " k "; ;
            //lblShipedQtyTotal_BIPL.Text = ShipeQtyBIPL == 0 ? "" : ShipeQtyBIPL.ToString() + " k "; ;
            //lblShipedValTotal_BIPL.Text = ShipeValueBIPL == 0 ? "" : " \u20B9 " + ShipeValueBIPL.ToString();
            ////lblCtslTotal_BIPL.Text = ctslBIPL == 0 ? "" : "(" + ctslBIPL.ToString() + " % )"; ;
            //lblShipedPendingQtyTotal_BIPL.Text = PendingQtyBIPL == 0 ? "" : PendingQtyBIPL.ToString() + " k "; ;
            //lblShipedPendingValTotal_BIPL.Text = pedPendingValBIPL == 0 ? "" : " \u20B9 " + pedPendingValBIPL.ToString();


            //if ((CutQtyBIPL != 0 & CutQtyBIPL != 0.0) && (ShipeQtyBIPL != 0 & ShipeQtyBIPL != 0.0))
            //{
            //    string CbiplCtsl = Math.Round(Convert.ToDouble((((CutQtyBIPL - ShipeQtyBIPL)*100) / Convert.ToDouble(CutQtyBIPL))), 1, MidpointRounding.AwayFromZero).ToString();

            //    lblCtslTotal_BIPL.Text = CbiplCtsl == "0" ? "" : "(" + CbiplCtsl.ToString() + " % )"; ;
            //}

            if ((CutQtyCtsl_BIPLtotal != 0 & CutQtyCtsl_BIPLtotal != 0.0) && (ShipeQtyBIPL != 0 & ShipeQtyBIPL != 0.0))
            {
                string CbiplCtsl = Math.Round(Convert.ToDouble((((CutQtyCtsl_BIPLtotal - ShipeQtyBIPL) * 100) / Convert.ToDouble(CutQtyCtsl_BIPLtotal))), 1, MidpointRounding.AwayFromZero).ToString();

                //lblCtslTotal_BIPL.Text = CbiplCtsl == "0" ? "" : CbiplCtsl.ToString() + "%"; ;
            }
        }
        protected void gridshipemtNew_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Footer)
            {

                // TableRow tableRow = new TableRow();
                // TableCell cell1 = new TableCell();
                // cell1.Text = "Total";
                //// cell1.ColumnSpan = 8;
                // tableRow.Controls.Add(cell1);
                // cell1 = new TableCell();
                // cell1.Width = 70;
                // cell1.Text = "Sub";
                // tableRow.Controls.Add(cell1);
                // e.Row.NamingContainer.Controls.Add(tableRow);
                // You can add additional rows like this.
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblWeekDayRange = (Label)e.Row.FindControl("lblWeekDayRange");
                HiddenField hdnweekMax = (HiddenField)e.Row.FindControl("hdnweekMax");
                HiddenField hdnweekMin = (HiddenField)e.Row.FindControl("hdnweekMin");

                HiddenField hdnqntyActual_45 = (HiddenField)e.Row.FindControl("hdnqntyActual_45");
                HiddenField hdncurrentweekActual = (HiddenField)e.Row.FindControl("hdncurrentweekActual");





                if (hdnweekMax != null && hdnweekMin != null)
                {
                    if ((hdnweekMax.Value != "0" && hdnweekMax.Value != "") && (hdnweekMin.Value != "0" && hdnweekMin.Value != ""))
                    {
                        string Strdaterange = "(" + hdnweekMax.Value + "-" + hdnweekMin.Value + ")";
                        lblWeekDayRange.Text = Strdaterange;
                    }
                }
                DataSet ds = new DataSet();
                ds = objadmin.GetInceptionCountDone(Convert.ToInt32(hdnweekMax.Value), Convert.ToInt32(hdnweekMin.Value), 3);

                DataTable dtitem = new DataTable();
                DataTable dtitemlastday = new DataTable();
                dtitem = ds.Tables[0];
                dtitemlastday = ds.Tables[1];
                DataTable DtItemLastMonth = ds.Tables[2];
                //--------------------------------------C-47-------------------------------------------------------------------------
                Label lblcountrisk47 = (Label)e.Row.FindControl("lblcountrisk47");
                Label lblcounthoppm47 = (Label)e.Row.FindControl("lblcounthoppm47");

                Label lblcounttopsent47 = (Label)e.Row.FindControl("lblcounttopsent47");
                Label lblcountInline47 = (Label)e.Row.FindControl("lblcountInline47");

                Label lblcountOnline47 = (Label)e.Row.FindControl("lblcountOnline47");
                Label lblcountFinal47 = (Label)e.Row.FindControl("lblcountFinal47");


                if ((hdnweekMax.Value != "0" && hdnweekMax.Value != "") && (hdnweekMin.Value != "0" && hdnweekMin.Value != ""))
                {
                    if (dtitem.Rows[0]["Risk"].ToString() != "" && dtitem.Rows[0]["Risk"].ToString() != "0" && dtitem.Rows[0]["Risk"].ToString() != "0.0")
                    {
                        lblcountrisk47.Text = dtitem.Rows[0]["Risk"].ToString();
                    }


                    if (dtitemlastday.Rows[0]["Risk"].ToString() != "" && dtitemlastday.Rows[0]["Risk"].ToString() != "0" && dtitemlastday.Rows[0]["Risk"].ToString() != "0.0")
                    {
                        lblrisk47.Text = dtitemlastday.Rows[0]["Risk"].ToString();
                    }
                    if (DtItemLastMonth.Rows[0]["Risk"].ToString() != "" && DtItemLastMonth.Rows[0]["Risk"].ToString() != "0" && DtItemLastMonth.Rows[0]["Risk"].ToString() != "0.0")
                    {
                        lblrisklastmonth47.Text = DtItemLastMonth.Rows[0]["Risk"].ToString();
                    }
                    //---------Hoppm
                    if (dtitem.Rows[0]["Hoppm"].ToString() != "" && dtitem.Rows[0]["Hoppm"].ToString() != "0" && dtitem.Rows[0]["Hoppm"].ToString() != "0.0")
                    {
                        lblcounthoppm47.Text = dtitem.Rows[0]["Hoppm"].ToString();
                    }
                    if (dtitemlastday.Rows[0]["Hoppm"].ToString() != "" && dtitemlastday.Rows[0]["Hoppm"].ToString() != "0" && dtitemlastday.Rows[0]["Hoppm"].ToString() != "0.0")
                    {
                        lblhoppm47.Text = dtitemlastday.Rows[0]["Hoppm"].ToString();
                    }
                    if (DtItemLastMonth.Rows[0]["Hoppm"].ToString() != "" && DtItemLastMonth.Rows[0]["Hoppm"].ToString() != "0" && DtItemLastMonth.Rows[0]["Hoppm"].ToString() != "0.0")
                    {
                        lbllastmonthhoppm.Text = DtItemLastMonth.Rows[0]["Hoppm"].ToString();
                    }
                    //---------topsent
                    if (dtitem.Rows[0]["Topsent"].ToString() != "" && dtitem.Rows[0]["Topsent"].ToString() != "0" && dtitem.Rows[0]["Topsent"].ToString() != "0.0")
                    {
                        lblcounttopsent47.Text = dtitem.Rows[0]["Topsent"].ToString();
                    }
                    if (dtitemlastday.Rows[0]["Topsent"].ToString() != "" && dtitemlastday.Rows[0]["Topsent"].ToString() != "0" && dtitemlastday.Rows[0]["Topsent"].ToString() != "0.0")
                    {
                        lbltopsent47.Text = dtitemlastday.Rows[0]["Topsent"].ToString();
                    }
                    if (DtItemLastMonth.Rows[0]["Topsent"].ToString() != "" && DtItemLastMonth.Rows[0]["Topsent"].ToString() != "0" && DtItemLastMonth.Rows[0]["Topsent"].ToString() != "0.0")
                    {
                        lbllastmonthtopsent.Text = DtItemLastMonth.Rows[0]["Topsent"].ToString();
                    }

                    //---------Inline
                    if (dtitem.Rows[0]["Inline"].ToString() != "" && dtitem.Rows[0]["Inline"].ToString() != "0" && dtitem.Rows[0]["Inline"].ToString() != "0.0")
                    {
                        lblcountInline47.Text = dtitem.Rows[0]["Inline"].ToString();
                    }
                    if (dtitemlastday.Rows[0]["Inline"].ToString() != "" && dtitemlastday.Rows[0]["Inline"].ToString() != "0" && dtitemlastday.Rows[0]["Inline"].ToString() != "0.0")
                    {
                        lblInline47.Text = dtitemlastday.Rows[0]["Inline"].ToString();
                    }
                    if (DtItemLastMonth.Rows[0]["Inline"].ToString() != "" && DtItemLastMonth.Rows[0]["Inline"].ToString() != "0" && DtItemLastMonth.Rows[0]["Inline"].ToString() != "0.0")
                    {
                        lbllastmonthinline.Text = DtItemLastMonth.Rows[0]["Inline"].ToString();
                    }
                    //---------Online
                    if (dtitem.Rows[0]["Online"].ToString() != "" && dtitem.Rows[0]["Online"].ToString() != "0" && dtitem.Rows[0]["Online"].ToString() != "0.0")
                    {
                        lblcountOnline47.Text = dtitem.Rows[0]["Online"].ToString();
                    }
                    if (dtitemlastday.Rows[0]["Online"].ToString() != "" && dtitemlastday.Rows[0]["Online"].ToString() != "0" && dtitemlastday.Rows[0]["Online"].ToString() != "0.0")
                    {
                        lblonline47.Text = dtitemlastday.Rows[0]["Online"].ToString();
                    }
                    if (DtItemLastMonth.Rows[0]["Online"].ToString() != "" && DtItemLastMonth.Rows[0]["Online"].ToString() != "0" && DtItemLastMonth.Rows[0]["Online"].ToString() != "0.0")
                    {
                        lbllastmonthOnline.Text = DtItemLastMonth.Rows[0]["Online"].ToString();
                    }

                    //---------Final
                    if (dtitem.Rows[0]["Final"].ToString() != "" && dtitem.Rows[0]["Final"].ToString() != "0" && dtitem.Rows[0]["Final"].ToString() != "0.0")
                    {
                        lblcountFinal47.Text = dtitem.Rows[0]["Final"].ToString();
                    }
                    if (dtitemlastday.Rows[0]["Final"].ToString() != "" && dtitemlastday.Rows[0]["Final"].ToString() != "0" && dtitemlastday.Rows[0]["Final"].ToString() != "0.0")
                    {
                        lblfinal47.Text = dtitemlastday.Rows[0]["Final"].ToString();
                    }
                    if (DtItemLastMonth.Rows[0]["Final"].ToString() != "" && DtItemLastMonth.Rows[0]["Final"].ToString() != "0" && DtItemLastMonth.Rows[0]["Final"].ToString() != "0.0")
                    {
                        lbllastmonthFinal.Text = DtItemLastMonth.Rows[0]["Final"].ToString();
                    }

                    Label lblcountrisk4546 = (Label)e.Row.FindControl("lblcountrisk4546");
                    Label lblcounthoppm4546 = (Label)e.Row.FindControl("lblcounthoppm4546");

                    Label lblcounttopsent4546 = (Label)e.Row.FindControl("lblcounttopsent4546");
                    Label lblcountInline4546 = (Label)e.Row.FindControl("lblcountInline4546");

                    Label lblcountOnline4546 = (Label)e.Row.FindControl("lblcountOnline4546");
                    Label lblcountFinal4546 = (Label)e.Row.FindControl("lblcountFinal4546");

                    //-------------------------------------------C-45/46---------------------------------------------------------------------
                    DataSet ds4546 = new DataSet();
                    ds4546 = objadmin.GetInceptionCountDone(Convert.ToInt32(hdnweekMax.Value), Convert.ToInt32(hdnweekMin.Value), 11);

                    DataTable dtitem4645 = new DataTable();
                    DataTable dtitem4645lastday = new DataTable();
                    dtitem4645 = ds4546.Tables[0];
                    dtitem4645lastday = ds4546.Tables[1];
                    DataTable DtItemLastMonth4546 = ds4546.Tables[2];



                    if (dtitem4645.Rows[0]["Risk"].ToString() != "" && dtitem4645.Rows[0]["Risk"].ToString() != "0" && dtitem4645.Rows[0]["Risk"].ToString() != "0.0")
                    {
                        lblcountrisk4546.Text = dtitem4645.Rows[0]["Risk"].ToString();
                    }


                    if (dtitem4645lastday.Rows[0]["Risk"].ToString() != "" && dtitem4645lastday.Rows[0]["Risk"].ToString() != "0" && dtitem4645lastday.Rows[0]["Risk"].ToString() != "0.0")
                    {
                        lblrisk4546.Text = dtitem4645lastday.Rows[0]["Risk"].ToString();
                    }
                    if (DtItemLastMonth4546.Rows[0]["Risk"].ToString() != "" && DtItemLastMonth4546.Rows[0]["Risk"].ToString() != "0" && DtItemLastMonth4546.Rows[0]["Risk"].ToString() != "0.0")
                    {
                        lbllastmonthRiskC45C46.Text = DtItemLastMonth4546.Rows[0]["Risk"].ToString();
                    }
                    //---------Hoppm
                    if (dtitem4645.Rows[0]["Hoppm"].ToString() != "" && dtitem4645.Rows[0]["Hoppm"].ToString() != "0" && dtitem4645.Rows[0]["Hoppm"].ToString() != "0.0")
                    {
                        lblcounthoppm4546.Text = dtitem4645.Rows[0]["Hoppm"].ToString();
                    }
                    if (dtitem4645lastday.Rows[0]["Hoppm"].ToString() != "" && dtitem4645lastday.Rows[0]["Hoppm"].ToString() != "0" && dtitem4645lastday.Rows[0]["Hoppm"].ToString() != "0.0")
                    {
                        lblhoppm4546.Text = dtitem4645lastday.Rows[0]["Hoppm"].ToString();
                    }
                    if (DtItemLastMonth4546.Rows[0]["Hoppm"].ToString() != "" && DtItemLastMonth4546.Rows[0]["Hoppm"].ToString() != "0" && DtItemLastMonth4546.Rows[0]["Hoppm"].ToString() != "0.0")
                    {
                        lbllastMonthHoppmC45C46.Text = DtItemLastMonth4546.Rows[0]["Hoppm"].ToString();
                    }
                    //---------topsent
                    if (dtitem4645.Rows[0]["Topsent"].ToString() != "" && dtitem4645.Rows[0]["Topsent"].ToString() != "0" && dtitem4645.Rows[0]["Topsent"].ToString() != "0.0")
                    {
                        lblcounttopsent4546.Text = dtitem4645.Rows[0]["Topsent"].ToString();
                    }
                    if (dtitem4645lastday.Rows[0]["Topsent"].ToString() != "" && dtitem4645lastday.Rows[0]["Topsent"].ToString() != "0" && dtitem4645lastday.Rows[0]["Topsent"].ToString() != "0.0")
                    {
                        lbltopsent4546.Text = dtitem4645lastday.Rows[0]["Topsent"].ToString();
                    }
                    if (DtItemLastMonth4546.Rows[0]["Topsent"].ToString() != "" && DtItemLastMonth4546.Rows[0]["Topsent"].ToString() != "0" && DtItemLastMonth4546.Rows[0]["Topsent"].ToString() != "0.0")
                    {
                        lblLastmonthTopsentC45C46.Text = DtItemLastMonth4546.Rows[0]["Topsent"].ToString();
                    }

                    //---------Inline
                    if (dtitem4645.Rows[0]["Inline"].ToString() != "" && dtitem4645.Rows[0]["Inline"].ToString() != "0" && dtitem4645.Rows[0]["Inline"].ToString() != "0.0")
                    {
                        lblcountInline4546.Text = dtitem4645.Rows[0]["Inline"].ToString();
                    }
                    if (dtitem4645lastday.Rows[0]["Inline"].ToString() != "" && dtitem4645lastday.Rows[0]["Inline"].ToString() != "0" && dtitem4645lastday.Rows[0]["Inline"].ToString() != "0.0")
                    {
                        lblInline4546.Text = dtitem4645lastday.Rows[0]["Inline"].ToString();
                    }
                    if (DtItemLastMonth4546.Rows[0]["Inline"].ToString() != "" && DtItemLastMonth4546.Rows[0]["Inline"].ToString() != "0" && DtItemLastMonth4546.Rows[0]["Inline"].ToString() != "0.0")
                    {
                        lblLastMonthinlineC45C46.Text = DtItemLastMonth4546.Rows[0]["Inline"].ToString();
                    }
                    //---------Online
                    if (dtitem4645.Rows[0]["Online"].ToString() != "" && dtitem4645.Rows[0]["Online"].ToString() != "0" && dtitem4645.Rows[0]["Online"].ToString() != "0.0")
                    {
                        lblcountOnline4546.Text = dtitem4645.Rows[0]["Online"].ToString();
                    }
                    if (dtitem4645lastday.Rows[0]["Online"].ToString() != "" && dtitem4645lastday.Rows[0]["Online"].ToString() != "0" && dtitem4645lastday.Rows[0]["Online"].ToString() != "0.0")
                    {
                        lblonline4546.Text = dtitem4645lastday.Rows[0]["Online"].ToString();
                    }
                    if (DtItemLastMonth4546.Rows[0]["Online"].ToString() != "" && DtItemLastMonth4546.Rows[0]["Online"].ToString() != "0" && DtItemLastMonth4546.Rows[0]["Online"].ToString() != "0.0")
                    {
                        lblLastMonthOnlineC45C46.Text = DtItemLastMonth4546.Rows[0]["Online"].ToString();
                    }

                    //---------Final
                    if (dtitem4645.Rows[0]["Final"].ToString() != "" && dtitem4645.Rows[0]["Final"].ToString() != "0" && dtitem4645.Rows[0]["Final"].ToString() != "0.0")
                    {
                        lblcountFinal4546.Text = dtitem4645.Rows[0]["Final"].ToString();
                    }
                    if (dtitem4645lastday.Rows[0]["Final"].ToString() != "" && dtitem4645lastday.Rows[0]["Final"].ToString() != "0" && dtitem4645lastday.Rows[0]["Final"].ToString() != "0.0")
                    {
                        lblfinal4546.Text = dtitem4645lastday.Rows[0]["Final"].ToString();
                    }
                    if (DtItemLastMonth4546.Rows[0]["Final"].ToString() != "" && DtItemLastMonth4546.Rows[0]["Final"].ToString() != "0" && DtItemLastMonth4546.Rows[0]["Final"].ToString() != "0.0")
                    {
                        lblLastMonthFinalC45C46.Text = DtItemLastMonth4546.Rows[0]["Final"].ToString();
                    }

                    //-------------------------------------------BIPL---------------------------------------------------------------------

                    Label lblcountriskBipl = (Label)e.Row.FindControl("lblcountriskBipl");
                    Label lblcounthoppmBipl = (Label)e.Row.FindControl("lblcounthoppmBipl");

                    Label lblcounttopsentBipl = (Label)e.Row.FindControl("lblcounttopsentBipl");
                    Label lblcountInlineBipl = (Label)e.Row.FindControl("lblcountInlineBipl");

                    Label lblcountOnlineBipl = (Label)e.Row.FindControl("lblcountOnlineBipl");
                    Label lblcountFinalBipl = (Label)e.Row.FindControl("lblcountFinalBipl");


                    DataSet dsbipl = new DataSet();
                    dsbipl = objadmin.GetInceptionCountDone(Convert.ToInt32(hdnweekMax.Value), Convert.ToInt32(hdnweekMin.Value), 0);

                    DataTable dtitembipl = new DataTable();
                    DataTable dtitembiplLastday = new DataTable();
                    dtitembipl = dsbipl.Tables[0];
                    dtitembiplLastday = dsbipl.Tables[1];
                    DataTable DtItemLastMonthBipl = dsbipl.Tables[2];
                    Label lblutQty_bipl = (Label)e.Row.FindControl("lblutQty_bipl");

                    if (dtitembipl.Rows[0]["Risk"].ToString() != "" && dtitembipl.Rows[0]["Risk"].ToString() != "0" && dtitembipl.Rows[0]["Risk"].ToString() != "0.0")
                    {
                        lblcountriskBipl.Text = dtitembipl.Rows[0]["Risk"].ToString();
                    }


                    if (dtitembiplLastday.Rows[0]["Risk"].ToString() != "" && dtitembiplLastday.Rows[0]["Risk"].ToString() != "0" && dtitembiplLastday.Rows[0]["Risk"].ToString() != "0.0")
                    {
                        lblriskbipl.Text = dtitembiplLastday.Rows[0]["Risk"].ToString();
                    }
                    if (DtItemLastMonthBipl.Rows[0]["Risk"].ToString() != "" && DtItemLastMonthBipl.Rows[0]["Risk"].ToString() != "0" && DtItemLastMonthBipl.Rows[0]["Risk"].ToString() != "0.0")
                    {
                        lblLastMonthRiskbipl.Text = DtItemLastMonthBipl.Rows[0]["Risk"].ToString();
                    }
                    //---------Hoppm
                    if (dtitembipl.Rows[0]["Hoppm"].ToString() != "" && dtitembipl.Rows[0]["Hoppm"].ToString() != "0" && dtitembipl.Rows[0]["Hoppm"].ToString() != "0.0")
                    {
                        lblcounthoppmBipl.Text = dtitembipl.Rows[0]["Hoppm"].ToString();
                    }
                    if (dtitembiplLastday.Rows[0]["Hoppm"].ToString() != "" && dtitembiplLastday.Rows[0]["Hoppm"].ToString() != "0" && dtitembiplLastday.Rows[0]["Hoppm"].ToString() != "0.0")
                    {
                        lblhoppmbipl.Text = dtitembiplLastday.Rows[0]["Hoppm"].ToString();
                    }
                    if (DtItemLastMonthBipl.Rows[0]["Hoppm"].ToString() != "" && DtItemLastMonthBipl.Rows[0]["Hoppm"].ToString() != "0" && DtItemLastMonthBipl.Rows[0]["Hoppm"].ToString() != "0.0")
                    {
                        lblLastMonthHoppmbipl.Text = DtItemLastMonthBipl.Rows[0]["Hoppm"].ToString();
                    }
                    //---------topsent
                    if (dtitembipl.Rows[0]["Topsent"].ToString() != "" && dtitembipl.Rows[0]["Topsent"].ToString() != "0" && dtitembipl.Rows[0]["Topsent"].ToString() != "0.0")
                    {
                        lblcounttopsentBipl.Text = dtitembipl.Rows[0]["Topsent"].ToString();
                    }
                    if (dtitembiplLastday.Rows[0]["Topsent"].ToString() != "" && dtitembiplLastday.Rows[0]["Topsent"].ToString() != "0" && dtitembiplLastday.Rows[0]["Topsent"].ToString() != "0.0")
                    {
                        lbltopsentbipl.Text = dtitembiplLastday.Rows[0]["Topsent"].ToString();
                    }
                    if (DtItemLastMonthBipl.Rows[0]["Topsent"].ToString() != "" && DtItemLastMonthBipl.Rows[0]["Topsent"].ToString() != "0" && DtItemLastMonthBipl.Rows[0]["Topsent"].ToString() != "0.0")
                    {
                        lblLastMonthTopsentbipl.Text = DtItemLastMonthBipl.Rows[0]["Topsent"].ToString();
                    }

                    //---------Inline
                    if (dtitembipl.Rows[0]["Inline"].ToString() != "" && dtitembipl.Rows[0]["Inline"].ToString() != "0" && dtitembipl.Rows[0]["Inline"].ToString() != "0.0")
                    {
                        lblcountInlineBipl.Text = dtitembipl.Rows[0]["Inline"].ToString();
                    }
                    if (dtitembiplLastday.Rows[0]["Inline"].ToString() != "" && dtitembiplLastday.Rows[0]["Inline"].ToString() != "0" && dtitembiplLastday.Rows[0]["Inline"].ToString() != "0.0")
                    {
                        lblinlinebipl.Text = dtitembiplLastday.Rows[0]["Inline"].ToString();
                    }
                    if (DtItemLastMonthBipl.Rows[0]["Inline"].ToString() != "" && DtItemLastMonthBipl.Rows[0]["Inline"].ToString() != "0" && DtItemLastMonthBipl.Rows[0]["Inline"].ToString() != "0.0")
                    {
                        lblLastMonthInlinebipl.Text = DtItemLastMonthBipl.Rows[0]["Inline"].ToString();
                    }
                    //---------Online
                    if (dtitembipl.Rows[0]["Online"].ToString() != "" && dtitembipl.Rows[0]["Online"].ToString() != "0" && dtitembipl.Rows[0]["Online"].ToString() != "0.0")
                    {
                        lblcountOnlineBipl.Text = dtitembipl.Rows[0]["Online"].ToString();
                    }
                    if (dtitembiplLastday.Rows[0]["Online"].ToString() != "" && dtitembiplLastday.Rows[0]["Online"].ToString() != "0" && dtitembiplLastday.Rows[0]["Online"].ToString() != "0.0")
                    {
                        lblonlinebipl.Text = dtitembiplLastday.Rows[0]["Online"].ToString();
                    }
                    if (DtItemLastMonthBipl.Rows[0]["Online"].ToString() != "" && DtItemLastMonthBipl.Rows[0]["Online"].ToString() != "0" && DtItemLastMonthBipl.Rows[0]["Online"].ToString() != "0.0")
                    {
                        lblOnlineLastMonthbipl.Text = DtItemLastMonthBipl.Rows[0]["Online"].ToString();
                    }

                    //---------Final
                    if (dtitembipl.Rows[0]["Final"].ToString() != "" && dtitembipl.Rows[0]["Final"].ToString() != "0" && dtitembipl.Rows[0]["Final"].ToString() != "0.0")
                    {
                        lblcountFinalBipl.Text = dtitembipl.Rows[0]["Final"].ToString();
                    }
                    if (dtitembiplLastday.Rows[0]["Final"].ToString() != "" && dtitembiplLastday.Rows[0]["Final"].ToString() != "0" && dtitembiplLastday.Rows[0]["Final"].ToString() != "0.0")
                    {
                        lblFinalbipl.Text = dtitembiplLastday.Rows[0]["Final"].ToString();
                    }
                    if (DtItemLastMonthBipl.Rows[0]["Final"].ToString() != "" && DtItemLastMonthBipl.Rows[0]["Final"].ToString() != "0" && DtItemLastMonthBipl.Rows[0]["Final"].ToString() != "0.0")
                    {
                        lblLastMonthFinalbipl.Text = DtItemLastMonthBipl.Rows[0]["Final"].ToString();
                    }
                }

            }
        }

        protected void rptctsldetails_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
            {//GetFaultqtySum
                Label lblctsl = (Label)item.FindControl("lblctsl");
                Label lblctslqnty = (Label)item.FindControl("lblctslqnty");
                Label lblvalue = (Label)item.FindControl("lblvalue");
                if (lblvalue.Text != "0" || lblvalue.Text != "0.0")
                {
                    GetCtslVlaueSum += Convert.ToDouble(lblvalue.Text.Replace("K", "").Replace("\u20B9 ", ""));
                }
                lblvalue.Text = "\u20B9 " + lblvalue.Text + " k";
                if (lblctsl.Text == "0" || lblctsl.Text == "0.0")
                {
                    lblctsl.Text = "";
                }
                else
                {
                    lblctsl.Text = lblctsl.Text + "%";
                }
                if (lblctslqnty.Text != "0" || lblctslqnty.Text != "0.0")
                {
                    GetFaultqtySum += Convert.ToInt32(lblctslqnty.Text);
                }

            }
        }

        protected void grdhoppminspection_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                HtmlGenericControl spanICTotalCut = (HtmlGenericControl)e.Row.FindControl("spanICTotalCut");
                HtmlGenericControl spanICstichTotal = (HtmlGenericControl)e.Row.FindControl("spanICstichTotal");
                HtmlGenericControl spanicfinsidhtotal = (HtmlGenericControl)e.Row.FindControl("spanicfinsidhtotal");
                HtmlGenericControl spOrderValueIctotal = (HtmlGenericControl)e.Row.FindControl("spOrderValueIctotal");

                HtmlGenericControl Strong8 = (HtmlGenericControl)e.Row.FindControl("spOrderValueIctotal");
                HtmlGenericControl spanICTotalContract = (HtmlGenericControl)e.Row.FindControl("spanICTotalContract");


                // HtmlGenericControl Spstatusrisk = (HtmlGenericControl)e.Row.FindControl("Spstatusrisk");
                Label Spstatusriskcount = (Label)e.Row.FindControl("Spstatusriskcount");

                //HtmlGenericControl Spstatushoppm = (HtmlGenericControl)e.Row.FindControl("Spstatushoppm");
                Label Spstatushoppmcount = (Label)e.Row.FindControl("Spstatushoppmcount");

                //HtmlGenericControl Spstatushoppmtop = (HtmlGenericControl)e.Row.FindControl("Spstatushoppmtop");
                Label Spstatushoppmtopcount = (Label)e.Row.FindControl("Spstatushoppmtopcount");


                // HtmlGenericControl Spstatushoppminline = (HtmlGenericControl)e.Row.FindControl("Spstatushoppminline");
                Label Spstatushoppminlinecount = (Label)e.Row.FindControl("Spstatushoppminlinecount");


                //HtmlGenericControl Spstatushoppmonline = (HtmlGenericControl)e.Row.FindControl("Spstatushoppmonline");
                Label SpstatushoppmonlineCount = (Label)e.Row.FindControl("SpstatushoppmonlineCount");

                // HtmlGenericControl Spstatushoppmfinal = (HtmlGenericControl)e.Row.FindControl("Spstatushoppmfinal");
                Label Spstatushoppmfinalcount = (Label)e.Row.FindControl("Spstatushoppmfinalcount");

                Spstatusriskcount.Text = dtpendingCount.Rows[0]["Risk"].ToString();
                Spstatushoppmcount.Text = dtpendingCount.Rows[0]["hoppm"].ToString();
                Spstatushoppmtopcount.Text = dtpendingCount.Rows[0]["topsent"].ToString();
                Spstatushoppminlinecount.Text = dtpendingCount.Rows[0]["inline"].ToString();
                SpstatushoppmonlineCount.Text = dtpendingCount.Rows[0]["online"].ToString();
                Spstatushoppmfinalcount.Text = dtpendingCount.Rows[0]["finish"].ToString();

                Spstatusriskcount.Text = Spstatusriskcount.Text != "0" ? "<b style='font-size:12px;'>" + Spstatusriskcount.Text + "</b>" : "";
                Spstatushoppmcount.Text = Spstatushoppmcount.Text != "0" ? "<b style='font-size:12px;'>" + Spstatushoppmcount.Text + "</b>" : "";
                Spstatushoppmtopcount.Text = Spstatushoppmtopcount.Text != "0" ? "<b style='font-size:12px;'>" + Spstatushoppmtopcount.Text + "</b>" : "";
                Spstatushoppminlinecount.Text = Spstatushoppminlinecount.Text != "0" ? "<b style='font-size:12px;'>" + Spstatushoppminlinecount.Text + "</b>" : "";
                SpstatushoppmonlineCount.Text = SpstatushoppmonlineCount.Text != "0" ? "<b style='font-size:12px;'>" + SpstatushoppmonlineCount.Text + "</b>" : "";
                Spstatushoppmfinalcount.Text = Spstatushoppmfinalcount.Text != "0" ? "<b style='font-size:12px;'>" + Spstatushoppmfinalcount.Text + "</b>" : "";


                e.Row.Cells[1].Visible = false;
                e.Row.Cells[0].Attributes.Add("colspan", "2");

                if (dtitem_ic_foter.Rows[0]["totalcutQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["totalcutQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["totalcutQty"].ToString() != "0.0")
                {
                    spanICTotalCut.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["totalcutQty"].ToString()).ToString("N0") + " " + "Pcs";
                }

                if (dtitem_ic_foter.Rows[0]["totalstichQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["totalstichQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["totalstichQty"].ToString() != "0.0")
                {
                    spanICstichTotal.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["totalstichQty"].ToString()).ToString("N0") + " " + "Pcs";
                }


                if (dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString() != "0.0")
                {
                    spanicfinsidhtotal.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString()).ToString("N0") + " " + "Pcs";
                }



                if (dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "" && dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "0" && dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "0.0" && dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "0.00")
                {
                    spOrderValueIctotal.InnerText = "\u20B9 " + dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() + " Cr";
                }
                if (dtitem_ic_foter.Rows[0]["ContractQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["ContractQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["ContractQty"].ToString() != "0.0")
                {
                    spanICTotalContract.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["ContractQty"].ToString()).ToString("N0") + " " + "Pcs";
                }


            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblContactNo = (Label)e.Row.FindControl("lblContactNo");
                Label lblLineitemNo = (Label)e.Row.FindControl("lblLineitemNo");


                Label lbltotalcutqty = (Label)e.Row.FindControl("lbltotalcutqty");


                if (lbltotalcutqty.Text != "" && lbltotalcutqty.Text != "0")
                {
                    lbltotalcutqty.Text = Convert.ToInt32(lbltotalcutqty.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lbltotalcutqty.Text = "";
                }

                Label lblPrice = (Label)e.Row.FindControl("lblPrice");
                HiddenField hdnCurrenyTag = (HiddenField)e.Row.FindControl("hdnCurrenyTag");

                string StrTag = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType((Convert.ToInt32(hdnCurrenyTag.Value)));

                if (lblPrice.Text != "" && lblPrice.Text != "0" && lblPrice.Text != "0.0")
                {

                    lblPrice.Text = StrTag + " " + Math.Round(Convert.ToDouble(lblPrice.Text), 2, MidpointRounding.AwayFromZero).ToString();
                }
                else
                {
                    lblPrice.Text = "";
                }

                Label lbltotalcontractqty = (Label)e.Row.FindControl("lbltotalcontractqty");

                if (lbltotalcontractqty.Text != "" && lbltotalcontractqty.Text != "0" && lbltotalcontractqty.Text != "0.0")
                {
                    lbltotalcontractqty.Text = Convert.ToInt32(lbltotalcontractqty.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lbltotalcontractqty.Text = "";
                }


                Label lbltotalstich = (Label)e.Row.FindControl("lbltotalstich");

                if (lbltotalstich.Text != "" && lbltotalstich.Text != "0" && lbltotalstich.Text != "0.0")
                {
                    lbltotalstich.Text = Convert.ToInt32(lbltotalstich.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lbltotalstich.Text = "";
                }


                Label lblTotalFinishedQty = (Label)e.Row.FindControl("lblTotalFinishedQty");

                if (lblTotalFinishedQty.Text != "" && lblTotalFinishedQty.Text != "0" && lblTotalFinishedQty.Text != "0.0")
                {
                    lblTotalFinishedQty.Text = Convert.ToInt32(lblTotalFinishedQty.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lblTotalFinishedQty.Text = "";
                }

                Label lblOrderValueValue = (Label)e.Row.FindControl("lblOrderValueValue");

                if (lblOrderValueValue.Text != "" && lblOrderValueValue.Text != "0" && lblOrderValueValue.Text != "0.0")
                {
                    lblOrderValueValue.Text = "\u20B9 " + Math.Round((Convert.ToDouble(lblOrderValueValue.Text)), 2, MidpointRounding.AwayFromZero).ToString();


                }
                else
                {
                    lblOrderValueValue.Text = "";
                }

                Label lblhoppmstatus = (Label)e.Row.FindControl("lblhoppmstatus");
                Label lblrisk = (Label)e.Row.FindControl("lblrisk");
                Label lblInceptionInline = (Label)e.Row.FindControl("lblInceptionInline");
                Label lblInceptionOnline = (Label)e.Row.FindControl("lblInceptionOnline");
                Label lblFinish = (Label)e.Row.FindControl("lblFinish");
                Label lbltop = (Label)e.Row.FindControl("lbltop");
                HiddenField hdnOrderdetailID = (HiddenField)e.Row.FindControl("hdnOrderdetailID");


                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                if (hdnOrderdetailID != null && hdnOrderdetailID.Value != "")
                {
                    ds = objadmin.GetShipmentReportByICBIPL_ordring(Convert.ToInt32(hdnOrderdetailID.Value), "HOPPM");
                    dt = ds.Tables[0];
                    if (dt.Rows.Count == 1)
                    {
                        lblrisk.Text = dt.Rows[0]["StatusName"].ToString();
                    }
                    if (dt.Rows.Count == 2)
                    {
                        lblrisk.Text = dt.Rows[0]["StatusName"].ToString();
                        lblhoppmstatus.Text = dt.Rows[1]["StatusName"].ToString();
                    }
                    if (dt.Rows.Count == 3)
                    {
                        lblrisk.Text = dt.Rows[0]["StatusName"].ToString();
                        lblhoppmstatus.Text = dt.Rows[1]["StatusName"].ToString();
                        lbltop.Text = dt.Rows[2]["StatusName"].ToString();
                    }
                    if (dt.Rows.Count == 4)
                    {
                        lblrisk.Text = dt.Rows[0]["StatusName"].ToString();
                        lblhoppmstatus.Text = dt.Rows[1]["StatusName"].ToString();
                        lbltop.Text = dt.Rows[2]["StatusName"].ToString();
                        lblInceptionInline.Text = dt.Rows[3]["StatusName"].ToString();
                    }
                    if (dt.Rows.Count == 5)
                    {
                        lblrisk.Text = dt.Rows[0]["StatusName"].ToString();
                        lblhoppmstatus.Text = dt.Rows[1]["StatusName"].ToString();
                        lbltop.Text = dt.Rows[2]["StatusName"].ToString();
                        lblInceptionInline.Text = dt.Rows[3]["StatusName"].ToString();
                        lblInceptionOnline.Text = dt.Rows[4]["StatusName"].ToString();
                    }
                    if (dt.Rows.Count == 6)
                    {
                        lblrisk.Text = dt.Rows[0]["StatusName"].ToString();
                        lblhoppmstatus.Text = dt.Rows[1]["StatusName"].ToString();
                        lbltop.Text = dt.Rows[2]["StatusName"].ToString();
                        lblInceptionInline.Text = dt.Rows[3]["StatusName"].ToString();
                        lblInceptionOnline.Text = dt.Rows[4]["StatusName"].ToString();
                        lblFinish.Text = dt.Rows[5]["StatusName"].ToString();
                    }

                }





                if (lblhoppmstatus.Text != "")
                {

                    bool conts_done = lblhoppmstatus.Text.Contains("Done") || lblhoppmstatus.Text.Contains("done");
                    bool conts_pending = lblhoppmstatus.Text.Contains("Pending") || lblhoppmstatus.Text.Contains("pending");

                    int pos_done = lblhoppmstatus.Text.IndexOf("Done", StringComparison.CurrentCultureIgnoreCase);
                    int pos_pending = lblhoppmstatus.Text.IndexOf("Pending", StringComparison.CurrentCultureIgnoreCase);
                    if (conts_done)
                    {
                        if (pos_done > -1)
                        {
                            lblhoppmstatus.ForeColor = Color.Gray;

                        }

                    }
                    else if (conts_pending)
                    {
                        if (pos_pending > -1)
                        {
                            lblhoppmstatus.ForeColor = Color.Red;
                        }

                    }


                }
                else
                {
                    lblhoppmstatus.Text = "";
                }

                if (lblrisk.Text != "")
                {

                    bool conts_done = lblrisk.Text.Contains("Done") || lblrisk.Text.Contains("done");
                    bool conts_pending = lblrisk.Text.Contains("Pending") || lblrisk.Text.Contains("pending");

                    int pos_done = lblrisk.Text.IndexOf("Done", StringComparison.CurrentCultureIgnoreCase);
                    int pos_pending = lblrisk.Text.IndexOf("Pending", StringComparison.CurrentCultureIgnoreCase);
                    if (conts_done)
                    {
                        if (pos_done > -1)
                        {
                            lblrisk.ForeColor = Color.Gray;

                        }

                    }
                    else if (conts_pending)
                    {
                        if (pos_pending > -1)
                        {
                            lblrisk.ForeColor = Color.Red;
                        }

                    }


                }
                else
                {
                    lblrisk.Text = "";
                }

                if (lblInceptionInline.Text != "")
                {

                    bool conts_done = lblInceptionInline.Text.Contains("Done") || lblInceptionInline.Text.Contains("done");
                    bool conts_pending = lblInceptionInline.Text.Contains("due") || lblInceptionInline.Text.Contains("due");

                    int pos_done = lblInceptionInline.Text.IndexOf("Done", StringComparison.CurrentCultureIgnoreCase);
                    int pos_pending = lblInceptionInline.Text.IndexOf("due", StringComparison.CurrentCultureIgnoreCase);
                    if (conts_done)
                    {
                        if (pos_done > -1)
                        {
                            lblInceptionInline.ForeColor = Color.Gray;

                        }

                    }
                    else if (conts_pending)
                    {
                        if (pos_pending > -1)
                        {
                            lblInceptionInline.ForeColor = Color.Red;
                        }

                    }


                }
                else
                {
                    lblInceptionInline.Text = "";
                }

                if (lblInceptionOnline.Text != "")
                {

                    bool conts_done = lblInceptionOnline.Text.Contains("Done") || lblInceptionOnline.Text.Contains("done");
                    bool conts_pending = lblInceptionOnline.Text.Contains("due") || lblInceptionOnline.Text.Contains("due");

                    int pos_done = lblInceptionOnline.Text.IndexOf("Done", StringComparison.CurrentCultureIgnoreCase);
                    int pos_pending = lblInceptionOnline.Text.IndexOf("due", StringComparison.CurrentCultureIgnoreCase);
                    if (conts_done)
                    {
                        if (pos_done > -1)
                        {
                            lblInceptionOnline.ForeColor = Color.Gray;

                        }

                    }
                    else if (conts_pending)
                    {
                        if (pos_pending > -1)
                        {
                            lblInceptionOnline.ForeColor = Color.Red;
                        }

                    }


                }
                else
                {
                    lblInceptionOnline.Text = "";
                }


                if (lblFinish.Text != "")
                {

                    bool conts_done = lblFinish.Text.Contains("Done") || lblFinish.Text.Contains("done");
                    bool conts_pending = lblFinish.Text.Contains("due") || lblFinish.Text.Contains("due");

                    int pos_done = lblFinish.Text.IndexOf("Done", StringComparison.CurrentCultureIgnoreCase);
                    int pos_pending = lblFinish.Text.IndexOf("due", StringComparison.CurrentCultureIgnoreCase);
                    if (conts_done)
                    {
                        if (pos_done > -1)
                        {
                            lblFinish.ForeColor = Color.Gray;

                        }

                    }
                    else if (conts_pending)
                    {
                        if (pos_pending > -1)
                        {
                            lblFinish.ForeColor = Color.Red;
                        }

                    }


                }
                else
                {
                    lblFinish.Text = "";
                }
                if (lbltop.Text != "")
                {

                    bool conts_done = lbltop.Text.Contains("Done") || lbltop.Text.Contains("done");
                    bool conts_pending = lbltop.Text.Contains("pending") || lbltop.Text.Contains("pending");

                    int pos_done = lbltop.Text.IndexOf("Done", StringComparison.CurrentCultureIgnoreCase);
                    int pos_pending = lbltop.Text.IndexOf("pending", StringComparison.CurrentCultureIgnoreCase);
                    if (conts_done)
                    {
                        if (pos_done > -1)
                        {
                            lbltop.ForeColor = Color.Gray;

                        }

                    }
                    else if (conts_pending)
                    {
                        if (pos_pending > -1)
                        {
                            lbltop.ForeColor = Color.Red;
                        }

                    }


                }
                else
                {
                    lbltop.Text = "";
                }
                Label lblexfactdate = (Label)e.Row.FindControl("lblexfactdate");
                if (lblexfactdate.Text != "" && lblexfactdate != null)
                {
                    lblexfactdate.Text = Convert.ToDateTime(lblexfactdate.Text).ToString("dd MMM yy (ddd)");
                }
                //Label lblinlineinspectiondate_Name = (Label)e.Row.FindControl("lblinlineinspectiondate_Name");
                //Label lblMidinspectiondateand_Name = (Label)e.Row.FindControl("lblMidinspectiondateand_Name");
                //Label lblFinalinspectiondate_Name = (Label)e.Row.FindControl("lblFinalinspectiondate_Name");
                //Label lblFinalBIHinspectiondate_Name = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name");

            }
        }

        protected void grdqadone_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //HtmlGenericControl spanICTotalCut = (HtmlGenericControl)e.Row.FindControl("spanICTotalCut");
                //HtmlGenericControl spanICstichTotal = (HtmlGenericControl)e.Row.FindControl("spanICstichTotal");
                //HtmlGenericControl spanicfinsidhtotal = (HtmlGenericControl)e.Row.FindControl("spanicfinsidhtotal");
                //HtmlGenericControl spOrderValueIctotal = (HtmlGenericControl)e.Row.FindControl("spOrderValueIctotal");

                //HtmlGenericControl Strong8 = (HtmlGenericControl)e.Row.FindControl("spOrderValueIctotal");
                //HtmlGenericControl spanICTotalContract = (HtmlGenericControl)e.Row.FindControl("spanICTotalContract");



                Label Spstatusriskcount = (Label)e.Row.FindControl("Spstatusriskcount");
                Label Spstatushoppmcount = (Label)e.Row.FindControl("Spstatushoppmcount");
                Label Spstatushoppmtopcount = (Label)e.Row.FindControl("Spstatushoppmtopcount");
                Label Spstatushoppminlinecount = (Label)e.Row.FindControl("Spstatushoppminlinecount");
                Label SpstatushoppmonlineCount = (Label)e.Row.FindControl("SpstatushoppmonlineCount");
                //Label Spstatushoppmfinalcount = (Label)e.Row.FindControl("Spstatushoppmfinalcount");

                Spstatusriskcount.Text = DoneCountRisk.ToString();
                Spstatushoppmcount.Text = DoneCountHoppm.ToString();
                Spstatushoppmtopcount.Text = DoneCountTopSent.ToString();
                Spstatushoppminlinecount.Text = DoneCountInline.ToString();
                SpstatushoppmonlineCount.Text = DoneCountOnline.ToString();
                // Spstatushoppmfinalcount.Text = DoneCountFinal.ToString();

                Spstatusriskcount.Text = Spstatusriskcount.Text != "0" ? "<b style='font-size:12px;'>" + Spstatusriskcount.Text + "</b>" : "";
                Spstatushoppmcount.Text = Spstatushoppmcount.Text != "0" ? "<b style='font-size:12px;'>" + Spstatushoppmcount.Text + "</b>" : "";
                Spstatushoppmtopcount.Text = Spstatushoppmtopcount.Text != "0" ? "<b style='font-size:12px;'>" + Spstatushoppmtopcount.Text + "</b>" : "";
                Spstatushoppminlinecount.Text = Spstatushoppminlinecount.Text != "0" ? "<b style='font-size:12px;'>" + Spstatushoppminlinecount.Text + "</b>" : "";
                SpstatushoppmonlineCount.Text = SpstatushoppmonlineCount.Text != "0" ? "<b style='font-size:12px;'>" + SpstatushoppmonlineCount.Text + "</b>" : "";
                //  Spstatushoppmfinalcount.Text = Spstatushoppmfinalcount.Text != "0" ? "<b style='font-size:12px;'>" + Spstatushoppmfinalcount.Text + "</b>" : "";


                e.Row.Cells[1].Visible = false;
                e.Row.Cells[0].Attributes.Add("colspan", "2");

                //if (dtitem_ic_foter.Rows[0]["totalcutQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["totalcutQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["totalcutQty"].ToString() != "0.0")
                //{
                //    spanICTotalCut.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["totalcutQty"].ToString()).ToString("N0") + " " + "pcs";
                //}

                //if (dtitem_ic_foter.Rows[0]["totalstichQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["totalstichQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["totalstichQty"].ToString() != "0.0")
                //{
                //    spanICstichTotal.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["totalstichQty"].ToString()).ToString("N0") + " " + "pcs";
                //}


                //if (dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString() != "0.0")
                //{
                //    spanicfinsidhtotal.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString()).ToString("N0") + " " + "pcs";
                //}



                //if (dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "" && dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "0" && dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "0.0")
                //{
                //    spOrderValueIctotal.InnerText = "\u20B9 " + dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() + "Cr";
                //}
                //if (dtitem_ic_foter.Rows[0]["ContractQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["ContractQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["ContractQty"].ToString() != "0.0")
                //{
                //    spanICTotalContract.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["ContractQty"].ToString()).ToString("N0") + " " + "pcs";
                //}


            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblContactNo = (Label)e.Row.FindControl("lblContactNo");
                Label lblLineitemNo = (Label)e.Row.FindControl("lblLineitemNo");


                Label lbltotalcutqty = (Label)e.Row.FindControl("lbltotalcutqty");


                if (lbltotalcutqty.Text != "" && lbltotalcutqty.Text != "0")
                {
                    lbltotalcutqty.Text = Convert.ToInt32(lbltotalcutqty.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lbltotalcutqty.Text = "";
                }

                //Label lblPrice = (Label)e.Row.FindControl("lblPrice");
                //HiddenField hdnCurrenyTag = (HiddenField)e.Row.FindControl("hdnCurrenyTag");

                //string StrTag = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType((Convert.ToInt32(hdnCurrenyTag.Value)));

                //if (lblPrice.Text != "" && lblPrice.Text != "0" && lblPrice.Text != "0.0")
                //{

                //    lblPrice.Text = StrTag + " " + Math.Round(Convert.ToDouble(lblPrice.Text), 2, MidpointRounding.AwayFromZero).ToString();
                //}
                //else
                //{
                //    lblPrice.Text = "";
                //}

                Label lbltotalcontractqty = (Label)e.Row.FindControl("lbltotalcontractqty");

                if (lbltotalcontractqty.Text != "" && lbltotalcontractqty.Text != "0" && lbltotalcontractqty.Text != "0.0")
                {
                    lbltotalcontractqty.Text = Convert.ToInt32(lbltotalcontractqty.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lbltotalcontractqty.Text = "";
                }


                Label lbltotalstich = (Label)e.Row.FindControl("lbltotalstich");

                if (lbltotalstich.Text != "" && lbltotalstich.Text != "0" && lbltotalstich.Text != "0.0")
                {
                    lbltotalstich.Text = Convert.ToInt32(lbltotalstich.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lbltotalstich.Text = "";
                }


                Label lblTotalFinishedQty = (Label)e.Row.FindControl("lblTotalFinishedQty");

                if (lblTotalFinishedQty.Text != "" && lblTotalFinishedQty.Text != "0" && lblTotalFinishedQty.Text != "0.0")
                {
                    lblTotalFinishedQty.Text = Convert.ToInt32(lblTotalFinishedQty.Text).ToString("N0") + " Pcs";
                }
                else
                {
                    lblTotalFinishedQty.Text = "";
                }






                //Label lblOrderValueValue = (Label)e.Row.FindControl("lblOrderValueValue");

                //if (lblOrderValueValue.Text != "" && lblOrderValueValue.Text != "0" && lblOrderValueValue.Text != "0.0")
                //{
                //    lblOrderValueValue.Text = "\u20B9 " + Math.Round((Convert.ToDouble(lblOrderValueValue.Text)), 2, MidpointRounding.AwayFromZero).ToString();


                //}
                //else
                //{
                //    lblOrderValueValue.Text = "";
                //}

                Label lblhoppmstatus = (Label)e.Row.FindControl("lblhoppmstatus");
                Label lblriskstatus = (Label)e.Row.FindControl("lblriskstatus");
                Label lblQainLine = (Label)e.Row.FindControl("lblQainLine");
                Label lblQaOnline = (Label)e.Row.FindControl("lblQaOnline");
                Label lblQaFinish = (Label)e.Row.FindControl("lblQaFinish");
                Label lbltopsent = (Label)e.Row.FindControl("lbltopsent");

                DataSet dsQaOending = new DataSet();
                DataTable dt_QaOendingHoppm = new DataTable();
                DataTable dt_QaOendingrisk = new DataTable();
                DataTable dt_QaOendingInceptionInline = new DataTable();
                DataTable dt_QaOendingOnline = new DataTable();
                DataTable dt_QaOendingFinish = new DataTable();
                DataTable dt_QaOendingtop = new DataTable();
                //---------------fault------------------//
                DataTable dtfaultinline = new DataTable();
                DataTable dtfaultinline_sum = new DataTable();

                DataTable dtfaultfinish = new DataTable();
                DataTable dtfaultfinish_sum = new DataTable();

                DataTable dtfaultOnline = new DataTable();
                DataTable dtfaultOnline_sum = new DataTable();

                DataTable dtfoterQaOending = new DataTable();
                HiddenField OrderDeatilID = (HiddenField)e.Row.FindControl("OrderDeatilID");
                if (OrderDeatilID != null && OrderDeatilID.Value != "")
                {
                    dsQaOending = objadmin.GetQaPedingDoneByDate(Convert.ToInt32(OrderDeatilID.Value), "");
                    dt_QaOendingHoppm = dsQaOending.Tables[0];
                    dt_QaOendingrisk = dsQaOending.Tables[1];
                    dt_QaOendingtop = dsQaOending.Tables[2];
                    dt_QaOendingInceptionInline = dsQaOending.Tables[3];
                    dt_QaOendingFinish = dsQaOending.Tables[4];
                    dt_QaOendingOnline = dsQaOending.Tables[5];

                    //if (dsQaOending.Tables.Count == 7 && dsQaOending.Tables.Count == 8)
                    //{
                    dtfaultinline = dsQaOending.Tables[6];
                    dtfaultinline_sum = dsQaOending.Tables[7];
                    // }
                    //if (dsQaOending.Tables.Count == 9 && dsQaOending.Tables.Count == 10)
                    //{
                    dtfaultfinish = dsQaOending.Tables[8];
                    dtfaultfinish_sum = dsQaOending.Tables[9];
                    // }
                    //if (dsQaOending.Tables.Count == 11 && dsQaOending.Tables.Count == 12)
                    //{
                    dtfaultOnline = dsQaOending.Tables[10];
                    dtfaultOnline_sum = dsQaOending.Tables[11];
                    // }

                    if (dt_QaOendingHoppm.Rows[0][0].ToString() != "")
                    {
                        lblhoppmstatus.Text = dt_QaOendingHoppm.Rows[0][0].ToString();
                    }
                    if (dt_QaOendingrisk.Rows[0][0].ToString() != "")
                    {
                        lblriskstatus.Text = dt_QaOendingrisk.Rows[0][0].ToString();

                    }
                    if (dt_QaOendingtop.Rows[0][0].ToString() != "")
                    {
                        lbltopsent.Text = dt_QaOendingtop.Rows[0][0].ToString();
                    }

                    if (dt_QaOendingInceptionInline.Rows[0][0].ToString() != "")
                    {
                        lblQainLine.Text = dt_QaOendingInceptionInline.Rows[0][0].ToString();
                    }
                    Repeater rptfualtldetails_inline = e.Row.FindControl("rptfualtldetails_inline") as Repeater;

                    //Label lblctsl = (Label)rptctsldetails.FindControl("lblctsl");
                    Label lblInspected_inline = (Label)e.Row.FindControl("lblInspected_inline");
                    Label lblqty_inline = (Label)e.Row.FindControl("lblqty_inline");

                    //HtmlTableRow tdrpss_inline = (HtmlTableRow)e.Row.FindControl("tdrp");
                    //HtmlTableRow tdrpss = (HtmlTableRow)e.Row.FindControl("tdrpss");
                    //HtmlTable tblinline = (HtmlTable)e.Row.FindControl("tblinline");

                    HtmlTableRow tblinline = (HtmlTableRow)e.Row.FindControl("tblinline");
                    //DataSet dsfualt = objadmin.GetQaPedingDoneByDate(Convert.ToInt32(OrderDeatilID.Value), "FAULT");

                    if (rptfualtldetails_inline != null)
                    {
                        if (dtfaultinline.Rows.Count > 0)
                        {
                            rptfualtldetails_inline.DataSource = dtfaultinline;
                            rptfualtldetails_inline.DataBind();
                        }
                        else
                        {
                            if (tblinline != null)
                            {
                                tblinline.Visible = false;
                            }

                        }

                        if (dtfaultinline_sum.Rows[0]["ActualSampleChecked"].ToString() == "0")
                        {
                            lblInspected_inline.Text = "";
                        }
                        else
                        {
                            lblInspected_inline.Text = dtfaultinline_sum.Rows[0]["ActualSampleChecked"].ToString();
                        }

                        if (dtfaultinline_sum.Rows[0]["OccurrenceSum"].ToString() == "0")
                        {
                            lblqty_inline.Text = "";
                        }
                        else
                        {
                            lblqty_inline.Text = dtfaultinline_sum.Rows[0]["OccurrenceSum"].ToString();
                        }

                    }

                    if (dt_QaOendingOnline.Rows[0][0].ToString() != "")
                    {
                        lblQaOnline.Text = dt_QaOendingOnline.Rows[0][0].ToString();
                    }

                    Repeater rptfualtldetails_Online = e.Row.FindControl("rptfualtldetails_Online") as Repeater;


                    Label lblInspected_Online = (Label)e.Row.FindControl("lblInspected_Online");
                    Label lblqty_Online = (Label)e.Row.FindControl("lblqty_Online");

                    //HtmlTableRow tdrpss_inline = (HtmlTableRow)e.Row.FindControl("tdrp");
                    //HtmlTableRow tdrpss = (HtmlTableRow)e.Row.FindControl("tdrpss");
                    //HtmlTable tblOnline = (HtmlTable)e.Row.FindControl("tblOnline");
                    //DataSet dsfualt = objadmin.GetQaPedingDoneByDate(Convert.ToInt32(OrderDeatilID.Value), "FAULT");

                    HtmlTableRow tblOnline = (HtmlTableRow)e.Row.FindControl("tblOnline");

                    if (rptfualtldetails_Online != null)
                    {
                        if (dtfaultOnline.Rows.Count > 0)
                        {
                            rptfualtldetails_Online.DataSource = dtfaultOnline;
                            rptfualtldetails_Online.DataBind();
                        }
                        else
                        {
                            if (tblOnline != null)
                            {
                                tblOnline.Visible = false;
                            }

                        }

                        if (dtfaultOnline_sum.Rows[0]["ActualSampleChecked"].ToString() == "0")
                        {
                            lblInspected_Online.Text = "";
                        }
                        else
                        {
                            lblInspected_Online.Text = dtfaultOnline_sum.Rows[0]["ActualSampleChecked"].ToString();
                        }

                        if (dtfaultOnline_sum.Rows[0]["OccurrenceSum"].ToString() == "0")
                        {
                            lblqty_Online.Text = "";
                        }
                        else
                        {
                            lblqty_Online.Text = dtfaultOnline_sum.Rows[0]["OccurrenceSum"].ToString();
                        }

                    }

                    if (dt_QaOendingFinish.Rows[0][0].ToString() != "")
                    {
                        lblQaFinish.Text = dt_QaOendingFinish.Rows[0][0].ToString();
                    }
                    Repeater rptfualtldetails_Finish = e.Row.FindControl("rptfualtldetails_Finish") as Repeater;

                    //Label lblctsl = (Label)rptctsldetails.FindControl("lblctsl");
                    Label lblInspected_Finish = (Label)e.Row.FindControl("lblInspected_Finish");
                    Label lblqty_finish = (Label)e.Row.FindControl("lblqty_finish");

                    //HtmlTableRow tdrpss_inline = (HtmlTableRow)e.Row.FindControl("tdrp");
                    //HtmlTableRow tdrpss = (HtmlTableRow)e.Row.FindControl("tdrpss");
                    // HtmlTable tblFinish_finish = (HtmlTable)e.Row.FindControl("tblFinish_finish");
                    //DataSet dsfualt = objadmin.GetQaPedingDoneByDate(Convert.ToInt32(OrderDeatilID.Value), "FAULT");
                    HtmlTableRow tblFinish_finish = (HtmlTableRow)e.Row.FindControl("tblFinish_finish");

                    if (rptfualtldetails_Finish != null)
                    {
                        if (dtfaultfinish.Rows.Count > 0)
                        {
                            rptfualtldetails_Finish.DataSource = dtfaultfinish;
                            rptfualtldetails_Finish.DataBind();
                        }
                        else
                        {
                            if (tblFinish_finish != null)
                            {
                                tblFinish_finish.Visible = false;
                            }

                        }

                        if (dtfaultfinish_sum.Rows[0]["ActualSampleChecked"].ToString() == "0")
                        {
                            lblInspected_Finish.Text = "";
                        }
                        else
                        {
                            lblInspected_Finish.Text = dtfaultfinish_sum.Rows[0]["ActualSampleChecked"].ToString();
                        }

                        if (dtfaultfinish_sum.Rows[0]["OccurrenceSum"].ToString() == "0")
                        {
                            lblqty_finish.Text = "";
                        }
                        else
                        {
                            lblqty_finish.Text = dtfaultfinish_sum.Rows[0]["OccurrenceSum"].ToString();
                        }

                    }


                    //===============================Fault================================//



                }
                //Repeater rptfualtldetails = e.Row.FindControl("rptfualtldetails") as Repeater;

                ////Label lblctsl = (Label)rptctsldetails.FindControl("lblctsl");
                //Label lblInspected = (Label)e.Row.FindControl("lblInspected");
                //Label lblqty = (Label)e.Row.FindControl("lblqty");

                //HtmlTableRow tdrp = (HtmlTableRow)e.Row.FindControl("tdrp");
                //HtmlTableRow tdrpss = (HtmlTableRow)e.Row.FindControl("tdrpss");
                ////HtmlTable tblFualt = (HtmlTable)e.Row.FindControl("tblFualt");
                //DataSet dsfualt = objadmin.GetQaPedingDoneByDate(Convert.ToInt32(OrderDeatilID.Value), "FAULT");
                //DataTable dtfualtName = dsfualt.Tables[0];
                //DataTable dtsumfault = dsfualt.Tables[1];
                //if (rptfualtldetails != null)
                //{
                //    if (dtfualtName.Rows.Count > 0)
                //    {
                //        rptfualtldetails.DataSource = dtfualtName;
                //        rptfualtldetails.DataBind();

                //        //lblctsl.Text = lblctsl.Text + "%";
                //    }
                //    else
                //    {
                //        tdrpss.Visible = false;
                //        tdrp.Visible = false;
                //    }

                //    if (dtsumfault.Rows[0]["ActualSampleChecked"].ToString() == "0")
                //    {
                //        lblInspected.Text = "";
                //    }
                //    else
                //    {
                //        lblInspected.Text = dtsumfault.Rows[0]["ActualSampleChecked"].ToString();
                //    }

                //    if (dtsumfault.Rows[0]["OccurrenceSum"].ToString() == "0")
                //    {
                //        lblqty.Text = "";
                //    }
                //    else
                //    {
                //        lblqty.Text = dtsumfault.Rows[0]["OccurrenceSum"].ToString();
                //    }

                //}

                if (lblhoppmstatus.Text != "")
                {

                    bool conts_done = lblhoppmstatus.Text.Contains("Done") || lblhoppmstatus.Text.Contains("done");
                    bool conts_pending = lblhoppmstatus.Text.Contains("Pending") || lblhoppmstatus.Text.Contains("pending");

                    int pos_done = lblhoppmstatus.Text.IndexOf("Done", StringComparison.CurrentCultureIgnoreCase);
                    int pos_pending = lblhoppmstatus.Text.IndexOf("Pending", StringComparison.CurrentCultureIgnoreCase);
                    if (conts_done)
                    {
                        if (pos_done > -1)
                        {
                            DoneCountHoppm += 1;

                        }

                    }



                }


                if (lblriskstatus.Text != "")
                {

                    bool conts_done = lblriskstatus.Text.Contains("Done") || lblriskstatus.Text.Contains("done");
                    bool conts_pending = lblriskstatus.Text.Contains("Pending") || lblriskstatus.Text.Contains("pending");

                    int pos_done = lblriskstatus.Text.IndexOf("Done", StringComparison.CurrentCultureIgnoreCase);
                    int pos_pending = lblriskstatus.Text.IndexOf("Pending", StringComparison.CurrentCultureIgnoreCase);
                    if (conts_done)
                    {
                        if (pos_done > -1)
                        {

                            DoneCountRisk += 1;
                        }

                    }


                }


                if (lblQainLine.Text != "")
                {

                    bool conts_done = lblQainLine.Text.Contains("Inline") || lblQainLine.Text.Contains("Inline");
                    bool conts_pending = lblQainLine.Text.Contains("due") || lblQainLine.Text.Contains("due");

                    int pos_done = lblQainLine.Text.IndexOf("Inline", StringComparison.CurrentCultureIgnoreCase);
                    int pos_pending = lblQainLine.Text.IndexOf("due", StringComparison.CurrentCultureIgnoreCase);
                    if (conts_done)
                    {
                        if (pos_done > -1)
                        {
                            DoneCountInline += 1;

                        }

                    }



                }

                if (lblQaOnline.Text != "")
                {

                    bool conts_done = lblQaOnline.Text.Contains("Online") || lblQaOnline.Text.Contains("Online");
                    bool conts_pending = lblQaOnline.Text.Contains("due") || lblQaOnline.Text.Contains("due");

                    int pos_done = lblQaOnline.Text.IndexOf("Online", StringComparison.CurrentCultureIgnoreCase);
                    int pos_pending = lblQaOnline.Text.IndexOf("due", StringComparison.CurrentCultureIgnoreCase);
                    if (conts_done)
                    {
                        if (pos_done > -1)
                        {
                            DoneCountOnline += 1;

                        }

                    }



                }


                if (lblQaFinish.Text != "")
                {

                    bool conts_done = lblQaFinish.Text.Contains("Final") || lblQaFinish.Text.Contains("Final");
                    bool conts_pending = lblQaFinish.Text.Contains("due") || lblQaFinish.Text.Contains("due");

                    int pos_done = lblQaFinish.Text.IndexOf("Final", StringComparison.CurrentCultureIgnoreCase);
                    int pos_pending = lblQaFinish.Text.IndexOf("due", StringComparison.CurrentCultureIgnoreCase);
                    if (conts_done)
                    {
                        if (pos_done > -1)
                        {
                            DoneCountFinal += 1;

                        }

                    }
                }
                if (lbltopsent.Text != "")
                {

                    // bool conts_done = lbltopsent.Text.Contains("Sent") || lbltopsent.Text.Contains("Reject");
                    bool conts_done = false;
                    bool conts_pending = lbltopsent.Text.Contains("Pending") || lbltopsent.Text.Contains("Pending");
                    if (lbltopsent.Text.Contains("Sent") || lbltopsent.Text.Contains("Reject") || lbltopsent.Text.Contains("Approved"))
                    {
                        conts_done = true;

                    }

                    //int pos_done = lbltopsent.Text.IndexOf("Done", StringComparison.CurrentCultureIgnoreCase);

                    //if()
                    //int pos_pending = lbltopsent.Text.IndexOf("Pending", StringComparison.CurrentCultureIgnoreCase);
                    if (conts_done)
                    {
                        //if (pos_done > -1)
                        //{
                        DoneCountTopSent += 1;

                        //  }

                    }
                }
                Label lblexfactdate = (Label)e.Row.FindControl("lblexfactdate");
                if (lblexfactdate.Text != "" && lblexfactdate != null)
                {
                    lblexfactdate.Text = Convert.ToDateTime(lblexfactdate.Text).ToString("dd MMM yy (ddd)");
                }
                //Label lblinlineinspectiondate_Name = (Label)e.Row.FindControl("lblinlineinspectiondate_Name");
                //Label lblMidinspectiondateand_Name = (Label)e.Row.FindControl("lblMidinspectiondateand_Name");
                //Label lblFinalinspectiondate_Name = (Label)e.Row.FindControl("lblFinalinspectiondate_Name");
                //Label lblFinalBIHinspectiondate_Name = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name");


                //Label lblhoppmstatus = (Label)e.Row.FindControl("lblhoppmstatus");
                //Label lblriskstatus = (Label)e.Row.FindControl("lblriskstatus");
                //Label lblInceptionInline = (Label)e.Row.FindControl("lblInceptionInline");
                //Label lblInceptionOnline = (Label)e.Row.FindControl("lblInceptionOnline");
                //Label lblFinish = (Label)e.Row.FindControl("lblFinish");
                //Label lbltop = (Label)e.Row.FindControl("lbltop");

                // HtmlGenericControl Spstatusrisk = (HtmlGenericControl)e.Row.FindControl("Spstatusrisk");
                Label Spstatusriskcount = (Label)e.Row.FindControl("Spstatusriskcount");

                //HtmlGenericControl Spstatushoppm = (HtmlGenericControl)e.Row.FindControl("Spstatushoppm");
                Label Spstatushoppmcount = (Label)e.Row.FindControl("Spstatushoppmcount");

                //HtmlGenericControl Spstatushoppmtop = (HtmlGenericControl)e.Row.FindControl("Spstatushoppmtop");
                Label Spstatushoppmtopcount = (Label)e.Row.FindControl("Spstatushoppmtopcount");


                // HtmlGenericControl Spstatushoppminline = (HtmlGenericControl)e.Row.FindControl("Spstatushoppminline");
                Label Spstatushoppminlinecount = (Label)e.Row.FindControl("Spstatushoppminlinecount");


                //HtmlGenericControl Spstatushoppmonline = (HtmlGenericControl)e.Row.FindControl("Spstatushoppmonline");
                Label SpstatushoppmonlineCount = (Label)e.Row.FindControl("SpstatushoppmonlineCount");

                // HtmlGenericControl Spstatushoppmfinal = (HtmlGenericControl)e.Row.FindControl("Spstatushoppmfinal");
                // Label Spstatushoppmfinalcount = (Label)e.Row.FindControl("Spstatushoppmfinalcount");




            }
        }

        protected void rptfualtldetails_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            RepeaterItem item = e.Item;
            if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
            {//GetFaultqtySum
                //Label lblctsl = (Label)item.FindControl("lblctsl");
                //Label lblctslqnty = (Label)item.FindControl("lblctslqnty");
                //Label lblvalue = (Label)item.FindControl("lblvalue");
                //lblvalue.Text = "\u20B9 " + lblvalue.Text + "K";
                //if (lblctsl.Text == "0" || lblctsl.Text == "0.0")
                //{
                //    lblctsl.Text = "";
                //}
                //else
                //{
                //    lblctsl.Text = lblctsl.Text + "%";
                //}
                //if (lblctslqnty.Text != "0" || lblctslqnty.Text != "0.0")
                //{

                //    GetFaultqtySum += Convert.ToInt32(lblctslqnty.Text);
                //}
                //if (lblvalue.Text != "0" || lblvalue.Text != "0.0")
                //{

                //    GetCtslVlaueSum += Convert.ToDouble(lblvalue.Text.Replace("K", "").Replace("\u20B9 ", ""));
                //}
                Label lblctsldetaild = (Label)item.FindControl("lblctsldetaild");
                Label lblctslqnty = (Label)item.FindControl("lblctslqnty");


            }
        }


        ////  code by Prabhaker//
        //protected void repeaterTopFaults(object sender, RepeaterItemEventArgs e)
        //{
        //    RepeaterItem item = e.Item;
        //    if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
        //    {
        //        repeaterTopFaultsOneMonthC47 = (Repeater)item.FindControl("repeaterTopFaultsOneMonthC47");
        //        repeaterTopFaultsOneMonthC47.DataSource = repeaterTopFaultsOneMonthC47;
        //        repeaterTopFaultsOneMonthC47.DataBind();

        //    }

        //}



        ////end-of prabhaker code  //

        //protected void grdtopFaultDetails46_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Label lblmonthlast = (Label)e.Row.FindControl("lblmonthlast");
        //        //-------------C47---------------------------------------------//


        //        HiddenField hdnduration = (HiddenField)e.Row.FindControl("hdnduration");
        //DataSet ds = new DataSet();
        //DataTable dt = new DataTable();
        //ds = objadmin.GetTopQaFualtReport(3, Convert.ToInt32(hdnduration.Value), "TOPFUALTS");
        //dt = ds.Tables[0];
        //if (dt.Rows.Count > 0)
        //{
        //    Repeater rptinceptionC47 = (Repeater)e.Row.FindControl("rptinceptionC47");
        //    rptinceptionC47.DataSource = dt;
        //    rptinceptionC47.DataBind();
        //}
        //ds = objadmin.GetTopQaFualtReport(3, Convert.ToInt32(hdnduration.Value), "TOPREASONCTSL");
        //dt = ds.Tables[0];
        //if (dt.Rows.Count > 0)
        //{
        //    Repeater rptCtslC47 = (Repeater)e.Row.FindControl("rptCtslC47");
        //    rptCtslC47.DataSource = dt;
        //    rptCtslC47.DataBind();
        //}

        //ds = objadmin.GetTopQaFualtReport(3, Convert.ToInt32(hdnduration.Value), "TOPREASONDHU");
        //dt = ds.Tables[0];
        //if (dt.Rows.Count > 0)
        //{
        //    Repeater rptdhuC47 = (Repeater)e.Row.FindControl("rptdhuC47");
        //    rptdhuC47.DataSource = dt;
        //    rptdhuC47.DataBind();
        //}
        //-------------C4546---------------------------------------------//



        //DataSet dsC4546 = new DataSet();
        //DataTable dtC4546 = new DataTable();
        //dsC4546 = objadmin.GetTopQaFualtReport(11, Convert.ToInt32(hdnduration.Value), "TOPFUALTS");
        //dtC4546 = dsC4546.Tables[0];
        //if (dtC4546.Rows.Count > 0)
        //{
        //    Repeater rptinceptionC45c46 = (Repeater)e.Row.FindControl("rptinceptionC45c46");
        //    rptinceptionC45c46.DataSource = dtC4546;
        //    rptinceptionC45c46.DataBind();
        //}
        //dsC4546 = objadmin.GetTopQaFualtReport(11, Convert.ToInt32(hdnduration.Value), "TOPREASONCTSL");
        //dtC4546 = dsC4546.Tables[0];
        //if (dtC4546.Rows.Count > 0)
        //{
        //    Repeater rptCtslC45c46 = (Repeater)e.Row.FindControl("rptCtslC45c46");
        //    rptCtslC45c46.DataSource = dtC4546;
        //    rptCtslC45c46.DataBind();
        //}

        //dsC4546 = objadmin.GetTopQaFualtReport(11, Convert.ToInt32(hdnduration.Value), "TOPREASONDHU");
        //dtC4546 = dsC4546.Tables[0];
        //if (dtC4546.Rows.Count > 0)
        //{
        //    Repeater rptdhuC45c46 = (Repeater)e.Row.FindControl("rptdhuC45c46");
        //    rptdhuC45c46.DataSource = dtC4546;
        //    rptdhuC45c46.DataBind();
        //}
        //-------------Bipl---------------------------------------------//

        //DataSet dsBipl = new DataSet();
        //DataTable dtBipl = new DataTable();
        //dsBipl = objadmin.GetTopQaFualtReport(0, Convert.ToInt32(hdnduration.Value), "TOPFUALTS");
        //dtBipl = dsBipl.Tables[0];
        //if (dtBipl.Rows.Count > 0)
        //{
        //    Repeater rptinceptionBipl = (Repeater)e.Row.FindControl("rptinceptionBipl");
        //    rptinceptionBipl.DataSource = dtBipl;
        //    rptinceptionBipl.DataBind();
        //}
        //dsBipl = objadmin.GetTopQaFualtReport(0, Convert.ToInt32(hdnduration.Value), "TOPREASONCTSL");
        //dtBipl = dsBipl.Tables[0];
        //if (dtBipl.Rows.Count > 0)
        //{
        //    Repeater rptCtslBipl = (Repeater)e.Row.FindControl("rptCtslBipl");
        //    rptCtslBipl.DataSource = dtBipl;
        //    rptCtslBipl.DataBind();
        //}

        //dsBipl = objadmin.GetTopQaFualtReport(0, Convert.ToInt32(hdnduration.Value), "TOPREASONDHU");
        //dtBipl = dsBipl.Tables[0];
        //if (dtBipl.Rows.Count > 0)
        //{
        //    Repeater rptdhuBipl = (Repeater)e.Row.FindControl("rptdhuBipl");
        //    rptdhuBipl.DataSource = dtBipl;
        //    rptdhuBipl.DataBind();
        //}
        //    }
        //}


        //protected void grdtopFaultDetailsbipl_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Label lblmonthlast = (Label)e.Row.FindControl("lblmonthlast");
        //        //-------------C47---------------------------------------------//


        //        HiddenField hdnduration = (HiddenField)e.Row.FindControl("hdnduration");
        //DataSet ds = new DataSet();
        //DataTable dt = new DataTable();
        //ds = objadmin.GetTopQaFualtReport(3, Convert.ToInt32(hdnduration.Value), "TOPFUALTS");
        //dt = ds.Tables[0];
        //if (dt.Rows.Count > 0)
        //{
        //    Repeater rptinceptionC47 = (Repeater)e.Row.FindControl("rptinceptionC47");
        //    rptinceptionC47.DataSource = dt;
        //    rptinceptionC47.DataBind();
        //}
        //ds = objadmin.GetTopQaFualtReport(3, Convert.ToInt32(hdnduration.Value), "TOPREASONCTSL");
        //dt = ds.Tables[0];
        //if (dt.Rows.Count > 0)
        //{
        //    Repeater rptCtslC47 = (Repeater)e.Row.FindControl("rptCtslC47");
        //    rptCtslC47.DataSource = dt;
        //    rptCtslC47.DataBind();
        //}

        //ds = objadmin.GetTopQaFualtReport(3, Convert.ToInt32(hdnduration.Value), "TOPREASONDHU");
        //dt = ds.Tables[0];
        //if (dt.Rows.Count > 0)
        //{
        //    Repeater rptdhuC47 = (Repeater)e.Row.FindControl("rptdhuC47");
        //    rptdhuC47.DataSource = dt;
        //    rptdhuC47.DataBind();
        //}
        //-------------C4546---------------------------------------------//



        //DataSet dsC4546 = new DataSet();
        //DataTable dtC4546 = new DataTable();
        //dsC4546 = objadmin.GetTopQaFualtReport(11, Convert.ToInt32(hdnduration.Value), "TOPFUALTS");
        //dtC4546 = dsC4546.Tables[0];
        //if (dtC4546.Rows.Count > 0)
        //{
        //    Repeater rptinceptionC45c46 = (Repeater)e.Row.FindControl("rptinceptionC45c46");
        //    rptinceptionC45c46.DataSource = dtC4546;
        //    rptinceptionC45c46.DataBind();
        //}
        //dsC4546 = objadmin.GetTopQaFualtReport(11, Convert.ToInt32(hdnduration.Value), "TOPREASONCTSL");
        //dtC4546 = dsC4546.Tables[0];
        //if (dtC4546.Rows.Count > 0)
        //{
        //    Repeater rptCtslC45c46 = (Repeater)e.Row.FindControl("rptCtslC45c46");
        //    rptCtslC45c46.DataSource = dtC4546;
        //    rptCtslC45c46.DataBind();
        //}

        //dsC4546 = objadmin.GetTopQaFualtReport(11, Convert.ToInt32(hdnduration.Value), "TOPREASONDHU");
        //dtC4546 = dsC4546.Tables[0];
        //if (dtC4546.Rows.Count > 0)
        //{
        //    Repeater rptdhuC45c46 = (Repeater)e.Row.FindControl("rptdhuC45c46");
        //    rptdhuC45c46.DataSource = dtC4546;
        //    rptdhuC45c46.DataBind();
        //}
        //-------------Bipl---------------------------------------------//

        //        DataSet dsBipl = new DataSet();
        //        DataTable dtBipl = new DataTable();
        //        dsBipl = objadmin.GetTopQaFualtReport(0, Convert.ToInt32(hdnduration.Value), "TOPFUALTS");
        //        dtBipl = dsBipl.Tables[0];
        //        if (dtBipl.Rows.Count > 0)
        //        {
        //            Repeater rptinceptionBipl = (Repeater)e.Row.FindControl("rptinceptionBipl");
        //            rptinceptionBipl.DataSource = dtBipl;
        //            rptinceptionBipl.DataBind();
        //        }
        //        dsBipl = objadmin.GetTopQaFualtReport(0, Convert.ToInt32(hdnduration.Value), "TOPREASONCTSL");
        //        dtBipl = dsBipl.Tables[0];
        //        if (dtBipl.Rows.Count > 0)
        //        {
        //            Repeater rptCtslBipl = (Repeater)e.Row.FindControl("rptCtslBipl");
        //            rptCtslBipl.DataSource = dtBipl;
        //            rptCtslBipl.DataBind();
        //        }

        //        dsBipl = objadmin.GetTopQaFualtReport(0, Convert.ToInt32(hdnduration.Value), "TOPREASONDHU");
        //        dtBipl = dsBipl.Tables[0];
        //        if (dtBipl.Rows.Count > 0)
        //        {
        //            Repeater rptdhuBipl = (Repeater)e.Row.FindControl("rptdhuBipl");
        //            rptdhuBipl.DataSource = dtBipl;
        //            rptdhuBipl.DataBind();
        //        }
        //    }
        //}

    }
}