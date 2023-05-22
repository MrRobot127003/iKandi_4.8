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
    public partial class ExFactoryQuantity : BaseUserControl
    {
        #region fields

        DataSet dsExFactoryQty = null;
        DataTable dtExFactoryQty = null;
        bool IsExtraheaderCreated = false;
        int totalClient = 0;
        int weeks = 0;
        double weeklyQty;
        double totalQty = 0;
        long totalFillup = 0;
        long[] qtys;

        #endregion

        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //BindControls();
        }

        protected void grdExFactoryQty_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {

                if (e.Row.RowType == DataControlRowType.Header)
                {
                    for (int i = 0; i < e.Row.Cells.Count; i++)
                    {
                        if (e.Row.Cells[i].Text.Contains("Qty:"))
                        {
                            e.Row.Cells[i].Text = "QTY";
                        }
                        else if (e.Row.Cells[i].Text.Contains("Orders:"))
                        {
                            e.Row.Cells[i].Text = "Orders";
                        }
                        else if (e.Row.Cells[i].Text.Contains("QtySharePer:"))
                        {
                            e.Row.Cells[i].Text = "Qty Share %";
                        }
                    }
                }
                else if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowIndex == weeks)
                    {
                        e.Row.Cells[1].Text = totalQty.ToString("N0");
                        e.Row.Cells[2].Text = (totalFillup / weeks).ToString() + "%";

                        for (int i = 2; i < e.Row.Cells.Count; i++)
                        {
                            e.Row.Cells[i].CssClass = "font_color_blue";
                        }
                        for (int i = 0; i < e.Row.Cells.Count; i++)
                        {
                            e.Row.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9ddf4");
                        }
                        e.Row.Cells[2].RowSpan = 2;
                        for (int i = 3; i < e.Row.Cells.Count; i = i + 3)
                        {
                            e.Row.Cells[i + 2].RowSpan = 2;
                            e.Row.Cells[i].Text = qtys[i].ToString() == "0" || qtys[i].ToString() == string.Empty || qtys[i].ToString() == "&nbsp;" ? string.Empty : qtys[i].ToString("N0");
                            e.Row.Cells[i + 1].Text = qtys[i + 1].ToString() == "0" || qtys[i + 1].ToString() == string.Empty || qtys[i + 1].ToString() == "&nbsp;" ? string.Empty : qtys[i + 1].ToString("N0");
                            e.Row.Cells[i + 2].Text = qtys[i + 2].ToString() == "0" || qtys[i + 2].ToString() == string.Empty || qtys[i + 2].ToString() == "&nbsp;" ? string.Empty : (Convert.ToInt64(qtys[i + 2]) / weeks).ToString() + "%";
                            var p1 = e.Row.Cells[i + 2].Text.Split('%');
                            if (p1[0].ToString() != "&nbsp;" && p1[0].ToString() != string.Empty && Convert.ToInt32(p1[0]) >= 0)
                                e.Row.Cells[i + 2].BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetExFactoryPecentageColor(Convert.ToInt32(p1[0])));
                        }

                        var p3 = e.Row.Cells[2].Text.Split('%');
                        if (p3[0].ToString() != "&nbsp;" && p3[0].ToString() != string.Empty && Convert.ToInt32(p3[0]) >= 0)
                            e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetExFactoryPecentageColor(Convert.ToInt32(p3[0])));
                    }
                    else if (e.Row.RowIndex < weeks)
                    {

                        e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9ddf4");


                        for (int i = 3; i < e.Row.Cells.Count; i = i + 3)
                        {
                            qtys[i] += e.Row.Cells[i].Text == string.Empty || e.Row.Cells[i].Text == "&nbsp;" ? 0 : Convert.ToInt64(e.Row.Cells[i].Text);
                            qtys[i + 1] += e.Row.Cells[i + 1].Text == "0.00" || e.Row.Cells[i + 1].Text == "&nbsp;" ? 0 : Convert.ToInt64(e.Row.Cells[i + 1].Text);
                            qtys[i + 2] += (e.Row.Cells[i].Text) == "0" || (e.Row.Cells[i].Text) == "&nbsp;" || (e.Row.Cells[i].Text) == "" || (e.Row.Cells[i].Text) == string.Empty || (e.Row.Cells[1].Text) == "0" || (e.Row.Cells[1].Text) == "&nbsp;" || (e.Row.Cells[1].Text) == "" || (e.Row.Cells[1].Text) == string.Empty ? 0 : Convert.ToInt64((Convert.ToDecimal(e.Row.Cells[i].Text.Replace(",", "")) / Convert.ToDecimal(e.Row.Cells[1].Text.Replace(",", ""))) * 100);
                            e.Row.Cells[i].Text = e.Row.Cells[i].Text == "0" || e.Row.Cells[i].Text == string.Empty || e.Row.Cells[i].Text == "&nbsp;" ? string.Empty : Convert.ToInt64(e.Row.Cells[i].Text).ToString("N0");
                            e.Row.Cells[i + 1].Text = e.Row.Cells[i + 1].Text == "0" || e.Row.Cells[i + 1].Text == "0.00" || e.Row.Cells[i + 1].Text == "&nbsp;" ? string.Empty : Convert.ToDouble(e.Row.Cells[i + 1].Text).ToString("N0");
                            e.Row.Cells[i + 2].Text = (e.Row.Cells[i].Text) == "0" || (e.Row.Cells[i].Text) == "&nbsp;" || (e.Row.Cells[i].Text) == "" || (e.Row.Cells[i].Text) == string.Empty || (e.Row.Cells[1].Text) == "0" || (e.Row.Cells[1].Text) == "&nbsp;" || (e.Row.Cells[1].Text) == "" || (e.Row.Cells[1].Text) == string.Empty ? string.Empty : ((Convert.ToDecimal(e.Row.Cells[i].Text.Replace(",", "")) / Convert.ToDecimal(e.Row.Cells[1].Text.Replace(",", ""))) * 100).ToString("N0").Replace(",", "") + "%";

                            var p1 = e.Row.Cells[i + 2].Text.Split('%');
                            if (p1[0].ToString() != "&nbsp;" && p1[0].ToString() != string.Empty && Convert.ToInt32(p1[0]) >= 0)
                                e.Row.Cells[i + 2].BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetExFactoryPecentageColor(Convert.ToInt32(p1[0])));
                        }

                        var p = e.Row.Cells[2].Text.Split('%');

                        totalFillup += e.Row.Cells[2].Text == "0.00" || e.Row.Cells[2].Text == "&nbsp;" ? 0 : Convert.ToInt64(p[0]);

                        e.Row.Cells[2].BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetExFactoryPecentageColor(Convert.ToInt32(p[0])));

                        e.Row.Cells[1].CssClass = "date_style";

                        e.Row.Cells[1].Text = (e.Row.Cells[1].Text) == "0" || (e.Row.Cells[1].Text) == string.Empty ? string.Empty : (e.Row.Cells[1].Text).ToString();
                        e.Row.Cells[2].Text = (e.Row.Cells[2].Text) == "0%" ? string.Empty : (e.Row.Cells[2].Text).ToString();

                    }
                    else if (e.Row.RowIndex > weeks)
                    {
                        e.Row.Cells[1].Text = (totalQty / weeks).ToString("N0");


                        for (int i = 2; i < e.Row.Cells.Count; i++)
                        {
                            e.Row.Cells[i].CssClass = "font_color_blue";

                        }
                        for (int i = 0; i < e.Row.Cells.Count; i++)
                        {
                            e.Row.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9ddf4");
                        }
                        var j = 0;
                        for (int i = 3; i < e.Row.Cells.Count; i = i + 3)
                        {
                            long avgQty = 0;
                            avgQty = (long)(qtys[i] / weeks);
                            e.Row.Cells[i - (j + 1)].Text = avgQty.ToString() == "0" || avgQty.ToString() == string.Empty || avgQty.ToString() == "&nbsp;" ? string.Empty : avgQty.ToString("N0");
                            j++;
                        }
                        var k = 0;
                        for (int i = 3; i < e.Row.Cells.Count - (totalClient + 1); i = i + 3)
                        {
                            long avgOrder = 0;
                            avgOrder = (long)(qtys[i + 1] / weeks);
                            e.Row.Cells[i - (k)].Text = avgOrder.ToString() == "0" || avgOrder.ToString() == string.Empty || avgOrder.ToString() == "&nbsp;" ? string.Empty : avgOrder.ToString("N0");
                            k++;
                        }

                        for (int i = e.Row.Cells.Count; i > (e.Row.Cells.Count - totalClient - 1); i--)
                        {
                            e.Row.Cells[i - 1].Visible = false;
                        }


                    }

                    for (int i = 0; i < e.Row.Cells.Count; i++)
                    {
                        e.Row.Cells[i].CssClass = "font_color_blue";
                    }

                }
            }
            catch (Exception) {  }
        }

        protected void grdExFactoryQty_DataBound(object sender, EventArgs e)
        {

        }

        protected void grdExFactoryQty_RowCreated(object sender, GridViewRowEventArgs e)
        {

            {
                if (IsExtraheaderCreated == false)
                    if (dsExFactoryQty != null && dsExFactoryQty.Tables.Count > 0)
                    {
                        if (dsExFactoryQty.Tables[2].Rows.Count > 0)
                        {
                            totalClient = dsExFactoryQty.Tables[2].Rows.Count;
                        }

                        GridView HeaderGrid = (GridView)sender;

                        GridViewRow HeaderGridRow =
                        new GridViewRow(0, 0, DataControlRowType.Header,
                        DataControlRowState.Insert);

                        Label lbl = new Label();
                        lbl.Width = 120;
                        lbl.Text = "Weekly capacity";

                        TableCell HeaderCell = new TableCell();
                        HeaderCell.Controls.Add(lbl);
                        HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F9ddf4");
                        HeaderCell.CssClass = "extra_header";
                        HeaderGridRow.Cells.Add(HeaderCell);

                        HeaderCell = new TableCell();
                        HeaderCell.Text = (Convert.ToDecimal(dsExFactoryQty.Tables[1].Rows[0]["QtyPerWeek"])).ToString("N0");
                        HeaderCell.CssClass = "extra_header";
                        HeaderCell.ColumnSpan = 1;
                        HeaderCell.Font.Bold = true;
                        HeaderCell.Font.Size = 12;
                        HeaderGridRow.Cells.Add(HeaderCell);


                        HeaderCell = new TableCell();
                        HeaderCell.Text = "Buyers";
                        HeaderCell.CssClass = "extra_header";
                        HeaderCell.ColumnSpan = 1;
                        HeaderGridRow.Cells.Add(HeaderCell);

                        for (int i = 1; i <= totalClient; i++)
                        {
                            HeaderCell = new TableCell();
                            HeaderCell.Text = dsExFactoryQty.Tables[2].Rows[i - 1]["CompanyName"].ToString();
                            HeaderCell.CssClass = "extra_header font_color_blue";
                            HeaderCell.ColumnSpan = 3;
                            HeaderGridRow.Cells.Add(HeaderCell);
                        }


                        grdExFactoryQty.Controls[0].Controls.AddAt(0, HeaderGridRow);


                    }
                IsExtraheaderCreated = true;
            }
        }

        #endregion

        #region Private Methods

        public void BindControls()
        {
            dsExFactoryQty = this.ReportControllerInstance.GetExFactoryQuantityReport();

            dtExFactoryQty = new DataTable();

            weeks = dsExFactoryQty.Tables[3].Rows.Count;
            DataRowCollection weekRows = dsExFactoryQty.Tables[3].Rows;
            DataRowCollection clientRows = dsExFactoryQty.Tables[2].Rows;

            if (dsExFactoryQty.Tables[0].Rows.Count == 0)
                return;

            if (dsExFactoryQty.Tables.Count > 0 && dsExFactoryQty.Tables[2].Rows.Count > 0)
            {
                totalClient = dsExFactoryQty.Tables[2].Rows.Count;
            }

            qtys = new long[(totalClient * 3) + 3];
            for (int l = 0; l < ((totalClient * 3) + 3); l++)
            {
                qtys[l] = 0;
            }

            dtExFactoryQty.Columns.Add("Week Ending");
            dtExFactoryQty.Columns.Add("Overall Quantity");
            dtExFactoryQty.Columns.Add("% Fillup");

            for (int i = 0; i < totalClient; i++)
            {
                DataColumn colQty = new DataColumn();
                colQty.ColumnName = "Qty: " + 0 + "-" + i;
                dtExFactoryQty.Columns.Add(colQty);

                DataColumn QtyOrders = new DataColumn();
                QtyOrders.ColumnName = "Orders: " + 0 + "-" + i;
                dtExFactoryQty.Columns.Add(QtyOrders);

                DataColumn QtySharePer = new DataColumn();
                QtySharePer.ColumnName = "QtySharePer: " + 0 + "-" + i;
                dtExFactoryQty.Columns.Add(QtySharePer);
            }

            long[] totalQuantity = new long[totalClient * 2];
            int[] totalOrders = new int[totalClient * 2];


            for (int l = 0; l < (totalClient * 2); l++)
            {
                totalQuantity[l] = 0;
                totalOrders[l] = 0;
            }

            if (dsExFactoryQty.Tables[1].Rows.Count >= 0)
            {
                weeklyQty = Convert.ToDouble(dsExFactoryQty.Tables[1].Rows[0]["QtyPerWeek"]);
            }


            for (int rows = 0; rows < weeks + 2; rows++)
            {
                DataRow drExFactoryQty = dtExFactoryQty.NewRow();
                long overAllQty = 0;

                for (int i = 0, k = 0; i < totalClient; i++)
                {
                    if (rows < weeks)
                    {
                        string str = "WeekNo =" + weekRows[rows]["WeekNo"] + " and ClientId=" + clientRows[i]["ClientId"];
                        DataRow[] dr = dsExFactoryQty.Tables[0].Select(str);

                        string str1 = "WeekNo =" + weekRows[rows]["WeekNo"];
                        DataRow[] dr1 = dsExFactoryQty.Tables[3].Select(str1);

                        long qty = 0;
                        int orders = 0;

                        drExFactoryQty["Week Ending"] = Convert.ToDateTime((System.Text.ASCIIEncoding.ASCII.GetString((byte[])dr1[0]["WeekDate"]))).ToString("dd MMM yy (ddd)");


                        if (dr.Length > 0)
                        {
                            qty = (dr[0]["TotalQuantity"] == DBNull.Value) ? 0 : Convert.ToInt64(dr[0]["TotalQuantity"]);
                            orders = (dr[0]["TotalOrder"] == DBNull.Value) ? 0 : Convert.ToInt32(dr[0]["TotalOrder"]);
                            overAllQty = overAllQty + qty;
                            totalQty += qty;
                        }



                        drExFactoryQty["Qty: " + 0 + "-" + i] = qty;

                        totalQuantity[k] += qty;
                        totalOrders[k] += orders;

                        drExFactoryQty["Orders: " + 0 + "-" + i] = orders;
                        drExFactoryQty["QtySharePer: " + 0 + "-" + i] = 0;


                        k++;
                    }

                    if (rows == weeks)
                    {
                        drExFactoryQty["Week Ending"] = "Totals";
                        drExFactoryQty["Overall Quantity"] = totalQty;
                    }

                    if (rows > weeks)
                    {
                        drExFactoryQty["Week Ending"] = "Average";
                        // drExFactoryQty["Overall Quantity"] = totalQty/weeks;
                    }

                }
                drExFactoryQty["Overall Quantity"] = overAllQty.ToString("N0");
                drExFactoryQty["% Fillup"] = ((overAllQty / (weeklyQty)) * 100).ToString("N0") + "%";

                dtExFactoryQty.Rows.Add(drExFactoryQty);
            }

            IsExtraheaderCreated = false;

            grdExFactoryQty.DataSource = dtExFactoryQty;
            grdExFactoryQty.DataBind();
        }

        #endregion
    }
}