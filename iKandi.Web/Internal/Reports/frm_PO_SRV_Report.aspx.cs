using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;
using System.Data.SqlClient;
using iKandi.Web.Components;

namespace iKandi.Web.Internal.Reports
{
    public partial class frm_PO_SRV_Report : System.Web.UI.Page
    {
        AdminController objAdminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (!IsPostBack)
            {                
                BindgrdPoSRV();
            }
        }

        private void BindgrdPoSRV()
        {
            DataSet ds = objAdminController.GetPoSrvReport();
            grdPO_SRV.DataSource = ds.Tables[0];
            grdPO_SRV.DataBind();
        }

        protected void grdPO_SRV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblFourPointCheckRecQty = (Label)e.Row.FindControl("lblFourPointCheckRecQty");                
                Label lblPassQty = (Label)e.Row.FindControl("lblPassQty");
                Label lblFailQty = (Label)e.Row.FindControl("lblFailQty");
                Label lblHoldQty = (Label)e.Row.FindControl("lblHoldQty");
                Label lblStatus = (Label)e.Row.FindControl("lblStatus");
                Label lblChallanNo = (Label)e.Row.FindControl("lblChallanNo");
                Label lblName = (Label)e.Row.FindControl("lblName");
                Label lblRecQty = (Label)e.Row.FindControl("lblRecQty");

                lblRecQty.Text = (lblRecQty.Text == "0") ? "" : lblRecQty.Text;
                lblFourPointCheckRecQty.Text = (lblFourPointCheckRecQty.Text == "0") ? "" : lblFourPointCheckRecQty.Text;
                lblPassQty.Text = (lblPassQty.Text == "0") ? "" : lblPassQty.Text;
                lblFailQty.Text = (lblFailQty.Text == "0") ? "" : lblFailQty.Text;
                lblHoldQty.Text = (lblHoldQty.Text == "0") ? "" : lblHoldQty.Text;

                if (lblStatus.Text == "0")
                {
                    lblStatus.Text = "Open";
                }
                if (lblStatus.Text == "1")
                {
                    lblStatus.Text = "Cancel";
                    lblStatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#989a9e");
                }
                if (lblStatus.Text == "2")
                {
                    lblStatus.Text = "Close";
                    lblStatus.ForeColor = System.Drawing.ColorTranslator.FromHtml("#989a9e");
                    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#f0f0ed");
                }

                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                lblFourPointCheckRecQty.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4f4f4e");
                lblPassQty.ForeColor = System.Drawing.ColorTranslator.FromHtml("#459437");
                lblFailQty.ForeColor = System.Drawing.ColorTranslator.FromHtml("#de1421");
                lblHoldQty.ForeColor = System.Drawing.ColorTranslator.FromHtml("#000000");

                lblChallanNo.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4f4f4e");
                lblName.ForeColor = System.Drawing.ColorTranslator.FromHtml("#4f4f4e");
            }

        }


        protected void grdPO_SRV_DataBound(object sender, EventArgs e)
        {
            for (int i = grdPO_SRV.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdPO_SRV.Rows[i];
                GridViewRow previousRow = grdPO_SRV.Rows[i - 1];

                Label lblTradeName = (Label)row.FindControl("lblTradeName");
                Label lblPreviousTradeName = (Label)previousRow.FindControl("lblTradeName");

                Label lblFabricDetail = (Label)row.FindControl("lblFabricDetail");
                Label lblPreviousFabricDetail = (Label)previousRow.FindControl("lblFabricDetail");

                Label lblName = (Label)row.FindControl("lblName");
                Label lbPreviouslName = (Label)previousRow.FindControl("lblName");

                Label lblPO_Number = (Label)row.FindControl("lblPO_Number");
                Label lblPreviousPO_Number = (Label)previousRow.FindControl("lblPO_Number");

                Label lblReqQty = (Label)row.FindControl("lblReqQty");
                Label lblPreviousReqQty = (Label)previousRow.FindControl("lblReqQty");

                Label lblChallanNo = (Label)row.FindControl("lblChallanNo");
                Label lblPreviousChallanNo = (Label)previousRow.FindControl("lblChallanNo");

                Label lblRecQty = (Label)row.FindControl("lblRecQty");
                Label lblPreviousRecQty = (Label)previousRow.FindControl("lblRecQty");

                Label lblPassQty = (Label)row.FindControl("lblPassQty");
                Label lblPreviousPassQty = (Label)previousRow.FindControl("lblPassQty");

                Label lblHoldQty = (Label)row.FindControl("lblHoldQty");
                Label lblPreviousHoldQty = (Label)previousRow.FindControl("lblHoldQty");

                Label lblFourPointCheckRecQty = (Label)row.FindControl("lblFourPointCheckRecQty");
                Label lblPreviousFourPointCheckRecQty = (Label)previousRow.FindControl("lblFourPointCheckRecQty");

                Label lblStatus = (Label)row.FindControl("lblStatus");
                Label lblPreviousStatus = (Label)previousRow.FindControl("lblStatus");



                if (lblTradeName.Text == lblPreviousTradeName.Text)
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
                        //row.BackColor = System.Drawing.ColorTranslator.FromHtml("#cbccc8");
                        row.Cells[0].Visible = false;
                    }
                }

                if (lblFabricDetail.Text == lblPreviousFabricDetail.Text && lblTradeName.Text == lblPreviousTradeName.Text)
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
                
                if (lblName.Text == lbPreviouslName.Text)
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

                if (lblPO_Number.Text == lblPreviousPO_Number.Text)
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

                if (lblReqQty.Text == lblPreviousReqQty.Text && lblPO_Number.Text == lblPreviousPO_Number.Text)
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

                if (lblChallanNo.Text == lblPreviousChallanNo.Text)
                {
                    if (previousRow.Cells[5].RowSpan == 0)
                    {
                        if (row.Cells[5].RowSpan == 0)
                        {
                            previousRow.Cells[5].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[5].RowSpan = row.Cells[5].RowSpan + 1;
                        }
                        row.Cells[5].Visible = false;
                    }
                }

                //if (lblRecQty.Text == lblPreviousRecQty.Text)
                //{
                //    if (previousRow.Cells[6].RowSpan == 0)
                //    {
                //        if (row.Cells[6].RowSpan == 0)
                //        {
                //            previousRow.Cells[6].RowSpan += 2;
                //        }
                //        else
                //        {
                //            previousRow.Cells[6].RowSpan = row.Cells[6].RowSpan + 1;
                //        }
                //        row.Cells[6].Visible = false;
                //    }
                //}

                //if (lblPassQty.Text == lblPreviousPassQty.Text && lblPO_Number.Text == lblPreviousPO_Number.Text)
                //{
                //    if (previousRow.Cells[7].RowSpan == 0)
                //    {
                //        if (row.Cells[7].RowSpan == 0)
                //        {
                //            previousRow.Cells[7].RowSpan += 2;
                //        }
                //        else
                //        {
                //            previousRow.Cells[7].RowSpan = row.Cells[7].RowSpan + 1;
                //        }
                //        row.Cells[7].Visible = false;
                //    }
                //}

                //if (lblHoldQty.Text == lblPreviousHoldQty.Text && lblPO_Number.Text == lblPreviousPO_Number.Text)
                //{
                //    if (previousRow.Cells[8].RowSpan == 0)
                //    {
                //        if (row.Cells[8].RowSpan == 0)
                //        {
                //            previousRow.Cells[8].RowSpan += 2;
                //        }
                //        else
                //        {
                //            previousRow.Cells[8].RowSpan = row.Cells[8].RowSpan + 1;
                //        }
                //        row.Cells[8].Visible = false;
                //    }
                //}

                //if (lblFourPointCheckRecQty.Text == lblPreviousFourPointCheckRecQty.Text)
                //{
                //    if (previousRow.Cells[9].RowSpan == 0)
                //    {
                //        if (row.Cells[9].RowSpan == 0)
                //        {
                //            previousRow.Cells[9].RowSpan += 2;
                //        }
                //        else
                //        {
                //            previousRow.Cells[9].RowSpan = row.Cells[9].RowSpan + 1;
                //        }
                //        row.Cells[9].Visible = false;
                //    }
                //}

                if (lblStatus.Text == lblPreviousStatus.Text && lblPO_Number.Text == lblPreviousPO_Number.Text)
                {
                    if (previousRow.Cells[10].RowSpan == 0)
                    {
                        if (row.Cells[10].RowSpan == 0)
                        {
                            previousRow.Cells[10].RowSpan += 2;
                        }
                        else
                        {
                            previousRow.Cells[10].RowSpan = row.Cells[10].RowSpan + 1;
                        }
                        row.Cells[10].Visible = false;
                    }
                }
            }
        }



        protected void grdPO_SRV_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Fabric Quality";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "150px");
                HeaderCell.Attributes.Add("class", "header1");
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Color Print";
                HeaderCell.RowSpan = 2;
                //HeaderCell.ColumnSpan = 4;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Type";
                HeaderCell.RowSpan = 2;
                //HeaderCell.ColumnSpan = 4;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "PO No.";
                HeaderCell.RowSpan = 2;
                //HeaderCell.ColumnSpan = 4;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Raised PO Qty.";
                HeaderCell.RowSpan = 2;
                //HeaderCell.ColumnSpan = 4;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Challan No.";
                HeaderCell.RowSpan = 2;
                //HeaderCell.ColumnSpan = 4;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SRV Received Qty.";
                HeaderCell.RowSpan = 2;
                //HeaderCell.ColumnSpan = 4;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Four Point Check";
                HeaderCell.ColumnSpan = 4;                
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);


                HeaderCell = new TableCell();
                HeaderCell.Text = "PO Status";
                //HeaderCell.ColumnSpan = 4;
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                grdPO_SRV.Controls[0].Controls.AddAt(0, HeaderGridRow);

                GridViewRow HeaderGridRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Received Qty.";
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 1;
                HeaderCell.Attributes.Add("class", "header1");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Pass Qty.";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Fail Qty.";
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 1;
                HeaderCell.Attributes.Add("class", "header1");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Hold Qty.";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Attributes.Add("class", "header1");
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 1;
                HeaderGridRow1.Cells.Add(HeaderCell);                

                grdPO_SRV.Controls[0].Controls.AddAt(1, HeaderGridRow1);

            }
        }
    }
}