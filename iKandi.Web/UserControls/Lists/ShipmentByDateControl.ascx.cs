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
using System.Text;
using System.Text.RegularExpressions;

using System.Net;


namespace iKandi.Web.UserControls.Lists
{

    public partial class ShipmentByDateControl : System.Web.UI.UserControl
    {
        AdminController objadmin = new AdminController();

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

        DataTable dtitemMonthC47_Total = new DataTable();
        DataTable dtitemMonthC4546_Total = new DataTable();
        DataTable dtitemMonthBipl_Total = new DataTable();
        DataTable dtitemMonthD169_Total = new DataTable();
        DataTable dtitemMonthC52_Total = new DataTable();


        public static int GetFaultqtySum = 0;
        public static double GetCtslVlaueSum = 0;

        public int DoneCountHoppm = 0;
        public int DoneCountRisk = 0;
        public int DoneCountTopSent = 0;
        public int DoneCountInline = 0;
        public int DoneCountOnline = 0;
        public int DoneCountFinal = 0;
        public decimal grandASOOrderQty = 0;
        public decimal grandASOOrderQtyAir = 0;
        public decimal grandERNOrderQty = 0;

        public decimal grandTotalOrderQty = 0;
        public decimal grandASOBiplTotal = 0;
        public decimal grandASOBiplTotalAir = 0;

        public decimal grandERNBiplTotal = 0;
        public decimal grandTOTALBiplTotal = 0;

        public decimal grandOtherOrderQty = 0;
        public decimal grandOtherOrderVal = 0;
        string EmailContent = string.Empty;
        string WriteFile, WriteFile_c45_46;


        DataTable dtWeekRangeFoter = new DataTable();
        DataSet dsupcoming = new DataSet();
        DataTable dtFabricWIP = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Rell_Outhouse.HRef = Application["Reallocation_Outhouse"].ToString();
            //Rell_Outhouse_Emb.HRef = Application["Reallocation_Outhouse_Emb"].ToString();

            // Code Appended on 26 jul 2021 as per live after ravikumar left
            if (Application["Reallocation_Outhouse"] != null)
            {
                Rell_Outhouse.HRef = Application["Reallocation_Outhouse"].ToString();
            }
            if (Application["Reallocation_Outhouse_Emb"] != null)
            {
                Rell_Outhouse_Emb.HRef = Application["Reallocation_Outhouse_Emb"].ToString();
            }
            // End of Code Appended on 26 jul 2021 as per live after ravikumar left

            //////  Add By Prabhaker 16-Apr-18
            //randorNewsLetterC47Html();
            //Production_Plan_Details_C47.HRef = WriteFile;


            //randorNewsLetterC45_46Html();
            //Production_Plan_Details_C45_46.HRef = WriteFile_c45_46;
            //Application["NewsLetterC45_46"] = WriteFile_c45_46;

            lbldate.Text = DateTime.Now.ToString("dd MMM yy (ddd)");
            lbldates.Text = DateTime.Now.ToString("dd-MMM");
            spanlastMonthName.InnerText = DateTime.Now.AddMonths(-1).ToString("MMMM");
            Bindgrd();
            GetFaultqtySum = 0;
            GetCtslVlaueSum = 0;
            BottomDataBind();
            BindStylecode();
            string BIPLMonthlyPenalty_File = "BIPLMonthlyPenalty.png";
            string BIPLMonthlyPenalty_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", BIPLMonthlyPenalty_File);
            BIPLMonthlyPenalty.Src = BIPLMonthlyPenalty_Path;
            //add code by bhrat on 31-Oct-19
            string BIPLMonthlyFinishedQty_File = "BIPLMonthlyFinishedQty.png";
            string BIPLMonthlyFinishedQty_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", BIPLMonthlyFinishedQty_File);
            BIPLMonthlyFinishedQty.Src = BIPLMonthlyFinishedQty_Path;

            string BIPLMonthlyShipQty_File = "BIPLMonthlyShipQty.png";
            string BIPLMonthlyShipQty_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", BIPLMonthlyShipQty_File);
            BIPLMonthlyShipQty.Src = BIPLMonthlyShipQty_Path;

            string BIPLMonthlyStitchQty_File = "BIPLMonthlyStitchQty.png";
            string BIPLMonthlyStitchQty_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", BIPLMonthlyStitchQty_File);
            BIPLMonthlyStitchQty.Src = BIPLMonthlyStitchQty_Path;

            string BIPLMonthlyCutQty_File = "BIPLMonthlyCutQty.png";
            string BIPLMonthlyCutQty_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", BIPLMonthlyCutQty_File);
            BIPLMonthlyCutQty.Src = BIPLMonthlyCutQty_Path;

            string BIPLMonthlyCTSL_File = "BIPLMonthlyCTSL.png";
            string BIPLMonthlyCTSL_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", BIPLMonthlyCTSL_File);
            BIPLMonthlyCTSL.Src = BIPLMonthlyCTSL_Path;

            string BIPLMonthlyStitchingValue_File = "BIPLMonthlyStitchingValue.png";
            string BIPLMonthlyStitchingValue_Path = System.IO.Path.Combine("http://192.168.0.4:81/pic/", BIPLMonthlyStitchingValue_File);
            BIPLMonthlyStitchingValue.Src = BIPLMonthlyStitchingValue_Path;
            //end
        }

        //Add By Prabhaker 16-Apr-18
        public void randorNewsLetterC47Html()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;

            // Give your ASP.NET Page address
            quest = WebRequest.Create("http://192.168.0.4/NewsLetterC47.aspx");
            // quest = WebRequest.Create("http://localhost:3220/NewsLetterC47.aspx");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();



            string Reallocation_ReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");

            Reallocation_ReportHtml = "NewsLetterC47_" + Day + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/NewsLetter/" + Reallocation_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            //WriteFile = Server.MapPath("~/Uploads/Fits/" + HourlyReportHtml);
            WriteFile = "http://boutique.in/uploads/NewsLetter/" + Reallocation_ReportHtml;
            //WriteFile = "http://localhost:3220/uploads/NewsLetter/" + Reallocation_ReportHtml;
            // Response.WriteFile();   
        }


        public void randorNewsLetterC45_46Html()
        {
            WebRequest quest;
            WebResponse ponse;
            StreamReader reader;
            StreamWriter writer;
            string strHTML;

            // Give your ASP.NET Page address
            quest = WebRequest.Create("http://192.168.0.4/NewsLetterC45_46.aspx");
            //quest = WebRequest.Create("http://localhost:3220/NewsLetterC45_46.aspx");
            quest.Timeout = Convert.ToInt32(99999999);
            ponse = quest.GetResponse();
            reader = new StreamReader(ponse.GetResponseStream());

            strHTML = reader.ReadToEnd();



            string Reallocation_ReportHtml = "";
            DateTime now = DateTime.Now;
            string Day = now.ToString("dd");
            string Month = now.ToString("MMM");

            Reallocation_ReportHtml = "NewsLetterC45_46_" + Day + Month + ".html";
            writer = File.CreateText(Server.MapPath("~/Uploads/NewsLetter/" + Reallocation_ReportHtml));
            writer.WriteLine(strHTML);
            writer.Close();
            //WriteFile = Server.MapPath("~/Uploads/Fits/" + HourlyReportHtml);http://localhost:3220/
            WriteFile_c45_46 = "http://boutique.in/uploads/NewsLetter/" + Reallocation_ReportHtml;

            //  WriteFile_c45_46 = "http://localhost:3220/uploads/NewsLetter/" + Reallocation_ReportHtml;
            // Response.WriteFile();   
        }
        //End Of Code
        public void Bindgrd()
        {

            ds = objadmin.GetShipmetReport("DAILYSHIPMENT");
            dtitem = ds.Tables[0];
            dtitemfoter = ds.Tables[1];
            grdshipmentBydate.DataSource = dtitem;
            grdshipmentBydate.DataBind();

            //second grid for icbipl

            //ds_ic = objadmin.GetShipmetReport("ICREPORT");
            //dtitem_ic = ds_ic.Tables[0];
            //dtitem_ic_foter = ds_ic.Tables[1];
            //grdShipmentICbipl.DataSource = dtitem_ic;
            //grdShipmentICbipl.DataBind();

            //DataSet dspnd = objadmin.GetShipmetReportPnd("SHIPMENTPLANING", 0, "");
            //DataTable dtpndShipment = dspnd.Tables[1];
            //if (dtpndShipment.Rows.Count > 0)
            //{
            //  grdshipmentdue.DataSource = dtpndShipment;
            //  grdshipmentdue.DataBind();
            //}



            dsupcoming = objadmin.GetShipmetReportUpcming();
            DataTable dtupcoming = dsupcoming.Tables[0];

            DataSet dsPenaltyReports = objadmin.GetShipmentPenaltyReports();
            DataTable dtPenaltyReports = dsPenaltyReports.Tables[0];

            DataTable dtshipValueTotal = dsupcoming.Tables[1];
            dtFabricWIP = dsupcoming.Tables[2];
            ViewState["VS_dtshipValueTotal"] = dtshipValueTotal;
            if (dtupcoming.Rows.Count > 0)
            {
                grandTotalOrderQty = 0;
                grandASOBiplTotal = 0;
                grandASOBiplTotalAir = 0;
                grandERNBiplTotal = 0;
                grandTOTALBiplTotal = 0;

                grdupcmoming.DataSource = dtupcoming;
                grdupcmoming.DataBind();
            }
            //---------------------------------------Penalty reports---------------------------
            if (dtPenaltyReports.Rows.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("<table class='ShipmentPen' style='width:500px;'>");
                sb.Append("<tr>");
                sb.Append("<th colspan='5'>Penalty Reports</th>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<th>Time Range</th>");
                sb.Append("<th>ERN</th>");
                sb.Append("<th>ASOS</th>");
                sb.Append("<th>Others</th>");
                sb.Append("<th>BIPL</th>");
                sb.Append("</tr>");

                sb.Append("<tr>");
                sb.Append("<td>1 Month</td>");
                string ern=dtPenaltyReports.Rows[0]["ERN"].ToString();
                string ernp="";
                if (ern !="0")
                {
                    ernp = "<span>&#8377;</span> " + dtPenaltyReports.Rows[0]["ERN"].ToString() + " Lk";
                }
                else {
                    ernp = "";
                }
                sb.Append("<td class='txtcenter'>" + ernp + "</td>");
                string Asos = dtPenaltyReports.Rows[0]["ASOS"].ToString();
                string AsosP = "";
                if (Asos != "0")
                {
                    AsosP = "<span>&#8377;</span> " + dtPenaltyReports.Rows[0]["ASOS"].ToString() + " Lk";
                }
                else {
                    AsosP = "";
                }
                sb.Append("<td class='txtcenter'>" + AsosP + "</td>");

                string Other =  dtPenaltyReports.Rows[0]["Others"].ToString();
                string otherL = "";
                if (Other != "")
                {
                 
                     otherL ="<span>&#8377;</span> " + dtPenaltyReports.Rows[0]["Others"].ToString() + " Lk";
                }
                else { otherL = ""; }
                sb.Append("<td class='txtcenter'>" + otherL + "</td>");

                string Bipl = dtPenaltyReports.Rows[0]["BIPL"].ToString();
                string BiplP = "";
                if (Bipl != "0")
                {
                    BiplP = "<span>&#8377;</span> " + dtPenaltyReports.Rows[0]["BIPL"].ToString() + " Lk ";
                }
                else {
                    BiplP = "";
                }
                sb.Append("<td class='txtcenter'>" + BiplP + "</td>");
                sb.Append("</tr>");

                sb.Append("<tr>");
                sb.Append("<td>3 Month</td>");
                string ern_3mo = dtPenaltyReports.Rows[1]["ERN"].ToString();
                string ern_3mon = "";
                if (ern_3mo != "0")
                {
                    ern_3mon = "<span>&#8377;</span> " + dtPenaltyReports.Rows[1]["ERN"].ToString() + " Lk ";
                }
                else {
                    ern_3mon = "";
                }
                sb.Append("<td class='txtcenter'>" + ern_3mon + "</td>");
                string Asos_3mom=dtPenaltyReports.Rows[1]["ASOS"].ToString();
                string Asos_3month="";
                if (Asos_3mom != "0")
                {
                    Asos_3month = "<span>&#8377;</span> " + dtPenaltyReports.Rows[1]["ASOS"].ToString() + " Lk ";
                }  
                else {
                    Asos_3month = "";
                }
                sb.Append("<td class='txtcenter'>" + Asos_3month + "</td>");

                string Other_3mom = dtPenaltyReports.Rows[1]["Others"].ToString();
                string Other_3month = "";
                if (Other_3mom != "0")
                {
                    Other_3month = "<span>&#8377;</span> " + dtPenaltyReports.Rows[1]["Others"].ToString() + " Lk ";
                }
                else
                {
                    Other_3month = "";
                }

                sb.Append("<td class='txtcenter'> " + Other_3month + "</td>");

                string Bipl_3mom = dtPenaltyReports.Rows[1]["BIPL"].ToString();
                string Bipl_3month = "";
                if (Bipl_3mom != "0")
                {
                    Bipl_3month = "<span>&#8377;</span> " + dtPenaltyReports.Rows[1]["BIPL"].ToString() + " Lk ";
                }
                else
                {
                    Bipl_3month = "";
                }
                sb.Append("<td class='txtcenter'>" + Bipl_3month + "</td>");
                sb.Append("</tr>");
                sb.Append("<tr>");

                sb.Append("<td>Current Financial Year</td>");

                string ern_Current = dtPenaltyReports.Rows[2]["ERN"].ToString();
                string ern_CurrentYe = "";
                if (ern_Current != "0")
                {
                    ern_CurrentYe = "<span>&#8377;</span> " + dtPenaltyReports.Rows[2]["ERN"].ToString() + " Lk ";
                }
                else
                {
                    ern_CurrentYe = "";
                }
                sb.Append("<td class='txtcenter'>" + ern_CurrentYe + "</td>");
                string Asos_Current = dtPenaltyReports.Rows[2]["ASOS"].ToString();
                string Asos_CurrentYe = "";
                if (Asos_Current != "0")
                {
                    Asos_CurrentYe = "<span>&#8377;</span> " + dtPenaltyReports.Rows[2]["ASOS"].ToString() + " Lk ";
                }
                else
                {
                    Asos_CurrentYe = "";
                }
                sb.Append("<td class='txtcenter'>" + Asos_CurrentYe + "</td>");

                string Other_Current = dtPenaltyReports.Rows[2]["Others"].ToString();
                string Other_CurrentYe = "";
                if (Other_Current != "0")
                {
                    Other_CurrentYe = "<span>&#8377;</span> " + dtPenaltyReports.Rows[2]["Others"].ToString() + " Lk ";
                }
                else
                {
                    Other_CurrentYe = "";
                }

                sb.Append("<td class='txtcenter'> " + Other_CurrentYe + "</td>");

                string Bipl_Current = dtPenaltyReports.Rows[2]["BIPL"].ToString();
                string Bipl_CurrentYe = "";
                if (Bipl_Current != "0")
                {
                    Bipl_Current = "<span>&#8377;</span> " + dtPenaltyReports.Rows[2]["BIPL"].ToString() + " Lk ";
                }
                else
                {
                    Bipl_CurrentYe = "";
                }
                sb.Append("<td class='txtcenter'>" + Bipl_CurrentYe + "</td>");

                //sb.Append("<td class='txtcenter'>&#8377; " + dtPenaltyReports.Rows[2]["ERN"].ToString() + " Lk </td>");
                //sb.Append("<td class='txtcenter'>&#8377; " + dtPenaltyReports.Rows[2]["ASOS"].ToString() + " Lk </td>");
                //sb.Append("<td class='txtcenter'>&#8377; " + dtPenaltyReports.Rows[2]["Others"].ToString() + " Lk </td>");
                //sb.Append("<td class='txtcenter'>&#8377; " + dtPenaltyReports.Rows[2]["BIPL"].ToString() + " Lk </td>");
                sb.Append("</tr>");
                sb.Append("</table>");

                frmQShipmentPenaltyReport.InnerHtml = Convert.ToString(sb);
            }
            //-----------------------------Fabric WIP----------------------------------
            if (dtFabricWIP.Rows.Count > 0)
            {

                StringBuilder sb = new StringBuilder();
                sb.Append("<table cellspacing='0' cellpadding='0' class='ShipmentPen' border='1' style='width:500px'>");
                sb.Append("<tr>");
                sb.Append("<th colspan='9'>WIP Details</th>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<th colspan='2'>Fabric Issued WIP</th>");
                sb.Append("<th colspan='2'>Cut WIP</th>");
                sb.Append("<th colspan='2'>Stitch WIP</th>");
                sb.Append("<th colspan='2'>Pack WIP</th>");
                sb.Append("<th rowspan='2'>Total Value</th>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<th style'width:80px'>Value</th>");
                sb.Append("<th style'width:80px'>Qty (Mtr)</th>");
                sb.Append("<th style'width:80px'>Value</th>");
                sb.Append("<th style'width:80px'>Qty</th>");
                sb.Append("<th style'width:80px'>Value</th>");
                sb.Append("<th style'width:80px'>Qty</th>");
                sb.Append("<th style'width:80px'>Value</th>");
                sb.Append("<th style'width:80px'>Qty</th>");
                sb.Append("</tr>");
                sb.Append("<tr>");
                sb.Append("<td><span class='green'>&#8377;" + dtFabricWIP.Rows[0]["FWIPCost"].ToString() + "</span></td>");
                sb.Append("<td>" + dtFabricWIP.Rows[0]["FWIPValue"].ToString() + "</td>");
                sb.Append("<td><span class='green'>&#8377;" + dtFabricWIP.Rows[0]["CutWIPCost"].ToString() + "</span></td>");
                sb.Append("<td>" + dtFabricWIP.Rows[0]["CutWIPPcs"].ToString() + "</td>");
                sb.Append("<td><span class='green'>&#8377;" + dtFabricWIP.Rows[0]["StitchWIPCost"].ToString() + "</span></td>");
                sb.Append("<td>" + dtFabricWIP.Rows[0]["StitchWIPPcs"].ToString() + "</td>");
                sb.Append("<td><span class='green'>&#8377;" + dtFabricWIP.Rows[0]["PackWIPCost"].ToString() + "</span></td>");
                sb.Append("<td>" + dtFabricWIP.Rows[0]["PackWIPPcs"].ToString() + "</td>");
                sb.Append("<td><span class='green'>&#8377;" + dtFabricWIP.Rows[0]["TotalCost"].ToString() + "</span></td>");
                sb.Append("</tr>");
                sb.Append("</table>");
                Fabric_WIP.InnerHtml = sb.ToString();
            }
            //--------------------------End-------------------------------------------

            //DataSet dsOuthouseSummary = new DataSet();
            //dsOuthouseSummary = objadmin.GetOuthouseSummary();
            //DataTable dtOutHouseReport = dsOuthouseSummary.Tables[0];
            //if (dtOutHouseReport.Rows.Count > 0)
            //{
            //  grdOuthouseSummary.DataSource = dtOutHouseReport;
            //  grdOuthouseSummary.DataBind();
            //}
            //third grid for shipment pending

            /*ds_p = objadmin.GetShipmetReport("SHIPMENTPLANING");

            dtitem_pending = ds_p.Tables[0];
            dtitem_ic_foterpening = ds_p.Tables[1];
            grdpendingshipment.DataSource = dtitem_pending;
            grdpendingshipment.DataBind();*/


            //fourth grid for shipment pending

            ds_cumlative = objadmin.GetShipmetReport("SHIPMENTREPORTCUMLATIV");
            dt_cumlaive = ds_cumlative.Tables[0];
            //  gridshipemtNew.DataSource = dt_cumlaive;
            //   gridshipemtNew.DataBind();
            //// getShipmentReportCummlative();

            DataSet ds_hoppm = new DataSet();
            DataTable dtitem_hoppm = new DataTable();
            DataTable dtfoter_hoppm = new DataTable();
            //5th grid hoppm-------------//

            ds_hoppm = objadmin.GetShipmetReport("HOPPM");
            dtitem_hoppm = ds_hoppm.Tables[0];
            dtfoter_hoppm = ds_hoppm.Tables[1];


            //-------------sum count-------------------//

            //------------Get_StyleCount_Break_Down_In_ShipmentReport-----//
            DataSet Ds_StyleCount_ShipmentReport = new DataSet();
            DataTable dt_StyleCount_ShipmentReport = new DataTable();
            Ds_StyleCount_ShipmentReport = objadmin.GetShipmetReport("Get_StyleCount_Break_Down_In_ShipmentReport");
            dt_StyleCount_ShipmentReport = Ds_StyleCount_ShipmentReport.Tables[0];
            //grdgetstyleCountBreakDownInShipment.DataSource = dt_StyleCount_ShipmentReport;
            //grdgetstyleCountBreakDownInShipment.DataBind();
            //-----------End Of Get_StyleCount_Break_Down_In_ShipmentReport----//
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

            //grdhoppminspection.DataSource = dtitem_hoppm;
            //grdhoppminspection.DataBind();

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



            //grdqadone.DataSource = dtitem_qapending;
            //grdqadone.DataBind();



            //bind foter here---------------------------------------------------------//


            //if (dtitemfoter.Rows[0]["totalcutQty"].ToString() != "" && dtitemfoter.Rows[0]["totalcutQty"].ToString() != "0")
            //{
            //    sptotcalcut.InnerText = Convert.ToInt32(dtitemfoter.Rows[0]["totalcutQty"].ToString()).ToString("N0") + " " + "pcs";
            //}

            //if (dtitemfoter.Rows[0]["totalstichQty"].ToString() != "" && dtitemfoter.Rows[0]["totalstichQty"].ToString() != "0")
            //{
            //    spTotalStitch.InnerText = Convert.ToInt32(dtitemfoter.Rows[0]["totalstichQty"].ToString()).ToString("N0") + " " + "pcs";
            //}


            //if (dtitemfoter.Rows[0]["totalshippedqty"].ToString() != "" && dtitemfoter.Rows[0]["totalshippedqty"].ToString() != "0")
            //{
            //    spTotalShippedQty.InnerText = Convert.ToInt32(dtitemfoter.Rows[0]["totalshippedqty"].ToString()).ToString("N0") + " " + "pcs";
            //}

            //if (dtitemfoter.Rows[0]["totalCtsl"].ToString() != "" && dtitemfoter.Rows[0]["totalCtsl"].ToString() != "0")
            //{
            //    CTSL.InnerText = dtitemfoter.Rows[0]["totalCtsl"].ToString()+"%";
            //}

            //if (dtitemfoter.Rows[0]["ShippedValueFoter"].ToString() != "" && dtitemfoter.Rows[0]["ShippedValueFoter"].ToString() != "0")
            //{
            //    spShippedValue.InnerText = "\u20B9 " + dtitemfoter.Rows[0]["ShippedValueFoter"].ToString() + "cr";
            //}

            //if (dtitemfoter.Rows[0]["totalCIFAirFoter"].ToString() != "" && dtitemfoter.Rows[0]["totalCIFAirFoter"].ToString() != "0")
            //{
            //    spCIF.InnerText = "\u20B9 " + Convert.ToInt32(dtitemfoter.Rows[0]["totalCIFAirFoter"].ToString()).ToString("N0");
            //}

            //if (dtitemfoter.Rows[0]["Totoal_InspectionFailandTransport"].ToString() != "" && dtitemfoter.Rows[0]["Totoal_InspectionFailandTransport"].ToString() != "0")
            //{
            //    spInspection.InnerText = "\u20B9 " + dtitemfoter.Rows[0]["Totoal_InspectionFailandTransport"].ToString();
            //}
            ////if (dtitemfoter.Rows[0]["TotalPenalty"].ToString() != "" && dtitemfoter.Rows[0]["TotalPenalty"].ToString() != "0")
            ////{
            ////    spPenalty.InnerText = "\u20B9 " + dtitemfoter.Rows[0]["TotalPenalty"].ToString()+"Lac";
            ////}

            //if (dtitemfoter.Rows[0]["totalPelantyAge"].ToString() != "" && dtitemfoter.Rows[0]["totalPelantyAge"].ToString() != "0")
            //{
            //    spPenalty.InnerText = "\u20B9 " + dtitemfoter.Rows[0]["totalPelantyAge"].ToString() + "%";
            //}
            //if (dtitemfoter.Rows[0]["TotalPenalty"].ToString() != "" && dtitemfoter.Rows[0]["TotalPenalty"].ToString() != "0")
            //{
            //    spTotalPenalty.InnerText = "\u20B9 " + dtitemfoter.Rows[0]["TotalPenalty"].ToString() + "Lac";
            //}


            ////second grid foter total===============================================================================================//

            //if (dtitem_ic_foter.Rows[0]["totalcutQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["totalcutQty"].ToString() != "0")
            //{
            //    spanICTotalCut.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["totalcutQty"].ToString()).ToString("N0") + " " + "pcs";
            //}

            //if (dtitem_ic_foter.Rows[0]["totalstichQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["totalstichQty"].ToString() != "0")
            //{
            //    spanICstichTotal.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["totalstichQty"].ToString()).ToString("N0") + " " + "pcs";
            //}


            //if (dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString() != "0")
            //{
            //    spanicfinsidhtotal.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString()).ToString("N0") + " " + "pcs";
            //}



            //if (dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "" && dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "0")
            //{
            //    spOrderValueIctotal.InnerText = "\u20B9 " + dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() + "cr";
            //}


            ////thrid grid foter total===============================================================================================//

            //if (dtitem_ic_foterpening.Rows[0]["totalcutQty"].ToString() != "" && dtitem_ic_foterpening.Rows[0]["totalcutQty"].ToString() != "0")
            //{
            //    spanICTotalCut_p.InnerText = Convert.ToInt32(dtitem_ic_foterpening.Rows[0]["totalcutQty"].ToString()).ToString("N0") + " " + "pcs";
            //}

            //if (dtitem_ic_foterpening.Rows[0]["totalstichQty"].ToString() != "" && dtitem_ic_foterpening.Rows[0]["totalstichQty"].ToString() != "0")
            //{
            //    panICstichTotal_p.InnerText = Convert.ToInt32(dtitem_ic_foterpening.Rows[0]["totalstichQty"].ToString()).ToString("N0") + " " + "pcs";
            //}


            //if (dtitem_ic_foterpening.Rows[0]["TotalFoterFinsishedQty"].ToString() != "" && dtitem_ic_foterpening.Rows[0]["TotalFoterFinsishedQty"].ToString() != "0")
            //{
            //    spanicfinsidhtotal_p.InnerText = Convert.ToInt32(dtitem_ic_foterpening.Rows[0]["TotalFoterFinsishedQty"].ToString()).ToString("N0") + " " + "pcs";
            //}



            //if (dtitem_ic_foterpening.Rows[0]["fotertotalOrderValue"].ToString() != "" && dtitem_ic_foterpening.Rows[0]["fotertotalOrderValue"].ToString() != "0")
            //{
            //    spOrderValueIctotal_p.InnerText = "\u20B9 " + dtitem_ic_foterpening.Rows[0]["fotertotalOrderValue"].ToString() + "cr";
            //}

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
                    spvalue.InnerHtml = "<span style='color:green;'> " + " \u20B9 " + GetCtslVlaueSum.ToString() + " k" + "</span>";



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
                    spShippedValue.InnerHtml = "<span style='color:green;'> " + " \u20B9 " + dtitemfoter.Rows[0]["ShippedValueFoter"].ToString() + " Cr" + "</span>";
                }

                ////if (dtitemfoter.Rows[0]["totalCIFAirFoter"].ToString() != "" && dtitemfoter.Rows[0]["totalCIFAirFoter"].ToString() != "0" && dtitemfoter.Rows[0]["totalCIFAirFoter"].ToString() != "0.0")
                ////{
                ////    spCIF.InnerHtml = "<span style='color:green;'> " + " \u20B9 " + Convert.ToInt32(dtitemfoter.Rows[0]["totalCIFAirFoter"].ToString()).ToString("N0") + "</span>";
                ////}

                ////if (dtitemfoter.Rows[0]["Totoal_InspectionFailandTransport"].ToString() != "" && dtitemfoter.Rows[0]["Totoal_InspectionFailandTransport"].ToString() != "0" && dtitemfoter.Rows[0]["Totoal_InspectionFailandTransport"].ToString() != "0.0")
                ////{
                ////    spInspection.InnerHtml = "<span style='color:green;'> " + " \u20B9 " + dtitemfoter.Rows[0]["Totoal_InspectionFailandTransport"].ToString() + "</span>";


                ////}

                ////if (dtitemfoter.Rows[0]["totalExpressAirline"].ToString() != "" && dtitemfoter.Rows[0]["totalExpressAirline"].ToString() != "0" && dtitemfoter.Rows[0]["totalExpressAirline"].ToString() != "0.0")
                ////{
                ////    spExpressAirline.InnerHtml = "<span style='color:green;'> " + " \u20B9 " + dtitemfoter.Rows[0]["totalExpressAirline"].ToString() + "</span>";

                ////}



                ////if (dtitemfoter.Rows[0]["totalAirToMumbai"].ToString() != "" && dtitemfoter.Rows[0]["totalAirToMumbai"].ToString() != "0" && dtitemfoter.Rows[0]["totalAirToMumbai"].ToString() != "0.0")
                ////{
                ////    //sptotalAirToMumbai.InnerText = dtitemfoter.Rows[0]["totalAirToMumbai"].ToString();
                ////    sptotalAirToMumbai.InnerHtml = "<span style='color:green;'> " + " \u20B9 " + Math.Round(Convert.ToDouble(dtitemfoter.Rows[0]["totalAirToMumbai"].ToString()), 3, MidpointRounding.AwayFromZero).ToString("N0") + "</span>";

                ////}


                ////if (dtitemfoter.Rows[0]["TotalFiftyPercentCIFAir"].ToString() != "" && dtitemfoter.Rows[0]["TotalFiftyPercentCIFAir"].ToString() != "0" && dtitemfoter.Rows[0]["TotalFiftyPercentCIFAir"].ToString() != "0.0")
                ////{
                ////    //sp50CIF.InnerText = "\u20B9 " + dtitemfoter.Rows[0]["TotalFiftyPercentCIFAir"].ToString();
                ////    sp50CIF.InnerHtml = "<span style='color:green;'> " + " \u20B9 " + Math.Round(Convert.ToDouble(dtitemfoter.Rows[0]["TotalFiftyPercentCIFAir"].ToString()), 3, MidpointRounding.AwayFromZero).ToString("N0") + "</span>";


                ////}
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
                    spTotalPenalty.InnerHtml = "<span style='color:green;'> " + " \u20B9 " + "<span style='color:green;'>" + dtitemfoter.Rows[0]["TotalPenalty"].ToString() + "</span>" + "" + " Lacs";


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
                        lblvaluetotal.Text = "<span style='color:green;'> " + " \u20B9 " + dtfoterfualt.Rows[0]["Ctslweektotal"].ToString() + "</span>" + " k";
                        lblvaluetotal.ForeColor = Color.Green;
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
                    //lblPrice.Text = StrTag + " " + Math.Round(Convert.ToDouble(lblPrice.Text), 2, MidpointRounding.AwayFromZero).ToString();
                    lblPrice.Text = StrTag + " " + lblPrice.Text;
                    //lblPrice.Text = StrTag+" "+ lblPrice.Text.ToString();
                }
                else
                {
                    lblPrice.Text = "";
                }


                Label lblShippedValue = (Label)e.Row.FindControl("lblShippedValue");

                if (lblShippedValue.Text != "" && lblShippedValue.Text != "0" && lblShippedValue.Text != "0.0" && lblShippedValue.Text != "0.00")
                {
                    //lblShippedValue.Text = "\u20B9 " + lblShippedValue.Text.ToString();
                    //lblShippedValue.Text = "\u20B9 " + "<span style='color:green;'>" + Math.Round(Convert.ToDouble(lblShippedValue.Text), 2, MidpointRounding.AwayFromZero) + "</span>";
                    lblShippedValue.Text = "<span style='color:green;'>" + "\u20B9 " + lblShippedValue.Text + "</span>";

                }
                else
                {
                    lblShippedValue.Text = "";
                }


                //Label lblExpressAirline = (Label)e.Row.FindControl("lblExpressAirline");

                //if (lblExpressAirline.Text != "" && lblExpressAirline.Text != "0" && lblExpressAirline.Text != "0.0")
                //{
                //    lblExpressAirline.Text = "<span style='color:green;'> " + " \u20B9 " + lblExpressAirline.Text.ToString() + "</span>";

                //}
                //else
                //{
                //    lblExpressAirline.Text = "";
                //}


                //Label lblCIFAir = (Label)e.Row.FindControl("lblCIFAir");
                //if (lblCIFAir.Text != "" && lblCIFAir.Text != "0" && lblCIFAir.Text != "0.0")
                //{

                //    lblCIFAir.Text = "<span style='color:green;'> " + " \u20B9 " + Math.Round(Convert.ToDouble(lblCIFAir.Text), 3, MidpointRounding.AwayFromZero).ToString("N0") + "</span>";



                //    //Math.Round((lblCIFAir.Text), 2, MidpointRounding.AwayFromZero).ToString("N0")
                //}
                //else
                //{
                //    lblCIFAir.Text = "";
                //}


                //Label lbl50CIF = (Label)e.Row.FindControl("lbl50CIF");

                //if (lbl50CIF.Text != "" && lbl50CIF.Text != "0" && lbl50CIF.Text != "0.0")
                //{
                //    lbl50CIF.Text = "<span style='color:green;'> " + " \u20B9 " + Math.Round(Convert.ToDouble(lbl50CIF.Text), 3, MidpointRounding.AwayFromZero).ToString("N0") + "</span>";




                //}
                //else
                //{
                //    lbl50CIF.Text = "";
                //}


                //Label lblAirToMumbai = (Label)e.Row.FindControl("lblAirToMumbai");

                //if (lblAirToMumbai.Text != "" && lblAirToMumbai.Text != "0" && lblAirToMumbai.Text != "0.0")
                //{
                //    lblAirToMumbai.Text = "<span style='color:green;'> " + " \u20B9 " + Math.Round(Convert.ToDouble(lblAirToMumbai.Text), 3, MidpointRounding.AwayFromZero).ToString("N0") + "</span>";


                //}
                //else
                //{
                //    lblAirToMumbai.Text = "";
                //}



                //Label lblInspectionFailandTransport = (Label)e.Row.FindControl("lblInspectionFailandTransport");

                //if (lblInspectionFailandTransport.Text != "" && lblInspectionFailandTransport.Text != "0" && lblInspectionFailandTransport.Text != "0.0")
                //{
                //    lblInspectionFailandTransport.Text = "<span style='color:green;'> " + " \u20B9 " + Math.Round(Convert.ToDouble(lblInspectionFailandTransport.Text), 3, MidpointRounding.AwayFromZero).ToString("N0") + "</span>";

                //}
                //else
                //{
                //    lblInspectionFailandTransport.Text = "";
                //}


                Label lblTotalPenalty = (Label)e.Row.FindControl("lblTotalPenalty");

                if (lblTotalPenalty.Text != "" && lblTotalPenalty.Text != "0" && lblTotalPenalty.Text != "0.0")
                {
                    lblTotalPenalty.Text = "<span style='color:green;'> " + " \u20B9 " + Math.Round(Convert.ToDouble(lblTotalPenalty.Text), 3, MidpointRounding.AwayFromZero).ToString("N0") + "</span>";

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
                //Label lblMidinspectiondateand_Name_username = (Label)e.Row.FindControl("lblMidinspectiondateand_Name_username");
                Label lblFinalinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalinspectiondate_Name_username");
                Label lblFinalBIHinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name_username");

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
                Label lbldcdate = (Label)e.Row.FindControl("lbldcdate");
                if (lbldcdate.Text != "" && lbldcdate != null)
                {
                    lbldcdate.Text = Convert.ToDateTime(lbldcdate.Text).ToString("dd MMM yy (ddd)");
                }
                DataSet dss = new DataSet();
                DataTable dts = new DataTable();
                if (OrderDeatilID != null && OrderDeatilID.Value != "")
                {
                    dss = objadmin.GetInceptionDetailsSorting(Convert.ToInt32(OrderDeatilID.Value));
                    dts = dss.Tables[0];

                    //if (dts.Rows.Count == 1)
                    //{
                    //    lblinlineinspectiondate_Name_username.Text = dts.Rows[0]["InceptionDetails"].ToString();
                    //}
                    //if (dts.Rows.Count == 2)
                    //{
                    //    lblinlineinspectiondate_Name_username.Text = dts.Rows[0]["InceptionDetails"].ToString();
                    //    lblFinalinspectiondate_Name_username.Text = dts.Rows[1]["InceptionDetails"].ToString();
                    //}
                    //if (dts.Rows.Count == 3)
                    //{
                    //    lblinlineinspectiondate_Name_username.Text = dts.Rows[0]["InceptionDetails"].ToString();
                    //    lblFinalinspectiondate_Name_username.Text = dts.Rows[1]["InceptionDetails"].ToString();
                    //    lblFinalBIHinspectiondate_Name_username.Text = dts.Rows[2]["InceptionDetails"].ToString();
                    //}
                    //if (dt.Rows.Count == 4)
                    //{
                    //    lblinlineinspectiondate_Name_username.Text = dt.Rows[0]["StatusName"].ToString();
                    //    lblFinalinspectiondate_Name_username.Text = dt.Rows[1]["StatusName"].ToString();
                    //    lblMidinspectiondateand_Name_username.Text = dt.Rows[2]["StatusName"].ToString();
                    //    lblFinalBIHinspectiondate_Name_username.Text = dt.Rows[3]["StatusName"].ToString();
                    //}
                    if (dts.Rows.Count > 0)
                    {
                        //lblinlineinspectiondate_Name_username.Text = dts.Rows[0]["Pass"].ToString();
                        //StringBuilder builder = new StringBuilder();
                        //for (int i = 0; i < dts.Columns.Count; i++)
                        //{
                        //  builder.Append("<DIV>").Append(dts.Rows[0][i].ToString()).Append(" ").Append("</DIV>");
                        //}
                        //lblinlineinspectiondate_Name_username.Text = builder.ToString();

                        Label lblpass = (Label)e.Row.FindControl("lblpass");
                        Label lblfail = (Label)e.Row.FindControl("lblfail");
                        Label lblactualeiff = (Label)e.Row.FindControl("lblactualeiff");
                        Label lbltargeteffi = (Label)e.Row.FindControl("lbltargeteffi");
                        Label lblach = (Label)e.Row.FindControl("lblach");
                        if (dts.Rows[0]["Pass"].ToString() != "0")
                        {
                            lblpass.Text = dts.Rows[0]["Pass"].ToString();
                        }
                        else
                        {
                            lblpass.Text = "";
                        }
                        if (dts.Rows[0]["Fail"].ToString() != "0")
                        {
                            lblfail.Text = dts.Rows[0]["Fail"].ToString();
                        }
                        else
                        {
                            lblfail.Text = "";
                        }
                        if (dts.Rows[0]["ActualEff"].ToString() != "0")
                        {
                            lblactualeiff.Text = dts.Rows[0]["ActualEff"].ToString() + "%";
                        }
                        else
                        {
                            lblactualeiff.Text = "";
                        }
                        if (dts.Rows[0]["TargetDayEff"].ToString() != "0")
                        {
                            lbltargeteffi.Text = dts.Rows[0]["TargetDayEff"].ToString() + "%";
                        }
                        else
                        {
                            lbltargeteffi.Text = "";
                        }
                        HtmlTableCell tdach = (HtmlTableCell)e.Row.FindControl("tdach");
                        if (dts.Rows[0]["achivement"].ToString() != "0")
                        {
                            lblach.Text = dts.Rows[0]["achivement"].ToString() + "%";
                            if (Convert.ToDecimal(dts.Rows[0]["achivement"].ToString()) < 80)
                            {
                                tdach.BgColor = "Red";
                                lblach.ForeColor = Color.Yellow;
                            }
                            else
                            {
                                // lblach.BackColor = Color.Green;
                                tdach.BgColor = "Green";
                                lblach.ForeColor = Color.Yellow;
                            }

                        }
                        else
                        {
                            lblach.Text = "";
                        }

                    }

                }

                /*if (lblinlineinspectiondate_Name_username.Text.IndexOf("pass") > 0 || lblinlineinspectiondate_Name_username.Text.IndexOf("Pass") > 0)
                    lblinlineinspectiondate_Name_username.ForeColor = Color.Green;
                else if (lblinlineinspectiondate_Name_username.Text.IndexOf("fail") > 0 || lblinlineinspectiondate_Name_username.Text.IndexOf("Fail") > 0)
                    lblinlineinspectiondate_Name_username.ForeColor = Color.Red;

                if (lblFinalinspectiondate_Name_username.Text.IndexOf("pass") > 0 || lblFinalinspectiondate_Name_username.Text.IndexOf("Pass") > 0)
                    lblFinalinspectiondate_Name_username.ForeColor = Color.Green;
                else if (lblFinalinspectiondate_Name_username.Text.IndexOf("fail") > 0 || lblFinalinspectiondate_Name_username.Text.IndexOf("Fail") > 0)
                    lblFinalinspectiondate_Name_username.ForeColor = Color.Red;

                //if (lblMidinspectiondateand_Name_username.Text.IndexOf("pass") > 0 || lblMidinspectiondateand_Name_username.Text.IndexOf("Pass") > 0)
                //    lblMidinspectiondateand_Name_username.ForeColor = Color.Green;
                //else if (lblMidinspectiondateand_Name_username.Text.IndexOf("fail") > 0 || lblMidinspectiondateand_Name_username.Text.IndexOf("Fail") > 0)
                //    lblMidinspectiondateand_Name_username.ForeColor = Color.Red;

                if (lblFinalBIHinspectiondate_Name_username.Text.IndexOf("pass") > 0 || lblFinalBIHinspectiondate_Name_username.Text.IndexOf("Pass") > 0)
                    lblFinalBIHinspectiondate_Name_username.ForeColor = Color.Green;
                else if (lblFinalBIHinspectiondate_Name_username.Text.IndexOf("fail") > 0 || lblFinalBIHinspectiondate_Name_username.Text.IndexOf("Fail") > 0)

                    lblFinalBIHinspectiondate_Name_username.ForeColor = Color.Red;*/




            }
        }
        //protected void grdShipmentICbipl_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        HtmlGenericControl spanICTotalCut = (HtmlGenericControl)e.Row.FindControl("spanICTotalCut");
        //        HtmlGenericControl spanICstichTotal = (HtmlGenericControl)e.Row.FindControl("spanICstichTotal");
        //        HtmlGenericControl spanicfinsidhtotal = (HtmlGenericControl)e.Row.FindControl("spanicfinsidhtotal");
        //        HtmlGenericControl spOrderValueIctotal = (HtmlGenericControl)e.Row.FindControl("spOrderValueIctotal");

        //        HtmlGenericControl Strong8 = (HtmlGenericControl)e.Row.FindControl("spOrderValueIctotal");
        //        HtmlGenericControl spanICTotalContract = (HtmlGenericControl)e.Row.FindControl("spanICTotalContract");

        //        e.Row.Cells[1].Visible = false;
        //        e.Row.Cells[0].Attributes.Add("colspan", "2");

        //        if (dtitem_ic_foter.Rows[0]["totalcutQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["totalcutQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["totalcutQty"].ToString() != "0.0")
        //        {
        //            spanICTotalCut.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["totalcutQty"].ToString()).ToString("N0") + " " + "Pcs";
        //        }

        //        if (dtitem_ic_foter.Rows[0]["totalstichQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["totalstichQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["totalstichQty"].ToString() != "0.0")
        //        {
        //            spanICstichTotal.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["totalstichQty"].ToString()).ToString("N0") + " " + "Pcs";
        //        }


        //        if (dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString() != "0.0")
        //        {
        //            spanicfinsidhtotal.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["TotalFoterFinsishedQty"].ToString()).ToString("N0") + " " + "Pcs";
        //        }



        //        if (dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "" && dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "0" && dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "0.0" && dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() != "0.00")
        //        {
        //            spOrderValueIctotal.InnerHtml = "<span style='color:green;'> " + " \u20B9 " + dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() + " Cr" + "</span>";
        //        }
        //        if (dtitem_ic_foter.Rows[0]["ContractQty"].ToString() != "" && dtitem_ic_foter.Rows[0]["ContractQty"].ToString() != "0" && dtitem_ic_foter.Rows[0]["ContractQty"].ToString() != "0.0")
        //        {
        //            spanICTotalContract.InnerText = Convert.ToInt32(dtitem_ic_foter.Rows[0]["ContractQty"].ToString()).ToString("N0") + " " + "Pcs";
        //        }


        //    }

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Label lblContactNo = (Label)e.Row.FindControl("lblContactNo");
        //        Label lblLineitemNo = (Label)e.Row.FindControl("lblLineitemNo");


        //        Label lbltotalcutqty = (Label)e.Row.FindControl("lbltotalcutqty");


        //        if (lbltotalcutqty.Text != "" && lbltotalcutqty.Text != "0")
        //        {
        //            lbltotalcutqty.Text = Convert.ToInt32(lbltotalcutqty.Text).ToString("N0") + " Pcs";
        //        }
        //        else
        //        {
        //            lbltotalcutqty.Text = "";
        //        }

        //        Label lblPrice = (Label)e.Row.FindControl("lblPrice");
        //        HiddenField hdnCurrenyTag = (HiddenField)e.Row.FindControl("hdnCurrenyTag");

        //        string StrTag = iKandi.Common.Constants.GetCurrencySymbalByCurrencyType((Convert.ToInt32(hdnCurrenyTag.Value)));

        //        if (lblPrice.Text != "" && lblPrice.Text != "0" && lblPrice.Text != "0.0")
        //        {

        //            //lblPrice.Text = StrTag + " " + Math.Round(Convert.ToDouble(lblPrice.Text), 2, MidpointRounding.AwayFromZero).ToString();
        //            lblPrice.Text = StrTag + " " + lblPrice.Text;
        //        }
        //        else
        //        {
        //            lblPrice.Text = "";
        //        }

        //        Label lbltotalcontractqty = (Label)e.Row.FindControl("lbltotalcontractqty");

        //        if (lbltotalcontractqty.Text != "" && lbltotalcontractqty.Text != "0" && lbltotalcontractqty.Text != "0.0")
        //        {
        //            lbltotalcontractqty.Text = Convert.ToInt32(lbltotalcontractqty.Text).ToString("N0") + " Pcs";
        //        }
        //        else
        //        {
        //            lbltotalcontractqty.Text = "";
        //        }


        //        Label lbltotalstich = (Label)e.Row.FindControl("lbltotalstich");

        //        if (lbltotalstich.Text != "" && lbltotalstich.Text != "0" && lbltotalstich.Text != "0.0")
        //        {
        //            lbltotalstich.Text = Convert.ToInt32(lbltotalstich.Text).ToString("N0") + " Pcs";
        //        }
        //        else
        //        {
        //            lbltotalstich.Text = "";
        //        }


        //        Label lblTotalFinishedQty = (Label)e.Row.FindControl("lblTotalFinishedQty");

        //        if (lblTotalFinishedQty.Text != "" && lblTotalFinishedQty.Text != "0" && lblTotalFinishedQty.Text != "0.0")
        //        {
        //            lblTotalFinishedQty.Text = Convert.ToInt32(lblTotalFinishedQty.Text).ToString("N0") + " Pcs";
        //        }
        //        else
        //        {
        //            lblTotalFinishedQty.Text = "";
        //        }

        //        Label lblOrderValueValue = (Label)e.Row.FindControl("lblOrderValueValue");

        //        if (lblOrderValueValue.Text != "" && lblOrderValueValue.Text != "0" && lblOrderValueValue.Text != "0.0")
        //        {
        //            lblOrderValueValue.Text = "<span style='color:green;'>" + "\u20B9 " + lblOrderValueValue.Text + "</span>";


        //        }
        //        else
        //        {
        //            lblOrderValueValue.Text = "";
        //        }
        //        HiddenField hdnOrderDetailsID = (HiddenField)e.Row.FindControl("hdnOrderDetailsID");
        //        Label lblinlineinspectiondate_Name = (Label)e.Row.FindControl("lblinlineinspectiondate_Name");
        //        Label lblMidinspectiondateand_Name = (Label)e.Row.FindControl("lblMidinspectiondateand_Name");
        //        Label lblFinalinspectiondate_Name = (Label)e.Row.FindControl("lblFinalinspectiondate_Name");
        //        Label lblFinalBIHinspectiondate_Name = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name");


        //        //lblinlineinspectiondate_Name.Text = lblinlineinspectiondate_Name.Text != "" ? Convert.ToDateTime(lblinlineinspectiondate_Name.Text).ToString("dd MMM yy (ddd)") : "";
        //        //lblMidinspectiondateand_Name.Text = lblMidinspectiondateand_Name.Text != "" ? Convert.ToDateTime(lblMidinspectiondateand_Name.Text).ToString("dd MMM yy (ddd)") : "";
        //        //lblFinalinspectiondate_Name.Text = lblFinalinspectiondate_Name.Text != "" ? Convert.ToDateTime(lblFinalinspectiondate_Name.Text).ToString("dd MMM yy (ddd)") : "";
        //        //lblFinalBIHinspectiondate_Name.Text = lblFinalBIHinspectiondate_Name.Text != "" ? Convert.ToDateTime(lblFinalBIHinspectiondate_Name.Text).ToString("dd MMM yy (ddd)") : "";







        //        //Label lblinlineinspectiondate_Name_username = (Label)e.Row.FindControl("lblinlineinspectiondate_Name_username");


        //        //if (lblinlineinspectiondate_Name_username.Text != "")
        //        //{

        //        //    string[] str = lblinlineinspectiondate_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
        //        //    if (str.Length == 1)
        //        //    {
        //        //        if (str[0].ToString() != "")
        //        //        {
        //        //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
        //        //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
        //        //            if (dt != DateTime.MinValue)
        //        //                lblinlineinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");
        //        //            else
        //        //                lblinlineinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");


        //        //        }
        //        //    }
        //        //    if (str.Length == 2)
        //        //    {
        //        //        if (str[1].ToString() != "")
        //        //        {
        //        //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
        //        //            lblinlineinspectiondate_Name_username.Text = str[0].ToString();
        //        //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
        //        //            if (dt != DateTime.MinValue)
        //        //                lblinlineinspectiondate_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
        //        //            else
        //        //                lblinlineinspectiondate_Name.Text = "";


        //        //        }
        //        //    }


        //        //}

        //        //Label lblMidinspectiondateand_Name_username = (Label)e.Row.FindControl("lblMidinspectiondateand_Name_username");


        //        //if (lblMidinspectiondateand_Name_username.Text != "")
        //        //{

        //        //    string[] str = lblMidinspectiondateand_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
        //        //    if (str.Length == 1)
        //        //    {
        //        //        if (str[0].ToString() != "")
        //        //        {
        //        //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
        //        //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
        //        //            if (dt != DateTime.MinValue)
        //        //                lblMidinspectiondateand_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");
        //        //            else
        //        //                lblMidinspectiondateand_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");


        //        //        }
        //        //    }
        //        //    if (str.Length == 2)
        //        //    {
        //        //        if (str[1].ToString() != "")
        //        //        {
        //        //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
        //        //            lblMidinspectiondateand_Name_username.Text = str[0].ToString();
        //        //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
        //        //            if (dt != DateTime.MinValue)
        //        //                lblMidinspectiondateand_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
        //        //            else
        //        //                lblMidinspectiondateand_Name.Text = "";


        //        //        }
        //        //    }


        //        //}


        //        //Label lblFinalinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalinspectiondate_Name_username");

        //        //if (lblFinalinspectiondate_Name_username.Text != "")
        //        //{

        //        //    string[] str = lblFinalinspectiondate_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
        //        //    if (str.Length == 1)
        //        //    {
        //        //        if (str[0].ToString() != "")
        //        //        {
        //        //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
        //        //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
        //        //            if (dt != DateTime.MinValue)
        //        //                lblFinalinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");
        //        //            else
        //        //                lblFinalinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");


        //        //        }
        //        //    }
        //        //    if (str.Length == 2)
        //        //    {
        //        //        if (str[1].ToString() != "")
        //        //        {
        //        //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
        //        //            lblFinalinspectiondate_Name_username.Text = str[0].ToString();
        //        //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
        //        //            if (dt != DateTime.MinValue)
        //        //                lblFinalinspectiondate_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
        //        //            else
        //        //                lblFinalinspectiondate_Name.Text = "";


        //        //        }
        //        //    }


        //        //}

        //        //Label lblFinalBIHinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name_username");


        //        //if (lblFinalBIHinspectiondate_Name_username.Text != "")
        //        //{

        //        //    string[] str = lblFinalBIHinspectiondate_Name_username.Text.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
        //        //    if (str.Length == 1)
        //        //    {
        //        //        if (str[0].ToString() != "")
        //        //        {
        //        //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
        //        //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
        //        //            if (dt != DateTime.MinValue)
        //        //                lblFinalBIHinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");
        //        //            else
        //        //                lblFinalBIHinspectiondate_Name_username.Text = Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)");


        //        //        }
        //        //    }
        //        //    if (str.Length == 2)
        //        //    {
        //        //        if (str[1].ToString() != "")
        //        //        {
        //        //            DateTime dt = DateHelper.ParseDate(Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)")).Value; ;
        //        //            lblFinalBIHinspectiondate_Name_username.Text = str[0].ToString();
        //        //            //bool result = IsValidDateTime(Convert.ToDateTime(str[0].ToString()).ToString("dd MMM yy (ddd)"));
        //        //            if (dt != DateTime.MinValue)
        //        //                lblFinalBIHinspectiondate_Name.Text = Convert.ToDateTime(str[1].ToString()).ToString("dd MMM yy (ddd)");
        //        //            else
        //        //                lblFinalBIHinspectiondate_Name.Text = "";


        //        //        }
        //        //    }


        //        //}
        //        Label lblinlineinspectiondate_Name_username = (Label)e.Row.FindControl("lblinlineinspectiondate_Name_username");
        //        //Label lblMidinspectiondateand_Name_username = (Label)e.Row.FindControl("lblMidinspectiondateand_Name_username");
        //        Label lblFinalinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalinspectiondate_Name_username");
        //        Label lblFinalBIHinspectiondate_Name_username = (Label)e.Row.FindControl("lblFinalBIHinspectiondate_Name_username");


        //        Label lblexfactdate = (Label)e.Row.FindControl("lblexfactdate");
        //        if (lblexfactdate.Text != "" && lblexfactdate != null)
        //        {
        //            lblexfactdate.Text = Convert.ToDateTime(lblexfactdate.Text).ToString("dd MMM yy (ddd)");
        //            DateTime d = DateTime.ParseExact(lblexfactdate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);

        //            if (d < DateTime.Now.Date)
        //                lblexfactdate.ForeColor = Color.Red;
        //            else
        //                lblexfactdate.ForeColor = Color.Green;
        //        }
        //        Label lblDcDate = (Label)e.Row.FindControl("lblDcDate");
        //        if (lblDcDate.Text != "" && lblDcDate != null)
        //        {
        //            lblDcDate.Text = Convert.ToDateTime(lblDcDate.Text).ToString("dd MMM yy (ddd)");
        //            //DateTime d = DateTime.ParseExact(lblDcDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);

        //            //if (d>DateTime.Now.Date)
        //            //    lblDcDate.ForeColor = Color.Red;
        //            //else
        //            //    lblDcDate.ForeColor = Color.Green;
        //        }
        //        DataSet ds = new DataSet();
        //        DataTable dt = new DataTable();
        //        if (hdnOrderDetailsID != null && hdnOrderDetailsID.Value != "")
        //        {
        //            ds = objadmin.GetShipmentReportByICBIPL_ordring(Convert.ToInt32(hdnOrderDetailsID.Value), "ICBIPL");
        //            dt = ds.Tables[0];
        //            if (dt.Rows.Count == 1)
        //            {
        //                lblinlineinspectiondate_Name_username.Text = dt.Rows[0]["StatusName"].ToString();
        //            }
        //            if (dt.Rows.Count == 2)
        //            {
        //                lblinlineinspectiondate_Name_username.Text = dt.Rows[0]["StatusName"].ToString();
        //                lblFinalinspectiondate_Name_username.Text = dt.Rows[1]["StatusName"].ToString();
        //            }
        //            if (dt.Rows.Count == 3)
        //            {
        //                lblinlineinspectiondate_Name_username.Text = dt.Rows[0]["StatusName"].ToString();
        //                lblFinalinspectiondate_Name_username.Text = dt.Rows[1]["StatusName"].ToString();
        //                lblFinalBIHinspectiondate_Name_username.Text = dt.Rows[2]["StatusName"].ToString();
        //            }
        //            //if (dt.Rows.Count == 4)
        //            //{
        //            //    lblinlineinspectiondate_Name_username.Text = dt.Rows[0]["StatusName"].ToString();
        //            //    lblFinalinspectiondate_Name_username.Text = dt.Rows[1]["StatusName"].ToString();
        //            //    lblMidinspectiondateand_Name_username.Text = dt.Rows[2]["StatusName"].ToString();

        //            //}

        //        }
        //        if (lblinlineinspectiondate_Name_username.Text.IndexOf("pass") > 0 || lblinlineinspectiondate_Name_username.Text.IndexOf("Pass") > 0)
        //            lblinlineinspectiondate_Name_username.ForeColor = Color.Green;
        //        else if (lblinlineinspectiondate_Name_username.Text.IndexOf("fail") > 0 || lblinlineinspectiondate_Name_username.Text.IndexOf("Fail") > 0)
        //            lblinlineinspectiondate_Name_username.ForeColor = Color.Red;

        //        if (lblFinalinspectiondate_Name_username.Text.IndexOf("pass") > 0 || lblFinalinspectiondate_Name_username.Text.IndexOf("Pass") > 0)
        //            lblFinalinspectiondate_Name_username.ForeColor = Color.Green;
        //        else if (lblFinalinspectiondate_Name_username.Text.IndexOf("fail") > 0 || lblFinalinspectiondate_Name_username.Text.IndexOf("Fail") > 0)
        //            lblFinalinspectiondate_Name_username.ForeColor = Color.Red;

        //        //if (lblMidinspectiondateand_Name_username.Text.IndexOf("pass") > 0 || lblMidinspectiondateand_Name_username.Text.IndexOf("Pass") > 0)
        //        //    lblMidinspectiondateand_Name_username.ForeColor = Color.Green;
        //        //else if (lblMidinspectiondateand_Name_username.Text.IndexOf("fail") > 0 || lblMidinspectiondateand_Name_username.Text.IndexOf("Fail") > 0)
        //        //    lblMidinspectiondateand_Name_username.ForeColor = Color.Red;

        //        if (lblFinalBIHinspectiondate_Name_username.Text.IndexOf("pass") > 0 || lblFinalBIHinspectiondate_Name_username.Text.IndexOf("Pass") > 0)
        //            lblFinalBIHinspectiondate_Name_username.ForeColor = Color.Green;
        //        else if (lblFinalBIHinspectiondate_Name_username.Text.IndexOf("fail") > 0 || lblFinalBIHinspectiondate_Name_username.Text.IndexOf("Fail") > 0)
        //            lblFinalBIHinspectiondate_Name_username.ForeColor = Color.Red;


        //        Label lbltopsentstatus = (Label)e.Row.FindControl("lbltopsentstatus");
        //        if (lbltopsentstatus.Text.IndexOf("Approved") > 0 || lbltopsentstatus.Text.IndexOf("approved ") > 0)
        //            lbltopsentstatus.ForeColor = Color.Green;
        //        else
        //            lbltopsentstatus.ForeColor = Color.Red;

        //    }
        //}
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
                    spOrderValueIctotal_p.InnerHtml = "<span style='color:green;'> " + " \u20B9 " + dtitem_ic_foterpening.Rows[0]["fotertotalOrderValue"].ToString() + " Cr" + "</span>";

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
                    //lblPrice.Text = StrTag + " " + Math.Round(Convert.ToDouble(lblPrice.Text), 2, MidpointRounding.AwayFromZero).ToString();
                    lblPrice.Text = StrTag + " " + lblPrice.Text;
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
                    lblOrderValueValue.Text = "<span style='color:green;'> " + " \u20B9 " + lblOrderValueValue.Text + "</span>";



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
                //Label lblMidinspectiondateand_Name_username = (Label)e.Row.FindControl("lblMidinspectiondateand_Name_username");
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
                        lblFinalBIHinspectiondate_Name_username.Text = dt.Rows[2]["StatusName"].ToString();
                    }
                    //if (dt.Rows.Count == 4)
                    //{
                    //    lblinlineinspectiondate_Name_username.Text = dt.Rows[0]["StatusName"].ToString();
                    //    lblFinalinspectiondate_Name_username.Text = dt.Rows[1]["StatusName"].ToString();
                    //    lblMidinspectiondateand_Name_username.Text = dt.Rows[2]["StatusName"].ToString();

                    //}

                }
                if (lblinlineinspectiondate_Name_username.Text.IndexOf("pass") > 0 || lblinlineinspectiondate_Name_username.Text.IndexOf("Pass") > 0)
                    lblinlineinspectiondate_Name_username.ForeColor = Color.Green;
                else if (lblinlineinspectiondate_Name_username.Text.IndexOf("fail") > 0 || lblinlineinspectiondate_Name_username.Text.IndexOf("Fail") > 0)
                    lblinlineinspectiondate_Name_username.ForeColor = Color.Red;

                if (lblFinalinspectiondate_Name_username.Text.IndexOf("pass") > 0 || lblFinalinspectiondate_Name_username.Text.IndexOf("Pass") > 0)
                    lblFinalinspectiondate_Name_username.ForeColor = Color.Green;
                else if (lblFinalinspectiondate_Name_username.Text.IndexOf("fail") > 0 || lblFinalinspectiondate_Name_username.Text.IndexOf("Fail") > 0)
                    lblFinalinspectiondate_Name_username.ForeColor = Color.Red;

                //if (lblMidinspectiondateand_Name_username.Text.IndexOf("pass") > 0 || lblMidinspectiondateand_Name_username.Text.IndexOf("Pass") > 0)
                //    lblMidinspectiondateand_Name_username.ForeColor = Color.Green;
                //else if (lblMidinspectiondateand_Name_username.Text.IndexOf("fail") > 0 || lblMidinspectiondateand_Name_username.Text.IndexOf("Fail") > 0)
                //    lblMidinspectiondateand_Name_username.ForeColor = Color.Red;

                if (lblFinalBIHinspectiondate_Name_username.Text.IndexOf("pass") > 0 || lblFinalBIHinspectiondate_Name_username.Text.IndexOf("Pass") > 0)
                    lblFinalBIHinspectiondate_Name_username.ForeColor = Color.Green;
                else if (lblFinalBIHinspectiondate_Name_username.Text.IndexOf("fail") > 0 || lblFinalBIHinspectiondate_Name_username.Text.IndexOf("Fail") > 0)
                    lblFinalBIHinspectiondate_Name_username.ForeColor = Color.Red;



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
                Label lbldcdate = (Label)e.Row.FindControl("lbldcdate");
                if (lbldcdate.Text != "" && lbldcdate != null)
                {
                    lbldcdate.Text = Convert.ToDateTime(lbldcdate.Text).ToString("dd MMM yy (ddd)");
                }

                Label lbltopsentstatus = (Label)e.Row.FindControl("lbltopsentstatus");
                if (lbltopsentstatus.Text.IndexOf("Approved") > 0 || lbltopsentstatus.Text.IndexOf("approved ") > 0)
                    lbltopsentstatus.ForeColor = Color.Green;
                else
                    lbltopsentstatus.ForeColor = Color.Red;
            }
        }

        //---------------------------------c47---------------------------------------//
        //double CutQty47 = 0;
        //double StitchQty47 = 0;
        //double FinishQty47 = 0;
        //double ShipeQty47 = 0;
        //// edit by surendra
        //double Penalty47 = 0;
        //// end
        //double ShipeValue47 = 0;
        //double ctsl47 = 0;
        //double PendingQty_47 = 0;
        //double pedPendingVal_47 = 0;

        //double PendingStitchQty_47 = 0;

        public static double CutQty47total;
        public static double StitchQty47total;
        public static double FinishQty47total;
        public static double ShipeQty47total;
        public static double ShipeValue47total;
        public static double ctsl4747total;
        public static double PendingQty_47total;
        public static double pedPendingVal_47total;
        public static double pedPendingVal_fob_47total;
        public static double PenaltyValue_47total;
        public static double PendingStitchQty_47total;
        //-----------------------------------------------d169-------------------------------------------------------
        //double Penalty169 = 0;
        //double CutQtyCtsl_D169 = 0;
        //public static double CutQtyCtsl_D169total;
        //double CutQty169 = 0;
        //double StitchQty169 = 0;
        //double FinishQty169 = 0;
        //double ShipeQty169 = 0;
        //double ShipeValue169 = 0;
        //double ctsl169 = 0;
        //double PendingQty_169 = 0;
        //double pedPendingVal_169 = 0;

        //double PendingStitchQty_169 = 0;
        public static double CutQty169total;
        public static double StitchQty169total;
        public static double FinishQty169total;
        public static double ShipeQty169total;
        public static double ShipeValue169total;
        public static double ctsl4747_169total;
        public static double PendingQty_169total;
        public static double pedPendingVal_169total;
        public static double pedPendingVal_fob_169total;
        public static double PenaltyValue_169total;
        public static double PendingStitchQty_169total;



        // double CutQtyCtsl_C47 = 0;


        public static double CutQtyCtsl_C47total;



        //---------------------------------C46C47---------------------------------------//
        //double CutQty46C47 = 0;
        //double StitchQty46C47 = 0;
        //double FinishQty46C47 = 0;
        //double ShipeQty46C47 = 0;
        //double Penalty46C47 = 0;
        //double ShipeValue46C47 = 0;
        //double ctsl46C47 = 0;
        //double PendingQty46C47 = 0;
        //double pedPendingVal46C47 = 0;
        //double pedPendingVal_fob_46C47 = 0;
        //double PendingStitchQty_46C47 = 0;

        public static double CutQty46C47total;
        public static double StitchQty46C47total;
        public static double FinishQty46C47total;
        public static double ShipeQty46C47total;
        public static double ShipeValue46C47total;
        public static double ctsl46C47total;
        public static double PendingQty46C47total;
        public static double pedPendingVal46C47total;
        public static double pedPendingVal_fob_46C47total;
        public static double PenaltyValue_46C47total;
        public static double PendingStitchQtyTotal_C4546;

        // double CutQtyCtsl_46C47 = 0;


        public static double CutQtyCtsl_46C47total;
        //---------------------------------BIPL---------------------------------------//

        //double CutQtyBIPL = 0;
        //double StitchQtyBIPL = 0;
        //double FinishQtyBIPL = 0;
        //double ShipeQtyBIPL = 0;
        //double PenaltyBIPL = 0;
        //double ShipeValueBIPL = 0;
        //double ctslBIPL = 0;
        //double PendingQtyBIPL = 0;
        //double pedPendingValBIPL = 0;
        //double pedPendingVal_fob_BIPL = 0;
        //double PendingStitchQty_BIPL = 0;


        public static double CutQtyBIPLtotal = 0;
        public static double StitchQtyBIPLtotal = 0;
        public static double FinishQtyBIPLtotal = 0;
        public static double ShipeQtyBIPLtotal = 0;
        public static double ShipeValueBIPLtotal = 0;
        public static double ctslBIPLtotal = 0;
        public static double PendingQtyBIPLtotal = 0;
        public static double pedPendingValBIPLtotal = 0;
        public static double pedPendingVal_fob_BIPLtotal = 0;
        public static double PenaltyValue_BIPLtotal = 0;
        public static double PendingStitchQtyTotal_BIPL = 0;


        


        public static double CutQtyCtsl_BIPLtotal;

        ////public void getShipmentReportCummlative()
        ////{

        ////    //----------------------------------------C47--------------------------------------------------------//

        ////    foreach (GridViewRow row in gridshipemtNew.Rows)
        ////    {
        ////        HiddenField hdnQty_47 = (HiddenField)row.FindControl("hdnQty_47");
        ////        HiddenField hdnQtyCutCtsl_C47 = (HiddenField)row.FindControl("hdnQtyCutCtsl_C47");

        ////        if (hdnQty_47 != null)
        ////        {
        ////            if (hdnQty_47.Value != "")
        ////            {
        ////                hdnQty_47.Value = hdnQty_47.Value == "" ? "0" : hdnQty_47.Value;

        ////                if (hdnQty_47.Value != "")
        ////                {
        ////                    CutQty47 = CutQty47 + Convert.ToDouble(hdnQty_47.Value);
        ////                    CutQty47total = CutQty47;

        ////                }
        ////            }
        ////        }
        ////        if (hdnQtyCutCtsl_C47 != null)
        ////        {
        ////            if (hdnQtyCutCtsl_C47.Value != "")
        ////            {
        ////                hdnQtyCutCtsl_C47.Value = hdnQtyCutCtsl_C47.Value == "" ? "0" : hdnQtyCutCtsl_C47.Value;

        ////                if (hdnQtyCutCtsl_C47.Value != "")
        ////                {
        ////                    CutQtyCtsl_C47 = CutQtyCtsl_C47 + Convert.ToDouble(hdnQtyCutCtsl_C47.Value);
        ////                    CutQtyCtsl_C47total = CutQtyCtsl_C47;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnstitchQty_47 = (HiddenField)row.FindControl("hdnstitchQty_47");
        ////        if (hdnstitchQty_47 != null)
        ////        {
        ////            if (hdnstitchQty_47.Value != "")
        ////            {
        ////                hdnstitchQty_47.Value = hdnstitchQty_47.Value == "" ? "0" : hdnstitchQty_47.Value;

        ////                if (hdnstitchQty_47.Value != "")
        ////                {
        ////                    StitchQty47 = StitchQty47 + Convert.ToDouble(hdnstitchQty_47.Value);
        ////                    StitchQty47total = StitchQty47;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnFinishQty_47 = (HiddenField)row.FindControl("hdnFinishQty_47");
        ////        if (hdnFinishQty_47 != null)
        ////        {
        ////            if (hdnFinishQty_47.Value != "")
        ////            {
        ////                hdnFinishQty_47.Value = hdnFinishQty_47.Value == "" ? "0" : hdnFinishQty_47.Value;

        ////                if (hdnFinishQty_47.Value != "")
        ////                {
        ////                    FinishQty47 = FinishQty47 + Convert.ToDouble(hdnFinishQty_47.Value);
        ////                    FinishQty47total = FinishQty47;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnShipedQty_47 = (HiddenField)row.FindControl("hdnShipedQty_47");
        ////        if (hdnShipedQty_47 != null)
        ////        {
        ////            if (hdnShipedQty_47.Value != "")
        ////            {
        ////                hdnShipedQty_47.Value = hdnShipedQty_47.Value == "" ? "0" : hdnShipedQty_47.Value;

        ////                if (hdnShipedQty_47.Value != "")
        ////                {
        ////                    ShipeQty47 = ShipeQty47 + Convert.ToDouble(hdnShipedQty_47.Value);
        ////                    ShipeQty47total = ShipeQty47;

        ////                }
        ////            }
        ////        }
        ////        // edit by surendra
        ////        HiddenField hdnPenalty_47 = (HiddenField)row.FindControl("hdnPenalty_47");
        ////        if (hdnPenalty_47 != null)
        ////        {
        ////            if (hdnPenalty_47.Value != "")
        ////            {
        ////                hdnPenalty_47.Value = hdnPenalty_47.Value == "" ? "0" : hdnPenalty_47.Value;

        ////                if (hdnPenalty_47.Value != "")
        ////                {
        ////                    Penalty47 = Penalty47 + Convert.ToDouble(hdnPenalty_47.Value);
        ////                    PenaltyValue_47total = Penalty47;

        ////                }
        ////            }
        ////        }
        ////        //
        ////        HiddenField hdnhipedValQty = (HiddenField)row.FindControl("hdnhipedValQty");
        ////        if (hdnhipedValQty != null)
        ////        {
        ////            if (hdnhipedValQty.Value != "")
        ////            {
        ////                hdnhipedValQty.Value = hdnhipedValQty.Value == "" ? "0" : hdnhipedValQty.Value;

        ////                if (hdnhipedValQty.Value != "")
        ////                {
        ////                    ShipeValue47 = ShipeValue47 + Convert.ToDouble(hdnhipedValQty.Value);
        ////                    ShipeValue47total = ShipeValue47;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnCtsl_c47 = (HiddenField)row.FindControl("hdnCtsl_c47");
        ////        if (hdnCtsl_c47 != null)
        ////        {
        ////            if (hdnCtsl_c47.Value != "")
        ////            {
        ////                hdnCtsl_c47.Value = hdnCtsl_c47.Value == "" ? "0" : hdnCtsl_c47.Value;

        ////                if (hdnCtsl_c47.Value != "")
        ////                {
        ////                    ctsl47 = ctsl47 + Convert.ToDouble(hdnCtsl_c47.Value);
        ////                    ctsl4747total = ctsl47;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnPndstitchQty_C47 = (HiddenField)row.FindControl("hdnPndstitchQty_C47");
        ////        if (hdnPndstitchQty_C47 != null)
        ////        {
        ////            if (hdnPndstitchQty_C47.Value != "" && hdnPndstitchQty_C47.Value != "")
        ////            {
        ////                hdnPndstitchQty_C47.Value = hdnPndstitchQty_C47.Value == "" ? "0" : hdnPndstitchQty_C47.Value;

        ////                PendingStitchQty_47 = PendingStitchQty_47 + Convert.ToDouble(hdnPndstitchQty_C47.Value);
        ////                PendingStitchQty_47total = PendingStitchQty_47;
        ////            }
        ////        }
        ////        HiddenField hdnShipedPendingQty_47 = (HiddenField)row.FindControl("hdnShipedPendingQty_47");
        ////        if (hdnShipedPendingQty_47 != null)
        ////        {
        ////            if (hdnShipedPendingQty_47.Value != "")
        ////            {
        ////                hdnShipedPendingQty_47.Value = hdnShipedPendingQty_47.Value == "" ? "0" : hdnShipedPendingQty_47.Value;

        ////                if (hdnShipedPendingQty_47.Value != "")
        ////                {
        ////                    PendingQty_47 = PendingQty_47 + Convert.ToDouble(hdnShipedPendingQty_47.Value);
        ////                    PendingQty_47total = PendingQty_47;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnShipedPendingVal_47 = (HiddenField)row.FindControl("hdnShipedPendingVal_47");
        ////        if (hdnShipedPendingVal_47 != null)
        ////        {
        ////            if (hdnShipedPendingVal_47.Value != "")
        ////            {
        ////                hdnShipedPendingVal_47.Value = hdnShipedPendingVal_47.Value == "" ? "0" : hdnShipedPendingVal_47.Value;

        ////                if (hdnShipedPendingVal_47.Value != "")
        ////                {
        ////                    pedPendingVal_47 = pedPendingVal_47 + Convert.ToDouble(hdnShipedPendingVal_47.Value);
        ////                    pedPendingVal_47total = pedPendingVal_47;

        ////                }
        ////            }
        ////        }
        ////        //HiddenField hdnfobpercentage_47 = (HiddenField)row.FindControl("hdnfobpercentage_47");
        ////        //if (hdnfobpercentage_47 != null)
        ////        //{
        ////        //    if (hdnfobpercentage_47.Value != "")
        ////        //    {
        ////        //        hdnfobpercentage_47.Value = hdnfobpercentage_47.Value == "" ? "0" : hdnfobpercentage_47.Value;

        ////        //        if (hdnfobpercentage_47.Value != "")
        ////        //        {
        ////        //            pedPendingVal_fob_47 = pedPendingVal_fob_47 + Convert.ToDouble(hdnfobpercentage_47.Value);
        ////        //            pedPendingVal_fob_47total = pedPendingVal_fob_47;

        ////        //        }
        ////        //    }
        ////        //}
        ////    }
        ////    // -------------------------------------D169-----------------------------------------------------------//


        ////    foreach (GridViewRow row in gridshipemtNew.Rows)
        ////    {
        ////        HiddenField hdnQty_169 = (HiddenField)row.FindControl("hdnQty_169");
        ////        HiddenField hdnQtyCutCtsl_169 = (HiddenField)row.FindControl("hdnQtyCutCtsl_169");

        ////        if (hdnQty_169 != null)
        ////        {
        ////            if (hdnQty_169.Value != "")
        ////            {
        ////                hdnQty_169.Value = hdnQty_169.Value == "" ? "0" : hdnQty_169.Value;

        ////                if (hdnQty_169.Value != "")
        ////                {
        ////                    CutQty169 = CutQty169 + Convert.ToDouble(hdnQty_169.Value);
        ////                    CutQty169total = CutQty169;

        ////                }
        ////            }
        ////        }
        ////        if (hdnQtyCutCtsl_169 != null)
        ////        {
        ////            if (hdnQtyCutCtsl_169.Value != "")
        ////            {
        ////                hdnQtyCutCtsl_169.Value = hdnQtyCutCtsl_169.Value == "" ? "0" : hdnQtyCutCtsl_169.Value;

        ////                if (hdnQtyCutCtsl_169.Value != "")
        ////                {
        ////                    CutQtyCtsl_D169 = CutQtyCtsl_D169 + Convert.ToDouble(hdnQtyCutCtsl_169.Value);
        ////                    CutQtyCtsl_D169total = CutQtyCtsl_D169;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnstitchQty_169 = (HiddenField)row.FindControl("hdnstitchQty_169");
        ////        if (hdnstitchQty_169 != null)
        ////        {
        ////            if (hdnstitchQty_169.Value != "")
        ////            {
        ////                hdnstitchQty_169.Value = hdnstitchQty_169.Value == "" ? "0" : hdnstitchQty_169.Value;

        ////                if (hdnstitchQty_169.Value != "")
        ////                {
        ////                    StitchQty169 = StitchQty169 + Convert.ToDouble(hdnstitchQty_169.Value);
        ////                    StitchQty169total = StitchQty169;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnFinishQty_169 = (HiddenField)row.FindControl("hdnFinishQty_169");
        ////        if (hdnFinishQty_169 != null)
        ////        {
        ////            if (hdnFinishQty_169.Value != "")
        ////            {
        ////                hdnFinishQty_169.Value = hdnFinishQty_169.Value == "" ? "0" : hdnFinishQty_169.Value;

        ////                if (hdnFinishQty_169.Value != "")
        ////                {
        ////                    FinishQty169 = FinishQty169 + Convert.ToDouble(hdnFinishQty_169.Value);
        ////                    FinishQty169total = FinishQty169;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnShipedQty_169 = (HiddenField)row.FindControl("hdnShipedQty_169");
        ////        if (hdnShipedQty_169 != null)
        ////        {
        ////            if (hdnShipedQty_169.Value != "")
        ////            {
        ////                hdnShipedQty_169.Value = hdnShipedQty_169.Value == "" ? "0" : hdnShipedQty_169.Value;

        ////                if (hdnShipedQty_169.Value != "")
        ////                {
        ////                    ShipeQty169 = ShipeQty169 + Convert.ToDouble(hdnShipedQty_169.Value);
        ////                    ShipeQty169total = ShipeQty169;

        ////                }
        ////            }
        ////        }
        ////        // edit by surendra
        ////        HiddenField hdnPenalty_169 = (HiddenField)row.FindControl("hdnPenalty_169");
        ////        if (hdnPenalty_169 != null)
        ////        {
        ////            if (hdnPenalty_169.Value != "")
        ////            {
        ////                hdnPenalty_169.Value = hdnPenalty_169.Value == "" ? "0" : hdnPenalty_169.Value;

        ////                if (hdnPenalty_169.Value != "")
        ////                {
        ////                    Penalty169 = Penalty169 + Convert.ToDouble(hdnPenalty_169.Value);
        ////                    PenaltyValue_169total = Penalty169;

        ////                }
        ////            }
        ////        }
        ////        //
        ////        HiddenField hdnhipedValQty_169 = (HiddenField)row.FindControl("hdnhipedValQty_169");
        ////        if (hdnhipedValQty_169 != null)
        ////        {
        ////            if (hdnhipedValQty_169.Value != "")
        ////            {
        ////                hdnhipedValQty_169.Value = hdnhipedValQty_169.Value == "" ? "0" : hdnhipedValQty_169.Value;

        ////                if (hdnhipedValQty_169.Value != "")
        ////                {
        ////                    ShipeValue169 = ShipeValue169 + Convert.ToDouble(hdnhipedValQty_169.Value);
        ////                    ShipeValue169total = ShipeValue169;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnCtsl_D169 = (HiddenField)row.FindControl("hdnCtsl_D169");
        ////        if (hdnCtsl_D169 != null)
        ////        {
        ////            if (hdnCtsl_D169.Value != "")
        ////            {
        ////                hdnCtsl_D169.Value = hdnCtsl_D169.Value == "" ? "0" : hdnCtsl_D169.Value;

        ////                if (hdnCtsl_D169.Value != "")
        ////                {
        ////                    ctsl169 = ctsl169 + Convert.ToDouble(hdnCtsl_D169.Value);
        ////                    ctsl4747_169total = ctsl169;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnPndstitchQty_D169 = (HiddenField)row.FindControl("hdnPndstitchQty_D169");
        ////        if (hdnPndstitchQty_D169 != null)
        ////        {
        ////            if (hdnPndstitchQty_D169.Value != "" && hdnPndstitchQty_D169.Value != "")
        ////            {
        ////                hdnPndstitchQty_D169.Value = hdnPndstitchQty_D169.Value == "" ? "0" : hdnPndstitchQty_D169.Value;

        ////                PendingStitchQty_169 = PendingStitchQty_169 + Convert.ToDouble(hdnPndstitchQty_D169.Value);
        ////                PendingStitchQty_169total = PendingStitchQty_169;
        ////            }
        ////        }
        ////        HiddenField hdnShipedPendingQty_169 = (HiddenField)row.FindControl("hdnShipedPendingQty_169");
        ////        if (hdnShipedPendingQty_169 != null)
        ////        {
        ////            if (hdnShipedPendingQty_169.Value != "")
        ////            {
        ////                hdnShipedPendingQty_169.Value = hdnShipedPendingQty_169.Value == "" ? "0" : hdnShipedPendingQty_169.Value;

        ////                if (hdnShipedPendingQty_169.Value != "")
        ////                {
        ////                    PendingQty_169 = PendingQty_169 + Convert.ToDouble(hdnShipedPendingQty_169.Value);
        ////                    PendingQty_169total = PendingQty_169;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnShipedPendingVal_169 = (HiddenField)row.FindControl("hdnShipedPendingVal_169");
        ////        if (hdnShipedPendingVal_169 != null)
        ////        {
        ////            if (hdnShipedPendingVal_169.Value != "")
        ////            {
        ////                hdnShipedPendingVal_169.Value = hdnShipedPendingVal_169.Value == "" ? "0" : hdnShipedPendingVal_169.Value;

        ////                if (hdnShipedPendingVal_169.Value != "")
        ////                {
        ////                    pedPendingVal_169 = pedPendingVal_169 + Convert.ToDouble(hdnShipedPendingVal_169.Value);
        ////                    pedPendingVal_169total = pedPendingVal_169;

        ////                }
        ////            }
        ////        }
        ////        //HiddenField hdnfobpercentage_47 = (HiddenField)row.FindControl("hdnfobpercentage_47");
        ////        //if (hdnfobpercentage_47 != null)
        ////        //{
        ////        //    if (hdnfobpercentage_47.Value != "")
        ////        //    {
        ////        //        hdnfobpercentage_47.Value = hdnfobpercentage_47.Value == "" ? "0" : hdnfobpercentage_47.Value;

        ////        //        if (hdnfobpercentage_47.Value != "")
        ////        //        {
        ////        //            pedPendingVal_fob_47 = pedPendingVal_fob_47 + Convert.ToDouble(hdnfobpercentage_47.Value);
        ////        //            pedPendingVal_fob_47total = pedPendingVal_fob_47;

        ////        //        }
        ////        //    }
        ////        //}
        ////    }
        ////    //-------------------------------------end-------------------------------------------------------------//
        ////    //----------------------------------------C46C47--------------------------------------------------------//  
        ////    foreach (GridViewRow row in gridshipemtNew.Rows)
        ////    {
        ////        HiddenField hdnQty_4546 = (HiddenField)row.FindControl("hdnQty_4546");
        ////        if (hdnQty_4546 != null)
        ////        {
        ////            if (hdnQty_4546.Value != "")
        ////            {
        ////                hdnQty_4546.Value = hdnQty_4546.Value == "" ? "0" : hdnQty_4546.Value;

        ////                if (hdnQty_4546.Value != "")
        ////                {
        ////                    CutQty46C47 = CutQty46C47 + Convert.ToDouble(hdnQty_4546.Value);
        ////                    CutQty46C47total = CutQty46C47;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnQtyCutCtsl_4546 = (HiddenField)row.FindControl("hdnQtyCutCtsl_4546");
        ////        if (hdnQtyCutCtsl_4546 != null)
        ////        {
        ////            if (hdnQtyCutCtsl_4546.Value != "")
        ////            {
        ////                hdnQtyCutCtsl_4546.Value = hdnQtyCutCtsl_4546.Value == "" ? "0" : hdnQtyCutCtsl_4546.Value;

        ////                if (hdnQtyCutCtsl_4546.Value != "")
        ////                {
        ////                    CutQtyCtsl_46C47 = CutQtyCtsl_46C47 + Convert.ToDouble(hdnQtyCutCtsl_4546.Value);
        ////                    CutQtyCtsl_46C47total = CutQtyCtsl_46C47;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnstitchQty_4546 = (HiddenField)row.FindControl("hdnstitchQty_4546");
        ////        if (hdnstitchQty_4546 != null)
        ////        {
        ////            if (hdnstitchQty_4546.Value != "")
        ////            {
        ////                hdnstitchQty_4546.Value = hdnstitchQty_4546.Value == "" ? "0" : hdnstitchQty_4546.Value;

        ////                if (hdnstitchQty_4546.Value != "")
        ////                {
        ////                    StitchQty46C47 = StitchQty46C47 + Convert.ToDouble(hdnstitchQty_4546.Value);
        ////                    StitchQty46C47total = StitchQty46C47;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnFinishQty_4546 = (HiddenField)row.FindControl("hdnFinishQty_4546");
        ////        if (hdnFinishQty_4546 != null)
        ////        {
        ////            if (hdnFinishQty_4546.Value != "")
        ////            {
        ////                hdnFinishQty_4546.Value = hdnFinishQty_4546.Value == "" ? "0" : hdnFinishQty_4546.Value;

        ////                if (hdnstitchQty_4546.Value != "")
        ////                {
        ////                    FinishQty46C47 = FinishQty46C47 + Convert.ToDouble(hdnFinishQty_4546.Value);
        ////                    FinishQty46C47total = FinishQty46C47;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdShipedQty_4546 = (HiddenField)row.FindControl("hdShipedQty_4546");
        ////        if (hdShipedQty_4546 != null)
        ////        {
        ////            if (hdShipedQty_4546.Value != "")
        ////            {
        ////                hdShipedQty_4546.Value = hdShipedQty_4546.Value == "" ? "0" : hdShipedQty_4546.Value;

        ////                if (hdShipedQty_4546.Value != "")
        ////                {
        ////                    ShipeQty46C47 = ShipeQty46C47 + Convert.ToDouble(hdShipedQty_4546.Value);
        ////                    ShipeQty46C47total = ShipeQty46C47;

        ////                }
        ////            }
        ////        }
        ////        // edit by surendra
        ////        HiddenField hdnPenalty_4546 = (HiddenField)row.FindControl("hdnPenalty_4546");
        ////        if (hdnPenalty_4546 != null)
        ////        {
        ////            if (hdnPenalty_4546.Value != "")
        ////            {
        ////                hdnPenalty_4546.Value = hdnPenalty_4546.Value == "" ? "0" : hdnPenalty_4546.Value;

        ////                if (hdnPenalty_4546.Value != "")
        ////                {
        ////                    Penalty46C47 = Penalty46C47 + Convert.ToDouble(hdnPenalty_4546.Value);
        ////                    PenaltyValue_46C47total = Penalty46C47;

        ////                }
        ////            }
        ////        }
        ////        // end
        ////        HiddenField hdnShipedVal_4546 = (HiddenField)row.FindControl("hdnShipedVal_4546");
        ////        if (hdnShipedVal_4546 != null)
        ////        {
        ////            if (hdnShipedVal_4546.Value != "")
        ////            {
        ////                hdnShipedVal_4546.Value = hdnShipedVal_4546.Value == "" ? "0" : hdnShipedVal_4546.Value;

        ////                if (hdnShipedVal_4546.Value != "")
        ////                {
        ////                    ShipeValue46C47 = ShipeValue46C47 + Convert.ToDouble(hdnShipedVal_4546.Value);
        ////                    ShipeValue46C47total = ShipeValue46C47;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnctsl_4645 = (HiddenField)row.FindControl("hdnctsl_4645");
        ////        if (hdnctsl_4645 != null)
        ////        {
        ////            if (hdnctsl_4645.Value != "")
        ////            {
        ////                hdnctsl_4645.Value = hdnctsl_4645.Value == "" ? "0" : hdnctsl_4645.Value;

        ////                if (hdnctsl_4645.Value != "")
        ////                {
        ////                    ctsl46C47 = ctsl46C47 + Convert.ToDouble(hdnctsl_4645.Value);
        ////                    ctsl46C47total = ctsl46C47;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdShipedPendingQty_4546 = (HiddenField)row.FindControl("hdShipedPendingQty_4546");
        ////        if (hdShipedPendingQty_4546 != null)
        ////        {
        ////            if (hdShipedPendingQty_4546.Value != "")
        ////            {
        ////                hdShipedPendingQty_4546.Value = hdShipedPendingQty_4546.Value == "" ? "0" : hdShipedPendingQty_4546.Value;

        ////                if (hdShipedPendingQty_4546.Value != "")
        ////                {
        ////                    PendingQty46C47 = PendingQty46C47 + Convert.ToDouble(hdShipedPendingQty_4546.Value);
        ////                    PendingQty46C47total = PendingQty46C47;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnShipedPendingVal_4546 = (HiddenField)row.FindControl("hdnShipedPendingVal_4546");
        ////        if (hdnShipedPendingVal_4546 != null)
        ////        {
        ////            if (hdnShipedPendingVal_4546.Value != "")
        ////            {
        ////                hdnShipedPendingVal_4546.Value = hdnShipedPendingVal_4546.Value == "" ? "0" : hdnShipedPendingVal_4546.Value;

        ////                if (hdnShipedPendingVal_4546.Value != "")
        ////                {
        ////                    pedPendingVal46C47 = pedPendingVal46C47 + Convert.ToDouble(hdnShipedPendingVal_4546.Value);
        ////                    pedPendingVal46C47total = pedPendingVal46C47;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnPndStitchQty_C4546 = (HiddenField)row.FindControl("hdnPndStitchQty_C4546");
        ////        if (hdnPndStitchQty_C4546 != null)
        ////        {
        ////            if (hdnPndStitchQty_C4546.Value != "")
        ////            {
        ////                hdnPndStitchQty_C4546.Value = hdnPndStitchQty_C4546.Value == "" ? "0" : hdnPndStitchQty_C4546.Value;
        ////                PendingStitchQty_46C47 = PendingStitchQty_46C47 + Convert.ToDouble(hdnPndStitchQty_C4546.Value);
        ////                PendingStitchQtyTotal_C4546 = PendingStitchQty_46C47;
        ////            }
        ////        }
        ////        //HiddenField hdnfobpercentage_4546 = (HiddenField)row.FindControl("hdnfobpercentage_4546");
        ////        //if (hdnfobpercentage_4546 != null)
        ////        //{
        ////        //    if (hdnfobpercentage_4546.Value != "")
        ////        //    {
        ////        //        hdnfobpercentage_4546.Value = hdnfobpercentage_4546.Value == "" ? "0" : hdnfobpercentage_4546.Value;

        ////        //        if (hdnfobpercentage_4546.Value != "")
        ////        //        {
        ////        //            pedPendingVal_fob_46C47 = pedPendingVal_fob_46C47 + Convert.ToDouble(hdnfobpercentage_4546.Value);
        ////        //            pedPendingVal_fob_46C47total = pedPendingVal_fob_46C47;

        ////        //        }
        ////        //    }
        ////        //}
        ////    }
        ////    //----------------------------------------BIPL--------------------------------------------------------// 
        ////    foreach (GridViewRow row in gridshipemtNew.Rows)
        ////    {
        ////        HiddenField hdcutqty_BIPL = (HiddenField)row.FindControl("hdcutqty_BIPL");
        ////        if (hdcutqty_BIPL != null)
        ////        {
        ////            if (hdcutqty_BIPL.Value != "")
        ////            {
        ////                hdcutqty_BIPL.Value = hdcutqty_BIPL.Value == "" ? "0" : hdcutqty_BIPL.Value;

        ////                if (hdcutqty_BIPL.Value != "")
        ////                {
        ////                    CutQtyBIPL = CutQtyBIPL + Convert.ToDouble(hdcutqty_BIPL.Value);
        ////                    CutQty46C47total = CutQtyBIPL;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnQtyCutCtsl_BIPL = (HiddenField)row.FindControl("hdnQtyCutCtsl_BIPL");
        ////        if (hdnQtyCutCtsl_BIPL != null)
        ////        {
        ////            if (hdnQtyCutCtsl_BIPL.Value != "")
        ////            {
        ////                hdnQtyCutCtsl_BIPL.Value = hdnQtyCutCtsl_BIPL.Value == "" ? "0" : hdnQtyCutCtsl_BIPL.Value;

        ////                if (hdnQtyCutCtsl_BIPL.Value != "")
        ////                {
        ////                    CutQtyCtsl_BIPL = CutQtyCtsl_BIPL + Convert.ToDouble(hdnQtyCutCtsl_BIPL.Value);
        ////                    CutQtyCtsl_BIPLtotal = CutQtyCtsl_BIPL;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdstitchQty_BIPL = (HiddenField)row.FindControl("hdstitchQty_BIPL");
        ////        if (hdstitchQty_BIPL != null)
        ////        {
        ////            if (hdstitchQty_BIPL.Value != "")
        ////            {
        ////                hdstitchQty_BIPL.Value = hdstitchQty_BIPL.Value == "" ? "0" : hdstitchQty_BIPL.Value;

        ////                if (hdstitchQty_BIPL.Value != "")
        ////                {
        ////                    StitchQtyBIPL = StitchQtyBIPL + Convert.ToDouble(hdstitchQty_BIPL.Value);
        ////                    StitchQtyBIPLtotal = StitchQtyBIPL;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdFinishQty_BIPL = (HiddenField)row.FindControl("hdFinishQty_BIPL");
        ////        if (hdFinishQty_BIPL != null)
        ////        {
        ////            if (hdFinishQty_BIPL.Value != "")
        ////            {
        ////                hdFinishQty_BIPL.Value = hdFinishQty_BIPL.Value == "" ? "0" : hdFinishQty_BIPL.Value;

        ////                if (hdFinishQty_BIPL.Value != "")
        ////                {
        ////                    FinishQtyBIPL = FinishQtyBIPL + Convert.ToDouble(hdFinishQty_BIPL.Value);
        ////                    FinishQtyBIPLtotal = FinishQtyBIPL;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdShipedQty_BIPL = (HiddenField)row.FindControl("hdShipedQty_BIPL");
        ////        if (hdShipedQty_BIPL != null)
        ////        {
        ////            if (hdShipedQty_BIPL.Value != "")
        ////            {
        ////                hdShipedQty_BIPL.Value = hdShipedQty_BIPL.Value == "" ? "0" : hdShipedQty_BIPL.Value;

        ////                if (hdShipedQty_BIPL.Value != "")
        ////                {
        ////                    ShipeQtyBIPL = ShipeQtyBIPL + Convert.ToDouble(hdShipedQty_BIPL.Value);
        ////                    ShipeQtyBIPLtotal = ShipeQtyBIPL;

        ////                }
        ////            }
        ////        }
        ////        // edit by surendra
        ////        HiddenField hdPenalty_BIPL = (HiddenField)row.FindControl("hdPenalty_BIPL");
        ////        if (hdPenalty_BIPL != null)
        ////        {
        ////            if (hdPenalty_BIPL.Value != "")
        ////            {
        ////                hdPenalty_BIPL.Value = hdPenalty_BIPL.Value == "" ? "0" : hdPenalty_BIPL.Value;

        ////                if (hdPenalty_BIPL.Value != "")
        ////                {
        ////                    PenaltyBIPL = PenaltyBIPL + Convert.ToDouble(hdPenalty_BIPL.Value);
        ////                    PenaltyValue_BIPLtotal = PenaltyBIPL;

        ////                }
        ////            }
        ////        }
        ////        // end
        ////        HiddenField hdnShipedVal_BIPL = (HiddenField)row.FindControl("hdnShipedVal_BIPL");
        ////        if (hdnShipedVal_BIPL != null)
        ////        {
        ////            if (hdnShipedVal_BIPL.Value != "")
        ////            {
        ////                hdnShipedVal_BIPL.Value = hdnShipedVal_BIPL.Value == "" ? "0" : hdnShipedVal_BIPL.Value;

        ////                if (hdnShipedVal_BIPL.Value != "")
        ////                {
        ////                    ShipeValueBIPL = ShipeValueBIPL + Convert.ToDouble(hdnShipedVal_BIPL.Value);
        ////                    ShipeValueBIPLtotal = ShipeValueBIPL;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnCtsl_BIPL = (HiddenField)row.FindControl("hdnCtsl_BIPL");
        ////        if (hdnCtsl_BIPL != null)
        ////        {
        ////            if (hdnCtsl_BIPL.Value != "")
        ////            {
        ////                hdnCtsl_BIPL.Value = hdnCtsl_BIPL.Value == "" ? "0" : hdnCtsl_BIPL.Value;

        ////                if (hdnCtsl_BIPL.Value != "")
        ////                {
        ////                    ctslBIPL = ctslBIPL + Convert.ToDouble(hdnCtsl_BIPL.Value);
        ////                    ctslBIPLtotal = ctslBIPL;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdShipedPendingQty_BIPL = (HiddenField)row.FindControl("hdShipedPendingQty_BIPL");
        ////        if (hdShipedPendingQty_BIPL != null)
        ////        {
        ////            if (hdShipedPendingQty_BIPL.Value != "")
        ////            {
        ////                hdShipedPendingQty_BIPL.Value = hdShipedPendingQty_BIPL.Value == "" ? "0" : hdShipedPendingQty_BIPL.Value;

        ////                if (hdShipedPendingQty_BIPL.Value != "")
        ////                {
        ////                    PendingQtyBIPL = PendingQtyBIPL + Convert.ToDouble(hdShipedPendingQty_BIPL.Value);
        ////                    PendingQtyBIPLtotal = PendingQtyBIPL;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnShipedPendingVal_BIPL = (HiddenField)row.FindControl("hdnShipedPendingVal_BIPL");
        ////        if (hdnShipedPendingVal_BIPL != null)
        ////        {
        ////            if (hdnShipedPendingVal_BIPL.Value != "")
        ////            {
        ////                hdnShipedPendingVal_BIPL.Value = hdnShipedPendingVal_BIPL.Value == "" ? "0" : hdnShipedPendingVal_BIPL.Value;

        ////                if (hdnShipedPendingVal_BIPL.Value != "")
        ////                {
        ////                    pedPendingValBIPL = pedPendingValBIPL + Convert.ToDouble(hdnShipedPendingVal_BIPL.Value);
        ////                    pedPendingValBIPLtotal = pedPendingValBIPL;

        ////                }
        ////            }
        ////        }
        ////        HiddenField hdnPendingStitchQty_BIPL = (HiddenField)row.FindControl("hdnPendingStitchQty_BIPL");
        ////        if (hdnPendingStitchQty_BIPL != null)
        ////        {
        ////            if (hdnPendingStitchQty_BIPL.Value != "")
        ////            {
        ////                hdnPendingStitchQty_BIPL.Value = hdnPendingStitchQty_BIPL.Value == "" ? "0" : hdnPendingStitchQty_BIPL.Value;

        ////                if (hdnPendingStitchQty_BIPL.Value != "")
        ////                {
        ////                    PendingStitchQty_BIPL = PendingStitchQty_BIPL + Convert.ToDouble(hdnPendingStitchQty_BIPL.Value);
        ////                    PendingStitchQtyTotal_BIPL = PendingStitchQty_BIPL;

        ////                }
        ////            }
        ////        }
        ////        //HiddenField hdnfobpercentage_bipl = (HiddenField)row.FindControl("hdnfobpercentage_bipl");
        ////        //if (hdnfobpercentage_bipl != null)
        ////        //{
        ////        //    if (hdnfobpercentage_bipl.Value != "")
        ////        //    {
        ////        //        hdnfobpercentage_bipl.Value = hdnfobpercentage_bipl.Value == "" ? "0" : hdnfobpercentage_bipl.Value;

        ////        //        if (hdnfobpercentage_bipl.Value != "")
        ////        //        {
        ////        //            pedPendingVal_fob_BIPL = pedPendingVal_fob_BIPL + Convert.ToDouble(hdnfobpercentage_bipl.Value);
        ////        //            pedPendingVal_fob_BIPLtotal = pedPendingVal_fob_BIPL;

        ////        //        }
        ////        //    }
        ////        //}

        ////    }


        ////    //HtmlGenericControl spCurrentWeekCumulativeSum_c45 = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentWeekCumulativeSum_c45");
        ////    //HtmlGenericControl spCurrentWeekCumulativeSum_c46 = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentWeekCumulativeSum_c46");
        ////    //HtmlGenericControl spCurrentWeekCumulativeSum_out = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentWeekCumulativeSum_out");
        ////    //HtmlGenericControl spCurrentWeekCumulativeSum_Bipl = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentWeekCumulativeSum_Bipl");
        ////    //HtmlGenericControl spctslCumulativeSum = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spctslCumulativeSum");

        ////    ////spCurrentWeekCumulativeSum_c45.InnerText = qntyc45total == 0 ? "" : qntyc45total.ToString()+" k ";
        ////    ////spCurrentWeekCumulativeSum_c46.InnerText = qntyc46total == 0 ? "" : qntyc46total.ToString() + " k "; ;
        ////    ////spCurrentWeekCumulativeSum_out.InnerText = qntycouttotal == 0 ? "" : qntycouttotal.ToString() + " k "; ;
        ////    ////spCurrentWeekCumulativeSum_Bipl.InnerText = qntycbipltotal == 0 ? "" : qntycbipltotal.ToString() + " k "; ;

        ////    ////spctslCumulativeSum.InnerText = qntyctsltotal == 0 ? "" : qntyctsltotal.ToString();

        ////    ////HtmlGenericControl spctsl46 = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spctsl46");
        ////    ////HtmlGenericControl spctsl47 = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spctsl47");
        ////    ////HtmlGenericControl spctslout = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spctslout");
        ////    ////HtmlGenericControl spctslbipl = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spctslbipl");

        ////    ////spctsl46.InnerText = qntyc45totalctsl == 0 ? "" : "("+qntyc45totalctsl.ToString()+"%)";
        ////    ////spctsl47.InnerText = qntyc46totalctsl == 0 ? "" : "(" + qntyc46totalctsl.ToString() + "%)";
        ////    ////spctslout.InnerText = qntycouttotalctsl == 0 ? "" : "(" + qntycouttotalctsl.ToString() + "%)";
        ////    ////spctslbipl.InnerText = qntycbipltotalctsl == 0 ? "" : "(" + qntycbipltotalctsl.ToString() + "%)";


        ////    ////HtmlGenericControl spCurrentValueCumulativeSum_c45 = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentValueCumulativeSum_c45");
        ////    ////HtmlGenericControl spCurrentValueCumulativeSum_c46 = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentValueCumulativeSum_c46");
        ////    ////HtmlGenericControl spCurrentValueCumulativeSum_out = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentValueCumulativeSum_out");
        ////    ////HtmlGenericControl spCurrentValueCumulativeSum_bipl = (HtmlGenericControl)gridshipemtNew.FooterRow.FindControl("spCurrentValueCumulativeSum_bipl");



        ////    //////spCurrentValueCumulativeSum_c45.InnerText = qntytotal_cum.ToString("N0") + " " + "pcs";
        ////    ////spCurrentValueCumulativeSum_c45.InnerText = val_cum45total == 0 ? "" : "\u20B9 " + val_cum45total;
        ////    ////spCurrentValueCumulativeSum_c46.InnerText = val_cum46total == 0 ? "" : "\u20B9 " + val_cum46total;
        ////    ////spCurrentValueCumulativeSum_out.InnerText = val_cumouttotal == 0 ? "" : "\u20B9 " + val_cumouttotal;
        ////    ////spCurrentValueCumulativeSum_bipl.InnerText = val_cumbipltotal == 0 ? "" : "\u20B9 " + val_cumbipltotal;

        ////    BindFoterSum();

        ////}
        public string SetMonthTotal(double values)
        {
            string Result = string.Empty;
            DataSet ds = new DataSet();
            DataTable dtworkingHours = new DataTable();
            ds = objadmin.GetProductionWorkingHours();
            dtworkingHours = ds.Tables[0];
            double hours = Convert.ToDouble(dtworkingHours.Rows[0]["WokringHours"].ToString());
            if (values != 0 && values != 0.0 && values != 0)
            {

                string Values = Math.Round(((Convert.ToDouble(values)) / (Convert.ToDouble(hours))), 1, MidpointRounding.AwayFromZero).ToString();
                Result = "<br /><span style='font-size: 8px;'>" + Values + " k pdy" + "</span>";
            }
            return Result;
        }
        public string SetMonthTotal_ForLastDay(double values)
        {
            string Result = string.Empty;
            DataSet ds = new DataSet();
            DataTable dtworkingHours = new DataTable();
            ds = objadmin.GetProductionWorkingHours();
            dtworkingHours = ds.Tables[0];
            double hours = Convert.ToDouble(dtworkingHours.Rows[0]["WokringHours"].ToString());
            if (values != 0 && values != 0.0 && values != 0)
            {

                string Values = Math.Round(((Convert.ToDouble(values)) / (Convert.ToDouble(hours))), 1, MidpointRounding.AwayFromZero).ToString();
                Result = "<br /><span style='font-size: 8px; font-weight:bold'>" + Values + " k pdy" + "</span>";
            }
            return Result;
        }
        //public void BindFoterSum()
        //{
        //    try
        //    {

        //        //--------------------------------------C47-------------------------------------------------------------//
        //        Label lblutQtyTotal_47 = (Label)gridshipemtNew.FooterRow.FindControl("lblutQtyTotal_47");
        //        Label lblstitchQtyTotal_47 = (Label)gridshipemtNew.FooterRow.FindControl("lblstitchQtyTotal_47");
        //        Label lblFinishQtyTotal_47 = (Label)gridshipemtNew.FooterRow.FindControl("lblFinishQtyTotal_47");
        //        Label lblShipedQtyTotal_c47 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedQtyTotal_c47");
        //        Label lblShipedValTotal_c47 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedValTotal_c47");
        //        Label lblCtslTotal_c47 = (Label)gridshipemtNew.FooterRow.FindControl("lblCtslTotal_c47");
        //        Label lblPndStitchQty_Total_C47 = (Label)gridshipemtNew.FooterRow.FindControl("lblPndStitchQty_Total_C47");
        //        Label lblShipedPendingQtyTotal_c47 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingQtyTotal_c47");
        //        Label lblShipedPendingValTotal_c47 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingValTotal_c47");
        //        Label lblShipedPendingValTotal_fob_c47 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingValTotal_fob_c47");
        //        Label lblPenaltyPendingValTotal_fob_c47 = (Label)gridshipemtNew.FooterRow.FindControl("lblPenaltyPendingValTotal_fob_c47");

        //        //----------------------prabhaker code start-------------------------//
        //        Label lblstitchvalTotal_47 = (Label)gridshipemtNew.FooterRow.FindControl("lblstitchvalTotal_47");
        //        Label lblFinishValTotal_47 = (Label)gridshipemtNew.FooterRow.FindControl("lblFinishValTotal_47");

        //        var monthStitchedValue = dtitemMonthC47_Total.Rows[0]["StitchedValue"];
        //        var monthFinishedValue = dtitemMonthC47_Total.Rows[0]["FinishedValue"];
        //        if (Convert.ToInt32(monthStitchedValue) != 0.00)
        //        {
        //            lblstitchvalTotal_47.Text = " \u20B9 " + dtitemMonthC47_Total.Rows[0]["StitchedValue"].ToString() + " Cr.";
        //        }
        //        else
        //        {
        //            lblstitchvalTotal_47.Text = "";
        //        }
        //        if (Convert.ToInt32(monthFinishedValue) != 0.00)
        //        {
        //            lblFinishValTotal_47.Text = " \u20B9 " + dtitemMonthC47_Total.Rows[0]["FinishedValue"].ToString() + " Cr.";
        //        }
        //        else
        //        {
        //            lblFinishValTotal_47.Text = "";
        //        }



        //        //-------------------end-of prabhaker code------------------------//

        //        //lblutQtyTotal_47.Text = CutQty47total == 0 ? "" : Get(CutQty47total.ToString().Replace("k", "")) + " k " + Get(SetMonthTotal(CutQty47total).Replace("k", ""));
        //        //lblstitchQtyTotal_47.Text = StitchQty47total == 0 ? "" : Get(StitchQty47total.ToString().Replace("k", "")) + " k " + Get(SetMonthTotal(StitchQty47total).Replace("k", "")); lblstitchQtyTotal_47.ForeColor = Color.Black;
        //        //lblFinishQtyTotal_47.Text = FinishQty47total == 0 ? "" : FinishQty47total.ToString() + " k " + SetMonthTotal(FinishQty47total);
        //        //lblShipedQtyTotal_c47.Text = ShipeQty47total == 0 ? "" : ShipeQty47total.ToString() + " k ";

        //        lblutQtyTotal_47.Text = CutQty47total == 0 ? "" : Get(CutQty47total.ToString().Replace("k", "")) + " k" + SetMonthTotal(Convert.ToDouble(Get(CutQty47total.ToString()).Replace("k", "")));
        //        lblstitchQtyTotal_47.Text = StitchQty47total == 0 ? "" : Get(StitchQty47total.ToString().Replace("k", "")) + " k " + SetMonthTotal_ForLastDay(Convert.ToDouble(Get(StitchQty47total.ToString()).Replace("k", ""))); lblstitchQtyTotal_47.ForeColor = Color.Black;
        //        lblFinishQtyTotal_47.Text = FinishQty47total == 0 ? "" : Get(FinishQty47total.ToString().Replace("k", "")) + " k " + SetMonthTotal(Convert.ToDouble(Get(FinishQty47total.ToString()).Replace("k", "")));
        //        lblShipedQtyTotal_c47.Text = ShipeQty47total == 0 ? "" : Get(ShipeQty47total.ToString().Replace("k", "")) + " k ";

        //        lblShipedValTotal_c47.Text = ShipeValue47total == 0 ? "" : "/<span style='color:green;'> " + "\u20B9" + String.Format("{0:0.0}", ShipeValue47total) + " Cr" + "</span>";
        //        //lblCtslTotal_c47.Text = ctsl4747total == 0 ? "" : "(" + ctsl4747total.ToString() + " % )"; ;

        //        ds = objadmin.GetPreiousMonthRevenue(3);
        //        DataTable dtLastMonthRevnue = ds.Tables[0];
        //        PendingStitchQty_47total = PendingStitchQty_47total + Convert.ToDouble(dtLastMonthRevnue.Rows[0]["PreviusMonthUnshippedQty"]);
        //        PendingQty_47total = PendingQty_47total + Convert.ToDouble(dtLastMonthRevnue.Rows[0]["PreviousMonthPendingOrderQty"]);
        //        pedPendingVal_47total = pedPendingVal_47total + Convert.ToDouble(dtLastMonthRevnue.Rows[0]["PreviousRevenue"]);
        //        lblPndStitchQty_Total_C47.Text = PendingStitchQty_47total == 0 ? "" : PendingStitchQty_47total.ToString() + " k ";

        //        lblShipedPendingQtyTotal_c47.Text = PendingQty_47total == 0 ? "" : PendingQty_47total.ToString() + " k ";
        //        lblShipedPendingValTotal_c47.Text = pedPendingVal_47total == 0 ? "" : "<span style='color:green;'> " + " \u20B9 " + pedPendingVal_47total.ToString() + " Cr" + "</span>";
        //        if (pedPendingVal_fob_47total.ToString() != "0.00" && pedPendingVal_fob_47total.ToString() != "0")
        //        {
        //            lblShipedPendingValTotal_fob_c47.Text = "/" + pedPendingVal_fob_47total.ToString() == "0.00" ? "" : "/ " + pedPendingVal_fob_47total + " %";
        //        }
        //        if (PenaltyValue_47total.ToString() != "0.00" && PenaltyValue_47total.ToString() != "0")
        //        {
        //            lblPenaltyPendingValTotal_fob_c47.Text = " \u20B9 " + PenaltyValue_47total.ToString() + " Lk";
        //        }





        //        //if ((CutQty47total != 0 & CutQty47total != 0.0) && (ShipeQty47total != 0 & ShipeQty47total != 0.0))
        //        //{
        //        //    string C47Ctsl = Math.Round(Convert.ToDouble((((CutQty47total - ShipeQty47total)*100) / Convert.ToDouble(CutQty47total))), 1, MidpointRounding.AwayFromZero).ToString();
        //        //    lblCtslTotal_c47.Text = C47Ctsl == "0" ? "" : "(" + C47Ctsl + " % )"; 

        //        //}

        //        //if ((CutQtyCtsl_C47total != 0 & CutQtyCtsl_C47total != 0.0) && (ShipeQty47total != 0 & ShipeQty47total != 0.0))
        //        //{
        //        //  string C47Ctsl = Math.Round(Convert.ToDouble((((CutQtyCtsl_C47total - ShipeQty47total) * 100) / Convert.ToDouble(CutQtyCtsl_C47total))), 1, MidpointRounding.AwayFromZero).ToString();
        //        //  lblCtslTotal_c47.Text = C47Ctsl == "0" ? "" : C47Ctsl + " %";

        //        //}
        //        ds = objadmin.get_ctsl(3);
        //        DataTable dt_CTSL = ds.Tables[0];
        //        if (Convert.ToInt32(dt_CTSL.Rows[0]["CTSL"]) > 0)
        //            lblCtslTotal_c47.Text = Convert.ToString(dt_CTSL.Rows[0]["CTSL"]) + " %";

        //        if (Convert.ToInt32(dt_CTSL.Rows[0]["RescanQty"]) > 0)
        //            lblCtslTotal_c47.Text = lblCtslTotal_c47.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(dt_CTSL.Rows[0]["RescanQty"].ToString()) + " </span>";

        //        //----------------------------------------D169--------------------------------------------------------------//

        //        Label lblutQtyTotal_169 = (Label)gridshipemtNew.FooterRow.FindControl("lblutQtyTotal_169");
        //        Label lblstitchQtyTotal_169 = (Label)gridshipemtNew.FooterRow.FindControl("lblstitchQtyTotal_169");
        //        Label lblFinishQtyTotal_169 = (Label)gridshipemtNew.FooterRow.FindControl("lblFinishQtyTotal_169");
        //        Label lblShipedQtyTotal_D169 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedQtyTotal_D169");
        //        Label lblShipedValTotal_D169 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedValTotal_D169");
        //        Label lblCtslTotal_D169 = (Label)gridshipemtNew.FooterRow.FindControl("lblCtslTotal_D169");
        //        Label lblPndStitchQty_Total_D169 = (Label)gridshipemtNew.FooterRow.FindControl("lblPndStitchQty_Total_D169");
        //        Label lblShipedPendingQtyTotal_D169 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingQtyTotal_D169");
        //        Label lblShipedPendingValTotal_D169 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingValTotal_D169");
        //        Label lblShipedPendingValTotal_fob_D169 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingValTotal_fob_D169");
        //        Label lblPenaltyPendingValTotal_fob_D169 = (Label)gridshipemtNew.FooterRow.FindControl("lblPenaltyPendingValTotal_fob_D169");

        //        //----------------------prabhaker code start-------------------------//
        //        Label lblstitchvalTotal_169 = (Label)gridshipemtNew.FooterRow.FindControl("lblstitchvalTotal_169");
        //        Label lblFinishValTotal_169 = (Label)gridshipemtNew.FooterRow.FindControl("lblFinishValTotal_169");

        //        var monthStitchedValue_169 = dtitemMonthD169_Total.Rows[0]["StitchedValue"];
        //        var monthFinishedValue_169 = dtitemMonthD169_Total.Rows[0]["FinishedValue"];
        //        if (Convert.ToInt32(monthStitchedValue_169) != 0.00)
        //        {
        //            lblstitchvalTotal_169.Text = " \u20B9 " + dtitemMonthD169_Total.Rows[0]["StitchedValue"].ToString() + " Cr.";
        //        }
        //        else
        //        {
        //            lblstitchvalTotal_169.Text = "";
        //        }
        //        if (Convert.ToInt32(monthFinishedValue_169) != 0.00)
        //        {
        //            lblFinishValTotal_169.Text = " \u20B9 " + dtitemMonthD169_Total.Rows[0]["FinishedValue"].ToString() + " Cr.";
        //        }
        //        else
        //        {
        //            lblFinishValTotal_169.Text = "";
        //        }



        //        //-------------------end-of prabhaker code------------------------//

        //        //lblutQtyTotal_47.Text = CutQty47total == 0 ? "" : Get(CutQty47total.ToString().Replace("k", "")) + " k " + Get(SetMonthTotal(CutQty47total).Replace("k", ""));
        //        //lblstitchQtyTotal_47.Text = StitchQty47total == 0 ? "" : Get(StitchQty47total.ToString().Replace("k", "")) + " k " + Get(SetMonthTotal(StitchQty47total).Replace("k", "")); lblstitchQtyTotal_47.ForeColor = Color.Black;
        //        //lblFinishQtyTotal_47.Text = FinishQty47total == 0 ? "" : FinishQty47total.ToString() + " k " + SetMonthTotal(FinishQty47total);
        //        //lblShipedQtyTotal_c47.Text = ShipeQty47total == 0 ? "" : ShipeQty47total.ToString() + " k ";

        //        lblutQtyTotal_169.Text = CutQty169total == 0 ? "" : Get(CutQty169total.ToString().Replace("k", "")) + " k" + SetMonthTotal(Convert.ToDouble(Get(CutQty169total.ToString()).Replace("k", "")));
        //        lblstitchQtyTotal_169.Text = StitchQty169total == 0 ? "" : Get(StitchQty169total.ToString().Replace("k", "")) + " k " + SetMonthTotal_ForLastDay(Convert.ToDouble(Get(StitchQty169total.ToString()).Replace("k", ""))); lblstitchQtyTotal_169.ForeColor = Color.Black;
        //        lblFinishQtyTotal_169.Text = FinishQty169total == 0 ? "" : Get(FinishQty169total.ToString().Replace("k", "")) + " k " + SetMonthTotal(Convert.ToDouble(Get(FinishQty169total.ToString()).Replace("k", "")));
        //        lblShipedQtyTotal_D169.Text = ShipeQty169total == 0 ? "" : Get(ShipeQty169total.ToString().Replace("k", "")) + " k ";

        //        lblShipedValTotal_D169.Text = ShipeValue169total == 0 ? "" : "/<span style='color:green;'> " + "\u20B9" + String.Format("{0:0.0}", ShipeValue169total) + " Cr" + "</span>";
        //        //lblCtslTotal_c47.Text = ctsl4747total == 0 ? "" : "(" + ctsl4747total.ToString() + " % )"; ;

        //        ds = objadmin.GetPreiousMonthRevenue(96);
        //        DataTable dtLastMonthRevnue_169 = ds.Tables[0];
        //        PendingStitchQty_169total = PendingStitchQty_169total + Convert.ToDouble(dtLastMonthRevnue_169.Rows[0]["PreviusMonthUnshippedQty"]);
        //        PendingQty_169total = PendingQty_169total + Convert.ToDouble(dtLastMonthRevnue_169.Rows[0]["PreviousMonthPendingOrderQty"]);
        //        pedPendingVal_169total = pedPendingVal_169total + Convert.ToDouble(dtLastMonthRevnue_169.Rows[0]["PreviousRevenue"]);
        //        lblPndStitchQty_Total_D169.Text = PendingStitchQty_169total == 0 ? "" : PendingStitchQty_169total.ToString() + " k ";

        //        lblShipedPendingQtyTotal_D169.Text = PendingQty_169total == 0 ? "" : PendingQty_169total.ToString() + " k ";
        //        lblShipedPendingValTotal_D169.Text = pedPendingVal_169total == 0 ? "" : "<span style='color:green;'> " + " \u20B9 " + pedPendingVal_169total.ToString() + " Cr" + "</span>";
        //        if (pedPendingVal_fob_169total.ToString() != "0.00" && pedPendingVal_fob_169total.ToString() != "0")
        //        {
        //            lblShipedPendingValTotal_fob_D169.Text = "/" + pedPendingVal_fob_169total.ToString() == "0.00" ? "" : "/ " + pedPendingVal_fob_169total + " %";
        //        }
        //        if (PenaltyValue_169total.ToString() != "0.00" && PenaltyValue_169total.ToString() != "0")
        //        {
        //            lblPenaltyPendingValTotal_fob_D169.Text = " \u20B9 " + PenaltyValue_169total.ToString() + " Lk";
        //        }





        //        //if ((CutQty47total != 0 & CutQty47total != 0.0) && (ShipeQty47total != 0 & ShipeQty47total != 0.0))
        //        //{
        //        //    string C47Ctsl = Math.Round(Convert.ToDouble((((CutQty47total - ShipeQty47total)*100) / Convert.ToDouble(CutQty47total))), 1, MidpointRounding.AwayFromZero).ToString();
        //        //    lblCtslTotal_c47.Text = C47Ctsl == "0" ? "" : "(" + C47Ctsl + " % )"; 

        //        //}

        //        //if ((CutQtyCtsl_C47total != 0 & CutQtyCtsl_C47total != 0.0) && (ShipeQty47total != 0 & ShipeQty47total != 0.0))
        //        //{
        //        //  string C47Ctsl = Math.Round(Convert.ToDouble((((CutQtyCtsl_C47total - ShipeQty47total) * 100) / Convert.ToDouble(CutQtyCtsl_C47total))), 1, MidpointRounding.AwayFromZero).ToString();
        //        //  lblCtslTotal_c47.Text = C47Ctsl == "0" ? "" : C47Ctsl + " %";

        //        //}
        //        ds = objadmin.get_ctsl(96);
        //        DataTable dt_CTSL_D169 = ds.Tables[0];
        //        if (Convert.ToInt32(dt_CTSL_D169.Rows[0]["CTSL"]) > 0)
        //            lblCtslTotal_D169.Text = Convert.ToString(dt_CTSL_D169.Rows[0]["CTSL"]) + " %";

        //        if (Convert.ToInt32(dt_CTSL_D169.Rows[0]["RescanQty"]) > 0)
        //            lblCtslTotal_D169.Text = lblCtslTotal_D169.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(dt_CTSL_D169.Rows[0]["RescanQty"].ToString()) + " </span>";
        //        //-------------------------------------end-------------------------------------------------------------------//

        //        //--------------------------------------C46C47-------------------------------------------------------------//

        //        Label lblutQtyTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblutQtyTotal_4546");
        //        Label lblstitchQtyTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblstitchQtyTotal_4546");
        //        Label lblFinishQtyTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblFinishQtyTotal_4546");
        //        Label lblShipedQtyTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedQtyTotal_4546");
        //        Label lblShipedValTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedValTotal_4546");
        //        Label lblCtslTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblCtslTotal_4546");
        //        Label lblPendingStitchQtyTotal_C4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblPendingStitchQtyTotal_C4546");
        //        Label lblShipedPendingQtyTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingQtyTotal_4546");
        //        Label lblShipedPendingValTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingValTotal_4546");
        //        Label lblShipedPendingValTotal_fob_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingValTotal_fob_4546");
        //        Label lblPenaltyPendingValTotal_fob_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblPenaltyPendingValTotal_fob_4546");

        //        Label lblstitchValTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblstitchValTotal_4546");
        //        Label lblFinishValTotal_4546 = (Label)gridshipemtNew.FooterRow.FindControl("lblFinishValTotal_4546");




        //        lblutQtyTotal_4546.Text = CutQty46C47 == 0 ? "" : CutQty46C47.ToString() + " k " + SetMonthTotal(CutQty46C47);
        //        lblstitchQtyTotal_4546.Text = StitchQty46C47 == 0 ? "" : StitchQty46C47.ToString() + " k " + SetMonthTotal_ForLastDay(StitchQty46C47); lblstitchQtyTotal_4546.ForeColor = Color.Black;
        //        lblFinishQtyTotal_4546.Text = FinishQty46C47 == 0 ? "" : FinishQty46C47.ToString() + " k " + SetMonthTotal(FinishQty46C47);
        //        lblShipedQtyTotal_4546.Text = ShipeQty46C47 == 0 ? "" : ShipeQty46C47.ToString() + " k "; ;
        //        lblShipedValTotal_4546.Text = ShipeValue46C47 == 0 ? "" : "/<span style='color:green;'> " + "\u20B9 " + String.Format("{0:0.0}", ShipeValue46C47) + " Cr" + "</span>";

        //        ds = objadmin.GetPreiousMonthRevenue(11);
        //        DataTable dtLastMonthRevnue_c4546 = ds.Tables[0];
        //        PendingStitchQtyTotal_C4546 = PendingStitchQtyTotal_C4546 + Convert.ToDouble(dtLastMonthRevnue_c4546.Rows[0]["PreviusMonthUnshippedQty"]);
        //        PendingQty46C47total = PendingQty46C47total + Convert.ToDouble(dtLastMonthRevnue_c4546.Rows[0]["PreviousMonthPendingOrderQty"]);
        //        pedPendingVal46C47total = pedPendingVal46C47total + Convert.ToDouble(dtLastMonthRevnue_c4546.Rows[0]["PreviousRevenue"]);
        //        // lblCtslTotal_4546.Text = ctsl46C47 == 0 ? "" : "(" + ctsl46C47.ToString() + " % )"; ;
        //        lblPendingStitchQtyTotal_C4546.Text = PendingStitchQtyTotal_C4546 == 0 ? "" : PendingStitchQtyTotal_C4546.ToString() + " k ";
        //        lblShipedPendingQtyTotal_4546.Text = PendingQty46C47total == 0 ? "" : PendingQty46C47total.ToString() + " k "; ;
        //        lblShipedPendingValTotal_4546.Text = pedPendingVal46C47total == 0 ? "" : "<span style='color:green;'> " + "\u20B9 " + pedPendingVal46C47total.ToString() + " Cr" + "</span>";

        //        // prabhaker coding start here


        //        var monthStitchedValue_4546 = dtitemMonthC4546_Total.Rows[0]["StitchedValue"];
        //        var monthFinishedValue_4546 = dtitemMonthC4546_Total.Rows[0]["FinishedValue"];
        //        if (Convert.ToInt32(monthStitchedValue_4546) != 0.00)
        //        {
        //            lblstitchValTotal_4546.Text = " \u20B9 " + dtitemMonthC4546_Total.Rows[0]["StitchedValue"].ToString() + " Cr.";
        //        }
        //        else
        //        {
        //            lblstitchValTotal_4546.Text = "";
        //        }
        //        if (Convert.ToInt32(monthFinishedValue_4546) != 0.00)
        //        {
        //            lblFinishValTotal_4546.Text = " \u20B9 " + dtitemMonthC4546_Total.Rows[0]["FinishedValue"].ToString() + " Cr.";
        //        }
        //        else
        //        {
        //            lblFinishValTotal_4546.Text = "";
        //        }
        //        //end of prabhaker coding

        //        if (pedPendingVal_fob_46C47total.ToString() != "0.00" && pedPendingVal_fob_46C47total.ToString() != "0")
        //        {
        //            lblShipedPendingValTotal_fob_4546.Text = " / " + pedPendingVal_fob_46C47total.ToString() == "0.00" ? "" : " / " + pedPendingVal_fob_46C47total + " %";
        //        }
        //        if (PenaltyValue_46C47total.ToString() != "0.00" && PenaltyValue_46C47total.ToString() != "0")
        //        {
        //            lblPenaltyPendingValTotal_fob_4546.Text = " \u20B9 " + PenaltyValue_46C47total.ToString() + " Lk";
        //        }


        //        //if ((CutQty46C47 != 0 & CutQty46C47 != 0.0) && (ShipeQty46C47 != 0 & ShipeQty46C47 != 0.0))
        //        //{
        //        //    string C46C47Ctsl = Math.Round(Convert.ToDouble((((CutQty46C47 - ShipeQty46C47)*100) / Convert.ToDouble(CutQty46C47))), 1, MidpointRounding.AwayFromZero).ToString();

        //        //    lblCtslTotal_4546.Text = C46C47Ctsl == "0" ? "" : "(" + C46C47Ctsl.ToString() + " % )"; ;
        //        //}
        //        //if ((CutQtyCtsl_46C47total != 0 & CutQtyCtsl_46C47total != 0.0) && (ShipeQty46C47 != 0 & ShipeQty46C47 != 0.0))
        //        //{
        //        //  string C46C47Ctsl = Math.Round(Convert.ToDouble((((CutQtyCtsl_46C47total - ShipeQty46C47) * 100) / Convert.ToDouble(CutQtyCtsl_46C47total))), 1, MidpointRounding.AwayFromZero).ToString();

        //        //  lblCtslTotal_4546.Text = C46C47Ctsl == "0" ? "" : C46C47Ctsl.ToString() + "%";
        //        //}
        //        ds = objadmin.get_ctsl(11);
        //        dt_CTSL = ds.Tables[0];
        //        if (Convert.ToInt32(dt_CTSL.Rows[0]["CTSL"]) > 0)
        //            lblCtslTotal_4546.Text = Convert.ToString(dt_CTSL.Rows[0]["CTSL"]) + " %";

        //        if (Convert.ToInt32(dt_CTSL.Rows[0]["RescanQty"]) > 0)
        //            lblCtslTotal_4546.Text = lblCtslTotal_4546.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(dt_CTSL.Rows[0]["RescanQty"].ToString()) + " </span>";

        //        //--------------------------------------BIPL-------------------------------------------------------------//

        //        Label lblutQtyTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblutQtyTotal_BIPL");
        //        Label lblstitchQtyTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblstitchQtyTotal_BIPL");
        //        Label lblFinishQtyTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblFinishQtyTotal_BIPL");
        //        Label lblShipedQtyTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedQtyTotal_BIPL");
        //        Label lblShipedValTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedValTotal_BIPL");
        //        Label lblCtslTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblCtslTotal_BIPL");
        //        Label lblShipedPendingQtyTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingQtyTotal_BIPL");
        //        Label lblShipedPendingValTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingValTotal_BIPL");
        //        Label lblShipedPendingValTotal_fob_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblShipedPendingValTotal_fob_BIPL");
        //        Label lblPenaltyPendingValTotal_fob_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblPenaltyPendingValTotal_fob_BIPL");

        //        Label lblstitchValTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblstitchValTotal_BIPL");
        //        Label lblFinishValTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblFinishvalTotal_BIPL");
        //        Label lblPendingStitchQtyTotal_BIPL = (Label)gridshipemtNew.FooterRow.FindControl("lblPendingStitchQtyTotal_BIPL");


        //        lblutQtyTotal_BIPL.Text = CutQtyBIPL == 0 ? "" : CutQtyBIPL.ToString() + " k " + SetMonthTotal(CutQtyBIPL);
        //        lblstitchQtyTotal_BIPL.Text = StitchQtyBIPL == 0 ? "" : StitchQtyBIPL.ToString() + " k " + SetMonthTotal_ForLastDay(StitchQtyBIPL); lblstitchQtyTotal_BIPL.ForeColor = Color.Black;
        //        lblFinishQtyTotal_BIPL.Text = FinishQtyBIPL == 0 ? "" : FinishQtyBIPL.ToString() + " k " + SetMonthTotal(FinishQtyBIPL);
        //        lblShipedQtyTotal_BIPL.Text = ShipeQtyBIPL == 0 ? "" : ShipeQtyBIPL.ToString() + " k "; ;
        //        lblShipedValTotal_BIPL.Text = ShipeValueBIPL == 0 ? "" : "/<span style='color:green;'> " + "\u20B9" + String.Format("{0:0.0}", ShipeValueBIPL) + " Cr" + "</span>";

        //        ds = objadmin.GetPreiousMonthRevenue(0);
        //        DataTable dtLastMonthRevnue_Total = ds.Tables[0];
        //        PendingStitchQtyTotal_BIPL = PendingStitchQtyTotal_BIPL + Convert.ToDouble(dtLastMonthRevnue_Total.Rows[0]["PreviusMonthUnshippedQty"]);
        //        PendingQtyBIPL = PendingQtyBIPL + Convert.ToDouble(dtLastMonthRevnue_Total.Rows[0]["PreviousMonthPendingOrderQty"]);
        //        pedPendingValBIPL = pedPendingValBIPL + Convert.ToDouble(dtLastMonthRevnue_Total.Rows[0]["PreviousRevenue"]);
        //        //lblCtslTotal_BIPL.Text = ctslBIPL == 0 ? "" : "(" + ctslBIPL.ToString() + " % )"; ;
        //        lblPendingStitchQtyTotal_BIPL.Text = PendingStitchQtyTotal_BIPL == 0 ? "" : Math.Round(Convert.ToDecimal(PendingStitchQtyTotal_BIPL.ToString()), MidpointRounding.AwayFromZero) + " k ";
        //        lblShipedPendingQtyTotal_BIPL.Text = PendingQtyBIPL == 0 ? "" : Math.Round(Convert.ToDecimal(PendingQtyBIPL.ToString()), MidpointRounding.AwayFromZero) + " k "; ;
        //        lblShipedPendingValTotal_BIPL.Text = pedPendingValBIPL == 0 ? "" : "<span style='color:green;'>" + "\u20B9" + pedPendingValBIPL.ToString() + " Cr" + "</span>";

        //        // prabhaker coding start here


        //        var monthStitchedValue_BIPL = dtitemMonthBipl_Total.Rows[0]["StitchedValue"];
        //        var monthFinishedValue_BIPL = dtitemMonthBipl_Total.Rows[0]["FinishedValue"];
        //        if (Convert.ToInt32(monthStitchedValue_BIPL) != 0.00)
        //        {
        //            lblstitchValTotal_BIPL.Text = " \u20B9 " + dtitemMonthBipl_Total.Rows[0]["StitchedValue"].ToString() + " Cr.";
        //        }
        //        else
        //        {
        //            lblstitchValTotal_BIPL.Text = "";
        //        }
        //        if (Convert.ToInt32(monthFinishedValue_BIPL) != 0.00)
        //        {
        //            lblFinishValTotal_BIPL.Text = " \u20B9 " + dtitemMonthBipl_Total.Rows[0]["FinishedValue"].ToString() + " Cr.";
        //        }
        //        else
        //        {
        //            lblFinishValTotal_4546.Text = "";
        //        }
        //        //end of prabhaker coding



        //        if (pedPendingVal_fob_BIPLtotal.ToString() != "0.00" && pedPendingVal_fob_BIPLtotal.ToString() != "0")
        //        {
        //            lblShipedPendingValTotal_fob_BIPL.Text = "/" + pedPendingVal_fob_BIPLtotal.ToString() == "0.00" ? "" : "/" + pedPendingVal_fob_BIPLtotal + " %";
        //        }

        //        if (PenaltyValue_BIPLtotal.ToString() != "0.00" && PenaltyValue_BIPLtotal.ToString() != "0")
        //        {
        //            lblPenaltyPendingValTotal_fob_BIPL.Text = " \u20B9 " + PenaltyValue_BIPLtotal.ToString() + " Lk";
        //        }

        //        //if ((CutQtyBIPL != 0 & CutQtyBIPL != 0.0) && (ShipeQtyBIPL != 0 & ShipeQtyBIPL != 0.0))
        //        //{
        //        //    string CbiplCtsl = Math.Round(Convert.ToDouble((((CutQtyBIPL - ShipeQtyBIPL)*100) / Convert.ToDouble(CutQtyBIPL))), 1, MidpointRounding.AwayFromZero).ToString();

        //        //    lblCtslTotal_BIPL.Text = CbiplCtsl == "0" ? "" : "(" + CbiplCtsl.ToString() + " % )"; ;
        //        //}

        //        //if ((CutQtyCtsl_BIPLtotal != 0 & CutQtyCtsl_BIPLtotal != 0.0) && (ShipeQtyBIPL != 0 & ShipeQtyBIPL != 0.0))
        //        //{
        //        //  string CbiplCtsl = Math.Round(Convert.ToDouble((((CutQtyCtsl_BIPLtotal - ShipeQtyBIPL) * 100) / Convert.ToDouble(CutQtyCtsl_BIPLtotal))), 1, MidpointRounding.AwayFromZero).ToString();

        //        //  lblCtslTotal_BIPL.Text = CbiplCtsl == "0" ? "" : CbiplCtsl.ToString() + "%"; ;
        //        //}

        //        ds = objadmin.get_ctsl(0);
        //        dt_CTSL = ds.Tables[0];
        //        if (Convert.ToInt32(dt_CTSL.Rows[0]["CTSL"]) > 0)
        //            lblCtslTotal_BIPL.Text = Convert.ToString(dt_CTSL.Rows[0]["CTSL"]) + " %";

        //        if (Convert.ToInt32(dt_CTSL.Rows[0]["RescanQty"]) > 0)
        //            lblCtslTotal_BIPL.Text = lblCtslTotal_BIPL.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(dt_CTSL.Rows[0]["RescanQty"].ToString()) + " </span>";

        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}
        public string Get(string value, int round = 0)
        {
            string result = "";
          
            decimal DivideByThousand = 1000M;
            value = value.Replace("k", "");
            if (Convert.ToDecimal(value) >= DivideByThousand)
            {
                //val = true;
                result = Math.Round(Convert.ToDouble(((Convert.ToDouble(value)) / Convert.ToDouble(DivideByThousand))), round, MidpointRounding.AwayFromZero).ToString() + " k";
            }
            else
            {
                result = value;
                //val = false;
            }
            return result;
        }
        public string Get_WithDecimal(string value, int round = 1)
        {
            string result = "";
           
            decimal DivideByThousand = 1000M;
            value = value.Replace("k", "");
            if (Convert.ToDecimal(value) >= DivideByThousand)
            {
               
                result = Math.Round(Convert.ToDouble(((Convert.ToDouble(value)) / Convert.ToDouble(DivideByThousand))), round, MidpointRounding.AwayFromZero).ToString() + " k";
            }
            else
            {
                result = value;
                
            }
            return result;
        }
        public string GetLastMonthPDY(string value, int round = 1)
        {
            string result = "";
            
            decimal DivideByThousand = 1000M;
            value = value.Replace("k", "");
            if (Convert.ToDecimal(value) >= DivideByThousand)
            {
                
                result = Math.Round(Convert.ToDouble(((Convert.ToDouble(value)) / Convert.ToDouble(DivideByThousand))), round, MidpointRounding.AwayFromZero).ToString() + " k";
            }
            else
            {
                result = value + " k";
                
            }
            return result;
        }
        public string GetValueDivideByThousand(string Value)
        {
            string Result = "0";
            if (Value != "" && Convert.ToDecimal(Value) > 0)
            {
                string val = ExtractHtmlInnerText(Value).Trim();
                decimal DivideByThousand = 1000M;

                if (Result != string.Empty)
                {
                    Result = Math.Round(Convert.ToDouble(((Convert.ToDouble(val)) / Convert.ToDouble(DivideByThousand))), 0).ToString();

                }
            }

            return Result;
        }
        public static string ExtractHtmlInnerText(string htmlText)
        {
            Regex regex = new Regex("(<.*?>\\s*)+", RegexOptions.Singleline);
            string resultText = regex.Replace(htmlText, " ").Replace("k", "").Replace("pdy", "").Trim();
            return resultText;
        }
        protected void BottomDataBind()
        {

            //-------------------------------------------C-47---------------------------------------------------------------------
            DataSet ds = new DataSet();
            DataSet dsMonthTotal = new DataSet();
            ds = objadmin.GetShipmentReportByValue(1, 1, 3);
            dsMonthTotal = objadmin.GetShipmentReport_MonthTotal();
            DataTable dtitem = new DataTable();
            DataTable dtMonthTotal = new DataTable();

            DataTable dtitemlastday = new DataTable();
            DataTable dtitemlastday_month = new DataTable();

            dtitem = ds.Tables[0];
            dtitemlastday = ds.Tables[1];
            dtitemlastday_month = ds.Tables[2];
            DataTable dtitemlastday_month_avg = ds.Tables[3];
            dtMonthTotal = dsMonthTotal.Tables[0];
            //--------------created by Prabhaker--------//               
            dtitemMonthC47_Total = ds.Tables[7];

            DataTable dtitemlastdaystitchv_month_val = ds.Tables[3];
            //----last three month-----//
            DataTable dtitemlastday_lastthree = new DataTable();
            DataTable dtavglastthree = new DataTable();
            //--------------created by Prabhaker--------//
            DataTable dtavglastthree_val = ds.Tables[5];
            //----last three month-----//
            dtitemlastday_lastthree = ds.Tables[4];
            dtavglastthree = ds.Tables[5];


            DataSet dswip = new DataSet();
            DataTable dtwip = new DataTable();

            DataSet dsPendingRescan = new DataSet();
            DataTable dtPendingRescan = new DataTable();

            //------------------------------------------Month Total-------------------------------------------------------

            lblCutQtyTotal_C47.Text = dtMonthTotal.Rows[0]["CutQty_C47"].ToString() + SetMonthTotal(Convert.ToDouble(dtMonthTotal.Rows[0]["CutQty_C47"].ToString().Replace("k", "")));
            lblCutQtyTotal_C45_46.Text = dtMonthTotal.Rows[0]["CutQty_C4546"].ToString() + SetMonthTotal(Convert.ToDouble(dtMonthTotal.Rows[0]["CutQty_C4546"].ToString().Replace("k", "")));
            lblCutQtyTotal_D69.Text = dtMonthTotal.Rows[0]["CutQty_D169"].ToString() + SetMonthTotal(Convert.ToDouble(dtMonthTotal.Rows[0]["CutQty_D169"].ToString().Replace("k", "")));
            // new unit c52 added
            //lblCutQtyTotal_C52.Text = dtMonthTotal.Rows[0]["CutQty_C52"].ToString() + SetMonthTotal(Convert.ToDouble(dtMonthTotal.Rows[0]["CutQty_C52"].ToString().Replace("k", "")));
            //lblCutQtyTotal_C52.Text = lblCutQtyTotal_C52.Text == "0" ? "" : lblCutQtyTotal_C52.Text;
            //
            lblCutQtyTotal_Bipl.Text = dtMonthTotal.Rows[0]["CutQty_Total"].ToString() + SetMonthTotal(Convert.ToDouble(dtMonthTotal.Rows[0]["CutQty_Total"].ToString().Replace("k", "")));
            lblstitchQtyTotal_47.Text = dtMonthTotal.Rows[0]["StichedQty_C47"].ToString() + SetMonthTotal(Convert.ToDouble(dtMonthTotal.Rows[0]["StichedQty_C47"].ToString().Replace("k", "")));
            lblstitchQtyTotal_C45_46.Text = dtMonthTotal.Rows[0]["StichedQty_C4546"].ToString() + SetMonthTotal(Convert.ToDouble(dtMonthTotal.Rows[0]["StichedQty_C4546"].ToString().Replace("k", "")));
            lblstitchQtyTotal_D69.Text = dtMonthTotal.Rows[0]["StichedQty_D169"].ToString() + SetMonthTotal(Convert.ToDouble(dtMonthTotal.Rows[0]["StichedQty_D169"].ToString().Replace("k", "")));
            // new unit c52 added
            //lblstitchQtyTotal_C52.Text = dtMonthTotal.Rows[0]["StichedQty_C52"].ToString() + SetMonthTotal(Convert.ToDouble(dtMonthTotal.Rows[0]["StichedQty_C52"].ToString().Replace("k", "")));
            //lblstitchQtyTotal_C52.Text = lblstitchQtyTotal_C52.Text == "0" ? "" : lblstitchQtyTotal_C52.Text;
            //
            lblstitchQtyTotal_Bipl.Text = dtMonthTotal.Rows[0]["StichedQty_Total"].ToString() + SetMonthTotal(Convert.ToDouble(dtMonthTotal.Rows[0]["StichedQty_Total"].ToString().Replace("k", "")));
            if (dtMonthTotal.Rows[0]["StichedValue_C47"].ToString() == "")
                lblstitchvalTotal_47.Text = "";
            else
                lblstitchvalTotal_47.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["StichedValue_C47"].ToString() + "</span>";

            if (dtMonthTotal.Rows[0]["StichedValue_C4546"].ToString() == "")
                lblstitchvalTotal_C45_46.Text = "";
            else
                lblstitchvalTotal_C45_46.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["StichedValue_C4546"].ToString() + "</span>";

            if (dtMonthTotal.Rows[0]["StichedValue_D169"].ToString() == "")
                lblstitchvalTotal_D69.Text = "";
            else
                lblstitchvalTotal_D69.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["StichedValue_D169"].ToString() + "</span>";

            // new unit c52 added
            //if (dtMonthTotal.Rows[0]["StichedValue_C52"].ToString() == "")
            //    lblstitchvalTotal_C52.Text = "";
            //else
            //    lblstitchvalTotal_C52.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["StichedValue_C52"].ToString() + "</span>";
            // END
            if (dtMonthTotal.Rows[0]["StichedValue_Total"].ToString() == "")
                lblstitchvalTotal_Bipl.Text = "";
            else
                lblstitchvalTotal_Bipl.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["StichedValue_Total"].ToString() + "</span>";

            lblFinishQtyTotal_47.Text = dtMonthTotal.Rows[0]["FinishedQty_C47"].ToString() + SetMonthTotal(Convert.ToDouble(dtMonthTotal.Rows[0]["FinishedQty_C47"].ToString().Replace("k", "")));
            lblFinishQtyTotal_C45_46.Text = dtMonthTotal.Rows[0]["FinishedQty_C4546"].ToString() + SetMonthTotal(Convert.ToDouble(dtMonthTotal.Rows[0]["FinishedQty_C4546"].ToString().Replace("k", "")));
            lblFinishQtyTotal_D69.Text = dtMonthTotal.Rows[0]["FinishedQty_D169"].ToString() + SetMonthTotal(Convert.ToDouble(dtMonthTotal.Rows[0]["FinishedQty_D169"].ToString().Replace("k", "")));
            // new unit c52 added
            //lblFinishQtyTotal_C52.Text = dtMonthTotal.Rows[0]["FinishedQty_C52"].ToString() + SetMonthTotal(Convert.ToDouble(dtMonthTotal.Rows[0]["FinishedQty_C52"].ToString().Replace("k", "")));
            // END
            lblFinishQtyTotal_Bipl.Text = dtMonthTotal.Rows[0]["FinishedQty_Total"].ToString() + SetMonthTotal(Convert.ToDouble(dtMonthTotal.Rows[0]["FinishedQty_Total"].ToString().Replace("k", "")));

            if (dtMonthTotal.Rows[0]["FinishedValue_C47"].ToString() == "")
                lblFinishValTotal_47.Text = "";
            else
                lblFinishValTotal_47.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["FinishedValue_C47"].ToString() + "</span>";

            if (dtMonthTotal.Rows[0]["FinishedValue_C4546"].ToString() == "")
                lblFinishValTotal_C45_46.Text = "";
            else
                lblFinishValTotal_C45_46.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["FinishedValue_C4546"].ToString() + "</span>";

            if (dtMonthTotal.Rows[0]["FinishedValue_D169"].ToString() == "")
                lblFinishValTotal_D69.Text = "";
            else
                lblFinishValTotal_D69.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["FinishedValue_D169"].ToString() + "</span>";

            // new unit C52 added
            //if (dtMonthTotal.Rows[0]["FinishedValue_C52"].ToString() == "")
            //    lblFinishValTotal_C52.Text = "";
            //else
            //    lblFinishValTotal_C52.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["FinishedValue_C52"].ToString() + "</span>";
            // END
            if (dtMonthTotal.Rows[0]["FinishedValue_Total"].ToString() == "")
                lblFinishValTotal_Bipl.Text = "";
            else
                lblFinishValTotal_Bipl.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["FinishedValue_Total"].ToString() + "</span>";
            if (dtMonthTotal.Rows[0]["ShippedQty_C47"].ToString() == "0")
                lblShipedQtyTotal_c47.Text = "";
            else
                lblShipedQtyTotal_c47.Text = dtMonthTotal.Rows[0]["ShippedQty_C47"].ToString();

            if (dtMonthTotal.Rows[0]["ShippedQty_C4546"].ToString() == "0")
                lblShipedQtyTotal_C45_46.Text = "";
            else
                lblShipedQtyTotal_C45_46.Text = dtMonthTotal.Rows[0]["ShippedQty_C4546"].ToString();

            if (dtMonthTotal.Rows[0]["ShippedQty_D169"].ToString() == "0")
                lblShipedQtyTotal_D69.Text = "";
            else
                lblShipedQtyTotal_D69.Text = dtMonthTotal.Rows[0]["ShippedQty_D169"].ToString();

            // new unit C52 added
            //if (dtMonthTotal.Rows[0]["ShippedQty_C52"].ToString() == "0")
            //    lblShipedQtyTotal_C52.Text = "";
            //else
            //    lblShipedQtyTotal_C52.Text = dtMonthTotal.Rows[0]["ShippedQty_C52"].ToString();
            // END
            if (dtMonthTotal.Rows[0]["ShippedQty_Total"].ToString() == "0")
                lblShipedQtyTotal_Bipl.Text = "";
            else
                lblShipedQtyTotal_Bipl.Text = dtMonthTotal.Rows[0]["ShippedQty_Total"].ToString();

            if (dtMonthTotal.Rows[0]["ShippedValue_C47"].ToString() == "")
                lblShipedValTotal_c47.Text = "";
            else
                lblShipedValTotal_c47.Text = "<span >/ &#8377;" + dtMonthTotal.Rows[0]["ShippedValue_C47"].ToString() + "</span>";

            if (dtMonthTotal.Rows[0]["ShippedValue_C4546"].ToString() == "")
                lblShipedValTotal_C45_46.Text = "";
            else
                lblShipedValTotal_C45_46.Text = "<span >/ &#8377;" + dtMonthTotal.Rows[0]["ShippedValue_C4546"].ToString() + "</span>";

            if (dtMonthTotal.Rows[0]["ShippedValue_D169"].ToString() == "")
                lblShipedValTotal_D69.Text = "";
            else
                lblShipedValTotal_D69.Text = "<span >/ &#8377;" + dtMonthTotal.Rows[0]["ShippedValue_D169"].ToString() + "</span>";

            // new unit C52 added
            //if (dtMonthTotal.Rows[0]["ShippedValue_C52"].ToString() == "")
            //    lblShipedValTotal_C52.Text = "";
            //else
            //    lblShipedValTotal_C52.Text = "<span >/ &#8377;" + dtMonthTotal.Rows[0]["ShippedValue_C52"].ToString() + "</span>";
            // END
            if (dtMonthTotal.Rows[0]["ShippedValue_Total"].ToString() == "")
                lblShipedValTotal_Bipl.Text = "";
            else
                lblShipedValTotal_Bipl.Text = "<span >/ &#8377;" + dtMonthTotal.Rows[0]["ShippedValue_Total"].ToString() + "</span>";

            if (dtMonthTotal.Rows[0]["Penalty_C47"].ToString() == "")
                lblPenaltyPendingValTotal_fob_c47.Text = "";
            else
                lblPenaltyPendingValTotal_fob_c47.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["Penalty_C47"].ToString() + "</span>";

            if (dtMonthTotal.Rows[0]["Penalty_C4546"].ToString() == "")
                lblPenaltyPendingValTotal_fob_C45_46.Text = "";
            else
                lblPenaltyPendingValTotal_fob_C45_46.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["Penalty_C4546"].ToString() + "</span>";

            if (dtMonthTotal.Rows[0]["Penalty_D169"].ToString() == "")
                lblPenaltyPendingValTotal_fob_D69.Text = "";
            else
                lblPenaltyPendingValTotal_fob_D69.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["Penalty_D169"].ToString() + "</span>";

            // new unit C52 added
            //if (dtMonthTotal.Rows[0]["Penalty_C52"].ToString() == "")
            //    lblPenaltyPendingValTotal_fob_C52.Text = "";
            //else
            //    lblPenaltyPendingValTotal_fob_C52.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["Penalty_C52"].ToString() + "</span>";
            // END
            if (dtMonthTotal.Rows[0]["Penalty_Total"].ToString() == "")
                lblPenaltyPendingValTotal_fob_Bipl.Text = "";
            else
                lblPenaltyPendingValTotal_fob_Bipl.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["Penalty_Total"].ToString() + "</span>";

            if (dtMonthTotal.Rows[0]["PercentFOB_C47"].ToString() == "")
            {
                lblShipedPendingValTotal_fob_c47.Text = "";
            }
            else
            {
                lblShipedPendingValTotal_fob_c47.Text = "/ " + dtMonthTotal.Rows[0]["PercentFOB_C47"].ToString();
                lblShipedPendingValTotal_fob_c47.Text = lblShipedPendingValTotal_fob_c47.Text == "/ 0.0" ? "" : lblShipedPendingValTotal_fob_c47.Text;
            }
            if (dtMonthTotal.Rows[0]["PercentFOB_C4546"].ToString() == "")
            {
                lblShipedPendingValTotal_fob_C45_46.Text = "";
            }
            else
            {
                lblShipedPendingValTotal_fob_C45_46.Text = "/ " + dtMonthTotal.Rows[0]["PercentFOB_C4546"].ToString();
                lblShipedPendingValTotal_fob_C45_46.Text = lblShipedPendingValTotal_fob_C45_46.Text == "/ 0.0" ? "" : lblShipedPendingValTotal_fob_C45_46.Text;
            }

            if (dtMonthTotal.Rows[0]["PercentFOB_D169"].ToString() == "")
                lblShipedPendingValTotal_fob_D69.Text = "";
            else
                lblShipedPendingValTotal_fob_D69.Text = "/ " + dtMonthTotal.Rows[0]["PercentFOB_D169"].ToString();

            // new unit C52 added
            //if (dtMonthTotal.Rows[0]["PercentFOB_C52"].ToString() == "")
            //    lblShipedPendingValTotal_fob_C52.Text = "";
            //else
            //    lblShipedPendingValTotal_fob_C52.Text = "/ " + dtMonthTotal.Rows[0]["PercentFOB_C52"].ToString();
            // END
            if (dtMonthTotal.Rows[0]["PercentFOB_Total"].ToString() == "")
            {
                lblShipedPendingValTotal_fob_Bipl.Text = "";
            }
            else
            {
                lblShipedPendingValTotal_fob_Bipl.Text = "/ " + dtMonthTotal.Rows[0]["PercentFOB_Total"].ToString();
                lblShipedPendingValTotal_fob_Bipl.Text = lblShipedPendingValTotal_fob_Bipl.Text == "/ 0.0" ? "" : lblShipedPendingValTotal_fob_Bipl.Text;
            }

            if (dtMonthTotal.Rows[0]["RescanPcs_C47"].ToString() == "0 k")
                lblCtslTotal_c47.Text = dtMonthTotal.Rows[0]["ctsl_C47"].ToString();
            else
                lblCtslTotal_c47.Text = dtMonthTotal.Rows[0]["ctsl_C47"].ToString() + " " + dtMonthTotal.Rows[0]["RescanPcs_C47"].ToString();

            if (dtMonthTotal.Rows[0]["RescanPcs_C4546"].ToString() == "0 k")
                lblCtslTotal_C45_46.Text = dtMonthTotal.Rows[0]["ctsl_C4546"].ToString();
            else
                lblCtslTotal_C45_46.Text = dtMonthTotal.Rows[0]["ctsl_C4546"].ToString() + " " + dtMonthTotal.Rows[0]["RescanPcs_C4546"].ToString();

            if (dtMonthTotal.Rows[0]["RescanPcs_D169"].ToString() == "0 k")
                lblCtslTotal_D69.Text = dtMonthTotal.Rows[0]["ctsl_D169"].ToString();
            else
                lblCtslTotal_D69.Text = dtMonthTotal.Rows[0]["ctsl_D169"].ToString() + " " + dtMonthTotal.Rows[0]["RescanPcs_D169"].ToString();

            // new unit C52 added
            //if (dtMonthTotal.Rows[0]["RescanPcs_C52"].ToString() == "0 k")
            //    lblCtslTotal_C52.Text = dtMonthTotal.Rows[0]["ctsl_C52"].ToString();
            //else
            //    lblCtslTotal_C52.Text = dtMonthTotal.Rows[0]["ctsl_C52"].ToString() + " " + dtMonthTotal.Rows[0]["RescanPcs_C52"].ToString();
            // END
            if (dtMonthTotal.Rows[0]["RescanPcs_Total"].ToString() == "0 k")
                lblCtslTotal_Bipl.Text = dtMonthTotal.Rows[0]["ctsl_Total"].ToString();
            else
                lblCtslTotal_Bipl.Text = dtMonthTotal.Rows[0]["ctsl_Total"].ToString() + " " + dtMonthTotal.Rows[0]["RescanPcs_Total"].ToString();

            if (dtMonthTotal.Rows[0]["Pending_StitchedQty_C47"].ToString() == "")
                lblPndStitchQty_Total_C47.Text = "";
            else
                lblPndStitchQty_Total_C47.Text = dtMonthTotal.Rows[0]["Pending_StitchedQty_C47"].ToString();

            if (dtMonthTotal.Rows[0]["Pending_StitchedQty_C4546"].ToString() == "")
                lblPndStitchQty_Total_C45_46.Text = "";
            else
                lblPndStitchQty_Total_C45_46.Text = dtMonthTotal.Rows[0]["Pending_StitchedQty_C4546"].ToString();

            if (dtMonthTotal.Rows[0]["Pending_StitchedQty_D169"].ToString() == "")
                lblPndStitchQty_Total_D69.Text = "";
            else
                lblPndStitchQty_Total_D69.Text = dtMonthTotal.Rows[0]["Pending_StitchedQty_D169"].ToString();

            // new unit C52 added
            //if (dtMonthTotal.Rows[0]["Pending_StitchedQty_C52"].ToString() == "")
            //    lblPndStitchQty_Total_C52.Text = "";
            //else
            //    lblPndStitchQty_Total_C52.Text = dtMonthTotal.Rows[0]["Pending_StitchedQty_C52"].ToString();
            // END
            if (dtMonthTotal.Rows[0]["Pending_StitchedQty_Total"].ToString() == "")
                lblPndStitchQty_Total_Bipl.Text = "";
            else
                lblPndStitchQty_Total_Bipl.Text = dtMonthTotal.Rows[0]["Pending_StitchedQty_Total"].ToString();

            if (dtMonthTotal.Rows[0]["Pending_ShippedQty_C47"].ToString() == "")
                lblShipedPendingQtyTotal_c47.Text = "";
            else
                lblShipedPendingQtyTotal_c47.Text = dtMonthTotal.Rows[0]["Pending_ShippedQty_C47"].ToString();

            if (dtMonthTotal.Rows[0]["Pending_ShippedQty_C4546"].ToString() == "")
                lblShipedPendingQtyTotal_C45_46.Text = "";
            else
                lblShipedPendingQtyTotal_C45_46.Text = dtMonthTotal.Rows[0]["Pending_ShippedQty_C4546"].ToString();

            if (dtMonthTotal.Rows[0]["Pending_ShippedQty_D169"].ToString() == "")
                lblShipedPendingQtyTotal_D69.Text = "";
            else
                lblShipedPendingQtyTotal_D69.Text = dtMonthTotal.Rows[0]["Pending_ShippedQty_D169"].ToString();

            // new unit C52 added
            //if (dtMonthTotal.Rows[0]["Pending_ShippedQty_C52"].ToString() == "")
            //    lblShipedPendingQtyTotal_C52.Text = "";
            //else
            //    lblShipedPendingQtyTotal_C52.Text = dtMonthTotal.Rows[0]["Pending_ShippedQty_C52"].ToString();
            // END
            if (dtMonthTotal.Rows[0]["Pending_ShippedQty_Total"].ToString() == "")
                lblShipedPendingQtyTotal_Bipl.Text = "";
            else
                lblShipedPendingQtyTotal_Bipl.Text = dtMonthTotal.Rows[0]["Pending_ShippedQty_Total"].ToString();

            if (dtMonthTotal.Rows[0]["PendingShippedValue_C47"].ToString() == "")
                lblShipedPendingValTotal_c47.Text = "";
            else
                lblShipedPendingValTotal_c47.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["PendingShippedValue_C47"].ToString() + "</span>";

            if (dtMonthTotal.Rows[0]["PendingShippedValue_C4546"].ToString() == "")
                lblShipedPendingValTotal_C45_46.Text = "";
            else
                lblShipedPendingValTotal_C45_46.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["PendingShippedValue_C4546"].ToString() + "</span>";

            if (dtMonthTotal.Rows[0]["PendingShippedValue_D169"].ToString() == "")
                lblShipedPendingValTotal_D69.Text = "";
            else
                lblShipedPendingValTotal_D69.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["PendingShippedValue_D169"].ToString() + "</span>";

            // new unit C52 added
            //if (dtMonthTotal.Rows[0]["PendingShippedValue_C52"].ToString() == "")
            //    lblShipedPendingValTotal_C52.Text = "";
            //else
            //    lblShipedPendingValTotal_C52.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["PendingShippedValue_C52"].ToString() + "</span>";
            // end
            if (dtMonthTotal.Rows[0]["PendingShippedValue_Total"].ToString() == "")
                lblShipedPendingValTotal_Bipl.Text = "";
            else
                lblShipedPendingValTotal_Bipl.Text = "<span >&#8377;" + dtMonthTotal.Rows[0]["PendingShippedValue_Total"].ToString() + "</span>";



            //------------------------------------Month Total End---------------------------------------------------------------
            //dswip = objadmin.GetWipDetails(3, "CUTWIP");
            dtwip = dsupcoming.Tables[3];

            if (dtitemlastday.Rows[0]["CutActual"].ToString() != "" && dtitemlastday.Rows[0]["CutActual"].ToString() != "0" && dtitemlastday.Rows[0]["CutActual"].ToString() != "0.0" && dtitemlastday.Rows[0]["CutActual"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday.Rows[0]["CutActual"].ToString()))
                {
                    //lbllastdayCutQty_C47.Text = dtitemlastday.Rows[0]["CutActual"].ToString() + " k";
                    lbllastdayCutQty_C47.Text = Get_WithDecimal(dtitemlastday.Rows[0]["CutActual"].ToString());
                }

            }

            if (dtitemlastday.Rows[0]["StitchQty"].ToString() != "" && dtitemlastday.Rows[0]["StitchQty"].ToString() != "0" && dtitemlastday.Rows[0]["StitchQty"].ToString() != "0.0" && dtitemlastday.Rows[0]["StitchQty"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday.Rows[0]["StitchQty"].ToString()))
                {
                    lblLastdayStitchQty_C47.Text = Get_WithDecimal(dtitemlastday.Rows[0]["StitchQty"].ToString());
                }
            }

            if (dtitemlastday.Rows[0]["Stitchedvalue"].ToString() != "" && dtitemlastday.Rows[0]["Stitchedvalue"].ToString() != "0" && dtitemlastday.Rows[0]["Stitchedvalue"].ToString() != "0.00" && dtitemlastday.Rows[0]["Stitchedvalue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday.Rows[0]["Stitchedvalue"].ToString()))
                    lblLastdayStitchval_C47.Text = " \u20B9 " + dtitemlastday.Rows[0]["Stitchedvalue"].ToString() + " Cr.";

            }

            if (dtitemlastday.Rows[0]["FinishQty"].ToString() != "" && dtitemlastday.Rows[0]["FinishQty"].ToString() != "0" && dtitemlastday.Rows[0]["FinishQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday.Rows[0]["FinishQty"].ToString()))
                {
                    lblLastdayFinish_C47.Text = Get_WithDecimal(dtitemlastday.Rows[0]["FinishQty"].ToString());
                }
            }


            if (dtitemlastday.Rows[0]["finishedvalue"].ToString() != "" && dtitemlastday.Rows[0]["finishedvalue"].ToString() != "0" && dtitemlastday.Rows[0]["finishedvalue"].ToString() != "0.00" && dtitemlastday.Rows[0]["finishedvalue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday.Rows[0]["finishedvalue"].ToString()))
                    lblLastdayFinishVal_C47.Text = " \u20B9 " + dtitemlastday.Rows[0]["finishedvalue"].ToString() + " Cr.";

            }

            if (dtitemlastday.Rows[0]["ShipQty"].ToString() != "" && dtitemlastday.Rows[0]["ShipQty"].ToString() != "0" && dtitemlastday.Rows[0]["ShipQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday.Rows[0]["ShipQty"].ToString()))
                {
                    llblLastdayShipQty_C47.Text = Get(dtitemlastday.Rows[0]["ShipQty"].ToString());

                }
            }
            if (dtitemlastday.Rows[0]["ShipedValue"].ToString() != "" && dtitemlastday.Rows[0]["ShipedValue"].ToString() != "0" && dtitemlastday.Rows[0]["ShipedValue"].ToString() != "0.0" && dtitemlastday.Rows[0]["ShipedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday.Rows[0]["ShipedValue"].ToString()))
                    llblLastdayShipValue_C47.Text = "/" + "<span style='color:green;'> " + "\u20B9 " + dtitemlastday.Rows[0]["ShipedValue"].ToString() + " Cr." + "</span>";

            }

            if (dtitemlastday.Rows[0]["PenaltyValue"].ToString() != "" && dtitemlastday.Rows[0]["PenaltyValue"].ToString() != "0" && dtitemlastday.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitemlastday.Rows[0]["PenaltyValue"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday.Rows[0]["PenaltyValue"].ToString()))
                    lbllastdayPenaltyValue_fob_C47.Text = "\u20B9 " + dtitemlastday.Rows[0]["PenaltyValue"].ToString() + " Lk /";

            }

            if (dtitemlastday.Rows[0]["PercentageFob"].ToString() != "" && dtitemlastday.Rows[0]["PercentageFob"].ToString() != "0" && dtitemlastday.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitemlastday.Rows[0]["PercentageFob"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday.Rows[0]["PercentageFob"].ToString()))
                    lbllastdaypendingShipvalue_fob_C47.Text = dtitemlastday.Rows[0]["PercentageFob"].ToString() + " %";

            }

            if (dtitemlastday.Rows[0]["ctsl"].ToString() != "" && dtitemlastday.Rows[0]["ctsl"].ToString() != "0" && dtitemlastday.Rows[0]["ctsl"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday.Rows[0]["ctsl"].ToString()))
                {
                    lblLastdayShipCtsl_C47.Text = dtitemlastday.Rows[0]["ctsl"].ToString() + "%";
                }
            }

            if (dtitemlastday.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemlastday.Rows[0]["PendingShipQty"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday.Rows[0]["PendingShipQty"].ToString()))
                {

                    lbllastdaypendingShipQty_C47.Text = Get_WithDecimal(dtitemlastday.Rows[0]["PendingShipQty"].ToString());
                }
            }

            if (dtitemlastday.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemlastday.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemlastday.Rows[0]["PendingShipValue"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday.Rows[0]["PendingShipValue"].ToString()))
                    lbllastdaypendingShipvalue_C47.Text = "<span style='color:green;'> \u20B9 " + dtitemlastday.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

            }
            //Last Month

            if (dtitemlastday_month.Rows[0]["CutActual"].ToString() != "" && dtitemlastday_month.Rows[0]["CutActual"].ToString() != "0" && dtitemlastday_month.Rows[0]["CutActual"].ToString() != "0.0" && dtitemlastday_month.Rows[0]["CutActual"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_month.Rows[0]["CutActual"].ToString()))
                {

                    lbllastdayCutQty_C47_month.Text = Get(dtitemlastday_month.Rows[0]["CutActual"].ToString());
                }
            }
            if (dtitemlastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "" && dtitemlastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "0" && dtitemlastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month_avg.Rows[0]["CutQtyavg"].ToString()))
                {
                    lbllastdayCutQty_C47_month_avg.Text = Get(dtitemlastday_month_avg.Rows[0]["CutQtyavg"].ToString()) + " k" + " <span style='font-size: 8px;color:Black;'>" + "pdy" + "</span>";
                    lbllastdayCutQty_C47_month_avg.ForeColor = Color.Black;
                }
            }
            if (dtitemlastday_month.Rows[0]["StitchQty"].ToString() != "" && dtitemlastday_month.Rows[0]["StitchQty"].ToString() != "0" && dtitemlastday_month.Rows[0]["StitchQty"].ToString() != "0.0" && dtitemlastday_month.Rows[0]["StitchQty"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_month.Rows[0]["StitchQty"].ToString()))
                {

                    lblLastdayStitchQty_C47_month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_month.Rows[0]["StitchQty"].ToString()).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";

                }
            }

            if (dtitemlastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "" && dtitemlastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "0" && dtitemlastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "0.0" && dtitemlastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_month_avg.Rows[0]["StitchQtyavg"].ToString()))
                {

                    lblLastdayStitchQty_C47_month_avg.Text = GetLastMonthPDY(dtitemlastday_month_avg.Rows[0]["StitchQtyavg"].ToString()) + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";


                }
            }

            if (dtitemlastdaystitchv_month_val.Rows[0]["StitchedValue"].ToString() != "" && dtitemlastdaystitchv_month_val.Rows[0]["StitchedValue"].ToString() != "0" && dtitemlastdaystitchv_month_val.Rows[0]["StitchedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastdaystitchv_month_val.Rows[0]["StitchedValue"].ToString()))
                    lblLastdayStitchval_C47_month.Text = " \u20B9 " + dtitemlastdaystitchv_month_val.Rows[0]["StitchedValue"].ToString() + " Cr.";

            }
            if (dtitemlastday_month.Rows[0]["FinishQty"].ToString() != "" && dtitemlastday_month.Rows[0]["FinishQty"].ToString() != "0" && dtitemlastday_month.Rows[0]["FinishQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month.Rows[0]["FinishQty"].ToString()))
                {
                    lblLastdayFinish_C47_month.Text = Get(dtitemlastday_month.Rows[0]["FinishQty"].ToString());
                }

            }
            if (dtitemlastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "" && dtitemlastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0" && dtitemlastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month_avg.Rows[0]["FinishQtyavg"].ToString()))
                {
                    //lblLastdayFinish_C47_month_avg.Text = dtitemlastday_month_avg.Rows[0]["FinishQtyavg"].ToString() + " k" + " <span style='font-size: 8px;color:Black;'>" + "pdy" + "</span>";
                    lblLastdayFinish_C47_month_avg.Text = GetLastMonthPDY(dtitemlastday_month_avg.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:Black;'>" + "pdy" + "</span>";
                    lblLastdayFinish_C47_month_avg.ForeColor = Color.Black;
                }
            }
            if (dtitemlastdaystitchv_month_val.Rows[0]["FinishedValue"].ToString() != "" && dtitemlastdaystitchv_month_val.Rows[0]["FinishedValue"].ToString() != "0" && dtitemlastdaystitchv_month_val.Rows[0]["FinishedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastdaystitchv_month_val.Rows[0]["FinishedValue"].ToString()))
                    lblLastdayFinishval_C47_month.Text = "<span style='color:green;'> " + "\u20B9 " + dtitemlastdaystitchv_month_val.Rows[0]["FinishedValue"].ToString() + " Cr." + "</span>";
            }
            if (dtitemlastday_month.Rows[0]["ShipQty"].ToString() != "" && dtitemlastday_month.Rows[0]["ShipQty"].ToString() != "0" && dtitemlastday_month.Rows[0]["ShipQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month.Rows[0]["ShipQty"].ToString()))
                {
                    //llblLastdayShipQty_C47_month.Text = dtitemlastday_month.Rows[0]["ShipQty"].ToString() + " k";                   
                    llblLastdayShipQty_C47_month.Text = Get(dtitemlastday_month.Rows[0]["ShipQty"].ToString());
                }
            }
            if (dtitemlastday_month.Rows[0]["ShipedValue"].ToString() != "" && dtitemlastday_month.Rows[0]["ShipedValue"].ToString() != "0" && dtitemlastday_month.Rows[0]["ShipedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month.Rows[0]["ShipedValue"].ToString()))
                    llblLastdayShipValue_C47_month.Text = "/ " + "<span style='color:green;'> " + "\u20B9 " + dtitemlastday_month.Rows[0]["ShipedValue"].ToString() + " Cr." + "</span>";

            }
            if (dtitemlastday_month.Rows[0]["PenaltyValue"].ToString() != "" && dtitemlastday_month.Rows[0]["PenaltyValue"].ToString() != "0" && dtitemlastday_month.Rows[0]["PenaltyValue"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_month.Rows[0]["PenaltyValue"].ToString()))
                    lbllastdayPenalty_fob_C47_month.Text = "\u20B9 " + dtitemlastday_month.Rows[0]["PenaltyValue"].ToString() + " Lk /";

            }
            if (dtitemlastday_month.Rows[0]["PercentageFob"].ToString() != "" && dtitemlastday_month.Rows[0]["PercentageFob"].ToString() != "0" && dtitemlastday_month.Rows[0]["PercentageFob"].ToString() != "0.00" && dtitemlastday_month.Rows[0]["PercentageFob"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month.Rows[0]["PercentageFob"].ToString()))
                    lbllastdaypendingShipvalue_fob_C47_month.Text = dtitemlastday_month.Rows[0]["PercentageFob"].ToString() + " %";
            }
            if (dtitemlastday_month.Rows[0]["ctsl"].ToString() != "" && dtitemlastday_month.Rows[0]["ctsl"].ToString() != "0" && dtitemlastday_month.Rows[0]["ctsl"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month.Rows[0]["ctsl"].ToString()))
                    lblLastdayShipCtsl_C47_month.Text = dtitemlastday_month.Rows[0]["ctsl"].ToString() + " %";
                if (Convert.ToInt32(dtitemlastday_month.Rows[0]["RescanQty"]) > 0)
                    lblLastdayShipCtsl_C47_month.Text = lblLastdayShipCtsl_C47_month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(dtitemlastday_month.Rows[0]["RescanQty"].ToString()) + " </span>";

            }
            if (dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_month.Rows[0]["PendingShipQty"].ToString()))
                {
                    //lbllastdaypendingShipQty_C47_month.Text = dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() + " k";   
                    lbllastdaypendingShipQty_C47_month.Text = Get(dtitemlastday_month.Rows[0]["PendingShipQty"].ToString());
                }
            }
            if (dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month.Rows[0]["PendingShipValue"].ToString()))
                    lbllastdaypendingShipvalue_C47_month.Text = "<span style='color:green;'> \u20B9 " + dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

            }

            //last three month===========================================================//
            if (dtitemlastday_lastthree.Rows[0]["CutActual"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["CutActual"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["CutActual"].ToString() != "0.0")
            {

                if (Math.Round(Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["CutActual"].ToString()), MidpointRounding.AwayFromZero) > 0)
                {
                    lbllastdayCutQty_C47_3month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_lastthree.Rows[0]["CutActual"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";
                }
            }
            if (dtavglastthree.Rows[0]["CutQtyavg"].ToString() != "" && dtavglastthree.Rows[0]["CutQtyavg"].ToString() != "0" && dtavglastthree.Rows[0]["CutQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtavglastthree.Rows[0]["CutQtyavg"].ToString()))
                {
                    lbllastdayCutQty_C47_3month_avg.Text = GetLastMonthPDY(dtavglastthree.Rows[0]["CutQtyavg"].ToString()) + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
                }
            }
            if (dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString() != "0.0")
            {

                if (CheckZero(dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString()))
                {
                    if (Math.Round(Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
                    {

                        lblLastdayStitchQty_C47_3month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";


                    }
                }
            }
            if (dtavglastthree.Rows[0]["StitchQtyavg"].ToString() != "" && dtavglastthree.Rows[0]["StitchQtyavg"].ToString() != "0" && dtavglastthree.Rows[0]["StitchQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtavglastthree.Rows[0]["StitchQtyavg"].ToString()))
                {
                    lblLastdayStitchQty_C47_3month_avg.Text = Get(dtavglastthree.Rows[0]["StitchQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
                }
            }
            if (dtavglastthree_val.Rows[0]["StitchedValue"].ToString() != "" && dtavglastthree_val.Rows[0]["StitchedValue"].ToString() != "0" && dtavglastthree_val.Rows[0]["StitchedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtavglastthree_val.Rows[0]["StitchedValue"].ToString()))
                    lblLastdayStitchval_C47_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtavglastthree_val.Rows[0]["StitchedValue"].ToString() + " Cr." + "</span>";

            }
            if (dtitemlastday_lastthree.Rows[0]["FinishQty"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["FinishQty"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["FinishQty"].ToString() != "0.0")
            {
                if (Math.Round(Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["FinishQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
                {

                    lblLastdayFinish_C47_3month.Text = Get(dtitemlastday_lastthree.Rows[0]["FinishQty"].ToString());

                }
            }
            if (dtavglastthree.Rows[0]["FinishQtyavg"].ToString() != "" && dtavglastthree.Rows[0]["FinishQtyavg"].ToString() != "0" && dtavglastthree.Rows[0]["FinishQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtavglastthree.Rows[0]["FinishQtyavg"].ToString()))
                {
                    //lblLastdayFinish_C47_3month_avg.Text = dtavglastthree.Rows[0]["FinishQtyavg"].ToString() + " k" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
                    lblLastdayFinish_C47_3month_avg.Text = Get(dtavglastthree.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
                    lblLastdayFinish_C47_3month_avg.ForeColor = Color.Black;
                }

            }
            if (dtavglastthree_val.Rows[0]["FinishedValue"].ToString() != "" && dtavglastthree_val.Rows[0]["FinishedValue"].ToString() != "0" && dtavglastthree_val.Rows[0]["FinishedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtavglastthree_val.Rows[0]["FinishedValue"].ToString()))
                {

                    lblLastdayFinishval_C47_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtavglastthree_val.Rows[0]["FinishedValue"].ToString() + " Cr." + "</span>";
                }
            }
            if (dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString() != "0.0" && dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString() != "0.0")
            {
                if (Math.Round((Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString()) / 3), MidpointRounding.AwayFromZero) > 0)
                {
                    llblLastdayShipQty_C47_3month.Text = Math.Round((Convert.ToDecimal(Get(dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString()).Replace("k", "")) / 3), MidpointRounding.AwayFromZero) + " k";

                }
            }
            if (dtitemlastday_lastthree.Rows[0]["ShipedValue"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["ShipedValue"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["ShipedValue"].ToString() != "0.0" && dtitemlastday_lastthree.Rows[0]["ShipedValue"].ToString() != "0.0")
            {

                if (CheckZero(dtitemlastday_lastthree.Rows[0]["ShipedValue"].ToString()))
                {
                    if (Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["ShipedValue"].ToString()) / 3 > 0)
                    {
                        llblLastdayShipValue_C47_3month.Text = "/ " + "<span style='color:green;'> " + "\u20B9 " + Math.Round(Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["ShipedValue"].ToString()) / 3, 1) + " Cr." + "</span>";
                    }
                }
            }
            if (dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString()))
                {
                    if ((Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString()) / 3) > 0)
                    {
                        lbllast_threeMonth_Penalty_fob_C47_3month.Text = "\u20B9 " + Math.Round((Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString()) / 3), 1) + " Lk /";
                    }
                }

            }
            if (dtitemlastday_lastthree.Rows[0]["PercentageFob"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["PercentageFob"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitemlastday_lastthree.Rows[0]["PercentageFob"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_lastthree.Rows[0]["PercentageFob"].ToString()))
                    lbllastdaypendingShipvalue_fob_C47_3month.Text = dtitemlastday_lastthree.Rows[0]["PercentageFob"].ToString() + " %";

            }
            if (dtitemlastday_lastthree.Rows[0]["ctsl"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["ctsl"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["ctsl"].ToString() != "0.0" && dtitemlastday_lastthree.Rows[0]["ctsl"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_lastthree.Rows[0]["ctsl"].ToString()))
                    lblLastdayShipCtsl_C47_3month.Text = dtitemlastday_lastthree.Rows[0]["ctsl"].ToString() + " %";
                if (Convert.ToInt32(dtitemlastday_lastthree.Rows[0]["RescanQty"]) > 0)
                {
                    string RescanQty = Math.Round(Convert.ToDouble(((Convert.ToDouble(dtitemlastday_lastthree.Rows[0]["RescanQty"].ToString())) / Convert.ToDouble(3))), 0, MidpointRounding.AwayFromZero).ToString();
                    lblLastdayShipCtsl_C47_3month.Text = lblLastdayShipCtsl_C47_3month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(RescanQty) + " </span>";
                }
            }
            if (dtitemlastday_lastthree.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemlastday_lastthree.Rows[0]["PendingShipQty"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_lastthree.Rows[0]["PendingShipQty"].ToString()))
                {
                    lbllastdaypendingShipQty_C47_3month.Text = GetLastMonthPDY(dtitemlastday_lastthree.Rows[0]["PendingShipQty"].ToString());
                }
            }
            if (dtitemlastday_lastthree.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemlastday_lastthree.Rows[0]["PendingShipValue"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_lastthree.Rows[0]["PendingShipValue"].ToString()))
                    lbllastdaypendingShipvalue_C47_3month.Text = "<span style='color:green;'> \u20B9 " + dtitemlastday_lastthree.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

            }
            //if (dtwip.Rows[0]["CutWip_k"].ToString() != "" && dtwip.Rows[0]["CutWip_k"].ToString() != "0" && dtwip.Rows[0]["CutWip_k"].ToString() != "0.00")
            //{
            //    if (Math.Round(Convert.ToDecimal(CheckZero(dtwip.Rows[0]["CutWip_k"].ToString())), 0) > 0)
            //    {
            lblwipcutC47_K.Text = dtwip.Rows[0]["CutWIPPcs_C47"].ToString();
            //    }
            //}
            //if (dtwip.Rows[0]["CutWip"].ToString() != "" && dtwip.Rows[0]["CutWip"].ToString() != "0" && dtwip.Rows[0]["CutWip"].ToString() != "0.00")
            //{
            //if (CheckZero(dtwip.Rows[0]["CutWip"].ToString()))
            // lblwipcutC47.Text = dtwip.Rows[0]["CutWIPPcs_C47"].ToString(); //+ " <span style='font-size: 8px;'>" + "D" + "</span>";

            //}

            //dswip = objadmin.GetWipDetails(3, "STITCHWIP");
            //dtwip = dswip.Tables[0];
            //if (dtwip.Rows[0]["StitchWip_k"].ToString() != "" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtwip.Rows[0]["StitchWip_k"].ToString()))
            //    {
            lblwipstitchC47_K.Text = dtwip.Rows[0]["StitchWIPPcs_C47"].ToString();
            //    }
            //}
            //if (dtwip.Rows[0]["StitchWip"].ToString() != "" && dtwip.Rows[0]["StitchWip"].ToString() != "0" && dtwip.Rows[0]["StitchWip"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtwip.Rows[0]["StitchWip"].ToString()))
            //        lblwipstitchC47.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["StitchWip"].ToString()), 0) + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
            //}
            //dswip = objadmin.GetWipDetails(3, "FINISHWIP");
            //dtwip = dswip.Tables[0];
            //if (dtwip.Rows[0]["FinishWip_k"].ToString() != "" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtwip.Rows[0]["FinishWip_k"].ToString()))
            //    {
            lblwipfinishC47_K.Text = dtwip.Rows[0]["PackWIPPcs_C47"].ToString();
            //    }
            //}
            dsPendingRescan = objadmin.GetWipDetails(3, "PENDING_RESCAN");
            dtPendingRescan = dsPendingRescan.Tables[0];
            if (dtPendingRescan.Rows[0]["RescanValue"].ToString() != "" && dtPendingRescan.Rows[0]["RescanValue"].ToString() != "0" && dtPendingRescan.Rows[0]["RescanValue"].ToString() != "0.00")
            {
                if (CheckZero(dtPendingRescan.Rows[0]["RescanValue"].ToString()))
                {
                    lblPendingRescanC47_k.Text = Get(dtPendingRescan.Rows[0]["RescanValue"].ToString()) + " <span style='color:red; font-size: 8px;'>" + "" + "</span>";
                }
            }
            //if (dtwip.Rows[0]["FinishWip"].ToString() != "" && dtwip.Rows[0]["FinishWip"].ToString() != "0" && dtwip.Rows[0]["FinishWip"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtwip.Rows[0]["FinishWip"].ToString()))
            //    {
            //        // lblwipfinishC47.Text = dtwip.Rows[0]["FinishWip"].ToString() + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
            //        if (Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()) > 2)
            //        {
            //            lblwipfinishC47.Text = " <span style='font-weight: bold;color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D" + "</span>";
            //        }
            //        else
            //        {
            //            lblwipfinishC47.Text = " <span style='color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D" + "</span>";
            //        }
            //    }
            //}

            //---------------------------end--------------------------------------------------------------------------------------
            //-------------------------------------------C-45/46---------------------------------------------------------------------

            DataSet ds4546 = new DataSet();
            ds4546 = objadmin.GetShipmentReportByValue(1, 1, 11);

            DataTable dtitem4645 = new DataTable();
            DataTable dtitem4645lastday = new DataTable();
            DataTable dtitem4645lastday_month = new DataTable();
            dtitemMonthC4546_Total = ds4546.Tables[7];

            dtitem4645 = ds4546.Tables[0];
            dtitem4645lastday = ds4546.Tables[1];
            dtitem4645lastday_month = ds4546.Tables[2];
            DataTable dtitem4645lastday_month_avg = ds4546.Tables[3];
            DataTable dtitem4645lastday_month_val = ds4546.Tables[3];



            //last three month=================//

            DataTable dtlastthree_month = new DataTable();
            DataTable dtlastthree_monthavg = new DataTable();
            DataTable dtlastthree_monthval = new DataTable();
            dtlastthree_month = ds4546.Tables[4];
            dtlastthree_monthavg = ds4546.Tables[5];
            dtlastthree_monthval = ds4546.Tables[5];

            if (dtitem4645lastday.Rows[0]["CutActual"].ToString() != "" && dtitem4645lastday.Rows[0]["CutActual"].ToString() != "0" && dtitem4645lastday.Rows[0]["CutActual"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday.Rows[0]["CutActual"].ToString()))
                {

                    lbllastCutQty_C4647.Text = Get_WithDecimal(dtitem4645lastday.Rows[0]["CutActual"].ToString());
                }
            }

            if (dtitem4645lastday.Rows[0]["StitchQty"].ToString() != "" && dtitem4645lastday.Rows[0]["StitchQty"].ToString() != "0" && dtitem4645lastday.Rows[0]["StitchQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday.Rows[0]["StitchQty"].ToString()))
                {

                    lbllastStichedQty_C4647.Text = Get_WithDecimal(dtitem4645lastday.Rows[0]["StitchQty"].ToString());
                }
            }
            if (dtitem4645lastday.Rows[0]["Stitchedvalue"].ToString() != "" && dtitem4645lastday.Rows[0]["Stitchedvalue"].ToString() != "0" && dtitem4645lastday.Rows[0]["Stitchedvalue"].ToString() != "0.00")
            {
                if (CheckZero(dtitem4645lastday.Rows[0]["Stitchedvalue"].ToString()))
                    lbllastStichedVal_C4647.Text = "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday.Rows[0]["Stitchedvalue"].ToString() + " Cr." + "</span>";


            }
            if (dtitem4645lastday.Rows[0]["FinishQty"].ToString() != "" && dtitem4645lastday.Rows[0]["FinishQty"].ToString() != "0" && dtitem4645lastday.Rows[0]["FinishQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday.Rows[0]["FinishQty"].ToString()))
                {

                    lbllastFinishQty_C4647.Text = Get_WithDecimal(dtitem4645lastday.Rows[0]["FinishQty"].ToString());
                }
            }
            if (dtitem4645lastday.Rows[0]["finishedvalue"].ToString() != "" && dtitem4645lastday.Rows[0]["finishedvalue"].ToString() != "0" && dtitem4645lastday.Rows[0]["finishedvalue"].ToString() != "0.00")
            {
                if (CheckZero(dtitem4645lastday.Rows[0]["finishedvalue"].ToString()))
                    lbllastFinishVal_C4647.Text = "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday.Rows[0]["finishedvalue"].ToString() + " Cr." + "</span>";


            }
            if (dtitem4645lastday.Rows[0]["ShipQty"].ToString() != "" && dtitem4645lastday.Rows[0]["ShipQty"].ToString() != "0" && dtitem4645lastday.Rows[0]["ShipQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday.Rows[0]["ShipQty"].ToString()))
                {

                    lbllastdayshipQty_C4647.Text = Get(dtitem4645lastday.Rows[0]["ShipQty"].ToString());
                }
            }
            if (dtitem4645lastday.Rows[0]["ShipedValue"].ToString() != "" && dtitem4645lastday.Rows[0]["ShipedValue"].ToString() != "0" && dtitem4645lastday.Rows[0]["ShipedValue"].ToString() != "0.0" && dtitem4645lastday.Rows[0]["ShipedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday.Rows[0]["ShipedValue"].ToString()))
                {
                    lbllastdaysShipVal_C4647.Text = "/" + "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday.Rows[0]["ShipedValue"].ToString() + " Cr." + "</span>";
                }

            }
            if (dtitem4645lastday.Rows[0]["PenaltyValue"].ToString() != "" && dtitem4645lastday.Rows[0]["PenaltyValue"].ToString() != "0" && dtitem4645lastday.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitem4645lastday.Rows[0]["PenaltyValue"].ToString() != "0.00")
            {
                if (CheckZero(dtitem4645lastday.Rows[0]["PenaltyValue"].ToString()))
                    lbllastdayPenaltyValue_fob_C4647.Text = "\u20B9 " + dtitem4645lastday.Rows[0]["PenaltyValue"].ToString() + " Lk /";
            }
            if (dtitem4645lastday.Rows[0]["PercentageFob"].ToString() != "" && dtitem4645lastday.Rows[0]["PercentageFob"].ToString() != "0" && dtitem4645lastday.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitem4645lastday.Rows[0]["PercentageFob"].ToString() != "0.00")
            {
                if (CheckZero(dtitem4645lastday.Rows[0]["PercentageFob"].ToString()))
                    lbllastdayPendingShipedVal_fob_C4647.Text = dtitem4645lastday.Rows[0]["PercentageFob"].ToString() + " %";
            }
            if (dtitem4645lastday.Rows[0]["ctsl"].ToString() != "" && dtitem4645lastday.Rows[0]["ctsl"].ToString() != "0" && dtitem4645lastday.Rows[0]["ctsl"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday.Rows[0]["ctsl"].ToString()))
                {
                    lbllastdaysShipCtsl_C4647.Text = dtitem4645lastday.Rows[0]["ctsl"].ToString() + "%";
                }
            }
            if (dtitem4645lastday.Rows[0]["PendingShipQty"].ToString() != "" && dtitem4645lastday.Rows[0]["ctsl"].ToString() != "0" && dtitem4645lastday.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitem4645lastday.Rows[0]["PendingShipQty"].ToString() != "0.00")
            {
                if (CheckZero(dtitem4645lastday.Rows[0]["PendingShipQty"].ToString()))
                {

                    lbllastdayPendingShipedQty_C4647.Text = Get(dtitem4645lastday.Rows[0]["PendingShipQty"].ToString());
                }
            }
            if (dtitem4645lastday.Rows[0]["PendingShipValue"].ToString() != "" && dtitem4645lastday.Rows[0]["PendingShipValue"].ToString() != "0" && dtitem4645lastday.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitem4645lastday.Rows[0]["PendingShipValue"].ToString() != "0.00")
            {
                if (CheckZero(dtitem4645lastday.Rows[0]["PendingShipValue"].ToString()))
                {
                    lbllastdayPendingShipedVal_C4647.Text = "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";
                }

            }

            if (dtitem4645lastday_month.Rows[0]["CutActual"].ToString() != "" && dtitem4645lastday_month.Rows[0]["CutActual"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["CutActual"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday_month.Rows[0]["CutActual"].ToString()))
                    lbllastCutQty_C4647_month.Text = Get(dtitem4645lastday_month.Rows[0]["CutActual"].ToString());

            }
            if (dtitem4645lastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "" && dtitem4645lastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "0" && dtitem4645lastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday_month_avg.Rows[0]["CutQtyavg"].ToString()))
                {
                    lbllastCutQty_C4647_month_avg.Text = GetLastMonthPDY(dtitem4645lastday_month_avg.Rows[0]["CutQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:Black;'>" + "pdy" + "</span>";
                    lbllastCutQty_C4647_month_avg.ForeColor = Color.Black;
                }
            }
            if (dtitem4645lastday_month.Rows[0]["StitchQty"].ToString() != "" && dtitem4645lastday_month.Rows[0]["StitchQty"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["StitchQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday_month.Rows[0]["StitchQty"].ToString()))
                    //lbllastStichedQty_C4647_month.Text = Math.Round(Convert.ToDecimal(dtitem4645lastday_month.Rows[0]["StitchQty"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k";
                    lbllastStichedQty_C4647_month.Text = Math.Round(Convert.ToDecimal(Get(dtitem4645lastday_month.Rows[0]["StitchQty"].ToString().Replace("k", "")).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";

            }
            //last month====avg
            if (dtitem4645lastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "" && dtitem4645lastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "0" && dtitem4645lastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday_month_avg.Rows[0]["StitchQtyavg"].ToString()))
                {
                    // lbllastStichedQty_C4647_month_avg.Text = dtitem4645lastday_month_avg.Rows[0]["StitchQtyavg"].ToString() + " k" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
                    lbllastStichedQty_C4647_month_avg.Text = GetLastMonthPDY(dtitem4645lastday_month_avg.Rows[0]["StitchQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
                }
            }
            if (dtitem4645lastday_month_val.Rows[0]["StitchedValue"].ToString() != "" && dtitem4645lastday_month_val.Rows[0]["StitchedValue"].ToString() != "0" && dtitem4645lastday_month_val.Rows[0]["StitchedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday_month_val.Rows[0]["StitchedValue"].ToString()))
                    lbllastStichedval_C4647_month.Text = "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday_month_val.Rows[0]["StitchedValue"].ToString() + " Cr." + "</span>";

            }
            if (dtitem4645lastday_month.Rows[0]["FinishQty"].ToString() != "" && dtitem4645lastday_month.Rows[0]["FinishQty"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["FinishQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday_month.Rows[0]["FinishQty"].ToString()))
                {
                    lbllastFinishQty_C4647_month.Text = Math.Round(Convert.ToDecimal(Get(dtitem4645lastday_month.Rows[0]["FinishQty"].ToString().Replace("k", "")).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";
                }
            }
            if (dtitem4645lastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "" && dtitem4645lastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0" && dtitem4645lastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday_month_avg.Rows[0]["FinishQtyavg"].ToString()))
                {
                    lbllastFinishQty_C4647_month_avg.Text = GetLastMonthPDY(dtitem4645lastday_month_avg.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:Black;'>" + "pdy" + "</span>";
                    lbllastFinishQty_C4647_month_avg.ForeColor = Color.Black;
                }
            }
            if (dtitem4645lastday_month_val.Rows[0]["FinishedValue"].ToString() != "" && dtitem4645lastday_month_val.Rows[0]["FinishedValue"].ToString() != "0" && dtitem4645lastday_month_val.Rows[0]["FinishedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday_month_val.Rows[0]["FinishedValue"].ToString()))
                    lbllastFinishval_C4647_month.Text = "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday_month_val.Rows[0]["FinishedValue"].ToString() + " Cr." + "</span>";

            }
            if (dtitem4645lastday_month.Rows[0]["ShipQty"].ToString() != "" && dtitem4645lastday_month.Rows[0]["ShipQty"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["ShipQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday_month.Rows[0]["ShipQty"].ToString()))
                {
                    lbllastdayshipQty_C4647_month.Text = Get(dtitem4645lastday_month.Rows[0]["ShipQty"].ToString());
                }

            }
            if (dtitem4645lastday_month.Rows[0]["ShipedValue"].ToString() != "" && dtitem4645lastday_month.Rows[0]["ShipedValue"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["ShipedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday_month.Rows[0]["ShipedValue"].ToString()))
                {
                    lbllastdaysShipVal_C4647_month.Text = "/" + "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday_month.Rows[0]["ShipedValue"].ToString() + " Cr." + "</span>";
                }

            }
            if (dtitem4645lastday_month.Rows[0]["PenaltyValue"].ToString() != "" && dtitem4645lastday_month.Rows[0]["PenaltyValue"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitem4645lastday_month.Rows[0]["PenaltyValue"].ToString() != "0.00")
            {
                if (CheckZero(dtitem4645lastday_month.Rows[0]["PenaltyValue"].ToString()))
                    lbllastdayPenalty_fob_C4647_month.Text = "\u20B9 " + Math.Round(Convert.ToDecimal(dtitem4645lastday_month.Rows[0]["PenaltyValue"].ToString()) / 3, 1) + " Lk /";

            }
            if (dtitem4645lastday_month.Rows[0]["PercentageFob"].ToString() != "" && dtitem4645lastday_month.Rows[0]["PercentageFob"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitem4645lastday_month.Rows[0]["PercentageFob"].ToString() != "0.00")
            {
                if (CheckZero(dtitem4645lastday_month.Rows[0]["PercentageFob"].ToString()))
                    lbllastdayPendingShipedVal_fob_C4647_month.Text = dtitem4645lastday_month.Rows[0]["PercentageFob"].ToString() + " %";

            }
            if (dtitem4645lastday_month.Rows[0]["ctsl"].ToString() != "" && dtitem4645lastday_month.Rows[0]["ctsl"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["ctsl"].ToString() != "0.0")
            {
                if (CheckZero(dtitem4645lastday_month.Rows[0]["ctsl"].ToString()))
                {
                    lbllastdaysShipCtsl_C4647_month.Text = dtitem4645lastday_month.Rows[0]["ctsl"].ToString() + " %";
                    if (Convert.ToInt32(dtitem4645lastday_month.Rows[0]["RescanQty"]) > 0)
                        lbllastdaysShipCtsl_C4647_month.Text = lbllastdaysShipCtsl_C4647_month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(dtitem4645lastday_month.Rows[0]["RescanQty"].ToString()) + " </span>";

                }

            }
            if (dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() != "" && dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() != "0.00")
            {
                if (CheckZero(dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString()))
                {
                    lbllastdayPendingShipedQty_C4647_month.Text = Get(dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString());
                }
            }
            if (dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() != "" && dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() != "0.00")
            {
                if (CheckZero(dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString()))
                    lbllastdayPendingShipedVal_C4647_month.Text = "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

            }

            //last three month=================================================
            if (dtlastthree_month.Rows[0]["CutActual"].ToString() != "" && dtlastthree_month.Rows[0]["CutActual"].ToString() != "0" && dtlastthree_month.Rows[0]["CutActual"].ToString() != "0.0")
            {
                if (CheckZero(dtlastthree_month.Rows[0]["CutActual"].ToString()))
                {
                    if (Math.Round(Convert.ToDecimal(dtlastthree_month.Rows[0]["CutActual"].ToString()), MidpointRounding.AwayFromZero) > 0)
                    {
                        lbllastCutQty_C4647_3month.Text = Math.Round(Convert.ToDecimal(Get(dtlastthree_month.Rows[0]["CutActual"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";
                    }
                }
            }
            if (dtlastthree_monthavg.Rows[0]["CutQtyavg"].ToString() != "" && dtlastthree_monthavg.Rows[0]["CutQtyavg"].ToString() != "0" && dtlastthree_monthavg.Rows[0]["CutQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtlastthree_monthavg.Rows[0]["CutQtyavg"].ToString()))
                {
                    lbllastCutQty_C4647_3month_avg.Text = Get(dtlastthree_monthavg.Rows[0]["CutQtyavg"].ToString()) + "" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
                }
            }
            if (dtlastthree_month.Rows[0]["StitchQty"].ToString() != "" && dtlastthree_month.Rows[0]["StitchQty"].ToString() != "0" && dtlastthree_month.Rows[0]["StitchQty"].ToString() != "0.0")
            {
                if (Math.Round(Convert.ToDecimal(dtlastthree_month.Rows[0]["StitchQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
                {
                    lbllastStichedQty_C4647_3month.Text = Math.Round(Convert.ToDecimal(Get(dtlastthree_month.Rows[0]["StitchQty"].ToString().Replace("k", "")).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";

                }

            }
            if (dtlastthree_monthavg.Rows[0]["StitchQtyavg"].ToString() != "" && dtlastthree_monthavg.Rows[0]["StitchQtyavg"].ToString() != "0" && dtlastthree_monthavg.Rows[0]["StitchQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtlastthree_monthavg.Rows[0]["StitchQtyavg"].ToString()))
                {
                    lbllastStichedQty_C4647_3month_avg.Text = Get(dtlastthree_monthavg.Rows[0]["StitchQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
                }
            }
            if (dtlastthree_monthval.Rows[0]["StitchedValue"].ToString() != "" && dtlastthree_monthval.Rows[0]["StitchedValue"].ToString() != "0" && dtlastthree_monthval.Rows[0]["StitchedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtlastthree_monthval.Rows[0]["StitchedValue"].ToString()))
                    lbllastStichedval_C4647_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtlastthree_monthval.Rows[0]["StitchedValue"].ToString() + " Cr." + "</span>";

            }
            if (dtlastthree_month.Rows[0]["FinishQty"].ToString() != "" && dtlastthree_month.Rows[0]["FinishQty"].ToString() != "0" && dtlastthree_month.Rows[0]["FinishQty"].ToString() != "0.0")
            {
                if (Math.Round(Convert.ToDecimal(dtlastthree_month.Rows[0]["FinishQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
                {
                    lbllastFinishQty_C4647_3month.Text = Math.Round(Convert.ToDecimal(Get(dtlastthree_month.Rows[0]["FinishQty"].ToString().Replace("k", "")).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";
                }

            }
            if (dtlastthree_monthavg.Rows[0]["FinishQtyavg"].ToString() != "" && dtlastthree_monthavg.Rows[0]["FinishQtyavg"].ToString() != "0" && dtlastthree_monthavg.Rows[0]["FinishQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtlastthree_monthavg.Rows[0]["FinishQtyavg"].ToString()))
                {
                    lbllastFinishQty_C4647_3month_avg.Text = Get(dtlastthree_monthavg.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
                    lbllastFinishQty_C4647_3month_avg.ForeColor = Color.Black;
                }

            }
            if (dtlastthree_monthval.Rows[0]["FinishedValue"].ToString() != "" && dtlastthree_monthval.Rows[0]["FinishedValue"].ToString() != "0" && dtlastthree_monthval.Rows[0]["FinishedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtlastthree_monthval.Rows[0]["FinishedValue"].ToString()))
                {
                    lbllastFinishval_C4647_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtlastthree_monthval.Rows[0]["FinishedValue"].ToString() + " Cr." + "</span>";
                }

            }
            if (dtlastthree_month.Rows[0]["ShipQty"].ToString() != "" && dtlastthree_month.Rows[0]["ShipQty"].ToString() != "0" && dtlastthree_month.Rows[0]["ShipQty"].ToString() != "0.0" && dtlastthree_month.Rows[0]["ShipQty"].ToString() != "0.00")
            {

                if (Math.Round(Convert.ToDecimal(dtlastthree_month.Rows[0]["ShipQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
                {
                    lbllastdayshipQty_C4647_3month.Text = Math.Round((Convert.ToDecimal(Get(dtlastthree_month.Rows[0]["ShipQty"].ToString().Replace("k", "")).Replace("k", "")) / 3), MidpointRounding.AwayFromZero) + " k";
                }
            }
            if (dtlastthree_month.Rows[0]["ShipedValue"].ToString() != "" && dtlastthree_month.Rows[0]["ShipedValue"].ToString() != "0" && dtlastthree_month.Rows[0]["ShipedValue"].ToString() != "0.0")
            {
                if (Convert.ToDecimal(dtlastthree_month.Rows[0]["ShipedValue"].ToString()) / 3 > 0)
                {

                    lbllastdaysShipVal_C4647_3month.Text = "/" + "<span style='color:green;'> " + "\u20B9 " + Math.Round(Convert.ToDecimal(dtlastthree_month.Rows[0]["ShipedValue"].ToString()) / 3, 1) + " Cr." + "</span>";
                }
            }
            if (dtlastthree_month.Rows[0]["PenaltyValue"].ToString() != "" && dtlastthree_month.Rows[0]["PenaltyValue"].ToString() != "0" && dtlastthree_month.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtlastthree_month.Rows[0]["PenaltyValue"].ToString() != "0.00")
            {
                if (Convert.ToDecimal(dtlastthree_month.Rows[0]["PenaltyValue"].ToString()) / 3 > 0)
                {
                    lbllast_threeMonth_Penalty_fob_C4647_3month.Text = "\u20B9 " + Math.Round(Convert.ToDecimal(dtlastthree_month.Rows[0]["PenaltyValue"].ToString()) / 3, 1) + " Lk" + " /";
                }

            }
            if (dtlastthree_month.Rows[0]["PercentageFob"].ToString() != "" && dtlastthree_month.Rows[0]["PercentageFob"].ToString() != "0" && dtlastthree_month.Rows[0]["PercentageFob"].ToString() != "0.0" && dtlastthree_month.Rows[0]["PercentageFob"].ToString() != "0.00")
            {
                if (CheckZero(dtlastthree_month.Rows[0]["PercentageFob"].ToString()))
                    lbllastdayPendingShipedVal_fob_C4647_3month.Text = dtlastthree_month.Rows[0]["PercentageFob"].ToString() + " %";

            }
            if (dtlastthree_month.Rows[0]["ctsl"].ToString() != "" && dtlastthree_month.Rows[0]["ctsl"].ToString() != "0" && dtlastthree_month.Rows[0]["ctsl"].ToString() != "0.0")
            {
                if (CheckZero(dtlastthree_month.Rows[0]["ctsl"].ToString()))
                {
                    lbllastdaysShipCtsl_C4647_3month.Text = dtlastthree_month.Rows[0]["ctsl"].ToString() + " %";
                    if (Convert.ToInt32(dtlastthree_month.Rows[0]["RescanQty"]) > 0)
                    {
                        string RescanQty = Math.Round(Convert.ToDouble(((Convert.ToDouble(dtlastthree_month.Rows[0]["RescanQty"].ToString())) / Convert.ToDouble(3))), 0, MidpointRounding.AwayFromZero).ToString();
                        lbllastdaysShipCtsl_C4647_3month.Text = lbllastdaysShipCtsl_C4647_3month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(RescanQty) + " </span>";
                    }

                }

            }
            if (dtlastthree_month.Rows[0]["PendingShipQty"].ToString() != "" && dtlastthree_month.Rows[0]["PendingShipQty"].ToString() != "0" && dtlastthree_month.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtlastthree_month.Rows[0]["PendingShipQty"].ToString() != "0.00")
            {
                if (CheckZero(dtlastthree_month.Rows[0]["PendingShipQty"].ToString()))
                {
                    lbllastdayPendingShipedQty_C4647_3month.Text = GetLastMonthPDY(dtlastthree_month.Rows[0]["PendingShipQty"].ToString());
                }
            }
            if (dtlastthree_month.Rows[0]["PendingShipValue"].ToString() != "" && dtlastthree_month.Rows[0]["PendingShipValue"].ToString() != "0" && dtlastthree_month.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtlastthree_month.Rows[0]["PendingShipValue"].ToString() != "0.00")
            {
                if (CheckZero(dtlastthree_month.Rows[0]["PendingShipValue"].ToString()))
                    lbllastdayPendingShipedVal_C4647_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtlastthree_month.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

            }
            //dswip = objadmin.GetWipDetails(11, "CUTWIP");
            //dtwip = dswip.Tables[0];
            //if (dtwip.Rows[0]["CutWip_k"].ToString() != "" && dtwip.Rows[0]["CutWip_k"].ToString() != "0" && dtwip.Rows[0]["CutWip_k"].ToString() != "0.0" && dtwip.Rows[0]["CutWip_k"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtwip.Rows[0]["CutWip_k"].ToString()))
            //    {
            lblwipcutC45C46_K.Text = dtwip.Rows[0]["CutWIPPcs_C45"].ToString();
            //    }
            //}
            //dswip = objadmin.GetWipDetails(11, "CUTWIP");
            //dtwip = dswip.Tables[0];
            //if (dtwip.Rows[0]["CutWip_k"].ToString() != "" && dtwip.Rows[0]["CutWip_k"].ToString() != "0" && dtwip.Rows[0]["CutWip_k"].ToString() != "0.0" && dtwip.Rows[0]["CutWip_k"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtwip.Rows[0]["CutWip_k"].ToString()))
            //    {
            lblwipcutC45C46_K.Text = dtwip.Rows[0]["CutWIPPcs_C45"].ToString();
            //    }
            //}
            //if (dtwip.Rows[0]["CutWip"].ToString() != "" && dtwip.Rows[0]["CutWip"].ToString() != "0" && dtwip.Rows[0]["CutWip"].ToString() != "0.0" && dtwip.Rows[0]["CutWip"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtwip.Rows[0]["CutWip"].ToString()))

            //        lblwipcutC45C46.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["CutWip"].ToString()), 0) + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
            //}
            //dswip = objadmin.GetWipDetails(11, "STITCHWIP");
            //dtwip = dswip.Tables[0];
            //if (dtwip.Rows[0]["StitchWip_k"].ToString() != "" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0.00" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtwip.Rows[0]["StitchWip_k"].ToString()))
            //    {
            lblwipstitchC45C46_K.Text = dtwip.Rows[0]["StitchWIPPcs_C45"].ToString();
            //    }
            //}
            //if (dtwip.Rows[0]["StitchWip"].ToString() != "" && dtwip.Rows[0]["StitchWip"].ToString() != "0" && dtwip.Rows[0]["StitchWip"].ToString() != "0.00" && dtwip.Rows[0]["StitchWip"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtwip.Rows[0]["StitchWip"].ToString()))
            //        lblwipstitchC45C46.Text = dtwip.Rows[0]["StitchWip"].ToString() + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
            //}
            //dswip = objadmin.GetWipDetails(11, "FINISHWIP");
            //dtwip = dswip.Tables[0];
            //if (dtwip.Rows[0]["FinishWip_k"].ToString() != "" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0.00" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtwip.Rows[0]["FinishWip_k"].ToString()))
            //    {
            lblwipfinishC45C46_K.Text = dtwip.Rows[0]["PackWIPPcs_C45"].ToString();
            //    }
            //}
            // Pending Rescan value for C 45-46
            dsPendingRescan = objadmin.GetWipDetails(11, "PENDING_RESCAN");
            dtPendingRescan = dsPendingRescan.Tables[0];
            if (dtPendingRescan.Rows[0]["RescanValue"].ToString() != "" && dtPendingRescan.Rows[0]["RescanValue"].ToString() != "0" && dtPendingRescan.Rows[0]["RescanValue"].ToString() != "0.00")
            {
                if (CheckZero(dtPendingRescan.Rows[0]["RescanValue"].ToString()))
                {
                    lblPendingRescanC4546_k.Text = Get(dtPendingRescan.Rows[0]["RescanValue"].ToString()) + " <span style='color:red; font-size: 8px;'>" + "" + "</span>";
                }
            }
            //if (dtwip.Rows[0]["FinishWip"].ToString() != "" && dtwip.Rows[0]["FinishWip"].ToString() != "0" && dtwip.Rows[0]["FinishWip"].ToString() != "0.00" && dtwip.Rows[0]["FinishWip"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtwip.Rows[0]["FinishWip"].ToString()))
            //        lblwipfinishC45C46.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";

            //    if (Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()) > 2)
            //    {
            //        lblwipfinishC45C46.Text = " <span style='font-weight: bold;color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D</span>";
            //    }
            //    else
            //    {
            //        lblwipfinishC45C46.Text = " <span style='color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D</span>";
            //    }
            //}


            //--------------------------d 169 unit--------------------------------------------------------------------------------

            DataSet ds_169 = new DataSet();
            ds_169 = objadmin.GetShipmentReportByValue(1, 1, 96);

            DataTable dtitem_169 = new DataTable();

            DataTable dtitemlastday_169 = new DataTable();
            DataTable dtitemlastday_month_169 = new DataTable();

            dtitem_169 = ds_169.Tables[0];
            dtitemlastday_169 = ds_169.Tables[1];
            dtitemlastday_month_169 = ds_169.Tables[2];
            DataTable dtitemlastday_month_avg_169 = ds_169.Tables[3];
            //--------------created by Prabhaker--------//               
            dtitemMonthD169_Total = ds_169.Tables[7];

            DataTable dtitemlastdaystitchv_month_val_169 = ds_169.Tables[3];
            //----last three month-----//
            DataTable dtitemlastday_lastthree_169 = new DataTable();
            DataTable dtavglastthree_169 = new DataTable();
            //--------------created by Prabhaker--------//
            DataTable dtavglastthree_val_169 = ds_169.Tables[5];
            //----last three month-----//
            dtitemlastday_lastthree_169 = ds_169.Tables[4];
            dtavglastthree_169 = ds_169.Tables[5];


            //DataSet dswip_169 = new DataSet();
            //DataTable dtwip_169 = new DataTable();

            //dswip_169 = objadmin.GetWipDetails(96, "CUTWIP");
            //dtwip_169 = dswip_169.Tables[0];

            if (dtitemlastday_169.Rows[0]["CutActual"].ToString() != "" && dtitemlastday_169.Rows[0]["CutActual"].ToString() != "0" && dtitemlastday_169.Rows[0]["CutActual"].ToString() != "0.0" && dtitemlastday_169.Rows[0]["CutActual"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday.Rows[0]["CutActual"].ToString()))
                {
                    lbllastdayCutQty_D169.Text = Get_WithDecimal(dtitemlastday_169.Rows[0]["CutActual"].ToString());
                }

            }

            if (dtitemlastday_169.Rows[0]["StitchQty"].ToString() != "" && dtitemlastday_169.Rows[0]["StitchQty"].ToString() != "0" && dtitemlastday_169.Rows[0]["StitchQty"].ToString() != "0.0" && dtitemlastday_169.Rows[0]["StitchQty"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_169.Rows[0]["StitchQty"].ToString()))
                {
                    lblLastdayStitchQty_D169.Text = Get_WithDecimal(dtitemlastday_169.Rows[0]["StitchQty"].ToString());
                }
            }
            if (dtitemlastday_169.Rows[0]["Stitchedvalue"].ToString() != "" && dtitemlastday_169.Rows[0]["Stitchedvalue"].ToString() != "0" && dtitemlastday_169.Rows[0]["Stitchedvalue"].ToString() != "0.00" && dtitemlastday_169.Rows[0]["Stitchedvalue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_169.Rows[0]["Stitchedvalue"].ToString()))
                    lblLastdayStitchval_D169.Text = " \u20B9 " + dtitemlastday_169.Rows[0]["Stitchedvalue"].ToString() + " Cr.";

            }
            if (dtitemlastday_169.Rows[0]["FinishQty"].ToString() != "" && dtitemlastday_169.Rows[0]["FinishQty"].ToString() != "0" && dtitemlastday_169.Rows[0]["FinishQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_169.Rows[0]["FinishQty"].ToString()))
                {
                    lblLastdayFinish_D169.Text = Get_WithDecimal(dtitemlastday_169.Rows[0]["FinishQty"].ToString());
                }
            }
            if (dtitemlastday_169.Rows[0]["finishedvalue"].ToString() != "" && dtitemlastday_169.Rows[0]["finishedvalue"].ToString() != "0" && dtitemlastday_169.Rows[0]["finishedvalue"].ToString() != "0.00" && dtitemlastday_169.Rows[0]["finishedvalue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_169.Rows[0]["finishedvalue"].ToString()))
                    lblLastdayFinishVal_D169.Text = " \u20B9 " + dtitemlastday_169.Rows[0]["finishedvalue"].ToString() + " Cr.";

            }
            if (dtitemlastday_169.Rows[0]["ShipQty"].ToString() != "" && dtitemlastday_169.Rows[0]["ShipQty"].ToString() != "0" && dtitemlastday_169.Rows[0]["ShipQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_169.Rows[0]["ShipQty"].ToString()))
                {

                    llblLastdayShipQty_D169.Text = Get(dtitemlastday_169.Rows[0]["ShipQty"].ToString());

                }
            }
            if (dtitemlastday_169.Rows[0]["ShipedValue"].ToString() != "" && dtitemlastday_169.Rows[0]["ShipedValue"].ToString() != "0" && dtitemlastday_169.Rows[0]["ShipedValue"].ToString() != "0.0" && dtitemlastday_169.Rows[0]["ShipedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_169.Rows[0]["ShipedValue"].ToString()))
                    llblLastdayShipValue_D169.Text = "/" + "<span style='color:green;'> " + "\u20B9 " + dtitemlastday_169.Rows[0]["ShipedValue"].ToString() + " Cr." + "</span>";

            }
            if (dtitemlastday_169.Rows[0]["PenaltyValue"].ToString() != "" && dtitemlastday_169.Rows[0]["PenaltyValue"].ToString() != "0" && dtitemlastday_169.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitemlastday_169.Rows[0]["PenaltyValue"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_169.Rows[0]["PenaltyValue"].ToString()))
                    lbllastdayPenaltyValue_fob_D169.Text = "\u20B9 " + dtitemlastday_169.Rows[0]["PenaltyValue"].ToString() + " Lk /";

            }
            if (dtitemlastday_169.Rows[0]["PercentageFob"].ToString() != "" && dtitemlastday_169.Rows[0]["PercentageFob"].ToString() != "0" && dtitemlastday_169.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitemlastday_169.Rows[0]["PercentageFob"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_169.Rows[0]["PercentageFob"].ToString()))
                    lbllastdaypendingShipvalue_fob_D169.Text = dtitemlastday_169.Rows[0]["PercentageFob"].ToString() + " %";

            }
            if (dtitemlastday_169.Rows[0]["ctsl"].ToString() != "" && dtitemlastday_169.Rows[0]["ctsl"].ToString() != "0" && dtitemlastday_169.Rows[0]["ctsl"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_169.Rows[0]["ctsl"].ToString()))
                {
                    lblLastdayShipCtsl_D169.Text = dtitemlastday_169.Rows[0]["ctsl"].ToString() + "%";
                }
            }
            if (dtitemlastday_169.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_169.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_169.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemlastday_169.Rows[0]["PendingShipQty"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_169.Rows[0]["PendingShipQty"].ToString()))
                {

                    lbllastdaypendingShipQty_D169.Text = Get_WithDecimal(dtitemlastday_169.Rows[0]["PendingShipQty"].ToString());
                }
            }
            if (dtitemlastday_169.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_169.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemlastday_169.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemlastday_169.Rows[0]["PendingShipValue"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_169.Rows[0]["PendingShipValue"].ToString()))
                    lbllastdaypendingShipvalue_D169.Text = "<span style='color:green;'> \u20B9 " + dtitemlastday_169.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

            }
            if (dtitemlastday_month_169.Rows[0]["CutActual"].ToString() != "" && dtitemlastday_month_169.Rows[0]["CutActual"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["CutActual"].ToString() != "0.0" && dtitemlastday_month_169.Rows[0]["CutActual"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_month_169.Rows[0]["CutActual"].ToString()))
                {
                    lbllastdayCutQty_D169_month.Text = Get(dtitemlastday_month_169.Rows[0]["CutActual"].ToString());
                }
            }

            //last month====avg
            if (dtitemlastday_month_avg_169.Rows[0]["CutQtyavg"].ToString() != "" && dtitemlastday_month_avg_169.Rows[0]["CutQtyavg"].ToString() != "0" && dtitemlastday_month_avg_169.Rows[0]["CutQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month_avg_169.Rows[0]["CutQtyavg"].ToString()))
                {
                    lbllastdayCutQty_D169_month_avg.Text = Get(dtitemlastday_month_avg_169.Rows[0]["CutQtyavg"].ToString()) + " k" + " <span style='font-size: 8px;color:Black;'>" + "pdy" + "</span>";
                    lbllastdayCutQty_D169_month_avg.ForeColor = Color.Black;
                }
            }

            if (dtitemlastday_month_169.Rows[0]["StitchQty"].ToString() != "" && dtitemlastday_month_169.Rows[0]["StitchQty"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["StitchQty"].ToString() != "0.0" && dtitemlastday_month_169.Rows[0]["StitchQty"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_month_169.Rows[0]["StitchQty"].ToString()))
                {

                    lblLastdayStitchQty_D169_month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_month_169.Rows[0]["StitchQty"].ToString()).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";

                }
            }
            //last month====avg
            if (dtitemlastday_month_avg_169.Rows[0]["StitchQtyavg"].ToString() != "" && dtitemlastday_month_avg_169.Rows[0]["StitchQtyavg"].ToString() != "0" && dtitemlastday_month_avg_169.Rows[0]["StitchQtyavg"].ToString() != "0.0" && dtitemlastday_month_avg_169.Rows[0]["StitchQtyavg"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_month_avg_169.Rows[0]["StitchQtyavg"].ToString()))
                {

                    lblLastdayStitchQty_D169_month_avg.Text = GetLastMonthPDY(dtitemlastday_month_avg_169.Rows[0]["StitchQtyavg"].ToString()) + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";


                }
            }

            if (dtitemlastdaystitchv_month_val_169.Rows[0]["StitchedValue"].ToString() != "" && dtitemlastdaystitchv_month_val_169.Rows[0]["StitchedValue"].ToString() != "0" && dtitemlastdaystitchv_month_val_169.Rows[0]["StitchedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastdaystitchv_month_val_169.Rows[0]["StitchedValue"].ToString()))
                    lblLastdayStitchval_D169_month.Text = " \u20B9 " + dtitemlastdaystitchv_month_val_169.Rows[0]["StitchedValue"].ToString() + " Cr.";

            }
            if (dtitemlastday_month_169.Rows[0]["FinishQty"].ToString() != "" && dtitemlastday_month_169.Rows[0]["FinishQty"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["FinishQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month_169.Rows[0]["FinishQty"].ToString()))
                {
                    //lblLastdayFinish_C47_month.Text = Math.Round(Convert.ToDecimal(dtitemlastday_month.Rows[0]["FinishQty"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k";
                    lblLastdayFinish_D169_month.Text = Get(dtitemlastday_month_169.Rows[0]["FinishQty"].ToString());
                }

            }
            if (dtitemlastday_month_avg_169.Rows[0]["FinishQtyavg"].ToString() != "" && dtitemlastday_month_avg_169.Rows[0]["FinishQtyavg"].ToString() != "0" && dtitemlastday_month_avg_169.Rows[0]["FinishQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month_avg_169.Rows[0]["FinishQtyavg"].ToString()))
                {
                    //lblLastdayFinish_C47_month_avg.Text = dtitemlastday_month_avg.Rows[0]["FinishQtyavg"].ToString() + " k" + " <span style='font-size: 8px;color:Black;'>" + "pdy" + "</span>";
                    lblLastdayFinish_D169_month_avg.Text = GetLastMonthPDY(dtitemlastday_month_avg_169.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:Black;'>" + "pdy" + "</span>";
                    lblLastdayFinish_D169_month_avg.ForeColor = Color.Black;
                }
            }

            if (dtitemlastdaystitchv_month_val_169.Rows[0]["FinishedValue"].ToString() != "" && dtitemlastdaystitchv_month_val_169.Rows[0]["FinishedValue"].ToString() != "0" && dtitemlastdaystitchv_month_val_169.Rows[0]["FinishedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastdaystitchv_month_val_169.Rows[0]["FinishedValue"].ToString()))
                    lblLastdayFinishval_D169_month.Text = "<span style='color:green;'> " + "\u20B9 " + dtitemlastdaystitchv_month_val_169.Rows[0]["FinishedValue"].ToString() + " Cr." + "</span>";
            }
            if (dtitemlastday_month_169.Rows[0]["ShipQty"].ToString() != "" && dtitemlastday_month_169.Rows[0]["ShipQty"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["ShipQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month_169.Rows[0]["ShipQty"].ToString()))
                {
                    //llblLastdayShipQty_C47_month.Text = dtitemlastday_month.Rows[0]["ShipQty"].ToString() + " k";                   
                    llblLastdayShipQty_D169_month.Text = Get(dtitemlastday_month_169.Rows[0]["ShipQty"].ToString());
                }
            }
            if (dtitemlastday_month_169.Rows[0]["ShipedValue"].ToString() != "" && dtitemlastday_month_169.Rows[0]["ShipedValue"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["ShipedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month_169.Rows[0]["ShipedValue"].ToString()))
                    llblLastdayShipValue_D169_month.Text = "/ " + "<span style='color:green;'> " + "\u20B9 " + dtitemlastday_month_169.Rows[0]["ShipedValue"].ToString() + " Cr." + "</span>";

            }

            if (dtitemlastday_month_169.Rows[0]["PenaltyValue"].ToString() != "" && dtitemlastday_month_169.Rows[0]["PenaltyValue"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["PenaltyValue"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_month_169.Rows[0]["PenaltyValue"].ToString()))
                    lbllastdayPenalty_fob_D169_month.Text = "\u20B9 " + dtitemlastday_month_169.Rows[0]["PenaltyValue"].ToString() + " Lk /";

            }
            if (dtitemlastday_month_169.Rows[0]["PercentageFob"].ToString() != "" && dtitemlastday_month_169.Rows[0]["PercentageFob"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["PercentageFob"].ToString() != "0.00" && dtitemlastday_month_169.Rows[0]["PercentageFob"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month_169.Rows[0]["PercentageFob"].ToString()))
                    lbllastdaypendingShipvalue_fob_D169_month.Text = dtitemlastday_month_169.Rows[0]["PercentageFob"].ToString() + " %";
            }
            if (dtitemlastday_month_169.Rows[0]["ctsl"].ToString() != "" && dtitemlastday_month_169.Rows[0]["ctsl"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["ctsl"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month_169.Rows[0]["ctsl"].ToString()))
                    lblLastdayShipCtsl_D169_month.Text = dtitemlastday_month_169.Rows[0]["ctsl"].ToString() + " %";
                if (Convert.ToInt32(dtitemlastday_month_169.Rows[0]["RescanQty"]) > 0)
                    lblLastdayShipCtsl_D169_month.Text = lblLastdayShipCtsl_D169_month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(dtitemlastday_month_169.Rows[0]["RescanQty"].ToString()) + " </span>";


            }
            if (dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString()))
                {
                    //lbllastdaypendingShipQty_C47_month.Text = dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() + " k";   
                    lbllastdaypendingShipQty_D169_month.Text = Get(dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString());
                }
            }

            if (dtitemlastday_month_169.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_month_169.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["PendingShipValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_month_169.Rows[0]["PendingShipValue"].ToString()))
                    lbllastdaypendingShipvalue_D169_month.Text = "<span style='color:green;'> \u20B9 " + dtitemlastday_month_169.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

            }
            //last three month===========================================================//
            if (dtitemlastday_lastthree_169.Rows[0]["CutActual"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["CutActual"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["CutActual"].ToString() != "0.0")
            {
                if (Math.Round(Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["CutActual"].ToString()), MidpointRounding.AwayFromZero) > 0)
                {
                    lbllastdayCutQty_D169_3month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_lastthree_169.Rows[0]["CutActual"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";
                }
            }
            if (dtavglastthree_169.Rows[0]["CutQtyavg"].ToString() != "" && dtavglastthree_169.Rows[0]["CutQtyavg"].ToString() != "0" && dtavglastthree_169.Rows[0]["CutQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtavglastthree_169.Rows[0]["CutQtyavg"].ToString()))
                {
                    lbllastdayCutQty_D169_3month_avg.Text = GetLastMonthPDY(dtavglastthree_169.Rows[0]["CutQtyavg"].ToString()) + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
                }
            }
            if (dtitemlastday_lastthree_169.Rows[0]["StitchQty"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["StitchQty"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["StitchQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitemlastday_lastthree_169.Rows[0]["StitchQty"].ToString()))
                {
                    if (Math.Round(Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["StitchQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
                    {

                        lblLastdayStitchQty_D169_3month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_lastthree_169.Rows[0]["StitchQty"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";

                    }
                }
            }
            if (dtavglastthree_169.Rows[0]["StitchQtyavg"].ToString() != "" && dtavglastthree_169.Rows[0]["StitchQtyavg"].ToString() != "0" && dtavglastthree_169.Rows[0]["StitchQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtavglastthree_169.Rows[0]["StitchQtyavg"].ToString()))
                {
                    lblLastdayStitchQty_D169_3month_avg.Text = Get(dtavglastthree_169.Rows[0]["StitchQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
                }
            }
            if (dtavglastthree_val_169.Rows[0]["StitchedValue"].ToString() != "" && dtavglastthree_val_169.Rows[0]["StitchedValue"].ToString() != "0" && dtavglastthree_val_169.Rows[0]["StitchedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtavglastthree_val_169.Rows[0]["StitchedValue"].ToString()))
                    lblLastdayStitchval_D169_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtavglastthree_val_169.Rows[0]["StitchedValue"].ToString() + " Cr." + "</span>";

            }
            if (dtitemlastday_lastthree_169.Rows[0]["FinishQty"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["FinishQty"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["FinishQty"].ToString() != "0.0")
            {

                if (Math.Round(Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["FinishQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
                {

                    lblLastdayFinish_D169_3month.Text = Get(dtitemlastday_lastthree_169.Rows[0]["FinishQty"].ToString());

                }
            }
            if (dtavglastthree_val_169.Rows[0]["FinishedValue"].ToString() != "" && dtavglastthree_val_169.Rows[0]["FinishedValue"].ToString() != "0" && dtavglastthree_val_169.Rows[0]["FinishedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtavglastthree_val_169.Rows[0]["FinishedValue"].ToString()))
                {

                    lblLastdayFinishval_D169_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtavglastthree_val_169.Rows[0]["FinishedValue"].ToString() + " Cr." + "</span>";
                }
            }

            // last month====avg
            if (dtavglastthree_169.Rows[0]["FinishQtyavg"].ToString() != "" && dtavglastthree_169.Rows[0]["FinishQtyavg"].ToString() != "0" && dtavglastthree_169.Rows[0]["FinishQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtavglastthree_169.Rows[0]["FinishQtyavg"].ToString()))
                {
                    lblLastdayFinish_D169_3month_avg.Text = Get(dtavglastthree_169.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
                    lblLastdayFinish_D169_3month_avg.ForeColor = Color.Black;
                }

            }
            if (dtitemlastday_lastthree_169.Rows[0]["ShipQty"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["ShipQty"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["ShipQty"].ToString() != "0.0" && dtitemlastday_lastthree_169.Rows[0]["ShipQty"].ToString() != "0.0")
            {
                if (Math.Round((Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["ShipQty"].ToString()) / 3), MidpointRounding.AwayFromZero) > 0)
                {
                    llblLastdayShipQty_D169_3month.Text = Math.Round((Convert.ToDecimal(Get(dtitemlastday_lastthree_169.Rows[0]["ShipQty"].ToString()).Replace("k", "")) / 3), MidpointRounding.AwayFromZero) + " k";

                }
            }
            if (dtitemlastday_lastthree_169.Rows[0]["ShipedValue"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["ShipedValue"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["ShipedValue"].ToString() != "0.0" && dtitemlastday_lastthree_169.Rows[0]["ShipedValue"].ToString() != "0.0")
            {

                if (CheckZero(dtitemlastday_lastthree_169.Rows[0]["ShipedValue"].ToString()))
                {
                    if (Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["ShipedValue"].ToString()) / 3 > 0)
                    {
                        llblLastdayShipValue_D169_3month.Text = "/ " + "<span style='color:green;'> " + "\u20B9 " + Math.Round(Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["ShipedValue"].ToString()) / 3, 1) + " Cr." + "</span>";
                    }
                }
            }
            if (dtitemlastday_lastthree_169.Rows[0]["PenaltyValue"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["PenaltyValue"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitemlastday_lastthree_169.Rows[0]["PenaltyValue"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_lastthree_169.Rows[0]["PenaltyValue"].ToString()))
                {
                    if ((Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["PenaltyValue"].ToString()) / 3) > 0)
                    {
                        lbllast_threeMonth_Penalty_fob_D169_3month.Text = "\u20B9 " + Math.Round((Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["PenaltyValue"].ToString()) / 3), 1) + " Lk /";
                    }
                }

            }
            if (dtitemlastday_lastthree_169.Rows[0]["PercentageFob"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["PercentageFob"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitemlastday_lastthree_169.Rows[0]["PercentageFob"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_lastthree_169.Rows[0]["PercentageFob"].ToString()))
                    lbllastdaypendingShipvalue_fob_D169_3month.Text = dtitemlastday_lastthree_169.Rows[0]["PercentageFob"].ToString() + " %";

            }
            if (dtitemlastday_lastthree_169.Rows[0]["ctsl"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["ctsl"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["ctsl"].ToString() != "0.0" && dtitemlastday_lastthree_169.Rows[0]["ctsl"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_lastthree_169.Rows[0]["ctsl"].ToString()))
                    lblLastdayShipCtsl_D169_3month.Text = dtitemlastday_lastthree_169.Rows[0]["ctsl"].ToString() + " %";
                if (Convert.ToInt32(dtitemlastday_lastthree_169.Rows[0]["RescanQty"]) > 0)
                {
                    string RescanQty = Math.Round(Convert.ToDouble(((Convert.ToDouble(dtitemlastday_lastthree_169.Rows[0]["RescanQty"].ToString())) / Convert.ToDouble(3))), 0, MidpointRounding.AwayFromZero).ToString();
                    lblLastdayShipCtsl_D169_3month.Text = lblLastdayShipCtsl_D169_3month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(RescanQty) + " </span>";
                }
            }
            if (dtitemlastday_lastthree_169.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemlastday_lastthree_169.Rows[0]["PendingShipQty"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_lastthree_169.Rows[0]["PendingShipQty"].ToString()))
                {
                    lbllastdaypendingShipQty_D169_3month.Text = GetLastMonthPDY(dtitemlastday_lastthree_169.Rows[0]["PendingShipQty"].ToString());
                }
            }
            if (dtitemlastday_lastthree_169.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemlastday_lastthree_169.Rows[0]["PendingShipValue"].ToString() != "0.00")
            {
                if (CheckZero(dtitemlastday_lastthree_169.Rows[0]["PendingShipValue"].ToString()))
                    lbllastdaypendingShipvalue_D169_3month.Text = "<span style='color:green;'> \u20B9 " + dtitemlastday_lastthree_169.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

            }
            //if (dtwip_169.Rows[0]["CutWip_k"].ToString() != "" && dtwip_169.Rows[0]["CutWip_k"].ToString() != "0" && dtwip_169.Rows[0]["CutWip_k"].ToString() != "0.00")
            //{
            //    if (Math.Round(Convert.ToDecimal(CheckZero(dtwip_169.Rows[0]["CutWip_k"].ToString())), 0) > 0)
            //    {
            lblwipcutD169_K.Text = dtwip.Rows[0]["CutWIPPcs_D169"].ToString();
            //    }
            //}
            //if (dtwip_169.Rows[0]["CutWip"].ToString() != "" && dtwip_169.Rows[0]["CutWip"].ToString() != "0" && dtwip_169.Rows[0]["CutWip"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtwip_169.Rows[0]["CutWip"].ToString()))
            //        lblwipcutD169.Text = Math.Round(Convert.ToDecimal(dtwip_169.Rows[0]["CutWip"].ToString()), 0) + " D"; //+ " <span style='font-size: 8px;'>" + "D" + "</span>";

            //}
            //dswip = objadmin.GetWipDetails(96, "STITCHWIP");
            //dtwip = dswip.Tables[0];
            //if (dtwip.Rows[0]["StitchWip_k"].ToString() != "" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtwip.Rows[0]["StitchWip_k"].ToString()))
            //    {
            lblwipstitchD169_K.Text = dtwip.Rows[0]["StitchWIPPcs_D169"].ToString();
            //    }
            //}
            //if (dtwip.Rows[0]["StitchWip"].ToString() != "" && dtwip.Rows[0]["StitchWip"].ToString() != "0" && dtwip.Rows[0]["StitchWip"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtwip.Rows[0]["StitchWip"].ToString()))
            //        lblwipstitchD169.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["StitchWip"].ToString()), 0) + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
            //}
            //dswip = objadmin.GetWipDetails(96, "FINISHWIP");
            //dtwip = dswip.Tables[0];
            //if (dtwip.Rows[0]["FinishWip_k"].ToString() != "" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtwip.Rows[0]["FinishWip_k"].ToString()))
            //    {
            lblwipfinishD169_K.Text = dtwip.Rows[0]["PackWIPPcs_D169"].ToString();
            //    }
            //}
            // Pending Rescan value for C 47
            dsPendingRescan = objadmin.GetWipDetails(96, "PENDING_RESCAN");
            dtPendingRescan = dsPendingRescan.Tables[0];
            if (dtPendingRescan.Rows[0]["RescanValue"].ToString() != "" && dtPendingRescan.Rows[0]["RescanValue"].ToString() != "0" && dtPendingRescan.Rows[0]["RescanValue"].ToString() != "0.00")
            {
                if (CheckZero(dtPendingRescan.Rows[0]["RescanValue"].ToString()))
                {
                    lblPendingRescanD169_k.Text = Get(dtPendingRescan.Rows[0]["RescanValue"].ToString()) + " <span style='color:red; font-size: 8px;'>" + "" + "</span>";
                }
            }
            //if (dtwip.Rows[0]["FinishWip"].ToString() != "" && dtwip.Rows[0]["FinishWip"].ToString() != "0" && dtwip.Rows[0]["FinishWip"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtwip.Rows[0]["FinishWip"].ToString()))
            //    {
            //        // lblwipfinishC47.Text = dtwip.Rows[0]["FinishWip"].ToString() + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
            //        if (Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()) > 2)
            //        {
            //            lblwipfinishD169.Text = " <span style='font-weight: bold;color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D" + "</span>";
            //        }
            //        else
            //        {
            //            lblwipfinishD169.Text = " <span style='color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D" + "</span>";
            //        }
            //    }
            //}
            //--------------------------C52 unit--------------------------------------------------------------------------------

            //DataSet ds_C52 = new DataSet();
            //ds_C52 = objadmin.GetShipmentReportByValue(1, 1, 120);

            //DataTable dtitem_C52 = new DataTable();

            //DataTable dtitemlastday_C52 = new DataTable();
            //DataTable dtitemlastday_month_C52 = new DataTable();

            //dtitem_C52 = ds_C52.Tables[0];
            //dtitemlastday_C52 = ds_C52.Tables[1];
            //dtitemlastday_month_C52 = ds_C52.Tables[2];
            //DataTable dtitemlastday_month_avg_C52 = ds_C52.Tables[3];
            ////--------------created by Prabhaker--------//               
            //dtitemMonthC52_Total = ds_C52.Tables[7];

            //DataTable dtitemlastdaystitchv_month_val_C52 = ds_C52.Tables[3];
            ////----last three month-----//
            //DataTable dtitemlastday_lastthree_C52 = new DataTable();
            //DataTable dtavglastthree_C52 = new DataTable();
            ////--------------created by Prabhaker--------//
            //DataTable dtavglastthree_val_C52 = ds_C52.Tables[5];
            ////----last three month-----//
            //dtitemlastday_lastthree_C52 = ds_C52.Tables[4];
            //dtavglastthree_C52 = ds_C52.Tables[5];


            ////DataSet dswip_C52 = new DataSet();
            ////DataTable dtwip_C52 = new DataTable();

            ////dswip_C52 = objadmin.GetWipDetails(120, "CUTWIP");
            ////dtwip_C52 = dswip_C52.Tables[0];

            //if (dtitemlastday_C52.Rows[0]["CutActual"].ToString() != "" && dtitemlastday_C52.Rows[0]["CutActual"].ToString() != "0" && dtitemlastday_C52.Rows[0]["CutActual"].ToString() != "0.0" && dtitemlastday_C52.Rows[0]["CutActual"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday.Rows[0]["CutActual"].ToString()))
            //    {
            //        lbllastdayCutQty_C52.Text = Get_WithDecimal(dtitemlastday_C52.Rows[0]["CutActual"].ToString());
            //    }

            //}

            //if (dtitemlastday_C52.Rows[0]["StitchQty"].ToString() != "" && dtitemlastday_C52.Rows[0]["StitchQty"].ToString() != "0" && dtitemlastday_C52.Rows[0]["StitchQty"].ToString() != "0.0" && dtitemlastday_C52.Rows[0]["StitchQty"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday_C52.Rows[0]["StitchQty"].ToString()))
            //    {
            //        lblLastdayStitchQty_C52.Text = Get_WithDecimal(dtitemlastday_C52.Rows[0]["StitchQty"].ToString());
            //    }
            //}
            //if (dtitemlastday_C52.Rows[0]["Stitchedvalue"].ToString() != "" && dtitemlastday_C52.Rows[0]["Stitchedvalue"].ToString() != "0" && dtitemlastday_C52.Rows[0]["Stitchedvalue"].ToString() != "0.00" && dtitemlastday_C52.Rows[0]["Stitchedvalue"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastday_C52.Rows[0]["Stitchedvalue"].ToString()))
            //        lblLastdayStitchval_C52.Text = " \u20B9 " + dtitemlastday_C52.Rows[0]["Stitchedvalue"].ToString() + " Cr.";

            //}
            //if (dtitemlastday_C52.Rows[0]["FinishQty"].ToString() != "" && dtitemlastday_C52.Rows[0]["FinishQty"].ToString() != "0" && dtitemlastday_C52.Rows[0]["FinishQty"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastday_C52.Rows[0]["FinishQty"].ToString()))
            //    {
            //        lblLastdayFinish_C52.Text = Get_WithDecimal(dtitemlastday_C52.Rows[0]["FinishQty"].ToString());
            //    }
            //}
            //if (dtitemlastday_C52.Rows[0]["finishedvalue"].ToString() != "" && dtitemlastday_C52.Rows[0]["finishedvalue"].ToString() != "0" && dtitemlastday_C52.Rows[0]["finishedvalue"].ToString() != "0.00" && dtitemlastday_C52.Rows[0]["finishedvalue"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastday_C52.Rows[0]["finishedvalue"].ToString()))
            //        lblLastdayFinishVal_C52.Text = " \u20B9 " + dtitemlastday_C52.Rows[0]["finishedvalue"].ToString() + " Cr.";

            //}
            //if (dtitemlastday_C52.Rows[0]["ShipQty"].ToString() != "" && dtitemlastday_C52.Rows[0]["ShipQty"].ToString() != "0" && dtitemlastday_C52.Rows[0]["ShipQty"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastday_C52.Rows[0]["ShipQty"].ToString()))
            //    {

            //        llblLastdayShipQty_C52.Text = Get(dtitemlastday_C52.Rows[0]["ShipQty"].ToString());

            //    }
            //}
            //if (dtitemlastday_C52.Rows[0]["ShipedValue"].ToString() != "" && dtitemlastday_C52.Rows[0]["ShipedValue"].ToString() != "0" && dtitemlastday_C52.Rows[0]["ShipedValue"].ToString() != "0.0" && dtitemlastday_C52.Rows[0]["ShipedValue"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastday_C52.Rows[0]["ShipedValue"].ToString()))
            //        llblLastdayShipValue_C52.Text = "/" + "<span style='color:green;'> " + "\u20B9 " + dtitemlastday_C52.Rows[0]["ShipedValue"].ToString() + " Cr." + "</span>";

            //}
            //if (dtitemlastday_C52.Rows[0]["PenaltyValue"].ToString() != "" && dtitemlastday_C52.Rows[0]["PenaltyValue"].ToString() != "0" && dtitemlastday_C52.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitemlastday_C52.Rows[0]["PenaltyValue"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday_C52.Rows[0]["PenaltyValue"].ToString()))
            //        lbllastdayPenaltyValue_fob_C52.Text = "\u20B9 " + dtitemlastday_C52.Rows[0]["PenaltyValue"].ToString() + " Lk /";

            //}
            //if (dtitemlastday_C52.Rows[0]["PercentageFob"].ToString() != "" && dtitemlastday_C52.Rows[0]["PercentageFob"].ToString() != "0" && dtitemlastday_C52.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitemlastday_C52.Rows[0]["PercentageFob"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday_C52.Rows[0]["PercentageFob"].ToString()))
            //        lbllastdaypendingShipvalue_fob_C52.Text = dtitemlastday_C52.Rows[0]["PercentageFob"].ToString() + " %";

            //}
            //if (dtitemlastday_C52.Rows[0]["ctsl"].ToString() != "" && dtitemlastday_C52.Rows[0]["ctsl"].ToString() != "0" && dtitemlastday_C52.Rows[0]["ctsl"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastday_C52.Rows[0]["ctsl"].ToString()))
            //    {
            //        lblLastdayShipCtsl_C52.Text = dtitemlastday_C52.Rows[0]["ctsl"].ToString() + "%";
            //    }
            //}
            //if (dtitemlastday_C52.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_C52.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_C52.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemlastday_C52.Rows[0]["PendingShipQty"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday_C52.Rows[0]["PendingShipQty"].ToString()))
            //    {

            //        lbllastdaypendingShipQty_C52.Text = Get_WithDecimal(dtitemlastday_C52.Rows[0]["PendingShipQty"].ToString());
            //    }
            //}
            //if (dtitemlastday_C52.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_C52.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemlastday_C52.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemlastday_C52.Rows[0]["PendingShipValue"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday_C52.Rows[0]["PendingShipValue"].ToString()))
            //        lbllastdaypendingShipvalue_C52.Text = "<span style='color:green;'> \u20B9 " + dtitemlastday_C52.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

            //}
            //if (dtitemlastday_month_C52.Rows[0]["CutActual"].ToString() != "" && dtitemlastday_month_C52.Rows[0]["CutActual"].ToString() != "0" && dtitemlastday_month_C52.Rows[0]["CutActual"].ToString() != "0.0" && dtitemlastday_month_C52.Rows[0]["CutActual"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday_month_C52.Rows[0]["CutActual"].ToString()))
            //    {
            //        lbllastdayCutQty_C52_month.Text = Get(dtitemlastday_month_C52.Rows[0]["CutActual"].ToString());
            //    }
            //}

            ////last month====avg
            //if (dtitemlastday_month_avg_C52.Rows[0]["CutQtyavg"].ToString() != "" && dtitemlastday_month_avg_C52.Rows[0]["CutQtyavg"].ToString() != "0" && dtitemlastday_month_avg_C52.Rows[0]["CutQtyavg"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastday_month_avg_C52.Rows[0]["CutQtyavg"].ToString()))
            //    {
            //        lbllastdayCutQty_C52_month_avg.Text = Get(dtitemlastday_month_avg_C52.Rows[0]["CutQtyavg"].ToString()) + " k" + " <span style='font-size: 8px;color:Black;'>" + "pdy" + "</span>";
            //        lbllastdayCutQty_C52_month_avg.ForeColor = Color.Black;
            //    }
            //}

            //if (dtitemlastday_month_C52.Rows[0]["StitchQty"].ToString() != "" && dtitemlastday_month_C52.Rows[0]["StitchQty"].ToString() != "0" && dtitemlastday_month_C52.Rows[0]["StitchQty"].ToString() != "0.0" && dtitemlastday_month_C52.Rows[0]["StitchQty"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday_month_C52.Rows[0]["StitchQty"].ToString()))
            //    {

            //        lblLastdayStitchQty_C52_month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_month_C52.Rows[0]["StitchQty"].ToString()).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";

            //    }
            //}
            ////last month====avg
            //if (dtitemlastday_month_avg_C52.Rows[0]["StitchQtyavg"].ToString() != "" && dtitemlastday_month_avg_C52.Rows[0]["StitchQtyavg"].ToString() != "0" && dtitemlastday_month_avg_C52.Rows[0]["StitchQtyavg"].ToString() != "0.0" && dtitemlastday_month_avg_C52.Rows[0]["StitchQtyavg"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday_month_avg_C52.Rows[0]["StitchQtyavg"].ToString()))
            //    {

            //        lblLastdayStitchQty_C52_month_avg.Text = GetLastMonthPDY(dtitemlastday_month_avg_C52.Rows[0]["StitchQtyavg"].ToString()) + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";


            //    }
            //}

            //if (dtitemlastdaystitchv_month_val_C52.Rows[0]["StitchedValue"].ToString() != "" && dtitemlastdaystitchv_month_val_C52.Rows[0]["StitchedValue"].ToString() != "0" && dtitemlastdaystitchv_month_val_C52.Rows[0]["StitchedValue"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastdaystitchv_month_val_C52.Rows[0]["StitchedValue"].ToString()))
            //        lblLastdayStitchval_C52_month.Text = " \u20B9 " + dtitemlastdaystitchv_month_val_C52.Rows[0]["StitchedValue"].ToString() + " Cr.";

            //}
            //if (dtitemlastday_month_C52.Rows[0]["FinishQty"].ToString() != "" && dtitemlastday_month_C52.Rows[0]["FinishQty"].ToString() != "0" && dtitemlastday_month_C52.Rows[0]["FinishQty"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastday_month_C52.Rows[0]["FinishQty"].ToString()))
            //    {
            //        //lblLastdayFinish_C47_month.Text = Math.Round(Convert.ToDecimal(dtitemlastday_month.Rows[0]["FinishQty"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k";
            //        lblLastdayFinish_C52_month.Text = Get(dtitemlastday_month_C52.Rows[0]["FinishQty"].ToString());
            //    }

            //}
            //if (dtitemlastday_month_avg_C52.Rows[0]["FinishQtyavg"].ToString() != "" && dtitemlastday_month_avg_C52.Rows[0]["FinishQtyavg"].ToString() != "0" && dtitemlastday_month_avg_C52.Rows[0]["FinishQtyavg"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastday_month_avg_C52.Rows[0]["FinishQtyavg"].ToString()))
            //    {
            //        //lblLastdayFinish_C47_month_avg.Text = dtitemlastday_month_avg.Rows[0]["FinishQtyavg"].ToString() + " k" + " <span style='font-size: 8px;color:Black;'>" + "pdy" + "</span>";
            //        lblLastdayFinish_C52_month_avg.Text = GetLastMonthPDY(dtitemlastday_month_avg_C52.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:Black;'>" + "pdy" + "</span>";
            //        lblLastdayFinish_C52_month_avg.ForeColor = Color.Black;
            //    }
            //}

            //if (dtitemlastdaystitchv_month_val_C52.Rows[0]["FinishedValue"].ToString() != "" && dtitemlastdaystitchv_month_val_C52.Rows[0]["FinishedValue"].ToString() != "0" && dtitemlastdaystitchv_month_val_C52.Rows[0]["FinishedValue"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastdaystitchv_month_val_C52.Rows[0]["FinishedValue"].ToString()))
            //        lblLastdayFinishval_C52_month.Text = "<span style='color:green;'> " + "\u20B9 " + dtitemlastdaystitchv_month_val_C52.Rows[0]["FinishedValue"].ToString() + " Cr." + "</span>";
            //}
            //if (dtitemlastday_month_C52.Rows[0]["ShipQty"].ToString() != "" && dtitemlastday_month_C52.Rows[0]["ShipQty"].ToString() != "0" && dtitemlastday_month_C52.Rows[0]["ShipQty"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastday_month_C52.Rows[0]["ShipQty"].ToString()))
            //    {
            //        //llblLastdayShipQty_C47_month.Text = dtitemlastday_month.Rows[0]["ShipQty"].ToString() + " k";                   
            //        llblLastdayShipQty_C52_month.Text = Get(dtitemlastday_month_C52.Rows[0]["ShipQty"].ToString());
            //    }
            //}
            //if (dtitemlastday_month_C52.Rows[0]["ShipedValue"].ToString() != "" && dtitemlastday_month_C52.Rows[0]["ShipedValue"].ToString() != "0" && dtitemlastday_month_C52.Rows[0]["ShipedValue"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastday_month_C52.Rows[0]["ShipedValue"].ToString()))
            //        llblLastdayShipValue_C52_month.Text = "/ " + "<span style='color:green;'> " + "\u20B9 " + dtitemlastday_month_C52.Rows[0]["ShipedValue"].ToString() + " Cr." + "</span>";

            //}

            //if (dtitemlastday_month_C52.Rows[0]["PenaltyValue"].ToString() != "" && dtitemlastday_month_C52.Rows[0]["PenaltyValue"].ToString() != "0" && dtitemlastday_month_C52.Rows[0]["PenaltyValue"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday_month_C52.Rows[0]["PenaltyValue"].ToString()))
            //        lbllastdayPenalty_fob_C52_month.Text = "\u20B9 " + dtitemlastday_month_C52.Rows[0]["PenaltyValue"].ToString() + " Lk /";

            //}
            //if (dtitemlastday_month_C52.Rows[0]["PercentageFob"].ToString() != "" && dtitemlastday_month_C52.Rows[0]["PercentageFob"].ToString() != "0" && dtitemlastday_month_C52.Rows[0]["PercentageFob"].ToString() != "0.00" && dtitemlastday_month_C52.Rows[0]["PercentageFob"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastday_month_C52.Rows[0]["PercentageFob"].ToString()))
            //        lbllastdaypendingShipvalue_fob_C52_month.Text = dtitemlastday_month_C52.Rows[0]["PercentageFob"].ToString() + " %";
            //}
            //if (dtitemlastday_month_C52.Rows[0]["ctsl"].ToString() != "" && dtitemlastday_month_C52.Rows[0]["ctsl"].ToString() != "0" && dtitemlastday_month_C52.Rows[0]["ctsl"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastday_month_C52.Rows[0]["ctsl"].ToString()))
            //        lblLastdayShipCtsl_C52_month.Text = dtitemlastday_month_C52.Rows[0]["ctsl"].ToString() + " %";
            //    if (Convert.ToInt32(dtitemlastday_month_C52.Rows[0]["RescanQty"]) > 0)
            //        lblLastdayShipCtsl_C52_month.Text = lblLastdayShipCtsl_C52_month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(dtitemlastday_month_C52.Rows[0]["RescanQty"].ToString()) + " </span>";


            //}
            //if (dtitemlastday_month_C52.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_month_C52.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_month_C52.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemlastday_month_C52.Rows[0]["PendingShipQty"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday_month_C52.Rows[0]["PendingShipQty"].ToString()))
            //    {
            //        //lbllastdaypendingShipQty_C47_month.Text = dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() + " k";   
            //        lbllastdaypendingShipQty_C52_month.Text = Get(dtitemlastday_month_C52.Rows[0]["PendingShipQty"].ToString());
            //    }
            //}

            //if (dtitemlastday_month_C52.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_month_C52.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemlastday_month_C52.Rows[0]["PendingShipValue"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastday_month_C52.Rows[0]["PendingShipValue"].ToString()))
            //        lbllastdaypendingShipvalue_C52_month.Text = "<span style='color:green;'> \u20B9 " + dtitemlastday_month_C52.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

            //}
            ////last three month===========================================================//
            //if (dtitemlastday_lastthree_C52.Rows[0]["CutActual"].ToString() != "" && dtitemlastday_lastthree_C52.Rows[0]["CutActual"].ToString() != "0" && dtitemlastday_lastthree_C52.Rows[0]["CutActual"].ToString() != "0.0")
            //{
            //    if (Math.Round(Convert.ToDecimal(dtitemlastday_lastthree_C52.Rows[0]["CutActual"].ToString()), MidpointRounding.AwayFromZero) > 0)
            //    {
            //        lbllastdayCutQty_C52_3month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_lastthree_C52.Rows[0]["CutActual"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";
            //    }
            //}
            //if (dtavglastthree_C52.Rows[0]["CutQtyavg"].ToString() != "" && dtavglastthree_C52.Rows[0]["CutQtyavg"].ToString() != "0" && dtavglastthree_C52.Rows[0]["CutQtyavg"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtavglastthree_C52.Rows[0]["CutQtyavg"].ToString()))
            //    {
            //        lbllastdayCutQty_C52_3month_avg.Text = GetLastMonthPDY(dtavglastthree_C52.Rows[0]["CutQtyavg"].ToString()) + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
            //    }
            //}
            //if (dtitemlastday_lastthree_C52.Rows[0]["StitchQty"].ToString() != "" && dtitemlastday_lastthree_C52.Rows[0]["StitchQty"].ToString() != "0" && dtitemlastday_lastthree_C52.Rows[0]["StitchQty"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtitemlastday_lastthree_C52.Rows[0]["StitchQty"].ToString()))
            //    {
            //        if (Math.Round(Convert.ToDecimal(dtitemlastday_lastthree_C52.Rows[0]["StitchQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
            //        {

            //            lblLastdayStitchQty_C52_3month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_lastthree_C52.Rows[0]["StitchQty"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";

            //        }
            //    }
            //}
            //if (dtavglastthree_C52.Rows[0]["StitchQtyavg"].ToString() != "" && dtavglastthree_C52.Rows[0]["StitchQtyavg"].ToString() != "0" && dtavglastthree_C52.Rows[0]["StitchQtyavg"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtavglastthree_C52.Rows[0]["StitchQtyavg"].ToString()))
            //    {
            //        lblLastdayStitchQty_C52_3month_avg.Text = Get(dtavglastthree_C52.Rows[0]["StitchQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
            //    }
            //}
            //if (dtavglastthree_val_C52.Rows[0]["StitchedValue"].ToString() != "" && dtavglastthree_val_C52.Rows[0]["StitchedValue"].ToString() != "0" && dtavglastthree_val_C52.Rows[0]["StitchedValue"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtavglastthree_val_C52.Rows[0]["StitchedValue"].ToString()))
            //        lblLastdayStitchval_C52_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtavglastthree_val_C52.Rows[0]["StitchedValue"].ToString() + " Cr." + "</span>";

            //}
            //if (dtitemlastday_lastthree_C52.Rows[0]["FinishQty"].ToString() != "" && dtitemlastday_lastthree_C52.Rows[0]["FinishQty"].ToString() != "0" && dtitemlastday_lastthree_C52.Rows[0]["FinishQty"].ToString() != "0.0")
            //{

            //    if (Math.Round(Convert.ToDecimal(dtitemlastday_lastthree_C52.Rows[0]["FinishQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
            //    {

            //        lbllastdayCutQty_C52_3month.Text = Get(dtitemlastday_lastthree_C52.Rows[0]["FinishQty"].ToString());

            //    }
            //}
            //if (dtavglastthree_val_C52.Rows[0]["FinishedValue"].ToString() != "" && dtavglastthree_val_C52.Rows[0]["FinishedValue"].ToString() != "0" && dtavglastthree_val_C52.Rows[0]["FinishedValue"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtavglastthree_val_C52.Rows[0]["FinishedValue"].ToString()))
            //    {

            //        lbllastdayCutQty_C52_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtavglastthree_val_C52.Rows[0]["FinishedValue"].ToString() + " Cr." + "</span>";
            //    }
            //}

            //// last month====avg
            //if (dtavglastthree_C52.Rows[0]["FinishQtyavg"].ToString() != "" && dtavglastthree_C52.Rows[0]["FinishQtyavg"].ToString() != "0" && dtavglastthree_C52.Rows[0]["FinishQtyavg"].ToString() != "0.0")
            //{
            //    if (CheckZero(dtavglastthree_C52.Rows[0]["FinishQtyavg"].ToString()))
            //    {
            //        lblLastdayStitchQty_C52_3month_avg.Text = Get(dtavglastthree_C52.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
            //        lblLastdayStitchQty_C52_3month_avg.ForeColor = Color.Black;
            //    }

            //}
            //if (dtitemlastday_lastthree_C52.Rows[0]["ShipQty"].ToString() != "" && dtitemlastday_lastthree_C52.Rows[0]["ShipQty"].ToString() != "0" && dtitemlastday_lastthree_C52.Rows[0]["ShipQty"].ToString() != "0.0" && dtitemlastday_lastthree_C52.Rows[0]["ShipQty"].ToString() != "0.0")
            //{
            //    if (Math.Round((Convert.ToDecimal(dtitemlastday_lastthree_C52.Rows[0]["ShipQty"].ToString()) / 3), MidpointRounding.AwayFromZero) > 0)
            //    {
            //        lblLastdayStitchQty_C52_3month.Text = Math.Round((Convert.ToDecimal(Get(dtitemlastday_lastthree_C52.Rows[0]["ShipQty"].ToString()).Replace("k", "")) / 3), MidpointRounding.AwayFromZero) + " k";

            //    }
            //}
            //if (dtitemlastday_lastthree_C52.Rows[0]["ShipedValue"].ToString() != "" && dtitemlastday_lastthree_C52.Rows[0]["ShipedValue"].ToString() != "0" && dtitemlastday_lastthree_C52.Rows[0]["ShipedValue"].ToString() != "0.0" && dtitemlastday_lastthree_C52.Rows[0]["ShipedValue"].ToString() != "0.0")
            //{

            //    if (CheckZero(dtitemlastday_lastthree_C52.Rows[0]["ShipedValue"].ToString()))
            //    {
            //        if (Convert.ToDecimal(dtitemlastday_lastthree_C52.Rows[0]["ShipedValue"].ToString()) / 3 > 0)
            //        {
            //            lblLastdayStitchQty_C52_3month.Text = "/ " + "<span style='color:green;'> " + "\u20B9 " + Math.Round(Convert.ToDecimal(dtitemlastday_lastthree_C52.Rows[0]["ShipedValue"].ToString()) / 3, 1) + " Cr." + "</span>";
            //        }
            //    }
            //}
            //if (dtitemlastday_lastthree_C52.Rows[0]["PenaltyValue"].ToString() != "" && dtitemlastday_lastthree_C52.Rows[0]["PenaltyValue"].ToString() != "0" && dtitemlastday_lastthree_C52.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitemlastday_lastthree_C52.Rows[0]["PenaltyValue"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday_lastthree_C52.Rows[0]["PenaltyValue"].ToString()))
            //    {
            //        if ((Convert.ToDecimal(dtitemlastday_lastthree_C52.Rows[0]["PenaltyValue"].ToString()) / 3) > 0)
            //        {
            //            lbllast_threeMonth_Penalty_fob_C52_3month.Text = "\u20B9 " + Math.Round((Convert.ToDecimal(dtitemlastday_lastthree_C52.Rows[0]["PenaltyValue"].ToString()) / 3), 1) + " Lk /";
            //        }
            //    }

            //}
            //if (dtitemlastday_lastthree_C52.Rows[0]["PercentageFob"].ToString() != "" && dtitemlastday_lastthree_C52.Rows[0]["PercentageFob"].ToString() != "0" && dtitemlastday_lastthree_C52.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitemlastday_lastthree_C52.Rows[0]["PercentageFob"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday_lastthree_C52.Rows[0]["PercentageFob"].ToString()))
            //        lbllast_threeMonth_Penalty_fob_C52_3month.Text = dtitemlastday_lastthree_C52.Rows[0]["PercentageFob"].ToString() + " %";

            //}
            //if (dtitemlastday_lastthree_C52.Rows[0]["ctsl"].ToString() != "" && dtitemlastday_lastthree_C52.Rows[0]["ctsl"].ToString() != "0" && dtitemlastday_lastthree_C52.Rows[0]["ctsl"].ToString() != "0.0" && dtitemlastday_lastthree_C52.Rows[0]["ctsl"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday_lastthree_C52.Rows[0]["ctsl"].ToString()))
            //        llblLastdayShipQty_C52_3month.Text = dtitemlastday_lastthree_C52.Rows[0]["ctsl"].ToString() + " %";
            //    if (Convert.ToInt32(dtitemlastday_lastthree_C52.Rows[0]["RescanQty"]) > 0)
            //    {
            //        string RescanQty = Math.Round(Convert.ToDouble(((Convert.ToDouble(dtitemlastday_lastthree_C52.Rows[0]["RescanQty"].ToString())) / Convert.ToDouble(3))), 0, MidpointRounding.AwayFromZero).ToString();
            //        llblLastdayShipQty_C52_3month.Text = lblLastdayShipCtsl_C52_3month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(RescanQty) + " </span>";
            //    }
            //}
            //if (dtitemlastday_lastthree_C52.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_lastthree_C52.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_lastthree_C52.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemlastday_lastthree_C52.Rows[0]["PendingShipQty"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday_lastthree_C52.Rows[0]["PendingShipQty"].ToString()))
            //    {
            //        lbllastdaypendingShipQty_C52_3month.Text = GetLastMonthPDY(dtitemlastday_lastthree_C52.Rows[0]["PendingShipQty"].ToString());
            //    }
            //}
            //if (dtitemlastday_lastthree_C52.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_lastthree_C52.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemlastday_lastthree_C52.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemlastday_lastthree_C52.Rows[0]["PendingShipValue"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtitemlastday_lastthree_C52.Rows[0]["PendingShipValue"].ToString()))
            //        lbllastdaypendingShipQty_C52_3month.Text = "<span style='color:green;'> \u20B9 " + dtitemlastday_lastthree_C52.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

            //}
            ////if (dtwip_C52.Rows[0]["CutWip_k"].ToString() != "" && dtwip_C52.Rows[0]["CutWip_k"].ToString() != "0" && dtwip_C52.Rows[0]["CutWip_k"].ToString() != "0.00")
            ////{
            ////    if (Math.Round(Convert.ToDecimal(CheckZero(dtwip_C52.Rows[0]["CutWip_k"].ToString())), 0) > 0)
            ////    {
            //lblwipcutC52_K.Text = dtwip.Rows[0]["CutWIPPcs_C52"].ToString();
            ////    }
            ////}
            ////if (dtwip_C52.Rows[0]["CutWip"].ToString() != "" && dtwip_C52.Rows[0]["CutWip"].ToString() != "0" && dtwip_C52.Rows[0]["CutWip"].ToString() != "0.00")
            ////{
            ////    if (CheckZero(dtwip_C52.Rows[0]["CutWip"].ToString()))
            ////        lblwipcutC52.Text = Math.Round(Convert.ToDecimal(dtwip_C52.Rows[0]["CutWip"].ToString()), 0) + " D"; //+ " <span style='font-size: 8px;'>" + "D" + "</span>";

            ////}
            ////dswip = objadmin.GetWipDetails(96, "STITCHWIP");
            ////dtwip = dswip.Tables[0];
            ////if (dtwip.Rows[0]["StitchWip_k"].ToString() != "" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0.00")
            ////{
            ////    if (CheckZero(dtwip.Rows[0]["StitchWip_k"].ToString()))
            ////    {
            //lblwipstitchC52_K.Text = dtwip.Rows[0]["StitchWIPPcs_C52"].ToString();
            ////    }
            ////}
            ////if (dtwip.Rows[0]["StitchWip"].ToString() != "" && dtwip.Rows[0]["StitchWip"].ToString() != "0" && dtwip.Rows[0]["StitchWip"].ToString() != "0.00")
            ////{
            ////    if (CheckZero(dtwip.Rows[0]["StitchWip"].ToString()))
            ////        lblwipstitchC52.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["StitchWip"].ToString()), 0) + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
            ////}
            ////dswip = objadmin.GetWipDetails(96, "FINISHWIP");
            ////dtwip = dswip.Tables[0];
            ////if (dtwip.Rows[0]["FinishWip_k"].ToString() != "" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0.00")
            ////{
            ////    if (CheckZero(dtwip.Rows[0]["FinishWip_k"].ToString()))
            ////    {
            //lblwipfinishC52_K.Text = dtwip.Rows[0]["PackWIPPcs_C52"].ToString();
            ////    }
            ////}
            //// Pending Rescan value for C 47
            //dsPendingRescan = objadmin.GetWipDetails(96, "PENDING_RESCAN");
            //dtPendingRescan = dsPendingRescan.Tables[0];
            //if (dtPendingRescan.Rows[0]["RescanValue"].ToString() != "" && dtPendingRescan.Rows[0]["RescanValue"].ToString() != "0" && dtPendingRescan.Rows[0]["RescanValue"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtPendingRescan.Rows[0]["RescanValue"].ToString()))
            //    {
            //        lblPendingRescanC52_k.Text = Get(dtPendingRescan.Rows[0]["RescanValue"].ToString()) + " <span style='color:red; font-size: 8px;'>" + "" + "</span>";
            //    }
            //}
            //if (dtwip.Rows[0]["FinishWip"].ToString() != "" && dtwip.Rows[0]["FinishWip"].ToString() != "0" && dtwip.Rows[0]["FinishWip"].ToString() != "0.00")
            //{
            //    if (CheckZero(dtwip.Rows[0]["FinishWip"].ToString()))
            //    {
            //        // lblwipfinishC47.Text = dtwip.Rows[0]["FinishWip"].ToString() + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
            //        if (Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()) > 2)
            //        {
            //            lblwipfinishC52.Text = " <span style='font-weight: bold;color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D" + "</span>";
            //        }
            //        else
            //        {
            //            lblwipfinishC52.Text = " <span style='color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D" + "</span>";
            //        }
            //    }
            //}

            //-------------------------------------------BIPL---------------------------------------------------------------------

            DataSet dsbipl = new DataSet();
            dsbipl = objadmin.GetShipmentReportByValue(1, 1, 0);
            dtitemMonthBipl_Total = dsbipl.Tables[7];
            DataTable dtitembipl = new DataTable();
            DataTable dtitembiplLastday = new DataTable();
            dtitembipl = dsbipl.Tables[0];
            dtitembiplLastday = dsbipl.Tables[1];
            DataTable dtitemBIpllastday_month = dsbipl.Tables[2];
            DataTable dtitemBIpllastday_month_avg = dsbipl.Tables[3];

            //----------------------prabhaker code start---------------//
            DataTable dtitemBIpllastday_month_val = dsbipl.Tables[3];

            //-------------------end of prabhaker-------------------------//
            //====last three month===================================

            DataTable dtlastthreemonth = new DataTable();
            DataTable dtlastthreemonthavg = new DataTable();
            DataTable dtlastthreemonthval = new DataTable();

            dtlastthreemonth = dsbipl.Tables[4];
            dtlastthreemonthavg = dsbipl.Tables[5];
            dtlastthreemonthval = dsbipl.Tables[5];

            if (dtitembiplLastday.Rows[0]["CutActual"].ToString() != "" && dtitembiplLastday.Rows[0]["CutActual"].ToString() != "0" && dtitembiplLastday.Rows[0]["CutActual"].ToString() != "0.0" && dtitembiplLastday.Rows[0]["CutActual"].ToString() != "0.00")
            {
                if (CheckZero(dtitembiplLastday.Rows[0]["CutActual"].ToString()))
                {

                    lbllastdayCutQty_BIPL.Text = Get_WithDecimal(dtitembiplLastday.Rows[0]["CutActual"].ToString());
                }
            }

            if (dtitembiplLastday.Rows[0]["StitchQty"].ToString() != "" && dtitembiplLastday.Rows[0]["StitchQty"].ToString() != "0" && dtitembiplLastday.Rows[0]["StitchQty"].ToString() != "0.0" && dtitembiplLastday.Rows[0]["StitchQty"].ToString() != "0.00")
            {
                if (CheckZero(dtitembiplLastday.Rows[0]["StitchQty"].ToString()))
                {

                    lbllastdaystitchQty_BIPL.Text = Get_WithDecimal(dtitembiplLastday.Rows[0]["StitchQty"].ToString());
                }
            }
            if (dtitembiplLastday.Rows[0]["Stitchedvalue"].ToString() != "" && dtitembiplLastday.Rows[0]["Stitchedvalue"].ToString() != "0" && dtitembiplLastday.Rows[0]["Stitchedvalue"].ToString() != "0.00" && dtitembiplLastday.Rows[0]["Stitchedvalue"].ToString() != "0.0")
            {
                if (CheckZero(dtitembiplLastday.Rows[0]["Stitchedvalue"].ToString()))
                {
                    lbllastdaystitchval_BIPL.Text = "<span style='color:green;'> \u20B9 " + dtitembiplLastday.Rows[0]["Stitchedvalue"].ToString() + " Cr</span>";
                }
            }
            if (dtitembiplLastday.Rows[0]["FinishQty"].ToString() != "" && dtitembiplLastday.Rows[0]["FinishQty"].ToString() != "0" && dtitembiplLastday.Rows[0]["FinishQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitembiplLastday.Rows[0]["FinishQty"].ToString()))
                {

                    lblfinishQtylastday_BIPL.Text = Get_WithDecimal(dtitembiplLastday.Rows[0]["FinishQty"].ToString());
                }
            }
            if (dtitembiplLastday.Rows[0]["finishedvalue"].ToString() != "" && dtitembiplLastday.Rows[0]["finishedvalue"].ToString() != "0" && dtitembiplLastday.Rows[0]["finishedvalue"].ToString() != "0.00" && dtitembiplLastday.Rows[0]["finishedvalue"].ToString() != "0.0")
            {
                if (CheckZero(dtitembiplLastday.Rows[0]["finishedvalue"].ToString()))
                    lblfinishvallastday_BIPL.Text = "<span style='color:green;'>\u20B9 " + dtitembiplLastday.Rows[0]["finishedvalue"].ToString() + " Cr</span>";
            }
            if (dtitembiplLastday.Rows[0]["ShipQty"].ToString() != "" && dtitembiplLastday.Rows[0]["ShipQty"].ToString() != "0" && dtitembiplLastday.Rows[0]["ShipQty"].ToString() != "0.0")
            {


                lbllastdayShipQty_BIPL.Text = Get(dtitembiplLastday.Rows[0]["ShipQty"].ToString());
            }
            if (dtitembiplLastday.Rows[0]["ShipedValue"].ToString() != "" && dtitembiplLastday.Rows[0]["ShipedValue"].ToString() != "0" && dtitembiplLastday.Rows[0]["ShipedValue"].ToString() != "0.0" && dtitembiplLastday.Rows[0]["ShipedValue"].ToString() != "0.0")
            {

                lbllastdayShipVal_BIPL.Text = "/" + "<span style='color:green;'>\u20B9 " + dtitembiplLastday.Rows[0]["ShipedValue"].ToString() + " Cr.</span>";

            }
            if (dtitembiplLastday.Rows[0]["PenaltyValue"].ToString() != "" && dtitembiplLastday.Rows[0]["PenaltyValue"].ToString() != "0" && dtitembiplLastday.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitembiplLastday.Rows[0]["PenaltyValue"].ToString() != "0.00")
            {

                lblpendingPenaltyValue_fob_Bipl.Text = "\u20B9 " + dtitembiplLastday.Rows[0]["PenaltyValue"].ToString() + " Lk /";


            }
            if (dtitembiplLastday.Rows[0]["PercentageFob"].ToString() != "" && dtitembiplLastday.Rows[0]["PercentageFob"].ToString() != "0" && dtitembiplLastday.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitembiplLastday.Rows[0]["PercentageFob"].ToString() != "0.00")
            {

                lblpendingShipedshipedvalue_fob_Bipl.Text = dtitembiplLastday.Rows[0]["PercentageFob"].ToString() + " %";

            }
            if (dtitembiplLastday.Rows[0]["ctsl"].ToString() != "" && dtitembiplLastday.Rows[0]["ctsl"].ToString() != "0" && dtitembiplLastday.Rows[0]["ctsl"].ToString() != "0.0")
            {

                lbllastdayShipCtsl_BIPL.Text = dtitembiplLastday.Rows[0]["ctsl"].ToString() + "%";
            }
            if (dtitembiplLastday.Rows[0]["PendingShipQty"].ToString() != "" && dtitembiplLastday.Rows[0]["PendingShipQty"].ToString() != "0" && dtitembiplLastday.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitembiplLastday.Rows[0]["PendingShipQty"].ToString() != "0.00")
            {


                lblpendingshipedQtyBipl.Text = Get_WithDecimal(dtitembiplLastday.Rows[0]["PendingShipQty"].ToString());

            }
            if (dtitembiplLastday.Rows[0]["PendingShipValue"].ToString() != "" && dtitembiplLastday.Rows[0]["PendingShipValue"].ToString() != "0" && dtitembiplLastday.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitembiplLastday.Rows[0]["PendingShipValue"].ToString() != "0.00")
            {

                lblpendingShipedshipedvalueBipl.Text = "<span style='color:green;'> \u20B9 " + dtitembiplLastday.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

            }
            if (dtitemBIpllastday_month.Rows[0]["CutActual"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["CutActual"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["CutActual"].ToString() != "0.0" && dtitemBIpllastday_month.Rows[0]["CutActual"].ToString() != "0.00")
            {
                if (CheckZero(dtitemBIpllastday_month.Rows[0]["CutActual"].ToString()))
                {
                    lbllastdayCutQty_BIPL_month.Text = Get(dtitemBIpllastday_month.Rows[0]["CutActual"].ToString());
                }
            }
            if (dtitemBIpllastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "" && dtitemBIpllastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "0" && dtitemBIpllastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "0.0" && dtitemBIpllastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "0.00")
            {
                if (CheckZero(dtitemBIpllastday_month_avg.Rows[0]["CutQtyavg"].ToString()))
                {
                    lbllastdayCutQty_BIPL_month_avg.Text = Get(dtitemBIpllastday_month_avg.Rows[0]["CutQtyavg"].ToString().Replace("k", "")) + " k <span style='font-size: 8px;color:Black;'>pdy</span>";
                    lbllastdayCutQty_BIPL_month_avg.ForeColor = Color.Black;
                }
            }
            if (dtitemBIpllastday_month.Rows[0]["StitchQty"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["StitchQty"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["StitchQty"].ToString() != "0.0" && dtitemBIpllastday_month.Rows[0]["StitchQty"].ToString() != "0.00")
            {
                if (CheckZero(dtitemBIpllastday_month.Rows[0]["StitchQty"].ToString()))
                {
                    lbllastdaystitchQty_BIPL_month.Text = Math.Round(Convert.ToDecimal(Get(dtitemBIpllastday_month.Rows[0]["StitchQty"].ToString()).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";
                }

            }
            if (dtitemBIpllastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "" && dtitemBIpllastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "0" && dtitemBIpllastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtitemBIpllastday_month_avg.Rows[0]["StitchQtyavg"].ToString()))
                {
                    lbllastdaystitchQty_BIPL_month_avg.Text = GetLastMonthPDY(dtitemBIpllastday_month_avg.Rows[0]["StitchQtyavg"].ToString()) + " <span style='font-size: 8px;color:black;'> pdy</span>";
                }
            }
            if (dtitemBIpllastday_month_val.Rows[0]["StitchedValue"].ToString() != "" && dtitemBIpllastday_month_val.Rows[0]["StitchedValue"].ToString() != "0" && dtitemBIpllastday_month_val.Rows[0]["StitchedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemBIpllastday_month_val.Rows[0]["StitchedValue"].ToString()))
                    lbllastdaystitchval_BIPL_month.Text = "<span style='color:green;'>\u20B9 " + dtitemBIpllastday_month_val.Rows[0]["StitchedValue"].ToString() + " Cr.</span>";

            }
            if (dtitemBIpllastday_month.Rows[0]["FinishQty"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["FinishQty"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["FinishQty"].ToString() != "0.0")
            {
                if (CheckZero(dtitemBIpllastday_month.Rows[0]["FinishQty"].ToString()))
                {
                    lblfinishQtylastday_BIPL_month.Text = Math.Round(Convert.ToDecimal(Get(dtitemBIpllastday_month.Rows[0]["FinishQty"].ToString()).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";
                }
            }
            if (dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "" && dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0" && dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString()))
                {
                    lblfinishQtylastday_BIPL_month_avg.Text = GetLastMonthPDY(dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString()) + " <span style='font-size: 8px;color:Black;'>pdy</span>";
                    lblfinishQtylastday_BIPL_month_avg.ForeColor = Color.Black;
                }

            }
            if (dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString() != "" && dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString() != "0" && dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString() != "0.0")
            {
                if (CheckZero(dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString()))
                    lblfinishvallastday_BIPL_month.Text = "<span style='color:green;'> \u20B9 " + dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString() + " Cr.</span>";

            }
            if (dtitemBIpllastday_month.Rows[0]["ShipQty"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["ShipQty"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["ShipQty"].ToString() != "0.0")
            {
                lbllastdayShipQty_BIPL_month.Text = Math.Round((Convert.ToDecimal(Get(dtitemBIpllastday_month.Rows[0]["ShipQty"].ToString()).Replace("k", ""))), MidpointRounding.AwayFromZero) + " k";

            }
            if (dtitemBIpllastday_month.Rows[0]["ShipedValue"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["ShipedValue"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["ShipedValue"].ToString() != "0.0")
            {

                lbllastdayShipVal_BIPL_month.Text = "/" + "<span style='color:green;'> \u20B9 " + dtitemBIpllastday_month.Rows[0]["ShipedValue"].ToString() + " Cr.</span>";

            }
            if (Convert.ToInt32(dtitemBIpllastday_month.Rows[0]["PenaltyValue"]) > 0)
            {

                lblpendingPenaltyBipl_fob_month.Text = "\u20B9 " + dtitemBIpllastday_month.Rows[0]["PenaltyValue"].ToString() + " Lk /";

            }
            if (dtitemBIpllastday_month.Rows[0]["PercentageFob"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["PercentageFob"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["PercentageFob"].ToString() != "0.00" && dtitemBIpllastday_month.Rows[0]["PercentageFob"].ToString() != "0.0")
            {

                lblpendingShipedshipedvalueBipl_fob_month.Text = dtitemBIpllastday_month.Rows[0]["PercentageFob"].ToString() + " %";

            }
            if (dtitemBIpllastday_month.Rows[0]["ctsl"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["ctsl"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["ctsl"].ToString() != "0.0")
            {

                lbllastdayShipCtsl_BIPL_month.Text = dtitemBIpllastday_month.Rows[0]["ctsl"].ToString() + " %";
                if (Convert.ToInt32(dtitemBIpllastday_month.Rows[0]["RescanQty"]) > 0)
                    lbllastdayShipCtsl_BIPL_month.Text = lbllastdayShipCtsl_BIPL_month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(dtitemBIpllastday_month.Rows[0]["RescanQty"].ToString()) + " </span>";

            }
            if (dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() != "0.00")
            {

                lblpendingshipedQtyBipl_month.Text = Get(dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString()).Replace("k", "") + " k";

            }
            if (dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() != "0.00")
            {

                lblpendingShipedshipedvalueBipl_month.Text = "<span style='color:green;'> \u20B9 " + dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

            }
            // last three month
            if (dtlastthreemonth.Rows[0]["CutActual"].ToString() != "" && dtlastthreemonth.Rows[0]["CutActual"].ToString() != "0" && dtlastthreemonth.Rows[0]["CutActual"].ToString() != "0.0" && dtlastthreemonth.Rows[0]["CutActual"].ToString() != "0.00")
            {
                if (Math.Round(Convert.ToDecimal(dtlastthreemonth.Rows[0]["CutActual"].ToString()), MidpointRounding.AwayFromZero) > 0)
                {
                    lbllastdayCutQty_BIPL_3month.Text = Math.Round(Convert.ToDecimal(Get(dtlastthreemonth.Rows[0]["CutActual"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";
                }
            }
            if (dtlastthreemonthavg.Rows[0]["CutQtyavg"].ToString() != "" && dtlastthreemonthavg.Rows[0]["CutQtyavg"].ToString() != "0" && dtlastthreemonthavg.Rows[0]["CutQtyavg"].ToString() != "0.0" && dtlastthreemonthavg.Rows[0]["CutQtyavg"].ToString() != "0.00")
            {
                if (CheckZero(dtlastthreemonthavg.Rows[0]["CutQtyavg"].ToString()))
                {
                    lbllastdayCutQty_BIPL_3month_avg.Text = GetLastMonthPDY(dtlastthreemonthavg.Rows[0]["CutQtyavg"].ToString()) + "<span style='font-size: 8px;'> pdy</span>";
                    lbllastdayCutQty_BIPL_3month_avg.ForeColor = Color.Black;
                }
            }
            if (dtlastthreemonth.Rows[0]["StitchQty"].ToString() != "" && dtlastthreemonth.Rows[0]["StitchQty"].ToString() != "0" && dtlastthreemonth.Rows[0]["StitchQty"].ToString() != "0.0" && dtlastthreemonth.Rows[0]["StitchQty"].ToString() != "0.00")
            {
                if (Math.Round(Convert.ToDecimal(dtlastthreemonth.Rows[0]["StitchQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
                {
                    lbllastdaystitchQty_BIPL_3month.Text = Math.Round(Convert.ToDecimal(Get(dtlastthreemonth.Rows[0]["StitchQty"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";
                }
            }
            if (dtlastthreemonthavg.Rows[0]["StitchQtyavg"].ToString() != "" && dtlastthreemonthavg.Rows[0]["StitchQtyavg"].ToString() != "0" && dtlastthreemonthavg.Rows[0]["StitchQtyavg"].ToString() != "0.0")
            {
                if (CheckZero(dtlastthreemonthavg.Rows[0]["StitchQtyavg"].ToString()))
                {
                    lbllastdaystitchQty_BIPL_3month_avg.Text = Get(dtlastthreemonthavg.Rows[0]["StitchQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
                    lbllastdaystitchval_BIPL_3month.Text = "<span style='color:green;'>\u20B9 " + dtlastthreemonthavg.Rows[0]["StitchedValue"].ToString() + " Cr.</span>";
                }
            }
            if (dtlastthreemonth.Rows[0]["FinishQty"].ToString() != "" && dtlastthreemonth.Rows[0]["FinishQty"].ToString() != "0" && dtlastthreemonth.Rows[0]["FinishQty"].ToString() != "0.0" && dtlastthreemonth.Rows[0]["FinishQty"].ToString() != "0.00")
            {
                if (Math.Round(Convert.ToDecimal(dtlastthreemonth.Rows[0]["FinishQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
                {

                    lblfinishQtylastday_BIPL_3month.Text = Math.Round(Convert.ToDecimal(Get(dtlastthreemonth.Rows[0]["FinishQty"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";

                }
            }
            if (dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "" && dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0" && dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0.0")
            {

                lblfinishQtylastday_BIPL_3month_avg.Text = Get(dtlastthreemonthavg.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";

            }
            if (dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString() != "" && dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString() != "0" && dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString() != "0.0")
            {

                lblfinishvallastday_BIPL_3month.Text = "<span style='color:green;'> \u20B9 " + dtlastthreemonthval.Rows[0]["FinishedValue"].ToString() + " Cr.</span>";

            }
            if (dtlastthreemonth.Rows[0]["ShipQty"].ToString() != "" && dtlastthreemonth.Rows[0]["ShipQty"].ToString() != "0" && dtlastthreemonth.Rows[0]["ShipQty"].ToString() != "0.0")
            {
                if (Math.Round((Convert.ToDecimal(dtlastthreemonth.Rows[0]["ShipQty"].ToString()) / 3), MidpointRounding.AwayFromZero) > 0)
                {
                    lbllastdayShipQty_BIPL_3month.Text = Math.Round((Convert.ToDecimal(Get(dtlastthreemonth.Rows[0]["ShipQty"].ToString()).Replace("k", "")) / 3), MidpointRounding.AwayFromZero) + " k";
                }

            }
            if (dtlastthreemonth.Rows[0]["ShipedValue"].ToString() != "" && dtlastthreemonth.Rows[0]["ShipedValue"].ToString() != "0" && dtlastthreemonth.Rows[0]["ShipedValue"].ToString() != "0.0")
            {

                if (Convert.ToDecimal(dtlastthreemonth.Rows[0]["ShipedValue"].ToString()) / 3 > 0)
                {
                    lbllastdayShipVal_BIPL_3month.Text = "/" + "<span style='color:green;'> \u20B9 " + Math.Round(Convert.ToDecimal(dtlastthreemonth.Rows[0]["ShipedValue"].ToString()) / 3, 1) + " Cr.</span>";
                }

            }
            if (Convert.ToInt32(dtlastthreemonth.Rows[0]["PenaltyValue"]) > 0)
            {
                if (Convert.ToDecimal(dtlastthreemonth.Rows[0]["PenaltyValue"].ToString()) / 3 > 0)
                {
                    lbl_threeMonth_Penalty_Bipl_fob_3month.Text = "\u20B9 " + Math.Round(Convert.ToDecimal(dtlastthreemonth.Rows[0]["PenaltyValue"].ToString()) / 3, 1) + " Lk" + " /";
                }
            }
            if (dtlastthreemonth.Rows[0]["PercentageFob"].ToString() != "" && dtlastthreemonth.Rows[0]["PercentageFob"].ToString() != "0" && dtlastthreemonth.Rows[0]["PercentageFob"].ToString() != "0.00")
            {

                lblpendingShipedshipedvalueBipl_fob_3month.Text = dtlastthreemonth.Rows[0]["PercentageFob"].ToString() + " %";

            }
            if (dtitemBIpllastday_month.Rows[0]["ctsl"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["ctsl"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["ctsl"].ToString() != "0.0")
            {

                lbllastdayShipCtsl_BIPL_3month.Text = dtlastthreemonth.Rows[0]["ctsl"].ToString() + " %";
                if (Convert.ToInt32(dtlastthreemonth.Rows[0]["RescanQty"]) > 0)
                {
                    string RescanQty = Math.Round(Convert.ToDouble(((Convert.ToDouble(dtlastthreemonth.Rows[0]["RescanQty"].ToString())) / Convert.ToDouble(3))), 0, MidpointRounding.AwayFromZero).ToString();
                    lbllastdayShipCtsl_BIPL_3month.Text = lbllastdayShipCtsl_BIPL_3month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(RescanQty) + " </span>";
                }
            }
            if (dtlastthreemonth.Rows[0]["PendingShipQty"].ToString() != "" && dtlastthreemonth.Rows[0]["PendingShipQty"].ToString() != "0" && dtlastthreemonth.Rows[0]["PendingShipQty"].ToString() != "0.0")
            {

                lblpendingshipedQtyBipl_3month.Text = Get(dtlastthreemonth.Rows[0]["PendingShipQty"].ToString()).Replace("k", "") + " k";

            }
            if (dtlastthreemonth.Rows[0]["PendingShipValue"].ToString() != "" && dtlastthreemonth.Rows[0]["PendingShipValue"].ToString() != "0" && dtlastthreemonth.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtlastthreemonth.Rows[0]["PendingShipValue"].ToString() != "0.00")
            {

                lblpendingShipedshipedvalueBipl_3month.Text = "<span style='color:green;'> \u20B9 " + dtlastthreemonth.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

            }

            //dswip = objadmin.GetWipDetails(0, "CUTWIP");
            //dtwip = dswip.Tables[0];
            //if (dtwip.Rows[0]["CutWip_k"].ToString() != "" && dtwip.Rows[0]["CutWip_k"].ToString() != "0" && dtwip.Rows[0]["CutWip_k"].ToString() != "0.00")
            //{
            lblwipcutbipl_K.Text = dtwip.Rows[0]["CutWIPPcs_BIPL"].ToString();

            //}
            //if (dtwip.Rows[0]["CutWip"].ToString() != "" && dtwip.Rows[0]["CutWip"].ToString() != "0" && dtwip.Rows[0]["CutWip"].ToString() != "0.00")
            //{
            //    lblwipcutbipl.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["CutWip"].ToString()), 0) + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
            //}
            //dswip = objadmin.GetWipDetails(0, "STITCHWIP");
            //dtwip = dswip.Tables[0];
            //if (dtwip.Rows[0]["StitchWip_k"].ToString() != "" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0.00")
            //{

            lblwipstitchbipl_K.Text = dtwip.Rows[0]["StitchWIPPcs_BIPL"].ToString();
            //}
            //if (dtwip.Rows[0]["StitchWip"].ToString() != "" && dtwip.Rows[0]["StitchWip"].ToString() != "0" && dtwip.Rows[0]["StitchWip"].ToString() != "0.00")
            //{
            //    lblwipstitchbipl.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["StitchWip"].ToString()), 0) + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
            //}
            //dswip = objadmin.GetWipDetails(0, "FINISHWIP");
            //dtwip = dswip.Tables[0];
            //if (dtwip.Rows[0]["FinishWip_k"].ToString() != "" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0.00")
            //{
            lblwipfinishbipl_K.Text = dtwip.Rows[0]["PackWIPPcs_BIPL"].ToString();
            //}
            //if (dtwip.Rows[0]["FINISHWIP"].ToString() != "" && dtwip.Rows[0]["FINISHWIP"].ToString() != "0" && dtwip.Rows[0]["FINISHWIP"].ToString() != "0.00")
            //{
            //   if (Convert.ToDecimal(dtwip.Rows[0]["FINISHWIP"].ToString()) > 2)
            //    {

            //        lblwipfinishbipl.Text = " <span style='font-weight: bold;color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FINISHWIP"].ToString()), 0) + " D" + "</span>";
            //    }
            //    else
            //    {
            //        lblwipfinishbipl.Text = " <span style='color:black'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FINISHWIP"].ToString()), 0) + " D</span>";
            //    }
            //}

            // Pending Rescan value for BIPL
            dsPendingRescan = objadmin.GetWipDetails(0, "PENDING_RESCAN");
            dtPendingRescan = dsPendingRescan.Tables[0];
            if (dtPendingRescan.Rows[0]["RescanValue"].ToString() != "" && dtPendingRescan.Rows[0]["RescanValue"].ToString() != "0" && dtPendingRescan.Rows[0]["RescanValue"].ToString() != "0.00")
            {
                if (CheckZero(dtPendingRescan.Rows[0]["RescanValue"].ToString()))
                {
                    lblPendingRescanBIPL_k.Text = Get(dtPendingRescan.Rows[0]["RescanValue"].ToString()) + " <span style='color:red; font-size: 8px;'>" + "" + "</span>";
                }
            }

            dswip = objadmin.GetWipDetails(11, "FINISHWIPWORKINGDAYS");
            dtwip = dswip.Tables[0];
            if (dswip.Tables[0].Rows.Count > 0)
            {
                DateTime now = DateTime.Now;

                if ((Convert.ToDecimal(dtwip.Rows[0]["PedningWkDayCurrentMonth"].ToString())) > 0)
                {
                    lblpendingworkingdaymonth.Text = " <span style='color:Black'>" + now.ToString("MMM") + ": " + "</span>" + dtwip.Rows[0]["PedningWkDayCurrentMonth"].ToString() + " D";
                }
                if ((Convert.ToDecimal(dtwip.Rows[0]["PendingWkHourCUrrentMonth"].ToString())) > 0)
                {
                    lblpendingworkinghours.Text = "," + dtwip.Rows[0]["PendingWkHourCUrrentMonth"].ToString() + " Hr";
                }
                if ((Convert.ToDecimal(dtwip.Rows[0]["PedningWkDayTwoMonth"].ToString())) > 0)
                {
                    lblpeningwkday60.Text = " <span style='color:Black'>" + "2 M: " + "</span>" + dtwip.Rows[0]["PedningWkDayTwoMonth"].ToString() + " D";
                }
                if ((Convert.ToDecimal(dtwip.Rows[0]["PendingWkHourTwoMonth"].ToString())) > 0)
                {
                    lblpendingworkinghur60.Text = "," + dtwip.Rows[0]["PendingWkHourTwoMonth"].ToString() + " Hr";
                }
                if ((Convert.ToDecimal(dtwip.Rows[0]["UnStitchQty"].ToString())) > 0)
                {

                    lblunstitchQty60.Text = " <span style='color:Black'>" + "2 M: " + "</span>" + Get(dtwip.Rows[0]["UnStitchQty"].ToString());
                }
                if ((Convert.ToDecimal(dtwip.Rows[0]["PerDayUnStitQty"].ToString())) > 0)
                {
                    string result = string.Format("{0:0.0}", dtwip.Rows[0]["PerDayUnStitQty"].ToString());
                    lblunstitchQtyPerday.Text = "," + result + " k pdy";
                }
            }


        }

        // comment by bharat 6may
        //protected void gridshipemtNew_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.Footer)
        //        {
        //              e.Row.Visible = false;
        //            // TableRow tableRow = new TableRow();
        //            // TableCell cell1 = new TableCell();
        //            // cell1.Text = "Total";
        //            //// cell1.ColumnSpan = 8;
        //            // tableRow.Controls.Add(cell1);
        //            // cell1 = new TableCell();
        //            // cell1.Width = 70;
        //            // cell1.Text = "Sub";
        //            // tableRow.Controls.Add(cell1);
        //            // e.Row.NamingContainer.Controls.Add(tableRow);
        //            // You can add additional rows like this.
        //        }
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            e.Row.Visible = false;
        //           // int index = Convert.ToInt32(ViewState["CellIndex"]);

        //           // e.Row.Cells[index].Attributes["style"] = "display:none;max-height:0; mso-hide:all; overflow:hidden; font-size:0; line-height: 0 ";
        //           // e.Row.Cells[0].Attributes.Add("class", "not-for-outlook displaynonedt");

        //           // e.Row.Attributes.Add("class", "displaynonedt");
        //            Label lblWeekDayRange = (Label)e.Row.FindControl("lblWeekDayRange");
        //            HiddenField hdnweekMax = (HiddenField)e.Row.FindControl("hdnweekMax");
        //            HiddenField hdnweekMin = (HiddenField)e.Row.FindControl("hdnweekMin");

        //            HiddenField hdnqntyActual_45 = (HiddenField)e.Row.FindControl("hdnqntyActual_45");
        //            HiddenField hdncurrentweekActual = (HiddenField)e.Row.FindControl("hdncurrentweekActual");





        //            if (hdnweekMax != null && hdnweekMin != null)
        //            {
        //                if ((hdnweekMax.Value != "0" && hdnweekMax.Value != "") && (hdnweekMin.Value != "0" && hdnweekMin.Value != ""))
        //                {
        //                    string Strdaterange = "(" + hdnweekMax.Value + "-" + hdnweekMin.Value + ")";
        //                    lblWeekDayRange.Text = Strdaterange;
        //                }
        //            }
        //            DataSet ds = new DataSet();
        //            ds = objadmin.GetShipmentReportByValue(Convert.ToInt32(hdnweekMax.Value), Convert.ToInt32(hdnweekMin.Value), 3);

        //            DataTable dtitem = new DataTable();

        //            DataTable dtitemlastday = new DataTable();
        //            DataTable dtitemlastday_month = new DataTable();

        //            dtitem = ds.Tables[0];
        //            dtitemlastday = ds.Tables[1];
        //            dtitemlastday_month = ds.Tables[2];
        //            DataTable dtitemlastday_month_avg = ds.Tables[3];
        //            //--------------created by Prabhaker--------//               
        //            dtitemMonthC47_Total = ds.Tables[7];

        //            DataTable dtitemlastdaystitchv_month_val = ds.Tables[3];
        //            //----last three month-----//
        //            DataTable dtitemlastday_lastthree = new DataTable();
        //            DataTable dtavglastthree = new DataTable();
        //            //--------------created by Prabhaker--------//
        //            DataTable dtavglastthree_val = ds.Tables[5];
        //            //----last three month-----//
        //            dtitemlastday_lastthree = ds.Tables[4];
        //            dtavglastthree = ds.Tables[5];


        //            DataSet dswip = new DataSet();
        //            DataTable dtwip = new DataTable();

        //            dswip = objadmin.GetWipDetails(3, "CUTWIP");
        //            dtwip = dswip.Tables[0];

        //            //--------------------------------------C-47-------------------------------------------------------------------------
        //            Label lblutQty_47 = (Label)e.Row.FindControl("lblutQty_47");
        //            HiddenField hdnQty_47 = (HiddenField)e.Row.FindControl("hdnQty_47");
        //            HiddenField hdnQtyCutCtsl_C47 = (HiddenField)e.Row.FindControl("hdnQtyCutCtsl_C47");
        //            if ((hdnweekMax.Value != "0" && hdnweekMax.Value != "") && (hdnweekMin.Value != "0" && hdnweekMin.Value != ""))
        //            {
        //                if (dtitem.Rows[0]["CutActual"].ToString() != "" && dtitem.Rows[0]["CutActual"].ToString() != "0" && dtitem.Rows[0]["CutActual"].ToString() != "0.0" && dtitem.Rows[0]["CutActual"].ToString() != "0.00")
        //                {
        //                    {

        //                        lblutQty_47.Text = Get(dtitem.Rows[0]["CutActual"].ToString());
        //                        //hdnQty_47.Value = dtitem.Rows[0]["CutActual"].ToString();
        //                        hdnQty_47.Value = GetValueDivideByThousand(dtitem.Rows[0]["CutActual"].ToString());
        //                    }
        //                }

        //                if (dtitem.Rows[0]["CutQty"].ToString() != "" && dtitem.Rows[0]["CutQty"].ToString() != "0" && dtitem.Rows[0]["CutQty"].ToString() != "0.0" && dtitem.Rows[0]["CutQty"].ToString() != "0.00")
        //                {

        //                    // hdnQtyCutCtsl_C47.Value = dtitem.Rows[0]["CutQty"].ToString();
        //                    //hdnQtyCutCtsl_C47.Value = Get(dtitem.Rows[0]["CutQty"].ToString().Replace("k", "")).Replace("k", "");
        //                    hdnQtyCutCtsl_C47.Value = GetValueDivideByThousand(dtitem.Rows[0]["CutQty"].ToString());
        //                }

        //                // comment by bhrarat 6may

        //                ////if (dtitemlastday.Rows[0]["CutActual"].ToString() != "" && dtitemlastday.Rows[0]["CutActual"].ToString() != "0" && dtitemlastday.Rows[0]["CutActual"].ToString() != "0.0" && dtitemlastday.Rows[0]["CutActual"].ToString() != "0.00")
        //                ////{
        //                ////    if (CheckZero(dtitemlastday.Rows[0]["CutActual"].ToString()))
        //                ////    {
        //                ////        //lbllastdayCutQty_C47.Text = dtitemlastday.Rows[0]["CutActual"].ToString() + " k";
        //                ////        lbllastdayCutQty_C47.Text = Get_WithDecimal(dtitemlastday.Rows[0]["CutActual"].ToString());
        //                ////    }

        //                ////}

        //                //last month====
        //                //////if (dtitemlastday_month.Rows[0]["CutActual"].ToString() != "" && dtitemlastday_month.Rows[0]["CutActual"].ToString() != "0" && dtitemlastday_month.Rows[0]["CutActual"].ToString() != "0.0" && dtitemlastday_month.Rows[0]["CutActual"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtitemlastday_month.Rows[0]["CutActual"].ToString()))
        //                //////    {
        //                //////        //lbllastdayCutQty_C47_month.Text = Math.Round(Convert.ToDecimal(dtitemlastday_month.Rows[0]["CutActual"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //                //////        //lbllastdayCutQty_C47_month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_month.Rows[0]["CutActual"].ToString()).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //                //////        lbllastdayCutQty_C47_month.Text = Get(dtitemlastday_month.Rows[0]["CutActual"].ToString());
        //                //////    }
        //                //////}
        //                //last month====avg
        //                //////if (dtitemlastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "" && dtitemlastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "0" && dtitemlastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "0.0")
        //                //////{
        //                //////    if (CheckZero(dtitemlastday_month_avg.Rows[0]["CutQtyavg"].ToString()))
        //                //////    {
        //                //////        //lbllastdayCutQty_C47_month_avg.Text = dtitemlastday_month_avg.Rows[0]["CutQtyavg"].ToString() + " k" + " <span style='font-size: 8px;color:Gray;'>" + "pdy" + "</span>";
        //                //////        lbllastdayCutQty_C47_month_avg.Text = Get(dtitemlastday_month_avg.Rows[0]["CutQtyavg"].ToString()) + " k" + " <span style='font-size: 8px;color:Gray;'>" + "pdy" + "</span>";
        //                //////        lbllastdayCutQty_C47_month_avg.ForeColor = Color.Gray;
        //                //////    }
        //                //////}

        //                ////////last three month===========================================================//
        //                //////if (dtitemlastday_lastthree.Rows[0]["CutActual"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["CutActual"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["CutActual"].ToString() != "0.0")
        //                //////{
        //                //////    //lbllastdayCutQty_C47_3month.Text = dtitemlastday_lastthree.Rows[0]["CutActual"].ToString() + " k";

        //                //////    if (Math.Round(Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["CutActual"].ToString()), MidpointRounding.AwayFromZero) > 0)
        //                //////    {
        //                //////        //lbllastdayCutQty_C47_3month.Text = Math.Round(Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["CutActual"].ToString()), MidpointRounding.AwayFromZero) + " k";
        //                //////        lbllastdayCutQty_C47_3month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_lastthree.Rows[0]["CutActual"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";
        //                //////    }
        //                //////}
        //                //avg
        //                //////if (dtavglastthree.Rows[0]["CutQtyavg"].ToString() != "" && dtavglastthree.Rows[0]["CutQtyavg"].ToString() != "0" && dtavglastthree.Rows[0]["CutQtyavg"].ToString() != "0.0")
        //                //////{
        //                //////    if (CheckZero(dtavglastthree.Rows[0]["CutQtyavg"].ToString()))
        //                //////    {
        //                //////        //lbllastdayCutQty_C47_3month_avg.Text = dtavglastthree.Rows[0]["CutQtyavg"].ToString() + " k" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
        //                //////        lbllastdayCutQty_C47_3month_avg.Text = GetLastMonthPDY(dtavglastthree.Rows[0]["CutQtyavg"].ToString()) + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
        //                //////    }
        //                //////}
        //                //wip
        //                //////if (dtwip.Rows[0]["CutWip_k"].ToString() != "" && dtwip.Rows[0]["CutWip_k"].ToString() != "0" && dtwip.Rows[0]["CutWip_k"].ToString() != "0.00")
        //                //////{
        //                //////    if (Math.Round(Convert.ToDecimal(CheckZero(dtwip.Rows[0]["CutWip_k"].ToString())), 0) > 0)
        //                //////    {
        //                //////        //lblwipcutC47_K.Text = Math.Round(Convert.ToDecimal(CheckZero(dtwip.Rows[0]["CutWip_k"].ToString())), 0) + " k" + " <span style='font-size: 8px;'>" + "" + "</span>";
        //                //////        //lblwipcutC47_K.Text = Math.Round(Convert.ToDecimal(CheckZero(Get(dtwip.Rows[0]["CutWip_k"].ToString()))), 0) + "" + " <span style='font-size: 8px;'>" + "" + "</span>";
        //                //////        lblwipcutC47_K.Text = Get(dtwip.Rows[0]["CutWip_k"].ToString()) + " <span style='font-size: 8px;'>" + "" + "</span>";
        //                //////    }
        //                //////}
        //                //////if (dtwip.Rows[0]["CutWip"].ToString() != "" && dtwip.Rows[0]["CutWip"].ToString() != "0" && dtwip.Rows[0]["CutWip"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtwip.Rows[0]["CutWip"].ToString()))
        //                //////        lblwipcutC47.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["CutWip"].ToString()), 0) + " D"; //+ " <span style='font-size: 8px;'>" + "D" + "</span>";

        //                //////}
        //                //////dswip = objadmin.GetWipDetails(3, "STITCHWIP");
        //                //////dtwip = dswip.Tables[0];
        //                //////if (dtwip.Rows[0]["StitchWip_k"].ToString() != "" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtwip.Rows[0]["StitchWip_k"].ToString()))
        //                //////    {
        //                //////        lblwipstitchC47_K.Text = Get(dtwip.Rows[0]["StitchWip_k"].ToString()) + " <span style='font-size: 8px;'>" + "" + "</span>";
        //                //////    }
        //                //////}
        //                //////if (dtwip.Rows[0]["StitchWip"].ToString() != "" && dtwip.Rows[0]["StitchWip"].ToString() != "0" && dtwip.Rows[0]["StitchWip"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtwip.Rows[0]["StitchWip"].ToString()))
        //                //////        lblwipstitchC47.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["StitchWip"].ToString()), 0) + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
        //                //////}
        //                //////dswip = objadmin.GetWipDetails(3, "FINISHWIP");
        //                //////dtwip = dswip.Tables[0];
        //                //////if (dtwip.Rows[0]["FinishWip_k"].ToString() != "" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtwip.Rows[0]["FinishWip_k"].ToString()))
        //                //////    {
        //                //////        lblwipfinishC47_K.Text = Get(dtwip.Rows[0]["FinishWip_k"].ToString()) + " <span style='font-size: 8px;'>" + "" + "</span>";
        //                //////    }
        //                //////}
        //                //////if (dtwip.Rows[0]["FinishWip"].ToString() != "" && dtwip.Rows[0]["FinishWip"].ToString() != "0" && dtwip.Rows[0]["FinishWip"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtwip.Rows[0]["FinishWip"].ToString()))
        //                //////    {
        //                //////        // lblwipfinishC47.Text = dtwip.Rows[0]["FinishWip"].ToString() + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
        //                //////        if (Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()) > 2)
        //                //////        {
        //                //////            lblwipfinishC47.Text = " <span style='font-weight: bold;color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D" + "</span>";
        //                //////        }
        //                //////        else
        //                //////        {
        //                //////            lblwipfinishC47.Text = " <span style='color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D" + "</span>";
        //                //////        }
        //                //////    }
        //                //////}
        //                // Pending Rescan value for C 47
        //                //////dswip = objadmin.GetWipDetails(3, "PENDING_RESCAN");
        //                //////dtwip = dswip.Tables[0];
        //                //////if (dtwip.Rows[0]["RescanValue"].ToString() != "" && dtwip.Rows[0]["RescanValue"].ToString() != "0" && dtwip.Rows[0]["RescanValue"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtwip.Rows[0]["RescanValue"].ToString()))
        //                //////    {
        //                //////        lblPendingRescanC47_k.Text = Get(dtwip.Rows[0]["RescanValue"].ToString()) + " <span style='color:red; font-size: 8px;'>" + "" + "</span>";
        //                //////    }
        //                //////}

        //            }
        //            Label lblstitchQty_47 = (Label)e.Row.FindControl("lblstitchQty_47");
        //            HiddenField hdnstitchQty_47 = (HiddenField)e.Row.FindControl("hdnstitchQty_47");
        //            if (dtitem.Rows[0]["StitchQty"].ToString() != "" && dtitem.Rows[0]["StitchQty"].ToString() != "0" && dtitem.Rows[0]["StitchQty"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem.Rows[0]["StitchQty"].ToString()))
        //                {

        //                    lblstitchQty_47.Text = Get(dtitem.Rows[0]["StitchQty"].ToString());
        //                    //  hdnstitchQty_47.Value = Get(dtitem.Rows[0]["StitchQty"].ToString()).Replace("k", "");
        //                    hdnstitchQty_47.Value = GetValueDivideByThousand(dtitem.Rows[0]["StitchQty"].ToString());
        //                }

        //            }

        //            // comment by bhrarat 6may

        //            //////if (dtitemlastday.Rows[0]["StitchQty"].ToString() != "" && dtitemlastday.Rows[0]["StitchQty"].ToString() != "0" && dtitemlastday.Rows[0]["StitchQty"].ToString() != "0.0" && dtitemlastday.Rows[0]["StitchQty"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday.Rows[0]["StitchQty"].ToString()))
        //            //////    {
        //            //////        lblLastdayStitchQty_C47.Text = Get_WithDecimal(dtitemlastday.Rows[0]["StitchQty"].ToString());
        //            //////    }
        //            //////}

        //            //////if (dtitemlastday.Rows[0]["Stitchedvalue"].ToString() != "" && dtitemlastday.Rows[0]["Stitchedvalue"].ToString() != "0" && dtitemlastday.Rows[0]["Stitchedvalue"].ToString() != "0.00" && dtitemlastday.Rows[0]["Stitchedvalue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday.Rows[0]["Stitchedvalue"].ToString()))
        //            //////        lblLastdayStitchval_C47.Text = " \u20B9 " + dtitemlastday.Rows[0]["Stitchedvalue"].ToString() + " Cr.";

        //            //////}

        //            //////if (dtitemlastday.Rows[0]["finishedvalue"].ToString() != "" && dtitemlastday.Rows[0]["finishedvalue"].ToString() != "0" && dtitemlastday.Rows[0]["finishedvalue"].ToString() != "0.00" && dtitemlastday.Rows[0]["finishedvalue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday.Rows[0]["finishedvalue"].ToString()))
        //            //////        lblLastdayFinishVal_C47.Text = " \u20B9 " + dtitemlastday.Rows[0]["finishedvalue"].ToString() + " Cr.";

        //            //////}

        //            //last month====
        //            //////if (dtitemlastday_month.Rows[0]["StitchQty"].ToString() != "" && dtitemlastday_month.Rows[0]["StitchQty"].ToString() != "0" && dtitemlastday_month.Rows[0]["StitchQty"].ToString() != "0.0" && dtitemlastday_month.Rows[0]["StitchQty"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month.Rows[0]["StitchQty"].ToString()))
        //            //////    {

        //            //////        //lblLastdayStitchQty_C47_month.Text = Math.Round(Convert.ToDecimal(dtitemlastday_month.Rows[0]["StitchQty"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //            //////        lblLastdayStitchQty_C47_month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_month.Rows[0]["StitchQty"].ToString()).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";

        //            //////    }
        //            //////}
        //            //last month====avg
        //            //////if (dtitemlastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "" && dtitemlastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "0" && dtitemlastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "0.0" && dtitemlastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month_avg.Rows[0]["StitchQtyavg"].ToString()))
        //            //////    {

        //            //////        //  lblLastdayStitchQty_C47_month_avg.Text = Math.Round(Convert.ToDecimal(dtitemlastday_month_avg.Rows[0]["StitchQtyavg"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
        //            //////        lblLastdayStitchQty_C47_month_avg.Text = GetLastMonthPDY(dtitemlastday_month_avg.Rows[0]["StitchQtyavg"].ToString()) + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";


        //            //////    }
        //            //////}
        //            if (dtitem.Rows[0]["PercentageFob_month"].ToString() != "" && dtitem.Rows[0]["PercentageFob_month"].ToString() != "0" && dtitem.Rows[0]["PercentageFob_month"].ToString() != "0.0")
        //            {

        //                pedPendingVal_fob_47total = Convert.ToDouble(dtitem.Rows[0]["PercentageFob_month"].ToString());

        //            }

        //            //--------------created By Prabhaker-------------//

        //            //comment by bharat 7may
        //            //////if (dtitemlastdaystitchv_month_val.Rows[0]["StitchedValue"].ToString() != "" && dtitemlastdaystitchv_month_val.Rows[0]["StitchedValue"].ToString() != "0" && dtitemlastdaystitchv_month_val.Rows[0]["StitchedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastdaystitchv_month_val.Rows[0]["StitchedValue"].ToString()))
        //            //////        lblLastdayStitchval_C47_month.Text = " \u20B9 " + dtitemlastdaystitchv_month_val.Rows[0]["StitchedValue"].ToString() + " Cr.";

        //            //////}

        //            //if (dtitem.Rows[0]["PenaltyValue"].ToString() != "" && dtitem.Rows[0]["PenaltyValue"].ToString() != "0" && dtitem.Rows[0]["PenaltyValue"].ToString() != "0.0")
        //            //{

        //            //    PenaltyValue_47total = Convert.ToDouble(dtitem.Rows[0]["PenaltyValue"].ToString());

        //            //}


        //            //last three month=======================================================//
        //            //////if (dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString() != "0.0")
        //            //////{

        //            //////    //lblLastdayStitchQty_C47_3month.Text = dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString() + " k";
        //            //////    if (CheckZero(dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString()))
        //            //////    {
        //            //////        if (Math.Round(Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
        //            //////        {

        //            //////            //lblLastdayStitchQty_C47_3month.Text = Math.Round(Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString()), MidpointRounding.AwayFromZero) + " k";

        //            //////            lblLastdayStitchQty_C47_3month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";


        //            //////        }
        //            //////    }
        //            //////}
        //            //last avg
        //            //////if (dtavglastthree.Rows[0]["StitchQtyavg"].ToString() != "" && dtavglastthree.Rows[0]["StitchQtyavg"].ToString() != "0" && dtavglastthree.Rows[0]["StitchQtyavg"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtavglastthree.Rows[0]["StitchQtyavg"].ToString()))
        //            //////    {
        //            //////        //lblLastdayStitchQty_C47_3month_avg.Text = dtavglastthree.Rows[0]["StitchQtyavg"].ToString() + " k" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
        //            //////        lblLastdayStitchQty_C47_3month_avg.Text = Get(dtavglastthree.Rows[0]["StitchQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
        //            //////    }
        //            //////}
        //            //--------------created By Prabhaker-----------//
        //            //////if (dtavglastthree_val.Rows[0]["StitchedValue"].ToString() != "" && dtavglastthree_val.Rows[0]["StitchedValue"].ToString() != "0" && dtavglastthree_val.Rows[0]["StitchedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtavglastthree_val.Rows[0]["StitchedValue"].ToString()))
        //            //////        lblLastdayStitchval_C47_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtavglastthree_val.Rows[0]["StitchedValue"].ToString() + " Cr." + "</span>";

        //            //////}
        //            //-------end of prabhaker code----------------//

        //            Label lblFinishQty_47 = (Label)e.Row.FindControl("lblFinishQty_47");
        //            HiddenField hdnFinishQty_47 = (HiddenField)e.Row.FindControl("hdnFinishQty_47");
        //            if (dtitem.Rows[0]["Finish"].ToString() != "" && dtitem.Rows[0]["Finish"].ToString() != "0" && dtitem.Rows[0]["Finish"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem.Rows[0]["Finish"].ToString()))
        //                {

        //                    lblFinishQty_47.Text = Get(dtitem.Rows[0]["Finish"].ToString());
        //                    //hdnFinishQty_47.Value = Get(dtitem.Rows[0]["Finish"].ToString()).Replace("k", "");
        //                    hdnFinishQty_47.Value = GetValueDivideByThousand(dtitem.Rows[0]["Finish"].ToString());
        //                }
        //            }

        //            //comment by bharat 6may
        //            //////if (dtitemlastday.Rows[0]["FinishQty"].ToString() != "" && dtitemlastday.Rows[0]["FinishQty"].ToString() != "0" && dtitemlastday.Rows[0]["FinishQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday.Rows[0]["FinishQty"].ToString()))
        //            //////    {
        //            //////        lblLastdayFinish_C47.Text = Get_WithDecimal(dtitemlastday.Rows[0]["FinishQty"].ToString());
        //            //////    }
        //            //////}

        //            //last month====
        //            //////if (dtitemlastday_month.Rows[0]["FinishQty"].ToString() != "" && dtitemlastday_month.Rows[0]["FinishQty"].ToString() != "0" && dtitemlastday_month.Rows[0]["FinishQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month.Rows[0]["FinishQty"].ToString()))
        //            //////    {
        //            //////        //lblLastdayFinish_C47_month.Text = Math.Round(Convert.ToDecimal(dtitemlastday_month.Rows[0]["FinishQty"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //            //////        lblLastdayFinish_C47_month.Text = Get(dtitemlastday_month.Rows[0]["FinishQty"].ToString());
        //            //////    }

        //            //////}
        //            //last month====avg
        //            //////if (dtavglastthree.Rows[0]["FinishQtyavg"].ToString() != "" && dtavglastthree.Rows[0]["FinishQtyavg"].ToString() != "0" && dtavglastthree.Rows[0]["FinishQtyavg"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtavglastthree.Rows[0]["FinishQtyavg"].ToString()))
        //            //////    {
        //            //////        //lblLastdayFinish_C47_3month_avg.Text = dtavglastthree.Rows[0]["FinishQtyavg"].ToString() + " k" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
        //            //////        lblLastdayFinish_C47_3month_avg.Text = Get(dtavglastthree.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
        //            //////        lblLastdayFinish_C47_3month_avg.ForeColor = Color.Gray;
        //            //////    }

        //            //////}

        //            //----------------------created By Prabhaker------------//

        //            //////if (dtavglastthree_val.Rows[0]["FinishedValue"].ToString() != "" && dtavglastthree_val.Rows[0]["FinishedValue"].ToString() != "0" && dtavglastthree_val.Rows[0]["FinishedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtavglastthree_val.Rows[0]["FinishedValue"].ToString()))
        //            //////    {

        //            //////        lblLastdayFinishval_C47_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtavglastthree_val.Rows[0]["FinishedValue"].ToString() + " Cr." + "</span>";
        //            //////    }
        //            //////}

        //            //-----------------------end of prabhaker---------------//

        //            //last three month============================================================//
        //            //////if (dtitemlastday_lastthree.Rows[0]["FinishQty"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["FinishQty"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["FinishQty"].ToString() != "0.0")
        //            //////{
        //            //////    // lblLastdayFinish_C47_3month.Text = dtitemlastday_lastthree.Rows[0]["FinishQty"].ToString() + " k";

        //            //////    if (Math.Round(Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["FinishQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
        //            //////    {

        //            //////        //lblLastdayFinish_C47_3month.Text = Math.Round(Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["FinishQty"].ToString()), MidpointRounding.AwayFromZero) + " k";
        //            //////        lblLastdayFinish_C47_3month.Text = Get(dtitemlastday_lastthree.Rows[0]["FinishQty"].ToString());

        //            //////    }
        //            //////}
        //            //avg 

        //            //////if (dtitemlastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "" && dtitemlastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0" && dtitemlastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month_avg.Rows[0]["FinishQtyavg"].ToString()))
        //            //////    {
        //            //////        //lblLastdayFinish_C47_month_avg.Text = dtitemlastday_month_avg.Rows[0]["FinishQtyavg"].ToString() + " k" + " <span style='font-size: 8px;color:Gray;'>" + "pdy" + "</span>";
        //            //////        lblLastdayFinish_C47_month_avg.Text = GetLastMonthPDY(dtitemlastday_month_avg.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:Gray;'>" + "pdy" + "</span>";
        //            //////        lblLastdayFinish_C47_month_avg.ForeColor = Color.Gray;
        //            //////    }
        //            //////}

        //            //-----------------created By Prabhaker--------//

        //            //////if (dtitemlastdaystitchv_month_val.Rows[0]["FinishedValue"].ToString() != "" && dtitemlastdaystitchv_month_val.Rows[0]["FinishedValue"].ToString() != "0" && dtitemlastdaystitchv_month_val.Rows[0]["FinishedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastdaystitchv_month_val.Rows[0]["FinishedValue"].ToString()))
        //            //////        lblLastdayFinishval_C47_month.Text = "<span style='color:green;'> " + "\u20B9 " + dtitemlastdaystitchv_month_val.Rows[0]["FinishedValue"].ToString() + " Cr." + "</span>";
        //            //////}
        //            //----------end of prabhaker-----------//

        //            Label lblShipedQty_c47 = (Label)e.Row.FindControl("lblShipedQty_c47");
        //            HiddenField hdnShipedQty_47 = (HiddenField)e.Row.FindControl("hdnShipedQty_47");
        //            // edit by surendra
        //            HiddenField hdnPenalty_47 = (HiddenField)e.Row.FindControl("hdnPenalty_47");
        //            // end
        //            if (dtitem.Rows[0]["ShipQty"].ToString() != "" && dtitem.Rows[0]["ShipQty"].ToString() != "0" && dtitem.Rows[0]["ShipQty"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem.Rows[0]["ShipQty"].ToString()))
        //                {

        //                    //lblShipedQty_c47.Text = dtitem.Rows[0]["ShipQty"].ToString() + " k";                
        //                    // hdnShipedQty_47.Value = dtitem.Rows[0]["ShipQty"].ToString();
        //                    lblShipedQty_c47.Text = Get(dtitem.Rows[0]["ShipQty"].ToString());
        //                    //hdnShipedQty_47.Value = Get(dtitem.Rows[0]["ShipQty"].ToString()).Replace("k", "");
        //                    hdnShipedQty_47.Value = GetValueDivideByThousand(dtitem.Rows[0]["ShipQty"].ToString());
        //                }
        //            }
        //            // comment by bharat 6may
        //            //////if (dtitemlastday.Rows[0]["ShipQty"].ToString() != "" && dtitemlastday.Rows[0]["ShipQty"].ToString() != "0" && dtitemlastday.Rows[0]["ShipQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday.Rows[0]["ShipQty"].ToString()))
        //            //////    {
        //            //////        //llblLastdayShipQty_C47.Text = dtitemlastday.Rows[0]["ShipQty"].ToString() + " k";
        //            //////        llblLastdayShipQty_C47.Text = Get(dtitemlastday.Rows[0]["ShipQty"].ToString());

        //            //////    }
        //            //////}
        //            //last month====
        //            //////if (dtitemlastday_month.Rows[0]["ShipQty"].ToString() != "" && dtitemlastday_month.Rows[0]["ShipQty"].ToString() != "0" && dtitemlastday_month.Rows[0]["ShipQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month.Rows[0]["ShipQty"].ToString()))
        //            //////    {
        //            //////        //llblLastdayShipQty_C47_month.Text = dtitemlastday_month.Rows[0]["ShipQty"].ToString() + " k";                   
        //            //////        llblLastdayShipQty_C47_month.Text = Get(dtitemlastday_month.Rows[0]["ShipQty"].ToString());
        //            //////    }
        //            //////}
        //            //////if (dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString() != "0.0" && dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString() != "0.0")
        //            //////{

        //            //////    //llblLastdayShipQty_C47_3month.Text = dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString() + " k";

        //            //////    if (Math.Round((Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString()) / 3), MidpointRounding.AwayFromZero) > 0)
        //            //////    {
        //            //////        //llblLastdayShipQty_C47_3month.Text = Math.Round((Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString()) / 3), MidpointRounding.AwayFromZero) + " k";
        //            //////        llblLastdayShipQty_C47_3month.Text = Math.Round((Convert.ToDecimal(Get(dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString()).Replace("k", "")) / 3), MidpointRounding.AwayFromZero) + " k";

        //            //////    }
        //            //////}
        //            Label lblShipedVal_c47 = (Label)e.Row.FindControl("lblShipedVal_c47");
        //            HiddenField hdnhipedValQty = (HiddenField)e.Row.FindControl("hdnhipedValQty");
        //            if (dtitem.Rows[0]["ShipValue"].ToString() != "" && dtitem.Rows[0]["ShipValue"].ToString() != "0" && dtitem.Rows[0]["ShipValue"].ToString() != "0.0" && dtitem.Rows[0]["ShipValue"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem.Rows[0]["ShipValue"].ToString()))
        //                {
        //                    lblShipedVal_c47.Text = "/ <span style='color:green;'> " + " \u20B9 " + dtitem.Rows[0]["ShipValue"].ToString() + " Cr" + "</span>";

        //                    hdnhipedValQty.Value = dtitem.Rows[0]["ShipValue"].ToString();
        //                }
        //            }
        //            //comment by bharat 6may
        //            //////if (dtitemlastday.Rows[0]["ShipedValue"].ToString() != "" && dtitemlastday.Rows[0]["ShipedValue"].ToString() != "0" && dtitemlastday.Rows[0]["ShipedValue"].ToString() != "0.0" && dtitemlastday.Rows[0]["ShipedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday.Rows[0]["ShipedValue"].ToString()))
        //            //////        llblLastdayShipValue_C47.Text = "/" + "<span style='color:green;'> " + "\u20B9 " + dtitemlastday.Rows[0]["ShipedValue"].ToString() + " Cr." + "</span>";

        //            //////}

        //            //last month====
        //            //////if (dtitemlastday_month.Rows[0]["ShipedValue"].ToString() != "" && dtitemlastday_month.Rows[0]["ShipedValue"].ToString() != "0" && dtitemlastday_month.Rows[0]["ShipedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month.Rows[0]["ShipedValue"].ToString()))
        //            //////        llblLastdayShipValue_C47_month.Text = "/ " + "<span style='color:green;'> " + "\u20B9 " + dtitemlastday_month.Rows[0]["ShipedValue"].ToString() + " Cr." + "</span>";

        //            //////}
        //            //////if (dtitemlastday_lastthree.Rows[0]["ShipedValue"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["ShipedValue"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["ShipedValue"].ToString() != "0.0" && dtitemlastday_lastthree.Rows[0]["ShipedValue"].ToString() != "0.0")
        //            //////{

        //            //////    if (CheckZero(dtitemlastday_lastthree.Rows[0]["ShipedValue"].ToString()))
        //            //////    {
        //            //////        if (Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["ShipedValue"].ToString()) / 3 > 0)
        //            //////        {
        //            //////            llblLastdayShipValue_C47_3month.Text = "/ " + "<span style='color:green;'> " + "\u20B9 " + Math.Round(Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["ShipedValue"].ToString()) / 3, 1) + " Cr." + "</span>";
        //            //////        }
        //            //////    }
        //            //////}
        //            Label lblCtsl_c47 = (Label)e.Row.FindControl("lblCtsl_c47");
        //            HiddenField hdnCtsl_c47 = (HiddenField)e.Row.FindControl("hdnCtsl_c47");
        //            if (dtitem.Rows[0]["ShipCtsl"].ToString() != "" && dtitem.Rows[0]["ShipCtsl"].ToString() != "0" && dtitem.Rows[0]["ShipCtsl"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem.Rows[0]["ShipCtsl"].ToString()))
        //                {
        //                    lblCtsl_c47.Text = dtitem.Rows[0]["ShipCtsl"].ToString() + "%";
        //                    hdnCtsl_c47.Value = dtitem.Rows[0]["ShipCtsl"].ToString();
        //                }
        //            }
        //            // comment by bharat 6may
        //            //////if (dtitemlastday.Rows[0]["ctsl"].ToString() != "" && dtitemlastday.Rows[0]["ctsl"].ToString() != "0" && dtitemlastday.Rows[0]["ctsl"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday.Rows[0]["ctsl"].ToString()))
        //            //////    {
        //            //////        lblLastdayShipCtsl_C47.Text = dtitemlastday.Rows[0]["ctsl"].ToString() + "%";
        //            //////    }
        //            //////}

        //            //last month====
        //            //////if (dtitemlastday_month.Rows[0]["ctsl"].ToString() != "" && dtitemlastday_month.Rows[0]["ctsl"].ToString() != "0" && dtitemlastday_month.Rows[0]["ctsl"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month.Rows[0]["ctsl"].ToString()))
        //            //////        lblLastdayShipCtsl_C47_month.Text = dtitemlastday_month.Rows[0]["ctsl"].ToString() + " %";
        //            //////    if (Convert.ToInt32(dtitemlastday_month.Rows[0]["RescanQty"]) > 0)
        //            //////        lblLastdayShipCtsl_C47_month.Text = lblLastdayShipCtsl_C47_month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(dtitemlastday_month.Rows[0]["RescanQty"].ToString()) + " </span>";


        //            //////}
        //            //////if (dtitemlastday_lastthree.Rows[0]["ctsl"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["ctsl"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["ctsl"].ToString() != "0.0" && dtitemlastday_lastthree.Rows[0]["ctsl"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_lastthree.Rows[0]["ctsl"].ToString()))
        //            //////        lblLastdayShipCtsl_C47_3month.Text = dtitemlastday_lastthree.Rows[0]["ctsl"].ToString() + " %";
        //            //////    if (Convert.ToInt32(dtitemlastday_lastthree.Rows[0]["RescanQty"]) > 0)
        //            //////    {
        //            //////        string RescanQty = Math.Round(Convert.ToDouble(((Convert.ToDouble(dtitemlastday_lastthree.Rows[0]["RescanQty"].ToString())) / Convert.ToDouble(3))), 0, MidpointRounding.AwayFromZero).ToString();
        //            //////        lblLastdayShipCtsl_C47_3month.Text = lblLastdayShipCtsl_C47_3month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(RescanQty) + " </span>";
        //            //////    }




        //            //////}
        //            //if (lbllastdayCutQty_C47.Text != "" && llblLastdayShipQty_C47.Text != "")
        //            //{
        //            //    string C47Ctsl_lastday = Math.Round(Convert.ToDouble((Convert.ToDouble(lbllastdayCutQty_C47.Text.Replace(" k", "")) - Convert.ToDouble(llblLastdayShipQty_C47.Text.Replace(" k", ""))) / Convert.ToDouble(lbllastdayCutQty_C47.Text.Replace(" k", ""))), 1, MidpointRounding.AwayFromZero).ToString();
        //            //    lblLastdayShipCtsl_C47.Text = C47Ctsl_lastday == "0" ? "" : "(" + C47Ctsl_lastday + " % )"; ;

        //            //}
        //            Label lblShipedPendingQty_c47 = (Label)e.Row.FindControl("lblShipedPendingQty_c47");
        //            Label lblPndStitchQty_C47 = (Label)e.Row.FindControl("lblPndStitchQty_C47");
        //            HiddenField hdnShipedPendingQty_47 = (HiddenField)e.Row.FindControl("hdnShipedPendingQty_47");
        //            HiddenField hdnPndstitchQty_C47 = (HiddenField)e.Row.FindControl("hdnPndstitchQty_C47");
        //            if (dtitem.Rows[0]["PendingShipQty"].ToString() != "" && dtitem.Rows[0]["PendingShipQty"].ToString() != "0" && dtitem.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitem.Rows[0]["PendingShipQty"].ToString() != "0.00")
        //            {
        //                if (CheckZero(dtitem.Rows[0]["PendingShipQty"].ToString()))
        //                {




        //                    //lblShipedPendingQty_c47.Text = dtitem.Rows[0]["PendingShipQty"].ToString() + " k";
        //                    //hdnShipedPendingQty_47.Value = dtitem.Rows[0]["PendingShipQty"].ToString();

        //                    lblShipedPendingQty_c47.Text = Get(dtitem.Rows[0]["PendingShipQty"].ToString());
        //                    //hdnShipedPendingQty_47.Value = Get(dtitem.Rows[0]["PendingShipQty"].ToString()).Replace("k", "");
        //                    hdnShipedPendingQty_47.Value = GetValueDivideByThousand(dtitem.Rows[0]["PendingShipQty"].ToString());

        //                }
        //                //if (e.Row.RowIndex == 0)
        //                //{
        //                //    if (dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "0.0")
        //                //    {

        //                //        lblShipedPendingQty_c47.Text = lblShipedPendingQty_c47.Text + " (" + dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() + " k" + ")";

        //                //    }
        //                //}

        //            }
        //            if (dtitem.Rows[0]["PendingStitchQty"].ToString() != "" && dtitem.Rows[0]["PendingStitchQty"].ToString() != "0" && dtitem.Rows[0]["PendingStitchQty"].ToString() != "0.0" && dtitem.Rows[0]["PendingStitchQty"].ToString() != "0.00")
        //            {
        //                if (CheckZero(dtitem.Rows[0]["PendingStitchQty"].ToString()))
        //                {

        //                    //lblPndStitchQty_C47.Text = dtitem.Rows[0]["PendingStitchQty"].ToString() + " k";
        //                    //hdnPndstitchQty_C47.Value = dtitem.Rows[0]["PendingStitchQty"].ToString();

        //                    lblPndStitchQty_C47.Text = Get(dtitem.Rows[0]["PendingStitchQty"].ToString());
        //                    //hdnPndstitchQty_C47.Value = Get(dtitem.Rows[0]["PendingStitchQty"].ToString()).Replace("k", "");
        //                    hdnPndstitchQty_C47.Value = GetValueDivideByThousand(dtitem.Rows[0]["PendingStitchQty"].ToString());

        //                }
        //            }
        //            if (e.Row.RowIndex == 0)
        //            {
        //                if (dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "0.00" && dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "0.0")
        //                {
        //                    if (CheckZero(dtitemlastday_month.Rows[0]["PendingShipQty"].ToString()))
        //                    {
        //                        // lblShipedPendingQty_c47.Text = lblShipedPendingQty_c47.Text + " (" + dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() + " k" + ")";
        //                        lblShipedPendingQty_c47.Text = lblShipedPendingQty_c47.Text + " (" + Get(dtitemlastday_month.Rows[0]["PendingShipQty"].ToString()) + ")";
        //                    }
        //                }
        //            }
        //            // comment by bharat 6may
        //            //////if (dtitemlastday.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemlastday.Rows[0]["PendingShipQty"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday.Rows[0]["PendingShipQty"].ToString()))
        //            //////    {
        //            //////        //lbllastdaypendingShipQty_C47.Text = dtitemlastday.Rows[0]["PendingShipQty"].ToString() + " k";
        //            //////        lbllastdaypendingShipQty_C47.Text = Get_WithDecimal(dtitemlastday.Rows[0]["PendingShipQty"].ToString());
        //            //////    }
        //            //////}
        //            //last month====
        //            //////if (dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month.Rows[0]["PendingShipQty"].ToString()))
        //            //////    {
        //            //////        //lbllastdaypendingShipQty_C47_month.Text = dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() + " k";   
        //            //////        lbllastdaypendingShipQty_C47_month.Text = Get(dtitemlastday_month.Rows[0]["PendingShipQty"].ToString());
        //            //////    }
        //            //////}
        //            //////if (dtitemlastday_lastthree.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemlastday_lastthree.Rows[0]["PendingShipQty"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_lastthree.Rows[0]["PendingShipQty"].ToString()))
        //            //////    {

        //            //////        //lbllastdaypendingShipQty_C47_3month.Text = dtitemlastday_lastthree.Rows[0]["PendingShipQty"].ToString() + " k";
        //            //////        lbllastdaypendingShipQty_C47_3month.Text = GetLastMonthPDY(dtitemlastday_lastthree.Rows[0]["PendingShipQty"].ToString());
        //            //////    }
        //            //////}
        //            Label lblShipedPendingVal_c47 = (Label)e.Row.FindControl("lblShipedPendingVal_c47");
        //            HiddenField hdnShipedPendingVal_47 = (HiddenField)e.Row.FindControl("hdnShipedPendingVal_47");
        //            if (dtitem.Rows[0]["PendingShipValue"].ToString() != "" && dtitem.Rows[0]["PendingShipValue"].ToString() != "0" && dtitem.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitem.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //            {
        //                lblShipedPendingVal_c47.Text = "<span style='color:green;'> " + " \u20B9 " + dtitem.Rows[0]["PendingShipValue"].ToString() + " Cr. </span>";

        //                hdnShipedPendingVal_47.Value = dtitem.Rows[0]["PendingShipValue"].ToString();

        //                //if (e.Row.RowIndex == 0)
        //                //{
        //                //    if (dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() != "00")
        //                //    {
        //                //        lblShipedPendingVal_c47.Text = lblShipedPendingVal_c47.Text + " (" + "<span style='color:green;'> " + " \u20B9 " + dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() + " Cr" + ")"+"</span>";
        //                //    }
        //                //}
        //            }
        //            if (e.Row.RowIndex == 0)
        //            {
        //                if (dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //                {

        //                    lblShipedPendingVal_c47.Text = lblShipedPendingVal_c47.Text + "(<span style='color:green;'> \u20B9 " + dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() + " Cr. </span>)";
        //                }
        //            }
        //            Label lblShipedPendingVal_fob_c47 = (Label)e.Row.FindControl("lblShipedPendingVal_fob_c47");
        //            Label lblPenaltyTotal_fob_c47 = (Label)e.Row.FindControl("lblPenaltyTotal_fob_c47");
        //            HiddenField hdnfobpercentage_47 = (HiddenField)e.Row.FindControl("hdnfobpercentage_47");
        //            if (dtitem.Rows[0]["PercentageFob"].ToString() != "" && dtitem.Rows[0]["PercentageFob"].ToString() != "0" && dtitem.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitem.Rows[0]["PercentageFob"].ToString() != "0.00")
        //            {
        //                if (CheckZero(dtitem.Rows[0]["PercentageFob"].ToString()))
        //                    lblShipedPendingVal_fob_c47.Text = dtitem.Rows[0]["PercentageFob"].ToString() + " %";

        //                //hdnfobpercentage_47.Value = dtitem.Rows[0]["PercentageFob"].ToString() + " %";
        //            }
        //            if (dtitem.Rows[0]["PenaltyValue"].ToString() != "" && dtitem.Rows[0]["PenaltyValue"].ToString() != "0" && dtitem.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitem.Rows[0]["PenaltyValue"].ToString() != "0.00")
        //            {
        //                if (CheckZero(dtitem.Rows[0]["PenaltyValue"].ToString()))
        //                {
        //                    lblPenaltyTotal_fob_c47.Text = "<span style='color:red;'> \u20B9 " + dtitem.Rows[0]["PenaltyValue"].ToString() + " Lk </span> / ";
        //                    hdnPenalty_47.Value = dtitem.Rows[0]["PenaltyValue"].ToString();
        //                }
        //                //hdnfobpercentage_47.Value = dtitem.Rows[0]["PercentageFob"].ToString() + " %";
        //            }
        //            // comment by bharat 6may
        //            //////if (dtitemlastday.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemlastday.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemlastday.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday.Rows[0]["PendingShipValue"].ToString()))
        //            //////        lbllastdaypendingShipvalue_C47.Text = "<span style='color:green;'> \u20B9 " + dtitemlastday.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

        //            //////}
        //            //last month====
        //            //////if (dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month.Rows[0]["PendingShipValue"].ToString()))
        //            //////        lbllastdaypendingShipvalue_C47_month.Text = "<span style='color:green;'> \u20B9 " + dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

        //            //////}
        //            //////if (dtitemlastday_lastthree.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemlastday_lastthree.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_lastthree.Rows[0]["PendingShipValue"].ToString()))
        //            //////        lbllastdaypendingShipvalue_C47_3month.Text = "<span style='color:green;'> \u20B9 " + dtitemlastday_lastthree.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

        //            //////}
        //            //comment by bharat 6may
        //            //////if (dtitemlastday.Rows[0]["PercentageFob"].ToString() != "" && dtitemlastday.Rows[0]["PercentageFob"].ToString() != "0" && dtitemlastday.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitemlastday.Rows[0]["PercentageFob"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday.Rows[0]["PercentageFob"].ToString()))
        //            //////        lbllastdaypendingShipvalue_fob_C47.Text = dtitemlastday.Rows[0]["PercentageFob"].ToString() + " %";

        //            //////}

        //            //////if (dtitemlastday.Rows[0]["PenaltyValue"].ToString() != "" && dtitemlastday.Rows[0]["PenaltyValue"].ToString() != "0" && dtitemlastday.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitemlastday.Rows[0]["PenaltyValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday.Rows[0]["PenaltyValue"].ToString()))
        //            //////        lbllastdayPenaltyValue_fob_C47.Text = "\u20B9 " + dtitemlastday.Rows[0]["PenaltyValue"].ToString() + " Lk /";

        //            //////}


        //            //////if (dtitemlastday_month.Rows[0]["PercentageFob"].ToString() != "" && dtitemlastday_month.Rows[0]["PercentageFob"].ToString() != "0" && dtitemlastday_month.Rows[0]["PercentageFob"].ToString() != "0.00" && dtitemlastday_month.Rows[0]["PercentageFob"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month.Rows[0]["PercentageFob"].ToString()))
        //            //////        lbllastdaypendingShipvalue_fob_C47_month.Text = dtitemlastday_month.Rows[0]["PercentageFob"].ToString() + " %";
        //            //////}
        //            //////if (dtitemlastday_month.Rows[0]["PenaltyValue"].ToString() != "" && dtitemlastday_month.Rows[0]["PenaltyValue"].ToString() != "0" && dtitemlastday_month.Rows[0]["PenaltyValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month.Rows[0]["PenaltyValue"].ToString()))
        //            //////        lbllastdayPenalty_fob_C47_month.Text = "\u20B9 " + dtitemlastday_month.Rows[0]["PenaltyValue"].ToString() + " Lk /";

        //            //////}
        //            //////if (dtitemlastday_lastthree.Rows[0]["PercentageFob"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["PercentageFob"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitemlastday_lastthree.Rows[0]["PercentageFob"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_lastthree.Rows[0]["PercentageFob"].ToString()))
        //            //////        lbllastdaypendingShipvalue_fob_C47_3month.Text = dtitemlastday_lastthree.Rows[0]["PercentageFob"].ToString() + " %";

        //            //////}
        //            //////if (dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString() != "" && dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString() != "0" && dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString()))
        //            //////    {
        //            //////        //lbllast_threeMonth_Penalty_fob_C47_3month.Text = "\u20B9 " + dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString() + " Lk" + " /";
        //            //////        if ((Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString()) / 3) > 0)
        //            //////        {
        //            //////            lbllast_threeMonth_Penalty_fob_C47_3month.Text = "\u20B9 " + Math.Round((Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString()) / 3), 1) + " Lk /";
        //            //////        }
        //            //////    }

        //            //////}
        //            //--------------------------d 169 unit--------------------------------------------------------------------------------

        //            DataSet ds_169 = new DataSet();
        //            ds_169 = objadmin.GetShipmentReportByValue(Convert.ToInt32(hdnweekMax.Value), Convert.ToInt32(hdnweekMin.Value), 96);

        //            DataTable dtitem_169 = new DataTable();

        //            DataTable dtitemlastday_169 = new DataTable();
        //            DataTable dtitemlastday_month_169 = new DataTable();

        //            dtitem_169 = ds_169.Tables[0];
        //            dtitemlastday_169 = ds_169.Tables[1];
        //            dtitemlastday_month_169 = ds_169.Tables[2];
        //            DataTable dtitemlastday_month_avg_169 = ds_169.Tables[3];
        //            //--------------created by Prabhaker--------//               
        //            dtitemMonthD169_Total = ds_169.Tables[7];

        //            DataTable dtitemlastdaystitchv_month_val_169 = ds_169.Tables[3];
        //            //----last three month-----//
        //            DataTable dtitemlastday_lastthree_169 = new DataTable();
        //            DataTable dtavglastthree_169 = new DataTable();
        //            //--------------created by Prabhaker--------//
        //            DataTable dtavglastthree_val_169 = ds_169.Tables[5];
        //            //----last three month-----//
        //            dtitemlastday_lastthree_169 = ds_169.Tables[4];
        //            dtavglastthree_169 = ds_169.Tables[5];


        //            DataSet dswip_169 = new DataSet();
        //            DataTable dtwip_169 = new DataTable();

        //            dswip_169 = objadmin.GetWipDetails(96, "CUTWIP");
        //            dtwip_169 = dswip_169.Tables[0];


        //            Label lblCutQty_169 = (Label)e.Row.FindControl("lblCutQty_169");
        //            HiddenField hdnQty_169 = (HiddenField)e.Row.FindControl("hdnQty_169");
        //            HiddenField hdnQtyCutCtsl_169 = (HiddenField)e.Row.FindControl("hdnQtyCutCtsl_169");
        //            if ((hdnweekMax.Value != "0" && hdnweekMax.Value != "") && (hdnweekMin.Value != "0" && hdnweekMin.Value != ""))
        //            {
        //                if (dtitem_169.Rows[0]["CutActual"].ToString() != "" && dtitem_169.Rows[0]["CutActual"].ToString() != "0" && dtitem_169.Rows[0]["CutActual"].ToString() != "0.0" && dtitem_169.Rows[0]["CutActual"].ToString() != "0.00")
        //                {
        //                    {

        //                        lblCutQty_169.Text = Get(dtitem_169.Rows[0]["CutActual"].ToString());
        //                        //hdnQty_47.Value = dtitem.Rows[0]["CutActual"].ToString();
        //                        hdnQty_169.Value = GetValueDivideByThousand(dtitem_169.Rows[0]["CutActual"].ToString());
        //                    }
        //                }

        //                if (dtitem_169.Rows[0]["CutQty"].ToString() != "" && dtitem_169.Rows[0]["CutQty"].ToString() != "0" && dtitem_169.Rows[0]["CutQty"].ToString() != "0.0" && dtitem_169.Rows[0]["CutQty"].ToString() != "0.00")
        //                {

        //                    // hdnQtyCutCtsl_C47.Value = dtitem.Rows[0]["CutQty"].ToString();
        //                    //hdnQtyCutCtsl_C47.Value = Get(dtitem.Rows[0]["CutQty"].ToString().Replace("k", "")).Replace("k", "");
        //                    hdnQtyCutCtsl_169.Value = GetValueDivideByThousand(dtitem_169.Rows[0]["CutQty"].ToString());
        //                }

        //                // comment by bharat 6may
        //                //////if (dtitemlastday_169.Rows[0]["CutActual"].ToString() != "" && dtitemlastday_169.Rows[0]["CutActual"].ToString() != "0" && dtitemlastday_169.Rows[0]["CutActual"].ToString() != "0.0" && dtitemlastday_169.Rows[0]["CutActual"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtitemlastday.Rows[0]["CutActual"].ToString()))
        //                //////    {
        //                //////        //lbllastdayCutQty_C47.Text = dtitemlastday.Rows[0]["CutActual"].ToString() + " k";
        //                //////        lbllastdayCutQty_D169.Text = Get_WithDecimal(dtitemlastday_169.Rows[0]["CutActual"].ToString());

        //                //////    }

        //                //////}
        //                //last month====
        //                //////if (dtitemlastday_month_169.Rows[0]["CutActual"].ToString() != "" && dtitemlastday_month_169.Rows[0]["CutActual"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["CutActual"].ToString() != "0.0" && dtitemlastday_month_169.Rows[0]["CutActual"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtitemlastday_month_169.Rows[0]["CutActual"].ToString()))
        //                //////    {
        //                //////        //lbllastdayCutQty_C47_month.Text = Math.Round(Convert.ToDecimal(dtitemlastday_month.Rows[0]["CutActual"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //                //////        //lbllastdayCutQty_C47_month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_month.Rows[0]["CutActual"].ToString()).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //                //////        lbllastdayCutQty_D169_month.Text = Get(dtitemlastday_month_169.Rows[0]["CutActual"].ToString());
        //                //////    }
        //                //////}
        //                ////////last month====avg
        //                //////if (dtitemlastday_month_avg_169.Rows[0]["CutQtyavg"].ToString() != "" && dtitemlastday_month_avg_169.Rows[0]["CutQtyavg"].ToString() != "0" && dtitemlastday_month_avg_169.Rows[0]["CutQtyavg"].ToString() != "0.0")
        //                //////{
        //                //////    if (CheckZero(dtitemlastday_month_avg_169.Rows[0]["CutQtyavg"].ToString()))
        //                //////    {
        //                //////        //lbllastdayCutQty_C47_month_avg.Text = dtitemlastday_month_avg.Rows[0]["CutQtyavg"].ToString() + " k" + " <span style='font-size: 8px;color:Gray;'>" + "pdy" + "</span>";
        //                //////        lbllastdayCutQty_D169_month_avg.Text = Get(dtitemlastday_month_avg_169.Rows[0]["CutQtyavg"].ToString()) + " k" + " <span style='font-size: 8px;color:Gray;'>" + "pdy" + "</span>";
        //                //////        lbllastdayCutQty_D169_month_avg.ForeColor = Color.Gray;
        //                //////    }
        //                //////}

        //                ////////last three month===========================================================//
        //                //////if (dtitemlastday_lastthree_169.Rows[0]["CutActual"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["CutActual"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["CutActual"].ToString() != "0.0")
        //                //////{
        //                //////    //lbllastdayCutQty_C47_3month.Text = dtitemlastday_lastthree.Rows[0]["CutActual"].ToString() + " k";

        //                //////    if (Math.Round(Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["CutActual"].ToString()), MidpointRounding.AwayFromZero) > 0)
        //                //////    {
        //                //////        //lbllastdayCutQty_C47_3month.Text = Math.Round(Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["CutActual"].ToString()), MidpointRounding.AwayFromZero) + " k";
        //                //////        lbllastdayCutQty_D169_3month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_lastthree_169.Rows[0]["CutActual"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";
        //                //////    }
        //                //////}
        //                //avg
        //                //////if (dtavglastthree_169.Rows[0]["CutQtyavg"].ToString() != "" && dtavglastthree_169.Rows[0]["CutQtyavg"].ToString() != "0" && dtavglastthree_169.Rows[0]["CutQtyavg"].ToString() != "0.0")
        //                //////{
        //                //////    if (CheckZero(dtavglastthree_169.Rows[0]["CutQtyavg"].ToString()))
        //                //////    {
        //                //////        //lbllastdayCutQty_C47_3month_avg.Text = dtavglastthree.Rows[0]["CutQtyavg"].ToString() + " k" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
        //                //////        lbllastdayCutQty_D169_3month_avg.Text = GetLastMonthPDY(dtavglastthree_169.Rows[0]["CutQtyavg"].ToString()) + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
        //                //////    }
        //                //////}
        //                //wip
        //                //////if (dtwip_169.Rows[0]["CutWip_k"].ToString() != "" && dtwip_169.Rows[0]["CutWip_k"].ToString() != "0" && dtwip_169.Rows[0]["CutWip_k"].ToString() != "0.00")
        //                //////{
        //                //////    if (Math.Round(Convert.ToDecimal(CheckZero(dtwip_169.Rows[0]["CutWip_k"].ToString())), 0) > 0)
        //                //////    {
        //                //////        //lblwipcutC47_K.Text = Math.Round(Convert.ToDecimal(CheckZero(dtwip.Rows[0]["CutWip_k"].ToString())), 0) + " k" + " <span style='font-size: 8px;'>" + "" + "</span>";
        //                //////        //lblwipcutC47_K.Text = Math.Round(Convert.ToDecimal(CheckZero(Get(dtwip.Rows[0]["CutWip_k"].ToString()))), 0) + "" + " <span style='font-size: 8px;'>" + "" + "</span>";
        //                //////        lblwipcutD169_K.Text = Get(dtwip_169.Rows[0]["CutWip_k"].ToString()) + " <span style='font-size: 8px;'>" + "" + "</span>";
        //                //////    }
        //                //////}
        //                //////if (dtwip_169.Rows[0]["CutWip"].ToString() != "" && dtwip_169.Rows[0]["CutWip"].ToString() != "0" && dtwip_169.Rows[0]["CutWip"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtwip_169.Rows[0]["CutWip"].ToString()))
        //                //////        lblwipcutD169.Text = Math.Round(Convert.ToDecimal(dtwip_169.Rows[0]["CutWip"].ToString()), 0) + " D"; //+ " <span style='font-size: 8px;'>" + "D" + "</span>";

        //                //////}
        //                //////dswip = objadmin.GetWipDetails(96, "STITCHWIP");
        //                //////dtwip = dswip.Tables[0];
        //                //////if (dtwip.Rows[0]["StitchWip_k"].ToString() != "" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtwip.Rows[0]["StitchWip_k"].ToString()))
        //                //////    {
        //                //////        lblwipstitchD169_K.Text = Get(dtwip.Rows[0]["StitchWip_k"].ToString()) + " <span style='font-size: 8px;'>" + "" + "</span>";
        //                //////    }
        //                //////}
        //                //////if (dtwip.Rows[0]["StitchWip"].ToString() != "" && dtwip.Rows[0]["StitchWip"].ToString() != "0" && dtwip.Rows[0]["StitchWip"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtwip.Rows[0]["StitchWip"].ToString()))
        //                //////        lblwipstitchD169.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["StitchWip"].ToString()), 0) + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
        //                //////}
        //                //////dswip = objadmin.GetWipDetails(96, "FINISHWIP");
        //                //////dtwip = dswip.Tables[0];
        //                //////if (dtwip.Rows[0]["FinishWip_k"].ToString() != "" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtwip.Rows[0]["FinishWip_k"].ToString()))
        //                //////    {
        //                //////        lblwipfinishD169_K.Text = Get(dtwip.Rows[0]["FinishWip_k"].ToString()) + " <span style='font-size: 8px;'>" + "" + "</span>";
        //                //////    }
        //                //////}
        //                //////if (dtwip.Rows[0]["FinishWip"].ToString() != "" && dtwip.Rows[0]["FinishWip"].ToString() != "0" && dtwip.Rows[0]["FinishWip"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtwip.Rows[0]["FinishWip"].ToString()))
        //                //////    {
        //                //////        // lblwipfinishC47.Text = dtwip.Rows[0]["FinishWip"].ToString() + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
        //                //////        if (Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()) > 2)
        //                //////        {
        //                //////            lblwipfinishD169.Text = " <span style='font-weight: bold;color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D" + "</span>";
        //                //////        }
        //                //////        else
        //                //////        {
        //                //////            lblwipfinishD169.Text = " <span style='color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D" + "</span>";
        //                //////        }
        //                //////    }
        //                //////}
        //                //////// Pending Rescan value for C 47
        //                //////dswip = objadmin.GetWipDetails(96, "PENDING_RESCAN");
        //                //////dtwip = dswip.Tables[0];
        //                //////if (dtwip.Rows[0]["RescanValue"].ToString() != "" && dtwip.Rows[0]["RescanValue"].ToString() != "0" && dtwip.Rows[0]["RescanValue"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtwip.Rows[0]["RescanValue"].ToString()))
        //                //////    {
        //                //////        lblPendingRescanD169_k.Text = Get(dtwip.Rows[0]["RescanValue"].ToString()) + " <span style='color:red; font-size: 8px;'>" + "" + "</span>";
        //                //////    }
        //                //////}

        //            }
        //            Label lblstitchQty_169 = (Label)e.Row.FindControl("lblstitchQty_169");
        //            HiddenField hdnstitchQty_169 = (HiddenField)e.Row.FindControl("hdnstitchQty_169");
        //            if (dtitem_169.Rows[0]["StitchQty"].ToString() != "" && dtitem_169.Rows[0]["StitchQty"].ToString() != "0" && dtitem_169.Rows[0]["StitchQty"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem.Rows[0]["StitchQty"].ToString()))
        //                {

        //                    lblstitchQty_169.Text = Get(dtitem_169.Rows[0]["StitchQty"].ToString());
        //                    //  hdnstitchQty_47.Value = Get(dtitem.Rows[0]["StitchQty"].ToString()).Replace("k", "");
        //                    hdnstitchQty_169.Value = GetValueDivideByThousand(dtitem_169.Rows[0]["StitchQty"].ToString());
        //                }

        //            }
        //            // comment by bharat 6may
        //            //////if (dtitemlastday_169.Rows[0]["StitchQty"].ToString() != "" && dtitemlastday_169.Rows[0]["StitchQty"].ToString() != "0" && dtitemlastday_169.Rows[0]["StitchQty"].ToString() != "0.0" && dtitemlastday_169.Rows[0]["StitchQty"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_169.Rows[0]["StitchQty"].ToString()))
        //            //////    {
        //            //////        lblLastdayStitchQty_D169.Text = Get_WithDecimal(dtitemlastday_169.Rows[0]["StitchQty"].ToString());
        //            //////    }
        //            //////}
        //            //////if (dtitemlastday_169.Rows[0]["Stitchedvalue"].ToString() != "" && dtitemlastday_169.Rows[0]["Stitchedvalue"].ToString() != "0" && dtitemlastday_169.Rows[0]["Stitchedvalue"].ToString() != "0.00" && dtitemlastday_169.Rows[0]["Stitchedvalue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_169.Rows[0]["Stitchedvalue"].ToString()))
        //            //////        lblLastdayStitchval_D169.Text = " \u20B9 " + dtitemlastday_169.Rows[0]["Stitchedvalue"].ToString() + " Cr.";

        //            //////}
        //            //////if (dtitemlastday_169.Rows[0]["finishedvalue"].ToString() != "" && dtitemlastday_169.Rows[0]["finishedvalue"].ToString() != "0" && dtitemlastday_169.Rows[0]["finishedvalue"].ToString() != "0.00" && dtitemlastday_169.Rows[0]["finishedvalue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_169.Rows[0]["finishedvalue"].ToString()))
        //            //////        lblLastdayFinishVal_D169.Text = " \u20B9 " + dtitemlastday_169.Rows[0]["finishedvalue"].ToString() + " Cr.";

        //            //////}
        //            //last month====
        //            //////if (dtitemlastday_month_169.Rows[0]["StitchQty"].ToString() != "" && dtitemlastday_month_169.Rows[0]["StitchQty"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["StitchQty"].ToString() != "0.0" && dtitemlastday_month_169.Rows[0]["StitchQty"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month_169.Rows[0]["StitchQty"].ToString()))
        //            //////    {

        //            //////        //lblLastdayStitchQty_C47_month.Text = Math.Round(Convert.ToDecimal(dtitemlastday_month.Rows[0]["StitchQty"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //            //////        lblLastdayStitchQty_D169_month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_month_169.Rows[0]["StitchQty"].ToString()).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";

        //            //////    }
        //            //////}
        //            ////////last month====avg
        //            //////if (dtitemlastday_month_avg_169.Rows[0]["StitchQtyavg"].ToString() != "" && dtitemlastday_month_avg_169.Rows[0]["StitchQtyavg"].ToString() != "0" && dtitemlastday_month_avg_169.Rows[0]["StitchQtyavg"].ToString() != "0.0" && dtitemlastday_month_avg_169.Rows[0]["StitchQtyavg"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month_avg_169.Rows[0]["StitchQtyavg"].ToString()))
        //            //////    {

        //            //////        //  lblLastdayStitchQty_C47_month_avg.Text = Math.Round(Convert.ToDecimal(dtitemlastday_month_avg.Rows[0]["StitchQtyavg"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
        //            //////        lblLastdayStitchQty_D169_month_avg.Text = GetLastMonthPDY(dtitemlastday_month_avg_169.Rows[0]["StitchQtyavg"].ToString()) + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";


        //            //////    }
        //            //////}
        //            if (dtitem_169.Rows[0]["PercentageFob_month"].ToString() != "" && dtitem_169.Rows[0]["PercentageFob_month"].ToString() != "0" && dtitem_169.Rows[0]["PercentageFob_month"].ToString() != "0.0")
        //            {

        //                pedPendingVal_fob_169total = Convert.ToDouble(dtitem_169.Rows[0]["PercentageFob_month"].ToString());

        //            }

        //            //--------------created By Prabhaker-------------//

        //            //////if (dtitemlastdaystitchv_month_val_169.Rows[0]["StitchedValue"].ToString() != "" && dtitemlastdaystitchv_month_val_169.Rows[0]["StitchedValue"].ToString() != "0" && dtitemlastdaystitchv_month_val_169.Rows[0]["StitchedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastdaystitchv_month_val_169.Rows[0]["StitchedValue"].ToString()))
        //            //////        lblLastdayStitchval_D169_month.Text = " \u20B9 " + dtitemlastdaystitchv_month_val_169.Rows[0]["StitchedValue"].ToString() + " Cr.";

        //            //////}

        //            //if (dtitem.Rows[0]["PenaltyValue"].ToString() != "" && dtitem.Rows[0]["PenaltyValue"].ToString() != "0" && dtitem.Rows[0]["PenaltyValue"].ToString() != "0.0")
        //            //{

        //            //    PenaltyValue_47total = Convert.ToDouble(dtitem.Rows[0]["PenaltyValue"].ToString());

        //            //}


        //            //last three month=======================================================//
        //            //////if (dtitemlastday_lastthree_169.Rows[0]["StitchQty"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["StitchQty"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["StitchQty"].ToString() != "0.0")
        //            //////{

        //            //////    //lblLastdayStitchQty_C47_3month.Text = dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString() + " k";
        //            //////    if (CheckZero(dtitemlastday_lastthree_169.Rows[0]["StitchQty"].ToString()))
        //            //////    {
        //            //////        if (Math.Round(Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["StitchQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
        //            //////        {

        //            //////            //lblLastdayStitchQty_C47_3month.Text = Math.Round(Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["StitchQty"].ToString()), MidpointRounding.AwayFromZero) + " k";

        //            //////            lblLastdayStitchQty_D169_3month.Text = Math.Round(Convert.ToDecimal(Get(dtitemlastday_lastthree_169.Rows[0]["StitchQty"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";


        //            //////        }
        //            //////    }
        //            //////}
        //            //last avg
        //            //////if (dtavglastthree_169.Rows[0]["StitchQtyavg"].ToString() != "" && dtavglastthree_169.Rows[0]["StitchQtyavg"].ToString() != "0" && dtavglastthree_169.Rows[0]["StitchQtyavg"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtavglastthree_169.Rows[0]["StitchQtyavg"].ToString()))
        //            //////    {
        //            //////        //lblLastdayStitchQty_C47_3month_avg.Text = dtavglastthree.Rows[0]["StitchQtyavg"].ToString() + " k" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
        //            //////        lblLastdayStitchQty_D169_3month_avg.Text = Get(dtavglastthree_169.Rows[0]["StitchQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
        //            //////    }
        //            //////}
        //            //--------------created By Prabhaker-----------//
        //            //////if (dtavglastthree_val_169.Rows[0]["StitchedValue"].ToString() != "" && dtavglastthree_val_169.Rows[0]["StitchedValue"].ToString() != "0" && dtavglastthree_val_169.Rows[0]["StitchedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtavglastthree_val_169.Rows[0]["StitchedValue"].ToString()))
        //            //////        lblLastdayStitchval_D169_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtavglastthree_val_169.Rows[0]["StitchedValue"].ToString() + " Cr." + "</span>";

        //            //////}
        //            //-------end of prabhaker code----------------//

        //            Label lblFinishQty_169 = (Label)e.Row.FindControl("lblFinishQty_169");
        //            HiddenField hdnFinishQty_169 = (HiddenField)e.Row.FindControl("hdnFinishQty_169");
        //            if (dtitem_169.Rows[0]["Finish"].ToString() != "" && dtitem_169.Rows[0]["Finish"].ToString() != "0" && dtitem_169.Rows[0]["Finish"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem_169.Rows[0]["Finish"].ToString()))
        //                {

        //                    lblFinishQty_169.Text = Get(dtitem_169.Rows[0]["Finish"].ToString());
        //                    //hdnFinishQty_47.Value = Get(dtitem.Rows[0]["Finish"].ToString()).Replace("k", "");
        //                    hdnFinishQty_169.Value = GetValueDivideByThousand(dtitem_169.Rows[0]["Finish"].ToString());
        //                }
        //            }

        //            //comment by bharat 6may
        //            //////if (dtitemlastday_169.Rows[0]["FinishQty"].ToString() != "" && dtitemlastday_169.Rows[0]["FinishQty"].ToString() != "0" && dtitemlastday_169.Rows[0]["FinishQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_169.Rows[0]["FinishQty"].ToString()))
        //            //////    {
        //            //////        lblLastdayFinish_D169.Text = Get_WithDecimal(dtitemlastday_169.Rows[0]["FinishQty"].ToString());
        //            //////    }
        //            //////}
        //            //last month====
        //            //////if (dtitemlastday_month_169.Rows[0]["FinishQty"].ToString() != "" && dtitemlastday_month_169.Rows[0]["FinishQty"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["FinishQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month_169.Rows[0]["FinishQty"].ToString()))
        //            //////    {
        //            //////        //lblLastdayFinish_C47_month.Text = Math.Round(Convert.ToDecimal(dtitemlastday_month.Rows[0]["FinishQty"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //            //////        lblLastdayFinish_D169_month.Text = Get(dtitemlastday_month_169.Rows[0]["FinishQty"].ToString());
        //            //////    }

        //            //////}
        //            ////////last month====avg
        //            //////if (dtavglastthree_169.Rows[0]["FinishQtyavg"].ToString() != "" && dtavglastthree_169.Rows[0]["FinishQtyavg"].ToString() != "0" && dtavglastthree_169.Rows[0]["FinishQtyavg"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtavglastthree_169.Rows[0]["FinishQtyavg"].ToString()))
        //            //////    {
        //            //////        //lblLastdayFinish_C47_3month_avg.Text = dtavglastthree.Rows[0]["FinishQtyavg"].ToString() + " k" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
        //            //////        lblLastdayFinish_D169_3month_avg.Text = Get(dtavglastthree_169.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
        //            //////        lblLastdayFinish_D169_3month_avg.ForeColor = Color.Gray;
        //            //////    }

        //            //////}

        //            //----------------------created By Prabhaker------------//

        //            //////if (dtavglastthree_val_169.Rows[0]["FinishedValue"].ToString() != "" && dtavglastthree_val_169.Rows[0]["FinishedValue"].ToString() != "0" && dtavglastthree_val_169.Rows[0]["FinishedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtavglastthree_val_169.Rows[0]["FinishedValue"].ToString()))
        //            //////    {

        //            //////        lblLastdayFinishval_D169_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtavglastthree_val_169.Rows[0]["FinishedValue"].ToString() + " Cr." + "</span>";
        //            //////    }
        //            //////}

        //            //-----------------------end of prabhaker---------------//

        //            //last three month============================================================//
        //            //////if (dtitemlastday_lastthree_169.Rows[0]["FinishQty"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["FinishQty"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["FinishQty"].ToString() != "0.0")
        //            //////{
        //            //////    // lblLastdayFinish_C47_3month.Text = dtitemlastday_lastthree.Rows[0]["FinishQty"].ToString() + " k";

        //            //////    if (Math.Round(Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["FinishQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
        //            //////    {

        //            //////        //lblLastdayFinish_C47_3month.Text = Math.Round(Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["FinishQty"].ToString()), MidpointRounding.AwayFromZero) + " k";
        //            //////        lblLastdayFinish_D169_3month.Text = Get(dtitemlastday_lastthree_169.Rows[0]["FinishQty"].ToString());

        //            //////    }
        //            //////}
        //            //avg
        //            //////if (dtitemlastday_month_avg_169.Rows[0]["FinishQtyavg"].ToString() != "" && dtitemlastday_month_avg_169.Rows[0]["FinishQtyavg"].ToString() != "0" && dtitemlastday_month_avg_169.Rows[0]["FinishQtyavg"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month_avg_169.Rows[0]["FinishQtyavg"].ToString()))
        //            //////    {
        //            //////        //lblLastdayFinish_C47_month_avg.Text = dtitemlastday_month_avg.Rows[0]["FinishQtyavg"].ToString() + " k" + " <span style='font-size: 8px;color:Gray;'>" + "pdy" + "</span>";
        //            //////        lblLastdayFinish_D169_month_avg.Text = GetLastMonthPDY(dtitemlastday_month_avg_169.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:Gray;'>" + "pdy" + "</span>";
        //            //////        lblLastdayFinish_D169_month_avg.ForeColor = Color.Gray;
        //            //////    }
        //            //////}

        //            //-----------------created By Prabhaker--------//

        //            //////if (dtitemlastdaystitchv_month_val_169.Rows[0]["FinishedValue"].ToString() != "" && dtitemlastdaystitchv_month_val_169.Rows[0]["FinishedValue"].ToString() != "0" && dtitemlastdaystitchv_month_val_169.Rows[0]["FinishedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastdaystitchv_month_val_169.Rows[0]["FinishedValue"].ToString()))
        //            //////        lblLastdayFinishval_D169_month.Text = "<span style='color:green;'> " + "\u20B9 " + dtitemlastdaystitchv_month_val_169.Rows[0]["FinishedValue"].ToString() + " Cr." + "</span>";
        //            //////}
        //            //----------end of prabhaker-----------//

        //            Label lblShipedQty_D169 = (Label)e.Row.FindControl("lblShipedQty_D169");
        //            HiddenField hdnShipedQty_169 = (HiddenField)e.Row.FindControl("hdnShipedQty_169");
        //            // edit by surendra
        //            HiddenField hdnPenalty_169 = (HiddenField)e.Row.FindControl("hdnPenalty_169");
        //            // end
        //            if (dtitem_169.Rows[0]["ShipQty"].ToString() != "" && dtitem_169.Rows[0]["ShipQty"].ToString() != "0" && dtitem_169.Rows[0]["ShipQty"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem_169.Rows[0]["ShipQty"].ToString()))
        //                {

        //                    //lblShipedQty_c47.Text = dtitem.Rows[0]["ShipQty"].ToString() + " k";                
        //                    // hdnShipedQty_47.Value = dtitem.Rows[0]["ShipQty"].ToString();
        //                    lblShipedQty_D169.Text = Get(dtitem_169.Rows[0]["ShipQty"].ToString());
        //                    //hdnShipedQty_47.Value = Get(dtitem.Rows[0]["ShipQty"].ToString()).Replace("k", "");
        //                    hdnShipedQty_169.Value = GetValueDivideByThousand(dtitem_169.Rows[0]["ShipQty"].ToString());
        //                }
        //            }

        //            // comment by bharat 6may
        //            //////if (dtitemlastday_169.Rows[0]["ShipQty"].ToString() != "" && dtitemlastday_169.Rows[0]["ShipQty"].ToString() != "0" && dtitemlastday_169.Rows[0]["ShipQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_169.Rows[0]["ShipQty"].ToString()))
        //            //////    {
        //            //////        //llblLastdayShipQty_C47.Text = dtitemlastday.Rows[0]["ShipQty"].ToString() + " k";
        //            //////        llblLastdayShipQty_D169.Text = Get(dtitemlastday_169.Rows[0]["ShipQty"].ToString());

        //            //////    }
        //            //////}
        //            //last month====
        //            //////if (dtitemlastday_month_169.Rows[0]["ShipQty"].ToString() != "" && dtitemlastday_month_169.Rows[0]["ShipQty"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["ShipQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month_169.Rows[0]["ShipQty"].ToString()))
        //            //////    {
        //            //////        //llblLastdayShipQty_C47_month.Text = dtitemlastday_month.Rows[0]["ShipQty"].ToString() + " k";                   
        //            //////        llblLastdayShipQty_D169_month.Text = Get(dtitemlastday_month_169.Rows[0]["ShipQty"].ToString());
        //            //////    }
        //            //////}
        //            //////if (dtitemlastday_lastthree_169.Rows[0]["ShipQty"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["ShipQty"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["ShipQty"].ToString() != "0.0" && dtitemlastday_lastthree_169.Rows[0]["ShipQty"].ToString() != "0.0")
        //            //////{

        //            //////    //llblLastdayShipQty_C47_3month.Text = dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString() + " k";

        //            //////    if (Math.Round((Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["ShipQty"].ToString()) / 3), MidpointRounding.AwayFromZero) > 0)
        //            //////    {
        //            //////        //llblLastdayShipQty_C47_3month.Text = Math.Round((Convert.ToDecimal(dtitemlastday_lastthree.Rows[0]["ShipQty"].ToString()) / 3), MidpointRounding.AwayFromZero) + " k";
        //            //////        llblLastdayShipQty_D169_3month.Text = Math.Round((Convert.ToDecimal(Get(dtitemlastday_lastthree_169.Rows[0]["ShipQty"].ToString()).Replace("k", "")) / 3), MidpointRounding.AwayFromZero) + " k";

        //            //////    }
        //            //////}
        //            Label lblShipedVal_D169 = (Label)e.Row.FindControl("lblShipedVal_D169");
        //            HiddenField hdnhipedValQty_169 = (HiddenField)e.Row.FindControl("hdnhipedValQty_169");
        //            if (dtitem_169.Rows[0]["ShipValue"].ToString() != "" && dtitem_169.Rows[0]["ShipValue"].ToString() != "0" && dtitem_169.Rows[0]["ShipValue"].ToString() != "0.0" && dtitem_169.Rows[0]["ShipValue"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem_169.Rows[0]["ShipValue"].ToString()))
        //                {
        //                    lblShipedVal_D169.Text = "/ <span style='color:green;'> " + " \u20B9 " + dtitem_169.Rows[0]["ShipValue"].ToString() + " Cr" + "</span>";

        //                    hdnhipedValQty_169.Value = dtitem_169.Rows[0]["ShipValue"].ToString();
        //                }
        //            }

        //            // comment by bharat 6may
        //            //////if (dtitemlastday_169.Rows[0]["ShipedValue"].ToString() != "" && dtitemlastday_169.Rows[0]["ShipedValue"].ToString() != "0" && dtitemlastday_169.Rows[0]["ShipedValue"].ToString() != "0.0" && dtitemlastday_169.Rows[0]["ShipedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_169.Rows[0]["ShipedValue"].ToString()))
        //            //////        llblLastdayShipValue_D169.Text = "/" + "<span style='color:green;'> " + "\u20B9 " + dtitemlastday_169.Rows[0]["ShipedValue"].ToString() + " Cr." + "</span>";

        //            //////}
        //            //last month====
        //            ////if (dtitemlastday_month_169.Rows[0]["ShipedValue"].ToString() != "" && dtitemlastday_month_169.Rows[0]["ShipedValue"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["ShipedValue"].ToString() != "0.0")
        //            ////{
        //            ////    if (CheckZero(dtitemlastday_month_169.Rows[0]["ShipedValue"].ToString()))
        //            ////        llblLastdayShipValue_D169_month.Text = "/ " + "<span style='color:green;'> " + "\u20B9 " + dtitemlastday_month_169.Rows[0]["ShipedValue"].ToString() + " Cr." + "</span>";

        //            ////}
        //            //////if (dtitemlastday_lastthree_169.Rows[0]["ShipedValue"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["ShipedValue"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["ShipedValue"].ToString() != "0.0" && dtitemlastday_lastthree_169.Rows[0]["ShipedValue"].ToString() != "0.0")
        //            //////{

        //            //////    if (CheckZero(dtitemlastday_lastthree_169.Rows[0]["ShipedValue"].ToString()))
        //            //////    {
        //            //////        if (Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["ShipedValue"].ToString()) / 3 > 0)
        //            //////        {
        //            //////            llblLastdayShipValue_D169_3month.Text = "/ " + "<span style='color:green;'> " + "\u20B9 " + Math.Round(Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["ShipedValue"].ToString()) / 3, 1) + " Cr." + "</span>";
        //            //////        }
        //            //////    }
        //            //////}
        //            Label lblCtsl_D169 = (Label)e.Row.FindControl("lblCtsl_D169");
        //            HiddenField hdnCtsl_D169 = (HiddenField)e.Row.FindControl("hdnCtsl_D169");
        //            if (dtitem_169.Rows[0]["ShipCtsl"].ToString() != "" && dtitem_169.Rows[0]["ShipCtsl"].ToString() != "0" && dtitem_169.Rows[0]["ShipCtsl"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem_169.Rows[0]["ShipCtsl"].ToString()))
        //                {
        //                    lblCtsl_D169.Text = dtitem_169.Rows[0]["ShipCtsl"].ToString() + "%";
        //                    hdnCtsl_D169.Value = dtitem_169.Rows[0]["ShipCtsl"].ToString();
        //                }
        //            }

        //            // comment by bharat 6may
        //            if (dtitemlastday_169.Rows[0]["ctsl"].ToString() != "" && dtitemlastday_169.Rows[0]["ctsl"].ToString() != "0" && dtitemlastday_169.Rows[0]["ctsl"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitemlastday_169.Rows[0]["ctsl"].ToString()))
        //                {
        //                    lblLastdayShipCtsl_D169.Text = dtitemlastday_169.Rows[0]["ctsl"].ToString() + "%";
        //                }
        //            }
        //            //last month====
        //            //////if (dtitemlastday_month_169.Rows[0]["ctsl"].ToString() != "" && dtitemlastday_month_169.Rows[0]["ctsl"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["ctsl"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month_169.Rows[0]["ctsl"].ToString()))
        //            //////        lblLastdayShipCtsl_D169_month.Text = dtitemlastday_month_169.Rows[0]["ctsl"].ToString() + " %";
        //            //////    if (Convert.ToInt32(dtitemlastday_month_169.Rows[0]["RescanQty"]) > 0)
        //            //////        lblLastdayShipCtsl_D169_month.Text = lblLastdayShipCtsl_D169_month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(dtitemlastday_month_169.Rows[0]["RescanQty"].ToString()) + " </span>";


        //            //////}
        //            //////if (dtitemlastday_lastthree_169.Rows[0]["ctsl"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["ctsl"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["ctsl"].ToString() != "0.0" && dtitemlastday_lastthree_169.Rows[0]["ctsl"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_lastthree_169.Rows[0]["ctsl"].ToString()))
        //            //////        lblLastdayShipCtsl_D169_3month.Text = dtitemlastday_lastthree_169.Rows[0]["ctsl"].ToString() + " %";
        //            //////    if (Convert.ToInt32(dtitemlastday_lastthree_169.Rows[0]["RescanQty"]) > 0)
        //            //////    {
        //            //////        string RescanQty = Math.Round(Convert.ToDouble(((Convert.ToDouble(dtitemlastday_lastthree_169.Rows[0]["RescanQty"].ToString())) / Convert.ToDouble(3))), 0, MidpointRounding.AwayFromZero).ToString();
        //            //////        lblLastdayShipCtsl_D169_3month.Text = lblLastdayShipCtsl_D169_3month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(RescanQty) + " </span>";
        //            //////    }




        //            //////}
        //            //if (lbllastdayCutQty_C47.Text != "" && llblLastdayShipQty_C47.Text != "")
        //            //{
        //            //    string C47Ctsl_lastday = Math.Round(Convert.ToDouble((Convert.ToDouble(lbllastdayCutQty_C47.Text.Replace(" k", "")) - Convert.ToDouble(llblLastdayShipQty_C47.Text.Replace(" k", ""))) / Convert.ToDouble(lbllastdayCutQty_C47.Text.Replace(" k", ""))), 1, MidpointRounding.AwayFromZero).ToString();
        //            //    lblLastdayShipCtsl_C47.Text = C47Ctsl_lastday == "0" ? "" : "(" + C47Ctsl_lastday + " % )"; ;

        //            //}
        //            Label lblShipedPendingQty_D169 = (Label)e.Row.FindControl("lblShipedPendingQty_D169");
        //            Label lblPndStitchQty_D169 = (Label)e.Row.FindControl("lblPndStitchQty_D169");
        //            HiddenField hdnShipedPendingQty_169 = (HiddenField)e.Row.FindControl("hdnShipedPendingQty_169");
        //            HiddenField hdnPndstitchQty_D169 = (HiddenField)e.Row.FindControl("hdnPndstitchQty_D169");
        //            if (dtitem_169.Rows[0]["PendingShipQty"].ToString() != "" && dtitem_169.Rows[0]["PendingShipQty"].ToString() != "0" && dtitem_169.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitem_169.Rows[0]["PendingShipQty"].ToString() != "0.00")
        //            {
        //                if (CheckZero(dtitem_169.Rows[0]["PendingShipQty"].ToString()))
        //                {




        //                    //lblShipedPendingQty_c47.Text = dtitem.Rows[0]["PendingShipQty"].ToString() + " k";
        //                    //hdnShipedPendingQty_47.Value = dtitem.Rows[0]["PendingShipQty"].ToString();

        //                    lblShipedPendingQty_D169.Text = Get(dtitem_169.Rows[0]["PendingShipQty"].ToString());
        //                    //hdnShipedPendingQty_47.Value = Get(dtitem.Rows[0]["PendingShipQty"].ToString()).Replace("k", "");
        //                    hdnShipedPendingQty_169.Value = GetValueDivideByThousand(dtitem_169.Rows[0]["PendingShipQty"].ToString());

        //                }
        //                //if (e.Row.RowIndex == 0)
        //                //{
        //                //    if (dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() != "0.0")
        //                //    {

        //                //        lblShipedPendingQty_c47.Text = lblShipedPendingQty_c47.Text + " (" + dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() + " k" + ")";

        //                //    }
        //                //}

        //            }
        //            if (dtitem_169.Rows[0]["PendingStitchQty"].ToString() != "" && dtitem_169.Rows[0]["PendingStitchQty"].ToString() != "0" && dtitem_169.Rows[0]["PendingStitchQty"].ToString() != "0.0" && dtitem_169.Rows[0]["PendingStitchQty"].ToString() != "0.00")
        //            {
        //                if (CheckZero(dtitem_169.Rows[0]["PendingStitchQty"].ToString()))
        //                {

        //                    //lblPndStitchQty_C47.Text = dtitem.Rows[0]["PendingStitchQty"].ToString() + " k";
        //                    //hdnPndstitchQty_C47.Value = dtitem.Rows[0]["PendingStitchQty"].ToString();

        //                    lblPndStitchQty_D169.Text = Get(dtitem_169.Rows[0]["PendingStitchQty"].ToString());
        //                    //hdnPndstitchQty_C47.Value = Get(dtitem.Rows[0]["PendingStitchQty"].ToString()).Replace("k", "");
        //                    hdnPndstitchQty_D169.Value = GetValueDivideByThousand(dtitem_169.Rows[0]["PendingStitchQty"].ToString());

        //                }
        //            }
        //            if (e.Row.RowIndex == 0)
        //            {
        //                if (dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString() != "0.00" && dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString() != "0.0")
        //                {
        //                    if (CheckZero(dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString()))
        //                    {
        //                        // lblShipedPendingQty_c47.Text = lblShipedPendingQty_c47.Text + " (" + dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() + " k" + ")";
        //                        lblShipedPendingQty_D169.Text = lblShipedPendingQty_D169.Text + " (" + Get(dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString()) + ")";
        //                    }
        //                }
        //            }

        //            // comment by bharat 6may
        //            //////if (dtitemlastday_169.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_169.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_169.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemlastday_169.Rows[0]["PendingShipQty"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_169.Rows[0]["PendingShipQty"].ToString()))
        //            //////    {
        //            //////        //lbllastdaypendingShipQty_C47.Text = dtitemlastday.Rows[0]["PendingShipQty"].ToString() + " k";
        //            //////        lbllastdaypendingShipQty_D169.Text = Get_WithDecimal(dtitemlastday_169.Rows[0]["PendingShipQty"].ToString());
        //            //////    }
        //            //////}
        //            //last month====
        //            //////if (dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString()))
        //            //////    {
        //            //////        //lbllastdaypendingShipQty_C47_month.Text = dtitemlastday_month.Rows[0]["PendingShipQty"].ToString() + " k";   
        //            //////        lbllastdaypendingShipQty_D169_month.Text = Get(dtitemlastday_month_169.Rows[0]["PendingShipQty"].ToString());
        //            //////    }
        //            //////}
        //            //////if (dtitemlastday_lastthree_169.Rows[0]["PendingShipQty"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemlastday_lastthree_169.Rows[0]["PendingShipQty"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_lastthree_169.Rows[0]["PendingShipQty"].ToString()))
        //            //////    {

        //            //////        //lbllastdaypendingShipQty_C47_3month.Text = dtitemlastday_lastthree.Rows[0]["PendingShipQty"].ToString() + " k";
        //            //////        lbllastdaypendingShipQty_D169_3month.Text = GetLastMonthPDY(dtitemlastday_lastthree_169.Rows[0]["PendingShipQty"].ToString());
        //            //////    }
        //            //////}
        //            Label lblShipedPendingVal_D169 = (Label)e.Row.FindControl("lblShipedPendingVal_D169");
        //            HiddenField hdnShipedPendingVal_169 = (HiddenField)e.Row.FindControl("hdnShipedPendingVal_169");
        //            if (dtitem_169.Rows[0]["PendingShipValue"].ToString() != "" && dtitem_169.Rows[0]["PendingShipValue"].ToString() != "0" && dtitem_169.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitem_169.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //            {
        //                lblShipedPendingVal_D169.Text = "<span style='color:green;'> " + " \u20B9 " + dtitem_169.Rows[0]["PendingShipValue"].ToString() + " Cr. </span>";

        //                hdnShipedPendingVal_169.Value = dtitem_169.Rows[0]["PendingShipValue"].ToString();

        //                //if (e.Row.RowIndex == 0)
        //                //{
        //                //    if (dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() != "00")
        //                //    {
        //                //        lblShipedPendingVal_c47.Text = lblShipedPendingVal_c47.Text + " (" + "<span style='color:green;'> " + " \u20B9 " + dtitemlastday_month.Rows[0]["PendingShipValue"].ToString() + " Cr" + ")"+"</span>";
        //                //    }
        //                //}
        //            }
        //            if (e.Row.RowIndex == 0)
        //            {
        //                if (dtitemlastday_month_169.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_month_169.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemlastday_month_169.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //                {

        //                    lblShipedPendingVal_D169.Text = lblShipedPendingVal_D169.Text + "(<span style='color:green;'> \u20B9 " + dtitemlastday_month_169.Rows[0]["PendingShipValue"].ToString() + " Cr. </span>)";
        //                }
        //            }
        //            Label lblShipedPendingVal_fob_D169 = (Label)e.Row.FindControl("lblShipedPendingVal_fob_D169");
        //            Label lblPenaltyTotal_fob_D169 = (Label)e.Row.FindControl("lblPenaltyTotal_fob_D169");
        //            HiddenField hdnfobpercentage_169 = (HiddenField)e.Row.FindControl("hdnfobpercentage_169");
        //            if (dtitem_169.Rows[0]["PercentageFob"].ToString() != "" && dtitem_169.Rows[0]["PercentageFob"].ToString() != "0" && dtitem_169.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitem_169.Rows[0]["PercentageFob"].ToString() != "0.00")
        //            {
        //                if (CheckZero(dtitem_169.Rows[0]["PercentageFob"].ToString()))
        //                    lblShipedPendingVal_fob_D169.Text = dtitem_169.Rows[0]["PercentageFob"].ToString() + " %";

        //                //hdnfobpercentage_47.Value = dtitem.Rows[0]["PercentageFob"].ToString() + " %";
        //            }
        //            if (dtitem_169.Rows[0]["PenaltyValue"].ToString() != "" && dtitem_169.Rows[0]["PenaltyValue"].ToString() != "0" && dtitem_169.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitem_169.Rows[0]["PenaltyValue"].ToString() != "0.00")
        //            {
        //                if (CheckZero(dtitem_169.Rows[0]["PenaltyValue"].ToString()))
        //                {
        //                    lblPenaltyTotal_fob_D169.Text = "<span style='color:red;'> \u20B9 " + dtitem_169.Rows[0]["PenaltyValue"].ToString() + " Lk </span> / ";
        //                    hdnPenalty_169.Value = dtitem_169.Rows[0]["PenaltyValue"].ToString();
        //                }
        //                //hdnfobpercentage_47.Value = dtitem.Rows[0]["PercentageFob"].ToString() + " %";
        //            }

        //            // comment by bharat 6may
        //            //////if (dtitemlastday_169.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_169.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemlastday_169.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemlastday_169.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_169.Rows[0]["PendingShipValue"].ToString()))
        //            //////        lbllastdaypendingShipvalue_D169.Text = "<span style='color:green;'> \u20B9 " + dtitemlastday_169.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

        //            //////}
        //            //last month====
        //            //////if (dtitemlastday_month_169.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_month_169.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["PendingShipValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month_169.Rows[0]["PendingShipValue"].ToString()))
        //            //////        lbllastdaypendingShipvalue_D169_month.Text = "<span style='color:green;'> \u20B9 " + dtitemlastday_month_169.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

        //            //////}
        //            //////if (dtitemlastday_lastthree_169.Rows[0]["PendingShipValue"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemlastday_lastthree_169.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_lastthree_169.Rows[0]["PendingShipValue"].ToString()))
        //            //////        lbllastdaypendingShipvalue_D169_3month.Text = "<span style='color:green;'> \u20B9 " + dtitemlastday_lastthree_169.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

        //            //////}

        //            // comment by bharat 6may
        //            //////if (dtitemlastday_169.Rows[0]["PercentageFob"].ToString() != "" && dtitemlastday_169.Rows[0]["PercentageFob"].ToString() != "0" && dtitemlastday_169.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitemlastday_169.Rows[0]["PercentageFob"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_169.Rows[0]["PercentageFob"].ToString()))
        //            //////        lbllastdaypendingShipvalue_fob_D169.Text = dtitemlastday_169.Rows[0]["PercentageFob"].ToString() + " %";

        //            //////}

        //            // comment by bharat 6may
        //            //////if (dtitemlastday_169.Rows[0]["PenaltyValue"].ToString() != "" && dtitemlastday_169.Rows[0]["PenaltyValue"].ToString() != "0" && dtitemlastday_169.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitemlastday_169.Rows[0]["PenaltyValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_169.Rows[0]["PenaltyValue"].ToString()))
        //            //////        lbllastdayPenaltyValue_fob_D169.Text = "\u20B9 " + dtitemlastday_169.Rows[0]["PenaltyValue"].ToString() + " Lk /";

        //            //////}


        //            //////if (dtitemlastday_month_169.Rows[0]["PercentageFob"].ToString() != "" && dtitemlastday_month_169.Rows[0]["PercentageFob"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["PercentageFob"].ToString() != "0.00" && dtitemlastday_month_169.Rows[0]["PercentageFob"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month_169.Rows[0]["PercentageFob"].ToString()))
        //            //////        lbllastdaypendingShipvalue_fob_D169_month.Text = dtitemlastday_month_169.Rows[0]["PercentageFob"].ToString() + " %";
        //            //////}
        //            //////if (dtitemlastday_month_169.Rows[0]["PenaltyValue"].ToString() != "" && dtitemlastday_month_169.Rows[0]["PenaltyValue"].ToString() != "0" && dtitemlastday_month_169.Rows[0]["PenaltyValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_month_169.Rows[0]["PenaltyValue"].ToString()))
        //            //////        lbllastdayPenalty_fob_D169_month.Text = "\u20B9 " + dtitemlastday_month_169.Rows[0]["PenaltyValue"].ToString() + " Lk /";

        //            //////}
        //            //////if (dtitemlastday_lastthree_169.Rows[0]["PercentageFob"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["PercentageFob"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitemlastday_lastthree_169.Rows[0]["PercentageFob"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_lastthree_169.Rows[0]["PercentageFob"].ToString()))
        //            //////        lbllastdaypendingShipvalue_fob_D169_3month.Text = dtitemlastday_lastthree_169.Rows[0]["PercentageFob"].ToString() + " %";

        //            //////}
        //            //////if (dtitemlastday_lastthree_169.Rows[0]["PenaltyValue"].ToString() != "" && dtitemlastday_lastthree_169.Rows[0]["PenaltyValue"].ToString() != "0" && dtitemlastday_lastthree_169.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitemlastday_lastthree_169.Rows[0]["PenaltyValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemlastday_lastthree_169.Rows[0]["PenaltyValue"].ToString()))
        //            //////    {
        //            //////        //lbllast_threeMonth_Penalty_fob_C47_3month.Text = "\u20B9 " + dtitemlastday_lastthree.Rows[0]["PenaltyValue"].ToString() + " Lk" + " /";
        //            //////        if ((Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["PenaltyValue"].ToString()) / 3) > 0)
        //            //////        {
        //            //////            lbllast_threeMonth_Penalty_fob_D169_3month.Text = "\u20B9 " + Math.Round((Convert.ToDecimal(dtitemlastday_lastthree_169.Rows[0]["PenaltyValue"].ToString()) / 3), 1) + " Lk /";
        //            //////        }
        //            //////    }

        //            //////}
        //            //---------------------------end--------------------------------------------------------------------------------------
        //            //-------------------------------------------C-45/46---------------------------------------------------------------------
        //            DataSet ds4546 = new DataSet();
        //            ds4546 = objadmin.GetShipmentReportByValue(Convert.ToInt32(hdnweekMax.Value), Convert.ToInt32(hdnweekMin.Value), 11);

        //            DataTable dtitem4645 = new DataTable();
        //            DataTable dtitem4645lastday = new DataTable();
        //            DataTable dtitem4645lastday_month = new DataTable();
        //            dtitemMonthC4546_Total = ds4546.Tables[7];

        //            dtitem4645 = ds4546.Tables[0];
        //            dtitem4645lastday = ds4546.Tables[1];
        //            dtitem4645lastday_month = ds4546.Tables[2];
        //            DataTable dtitem4645lastday_month_avg = ds4546.Tables[3];
        //            DataTable dtitem4645lastday_month_val = ds4546.Tables[3];



        //            //last three month=================//

        //            DataTable dtlastthree_month = new DataTable();
        //            DataTable dtlastthree_monthavg = new DataTable();
        //            DataTable dtlastthree_monthval = new DataTable();
        //            dtlastthree_month = ds4546.Tables[4];
        //            dtlastthree_monthavg = ds4546.Tables[5];
        //            dtlastthree_monthval = ds4546.Tables[5];
        //            Label lblutQty_4546 = (Label)e.Row.FindControl("lblutQty_4546");
        //            HiddenField hdnQty_4546 = (HiddenField)e.Row.FindControl("hdnQty_4546");
        //            HiddenField hdnQtyCutCtsl_4546 = (HiddenField)e.Row.FindControl("hdnQtyCutCtsl_4546");
        //            if ((hdnweekMax.Value != "0" && hdnweekMax.Value != "") && (hdnweekMin.Value != "0" && hdnweekMin.Value != ""))
        //            {
        //                if (dtitem4645.Rows[0]["CutActual"].ToString() != "" && dtitem4645.Rows[0]["CutActual"].ToString() != "0" && dtitem4645.Rows[0]["CutActual"].ToString() != "0.0")
        //                {
        //                    if (CheckZero(dtitem4645.Rows[0]["CutActual"].ToString()))
        //                    {
        //                        //lblutQty_4546.Text = dtitem4645.Rows[0]["CutActual"].ToString() + " k";
        //                        //hdnQty_4546.Value = dtitem4645.Rows[0]["CutActual"].ToString();

        //                        lblutQty_4546.Text = Get(dtitem4645.Rows[0]["CutActual"].ToString());
        //                        //hdnQty_4546.Value = Get(dtitem4645.Rows[0]["CutActual"].ToString()).Replace("k", "");
        //                        hdnQty_4546.Value = GetValueDivideByThousand(dtitem4645.Rows[0]["CutActual"].ToString());

        //                    }
        //                }
        //                if (dtitem4645.Rows[0]["CutQty"].ToString() != "" && dtitem4645.Rows[0]["CutQty"].ToString() != "0" && dtitem4645.Rows[0]["CutQty"].ToString() != "0.0")
        //                {

        //                    //hdnQtyCutCtsl_4546.Value = dtitem4645.Rows[0]["CutQty"].ToString();
        //                    // hdnQtyCutCtsl_4546.Value = Get(dtitem4645.Rows[0]["CutQty"].ToString()).Replace("k", "");
        //                    hdnQtyCutCtsl_4546.Value = GetValueDivideByThousand(dtitem4645.Rows[0]["CutQty"].ToString());
        //                }

        //                // comment by bharat 6may
        //                ////if (dtitem4645lastday.Rows[0]["CutActual"].ToString() != "" && dtitem4645lastday.Rows[0]["CutActual"].ToString() != "0" && dtitem4645lastday.Rows[0]["CutActual"].ToString() != "0.0")
        //                ////{
        //                ////    if (CheckZero(dtitem4645lastday.Rows[0]["CutActual"].ToString()))
        //                ////    {
        //                ////        //lbllastCutQty_C4647.Text = dtitem4645lastday.Rows[0]["CutActual"].ToString() + " k";
        //                ////        lbllastCutQty_C4647.Text = Get_WithDecimal(dtitem4645lastday.Rows[0]["CutActual"].ToString());
        //                ////    }
        //                ////}
        //                //last month====
        //                //////if (dtitem4645lastday_month.Rows[0]["CutActual"].ToString() != "" && dtitem4645lastday_month.Rows[0]["CutActual"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["CutActual"].ToString() != "0.0")
        //                //////{
        //                //////    if (CheckZero(dtitem4645lastday_month.Rows[0]["CutActual"].ToString()))

        //                //////        // lbllastCutQty_C4647_month.Text = Math.Round(Convert.ToDecimal(dtitem4645lastday_month.Rows[0]["CutActual"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k";                       
        //                //////        // lbllastCutQty_C4647_month.Text = Math.Round(Convert.ToDecimal(Get(dtitem4645lastday_month.Rows[0]["CutActual"].ToString()).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //                //////        lbllastCutQty_C4647_month.Text = Get(dtitem4645lastday_month.Rows[0]["CutActual"].ToString());

        //                //////}
        //                //last month====avg
        //                //////if (dtitem4645lastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "" && dtitem4645lastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "0" && dtitem4645lastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "0.0")
        //                //////{
        //                //////    if (CheckZero(dtitem4645lastday_month_avg.Rows[0]["CutQtyavg"].ToString()))
        //                //////    {
        //                //////        //lbllastCutQty_C4647_month_avg.Text = dtitem4645lastday_month_avg.Rows[0]["CutQtyavg"].ToString() + " k" + " <span style='font-size: 8px;color:Gray;'>" + "pdy" + "</span>";
        //                //////        lbllastCutQty_C4647_month_avg.Text = GetLastMonthPDY(dtitem4645lastday_month_avg.Rows[0]["CutQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:Gray;'>" + "pdy" + "</span>";
        //                //////        lbllastCutQty_C4647_month_avg.ForeColor = Color.Gray;
        //                //////    }
        //                //////}
        //                if (dtitem4645.Rows[0]["PercentageFob_month"].ToString() != "" && dtitem4645.Rows[0]["PercentageFob_month"].ToString() != "0" && dtitem4645.Rows[0]["PercentageFob_month"].ToString() != "0.0")
        //                {

        //                    pedPendingVal_fob_46C47total = Convert.ToDouble(dtitem4645.Rows[0]["PercentageFob_month"].ToString());

        //                }
        //                //if (dtitem4645.Rows[0]["PenaltyValue"].ToString() != "" && dtitem4645.Rows[0]["PenaltyValue"].ToString() != "0" && dtitem4645.Rows[0]["PenaltyValue"].ToString() != "0.0")
        //                //{

        //                //    PenaltyValue_46C47total = Convert.ToDouble(dtitem4645.Rows[0]["PenaltyValue"].ToString());

        //                //}



        //                ////////last three month=================================================
        //                //////if (dtlastthree_month.Rows[0]["CutActual"].ToString() != "" && dtlastthree_month.Rows[0]["CutActual"].ToString() != "0" && dtlastthree_month.Rows[0]["CutActual"].ToString() != "0.0")
        //                //////{
        //                //////    //lbllastCutQty_C4647_3month.Text = dtlastthree_month.Rows[0]["CutActual"].ToString() + " k";
        //                //////    if (CheckZero(dtlastthree_month.Rows[0]["CutActual"].ToString()))
        //                //////    {
        //                //////        if (Math.Round(Convert.ToDecimal(dtlastthree_month.Rows[0]["CutActual"].ToString()), MidpointRounding.AwayFromZero) > 0)
        //                //////        {
        //                //////            //lbllastCutQty_C4647_3month.Text = Math.Round(Convert.ToDecimal(dtlastthree_month.Rows[0]["CutActual"].ToString()), MidpointRounding.AwayFromZero) + " k";
        //                //////            lbllastCutQty_C4647_3month.Text = Math.Round(Convert.ToDecimal(Get(dtlastthree_month.Rows[0]["CutActual"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";
        //                //////        }
        //                //////    }
        //                //////}
        //                //last month====avg
        //                //////if (dtlastthree_monthavg.Rows[0]["CutQtyavg"].ToString() != "" && dtlastthree_monthavg.Rows[0]["CutQtyavg"].ToString() != "0" && dtlastthree_monthavg.Rows[0]["CutQtyavg"].ToString() != "0.0")
        //                //////{
        //                //////    if (CheckZero(dtlastthree_monthavg.Rows[0]["CutQtyavg"].ToString()))
        //                //////    {
        //                //////        //lbllastCutQty_C4647_3month_avg.Text = dtlastthree_monthavg.Rows[0]["CutQtyavg"].ToString() + " k" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
        //                //////        lbllastCutQty_C4647_3month_avg.Text = Get(dtlastthree_monthavg.Rows[0]["CutQtyavg"].ToString()) + "" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
        //                //////    }
        //                //////}

        //            }
        //            Label lblstitchQty_4546 = (Label)e.Row.FindControl("lblstitchQty_4546");
        //            //Label lbllastStichedQty_C4647 = (Label)e.Row.FindControl("lbllastStichedQty_C4647");

        //            HiddenField hdnstitchQty_4546 = (HiddenField)e.Row.FindControl("hdnstitchQty_4546");
        //            if (dtitem4645.Rows[0]["StitchQty"].ToString() != "" && dtitem4645.Rows[0]["StitchQty"].ToString() != "0" && dtitem4645.Rows[0]["StitchQty"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem4645.Rows[0]["StitchQty"].ToString()))
        //                {
        //                    //lblstitchQty_4546.Text = dtitem4645.Rows[0]["StitchQty"].ToString() + " k";
        //                    //hdnstitchQty_4546.Value = dtitem4645.Rows[0]["StitchQty"].ToString();

        //                    lblstitchQty_4546.Text = Get(dtitem4645.Rows[0]["StitchQty"].ToString());
        //                    //hdnstitchQty_4546.Value = Get(dtitem4645.Rows[0]["StitchQty"].ToString()).Replace("k", "");
        //                    hdnstitchQty_4546.Value = GetValueDivideByThousand(dtitem4645.Rows[0]["StitchQty"].ToString());

        //                }
        //            }
        //            // comment by bharat 6may
        //            //////if (dtitem4645lastday.Rows[0]["StitchQty"].ToString() != "" && dtitem4645lastday.Rows[0]["StitchQty"].ToString() != "0" && dtitem4645lastday.Rows[0]["StitchQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday.Rows[0]["StitchQty"].ToString()))
        //            //////    {
        //            //////        //lbllastStichedQty_C4647.Text = dtitem4645lastday.Rows[0]["StitchQty"].ToString() + " k";
        //            //////        lbllastStichedQty_C4647.Text = Get_WithDecimal(dtitem4645lastday.Rows[0]["StitchQty"].ToString());
        //            //////    }
        //            //////}
        //            //////if (dtitem4645lastday.Rows[0]["Stitchedvalue"].ToString() != "" && dtitem4645lastday.Rows[0]["Stitchedvalue"].ToString() != "0" && dtitem4645lastday.Rows[0]["Stitchedvalue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday.Rows[0]["Stitchedvalue"].ToString()))
        //            //////        lbllastStichedVal_C4647.Text = "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday.Rows[0]["Stitchedvalue"].ToString() + " Cr." + "</span>";


        //            //////}
        //            //////if (dtitem4645lastday.Rows[0]["finishedvalue"].ToString() != "" && dtitem4645lastday.Rows[0]["finishedvalue"].ToString() != "0" && dtitem4645lastday.Rows[0]["finishedvalue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday.Rows[0]["finishedvalue"].ToString()))
        //            //////        lbllastFinishVal_C4647.Text = "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday.Rows[0]["finishedvalue"].ToString() + " Cr." + "</span>";


        //            //////}
        //            //last month====
        //            //////if (dtitem4645lastday_month.Rows[0]["StitchQty"].ToString() != "" && dtitem4645lastday_month.Rows[0]["StitchQty"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["StitchQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday_month.Rows[0]["StitchQty"].ToString()))
        //            //////        //lbllastStichedQty_C4647_month.Text = Math.Round(Convert.ToDecimal(dtitem4645lastday_month.Rows[0]["StitchQty"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //            //////        lbllastStichedQty_C4647_month.Text = Math.Round(Convert.ToDecimal(Get(dtitem4645lastday_month.Rows[0]["StitchQty"].ToString().Replace("k", "")).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";

        //            //////}
        //            ////////last month====avg
        //            //////if (dtitem4645lastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "" && dtitem4645lastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "0" && dtitem4645lastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday_month_avg.Rows[0]["StitchQtyavg"].ToString()))
        //            //////    {
        //            //////        // lbllastStichedQty_C4647_month_avg.Text = dtitem4645lastday_month_avg.Rows[0]["StitchQtyavg"].ToString() + " k" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
        //            //////        lbllastStichedQty_C4647_month_avg.Text = GetLastMonthPDY(dtitem4645lastday_month_avg.Rows[0]["StitchQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
        //            //////    }
        //            //////}
        //            //------------------created By Prabhaker-----------------//
        //            //////if (dtitem4645lastday_month_val.Rows[0]["StitchedValue"].ToString() != "" && dtitem4645lastday_month_val.Rows[0]["StitchedValue"].ToString() != "0" && dtitem4645lastday_month_val.Rows[0]["StitchedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday_month_val.Rows[0]["StitchedValue"].ToString()))
        //            //////        lbllastStichedval_C4647_month.Text = "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday_month_val.Rows[0]["StitchedValue"].ToString() + " Cr." + "</span>";

        //            //////}
        //            //-----------end of prabhaker code------------------------//
        //            //last three month=======================
        //            //////if (dtlastthree_month.Rows[0]["StitchQty"].ToString() != "" && dtlastthree_month.Rows[0]["StitchQty"].ToString() != "0" && dtlastthree_month.Rows[0]["StitchQty"].ToString() != "0.0")
        //            //////{

        //            //////    // lbllastStichedQty_C4647_3month.Text = dtlastthree_month.Rows[0]["StitchQty"].ToString() + " k";
        //            //////    if (Math.Round(Convert.ToDecimal(dtlastthree_month.Rows[0]["StitchQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
        //            //////    {
        //            //////        //lbllastStichedQty_C4647_3month.Text = Math.Round(Convert.ToDecimal(dtlastthree_month.Rows[0]["StitchQty"].ToString()), MidpointRounding.AwayFromZero) + " k";
        //            //////        lbllastStichedQty_C4647_3month.Text = Math.Round(Convert.ToDecimal(Get(dtlastthree_month.Rows[0]["StitchQty"].ToString().Replace("k", "")).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";

        //            //////    }

        //            //////}
        //            //last month====avg
        //            //////if (dtlastthree_monthavg.Rows[0]["StitchQtyavg"].ToString() != "" && dtlastthree_monthavg.Rows[0]["StitchQtyavg"].ToString() != "0" && dtlastthree_monthavg.Rows[0]["StitchQtyavg"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtlastthree_monthavg.Rows[0]["StitchQtyavg"].ToString()))
        //            //////    {
        //            //////        //lbllastStichedQty_C4647_3month_avg.Text = dtlastthree_monthavg.Rows[0]["StitchQtyavg"].ToString() + " k" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
        //            //////        lbllastStichedQty_C4647_3month_avg.Text = Get(dtlastthree_monthavg.Rows[0]["StitchQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
        //            //////    }
        //            //////}
        //            //////if (dtlastthree_monthval.Rows[0]["StitchedValue"].ToString() != "" && dtlastthree_monthval.Rows[0]["StitchedValue"].ToString() != "0" && dtlastthree_monthval.Rows[0]["StitchedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtlastthree_monthval.Rows[0]["StitchedValue"].ToString()))
        //            //////        lbllastStichedval_C4647_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtlastthree_monthval.Rows[0]["StitchedValue"].ToString() + " Cr." + "</span>";

        //            //////}

        //            Label lblFinishQty_4546 = (Label)e.Row.FindControl("lblFinishQty_4546");
        //            HiddenField hdnFinishQty_4546 = (HiddenField)e.Row.FindControl("hdnFinishQty_4546");
        //            if (dtitem4645.Rows[0]["Finish"].ToString() != "" && dtitem4645.Rows[0]["Finish"].ToString() != "0" && dtitem4645.Rows[0]["Finish"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem4645.Rows[0]["Finish"].ToString()))
        //                {
        //                    //lblFinishQty_4546.Text = dtitem4645.Rows[0]["Finish"].ToString() + " k";
        //                    //hdnFinishQty_4546.Value = dtitem4645.Rows[0]["Finish"].ToString();

        //                    lblFinishQty_4546.Text = Get(dtitem4645.Rows[0]["Finish"].ToString());
        //                    // hdnFinishQty_4546.Value = Get(dtitem4645.Rows[0]["Finish"].ToString()).Replace("k", "");
        //                    hdnFinishQty_4546.Value = GetValueDivideByThousand(dtitem4645.Rows[0]["Finish"].ToString());
        //                }
        //            }
        //            // comment by bharat 6may
        //            //////if (dtitem4645lastday.Rows[0]["FinishQty"].ToString() != "" && dtitem4645lastday.Rows[0]["FinishQty"].ToString() != "0" && dtitem4645lastday.Rows[0]["FinishQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday.Rows[0]["FinishQty"].ToString()))
        //            //////    {
        //            //////        // lbllastFinishQty_C4647.Text = dtitem4645lastday.Rows[0]["FinishQty"].ToString() + " k";
        //            //////        lbllastFinishQty_C4647.Text = Get_WithDecimal(dtitem4645lastday.Rows[0]["FinishQty"].ToString());
        //            //////    }
        //            //////}
        //            //last month====
        //            //////if (dtitem4645lastday_month.Rows[0]["FinishQty"].ToString() != "" && dtitem4645lastday_month.Rows[0]["FinishQty"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["FinishQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday_month.Rows[0]["FinishQty"].ToString()))
        //            //////    {
        //            //////        //lbllastFinishQty_C4647_month.Text = Math.Round(Convert.ToDecimal(dtitem4645lastday_month.Rows[0]["FinishQty"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //            //////        lbllastFinishQty_C4647_month.Text = Math.Round(Convert.ToDecimal(Get(dtitem4645lastday_month.Rows[0]["FinishQty"].ToString().Replace("k", "")).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //            //////    }
        //            //////}
        //            ////////last month====avg
        //            //////if (dtlastthree_monthavg.Rows[0]["FinishQtyavg"].ToString() != "" && dtlastthree_monthavg.Rows[0]["FinishQtyavg"].ToString() != "0" && dtlastthree_monthavg.Rows[0]["FinishQtyavg"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtlastthree_monthavg.Rows[0]["FinishQtyavg"].ToString()))
        //            //////    {
        //            //////        //lbllastFinishQty_C4647_3month_avg.Text = dtlastthree_monthavg.Rows[0]["FinishQtyavg"].ToString() + " k" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
        //            //////        lbllastFinishQty_C4647_3month_avg.Text = Get(dtlastthree_monthavg.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
        //            //////        lbllastFinishQty_C4647_3month_avg.ForeColor = Color.Gray;
        //            //////    }

        //            //////}


        //            //////if (dtlastthree_monthval.Rows[0]["FinishedValue"].ToString() != "" && dtlastthree_monthval.Rows[0]["FinishedValue"].ToString() != "0" && dtlastthree_monthval.Rows[0]["FinishedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtlastthree_monthval.Rows[0]["FinishedValue"].ToString()))
        //            //////    {
        //            //////        lbllastFinishval_C4647_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtlastthree_monthval.Rows[0]["FinishedValue"].ToString() + " Cr." + "</span>";
        //            //////    }

        //            //////}
        //            //last three month==================================
        //            //////if (dtlastthree_month.Rows[0]["FinishQty"].ToString() != "" && dtlastthree_month.Rows[0]["FinishQty"].ToString() != "0" && dtlastthree_month.Rows[0]["FinishQty"].ToString() != "0.0")
        //            //////{

        //            //////    //lbllastFinishQty_C4647_3month.Text = dtlastthree_month.Rows[0]["FinishQty"].ToString() + " k";

        //            //////    if (Math.Round(Convert.ToDecimal(dtlastthree_month.Rows[0]["FinishQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
        //            //////    {
        //            //////        //lbllastFinishQty_C4647_3month.Text = Math.Round(Convert.ToDecimal(dtlastthree_month.Rows[0]["FinishQty"].ToString()), MidpointRounding.AwayFromZero) + " k";
        //            //////        lbllastFinishQty_C4647_3month.Text = Math.Round(Convert.ToDecimal(Get(dtlastthree_month.Rows[0]["FinishQty"].ToString().Replace("k", "")).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";
        //            //////    }

        //            //////}
        //            //last three month====avg
        //            if (dtitem4645lastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "" && dtitem4645lastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0" && dtitem4645lastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem4645lastday_month_avg.Rows[0]["FinishQtyavg"].ToString()))
        //                {
        //                    //lbllastFinishQty_C4647_month_avg.Text = dtitem4645lastday_month_avg.Rows[0]["FinishQtyavg"].ToString() + " k" + " <span style='font-size: 8px;color:Gray;'>" + "pdy" + "</span>";
        //                    lbllastFinishQty_C4647_month_avg.Text = GetLastMonthPDY(dtitem4645lastday_month_avg.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:Gray;'>" + "pdy" + "</span>";
        //                    lbllastFinishQty_C4647_month_avg.ForeColor = Color.Gray;
        //                }
        //            }
        //            //----------------created By Prabhaker---------------//
        //            //////if (dtitem4645lastday_month_val.Rows[0]["FinishedValue"].ToString() != "" && dtitem4645lastday_month_val.Rows[0]["FinishedValue"].ToString() != "0" && dtitem4645lastday_month_val.Rows[0]["FinishedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday_month_val.Rows[0]["FinishedValue"].ToString()))
        //            //////        lbllastFinishval_C4647_month.Text = "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday_month_val.Rows[0]["FinishedValue"].ToString() + " Cr." + "</span>";

        //            //////}

        //            //-----------------end of prabhaker---------------//
        //            Label lblShipedQty_4546 = (Label)e.Row.FindControl("lblShipedQty_4546");
        //            HiddenField hdShipedQty_4546 = (HiddenField)e.Row.FindControl("hdShipedQty_4546");
        //            // edit by surendra

        //            HiddenField hdnPenalty_4546 = (HiddenField)e.Row.FindControl("hdnPenalty_4546");
        //            // end
        //            if (dtitem4645.Rows[0]["ShipQty"].ToString() != "" && dtitem4645.Rows[0]["ShipQty"].ToString() != "0" && dtitem4645.Rows[0]["ShipQty"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem4645.Rows[0]["ShipQty"].ToString()))
        //                {

        //                    //lblShipedQty_4546.Text = dtitem4645.Rows[0]["ShipQty"].ToString() + " k";
        //                    //hdShipedQty_4546.Value = dtitem4645.Rows[0]["ShipQty"].ToString();

        //                    lblShipedQty_4546.Text = Get(dtitem4645.Rows[0]["ShipQty"].ToString());
        //                    // hdShipedQty_4546.Value = Get(dtitem4645.Rows[0]["ShipQty"].ToString()).Replace("k", "");
        //                    hdShipedQty_4546.Value = GetValueDivideByThousand(dtitem4645.Rows[0]["ShipQty"].ToString());
        //                }
        //            }

        //            // comment by bharat 6may
        //            //////if (dtitem4645lastday.Rows[0]["ShipQty"].ToString() != "" && dtitem4645lastday.Rows[0]["ShipQty"].ToString() != "0" && dtitem4645lastday.Rows[0]["ShipQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday.Rows[0]["ShipQty"].ToString()))
        //            //////    {
        //            //////        //lbllastdayshipQty_C4647.Text = dtitem4645lastday.Rows[0]["ShipQty"].ToString() + " k";
        //            //////        lbllastdayshipQty_C4647.Text = Get(dtitem4645lastday.Rows[0]["ShipQty"].ToString());
        //            //////    }
        //            //////}
        //            //last month====
        //            //////if (dtitem4645lastday_month.Rows[0]["ShipQty"].ToString() != "" && dtitem4645lastday_month.Rows[0]["ShipQty"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["ShipQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday_month.Rows[0]["ShipQty"].ToString()))
        //            //////    {
        //            //////        //lbllastdayshipQty_C4647_month.Text = dtitem4645lastday_month.Rows[0]["ShipQty"].ToString() + " k";
        //            //////        lbllastdayshipQty_C4647_month.Text = Get(dtitem4645lastday_month.Rows[0]["ShipQty"].ToString());
        //            //////    }

        //            //////}
        //            //////if (dtlastthree_month.Rows[0]["ShipQty"].ToString() != "" && dtlastthree_month.Rows[0]["ShipQty"].ToString() != "0" && dtlastthree_month.Rows[0]["ShipQty"].ToString() != "0.0" && dtlastthree_month.Rows[0]["ShipQty"].ToString() != "0.00")
        //            //////{

        //            //////    // lbllastdayshipQty_C4647_3month.Text = dtlastthree_month.Rows[0]["ShipQty"].ToString() + " k";

        //            //////    if (Math.Round(Convert.ToDecimal(dtlastthree_month.Rows[0]["ShipQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
        //            //////    {
        //            //////        //lbllastdayshipQty_C4647_3month.Text = Math.Round((Convert.ToDecimal(dtlastthree_month.Rows[0]["ShipQty"].ToString())/3), MidpointRounding.AwayFromZero) + " k";
        //            //////        lbllastdayshipQty_C4647_3month.Text = Math.Round((Convert.ToDecimal(Get(dtlastthree_month.Rows[0]["ShipQty"].ToString().Replace("k", "")).Replace("k", "")) / 3), MidpointRounding.AwayFromZero) + " k";
        //            //////    }
        //            //////}
        //            HiddenField hdnShipedVal_4546 = (HiddenField)e.Row.FindControl("hdnShipedVal_4546");
        //            Label lblShipedVal_4546 = (Label)e.Row.FindControl("lblShipedVal_4546");
        //            if (dtitem4645.Rows[0]["ShipValue"].ToString() != "" && dtitem4645.Rows[0]["ShipValue"].ToString() != "0" && dtitem4645.Rows[0]["ShipValue"].ToString() != "0.0" && dtitem4645.Rows[0]["ShipValue"].ToString() != "0.00")
        //            {
        //                if (CheckZero(dtitem4645.Rows[0]["ShipValue"].ToString()))
        //                {
        //                    lblShipedVal_4546.Text = "/ <span style='color:green;'> " + " \u20B9 " + dtitem4645.Rows[0]["ShipValue"].ToString() + " Cr" + "</span>";

        //                    hdnShipedVal_4546.Value = dtitem4645.Rows[0]["ShipValue"].ToString();
        //                }
        //            }

        //            // comment by bharat 6may
        //            //////if (dtitem4645lastday.Rows[0]["ShipedValue"].ToString() != "" && dtitem4645lastday.Rows[0]["ShipedValue"].ToString() != "0" && dtitem4645lastday.Rows[0]["ShipedValue"].ToString() != "0.0" && dtitem4645lastday.Rows[0]["ShipedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday.Rows[0]["ShipedValue"].ToString()))
        //            //////    {
        //            //////        lbllastdaysShipVal_C4647.Text = "/" + "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday.Rows[0]["ShipedValue"].ToString() + " Cr." + "</span>";
        //            //////    }

        //            //////}
        //            //last month====
        //            //////if (dtitem4645lastday_month.Rows[0]["ShipedValue"].ToString() != "" && dtitem4645lastday_month.Rows[0]["ShipedValue"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["ShipedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday_month.Rows[0]["ShipedValue"].ToString()))
        //            //////    {
        //            //////        lbllastdaysShipVal_C4647_month.Text = "/" + "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday_month.Rows[0]["ShipedValue"].ToString() + " Cr." + "</span>";
        //            //////    }

        //            //////}
        //            //////if (dtlastthree_month.Rows[0]["ShipedValue"].ToString() != "" && dtlastthree_month.Rows[0]["ShipedValue"].ToString() != "0" && dtlastthree_month.Rows[0]["ShipedValue"].ToString() != "0.0")
        //            //////{


        //            //////    if (Convert.ToDecimal(dtlastthree_month.Rows[0]["ShipedValue"].ToString()) / 3 > 0)
        //            //////    {

        //            //////        lbllastdaysShipVal_C4647_3month.Text = "/" + "<span style='color:green;'> " + "\u20B9 " + Math.Round(Convert.ToDecimal(dtlastthree_month.Rows[0]["ShipedValue"].ToString()) / 3, 1) + " Cr." + "</span>";
        //            //////    }

        //            //////}
        //            Label lblCtsl_4546 = (Label)e.Row.FindControl("lblCtsl_4546");
        //            HiddenField hdnctsl_4645 = (HiddenField)e.Row.FindControl("hdnctsl_4645");
        //            if (dtitem4645.Rows[0]["ShipCtsl"].ToString() != "" && dtitem4645.Rows[0]["ShipCtsl"].ToString() != "0" && dtitem4645.Rows[0]["ShipCtsl"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem4645.Rows[0]["ShipCtsl"].ToString()))
        //                {
        //                    lblCtsl_4546.Text = dtitem4645.Rows[0]["ShipCtsl"].ToString() + "%";
        //                    hdnctsl_4645.Value = dtitem4645.Rows[0]["ShipCtsl"].ToString();

        //                }
        //            }
        //            // comment by bharat 6may
        //            //////if (dtitem4645lastday.Rows[0]["ctsl"].ToString() != "" && dtitem4645lastday.Rows[0]["ctsl"].ToString() != "0" && dtitem4645lastday.Rows[0]["ctsl"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday.Rows[0]["ctsl"].ToString()))
        //            //////    {
        //            //////        lbllastdaysShipCtsl_C4647.Text = dtitem4645lastday.Rows[0]["ctsl"].ToString() + "%";
        //            //////    }
        //            //////}
        //            //last month====
        //            //////if (dtitem4645lastday_month.Rows[0]["ctsl"].ToString() != "" && dtitem4645lastday_month.Rows[0]["ctsl"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["ctsl"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday_month.Rows[0]["ctsl"].ToString()))
        //            //////    {
        //            //////        lbllastdaysShipCtsl_C4647_month.Text = dtitem4645lastday_month.Rows[0]["ctsl"].ToString() + " %";
        //            //////        if (Convert.ToInt32(dtitem4645lastday_month.Rows[0]["RescanQty"]) > 0)
        //            //////            lbllastdaysShipCtsl_C4647_month.Text = lbllastdaysShipCtsl_C4647_month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(dtitem4645lastday_month.Rows[0]["RescanQty"].ToString()) + " </span>";

        //            //////    }

        //            //////}
        //            //////if (dtlastthree_month.Rows[0]["ctsl"].ToString() != "" && dtlastthree_month.Rows[0]["ctsl"].ToString() != "0" && dtlastthree_month.Rows[0]["ctsl"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtlastthree_month.Rows[0]["ctsl"].ToString()))
        //            //////    {
        //            //////        lbllastdaysShipCtsl_C4647_3month.Text = dtlastthree_month.Rows[0]["ctsl"].ToString() + " %";
        //            //////        if (Convert.ToInt32(dtlastthree_month.Rows[0]["RescanQty"]) > 0)
        //            //////        {
        //            //////            string RescanQty = Math.Round(Convert.ToDouble(((Convert.ToDouble(dtlastthree_month.Rows[0]["RescanQty"].ToString())) / Convert.ToDouble(3))), 0, MidpointRounding.AwayFromZero).ToString();
        //            //////            lbllastdaysShipCtsl_C4647_3month.Text = lbllastdaysShipCtsl_C4647_3month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(RescanQty) + " </span>";
        //            //////        }

        //            //////    }

        //            //////}
        //            //if (lbllastCutQty_C4647.Text != "" && lbllastdayshipQty_C4647.Text != "")
        //            //{
        //            //    string C4647Ctsl_lastday = Math.Round(Convert.ToDouble((Convert.ToDouble(lbllastCutQty_C4647.Text.Replace(" k", "")) - Convert.ToDouble(lbllastdayshipQty_C4647.Text.Replace(" k", ""))) / Convert.ToDouble(lbllastCutQty_C4647.Text.Replace(" k", ""))), 1, MidpointRounding.AwayFromZero).ToString();
        //            //    lbllastdaysShipCtsl_C4647.Text = C4647Ctsl_lastday == "0" ? "" : "(" + C4647Ctsl_lastday + " % )"; ;

        //            //}

        //            Label lblShipedPendingQty_4546 = (Label)e.Row.FindControl("lblShipedPendingQty_4546");
        //            HiddenField hdShipedPendingQty_4546 = (HiddenField)e.Row.FindControl("hdShipedPendingQty_4546");
        //            Label lblPndStitchQty_C4546 = (Label)e.Row.FindControl("lblPndStitchQty_C4546");
        //            HiddenField hdnPndStitchQty_C4546 = (HiddenField)e.Row.FindControl("hdnPndStitchQty_C4546");
        //            // if (dtitem4645.Rows[0]["PendingShipQty"].ToString() != "" && dtitem4645.Rows[0]["PendingShipQty"].ToString() != "0" && dtitem4645.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitem4645lastday.Rows[0]["PendingShipQty"].ToString() != "0.00")
        //            if (dtitem4645.Rows[0]["PendingShipQty"].ToString() != "" && dtitem4645.Rows[0]["PendingShipQty"].ToString() != "0" && dtitem4645.Rows[0]["PendingShipQty"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem4645.Rows[0]["PendingShipQty"].ToString()))
        //                {
        //                    //lblShipedPendingQty_4546.Text = dtitem4645.Rows[0]["PendingShipQty"].ToString() + " k";
        //                    //hdShipedPendingQty_4546.Value = dtitem4645.Rows[0]["PendingShipQty"].ToString();

        //                    lblShipedPendingQty_4546.Text = Get(dtitem4645.Rows[0]["PendingShipQty"].ToString());
        //                    // hdShipedPendingQty_4546.Value = Get(dtitem4645.Rows[0]["PendingShipQty"].ToString()).Replace("k", "");
        //                    hdShipedPendingQty_4546.Value = GetValueDivideByThousand(dtitem4645.Rows[0]["PendingShipQty"].ToString());


        //                }
        //                //if (e.Row.RowIndex == 0)
        //                //{
        //                //    if (dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() != "" && dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() != "0.0")
        //                //    {

        //                //        lblShipedPendingQty_4546.Text = lblShipedPendingQty_4546.Text + " (" + dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() + " k" + ")";

        //                //    }
        //                //}

        //            }
        //            if (dtitem4645.Rows[0]["PendingStitchQty"].ToString() != "" && dtitem4645.Rows[0]["PendingStitchQty"].ToString() != "0" && dtitem4645.Rows[0]["PendingStitchQty"].ToString() != "0.00" && dtitem4645.Rows[0]["PendingStitchQty"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitem4645.Rows[0]["PendingStitchQty"].ToString()))
        //                {
        //                    //lblPndStitchQty_C4546.Text = dtitem4645.Rows[0]["PendingStitchQty"].ToString() + " k";
        //                    //hdnPndStitchQty_C4546.Value = dtitem4645.Rows[0]["PendingStitchQty"].ToString();

        //                    lblPndStitchQty_C4546.Text = Get(dtitem4645.Rows[0]["PendingStitchQty"].ToString());
        //                    //hdnPndStitchQty_C4546.Value = Get(dtitem4645.Rows[0]["PendingStitchQty"].ToString()).Replace("k", "");
        //                    hdnPndStitchQty_C4546.Value = GetValueDivideByThousand(dtitem4645.Rows[0]["PendingStitchQty"].ToString());
        //                }
        //            }
        //            if (e.Row.RowIndex == 0)
        //            {
        //                if (dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() != "" && dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() != "0.00" && dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() != "0.0")
        //                {
        //                    if (CheckZero(dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString()))
        //                    {
        //                        lblShipedPendingQty_4546.Text = lblShipedPendingQty_4546.Text + " (" + Get(dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString()) + ")";
        //                        // lblShipedPendingQty_4546.Text = lblShipedPendingQty_4546.Text.Replace("k", "") + " (" + Get(dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString().Replace("k", "").Replace("k", "")) + " k" + ")";
        //                    }

        //                }
        //            }

        //            // comment by bharat 6may
        //            //////if (dtitem4645lastday.Rows[0]["PendingShipQty"].ToString() != "" && dtitem4645lastday.Rows[0]["ctsl"].ToString() != "0" && dtitem4645lastday.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitem4645lastday.Rows[0]["PendingShipQty"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday.Rows[0]["PendingShipQty"].ToString()))
        //            //////    {
        //            //////        //lbllastdayPendingShipedQty_C4647.Text = dtitem4645lastday.Rows[0]["PendingShipQty"].ToString() + " k";
        //            //////        lbllastdayPendingShipedQty_C4647.Text = Get(dtitem4645lastday.Rows[0]["PendingShipQty"].ToString());
        //            //////    }
        //            //////}
        //            //last month====
        //            //////if (dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() != "" && dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString()))
        //            //////    {
        //            //////        //lbllastdayPendingShipedQty_C4647_month.Text = dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString() + " k";
        //            //////        lbllastdayPendingShipedQty_C4647_month.Text = Get(dtitem4645lastday_month.Rows[0]["PendingShipQty"].ToString());
        //            //////    }
        //            //////}
        //            //////if (dtlastthree_month.Rows[0]["PendingShipQty"].ToString() != "" && dtlastthree_month.Rows[0]["PendingShipQty"].ToString() != "0" && dtlastthree_month.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtlastthree_month.Rows[0]["PendingShipQty"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtlastthree_month.Rows[0]["PendingShipQty"].ToString()))
        //            //////    {
        //            //////        //lbllastdayPendingShipedQty_C4647_3month.Text = dtlastthree_month.Rows[0]["PendingShipQty"].ToString() + " k";
        //            //////        lbllastdayPendingShipedQty_C4647_3month.Text = GetLastMonthPDY(dtlastthree_month.Rows[0]["PendingShipQty"].ToString());
        //            //////    }
        //            //////}
        //            Label lblShipedPendingVal_4546 = (Label)e.Row.FindControl("lblShipedPendingVal_4546");
        //            HiddenField hdnShipedPendingVal_4546 = (HiddenField)e.Row.FindControl("hdnShipedPendingVal_4546");
        //            if (dtitem4645.Rows[0]["PendingShipValue"].ToString() != "" && dtitem4645.Rows[0]["PendingShipValue"].ToString() != "0" && dtitem4645.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitem4645.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //            {
        //                if (CheckZero(dtitem4645.Rows[0]["PendingShipValue"].ToString()))
        //                    lblShipedPendingVal_4546.Text = "<span style='color:green;'> \u20B9 " + dtitem4645.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

        //                //if (e.Row.RowIndex == 0)
        //                //{
        //                //    if (dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() != "" && dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() != "0.0")
        //                //    {
        //                //        lblShipedPendingVal_4546.Text = lblShipedPendingVal_4546.Text + " (" + "<span style='color:green;'> " + " \u20B9 " + dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() + " Cr" + ")"+"</span>";
        //                //    }
        //                //}
        //                hdnShipedPendingVal_4546.Value = dtitem4645.Rows[0]["PendingShipValue"].ToString();
        //            }
        //            if (e.Row.RowIndex == 0)
        //            {
        //                if (dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() != "" && dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() != "0.00" && dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() != "0.0")
        //                {
        //                    lblShipedPendingVal_4546.Text = lblShipedPendingVal_4546.Text + " (<span style='color:green;'> " + " \u20B9 " + dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>)";
        //                }
        //            }

        //            Label lblShipedPendingVal_fob_4546 = (Label)e.Row.FindControl("lblShipedPendingVal_fob_4546");
        //            Label lblPenaltyTotal_fob_4546 = (Label)e.Row.FindControl("lblPenaltyTotal_fob_4546");
        //            HiddenField hdnfobpercentage_4546 = (HiddenField)e.Row.FindControl("hdnfobpercentage_4546");
        //            if (dtitem4645.Rows[0]["PercentageFob"].ToString() != "" && dtitem4645.Rows[0]["PercentageFob"].ToString() != "0" && dtitem4645.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitem4645.Rows[0]["PercentageFob"].ToString() != "0.00")
        //            {
        //                if (CheckZero(dtitem4645.Rows[0]["PercentageFob"].ToString()))
        //                    lblShipedPendingVal_fob_4546.Text = dtitem4645.Rows[0]["PercentageFob"].ToString() + " %";


        //                //hdnfobpercentage_4546.Value = dtitem4645.Rows[0]["PercentageFob"].ToString();
        //            }
        //            if (dtitem4645.Rows[0]["PenaltyValue"].ToString() != "" && dtitem4645.Rows[0]["PenaltyValue"].ToString() != "0" && dtitem4645.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitem4645.Rows[0]["PenaltyValue"].ToString() != "0.00")
        //            {
        //                if (CheckZero(dtitem4645.Rows[0]["PenaltyValue"].ToString()))
        //                {
        //                    lblPenaltyTotal_fob_4546.Text = "<span style='color:red;'> " + " \u20B9 " + dtitem4645.Rows[0]["PenaltyValue"].ToString() + " Lk</span> /";
        //                    hdnPenalty_4546.Value = dtitem4645.Rows[0]["PenaltyValue"].ToString();
        //                }

        //                //hdnfobpercentage_4546.Value = dtitem4645.Rows[0]["PercentageFob"].ToString();
        //            }

        //            // comment by bharat 6may
        //            //////if (dtitem4645lastday.Rows[0]["PendingShipValue"].ToString() != "" && dtitem4645lastday.Rows[0]["PendingShipValue"].ToString() != "0" && dtitem4645lastday.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitem4645lastday.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday.Rows[0]["PendingShipValue"].ToString()))
        //            //////    {
        //            //////        lbllastdayPendingShipedVal_C4647.Text = "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";
        //            //////    }

        //            //////}
        //            //last month====
        //            //////if (dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() != "" && dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString()))
        //            //////        lbllastdayPendingShipedVal_C4647_month.Text = "<span style='color:green;'> " + "\u20B9 " + dtitem4645lastday_month.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

        //            //////}
        //            //////if (dtlastthree_month.Rows[0]["PendingShipValue"].ToString() != "" && dtlastthree_month.Rows[0]["PendingShipValue"].ToString() != "0" && dtlastthree_month.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtlastthree_month.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtlastthree_month.Rows[0]["PendingShipValue"].ToString()))
        //            //////        lbllastdayPendingShipedVal_C4647_3month.Text = "<span style='color:green;'> " + "\u20B9 " + dtlastthree_month.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

        //            //////}
        //            //comment bh bharat 6may
        //            //////if (dtitem4645lastday.Rows[0]["PercentageFob"].ToString() != "" && dtitem4645lastday.Rows[0]["PercentageFob"].ToString() != "0" && dtitem4645lastday.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitem4645lastday.Rows[0]["PercentageFob"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday.Rows[0]["PercentageFob"].ToString()))
        //            //////        lbllastdayPendingShipedVal_fob_C4647.Text = dtitem4645lastday.Rows[0]["PercentageFob"].ToString() + " %";


        //            //////}


        //            //////if (dtitem4645lastday.Rows[0]["PenaltyValue"].ToString() != "" && dtitem4645lastday.Rows[0]["PenaltyValue"].ToString() != "0" && dtitem4645lastday.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitem4645lastday.Rows[0]["PenaltyValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday.Rows[0]["PenaltyValue"].ToString()))
        //            //////        lbllastdayPenaltyValue_fob_C4647.Text = "\u20B9 " + dtitem4645lastday.Rows[0]["PenaltyValue"].ToString() + " Lk /";



        //            //////}
        //            //if (dtitem4645lastday.Rows[0]["PercentageFob"].ToString() != "" && dtitem4645lastday.Rows[0]["PercentageFob"].ToString() != "0" && dtitem4645lastday.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitem4645lastday.Rows[0]["PercentageFob"].ToString() != "0.00")
        //            //{

        //            //    lbllastdayPendingShipedVal_fob_C4647_3month.Text = dtitem4645lastday.Rows[0]["PercentageFob"].ToString() + " %";


        //            //}
        //            //////if (dtitem4645lastday_month.Rows[0]["PercentageFob"].ToString() != "" && dtitem4645lastday_month.Rows[0]["PercentageFob"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitem4645lastday_month.Rows[0]["PercentageFob"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday_month.Rows[0]["PercentageFob"].ToString()))
        //            //////        lbllastdayPendingShipedVal_fob_C4647_month.Text = dtitem4645lastday_month.Rows[0]["PercentageFob"].ToString() + " %";

        //            //////}
        //            //////if (dtitem4645lastday_month.Rows[0]["PenaltyValue"].ToString() != "" && dtitem4645lastday_month.Rows[0]["PenaltyValue"].ToString() != "0" && dtitem4645lastday_month.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitem4645lastday_month.Rows[0]["PenaltyValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitem4645lastday_month.Rows[0]["PenaltyValue"].ToString()))
        //            //////        lbllastdayPenalty_fob_C4647_month.Text = "\u20B9 " + Math.Round(Convert.ToDecimal(dtitem4645lastday_month.Rows[0]["PenaltyValue"].ToString()) / 3, 1) + " Lk /";

        //            //////}
        //            //////if (dtlastthree_month.Rows[0]["PercentageFob"].ToString() != "" && dtlastthree_month.Rows[0]["PercentageFob"].ToString() != "0" && dtlastthree_month.Rows[0]["PercentageFob"].ToString() != "0.0" && dtlastthree_month.Rows[0]["PercentageFob"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtlastthree_month.Rows[0]["PercentageFob"].ToString()))
        //            //////        lbllastdayPendingShipedVal_fob_C4647_3month.Text = dtlastthree_month.Rows[0]["PercentageFob"].ToString() + " %";

        //            //////}
        //            //////if (dtlastthree_month.Rows[0]["PenaltyValue"].ToString() != "" && dtlastthree_month.Rows[0]["PenaltyValue"].ToString() != "0" && dtlastthree_month.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtlastthree_month.Rows[0]["PenaltyValue"].ToString() != "0.00")
        //            //////{


        //            //////    if (Convert.ToDecimal(dtlastthree_month.Rows[0]["PenaltyValue"].ToString()) / 3 > 0)
        //            //////    {
        //            //////        lbllast_threeMonth_Penalty_fob_C4647_3month.Text = "\u20B9 " + Math.Round(Convert.ToDecimal(dtlastthree_month.Rows[0]["PenaltyValue"].ToString()) / 3, 1) + " Lk" + " /";
        //            //////    }


        //            //////}
        //            //////dswip = objadmin.GetWipDetails(11, "CUTWIP");
        //            //////dtwip = dswip.Tables[0];
        //            //////if (dtwip.Rows[0]["CutWip_k"].ToString() != "" && dtwip.Rows[0]["CutWip_k"].ToString() != "0" && dtwip.Rows[0]["CutWip_k"].ToString() != "0.0" && dtwip.Rows[0]["CutWip_k"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtwip.Rows[0]["CutWip_k"].ToString()))
        //            //////    {
        //            //////        // lblwipcutC45C46_K.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["CutWip_k"].ToString()), 0) + " k" + " <span style='font-size: 8px;'>" + "" + "</span>";
        //            //////        //lblwipcutC45C46_K.Text = Math.Round(Convert.ToDecimal(Get(dtwip.Rows[0]["CutWip_k"].ToString().Replace("k", ""))), 0) + " k" + " <span style='font-size: 8px;'>" + "" + "</span>";
        //            //////        lblwipcutC45C46_K.Text = Get(dtwip.Rows[0]["CutWip_k"].ToString()) + " <span style='font-size: 8px;'>" + "" + "</span>";
        //            //////    }
        //            //////}
        //            //////if (dtwip.Rows[0]["CutWip"].ToString() != "" && dtwip.Rows[0]["CutWip"].ToString() != "0" && dtwip.Rows[0]["CutWip"].ToString() != "0.0" && dtwip.Rows[0]["CutWip"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtwip.Rows[0]["CutWip"].ToString()))

        //            //////        lblwipcutC45C46.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["CutWip"].ToString()), 0) + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
        //            //////}
        //            //////dswip = objadmin.GetWipDetails(11, "STITCHWIP");
        //            //////dtwip = dswip.Tables[0];
        //            //////if (dtwip.Rows[0]["StitchWip_k"].ToString() != "" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0.00" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtwip.Rows[0]["StitchWip_k"].ToString()))
        //            //////    {
        //            //////        //lblwipstitchC45C46_K.Text = dtwip.Rows[0]["StitchWip_k"].ToString() + " k" + " <span style='font-size: 8px;'>" + "" + "</span>";
        //            //////        //lblwipstitchC45C46_K.Text = Get(dtwip.Rows[0]["StitchWip_k"].ToString()) + "" + " <span style='font-size: 8px;'>" + "" + "</span>";
        //            //////        lblwipstitchC45C46_K.Text = Get(dtwip.Rows[0]["StitchWip_k"].ToString()) + " <span style='font-size: 8px;'>" + "" + "</span>";
        //            //////    }
        //            //////}
        //            //////if (dtwip.Rows[0]["StitchWip"].ToString() != "" && dtwip.Rows[0]["StitchWip"].ToString() != "0" && dtwip.Rows[0]["StitchWip"].ToString() != "0.00" && dtwip.Rows[0]["StitchWip"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtwip.Rows[0]["StitchWip"].ToString()))
        //            //////        lblwipstitchC45C46.Text = dtwip.Rows[0]["StitchWip"].ToString() + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
        //            //////}
        //            //////dswip = objadmin.GetWipDetails(11, "FINISHWIP");
        //            //////dtwip = dswip.Tables[0];
        //            //////if (dtwip.Rows[0]["FinishWip_k"].ToString() != "" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0.00" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtwip.Rows[0]["FinishWip_k"].ToString()))
        //            //////    {
        //            //////        lblwipfinishC45C46_K.Text = Get(dtwip.Rows[0]["FinishWip_k"].ToString()) + " <span style='font-size: 8px;'>" + "" + "</span>";
        //            //////    }
        //            //////}
        //            //////if (dtwip.Rows[0]["FinishWip"].ToString() != "" && dtwip.Rows[0]["FinishWip"].ToString() != "0" && dtwip.Rows[0]["FinishWip"].ToString() != "0.00" && dtwip.Rows[0]["FinishWip"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtwip.Rows[0]["FinishWip"].ToString()))
        //            //////        lblwipfinishC45C46.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";

        //            //////    if (Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()) > 2)
        //            //////    {
        //            //////        lblwipfinishC45C46.Text = " <span style='font-weight: bold;color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D</span>";
        //            //////    }
        //            //////    else
        //            //////    {
        //            //////        lblwipfinishC45C46.Text = " <span style='color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FinishWip"].ToString()), 0) + " D</span>";
        //            //////    }
        //            //////}
        //            //////// Pending Rescan value for C 45-46
        //            //////dswip = objadmin.GetWipDetails(11, "PENDING_RESCAN");
        //            //////dtwip = dswip.Tables[0];
        //            //////if (dtwip.Rows[0]["RescanValue"].ToString() != "" && dtwip.Rows[0]["RescanValue"].ToString() != "0" && dtwip.Rows[0]["RescanValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtwip.Rows[0]["RescanValue"].ToString()))
        //            //////    {
        //            //////        lblPendingRescanC4546_k.Text = Get(dtwip.Rows[0]["RescanValue"].ToString()) + " <span style='color:red; font-size: 8px;'>" + "" + "</span>";
        //            //////    }
        //            //////}
        //            dswip = objadmin.GetWipDetails(11, "FINISHWIPWORKINGDAYS");
        //            dtwip = dswip.Tables[0];
        //            if (dswip.Tables[0].Rows.Count > 0)
        //            {
        //                DateTime now = DateTime.Now;

        //                if ((Convert.ToDecimal(dtwip.Rows[0]["PedningWkDayCurrentMonth"].ToString())) > 0)
        //                {
        //                    lblpendingworkingdaymonth.Text = " <span style='color:gray'>" + now.ToString("MMM") + ": " + "</span>" + dtwip.Rows[0]["PedningWkDayCurrentMonth"].ToString() + " D";
        //                }
        //                if ((Convert.ToDecimal(dtwip.Rows[0]["PendingWkHourCUrrentMonth"].ToString())) > 0)
        //                {
        //                    lblpendingworkinghours.Text = "," + dtwip.Rows[0]["PendingWkHourCUrrentMonth"].ToString() + " Hr";
        //                }
        //                if ((Convert.ToDecimal(dtwip.Rows[0]["PedningWkDayTwoMonth"].ToString())) > 0)
        //                {
        //                    lblpeningwkday60.Text = " <span style='color:gray'>" + "2 M: " + "</span>" + dtwip.Rows[0]["PedningWkDayTwoMonth"].ToString() + " D";
        //                }
        //                if ((Convert.ToDecimal(dtwip.Rows[0]["PendingWkHourTwoMonth"].ToString())) > 0)
        //                {
        //                    lblpendingworkinghur60.Text = "," + dtwip.Rows[0]["PendingWkHourTwoMonth"].ToString() + " Hr";
        //                }
        //                if ((Convert.ToDecimal(dtwip.Rows[0]["UnStitchQty"].ToString())) > 0)
        //                {

        //                    lblunstitchQty60.Text = " <span style='color:gray'>" + "2 M: " + "</span>" + Get(dtwip.Rows[0]["UnStitchQty"].ToString());
        //                }
        //                if ((Convert.ToDecimal(dtwip.Rows[0]["PerDayUnStitQty"].ToString())) > 0)
        //                {
        //                    string result = string.Format("{0:0.0}", dtwip.Rows[0]["PerDayUnStitQty"].ToString());
        //                    lblunstitchQtyPerday.Text = "," + result + " k pdy";
        //                }
        //            }
        //            //-------------------------------------------BIPL---------------------------------------------------------------------

        //            DataSet dsbipl = new DataSet();
        //            dsbipl = objadmin.GetShipmentReportByValue(Convert.ToInt32(hdnweekMax.Value), Convert.ToInt32(hdnweekMin.Value), 0);
        //            dtitemMonthBipl_Total = dsbipl.Tables[7];
        //            DataTable dtitembipl = new DataTable();
        //            DataTable dtitembiplLastday = new DataTable();
        //            dtitembipl = dsbipl.Tables[0];
        //            dtitembiplLastday = dsbipl.Tables[1];
        //            DataTable dtitemBIpllastday_month = dsbipl.Tables[2];
        //            DataTable dtitemBIpllastday_month_avg = dsbipl.Tables[3];

        //            //----------------------prabhaker code start---------------//
        //            DataTable dtitemBIpllastday_month_val = dsbipl.Tables[3];

        //            //-------------------end of prabhaker-------------------------//
        //            //====last three month===================================

        //            DataTable dtlastthreemonth = new DataTable();
        //            DataTable dtlastthreemonthavg = new DataTable();
        //            DataTable dtlastthreemonthval = new DataTable();

        //            dtlastthreemonth = dsbipl.Tables[4];
        //            dtlastthreemonthavg = dsbipl.Tables[5];
        //            dtlastthreemonthval = dsbipl.Tables[5];

        //            Label lblutQty_bipl = (Label)e.Row.FindControl("lblutQty_bipl");

        //            if ((hdnweekMax.Value != "0" && hdnweekMax.Value != "") && (hdnweekMin.Value != "0" && hdnweekMin.Value != ""))
        //            {
        //                HiddenField hdcutqty_BIPL = (HiddenField)e.Row.FindControl("hdcutqty_BIPL");
        //                HiddenField hdnQtyCutCtsl_BIPL = (HiddenField)e.Row.FindControl("hdnQtyCutCtsl_BIPL");
        //                if (dtitembipl.Rows[0]["CutActual"].ToString() != "" && dtitembipl.Rows[0]["CutActual"].ToString() != "0" && dtitembipl.Rows[0]["CutActual"].ToString() != "0.0" && dtitembipl.Rows[0]["CutActual"].ToString() != "0.00")
        //                {
        //                    if (CheckZero(dtitembipl.Rows[0]["CutActual"].ToString()))
        //                    {
        //                        //lblutQty_bipl.Text = dtitembipl.Rows[0]["CutActual"].ToString() + " k";
        //                        //hdcutqty_BIPL.Value = dtitembipl.Rows[0]["CutActual"].ToString();

        //                        lblutQty_bipl.Text = Get(dtitembipl.Rows[0]["CutActual"].ToString());
        //                        //hdcutqty_BIPL.Value = Get(dtitembipl.Rows[0]["CutActual"].ToString()).Replace("k", "");
        //                        hdcutqty_BIPL.Value = GetValueDivideByThousand(dtitembipl.Rows[0]["CutActual"].ToString());
        //                    }
        //                }
        //                if (dtitembipl.Rows[0]["CutQty"].ToString() != "" && dtitembipl.Rows[0]["CutQty"].ToString() != "0" && dtitembipl.Rows[0]["CutQty"].ToString() != "0.0" && dtitembipl.Rows[0]["CutQty"].ToString() != "0.00")
        //                {

        //                    //hdnQtyCutCtsl_BIPL.Value = dtitembipl.Rows[0]["CutQty"].ToString();
        //                    //hdnQtyCutCtsl_BIPL.Value = Get(dtitembipl.Rows[0]["CutQty"].ToString()).Replace("k", "");
        //                    hdnQtyCutCtsl_BIPL.Value = GetValueDivideByThousand(dtitembipl.Rows[0]["CutQty"].ToString());
        //                }

        //                // comment by bharat 6may
        //                //////if (dtitembiplLastday.Rows[0]["CutActual"].ToString() != "" && dtitembiplLastday.Rows[0]["CutActual"].ToString() != "0" && dtitembiplLastday.Rows[0]["CutActual"].ToString() != "0.0" && dtitembiplLastday.Rows[0]["CutActual"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtitembiplLastday.Rows[0]["CutActual"].ToString()))
        //                //////    {
        //                //////        //lbllastdayCutQty_BIPL.Text = dtitembiplLastday.Rows[0]["CutActual"].ToString() + " k";
        //                //////        lbllastdayCutQty_BIPL.Text = Get_WithDecimal(dtitembiplLastday.Rows[0]["CutActual"].ToString());
        //                //////    }
        //                //////}
        //                //last month====
        //                //////if (dtitemBIpllastday_month.Rows[0]["CutActual"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["CutActual"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["CutActual"].ToString() != "0.0" && dtitemBIpllastday_month.Rows[0]["CutActual"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtitemBIpllastday_month.Rows[0]["CutActual"].ToString()))
        //                //////    {
        //                //////        //lbllastdayCutQty_BIPL_month.Text = Math.Round(Convert.ToDecimal(dtitemBIpllastday_month.Rows[0]["CutActual"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //                //////        //lbllastdayCutQty_BIPL_month.Text = Math.Round(Convert.ToDecimal(Get(dtitemBIpllastday_month.Rows[0]["CutActual"].ToString()).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //                //////        lbllastdayCutQty_BIPL_month.Text = Get(dtitemBIpllastday_month.Rows[0]["CutActual"].ToString());
        //                //////    }
        //                //////}
        //                //last month====avg
        //                //////if (dtitemBIpllastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "" && dtitemBIpllastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "0" && dtitemBIpllastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "0.0" && dtitemBIpllastday_month_avg.Rows[0]["CutQtyavg"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtitemBIpllastday_month_avg.Rows[0]["CutQtyavg"].ToString()))
        //                //////    {
        //                //////        //lbllastdayCutQty_BIPL_month_avg.Text = dtitemBIpllastday_month_avg.Rows[0]["CutQtyavg"].ToString() + " k <span style='font-size: 8px;color:Gray;'>pdy</span>";
        //                //////        lbllastdayCutQty_BIPL_month_avg.Text = Get(dtitemBIpllastday_month_avg.Rows[0]["CutQtyavg"].ToString().Replace("k", "")) + " k <span style='font-size: 8px;color:Gray;'>pdy</span>";
        //                //////        lbllastdayCutQty_BIPL_month_avg.ForeColor = Color.Gray;
        //                //////    }
        //                //////}
        //                //last month=three===
        //                //////if (dtlastthreemonth.Rows[0]["CutActual"].ToString() != "" && dtlastthreemonth.Rows[0]["CutActual"].ToString() != "0" && dtlastthreemonth.Rows[0]["CutActual"].ToString() != "0.0" && dtlastthreemonth.Rows[0]["CutActual"].ToString() != "0.00")
        //                //////{

        //                //////    //lbllastdayCutQty_BIPL_3month.Text = dtlastthreemonth.Rows[0]["CutActual"].ToString() + " k";

        //                //////    if (Math.Round(Convert.ToDecimal(dtlastthreemonth.Rows[0]["CutActual"].ToString()), MidpointRounding.AwayFromZero) > 0)
        //                //////    {
        //                //////        //lbllastdayCutQty_BIPL_3month.Text = Math.Round(Convert.ToDecimal(dtlastthreemonth.Rows[0]["CutActual"].ToString()), MidpointRounding.AwayFromZero) + " k";
        //                //////        lbllastdayCutQty_BIPL_3month.Text = Math.Round(Convert.ToDecimal(Get(dtlastthreemonth.Rows[0]["CutActual"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";
        //                //////    }
        //                //////}
        //                //last month=three===avg
        //                //////if (dtlastthreemonthavg.Rows[0]["CutQtyavg"].ToString() != "" && dtlastthreemonthavg.Rows[0]["CutQtyavg"].ToString() != "0" && dtlastthreemonthavg.Rows[0]["CutQtyavg"].ToString() != "0.0" && dtlastthreemonthavg.Rows[0]["CutQtyavg"].ToString() != "0.00")
        //                //////{
        //                //////    if (CheckZero(dtlastthreemonthavg.Rows[0]["CutQtyavg"].ToString()))
        //                //////    {
        //                //////        //lbllastdayCutQty_BIPL_3month_avg.Text = dtlastthreemonthavg.Rows[0]["CutQtyavg"].ToString() + " k <span style='font-size: 8px;'>pdy</span>";
        //                //////        lbllastdayCutQty_BIPL_3month_avg.Text = GetLastMonthPDY(dtlastthreemonthavg.Rows[0]["CutQtyavg"].ToString()) + "<span style='font-size: 8px;'> pdy</span>";
        //                //////        lbllastdayCutQty_BIPL_3month_avg.ForeColor = Color.Gray;
        //                //////    }
        //                //////}
        //                if (dtitembipl.Rows[0]["PercentageFob_month"].ToString() != "" && dtitembipl.Rows[0]["PercentageFob_month"].ToString() != "0" && dtitembipl.Rows[0]["PercentageFob_month"].ToString() != "0.0" && dtitembipl.Rows[0]["PercentageFob_month"].ToString() != "0.00")
        //                {

        //                    pedPendingVal_fob_BIPLtotal = Convert.ToDouble(dtitembipl.Rows[0]["PercentageFob_month"].ToString());

        //                }
        //                //if (dtitembipl.Rows[0]["PenaltyValue"].ToString() != "" && dtitembipl.Rows[0]["PenaltyValue"].ToString() != "0" && dtitembipl.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitembipl.Rows[0]["PenaltyValue"].ToString() != "0.00")
        //                //{

        //                //    PenaltyValue_BIPLtotal = Convert.ToDouble(dtitembipl.Rows[0]["PenaltyValue"].ToString());

        //                //}

        //            }
        //            Label lblstitchQty_bipl = (Label)e.Row.FindControl("lblstitchQty_bipl");
        //            HiddenField hdstitchQty_BIPL = (HiddenField)e.Row.FindControl("hdstitchQty_BIPL");
        //            if (dtitembipl.Rows[0]["StitchQty"].ToString() != "" && dtitembipl.Rows[0]["StitchQty"].ToString() != "0" && dtitembipl.Rows[0]["StitchQty"].ToString() != "0.0" && dtitembipl.Rows[0]["StitchQty"].ToString() != "0.00")
        //            {
        //                if (CheckZero(dtitembipl.Rows[0]["StitchQty"].ToString()))
        //                {
        //                    //lblstitchQty_bipl.Text = dtitembipl.Rows[0]["StitchQty"].ToString() + " k";
        //                    //hdstitchQty_BIPL.Value = dtitembipl.Rows[0]["StitchQty"].ToString();

        //                    lblstitchQty_bipl.Text = Get(dtitembipl.Rows[0]["StitchQty"].ToString());
        //                    //hdstitchQty_BIPL.Value = Get(dtitembipl.Rows[0]["StitchQty"].ToString()).Replace("k", "");
        //                    hdstitchQty_BIPL.Value = GetValueDivideByThousand(dtitembipl.Rows[0]["StitchQty"].ToString());

        //                }
        //            }
        //            // comment by bharat 6may
        //            //////if (dtitembiplLastday.Rows[0]["StitchQty"].ToString() != "" && dtitembiplLastday.Rows[0]["StitchQty"].ToString() != "0" && dtitembiplLastday.Rows[0]["StitchQty"].ToString() != "0.0" && dtitembiplLastday.Rows[0]["StitchQty"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitembiplLastday.Rows[0]["StitchQty"].ToString()))
        //            //////    {
        //            //////        //lbllastdaystitchQty_BIPL.Text = dtitembiplLastday.Rows[0]["StitchQty"].ToString() + " k";
        //            //////        lbllastdaystitchQty_BIPL.Text = Get_WithDecimal(dtitembiplLastday.Rows[0]["StitchQty"].ToString());
        //            //////    }
        //            //////}
        //            //////if (dtitembiplLastday.Rows[0]["Stitchedvalue"].ToString() != "" && dtitembiplLastday.Rows[0]["Stitchedvalue"].ToString() != "0" && dtitembiplLastday.Rows[0]["Stitchedvalue"].ToString() != "0.00" && dtitembiplLastday.Rows[0]["Stitchedvalue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitembiplLastday.Rows[0]["Stitchedvalue"].ToString()))
        //            //////    {
        //            //////        lbllastdaystitchval_BIPL.Text = "<span style='color:green;'> \u20B9 " + dtitembiplLastday.Rows[0]["Stitchedvalue"].ToString() + " Cr</span>";
        //            //////    }
        //            //////}
        //            //////if (dtitembiplLastday.Rows[0]["finishedvalue"].ToString() != "" && dtitembiplLastday.Rows[0]["finishedvalue"].ToString() != "0" && dtitembiplLastday.Rows[0]["finishedvalue"].ToString() != "0.00" && dtitembiplLastday.Rows[0]["finishedvalue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitembiplLastday.Rows[0]["finishedvalue"].ToString()))
        //            //////        lblfinishvallastday_BIPL.Text = "<span style='color:green;'>\u20B9 " + dtitembiplLastday.Rows[0]["finishedvalue"].ToString() + " Cr</span>";
        //            //////}
        //            //last month====
        //            //////if (dtitemBIpllastday_month.Rows[0]["StitchQty"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["StitchQty"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["StitchQty"].ToString() != "0.0" && dtitemBIpllastday_month.Rows[0]["StitchQty"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtitemBIpllastday_month.Rows[0]["StitchQty"].ToString()))
        //            //////    {
        //            //////        //lbllastdaystitchQty_BIPL_month.Text = Math.Round(Convert.ToDecimal(dtitemBIpllastday_month.Rows[0]["StitchQty"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //            //////        lbllastdaystitchQty_BIPL_month.Text = Math.Round(Convert.ToDecimal(Get(dtitemBIpllastday_month.Rows[0]["StitchQty"].ToString()).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //            //////    }

        //            //////}
        //            //last month====
        //            //////if (dtitemBIpllastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "" && dtitemBIpllastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "0" && dtitemBIpllastday_month_avg.Rows[0]["StitchQtyavg"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemBIpllastday_month_avg.Rows[0]["StitchQtyavg"].ToString()))
        //            //////    {
        //            //////        //lbllastdaystitchQty_BIPL_month_avg.Text = dtitemBIpllastday_month_avg.Rows[0]["StitchQtyavg"].ToString() + " k<span style='font-size: 8px;color:black;'> pdy</span>";
        //            //////        lbllastdaystitchQty_BIPL_month_avg.Text = GetLastMonthPDY(dtitemBIpllastday_month_avg.Rows[0]["StitchQtyavg"].ToString()) + " <span style='font-size: 8px;color:black;'> pdy</span>";
        //            //////    }
        //            //////}

        //            //----------------------prabhaker code start------------------//
        //            //////if (dtitemBIpllastday_month_val.Rows[0]["StitchedValue"].ToString() != "" && dtitemBIpllastday_month_val.Rows[0]["StitchedValue"].ToString() != "0" && dtitemBIpllastday_month_val.Rows[0]["StitchedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemBIpllastday_month_val.Rows[0]["StitchedValue"].ToString()))
        //            //////        lbllastdaystitchval_BIPL_month.Text = "<span style='color:green;'>\u20B9 " + dtitemBIpllastday_month_val.Rows[0]["StitchedValue"].ToString() + " Cr.</span>";

        //            //////}


        //            //-------------------end of prabhaker code------------------//
        //            //last month=three=month==
        //            //////if (dtlastthreemonth.Rows[0]["StitchQty"].ToString() != "" && dtlastthreemonth.Rows[0]["StitchQty"].ToString() != "0" && dtlastthreemonth.Rows[0]["StitchQty"].ToString() != "0.0" && dtlastthreemonth.Rows[0]["StitchQty"].ToString() != "0.00")
        //            //////{

        //            //////    //lbllastdaystitchQty_BIPL_3month.Text = dtlastthreemonth.Rows[0]["StitchQty"].ToString() + " k";
        //            //////    if (Math.Round(Convert.ToDecimal(dtlastthreemonth.Rows[0]["StitchQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
        //            //////    {
        //            //////        //lbllastdaystitchQty_BIPL_3month.Text = Math.Round(Convert.ToDecimal(dtlastthreemonth.Rows[0]["StitchQty"].ToString()), MidpointRounding.AwayFromZero) + " k";
        //            //////        lbllastdaystitchQty_BIPL_3month.Text = Math.Round(Convert.ToDecimal(Get(dtlastthreemonth.Rows[0]["StitchQty"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";
        //            //////    }

        //            //////}
        //            //last month=three=month====avg
        //            //////if (dtlastthreemonthavg.Rows[0]["StitchQtyavg"].ToString() != "" && dtlastthreemonthavg.Rows[0]["StitchQtyavg"].ToString() != "0" && dtlastthreemonthavg.Rows[0]["StitchQtyavg"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtlastthreemonthavg.Rows[0]["StitchQtyavg"].ToString()))
        //            //////    {
        //            //////        //lbllastdaystitchQty_BIPL_3month_avg.Text = dtlastthreemonthavg.Rows[0]["StitchQtyavg"].ToString() + " k" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
        //            //////        lbllastdaystitchQty_BIPL_3month_avg.Text = Get(dtlastthreemonthavg.Rows[0]["StitchQtyavg"].ToString()) + "" + " <span style='font-size: 8px;color:black;'>" + "pdy" + "</span>";
        //            //////        lbllastdaystitchval_BIPL_3month.Text = "<span style='color:green;'>\u20B9 " + dtlastthreemonthavg.Rows[0]["StitchedValue"].ToString() + " Cr.</span>";
        //            //////    }
        //            //////}

        //            //------------prabhaker code start----------------//
        //            //if (dtavglastthree_val.Rows[0]["StitchedValue"].ToString() != "" && dtavglastthree_val.Rows[0]["StitchedValue"].ToString() != "0" && dtavglastthree_val.Rows[0]["StitchedValue"].ToString() != "0.0")
        //            //{

        //            //    lbllastdaystitchval_BIPL_3month.Text = " \u20B9 " + dtavglastthree_val.Rows[0]["StitchedValue"].ToString() + " Cr.";

        //            //}

        //            //------------end of prabhaker code-----------------//
        //            Label lblFinishQty_bipl = (Label)e.Row.FindControl("lblFinishQty_bipl");
        //            HiddenField hdFinishQty_BIPL = (HiddenField)e.Row.FindControl("hdFinishQty_BIPL");
        //            if (dtitembipl.Rows[0]["Finish"].ToString() != "" && dtitembipl.Rows[0]["Finish"].ToString() != "0" && dtitembipl.Rows[0]["Finish"].ToString() != "0.0")
        //            {
        //                if (CheckZero(dtitembipl.Rows[0]["Finish"].ToString()))
        //                {
        //                    //lblFinishQty_bipl.Text = dtitembipl.Rows[0]["Finish"].ToString() + " k";
        //                    //hdFinishQty_BIPL.Value = dtitembipl.Rows[0]["Finish"].ToString();

        //                    lblFinishQty_bipl.Text = Get(dtitembipl.Rows[0]["Finish"].ToString());
        //                    //hdFinishQty_BIPL.Value = Get(dtitembipl.Rows[0]["Finish"].ToString()).Replace("k", "");
        //                    hdFinishQty_BIPL.Value = GetValueDivideByThousand(dtitembipl.Rows[0]["Finish"].ToString());


        //                }
        //            }

        //            // comment by bharat 6may
        //            //////if (dtitembiplLastday.Rows[0]["FinishQty"].ToString() != "" && dtitembiplLastday.Rows[0]["FinishQty"].ToString() != "0" && dtitembiplLastday.Rows[0]["FinishQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitembiplLastday.Rows[0]["FinishQty"].ToString()))
        //            //////    {
        //            //////        //lblfinishQtylastday_BIPL.Text = dtitembiplLastday.Rows[0]["FinishQty"].ToString() + " k";
        //            //////        lblfinishQtylastday_BIPL.Text = Get_WithDecimal(dtitembiplLastday.Rows[0]["FinishQty"].ToString());
        //            //////    }
        //            //////}
        //            //last month====
        //            //////if (dtitemBIpllastday_month.Rows[0]["FinishQty"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["FinishQty"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["FinishQty"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemBIpllastday_month.Rows[0]["FinishQty"].ToString()))
        //            //////    {
        //            //////        //lblfinishQtylastday_BIPL_month.Text = Math.Round(Convert.ToDecimal(dtitemBIpllastday_month.Rows[0]["FinishQty"].ToString()), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //            //////        lblfinishQtylastday_BIPL_month.Text = Math.Round(Convert.ToDecimal(Get(dtitemBIpllastday_month.Rows[0]["FinishQty"].ToString()).Replace("k", "")), 0, MidpointRounding.AwayFromZero).ToString() + " k";
        //            //////    }
        //            //////}
        //            //last month====
        //            //////if (dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "" && dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0" && dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString()))
        //            //////    {
        //            //////        //lblfinishQtylastday_BIPL_month_avg.Text = dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString() + " k <span style='font-size: 8px;color:Gray;'>pdy</span>";
        //            //////        lblfinishQtylastday_BIPL_month_avg.Text = GetLastMonthPDY(dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString()) + " <span style='font-size: 8px;color:Gray;'>pdy</span>";
        //            //////        lblfinishQtylastday_BIPL_month_avg.ForeColor = Color.Gray;
        //            //////    }

        //            //////}

        //            //-------------------prabhaker code start----------------//
        //            //////if (dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString() != "" && dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString() != "0" && dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString() != "0.0")
        //            //////{
        //            //////    if (CheckZero(dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString()))
        //            //////        lblfinishvallastday_BIPL_month.Text = "<span style='color:green;'> \u20B9 " + dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString() + " Cr.</span>";


        //            //////}

        //            //----------------end of prabhaker code-----------------//
        //            //last month====
        //            //////if (dtlastthreemonth.Rows[0]["FinishQty"].ToString() != "" && dtlastthreemonth.Rows[0]["FinishQty"].ToString() != "0" && dtlastthreemonth.Rows[0]["FinishQty"].ToString() != "0.0" && dtlastthreemonth.Rows[0]["FinishQty"].ToString() != "0.00")
        //            //////{

        //            //////    // lblfinishQtylastday_BIPL_3month.Text = dtlastthreemonth.Rows[0]["FinishQty"].ToString() + " k";
        //            //////    if (Math.Round(Convert.ToDecimal(dtlastthreemonth.Rows[0]["FinishQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
        //            //////    {
        //            //////        //lblfinishQtylastday_BIPL_3month.Text = Math.Round(Convert.ToDecimal(dtlastthreemonth.Rows[0]["FinishQty"].ToString()), MidpointRounding.AwayFromZero) + " k";

        //            //////        lblfinishQtylastday_BIPL_3month.Text = Math.Round(Convert.ToDecimal(Get(dtlastthreemonth.Rows[0]["FinishQty"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k";

        //            //////    }

        //            //////}
        //            //////if (dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "" && dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0" && dtitemBIpllastday_month_avg.Rows[0]["FinishQtyavg"].ToString() != "0.0")
        //            //////{

        //            //////    //lblfinishQtylastday_BIPL_3month_avg.Text = dtlastthreemonthavg.Rows[0]["FinishQtyavg"].ToString() + " k" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";
        //            //////    lblfinishQtylastday_BIPL_3month_avg.Text = Get(dtlastthreemonthavg.Rows[0]["FinishQtyavg"].ToString()) + "" + " <span style='font-size: 8px;'>" + "pdy" + "</span>";

        //            //////}
        //            //-------------------prabhaker code start----------------//
        //            //////if (dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString() != "" && dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString() != "0" && dtitemBIpllastday_month_val.Rows[0]["FinishedValue"].ToString() != "0.0")
        //            //////{

        //            //////    lblfinishvallastday_BIPL_3month.Text = "<span style='color:green;'> \u20B9 " + dtlastthreemonthval.Rows[0]["FinishedValue"].ToString() + " Cr.</span>";

        //            //////}

        //            //----------------end of prabhaker code-----------------//
        //            Label lblShipedQty_bipl = (Label)e.Row.FindControl("lblShipedQty_bipl");
        //            HiddenField hdShipedQty_BIPL = (HiddenField)e.Row.FindControl("hdShipedQty_BIPL");
        //            // edit
        //            HiddenField hdPenalty_BIPL = (HiddenField)e.Row.FindControl("hdPenalty_BIPL");

        //            // end
        //            if (dtitembipl.Rows[0]["ShipQty"].ToString() != "" && dtitembipl.Rows[0]["ShipQty"].ToString() != "0" && dtitembipl.Rows[0]["ShipQty"].ToString() != "0.0")
        //            {
        //                //lblShipedQty_bipl.Text = dtitembipl.Rows[0]["ShipQty"].ToString() + " k";
        //                //hdShipedQty_BIPL.Value = dtitembipl.Rows[0]["ShipQty"].ToString();

        //                lblShipedQty_bipl.Text = Get(dtitembipl.Rows[0]["ShipQty"].ToString());
        //                //hdShipedQty_BIPL.Value = Get(dtitembipl.Rows[0]["ShipQty"].ToString()).Replace("k", "");
        //                hdShipedQty_BIPL.Value = GetValueDivideByThousand(dtitembipl.Rows[0]["ShipQty"].ToString());
        //            }

        //            // comment by bharat 6may
        //            //////if (dtitembiplLastday.Rows[0]["ShipQty"].ToString() != "" && dtitembiplLastday.Rows[0]["ShipQty"].ToString() != "0" && dtitembiplLastday.Rows[0]["ShipQty"].ToString() != "0.0")
        //            //////{

        //            //////    //lbllastdayShipQty_BIPL.Text = dtitembiplLastday.Rows[0]["ShipQty"].ToString() + " k";
        //            //////    lbllastdayShipQty_BIPL.Text = Get(dtitembiplLastday.Rows[0]["ShipQty"].ToString());
        //            //////}
        //            //last month====
        //            //////if (dtitemBIpllastday_month.Rows[0]["ShipQty"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["ShipQty"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["ShipQty"].ToString() != "0.0")
        //            //////{

        //            //////    //lbllastdayShipQty_BIPL_month.Text = Math.Round((Convert.ToDecimal(dtitemBIpllastday_month.Rows[0]["ShipQty"].ToString())), MidpointRounding.AwayFromZero) + " k";
        //            //////    lbllastdayShipQty_BIPL_month.Text = Math.Round((Convert.ToDecimal(Get(dtitemBIpllastday_month.Rows[0]["ShipQty"].ToString()).Replace("k", ""))), MidpointRounding.AwayFromZero) + " k";

        //            //////}
        //            //////if (dtlastthreemonth.Rows[0]["ShipQty"].ToString() != "" && dtlastthreemonth.Rows[0]["ShipQty"].ToString() != "0" && dtlastthreemonth.Rows[0]["ShipQty"].ToString() != "0.0")
        //            //////{

        //            //////    //  lbllastdayShipQty_BIPL_3month.Text = dtlastthreemonth.Rows[0]["ShipQty"].ToString() + " k";
        //            //////    if (Math.Round((Convert.ToDecimal(dtlastthreemonth.Rows[0]["ShipQty"].ToString()) / 3), MidpointRounding.AwayFromZero) > 0)
        //            //////    {
        //            //////        //lbllastdayShipQty_BIPL_3month.Text = Math.Round((Convert.ToDecimal(dtlastthreemonth.Rows[0]["ShipQty"].ToString())/3), MidpointRounding.AwayFromZero) + " k";
        //            //////        lbllastdayShipQty_BIPL_3month.Text = Math.Round((Convert.ToDecimal(Get(dtlastthreemonth.Rows[0]["ShipQty"].ToString()).Replace("k", "")) / 3), MidpointRounding.AwayFromZero) + " k";
        //            //////    }

        //            //////}
        //            Label lblShipedVal_bipl = (Label)e.Row.FindControl("lblShipedVal_bipl");
        //            HiddenField hdnShipedVal_BIPL = (HiddenField)e.Row.FindControl("hdnShipedVal_BIPL");
        //            if (dtitembipl.Rows[0]["ShipValue"].ToString() != "" && dtitembipl.Rows[0]["ShipValue"].ToString() != "0" && dtitembipl.Rows[0]["ShipValue"].ToString() != "0.0" && dtitembipl.Rows[0]["ShipValue"].ToString() != "0.00")
        //            {
        //                lblShipedVal_bipl.Text = "/ <span style='color:green;'> \u20B9 " + dtitembipl.Rows[0]["ShipValue"].ToString() + " Cr.</span>";


        //                hdnShipedVal_BIPL.Value = dtitembipl.Rows[0]["ShipValue"].ToString();
        //            }

        //            // comment by bharat 6may
        //            //////if (dtitembiplLastday.Rows[0]["ShipedValue"].ToString() != "" && dtitembiplLastday.Rows[0]["ShipedValue"].ToString() != "0" && dtitembiplLastday.Rows[0]["ShipedValue"].ToString() != "0.0" && dtitembiplLastday.Rows[0]["ShipedValue"].ToString() != "0.0")
        //            //////{

        //            //////    lbllastdayShipVal_BIPL.Text = "/" + "<span style='color:green;'>\u20B9 " + dtitembiplLastday.Rows[0]["ShipedValue"].ToString() + " Cr.</span>";

        //            //////}
        //            //last month====
        //            //////if (dtitemBIpllastday_month.Rows[0]["ShipedValue"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["ShipedValue"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["ShipedValue"].ToString() != "0.0")
        //            //////{

        //            //////    lbllastdayShipVal_BIPL_month.Text = "/" + "<span style='color:green;'> \u20B9 " + dtitemBIpllastday_month.Rows[0]["ShipedValue"].ToString() + " Cr.</span>";

        //            //////}
        //            //////if (dtlastthreemonth.Rows[0]["ShipedValue"].ToString() != "" && dtlastthreemonth.Rows[0]["ShipedValue"].ToString() != "0" && dtlastthreemonth.Rows[0]["ShipedValue"].ToString() != "0.0")
        //            //////{


        //            //////    if (Convert.ToDecimal(dtlastthreemonth.Rows[0]["ShipedValue"].ToString()) / 3 > 0)
        //            //////    {
        //            //////        lbllastdayShipVal_BIPL_3month.Text = "/" + "<span style='color:green;'> \u20B9 " + Math.Round(Convert.ToDecimal(dtlastthreemonth.Rows[0]["ShipedValue"].ToString()) / 3, 1) + " Cr.</span>";
        //            //////    }

        //            //////}
        //            Label lblCtsl_bipl = (Label)e.Row.FindControl("lblCtsl_bipl");
        //            HiddenField hdnCtsl_BIPL = (HiddenField)e.Row.FindControl("hdnCtsl_BIPL");
        //            if (dtitembipl.Rows[0]["ShipCtsl"].ToString() != "" && dtitembipl.Rows[0]["ShipCtsl"].ToString() != "0" && dtitembipl.Rows[0]["ShipCtsl"].ToString() != "0.0")
        //            {
        //                lblCtsl_bipl.Text = dtitembipl.Rows[0]["ShipCtsl"].ToString() + "%";
        //                hdnCtsl_BIPL.Value = dtitembipl.Rows[0]["ShipCtsl"].ToString();
        //            }

        //            // comment by bharat 6may
        //            //////if (dtitembiplLastday.Rows[0]["ctsl"].ToString() != "" && dtitembiplLastday.Rows[0]["ctsl"].ToString() != "0" && dtitembiplLastday.Rows[0]["ctsl"].ToString() != "0.0")
        //            //////{

        //            //////    lbllastdayShipCtsl_BIPL.Text = dtitembiplLastday.Rows[0]["ctsl"].ToString() + "%";
        //            //////}
        //            //last month====
        //            //////if (dtitemBIpllastday_month.Rows[0]["ctsl"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["ctsl"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["ctsl"].ToString() != "0.0")
        //            //////{

        //            //////    lbllastdayShipCtsl_BIPL_month.Text = dtitemBIpllastday_month.Rows[0]["ctsl"].ToString() + " %";
        //            //////    if (Convert.ToInt32(dtitemBIpllastday_month.Rows[0]["RescanQty"]) > 0)
        //            //////        lbllastdayShipCtsl_BIPL_month.Text = lbllastdayShipCtsl_BIPL_month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(dtitemBIpllastday_month.Rows[0]["RescanQty"].ToString()) + " </span>";

        //            //////}
        //            //////if (dtitemBIpllastday_month.Rows[0]["ctsl"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["ctsl"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["ctsl"].ToString() != "0.0")
        //            //////{

        //            //////    lbllastdayShipCtsl_BIPL_3month.Text = dtlastthreemonth.Rows[0]["ctsl"].ToString() + " %";
        //            //////    if (Convert.ToInt32(dtlastthreemonth.Rows[0]["RescanQty"]) > 0)
        //            //////    {
        //            //////        string RescanQty = Math.Round(Convert.ToDouble(((Convert.ToDouble(dtlastthreemonth.Rows[0]["RescanQty"].ToString())) / Convert.ToDouble(3))), 0, MidpointRounding.AwayFromZero).ToString();
        //            //////        lbllastdayShipCtsl_BIPL_3month.Text = lbllastdayShipCtsl_BIPL_3month.Text + " " + "<span style='font-weight: bold;color:red'>" + Get(RescanQty) + " </span>";
        //            //////    }


        //            //////}
        //            Label lblShipedPendingQty_BIPL = (Label)e.Row.FindControl("lblShipedPendingQty_BIPL");
        //            HiddenField hdShipedPendingQty_BIPL = (HiddenField)e.Row.FindControl("hdShipedPendingQty_BIPL");
        //            Label lblPendingStitchQty_BIPL = (Label)e.Row.FindControl("lblPendingStitchQty_BIPL");
        //            HiddenField hdnPendingStitchQty_BIPL = (HiddenField)e.Row.FindControl("hdnPendingStitchQty_BIPL");
        //            if (dtitembipl.Rows[0]["PendingShipQty"].ToString() != "" && dtitembipl.Rows[0]["PendingShipQty"].ToString() != "0" && dtitembipl.Rows[0]["PendingShipQty"].ToString() != "0.0")
        //            {


        //                if ((Math.Round(Convert.ToDecimal(dtitembipl.Rows[0]["PendingShipQty"].ToString()), MidpointRounding.AwayFromZero)) > 0)
        //                {
        //                    //lblShipedPendingQty_BIPL.Text = Math.Round(Convert.ToDecimal(dtitembipl.Rows[0]["PendingShipQty"].ToString()), MidpointRounding.AwayFromZero) + " k";                  

        //                    // lblShipedPendingQty_BIPL.Text = Get(dtitembipl.Rows[0]["PendingShipQty"].ToString());
        //                    //lblShipedPendingQty_BIPL.Text = Get(dtitembipl.Rows[0]["PendingShipQty"].ToString());
        //                }
        //                //hdShipedPendingQty_BIPL.Value = Math.Round(Convert.ToDecimal(Get(dtitembipl.Rows[0]["PendingShipQty"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero).ToString();
        //                hdShipedPendingQty_BIPL.Value = GetValueDivideByThousand(dtitembipl.Rows[0]["PendingShipQty"].ToString());

        //                //if (e.Row.RowIndex == 0)
        //                //{
        //                //    if (dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() != "0.0")
        //                //    {

        //                //        lblShipedPendingQty_BIPL.Text = lblShipedPendingQty_BIPL.Text + " (" + dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() + " k" + ")";

        //                //    }
        //                //}                    
        //            }
        //            if (dtitembipl.Rows[0]["PendingStitchQty"].ToString() != "" && dtitembipl.Rows[0]["PendingStitchQty"].ToString() != "0" && dtitembipl.Rows[0]["PendingStitchQty"].ToString() != "0.0" && dtitembipl.Rows[0]["PendingStitchQty"].ToString() != "0.00")
        //            {

        //                if (Math.Round(Convert.ToDecimal(dtitembipl.Rows[0]["PendingStitchQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
        //                {
        //                    //lblPendingStitchQty_BIPL.Text = Math.Round(Convert.ToDecimal(dtitembipl.Rows[0]["PendingStitchQty"].ToString()), MidpointRounding.AwayFromZero) + " k";
        //                    lblPendingStitchQty_BIPL.Text = Get(dtitembipl.Rows[0]["PendingStitchQty"].ToString());

        //                }
        //                //hdnPendingStitchQty_BIPL.Value = Math.Round(Convert.ToDecimal(Get(dtitembipl.Rows[0]["PendingStitchQty"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero).ToString();
        //                hdnPendingStitchQty_BIPL.Value = GetValueDivideByThousand(dtitembipl.Rows[0]["PendingStitchQty"].ToString());
        //            }
        //            if (e.Row.RowIndex == 0)
        //            {
        //                lblShipedPendingQty_BIPL.Text = dtitembipl.Rows[0]["PendingShipQty"].ToString();
        //                if (dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() != "0.00")
        //                {
        //                    if (lblShipedPendingQty_BIPL.Text.Trim() != "")
        //                    {
        //                        //if (Math.Round(Convert.ToDecimal(lblShipedPendingQty_BIPL.Text.Trim())) > 0)
        //                        //{
        //                        //lblShipedPendingQty_BIPL.Text = Math.Round(Convert.ToDecimal(lblShipedPendingQty_BIPL.Text.Trim().Replace("k", "")),0, MidpointRounding.AwayFromZero).ToString() + " k";
        //                        //lblShipedPendingQty_BIPL.Text = Get(lblShipedPendingQty_BIPL.Text.Trim().Replace("k", ""));
        //                        lblShipedPendingQty_BIPL.Text = Get(lblShipedPendingQty_BIPL.Text.Trim(), 0);
        //                        //}
        //                    }
        //                    if (Math.Round(Convert.ToDecimal(dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString()), MidpointRounding.AwayFromZero) > 0)
        //                    {
        //                        //lblShipedPendingQty_BIPL.Text = lblShipedPendingQty_BIPL.Text + " (" + Math.Round(Convert.ToDecimal(dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString()), MidpointRounding.AwayFromZero) + " k" + ")";
        //                        //lblShipedPendingQty_BIPL.Text = lblShipedPendingQty_BIPL.Text + " (" + Math.Round(Convert.ToDecimal(Get(dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString()).Replace("k", "")), MidpointRounding.AwayFromZero) + " k" + ")";
        //                        lblShipedPendingQty_BIPL.Text = lblShipedPendingQty_BIPL.Text + " (" + Get(dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString(), 0) + ")";
        //                        // lblShipedPendingQty_BIPL.Text = Get(lblShipedPendingQty_BIPL.Text.Trim().Replace("k", ""));
        //                    }


        //                }
        //            }
        //            else
        //            {
        //                lblShipedPendingQty_BIPL.Text = Get(dtitembipl.Rows[0]["PendingShipQty"].ToString());
        //            }
        //            //if (dtitembiplLastday.Rows[0]["ctsl"].ToString() != "" && dtitembiplLastday.Rows[0]["ctsl"].ToString() != "0" && dtitembiplLastday.Rows[0]["ctsl"].ToString() != "0.0")
        //            //{

        //            //    lbllastdayShipCtsl_BIPL.Text = dtitembiplLastday.Rows[0]["ctsl"].ToString();
        //            //}
        //            Label lblShipedPendingVal_bipl = (Label)e.Row.FindControl("lblShipedPendingVal_bipl");
        //            HiddenField hdnShipedPendingVal_BIPL = (HiddenField)e.Row.FindControl("hdnShipedPendingVal_BIPL");
        //            if (dtitembipl.Rows[0]["PendingShipValue"].ToString() != "" && dtitembipl.Rows[0]["PendingShipValue"].ToString() != "0" && dtitembipl.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitembipl.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //            {
        //                lblShipedPendingVal_bipl.Text = "<span style='color:green;'> \u20B9 " + dtitembipl.Rows[0]["PendingShipValue"].ToString() + " Cr</span>";


        //                hdnShipedPendingVal_BIPL.Value = dtitembipl.Rows[0]["PendingShipValue"].ToString();

        //                //if (e.Row.RowIndex == 0)
        //                //{
        //                //    if (dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() != "0.0")
        //                //    {
        //                //        lblShipedPendingVal_bipl.Text = lblShipedPendingVal_bipl.Text + " (" + "<span style='color:green;'> " + " \u20B9 " + dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() + " Cr" + ")"+"</span>";
        //                //    }
        //                //}
        //            }
        //            if (e.Row.RowIndex == 0)
        //            {
        //                if (dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() != "0.00" && dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() != "0.0")
        //                {
        //                    lblShipedPendingVal_bipl.Text = lblShipedPendingVal_bipl.Text + " (<span style='color:green;'> " + " \u20B9 " + dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() + " Cr.</span> )";
        //                }
        //            }

        //            Label lblShipedPendingVal_fob_BIPL = (Label)e.Row.FindControl("lblShipedPendingVal_fob_BIPL");
        //            Label lblPenaltyTotal_fob_BIPL = (Label)e.Row.FindControl("lblPenaltyTotal_fob_BIPL");
        //            HiddenField hdnfobpercentage_bipl = (HiddenField)e.Row.FindControl("hdnfobpercentage_bipl");
        //            if (dtitembipl.Rows[0]["PercentageFob"].ToString() != "" && dtitembipl.Rows[0]["PercentageFob"].ToString() != "0" && dtitembipl.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitembipl.Rows[0]["PercentageFob"].ToString() != "0.00")
        //            {
        //                lblShipedPendingVal_fob_BIPL.Text = dtitembipl.Rows[0]["PercentageFob"].ToString() + " %";


        //                //hdnfobpercentage_bipl.Value = dtitembipl.Rows[0]["PercentageFob"].ToString();
        //            }
        //            if (dtitembipl.Rows[0]["PenaltyValue"].ToString() != "" && dtitembipl.Rows[0]["PenaltyValue"].ToString() != "0" && dtitembipl.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitembipl.Rows[0]["PenaltyValue"].ToString() != "0.00")
        //            {
        //                lblPenaltyTotal_fob_BIPL.Text = "<span style='color:red;'>  \u20B9 " + dtitembipl.Rows[0]["PenaltyValue"].ToString() + " Lk</span> / ";
        //                hdPenalty_BIPL.Value = dtitembipl.Rows[0]["PenaltyValue"].ToString();


        //                //hdnfobpercentage_bipl.Value = dtitembipl.Rows[0]["PercentageFob"].ToString();
        //            }

        //            // comment by bharat 6 may
        //            //////if (dtitembiplLastday.Rows[0]["PendingShipQty"].ToString() != "" && dtitembiplLastday.Rows[0]["PendingShipQty"].ToString() != "0" && dtitembiplLastday.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitembiplLastday.Rows[0]["PendingShipQty"].ToString() != "0.00")
        //            //////{

        //            //////    //lblpendingshipedQtyBipl.Text = Get(dtitembiplLastday.Rows[0]["PendingShipQty"].ToString());
        //            //////    lblpendingshipedQtyBipl.Text = Get_WithDecimal(dtitembiplLastday.Rows[0]["PendingShipQty"].ToString());

        //            //////}
        //            //last month====
        //            //////if (dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() != "0.0" && dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() != "0.00")
        //            //////{

        //            //////    //lblpendingshipedQtyBipl_month.Text = dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString() + " k";
        //            //////    lblpendingshipedQtyBipl_month.Text = Get(dtitemBIpllastday_month.Rows[0]["PendingShipQty"].ToString()).Replace("k", "") + " k";

        //            //////}
        //            //////if (dtlastthreemonth.Rows[0]["PendingShipQty"].ToString() != "" && dtlastthreemonth.Rows[0]["PendingShipQty"].ToString() != "0" && dtlastthreemonth.Rows[0]["PendingShipQty"].ToString() != "0.0")
        //            //////{

        //            //////    //lblpendingshipedQtyBipl_3month.Text = dtlastthreemonth.Rows[0]["PendingShipQty"].ToString() + " k";
        //            //////    lblpendingshipedQtyBipl_3month.Text = Get(dtlastthreemonth.Rows[0]["PendingShipQty"].ToString()).Replace("k", "") + " k";

        //            //////}

        //            // comment by bharat 6may
        //            //////if (dtitembiplLastday.Rows[0]["PendingShipValue"].ToString() != "" && dtitembiplLastday.Rows[0]["PendingShipValue"].ToString() != "0" && dtitembiplLastday.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitembiplLastday.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //            //////{

        //            //////    lblpendingShipedshipedvalueBipl.Text = "<span style='color:green;'> \u20B9 " + dtitembiplLastday.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

        //            //////}
        //            //last month====
        //            //////if (dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //            //////{

        //            //////    lblpendingShipedshipedvalueBipl_month.Text = "<span style='color:green;'> \u20B9 " + dtitemBIpllastday_month.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

        //            //////}
        //            //////if (dtlastthreemonth.Rows[0]["PendingShipValue"].ToString() != "" && dtlastthreemonth.Rows[0]["PendingShipValue"].ToString() != "0" && dtlastthreemonth.Rows[0]["PendingShipValue"].ToString() != "0.0" && dtlastthreemonth.Rows[0]["PendingShipValue"].ToString() != "0.00")
        //            //////{

        //            //////    lblpendingShipedshipedvalueBipl_3month.Text = "<span style='color:green;'> \u20B9 " + dtlastthreemonth.Rows[0]["PendingShipValue"].ToString() + " Cr.</span>";

        //            //////}
        //            // Comment by bharat 6may

        //            //////if (dtitembiplLastday.Rows[0]["PercentageFob"].ToString() != "" && dtitembiplLastday.Rows[0]["PercentageFob"].ToString() != "0" && dtitembiplLastday.Rows[0]["PercentageFob"].ToString() != "0.0" && dtitembiplLastday.Rows[0]["PercentageFob"].ToString() != "0.00")
        //            //////{

        //            //////    lblpendingShipedshipedvalue_fob_Bipl.Text = dtitembiplLastday.Rows[0]["PercentageFob"].ToString() + " %";

        //            //////}

        //            //////if (dtitembiplLastday.Rows[0]["PenaltyValue"].ToString() != "" && dtitembiplLastday.Rows[0]["PenaltyValue"].ToString() != "0" && dtitembiplLastday.Rows[0]["PenaltyValue"].ToString() != "0.0" && dtitembiplLastday.Rows[0]["PenaltyValue"].ToString() != "0.00")
        //            //////{

        //            //////    lblpendingPenaltyValue_fob_Bipl.Text = "\u20B9 " + dtitembiplLastday.Rows[0]["PenaltyValue"].ToString() + " Lk /";


        //            //////}
        //            //////if (dtitemBIpllastday_month.Rows[0]["PercentageFob"].ToString() != "" && dtitemBIpllastday_month.Rows[0]["PercentageFob"].ToString() != "0" && dtitemBIpllastday_month.Rows[0]["PercentageFob"].ToString() != "0.00" && dtitemBIpllastday_month.Rows[0]["PercentageFob"].ToString() != "0.0")
        //            //////{

        //            //////    lblpendingShipedshipedvalueBipl_fob_month.Text = dtitemBIpllastday_month.Rows[0]["PercentageFob"].ToString() + " %";

        //            //////}
        //            //////if (Convert.ToInt32(dtitemBIpllastday_month.Rows[0]["PenaltyValue"]) > 0)
        //            //////{

        //            //////    lblpendingPenaltyBipl_fob_month.Text = "\u20B9 " + dtitemBIpllastday_month.Rows[0]["PenaltyValue"].ToString() + " Lk /";

        //            //////}
        //            //////if (dtlastthreemonth.Rows[0]["PercentageFob"].ToString() != "" && dtlastthreemonth.Rows[0]["PercentageFob"].ToString() != "0" && dtlastthreemonth.Rows[0]["PercentageFob"].ToString() != "0.00")
        //            //////{

        //            //////    lblpendingShipedshipedvalueBipl_fob_3month.Text = dtlastthreemonth.Rows[0]["PercentageFob"].ToString() + " %";

        //            //////}
        //            //////if (Convert.ToInt32(dtlastthreemonth.Rows[0]["PenaltyValue"]) > 0)
        //            //////{
        //            //////    if (Convert.ToDecimal(dtlastthreemonth.Rows[0]["PenaltyValue"].ToString()) / 3 > 0)
        //            //////    {
        //            //////        lbl_threeMonth_Penalty_Bipl_fob_3month.Text = "\u20B9 " + Math.Round(Convert.ToDecimal(dtlastthreemonth.Rows[0]["PenaltyValue"].ToString()) / 3, 1) + " Lk" + " /";
        //            //////    }
        //            //////}
        //            //if (lbllastdayCutQty_BIPL.Text != "" && lbllastdayShipQty_BIPL.Text != "")
        //            //{
        //            //    string BiplCtsl_lastday = Math.Round(Convert.ToDouble((Convert.ToDouble(lbllastdayCutQty_BIPL.Text.Replace(" k", "")) - Convert.ToDouble(lbllastdayShipQty_BIPL.Text.Replace(" k", ""))) / Convert.ToDouble(lbllastdayCutQty_BIPL.Text.Replace(" k", ""))), 1, MidpointRounding.AwayFromZero).ToString();
        //            //    lbllastdayShipCtsl_BIPL.Text = BiplCtsl_lastday == "0" ? "" : "(" + BiplCtsl_lastday + " % )"; ;

        //            //}
        //            //////dswip = objadmin.GetWipDetails(0, "CUTWIP");
        //            //////dtwip = dswip.Tables[0];
        //            //////if (dtwip.Rows[0]["CutWip_k"].ToString() != "" && dtwip.Rows[0]["CutWip_k"].ToString() != "0" && dtwip.Rows[0]["CutWip_k"].ToString() != "0.00")
        //            //////{

        //            //////    // lblwipcutbipl_K.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["CutWip_k"].ToString()), 0) + " k" + " <span style='font-size: 8px;'>" + "" + "</span>";
        //            //////    //lblwipcutbipl_K.Text = Math.Round(Convert.ToDecimal(Get(dtwip.Rows[0]["CutWip_k"].ToString()).Replace("k", "")), 0) + " k" + " <span style='font-size: 8px;'>" + "" + "</span>";
        //            //////    lblwipcutbipl_K.Text = Get(dtwip.Rows[0]["CutWip_k"].ToString()) + " <span style='font-size: 8px;'>" + "" + "</span>";

        //            //////}
        //            //////if (dtwip.Rows[0]["CutWip"].ToString() != "" && dtwip.Rows[0]["CutWip"].ToString() != "0" && dtwip.Rows[0]["CutWip"].ToString() != "0.00")
        //            //////{
        //            //////    lblwipcutbipl.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["CutWip"].ToString()), 0) + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
        //            //////}
        //            //////dswip = objadmin.GetWipDetails(0, "STITCHWIP");
        //            //////dtwip = dswip.Tables[0];
        //            //////if (dtwip.Rows[0]["StitchWip_k"].ToString() != "" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0" && dtwip.Rows[0]["StitchWip_k"].ToString() != "0.00")
        //            //////{

        //            //////    //lblwipstitchbipl_K.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["StitchWip_k"].ToString()), 0) + " k" + " <span style='font-size: 8px;'>" + "" + "</span>";
        //            //////    //lblwipstitchbipl_K.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["StitchWip_k"].ToString()), 0) + " k" + " <span style='font-size: 8px;'>" + "" + "</span>";
        //            //////    lblwipstitchbipl_K.Text = Get(dtwip.Rows[0]["StitchWip_k"].ToString()) + " <span style='font-size: 8px;'>" + "" + "</span>";
        //            //////}
        //            //////if (dtwip.Rows[0]["StitchWip"].ToString() != "" && dtwip.Rows[0]["StitchWip"].ToString() != "0" && dtwip.Rows[0]["StitchWip"].ToString() != "0.00")
        //            //////{
        //            //////    lblwipstitchbipl.Text = Math.Round(Convert.ToDecimal(dtwip.Rows[0]["StitchWip"].ToString()), 0) + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
        //            //////}
        //            //////dswip = objadmin.GetWipDetails(0, "FINISHWIP");
        //            //////dtwip = dswip.Tables[0];
        //            //////if (dtwip.Rows[0]["FinishWip_k"].ToString() != "" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0" && dtwip.Rows[0]["FinishWip_k"].ToString() != "0.00")
        //            //////{
        //            //////    lblwipfinishbipl_K.Text = Get(dtwip.Rows[0]["FinishWip_k"].ToString());
        //            //////}
        //            //////if (dtwip.Rows[0]["FINISHWIP"].ToString() != "" && dtwip.Rows[0]["FINISHWIP"].ToString() != "0" && dtwip.Rows[0]["FINISHWIP"].ToString() != "0.00")
        //            //////{
        //            //////    // lblwipfinishbipl.Text = dtwip.Rows[0]["FINISHWIP"].ToString() + " D"; //+ " k" + " <span style='font-size: 8px;'>" + "D" + "</span>";
        //            //////    if (Convert.ToDecimal(dtwip.Rows[0]["FINISHWIP"].ToString()) > 2)
        //            //////    {

        //            //////        lblwipfinishbipl.Text = " <span style='font-weight: bold;color:red'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FINISHWIP"].ToString()), 0) + " D" + "</span>";
        //            //////    }
        //            //////    else
        //            //////    {
        //            //////        lblwipfinishbipl.Text = " <span style='color:black'>" + Math.Round(Convert.ToDecimal(dtwip.Rows[0]["FINISHWIP"].ToString()), 0) + " D</span>";
        //            //////    }
        //            //////}

        //            //////// Pending Rescan value for BIPL
        //            //////dswip = objadmin.GetWipDetails(0, "PENDING_RESCAN");
        //            //////dtwip = dswip.Tables[0];
        //            //////if (dtwip.Rows[0]["RescanValue"].ToString() != "" && dtwip.Rows[0]["RescanValue"].ToString() != "0" && dtwip.Rows[0]["RescanValue"].ToString() != "0.00")
        //            //////{
        //            //////    if (CheckZero(dtwip.Rows[0]["RescanValue"].ToString()))
        //            //////    {
        //            //////        lblPendingRescanBIPL_k.Text = Get(dtwip.Rows[0]["RescanValue"].ToString()) + " <span style='color:red; font-size: 8px;'>" + "" + "</span>";
        //            //////    }
        //            //////}
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}


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

                    GetCtslVlaueSum += Convert.ToDouble(lblvalue.Text.Replace("k", "").Replace("\u20B9 ", ""));
                }
                lblvalue.Text = "<span style='color:green;'> " + " \u20B9 " + lblvalue.Text + " k" + "</span>";
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
                    spOrderValueIctotal.InnerText = "<span style='color:green;'> " + " \u20B9 " + dtitem_ic_foter.Rows[0]["fotertotalOrderValue"].ToString() + "</span>" + " Cr";


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

                    //lblPrice.Text = StrTag + " " + Math.Round(Convert.ToDouble(lblPrice.Text), 2, MidpointRounding.AwayFromZero).ToString();
                    lblPrice.Text = StrTag + " " + lblPrice.Text;
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
                    lblOrderValueValue.Text = "<span style='color:green;'> " + " \u20B9 " + lblOrderValueValue.Text + "</span>";



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
                //lblvalue.Text = "\u20B9 " + lblvalue.Text + "k";
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

                //    GetCtslVlaueSum += Convert.ToDouble(lblvalue.Text.Replace("k", "").Replace("\u20B9 ", ""));
                //}
                Label lblctsldetaild = (Label)item.FindControl("lblctsldetaild");
                Label lblctslqnty = (Label)item.FindControl("lblctslqnty");


            }
        }
        //protected void grdshipmentdue_RowDataBound(object sender, GridViewRowEventArgs e)
        //{


        //  if (e.Row.RowType == DataControlRowType.DataRow)
        //  {
        //    Label lblExfac = (Label)e.Row.FindControl("lblExfac");
        //    Label lblOrderQty = (Label)e.Row.FindControl("lblOrderQty");
        //    Label lblbiplprice = (Label)e.Row.FindControl("lblbiplprice");
        //    HiddenField hdnexfactdate = (HiddenField)e.Row.FindControl("hdnexfactdate");


        //    //new code Add//

        //    Label lblASOOrderQty = (Label)e.Row.FindControl("lblASOOrderQty");
        //    Label lblERNOrderQty = (Label)e.Row.FindControl("lblERNOrderQty");
        //    Label lblTotalOrderQty = (Label)e.Row.FindControl("lblTotalOrderQty");
        //    Label lblASObiplprice = (Label)e.Row.FindControl("lblASObiplprice");
        //    Label lblERNbiplprice = (Label)e.Row.FindControl("lblERNbiplprice");
        //    Label lblTotalbiplprice = (Label)e.Row.FindControl("lblTotalbiplprice");


        //    //end of code

        //    //Label lblClinetName = (Label)e.Row.FindControl("lblClinetName");
        //    //if (string.Equals(lblClinetName.Text, "Total"))
        //    //{                    
        //    //    lblClinetName.Font.Bold = true;
        //    //    lblClinetName.Style.Add("font-size","11px");                   
        //    //    lblbiplprice.Font.Bold = true;                    
        //    //    lblOrderQty.Font.Bold = true;

        //    //}
        //    //HiddenField hdnclinetid = (HiddenField)e.Row.FindControl("hdnclinetid");

        //    lblExfac.Text = Convert.ToDateTime(lblExfac.Text).ToString("dd MMM (ddd)");


        //    DataSet ds = objadmin.GetShipmetReportPnd("SHIPMENTPLANING", 0, hdnexfactdate.Value);
        //    DataTable dt = ds.Tables[0];
        //    if (dt.Rows.Count > 0)
        //    {

        //      if (dt.Rows[0]["ASOS_OrderQty"].ToString() != "0.0")
        //      {
        //        lblASOOrderQty.Text = dt.Rows[0]["ASOS_OrderQty"].ToString() + " " + "k";

        //        decimal ASOQty = Convert.ToDecimal(dt.Rows[0]["ASOS_OrderQty"]);
        //        grandASOOrderQty = grandASOOrderQty + ASOQty;
        //      }
        //      if (dt.Rows[0]["ERN_OrderQty"].ToString() != "0.0")
        //      {
        //        lblERNOrderQty.Text = dt.Rows[0]["ERN_OrderQty"].ToString() + " " + "k";
        //        decimal ERNQty = Convert.ToDecimal(dt.Rows[0]["ERN_OrderQty"]);
        //        grandERNOrderQty = grandERNOrderQty + ERNQty;
        //      }



        //      if (dt.Rows[0]["Total_OrderQty"].ToString() != "0.0")
        //      {
        //        lblTotalOrderQty.Text = dt.Rows[0]["Total_OrderQty"].ToString() + " " + "k";
        //        decimal TotalOrderQty = Convert.ToDecimal(dt.Rows[0]["Total_OrderQty"]);
        //        grandTotalOrderQty = grandTotalOrderQty + TotalOrderQty;
        //      }


        //      if (dt.Rows[0]["ASOS_OrderValue"].ToString() != "0.0")
        //      {

        //        lblASObiplprice.Text = dt.Rows[0]["ASOS_OrderValue"].ToString() + " " + "lk";
        //        decimal ASObiplpoints = Convert.ToDecimal(dt.Rows[0]["ASOS_OrderValue"]);
        //        grandASOBiplTotal = grandASOBiplTotal + ASObiplpoints;
        //      }


        //      if (dt.Rows[0]["ERN_OrderValue"].ToString() != "0.0")
        //      {

        //        lblERNbiplprice.Text = dt.Rows[0]["ERN_OrderValue"].ToString() + " " + "lk";
        //        decimal ERNbiplpoints = Convert.ToDecimal(dt.Rows[0]["ERN_OrderValue"]);
        //        grandERNBiplTotal = grandERNBiplTotal + ERNbiplpoints;

        //      }


        //      if (dt.Rows[0]["Total_OrderValue"].ToString() != "0.0")
        //      {

        //        lblTotalbiplprice.Text = dt.Rows[0]["Total_OrderValue"].ToString() + " " + "lk";
        //        decimal TOTALbiplpoints = Convert.ToDecimal(dt.Rows[0]["Total_OrderValue"]);
        //        grandTOTALBiplTotal = grandTOTALBiplTotal + TOTALbiplpoints;
        //      }



        //    }
        //    //int points = Convert.ToInt32(orderTotalValue.ToString());

        //    //Label lblbiplQtygrand = (Label)e.Row.FindControl("lblbiplprice");


        //  }
        //  if (e.Row.RowType == DataControlRowType.Footer)
        //  {
        //    Label lblASOgrandOrederQty = (Label)e.Row.FindControl("lblASOgrandOrederQty");
        //    Label lblASOgrandOrederVal = (Label)e.Row.FindControl("lblASOgrandOrederVal");
        //    Label lblERNgrandOrederQty = (Label)e.Row.FindControl("lblERNgrandOrederQty");
        //    Label lblERNgrandOrederVal = (Label)e.Row.FindControl("lblERNgrandOrederVal");
        //    Label lblTotalgrandOrederQty = (Label)e.Row.FindControl("lblTotalgrandOrederQty");
        //    Label lblTotalgrandOrederVal = (Label)e.Row.FindControl("lblTotalgrandOrederVal");
        //    if (Math.Round((grandASOBiplTotal / 100), 1).ToString() != "0")
        //      lblASOgrandOrederVal.Text = "\u20B9 " + Math.Round((grandASOBiplTotal / 100), 1).ToString() + " " + "Cr";
        //    if (grandASOOrderQty.ToString() != "0")
        //      lblASOgrandOrederQty.Text = grandASOOrderQty.ToString() + " " + "k (Pcs)";
        //    if (Math.Round((grandERNBiplTotal / 100), 1).ToString() != "0")
        //      lblERNgrandOrederVal.Text = "\u20B9 " + Math.Round((grandERNBiplTotal / 100), 1).ToString() + " " + "Cr";
        //    if (grandERNOrderQty.ToString() != "0")
        //      lblERNgrandOrederQty.Text = grandERNOrderQty.ToString() + " " + "k (Pcs)";
        //    if (Math.Round((grandTOTALBiplTotal / 100), 1).ToString() != "0")
        //      lblTotalgrandOrederVal.Text = "\u20B9 " + Math.Round((grandTOTALBiplTotal / 100), 1).ToString() + " " + "Cr";
        //    if (grandTotalOrderQty.ToString() != "0")
        //      lblTotalgrandOrederQty.Text = grandTotalOrderQty.ToString() + " " + "k (Pcs)";
        //  }

        //}
        // ******************* Previous code commented **********************
        //protected void grdupcmoming_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        //        GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);            
        //        headerRow1.Attributes.Add("class", "header1");
        //        headerRow2.Attributes.Add("class", "header1");
        //        TableCell HeaderCell = new TableCell();
        //        //Adding the Row at the 0th position (first row) in the Grid
        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Planned For Date";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.RowSpan = 2;           
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "ASO";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "ERN";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        headerRow1.Cells.Add(HeaderCell);



        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Other";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2;
        //        headerRow1.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "BIPL";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 4;
        //        headerRow1.Cells.Add(HeaderCell);


        //        //2 row start
        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Qty";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Val";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Qty";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Val";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Qty";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Val";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Qty";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Val";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        headerRow2.Cells.Add(HeaderCell);

        //        grdupcmoming.Controls[0].Controls.AddAt(0, headerRow2);
        //        grdupcmoming.Controls[0].Controls.AddAt(0, headerRow1);
        //    }

        //  if (e.Row.RowType == DataControlRowType.DataRow)
        //  {
        //    Label lblExfac = (Label)e.Row.FindControl("lblExfac");
        //    Label lblOrderQty = (Label)e.Row.FindControl("lblOrderQty");
        //    Label lblbiplprice = (Label)e.Row.FindControl("lblbiplprice");
        //    HiddenField hdnexfactdate = (HiddenField)e.Row.FindControl("hdnexfactdate");

        //    Label lblASOOrderQty = (Label)e.Row.FindControl("lblASOOrderQty");
        //    Label lblASObiplprice = (Label)e.Row.FindControl("lblASObiplprice");

        //    Label lblERNOrderQty = (Label)e.Row.FindControl("lblERNOrderQty");
        //    Label lblERNbiplprice = (Label)e.Row.FindControl("lblERNbiplprice");

        //    Label lblTotalOrderQty = (Label)e.Row.FindControl("lblTotalOrderQty");    
        //    Label lblTotalbiplprice = (Label)e.Row.FindControl("lblTotalbiplprice");


        //    Label lblOther_ContractQty = (Label)e.Row.FindControl("lblOther_ContractQty");
        //    Label lblOther_ShipedValue = (Label)e.Row.FindControl("lblOther_ShipedValue");

        //    if (Convert.ToDouble(lblASOOrderQty.Text) > 0)
        //    {
        //      lblASOOrderQty.Text = lblASOOrderQty.Text + " " + "k";

        //      decimal ASOQty = Convert.ToDecimal(lblASOOrderQty.Text.Trim().Replace(" k", ""));
        //      grandASOOrderQty = grandASOOrderQty + ASOQty;
        //    }
        //    else
        //    {
        //      lblASOOrderQty.Text = "";
        //    }
        //    if (Convert.ToDouble(lblERNOrderQty.Text) > 0)
        //    {
        //      lblERNOrderQty.Text = lblERNOrderQty.Text + " " + "k";
        //      decimal ERNQty = Convert.ToDecimal(lblERNOrderQty.Text.Trim().Replace(" k", ""));
        //      grandERNOrderQty = grandERNOrderQty + ERNQty;
        //    }
        //    else
        //    {
        //      lblERNOrderQty.Text = "";
        //    }



        //    if (Convert.ToDouble(lblTotalOrderQty.Text) > 0)
        //    {
        //      lblTotalOrderQty.Text = lblTotalOrderQty.Text + " " + "k";
        //      decimal TotalOrderQty = Convert.ToDecimal(lblTotalOrderQty.Text.Trim().Replace(" k", ""));
        //      grandTotalOrderQty = grandTotalOrderQty + TotalOrderQty;
        //    }
        //    else
        //    {
        //      lblTotalOrderQty.Text = "";

        //    }


        //    if (Convert.ToDouble(lblASObiplprice.Text) > 0)
        //    {
        //      lblASObiplprice.Text = lblASObiplprice.Text + " " + "lk";
        //      decimal ASObiplpoints = Convert.ToDecimal(lblASObiplprice.Text.Trim().Replace(" lk", ""));
        //      grandASOBiplTotal = grandASOBiplTotal + ASObiplpoints;
        //    }
        //    else
        //    {
        //      lblASObiplprice.Text = "";
        //    }


        //    if (Convert.ToDouble(lblERNbiplprice.Text) > 0)
        //    {

        //      lblERNbiplprice.Text = lblERNbiplprice.Text + " " + "lk";
        //      decimal ERNbiplpoints = Convert.ToDecimal(lblERNbiplprice.Text.Trim().Replace(" lk", ""));
        //      grandERNBiplTotal = grandERNBiplTotal + ERNbiplpoints;

        //    }
        //    else
        //    {
        //      lblERNbiplprice.Text = "";
        //    }


        //    if (Convert.ToDouble(lblTotalbiplprice.Text) > 0)
        //    {

        //      lblTotalbiplprice.Text = lblTotalbiplprice.Text + " " + "lk";
        //      decimal TOTALbiplpoints = Convert.ToDecimal(lblTotalbiplprice.Text.Trim().Replace(" lk", ""));
        //      grandTOTALBiplTotal = grandTOTALBiplTotal + TOTALbiplpoints;
        //    }
        //    else
        //    {
        //      lblTotalbiplprice.Text = "";

        //    }


        //    if (Convert.ToDouble(lblOther_ContractQty.Text) > 0)
        //    {
        //       lblOther_ContractQty.Text = lblOther_ContractQty.Text + " " + "k";
        //      decimal OtherQty = Convert.ToDecimal(lblOther_ContractQty.Text.Trim().Replace(" k", ""));
        //      grandOtherOrderQty = grandOtherOrderQty + OtherQty;
        //    }
        //    else
        //    {
        //      lblOther_ContractQty.Text = "";
        //    }
        //    if (Convert.ToDouble(lblOther_ShipedValue.Text) > 0)
        //    {
        //      lblOther_ShipedValue.Text = lblOther_ShipedValue.Text + " " + "lk";
        //      decimal Otherbiplpoints = Convert.ToDecimal(lblOther_ShipedValue.Text.Trim().Replace(" lk", ""));
        //      grandOtherOrderVal = grandOtherOrderVal + Otherbiplpoints;
        //    }
        //    else
        //    {
        //      lblOther_ShipedValue.Text = "";
        //    }

        //  }
        //  if (e.Row.RowType == DataControlRowType.Footer)
        //  {
        //    Label lblASOgrandOrederQty = (Label)e.Row.FindControl("lblASOgrandOrederQty");
        //    Label lblASOgrandOrederVal = (Label)e.Row.FindControl("lblASOgrandOrederVal");
        //    Label lblERNgrandOrederQty = (Label)e.Row.FindControl("lblERNgrandOrederQty");
        //    Label lblERNgrandOrederVal = (Label)e.Row.FindControl("lblERNgrandOrederVal");
        //    Label lblTotalgrandOrederQty = (Label)e.Row.FindControl("lblTotalgrandOrederQty");
        //    Label lblTotalgrandOrederVal = (Label)e.Row.FindControl("lblTotalgrandOrederVal");

        //    Label lblOthergrandOrederQty = (Label)e.Row.FindControl("lblOthergrandOrederQty");
        //    Label lblOthergrandOrederVal = (Label)e.Row.FindControl("lblOthergrandOrederVal");

        //    if (Math.Round((grandASOBiplTotal / 100), 1).ToString() != "0")
        //      lblASOgrandOrederVal.Text = "\u20B9 " + Math.Round((grandASOBiplTotal / 100), 1).ToString() + " " + "Cr";
        //    if (grandASOOrderQty.ToString() != "0")
        //      lblASOgrandOrederQty.Text = grandASOOrderQty.ToString() + " " + "k (Pcs)";

        //    if (Math.Round((grandERNBiplTotal / 100), 1).ToString() != "0")
        //      lblERNgrandOrederVal.Text = "\u20B9 " + Math.Round((grandERNBiplTotal / 100), 1).ToString() + " " + "Cr";

        //    if (grandERNOrderQty.ToString() != "0")
        //      lblERNgrandOrederQty.Text = grandERNOrderQty.ToString() + " " + "k (Pcs)";
        //    if (Math.Round((grandTOTALBiplTotal / 100), 1).ToString() != "0")
        //      lblTotalgrandOrederVal.Text = "\u20B9 " + Math.Round((grandTOTALBiplTotal / 100), 1).ToString() + " " + "Cr";
        //    if (grandTotalOrderQty.ToString() != "0")
        //      lblTotalgrandOrederQty.Text = grandTotalOrderQty.ToString() + " " + "k (Pcs)";

        //    if (Math.Round((grandOtherOrderVal / 100), 1).ToString() != "0")
        //      lblOthergrandOrederVal.Text = "\u20B9 " + Math.Round((grandOtherOrderVal / 100), 1).ToString() + " " + "Cr";
        //    if (grandOtherOrderQty.ToString() != "0")
        //      lblOthergrandOrederQty.Text = grandOtherOrderQty.ToString() + " " + "k (Pcs)";

        //  }

        //}
        // *************************8 End of Comment **************************
        protected void grdupcmoming_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.Attributes.Add("class", "header1");
                headerRow2.Attributes.Add("class", "header1");
                headerRow3.Attributes.Add("class", "header1");

                TableCell HeaderCell = new TableCell();
                //Adding the Row at the 0th position (first row) in the Grid
                HeaderCell = new TableCell();
                HeaderCell.Text = "Exfactory Weeks";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 3;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "IKANDI";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                HeaderCell.RowSpan = 1;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "ERN";
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow1.Cells.Add(HeaderCell);



                HeaderCell = new TableCell();
                HeaderCell.Text = "Other";
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow1.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "BIPL";
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow1.Cells.Add(HeaderCell);


                //2 row start
                HeaderCell = new TableCell();
                HeaderCell.Text = "Sea";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Air";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Qty";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Qty";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Qty";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 2;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow2.Cells.Add(HeaderCell);

                //3 row start
                HeaderCell = new TableCell();
                HeaderCell.Text = "Qty";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Qty";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.RowSpan = 1;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                headerRow3.Cells.Add(HeaderCell);

                grdupcmoming.Controls[0].Controls.AddAt(0, headerRow3);
                grdupcmoming.Controls[0].Controls.AddAt(0, headerRow2);
                grdupcmoming.Controls[0].Controls.AddAt(0, headerRow1);
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblExfac = (Label)e.Row.FindControl("lblExfac");
                Label lblOrderQty = (Label)e.Row.FindControl("lblOrderQty");
                Label lblbiplprice = (Label)e.Row.FindControl("lblbiplprice");
                HiddenField hdnexfactdate = (HiddenField)e.Row.FindControl("hdnexfactdate");

                Label lblASOOrderQty = (Label)e.Row.FindControl("lblASOOrderQty");
                Label lblASObiplprice = (Label)e.Row.FindControl("lblASObiplprice");

                Label lblASOOrderQtyAir = (Label)e.Row.FindControl("lblASOOrderQtyAir");
                Label lblASObiplpriceAir = (Label)e.Row.FindControl("lblASObiplpriceAir");

                Label lblERNOrderQty = (Label)e.Row.FindControl("lblERNOrderQty");
                Label lblERNbiplprice = (Label)e.Row.FindControl("lblERNbiplprice");

                Label lblTotalOrderQty = (Label)e.Row.FindControl("lblTotalOrderQty");
                Label lblTotalbiplprice = (Label)e.Row.FindControl("lblTotalbiplprice");


                Label lblOther_ContractQty = (Label)e.Row.FindControl("lblOther_ContractQty");
                Label lblOther_ShipedValue = (Label)e.Row.FindControl("lblOther_ShipedValue");
                lblExfac.Text.Replace("to", "<span style='Color:gray'>to</span>");
                if (Convert.ToDouble(lblASOOrderQty.Text) > 0)
                {
                    lblASOOrderQty.Text = Convert.ToInt32(lblASOOrderQty.Text).ToString("N0") + " " + "k";

                    decimal ASOQty = Convert.ToDecimal(lblASOOrderQty.Text.Trim().Replace(" k", ""));
                    grandASOOrderQty = grandASOOrderQty + ASOQty;
                }
                else
                {
                    lblASOOrderQty.Text = "";
                }

                if (Convert.ToDouble(lblASOOrderQtyAir.Text) > 0)
                {
                    lblASOOrderQtyAir.Text = Convert.ToInt32(lblASOOrderQtyAir.Text).ToString("N0") + " " + "k";

                    decimal ASOQty = Convert.ToDecimal(lblASOOrderQtyAir.Text.Trim().Replace(" k", ""));
                    grandASOOrderQtyAir = grandASOOrderQtyAir + ASOQty;
                }
                else
                {
                    lblASOOrderQtyAir.Text = "";
                }

                if (Convert.ToDouble(lblERNOrderQty.Text) > 0)
                {
                    lblERNOrderQty.Text = Convert.ToInt32(lblERNOrderQty.Text).ToString("N0") + " " + "k";
                    decimal ERNQty = Convert.ToDecimal(lblERNOrderQty.Text.Trim().Replace(" k", ""));
                    grandERNOrderQty = grandERNOrderQty + ERNQty;
                }
                else
                {
                    lblERNOrderQty.Text = "";
                }



                if (Convert.ToDouble(lblTotalOrderQty.Text) > 0)
                {
                    lblTotalOrderQty.Text = Convert.ToInt32(lblTotalOrderQty.Text).ToString("N0") + " " + "k";
                    decimal TotalOrderQty = Convert.ToDecimal(lblTotalOrderQty.Text.Trim().Replace(" k", ""));
                    grandTotalOrderQty = grandTotalOrderQty + TotalOrderQty;
                }
                else
                {
                    lblTotalOrderQty.Text = "";

                }


                if (Convert.ToDouble(lblASObiplprice.Text) > 0)
                {
                    lblASObiplprice.Text = lblASObiplprice.Text + " " + "Cr";
                    //decimal ASObiplpoints = Convert.ToDecimal(lblASObiplprice.Text.Trim().Replace(" Cr", ""));
                    //grandASOBiplTotal = grandASOBiplTotal + ASObiplpoints;
                }
                else
                {
                    lblASObiplprice.Text = "";
                }

                if (Convert.ToDouble(lblASObiplpriceAir.Text) > 0)
                {
                    lblASObiplpriceAir.Text = lblASObiplpriceAir.Text + " " + "Cr";
                    //decimal ASObiplpointsAir = Convert.ToDecimal(lblASObiplpriceAir.Text.Trim().Replace(" Cr", ""));
                    //grandASOBiplTotalAir = grandASOBiplTotalAir + ASObiplpointsAir;
                }
                else
                {
                    lblASObiplpriceAir.Text = "";
                }


                if (Convert.ToDouble(lblERNbiplprice.Text) > 0)
                {

                    lblERNbiplprice.Text = lblERNbiplprice.Text + " " + "Cr";
                    //decimal ERNbiplpoints = Convert.ToDecimal(lblERNbiplprice.Text.Trim().Replace(" Cr", ""));
                    //grandERNBiplTotal = grandERNBiplTotal + ERNbiplpoints;

                }
                else
                {
                    lblERNbiplprice.Text = "";
                }


                if (Convert.ToDouble(lblTotalbiplprice.Text) > 0)
                {

                    lblTotalbiplprice.Text = lblTotalbiplprice.Text + " " + "Cr";
                    //decimal TOTALbiplpoints = Convert.ToDecimal(lblTotalbiplprice.Text.Trim().Replace(" Cr", ""));
                    //grandTOTALBiplTotal = grandTOTALBiplTotal + TOTALbiplpoints;
                }
                else
                {
                    lblTotalbiplprice.Text = "";

                }


                if (Convert.ToDouble(lblOther_ContractQty.Text) > 0)
                {
                    lblOther_ContractQty.Text = Convert.ToInt32(lblOther_ContractQty.Text).ToString("N0") + " " + "k";
                    decimal OtherQty = Convert.ToDecimal(lblOther_ContractQty.Text.Trim().Replace(" k", ""));
                    grandOtherOrderQty = grandOtherOrderQty + OtherQty;
                }
                else
                {
                    lblOther_ContractQty.Text = "";
                }
                if (Convert.ToDouble(lblOther_ShipedValue.Text) > 0)
                {
                    lblOther_ShipedValue.Text = lblOther_ShipedValue.Text + " " + "Cr";
                    //decimal Otherbiplpoints = Convert.ToDecimal(lblOther_ShipedValue.Text.Trim().Replace(" Cr", ""));
                    //grandOtherOrderVal = grandOtherOrderVal + Otherbiplpoints;
                }
                else
                {
                    lblOther_ShipedValue.Text = "";
                }

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DataTable VS_dtshipValueTotal = (DataTable)ViewState["VS_dtshipValueTotal"];

                Label lblASOgrandOrederQty = (Label)e.Row.FindControl("lblASOgrandOrederQty");
                Label lblASOgrandOrederVal = (Label)e.Row.FindControl("lblASOgrandOrederVal");
                Label lblASOgrandOrederQtyAir = (Label)e.Row.FindControl("lblASOgrandOrederQtyAir");
                Label lblASOgrandOrederValAir = (Label)e.Row.FindControl("lblASOgrandOrederValAir");
                Label lblERNgrandOrederQty = (Label)e.Row.FindControl("lblERNgrandOrederQty");
                Label lblERNgrandOrederVal = (Label)e.Row.FindControl("lblERNgrandOrederVal");
                Label lblTotalgrandOrederQty = (Label)e.Row.FindControl("lblTotalgrandOrederQty");
                Label lblTotalgrandOrederVal = (Label)e.Row.FindControl("lblTotalgrandOrederVal");

                Label lblOthergrandOrederQty = (Label)e.Row.FindControl("lblOthergrandOrederQty");
                Label lblOthergrandOrederVal = (Label)e.Row.FindControl("lblOthergrandOrederVal");

                grandASOBiplTotal = Convert.ToDecimal(VS_dtshipValueTotal.Rows[0]["Assos_ShipedValue_Sea"].ToString());
                grandASOBiplTotalAir = Convert.ToDecimal(VS_dtshipValueTotal.Rows[0]["Assos_ShipedValue_Air"].ToString());
                grandERNBiplTotal = Convert.ToDecimal(VS_dtshipValueTotal.Rows[0]["ERN_ShipedValue"].ToString());
                grandTOTALBiplTotal = Convert.ToDecimal(VS_dtshipValueTotal.Rows[0]["BIPL_ShipedValue"].ToString());
                grandOtherOrderVal = Convert.ToDecimal(VS_dtshipValueTotal.Rows[0]["Other_ShipedValue"].ToString());


                if (Math.Round((grandASOBiplTotal), 0).ToString() != "0")
                    lblASOgrandOrederVal.Text = "\u20B9 " + Math.Round((grandASOBiplTotal), 0).ToString() + " " + "Cr";
                if (Math.Round((grandASOBiplTotalAir), 0).ToString() != "0")
                    lblASOgrandOrederValAir.Text = "\u20B9 " + Math.Round((grandASOBiplTotalAir), 0).ToString() + " " + "Cr";
                if (grandASOOrderQty.ToString() != "0")
                    lblASOgrandOrederQty.Text = grandASOOrderQty.ToString("N0") + " " + "k Pcs";

                if (grandASOOrderQtyAir.ToString() != "0")
                    lblASOgrandOrederQtyAir.Text = grandASOOrderQtyAir.ToString("N0") + " " + "k Pcs";


                if (Math.Round((grandERNBiplTotal), 0).ToString() != "0")
                    lblERNgrandOrederVal.Text = "\u20B9 " + Math.Round((grandERNBiplTotal), 0).ToString() + " " + "Cr";

                if (grandERNOrderQty.ToString() != "0")
                    lblERNgrandOrederQty.Text = grandERNOrderQty.ToString("N0") + " " + "k Pcs";

                if (Math.Round((grandTOTALBiplTotal), 0).ToString() != "0")
                    lblTotalgrandOrederVal.Text = "\u20B9 " + Math.Round((grandTOTALBiplTotal), 0).ToString() + " " + "Cr";
                if (grandTotalOrderQty.ToString() != "0")
                    lblTotalgrandOrederQty.Text = grandTotalOrderQty.ToString("N0") + " " + "k Pcs";


                if (Math.Round((grandOtherOrderVal), 0).ToString() != "0")
                    lblOthergrandOrederVal.Text = "\u20B9 " + Math.Round((grandOtherOrderVal), 0).ToString() + " " + "Cr";
                if (grandOtherOrderQty.ToString() != "0")
                    lblOthergrandOrederQty.Text = grandOtherOrderQty.ToString("N0") + " " + "k Pcs";

            }

        }

        public bool CheckZero(string txt)
        {
            bool iss = true;
         

            if (txt != "")
            {
                decimal s = Convert.ToDecimal(txt);
                if (s <= 0)
                {
                    iss = false;
                }
            }
            else
            {
                iss = false;
            }
            return iss;
        }

        //protected void grdOuthouseSummary_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //  if (e.Row.RowType == DataControlRowType.DataRow)
        //  {
        //    Label lblTotal_Machines = (Label)e.Row.FindControl("lblTotal_Machines");
        //    Label lblAvrage_Machine = (Label)e.Row.FindControl("lblAvrage_Machine");
        //    Label lblAvrage_Psc_PerDayOutPut = (Label)e.Row.FindControl("lblAvrage_Psc_PerDayOutPut");

        //    Label lblinitialmultiplier = (Label)e.Row.FindControl("lblinitialmultiplier");
        //    Label lblProductionmultiplier = (Label)e.Row.FindControl("lblProductionmultiplier");
        //    Label lblAvgDelayInDays = (Label)e.Row.FindControl("lblAvgDelayInDays");


        //    if (lblTotal_Machines.Text.Trim() == "0")
        //    {
        //      lblTotal_Machines.Text = "";
        //    }
        //    if (lblAvrage_Machine.Text.Trim() == "0")
        //    {
        //      lblAvrage_Machine.Text = "";
        //    }
        //    if (lblAvrage_Psc_PerDayOutPut.Text.Trim() == "0")
        //    {
        //      lblAvrage_Psc_PerDayOutPut.Text = "";
        //    }
        //    if (lblinitialmultiplier.Text.Trim() == "0")
        //    {
        //      lblinitialmultiplier.Text = "";
        //    }
        //    if (lblProductionmultiplier.Text.Trim() == "0")
        //    {
        //      lblProductionmultiplier.Text = "";
        //    }
        //    if (lblAvgDelayInDays.Text.Trim() == "0")
        //    {
        //      lblAvgDelayInDays.Text = "";
        //    }
        //  }
        //}
        //Added by abhishek 10/9/2018
        public void BindStylecode()
        {
            AdminController objadmin = new AdminController();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objadmin.BindStylecodePlan();
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                grdStyleCodePlaning.DataSource = dt;
                grdStyleCodePlaning.DataBind();
            }

            GridViewRow row = grdStyleCodePlaning.Rows[grdStyleCodePlaning.Rows.Count - 1];
            row.Cells[0].ForeColor = System.Drawing.ColorTranslator.FromHtml("#999999");
        }
        protected void grdStyleCodePlaning_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string CurrentMonth = String.Format("{0:MMMM}", DateTime.Now);
            string NextMonth = String.Format("{0:MMMM}", DateTime.Now.AddMonths(1));
            string NextToNextMonth = String.Format("{0:MMMM}", DateTime.Now.AddMonths(2));
            // Added by Yadvendra on 12/12/2019
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblqtyFromRange = (Label)e.Row.FindControl("lblqtyFromRange");
                Label Quantity = (Label)e.Row.FindControl("lblQuantity");
                Label CurrentMonth_TotalQtyPlanned = (Label)e.Row.FindControl("lblCurrentMonth_TotalQtyPlanned");
                Label CurrentMonth_TotalQtyUnPlanned = (Label)e.Row.FindControl("lblCurrentMonth_TotalQtyUnPlanned");
                Label NextMonth_TotalQtyPlanned = (Label)e.Row.FindControl("lblNextMonth_TotalQtyPlanned");
                Label NextMonth_TotalQtyUnPlanned = (Label)e.Row.FindControl("lblNextMonth_TotalQtyUnPlanned");
                Label NextToNextMonth_TotalQtyPlanned = (Label)e.Row.FindControl("lblNextToNextMonth_TotalQtyPlanned");
                Label NextToNextMonth_TotalQtyUnPlanned = (Label)e.Row.FindControl("lblNextToNextMonth_TotalQtyUnPlanned");

                if (lblqtyFromRange.Text != "<b>Grand Total</b>")
                {
                    Quantity.Text = Quantity.Text == string.Empty ? string.Empty : Convert.ToDecimal(Quantity.Text.Trim().Replace(" k", "")).ToString("N0") + " k";
                    //CurrentMonth_TotalQtyPlanned.Text = CurrentMonth_TotalQtyPlanned.Text == string.Empty ? string.Empty : Convert.ToDecimal(CurrentMonth_TotalQtyPlanned.Text.Trim().Replace(" k", "")).ToString("N0") + " k";
                    CurrentMonth_TotalQtyPlanned.Text = CurrentMonth_TotalQtyPlanned.Text == string.Empty ? string.Empty : ((Convert.ToDecimal(CurrentMonth_TotalQtyPlanned.Text.Trim().Replace(" k", "")) < 1000 && CurrentMonth_TotalQtyPlanned.Text.Contains('k') == false) ? (Convert.ToDecimal(CurrentMonth_TotalQtyPlanned.Text.Trim().Replace(" k", "")).ToString("N0")) : (Convert.ToDecimal(CurrentMonth_TotalQtyPlanned.Text.Trim().Replace(" k", "")).ToString("N0") + " k"));
                    //CurrentMonth_TotalQtyUnPlanned.Text = CurrentMonth_TotalQtyUnPlanned.Text == string.Empty ? string.Empty : Convert.ToDecimal(CurrentMonth_TotalQtyUnPlanned.Text.Trim().Replace(" k", "")).ToString("N0") + " k";
                    CurrentMonth_TotalQtyUnPlanned.Text = CurrentMonth_TotalQtyUnPlanned.Text == string.Empty ? string.Empty : ((Convert.ToDecimal(CurrentMonth_TotalQtyUnPlanned.Text.Trim().Replace(" k", "")) < 1000 && CurrentMonth_TotalQtyUnPlanned.Text.Contains('k') == false) ? (Convert.ToDecimal(CurrentMonth_TotalQtyUnPlanned.Text.Trim().Replace(" k", "")).ToString("N0")) : (Convert.ToDecimal(CurrentMonth_TotalQtyUnPlanned.Text.Trim().Replace(" k", "")).ToString("N0") + " k"));
                    //NextMonth_TotalQtyPlanned.Text = NextMonth_TotalQtyPlanned.Text == string.Empty ? string.Empty : Convert.ToDecimal(NextMonth_TotalQtyPlanned.Text.Trim().Replace(" k", "")).ToString("N0") + " k";
                    NextMonth_TotalQtyPlanned.Text = NextMonth_TotalQtyPlanned.Text == string.Empty ? string.Empty : ((Convert.ToDecimal(NextMonth_TotalQtyPlanned.Text.Trim().Replace(" k", "")) < 1000 && NextMonth_TotalQtyPlanned.Text.Contains('k')==false) ? (Convert.ToDecimal(NextMonth_TotalQtyPlanned.Text.Trim().Replace(" k", "")).ToString("N0")) : (Convert.ToDecimal(NextMonth_TotalQtyPlanned.Text.Trim().Replace(" k", "")).ToString("N0") + " k"));
                    //NextMonth_TotalQtyUnPlanned.Text = NextMonth_TotalQtyUnPlanned.Text == string.Empty ? string.Empty : Convert.ToDecimal(NextMonth_TotalQtyUnPlanned.Text.Trim().Replace(" k", "")).ToString("N0") + " k";
                    NextMonth_TotalQtyUnPlanned.Text = NextMonth_TotalQtyUnPlanned.Text == string.Empty ? string.Empty : ((Convert.ToDecimal(NextMonth_TotalQtyUnPlanned.Text.Trim().Replace(" k", "")) < 1000 && NextMonth_TotalQtyUnPlanned.Text.Contains('k') == false) ? (Convert.ToDecimal(NextMonth_TotalQtyUnPlanned.Text.Trim().Replace(" k", "")).ToString("N0")) : (Convert.ToDecimal(NextMonth_TotalQtyUnPlanned.Text.Trim().Replace(" k", "")).ToString("N0") + " k"));
                    //NextToNextMonth_TotalQtyPlanned.Text = NextToNextMonth_TotalQtyPlanned.Text == string.Empty ? string.Empty : Convert.ToDecimal(NextToNextMonth_TotalQtyPlanned.Text.Trim().Replace(" k", "")).ToString("N0") + " k";
                    NextToNextMonth_TotalQtyPlanned.Text = NextToNextMonth_TotalQtyPlanned.Text == string.Empty ? string.Empty : ((Convert.ToDecimal(NextToNextMonth_TotalQtyPlanned.Text.Trim().Replace(" k", "")) < 1000 && NextToNextMonth_TotalQtyPlanned.Text.Contains('k') == false) ? (Convert.ToDecimal(NextToNextMonth_TotalQtyPlanned.Text.Trim().Replace(" k", "")).ToString("N0")) : (Convert.ToDecimal(NextToNextMonth_TotalQtyPlanned.Text.Trim().Replace(" k", "")).ToString("N0") + " k"));
                    //NextToNextMonth_TotalQtyUnPlanned.Text = NextToNextMonth_TotalQtyUnPlanned.Text == string.Empty ? string.Empty : Convert.ToDecimal(NextToNextMonth_TotalQtyUnPlanned.Text.Trim().Replace(" k", "")).ToString("N0") + " k";
                    NextToNextMonth_TotalQtyUnPlanned.Text = NextToNextMonth_TotalQtyUnPlanned.Text == string.Empty ? string.Empty : ((Convert.ToDecimal(NextToNextMonth_TotalQtyUnPlanned.Text.Trim().Replace(" k", "")) < 1000 && NextToNextMonth_TotalQtyUnPlanned.Text.Contains('k') == false) ? (Convert.ToDecimal(NextToNextMonth_TotalQtyUnPlanned.Text.Trim().Replace(" k", "")).ToString("N0")) : (Convert.ToDecimal(NextToNextMonth_TotalQtyUnPlanned.Text.Trim().Replace(" k", "")).ToString("N0") + " k"));
                }
                else
                {
                    Quantity.Text = Quantity.Text == string.Empty ? string.Empty : "<b>" + Convert.ToDecimal(Quantity.Text.Trim().Replace(" k", "").Replace("<b>", "").Replace("</b>", "")).ToString("N0") + " k" + "</b>";
                    CurrentMonth_TotalQtyPlanned.Text = CurrentMonth_TotalQtyPlanned.Text == string.Empty ? string.Empty : "<b>" + Convert.ToDecimal(CurrentMonth_TotalQtyPlanned.Text.Trim().Replace(" k", "").Replace("<b>", "").Replace("</b>", "")).ToString("N0") + " k" + "</b>";
                    CurrentMonth_TotalQtyUnPlanned.Text = CurrentMonth_TotalQtyUnPlanned.Text == string.Empty ? string.Empty : "<b>" + Convert.ToDecimal(CurrentMonth_TotalQtyUnPlanned.Text.Trim().Replace(" k", "").Replace("<b>", "").Replace("</b>", "")).ToString("N0") + " k" + "</b>";
                    NextMonth_TotalQtyPlanned.Text = NextMonth_TotalQtyPlanned.Text == string.Empty ? string.Empty : "<b>" + Convert.ToDecimal(NextMonth_TotalQtyPlanned.Text.Trim().Replace(" k", "").Replace("<b>", "").Replace("</b>", "")).ToString("N0") + " k" + "</b>";
                    NextMonth_TotalQtyUnPlanned.Text = NextMonth_TotalQtyUnPlanned.Text == string.Empty ? string.Empty : "<b>" + Convert.ToDecimal(NextMonth_TotalQtyUnPlanned.Text.Trim().Replace(" k", "").Replace("<b>", "").Replace("</b>", "")).ToString("N0") + " k" + "</b>";
                    NextToNextMonth_TotalQtyPlanned.Text = NextToNextMonth_TotalQtyPlanned.Text == string.Empty ? string.Empty : "<b>" + Convert.ToDecimal(NextToNextMonth_TotalQtyPlanned.Text.Trim().Replace(" k", "").Replace("<b>", "").Replace("</b>", "")).ToString("N0") + " k" + "</b>";
                    NextToNextMonth_TotalQtyUnPlanned.Text = NextToNextMonth_TotalQtyUnPlanned.Text == string.Empty ? string.Empty : "<b>" + Convert.ToDecimal(NextToNextMonth_TotalQtyUnPlanned.Text.Trim().Replace(" k", "").Replace("<b>", "").Replace("</b>", "")).ToString("N0") + " k" + "</b>";

                }
            }
            // End Added by Yadvendra on 12/12/2019

            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.Attributes.Add("class", "header1");
                headerRow2.Attributes.Add("class", "header1");
                headerRow3.Attributes.Add("class", "header1");
                TableCell HeaderCell = new TableCell();
                //Adding the Row at the 0th position (first row) in the Grid
                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity Range";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 3;
                HeaderCell.Width = 100;
                HeaderCell.Height = 50;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Total";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                HeaderCell.RowSpan = 2;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = CurrentMonth + " & Before";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow1.Cells.Add(HeaderCell);



                HeaderCell = new TableCell();
                HeaderCell.Text = NextMonth;
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow1.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = NextToNextMonth + " Onwards";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow1.Cells.Add(HeaderCell);


                //2 row start
                HeaderCell = new TableCell();
                HeaderCell.Text = "Planned";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Unplanned";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Planned";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Unplanned";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Planned";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Unplanned";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow2.Cells.Add(HeaderCell);


                //Adding the Row at the 3rd position (second row) in the Grid
                HeaderCell = new TableCell();
                HeaderCell.Text = "SCode Count";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);



                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SC Count";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SC Count";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SC Count";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SC Count";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SC Count";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SC Count";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);


                grdStyleCodePlaning.Controls[0].Controls.AddAt(0, headerRow3);
                grdStyleCodePlaning.Controls[0].Controls.AddAt(0, headerRow2);
                grdStyleCodePlaning.Controls[0].Controls.AddAt(0, headerRow1);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


            }
        }


    }
}