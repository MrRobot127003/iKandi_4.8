using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;

namespace iKandi.Web.Internal.Reports
{
    public partial class frmAccessory_PoSrv_Report : System.Web.UI.Page
    {
        AdminController objAdminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrdView();
            }
        }

        protected void BindGrdView() {
            DataSet ds = objAdminController.GetAccessoryPoSrvReport();
            GrdAccessoryPoSrvReport.DataSource = ds.Tables[0];
            GrdAccessoryPoSrvReport.DataBind();
        }
        protected void GrdAccessoryPoSrvReport_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblSize = (Label)e.Row.FindControl("lblSize");
                Label lblColorPrint = (Label)e.Row.FindControl("lblColorPrint");
                HiddenField hdnUnitChange = (HiddenField)e.Row.FindControl("hdnUnitChange");
                Label lblGarmentUnitName = (Label)e.Row.FindControl("lblGarmentUnitName");
                Label lblPODate = (Label)e.Row.FindControl("lblPODate");

                if (lblSize.Text != "") {
                    lblSize.Text = "(" + lblSize.Text + ")";
                }
                if (lblGarmentUnitName.Text != "")
                {
                    lblGarmentUnitName.Text = "(" + lblGarmentUnitName.Text + ")";
                }
                if (Convert.ToString(hdnUnitChange.Value) == "True") {
                    lblGarmentUnitName.Attributes.Add("style","background:yellow");
                }
                    lblPODate.Text=Convert.ToDateTime(lblPODate.Text).ToString("dd MMM");

            }
        }
        protected void GrdAccessoryPoSrvReport_DataBound(object sender, EventArgs e) {
            for (int i = GrdAccessoryPoSrvReport.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = GrdAccessoryPoSrvReport.Rows[i];
                GridViewRow previousRow = GrdAccessoryPoSrvReport.Rows[i - 1];


                Label lblAccessoryName = (Label)row.FindControl("lblAccessoryName");
                Label lblPreviousAccessoryName = (Label)previousRow.FindControl("lblAccessoryName");

                Label lblSize = (Label)row.FindControl("lblSize");
                Label lblPreviousSize = (Label)previousRow.FindControl("lblSize");

                Label lblColorPrint = (Label)row.FindControl("lblColorPrint");
                Label lblPreviousColorPrint = (Label)previousRow.FindControl("lblColorPrint");

                Label lblPOType = (Label)row.FindControl("lblPOType");
                Label lbPreviousPOType = (Label)previousRow.FindControl("lblPOType");

                Label lblPO_Number = (Label)row.FindControl("lblPO_Number");
                Label lblPreviousPO_Number = (Label)previousRow.FindControl("lblPO_Number");

                Label lblTotalPoQty = (Label)row.FindControl("lblTotalPoQty");
                Label lblPreviousTotalPoQty = (Label)previousRow.FindControl("lblTotalPoQty");

                Label lblPODate = (Label)row.FindControl("lblPODate");
                Label lblPreviousPODate = (Label)previousRow.FindControl("lblPODate");

                //Label lblRecQty = (Label)row.FindControl("lblRecQty");
                //Label lblPreviousRecQty = (Label)previousRow.FindControl("lblRecQty");

                //Label lblPassQty = (Label)row.FindControl("lblPassQty");
                //Label lblPreviousPassQty = (Label)previousRow.FindControl("lblPassQty");

                //Label lblHoldQty = (Label)row.FindControl("lblHoldQty");
                //Label lblPreviousHoldQty = (Label)previousRow.FindControl("lblHoldQty");

                //Label lblFourPointCheckRecQty = (Label)row.FindControl("lblFourPointCheckRecQty");
                //Label lblPreviousFourPointCheckRecQty = (Label)previousRow.FindControl("lblFourPointCheckRecQty");

                //Label lblStatus = (Label)row.FindControl("lblStatus");
                //Label lblPreviousStatus = (Label)previousRow.FindControl("lblStatus");

                if ((lblAccessoryName.Text == lblPreviousAccessoryName.Text) && (lblSize.Text == lblPreviousSize.Text) && (lblColorPrint.Text == lblPreviousColorPrint.Text))
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                }



                if (lblPOType.Text == lbPreviousPOType.Text)
                {
                    if (previousRow.Cells[1].RowSpan == 0)
                    {
                        if (row.Cells[1].RowSpan == 0)
                        {
                            previousRow.Cells[1].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[1].RowSpan = row.Cells[1].RowSpan + 1;
                        }
                        row.Cells[1].Visible = false;
                    }
                }

                if (lblPO_Number.Text == lblPreviousPO_Number.Text)
                {
                    if (previousRow.Cells[2].RowSpan == 0)
                    {
                        if (row.Cells[2].RowSpan == 0)
                        {
                            previousRow.Cells[2].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[2].RowSpan = row.Cells[2].RowSpan + 1;
                        }
                        row.Cells[2].Visible = false;
                    }
                }

                if (lblTotalPoQty.Text == lblPreviousTotalPoQty.Text)
                {
                    if (previousRow.Cells[3].RowSpan == 0)
                    {
                        if (row.Cells[3].RowSpan == 0)
                        {
                            previousRow.Cells[3].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[3].RowSpan = row.Cells[3].RowSpan + 1;
                        }
                        row.Cells[3].Visible = false;
                    }
                }

                if (lblPODate.Text == lblPreviousPODate.Text)
                {
                    if (previousRow.Cells[4].RowSpan == 0)
                    {
                        if (row.Cells[4].RowSpan == 0)
                        {
                            previousRow.Cells[4].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[4].RowSpan = row.Cells[4].RowSpan + 1;
                        }
                        row.Cells[4].Visible = false;
                    }
                }
            }
        }
        protected void GrdAccessoryPoSrvReport_RowCreated(object sender, GridViewRowEventArgs e) {


            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Accessory Quality (Size)<br> Color Print";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "150px");
                HeaderCell.Attributes.Add("class", "header1");
                HeaderGridRow.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Color Print";
                //HeaderCell.RowSpan = 2;
                ////HeaderCell.ColumnSpan = 4;
                //HeaderCell.Style.Add("text-align", "center");
                //HeaderCell.Attributes.Add("class", "header1");
                //HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Type";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO No. <br> (Unit)";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Raised PO Qty.";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Date";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Challan No.";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SRV Received Qty.";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Four Point Check";
                HeaderCell.ColumnSpan = 5;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                HeaderGridRow.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Status";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                HeaderGridRow.Cells.Add(HeaderCell);

                GrdAccessoryPoSrvReport.Controls[0].Controls.AddAt(0, HeaderGridRow);

                GridViewRow HeaderGridRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Received Qty.";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.Attributes.Add("class", "header1");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "Received Qty.";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.Attributes.Add("class", "header1");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pass Qty.";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Fail Qty.";
                HeaderCell.ColumnSpan = 1;
                HeaderCell.Attributes.Add("class", "header1");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Hold Qty.";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow1.Cells.Add(HeaderCell);

                GrdAccessoryPoSrvReport.Controls[0].Controls.AddAt(1, HeaderGridRow1);

            }
        }
    }
}