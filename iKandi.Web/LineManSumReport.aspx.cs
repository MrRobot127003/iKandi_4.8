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
    public partial class LineManSumReport : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindTableLineMan();
        }

        public int GetQuarter(DateTime date)
        {
            if (date.Month >= 4 && date.Month <= 6)
                return 1;
            else if (date.Month >= 7 && date.Month <= 9)
                return 2;
            else if (date.Month >= 10 && date.Month <= 12)
                return 3;
            else
                return 4;
        }
        protected void BindTableLineMan()
        {
            string quater_sum = "";
            string quarter = "";
            DateTime dtnow = DateTime.Now;
            int Quarter = GetQuarter(dtnow);

            if (Quarter == 1)
            {
                quater_sum = "Last Year";
                quarter = "Q1";
            }
            else if (Quarter == 2)
            {
                quater_sum = "Q1";
                quarter = "Q2";
            }
            else if (Quarter == 3)
            {
                quater_sum = "Q1 & Q2";
                quarter = "Q3";
            }
            else if (Quarter == 4)
            {
                quater_sum = "Q1 & Q2 & Q3";
                quarter = "Q4";
            }

            //DataTable dtQcLaxmanReport = new DataTable();
            DataSet dsQcLaxmanReport = new DataSet();
            dsQcLaxmanReport = objadmin.GetHeaderLineManSummeryReport();
            DataTable dtQcLaxmanReport = dsQcLaxmanReport.Tables[0];
            int Rows = dtQcLaxmanReport.Rows.Count;
            string str = "";


            if (DateTime.Now.Month.ToString() == "1" || DateTime.Now.Month.ToString() == "4" || DateTime.Now.Month.ToString() == "7" || DateTime.Now.Month.ToString() == "10")
            {
                str = "<table cellpadding='0' cellspacing='0' style='width:500px;' border='0' class='grdproc AddClass_Table'><tr><th colspan='9' style='font-size: 12px !important;border-right:1px solid gray !important;'>Line Man Performance Report </th></tr><tr><th rowspan='2'> Name </th>";
                str = str + "<th colspan='2'> Total CQD Faults</th> <th colspan='2'>CQD INSPN Pass</th><th colspan='2'>QC INSPN Pass</th><th colspan='2' style='border-right:1px solid gray !important;'> % Rescan</th> </tr>";
                str = str + "<tr><th>" + quater_sum + "</th><th>" + DateTime.Now.ToString("MMM") + "</th> <th>" + quater_sum + "</th><th>" + DateTime.Now.ToString("MMM") + "</th><th>" + quater_sum + "</th><th>" + DateTime.Now.ToString("MMM") + "</th><th>" + quater_sum + "</th><th style='border-right:1px solid gray !important;'>" + DateTime.Now.ToString("MMM") + "</th></tr>";
            }
            else
            {
                str = "<table cellpadding='0' cellspacing='0' style='width:650px;' border='1' class='grdproc AddClass_Table'><tr><th colspan='13' style='font-size: 12px !important;border-right:1px solid gray !important;'>Line Man Performance Report </th></tr><tr><th rowspan='2'> Name </th>";
                str = str + "<th colspan='3'> Total CQD Faults</th> <th colspan='3'>CQD INSPN Pass</th><th colspan='3'>QC INSPN Pass</th><th colspan='3' style='border-right:1px solid gray !important;'> % Rescan</th> </tr>";
                str = str + "<tr><th>" + quater_sum + "</th><th>" + quarter + "</th><th>" + DateTime.Now.ToString("MMM") + "</th> <th>" + quater_sum + "</th><th>" + quarter + "</th><th>" + DateTime.Now.ToString("MMM") + "</th><th>" + quater_sum + "</th><th>" + quarter + "</th> <th>" + DateTime.Now.ToString("MMM") + "</th><th>" + quater_sum + "</th><th>" + quarter + "</th><th style='border-right:1px solid gray !important;'>" + DateTime.Now.ToString("MMM") + "</th></tr>";
            }
            //....Value bind in string....
            string T1 = "";
            string T2 = "";
            string T3 = "";
            string C1 = "";
            string C2 = "";
            string C3 = "";
            string I1 = "";
            string I2 = "";
            string I3 = "";
            string Q1 = "";
            string Q2 = "";
            string Q3 = "";
            //End

            int evenrow = 0;
            int oddrow = 1;
            int thirdrow = 2;
            for (int j = 0; j < Rows; j++)
            {
                string ProcessName = dtQcLaxmanReport.Rows[j].ItemArray[0].ToString();
                string[] ProcessFirst = ProcessName.Split('_');

                if (j == evenrow)
                {
                    if (ProcessFirst[3].ToString().Contains("(C 47") && ProcessFirst[0].ToString() != "Average")
                    {
                        str = str + "<tr><td style='color:gray;background:#bfbdbd; text-align:left; width:75px;' rowspan='1'><span style='color:black;font-weight:bold;'>" + ProcessFirst[0] + "</span>&nbsp;<br/>" + ProcessFirst[3] + "</td>";
                    }
                    else if (ProcessFirst[3].ToString().Contains("(D 169") && ProcessFirst[0].ToString() != "Average")
                    {
                        str = str + "<tr><td style='color:gray;background: #FFFFFF;text-align:left; font-size:11px !important;width:75px;' rowspan='1'><span style='color:black;font-weight:bold;'>" + ProcessFirst[0] + "</span>&nbsp;<br/>" + ProcessFirst[3] + "</td>";
                    }
                    else if (ProcessFirst[0].ToString() == "Average")
                    {
                        str = str + "<tr><td style='color:gray;background: #c7d4f5; text-align:left; font-size:11px !important;width:75px;' rowspan='1'><span style='color:black;font-weight:bold;'>" + ProcessFirst[0] + "</span>&nbsp;<br/>" + ProcessFirst[3] + "</td>";
                    }
                    else
                    {
                        str = str + "<tr><td style='color:gray;background: #DDDFE4; text-align:left; font-size:11px !important;width:75px;' rowspan='1'><span style='color:black;font-weight:bold;'>" + ProcessFirst[0] + "</span>&nbsp;<br/>" + ProcessFirst[3] + "</td>";
                    }

                    if (dtQcLaxmanReport.Rows[evenrow].ItemArray[1].ToString() != "")
                    {
                        T1 = Convert.ToInt32(dtQcLaxmanReport.Rows[evenrow].ItemArray[1]).ToString();
                    }
                    else
                    {
                        T1 = "0";
                    }
                    if (dtQcLaxmanReport.Rows[evenrow].ItemArray[2].ToString() != "")
                    {
                        C1 = Convert.ToInt32(dtQcLaxmanReport.Rows[evenrow].ItemArray[2]).ToString();
                    }
                    else
                    {
                        C1 = "0";
                    }
                    if (dtQcLaxmanReport.Rows[evenrow].ItemArray[3].ToString() != "")
                    {
                        I1 = Convert.ToInt32(dtQcLaxmanReport.Rows[evenrow].ItemArray[3]).ToString();
                    }
                    else
                    {
                        I1 = "0";
                    }
                    if (dtQcLaxmanReport.Rows[evenrow].ItemArray[4].ToString() != "")
                    {
                        Q1 = Convert.ToInt32(dtQcLaxmanReport.Rows[evenrow].ItemArray[4]).ToString();
                    }
                    else
                    {
                        Q1 = "0";
                    }

                    evenrow = evenrow + 3;
                }
                //if (oddrow <= Rows)
                if (j == oddrow)
                {
                    if (dtQcLaxmanReport.Rows[oddrow].ItemArray[1].ToString() != "")
                    {
                        T2 = Convert.ToInt32(dtQcLaxmanReport.Rows[oddrow].ItemArray[1]).ToString();
                    }
                    else
                    {
                        T2 = "0";
                    }
                    if (dtQcLaxmanReport.Rows[oddrow].ItemArray[2].ToString() != "")
                    {
                        C2 = Convert.ToInt32(dtQcLaxmanReport.Rows[oddrow].ItemArray[2]).ToString();
                    }
                    else
                    {
                        C2 = "0";
                    }
                    if (dtQcLaxmanReport.Rows[oddrow].ItemArray[3].ToString() != "")
                    {
                        I2 = Convert.ToInt32(dtQcLaxmanReport.Rows[oddrow].ItemArray[3]).ToString();
                    }
                    else
                    {
                        I2 = "0";
                    }
                    if (dtQcLaxmanReport.Rows[oddrow].ItemArray[4].ToString() != "")
                    {
                        Q2 = Convert.ToInt32(dtQcLaxmanReport.Rows[oddrow].ItemArray[4]).ToString();
                    }
                    else
                    {
                        Q2 = "0";
                    }
                    oddrow = oddrow + 3;
                }
                if (j == thirdrow)
                {
                    if (dtQcLaxmanReport.Rows[thirdrow].ItemArray[1].ToString() != "")
                    {
                        T3 = Convert.ToInt32(dtQcLaxmanReport.Rows[thirdrow].ItemArray[1]).ToString();
                    }
                    else
                    {
                        T3 = "0";
                    }
                    if (dtQcLaxmanReport.Rows[thirdrow].ItemArray[2].ToString() != "")
                    {
                        C3 = Convert.ToInt32(dtQcLaxmanReport.Rows[thirdrow].ItemArray[2]).ToString();
                    }
                    else
                    {
                        C3 = "0";
                    }
                    if (dtQcLaxmanReport.Rows[thirdrow].ItemArray[3].ToString() != "")
                    {
                        I3 = Convert.ToInt32(dtQcLaxmanReport.Rows[thirdrow].ItemArray[3]).ToString();
                    }
                    else
                    {
                        I3 = "0";
                    }
                    if (dtQcLaxmanReport.Rows[thirdrow].ItemArray[4].ToString() != "")
                    {
                        Q3 = Convert.ToInt32(dtQcLaxmanReport.Rows[thirdrow].ItemArray[4]).ToString();
                    }
                    else
                    {
                        Q3 = "0";
                    }
                    thirdrow = thirdrow + 3;

                    if (ProcessFirst[0].ToString() == "Average" && ProcessFirst[3].ToString() != "(BIPL)")
                    {
                        //....Start Total....
                        if (Convert.ToInt32(T1) > 12)
                        {
                            T1 = T1 == "0" ? "" : T1 + "%";
                            str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + T1 + "</span></td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(T1) > 10 && Convert.ToInt32(T1) < 13)
                            {
                                T1 = T1 == "0" ? "" : T1 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + T1 + "</span></td>";
                            }
                            else
                            {
                                T1 = T1 == "0" ? "" : T1 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + T1 + "</span></td>";
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(T2) > 12)
                            {
                                T2 = T2 == "0" ? "" : T2 + "%";
                                str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + T2 + "</span></td>";
                            }
                            else
                            {
                                if (Convert.ToInt32(T2) > 10 && Convert.ToInt32(T2) < 13)
                                {
                                    T2 = T2 == "0" ? "" : T2 + "%";
                                    str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + T2 + "</span></td>";
                                }
                                else
                                {
                                    T2 = T2 == "0" ? "" : T2 + "%";
                                    str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + T2 + "</span></td>";
                                }
                            }
                        }
                        if (Convert.ToInt32(T3) > 12)
                        {
                            T3 = T3 == "0" ? "" : T3 + "%";
                            str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + T3 + "</span></td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(T3) > 10 && Convert.ToInt32(T3) < 13)
                            {
                                T3 = T3 == "0" ? "" : T3 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + T3 + "</span></td>";
                            }
                            else
                            {
                                T3 = T3 == "0" ? "" : T3 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + T3 + "</span></td>";
                            }
                        }

                        //....Start COD....
                        if (Convert.ToInt32(C1) < 80)
                        {
                            C1 = C1 == "0" ? "" : C1 + "%";
                            str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + C1 + "</span> </td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(C1) > 79 && Convert.ToInt32(C1) < 91)
                            {
                                C1 = C1 == "0" ? "" : C1 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + C1 + "</span></td>";
                            }
                            else
                            {
                                C1 = C1 == "0" ? "" : C1 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + C1 + "</span></td>";
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(C2) < 80)
                            {
                                C2 = C2 == "0" ? "" : C2 + "%";
                                str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + C2 + "</span> </td>";
                            }
                            else
                            {
                                if (Convert.ToInt32(C2) > 79 && Convert.ToInt32(C2) < 91)
                                {
                                    C2 = C2 == "0" ? "" : C2 + "%";
                                    str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + C2 + "</span></td>";
                                }
                                else
                                {
                                    C2 = C2 == "0" ? "" : C2 + "%";
                                    str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + C2 + "</span></td>";
                                }
                            }
                        }
                        if (Convert.ToInt32(C3) < 80)
                        {
                            C3 = C3 == "0" ? "" : C3 + "%";
                            str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + C3 + "</span> </td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(C3) > 79 && Convert.ToInt32(C3) < 91)
                            {
                                C3 = C3 == "0" ? "" : C3 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + C3 + "</span></td>";
                            }
                            else
                            {
                                C3 = C3 == "0" ? "" : C3 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + C3 + "</span></td>";
                            }
                        }

                        //....Start QC....
                        if (Convert.ToInt32(I1) < 80)
                        {
                            I1 = I1 == "0" ? "" : I1 + "%";
                            str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + I1 + "</span></td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(I1) > 79 && Convert.ToInt32(I1) < 91)
                            {
                                I1 = I1 == "0" ? "" : I1 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + I1 + "</span></td>";
                            }
                            else
                            {
                                I1 = I1 == "0" ? "" : I1 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + I1 + "</span></td>";
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(I2) < 80)
                            {
                                I2 = I2 == "0" ? "" : I2 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + I2 + "</span></td>";
                            }
                            else
                            {
                                if (Convert.ToInt32(I2) > 79 && Convert.ToInt32(I2) < 91)
                                {
                                    I2 = I2 == "0" ? "" : I2 + "%";
                                    str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + I2 + "</span></td>";
                                }
                                else
                                {
                                    I2 = I2 == "0" ? "" : I2 + "%";
                                    str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + I2 + "</span></td>";
                                }
                            }
                        }
                        if (Convert.ToInt32(I3) < 80)
                        {
                            I3 = I3 == "0" ? "" : I3 + "%";
                            str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + I3 + "</span></td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(I3) > 79 && Convert.ToInt32(I3) < 91)
                            {
                                I3 = I3 == "0" ? "" : I3 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + I3 + "</span></td>";
                            }
                            else
                            {
                                I3 = I3 == "0" ? "" : I3 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + I3 + "</span></td>";
                            }
                        }

                        //....Start Rescan....
                        if (Convert.ToInt32(Q1) < 6)
                        {
                            Q1 = Q1 == "0" ? "" : Q1 + "%";
                            str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + Q1 + "</span> </td>";
                            //str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q1 + "</span> </td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(Q1) > 5 && Convert.ToInt32(Q1) < 11)
                            {
                                Q1 = Q1 == "0" ? "" : Q1 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + Q1 + "</span></td>";
                                //str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q1 + "</span> </td>";
                            }
                            else
                            {
                                Q1 = Q1 == "0" ? "" : Q1 + "%";
                                str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + Q1 + "</span></td>";
                                //str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q1 + "</span> </td>";
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(Q2) < 6)
                            {
                                Q2 = Q2 == "0" ? "" : Q2 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + Q2 + "</span> </td>";
                                //str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q2 + "</span> </td>";
                            }
                            else
                            {
                                if (Convert.ToInt32(Q2) > 5 && Convert.ToInt32(Q2) < 11)
                                {
                                    Q2 = Q2 == "0" ? "" : Q2 + "%";
                                    str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + Q2 + "</span></td>";
                                    //str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q2 + "</span> </td>";
                                }
                                else
                                {
                                    Q2 = Q2 == "0" ? "" : Q2 + "%";
                                    str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;' class='f-14px'><span style='color:red;font-size:12px !important; font-weight:bold;'>" + Q2 + "</span></td>";
                                    //str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q2 + "</span> </td>";
                                }
                            }
                        }
                        if (Convert.ToInt32(Q3) < 6)
                        {
                            Q3 = Q3 == "0" ? "" : Q3 + "%";
                            str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + Q3 + "</span> </td>";
                            //str = str + "<td style='width:50px; height:16px;'><span style='color:black;font-size:12px !important; font-weight:bold;text-align: center'>" + Q3 + "</span> </td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(Q3) > 5 && Convert.ToInt32(Q3) < 11)
                            {
                                Q3 = Q3 == "0" ? "" : Q3 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + Q3 + "</span></td>";
                                //str = str + "<td style='width:50px; height:16px;'><span style='color:black;font-size:12px !important; font-weight:bold;text-align: center'>" + Q3 + "</span> </td>";
                            }
                            else
                            {
                                Q3 = Q3 == "0" ? "" : Q3 + "%";
                                str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;' class='f-14px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + Q3 + "</span></td>";
                                //str = str + "<td style='width:50px; height:16px;'><span style='color:black;font-size:12px !important; font-weight:bold;text-align: center'>" + Q3 + "</span> </td>";
                            }
                        }
                    }
                    else if (ProcessFirst[0].ToString() == "Average" && ProcessFirst[3].ToString() == "(BIPL)")
                    {
                        //....Start Total....
                        if (Convert.ToInt32(T1) > 12)
                        {
                            T1 = T1 == "0" ? "" : T1 + "%";
                            str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + T1 + "</span></td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(T1) > 10 && Convert.ToInt32(T1) < 13)
                            {
                                T1 = T1 == "0" ? "" : T1 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + T1 + "</span></td>";
                            }
                            else
                            {
                                T1 = T1 == "0" ? "" : T1 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + T1 + "</span></td>";
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(T2) > 12)
                            {
                                T2 = T2 == "0" ? "" : T2 + "%";
                                str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + T2 + "</span></td>";
                            }
                            else
                            {
                                if (Convert.ToInt32(T2) > 10 && Convert.ToInt32(T2) < 13)
                                {
                                    T2 = T2 == "0" ? "" : T2 + "%";
                                    str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + T2 + "</span></td>";
                                }
                                else
                                {
                                    T2 = T2 == "0" ? "" : T2 + "%";
                                    str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + T2 + "</span></td>";
                                }
                            }
                        }
                        if (Convert.ToInt32(T3) > 12)
                        {
                            T3 = T3 == "0" ? "" : T3 + "%";
                            str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + T3 + "</span></td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(T3) > 10 && Convert.ToInt32(T3) < 13)
                            {
                                T3 = T3 == "0" ? "" : T3 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + T3 + "</span></td>";
                            }
                            else
                            {
                                T3 = T3 == "0" ? "" : T3 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + T3 + "</span></td>";
                            }
                        }

                        //....Start COD....
                        if (Convert.ToInt32(C1) < 80)
                        {
                            C1 = C1 == "0" ? "" : C1 + "%";
                            str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + C1 + "</span> </td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(C1) > 79 && Convert.ToInt32(C1) < 91)
                            {
                                C1 = C1 == "0" ? "" : C1 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + C1 + "</span></td>";
                            }
                            else
                            {
                                C1 = C1 == "0" ? "" : C1 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + C1 + "</span></td>";
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(C2) < 80)
                            {
                                C2 = C2 == "0" ? "" : C2 + "%";
                                str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + C2 + "</span> </td>";
                            }
                            else
                            {
                                if (Convert.ToInt32(C2) > 79 && Convert.ToInt32(C2) < 91)
                                {
                                    C2 = C2 == "0" ? "" : C2 + "%";
                                    str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + C2 + "</span></td>";
                                }
                                else
                                {
                                    C2 = C2 == "0" ? "" : C2 + "%";
                                    str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + C2 + "</span></td>";
                                }
                            }
                        }
                        if (Convert.ToInt32(C3) < 80)
                        {
                            C3 = C3 == "0" ? "" : C3 + "%";
                            str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + C3 + "</span> </td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(C3) > 79 && Convert.ToInt32(C3) < 91)
                            {
                                C3 = C3 == "0" ? "" : C3 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + C3 + "</span></td>";
                            }
                            else
                            {
                                C3 = C3 == "0" ? "" : C3 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + C3 + "</span></td>";
                            }
                        }

                        //....Start QC....
                        if (Convert.ToInt32(I1) < 80)
                        {
                            I1 = I1 == "0" ? "" : I1 + "%";
                            str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + I1 + "</span></td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(I1) > 79 && Convert.ToInt32(I1) < 91)
                            {
                                I1 = I1 == "0" ? "" : I1 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + I1 + "</span></td>";
                            }
                            else
                            {
                                I1 = I1 == "0" ? "" : I1 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + I1 + "</span></td>";
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(I2) < 80)
                            {
                                I2 = I2 == "0" ? "" : I2 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + I2 + "</span></td>";
                            }
                            else
                            {
                                if (Convert.ToInt32(I2) > 79 && Convert.ToInt32(I2) < 91)
                                {
                                    I2 = I2 == "0" ? "" : I2 + "%";
                                    str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + I2 + "</span></td>";
                                }
                                else
                                {
                                    I2 = I2 == "0" ? "" : I2 + "%";
                                    str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + I2 + "</span></td>";
                                }
                            }
                        }
                        if (Convert.ToInt32(I3) < 80)
                        {
                            I3 = I3 == "0" ? "" : I3 + "%";
                            str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + I3 + "</span></td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(I3) > 79 && Convert.ToInt32(I3) < 91)
                            {
                                I3 = I3 == "0" ? "" : I3 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + I3 + "</span></td>";
                            }
                            else
                            {
                                I3 = I3 == "0" ? "" : I3 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;text-align: center' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + I3 + "</span></td>";
                            }
                        }

                        //....Start Rescan....
                        if (Convert.ToInt32(Q1) < 6)
                        {
                            Q1 = Q1 == "0" ? "" : Q1 + "%";
                            str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + Q1 + "</span> </td>";
                            //str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q1 + "</span> </td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(Q1) > 5 && Convert.ToInt32(Q1) < 11)
                            {
                                Q1 = Q1 == "0" ? "" : Q1 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + Q1 + "</span></td>";
                                //str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q1 + "</span> </td>";
                            }
                            else
                            {
                                Q1 = Q1 == "0" ? "" : Q1 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + Q1 + "</span></td>";
                                //str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q1 + "</span> </td>";
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(Q2) < 6)
                            {
                                Q2 = Q2 == "0" ? "" : Q2 + "%";
                                str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + Q2 + "</span> </td>";
                                //str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q2 + "</span> </td>";
                            }
                            else
                            {
                                if (Convert.ToInt32(Q2) > 5 && Convert.ToInt32(Q2) < 11)
                                {
                                    Q2 = Q2 == "0" ? "" : Q2 + "%";
                                    str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + Q2 + "</span></td>";
                                    //str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q2 + "</span> </td>";
                                }
                                else
                                {
                                    Q2 = Q2 == "0" ? "" : Q2 + "%";
                                    str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + Q2 + "</span></td>";
                                    //str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q2 + "</span> </td>";
                                }
                            }
                        }
                        if (Convert.ToInt32(Q3) < 6)
                        {
                            Q3 = Q3 == "0" ? "" : Q3 + "%";
                            str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + Q3 + "</span> </td>";
                            //str = str + "<td style='width:50px; height:16px;'><span style='color:black;font-size:12px !important; font-weight:bold;text-align: center'>" + Q3 + "</span> </td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(Q3) > 5 && Convert.ToInt32(Q3) < 11)
                            {
                                Q3 = Q3 == "0" ? "" : Q3 + "%";
                                str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:normal;'>" + Q3 + "</span></td>";
                                //str = str + "<td style='width:50px; height:16px;'><span style='color:black;font-size:12px !important; font-weight:bold;text-align: center'>" + Q3 + "</span> </td>";
                            }
                            else
                            {
                                Q3 = Q3 == "0" ? "" : Q3 + "%";
                                str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;' class='f-16px'><span style='color:yellow;font-size:12px !important; font-weight:bold;'>" + Q3 + "</span></td>";
                                //str = str + "<td style='width:50px; height:16px;'><span style='color:black;font-size:12px !important; font-weight:bold;text-align: center'>" + Q3 + "</span> </td>";
                            }
                        }
                    }
                    else
                    {
                        //....Start Total....
                        if (Convert.ToInt32(T1) > 12)
                        {
                            T1 = T1 == "0" ? "" : T1 + "%";
                            str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:red;font-size:12px !important; font-weight:bold;'>" + T1 + "</span></td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(T1) > 10 && Convert.ToInt32(T1) < 13)
                            {
                                T1 = T1 == "0" ? "" : T1 + "%";
                                str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:#000;font-size:12px !important; font-weight:normal;'>" + T1 + "</span></td>";
                            }
                            else
                            {
                                T1 = T1 == "0" ? "" : T1 + "%";
                                str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:green;font-size:12px !important; font-weight:normal;'>" + T1 + "</span></td>";
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(T2) > 12)
                            {
                                T2 = T2 == "0" ? "" : T2 + "%";
                                str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:red;font-size:12px !important; font-weight:bold;'>" + T2 + "</span></td>";
                            }
                            else
                            {
                                if (Convert.ToInt32(T2) > 10 && Convert.ToInt32(T2) < 13)
                                {
                                    T2 = T2 == "0" ? "" : T2 + "%";
                                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:#000;font-size:12px !important; font-weight:normal;'>" + T2 + "</span></td>";
                                }
                                else
                                {
                                    T2 = T2 == "0" ? "" : T2 + "%";
                                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:green;font-size:12px !important; font-weight:normal;'>" + T2 + "</span></td>";
                                }
                            }
                        }
                        if (Convert.ToInt32(T3) > 12)
                        {
                            T3 = T3 == "0" ? "" : T3 + "%";
                            str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:red;font-size:12px !important; font-weight:bold;'>" + T3 + "</span></td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(T3) > 10 && Convert.ToInt32(T3) < 13)
                            {
                                T3 = T3 == "0" ? "" : T3 + "%";
                                str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:#000;font-size:12px !important; font-weight:normal;'>" + T3 + "</span></td>";
                            }
                            else
                            {
                                T3 = T3 == "0" ? "" : T3 + "%";
                                str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:green;font-size:12px !important; font-weight:normal;'>" + T3 + "</span></td>";
                            }
                        }

                        //....Start COD....
                        if (Convert.ToInt32(C1) < 80)
                        {
                            C1 = C1 == "0" ? "" : C1 + "%";
                            str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:red;font-size:12px !important; font-weight:bold;'>" + C1 + "</span> </td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(C1) > 79 && Convert.ToInt32(C1) < 91)
                            {
                                C1 = C1 == "0" ? "" : C1 + "%";
                                str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:#000;font-size:12px !important; font-weight:normal;'>" + C1 + "</span></td>";
                            }
                            else
                            {
                                C1 = C1 == "0" ? "" : C1 + "%";
                                str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:green;font-size:12px !important; font-weight:normal;'>" + C1 + "</span></td>";
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(C2) < 80)
                            {
                                C2 = C2 == "0" ? "" : C2 + "%";
                                str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:red;font-size:12px !important; font-weight:bold;'>" + C2 + "</span> </td>";
                            }
                            else
                            {
                                if (Convert.ToInt32(C2) > 79 && Convert.ToInt32(C2) < 91)
                                {
                                    C2 = C2 == "0" ? "" : C2 + "%";
                                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:#000;font-size:12px !important; font-weight:normal;'>" + C2 + "</span></td>";
                                }
                                else
                                {
                                    C2 = C2 == "0" ? "" : C2 + "%";
                                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:green;font-size:12px !important; font-weight:normal;'>" + C2 + "</span></td>";
                                }
                            }
                        }
                        if (Convert.ToInt32(C3) < 80)
                        {
                            C3 = C3 == "0" ? "" : C3 + "%";
                            str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:red;font-size:12px !important; font-weight:bold;'>" + C3 + "</span> </td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(C3) > 79 && Convert.ToInt32(C3) < 91)
                            {
                                C3 = C3 == "0" ? "" : C3 + "%";
                                str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:#000;font-size:12px !important; font-weight:normal;'>" + C3 + "</span></td>";
                            }
                            else
                            {
                                C3 = C3 == "0" ? "" : C3 + "%";
                                str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:green;font-size:12px !important; font-weight:normal;'>" + C3 + "</span></td>";
                            }
                        }

                        //....Start QC....
                        if (Convert.ToInt32(I1) < 80)
                        {
                            I1 = I1 == "0" ? "" : I1 + "%";
                            str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:green;font-size:12px !important; font-weight:normal;'>" + I1 + "</span></td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(I1) > 79 && Convert.ToInt32(I1) < 91)
                            {
                                I1 = I1 == "0" ? "" : I1 + "%";
                                str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:#000;font-size:12px !important; font-weight:normal;'>" + I1 + "</span></td>";
                            }
                            else
                            {
                                I1 = I1 == "0" ? "" : I1 + "%";
                                str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:green;font-size:12px !important; font-weight:normal;'>" + I1 + "</span></td>";
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(I2) < 80)
                            {
                                I2 = I2 == "0" ? "" : I2 + "%";
                                str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:green;font-size:12px !important; font-weight:normal;'>" + I2 + "</span></td>";
                            }
                            else
                            {
                                if (Convert.ToInt32(I2) > 79 && Convert.ToInt32(I2) < 91)
                                {
                                    I2 = I2 == "0" ? "" : I2 + "%";
                                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:#000;font-size:12px !important; font-weight:normal;'>" + I2 + "</span></td>";
                                }
                                else
                                {
                                    I2 = I2 == "0" ? "" : I2 + "%";
                                    str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:green;font-size:12px !important; font-weight:normal;'>" + I2 + "</span></td>";
                                }
                            }
                        }
                        if (Convert.ToInt32(I3) < 80)
                        {
                            I3 = I3 == "0" ? "" : I3 + "%";
                            str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:green;font-size:12px !important; font-weight:normal;'>" + I3 + "</span></td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(I3) > 79 && Convert.ToInt32(I3) < 91)
                            {
                                I3 = I3 == "0" ? "" : I3 + "%";
                                str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:#000;font-size:12px !important; font-weight:normal;'>" + I3 + "</span></td>";
                            }
                            else
                            {
                                I3 = I3 == "0" ? "" : I3 + "%";
                                str = str + "<td style='width:50px;height:16px;font-size:12px !important;text-align: center' ><span style='color:green;font-size:12px !important; font-weight:normal;'>" + I3 + "</span></td>";
                            }
                        }

                        //....Start Rescan....
                        if (Convert.ToInt32(Q1) < 6)
                        {
                            Q1 = Q1 == "0" ? "" : Q1 + "%";
                            //str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;' ><span style='color:Yellow;font-size:12px !important; font-weight:bold;'>" + Q1 + "</span> </td>";
                            str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q1 + "</span> </td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(Q1) > 5 && Convert.ToInt32(Q1) < 11)
                            {
                                Q1 = Q1 == "0" ? "" : Q1 + "%";
                                //str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;' ><span style='color:Yellow;font-size:12px !important; font-weight:bold;'>" + Q1 + "</span></td>";
                                str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q1 + "</span> </td>";
                            }
                            else
                            {
                                Q1 = Q1 == "0" ? "" : Q1 + "%";
                                //str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;' ><span style='color:Yellow;font-size:12px !important; font-weight:bold;'>" + Q1 + "</span></td>";
                                str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q1 + "</span> </td>";
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(Q2) < 6)
                            {
                                Q2 = Q2 == "0" ? "" : Q2 + "%";
                                //str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;' ><span style='color:Yellow;font-size:12px !important; font-weight:bold;'>" + Q2 + "</span> </td>";
                                str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q2 + "</span> </td>";
                            }
                            else
                            {
                                if (Convert.ToInt32(Q2) > 5 && Convert.ToInt32(Q2) < 11)
                                {
                                    Q2 = Q2 == "0" ? "" : Q2 + "%";
                                    //str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;' ><span style='color:Yellow;font-size:12px !important; font-weight:bold;'>" + Q2 + "</span></td>";
                                    str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q2 + "</span> </td>";
                                }
                                else
                                {
                                    Q2 = Q2 == "0" ? "" : Q2 + "%";
                                    //str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;' ><span style='color:Yellow;font-size:12px !important; font-weight:bold;'>" + Q2 + "</span></td>";
                                    str = str + "<td style='width:50px; height:16px;'><span style='color:black;text-align: center'>" + Q2 + "</span> </td>";
                                }
                            }
                        }
                        if (Convert.ToInt32(Q3) < 6)
                        {
                            Q3 = Q3 == "0" ? "" : Q3 + "%";
                            //str = str + "<td style='background:green;width:50px;height:16px;font-size:12px !important;' ><span style='color:Yellow;font-size:12px !important; font-weight:bold;'>" + Q3 + "</span> </td>";
                            str = str + "<td style='width:50px; height:16px;'><span style='color:black;font-size:12px !important; font-weight:bold;text-align: center'>" + Q3 + "</span> </td>";
                        }
                        else
                        {
                            if (Convert.ToInt32(Q3) > 5 && Convert.ToInt32(Q3) < 11)
                            {
                                Q3 = Q3 == "0" ? "" : Q3 + "%";
                                //str = str + "<td style='background:orange;width:50px;height:16px;font-size:12px !important;' ><span style='color:Yellow;font-size:12px !important; font-weight:bold;'>" + Q3 + "</span></td>";
                                str = str + "<td style='width:50px; height:16px;'><span style='color:black;font-size:12px !important; font-weight:bold;text-align: center'>" + Q3 + "</span> </td>";
                            }
                            else
                            {
                                Q3 = Q3 == "0" ? "" : Q3 + "%";
                                //str = str + "<td style='background:red;width:50px;height:16px;font-size:12px !important;' ><span style='color:Yellow;font-size:12px !important; font-weight:bold;'>" + Q3 + "</span></td>";
                                str = str + "<td style='width:50px; height:16px;'><span style='color:black;font-size:12px !important; font-weight:bold;text-align: center'>" + Q3 + "</span> </td>";
                            }
                        }
                    }

                    str = str + "</tr>";
                }

            }
            //str = str + "<tr><td colspan='13'><strong>Note:-</strong> Pressing Standards (Pass)- Pr. St., Ndl Plcy- Ndl. P., SPI & Metal Dt. (Pass)- SPI Metal DT., Signed R&D- R&D, L-Man Pc (Pass)- L-Man PC</td>";

            str = str + "</table>";
            frmLineMansummeryReport.InnerHtml = str;
        }
    }
}