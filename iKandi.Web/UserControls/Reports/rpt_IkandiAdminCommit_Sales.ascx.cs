using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using iKandi.Web.Components;
using System.Data;

namespace iKandi.Web.UserControls.Reports
{
    public partial class rpt_IkandiAdminCommit_Sales : System.Web.UI.UserControl
    {
        ClientController ClientControllerInstance = new ClientController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //BindGrid(); commented by shubhendu on 22/02/2022
            }
        }

        public void BindGrid()
        {
            string FinancialYear = GetCurrentFinancialYear();
            string[] year = FinancialYear.Split('-');
            DataSet ds = this.ClientControllerInstance.GetIkandiSales_AdminByYearNew_Report(Convert.ToInt32(year[0]), Convert.ToInt32(year[1]));
            grdIkandiadminCommit_sales.DataSource = ds;
            grdIkandiadminCommit_sales.DataBind();
            ViewState["BindData"] = ds;
            double total = 0;
            int i = 2;
            int y = 1;
            string symbol = "£ ";
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int k = 4; k < ds.Tables[0].Columns.Count; k++)
                {
                    // Added by Yadvendra on 19/12/2019
                    if (k % 2 == 0)
                    {                        
                        total = ds.Tables[0].AsEnumerable().Sum(row => row.Field<double>(ds.Tables[0].Columns[k].ToString()));
                        grdIkandiadminCommit_sales.FooterRow.Cells[i].Text = total.ToString() == "0" ? "" : symbol + (total / 1000).ToString("N0") + " K";
                        grdIkandiadminCommit_sales.FooterRow.Cells[i].Font.Bold = true;
                        grdIkandiadminCommit_sales.FooterRow.Cells[i].ForeColor = System.Drawing.Color.Gray;
                        grdIkandiadminCommit_sales.FooterRow.Cells[i].ToolTip = total.ToString("#,##0");
                    }
                    else
                    {
                        total = ds.Tables[0].AsEnumerable().Sum(row => row.Field<double>(ds.Tables[0].Columns[k].ToString()));
                        grdIkandiadminCommit_sales.FooterRow.Cells[i].Text = total.ToString() == "0" ? "" : symbol + (total / 1000).ToString("N0") + " K";
                        grdIkandiadminCommit_sales.FooterRow.Cells[i].Font.Bold = true;
                        grdIkandiadminCommit_sales.FooterRow.Cells[i].ToolTip = total.ToString("#,##0");
                        if (grdIkandiadminCommit_sales.FooterRow.Cells[i - 1].Text.Replace("£", "").Replace("K", "").Trim() == "" || grdIkandiadminCommit_sales.FooterRow.Cells[i].Text.Replace("£", "").Replace("K", "").Trim() == "")
                        {
                            grdIkandiadminCommit_sales.FooterRow.Cells[i].ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            if (grdIkandiadminCommit_sales.FooterRow.Cells[i].Text.Contains(",") || grdIkandiadminCommit_sales.FooterRow.Cells[i - 1].Text.Contains(","))
                            {
                                if (grdIkandiadminCommit_sales.FooterRow.Cells[i].Text.Contains(",") && !grdIkandiadminCommit_sales.FooterRow.Cells[i - 1].Text.Contains(","))
                                {
                                    if (Convert.ToInt32(grdIkandiadminCommit_sales.FooterRow.Cells[i].Text.Replace("£", "").Replace("K", "").Replace(",", "").Trim()) < Convert.ToInt32(grdIkandiadminCommit_sales.FooterRow.Cells[i - 1].Text.Replace("£", "").Replace("K", "").Trim()))
                                        grdIkandiadminCommit_sales.FooterRow.Cells[i].ForeColor = System.Drawing.Color.Red;
                                    else
                                        grdIkandiadminCommit_sales.FooterRow.Cells[i].ForeColor = System.Drawing.Color.Green;
                                }
                                else if (grdIkandiadminCommit_sales.FooterRow.Cells[i - 1].Text.Contains(",") && !grdIkandiadminCommit_sales.FooterRow.Cells[i].Text.Contains(","))
                                {
                                    if (Convert.ToInt32(grdIkandiadminCommit_sales.FooterRow.Cells[i].Text.Replace("£", "").Replace("K", "").Trim()) < Convert.ToInt32(grdIkandiadminCommit_sales.FooterRow.Cells[i - 1].Text.Replace("£", "").Replace("K", "").Replace(",", "").Trim()))
                                        grdIkandiadminCommit_sales.FooterRow.Cells[i].ForeColor = System.Drawing.Color.Red;
                                    else
                                        grdIkandiadminCommit_sales.FooterRow.Cells[i].ForeColor = System.Drawing.Color.Green;
                                }
                                else if (grdIkandiadminCommit_sales.FooterRow.Cells[i - 1].Text.Contains(",") && grdIkandiadminCommit_sales.FooterRow.Cells[i].Text.Contains(","))
                                {

                                    if (Convert.ToInt32(grdIkandiadminCommit_sales.FooterRow.Cells[i].Text.Replace("£", "").Replace("K", "").Replace(",", "").Trim()) < Convert.ToInt32(grdIkandiadminCommit_sales.FooterRow.Cells[i - 1].Text.Replace("£", "").Replace("K", "").Replace(",", "").Trim()))
                                        grdIkandiadminCommit_sales.FooterRow.Cells[i].ForeColor = System.Drawing.Color.Red;
                                    else
                                        grdIkandiadminCommit_sales.FooterRow.Cells[i].ForeColor = System.Drawing.Color.Green;
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(grdIkandiadminCommit_sales.FooterRow.Cells[i].Text.Replace("£", "").Replace("K", "").Trim()) < Convert.ToInt32(grdIkandiadminCommit_sales.FooterRow.Cells[i - 1].Text.Replace("£", "").Replace("K", "").Trim()))
                                    grdIkandiadminCommit_sales.FooterRow.Cells[i].ForeColor = System.Drawing.Color.Red;
                                else
                                    grdIkandiadminCommit_sales.FooterRow.Cells[i].ForeColor = System.Drawing.Color.Green;
                            }
                        }

                        if (y % 2 == 0)
                        {
                            symbol = "£ ";
                        }
                        else
                        {
                            symbol = "";
                        }
                        y++;
                    }
                    // End Added by Yadvendra on 19/12/2019
                    i++;                    
                }

                grdIkandiadminCommit_sales.FooterRow.Cells[0].ColumnSpan = 2;
                grdIkandiadminCommit_sales.FooterRow.Cells.RemoveAt(1);

                MegrgeRowinGridViewClient();
            }
        }
        public string GetCurrentFinancialYear()
        {
            int CurrentYear = DateTime.Today.Year;
            int PreviousYear = DateTime.Today.Year - 1;
            int NextYear = DateTime.Today.Year + 1;
            string PreYear = PreviousYear.ToString();
            string NexYear = NextYear.ToString();
            string CurYear = CurrentYear.ToString();
            string FinYear = null;

            if (DateTime.Today.Month > 3)
                FinYear = CurYear + "-" + NexYear;
            else
                FinYear = PreYear + "-" + CurYear;
            return FinYear.Trim();
        }

        protected void grdIkandiadminCommit_sales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow4 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                headerRow1.Attributes.Add("class", "HeaderClass");
                headerRow2.Attributes.Add("class", "HeaderClass");
                headerRow3.Attributes.Add("class", "HeaderClass");
                headerRow4.Attributes.Add("class", "HeaderClass");

                TableCell HeaderCell = new TableCell();
                HeaderCell = new TableCell();
                HeaderCell.Text = "Clients";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 4;
                HeaderCell.Width = 92;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Parent Dept.";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 4;
                HeaderCell.Width = 158;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "2018-19";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Left;
                HeaderCell.Attributes.Add("class", "TopHeader");
                HeaderCell.ColumnSpan = 48;
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "2019-20";
               // HeaderCell.HorizontalAlign = HorizontalAlign.Left;
                HeaderCell.ColumnSpan = 36;
                HeaderCell.Attributes.Add("class", "TopHeaderc");
                headerRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "April";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "May";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "June";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "July";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "August";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "September";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "October";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "November";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "December";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "January";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "February";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "March";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "April";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "May";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "June";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "July";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "August";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "September";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "October";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "November";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "December";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 4;
                headerRow2.Cells.Add(HeaderCell);

                

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                //-----------------------After March till decemever
                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Val";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pcs";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "TopHeaderCurr");
                HeaderCell.ColumnSpan = 2;
                headerRow3.Cells.Add(HeaderCell);
                //


                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual");
                headerRow4.Cells.Add(HeaderCell);

                //-------------------------After March till dec--
                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Target";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthTarget1");
                headerRow4.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.Attributes.Add("class", "minWidthActual1");
                headerRow4.Cells.Add(HeaderCell);
                //------end

                grdIkandiadminCommit_sales.Controls[0].Controls.AddAt(0, headerRow4);
                grdIkandiadminCommit_sales.Controls[0].Controls.AddAt(0, headerRow3);
                grdIkandiadminCommit_sales.Controls[0].Controls.AddAt(0, headerRow2);
                grdIkandiadminCommit_sales.Controls[0].Controls.AddAt(0, headerRow1);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int x = 2;
                int y = 4;
                for (int i = 1; i <= 21; i++)
                {
                    Label lblval = e.Row.FindControl("lblVal" + i) as Label;
                    Label lblpcs = e.Row.FindControl("lblPcs" + i) as Label;
                    Label lblvalAct = e.Row.FindControl("lblValAct" + i) as Label;
                    Label lblpcsAct = e.Row.FindControl("lblPcsAct" + i) as Label;
                    if (lblval.Text == "0 K")
                    {
                      lblval.Text = "";
                    }
                    if (lblpcs.Text == "0 K")
                    {
                      lblpcs.Text = "";
                    }
                    if (lblvalAct.Text == "0 K")
                    {
                      lblvalAct.Text = "";
                    }
                    if (lblpcsAct.Text == "0 K")
                    {
                      lblpcsAct.Text = "";
                    }
                    // Added by Yadvendra on 19/12/2019
                    if (lblval.Text.Contains("£"))
                        lblval.Text = "£ " + Convert.ToDecimal(lblval.Text.Replace(" K", "").Replace("£", "")).ToString("N0") + " K";
                    else
                        lblval.Text = lblval.Text == "" ? "" : Convert.ToDecimal(lblval.Text.Replace(" K", "")).ToString("N0") + " K";

                    if (lblpcs.Text.Contains("£"))
                        lblpcs.Text = "£ " + Convert.ToDecimal(lblpcs.Text.Replace(" K", "").Replace("£", "")).ToString("N0") + " K";
                    else
                        lblpcs.Text = lblpcs.Text == "" ? "" : Convert.ToDecimal(lblpcs.Text.Replace(" K", "")).ToString("N0") + " K";

                    if (lblvalAct.Text.Contains("£"))
                        lblvalAct.Text = "£ " + Convert.ToDecimal(lblvalAct.Text.Replace(" K", "").Replace("£", "")).ToString("N0") + " K";
                    else
                        lblvalAct.Text = lblvalAct.Text == "" ? "" : Convert.ToDecimal(lblvalAct.Text.Replace(" K", "")).ToString("N0") + " K";

                    if (lblpcsAct.Text.Contains("£"))
                        lblpcsAct.Text = "£ " + Convert.ToDecimal(lblpcsAct.Text.Replace(" K", "").Replace("£", "")).ToString("N0") + " K";
                    else
                        lblpcsAct.Text = lblpcsAct.Text == "" ? "" : Convert.ToDecimal(lblpcsAct.Text.Replace(" K", "")).ToString("N0") + " K";
                    //End Added by Yadvendra on 19/12/2019
                    if (lblval.Text != "")
                    {
                        if (lblvalAct.Text == "")
                        {
                        }
                        else if (Convert.ToDouble(lblvalAct.Text.Replace("K", "").Replace("£", "")) < Convert.ToDouble(lblval.Text.Replace("K", "").Replace("£", "")))
                        {
                            e.Row.Cells[i + x].Style.Add("color", "red");
                        }
                        else
                        {
                            e.Row.Cells[i + x].Style.Add("color", "green");
                        }
                    }
                    else
                    {
                        if (lblvalAct.Text == "")
                        {
                        }
                        else
                            e.Row.Cells[i + x].Style.Add("color", "green");
                    }
                    if (lblpcs.Text != "")
                    {
                        if (lblpcsAct.Text == "")
                        {
                        }
                        else if (Convert.ToDouble(lblpcsAct.Text.Replace("K", "")) < Convert.ToDouble(lblpcs.Text.Replace("K", "")))
                        {
                            e.Row.Cells[i + y].Style.Add("color", "red");
                        }
                        else
                        {
                            e.Row.Cells[i + y].Style.Add("color", "green");
                        }
                    }
                    else
                    {
                        if (lblpcsAct.Text == "")
                        {
                        }
                        else
                            e.Row.Cells[i + y].Style.Add("color", "green");
                    }

                    x = x + 3;
                    y = y + 3;
                }
            }

        }

        public void MegrgeRowinGridViewClient()
        {
            int index = grdIkandiadminCommit_sales.Rows.Count - 1;
            for (int i = grdIkandiadminCommit_sales.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdIkandiadminCommit_sales.Rows[i];
                GridViewRow previousRow = grdIkandiadminCommit_sales.Rows[index - 1];

                Label lblClient = (Label)row.FindControl("lblClient");
                Label lblPreviousClient = (Label)previousRow.FindControl("lblClient");

                if (lblClient.Text == lblPreviousClient.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan = 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                }
                index = index - 1;
            }
        }
    }
}