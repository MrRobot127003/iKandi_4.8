using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;
using System.Web.UI.HtmlControls;

namespace iKandi.Web.UserControls.Reports
{
    public partial class frmOutHouse_AuditEntry_Report : System.Web.UI.UserControl
    {

        int TotalAverage = 0;
        int TotalProcess = 0;
        AdminController objadmin = new AdminController();

        protected void Page_Load(object sender, EventArgs e)
        {
            BindHeader();
            GridViewRow grdOutHouseAuditReportrow = grdOutHouseAuditReport.Rows[(grdOutHouseAuditReport.Rows.Count) - 1];
            grdOutHouseAuditReportrow.CssClass = "footerback";
        }

        protected void BindHeader()
        {
            DataSet ds = new DataSet();
            ds = objadmin.GetHeaderOutHouseAuditReport();
            if (grdOutHouseAuditReport.Columns.Count > 0)
            {
                grdOutHouseAuditReport.Columns.Clear();

            }

            TemplateField Unit = new TemplateField();
            Unit.HeaderText = "Unit";
            Unit.ItemTemplate = new iKandi.Common.GridViewTemplate("label", "Unit", "Unit");
            grdOutHouseAuditReport.Columns.Insert(0, Unit);
            Unit.HeaderStyle.CssClass = "FirstChild";
            Unit.HeaderStyle.Width = 150;           

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
                    grdOutHouseAuditReport.Columns.Insert(i + 1, Process);
                    Process.HeaderStyle.Width = 100;
                }

            }
            grdOutHouseAuditReport.Width = 150 + 100 * (Count + 1);
            grdOutHouseAuditReport.DataSource = ds.Tables[0];
            grdOutHouseAuditReport.DataBind();
            //OutHouseAuditReport();
        }
        public int GetQuarter(DateTime date)
        {
            if (date.Month >= 4 && date.Month <= 6)
                return 1;
            else if (date.Month >= 7 && date.Month <= 9)
                return 2;
            else if (date.Month >= 10 && date.Month <= 12)
                return 3;
            else
                return 4;
        }
        protected void grdOutHouseAuditReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                DataSet ds = new DataSet();
                ds = objadmin.GetHeaderOutHouseAuditReport();

                GridViewRow HeaderRow = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell2 = new TableCell();

                DateTime dtnow = DateTime.Now;
                int Quarter = GetQuarter(dtnow);
                string Quarter1 = "";

                if (Quarter == 1)
                {
                    Quarter1 = "Q1";
                }
                else if (Quarter == 2)
                {
                    Quarter1 = "Q2";
                }
                else if (Quarter == 3)
                {
                    Quarter1 = "Q3";
                }
                else if (Quarter == 4)
                {
                    Quarter1 = "Q4";
                }

                HeaderCell2.Text = "Process/Product Safety Audit Outhouse Report (for " + Quarter1 + ")";
                HeaderCell2.ColumnSpan = Convert.ToInt32(ds.Tables[1].Rows.Count) + 1;
                HeaderCell2.Style.Add("text-align", "center");
                HeaderCell2.Style.Add("font-weight", "bold");
                HeaderCell2.Style.Add("background", "lightgrey");
                HeaderRow.Cells.Add(HeaderCell2);

                grdOutHouseAuditReport.Controls[0].Controls.AddAt(0, HeaderRow);
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                DataSet ds = new DataSet();
                ds = objadmin.GetHeaderOutHouseAuditReport();
                DataRowView drv = (DataRowView)e.Row.DataItem;

                string Fabricator_Name = drv.Row.ItemArray[0].ToString().Trim();
                int ValuesID = Convert.ToInt32(drv.Row.ItemArray[1].ToString().Trim());      
                
                Label UnitName = e.Row.FindControl("Unit") as Label;
                UnitName.Text = Fabricator_Name;
                e.Row.Cells[0].Width = 150;
                UnitName.Style.Add("color", "gray");
                e.Row.Cells[0].Style.Add("text-align", "center");
                if (Fabricator_Name.Contains("Average"))
                {
                    e.Row.Cells[0].Style.Add("background", "#c7d4f5");
                    UnitName.Style.Add("color", "#3c3737");
                }
                else
                {
                    e.Row.Cells[0].Style.Add("background", "#DDDFE4");
                }

                TotalAverage = 0;
                TotalProcess = 0;
                //bool blankrow = false;
                int Count = Convert.ToInt32(ds.Tables[1].Rows.Count);
                if (Convert.ToInt32(ds.Tables[1].Rows.Count) > 0)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        string ProcessName = ds.Tables[1].Rows[i]["Process"].ToString();
                        int ProcessType = Convert.ToInt32(ds.Tables[1].Rows[i]["ProcessType"]);
                        HtmlTableCell processnew = e.Row.FindControl("Process" + Convert.ToString(ds.Tables[1].Rows[i]["Process"])) as HtmlTableCell;
                        Label Process = e.Row.FindControl("Process" + Convert.ToString(ds.Tables[1].Rows[i]["Process"])) as Label;
                        //if ((ProcessName == "Day alteration count") || (ProcessName == "Operator on machine"))
                        //      Process.Text = objadmin.Get_BrealDownForOuthouse(ProcessName, ValuesID, TotalAverage, TotalProcess); // EFW.ToString();
                        //else 
                        //      Process.Text = objadmin.Get_BrealDownForOuthouse(ProcessName, ValuesID, TotalAverage, TotalProcess) + "%";
                        Process.Text = objadmin.Get_BrealDownForOuthouse(ProcessName, ValuesID, TotalAverage, TotalProcess) + "%";
                        Process.ForeColor = System.Drawing.Color.Yellow;
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
                            e.Row.Cells[i + 1].Style.Add("Background", "red");
                            e.Row.Cells[i + 1].Style.Add("font-weight", "bold");
                            if (Convert.ToInt32(Process.Text.Trim().Replace("%", "")) == 1)
                            {
                                Process.Visible = false;
                            }
                        }
                        else
                        {
                            if (Convert.ToInt32(Process.Text.Trim().Replace("%", "")) > 79 && Convert.ToInt32(Process.Text.Trim().Replace("%", "")) < 91)
                            {
                                e.Row.Cells[i + 1].Style.Add("Background", "orange");
                                e.Row.Cells[i + 1].Style.Add("font-weight", "bold");
                            }
                            else
                            {
                                e.Row.Cells[i + 1].Style.Add("Background", "green");
                                e.Row.Cells[i + 1].Style.Add("font-weight", "bold");
                            }
                        }
                        if (Process.Text.Trim().Replace("%", "") == "0" || Process.Text.Trim().Replace("%", "") == "")
                        {
                            Process.Text = "";
                            e.Row.Cells[i + 1].Style.Add("Background", "white");
                        }
                        else
                        {
                            TotalProcess = TotalProcess + 1;
                            TotalAverage = TotalAverage + Convert.ToInt32(Process.Text.Trim().Replace("%", ""));
                            //blankrow = true;
                        }

                    }

                }
                //if (blankrow == false)
                //{
                //    e.Row.Visible = false;
                //}
            }
        }

        public void OutHouseAuditReport()
        {
            int index = grdOutHouseAuditReport.Rows.Count - 1;
            for (int i = grdOutHouseAuditReport.Rows.Count - 1; i > 0; i--)
            {
                GridViewRow row = grdOutHouseAuditReport.Rows[i];
                GridViewRow previousRow = grdOutHouseAuditReport.Rows[index - 1];

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
    }
}