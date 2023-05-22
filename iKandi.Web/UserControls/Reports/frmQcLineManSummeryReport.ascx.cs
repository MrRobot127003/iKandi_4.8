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
    public partial class frmQcLineManSummeryReport : System.Web.UI.UserControl
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
            BindTableQC();
        }
        
        protected void BindTableQC()
        {                      
            DataSet dsQcLaxmanReport = new DataSet();
            dsQcLaxmanReport = objadmin.GetHeaderQCSummeryReport();

            DataTable dtQcLaxmanReport = dsQcLaxmanReport.Tables[1];
            int Rows = dtQcLaxmanReport.Rows.Count;
            string str = "";

            str = "<table cellpadding='0' cellspacing='0' style='width:660px;' border='1' class='grdproc AddClass_Table'> <tr><th colspan='8' style='font-size: 12px !important;border-right:1px solid gray !important;'>QC Performance Report (" + CommonDate.ToString("MMMM yyyy") + ")</th></tr>";
            str = str + "<tr><th> Name </th>   <th><span class='TotalCQDFUHo'>Total CQD Faults <span class='tooltiptext'>Weight:&nbsp;&nbsp; 20% <br>Upper Limit: 15%</span><span></th>  <th><span class='TotalCQDFUHo'>CQD INSPN Pass <span class='tooltiptext'>Weight:&nbsp;&nbsp; 10% <br>Target:&nbsp;&nbsp; 100%</span></span></th>"+
            "<th><span class='TotalCQDFUHo'>Marked Rescan <span class='tooltiptext'>Weight:&nbsp;&nbsp; 70% <br>Upper Limit: 20%</span><span></th>   <th><span class='TotalCQDFUHo'>Total QC Checked Qty. <span class='tooltiptext'>Target:&nbsp;&nbsp; 20,000</span></span></th> <th>Quality Audit</th> <th>Score</th></tr>";

            string TotalFaults = "";
            string CQDInspnPass = "";
            string MarkedRescan = "";
            string TotalCheckedQty = "";            
            string QualityAudit = "";
            string Score = "";

            for (int j = 0; j < Rows; j++)
            {
                string ProcessName = dtQcLaxmanReport.Rows[j].ItemArray[0].ToString();

                string[] ProcessFirst = ProcessName.Split('_');
                if (ProcessFirst[0].ToString() != "Average")
                {
                    if (ProcessFirst[1].ToString().Contains("C 47"))
                    {
                        str = str + "<tr><td style='color:#403c3c; background:#FCF6F6; text-align:left; width:120px;padding-left: 3px !important;' rowspan='1'><span style='color:black;font-weight:bold;'>" + ProcessFirst[0] +
                            "</span>&nbsp;<br/>&nbsp;<span style='font-size:10px;'>" + ProcessFirst[1] + "</span></td>";
                    }
                    else if (ProcessFirst[1].ToString().Contains("C 45"))
                    {
                        str = str + "<tr><td style='color:#403c3c; background: #E9F4F7; text-align:left; font-size:11px !important;width:120px;padding-left: 3px !important;' rowspan='1'><span style='color:black;font-weight:bold;'>" + ProcessFirst[0] +
                            "</span>&nbsp;<br/>&nbsp;<span style='font-size:10px;'>" + ProcessFirst[1] + "</span></td>";
                    }                    
                    else if (ProcessFirst[1].ToString().Contains("D 169"))
                    {
                        str = str + "<tr><td style='color:#403c3c; background:#F2F2E2; text-align:left; font-size:11px !important;width:120px;padding-left: 3px !important;' rowspan='1'><span style='color:black;font-weight:bold;'>" + ProcessFirst[0] +
                            "</span>&nbsp;<br/>&nbsp;<span style='font-size:10px;'>" + ProcessFirst[1] + "</span></td>";
                    }
                    //else if (ProcessFirst[1].ToString().Contains("C 52"))
                    //{
                    //    str = str + "<tr><td style='color:#403c3c; background:#D5F7EB; text-align:left; font-size:11px !important;width:120px;padding-left: 3px !important;' rowspan='1'><span style='color:black;font-weight:bold;'>" + ProcessFirst[0] +
                    //        "</span>&nbsp;<br/>&nbsp;<span style='font-size:10px;'>" + ProcessFirst[1] + "</span></td>";
                    //}
                    else
                    {
                        str = str + "<tr><td style='color:#403c3c; background:#F4F6F6; text-align:left; font-size:11px !important;width:120px;padding-left: 3px !important;' rowspan='1'><span style='color:black;font-weight:bold;'>" + ProcessFirst[0] +
                            "</span>&nbsp;<br/>&nbsp;<span style='font-size:10px;'>" + ProcessFirst[1] + "</span></td>";
                    }
                    
                }
                else if (ProcessFirst[0].ToString() == "Average")
                {
                    str = str + "<tr><td style='color:#403c3c;background:#c7d4f5; text-align:left; font-size:11px !important;width:120px;padding-left: 3px !important;' rowspan='1'><span style='color:black;font-weight:bold;'>" + ProcessFirst[0] + "</span>&nbsp;<br/>&nbsp;<span style='font-size:10px;'>" + ProcessFirst[1] + "</span></td>";
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
                if (dtQcLaxmanReport.Rows[j]["MarkedRescan"].ToString() != "")
                {
                    MarkedRescan = Convert.ToInt32(dtQcLaxmanReport.Rows[j]["MarkedRescan"]).ToString();
                }
                else
                {
                    MarkedRescan = "0";
                }
                if (dtQcLaxmanReport.Rows[j]["TotalCheckedQty"].ToString() != "")
                {
                    TotalCheckedQty = Convert.ToInt32(dtQcLaxmanReport.Rows[j]["TotalCheckedQty"]).ToString("N0");
                }
                else
                {
                    TotalCheckedQty = "0";
                }                
                if (dtQcLaxmanReport.Rows[j]["Score"].ToString() != "")
                {
                    Score = Convert.ToInt32(dtQcLaxmanReport.Rows[j]["Score"]).ToString();
                }
                else
                {
                    Score = "0";
                }
                if (dtQcLaxmanReport.Rows[j]["QualityAudit"].ToString() != "")
                {
                    QualityAudit = Convert.ToInt32(dtQcLaxmanReport.Rows[j]["QualityAudit"]).ToString();
                }
                else
                {
                    QualityAudit = "0";
                }
                

                if (ProcessFirst[0].ToString() == "Average")
                {
                    //.... TotalFaults....
                    TotalFaults = TotalFaults == "0" ? "" : TotalFaults + "%";
                    str = str + "<td style='background:#c7d4f5;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:black;font-size:13px !important; font-weight:bold;'>" + TotalFaults + "</span></td>";

                    //.... CQDInspnPass...
                    CQDInspnPass = CQDInspnPass == "0" ? "" : CQDInspnPass + "%";
                    str = str + "<td style='background:#c7d4f5;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:black;font-size:13px !important; font-weight:bold;'>" + CQDInspnPass + "</span></td>";

                    //.... MarkedRescan....
                    MarkedRescan = MarkedRescan == "0" ? "" : MarkedRescan + "%";
                    str = str + "<td style='background:#c7d4f5;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:black;font-size:13px !important; font-weight:bold;'>" + MarkedRescan + "</span></td>";


                    //.... TotalCheckedQty....
                    TotalCheckedQty = TotalCheckedQty == "0" ? "" : TotalCheckedQty;
                    str = str + "<td style='background:#c7d4f5;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:black;font-size:13px !important; font-weight:bold'>" + TotalCheckedQty + "</span></td>";

                    
                    //.... QualityAudite....
                    QualityAudit = QualityAudit == "0" ? "" : QualityAudit + "%";
                    str = str + "<td style='background:#c7d4f5;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:black;font-size:13px !important;font-weight:bold'>" + QualityAudit + "</span></td>";

                    //.... Score....
                    if (Convert.ToInt32(Score) < 71)
                    {
                        Score = Score == "0" ? "" : Score + "%";
                        str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:13px !important; font-weight:bold'>" + Score + "</span> </td>";
                    }
                    else
                    {
                        Score = Score == "0" ? "" : Score + "%";
                        str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:13px !important; font-weight:bold'>" + Score + "</span></td>";
                    }
                   
                }
                else
                {
                    //....TotalFaults....
                    TotalFaults = TotalFaults == "0" ? "" : TotalFaults + "%";
                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:black;font-size:12px !important; font-weight:normal;'>" + TotalFaults + "</span></td>";
                      
                    //....CQDInspnPass....
                    CQDInspnPass = CQDInspnPass == "0" ? "" : CQDInspnPass + "%";
                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:black;font-size:12px !important; font-weight:normal;'>" + CQDInspnPass + "</span></td>";
                       
                    //.... MarkedRescan....
                    MarkedRescan = MarkedRescan == "0" ? "" : MarkedRescan + "%";
                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:black;font-size:12px !important; font-weight:normal;'>" + MarkedRescan + "</span></td>";
                    
                    //.... TotalCheckedQty....
                    TotalCheckedQty = TotalCheckedQty == "0" ? "" : TotalCheckedQty;
                    str = str + "<td style='width:50px; height:16px;text-align: center'><span style='color:black'>" + TotalCheckedQty + "</span> </td>";
                                       

                    //.... QualityAudite....
                    QualityAudit = QualityAudit == "0" ? "" : QualityAudit + "%";
                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:black;font-size:12px !important;'>" + QualityAudit + "</span></td>";

                    //.... Score....
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
            frmQCsummeryReport.InnerHtml = str;
        }



    }
}