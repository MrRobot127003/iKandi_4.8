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

namespace iKandi.Web.UserControls.Reports
{
    public partial class QcFualtSummaryReport : BaseUserControl
    {
        AdminController oAdminController = new AdminController();
        DataSet dtUnitIn = new DataSet();
        
        protected void Page_Load(object sender, EventArgs e)
        {

     // dtUnitIn = oAdminController.GetFactorynames(0, "InHouseUnit");
            BindGrd();
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
        public void BindGrd()
        {

            iKandi.Common.QualityControl qualityControl = new iKandi.Common.QualityControl();
            qualityControl = this.QualityControllerInstance.GetQcFualtSummary();

            if (qualityControl.Process != null && qualityControl.Process.Count > 0)
            {
                grdqcfualtsummary.DataSource = qualityControl.Process;
                grdqcfualtsummary.DataBind();

                grdqcfualtsummary.HeaderRow.Cells[0].Visible = false;
                grdqcfualtsummary.HeaderRow.Cells[1].CssClass = "center";
                grdqcfualtsummary.HeaderRow.Cells[2].CssClass = "center";
                grdqcfualtsummary.HeaderRow.Cells[3].CssClass = "center";
                grdqcfualtsummary.HeaderRow.Cells[4].CssClass = "center";
            }

        }
        protected void grdqcfualtsummary_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //int @inhouseUniutCount = 0;
                //if (dtUnitIn.Tables[0].Rows.Count > 0)
                //{
                //    @inhouseUniutCount = dtUnitIn.Tables[0].Rows.Count;
                //}

                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass2");

                TableCell HeaderCell = new TableCell();
                HeaderCell = new TableCell();
                HeaderCell.Text = "Factory Specific QC Faults Summary Report";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 5;
                HeaderCell.Attributes.Add("style", "text-align:center !important");
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Name";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 2;
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Attributes.Add("style", "border-spacing:0px;text-align:center !important");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "C-47";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 1;
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Attributes.Add("style", "border-spacing:0px;text-align:center !important");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "C-45-46";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 1;
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Attributes.Add("style", "border-spacing:0px;text-align:center !important");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "D 169";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 1;
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Attributes.Add("style", "border-spacing:0px;text-align:center !important");
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "BIPL";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 1;
                HeaderCell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#999999");
                HeaderCell.Attributes.Add("style", "border-spacing:0px;text-align:center !important");
                headerRow2.Cells.Add(HeaderCell);

                Label lblQuaterSumC47 = (Label)e.Row.FindControl("lblQuaterSumC47");
                Label lblQuaterC47 = (Label)e.Row.FindControl("lblQuaterC47");
                Label lblPresentC47Month = (Label)e.Row.FindControl("lblPresentC47Month");

                Label lblQuaterSumC45 = (Label)e.Row.FindControl("lblQuaterSumC45");
                Label lblQuaterC45 = (Label)e.Row.FindControl("lblQuaterC45");
                Label lblPresentC45Month = (Label)e.Row.FindControl("lblPresentC45Month");

                Label lblQuaterSumD169 = (Label)e.Row.FindControl("lblQuaterSumD169");
                Label lblQuaterD169 = (Label)e.Row.FindControl("lblQuaterD169");
                Label lblPresentD169Month = (Label)e.Row.FindControl("lblPresentD169Month");


                Label lblQuaterSumBipl = (Label)e.Row.FindControl("lblQuaterSumBipl");
                Label lblQuaterBipl = (Label)e.Row.FindControl("lblQuaterBipl");
                Label lblPresentBiplMonth = (Label)e.Row.FindControl("lblPresentBiplMonth");
                if (DateTime.Now.Month.ToString() == "1" || DateTime.Now.Month.ToString() == "4" || DateTime.Now.Month.ToString() == "7" || DateTime.Now.Month.ToString() == "10")
                {
                    HtmlTableCell thQuaterc47 = e.Row.FindControl("thQuaterc47") as HtmlTableCell;
                    thQuaterc47.Visible = false;
                    HtmlTableCell thQuaterc45 = e.Row.FindControl("thQuaterc45") as HtmlTableCell;
                    thQuaterc45.Visible = false;
                    HtmlTableCell thQuaterD169 = e.Row.FindControl("thQuaterD169") as HtmlTableCell;
                    thQuaterD169.Visible = false;
                    HtmlTableCell thQuatercBIPL = e.Row.FindControl("thQuatercBIPL") as HtmlTableCell;
                    thQuatercBIPL.Visible = false;
                }
                
                lblPresentC47Month.Text = System.DateTime.Now.ToString("MMM");
                lblPresentC45Month.Text = System.DateTime.Now.ToString("MMM");
                lblPresentD169Month.Text = System.DateTime.Now.ToString("MMM");
                lblPresentBiplMonth.Text = System.DateTime.Now.ToString("MMM");
               

                DateTime dtnow = DateTime.Now;
                int Quarter = GetQuarter(dtnow);
                //string Quater_sum = "";
                //string Quarter1 = "";

                if (Quarter == 1)
                {
                    lblQuaterSumC47.Text = "Last Year";
                    lblQuaterC47.Text = "Q1";
                    lblQuaterSumC45.Text = "Last Year";
                    lblQuaterC45.Text = "Q1";
                    lblQuaterSumD169.Text = "Last Year";
                    lblQuaterD169.Text = "Q1";
                    lblQuaterSumBipl.Text = "Last Year";
                    lblQuaterBipl.Text = "Q1";
                }
                else if (Quarter == 2)
                {
                    lblQuaterSumC47.Text = "Q1";
                    lblQuaterC47.Text = "Q2";
                    lblQuaterSumC45.Text = "Q1";
                    lblQuaterC45.Text = "Q2";

                    lblQuaterSumD169.Text = "Q1";
                    lblQuaterD169.Text = "Q2";

                    lblQuaterSumBipl.Text = "Q1";
                    lblQuaterBipl.Text = "Q2";
                }
                else if (Quarter == 3)
                {
                    lblQuaterSumC47.Text = "Q1 & Q2";
                    lblQuaterC47.Text = "Q3";
                    lblQuaterSumC45.Text = "Q1 & Q2";
                    lblQuaterC45.Text = "Q3";

                    lblQuaterSumD169.Text = "Q1 & Q2";
                    lblQuaterD169.Text = "Q3";

                    lblQuaterSumBipl.Text = "Q1 & Q2";
                    lblQuaterBipl.Text = "Q3";
                }
                else if (Quarter == 4)
                {
                    lblQuaterSumC47.Text = "Q1 & Q2 & Q3";
                    lblQuaterC47.Text = "Q4";
                    lblQuaterSumC45.Text = "Q1 & Q2 & Q3";
                    lblQuaterC45.Text = "Q4";

                    lblQuaterSumD169.Text = "Q1 & Q2 & Q3";
                    lblQuaterD169.Text = "Q4";

                    lblQuaterSumBipl.Text = "Q1 & Q2 & Q3";
                    lblQuaterBipl.Text = "Q4";
                }

                grdqcfualtsummary.Controls[0].Controls.AddAt(0, headerRow2);
                grdqcfualtsummary.Controls[0].Controls.AddAt(0, headerRow1);

                //lblPresentC47Month.Visible = false;
                //lblPresentC45Month.Visible = false;
                //lblPresentBiplMonth.Visible = false;

                //lblPresentC47Month.Parent.Controls[3].Visible = false;
                //lblPresentC45Month.Parent.Controls[3].Visible = false;
                //lblPresentBiplMonth.Parent.Controls[3].Visible = false;
               
              
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                //e.Row.Cells[0].ColumnSpan = 4;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[0].Visible = false;
                //e.Row.Cells[5].Visible = false;
                //e.Row.Cells[6].Visible = false;
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                Label lblQaProcessId = (Label)e.Row.FindControl("lblQaProcessId");
                HiddenField hdnQaProcessId = (HiddenField)e.Row.FindControl("hdnQaProcessId");

                Label lblQuarterSum_C47 = (Label)e.Row.FindControl("lblQuarterSum_C47");
                Label lblQuarter_C47 = (Label)e.Row.FindControl("lblQuarter_C47");
                Label lbl1monthC47 = (Label)e.Row.FindControl("lbl1monthC47");

                Label lblQuarterSum_C45 = (Label)e.Row.FindControl("lblQuarterSum_C45");
                Label lblQuarter_C45 = (Label)e.Row.FindControl("lblQuarter_C45");
                Label lbl1monthC45 = (Label)e.Row.FindControl("lbl1monthC45");

                Label lblQuarterSum_D169 = (Label)e.Row.FindControl("lblQuarterSum_D169");
                Label lblQuarter_D169 = (Label)e.Row.FindControl("lblQuarter_D169");
                Label lbl1monthD169 = (Label)e.Row.FindControl("lbl1monthD169");

                Label lblQuarterSum_BIPL = (Label)e.Row.FindControl("lblQuarterSum_BIPL");
                Label lblQuarter_BIPL = (Label)e.Row.FindControl("lblQuarter_BIPL");
                Label lbl1monthBIPL = (Label)e.Row.FindControl("lbl1monthBIPL");

                HtmlTableCell tdQuarterSum_BIPL = (HtmlTableCell)e.Row.FindControl("tdQuarterSum_BIPL");
                HtmlTableCell tdQuarter_BIPL = (HtmlTableCell)e.Row.FindControl("tdQuarter_BIPL");
                HtmlTableCell td1monthBIPL = (HtmlTableCell)e.Row.FindControl("td1monthBIPL");

                HtmlTableCell tdQuarterSum_C45 = (HtmlTableCell)e.Row.FindControl("tdQuarterSum_C45");
                HtmlTableCell tdQuarter_C45 = (HtmlTableCell)e.Row.FindControl("tdQuarter_C45");
                HtmlTableCell td1monthC45 = (HtmlTableCell)e.Row.FindControl("td1monthC45");

                HtmlTableCell tdQuarterSum_C47 = (HtmlTableCell)e.Row.FindControl("tdQuarterSum_C47");
                HtmlTableCell tdQuarter_C47 = (HtmlTableCell)e.Row.FindControl("tdQuarter_C47");
                HtmlTableCell td1monthC47 = (HtmlTableCell)e.Row.FindControl("td1monthC47");

                HtmlTableCell tdQuarterSum_D169 = (HtmlTableCell)e.Row.FindControl("tdQuarterSum_D169");
                HtmlTableCell tdQuarter_D169 = (HtmlTableCell)e.Row.FindControl("tdQuarter_D169");
                HtmlTableCell td1monthD169 = (HtmlTableCell)e.Row.FindControl("td1monthD169");
                tdQuarterSum_D169.Attributes.Add("class","sum_col_d169");
                tdQuarter_D169.Attributes.Add("class", "Colwidth_d169");
                td1monthD169.Attributes.Add("class", "Colwidth_d169");

                if (DateTime.Now.Month.ToString() == "1" || DateTime.Now.Month.ToString() == "4" || DateTime.Now.Month.ToString() == "7" || DateTime.Now.Month.ToString() == "10")
                {
                    tdQuarter_C45.Visible = false;
                    tdQuarter_BIPL.Visible = false;
                    tdQuarter_C47.Visible = false;
                    tdQuarter_D169.Visible = false;
                }

                if (lblQaProcessId.Text == "Total CQD Faults")
                {
                    //============================C47==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(3, "TOTALCQD", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        //e.Row.BackColor = System.Drawing.Color.Yellow;
                        e.Row.CssClass = "font-size";
                        e.Row.Font.Bold = true;
                        e.Row.Cells[0].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[0].Font.Bold = false;
                        e.Row.Cells[0].Attributes.Add("style", "text-align: left !important;");
                       
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 12)
                        {
                            lbl1monthC47.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthC47.ForeColor = Color.Red;
                            lbl1monthC47.Font.Bold = true;

                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthC47.Style["background"] = "red";
                          
                        }
                        else
                        {
                            lbl1monthC47.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            //lbl1monthC47.ForeColor = Color.Yellow;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                            if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 10 && Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 13)
                            {
                                //td1monthC47.Style["background"] = "orange";
                                lbl1monthC47.ForeColor = Color.Black;
                            }
                            else
                            {
                               // td1monthC47.Style["background"] = "green";
                                lbl1monthC47.ForeColor = Color.Green;
                            }
                        }
                      

                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 12)
                        {
                            lblQuarterSum_C47.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_C47.ForeColor = Color.Red;
                            lblQuarterSum_C47.Font.Bold = true;
                          //  tdQuarterSum_C47.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_C47.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                           // lblQuarterSum_C47.ForeColor = Color.Yellow;
                            if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 13)
                            {
                                //tdQuarterSum_C47.Style["background"] = "orange";
                                lblQuarterSum_C47.ForeColor = Color.Black;
                            }
                            else
                            {
                              //  tdQuarterSum_C47.Style["background"] = "green";
                                lblQuarterSum_C47.ForeColor = Color.Green;
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 12)
                            {
                                lblQuarter_C47.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_C47.ForeColor = Color.Red;
                                lblQuarter_C47.Font.Bold = true;
                                //tdQuarter_C47.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_C47.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                               // lblQuarter_C47.ForeColor = Color.Yellow;
                                if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter"]) < 13)
                                {
                                   // tdQuarter_C47.Style["background"] = "orange";
                                    lblQuarter_C47.ForeColor = Color.Black;
                                }
                                else
                                {
                                   // tdQuarter_C47.Style["background"] = "green";
                                    lblQuarter_C47.ForeColor = Color.Green;
                                }
                            }
                        }
                    }
                    //============================C45C46==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(11, "TOTALCQD", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        e.Row.CssClass = "font-size";
                        //e.Row.BackColor = System.Drawing.Color.Yellow;
                        e.Row.Font.Bold = true;
                        e.Row.Cells[0].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[0].Font.Bold = false;
                        //lbl1monthC45C46.Text =  dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString();
                        //lbl3monthC45C46.Text =  dt.Rows[0]["threeMonths"].ToString() == "0" ? "" : dt.Rows[0]["threeMonths"].ToString();
                        //lbl1yearC45C46.Text =  dt.Rows[0]["OneYear"].ToString() == "0" ? "" : dt.Rows[0]["OneYear"].ToString() + '%';
                       
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 12)
                        {
                            lbl1monthC45.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthC45.ForeColor = Color.Red;
                            lbl1monthC45.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthC45.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthC45.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                           // lbl1monthC45.ForeColor = Color.Yellow;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                            if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 10 && Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 13)
                            {
                              //  td1monthC45.Style["background"] = "orange";
                                lbl1monthC45.ForeColor = Color.Black;
                            }
                            else
                            {
                                //td1monthC45.Style["background"] = "green";
                                lbl1monthC45.ForeColor = Color.Green;
                            }
                        }
                        

                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 12)
                        {
                            lblQuarterSum_C45.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_C45.ForeColor = Color.Red;
                            lblQuarterSum_C45.Font.Bold = true;
                           // tdQuarterSum_C45.Style["background"] = "red";
                           
                        }
                        else
                        {
                            lblQuarterSum_C45.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                           // lblQuarterSum_C45.ForeColor = Color.Yellow;
                            if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 13)
                            {
                              //  tdQuarterSum_C45.Style["background"] = "orange";
                                lblQuarterSum_C45.ForeColor = Color.Black;
                            }
                            else
                            {
                               // tdQuarterSum_C45.Style["background"] = "green";
                                lblQuarterSum_C45.ForeColor = Color.Green;
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 12)
                            {
                                lblQuarter_C45.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                               lblQuarter_C45.ForeColor = Color.Red;
                               lblQuarter_C45.Font.Bold = true;
                              //  tdQuarter_C45.Style["background"] = "red";
                               
                            }
                            else
                            {
                                lblQuarter_C45.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                               // lblQuarter_C45.ForeColor = Color.Yellow;
                                if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter"]) < 13)
                                {
                                   // tdQuarter_C45.Style["background"] = "orange";
                                    lblQuarter_C45.ForeColor = Color.Black;
                                }
                                else
                                {
                                   // tdQuarter_C45.Style["background"] = "green";
                                    lblQuarter_C45.ForeColor = Color.Green;
                                }
                            }
                        }
                    }
                    //============================D169==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(96, "TOTALCQD", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        e.Row.CssClass = "font-size";
                        //e.Row.BackColor = System.Drawing.Color.Yellow;
                        e.Row.Font.Bold = true;
                        e.Row.Cells[0].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[0].Font.Bold = false;
                        //lbl1monthC45C46.Text =  dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString();
                        //lbl3monthC45C46.Text =  dt.Rows[0]["threeMonths"].ToString() == "0" ? "" : dt.Rows[0]["threeMonths"].ToString();
                        //lbl1yearC45C46.Text =  dt.Rows[0]["OneYear"].ToString() == "0" ? "" : dt.Rows[0]["OneYear"].ToString() + '%';

                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 12)
                        {
                            lbl1monthD169.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthD169.ForeColor = Color.Red;
                            lbl1monthD169.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                          //  td1monthD169.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthD169.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                           // lbl1monthD169.ForeColor = Color.Yellow;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                            if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 10 && Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 13)
                            {
                              //  td1monthD169.Style["background"] = "orange";
                                lbl1monthD169.ForeColor = Color.Black;
                            }
                            else
                            {
                               // td1monthD169.Style["background"] = "green";
                                lbl1monthD169.ForeColor = Color.Green;
                            }
                        }


                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 12)
                        {
                            lblQuarterSum_D169.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_D169.ForeColor = Color.Red;
                            lblQuarterSum_D169.Font.Bold = true;
                           // tdQuarterSum_D169.Style["background"] = "red";
                          
                        }
                        else
                        {
                            lblQuarterSum_D169.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            //lblQuarterSum_D169.ForeColor = Color.Yellow;
                            if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 13)
                            {
                                //tdQuarterSum_D169.Style["background"] = "orange";
                                lblQuarterSum_D169.ForeColor = Color.Black;
                            }
                            else
                            {
                                //tdQuarterSum_D169.Style["background"] = "green";
                                lblQuarterSum_D169.ForeColor = Color.Green;
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 12)
                            {
                                lblQuarter_D169.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_D169.ForeColor = Color.Red;
                                lblQuarter_D169.Font.Bold = true;
                               // tdQuarter_D169.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_D169.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                //lblQuarter_D169.ForeColor = Color.Yellow;
                                if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter"]) < 13)
                                {
                                    //tdQuarter_D169.Style["background"] = "orange";
                                    lblQuarter_D169.ForeColor = Color.Black;
                                }
                                else
                                {
                                    //tdQuarter_D169.Style["background"] = "green";
                                    lblQuarter_D169.ForeColor = Color.Green;
                                }
                            }
                        }
                    }
                    //============================BIPL==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(0, "TOTALCQD", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        e.Row.CssClass = "font-size";
                        //e.Row.BackColor = System.Drawing.Color.Yellow;
                        e.Row.Font.Bold = true;
                        e.Row.Cells[0].BackColor = System.Drawing.Color.Yellow;

                       
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 12)
                        {
                            lbl1monthBIPL.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthBIPL.ForeColor = Color.Red;
                            lbl1monthBIPL.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthBIPL.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthBIPL.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            //lbl1monthBIPL.ForeColor = Color.Yellow;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                            if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 10 && Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 13)
                            {
                                //td1monthBIPL.Style["background"] = "orange";
                                lbl1monthBIPL.ForeColor = Color.Black;
                            }
                            else
                            {
                               // td1monthBIPL.Style["background"] = "green";
                                lbl1monthBIPL.ForeColor = Color.Green;
                            }
                        }
                      

                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 12)
                        {
                            lblQuarterSum_BIPL.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_BIPL.ForeColor = Color.Red;
                            lblQuarterSum_BIPL.Font.Bold = true;
                           // tdQuarterSum_BIPL.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_BIPL.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                           // lblQuarterSum_BIPL.ForeColor = Color.Yellow;
                            if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 13)
                            {
                                //tdQuarterSum_BIPL.Style["background"] = "orange";
                                lblQuarterSum_BIPL.ForeColor = Color.Black;
                            }
                            else
                            {
                                //tdQuarterSum_BIPL.Style["background"] = "green";
                                lblQuarterSum_BIPL.ForeColor = Color.Green;
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 12)
                            {
                                lblQuarter_BIPL.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_BIPL.ForeColor = Color.Red;
                                lblQuarter_BIPL.Font.Bold = true;
                               // tdQuarter_BIPL.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_BIPL.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                //lblQuarter_BIPL.ForeColor = Color.Yellow;
                                if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter"]) < 13)
                                {
                                   // tdQuarter_BIPL.Style["background"] = "orange";
                                    lblQuarter_BIPL.ForeColor = Color.Black;
                                }
                                else
                                {
                                   // tdQuarter_BIPL.Style["background"] = "green";
                                    lblQuarter_BIPL.ForeColor = Color.Green;
                                }
                            }
                        }
                    }
                }
                if (lblQaProcessId.Text == "Total QC Faults")
                {
                    //============================C45==============================================//

                    ds = this.QualityControllerInstance.GetQcFualtPer(3, "TOTALQC", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        //e.Row.BackColor = System.Drawing.Color.Yellow;
                        e.Row.CssClass = "font-size";
                        e.Row.Font.Bold = true;
                        e.Row.Cells[0].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[0].Font.Bold = false;

                       
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 12)
                        {
                            lbl1monthC47.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthC47.ForeColor = Color.Red;
                            lbl1monthC47.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthC47.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthC47.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                           // lbl1monthC47.ForeColor = Color.Yellow;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                            if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 10 && Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 13)
                            {
                                //td1monthC47.Style["background"] = "orange";
                                lbl1monthC47.ForeColor = Color.Black;
                            }
                            else
                            {
                                //td1monthC47.Style["background"] = "green";
                                lbl1monthC47.ForeColor = Color.Green;
                            }
                        }
                        
                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 12)
                        {
                            lblQuarterSum_C47.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_C47.ForeColor = Color.Red;
                            lblQuarterSum_C47.Font.Bold = true;
                           // tdQuarterSum_C47.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_C47.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                           // lblQuarterSum_C47.ForeColor = Color.Yellow;
                            if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 13)
                            {
                               // tdQuarterSum_C47.Style["background"] = "orange";
                                lblQuarterSum_C47.ForeColor = Color.Black;
                            }
                            else
                            {
                               // tdQuarterSum_C47.Style["background"] = "green";
                                lblQuarterSum_C47.ForeColor = Color.Green;
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 12)
                            {
                                lblQuarter_C47.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_C47.ForeColor = Color.Red;
                                lblQuarter_C47.Font.Bold = true;
                                //tdQuarter_C47.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_C47.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                              //  lblQuarter_C47.ForeColor = Color.Yellow;
                                if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter"]) < 13)
                                {
                                    //tdQuarter_C47.Style["background"] = "orange";
                                    lblQuarter_C47.ForeColor = Color.Black;
                                }
                                else
                                {
                                   // tdQuarter_C47.Style["background"] = "green";
                                    lblQuarter_C47.ForeColor = Color.Green;
                                }
                            }
                        }
                    }
                    //============================C45C46==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(11, "TOTALQC", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        e.Row.CssClass = "font-size";
                        //e.Row.BackColor = System.Drawing.Color.Yellow;
                        e.Row.Font.Bold = true;
                        e.Row.Cells[0].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[0].Font.Bold = false;
                        //lbl1monthC45C46.Text =  dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString();
                        //lbl3monthC45C46.Text =  dt.Rows[0]["threeMonths"].ToString() == "0" ? "" : dt.Rows[0]["threeMonths"].ToString();
                        //lbl1yearC45C46.Text =  dt.Rows[0]["OneYear"].ToString() == "0" ? "" : dt.Rows[0]["OneYear"].ToString() + '%';
                       
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 12)
                        {
                            lbl1monthC45.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthC45.ForeColor = Color.Red;
                            lbl1monthC45.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthC45.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthC45.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                           // lbl1monthC45.ForeColor = Color.Yellow;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                            if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 10 && Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 13)
                            {
                                //td1monthC45.Style["background"] = "orange";
                                lbl1monthC45.ForeColor = Color.Black;
                            }
                            else
                            {
                                //td1monthC45.Style["background"] = "green";
                                lbl1monthC45.ForeColor = Color.Green;
                            }
                        }
                       
                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 12)
                        {
                            lblQuarterSum_C45.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_C45.ForeColor = Color.Red;
                            lblQuarterSum_C45.Font.Bold = true;
                           // tdQuarterSum_C45.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_C45.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                          //  lblQuarterSum_C45.ForeColor = Color.Yellow;
                            if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 13)
                            {
                               // tdQuarterSum_C45.Style["background"] = "orange";
                                lblQuarterSum_C45.ForeColor = Color.Black;
                            }
                            else
                            {
                                //tdQuarterSum_C45.Style["background"] = "green";
                                lblQuarterSum_C45.ForeColor = Color.Green;
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 12)
                            {
                                lblQuarter_C45.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_C45.ForeColor = Color.Red;
                                lblQuarter_C45.Font.Bold = true;
                                //tdQuarter_C45.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_C45.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                               // lblQuarter_C45.ForeColor = Color.Yellow;
                                if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter"]) < 13)
                                {
                                    //tdQuarter_C45.Style["background"] = "orange";
                                    lblQuarter_C45.ForeColor = Color.Black;
                                }
                                else
                                {
                                    //tdQuarter_C45.Style["background"] = "green";
                                    lblQuarter_C45.ForeColor = Color.Green;
                                }
                            }
                        }
                    }
                    //============================D169==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(96, "TOTALQC", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        e.Row.CssClass = "font-size";
                        //e.Row.BackColor = System.Drawing.Color.Yellow;
                        e.Row.Font.Bold = true;
                        e.Row.Cells[0].BackColor = System.Drawing.Color.Yellow;
                        e.Row.Cells[0].Font.Bold = false;
                        //lbl1monthC45C46.Text =  dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString();
                        //lbl3monthC45C46.Text =  dt.Rows[0]["threeMonths"].ToString() == "0" ? "" : dt.Rows[0]["threeMonths"].ToString();
                        //lbl1yearC45C46.Text =  dt.Rows[0]["OneYear"].ToString() == "0" ? "" : dt.Rows[0]["OneYear"].ToString() + '%';

                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 12)
                        {
                            lbl1monthD169.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthD169.ForeColor = Color.Red;
                            lbl1monthD169.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthD169.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthD169.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                           // lbl1monthD169.ForeColor = Color.Yellow;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                            if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 10 && Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 13)
                            {
                                //td1monthD169.Style["background"] = "orange";
                                lbl1monthD169.ForeColor = Color.Black;
                            }
                            else
                            {
                                //td1monthD169.Style["background"] = "green";
                                lbl1monthD169.ForeColor = Color.Green;
                            }
                        }

                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 12)
                        {
                            lblQuarterSum_D169.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_D169.ForeColor = Color.Red;
                            lblQuarterSum_D169.Font.Bold = true;
                            //tdQuarterSum_D169.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_D169.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            //lblQuarterSum_D169.ForeColor = Color.Yellow;
                            if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 13)
                            {
                                //tdQuarterSum_D169.Style["background"] = "orange";
                                lblQuarterSum_D169.ForeColor = Color.Black;
                            }
                            else
                            {
                               // tdQuarterSum_D169.Style["background"] = "green";
                                lblQuarterSum_D169.ForeColor = Color.Green;
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 12)
                            {
                                lblQuarter_D169.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_D169.ForeColor = Color.Red;
                                lblQuarter_D169.Font.Bold = true;
                               // tdQuarter_D169.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_D169.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                //lblQuarter_D169.ForeColor = Color.Yellow;
                                if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter"]) < 13)
                                {
                                   // tdQuarter_D169.Style["background"] = "orange";
                                    lblQuarter_D169.ForeColor = Color.Black;
                                }
                                else
                                {
                                    //tdQuarter_D169.Style["background"] = "green";
                                    lblQuarter_D169.ForeColor = Color.Green;
                                }
                            }
                        }
                    }
                    //============================BIPL==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(0, "TOTALQC", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        e.Row.CssClass = "font-size";
                        //e.Row.BackColor = System.Drawing.Color.Yellow;
                        e.Row.Font.Bold = true;
                        e.Row.Cells[0].BackColor = System.Drawing.Color.Yellow;
                      
                            if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 12)
                            {
                                lbl1monthBIPL.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                                lbl1monthBIPL.ForeColor = Color.Red;
                                lbl1monthBIPL.Font.Bold = true;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                               // td1monthBIPL.Style["background"] = "red";
                            }
                            else
                            {
                                lbl1monthBIPL.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                                //lbl1monthBIPL.ForeColor = Color.Yellow;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                                if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 10 && Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 13)
                                {
                                    //td1monthBIPL.Style["background"] = "orange";
                                    lbl1monthBIPL.ForeColor = Color.Black;
                                }
                                else
                                {
                                    //td1monthBIPL.Style["background"] = "green";
                                    lbl1monthBIPL.ForeColor = Color.Green;
                                }
                            }
                        

                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 12)
                        {
                            lblQuarterSum_BIPL.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_BIPL.ForeColor = Color.Red;
                            lblQuarterSum_BIPL.Font.Bold = true;
                           // tdQuarterSum_BIPL.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_BIPL.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                           // lblQuarterSum_BIPL.ForeColor = Color.Yellow;
                            if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 13)
                            {
                                //tdQuarterSum_BIPL.Style["background"] = "orange";
                                lblQuarterSum_BIPL.ForeColor = Color.Black;
                            }
                            else
                            {
                                //tdQuarterSum_BIPL.Style["background"] = "green";
                                lblQuarterSum_BIPL.ForeColor = Color.Green;
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 12)
                            {
                                lblQuarter_BIPL.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_BIPL.ForeColor = Color.Red;
                                lblQuarter_BIPL.Font.Bold = true;
                               // tdQuarter_BIPL.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_BIPL.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                               // lblQuarter_BIPL.ForeColor = Color.Yellow;
                                if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 10 && Convert.ToInt32(dt.Rows[0]["Quarter"]) < 13)
                                {
                                   // tdQuarter_BIPL.Style["background"] = "orange";
                                    lblQuarter_BIPL.ForeColor = Color.Black;
                                }
                                else
                                {
                                   // tdQuarter_BIPL.Style["background"] = "green";
                                    lblQuarter_BIPL.ForeColor = Color.Green;
                                }
                            }
                        }
                    }

                }
                if (lblQaProcessId.Text == "CQD ONLINE INSPN Pass")
                {
                    //============================C45==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(3, "AQLPASSONLINE", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    e.Row.CssClass = "font-size";
                    if (dt.Rows.Count > 0)
                    {
                       
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 90)
                        {
                            lbl1monthC47.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthC47.ForeColor = Color.Red;
                            lbl1monthC47.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthC47.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthC47.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthC47.ForeColor = Color.Green;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthC47.Style["background"] = "green";

                        }
                        
                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 90)
                        {
                            lblQuarterSum_C47.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_C47.ForeColor = Color.Red;
                            lblQuarterSum_C47.Font.Bold = true;
                            //tdQuarterSum_C47.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_C47.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_C47.ForeColor = Color.Green;
                           // tdQuarterSum_C47.Style["background"] = "green";
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) < 90)
                            {
                                lblQuarter_C47.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_C47.ForeColor = Color.Red;
                                lblQuarter_C47.Font.Bold = true;
                               // tdQuarter_C47.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_C47.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_C47.ForeColor = Color.Green;
                               // tdQuarter_C47.Style["background"] = "green";
                            }
                        }
                    }
                    //============================C45C46==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(11, "AQLPASSONLINE", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                       
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 90)
                        {
                            lbl1monthC45.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthC45.ForeColor = Color.Red;
                            lbl1monthC45.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthC45.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthC45.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthC45.ForeColor = Color.Green;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthC45.Style["background"] = "green";

                        }
                        

                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 90)
                        {
                            lblQuarterSum_C45.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_C45.ForeColor = Color.Red;
                            lblQuarterSum_C45.Font.Bold = true;
                           // tdQuarterSum_C45.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_C45.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_C45.ForeColor = Color.Green;
                           // tdQuarterSum_C45.Style["background"] = "green";
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) < 90)
                            {
                                lblQuarter_C45.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_C45.ForeColor = Color.Red;
                                lblQuarter_C45.Font.Bold = true;
                               // tdQuarter_C45.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_C45.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_C45.ForeColor = Color.Green;
                                //tdQuarter_C45.Style["background"] = "green";
                            }
                        }
                    }
                    //============================D169==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(96, "AQLPASSONLINE", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {

                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 90)
                        {
                            lbl1monthD169.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthD169.ForeColor = Color.Red;
                            lbl1monthD169.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                            //td1monthD169.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthD169.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthD169.ForeColor = Color.Green;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthD169.Style["background"] = "green";

                        }


                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 90)
                        {
                            lblQuarterSum_D169.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_D169.ForeColor = Color.Red;
                            lblQuarterSum_D169.Font.Bold = true;
                           // tdQuarterSum_D169.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_D169.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_D169.ForeColor = Color.Green;
                           // tdQuarterSum_D169.Style["background"] = "green";
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) < 90)
                            {
                                lblQuarter_D169.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_D169.ForeColor = Color.Red;
                                lblQuarter_D169.Font.Bold = true;
                               // tdQuarter_D169.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_D169.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_D169.ForeColor = Color.Green;
                               // tdQuarter_D169.Style["background"] = "green";
                            }
                        }
                    }
                    //============================BIPL==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(0, "AQLPASSONLINE", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                       
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 90)
                        {
                            lbl1monthBIPL.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthBIPL.ForeColor = Color.Red;
                            lbl1monthBIPL.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                            //td1monthBIPL.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthBIPL.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthBIPL.ForeColor = Color.Green;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                            //td1monthBIPL.Style["background"] = "green";

                        }
                        

                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 90)
                        {
                            lblQuarterSum_BIPL.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_BIPL.ForeColor = Color.Red;
                            lblQuarterSum_BIPL.Font.Bold = true;
                           // tdQuarterSum_BIPL.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_BIPL.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_BIPL.ForeColor = Color.Green;
                            //tdQuarterSum_BIPL.Style["background"] = "green";
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) < 90)
                            {
                                lblQuarter_BIPL.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_BIPL.ForeColor = Color.Red;
                                lblQuarter_BIPL.Font.Bold = true;
                               // tdQuarter_BIPL.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_BIPL.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_BIPL.ForeColor = Color.Green;
                               // tdQuarter_BIPL.Style["background"] = "green";
                            }
                        }
                    }
                }
                if (lblQaProcessId.Text == "CQD FINAL INSPN Pass")
                {
                    //============================C45==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(3, "AQLPASSFINAL", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    e.Row.CssClass = "font-size";
                    if (dt.Rows.Count > 0)
                    {
                      
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 90)
                        {
                            lbl1monthC47.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthC47.ForeColor = Color.Red;
                            lbl1monthC47.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthC47.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthC47.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthC47.ForeColor = Color.Green;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthC47.Style["background"] = "green";

                        }
                       

                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 90)
                        {
                            lblQuarterSum_C47.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_C47.ForeColor = Color.Red;
                            lblQuarterSum_C47.Font.Bold = true;
                           // tdQuarterSum_C47.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_C47.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_C47.ForeColor = Color.Green;
                           // tdQuarterSum_C47.Style["background"] = "green";
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) < 90)
                            {
                                lblQuarter_C47.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_C47.ForeColor = Color.Red;
                                lblQuarter_C47.Font.Bold = true;
                               // tdQuarter_C47.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_C47.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_C47.ForeColor = Color.Green;
                                //tdQuarter_C47.Style["background"] = "green";
                            }
                        }
                    }
                    //============================C45C46==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(11, "AQLPASSFINAL", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                      
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 90)
                        {
                            lbl1monthC45.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthC45.ForeColor = Color.Red;
                            lbl1monthC45.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                            //td1monthC45.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthC45.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthC45.ForeColor = Color.Green;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                            //td1monthC45.Style["background"] = "green";

                        }
                        

                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 90)
                        {
                            lblQuarterSum_C45.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_C45.ForeColor = Color.Red;
                            lblQuarterSum_C45.Font.Bold = true;
                            //tdQuarterSum_C45.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_C45.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_C45.ForeColor = Color.Green;
                           // tdQuarterSum_C45.Style["background"] = "green";
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) < 90)
                            {
                                lblQuarter_C45.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_C45.ForeColor = Color.Red;
                                lblQuarter_C45.Font.Bold = true;
                               // tdQuarter_C45.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_C45.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_C45.ForeColor = Color.Green;
                               // tdQuarter_C45.Style["background"] = "green";
                            }
                        }
                    }
                    //============================D169==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(96, "AQLPASSFINAL", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {

                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 90)
                        {
                            lbl1monthD169.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthD169.ForeColor = Color.Red;
                            lbl1monthD169.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthD169.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthD169.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthD169.ForeColor = Color.Green;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthD169.Style["background"] = "green";

                        }


                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 90)
                        {
                            lblQuarterSum_D169.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_D169.ForeColor = Color.Red;
                            lblQuarterSum_D169.Font.Bold = true;
                            //tdQuarterSum_D169.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_D169.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_D169.ForeColor = Color.Green;
                           // tdQuarterSum_D169.Style["background"] = "green";
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) < 90)
                            {
                                lblQuarter_D169.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_D169.ForeColor = Color.Red;
                                lblQuarter_D169.Font.Bold = true;
                              //  tdQuarter_D169.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_D169.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_D169.ForeColor = Color.Green;
                               // tdQuarter_D169.Style["background"] = "green";
                            }
                        }
                    }
                    //============================BIPL==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(0, "AQLPASSFINAL", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                      
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 90)
                        {
                            lbl1monthBIPL.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthBIPL.ForeColor = Color.Red;
                            lbl1monthBIPL.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthBIPL.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthBIPL.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthBIPL.ForeColor = Color.Green;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                            //td1monthBIPL.Style["background"] = "green";

                        }
                        

                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 90)
                        {
                            lblQuarterSum_BIPL.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_BIPL.ForeColor = Color.Red;
                            lblQuarterSum_BIPL.Font.Bold = true;
                            //tdQuarterSum_BIPL.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_BIPL.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_BIPL.ForeColor = Color.Green;
                            //tdQuarterSum_BIPL.Style["background"] = "green";
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) < 90)
                            {
                                lblQuarter_BIPL.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_BIPL.ForeColor = Color.Red;
                                //tdQuarter_BIPL.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_BIPL.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_BIPL.ForeColor = Color.Green;
                                //tdQuarter_BIPL.Style["background"] = "green";
                            }
                        }
                    }
                }

                //===============================Finish Rate============================================//

                if (lblQaProcessId.Text == "Finish Rate")
                {
                    //============================C45==============================================//

                    //e.Row.Visible = false;
                    ds = this.QualityControllerInstance.GetQcFualtPer(3, "FINISHRATE", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                       
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 15)
                        {
                            lbl1monthC47.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString();
                            lbl1monthC47.ForeColor = Color.Red;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                          //  td1monthC47.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthC47.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString();
                            lbl1monthC47.ForeColor = Color.Green;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthC47.Style["background"] = "green";

                        }
                        

                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 15)
                        {
                            lblQuarterSum_C47.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString();
                            lblQuarterSum_C47.ForeColor = Color.Red;
                           // tdQuarterSum_C47.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_C47.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString();
                            lblQuarterSum_C47.ForeColor = Color.Green;
                           // tdQuarterSum_C47.Style["background"] = "green";
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 15)
                            {
                                lblQuarter_C47.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString();
                                lblQuarter_C47.ForeColor = Color.Red;
                                lblQuarter_C47.Font.Bold = true;
                               // tdQuarter_C47.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_C47.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString();
                                lblQuarter_C47.ForeColor = Color.Green;
                                //tdQuarter_C47.Style["background"] = "green";
                            }
                        }
                    }
                    //============================C45C46==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(11, "FINISHRATE", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                       
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 15)
                        {
                            lbl1monthC45.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString();
                            lbl1monthC45.ForeColor = Color.Red;
                            lbl1monthC45.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthC45.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthC45.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString();
                            lbl1monthC45.ForeColor = Color.Green;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                          //  td1monthC45.Style["background"] = "green";

                        }
                        

                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 15)
                        {
                            lblQuarterSum_C45.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString();
                            lblQuarterSum_C45.ForeColor = Color.Red;
                            lblQuarterSum_C45.Font.Bold = true;
                            //tdQuarterSum_C45.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_C45.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString();
                            lblQuarterSum_C45.ForeColor = Color.Green;
                            //tdQuarterSum_C45.Style["background"] = "green";
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 15)
                            {
                                lblQuarter_C45.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString();
                                lblQuarter_C45.ForeColor = Color.Red;
                                lblQuarter_C45.Font.Bold = true;
                               // tdQuarter_C45.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_C45.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString();
                                lblQuarter_C45.ForeColor = Color.Green;
                              //  tdQuarter_C45.Style["background"] = "green";
                            }
                        }
                    }
                    //============================D169==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(96, "FINISHRATE", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {

                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 15)
                        {
                            lbl1monthD169.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString();
                            lbl1monthD169.ForeColor = Color.Red;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                          //  td1monthD169.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthD169.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString();
                            lbl1monthD169.ForeColor = Color.Green;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                            //td1monthD169.Style["background"] = "green";

                        }


                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 15)
                        {
                            lblQuarterSum_D169.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString();
                            lblQuarterSum_D169.ForeColor = Color.Red;
                           // tdQuarterSum_D169.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_D169.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString();
                            lblQuarterSum_D169.ForeColor = Color.Green;
                            //tdQuarterSum_D169.Style["background"] = "green";
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 15)
                            {
                                lblQuarter_D169.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString();
                                lblQuarter_D169.ForeColor = Color.Red;
                                lblQuarter_D169.Font.Bold = true;
                               // tdQuarter_D169.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_D169.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString();
                                lblQuarter_D169.ForeColor = Color.Green;
                                //tdQuarter_D169.Style["background"] = "green";
                            }
                        }
                    }
                    //============================BIPL==============================================//


                    ds = this.QualityControllerInstance.GetQcFualtPer(0, "FINISHRATE", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                       
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 15)
                        {
                            lbl1monthBIPL.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString();
                            lbl1monthBIPL.ForeColor = Color.Red;
                            lbl1monthBIPL.Font.Bold = true;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthBIPL.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthBIPL.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString();
                            lbl1monthBIPL.ForeColor = Color.Green;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                          //  td1monthBIPL.Style["background"] = "green";

                        }
                        

                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 15)
                        {
                            lblQuarterSum_BIPL.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString();
                            lblQuarterSum_BIPL.ForeColor = Color.Red;
                            lblQuarterSum_BIPL.Font.Bold = true;
                           // tdQuarterSum_BIPL.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_BIPL.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString();
                            lblQuarterSum_BIPL.ForeColor = Color.Green;
                           // tdQuarterSum_BIPL.Style["background"] = "green";
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 15)
                            {
                                lblQuarter_BIPL.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString();
                                lblQuarter_BIPL.ForeColor = Color.Red;
                                lblQuarter_BIPL.Font.Bold = true;
                               // tdQuarter_BIPL.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_BIPL.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString();
                                lblQuarter_BIPL.ForeColor = Color.Green;
                                //tdQuarter_BIPL.Style["background"] = "green";
                            }
                        }
                    }
                }







                if (lblQaProcessId.Text != "Total CQD Faults" && lblQaProcessId.Text != "Total QC Faults" && lblQaProcessId.Text != "CQD ONLINE INSPN Pass" && lblQaProcessId.Text != "CQD FINAL INSPN Pass" && lblQaProcessId.Text != "Finish Rate")
                {
                    //============================C45==============================================//                    

                    ds = this.QualityControllerInstance.GetQcFualtPer(3, "PROCESS", hdnQaProcessId.Value);
                    dt = ds.Tables[0];
                    // lblQaProcessId.Text = lblQaProcessId.Text;

                    if (lblQaProcessId.Text == "QC (Pass)")
                    {
                        e.Row.CssClass = "font-size";
                       
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 90)
                        {
                            lbl1monthC47.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthC47.ForeColor = Color.Green;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthC47.Style["background"] = "green";
                        }
                        else
                        {
                            lbl1monthC47.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                           // lbl1monthC47.ForeColor = Color.Yellow;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                            if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 79 && Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 91)
                            {
                                //td1monthC47.Style["background"] = "orange";
                                lbl1monthC47.ForeColor = Color.Black;
                            }
                            else
                            {
                               // td1monthC47.Style["background"] = "red";
                                lbl1monthC47.ForeColor = Color.Red;
                                lbl1monthC47.Font.Bold = true;
                            }
                        }
                    

                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 90)
                        {
                            lblQuarterSum_C47.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_C47.ForeColor = Color.Green;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                          //  tdQuarterSum_C47.Style["background"] = "green";

                        }
                        else
                        {
                            lblQuarterSum_C47.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            // lbl3monthC45.Attributes.Add("style", "color:#F58282");  
                            //lbl3monthC45.ForeColor = Color.Yellow;
                            //TableCell rowCell = (TableCell)lbl3monthC45.Parent;
                            if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 79 && Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 91)
                            {
                                // rowCell.Style["background"] = "#F2CC74";
                                //tdQuarterSum_C47.Style["background"] = "orange";
                                lblQuarterSum_C47.ForeColor = Color.Black;
                            }
                            else
                            {
                               // tdQuarterSum_C47.Style["background"] = "red";
                                //rowCell.Style["background"] = "#F58282";
                                lblQuarterSum_C47.ForeColor = Color.Red;
                                lblQuarterSum_C47.Font.Bold = true;
                            }
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 90)
                            {
                                lblQuarter_C47.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_C47.ForeColor = Color.Green;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                               // tdQuarter_C47.Style["background"] = "green";

                            }
                            else
                            {
                                lblQuarter_C47.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                // lbl3monthC45.Attributes.Add("style", "color:#F58282");  
                                //lbl3monthC45.ForeColor = Color.Yellow;
                                //TableCell rowCell = (TableCell)lbl3monthC45.Parent;
                                if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 79 && Convert.ToInt32(dt.Rows[0]["Quarter"]) < 91)
                                {
                                    // rowCell.Style["background"] = "#F2CC74";
                                    //tdQuarter_C47.Style["background"] = "orange";
                                    lblQuarter_C47.ForeColor = Color.Black;
                                }
                                else
                                {
                                    //tdQuarter_C47.Style["background"] = "red";
                                    //rowCell.Style["background"] = "#F58282";
                                    lblQuarter_C47.ForeColor = Color.Red;
                                    lblQuarter_C47.Font.Bold = true;
                                }
                            }
                        }
                        //============================C45C46==============================================//


                        ds = this.QualityControllerInstance.GetQcFualtPer(11, "PROCESS", hdnQaProcessId.Value);
                        dt = ds.Tables[0];
                        //lblQaProcessId.Text = lblQaProcessId.Text + "(Pass)";
                        if (dt.Rows.Count > 0)
                        {
                            //    lbl1monthC45C46.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString();
                            //    lbl3monthC45C46.Text = dt.Rows[0]["threeMonths"].ToString() == "0" ? "" : dt.Rows[0]["threeMonths"].ToString();
                            //    lbl1yearC45C46.Text = dt.Rows[0]["OneYear"].ToString() == "0" ? "" : dt.Rows[0]["OneYear"].ToString() + '%';
                            //}
                         
                            if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 90)
                            {
                                lbl1monthC45.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                                lbl1monthC45.ForeColor = Color.Green;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                                //td1monthC45.Style["background"] = "green";
                            }
                            else
                            {
                                lbl1monthC45.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                               // lbl1monthC45.ForeColor = Color.Yellow;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                                if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 79 && Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 91)
                                {
                                    //td1monthC45.Style["background"] = "orange";
                                    lbl1monthC45.ForeColor = Color.Black;
                                }
                                else
                                {
                                    //td1monthC45.Style["background"] = "red";
                                    lbl1monthC45.ForeColor = Color.Red;
                                    lbl1monthC45.Font.Bold = true;
                                }
                            }
                         

                            if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 90)
                            {
                                lblQuarterSum_C45.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                                lblQuarterSum_C45.ForeColor = Color.Green;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                              //  tdQuarterSum_C45.Style["background"] = "green";

                            }
                            else
                            {
                                lblQuarterSum_C45.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                                // lbl3monthC45.Attributes.Add("style", "color:#F58282");  
                                //lbl3monthC45.ForeColor = Color.Yellow;
                                //TableCell rowCell = (TableCell)lbl3monthC45.Parent;
                                if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 79 && Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 91)
                                {
                                    // rowCell.Style["background"] = "#F2CC74";
                                   // tdQuarterSum_C45.Style["background"] = "orange";
                                    lblQuarterSum_C45.ForeColor = Color.Black;
                                }
                                else
                                {
                                   // tdQuarterSum_C45.Style["background"] = "red";
                                    lblQuarterSum_C45.ForeColor = Color.Red;
                                    lblQuarterSum_C45.Font.Bold = true;
                                    //rowCell.Style["background"] = "#F58282";
                                }
                            }
                            if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                            {
                                if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 90)
                                {
                                    lblQuarter_C45.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                    lblQuarter_C45.ForeColor = Color.Green;
                                    //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                                  //  tdQuarter_C45.Style["background"] = "green";

                                }
                                else
                                {
                                    lblQuarter_C45.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                    // lbl3monthC45.Attributes.Add("style", "color:#F58282");  
                                    //lbl3monthC45.ForeColor = Color.Yellow;
                                    //TableCell rowCell = (TableCell)lbl3monthC45.Parent;
                                    if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 79 && Convert.ToInt32(dt.Rows[0]["Quarter"]) < 91)
                                    {
                                        // rowCell.Style["background"] = "#F2CC74";
                                       // tdQuarter_C45.Style["background"] = "orange";
                                        lblQuarter_C45.ForeColor = Color.Black;
                                    }
                                    else
                                    {
                                        //tdQuarter_C45.Style["background"] = "red";
                                        //rowCell.Style["background"] = "#F58282";
                                        lblQuarter_C45.ForeColor = Color.Red;
                                        lblQuarter_C45.Font.Bold = true;
                                    }
                                }
                            }
                        }
                        //============================D169==============================================//


                        ds = this.QualityControllerInstance.GetQcFualtPer(11, "PROCESS", hdnQaProcessId.Value);
                        dt = ds.Tables[0];
                        //lblQaProcessId.Text = lblQaProcessId.Text + "(Pass)";
                        if (dt.Rows.Count > 0)
                        {
                            //    lbl1monthC45C46.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString();
                            //    lbl3monthC45C46.Text = dt.Rows[0]["threeMonths"].ToString() == "0" ? "" : dt.Rows[0]["threeMonths"].ToString();
                            //    lbl1yearC45C46.Text = dt.Rows[0]["OneYear"].ToString() == "0" ? "" : dt.Rows[0]["OneYear"].ToString() + '%';
                            //}

                            if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 90)
                            {
                                lbl1monthD169.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                                lbl1monthD169.ForeColor = Color.Green;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                                //td1monthD169.Style["background"] = "green";
                            }
                            else
                            {
                                lbl1monthD169.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                                //lbl1monthD169.ForeColor = Color.Yellow;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                                if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 79 && Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 91)
                                {
                                    //td1monthD169.Style["background"] = "orange";
                                    lbl1monthD169.ForeColor = Color.Black;
                                }
                                else
                                {
                                   // td1monthD169.Style["background"] = "red";
                                    lbl1monthD169.ForeColor = Color.Red;
                                }
                            }


                            if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 90)
                            {
                                lblQuarterSum_D169.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                                lblQuarterSum_D169.ForeColor = Color.Green;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                               // tdQuarterSum_D169.Style["background"] = "green";

                            }
                            else
                            {
                                lblQuarterSum_D169.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                                // lbl3monthC45.Attributes.Add("style", "color:#F58282");  
                                //lbl3monthC45.ForeColor = Color.Yellow;
                                //TableCell rowCell = (TableCell)lbl3monthC45.Parent;
                                if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 79 && Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 91)
                                {
                                    // rowCell.Style["background"] = "#F2CC74";
                                   // tdQuarterSum_D169.Style["background"] = "orange";
                                    lblQuarterSum_D169.ForeColor = Color.Black;
                                }
                                else
                                {
                                   // tdQuarterSum_C45.Style["background"] = "red";
                                    //rowCell.Style["background"] = "#F58282";
                                    lblQuarterSum_D169.ForeColor = Color.Red;
                                }
                            }
                            if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                            {
                                if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 90)
                                {
                                    lblQuarter_D169.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                    lblQuarter_D169.ForeColor = Color.Green;
                                    //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                                   // tdQuarter_D169.Style["background"] = "green";

                                }
                                else
                                {
                                    lblQuarter_D169.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                    // lbl3monthC45.Attributes.Add("style", "color:#F58282");  
                                    //lbl3monthC45.ForeColor = Color.Yellow;
                                    //TableCell rowCell = (TableCell)lbl3monthC45.Parent;
                                    if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 79 && Convert.ToInt32(dt.Rows[0]["Quarter"]) < 91)
                                    {
                                        // rowCell.Style["background"] = "#F2CC74";
                                        //tdQuarter_D169.Style["background"] = "orange";
                                        lblQuarter_D169.ForeColor = Color.Black;
                                    }
                                    else
                                    {
                                       // tdQuarter_D169.Style["background"] = "red";
                                        //rowCell.Style["background"] = "#F58282";
                                        lblQuarter_D169.ForeColor = Color.Red;
                                        lblQuarter_D169.Font.Bold = true;
                                    }
                                }
                            }
                        }
                        //============================BIPL==============================================//


                        ds = this.QualityControllerInstance.GetQcFualtPer(0, "PROCESS", hdnQaProcessId.Value);
                        dt = ds.Tables[0];
                        // lblQaProcessId.Text = lblQaProcessId.Text + "(Pass)";
                        if (dt.Rows.Count > 0)
                        {
                            //    lbl1monthBIPL.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString();
                            //    lbl3monthBIPL.Text = "&nbsp; &nbsp;" + dt.Rows[0]["threeMonths"].ToString() == "0" ? "" : dt.Rows[0]["threeMonths"].ToString();
                            //    lbl1yearBIPL.Text = dt.Rows[0]["OneYear"].ToString() == "0" ? "" : dt.Rows[0]["OneYear"].ToString() + '%';
                            //}
                           
                            if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 90)
                            {
                                lbl1monthBIPL.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                                lbl1monthBIPL.ForeColor = Color.Green;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                                //td1monthBIPL.Style["background"] = "green";
                            }
                            else
                            {
                                lbl1monthBIPL.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                              //  lbl1monthBIPL.ForeColor = Color.Yellow;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                                if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) > 79 && Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 91)
                                {
                                   // td1monthBIPL.Style["background"] = "orange";
                                    lbl1monthBIPL.ForeColor = Color.Black;
                                }
                                else
                                {
                                  //  td1monthBIPL.Style["background"] = "red";
                                    lbl1monthBIPL.ForeColor = Color.Red;
                                    lbl1monthBIPL.Font.Bold = true;
                                }
                            }
                          

                            if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 90)
                            {
                                lblQuarterSum_BIPL.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                                lblQuarterSum_BIPL.ForeColor = Color.Green;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                               // tdQuarterSum_BIPL.Style["background"] = "green";

                            }
                            else
                            {
                                lblQuarterSum_BIPL.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                                // lbl3monthC45.Attributes.Add("style", "color:#F58282");  
                                //lbl3monthC45.ForeColor = Color.Yellow;
                                //TableCell rowCell = (TableCell)lbl3monthC45.Parent;
                                if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) > 79 && Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 91)
                                {
                                    // rowCell.Style["background"] = "#F2CC74";
                                   // tdQuarterSum_BIPL.Style["background"] = "orange";
                                    lblQuarterSum_BIPL.ForeColor = Color.Black;
                                }
                                else
                                {
                                   // tdQuarterSum_BIPL.Style["background"] = "red";
                                    lblQuarterSum_BIPL.ForeColor = Color.Red;
                                    lblQuarterSum_BIPL.Font.Bold = true;

                                    //rowCell.Style["background"] = "#F58282";
                                }
                            }
                            if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                            {
                                if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 90)
                                {
                                    lblQuarter_BIPL.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                    lblQuarter_BIPL.ForeColor = Color.Green;
                                    //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                                    //tdQuarter_BIPL.Style["background"] = "green";

                                }
                                else
                                {
                                    lblQuarter_BIPL.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                    // lbl3monthC45.Attributes.Add("style", "color:#F58282");  
                                    //lbl3monthC45.ForeColor = Color.Yellow;
                                    //TableCell rowCell = (TableCell)lbl3monthC45.Parent;
                                    if (Convert.ToInt32(dt.Rows[0]["Quarter"]) > 79 && Convert.ToInt32(dt.Rows[0]["Quarter"]) < 91)
                                    {
                                        // rowCell.Style["background"] = "#F2CC74";
                                        //tdQuarter_BIPL.Style["background"] = "orange";
                                        lblQuarter_BIPL.ForeColor = Color.Black;
                                    }
                                    else
                                    {
                                       // tdQuarter_BIPL.Style["background"] = "red";
                                        //rowCell.Style["background"] = "#F58282";
                                        lblQuarter_BIPL.ForeColor = Color.Red;
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                      
                        if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 90)
                        {
                            lbl1monthC47.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthC47.ForeColor = Color.Red;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthC47.Style["background"] = "red";
                        }
                        else
                        {
                            lbl1monthC47.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                            lbl1monthC47.ForeColor = Color.Green;
                            //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                           // td1monthC47.Style["background"] = "green";

                        }
                        

                        if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 90)
                        {
                            lblQuarterSum_C47.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_C47.ForeColor = Color.Red;
                           // tdQuarterSum_C47.Style["background"] = "red";
                        }
                        else
                        {
                            lblQuarterSum_C47.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                            lblQuarterSum_C47.ForeColor = Color.Green;
                           // tdQuarterSum_C47.Style["background"] = "green";
                        }
                        if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                        {
                            if (Convert.ToInt32(dt.Rows[0]["Quarter"]) < 90)
                            {
                                lblQuarter_C47.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_C47.ForeColor = Color.Red;
                                lblQuarter_C47.Font.Bold = true;
                                //tdQuarter_C47.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarter_C47.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                lblQuarter_C47.ForeColor = Color.Green;
                               // tdQuarter_C47.Style["background"] = "green";
                            }
                        }
                        //============================C45C46==============================================//


                        ds = this.QualityControllerInstance.GetQcFualtPer(11, "PROCESS", hdnQaProcessId.Value);
                        dt = ds.Tables[0];
                        //lblQaProcessId.Text = lblQaProcessId.Text + "(Pass)";
                        if (dt.Rows.Count > 0)
                        {
                         
                            if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 90)
                            {
                                lbl1monthC45.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                                lbl1monthC45.ForeColor = Color.Red;
                                lbl1monthC45.Font.Bold = true;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                               // td1monthC45.Style["background"] = "red";
                            }
                            else
                            {
                                lbl1monthC45.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                                lbl1monthC45.ForeColor = Color.Green;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                                //td1monthC45.Style["background"] = "green";

                            }
                            

                            if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 90)
                            {
                                lblQuarterSum_C45.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                                lblQuarterSum_C45.ForeColor = Color.Red;
                                lblQuarterSum_C45.Font.Bold = true;
                                //tdQuarterSum_C45.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarterSum_C45.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                                lblQuarterSum_C45.ForeColor = Color.Green;
                              //  tdQuarterSum_C45.Style["background"] = "green";
                            }
                            if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                            {
                                if (Convert.ToInt32(dt.Rows[0]["Quarter"]) < 90)
                                {
                                    lblQuarter_C45.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                    lblQuarter_C45.ForeColor = Color.Red;
                                    lblQuarter_C45.Font.Bold = true;
                                   // tdQuarter_C45.Style["background"] = "red";
                                }
                                else
                                {
                                    lblQuarter_C45.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                    lblQuarter_C45.ForeColor = Color.Green;
                                   // tdQuarter_C45.Style["background"] = "green";
                                }
                            }
                        }
                        //============================D 169==============================================//


                        ds = this.QualityControllerInstance.GetQcFualtPer(96, "PROCESS", hdnQaProcessId.Value);
                        dt = ds.Tables[0];
                        //lblQaProcessId.Text = lblQaProcessId.Text + "(Pass)";
                        if (dt.Rows.Count > 0)
                        {

                            if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 90)
                            {
                                lbl1monthD169.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                                lbl1monthD169.ForeColor = Color.Red;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                               // td1monthD169.Style["background"] = "red";
                            }
                            else
                            {
                                lbl1monthD169.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                                lbl1monthD169.ForeColor = Color.Green;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                               // td1monthD169.Style["background"] = "green";

                            }


                            if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 90)
                            {
                                lblQuarterSum_D169.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                                lblQuarterSum_D169.ForeColor = Color.Red;
                               // tdQuarterSum_D169.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarterSum_D169.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                                lblQuarterSum_D169.ForeColor = Color.Green;
                                //tdQuarterSum_D169.Style["background"] = "green";
                            }
                            if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                            {
                                if (Convert.ToInt32(dt.Rows[0]["Quarter"]) < 90)
                                {
                                    lblQuarter_D169.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                    lblQuarter_D169.ForeColor = Color.Red;
                                    lblQuarter_D169.Font.Bold = true;
                                  // tdQuarter_D169.Style["background"] = "red";
                                }
                                else
                                {
                                    lblQuarter_D169.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                    lblQuarter_D169.ForeColor = Color.Green;
                                  //  tdQuarter_D169.Style["background"] = "green";
                                }
                            }
                        }
                        //============================BIPL==============================================//


                        ds = this.QualityControllerInstance.GetQcFualtPer(0, "PROCESS", hdnQaProcessId.Value);
                        dt = ds.Tables[0];
                        // lblQaProcessId.Text = lblQaProcessId.Text + "(Pass)";
                        if (dt.Rows.Count > 0)
                        {
                          
                            if (Convert.ToInt32(dt.Rows[0]["OneMonths"]) < 90)
                            {
                                lbl1monthBIPL.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                                lbl1monthBIPL.ForeColor = Color.Red;
                                lbl1monthBIPL.Font.Bold = true;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                               // td1monthBIPL.Style["background"] = "red";
                            }
                            else
                            {
                                lbl1monthBIPL.Text = dt.Rows[0]["OneMonths"].ToString() == "0" ? "" : dt.Rows[0]["OneMonths"].ToString() + '%';
                                lbl1monthBIPL.ForeColor = Color.Green;
                                //TableCell rowCell = (TableCell)lbl1monthC45.Parent;
                               // td1monthBIPL.Style["background"] = "green";

                            }
                           

                            if (Convert.ToInt32(dt.Rows[0]["Quarter_Sum"]) < 90)
                            {
                                lblQuarterSum_BIPL.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                                lblQuarterSum_BIPL.ForeColor = Color.Red;
                                lblQuarterSum_BIPL.Font.Bold = true;
                               // tdQuarterSum_BIPL.Style["background"] = "red";
                            }
                            else
                            {
                                lblQuarterSum_BIPL.Text = dt.Rows[0]["Quarter_Sum"].ToString() == "0" ? "" : dt.Rows[0]["Quarter_Sum"].ToString() + '%';
                                lblQuarterSum_BIPL.ForeColor = Color.Green;
                                //tdQuarterSum_BIPL.Style["background"] = "green";
                            }
                            if (DateTime.Now.Month.ToString() != "1" && DateTime.Now.Month.ToString() != "4" && DateTime.Now.Month.ToString() != "7" && DateTime.Now.Month.ToString() != "10")
                            {
                                if (Convert.ToInt32(dt.Rows[0]["Quarter"]) < 90)
                                {
                                    lblQuarter_BIPL.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                    lblQuarter_BIPL.ForeColor = Color.Red;
                                    //tdQuarter_BIPL.Style["background"] = "red";
                                }
                                else
                                {
                                    lblQuarter_BIPL.Text = dt.Rows[0]["Quarter"].ToString() == "0" ? "" : dt.Rows[0]["Quarter"].ToString() + '%';
                                    lblQuarter_BIPL.ForeColor = Color.Green;
                                    //tdQuarter_BIPL.Style["background"] = "green";
                                }
                            }
                        }
                    }
                }
             }
            
        }

    }
}