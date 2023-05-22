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


namespace iKandi.Web
{
    public partial class FrmLineManAchivementPerReport : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        CommonController objCommon = new CommonController();
        DateTime CommonDate;
        protected void Page_Load(object sender, EventArgs e)
        {
            CommonDate = objCommon.GetCommonRptDateOnPage();
            if (CommonDate.Day == 1)
            {
                CommonDate = CommonDate.AddDays(-1);
            }
            BindTableLineWiseEffeciency();
        }
       
        protected void BindTableLineWiseEffeciency()
        {
           
            DataSet dsQcLaxmanReport = new DataSet();
            dsQcLaxmanReport = objadmin.GetHeaderAchievmentLineManSummeryReport();
            DataTable dtQcLaxmanReport = dsQcLaxmanReport.Tables[0];

            int Rows = dtQcLaxmanReport.Rows.Count;
            string str = "";

            str = "<table cellpadding='0' cellspacing='0' style='width:720px;' border='0' class='AddClass_Table grdproc'><tr><th colspan='12' style='font-size: 12px !important;border-right:1px solid gray !important;'>Line Man Performance Report (" + CommonDate.ToString("MMMM yyyy") + ")</th></tr>";
                str = str + "<tr><th style='width:110px'>Name</th> <th>Total CQD Faults</th> <th>CQD INSPN Pass</th> <th>QC INSPN Pass</th> <th><span class='TotalCQDFUHo'>% Rescan<span class='tooltiptext'>Weight:&nbsp;&nbsp; 10% <br>Upper Limit: 20%</span><span></th>"+
                    "<th><span class='TotalCQDFUHo'>St. Achiev.<span class='tooltiptext'>Weight:&nbsp;&nbsp; 70% <br>Target:&nbsp;&nbsp; 100</span><span></th> <th>St. Eff</th> <th><span class='TotalCQDFUHo'>Compliance Audit<span class='tooltiptext'>Weight:&nbsp;&nbsp; 10% <br>Target:&nbsp;&nbsp; 100</span><span></th>"+
                    "<th><span class='TotalCQDFUHo'>Quality Audit<span class='tooltiptext'>Weight:&nbsp;&nbsp; 10% <br>Target:&nbsp;&nbsp; 100</span><span></th> <th>Total Stitch Qty.</th><th>FOB Price</th><th>Score</th></tr>";

                string TotalFaults = "";
                string CQDInspnPass = "";
                string QCInspnPass = "";
                string Rescan = "";
                string StAchieve = "";
                string StEff = "";
                string ComplianceAvg = "";
                string QualityAvg = "";               
                string StitchPcs = "";
                string FOBPrice = "";
                string Score = "";
            for (int j = 0; j < Rows; j++)
            {
                string ProcessName = dtQcLaxmanReport.Rows[j].ItemArray[0].ToString();
                string[] ProcessFirst = ProcessName.Split('(');

                if (ProcessFirst[1].ToString().Contains("C 47") && ProcessFirst[0].ToString() != "Average")
                {
                    str = str + "<tr><td style='color:gray;background:#FCF6F6; text-align:left; width:100px;' rowspan='1'><span style='color:black;font-weight:bold;'>" + ProcessFirst[0].Replace("_", " ") + "</span>&nbsp;<br/>" + "(" + ProcessFirst[1] + "</td>";
                }
                else if (ProcessFirst[1].ToString().Contains("C 45") && ProcessFirst[0].ToString() != "Average")
                {
                    str = str + "<tr><td style='color:gray;background:#E9F4F7; text-align:left; font-size:11px !important;width:100px;' rowspan='1'><span style='color:black;font-weight:bold;'>" + ProcessFirst[0].Replace("_", " ") + "</span>&nbsp;<br/>" + "(" + ProcessFirst[1] + "</td>";
                }
                else if (ProcessFirst[1].ToString().Contains("D 169") && ProcessFirst[0].ToString() != "Average")
                {
                    str = str + "<tr><td style='color:gray;background:#F2F2E2; text-align:left; font-size:11px !important;width:100px;' rowspan='1'><span style='color:black;font-weight:bold;'>" + ProcessFirst[0].Replace("_", " ") + "</span>&nbsp;<br/>" + "(" + ProcessFirst[1] + "</td>";
                }
                //else if (ProcessFirst[1].ToString().Contains("C 52") && ProcessFirst[0].ToString() != "Average")
                //{
                //    str = str + "<tr><td style='color:gray;background:#D5F7EB; text-align:left; font-size:11px !important;width:100px;' rowspan='1'><span style='color:black;font-weight:bold;'>" + ProcessFirst[0].Replace("_", " ") + "</span>&nbsp;<br/>" + "(" + ProcessFirst[1] + "</td>";
                //}
                else if (ProcessFirst[0].ToString() == "Average")
                {
                    str = str + "<tr><td style='color:gray;background:#c7d4f5; text-align:left; font-size:11px !important;width:100px;' rowspan='1'><span style='color:black;font-weight:bold;'>" + ProcessFirst[0] + "</span>&nbsp;<br/>" +"(" +ProcessFirst[1] + "</td>";
                }
                

                if (dtQcLaxmanReport.Rows[j]["TotalFaults"].ToString() != "")
                {
                    TotalFaults = Convert.ToInt32(dtQcLaxmanReport.Rows[j]["TotalFaults"]).ToString();
                }
                else
                {
                    TotalFaults = "0";
                }

                if (dtQcLaxmanReport.Rows[j]["CQDInspnPass"].ToString() != "")
                {
                    CQDInspnPass = Convert.ToInt32(dtQcLaxmanReport.Rows[j]["CQDInspnPass"]).ToString();
                }
                else
                {
                    CQDInspnPass = "0";
                }
                if (dtQcLaxmanReport.Rows[j]["QCInspnPass"].ToString() != "")
                {
                    QCInspnPass = Convert.ToInt32(dtQcLaxmanReport.Rows[j]["QCInspnPass"]).ToString();
                }
                else
                {
                    QCInspnPass = "0";
                }
                if (dtQcLaxmanReport.Rows[j]["Rescan"].ToString() != "")
                {
                    Rescan = Convert.ToInt32(dtQcLaxmanReport.Rows[j]["Rescan"]).ToString();
                }
                else
                {
                    Rescan = "0";
                }
                if (dtQcLaxmanReport.Rows[j]["StAchieve"].ToString() != "")
                {
                    StAchieve = Convert.ToInt32(dtQcLaxmanReport.Rows[j]["StAchieve"]).ToString();
                }
                else
                {
                    StAchieve = "0";
                }

                if (dtQcLaxmanReport.Rows[j]["StEff"].ToString() != "")
                {
                    StEff = Convert.ToInt32(dtQcLaxmanReport.Rows[j]["StEff"]).ToString();
                }
                else
                {
                    StEff = "0";
                }
                if (dtQcLaxmanReport.Rows[j]["ComplianceAvg"].ToString() != "")
                {
                    ComplianceAvg = Convert.ToInt32(dtQcLaxmanReport.Rows[j]["ComplianceAvg"]).ToString();
                }
                else
                {
                    ComplianceAvg = "0";
                }
                if (dtQcLaxmanReport.Rows[j]["QualityAvg"].ToString() != "")
                {
                    QualityAvg = Convert.ToInt32(dtQcLaxmanReport.Rows[j]["QualityAvg"]).ToString();
                }
                else
                {
                    QualityAvg = "0";
                }                

                if (dtQcLaxmanReport.Rows[j]["StitchPcs"].ToString() != "")
                {
                    StitchPcs = Convert.ToInt32(dtQcLaxmanReport.Rows[j]["StitchPcs"]).ToString();
                }
                else
                {
                    StitchPcs = "0";
                }

                if (Convert.ToInt32(dtQcLaxmanReport.Rows[j]["FOBPrice"]) > 0)
                {
                    double iFobPrice = Math.Round(Convert.ToDouble(dtQcLaxmanReport.Rows[j]["FOBPrice"]) / 100000,0);
                    FOBPrice = iFobPrice.ToString();                    
                }
                else
                {
                    FOBPrice = "0";
                }
                if (dtQcLaxmanReport.Rows[j]["Score"].ToString() != "")
                {
                    Score = Convert.ToInt32(dtQcLaxmanReport.Rows[j]["Score"]).ToString();
                }
                else
                {
                    Score = "0";
                }

                if (ProcessFirst[0].ToString() == "Average")
                {
                    //....Start TotalFaults....
                    TotalFaults = TotalFaults == "0" ? "" : TotalFaults + "%";
                    str = str + "<td style='background:#c7d4f5;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:black;font-size:13px !important; font-weight:bold;'>" + TotalFaults + "</span></td>";

                    //....Start CQDInspnPass...
                    CQDInspnPass = CQDInspnPass == "0" ? "" : CQDInspnPass + "%";
                    str = str + "<td style='background:#c7d4f5;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:black;font-size:13px !important; font-weight:bold;'>" + CQDInspnPass + "</span></td>";

                    //....Start QCInspnPass....
                    QCInspnPass = QCInspnPass == "0" ? "" : QCInspnPass + "%";
                    str = str + "<td style='background:#c7d4f5;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:black;font-size:13px !important; font-weight:bold;'>" + QCInspnPass + "</span></td>";


                    //....Start Rescan....
                    Rescan = Rescan == "0" ? "" : Rescan + "%";
                    str = str + "<td style='background:#c7d4f5;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:black;font-size:13px !important; font-weight:bold'>" + Rescan + "</span></td>";

                    //....Start StAchieve....
                    StAchieve = StAchieve == "0" ? "" : StAchieve + "%";
                    str = str + "<td style='background:#c7d4f5;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:black;font-size:13px !important; font-weight:bold'>" + StAchieve + "</span></td>";

                    //....Start StEff....
                    StEff = StEff == "0" ? "" : StEff + "%";
                    str = str + "<td style='background:#c7d4f5;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:black;font-size:13px !important; font-weight:bold'>" + StEff + "</span></td>";

                    //....Start Compliance....
                    ComplianceAvg = ComplianceAvg == "0" ? "" : ComplianceAvg + "%";
                    str = str + "<td style='background:#c7d4f5;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:black;font-size:13px !important; font-weight:bold'>" + ComplianceAvg + "</span></td>";

                    //....Start Quality....
                    QualityAvg = QualityAvg == "0" ? "" : QualityAvg + "%";
                    str = str + "<td style='background:#c7d4f5;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:black;font-size:13px !important; font-weight:bold'>" + QualityAvg + "</span></td>";

                    //....Start Total Stitch Qty
                    StitchPcs = StitchPcs == "0" ? "" : Convert.ToInt32(StitchPcs).ToString("N0");
                    str = str + "<td style='background:#c7d4f5;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:black;font-size:13px !important; font-weight:bold'>" + StitchPcs + "</span></td>";
                                                         

                    //....Start Total FOBPrice 
                    FOBPrice = FOBPrice == "0" ? "" : "&#x20B9; " + FOBPrice + " L";
                    str = str + "<td style='background:#c7d4f5;width:50px;height:16px;font-size:12px !important; text-align:center;' class='f-16px'><span style='color:black;font-size:13px !important; font-weight:bold'>" + FOBPrice + "</span></td>";

                    //....Score....
                    if (Convert.ToInt32(Score) < 71)
                    {
                        Score = Score == "0" ? "" : Score + "%";
                        str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:13px !important; font-weight:bold'>" + Score + "</span> </td>";
                    }
                    else
                    {
                        Score = Score == "0" ? "" : Score + "%";
                        str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:13px !important; font-weight:bold'>" + Score + "</span> </td>";
                    }
                }

                else
                {
                    //....Start TotalFaults....
                    TotalFaults = TotalFaults == "0" ? "" : TotalFaults + "%";
                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center'><span style='color:black;font-size:12px !important; font-weight:normal;'>" + TotalFaults + "</span></td>";

                    //....Start CQDInspnPass...
                    CQDInspnPass = CQDInspnPass == "0" ? "" : CQDInspnPass + "%";
                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center'><span style='color:black;font-size:12px !important; font-weight:normal;'>" + CQDInspnPass + "</span></td>";

                    //....Start QCInspnPass....
                    QCInspnPass = QCInspnPass == "0" ? "" : QCInspnPass + "%";
                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center'><span style='color:black;font-size:12px !important; font-weight:normal;'>" + QCInspnPass + "</span></td>";

                    //....Start Rescan....
                    Rescan = Rescan == "0" ? "" : Rescan + "%";
                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center'><span style='color:black;font-size:12px !important; font-weight:normal;'>" + Rescan + "</span></td>";

                    //....Start StAchieve....
                    StAchieve = StAchieve == "0" ? "" : StAchieve + "%";
                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center'><span style='color:black;font-size:12px !important; font-weight:normal;'>" + StAchieve + "</span></td>";

                    //....Start StEff....
                    StEff = StEff == "0" ? "" : StEff + "%";
                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center'><span style='color:black;font-size:12px !important; font-weight:normal;'>" + StEff + "</span></td>";
                   
                    //....Start Compliance....
                    ComplianceAvg = ComplianceAvg == "0" ? "" : ComplianceAvg + "%";
                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center'><span style='color:black;font-size:12px !important; font-weight:normal;'>" + ComplianceAvg + "</span></td>";

                    //....Start Quality....
                    QualityAvg = QualityAvg == "0" ? "" : QualityAvg + "%";
                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center'><span style='color:black;font-size:12px !important; font-weight:normal;'>" + QualityAvg + "</span></td>";

                    //....Start Total Stitch Qty....
                    StitchPcs = StitchPcs == "0" ? "" : Convert.ToInt32(StitchPcs).ToString("N0");
                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center'><span style='color:black;font-size:12px !important; font-weight:normal;'>" + StitchPcs + "</span></td>";
                                        

                    //....Start Total FOBPrice....
                    FOBPrice = FOBPrice == "0" ? "" : "&#x20B9; " + FOBPrice + " L";
                    str = str + "<td style='width:50px;height:16px;font-size:12px !important; text-align:center;'><span style='color:black;font-size:12px !important; font-weight:normal;'>" + FOBPrice + "</span></td>";

                    //....Score....
                    if (Convert.ToInt32(Score) < 71)
                    {
                        Score = Score == "0" ? "" : Score + "%";
                        str = str + "<td style='width:50px; height:16px;text-align: center'><span style='color:red;text-align: center;font-weight: bold'>" + Score + "</span> </td>";
                    }
                    else
                    {
                        Score = Score == "0" ? "" : Score + "%";
                        str = str + "<td style='width:50px; height:16px;text-align: center'><span style='color:green;text-align: center;font-weight: bold'>" + Score + "</span> </td>";
                    }
                }

                str = str + "</tr>";
            }
            
            str = str + "</table>";
            frmLineWiseEffeciency.InnerHtml = str;
        }
    }
}