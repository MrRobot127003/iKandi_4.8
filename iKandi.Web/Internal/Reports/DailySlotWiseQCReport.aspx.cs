using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;
using iKandi.Web.Components;

namespace iKandi.Web.Internal.Reports
{
    public partial class DailySlotWiseQCReport : System.Web.UI.Page
    {
        AdminController objAdminController = new AdminController();
        int CurrentLoggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            DateTime QCDate;
            //txtQCDate.Text = DateTime.Now.ToString("dd-MMM-yyy,ddd");
            if (txtQCDate.Text != "")
            {
                QCDate = DateTime.ParseExact(txtQCDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                QCDate = DateTime.Now;
                txtQCDate.Text = QCDate.ToString("dd MMM yy (ddd)");
            }

            if (!IsPostBack)
            {               
                bindSlotWiseQCgrd(QCDate);
            }
        }
        DataTable QCReport;
        public void bindSlotWiseQCgrd(DateTime QCDate)
        {
            DataSet ds = objAdminController.GetSloWiseQCReport(QCDate);
            QCReport = new DataTable();
            QCReport = ds.Tables[0];
            int Rows = QCReport.Rows.Count;
            string str = "";
            if (Rows > 0)
            {
                str = "<table cellpadding='0' cellspacing='0' style='width:100%;' border='1' padding-top:6px;padding-bottom:6px '> <tr style='background:#bfbdbd'><th  style='font-size: 12px !important;border-right:1px solid gray !important;'>QC Name</th><th  style='font-size: 12px !important;border-right:1px solid gray !important;'>S1</th><th  style='font-size: 12px !important;border-right:1px solid gray !important;'>S2</th><th  style='font-size: 12px !important;border-right:1px solid gray !important;'>S3</th><th  style='font-size: 12px !important;border-right:1px solid gray !important;'>S4</th><th  style='font-size: 12px !important;border-right:1px solid gray !important;'>S5</th><th  style='font-size: 12px !important;border-right:1px solid gray !important;'>S6</th><th  style='font-size: 12px !important;border-right:1px solid gray !important;'>S7</th><th  style='font-size: 12px !important;border-right:1px solid gray !important;'>S8</th><th  style='font-size: 12px !important;border-right:1px solid gray !important;'>S9</th><th  style='font-size: 12px !important;border-right:1px solid gray !important;'>S10</th><th  style='font-size: 12px !important;border-right:1px solid gray !important;'>S11</th><th  style='font-size: 12px !important;border-right:1px solid gray !important;'>S12</th><th  style='font-size: 12px !important;border-right:1px solid gray !important;'>Total</th></tr>";

                for (int j = 0; j < Rows; j++)
                {
                    if (QCReport.Rows[j]["QCName"].ToString() != "")
                    {
                        if (QCReport.Rows[j]["UnitId"].ToString() == "3")
                        {
                            str = str + "<tr><td style='color:gray;background:#FCF6F6; text-align:left; width:120px;' rowspan='1'><span style='color:black;font-weight:bold;'>" + QCReport.Rows[j]["QCName"].ToString() +
                                "</span>&nbsp;<br/><span style='font-size:10px; color:#2b2a2ae6;'>" + QCReport.Rows[j]["QCDesignation"].ToString() + "</span></td>";
                        }
                        else if (QCReport.Rows[j]["UnitId"].ToString() == "11")
                        {
                            str = str + "<tr><td style='color:gray;background:#E9F4F7; text-align:left; width:120px;' rowspan='1'><span style='color:black;font-weight:bold;'>" + QCReport.Rows[j]["QCName"].ToString() +
                                "</span>&nbsp;<br/><span style='font-size:10px; color:#2b2a2ae6;'>" + QCReport.Rows[j]["QCDesignation"].ToString() + "</span></td>";
                        }
                        else if (QCReport.Rows[j]["UnitId"].ToString() == "96")
                        {
                            str = str + "<tr><td style='color:gray;background:#F2F2E2; text-align:left; width:120px;' rowspan='1'><span style='color:black;font-weight:bold;'>" + QCReport.Rows[j]["QCName"].ToString() +
                                "</span>&nbsp;<br/><span style='font-size:10px; color:#2b2a2ae6;'>" + QCReport.Rows[j]["QCDesignation"].ToString() + "</span></td>";
                        }
                        else if (QCReport.Rows[j]["UnitId"].ToString() == "120")
                        {
                            str = str + "<tr><td style='color:gray;background:#D5F7EB; text-align:left; width:120px;' rowspan='1'><span style='color:black;font-weight:bold;'>" + QCReport.Rows[j]["QCName"].ToString() +
                                "</span>&nbsp;<br/><span style='font-size:10px; color:#2b2a2ae6;'>" + QCReport.Rows[j]["QCDesignation"].ToString() + "</span></td>";
                        }
                    }
                    if (QCReport.Rows[j]["Slot1"].ToString() != "")
                    {
                        string slot1 = QCReport.Rows[j]["Slot1"].ToString();
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:black;font-size:11px !important; '>" + slot1 + "</span></td>";
                    }
                    else
                    {
                        string slot1 = QCReport.Rows[j]["Slot1"].ToString();
                        slot1 = slot1 == "" ? "-" : slot1;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:#99003d;font-size:11px !important; '>" + slot1 + "</span></td>";
                    }
                    if (QCReport.Rows[j]["Slot2"].ToString() != "")
                    {
                        string slot2 = QCReport.Rows[j]["Slot2"].ToString();
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:black;font-size:11px !important; '>" + slot2 + "</span></td>";
                    }
                    else
                    {
                        string slot2 = QCReport.Rows[j]["Slot2"].ToString();
                        slot2 = slot2 == "" ? "-" : slot2;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:#99003d;font-size:11px !important; '>" + slot2 + "</span></td>";
                    }
                    if (QCReport.Rows[j]["Slot3"].ToString() != "")
                    {
                        string slot3 = QCReport.Rows[j]["Slot3"].ToString();
                        slot3 = slot3 == "" ? "-" : slot3;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:black;font-size:11px !important; '>" + slot3 + "</span></td>";
                    }
                    else
                    {
                        string slot3 = QCReport.Rows[j]["Slot3"].ToString();
                        slot3 = slot3 == "" ? "-" : slot3;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:#99003d;font-size:11px !important; '>" + slot3 + "</span></td>";
                    }
                    if (QCReport.Rows[j]["Slot4"].ToString() != "")
                    {
                        string slot4 = QCReport.Rows[j]["Slot4"].ToString();
                        slot4 = slot4 == "" ? "-" : slot4;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:black;font-size:11px !important; '>" + slot4 + "</span></td>";
                    }
                    else
                    {
                        string slot4 = QCReport.Rows[j]["Slot4"].ToString();
                        slot4 = slot4 == "" ? "-" : slot4;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:#99003d;font-size:11px !important; '>" + slot4 + "</span></td>";
                    }
                    if (QCReport.Rows[j]["Slot5"].ToString() != "")
                    {
                        string slot5 = QCReport.Rows[j]["Slot5"].ToString();
                        slot5 = slot5 == "" ? "-" : slot5;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:black;font-size:11px !important; '>" + slot5 + "</span></td>";
                    }
                    else
                    {
                        string slot5 = QCReport.Rows[j]["Slot5"].ToString();
                        slot5 = slot5 == "" ? "-" : slot5;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:#99003d;font-size:11px !important; '>" + slot5 + "</span></td>";
                    }
                    if (QCReport.Rows[j]["Slot6"].ToString() != "")
                    {
                        string slot6 = QCReport.Rows[j]["Slot6"].ToString();
                        slot6 = slot6 == "" ? "-" : slot6;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:black;font-size:11px !important; '>" + slot6 + "</span></td>";
                    }
                    else
                    {
                        string slot6 = QCReport.Rows[j]["Slot6"].ToString();
                        slot6 = slot6 == "" ? "-" : slot6;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:#99003d;font-size:11px !important; '>" + slot6 + "</span></td>";
                    }
                    if (QCReport.Rows[j]["Slot7"].ToString() != "")
                    {
                        string slot7 = QCReport.Rows[j]["Slot7"].ToString();
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:black;font-size:11px !important; '>" + slot7 + "</span></td>";
                    }
                    else
                    {
                        string slot7 = QCReport.Rows[j]["Slot7"].ToString();
                        slot7 = slot7 == "" ? "-" : slot7;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:#99003d;font-size:11px !important; '>" + slot7 + "</span></td>";
                    }
                    if (QCReport.Rows[j]["Slot8"].ToString() != "")
                    {
                        string slot8 = QCReport.Rows[j]["Slot8"].ToString();
                        slot8 = slot8 == "" ? "-" : slot8;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:black;font-size:11px !important; '>" + slot8 + "</span></td>";
                    }
                    else
                    {
                        string slot8 = QCReport.Rows[j]["Slot8"].ToString();
                        slot8 = slot8 == "" ? "-" : slot8;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:#99003d;font-size:11px !important; '>" + slot8 + "</span></td>";
                    }
                    if (QCReport.Rows[j]["Slot9"].ToString() != "")
                    {
                        string slot9 = QCReport.Rows[j]["Slot9"].ToString();
                        slot9 = slot9 == "" ? "-" : slot9;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:black;font-size:11px !important; '>" + slot9 + "</span></td>";
                    }
                    else
                    {
                        string slot9 = QCReport.Rows[j]["Slot9"].ToString();
                        slot9 = slot9 == "" ? "-" : slot9;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:#99003d;font-size:11px !important; '>" + slot9 + "</span></td>";
                    }
                    if (QCReport.Rows[j]["Slot10"].ToString() != "")
                    {
                        string slot10 = QCReport.Rows[j]["Slot10"].ToString();
                        slot10 = slot10 == "" ? "-" : slot10;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:black;font-size:11px !important; '>" + slot10 + "</span></td>";
                    }
                    else
                    {
                        string slot10 = QCReport.Rows[j]["Slot10"].ToString();
                        slot10 = slot10 == "" ? "-" : slot10;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:#99003d;font-size:11px !important; '>" + slot10 + "</span></td>";
                    }
                    if (QCReport.Rows[j]["Slot11"].ToString() != "")
                    {
                        string slot11 = QCReport.Rows[j]["Slot11"].ToString();
                        slot11 = slot11 == "" ? "-" : slot11;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:black;font-size:11px !important; '>" + slot11 + "</span></td>";
                    }
                    else
                    {
                        string slot11 = QCReport.Rows[j]["Slot11"].ToString();
                        slot11 = slot11 == "" ? "-" : slot11;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:#99003d;font-size:11px !important; '>" + slot11 + "</span></td>";
                    }
                    if (QCReport.Rows[j]["Slot12"].ToString() != "")
                    {
                        string slot12 = QCReport.Rows[j]["Slot12"].ToString();
                        slot12 = slot12 == "" ? "-" : slot12;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:black;font-size:11px !important; '>" + slot12 + "</span></td>";
                    }
                    else
                    {
                        string slot12 = QCReport.Rows[j]["Slot12"].ToString();
                        slot12 = slot12 == "" ? "-" : slot12;
                        str = str + "<td style=';width:20px;height:16px;font-size:11px !important;text-align: center'><span style='color:#99003d;font-size:11px !important; '>" + slot12 + "</span></td>";
                    }
                    if (QCReport.Rows[j]["Total"].ToString() != "")
                    {
                        string Total = QCReport.Rows[j]["Total"].ToString();
                        Total = Total == "" ? "-" : Total;
                        str = str + "<td style='width:30px;height:16px;font-size:11px !important;text-align: center'><span style='color:black;font-size:11px !important; font-weight:bold;'>" + Total + "</span></td>";
                    }
                    else
                    {
                        string Total = QCReport.Rows[j]["Total"].ToString();
                        Total = Total == "" ? "-" : Total;
                        str = str + "<td style='width:30px;height:16px;font-size:11px !important;text-align: center'><span style='color:black;font-size:11px !important; font-weight:bold;'>" + Total + "</span></td>";
                    }
                    str = str + "</tr>";
                }
                str = str + "</table>";
            }
            else
            {
                str = "<span style='color:red; font-size:13px !important;'>Data not available for this date!</span>";
            }
            frmQCReport.InnerHtml = str;
            
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            DateTime QCDate = DateTime.ParseExact(txtQCDate.Text, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture);
            bindSlotWiseQCgrd(QCDate);            
        }
    }
}