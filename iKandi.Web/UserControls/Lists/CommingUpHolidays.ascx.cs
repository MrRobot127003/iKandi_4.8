using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iKandi.Web.UserControls.Lists
{
    public partial class CommingUpHolidays : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvCommingUpHolidays_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            GridViewRow row = e.Row;

            iKandi.Common.Holiday holiday = (e.Row.DataItem as iKandi.Common.Holiday);

            /* Pending */
            if (DateTime.Today.AddDays(2) < holiday.Date)
            {
                e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#01cc01");
                e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#01cc01");
            }

            /* Urgent */
            if (holiday.Date >= DateTime.Today)
            {
                long days = Math.Abs(Microsoft.VisualBasic.DateAndTime.DateDiff(Microsoft.VisualBasic.DateInterval.Day, DateTime.Today, holiday.Date, Microsoft.VisualBasic.FirstDayOfWeek.Sunday, Microsoft.VisualBasic.FirstWeekOfYear.Jan1));
                if (days <= 2)
                {
                    e.Row.Cells[3].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFA500");
                    e.Row.Cells[4].BackColor = System.Drawing.ColorTranslator.FromHtml("#FFA500");
                }
            }
        }
    }
}