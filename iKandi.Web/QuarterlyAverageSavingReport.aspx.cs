using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace iKandi.Web.Internal.Production
{
    public partial class QuarterlyAverageSavingReport : System.Web.UI.Page
    {
        ProductionController objProductionController = new ProductionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            //BindTable();
            CreateExcel(ds);  
            BindRevenueReport();
            BindFinancialSavingReport();
           //     //UNCOMMENT AFTER TESTING 22-07-2020 -------------------------------------------------
            string Fabric_Average_Saving_C47_ = "BIPLCOSTTOORDERREVENUELK" + ".png";
            string Fabric_Average_Saving_C47_Img = System.IO.Path.Combine("http://boutique.in:81/pic/", Fabric_Average_Saving_C47_);
            Fabric_Average_Saving_C47.Src = Fabric_Average_Saving_C47_Img;

            string Fabric_Average_Saving_C4546 = "biplCosttoOrderSavingPer" + ".png";
            string Fabric_Average_Saving_C4546_Img = System.IO.Path.Combine("http://boutique.in:81/pic/", Fabric_Average_Saving_C4546);
            Fabric_Average_Saving_C45_46.Src = Fabric_Average_Saving_C4546_Img;

            string Fabric_Average_Saving_D169_ = "BIPLORDERTOCUTREVENUELK" + ".png";
            string Fabric_Average_Saving_D169_Img = System.IO.Path.Combine("http://boutique.in:81/pic/", Fabric_Average_Saving_D169_);
            Fabric_Average_Saving_D_169.Src = Fabric_Average_Saving_D169_Img;

            string biplOrdertoCutSaving_ = "biplOrdertoCutSavingper" + ".png";
            string biplOrdertoCutSaving_Img = System.IO.Path.Combine("http://boutique.in:81/pic/", biplOrdertoCutSaving_);
            biplOrdertoCutSavingImg.Src = biplOrdertoCutSaving_Img;
        }
        //added by raghvinder on 22-07-2020 start
        //double Quantity, Cost_Order_Rev, Cost_Order_Weighted, Order_Cut_Rev, Order_Cut_Weighted, Exfactory, FinalOrderWeighted, FinalCutWeighted;
        protected void BindFinancialSavingReport()
        {
            DataTable dt = objProductionController.GetFinancialSavingReport();
            grdFinancialSavingReport.DataSource = dt;
            grdFinancialSavingReport.DataBind();

            GridViewRow lastrow = grdFinancialSavingReport.Rows[(grdFinancialSavingReport.Rows.Count) - 1];
            lastrow.BackColor = System.Drawing.Color.FromName("#ffefef");

            for (int i = 0; i < lastrow.Cells.Count; i++)
            {
                lastrow.Cells[i].Font.Bold = true;
            } 

        }
        //added by raghvinder on 22-07-2020 end


        //added by raghvinder on 21-07-2020 start
        protected void BindRevenueReport()
        {
            DataTable dt = objProductionController.GetMeterRevenueReport();
            if (dt.Rows.Count > 0)
            {
                DataTable dt_diffSummaryReport = dt;

                //string Total_CostToOrder = dt_diffSummaryReport.Rows[dt_diffSummaryReport.Rows.Count - 1]["Cost-Order Rev"].ToString();     
                //string Total_CostToOrder_weightage = dt_diffSummaryReport.Rows[dt_diffSummaryReport.Rows.Count - 1]["Cost-Order Weight"].ToString();

                //string Total_OrderCut = dt_diffSummaryReport.Rows[dt_diffSummaryReport.Rows.Count - 1]["Order - Cut Rev"].ToString();
                //string Total_OrderCut_weightage = dt_diffSummaryReport.Rows[dt_diffSummaryReport.Rows.Count - 1]["Order -Cut Weight"].ToString();
                //string totalRevenCostOrder = "₹ " + Total_CostToOrder;
                //string totalRevenCutOrder = "₹ " + Total_OrderCut;
                //HtmlTableRow tRow1 = new HtmlTableRow();
                //HtmlTableCell tb1 = new HtmlTableCell();
                //HtmlTableCell tb2 = new HtmlTableCell();
                //HtmlTableCell tb3 = new HtmlTableCell();
                //HtmlTableCell tb4 = new HtmlTableCell();

                //    if (Math.Round(Convert.ToDecimal(Total_CostToOrder)/100000, MidpointRounding.AwayFromZero) < 1)
                //    {
                        
                //        tb1.InnerText = "";
                //        tRow1.Controls.Add(tb1);
                //    }
                //    else
                //    {                     
                //        tb1.InnerText = Math.Round(Convert.ToDecimal(Total_CostToOrder) / 100000, MidpointRounding.AwayFromZero).ToString("N0") + " L";
                //        tb1.Attributes.Add("title", totalRevenCostOrder);
                //        tRow1.Controls.Add(tb1); 
                       
                        
                //    }

                //    if (Math.Round(Convert.ToDecimal(Total_CostToOrder_weightage), MidpointRounding.AwayFromZero) < 1)
                //    {
                //        tb2.InnerText = "";
                //        tRow1.Controls.Add(tb2);
                //    }
                //    else
                //    {
                //        tb2.InnerText = Convert.ToDecimal(Total_CostToOrder_weightage).ToString("N1") + " %";
                //        tRow1.Controls.Add(tb2);                        
                //    }
                
                //    if (Math.Round(Convert.ToDecimal(Total_OrderCut) / 100000, MidpointRounding.AwayFromZero) < 1)
                //    {
                //        tb1.InnerText = "";
                //        tRow1.Controls.Add(tb1);
                //    }
                //    else
                //    {                        
                //        tb3.InnerText = Math.Round(Convert.ToDecimal(Total_OrderCut) / 100000, MidpointRounding.AwayFromZero).ToString("N0") + " L";
                //        tb3.Attributes.Add("title", totalRevenCutOrder);
                //        tRow1.Controls.Add(tb3);
                        
                //    }
                

                //    if (Math.Round(Convert.ToDecimal(Total_OrderCut_weightage), MidpointRounding.AwayFromZero) < 1)
                //    {
                //        tb4.InnerText = "";
                //        tRow1.Controls.Add(tb4);
                //    }
                //    else
                //    {
                //        tb4.InnerText = Convert.ToDecimal(Total_OrderCut_weightage).ToString("N1") + " %";
                //        tRow1.Controls.Add(tb4);                        
                //    }
                

                //diffSummaryReport.Rows.Add(tRow1);                
                
                double TotalCount = dt_diffSummaryReport.AsEnumerable().Count()-1;          //Getting Total Count of Rows of a table Except Last Row
                
                double CostToOrder_count2 = dt_diffSummaryReport.AsEnumerable().Count(row => row.Field<int>("Cost-Order %") <= 1 && row.Field<int>("Cost-Order %") >= 0);
                
                double OrderToCut_count2 = dt_diffSummaryReport.AsEnumerable().Count(row => row.Field<int>("Order -Cut Rev %") <= 1 && row.Field<int>("Order -Cut Rev %") >= 0);

                double costOrderPerct = (CostToOrder_count2 / TotalCount) * 100;                 
                double costOrder_BeyondPerct = ((TotalCount - CostToOrder_count2) / TotalCount) * 100;

                double orderCutPerct = (OrderToCut_count2 / TotalCount) * 100;
                double orderCut_BeyondPerct = ((TotalCount - OrderToCut_count2) / TotalCount) * 100;
                                

                HtmlTableRow tRow2 = new HtmlTableRow();
                HtmlTableCell tb5 = new HtmlTableCell();
                HtmlTableCell tb6 = new HtmlTableCell();
                HtmlTableCell tb7 = new HtmlTableCell();
                HtmlTableCell tb8 = new HtmlTableCell();

                if (Math.Round(costOrderPerct, MidpointRounding.AwayFromZero).ToString("N0") == "0")
                {
                    tb5.InnerText = "";
                    tRow2.Controls.Add(tb5);
                }
                else
                {
                    tb5.InnerText = Math.Round(costOrderPerct, MidpointRounding.AwayFromZero).ToString("N0") + " %";
                    tRow2.Controls.Add(tb5);
                }

                if (Math.Round(costOrder_BeyondPerct, MidpointRounding.AwayFromZero).ToString("N0") == "0")
                {
                    tb6.InnerText = "";
                    tRow2.Controls.Add(tb6);
                }
                else
                {
                    tb6.InnerText = Math.Round(costOrder_BeyondPerct, MidpointRounding.AwayFromZero).ToString("N0") + " %";
                    tRow2.Controls.Add(tb6);
                }

                if (Math.Round(orderCutPerct, MidpointRounding.AwayFromZero).ToString("N0") == "0")
                {
                    tb7.InnerText = "";
                    tRow2.Controls.Add(tb7);
                }
                else
                {
                    tb7.InnerText = Math.Round(orderCutPerct, MidpointRounding.AwayFromZero).ToString("N0") + " %";
                    tRow2.Controls.Add(tb7);
                }

                if (Math.Round(orderCut_BeyondPerct, MidpointRounding.AwayFromZero).ToString("N0") == "0")
                {
                    tb8.InnerText = "";
                    tRow2.Controls.Add(tb8);            
                }
                else
                {
                    tb8.InnerText = Math.Round(orderCut_BeyondPerct, MidpointRounding.AwayFromZero).ToString("N0") + " %";      //Assign Text to TableCell
                    tRow2.Controls.Add(tb8);                //Adding TableCell to TableRow
                }
                avgDeviationReport.Rows.Add(tRow2);           //Adding TableRows to Table, "avgDeviationReport" is Id of Table    
                
            }

        }

        protected void grdFinancialSavingReport_RowCreated(object sender, GridViewRowEventArgs e)
        {            
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Month";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "50px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Cost to Order";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Order to Cut";
                HeaderCell.ColumnSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                grdFinancialSavingReport.Controls[0].Controls.AddAt(0, HeaderGridRow);

                GridViewRow HeaderGridRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revenue";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 1;
                HeaderCell.Style.Add("width", "100px");
                HeaderCell.CssClass = "txtRight";

                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Weighted %";
                HeaderCell.CssClass = "txtRight";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 1;
                HeaderCell.Style.Add("width", "50px");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Revenue";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 1;
                HeaderCell.Style.Add("width", "100px");
                HeaderCell.CssClass = "txtRight";
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Weighted %";
                HeaderCell.CssClass = "txtRight";
                HeaderCell.Style.Add("width", "50px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow1.Cells.Add(HeaderCell);

                grdFinancialSavingReport.Controls[0].Controls.AddAt(1, HeaderGridRow1);

            }
            
        }


        decimal CostOrderWeighted = 0;
        decimal OrderCutWeighted = 0;
       
    
        string TootilCostOrder;
        string TootilCutOrder;
        
        protected void grdFinancialSavingReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblMonth = (Label)e.Row.FindControl("lblMonth");
                Label lblCostOrderRev = (Label)e.Row.FindControl("lblCostOrderRev");
                Label lblCostOrderWeighted = (Label)e.Row.FindControl("lblCostOrderWeighted");
                Label lblOrderCutRev = (Label)e.Row.FindControl("lblOrderCutRev");
                Label lblOrderCutWeighted = (Label)e.Row.FindControl("lblOrderCutWeighted");                
                HiddenField lblQuantity = (HiddenField)e.Row.FindControl("lblQuantity");

                TootilCostOrder = "₹ " + lblCostOrderRev.Text;
                TootilCutOrder = "₹ " + lblOrderCutRev.Text;
                if (lblMonth.Text == "1")
                {
                    lblMonth.Text = "Jan";
                }

                if (lblMonth.Text == "2")
                {
                    lblMonth.Text = "Feb";
                }

                if (lblMonth.Text == "3")
                {
                    lblMonth.Text = "Mar";
                }
                if (lblMonth.Text == "4")
                {
                    lblMonth.Text = "Apr";
                }

                if (lblMonth.Text == "5")
                {
                    lblMonth.Text = "May";
                }

                if (lblMonth.Text == "6")
                {
                    lblMonth.Text = "Jun";
                }

                if (lblMonth.Text == "7")
                {
                    lblMonth.Text = "Jul";
                }
                if (lblMonth.Text == "8")
                {
                    lblMonth.Text = "Aug";
                }

                if (lblMonth.Text == "9")
                {
                    lblMonth.Text = "Sep";
                }

                if (lblMonth.Text == "10")
                {
                    lblMonth.Text = "Oct";
                }

                if (lblMonth.Text == "11")
                {
                    lblMonth.Text = "Nov";
                }
                if (lblMonth.Text == "12")
                {
                    lblMonth.Text = "Dec";
                }
                if (lblMonth.Text == "101")
                {
                    lblMonth.Text = "Total";
                }
                decimal _lakh = 100000;
                if (lblMonth.Text == "Total")
                {
                    if ((Convert.ToDecimal(lblCostOrderRev.Text) / _lakh) > 0)
                    {

                        lblCostOrderRev.Text = (Convert.ToDecimal(lblCostOrderRev.Text) / _lakh).ToString("N1") == "0.0" ? "" : "₹ " + Math.Round(Convert.ToDecimal(lblCostOrderRev.Text) / _lakh,0).ToString("N1") + " L";
                        lblCostOrderRev.ToolTip = TootilCostOrder;
                    }
                    else
                    {
                        lblCostOrderRev.Text = "";
                    }
                }
                else
                {
                    if ((Convert.ToDecimal(lblCostOrderRev.Text) / _lakh) > 0)
                    {

                        lblCostOrderRev.Text = (Convert.ToDecimal(lblCostOrderRev.Text) / _lakh).ToString("N1") == "0.0" ? "" : "₹ " + (Convert.ToDecimal(lblCostOrderRev.Text) / _lakh).ToString("N1") + " L";
                        lblCostOrderRev.ToolTip = TootilCostOrder;
                    }
                    else
                    {
                        lblCostOrderRev.Text = "";
                    }
                }
                if (lblMonth.Text == "Total")
                {
                    if ((Convert.ToDecimal(lblOrderCutRev.Text) / _lakh) > 0)
                    {
                        lblOrderCutRev.Text = (Convert.ToDecimal(lblOrderCutRev.Text) / _lakh).ToString("N1") == "0.0" ? "" : "₹ " + Math.Round(Convert.ToDecimal(lblOrderCutRev.Text) / _lakh,0).ToString("N1") + " L";
                        lblOrderCutRev.ToolTip = TootilCutOrder;
                    }
                    else
                    {
                        lblOrderCutRev.Text = "";
                    }
                }
                else
                {
                    if ((Convert.ToDecimal(lblOrderCutRev.Text) / _lakh) > 0)
                    {
                        lblOrderCutRev.Text = (Convert.ToDecimal(lblOrderCutRev.Text) / _lakh).ToString("N1") == "0.0" ? "" : "₹ " + (Convert.ToDecimal(lblOrderCutRev.Text) / _lakh).ToString("N1") + " L";
                        lblOrderCutRev.ToolTip = TootilCutOrder;
                    }
                    else
                    {
                        lblOrderCutRev.Text = "";
                    }
                }
                if (lblQuantity.Value != "0")
                {
                    CostOrderWeighted = (Convert.ToDecimal(lblCostOrderWeighted.Text) / Convert.ToDecimal(lblQuantity.Value)) * 100;
                }
                else { 
                  CostOrderWeighted = (Convert.ToDecimal(lblCostOrderWeighted.Text));
                }

                
                lblCostOrderWeighted.Text = Convert.ToDecimal(CostOrderWeighted).ToString();                

                if(Convert.ToDecimal(lblCostOrderWeighted.Text) > 0)                
                {
                    lblCostOrderWeighted.Text = Math.Round(Convert.ToDecimal(CostOrderWeighted) - (decimal)0.005, 1).ToString() + "%";
                }
                else
                {
                    
                    lblCostOrderWeighted.Text = "";
                }
                if (lblQuantity.Value != "0")
                {
                    OrderCutWeighted = (Convert.ToDecimal(lblOrderCutWeighted.Text) / Convert.ToDecimal(lblQuantity.Value)) * 100;
                }
                else {
                    OrderCutWeighted = (Convert.ToDecimal(lblOrderCutWeighted.Text));
                }
                                               
                lblOrderCutWeighted.Text = Convert.ToDecimal(OrderCutWeighted).ToString();
                
                if (Convert.ToDecimal(lblOrderCutWeighted.Text) > 0)                
                {
                    lblOrderCutWeighted.Text = Math.Round(Convert.ToDecimal(OrderCutWeighted) - (decimal)0.005, 1).ToString() + "%";   
                   
                }
                else
                {
                    lblOrderCutWeighted.Text = "";
                }
            }

        }//added by raghvinder on 21-07-2020 end
        


        //protected void BindTable()
        //{
        //    int month = DateTime.Now.Month;
        //    if (month == 1 || month == 2 || month == 3)
        //    {
        //        lblFinancialYr1.Text = DateTime.Now.AddYears(-1).ToString("yyyy") + "-" + DateTime.Now.ToString("yy");
        //        lblFinancialYr2.Text = DateTime.Now.AddYears(-1).ToString("yyyy") + "-" + DateTime.Now.ToString("yy");
        //    }
        //    else
        //    {
        //        lblFinancialYr1.Text = DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.AddYears(1).ToString("yy");
        //        lblFinancialYr2.Text = DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.AddYears(1).ToString("yy");
        //    }

        //    DataSet ds = objProductionController.GetQuarterlyAverageReport();
        //    if (ds.Tables.Count > 0)
        //    {
        //        DataTable dtAvrDeviation = ds.Tables[0];
        //        DataTable dtMonthlySavingReport = ds.Tables[1];
        //        DataTable dtTotal = ds.Tables[2];

        //        for (int i = 0; i < dtAvrDeviation.Rows.Count; i++)
        //        {
        //            HtmlTableRow tRow1 = new HtmlTableRow();

        //            HtmlTableCell tb = new HtmlTableCell();
        //            tb.InnerText = dtAvrDeviation.Rows[i]["Unit"].ToString();
        //            tRow1.Controls.Add(tb);

        //            HtmlTableCell tb2 = new HtmlTableCell();
        //            if (dtAvrDeviation.Rows[i]["InRange"].ToString() != "0%")
        //            {
        //                tb2.InnerText = dtAvrDeviation.Rows[i]["InRange"].ToString();
        //                tb2.Style.Add(HtmlTextWriterStyle.Color, "Green");
        //            }
        //            tRow1.Controls.Add(tb2);

        //            //HtmlTableCell tb3 = new HtmlTableCell();
        //            //tb3.InnerText = dtAvrDeviation.Rows[i]["OutRange"].ToString();
        //            //tb3.Style.Add(HtmlTextWriterStyle.Color, "Red");
        //            //tRow1.Controls.Add(tb3);

        //            avrDeviation.Rows.Add(tRow1);
        //            //HtmlTableCell tb4 = new HtmlTableCell();
        //            //if (dtAvrDeviation.Rows[i]["InRangeOpt2"].ToString() != "0%")
        //            //{
        //            //    tb4.InnerText = dtAvrDeviation.Rows[i]["InRangeOpt2"].ToString();
        //            //    tb4.Style.Add(HtmlTextWriterStyle.Color, "Green");
        //            //}
        //            //tRow1.Controls.Add(tb4);

        //            HtmlTableCell tb5 = new HtmlTableCell();
        //            if (dtAvrDeviation.Rows[i]["OutRange"].ToString() != "0%")
        //            {
        //                tb5.InnerText = dtAvrDeviation.Rows[i]["OutRange"].ToString();
        //                tb5.Style.Add(HtmlTextWriterStyle.Color, "Red");
        //            }
        //            tRow1.Controls.Add(tb5);

        //            avrDeviation.Rows.Add(tRow1);
        //        }

        //        for (int i = 0; i < dtMonthlySavingReport.Rows.Count; i++)
        //        {
        //            HtmlTableRow tRow2 = new HtmlTableRow();

        //            HtmlTableCell tb = new HtmlTableCell();
        //            tb.InnerText = dtMonthlySavingReport.Rows[i]["MnthName"].ToString();
        //            tRow2.Controls.Add(tb);

        //            HtmlTableCell tb1 = new HtmlTableCell();
        //            tb1.InnerText = dtMonthlySavingReport.Rows[i]["MtrSum"].ToString();
        //            if (Convert.ToInt32(dtMonthlySavingReport.Rows[i]["MtrSum"]) < 0)
        //            {
        //                tb1.InnerText = tb1.InnerText.Replace("-", "") + " k";
        //                tb1.Attributes.Add("class", "txtRightPadding1");
        //                tb1.Style.Add(HtmlTextWriterStyle.Color, "Green");
        //            }
        //            else if (Convert.ToInt32(dtMonthlySavingReport.Rows[i]["MtrSum"]) > 0)
        //            {
        //                tb1.InnerText += " k";
        //                tb1.Attributes.Add("class", "txtRightPadding1");
        //                tb1.Style.Add(HtmlTextWriterStyle.Color, "Red");
        //            }
        //            else
        //                tb1.InnerText = string.Empty;

        //            tRow2.Controls.Add(tb1);

        //            HtmlTableCell tb2 = new HtmlTableCell();
        //            tb2.InnerText = Convert.ToInt32(dtMonthlySavingReport.Rows[i]["KgSum"]).ToString("N0");
        //            if (Convert.ToInt32(dtMonthlySavingReport.Rows[i]["KgSum"]) < 0)
        //            {
        //                tb2.InnerText = tb2.InnerText.Replace("-", "");
        //                tb2.Style.Add(HtmlTextWriterStyle.TextAlign, "Center");
        //                tb2.Attributes.Add("class", "txtRightPadding1");
        //                tb2.Style.Add(HtmlTextWriterStyle.Color, "Green");
        //            }
        //            else if (Convert.ToInt32(dtMonthlySavingReport.Rows[i]["KgSum"]) > 0)
        //            {
        //                tb2.Style.Add(HtmlTextWriterStyle.TextAlign, "Center");
        //                tb2.Attributes.Add("class", "txtRightPadding1");
        //                tb2.Style.Add(HtmlTextWriterStyle.Color, "Red");
        //            }
        //            else
        //                tb2.InnerText = string.Empty;

        //            tRow2.Controls.Add(tb2);

        //            HtmlTableCell tb3 = new HtmlTableCell();
        //            tb3.InnerText = Convert.ToDecimal(dtMonthlySavingReport.Rows[i]["TotalRevenue"]) < 0 ? (Convert.ToDecimal(dtMonthlySavingReport.Rows[i]["TotalRevenue"]) * -1).ToString() : dtMonthlySavingReport.Rows[i]["TotalRevenue"].ToString();
        //            if (Convert.ToDecimal(dtMonthlySavingReport.Rows[i]["TotalRevenue"]) < 0)
        //            {
        //                tb3.InnerText = "₹" + tb3.InnerText.Replace("-", "") + " L";
        //                tb3.Attributes.Add("class", "txtRightPadding");
        //                tb3.Style.Add(HtmlTextWriterStyle.Color, "Green");
        //                //tb3.InnerText = "-" + tb3.InnerText;
        //            }
        //            else if (Convert.ToDecimal(dtMonthlySavingReport.Rows[i]["TotalRevenue"]) > 0)
        //            {
        //                tb3.InnerText = "₹" + tb3.InnerText + " L";
        //                tb3.Attributes.Add("class", "txtRightPadding");
        //                tb3.Style.Add(HtmlTextWriterStyle.Color, "Red");
        //            }
        //            else
        //                tb3.InnerText = string.Empty;

        //            tRow2.Controls.Add(tb3);

        //            // Added by Yadvendra on 21/11/2019
        //            HtmlTableCell tb4 = new HtmlTableCell();
        //            tb4.InnerText = dtMonthlySavingReport.Rows[i]["MtrSumCut_Order"].ToString();
        //            if (Convert.ToInt32(dtMonthlySavingReport.Rows[i]["MtrSumCut_Order"]) < 0)
        //            {
        //                tb4.InnerText = tb4.InnerText.Replace("-", "") + " k";
        //                tb4.Attributes.Add("class", "txtRightPadding1");
        //                tb4.Style.Add(HtmlTextWriterStyle.Color, "Green");
        //            }
        //            else if (Convert.ToInt32(dtMonthlySavingReport.Rows[i]["MtrSumCut_Order"]) > 0)
        //            {
        //                tb4.InnerText += " k";
        //                tb4.Attributes.Add("class", "txtRightPadding1");
        //                tb4.Style.Add(HtmlTextWriterStyle.Color, "Red");
        //            }
        //            else
        //                tb4.InnerText = string.Empty;

        //            tRow2.Controls.Add(tb4);

        //            HtmlTableCell tb5 = new HtmlTableCell();
        //            tb5.InnerText = Convert.ToInt32(dtMonthlySavingReport.Rows[i]["KgSumCut_Order"]).ToString("N0");
        //            if (Convert.ToInt32(dtMonthlySavingReport.Rows[i]["KgSumCut_Order"]) < 0)
        //            {
        //                tb5.InnerText = tb5.InnerText.Replace("-", "");
        //                tb5.Style.Add(HtmlTextWriterStyle.TextAlign, "Center");
        //                tb5.Attributes.Add("class", "txtRightPadding1");
        //                tb5.Style.Add(HtmlTextWriterStyle.Color, "Green");
        //            }
        //            else if (Convert.ToInt32(dtMonthlySavingReport.Rows[i]["KgSumCut_Order"]) > 0)
        //            {
        //                tb5.Style.Add(HtmlTextWriterStyle.TextAlign, "Center");
        //                tb5.Attributes.Add("class", "txtRightPadding1");
        //                tb5.Style.Add(HtmlTextWriterStyle.Color, "Red");
        //            }
        //            else
        //                tb5.InnerText = string.Empty;

        //            tRow2.Controls.Add(tb5);

        //            HtmlTableCell tb6 = new HtmlTableCell();
        //            tb6.InnerText = Convert.ToDecimal(dtMonthlySavingReport.Rows[i]["TotalRevenueCut_Order"]) < 0 ? (Convert.ToDecimal(dtMonthlySavingReport.Rows[i]["TotalRevenueCut_Order"]) * -1).ToString() : dtMonthlySavingReport.Rows[i]["TotalRevenueCut_Order"].ToString();
        //            if (Convert.ToDecimal(dtMonthlySavingReport.Rows[i]["TotalRevenueCut_Order"]) < 0)
        //            {
        //                tb6.InnerText = "₹" + tb6.InnerText.Replace("-", "") + " L";
        //                tb6.Attributes.Add("class", "txtRightPadding");
        //                tb6.Style.Add(HtmlTextWriterStyle.Color, "Green");
        //                //tb6.InnerText = "-" + tb6.InnerText;
        //            }
        //            else if (Convert.ToDecimal(dtMonthlySavingReport.Rows[i]["TotalRevenueCut_Order"]) > 0)
        //            {
        //                tb6.InnerText = "₹" + tb6.InnerText + " L";
        //                tb6.Attributes.Add("class", "txtRightPadding");
        //                tb6.Style.Add(HtmlTextWriterStyle.Color, "Red");
        //            }
        //            else
        //                tb6.InnerText = string.Empty;

        //            tRow2.Controls.Add(tb6);

        //            monthlySavingReport.Rows.Add(tRow2);
        //        }

        //        // Total Row
        //        HtmlTableRow tRow = new HtmlTableRow();

        //        HtmlTableCell tc1 = new HtmlTableCell();
        //        tc1.InnerText = dtTotal.Rows[0]["Combined"].ToString();
        //        tc1.Style.Add(HtmlTextWriterStyle.FontWeight, "600");
        //        tRow.Controls.Add(tc1);

        //        HtmlTableCell tc2 = new HtmlTableCell();
        //        tc2.InnerText = dtTotal.Rows[0]["MtrSum"].ToString() + " k";
        //        if (Convert.ToInt32(dtTotal.Rows[0]["MtrSum"]) < 0)
        //        {
        //            tc2.InnerText = tc2.InnerText.Replace("-", "");
        //            tc2.Style.Add(HtmlTextWriterStyle.FontWeight, "600");
        //            tc2.Attributes.Add("class", "txtRightPadding1");
        //            tc2.Style.Add(HtmlTextWriterStyle.Color, "Green");
        //        }
        //        else if (Convert.ToInt32(dtTotal.Rows[0]["MtrSum"]) > 0)
        //        {
        //            tc2.Style.Add(HtmlTextWriterStyle.FontWeight, "600");
        //            tc2.Attributes.Add("class", "txtRightPadding1");
        //            tc2.Style.Add(HtmlTextWriterStyle.Color, "Red");
        //        }

        //        tRow.Controls.Add(tc2);

        //        HtmlTableCell tc3 = new HtmlTableCell();
        //        tc3.InnerText = Convert.ToInt32(dtTotal.Rows[0]["KgSum"]).ToString("N0");
        //        if (Convert.ToInt32(dtTotal.Rows[0]["KgSum"]) < 0)
        //        {
        //            tc3.InnerText = tc3.InnerText.Replace("-", "");
        //            tc3.Style.Add(HtmlTextWriterStyle.FontWeight, "600");
        //            tc3.Attributes.Add("class", "txtRightPadding1");
        //            tc3.Style.Add(HtmlTextWriterStyle.Color, "Green");
        //        }
        //        else if (Convert.ToInt32(dtTotal.Rows[0]["KgSum"]) > 0)
        //        {
        //            tc3.Style.Add(HtmlTextWriterStyle.FontWeight, "600");
        //            tc3.Attributes.Add("class", "txtRightPadding1");
        //            tc3.Style.Add(HtmlTextWriterStyle.Color, "Red");
        //        }

        //        tRow.Controls.Add(tc3);

        //        HtmlTableCell tc4 = new HtmlTableCell();
        //        tc4.InnerText = "₹" + (Convert.ToDecimal(dtTotal.Rows[0]["TotalRevenue"]) < 0 ? (Convert.ToDecimal(dtTotal.Rows[0]["TotalRevenue"]) * -1).ToString() : dtTotal.Rows[0]["TotalRevenue"].ToString()) + " L";
        //        if (Convert.ToDecimal(dtTotal.Rows[0]["TotalRevenue"]) < 0)
        //        {
        //            tc4.InnerText = tc4.InnerText.Replace("-", "");
        //            tc4.Style.Add(HtmlTextWriterStyle.FontWeight, "600");
        //            tc4.Attributes.Add("class", "txtRightPadding1");
        //            tc4.Style.Add(HtmlTextWriterStyle.Color, "Green");
        //            //tc4.InnerText = "-" + tc4.InnerText;
        //        }
        //        else if (Convert.ToDecimal(dtTotal.Rows[0]["TotalRevenue"]) > 0)
        //        {
        //            tc4.Style.Add(HtmlTextWriterStyle.FontWeight, "600");
        //            tc4.Attributes.Add("class", "txtRightPadding1");
        //            tc4.Style.Add(HtmlTextWriterStyle.Color, "Red");
        //        }

        //        tRow.Controls.Add(tc4);

        //        HtmlTableCell tc5 = new HtmlTableCell();
        //        tc5.InnerText = dtTotal.Rows[0]["MtrSumCut_Order"].ToString() + " k";
        //        if (Convert.ToInt32(dtTotal.Rows[0]["MtrSumCut_Order"]) < 0)
        //        {
        //            tc5.InnerText = tc5.InnerText.Replace("-", "");
        //            tc5.Style.Add(HtmlTextWriterStyle.FontWeight, "600");
        //            tc5.Attributes.Add("class", "txtRightPadding1");
        //            tc5.Style.Add(HtmlTextWriterStyle.Color, "Green");
        //        }
        //        else if (Convert.ToInt32(dtTotal.Rows[0]["MtrSumCut_Order"]) > 0)
        //        {
        //            tc5.Style.Add(HtmlTextWriterStyle.FontWeight, "600");
        //            tc5.Attributes.Add("class", "txtRightPadding1");
        //            tc5.Style.Add(HtmlTextWriterStyle.Color, "Red");
        //        }

        //        tRow.Controls.Add(tc5);

        //        HtmlTableCell tc6 = new HtmlTableCell();
        //        tc6.InnerText = Convert.ToInt32(dtTotal.Rows[0]["KgSumCut_Order"]).ToString("N0");
        //        if (Convert.ToInt32(dtTotal.Rows[0]["KgSumCut_Order"]) < 0)
        //        {
        //            tc6.InnerText = tc6.InnerText.Replace("-", "");
        //            tc6.Style.Add(HtmlTextWriterStyle.FontWeight, "600");
        //            tc6.Attributes.Add("class", "txtRightPadding1");
        //            tc6.Style.Add(HtmlTextWriterStyle.Color, "Green");
        //        }
        //        else if (Convert.ToInt32(dtTotal.Rows[0]["KgSumCut_Order"]) > 0)
        //        {
        //            tc6.Style.Add(HtmlTextWriterStyle.FontWeight, "600");
        //            tc6.Attributes.Add("class", "txtRightPadding1");
        //            tc6.Style.Add(HtmlTextWriterStyle.Color, "Red");
        //        }

        //        tRow.Controls.Add(tc6);

        //        HtmlTableCell tc7 = new HtmlTableCell();
        //        tc7.InnerText = "₹" + (Convert.ToDecimal(dtTotal.Rows[0]["TotalRevenueCut_Order"]) < 0 ? (Convert.ToDecimal(dtTotal.Rows[0]["TotalRevenueCut_Order"]) * -1).ToString() : dtTotal.Rows[0]["TotalRevenueCut_Order"].ToString()) + " L";
        //        if (Convert.ToDecimal(dtTotal.Rows[0]["TotalRevenueCut_Order"]) < 0)
        //        {
        //            tc7.InnerText = tc7.InnerText.Replace("-", "");
        //            tc7.Style.Add(HtmlTextWriterStyle.FontWeight, "600");
        //            tc7.Attributes.Add("class", "txtRightPadding1");
        //            tc7.Style.Add(HtmlTextWriterStyle.Color, "Green");
        //            // tc7.InnerText = "-" + tc7.InnerText;
        //        }
        //        else if (Convert.ToDecimal(dtTotal.Rows[0]["TotalRevenueCut_Order"]) > 0)
        //        {
        //            tc7.Style.Add(HtmlTextWriterStyle.FontWeight, "600");
        //            tc7.Attributes.Add("class", "txtRightPadding1");
        //            tc7.Style.Add(HtmlTextWriterStyle.Color, "Red");
        //        }

        //        tRow.Controls.Add(tc7);
        //        tRow.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFEFBB");
        //        monthlySavingReport.Rows.Add(tRow);
        //    }
        //}

        //UNCOMMENT AFTER TESTING 22-07-2020 -------------------------------------------------

        public void CreateExcel(DataSet ds)
        {
            AdminController objadmin = new AdminController();
            ReportController controller = new ReportController();
            string sourcePath = @"C:\";

            string GlobalType_Meterage = "Fabric_Average_Saving.xlsx";
            if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_Meterage)))
            {
                System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_Meterage);
            }
            //if ((System.IO.File.Exists("\\\\192.168.0.4\\Sampling-status\\Sampling-status.xlsx")))
            //{
            //  System.IO.File.Delete("\\\\192.168.0.4\\Sampling-status\\Sampling-status.xlsx");
            //}
            string targetPath_Meterage = Constants.FITS_FOLDER_PATH + GlobalType_Meterage;
            string sourceFile_Meterage = System.IO.Path.Combine(sourcePath, GlobalType_Meterage);
            string File_UpcommingExfactory = System.IO.Path.Combine(targetPath_Meterage, GlobalType_Meterage);
            System.IO.File.Copy(sourceFile_Meterage, targetPath_Meterage, true);


            string ReportType = "Fabric_Average_Saving";
            //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
            string pdfFilePath_Meterage = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Meterage);
            bool success = controller.GenerateFitsReportExcel(pdfFilePath_Meterage, ReportType, ds = objadmin.GetFitsReport("Fabric_Average_Saving"), GlobalType_Meterage);



        }
    }
}