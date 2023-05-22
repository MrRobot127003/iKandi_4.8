using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;

namespace iKandi.BLL
{
    public class UserTaskController : BaseController
    {
         #region Ctor(s)

        public UserTaskController()
        {
        }

        public UserTaskController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public int InsertUserTask(UserTask Task)
        {
            return this.UserTaskDataProviderInstance.InsertUserTask(Task);
        }

        public int InsertUserTaskShipment(UserTask Task)
        {
            return this.UserTaskDataProviderInstance.InsertUserTaskShipment(Task);
        }

        public void UpdateCostingUserTask(UserTask Task)
        {
            this.UserTaskDataProviderInstance.UpdateCostingUserTask(Task);
        }

        public void UpdateUserTask(UserTask Task)
        {
            this.UserTaskDataProviderInstance.UpdateUserTask(Task);
        }

        public void UpdateUserTaskForCostingAction(UserTask Task)
        {
            this.UserTaskDataProviderInstance.UpdateUserTaskForCostingAction(Task);
        }


        public List<UserTask> GetAllUserTasks(int Type)
        {
            return this.UserTaskDataProviderInstance.GetAllUserTasks(Type);
        }

        public List<UserTask> GetAllOtherTasks(int taskModeId)
        {
            return this.UserTaskDataProviderInstance.GetAllOtherTasks(taskModeId);
        }

        public System.Data.DataTable GetAllUserReminderTasks(int iUserID)
        {//manisha 1 march 2011
            return this.UserTaskDataProviderInstance.GetAllUserReminderTasks(iUserID);
        }

        public UserTask GetUserTasksByStyleID(int StyleID, UserTaskType Type)
        {
            return this.UserTaskDataProviderInstance.GetUserTasksByStyleID(StyleID, Type);
        }

        public UserTask GetUserCompletedTasksByStyleID(int StyleID, UserTaskType Type)
        {
            return this.UserTaskDataProviderInstance.GetUserCompletedTasksByStyleID(StyleID, Type);
        }

        public UserTask GetUserTasksByOrderID(int OrderID, UserTaskType Type)
        {
            return this.UserTaskDataProviderInstance.GetUserTasksByOrderID(OrderID, Type);
        }

        public UserTask GetUserTasksByOrderDetailID(int OrderDetailID, UserTaskType Type,int DesignationID )
        {
            return this.UserTaskDataProviderInstance.GetUserTasksByOrderDetailID(OrderDetailID, Type, DesignationID );
        }

        public void UpdateUserTaskETA(UserTask Task)
        {
            this.UserTaskDataProviderInstance.UpdateUserTaskETA(Task);
        }

        public UserTask GetUserTasksByLiabilityID(int LiabilityID, UserTaskType Type, int DesignationID)
        {
            return this.UserTaskDataProviderInstance.GetUserTasksByLiabilityID(LiabilityID, Type, DesignationID);
        }

        public ListUserTask GetUserTasksCount()
        {
            return this.UserTaskDataProviderInstance.GetUserTasksCount();
        }

        public ListTeamTask GetTeamTasksCount()
        {
            return this.UserTaskDataProviderInstance.GetTeamTasksCount();
        }
        // Add By Ravi kumar on 10-1-15 for Production Task
        public System.Data.DataTable GetAllProductionTask(int iUserID, int TaskModeId)
        {
            return this.UserTaskDataProviderInstance.GetAllProductionTask(iUserID, TaskModeId);
        }
    }
}
