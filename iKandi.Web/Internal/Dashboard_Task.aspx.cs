using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.Internal
{
    public partial class Dashboard_Task : BasePage
    {
        public int Count
        {
            get;
            set;
        }



        public int ShowCosting
        {
            get
            {
                ////return PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.DASHBOARD_COSTING_AND_ENQUIRIES)
                //           ? 1
                //  
                return 0;
            }
        }

        public int ShowBooking
        {
            get
            {
                //return (ApplicationHelper.LoggedInUser.ClientData != null) ||
                //       PermissionHelper.IsReadPermittedOnColumn(
                //           (int)AppModuleColumn.DASHBOARD_BOOKING_CALCULATOR)
                //           ? 1
                //           : 0;
              return  0;
            }
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //ListUserTask usertasks = null;
            //comment By Ravi

         //   ListUserTask usertasks = this.UserTaskControllerInstance.GetUserTasksCount();

            // end comment

            //if (usertasks != null)
            //{
            //    //rptMyTask.DataSource = usertasks;
            //    //rptMyTask.DataBind();
            //    //long mytaskcount = (from r in usertasks select r.Task_Count).ToList().Sum();
            //    //ltMyTask.Text = mytaskcount.ToString();

            //    //ListTeamTask listTeamTask = this.UserTaskControllerInstance.GetTeamTasksCount();
            //    //rptTeamTask.DataSource = listTeamTask;
            //    //rptTeamTask.DataBind();
            //    //long teamtaskcount = (from r in listTeamTask select r.Task_Count).ToList().Sum();
            //    //ltTeamTask.Text = teamtaskcount.ToString();

            //    //ltTotalTaskCount.Text = (mytaskcount + teamtaskcount).ToString();
            //    //ltTotalTaskCount.Text = (mytaskcount).ToString();
            //}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (ApplicationHelper.LoggedInUser == null)
            //    Response.Redirect("~/internal/Logout.aspx");

            //if (Request.Cookies["IsPasswordExpire"] != null)
            //{
            //    if (Request.Cookies["IsPasswordExpire"].Value != null)
            //        ScriptManager.RegisterStartupScript(Page, typeof(Page), "loginexpire",
            //                                                          "ShowHideValidationBox(true, 'your password will expire in next 5 days.', 'Login Page');",
            //                                                          true);
            //    Response.Cookies["IsPasswordExpire"].Value = null;
            //    Response.Cookies["IsPasswordExpire"].Expires = DateTime.Now.AddDays(-2);
            //}
            //HitRateForDesignersReport1.Visible = PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.DASHBOARD_HIT_RATES_FOR_DESIGNERS_REPORT);
            //BookingCalculator1.Visible = (ApplicationHelper.LoggedInUser.ClientData != null) ||
            //                             PermissionHelper.IsReadPermittedOnColumn(
            //                                 (int)AppModuleColumn.DASHBOARD_BOOKING_CALCULATOR);
            //CostingAndEnquiries1.Visible =
            //    PermissionHelper.IsReadPermittedOnColumn((int)AppModuleColumn.DASHBOARD_COSTING_AND_ENQUIRIES);
            if (!IsPostBack)
            {
                
                //if(ShowTask==0)
                //    return;'

               // ListUserTask usertasks = null;
                
              //  ListUserTask usertasks = this.UserTaskControllerInstance.GetUserTasksCount();
                // End comment

                //if (usertasks != null)
                //{
                //    rptMyTask.DataSource = usertasks;
                //    rptMyTask.DataBind();
                //    long mytaskcount = (from r in usertasks select r.Task_Count).ToList().Sum();
                //    ltMyTask.Text = mytaskcount.ToString();
                   
                //    //ltTotalTaskCount.Text = (mytaskcount + teamtaskcount).ToString();
                //    ltTotalTaskCount.Text = (mytaskcount).ToString();
                //}
             
            }
        }

        protected void rptTeamTask_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            TeamTaskCount ttc = e.Item.DataItem as TeamTaskCount;
            Repeater rpt = e.Item.FindControl("rptTeamSubTask") as Repeater;
            rpt.DataSource = ttc.ListUtc;
            rpt.DataBind();
        }

        protected void ctrlCalendar_SelectionChanged(object sender, EventArgs e)
        {
            //lblCurrentDate.Text = ctrlCalendar.SelectedDate.ToLongDateString();
        }
    }
}

