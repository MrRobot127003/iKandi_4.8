using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;
using System.Web.UI.HtmlControls;

namespace iKandi.Web
{
    public partial class FrmComplianceAuditReportC45 : System.Web.UI.Page
    {

        int TotalAverage = 0;
        int TotalProcess = 0;
        int c45rowblank = 0;
        int c47rowblank = 0;
        AdminController objadmin = new AdminController();
        CommonController objCommon = new CommonController();
        DateTime CommonDate;

        protected void Page_Load(object sender, EventArgs e)
        {
            CommonDate = objCommon.GetCommonRptDateOnPage();

            if (CommonDate.Day == 1)
            {
                CommonDate = CommonDate.AddDays(-1);
            }

            objadmin.SetTruncateTable();
            bindHeaderC45();
            GridViewRow grdComplianceQAuditReportC45row = grdComplianceQAuditReportC45.Rows[(grdComplianceQAuditReportC45.Rows.Count) - 1];
            grdComplianceQAuditReportC45row.CssClass = "footerback";
        }
        protected void bindHeaderC45()
        {
            DataSet ds = new DataSet();
            ds = objadmin.GetHeaderComplianceQAuditReport(2);
            if (grdComplianceQAuditReportC45.Columns.Count > 0)
            {
                grdComplianceQAuditReportC45.Columns.Clear();

            }

            TemplateField Unit = new TemplateField();
            Unit.HeaderText = "Unit";
            Unit.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "Unit", "Unit");
            grdComplianceQAuditReportC45.Columns.Insert(0, Unit);
            Unit.HeaderStyle.CssClass = "FirstChild";
            Unit.HeaderStyle.Width = 100;

            TemplateField Line = new TemplateField();
            Line.HeaderText = "Line";
            Line.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "Line", "Line");
            grdComplianceQAuditReportC45.Columns.Insert(1, Line);
            Line.HeaderStyle.CssClass = "FirstChild";
            Line.HeaderStyle.Width = 140;

            int Count = Convert.ToInt32(ds.Tables[1].Rows.Count) - 1;
            if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
            {
                for (int i = 0; i <= Count; i++)
                {
                    int ProcessType = Convert.ToInt32(ds.Tables[1].Rows[i]["ProcessType"]);
                    TemplateField Process = new TemplateField();
                    Process.HeaderText = Convert.ToString(ds.Tables[1].Rows[i]["Process"]);
                    Process.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "Process" + Convert.ToString(ds.Tables[1].Rows[i]["Process"]), "Process" + Convert.ToString(ds.Tables[1].Rows[i]["Process"]));
                    Process.ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                    Process.HeaderStyle.Font.Bold = false;
                    Process.HeaderStyle.BackColor = System.Drawing.Color.LightGray;
                    grdComplianceQAuditReportC45.Columns.Insert(i + 2, Process);
                    Process.HeaderStyle.Width = 80;
                    Process.HeaderStyle.CssClass = "headerColor";
                }

            }
            grdComplianceQAuditReportC45.Width = 120 + 80 * (Count + 1);
            grdComplianceQAuditReportC45.DataSource = ds.Tables[0];
            grdComplianceQAuditReportC45.DataBind();
            //ComplianceQAuditReportC45();
        }
        protected void grdComplianceQAuditReportC45_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                DataSet ds = new DataSet();
                ds = objadmin.GetHeaderComplianceQAuditReport(2);

                GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell2 = new TableCell();

                HeaderCell2.Text = "Quality Audit (for " + CommonDate.ToString("MMMM") + ")";
                HeaderCell2.ColumnSpan = Convert.ToInt32(ds.Tables[1].Rows.Count) + 2;
                HeaderCell2.Style.Add("font-weight", "bold");
                HeaderCell2.Style.Add("text-align", "center");
                HeaderCell2.Style.Add("background", "lightgrey");
                HeaderRow.Cells.Add(HeaderCell2);

                grdComplianceQAuditReportC45.Controls[0].Controls.AddAt(0, HeaderRow);
            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataSet ds = new DataSet();
                ds = objadmin.GetHeaderComplianceQAuditReport(2);
                DataRowView drv = (DataRowView)e.Row.DataItem;

                int QAComplaine_TypeAdmin = Convert.ToInt32(drv.Row.ItemArray[0].ToString().Trim());
                int ValuesID = Convert.ToInt32(drv.Row.ItemArray[2].ToString().Trim());
                string Line = drv.Row.ItemArray[1] == DBNull.Value ? "" : drv.Row.ItemArray[1].ToString().Trim();
                int UnitId = Convert.ToInt32(drv.Row.ItemArray[3].ToString().Trim());

                Label UnitName = e.Row.FindControl("Unit") as Label;
                if (UnitId == 3)
                {
                    UnitName.Text = "C 47";
                }
                else if (UnitId == 11)
                {
                    UnitName.Text = "C 45-46";
                }
                else if (UnitId == 96)
                {
                    UnitName.Text = "D 169";
                }
                //else if (UnitId == 120)
                //{
                //    UnitName.Text = "C 52";
                //}
                else
                {
                    UnitName.Text = "BIPL";
                }
                e.Row.Cells[0].Width = 70;
                e.Row.Cells[0].Style.Add("text-align", "center");
                e.Row.Cells[0].Style.Add("background", "#DDDFE4");

                Label LineName = e.Row.FindControl("Line") as Label;
                LineName.Text = Line;
                e.Row.Cells[1].Width = 100;
                LineName.Style.Add("color", "gray");
                e.Row.Cells[1].Style.Add("text-align", "center");
                if (Line.Contains("Average"))
                {
                    e.Row.Cells[1].Style.Add("background", "#c7d4f5");
                    LineName.Style.Add("color", "#3c3737");
                }
                else
                {
                    e.Row.Cells[1].Style.Add("background", "#DDDFE4");
                }
                TotalProcess = 0;
                TotalAverage = 0;
                bool blankrow = false;
                int Count = Convert.ToInt32(ds.Tables[1].Rows.Count);
                if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        string ProcessName = ds.Tables[1].Rows[i]["Process"].ToString();
                        int ProcessType = Convert.ToInt32(ds.Tables[1].Rows[i]["ProcessType"]);
                        HtmlTableCell processnew = e.Row.FindControl("Process" + Convert.ToString(ds.Tables[1].Rows[i]["Process"])) as HtmlTableCell;
                        Label Process = e.Row.FindControl("Process" + Convert.ToString(ds.Tables[1].Rows[i]["Process"])) as Label;
                        Process.Text = objadmin.Get_BrealDownForCompliance_QA(ProcessType, ProcessName, QAComplaine_TypeAdmin, ValuesID, UnitId, TotalAverage, TotalProcess) + "%"; // EFW.ToString();
                        // Process.ForeColor = System.Drawing.Color.Yellow;

                        if (Line.Contains("Average"))
                        {
                            if (UnitName.Text == "BIPL")
                            {
                                Process.Style.Add("font-size", "10px");


                            }
                            else
                            {
                                Process.Style.Add("font-size", "10px");


                            }
                            if (Convert.ToInt32(Process.Text.Trim().Replace("%", "")) < 80)
                            {
                                e.Row.Cells[i + 2].Style.Add("Background", "red");
                                // Process.ForeColor = System.Drawing.Color.Yellow;
                                Process.ForeColor = System.Drawing.Color.Yellow;
                                e.Row.Cells[i + 2].Style.Add("font-weight", "bold");
                                if (Convert.ToInt32(Process.Text.Trim().Replace("%", "")) == 1)
                                {
                                    Process.Visible = false;
                                }
                            }
                            else
                            {
                                if (Convert.ToInt32(Process.Text.Trim().Replace("%", "")) > 79 && Convert.ToInt32(Process.Text.Trim().Replace("%", "")) < 91)
                                {
                                    e.Row.Cells[i + 2].Style.Add("Background", "orange");
                                    // Process.ForeColor = System.Drawing.Color.Yellow;
                                    Process.ForeColor = System.Drawing.Color.Yellow;
                                    e.Row.Cells[i + 2].Style.Add("font-weight", "bold");
                                }
                                else
                                {
                                    e.Row.Cells[i + 2].Style.Add("Background", "green");
                                    Process.ForeColor = System.Drawing.Color.Yellow;
                                    e.Row.Cells[i + 2].Style.Add("font-weight", "bold");
                                    // Process.ForeColor = System.Drawing.Color.Yellow;
                                }
                            }
                        }
                        //if (Convert.ToInt32(Process.Text.Trim().Replace("%", "")) < 6)
                        //{
                        //    e.Row.Cells[i + 2].Style.Add("Background", "green");                           
                        //    e.Row.Cells[i + 2].Style.Add("font-weight", "bold");
                        //}
                        //else
                        //{
                        //    e.Row.Cells[i + 2].Style.Add("Background", "red");                          
                        //    e.Row.Cells[i + 2].Style.Add("font-weight", "bold");
                        //}
                        if (Convert.ToInt32(Process.Text.Trim().Replace("%", "")) < 80)
                        {
                            // e.Row.Cells[i + 2].Style.Add("Background", "red");
                            e.Row.Cells[i + 2].Attributes.Add("class", "RedColor");
                            e.Row.Cells[i + 2].Style.Add("font-weight", "bold");
                            if (Convert.ToInt32(Process.Text.Trim().Replace("%", "")) == 1)
                            {
                                Process.Visible = false;
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(Process.Text.Trim().Replace("%", "")) > 79 && Convert.ToInt32(Process.Text.Trim().Replace("%", "")) < 91)
                            {
                                // e.Row.Cells[i + 2].Style.Add("Background", "orange");
                                e.Row.Cells[i + 2].Attributes.Add("class", "BlackColor");
                                // e.Row.Cells[i + 2].Style.Add("font-weight", "bold");
                            }
                            else
                            {
                                //e.Row.Cells[i + 2].Style.Add("Background", "green");
                                e.Row.Cells[i + 2].Attributes.Add("class", "GreenColor");
                                // e.Row.Cells[i + 2].Style.Add("font-weight", "bold");
                            }
                        }
                        if (Process.Text.Trim().Replace("%", "") == "0" || Process.Text.Trim().Replace("%", "") == "")
                        {
                            Process.Text = "";
                            e.Row.Cells[i + 2].Style.Add("Background", "white");
                        }
                        else
                        {
                            TotalProcess = TotalProcess + 1;
                            TotalAverage = TotalAverage + Convert.ToInt32(Process.Text.Trim().Replace("%", ""));
                            blankrow = true;
                        }

                    }

                }
                if (blankrow == false)
                {
                    //e.Row.Cells[11].Text = "dgdg";
                    if (UnitId == 96 && Line == "Line 1")
                    {
                    }
                    else
                    {
                        e.Row.Visible = false;

                    }
                    c47rowblank = c47rowblank + 1;
                }
            }
        }


        public void ComplianceQAuditReportC45()
        {
            int index = grdComplianceQAuditReportC45.Rows.Count - 1;

            for (int i = grdComplianceQAuditReportC45.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdComplianceQAuditReportC45.Rows[i];
                GridViewRow previousRow = grdComplianceQAuditReportC45.Rows[i - 1];

                if (row.Visible == false)
                {
                    previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan;
                    row.Cells[0].Visible = false;
                    index = index - 1;
                    continue;
                }

                Label lblFactory = (Label)row.FindControl("Unit");
                Label lblPreviousFactory = (Label)previousRow.FindControl("Unit");

                if (lblFactory.Text == lblPreviousFactory.Text)
                {
                    if (previousRow.Cells[0].RowSpan == 0)
                    {
                        if (row.Cells[0].RowSpan == 0)
                        {
                            previousRow.Cells[0].RowSpan = 2;
                        }
                        else
                        {
                            previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
                        }
                        row.Cells[0].Visible = false;
                    }
                }
                index = index - 1;
            }
        }

        //protected void grdComplianceQAuditReportC45_DataBound(object sender, EventArgs e)
        //{
        //    for (int i = grdComplianceQAuditReportC45.Rows.Count - 1; i > 0; i--)
        //    {
        //        GridViewRow row = grdComplianceQAuditReportC45.Rows[i];
        //        GridViewRow previousRow = grdComplianceQAuditReportC45.Rows[i - 1];

        //        Label lblFactory = (Label)row.FindControl("Unit");
        //        Label lblPreviousFactory = (Label)previousRow.FindControl("Unit");

        //        if (lblFactory.Text == lblPreviousFactory.Text)
        //        {
        //            if (previousRow.Cells[0].RowSpan == 0)
        //            {
        //                if (row.Cells[0].RowSpan == 0)
        //                {
        //                    previousRow.Cells[0].RowSpan += 2;
        //                }
        //                else
        //                {
        //                    previousRow.Cells[0].RowSpan = row.Cells[0].RowSpan + 1;
        //                }
        //                row.Cells[0].Visible = false;
        //            }
        //        }
        //    }
        //}
    }
}