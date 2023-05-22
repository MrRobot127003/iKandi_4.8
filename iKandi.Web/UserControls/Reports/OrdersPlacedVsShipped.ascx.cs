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
using iKandi.Common;
using iKandi.Web.Components;
using System.Collections.Generic;

namespace iKandi.Web
{
    public partial class OrdersPlacedVsShipped : BaseUserControl
    {
        DataSet dsOrdersPlacesVsShipped;
        DataTable dtOrdersPlacedVsShipped;
        int count = 0;
        bool IsExtraheaderCreated = false;
        int rowCount = 0;

        protected void Page_Load(object sender, EventArgs e)
        {           
                BindControls();            
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
                if (dsOrdersPlacesVsShipped != null)
                {
                    if (dsOrdersPlacesVsShipped != null && dsOrdersPlacesVsShipped.Tables[0].Rows.Count > 0 || dsOrdersPlacesVsShipped.Tables[1].Rows.Count > 0
                        || dsOrdersPlacesVsShipped.Tables[2].Rows.Count > 0 || dsOrdersPlacesVsShipped.Tables[3].Rows.Count > 0)
                    {
                        GridView HeaderGrid = (GridView)sender;
                        GridViewRow HeaderGridRow =
                        new GridViewRow(0, 0, DataControlRowType.Header,
                        DataControlRowState.Insert);

                        DayOfWeek day = DateTime.Now.DayOfWeek;
                        int days = day - DayOfWeek.Monday;
                        DateTime start = DateTime.Now.AddDays(-days);
                        DateTime end = start.AddDays(6);

                        HeaderGridRow.Cells.Add(PrepareHeaderCell("Duration", "extra_header", 1));
                        HeaderGridRow.Cells.Add(PrepareHeaderCell((start.ToString("dd MMM yy (ddd)") + "-" + end.ToString("dd MMM yy (ddd)")), "extra_header font_color_blue", 2));
                        HeaderGridRow.Cells.Add(PrepareHeaderCell((start.AddDays(-7).ToString("dd MMM yy (ddd)") + "-" + end.ToString("dd MMM yy (ddd)")), "extra_header font_color_blue", 2));
                        HeaderGridRow.Cells.Add(PrepareHeaderCell((start.AddDays(-14).ToString("dd MMM yy (ddd)") + "-" + end.ToString("dd MMM yy (ddd)")), "extra_header font_color_blue", 2));
                        HeaderGridRow.Cells.Add(PrepareHeaderCell((start.AddDays(-21).ToString("dd MMM yy (ddd)") + "-" + end.ToString("dd MMM yy (ddd)")), "extra_header font_color_blue", 2));
                        HeaderGridRow.Cells.Add(PrepareHeaderCell((DateTime.Now.AddMonths(-3).AddDays(1).ToString("dd MMM yy (ddd)") + "-" + DateTime.Now.ToString("dd MMM yy (ddd)")), "extra_header font_color_blue", 2));
                        HeaderGridRow.Cells.Add(PrepareHeaderCell((DateTime.Now.AddMonths(-6).AddDays(1).ToString("dd MMM yy (ddd)") + "-" + DateTime.Now.ToString("dd MMM yy (ddd)")), "extra_header font_color_blue", 2));
                        
                        if (DateTime.Today.Month > 3)
                        {
                            HeaderGridRow.Cells.Add(PrepareHeaderCell(("APR'" + (DateTime.Now.Year.ToString()).Substring(2, 2) + "-MAR'" + ((DateTime.Now.Year + 1).ToString()).Substring(2, 2)), "extra_header font_color_blue", 2));
                        }
                        else
                        {
                            HeaderGridRow.Cells.Add(PrepareHeaderCell(("APR'" + ((DateTime.Now.Year -1) .ToString()).Substring(2, 2) + "-MAR'" + ((DateTime.Now.Year).ToString()).Substring(2, 2)), "extra_header font_color_blue", 2));
                        }

                        gvOrdersPlacedVsShipped.Controls[0].Controls.AddAt(0, HeaderGridRow);

                    }
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
            e.Row.Cells[0].CssClass = "text_align_left";
            if (e.Row.RowType == DataControlRowType.Header)
            {

                for (i = 0; i < e.Row.Cells.Count; i++)
                {
                    if (e.Row.Cells[i].Text.Contains("Placed"))
                    {
                        e.Row.Cells[i].Text = "PLACED";
                    }
                    else if (e.Row.Cells[i].Text.Contains("Shipped"))
                    {
                        e.Row.Cells[i].Text = "SHIPPED";
                    }
                }

            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex < (rowCount + 1))
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
                            if (i < e.Row.Cells.Count - 1)
                            {
                                e.Row.Cells[i + 1].Text = Math.Round(Convert.ToDouble(e.Row.Cells[i + 1].Text), 0) == 0 ? string.Empty : Convert.ToDouble(e.Row.Cells[i + 1].Text).ToString("N0");
                            }
                        }
                    }
                }
                else if (e.Row.RowIndex == (rowCount + 1))
                {
                    for (i = 1; i < e.Row.Cells.Count; i = i + 2)
                    {
                        e.Row.Cells[0].CssClass = "bold_text";
                        e.Row.Cells[i].CssClass = "font_color_blue";
                        e.Row.Cells[0].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                        e.Row.Cells[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                        e.Row.Cells[i].ColumnSpan = 2;
                        if (e.Row.Cells[i + 1].Text != String.Empty && Math.Round(Convert.ToDouble(e.Row.Cells[i + 1].Text), 0) > 0)
                            e.Row.Cells[i].Text = (Convert.ToDecimal(e.Row.Cells[i].Text) / (Convert.ToDecimal(e.Row.Cells[i + 1].Text))).ToString("N2");
                        else
                            e.Row.Cells[i].Text = string.Empty;
                        e.Row.Cells[i + 1].Visible = false;
                    }
                }
            }
        }

        public void BindControls()
        {
            dsOrdersPlacesVsShipped = new DataSet();
            dtOrdersPlacedVsShipped = new DataTable();

            if (!IsPostBack)
            {
                DropdownHelper.BindAllUnits(ddlProductionUnits as ListControl);               
            }


            dsOrdersPlacesVsShipped = this.ReportControllerInstance.GetOrdersPlacedVsShippedReport(Convert.ToInt32(ddlProductionUnits.SelectedValue));

            rowCount = dsOrdersPlacesVsShipped.Tables[4].Rows.Count;

            int i = 1;

            // to Add Header

            dtOrdersPlacedVsShipped.Columns.Add("Client");

            for (i = 1; i <= 7; i++)
            {
                dtOrdersPlacedVsShipped.Columns.Add("Placed" + i);
                dtOrdersPlacedVsShipped.Columns.Add("Shipped" + i);

            }

            Dictionary<string, int> placedTotal = new Dictionary<string, int>()
            {
                {"Placed1", 0}, {"Placed2", 0}, {"Placed3", 0}, {"Placed4", 0}, {"Placed5", 0}, {"Placed6", 0}, {"Placed7", 0}
            };
            Dictionary<string, int> shippedTotal = new Dictionary<string, int>()
            {
                {"Shipped1", 0}, {"Shipped2", 0}, {"Shipped3", 0}, {"Shipped4", 0}, {"Shipped5", 0}, {"Shipped6", 0}, {"Shipped7", 0}
            };
            foreach (DataRow client in dsOrdersPlacesVsShipped.Tables[4].Rows)
            {
                DataRow drShipmentByUnit = dtOrdersPlacedVsShipped.NewRow();
                drShipmentByUnit["Client"] = client["CompanyName"];
                bool atLeastOneData = false;
                foreach (DataRow weeklyPlacedData in dsOrdersPlacesVsShipped.Tables[0].Rows)
                {
                    if (weeklyPlacedData["ClientID"] != DBNull.Value
                        && Convert.ToInt64(client["ClientID"]) == Convert.ToInt64(weeklyPlacedData["ClientID"]))
                    {
                        switch (Convert.ToInt32(weeklyPlacedData["WeekValue"]))
                        {
                            case 1:
                                drShipmentByUnit["Placed1"] = Convert.ToInt32(weeklyPlacedData["TotalOrderPlaced"]);
                                atLeastOneData = true;
                                placedTotal["Placed1"] += Convert.ToInt32(drShipmentByUnit["Placed1"]);
                                break;
                            case 2:
                                drShipmentByUnit["Placed2"] = Convert.ToInt32(weeklyPlacedData["TotalOrderPlaced"]);
                                atLeastOneData = true;
                                placedTotal["Placed2"] += Convert.ToInt32(drShipmentByUnit["Placed2"]);
                                break;
                            case 3:
                                drShipmentByUnit["Placed3"] = Convert.ToInt32(weeklyPlacedData["TotalOrderPlaced"]);
                                atLeastOneData = true;
                                placedTotal["Placed3"] += Convert.ToInt32(drShipmentByUnit["Placed3"]);
                                break;
                            case 4:
                                drShipmentByUnit["Placed4"] = Convert.ToInt32(weeklyPlacedData["TotalOrderPlaced"]);
                                atLeastOneData = true;
                                placedTotal["Placed4"] += Convert.ToInt32(drShipmentByUnit["Placed4"]);
                                break;
                            default:
                                break;
                        }
                    }
                }
                foreach (DataRow weeklyShippedData in dsOrdersPlacesVsShipped.Tables[1].Rows)
                {
                    if (weeklyShippedData["ClientID"] != DBNull.Value
                        && Convert.ToInt64(client["ClientID"]) == Convert.ToInt64(weeklyShippedData["ClientID"]))
                    {
                        switch (Convert.ToInt32(weeklyShippedData["WeekValue"]))
                        {
                            case 1:
                                drShipmentByUnit["Shipped1"] = Convert.ToInt32(weeklyShippedData["TotalOrderShipped"]);
                                atLeastOneData = true;
                                shippedTotal["Shipped1"] += Convert.ToInt32(drShipmentByUnit["Shipped1"]);
                                break;
                            case 2:
                                drShipmentByUnit["Shipped2"] = Convert.ToInt32(weeklyShippedData["TotalOrderShipped"]);
                                atLeastOneData = true;
                                shippedTotal["Shipped2"] += Convert.ToInt32(drShipmentByUnit["Shipped2"]);
                                break;
                            case 3:
                                drShipmentByUnit["Shipped3"] = Convert.ToInt32(weeklyShippedData["TotalOrderShipped"]);
                                atLeastOneData = true;
                                shippedTotal["Shipped3"] += Convert.ToInt32(drShipmentByUnit["Shipped3"]);
                                break;
                            case 4:
                                drShipmentByUnit["Shipped4"] = Convert.ToInt32(weeklyShippedData["TotalOrderShipped"]);
                                atLeastOneData = true;
                                shippedTotal["Shipped4"] += Convert.ToInt32(drShipmentByUnit["Shipped4"]);
                                break;
                            default:
                                break;
                        }
                    }
                }
                foreach (DataRow threeMonthsPlacedData in dsOrdersPlacesVsShipped.Tables[7].Rows)
                {
                    if (threeMonthsPlacedData["ClientID"] != DBNull.Value
                        && Convert.ToInt64(client["ClientID"]) == Convert.ToInt64(threeMonthsPlacedData["ClientID"]))
                    {
                        drShipmentByUnit["Placed5"] = Convert.ToInt32(threeMonthsPlacedData["TotalOrderPlaced"]);
                        atLeastOneData = true;
                        placedTotal["Placed5"] += Convert.ToInt32(drShipmentByUnit["Placed5"]);
                    }
                }
                foreach (DataRow threeMonthsShippedData in dsOrdersPlacesVsShipped.Tables[8].Rows)
                {
                    if (threeMonthsShippedData["ClientID"] != DBNull.Value
                        && Convert.ToInt64(client["ClientID"]) == Convert.ToInt64(threeMonthsShippedData["ClientID"]))
                    {
                        drShipmentByUnit["Shipped5"] = Convert.ToInt32(threeMonthsShippedData["TotalOrderShipped"]);
                        atLeastOneData = true;
                        shippedTotal["Shipped5"] += Convert.ToInt32(drShipmentByUnit["Shipped5"]);
                    }
                }
                foreach (DataRow sixMonthsPlacedData in dsOrdersPlacesVsShipped.Tables[5].Rows)
                {
                    if (sixMonthsPlacedData["ClientID"] != DBNull.Value
                        && Convert.ToInt64(client["ClientID"]) == Convert.ToInt64(sixMonthsPlacedData["ClientID"]))
                    {
                        drShipmentByUnit["Placed6"] = Convert.ToInt32(sixMonthsPlacedData["TotalOrderPlaced"]);
                        atLeastOneData = true;
                        placedTotal["Placed6"] += Convert.ToInt32(drShipmentByUnit["Placed6"]);
                    }
                }
                foreach (DataRow sixMonthsShippedData in dsOrdersPlacesVsShipped.Tables[6].Rows)
                {
                    if (sixMonthsShippedData["ClientID"] != DBNull.Value
                        && Convert.ToInt64(client["ClientID"]) == Convert.ToInt64(sixMonthsShippedData["ClientID"]))
                    {
                        drShipmentByUnit["Shipped6"] = Convert.ToInt32(sixMonthsShippedData["TotalOrderShipped"]);
                        atLeastOneData = true;
                        shippedTotal["Shipped6"] += Convert.ToInt32(drShipmentByUnit["Shipped6"]);
                    }
                }
                foreach (DataRow yearlyPlacedData in dsOrdersPlacesVsShipped.Tables[9].Rows)
                {
                    if (yearlyPlacedData["ClientID"] != DBNull.Value
                        && Convert.ToInt64(client["ClientID"]) == Convert.ToInt64(yearlyPlacedData["ClientID"]))
                    {
                        drShipmentByUnit["Placed7"] = Convert.ToInt32(yearlyPlacedData["TotalOrderPlaced"]);
                        atLeastOneData = true;
                        placedTotal["Placed7"] += Convert.ToInt32(drShipmentByUnit["Placed7"]);
                    }
                }
                foreach (DataRow yearlyShippedData in dsOrdersPlacesVsShipped.Tables[10].Rows)
                {
                    if (yearlyShippedData["ClientID"] != DBNull.Value
                        && Convert.ToInt64(client["ClientID"]) == Convert.ToInt64(yearlyShippedData["ClientID"]))
                    {
                        drShipmentByUnit["Shipped7"] = Convert.ToInt32(yearlyShippedData["TotalOrderShipped"]);
                        atLeastOneData = true;
                        shippedTotal["Shipped7"] += Convert.ToInt32(drShipmentByUnit["Shipped7"]);
                    }
                }

                if (atLeastOneData)
                {
                    dtOrdersPlacedVsShipped.Rows.Add(drShipmentByUnit);
                }
            }
            DataRow drShipmentByUnitTotal = dtOrdersPlacedVsShipped.NewRow();
            drShipmentByUnitTotal["Client"] = "Total";
            drShipmentByUnitTotal["Placed1"] = placedTotal["Placed1"];
            drShipmentByUnitTotal["Placed2"] = placedTotal["Placed2"];
            drShipmentByUnitTotal["Placed3"] = placedTotal["Placed3"];
            drShipmentByUnitTotal["Placed4"] = placedTotal["Placed4"];
            drShipmentByUnitTotal["Placed5"] = placedTotal["Placed5"];
            drShipmentByUnitTotal["Placed6"] = placedTotal["Placed6"];
            drShipmentByUnitTotal["Placed7"] = placedTotal["Placed7"];
            drShipmentByUnitTotal["Shipped1"] = shippedTotal["Shipped1"];
            drShipmentByUnitTotal["Shipped2"] = shippedTotal["Shipped2"];
            drShipmentByUnitTotal["Shipped3"] = shippedTotal["Shipped3"];
            drShipmentByUnitTotal["Shipped4"] = shippedTotal["Shipped4"];
            drShipmentByUnitTotal["Shipped5"] = shippedTotal["Shipped5"];
            drShipmentByUnitTotal["Shipped6"] = shippedTotal["Shipped6"];
            drShipmentByUnitTotal["Shipped7"] = shippedTotal["Shipped7"];
            dtOrdersPlacedVsShipped.Rows.Add(drShipmentByUnitTotal);

            DataRow drShipmentByRatio = dtOrdersPlacedVsShipped.NewRow();
            drShipmentByRatio["Client"] = "Ratio";
            drShipmentByRatio["Placed1"] = placedTotal["Placed1"];
            drShipmentByRatio["Placed2"] = placedTotal["Placed2"];
            drShipmentByRatio["Placed3"] = placedTotal["Placed3"];
            drShipmentByRatio["Placed4"] = placedTotal["Placed4"];
            drShipmentByRatio["Placed5"] = placedTotal["Placed5"];
            drShipmentByRatio["Placed6"] = placedTotal["Placed6"];
            drShipmentByRatio["Placed7"] = placedTotal["Placed7"];
            drShipmentByRatio["Shipped1"] = shippedTotal["Shipped1"];
            drShipmentByRatio["Shipped2"] = shippedTotal["Shipped2"];
            drShipmentByRatio["Shipped3"] = shippedTotal["Shipped3"];
            drShipmentByRatio["Shipped4"] = shippedTotal["Shipped4"];
            drShipmentByRatio["Shipped5"] = shippedTotal["Shipped5"];
            drShipmentByRatio["Shipped6"] = shippedTotal["Shipped6"];
            drShipmentByRatio["Shipped7"] = shippedTotal["Shipped7"];
            dtOrdersPlacedVsShipped.Rows.Add(drShipmentByRatio);


            // to bind grid
            IsExtraheaderCreated = false;
            count = dtOrdersPlacedVsShipped.Rows.Count;
            gvOrdersPlacedVsShipped.DataSource = dtOrdersPlacedVsShipped;
            gvOrdersPlacedVsShipped.DataBind();

        }
    }
}