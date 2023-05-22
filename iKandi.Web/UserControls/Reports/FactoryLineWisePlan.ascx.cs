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
    public partial class FactoryLineWisePlan : BaseUserControl
    {
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }

        public void BindControls()
        {
            if (!IsPostBack)
                DropdownHelper.BindAllUnits(ddlUnit as ListControl);

            int UserId = -1;
            UserId = ApplicationHelper.LoggedInUser.UserData.UserID;

            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            if (!string.IsNullOrEmpty(txtfrom.Text))
                fromDate = DateHelper.ParseDate(txtfrom.Text).Value;

            if (!string.IsNullOrEmpty(txtTo.Text))
                toDate = DateHelper.ParseDate(txtTo.Text).Value;

            ds = this.ReportControllerInstance.GetFactoryLineWisePlanReport(txtsearch.Text, fromDate, toDate, Convert.ToInt32(ddlUnit.SelectedValue));
            LoadGrid();
        }

        protected void GridFactoryLine_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (ds.Tables.Count > 0)
                {
                    int count = 0;
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        DataRow dr = ds.Tables[1].Rows[0];
                        if (dr["MaxLines"] != DBNull.Value)
                        {
                            count = Convert.ToInt32(dr["MaxLines"]);

                            GridView HeaderGrid = (GridView)sender;
                            GridViewRow HeaderGridRow =
                            new GridViewRow(0, 0, DataControlRowType.Header,
                            DataControlRowState.Insert);

                            TableCell HeaderCell = new TableCell();

                            HeaderCell.Text = "Order Info.";
                            HeaderCell.CssClass = "extra_header";
                            HeaderCell.ColumnSpan = 11;
                            HeaderGridRow.Cells.Add(HeaderCell);
                            for (int i = 1; i <= count; i++)
                            {
                                HeaderCell = new TableCell();

                                HeaderCell.Text = "Line" + i;
                                HeaderCell.CssClass = "extra_header";
                                HeaderCell.ColumnSpan = 2;
                                HeaderGridRow.Cells.Add(HeaderCell);
                            }

                            GridFactoryLine.Controls[0].Controls.AddAt
                            (0, HeaderGridRow);
                        }

                    }
                }
            }
        }

        protected void GridFactoryLine_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridFactoryLine.PageIndex = e.NewPageIndex;
            BindControls();
        }

        protected void GridFactoryLine_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                OrderDetail od = (e.Row.DataItem as OrderDetail);

                DataRowView drv = (DataRowView)e.Row.DataItem;
                int orderId = Convert.ToInt32(drv["OrderID"]);
                int orderdetailId = Convert.ToInt32(drv["Id"]);
                int quantity = Convert.ToInt32(drv["quantity"]);
                string Serial = drv["SerialNumber"] == DBNull.Value ? "" : drv["SerialNumber"].ToString();
                string StyleNumber = drv["StyleNumber"] == DBNull.Value ? "" : drv["StyleNumber"].ToString();
                string ExFactory = (Convert.ToDateTime((drv["ExFactory"] == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(drv["ExFactory"]))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(drv["ExFactory"])).ToString("dd MMM yy (ddd)");
                int Quantity = drv["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(drv["Quantity"]);
                int StyleID = drv["StyleID"] == DBNull.Value ? 0 : Convert.ToInt32(drv["StyleID"]);
                string ImageURL = drv["SampleImageURL1"] == DBNull.Value ? "" : drv["SampleImageURL1"].ToString();
                string fabric1 = drv["Fabric1"] == DBNull.Value ? string.Empty : Convert.ToString(drv["Fabric1"]);
                string fabric1Detail = drv["Fabric1Details"] == DBNull.Value ? string.Empty : Convert.ToString(drv["Fabric1Details"]);
                string fabric2 = drv["Fabric2"] == DBNull.Value ? string.Empty : Convert.ToString(drv["Fabric2"]);
                string fabric2Detail = drv["Fabric2Details"] == DBNull.Value ? string.Empty : Convert.ToString(drv["Fabric2Details"]);
                string fabric3 = drv["Fabric3"] == DBNull.Value ? string.Empty : Convert.ToString(drv["Fabric3"]);
                string fabric3Detail = drv["Fabric3Details"] == DBNull.Value ? string.Empty : Convert.ToString(drv["Fabric3Details"]);
                string fabric4 = drv["Fabric4"] == DBNull.Value ? string.Empty : Convert.ToString(drv["Fabric4"]);
                string fabric4Detail = drv["Fabric4Details"] == DBNull.Value ? string.Empty : Convert.ToString(drv["Fabric4Details"]);
                string fabric1PercentInHouse = drv["PercentInHouse1"] == DBNull.Value ? string.Empty : Convert.ToString(drv["PercentInHouse1"]);
                string fabric2PercentInHouse = drv["PercentInHouse2"] == DBNull.Value ? string.Empty : Convert.ToString(drv["PercentInHouse2"]);
                string fabric3PercentInHouse = drv["PercentInHouse3"] == DBNull.Value ? string.Empty : Convert.ToString(drv["PercentInHouse3"]);
                string fabric4PercentInHouse = drv["PercentInHouse4"] == DBNull.Value ? string.Empty : Convert.ToString(drv["PercentInHouse4"]);
                int productionUnitId = drv["ProductionUnitId"] == DBNull.Value ? 0 : Convert.ToInt32(drv["ProductionUnitId"]);
                string factoryCode = drv["FactoryCode"] == DBNull.Value ? string.Empty : Convert.ToString(drv["FactoryCode"]);
                string factoryName = drv["FactoryName"] == DBNull.Value ? string.Empty : Convert.ToString(drv["FactoryName"]);
                string ExpFinishDate = (Convert.ToDateTime((drv["ExpectedFinishDate"] == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(drv["ExpectedFinishDate"]))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(drv["ExpectedFinishDate"])).ToString("dd MMM yy (ddd)");
                string StartDate = (Convert.ToDateTime((drv["StartDate"] == DBNull.Value) ? DateTime.MinValue : (Convert.ToDateTime(drv["StartDate"]))) == DateTime.MinValue) ? "" : (Convert.ToDateTime(drv["StartDate"])).ToString("dd MMM yy (ddd)");
                string AccessoryHistory = string.Empty;
                DateTime accDate = DateTime.MinValue;
                int accPercentInHouse = 0;
                String accName = string.Empty;
                int cuttingPer = 0;
                string fabricDetail = string.Empty;
                string line = drv["Line"] == DBNull.Value ? string.Empty : Convert.ToString(drv["Line"]);
                int PcsStitched = drv["PcsStitched"] == DBNull.Value ? 0 : Convert.ToInt32(drv["PcsStitched"]);
                int PcsStitchedPerDay = drv["PcsStitchedPerDay"] == DBNull.Value ? 0 : Convert.ToInt32(drv["PcsStitchedPerDay"]);

                var lineNo = line.Trim().Split('e');

                if (fabric1 != string.Empty)
                    fabricDetail = fabricDetail + "<nobr>" + fabric1 + " : " + fabric1Detail + " (" + fabric1PercentInHouse + "%)" + "</nobr>" + "<br/>";
                if (fabric2 != string.Empty)
                    fabricDetail = fabricDetail + "<nobr>" + fabric2 + " : " + fabric2Detail + " (" + fabric2PercentInHouse + "%)" + "</nobr>" + "<br/>";
                if (fabric3 != string.Empty)
                    fabricDetail = fabricDetail + "<nobr>" + fabric3 + " : " + fabric3Detail + " (" + fabric3PercentInHouse + "%)" + "</nobr>" + "<br/>";
                if (fabric4 != string.Empty)
                    fabricDetail = fabricDetail + "<nobr>" + fabric4 + " : " + fabric4Detail + " (" + fabric4PercentInHouse + "%)" + "</nobr>";

                Label iKandiSerial = e.Row.FindControl("iKandiSerial") as Label;
                iKandiSerial.Text = Serial;
                iKandiSerial.Style.Add("height", "80px");
                (iKandiSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(DateHelper.ParseDate(ExFactory).Value));
                e.Row.Cells[0].Controls.Add(iKandiSerial);

                Label StyleNo = e.Row.FindControl("StyleNo") as Label;
                StyleNo.Text = StyleNumber + "<br/>";

                ((Label)e.Row.FindControl("Qty")).Text = Quantity.ToString("N0");

                Label FabricDetails = e.Row.FindControl("FabricDetails") as Label;
                FabricDetails.Text = fabricDetail;
                e.Row.Cells[4].Controls.Add(FabricDetails);

                HtmlImage img = new HtmlImage();
                img.Src = ResolveUrl("~/uploads/style/thumb-" + ImageURL);
                img.Attributes.Add("border", "0px");
                img.Attributes.Add("height", "75px");

                HyperLink hypStyle = new HyperLink();
                hypStyle.Attributes.Add("onclick", "javascript:showStylePhotoWithOutScroll('" + StyleID + "','" + orderId + "','" + orderdetailId + "')");
                hypStyle.Controls.Add(img);
                e.Row.Cells[1].Controls.Add(hypStyle);

                DataRow drHistory = getAccessoryHistory(orderdetailId);
                accDate = (drHistory["Date"] == DBNull.Value) ? DateTime.MinValue : Convert.ToDateTime(drHistory["Date"]);
                accPercentInHouse = (drHistory["PercentInHouse"] == DBNull.Value) ? 0 : Convert.ToInt32(drHistory["PercentInHouse"]);
                accName = (drHistory["AccessoryName"] == DBNull.Value) ? string.Empty : drHistory["AccessoryName"].ToString();
                AccessoryHistory += "<nobr>" + accName + " " + accPercentInHouse + "% on" + " " + accDate.ToString("dd MMM yy (ddd)") + "</nobr>" + "<br/>";


                DataRow[] dr = getAccessoryCollection(orderId);
                foreach (DataRow row in dr)
                {
                    string AccessoryName = (row["AccessoryName"] == DBNull.Value) ? string.Empty : row["AccessoryName"].ToString();
                    if (AccessoryHistory != null && AccessoryHistory != string.Empty)
                    {
                        if (AccessoryHistory.IndexOf(AccessoryName) == -1)
                        {
                            AccessoryHistory += "<nobr>" + AccessoryName + " " + "0% on" + " " + DateTime.Today.ToString("dd MMM yy (ddd)") + "</nobr>" + "<br/>";
                        }
                    }
                    else
                    {
                        AccessoryHistory += "<nobr>" + AccessoryName + " " + "0% on" + " " + DateTime.Today.ToString("dd MMM yy (ddd)") + "</nobr>" + "<br/>";
                    }
                }

                Label lblAccessories = e.Row.FindControl("Accessories") as Label;
                if (AccessoryHistory != null)
                {
                    if (AccessoryHistory.IndexOf("<br/>") > -1)
                    {
                        string[] delim = { "<br/>" };
                        string[] AccessoryHistoryarray = AccessoryHistory.Split(delim, StringSplitOptions.None);
                        for (int i = 0; i < AccessoryHistoryarray.Length; i++)
                        {
                            Label lbl = new Label();
                            lbl.Text = AccessoryHistoryarray[i] + "<br/>";
                            if (i % 2 == 0)
                            {
                                lbl.ForeColor = System.Drawing.ColorTranslator.FromHtml("blue");
                            }

                            lblAccessories.Controls.Add(lbl);
                        }

                    }
                }
                
                e.Row.Cells[5].Controls.Add(lblAccessories);

                if (quantity > 0)
                    cuttingPer = ((drv["PcsCut"] == DBNull.Value ? 0 : Convert.ToInt32(drv["PcsCut"])) * 100) / quantity;

                Label CuttingPer = e.Row.FindControl("CuttingPer") as Label;
                CuttingPer.Text = cuttingPer.ToString() + "%";
                e.Row.Cells[6].Controls.Add(CuttingPer);

                Label Qty = e.Row.FindControl("Qty") as Label;
                Qty.Text = quantity.ToString("N0");
                e.Row.Cells[7].Controls.Add(Qty);

                Label lblStartDate = e.Row.FindControl("lblStartDate") as Label;
                lblStartDate.Text = "<nobr>" + StartDate + "</nobr>";
                e.Row.Cells[8].Controls.Add(lblStartDate);

                Label lblExpFinishdate = e.Row.FindControl("lblExpFinishdate") as Label;
                lblExpFinishdate.Text = "<nobr>" + ExpFinishDate + "</nobr>";
                e.Row.Cells[9].Controls.Add(lblExpFinishdate);

                Label lblExFactory = e.Row.FindControl("lblExFactory") as Label;
                lblExFactory.Text = "<nobr>" + ExFactory + "</nobr>";
                e.Row.Cells[10].Controls.Add(lblExFactory);

                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataRow drC = ds.Tables[1].Rows[0];
                    if (drC["MaxLines"] != DBNull.Value)
                    {
                        int count = Convert.ToInt32(drC["MaxLines"]);
                        hdnCount.Value = count.ToString();
                        for (int i = 1, j = 1; i <= count; i++, j = j + 2)
                        {
                            if (line != string.Empty)
                            {
                                if (i == Convert.ToInt32(lineNo[1]))
                                {
                                    Label lblPcsStitched = e.Row.FindControl("PcsStitched" + i) as Label;
                                    lblPcsStitched.Text = PcsStitched.ToString("N0");
                                    e.Row.Cells[10 + j].Controls.Add(lblPcsStitched);

                                    Label AvgPcsStitched = e.Row.FindControl("AvgPcsStitched" + i) as Label;
                                    if (StartDate != string.Empty)
                                        AvgPcsStitched.Text = PcsStitchedPerDay.ToString("N0");
                                    else
                                        AvgPcsStitched.Text = string.Empty;
                                    e.Row.Cells[11 + j].Controls.Add(AvgPcsStitched);
                                }
                            }
                        }
                    }
                }
            }

        }

        private void LoadGrid()
        {
            if (IsPostBack)
            {
                if (GridFactoryLine.Columns.Count > 0)
                {
                    GridFactoryLine.Columns.Clear();
                }
            }

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {

                    TemplateField iKandiSerial = new TemplateField();
                    iKandiSerial.HeaderText = "Serial No.";
                    iKandiSerial.ItemTemplate = new GridViewTemplate("label", "iKandiSerial", "iKandiSerial");
                    iKandiSerial.HeaderStyle.CssClass = "vertical_header";
                    iKandiSerial.ItemStyle.CssClass = "vertical_text quantity_style";
                    GridFactoryLine.Columns.Insert(0, iKandiSerial);

                    TemplateField StyleNo = new TemplateField();
                    StyleNo.HeaderText = "Style No.";
                    StyleNo.ItemTemplate = new GridViewTemplate("label", "StyleNo", "StyleNo");
                    StyleNo.HeaderStyle.CssClass = "nobr";
                    StyleNo.ItemStyle.CssClass = "nobr";
                    GridFactoryLine.Columns.Insert(1, StyleNo);

                    BoundField LineItemNumber = new BoundField();
                    LineItemNumber.HeaderText = "Line No";
                    LineItemNumber.HeaderStyle.CssClass = "vertical_header";
                    LineItemNumber.ItemStyle.CssClass = "vertical_text";
                    LineItemNumber.DataField = "LineItemNumber";
                    GridFactoryLine.Columns.Insert(2, LineItemNumber);

                    BoundField ContractNumber = new BoundField();
                    ContractNumber.HeaderText = "Contract No";
                    ContractNumber.DataField = "ContractNumber";
                    ContractNumber.HeaderStyle.CssClass = "vertical_header";
                    ContractNumber.ItemStyle.CssClass = "vertical_text";
                    GridFactoryLine.Columns.Insert(3, ContractNumber);

                    TemplateField Fabrics = new TemplateField();
                    Fabrics.HeaderText = "Fabric/details";
                    Fabrics.ItemTemplate = new GridViewTemplate("label", "FabricDetails", "FabricDetails");
                    GridFactoryLine.Columns.Insert(4, Fabrics);

                    TemplateField Accessoriess = new TemplateField();
                    Accessoriess.HeaderText = "Accessories";
                    Accessoriess.ItemTemplate = new GridViewTemplate("label", "Accessories", "Accessories");
                    Accessoriess.ItemStyle.CssClass = "remarks_text2 remarks_text";
                    Accessoriess.HeaderStyle.Width = 200;
                    Accessoriess.ItemStyle.Width = 200;
                    GridFactoryLine.Columns.Insert(5, Accessoriess);

                    TemplateField CuttingPer = new TemplateField();
                    CuttingPer.HeaderText = "Cutting %";
                    CuttingPer.ItemTemplate = new GridViewTemplate("label", "CuttingPer", "CuttingPer");
                    CuttingPer.ItemStyle.CssClass = "numeric_style quantity_style vertical_text";
                    CuttingPer.HeaderStyle.CssClass = "vertical_header";
                    GridFactoryLine.Columns.Insert(6, CuttingPer);

                    TemplateField Quantity = new TemplateField();
                    Quantity.HeaderText = "Total Quantity";
                    Quantity.ItemTemplate = new GridViewTemplate("label", "Qty", "Qty");
                    Quantity.ItemStyle.CssClass = "numeric_style quantity_style vertical_text";
                    Quantity.HeaderStyle.CssClass = "vertical_header";
                    GridFactoryLine.Columns.Insert(7, Quantity);

                    TemplateField StartDate = new TemplateField();
                    StartDate.HeaderText = "Start Date";
                    StartDate.ItemTemplate = new GridViewTemplate("label", "lblStartDate", "lblStartDate");
                    StartDate.ItemStyle.CssClass = "date_style mo_bulk_in_house_style ";
                    StartDate.HeaderStyle.CssClass = "mo_bulk_in_house_style ";
                    GridFactoryLine.Columns.Insert(8, StartDate);

                    TemplateField ExpFinishdate = new TemplateField();
                    ExpFinishdate.HeaderText = "Exp. Finish Date";
                    ExpFinishdate.ItemTemplate = new GridViewTemplate("label", "lblExpFinishdate", "lblExpFinishdate");
                    ExpFinishdate.ItemStyle.CssClass = "date_style mo_bulk_in_house_style ";
                    ExpFinishdate.HeaderStyle.CssClass = "mo_bulk_in_house_style ";
                    GridFactoryLine.Columns.Insert(9, ExpFinishdate);

                    TemplateField ExFactory = new TemplateField();
                    ExFactory.HeaderText = "ExFactory";
                    ExFactory.ItemTemplate = new GridViewTemplate("label", "lblExFactory", "lblExFactory");
                    ExFactory.ItemStyle.CssClass = "date_style mo_bulk_in_house_style ";
                    ExFactory.HeaderStyle.CssClass = "mo_bulk_in_house_style ";
                    GridFactoryLine.Columns.Insert(10, ExFactory);

                    GridFactoryLine.DataSource = ds.Tables[0];
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[1].Rows[0];
                    if (dr["MaxLines"] != DBNull.Value)
                    {
                        int count = Convert.ToInt32(dr["MaxLines"]);
                        hdnCount.Value = count.ToString();
                        for (int i = 1; i <= count; i++)
                        {
                            TemplateField pcsStitched = new TemplateField();
                            pcsStitched.HeaderText = "Pcs Stitched";
                            pcsStitched.ItemTemplate = new GridViewTemplate("label", "PcsStitched" + i, "PcsStitched" + i);
                            pcsStitched.HeaderStyle.CssClass = "vertical_header ";
                            pcsStitched.ItemStyle.CssClass = "vertical_text quantity_style";

                            TemplateField avgPcsStitched = new TemplateField();
                            avgPcsStitched.HeaderText = "Pcs Stchd. / day";
                            avgPcsStitched.ItemTemplate = new GridViewTemplate("label", "AvgPcsStitched" + i, "AvgPcsStitched" + i);
                            avgPcsStitched.HeaderStyle.CssClass = "vertical_header";
                            avgPcsStitched.ItemStyle.CssClass = "vertical_text quantity_style";

                            GridFactoryLine.Columns.Add(pcsStitched);
                            GridFactoryLine.Columns.Add(avgPcsStitched);
                        }
                    }
                }
                GridFactoryLine.DataBind();
            }
        }

        private DataRow[] getAccessoryCollection(int orderId)
        {
            DataTable dt = ds.Tables[3];
            string strExpr = "OrderID =" + orderId;
            DataRow[] DataRows = dt.Select(strExpr);
            return DataRows;
        }

        private DataRow getAccessoryHistory(int OrderDetailID)
        {
            DataTable dt = ds.Tables[2];
            string strExpr = "OrderDetailID = " + OrderDetailID;
            DataRow[] DataRows = dt.Select(strExpr);
            return DataRows.Length > 0 ? DataRows[0] : dt.NewRow();
        }

    }
}