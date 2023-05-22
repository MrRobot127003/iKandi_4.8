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
using iKandi.Common;

namespace iKandi.Web
{
    public partial class RejectedQaContracts : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            OrderDetail od = (e.Row.DataItem as OrderDetail);

            HtmlAnchor hypSerial = e.Row.FindControl("hypSerial") as HtmlAnchor;
            (hypSerial.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetSerialNumberColor(od.ExFactory));

            //HtmlAnchor hypstatusmode = e.Row.FindControl("hypstatusmode") as HtmlAnchor;
            //(hypstatusmode.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetStatusModeColor(od.ParentOrder.WorkflowInstanceDetail.StatusModeID));

            Label lblEx = e.Row.FindControl("lblEx") as Label;
            (lblEx.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(iKandi.BLL.CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode));

            //HtmlAnchor hypUnit = e.Row.FindControl("hypUnit") as HtmlAnchor;
            //(hypUnit.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(ApplicationHelper.GetUnitColor(od.Unit.FactoryCode));

            Label lblTopsendTgt = e.Row.FindControl("lblTopsendTgt") as Label;
            (lblTopsendTgt.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetActualDateColor(od.ParentOrder.InlinePPMOrderContract.TopSentTarget, od.ParentOrder.InlinePPMOrderContract.TopSentActual));

            Label lblTopActualapp = e.Row.FindControl("lblTopActualapp") as Label;
            (lblTopActualapp.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml(Constants.GetActualDateColor(od.ParentOrder.InlinePPMOrderContract.TopSentTarget, od.ParentOrder.InlinePPMOrderContract.TopActualApproval));
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow =
                new GridViewRow(0, 0, DataControlRowType.Header,
                DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Basic Info";
                HeaderCell.CssClass = "extra_header";
                HeaderCell.ColumnSpan = 13;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Cutting";
                HeaderCell.CssClass = "extra_header";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Stitching";
                HeaderCell.CssClass = "extra_header";
                HeaderCell.ColumnSpan = 5;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "EMB.";
                HeaderCell.CssClass = "extra_header";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Packing";
                HeaderCell.CssClass = "extra_header";
                HeaderCell.ColumnSpan = 6;
                HeaderGridRow.Cells.Add(HeaderCell);

                GridView1.Controls[0].Controls.AddAt
                (0, HeaderGridRow);

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }


        public void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindClients(ddlClient);
            }

            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {
                this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
            }
            else
            {
                this.HyperLinkPager1.PageIndex = 0;
            }

            int TotalRowCount = 0;

            GridView1.DataSource = this.ReportControllerInstance.GetRejectedQaContracts(HyperLinkPager1.PageSize, (!string.IsNullOrEmpty(Request.QueryString["PageIndex"])) ? Convert.ToInt32(Request.QueryString["PageIndex"]) : 0, out TotalRowCount, Convert.ToInt32(ddlClient.SelectedValue));
            GridView1.DataBind();

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();          
        }

       
    }
}