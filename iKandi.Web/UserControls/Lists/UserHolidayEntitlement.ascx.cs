using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iKandi.Web
{
    public partial class UserHolidayEntitlement : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
        

            foreach (GridViewRow row in gvUserHolidays.Rows)
            {
                HiddenField hdnId = row.FindControl("hdnUHEID") as HiddenField;
                HiddenField hdnUserID = row.FindControl("hdnUserID") as HiddenField;
                TextBox txtHolidays = row.FindControl("txtHolidays") as TextBox;

                iKandi.Common.UserHolidayEntitlement uhe = new iKandi.Common.UserHolidayEntitlement();

                uhe.ID = Convert.ToInt32(hdnId.Value);
                uhe.User = new iKandi.Common.User();
                uhe.User.UserID = Convert.ToInt32(hdnUserID.Value);

                if (!string.IsNullOrEmpty(txtHolidays.Text))
                    uhe.Holidays = Convert.ToInt32(txtHolidays.Text);
                else
                    uhe.Holidays = 0;

                this.AdminControllerInstance.SaveUserEntitledHolidays(uhe);
            }
        }
    }
}