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
    public partial class IndPrintCost : BaseUserControl
    {
        int count = 0;
        bool IsExtraheaderCreated = false;
        DataSet dsIndPrintCost;
        DataTable dtIndPrintCost;
        DateTime fromDate = DateTime.MinValue;
        DateTime toDate = DateTime.MinValue;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtTo.Text = DateTime.Now.ToString("dd MMM yy (ddd) ");
                txtFrom.Text = DateTime.Now.AddMonths(-1).ToString("dd MMM yy (ddd) ");
                BindControls();
            }
        }

        protected void btnGo_click(object sender, EventArgs e)
        {
            IsExtraheaderCreated = false;
            BindControls();
        }


        protected void GridView1_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (IsExtraheaderCreated == false)
            {
                GridView HeaderGrid = (GridView)sender;

                GridViewRow HeaderGridRow =
                new GridViewRow(0, 0, DataControlRowType.Header,
                DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.CssClass = "extra_header";
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "IND BLOCK";
                HeaderCell.CssClass = "extra_header ";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Print";
                HeaderCell.CssClass = "extra_header ";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                GridView1.Controls[0].Controls.AddAt
                           (0, HeaderGridRow);


            }
            IsExtraheaderCreated = true;


        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text.Contains("Qty-Ind"))
                    {
                        e.Row.Cells[i].Text = "Qty";
                    }
                    else if (e.Row.Cells[i].Text.Contains("Cost-Ind"))
                    {
                        e.Row.Cells[i].Text = "Cost";
                    }
                    else if (e.Row.Cells[i].Text.Contains("Qty-Print"))
                    {
                        e.Row.Cells[i].Text = "Qty";
                    }
                    else if (e.Row.Cells[i].Text.Contains("Cost-Print"))
                    {
                        e.Row.Cells[i].Text = "cost";
                    }

                }

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 1; i < e.Row.Cells.Count; i++)
                {

                    if (i % 2 == 0)
                    {
                        e.Row.Cells[i].Text = Math.Round(Convert.ToDouble(e.Row.Cells[i].Text), 0) == 0 ? string.Empty : "&pound;" + Convert.ToDouble(e.Row.Cells[i].Text).ToString("N0");

                    }
                    else
                    {
                        e.Row.Cells[i].Text = Math.Round(Convert.ToDouble(e.Row.Cells[i].Text), 0) == 0 ? string.Empty : Convert.ToDouble(e.Row.Cells[i].Text).ToString("N0");
                    }

                    e.Row.Cells[i].CssClass = "font_color_blue";
                    
                }

            }


        }


        private void BindControls()
        {
            dsIndPrintCost = new DataSet();
            dtIndPrintCost = new DataTable();
                                 
            if (!string.IsNullOrEmpty(txtFrom.Text))
                fromDate = DateHelper.ParseDate(txtFrom.Text).Value;
            if (!string.IsNullOrEmpty(txtTo.Text))
                toDate = DateHelper.ParseDate(txtTo.Text).Value;


            dsIndPrintCost = this.ReportControllerInstance.GetIndAndPrintCostReport(fromDate,toDate);

            //To Get Total Number of Rows = total designer
            if (dsIndPrintCost.Tables.Count > 0)
            {
                if (dsIndPrintCost.Tables[2].Rows.Count > 0)
                {
                    count = dsIndPrintCost.Tables[2].Rows.Count;
                }
            }

            //To Get datacolumn
            dtIndPrintCost.Columns.Add("Designer Name");
            dtIndPrintCost.Columns.Add("Qty-Ind");
            dtIndPrintCost.Columns.Add("Cost-Ind");
            dtIndPrintCost.Columns.Add("Qty-Print");
            dtIndPrintCost.Columns.Add("Cost-Print");

           int  totalIndQty = 0;
           int  totalPrintQty = 0;
           double totalIndCost = 0.00;
           double totalPrintCost = 0.00;
            //To Get DataRows
            for (int i = 0; i < count; i++)
            {
                DataRow drIndPrintCost = dtIndPrintCost.NewRow();

                drIndPrintCost["Designer Name"] = dsIndPrintCost.Tables[2].Rows[i]["DesignerName"];

                string strIndBLock = "UserID=" + dsIndPrintCost.Tables[2].Rows[i]["UserID"];
                DataRow[] drIndBlock = dsIndPrintCost.Tables[1].Select(strIndBLock);
                if (drIndBlock.Length > 0)
                {
                    drIndPrintCost["Qty-Ind"] = (drIndBlock[0]["TotalBlock"] == DBNull.Value) ? 0 : Convert.ToInt32(drIndBlock[0]["TotalBlock"]);
                    drIndPrintCost["Cost-Ind"] = (drIndBlock[0]["TotalBlockCost"] == DBNull.Value) ? 0 : Convert.ToDouble(drIndBlock[0]["TotalBlockCost"]);

                    
                }
                else
                {
                   
                    drIndPrintCost["Qty-Ind"] = 0;
                    drIndPrintCost["Cost-Ind"] = 0.00;
                }

                string strPrint = "UserID=" + dsIndPrintCost.Tables[2].Rows[i]["UserID"];
                DataRow[] drPrint = dsIndPrintCost.Tables[0].Select(strPrint);
                if (drPrint.Length > 0)
                {
                    drIndPrintCost["Qty-Print"] = (drPrint[0]["TotalPrints"] == DBNull.Value) ? 0 : Convert.ToInt32(drPrint[0]["TotalPrints"]);
                    drIndPrintCost["Cost-Print"] = (drPrint[0]["TotalPrintCost"] == DBNull.Value) ? 0 : Convert.ToDouble(drPrint[0]["TotalPrintCost"]);
                }
                else
                {
                    drIndPrintCost["Qty-Print"] = 0;
                    drIndPrintCost["Cost-Print"] = 0.00;
                }

                totalIndQty += Convert.ToInt32(drIndPrintCost["Qty-Ind"]);
                totalIndCost += Convert.ToDouble(drIndPrintCost["Cost-Ind"]);
                totalPrintQty += Convert.ToInt32(drIndPrintCost["Qty-Print"]);
                totalPrintCost += Convert.ToDouble(drIndPrintCost["Cost-Print"]);
                


                dtIndPrintCost.Rows.Add(drIndPrintCost);
            }

            DataRow drIndPrintCostTotal = dtIndPrintCost.NewRow();
            drIndPrintCostTotal["Designer Name"] = "Total";
            drIndPrintCostTotal["Qty-Ind"] = totalIndQty;
            drIndPrintCostTotal["Cost-Ind"] = totalIndCost;
            drIndPrintCostTotal["Qty-Print"] = totalPrintQty;
            drIndPrintCostTotal["Cost-Print"] = totalPrintCost;
            dtIndPrintCost.Rows.Add(drIndPrintCostTotal);


            IsExtraheaderCreated = false;
            GridView1.DataSource = dtIndPrintCost;
            GridView1.DataBind();
        }
    }
}