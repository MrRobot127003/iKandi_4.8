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
using iKandi.Common;
using iKandi.Web.Components;

 

namespace iKandi.Web 
{
    public partial class HolidayForm : BaseUserControl 
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            this.LeaveControllerInstance.GetInsertedHolidays(Convert.ToInt32(tbDay.Text), Convert.ToInt32(tbMonth.Text), Convert.ToInt32(tbYear.Text), Convert.ToString(tbTitle.Text)
                , Convert.ToString(tbDescription.Text), Convert.ToInt32(ddlCompany_Id.SelectedValue));
        }

    }
}