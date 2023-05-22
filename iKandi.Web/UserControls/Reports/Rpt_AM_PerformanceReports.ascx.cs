using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using iKandi.BLL;
using System.Data;

namespace iKandi.Web.UserControls.Reports
{

    public partial class Rpt_AM_PerformanceReports : System.Web.UI.UserControl
    {
        AdminController objadmin = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindAM_performanceReport();
            ScoreAMTable();

        }
        protected void BindAM_performanceReport()
        {
            string CurrentMonth_QuarterValue = "", FinancialYear = "", PreviousFinancialYear = "";
            DateTime CurrentDate;
            CurrentDate = DateTime.Now;
            int month = CurrentDate.Month;
            //month = 10;

            DataSet dsAM_Reports = new DataSet();
            dsAM_Reports = objadmin.Get_AM_Reports();
            DataTable dtAM_Reports = dsAM_Reports.Tables[0];
            StringBuilder sb = new StringBuilder();
            int type = 1;
            int Rows = dtAM_Reports.Rows.Count;

            if (month == 1 || month == 2 || month == 3)
            {

                CurrentMonth_QuarterValue = "Q4";
                FinancialYear = "(" + Convert.ToString(DateTime.Now.Year - 1) + "-" + Convert.ToString(DateTime.Now.Year).Substring(2, 2) + ")";
                PreviousFinancialYear = "(" + Convert.ToString(DateTime.Now.Year - 2) + "-" + Convert.ToString(DateTime.Now.Year - 1).Substring(2, 2) + ")";
                type = 4;
            }
            else if (month == 4 || month == 5 || month == 6)
            {
                type = 1;

                CurrentMonth_QuarterValue = "Q1";
                FinancialYear = "(" + Convert.ToString(DateTime.Now.Year) + "-" + Convert.ToString(DateTime.Now.Year + 1).Substring(2, 2) + ")";
                PreviousFinancialYear = "(" + Convert.ToString(DateTime.Now.Year - 1) + "-" + Convert.ToString(DateTime.Now.Year).Substring(2, 2) + ")";
            }
            else if (month == 7 || month == 8 || month == 9)
            {
                type = 2;

                CurrentMonth_QuarterValue = "Q2";
                FinancialYear = "(" + Convert.ToString(DateTime.Now.Year) + "-" + Convert.ToString(DateTime.Now.Year + 1).Substring(2, 2) + ")";
                PreviousFinancialYear = "(" + Convert.ToString(DateTime.Now.Year - 1) + "-" + Convert.ToString(DateTime.Now.Year).Substring(2, 2) + ")";
            }
            else if (month == 10 || month == 11 || month == 12)
            {
                type = 3;

                CurrentMonth_QuarterValue = "Q3";
                FinancialYear = "(" + Convert.ToString(DateTime.Now.Year) + "-" + Convert.ToString(DateTime.Now.Year + 1).Substring(2, 2) + ")";
                PreviousFinancialYear = "(" + Convert.ToString(DateTime.Now.Year - 1) + "-" + Convert.ToString(DateTime.Now.Year).Substring(2, 2) + ")";
            }

            if (type == 1)
            {

                sb.Append("<table cellspacing='0' cellpadding='0' border='0' class='Report_Table' style='border-color:#999;max-width:1000px;'>");

                sb.Append("<tr>");
                sb.Append("<th rowspan='3' style='width:100px'>AM</th>");
                sb.Append("<th colspan='7'>Q4  Weeks</th>");
                sb.Append("<th colspan='7'>Q1 Weeks</th>");// add colspan by bharat on 14-may-20
                //sb.Append("<th colspan='7'>Previous Finance Year " + PreviousFinancialYear + " Weeks</th>"); //comment by raghvinder 08 May 2021
                //code added by bharat on 22-Aug
                sb.Append("<th colspan='4' rowspan='2' style='width:100px'>" + CurrentMonth_QuarterValue + "</th>");
                //end
                sb.Append("</tr>");

                sb.Append("<tr>");
                sb.Append("<th rowspan='2' style='width:80px'>Avg. Ex</th>");
                sb.Append("<th colspan='2'>Sealing</th>");
                sb.Append("<th colspan='2'>Fabric BIH</th>");
                sb.Append("<th colspan='2'>Accessories BIH</th>");
                sb.Append("<th rowspan='2' style='width:60px'>Avg. Ex</th>");
                sb.Append("<th colspan='2'>Sealing</th>");
                sb.Append("<th colspan='2'>Fabric BIH</th>");
                sb.Append("<th colspan='2'>Accessories BIH</th>");// line added by bharat on 14-may-20
                //sb.Append("<th rowspan='2' style='width:60px'>Avg. Ex</th>"); //comment by raghvinder 08 May 2021
                //sb.Append("<th colspan='2'>Sealing</th>");                    //comment by raghvinder 08 May 2021
                //sb.Append("<th colspan='2'>Fabric BIH</th>");                 //comment by raghvinder 08 May 2021
                //sb.Append("<th colspan='2'>Accessories BIH</th>");            //comment by raghvinder 08 May 2021
                sb.Append("</tr>");

                sb.Append("<tr>");
                // Added code by bharat on 14-may-20
                sb.Append("<th style='width:60px'>Avg. ETA</th>");
                sb.Append("<th style='width:60px'>Avg. Delay</th>");
                sb.Append("<th style='width:60px'>Avg. ETA</th>");
                sb.Append("<th style='width:60px'>Avg. Delay</th>");
                //end
                sb.Append("<th style='width:60px'>Avg. ETA</th>");
                sb.Append("<th style='width:60px'>Avg. Delay</th>");
                sb.Append("<th style='width:60px'>Avg. ETA</th>");
                sb.Append("<th style='width:60px'>Avg. Delay</th>");

                sb.Append("<th style='width:60px'>Avg. ETA</th>");
                sb.Append("<th style='width:60px'>Avg. Delay</th>");
                sb.Append("<th style='width:60px'>Avg. ETA</th>");
                sb.Append("<th style='width:60px'>Avg. Delay</th>");
                //sb.Append("<th style='width:60px'>Avg. ETA</th>");     //comment by raghvinder 08 May 2021
                //sb.Append("<th style='width:60px'>Avg. Delay</th>");   //comment by raghvinder 08 May 2021
                //sb.Append("<th style='width:60px'>Avg. ETA</th>");     //comment by raghvinder 08 May 2021
                //sb.Append("<th style='width:60px'>Avg. Delay</th>");   //comment by raghvinder 08 May 2021
                //sb.Append("<th style='width:60px'>Avg. ETA</th>");     //comment by raghvinder 08 May 2021
                //sb.Append("<th style='width:60px'>Avg. Delay</th>");   //comment by raghvinder 08 May 2021
                //sb.Append("<th style='width:80px'>Style Code Share</th>");
                //code added by bharat on 22-Aug
                sb.Append("<th  style='width:80px'>Shipped Val.</th>");
                sb.Append("<th style='width:80px'>Shipped Qty.</th>");
                sb.Append("<th style='width:80px'>Score</th>");
                sb.Append("</tr>");

                for (int i = 0; i < Rows; i++)
                {
                    sb.Append("<tr>");
                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                        sb.Append("<td class='total_prv_financial_year'>" + dtAM_Reports.Rows[i]["UserName"].ToString() + " </td>");
                    else
                        sb.Append("<td class='firstCol'>" + dtAM_Reports.Rows[i]["UserName"].ToString() + " </td>");

                    //code added by bharat on 8-11 

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks4"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks4"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek4"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek4"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek4"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek4"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH4"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH4"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH4"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH4"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH4"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH4"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH4"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH4"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH4"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH4"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH4"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH4"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH4"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH4"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH4"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH4"].ToString() + "</td>");
                    }
                    //end

                    //------------------------------------------Q1-------------------------------------------------------------------------------------------
                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgExWeek1"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek1"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgExWeek1"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks1"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgETAWeeks1"].ToString() + "</td>");

                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks1"].ToString() == "0")
                            sb.Append("<td></td>");
                        else
                            sb.Append("<td>" + dtAM_Reports.Rows[i]["AvgETAWeeks1"].ToString() + "</td>");

                    }

                    if (dtAM_Reports.Rows[i]["AvgDelayWeek1"].ToString() == "0")
                    {
                        sb.Append("<td class='green'></td>");
                    }
                    else
                    {
                        if (Convert.ToInt32(dtAM_Reports.Rows[i]["AvgDelayWeek1"]) > 0)
                            sb.Append("<td class='red'>" + dtAM_Reports.Rows[i]["AvgDelayWeek1"].ToString() + "</td>");
                        else
                            sb.Append("<td class='green'>" + dtAM_Reports.Rows[i]["AvgDelayWeek1"].ToString() + "</td>");
                    }


                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH1"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH1"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH1"].ToString() == "0")
                            sb.Append("<td></td>");
                        else
                            sb.Append("<td>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH1"].ToString() + "</td>");
                    }


                    if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH1"].ToString() == "0")
                    {
                        sb.Append("<td class='green'></td>");
                    }
                    else
                    {
                        if (Convert.ToInt32(dtAM_Reports.Rows[i]["AvgDelayWeek_BIH1"]) > 0)
                            sb.Append("<td class='red'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH1"].ToString() + "</td>");
                        else
                            sb.Append("<td class='green'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH1"].ToString() + "</td>");
                    }

                    //added code by bharat on 14-may-20

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH1"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH1"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH1"].ToString() == "0")
                            sb.Append("<td></td>");
                        else
                            sb.Append("<td>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH1"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "0")
                    {
                        sb.Append("<td class='green'></td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH1"].ToString() == "0")
                            sb.Append("<td class='green'></td>");
                        else
                            sb.Append("<td class='red'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH1"].ToString() + "</td>");
                    }
                    //end

                    //comment by raghvinder 08 May 2021

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgExWeek2"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgExWeek2"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgExWeek2"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgExWeek2"].ToString() + "</td>");
                    //}
                    

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks2"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks2"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks2"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks2"].ToString() + "</td>");
                    //}
                    

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH2"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH2"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH2"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH2"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH2"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH2"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH2"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH2"].ToString() + "</td>");
                    //}

                    //// Added by Yadvendra
                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH2"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH2"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH2"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH2"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH2"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH2"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH2"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH2"].ToString() + "</td>");
                    //}

                    //comment by raghvinder 08 May 2021
                    //END

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() == "0")
                    //        sb.Append("<td class='total'></td>");
                    //    else
                    //        sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() + " %" + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() == "0")
                    //        sb.Append("<td></td>");
                    //    else
                    //        sb.Append("<td>" + dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() + " %" + "</td>");
                    //}
                    //code added by bharat on 22-Aug
                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {

                        if (dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total' style='color:green'>" + "₹ " + dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() + " Cr." + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() != "")
                        {
                            if (dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() == "0")
                                sb.Append("<td></td>");
                            else
                                sb.Append("<td style='color:green'>" + "₹ " + dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() + " Cr." + "</td>");
                        }
                        else
                        {
                            sb.Append("<td></td>");
                        }
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {

                        if (dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() + " L " + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() != "")
                        {
                            if (dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() == "0")
                                sb.Append("<td></td>");
                            else
                                sb.Append("<td>" + dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() + " L " + "</td>");
                        }
                        else
                        {
                            sb.Append("<td></td>");
                        }
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {

                        if (dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() + " %" + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() != "")
                        {
                            if (dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() == "0")
                                sb.Append("<td></td>");
                            else
                                sb.Append("<td>" + dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() + "  %" + "</td>");
                        }
                        else
                        {
                            sb.Append("<td></td>");
                        }
                    }
                    //end
                    sb.Append("</tr>");
                }
                sb = sb.Append("</table>");
                AM_Performance_Report.InnerHtml = sb.ToString();

            }

            if (type == 2)
            {
                sb.Append("<table cellspacing='0' cellpadding='0' border=0' class='Report_Table' style='border-color:#999;max-width:1100px;'>");

                sb.Append("<tr>");
                sb.Append("<th rowspan='3' style='width:100px'>AM</th>");
                sb.Append("<th colspan='7'>Q1 Weeks</th>");
                sb.Append("<th colspan='7'>Q2 Weeks</th>");
                //sb.Append("<th colspan='7'>Previous Finance Year " + PreviousFinancialYear + " Weeks</th>");
                //code added by bharat on 22-Aug
                sb.Append("<th colspan='4' rowspan='2' style='width:100px'>" + CurrentMonth_QuarterValue + "</th>");
                //end
                sb.Append("</tr>");

                sb.Append("<tr>");
                sb.Append("<th rowspan='2' style='width:80px'>Avg. Ex</th>");
                sb.Append("<th colspan='2'>Sealing</th>");
                sb.Append("<th colspan='2'>Fabric BIH</th>");
                sb.Append("<th colspan='2'>Accessories BIH</th>");

                sb.Append("<th rowspan='2' style='width:80px'>Avg. Ex</th>");
                sb.Append("<th colspan='2'>Sealing</th>");
                sb.Append("<th colspan='2'>Fabric BIH</th>");
                sb.Append("<th colspan='2'>Accessories BIH</th>");
                //sb.Append("<th rowspan='2' style='width:80px'>Avg. Ex</th>");
                //sb.Append("<th colspan='2'>Sealing</th>");
                //sb.Append("<th colspan='2'>Fabric BIH</th>");
                //sb.Append("<th colspan='2'>Accessories BIH</th>");
                sb.Append("</tr>");

                sb.Append("<tr>");
                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");
                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");
                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");
                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");
                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");
                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");
                //sb.Append("<th style='width:80px'>Avg. ETA</th>");
                //sb.Append("<th style='width:80px'>Avg. Delay</th>");
                //sb.Append("<th style='width:80px'>Avg. ETA</th>");
                //sb.Append("<th style='width:80px'>Avg. Delay</th>");
                //sb.Append("<th style='width:80px'>Style Code Share</th>");
                //code added by bharat on 22-Aug
                sb.Append("<th  style='width:80px'>Shipped Val.</th>");
                sb.Append("<th style='width:80px'>Shipped Qty.</th>");
                sb.Append("<th style='width:80px'>Score</th>");
                //end
                sb.Append("</tr>");

                for (int i = 0; i < Rows; i++)
                {
                    sb.Append("<tr>");
                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        sb.Append("<td class='total_prv_financial_year'>" + dtAM_Reports.Rows[i]["UserName"].ToString() + " </td>");
                    }
                    else
                    {
                        sb.Append("<td class='firstCol'>" + dtAM_Reports.Rows[i]["UserName"].ToString() + " </td>");
                    }

                    ////-------------------------------------------------------------- Q1 ------------------------------------------------

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek1"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgExWeek1"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek1"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgExWeek1"].ToString() + "</td>");
                    }
                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks1"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks1"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks1"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks1"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek1"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek1"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek1"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek1"].ToString() + "</td>");
                    }


                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH1"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH1"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH1"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH1"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH1"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH1"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH1"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH1"].ToString() + "</td>");
                    }
                    // For Accessory
                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH1"].ToString() == "0")
                            //sb.Append("<td class='total'></td>");
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            //sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH1"].ToString() + "</td>");
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH1"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH1"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH1"].ToString() + "</td>");
                    }



                    if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH1"].ToString() == "0")
                    {
                        //sb.Append("<td class='green'></td>");
                        sb.Append("<td class='priviousyear'></td>");
                    }
                    else
                    {
                        if (Convert.ToInt32(dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH1"]) > 0)
                            //sb.Append("<td class='red'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH1"].ToString() + "</td>");
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH1"].ToString() + "</td>");
                        else
                            //sb.Append("<td class='green'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH1"].ToString() + "</td>");
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH1"].ToString() + "</td>");

                    }
                    //END

                    ////-------------------------------------------------------------- Q2 ------------------------------------------------

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek2"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgExWeek2"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek2"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgExWeek2"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks2"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgETAWeeks2"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks2"].ToString() == "0")
                            sb.Append("<td></td>");
                        else
                            sb.Append("<td>" + dtAM_Reports.Rows[i]["AvgETAWeeks2"].ToString() + "</td>");
                    }


                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() == "0")
                        {
                            sb.Append("<td class='green'></td>");
                        }
                        else
                        {
                            if (Convert.ToInt32(dtAM_Reports.Rows[i]["AvgDelayWeek2"]) > 0)
                            {
                                sb.Append("<td class='red'>" + dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() + "</td>");
                            }
                            else
                            {
                                if (dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() == "0")
                                    sb.Append("<td class='green'></td>");
                                else
                                    sb.Append("<td class='green'>" + dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() + "</td>");
                            }

                        }
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() == "0")
                        {
                            sb.Append("<td class='green'></td>");
                        }
                        else
                        {
                            if (Convert.ToInt32(dtAM_Reports.Rows[i]["AvgDelayWeek2"]) > 0)
                            {
                                sb.Append("<td class='red'>" + dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() + "</td>");
                            }
                            else
                            {
                                if (dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() == "0")
                                    sb.Append("<td class='green'></td>");
                                else
                                    sb.Append("<td class='green'>" + dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() + "</td>");
                            }
                        }
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH2"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH2"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH2"].ToString() == "0")
                            sb.Append("<td></td>");
                        else
                            sb.Append("<td>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH2"].ToString() + "</td>");
                    }



                    if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH2"].ToString() == "0")
                    {
                        sb.Append("<td class='green'></td>");
                    }
                    else
                    {
                        if (Convert.ToInt32(dtAM_Reports.Rows[i]["AvgDelayWeek_BIH2"]) > 0)
                            sb.Append("<td class='red'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH2"].ToString() + "</td>");
                        else
                            sb.Append("<td class='green'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH2"].ToString() + "</td>");

                    }

                    // Added By Yadvendra
                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH2"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH2"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH2"].ToString() == "0")
                            sb.Append("<td></td>");
                        else
                            sb.Append("<td>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH2"].ToString() + "</td>");
                    }



                    if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH2"].ToString() == "0")
                    {
                        sb.Append("<td class='green'></td>");
                    }
                    else
                    {
                        if (Convert.ToInt32(dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH2"]) > 0)
                            sb.Append("<td class='red'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH2"].ToString() + "</td>");
                        else
                            sb.Append("<td class='green'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH2"].ToString() + "</td>");

                    }
                    //END
                    //////-------------------------------------------------------------- Q3 ------------------------------------------------
                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgExWeek3"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgExWeek3"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgExWeek3"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgExWeek3"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks3"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks3"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks3"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks3"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek3"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek3"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek3"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek3"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH3"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH3"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH3"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH3"].ToString() + "</td>");
                    //}


                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH3"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH3"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH3"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH3"].ToString() + "</td>");
                    //}

                    //// Added By Yadvendra
                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH3"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH3"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH3"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH3"].ToString() + "</td>");
                    //}


                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH3"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH3"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH3"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH3"].ToString() + "</td>");
                    //}
                    //END

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() == "0")
                    //        sb.Append("<td class='total'></td>");
                    //    else
                    //        sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() == "0")
                    //        sb.Append("<td></td>");
                    //    else
                    //        sb.Append("<td>" + dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() + "</td>");
                    //}
                    //code added by bharat on 22-Aug

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {

                        if (dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'style='color:green'>" + "₹ " + dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() + " Cr." + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() != "")
                        {
                            if (dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() == "0")
                                sb.Append("<td></td>");
                            else
                                sb.Append("<td style='color:green'>" + "₹ " + dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() + " Cr." + "</td>");
                        }
                        else
                        {
                            sb.Append("<td></td>");
                        }
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {

                        if (dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() + " L" + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() != "")
                        {
                            if (dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() == "0")
                                sb.Append("<td></td>");
                            else
                                sb.Append("<td>" + dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() + " L" + "</td>");
                        }
                        else
                        {
                            sb.Append("<td></td>");
                        }
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {

                        if (dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() + " %" + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() != "")
                        {
                            if (dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() == "0")
                                sb.Append("<td></td>");
                            else
                                sb.Append("<td>" + dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() + " %" + "</td>");
                        }
                        else
                        {
                            sb.Append("<td></td>");
                        }
                    }
                    //End

                    sb.Append("</tr>");


                }
                sb.Append("</table>");
                AM_Performance_Report.InnerHtml = sb.ToString();
            }

            if (type == 3)
            {
                sb.Append("<table cellspacing='0' cellpadding='0' border='0' class='Report_Table' style='border-color:#999;max-width:1100px;'>");

                sb.Append("<tr>");
                sb.Append("<th rowspan='3' style='width:100px'>AM</th>");
                //sb.Append("<th colspan='5'>Q1 Weeks</th>");
                sb.Append("<th colspan='7'>Q2 Weeks</th>");
                sb.Append("<th colspan='7'>Q3 Weeks</th>");
                //sb.Append("<th colspan='7'>Previous Finance Year " + PreviousFinancialYear + " Weeks</th>");
                //code added by bharat on 22-Aug
                sb.Append("<th colspan='4' rowspan='2' style='width:100px'>" + CurrentMonth_QuarterValue + "</th>");
                //end
                sb.Append("</tr>");

                sb.Append("<tr>");
                //sb.Append("<th rowspan='2' style='width:80px'>Avg. Ex</th>");
                //sb.Append("<th colspan='2'>Sealing</th>");
                //sb.Append("<th colspan='2'>Fabric BIH</th>");
                sb.Append("<th rowspan='2' style='width:80px'>Avg. Ex</th>");
                sb.Append("<th colspan='2'>Sealing</th>");
                sb.Append("<th colspan='2'>Fabric BIH</th>");
                sb.Append("<th colspan='2'>Accessories BIH</th>");
                sb.Append("<th rowspan='2' style='width:80px'>Avg. Ex</th>");
                sb.Append("<th colspan='2'>Sealing</th>");
                sb.Append("<th colspan='2'>Fabric BIH</th>");
                sb.Append("<th colspan='2'>Accessories BIH</th>");
                //sb.Append("<th rowspan='2' style='width:80px'>Avg. Ex</th>");
                //sb.Append("<th colspan='2'>Sealing</th>");
                //sb.Append("<th colspan='2'>Fabric BIH</th>");
                //sb.Append("<th colspan='2'>Accessories BIH</th>");
                sb.Append("</tr>");

                sb.Append("<tr>");
               
                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");
                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");

                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");
                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");

                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");
                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");

                //sb.Append("<th style='width:80px'>Avg. ETA</th>");
                //sb.Append("<th style='width:80px'>Avg. Delay</th>");
                //sb.Append("<th style='width:80px'>Avg. ETA</th>");
                //sb.Append("<th style='width:80px'>Avg. Delay</th>");
                //sb.Append("<th style='width:80px'>Avg. ETA</th>");
                //sb.Append("<th style='width:80px'>Avg. Delay</th>");
                //sb.Append("<th style='width:80px'>Style Code Share</th>");
                //code added by bharat on 22-Aug
                sb.Append("<th  style='width:80px'>Shipped Val.</th>");
                sb.Append("<th style='width:80px'>Shipped Qty.</th>");
                sb.Append("<th style='width:80px'>Score</th>");
                //end
                sb.Append("</tr>");

                for (int i = 0; i < Rows; i++)
                {
                    sb.Append("<tr>");

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        sb.Append("<td class='total_prv_financial_year'>" + dtAM_Reports.Rows[i]["UserName"].ToString() + "</td>");
                    }
                    else
                    {
                        sb.Append("<td class='firstCol'>" + dtAM_Reports.Rows[i]["UserName"].ToString() + "</td>");
                    }
                 
                    // -------------------------------------------------------- Quarter 2 --------------------------------------------

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek2"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgExWeek2"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek2"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgExWeek2"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks2"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks2"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks2"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks2"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek2"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH2"].ToString() == "0")
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH2"].ToString() + "</td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH2"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH2"].ToString() == "0")
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH2"].ToString() + "</td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH2"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH2"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH2"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH2"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH2"].ToString() + "</td>");
                    }

                    // Added By Yadvendra
                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH2"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH2"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH2"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH2"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH2"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH2"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH2"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH2"].ToString() + "</td>");
                    }
                    // END

                    // -------------------------------------------------------- Quarter 3 --------------------------------------------

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek3"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgExWeek3"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek3"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgExWeek3"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks3"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgETAWeeks3"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks3"].ToString() == "0")
                            sb.Append("<td></td>");
                        else
                            sb.Append("<td>" + dtAM_Reports.Rows[i]["AvgETAWeeks3"].ToString() + "</td>");
                    }



                    if (Convert.ToInt32(dtAM_Reports.Rows[i]["AvgDelayWeek3"]) > 0)
                    {
                        sb.Append("<td class='red'>" + dtAM_Reports.Rows[i]["AvgDelayWeek3"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek3"].ToString() == "0")
                            sb.Append("<td class='green'></td>");
                        else
                            sb.Append("<td class='green'>" + dtAM_Reports.Rows[i]["AvgDelayWeek3"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH3"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH3"].ToString() + "</td>");

                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH3"].ToString() == "0")
                            sb.Append("<td></td>");
                        else
                            sb.Append("<td>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH3"].ToString() + "</td>");

                    }

                    if (Convert.ToInt32(dtAM_Reports.Rows[i]["AvgDelayWeek_BIH3"]) > 0)
                    {
                        sb.Append("<td class='red'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH3"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH3"].ToString() == "0")
                            sb.Append("<td class='green'></td>");
                        else
                            sb.Append("<td class='green'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH3"].ToString() + "</td>");
                    }

                    // Added By Yadvendra
                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH3"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH3"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH3"].ToString() == "0")
                            sb.Append("<td class=''></td>");
                        else
                            sb.Append("<td class=''>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH3"].ToString() + "</td>");
                    }

                    if (Convert.ToInt32(dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH3"]) > 0)
                    {
                        sb.Append("<td class='red'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH3"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH3"].ToString() == "0")
                            sb.Append("<td class='green'></td>");
                        else
                            sb.Append("<td class='green'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH3"].ToString() + "</td>");
                    }
                    // END

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks4"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks4"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek4"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek4"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek4"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek4"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH4"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH4"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH4"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH4"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH4"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH4"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH4"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH4"].ToString() + "</td>");
                    //}

                    //// Added By Yadvendra
                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH4"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH4"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH4"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH4"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH4"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH4"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH4"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH4"].ToString() + "</td>");
                    //}
                    // END

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() == "0")
                    //        sb.Append("<td class='total'></td>");
                    //    else
                    //        sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() == "0")
                    //        sb.Append("<td></td>");
                    //    else
                    //        sb.Append("<td>" + dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() + "</td>");
                    //}
                    //code added by bharat on 22-Aug
                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {

                        if (dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total' style='color:green'>" + "₹ " + dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() + " Cr." + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() != "")
                        {

                            if (dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() == "0")
                                sb.Append("<td></td>");
                            else
                                sb.Append("<td style='color:green'>" + "₹ " + dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() + "  Cr." + "</td>");
                        }
                        else
                        {
                            sb.Append("<td></td>");
                        }
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {

                        if (dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() + " L " + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() != "")
                        {

                            if (dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() == "0")
                                sb.Append("<td></td>");
                            else
                                sb.Append("<td>" + dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() + " L " + "</td>");
                        }
                        else
                        {
                            sb.Append("<td></td>");
                        }
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {

                        if (dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() + " %" + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() != "")
                        {
                            if (dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() == "0")
                                sb.Append("<td></td>");
                            else
                                sb.Append("<td>" + dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() + " %" + "</td>");
                        }
                        else
                        {
                            sb.Append("<td></td>");
                        }
                    }
                    //end

                    sb.Append("</tr>");


                }

                sb.Append("</table>");
                AM_Performance_Report.InnerHtml = sb.ToString();


            }

            if (type == 4)
            {
                sb.Append("<table cellspacing='0' cellpadding='0' border='0' class='Report_Table' style='border-color:#999;max-width:1100px;'>");

                sb.Append("<tr>");
                sb.Append("<th rowspan='3' style='width:100px'>AM</th>");
                sb.Append("<th colspan='7'>Q3 Weeks</th>");
                sb.Append("<th colspan='7'>Q4 Weeks</th>");
                //sb.Append("<th colspan='7'>Previous Finance Year " + PreviousFinancialYear + " Weeks</th>");
                //code added by bharat on 22-Aug
                sb.Append("<th colspan='4' rowspan='2' style='width:100px'>" + CurrentMonth_QuarterValue + "</th>");
                //end
                sb.Append("</tr>");

                sb.Append("<tr>");
                sb.Append("<th rowspan='2' style='width:80px'>Avg. Ex</th>");
                sb.Append("<th colspan='2'>Sealing</th>");
                sb.Append("<th colspan='2'>Fabric BIH</th>");
                sb.Append("<th colspan='2'>Accessories BIH</th>");

                sb.Append("<th rowspan='2' style='width:80px'>Avg. Ex</th>");
                sb.Append("<th colspan='2'>Sealing</th>");
                sb.Append("<th colspan='2'>Fabric BIH</th>");
                sb.Append("<th colspan='2'>Accessories BIH</th>");

                //sb.Append("<th rowspan='2' style='width:80px'>Avg. Ex</th>");
                //sb.Append("<th colspan='2'>Sealing</th>");
                //sb.Append("<th colspan='2'>Fabric BIH</th>");
                //sb.Append("<th colspan='2'>Accessories BIH</th>");
                sb.Append("</tr>");

                sb.Append("<tr>");

                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");
                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");

                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");
                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");

                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");
                sb.Append("<th style='width:80px'>Avg. ETA</th>");
                sb.Append("<th style='width:80px'>Avg. Delay</th>");

                //sb.Append("<th style='width:80px'>Avg. ETA</th>");
                //sb.Append("<th style='width:80px'>Avg. Delay</th>");
                //sb.Append("<th style='width:80px'>Avg. ETA</th>");
                //sb.Append("<th style='width:80px'>Avg. Delay</th>");
                //sb.Append("<th style='width:80px'>Avg. ETA</th>");
                //sb.Append("<th style='width:80px'>Avg. Delay</th>");
                //sb.Append("<th style='width:80px'>Style Code Share</th>");
                //code added by bharat on 22-Aug
                sb.Append("<th  style='width:80px'>Shipped Val.</th>");
                sb.Append("<th style='width:80px'>Shipped Qty.</th>");
                sb.Append("<th style='width:80px'>Score %</th>");
                sb.Append("</tr>");


                for (int i = 0; i < Rows; i++)
                {
                    sb.Append("<tr>");

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        sb.Append("<td class='total_prv_financial_year'>" + dtAM_Reports.Rows[i]["UserName"].ToString() + "</td>");
                    }
                    else
                    {
                        sb.Append("<td class='firstCol'>" + dtAM_Reports.Rows[i]["UserName"].ToString() + "</td>");
                    }

                    // -------------------------------------------------------- Q 3 -------------------------------------------------

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek3"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgExWeek3"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek3"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgExWeek3"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek3"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks3"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek3"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks3"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek3"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek3"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek3"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek3"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH3"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH3"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH3"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH3"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH3"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH3"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH3"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH3"].ToString() + "</td>");
                    }

                    // Added By Yadvendra
                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH3"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH3"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH3"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH3"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH3"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH3"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH3"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH3"].ToString() + "</td>");
                    }

                    // -------------------------------------------------------- Q 4 -------------------------------------------------
                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() == "0")
                            sb.Append("<td class='priviousyear'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgExWeek4"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks4"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgETAWeeks4"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks4"].ToString() == "0")
                            sb.Append("<td></td>");
                        else
                            sb.Append("<td>" + dtAM_Reports.Rows[i]["AvgETAWeeks4"].ToString() + "</td>");
                    }



                    if (Convert.ToInt32(dtAM_Reports.Rows[i]["AvgDelayWeek4"]) > 0)
                    {
                        sb.Append("<td class='red'>" + dtAM_Reports.Rows[i]["AvgDelayWeek4"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek4"].ToString() == "0")
                            sb.Append("<td class='green'></td>");
                        else
                            sb.Append("<td class='green'>" + dtAM_Reports.Rows[i]["AvgDelayWeek4"].ToString() + "</td>");
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH4"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH4"].ToString() + "</td>");

                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH4"].ToString() == "0")
                            sb.Append("<td></td>");
                        else
                            sb.Append("<td>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH4"].ToString() + "</td>");

                    }

                    if (Convert.ToInt32(dtAM_Reports.Rows[i]["AvgDelayWeek_BIH4"]) > 0)
                    {
                        sb.Append("<td class='red'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH4"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH4"].ToString() == "0")
                            sb.Append("<td class='green'></td>");
                        else
                            sb.Append("<td class='green'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH4"].ToString() + "</td>");
                    }

                    // Added By Yadvendra
                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH4"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH4"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH4"].ToString() == "0")
                            sb.Append("<td class=''></td>");
                        else
                            sb.Append("<td class=''>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH4"].ToString() + "</td>");
                    }

                    if (Convert.ToInt32(dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH4"]) > 0)
                    {
                        sb.Append("<td class='red'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH4"].ToString() + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH4"].ToString() == "0")
                            sb.Append("<td class='green'></td>");
                        else
                            sb.Append("<td class='green'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH4"].ToString() + "</td>");
                    }
                    // END

                    ////add code by bharat on 7-1-20 for Previous year
                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgExWeek1"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgExWeek1"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgExWeek1"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgExWeek1"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgExWeek1"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks1"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgExWeek1"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks1"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek1"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek1"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek1"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek1"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH1"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH1"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_BIH1"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_BIH1"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH1"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH1"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_BIH1"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_BIH1"].ToString() + "</td>");
                    //}


                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH1"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH1"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH1"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgETAWeeks_ACC_BIH1"].ToString() + "</td>");
                    //}

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH1"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear previousTotal'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH1"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH1"].ToString() == "0")
                    //        sb.Append("<td class='priviousyear'></td>");
                    //    else
                    //        sb.Append("<td class='priviousyear'>" + dtAM_Reports.Rows[i]["AvgDelayWeek_ACC_BIH1"].ToString() + "</td>");
                    //}
                    //end

                    //if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    //{
                    //    if (dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() == "0")
                    //        sb.Append("<td class='total'></td>");
                    //    else
                    //        sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() + "</td>");
                    //}
                    //else
                    //{
                    //    if (dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() == "0")
                    //        sb.Append("<td></td>");
                    //    else
                    //        sb.Append("<td>" + dtAM_Reports.Rows[i]["StyleCodeShare"].ToString() + "</td>");
                    //}
                    //code added by bharat on 22-Aug
                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {

                        if (dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total' style='color:green'>" + "₹ " + dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() + " Cr." + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() != "")
                        {
                            if (dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() == "0")
                                sb.Append("<td></td>");
                            else
                                sb.Append("<td style='color:green'>" + "₹ " + dtAM_Reports.Rows[i]["PrevQtrShipVal"].ToString() + "  Cr." + "</td>");
                        }
                        else
                        {
                            sb.Append("<td></td>");
                        }
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {

                        if (dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() + " L " + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() != "")
                        {
                            if (dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() == "0")
                                sb.Append("<td></td>");
                            else
                                sb.Append("<td>" + dtAM_Reports.Rows[i]["PrevQtrShipQty"].ToString() + " L " + "</td>");
                        }
                        else
                        {
                            sb.Append("<td></td>");
                        }
                    }

                    if (dtAM_Reports.Rows[i]["UserName"].ToString() == "Total")
                    {

                        if (dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() == "0")
                            sb.Append("<td class='total'></td>");
                        else
                            sb.Append("<td class='total'>" + dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() + " %" + "</td>");
                    }
                    else
                    {
                        if (dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() != "")
                        {
                            if (dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() == "0")
                                sb.Append("<td></td>");
                            else
                                sb.Append("<td>" + dtAM_Reports.Rows[i]["PrevQtrRevenueShare"].ToString() + " %" + "</td>");
                        }
                        else
                        {
                            sb.Append("<td></td>");
                        }
                    }
                    //end

                    sb.Append("</tr>");
                }

                sb.Append("</table>");
                AM_Performance_Report.InnerHtml = sb.ToString();


            }
        }

        protected void ScoreAMTable()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objadmin.GetIncentiveScoreAmPerformnce();
            dt = ds.Tables[2];
            StringBuilder strScore = new StringBuilder();
            if (dt.Rows.Count > 0)
            {
                strScore.Append("<table cellpadding='0' cellspacing='0' border='0' style='max-width: 140px;margin: 0px 0px 5px !important; text-align: center'>");
                strScore.Append("<tr><th style='padding:2px 5px !important;border:1px solid #999 !important;width:140px;'>Material Performance Score</th></tr>");
                if ((dt.Rows[0]["MaterialScore"].ToString()) != "0")
                {
                    strScore.Append("<tr><td style='width:80px;border: 1px solid #999;border-top: 0px;color:#000'><b>" + dt.Rows[0]["MaterialScore"] + "%</b></td></tr></table>");
                }
                else
                {
                    strScore.Append("<tr><td style='width:80px;border: 1px solid #999;border-top: 0px;color:#000;height:18px;'></td></tr></table>");
                }
                ScoretableVal.InnerHtml = strScore.ToString();
            }
        }

    }
}