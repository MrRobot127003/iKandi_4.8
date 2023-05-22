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
using System.Collections.Generic;

namespace iKandi.Web
{
    public partial class LeaveInformation : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        private void BindControls()
        {
            List<Leave> leaves = this.LeaveControllerInstance.GetLeavesRelatedToMe(ApplicationHelper.LoggedInUser.UserData.UserID);
            List<Leave> myLeaves = new List<Leave>();
            List<Leave> pendingLeaves = new List<Leave>();

            foreach (Leave leave in leaves)
            {
                if (leave.Employee.UserID == ApplicationHelper.LoggedInUser.UserData.UserID)
                {
                    myLeaves.Add(leave);
                }
                else
                {
                    pendingLeaves.Add(leave);
                }
            }


            gvMyLeaves.DataSource = myLeaves;
            gvMyLeaves.DataBind();

            gvPendingLeaves.DataSource = pendingLeaves;
            gvPendingLeaves.DataBind();
        }
    }
}