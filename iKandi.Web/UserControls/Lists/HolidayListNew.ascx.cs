using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace iKandi.Web
{
    public partial class HolidayListNew : BaseUserControl
    {
        public bool IsSmall
        {
            get;
            set;
        }

        DataSet ds = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ds = this.LeaveControllerInstance.GetHolidays(DateTime.Now.Month, DateTime.Now.Year);

            smallCalendar.Visible = IsSmall;
            Calendar1.Visible = !IsSmall;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            try
            {
                CalendarDay day = (CalendarDay)e.Day;
                TableCell cell = (TableCell)e.Cell;

                string str = string.Empty;

                if (!day.IsOtherMonth)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DateTime date = Convert.ToDateTime(row["date"]);
                        DateTime tillDate = Convert.ToDateTime(row["tillDate"]);

                        if (day.Date.Day >= date.Day && day.Date.Day <= tillDate.Day)
                        {
                            if (str == string.Empty)
                                str = row["title"].ToString();
                            else
                                str += "<br />" + row["title"];
                        }
                    }

                    if (str != string.Empty)
                    {
                        // Format the Cell
                        cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#F9DDF4");
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        cell.VerticalAlign = VerticalAlign.Middle;

                        // Write some description about day
                        if (!IsSmall)
                            cell.Controls.Add(new LiteralControl("<br />" + str));
                        cell.ToolTip = str.Replace("<br />", ", ").ToUpper();
                    }
                }
            }
            catch (Exception ex) {
                
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

                // this.NotificationControllerInstance.SendErrorEmail(ex.Message + " " + ex.StackTrace);
            }
        }

        protected void smallCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            try
            {
                CalendarDay day = (CalendarDay)e.Day;
                TableCell cell = (TableCell)e.Cell;

                string str = string.Empty;

                if (!day.IsOtherMonth)
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DateTime date = Convert.ToDateTime(row["date"]);
                        DateTime tillDate = Convert.ToDateTime(row["tillDate"]);

                        if (day.Date.Day >= date.Day && day.Date.Day <= tillDate.Day)
                        {
                            if (str == string.Empty)
                                str = row["title"].ToString();
                            else
                                str += "<br />" + row["title"];
                        }
                    }

                    if (str != string.Empty)
                    {
                        // Format the Cell
                        cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#0066ff");
                        cell.ForeColor = System.Drawing.Color.White;
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        cell.VerticalAlign = VerticalAlign.Middle;

                        // Write some description about day
                        if (!IsSmall)
                            cell.Controls.Add(new LiteralControl("<br />" + str));
                        cell.ToolTip = str.Replace("<br />", ", ").ToUpper();
                    }
                }
            }
            catch (Exception ex)
            {

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));

                // this.NotificationControllerInstance.SendErrorEmail(ex.Message + " " + ex.StackTrace);
            }
        }

        protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            ds = this.LeaveControllerInstance.GetHolidays(e.NewDate.Month, e.NewDate.Year);
        }

        protected void ctrlCalendar_SelectionChanged(object sender, EventArgs e)
        {
            //lblCurrentDate.Text = ctrlCalendar.SelectedDate.ToLongDateString();
        }
    }
}