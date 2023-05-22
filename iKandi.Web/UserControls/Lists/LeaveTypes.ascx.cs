using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;

namespace iKandi.Web.UserControls.Lists
{
    public partial class LeaveTypes : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkBtnInsert_Click(object sender, EventArgs e)
        {
            LeaveType leaveType = new LeaveType();

            leaveType.Name = (gvLeaveTypes.FooterRow.FindControl("txtInsertName") as TextBox).Text;
            leaveType.MaxAllowed = Convert.ToInt32((gvLeaveTypes.FooterRow.FindControl("txtInsertMaxAllowed") as TextBox).Text);
            leaveType.CompanyTypeID = Convert.ToInt32((gvLeaveTypes.FooterRow.FindControl("ddlInsertCompanyType") as DropDownList).SelectedValue);

            this.LeaveControllerInstance.InsertLeaveType(leaveType);

            gvLeaveTypes.DataBind();

            (gvLeaveTypes.FooterRow.FindControl("txtInsertName") as TextBox).Text = "";
            (gvLeaveTypes.FooterRow.FindControl("txtInsertMaxAllowed") as TextBox).Text = "";
        }

        protected void lnkBtnInsertCancel_Click(object sender, EventArgs e)
        {
            (gvLeaveTypes.FooterRow.FindControl("txtInsertName") as TextBox).Text = "";
            (gvLeaveTypes.FooterRow.FindControl("txtInsertMaxAllowed") as TextBox).Text = "";
        }
    }
}