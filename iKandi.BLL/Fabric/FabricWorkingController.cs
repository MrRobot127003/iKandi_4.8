using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.DAL;
using iKandi.Common;
using System.Data;

namespace iKandi.BLL
{
    public class FabricWorkingController : BaseController
    {
        #region

        public FabricWorkingController()
        {
        }

        public FabricWorkingController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public bool InsertFabricWorking(iKandi.Common.FabricWorking fabricWorking)
        {
          bool success = this.FabricWorkingDataProviderInstance.InsertFabricWorking(fabricWorking);
          if (success)
          {
              iKandi.Common.Order order = this.OrderDataProviderInstance.GetOrderById(fabricWorking.order.OrderID);
            foreach (OrderDetail orderDetail in order.OrderBreakdown)
            {
              if (orderDetail.OrderDetailID > 0)
              {
                 
                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Create_Fabric, this.LoggedInUser.UserData.UserID);
                if (Convert.ToBoolean(fabricWorking.ApprovedByAccountManager))
                {
                    instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fabric_Approved, this.LoggedInUser.UserData.UserID);
                }
              }
            }
          }
          //// Edit By Nikhil
            //if (fabricWorking.ApprovedByAccountManager != 1 && fabricWorking.ApprovedByAccountManager != 1)
            //{
            //  return success;
            //}
            //try
            //{
            //  if (success)
            //  {
            //    // TODO: Heaving call, avoid it
            //    Order order = this.OrderDataProviderInstance.GetOrderById(fabricWorking.order.OrderID);

            //    foreach (OrderDetail orderDetail in order.OrderBreakdown)
            //    {
            //      // Update workflow
            //      WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(order.Style.StyleID, fabricWorking.order.OrderID, orderDetail.OrderDetailID);
            //      List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

            //      foreach (WorkflowInstanceDetail task in tasks)
            //      {
            //        if (task.StatusModeID == (int)StatusMode.WORKINGSCREATED && task.ApplicationModule.ApplicationModuleID == (int)AppModule.FABRIC_WORKING_FORM)
            //        {
            //          if (tasks.Count == 1)
            //          {
            //            this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);

            //            this.WorkflowControllerInstance.CreateTask(StatusMode.LIVE, instance.WorkflowInstanceID, order.OrderDate.AddDays(3));
            //          }
            //          else
            //          {
            //            WorkflowInstanceDetail newTask = new WorkflowInstanceDetail();
            //            newTask.ActionDate = DateTime.Today;
            //            newTask.AssignedTo = new User();
            //            newTask.AssignedTo.UserID = this.LoggedInUser.UserData.UserID;
            //            newTask.ETA = task.ETA;
            //            newTask.ActionID = task.ActionID;
            //            newTask.StatusModeID = task.StatusModeID;
            //            newTask.WorkflowInstance = new WorkflowInstance();
            //            newTask.WorkflowInstance.WorkflowInstanceID = instance.WorkflowInstanceID;
            //            this.WorkflowControllerInstance.InsertWorkflowInstanceDetail(newTask);
            //          }
            //        }
            //      }
            //    }
            //  }
            //}
            //catch (Exception ex)
            //{
            //  // this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            //}
          ////
          return success;
        }

        public bool UpdateFabricWorkingForSTM(iKandi.Common.FabricWorking fabricWorking)
        {
            bool success = this.FabricWorkingDataProviderInstance.UpdateFabricWorkingForSTM(fabricWorking);

            return success;
        }

        public bool UpdateFabricWorking(iKandi.Common.FabricWorking fabricWorking, bool FabricSection1, bool FabricSection2, bool FabricSection3, bool FabricSection4)
        {
          bool success = this.FabricWorkingDataProviderInstance.UpdateFabricWorking(fabricWorking);
          if (success && Convert.ToBoolean(fabricWorking.ApprovedByAccountManager))
          {
            //TODO: Heaving call, avoid it
              iKandi.Common.Order order = this.OrderDataProviderInstance.GetOrderById(fabricWorking.order.OrderID);
            foreach (OrderDetail orderDetail in order.OrderBreakdown)
            {
              if (orderDetail.OrderDetailID > 0)
              {

                  WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fabric_Approved, this.LoggedInUser.UserData.UserID);
                   instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Create_Fabric, this.LoggedInUser.UserData.UserID);


                  int iResult = WorkflowControllerInstance.Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(order.OrderID, orderDetail.OrderDetailID, TaskMode.WORKINGS_CREATED, this.LoggedInUser.UserData.UserID);

                 #region Gajendra Commented 26-04-2016
                //if ((FabricSection1 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric1)) && (FabricSection2 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric2)) && (FabricSection3 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric3)) && (FabricSection4 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric4)))
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Color_Print_REF_Received, this.LoggedInUser.UserData.UserID);
                //}
                //else if ((FabricSection1 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric1)) && (FabricSection2 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric2)) && (FabricSection3 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric3)) && !FabricSection4)
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Color_Print_REF_Received, this.LoggedInUser.UserData.UserID);
                //}
                //else if ((FabricSection1 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric1)) && (FabricSection2 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric2)) && !FabricSection3 && !FabricSection4)
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Color_Print_REF_Received, this.LoggedInUser.UserData.UserID);
                //}
                //else if ((FabricSection1 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric1)) && !FabricSection2 && !FabricSection3 && !FabricSection4)
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Color_Print_REF_Received, this.LoggedInUser.UserData.UserID);
                //}
                ////if ((FabricSection1 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric1)) || (FabricSection2 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric2)) || (FabricSection3 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric3)) || (FabricSection4 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric4)))
                ////{
                ////  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Color_Print_REF_Received, this.LoggedInUser.UserData.UserID);
                ////}

                //if ((FabricSection1 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric2) == 2) && (FabricSection3 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric3) == 2) && (FabricSection4 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric4) == 2))
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fabric_Quality_Approved, this.LoggedInUser.UserData.UserID);
                //}
                //else if ((FabricSection1 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric2) == 2) && (FabricSection3 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric3) == 2) && !FabricSection4)
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fabric_Quality_Approved, this.LoggedInUser.UserData.UserID);
                //}
                //else if ((FabricSection1 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric2) == 2) && !FabricSection3 && !FabricSection4)
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fabric_Quality_Approved, this.LoggedInUser.UserData.UserID);
                //}
                //else if ((FabricSection1 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric1) == 2) && !FabricSection2 && !FabricSection3 && !FabricSection4)
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fabric_Quality_Approved, this.LoggedInUser.UserData.UserID);
                //}
                ////if ((FabricSection1 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric1) == 2) || (FabricSection2 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric2) == 2) || (FabricSection3 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric3) == 2) || (FabricSection4 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric4) == 2))
                ////{
                ////  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fabric_Quality_Approved, this.LoggedInUser.UserData.UserID);
                ////}

                //if ((FabricSection1 && Convert.ToInt32(fabricWorking.IntialAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.IntialAprdFabric2) == 2) && (FabricSection3 && Convert.ToInt32(fabricWorking.IntialAprdFabric3) == 2) && (FabricSection4 && Convert.ToInt32(fabricWorking.IntialAprdFabric4) == 2))
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Initial_Approval, this.LoggedInUser.UserData.UserID);
                //}
                //else if ((FabricSection1 && Convert.ToInt32(fabricWorking.IntialAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.IntialAprdFabric2) == 2) && (FabricSection3 && Convert.ToInt32(fabricWorking.IntialAprdFabric3) == 2) && !FabricSection4)
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Initial_Approval, this.LoggedInUser.UserData.UserID);
                //}
                //else if ((FabricSection1 && Convert.ToInt32(fabricWorking.IntialAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.IntialAprdFabric2) == 2) && !FabricSection3 && !FabricSection4)
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Initial_Approval, this.LoggedInUser.UserData.UserID);
                //}
                //else if ((FabricSection1 && Convert.ToInt32(fabricWorking.IntialAprdFabric1) == 2) && !FabricSection2 && !FabricSection3 && !FabricSection4)
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Initial_Approval, this.LoggedInUser.UserData.UserID);
                //}
                ////if ((FabricSection1 && Convert.ToInt32(fabricWorking.IntialAprdFabric1) == 2) || (FabricSection2 && Convert.ToInt32(fabricWorking.IntialAprdFabric2) == 2) || (FabricSection3 && Convert.ToInt32(fabricWorking.IntialAprdFabric3) == 2) || (FabricSection4 && Convert.ToInt32(fabricWorking.IntialAprdFabric4) == 2))
                ////{
                ////  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Initial_Approval, this.LoggedInUser.UserData.UserID);
                ////}

                //if ((FabricSection1 && Convert.ToInt32(fabricWorking.BulkAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.BulkAprdFabric2) == 2) && (FabricSection3 && Convert.ToInt32(fabricWorking.BulkAprdFabric3) == 2) && (FabricSection4 && Convert.ToInt32(fabricWorking.BulkAprdFabric4) == 2))
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Bulk_Approval, this.LoggedInUser.UserData.UserID);
                //}
                //else if ((FabricSection1 && Convert.ToInt32(fabricWorking.BulkAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.BulkAprdFabric2) == 2) && (FabricSection3 && Convert.ToInt32(fabricWorking.BulkAprdFabric3) == 2) && !FabricSection4)
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Bulk_Approval, this.LoggedInUser.UserData.UserID);
                //}
                //else if ((FabricSection1 && Convert.ToInt32(fabricWorking.BulkAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.BulkAprdFabric2) == 2) && !FabricSection3 && !FabricSection4)
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Bulk_Approval, this.LoggedInUser.UserData.UserID);
                //}
                //else if ((FabricSection1 && Convert.ToInt32(fabricWorking.BulkAprdFabric1) == 2) && !FabricSection2 && !FabricSection3 && !FabricSection4)
                //{
                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Bulk_Approval, this.LoggedInUser.UserData.UserID);
                //}
                ////if ((FabricSection1 && Convert.ToInt32(fabricWorking.BulkAprdFabric1) == 2) || (FabricSection2 && Convert.ToInt32(fabricWorking.BulkAprdFabric2) == 2) || (FabricSection3 && Convert.ToInt32(fabricWorking.BulkAprdFabric3) == 2) || (FabricSection4 && Convert.ToInt32(fabricWorking.BulkAprdFabric4) == 2))
                ////{
                ////  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Bulk_Approval, this.LoggedInUser.UserData.UserID);
                ////}
                //else if ((Convert.ToInt32(fabricWorking.BulkAprdFabric1) == 2))
                //{
                //    instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Bulk_Approval, this.LoggedInUser.UserData.UserID);
                //}
                #endregion

                if (Convert.ToBoolean(fabricWorking.ApprovedByFabricManager))
                {
                  
                  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fill_Fabric, this.LoggedInUser.UserData.UserID);
                }              
              }
            }

            if (Convert.ToBoolean(fabricWorking.AcknowledgmentChecked))
            {
                int IsConfirm = WorkflowControllerInstance.Close_AcknowledgeFabric(fabricWorking.order.OrderID, TaskMode.Acknowledgement_Fabric, this.LoggedInUser.UserData.UserID);
            }
          }

          #region Commented
          //// Edit By Nikhil
            //if (fabricWorking.ApprovedByAccountManager != 1 && fabricWorking.ApprovedByAccountManager != 1)
            //{
            //  return success;
            //}
            //try
            //{
            //  // TODO: Heaving call, avoid it
            //  Order order = this.OrderDataProviderInstance.GetOrderById(fabricWorking.order.OrderID);

            //  foreach (OrderDetail orderDetail in order.OrderBreakdown)
            //  {
            //    // Update workflow
            //    WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(-1, -1, orderDetail.OrderDetailID);
            //    List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

            //    foreach (WorkflowInstanceDetail task in tasks)
            //    {
            //      if (task.StatusModeID == (int)StatusMode.WORKINGSCREATED && task.ApplicationModule.ApplicationModuleID == (int)AppModule.FABRIC_WORKING_FORM)
            //      {
            //        if (tasks.Count == 1)
            //        {
            //          this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);

            //          this.WorkflowControllerInstance.CreateTask(StatusMode.LIVE, instance.WorkflowInstanceID, order.OrderDate.AddDays(3));
            //        }
            //        else
            //        {
            //          WorkflowInstanceDetail newTask = new WorkflowInstanceDetail();
            //          newTask.ActionDate = DateTime.Today;
            //          newTask.AssignedTo = new User();
            //          newTask.AssignedTo.UserID = this.LoggedInUser.UserData.UserID;
            //          newTask.ETA = task.ETA;
            //          newTask.ActionID = task.ActionID;
            //          newTask.StatusModeID = task.StatusModeID;
            //          newTask.WorkflowInstance = new WorkflowInstance();
            //          newTask.WorkflowInstance.WorkflowInstanceID = instance.WorkflowInstanceID;
            //          this.WorkflowControllerInstance.InsertWorkflowInstanceDetail(newTask);
            //        }
            //      }
            //    }
            //  }

            //  foreach (OrderDetail orderDetail in order.OrderBreakdown)
            //  {
            //    // Update workflow
            //    WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(-1, -1, orderDetail.OrderDetailID);
            //    List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetCurrentPendingTasks(instance.WorkflowInstanceID);

            //    foreach (WorkflowInstanceDetail task in tasks)
            //    {
            //      if (task.StatusModeID == (int)StatusMode.LIVE && task.ApplicationModule.ApplicationModuleID == (int)AppModule.FABRIC_WORKING_FORM && task.AssignedToDesignation == this.LoggedInUser.UserData.Designation && ((task.AssignedToDesignation == Designation.BIPL_Fabrics_Manager && fabricWorking.ApprovedByFabricManager >= 1) || (task.AssignedToDesignation == Designation.BIPL_Merchandising_AccountManager && fabricWorking.ApprovedByAccountManager >= 1)))
            //      {
            //        if (tasks.Count == 1)
            //        {
            //          this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);
            //          //this.NotificationControllerInstance.SubOrderStatusModeLive(order, true);

            //          if (this.OrderDataProviderInstance.IsOrderSealedOff(orderDetail.OrderDetailID))
            //          {
            //            WorkflowInstanceDetail stctask = this.WorkflowControllerInstance.CreateTask(StatusMode.STCUNALLOCATED, instance.WorkflowInstanceID, orderDetail.STCUnallocated);
            //            this.WorkflowControllerInstance.CompleteTask(stctask, this.LoggedInUser.UserData.UserID);
            //            instance.CurrentStatus.StatusModeID = (int)StatusMode.STCUNALLOCATED;
            //            this.WorkflowControllerInstance.UpdateWorkflowInstance(instance);
            //            this.WorkflowControllerInstance.CreateTask(StatusMode.ALLOCATED, instance.WorkflowInstanceID, orderDetail.STCUnallocated.AddDays(3));
            //            //this.NotificationControllerInstance.StcUnallocated(order, orderDetail, true);
            //          }
            //          else
            //          {
            //            this.WorkflowControllerInstance.CreateTask(StatusMode.STCUNALLOCATED, instance.WorkflowInstanceID, orderDetail.STCUnallocated);
            //          }
            //        }
            //        else
            //        {
            //          WorkflowInstanceDetail newTask = new WorkflowInstanceDetail();
            //          newTask.ActionDate = DateTime.Today;
            //          newTask.AssignedTo = new User();
            //          newTask.AssignedTo.UserID = this.LoggedInUser.UserData.UserID;
            //          newTask.ETA = task.ETA;
            //          newTask.ActionID = task.ActionID;
            //          newTask.StatusModeID = task.StatusModeID;
            //          newTask.WorkflowInstance = new WorkflowInstance();
            //          newTask.WorkflowInstance.WorkflowInstanceID = instance.WorkflowInstanceID;
            //          this.WorkflowControllerInstance.InsertWorkflowInstanceDetail(newTask);
            //        }
            //      }
            //    }
            //  }
            //  // Add By Ravi kumar on 24/12/2014 for Acknowledgment task
            //  if (fabricWorking.AcknowledgmentChecked == 1)
            //  {
            //    this.WorkflowControllerInstance.Update_userTaskFor_Acknowledgment(14, fabricWorking.order.StyleID, fabricWorking.order.OrderID, fabricWorking.ApprovedAcknowledgementManagerOn, this.LoggedInUser.UserData.UserID);
            //  }
            //  // End By Ravi kumar on 24/12/2014 for Acknowledgment task

            //  // Add By Ravi kumar on 27/10/2015 for Task close and go on live
            //  string OBRiskDone = WorkflowControllerInstance.IsOBRiskDone(order.Style.StyleID, order.OrderID, "LIMITATION");
            //  if (OBRiskDone == "")
            //  {
            //    int WorkflowDone = WorkflowControllerInstance.WorkflowTask_OB_Risk(order.Style.StyleID, order.OrderID, "LIMITATION");
            //  }

            //}
            //catch (Exception ex)
            //{
            //  // this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            //}
          ////
          #endregion

          return success;
        }


        public bool Update_FabricApproval_PopUp(iKandi.Common.FabricWorking fabricWorking1, bool FabricSection1, bool FabricSection2, bool FabricSection3, bool FabricSection4, string Flag)
        {
            bool success = this.FabricWorkingDataProviderInstance.Update_FabricApproval_PopUp(fabricWorking1, Flag);

            if (success && Convert.ToBoolean(fabricWorking1.ApprovedByAccountManager))
            {
                iKandi.Common.Order order = this.OrderDataProviderInstance.GetOrderById(Convert.ToInt32(fabricWorking1.OrderID));
                foreach (OrderDetail orderDetail in order.OrderBreakdown)
                {
                    if (orderDetail.OrderDetailID > 0)
                    {
                         WorkflowInstance instance;
                        if (FabricWorkingDataProviderInstance.bCheck_Fabric_Approvel_Task(orderDetail.OrderDetailID,"Color_Print_REF_Received"))
                        {
                            instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Color_Print_REF_Received, this.LoggedInUser.UserData.UserID);
                        }
                        if (FabricWorkingDataProviderInstance.bCheck_Fabric_Approvel_Task(orderDetail.OrderDetailID, "Fabric_Quality_Approved"))
                        {
                            instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fabric_Quality_Approved, this.LoggedInUser.UserData.UserID);
                        }
                        if (FabricWorkingDataProviderInstance.bCheck_Fabric_Approvel_Task(orderDetail.OrderDetailID, "Initial_Approval"))
                        {
                            instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Initial_Approval, this.LoggedInUser.UserData.UserID);
                        }
                        if (FabricWorkingDataProviderInstance.bCheck_Fabric_Approvel_Task(orderDetail.OrderDetailID, "Bulk_Approval"))
                        {
                            instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Bulk_Approval, this.LoggedInUser.UserData.UserID);
                        }
                    //    FabricWorking fabricWorking = this.FabricWorkingDataProviderInstance.Get_FabricApprovalDetails(orderDetail.OrderDetailID.ToString(), Flag);

                    //    if ((Flag == "1" && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric)) && (Flag == "2" && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric)) && (Flag == "3" && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric)) && (Flag == "4" && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric)))
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Color_Print_REF_Received, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    else if ((FabricSection1 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric)) && (FabricSection2 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric)) && (FabricSection3 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric)) && !FabricSection4)
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Color_Print_REF_Received, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    else if ((FabricSection1 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric1)) && (FabricSection2 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric2)) && !FabricSection3 && !FabricSection4)
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Color_Print_REF_Received, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    else if ((FabricSection1 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric1)) && !FabricSection2 && !FabricSection3 && !FabricSection4)
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Color_Print_REF_Received, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    //if ((FabricSection1 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric1)) || (FabricSection2 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric2)) || (FabricSection3 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric3)) || (FabricSection4 && Convert.ToBoolean(fabricWorking.PrintColorRecdFabric4)))
                    //    //{
                    //    //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Color_Print_REF_Received, this.LoggedInUser.UserData.UserID);
                    //    //}

                    //    if ((FabricSection1 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric2) == 2) && (FabricSection3 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric3) == 2) && (FabricSection4 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric4) == 2))
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fabric_Quality_Approved, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    else if ((FabricSection1 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric2) == 2) && (FabricSection3 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric3) == 2) && !FabricSection4)
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fabric_Quality_Approved, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    else if ((FabricSection1 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric2) == 2) && !FabricSection3 && !FabricSection4)
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fabric_Quality_Approved, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    else if ((FabricSection1 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric1) == 2) && !FabricSection2 && !FabricSection3 && !FabricSection4)
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fabric_Quality_Approved, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    //if ((FabricSection1 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric1) == 2) || (FabricSection2 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric2) == 2) || (FabricSection3 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric3) == 2) || (FabricSection4 && Convert.ToInt32(fabricWorking.FabricQualtityAprdFabric4) == 2))
                    //    //{
                    //    //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fabric_Quality_Approved, this.LoggedInUser.UserData.UserID);
                    //    //}

                    //    if ((FabricSection1 && Convert.ToInt32(fabricWorking.IntialAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.IntialAprdFabric2) == 2) && (FabricSection3 && Convert.ToInt32(fabricWorking.IntialAprdFabric3) == 2) && (FabricSection4 && Convert.ToInt32(fabricWorking.IntialAprdFabric4) == 2))
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Initial_Approval, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    else if ((FabricSection1 && Convert.ToInt32(fabricWorking.IntialAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.IntialAprdFabric2) == 2) && (FabricSection3 && Convert.ToInt32(fabricWorking.IntialAprdFabric3) == 2) && !FabricSection4)
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Initial_Approval, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    else if ((FabricSection1 && Convert.ToInt32(fabricWorking.IntialAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.IntialAprdFabric2) == 2) && !FabricSection3 && !FabricSection4)
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Initial_Approval, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    else if ((FabricSection1 && Convert.ToInt32(fabricWorking.IntialAprdFabric1) == 2) && !FabricSection2 && !FabricSection3 && !FabricSection4)
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Initial_Approval, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    //if ((FabricSection1 && Convert.ToInt32(fabricWorking.IntialAprdFabric1) == 2) || (FabricSection2 && Convert.ToInt32(fabricWorking.IntialAprdFabric2) == 2) || (FabricSection3 && Convert.ToInt32(fabricWorking.IntialAprdFabric3) == 2) || (FabricSection4 && Convert.ToInt32(fabricWorking.IntialAprdFabric4) == 2))
                    //    //{
                    //    //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Initial_Approval, this.LoggedInUser.UserData.UserID);
                    //    //}

                    //    if ((FabricSection1 && Convert.ToInt32(fabricWorking.BulkAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.BulkAprdFabric2) == 2) && (FabricSection3 && Convert.ToInt32(fabricWorking.BulkAprdFabric3) == 2) && (FabricSection4 && Convert.ToInt32(fabricWorking.BulkAprdFabric4) == 2))
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Bulk_Approval, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    else if ((FabricSection1 && Convert.ToInt32(fabricWorking.BulkAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.BulkAprdFabric2) == 2) && (FabricSection3 && Convert.ToInt32(fabricWorking.BulkAprdFabric3) == 2) && !FabricSection4)
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Bulk_Approval, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    else if ((FabricSection1 && Convert.ToInt32(fabricWorking.BulkAprdFabric1) == 2) && (FabricSection2 && Convert.ToInt32(fabricWorking.BulkAprdFabric2) == 2) && !FabricSection3 && !FabricSection4)
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Bulk_Approval, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    else if ((FabricSection1 && Convert.ToInt32(fabricWorking.BulkAprdFabric1) == 2) && !FabricSection2 && !FabricSection3 && !FabricSection4)
                    //    {
                    //        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Bulk_Approval, this.LoggedInUser.UserData.UserID);
                    //    }
                    //    //if ((FabricSection1 && Convert.ToInt32(fabricWorking.BulkAprdFabric1) == 2) || (FabricSection2 && Convert.ToInt32(fabricWorking.BulkAprdFabric2) == 2) || (FabricSection3 && Convert.ToInt32(fabricWorking.BulkAprdFabric3) == 2) || (FabricSection4 && Convert.ToInt32(fabricWorking.BulkAprdFabric4) == 2))
                    //    //{
                    //    //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Bulk_Approval, this.LoggedInUser.UserData.UserID);
                    //    //}
                    //    //else if ((Convert.ToInt32(fabricWorking.BulkAprdFabric1) == 2))
                    //    //{
                    //    //    instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Bulk_Approval, this.LoggedInUser.UserData.UserID);
                    //    //}
                    }
                }
            }
            return success;
        }
        ////public iKandi.Common.FabricWorking GetFabricWorking(int orderID, string OrderDetailID)
        ////{
        ////    return this.FabricWorkingDataProviderInstance.GetFabricWorking(orderID, OrderDetailID);
        ////}

        public iKandi.Common.FabricWorking Get_FabricApprovalDetails(string OrderDetailID,string type)
        {
            return this.FabricWorkingDataProviderInstance.Get_FabricApprovalDetails(OrderDetailID, type);
        }
        public iKandi.Common.FabricWorking GetFabricWorking_data(int orderID)
        {
            return this.FabricWorkingDataProviderInstance.GetFabricWorking_data(orderID);
        }

        // Add By Ravi kumar On 11/12/2014
        public string[] GetCostingAvg(int OrderId, int SeqNo)
        {
            return this.FabricWorkingDataProviderInstance.GetCostingAvg(OrderId, SeqNo);
        }
    }
}
