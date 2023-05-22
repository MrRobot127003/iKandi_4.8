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
using System.Collections.Generic;
using System.Text;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.UserControls.Reports

{
    public partial class Master_Monthly_Performance_Report : System.Web.UI.UserControl
    {
        AdminController objadmin = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindTableTailorSamPer();
            BindTailorPerForRep();
            BindMasterMo_performanceReport();
        }

        //Tailor Wip table
        protected void BindTableTailorSamPer()
        {
            DataSet dsQcMasterReport = new DataSet();
            dsQcMasterReport = objadmin.GetMasterTaitorReport();
            DataTable dtQcTailorSamReport = dsQcMasterReport.Tables[0];
            string SamDays = dtQcTailorSamReport.Rows[0]["SamplingWIPDays"].ToString();
            string FitsDays = dtQcTailorSamReport.Rows[0]["FitsWIPDays"].ToString();
            string TotalDays = dtQcTailorSamReport.Rows[0]["TotalWIPDays"].ToString();
            
            StringBuilder Wipsb = new StringBuilder();

            Wipsb.Append("<table cellspacing='0' cellpadding='0' border='0' class='InternalAdminTable' style='float:left;margin-left:10px;'>");
            Wipsb.Append("<tr>");
            Wipsb.Append("<th colspan='3'>Tailor WIP</th>");
            Wipsb.Append("</tr>");
            Wipsb.Append("<tr>");
            Wipsb.Append("<th style='width:80px'>Sampling</th>");
            Wipsb.Append("<th style='width:80px'>Fits</th>");
            Wipsb.Append("<th style='width:80px'>Total</th>");
            Wipsb.Append("</tr>");
            Wipsb.Append("<tr>");
            //add code by bharat on 23-10-19
                string SamDay = "";
                if (SamDays != "1")
                {
                    SamDay = " Days";
                }
                else {
                    SamDay = " Day";
                }
            //end
                if (Convert.ToInt32(SamDays) < 3)
                {
                    Wipsb.Append("<td class='fontweightblod textLeft'><span>" + dtQcTailorSamReport.Rows[0]["SamplingWIP"].ToString() + "</span> <span class='textcolorGray txtright'>" + dtQcTailorSamReport.Rows[0]["SamplingWIPDays"].ToString() + SamDay + " </span></td>");
                }
                else
                {
                    Wipsb.Append("<td class='fontweightblod textLeft'><span>" + dtQcTailorSamReport.Rows[0]["SamplingWIP"].ToString() + "</span> <span class='colorRed txtright'>" + dtQcTailorSamReport.Rows[0]["SamplingWIPDays"].ToString() + SamDay + "</span></td>");
                }
                //add code by bharat on 23-10-19
                string FitsDay = "";
                if (FitsDays != "1")
                {
                    FitsDay = " Days";
                }
                else
                {
                    FitsDay = " Day";
                }
                //end
            if (Convert.ToInt32(FitsDays) < 3)
            {
                Wipsb.Append("<td class='fontweightblod textLeft'><span>" + dtQcTailorSamReport.Rows[0]["FitsWIP"].ToString() + "</span> <span class='textcolorGray txtright'> " + dtQcTailorSamReport.Rows[0]["FitsWIPDays"].ToString() + FitsDay + "</span></td>");
            }
            else {
                Wipsb.Append("<td class='fontweightblod textLeft'><span>" + dtQcTailorSamReport.Rows[0]["FitsWIP"].ToString() + "</span> <span class='colorRed txtright'> " + dtQcTailorSamReport.Rows[0]["FitsWIPDays"].ToString() + FitsDay + "</span></td>");
            }
            //add code by bharat on 23-10-19
            string TotalDay = "";
            if (TotalDays != "1")
            {
                TotalDay = " Days";
            }
            else
            {
                TotalDay = " Day";
            }
            //end
            if (Convert.ToInt32(TotalDays) < 3)
            {
                Wipsb.Append("<td class='fontweightblod textLeft'><span>" + dtQcTailorSamReport.Rows[0]["TotalWIP"].ToString() + "</span> <span class='textcolorGray txtright'> " + dtQcTailorSamReport.Rows[0]["TotalWIPDays"].ToString() + TotalDay + "</span></td>");
            }
            else {
                Wipsb.Append("<td class='fontweightblod textLeft'><span>" + dtQcTailorSamReport.Rows[0]["TotalWIP"].ToString() + "</span> <span class='colorRed txtright'> " + dtQcTailorSamReport.Rows[0]["TotalWIPDays"].ToString() + TotalDay + "</span></td>");
            }
            Wipsb.Append("</tr>");
            Wipsb.Append("</table>");

            TailorWip_Report.InnerHtml = Wipsb.ToString();
        }

        //Tailor  table
        protected void BindTailorPerForRep() {

            DataSet dsQcMasterReport = new DataSet();
            dsQcMasterReport = objadmin.GetMasterTaitorReport();
            DataTable dtQcTailorReport = dsQcMasterReport.Tables[2];
            DataTable dtCurrentQuarter = dsQcMasterReport.Tables[3];
            int Rows = dtQcTailorReport.Rows.Count;
           // string SamDays = dtQcTailorReport.Rows[0]["SamplingWIPDays"].ToString();

            StringBuilder Tasb = new StringBuilder();
            Tasb.Append("<table cellspacing='0' cellpadding='0' border='0' class='InternalAdminTable' style='float:left;'>");
            Tasb.Append("<tr>");
            Tasb.Append("<th colspan='5'>Tailor Quarterly Performance (<span style='color:#d2cdcd'>Sample Made</span>)</th>");
            Tasb.Append("</tr>");
            Tasb.Append("<tr>");
            Tasb.Append("<th rowspan='2' style='width:100px'>Tailor Details</th>");
            Tasb.Append("<th colspan='2'> Q" + dtCurrentQuarter.Rows[0]["CurrentQtrNo"].ToString() + " (<span style='color:#d2cdcd;font-size:10px'>Sample Made</span>)</th>");
            Tasb.Append("<th colspan='2'>Previous Qtr. (<span style='color:#d2cdcd;font-size:10px'>Sample Made</span>)</th>");
            Tasb.Append("</tr>");
            Tasb.Append("<tr>");
            Tasb.Append("<th style='width:60px'>Daily Avg.</th>");
            Tasb.Append("<th style='width:60px'>Total</th>");
            //Tasb.Append("<th>Remake</th>");
            Tasb.Append("<th style='width:60px'>Daily Avg.</th>");
            Tasb.Append("<th style='width:60px'>Total</th>");
            //Tasb.Append("<th>Remake</th>");
            Tasb.Append("</tr>");
            for (int i = 0; i < Rows; i++)
            {
                
                Tasb.Append("<tr>");
                Tasb.Append("<td class='textcolorName'>" + dtQcTailorReport.Rows[i]["DescriptionName"].ToString() + "</td>");

                if (Convert.ToUInt32(dtQcTailorReport.Rows[i]["CurQtrAvgTailor"]) != 0)
                {
                    Tasb.Append("<td>" + dtQcTailorReport.Rows[i]["CurQtrAvgTailor"].ToString() + "</td>");
                }
                else {
                    Tasb.Append("<td></td>");
                }
                if (Convert.ToUInt32(dtQcTailorReport.Rows[i]["CurQtrTotalTailor"]) != 0)
                {
                    //Added by Yadvendra on 12/12/19
                    Tasb.Append("<td>" + Convert.ToInt32(dtQcTailorReport.Rows[i]["CurQtrTotalTailor"]).ToString("N0") + "</td>");
                }
                else {
                    Tasb.Append("<td></td>");
                }
                //Tasb.Append("<td>1(2)</td>");
                if (Convert.ToUInt32(dtQcTailorReport.Rows[i]["PrevQtrAvgTailor"]) != 0)
                {
                    Tasb.Append("<td>" + dtQcTailorReport.Rows[i]["PrevQtrAvgTailor"].ToString() + "</td>");
                }
                else {
                    Tasb.Append("<td></td>");
                }
                if (Convert.ToUInt32(dtQcTailorReport.Rows[i]["PrevQtrTotalTailor"]) != 0)
                {
                    //Added by Yadvendra on 12/12/19
                    Tasb.Append("<td>" + Convert.ToInt32(dtQcTailorReport.Rows[i]["PrevQtrTotalTailor"]).ToString("N0") + "</td>");
                }
                else {
                    Tasb.Append("<td></td>");
                }
                //Tasb.Append("<td>1(2)</td>");
                Tasb.Append("</tr>");
              
            }

            Tasb.Append("</table>");

            Tailor_MonthlyPerformance_Report.InnerHtml = Tasb.ToString();
        }
        protected void BindMasterMo_performanceReport() {
            DataSet dsQcMasterReport = new DataSet();
            dsQcMasterReport = objadmin.GetMasterTaitorReport();
            DataTable dtQcMasterReport = dsQcMasterReport.Tables[1];
            DataTable dtCurrentQuarter = dsQcMasterReport.Tables[3];
            int Rows = dtQcMasterReport.Rows.Count;
          
            StringBuilder sb = new StringBuilder();
            sb.Append("<table cellspacing='0' cellpadding='0' border='0' class='InternalAdminTable'>");
            sb.Append("<tr>");
            sb.Append("<th colspan='8'>Master Quarterly Performance (<span style='color:#d2cdcd'>Pattern made including Remake</span>)</th>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<th rowspan='2' style='width:100px'>Name</th>");
            sb.Append("<th colspan='2'> Q" + dtCurrentQuarter.Rows[0]["CurrentQtrNo"].ToString() + " (<span style='color:#d2cdcd;font-size:10px'>Pattern Made</span>)</th>");
            sb.Append("<th colspan='3'>Pattern WIP</th>");
            sb.Append("<th colspan='2'>Previous Qtr. (<span style='color:#d2cdcd;font-size:10px'>Pattern Made</span>)</th>");
           
          
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<th style='width:60px'>Daily Avg.</th>");
            sb.Append("<th style='width:60px'>Total</th>");
            //sb.Append("<th style='width:60px'>Remake</th>");
            sb.Append("<th style='width:80px'>Sampling</th>");
            sb.Append("<th style='width:80px'>Fits</th>");
            sb.Append("<th style='width:80px'>Total</th>");
            sb.Append("<th style='width:60px'>Daily Avg.</th>");
            sb.Append("<th style='width:60px'>Total</th>");
            //sb.Append("<th style='width:60px'>Remake</th>");
            sb.Append("</tr>");
            for (int j = 0; j < Rows; j++)
            {
                string MasterName = dtQcMasterReport.Rows[j]["MasterName"].ToString();

                if (MasterName != "Total")
                {
                    sb.Append("<tr>");
                    sb.Append("<td class='textcolorName'>" + dtQcMasterReport.Rows[j]["MasterName"].ToString() + "</td>");
                    if (Convert.ToUInt32(dtQcMasterReport.Rows[j]["AvgPatterndoneCQ"]) != 0)
                    {
                        sb.Append("<td>" + dtQcMasterReport.Rows[j]["AvgPatterndoneCQ"].ToString() + "</td>");
                    }
                    else {
                        sb.Append("<td></td>");
                    }

                    if (Convert.ToUInt32(dtQcMasterReport.Rows[j]["TotalPatternDoneCQ"]) != 0)
                    {
                        sb.Append("<td>" + dtQcMasterReport.Rows[j]["TotalPatternDoneCQ"].ToString() + "</td>");
                    }
                    else
                    {
                        sb.Append("<td></td>");
                    }
                    //String AvgRema = dtQcMasterReport.Rows[j]["AvgRemakedoneCQ"].ToString();
                    //String TotalRema = dtQcMasterReport.Rows[j]["TotalRemakeDoneCQ"].ToString();
                    //if (AvgRema == "0")
                    //{
                    //    AvgRema = "";
                    //}
                    //else
                    //{
                    //    AvgRema = "(" + dtQcMasterReport.Rows[j]["AvgRemakedoneCQ"].ToString() + ")";
                    //}
                    //if (TotalRema == "0")
                    //{SS
                    //    TotalRema = "";
                    //}
                    //else
                    //{
                    //    TotalRema =  dtQcMasterReport.Rows[j]["TotalRemakeDoneCQ"].ToString();
                    //}
                    //sb.Append("<td>" + TotalRema + "" + AvgRema + "</td>");

                  
                    //string TotalRemaPQ = dtQcMasterReport.Rows[j]["TotalRemakeDonePQ"].ToString();
                    //string AvgRemaPQ = dtQcMasterReport.Rows[j]["AvgRemakedonePQ"].ToString();
                    //if (TotalRemaPQ == "0")
                    //{
                    //    TotalRemaPQ = "";
                    //}
                    //else {
                    //    TotalRemaPQ = dtQcMasterReport.Rows[j]["TotalRemakeDonePQ"].ToString() ;
                    //}
                    //if (AvgRemaPQ == "0")
                    //{
                    //    AvgRemaPQ = "";
                    //}
                    //else {
                    //    AvgRemaPQ = "(" + dtQcMasterReport.Rows[j]["AvgRemakedonePQ"].ToString() + ")";
                    //}
                    //sb.Append("<td>" + TotalRemaPQ + ""  + AvgRemaPQ  + "</td>");

                    string SamAdd = "";
                    string SamDays = dtQcMasterReport.Rows[j]["SamplingWIPDays"].ToString();
                    string SamWip = dtQcMasterReport.Rows[j]["SamplingWIP"].ToString();
                    if (SamWip != "0")
                    {
                        SamWip = dtQcMasterReport.Rows[j]["SamplingWIP"].ToString();
                    }
                    else {
                        SamWip = "";
                    }
                    if (SamDays != "0")
                    {
                        if (SamDays != "1")
                        {
                            SamDays = dtQcMasterReport.Rows[j]["SamplingWIPDays"].ToString();
                            SamAdd = "Days";
                        }
                        else {
                            SamDays = dtQcMasterReport.Rows[j]["SamplingWIPDays"].ToString();
                            SamAdd = "Day";
                        }
                    }
                    else
                    {
                        SamDays = "";
                    }
                    string SamClass = "colorRed";

                    if (SamDays != "")
                    {
                        if (Convert.ToInt32(SamDays) < 3)
                        {
                            SamClass = "textcolorGray";
                        }
                    }
                    sb.Append("<td class='fontweightblod textLeft'><span>" + SamWip + "</span> <span class=" + SamClass + ">" + SamDays + " " + SamAdd + "</span></td>");
                   
                    string  fitsAdd="";
                    string FitsWip = dtQcMasterReport.Rows[j]["FitsWIP"].ToString();
                    string FitsDays = dtQcMasterReport.Rows[j]["FitsWIPDays"].ToString();
                    if (FitsWip != "0")
                    {
                        FitsWip = dtQcMasterReport.Rows[j]["FitsWIP"].ToString();
                    }
                    else {
                        FitsWip = "";
                    }
                    if (FitsDays != "0")
                    {
                        if (FitsDays != "1")
                        {
                            FitsDays = dtQcMasterReport.Rows[j]["FitsWIPDays"].ToString();
                            fitsAdd = "Days";
                        }
                        else {
                            FitsDays = dtQcMasterReport.Rows[j]["FitsWIPDays"].ToString();
                            fitsAdd = "Day";
                        }
                    }
                    else {
                        FitsDays = "";
                    }
                    string fitsClass = "colorRed";

                    if (FitsDays != "")
                    {
                        if (Convert.ToInt32(FitsDays) < 3)
                        {
                            fitsClass = "textcolorGray";
                        }
                    }

                    sb.Append("<td class='fontweightblod textLeft'><span>" + FitsWip + "</span> <span class=" + fitsClass + ">" + FitsDays + " " + fitsAdd + "</span></td>");

                    string TotalWip = dtQcMasterReport.Rows[j]["TotalWIP"].ToString();
                    string TotalDays = dtQcMasterReport.Rows[j]["TotalWIPDays"].ToString();
                    string TotWipAdd = "";
                    if (TotalWip != "0")
                    {
                        TotalWip = dtQcMasterReport.Rows[j]["TotalWIP"].ToString();
                    }
                    else{
                     TotalWip="";
                    }
                    if (TotalDays != "0") {
                        if (TotalDays != "1")
                        {
                            TotalDays = dtQcMasterReport.Rows[j]["TotalWIPDays"].ToString();
                            TotWipAdd = "Days";
                        }
                        else {
                            TotalDays = dtQcMasterReport.Rows[j]["TotalWIPDays"].ToString();
                            TotWipAdd = "Day";
                        }
                    }
                    else{
                      TotalDays="";
                    }

                    string SamClassT = "colorRed";
                    if (TotalDays != "")
                    {
                        if (Convert.ToInt32(TotalDays) < 3)
                        {
                            SamClassT = "textcolorGray";
                        }
                    }
                    sb.Append("<td class='fontweightblod textLeft'><span>" + TotalWip + "</span> <span class=" + SamClassT + ">" + TotalDays + " " + TotWipAdd + "</span></td>");

                    if (Convert.ToUInt32(dtQcMasterReport.Rows[j]["AvgPatterndonePQ"]) != 0)
                    {
                        sb.Append("<td>" + dtQcMasterReport.Rows[j]["AvgPatterndonePQ"].ToString() + "</td>");
                    }
                    else
                    {
                        sb.Append("<td></td>");
                    }

                    if (Convert.ToUInt32(dtQcMasterReport.Rows[j]["TotalPatternDonePQ"]) != 0)
                    {
                        sb.Append("<td>" + dtQcMasterReport.Rows[j]["TotalPatternDonePQ"].ToString() + "</td>");
                    }
                    else
                    {
                        sb.Append("<td></td>");
                    }

                    sb.Append("</tr>");
                }
                else {
                    sb.Append("<tr class='totaltextColorBack'>");
                    sb.Append("<td class='textcolorName'>" + dtQcMasterReport.Rows[j]["MasterName"].ToString() + "</td>");
                    string CurrenAvg = dtQcMasterReport.Rows[j]["AvgPatterndoneCQ"].ToString();
                    if (CurrenAvg != "0")
                    {
                        CurrenAvg = dtQcMasterReport.Rows[j]["AvgPatterndoneCQ"].ToString();
                    }
                    else {
                        CurrenAvg = "";
                   }
                    sb.Append("<td>" + CurrenAvg + "</td>");
                    string currentTotal = dtQcMasterReport.Rows[j]["TotalPatternDoneCQ"].ToString();
                    if (currentTotal != "0") {
                        //Added by Yadvendra on 12/12/19
                        currentTotal = Convert.ToString(Convert.ToInt32(dtQcMasterReport.Rows[j]["TotalPatternDoneCQ"]).ToString("N0"));
                    } else {
                        currentTotal = "";
                    }
                    sb.Append("<td>" + currentTotal + "</td>");

                    //string TotalRemack = dtQcMasterReport.Rows[j]["TotalRemakeDoneCQ"].ToString();
                    //string RemackAbg =  dtQcMasterReport.Rows[j]["AvgRemakedoneCQ"].ToString();
                    //if (TotalRemack != "0") {
                    //    TotalRemack = dtQcMasterReport.Rows[j]["TotalRemakeDoneCQ"].ToString();
                    //}
                    //else {
                    //    TotalRemack = "";
                    //}
                    //if (RemackAbg != "0") {
                    //    RemackAbg = "(" + dtQcMasterReport.Rows[j]["AvgRemakedoneCQ"].ToString() + ")";
                    //} 
                    //else { RemackAbg = ""; }
                    //sb.Append("<td>" + TotalRemack + "" + RemackAbg + "</td>");

                  

                    string SamAdd = "";
                    string SamDays = dtQcMasterReport.Rows[j]["SamplingWIPDays"].ToString();
                    string SamWip = dtQcMasterReport.Rows[j]["SamplingWIP"].ToString();
                    if (SamWip != "0")
                    {
                        SamWip = dtQcMasterReport.Rows[j]["SamplingWIP"].ToString();
                    }
                    else
                    {
                        SamWip = "";
                    }
                    if (SamDays != "0")
                    {
                        if (SamDays != "1")
                        {
                            SamDays = dtQcMasterReport.Rows[j]["SamplingWIPDays"].ToString();
                            SamAdd = "Days";
                        }
                        else {
                            SamDays = dtQcMasterReport.Rows[j]["SamplingWIPDays"].ToString();
                            SamAdd = "Day";
                        }
                    }
                    else
                    {
                        SamDays = "";
                    }
                    string SamClass = "colorRed";

                    if (SamDays != "")
                    {
                        if (Convert.ToInt32(SamDays) < 3)
                        {
                            SamClass = "textcolorGray";
                        }
                    }
                    sb.Append("<td class='fontweightblod textLeft'><span>" + SamWip + "</span> <span class=" + SamClass + ">" + SamDays + " " + SamAdd + "</span></td>");

                    string fitsAdd = "";
                    string FitsWip = dtQcMasterReport.Rows[j]["FitsWIP"].ToString();
                    string FitsDays = dtQcMasterReport.Rows[j]["FitsWIPDays"].ToString();
                    if (FitsWip != "0")
                    {
                        FitsWip = dtQcMasterReport.Rows[j]["FitsWIP"].ToString();
                    }
                    else
                    {
                        FitsWip = "";
                    }
                    if (FitsDays != "0")
                    {
                        if (FitsDays != "1")
                        {
                            FitsDays = dtQcMasterReport.Rows[j]["FitsWIPDays"].ToString();
                            fitsAdd = "Days";
                        }
                        else {
                            FitsDays = dtQcMasterReport.Rows[j]["FitsWIPDays"].ToString();
                            fitsAdd = "Day";
                        }
                    }
                    else
                    {
                        FitsDays = "";
                    }
                    string fitsClass = "colorRed";

                    if (FitsDays != "")
                    {
                        if (Convert.ToInt32(FitsDays) < 3)
                        {
                            fitsClass = "textcolorGray";
                        }
                    }

                    sb.Append("<td class='fontweightblod textLeft'><span>" + FitsWip + "</span> <span class=" + fitsClass + ">" + FitsDays + " " + fitsAdd + "</span></td>");


                    string TotWipAdd = "";
                    string TotalWip = dtQcMasterReport.Rows[j]["TotalWIP"].ToString();
                    string TotalDays = dtQcMasterReport.Rows[j]["TotalWIPDays"].ToString();
                    if (TotalWip != "0")
                    {
                        TotalWip = dtQcMasterReport.Rows[j]["TotalWIP"].ToString();
                    }
                    else
                    {
                        TotalWip = "";
                    }
                    if (TotalDays != "0")
                    {
                        if (TotalDays != "1")
                        {
                            TotalDays = dtQcMasterReport.Rows[j]["TotalWIPDays"].ToString();
                            TotWipAdd = "Days";
                        }
                        else {
                            TotalDays = dtQcMasterReport.Rows[j]["TotalWIPDays"].ToString();
                            TotWipAdd = "Day";
                        }
                    }
                    else
                    {
                        TotalDays = "";
                    }

                    string SamClassTotal = "colorRed";
                    if (TotalDays != "")
                    {
                        if (Convert.ToInt32(TotalDays) < 3)
                        {
                            SamClassTotal = "textcolorGray";
                        }
                    }
                    sb.Append("<td class='fontweightblod textLeft'><span>" + TotalWip + "</span> <span class=" + SamClassTotal + ">" + TotalDays + " " + TotWipAdd + "</span></td>");

                    string PreAvg = dtQcMasterReport.Rows[j]["AvgPatterndonePQ"].ToString();
                    if (PreAvg != "0")
                    {
                        PreAvg = dtQcMasterReport.Rows[j]["AvgPatterndonePQ"].ToString();
                    }
                    else
                    {
                        PreAvg = "";
                    }
                    sb.Append("<td>" + PreAvg + "</td>");
                    string PreTotal = dtQcMasterReport.Rows[j]["TotalPatternDonePQ"].ToString();
                    if (PreTotal != "0")
                    {
                        //Added by Yadvendra on 12/12/19
                        PreTotal = Convert.ToInt32(dtQcMasterReport.Rows[j]["TotalPatternDonePQ"]).ToString("N0");
                    }
                    else
                    {
                        PreTotal = "";
                    }
                    sb.Append("<td>" + PreTotal + "</td>");

                    //string PreTotalRemack = dtQcMasterReport.Rows[j]["TotalRemakeDonePQ"].ToString();
                    //if (PreTotalRemack != "0") {
                    //    PreTotalRemack = dtQcMasterReport.Rows[j]["TotalRemakeDonePQ"].ToString();
                    //}else{
                    //  PreTotalRemack="";
                    //}
                    //string PreRemack = dtQcMasterReport.Rows[j]["AvgRemakedonePQ"].ToString();
                    //if (PreRemack != "0")
                    //{
                    //    PreRemack = "(" + dtQcMasterReport.Rows[j]["AvgRemakedonePQ"].ToString() + ")";
                    //}
                    //else {
                    //    PreRemack = "";
                    //}
                    //sb.Append("<td>" + PreTotalRemack + "" + PreRemack + "</td>");
                    sb.Append("</tr>");
                }
            }
            sb.Append("</table>");

            Master_MonthlyPerformance_Report.InnerHtml = sb.ToString();


            

        
        }
    }
}