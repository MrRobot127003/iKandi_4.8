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

namespace iKandi.Web.UserControls.Reports
{
    public partial class KeyManPowerSummaryMMR : System.Web.UI.UserControl    
    {
        AdminController objAdminController = new AdminController();
        //int CurrentLoggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;
        string CreatedDate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //string CreatedDate = txtCreatedDate.Value;
            //string CreatedDate = "2020-03-19";
            if (!IsPostBack)
            {
                bindMMRReportDate();
                bindKeypowerGrd(CreatedDate);
             
            }
            GridViewRow getRow = grdKeyManPowerMMReport.Rows[grdKeyManPowerMMReport.Rows.Count - 1];
            getRow.Attributes.Add("class", "headerBack");
        }

        public void bindMMRReportDate()
        {

            DataSet ds = objAdminController.GetMMRReportDate();
            CreatedDate = ds.Tables[0].Rows[0]["MMRDate"].ToString();            
        }

        public void bindKeypowerGrd(string CreatedDate)
        {


            DataSet ds = objAdminController.GetKeyManPowerMMRreport(CreatedDate);

            grdKeyManPowerMMReport.DataSource = ds.Tables[0];
            grdKeyManPowerMMReport.DataBind();

           

        }

        protected void grdKeyManPowerMMReport_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Department";
                HeaderCell.RowSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "150px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "C-47";
                HeaderCell.ColumnSpan = 3;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "C45-46";
                HeaderCell.ColumnSpan = 3;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                // RajeevS 10-05-2023 Start
                    //HeaderCell = new TableCell();
                    //HeaderCell.Text = "D-169";
                    //HeaderCell.ColumnSpan = 3;
                    //HeaderCell.Style.Add("text-align", "center");
                    //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                    //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    //HeaderGridRow.Cells.Add(HeaderCell);
                // RajeevS 10-05-2023 Start

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "C-52";
                //HeaderCell.ColumnSpan = 3;
                //HeaderCell.Style.Add("text-align", "center");
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "BIPL (Excl. Outhouse)";
                HeaderCell.ColumnSpan = 3;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);
                grdKeyManPowerMMReport.Controls[0].Controls.AddAt(0, HeaderGridRow);

                GridViewRow HeaderGridRow2 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
                // RajeevS 10-05-2023 Start
                    //HeaderCell = new TableCell();
                    //HeaderCell.Text = "Budget";
                    //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                    //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    //HeaderCell.Style.Add("text-align", "center");
                    //HeaderGridRow2.Cells.Add(HeaderCell);

                    //HeaderCell = new TableCell();
                    //HeaderCell.Text = "Actual";
                    //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                    //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    //HeaderCell.Style.Add("text-align", "center");
                    //HeaderGridRow2.Cells.Add(HeaderCell);

                    //HeaderCell = new TableCell();
                    //HeaderCell.Text = "%";
                    //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                    //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                    //HeaderCell.Style.Add("text-align", "center");
                    //HeaderGridRow2.Cells.Add(HeaderCell);
                // RajeevS 10-05-2023 End

                HeaderCell = new TableCell();
                HeaderCell.Text = "Budget";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "%";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Budget";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "%";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Budget";
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.Style.Add("text-align", "center");
                //HeaderGridRow2.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Actual";
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.Style.Add("text-align", "center");
                //HeaderGridRow2.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "%";
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.Style.Add("text-align", "center");
                //HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Budget";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Actual";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "%";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                grdKeyManPowerMMReport.Controls[0].Controls.AddAt(1, HeaderGridRow2);
            }
        }

        protected void grdKeyManPowerMMReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                try
                {
                    Label lblDepartment = (Label)e.Row.FindControl("lblDepartment");
                    Label lblManPowerBudgetC47 = (Label)e.Row.FindControl("lblManPowerBudgetC47");
                    Label lblManPowerTodayC47 = (Label)e.Row.FindControl("lblManPowerTodayC47");
                    Label lblManPowerC47Percent = (Label)e.Row.FindControl("lblManPowerC47Percent");

                    Label lblManPowerBudgetC45 = (Label)e.Row.FindControl("lblManPowerBudgetC45");
                    Label lblManPowerTodayC45 = (Label)e.Row.FindControl("lblManPowerTodayC45");
                    Label lblManPowerC45Percent = (Label)e.Row.FindControl("lblManPowerC45Percent");

                    // RajeevS 10-05-2023 Start
                        //Label lblManPowerBudgetD169 = (Label)e.Row.FindControl("lblManPowerBudgetD169");
                        //Label lblManPowerTodayD169 = (Label)e.Row.FindControl("lblManPowerTodayD169");
                        //Label lblManPowerD169Percent = (Label)e.Row.FindControl("lblManPowerD169Percent");
                    // RajeevS 10-05-2023 End

                    //Label lblManPowerBudgetC52 = (Label)e.Row.FindControl("lblManPowerBudgetC52");
                    //Label lblManPowerTodayC52 = (Label)e.Row.FindControl("lblManPowerTodayC52");
                    //Label lblManPowerC52Percent = (Label)e.Row.FindControl("lblManPowerC52Percent");

                    Label lblManPowerBudgetBIPL = (Label)e.Row.FindControl("lblManPowerBudgetBIPL");
                    Label lblManPowerTodayBIPL = (Label)e.Row.FindControl("lblManPowerTodayBIPL");
                    Label lblManPowerBIPLPercent = (Label)e.Row.FindControl("lblManPowerBIPLPercent");

                    decimal ManPowerC47Percent, ManPowerC45Percent, ManPowerBIPLPercent = 0; //ManPowerD169Percent, ManPowerC52Percent,
                    decimal ManPowerC47Budget, ManPowerC47Today, ManPowerC45Budget, ManPowerC45Today, ManPowerBIPLBudget, ManPowerBIPLToday = 0; //ManPowerD169Budget, ManPowerD169Today, ManPowerC52Budget, ManPowerC52Today,

                    if (lblDepartment.Text == "Operator (Incl. standing operator & pressmen)" && grdKeyManPowerMMReport.Rows.Count == 0)
                    {
                        lblDepartment.Text = "Lines";
                    }

                    if (lblDepartment.Text == "Operator (Incl. standing operator & pressmen)" && grdKeyManPowerMMReport.Rows.Count == 1)
                    {
                        lblDepartment.Text = "Tailors";
                    }

                    if (lblDepartment.Text == "Mmt Checkers (Midline & Offline)")
                    {
                        lblDepartment.Text = "Mmt Checkers";
                    }

                    if (lblDepartment.Text == "Finishing Checker (Visual & Initial)")
                    {
                        lblDepartment.Text = "Visual checkers";
                    }


                    if (lblDepartment.Text == "Pressmen (operator)")
                    {
                        lblDepartment.Text = "Pressmen";
                    }

                    if (lblDepartment.Text == "Checkers (midline & offline)")
                    {
                        lblDepartment.Text = "Checkers";
                    }


                    if ((Convert.ToDouble(lblManPowerTodayC47.Text) > 0) && (Convert.ToDouble(lblManPowerBudgetC47.Text) > 0))
                    {
                        ManPowerC47Percent = (Convert.ToDecimal(lblManPowerTodayC47.Text) / Convert.ToDecimal(lblManPowerBudgetC47.Text)) * 100;

                        lblManPowerC47Percent.Text = Math.Round(ManPowerC47Percent, MidpointRounding.AwayFromZero).ToString() + "%";
                    }
                    else
                    {
                        lblManPowerC47Percent.Text = "0%";
                    }

                    lblManPowerC47Percent.ForeColor = System.Drawing.Color.Navy;
                    lblManPowerC47Percent.Text = (lblManPowerC47Percent.Text == "0" || lblManPowerC47Percent.Text == "0%") ? "" : lblManPowerC47Percent.Text;

                    if ((Convert.ToDouble(lblManPowerTodayC45.Text) > 0) && (Convert.ToDouble(lblManPowerBudgetC45.Text) > 0))
                    {
                        ManPowerC45Percent = (Convert.ToDecimal(lblManPowerTodayC45.Text) / Convert.ToDecimal(lblManPowerBudgetC45.Text)) * 100;
                        lblManPowerC45Percent.Text = Math.Round(ManPowerC45Percent, MidpointRounding.AwayFromZero).ToString() + "%";
                    }
                    else
                    {
                        lblManPowerC45Percent.Text = "0%";
                    }

                    lblManPowerC45Percent.ForeColor = System.Drawing.Color.Navy;
                    lblManPowerC45Percent.Text = (lblManPowerC45Percent.Text == "0" || lblManPowerC45Percent.Text == "0%") ? "" : lblManPowerC45Percent.Text;

                    // RajeevS 10-05-2023 Start
                        //if ((Convert.ToDouble(lblManPowerTodayD169.Text) > 0) && (Convert.ToDouble(lblManPowerBudgetD169.Text) > 0))
                        //{
                        //    ManPowerD169Percent = (Convert.ToDecimal(lblManPowerTodayD169.Text) / Convert.ToDecimal(lblManPowerBudgetD169.Text)) * 100;
                        //    lblManPowerD169Percent.Text = Math.Round(ManPowerD169Percent, MidpointRounding.AwayFromZero).ToString() + "%";
                        //}
                        //else
                        //{
                        //    lblManPowerD169Percent.Text = "0%";
                        //}
                        //lblManPowerD169Percent.ForeColor = System.Drawing.Color.Navy;
                        //lblManPowerD169Percent.Text = (lblManPowerD169Percent.Text == "0" || lblManPowerD169Percent.Text == "0%") ? "" : lblManPowerD169Percent.Text;
                    // RajeevS 10-05-2023 End


                    //added by raghvinder on 02-11-2020 start
                    //if ((Convert.ToDouble(lblManPowerTodayC52.Text) > 0) && (Convert.ToDouble(lblManPowerBudgetC52.Text) > 0))
                    //{
                    //    ManPowerC52Percent = (Convert.ToDecimal(lblManPowerTodayC52.Text) / Convert.ToDecimal(lblManPowerBudgetC52.Text)) * 100;
                    //    lblManPowerC52Percent.Text = Math.Round(ManPowerC52Percent, MidpointRounding.AwayFromZero).ToString() + "%";
                    //}
                    //else
                    //{
                    //    lblManPowerC52Percent.Text = "0%";
                    //}
                    //lblManPowerC52Percent.ForeColor = System.Drawing.Color.Navy;
                    //lblManPowerC52Percent.Text = (lblManPowerC52Percent.Text == "0" || lblManPowerC52Percent.Text == "0%") ? "" : lblManPowerC52Percent.Text;
                    //added by raghvinder on 02-11-2020 end

                    if ((Convert.ToDouble(lblManPowerTodayBIPL.Text) > 0) && (Convert.ToDouble(lblManPowerBudgetBIPL.Text) > 0))
                    {
                        ManPowerBIPLPercent = (Convert.ToDecimal(lblManPowerTodayBIPL.Text) / Convert.ToDecimal(lblManPowerBudgetBIPL.Text)) * 100;
                        lblManPowerBIPLPercent.Text = Math.Round(ManPowerBIPLPercent, MidpointRounding.AwayFromZero).ToString() + "%";
                    }
                    else
                    {
                        lblManPowerBIPLPercent.Text = "0%";
                    }

                    lblManPowerBIPLPercent.ForeColor = System.Drawing.Color.Navy;
                    lblManPowerBIPLPercent.Text = (lblManPowerBIPLPercent.Text == "0" || lblManPowerBIPLPercent.Text == "0%") ? "" : lblManPowerBIPLPercent.Text;

                    //double ManPowerC47Budget,ManPowerC47Today, ManPowerC45Budget, ManPowerC45Today, ManPowerD169Budget, ManPowerD169Today, ManPowerBIPLBudget, ManPowerBIPLToday = 0;
                    ManPowerC47Budget = Convert.ToDecimal(lblManPowerBudgetC47.Text);
                    ManPowerC47Today = Convert.ToDecimal(lblManPowerTodayC47.Text);

                    ManPowerC45Budget = Convert.ToDecimal(lblManPowerBudgetC45.Text);
                    ManPowerC45Today = Convert.ToDecimal(lblManPowerTodayC45.Text);

                    // RajeevS 10-05-2023 Start
                        //ManPowerD169Budget = Convert.ToDecimal(lblManPowerBudgetD169.Text);
                        //ManPowerD169Today = Convert.ToDecimal(lblManPowerTodayD169.Text);
                    // RajeevS 10-05-2023 End

                    //ManPowerC52Budget = Convert.ToDecimal(lblManPowerBudgetC52.Text);
                    //ManPowerC52Today = Convert.ToDecimal(lblManPowerTodayC52.Text);

                    ManPowerBIPLBudget = Convert.ToDecimal(lblManPowerBudgetBIPL.Text);
                    ManPowerBIPLToday = Convert.ToDecimal(lblManPowerTodayBIPL.Text);

                    if (lblDepartment.Text == "Lines")
                    {
                        lblManPowerBudgetC47.Text = (ManPowerC47Budget == 0) ? "" : Math.Round(ManPowerC47Budget, 1, MidpointRounding.AwayFromZero).ToString();
                        lblManPowerTodayC47.Text = (ManPowerC47Today == 0) ? "" : Math.Round(ManPowerC47Today, 1, MidpointRounding.AwayFromZero).ToString();

                        lblManPowerBudgetC45.Text = (ManPowerC45Budget == 0) ? "" : Math.Round(ManPowerC45Budget, 1, MidpointRounding.AwayFromZero).ToString();
                        lblManPowerTodayC45.Text = (ManPowerC45Today == 0) ? "" : Math.Round(ManPowerC45Today, 1, MidpointRounding.AwayFromZero).ToString();

                        // RajeevS 10-05-2023 Start
                            //lblManPowerBudgetD169.Text = (ManPowerD169Budget == 0) ? "" : Math.Round(ManPowerD169Budget, 1, MidpointRounding.AwayFromZero).ToString();
                            //lblManPowerTodayD169.Text = (ManPowerD169Today == 0) ? "" : Math.Round(ManPowerD169Today, 1, MidpointRounding.AwayFromZero).ToString();
                        // RajeevS 10-05-2023 Start

                        //lblManPowerBudgetC52.Text = (ManPowerC52Budget == 0) ? "" : Math.Round(ManPowerC52Budget, 1, MidpointRounding.AwayFromZero).ToString();
                        //lblManPowerTodayC52.Text = (ManPowerC52Today == 0) ? "" : Math.Round(ManPowerC52Today, 1, MidpointRounding.AwayFromZero).ToString();

                        lblManPowerBudgetBIPL.Text = (ManPowerBIPLBudget == 0) ? "" : Math.Round(ManPowerBIPLBudget, 1, MidpointRounding.AwayFromZero).ToString();
                        lblManPowerTodayBIPL.Text = (ManPowerBIPLToday == 0) ? "" : Math.Round(ManPowerBIPLToday, 1, MidpointRounding.AwayFromZero).ToString();

                    }
                    else
                    {
                        lblManPowerBudgetC47.Text = (ManPowerC47Budget == 0) ? "" : Math.Round(ManPowerC47Budget, 1, MidpointRounding.AwayFromZero).ToString("N0");
                        lblManPowerTodayC47.Text = (ManPowerC47Today == 0) ? "" : Math.Round(ManPowerC47Today, 1, MidpointRounding.AwayFromZero).ToString("N0");

                        lblManPowerBudgetC45.Text = (ManPowerC45Budget == 0) ? "" : Math.Round(ManPowerC45Budget, 1, MidpointRounding.AwayFromZero).ToString("N0");
                        lblManPowerTodayC45.Text = (ManPowerC45Today == 0) ? "" : Math.Round(ManPowerC45Today, 1, MidpointRounding.AwayFromZero).ToString("N0");

                        // RajeevS 10-05-2023 Start
                            //lblManPowerBudgetD169.Text = (ManPowerD169Budget == 0) ? "" : Math.Round(ManPowerD169Budget, 1, MidpointRounding.AwayFromZero).ToString("N0");
                            //lblManPowerTodayD169.Text = (ManPowerD169Today == 0) ? "" : Math.Round(ManPowerD169Today, 1, MidpointRounding.AwayFromZero).ToString("N0");
                        // RajeevS 10-05-2023 End

                        //lblManPowerBudgetC52.Text = (ManPowerC52Budget == 0) ? "" : Math.Round(ManPowerC52Budget, 1, MidpointRounding.AwayFromZero).ToString("N0");
                        //lblManPowerTodayC52.Text = (ManPowerC52Today == 0) ? "" : Math.Round(ManPowerC52Today, 1, MidpointRounding.AwayFromZero).ToString("N0");

                        lblManPowerBudgetBIPL.Text = (ManPowerBIPLBudget == 0) ? "" : Math.Round(ManPowerBIPLBudget, 1, MidpointRounding.AwayFromZero).ToString("N0");
                        lblManPowerTodayBIPL.Text = (ManPowerBIPLToday == 0) ? "" : Math.Round(ManPowerBIPLToday, 1, MidpointRounding.AwayFromZero).ToString("N0");

                    }
                    if (lblDepartment.Text == "Total Hiring")
                    {
                        lblManPowerBudgetC47.Font.Bold = true;
                        lblManPowerTodayC47.Font.Bold = true;
                        lblManPowerC47Percent.Font.Bold = true;
                        lblManPowerBudgetC45.Font.Bold = true;
                        lblManPowerTodayC45.Font.Bold = true;
                        lblManPowerC45Percent.Font.Bold = true;

                        // RajeevS 10-05-2023 Start
                            //lblManPowerBudgetD169.Font.Bold = true;
                            //lblManPowerTodayD169.Font.Bold = true;
                            //lblManPowerD169Percent.Font.Bold = true;
                        // RajeevS 10-05-2023 End

                        //lblManPowerBudgetC52.Font.Bold = true;
                        //lblManPowerTodayC52.Font.Bold = true;
                        //lblManPowerC52Percent.Font.Bold = true;

                        lblManPowerBudgetBIPL.Font.Bold = true;
                        lblManPowerTodayBIPL.Font.Bold = true;
                        lblManPowerBIPLPercent.Font.Bold = true;
                        lblDepartment.Font.Bold = true;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    //Response.Write("Could not divide by zero");
                }
            }
        }
    }
}