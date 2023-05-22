using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;
using iKandi.Web.Components;


namespace iKandi.Web.Internal.Reports
{
    public partial class DailyMMRDetail : System.Web.UI.Page
    {

        AdminController objAdminController = new AdminController();
        PermissionController objPermissionController = new PermissionController();
        //int CurrentLoggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;        

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check Login Permissions
            DataTable dt = objPermissionController.GetLoginActivate(ApplicationHelper.LoggedInUser.UserData.UserID).Tables[0];

            //objAdminController.MMRLogOut(ApplicationHelper.LoggedInUser.UserData.UserID, 1);
            string WorkerType = txtWorker.Value;
            string Dept = DDl_Dept.SelectedItem.ToString();

            if (!IsPostBack)
            {
                if (dt.Rows[0]["MMRReportsActive"].ToString() == "0")
                {
                    // log out and show error
                    ShowAlert("Someone else is using MMR entry, When it finished then only you can access!");
                    pnlMain.Visible = false;
                    pnlMessage.Visible = true;
                    return;
                }
                else
                {
                    //

                    UserPermission();
                    txtCreatedDate.Value = DateTime.Now.ToString("dd MMM yy (ddd)");

                    bindgrd(WorkerType, Dept, DateTime.ParseExact(txtCreatedDate.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture).ToString());
                    bingrdShortfall(DateTime.ParseExact(txtCreatedDate.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture).ToString());

                    if (dt.Rows[0]["DepartmentID"].ToString() != "19")
                    {
                        btnSaveShortfall.Visible = false;
                        btnSaveCmtAdminRateAndPieces.Visible = false;
                        btnSaveOTDays.Visible = false;
                        btnSave.Visible = false;
                    }
                }
            }
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }

        private void UserPermission()
        {
            DataTable dt = objPermissionController.GetMMRPermission(ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID, ApplicationHelper.LoggedInUser.UserData.DesignationID, (int)iKandi.Common.AppModuleColumn.MMR_REPORT_BUTTON).Tables[0];

            int writePermission = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                writePermission = Convert.ToInt32(dt.Rows[i]["PermissionType"]);
            }


            if (writePermission == 2)
            {
                btnSaveShortfall.Enabled = true;
                btnSaveCmtAdminRateAndPieces.Enabled = true;
                btnSaveOTDays.Enabled = true;
                btnSave.Enabled = true;
            }
            else
            {
                btnSaveShortfall.Enabled = false;
                btnSaveCmtAdminRateAndPieces.Enabled = false;
                btnSaveOTDays.Enabled = false;
                btnSave.Enabled = false;
            }
        }

        protected decimal OT;
        protected int working_days;
        protected int working_hours;
        protected double multiplier;
        protected double total_OT_Hours;
        protected int working_days_OT;
        protected decimal OTDaysPerc = 0.1M;


        DataTable dt_staff;
        DataTable dt_cmtAdmin;
        DataTable dt_OTDays;

        public void bindgrd(string WorkerType, string Dept, string CreatedDate)
        {


            DataSet ds = objAdminController.GetMMRreport(WorkerType, Dept, CreatedDate);
            dt_staff = new DataTable();
            dt_staff = ds.Tables[0];
            dt_cmtAdmin = ds.Tables[1];
            dt_OTDays = ds.Tables[2];

            foreach (DataRow row in dt_OTDays.Rows)
            {
                txtOTDays.Value = row["OTDays"].ToString();
                working_days_OT = Convert.ToInt32(row["OTDays"].ToString());
            }

            foreach (DataRow row in dt_cmtAdmin.Rows)
            {

                hdnOT.Value = row["OT1"].ToString();
                hdnworkingdays.Value = row["Barrier_Days_Slot_1_Values"].ToString();
                hdnworkinghour.Value = row["WorkingHrs"].ToString();
                //hdnmultiplier.Value = row["MMRMultiplierFact"].ToString();

                OT = Convert.ToDecimal(row["OT1"].ToString());
                working_hours = Convert.ToInt32(row["WorkingHrs"].ToString());
                working_days = Convert.ToInt32(row["Barrier_Days_Slot_1_Values"].ToString());
                //multiplier = Convert.ToDouble(row["MMRMultiplierFact"].ToString());                

                txtRate.Value = row["Rate"].ToString();
                int abc = Convert.ToInt32(row["Pieces"].ToString());
                string str = abc.ToString("N0");
                txtPieces.Value = str;

            }

            grdMMReport.DataSource = ds.Tables[0];
            grdMMReport.DataBind();


        }
        public void bingrdShortfall(string CreatedDate)
        {
            // CreatedDate = DateTime.ParseExact(CreatedDate, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture).ToString();

            DataSet ds = objAdminController.GetBIPLBudgetShortfall(CreatedDate);

            grdBudgetShortfall.DataSource = ds.Tables[0];
            grdBudgetShortfall.DataBind();


        }

        protected void grdMMReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddl_Depart = (DropDownList)e.Row.FindControl("ddl_Depart");
                TextBox txtWorkerType = (TextBox)e.Row.FindControl("txtWorkerType");

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

                //Label lbFinancialBudgetC52 = (Label)e.Row.FindControl("lbFinancialBudgetC52");
                //Label lblFinancialTodayC52 = (Label)e.Row.FindControl("lblFinancialTodayC52");
                //TextBox txtManPowerBudgetC52 = (TextBox)e.Row.FindControl("txtManPowerBudgetC52");
                //TextBox txtManPowerTodayC52 = (TextBox)e.Row.FindControl("txtManPowerTodayC52");

                Label lbFinancialBudgetBIPL = (Label)e.Row.FindControl("lbFinancialBudgetBIPL");
                Label lblFinancialTodayBIPL = (Label)e.Row.FindControl("lblFinancialTodayBIPL");
                TextBox txtManPowerBudgetBIPL = (TextBox)e.Row.FindControl("txtManPowerBudgetBIPL");
                TextBox txtManPowerTodayBIPL = (TextBox)e.Row.FindControl("txtManPowerTodayBIPL");

                Label lbl_Salary = (Label)e.Row.FindControl("lbl_Salary");

                Label lbl_obsed = (Label)e.Row.FindControl("lbl_obsed");
                Label lbl_Status = (Label)e.Row.FindControl("lbl_Status");
                ddl_Depart.Items.Clear();

                ddl_Depart.Items.Insert(0, new ListItem("Accessory"));
                ddl_Depart.Items.Insert(1, new ListItem("Cutting"));
                ddl_Depart.Items.Insert(2, new ListItem("Fabric"));
                ddl_Depart.Items.Insert(3, new ListItem("Finishing"));
                ddl_Depart.Items.Insert(4, new ListItem("Misc"));
                ddl_Depart.Items.Insert(5, new ListItem("R&D"));
                ddl_Depart.Items.Insert(6, new ListItem("Stitching"));
                ddl_Depart.Items.Insert(7, new ListItem("Xny"));


                if (lbl_Salary.Text != "")
                {
                    lbl_Salary.Text = Convert.ToInt32(lbl_Salary.Text).ToString("N0");
                }


                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 13 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 18 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 19 || ApplicationHelper.LoggedInUser.UserData.DesignationID == 54)
                {
                    txtManPowerBudgetC47.ReadOnly = false;
                    txtManPowerBudgetC45.ReadOnly = false;
                    txtManPowerBudgetD169.ReadOnly = false;
                    //txtManPowerBudgetC52.ReadOnly = false;
                    txtManPowerBudgetBIPL.ReadOnly = false;
                }
                if (ApplicationHelper.LoggedInUser.UserData.DesignationID == 44)
                {
                    btnSave.Visible = false;
                }

                DataRowView dr = e.Row.DataItem as DataRowView;
                ddl_Depart.SelectedValue = dr["StaffDept"].ToString();

                //added on 12-05-2020 by raghvinder starts
                //double BudgetBIPL = ((txtManPowerBudgetC47.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetC47).Text))) + ((txtManPowerBudgetC45.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetC45).Text))) + ((txtManPowerBudgetD169.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetD169).Text))) + ((txtManPowerBudgetC52.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetC52).Text)));
                double BudgetBIPL = ((txtManPowerBudgetC47.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetC47).Text))) + ((txtManPowerBudgetC45.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetC45).Text))) + ((txtManPowerBudgetD169.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetD169).Text)));
                //double TodayBIPL = ((txtManPowerTodayC47.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC47).Text))) + ((txtManPowerTodayC45.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC45).Text))) + ((txtManPowerTodayD169.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayD169).Text))) + ((txtManPowerTodayC52.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC52).Text)));
                double TodayBIPL = ((txtManPowerTodayC47.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC47).Text))) + ((txtManPowerTodayC45.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC45).Text))) + ((txtManPowerTodayD169.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayD169).Text)));

                double Salary = Convert.ToDouble(dr["Salary"].ToString());
                bool isStatus = Convert.ToBoolean(dr["isStatus"].ToString());

                total_OT_Hours = Convert.ToDouble(OT) * working_days_OT;
                multiplier = Convert.ToDouble(1 + ((OT * (((decimal)working_days_OT / (decimal)working_days) * OTDaysPerc)) / OT));
                hdnmultiplier.Value = multiplier.ToString();
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
                        lbFinancialBudgetC47.Text = Math.Round(financialbudgetC47, MidpointRounding.AwayFromZero).ToString("#,##0");
                    }
                    else
                    {
                        lbFinancialBudgetC47.Text = "";
                    }

                    double financialTodayC47 = Convert.ToDouble(Salary) * 1.1 * (txtManPowerTodayC47.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC47).Text));

                    if (financialTodayC47 != 0)
                    {
                        lblFinancialTodayC47.Text = Math.Round(financialTodayC47, MidpointRounding.AwayFromZero).ToString("#,##0");
                    }
                    else
                    {
                        lblFinancialTodayC47.Text = "";
                    }

                    double financialbudgetC45 = Convert.ToDouble(Salary) * 1.1 * (txtManPowerBudgetC45.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetC45).Text));

                    if (financialbudgetC45 != 0)
                    {
                        lbFinancialBudgetC45.Text = Math.Round(financialbudgetC45, MidpointRounding.AwayFromZero).ToString("N0");
                    }
                    else
                    {
                        lbFinancialBudgetC45.Text = "";
                    }
                    double financialTodayC45 = Convert.ToDouble(Salary) * 1.1 * (txtManPowerTodayC45.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC45).Text));

                    if (financialTodayC45 != 0)
                    {
                        lblFinancialTodayC45.Text = Math.Round(financialTodayC45, MidpointRounding.AwayFromZero).ToString("N0");
                    }
                    else
                    {
                        lblFinancialTodayC45.Text = "";
                    }

                    double financialbudgetD169 = Convert.ToDouble(Salary) * 1.1 * (txtManPowerBudgetD169.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetD169).Text));

                    if (financialbudgetD169 != 0)
                    {
                        lbFinancialBudgetD169.Text = Math.Round(financialbudgetD169, MidpointRounding.AwayFromZero).ToString("N0");
                    }
                    else
                    {
                        lbFinancialBudgetD169.Text = "";
                    }
                    double financialTodayD169 = Convert.ToDouble(Salary) * 1.1 * (txtManPowerTodayD169.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayD169).Text));

                    if (financialTodayD169 != 0)
                    {
                        lblFinancialTodayD169.Text = Math.Round(financialTodayD169, MidpointRounding.AwayFromZero).ToString("N0");
                    }
                    else
                    {
                        lblFinancialTodayD169.Text = "";
                    }


                    //new unit added start
                    //double financialbudgetC52 = Convert.ToDouble(Salary) * 1.1 * (txtManPowerBudgetC52.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetC52).Text));

                    //if (financialbudgetC52 != 0)
                    //{
                    //    lbFinancialBudgetC52.Text = Math.Round(financialbudgetC52, MidpointRounding.AwayFromZero).ToString("N0");
                    //}
                    //else
                    //{
                    //    lbFinancialBudgetC52.Text = "";
                    //}
                    //double financialTodayC52 = Convert.ToDouble(Salary) * 1.1 * (txtManPowerTodayC52.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC52).Text));

                    //if (financialTodayC52 != 0)
                    //{
                    //    lblFinancialTodayC52.Text = Math.Round(financialTodayC52, MidpointRounding.AwayFromZero).ToString("N0");
                    //}
                    //else
                    //{
                    //    lblFinancialTodayC52.Text = "";
                    //}
                    //new unit added end

                    double financialbudgetBIPL = Convert.ToDouble(Salary) * 1.1 * (txtManPowerBudgetBIPL.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetBIPL).Text));

                    if (financialbudgetBIPL != 0)
                    {
                        lbFinancialBudgetBIPL.Text = Math.Round(financialbudgetBIPL, MidpointRounding.AwayFromZero).ToString("N0");
                    }
                    else
                    {
                        lbFinancialBudgetBIPL.Text = "";
                    }

                    double financialTodayBIPL = Convert.ToDouble(Salary) * 1.1 * (txtManPowerTodayBIPL.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayBIPL).Text));

                    if (financialTodayBIPL != 0)
                    {
                        lblFinancialTodayBIPL.Text = Math.Round(financialTodayBIPL, MidpointRounding.AwayFromZero).ToString("N0");
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
                        lbFinancialBudgetC47.Text = Math.Round(financialbudgetC47, MidpointRounding.AwayFromZero).ToString("N0");
                    }
                    else
                    {
                        lbFinancialBudgetC47.Text = "";
                    }

                    double financialTodayC47 = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerTodayC47.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC47).Text));

                    if (financialTodayC47 != 0)
                    {
                        lblFinancialTodayC47.Text = Math.Round(financialTodayC47, MidpointRounding.AwayFromZero).ToString("N0");
                    }
                    else
                    {
                        lblFinancialTodayC47.Text = "";
                    }

                    double financialbudgetC45 = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerBudgetC45.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetC45).Text));

                    if (financialbudgetC45 != 0)
                    {
                        lbFinancialBudgetC45.Text = Math.Round(financialbudgetC45, MidpointRounding.AwayFromZero).ToString("N0");
                    }
                    else
                    {
                        lbFinancialBudgetC45.Text = "";
                    }

                    double financialTodayC45 = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerTodayC45.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC45).Text));

                    if (financialTodayC45 != 0)
                    {
                        lblFinancialTodayC45.Text = Math.Round(financialTodayC45, MidpointRounding.AwayFromZero).ToString("N0");
                    }
                    else
                    {
                        lblFinancialTodayC45.Text = "";
                    }

                    double financialbudgetD169 = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerBudgetD169.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetD169).Text));

                    if (financialbudgetD169 != 0)
                    {
                        lbFinancialBudgetD169.Text = Math.Round(financialbudgetD169, MidpointRounding.AwayFromZero).ToString("N0");
                    }
                    else
                    {
                        lbFinancialBudgetD169.Text = "";
                    }

                    double financialTodayD169 = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerTodayD169.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayD169).Text));

                    if (financialTodayD169 != 0)
                    {
                        lblFinancialTodayD169.Text = Math.Round(financialTodayD169, MidpointRounding.AwayFromZero).ToString("N0");
                    }
                    else
                    {
                        lblFinancialTodayD169.Text = "";
                    }

                    //new unit added start
                    //double financialbudgetC52 = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerBudgetC52.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetC52).Text));

                    //if (financialbudgetC52 != 0)
                    //{
                    //    lbFinancialBudgetC52.Text = Math.Round(financialbudgetC52, MidpointRounding.AwayFromZero).ToString("N0");
                    //}
                    //else
                    //{
                    //    lbFinancialBudgetC52.Text = "";
                    //}

                    //double financialTodayC52 = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerTodayC52.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayC52).Text));

                    //if (financialTodayC52 != 0)
                    //{
                    //    lblFinancialTodayC52.Text = Math.Round(financialTodayC52, MidpointRounding.AwayFromZero).ToString("N0");
                    //}
                    //else
                    //{
                    //    lblFinancialTodayC52.Text = "";
                    //}
                    //new unit added end

                    double financialbudgetBIPL = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerBudgetBIPL.Text == "" ? 0 : Convert.ToDouble((txtManPowerBudgetBIPL).Text));

                    if (financialbudgetBIPL != 0)
                    {
                        lbFinancialBudgetBIPL.Text = Math.Round(financialbudgetBIPL, MidpointRounding.AwayFromZero).ToString("N0");
                    }
                    else
                    {
                        lbFinancialBudgetBIPL.Text = "";
                    }

                    double financialTodayBIPL = (Convert.ToDouble(Salary) + ((Convert.ToDouble(Salary) / working_days / working_hours) * total_OT_Hours * multiplier)) * (txtManPowerTodayBIPL.Text == "" ? 0 : Convert.ToDouble((txtManPowerTodayBIPL).Text));

                    if (financialTodayBIPL != 0)
                    {
                        lblFinancialTodayBIPL.Text = Math.Round(financialTodayBIPL, MidpointRounding.AwayFromZero).ToString("N0");
                    }
                    else
                    {
                        lblFinancialTodayBIPL.Text = "";
                    }
                }
                //added on 12-05-2020 by raghvinder end
            }
        }




        protected void btnSave_Click(object sender, EventArgs e)
        {
            string WorkerType = txtWorker.Value;
            string Dept = DDl_Dept.SelectedItem.ToString();
            //string CreatedDate = txtCreatedDate.Value;
            string CreatedDate = DateTime.ParseExact(txtCreatedDate.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture).ToString();
            if (CreatedDate == "")
            {
                ShowAlert("Date should not blank!");
                return;
            }
            string strQuery = "<table>";
            foreach (GridViewRow row in grdMMReport.Rows)
            {

                if (((TextBox)row.FindControl("txtWorkerType")).Text == "" &&
                   ((DropDownList)row.FindControl("ddl_Depart")).Text == "" &&
                   ((TextBox)row.FindControl("txtManPowerBudgetC47")).Text == "" &&
                   ((TextBox)row.FindControl("txtManPowerTodayC47")).Text == "" &&
                   ((TextBox)row.FindControl("txtManPowerBudgetC45")).Text == "" &&
                   ((TextBox)row.FindControl("txtManPowerTodayC45")).Text == "" &&
                   ((TextBox)row.FindControl("txtManPowerBudgetD169")).Text == "" &&
                   ((TextBox)row.FindControl("txtManPowerTodayD169")).Text == "" &&

                   //((TextBox)row.FindControl("txtManPowerBudgetC52")).Text == "" &&
                    //((TextBox)row.FindControl("txtManPowerTodayC52")).Text == "" &&

                   ((TextBox)row.FindControl("txtManPowerBudgetBIPL")).Text == "" &&
                   ((TextBox)row.FindControl("txtManPowerTodayBIPL")).Text == "")
                    continue;

                int? C47_Manpower_Budget = null;
                int? C47_Manpower_Today = null;
                int? C45_Manpower_Budget = null;
                int? C45_Manpower_Today = null;
                int? D169_Manpower_Budget = null;
                int? D169_Manpower_Today = null;

                //int? C52_Manpower_Budget = null;
                //int? C52_Manpower_Today = null;

                int? BIPL_Manpower_Budget = null;
                int? BIPL_Manpower_Today = null;
                int FactoryWorkspace = 0;

                FactoryWorkspace = Convert.ToInt16(((HiddenField)row.FindControl("hdnworkerType")).Value);

                if (((TextBox)row.FindControl("txtManPowerBudgetC47")).Text != "")
                {
                    C47_Manpower_Budget = Convert.ToInt32(((TextBox)row.FindControl("txtManPowerBudgetC47")).Text.Trim());

                }
                if (((TextBox)row.FindControl("txtManPowerTodayC47")).Text != "")
                {
                    C47_Manpower_Today = Convert.ToInt32(((TextBox)row.FindControl("txtManPowerTodayC47")).Text.Trim());
                }

                if (((TextBox)row.FindControl("txtManPowerBudgetC45")).Text != "")
                {
                    C45_Manpower_Budget = Convert.ToInt32(((TextBox)row.FindControl("txtManPowerBudgetC45")).Text.Trim());
                }
                if (((TextBox)row.FindControl("txtManPowerTodayC45")).Text != "")
                {
                    C45_Manpower_Today = Convert.ToInt32(((TextBox)row.FindControl("txtManPowerTodayC45")).Text.Trim());
                }

                if (((TextBox)row.FindControl("txtManPowerBudgetD169")).Text != "")
                {
                    D169_Manpower_Budget = Convert.ToInt32(((TextBox)row.FindControl("txtManPowerBudgetD169")).Text.Trim());
                }
                if (((TextBox)row.FindControl("txtManPowerTodayD169")).Text != "")
                {
                    D169_Manpower_Today = Convert.ToInt32(((TextBox)row.FindControl("txtManPowerTodayD169")).Text.Trim());
                }


                //if (((TextBox)row.FindControl("txtManPowerBudgetC52")).Text != "")
                //{
                //    C52_Manpower_Budget = Convert.ToInt32(((TextBox)row.FindControl("txtManPowerBudgetC52")).Text.Trim());
                //}
                //if (((TextBox)row.FindControl("txtManPowerTodayC52")).Text != "")
                //{
                //    C52_Manpower_Today = Convert.ToInt32(((TextBox)row.FindControl("txtManPowerTodayC52")).Text.Trim());
                //}




                if (((TextBox)row.FindControl("txtManPowerBudgetBIPL")).Text != "")
                {
                    BIPL_Manpower_Budget = Convert.ToInt32(((TextBox)row.FindControl("txtManPowerBudgetBIPL")).Text.Trim());
                }
                if (((TextBox)row.FindControl("txtManPowerTodayBIPL")).Text != "")
                {
                    BIPL_Manpower_Today = Convert.ToInt32(((TextBox)row.FindControl("txtManPowerTodayBIPL")).Text.Trim());
                }
                int CreatedBy = 0;
                if (ApplicationHelper.LoggedInUser.UserData.UserID > 0)
                {
                    CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                }


                strQuery = strQuery + "<C47_Manpower_Budget>" + C47_Manpower_Budget + "</C47_Manpower_Budget><C47_Manpower_Today>" + C47_Manpower_Today +
                "</C47_Manpower_Today><C45_Manpower_Budget>" + C45_Manpower_Budget + "</C45_Manpower_Budget><C45_Manpower_Today>" + C45_Manpower_Today +
                "</C45_Manpower_Today><D169_Manpower_Budget>" + D169_Manpower_Budget + "</D169_Manpower_Budget><D169_Manpower_Today>" + D169_Manpower_Today +
                "</D169_Manpower_Today><BIPL_Manpower_Budget>" + BIPL_Manpower_Budget + "</BIPL_Manpower_Budget><BIPL_Manpower_Today>" + BIPL_Manpower_Today +
                "</BIPL_Manpower_Today><CreatedBy>" + CreatedBy.ToString() + "</CreatedBy><CreatedDate>" + CreatedDate + "</CreatedDate><FactoryWorkspace>" + FactoryWorkspace.ToString() + "</FactoryWorkspace>";

                //strQuery = strQuery + "<C47_Manpower_Budget>" + C47_Manpower_Budget + "</C47_Manpower_Budget><C47_Manpower_Today>" + C47_Manpower_Today +
                //"</C47_Manpower_Today><C45_Manpower_Budget>" + C45_Manpower_Budget + "</C45_Manpower_Budget><C45_Manpower_Today>" + C45_Manpower_Today +
                //"</C45_Manpower_Today><D169_Manpower_Budget>" + D169_Manpower_Budget + "</D169_Manpower_Budget><D169_Manpower_Today>" + D169_Manpower_Today +
                //"</D169_Manpower_Today><C52_Manpower_Budget>" + C52_Manpower_Budget + "</C52_Manpower_Budget><C52_Manpower_Today>" + C52_Manpower_Today +
                //"</C52_Manpower_Today><BIPL_Manpower_Budget>" + BIPL_Manpower_Budget + "</BIPL_Manpower_Budget><BIPL_Manpower_Today>" + BIPL_Manpower_Today +
                //"</BIPL_Manpower_Today><CreatedBy>" + CreatedBy.ToString() + "</CreatedBy><CreatedDate>" + CreatedDate + "</CreatedDate><FactoryWorkspace>" + FactoryWorkspace.ToString() + "</FactoryWorkspace>";
            }
            strQuery = strQuery + "</table>";
            int row_no = 0;
            if (strQuery != "<table></table>")
            {
                //string script = string.Empty;
                row_no = objAdminController.InserNewMMR_Report(strQuery, CreatedDate);
                //script = "ShowHideMessageBox(true,'Added New MMR Record Successfully.');";
                //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), Guid.NewGuid().ToString(), script, true);
                if (row_no > 0)
                {
                    ShowAlert("Saved Successfully!");
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MRTDailyScrolltop", "MRTDailyScrolltop()", true);

                }
                else
                {
                    ShowAlert("Error on Saving!");

                }

            }
            if (row_no > 0)
            {
                //txtWorker.Value = "";
                //txtWorker.Focus();
                //DDl_Dept.SelectedValue = "-1";

                bindgrd(WorkerType, Dept, CreatedDate);
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

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "C-52";
                //HeaderCell.ColumnSpan = 4;
                //HeaderCell.Style.Add("text-align", "center");
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "BIPL (Excl. Outhouse)";
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

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Manpower";
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.ColumnSpan = 2;
                //HeaderCell.Style.Add("text-align", "center");
                //HeaderGridRow1.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Financial";
                //HeaderCell.Style.Add("text-align", "center");
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.ColumnSpan = 2;
                //HeaderGridRow1.Cells.Add(HeaderCell);

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

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Budget";
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.Style.Add("text-align", "center");
                //HeaderGridRow2.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Today";
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.Style.Add("text-align", "center");
                //HeaderGridRow2.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Budget";
                //HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                //HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                //HeaderCell.Style.Add("text-align", "center");
                //HeaderGridRow2.Cells.Add(HeaderCell);

                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Today";
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
                HeaderCell.Text = "Today";
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

                grdMMReport.Controls[0].Controls.AddAt(2, HeaderGridRow2);
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string WorkerType = txtWorker.Value;
            string Dept = DDl_Dept.SelectedItem.ToString();
            // string CreatedDate = txtCreatedDate.Value;
            //CreatedDate = DateTime.ParseExact(CreatedDate, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture).ToString();
            bindgrd(WorkerType, Dept, DateTime.ParseExact(txtCreatedDate.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture).ToString());
            bingrdShortfall(DateTime.ParseExact(txtCreatedDate.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture).ToString());
        }

        protected void btnSaveShortfall_Click(object sender, EventArgs e)
        {
            //string CreatedDate = txtCreatedDate.Value;
            string CreatedDate = DateTime.ParseExact(txtCreatedDate.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture).ToString();
            if (CreatedDate == "")
            {
                ShowAlert("Date should not blank!");
                return;
            }
            string strShortfallQuery = "<table>";
            foreach (GridViewRow row in grdBudgetShortfall.Rows)
            {
                string Designation = null;
                int? Shortfall = null;
                string ReasonForShortfall = null;
                string OnTrial = null;
                string HRremarks = null;

                if (((Label)row.FindControl("lblDepartment")).Text != "")
                {
                    Designation = Convert.ToString(((Label)row.FindControl("lblDepartment")).Text.Trim());

                }
                if (((Label)row.FindControl("lblShortfall")).Text != "")
                {
                    Shortfall = Convert.ToInt32(((Label)row.FindControl("lblShortfall")).Text.Trim());

                }
                if (((TextBox)row.FindControl("txtReasonForShortfall")).Text != "")
                {
                    ReasonForShortfall = Convert.ToString(((TextBox)row.FindControl("txtReasonForShortfall")).Text.Trim());
                }

                if (((TextBox)row.FindControl("txtOnTrial")).Text != "")
                {
                    OnTrial = Convert.ToString(((TextBox)row.FindControl("txtOnTrial")).Text.Trim());
                }
                if (((TextBox)row.FindControl("txtHRremark")).Text != "")
                {
                    HRremarks = Convert.ToString(((TextBox)row.FindControl("txtHRremark")).Text.Trim());
                }
                int CreatedBy = 0;
                if (ApplicationHelper.LoggedInUser.UserData.UserID > 0)
                {
                    CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                }

                strShortfallQuery = strShortfallQuery + "<Designation>" + Designation +
                "</Designation><ReasonForShortfall>" + ReasonForShortfall +
                "</ReasonForShortfall><OnTrial>" + OnTrial +
                "</OnTrial><HRremarks>" + HRremarks + "</HRremarks><CreatedBy>" + CreatedBy.ToString() +
                "</CreatedBy><CreatedDate>" + CreatedDate + "</CreatedDate>";
            }
            strShortfallQuery = strShortfallQuery + "</table>";
            int row_no = 0;

            if (strShortfallQuery != "<table></table>")
            {
                string script = string.Empty;
                row_no = objAdminController.InsertBudgetShortfall_Report(strShortfallQuery, CreatedDate);
                if (row_no > 0)
                {
                    ShowAlert("Saved Successfully!");
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "MRTDailyScrolltop", "MRTDailyScrolltop()", true);
                }
                else
                {
                    ShowAlert("Error on Saving!");
                }
            }
            if (row_no > 0)
            {
                //txtWorker.Value = "";
                //txtWorker.Focus();
                //DDl_Dept.SelectedValue = "-1";
                bingrdShortfall(CreatedDate);
            }

        }

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
                HeaderCell.Width = 130;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Shortfall";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Width = 80;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "Reason for Shortfall";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Width = 180;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "On Trial";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Width = 80;
                HeaderGridRow1.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "HR Remarks";
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.Width = 120;
                HeaderGridRow1.Cells.Add(HeaderCell);


                grdBudgetShortfall.Controls[0].Controls.AddAt(1, HeaderGridRow1);

            }
        }

        protected void btnSaveCmtAdminRateAndPieces_Click(object sender, EventArgs e)
        {
            int row_no = 0;

            int Pieces = Convert.ToInt32(txtPieces.Value.Replace(",", ""));
            decimal Rate = Convert.ToDecimal(txtRate.Value);
            string script = string.Empty;
            row_no = objAdminController.UpdateCmtAdminRateAndPieces(Rate, Pieces);
            if (row_no > 0)
            {
                ShowAlert("Saved Successfully!");
            }
            else
            {
                ShowAlert("Error on Saving!");
            }

        }

        protected void btnSaveOTDays_Click(object sender, EventArgs e)
        {
            int row_no_OTDays = 0;
            string CreatedDate = DateTime.ParseExact(txtCreatedDate.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture).ToString();
            if (CreatedDate == "")
            {
                ShowAlert("Date should not blank!");
                return;
            }
            int OTDays = Convert.ToInt32(txtOTDays.Value);
            row_no_OTDays = objAdminController.InsertOTDays(CreatedDate, OTDays);
            if (row_no_OTDays > 0)
            {
                ShowAlert("Saved Successfully!");
            }
            else
            {
                ShowAlert("Error on Saving!");
            }
            if (row_no_OTDays > 0)
            {
                string WorkerType = txtWorker.Value;
                string Dept = DDl_Dept.SelectedItem.ToString();
                bindgrd(WorkerType, Dept, CreatedDate);
            }
        }
    }
}