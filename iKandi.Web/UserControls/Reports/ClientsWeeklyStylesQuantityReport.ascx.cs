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
using iKandi.BLL;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class ClientsWeeklyStylesQuantityReport : BaseUserControl
    {
        DataSet ds;
        DataTable dt;
        int RowCount;
        int Colcount;
        int FirstRow = -1;
        int cid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 2; i < e.Row.Cells.Count - 1; i++)
                {
                    e.Row.Cells[i].Text = Convert.ToDateTime(ds.Tables[0].Rows[i - 1]["WeekEnd"]).ToString("dd MMM yy (ddd)");
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.RowIndex == RowCount)
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                        e.Row.Cells[i].CssClass = "quantity_style";
                        if (i == 0)
                        {
                            e.Row.Cells[i].Style.Add("text-align", "left");
                        }
                        else
                        {
                            if (e.Row.Cells[i].Text == "0")
                            {
                                e.Row.Cells[i].Text = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        e.Row.Cells[i].CssClass = "font_color_blue";
                        if (i == 0)
                        {
                            e.Row.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                            e.Row.Cells[i].Style.Add("text-align", "left");
                        }
                        else
                        {
                            if (e.Row.Cells[i].Text == "0")
                            {
                                e.Row.Cells[i].Text = string.Empty;
                            }
                        }

                        if (i == (e.Row.Cells.Count - 1))
                            e.Row.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                    }
                }
                if (e.Row.RowIndex < RowCount)
                {

                    if (cid == Convert.ToInt32(ds.Tables[2].Rows[e.Row.RowIndex]["ClientID"]))
                    {
                        GridView1.Rows[FirstRow].Cells[0].RowSpan += 1;
                        e.Row.Cells[0].Visible = false;
                    }
                    else
                    {
                        FirstRow = e.Row.RowIndex;
                        cid = Convert.ToInt32(ds.Tables[2].Rows[e.Row.RowIndex]["ClientID"]);
                        e.Row.Cells[0].RowSpan = 1;
                    }
                }
            }
        }

        public void BindControls()
        {
            ds = new DataSet();
            dt = new DataTable();
            ds = this.ReportControllerInstance.GetClientsWeeklyStylesQuantity();

            if (ds.Tables.Count > 0)
            {
                Colcount = 7;
                RowCount = ds.Tables[2].Rows.Count;
            }

            dt.Columns.Add("Clients");
            //dt.Columns.Add("Departments");

            dt.Columns.Add("Delayed");

            for (int i = 1; i < Colcount; i++)
            {
                DataColumn col1 = new DataColumn();
                col1.ColumnName = "Week " + (i + 1);
                dt.Columns.Add(col1);
            }

            dt.Columns.Add("Total");

            int[] totalQuantity = new int[7];
            foreach (int item in totalQuantity)
            {
                totalQuantity[item] = 0;
            }

            for (int i = 0; i <= RowCount; i++)
            {
                int totalClientSamples = 0;

                DataRow dr = dt.NewRow();

                for (int j = 0; j < Colcount; j++)
                {
                    if (i < RowCount)
                    {
                        dr["Clients"] = ds.Tables[2].Rows[i]["CompanyName"];

                        int clientId = Convert.ToInt32(ds.Tables[2].Rows[i]["ClientId"]);

                        int qty = getTotalStylesMade(clientId, (j + 1));

                        // Last Column
                        if (j == 6)
                        {
                            dr["Total"] = totalClientSamples;
                        }

                        if (j == 0)
                        {
                            dr["Delayed"] = qty;
                        }
                        else
                        {
                            dr["Week " + (j + 1)] = qty;
                        }

                        totalClientSamples += qty;

                        totalQuantity[j] += qty;

                    }
                    else if (i == RowCount)
                    {
                        dr["Clients"] = "Total";

                        if (j == 0)
                        {
                            dr["Delayed"] = totalQuantity[j];
                        }
                        else
                        {
                            dr["Week " + (j + 1)] = totalQuantity[j];
                        }
                    }
                }

                dt.Rows.Add(dr);
            }

            int total = 0;

            for (int k = 0; k < totalQuantity.Length; k++)
            {
                total += totalQuantity[k];
            }

            dt.Rows[dt.Rows.Count - 1][8] = total;

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        private int getTotalStylesMade(int ClientID, int WeekValue)
        {
            DataTable dt1 = ds.Tables[1];

            string strExpr = "ClientID =" + ClientID + " and " + "WeekValue = " + WeekValue;

            DataRow[] DataRows = dt1.Select(strExpr);

            return DataRows.Length > 0 ? Convert.ToInt32(DataRows[0]["TotalStylesMade"]) : 0;

        }
    }
}