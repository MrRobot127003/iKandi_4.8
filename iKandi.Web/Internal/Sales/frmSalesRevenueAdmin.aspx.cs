using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Text;
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

namespace iKandi.Web.Internal.Sales
{
    public partial class frmSalesRevenueAdmin : System.Web.UI.Page
    {
        FinancialController objfin = new FinancialController();
        int ExportSave = 0, CmtSave=0;
        protected void Page_Load(object sender, EventArgs e)
        {
          if (!Page.IsPostBack)
          {
            Bindgrd();
            FinancialYearDropdownBind();
            MonthlyActualCMTBind();
          }

        }
        public void Bindgrd()
        {
          DataSet ds = objfin.GetBIPLfinancialValue();
          DataTable dt =ds.Tables[0];
          if(dt.Rows.Count>1)
          {
            grdbiplExportRevenue.DataSource = dt;
            grdbiplExportRevenue.DataBind();

          }
        }
        public void MonthlyActualCMTBind()
        {
            DataSet ds = objfin.GetMonthlyActualCMTValue(ddlFinancialYear.SelectedItem.Text);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 1)
            {
                grdMonthlyActualCMT.DataSource = dt;
                grdMonthlyActualCMT.DataBind();

            }
        }
        public void FinancialYearDropdownBind()
        {
            DataTable dt = objfin.GetFinancialYear();
            if (dt.Rows.Count > 0)
            {
                ddlFinancialYear.DataSource = dt;
                ddlFinancialYear.DataValueField = "YearRange";
                ddlFinancialYear.DataTextField = "YearRange";
                ddlFinancialYear.DataBind();
                ddlFinancialYear.SelectedValue = "2020-21";
            }
        }
        protected void grdbiplExportRevenue_RowDataBound(object sender, GridViewRowEventArgs e)
        {
          if (e.Row.RowType == DataControlRowType.Header)
          {
            //GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            //GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            //headerRow1.Attributes.Add("class", "header1");
            //headerRow2.Attributes.Add("class", "header1");
            //TableCell HeaderCell = new TableCell();
            ////Adding the Row at the 0th position (first row) in the Grid
            //HeaderCell = new TableCell();
            //HeaderCell.Text = "Financial Year";
            //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //HeaderCell.RowSpan = 2;
            //headerRow1.Cells.Add(HeaderCell);

            //HeaderCell = new TableCell();
            //HeaderCell.Text = "BIPL Export";
            //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //HeaderCell.ColumnSpan = 2;
            //headerRow1.Cells.Add(HeaderCell);

            //HeaderCell = new TableCell();
            //HeaderCell.Text = "Ikandi Delivery";
            //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //HeaderCell.ColumnSpan = 2;
            //headerRow1.Cells.Add(HeaderCell);


            ////2 row start
            //HeaderCell = new TableCell();
            //HeaderCell.Text = "Value Cr.";
            //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //headerRow2.Cells.Add(HeaderCell);

            //HeaderCell = new TableCell();
            //HeaderCell.Text = "Pcs. (Lacks)";
            //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //headerRow2.Cells.Add(HeaderCell);

            //HeaderCell = new TableCell();
            //HeaderCell.Text = "Value Cr.";
            //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //headerRow2.Cells.Add(HeaderCell);

            //HeaderCell = new TableCell();
            //HeaderCell.Text = "Pcs. (Lacks)";
            //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            //headerRow2.Cells.Add(HeaderCell);

            //grdbiplExportRevenue.Controls[0].Controls.AddAt(0, headerRow2);
            //grdbiplExportRevenue.Controls[0].Controls.AddAt(0, headerRow1);





          }
         

        }
       
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
          //for (int i = 2; i <=grdbiplExportRevenue.Rows.Count; i++)
          //{
          //  string tbiplexportvalCR = ((TextBox)grdbiplExportRevenue.Rows[i].FindControl("txtbiplexportvalCR")).Text.Trim();
          //  string tbiplexportvalLK = ((TextBox)grdbiplExportRevenue.Rows[i].FindControl("txtbiplexportvalLK")).Text.Trim();
          //  string IKANDIexportvalCR = ((TextBox)grdbiplExportRevenue.Rows[i].FindControl("txtIKANDIexportvalCR")).Text.Trim();
          //  string IKANDIexportvalLK = ((TextBox)grdbiplExportRevenue.Rows[i].FindControl("txtIKANDIexportvalLK")).Text.Trim();
           
          //}
          save();
          ActualCMTsave();
        }

        //protected void btnSubmitCmt_Click(object sender, EventArgs e)
        //{
        //    ActualCMTsave();
        //}

        public void save()
        {
          
          //int i = 0;
          foreach (GridViewRow row in grdbiplExportRevenue.Rows)
          {
            Double tbiplexportvalCR = 0;
            Double tbiplexportvalLK = 0;
            Double IKANDIexportvalCR = 0;
            Double IKANDIexportvalLK = 0;

            HiddenField hdnP_ID = (HiddenField)row.FindControl("hdnP_ID");
            TextBox txtbiplexportvalCR = (TextBox)row.FindControl("txtbiplexportvalCR");
            TextBox txtbiplexportvalLK = (TextBox)row.FindControl("txtbiplexportvalLK");
            TextBox txtIKANDIexportvalCR = (TextBox)row.FindControl("txtIKANDIexportvalCR");
            TextBox txtIKANDIexportvalLK = (TextBox)row.FindControl("txtIKANDIexportvalLK");

            if (txtbiplexportvalCR.Text.Trim() != "")
            {
              tbiplexportvalCR = Convert.ToDouble(txtbiplexportvalCR.Text);
            }
            if (txtbiplexportvalLK.Text.Trim() != "")
            {
              tbiplexportvalLK = Convert.ToDouble(txtbiplexportvalLK.Text);
            }
            if (txtIKANDIexportvalCR.Text.Trim() != "")
            {
              IKANDIexportvalCR = Convert.ToDouble(txtIKANDIexportvalCR.Text);
            }
            if (txtIKANDIexportvalLK.Text.Trim() != "")
            {
              IKANDIexportvalLK = Convert.ToDouble(txtIKANDIexportvalLK.Text);
            }
            //if (tbiplexportvalCR != 0 && tbiplexportvalLK != 0 && IKANDIexportvalCR != 0 && IKANDIexportvalLK != 0&& hdnP_ID.Value != "")
            //{
                //i = objfin.InsertbiplExportrevenue(Convert.ToInt32(hdnP_ID.Value), tbiplexportvalCR, tbiplexportvalLK, IKANDIexportvalCR, IKANDIexportvalLK);
               ExportSave  = objfin.InsertbiplExportrevenue(Convert.ToInt32(hdnP_ID.Value), tbiplexportvalCR,tbiplexportvalLK,IKANDIexportvalCR,IKANDIexportvalLK);
            //}
          }
          //if (i == 1)
          //{
          //  ShowAlert("Saved successfully");
          //  Bindgrd();
          //}
        }
        public void ActualCMTsave()
        {
            //int i = 0;
            
            string FinancialYear = ddlFinancialYear.SelectedItem.Text;
            int CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;

            foreach (GridViewRow row in grdMonthlyActualCMT.Rows)
            {
                Double ActualCMT = 0;
                //int MonthNumber = 0;

                HiddenField hdnFinancialID = (HiddenField)row.FindControl("hdnFinancialID");
                HiddenField hdnMonthNumber = (HiddenField)row.FindControl("hdnMonthNumber");
                
                TextBox txtActualCMT = (TextBox)row.FindControl("txtActualCMT");
                Label lblMonth = (Label)row.FindControl("lblMonth");                

                if (txtActualCMT.Text.Trim() != "")
                {
                    ActualCMT = Convert.ToDouble(txtActualCMT.Text.Replace(",",""));
                }
                //i = objfin.InsertActualCMT(Convert.ToInt32(hdnFinancialID.Value), Convert.ToInt32(hdnMonthNumber.Value), FinancialYear, Convert.ToDouble(ActualCMT), CreatedBy);
                CmtSave = objfin.InsertActualCMT(Convert.ToInt32(hdnFinancialID.Value), Convert.ToInt32(hdnMonthNumber.Value), FinancialYear, Convert.ToDouble(ActualCMT), CreatedBy);
               
            }
            if (CmtSave > 0 && ExportSave > 0)
            {
                ShowAlert("Saved successfully");
                Bindgrd();
                MonthlyActualCMTBind();
            }
            //if (i == 1)
            //{
            //    ShowAlert("Saved successfully");
            //    MonthlyActualCMTBind();
            //}
            //else
            //{
                
            //    foreach (GridViewRow row in grdMonthlyActualCMT.Rows)
            //    {
            //        TextBox txtActualCMT = (TextBox)row.FindControl("txtActualCMT");
            //        txtActualCMT.Text = "";
            //    }
            //}
        }
        public void ShowAlert(string stringAlertMsg)
        {
          string myStringVariable = string.Empty;
          myStringVariable = stringAlertMsg;
          ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        protected void grdMonthlyActualCMT_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {

                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);               

                TableCell HeaderCell = new TableCell();

                HeaderCell.Text = "Month";
                HeaderCell.CssClass = "Header1";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6b6464");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
                HeaderCell.Font.Bold = true;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Act CMT <span style='color:Gray;font-size:10px'>(₹)</span>";
                HeaderCell.CssClass = "Header1";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#6b6464");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#dddfe4");
                HeaderCell.Font.Bold = true;
                HeaderGridRow.Cells.Add(HeaderCell);



                grdMonthlyActualCMT.Controls[0].Controls.AddAt(0, HeaderGridRow);
                

            }

        }

        protected void grdMonthlyActualCMT_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                HiddenField hdnP_ID = (HiddenField)e.Row.FindControl("hdnFinancialID");
                TextBox txtActualCMT = (TextBox)e.Row.FindControl("txtActualCMT");
                Label lblMonth = (Label)e.Row.FindControl("lblMonth");

                if (lblMonth.Text == "4")
                {
                    lblMonth.Text = "April";
                }
                if (lblMonth.Text == "5")
                {
                    lblMonth.Text = "May";
                }
                if (lblMonth.Text == "6")
                {
                    lblMonth.Text = "June";
                }
                if (lblMonth.Text == "7")
                {
                    lblMonth.Text = "July";
                }
                if (lblMonth.Text == "8")
                {
                    lblMonth.Text = "August";
                }
                if (lblMonth.Text == "9")
                {
                    lblMonth.Text = "September";
                }
                if (lblMonth.Text == "10")
                {
                    lblMonth.Text = "October";
                }
                if (lblMonth.Text == "11")
                {
                    lblMonth.Text = "November";
                }
                if (lblMonth.Text == "12")
                {
                    lblMonth.Text = "December";
                }
                if (lblMonth.Text == "1")
                {
                    lblMonth.Text = "January";
                }
                if (lblMonth.Text == "2")
                {
                    lblMonth.Text = "February";
                }
                if (lblMonth.Text == "3")
                {
                    lblMonth.Text = "March";
                }

            }
        }

        protected void ddlFinancialYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            MonthlyActualCMTBind();
        }
    }
}