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
    public partial class ApplyLeave : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbFrom.Text = DateTime.Now.AddDays(1).ToString("dd MMM yy (ddd)");
                tbTo.Text = DateTime.Now.AddDays(2).ToString("dd MMM yy (ddd)");
                DropdownHelper.BindLeaveTypes(ddlLeaveType, true);
                DropdownHelper.BindLeaveManagers(
                    ddlAppliedTo as ListControl, ApplicationHelper.LoggedInUser.UserData.PrimaryGroupID,
                    ApplicationHelper.LoggedInUser.UserData.CompanyID == 1 ? 12 : 13);
                double balanceLeaves = this.LeaveControllerInstance.GetBalanceLeaves(
                 ApplicationHelper.LoggedInUser.UserData.UserID, Convert.ToInt32(ddlLeaveType.SelectedValue));

                lblBalance.Text = balanceLeaves.ToString();

                lblDays.Text = GetNetLeaves().ToString();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            double reqLeaveCount = GetNetLeaves();
            Leave leave = new Leave()
            {                
                FromDate = DateHelper.ParseDate(tbFrom.Text).Value,
                ToDate = DateHelper.ParseDate(tbTo.Text).Value,
                FromSession = Convert.ToByte(ddlFromSession.SelectedValue),
                ToSession = Convert.ToByte(ddlToSession.SelectedValue),
                NetLeaves = reqLeaveCount,
               
                Reason = tbReason.Text,
                ContactDetails = tbContactDetails.Text,
                Status = LeaveStatus.Pending,
                CC = tbCC.Text
            };

            leave.Type = new LeaveType();
            leave.Employee = new User();
            leave.Employee.UserID = ApplicationHelper.LoggedInUser.UserData.UserID;
            leave.AppliedTo = new User();
            leave.AppliedTo.UserID = Convert.ToInt32(ddlAppliedTo.SelectedValue != string.Empty ? ddlAppliedTo.SelectedValue : "2");
            leave.Type.LeaveTypeID = Convert.ToInt32(ddlLeaveType.SelectedValue);

            long returnValue = this.LeaveControllerInstance.ApplyForLeave(leave);
            if (returnValue > 0)
            {
                pnlSuccessMessage.Visible = true;
                pnlForm.Visible = false;
                pnlErrorMessage.Visible = false;
            }
            else if (returnValue == -101)//total leaves became more than the maximum allowed leaves
            {
                lblErrorMessage.Text = "Sorry! You can NOT take more holidays. Your leave quota is full.";
                pnlErrorMessage.Visible = true;
                pnlForm.Visible = false;
                pnlSuccessMessage.Visible = false;
            }
            else
            {
                lblErrorMessage.Text = "Your Request can not be fulfilled right now , please contact Administrator!";
                pnlErrorMessage.Visible = true;
                pnlForm.Visible = false;
                pnlSuccessMessage.Visible = false;

            }
        }

        private double GetNetLeaves()
        {

            if (string.IsNullOrEmpty(tbFrom.Text) || string.IsNullOrEmpty(tbTo.Text))
                return 0;

            DateTime start = DateHelper.ParseDate(tbFrom.Text).Value;
            DateTime end = DateHelper.ParseDate(tbTo.Text).Value;

            if (end < start)
                return 0;

            int type = Convert.ToInt32(ddlLeaveType.SelectedValue);

            double reqLeaveCount = 0;
            reqLeaveCount = (end - start).Days + 1;
            while (true)
            {
                if (start >  end)
                {
                    break;
                }

                if (ddlLeaveType.SelectedItem.Text != "CompOffLeave" && ddlLeaveType.SelectedItem.Text != "CompOffWork")
                {
                    if (start.DayOfWeek == DayOfWeek.Saturday || start.DayOfWeek == DayOfWeek.Sunday)
                    {
                        bool ikandi = ApplicationHelper.LoggedInUser.UserData.CompanyID == 1;
                        if (ikandi)
                        {
                            if (start.DayOfWeek == DayOfWeek.Saturday || start.DayOfWeek == DayOfWeek.Sunday)
                            {
                                reqLeaveCount--;
                            }
                        }
                        else
                        {
                            if (start.DayOfWeek == DayOfWeek.Sunday)
                            {
                                reqLeaveCount--;
                            }
                        }
                    }
                    else if (this.LeaveControllerInstance.GetHolidays(ApplicationHelper.LoggedInUser.UserData.Company, start.Day, start.Month, start.Year).Tables[0].Rows.Count > 0)
                    {
                        reqLeaveCount--;
                    }
                }
                start = start.AddDays(1);
            }
            byte fromSession = Convert.ToByte(ddlFromSession.SelectedValue);
            byte toSession = Convert.ToByte(ddlToSession.SelectedValue);
            reqLeaveCount = fromSession == 1 ? reqLeaveCount - 0.5 : reqLeaveCount;
            reqLeaveCount = toSession == 0 ? reqLeaveCount - 0.5 : reqLeaveCount;

            if (reqLeaveCount < 0)
                reqLeaveCount = 0;

            return reqLeaveCount;
        }

        protected void ddlLeaveType_SelectedIndexChanged(object sender, EventArgs e)
        {
            double balanceLeaves = this.LeaveControllerInstance.GetBalanceLeaves(
                ApplicationHelper.LoggedInUser.UserData.UserID, Convert.ToInt32(ddlLeaveType.SelectedValue));
            lblBalance.Text = balanceLeaves.ToString();
        }

        protected void ddlToSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDays.Text = GetNetLeaves().ToString();
        }

        protected void ddlFromSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDays.Text = GetNetLeaves().ToString();
        }

        protected void tbTo_TextChanged(object sender, EventArgs e)
        {
            lblDays.Text = GetNetLeaves().ToString();
        }

        protected void tbFrom_TextChanged(object sender, EventArgs e)
        {
            lblDays.Text = GetNetLeaves().ToString();
        }
    }
}