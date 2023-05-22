using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Text;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.Web;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.Admin
{
    public partial class TaskDelayEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddDepartmentColumns();
                AddLeadTimeDepartmentColumns();
                FillDelayTaskDetails();
                Fill_LeadTime_DelayTaskDetails();
            }
        }

        private void AddDepartmentColumns()
        {
            WorkflowController oWorkflowController = new WorkflowController();
            DataTable dtClients = oWorkflowController.GetClients_DelayTaskDetails();
            if (dtClients.Rows.Count > 0)
            {
                for (int i = 0; i < dtClients.Rows.Count; i++)
                {
                    string tablestring = "";

                    tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' width='100%' border='0' style='border-collapse:collapse; text-align:center;font-size: 9px;'>";
                    tablestring = tablestring + "<tr> <td colspan='4' width='100%' height='20px' style='border-bottom:1px solid #bfbfbf;font-weight:bold;font-size: 12px; color:#ffffff;'><table width='100%' cellspacing='0' cellpadding='0' border='0'><tr><td style='width:70%;color:white;text-align:center;font-size: 12px;font-weight: bold;'>" + dtClients.Rows[i]["CompanyName"].ToString() + "<td style='color:#98a9ca;font-size:9px; padding-right:3px;'> LT in WK</td></tr></table> </td>  </tr>";
                    tablestring = tablestring + "<tr> <td width='25%' height='20px' style='border-right:1px solid #bfbfbf; font-weight:normal; color:#98a9ca;'> Dly </td> <td id='tdStchActOB' runat='server' width='25%' style='border-right:1px solid #bfbfbf;font-weight:normal;color:#98a9ca;'> Tot LT. </td>";
                    tablestring = tablestring + "<td height='20px' width='25%' style='border-right:1px solid #bfbfbf; font-weight:normal;color:#98a9ca;'> 3 M LT </td> <td id='tdFinActOB' runat='server' width='25%' style='font-weight:normal;color:#98a9ca;' >1 Y LT</td> </tr>";
                    tablestring = tablestring + "</table>";

                    if (dtClients.Rows[i]["CompanyName"].ToString() != "Select")
                    {
                        TemplateField oTemplateField = new TemplateField();
                        oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Top;
                        oTemplateField.HeaderText = tablestring;
                        oTemplateField.HeaderStyle.Width = 150;
                        oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        oTemplateField.ItemStyle.VerticalAlign = VerticalAlign.Top;
                        gvDelayMonitoring.Columns.Add(oTemplateField);
                        oTemplateField = null;
                    }
                }
            }
            oWorkflowController = null;
        }
        private void AddLeadTimeDepartmentColumns()
        {
            WorkflowController oWorkflowController = new WorkflowController();
            DataTable dtClients = oWorkflowController.GetClients_LeadTime_DelayTaskDetails();
            if (dtClients.Rows.Count > 0)
            {
                for (int i = 0; i < dtClients.Rows.Count; i++)
                {
                    string tablestring = "";

                    //tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' width='100%' border='0' style='border-collapse:collapse; text-align:center;font-size: 9px;'>";
                    //tablestring = tablestring + "<tr> <td colspan='2' width='100%' height='20px' style='border-bottom:1px solid #bfbfbf;font-weight:bold;font-size: 12px; color:#ffffff;'>" + dtClients.Rows[i]["CompanyName"].ToString() + " </td>  </tr>";
                    ////tablestring = tablestring + "<tr> <td width='50%' height='20px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;font-weight:normal; color:#98a9ca;'> Order Lead Time 1 Years </td> <td id='tdStchActOB' runat='server' width='50%' style=' border-bottom:1px solid #bfbfbf;font-weight:normal;color:#98a9ca;'>  3 Month Lead Time Avg(Wk) </td>  </tr>";
                    ////tablestring = tablestring + "<tr> <td height='20px' width='50%' style='border-right:1px solid #bfbfbf; font-weight:normal;color:#98a9ca;'> Task Lead Time(Wk)  </td> <td id='tdFinActOB' runat='server' width='50%' style='font-weight:normal;color:#98a9ca;' > 1 Year Lead Time Avg(Wk)</td> </tr>";
                    //tablestring = tablestring + "<tr> <td width='50%' height='20px' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-weight:normal; color:#98a9ca;'> 1 Month Lead Time Avg(Wk) </td> <td id='tdStchActOB' runat='server' width='50%' style=' border-bottom:1px solid #bfbfbf;font-weight:normal;color:#98a9ca;'>  3 Month Lead Time Avg(Wk) </td>  </tr>";
                    //tablestring = tablestring + "<tr> <td width='50%' height='20px' style='border-right:1px solid #bfbfbf; font-weight:normal; color:#98a9ca;'> Task Lead Time(Wk) </td><td id='tdFinActOB' runat='server' width='50%' style='font-weight:normal;color:#98a9ca;border-left:1px solid #bfbfbf; height:20px' > 1 Year Lead Time Avg(Wk)</td> </tr>";

                    tablestring = tablestring + "<table  cellpadding='0' cellspacing='0'  width='100%' border='0' style='border-collapse:collapse; text-align:center;font-size: 9px;'>";
                    tablestring = tablestring + "<tr> <td width='100%' height='20px' colspan='3' style='border-bottom:1px solid #bfbfbf;font-weight:bold;font-size: 12px; color:#ffffff;'>" + dtClients.Rows[i]["CompanyName"].ToString() + " </td>  </tr>";
                    //tablestring = tablestring + "<tr> <td width='50%' height='20px' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;font-weight:normal; color:#98a9ca;'> Order Lead Time 1 Years </td> <td id='tdStchActOB' runat='server' width='50%' style=' border-bottom:1px solid #bfbfbf;font-weight:normal;color:#98a9ca;'>  3 Month Lead Time Avg(Wk) </td>  </tr>";
                    //tablestring = tablestring + "<tr> <td height='20px' width='50%' style='border-right:1px solid #bfbfbf; font-weight:normal;color:#98a9ca;'> Task Lead Time(Wk)  </td> <td id='tdFinActOB' runat='server' width='50%' style='font-weight:normal;color:#98a9ca;' > 1 Year Lead Time Avg(Wk)</td> </tr>";
                    tablestring = tablestring + "<tr> <td width='100%' height='20px' colspan='3' style='font-weight:normal; color:#98a9ca;border-bottom:1px solid #bfbfbf;'> Task Lead Time(Wk) </td>";

                    tablestring = tablestring + "<tr> <td  height='20px' style='border-right:1px solid #bfbfbf; font-weight:normal; color:#98a9ca; width:33%'> Total </td>";
                    tablestring = tablestring + " <td width='100%' style=' border-right:1px solid #bfbfbf;font-weight:normal;color:#98a9ca; width:33%'>  3 Month </td>";
                    tablestring = tablestring + " <td width='100%' height='20px' style='font-weight:normal; color:#98a9ca; width:34%;'> 1 Year </td> </tr>";

                    tablestring = tablestring + "</table>";

                    if (dtClients.Rows[i]["CompanyName"].ToString() != "Select")
                    {
                        TemplateField oTemplateField = new TemplateField();
                        oTemplateField.HeaderStyle.VerticalAlign = VerticalAlign.Top;
                        oTemplateField.HeaderText = tablestring;
                        oTemplateField.HeaderStyle.Width = 215;
                        oTemplateField.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                        oTemplateField.ItemStyle.VerticalAlign = VerticalAlign.Top;
                        grdViewLeadTime.Columns.Add(oTemplateField);
                        oTemplateField = null;
                    }
                }
            }
            oWorkflowController = null;
        }

        private void FillDelayTaskDetails()
        {
            WorkflowController oWorkflowController = new WorkflowController();
            gvDelayMonitoring.DataSource = oWorkflowController.GetDelayTaskDetails();
            gvDelayMonitoring.DataBind();
            oWorkflowController = null;
            gvDelayMonitoring.Columns[3].Visible = false;
        }
        private void Fill_LeadTime_DelayTaskDetails()
        {
            WorkflowController oWorkflowController = new WorkflowController();
            grdViewLeadTime.DataSource = oWorkflowController.Get_LeadTime_DelayTaskDetails();
            grdViewLeadTime.DataBind();
            oWorkflowController = null;
            grdViewLeadTime.Columns[3].Visible = false;
        }


        protected void gvDelayMonitoring_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                WorkflowController oWorkflowController = new WorkflowController();
                DataTable dtClients = oWorkflowController.GetClients_DelayTaskDetails();
                HiddenField hdnStatusModeId = (HiddenField)e.Row.FindControl("hdnStatusModeId");
                Label lblpercentdelay = (Label)e.Row.FindControl("lblpercentdelay");
                Label lblTotalStatusModeCount = (Label)e.Row.FindControl("lblTotalStatusModeCount");
                Label lblAvgDelayDay = (Label)e.Row.FindControl("lblAvgDelayDay");
                Label lblMaxDelayDay = (Label)e.Row.FindControl("lblMaxDelayDay");



                HtmlTableCell tdt2 = (HtmlTableCell)e.Row.FindControl("tdt2");
                HtmlTableCell tdStchActOB = (HtmlTableCell)e.Row.FindControl("tdStchActOB");
                //lblpercentdelay.Text = lblpercentdelay.Text.ToString() == "" ? "0" : lblpercentdelay.Text;
                //if (Convert.ToInt32(lblpercentdelay.Text) > 25)
                //{
                //    //tdt2.Style.Add("color", "red");
                //    lblpercentdelay.ForeColor = System.Drawing.Color.Red;
                //    //lblpercentdelay.Font.Bold = true;

                //}
                ////-- For color code

                //if (Convert.ToInt32(lblAvgDelayDay.Text) <= 2)
                //{
                //    lblAvgDelayDay.ForeColor = System.Drawing.Color.Black;
                //    tdStchActOB.Style.Add("background", "#67aa67");
                //}
                //if (Convert.ToInt32(lblAvgDelayDay.Text) == 3 || Convert.ToInt32(lblAvgDelayDay.Text) == 4)
                //{
                //    //lblAvgDelayDay.ForeColor = System.Drawing.Color.Orange;
                //    tdStchActOB.Style.Add("background", "Orange");
                //    lblAvgDelayDay.ForeColor = System.Drawing.Color.Black;
                //}
                //if (Convert.ToInt32(lblAvgDelayDay.Text) >= 5)
                //{
                //    lblAvgDelayDay.ForeColor = System.Drawing.Color.Black;
                //    tdStchActOB.Style.Add("background", "#f88585");
                //}
                //else
                //{
                //    lblAvgDelayDay.ForeColor = System.Drawing.Color.Black;
                //}
                //--end
                //lblpercentdelay.Text = lblpercentdelay.Text.ToString() == "0" ? "" : lblpercentdelay.Text + " %";
                //lblTotalStatusModeCount.Text = lblTotalStatusModeCount.Text.ToString() == "0" ? "" : lblTotalStatusModeCount.Text ;
                //lblAvgDelayDay.Text = lblAvgDelayDay.Text.ToString() == "0" ? "" : lblAvgDelayDay.Text;
                //lblMaxDelayDay.Text = lblMaxDelayDay.Text.ToString() == "0" ? "" : lblMaxDelayDay.Text;


                for (int i = 4; i < gvDelayMonitoring.Columns.Count; i++)
                {

                    int ClientId = Convert.ToInt32(dtClients.Rows[i - 4]["ClientID"]);

                    Label oLabel = new Label();
                    oLabel.ID = "lblClient_" + (i - 4);
                    string Delay = "";
                    string AvgDlyDay = "";
                    string PercentDelay = "";
                    string MaxDelayDay = "";

                    //abhishek 14/7/2017
                    if (hdnStatusModeId.Value == "9997")
                    {
                        DataTable dtDelayDetails = oWorkflowController.GetClients_DelayTaskCount_TopApprovalPending(ClientId, Convert.ToInt32(hdnStatusModeId.Value));
                        Delay = dtDelayDetails.Rows[0].ItemArray[0].ToString() == "0" ? "" : dtDelayDetails.Rows[0].ItemArray[0].ToString();//TOTAL DELAY
                        AvgDlyDay = dtDelayDetails.Rows[0].ItemArray[1].ToString() == "0" ? "" : dtDelayDetails.Rows[0].ItemArray[1].ToString();//TOTAL LT
                        PercentDelay = dtDelayDetails.Rows[0].ItemArray[2].ToString() == "0" ? "" : dtDelayDetails.Rows[0].ItemArray[2].ToString();//3 MONTH
                        MaxDelayDay = dtDelayDetails.Rows[0].ItemArray[3].ToString() == "0" ? "" : dtDelayDetails.Rows[0].ItemArray[3].ToString();//1 YEAR
                    }
                    else
                    {
                        DataTable dtDelayDetails = oWorkflowController.GetClients_DelayTaskCount(ClientId, Convert.ToInt32(hdnStatusModeId.Value));
                        Delay = dtDelayDetails.Rows[0].ItemArray[0].ToString() == "0" ? "" : dtDelayDetails.Rows[0].ItemArray[0].ToString();//TOTAL DELAY
                        AvgDlyDay = dtDelayDetails.Rows[0].ItemArray[1].ToString() == "0" ? "" : dtDelayDetails.Rows[0].ItemArray[1].ToString();//TOTAL LT
                        PercentDelay = dtDelayDetails.Rows[0].ItemArray[2].ToString() == "0" ? "" : dtDelayDetails.Rows[0].ItemArray[2].ToString();//3 MONTH
                        MaxDelayDay = dtDelayDetails.Rows[0].ItemArray[3].ToString() == "0" ? "" : dtDelayDetails.Rows[0].ItemArray[3].ToString();//1 YEAR
                    }


                    string tablestring = "";

                    if (hdnStatusModeId.Value != "9999")
                    {
                        //PercentDelay = PercentDelay.ToString() == "" ? "0" : PercentDelay;
                        //if (Convert.ToInt32(PercentDelay.Replace(" %", "")) > 25)
                        //{
                        //if (PercentDelay == "0")
                        //{
                        //    PercentDelay = "";
                        //}
                        //tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' width='100%' border='0' style='border-collapse:collapse; text-align:center;font-size: 11px;'>";
                        //tablestring = tablestring + "<tr> <td width='50%' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;font-weight:bold; height:14px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='50%' style=' border-bottom:1px solid #bfbfbf;color:gray;'> " + AvgDlyDay + "</td>  </tr>";
                        //if (AvgDlyDay == "")
                        //    AvgDlyDay = "0";
                        //if (Convert.ToInt32(AvgDlyDay) <= 2)
                        //{
                        //    AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                        //    if ((AvgDlyDay == "") && (MaxDelayDay == ""))
                        //        tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf; font-weight:bold; height:23px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style='color:black;font-weight:bold; border-right:1px solid #bfbfbf;'> " + AvgDlyDay + "</td>";
                        //    else
                        //        tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf;font-weight:bold; height:23px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style='background:#67aa67;color:black;font-weight:bold; border-right:1px solid #bfbfbf;'> " + AvgDlyDay + "</td>";
                        //    AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                        //}
                        //if (Convert.ToInt32(AvgDlyDay) == 3 || Convert.ToInt32(AvgDlyDay) == 4)
                        //{
                        //    AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                        //    tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf;font-weight:bold; height:23px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style='border-right:1px solid #bfbfbf;background:Orange;color:black; font-weight:bold;'> " + AvgDlyDay + "</td>";
                        //    AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                        //}
                        //if (Convert.ToInt32(AvgDlyDay) >= 5)
                        //{
                        //    AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                        //    tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf;font-weight:bold; height:23px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style='border-right:1px solid #bfbfbf;background:#f88585;color:Black; font-weight:bold;'> " + AvgDlyDay + "</td>";
                        //    AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                        //}

                        //if (MaxDelayDay == "")
                        //    MaxDelayDay = "0";
                        //if (Convert.ToInt32(MaxDelayDay) <= 2)
                        //{
                        //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                        //    if (MaxDelayDay == "")
                        //        tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:red;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                        //    else
                        //        tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:red;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                        //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;

                        //}
                        //if (Convert.ToInt32(MaxDelayDay) == 3 || Convert.ToInt32(MaxDelayDay) == 4)
                        //{
                        //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                        //    tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:red;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                        //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                        //}
                        //if (Convert.ToInt32(MaxDelayDay) >= 5)
                        //{
                        //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                        //    tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:red;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                        //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                        //}
                        tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' width='100%' border='0' style='border-collapse:collapse; text-align:center;font-size: 11px;'>";
                        if (AvgDlyDay == "")
                            AvgDlyDay = "0";
                        Delay = Delay.ToString() == "" ? "0" : Delay;
                        PercentDelay = PercentDelay.ToString() == "" ? "0" : PercentDelay;
                        MaxDelayDay = MaxDelayDay.ToString() == "" ? "0" : MaxDelayDay;

                        if (Convert.ToDecimal(MaxDelayDay) <= Convert.ToDecimal(AvgDlyDay))
                        {

                            if (Convert.ToDecimal(PercentDelay) <= Convert.ToDecimal(AvgDlyDay))
                            {
                                AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                                MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                                PercentDelay = PercentDelay.ToString() == "0" ? "" : PercentDelay;
                                Delay = Delay.ToString() == "0" ? "" : Delay;
                                tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf;color:red;font-weight:bold; height:25px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style='color:black; font-weight:bold;border-right:1px solid #bfbfbf;background:#f2f2f2;height:25px'> " + AvgDlyDay + "</td> ";
                                tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:black;height:25px; background:#67aa67'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:black;background:#67aa67;height:25px' width='25%'> " + MaxDelayDay + "</td> </tr>";

                            }
                            else
                            {
                                AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                                MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                                PercentDelay = PercentDelay.ToString() == "0" ? "" : PercentDelay;
                                Delay = Delay.ToString() == "0" ? "" : Delay;
                                tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf;color:red;font-weight:bold; height:25px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style='color:black; font-weight:bold;border-right:1px solid #bfbfbf;background:#f2f2f2;height:25px'> " + AvgDlyDay + "</td> ";
                                tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:black;height:25px; background:#f88585'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:black;background:#67aa67;height:25px' width='25%'> " + MaxDelayDay + "</td> </tr>";

                            }
                        }
                        else
                        {

                            if (Convert.ToDecimal(PercentDelay) <= Convert.ToDecimal(AvgDlyDay))
                            {
                                AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                                MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                                PercentDelay = PercentDelay.ToString() == "0" ? "" : PercentDelay;
                                Delay = Delay.ToString() == "0" ? "" : Delay;
                                tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf;color:red;font-weight:bold; height:25px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style='color:black; font-weight:bold;border-right:1px solid #bfbfbf;background:#f2f2f2;height:25px'> " + AvgDlyDay + "</td> ";
                                tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:black;height:25px; background:#67aa67'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:black;background:#f88585;height:25px' width='25%'> " + MaxDelayDay + "</td> </tr>";

                            }
                            else
                            {
                                AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                                MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                                PercentDelay = PercentDelay.ToString() == "0" ? "" : PercentDelay;
                                Delay = Delay.ToString() == "0" ? "" : Delay;
                                tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf;color:red;font-weight:bold; height:25px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style='color:black; font-weight:bold;border-right:1px solid #bfbfbf;background:#f2f2f2;height:25px'> " + AvgDlyDay + "</td> ";
                                tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:black;height:25px; background:#f88585'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:black;background:#f88585;height:25px' width='25%'> " + MaxDelayDay + "</td> </tr>";

                            }

                        }
                        tablestring = tablestring + "</table>";
                    }
                    //else
                    //{
                    //if (PercentDelay == "0")
                    //{
                    //    PercentDelay = "";
                    //}
                    //tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' width='100%' border='0' style='border-collapse:collapse; text-align:center;font-size: 11px;'>";
                    //tablestring = tablestring + "<tr> <td width='50%' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;font-weight:bold; height:14px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='50%' style=' border-bottom:1px solid #bfbfbf;color:gray;'> " + AvgDlyDay + "</td>  </tr>";
                    //if (AvgDlyDay == "")
                    //    AvgDlyDay = "0";



                            //if (Convert.ToInt32(AvgDlyDay) <= 2)
                    //{
                    //    AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;

                            //    if ((AvgDlyDay == "") && (MaxDelayDay == ""))
                    //        tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf;font-weight:bold; height:23px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style='color:black; font-weight:bold;border-right:1px solid #bfbfbf;'> " + AvgDlyDay + "</td> ";
                    //    else
                    //        tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf;font-weight:bold; height:23px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style='border-right:1px solid #bfbfbf;background:#67aa67;color:black; font-weight:bold;'> " + AvgDlyDay + "</td>";
                    //    AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                    //}
                    //if (Convert.ToInt32(AvgDlyDay) == 3 || Convert.ToInt32(AvgDlyDay) == 4)
                    //{
                    //    AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                    //    tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf;font-weight:bold; height:23px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style='border-right:1px solid #bfbfbf;background:Orange;color:black; font-weight:bold;'> " + AvgDlyDay + "</td>";
                    //    AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                    //}
                    //if (Convert.ToInt32(AvgDlyDay) >= 5)
                    //{
                    //    AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                    //    tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;font-weight:bold; height:14px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style=' border-bottom:1px solid #bfbfbf;background:#f88585;color:black; font-weight:bold;'> " + AvgDlyDay + "</td>";
                    //    AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                    //}
                    //if (MaxDelayDay == "")
                    //    MaxDelayDay = "0";
                    //if (Convert.ToInt32(MaxDelayDay) <= 2)
                    //{
                    //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                    //    if (MaxDelayDay == "")
                    //        tablestring = tablestring + " <td width='25%' style='border-right:1px solid #bfbfbf;color:blue;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                    //    else
                    //        tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:blue;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                    //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;

                            //}
                    //if (Convert.ToInt32(MaxDelayDay) == 3 || Convert.ToInt32(MaxDelayDay) == 4)
                    //{
                    //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                    //    tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:blue;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                    //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                    //}
                    //if (Convert.ToInt32(MaxDelayDay) >= 5)
                    //{
                    //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                    //    tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:blue;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                    //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                    //}


                            //tablestring = tablestring + "<tr> <td width='50%' style='border-right:1px solid #bfbfbf;color:blue;height:14px'>" + PercentDelay +" </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='50%'> " + MaxDelayDay + "</td> </tr>";
                    //tablestring = tablestring + "</table>";
                    //}

                    //}
                    else
                    {
                        //PercentDelay = PercentDelay.ToString() == "" ? "0" : PercentDelay;
                        //if (Convert.ToInt32(PercentDelay.Replace(" %", "")) > 25)
                        //{
                        //if (PercentDelay == "0")
                        //{
                        //    PercentDelay = "";
                        //}
                        //tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' width='100%' border='0' style='border-collapse:collapse; text-align:center;font-size: 11px;'>";
                        ////tablestring = tablestring + "<tr style='background:#f2f2f2;'> <td width='50%' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;font-weight:bold; font-size:12px; height:14px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='50%' style=' border-bottom:1px solid #bfbfbf;color:gray;'> " + AvgDlyDay + "</td>  </tr>";
                        //if (AvgDlyDay == "")
                        //    AvgDlyDay = "0";
                        //if (Convert.ToInt32(AvgDlyDay) <= 2)
                        //{
                        //    AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                        //    if ((AvgDlyDay == "") && (MaxDelayDay == ""))
                        //        tablestring = tablestring + "<tr style='background:#f2f2f2;'> <td width='25%' style='border-right:1px solid #bfbfbf;font-weight:bold; font-size:12px; height:23px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style=' border-right:1px solid #bfbfbf;color:black; font-weight:bold;'> " + AvgDlyDay + "</td>";
                        //    else
                        //        tablestring = tablestring + "<tr style='background:#f2f2f2;'> <td width='25%' style='border-right:1px solid #bfbfbf;font-weight:bold; font-size:12px; height:23px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='60%' style=' border-right:1px solid #bfbfbf;background:#67aa67;color:black; font-weight:bold;'> " + AvgDlyDay + "</td>";
                        //    AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                        //}
                        //if (Convert.ToInt32(AvgDlyDay) == 3 || Convert.ToInt32(AvgDlyDay) == 4)
                        //{
                        //    AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                        //    tablestring = tablestring + "<tr style='background:#f2f2f2;'> <td width='25%' style='border-right:1px solid #bfbfbf;font-weight:bold; font-size:12px; height:23px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style=' border-right:1px solid #bfbfbf;background:Orange;color:black; font-weight:bold;'> " + AvgDlyDay + "</td>";
                        //    AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                        //}
                        //if (Convert.ToInt32(AvgDlyDay) >= 5)
                        //{
                        //    AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                        //    tablestring = tablestring + "<tr style='background:#f2f2f2;'> <td width='25%' style='border-right:1px solid #bfbfbf;font-weight:bold; font-size:12px; height:23px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style=' border-right:1px solid #bfbfbf;background:#f88585;color:black; font-weight:bold;'> " + AvgDlyDay + "</td>";
                        //    AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                        //}
                        //if (MaxDelayDay == "")
                        //    MaxDelayDay = "0";
                        //if (Convert.ToInt32(MaxDelayDay) <= 2)
                        //{
                        //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                        //    if (MaxDelayDay == "")
                        //        tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:red;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                        //    else
                        //        tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:red;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                        //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;

                        //}
                        //if (Convert.ToInt32(MaxDelayDay) == 3 || Convert.ToInt32(MaxDelayDay) == 4)
                        //{
                        //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                        //    tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:red;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                        //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                        //}
                        //if (Convert.ToInt32(MaxDelayDay) >= 5)
                        //{
                        //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                        //    tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:red;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                        //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                        //}

                        //tablestring = tablestring + "<tr style='background:#f2f2f2;'> <td width='50%' style='border-right:1px solid #bfbfbf;color:black;background:red;height:14px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='50%'> " + MaxDelayDay + "</td> </tr>";
                        //tablestring = tablestring + "</table>";
                        //}
                        //else
                        //{
                        //if (PercentDelay == "0")
                        //{
                        //    PercentDelay = "";
                        //}
                        //tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' width='100%' border='0' style='border-collapse:collapse; text-align:center;font-size: 11px;'>";
                        //tablestring = tablestring + "<tr style='background:#f2f2f2;'> <td width='50%' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;font-weight:bold; font-size:12px; height:14px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='50%' style=' border-bottom:1px solid #bfbfbf;color:gray;'> " + AvgDlyDay + "</td>  </tr>";
                        //if (AvgDlyDay == "")
                        //    AvgDlyDay = "0";
                        //if (Convert.ToInt32(AvgDlyDay) <= 2)
                        //{
                        //    AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                        //    if ((AvgDlyDay == "") && (MaxDelayDay == ""))
                        //        tablestring = tablestring + "<tr style='background:#f2f2f2;'> <td width='25%' style='border-right:1px solid #bfbfbf; font-weight:bold; font-size:12px; height:23px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style=' border-right:1px solid #bfbfbf;color:black; font-weight:bold;'> " + AvgDlyDay + "</td>";
                        //    else
                        //        tablestring = tablestring + "<tr style='background:#f2f2f2;'> <td width='25%' style='border-right:1px solid #bfbfbf; font-weight:bold; font-size:12px; height:23px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style=' border-right:1px solid #bfbfbf;background:#67aa67;color:black; font-weight:bold;'> " + AvgDlyDay + "</td>";
                        //    AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                        //}
                        //if (Convert.ToInt32(AvgDlyDay) == 3 || Convert.ToInt32(AvgDlyDay) == 4)
                        //{
                        //    AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                        //    tablestring = tablestring + "<tr style='background:#f2f2f2;'> <td width='25%' style='border-right:1px solid #bfbfbf;font-weight:bold; font-size:12px; height:23px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style=' border-right:1px solid #bfbfbf;background:Orange;color:black; font-weight:bold;'> " + AvgDlyDay + "</td>";
                        //    AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                        //}
                        //if (Convert.ToInt32(AvgDlyDay) >= 5)
                        //{
                        //    AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                        //    tablestring = tablestring + "<tr style='background:#f2f2f2;'> <td width='25%' style='border-right:1px solid #bfbfbf;font-weight:bold; font-size:12px; height:23px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style=' border-right:1px solid #bfbfbf;background:#f88585;color:black; font-weight:bold;'> " + AvgDlyDay + "</td>";
                        //    AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                        //}
                        //if (MaxDelayDay == "")
                        //    MaxDelayDay = "0";
                        //if (Convert.ToInt32(MaxDelayDay) <= 2)
                        //{
                        //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                        //    if (MaxDelayDay == "")
                        //        tablestring = tablestring + " <td width='25%' style='border-right:1px solid #bfbfbf;color:blue;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                        //    else
                        //        tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:blue;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                        //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;

                        //}
                        //if (Convert.ToInt32(MaxDelayDay) == 3 || Convert.ToInt32(MaxDelayDay) == 4)
                        //{
                        //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                        //    tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:blue;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                        //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                        //}
                        //if (Convert.ToInt32(MaxDelayDay) >= 5)
                        //{
                        //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                        //    tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:blue;height:23px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='25%'> " + MaxDelayDay + "</td> </tr>";
                        //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                        //}


                        //tablestring = tablestring + "<tr style='background:#f2f2f2;'> <td width='50%' style='border-right:1px solid #bfbfbf;color:blue;height:14px'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='50%'> " + MaxDelayDay + "</td> </tr>";

                        //}
                        tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' width='100%' border='0' style='border-collapse:collapse; text-align:center;font-size: 11px;'>";

                        if (AvgDlyDay == "")
                            AvgDlyDay = "0";
                        Delay = Delay.ToString() == "" ? "0" : Delay;
                        PercentDelay = PercentDelay.ToString() == "" ? "0" : PercentDelay;
                        MaxDelayDay = MaxDelayDay.ToString() == "" ? "0" : MaxDelayDay;

                        if (Convert.ToDecimal(MaxDelayDay) <= Convert.ToDecimal(AvgDlyDay))
                        {

                            if (Convert.ToDecimal(PercentDelay) <= Convert.ToDecimal(AvgDlyDay))
                            {
                                AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                                MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                                PercentDelay = PercentDelay.ToString() == "0" ? "" : PercentDelay;
                                Delay = Delay.ToString() == "0" ? "" : Delay;
                                tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf;color:red;font-weight:bold; height:25px;'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style='color:black; font-weight:bold;border-right:1px solid #bfbfbf;background:#f2f2f2;height:25px'> " + AvgDlyDay + "</td> ";
                                tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:black;height:25px; background:#67aa67'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:black;background:#67aa67;height:25px;' width='25%'> " + MaxDelayDay + "</td> </tr>";

                            }
                            else
                            {
                                AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                                MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                                PercentDelay = PercentDelay.ToString() == "0" ? "" : PercentDelay;
                                Delay = Delay.ToString() == "0" ? "" : Delay;
                                tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf;color:red;font-weight:bold; height:25px;'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style='color:black; font-weight:bold;border-right:1px solid #bfbfbf;background:#f2f2f2;height:25px;'> " + AvgDlyDay + "</td> ";
                                tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:black;height:25px; background:#f88585'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:black;background:#67aa67;height:25px;' width='25%'> " + MaxDelayDay + "</td> </tr>";

                            }
                        }
                        else
                        {

                            if (Convert.ToDecimal(PercentDelay) <= Convert.ToDecimal(AvgDlyDay))
                            {
                                AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                                MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                                PercentDelay = PercentDelay.ToString() == "0" ? "" : PercentDelay;
                                Delay = Delay.ToString() == "0" ? "" : Delay;
                                tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf;color:red;font-weight:bold; height:25px;'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style='color:black; font-weight:bold;border-right:1px solid #bfbfbf;background:#f2f2f2;height:25px;'> " + AvgDlyDay + "</td> ";
                                tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:black;height:25px; background:#67aa67'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:black;background:#f88585;height:25px' width='25%'> " + MaxDelayDay + "</td> </tr>";

                            }
                            else
                            {
                                AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                                MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                                PercentDelay = PercentDelay.ToString() == "0" ? "" : PercentDelay;
                                Delay = Delay.ToString() == "0" ? "" : Delay;
                                tablestring = tablestring + "<tr> <td width='25%' style='border-right:1px solid #bfbfbf;color:red;font-weight:bold; height:25px;'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='25%' style='color:black; font-weight:bold;border-right:1px solid #bfbfbf;background:#f2f2f2;height:25px;'> " + AvgDlyDay + "</td> ";
                                tablestring = tablestring + "<td width='25%' style='border-right:1px solid #bfbfbf;color:black;height:25px; background:#f88585'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:black;background:#f88585;height:25px' width='25%'> " + MaxDelayDay + "</td> </tr>";

                            }

                        }
                        tablestring = tablestring + "</table>";
                    }


                    oLabel.Text = tablestring;
                    e.Row.Cells[i].Controls.Add(oLabel);
                    if (hdnStatusModeId.Value == "9999")
                    {
                        e.Row.Cells[0].ColumnSpan = 2;
                        e.Row.Cells[1].Visible = false;
                        e.Row.Cells[2].Attributes.Add("bgcolor", "#f2f2f2");
                    }


                }
                oWorkflowController = null;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                e.Row.Cells[0].ColumnSpan = 2;
                e.Row.Cells[1].Visible = false;
            }
        }
        public string getmonth(string CurrentMonth)
        {
            switch (CurrentMonth)
            {
                case "01":
                    CurrentMonth = "Jan";
                    break;
                case "02":
                    CurrentMonth = "Feb";
                    break;
                case "03":
                    CurrentMonth = "March";
                    break;
                case "04":
                    CurrentMonth = "April";
                    break;
                case "05":
                    CurrentMonth = "May";
                    break;
                case "06":
                    CurrentMonth = "June";
                    break;
                case "07":
                    CurrentMonth = "July";
                    break;
                case "08":
                    CurrentMonth = "Aug";
                    break;
                case "09":
                    CurrentMonth = "Sept";
                    break;
                case "10":
                    CurrentMonth = "Oct";
                    break;
                case "11":
                    CurrentMonth = "Nov";
                    break;
                case "12":
                    CurrentMonth = "Dec";
                    break;

            }
            return CurrentMonth;
        }
        protected void grdViewLeadTime_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                WorkflowController oWorkflowController = new WorkflowController();
                DataTable dtClients = oWorkflowController.GetClients_LeadTime_DelayTaskDetails();
                HiddenField hdnStatusModeId = (HiddenField)e.Row.FindControl("hdnLeadTimeStatusModeId");
                Label lblpercentdelay = (Label)e.Row.FindControl("lblLeadTimepercentdelay");
                Label lblTotalStatusModeCount = (Label)e.Row.FindControl("lblLeadTimeTotalStatusModeCount");
                Label lblAvgDelayDay = (Label)e.Row.FindControl("lblLeadTimeAvgDelayDay");
                Label lblMaxDelayDay = (Label)e.Row.FindControl("lblLeadTimeMaxDelayDay");

                HiddenField hdnLeadTimepercentdelay = (HiddenField)e.Row.FindControl("hdnLeadTimepercentdelay");
                HiddenField hdnLeadTimeAvgDelayDay = (HiddenField)e.Row.FindControl("hdnLeadTimeAvgDelayDay");
                HtmlGenericControl footertable = (HtmlGenericControl)e.Row.FindControl("footertable");
                Label lblLeadTimeTargetLogic = (Label)e.Row.FindControl("lblLeadTimeTargetLogic");
                string CurrentMonth = getmonth(DateTime.Now.ToString("MM"));
                string nextMonth = getmonth(DateTime.Now.AddMonths(1).ToString("MM"));
                string nextToNextMonth = getmonth(DateTime.Now.AddMonths(2).ToString("MM"));
                string nextToNextaddMonth = getmonth(DateTime.Now.AddMonths(3).ToString("MM"));
                // nextToNextaddMonth = nextToNextaddMonth + " Onw.";
                nextToNextMonth = nextToNextMonth + " Onw.";


                HtmlTableCell tdt2 = (HtmlTableCell)e.Row.FindControl("tdLeadTimet2");
                HtmlTableCell tdStchActOB = (HtmlTableCell)e.Row.FindControl("tdLeadTimeStchActOB");
                //lblpercentdelay.Text = lblpercentdelay.Text.ToString() == "" ? "0" : lblpercentdelay.Text;

                //lblpercentdelay.Text = lblpercentdelay.Text.ToString() == "0" ? "" : lblpercentdelay.Text;
                //lblTotalStatusModeCount.Text = lblTotalStatusModeCount.Text.ToString() == "0" ? "" : lblTotalStatusModeCount.Text;
                //lblAvgDelayDay.Text = lblAvgDelayDay.Text.ToString() == "0" ? "" : lblAvgDelayDay.Text;
                //lblMaxDelayDay.Text = lblMaxDelayDay.Text.ToString() == "0" ? "" : lblMaxDelayDay.Text;


                //-- For color code


                //if (Convert.ToDecimal(hdnLeadTimepercentdelay.Value) > Convert.ToDecimal(hdnLeadTimeAvgDelayDay.Value))
                //{
                //    lblAvgDelayDay.ForeColor = System.Drawing.Color.Black;
                //    tdStchActOB.Style.Add("background", "#67aa67");
                //}
                //if (Convert.ToDecimal(hdnLeadTimeAvgDelayDay.Value) > Convert.ToDecimal(hdnLeadTimepercentdelay.Value))
                //{
                //    lblAvgDelayDay.ForeColor = System.Drawing.Color.Black;
                //    tdStchActOB.Style.Add("background", "#f88585");
                //}
                //if (Convert.ToInt32(lblAvgDelayDay.Text) == 3 || Convert.ToInt32(lblAvgDelayDay.Text) == 4)
                //{
                //    //lblAvgDelayDay.ForeColor = System.Drawing.Color.Orange;
                //    tdStchActOB.Style.Add("background", "Orange");
                //    lblAvgDelayDay.ForeColor = System.Drawing.Color.Black;
                //}
                //if (Convert.ToInt32(lblAvgDelayDay.Text) >= 5)
                //{
                //    lblAvgDelayDay.ForeColor = System.Drawing.Color.Yellow;
                //    tdStchActOB.Style.Add("background", "Red");
                //}
                for (int i = 4; i < grdViewLeadTime.Columns.Count; i++)
                {

                    int ClientId = Convert.ToInt32(dtClients.Rows[i - 4]["ClientID"]);

                    Label oLabel = new Label();
                    oLabel.ID = "lblClient_" + (i - 4);

                    DataTable dtDelayDetails = oWorkflowController.GetClients_LeadTime_DelayTaskCount(ClientId, Convert.ToInt32(hdnStatusModeId.Value));
                    string Delay = dtDelayDetails.Rows[0].ItemArray[0].ToString() == "" ? "0" : dtDelayDetails.Rows[0].ItemArray[0].ToString();
                    string AvgDlyDay = dtDelayDetails.Rows[0].ItemArray[3].ToString() == "" ? "0" : dtDelayDetails.Rows[0].ItemArray[3].ToString();
                    string PercentDelay = dtDelayDetails.Rows[0].ItemArray[2].ToString() == "" ? "0" : dtDelayDetails.Rows[0].ItemArray[2].ToString();
                    string MaxDelayDay = dtDelayDetails.Rows[0].ItemArray[1].ToString() == "" ? "0" : dtDelayDetails.Rows[0].ItemArray[1].ToString();
                    string StyleCount = dtDelayDetails.Rows[0].ItemArray[1].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["StyleCount"].ToString();
                    string OneMonthAvg = dtDelayDetails.Rows[0]["OneMonthesAvg"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["OneMonthesAvg"].ToString();
                    // -------------------------------------------EDIT BY SURENDRA FOR TOTAL MONTH WISE COUNT
                    string CurrentMonthDone = dtDelayDetails.Rows[0]["CurrentMonthDone"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["CurrentMonthDone"].ToString();
                    string CurrentMonthPending = dtDelayDetails.Rows[0]["CurrentMonthPending"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["CurrentMonthPending"].ToString();
                    string NextMonthDone = dtDelayDetails.Rows[0]["NextMonthDone"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["NextMonthDone"].ToString();
                    string NextMonthPending = dtDelayDetails.Rows[0]["NextMonthPending"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["NextMonthPending"].ToString();
                    string NextToNextMonthDone = dtDelayDetails.Rows[0]["NextToNextMonthDone"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["NextToNextMonthDone"].ToString();
                    string NextToNextMonthPending = dtDelayDetails.Rows[0]["NextToNextMonthPending"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["NextToNextMonthPending"].ToString();
                    string CurrentMonthAdd3MonthesPending = dtDelayDetails.Rows[0]["CurrentMonthAdd3MonthesPending"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["CurrentMonthAdd3MonthesPending"].ToString();
                    string CurrentMonthAdd3MonthesDone = dtDelayDetails.Rows[0]["CurrentMonthAdd3MonthesDone"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["CurrentMonthAdd3MonthesDone"].ToString();





                    string CurrentMonthDone_Stylecode = dtDelayDetails.Rows[0]["CurrentMonthDone_Stylecode"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["CurrentMonthDone_Stylecode"].ToString();
                    string CurrentMonthPending_Stylecode = dtDelayDetails.Rows[0]["CurrentMonthPending_Stylecode"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["CurrentMonthPending_Stylecode"].ToString();
                    string CurrentMonthDonePatternSample_Stylecode = dtDelayDetails.Rows[0]["CurrentMonthDonePatternSample_Stylecode"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["CurrentMonthDonePatternSample_Stylecode"].ToString();
                    string NextMonthDone_Stylecode = dtDelayDetails.Rows[0]["NextMonthDone_Stylecode"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["NextMonthDone_Stylecode"].ToString();
                    string NextMonthPending_Stylecode = dtDelayDetails.Rows[0]["NextMonthPending_Stylecode"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["NextMonthPending_Stylecode"].ToString();
                    string NextMonthDonePatternSample_Stylecode = dtDelayDetails.Rows[0]["NextMonthDonePatternSample_Stylecode"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["NextMonthDonePatternSample_Stylecode"].ToString();
                    string NextToNextMonthDone_Stylecode = dtDelayDetails.Rows[0]["NextToNextMonthDone_Stylecode"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["NextToNextMonthDone_Stylecode"].ToString();
                    string NextToNextMonthPending_Stylecode = dtDelayDetails.Rows[0]["NextToNextMonthPending_Stylecode"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["NextToNextMonthPending_Stylecode"].ToString();
                    string NextToNextMonthDonePatternSample_Stylecode = dtDelayDetails.Rows[0]["NextToNextMonthDonePatternSample_Stylecode"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["NextToNextMonthDonePatternSample_Stylecode"].ToString();

                    string StyleCode = dtDelayDetails.Rows[0]["StyleCode"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["StyleCode"].ToString();
                    //--------------------------------------------END

                    // -------------------------------------------ADDED BY MR.A FOR TOTAL MONTH WISE COUNT
                    string CurrentMonthDonePatternSample = dtDelayDetails.Rows[0]["CurrentMonthDonePatternSample"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["CurrentMonthDonePatternSample"].ToString();
                    string NextMonthDonePatternSample = dtDelayDetails.Rows[0]["NextMonthDonePatternSample"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["NextMonthDonePatternSample"].ToString();
                    string NextToNextMonthDonePatternSample = dtDelayDetails.Rows[0]["NextToNextMonthDonePatternSample"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["NextToNextMonthDonePatternSample"].ToString();
                    //  string CurrentMonthAdd3MonthesDonePatternSample = dtDelayDetails.Rows[0]["CurrentMonthAdd3MonthesDoneDonePatternSample"].ToString() == "" ? "0" : dtDelayDetails.Rows[0]["CurrentMonthAdd3MonthesDoneDonePatternSample"].ToString();



                    //--------------------------------------------END

                    string tablestring = "";


                    if (hdnStatusModeId.Value != "9999")
                    {
                        PercentDelay = PercentDelay.ToString() == "" ? "0" : PercentDelay;

                        tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' width='100%' border='0' style='border-collapse:collapse; text-align:center;font-size: 11px;'>";

                        if (Convert.ToInt32(hdnStatusModeId.Value) == 63)
                        {
                            AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                            // OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                            MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                            PercentDelay = PercentDelay == "0" ? "" : PercentDelay;
                            if (Convert.ToDecimal(MaxDelayDay) <= Convert.ToDecimal(PercentDelay))
                            {
                                if (Convert.ToDecimal(AvgDlyDay) <= Convert.ToDecimal(PercentDelay))
                                {
                                    tablestring = tablestring + "<tr><td style='height:25px;color:black;font-weight:bold;border-right:1px solid #bfbfbf; width:33%'>" + PercentDelay + " </td><td id='tdStchActOB' runat='server' style='height:25px; width:33%;border-right:1px solid #bfbfbf;color:black; background:#67aa67;'> " + AvgDlyDay + "</td> <td id='tdFinActOB' runat='server' style='color:black;height:25px; width:34%;background:#67aa67;'> " + MaxDelayDay + "</td>   </tr>";
                                }
                                else
                                {
                                    tablestring = tablestring + "<tr><td style='height:25px;color:black;font-weight:bold;border-right:1px solid #bfbfbf; width:33%'>" + PercentDelay + " </td><td id='tdStchActOB' runat='server' style='height:25px; width:33%;border-right:1px solid #bfbfbf; background:#f88585;'> " + AvgDlyDay + "</td> <td id='tdFinActOB' runat='server' style='color:black;height:25px; width:34%;background:#67aa67;'> " + MaxDelayDay + "</td>   </tr>";

                                }
                            }
                            else
                            {
                                if (Convert.ToDecimal(AvgDlyDay) <= Convert.ToDecimal(PercentDelay))
                                {
                                    tablestring = tablestring + "<tr><td style='height:25px;color:black;font-weight:bold;border-right:1px solid #bfbfbf; width:33%'>" + PercentDelay + " </td><td id='tdStchActOB' runat='server' style='height:25px; width:33%;border-right:1px solid #bfbfbf;background:#67aa67;'> " + AvgDlyDay + "</td> <td id='tdFinActOB' runat='server' style='color:black;height:25px; width:34%;background:#f88585;'> " + MaxDelayDay + "</td>   </tr>";
                                }
                                else
                                {
                                    tablestring = tablestring + "<tr><td style='height:25px;color:black;font-weight:bold;border-right:1px solid #bfbfbf; width:33%'>" + PercentDelay + " </td><td id='tdStchActOB' runat='server' style='height:25px; width:33%;border-right:1px solid #bfbfbf; background:#f88585;'> " + AvgDlyDay + "</td> <td id='tdFinActOB' runat='server' style='color:black;height:25px; width:34%;background:#f88585;'> " + MaxDelayDay + "</td>   </tr>";
                                }
                            }

                            // AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                            // OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                            // MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                            // PercentDelay = PercentDelay == "" ? "0" : PercentDelay;
                        }
                        //added by abhishek ---------------------
                        else if (Convert.ToInt32(hdnStatusModeId.Value) == 79)
                        {
                            AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                            MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                            PercentDelay = PercentDelay == "0" ? "" : PercentDelay;


                            var TotalDone = Convert.ToDecimal(CurrentMonthDone) + Convert.ToDecimal(NextMonthDone) + Convert.ToDecimal(NextToNextMonthDone) + Convert.ToDecimal(CurrentMonthAdd3MonthesDone);
                            var TotalPending = Convert.ToDecimal(CurrentMonthPending) + Convert.ToDecimal(NextMonthPending) + Convert.ToDecimal(NextToNextMonthPending) + Convert.ToDecimal(CurrentMonthAdd3MonthesPending);

                            var TotalDonePatternSample = Convert.ToDecimal(CurrentMonthDonePatternSample) + Convert.ToDecimal(NextMonthDonePatternSample) + Convert.ToDecimal(NextToNextMonthDonePatternSample);

                            var TotalDone_styleCode = Convert.ToDecimal(CurrentMonthDone_Stylecode) + Convert.ToDecimal(NextMonthDone_Stylecode) + Convert.ToDecimal(NextToNextMonthDone_Stylecode);
                            var TotalPending_styleCode = Convert.ToDecimal(CurrentMonthPending_Stylecode) + Convert.ToDecimal(NextMonthPending_Stylecode) + Convert.ToDecimal(NextToNextMonthPending_Stylecode);

                            var TotalDonePatternSample_styleCode = Convert.ToDecimal(CurrentMonthDonePatternSample_Stylecode) + Convert.ToDecimal(NextMonthDonePatternSample_Stylecode) + Convert.ToDecimal(NextToNextMonthDonePatternSample_Stylecode);
                           

                           // var TotalDoneBIH = 0;

                            CurrentMonthDone = CurrentMonthDone == "0" ? "" : CurrentMonthDone;
                            CurrentMonthPending = CurrentMonthPending == "0" ? "" : CurrentMonthPending;
                            NextMonthDone = NextMonthDone == "0" ? "" : NextMonthDone;
                            NextMonthPending = NextMonthPending == "0" ? "" : NextMonthPending;
                            NextToNextMonthDone = NextToNextMonthDone == "0" ? "" : NextToNextMonthDone;
                            NextToNextMonthPending = NextToNextMonthPending == "0" ? "" : NextToNextMonthPending;
                            CurrentMonthAdd3MonthesPending = CurrentMonthAdd3MonthesPending == "0" ? "" : CurrentMonthAdd3MonthesPending;
                            CurrentMonthAdd3MonthesDone = CurrentMonthAdd3MonthesDone == "0" ? "" : CurrentMonthAdd3MonthesDone;

                            CurrentMonthDonePatternSample = CurrentMonthDonePatternSample == "0" ? "" : CurrentMonthDonePatternSample;
                            NextMonthDonePatternSample = NextMonthDonePatternSample == "0" ? "" : NextMonthDonePatternSample;
                            NextToNextMonthDonePatternSample = NextToNextMonthDonePatternSample == "0" ? "" : NextToNextMonthDonePatternSample;
                            // CurrentMonthAdd3MonthesDonePatternSample = CurrentMonthAdd3MonthesDonePatternSample == "0" ? "" : CurrentMonthAdd3MonthesDonePatternSample;

                            CurrentMonthDone_Stylecode = CurrentMonthDone_Stylecode == "0" ? "" : CurrentMonthDone_Stylecode;
                            CurrentMonthPending_Stylecode = CurrentMonthPending_Stylecode == "0" ? "" : CurrentMonthPending_Stylecode;
                            CurrentMonthDonePatternSample_Stylecode = CurrentMonthDonePatternSample_Stylecode == "0" ? "" : CurrentMonthDonePatternSample_Stylecode;
                            NextMonthDone_Stylecode = NextMonthDone_Stylecode == "0" ? "" : NextMonthDone_Stylecode;
                            NextMonthPending_Stylecode = NextMonthPending_Stylecode == "0" ? "" : NextMonthPending_Stylecode;
                            NextMonthDonePatternSample_Stylecode = NextMonthDonePatternSample_Stylecode == "0" ? "" : NextMonthDonePatternSample_Stylecode;
                            NextToNextMonthDone_Stylecode = NextToNextMonthDone_Stylecode == "0" ? "" : NextToNextMonthDone_Stylecode;
                            NextToNextMonthPending_Stylecode = NextToNextMonthPending_Stylecode == "0" ? "" : NextToNextMonthPending_Stylecode;
                            NextToNextMonthDonePatternSample_Stylecode = NextToNextMonthDonePatternSample_Stylecode == "0" ? "" : NextToNextMonthDonePatternSample_Stylecode;
                          
                            if (Convert.ToDecimal(MaxDelayDay) <= Convert.ToDecimal(PercentDelay))
                            {
                                if (Convert.ToDecimal(AvgDlyDay) <= Convert.ToDecimal(PercentDelay))
                                {
                                    tablestring = tablestring + "<tr><td style='height:14px;color:black;font-weight:bold;border-right:1px solid #bfbfbf; width:33%'>" + PercentDelay + " </td><td id='tdStchActOB' runat='server' style='height:14px; width:33%;border-right:1px solid #bfbfbf;color:black; background:#67aa67;'> " + AvgDlyDay + "</td> <td id='tdFinActOB' runat='server' style='color:black;height:14px; width:34%;background:#67aa67;'> " + MaxDelayDay + "</td> </tr>";
                                    //tablestring = tablestring + "<tr><td colspan='3'><table cellpadding='0' cellspacing='0' width='100%' border='0'> <tr><td width='50%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;border-top:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> Ex. Month</td> <td width='25%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>Comp.</td> <td width='25%' style='border-top:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>Pend.</td>  </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + CurrentMonth + " & Bef.</td><td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;'> " + CurrentMonthDone + "</td><td style='color:black;border-bottom:1px solid #bfbfbf;font-size:11px;'> " + CurrentMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextMonth + " </td> <td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;'> " + NextMonthDone + "</td><td style='color:black;border-bottom:1px solid #bfbfbf; font-size:11px;'> " + NextMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextToNextMonth + " </td><td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;'> " + NextToNextMonthDone + "</td><td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;'> " + NextToNextMonthPending + "</td></tr><tr><td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E;border-bottom:1px solid #bfbfbf; '> " + nextToNextaddMonth + " </td><td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;'> " + CurrentMonthAdd3MonthesDone + "</td><td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;' > " + CurrentMonthAdd3MonthesPending + "</td></tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E;font-weight:bold; '> Total </td><td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;'> " + TotalDone + "</td><td style='color:black;font-size:11px;font-weight:bold;' > " + TotalPending + "</td></tr> </table> </td></tr>";
                                    tablestring = tablestring +

                                  "<tr><td colspan='3'>" +
                                        "<table cellpadding='0' cellspacing='0' width='100%' border='0'>" +
                                             "<tr>" +
                                              "<td width='28%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;border-top:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' rowspan='3'> Ex. Month</td>" +
                                               "<td width='36%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' colspan='3'>Style Code</td>" +
                                                "<td width='36%' style='border-top:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' colspan='3'>Style No.</td>" +
                                           "</tr>" +
                                           "<tr>" +
                                               "<td width='24%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' colspan='2'>Complete</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' rowspan='2'>STC Pend.</td>" +
                                                "<td width='24%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' colspan='2'>Complete</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' rowspan='2'>STC Pend.</td>" +

                                                "</tr>" +

                                           "<tr>" +
                                              "<td width='12%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>STC</td>" +
                                        //"<td width='15%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'>BIH</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>PS</td>" +
                                            "<td width='12%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>STC</td>" +
                                        //"<td width='15%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'>BIH</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>PS</td>" +


                                                "</tr>" +
                                           "<tr>" +
                                              "<td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + CurrentMonth + " & Bef.</td>" +
                                              "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDone_Stylecode + "</td>" +
                                        //"<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;display:none;'> " + "" + "</td>" +
                                              "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDonePatternSample_Stylecode + "</td>" +
                                              "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + CurrentMonthPending_Stylecode + "</td>" +
                                           "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDone + "</td>" +
                                        //"<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;display:none;'> " + "" + "</td>" +
                                              "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDonePatternSample + "</td>" +
                                              "<td style='color: #7E7E7E;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + CurrentMonthPending + "</td>" +

                                              "</tr>" +
                                           "<tr>" +
                                              "<td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextMonth + " </td>" +
                                              "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDone_Stylecode + "</td>" +
                                        //"<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;display:none;'> " + "" + "</td>" +
                                                "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDonePatternSample_Stylecode + "</td>" +
                                             "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + NextMonthPending_Stylecode + "</td>" +
                                            "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDone + "</td>" +
                                        //"<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;display:none;'> " + "" + "</td>" +
                                                "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDonePatternSample + "</td>" +
                                             "<td style='color: #7E7E7E;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + NextMonthPending + "</td>" +


                                             "</tr>" +
                                           "<tr>" +
                                              "<td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextToNextMonth + " </td>" +
                                              "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextToNextMonthDone_Stylecode + "</td>" +
                                        //"<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;display:none;'> " + "" + "</td>" +
                                                "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextToNextMonthDonePatternSample_Stylecode + "</td>" +
                                              "<td style='color:black;font-size:11px;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;text-align:center'> " + NextToNextMonthPending_Stylecode + "</td>" +
                                            "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextToNextMonthDone + "</td>" +
                                        //"<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;display:none;'> " + "" + "</td>" +
                                                "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextToNextMonthDonePatternSample + "</td>" +
                                              "<td style='color: #7E7E7E;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + NextToNextMonthPending + "</td>" +


                                              "</tr>" +
                                        //"<tr>"+
                                        //   "<td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E;border-bottom:1px solid #bfbfbf; '> " + nextToNextaddMonth + " </td>"+
                                        //   "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDone + "</td>" +

                                           //    //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;display:none;'> " + "" + "</td>" +
                                        //     "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDonePatternSample + "</td>" +

                                           //   "<td style='color:black;font-size:11px;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;text-align:center' > " + CurrentMonthAdd3MonthesPending + "</td>" +
                                        //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDone + "</td>" +

                                           //    //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;display:none;'> " + "" + "</td>" +
                                        //     "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDonePatternSample + "</td>" +

                                           //   "<td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center' > " + CurrentMonthAdd3MonthesPending + "</td>" +


                                           //   "</tr>"+
                                           "<tr>" +
                                              "<td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E;font-weight:bold; '> Total </td>" +
                                              "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDone_styleCode + "</td>" +
                                        //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;display:none;'> " + "" + "</td>" +
                                              "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDonePatternSample_styleCode + "</td>" +
                                              "<td style='color:black;font-size:11px;font-weight:bold;text-align:center;border-right:1px solid #bfbfbf;' > " + TotalPending_styleCode + "</td>" +
                                            "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDone + "</td>" +
                                        //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;display:none;'> " + "" + "</td>" +
                                              "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDonePatternSample + "</td>" +
                                              "<td style='color:black;font-size:11px;font-weight:bold;text-align:center' > " + TotalPending + "</td>" +


                                              "</tr>" +
                                        "</table>" +
                                     "</td>" +
                                  "</tr>";
                                }
                                else
                                {
                                    tablestring = tablestring + "<tr><td style='height:14px;color:black;font-weight:bold;border-right:1px solid #bfbfbf; width:33%'>" + PercentDelay + " </td><td id='tdStchActOB' runat='server' style='height:14px; width:33%;border-right:1px solid #bfbfbf;color:black; background:#f88585;'> " + AvgDlyDay + "</td> <td id='tdFinActOB' runat='server' style='color:black;height:14px; width:34%;background:#67aa67;'> " + MaxDelayDay + "</td>   </tr>";
                                    //tablestring = tablestring + "<tr><td colspan='3'><table cellpadding='0' cellspacing='0' width='100%' border='0'> <tr><td width='50%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;border-top:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> Ex. Month</td> <td width='25%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>Comp.</td> <td width='25%' style='border-top:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>Pend.</td>  </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + CurrentMonth + " & Bef.</td><td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;'> " + CurrentMonthDone + "</td><td style='color:black;border-bottom:1px solid #bfbfbf;font-size:11px;'> " + CurrentMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextMonth + " </td> <td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;'> " + NextMonthDone + "</td><td style='color:black;border-bottom:1px solid #bfbfbf; font-size:11px;'> " + NextMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextToNextMonth + " </td><td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;'> " + NextToNextMonthDone + "</td><td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;'> " + NextToNextMonthPending + "</td></tr><tr><td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E;border-bottom:1px solid #bfbfbf; '> " + nextToNextaddMonth + " </td><td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;'> " + CurrentMonthAdd3MonthesDone + "</td><td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;' > " + CurrentMonthAdd3MonthesPending + "</td></tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E;font-weight:bold; '> Total </td><td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;'> " + TotalDone + "</td><td style='color:black;font-size:11px;font-weight:bold;' > " + TotalPending + "</td></tr></table> </td></tr>";
                                    tablestring = tablestring + "<tr><td colspan='3'>" +
                                        "<table cellpadding='0' cellspacing='0' width='100%' border='0'>" +
                                                  "<tr>" +
                                              "<td width='28%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;border-top:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' rowspan='3'> Ex. Month</td>" +
                                               "<td width='36%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' colspan='3'>Style Code</td>" +
                                                "<td width='36%' style='border-top:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' colspan='3'>Style No.</td>" +
                                           "</tr>" +
                                           "<tr>" +
                                               "<td width='24%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' colspan='2'>Complete</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' rowspan='2'>STC Pend.</td>" +
                                                "<td width='24%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' colspan='2'>Complete</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' rowspan='2'>STC Pend.</td>" +

                                                "</tr>" +

                                           "<tr>" +
                                              "<td width='12%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>STC</td>" +
                                        //"<td width='15%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'>BIH</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>PS</td>" +
                                            "<td width='12%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>STC</td>" +
                                        //"<td width='15%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'>BIH</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>PS</td>" +


                                                "</tr>" +
                                             "<tr>" +
                                                "<td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + CurrentMonth + " & Bef.</td>" +
                                               "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDone_Stylecode + "</td>" +

                                                //"<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;display:none;'> " + "" + "</td>" +
                                                 "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDonePatternSample_Stylecode + "</td>" +
                                               "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + CurrentMonthPending_Stylecode + "</td>" +
                                             "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDone + "</td>" +

                                                //"<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;display:none;'> " + "" + "</td>" +
                                                 "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDonePatternSample + "</td>" +
                                               "<td style='color: #7E7E7E;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + CurrentMonthPending + "</td>" +


                                               "</tr>" +
                                             "<tr>" +
                                                "<td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextMonth + " </td>" +
                                                "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDone_Stylecode + "</td>" +

                                                //"<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;display:none;'> " + "" + "</td>" +
                                                "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDonePatternSample_Stylecode + "</td>" +

                                                "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + NextMonthPending_Stylecode + "</td>" +
                                              "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDone + "</td>" +

                                                //"<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;display:none;'> " + "" + "</td>" +
                                                "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDonePatternSample + "</td>" +

                                                "<td style='color: #7E7E7E;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + NextMonthPending + "</td>" +


                                                "</tr>" +
                                             "<tr>" +
                                                "<td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextToNextMonth + " </td>" +
                                                "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextToNextMonthDone_Stylecode + "</td>" +

                                                //"<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;display:none;'> " + "" + "</td>" +
                                                "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextToNextMonthDonePatternSample_Stylecode + "</td>" +

                                                "<td style='color:black;font-size:11px;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;text-align:center'> " + NextToNextMonthPending_Stylecode + "</td>" +
                                             "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextToNextMonthDone + "</td>" +

                                                //"<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;display:none;'> " + "" + "</td>" +
                                                "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextToNextMonthDonePatternSample + "</td>" +

                                                "<td style='color: #7E7E7E;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + NextToNextMonthPending + "</td>" +


                                                "</tr>" +
                                        //"<tr>"+
                                        //   "<td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E;border-bottom:1px solid #bfbfbf; '> " + nextToNextaddMonth + " </td>"+
                                        //   "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDone + "</td>" +

                                             //   //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;display:none;'> " + "" + "</td>" +
                                        //   "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDonePatternSample + "</td>" +

                                             //   "<td style='color:black;font-size:11px;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;text-align:center' > " + CurrentMonthAdd3MonthesPending + "</td>" +
                                        // "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDone + "</td>" +

                                             //   //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;display:none;'> " + "" + "</td>" +
                                        //   "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDonePatternSample + "</td>" +

                                             //   "<td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center' > " + CurrentMonthAdd3MonthesPending + "</td>" +


                                             //   "</tr>"+
                                             "<tr>" +
                                                "<td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E;font-weight:bold; '> Total </td>" +
                                                "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDone_styleCode + "</td>" +
                                        //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;display:none;'> " + "" + "</td>" +
                                                "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDonePatternSample_styleCode + "</td>" +

                                                "<td style='color:black;font-size:11px;font-weight:bold;text-align:center;border-right:1px solid #bfbfbf;' > " + TotalPending_styleCode + "</td>" +
                                              "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDone + "</td>" +
                                        //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;display:none;'> " + "" + "</td>" +
                                                "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDonePatternSample + "</td>" +

                                                "<td style='color:black;font-size:11px;font-weight:bold;text-align:center' > " + TotalPending + "</td>" +


                                                "</tr>" +
                                          "</table>" +
                                       "</td>" +
                                    "</tr>";
                                }
                            }
                            else
                            {
                                if (Convert.ToDecimal(AvgDlyDay) <= Convert.ToDecimal(PercentDelay))
                                {
                                    tablestring = tablestring + "<tr><td style='height:14px;color:black;font-weight:bold;border-right:1px solid #bfbfbf; width:33%'>" + PercentDelay + " </td><td id='tdStchActOB' runat='server' style='height:14px; width:33%;border-right:1px solid #bfbfbf; color:black; background:#67aa67;'> " + AvgDlyDay + "</td> <td id='tdFinActOB' runat='server' style='color:black;height:14px; width:34%;background:#f88585;'> " + MaxDelayDay + "</td>   </tr>";
                                    tablestring = tablestring + "<tr><td colspan='3'>" +
                                         "<table cellpadding='0' cellspacing='0' width='100%' border='0'>" +
                                              "<tr>" +
                                              "<td width='28%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;border-top:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' rowspan='3'> Ex. Month</td>" +
                                               "<td width='36%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' colspan='3'>Style Code</td>" +
                                                "<td width='36%' style='border-top:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' colspan='3'>Style No.</td>" +
                                           "</tr>" +
                                           "<tr>" +
                                               "<td width='24%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' colspan='2'>Complete</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' rowspan='2'>STC Pend.</td>" +
                                                "<td width='24%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' colspan='2'>Complete</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' rowspan='2'>STC Pend.</td>" +

                                                "</tr>" +

                                           "<tr>" +
                                              "<td width='12%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>STC</td>" +
                                        //"<td width='15%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'>BIH</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>PS</td>" +
                                            "<td width='12%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>STC</td>" +
                                        //"<td width='15%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'>BIH</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>PS</td>" +


                                                "</tr>" +
                                "<tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + CurrentMonth + " & Bef.</td>" +
                                "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDone_Stylecode + "</td>" +

                                //"<td  style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                "<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + CurrentMonthDonePatternSample_Stylecode + "</td>" +


                                "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + CurrentMonthPending_Stylecode + "</td> " +
                                 "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDone + "</td>" +

                                //"<td  style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                "<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + CurrentMonthDonePatternSample + "</td>" +


                                "<td style='color: #7E7E7E;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + CurrentMonthPending + "</td> " +


                                "</tr>" +

                                "<tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextMonth + " </td> " +
                                "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDone_Stylecode + "</td>" +

                                //"<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                "<td  style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + NextMonthDonePatternSample_Stylecode + "</td>" +

                                "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthPending_Stylecode + "</td> " +
                               "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDone + "</td>" +

                                //"<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                "<td  style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + NextMonthDonePatternSample + "</td>" +

                                "<td style='color: #7E7E7E;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthPending + "</td> " +

                                "</tr>" +

                                "<tr>" +
                                "<td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextToNextMonth + " </td>" +
                                "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + NextToNextMonthDone_Stylecode + "</td>" +

                                //"<td  style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                "<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + NextToNextMonthDonePatternSample_Stylecode + "</td>" +

                                "<td style='color:black;font-size:11px;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;text-align:center'> " + NextToNextMonthPending_Stylecode + "</td>" +
                                 "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + NextToNextMonthDone + "</td>" +

                                //"<td  style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                "<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + NextToNextMonthDonePatternSample + "</td>" +

                                "<td style='color: #7E7E7E;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + NextToNextMonthPending + "</td>" +


                                "</tr>" +

                                //"<tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;color: #7E7E7E; '> " + nextToNextaddMonth + " </td>" +
                                        //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDone + "</td>" +

                                ////"<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                        //"<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + CurrentMonthAdd3MonthesDonePatternSample + "</td>" +

                                //"<td style='color:black;font-size:11px;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;text-align:center' > " + CurrentMonthAdd3MonthesPending + "</td>" +
                                        //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDone + "</td>" +

                                ////"<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                        //"<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + CurrentMonthAdd3MonthesDonePatternSample + "</td>" +

                                //"<td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center' > " + CurrentMonthAdd3MonthesPending + "</td>" +

                                //"</tr>" +

                                "<tr><td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E; font-weight:bold;'> Total </td>" +
                                "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDone_styleCode + "</td>" +

                                //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;display:none;'> " + "" + "</td>" +
                                "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDonePatternSample_styleCode + "</td>" +

                                "<td style='color:black;font-size:11px;font-weight:bold;text-align:center;border-right:1px solid #bfbfbf;' > " + TotalPending_styleCode + "</td>" +

                                 "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDone + "</td>" +

                                //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;display:none;'> " + "" + "</td>" +
                                "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDonePatternSample + "</td>" +

                                "<td style='color:black;font-size:11px;font-weight:bold;text-align:center' > " + TotalPending + "</td></tr> </table> </td></tr>";
                                }
                                else
                                {
                                    tablestring = tablestring + "<tr><td style='height:14px;color:black;font-weight:bold;border-right:1px solid #bfbfbf; width:33%'>" + PercentDelay + " </td><td id='tdStchActOB' runat='server' style='height:14px; width:33%;border-right:1px solid #bfbfbf; color:black; background:#f88585;'> " + AvgDlyDay + "</td> <td id='tdFinActOB' runat='server' style='color:black;height:14px; width:34%;background:#f88585;'> " + MaxDelayDay + "</td>   </tr>";
                                    //tablestring = tablestring + "<tr><td colspan='3'><table cellpadding='0' cellspacing='0' width='100%' border='0'> <tr><td width='50%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;border-top:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> Ex. Month</td> <td width='25%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>Comp.</td> <td width='25%' style='border-top:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>Pend.</td>  </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + CurrentMonth + " & Bef.</td><td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;'> " + CurrentMonthDone + "</td><td style='color:black;border-bottom:1px solid #bfbfbf;font-size:11px;'> " + CurrentMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextMonth + " </td> <td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;'> " + NextMonthDone + "</td><td style='color:black;border-bottom:1px solid #bfbfbf;font-size:11px;'> " + NextMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextToNextMonth + " </td><td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;'> " + NextToNextMonthDone + "</td><td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;'> " + NextToNextMonthPending + "</td></tr><tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;color: #7E7E7E; '> " + nextToNextaddMonth + " </td><td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;'> " + CurrentMonthAdd3MonthesDone + "</td><td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;' > " + CurrentMonthAdd3MonthesPending + "</td></tr><tr><td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E; font-weight:bold;'> Total </td><td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;'> " + TotalDone + "</td><td style='color:black;font-size:11px;font-weight:bold;' > " + TotalPending + "</td></tr> </table> </td></tr>";
                                    tablestring = tablestring + "<tr><td colspan='3'>" +
                                        "<table cellpadding='0' cellspacing='0' width='100%' border='0'>" +
                                                 "<tr>" +
                                              "<td width='28%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;border-top:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' rowspan='3'> Ex. Month</td>" +
                                               "<td width='36%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' colspan='3'>Style Code</td>" +
                                                "<td width='36%' style='border-top:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' colspan='3'>Style No.</td>" +
                                           "</tr>" +
                                           "<tr>" +
                                               "<td width='24%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf; color: #7E7E7E; font-size:11px;' colspan='2'>Complete</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' rowspan='2'>STC Pend.</td>" +
                                                "<td width='24%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' colspan='2'>Complete</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;' rowspan='2'>STC Pend.</td>" +

                                                "</tr>" +

                                           "<tr>" +
                                              "<td width='12%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>STC</td>" +
                                        //"<td width='15%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'>BIH</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>PS</td>" +
                                            "<td width='12%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>STC</td>" +
                                        //"<td width='15%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'>BIH</td>" +
                                                "<td width='12%' style='border-bottom:1px solid #bfbfbf;border-right:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>PS</td>" +


                                                "</tr>" +
                                "<tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + CurrentMonth + " & Bef.</td>" +
                                "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDone_Stylecode + "</td>" +

                                //"<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                "<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + CurrentMonthDonePatternSample_Stylecode + "</td>" +


                                "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + CurrentMonthPending_Stylecode + "</td> " +
                                 "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDone + "</td>" +

                                //"<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                "<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + CurrentMonthDonePatternSample + "</td>" +


                                "<td style='color: #7E7E7E;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + CurrentMonthPending + "</td> " +


                                "</tr>" +

                                "<tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextMonth + " </td> " +
                                "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDone + "</td>" +

                                //"<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                "<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + NextMonthDonePatternSample_Stylecode + "</td>" +

                                "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthPending_Stylecode + "</td> " +
                                "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDone + "</td>" +

                                //"<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                "<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + NextMonthDonePatternSample + "</td>" +

                                "<td style='color: #7E7E7E;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthPending + "</td> " +


                                "</tr>" +

                                "<tr>" +
                                "<td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextToNextMonth + " </td>" +
                                "<td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + NextToNextMonthDone_Stylecode + "</td>" +

                                //"<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                "<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + NextToNextMonthDonePatternSample_Stylecode + "</td>" +

                                "<td style='color:black;font-size:11px;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;text-align:center'> " + NextToNextMonthPending_Stylecode + "</td>" +
                                "<td style='color: #7E7E7E;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + NextToNextMonthDone + "</td>" +

                                //"<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                "<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + NextToNextMonthDonePatternSample + "</td>" +

                                "<td style='color: #7E7E7E;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + NextToNextMonthPending + "</td>" +

                                "</tr>" +

                               // "<tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;color: #7E7E7E; '> " + nextToNextaddMonth + " </td>" +
                                        // "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDone + "</td>" +

                               // //"<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                        // "<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + CurrentMonthAdd3MonthesDonePatternSample + "</td>" +

                               // "<td style='color:black;font-size:11px;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;text-align:center' > " + CurrentMonthAdd3MonthesPending + "</td>" +
                                        //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDone + "</td>" +

                               // //"<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;display:none;'> " + "" + " </td>" +
                                        // "<td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;text-align:center'> " + CurrentMonthAdd3MonthesDonePatternSample + "</td>" +

                               // "<td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center' > " + CurrentMonthAdd3MonthesPending + "</td>" +

                               // "</tr>" +

                                "<tr><td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E; font-weight:bold;'> Total </td>" +
                                "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDone_styleCode + "</td>" +

                                //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;display:none;'> " + "" + "</td>" +
                                "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDonePatternSample_styleCode + "</td>" +

                                "<td style='color:black;font-size:11px;font-weight:bold;text-align:center;border-right:1px solid #bfbfbf;' > " + TotalPending_styleCode + "</td>" +

                                 "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDone + "</td>" +

                                //"<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;display:none;'> " + "" + "</td>" +
                                "<td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDonePatternSample + "</td>" +

                                "<td style='color:black;font-size:11px;font-weight:bold;text-align:center' > " + TotalPending + "</td></tr> </table> </td></tr>";
                                }
                            }
                        }//end abhishek
                        else
                        {
                            AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                            // OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                            MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                            PercentDelay = PercentDelay == "0" ? "" : PercentDelay;


                            var TotalDone = Convert.ToDecimal(CurrentMonthDone) + Convert.ToDecimal(NextMonthDone) + Convert.ToDecimal(NextToNextMonthDone) + Convert.ToDecimal(CurrentMonthAdd3MonthesDone);
                            var TotalPending = Convert.ToDecimal(CurrentMonthPending) + Convert.ToDecimal(NextMonthPending) + Convert.ToDecimal(NextToNextMonthPending) + Convert.ToDecimal(CurrentMonthAdd3MonthesPending);
                            var TotalDone_styleCode = Convert.ToDecimal(CurrentMonthDone_Stylecode) + Convert.ToDecimal(NextMonthDone_Stylecode) + Convert.ToDecimal(NextToNextMonthDone_Stylecode);
                            var TotalPending_styleCode = Convert.ToDecimal(CurrentMonthPending_Stylecode) + Convert.ToDecimal(NextMonthPending_Stylecode) + Convert.ToDecimal(NextToNextMonthPending_Stylecode);

                            CurrentMonthDone = CurrentMonthDone == "0" ? "" : CurrentMonthDone;
                            CurrentMonthPending = CurrentMonthPending == "0" ? "" : CurrentMonthPending;
                            NextMonthDone = NextMonthDone == "0" ? "" : NextMonthDone;
                            NextMonthPending = NextMonthPending == "0" ? "" : NextMonthPending;
                            NextToNextMonthDone = NextToNextMonthDone == "0" ? "" : NextToNextMonthDone;
                            NextToNextMonthPending = NextToNextMonthPending == "0" ? "" : NextToNextMonthPending;
                            CurrentMonthAdd3MonthesPending = CurrentMonthAdd3MonthesPending == "0" ? "" : CurrentMonthAdd3MonthesPending;
                            CurrentMonthAdd3MonthesDone = CurrentMonthAdd3MonthesDone == "0" ? "" : CurrentMonthAdd3MonthesDone;



                            if (Convert.ToDecimal(MaxDelayDay) <= Convert.ToDecimal(PercentDelay))
                            {
                                if (Convert.ToDecimal(AvgDlyDay) <= Convert.ToDecimal(PercentDelay))
                                {
                                    tablestring = tablestring + "<tr><td style='height:14px;color:black;font-weight:bold;border-right:1px solid #bfbfbf; width:33%'>" + PercentDelay + " </td><td id='tdStchActOB' runat='server' style='height:14px; width:33%;border-right:1px solid #bfbfbf;color:black; background:#67aa67;'> " + AvgDlyDay + "</td> <td id='tdFinActOB' runat='server' style='color:black;height:14px; width:34%;background:#67aa67;'> " + MaxDelayDay + "</td>   </tr>";
                                    tablestring = tablestring + "<tr><td colspan='3'><table cellpadding='0' cellspacing='0' width='100%' border='0'> <tr><td width='43%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;border-top:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> Ex. Month</td> <td width='32%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>Complete</td> <td width='31%' style='border-top:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>Pend.</td>  </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + CurrentMonth + " & Bef.</td><td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDone + "</td><td style='color:black;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + CurrentMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextMonth + " </td> <td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDone + "</td><td style='color:black;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + NextMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextToNextMonth + " </td><td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextToNextMonthDone + "</td><td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + NextToNextMonthPending + "</td></tr>"
                                        //+"<tr><td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E;border-bottom:1px solid #bfbfbf; '> " + nextToNextaddMonth + " </td><td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDone + "</td><td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center' > " + CurrentMonthAdd3MonthesPending + "</td></tr>"+ 
                                       + "<tr><td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E;font-weight:bold; '> Total </td><td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDone + "</td><td style='color:black;font-size:11px;font-weight:bold;text-align:center' > " + TotalPending + "</td></tr> </table> </td></tr>";
                                }
                                else
                                {
                                    tablestring = tablestring + "<tr><td style='height:14px;color:black;font-weight:bold;border-right:1px solid #bfbfbf; width:33%'>" + PercentDelay + " </td><td id='tdStchActOB' runat='server' style='height:14px; width:33%;border-right:1px solid #bfbfbf;color:black; background:#f88585;'> " + AvgDlyDay + "</td> <td id='tdFinActOB' runat='server' style='color:black;height:14px; width:34%;background:#67aa67;'> " + MaxDelayDay + "</td>   </tr>";
                                    tablestring = tablestring + "<tr><td colspan='3'><table cellpadding='0' cellspacing='0' width='100%' border='0'> <tr><td width='43%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;border-top:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> Ex. Month</td> <td width='32%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>Complete</td> <td width='31%' style='border-top:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>Pend.</td>  </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + CurrentMonth + " & Bef.</td><td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDone + "</td><td style='color:black;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + CurrentMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextMonth + " </td> <td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDone + "</td><td style='color:black;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + NextMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextToNextMonth + " </td><td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextToNextMonthDone + "</td><td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + NextToNextMonthPending + "</td></tr>"
                                        //+"<tr><td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E;border-bottom:1px solid #bfbfbf; '> " + nextToNextaddMonth + " </td><td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDone + "</td><td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center' > " + CurrentMonthAdd3MonthesPending + "</td></tr>"
                                        + " <tr><td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E;font-weight:bold; '> Total </td><td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDone + "</td><td style='color:black;font-size:11px;font-weight:bold;text-align:center' > " + TotalPending + "</td></tr></table> </td></tr>";
                                }
                            }
                            else
                            {
                                if (Convert.ToDecimal(AvgDlyDay) <= Convert.ToDecimal(PercentDelay))
                                {
                                    tablestring = tablestring + "<tr><td style='height:14px;color:black;font-weight:bold;border-right:1px solid #bfbfbf; width:33%'>" + PercentDelay + " </td><td id='tdStchActOB' runat='server' style='height:14px; width:33%;border-right:1px solid #bfbfbf; color:black; background:#67aa67;'> " + AvgDlyDay + "</td> <td id='tdFinActOB' runat='server' style='color:black;height:14px; width:34%;background:#f88585;'> " + MaxDelayDay + "</td>   </tr>";
                                    tablestring = tablestring + "<tr><td colspan='3'><table cellpadding='0' cellspacing='0' width='100%' border='0'> <tr><td width='43%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;border-top:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> Ex. Month</td> <td width='32%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>Complete</td> <td width='31%' style='border-top:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>Pend.</td>  </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + CurrentMonth + " & Bef.</td><td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDone + "</td><td style='color:black;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + CurrentMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextMonth + " </td> <td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDone + "</td><td style='color:black;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextToNextMonth + " </td><td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + NextToNextMonthDone + "</td><td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + NextToNextMonthPending + "</td></tr>" +
                                        //"<tr><td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E;border-bottom:1px solid #bfbfbf; '> " + nextToNextaddMonth + " </td><td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDone + "</td><td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center' > " + CurrentMonthAdd3MonthesPending + "</td></tr>"+
                                        "<tr><td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E;font-weight:bold; '> Total </td><td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDone + "</td><td style='color:black;font-size:11px;font-weight:bold;text-align:center' > " + TotalPending + "</td></tr> </table> </td></tr>";
                                }
                                else
                                {
                                    tablestring = tablestring + "<tr><td style='height:14px;color:black;font-weight:bold;border-right:1px solid #bfbfbf; width:33%'>" + PercentDelay + " </td><td id='tdStchActOB' runat='server' style='height:14px; width:33%;border-right:1px solid #bfbfbf; color:black; background:#f88585;'> " + AvgDlyDay + "</td> <td id='tdFinActOB' runat='server' style='color:black;height:14px; width:34%;background:#f88585;'> " + MaxDelayDay + "</td>   </tr>";
                                    tablestring = tablestring + "<tr><td colspan='3'><table cellpadding='0' cellspacing='0' width='100%' border='0'> <tr><td width='43%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;border-top:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> Ex. Month</td> <td width='32%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>Complete</td> <td width='31%' style='border-top:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'>Pend.</td>  </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + CurrentMonth + " & Bef.</td><td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + CurrentMonthDone + "</td><td style='color:black;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + CurrentMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextMonth + " </td> <td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthDone + "</td><td style='color:black;border-bottom:1px solid #bfbfbf;font-size:11px;text-align:center'> " + NextMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;color: #7E7E7E; font-size:11px;'> " + nextToNextMonth + " </td><td style='color:black;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf; font-size:11px;text-align:center'> " + NextToNextMonthDone + "</td><td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + NextToNextMonthPending + "</td></tr>"
                                        //+"<tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;font-size:11px;color: #7E7E7E; '> " + nextToNextaddMonth + " </td><td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center'> " + CurrentMonthAdd3MonthesDone + "</td><td style='color:black;font-size:11px;border-bottom:1px solid #bfbfbf;text-align:center' > " + CurrentMonthAdd3MonthesPending + "</td></tr>"
                                        + "<tr><td align='left' style='border-right:1px solid #bfbfbf;font-size:11px;color: #7E7E7E; font-weight:bold;'> Total </td><td style='color:black;border-right:1px solid #bfbfbf;font-size:11px;font-weight:bold;text-align:center'> " + TotalDone + "</td><td style='color:black;font-size:11px;font-weight:bold;text-align:center' > " + TotalPending + "</td></tr> </table> </td></tr>";

                                }
                            }


                            // AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                            // OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                            // MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                            // PercentDelay = PercentDelay == "" ? "0" : PercentDelay;
                        }









                        //if (Convert.ToDecimal(AvgDlyDay) == 0)
                        //{
                        //    AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                        //   // OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                        //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                        //    PercentDelay = PercentDelay == "0" ? "" : PercentDelay;

                        //tablestring = tablestring + "<tr>  <td width='50%' style='border-right:1px solid #bfbfbf;height:28px;color:gray;' rowspan='2'>" + PercentDelay + " </td> <td id='tdStchActOB' runat='server' width='50%' style=' border-bottom:1px solid #bfbfbf;font-weight:bold;height:14px;'> " + AvgDlyDay + "</td>  </tr>";
                        //tablestring = tablestring + "<tr> <td id='tdFinActOB' runat='server' style='color:gray;height:14px;' width='50%'> " + MaxDelayDay + "</td> </tr>";
                        //if (Convert.ToDecimal(OneMonthAvg) < Convert.ToDecimal(PercentDelay))
                        //    tablestring = tablestring + "<tr>  <td width='50%' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;height:14px;color:gray;background:#67aa67;'>" + OneMonthAvg + " </td>";
                        //else
                        //    tablestring = tablestring + "<tr>  <td width='50%' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;height:14px;color:gray;background:#f88585;'>" + OneMonthAvg + " </td>";
                        //tablestring = tablestring + "<td id='tdStchActOB' runat='server' width='50%' style=' border-bottom:1px solid #bfbfbf;font-weight:bold;height:14px;'> " + AvgDlyDay + "</td> </tr>";
                        //tablestring = tablestring + "<tr><td width='50%' style='border-right:1px solid #bfbfbf;height:14px;color:gray;'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;height:14px;' width='50%'> " + MaxDelayDay + "</td> </tr>";
                        //tablestring = tablestring + "<tr><td style='height:14px;color:black;font-weight:bold;border-right:1px solid #bfbfbf; width:33%'>" + PercentDelay + " </td><td id='tdStchActOB' runat='server' style='height:14px; width:33%;border-right:1px solid #bfbfbf;'> " + AvgDlyDay + "</td> <td id='tdFinActOB' runat='server' style='color:gray;height:14px; width:34%'> " + MaxDelayDay + "</td>   </tr>";
                        //if (Convert.ToDecimal(OneMonthAvg) < Convert.ToDecimal(PercentDelay))
                        //    tablestring = tablestring + "<tr>  <td style='border-bottom:1px solid #bfbfbf;height:14px;color:gray;background:#67aa67;'>" + OneMonthAvg + " </td></tr>";
                        //else
                        //    tablestring = tablestring + "<tr>  <td style='border-bottom:1px solid #bfbfbf;height:14px;color:gray;background:#f88585;'>" + OneMonthAvg + " </td></tr>";

                        //    if (Convert.ToInt32(hdnStatusModeId.Value) !=63)
                        //        tablestring = tablestring + "<tr><td colspan='3'><table cellpadding='0' cellspacing='0' width='100%' border='0'> <tr><td width='50%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;border-top:1px solid #bfbfbf;'> Ex. Month</td> <td width='25%' style='border-top:1px solid #bfbfbf;border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'>Comp.</td> <td width='25%' style='border-top:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'>Pend.</td>  </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + CurrentMonth + " & Bef.</td><td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + CurrentMonthDone + "</td><td style='border-bottom:1px solid #bfbfbf;'> " + CurrentMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + nextMonth + " </td> <td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + NextMonthDone + "</td><td style='border-bottom:1px solid #bfbfbf;'> " + NextMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + nextToNextMonth + " </td><td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + NextToNextMonthDone + "</td><td style='border-bottom:1px solid #bfbfbf;'> " + NextToNextMonthPending + "</td></tr><tr><td align='left' style='border-right:1px solid #bfbfbf;'> " + nextToNextaddMonth + " </td><td style='border-right:1px solid #bfbfbf;'> " + CurrentMonthAdd3MonthesDone + "</td><td > " + CurrentMonthAdd3MonthesPending + "</td></tr> </table> </td></tr>";



                        //    AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                        //   // OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                        //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                        //    PercentDelay = PercentDelay == "" ? "0" : PercentDelay;
                        //}
                        //else
                        //{
                        //if (Convert.ToDecimal(AvgDlyDay) < Convert.ToDecimal(PercentDelay))
                        //{

                        //    //Delay = Delay == "0" ? "" : Delay;
                        //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                        //    PercentDelay = PercentDelay == "0" ? "" : PercentDelay;
                        //    //OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                        //    //tablestring = tablestring + "<tr>  <td width='50%' style='border-right:1px solid #bfbfbf;height:28px;color:gray' rowspan='2'>" + PercentDelay + " </td> <td id='tdStchActOB' runat='server' width='50%' style=' border-bottom:1px solid #bfbfbf;font-weight:bold; background:#67aa67; color:black;height:14px;'> " + AvgDlyDay + "</td>  </tr>";
                        //    //tablestring = tablestring + "<tr>  <td id='tdFinActOB' runat='server' style='color:gray;height:14px;'> " + MaxDelayDay + "</td> </tr>";
                        //    tablestring = tablestring + "<tr><td style='height:14px;color:black;font-weight:bold;border-bottom:1px solid #bfbfbf; width:33%;border-right:1px solid #bfbfbf;'>" + PercentDelay + " </td><td id='tdStchActOB' runat='server' style=' border-bottom:1px solid #bfbfbf; background:#67aa67; color:black;height:14px; width:33%;border-right:1px solid #bfbfbf;'> " + AvgDlyDay + "</td> <td id='tdFinActOB' runat='server' style='color:gray;height:14px;border-bottom:1px solid #bfbfbf;width:34%'> " + MaxDelayDay + "</td>  </tr>";
                        //    //if (Convert.ToDecimal(OneMonthAvg) < Convert.ToDecimal(PercentDelay))
                        //    //{
                        //    //    OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                        //    //    //tablestring = tablestring + "<tr>  <td width='50%' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;height:14px;color:black;background:#67aa67;'>" + OneMonthAvg + " </td>";
                        //    //    tablestring = tablestring + "<tr>  <td style='border-bottom:1px solid #bfbfbf;height:14px;color:black;background:#67aa67;'>" + OneMonthAvg + " </td></tr>";
                        //    //}
                        //    //else
                        //    //{
                        //    //    OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                        //    //    //tablestring = tablestring + "<tr>  <td width='50%' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;height:14px;color:black;background:#f88585;'>" + OneMonthAvg + " </td>";
                        //    //    tablestring = tablestring + "<tr>  <td style='border-bottom:1px solid #bfbfbf;height:14px;color:black;background:#f88585;'>" + OneMonthAvg + " </td></tr>";
                        //    //}
                        //    if (Convert.ToInt32(hdnStatusModeId.Value) != 63)
                        //        tablestring = tablestring + "<tr><td colspan='3'><table cellpadding='0' cellspacing='0' width='100%' border='0'> <tr><td width='50%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> Ex. Month</td> <td width='25%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'>Comp.</td> <td width='25%' style='border-bottom:1px solid #bfbfbf;'>Pend.</td>  </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + CurrentMonth + " & Bef.</td><td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + CurrentMonthDone + "</td><td style='border-bottom:1px solid #bfbfbf;'> " + CurrentMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + nextMonth + " </td> <td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + NextMonthDone + "</td><td style='border-bottom:1px solid #bfbfbf;'> " + NextMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + nextToNextMonth + " </td><td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + NextToNextMonthDone + "</td><td style='border-bottom:1px solid #bfbfbf;'> " + NextToNextMonthPending + "</td></tr><tr><td align='left' style='border-right:1px solid #bfbfbf;'> " + nextToNextaddMonth + " </td><td style='border-right:1px solid #bfbfbf;'> " + CurrentMonthAdd3MonthesDone + "</td><td > " + CurrentMonthAdd3MonthesPending + "</td></tr> </table> </td></tr>";


                        //   // OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                        //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                        //    PercentDelay = PercentDelay == "" ? "0" : PercentDelay;
                        //}
                        //else
                        //{
                        //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                        //    //OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                        //    // Delay = Delay == "0" ? "" : Delay;
                        //    PercentDelay = PercentDelay == "0" ? "" : PercentDelay;
                        //    //tablestring = tablestring + "<tr> <td width='50%' style='border-right:1px solid #bfbfbf;height:28px;color:gray' rowspan='2'>" + PercentDelay + " </td>  <td id='tdStchActOB' runat='server' width='50%' style=' border-bottom:1px solid #bfbfbf;font-weight:bold; background:#f88585;color:black;height:14px;'> " + AvgDlyDay + "</td>  </tr>";
                        //    //tablestring = tablestring + "<tr> <td id='tdFinActOB' runat='server' style='color:gray;height:14px;'> " + MaxDelayDay + "</td> </tr>";
                        //    tablestring = tablestring + "<tr><td style='height:14px;color:black;font-weight:bold;border-bottom:1px solid #bfbfbf; width:33%;border-right:1px solid #bfbfbf;'>" + PercentDelay + " </td><td id='tdStchActOB' runat='server' style=' border-bottom:1px solid #bfbfbf;font-weight:bold; background:#f88585;color:black;height:14px;width:33%;border-right:1px solid #bfbfbf;'> " + AvgDlyDay + "</td><td style='border-right:1px solid #bfbfbf;height:14px;color:gray; width:34%;border-bottom:1px solid #bfbfbf;'>" + MaxDelayDay + " </td>  </tr>";
                        //    //if (Convert.ToDecimal(OneMonthAvg) < Convert.ToDecimal(PercentDelay))
                        //    //{
                        //    //    OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                        //    //    //tablestring = tablestring + "<tr>  <td width='50%' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;height:14px;color:black;background:#67aa67;'>" + OneMonthAvg + " </td>";
                        //    //    tablestring = tablestring + "<tr>  <td style='border-bottom:1px solid #bfbfbf;height:14px;color:black;background:#67aa67;'>" + OneMonthAvg + " </td></tr>";
                        //    //}
                        //    //else
                        //    //{
                        //    //    OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                        //    //    //tablestring = tablestring + "<tr>  <td width='50%' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;height:14px;color:black;background:#f88585;'>" + OneMonthAvg + " </td>";
                        //    //    tablestring = tablestring + "<tr> <td style='border-bottom:1px solid #bfbfbf;height:14px;color:black;background:#f88585;'>" + OneMonthAvg + " </td><td id='tdStchActOB' runat='server' style=' border-bottom:1px solid #bfbfbf; background:#f88585;color:black;height:14px;'> " + AvgDlyDay + "</td><td id='tdFinActOB' runat='server' style='color:gray;height:14px;'> " + MaxDelayDay + "</td> </tr>";
                        //    //}

                        //    //tablestring = tablestring + "<tr>  </tr>";
                        //    if (Convert.ToInt32(hdnStatusModeId.Value) != 63)
                        //        tablestring = tablestring + "<tr><td colspan='3'><table cellpadding='0' cellspacing='0' width='100%' border='0'> <tr><td width='50%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> Ex. Month</td> <td width='25%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'>Comp.</td> <td width='25%' style='border-bottom:1px solid #bfbfbf;'>Pend.</td>  </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + CurrentMonth + " & Bef.</td><td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + CurrentMonthDone + "</td><td style='border-bottom:1px solid #bfbfbf;'> " + CurrentMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + nextMonth + " </td> <td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + NextMonthDone + "</td><td style='border-bottom:1px solid #bfbfbf;'> " + NextMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + nextToNextMonth + " </td><td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + NextToNextMonthDone + "</td><td style='border-bottom:1px solid #bfbfbf;'> " + NextToNextMonthPending + "</td></tr><tr><td align='left' style='border-right:1px solid #bfbfbf;'> " + nextToNextaddMonth + " </td><td style='border-right:1px solid #bfbfbf;'> " + CurrentMonthAdd3MonthesDone + "</td><td > " + CurrentMonthAdd3MonthesPending + "</td></tr> </table> </td></tr>";
                        //    // tablestring = tablestring + "<tr> </tr>";






                        //    OneMonthAvg = OneMonthAvg == "" ? "0" : OneMonthAvg;
                        //    //Delay = Delay == "" ? "0" : Delay;
                        //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                        //    PercentDelay = PercentDelay == "" ? "0" : PercentDelay;
                        //}

                        //}

                        tablestring = tablestring + "</table>";
                    }

                    //else
                    //{

                    //    tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' width='100%' border='0' style='border-collapse:collapse; text-align:center;font-size: 11px;'>";


                    //    if (Convert.ToDecimal(AvgDlyDay) == 0)
                    //    {
                    //        Delay = Delay == "0" ? "" : Delay;
                    //        AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                    //        MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                    //        PercentDelay = PercentDelay == "0" ? "" : PercentDelay;
                    //        StyleCount = StyleCount == "0" ? "" : StyleCount;
                    //       // OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                    //        // tablestring = tablestring + "<tr> <td width='50%' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;font-weight:bold; height:14px;display:none;'>" + Delay + " </td> <td width='50%' style='border-right:1px solid #bfbfbf;height:14px;color:gray' rowspan='2'>" + PercentDelay + " </td> <td id='tdStchActOB' runat='server' width='50%' style=' border-bottom:1px solid #bfbfbf;font-weight:bold;'> " + AvgDlyDay + "</td>  </tr>";
                    //        //tablestring = tablestring + "<tr>  <td id='tdFinActOB' runat='server' style='color:gray;' width='50%'> " + MaxDelayDay + "</td> </tr>";


                    //        //tablestring = tablestring + "<tr> <td width='50%' style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;font-weight:bold; height:14px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='50%' style=' border-bottom:1px solid #bfbfbf;font-weight:bold;'> " + AvgDlyDay + "</td>  </tr>";
                    //        //tablestring = tablestring + "<tr> <td width='50%' style='border-right:1px solid #bfbfbf;height:14px;color:gray'>" + PercentDelay + " </td> <td id='tdFinActOB' runat='server' style='color:gray;' width='50%'> " + MaxDelayDay + "</td> </tr>";
                    //        tablestring = tablestring + "<tr><td style='height:14px;color:black;font-weight:bold;border-bottom:1px solid #bfbfbf; width:33%; border-right:1px solid #bfbfbf;'>" + PercentDelay + " </td> <td id='tdStchActOB' runat='server' style=' border-bottom:1px solid #bfbfbf; width:33%; border-right:1px solid #bfbfbf;'> " + AvgDlyDay + "</td><td id='tdFinActOB' runat='server' style='height:14px;color:gray;border-bottom:1px solid #bfbfbf;'> " + MaxDelayDay + "</td>   </tr>";
                    //        //tablestring = tablestring + "<tr> <td style='border-bottom:1px solid #bfbfbf;height:14px'>" + OneMonthAvg + "</td> </tr>";
                    //        if (Convert.ToInt32(hdnStatusModeId.Value) != 63)
                    //            tablestring = tablestring + "<tr><td colspan='3'><table cellpadding='0' cellspacing='0' width='100%' border='0'> <tr><td width='50%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> Ex. Month</td> <td width='25%' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'>Comp.</td> <td width='25%' style='border-bottom:1px solid #bfbfbf;'>Pend.</td>  </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + CurrentMonth + " & Bef.</td><td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + CurrentMonthDone + "</td><td style='border-bottom:1px solid #bfbfbf;'> " + CurrentMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + nextMonth + " </td> <td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + NextMonthDone + "</td><td style='border-bottom:1px solid #bfbfbf;'> " + NextMonthPending + "</td> </tr> <tr><td align='left' style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + nextToNextMonth + " </td><td style='border-right:1px solid #bfbfbf;border-bottom:1px solid #bfbfbf;'> " + NextToNextMonthDone + "</td><td style='border-bottom:1px solid #bfbfbf;'> " + NextToNextMonthPending + "</td></tr><tr><td align='left' style='border-right:1px solid #bfbfbf;'> " + nextToNextaddMonth + " </td><td style='border-right:1px solid #bfbfbf;'> " + CurrentMonthAdd3MonthesDone + "</td><td > " + CurrentMonthAdd3MonthesPending + "</td></tr> </table> </td></tr>";



                    //        AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                    //        Delay = Delay == "" ? "0" : Delay;
                    //        MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                    //        PercentDelay = PercentDelay == "" ? "0" : PercentDelay;
                    //       // OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                    //    }

                    else
                    {
                        //if (Convert.ToDecimal(AvgDlyDay) < Convert.ToDecimal(PercentDelay))
                        //{
                        tablestring = tablestring + "<table  cellpadding='0' cellspacing='0' width='100%' border='0' style='border-collapse:collapse; text-align:center;font-size: 11px;'>";

                        Delay = Delay == "0" ? "" : Delay;
                        //AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                        MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                        PercentDelay = PercentDelay == "0" ? "" : PercentDelay;
                        StyleCode = StyleCode == "0" ? "" : StyleCode;
                        // OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;

                        //tablestring = tablestring + "<tr> <td width='50%' rowspan='2' style='border-right:1px solid #bfbfbf; height:14px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='50%' style=' border-bottom:1px solid #bfbfbf;font-weight:bold; background:#67aa67; color:black'> " + AvgDlyDay + "</td>  </tr>";
                        //tablestring = tablestring + "<tr>  <td id='tdFinActOB' runat='server' style='color:gray;' width='50%'> " + MaxDelayDay + "</td> </tr>";

                        tablestring = tablestring + "<tr> <td style='border-bottom:1px solid #bfbfbf; height:22px; color:black'>" + Delay + " </td> </tr>";
                        tablestring = tablestring + "<tr> <td style='height:22px;color:black;font-weight:bold;'>" + StyleCode + "(" + StyleCount + ")</td></tr>";

                        //tablestring = tablestring + "<tr>  <td id='tdFinActOB' runat='server'  style='color:gray;' width='50%'> " + MaxDelayDay + "</td> </tr>";



                        // AvgDlyDay = AvgDlyDay == "" ? "0" : AvgDlyDay;
                        Delay = Delay == "" ? "0" : Delay;
                        MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                        PercentDelay = PercentDelay == "" ? "0" : PercentDelay;
                        StyleCode = StyleCode == "" ? "0" : StyleCode;
                        // OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;

                        //}
                        //else
                        //{
                        //    Delay = Delay == "0" ? "" : Delay;
                        //    // AvgDlyDay = AvgDlyDay == "0" ? "" : AvgDlyDay;
                        //    MaxDelayDay = MaxDelayDay == "0" ? "" : MaxDelayDay;
                        //    PercentDelay = PercentDelay == "0" ? "" : PercentDelay;
                        //   // OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                        //    //tablestring = tablestring + "<tr> <td width='50%' rowspan='2' style='border-right:1px solid #bfbfbf; height:14px'>" + Delay + " </td> <td id='tdStchActOB' runat='server' width='50%' style=' border-bottom:1px solid #bfbfbf;font-weight:bold; background:#f88585;color:black'> " + AvgDlyDay + "</td>  </tr>";
                        //    //tablestring = tablestring + "<tr><td id='tdFinActOB' runat='server' style='color:gray;' width='50%'> " + MaxDelayDay + "</td> </tr>";
                        //    //tablestring = tablestring + "<tr> <td style='height:21px'>" + Delay + " /" + StyleCount + " </td> </tr>";
                        //    tablestring = tablestring + "<tr> <td style='border-bottom:1px solid #bfbfbf; height:22px; color:black'>" + Delay + " </td></tr>"; 
                        //    tablestring = tablestring + "<tr> <td  style='height:22px;color:black'>" + StyleCount + " </td></tr>";

                        //    //OneMonthAvg = OneMonthAvg == "0" ? "" : OneMonthAvg;
                        //    Delay = Delay == "" ? "0" : Delay;
                        //    MaxDelayDay = MaxDelayDay == "" ? "0" : MaxDelayDay;
                        //    PercentDelay = PercentDelay == "" ? "0" : PercentDelay;
                        //}
                        //}


                        tablestring = tablestring + "</table>";

                    }


                    oLabel.Text = tablestring;
                    e.Row.Cells[i].Controls.Add(oLabel);


                    if (hdnStatusModeId.Value == "9999")
                    {
                        Label lblLeadTimeStatusMode = (Label)e.Row.FindControl("lblLeadTimeStatusMode");
                        //e.Row.Cells[0].ColumnSpan = 2;
                        //e.Row.Cells[1].ColumnSpan = 2;
                        // e.Row.Cells[2].Visible = false;
                        string newtablestring = "";
                        if (lblLeadTimeStatusMode.Text == "Total Lead")
                        {
                            lblLeadTimeStatusMode.Visible = false;
                        }
                        //newtablestring = newtablestring + "<table  cellpadding='0' cellspacing='0' width='100%' border='0' style='background:#405D99;'>";
                        //newtablestring = newtablestring + "<tr><td style='border-right:1px solid #bfbfbf; border-bottom:1px solid #bfbfbf;font-weight:normal; color:#98a9ca;font-size:10px;' height='14px' width='50%' rowspan='2'> Total Lead Time 1 Year </td> <td  style='border-bottom:1px solid #bfbfbf;font-weight:normal;font-size:10px;color:#98a9ca;' width='50%'> (3 M) Lead Time Avg (Wk) </td></tr>";
                        //newtablestring = newtablestring + "<tr> <td  style='font-weight:normal;color:#98a9ca;font-size:10px;' width='50%'> (1 Y) Lead Time Avg(Wk) </td></tr>";
                        //newtablestring = newtablestring + "</table>";
                        lblLeadTimeTargetLogic.Visible = false;
                        newtablestring = newtablestring + "<table  cellpadding='0' cellspacing='0' width='100%' border='0'>";
                        newtablestring = newtablestring + "<tr><td style='border-bottom:1px solid #bfbfbf; font-weight:normal; color:#98a9ca;font-size:9px;background:#405D99;height:22px;'> Tot. LdTime 1 Yr (Wks) </td></tr>";
                        newtablestring = newtablestring + "<tr><td  style='font-weight:normal;font-size:9px;color:#98a9ca;background:#405D99; height:22px;font-weight:bold;'>Tot Style Code/No </td></tr>";
                        newtablestring = newtablestring + "</table>";
                        //newtablestring = newtablestring + "<span style='font-size:12px;'>Total Lead Time 1 Year (Wk)/No of style </span>";

                        footertable.InnerHtml = newtablestring;
                        //e.Row.Cells[2].Attributes.Add("bgcolor", "#f2f2f2");
                        e.Row.Cells[0].Controls.Add(footertable);

                    }


                }
                oWorkflowController = null;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {

                //e.Row.Cells[0].ColumnSpan = 2;
                // e.Row.Cells[1].ColumnSpan = 2;
                // e.Row.Cells[2].Visible = false;
            }
        }
    }
}