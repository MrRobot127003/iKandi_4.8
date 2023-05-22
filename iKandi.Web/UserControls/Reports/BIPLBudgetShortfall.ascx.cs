using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;
using iKandi.Web.Components;

namespace iKandi.Web.UserControls.Reports
{
    public partial class BIPLBudgetShortfall : System.Web.UI.UserControl
    {
        AdminController objAdminController = new AdminController();
        //int CurrentLoggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;
        string CreatedDate="";
        protected void Page_Load(object sender, EventArgs e)
        {
            //string CreatedDate = txtCreatedDate.Value;
            //string CreatedDate = "2020-05-26";
            if (!IsPostBack)
            {
                bindMMRReportDate();
                bingrdShortfall(CreatedDate);
            }
        }
        public void bingrdShortfall(string CreatedDate)
        {


            DataSet ds = objAdminController.GetBIPLBudgetShortfall(CreatedDate);

            grdBudgetShortfall.DataSource = ds.Tables[0];
            grdBudgetShortfall.DataBind();
        }

        public void bindMMRReportDate()
        {
            
            DataSet ds = objAdminController.GetMMRReportDate();
            //CreatedDate = Convert.ToString(ds.Tables[0]);
            CreatedDate = ds.Tables[0].Rows[0]["MMRDate"].ToString();            
        }

        //protected void btnsubmit_Click(object sender, EventArgs e)
        //{            
        //    string CreatedDate = txtCreatedDate.Value;            
        //    bingrdShortfall(CreatedDate);
        //}

        protected void grdBudgetShortfall_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.ColumnSpan = 5;
                HeaderCell.Text = "BIPL-Budget Shortfall";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.CssClass = "HeaderClass2";
                //HeaderCell.Style.Add("width", "150px");
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                grdBudgetShortfall.Controls[0].Controls.AddAt(0, HeaderGridRow);

                GridViewRow HeaderGridRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Designation";
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.CssClass = "FirstColor";
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Shortfall";
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width","100px");
                HeaderCell.CssClass = "FirstColor";
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Reason for Shortfall";
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "225px");
                HeaderCell.CssClass = "FirstColor";
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "On Trial";
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "70px");
                HeaderCell.CssClass = "FirstColor";
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "HR Remarks";
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "90px");
                HeaderCell.CssClass = "FirstColor";
                HeaderGridRow1.Cells.Add(HeaderCell);


                grdBudgetShortfall.Controls[0].Controls.AddAt(1, HeaderGridRow1);

            }
        }
    }
}