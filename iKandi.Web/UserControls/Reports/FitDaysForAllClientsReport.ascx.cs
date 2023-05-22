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

namespace iKandi.Web
{
    public partial class FitDaysForAllClientsReport : BaseUserControl
    {
        # region Event Handler

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            //{
            //    this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
            //}
            //else
            //{
            //    this.HyperLinkPager1.PageIndex = 0;
            //}

            if (!IsPostBack)
            {
                BindControls();
            }
        }

        # endregion

        # region Methods
        private void BindControls()
        {
            int totalRecords = 0;
            DataSet ds = this.ReportControllerInstance.GetFitDaysForAllClients(0, 0, out totalRecords);
            //DataSet ds = this.ReportControllerInstance.GetFitDaysForAllClients(HyperLinkPager1.PageIndex, HyperLinkPager1.PageSize, out totalRecords);
            //HyperLinkPager1.TotalRecords = totalRecords;
            gvFitDays.DataSource = ds;
            gvFitDays.DataBind();
        }
        public static void MergeRows(GridView gridView)
        {
            for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = gridView.Rows[rowIndex];
                GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                //for (int i = 0; i < row.Cells.Count; i++)
                //{
                if (row.Cells[0].Text == previousRow.Cells[0].Text)
                {
                    row.Cells[0].RowSpan = previousRow.Cells[0].RowSpan < 2 ? 2 : previousRow.Cells[0].RowSpan + 1;
                    previousRow.Cells[0].Visible = false;
                }
                //}
            }
        }

        # endregion

        protected void gvFitDays_PreRender(object sender, EventArgs e)
        {
            MergeRows(gvFitDays);
        }

        protected void gvFitDays_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            Label lbl = e.Row.FindControl("lblMon") as Label;

            if (DataBinder.Eval(e.Row.DataItem, "Mon").ToString() == "1")
            {
                (lbl.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01cc01");
            }

            lbl = e.Row.FindControl("lblTue") as Label;

            if (DataBinder.Eval(e.Row.DataItem, "Tue").ToString() == "1")
            {
                (lbl.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01cc01");
            }

            lbl = e.Row.FindControl("lblWed") as Label;

            if (DataBinder.Eval(e.Row.DataItem, "Wed").ToString() == "1")
            {
                (lbl.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01cc01");
            }

            lbl = e.Row.FindControl("lblThu") as Label;

            if (DataBinder.Eval(e.Row.DataItem, "Thu").ToString() == "1")
            {
                (lbl.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01cc01");
            }

            lbl = e.Row.FindControl("lblFri") as Label;

            if (DataBinder.Eval(e.Row.DataItem, "Fri").ToString() == "1")
            {
                (lbl.Parent as TableCell).BackColor = System.Drawing.ColorTranslator.FromHtml("#01cc01");
            }

        }

        //protected void gvFitDays_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    int totalRecords = 0;
        //    DataSet ds = this.ReportControllerInstance.GetFitDaysForAllClients(e.NewPageIndex, gvFitDays.PageSize, out totalRecords);
        //    gvFitDays.DataSource = ds;
        //    gvFitDays.DataBind();
        //    HyperLinkPager1.TotalRecords = totalRecords;
        //    HyperLinkPager1.PageSize = 10;
        //    HyperLinkPager1.PageIndex = e.NewPageIndex;
        //}
    }
}