using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using System.Data;
using iKandi.Common.Entities;
using System.Text;

using System.Net.Mail;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
using System.Globalization;
using iKandi.Web.Components;

namespace iKandi.Web
{
    public partial class BiplMeeting : System.Web.UI.Page
    {
        FabricController objfab = new FabricController();
        NotificationController objnotif = new NotificationController();
        static List<string> myCollection = new List<string>();
        static int MeetingScheduleId = 0;
        string MailType = "";
        string Flag = string.Empty;
        public string Isscheduler;
        public static List<User> Users
        {
            get
            {
                if (HttpRuntime.Cache["APPLICATIONUSERS"] == null)
                {
                    UserController controller = new UserController();
                    HttpRuntime.Cache.Insert("APPLICATIONUSERS", controller.GetAllUsers(), null, DateTime.Now.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);
                }

                return (HttpRuntime.Cache["APPLICATIONUSERS"] as List<User>);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if (Request.QueryString["Isscheduler"] != null)
                {
                    Isscheduler = Request.QueryString["Isscheduler"].ToString();
                }
                Bindddl();
                myCollection.Clear();
                lbluserlist.Text = "";
                BindTime(ddlDailyTime);
                BindTime(ddlWeeklyTime);
                BindTime(ddlMonthlyTime);
                BindTime(ddlQuarterDaysTime);
                BindTime(ddlDailyTime);
                BindTime(ddlManualtime);
                BindTime(ddlYearTime);
                BindTime(ddlOneTime_Time);
                bindgrd();
                //BindddlYear(ddlyearonetimeonly);
                hdnuserlist.Value = "";
                //Execute based on query string 
                //Mailscheduler();
                //MailsschedulerSave()
                //ENd

                tbladd.Visible = true;

                ddlYearMonth.Visible = false;
                ddlYearDays.Visible = false;
                ddlYearTime.Visible = false;
                ddlWeekly.Visible = false;
                ddlWeeklyTime.Visible = false;
                ddlMonthly.Visible = false;
                ddlMonthlyTime.Visible = false;
                ddlDailyTime.Visible = false;
                ddlQuarter.Visible = false;
                ddlQuarterDay.Visible = false;
                ddlQuarterDaysTime.Visible = false;
                ddlManualdays.Visible = false;
                ddlManualtime.Visible = false;


                ddlWeeklyManual.Visible = false;
                ddlYearMonthManual.Visible = false;
                ddlManualQuarter.Visible = false;
                MeetingScheduleId = 0;
                ExecuteScheduler();
            }
        }
        public void ExecuteScheduler()
        {
            if (Isscheduler == "YES")
            {
                MailsschedulerSave();
            }
        }
        public void Bindddl()
        {

            DataTable dt = objfab.GetEventOccurence();
            ddlaccurrence.DataSource = dt;
            ddlaccurrence.DataTextField = "CategoryName";
            ddlaccurrence.DataValueField = "MeetingCategory_Id";
            ddlaccurrence.DataBind();
            ddlaccurrence.Items.Insert(0, new ListItem("Select Occurrence", "-1"));

        }
        public void BindddlYear(DropDownList ddlyear)
        {
            ddlyear.Items.Clear();
            // Add default item to the list
            ddlyear.Items.Add("--Year--");
            // Start loop
            for (int i = 0; i < 2; i++)
            {
                // For each pass add an item
                // Add a number of years (negative, which will subtract) to current year
                ddlyear.Items.Add(DateTime.Now.AddYears(-i).Year.ToString());
            }


        }
        public void bindgrd()
        {
            DataTable dt = objfab.GetEventOccurenceDetails(0);
            if (dt.Rows.Count > 0)
            {
                grdMeetingsbipl.DataSource = dt;
                grdMeetingsbipl.DataBind();
            }
        }
        public void BindEditTable()
        {
            tbladd.Visible = true;
            DataTable dt = objfab.GetEventOccurenceDetails(MeetingScheduleId);
            if (dt.Rows.Count > 0)
            {
                ddlaccurrence.SelectedValue = dt.Rows[0]["MeetingCategory_Id"].ToString();
                if (dt.Rows[0]["IsManual"].ToString() == "True")
                {
                    ChkIsmanual.Checked = true;
                }
                else
                {
                    ChkIsmanual.Checked = false;
                }
                Accurencesschange();
                manualchange();
                txtmeetingname.Text = dt.Rows[0]["MeetingName"].ToString();
                if (dt.Rows[0]["MeetingCategory_Id"].ToString() == "1")
                {

                    ddlDailyTime.SelectedValue = dt.Rows[0]["Time"].ToString().ToUpper();
                    if (dt.Rows[0]["IsManual"].ToString() == "True")
                    {
                        ddlManualtime.SelectedValue = dt.Rows[0]["Manual_Time"].ToString().ToUpper();
                    }
                }
                if (dt.Rows[0]["MeetingCategory_Id"].ToString() == "2")
                {
                    ddlMonthly.SelectedValue = dt.Rows[0]["day"].ToString();
                    ddlMonthlyTime.SelectedValue = dt.Rows[0]["Time"].ToString().ToUpper();

                    if (dt.Rows[0]["IsManual"].ToString() == "True")
                    {
                        ddlManualdays.SelectedValue = dt.Rows[0]["Manual_Day"].ToString();
                        ddlManualtime.SelectedValue = dt.Rows[0]["Manual_Time"].ToString().ToUpper();
                    }
                }
                if (dt.Rows[0]["MeetingCategory_Id"].ToString() == "3")
                {

                    ddlQuarter.SelectedValue = dt.Rows[0]["Month"].ToString();
                    ddlQuarterDay.SelectedValue = dt.Rows[0]["Day"].ToString();
                    ddlQuarterDaysTime.SelectedValue = dt.Rows[0]["Time"].ToString().ToUpper();

                    if (dt.Rows[0]["IsManual"].ToString() == "True")
                    {
                        ddlManualQuarter.SelectedValue = dt.Rows[0]["Manual_Month"].ToString();
                        ddlManualdays.SelectedValue = dt.Rows[0]["Manual_Day"].ToString();
                        ddlManualtime.SelectedValue = dt.Rows[0]["Manual_Time"].ToString().ToUpper();
                    }

                }
                if (dt.Rows[0]["MeetingCategory_Id"].ToString() == "4")
                {
                    ddlWeekly.SelectedValue = dt.Rows[0]["Day"].ToString();
                    ddlWeeklyTime.SelectedValue = dt.Rows[0]["Time"].ToString();

                    if (dt.Rows[0]["IsManual"].ToString() == "True")
                    {
                        ddlWeeklyManual.SelectedValue = dt.Rows[0]["Manual_Day"].ToString();
                        ddlManualtime.SelectedValue = dt.Rows[0]["Manual_Time"].ToString().ToUpper();
                    }
                }
                if (dt.Rows[0]["MeetingCategory_Id"].ToString() == "5")
                {

                    ddlYearMonth.SelectedValue = dt.Rows[0]["Month"].ToString();
                    ddlYearDays.SelectedValue = dt.Rows[0]["Day"].ToString();
                    ddlYearTime.SelectedValue = dt.Rows[0]["Time"].ToString().ToUpper();

                    if (dt.Rows[0]["IsManual"].ToString() == "True")
                    {
                        ddlYearMonthManual.SelectedValue = dt.Rows[0]["Manual_Month"].ToString();
                        ddlManualdays.SelectedValue = dt.Rows[0]["Manual_Day"].ToString();
                        ddlManualtime.SelectedValue = dt.Rows[0]["Manual_Time"].ToString().ToUpper();
                    }
                }
                if (dt.Rows[0]["MeetingCategory_Id"].ToString() == "6")
                {

                    ddlOneTime_Month.SelectedValue = dt.Rows[0]["Month"].ToString();
                    ddlOneTime_Day.SelectedValue = dt.Rows[0]["Day"].ToString();
                    ddlOneTime_Time.SelectedValue = dt.Rows[0]["Time"].ToString().ToUpper();
                    ddlyearonetimeonly.SelectedValue = dt.Rows[0]["Years"].ToString().ToUpper();

                    ChkIsmanual.Checked = false;
                    ChkIsmanual.Enabled = false;
                }
                hdnuserlist.Value = dt.Rows[0]["Participate"].ToString();
                txtDescription.Text = dt.Rows[0]["Description"].ToString();
            }
        }
        public void btnadd_Click(object sender, EventArgs e)
        {
            string error = "";
            Validate(out error);
            if (error != "")
            {
                ShowAlert(error);
                return;
            }
            else
            {
                SaveMeetingInfo();
            }
        }
        public void btncancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
        public void SaveMeetingInfo()
        {
            int MeetingCategory_Id;
            string MeetingName; int TimeZone = 0; int Month = 0; int Day = 0; string Time = ""; int IsManual = 0; int Manual_TimeZone = 0; int Manual_Month = 0; int Manual_Day = 0; int Years = 0;
            string Manual_Time = ""; string Participate = ""; string Description = "";
            MeetingName = txtmeetingname.Text;
            MeetingCategory_Id = Convert.ToInt32(ddlaccurrence.SelectedValue);
            if (ChkIsmanual.Checked == true)
            {
                IsManual = 1;
            }
            if (ddlaccurrence.SelectedValue == "1")
            {
                Time = ddlDailyTime.SelectedValue;

                if (ChkIsmanual.Checked == true)
                    Manual_Time = ddlManualtime.SelectedValue;
            }
            if (ddlaccurrence.SelectedValue == "2")
            {
                Day = Convert.ToInt32(ddlMonthly.SelectedValue);
                Time = ddlMonthlyTime.SelectedValue;

                if (ChkIsmanual.Checked == true)
                {
                    Manual_Day = Convert.ToInt32(ddlManualdays.SelectedValue);
                    Manual_Time = ddlManualtime.SelectedValue;
                }

            }
            if (ddlaccurrence.SelectedValue == "3")
            {
                Month = Convert.ToInt32(ddlQuarter.SelectedValue);
                Day = Convert.ToInt32(ddlQuarterDay.SelectedValue);
                Time = ddlQuarterDaysTime.SelectedValue;

                if (ChkIsmanual.Checked == true)
                {
                    Manual_Month = Convert.ToInt32(ddlManualQuarter.SelectedValue);
                    Manual_Day = Convert.ToInt32(ddlManualdays.SelectedValue);
                    Manual_Time = ddlManualtime.SelectedValue;
                }

            }
            if (ddlaccurrence.SelectedValue == "4")
            {

                Day = Convert.ToInt32(ddlWeekly.SelectedValue);
                Time = ddlWeeklyTime.SelectedValue;

                if (ChkIsmanual.Checked == true)
                {
                    Manual_Day = Convert.ToInt32(ddlWeeklyManual.SelectedValue);
                    Manual_Time = ddlManualtime.SelectedValue;
                }

            }
            if (ddlaccurrence.SelectedValue == "5")
            {

                Month = Convert.ToInt32(ddlYearMonth.SelectedValue);
                Day = Convert.ToInt32(ddlYearDays.SelectedValue);
                Time = ddlYearTime.SelectedValue;

                if (ChkIsmanual.Checked == true)
                {
                    Manual_Month = Convert.ToInt32(ddlYearMonthManual.SelectedValue);
                    Manual_Day = Convert.ToInt32(ddlManualdays.SelectedValue);
                    Manual_Time = ddlManualtime.SelectedValue;
                }

            }
            if (ddlaccurrence.SelectedValue == "6")
            {
                Month = Convert.ToInt32(ddlOneTime_Month.SelectedValue);
                Day = Convert.ToInt32(ddlOneTime_Day.SelectedValue);
                Time = ddlOneTime_Time.SelectedValue;
                Years = Convert.ToInt32(ddlyearonetimeonly.SelectedValue);

                DateTime t1 = DateTime.Parse("2012/12/12 " + Time);
                DateTime t2 = DateTime.Parse("2012/12/12 " + DateTime.Now.ToString("hh:mm tt"));

                DateTime NextDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                DateTime savingDate = new DateTime(Years, Month, Day);
                if (savingDate < NextDate)
                {
                    ShowAlert("Date Time cannot be less than from current Date time");
                    return;
                }
                else if (savingDate == NextDate)
                {
                    if (t1.TimeOfDay < t2.TimeOfDay)
                    {
                        ShowAlert("Date Time cannot be less than from current Date time");
                        return;
                    }
                }

            }

            
            Participate = hdnuserlist.Value;
            Description = txtDescription.Text;

            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            DataTable dt = objfab.SaveBiplMeetingInfo(MeetingScheduleId, MeetingCategory_Id, MeetingName, TimeZone, Month, Day, Time, IsManual, Manual_TimeZone, Manual_Month, Manual_Day, Manual_Time, Participate, Description, Years,UserId);
            bindgrd();
            MailsSave(dt);
            Response.Redirect(Request.RawUrl);
        }
        private void BindTime(DropDownList ddl)
        {
            // Set the start time (00:00 means 12:00 AM)
            DateTime StartTime = DateTime.ParseExact("10:00", "HH:mm", null);
            // Set the end time (23:55 means 11:55 PM)
            DateTime EndTime = DateTime.ParseExact("20:00", "HH:mm", null);
            //Set 5 minutes interval
            TimeSpan Interval = new TimeSpan(0, 15, 0);
            //To set 1 hour interval
            //TimeSpan Interval = new TimeSpan(1, 0, 0);           
            ddl.Items.Clear();
            while (StartTime <= EndTime)
            {
                ddl.Items.Add(StartTime.ToString("h:mm tt", CultureInfo.InvariantCulture));
                //  ddlTimeTo.Items.Add(StartTime.ToShortTimeString());
                StartTime = StartTime.Add(Interval);
            }
            ddl.Items.Insert(0, new ListItem("Select Time", "-1"));

        }
        public void btnadduser_Click(object sender, EventArgs e)
        {
            DuplicateMeetingNameCheck();
            bool checkname = false;
            DataTable dt = objfab.MeetingNameDuplicateCheck("USERNAME", -1, txtuser.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["DuplicateCheck"].ToString() == "EXISTS")
                {
                    checkname = true;
                }


            }
            if (checkname == false)
            {
                ShowAlert("Not valid user");
                txtuser.Text = "";
                return;
            }
            if (hdnuserlist.Value != "")
            {
                string[] struser = hdnuserlist.Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string x in struser)
                {
                    myCollection.Add(x);

                }
            }
            myCollection.Add(txtuser.Text.Trim());
            List<string> distinct = myCollection.Distinct().ToList();
            hdnuserlist.Value = "";
            foreach (string xx in distinct)
                hdnuserlist.Value = hdnuserlist.Value + xx + ",";

            distinct = myCollection.Distinct().ToList();
            int i = 1;
            string strhtml = "";
            foreach (string x in distinct)
            {
                strhtml = strhtml + i + ". " + x + @"<br /> ";
                i++;
            }
            lbluserlist.Text = strhtml;
            txtparticipante.Text = strhtml;
            txtuser.Text = "";

            grdparticipaint.DataSource = distinct;
            grdparticipaint.DataBind();
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        public void btn_Edit_Click(object sender, EventArgs e)
        {
            myCollection.Clear();
            divuser.Visible = true;
            modalPopup.Visible = true;
            if (hdnuserlist.Value != "")
            {
                string[] struser = hdnuserlist.Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string x in struser)
                {
                    myCollection.Add(x);

                }
            }

            List<string> distinct = myCollection.Distinct().ToList();
            foreach (string xx in distinct)
                hdnuserlist.Value = hdnuserlist.Value + xx + ",";


            int i = 1;
            string strhtml = "";
            foreach (string x in distinct)
            {
                strhtml = strhtml + i + ". " + x + @"<br /> ";
                i++;
            }
            lbluserlist.Text = strhtml;

            grdparticipaint.DataSource = myCollection;
            grdparticipaint.DataBind();
        }
        public void btnhide_Click(object sender, EventArgs e)
        {
            divuser.Visible = false;
            modalPopup.Visible = false;

        }
        public void manualchange()
        {
            if (ChkIsmanual.Checked)
            {
                ddlaccurrence.Enabled = false;
                ddlDailyTime.Enabled = false;

                ddlMonthly.Enabled = false;
                ddlMonthlyTime.Enabled = false;

                ddlQuarter.Enabled = false;
                ddlQuarterDay.Enabled = false;
                ddlQuarterDaysTime.Enabled = false;

                ddlWeekly.Enabled = false;
                ddlWeeklyTime.Enabled = false;

                ddlYearMonth.Enabled = false;
                ddlYearDays.Enabled = false;
                ddlYearTime.Enabled = false;

                if (ddlaccurrence.SelectedValue == "1")
                {
                    ddlManualtime.Visible = true;

                    ddlManualdays.Visible = false;
                    ddlManualQuarter.Visible = false;
                    ddlYearMonthManual.Visible = false;
                }

                if (ddlaccurrence.SelectedValue == "4")
                {
                    ddlWeeklyManual.Visible = true;
                    ddlManualtime.Visible = true;

                    ddlManualQuarter.Visible = false;
                    ddlManualdays.Visible = false;
                    ddlYearMonthManual.Visible = false;
                }
                if (ddlaccurrence.SelectedValue == "2")
                {
                    ddlManualdays.Visible = true;
                    ddlManualtime.Visible = true;

                    ddlManualQuarter.Visible = false;
                    ddlWeeklyManual.Visible = false;
                    ddlYearMonthManual.Visible = false;
                }
                if (ddlaccurrence.SelectedValue == "3")
                {
                    ddlManualQuarter.Visible = true;
                    ddlManualdays.Visible = true;
                    ddlManualtime.Visible = true;


                    ddlWeeklyManual.Visible = false;
                    ddlYearMonthManual.Visible = false;
                }
                if (ddlaccurrence.SelectedValue == "5")
                {
                    ddlYearMonthManual.Visible = true;
                    ddlManualdays.Visible = true;
                    ddlManualtime.Visible = true;


                    ddlManualQuarter.Visible = false;
                    ddlWeeklyManual.Visible = false;

                }


            }
            else
            {
                ddlaccurrence.Enabled = true;
                ddlDailyTime.Enabled = true;

                ddlMonthly.Enabled = true;
                ddlMonthlyTime.Enabled = true;

                ddlQuarter.Enabled = true;
                ddlQuarterDay.Enabled = true;
                ddlQuarterDaysTime.Enabled = true;

                ddlWeekly.Enabled = true;
                ddlWeeklyTime.Enabled = true;

                ddlManualdays.Visible = false;
                ddlManualtime.Visible = false;


                ddlWeeklyManual.Visible = false;
                ddlYearMonthManual.Visible = false;
                ddlManualQuarter.Visible = false;

                ddlYearMonth.Enabled = true;
                ddlYearDays.Enabled = true;
                ddlYearTime.Enabled = true;

                ddlOneTime_Month.Enabled = true;
                ddlOneTime_Day.Enabled = true;
                ddlOneTime_Time.Enabled = true;
                ddlyearonetimeonly.Enabled = true;
            }
        }
        protected void ChkIsmanual_CheckedChanged(object sender, EventArgs e)
        {
            manualchange();
        }
        public void Accurencesschange()
        {
            if (ddlaccurrence.SelectedValue == "-1")
            {
                ddlDailyTime.Visible = false;

                ddlMonthly.Visible = false;
                ddlMonthlyTime.Visible = false;

                ddlQuarter.Visible = false;
                ddlQuarterDay.Visible = false;
                ddlQuarterDaysTime.Visible = false;

                ddlWeekly.Visible = false;
                ddlWeeklyTime.Visible = false;

                ddlYearMonth.Visible = false;
                ddlYearDays.Visible = false;
                ddlYearTime.Visible = false;

                ddlOneTime_Month.Visible = false;
                ddlOneTime_Day.Visible = false;
                ddlOneTime_Time.Visible = false;
                ddlyearonetimeonly.Visible = false;

            }
            if (ddlaccurrence.SelectedValue == "1")
            {
                ddlDailyTime.Visible = true;

                ddlMonthly.Visible = false;
                ddlMonthlyTime.Visible = false;

                ddlQuarter.Visible = false;
                ddlQuarterDay.Visible = false;
                ddlQuarterDaysTime.Visible = false;

                ddlWeekly.Visible = false;
                ddlWeeklyTime.Visible = false;

                ddlYearMonth.Visible = false;
                ddlYearDays.Visible = false;
                ddlYearTime.Visible = false;

                ddlOneTime_Month.Visible = false;
                ddlOneTime_Day.Visible = false;
                ddlOneTime_Time.Visible = false;
                ChkIsmanual.Enabled = true;
                ddlyearonetimeonly.Enabled = false;


            }
            else if (ddlaccurrence.SelectedValue == "2")
            {
                ddlMonthly.Visible = true;
                ddlMonthlyTime.Visible = true;

                ddlDailyTime.Visible = false;

                ddlQuarter.Visible = false;
                ddlQuarterDay.Visible = false;
                ddlQuarterDaysTime.Visible = false;

                ddlWeekly.Visible = false;
                ddlWeeklyTime.Visible = false;

                ddlWeeklyManual.Visible = false;
                ddlYearMonth.Visible = false;
                ddlYearDays.Visible = false;
                ddlYearTime.Visible = false;

                ddlOneTime_Month.Visible = false;
                ddlOneTime_Day.Visible = false;
                ddlOneTime_Time.Visible = false;
                ddlyearonetimeonly.Visible = false;
                ChkIsmanual.Enabled = true;
            }
            else if (ddlaccurrence.SelectedValue == "3")
            {
                ddlQuarter.Visible = true;
                ddlQuarterDay.Visible = true;
                ddlQuarterDaysTime.Visible = true;

                ddlMonthly.Visible = false;
                ddlMonthlyTime.Visible = false;

                ddlDailyTime.Visible = false;

                ddlWeekly.Visible = false;
                ddlWeeklyTime.Visible = false;

                ddlYearMonth.Visible = false;
                ddlYearDays.Visible = false;
                ddlYearTime.Visible = false;

                ddlOneTime_Month.Visible = false;
                ddlOneTime_Day.Visible = false;
                ddlOneTime_Time.Visible = false;
                ChkIsmanual.Enabled = true;
                ddlyearonetimeonly.Visible = false;
            }
            else if (ddlaccurrence.SelectedValue == "4")
            {
                ddlWeekly.Visible = true;
                ddlWeeklyTime.Visible = true;

                ddlMonthly.Visible = false;
                ddlMonthlyTime.Visible = false;

                ddlDailyTime.Visible = false;

                ddlQuarter.Visible = false;
                ddlQuarterDay.Visible = false;
                ddlQuarterDaysTime.Visible = false;

                ddlYearMonth.Visible = false;
                ddlYearDays.Visible = false;
                ddlYearTime.Visible = false;

                ddlOneTime_Month.Visible = false;
                ddlOneTime_Day.Visible = false;
                ddlOneTime_Time.Visible = false;
                ddlyearonetimeonly.Visible = false;
                ChkIsmanual.Enabled = true;
            }
            else if (ddlaccurrence.SelectedValue == "5")
            {
                ddlYearMonth.Visible = true;
                ddlYearDays.Visible = true;
                ddlYearTime.Visible = true;

                ddlWeekly.Visible = false;
                ddlWeeklyTime.Visible = false;

                ddlMonthly.Visible = false;
                ddlMonthlyTime.Visible = false;

                ddlDailyTime.Visible = false;

                ddlQuarter.Visible = false;
                ddlQuarterDay.Visible = false;
                ddlQuarterDaysTime.Visible = false;

                ddlOneTime_Month.Visible = false;
                ddlOneTime_Day.Visible = false;
                ddlOneTime_Time.Visible = false;
                ddlyearonetimeonly.Visible = false;

                ChkIsmanual.Enabled = true;
            }
            else if (ddlaccurrence.SelectedValue == "6")
            {
                ddlYearMonth.Visible = false;
                ddlYearDays.Visible = false;
                ddlYearTime.Visible = false;

                ddlWeekly.Visible = false;
                ddlWeeklyTime.Visible = false;

                ddlMonthly.Visible = false;
                ddlMonthlyTime.Visible = false;

                ddlDailyTime.Visible = false;

                ddlQuarter.Visible = false;
                ddlQuarterDay.Visible = false;
                ddlQuarterDaysTime.Visible = false;

                ddlOneTime_Month.Visible = true;
                ddlOneTime_Day.Visible = true;
                ddlOneTime_Time.Visible = true;
                ddlyearonetimeonly.Visible = true;
                ChkIsmanual.Checked = false;
                ChkIsmanual.Enabled = false;

            }
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Accurencesschange();
        }
        public void Validate(out string errormsg)
        {

            errormsg = "";
            if (txtmeetingname.Text.Trim() == "")
            {
                errormsg = "Enter Meeting Name";
                return;
            }

            if (ddlaccurrence.SelectedValue == "-1")
            {
                errormsg = "Select occurrence";
                return;
            }          
            if (ddlaccurrence.SelectedValue != "-1")
            {

                if (ddlaccurrence.SelectedValue == "1")
                {
                    if (ddlDailyTime.SelectedValue == "-1")
                    {
                        errormsg = "Select occurrence Daily Time";
                        return;
                    }
                    if (ChkIsmanual.Checked == true)
                    {
                        if (ddlManualtime.SelectedValue == "-1")
                        {
                            errormsg = "Select Manual Daily Time";
                            return;
                        }
                    }

                }
                else if (ddlaccurrence.SelectedValue == "2")
                {
                    if (ddlMonthly.SelectedValue == "-1")
                    {
                        errormsg = "Select occurrence Monthly";
                        return;
                    }
                    else if (ddlMonthlyTime.SelectedValue == "-1")
                    {
                        errormsg = "Select occurrence Time";
                        return;
                    }

                    if (ChkIsmanual.Checked == true)
                    {
                        if (ddlManualdays.SelectedValue == "-1")
                        {
                            errormsg = "Select Manual Monthly";
                            return;
                        }
                        else if (ddlManualtime.SelectedValue == "-1")
                        {
                            errormsg = "Select Manual Time";
                            return;
                        }
                    }



                }
                else if (ddlaccurrence.SelectedValue == "3")
                {
                    if (ddlQuarter.SelectedValue == "-1")
                    {
                        errormsg = "Select occurrence Quarter";
                        return;
                    }
                    else if (ddlQuarterDay.SelectedValue == "-1")
                    {
                        errormsg = "Select occurrence Quarter Day";
                        return;
                    }
                    else if (ddlQuarterDaysTime.SelectedValue == "-1")
                    {
                        errormsg = "Select occurrence Quarter Days Time";
                        return;
                    }

                    if (ChkIsmanual.Checked == true)
                    {
                        if (ddlManualQuarter.SelectedValue == "-1")
                        {
                            errormsg = "Select Manual Quarter";
                            return;
                        }
                        else if (ddlManualdays.SelectedValue == "-1")
                        {
                            errormsg = "Select Manual Quarter Day";
                            return;
                        }
                        else if (ddlManualtime.SelectedValue == "-1")
                        {
                            errormsg = "Select Manual Quarter Days Time";
                            return;
                        }
                    }


                }
                else if (ddlaccurrence.SelectedValue == "4")
                {
                    if (ddlWeekly.SelectedValue == "-1")
                    {
                        errormsg = "Select occurrence Weekly";
                        return;
                    }
                    else if (ddlWeeklyTime.SelectedValue == "-1")
                    {
                        errormsg = "Select occurrence Weekly Time";
                        return;
                    }

                    if (ChkIsmanual.Checked == true)
                    {
                        if (ddlWeeklyManual.SelectedValue == "-1")
                        {
                            errormsg = "Select Manual Weekly";
                            return;
                        }
                        else if (ddlManualtime.SelectedValue == "-1")
                        {
                            errormsg = "Select Manual Weekly Time";
                            return;
                        }
                    }



                }
                else if (ddlaccurrence.SelectedValue == "5")
                {
                    if (ddlYearMonth.SelectedValue == "-1")
                    {
                        errormsg = "Select occurrence Month";
                        return;
                    }
                    else if (ddlYearDays.SelectedValue == "-1")
                    {
                        errormsg = "Select occurrence Year Days";
                        return;
                    }
                    else if (ddlYearTime.SelectedValue == "-1")
                    {
                        errormsg = "Select occurrence Year Time";
                        return;
                    }

                    if (ChkIsmanual.Checked == true)
                    {
                        if (ddlYearMonthManual.SelectedValue == "-1")
                        {
                            errormsg = "Select Manual Month";
                            return;
                        }
                        else if (ddlManualdays.SelectedValue == "-1")
                        {
                            errormsg = "Select Manual Year Days";
                            return;
                        }
                        else if (ddlManualtime.SelectedValue == "-1")
                        {
                            errormsg = "Select Manual Year Time";
                            return;
                        }
                    }


                }
                else if (ddlaccurrence.SelectedValue == "6")
                {
                    if (ddlOneTime_Month.SelectedValue == "-1")
                    {
                        errormsg = "Select one time occurrence Month";
                        return;
                    }
                    else if (ddlOneTime_Day.SelectedValue == "-1")
                    {
                        errormsg = "Select one time occurrence Day";
                        return;
                    }
                    else if (ddlOneTime_Time.SelectedValue == "-1")
                    {
                        errormsg = "Select one time occurrence Time";
                        return;
                    }
                    else if (ddlyearonetimeonly.SelectedValue == "-1")
                    {
                        errormsg = "Select one time occurrence year";
                        return;
                    }
                   
                        int Month = Convert.ToInt32(ddlOneTime_Month.SelectedValue);
                        int Day = Convert.ToInt32(ddlOneTime_Day.SelectedValue);
                        string Time = ddlOneTime_Time.SelectedValue;
                        int Years = Convert.ToInt32(ddlyearonetimeonly.SelectedValue);
                        DateTime t1 = DateTime.Parse("2012/12/12 " + Time);
                        DateTime t2 = DateTime.Parse("2012/12/12 " + DateTime.Now.ToString("hh:mm tt"));

                        DateTime UserTime = new DateTime(Years, Month, Day);
                        DateTime CurrentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                        if (UserTime < CurrentTime)
                        {
                            errormsg = "Date time cannot be less than from current date time";
                            return;

                        }
                        else if (UserTime == CurrentTime)
                        {
                            if (t1 < t2)
                            {
                                errormsg = "Date time cannot be less than from current date time";
                               
                                return;
                            }
                        }
                }
            }
            if (hdnuserlist.Value == "")
            {
                errormsg = "Select at least one Participant";
                return;
            }
            //if (ddlManualdays.SelectedValue == "-1")
            //{
            //    errormsg = "Select Manual days";
            //    return;
            //}
            //if (ddlManualtime.SelectedValue == "-1")
            //{
            //    errormsg = "Select Manual Time";
            //    return;
            //}
            //if (hdnuserlist.Value == "")
            //{
            //    errormsg = "Select at least one Participants";
            //    return;
            //}

        }
        protected void txtmeetingname_TextChanged(object sender, EventArgs e)
        {
            if (DuplicateMeetingNameCheck() != "")
            {
                ShowAlert("Event Name alredy exists choose  another!");
                txtmeetingname.Text = "";
                return;
            }
        }

        protected void grdMeetingsbipl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "edit")
            {
                foreach (GridViewRow row in grdMeetingsbipl.Rows)
                {
                    row.Attributes.Remove("class");
                }
                var value = e.CommandArgument;


                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                gvr.Attributes.Add("Class", "selected_row");
                Label lblParticipants = (Label)gvr.FindControl("lblParticipants");
                HiddenField hdnMeetingSchedule_Id = (HiddenField)gvr.FindControl("hdnMeetingSchedule_Id");
                txtparticipante.Text = lblParticipants.Text;
                MeetingScheduleId = Convert.ToInt32(hdnMeetingSchedule_Id.Value);
                BindEditTable();
            }

        }
        protected void grdMeetingsbipl_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        public string DuplicateMeetingNameCheck()
        {
            string result = "";
            DataTable dt = objfab.MeetingNameDuplicateCheck("DUPLICATECHECK", MeetingScheduleId, txtmeetingname.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["DuplicateCheck"].ToString() == "EXISTS")
                {
                    result = "EXISTS";
                }
                else if (dt.Rows[0]["DuplicateCheck"].ToString() == "NOTEXISTS")
                {
                    result = "";
                }

            }
            return result;
        }
        public void btnaddnew_Click(object sender, EventArgs e)
        {

            //MeetingScheduleId = 0;

            //grdMeetingsbipl.Visible = true;
            //tbladd.Visible = true;
            //Bindddl();
            //myCollection.Clear();
            //lbluserlist.Text = "";
            //BindTime(ddlDailyTime);
            //BindTime(ddlWeeklyTime);
            //BindTime(ddlMonthlyTime);
            //BindTime(ddlQuarterDaysTime);
            //BindTime(ddlDailyTime);
            //BindTime(ddlManualtime);
            //BindTime(ddlYearTime);
            //bindgrd();
            //hdnuserlist.Value = "";
            //ChkIsmanual.Checked = false;

            //ddlYearMonth.Visible = false;
            //ddlYearDays.Visible = false;
            //ddlYearTime.Visible = false;
            //ddlWeekly.Visible = false;
            //ddlWeeklyTime.Visible = false;
            //ddlMonthly.Visible = false;
            //ddlMonthlyTime.Visible = false;
            //ddlDailyTime.Visible = false;
            //ddlQuarter.Visible = false;
            //ddlQuarterDay.Visible = false;
            //ddlQuarterDaysTime.Visible = false;

            //ddlManualdays.Visible = false;
            //ddlManualtime.Visible = false;


            //ddlWeeklyManual.Visible = false;
            //ddlYearMonthManual.Visible = false;
            //ddlManualQuarter.Visible = false;
            //txtmeetingname.Text = "";
            //txtDescription.Text = "";
            //ddlaccurrence.Enabled = true;

            Response.Redirect(Request.RawUrl);
        }
        public static string AddOrdinal(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return "th";
            }

            switch (num % 10)
            {
                case 1:
                    return "st";
                case 2:
                    return "nd";
                case 3:
                    return "rd";
                default:
                    return "th";
            }

        }
        public string GetWeekName(int days)
        {
            string WeekName = "";
            switch (days)
            {
                case 1:
                    WeekName = "Sunday";
                    break;
                case 2:
                    WeekName = "Monday";
                    break;
                case 3:
                    WeekName = "Tuesday";
                    break;
                case 4:
                    WeekName = "Wednesday";
                    break;
                case 5:
                    WeekName = "Thursday";
                    break;
                case 6:
                    WeekName = "Friday";
                    break;
                case 7:
                    WeekName = "Saturday";
                    break;
                default:
                    WeekName = "";
                    break;
            }
            return WeekName;
        }
        public string GetmonthName(int days)
        {
            string monthName = "";
            switch (days)
            {
                case 1:
                    monthName = "January";
                    break;
                case 2:
                    monthName = "February";
                    break;
                case 3:
                    monthName = "March";
                    break;
                case 4:
                    monthName = "April";
                    break;
                case 5:
                    monthName = "May";
                    break;
                case 6:
                    monthName = "June";
                    break;
                case 7:
                    monthName = "July";
                    break;
                case 8:
                    monthName = "August";
                    break;
                case 9:
                    monthName = "September";
                    break;
                case 10:
                    monthName = "October";
                    break;
                case 11:
                    monthName = "November";
                    break;
                case 12:
                    monthName = "December";
                    break;
                default:
                    monthName = "";
                    break;
            }
            return monthName;
        }
        protected void grdMeetingsbipl_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HiddenField hdnMeetingCategory_Id = (HiddenField)e.Row.FindControl("hdnMeetingCategory_Id");
                HiddenField hdnMonth = (HiddenField)e.Row.FindControl("hdnMonth");
                HiddenField hdnDay = (HiddenField)e.Row.FindControl("hdnDay");
                HiddenField hdnTime = (HiddenField)e.Row.FindControl("hdnTime");
                Label lblOccurrence = (Label)e.Row.FindControl("lblOccurrence");
                Label lblManual = (Label)e.Row.FindControl("lblManual");
                HiddenField hdnManual_Day = (HiddenField)e.Row.FindControl("hdnManual_Day");
                HiddenField hdnManual_Time = (HiddenField)e.Row.FindControl("hdnManual_Time");
                HiddenField hdnManual_Month = (HiddenField)e.Row.FindControl("hdnManual_Month");
                Label lblParticipants = (Label)e.Row.FindControl("lblParticipants");
                HiddenField hdnIsManual = (HiddenField)e.Row.FindControl("hdnIsManual");
                HiddenField hdnyear = (HiddenField)e.Row.FindControl("hdnyear");
                if (hdnMeetingCategory_Id.Value == "3")
                {
                    //lblOccurrence.Text = "<b>Quarterly</b> - <b>" + hdnMonth.Value + (AddOrdinal(Convert.ToInt32(hdnMonth.Value))).ToString() + "</b><span style='color:gray'> Month of Qtr.</span><b>" + hdnDay.Value + "</b><span style='color:gray'> Day at</span><b> " + hdnTime.Value + "</b>";


                    lblOccurrence.Text = "<b>Quarterly</b> - " + "<b>" + hdnDay.Value + "</b>" + "<span style='color:gray'> Day of.</span>" + "<b>" + hdnMonth.Value + "</b>" + (AddOrdinal(Convert.ToInt32(hdnMonth.Value))).ToString() + "<span style='color:gray'> month each qtr at.</span>" + "<b> " + hdnTime.Value + "</b>";
                    if (hdnIsManual.Value == "True")
                        lblManual.Text = "<b>Manually</b> - <b>" + hdnManual_Day.Value + "</b>" + " Day" + " of <span style='color:gray'>of</span><span style='color:gray'> Day at </span> " + (AddOrdinal(Convert.ToInt32(hdnManual_Month.Value))).ToString() + "month earch qtr. at<b> " + hdnManual_Time.Value + "</b>";
                }
                else if (hdnMeetingCategory_Id.Value == "1")
                {
                    lblOccurrence.Text = "<b>Daily</b> - <b>" + hdnTime.Value + "</b>";

                    if (hdnIsManual.Value == "True")
                        lblManual.Text = "<b>Manually</b> - <b>" + hdnManual_Time.Value + "</b>";
                }
                else if (hdnMeetingCategory_Id.Value == "2")
                {
                    lblOccurrence.Text = "<b>Monthly</b> - <b>" + hdnDay.Value + (AddOrdinal(Convert.ToInt32(hdnDay.Value))).ToString() + "</b> <span style='color:gray'>Day of every month at</span> <b>" + hdnTime.Value + "</b>";

                    if (hdnIsManual.Value == "True")
                        lblManual.Text = "<b>Manually</b> - <b>" + hdnManual_Day.Value + (AddOrdinal(Convert.ToInt32(hdnManual_Day.Value))).ToString() + "</b><span style='color:gray'> at</span><b> " + hdnManual_Time.Value + "<b>";
                }
                else if (hdnMeetingCategory_Id.Value == "4")
                {
                    lblOccurrence.Text = "<b>Weekly</b> -<span style='color:gray'> every </span><b>" + GetWeekName(Convert.ToInt32(hdnDay.Value)) + "</b><span style='color:gray'> at </span><b>" + hdnTime.Value + "</b>";

                    if (hdnIsManual.Value == "True")
                        lblManual.Text = "<b>Manually</b> - <span style='color:gray'>This </span><b>" + GetWeekName(Convert.ToInt32(hdnManual_Day.Value)) + "</b><span style='color:gray'> at </span><b>" + hdnManual_Time.Value + "</b>";
                }
                else if (hdnMeetingCategory_Id.Value == "5")
                {
                    lblOccurrence.Text = "<b>Yearly </b> - <b>" + hdnDay.Value + (AddOrdinal(Convert.ToInt32(hdnMonth.Value))).ToString() + " " + GetmonthName(Convert.ToInt32(hdnMonth.Value)) + "</b><span style='color:gray'> at </span><b>" + hdnTime.Value + "</b>";

                    if (hdnIsManual.Value == "True")
                        lblManual.Text = "<b>Manually </b> - <b>" + hdnManual_Day.Value + (AddOrdinal(Convert.ToInt32(hdnManual_Month.Value))).ToString() + " " + GetmonthName(Convert.ToInt32(hdnManual_Month.Value)) + "</b><span style='color:gray'> at </span><b>" + hdnManual_Time.Value + "</b>";
                }
                else if (hdnMeetingCategory_Id.Value == "6")
                {
                    lblOccurrence.Text = "<b>OneTime </b> - <b>" + hdnDay.Value + (AddOrdinal(Convert.ToInt32(hdnMonth.Value))).ToString() + " " + GetmonthName(Convert.ToInt32(hdnMonth.Value)) + " " + hdnyear.Value + " </b><span style='color:gray'> at </span><b>" + hdnTime.Value + "</b>";


                }
                string[] struser = lblParticipants.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                string[] srdis = struser.Distinct().ToArray();
                lblParticipants.Text = "";
                for (int i = 0; i < srdis.Length; i++)
                {
                    string strinf = "";
                    foreach (User xx in Users)
                    {
                        strinf = "";
                        if (srdis[i].ToString().Trim().ToLower() == xx.FullName.ToLower())
                        {
                            strinf += strinf + "<table>" +
                                "<tr>"
                                + "<td>" + "Full Name" + "</td>" + "<tr>" +
                                 "<td>" + xx.FullName.ToLower() + "</td>" + "<tr>" +
                                  "<td>" + "Designation" + "</td>" + "<tr>" +
                                 "<td>" + xx.DesignationName.ToLower() + "</td>" + "<tr>" +
                                 "<td>" + "Line Mgr." + "</td>" + "<tr>" +
                                 "<td>" + xx.ManagerName + "</td>" + "<tr>" +
                                 "<td>" + "Dept. Name" + "</td>" + "<tr>" +
                                 "<td>" + xx.PrimaryGroup + "</td>" + "<tr>" +
                                "</table>";
                            break;
                        }

                    }

                    lblParticipants.Text = "<div>" + lblParticipants.Text + " " + srdis[i].ToString() + "</div>";
                }
            }
        }
        public void Mailscheduler(DataTable dt)
        {
            //======Daily===============================================================================
            if (dt.Rows.Count > 0)
                MeetingScheduleId = Convert.ToInt32(dt.Rows[0]["MeetingSchedule_Id"].ToString());

            DataTable dtdaily = objfab.MeetingDaily("DAILYMAIL", MeetingScheduleId);
            MailType = "Daily Meeting";
            if (dtdaily.Rows.Count > 0)
            {
                int days = DateTime.Now.Day;


                //int days = 17;
                //days = days + 1;
                DateTime Todaydate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days);
                foreach (DataRow dtRow in dtdaily.Rows)
                {

                    string EmailContent = dtRow["Description"].ToString();

                    string Daily_Time = dtRow["Time"].ToString();
                    if (Convert.ToBoolean(dtRow["IsManual"].ToString()) == true)
                    {
                        string Manual_Day = dtRow["Manual_Day"].ToString();
                        string Manual_Time = dtRow["Manual_Time"].ToString();

                        DateTime t1 = DateTime.Parse("2012/12/12 " + Manual_Time);
                        DateTime t2 = DateTime.Parse("2012/12/12 " + DateTime.Now.ToString("hh:mm tt"));

                        if (t1.TimeOfDay > t2.TimeOfDay)
                        {
                            //something
                        }
                        else
                        {
                            days = days + 1;
                        }

                        if (t1.TimeOfDay > t2.TimeOfDay)
                        {
                            DateTime ExistsDateDaily = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                            if (EmailDate(ExistsDateDaily.AddDays(-1)) != ExistsDateDaily)
                            {
                                ExistsDateDaily = EmailDate(ExistsDateDaily);
                            }
                            EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</span></b><span style='color:#524848'> on dated</span> " + "<b> " + ExistsDateDaily.ToString("dd MMM yy (ddd)") + "</b> <span style='color:#524848'>at time<span> " + "<b> " + Manual_Time + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                          "</span> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";
                            MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + ExistsDateDaily.ToString("dd MMM yy (ddd)") + " at " + Manual_Time;
                            SendClientRegistrationEmail("abhishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                        }
                        else
                        {
                            DateTime ExistsDateDaily = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                            EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</span></b><span style='color:#524848'> on dated</span> " + "<b> " + EmailDate(ExistsDateDaily).ToString("dd MMM yy (ddd)") + "</b> <span style='color:#524848'>at time<span> " + "<b> " + Manual_Time + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                          "</span> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";
                            MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + EmailDate(ExistsDateDaily).ToString("dd MMM yy (ddd)") + " at " + Manual_Time;

                            SendClientRegistrationEmail("abhishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                        }

                    }
                    else
                    {
                        DateTime t1 = DateTime.Parse("2012/12/12 " + Daily_Time);
                        DateTime t2 = DateTime.Parse("2012/12/12 " + DateTime.Now.ToString("hh:mm tt"));

                        if (dtRow["Participate"].ToString() != "")
                        {
                            if (t1.TimeOfDay > t2.TimeOfDay)
                            {
                                DateTime ExistsDateDaily = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                                if (EmailDate(ExistsDateDaily.AddDays(-1)) != ExistsDateDaily)
                                {
                                    ExistsDateDaily = EmailDate(ExistsDateDaily);
                                }
                                EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</span></b><span style='color:#524848'> on dated</span> " + "<b> " + ExistsDateDaily.ToString("dd MMM yy (ddd)") + "</b> <span style='color:#524848'>at time<span> " + "<b> " + Daily_Time + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                              "</span> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";
                                MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + ExistsDateDaily.ToString("dd MMM yy (ddd)") + " at " + Daily_Time;
                                SendClientRegistrationEmail("abhishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                            }
                            else
                            {
                                DateTime ExistsDateDaily = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                                EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</span></b><span style='color:#524848'> on dated</span> " + "<b> " + EmailDate(ExistsDateDaily).ToString("dd MMM yy (ddd)") + "</b> <span style='color:#524848'>at time<span> " + "<b> " + Daily_Time + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                              "</span> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";
                                MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + EmailDate(ExistsDateDaily).ToString("dd MMM yy (ddd)") + " at " + Daily_Time;

                                SendClientRegistrationEmail("abhishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                            }
                        }
                    }
                }
            }

        }
        public void EmailHolidayReminder()
        {

            DataTable dtparticipents = objnotif.GetpRODUCTMAIL("HOLIDAYMEETINGS").Tables[0];
            DataTable dt = objfab.GetEventOccurenceDetails(0);
            string _strHolidayList = "";
            DateTime Ddate;
            int Day;
            int Month;
            string ExistWeekName;
            DateTime NextDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(1);
            if (EmailDateCheckIsEvent(NextDate) == "YES")
            {
                foreach (DataRow dtRow in dt.Rows)
                {
                    if (dtRow["MeetingCategory_Id"].ToString() == "1")//Daily
                    {
                        Ddate = DateTime.Now.AddDays(1);
                        if (NextDate == Ddate)
                        {
                            _strHolidayList = _strHolidayList + dtRow["MeetingName"].ToString() + ",&nbsp;";
                        }
                    }
                    else if (dtRow["MeetingCategory_Id"].ToString() == "2")//Monthly
                    {
                        if (dtRow["IsManual"].ToString() == "True")
                        {
                            Day = Convert.ToInt32(dtRow["Manual_Day"].ToString());
                        }
                        else
                        {
                            Day = Convert.ToInt32(dtRow["Day"].ToString());
                        }

                        if (Day < DateTime.Now.Day)
                        {
                            Ddate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Day).AddMonths(1);

                        }
                        else
                        {
                            Ddate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Day);
                        }

                        if (NextDate == Ddate)
                        {
                            _strHolidayList = _strHolidayList + dtRow["MeetingName"].ToString() + ",&nbsp;";
                        }
                    }
                    else if (dtRow["MeetingCategory_Id"].ToString() == "3")//Quarterly
                    {

                        if (dtRow["IsManual"].ToString() == "True")
                        {
                            Day = Convert.ToInt32(dtRow["Manual_Day"].ToString());
                            Month = Convert.ToInt32(dtRow["Manual_Month"].ToString());

                        }
                        else
                        {
                            Day = Convert.ToInt32(dtRow["Day"].ToString());
                            Month = Convert.ToInt32(dtRow["Month"].ToString());
                        }
                        
                        if (DateTime.Now.Month > 3 && GetQuarter(DateTime.Now, Month) >= 1 && GetQuarter(DateTime.Now, Month) <= 3)
                        {
                            Ddate = new DateTime(DateTime.Now.Year + 1, GetQuarter(DateTime.Now, Month) + 3, Day);
                        }
                        else
                        {
                            Ddate = new DateTime(DateTime.Now.Year, GetQuarter(DateTime.Now, Month), Day);
                        }
                        if (NextDate == Ddate)
                        {
                            _strHolidayList = _strHolidayList + dtRow["MeetingName"].ToString() + ",&nbsp;";
                        }
                    }
                    else if (dtRow["MeetingCategory_Id"].ToString() == "4")//Weekly
                    {
                        if (dtRow["IsManual"].ToString() == "True")
                        {
                            Day = Convert.ToInt32(dtRow["Manual_Day"].ToString());
                        }
                        else
                        {
                            Day = Convert.ToInt32(dtRow["Day"].ToString());
                        }
                        ExistWeekName = GetWeekName(Day);
                        if (NextDate.ToString("dddd") == ExistWeekName)
                        {
                            _strHolidayList = _strHolidayList + dtRow["MeetingName"].ToString() + ",&nbsp;";
                        }
                    }
                    else if (dtRow["MeetingCategory_Id"].ToString() == "5")//Yearly
                    {
                        if (dtRow["IsManual"].ToString() == "True")
                        {
                            Day = Convert.ToInt32(dtRow["Manual_Day"].ToString());
                            Month = Convert.ToInt32(dtRow["Manual_Month"].ToString());

                        }
                        else
                        {
                            Day = Convert.ToInt32(dtRow["Day"].ToString());
                            Month = Convert.ToInt32(dtRow["Month"].ToString());
                        }
                        Ddate = new DateTime(DateTime.Now.Year, Month, Day);
                        DateTime TodayDayTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        if (Ddate < TodayDayTime)
                        {
                            Ddate.AddYears(1);
                        }

                        if (NextDate == Ddate)
                        {
                            _strHolidayList = _strHolidayList + dtRow["MeetingName"].ToString() + ",&nbsp;";
                        }

                    }
                    else if (dtRow["MeetingCategory_Id"].ToString() == "6")//OneTime
                    {

                        Day = Convert.ToInt32(dtRow["Day"].ToString());
                        if (Day < DateTime.Now.Day)
                        {
                            Ddate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Day).AddMonths(1);

                        }
                        else
                        {
                            Ddate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Day);
                        }

                        if (NextDate == Ddate)
                        {
                            _strHolidayList = _strHolidayList + dtRow["MeetingName"].ToString() + ",&nbsp;";
                        }
                    }
                }
                if (_strHolidayList != "")
                {
                    _strHolidayList = _strHolidayList.Remove(_strHolidayList.Length - 1);
                    MailType = " Reschedule the following meeting due to upcoming holiday";
                    string EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;Tomorrow is holiday and following meetings scheduled tomorrow. Please manually update the schedules if required.</span>" +
                                          "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + "<b>" + _strHolidayList + "</b>" + "</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

                    SendClientRegistrationEmail("abhishek", "", EmailContent, MailType, dtparticipents.Rows[0]["Email"].ToString());
                }

            }



        }
        public void MailsschedulerSave()
        {
            //====not==Daily===============================================================================
            // Normal Mails
            // Daily Mails
            EmailHolidayReminder();
            if ((EmailDate(DateTime.Now.AddDays(-1)) - (DateTime.Now)).Days == 0)
            {
                DataTable dtdaily_Normal = objfab.MeetingDaily("MAILSAVESSCHEDULER", 1);

                foreach (DataRow dtRow in dtdaily_Normal.Rows)
                {

                    int days = DateTime.Now.Day;
                    if (Convert.ToBoolean(dtRow["IsManual"].ToString()) == true)
                    {
                        //Start
                        MailType = dtRow["MeetingName"].ToString();

                        DateTime Todaydate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days);
                        string EmailContent = dtRow["Description"].ToString();
                        string Manual_Day = dtRow["Manual_Day"].ToString();
                        string Manual_Time = dtRow["Manual_Time"].ToString();
                        DateTime ExistsDateDaily = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(days));
                        //EmailDate(ExistsDateDaily);

                        MailType = dtRow["MeetingName"].ToString() + " " + "Scheduled On " + EmailDate(ExistsDateDaily).ToString("dd MMM yy (ddd)") + " at " + dtRow["Manual_Time"].ToString();
                        if (dtRow["Participate"].ToString() != "")
                        {

                            if ((DateTime.Now - (Convert.ToDateTime(dtRow["UpdatedOn"].ToString()))).Days == 0)
                            {
                                EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b> <span style='color:#524848'>on dated</span> " + " <b>" + EmailDate(ExistsDateDaily).ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'> at time </span>" + "<b> " + Manual_Time + ".</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                                                       "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>&nbsp;&nbsp;&nbsp;" + "This is system generated mail. Please do not reply on this mail." + "<br><br></div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong>  <br> Team BIPL " + "</div>";
                                SendClientRegistrationEmail("abhishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                                DataTable dtx = objfab.MAILUPDATE("MAILUPDATE", Convert.ToInt32(dtRow["MeetingSchedule_Id"].ToString()));
                            }
                            else
                            {
                                // Update manual to 0
                                DataTable dtx = objfab.MAILUPDATE("MAILUPDATE", Convert.ToInt32(dtRow["MeetingSchedule_Id"].ToString()));
                                // send mail as normal
                                EmailContent = dtRow["Description"].ToString();
                                string Day = dtRow["Day"].ToString();
                                string Daily_Time = dtRow["Time"].ToString();


                                if (dtRow["Participate"].ToString() != "")
                                {
                                    ExistsDateDaily = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days);
                                    MailType = MailType + " Scheduled On " + EmailDate(ExistsDateDaily).ToString("dd MMM yy (ddd)") + " at " + Daily_Time;
                                    EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</span></b><span style='color:#524848'> on dated</span> " + "<b> " + EmailDate(ExistsDateDaily).ToString("dd MMM yy (ddd)") + "</b> <span style='color:#524848'>at time<span> " + "<b> " + Daily_Time + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                                    "</span> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";


                                    SendClientRegistrationEmail("abhishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                                }

                            }


                        }
                    }
                    else
                    {
                        string EmailContent = dtRow["Description"].ToString();
                        string Day = dtRow["Day"].ToString();
                        string Daily_Time = dtRow["Time"].ToString();


                        if (dtRow["Participate"].ToString() != "")
                        {
                            DateTime ExistsDateDaily = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days);
                            MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + EmailDate(ExistsDateDaily).ToString("dd MMM yy (ddd)") + " at " + Daily_Time;
                            EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</span></b><span style='color:#524848'> on dated</span> " + "<b> " + EmailDate(ExistsDateDaily).ToString("dd MMM yy (ddd)") + "</b> <span style='color:#524848'>at time<span> " + "<b> " + Daily_Time + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                            "</span> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";


                            SendClientRegistrationEmail("abhishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                        }
                    }
                }

                // Weekly Mails
                DataTable dtWeekly_Normal = objfab.MeetingDaily("MAILSAVESSCHEDULER", 4);
                foreach (DataRow dtRow in dtWeekly_Normal.Rows)
                {
                    int Days = DateTime.Now.Day;
                    if (Convert.ToBoolean(dtRow["IsManual"].ToString()) == true)
                    {
                        int Manual_Day = Convert.ToInt32(dtRow["Manual_Day"].ToString());
                        DateTime NextdayTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Days);
                        NextdayTime = EmailDate(NextdayTime);

                        string TodayDayWeekName = NextdayTime.ToString("dddd");
                        string ExistsDayWeekName = GetWeekName(Manual_Day);
                        //string ExistsDayWeekName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Manual_Day).ToString("dddd");
                        if (TodayDayWeekName == ExistsDayWeekName)
                        {
                            MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + NextdayTime.ToString("dd MMM yy (ddd)") + " at " + dtRow["Manual_Time"].ToString();
                            string EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'>  on dated </span>" + " <b>" + NextdayTime.ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'>  at time </span>" + "<b> " + dtRow["Manual_Time"].ToString() + "</b> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                      "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

                            if (dtRow["Participate"].ToString() != "")
                            {
                                SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                            }
                            // Update manual to 0
                            DataTable dtx = objfab.MAILUPDATE("MAILUPDATE", Convert.ToInt32(dtRow["MeetingSchedule_Id"].ToString()));

                        }

                    }
                    else
                    {
                        int Day = Convert.ToInt32(dtRow["Day"].ToString());
                        DateTime NextdayTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Days);
                        NextdayTime = EmailDate(NextdayTime);

                        string TodayDayWeekName = NextdayTime.ToString("dddd");
                        // string ExistsDayWeekName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Day).ToString("dddd");
                        string ExistsDayWeekName = GetWeekName(Day);
                        if (TodayDayWeekName == ExistsDayWeekName)
                        {
                            MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + NextdayTime.ToString("dd MMM yy (ddd)") + " at " + dtRow["Time"].ToString();
                            string EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'>  on dated </span>" + " <b>" + NextdayTime.ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'>  at time </span>" + "<b> " + dtRow["Time"].ToString() + "</b> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                      "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

                            if (dtRow["Participate"].ToString() != "")
                            {
                                SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                            }
                        }
                    }
                }


                // Monthly Mails
                DataTable dtMonthly_Normal = objfab.MeetingDaily("MAILSAVESSCHEDULER", 2);
                foreach (DataRow dtRow in dtMonthly_Normal.Rows)
                {
                    int Days = DateTime.Now.Day;
                    if (Convert.ToBoolean(dtRow["IsManual"].ToString()) == true)
                    {
                        int Manual_Day = Convert.ToInt32(dtRow["Manual_Day"].ToString());
                        DateTime NextdayTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Days);
                        NextdayTime = EmailDate(NextdayTime);
                        DateTime ExistsDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Manual_Day);
                        if (ExistsDate.ToString("dddd") == EmailDate(NextdayTime).AddDays(-1).ToString("dddd"))
                        {

                            MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + NextdayTime.ToString("dd MMM yy (ddd)") + " at " + dtRow["Manual_Time"].ToString();
                            string EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'>  on dated </span>" + " <b>" + NextdayTime.ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'>  at time </span>" + "<b> " + dtRow["Manual_Time"].ToString() + "</b> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                      "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

                            if (dtRow["Participate"].ToString() != "")
                            {
                                SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                            }
                            // Update manual to 0
                            DataTable dtx = objfab.MAILUPDATE("MAILUPDATE", Convert.ToInt32(dtRow["MeetingSchedule_Id"].ToString()));
                        }
                    }
                    // Updated on 18 feb 2020
                    else
                    {
                        int Day = Convert.ToInt32(dtRow["Day"].ToString());
                         //= new DateTime(DateTime.Now.Year, DateTime.Now.Month, Day);
                        DateTime Plandate  = CheckDayExistsInMonth(Day);
                        if (EmailDateCheckIsEvent(Plandate) == "YES")
                        {
                            Plandate = EmailDate(Plandate);
                        }
                        DateTime NextdayTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Days);

                        //if(NextdayTime < DateTime.Now

                        NextdayTime = EmailDate(NextdayTime);
                        //DateTime ExistsDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Day);

                        //DateTime d1 = new DateTime(EmailDate(NextdayTime).Year, EmailDate(NextdayTime).Month, EmailDate(NextdayTime).Day);
                        //DateTime d2 = new DateTime(ExistsDate.Year, ExistsDate.Month, ExistsDate.Day);
                        string ExistsDate = GetWeekName(Convert.ToInt32(Day));
                        string NextdayTime2 = GetWeekName(Convert.ToInt32(Days));
                        if (Plandate.Day == NextdayTime.Day)
                        {
                            MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + NextdayTime.ToString("dd MMM yy (ddd)") + " at " + dtRow["Time"].ToString();
                            string EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'>  on dated </span>" + " <b>" + NextdayTime.ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'>  at time </span>" + "<b> " + dtRow["Time"].ToString() + "</b> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                      "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

                            if (dtRow["Participate"].ToString() != "")
                            {
                                SendClientRegistrationEmail("abhishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                            }

                        }
                    }
                    // end of Updated on 18 feb 2020
                }


                // Quarterly Mails
                DataTable dtQuarterly_Normal = objfab.MeetingDaily("MAILSAVESSCHEDULER", 3);
                foreach (DataRow dtRow in dtQuarterly_Normal.Rows)
                {
                    int Days = DateTime.Now.Day;
                    if (Convert.ToBoolean(dtRow["IsManual"].ToString()) == true)
                    {
                        int Manual_Day = Convert.ToInt32(dtRow["Manual_Day"].ToString());

                        DateTime NextdayTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Days);
                        NextdayTime = EmailDate(NextdayTime);

                        int Manual_Month = Convert.ToInt32(dtRow["Manual_Month"].ToString());
                        DateTime ExistsDate = new DateTime(DateTime.Now.Year, Manual_Month, Manual_Day);

                        ExistsDate = new DateTime(DateTime.Now.Year, GetQuarter(DateTime.Now, Manual_Month), Manual_Day);

                        if ((NextdayTime - (ExistsDate)).Days == 0)
                        {
                            MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + NextdayTime.ToString("dd MMM yy (ddd)") + " at " + dtRow["Manual_Time"].ToString();
                            string EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'>  on dated </span>" + " <b>" + NextdayTime.ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'>  at time </span>" + "<b> " + dtRow["Manual_Time"].ToString() + "</b> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                      "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

                            if (dtRow["Participate"].ToString() != "")
                            {
                                SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                            }
                            // Update manual to 0
                            DataTable dtx = objfab.MAILUPDATE("MAILUPDATE", Convert.ToInt32(dtRow["MeetingSchedule_Id"].ToString()));

                        }

                    }
                    else
                    {
                        int Month = Convert.ToInt32(dtRow["Month"].ToString());
                        Days = Convert.ToInt32(dtRow["Day"].ToString());


                        DateTime NextdayTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        NextdayTime = EmailDate(NextdayTime);
                        DateTime ExistsDate = new DateTime(DateTime.Now.Year, GetQuarter(NextdayTime, Month), Days);

                        if (ExistsDate == NextdayTime)
                        {
                            NextdayTime = EmailDate(DateTime.Now);
                            if ((NextdayTime - ExistsDate).Days == 0)
                            {

                                MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + NextdayTime.ToString("dd MMM yy (ddd)") + " at " + dtRow["Time"].ToString();
                                string EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'>  on dated </span>" + " <b>" + NextdayTime.ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'>  at time </span>" + "<b> " + dtRow["Time"].ToString() + "</b> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                          "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

                                if (dtRow["Participate"].ToString() != "")
                                {
                                    SendClientRegistrationEmail("abhishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                                }

                            }
                        }

                    }
                }
                // Yearly Mails
                DataTable dtYearly_Normal = objfab.MeetingDaily("MAILSAVESSCHEDULER", 5);
                foreach (DataRow dtRow in dtYearly_Normal.Rows)
                {

                    int Days = DateTime.Now.Day;
                    if (Convert.ToBoolean(dtRow["IsManual"].ToString()) == true)
                    {
                        DateTime Todaydate = DateTime.Now;
                        DateTime t1 = DateTime.Parse("2012/12/12 " + dtRow["Manual_Time"].ToString());
                        DateTime t2 = DateTime.Parse("2012/12/12 " + DateTime.Now.ToString("hh:mm tt"));

                        int Manual_Day = Convert.ToInt32(dtRow["Manual_Day"].ToString());
                        DateTime NextdayTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Days);
                        NextdayTime = EmailDate(NextdayTime);

                        int Manual_Month = Convert.ToInt32(dtRow["Manual_Month"].ToString());
                        DateTime ExistsDate = new DateTime(DateTime.Now.Year, Manual_Month, Manual_Day);

                        //if (NextdayTime.ToString("dddd") == ExistsDate.ToString("dddd"))
                        //{

                        //    if (t1.TimeOfDay < t2.TimeOfDay)
                        //    {
                        //        NextdayTime = NextdayTime.AddYears(1);

                        //    }
                        //    if (EmailDateCheckIsEvent(NextdayTime) == "YES")
                        //    {
                        //        NextdayTime = EmailDate(NextdayTime);
                        //    }
                        //    MailType = " Scheduled On " + NextdayTime.ToString("dd MMM yy (ddd)") + " at " + dtRow["Manual_Time"].ToString();
                        //    string EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'>  on dated </span>" + " <b>" + NextdayTime.ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'>  at time </span>" + "<b> " + dtRow["Manual_Time"].ToString() + "</b> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                        //              "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

                        //    if (dtRow["Participate"].ToString() != "")
                        //    {
                        //        SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                        //    }
                        //    // Update manual to 0
                        //    DataTable dtx = objfab.MAILUPDATE("MAILUPDATE", Convert.ToInt32(dtRow["MeetingCategory_Id"].ToString()));
                        //}
                        //else
                        //{


                        //NextdayTime = EmailDate(NextdayTime);
                        string ExistsDateWeekName = new DateTime(DateTime.Now.Year, Manual_Month, Manual_Day).ToString("dddd");
                        string NextdayTime2 = NextdayTime.ToString("dddd");
                        //if (ExistsDateWeekName == NextdayTime2)
                        //{
                        if (NextdayTime == ExistsDate)
                        {
                            //if (t1.TimeOfDay < t2.TimeOfDay)
                            //{
                            //    NextdayTime = NextdayTime.AddYears(1);
                            //}
                            //if (EmailDateCheckIsEvent(NextdayTime) == "YES")
                            //{
                            //    NextdayTime = EmailDate(NextdayTime);
                            //}


                            MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + NextdayTime.ToString("dd MMM yy (ddd)") + " at " + dtRow["Manual_Time"].ToString();
                            string EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'>  on dated </span>" + " <b>" + NextdayTime.ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'>  at time </span>" + "<b> " + dtRow["Manual_Time"].ToString() + "</b> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                      "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

                            if (dtRow["Participate"].ToString() != "")
                            {
                                SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                            }
                            // Update manual to 0
                            DataTable dtx = objfab.MAILUPDATE("MAILUPDATE", Convert.ToInt32(dtRow["MeetingSchedule_Id"].ToString()));

                        }
                    }
                    //}
                    //}
                    else
                    {
                        int Month = Convert.ToInt32(dtRow["Month"].ToString());
                        int Day = Convert.ToInt32(dtRow["Day"].ToString());
                        DateTime NextdayTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Days);

                        NextdayTime = EmailDate(NextdayTime);
                        DateTime ExistsDate = new DateTime(DateTime.Now.Year, Month, Day);
                        if ((NextdayTime - ExistsDate).Days == 0)
                        {
                            DateTime Todaydate = DateTime.Now;
                            DateTime t1 = DateTime.Parse("2012/12/12 " + dtRow["Time"].ToString());
                            DateTime t2 = DateTime.Parse("2012/12/12 " + DateTime.Now.ToString("hh:mm tt"));
                            if (t1.TimeOfDay < t2.TimeOfDay)
                            {
                                NextdayTime = NextdayTime.AddYears(1);
                            }
                            MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + NextdayTime.ToString("dd MMM yy (ddd)") + " at " + dtRow["Time"].ToString();
                            string EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'>  on dated </span>" + " <b>" + NextdayTime.ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'>  at time </span>" + "<b> " + dtRow["Time"].ToString() + "</b> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                      "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

                            if (dtRow["Participate"].ToString() != "")
                            {
                                SendClientRegistrationEmail("abhishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                            }

                        }
                    }
                }
                // OneTimeOnly Mails
                DataTable dtOneTimeOnly = objfab.MeetingDaily("MAILSAVESSCHEDULER", 6);
                foreach (DataRow dtRow in dtOneTimeOnly.Rows)
                {
                    int Days = DateTime.Now.Day;
                    if (Convert.ToBoolean(dtRow["IsManual"].ToString()) == false)
                    {

                        int Month = Convert.ToInt32(dtRow["Month"].ToString());
                        int Day = Convert.ToInt32(dtRow["Day"].ToString());
                        int Years = Convert.ToInt32(dtRow["Years"].ToString());

                        DateTime ExistsDate = new DateTime(Years, Month, Day);


                        DateTime NextdayTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                        NextdayTime = EmailDate(NextdayTime);

                        if (ExistsDate == NextdayTime)
                        {
                            DateTime Todaydate = DateTime.Now;
                          
                            DateTime UserTime = new DateTime(Years, Month, Day);
                          

                            DateTime CurrentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                            

                            if (UserTime.TimeOfDay > CurrentTime.TimeOfDay)
                            {
                                NextdayTime = NextdayTime.AddDays(-1);
                            }

                            MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + NextdayTime.ToString("dd MMM yy (ddd)") + " at " + dtRow["Time"].ToString();
                            string EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'>  on dated </span>" + " <b>" + NextdayTime.ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'>  at time </span>" + "<b> " + dtRow["Time"].ToString() + "</b> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                                 "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

                            if (dtRow["Participate"].ToString() != "")
                            {
                                SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                            }
                            // Update active to 0
                            DataTable dtx = objfab.MAILUPDATE("UPDATESTATUS", Convert.ToInt32(dtRow["MeetingSchedule_Id"].ToString()));
                        }
                    }

                }
            }
            //--------------------------------------------------------------------------------------------------


            ////DataTable dtdaily_Normal = objfab.MeetingDaily("MAILSAVESSCHEDULER", 0);
            //if (dtdaily_Normal.Rows.Count > 0)
            //{
            //    int days = DateTime.Now.Day;
            //    days = days + 1;
            //    DateTime Todaydate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days);
            //    int dayss = 0;
            //    foreach (DataRow dtRow in dtdaily_Normal.Rows)
            //    {
            //        if (dtRow["MeetingCategory_Id"].ToString() == "2")
            //        {
            //            MailType = "Monthly Meeting";

            //        }
            //        else if (dtRow["MeetingCategory_Id"].ToString() == "3")
            //        {
            //            MailType = "Quarterly Meeting";
            //        }
            //        else if (dtRow["MeetingCategory_Id"].ToString() == "4")
            //        {
            //            MailType = "Weekly Meeting";
            //        }
            //        else if (dtRow["MeetingCategory_Id"].ToString() == "5")
            //        {
            //            MailType = "Yearly Meeting";
            //        }

            //        string Manual_Day = dtRow["Manual_Day"].ToString();
            //        string Manual_Time = dtRow["Manual_Time"].ToString();
            //        string EmailContent = dtRow["Description"].ToString();

            //        string user_Day = dtRow["Day"].ToString();

            //        string Daily_Time = dtRow["Time"].ToString();
            //        if (Convert.ToBoolean(dtRow["IsManual"].ToString()) == true)
            //        {
            //            DateTime ExistsDateDaily = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(Manual_Day));
            //            if (dtRow["MeetingCategory_Id"].ToString() == "4")
            //            {
            //                string TodayDayWeekName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days).ToString("dddd");
            //                string ExistsDayWeekName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(Manual_Day)).ToString("dddd");
            //                if (TodayDayWeekName == ExistsDayWeekName)
            //                {
            //                    MailType = MailType + " Scheduled On " + Convert.ToInt32(Manual_Day) + "" + AddOrdinal(Convert.ToInt32(Manual_Day)) + "" + ExistsDayWeekName + " at " + dtRow["Manual_Time"].ToString();
            //                    EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'>  on dated </span>" + " <b>" + Todaydate.ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'>  at time </span>" + "<b> " + Manual_Time + "</b> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
            //                              "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

            //                    if (dtRow["Participate"].ToString() != "")
            //                    {
            //                        SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
            //                    }
            //                }
            //            }
            //            else
            //            {


            //                if (Todaydate == ExistsDateDaily)
            //                {


            //                    MailType = MailType + " Scheduled On " + Convert.ToInt32(Manual_Day) + "" + AddOrdinal(Convert.ToInt32(Manual_Day)) + " " + GetmonthName(Convert.ToInt32(dtRow["Day"].ToString())) + " at " + dtRow["Manual_Time"].ToString();
            //                    EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'> on dated</span> " + "<b> " + ExistsDateDaily.ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'> at time</span> " + "<b> " + Manual_Time + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
            //                              "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";


            //                    if (dtRow["Participate"].ToString() != "")
            //                    {
            //                        SendClientRegistrationEmail("Abhishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
            //                    }
            //                }

            //            }
            //        }
            //        else
            //        {
            //            if (dtRow["MeetingCategory_Id"].ToString() == "4")
            //            {
            //                string TodayDayWeekName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days).ToString("dddd");
            //                string ExistsDayWeekName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(user_Day)).ToString("dddd");
            //                if (TodayDayWeekName == ExistsDayWeekName)
            //                {
            //                    MailType = MailType + " Scheduled On " + Convert.ToInt32(user_Day) + "" + AddOrdinal(Convert.ToInt32(user_Day)) + "" + ExistsDayWeekName + " at " + dtRow["Time"].ToString();
            //                    EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'> on dated </span>" + "<b> " + Todaydate.ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'> at time</span> " + "<b> " + dtRow["Time"].ToString() + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
            //                              "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-family:arial; font-size:12px;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

            //                    if (dtRow["Participate"].ToString() != "")
            //                    {
            //                        SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                DateTime ExistsDateDaily = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(dtRow["Day"].ToString()));
            //                if (Todaydate == ExistsDateDaily)
            //                {
            //                    MailType = MailType + " Scheduled On " + Convert.ToInt32(dtRow["Day"].ToString()) + "" + AddOrdinal(Convert.ToInt32(dtRow["Day"].ToString())) + " " + GetmonthName(DateTime.Now.Month) + " at " + Daily_Time;
            //                    EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'>&nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + " " + dtRow["MeetingName"].ToString() + " on dated " + " " + ExistsDateDaily.ToString("dd MMM yy (ddd)") + " at time " + " " + Daily_Time + "</b><br><span style='color:#524848'>  &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
            //                              "</span><br><span style='color:#524848'>&nbsp;&nbsp;&nbsp; Please join the meeting 5 minutes before.</span></div><br><div style='font-family:arial; font-size:12px;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail." + "</div><div style='font-family:arial; font-size:12px'><br><br>" + "<strong>Thanks & Best Regards</strong>  <br> Team BIPL " + "</div>";

            //                    if (dtRow["Participate"].ToString() != "")
            //                    {
            //                        SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
            //                    }
            //                }
            //            }
            //        }

            //    }
            //}
        }
        public void MailsSave(DataTable dt)
        {
            //======Daily===============================================================================
            int MeetingScheduleId = 0;
            if (dt.Rows.Count > 0)
                MeetingScheduleId = Convert.ToInt32(dt.Rows[0]["MeetingSchedule_Id"].ToString());

            Mailscheduler(dt);

            DataTable dtdaily = objfab.MeetingDaily("MAILSAVE", MeetingScheduleId);
            if (dtdaily.Rows.Count > 0)
            {
                int days = DateTime.Now.Day;


                foreach (DataRow dtRow in dtdaily.Rows)
                {
                    MailType = dtRow["MeetingName"].ToString();
                    //if (dtRow["MeetingCategory_Id"].ToString() == "2")
                    //{
                    //    MailType = "Monthly Meeting";

                    //}
                    //else if (dtRow["MeetingCategory_Id"].ToString() == "3")
                    //{
                    //    MailType = "Quarterly Meeting";
                    //}
                    //else if (dtRow["MeetingCategory_Id"].ToString() == "4")
                    //{
                    //    MailType = "Weekly Meeting ";
                    //}
                    //else if (dtRow["MeetingCategory_Id"].ToString() == "5")
                    //{
                    //    MailType = "Yearly Meeting";
                    //}


                    string EmailContent = dtRow["Description"].ToString();

                    string Daily_Time = dtRow["Time"].ToString();
                    if (Convert.ToBoolean(dtRow["IsManual"].ToString()) == true)
                    {
                        int Manual_Day = Convert.ToInt32(dtRow["Manual_Day"].ToString());

                        string Manual_Time = dtRow["Manual_Time"].ToString();
                        if (dtRow["MeetingCategory_Id"].ToString() == "4")
                        {


                            string TodayDayWeekName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days).ToString("dddd");
                            // string ExistsDayWeekName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(Manual_Day)).ToString("dddd");
                            string ExistsDayWeekName = GetWeekName(Convert.ToInt32(Manual_Day));
                            if (TodayDayWeekName == ExistsDayWeekName)
                            {
                                DateTime Todaydate = DateTime.Now;
                                DateTime t1 = DateTime.Parse("2012/12/12 " + Manual_Time);
                                DateTime t2 = DateTime.Parse("2012/12/12 " + DateTime.Now.ToString("hh:mm tt"));

                                if (t1.TimeOfDay > t2.TimeOfDay)
                                {
                                    //something
                                    Todaydate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days);
                                }
                                else
                                {
                                    // Manual_Day = Manual_Day + 1;
                                    Todaydate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days).AddDays(7);

                                }
                                if (EmailDate(Todaydate.AddDays(-1)) != Todaydate)
                                {
                                    Todaydate = EmailDate(Todaydate);
                                }
                                MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + "" + EmailDate(Todaydate.AddDays(-1)).ToString("dd MMM yy (ddd)") + " at " + dtRow["Manual_Time"].ToString();
                                EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'> on dated </span>" + "<b> " + EmailDate(Todaydate.AddDays(-1)).ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'> at time </span>" + "<b> " + Manual_Time + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                          "</span><br><span style='color:#524848'>&nbsp;&nbsp;&nbsp; Please join the meeting 5 minutes before.</span></div><br><div style='font-family:arial; font-size:12px;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

                                if (dtRow["Participate"].ToString() != "")
                                {
                                    SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                                }
                            }
                        }
                        else
                        {
                            DateTime Todaydate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days);
                            DateTime ExistsDateDaily = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(dtRow["Manual_Day"].ToString()));
                            if (Todaydate == ExistsDateDaily)
                            {
                                DateTime t1 = DateTime.Parse("2012/12/12 " + dtRow["Manual_Time"].ToString());
                                DateTime t2 = DateTime.Parse("2012/12/12 " + DateTime.Now.ToString("hh:mm tt"));

                                if (t1.TimeOfDay > t2.TimeOfDay)
                                {
                                    if (dtRow["MeetingCategory_Id"].ToString() == "3")
                                    {
                                        if (GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Manual_Month"].ToString())) != DateTime.Now.Month)
                                            return;
                                    }
                                    //Yearly Meeting
                                    if (dtRow["MeetingCategory_Id"].ToString() == "5")
                                    {
                                        if (Convert.ToInt32(dtRow["Manual_Month"].ToString()) != DateTime.Now.Month)
                                            return;
                                    }
                                    if (dtRow["MeetingCategory_Id"].ToString() == "2" || dtRow["MeetingCategory_Id"].ToString() == "3" || dtRow["MeetingCategory_Id"].ToString() == "5")
                                    {
                                        ExistsDateDaily = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(days));
                                        if (EmailDate(ExistsDateDaily.AddDays(-1)) != ExistsDateDaily)
                                        {
                                            ExistsDateDaily = EmailDate(ExistsDateDaily);
                                        }
                                        MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + ExistsDateDaily.ToString("dd MMM yy (ddd)") + " at " + dtRow["Manual_Time"].ToString();
                                        EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'> on dated </span>" + " <b>" + ExistsDateDaily.ToString("dd MMM yy (ddd)") + " at time " + " " + dtRow["Manual_Time"].ToString() + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                                  "</span><br><span style='color:#524848'>&nbsp;&nbsp;&nbsp; Please join the meeting 5 minutes before.</span></div><br><div style='font-family:arial; font-size:12px;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards</strong>  <br> Team BIPL " + "</div>";

                                        if (dtRow["Participate"].ToString() != "")
                                        {
                                            SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                                        }
                                    }
                                }
                                else
                                {
                                    if (dtRow["MeetingCategory_Id"].ToString() == "2")
                                    {

                                        ExistsDateDaily = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(days)).AddMonths(1);
                                        if (EmailDate(ExistsDateDaily.AddDays(-1)) != ExistsDateDaily)
                                        {
                                            ExistsDateDaily = EmailDate(ExistsDateDaily);
                                        }

                                        MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + EmailDate(ExistsDateDaily.AddDays(-1)).ToString("dd MMM yy (ddd)") + " at " + dtRow["Manual_Time"].ToString();
                                        EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'> on dated </span>" + " <b>" + EmailDate(ExistsDateDaily.AddDays(-1)).ToString("dd MMM yy (ddd)") + " at time " + " " + dtRow["Manual_Time"].ToString() + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                                    "</span><br><span style='color:#524848'>&nbsp;&nbsp;&nbsp; Please join the meeting 5 minutes before.</span></div><br><div style='font-family:arial; font-size:12px;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards</strong>  <br> Team BIPL " + "</div>";

                                        if (dtRow["Participate"].ToString() != "")
                                        {
                                            SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                                        }
                                    }
                                    else if (dtRow["MeetingCategory_Id"].ToString() == "3")
                                    {
                                        if (GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Manual_Month"].ToString())) != DateTime.Now.Month)
                                            return;

                                        //if (DateTime.Now.Month > 3 && GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Manual_Month"].ToString())) >= 1 && GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Manual_Month"].ToString())) <= 3)
                                        //{
                                        //    ExistsDateDaily = new DateTime(DateTime.Now.Year + 1, GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Manual_Month"].ToString())) + 3, Convert.ToInt32(days));
                                        //}
                                        //else
                                        //{
                                        //    ExistsDateDaily = new DateTime(DateTime.Now.Year, GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Manual_Month"].ToString())) + 3, Convert.ToInt32(days));
                                        //}
                                        //if (EmailDate(ExistsDateDaily.AddDays(-1)) != ExistsDateDaily)
                                        //{
                                        //    ExistsDateDaily = EmailDate(ExistsDateDaily);
                                        //}


                                        if (DateTime.Now.Month > 3 && GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Manual_Month"].ToString())) >= 1 && GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Manual_Month"].ToString())) <= 3)
                                        {
                                            ExistsDateDaily = new DateTime(DateTime.Now.Year + 1, GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Manual_Month"].ToString())) + 3, Convert.ToInt32(dtRow["Manual_Day"].ToString()));
                                        }
                                        else
                                        {
                                            ExistsDateDaily = new DateTime(DateTime.Now.Year, GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Manual_Month"].ToString())), Convert.ToInt32(dtRow["Manual_Day"].ToString()));
                                        }

                                        t1 = DateTime.Parse("2012/12/12 " + dtRow["Manual_Time"].ToString());
                                        t2 = DateTime.Parse("2012/12/12 " + DateTime.Now.ToString("hh:mm tt"));

                                        if (t1.TimeOfDay < t2.TimeOfDay)
                                        {
                                            ExistsDateDaily = ExistsDateDaily.AddMonths(3);
                                        }


                                        MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + EmailDate(ExistsDateDaily.AddDays(-1)).ToString("dd MMM yy (ddd)") + " at " + dtRow["Manual_Time"].ToString();
                                        EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'> on dated </span>" + " <b>" + EmailDate(ExistsDateDaily.AddDays(-1)).ToString("dd MMM yy (ddd)") + " at time " + " " + dtRow["Manual_Time"].ToString() + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                                  "</span><br><span style='color:#524848'>&nbsp;&nbsp;&nbsp; Please join the meeting 5 minutes before.</span></div><br><div style='font-family:arial; font-size:12px;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards</strong>  <br> Team BIPL " + "</div>";

                                        if (dtRow["Participate"].ToString() != "")
                                        {
                                            SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                                        }

                                    }

                                    //else if (dtRow["MeetingCategory_Id"].ToString() == "4")
                                    //{
                                    //    MailType = "Weekly Meeting ";
                                    //}
                                    else if (dtRow["MeetingCategory_Id"].ToString() == "5")
                                    {
                                        //Yearly Meeting
                                        if (Convert.ToInt32(dtRow["Manual_Month"].ToString()) != DateTime.Now.Month)
                                            return;
                                        ExistsDateDaily = new DateTime(DateTime.Now.Year + 1, Convert.ToInt32(dtRow["Manual_Month"].ToString()), Convert.ToInt32(days));
                                        if (EmailDate(ExistsDateDaily.AddDays(-1)) != ExistsDateDaily)
                                        {
                                            ExistsDateDaily = EmailDate(ExistsDateDaily);
                                        }
                                        MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + EmailDate(ExistsDateDaily.AddDays(-1)).ToString("dd MMM yy (ddd)") + " at " + dtRow["Manual_Time"].ToString();
                                        EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'> on dated </span>" + " <b>" + EmailDate(ExistsDateDaily.AddDays(-1)).ToString("dd MMM yy (ddd)") + " at time " + " " + dtRow["Manual_Time"].ToString() + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                                  "</span><br><span style='color:#524848'>&nbsp;&nbsp;&nbsp; Please join the meeting 5 minutes before.</span></div><br><div style='font-family:arial; font-size:12px;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards</strong>  <br> Team BIPL " + "</div>";

                                        if (dtRow["Participate"].ToString() != "")
                                        {
                                            SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                                        }

                                    }

                                }
                                //Todaydate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days);
                                // ExistsDateDaily = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days);
                            }
                        }
                    }
                    else
                    {
                        // OneTimeOnly Mails

                        if (dtRow["MeetingCategory_Id"].ToString() == "6")
                        {
                            int Days = DateTime.Now.Day;
                            if (Convert.ToBoolean(dtRow["IsManual"].ToString()) == false)
                            {
                                int Years = Convert.ToInt32(dtRow["Years"].ToString());
                                int Month = Convert.ToInt32(dtRow["Month"].ToString());
                                int Day = Convert.ToInt32(dtRow["Day"].ToString());
                                string Time = dtRow["Time"].ToString();

                                DateTime ExistsDate = new DateTime(Years, Month, Day);
                                
                                DateTime NextdayTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                                NextdayTime = EmailDate(NextdayTime);

                                if (ExistsDate == NextdayTime.AddDays(-1))
                                {
                                    DateTime Todaydate = DateTime.Now;

                                    DateTime UserTime = new DateTime(Years, Month, Day);
                                    DateTime CurrentTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

                                    DateTime t1 = DateTime.Parse("2012/12/12 " + Time);
                                    DateTime t2 = DateTime.Parse("2012/12/12 " + DateTime.Now.ToString("hh:mm tt"));



                                    if (UserTime == CurrentTime)
                                    {
                                        if (t1 >= t2)
                                        {
                                            
                                            UserTime = EmailDate(UserTime).AddDays(-1);
                                            MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + UserTime.ToString("dd MMM yy (ddd)") + " at " + dtRow["Time"].ToString();
                                            EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'>  on dated </span>" + " <b>" + UserTime.ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'>  at time </span>" + "<b> " + dtRow["Time"].ToString() + "</b> <br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                                            "</span><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;Please join the meeting 5 minutes before.</span></div><br><div style='font-size:12px;font-family:arial;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

                                            if (dtRow["Participate"].ToString() != "")
                                            {
                                                SendClientRegistrationEmail("abhishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                                            }
                                            // Update active to 0
                                            DataTable dtx = objfab.MAILUPDATE("UPDATESTATUS", Convert.ToInt32(dtRow["MeetingSchedule_Id"].ToString()));
                                        }
                                    }
                                }

                            }
                            return;
                        }
                        if (dtRow["MeetingCategory_Id"].ToString() == "4")
                        {
                            string TodayDayWeekName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days).ToString("dddd");
                            //string ExistsDayWeekName = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(dtRow["Day"].ToString())).ToString("dddd");
                            string ExistsDayWeekName = GetWeekName(Convert.ToInt32(dtRow["Day"].ToString()));
                            if (TodayDayWeekName == ExistsDayWeekName)
                            {
                                DateTime t1 = DateTime.Parse("2012/12/12 " + dtRow["Time"].ToString());
                                DateTime t2 = DateTime.Parse("2012/12/12 " + DateTime.Now.ToString("hh:mm tt"));
                                DateTime Todaydate = DateTime.Now;
                                if (t1.TimeOfDay > t2.TimeOfDay)
                                {
                                    //something
                                    Todaydate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days);
                                }
                                else
                                {
                                    // Manual_Day = Manual_Day + 1;
                                    Todaydate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days).AddDays(7);

                                }

                                if (EmailDate(Todaydate.AddDays(-1)) != Todaydate)
                                {
                                    Todaydate = EmailDate(Todaydate);
                                }
                                MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + "" + EmailDate(Todaydate.AddDays(-1)).ToString("dd MMM yy (ddd)") + " at " + dtRow["Time"].ToString();
                                EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'> on dated </span>" + "<b> " + EmailDate(Todaydate.AddDays(-1)).ToString("dd MMM yy (ddd)") + "</b><span style='color:#524848'> at time</span> " + " <b>" + dtRow["Time"].ToString() + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                          "</span><br><span style='color:#524848'>&nbsp;&nbsp;&nbsp; Please join the meeting 5 minutes before.</span></div><br><div style='font-family:arial; font-size:12px;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div>" + "<strong>Thanks & Best Regards </strong> <br> Team BIPL " + "</div>";

                                if (dtRow["Participate"].ToString() != "")
                                {
                                    SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                                }
                            }
                        }
                        else
                        {
                            DateTime Todaydate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days);
                            DateTime ExistsDateDaily = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(dtRow["Day"].ToString()));
                            if (Todaydate == ExistsDateDaily)
                            {
                                DateTime t1 = DateTime.Parse("2012/12/12 " + dtRow["Time"].ToString());
                                DateTime t2 = DateTime.Parse("2012/12/12 " + DateTime.Now.ToString("hh:mm tt"));

                                if (t1.TimeOfDay > t2.TimeOfDay)
                                {
                                    if (dtRow["MeetingCategory_Id"].ToString() == "3")
                                    {
                                        if (GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Month"].ToString())) != DateTime.Now.Month)
                                            return;
                                    }
                                    //Yearly Meeting
                                    if (dtRow["MeetingCategory_Id"].ToString() == "5")
                                    {
                                        if (Convert.ToInt32(dtRow["Month"].ToString()) != DateTime.Now.Month)
                                            return;


                                    }
                                    if (EmailDate(ExistsDateDaily.AddDays(-1)) != ExistsDateDaily)
                                    {
                                        ExistsDateDaily = EmailDate(ExistsDateDaily);
                                    }
                                    MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + ExistsDateDaily.ToString("dd MMM yy (ddd)") + " at " + dtRow["Time"].ToString();
                                    EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'> on dated </span>" + " <b>" + ExistsDateDaily.ToString("dd MMM yy (ddd)") + " at time " + " " + dtRow["Time"].ToString() + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                                "</span><br><span style='color:#524848'>&nbsp;&nbsp;&nbsp; Please join the meeting 5 minutes before.</span></div><br><div style='font-family:arial; font-size:12px;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards</strong>  <br> Team BIPL " + "</div>";

                                    if (dtRow["Participate"].ToString() != "")
                                    {
                                        SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                                    }

                                }
                                else
                                {
                                    if (dtRow["MeetingCategory_Id"].ToString() == "2")
                                    {

                                        ExistsDateDaily = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(days)).AddMonths(1);
                                        if (EmailDate(ExistsDateDaily.AddDays(-1)) != ExistsDateDaily)
                                        {
                                            ExistsDateDaily = EmailDate(ExistsDateDaily);
                                        }

                                        MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + EmailDate(ExistsDateDaily.AddDays(-1)).ToString("dd MMM yy (ddd)") + " at " + dtRow["Time"].ToString();
                                        EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'> on dated </span>" + " <b>" + EmailDate(ExistsDateDaily.AddDays(-1)).ToString("dd MMM yy (ddd)") + " at time " + " " + dtRow["Time"].ToString() + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                                  "</span><br><span style='color:#524848'>&nbsp;&nbsp;&nbsp; Please join the meeting 5 minutes before.</span></div><br><div style='font-family:arial; font-size:12px;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards</strong>  <br> Team BIPL " + "</div>";

                                        if (dtRow["Participate"].ToString() != "")
                                        {
                                            SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                                        }


                                    }
                                    else if (dtRow["MeetingCategory_Id"].ToString() == "3")
                                    {
                                        if (GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Month"].ToString())) != DateTime.Now.Month)
                                            return;

                                        if (DateTime.Now.Month > 3 && GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Month"].ToString())) >= 1 && GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Month"].ToString())) <= 3)
                                        {
                                            ExistsDateDaily = new DateTime(DateTime.Now.Year + 1, GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Month"].ToString())) + 3, Convert.ToInt32(dtRow["Day"].ToString()));
                                        }
                                        else
                                        {
                                            ExistsDateDaily = new DateTime(DateTime.Now.Year, GetQuarter(DateTime.Now, Convert.ToInt32(dtRow["Month"].ToString())), Convert.ToInt32(dtRow["Day"].ToString()));
                                        }

                                        t1 = DateTime.Parse("2012/12/12 " + dtRow["Time"].ToString());
                                        t2 = DateTime.Parse("2012/12/12 " + DateTime.Now.ToString("hh:mm tt"));

                                        if (t1.TimeOfDay < t2.TimeOfDay)
                                        {
                                            ExistsDateDaily = ExistsDateDaily.AddMonths(3);
                                        }



                                        if (EmailDate(ExistsDateDaily.AddDays(-1)) != ExistsDateDaily)
                                        {
                                            ExistsDateDaily = EmailDate(ExistsDateDaily);
                                        }
                                        MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + EmailDate(ExistsDateDaily.AddDays(-1)).ToString("dd MMM yy (ddd)") + " at " + dtRow["Time"].ToString();
                                        EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'> on dated </span>" + " <b>" + EmailDate(ExistsDateDaily.AddDays(-1)).ToString("dd MMM yy (ddd)") + " at time " + " " + dtRow["Time"].ToString() + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                                      "</span><br><span style='color:#524848'>&nbsp;&nbsp;&nbsp; Please join the meeting 5 minutes before.</span></div><br><div style='font-family:arial; font-size:12px;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards</strong>  <br> Team BIPL " + "</div>";

                                        if (dtRow["Participate"].ToString() != "")
                                        {
                                            SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                                        }

                                    }

                                    else if (dtRow["MeetingCategory_Id"].ToString() == "5")
                                    {
                                        //Yearly Meeting
                                        if (Convert.ToInt32(dtRow["Month"].ToString()) != DateTime.Now.Month)
                                            return;
                                        ExistsDateDaily = new DateTime(DateTime.Now.Year, Convert.ToInt32(dtRow["Month"].ToString()), Convert.ToInt32(days)).AddYears(1);


                                        if (EmailDate(ExistsDateDaily.AddDays(-1)) != ExistsDateDaily)
                                        {
                                            ExistsDateDaily = EmailDate(ExistsDateDaily);
                                        }
                                        MailType = dtRow["MeetingName"].ToString() + " Scheduled On " + EmailDate(ExistsDateDaily.AddDays(-1)).ToString("dd MMM yy (ddd)") + " at " + dtRow["Time"].ToString();
                                        EmailContent = "<div style='font-family:arial; font-size:12px'>Dear BIPL Team ,<br><br><span style='position:reltive;left:5%;color:#524848'> &nbsp;&nbsp;&nbsp;You are invited to the meeting</span>" + "<b> " + dtRow["MeetingName"].ToString() + "</b><span style='color:#524848'> on dated </span>" + " <b>" + EmailDate(ExistsDateDaily.AddDays(-1)).ToString("dd MMM yy (ddd)") + " at time " + " " + dtRow["Time"].ToString() + "</b><br><span style='color:#524848'> &nbsp;&nbsp;&nbsp;" + dtRow["Description"].ToString() +
                                                      "</span><br><span style='color:#524848'>&nbsp;&nbsp;&nbsp; Please join the meeting 5 minutes before.</span></div><br><div style='font-family:arial; font-size:12px;color:blue'>" + "&nbsp;&nbsp;&nbsp; This is system generated mail. Please do not reply on this mail.<br><br>" + "</div><div style='font-family:arial; font-size:12px'>" + "<strong>Thanks & Best Regards</strong>  <br> Team BIPL " + "</div>";

                                        if (dtRow["Participate"].ToString() != "")
                                        {
                                            SendClientRegistrationEmail("Abishek", "", EmailContent, MailType, dtRow["Participate"].ToString());
                                        }
                                        //}
                                    }

                                }
                            }
                        }
                    }

                }
            }
        }

        public int GetQuarter(DateTime date, int Mnth)
        {
            if (date.Month >= 4 && date.Month <= 6)
            {
                if (Mnth == 1)
                { return 4; }
                else if (Mnth == 2)
                { return 5; }
                else if (Mnth == 3)
                { return 6; }
                else return 0;
            }
            else if (date.Month >= 7 && date.Month <= 9)
            {
                if (Mnth == 1)
                { return 7; }
                else if (Mnth == 2)
                { return 8; }
                else if (Mnth == 3)
                { return 9; }
                else return 0;
            }

            else if (date.Month >= 10 && date.Month <= 12)
            {
                if (Mnth == 1)
                { return 10; }
                else if (Mnth == 2)
                { return 11; }
                else if (Mnth == 3)
                { return 12; }
                else return 0;
            }
            else
            {
                if (Mnth == 1)
                { return 1; }
                else if (Mnth == 2)
                { return 2; }
                else if (Mnth == 3)
                { return 3; }
                else return 0;
            }
        }
        public void UpdateManual()
        {
            DataTable dtdaily = objfab.MeetingDaily("GETSINGLE", 0);
            foreach (DataRow dtRow in dtdaily.Rows)
            {
                int days = DateTime.Now.Day;
                DateTime Todaydate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, days);
                DateTime Checkdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, Convert.ToInt32(dtRow["Manual_Day"].ToString()));
                if (Checkdate < Todaydate)
                {
                    DataTable dtx = objfab.MAILUPDATE("MAILUPDATE", Convert.ToInt32(dtRow["MeetingSchedule_Id"].ToString()));
                }
            }
        }
        public Boolean SendClientRegistrationEmail(String ClientName, String UsernamePasswordList, String ToEmail, string MailType, string MailToList)
        {
            try
            {
                String fromName = BLLCache.GetConfigurationKeyValue("FROMEMAIL");
                List<String> to = new List<String>();

                NotificationController objcontroller = new NotificationController();
                if (MailToList != "")
                {
                    string[] struser = MailToList.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string x in struser)
                    {
                        myCollection.Add(x);

                    }
                }
                List<string> distinct = myCollection.Distinct().ToList();
                foreach (string em in distinct)
                {
                    if (em.Contains("@"))
                    {
                        to.Add(em);
                    }
                    else
                    {
                        foreach (User xx in Users)
                        {
                            if (em.Trim().ToLower() == xx.FullName.ToLower())
                            {
                                to.Add(xx.Email);
                            }
                        }
                    }
                }
                this.SendEmail(fromName, to, null, null, ToEmail, MailType, null, false, false);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                return false;
            }
        }
        public DateTime EmailDate(DateTime tme)
        {
            DataTable dtx = objfab.MeetingHolidayCheck("HOLIDAYCHECK", tme);
            return Convert.ToDateTime(dtx.Rows[0]["EmailDay"].ToString());
        }
        
        public string EmailDateCheckIsEvent(DateTime tme)
        {
            string ss = "";
            DataTable dtx = objfab.MeetingHolidayCheck("HOLIDAYCHECK2", tme);
            if (dtx.Rows.Count > 0)
            {
                ss = dtx.Rows[0]["Result"].ToString();
            }
            else
            {
                ss = "";
            }
            return ss;
        }
        protected void grdparticipaint_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label lblname = (Label)e.Row.FindControl("lblname");
            }
        }
        protected void grdparticipaint_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {

                var value = e.CommandArgument;


                GridViewRow gvr = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                gvr.Attributes.Add("Class", "selected_row");
                Label lblParticipants = (Label)gvr.FindControl("lblParticipants");
                HiddenField hdnMeetingSchedule_Id = (HiddenField)gvr.FindControl("hdnMeetingSchedule_Id");
                //txtparticipante.Text = lblParticipants.Text;
                //MeetingScheduleId = Convert.ToInt32(hdnMeetingSchedule_Id.Value);
                //BindEditTable();
            }

        }
        // Updated on 18 feb 2020
        public DateTime CheckDayExistsInMonth(int day)
        {
            DateTime returndate = DateTime.Now; 
            DateTime now = DateTime.Now;
            DateTime startDate = new DateTime(now.Year, now.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            //DateTime Todaydate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            if (day <= endDate.Day)
            {
                returndate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
            }
            else
            {
                returndate = endDate;
            }
            return returndate; 
        }
        // end of Updated on 18 feb 2020
        protected void grdparticipaint_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)grdparticipaint.Rows[e.RowIndex];
            Label lblname = (Label)row.FindControl("lblname");

            myCollection.Clear();
            string[] struser = hdnuserlist.Value.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string x in struser)
            {
                myCollection.Add(x);
            }
            myCollection = myCollection.Distinct().ToList();
            foreach (string em in myCollection)
            {
                if (em.ToLower().Trim() == lblname.Text.ToLower().Trim())
                {
                    myCollection.Remove(lblname.Text.Trim());
                    hdnuserlist.Value = "";
                    foreach (string xx in myCollection)
                        hdnuserlist.Value = hdnuserlist.Value + xx + ",";

                    grdparticipaint.DataSource = myCollection;
                    grdparticipaint.DataBind();

                    int i = 1;
                    string strhtml = "";
                    foreach (string x in myCollection)
                    {
                        strhtml = strhtml + i + ". " + x + @"<br /> ";
                        i++;
                    }
                    lbluserlist.Text = strhtml;
                    txtparticipante.Text = strhtml;
                    break;
                }
            }

        }
        
        protected void grdMeetingsbipl_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)grdMeetingsbipl.Rows[e.RowIndex];
            Label lblname = (Label)row.FindControl("lblname");
            HiddenField hdnMeetingSchedule_Id = (HiddenField)row.FindControl("hdnMeetingSchedule_Id");
            DataTable dtx = objfab.MAILUPDATE("DELETE", Convert.ToInt32(hdnMeetingSchedule_Id.Value));
            Response.Redirect(Request.RawUrl);
        }
        public Boolean SendEmail(String FromEmail, List<String> To, List<String> CC, List<String> BCC, String Subject, String Content, List<Attachment> Attachments, Boolean hasAppendAttachment, Boolean isAsync)
        {

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(FromEmail);
            mailMessage.ReplyTo = new MailAddress(FromEmail);
            mailMessage.Priority = MailPriority.Normal;
            mailMessage.Subject = MailType;
            mailMessage.IsBodyHtml = true;


            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Subject, null, "text/html");
            mailMessage.AlternateViews.Add(htmlView);

            //if (hasAppendAttachment && Attachments != null)
            //{
            //    int i = 1;
            //    foreach (Attachment attachment in Attachments)
            //    {
            //        if (attachment.ContentStream.Length > 0)
            //        {
            //            LinkedResource imageId = new LinkedResource(attachment.ContentStream, "image/jpeg");
            //            imageId.ContentId = "imageId" + i.ToString();
            //            imageId.TransferEncoding = System.Net.Mime.TransferEncoding.Base64;
            //            htmlView.LinkedResources.Add(imageId);
            //        }

            //        i++;
            //    }
            //}
            //else
            //{
            //    mailMessage.Body = Subject;
            //}
            mailMessage.Body = Subject;
            Boolean isDebug = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["isDebug"]);

            if (isDebug)
            {
                // TODO
                mailMessage.To.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
                mailMessage.Bcc.Add(Constants.WEBMASTER_EMAIL);
            }
            else
            {
                foreach (String to in To)
                    mailMessage.To.Add(to);

                if (CC != null)
                    foreach (String to in CC)
                        mailMessage.CC.Add(to);

                if (BCC != null)
                    foreach (String to in BCC)
                        mailMessage.Bcc.Add(to);


                mailMessage.Bcc.Add(System.Configuration.ConfigurationManager.AppSettings["debugModeEmailId"]);
            }
            SmtpClient smtpClient = new SmtpClient(Constants.SMTP_HOST, Constants.SMTP_PORT);

            if (!hasAppendAttachment && Attachments != null)
            {
                foreach (Attachment att in Attachments)
                {
                    mailMessage.Attachments.Add(att);
                }
            }

            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Timeout = Constants.SMTP_TIMEOUT;

            if (Constants.SMTP_SECURE)
            {
                smtpClient.EnableSsl = true;
            }

            if (Constants.SMTP_IS_AUTH_REQUIRED)
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(Constants.SMTP_USERNAME, Constants.SMTP_PASSWORD);
            }
            try
            {
                smtpClient.Timeout = 300000;
                smtpClient.Send(mailMessage);
                System.Diagnostics.Trace.WriteLine("Email Having Subject of --" + Subject.ToString() + " is send successfully on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");

                return true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Some error has been occur in Email having subject of ---" + Subject.ToString() + " On" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                System.Diagnostics.Trace.WriteLine("Sorry !! Email has not been send on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt") + "\n");
                return false;
            }

            finally
            {
                try
                {
                    if (Attachments != null)
                    {
                        foreach (Attachment att in Attachments)
                        {
                            att.Dispose();
                        }

                        Attachments = null;
                    }

                    foreach (Attachment att in mailMessage.Attachments)
                    {
                        att.Dispose();
                    }

                    mailMessage = null;

                }
                catch (Exception ex) {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
        }


    }

}