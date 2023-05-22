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
using iKandi.BLL;
using System.Text;
using iKandi.BLL.Production;

namespace iKandi.Web
{
    public partial class Departmentwise_Report : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();

        
        int ETA1Week = 0;
        int Wk1Dly = 0;
        int Wk2Dly = 0;
        int CompletedHandOver = 0;
        int AvgLeadDaysHandOver = 0;

        int ComPatternReady = 0;
        int AvgLeadDaysPattern = 0;

        int AvgTimeLine = 0;
        int AvgTimeTaken = 0;
        int AvgStyleCreatedAll = 0;
        int AvgStyleCreatedSample = 0;

        int Total_without = 0;
        int ETA1Week_without = 0;
        int Wk1Dly_without = 0;
        int Wk2Dly_without = 0;
        int CompletedHandOver_without = 0;
        int AvgLeadDaysHandOver_without = 0;

        int ComPatternReady_without = 0;
        int AvgLeadDaysPattern_without = 0;

        int AvgTimeLine_without = 0;
        int AvgTimeTaken_without = 0;
        int AvgStyleCreatedAll_without = 0;
        int AvgStyleCreatedSample_without = 0;
        int TotalPendingSampleSent_WithOneweek = 0;
        DataTable DeptFooter = new DataTable();
        DataTable DeptFooter_without = new DataTable();
        int rowno = 0;
        int rowno_without = 0;
       
        //code add by bharat on 27-Aug
           double sumQty = 0.0;
            double sumval = 0.0;
         //end
        protected void Page_Load(object sender, EventArgs e)
        {
            BindReport();
            if (!Page.IsPostBack)
            {
                DataSet ds = new DataSet();
                //CreateExcel(ds);
            }
            
        }


        public void BindReport()
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                DataSet dsDept = new DataSet();
                DataTable dtDept = new DataTable();


                DataSet dsDept_without = new DataSet();


                ds = objadmin.GetFitsReport("SAMPLING");

                dt = ds.Tables[0];
                dt.Rows.Add(dt.NewRow());

                grdsampling.DataSource = dt;
                grdsampling.DataBind();

                dsDept = objadmin.getDepartmentWiseReport();
                dtDept = dsDept.Tables[0];
                
                ds = objadmin.GetIncentiveScoreSampling();
                dt = ds.Tables[2];

                //GridViewRow Samplinglastrow = grdsampling.Rows[(grdsampling.Rows.Count) - 1];



                //Samplinglastrow.Cells[17].Text = "<span style='color:#000 !important'>" + "score"  +" </span>";
                //Samplinglastrow.Cells[18].Text = "<span style='color:green !important'>₹ " + dt.Rows[0]["PDSalesScore"].ToString() + " Cr.</span>";
                 
                    //end


                DeptFooter = dsDept.Tables[1];
                grdDepartmentSpecificDelayReport.DataSource = dtDept;
                grdDepartmentSpecificDelayReport.DataBind();


                dsDept_without = objadmin.getDepartmentWiseReport_withoutassosiation();
                //dtDept = dsDept_without.Tables[0];
                DeptFooter_without = dsDept.Tables[1];
                GridView1.DataSource = dsDept_without.Tables[0];
                GridView1.DataBind();
                GridViewRow Samplinglastrow2 = grdsampling.Rows[(grdsampling.Rows.Count) - 2];

                for (int i = 0; i < Samplinglastrow2.Cells.Count; i++)
                {
                    //Samplinglastrow.Cells[i].Font.Bold = true;
                    //Samplinglastrow.Cells[i].Font.Size=10;
                    //Samplinglastrow.Cells[0].ForeColor = System.Drawing.Color.Black;
                    Samplinglastrow2.Cells[0].CssClass = "boldblack";
                    Samplinglastrow2.Cells[i].CssClass = "boldblacknew";
                    //code add by bharat on 27-Aug
                    if (Convert.ToString(sumQty) == "0")
                        Samplinglastrow2.Cells[17].Text = "";
                    else
                        Samplinglastrow2.Cells[17].Text = "<span style='color:#000 !important'>" + Convert.ToString(sumQty) == "0" ? "" : sumQty.ToString() + " L </span>";

                    if (Convert.ToString(sumval) == "0")
                        Samplinglastrow2.Cells[18].Text = "";
                    else
                        Samplinglastrow2.Cells[18].Text = "<span style='color:green !important'>₹ " + Convert.ToString(sumval) == "0" ? "" : sumval.ToString() + " Cr.</span>";

                    Samplinglastrow2.Cells[17].ForeColor = System.Drawing.Color.Black;
                    Samplinglastrow2.Cells[18].ForeColor = System.Drawing.Color.Green;
                    //end
                }
                Samplinglastrow2.BackColor = System.Drawing.Color.FromName("#FFF0A5");


                GridViewRow Samplinglastrow = grdsampling.Rows[(grdsampling.Rows.Count) - 1];

                for (int i = 0; i < Samplinglastrow.Cells.Count; i++)
                {
                    Samplinglastrow.Cells[0].CssClass = "boldblack";
                    Samplinglastrow.Cells[i].CssClass = "boldblacknew";
                    //Samplinglastrow.Cells[i].Font.Size=10;
                    //Samplinglastrow.Cells[0].ForeColor = System.Drawing.Color.Black;
                    Samplinglastrow.Cells[16].ColumnSpan = 17;
                    Samplinglastrow.Cells[0].Visible = false;
                    Samplinglastrow.Cells[1].Visible = false;
                    Samplinglastrow.Cells[2].Visible = false;
                    Samplinglastrow.Cells[3].Visible = false;
                    Samplinglastrow.Cells[4].Visible = false;
                    Samplinglastrow.Cells[5].Visible = false;
                    Samplinglastrow.Cells[6].Visible = false;
                    Samplinglastrow.Cells[7].Visible = false;
                    Samplinglastrow.Cells[8].Visible = false;
                    Samplinglastrow.Cells[9].Visible = false;
                    Samplinglastrow.Cells[10].Visible = false;
                    Samplinglastrow.Cells[11].Visible = false;
                    Samplinglastrow.Cells[12].Visible = false;
                    Samplinglastrow.Cells[13].Visible = false;
                    Samplinglastrow.Cells[14].Visible = false;
                    Samplinglastrow.Cells[15].Visible = false;
                  
                   
                    //code add by bharat on 27-Aug
                    Samplinglastrow.Cells[17].Text = "<span style='color:#000 !important;'>" + "score" + "</span>";
                    Samplinglastrow.Cells[18].Text = "<span style='color:#000 !important'>" + dt.Rows[0]["PDSalesScore"].ToString() + "%</span>";
                    Samplinglastrow2.Cells[18].ForeColor = System.Drawing.Color.Black;
                    //end
                   
                }
               
                
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
        }
       
       
        //code add by bharat on 27-Aug
        protected void grdsampling_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                string PreviousMonth_QuarterValue = "";
                DateTime CurrentDate;
                CurrentDate = DateTime.Now;
                int month = CurrentDate.Month;
                if (month == 1 || month == 2 || month == 3)
                {
                    PreviousMonth_QuarterValue = "Q4";
                }
                else if (month == 4 || month == 5 || month == 6)
                {
                    PreviousMonth_QuarterValue = "Q1";
                }
                else if (month == 7 || month == 8 || month == 9)
                {
                     PreviousMonth_QuarterValue = "Q2";
                }
                else if (month == 10 || month == 11 || month == 12)
                {
                   
                    PreviousMonth_QuarterValue = "Q3";
                }
                TableHeaderCell headerTableCell = new TableHeaderCell();
                headerTableCell.RowSpan = 2;
                headerTableCell.Text = "PD";
                headerTableCell.Font.Bold = true;
                headerTableCell.Attributes.Add("style","width:80px");
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.RowSpan = 2;
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Style Pend.";
                headerTableCell.Attributes.Add("style", "width:59px");
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 3;
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Handover";
              
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 3;
                headerTableCell.Font.Bold = true;
               
                headerTableCell.Text = "Pattern Ready";
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 3;
               
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Pending Samples To Sent";
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 3;
                headerTableCell.Font.Bold = true;
               
                headerTableCell.Text = "Initial Costing BIPL";
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 3;
                headerTableCell.Font.Bold = true;
               
                headerTableCell.Text = "Costing Price Quoted";
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 2;
             
                headerTableCell.Font.Bold = true;

                headerTableCell.Text = PreviousMonth_QuarterValue;
                headerRow1.Controls.Add(headerTableCell);


                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Task Pend.";
                headerTableCell.Attributes.Add("style", "width:59px");
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Task Dela";
                headerTableCell.Attributes.Add("style", "width:59px");
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Attributes.Add("style", "width:59px");
                headerTableCell.Text = "Avg LT 1 Mon. (Days)";
                headerRow2.Controls.Add(headerTableCell);


                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Task Pend.";
                headerTableCell.Attributes.Add("style", "width:59px");
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Task Dela";
                headerTableCell.Attributes.Add("style", "width:59px");
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Avg LT 1 Mon. (Days)";
                headerRow2.Controls.Add(headerTableCell);


                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Task Pend.";
                headerTableCell.Attributes.Add("style", "width:59px");
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Task Dela";
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Attributes.Add("style", "width:59px");
                headerTableCell.Text = "Avg LT 1 Mon. (Days)";
                headerRow2.Controls.Add(headerTableCell);


                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Pending Initial Costing BIPL";
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Attributes.Add("style", "width:59px");
                headerTableCell.Text = "Delay Initial Costing";
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Attributes.Add("style", "width:59px");
                headerTableCell.Text = "Avg LT 1 Mon. (Days)";
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Attributes.Add("style", "width:59px");
                headerTableCell.Text = "Pending Price Quoted";
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Attributes.Add("style", "width:59px");
                headerTableCell.Text = "Delay Price Quoted";
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Attributes.Add("style", "width:59px");
                headerTableCell.Text = "Avg LT 1 Mon. (Days)";
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Sales Qty.";
                headerTableCell.Attributes.Add("style", "width:59px");
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Sales Val.";
                headerTableCell.Attributes.Add("style", "width:80px");
                headerRow2.Controls.Add(headerTableCell);

                grdsampling.Controls[0].Controls.AddAt(0, headerRow2);
                grdsampling.Controls[0].Controls.AddAt(0, headerRow1);

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSales_Qty = (Label)e.Row.FindControl("lblSales_Qty");
                Label lblSales_Val = (Label)e.Row.FindControl("lblSales_Val");

                if (lblSales_Qty.Text != "")
                {
                    if (Convert.ToDecimal(lblSales_Qty.Text) != 0)
                    {
                        sumQty += Convert.ToDouble(lblSales_Qty.Text);
                    }
                }
                if (lblSales_Val.Text != "")
                {
                    if (Convert.ToDecimal(lblSales_Val.Text) != 0)
                    {
                        sumval += Convert.ToDouble(lblSales_Val.Text);
                    }
                }


                if (lblSales_Qty.Text != "")
                {
                    if (Convert.ToDecimal(lblSales_Qty.Text) != 0)
                    {
                        lblSales_Qty.Text = lblSales_Qty.Text + " " + "L";
                    }
                    else
                    {
                        lblSales_Qty.Text = "";
                    }
                }
                if (lblSales_Val.Text != "")
                {
                    if (Convert.ToDecimal(lblSales_Val.Text) != 0)
                    {
                        lblSales_Val.Text = "₹ " + lblSales_Val.Text + " " + "Cr.";
                    }
                    else
                    {
                        lblSales_Val.Text = "";
                    }
                }
               
            }
            
           
        }
        //end
        protected void grdDepartmentSpecificDelayReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableHeaderCell headerTableCell = new TableHeaderCell();

                headerTableCell.RowSpan = 2;
                headerTableCell.Text = "PD Merchant";
                headerTableCell.Font.Bold = true;
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.RowSpan = 2;
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Client-Department";

                headerRow1.Controls.Add(headerTableCell);

                //headerTableCell = new TableHeaderCell();
                //headerTableCell.RowSpan = 2;
                //// headerTableCell.ColumnSpan = 2;
                //headerTableCell.Font.Bold = true;
                //headerTableCell.Text = "Pndg Overall(SampleSent)";

                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                // headerTableCell.RowSpan = 2;
                headerTableCell.ColumnSpan = 2;
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Total";
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 3;
                headerTableCell.Text = "Pending Samples to Sent";
                headerTableCell.Font.Bold = true;
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 4;
                headerTableCell.Text = "Handover Past 3 Month";
                headerTableCell.Font.Bold = true;
                headerRow1.Controls.Add(headerTableCell);


                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 4;
                headerTableCell.Text = "Pattern Ready Past 3 Month";
                headerTableCell.Font.Bold = true;
                headerRow1.Controls.Add(headerTableCell);


                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 7;
                headerTableCell.Text = "Avg Based On 3 Month";
                headerTableCell.Font.Bold = true;
                headerRow1.Controls.Add(headerTableCell);



                headerRow1.Controls.Add(headerTableCell);

                TableHeaderCell headerCell1;
                TableHeaderCell headerCell2;
                TableHeaderCell headerCell3;
                TableHeaderCell headerCell4;
                TableHeaderCell headerCell5;
                TableHeaderCell headerCell6;
                TableHeaderCell headerCell7;
                TableHeaderCell headerCell8;
                TableHeaderCell headerCell9;
                TableHeaderCell headerCell10;
                TableHeaderCell headerCell11;
                TableHeaderCell headerCell12;

                TableHeaderCell headerCell13;
                TableHeaderCell headerCell14;
                TableHeaderCell headerCell15;
                TableHeaderCell headerCell16;
                TableHeaderCell headerCell17;
                TableHeaderCell headerCell18;
                TableHeaderCell headerCell19;
                TableHeaderCell headerCell20;
                TableHeaderCell headerCell21;
                TableHeaderCell headerCell22;

                headerCell1 = new TableHeaderCell();
                headerCell2 = new TableHeaderCell();               
                headerCell3 = new TableHeaderCell();
                headerCell4 = new TableHeaderCell();
                headerCell5 = new TableHeaderCell();
                headerCell6 = new TableHeaderCell();
                headerCell7 = new TableHeaderCell();
                headerCell8 = new TableHeaderCell();
                headerCell9 = new TableHeaderCell();
                headerCell10 = new TableHeaderCell();
                headerCell11 = new TableHeaderCell();
                headerCell12 = new TableHeaderCell();
                headerCell13 = new TableHeaderCell();
                headerCell14 = new TableHeaderCell();
                headerCell15 = new TableHeaderCell();
                headerCell16 = new TableHeaderCell();
                headerCell17 = new TableHeaderCell();
                headerCell18 = new TableHeaderCell();
                headerCell19 = new TableHeaderCell();
                headerCell20 = new TableHeaderCell();
                headerCell21 = new TableHeaderCell();
                headerCell22 = new TableHeaderCell();

                headerCell21.Text = "Total Pending To Send";
                headerCell22.Text = "Delayed And Upcoming In 1 Wk";
                headerCell1.Text = "Eta in 1 Wk";
                headerCell2.Text = "1 Wk Dly";
                headerCell3.Text = "2 Wk+ Dly";

                headerCell4.Text = "Completed Handover";
                headerCell5.Text = "Avg Lead Time Days";
                headerCell6.Text = "% Completed  Within 2 Days"; 

                headerCell7.Text = "% Completed Beyond 2+ Days";
                headerCell8.Text = "Completed Pattern Ready";
                headerCell9.Text = "Avg Lead Time Days";


                headerCell10.Text = "% Completed  Within 3 Days";
                headerCell11.Text = "% Completed Beyond 4 + Days";
                headerCell12.Text = "Avg Timeline Given (Days)";

                headerCell13.Text = "Avg Time Taken (Days)";
                headerCell14.Text = "Avg style Created (All) Monthly";
                headerCell15.Text = "Avg style Created (With Sample) Monthly";

                headerCell16.Text = "% On Time Sample Sent (With Sample)";
                headerCell17.Text = "% 1 Wk Dly (With Sample)";
                headerCell18.Text = "% 1 Wk + Dly (With Sample)";
                headerCell19.Text = "% 1 Wk Dly (With Sample)";
                headerCell18.Text = "% 1 Wk + Dly (With Sample)";


                headerRow2.Controls.Add(headerCell21);
                headerRow2.Controls.Add(headerCell22);
                headerRow2.Controls.Add(headerCell1);
                headerRow2.Controls.Add(headerCell2);
                headerRow2.Controls.Add(headerCell3);

                headerRow2.Controls.Add(headerCell4);
                headerRow2.Controls.Add(headerCell5);
                headerRow2.Controls.Add(headerCell6);

                headerRow2.Controls.Add(headerCell7);
                headerRow2.Controls.Add(headerCell8);
                headerRow2.Controls.Add(headerCell9);

                headerRow2.Controls.Add(headerCell10);
                headerRow2.Controls.Add(headerCell11);
                headerRow2.Controls.Add(headerCell12);

                headerRow2.Controls.Add(headerCell13);
                headerRow2.Controls.Add(headerCell14);
                headerRow2.Controls.Add(headerCell15);

                headerRow2.Controls.Add(headerCell16);
                headerRow2.Controls.Add(headerCell17);
                headerRow2.Controls.Add(headerCell18);
                grdDepartmentSpecificDelayReport.Controls[0].Controls.AddAt(0, headerRow2);
                grdDepartmentSpecificDelayReport.Controls[0].Controls.AddAt(0, headerRow1);
            }




            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAverage_TimeTaken_days = (Label)e.Row.FindControl("lblAverage_TimeTaken_days");
                Label lblHandOver_Completed_In_Two_Days = (Label)e.Row.FindControl("lblHandOver_Completed_In_Two_Days");
                Label lblHandOver_Completed_Beyond_Two_Days = (Label)e.Row.FindControl("lblHandOver_Completed_Beyond_Two_Days");
                Label lblPatternReady_Completed_In_three_Days = (Label)e.Row.FindControl("lblPatternReady_Completed_In_three_Days");
                Label lblPatternReady_Completed_Beyond_four_Days = (Label)e.Row.FindControl("lblPatternReady_Completed_Beyond_four_Days");
                Label lblPercent_One_Week_Delay_In_Sample = (Label)e.Row.FindControl("lblPercent_One_Week_Delay_In_Sample");
                Label lblPercent_On_time_sample_sent = (Label)e.Row.FindControl("lblPercent_On_time_sample_sent");
                Label lblPercent_One_Week_Delay_One_Week_In_Sample = (Label)e.Row.FindControl("lblPercent_One_Week_Delay_One_Week_In_Sample");

                rowno = rowno + 1;
                if (lblHandOver_Completed_In_Two_Days.Text != "0")
                    lblHandOver_Completed_In_Two_Days.Text = lblHandOver_Completed_In_Two_Days.Text + "%";
                else
                    lblHandOver_Completed_In_Two_Days.Text = "";
                if (lblHandOver_Completed_Beyond_Two_Days.Text != "0")
                    lblHandOver_Completed_Beyond_Two_Days.Text = lblHandOver_Completed_Beyond_Two_Days.Text + "%";
                else
                    lblHandOver_Completed_Beyond_Two_Days.Text = "";

                if (lblPatternReady_Completed_In_three_Days.Text != "0")
                    lblPatternReady_Completed_In_three_Days.Text = lblPatternReady_Completed_In_three_Days.Text + "%";
                else
                    lblPatternReady_Completed_In_three_Days.Text = "";
                if (lblPatternReady_Completed_Beyond_four_Days.Text != "0")
                    lblPatternReady_Completed_Beyond_four_Days.Text = lblPatternReady_Completed_Beyond_four_Days.Text + "%";
                else
                    lblPatternReady_Completed_Beyond_four_Days.Text = "";
                if (lblPercent_One_Week_Delay_In_Sample.Text != "0")
                    lblPercent_One_Week_Delay_In_Sample.Text = lblPercent_One_Week_Delay_In_Sample.Text + "%";
                else
                    lblPercent_One_Week_Delay_In_Sample.Text = "";
                if (lblPercent_On_time_sample_sent.Text != "0")
                    lblPercent_On_time_sample_sent.Text = lblPercent_On_time_sample_sent.Text + "%";
                else
                    lblPercent_On_time_sample_sent.Text = "";
                if (lblPercent_One_Week_Delay_One_Week_In_Sample.Text != "0")
                    lblPercent_One_Week_Delay_One_Week_In_Sample.Text = lblPercent_One_Week_Delay_One_Week_In_Sample.Text + "%";
                else
                    lblPercent_One_Week_Delay_One_Week_In_Sample.Text = "";


                if (Convert.ToInt32(lblAverage_TimeTaken_days.Text) > 18)
                {
                    lblAverage_TimeTaken_days.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (lblAverage_TimeTaken_days.Text == "0")
                    {
                        lblAverage_TimeTaken_days.Text = "";
                    }
                    lblAverage_TimeTaken_days.ForeColor = System.Drawing.Color.Green;
                }

                // string valueAdd = 
                //Total = Total + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalPendingSampleSent").ToString());
                //Total = 30;

                ETA1Week = ETA1Week + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ETA_In_One_Week").ToString());
                Wk1Dly = Wk1Dly + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "One_Week_Delay").ToString());
                Wk2Dly = Wk2Dly + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TwoWeekDlyInweek").ToString());


                CompletedHandOver = CompletedHandOver + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedHandover").ToString());

                AvgLeadDaysHandOver = AvgLeadDaysHandOver + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "HandOver_Avg_Leadtime"));

                ComPatternReady = ComPatternReady + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedPatternReady").ToString());
                AvgLeadDaysPattern = AvgLeadDaysPattern + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PatternReady_Avg_Leadtime"));


                AvgTimeLine = AvgTimeLine + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Average_TimeLine_Givendays").ToString());
                AvgTimeTaken = AvgTimeTaken + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Average_TimeTaken_days").ToString());
                AvgStyleCreatedAll = AvgStyleCreatedAll + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Avg_style_created_all").ToString());
                AvgStyleCreatedSample = AvgStyleCreatedSample + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Avg_style_created_With_sample").ToString());

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblfoo_TotalPendingSampleSent = (Label)e.Row.FindControl("lblfoo_TotalPendingSampleSent");
                Label lblfoo_TotalPendingSampleSent_WithOneweek = (Label)e.Row.FindControl("lblfoo_TotalPendingSampleSent_WithOneweek");
              
                Label lblfoo_ETA_In_One_Week = (Label)e.Row.FindControl("lblfoo_ETA_In_One_Week");
                Label lblfoo_One_Week_Delay = (Label)e.Row.FindControl("lblfoo_One_Week_Delay");
                Label lblfoo_TwoWeekDlyInweek = (Label)e.Row.FindControl("lblfoo_TwoWeekDlyInweek");

                Label lblfoo_CompletedHandover = (Label)e.Row.FindControl("lblfoo_CompletedHandover");
                Label lblfoo_HandOver_Avg_Leadtime = (Label)e.Row.FindControl("lblfoo_HandOver_Avg_Leadtime");
                Label lblfoo_HandOver_Completed_In_Two_Days = (Label)e.Row.FindControl("lblfoo_HandOver_Completed_In_Two_Days");
                Label lblfoo_HandOver_Completed_Beyond_Two_Days = (Label)e.Row.FindControl("lblfoo_HandOver_Completed_Beyond_Two_Days");


                Label lblfoo_CompletedPatternReady = (Label)e.Row.FindControl("lblfoo_CompletedPatternReady");
                Label lblfoo_PatternReady_Avg_Leadtime = (Label)e.Row.FindControl("lblfoo_PatternReady_Avg_Leadtime");
                Label lblfoo_PatternReady_Completed_In_three_Days = (Label)e.Row.FindControl("lblfoo_PatternReady_Completed_In_three_Days");
                Label lblfoo_PatternReady_Completed_Beyond_four_Days = (Label)e.Row.FindControl("lblfoo_PatternReady_Completed_Beyond_four_Days");

                Label lblfoo_Average_TimeLine_Givendays = (Label)e.Row.FindControl("lblfoo_Average_TimeLine_Givendays");
                Label lblfoo_Average_TimeTaken_days = (Label)e.Row.FindControl("lblfoo_Average_TimeTaken_days");
                Label lblfoo_Avg_style_created_all = (Label)e.Row.FindControl("lblfoo_Avg_style_created_all");
                Label lblfoo_Avg_style_created_With_sample = (Label)e.Row.FindControl("lblfoo_Avg_style_created_With_sample");

                Label lblfoo_Percent_On_time_sample_sent = (Label)e.Row.FindControl("lblfoo_Percent_On_time_sample_sent");
                Label lblfoo_Percent_One_Week_Delay_In_Sample = (Label)e.Row.FindControl("lblfoo_Percent_One_Week_Delay_In_Sample");
                Label lblfoo_Percent_One_Week_Delay_One_Week_In_Sample = (Label)e.Row.FindControl("lblfoo_Percent_One_Week_Delay_One_Week_In_Sample");

                Label lblFoo_total = (Label)e.Row.FindControl("lblFoo_total");
                lblFoo_total.Text = "Total";
                e.Row.Font.Bold = true;
                e.Row.BackColor = System.Drawing.Color.FromName("#FFF0A5");
                e.Row.Cells[0].ColumnSpan = 2;
                e.Row.Cells[1].Visible = false;
                //if (Total > 0)
                //{
                //    lblfoo_TotalPendingSampleSent.Text = Total.ToString();
                //}
                lblfoo_TotalPendingSampleSent.Text = DeptFooter.Rows[0]["OverAllStyle"].ToString() == "0" ? "" : DeptFooter.Rows[0]["OverAllStyle"].ToString();
                lblfoo_TotalPendingSampleSent_WithOneweek.Text = DeptFooter.Rows[0]["Delay_And_Upcomming_In_Aweek_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Delay_And_Upcomming_In_Aweek_Total"].ToString();
                if (ETA1Week > 0)
                {
                    lblfoo_ETA_In_One_Week.Text = ETA1Week.ToString();
                }
                if (Wk1Dly > 0)
                {
                    lblfoo_One_Week_Delay.Text = Wk1Dly.ToString();
                }
                if (Wk2Dly > 0)
                {
                    lblfoo_TwoWeekDlyInweek.Text = Wk2Dly.ToString();
                }
                if (CompletedHandOver > 0)
                {
                    lblfoo_CompletedHandover.Text = CompletedHandOver.ToString();
                }
                if ((AvgLeadDaysHandOver / rowno) > 0)
                {
                    lblfoo_HandOver_Avg_Leadtime.Text = (AvgLeadDaysHandOver / rowno).ToString();
                }

                lblfoo_HandOver_Completed_In_Two_Days.Text = DeptFooter.Rows[0]["HandOver_Completed_With_in_two_Days_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["HandOver_Completed_With_in_two_Days_Total"].ToString() + "%";
                lblfoo_HandOver_Completed_Beyond_Two_Days.Text = DeptFooter.Rows[0]["HandOver_Completed_Beyond_two_Days_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["HandOver_Completed_Beyond_two_Days_Total"].ToString() + "%";
                if (ComPatternReady > 0)
                {
                    lblfoo_CompletedPatternReady.Text = ComPatternReady.ToString();
                }
                if ((AvgLeadDaysPattern / rowno) > 0)
                {
                    lblfoo_PatternReady_Avg_Leadtime.Text = (AvgLeadDaysPattern / rowno).ToString();
                }
                lblfoo_PatternReady_Completed_In_three_Days.Text = DeptFooter.Rows[0]["PatternReady_Completed_With_in_three_Days_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["PatternReady_Completed_With_in_three_Days_Total"].ToString() + "%";
                lblfoo_PatternReady_Completed_Beyond_four_Days.Text = DeptFooter.Rows[0]["PatternReady_Completed_Beyond_four_Days_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["PatternReady_Completed_Beyond_four_Days_Total"].ToString() + "%";
                lblfoo_Average_TimeLine_Givendays.Text = DeptFooter.Rows[0]["Average_TimeLine_Givendays_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Average_TimeLine_Givendays_Total"].ToString();
                //if ((AvgTimeLine / rowno) > 0)
                //{
                //    lblfoo_Average_TimeLine_Givendays.Text = (AvgTimeLine / rowno).ToString();
                //}

                if ((AvgTimeTaken / rowno) > 18)
                {
                    lblfoo_Average_TimeTaken_days.ForeColor = System.Drawing.Color.Red;
                    //lblfoo_Average_TimeTaken_days.Text = (AvgTimeTaken / rowno).ToString();
                    lblfoo_Average_TimeTaken_days.Text = DeptFooter.Rows[0]["Average_TimeTaken_days_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Average_TimeTaken_days_Total"].ToString();
                }
                else
                {
                    if ((AvgTimeTaken / rowno) > 0)
                    {
                        lblfoo_Average_TimeTaken_days.Text = DeptFooter.Rows[0]["Average_TimeTaken_days_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Average_TimeTaken_days_Total"].ToString();
                    }
                    lblfoo_Average_TimeTaken_days.ForeColor = System.Drawing.Color.Green;
                }
                if ((AvgStyleCreatedAll / rowno) > 0)
                {
                    lblfoo_Avg_style_created_all.Text = DeptFooter.Rows[0]["Avg_style_created_all_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Avg_style_created_all_Total"].ToString();
                }
                if ((AvgStyleCreatedSample / rowno) > 0)
                {
                    lblfoo_Avg_style_created_With_sample.Text = DeptFooter.Rows[0]["Avg_style_created_With_sample_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Avg_style_created_With_sample_Total"].ToString();
                }
                lblfoo_Percent_On_time_sample_sent.Text = DeptFooter.Rows[0]["Percent_On_time_sample_sent_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Percent_On_time_sample_sent_Total"].ToString() + "%";
                lblfoo_Percent_One_Week_Delay_In_Sample.Text = DeptFooter.Rows[0]["Percent_One_Week_Delay_In_Sample_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Percent_One_Week_Delay_In_Sample_Total"].ToString() + "%";
                lblfoo_Percent_One_Week_Delay_One_Week_In_Sample.Text = DeptFooter.Rows[0]["Percent_One_Week_Delay_One_Week_In_Sample_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Percent_One_Week_Delay_One_Week_In_Sample_Total"].ToString() + "%";
            }
        }

        protected void grdDepartmentSpecificDelayReport_DataBound(object sender, EventArgs e)
        {
            for (int i = grdDepartmentSpecificDelayReport.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdDepartmentSpecificDelayReport.Rows[i];
                GridViewRow previousRow = grdDepartmentSpecificDelayReport.Rows[i - 1];

                Label lblPdMerchant = (Label)row.FindControl("lblPdMerchant");
                Label lblPreviousPdMerchant = (Label)previousRow.FindControl("lblPdMerchant");

                if (lblPdMerchant.Text == lblPreviousPdMerchant.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                }
            }
        }

     
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableHeaderCell headerTableCell = new TableHeaderCell();

                headerTableCell.RowSpan = 2;
                headerTableCell.Text = "PD Merchant";
                headerTableCell.Font.Bold = true;
                headerRow1.Controls.Add(headerTableCell);

                //headerTableCell = new TableHeaderCell();
                //headerTableCell.RowSpan = 2;
                //headerTableCell.Font.Bold = true;
                //headerTableCell.Text = "Client-Department";

                //  headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                // headerTableCell.RowSpan = 2;
                headerTableCell.ColumnSpan = 2;
                headerTableCell.Font.Bold = true;
                headerTableCell.Text = "Total";

                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 3;
                headerTableCell.Text = "Pending Samples to Sent";
                headerTableCell.Font.Bold = true;
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 4;
                headerTableCell.Text = "Handover Past 3 Month";
                headerTableCell.Font.Bold = true;
                headerRow1.Controls.Add(headerTableCell);


                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 4;
                headerTableCell.Text = "Pattern Ready Past 3 Month";
                headerTableCell.Font.Bold = true;
                headerRow1.Controls.Add(headerTableCell);


                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 7;
                headerTableCell.Text = "Avg Based On 3 Month";
                headerTableCell.Font.Bold = true;
                headerRow1.Controls.Add(headerTableCell);



                headerRow1.Controls.Add(headerTableCell);

                TableHeaderCell headerCell1;
                TableHeaderCell headerCell2;
                TableHeaderCell headerCell3;
                TableHeaderCell headerCell4;
                TableHeaderCell headerCell5;
                TableHeaderCell headerCell6;
                TableHeaderCell headerCell7;
                TableHeaderCell headerCell8;
                TableHeaderCell headerCell9;
                TableHeaderCell headerCell10;
                TableHeaderCell headerCell11;
                TableHeaderCell headerCell12;

                TableHeaderCell headerCell13;
                TableHeaderCell headerCell14;
                TableHeaderCell headerCell15;
                TableHeaderCell headerCell16;
                TableHeaderCell headerCell17;
                TableHeaderCell headerCell18;

                TableHeaderCell headerCell19;
                TableHeaderCell headerCell20;

                headerCell1 = new TableHeaderCell();
                headerCell2 = new TableHeaderCell();
                headerCell3 = new TableHeaderCell();
                headerCell4 = new TableHeaderCell();
                headerCell5 = new TableHeaderCell();
                headerCell6 = new TableHeaderCell();
                headerCell7 = new TableHeaderCell();
                headerCell8 = new TableHeaderCell();
                headerCell9 = new TableHeaderCell();
                headerCell10 = new TableHeaderCell();
                headerCell11 = new TableHeaderCell();
                headerCell12 = new TableHeaderCell();
                headerCell13 = new TableHeaderCell();
                headerCell14 = new TableHeaderCell();
                headerCell15 = new TableHeaderCell();
                headerCell16 = new TableHeaderCell();
                headerCell17 = new TableHeaderCell();
                headerCell18 = new TableHeaderCell();

                headerCell19 = new TableHeaderCell();
                headerCell20 = new TableHeaderCell();

                headerCell1.Text = "Eta in 1 Wk";
                headerCell2.Text = "1 Wk Dly";
                headerCell3.Text = "2 Wk+ Dly";

                headerCell4.Text = "Completed Handover";
                headerCell5.Text = "Avg Lead Time Days";
                headerCell6.Text = "% Completed  Within 2 Days";

                headerCell7.Text = "% Completed Beyond 2+ Days";
                headerCell8.Text = "Completed Pattern Ready";
                headerCell9.Text = "Avg Lead Time Days";


                headerCell10.Text = "% Completed  Within 3 Days";
                headerCell11.Text = "% Completed Beyond 4 + Days";
                headerCell12.Text = "Avg Timeline Given (Days)";

                headerCell13.Text = "Avg Time Taken (Days)";
                headerCell14.Text = "Avg style Created (All) Monthly";
                headerCell15.Text = "Avg style Created (With Sample) Monthly";

                headerCell16.Text = "% On Time Sample Sent (With Sample)";
                headerCell17.Text = "% 1 Wk Dly (With Sample)";
                headerCell18.Text = "% 1 Wk + Dly (With Sample)";

                headerCell19.Text = "Total Pending to send";
                headerCell20.Text = "Delayed and Upcoming in 1 Wk";

                headerRow2.Controls.Add(headerCell19);
                headerRow2.Controls.Add(headerCell20);

                headerRow2.Controls.Add(headerCell1);
                headerRow2.Controls.Add(headerCell2);
                headerRow2.Controls.Add(headerCell3);

                headerRow2.Controls.Add(headerCell4);
                headerRow2.Controls.Add(headerCell5);
                headerRow2.Controls.Add(headerCell6);

                headerRow2.Controls.Add(headerCell7);
                headerRow2.Controls.Add(headerCell8);
                headerRow2.Controls.Add(headerCell9);

                headerRow2.Controls.Add(headerCell10);
                headerRow2.Controls.Add(headerCell11);
                headerRow2.Controls.Add(headerCell12);

                headerRow2.Controls.Add(headerCell13);
                headerRow2.Controls.Add(headerCell14);
                headerRow2.Controls.Add(headerCell15);

                headerRow2.Controls.Add(headerCell16);
                headerRow2.Controls.Add(headerCell17);
                headerRow2.Controls.Add(headerCell18);
                GridView1.Controls[0].Controls.AddAt(0, headerRow2);
                GridView1.Controls[0].Controls.AddAt(0, headerRow1);
            }




            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblAverage_TimeTaken_days = (Label)e.Row.FindControl("lblAverage_TimeTaken_days");
                Label lblHandOver_Completed_In_Two_Days = (Label)e.Row.FindControl("lblHandOver_Completed_In_Two_Days");
                Label lblHandOver_Completed_Beyond_Two_Days = (Label)e.Row.FindControl("lblHandOver_Completed_Beyond_Two_Days");
                Label lblPatternReady_Completed_In_three_Days = (Label)e.Row.FindControl("lblPatternReady_Completed_In_three_Days");
                Label lblPatternReady_Completed_Beyond_four_Days = (Label)e.Row.FindControl("lblPatternReady_Completed_Beyond_four_Days");
                Label lblPercent_One_Week_Delay_In_Sample = (Label)e.Row.FindControl("lblPercent_One_Week_Delay_In_Sample");
                Label lblPercent_On_time_sample_sent = (Label)e.Row.FindControl("lblPercent_On_time_sample_sent");
                Label lblPercent_One_Week_Delay_One_Week_In_Sample = (Label)e.Row.FindControl("lblPercent_One_Week_Delay_One_Week_In_Sample");

                rowno_without = rowno_without + 1;
                if (lblHandOver_Completed_In_Two_Days.Text != "0")
                    lblHandOver_Completed_In_Two_Days.Text = lblHandOver_Completed_In_Two_Days.Text + "%";
                else
                    lblHandOver_Completed_In_Two_Days.Text = "";
                if (lblHandOver_Completed_Beyond_Two_Days.Text != "0")
                    lblHandOver_Completed_Beyond_Two_Days.Text = lblHandOver_Completed_Beyond_Two_Days.Text + "%";
                else
                    lblHandOver_Completed_Beyond_Two_Days.Text = "";

                if (lblPatternReady_Completed_In_three_Days.Text != "0")
                    lblPatternReady_Completed_In_three_Days.Text = lblPatternReady_Completed_In_three_Days.Text + "%";
                else
                    lblPatternReady_Completed_In_three_Days.Text = "";
                if (lblPatternReady_Completed_Beyond_four_Days.Text != "0")
                    lblPatternReady_Completed_Beyond_four_Days.Text = lblPatternReady_Completed_Beyond_four_Days.Text + "%";
                else
                    lblPatternReady_Completed_Beyond_four_Days.Text = "";
                if (lblPercent_One_Week_Delay_In_Sample.Text != "0")
                    lblPercent_One_Week_Delay_In_Sample.Text = lblPercent_One_Week_Delay_In_Sample.Text + "%";
                else
                    lblPercent_One_Week_Delay_In_Sample.Text = "";
                if (lblPercent_On_time_sample_sent.Text != "0")
                    lblPercent_On_time_sample_sent.Text = lblPercent_On_time_sample_sent.Text + "%";
                else
                    lblPercent_On_time_sample_sent.Text = "";
                if (lblPercent_One_Week_Delay_One_Week_In_Sample.Text != "0")
                    lblPercent_One_Week_Delay_One_Week_In_Sample.Text = lblPercent_One_Week_Delay_One_Week_In_Sample.Text + "%";
                else
                    lblPercent_One_Week_Delay_One_Week_In_Sample.Text = "";


                if (Convert.ToInt32(lblAverage_TimeTaken_days.Text) > 18)
                {
                    lblAverage_TimeTaken_days.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    if (lblAverage_TimeTaken_days.Text == "0")
                    {
                        lblAverage_TimeTaken_days.Text = "";
                    }
                    lblAverage_TimeTaken_days.ForeColor = System.Drawing.Color.Green;
                }

                // string valueAdd = 
                Total_without = Total_without + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TotalPendingSampleSent").ToString());

                ETA1Week_without = ETA1Week_without + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "ETA_In_One_Week").ToString());
                Wk1Dly_without = Wk1Dly_without + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "One_Week_Delay").ToString());
                Wk2Dly_without = Wk2Dly_without + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TwoWeekDlyInweek").ToString());


                CompletedHandOver_without = CompletedHandOver_without + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedHandover").ToString());

                AvgLeadDaysHandOver_without = AvgLeadDaysHandOver_without + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "HandOver_Avg_Leadtime"));

                ComPatternReady_without = ComPatternReady_without + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "CompletedPatternReady").ToString());
                AvgLeadDaysPattern_without = AvgLeadDaysPattern_without + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PatternReady_Avg_Leadtime"));


                AvgTimeLine_without = AvgTimeLine_without + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Average_TimeLine_Givendays").ToString());
                AvgTimeTaken_without = AvgTimeTaken_without + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Average_TimeTaken_days").ToString());
                AvgStyleCreatedAll_without = AvgStyleCreatedAll_without + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Avg_style_created_all").ToString());
                AvgStyleCreatedSample_without = AvgStyleCreatedSample_without + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Avg_style_created_With_sample").ToString());
                TotalPendingSampleSent_WithOneweek = TotalPendingSampleSent_WithOneweek + Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "PendingSampleSent_WithOneweek").ToString());

            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblfoo_TotalPendingSampleSent = (Label)e.Row.FindControl("lblfoo_TotalPendingSampleSent");
                Label lblfoo_ETA_In_One_Week = (Label)e.Row.FindControl("lblfoo_ETA_In_One_Week");
                Label lblfoo_One_Week_Delay = (Label)e.Row.FindControl("lblfoo_One_Week_Delay");
                Label lblfoo_TwoWeekDlyInweek = (Label)e.Row.FindControl("lblfoo_TwoWeekDlyInweek");

                Label lblfoo_CompletedHandover = (Label)e.Row.FindControl("lblfoo_CompletedHandover");
                Label lblfoo_HandOver_Avg_Leadtime = (Label)e.Row.FindControl("lblfoo_HandOver_Avg_Leadtime");
                Label lblfoo_HandOver_Completed_In_Two_Days = (Label)e.Row.FindControl("lblfoo_HandOver_Completed_In_Two_Days");
                Label lblfoo_HandOver_Completed_Beyond_Two_Days = (Label)e.Row.FindControl("lblfoo_HandOver_Completed_Beyond_Two_Days");


                Label lblfoo_CompletedPatternReady = (Label)e.Row.FindControl("lblfoo_CompletedPatternReady");
                Label lblfoo_PatternReady_Avg_Leadtime = (Label)e.Row.FindControl("lblfoo_PatternReady_Avg_Leadtime");
                Label lblfoo_PatternReady_Completed_In_three_Days = (Label)e.Row.FindControl("lblfoo_PatternReady_Completed_In_three_Days");
                Label lblfoo_PatternReady_Completed_Beyond_four_Days = (Label)e.Row.FindControl("lblfoo_PatternReady_Completed_Beyond_four_Days");

                Label lblfoo_Average_TimeLine_Givendays = (Label)e.Row.FindControl("lblfoo_Average_TimeLine_Givendays");
                Label lblfoo_Average_TimeTaken_days = (Label)e.Row.FindControl("lblfoo_Average_TimeTaken_days");
                Label lblfoo_Avg_style_created_all = (Label)e.Row.FindControl("lblfoo_Avg_style_created_all");
                Label lblfoo_Avg_style_created_With_sample = (Label)e.Row.FindControl("lblfoo_Avg_style_created_With_sample");

                Label lblfoo_Percent_On_time_sample_sent = (Label)e.Row.FindControl("lblfoo_Percent_On_time_sample_sent");
                Label lblfoo_Percent_One_Week_Delay_In_Sample = (Label)e.Row.FindControl("lblfoo_Percent_One_Week_Delay_In_Sample");
                Label lblfoo_Percent_One_Week_Delay_One_Week_In_Sample = (Label)e.Row.FindControl("lblfoo_Percent_One_Week_Delay_One_Week_In_Sample");

                Label lblfoo_TotalPendingSampleSent_WithOneweek = (Label)e.Row.FindControl("lblfoo_TotalPendingSampleSent_WithOneweek");

                Label lblFoo_total = (Label)e.Row.FindControl("lblFoo_total");
                lblFoo_total.Text = "Total";
                e.Row.Font.Bold = true;
                e.Row.BackColor = System.Drawing.Color.FromName("#FFF0A5");
                e.Row.Cells[0].ColumnSpan = 1;
                e.Row.Cells[1].Visible = false;
                if (Total_without > 0)
                {
                    lblfoo_TotalPendingSampleSent.Text = Total_without.ToString();
                }
                if (ETA1Week_without > 0)
                {
                    lblfoo_ETA_In_One_Week.Text = ETA1Week_without.ToString();
                }
                if (Wk1Dly_without > 0)
                {
                    lblfoo_One_Week_Delay.Text = Wk1Dly_without.ToString();
                }
                if (Wk2Dly_without > 0)
                {
                    lblfoo_TwoWeekDlyInweek.Text = Wk2Dly_without.ToString();
                }
                if (CompletedHandOver_without > 0)
                {
                    lblfoo_CompletedHandover.Text = CompletedHandOver_without.ToString();
                }
                if ((AvgLeadDaysHandOver_without / rowno_without) > 0)
                {
                    lblfoo_HandOver_Avg_Leadtime.Text = (AvgLeadDaysHandOver_without / rowno_without).ToString();
                }

                lblfoo_HandOver_Completed_In_Two_Days.Text = DeptFooter.Rows[0]["HandOver_Completed_With_in_two_Days_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["HandOver_Completed_With_in_two_Days_Total"].ToString() + "%";
                lblfoo_HandOver_Completed_Beyond_Two_Days.Text = DeptFooter.Rows[0]["HandOver_Completed_Beyond_two_Days_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["HandOver_Completed_Beyond_two_Days_Total"].ToString() + "%";
                if (ComPatternReady_without > 0)
                {
                    lblfoo_CompletedPatternReady.Text = ComPatternReady_without.ToString();
                }
                if ((AvgLeadDaysPattern_without / rowno_without) > 0)
                {
                    lblfoo_PatternReady_Avg_Leadtime.Text = (AvgLeadDaysPattern_without / rowno_without).ToString();
                }
                lblfoo_PatternReady_Completed_In_three_Days.Text = DeptFooter.Rows[0]["PatternReady_Completed_With_in_three_Days_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["PatternReady_Completed_With_in_three_Days_Total"].ToString() + "%";
                lblfoo_PatternReady_Completed_Beyond_four_Days.Text = DeptFooter.Rows[0]["PatternReady_Completed_Beyond_four_Days_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["PatternReady_Completed_Beyond_four_Days_Total"].ToString() + "%";
                if ((AvgTimeLine_without / rowno_without) > 0)
                {
                    lblfoo_Average_TimeLine_Givendays.Text = (AvgTimeLine_without / rowno_without).ToString();
                }

                if ((AvgTimeTaken_without / rowno_without) > 18)
                {
                    lblfoo_Average_TimeTaken_days.ForeColor = System.Drawing.Color.Red;
                    lblfoo_Average_TimeTaken_days.Text = DeptFooter.Rows[0]["Average_TimeTaken_days_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Average_TimeTaken_days_Total"].ToString();
                }
                else
                {
                    if ((AvgTimeTaken_without / rowno_without) > 0)
                    {
                        lblfoo_Average_TimeTaken_days.Text = DeptFooter.Rows[0]["Average_TimeTaken_days_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Average_TimeTaken_days_Total"].ToString();
                    }
                    lblfoo_Average_TimeTaken_days.ForeColor = System.Drawing.Color.Green;
                }
                if ((AvgStyleCreatedAll_without / rowno_without) > 0)
                {
                    lblfoo_Avg_style_created_all.Text = DeptFooter.Rows[0]["Avg_style_created_all_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Avg_style_created_all_Total"].ToString();
                }
                if ((AvgStyleCreatedSample_without / rowno_without) > 0)
                {
                    lblfoo_Avg_style_created_With_sample.Text = DeptFooter.Rows[0]["Avg_style_created_With_sample_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Avg_style_created_With_sample_Total"].ToString();
                }

                if (TotalPendingSampleSent_WithOneweek > 0)
                {
                    lblfoo_TotalPendingSampleSent_WithOneweek.Text = TotalPendingSampleSent_WithOneweek.ToString();
                }
                lblfoo_Percent_On_time_sample_sent.Text = DeptFooter.Rows[0]["Percent_On_time_sample_sent_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Percent_On_time_sample_sent_Total"].ToString() + "%";
                lblfoo_Percent_One_Week_Delay_In_Sample.Text = DeptFooter.Rows[0]["Percent_One_Week_Delay_In_Sample_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Percent_One_Week_Delay_In_Sample_Total"].ToString() + "%";
                lblfoo_Percent_One_Week_Delay_One_Week_In_Sample.Text = DeptFooter.Rows[0]["Percent_One_Week_Delay_One_Week_In_Sample_Total"].ToString() == "0" ? "" : DeptFooter.Rows[0]["Percent_One_Week_Delay_One_Week_In_Sample_Total"].ToString() + "%";
            }
        }

        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            for (int i = GridView1.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = GridView1.Rows[i];
                GridViewRow previousRow = GridView1.Rows[i - 1];

                Label lblPdMerchant = (Label)row.FindControl("lblPdMerchant");
                Label lblPreviousPdMerchant = (Label)previousRow.FindControl("lblPdMerchant");

                if (lblPdMerchant.Text == lblPreviousPdMerchant.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                }
            }
        }
        public void CreateExcel(DataSet ds)
        {
            AdminController objadmin = new AdminController();
            ReportController controller = new ReportController();
            string sourcePath = @"E:\";

            string GlobalType_Upcomming_Exfactory = "Sampling-status.xlsx";
            if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_Upcomming_Exfactory)))
            {
                System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_Upcomming_Exfactory);
            }
            //if ((System.IO.File.Exists("\\\\192.168.0.4\\Sampling-status\\Sampling-status.xlsx")))
            //{
            //  System.IO.File.Delete("\\\\192.168.0.4\\Sampling-status\\Sampling-status.xlsx");
            //}
            string targetPath_UpcommingExfactory = Constants.FITS_FOLDER_PATH + GlobalType_Upcomming_Exfactory;
            string sourceFile_UpcommingExfactory = System.IO.Path.Combine(sourcePath, GlobalType_Upcomming_Exfactory);
            string destFile_UpcommingExfactory = System.IO.Path.Combine(targetPath_UpcommingExfactory, GlobalType_Upcomming_Exfactory);
            System.IO.File.Copy(sourceFile_UpcommingExfactory, targetPath_UpcommingExfactory, true);


          string ReportType = "Sampling-status";
          //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
          string pdfFilePath_Upcomming_Exfactory = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Upcomming_Exfactory);
          bool success = controller.GenerateFitsReportExcel(pdfFilePath_Upcomming_Exfactory, ReportType, ds = objadmin.GetFitsReport("Sampling-status"), GlobalType_Upcomming_Exfactory);



        }





    }
}