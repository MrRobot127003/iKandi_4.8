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
using System.Collections.Generic;
using iKandi.Web.Components;
using iKandi.Common;

namespace iKandi.Web
{
    public partial class CourierStylesPending : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindControls();
        }

        private void BindControls()
        {     
            
            List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(ApplicationHelper.LoggedInUser.UserData.UserID);

            tasks.Sort(delegate(WorkflowInstanceDetail wfd1, WorkflowInstanceDetail wfd2)
            {
                if (wfd1.WorkflowInstance.Style.Buyer.Equals(wfd2.WorkflowInstance.Style.Buyer))
                {
                    return wfd1.WorkflowInstance.Style.StyleNumber.CompareTo(wfd2.WorkflowInstance.Style.StyleNumber);
                }
                else
                {
                    return wfd1.WorkflowInstance.Style.Buyer.CompareTo(wfd2.WorkflowInstance.Style.Buyer);
                }
            });

           
            List<WorkflowInstanceDetail> pendingTasks = tasks.FindAll(delegate(WorkflowInstanceDetail detail)
            {
                //return (detail.StatusModeID == (int)TaskMode.SAMPLE_SENT && detail.ApplicationModule.ApplicationModuleID == (int)AppModule.DISPATCH_ENTRY_FILE); //
                return (detail.StatusModeID == (int)TaskMode.SAMPLE_SENT); //Gajendra Workflow
            });
 
            grdPendingTasks.DataSource = pendingTasks;
            grdPendingTasks.DataBind();    
       
        }
           

           
            




    }
}