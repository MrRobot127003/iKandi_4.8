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
    public partial class DailyMMRDetailReport : System.Web.UI.UserControl
    {

        AdminController objAdminController = new AdminController();
        //int CurrentLoggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            string WorkerType = txtWorker.Value;
            string Dept = DDl_Dept.SelectedItem.ToString();
            string CreatedDate = txtCreatedDate.Value;

            if (!IsPostBack)
            {
                bindgrd(WorkerType, Dept, CreatedDate);
                bingrdShortfall(CreatedDate);
            }
        }

        protected decimal OT;
        protected int working_days;
        protected int working_hours;
        protected double multiplier;
        protected double total_OT_Hours;

        DataTable dt_staff;
        DataTable dt_cmtAdmin;

        public void bindgrd(string WorkerType, string Dept, string CreatedDate)
        {


            DataSet ds = objAdminController.GetMMRreport(WorkerType, Dept, CreatedDate);
            dt_staff = new DataTable();
            dt_staff = ds.Tables[0];
            dt_cmtAdmin = ds.Tables[1];

            foreach (DataRow row in dt_cmtAdmin.Rows)
            {

                hdnOT.Value = row["OT1"].ToString();
                hdnworkingdays.Value = row["Barrier_Days_Slot_1_Values"].ToString();
                hdnworkinghour.Value = row["WorkingHrs"].ToString();
                hdnmultiplier.Value = row["MMRMultiplierFact"].ToString();

                OT = Convert.ToDecimal(row["OT1"].ToString());
                working_hours = Convert.ToInt32(row["WorkingHrs"].ToString());
                working_days = Convert.ToInt32(row["Barrier_Days_Slot_1_Values"].ToString());
                multiplier = Convert.ToDouble(row["MMRMultiplierFact"].ToString());
            }
            grdMMReport.DataSource = ds.Tables[0];
            grdMMReport.DataBind();


        }
        public void bingrdShortfall(string CreatedDate)
        {


            DataSet ds = objAdminController.GetBIPLBudgetShortfall(CreatedDate);

            grdBudgetShortfall.DataSource = ds.Tables[0];
            grdBudgetShortfall.DataBind();


        }

        protected void grdMMReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl_Depart = (DropDownList)e.Row.FindControl("ddl_Depart");

                Label lbFinancialBudgetC47 = (Label)e.Row.FindControl("lbFinancialBudgetC47");
                Label lblFinancialTodayC47 = (Label)e.Row.FindControl("lblFinancialTodayC47");
                TextBox txtManPowerBudgetC47 = (TextBox)e.Row.FindControl("txtManPowerBudgetC47");
                TextBox txtManPowerTodayC47 = (TextBox)e.Row.FindControl("txtManPowerTodayC47");

                Label lbFinancialBudgetC45 = (Label)e.Row.FindControl("lbFinancialBudgetC45");
                Label lblFinancialTodayC45 = (Label)e.Row.FindControl("lblFinancialTodayC45");
                TextBox txtManPowerBudgetC45 = (TextBox)e.Row.FindControl("txtManPowerBudgetC45");
                TextBox txtManPowerTodayC45 = (TextBox)e.Row.FindControl("txtManPowerTodayC45");

                Label lbFinancialBudgetD169 = (Label)e.Row.FindControl("lbFinancialBudgetD169");
                Label lblFinancialTodayD169 = (Label)e.Row.FindControl("lblFinancialTodayD169");
                TextBox txtManPowerBudgetD169 = (TextBox)e.Row.FindControl("txtManPowerBudgetD169");
                TextBox txtManPowerTodayD169 = (TextBox)e.Row.FindControl("txtManPowerTodayD169");

                Label lbFinancialBudgetBIPL = (Label)e.Row.FindControl("lbFinancialBudgetBIPL");
                Label lblFinancialTodayBIPL = (Label)e.Row.FindControl("lblFinancialTodayBIPL");
                TextBox txtManPowerBudgetBIPL = (TextBox)e.Row.FindControl("txtManPowerBudgetBIPL");
                TextBox txtManPowerTodayBIPL = (TextBox)e.Row.FindControl("txtManPowerTodayBIPL");

                Label lbl_obsed = (Label)e.Row.FindControl("lbl_obsed");
                Label lbl_Status = (Label)e.Row.FindControl("lbl_Status");
                //bind dropdownlist
                ddl_Depart.Items.Clear();

                //ddlStaffItem = new ListItem("irornig", "4");
                ddl_Depart.Items.Insert(0, new ListItem("Stitching"));
                ddl_Depart.Items.Insert(1, new ListItem("Finishing"));
                ddl_Depart.Items.Insert(2, new ListItem("Cutting"));
                ddl_Depart.Items.Insert(3, new ListItem("Misc"));
                ddl_Depart.Items.Insert(3, new ListItem("Xny"));
                ddl_Depart.Items.Insert(4, new ListItem("Accessory"));
                ddl_Depart.Items.Insert(5, new ListItem("R&D"));
                ddl_Depart.Items.Insert(6, new ListItem("Fabric"));

                DataRowView dr = e.Row.DataItem as DataRowView;
                ddl_Depart.SelectedValue = dr["StaffDept"].ToString();

                //new code 12 may 2020 by raghvinder starts
                double BudgetBIPL = ((txtManPowerBudgetC47.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetC47).Text))) + ((txtManPowerBudgetC45.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetC45).Text))) + ((txtManPowerBudgetD169.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetD169).Text)));
                double TodayBIPL = ((txtManPowerTodayC47.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC47).Text))) + ((txtManPowerTodayC45.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC45).Text))) + ((txtManPowerTodayD169.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayD169).Text)));

                decimal Salary = Convert.ToDecimal(dr["Salary"].ToString());
                bool isStatus = Convert.ToBoolean(dr["isStatus"].ToString());

                total_OT_Hours = Convert.ToDouble(OT) * working_days;
                hdnTotalOTHours.Value = total_OT_Hours.ToString();

                if (lbl_obsed.Text == "True")
                {
                    lbl_obsed.Text = "OB Based";
                }
                else
                {
                    lbl_obsed.Text = "Non OB based";
                }

                if (lbl_Status.Text == "True")
                {
                    lbl_Status.Text = "Yes";
                }
                else
                {
                    lbl_Status.Text = "No";
                }

                if (isStatus == false)
                {
                    double financialbudgetC47 = Convert.ToDouble(Salary) * 1.1 * (txtManPowerBudgetC47.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetC47).Text));

                    if (financialbudgetC47 != 0)
                    {
                        lbFinancialBudgetC47.Text = Math.Round(financialbudgetC47).ToString();
                    }
                    else
                    {
                        lbFinancialBudgetC47.Text = "";
                    }

                    double financialTodayC47 = Convert.ToDouble(Salary) * 1.1 * (txtManPowerTodayC47.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC47).Text));

                    if (financialTodayC47 != 0)
                    {
                        lblFinancialTodayC47.Text = Math.Round(financialTodayC47).ToString();
                    }
                    else
                    {
                        lblFinancialTodayC47.Text = "";
                    }

                    double financialbudgetC45 = Convert.ToDouble(Salary) * 1.1 * (txtManPowerBudgetC45.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetC45).Text));

                    if (financialbudgetC45 != 0)
                    {
                        lbFinancialBudgetC45.Text = Math.Round(financialbudgetC45).ToString();
                    }
                    else
                    {
                        lbFinancialBudgetC45.Text = "";
                    }
                    double financialTodayC45 = Convert.ToDouble(Salary) * 1.1 * (txtManPowerTodayC45.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC45).Text));

                    if (financialTodayC45 != 0)
                    {
                        lblFinancialTodayC45.Text = Math.Round(financialTodayC45).ToString();
                    }
                    else
                    {
                        lblFinancialTodayC45.Text = "";
                    }

                    double financialbudgetD169 = Convert.ToDouble(Salary) * 1.1 * (txtManPowerBudgetD169.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetD169).Text));

                    if (financialbudgetD169 != 0)
                    {
                        lbFinancialBudgetD169.Text = Math.Round(financialbudgetD169).ToString();
                    }
                    else
                    {
                        lbFinancialBudgetD169.Text = "";
                    }
                    double financialTodayD169 = Convert.ToDouble(Salary) * 1.1 * (txtManPowerTodayD169.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayD169).Text));

                    if (financialTodayD169 != 0)
                    {
                        lblFinancialTodayD169.Text = Math.Round(financialTodayD169).ToString();
                    }
                    else
                    {
                        lblFinancialTodayD169.Text = "";
                    }

                    double financialbudgetBIPL = Convert.ToDouble(Salary) * 1.1 * (txtManPowerBudgetBIPL.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetBIPL).Text));

                    if (financialbudgetBIPL != 0)
                    {
                        lbFinancialBudgetBIPL.Text = Math.Round(financialbudgetBIPL).ToString();
                    }
                    else
                    {
                        lbFinancialBudgetBIPL.Text = "";
                    }

                    double financialTodayBIPL = Convert.ToDouble(Salary) * 1.1 * (txtManPowerTodayBIPL.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayBIPL).Text));

                    if (financialTodayBIPL != 0)
                    {
                        lblFinancialTodayBIPL.Text = Math.Round(financialTodayBIPL).ToString();
                    }
                    else
                    {
                        lblFinancialTodayBIPL.Text = "";
                    }
                }
                else
                {
                    double financialbudgetC47 = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerBudgetC47.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetC47).Text));

                    if (financialbudgetC47 != 0)
                    {
                        lbFinancialBudgetC47.Text = Math.Round(financialbudgetC47).ToString();
                    }
                    else
                    {
                        lbFinancialBudgetC47.Text = "";
                    }

                    double financialTodayC47 = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerTodayC47.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC47).Text));

                    if (financialTodayC47 != 0)
                    {
                        lblFinancialTodayC47.Text = Math.Round(financialTodayC47).ToString();
                    }
                    else
                    {
                        lblFinancialTodayC47.Text = "";
                    }

                    double financialbudgetC45 = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerBudgetC45.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetC45).Text));

                    if (financialbudgetC45 != 0)
                    {
                        lbFinancialBudgetC45.Text = Math.Round(financialbudgetC45).ToString();
                    }
                    else
                    {
                        lbFinancialBudgetC45.Text = "";
                    }

                    double financialTodayC45 = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerTodayC45.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC45).Text));

                    if (financialTodayC45 != 0)
                    {
                        lblFinancialTodayC45.Text = Math.Round(financialTodayC45).ToString();
                    }
                    else
                    {
                        lblFinancialTodayC45.Text = "";
                    }

                    double financialbudgetD169 = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerBudgetD169.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetD169).Text));

                    if (financialbudgetD169 != 0)
                    {
                        lbFinancialBudgetD169.Text = Math.Round(financialbudgetD169).ToString();
                    }
                    else
                    {
                        lbFinancialBudgetD169.Text = "";
                    }

                    double financialTodayD169 = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerTodayD169.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayD169).Text));

                    if (financialTodayD169 != 0)
                    {
                        lblFinancialTodayD169.Text = Math.Round(financialTodayD169).ToString();
                    }
                    else
                    {
                        lblFinancialTodayD169.Text = "";
                    }

                    double financialbudgetBIPL = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerBudgetBIPL.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetBIPL).Text));

                    if (financialbudgetBIPL != 0)
                    {
                        lbFinancialBudgetBIPL.Text = Math.Round(financialbudgetBIPL).ToString();
                    }
                    else
                    {
                        lbFinancialBudgetBIPL.Text = "";
                    }

                    double financialTodayBIPL = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerTodayBIPL.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayBIPL).Text));

                    if (financialTodayBIPL != 0)
                    {
                        lblFinancialTodayBIPL.Text = Math.Round(financialTodayBIPL).ToString();
                    }
                    else
                    {
                        lblFinancialTodayBIPL.Text = "";
                    }
                }
                //new code 12 may 2020 by raghvinder starts                
            }
        }

              
        

        protected void grdMMReport_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Department";
                HeaderCell.RowSpan = 3;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "150px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Worker Type";
                HeaderCell.RowSpan = 3;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "480px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "OB Based";
                HeaderCell.RowSpan = 3;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "280px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Salary";
                HeaderCell.RowSpan = 3;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "100px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Status";
                HeaderCell.RowSpan = 3;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Style.Add("width", "70px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "C-47";
                HeaderCell.ColumnSpan = 4;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "C45-46";
                HeaderCell.ColumnSpan = 4;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "D-169";
                HeaderCell.ColumnSpan = 4;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "BIPL (Excl. Outhouse";
                HeaderCell.ColumnSpan = 4;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);
                grdMMReport.Controls[0].Controls.AddAt(0, HeaderGridRow);

                GridViewRow HeaderGridRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Manpower";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Financial";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Manpower";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Financial";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Manpower";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Financial";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Manpower";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 2;
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Financial";
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow1.Cells.Add(HeaderCell);

                grdMMReport.Controls[0].Controls.AddAt(1, HeaderGridRow1);

                GridViewRow HeaderGridRow2 = new GridViewRow(2, 0, DataControlRowType.Header, DataControlRowState.Insert);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Budget";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Today";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Budget(Lakh)";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Today(Lakh)";
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
                HeaderCell.Text = "Today";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Budget(Lakh)";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Today(Lakh)";
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
                HeaderCell.Text = "Today";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Budget(Lakh)";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Today(Lakh)";
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
                HeaderCell.Text = "Today";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Budget(Lakh)";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Today(Lakh)";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow2.Cells.Add(HeaderCell);

                grdMMReport.Controls[0].Controls.AddAt(2, HeaderGridRow2);
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string WorkerType = txtWorker.Value;
            string Dept = DDl_Dept.SelectedItem.ToString();
            string CreatedDate = txtCreatedDate.Value;
            bindgrd(WorkerType, Dept, CreatedDate);
            bingrdShortfall(CreatedDate);
        }

        //protected void btnSaveShortfall_Click(object sender, EventArgs e)
        //{
        //    string CreatedDate = txtCreatedDate.Value;
        //    string strShortfallQuery = "<table>";
        //    foreach (GridViewRow row in grdBudgetShortfall.Rows)
        //    {

        //        //if (((TextBox)row.FindControl("txtWorkerType")).Text == "" &&
        //        //   ((DropDownList)row.FindControl("ddl_Depart")).Text == "" &&
        //        //   ((TextBox)row.FindControl("txtManPowerBudgetC47")).Text == "" &&
        //        //   ((TextBox)row.FindControl("txtManPowerTodayC47")).Text == "" &&
        //        //   ((TextBox)row.FindControl("txtManPowerBudgetC45")).Text == "" &&
        //        //   ((TextBox)row.FindControl("txtManPowerTodayC45")).Text == "" &&
        //        //   ((TextBox)row.FindControl("txtManPowerBudgetD169")).Text == "" &&
        //        //   ((TextBox)row.FindControl("txtManPowerTodayD169")).Text == "" &&
        //        //   ((TextBox)row.FindControl("txtManPowerBudgetBIPL")).Text == "" &&
        //        //   ((TextBox)row.FindControl("txtManPowerTodayBIPL")).Text == "")
        //        //    continue;
        //        string Designation = null;
        //        int? Shortfall = null;
        //        string ReasonForShortfall = null;
        //        string OnTrial = null;
        //        string HRremarks = null;
        //        int FactoryWorkspace = 0;

        //        //FactoryWorkspace = Convert.ToInt16(((HiddenField)row.FindControl("hdnworkerType")).Value);
        //        if (((Label)row.FindControl("lblDepartment")).Text != "")
        //        {
        //            Designation = Convert.ToString(((Label)row.FindControl("lblDepartment")).Text.Trim());

        //        }
        //        if (((Label)row.FindControl("lblShortfall")).Text != "")
        //        {
        //            Shortfall = Convert.ToInt32(((Label)row.FindControl("lblShortfall")).Text.Trim());

        //        }
        //        if (((TextBox)row.FindControl("txtReasonForShortfall")).Text != "")
        //        {
        //            ReasonForShortfall = Convert.ToString(((TextBox)row.FindControl("txtReasonForShortfall")).Text.Trim());
        //        }

        //        if (((TextBox)row.FindControl("txtOnTrial")).Text != "")
        //        {
        //            OnTrial = Convert.ToString(((TextBox)row.FindControl("txtOnTrial")).Text.Trim());
        //        }
        //        if (((TextBox)row.FindControl("txtHRremark")).Text != "")
        //        {
        //            HRremarks = Convert.ToString(((TextBox)row.FindControl("txtHRremark")).Text.Trim());
        //        }
        //        int CreatedBy = 0;
        //        if (CurrentLoggedInUserID > 0)
        //        {
        //            CreatedBy = CurrentLoggedInUserID;
        //        }

        //        strShortfallQuery = strShortfallQuery + "<Designation>" + Designation +
        //        "</Designation><ReasonForShortfall>" + ReasonForShortfall +
        //        "</ReasonForShortfall><OnTrial>" + OnTrial +
        //        "</OnTrial><HRremarks>" + HRremarks + "</HRremarks><CreatedBy>" + CreatedBy.ToString() +
        //        "</CreatedBy><CreatedDate>" + CreatedDate + "</CreatedDate>";
        //    }
        //    strShortfallQuery = strShortfallQuery + "</table>";
        //    int row_no = 0;
        //    if (strShortfallQuery != "<table></table>")
        //    {
        //        string script = string.Empty;
        //        row_no = objAdminController.InsertBudgetShortfall_Report(strShortfallQuery, CreatedDate);
        //        if (row_no > 0)
        //        {
        //            ShowAlert("Saved Successfully!");
        //        }
        //        else
        //        {
        //            ShowAlert("Error on Saving!");
        //        }
        //    }
        //    if (row_no > 0)
        //    {
        //        txtWorker.Value = "";
        //        txtWorker.Focus();
        //        DDl_Dept.SelectedValue = "-1";
        //    }
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
                //HeaderCell.Style.Add("width", "150px");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

                grdBudgetShortfall.Controls[0].Controls.AddAt(0, HeaderGridRow);

                GridViewRow HeaderGridRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Designation";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Shortfall";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Reason for Shortfall";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "On Trial";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "HR Remarks";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderGridRow1.Cells.Add(HeaderCell);


                grdBudgetShortfall.Controls[0].Controls.AddAt(1, HeaderGridRow1);

            }
        }
    }
}
