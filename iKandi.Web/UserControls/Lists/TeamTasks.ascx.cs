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
    public partial class TeamTasks : BaseUserControl
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
            //if (ShowTask == 0)
            //    return;
            ListTeamTask listTeamTask = this.UserTaskControllerInstance.GetTeamTasksCount();
            if (listTeamTask != null)
            {
                rptTeamTask.DataSource = listTeamTask;
                rptTeamTask.DataBind();
                long teamtaskcount = (from r in listTeamTask select r.Task_Count).ToList().Sum();
                hfTeamTask.Value = teamtaskcount.ToString();
            }
        }

        protected void rptTeamTask_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            TeamTaskCount ttc = e.Item.DataItem as TeamTaskCount;
            Repeater rpt = e.Item.FindControl("rptTeamSubTask") as Repeater;
            rpt.DataSource = ttc.ListUtc;
            rpt.DataBind();
        }
    }
}