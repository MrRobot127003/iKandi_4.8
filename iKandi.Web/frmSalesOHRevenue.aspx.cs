using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using iKandi.BLL.Production;


namespace iKandi.Web
{
    public partial class frmSalesOHRevenue : System.Web.UI.Page
    {
        ProductionController objProductionController = new ProductionController();
        string AddCurrencySign = "<span style='color:#b0b0b0;'>₹ </span>";
        string addCorore = "<span style='color:#b0b0b0;'> Cr </span>";
        string addThousand = "<span style='color:#b0b0b0;'> k </span>";
        string addPer = "<span style='color:#b0b0b0;'>% </span>";

        protected void Page_Load(object sender, EventArgs e)
        {
            BindSalesOHRevenue();
        }


        private void BindSalesOHRevenue()
        {
            DataTable dt = objProductionController.GetSalesOHRevenue();
           // grdSalesOHRevenue.DataSource = dt;
            //grdSalesOHRevenue.DataBind();

            DataTable dt1 = objProductionController.GetMaterialRequired_Actual_Report();
            grdSales.DataSource = dt1;
            grdSales.DataBind();

            grdCMT.DataSource = dt;
            grdCMT.DataBind();
        }

        //protected void grdSalesOHRevenue_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {

        //        GridView HeaderGrid = (GridView)sender;
        //        GridViewRow HeaderGridRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        //        GridViewRow HeaderGridRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        //        TableCell HeaderCell = new TableCell();
        //        HeaderCell.Text = "Ex Month";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.Style.Add("width", "50px");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
        //        HeaderCell.RowSpan = 2;
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "FOB Ship";
        //        HeaderCell.RowSpan = 2;
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Material Costed";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "CMT Costed";
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderGridRow1.Cells.Add(HeaderCell);



        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Overhead Costed";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
        //        HeaderCell.ColumnSpan = 2;
        //        HeaderGridRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = " Val.";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
        //        HeaderGridRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = " %";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.Style.Add("width", "60px");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
        //        HeaderGridRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = " Val.";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
        //        HeaderGridRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = " %";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.Style.Add("width", "60px");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
        //        HeaderGridRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = " Val.";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
        //        HeaderGridRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = " %";
        //        HeaderCell.Style.Add("text-align", "center");
        //        HeaderCell.Style.Add("width", "60px");
        //        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
        //        HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
        //        HeaderGridRow2.Cells.Add(HeaderCell);



        //        //grdSalesOHRevenue.Controls[0].Controls.AddAt(0, HeaderGridRow2);
        //        //grdSalesOHRevenue.Controls[0].Controls.AddAt(0, HeaderGridRow1);

        //    }
        //}


        double ExFactRevCurrent_total = 0, MatRevCurrent_total = 0, CMTCostRevCurrent_total = 0, OverHeadRevCurrent_total = 0;
        //double MatPerFob_total = 0, CMTPerFob_total = 0, OverHeadPerFob_total = 0;
        //double MatPerFob_total = 0, CMTPerFob_total = 0, OverHeadPerFob_total = 0;
        protected void grdSalesOHRevenue_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string AddCurrencySign = "<span style='color:#b0b0b0;'>₹ </span>";
                //string addCorore = "<span style='color:#b0b0b0;'> Cr </span>";
                //string addPer = "<span style='color:#b0b0b0;'>% </span>";
                Label lblMonth = (Label)e.Row.FindControl("lblMonth");
                Label lblExFactRevCurrent = (Label)e.Row.FindControl("lblExFactRevCurrent");
                Label lblMatRevCurrent = (Label)e.Row.FindControl("lblMatRevCurrent");
                Label lblCMTCostRevCurrent = (Label)e.Row.FindControl("lblCMTCostRevCurrent");
                Label lblOverHeadRevCurrent = (Label)e.Row.FindControl("lblOverHeadRevCurrent");
                Label lblMatPerFob = (Label)e.Row.FindControl("lblMatPerFob");
                Label lblCMTPerFob = (Label)e.Row.FindControl("lblCMTPerFob");
                Label lblOverHeadPerFob = (Label)e.Row.FindControl("lblOverHeadPerFob");

                ExFactRevCurrent_total += lblExFactRevCurrent.Text == "0" ? 0 : Convert.ToDouble(lblExFactRevCurrent.Text);
                MatRevCurrent_total += lblMatRevCurrent.Text == "0" ? 0 : Convert.ToDouble(lblMatRevCurrent.Text);
                CMTCostRevCurrent_total += lblCMTCostRevCurrent.Text == "0" ? 0 : Convert.ToDouble(lblCMTCostRevCurrent.Text);
                OverHeadRevCurrent_total += lblOverHeadRevCurrent.Text == "0" ? 0 : Convert.ToDouble(lblOverHeadRevCurrent.Text);
                //MatPerFob_total += lblMatPerFob.Text == "0" ? 0 : Convert.ToDouble(lblMatPerFob.Text);
                //CMTPerFob_total += lblCMTPerFob.Text == "0" ? 0 : Convert.ToDouble(lblCMTPerFob.Text);
                //OverHeadPerFob_total += lblOverHeadPerFob.Text == "0" ? 0 : Convert.ToDouble(lblOverHeadPerFob.Text);

                if (lblExFactRevCurrent.Text == "0.0")
                {
                    lblExFactRevCurrent.Text = "";
                }
                else
                {
                    lblExFactRevCurrent.Text = AddCurrencySign + lblExFactRevCurrent.Text + addCorore;
                }

                if (lblMatRevCurrent.Text == "0.0")
                {
                    lblMatRevCurrent.Text = "";
                }
                else
                {
                    lblMatRevCurrent.Text = AddCurrencySign + lblMatRevCurrent.Text + addCorore;
                }
                if (lblCMTCostRevCurrent.Text == "0.0")
                {
                    lblCMTCostRevCurrent.Text = "";
                }
                else
                {
                    lblCMTCostRevCurrent.Text = AddCurrencySign + lblCMTCostRevCurrent.Text + addCorore;
                }

                if (lblOverHeadRevCurrent.Text == "0.0")
                {
                    lblOverHeadRevCurrent.Text = "";
                }
                else
                {
                    lblOverHeadRevCurrent.Text = AddCurrencySign + lblOverHeadRevCurrent.Text + addCorore;
                }

                if (lblMatPerFob.Text == "0")
                {
                    lblMatPerFob.Text = "";
                }
                else
                {
                    lblMatPerFob.Text = lblMatPerFob.Text + addPer;
                }

                if (lblCMTPerFob.Text == "0")
                {
                    lblCMTPerFob.Text = "";
                }
                else
                {
                    lblCMTPerFob.Text = lblCMTPerFob.Text + addPer;
                }

                if (lblOverHeadPerFob.Text == "0")
                {
                    lblOverHeadPerFob.Text = "";
                }
                else
                {
                    lblOverHeadPerFob.Text = lblOverHeadPerFob.Text + addPer;
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //string AddCurrencySign = "<span style='color:#b0b0b0;'>₹ </span>";
                //string addCorore = "<span style='color:#b0b0b0;'> Cr </span>";
                //string addThousand = "<span style='color:#b0b0b0;'> K </span>";   


                Label lblTotalExFactRevCurrent = (Label)e.Row.FindControl("lblTotalExFactRevCurrent");
                Label lblTotalMatRevCurrent = (Label)e.Row.FindControl("lblTotalMatRevCurrent");
                Label lblTotalCMTCostRevCurrent = (Label)e.Row.FindControl("lblTotalCMTCostRevCurrent");
                Label lblTotalOverHeadRevCurrent = (Label)e.Row.FindControl("lblTotalOverHeadRevCurrent");
                Label lblTotalMatPerFob = (Label)e.Row.FindControl("lblTotalMatPerFob");
                Label lblTotalCMTPerFob = (Label)e.Row.FindControl("lblTotalCMTPerFob");
                Label lblTotalOverHeadPerFob = (Label)e.Row.FindControl("lblTotalOverHeadPerFob");


                lblTotalExFactRevCurrent.Text = ExFactRevCurrent_total == 0 ? "" : AddCurrencySign + ExFactRevCurrent_total.ToString("N1") + addCorore;
                lblTotalMatRevCurrent.Text = MatRevCurrent_total == 0 ? "" : AddCurrencySign + "<span style='color:green;'>" + MatRevCurrent_total.ToString("N1") + "</span>" + addCorore;
                lblTotalCMTCostRevCurrent.Text = CMTCostRevCurrent_total == 0 ? "" : AddCurrencySign + "<span style='color:green;'>" + CMTCostRevCurrent_total.ToString("N1") + "</span>" + addCorore;
                lblTotalOverHeadRevCurrent.Text = OverHeadRevCurrent_total == 0 ? "" : AddCurrencySign + "<span style='color:green;'>" + OverHeadRevCurrent_total.ToString("N1") + "</span>" + addCorore;

                if (MatRevCurrent_total > 0 && ExFactRevCurrent_total > 0)
                {
                    lblTotalMatPerFob.Text = ((MatRevCurrent_total / ExFactRevCurrent_total) * 100) == 0 ? "" : "<span style='color:Blue;'>" + ((MatRevCurrent_total / ExFactRevCurrent_total) * 100).ToString("N0") + "</span>" + addPer;
                }
                else
                {
                    lblTotalMatPerFob.Text = "";
                }
                if (CMTCostRevCurrent_total > 0 && ExFactRevCurrent_total > 0)
                {
                    lblTotalCMTPerFob.Text = ((CMTCostRevCurrent_total / ExFactRevCurrent_total) * 100) == 0 ? "" : "<span style='color:Blue;'>" + ((CMTCostRevCurrent_total / ExFactRevCurrent_total) * 100).ToString("N0") + "</span>" + addPer;
                }
                else
                {
                    lblTotalCMTPerFob.Text = "";
                }

                if (OverHeadRevCurrent_total > 0 && ExFactRevCurrent_total > 0)
                {
                    lblTotalOverHeadPerFob.Text = ((OverHeadRevCurrent_total / ExFactRevCurrent_total) * 100) == 0 ? "" : "<span style='color:Blue;'>" + ((OverHeadRevCurrent_total / ExFactRevCurrent_total) * 100).ToString("N0") + "</span>" + addPer;
                }
                else
                {
                    lblTotalOverHeadPerFob.Text = "";
                }
            }

        }

        protected void grdSales_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow HeaderGridRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                //GridViewRow HeaderGridRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell1 = new TableCell();
                HeaderCell1.Text = "Inhouse Fabric Value %";
                HeaderCell1.Style.Add("text-align", "center");
                HeaderCell1.Style.Add("width", "100%");
                HeaderCell1.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell1.ColumnSpan = 4;
                HeaderGridRow.Cells.Add(HeaderCell1);


                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Ex Month";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "50px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.RowSpan = 2;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Costed Val.";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.ColumnSpan = 2;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Inhouse Val.";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                //HeaderCell.ColumnSpan = 2;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Inhouse Val. %";
                //HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow1.Cells.Add(HeaderCell);

                //grdSalesOHRevenue.Controls[0].Controls.AddAt(0, HeaderGridRow2);
                grdSales.Controls[0].Controls.AddAt(0, HeaderGridRow);
                grdSales.Controls[0].Controls.AddAt(1, HeaderGridRow1);



            }
        }


        double MatCost_total = 0, MatInhouse_total = 0;
        //double Inhouse_total = 0;
        protected void grdSales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //string AddCurrencySign = "<span style='color:#b0b0b0;'>₹ </span>";
                //string addCorore = "<span style='color:#b0b0b0;'> Cr </span>";                
                //string addPer = "<span style='color:#b0b0b0;'>% </span>";

                Label lblMonth = (Label)e.Row.FindControl("lblMonth");
                Label lblMatCost = (Label)e.Row.FindControl("lblMatCost");
                Label lblMatInhouse = (Label)e.Row.FindControl("lblMatInhouse");
                Label lblInhouse = (Label)e.Row.FindControl("lblInhouse");

                MatCost_total += lblMatCost.Text == "0" ? 0 : Convert.ToDouble(lblMatCost.Text);
                MatInhouse_total += lblMatInhouse.Text == "0" ? 0 : Convert.ToDouble(lblMatInhouse.Text);
                //Inhouse_total += lblInhouse.Text == "0" ? 0 : Convert.ToDouble(lblInhouse.Text);                 


                if (lblMatCost.Text == "0.0")
                {
                    lblMatCost.Text = "";
                }
                else
                {
                    lblMatCost.Text = AddCurrencySign + lblMatCost.Text + addCorore;
                }

                if (lblMatInhouse.Text == "0.0")
                {
                    lblMatInhouse.Text = "";
                }
                else
                {
                    lblMatInhouse.Text = AddCurrencySign + "<span style='color:green;'>" + lblMatInhouse.Text + "</span>" + addCorore;
                }

                if (lblInhouse.Text == "0")
                {
                    lblInhouse.Text = "";
                }
                else
                {
                    lblInhouse.Text = "<span style='color:Blue;'>" + lblInhouse.Text + "</span>" + addPer;
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblTotalMatCost = (Label)e.Row.FindControl("lblTotalMatCost");
                Label lblTotalMatInhouse = (Label)e.Row.FindControl("lblTotalMatInhouse");
                Label lblTotalInhouse = (Label)e.Row.FindControl("lblTotalInhouse");

                lblTotalMatCost.Text = MatCost_total == 0 ? "" : AddCurrencySign + MatCost_total.ToString("N1") + addCorore;
                lblTotalMatInhouse.Text = MatInhouse_total == 0 ? "" : AddCurrencySign + "<span style='color:green;'>" + MatInhouse_total.ToString("N1") + "</span>" + addCorore;
                if (MatInhouse_total > 0 && MatCost_total > 0)
                {
                    lblTotalInhouse.Text = ((MatInhouse_total / MatCost_total) * 100) == 0 ? "" : "<span style='color:Blue;'>" + ((MatInhouse_total / MatCost_total) * 100).ToString("N0") + "</span>" + addPer;
                }
                else
                {
                    lblTotalInhouse.Text = "";
                }
            }
        }

        protected void grdCMT_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow HeaderGridRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow HeaderGridRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell1 = new TableCell();
                HeaderCell1.Text = "Live Cost vs Actual<br>(Figures Based on Actual Stitching)";
                HeaderCell1.Style.Add("text-align", "center");
                HeaderCell1.Style.Add("width", "100%");
                HeaderCell1.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell1.ColumnSpan = 14;
                HeaderGridRow.Cells.Add(HeaderCell1);

                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Ex Month";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "10%");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.RowSpan = 2;
                HeaderGridRow1.Cells.Add(HeaderCell);

                TableCell HeaderCell2 = new TableCell();
                HeaderCell2.Text = "Stitch";
                HeaderCell2.Style.Add("text-align", "center");
                HeaderCell2.Style.Add("width", "22%");
                HeaderCell2.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell2.ColumnSpan = 3;
                HeaderGridRow1.Cells.Add(HeaderCell2);

                TableCell HeaderCell3 = new TableCell();
                HeaderCell3.Text = "Material";
                HeaderCell3.Style.Add("text-align", "center");
                HeaderCell3.Style.Add("width", "22%");
                HeaderCell3.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell3.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell3.ColumnSpan = 3;
                HeaderGridRow1.Cells.Add(HeaderCell3);

                TableCell HeaderCell4 = new TableCell();
                HeaderCell4.Text = "CMT";
                HeaderCell4.Style.Add("text-align", "center");
                HeaderCell4.Style.Add("width", "22%");
                HeaderCell4.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell4.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell4.ColumnSpan = 3;
                HeaderGridRow1.Cells.Add(HeaderCell4);

                TableCell HeaderCell5 = new TableCell();
                HeaderCell5.Text = "Per pcs CMT";
                HeaderCell5.Style.Add("text-align", "center");
                HeaderCell5.Style.Add("width", "22%");
                HeaderCell5.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell5.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell5.ColumnSpan = 3;
                HeaderGridRow1.Cells.Add(HeaderCell5);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Quantity";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "50px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.RowSpan = 2;
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "FOB";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "50px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.RowSpan = 2;
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Per pcs FOB";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.ColumnSpan = 2;
                HeaderGridRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Costed";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                //HeaderCell.ColumnSpan = 2;
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Profit";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.ColumnSpan = 2;
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Costed";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.ColumnSpan = 2;
                HeaderGridRow2.Cells.Add(HeaderCell);

                //
                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.ColumnSpan = 2;
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Profit";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.ColumnSpan = 2;
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Costed ";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Profit";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow2.Cells.Add(HeaderCell);
                //
                HeaderCell = new TableCell();
                HeaderCell.Text = "Monthly Wt.<br>SAM";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.RowSpan = 2;
                HeaderGridRow1.Cells.Add(HeaderCell);
                //grdSalesOHRevenue.Controls[0].Controls.AddAt(0, HeaderGridRow2);
                grdCMT.Controls[0].Controls.AddAt(0, HeaderGridRow);
                grdCMT.Controls[0].Controls.AddAt(1, HeaderGridRow1);
                grdCMT.Controls[0].Controls.AddAt(2, HeaderGridRow2);



            }
        }

        double CostedCMT_total = 0, ActualCMT_total = 0, Difference_total = 0, Stitch_total = 0, Stitch_totalActual = 0, CostedPerPcs_Total = 0, ActualPerPcs_Total = 0
                , TotalOrderQty = 0, TotalSAMMultipliedByOrderQty = 0, TotalStitchedFOB = 0
            //13-04-2023 Start
                , MaterialCostedCMTTotal = 0
                , MaterialActualCMTTotal = 0
                , MaterialDifferanceCMTTotal = 0
                , NewCostedCMTTotal = 0
                , NewActualCMTTotal = 0
                , NewProfitCMTTotal = 0
                , PPCostedCMTTotal = 0
                , PPActualCMTTotal = 0
                , PPProfitCMTTotal = 0;
        //13-04-2023 End

        protected void grdCMT_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            double CostedCMT = 0, ActualCMT = 0, DifferenceCMT = 0, StitchQty = 0, CostedPerPcs = 0, ActualPerPcs = 0, CompleteStitchedQty = 0;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblMonth = (Label)e.Row.FindControl("lblMonth");
                Label lblCostedCMT = (Label)e.Row.FindControl("lblCostedCMT");
                Label lblMaterialActualCMT = (Label)e.Row.FindControl("lblMaterialActualCMT");
                Label lblMaterialDifferenceCMT = (Label)e.Row.FindControl("lblMaterialDifferenceCMT");
                Label lblStichedQty = (Label)e.Row.FindControl("lblStichedQty");
                Label lblStichedfob = (Label)e.Row.FindControl("lblStichedfob");
                Label lblMonthlyWeightedSAM = (Label)e.Row.FindControl("lblMonthlyWeightedSAM");
                HiddenField hdnStitchedQty = (HiddenField)e.Row.FindControl("hdnStitchedQty");
                HiddenField hdnStichedfob = (HiddenField)e.Row.FindControl("hdnStichedfob");

                //13-04-2023 Start lblMaterialActualCMT
                HiddenField hdnMaterialActualCMT = (HiddenField)e.Row.FindControl("hdnMaterialActualCMT");
                HiddenField hdnMaterialCostedCMT = (HiddenField)e.Row.FindControl("hdnMaterialCostedCMT");
                HiddenField hdnNewCostedCMT = (HiddenField)e.Row.FindControl("hdnNewCostedCMT");
                HiddenField hdnPPCostedCMT = (HiddenField)e.Row.FindControl("hdnPPCostedCMT");
                HiddenField hdnPPActualCMT = (HiddenField)e.Row.FindControl("hdnPPActualCMT");
                HiddenField hdnPPProfitCMT = (HiddenField)e.Row.FindControl("hdnPPProfitCMT");
                HiddenField hdnMaterialDifferenceCMT = (HiddenField)e.Row.FindControl("hdnMaterialDifferenceCMT");
                HiddenField hdnNewProfitCMT = (HiddenField)e.Row.FindControl("hdnNewProfitCMT");

                Label lblPPCostedCMT = (Label)e.Row.FindControl("lblPPCostedCMT");
                Label lblPPActualCMT = (Label)e.Row.FindControl("lblPPActualCMT");
                Label lblPPProfitCMT = (Label)e.Row.FindControl("lblPPProfitCMT");

                Label lblMaterialCostedCMT = (Label)e.Row.FindControl("lblMaterialCostedCMT");
                Label lblNewCostedCMT = (Label)e.Row.FindControl("lblNewCostedCMT");
                Label lblNewActualCMT = (Label)e.Row.FindControl("lblNewActualCMT");
                Label lblNewProfitCMT = (Label)e.Row.FindControl("lblNewProfitCMT");
                //13-04-2023 end                 
                HiddenField hdnTotalOrderQty = (HiddenField)e.Row.FindControl("hdnTotalOrderQty");
                HiddenField hdnSAMMultipliedByOrderQty = (HiddenField)e.Row.FindControl("hdnSAMMultipliedByOrderQty");
                //13-04-2023 start               
                if (hdnMaterialCostedCMT.Value != "" || hdnMaterialCostedCMT.Value != "0.00000")
                {
                    if (!string.IsNullOrEmpty(hdnMaterialCostedCMT.Value))
                        MaterialCostedCMTTotal = MaterialCostedCMTTotal + Convert.ToDouble(hdnMaterialCostedCMT.Value);
                }
                if (hdnNewCostedCMT.Value != "" || hdnNewCostedCMT.Value != "0.00000")
                {
                    if (!string.IsNullOrEmpty(hdnNewCostedCMT.Value))
                        NewCostedCMTTotal = NewCostedCMTTotal + Convert.ToDouble(hdnNewCostedCMT.Value);
                }
                if (hdnPPCostedCMT.Value != "" || hdnPPCostedCMT.Value != "0.00000")
                {
                    if (!string.IsNullOrEmpty(hdnPPCostedCMT.Value))
                        PPCostedCMTTotal = PPCostedCMTTotal + Convert.ToDouble(hdnPPCostedCMT.Value);
                }
                if (hdnMaterialActualCMT.Value != "" || hdnMaterialActualCMT.Value != "0.00000")
                {
                    if (!string.IsNullOrEmpty(hdnPPActualCMT.Value))
                        MaterialActualCMTTotal = MaterialActualCMTTotal + Convert.ToDouble(hdnMaterialActualCMT.Value);
                }
                if (hdnPPProfitCMT.Value != "" || hdnPPProfitCMT.Value != "0.00000")
                {
                    if (!string.IsNullOrEmpty(hdnPPProfitCMT.Value))
                        PPProfitCMTTotal = PPProfitCMTTotal + Convert.ToDouble(hdnPPProfitCMT.Value);
                }
                if (hdnMaterialDifferenceCMT.Value != "" || hdnMaterialDifferenceCMT.Value != "0.00000")
                {
                    if (!string.IsNullOrEmpty(hdnMaterialDifferenceCMT.Value))
                        MaterialDifferanceCMTTotal = MaterialDifferanceCMTTotal + Convert.ToDouble(hdnMaterialDifferenceCMT.Value);
                }
                if (hdnNewProfitCMT.Value != "" || hdnNewProfitCMT.Value != "0.00000")
                {
                    if (!string.IsNullOrEmpty(hdnNewProfitCMT.Value))
                        NewProfitCMTTotal = NewProfitCMTTotal + Convert.ToDouble(hdnNewProfitCMT.Value);
                }
                //13-04-2023 end 

                if (hdnStichedfob.Value != "" || hdnStichedfob.Value != "0.00000")
                {
                    TotalStitchedFOB = TotalStitchedFOB + Convert.ToDouble(hdnStichedfob.Value);
                }

                if (lblStichedfob.Text == "0.0" || lblStichedfob.Text == "" || lblStichedfob.Text == "0")
                {
                    lblStichedfob.Text = "";
                }
                else
                {
                    lblStichedfob.Text = AddCurrencySign + lblStichedfob.Text + addCorore;
                }

                if (hdnTotalOrderQty.Value != "")
                {

                    TotalOrderQty = TotalOrderQty + Convert.ToDouble(hdnTotalOrderQty.Value);

                }
                if (hdnSAMMultipliedByOrderQty.Value != "")
                {

                    TotalSAMMultipliedByOrderQty = TotalSAMMultipliedByOrderQty + Convert.ToDouble(hdnSAMMultipliedByOrderQty.Value);

                }
                //13-04-2023 start lblMaterialDifferenceCMT.Text
                //if (!string.IsNullOrEmpty(lblMaterialCostedCMT.Text))
                //{
                //    if (Convert.ToDouble(lblMaterialCostedCMT.Text) > 0)
                //    {
                //        double MaterialDefferenceCMT = Math.Round( Convert.ToDouble(lblMaterialCostedCMT.Text) - (Convert.ToDouble(lblMaterialActualCMT.Text)/ 10000000),1);
                //        lblMaterialDifferenceCMT.Text = AddCurrencySign + MaterialDefferenceCMT.ToString()+addCorore;
                //    }                   
                //}
                //else
                //{
                //    lblMaterialDifferenceCMT.Text = "";
                //}

                if (!string.IsNullOrEmpty(lblPPCostedCMT.Text) || lblPPProfitCMT.Text == "0")
                //{
                //    if (lblPPActualCMT.Text == "")
                //      //  lblPPActualCMT.Text = "0";
                //    //if (Convert.ToDouble(lblPPCostedCMT.Text) > 0)
                //    //{
                //    //    lblPPProfitCMT.Text = AddCurrencySign + (Convert.ToDouble(lblPPCostedCMT.Text) - Convert.ToDouble(lblPPActualCMT.Text)).ToString("N0") + addCorore;
                //    //}
                //}
                //else
                {
                    lblPPProfitCMT.Text = "";
                }

                if (!string.IsNullOrEmpty(lblNewCostedCMT.Text))
                {
                    if (lblNewActualCMT.Text == "")
                        lblNewActualCMT.Text = "0";
                    if ((Convert.ToDouble(lblNewCostedCMT.Text) > 0) && (!string.IsNullOrEmpty(lblNewCostedCMT.Text)))
                    {
                        lblNewProfitCMT.Text = AddCurrencySign + (Convert.ToDouble(lblNewCostedCMT.Text) - Convert.ToDouble(lblNewActualCMT.Text)).ToString("N0") + addCorore;
                    }
                }
                else
                {
                    lblNewProfitCMT.Text = "";
                }

                if (lblMaterialCostedCMT.Text == "0.0" || lblMaterialCostedCMT.Text == "")
                {
                    lblMaterialCostedCMT.Text = "";
                }
                else
                {
                    lblMaterialCostedCMT.Text = AddCurrencySign + Convert.ToDouble(lblMaterialCostedCMT.Text).ToString("N0") + addCorore;
                }

                if (lblMaterialActualCMT.Text == "0.0" || lblMaterialActualCMT.Text == "" || lblMaterialActualCMT.Text == "0")
                {
                    lblMaterialActualCMT.Text = "";
                }
                else
                {
                    lblMaterialActualCMT.Text = AddCurrencySign + lblMaterialActualCMT.Text.ToString() + addCorore;
                }
                //else
                //{
                //    double MaterialActiualCMTValue = Math.Round((Convert.ToDouble(lblMaterialActualCMT.Text) / 10000000), 1);
                //    if (MaterialActiualCMTValue>0)
                //    {
                //        lblMaterialActualCMT.Text = AddCurrencySign + MaterialActiualCMTValue.ToString() + addCorore;
                //    }
                //    else
                //    {
                //        lblMaterialActualCMT.Text = "";
                //    }

                //}

                if (lblNewCostedCMT.Text == "0.0" || lblNewCostedCMT.Text == "")
                {
                    lblNewCostedCMT.Text = "";
                }
                else
                {
                    lblNewCostedCMT.Text = AddCurrencySign + Convert.ToDouble(lblNewCostedCMT.Text).ToString("N0") + addCorore;
                }
                if (lblMonthlyWeightedSAM.Text == "0.0" || lblMonthlyWeightedSAM.Text == "" || lblMonthlyWeightedSAM.Text == "0")
                {
                    lblMonthlyWeightedSAM.Text = "";
                }
                //13-04-2023 end

                if (lblPPCostedCMT.Text != "")
                {
                    CostedPerPcs = lblPPCostedCMT.Text == "0" ? 0 : Convert.ToDouble(lblPPCostedCMT.Text);
                }

                if (lblPPActualCMT.Text != "")
                {
                    ActualPerPcs = lblPPActualCMT.Text == "0" ? 0 : Convert.ToDouble(lblPPActualCMT.Text);
                }

                if (lblPPCostedCMT.Text == "0" || lblPPCostedCMT.Text == "")
                {
                    lblPPCostedCMT.Text = "";
                }
                else
                {
                    lblPPCostedCMT.Text = AddCurrencySign + Convert.ToDouble(lblPPCostedCMT.Text).ToString("N0") ;
                }

                //if (lblPPCostedCMT.Text == "0" || lblPPCostedCMT.Text == "")
                //{
                //    lblPPCostedCMT.Text = "";
                //}
                //else
                //{
                //   // lblPPCostedCMT.Text = AddCurrencySign + Convert.ToDouble(lblPPCostedCMT.Text).ToString("N0");
                //    lblPPCostedCMT.Text = AddCurrencySign + lblPPCostedCMT.Text;
                //}                

                if (lblCostedCMT.Text != "")
                {
                    CostedCMT = lblCostedCMT.Text == "0" ? 0 : Convert.ToDouble(lblCostedCMT.Text);
                }
                //if (lblMaterialActualCMT.Text != "")
                //{
                //    ActualCMT = lblMaterialActualCMT.Text == "0" ? 0 : Convert.ToDouble(lblMaterialActualCMT.Text);                   
                //    lblMaterialActualCMT.Text = AddCurrencySign + Convert.ToDouble(lblMaterialActualCMT.Text).ToString("N0");

                //}


                //double DifferenceCMT = lblCostedCMT.Text == "0" ? 0 : (Convert.ToDouble(lblCostedCMT.Text) - Convert.ToDouble(lblActualCMT.Text)) / 100000;
                //if (CostedCMT >= ActualCMT)
                //{
                if (ActualCMT > 0)
                    DifferenceCMT = (CostedCMT - ActualCMT) / 10000000;

                //}
                //else
                //{
                //    DifferenceCMT = (ActualCMT - CostedCMT) / 100000;
                //}

                //if (lblCostedCMT.Text == "0" || lblCostedCMT.Text == "0.0")


                StitchQty = (lblStichedQty.Text == "0" || lblStichedQty.Text == "") ? 0 : Convert.ToDouble(lblStichedQty.Text);
                CompleteStitchedQty = (hdnStitchedQty.Value == "0" || hdnStitchedQty.Value == "") ? 0 : Convert.ToDouble(hdnStitchedQty.Value);

                CostedCMT_total += CostedCMT;
                ActualCMT_total += ActualCMT;
                if (ActualCMT > 0)
                    Difference_total += (CostedCMT - ActualCMT);

                if (CostedCMT > 0)
                {
                    //Stitch_total += StitchQty;
                    Stitch_total += CompleteStitchedQty;
                }
                if (ActualCMT > 0)
                {
                    //Stitch_totalActual += StitchQty;
                    Stitch_totalActual += CompleteStitchedQty;
                }

                //CostedPerPcs_Total += CostedPerPcs;
                //ActualPerPcs_Total += ActualPerPcs;

                //if (StitchQty > 0)
                //{
                //    //lblStichedQty.Text = AddCurrencySign + (StitchQty / 1000).ToString("N0") + addThousand;
                //    StitchQty = StitchQty / 1000;
                //}
                //else
                //{
                //    lblStichedQty.Text = "";
                //}

                lblStichedQty.Text = StitchQty != 0 ? StitchQty.ToString("N0") + addThousand : "";

                if (CostedCMT == 0 || CostedCMT == 0.0)
                {
                    lblCostedCMT.Text = "";
                }
                else
                {
                    if (Math.Round((CostedCMT), 1).ToString() == "0")
                    {
                        lblCostedCMT.Text = "";
                    }
                    else
                    {
                        //lblCostedCMT.Text = AddCurrencySign + lblCostedCMT.Text=="0"?0:Math.Round(Convert.ToDouble(lblCostedCMT.Text),2).ToString() + addCorore;
                        //lblCostedCMT.Text = AddCurrencySign + Math.Round((CostedCMT / 10000000), 1).ToString() + addCorore;
                        lblCostedCMT.Text = AddCurrencySign + Math.Round((CostedCMT), 1).ToString();
                    }
                }

                //if (lblMaterialActualCMT.Text == "0" || lblMaterialActualCMT.Text == "0.0")
                //    if (ActualCMT == 0 || ActualCMT == 0.0)
                //    {
                //        lblMaterialActualCMT.Text = "";
                //    }
                //    else
                //    {
                //        if (Math.Round((ActualCMT / 10000000), 1).ToString() == "0")
                //        {
                //            lblMaterialActualCMT.Text = "";
                //        }
                //        else
                //        {
                //            //lblActualCMT.Text = AddCurrencySign + "<span style='color:green;'>" + Math.Round(Convert.ToDouble(lblActualCMT.Text), 2).ToString() + "</span>" + addCorore;
                //            lblMaterialActualCMT.Text = AddCurrencySign + Math.Round((ActualCMT / 10000000), 1).ToString() + addCorore;
                //        }
                //    }

                //if (DifferenceCMT == 0)
                //{
                //    lblMaterialDifferenceCMT.Text = "";
                //}
                //else
                //{
                //    if (DifferenceCMT > 0)
                //    {
                //        if (Math.Round(DifferenceCMT, 1).ToString() == "0")
                //        {
                //            lblMaterialDifferenceCMT.Text = "";
                //        }
                //        else
                //        {
                //            lblMaterialDifferenceCMT.Text = AddCurrencySign + "<span style='color:green;'>" + Math.Round(DifferenceCMT, 1).ToString() + "</span>" + addCorore;
                //        }
                //    }
                //    else if (DifferenceCMT < 0)
                //    {
                //        if (Math.Round(DifferenceCMT, 1).ToString() == "0")
                //        {
                //            lblMaterialDifferenceCMT.Text = "";
                //        }
                //        else
                //        {
                //            lblMaterialDifferenceCMT.Text = AddCurrencySign + "<span style='color:red;'>" + Math.Round(DifferenceCMT, 1).ToString() + "</span>" + addCorore;
                //        }
                //    }

                //}
                if (lblMaterialDifferenceCMT.Text == "0.0" || lblMaterialDifferenceCMT.Text == "0")
                {
                    lblMaterialDifferenceCMT.Text = "";
                }
                else
                {
                    lblMaterialDifferenceCMT.Text = AddCurrencySign + lblMaterialDifferenceCMT.Text.ToString() + addCorore;
                }
                if (lblPPActualCMT.Text == "0.0" || lblPPActualCMT.Text == "0")
                {
                    lblPPActualCMT.Text = "";
                }
                if (lblNewActualCMT.Text == "0.0" || lblNewActualCMT.Text == "0")
                {
                    lblNewActualCMT.Text = "";
                }
                if (lblNewProfitCMT.Text == "0.0" || lblNewProfitCMT.Text == "0")
                {
                    lblNewProfitCMT.Text = "";
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {

                //string AddCurrencySign = "<span style='color:#b0b0b0;'>₹ </span>";
                //string addCorore = "<span style='color:#b0b0b0;'> Cr </span>";
                //string addThousand = "<span style='color:#b0b0b0;'> K </span>";
                Label lblTotalStichedQty = (Label)e.Row.FindControl("lblTotalStichedQty");
                Label lblTotalCostedCMT = (Label)e.Row.FindControl("lblTotalCostedCMT");
                Label lblTotalActualCMT = (Label)e.Row.FindControl("lblTotalActualCMT");
                Label lblTotalDifferenceCMT = (Label)e.Row.FindControl("lblTotalDifferenceCMT");

                Label lblTotalCostedPerPcs = (Label)e.Row.FindControl("lblTotalCostedPerPcs");
                Label lblTotalActualPerPcs = (Label)e.Row.FindControl("lblTotalActualPerPcs");
                Label lblTotalWeightedSAM = (Label)e.Row.FindControl("lblTotalWeightedSAM");
                Label lblTotalStichedfob = (Label)e.Row.FindControl("lblTotalStichedfob");

                Label lblMaterialCostedCMTTotal = (Label)e.Row.FindControl("lblMaterialCostedCMTTotal");
                Label lblMaterialActualCMTTotal = (Label)e.Row.FindControl("lblMaterialActualCMTTotal");
                Label lblMaterialDifferenceCMTTotal = (Label)e.Row.FindControl("lblMaterialDifferenceCMTTotal");

                Label lblNewCostedCMTTotal = (Label)e.Row.FindControl("lblNewCostedCMTTotal");
                Label lblNewActualCMTTotal = (Label)e.Row.FindControl("lblNewActualCMTTotal");
                Label lblNewProfitCMTTotal = (Label)e.Row.FindControl("lblNewProfitCMTTotal");
               
                Label lblPPCostedCMTTotal = (Label)e.Row.FindControl("lblPPCostedCMTTotal");
                Label lblPPActualCMTTotal = (Label)e.Row.FindControl("lblPPActualCMTTotal");
                Label lblPPProfitCMTTotal = (Label)e.Row.FindControl("lblPPProfitCMTTotal");



                double CostPerPcTotal_Diff = 0, ActualPerPcTotal_Diff = 0;

                //Total block Start               

                if (TotalStitchedFOB > 0)
                {
                    lblTotalStichedfob.Text = AddCurrencySign + Math.Round(TotalStitchedFOB / 10000000, 1).ToString() + addCorore;
                }
                else
                {
                    lblTotalStichedfob.Text = "";
                }

                if (TotalSAMMultipliedByOrderQty > 0 && TotalOrderQty > 0)
                {
                    lblTotalWeightedSAM.Text = Math.Round((TotalSAMMultipliedByOrderQty / TotalOrderQty), 0).ToString();
                }
                else
                {
                    lblTotalWeightedSAM.Text = "";
                }

                if (CostedCMT_total > 0 && Stitch_total > 0)
                {
                    //CostPerPcTotal_Diff = Math.Round((CostedCMT_total / (Stitch_total * 1000)), 0);
                    CostPerPcTotal_Diff = Math.Round((CostedCMT_total / (Stitch_total)), 0);
                }

                if (ActualCMT_total > 0 && Stitch_totalActual > 0)
                {
                    //ActualPerPcTotal_Diff = Math.Round((ActualCMT_total / (Stitch_totalActual * 1000)), 0);
                    ActualPerPcTotal_Diff = Math.Round((ActualCMT_total / (Stitch_totalActual)), 0);
                }

                if (CostPerPcTotal_Diff > 0)
                {
                    lblPPCostedCMTTotal.Text = CostPerPcTotal_Diff != 0 ? AddCurrencySign + Math.Round(CostPerPcTotal_Diff, 0).ToString() + addCorore : "";
                }
                else
                {
                    lblPPCostedCMTTotal.Text = "";
                }
                // 14-04-2023 start 
                //Material Costed CMT Total
                if (MaterialCostedCMTTotal > 0)
                {
                    lblMaterialCostedCMTTotal.Text = MaterialCostedCMTTotal != 0 ? AddCurrencySign + Math.Round(MaterialCostedCMTTotal, 0).ToString() + addCorore : "";
                }
                else
                {
                    lblMaterialCostedCMTTotal.Text = "";
                }
                //Material Actual CMT Total
                if (MaterialActualCMTTotal > 0)
                {
                    lblMaterialActualCMTTotal.Text = MaterialActualCMTTotal != 0 ? AddCurrencySign + Math.Round(MaterialActualCMTTotal, 1).ToString() + addCorore : "";
                }
                else
                {
                    lblMaterialActualCMTTotal.Text = "";
                }
                //Material Differnce CMT Total
                if (MaterialDifferanceCMTTotal > 0)
                {
                    lblMaterialDifferenceCMTTotal.Text = MaterialDifferanceCMTTotal != 0 ? AddCurrencySign + Math.Round(MaterialDifferanceCMTTotal, 0).ToString() + addCorore : "";
                }
                else
                {
                    lblMaterialDifferenceCMTTotal.Text = "";
                }
                //New Costed CMT Total
                if (NewCostedCMTTotal > 0)
                {
                    lblNewCostedCMTTotal.Text = NewCostedCMTTotal != 0 ? AddCurrencySign + Math.Round(NewCostedCMTTotal, 0).ToString() + addCorore : "";
                }
                else
                {
                    lblNewCostedCMTTotal.Text = "";
                }
                //New Actual CMT Total
                if (NewActualCMTTotal > 0)
                {
                    lblNewActualCMTTotal.Text = NewActualCMTTotal != 0 ? AddCurrencySign + Math.Round(NewActualCMTTotal, 0).ToString() + addCorore : "";
                }
                else
                {
                    lblNewActualCMTTotal.Text = "";
                }
                //New Profit CMT Total
                if (NewProfitCMTTotal > 0)
                {
                    lblNewProfitCMTTotal.Text = NewProfitCMTTotal != 0 ? AddCurrencySign + Math.Round(NewProfitCMTTotal, 0).ToString() + addCorore : "";
                }
                else
                {
                    lblNewProfitCMTTotal.Text = "";
                }
                //PP Costed CMT Total
                if (PPCostedCMTTotal > 0)
                {
                    lblPPCostedCMTTotal.Text = PPCostedCMTTotal != 0 ? AddCurrencySign + Math.Round(PPCostedCMTTotal, 0).ToString() + addCorore : "";
                }
                else
                {
                    lblPPCostedCMTTotal.Text = "";
                }
                //PP Actual CMT Total
                if (PPActualCMTTotal > 0)
                {
                    lblPPActualCMTTotal.Text = PPActualCMTTotal != 0 ? AddCurrencySign + Math.Round(PPActualCMTTotal, 0).ToString()  : "";
                }
                else
                {
                    lblPPActualCMTTotal.Text = "";
                }
                //PP Profit CMT Total
                if (PPProfitCMTTotal > 0)
                {
                    lblPPProfitCMTTotal.Text = PPProfitCMTTotal != 0 ? AddCurrencySign + Math.Round(PPProfitCMTTotal, 0).ToString() + addCorore : "";
                }
                else
                {
                    lblPPProfitCMTTotal.Text = "";
                }

                if (lblPPCostedCMTTotal.Text == "0")
                {
                    lblPPCostedCMTTotal.Text = "";
                }

                if (lblPPActualCMTTotal.Text == "0")
                {
                    lblPPActualCMTTotal.Text = "";
                }

                lblTotalStichedQty.Text = Stitch_total != 0 ? (Stitch_total / 1000).ToString("N0") + addThousand : "";
                if (CostedCMT_total > 0)
                {
                    lblTotalCostedCMT.Text = CostedCMT_total != 0 ? AddCurrencySign + Math.Round((CostedCMT_total), 1).ToString() :""; //+ addCorore
                }
                else
                {
                    lblTotalCostedCMT.Text = "";
                }

                if (lblTotalCostedCMT.Text == "<span style='color:#b0b0b0;'>₹ </span>0<span style='color:#b0b0b0;'> Cr </span>")
                {
                    lblTotalCostedCMT.Text = "";
                }

                if (ActualCMT_total > 0)
                {
                    lblNewActualCMTTotal.Text = ActualCMT_total != 0 ? AddCurrencySign + Math.Round((ActualCMT_total / 10000000), 1).ToString() + addCorore : "";
                }
                else
                {
                    lblNewActualCMTTotal.Text = "";
                }

                if (lblNewActualCMTTotal.Text == "<span style='color:#b0b0b0;'>₹ </span>0<span style='color:#b0b0b0;'> Cr </span>")
                {
                    lblNewActualCMTTotal.Text = "";
                }
                //if (Difference_total > 0)
                //{
                //    lblTotalDifferenceCMT.Text = Difference_total != 0 ? AddCurrencySign + "<span style='color:green;'>" + (Difference_total / 10000000).ToString("N0") + "</span>" + addCorore : "";
                //}
                //else
                //{
                //    lblTotalDifferenceCMT.Text = "";
                //}

                //if (Difference_total == 0)
                //{
                //    lblNewProfitCMTTotal.Text = "";
                //}
                //else
                //{
                //    if (Difference_total > 0)
                //    {
                //        if (Math.Round(Difference_total, 1).ToString() == "0")
                //        {
                //            lblNewProfitCMTTotal.Text = "";
                //        }
                //        else
                //        {
                //            lblNewProfitCMTTotal.Text = AddCurrencySign + "<span style='color:green;'>" + Math.Round((Difference_total / 10000000), 1).ToString() + "</span>" + addCorore;
                //        }
                //        if (lblNewProfitCMTTotal.Text == "<span style='color:#b0b0b0;'>₹ </span><span style='color:green;'>0</span><span style='color:#b0b0b0;'> Cr </span>")
                //        {
                //            lblNewProfitCMTTotal.Text = "";
                //        }
                //    }
                //    else if (Difference_total < 0)
                //    {
                //        if (Math.Round(Difference_total, 1).ToString() == "0")
                //        {
                //            lblNewProfitCMTTotal.Text = "";
                //        }
                //        else
                //        {
                //            lblNewProfitCMTTotal.Text = AddCurrencySign + "<span style='color:red;'>" + Math.Round((Difference_total / 10000000), 1).ToString() + "</span>" + addCorore;
                //        }
                //        if (lblNewProfitCMTTotal.Text == "<span style='color:#b0b0b0;'>₹ </span><span style='color:red;'>0</span><span style='color:#b0b0b0;'> Cr </span>")
                //        {
                //            lblNewProfitCMTTotal.Text = "";
                //        }
                //    }

                //}
            }
        }
    }
}