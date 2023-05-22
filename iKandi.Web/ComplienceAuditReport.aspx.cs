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
using System.Web.Services;


namespace iKandi.Web
{
    public partial class ComplienceAuditReport : System.Web.UI.Page
    {
        int UnitId;
        int processType;        
        AdminController objadmin = new AdminController();
        string failname;
        string dateSelect;// = DateTime.Now.ToString("dd MMM yy");
        string floornull="Inhouse";
        bool bOpenFromLink = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UnitId"] != null)
            {
                UnitId = Convert.ToInt32(Request.QueryString["UnitId"].ToString());
                Session["UnitId"] = UnitId;
            }
            if (Request.QueryString["ProcessType"] != null)
            {
                processType = Convert.ToInt32(Request.QueryString["ProcessType"].ToString());
                Session["ProcessType"] = processType;
            }
            if (!IsPostBack)
            {
                BindTableProductQCpt();
              
            }
        }
        protected void BindTableProductQCpt()
        {
            string remarks = "";
            int PassFail = 5;           
            int countFail;
            DataSet dsvalue = new DataSet();
            DataSet resultValue = new DataSet();
            DataSet dsProductQCpt = new DataSet();
            dsProductQCpt = objadmin.GetProductOccupationalAudit(UnitId, processType);
            DataTable dtProductQCptProcess = dsProductQCpt.Tables[0];
            DataTable dtProductQCptLine = dsProductQCpt.Tables[1];
            DataTable dtProductQCptTypeAdmin = dsProductQCpt.Tables[2];
            DataTable dtProductQCptCluster = dsProductQCpt.Tables[3];

            DataTable dtUnitName = dsProductQCpt.Tables[4];
            DataTable dtOutHouseFactory = dsProductQCpt.Tables[5];
            int OutHouseFactory = dtOutHouseFactory.Rows.Count;

            dateSelect = Convert.ToDateTime(dtUnitName.Rows[0]["ReportDate"]).ToString("dd MMM yy");

            int LineNo = dtProductQCptLine.Rows.Count;
            string ImageFile = "";
            int TypeAdmin = dtProductQCptTypeAdmin.Rows.Count;
            int ClusterCount = dtProductQCptCluster.Rows.Count;
            int QCptProcess = dtProductQCptProcess.Rows.Count;
            int columnSpan;
            if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
            {
                columnSpan = OutHouseFactory + 1;
            }
            else
            {
                columnSpan = LineNo + TypeAdmin + ClusterCount + 1;
            }
            int width = 350 + LineNo * 60 + TypeAdmin * 60 + ClusterCount * 60;

            string str = "";
            if (QCptProcess > 0)
            {
                if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
                {
                    width = 350 + OutHouseFactory * 70;
                    lblProcessName.Text = "Out House Audit Report";
                    mainhead.Attributes.Add("style", "width:" + width + "px");
                    str = "<table cellpadding='0' cellspacing='0' style='width:" + width + "px; margin:0px auto;' border='1' class='item_list1'><tr><th>Product/ Occupational Safety (<span style='color:green'> Pass</span> / <span style='color:red'> Fail </span>) </th>";
                }
                else
                {
                    if (processType == 1)
                    {
                        lblProcessName.Text = dtUnitName.Rows[0]["Name"] + "&nbsp; Product/ Occupational Safety Audit and Lines Process Audit Report (Compliance)";
                        int heaerwidth = width - 2;
                        mainhead.Attributes.Add("style", "width:" + heaerwidth + "px");
                        str = "<table cellpadding='0' cellspacing='0' style='width:" + width + "px; margin:0px auto;' border='1' class='item_list1'><tr><th>Product/ Occupational Safety (<span style='color:green'> Pass</span> / <span style='color:red'> Fail </span>) </th>";
                    }
                    else
                    {
                        lblProcessName.Text = dtUnitName.Rows[0]["Name"] + "&nbsp; Quality Audit Report";
                        int heaerwidth = width - 2;
                        mainhead.Attributes.Add("style", "width:" + heaerwidth + "px");
                        str = "<table cellpadding='0' cellspacing='0' style='width:" + width + "px; margin:0px auto;' border='1' class='item_list1'><tr><th>Process Audit Report (<span style='color:green'> Pass</span> / <span style='color:red'> Fail </span>) </th>";
                    }
                }
                if (LineNo > 0)
                {
                    for (int i = 0; i < LineNo; i++)
                    {
                        str = str + "<th> Line " + dtProductQCptLine.Rows[i].ItemArray[0].ToString() + "</th>";
                    }
                }
                if (ClusterCount > 0)
                {
                    for (int j = 0; j < ClusterCount; j++)
                    {
                        str = str + "<th> Fin Clstr " + dtProductQCptCluster.Rows[j].ItemArray[0].ToString() + "</th>";
                    }
                }
                if (TypeAdmin > 0)
                {
                    for (int Ab = 0; Ab < TypeAdmin; Ab++)
                    {
                        str = str + "<th>" + dtProductQCptTypeAdmin.Rows[Ab].ItemArray[1].ToString() + "</th>";
                    }
                }
                if (Convert.ToInt32(HttpContext.Current.Session["ProcessType"].ToString()) == -1)
                {
                    if (OutHouseFactory > 0)
                    {
                        for (int OH = 0; OH < OutHouseFactory; OH++)
                        {
                            str = str + "<th>" + dtOutHouseFactory.Rows[OH].ItemArray[0].ToString() + "</th>";
                        }
                    }
                }
                for (int k = 0; k < QCptProcess; k++)
                {
                    str = str + "<tr><td style='width:350px; text-align:left;'>" + dtProductQCptProcess.Rows[k].ItemArray[1].ToString() + "</td>";
                    if (LineNo > 0)
                    {
                        for (int l = 0; l < LineNo; l++)
                        {
                            dsvalue = objadmin.GetLineProcessValue(UnitId, Convert.ToInt32(dtProductQCptProcess.Rows[k].ItemArray[2].ToString()), Convert.ToInt32(dtProductQCptProcess.Rows[k].ItemArray[0].ToString()), 1, Convert.ToInt32(dtProductQCptLine.Rows[l].ItemArray[0].ToString()), dtProductQCptLine.Rows[l].ItemArray[0].ToString().Replace("&", "~"), dateSelect,bOpenFromLink);
                            if (dsvalue.Tables[0].Rows.Count > 0)
                            {
                                remarks = dsvalue.Tables[0].Rows[0]["Remarks"].ToString();
                                PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());                     
                               
                            }
                            else
                            {
                                remarks = "";
                                PassFail = 5;                                
                            }
                            if (PassFail == 1)
                            {
                                str = str + "<td title='" + remarks + "' style='background:green; width:60px;'>";
                            }
                            else if (PassFail == 2)
                            {
                                str = str + "<td title='" + remarks + "' style='background:red;width:60px;'>";
                               
                                failname = failname + "~" + dtProductQCptProcess.Rows[k].ItemArray[1].ToString() + " (Line No " + dtProductQCptLine.Rows[l].ItemArray[0].ToString() + ")=" + remarks;
                               
                            }
                            else if (PassFail == 0)
                            {
                                str = str + "<td title='" + remarks + "' style='width:60px;'>Closed";
                            }
                            else
                            {

                                str = str + "<td title='" + remarks + "' style='width:60px;'>";
                            }                        
                            str = str + "</td>";

                        }
                    }

                    if (ClusterCount > 0)
                    {
                        for (int m = 0; m < ClusterCount; m++)
                        {
                            dsvalue = objadmin.GetLineProcessValue(UnitId, Convert.ToInt32(dtProductQCptProcess.Rows[k].ItemArray[2].ToString()), Convert.ToInt32(dtProductQCptProcess.Rows[k].ItemArray[0].ToString()), 2, Convert.ToInt32(dtProductQCptCluster.Rows[m].ItemArray[1].ToString()), dtProductQCptCluster.Rows[m].ItemArray[0].ToString().Replace("&", "~"), dateSelect,bOpenFromLink);
                            if (dsvalue.Tables[0].Rows.Count > 0)
                            {
                                remarks = dsvalue.Tables[0].Rows[0]["Remarks"].ToString();
                                PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                                ImageFile = dsvalue.Tables[0].Rows[0]["ImageFile"].ToString();
                            }
                            else
                            {
                                remarks = "";
                                PassFail = 5;
                                ImageFile = "";
                            }
                            if (PassFail == 1)
                            {
                                str = str + "<td title='" + remarks + "' style='background:green; width:60px;'>";
                            }
                            else if (PassFail == 2)
                            {
                                str = str + "<td title='" + remarks + "' style='background:red;width:60px;'>";
                               failname = failname + "~" + dtProductQCptProcess.Rows[k].ItemArray[1].ToString() + " (Cluster " + dtProductQCptCluster.Rows[m].ItemArray[0].ToString() + ")=" + remarks;
                                
                            }
                            else if (PassFail == 0)
                            {
                                str = str + "<td title='" + remarks + "' style='width:60px;'>Closed";
                            }
                            else
                            {
                                str = str + "<td title='" + remarks + "' style='width:60px;'>";
                            }
                            
                            str = str + "</td>";
                        }
                    }
                    if (TypeAdmin > 0)
                    {
                        for (int BI = 0; BI < TypeAdmin; BI++)
                        {
                            dsvalue = objadmin.GetLineProcessValue(UnitId, Convert.ToInt32(dtProductQCptProcess.Rows[k].ItemArray[2].ToString()), Convert.ToInt32(dtProductQCptProcess.Rows[k].ItemArray[0].ToString()), Convert.ToInt32(dtProductQCptTypeAdmin.Rows[BI].ItemArray[0].ToString()), Convert.ToInt32(dtProductQCptTypeAdmin.Rows[BI].ItemArray[0].ToString()), dtProductQCptTypeAdmin.Rows[BI].ItemArray[1].ToString().Replace("&", "~"), dateSelect,bOpenFromLink);
                            if (dsvalue.Tables[0].Rows.Count > 0)
                            {
                                remarks = dsvalue.Tables[0].Rows[0]["Remarks"].ToString();
                                PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                                ImageFile = dsvalue.Tables[0].Rows[0]["ImageFile"].ToString();
                            }
                            else
                            {
                                remarks = "";
                                PassFail = 5;
                                ImageFile = "";
                            }
                            if (PassFail == 1)
                            {
                                str = str + "<td title='" + remarks + "' style='background:green; width:60px;'>";
                            }
                            else if (PassFail == 2)
                            {
                                str = str + "<td title='" + remarks + "' style='background:red;width:60px;'>";
                                failname = failname + "~" + dtProductQCptProcess.Rows[k].ItemArray[1].ToString() + " (" + dtProductQCptTypeAdmin.Rows[BI].ItemArray[1].ToString() + ")=" + remarks;
                               
                            }
                            else if (PassFail == 0)
                            {
                                str = str + "<td title='" + remarks + "' style='width:60px;'>Closed";
                            }
                            else
                            {
                                str = str + "<td title='" + remarks + "' style='width:60px;'>";
                            }                            
                            str = str + "</td>";
                        }
                    }

                    if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
                    {
                        if (OutHouseFactory > 0)
                        {
                            for (int OH = 0; OH < OutHouseFactory; OH++)
                            {
                                dsvalue = objadmin.GetLineProcessValue(Convert.ToInt32(Session["UnitId"].ToString()), Convert.ToInt32(dtProductQCptProcess.Rows[k].ItemArray[2].ToString()), Convert.ToInt32(dtProductQCptProcess.Rows[k].ItemArray[0].ToString()), 9998, 9999, dtOutHouseFactory.Rows[OH].ItemArray[1].ToString().Replace("&", "~"), dateSelect,bOpenFromLink);
                                if (dsvalue.Tables[0].Rows.Count > 0)
                                {
                                    remarks = dsvalue.Tables[0].Rows[0]["Remarks"].ToString();
                                    PassFail = Convert.ToInt32(dsvalue.Tables[0].Rows[0]["Pass_Fail"].ToString());
                                    ImageFile = dsvalue.Tables[0].Rows[0]["ImageFile"].ToString();
                                }
                                else
                                {
                                    remarks = "";
                                    PassFail = 5;
                                    ImageFile = "";
                                }
                                if (dtProductQCptProcess.Rows[k].ItemArray[3].ToString() == "1")
                                {
                                    if (dsvalue.Tables[3].Rows.Count > 0)
                                    {
                                        if (dsvalue.Tables[3].Rows[0]["Alternation_Operator_OnMachine"].ToString() != "")
                                        {
                                            if (dsvalue.Tables[3].Rows[0]["Alternation_Operator_OnMachine"].ToString() == "0")
                                            {
                                                str = str + "<td style='width:70px; background:#dbdbd3'>&nbsp;";
                                            }
                                            else
                                            {
                                                str = str + "<td style='width:70px;background:#dbdbd3'>" + dsvalue.Tables[3].Rows[0]["Alternation_Operator_OnMachine"].ToString();
                                            }
                                        }
                                        else
                                        {
                                            str = str + "<td style='width:70px;'>&nbsp;";
                                        }
                                    }
                                    else
                                    {
                                        str = str + "<td style='width:70px;'>&nbsp;";
                                    }
                                }

                              //end

                                else
                                {

                                    if (PassFail == 1)
                                    {
                                        str = str + "<td title='" + remarks + "' style='background:green; width:70px;'>";
                                    }
                                    else if (PassFail == 2)
                                    {
                                        str = str + "<td title='" + remarks + "' style='background:red;width:70px;'>";
                                        if (ImageFile != "")
                                        {
                                            failname = failname + "~" + dtProductQCptProcess.Rows[k].ItemArray[1].ToString() + "℥(" + dtOutHouseFactory.Rows[OH].ItemArray[0].ToString() + ")=" + remarks + "=" + ImageFile;
                                        }
                                        else
                                        {
                                            failname = failname + "~" + dtProductQCptProcess.Rows[k].ItemArray[1].ToString() + "℥(" + dtOutHouseFactory.Rows[OH].ItemArray[0].ToString() + ")=" + remarks;
                                        }
                                    }
                                    else if (PassFail == 0)
                                    {
                                        str = str + "<td title='" + remarks + "' style='width:70px;'>Closed";
                                    }
                                   
                                    else
                                    {
                                        str = str + "<td title='" + remarks + "' style='width:70px;'>";
                                    }
                                }
                            }
                        }
                    }
                    str = str + "</tr>";
                }

                // Start Pass Fail Footer

                str = str + "<tr><td style='width:350px; text-align:left;'> <b> Result:- </b>( <font color='green'> Pass </font>/<font color='red'> Fail </font>) </td>";
                if (LineNo > 0)
                {
                    for (int O = 0; O < LineNo; O++)
                    {
                        resultValue = objadmin.GetProductOccuptionResult(UnitId, 1, Convert.ToInt32(dtProductQCptLine.Rows[O].ItemArray[0].ToString()), processType, dateSelect, floornull,bOpenFromLink);
                        if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 2)
                        {
                            str = str + "<td style='background:red; width:60px;'></td>";
                        }
                        else if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 0)
                        {
                            str = str + "<td style='background:white; width:60px;'></td>";
                        }
                        else
                        {
                            str = str + "<td style='background:green; width:60px;'></td>";
                        }
                    }
                }

                if (ClusterCount > 0)
                {
                    for (int P = 0; P < ClusterCount; P++)
                    {
                        resultValue = objadmin.GetProductOccuptionResult(UnitId, 2, Convert.ToInt32(dtProductQCptCluster.Rows[P].ItemArray[1].ToString()), processType, dateSelect, floornull,bOpenFromLink);
                        if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 2)
                        {
                            str = str + "<td style='background:red; width:60px;'></td>";
                        }
                        else if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 0)
                        {
                            str = str + "<td style='background:white; width:60px;'></td>";
                        }
                        else
                        {
                            str = str + "<td style='background:green; width:60px;'></td>";
                        }
                    }
                }
                if (TypeAdmin > 0)
                {
                    for (int BP = 0; BP < TypeAdmin; BP++)
                    {

                        resultValue = objadmin.GetProductOccuptionResult(UnitId, Convert.ToInt32(dtProductQCptTypeAdmin.Rows[BP].ItemArray[0].ToString()), Convert.ToInt32(dtProductQCptTypeAdmin.Rows[BP].ItemArray[0].ToString()), processType, dateSelect, floornull,bOpenFromLink);
                        if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 2)
                        {
                            str = str + "<td style='background:red; width:60px;'></td>";
                        }
                        else if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 0)
                        {
                            str = str + "<td style='background:white; width:60px;'></td>";
                        }
                        else
                        {
                            str = str + "<td style='background:green; width:60px;'></td>";
                        }
                    }

                }
                if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
                {
                    if (OutHouseFactory > 0)
                    {
                        for (int OH = 0; OH < OutHouseFactory; OH++)
                        {
                            resultValue = objadmin.GetProductOccuptionResult(Convert.ToInt32(Session["UnitId"].ToString()), 9998, 9999, Convert.ToInt32(Session["ProcessType"].ToString()), dateSelect, dtOutHouseFactory.Rows[OH].ItemArray[1].ToString().Replace("&", "~"),bOpenFromLink);
                            if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 2)
                            {
                                str = str + "<td style='background:red; width:60px;'></td>";
                            }
                            else if (Convert.ToInt32(resultValue.Tables[0].Rows[0]["PassLine"].ToString()) == 0)
                            {
                                str = str + "<td style='background:white; width:60px;'></td>";
                            }
                            else
                            {
                                str = str + "<td style='background:green; width:60px;'></td>";
                            }
                        }
                    }
                }
                str = str + "</tr>";
                //End Of Pass Fail Footer

                if (failname != null)
                {
                    str = str + "<tr><th colspan='" + columnSpan + "' style='font-size: 12px !important;'>Remarks:-</th></tr>";
                    string[] FailRemark = failname.Split('~');
                    countFail = FailRemark.Length;
                    for (int n = 1; n < countFail; n++)
                    {
                        string[] FailRemarkUpdated = FailRemark[n].Split('=');

                        if (FailRemarkUpdated.Length == 3)
                        {
                            string[] FailRemarkImage = FailRemarkUpdated[2].Split('$');
                            string[] failunit = FailRemarkUpdated[0].Split('℥');
                            if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
                            {
                                str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + failunit[0] + "</span><span style='color:black'>&nbsp;" + failunit[1] + "</span>:-&nbsp;&nbsp;" + FailRemarkUpdated[1] + "&nbsp; &nbsp;";
                            }
                            else
                            {
                                str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + FailRemarkUpdated[0] + ":-</span>&nbsp; &nbsp;" + FailRemarkUpdated[1] + "&nbsp; &nbsp;";
                            }
                            for (int img = 0; img < FailRemarkImage.Length; img++)
                            {
                                string imageFullPath = "http://localhost:3220/uploads/OwnerRes/" + FailRemarkImage[img];
                                str = str + "<img src=" + imageFullPath + " style='float:right;height:25px;width:25px;' class='preview' />";
                            }
                            str = str + "</td></tr>";
                        }
                        else
                        {
                            if (FailRemarkUpdated.Length == 2)
                            {
                                string[] failunit = FailRemarkUpdated[0].Split('℥');
                                if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
                                {
                                    str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + failunit[0] + "</span><span style='color:black'>&nbsp;" + failunit[1] + "</span>:-&nbsp;&nbsp;" + FailRemarkUpdated[1] + "</td></tr>";
                                }
                                else
                                {
                                    str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + FailRemarkUpdated[0] + ":-</span>&nbsp; &nbsp;" + FailRemarkUpdated[1] + "</td></tr>";
                                }
                            }
                            else
                            {
                                string[] failunit = FailRemarkUpdated[0].Split('℥');
                                if (Convert.ToInt32(Session["ProcessType"].ToString()) == -1)
                                {
                                    str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + failunit[0] + "</span><span style='color:black'>&nbsp;" + failunit[1] + "</span></td></tr>";
                                }
                                else
                                {
                                    str = str + "<tr><td colspan='" + columnSpan + "' style='font-size: 12px !important;text-align:left;'><span style='color:gray'>" + FailRemarkUpdated[0] + ":-</span></td></tr>";
                                }
                            }
                        }
                    }
                }
                str = str + "</table>";
                ProductOccuPational.InnerHtml = str;
            }
        }
    }
}