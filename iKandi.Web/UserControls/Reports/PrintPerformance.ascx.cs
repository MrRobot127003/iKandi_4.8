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
using iKandi.Web.Components;
using iKandi.Common;


namespace iKandi.Web
{
    public partial class PrintPerformance : BaseUserControl
    {
      
        int rowIndex = -1;
        int countClients = 0; //its counts the number of clients excluding the clients which have no department
        int countDepartments = 0; // its counts total number of department
        int countDesigners = 0; // its count the total numver of designers
        int countTotalRows = 0; // counts the total rows in the grid
        int countTotalColumn = 2;
        bool IsExtraheaderCreated = false;
        string clientName = string.Empty;
        DataSet dsPrintPerformance;
        DataTable dtPrintPerformance;
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                BindControls();
            }
        }


        public void BindControls()
        {
            dsPrintPerformance = new DataSet();
            dtPrintPerformance = new DataTable();
            int arrayIndexCountForTotal = 0; // it will count the total numbers of columns except the  columns for clients and department
            string clientNameBrforeAsign = string.Empty; // this is used to add value in the array for Print sold, print bought etc. column
            string clientNameAsigned = string.Empty; // this is used to add value in the array for Print sold, print bought etc. column
            string ClientNameBeforeDesignationWise = string.Empty;

            // To Get count 
            


            dsPrintPerformance = this.ReportControllerInstance.GetPrintsPerformanceReport(ddlYearSlot.SelectedValue);

            if (dsPrintPerformance.Tables.Count > 0)
            {
                if (dsPrintPerformance.Tables[5].Rows.Count > 0)  // TOTAL CLIENTS
                {
                    countClients = dsPrintPerformance.Tables[5].Rows.Count;
                }

                if (dsPrintPerformance.Tables[4].Rows.Count > 0)
                {
                    countDepartments = dsPrintPerformance.Tables[4].Rows.Count;
                    countTotalRows = dsPrintPerformance.Tables[4].Rows.Count;
                }

                if (dsPrintPerformance.Tables[3].Rows.Count > 0)
                {
                    countDesigners = dsPrintPerformance.Tables[3].Rows.Count;
                    arrayIndexCountForTotal = (countDesigners + 1) * 6;
                }
            }

            // To Add Coloumns
            dtPrintPerformance.Columns.Add("Client");
            dtPrintPerformance.Columns.Add("Department");

            DataColumn dcPrintBoughtTotal = new DataColumn();
            dcPrintBoughtTotal.ColumnName = "Print Bought";
            dtPrintPerformance.Columns.Add(dcPrintBoughtTotal);

            DataColumn dcPrintSoldTotal = new DataColumn();
            dcPrintSoldTotal.ColumnName = "Print Sold";
            dtPrintPerformance.Columns.Add(dcPrintSoldTotal);

            DataColumn dcQtyBookedTotal = new DataColumn();
            dcQtyBookedTotal.ColumnName = "Qty Booked";
            dtPrintPerformance.Columns.Add(dcQtyBookedTotal);

            DataColumn dcRevenueBookedTotal = new DataColumn();
            dcRevenueBookedTotal.ColumnName = "Revenue Booked";
            dtPrintPerformance.Columns.Add(dcRevenueBookedTotal);

            DataColumn dcPrintPerGarmetTotal = new DataColumn();
            dcPrintPerGarmetTotal.ColumnName = "Print Per Garmet";
            dtPrintPerformance.Columns.Add(dcPrintPerGarmetTotal);

            DataColumn dcHitRateTotal = new DataColumn();
            dcHitRateTotal.ColumnName = "HitRate";
            dtPrintPerformance.Columns.Add(dcHitRateTotal);

            for (int i = 0; i < countDesigners; i++, countTotalColumn++)
            {
                DataColumn dcPrintBought = new DataColumn();
                dcPrintBought.ColumnName = "Print Bought" + i;
                dtPrintPerformance.Columns.Add(dcPrintBought);

                DataColumn dcPrintSold = new DataColumn();
                dcPrintSold.ColumnName = "Print Sold" + i;
                dtPrintPerformance.Columns.Add(dcPrintSold);

                DataColumn dcQtyBooked = new DataColumn();
                dcQtyBooked.ColumnName = "Qty Booked" + i;
                dtPrintPerformance.Columns.Add(dcQtyBooked);

                DataColumn dcRevenueBooked = new DataColumn();
                dcRevenueBooked.ColumnName = "Revenue Booked" + i;
                dtPrintPerformance.Columns.Add(dcRevenueBooked);

                DataColumn dcPrintPerGarmet = new DataColumn();
                dcPrintPerGarmet.ColumnName = "Print Per Garmet" + i;
                dtPrintPerformance.Columns.Add(dcPrintPerGarmet);

                DataColumn dcHitRate = new DataColumn();
                dcHitRate.ColumnName = "HitRate" + i;
                dtPrintPerformance.Columns.Add(dcHitRate);
            }

           

            DataRow drPrintRow = dtPrintPerformance.NewRow();

            int sumPrintBought = 0;
            int sumPrintSold = 0;
            int sumQuantityBooked = 0;
            double sumRevenueBooked = 0;
            double totalPrintCost = 0;

            drPrintRow[0] = "Total";
            drPrintRow[1] = "";

            for (int j = 0; j < countDesigners; j++) // Initialisation of array with initial value
            {
                int bought = 0;
                int sold = 0;
                double printCost = 0.0;
                int qtyBooked = 0;
                double hitRate = 0;
                double printPerGarmet = 0;
                double revBooked = 0;
                

                string strTotalPrintBoughtForDesigner = "UserID=" + dsPrintPerformance.Tables[3].Rows[j]["UserID"];
                DataRow[] drTotalPrintBoughtForDesigner = dsPrintPerformance.Tables[12].Select(strTotalPrintBoughtForDesigner);

                if (drTotalPrintBoughtForDesigner.Length > 0)
                {
                     bought = (drTotalPrintBoughtForDesigner[0]["TotalPrints"] == DBNull.Value) ? 0 : Convert.ToInt32(drTotalPrintBoughtForDesigner[0]["TotalPrints"]);
                    drPrintRow["Print Bought" + j] = bought;

                    sumPrintBought +=  bought;
                }
                else
                {
                    bought = 0;
                    drPrintRow["Print Bought" + j] = 0;                   

                }

                string strPrintSold = "UserID=" + dsPrintPerformance.Tables[3].Rows[j]["UserID"];
                DataRow[] drPrintSold = dsPrintPerformance.Tables[10].Select(strPrintSold);

                if (drPrintSold.Length > 0)
                {
                     sold = (drPrintSold[0]["TotalSoldPrints"] == DBNull.Value) ? 0 : Convert.ToInt32(drPrintSold[0]["TotalSoldPrints"]);
                   drPrintRow["Print Sold" + j] = sold;
                   sumPrintSold +=  sold;
                    printCost = (drPrintSold[0]["TotalPrintCost"] == DBNull.Value) ? 0.00 : Convert.ToDouble(drPrintSold[0]["TotalPrintCost"]);
                    printCost = Math.Round(printCost, 2);
                }
                else
                {
                    sold = 0;
                    drPrintRow["Print Sold" + j] = 0;                   
                    printCost = 0.00;
                }

                string strQtyOrRev =  "UserID=" + dsPrintPerformance.Tables[3].Rows[j]["UserID"];
                DataRow[] drQtyOrRev = dsPrintPerformance.Tables[11].Select(strQtyOrRev);

                if (drQtyOrRev.Length > 0)
                {
                     qtyBooked = (drQtyOrRev[0]["QtyBooked"] == DBNull.Value) ? 0 : Convert.ToInt32(drQtyOrRev[0]["QtyBooked"]);
                     drPrintRow["Qty Booked" + j] = qtyBooked;

                     revBooked = (drQtyOrRev[0]["RevenueBooked"] == DBNull.Value) ? 0 : Convert.ToDouble(drQtyOrRev[0]["RevenueBooked"]);
                    revBooked = Math.Round(revBooked, 2);
                    drPrintRow["Revenue Booked" + j] = revBooked;

                    sumQuantityBooked += qtyBooked;
                    sumRevenueBooked += revBooked;
                }
                else
                {

                    drPrintRow["Qty Booked" + j] = 0;
                    drPrintRow["Revenue Booked" + j] = 0;
                    qtyBooked = 0;
                    revBooked = 0;
                }


                if (bought > 0)
                {
                    hitRate = ((double)sold / (double)bought) * 100;
                    
                }

                drPrintRow["HitRate" + j] = hitRate;

                if (qtyBooked > 0)
                {
                    printPerGarmet = Math.Round((double)printCost / (double)qtyBooked, 2);

                }

                drPrintRow["Print Per Garmet" + j] = printPerGarmet;

                
            }


            // asign total sum of designer rowwise
            drPrintRow["Print Bought"] = sumPrintBought;
            drPrintRow["Print Sold"] = sumPrintSold;
            drPrintRow["Qty Booked"] = sumQuantityBooked;
            drPrintRow["Revenue Booked"] = sumRevenueBooked;

            if (sumPrintBought > 0)
            {
                drPrintRow["HitRate"] = Math.Round(((double)sumPrintSold / (double)sumPrintBought) * 100);
            }
            else
            {
                drPrintRow["HitRate"] = 0;
            }

            // it is used to get ToTal PrintCost booked for each client designerwise

           

            if (dsPrintPerformance.Tables[9].Rows.Count > 0)
            {
                totalPrintCost = (dsPrintPerformance.Tables[9].Rows[0]["TotalPrintCost"] == DBNull.Value) ? 0.00 : Convert.ToDouble(dsPrintPerformance.Tables[9].Rows[0]["TotalPrintCost"]);

            }
            else
            {
                totalPrintCost = 0.00;
            }

             if (sumQuantityBooked > 0)
            {
                drPrintRow["Print Per Garmet"] = totalPrintCost / sumQuantityBooked;
            }
            else
            {
                drPrintRow["Print Per Garmet"] = 0;
            }


            // add row to datatable
            dtPrintPerformance.Rows.Add(drPrintRow);

            


            //// to add rows for  total
            //DataRow drForTotalColumnWise = dtPrintPerformance.NewRow();
            //drForTotalColumnWise[0] = "Total";
            //drForTotalColumnWise[1] = "";

            //for (int k = 0; k < countDesigners; k++)
            //{
			 
            //}
            
            //dtPrintPerformance.Rows.Add(drForTotalColumnWise);

            // To Add Rows
            for (int i = 0; i < countTotalRows; i++)
            {

                DataRow drPrintRows = dtPrintPerformance.NewRow();

                if (dsPrintPerformance.Tables[4].Rows.Count > 0)
                {
                    drPrintRows["Client"] = (dsPrintPerformance.Tables[4].Rows[i]["CompanyName"] == DBNull.Value) ? string.Empty : Convert.ToString(dsPrintPerformance.Tables[4].Rows[i]["CompanyName"]);
                    clientNameAsigned = (dsPrintPerformance.Tables[4].Rows[i]["CompanyName"] == DBNull.Value) ? string.Empty : Convert.ToString(dsPrintPerformance.Tables[4].Rows[i]["CompanyName"]);
                    drPrintRows["Department"] = (dsPrintPerformance.Tables[4].Rows[i]["DepartmentName"] == DBNull.Value) ? string.Empty : Convert.ToString(dsPrintPerformance.Tables[4].Rows[i]["DepartmentName"]);
                }

                // Variables used to get sumDesignerWise
                int sumPrintSoldDesignerWise = 0;
                int sumPrintBoughtDesignerWise = 0;
                int sumQuantityBookedDesignerWise = 0;
                double sumRevenueBookedDesignerWise = 0;
                double sumHitRateDesignerWise = 0;
                double PrintperGarmetDesignerWise = 0;
                double QuantityBookedDesignerWise = 0;



                for (int j = 0; j < countDesigners; j++)
                {
                   // int k = 6;
                    int sold = 0;
                    int bought = 0;
                    int totalQtyBookedDepartmentwise = 0;                   
                    double hitRate = 0.00;
                    double printCost = 0.00;
                    double printPerGarmet = 0.00;
                    int qtyBooked = 0;
                    double revBooked = 0.00;

                    string strPrintBought = "clientid=" + dsPrintPerformance.Tables[4].Rows[i]["clientid"] + "and UserID=" + dsPrintPerformance.Tables[3].Rows[j]["UserID"];
                    DataRow[] drPrintBought = dsPrintPerformance.Tables[0].Select(strPrintBought);

                    if (drPrintBought.Length > 0)
                    {
                        bought = (drPrintBought[0]["TotalPrints"] == DBNull.Value) ? 0 : Convert.ToInt32(drPrintBought[0]["TotalPrints"]);
                        drPrintRows["Print Bought" + j] = bought;
                       
                        sumPrintBoughtDesignerWise = sumPrintBoughtDesignerWise + bought;
                    }
                    else
                    {
                        drPrintRows["Print Bought" + j] = 0;
                        bought = 0;

                    }

                    string strPrintSold = "clientid=" + dsPrintPerformance.Tables[4].Rows[i]["clientid"] + "and UserID=" + dsPrintPerformance.Tables[3].Rows[j]["UserID"];
                    DataRow[] drPrintSold = dsPrintPerformance.Tables[1].Select(strPrintBought);

                    if (drPrintSold.Length > 0)
                    {
                        sold = (drPrintSold[0]["TotalSoldPrints"] == DBNull.Value) ? 0 : Convert.ToInt32(drPrintSold[0]["TotalSoldPrints"]);
                        drPrintRows["Print Sold" + j] = sold;
                        sumPrintSoldDesignerWise = sumPrintSoldDesignerWise + sold;
                        printCost = (drPrintSold[0]["TotalPrintCost"] == DBNull.Value) ? 0.00 : Convert.ToDouble(drPrintSold[0]["TotalPrintCost"]);
                        printCost = Math.Round(printCost, 2);
                    }
                    else
                    {
                        drPrintRows["Print Sold" + j] = 0;
                        sold = 0;
                        printCost = 0.00;
                    }

                    string strQtyOrRev = "clientid=" + dsPrintPerformance.Tables[4].Rows[i]["clientid"] + "and departmentid=" + dsPrintPerformance.Tables[4].Rows[i]["departmentID"] + "and UserID=" + dsPrintPerformance.Tables[3].Rows[j]["UserID"];
                    DataRow[] drQtyOrRev = dsPrintPerformance.Tables[2].Select(strQtyOrRev);

                    if (drQtyOrRev.Length > 0)
                    {
                        qtyBooked = (drQtyOrRev[0]["QtyBooked"] == DBNull.Value) ? 0 : Convert.ToInt32(drQtyOrRev[0]["QtyBooked"]);
                        drPrintRows["Qty Booked" + j] = qtyBooked;

                        revBooked = (drQtyOrRev[0]["RevenueBooked"] == DBNull.Value) ? 0 : Convert.ToUInt32(drQtyOrRev[0]["RevenueBooked"]);
                        revBooked = Math.Round(revBooked, 2);
                        drPrintRows["Revenue Booked" + j] =  revBooked;
                       
                        sumQuantityBookedDesignerWise += qtyBooked;
                        sumRevenueBookedDesignerWise += revBooked;
                    }
                    else
                    {

                        drPrintRows["Qty Booked" + j] = 0;
                        drPrintRows["Revenue Booked" + j] = 0;
                        qtyBooked = 0;
                        revBooked = 0;
                    }

                    string strQtybookedClientWise = "clientid=" + dsPrintPerformance.Tables[4].Rows[i]["clientid"] + "and UserID=" + dsPrintPerformance.Tables[3].Rows[j]["UserID"];
                    DataRow[] drQtybookedClientWise = dsPrintPerformance.Tables[6].Select(strQtybookedClientWise);

                    // it is used to get Sum of all quantity booked for each client 
                    if (drQtybookedClientWise.Length > 0)
                    {
                        totalQtyBookedDepartmentwise = (drQtybookedClientWise[0]["QtyBooked"] == DBNull.Value) ? 0 : Convert.ToInt32(drQtybookedClientWise[0]["QtyBooked"]);

                    }
                    else
                    {
                        totalQtyBookedDepartmentwise = 0;

                    }

                    if (bought > 0)
                    {
                        hitRate = ((double)sold / (double)bought) * 100;
                        sumHitRateDesignerWise += hitRate;
                    }

                    drPrintRows["HitRate" + j] = hitRate;

                    if (totalQtyBookedDepartmentwise > 0)
                    {
                        printPerGarmet = Math.Round((double)printCost / (double)totalQtyBookedDepartmentwise, 2);
                       
                    }

                    drPrintRows["Print Per Garmet" + j] = printPerGarmet;

                }



                // asign total sum of designer rowwise
                drPrintRows["Print Bought"] = sumPrintBoughtDesignerWise;
                drPrintRows["Print Sold"] = sumPrintSoldDesignerWise;
                drPrintRows["Qty Booked"] = sumQuantityBookedDesignerWise;
                drPrintRows["Revenue Booked"] = sumRevenueBookedDesignerWise;

                if (sumPrintBoughtDesignerWise > 0)
                {
                    drPrintRows["HitRate"] = Math.Round(((double)sumPrintSoldDesignerWise /  (double)sumPrintBoughtDesignerWise) * 100);
                }
                else
                {
                    drPrintRows["HitRate"] = 0;
                }

                // it is used to get ToTal PrintCost booked for each client designerwise
                string strPrintSoldDesignerWise = "clientid=" + dsPrintPerformance.Tables[4].Rows[i]["clientid"];
                DataRow[] drPrintSoldDesignerWise = dsPrintPerformance.Tables[7].Select(strPrintSoldDesignerWise);

                if (drPrintSoldDesignerWise.Length > 0)
                {
                    PrintperGarmetDesignerWise = (drPrintSoldDesignerWise[0]["TotalPrintCost"] == DBNull.Value) ? 0.00 : Convert.ToDouble(drPrintSoldDesignerWise[0]["TotalPrintCost"]);

                }
                else
                {
                   PrintperGarmetDesignerWise = 0.00;
                }

                // it is used to get Sum of all quantity booked for each client designerwise 
                string strQtybookedClientWiseForDesigner = "clientid=" + dsPrintPerformance.Tables[4].Rows[i]["clientid"];
                DataRow[] drQtybookedClientWiseForDesigner = dsPrintPerformance.Tables[8].Select(strQtybookedClientWiseForDesigner);

                if (drQtybookedClientWiseForDesigner.Length > 0)
                {
                    QuantityBookedDesignerWise = (drQtybookedClientWiseForDesigner[0]["QtyBooked"] == DBNull.Value) ? 0 : Convert.ToInt32(drQtybookedClientWiseForDesigner[0]["QtyBooked"]);

                }
                else
                {
                    QuantityBookedDesignerWise = 0;

                }


                if (QuantityBookedDesignerWise > 0)
                {
                    drPrintRows["Print Per Garmet"] = PrintperGarmetDesignerWise / QuantityBookedDesignerWise;
                }
                else
                {
                    drPrintRows["Print Per Garmet"] = 0;
                }
                

                // add row to datatable
                dtPrintPerformance.Rows.Add(drPrintRows);
            }


           


            // to bind grid
            IsExtraheaderCreated = false;
            GridView1.DataSource = dtPrintPerformance;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {

                e.Row.Cells[0].CssClass = "vertical_header";
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text.Contains("Print Bought"))
                    {
                        e.Row.Cells[i].Text = "Print Bought";
                    }
                    else if (e.Row.Cells[i].Text.Contains("Print Sold"))
                    {
                        e.Row.Cells[i].Text = "Print Sold";
                    }
                    else if (e.Row.Cells[i].Text.Contains("Qty Booked"))
                    {
                        e.Row.Cells[i].Text = "Qty Booked";
                    }
                    else if (e.Row.Cells[i].Text.Contains("Revenue Booked"))
                    {
                        e.Row.Cells[i].Text = "Revenue Booked";
                    }
                    else if (e.Row.Cells[i].Text.Contains("Print Per Garmet"))
                    {
                        e.Row.Cells[i].Text = "Print Per Garmet";
                    }

                    else if (e.Row.Cells[i].Text.Contains("HitRate"))
                    {
                        e.Row.Cells[i].Text = "HitRate";
                    }
                }

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DataRowView dataRowView = e.Row.DataItem as DataRowView;

                if (e.Row.RowIndex == 0)
                {
                    e.Row.Cells[0].ColumnSpan = 2;
                    e.Row.Cells[1].Visible = false;
                    e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                    e.Row.Cells[0].CssClass = "quantity_style";

                    for (int i = 2; i < e.Row.Cells.Count; i = i + 6)
                    {
                        e.Row.Cells[i].Text = (Convert.ToInt32(e.Row.Cells[i].Text) == 0) ? string.Empty : Convert.ToInt32(e.Row.Cells[i].Text).ToString("N0");
                        e.Row.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                        e.Row.Cells[i].CssClass = "quantity_style";
                        e.Row.Cells[i + 1].Text = (Convert.ToInt32(e.Row.Cells[i + 1].Text) == 0) ? string.Empty : Convert.ToInt32(e.Row.Cells[i + 1].Text).ToString("N0");
                        e.Row.Cells[i + 1].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                        e.Row.Cells[i + 1].CssClass = "quantity_style";
                        e.Row.Cells[i + 2].Text = (Convert.ToInt32(e.Row.Cells[i + 2].Text) == 0) ? string.Empty : Convert.ToInt32(e.Row.Cells[i + 2].Text).ToString("N0");
                        e.Row.Cells[i + 2].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                        e.Row.Cells[i + 2].CssClass = "quantity_style";
                        e.Row.Cells[i + 3].Text = (Convert.ToDouble(e.Row.Cells[i + 3].Text) == 0) ? string.Empty : ("&pound;" + Convert.ToDouble(e.Row.Cells[i + 3].Text).ToString("N0"));
                        e.Row.Cells[i + 3].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                        e.Row.Cells[i + 3].CssClass = "quantity_style";
                        e.Row.Cells[i + 4].Text = (Convert.ToDouble(e.Row.Cells[i + 4].Text) == 0.00) ? string.Empty : ("&pound;" + Convert.ToDouble(e.Row.Cells[i + 4].Text).ToString("N2"));
                        e.Row.Cells[i + 4].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                        e.Row.Cells[i + 4].CssClass = "quantity_style";
                        e.Row.Cells[i + 5].Text = (Convert.ToDouble(e.Row.Cells[i + 5].Text) == 0.00) ? string.Empty : (Convert.ToDouble(e.Row.Cells[i + 5].Text).ToString("N0") + " %");
                        e.Row.Cells[i + 5].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                        e.Row.Cells[i + 5].CssClass = "quantity_style";
                       
                    }
                }

                else
                {

                    if (clientName.ToLower() == dataRowView["Client"].ToString().ToLower())
                    {
                        GridView1.Rows[rowIndex].Cells[0].RowSpan += 1;
                        GridView1.Rows[rowIndex].Cells[0].CssClass = "vertical_text bold_text";
                        e.Row.Cells[0].Visible = false;

                        for (int i = 2; i < e.Row.Cells.Count; i = i + 6)
                        {
                            e.Row.Cells[i].Text = (Convert.ToInt32(e.Row.Cells[i].Text) == 0) ? string.Empty : Convert.ToInt32(e.Row.Cells[i].Text).ToString("N0");
                            e.Row.Cells[i + 1].Text = (Convert.ToInt32(e.Row.Cells[i + 1].Text) == 0) ? string.Empty : Convert.ToInt32(e.Row.Cells[i + 1].Text).ToString("N0");
                            e.Row.Cells[i + 2].Text = (Convert.ToInt32(e.Row.Cells[i + 2].Text) == 0) ? string.Empty : Convert.ToInt32(e.Row.Cells[i + 2].Text).ToString("N0");
                            e.Row.Cells[i + 3].Text = (Convert.ToInt32(e.Row.Cells[i + 3].Text) == 0) ? string.Empty : ("&pound;" + Convert.ToInt32(e.Row.Cells[i + 3].Text).ToString("N0"));
                            e.Row.Cells[i + 4].Text = (Convert.ToDouble(e.Row.Cells[i + 4].Text) == 0.00) ? string.Empty : ("&pound;" + Convert.ToDouble(e.Row.Cells[i + 4].Text).ToString("N2"));
                            e.Row.Cells[i + 5].Text = (Convert.ToDouble(e.Row.Cells[i + 5].Text) == 0.00) ? string.Empty : (Convert.ToDouble(e.Row.Cells[i + 5].Text).ToString("N0") + " %");

                            GridView1.Rows[rowIndex].Cells[i].RowSpan += 1;
                            e.Row.Cells[i].Visible = false;

                            GridView1.Rows[rowIndex].Cells[i + 1].RowSpan += 1;
                            e.Row.Cells[i + 1].Visible = false;

                            GridView1.Rows[rowIndex].Cells[i + 4].RowSpan += 1;
                            e.Row.Cells[i + 4].Visible = false;

                            GridView1.Rows[rowIndex].Cells[i + 5].RowSpan += 1;
                            e.Row.Cells[i + 5].Visible = false;
                        }

                    }
                    else
                    {
                        clientName = (string)dataRowView["Client"];
                        rowIndex = e.Row.RowIndex;

                        e.Row.Cells[0].RowSpan = 1;
                        e.Row.Cells[0].CssClass = "vertical_text bold_text";

                        for (int i = 2; i < e.Row.Cells.Count; i = i + 6)
                        {
                            e.Row.Cells[i].Text = (Convert.ToInt32(e.Row.Cells[i].Text) == 0) ? string.Empty : Convert.ToInt32(e.Row.Cells[i].Text).ToString("N0");
                            e.Row.Cells[i + 1].Text = (Convert.ToInt32(e.Row.Cells[i + 1].Text) == 0) ? string.Empty : Convert.ToInt32(e.Row.Cells[i + 1].Text).ToString("N0");
                            e.Row.Cells[i + 2].Text = (Convert.ToInt32(e.Row.Cells[i + 2].Text) == 0) ? string.Empty : Convert.ToInt32(e.Row.Cells[i + 2].Text).ToString("N0");
                            e.Row.Cells[i + 3].Text = (Convert.ToInt32(e.Row.Cells[i + 3].Text) == 0) ? string.Empty : ("&pound;" + Convert.ToInt32(e.Row.Cells[i + 3].Text).ToString("N0"));
                            e.Row.Cells[i + 4].Text = (Convert.ToDouble(e.Row.Cells[i + 4].Text) == 0.00) ? string.Empty : ("&pound;" + Convert.ToDouble(e.Row.Cells[i + 4].Text).ToString("N2"));
                            e.Row.Cells[i + 5].Text = (Convert.ToDouble(e.Row.Cells[i + 5].Text) == 0.00) ? string.Empty : (Convert.ToDouble(e.Row.Cells[i + 5].Text).ToString("N0") + " %");

                            e.Row.Cells[i].RowSpan = 1;
                            e.Row.Cells[i + 1].RowSpan = 1;
                            e.Row.Cells[i + 4].RowSpan = 1;
                            e.Row.Cells[i + 5].RowSpan = 1;
                        }

                    }

                    e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                    e.Row.Cells[2].CssClass = "quantity_style";
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                    e.Row.Cells[3].CssClass = "quantity_style";
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                    e.Row.Cells[4].CssClass = "quantity_style";
                    e.Row.Cells[5].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                    e.Row.Cells[5].CssClass = "quantity_style";
                    e.Row.Cells[6].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                    e.Row.Cells[6].CssClass = "quantity_style";
                    e.Row.Cells[7].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                    e.Row.Cells[7].CssClass = "quantity_style";
                   
                }
            }


        }

        protected void GridView1_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            int count = 0;

            if (IsExtraheaderCreated == false)
            {
                if (dsPrintPerformance != null)
                {
                    if (dsPrintPerformance.Tables.Count > 0)
                    {
                        if (dsPrintPerformance.Tables[3].Rows.Count > 0)
                        {
                            count = dsPrintPerformance.Tables[3].Rows.Count;
                        }


                        GridView HeaderGrid = (GridView)sender;

                        GridViewRow HeaderGridRow =
                        new GridViewRow(0, 0, DataControlRowType.Header,
                        DataControlRowState.Insert);

                        TableCell HeaderCell = new TableCell();
                        HeaderCell.Text = "Designer Name";
                        HeaderCell.CssClass = "extra_header";
                        HeaderCell.ColumnSpan = 2;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();                       
                        HeaderCell.Text = "Total";
                        HeaderCell.CssClass = "extra_header ";
                        HeaderCell.ColumnSpan = 6;
                        HeaderGridRow.Cells.Add(HeaderCell);


                        for (int i = 0; i < count; i++)
                        {

                            HeaderCell = new TableCell();
                            string name = dsPrintPerformance.Tables[3].Rows[i]["DesignerName"].ToString();
                            HeaderCell.Text = name;
                            HeaderCell.CssClass = "extra_header ";
                            HeaderCell.ColumnSpan = 6;
                            HeaderGridRow.Cells.Add(HeaderCell);


                        }
                        GridView1.Controls[0].Controls.AddAt
                                   (0, HeaderGridRow);


                    }
                }
                IsExtraheaderCreated = true;
            }

        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
           
             rowIndex = -1;
             countClients = 0; //its counts the number of clients excluding the clients which have no department
             countDepartments = 0; // its counts total number of department
             countDesigners = 0; // its count the total numver of designers
             countTotalRows = 0; // counts the total roes in the grid
             countTotalColumn = 2;
             IsExtraheaderCreated = true;
             clientName = string.Empty;

            BindControls();

        }


    }
}