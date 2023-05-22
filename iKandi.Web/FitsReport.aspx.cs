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
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iKandi.BLL;
using System.Text;
using iKandi.BLL.Production;




namespace iKandi.Web
{
    public partial class FitsReport : System.Web.UI.Page
    {
        AdminController objadmin = new AdminController();
        String FitsFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["fits.docs.folder"];
        ReportController controller = new ReportController();
        ProductionController objProductionController = new ProductionController();
        int BIPLPerformance = 0;
        int days = 0;
        double SumAvgPer = 0;
        double WipForAvgPer = 0;
        DataTable dtInPro = new DataTable();
        //String FitsFolderPath = "~/" + System.Configuration.ConfigurationManager.AppSettings["fits.docs.foldertest"];

        public int indexs
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            if (Request.QueryString["Type"].ToString() != "" || Request.QueryString["Type"] != null)
            {
                string Type = Request.QueryString["Type"].ToString();
                if (Type == "FitsSampling")
                {
                    CreateExcel(ds, Type);
                }
                else if (Type == "Restexcels")
                {
                    CreateExcel(ds, Type);
                }
                else if (Type == "BindReport")
                {
                    //ExcelObjectCreate();
                    days = objadmin.GetWeek_Count(out days);
                    //CreateExcel(ds);
                    BindReport();
                    score();
                }
            }
            else
            {
                // do nothing
                Response.Write("Nothing");
            }




        }






        public void BindReport()
        {
            //try
            //{

            DataSet dsFits = new DataSet();
            DataSet ds = new DataSet();
            DataTable dtFits = new DataTable();
            DataTable dt = new DataTable();

            // ds = objadmin.GetFitsReport("SAMPLING");
            // dt = ds.Tables[0];
            // grdsampling.DataSource = dt;
            // grdsampling.DataBind();

            dsFits = objadmin.GetFitsReport("FITS");
            dtFits = dsFits.Tables[0];

            dtInPro = dsFits.Tables[0];
            grdinproduction.DataSource = dtInPro;
            grdinproduction.DataBind();
            //HideColumnWithoutStitch();

            GridViewRow lastrowProd = grdinproduction.Rows[(grdinproduction.Rows.Count) - 1];
            lastrowProd.BackColor = System.Drawing.Color.FromName("#FFF0A5");
            lastrowProd.Font.Bold = true;

            for (int i = 20; i < lastrowProd.Cells.Count; i++)
            {
                lastrowProd.Cells[i].Font.Bold = true;
                lastrowProd.Cells[i].ForeColor = System.Drawing.Color.Black;
            }

            //grdper.DataSource = dtInPro;
            //grdper.DataBind();
            //HideColumnPerformance();
            //GridViewRow lastrowgrdper = grdper.Rows[(grdper.Rows.Count) - 1];
            //lastrowgrdper.Font.Bold = true;
            //lastrowgrdper.BackColor = System.Drawing.Color.FromName("#FFF0A5");


            //for (int i = 20; i < lastrowgrdper.Cells.Count; i++)
            //{
            //  lastrowgrdper.Cells[i].Font.Bold = true;
            //  lastrowgrdper.Cells[i].ForeColor = System.Drawing.Color.Black;
            //}

            //ds = objadmin.GetFitsReport("TOPSUMMARY");
            //dt = ds.Tables[0];
            //grdtopsummary.DataSource = dt;
            //grdtopsummary.DataBind();

            //ds = objadmin.GetFitsReport("DAYS");
            //dt = ds.Tables[0];
            //indexs = ds.Tables[0].Rows.Count - 2;//2 for hide wip & avg row
            //grdmasterper.DataSource = dt;
            //grdmasterper.DataBind();

            //added by bhart veer 13/12/18-------------------

            //grdperfreport.DataSource = dtInPro;
            //grdperfreport.DataBind();

            //GridViewRow lastrowre = grdperfreport.Rows[(grdperfreport.Rows.Count) - 1];
            //lastrowre.BackColor = System.Drawing.Color.FromName("#FFF0A5");

            //for (int i = 0; i < lastrowre.Cells.Count; i++)
            //{
            //    lastrowre.Cells[i].Font.Bold = true;
            //    //lastrow.Cells[0].ForeColor = System.Drawing.Color.Gray;
            //    lastrowre.Cells[i].ForeColor = System.Drawing.Color.Black;
            //    lastrowre.Cells[i].BorderColor = System.Drawing.Color.Gray;
            //}


            //GridViewRow lastrow = grdmasterper.Rows[(grdmasterper.Rows.Count) - 1];
            //lastrow.BackColor = System.Drawing.Color.FromName("#FFF0A5");


            //for (int i = 0; i < lastrow.Cells.Count; i++)
            //{
            //    lastrow.Cells[i].Font.Bold = true;
            //    //lastrow.Cells[0].ForeColor = System.Drawing.Color.Gray;
            //    lastrow.Cells[i].ForeColor = System.Drawing.Color.Black;
            //    lastrow.Cells[i].BorderColor = System.Drawing.Color.Gray;
            //}
            //GridViewRow lastrow1 = grdmasterper.Rows[(grdmasterper.Rows.Count) - 2];
            //lastrow1.BackColor = System.Drawing.Color.FromName("#FFF0A5");

            //for (int i = 0; i < lastrow1.Cells.Count; i++)
            //{
            //    lastrow1.Cells[i].Font.Bold = true;
            //    //lastrow1.Cells[0].ForeColor = System.Drawing.Color.Gray;
            //    lastrow1.Cells[i].ForeColor = System.Drawing.Color.Black;
            //    lastrow1.Cells[i].BorderColor = System.Drawing.Color.Gray;
            //}

            //GridViewRow TopReport = grdtopsummary.Rows[(grdtopsummary.Rows.Count) - 1];
            //TopReport.BackColor = System.Drawing.Color.FromName("#FFF0A5");

            //for (int i = 0; i < TopReport.Cells.Count; i++)
            //{
            //    TopReport.Cells[i].Font.Bold = true;
            //    TopReport.Cells[i].Font.Size = 10;
            //    TopReport.Cells[0].ForeColor = System.Drawing.Color.Black;
            //    TopReport.Cells[0].CssClass = "boldblack";
            //    TopReport.Cells[i].CssClass = "boldblacknew";

            //}

            //ds = objadmin.GetFitsReport("HANDOVER");
            // CreateExcel(ds);/* abhishek*/

            //}
            //catch (Exception ex)
            //{
            //    string error = ex.ToString();
            //}
        }
        //added by abhishek 20/11/2018
        public string GetColSpanUnit(string IsFirstQuarter, string IsSecondQuarter, string IsThirdQuarter, string IsFourthQuarter)
        {
            string Colspans = "";
            if (IsFirstQuarter == "1" && IsSecondQuarter == "1" && IsThirdQuarter == "1" && IsFourthQuarter == "1")
            {
                Colspans = "4";
            }
            else if (IsFirstQuarter == "1" && IsSecondQuarter == "1" && IsThirdQuarter == "1")
            {
                Colspans = "3";
            }
            else if (IsFirstQuarter == "1" && IsSecondQuarter == "1")
            {
                Colspans = "2";
            }
            else if (IsFirstQuarter == "1")
            {
                Colspans = "1";
            }
            return Colspans;

        }


        public string GetFinancialMonth()
        {
            string FinMonth = "";
            DateTime CurrentDate;
            CurrentDate = DateTime.Now;
            int month = CurrentDate.Month;
            if (month == 1 || month == 2 || month == 3)
                FinMonth = "Q1+Q2+Q3";
            else if (month == 4 || month == 5 || month == 6)
                FinMonth = "Q1+Q2+Q3+Q4";
            else if (month == 7 || month == 8 || month == 9)
                FinMonth = "Q1";
            else if (month == 10 || month == 11 || month == 12)
                FinMonth = "Q1 & Q2 ";
            return FinMonth;
        }
        public string Get_Current_FinancialMonth(string Quarter)
        {
            string FinMonth = "";
            DateTime CurrentDate;
            CurrentDate = DateTime.Now;
            int month = CurrentDate.Month;
            string PreViousYear = Convert.ToString(DateTime.Now.AddYears(-1).Year);
            string CurrentYear = Convert.ToString(DateTime.Now.AddYears(0).Year);
            string NextYear = Convert.ToString(DateTime.Now.AddYears(1).Year);
            if (Quarter == "Q1")
            {
                if (month == 1 || month == 2 || month == 3)
                    // FinMonth = "Q1(" + PreViousYear + "-" + CurrentYear + ")";
                    FinMonth = "Q1";
                else
                    FinMonth = "Q1";
                //FinMonth = "Q1(" + CurrentYear + "-" + NextYear + ")";
            }
            if (Quarter == "Q2")
                if (month == 7 || month == 8 || month == 9 || month == 10 || month == 11 || month == 12)
                    FinMonth = "Q2(" + CurrentYear + "-" + NextYear + ")";
                else
                    FinMonth = "Q2(" + PreViousYear + "-" + CurrentYear + ")";
            if (Quarter == "Q3")
                if (month == 10 || month == 11 || month == 12)
                    FinMonth = "Q3(" + CurrentYear + "-" + NextYear + ")";
                else
                    FinMonth = "Q3(" + PreViousYear + "-" + CurrentYear + ")";
            if (Quarter == "Q4")
                if (month == 1 || month == 2 || month == 3)
                    FinMonth = "Q4(" + PreViousYear + "-" + CurrentYear + ")";
                else
                    FinMonth = "Q4(" + PreViousYear + "-" + CurrentYear + ")";

            return FinMonth;
        }
        public string Get_Current_FinanceYear()
        {
            string FinYear = "";
            FinYear = DateTime.Now.Year.ToString() + " " + "-" + " " + DateTime.Now.AddYears(1).ToString("yy");
            return FinYear;
            //DateTime.Now.AddMonths(-1).ToString("MMM") + " " + DateTime.Now.AddMonths(-1).ToString("yy");


        }
        protected void HideColumnWithoutStitch()
        {
            int index = 0;
            string IsFirstQuarter = dtInPro.Rows[0]["IsFirstQuarter"].ToString();
            string IsSecondQuarter = dtInPro.Rows[0]["IsSecondQuarter"].ToString();
            string IsThirdQuarter = dtInPro.Rows[0]["IsThirdQuarter"].ToString();
            string IsFourthQuarter = dtInPro.Rows[0]["IsFourthQuarter"].ToString();
            int Colspans = Convert.ToInt32(GetColSpanUnit(IsFirstQuarter, IsSecondQuarter, IsThirdQuarter, IsFourthQuarter));
            if (Colspans == 1)
            {

                grdinproduction.Columns[21].Visible = false;
                grdinproduction.Columns[22].Visible = false;
                grdinproduction.Columns[23].Visible = false;

                grdinproduction.Columns[25].Visible = false;
                grdinproduction.Columns[26].Visible = false;
                grdinproduction.Columns[27].Visible = false;

                grdinproduction.Columns[29].Visible = false;
                grdinproduction.Columns[30].Visible = false;
                grdinproduction.Columns[31].Visible = false;

            }
            else if (Colspans == 2)
            {

                grdinproduction.Columns[22].Visible = false;
                grdinproduction.Columns[23].Visible = false;
                grdinproduction.Columns[26].Visible = false;
                grdinproduction.Columns[27].Visible = false;
                grdinproduction.Columns[30].Visible = false;
                grdinproduction.Columns[31].Visible = false;


            }
            else if (Colspans == 3)
            {

                grdinproduction.Columns[23].Visible = false;
                grdinproduction.Columns[27].Visible = false;
                grdinproduction.Columns[31].Visible = false;

            }
        }
        protected void HideColumnPerformance()
        {
            int index = 0;
            string IsFirstQuarter = dtInPro.Rows[0]["IsFirstQuarter"].ToString();
            string IsSecondQuarter = dtInPro.Rows[0]["IsSecondQuarter"].ToString();
            string IsThirdQuarter = dtInPro.Rows[0]["IsThirdQuarter"].ToString();
            string IsFourthQuarter = dtInPro.Rows[0]["IsFourthQuarter"].ToString();
            int Colspans = Convert.ToInt32(GetColSpanUnit(IsFirstQuarter, IsSecondQuarter, IsThirdQuarter, IsFourthQuarter));
            if (Colspans == 1)
            {

                grdper.Columns[21].Visible = false;
                grdper.Columns[22].Visible = false;
                grdper.Columns[23].Visible = false;

                grdper.Columns[25].Visible = false;
                grdper.Columns[26].Visible = false;
                grdper.Columns[27].Visible = false;

                grdper.Columns[29].Visible = false;
                grdper.Columns[30].Visible = false;
                grdper.Columns[31].Visible = false;

            }
            else if (Colspans == 2)
            {
                grdper.Columns[3].Visible = false;
                grdper.Columns[4].Visible = false;
                grdper.Columns[7].Visible = false;
                grdper.Columns[8].Visible = false;
                grdper.Columns[10].Visible = false;
                grdper.Columns[11].Visible = false;
                grdper.Columns[12].Visible = false;

            }
            else if (Colspans == 3)
            {

                grdper.Columns[23].Visible = false;
                grdper.Columns[27].Visible = false;
                grdper.Columns[31].Visible = false;

            }
        }
        protected void grdper_RowdataBound(object sender, GridViewRowEventArgs e)
        {
            string IsFirstQuarter = dtInPro.Rows[0]["IsFirstQuarter"].ToString();
            string IsSecondQuarter = dtInPro.Rows[0]["IsSecondQuarter"].ToString();
            string IsThirdQuarter = dtInPro.Rows[0]["IsThirdQuarter"].ToString();
            string IsFourthQuarter = dtInPro.Rows[0]["IsFourthQuarter"].ToString();
            int Colspans = Convert.ToInt32(GetColSpanUnit(IsFirstQuarter, IsSecondQuarter, IsThirdQuarter, IsFourthQuarter));
            string ShowFinMonth = GetFinancialMonth();

            if (e.Row.RowType == DataControlRowType.Header)
            {


                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.Attributes.Add("class", "header1");
                headerRow2.Attributes.Add("class", "header2");
                headerRow3.Attributes.Add("class", "header3");
                TableCell HeaderCell = new TableCell();
                //Adding the Row at the 0th position (first row) in the Grid
                HeaderCell = new TableCell();
                HeaderCell.Text = "AM";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 3;
                HeaderCell.Width = 100;
                headerRow1.Cells.Add(HeaderCell);




                HeaderCell = new TableCell();
                HeaderCell.Text = "Performance";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 3 * Colspans;
                headerRow1.Cells.Add(HeaderCell);

                //Adding the Row at the 1st position (Second row) in the Grid




                HeaderCell = new TableCell();
                HeaderCell.Text = "Sealing";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = Colspans;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "BIH";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = Colspans;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "StyleCode Share";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = Colspans;
                headerRow2.Cells.Add(HeaderCell);


                //Adding the Row at the 3rd position (second row) in the Grid


                switch (Colspans)
                {
                    case 3:
                        HeaderCell = new TableCell();
                        HeaderCell.Text = ShowFinMonth;
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);


                        HeaderCell = new TableCell();
                        HeaderCell.Text = "" + "(Avg.Dly Day)";
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);


                        HeaderCell = new TableCell();
                        HeaderCell.Text = "Q3";
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);


                        HeaderCell = new TableCell();
                        HeaderCell.Text = ShowFinMonth;
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);


                        HeaderCell = new TableCell();
                        HeaderCell.Text = "" + "(Avg.Dly Day)";
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);


                        HeaderCell = new TableCell();
                        HeaderCell.Text = "80";
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 50;
                        headerRow3.Cells.Add(HeaderCell);


                        HeaderCell = new TableCell();
                        HeaderCell.Text = Get_Current_FinanceYear();
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);


                        HeaderCell = new TableCell();
                        HeaderCell.Text = "";
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);


                        HeaderCell = new TableCell();
                        HeaderCell.Text = "Q3";
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);

                        break;
                    case 2:
                        HeaderCell = new TableCell();
                        HeaderCell.Text = ShowFinMonth;
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);


                        HeaderCell = new TableCell();
                        HeaderCell.Text = "" + "(Avg.Dly Days)";
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);


                        HeaderCell = new TableCell();
                        HeaderCell.Text = ShowFinMonth;
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);


                        HeaderCell = new TableCell();
                        HeaderCell.Text = "" + "(Avg.Dly Days)";
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);




                        HeaderCell = new TableCell();
                        HeaderCell.Text = Get_Current_FinanceYear();
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);

                        break;
                    case 1:
                        HeaderCell = new TableCell();
                        HeaderCell.Text = ShowFinMonth;
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = "Previous Quarter";
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);


                        HeaderCell = new TableCell();
                        HeaderCell.Text = Get_Current_FinanceYear();
                        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                        HeaderCell.Width = 80;
                        headerRow3.Cells.Add(HeaderCell);

                        break;
                    default:
                        {
                            HeaderCell = new TableCell();
                            HeaderCell.Text = ShowFinMonth;
                            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                            HeaderCell.Width = 80;
                            headerRow3.Cells.Add(HeaderCell);


                            HeaderCell = new TableCell();
                            HeaderCell.Text = "" + "(Avg.Dly Days)";
                            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                            HeaderCell.Width = 80;
                            headerRow3.Cells.Add(HeaderCell);


                            HeaderCell = new TableCell();
                            HeaderCell.Text = "Q3";
                            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                            HeaderCell.Width = 80;
                            headerRow3.Cells.Add(HeaderCell);


                            HeaderCell = new TableCell();
                            HeaderCell.Text = "Q4";
                            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                            HeaderCell.Width = 80;
                            headerRow3.Cells.Add(HeaderCell);


                            HeaderCell = new TableCell();
                            HeaderCell.Text = ShowFinMonth;
                            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                            HeaderCell.Width = 80;
                            headerRow3.Cells.Add(HeaderCell);


                            HeaderCell = new TableCell();
                            HeaderCell.Text = "Current Quarter";
                            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                            HeaderCell.Width = 80;
                            headerRow3.Cells.Add(HeaderCell);


                            HeaderCell = new TableCell();
                            HeaderCell.Text = "Q3";
                            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                            HeaderCell.Width = 80;
                            headerRow3.Cells.Add(HeaderCell);

                            HeaderCell = new TableCell();
                            HeaderCell.Text = "Q4";
                            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                            HeaderCell.Width = 80;
                            headerRow3.Cells.Add(HeaderCell);

                            HeaderCell = new TableCell();
                            HeaderCell.Text = Get_Current_FinanceYear();
                            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                            HeaderCell.Width = 80;
                            headerRow3.Cells.Add(HeaderCell);

                            HeaderCell = new TableCell();
                            HeaderCell.Text = "Q3";
                            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                            HeaderCell.Width = 80;
                            headerRow3.Cells.Add(HeaderCell);


                            HeaderCell = new TableCell();
                            HeaderCell.Text = "Q4";
                            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                            HeaderCell.Width = 80;
                            headerRow3.Cells.Add(HeaderCell);
                            break;
                        }
                }



                grdper.Controls[0].Controls.AddAt(0, headerRow3);
                grdper.Controls[0].Controls.AddAt(0, headerRow2);
                grdper.Controls[0].Controls.AddAt(0, headerRow1);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {



                DataRowView drv = (DataRowView)e.Row.DataItem;

                Label lblSealing_1 = (Label)e.Row.FindControl("lblSealing_1");
                Label lblSealing_2 = (Label)e.Row.FindControl("lblSealing_2");
                Label lblSealing_3 = (Label)e.Row.FindControl("lblSealing_3");
                Label lblSealing_4 = (Label)e.Row.FindControl("lblSealing_4");

                HiddenField hdnlblSealing_1 = e.Row.FindControl("hdnlblSealing_1") as HiddenField;
                HiddenField hdnlblSealing_2 = e.Row.FindControl("hdnlblSealing_2") as HiddenField;
                HiddenField hdnlblBIH_1 = e.Row.FindControl("hdnlblBIH_1") as HiddenField;
                HiddenField hdnlblBIH_2 = e.Row.FindControl("hdnlblBIH_2") as HiddenField;

                HtmlTableCell tdFirstQuarter = (HtmlTableCell)e.Row.FindControl("tdFirstQuarter");

                Label lblBIH_1 = (Label)e.Row.FindControl("lblBIH_1");
                Label lblBIH_2 = (Label)e.Row.FindControl("lblBIH_2");
                Label lblBIH_3 = (Label)e.Row.FindControl("lblBIH_3");
                Label lblBIH_4 = (Label)e.Row.FindControl("lblBIH_4");


                Label StyleCodeShare_Q1 = (Label)e.Row.FindControl("StyleCodeShare_Q1");
                Label StyleCodeShare_Q2 = (Label)e.Row.FindControl("StyleCodeShare_Q2");
                Label StyleCodeShare_Q3 = (Label)e.Row.FindControl("StyleCodeShare_Q3");
                Label StyleCodeShare_Q4 = (Label)e.Row.FindControl("StyleCodeShare_Q4");



                switch (Colspans)
                {
                    case 1:
                        lblSealing_1.Attributes.Add("style", "color:gray !important;");
                        lblBIH_1.Attributes.Add("style", "color:gray !important;");
                        StyleCodeShare_Q1.Attributes.Add("style", "color:gray !important;");

                        if (Convert.ToInt32(hdnlblBIH_1.Value) >= 80)
                        {
                            e.Row.Cells[3].BackColor = System.Drawing.Color.Green;
                            lblBIH_1.Attributes.Add("style", "background-color:green;color:#fff;");
                        }
                        else
                            lblBIH_1.Attributes.Add("style", "background-color:red;color:#fff;");
                        //if (Convert.ToInt32(lblSealing_1.Text.Replace("%", "")) > 80)
                        //    tdFirstQuarter.Style.Add("background-color", "green");
                        //else
                        //    tdFirstQuarter.Style.Add("background-color", "red"); 

                        break;
                    case 2:

                        //if (lblSealing_1.Text != "")
                        //{
                        if (Convert.ToInt32(hdnlblSealing_1.Value) >= 80)
                        {
                            e.Row.Cells[1].Style.Add("Background", "green");
                            //lblSealing_1.Attributes.Add("style", "color:yellow !important;font-weight:normal !important;");
                            lblSealing_1.ForeColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            e.Row.Cells[1].Style.Add("Background", "red");
                            lblSealing_1.ForeColor = System.Drawing.Color.Yellow;
                        }
                        //}
                        //if (lblSealing_2.Text != "")
                        //{
                        if (Convert.ToInt32(hdnlblSealing_2.Value) >= 80)
                        {
                            e.Row.Cells[2].Style.Add("Background", "green");
                            lblSealing_2.ForeColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            e.Row.Cells[2].Style.Add("Background", "red");
                            lblSealing_2.ForeColor = System.Drawing.Color.Yellow;

                        }
                        //}

                        //if (lblBIH_1.Text != "")
                        //{
                        if (Convert.ToInt32(hdnlblBIH_1.Value) >= 80)
                        {
                            e.Row.Cells[5].Style.Add("Background", "green");
                            lblBIH_1.ForeColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            e.Row.Cells[5].Style.Add("Background", "red");
                            lblBIH_1.ForeColor = System.Drawing.Color.Yellow;
                        }
                        //}

                        //if (lblBIH_2.Text != "")
                        //{
                        if (Convert.ToInt32(hdnlblBIH_2.Value) >= 80)
                        {
                            e.Row.Cells[6].Style.Add("Background", "green");
                            lblBIH_2.ForeColor = System.Drawing.Color.Yellow;
                        }
                        else
                        {
                            e.Row.Cells[6].Style.Add("Background", "red");
                            lblBIH_2.ForeColor = System.Drawing.Color.Yellow;
                        }
                        //}                   
                        break;
                    case 3:
                        lblSealing_3.Attributes.Add("style", "color:black !important;");
                        lblBIH_3.Attributes.Add("style", "color:black !important;");
                        StyleCodeShare_Q3.Attributes.Add("style", "color:black !important;");
                        break;

                    case 4:
                        lblSealing_4.Attributes.Add("style", "color:black !important;");
                        lblBIH_4.Attributes.Add("style", "color:black !important;");
                        StyleCodeShare_Q4.Attributes.Add("style", "color:black !important;");
                        break;
                }

            }
        }

        //protected void grdperfreport_RowdataBound(object sender, GridViewRowEventArgs e)
        //{
        //    //string IsFirstQuarter = dtInPro.Rows[0]["IsFirstQuarter"].ToString();
        //    //string IsSecondQuarter = dtInPro.Rows[0]["IsSecondQuarter"].ToString();
        //    //string IsThirdQuarter = dtInPro.Rows[0]["IsThirdQuarter"].ToString();
        //    //string IsFourthQuarter = dtInPro.Rows[0]["IsFourthQuarter"].ToString();
        //    //int Colspans = Convert.ToInt32(GetColSpanUnit(IsFirstQuarter, IsSecondQuarter, IsThirdQuarter, IsFourthQuarter));

        //    //string CurrentFin = Get_Current_FinancialMonth();
        //    string FirstQuarter = Get_Current_FinancialMonth("Q1");
        //    string SecondQuarter = Get_Current_FinancialMonth("Q2");
        //    string ThirdQuarter = Get_Current_FinancialMonth("Q3");
        //    string FourthQuarter = Get_Current_FinancialMonth("Q4");
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {


        //        GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        //        GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        //        GridViewRow headerRow3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        //        headerRow1.Attributes.Add("class", "header1");
        //        headerRow2.Attributes.Add("class", "header2");
        //        headerRow3.Attributes.Add("class", "header3");
        //        TableCell HeaderCell = new TableCell();
        //        //Adding the Row at the 0th position (first row) in the Grid
        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "AM";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.RowSpan = 3;
        //        HeaderCell.Width = 120;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow1.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = FirstQuarter;
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        HeaderCell.ColumnSpan = 7;
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = SecondQuarter;
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 7;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = ThirdQuarter;
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 7;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = FourthQuarter;
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 7;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow1.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "StyleCode Share";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        HeaderCell.RowSpan = 2;
        //        headerRow1.Cells.Add(HeaderCell);

        //        //Adding the Row at the 1st position (Second row) in the Grid


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. Ex Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.RowSpan = 2;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Sealing";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 3;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "BIH";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        HeaderCell.ColumnSpan = 3;
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. Ex Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.RowSpan = 2;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Sealing";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 3;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "BIH";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        HeaderCell.ColumnSpan = 3;
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. Ex Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.RowSpan = 2;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Sealing";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 3;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "BIH";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        HeaderCell.ColumnSpan = 3;
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. Ex Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.RowSpan = 2;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Sealing";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 3;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow2.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "BIH";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        HeaderCell.ColumnSpan = 3;
        //        headerRow2.Cells.Add(HeaderCell);

        //        //Adding the Row at the 3rd position (second row) in the Grid

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "On Time %";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 100;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. ETA Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. Dly Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "On Time %";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 100;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. ETA Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. Dly Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "On Time %";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 100;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. ETA Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. Dly Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "On Time %";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 100;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. ETA Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. Dly Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "On Time %";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 100;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. ETA Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. Dly Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "On Time %";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 100;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. ETA Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. Dly Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "On Time %";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 100;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. ETA Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. Dly Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "On Time %";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 100;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. ETA Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);


        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Avg. Dly Weeks";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);

        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = Get_Current_FinanceYear();
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.Width = 80;
        //        HeaderCell.Attributes.Add("Class", "headerfontsize");
        //        headerRow3.Cells.Add(HeaderCell);

        //        //grdperfreport.Controls[0].Controls.AddAt(0, headerRow3);
        //        //grdperfreport.Controls[0].Controls.AddAt(0, headerRow2);
        //        //grdperfreport.Controls[0].Controls.AddAt(0, headerRow1);
        //    }
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        DataRowView drv = (DataRowView)e.Row.DataItem;

        //        Label lblSealing_Q1_AvgDlyweeks = (Label)e.Row.FindControl("lblSealing_Q1_AvgDlyweeks");

        //        if (lblSealing_Q1_AvgDlyweeks.Text == "")
        //        {
        //             e.Row.Cells[4].Style.Add("Background", "green");
        //             lblSealing_Q1_AvgDlyweeks.Attributes.Add("Class", "YellowClass");
        //        }
        //        else
        //        {
        //            if (Convert.ToDecimal(lblSealing_Q1_AvgDlyweeks.Text) >= 1)
        //            {
        //                e.Row.Cells[4].Style.Add("Background", "red");
        //                lblSealing_Q1_AvgDlyweeks.Attributes.Add("Class", "YellowClass");

        //            }

        //            else
        //            {
        //                e.Row.Cells[4].Style.Add("Background", "green");
        //                lblSealing_Q1_AvgDlyweeks.Attributes.Add("Class", "YellowClass ");
        //            }
        //        }

        //        Label lblbih_Q1_Avg_Dly_weeks = (Label)e.Row.FindControl("lblbih_Q1_Avg_Dly_weeks");

        //        if (lblbih_Q1_Avg_Dly_weeks.Text == "")
        //        {
        //            e.Row.Cells[7].Style.Add("Background", "green");
        //            lblbih_Q1_Avg_Dly_weeks.Attributes.Add("Class", "YellowClass");
        //        }
        //        else
        //        {
        //            if (Convert.ToDecimal(lblbih_Q1_Avg_Dly_weeks.Text) >= 1)
        //            {
        //               e.Row.Cells[7].Style.Add("Background", "red");
        //               lblbih_Q1_Avg_Dly_weeks.Attributes.Add("Class", "YellowClass");
        //            }

        //            else
        //            {
        //                e.Row.Cells[7].Style.Add("Background", "green");
        //                lblbih_Q1_Avg_Dly_weeks.Attributes.Add("Class", "YellowClass");
        //            }

        //        }
        //    }
        //}
        //END abhishek 6/12/2018
        protected void grdinproduction_RowdataBound(object sender, GridViewRowEventArgs e)
        {
            //string IsFirstQuarter = dtInPro.Rows[0]["IsFirstQuarter"].ToString();
            //string IsSecondQuarter = dtInPro.Rows[0]["IsSecondQuarter"].ToString();
            //string IsThirdQuarter = dtInPro.Rows[0]["IsThirdQuarter"].ToString();
            //string IsFourthQuarter = dtInPro.Rows[0]["IsFourthQuarter"].ToString();
            //int Colspans = Convert.ToInt32(GetColSpanUnit(IsFirstQuarter, IsSecondQuarter, IsThirdQuarter, IsFourthQuarter));
            //string ShowFinMonth = GetFinancialMonth();
            if (e.Row.RowType == DataControlRowType.Header)
            {


                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                headerRow1.Attributes.Add("class", "header1");
                headerRow2.Attributes.Add("class", "header2");
                headerRow3.Attributes.Add("class", "header3");
                TableCell HeaderCell = new TableCell();
                //Adding the Row at the 0th position (first row) in the Grid
                HeaderCell = new TableCell();
                HeaderCell.Text = "AM";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 3;
                HeaderCell.Width = 80;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "In Production Planning <span style='color:#c7c5c5;'> (For ref. Review <b style='font-size:11px'>ProductionPlanningReports</b> excel) </span>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 6;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = " Fits Performance Report <span style='color:#c7c5c5;'> (For ref. Review <b style='font-size:11px'>FITS and Sampling Reports</b> excel) </span>";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 13;
                headerRow1.Cells.Add(HeaderCell);

                //Adding the Row at the 1st position (Second row) in the Grid


                HeaderCell = new TableCell();
                HeaderCell.Text = "Style Code. (Style No )";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 6;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Handover";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 3;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pattern Ready";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 3;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Sample Sent";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 3;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Fits Comment Upload";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                //Adding the Row at the 3rd position (second row) in the Grid
                HeaderCell = new TableCell();
                HeaderCell.Text = "Order Qty";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Count";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 60;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Stc Requs.";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 60;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "STC Done";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 60;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "P S Done";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 60;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "In Prod.";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 60;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Task Pend.";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Task Delay";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Avg LT 1M (Days)";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Task Pend.";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Task Delay";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Avg LT 1M (Days)";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Task Pend.";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Task Delay";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Avg LT 1M (Days)";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Task Pend.";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Task Delay";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Avg LT 1M (Days)";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PP Sample Sent";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Width = 50;
                headerRow3.Cells.Add(HeaderCell);


                grdinproduction.Controls[0].Controls.AddAt(0, headerRow3);
                grdinproduction.Controls[0].Controls.AddAt(0, headerRow2);
                grdinproduction.Controls[0].Controls.AddAt(0, headerRow1);

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblTotalOrderQty = (Label)e.Row.FindControl("lblTotalOrderQty");
                HiddenField hdnOrderQty = (HiddenField)e.Row.FindControl("hdnOrderQty");
                Label lblStylePendingCount = (Label)e.Row.FindControl("lblStylePendingCount");
                Label lblStcRequestedStyleNo = (Label)e.Row.FindControl("lblStcRequestedStyleNo");
                Label lblSTCStyleNo = (Label)e.Row.FindControl("lblSTCStyleNo");
                Label lblPsStyleNo = (Label)e.Row.FindControl("lblPsStyleNo");
                Label lblInProductionStyleNo = (Label)e.Row.FindControl("lblInProductionStyleNo");
                if (hdnOrderQty.Value == "")
                    hdnOrderQty.Value = "0";
                if (Convert.ToInt32(hdnOrderQty.Value) > 0)
                {
                    //Added by Yadvendra on 12/12/19
                    lblTotalOrderQty.Text = (Convert.ToInt32(hdnOrderQty.Value) / 1000).ToString("N0") + "k";
                }
                if (lblStylePendingCount.Text != "")
                {
                    lblStylePendingCount.Text = "(" + lblStylePendingCount.Text + ")";
                }
                if (lblStcRequestedStyleNo.Text != "")
                {
                    lblStcRequestedStyleNo.Text = "(" + lblStcRequestedStyleNo.Text + ")";
                }
                if (lblSTCStyleNo.Text != "")
                {
                    lblSTCStyleNo.Text = "(" + lblSTCStyleNo.Text + ")";
                }
                if (lblPsStyleNo.Text != "")
                {
                    lblPsStyleNo.Text = "(" + lblPsStyleNo.Text + ")";
                }
                if (lblInProductionStyleNo.Text != "")
                {
                    lblInProductionStyleNo.Text = "(" + lblInProductionStyleNo.Text + ")";
                }
                // DataRowView drv = (DataRowView)e.Row.DataItem;

                // Label lblSealing_1 = (Label)e.Row.FindControl("lblSealing_1");
                // Label lblSealing_2 = (Label)e.Row.FindControl("lblSealing_2");
                // Label lblSealing_3 = (Label)e.Row.FindControl("lblSealing_3");
                // Label lblSealing_4 = (Label)e.Row.FindControl("lblSealing_4");

                // HiddenField hdnlblSealing_1 = e.Row.FindControl("hdnlblSealing_1") as HiddenField;
                // HiddenField hdnlblSealing_2 = e.Row.FindControl("hdnlblSealing_2") as HiddenField;
                // HiddenField hdnlblBIH_1 = e.Row.FindControl("hdnlblBIH_1") as HiddenField;
                // HiddenField hdnlblBIH_2 = e.Row.FindControl("hdnlblBIH_2") as HiddenField;

                // HtmlTableCell tdFirstQuarter = (HtmlTableCell)e.Row.FindControl("tdFirstQuarter");

                // Label lblBIH_1 = (Label)e.Row.FindControl("lblBIH_1");
                // Label lblBIH_2 = (Label)e.Row.FindControl("lblBIH_2");
                // Label lblBIH_3 = (Label)e.Row.FindControl("lblBIH_3");
                // Label lblBIH_4 = (Label)e.Row.FindControl("lblBIH_4");


                // Label StyleCodeShare_Q1 = (Label)e.Row.FindControl("StyleCodeShare_Q1");
                //Label StyleCodeShare_Q2 = (Label)e.Row.FindControl("StyleCodeShare_Q2");
                // Label StyleCodeShare_Q3 = (Label)e.Row.FindControl("StyleCodeShare_Q3");
                // Label StyleCodeShare_Q4 = (Label)e.Row.FindControl("StyleCodeShare_Q4");



                // switch (Colspans)
                // {
                //   case 1:
                //         lblSealing_1.Attributes.Add("style", "color:gray !important;font-weight:normal !important;");
                //         lblBIH_1.Attributes.Add("style", "color:gray !important;font-weight:normal");
                //         StyleCodeShare_Q1.Attributes.Add("style", "color:gray !important;font-weight:normal !important;");

                //         if (Convert.ToInt32(hdnlblBIH_1.Value) >= 80)
                //         {
                //             e.Row.Cells[26].BackColor=System.Drawing.Color.Green;
                //             lblBIH_1.Attributes.Add("style", "background-color:green;padding:10% 26% 10% 26%;color:#fff;");
                //         }
                //         else
                //             lblBIH_1.Attributes.Add("style", "background-color:red;padding:10% 26% 10% 26%;color:#fff;");
                //         //if (Convert.ToInt32(lblSealing_1.Text.Replace("%", "")) > 80)
                //         //    tdFirstQuarter.Style.Add("background-color", "green");
                //         //else
                //         //    tdFirstQuarter.Style.Add("background-color", "red"); 

                //     break;
                //   case 2:

                //     //if (lblSealing_1.Text != "")
                //     //{
                //         if (Convert.ToInt32(hdnlblSealing_1.Value) >= 80)
                //         {
                //             e.Row.Cells[20].Style.Add("Background", "green");
                //             //lblSealing_1.Attributes.Add("style", "color:yellow !important;font-weight:normal !important;");
                //             lblSealing_1.ForeColor = System.Drawing.Color.Yellow;
                //             lblSealing_1.Font.Bold = false;
                //         }
                //         else
                //         {
                //             e.Row.Cells[20].Style.Add("Background", "red");
                //             lblSealing_1.ForeColor = System.Drawing.Color.Yellow;
                //             lblSealing_1.Font.Bold = false;
                //         }
                //     //}
                //     //if (lblSealing_2.Text != "")
                //     //{
                //         if (Convert.ToInt32(hdnlblSealing_2.Value) >= 80)
                //         {
                //             e.Row.Cells[21].Style.Add("Background", "green");
                //             lblSealing_2.ForeColor = System.Drawing.Color.Yellow;
                //             lblSealing_2.Font.Bold = false;
                //         }
                //         else
                //         {
                //             e.Row.Cells[21].Style.Add("Background", "red");
                //             lblSealing_2.ForeColor = System.Drawing.Color.Yellow;
                //             lblSealing_2.Font.Bold = false;
                //         }
                //     //}

                //     //if (lblBIH_1.Text != "")
                //     //{
                //         if (Convert.ToInt32(hdnlblBIH_1.Value) >= 80)
                //         {
                //             e.Row.Cells[24].Style.Add("Background", "green");
                //             lblBIH_1.ForeColor = System.Drawing.Color.Yellow;
                //             lblBIH_1.Font.Bold = false;
                //         }
                //         else
                //         {
                //             e.Row.Cells[24].Style.Add("Background", "red");
                //             lblBIH_1.ForeColor = System.Drawing.Color.Yellow;
                //             lblBIH_1.Font.Bold = false;
                //         }
                //     //}

                //     //if (lblBIH_2.Text != "")
                //     //{
                //         if (Convert.ToInt32(hdnlblBIH_2.Value) >= 80)
                //         {
                //             e.Row.Cells[25].Style.Add("Background", "green");
                //             lblBIH_2.ForeColor = System.Drawing.Color.Yellow;
                //             lblBIH_2.Font.Bold = false;
                //         }
                //         else
                //         {
                //             e.Row.Cells[25].Style.Add("Background", "red");
                //             lblBIH_2.ForeColor = System.Drawing.Color.Yellow;
                //             lblBIH_2.Font.Bold = false;
                //         }                      
                //     //}                   


                //     break;
                //   case 3:
                //     lblSealing_3.Attributes.Add("style", "color:black !important;");

                //     lblBIH_3.Attributes.Add("style", "color:black !important;");

                //     StyleCodeShare_Q3.Attributes.Add("style", "color:black !important;");
                //     break;

                //   case 4:
                //     lblSealing_4.Attributes.Add("style", "color:black !important;");

                //     lblBIH_4.Attributes.Add("style", "color:black !important;");

                //     StyleCodeShare_Q4.Attributes.Add("style", "color:black !important;");

                //     break;




                // }

            }
        }
        public void score()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds = objadmin.GetIncentiveScoreAmPerformnce();
            dt = ds.Tables[3];
            StringBuilder strScore = new StringBuilder();
            if (dt.Rows.Count > 0)
            {

                string SampleDelay = "";
                string PatternPerDay = "";
                string SamplePerDay = "";
                string OrderToCutSaving = "";
                string PatternSampleScore = "";
                if (dt.Rows[0]["SampleDelay"].ToString() != "0")
                {
                    SampleDelay = dt.Rows[0]["SampleDelay"].ToString();
                }

                strScore.Append("<table cellpadding='0' cellspacing='0' border='0' style='max-width: 506px;margin: 0px 0px 5px !important; float:left;text-align: center' class='InternalAdminTable'>");
                strScore.Append("<tr><th style='padding:2px 5px !important;border:1px solid #999 !important;width:140px' colspan='5'>Patterns and sampling score (Current Qurter)</th></tr>");
                strScore.Append("<tr><th style='padding:2px 5px !important;border:1px solid #999 !important;width:175px'>Sample Delay (WK)</th><th style='padding:2px 5px !important;border:1px solid #999 !important;width:140px'>Pattern per day</th><th style='padding:2px 5px !important;border:1px solid #999 !important;width:140px'> Sample per day</th> <th style='padding:2px 5px !important;border:1px solid #999 !important;width:140px'>Order to cut</th><th style='padding:2px 5px !important;border:1px solid #999 !important;width:105px'>Score</th></tr>");
                strScore.Append("<tr><td style='width:80px;border: 1px solid #999;border-top: 0px;color:#000'>" + SampleDelay + "</td><td style='width:80px;border: 1px solid #999;border-top: 0px;color:#000'>" + dt.Rows[0]["PatternPerDay"].ToString() + "</td><td style='width:80px;border: 1px solid #999;border-top: 0px;color:#000'>" + dt.Rows[0]["SamplePerDay"].ToString() + "</td><td style='width:80px;border: 1px solid #999;border-top: 0px;color:#000'>" + dt.Rows[0]["OrderToCutSaving"].ToString() + "%</td><td style='width:80px;border: 1px solid #999;border-top: 0px;color:#000'><b>" + dt.Rows[0]["PatternSampleScore"].ToString() + "%</b></td></tr>");
                strScore.Append("</table>");
                divscore.InnerHtml = strScore.ToString();
            }
        }
        //END abhishek 20/11/2018
        protected void grdmasterper_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            int RowTotal = 0;
            int RowTotal_Remake = 0;
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string FlagMonth = string.Empty;
                    HiddenField hdnID = (HiddenField)e.Row.FindControl("hdnID");
                    HiddenField hdnStartdate = (HiddenField)e.Row.FindControl("hdnStartdate");
                    HiddenField hdnEnddate = (HiddenField)e.Row.FindControl("hdnEnddate");
                    Label lblWeekName = (Label)e.Row.FindControl("lblWeekName");
                    Label lblweekNameday = (Label)e.Row.FindControl("lblweekNameday");

                    bool IsSingleDay = Microsoft.VisualBasic.Information.IsNumeric(lblWeekName.Text);
                    if (lblweekNameday.Text != null && lblweekNameday.Text != "")
                    {
                        if (IsSingleDay)
                        {
                            bool bCheckEvent = false;
                            bCheckEvent = objProductionController.bCheckCalenderEvent_ForFits(Convert.ToDateTime(hdnStartdate.Value));


                            lblweekNameday.Text = " (" + lblweekNameday.Text.Substring(0, 3) + " )";
                            DateTime myDateTime = DateTime.Now;
                            string day = myDateTime.Day.ToString();

                            if (lblWeekName.Text.Contains(day))//hide current day
                            {
                                indexs = indexs - 1;
                                e.Row.Visible = false;
                            }
                            if (bCheckEvent == false)//hide Holiday and event
                            {
                                indexs = indexs - 1;
                                e.Row.Visible = false;
                            }
                        }
                        else
                        {
                            lblweekNameday.Text = "";
                        }
                    }
                    //master=================================================================//

                    Label lblmaster1 = (Label)e.Row.FindControl("lblmaster1");
                    Label lblmaster2 = (Label)e.Row.FindControl("lblmaster2");
                    Label lblmaster3 = (Label)e.Row.FindControl("lblmaster3");
                    Label lblmaster4 = (Label)e.Row.FindControl("lblmaster4");
                    Label lblmaster5 = (Label)e.Row.FindControl("lblmaster5");
                    Label lblmaster6 = (Label)e.Row.FindControl("lblmaster6");
                    Label lblmaster1Remake = (Label)e.Row.FindControl("lblmaster1Remake");
                    Label lblmaster2Remake = (Label)e.Row.FindControl("lblmaster2Remake");
                    Label lblmaster3Remake = (Label)e.Row.FindControl("lblmaster3Remake");
                    Label lblmaster4Remake = (Label)e.Row.FindControl("lblmaster4Remake");
                    Label lblmaster5Remake = (Label)e.Row.FindControl("lblmaster5Remake");
                    Label lblmaster6Remake = (Label)e.Row.FindControl("lblmaster6Remake");





                    Label lblmaster1days = (Label)e.Row.FindControl("lblmaster1days");
                    Label lblmaster2days = (Label)e.Row.FindControl("lblmaster2days");
                    Label lblmaster3days = (Label)e.Row.FindControl("lblmaster3days");
                    Label lblmaster4days = (Label)e.Row.FindControl("lblmaster4days");
                    Label lblmaster5days = (Label)e.Row.FindControl("lblmaster5days");
                    Label lblmaster6days = (Label)e.Row.FindControl("lblmaster6days");

                    Label lblmaster1daysRemake = (Label)e.Row.FindControl("lblmaster1daysRemake");
                    Label lblmaster2daysRemake = (Label)e.Row.FindControl("lblmaster2daysRemake");
                    Label lblmaster3daysRemake = (Label)e.Row.FindControl("lblmaster3daysRemake");
                    Label lblmaster4daysRemake = (Label)e.Row.FindControl("lblmaster4daysRemake");
                    Label lblmaster5daysRemake = (Label)e.Row.FindControl("lblmaster5daysRemake");
                    Label lblmaster6daysRemake = (Label)e.Row.FindControl("lblmaster6daysRemake");

                    Label lblmaster1Total = (Label)e.Row.FindControl("lblmaster1Total");
                    Label lblmaster2Total = (Label)e.Row.FindControl("lblmaster2Total");
                    Label lblmaster3Total = (Label)e.Row.FindControl("lblmaster3Total");
                    Label lblmaster4Total = (Label)e.Row.FindControl("lblmaster4Total");
                    Label lblmaster5Total = (Label)e.Row.FindControl("lblmaster5Total");
                    Label lblmaster6Total = (Label)e.Row.FindControl("lblmaster6Total");

                    Label lblmaster1TotalRemake = (Label)e.Row.FindControl("lblmaster1TotalRemake");
                    Label lblmaster2TotalRemake = (Label)e.Row.FindControl("lblmaster2TotalRemake");
                    Label lblmaster3TotalRemake = (Label)e.Row.FindControl("lblmaster3TotalRemake");
                    Label lblmaster4TotalRemake = (Label)e.Row.FindControl("lblmaster4TotalRemake");
                    Label lblmaster5TotalRemake = (Label)e.Row.FindControl("lblmaster5TotalRemake");
                    Label lblmaster6TotalRemake = (Label)e.Row.FindControl("lblmaster6TotalRemake");


                    HiddenField hdnmaster1_ID = (HiddenField)e.Row.FindControl("hdnmaster1_ID");
                    HiddenField hdnmaster2_ID = (HiddenField)e.Row.FindControl("hdnmaster2_ID");
                    HiddenField hdnmaster3_ID = (HiddenField)e.Row.FindControl("hdnmaster3_ID");
                    HiddenField hdnmaster4_ID = (HiddenField)e.Row.FindControl("hdnmaster4_ID");
                    //HiddenField hdnmaster5_ID = (HiddenField)e.Row.FindControl("hdnmaster5_ID");
                    HiddenField hdnmaster6_ID = (HiddenField)e.Row.FindControl("hdnmaster6_ID");



                    Label lblTotal = (Label)e.Row.FindControl("lblTotal");
                    Label lblmasterTotaltillnow = (Label)e.Row.FindControl("lblmasterTotaltillnow");
                    Label lblTotalRemake = (Label)e.Row.FindControl("lblTotalRemake");
                    Label lblmasterTotaltillnowRemake = (Label)e.Row.FindControl("lblmasterTotaltillnowRemake");
                    Label lblAvgPerformance = (Label)e.Row.FindControl("lblAvgPerformance");

                    Label lblTotaldays = (Label)e.Row.FindControl("lblTotaldays");
                    Label lblTotaldaysRemake = (Label)e.Row.FindControl("lblTotaldaysRemake");
                    Label lblAvgPerformancedays = (Label)e.Row.FindControl("lblAvgPerformancedays");


                    HiddenField hdnTotal_ID = (HiddenField)e.Row.FindControl("hdnTotal_ID");
                    HiddenField hdnAvgPerformance_ID = (HiddenField)e.Row.FindControl("hdnAvgPerformance_ID");

                    DataTable dt = new DataTable();
                    dt = objadmin.GetFitsMasterReport("MONTH-AVG", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster1_ID.Value));

                    if (dt.Rows.Count > 0)
                    {
                        lblmaster1.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                        RowTotal = RowTotal + Convert.ToInt32(dt.Rows[0]["val"].ToString());
                        lblmaster1Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                        RowTotal_Remake = RowTotal_Remake + Convert.ToInt32(dt.Rows[0]["val_Remake"].ToString());

                    }
                    dt = objadmin.GetFitsMasterReport("MONTH-AVG", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster2_ID.Value));

                    if (dt.Rows.Count > 0)
                    {
                        lblmaster2.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                        RowTotal = RowTotal + Convert.ToInt32(dt.Rows[0]["val"].ToString());
                        lblmaster2Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                        RowTotal_Remake = RowTotal_Remake + Convert.ToInt32(dt.Rows[0]["val_Remake"].ToString());
                    }
                    dt = objadmin.GetFitsMasterReport("MONTH-AVG", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster3_ID.Value));

                    if (dt.Rows.Count > 0)
                    {
                        lblmaster3.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                        RowTotal = RowTotal + Convert.ToInt32(dt.Rows[0]["val"].ToString());
                        lblmaster3Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                        RowTotal_Remake = RowTotal_Remake + Convert.ToInt32(dt.Rows[0]["val_Remake"].ToString());
                    }
                    dt = objadmin.GetFitsMasterReport("MONTH-AVG", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster4_ID.Value));

                    if (dt.Rows.Count > 0)
                    {
                        lblmaster4.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                        RowTotal = RowTotal + Convert.ToInt32(dt.Rows[0]["val"].ToString());
                        lblmaster4Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                        RowTotal_Remake = RowTotal_Remake + Convert.ToInt32(dt.Rows[0]["val_Remake"].ToString());
                    }
                    //dt = objadmin.GetFitsMasterReport("MONTH-AVG", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster5_ID.Value));

                    //if (dt.Rows.Count > 0)
                    //{
                    //    //lblmaster5.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                    //    RowTotal = RowTotal + Convert.ToInt32(dt.Rows[0]["val"].ToString());
                    //    //lblmaster5Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                    //    RowTotal_Remake = RowTotal_Remake + Convert.ToInt32(dt.Rows[0]["val_Remake"].ToString());
                    //}
                    dt = objadmin.GetFitsMasterReport("MONTH-AVG", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster6_ID.Value));
                    if (dt.Rows.Count > 0)
                    {
                        lblmaster6.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                        RowTotal = RowTotal + Convert.ToInt32(dt.Rows[0]["val"].ToString());
                        lblmaster6Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                        RowTotal_Remake = RowTotal_Remake + Convert.ToInt32(dt.Rows[0]["val_Remake"].ToString());
                    }
                    //Total==Avg===============================================================//

                    dt = objadmin.GetFitsMasterReport("TOTAL-AVG", hdnStartdate.Value, hdnEnddate.Value, 0);

                    //if (dt.Rows.Count > 0)
                    //{
                    //    lblTotal.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                    //}
                    if (RowTotal > 0)
                    {
                        lblTotal.Text = RowTotal.ToString();
                    }
                    if (RowTotal_Remake > 0)
                    {
                        lblTotalRemake.Text = RowTotal_Remake.ToString();
                    }
                    dt = objadmin.GetFitsMasterReport("AVG", hdnStartdate.Value, hdnEnddate.Value, 0);

                    if (lblweekNameday.Text.Replace("(", "").Replace(")", "").Contains("Sun") == false)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            lblAvgPerformance.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            if ((hdnID.Value == "999") || (hdnID.Value == "1000") || (hdnID.Value == "1001"))
                            {
                                //if (hdnID.Value != "999")

                            }
                            else
                            {
                                BIPLPerformance = BIPLPerformance + Convert.ToInt32(lblAvgPerformance.Text = lblAvgPerformance.Text == "" ? "0" : lblAvgPerformance.Text);
                            }
                            //if (hdnID.Value != "1000")
                            //     BIPLPerformance = BIPLPerformance + Convert.ToInt32(lblAvgPerformance.Text = lblAvgPerformance.Text == "" ? "0" : lblAvgPerformance.Text);

                        }
                        // indexs = indexs - 1;
                    }

                    //=========================================================================//
                    if (hdnID.Value == "999")//for style avg per
                    {
                        dt = objadmin.GetFitsMasterReport("STYLE", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster1_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster1.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            lblmaster1Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                        }
                        dt = objadmin.GetFitsMasterReport("STYLE", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster2_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster2.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            lblmaster2Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                        }
                        dt = objadmin.GetFitsMasterReport("STYLE", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster3_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster3.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            lblmaster3Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                        }
                        dt = objadmin.GetFitsMasterReport("STYLE", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster4_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster4.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            lblmaster4Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                        }
                        //dt = objadmin.GetFitsMasterReport("STYLE", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster5_ID.Value));

                        //if (dt.Rows.Count > 0)
                        //{
                        //    lblmaster5.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                        //    lblmaster5Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                        //}
                        dt = objadmin.GetFitsMasterReport("STYLE", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster6_ID.Value));
                        if (dt.Rows.Count > 0)
                        {
                            lblmaster6.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            lblmaster6Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                        }

                        dt = objadmin.GetFitsMasterReport("STYLE", hdnStartdate.Value, hdnEnddate.Value, 999);
                        if (dt.Rows.Count > 0)
                        {
                            lblTotal.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            lblTotalRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                        }
                        dt = objadmin.GetFitsMasterReport("STYLE-AVG", hdnStartdate.Value, hdnEnddate.Value, 999);
                        if (dt.Rows.Count > 0)
                        {
                            //lblAvgPerformance.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            lblAvgPerformance.Text = Convert.ToString(Math.Round(Convert.ToDecimal(BIPLPerformance) / Convert.ToDecimal(days), 0));
                        }
                        //===========show master total =============================================================================================//
                        dt = objadmin.GetFitsMasterReport("TOTAL", hdnStartdate.Value, hdnEnddate.Value, 0);

                        if (dt.Rows.Count > 0)
                        {
                            lblmasterTotaltillnow.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "(" + dt.Rows[0]["val"].ToString() + ")";
                            lblmasterTotaltillnowRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "(" + dt.Rows[0]["val_Remake"].ToString() + ")";
                        }

                        dt = objadmin.GetFitsMasterReport("MONTH", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster1_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster1Total.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "( " + dt.Rows[0]["val"].ToString() + " )";
                            lblmaster1TotalRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "( " + dt.Rows[0]["val_Remake"].ToString() + " )";
                        }
                        dt = objadmin.GetFitsMasterReport("MONTH", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster2_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster2Total.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "( " + dt.Rows[0]["val"].ToString() + " )";
                            lblmaster2TotalRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "( " + dt.Rows[0]["val_Remake"].ToString() + " )";
                        }
                        dt = objadmin.GetFitsMasterReport("MONTH", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster3_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster3Total.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "( " + dt.Rows[0]["val"].ToString() + " )";
                            lblmaster3TotalRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "( " + dt.Rows[0]["val_Remake"].ToString() + " )";
                        }
                        dt = objadmin.GetFitsMasterReport("MONTH", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster4_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster4Total.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "( " + dt.Rows[0]["val"].ToString() + " )";
                            lblmaster4TotalRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "( " + dt.Rows[0]["val_Remake"].ToString() + " )";
                        }
                        //dt = objadmin.GetFitsMasterReport("MONTH", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster5_ID.Value));

                        //if (dt.Rows.Count > 0)
                        //{
                        //    lblmaster5Total.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "( " + dt.Rows[0]["val"].ToString() + " )";
                        //    lblmaster5TotalRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "( " + dt.Rows[0]["val_Remake"].ToString() + " )";
                        //}
                        dt = objadmin.GetFitsMasterReport("MONTH", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster6_ID.Value));
                        if (dt.Rows.Count > 0)
                        {
                            lblmaster6Total.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "( " + dt.Rows[0]["val"].ToString() + " )";
                            lblmaster6TotalRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "( " + dt.Rows[0]["val_Remake"].ToString() + " )";
                        }
                    }
                    if (hdnID.Value == "1000")//for WIP avg per
                    {
                        dt = objadmin.GetFitsMasterReport("WIP", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster1_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster1.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "<b>" + dt.Rows[0]["val"].ToString() + "</b>";
                            lblmaster1Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                            lblmaster1Remake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster2_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster2.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "<b>" + dt.Rows[0]["val"].ToString() + "</b>";
                            lblmaster2Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                            lblmaster2Remake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster3_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster3.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "<b>" + dt.Rows[0]["val"].ToString() + "</b>";
                            lblmaster3Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                            lblmaster3Remake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster4_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster4.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "<b>" + dt.Rows[0]["val"].ToString() + "</b>";
                            lblmaster4Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                            lblmaster4Remake.Visible = false;
                        }
                        //dt = objadmin.GetFitsMasterReport("WIP", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster5_ID.Value));

                        //if (dt.Rows.Count > 0)
                        //{
                        //    lblmaster5.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "<b>" + dt.Rows[0]["val"].ToString() + "</b>";
                        //    lblmaster5Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                        //    lblmaster5Remake.Visible = false;
                        //}
                        dt = objadmin.GetFitsMasterReport("WIP", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster6_ID.Value));
                        if (dt.Rows.Count > 0)
                        {
                            lblmaster6.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "<b>" + dt.Rows[0]["val"].ToString() + "</b>";
                            lblmaster6Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                            lblmaster6Remake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP", hdnStartdate.Value, hdnEnddate.Value, 1000);
                        if (dt.Rows.Count > 0)
                        {
                            lblTotal.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            lblTotalRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                            lblTotalRemake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP", hdnStartdate.Value, hdnEnddate.Value, 1000);
                        if (dt.Rows.Count > 0)
                        {
                            lblAvgPerformance.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            //lblAvgPerformance.Text = "";
                        }

                    }
                    if (hdnID.Value == "1001")//for WIP avg per
                    {
                        dt = objadmin.GetFitsMasterReport("WIP_Fitting", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster1_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster1.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "<b>" + dt.Rows[0]["val"].ToString() + "</b>";
                            lblmaster1Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                            lblmaster1Remake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP_Fitting", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster2_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster2.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "<b>" + dt.Rows[0]["val"].ToString() + "</b>";
                            lblmaster2Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                            lblmaster2Remake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP_Fitting", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster3_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster3.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "<b>" + dt.Rows[0]["val"].ToString() + "</b>";
                            lblmaster3Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                            lblmaster3Remake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP_Fitting", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster4_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster4.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "<b>" + dt.Rows[0]["val"].ToString() + "</b>";
                            lblmaster4Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                            lblmaster4Remake.Visible = false;
                        }
                        //dt = objadmin.GetFitsMasterReport("WIP_Fitting", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster5_ID.Value));

                        //if (dt.Rows.Count > 0)
                        //{
                        //    lblmaster5.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "<b>" + dt.Rows[0]["val"].ToString() + "</b>";
                        //    lblmaster5Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                        //    lblmaster5Remake.Visible = false;
                        //}
                        dt = objadmin.GetFitsMasterReport("WIP_Fitting", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster6_ID.Value));
                        if (dt.Rows.Count > 0)
                        {
                            lblmaster6.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : "<b>" + dt.Rows[0]["val"].ToString() + "</b>";
                            lblmaster6Remake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                            lblmaster6Remake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP_Fitting", hdnStartdate.Value, hdnEnddate.Value, 1000);
                        if (dt.Rows.Count > 0)
                        {
                            lblTotal.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            lblTotalRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : dt.Rows[0]["val_Remake"].ToString();
                            lblTotalRemake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP_Fitting", hdnStartdate.Value, hdnEnddate.Value, 1000);
                        if (dt.Rows.Count > 0)
                        {
                            lblAvgPerformance.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            //lblAvgPerformance.Text = "";
                        }

                    }
                    if (hdnID.Value == "1000")//for WIP avg per
                    {
                        dt = objadmin.GetFitsMasterReport("WIP-DAYS", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster1_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster1days.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            if (Convert.ToInt32(dt.Rows[0]["val"].ToString()) >= 3)
                            {
                                if (lblmaster1days.Text != "")
                                    lblmaster1days.Text = "<br/> <span style='color:red;font-weight:bold;'>" + lblmaster1days.Text + " Days</span>";
                            }
                            else
                            {
                                if (lblmaster1days.Text != "")
                                    lblmaster1days.Text = "<br/> <span style='color:gray;font-weight:bold;'>" + lblmaster1days.Text + " Days</span>";
                            }
                            lblmaster1daysRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "<br/> <span style='color:gray;font-weight:bold;'> (" + dt.Rows[0]["val_Remake"].ToString() + " Days)</span>";
                            lblmaster1daysRemake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP-DAYS", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster2_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster2days.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();

                            if (Convert.ToInt32(dt.Rows[0]["val"].ToString()) >= 3)
                            {
                                if (lblmaster2days.Text != "")
                                    lblmaster2days.Text = "<br/> <span style='color:red;font-weight:bold;'>" + lblmaster2days.Text + " Days</span>";
                            }
                            else
                            {
                                if (lblmaster2days.Text != "")
                                    lblmaster2days.Text = "<br/> <span style='color:gray;font-weight:bold;'>" + lblmaster2days.Text + " Days</span>";
                            }

                            lblmaster2daysRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "<br/> <span style='color:gray;font-weight:bold;'> (" + dt.Rows[0]["val_Remake"].ToString() + " Days)</span>";
                            lblmaster2daysRemake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP-DAYS", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster3_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster3days.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            if (Convert.ToInt32(dt.Rows[0]["val"].ToString()) >= 3)
                            {
                                if (lblmaster3days.Text != "")
                                    lblmaster3days.Text = "<br/> <span style='color:red;font-weight:bold;'>" + lblmaster3days.Text + " Days</span>";
                            }
                            else
                            {
                                if (lblmaster3days.Text != "")
                                    lblmaster3days.Text = "<br/> <span style='color:gray;font-weight:bold;'>" + lblmaster3days.Text + " Days </span>";
                            }

                            lblmaster3daysRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "<br/> <span style='color:gray;font-weight:bold;'> (" + dt.Rows[0]["val_Remake"].ToString() + " Days)</span>";
                            lblmaster3daysRemake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP-DAYS", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster4_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster4days.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();

                            if (Convert.ToInt32(dt.Rows[0]["val"].ToString()) >= 3)
                            {
                                if (lblmaster4days.Text != "")
                                    lblmaster4days.Text = "<br/> <span style='color:red;font-weight:bold;'>" + lblmaster4days.Text + " Days</span>";
                            }
                            else
                            {
                                if (lblmaster4days.Text != "")
                                    lblmaster4days.Text = "<br/> <span style='color:gray;font-weight:bold;'>" + dt.Rows[0]["val"].ToString() + " Days </span>";
                            }


                            lblmaster4daysRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "<br/> <span style='color:gray;font-weight:bold;'> (" + dt.Rows[0]["val_Remake"].ToString() + " Days)</span>";
                            lblmaster4daysRemake.Visible = false;
                        }
                        //dt = objadmin.GetFitsMasterReport("WIP-DAYS", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster5_ID.Value));

                        //if (dt.Rows.Count > 0)
                        //{
                        //    lblmaster5days.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                        //    if (Convert.ToInt32(dt.Rows[0]["val"].ToString()) >= 3)
                        //    {
                        //        if (lblmaster5days.Text != "")
                        //            lblmaster5days.Text = "<br/> <span style='color:red;font-weight:bold;'>" + lblmaster5days.Text + " Days</span>";
                        //    }
                        //    else
                        //    {
                        //        if (lblmaster5days.Text != "")
                        //            lblmaster5days.Text = "<br/> <span style='color:gray;font-weight:bold;'>" + lblmaster5days.Text + " Days </span>";
                        //    }

                        //    lblmaster5daysRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "<br/> <span style='color:gray;font-weight:bold;'> (" + dt.Rows[0]["val_Remake"].ToString() + " Days)</span>";
                        //    lblmaster5daysRemake.Visible = false;
                        //}

                        dt = objadmin.GetFitsMasterReport("WIP-DAYS", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster6_ID.Value));
                        if (dt.Rows.Count > 0)
                        {
                            lblmaster6days.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            if (Convert.ToInt32(dt.Rows[0]["val"].ToString()) >= 3)
                            {
                                if (lblmaster6days.Text != "")
                                    lblmaster6days.Text = "<br/> <span style='color:red;font-weight:bold;'>" + lblmaster6days.Text + " Days</span>";
                            }
                            else
                            {
                                if (lblmaster6days.Text != "")
                                    lblmaster6days.Text = "<br/> <span style='color:gray;font-weight:bold;'>" + lblmaster6days.Text + " Days </span>";
                            }
                            lblmaster6daysRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "<br/> <span style='color:gray;font-weight:bold;'> (" + dt.Rows[0]["val_Remake"].ToString() + " Days)</span>";
                            lblmaster6daysRemake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP-DAYS", hdnStartdate.Value, hdnEnddate.Value, 1000);
                        if (dt.Rows.Count > 0)
                        {
                            lblTotaldays.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            if (Convert.ToInt32(dt.Rows[0]["val"].ToString()) >= 3)
                            {
                                if (lblTotaldays.Text != "")
                                    lblTotaldays.Text = "<br/> <span style='color:red;font-weight:bold;'>" + lblTotaldays.Text + " Days</span>";
                            }
                            else
                            {
                                if (lblTotaldays.Text != "")
                                    lblTotaldays.Text = "<br/> <span style='color:gray;font-weight:bold;'>" + lblTotaldays.Text + " Days </span>";
                            }


                            lblTotaldaysRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "<br/> <span style='color:gray;font-weight:bold;'> (" + dt.Rows[0]["val_Remake"].ToString() + " Days)</span>";
                            lblTotaldaysRemake.Visible = false;
                        }
                        //dt = objadmin.GetFitsMasterReport("WIP-DAYS-AVG", hdnStartdate.Value, hdnEnddate.Value, 1000);
                        //if (dt.Rows.Count > 0)
                        //{
                        //    //lblAvgPerformancedays.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : " (" + dt.Rows[0]["val"].ToString() + " days)";
                        //    lblAvgPerformancedays.Text = "";
                        //}

                        //if (lblAvgPerformance.Text != "")
                        //{
                        double total = lblTotal.Text != "" ? Convert.ToDouble(lblTotal.Text) : 0;
                        // double AvgPerformance = lblAvgPerformance.Text != "" ? Convert.ToDouble(lblAvgPerformance.Text) : 0;
                        decimal AvgPerformance = Math.Round(Convert.ToDecimal(BIPLPerformance) / Convert.ToDecimal(days), 0);
                        int MasterCount = 5;
                        double Wipdays = (total / (Convert.ToDouble(AvgPerformance) * MasterCount));
                        double res = Math.Round(Wipdays, 0, MidpointRounding.AwayFromZero);
                        lblAvgPerformancedays.Text = (res.ToString() == "0" || res.ToString() == "" || res.ToString() == "0.0") ? "" : " (" + res.ToString() + " Days)";


                        //}
                    }
                    if (hdnID.Value == "1001")//for WIP avg per
                    {
                        dt = objadmin.GetFitsMasterReport("WIP-DAYS_Fitting", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster1_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster1days.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            if (Convert.ToInt32(dt.Rows[0]["val"].ToString()) >= 3)
                            {
                                if (lblmaster1days.Text != "")
                                    lblmaster1days.Text = "<br/> <span style='color:red;font-weight:bold;'>" + lblmaster1days.Text + " Days</span>";
                            }
                            else
                            {
                                if (lblmaster1days.Text != "")
                                    lblmaster1days.Text = "<br/> <span style='color:gray;font-weight:bold;'>" + lblmaster1days.Text + " Days </span>";
                            }


                            lblmaster1daysRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "<br/> <span style='color:gray;font-weight:bold;'> (" + dt.Rows[0]["val_Remake"].ToString() + " Days)</span>";
                            lblmaster1daysRemake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP-DAYS_Fitting", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster2_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster2days.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();

                            if (Convert.ToInt32(dt.Rows[0]["val"].ToString()) >= 3)
                            {
                                if (lblmaster2days.Text != "")
                                    lblmaster2days.Text = "<br/> <span style='color:red;font-weight:bold;'>" + lblmaster2days.Text + " Days</span>";
                            }
                            else
                            {
                                if (lblmaster2days.Text != "")
                                    lblmaster2days.Text = "<br/> <span style='color:gray;font-weight:bold;'>" + lblmaster2days.Text + " Days </span>";
                            }

                            lblmaster2daysRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "<br/> <span style='color:gray;font-weight:bold;'> (" + dt.Rows[0]["val_Remake"].ToString() + " Days)</span>";
                            lblmaster2daysRemake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP-DAYS_Fitting", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster3_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster3days.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            if (Convert.ToInt32(dt.Rows[0]["val"].ToString()) >= 3)
                            {
                                if (lblmaster3days.Text != "")
                                    lblmaster3days.Text = "<br/> <span style='color:red;font-weight:bold;'>" + lblmaster3days.Text + " Days</span>";
                            }
                            else
                            {
                                if (lblmaster3days.Text != "")
                                    lblmaster3days.Text = "<br/> <span style='color:gray;font-weight:bold;'>" + lblmaster3days.Text + " Days </span>";
                            }

                            lblmaster3daysRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "<br/> <span style='color:gray;font-weight:bold;'> (" + dt.Rows[0]["val_Remake"].ToString() + " Days)</span>";
                            lblmaster3daysRemake.Visible = false;
                        }
                        dt = objadmin.GetFitsMasterReport("WIP-DAYS_Fitting", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster4_ID.Value));

                        if (dt.Rows.Count > 0)
                        {
                            lblmaster4days.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            if (Convert.ToInt32(dt.Rows[0]["val"].ToString()) >= 3)
                            {
                                if (lblmaster4days.Text != "")
                                    lblmaster4days.Text = "<br/> <span style='color:red;font-weight:bold;'>" + lblmaster4days.Text + " Days</span>";
                            }
                            else
                            {
                                if (lblmaster4days.Text != "")
                                    lblmaster4days.Text = "<br/> <span style='color:gray;font-weight:bold;'>" + lblmaster4days.Text + " Days </span>";
                            }

                            lblmaster4daysRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "<br/> <span style='color:gray;font-weight:bold;'> (" + dt.Rows[0]["val_Remake"].ToString() + " Days)</span>";
                            lblmaster4daysRemake.Visible = false;
                        }
                        //dt = objadmin.GetFitsMasterReport("WIP-DAYS_Fitting", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster5_ID.Value));

                        //if (dt.Rows.Count > 0)
                        //{
                        //    lblmaster5days.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                        //    if (Convert.ToInt32(dt.Rows[0]["val"].ToString()) >= 3)
                        //    {
                        //        if (lblmaster5days.Text != "")
                        //            lblmaster5days.Text = "<br/> <span style='color:red;font-weight:bold;'>" + lblmaster5days.Text + " Days</span>";
                        //    }
                        //    else
                        //    {
                        //        if (lblmaster5days.Text != "")
                        //            lblmaster5days.Text = "<br/> <span style='color:gray;font-weight:bold;'>" + lblmaster5days.Text + " Days </span>";
                        //    }

                        //    lblmaster5daysRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "<br/> <span style='color:gray;font-weight:bold;'> (" + dt.Rows[0]["val_Remake"].ToString() + " Days)</span>";
                        //    lblmaster5daysRemake.Visible = false;
                        //}
                        dt = objadmin.GetFitsMasterReport("WIP-DAYS_Fitting", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster6_ID.Value));
                        if (dt.Rows.Count > 0)
                        {
                            lblmaster6days.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            if (Convert.ToInt32(dt.Rows[0]["val"].ToString()) >= 3)
                            {
                                if (lblmaster6days.Text != "")
                                    lblmaster6days.Text = "<br/> <span style='color:red;font-weight:bold;'>" + lblmaster6days.Text + " Days</span>";
                            }
                            else
                            {
                                if (lblmaster6days.Text != "")
                                    lblmaster6days.Text = "<br/> <span style='color:gray;font-weight:bold;'>" + lblmaster6days.Text + " Days </span>";
                            }
                        }
                        dt = objadmin.GetFitsMasterReport("WIP-DAYS_Fitting", hdnStartdate.Value, hdnEnddate.Value, 1000);
                        if (dt.Rows.Count > 0)
                        {
                            lblTotaldays.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                            if (Convert.ToInt32(dt.Rows[0]["val"].ToString()) >= 3)
                            {
                                if (lblTotaldays.Text != "")
                                    lblTotaldays.Text = "<br/> <span style='color:red;font-weight:bold;'>" + lblTotaldays.Text + " Days</span>";
                            }
                            else
                            {
                                if (lblTotaldays.Text != "")
                                    lblTotaldays.Text = "<br/> <span style='color:gray;font-weight:bold;'>" + lblTotaldays.Text + " Days </span>";
                            }

                            lblTotaldaysRemake.Text = dt.Rows[0]["val_Remake"].ToString() == "0" ? "" : "<br/> <span style='color:gray;font-weight:bold;'> (" + dt.Rows[0]["val_Remake"].ToString() + " Days)</span>";
                            lblTotaldaysRemake.Visible = false;
                        }
                        //dt = objadmin.GetFitsMasterReport("WIP-DAYS-AVG", hdnStartdate.Value, hdnEnddate.Value, 1000);
                        //if (dt.Rows.Count > 0)
                        //{
                        //    //lblAvgPerformancedays.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : " (" + dt.Rows[0]["val"].ToString() + " days)";
                        //    lblAvgPerformancedays.Text = "";
                        //}

                        //if (lblAvgPerformance.Text != "")
                        //{
                        double total = lblTotal.Text != "" ? Convert.ToDouble(lblTotal.Text) : 0;
                        // double AvgPerformance = lblAvgPerformance.Text != "" ? Convert.ToDouble(lblAvgPerformance.Text) : 0;
                        decimal AvgPerformance = Math.Round(Convert.ToDecimal(BIPLPerformance) / Convert.ToDecimal(days), 0);
                        int MasterCount = 5;
                        double Wipdays = (total / (Convert.ToDouble(AvgPerformance) * MasterCount));
                        double res = Math.Round(Wipdays, 0, MidpointRounding.AwayFromZero);
                        lblAvgPerformancedays.Text = (res.ToString() == "0" || res.ToString() == "" || res.ToString() == "0.0") ? "" : " (" + res.ToString() + " Days)";


                        //}
                    }
                    //=========================================================================//
                    //if (lblWeekName.Text == "Avg Style Performance")
                    //{
                    //    if (hdnID.Value == "999")//for style avg per
                    //    {
                    //        dt = objadmin.GetFitsMasterReport("MONTH", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster1_ID.Value));

                    //        if (dt.Rows.Count > 0)
                    //        {
                    //            lblmaster1.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                    //        }
                    //        dt = objadmin.GetFitsMasterReport("MONTH", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster2_ID.Value));

                    //        if (dt.Rows.Count > 0)
                    //        {
                    //            lblmaster2.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                    //        }
                    //        dt = objadmin.GetFitsMasterReport("MONTH", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster3_ID.Value));

                    //        if (dt.Rows.Count > 0)
                    //        {
                    //            lblmaster3.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                    //        }
                    //        dt = objadmin.GetFitsMasterReport("MONTH", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster4_ID.Value));

                    //        if (dt.Rows.Count > 0)
                    //        {
                    //            lblmaster4.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                    //        }
                    //        dt = objadmin.GetFitsMasterReport("MONTH", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster5_ID.Value));

                    //        if (dt.Rows.Count > 0)
                    //        {
                    //            lblmaster5.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                    //        }
                    //        dt = objadmin.GetFitsMasterReport("MONTH", hdnStartdate.Value, hdnEnddate.Value, Convert.ToInt32(hdnmaster6_ID.Value));
                    //        if (dt.Rows.Count > 0)
                    //        {
                    //            lblmaster6.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                    //        }

                    //        dt = objadmin.GetFitsMasterReport("TOTAL", hdnStartdate.Value, hdnEnddate.Value, 999);
                    //        if (dt.Rows.Count > 0)
                    //        {
                    //            lblTotal.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                    //        }
                    //        dt = objadmin.GetFitsMasterReport("AVG", hdnStartdate.Value, hdnEnddate.Value, 999);
                    //        if (dt.Rows.Count > 0)
                    //        {
                    //            lblAvgPerformance.Text = dt.Rows[0]["val"].ToString() == "0" ? "" : dt.Rows[0]["val"].ToString();
                    //        }

                    //    }
                    //}


                    //=====================Tailor monthly performance=============================================//
                    if (lblweekNameday.Text.Replace("(", "").Replace(")", "").Contains("Sun"))
                    {
                        indexs = indexs - 1;
                        e.Row.Visible = false;
                        // indexs = indexs - 1;
                    }


                    Label lbltailorCap = (Label)e.Row.FindControl("lbltailorCap");
                    Label lbltailorPresent = (Label)e.Row.FindControl("lbltailorPresent");
                    Label lbltailorSampleSent = (Label)e.Row.FindControl("lbltailorSampleSent");
                    Label lbltailorAvgPer = (Label)e.Row.FindControl("lbltailorAvgPer");
                    Label lblSampleMade = (Label)e.Row.FindControl("lblSampleMade");


                    if (hdnID.Value != "999" && hdnID.Value != "1000" && hdnID.Value != "1001")
                    {
                        dt = objadmin.GetFitstailorMonthlyReport("", hdnStartdate.Value, hdnEnddate.Value, 0);
                        if (dt.Rows.Count > 0)
                        {
                            lbltailorCap.Text = dt.Rows[0]["TailorCap"].ToString() == "0" ? "" : dt.Rows[0]["TailorCap"].ToString();
                            lbltailorPresent.Text = dt.Rows[0]["TailorPercent"].ToString() == "0" ? "" : dt.Rows[0]["TailorPercent"].ToString();
                            lbltailorSampleSent.Text = dt.Rows[0]["SampleSent"].ToString() == "0" ? "" : dt.Rows[0]["SampleSent"].ToString();
                            lbltailorAvgPer.Text = dt.Rows[0]["AvgPer"].ToString() == "0" ? "" : dt.Rows[0]["AvgPer"].ToString();
                            lblSampleMade.Text = dt.Rows[0]["SampleMade"].ToString() == "0" ? "" : dt.Rows[0]["SampleMade"].ToString();
                            SumAvgPer = SumAvgPer + (lbltailorAvgPer.Text == "" ? 0 : Convert.ToDouble(lbltailorAvgPer.Text));
                        }
                    }
                    if (hdnID.Value == "999")//for avg row 
                    {
                        dt = objadmin.GetFitstailorMonthlyReport("999", hdnStartdate.Value, hdnEnddate.Value, indexs);
                        if (dt.Rows.Count > 0)
                        {
                            lbltailorCap.Text = dt.Rows[0]["TailorCapAvg"].ToString() == "0" ? "" : dt.Rows[0]["TailorCapAvg"].ToString();
                            lbltailorPresent.Text = dt.Rows[0]["TailorPercentAvg"].ToString() == "0" ? "" : dt.Rows[0]["TailorPercentAvg"].ToString();
                            lbltailorSampleSent.Text = dt.Rows[0]["SampleSentAvg"].ToString() == "0" ? "" : dt.Rows[0]["SampleSentAvg"].ToString();
                            //lbltailorAvgPer.Text = dt.Rows[0]["AvgPer"].ToString() == "0" ? "" : dt.Rows[0]["AvgPer"].ToString();
                            lblSampleMade.Text = dt.Rows[0]["SampleMadeAvg"].ToString() == "0" ? "" : dt.Rows[0]["SampleMadeAvg"].ToString();

                            SumAvgPer = (SumAvgPer.ToString() == "0" || SumAvgPer.ToString() == "") ? 0 : SumAvgPer;
                            double TrailorPresent = lbltailorPresent.Text == "" ? 1 : Convert.ToDouble(lbltailorPresent.Text);
                            lbltailorAvgPer.Text = Math.Round((SumAvgPer / Convert.ToDouble(days) * TrailorPresent), 0, MidpointRounding.AwayFromZero).ToString();
                            WipForAvgPer = Math.Round((SumAvgPer / Convert.ToDouble(days) * TrailorPresent), 0, MidpointRounding.AwayFromZero);
                        }
                    }
                    if (hdnID.Value == "1000")//for avg row 
                    {
                        dt = objadmin.GetFitstailorMonthlyReport("1000", hdnStartdate.Value, hdnEnddate.Value, indexs);
                        if (dt.Rows.Count > 0)
                        {
                            //lbltailorCap.Text = dt.Rows[0]["TailorCapAvg"].ToString() == "0" ? "" : dt.Rows[0]["TailorCapAvg"].ToString();
                            //lbltailorPresent.Text = dt.Rows[0]["TailorPercentAvg"].ToString() == "0" ? "" : dt.Rows[0]["TailorPercentAvg"].ToString();
                            lbltailorSampleSent.Text = dt.Rows[0]["PendingSmapleSentCount"].ToString() == "0" ? "" : dt.Rows[0]["PendingSmapleSentCount"].ToString();
                            lbltailorSampleSent.Text = Convert.ToString(Convert.ToInt32(lbltailorSampleSent.Text) * 2);
                            lblSampleMade.Text = dt.Rows[0]["PendingSmapleMadeCount"].ToString() == "0" ? "" : dt.Rows[0]["PendingSmapleMadeCount"].ToString();
                            lblSampleMade.Visible = false;
                            if (dt.Rows[0]["WipDaySampleSent"].ToString() != "0")
                            {
                                lbltailorSampleSent.Text = lbltailorSampleSent.Text + " (" + dt.Rows[0]["WipDaySampleSent"].ToString() + " Days)";

                            }
                            if (dt.Rows[0]["WipDaySampleMade"].ToString() != "0")
                            {
                                lblSampleMade.Text = lblSampleMade.Text + " (" + dt.Rows[0]["WipDaySampleMade"].ToString() + " Days)";
                                lblSampleMade.Visible = false;
                            }
                            lbltailorAvgPer.Text = dt.Rows[0]["PendingSmapleSentCount"].ToString() == "0" ? "" : dt.Rows[0]["PendingSmapleSentCount"].ToString();

                            //if (dt.Rows[0]["WipDays"].ToString() != "0")
                            //{
                            //    //lbltailorAvgPer.Text = lbltailorAvgPer.Text + " (" + dt.Rows[0]["WipDays"].ToString() + "days)";
                            //    lbltailorAvgPer.Text = "";

                            //}
                            if (lbltailorAvgPer.Text != "" && lbltailorAvgPer.Text != "0")
                            {
                                //lbltailorAvgPer.Text = lbltailorAvgPer.Text + " (" + dt.Rows[0]["WipDays"].ToString() + "days)";
                                double Res = Math.Round(WipForAvgPer / Convert.ToDouble(lbltailorAvgPer.Text), 0, MidpointRounding.AwayFromZero);
                                if (Res.ToString() != "0.0" && Res.ToString() != "0")
                                {

                                    lbltailorAvgPer.Text = lbltailorAvgPer.Text + " (" + Res + "Days)";
                                }


                            }

                        }
                    }
                    if (hdnID.Value == "1001")//for avg row 
                    {
                        dt = objadmin.GetFitstailorMonthlyReport("1001", hdnStartdate.Value, hdnEnddate.Value, indexs);
                        if (dt.Rows.Count > 0)
                        {
                            //lbltailorCap.Text = dt.Rows[0]["TailorCapAvg"].ToString() == "0" ? "" : dt.Rows[0]["TailorCapAvg"].ToString();
                            //lbltailorPresent.Text = dt.Rows[0]["TailorPercentAvg"].ToString() == "0" ? "" : dt.Rows[0]["TailorPercentAvg"].ToString();
                            lbltailorSampleSent.Text = dt.Rows[0]["PendingSmapleSentCount"].ToString() == "0" ? "" : dt.Rows[0]["PendingSmapleSentCount"].ToString();
                            lbltailorSampleSent.Text = Convert.ToString(Convert.ToInt32(lbltailorSampleSent.Text) * 2);
                            lblSampleMade.Text = dt.Rows[0]["PendingSmapleMadeCount"].ToString() == "0" ? "" : dt.Rows[0]["PendingSmapleMadeCount"].ToString();
                            lblSampleMade.Visible = false;
                            if (dt.Rows[0]["WipDaySampleSent"].ToString() != "0")
                            {
                                lbltailorSampleSent.Text = lbltailorSampleSent.Text + " (" + dt.Rows[0]["WipDaySampleSent"].ToString() + " Days)";

                            }
                            if (dt.Rows[0]["WipDaySampleMade"].ToString() != "0")
                            {
                                lblSampleMade.Text = lblSampleMade.Text + " (" + dt.Rows[0]["WipDaySampleMade"].ToString() + " Days)";
                                lblSampleMade.Visible = false;

                            }
                            lbltailorAvgPer.Text = dt.Rows[0]["PendingSmapleSentCount"].ToString() == "0" ? "" : dt.Rows[0]["PendingSmapleSentCount"].ToString();

                            //if (dt.Rows[0]["WipDays"].ToString() != "0")
                            //{
                            //    //lbltailorAvgPer.Text = lbltailorAvgPer.Text + " (" + dt.Rows[0]["WipDays"].ToString() + "days)";
                            //    lbltailorAvgPer.Text = "";

                            //}
                            if (lbltailorAvgPer.Text != "" && lbltailorAvgPer.Text != "0")
                            {
                                //lbltailorAvgPer.Text = lbltailorAvgPer.Text + " (" + dt.Rows[0]["WipDays"].ToString() + "days)";
                                double Res = Math.Round(WipForAvgPer / Convert.ToDouble(lbltailorAvgPer.Text), 0, MidpointRounding.AwayFromZero);
                                if (Res.ToString() != "0.0" && Res.ToString() != "0")
                                {

                                    lbltailorAvgPer.Text = lbltailorAvgPer.Text + " (" + Res + "Days)";
                                }


                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.ToString();
            }
        }
        //protected void grdtopsummary_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        Label lblTopExfactoryLeadTimeDays = (Label)e.Row.FindControl("lblTopExfactoryLeadTimeDays");
        //        Label lblTopSent_ETA = (Label)e.Row.FindControl("lblTopSent_ETA");
        //        Label lblDiffBetweenNTopSentFor1Month = (Label)e.Row.FindControl("lblDiffBetweenNTopSentFor1Month");
        //        Label lblDiffBetweenNTopSentFor3Month = (Label)e.Row.FindControl("lblDiffBetweenNTopSentFor3Month");
        //        Label lblSealStyle = (Label)e.Row.FindControl("lblSealStyle");
        //        Label lblPatternSamplePending = (Label)e.Row.FindControl("lblPatternSamplePending");

        //        if (lblTopExfactoryLeadTimeDays != null && lblTopExfactoryLeadTimeDays.Text != "0")
        //        {
        //            lblTopExfactoryLeadTimeDays.Text = "(" + lblTopExfactoryLeadTimeDays.Text + ")";
        //        }
        //        if (lblDiffBetweenNTopSentFor1Month != null && lblDiffBetweenNTopSentFor1Month.Text != "0")
        //        {
        //            lblDiffBetweenNTopSentFor3Month.Text = "(" + lblDiffBetweenNTopSentFor3Month.Text + ")";
        //        }
        //        if (lblPatternSamplePending != null && lblPatternSamplePending.Text != "0")
        //        {
        //            lblPatternSamplePending.Text = "(" + lblPatternSamplePending.Text + ")";
        //        }
        //    }
        //}
        public static bool IsNumeric(object Expression)
        {
            double retNum;

            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        public void CreateExcel(DataSet ds, string Type)
        {
            try
            {
                //Directory.Delete(Constants.FITS_FOLDER_PATH);                
                string GlobalType_Weight;
                string ReportType = "";
                bool success = false;
                string GlobalType_Top = "";
                string GlobalType_Planning = "";
                string GlobalType_PO = "";
                string GlobalType_OnHold = "";
                string GlobalType_UpCommingDC_ForFabricSorted = "";
                string GlobalType_PatternStatus = "";
                string GlobalType_AM = "";
                string GlobalType_FitCommentPending = "";
                string GlobalType_PendingCost = "";
                string GlobalType = "";
                // string name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") +".xls";
                string pdfFilePath = "";

                string sourcePath = @"C:\";


                if (Type == "Restexcels")
                {
                    //---------------------Pending Cost Confirmation-------------------------------------
                    ////GlobalType_PendingCost = "Pending_Cost_Confirmation.xlsx";

                    ////if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_PendingCost)))
                    ////{
                    ////    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_PendingCost);

                    ////}

                    ////string targetPath_PendingCost = Constants.FITS_FOLDER_PATH + GlobalType_PendingCost;
                    ////string sourceFile_PendingCost = System.IO.Path.Combine(sourcePath, GlobalType_PendingCost);
                    ////string destFile_PendingCost = System.IO.Path.Combine(targetPath_PendingCost, GlobalType_PendingCost);
                    ////System.IO.File.Copy(sourceFile_PendingCost, targetPath_PendingCost, true);
                    //////---------------------- End -------------------------------------------------------

                    //////---------------------Rest of another file-------------------------------------
                    ////GlobalType_Top = "TOP Reports.xlsx";
                    ////if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_Top)))
                    ////{
                    ////    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_Top);

                    ////}

                    //////string targetPath = @"C:\Users\surendra\Documents\Live_Code\02_feb_2015_Sales_reports_cutting -Forcast- Released-6.0 - Copy\iKandi.Web\Uploads\Fits";
                    ////string targetPath_Top = Constants.FITS_FOLDER_PATH + GlobalType_Top;
                    ////string sourceFile_Top = System.IO.Path.Combine(sourcePath, GlobalType_Top);
                    ////string destFile_Top = System.IO.Path.Combine(targetPath_Top, GlobalType_Top);
                    ////System.IO.File.Copy(sourceFile_Top, targetPath_Top, true);
                    //////------------------------------------------------------------------------------

                    //////---------------------Rest of another file-------------------------------------
                    ////GlobalType_Planning = "Pattern_Sample_Pending.xlsx";
                    ////if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_Planning)))
                    ////{
                    ////    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_Planning);

                    ////}


                    //////string targetPath = @"C:\Users\surendra\Documents\Live_Code\02_feb_2015_Sales_reports_cutting -Forcast- Released-6.0 - Copy\iKandi.Web\Uploads\Fits";
                    ////string targetPath_Planning = Constants.FITS_FOLDER_PATH + GlobalType_Planning;
                    ////string sourceFile_Planning = System.IO.Path.Combine(sourcePath, GlobalType_Planning);
                    ////string destFile_Planning = System.IO.Path.Combine(targetPath_Planning, GlobalType_Planning);
                    ////System.IO.File.Copy(sourceFile_Planning, targetPath_Planning, true);



                    //////------------------------------------------------------------------------------
                    //////---------------------Rest of another file-------------------------------------
                    ////GlobalType_PO = "BuyerPOPendingReports.xlsx";
                    ////if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_PO)))
                    ////{
                    ////    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_PO);

                    ////}

                    //////string targetPath = @"C:\Users\surendra\Documents\Live_Code\02_feb_2015_Sales_reports_cutting -Forcast- Released-6.0 - Copy\iKandi.Web\Uploads\Fits";
                    ////string targetPath_PO = Constants.FITS_FOLDER_PATH + GlobalType_PO;
                    ////string sourceFile_PO = System.IO.Path.Combine(sourcePath, GlobalType_PO);
                    ////string destFile_PO = System.IO.Path.Combine(targetPath_PO, GlobalType_PO);
                    ////System.IO.File.Copy(sourceFile_PO, targetPath_PO, true);
                    //////--------------------------------OnHold Contract Status----------------------------------------------
                    ////GlobalType_OnHold = "PO_Onhold_report.xlsx";
                    ////if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_OnHold)))
                    ////{
                    ////    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_OnHold);

                    ////}

                    //////string targetPath = @"C:\Users\surendra\Documents\Live_Code\02_feb_2015_Sales_reports_cutting -Forcast- Released-6.0 - Copy\iKandi.Web\Uploads\Fits";
                    ////string targetPath_OnHold = Constants.FITS_FOLDER_PATH + GlobalType_OnHold;
                    ////string sourceFile_OnHold = System.IO.Path.Combine(sourcePath, GlobalType_OnHold);
                    ////string destFile_OnHold = System.IO.Path.Combine(targetPath_PO, GlobalType_OnHold);
                    ////System.IO.File.Copy(sourceFile_OnHold, targetPath_OnHold, true);
                    //////------------------------------------------------------------------------------
                    //////---------------------Rest of another file-------------------------------------
                    ////GlobalType_Weight = "Pending_Weight_Style_Reports.xlsx";
                    ////if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_Weight)))
                    ////{
                    ////    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_Weight);

                    ////}
                    ////GlobalType_UpCommingDC_ForFabricSorted = "FabriInhouseShortforUpcomingDC.xlsx";
                    ////if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_UpCommingDC_ForFabricSorted)))
                    ////{
                    ////    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_UpCommingDC_ForFabricSorted);

                    ////}
                    ////string targetPath_UpCommingDC_ForFabricSorted = Constants.FITS_FOLDER_PATH + GlobalType_UpCommingDC_ForFabricSorted;
                    ////string sourceFile_UpCommingDC_ForFabricSorted = System.IO.Path.Combine(sourcePath, GlobalType_UpCommingDC_ForFabricSorted);
                    ////string destFile_UpCommingDC_ForFabricSorted = System.IO.Path.Combine(targetPath_UpCommingDC_ForFabricSorted, GlobalType_UpCommingDC_ForFabricSorted);
                    ////System.IO.File.Copy(sourceFile_UpCommingDC_ForFabricSorted, targetPath_UpCommingDC_ForFabricSorted, true);

                    //////string targetPath = @"C:\Users\surendra\Documents\Live_Code\02_feb_2015_Sales_reports_cutting -Forcast- Released-6.0 - Copy\iKandi.Web\Uploads\Fits";
                    ////string targetPath_Weight = Constants.FITS_FOLDER_PATH + GlobalType_Weight;
                    ////string sourceFile_Weight = System.IO.Path.Combine(sourcePath, GlobalType_Weight);
                    ////string destFile_Weight = System.IO.Path.Combine(targetPath_Weight, GlobalType_Weight);
                    ////System.IO.File.Copy(sourceFile_Weight, targetPath_Weight, true);
                    //////------------------------------------------------------------------------------
                    ////GlobalType_PatternStatus = "PatternStatus.xlsx";
                    ////if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_PatternStatus)))
                    ////{
                    ////    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_PatternStatus);

                    ////}


                    //////string targetPath = @"C:\Users\surendra\Documents\Live_Code\02_feb_2015_Sales_reports_cutting -Forcast- Released-6.0 - Copy\iKandi.Web\Uploads\Fits";
                    ////string targetPath_PatternStatus = Constants.FITS_FOLDER_PATH + GlobalType_PatternStatus;
                    ////string sourceFile_PatternStatus = System.IO.Path.Combine(sourcePath, GlobalType_PatternStatus);
                    ////string destFile_PatternStatus = System.IO.Path.Combine(targetPath_PatternStatus, GlobalType_PatternStatus);
                    ////System.IO.File.Copy(sourceFile_PatternStatus, targetPath_PatternStatus, true);

                    //////--------------------------------------------AM----------------------------------
                    ////GlobalType_AM = "AM_and_Material_Performance.xlsx";
                    ////if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_AM)))
                    ////{
                    ////    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_AM);

                    ////}


                    //////string targetPath = @"C:\Users\surendra\Documents\Live_Code\02_feb_2015_Sales_reports_cutting -Forcast- Released-6.0 - Copy\iKandi.Web\Uploads\Fits";
                    ////string targetPath_AM = Constants.FITS_FOLDER_PATH + GlobalType_AM;
                    ////string sourceFile_AM = System.IO.Path.Combine(sourcePath, GlobalType_AM);
                    ////string destFile_AM = System.IO.Path.Combine(targetPath_AM, GlobalType_AM);
                    ////System.IO.File.Copy(sourceFile_AM, targetPath_AM, true);
                    //////-------------------------------------------end----------------------------------
                    //////---------------------Code Added by bharat on 19-july for Fit Comment Report Excel-------------------------------------
                    ////GlobalType_FitCommentPending = "FitComment_Pending.xlsx";
                    ////if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType_FitCommentPending)))
                    ////{
                    ////    System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType_FitCommentPending);

                    ////}

                    ////string targetPath_Fit = Constants.FITS_FOLDER_PATH + GlobalType_FitCommentPending;
                    ////string sourceFile_Fit = System.IO.Path.Combine(sourcePath, GlobalType_FitCommentPending);
                    ////string destFile_Fit = System.IO.Path.Combine(targetPath_Fit, GlobalType_FitCommentPending);
                    ////System.IO.File.Copy(sourceFile_Fit, targetPath_Fit, true);

                    //======================== Rest section

                    //bool success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("HandOver-PreOrder"), GlobalType);

                    ////ReportType = "Pending weight style";
                    ////pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Weight);
                    ////success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("Pending weight style"), GlobalType_Weight);

                    ////ReportType = "TOP Pending";
                    //////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    ////string pdfFilePath_Top = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Top);

                    ////success = controller.GenerateFitsReportExcel(pdfFilePath_Top, ReportType, ds = objadmin.GetFitsReport("TOPPEDNING"), GlobalType_Top);

                    ////ReportType = "TOP Approval Pending";
                    ////// name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    ////pdfFilePath_Top = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Top);

                    ////success = controller.GenerateFitsReportExcel(pdfFilePath_Top, ReportType, ds = objadmin.GetFitsReport("TOPAPPROVELPENDING"), GlobalType_Top);

                    ////ReportType = "TOP_Approved_MDA_Pending_Reports";
                    //////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    ////pdfFilePath_Top = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Top);

                    ////success = controller.GenerateFitsReportExcel(pdfFilePath_Top, ReportType, ds = objadmin.GetFitsReport("TOP_Approved_MDA_Pending_Reports"), pdfFilePath_Top);

                    //////ReportType = "TOP_Approved_Fabric_BIH_Reports";
                    ////////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    //////pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);

                    //////success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("TOP_Approved_Fabric_BIH_Reports"), GlobalType);

                    ////ReportType = "Pattern_Sample_Pending";
                    //////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    ////string pdfFilePath_Planning = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Planning);

                    ////success = controller.GenerateFitsReportExcel(pdfFilePath_Planning, ReportType, ds = objadmin.GetFitsReport("Pattern_Sample_Pending"), GlobalType_Planning);

                    //////ReportType = "Production_Planning";
                    ////////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    //////pdfFilePath_Planning = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_Planning);

                    //////success = controller.GenerateFitsReportExcel(pdfFilePath_Planning, ReportType, ds = objadmin.GetFitsReport("Production_Planning"), GlobalType_Planning);


                    ////ReportType = "Buyer_POPending";
                    //////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    ////string pdfFilePath_PO = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_PO);

                    ////success = controller.GenerateFitsReportExcel(pdfFilePath_PO, ReportType, ds = objadmin.GetFitsReport("Buyer_POPending"), GlobalType_PO);

                    //////--------------------------------OnHold Reports-------------------------------------------

                    ////ReportType = "Buyer_OnHold_Pending";
                    //////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    ////string pdfFilePath_OnHold = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_OnHold);

                    ////success = controller.GenerateFitsReportExcel(pdfFilePath_OnHold, ReportType, ds = objadmin.GetFitsReport("Buyer_OnHold_Pending"), GlobalType_OnHold);

                    //////-------------------------------End---------------------------------------------------------

                    ////GlobalType_UpCommingDC_ForFabricSorted = "FabriInhouseShortforUpcomingDC";
                    //////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    ////string pdfFilePath_UpCommingDC_ForFabricSorted = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_UpCommingDC_ForFabricSorted);
                    ////success = controller.GenerateFitsReportExcel(pdfFilePath_UpCommingDC_ForFabricSorted, "FabriInhouseShortforUpcomingDC", ds = objadmin.GetFitsReport("FabriInhouseShortforUpcomingDC"), GlobalType_UpCommingDC_ForFabricSorted);

                    ////ReportType = "PatternStatus";
                    //////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    ////string pdfFilePath_PatternStatus = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_PatternStatus);

                    ////success = controller.GenerateFitsReportExcel(pdfFilePath_PatternStatus, ReportType, ds = objadmin.GetFitsReport("PatternStatus"), GlobalType_PatternStatus);

                    //----------------AM Performance-----------------------------

                 ////   ReportType = "AMPerformance_STC";
                    //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    string pdfFilePath_AM = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_AM);

                    ////success = controller.GenerateFitsReportExcel(pdfFilePath_AM, ReportType, ds = objadmin.GetFitsReport("AMPerformance_STC"), GlobalType_AM);
                    //------------------------------------------------------------------------------------
                    ////ReportType = "AMPerformance_BIH";
                    //////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    ////pdfFilePath_AM = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_AM);
                    ////success = controller.GenerateFitsReportExcel(pdfFilePath_AM, ReportType, ds = objadmin.GetFitsReport("AMPerformance_BIH"), GlobalType_AM);

                    //-------------Code Added By Bharat-----------------------------------------------------------------------
                    ReportType = "AMPerformance_Acc_BIH";
                    //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    pdfFilePath_AM = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_AM);
                    success = controller.GenerateFitsReportExcel(pdfFilePath_AM, ReportType, ds = objadmin.GetFitsReport("AMPerformance_Acc_BIH"), GlobalType_AM);



                    ////ReportType = "FitCommentes_Pending";
                    //////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    ////string pdfFilePath_Fit = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_FitCommentPending);

                    ////success = controller.GenerateFitsReportExcel(pdfFilePath_Fit, ReportType, ds = objadmin.GetFitsReport("FitCommentes_Pending"), GlobalType_FitCommentPending);

                    //////--------------Pending Cost Confirmation---------------------------------------------------------
                    ////ReportType = "Pending_Cost_Confirmation";
                    ////string pdfFilePath_PendingCost = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType_PendingCost);
                    ////success = controller.GenerateFitsReportExcel(pdfFilePath_PendingCost, ReportType, ds = objadmin.GetFitsReport("Pending_Cost_Confirmation"), GlobalType_PendingCost);
                    // -----------------------------------------------End----------------------------------------------

                }
                //-------------------------------------------end----------------------------------
                if (Type == "FitsSampling")
                {

                    GlobalType = "FITS and Sampling Reports.xlsx";

                    if ((System.IO.File.Exists(Constants.FITS_FOLDER_PATH + GlobalType)))
                    {
                        System.IO.File.Delete(Constants.FITS_FOLDER_PATH + GlobalType);

                    }

                    //string targetPath = @"C:\Users\surendra\Documents\Live_Code\02_feb_2015_Sales_reports_cutting -Forcast- Released-6.0 - Copy\iKandi.Web\Uploads\Fits";
                    string targetPath = Constants.FITS_FOLDER_PATH + GlobalType;
                    string sourceFile = System.IO.Path.Combine(sourcePath, GlobalType);
                    string destFile = System.IO.Path.Combine(targetPath, GlobalType);
                    System.IO.File.Copy(sourceFile, targetPath, true);


                    ReportType = "HandOver-PreOrder";
                    success = false;
                    // string name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") +".xls";
                    pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);


                    ReportType = "HandOver-PostOrder";
                    //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);
                    success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("HandOver-PostOrder"), GlobalType);

                    //ReportType = "PatternReady-PreOrder";
                    ////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    //pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);
                    //success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("PatternReady-PreOrder"), GlobalType);

                    ReportType = "PatternReady-PostOrder";
                    //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") +".xls";
                    pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);

                    success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("PatternReady-PostOrder"), GlobalType);

                    //ReportType = "SampleSent-PreOrder";
                    ////name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    //pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);

                    //success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("SampleSent-PreOrder"), GlobalType);

                    ReportType = "SampleSent-PostOrder";
                    //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);

                    success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("SampleSent-PostOrder"), GlobalType);

                    //ReportType = "FitCommentesUpload-PostOrder";
                    //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    //pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, name);

                    //success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("FitCommentesUpload-PostOrder"));

                    ReportType = "COSTING BIPL";
                    //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);
                    success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("COSTING BIPL"), GlobalType);

                    ReportType = "PriceQuoted-BIPL";
                    //name = ReportType + "-" + DateTime.Now.ToString("dd MMM yyy") + ".xls";
                    pdfFilePath = Path.Combine(Constants.FITS_FOLDER_PATH, GlobalType);

                    success = controller.GenerateFitsReportExcel(pdfFilePath, ReportType, ds = objadmin.GetFitsReport("PriceQuoted-BIPL"), GlobalType);

                }


            }
            catch (Exception ex)
            {
                string error = ex.ToString();

            }

        }

    }

}