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

namespace iKandi.Web
{
    public partial class WhereAreMyOrders : BaseUserControl
    {
        #region Properties

        public int DateType
        {
            get;
            set;
        }

        public int PriceType
        {
            get;
            set;
        }

        #endregion

        DataSet dsWhereAreMyOrders;
        DataTable dtWhereAreMyOrdersTable;
        int count = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindControls();
            }

        }

        protected void btnGo_click(object sender, EventArgs e)
        {
            BindControls();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            iKandi.BLL.Configuration.Configuration config = new iKandi.BLL.Configuration.Configuration();
            int i = 0;
            GridView grid = (GridView)sender;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9ddf4");

                if (e.Row.RowIndex == count - 1 || e.Row.Cells[0].Text == "Total")
                {
                    e.Row.Cells[0].CssClass = "bold_text";
                }

                for (i = 1; i < e.Row.Cells.Count; i++)
                {

                    if (e.Row.RowIndex == count - 1 || e.Row.Cells[0].Text == "Total")
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                        e.Row.Cells[i].CssClass = "quantity_style";
                    }
                    else
                    {
                        e.Row.Cells[i].CssClass = "font_color_blue";
                    }
                }

                for (i = 1; i < e.Row.Cells.Count; i = i + 2)
                {
                    if (e.Row.Cells[i].Text != "&nbsp;")
                    {
                        e.Row.Cells[i].Text = Math.Round(Convert.ToDouble(e.Row.Cells[i].Text), 0) == 0 ? string.Empty : Convert.ToDouble(e.Row.Cells[i].Text).ToString("N0");
                        if (i < e.Row.Cells.Count - 1 && e.Row.Cells[i+1].Text != "&nbsp;")
                        {
                            e.Row.Cells[i+1].Text = Math.Round(Convert.ToDouble(e.Row.Cells[i+1].Text), 0) == 0 ? string.Empty : Convert.ToDouble(e.Row.Cells[i+1].Text).ToString("N0");
                        }
                    }
                }
            }
        }


        public void BindControls()
        {
            dsWhereAreMyOrders = new DataSet();
            dtWhereAreMyOrdersTable = new DataTable();


            dsWhereAreMyOrders = this.ReportControllerInstance.GetWhereAreMyOrdersReport();
            DataTable dtWhereAreMyOrders = dsWhereAreMyOrders.Tables[0];
            DataRow drWhereAreMyOrdersTotal = dtWhereAreMyOrders.NewRow();
            int totalContracts = 0;
            int totalQuantity = 0;
            foreach (DataRow row in dtWhereAreMyOrders.Rows)
            {
                totalContracts += row["NumberOfContracts"] != DBNull.Value ? Convert.ToInt32(row["NumberOfContracts"]) : 0;
                totalQuantity += row["TotalQuantity"] != DBNull.Value ? Convert.ToInt32(row["TotalQuantity"]) : 0;
            }
            drWhereAreMyOrdersTotal["Name"] = "TOTAL";
            drWhereAreMyOrdersTotal["NumberOfContracts"] = totalContracts;
            drWhereAreMyOrdersTotal["TotalQuantity"] = totalQuantity;
            dtWhereAreMyOrders.Rows.Add(drWhereAreMyOrdersTotal);

            count = dtWhereAreMyOrders.Rows.Count;
            GridView1.DataSource = dtWhereAreMyOrders;
            GridView1.DataBind();

        }
    }
}