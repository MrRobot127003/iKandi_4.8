using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using System.Data;

namespace iKandi.BLL
{
    public class WorkflowController : BaseController
    {
        #region Ctor(s)

        public WorkflowController()
        {
        }

        public WorkflowController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        #region Public Methods

        public int UpdateWorkflowInstancePostOrder(WorkflowInstance Instance)
        {
          return this.WorkflowDataProviderInstance.UpdateWorkflowInstancePostOrder(Instance);
        }
        public int CreateTaskFor_Consolidated(WorkflowInstance Instance)
        {
            return this.WorkflowDataProviderInstance.CreateTaskFor_Consolidated(Instance);
        }
        
        public int UpdatePostOrder_ForApprovedToEx_And_Exfactoried(WorkflowInstance Instance)
        {
            return this.WorkflowDataProviderInstance.UpdatePostOrder_ForApprovedToEx_And_Exfactoried(Instance);
        }
        public int UpdatePreOrderToPostOrder_ForSampling(int StyleId)
        {
            return this.WorkflowDataProviderInstance.UpdatePreOrderToPostOrder_ForSampling(StyleId);
        }
        public int UpdateWorkflowInstancePostOrder_Style_Order_Basis(int StyleId, int OrderId, TaskMode Status, int UserId)
        {
            return this.WorkflowDataProviderInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(StyleId, OrderId, (int)Status, UserId);
        }
        public int UpdateWorkflowInstancePostOrder_Only_For_Cutting(int StyleId, int OrderId, TaskMode Status, int UserId)
        {
            return this.WorkflowDataProviderInstance.UpdateWorkflowInstancePostOrder_Only_For_Cutting(StyleId, OrderId, (int)Status, UserId);
        }
        public int DeleteUnnessaryFits_UploadComentesTask(int StyleId,TaskMode Status)
        {
            return this.WorkflowDataProviderInstance.DeleteUnnessaryFits_UploadComentesTask(StyleId, (int)Status);
        }
        public int SplitOrder_FromOrderID(int OrderID)
        {
            return this.WorkflowDataProviderInstance.SplitOrder_FromOrderID(OrderID);
        }
        public int UpdateWorkflowInstancePreOrder_ForCreateOB(int StyleId, int OrderId, TaskMode Status, int UserId)
        {
            return this.WorkflowDataProviderInstance.UpdateWorkflowInstancePreOrder_ForCreateOB(StyleId, OrderId, (int)Status, UserId);
        }
        public int CreateTaskForCutAvg(int OrderId)
        {
            return this.WorkflowDataProviderInstance.CreateTaskForCutAvg(OrderId);
        }

        public bool GetMrMathurCheckBox(int StyleId)
        {
            return this.WorkflowDataProviderInstance.GetMrMathurCheckBox(StyleId);
        }
        public bool CheckOrderExistAndSamplingStatus(int StyleId)
        {
            return this.WorkflowDataProviderInstance.CheckOrderExistAndSamplingStatus(StyleId);
        }
        public int Update_PreOrder_Fits_Cycle(int StyleId, string status, string Requested, string PDDecesion, int UserID)
        {
            return this.WorkflowDataProviderInstance.Update_PreOrder_Fits_Cycle(StyleId, status, Requested, PDDecesion, UserID);
        }
        public int Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(int OrderId, int OrderDetailId, TaskMode Status, int UserId)
        {
            return this.WorkflowDataProviderInstance.Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(OrderId, OrderDetailId, (int)Status, UserId);
        }

        public string GetDesignationName()
        {
          return this.WorkflowDataProviderInstance.GetDesignationName(this.LoggedInUser.UserData.UserID);
        }

        //Ceate by Surendra2 on 11-12-2018
        public int UpdateWorkflowInstanceClosing_PreOrder(int StyleId, TaskMode Status, int UserId, int Type)
        {
            return this.WorkflowDataProviderInstance.UpdateWorkflowInstanceClosing_PreOrder(StyleId, (int)Status, UserId, Type);
        }
        public int UpdateWorkflowInstanceOpen_PreOrder(int StyleId, TaskMode Status, int UserId, int Type)
        {
            return this.WorkflowDataProviderInstance.UpdateWorkflowInstanceOpen_PreOrder(StyleId, (int)Status, UserId, Type);
        }

        //Gajendra Workflow
        public int UpdateWorkflowInstancePreOrder(int StyleId, TaskMode Status, int UserId)
        {
            return this.WorkflowDataProviderInstance.UpdateWorkflowInstancePreOrder(StyleId, (int)Status, UserId);
        }
        public int UpdateWorkflow_PatternReady(int StyleId, TaskMode Status, int UserId)
        {
            return this.WorkflowDataProviderInstance.UpdateWorkflow_PatternReady(StyleId, (int)Status, UserId);
        }
        public int UpdateWorkflow_SampleSent_Closed_CourierSent(int StyleId, TaskMode Status, int UserId)
        {
            return this.WorkflowDataProviderInstance.UpdateWorkflow_SampleSent_Closed_CourierSent(StyleId, (int)Status, UserId);
        }
       
        public int UpdateWorkflowInstanceFisModule_SpecialCases(int StyleId, TaskMode Status, int UserId)
        {
            return this.WorkflowDataProviderInstance.UpdateWorkflowInstanceFisModule_SpecialCases(StyleId, (int)Status, UserId);
        }

        //uday Notification
        public DataSet GetNotifactionRemarks(int DesignationID, int TaskId, string type,int userid)
        {

            return this.WorkflowDataProviderInstance.GetNotifactionRemarks(DesignationID, TaskId, type, userid);
        }


        //uday TaskCompletion
        public DataSet GetTaskCompletebyTask(int TaskId)
        {

            return this.WorkflowDataProviderInstance.GetTaskCompletebyTask(TaskId);
        }


        public WorkflowInstance InsertWorkflowInstance(WorkflowInstance Instance)
        {
            return this.WorkflowDataProviderInstance.InsertWorkflowInstance(Instance);
        }

        public DataSet GetGlobalandlanding(int department, int DesignationID, int UserId, int FromLogin)
        {

            return this.WorkflowDataProviderInstance.GetGlobalandlanding(department, DesignationID, UserId, FromLogin);
        }

        public DataTable GetDelayTaskDetails()
        {
          return this.WorkflowDataProviderInstance.GetDelayTaskDetails();
        }
        public DataTable Get_LeadTime_DelayTaskDetails()
        {
            return this.WorkflowDataProviderInstance.Get_LeadTime_DelayTaskDetails();
        }

        public DataTable GetClients_DelayTaskDetails()
        {
          return this.WorkflowDataProviderInstance.GetClients_DelayTaskDetails();
        }
        public DataTable GetClients_LeadTime_DelayTaskDetails()
        {
            return this.WorkflowDataProviderInstance.GetClients_LeadTime_DelayTaskDetails();
        }

        public DataTable GetClients_DelayTaskCount(int ClientId, int StatusModeId)
        {
            return this.WorkflowDataProviderInstance.GetClients_DelayTaskCount(ClientId, StatusModeId);
        }
        public DataTable GetClients_LeadTime_DelayTaskCount(int ClientId, int StatusModeId)
        {
            return this.WorkflowDataProviderInstance.GetClients_LeadTime_DelayTaskCount(ClientId, StatusModeId);
        }
       
        public DateTime GetNextTargetDate(int StatusId, OrderDetail OrderBreakDown)
        {
            return this.WorkflowDataProviderInstance.GetNextTargetDate(StatusId, OrderBreakDown);
        }

        public DateTime GetNextTargetDateByWfId(int StatusId, int WfId,string modeName)
        {
            return this.WorkflowDataProviderInstance.GetNextTargetDateByWfId(StatusId, WfId, modeName);
        }

        //public int GetNextTargetDays(int StatusId, OrderDetail OrderBreakDown)
        //{
        //    return this.WorkflowDataProviderInstance.GetNextTargetDays(StatusId, OrderBreakDown);
        //}

        public void UpdateWorkflowInstance(WorkflowInstance Instance)
        {
            this.WorkflowDataProviderInstance.UpdateWorkflowInstance(Instance);
        }

        public void UpdateWorkflowInstanceByID(WorkflowInstance WFInstance)
        {
            this.WorkflowDataProviderInstance.UpdateWorkflowInstanceByID(WFInstance);
        }

        public WorkflowInstanceDetail InsertWorkflowInstanceDetail(WorkflowInstanceDetail InstanceDetail)
        {
            return this.WorkflowDataProviderInstance.InsertWorkflowInstanceDetail(InstanceDetail);
        }
        public bool IscheckInlinetask(int mode, int statusMode)
        {
            return this.WorkflowDataProviderInstance.IscheckInlinetask(mode,statusMode);
        }
        public bool IsCheckCreateOBInPre_Order(int styleid)
        {
            return this.WorkflowDataProviderInstance.IsCheckCreateOBInPre_Order(styleid);
        }
        //added by uday 01/11/2016
        public bool InsertDelayForMO(string SessionId, int StatusId,int UserID)
        {
            return this.WorkflowDataProviderInstance.InsertDelayForMO(SessionId, StatusId, UserID);
        }
        public string InsertDelayCountForMO(string SessionId, int Check)
        {
            return this.WorkflowDataProviderInstance.InsertDelayCountForMO(SessionId, Check);
        }
        public string GetDelayOrderDetailIds(string SessionId)
        {
          return this.WorkflowDataProviderInstance.GetDelayOrderDetailIds(SessionId);
        }


        public void CompleteWorkflowInstanceTask(WorkflowInstanceDetail InstanceDetail)
        {
            this.WorkflowDataProviderInstance.CompleteWorkflowInstanceTask(InstanceDetail);
        }

        public void OnlyAllocationUpdateTask(WorkflowInstanceDetail InstanceDetail, int IsStc)
        {
            this.WorkflowDataProviderInstance.OnlyAllocationUpdateTask(InstanceDetail, IsStc);
        }

        public void UpdateWorkFlowInstanceDetails(WorkflowInstanceDetail WInstanceDetail)
        {
            this.WorkflowDataProviderInstance.UpdateWorkFlowInstanceDetails(WInstanceDetail);
        }
        

        public WorkflowInstance GetInstance(int StyleID, int OrderID, int OrderDetailID)
        {
            return this.WorkflowDataProviderInstance.GetInstance(StyleID, OrderID, OrderDetailID, -1);
        }

        public WorkflowInstance GetInstance(int ProductionPlanningID)
        {
            return this.WorkflowDataProviderInstance.GetInstance(-1, -1, -1, ProductionPlanningID);
        }

        public WorkflowInstance GetInstanceByID(int InstanceID)
        {
            return this.WorkflowDataProviderInstance.GetInstanceByID(InstanceID);
        }

        public WorkflowInstance GetInstanceHistory(int InstanceID)
        {
            return this.WorkflowDataProviderInstance.GetInstanceHistory(InstanceID);
        }

        public List<WorkflowInstanceDetail> GetUserTasks(int UserID)
        {
            return this.WorkflowDataProviderInstance.GetUserTasks(UserID);
        }

        public List<WorkflowInstanceDetail> GetUserTasksByDept(int UserID, int TaskId, int MyTask)
        {
            return this.WorkflowDataProviderInstance.GetUserTaskDAL(UserID, TaskId, MyTask);
        }

        public List<WorkflowInstanceDetail> GetWorkflowResolutionTasks(int UserID)  // change 
        {
            return this.WorkflowDataProviderInstance.GetWorkflowresolutionTasks(UserID);
        }

        public List<WorkflowInstanceDetail> GetWorkflowresolutionTasksByTaskId(int UserID, int TaskModeId)
        {
            return this.WorkflowDataProviderInstance.GetWorkflowresolutionTasksByTaskId(UserID, TaskModeId);
        }

        //public List<WorkflowInstanceDetail> GetUserStatusMeetingTasks(int UserID)
        //{
        //    return this.WorkflowDataProviderInstance.GetUserStatusMeetingTasks(UserID);
        //}

        public List<WorkflowInstanceDetail> GetUserTasks(int UserID, int WFInstanceID)
        {
            return this.WorkflowDataProviderInstance.GetUserTasks(UserID, WFInstanceID);
        }

        public WorkflowInstance Create_CloseWorkflowPostOrder(int OrderID, int OrderDetailID, TaskMode Status, int UserId)
        {
          WorkflowInstance instance = new WorkflowInstance();
          instance.CurrentStatus = new WorkflowInstanceDetail();
          instance.CurrentStatus.StatusModeID = (int)Status;
          instance.Order = new iKandi.Common.Order();
          instance.Order.OrderID = OrderID;
          instance.OrderDetailID = OrderDetailID;
          instance.AssignedTo = new User();
          instance.AssignedTo.UserID = UserId;
          instance.AssignedTo.Actiondate = Convert.ToDateTime(DateTime.Now.Date);
          this.UpdateWorkflowInstancePostOrder(instance);
          return instance;
        }
        public WorkflowInstance UpdatePostOrder_ForApprovedToEx_And_Exfactoried(int OrderID, int OrderDetailID, TaskMode Status, int UserId)
        {
            WorkflowInstance instance = new WorkflowInstance();
            instance.CurrentStatus = new WorkflowInstanceDetail();
            instance.CurrentStatus.StatusModeID = (int)Status;
            instance.Order = new iKandi.Common.Order();
            instance.Order.OrderID = OrderID;
            instance.OrderDetailID = OrderDetailID;
            instance.AssignedTo = new User();
            instance.AssignedTo.UserID = UserId;
            this.UpdatePostOrder_ForApprovedToEx_And_Exfactoried(instance);
            return instance;
        }
        public WorkflowInstance CreateTaskFor_Consolidated(int OrderID, int OrderDetailID, TaskMode Status, int UserId)
        {
            WorkflowInstance instance = new WorkflowInstance();
            instance.CurrentStatus = new WorkflowInstanceDetail();
            instance.CurrentStatus.StatusModeID = (int)Status;
            instance.Order = new iKandi.Common.Order();
            instance.Order.OrderID = OrderID;
            instance.OrderDetailID = OrderDetailID;
            instance.AssignedTo = new User();
            instance.AssignedTo.UserID = UserId;
            this.CreateTaskFor_Consolidated(instance);
            return instance;
        }

        public WorkflowInstance CreateWorkflow(int OrderID, int OrderDetailID, int StyleID, StatusMode Mode)
        {

            WorkflowInstance instance = new WorkflowInstance();

            instance.CurrentStatus = new WorkflowInstanceDetail();
            instance.CurrentStatus.StatusModeID = (int)Mode;
            instance.Order = new iKandi.Common.Order();
            instance.Order.OrderID = OrderID;
            instance.Style = new iKandi.Common.Style();
            instance.Style.StyleID = StyleID;
            instance.OrderDetailID = OrderDetailID;

            this.InsertWorkflowInstance(instance);

            return instance;
        }
       
        public WorkflowInstanceDetail CreateTask(TaskMode Mode, int WorkflowID, DateTime ETA)
        {
            WorkflowInstanceDetail instanceDetail = new WorkflowInstanceDetail();

            instanceDetail.AssignedTo = new User();
            instanceDetail.AssignedTo.UserID = -1;
            instanceDetail.ActionDate = DateTime.MinValue;
            instanceDetail.StatusModeID = (int)Mode;
            instanceDetail.ETA = ETA;
            instanceDetail.WorkflowInstance = new WorkflowInstance();
            instanceDetail.WorkflowInstance.WorkflowInstanceID = WorkflowID;

            return this.InsertWorkflowInstanceDetail(instanceDetail);
        }

        public void CompleteTask(WorkflowInstanceDetail InstanceDetail, int UserID)
        {
            //WorkflowInstanceDetail instanceDetail = new WorkflowInstanceDetail();
            InstanceDetail.ActionDate = DateTime.Today;
            InstanceDetail.AssignedTo = new User();
            InstanceDetail.AssignedTo.UserID = UserID;

            //instanceDetail.WorkflowInstanceDetailID = WorkflowInstanceDetailID;

            this.CompleteWorkflowInstanceTask(InstanceDetail);
          

            //if (InstanceDetail.StatusModeID == 12)
            //{
            //    List<WorkflowInstanceDetail> instanceDetails = this.WorkflowDataProviderInstance.GetWorkflowIDs(InstanceDetail.WorkflowInstance.Style.StyleID);
            //    if (instanceDetails != null)
            //    {
            //        foreach (WorkflowInstanceDetail wid in instanceDetails)
            //        {
            //            wid.ActionDate = DateTime.Today;
            //            wid.AssignedTo = new User();
            //            wid.AssignedTo.UserID = UserID;

            //            this.CompleteWorkflowInstanceTask(wid);
                       
            //        }
            //    }
            //    //this.GetWorkflowIDs(InstanceDetail);
            //}
        }
        public void CompleTaskVerifyCosting(int UserID,int styleid)
        {
            this.WorkflowDataProviderInstance.CompleteVeriFyCostingTask(UserID, styleid);
        }

       

        //public List<WorkflowInstanceDetail> GetCurrentPendingTasks(int SyleID, int OrderID, int OrderDetailID)
        //{
        //    return this.WorkflowDataProviderInstance.GetCurrentPendingTasks(SyleID, OrderID, OrderDetailID);
        //}

        public List<WorkflowInstanceDetail> GetCurrentPendingTasks(int WFInstanceID)
        {
            return this.WorkflowDataProviderInstance.GetCurrentPendingTasks(WFInstanceID);
        }

        public void ChangeWorkflowTaskMode(int WorkflowInstanceDetailID, int StatusModeID)
        {
            this.WorkflowDataProviderInstance.ChangeWorkflowTaskMode(WorkflowInstanceDetailID, StatusModeID);
        }

        public bool ChangeStatusToOnHold(int OrderDetailID, string Remarks)
        {
            //this.NotificationControllerInstance.SendOnHoldOrderEmail(OrderDetailID, Remarks, 1);
            return this.WorkflowDataProviderInstance.ChangeStatusToOnHold(OrderDetailID, Remarks);
        }
        public bool CheckOrder_OrderDetail_From_Style(int styleid, TaskMode Status, int Userid,string status="")
        {
            //this.NotificationControllerInstance.SendOnHoldOrderEmail(OrderDetailID, Remarks, 1);
            return this.WorkflowDataProviderInstance.CheckOrder_OrderDetail_From_Style(styleid, (int)Status, Userid, status);
        }


        public bool ChangeStatusToPrevious(int OrderDetailID, string Remarks)
        {
           // this.NotificationControllerInstance.SendOnHoldOrderEmail(OrderDetailID, Remarks, 2);
            return this.WorkflowDataProviderInstance.ChangeStatusToPrevious(OrderDetailID);
        }

        public bool UpdateWorkflowInstanceDetailByOrderDetailID(int OrderDetailID)
        {
            return this.WorkflowDataProviderInstance.UpdateWorkflowInstanceDetailByOrderDetailID(OrderDetailID);
        }

        // Add By Ravi kumar on 24/12/2014 fro Acknowledgment
        public bool Update_userTaskFor_Acknowledgment(int Type, int StyleId, int OrderId, DateTime ActionDate, int ActionBy)
        {
            return this.WorkflowDataProviderInstance.Update_userTaskFor_Acknowledgment(Type, StyleId, OrderId, ActionDate, ActionBy);
        }

        // Add By Ravi kumar on 28/07/2015 create task for OB and Risk
        public bool CreateTask_For_OB_Risk(string Type, int StyleId, int OrderId, int UserId)
        {
            return this.WorkflowDataProviderInstance.CreateTask_For_OB_Risk(Type, StyleId, OrderId,  UserId);
        }

        public bool Update_userTaskFor_OB_Risk(string Flag, int Type, int StyleId, int OrderId, DateTime ActionDate, int ActionBy)
        {
            return this.WorkflowDataProviderInstance.Update_userTaskFor_OB_Risk(Flag, Type, StyleId, OrderId, ActionDate, ActionBy);
        }
        // update by Ravi kumar for OB and Risk task ON 31/7/2015
        public string IsOBRiskDone(int StyleId, int OrderId, string Flag)
        {
            return this.WorkflowDataProviderInstance.IsOBRiskDone(StyleId, OrderId, Flag);
        }

        public int WorkflowTask_OB_Risk(int StyleId, int OrderId, string Flag)
        {
            return this.WorkflowDataProviderInstance.WorkflowTask_OB_Risk(StyleId, OrderId, Flag);
        }
        // Create by Ravi kumar on 12/09/2015 for Current status.
        public int Workflow_get_current_Status(int StyleId, int OrderId, int OrderDetailId)
        {
            return this.WorkflowDataProviderInstance.Workflow_get_current_Status(StyleId, OrderId, OrderDetailId);
        }
        // Create by Ravi kumar on 10/03/2016 for Inline cut.
        public WorkflowInstance Create_CloseInlineCut_PostOrder(int OrderID, int OrderDetailID, TaskMode Status, int UserId)
        {
            WorkflowInstance instance = new WorkflowInstance();
            instance.CurrentStatus = new WorkflowInstanceDetail();
            instance.CurrentStatus.StatusModeID = (int)Status;
            instance.Order = new iKandi.Common.Order();
            instance.Order.OrderID = OrderID;
            instance.OrderDetailID = OrderDetailID;
            instance.AssignedTo = new User();
            instance.AssignedTo.UserID = UserId;
            this.UpdateInlineCut_PostOrder(instance);
            return instance;
        }
        public int UpdateInlineCut_PostOrder(WorkflowInstance Instance)
        {
            return this.WorkflowDataProviderInstance.UpdateInlineCut_PostOrder(Instance);
        }

        public int Close_AcknowledgeTask(int StyleId, TaskMode Status, int UserId)
        {
            return this.WorkflowDataProviderInstance.Close_AcknowledgeTask(StyleId, (int)Status, UserId);
        }

        public int Close_AcknowledgeFabric(int OrderId, TaskMode Status, int UserId)
        {
            return this.WorkflowDataProviderInstance.Close_AcknowledgeFabric(OrderId, (int)Status, UserId);
        }

        public int IsFinalOBDone(int StyleId, TaskMode Status, string Flag)
        {
            return this.WorkflowDataProviderInstance.IsFinalOBDone(StyleId, (int)Status, Flag);
        }
        //added by abhishek on 14/7/2017
        public DataTable GetClients_DelayTaskCount_TopApprovalPending(int ClientId, int StatusModeId)
        {
            return this.WorkflowDataProviderInstance.GetClients_DelayTaskCount_TopApprovalPending(ClientId, StatusModeId);
        }
        public bool bCheck_AllCondition_CreateFabric(int OrderDetailID,int OrderID, string Accesories_Check)
        {
            return WorkflowDataProviderInstance.bCheck_AllCondition_CreateFabric(OrderDetailID,OrderID, Accesories_Check);
        }

        //End
        #endregion
    }
}
