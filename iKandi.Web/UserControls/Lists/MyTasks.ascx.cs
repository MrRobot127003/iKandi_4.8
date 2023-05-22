using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.Web.Components;

namespace iKandi.Web.UserControls.Lists
{
    public partial class MyTasks : BaseUserControl
    {
        public int ShowTask
        {
            get
            {
                if (ApplicationHelper.LoggedInUser.UserData.Designation == Designation.iKandi_Design_Designers)
                    return 0;
                return 1;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        public void BindControls()
        {
            if (ShowTask == 0)
                return;
            ListUserTask usertasks = this.UserTaskControllerInstance.GetUserTasksCount();
            rptMyTask.DataSource = usertasks;
            rptMyTask.DataBind();
            long mytaskcount = (from r in usertasks select r.Task_Count).ToList().Sum();
            hfMyTask.Value = mytaskcount.ToString();
        }
    }
}