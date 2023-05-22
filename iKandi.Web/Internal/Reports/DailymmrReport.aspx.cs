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
    public partial class DailymmrReport : System.Web.UI.Page
    {
        AdminController objAdminController = new AdminController();
        int CurrentLoggedInUserID = ApplicationHelper.LoggedInUser.UserData.UserID;
        protected void Page_Load(object sender, EventArgs e)
        {
            //string WorkerType = txtWorker.Value;
            //string Dept = DDl_Dept.SelectedItem.ToString();
            //string CreatedDate = txtCreatedDate.Value;

            if (!IsPostBack)
            {
                txtCreatedDate.Value = DateTime.Now.ToString("dd MMM yy (ddd)");
                //bindgrd(CreatedDate);
                bindgrd(DateTime.ParseExact(txtCreatedDate.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture).ToString());
            }
        }
        DataTable dt_cmtAdmin;
        decimal Pcs_Outhouse;
        decimal Avg_Outhouse_cost_per_pc;
        public void bindgrd(string CreatedDate)
        {
            DataSet ds = objAdminController.GetMMRSummaryreport(CreatedDate);
            
            dt_cmtAdmin = ds.Tables[1];
            foreach (DataRow row in dt_cmtAdmin.Rows)
            {
                Pcs_Outhouse = Convert.ToDecimal(row["Pieces"].ToString());
                Avg_Outhouse_cost_per_pc = Convert.ToDecimal(row["Rate"].ToString());
            }            
            grdMMReport.DataSource = ds.Tables[0];
            grdMMReport.DataBind();
            
            
        }

        decimal BudgetC47_total = 0;
        decimal TodayC47_total = 0;
        decimal C47BudgetFinancialTotal = 0;
        decimal C47TodayFinancialTotal = 0;
        decimal BudgetC4546_total = 0;
        decimal TodayC4546_total = 0;
        decimal C4546BudgetFinancialTotal = 0;
        decimal C4546TodayFinancialTotal = 0;
        decimal BudgetD169_total = 0;
        decimal TodayD169_total = 0;
        decimal D169BudgetFinancialTotal = 0;
        decimal D169TodayFinancialTotal = 0;

        decimal BudgetC52_total = 0;
        decimal TodayC52_total = 0;
        decimal C52BudgetFinancialTotal = 0;
        decimal C52TodayFinancialTotal = 0;

        decimal BudgetBIPL_total = 0;
        decimal TodayBIPL_total = 0;
        decimal BIPLBudgetFinancialTotal = 0;
        decimal BIPLTodayFinancialTotal = 0;
        


        protected void grdMMReport_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblDepartment = (Label)e.Row.FindControl("lblDepartment");
                Label lbFinancialBudgetC47 = (Label)e.Row.FindControl("lbFinancialBudgetC47");
                Label lblFinancialTodayC47 = (Label)e.Row.FindControl("lblFinancialTodayC47");
                Label lblManPowerBudgetC47 = (Label)e.Row.FindControl("lblManPowerBudgetC47");
                Label lblManPowerTodayC47 = (Label)e.Row.FindControl("lblManPowerTodayC47");
                Label lbFinancialBudgetC45 = (Label)e.Row.FindControl("lbFinancialBudgetC45");
                Label lblFinancialTodayC45 = (Label)e.Row.FindControl("lblFinancialTodayC45");
                Label lblManPowerBudgetC45 = (Label)e.Row.FindControl("lblManPowerBudgetC45");
                Label lblManPowerTodayC45 = (Label)e.Row.FindControl("lblManPowerTodayC45");
                Label lbFinancialBudgetD169 = (Label)e.Row.FindControl("lbFinancialBudgetD169");
                Label lblFinancialTodayD169 = (Label)e.Row.FindControl("lblFinancialTodayD169");
                Label lblManPowerBudgetD169 = (Label)e.Row.FindControl("lblManPowerBudgetD169");
                Label lblManPowerTodayD169 = (Label)e.Row.FindControl("lblManPowerTodayD169");

                Label lbFinancialBudgetC52 = (Label)e.Row.FindControl("lbFinancialBudgetC52");
                Label lblFinancialTodayC52 = (Label)e.Row.FindControl("lblFinancialTodayC52");
                Label lblManPowerBudgetC52 = (Label)e.Row.FindControl("lblManPowerBudgetC52");
                Label lblManPowerTodayC52 = (Label)e.Row.FindControl("lblManPowerTodayC52");

                Label lbFinancialBudgetBIPL = (Label)e.Row.FindControl("lbFinancialBudgetBIPL");
                Label lblFinancialTodayBIPL = (Label)e.Row.FindControl("lblFinancialTodayBIPL");
                Label lblManPowerBudgetBIPL = (Label)e.Row.FindControl("lblManPowerBudgetBIPL");
                Label lblManPowerTodayBIPL = (Label)e.Row.FindControl("lblManPowerTodayBIPL");

                DataRowView dr = e.Row.DataItem as DataRowView;

                BudgetC47_total += Convert.ToDecimal(lblManPowerBudgetC47.Text);
                TodayC47_total += Convert.ToDecimal(lblManPowerTodayC47.Text);
                C47BudgetFinancialTotal += Convert.ToDecimal(lbFinancialBudgetC47.Text);
                C47TodayFinancialTotal += Convert.ToDecimal(lblFinancialTodayC47.Text);

                BudgetC4546_total += Convert.ToDecimal(lblManPowerBudgetC45.Text);
                TodayC4546_total += Convert.ToDecimal(lblManPowerTodayC45.Text);
                C4546BudgetFinancialTotal += Convert.ToDecimal(lbFinancialBudgetC45.Text);
                C4546TodayFinancialTotal += Convert.ToDecimal(lblFinancialTodayC45.Text);

                BudgetD169_total += Convert.ToDecimal(lblManPowerBudgetD169.Text);
                TodayD169_total += Convert.ToDecimal(lblManPowerTodayD169.Text);
                D169BudgetFinancialTotal += Convert.ToDecimal(lbFinancialBudgetD169.Text);
                D169TodayFinancialTotal += Convert.ToDecimal(lblFinancialTodayD169.Text);


                BudgetC52_total += Convert.ToDecimal(lblManPowerBudgetC52.Text);
                TodayC52_total += Convert.ToDecimal(lblManPowerTodayC52.Text);
                C52BudgetFinancialTotal += Convert.ToDecimal(lbFinancialBudgetC52.Text);
                C52TodayFinancialTotal += Convert.ToDecimal(lblFinancialTodayC52.Text);

                BudgetBIPL_total += Convert.ToDecimal(lblManPowerBudgetBIPL.Text);
                TodayBIPL_total += Convert.ToDecimal(lblManPowerTodayBIPL.Text);
                BIPLBudgetFinancialTotal += Convert.ToDecimal(lbFinancialBudgetBIPL.Text);
                BIPLTodayFinancialTotal += Convert.ToDecimal(lblFinancialTodayBIPL.Text);

                if (Convert.ToDecimal(lbFinancialBudgetC47.Text) > 0)
                {
                    //lbFinancialBudgetC47.Text = "₹ " + Math.Round(Convert.ToDecimal(lbFinancialBudgetC47.Text) / 100000).ToString() + " L";
                    lbFinancialBudgetC47.Text = "₹ " + Math.Round(Convert.ToDecimal(lbFinancialBudgetC47.Text), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                    lbFinancialBudgetC47.Text = (lbFinancialBudgetC47.Text == "₹ 0 L") ? "" : lbFinancialBudgetC47.Text;
                }
                lbFinancialBudgetC47.Text = (lbFinancialBudgetC47.Text == "0 L" || lbFinancialBudgetC47.Text == "0") ? "" : lbFinancialBudgetC47.Text;

                if (Convert.ToDecimal(lblFinancialTodayC47.Text) > 0)
                {
                    //lblFinancialTodayC47.Text = "₹ " + Math.Round(Convert.ToDecimal(lblFinancialTodayC47.Text) / 100000).ToString() + " L";
                    lblFinancialTodayC47.Text = "₹ " + Math.Round(Convert.ToDecimal(lblFinancialTodayC47.Text), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                    lblFinancialTodayC47.Text = (lblFinancialTodayC47.Text == "₹ 0 L") ? "" : lblFinancialTodayC47.Text;
                }
                lblFinancialTodayC47.Text = (lblFinancialTodayC47.Text == "0 L" || lblFinancialTodayC47.Text == "0") ? "" : lblFinancialTodayC47.Text;

                if (Convert.ToDecimal(lbFinancialBudgetC45.Text) > 0)
                {
                    //lbFinancialBudgetC45.Text = "₹ " + Math.Round(Convert.ToDecimal(lbFinancialBudgetC45.Text) / 100000).ToString() + " L";
                    lbFinancialBudgetC45.Text = "₹ " + Math.Round(Convert.ToDecimal(lbFinancialBudgetC45.Text), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                    lbFinancialBudgetC45.Text = (lbFinancialBudgetC45.Text == "₹ 0 L") ? "" : lbFinancialBudgetC45.Text;
                }
                lbFinancialBudgetC45.Text = (lbFinancialBudgetC45.Text == "0 L" || lbFinancialBudgetC45.Text == "0") ? "" : lbFinancialBudgetC45.Text;

                if (Convert.ToDecimal(lblFinancialTodayC45.Text) > 0)
                {
                    //lblFinancialTodayC45.Text = "₹ " + Math.Round(Convert.ToDecimal(lblFinancialTodayC45.Text) / 100000).ToString() + " L";
                    lblFinancialTodayC45.Text = "₹ " + Math.Round(Convert.ToDecimal(lblFinancialTodayC45.Text), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                    lblFinancialTodayC45.Text = (lblFinancialTodayC45.Text == "₹ 0 L") ? "" : lblFinancialTodayC45.Text;
                }
                lblFinancialTodayC45.Text = (lblFinancialTodayC45.Text == "0 L" || lblFinancialTodayC45.Text == "0") ? "" : lblFinancialTodayC45.Text;

                if (Convert.ToDecimal(lbFinancialBudgetD169.Text) > 0)
                {
                    //lbFinancialBudgetD169.Text = "₹ " + Math.Round(Convert.ToDecimal(lbFinancialBudgetD169.Text) / 100000).ToString() + " L";
                    lbFinancialBudgetD169.Text = "₹ " + Math.Round(Convert.ToDecimal(lbFinancialBudgetD169.Text), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                    lbFinancialBudgetD169.Text = (lbFinancialBudgetD169.Text == "₹ 0 L") ? "" : lbFinancialBudgetD169.Text;
                }
                lbFinancialBudgetD169.Text = (lbFinancialBudgetD169.Text == "0 L" || lbFinancialBudgetD169.Text == "0") ? "" : lbFinancialBudgetD169.Text;

                if (Convert.ToDecimal(lblFinancialTodayD169.Text) > 0)
                {
                    //lblFinancialTodayD169.Text = "₹ " + Math.Round(Convert.ToDecimal(lblFinancialTodayD169.Text) / 100000).ToString() + " L";
                    lblFinancialTodayD169.Text = "₹ " + Math.Round(Convert.ToDecimal(lblFinancialTodayD169.Text), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                    lblFinancialTodayD169.Text = (lblFinancialTodayD169.Text == "₹ 0 L") ? "" : lblFinancialTodayD169.Text;
                }
                lblFinancialTodayD169.Text = (lblFinancialTodayD169.Text == "0 L" || lblFinancialTodayD169.Text == "0") ? "" : lblFinancialTodayD169.Text;

                //added by raghvinder on 02-11-2020 start
                if (Convert.ToDecimal(lbFinancialBudgetC52.Text) > 0)
                {                    
                    lbFinancialBudgetC52.Text = "₹ " + Math.Round(Convert.ToDecimal(lbFinancialBudgetC52.Text), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                    lbFinancialBudgetC52.Text = (lbFinancialBudgetC52.Text == "₹ 0 L") ? "" : lbFinancialBudgetC52.Text;
                }
                lbFinancialBudgetC52.Text = (lbFinancialBudgetC52.Text == "0 L" || lbFinancialBudgetC52.Text == "0") ? "" : lbFinancialBudgetC52.Text;

                if (Convert.ToDecimal(lblFinancialTodayC52.Text) > 0)
                {
                    lblFinancialTodayC52.Text = "₹ " + Math.Round(Convert.ToDecimal(lblFinancialTodayC52.Text), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                    lblFinancialTodayC52.Text = (lblFinancialTodayC52.Text == "₹ 0 L") ? "" : lblFinancialTodayC52.Text;
                }
                lblFinancialTodayC52.Text = (lblFinancialTodayC52.Text == "0 L" || lblFinancialTodayC52.Text == "0") ? "" : lblFinancialTodayC52.Text;

                //added by raghvinder on 02-11-2020 end


                if (Convert.ToDecimal(lbFinancialBudgetBIPL.Text) > 0)
                {
                    //lbFinancialBudgetBIPL.Text = "₹ " + Math.Round(Convert.ToDecimal(lbFinancialBudgetBIPL.Text) / 100000).ToString() + " L";
                    lbFinancialBudgetBIPL.Text = "₹ " + Math.Round(Convert.ToDecimal(lbFinancialBudgetBIPL.Text), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                    lbFinancialBudgetBIPL.Text = (lbFinancialBudgetBIPL.Text == "₹ 0 L") ? "" : lbFinancialBudgetBIPL.Text;
                }
                lbFinancialBudgetBIPL.Text = (lbFinancialBudgetBIPL.Text == "0 L" || lbFinancialBudgetBIPL.Text == "0") ? "" : lbFinancialBudgetBIPL.Text;

                if (Convert.ToDecimal(lblFinancialTodayBIPL.Text) > 0)
                {
                    //lblFinancialTodayBIPL.Text = "₹ " + Math.Round(Convert.ToDecimal(lblFinancialTodayBIPL.Text) / 100000).ToString() + " L";
                    lblFinancialTodayBIPL.Text = "₹ " + Math.Round(Convert.ToDecimal(lblFinancialTodayBIPL.Text), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                    lblFinancialTodayBIPL.Text = (lblFinancialTodayBIPL.Text == "₹ 0 L") ? "" : lblFinancialTodayBIPL.Text;
                }
                lblFinancialTodayBIPL.Text = (lblFinancialTodayBIPL.Text == "0 L" || lblFinancialTodayBIPL.Text == "0") ? "" : lblFinancialTodayBIPL.Text;



                lblManPowerBudgetC47.Text = (lblManPowerBudgetC47.Text == "0") ? "" : Convert.ToDecimal(lblManPowerBudgetC47.Text).ToString("N0");

                lblManPowerTodayC47.Text = (lblManPowerTodayC47.Text == "0") ? "" : Convert.ToDecimal(lblManPowerTodayC47.Text).ToString("N0");

                lbFinancialBudgetC47.Text = (lbFinancialBudgetC47.Text == "0") ? "" : lbFinancialBudgetC47.Text;

                lblFinancialTodayC47.Text = (lblFinancialTodayC47.Text == "0") ? "" : lblFinancialTodayC47.Text;

                lblManPowerBudgetC45.Text = (lblManPowerBudgetC45.Text == "0") ? "" : Convert.ToDecimal(lblManPowerBudgetC45.Text).ToString("N0");

                lblManPowerTodayC45.Text = (lblManPowerTodayC45.Text == "0") ? "" : Convert.ToDecimal(lblManPowerTodayC45.Text).ToString("N0");

                lbFinancialBudgetC45.Text = (lbFinancialBudgetC45.Text == "0") ? "" : lbFinancialBudgetC45.Text;

                lblFinancialTodayC45.Text = (lblFinancialTodayC45.Text == "0") ? "" : lblFinancialTodayC45.Text;

                lblManPowerBudgetD169.Text = (lblManPowerBudgetD169.Text == "0") ? "" : Convert.ToDecimal(lblManPowerBudgetD169.Text).ToString("N0");

                lblManPowerTodayD169.Text = (lblManPowerTodayD169.Text == "0") ? "" : Convert.ToDecimal(lblManPowerTodayD169.Text).ToString("N0");

                lbFinancialBudgetD169.Text = (lbFinancialBudgetD169.Text == "0") ? "" : lbFinancialBudgetD169.Text;

                lblFinancialTodayD169.Text = (lblFinancialTodayD169.Text == "0") ? "" : lblFinancialTodayD169.Text;


                //added by raghvinder on 02-11-2020 start
                lblManPowerBudgetC52.Text = (lblManPowerBudgetC52.Text == "0") ? "" : Convert.ToDecimal(lblManPowerBudgetC52.Text).ToString("N0");

                lblManPowerTodayC52.Text = (lblManPowerTodayC52.Text == "0") ? "" : Convert.ToDecimal(lblManPowerTodayC52.Text).ToString("N0");

                lbFinancialBudgetC52.Text = (lbFinancialBudgetC52.Text == "0") ? "" : lbFinancialBudgetC52.Text;

                lblFinancialTodayC52.Text = (lblFinancialTodayC52.Text == "0") ? "" : lblFinancialTodayC52.Text;
                //added by raghvinder on 02-11-2020 end


                lblManPowerBudgetBIPL.Text = (lblManPowerBudgetBIPL.Text == "0") ? "" : Convert.ToDecimal(lblManPowerBudgetBIPL.Text).ToString("N0");

                lblManPowerTodayBIPL.Text = (lblManPowerTodayBIPL.Text == "0") ? "" : Convert.ToDecimal(lblManPowerTodayBIPL.Text).ToString("N0");

                lbFinancialBudgetBIPL.Text = (lbFinancialBudgetBIPL.Text == "0") ? "" : lbFinancialBudgetBIPL.Text;

                lblFinancialTodayBIPL.Text = (lblFinancialTodayBIPL.Text == "0") ? "" : lblFinancialTodayBIPL.Text;
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                
                decimal Total_Expense = Pcs_Outhouse * Avg_Outhouse_cost_per_pc/100000;

                Label lblManPowerBudgetC47Total = (Label)e.Row.FindControl("lblManPowerBudgetC47Total");
                //lblManPowerBudgetC47Total.Text = "₹ " + Math.Round(Convert.ToDecimal((BudgetC47_total / 100000))).ToString() + " L";
                lblManPowerBudgetC47Total.Text = Math.Round(Convert.ToDecimal(BudgetC47_total), MidpointRounding.AwayFromZero).ToString("N0");
                lblManPowerBudgetC47Total.Text = (lblManPowerBudgetC47Total.Text == "0") ? "" : lblManPowerBudgetC47Total.Text;

                Label lblManPowerTodayC47Total = (Label)e.Row.FindControl("lblManPowerTodayC47Total");
                //lblManPowerTodayC47Total.Text = "₹ " + Math.Round(Convert.ToDecimal((TodayC47_total / 100000))).ToString() + " L";
                lblManPowerTodayC47Total.Text = Math.Round(Convert.ToDecimal(TodayC47_total), MidpointRounding.AwayFromZero).ToString("N0");
                lblManPowerTodayC47Total.Text = (lblManPowerTodayC47Total.Text == "0") ? "" : lblManPowerTodayC47Total.Text;

                Label lblFinancialBudgetC47Total = (Label)e.Row.FindControl("lblFinancialBudgetC47Total");
                //lblFinancialBudgetC47Total.Text = "₹ " + Math.Round(Convert.ToDecimal((C47BudgetFinancialTotal / 100000))).ToString() + " L";
                lblFinancialBudgetC47Total.Text = "₹ " + Math.Round(Convert.ToDecimal(C47BudgetFinancialTotal), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                lblFinancialBudgetC47Total.Text = (lblFinancialBudgetC47Total.Text == "₹ 0 L" || lblFinancialBudgetC47Total.Text == "0") ? "" : lblFinancialBudgetC47Total.Text;

                Label lblFinancialTodayC47Total = (Label)e.Row.FindControl("lblFinancialTodayC47Total");
                //lblFinancialTodayC47Total.Text = "₹ " + Math.Round(Convert.ToDecimal((C47TodayFinancialTotal / 100000))).ToString() + " L";
                lblFinancialTodayC47Total.Text = "₹ " + Math.Round(Convert.ToDecimal(C47TodayFinancialTotal), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                lblFinancialTodayC47Total.Text = (lblFinancialTodayC47Total.Text == "₹ 0 L" || lblFinancialTodayC47Total.Text == "0") ? "" : lblFinancialTodayC47Total.Text;

                Label lblManPowerBudgetC45Total = (Label)e.Row.FindControl("lblManPowerBudgetC45Total");
                //lblManPowerBudgetC45Total.Text = "₹ " + Math.Round(Convert.ToDecimal((BudgetC4546_total / 100000))).ToString() + " L";
                lblManPowerBudgetC45Total.Text = Math.Round(Convert.ToDecimal(BudgetC4546_total), MidpointRounding.AwayFromZero).ToString("N0");
                lblManPowerBudgetC45Total.Text = (lblManPowerBudgetC45Total.Text == "0") ? "" : lblManPowerBudgetC45Total.Text;

                Label lblManPowerTodayC45Total = (Label)e.Row.FindControl("lblManPowerTodayC45Total");
                //lblManPowerTodayC45Total.Text = "₹ " + Math.Round(Convert.ToDecimal((TodayC4546_total / 100000))).ToString() + " L";
                lblManPowerTodayC45Total.Text = Math.Round(Convert.ToDecimal(TodayC4546_total), MidpointRounding.AwayFromZero).ToString("N0");
                lblManPowerTodayC45Total.Text = (lblManPowerTodayC45Total.Text == "0") ? "" : lblManPowerTodayC45Total.Text;

                Label lbFinancialBudgetC45Total = (Label)e.Row.FindControl("lbFinancialBudgetC45Total");
                //lbFinancialBudgetC45Total.Text = "₹ " + Math.Round(Convert.ToDecimal((C4546BudgetFinancialTotal / 100000))).ToString() + " L";
                lbFinancialBudgetC45Total.Text = "₹ " + Math.Round(Convert.ToDecimal(C4546BudgetFinancialTotal), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                lbFinancialBudgetC45Total.Text = (lbFinancialBudgetC45Total.Text == "₹ 0 L" || lbFinancialBudgetC45Total.Text == "0") ? "" : lbFinancialBudgetC45Total.Text;

                Label lblFinancialTodayC45Total = (Label)e.Row.FindControl("lblFinancialTodayC45Total");
                //lblFinancialTodayC45Total.Text = "₹ " + Math.Round(Convert.ToDecimal((C4546TodayFinancialTotal / 100000))).ToString() + " L";
                lblFinancialTodayC45Total.Text = "₹ " + Math.Round(Convert.ToDecimal(C4546TodayFinancialTotal), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                lblFinancialTodayC45Total.Text = (lblFinancialTodayC45Total.Text == "₹ 0 L" || lblFinancialTodayC45Total.Text == "0") ? "" : lblFinancialTodayC45Total.Text;

                Label lblManPowerBudgetD169Total = (Label)e.Row.FindControl("lblManPowerBudgetD169Total");
                //lblManPowerBudgetD169Total.Text = "₹ " + Math.Round(Convert.ToDecimal((BudgetD169_total / 100000))).ToString() + " L";
                lblManPowerBudgetD169Total.Text = Math.Round(Convert.ToDecimal(BudgetD169_total), MidpointRounding.AwayFromZero).ToString("N0");
                lblManPowerBudgetD169Total.Text = (lblManPowerBudgetD169Total.Text == "0") ? "" : lblManPowerBudgetD169Total.Text;

                Label lblManPowerTodayD169Total = (Label)e.Row.FindControl("lblManPowerTodayD169Total");
                //lblManPowerTodayD169Total.Text = "₹ " + Math.Round(Convert.ToDecimal((TodayD169_total / 100000))).ToString() + " L";
                lblManPowerTodayD169Total.Text = Math.Round(Convert.ToDecimal(TodayD169_total), MidpointRounding.AwayFromZero).ToString("N0");
                lblManPowerTodayD169Total.Text = (lblManPowerTodayD169Total.Text == "0") ? "" : lblManPowerTodayD169Total.Text;

                Label lbFinancialBudgetD169Total = (Label)e.Row.FindControl("lbFinancialBudgetD169Total");
                //lbFinancialBudgetD169Total.Text = "₹ " + Math.Round(Convert.ToDecimal((D169BudgetFinancialTotal / 100000))).ToString() + " L";
                lbFinancialBudgetD169Total.Text = "₹ " + Math.Round(Convert.ToDecimal(D169BudgetFinancialTotal), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                lbFinancialBudgetD169Total.Text = (lbFinancialBudgetD169Total.Text == "₹ 0 L" || lbFinancialBudgetD169Total.Text == "0") ? "" : lbFinancialBudgetD169Total.Text;

                Label lblFinancialTodayD169Total = (Label)e.Row.FindControl("lblFinancialTodayD169Total");
                //lblFinancialTodayD169Total.Text = "₹ " + Math.Round(Convert.ToDecimal((D169TodayFinancialTotal / 100000))).ToString() + " L";
                lblFinancialTodayD169Total.Text = "₹ " + Math.Round(Convert.ToDecimal(D169TodayFinancialTotal), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                lblFinancialTodayD169Total.Text = (lblFinancialTodayD169Total.Text == "₹ 0 L" || lblFinancialTodayD169Total.Text == "0") ? "" : lblFinancialTodayD169Total.Text;

                //added by raghvinder on 02-11-2020 start
                Label lblManPowerBudgetC52Total = (Label)e.Row.FindControl("lblManPowerBudgetC52Total");                
                lblManPowerBudgetC52Total.Text = Math.Round(Convert.ToDecimal(BudgetC52_total), MidpointRounding.AwayFromZero).ToString("N0");
                lblManPowerBudgetC52Total.Text = (lblManPowerBudgetC52Total.Text == "0") ? "" : lblManPowerBudgetC52Total.Text;

                Label lblManPowerTodayC52Total = (Label)e.Row.FindControl("lblManPowerTodayC52Total");                
                lblManPowerTodayC52Total.Text = Math.Round(Convert.ToDecimal(TodayC52_total), MidpointRounding.AwayFromZero).ToString("N0");
                lblManPowerTodayC52Total.Text = (lblManPowerTodayC52Total.Text == "0") ? "" : lblManPowerTodayC52Total.Text;

                Label lbFinancialBudgetC52Total = (Label)e.Row.FindControl("lbFinancialBudgetC52Total");                
                lbFinancialBudgetC52Total.Text = "₹ " + Math.Round(Convert.ToDecimal(C52BudgetFinancialTotal), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                lbFinancialBudgetC52Total.Text = (lbFinancialBudgetC52Total.Text == "₹ 0 L" || lbFinancialBudgetC52Total.Text == "0") ? "" : lbFinancialBudgetC52Total.Text;

                Label lblFinancialTodayC52Total = (Label)e.Row.FindControl("lblFinancialTodayC52Total");                
                lblFinancialTodayC52Total.Text = "₹ " + Math.Round(Convert.ToDecimal(C52TodayFinancialTotal), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                lblFinancialTodayC52Total.Text = (lblFinancialTodayC52Total.Text == "₹ 0 L" || lblFinancialTodayC52Total.Text == "0") ? "" : lblFinancialTodayC52Total.Text;
                //added by raghvinder on 02-11-2020 end

                Label lblManPowerBudgetBIPLTotal = (Label)e.Row.FindControl("lblManPowerBudgetBIPLTotal");
                //lblManPowerBudgetBIPLTotal.Text = "₹ " + Math.Round(Convert.ToDecimal((BudgetBIPL_total / 100000))).ToString() + " L";
                lblManPowerBudgetBIPLTotal.Text = Math.Round(Convert.ToDecimal(BudgetBIPL_total), MidpointRounding.AwayFromZero).ToString("N0");
                lblManPowerBudgetBIPLTotal.Text = (lblManPowerBudgetBIPLTotal.Text == "0") ? "" : lblManPowerBudgetBIPLTotal.Text;

                Label lblManPowerTodayBIPLTotal = (Label)e.Row.FindControl("lblManPowerTodayBIPLTotal");
                //lblManPowerTodayBIPLTotal.Text = "₹ " + Math.Round(Convert.ToDecimal((TodayBIPL_total / 100000))).ToString() + " L";
                lblManPowerTodayBIPLTotal.Text = Math.Round(Convert.ToDecimal(TodayBIPL_total), MidpointRounding.AwayFromZero).ToString("N0");
                lblManPowerTodayBIPLTotal.Text = (lblManPowerTodayBIPLTotal.Text == "0") ? "" : lblManPowerTodayBIPLTotal.Text;

                Label lbFinancialBudgetBIPLTotal = (Label)e.Row.FindControl("lbFinancialBudgetBIPLTotal");
                //lbFinancialBudgetBIPLTotal.Text = "₹ " + Math.Round(Convert.ToDecimal((BIPLBudgetFinancialTotal / 100000))).ToString() + " L";
                lbFinancialBudgetBIPLTotal.Text = "₹ " + Math.Round(Convert.ToDecimal(BIPLBudgetFinancialTotal), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                lbFinancialBudgetBIPLTotal.Text = (lbFinancialBudgetBIPLTotal.Text == "₹ 0 L" || lbFinancialBudgetBIPLTotal.Text == "0") ? "" : "₹ " + (Math.Round(Convert.ToDecimal((BIPLBudgetFinancialTotal)) + Total_Expense)).ToString("N0") + " L";

                Label lblFinancialTodayBIPLTotal = (Label)e.Row.FindControl("lblFinancialTodayBIPLTotal");
                //lblFinancialTodayBIPLTotal.Text = "₹ " + Math.Round(Convert.ToDecimal((BIPLTodayFinancialTotal / 100000))).ToString() + " L";
                lblFinancialTodayBIPLTotal.Text = "₹ " + Math.Round(Convert.ToDecimal(BIPLTodayFinancialTotal), MidpointRounding.AwayFromZero).ToString("N0") + " L";
                lblFinancialTodayBIPLTotal.Text = (lblFinancialTodayBIPLTotal.Text == "₹ 0 L" || lblFinancialTodayBIPLTotal.Text == "0") ? "" : "₹ " + (Math.Round(Convert.ToDecimal((BIPLTodayFinancialTotal)) + Total_Expense)).ToString("N0") + " L";
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
                HeaderCell.Text = "C-52";
                HeaderCell.ColumnSpan = 4;
                HeaderCell.Style.Add("text-align", "center");
                HeaderCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#39589c");
                HeaderCell.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
                HeaderGridRow.Cells.Add(HeaderCell);

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
            //string CreatedDate = txtCreatedDate.Value;
            //bindgrd(CreatedDate);
            bindgrd(DateTime.ParseExact(txtCreatedDate.Value, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture).ToString());
        }       
        
    }
}