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
using System.Collections.Generic;

namespace iKandi.Web
{
    public partial class ShipmentByUnit : BaseUserControl
    {
        DataSet dsShipmentByUnit;
        DataTable dtShipmentByUnit;
        int count = 0;
        bool IsExtraheaderCreated = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                if (dsShipmentByUnit.Tables[2].Rows.Count > 0 || dsShipmentByUnit.Tables[3].Rows.Count > 0)
                {
                    GridView HeaderGrid = (GridView)sender;
                    GridViewRow HeaderGridRow =
                    new GridViewRow(0, 0, DataControlRowType.Header,
                    DataControlRowState.Insert);

                    HeaderGridRow.Cells.Add(PrepareHeaderCell("Duration", "extra_header", 2));
                    HeaderGridRow.Cells.Add(PrepareHeaderCell("1 Week", "extra_header font_color_blue", 2));
                    HeaderGridRow.Cells.Add(PrepareHeaderCell("2 Week", "extra_header font_color_blue", 2));
                    HeaderGridRow.Cells.Add(PrepareHeaderCell("3 Week", "extra_header font_color_blue", 2));
                    HeaderGridRow.Cells.Add(PrepareHeaderCell("4 Week", "extra_header font_color_blue", 2));
                    HeaderGridRow.Cells.Add(PrepareHeaderCell("1 Month", "extra_header font_color_blue", 2));
                    HeaderGridRow.Cells.Add(PrepareHeaderCell("3 Month", "extra_header font_color_blue", 2));
                    HeaderGridRow.Cells.Add(PrepareHeaderCell("6 Month", "extra_header font_color_blue", 2));
                    HeaderGridRow.Cells.Add(PrepareHeaderCell("12 Month", "extra_header font_color_blue", 2));

                    gvShipmentByUnit.Controls[0].Controls.AddAt
                                (0, HeaderGridRow);

                }
                IsExtraheaderCreated = true;
            }

        }

        private static TableCell PrepareHeaderCell(string headerText, string headerClass, int colSpan)
        {
            TableCell HeaderCell = new TableCell();

            HeaderCell.Text = headerText;
            HeaderCell.CssClass = headerClass;
            HeaderCell.ColumnSpan = colSpan;
            return HeaderCell;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            iKandi.BLL.Configuration.Configuration config = new iKandi.BLL.Configuration.Configuration();
            int i = 0;
            GridView grid = (GridView)sender;
            if (e.Row.RowType == DataControlRowType.Header)
            {

                for (i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text.Contains("Qty"))
                    {
                        e.Row.Cells[i].Text = "QTY";
                    }
                    else if (e.Row.Cells[i].Text.Contains("Revenue"))
                    {
                        e.Row.Cells[i].Text = "Revenue";
                    }
                }

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9ddf4");
                e.Row.Cells[1].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9ddf4");

                if (e.Row.RowIndex == count - 1 || e.Row.Cells[0].Text == "Total")
                {
                    e.Row.Cells[0].ColumnSpan = 2;
                    e.Row.Cells[0].CssClass = "bold_text";
                    e.Row.Cells.RemoveAt(1);
                }
                int start = e.Row.RowIndex == count - 1 ? 1 : 2;
                for (i = start; i < e.Row.Cells.Count; i++)
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

                start = e.Row.RowIndex == count - 1 ? 1 : 2;
                for (i = start; i < e.Row.Cells.Count; i = i + 2)
                {
                    if (e.Row.Cells[i].Text != "&nbsp;")
                    {
                        e.Row.Cells[i].Text = Math.Round(Convert.ToDouble(e.Row.Cells[i].Text), 0) == 0 ? string.Empty : Convert.ToDouble(e.Row.Cells[i].Text).ToString("N0");
                        if (i < e.Row.Cells.Count - 1)
                        {
                            e.Row.Cells[i + 1].Text = Math.Round(Convert.ToDouble(e.Row.Cells[i + 1].Text), 0) == 0 ? string.Empty : "&pound;" + Convert.ToDouble(e.Row.Cells[i + 1].Text).ToString("N0");
                        }
                    }
                }
            }
        }


        public void BindControls()
        {
            dsShipmentByUnit = new DataSet();
            dtShipmentByUnit = new DataTable();

            if (!IsPostBack)
            {
                //DropdownHelper.BindProductionUnits(ddlProductionUnits);
                //DropdownHelper.BindClients(ddlClients);
            }


            dsShipmentByUnit = this.ReportControllerInstance.GetShipmentByUnitReport();

            int i = 1;

            // to Add Header

            dtShipmentByUnit.Columns.Add("Client");
            dtShipmentByUnit.Columns.Add("Unit");

            for (i = 1; i <= 8; i++)
            {
                dtShipmentByUnit.Columns.Add("Qty" + i);
                dtShipmentByUnit.Columns.Add("Revenue" + i);

            }

            Dictionary<string, int> qtyTotal = new Dictionary<string, int>()
            {
                {"Qty1", 0}, {"Qty2", 0}, {"Qty3", 0}, {"Qty4", 0}, {"Qty5", 0}, {"Qty6", 0}, {"Qty7", 0}, {"Qty8", 0}
            };
            Dictionary<string, double> revTotal = new Dictionary<string, double>()
            {
                {"Revenue1", 0}, {"Revenue2", 0}, {"Revenue3", 0}, {"Revenue4", 0}, {"Revenue5", 0}, {"Revenue6", 0}, {"Revenue7", 0}, {"Revenue8", 0}
            };
            foreach (DataRow client in dsShipmentByUnit.Tables[0].Rows)
            {
                foreach (DataRow unit in dsShipmentByUnit.Tables[1].Rows)
                {
                    DataRow drShipmentByUnit = dtShipmentByUnit.NewRow();
                    drShipmentByUnit["Client"] = client["CompanyName"];
                    drShipmentByUnit["Unit"] = unit["Name"];
                    bool atLeastOneData = false;
                    foreach (DataRow weeklyData in dsShipmentByUnit.Tables[2].Rows)
                    {
                        if (weeklyData["ClientID"] != DBNull.Value && weeklyData["Id"] != DBNull.Value
                            && Convert.ToInt64(client["ClientID"]) == Convert.ToInt64(weeklyData["ClientID"])
                            && Convert.ToInt64(unit["Id"]) == Convert.ToInt64(weeklyData["Id"]))
                        {
                            switch (Convert.ToInt32(weeklyData["WeekValue"]))
                            {
                                case 1:
                                    drShipmentByUnit["Qty1"] = Convert.ToInt32(weeklyData["TotalQuantity"]);
                                    drShipmentByUnit["Revenue1"] = Convert.ToInt32(weeklyData["Revenue"]);
                                    atLeastOneData = true;
                                    qtyTotal["Qty1"] += Convert.ToInt32(drShipmentByUnit["Qty1"]);
                                    revTotal["Revenue1"] += Convert.ToInt32(drShipmentByUnit["Revenue1"]);
                                    break;
                                case 2:
                                    drShipmentByUnit["Qty2"] = Convert.ToInt32(weeklyData["TotalQuantity"]);
                                    drShipmentByUnit["Revenue2"] = Convert.ToInt32(weeklyData["Revenue"]);
                                    atLeastOneData = true;
                                    qtyTotal["Qty2"] += Convert.ToInt32(drShipmentByUnit["Qty2"]);
                                    revTotal["Revenue2"] += Convert.ToInt32(drShipmentByUnit["Revenue2"]);
                                    break;
                                case 3:
                                    drShipmentByUnit["Qty3"] = Convert.ToInt32(weeklyData["TotalQuantity"]);
                                    drShipmentByUnit["Revenue3"] = Convert.ToInt32(weeklyData["Revenue"]);
                                    atLeastOneData = true;
                                    qtyTotal["Qty3"] += Convert.ToInt32(drShipmentByUnit["Qty3"]);
                                    revTotal["Revenue3"] += Convert.ToInt32(drShipmentByUnit["Revenue3"]);
                                    break;
                                case 4:
                                    drShipmentByUnit["Qty4"] = Convert.ToInt32(weeklyData["TotalQuantity"]);
                                    drShipmentByUnit["Revenue4"] = Convert.ToInt32(weeklyData["Revenue"]);
                                    atLeastOneData = true;
                                    qtyTotal["Qty4"] += Convert.ToInt32(drShipmentByUnit["Qty4"]);
                                    revTotal["Revenue4"] += Convert.ToInt32(drShipmentByUnit["Revenue4"]);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    foreach (DataRow monthlyData in dsShipmentByUnit.Tables[3].Rows)
                    {
                        if (monthlyData["ClientID"] != DBNull.Value && monthlyData["Id"] != DBNull.Value
                            && Convert.ToInt64(client["ClientID"]) == Convert.ToInt64(monthlyData["ClientID"])
                            && Convert.ToInt64(unit["Id"]) == Convert.ToInt64(monthlyData["Id"]))
                        {
                            switch (Convert.ToInt32(monthlyData["MonthValue"]))
                            {
                                case 1:
                                    drShipmentByUnit["Qty5"] = Convert.ToInt32(monthlyData["TotalQuantity"]);
                                    drShipmentByUnit["Revenue5"] = Convert.ToInt32(monthlyData["Revenue"]);
                                    atLeastOneData = true;
                                    qtyTotal["Qty5"] += Convert.ToInt32(drShipmentByUnit["Qty5"]);
                                    revTotal["Revenue5"] += Convert.ToInt32(drShipmentByUnit["Revenue5"]);
                                    break;
                                case 3:
                                    drShipmentByUnit["Qty6"] = Convert.ToInt32(monthlyData["TotalQuantity"]);
                                    drShipmentByUnit["Revenue6"] = Convert.ToInt32(monthlyData["Revenue"]);
                                    atLeastOneData = true;
                                    qtyTotal["Qty6"] += Convert.ToInt32(drShipmentByUnit["Qty6"]);
                                    revTotal["Revenue6"] += Convert.ToInt32(drShipmentByUnit["Revenue6"]);
                                    break;
                                case 6:
                                    drShipmentByUnit["Qty7"] = Convert.ToInt32(monthlyData["TotalQuantity"]);
                                    drShipmentByUnit["Revenue7"] = Convert.ToInt32(monthlyData["Revenue"]);
                                    atLeastOneData = true;
                                    qtyTotal["Qty7"] += Convert.ToInt32(drShipmentByUnit["Qty7"]);
                                    revTotal["Revenue7"] += Convert.ToInt32(drShipmentByUnit["Revenue7"]);
                                    break;
                                case 12:
                                    drShipmentByUnit["Qty8"] = Convert.ToInt32(monthlyData["TotalQuantity"]);
                                    drShipmentByUnit["Revenue8"] = Convert.ToInt32(monthlyData["Revenue"]);
                                    atLeastOneData = true;
                                    qtyTotal["Qty8"] += Convert.ToInt32(drShipmentByUnit["Qty8"]);
                                    revTotal["Revenue8"] += Convert.ToInt32(drShipmentByUnit["Revenue8"]);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    if (atLeastOneData)
                    {
                        dtShipmentByUnit.Rows.Add(drShipmentByUnit);
                    }
                }
            }
            DataRow drShipmentByUnitTotal = dtShipmentByUnit.NewRow();
            drShipmentByUnitTotal["Client"] = "Total";
            drShipmentByUnitTotal["Qty1"] = qtyTotal["Qty1"];
            drShipmentByUnitTotal["Qty2"] = qtyTotal["Qty2"];
            drShipmentByUnitTotal["Qty3"] = qtyTotal["Qty3"];
            drShipmentByUnitTotal["Qty4"] = qtyTotal["Qty4"];
            drShipmentByUnitTotal["Qty5"] = qtyTotal["Qty5"];
            drShipmentByUnitTotal["Qty6"] = qtyTotal["Qty6"];
            drShipmentByUnitTotal["Qty7"] = qtyTotal["Qty7"];
            drShipmentByUnitTotal["Qty8"] = qtyTotal["Qty8"];
            drShipmentByUnitTotal["Revenue1"] = revTotal["Revenue1"];
            drShipmentByUnitTotal["Revenue2"] = revTotal["Revenue2"];
            drShipmentByUnitTotal["Revenue3"] = revTotal["Revenue3"];
            drShipmentByUnitTotal["Revenue4"] = revTotal["Revenue4"];
            drShipmentByUnitTotal["Revenue5"] = revTotal["Revenue5"];
            drShipmentByUnitTotal["Revenue6"] = revTotal["Revenue6"];
            drShipmentByUnitTotal["Revenue7"] = revTotal["Revenue7"];
            drShipmentByUnitTotal["Revenue8"] = revTotal["Revenue8"];
            dtShipmentByUnit.Rows.Add(drShipmentByUnitTotal);


            // to bind grid
            IsExtraheaderCreated = false;
            count = dtShipmentByUnit.Rows.Count;
            gvShipmentByUnit.DataSource = dtShipmentByUnit;
            gvShipmentByUnit.DataBind();

        }
    }
}