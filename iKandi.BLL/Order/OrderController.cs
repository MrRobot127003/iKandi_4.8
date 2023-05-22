#region Assembly Reference

using System;
using System.Collections.Generic;
using System.Data;
using iKandi.Common;
using System.Data.SqlClient;
using iKandi.Common.Entities;

#endregion

namespace iKandi.BLL
{
    public class OrderController : BaseController
    {
        #region

        public OrderController()
        {
        }

        public OrderController(SessionInfo loggedInUser)
            : base(loggedInUser)
        {
        }

        #endregion
        // update by ravi kumar on 17/8/2015 for Days, line, AvailMins, PCD update on new order
        public bool CalculatePCD_InsertOrder(int OrderId)
        {
            return OrderDataProviderInstance.CalculatePCD_InsertOrder(OrderId);
        }
        // Create by ravi kumar on 4/11/2015 for Days, line, AvailMins, PCD update on update order
        public bool CalculatePCD_UpdateOrder(int OrderId)
        {
            return OrderDataProviderInstance.CalculatePCD_UpdateOrder(OrderId);
        }
        public bool bCheckOB(int orderid)
        {
            return OrderDataProviderInstance.bCheckOB(orderid);
        }

        public bool bCheckOrderIsShipped(int OrderDetailID)
        {
            return OrderDataProviderInstance.bCheckOrderIsShipped(OrderDetailID);
        }
        /*aDDED BY UDAY * 21- 12- 2015*/

        public DataSet GetDHUDAYTA(int productionid)
        {
            DataSet ds = new DataSet();
            ds = OrderDataProviderInstance.GetDHUDAYTA(productionid);
            return ds;

        }

        public DataSet GetDHUDAYTAByStyle(int productionid, int lineno)
        {
            DataSet ds = new DataSet();
            ds = OrderDataProviderInstance.GetDHUDAYTAByStyle(productionid, lineno);
            return ds;
        }
        public DataSet GetDHUDAYTAByStyleAllFactory(int productionid, int lineno)
        {
            DataSet ds = new DataSet();
            ds = OrderDataProviderInstance.GetDHUDAYTAByStyleAllFactory(productionid, lineno);
            return ds;
        }

        public DataSet GetWeeklyData(int productionid)
        {
            DataSet ds = new DataSet();
            ds = OrderDataProviderInstance.GetWeeklyData(productionid);
            return ds;
        }

        //Add By Surendra2 on 10-05-2018
        public bool Update_Old_Style(int StyleId, int OrderId, int NewStyleId)
        {
            bool success = OrderDataProviderInstance.Update_Old_Style(StyleId, OrderId, NewStyleId);
            return success;
        }

        public bool AddOrder(iKandi.Common.Order order, int UserId, ref bool bCheckOrder, ref bool UpdateCheck, ref int AfterUpdation, ref int NewOrderId, int IsRepeatWithChanges)
        {
            bool bCheckAutoAllocation = false;
            bool bCheckUpdateRepeatOrder = false;
            if (order.OrderID == -1)
            {
                bool success = OrderDataProviderInstance.InsertOrder(order, UserId, ref NewOrderId, IsRepeatWithChanges);
                UpdateCheck = false;
                try
                {
                    if (success)
                    {
                        //split order insert
                        foreach (OrderDetail orderDetail in order.OrderBreakdown)
                        {
                            // Initiate Workflow
                            if (orderDetail.OrderDetailID > 0)
                            {
                                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.NEW_ORDER, UserId);
                            }
                        }
                        // Add by Ravi kumar for Auto Allocation and reallocation after new order on 23/11/2016
                        bCheckAutoAllocation = OrderDataProviderInstance.AutoAllocation_ReallocationOrder(order.OrderID);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                    // NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                }
                return success;
            }
            else
            {
                bool success = OrderDataProviderInstance.UpdateOrder(order, UserId, ref bCheckOrder, ref AfterUpdation);
                //bCheckAutoAllocation = OrderDataProviderInstance.AutoAllocation_ReallocationOrder(order.OrderID);
                UpdateCheck = true;
                try
                {
                    //split order update
                    if (success)
                    {
                        foreach (OrderDetail orderDetail in order.OrderBreakdown)
                        {
                            if (orderDetail.isSplit == 1)
                            {
                                bool success1 = OrderDataProviderInstance.SplitOrder(order.OrderID, orderDetail.OrderDetailID, orderDetail.parentOrderDetailID, UserId, orderDetail.sortType);
                                if (success1 == false)
                                    return false;
                            }

                            // Update workflow
                            WorkflowInstance instance = WorkflowControllerInstance.GetInstance(order.Style.StyleID, order.OrderID, orderDetail.OrderDetailID);

                            if (instance == null || instance.WorkflowInstanceID <= 0)
                            {
                                if (orderDetail.OrderDetailID > 0 && orderDetail.isDeleted == 0)
                                {
                                    // Initiate Workflow
                                    instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.NEW_ORDER, UserId);
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                // Edit by Surendra.. After order confirmed all preorder task delete as "HandOver","Pattern ready","Sample sent","Fits Comments Upload" on 06/07/2017
                                this.WorkflowControllerInstance.DeleteUnnessaryFits_UploadComentesTask(orderDetail.StyleId, TaskMode.HandOver);
                                this.WorkflowControllerInstance.DeleteUnnessaryFits_UploadComentesTask(orderDetail.StyleId, TaskMode.Pattern_Ready);
                                this.WorkflowControllerInstance.DeleteUnnessaryFits_UploadComentesTask(orderDetail.StyleId, TaskMode.Fits_SampleSent);
                                this.WorkflowControllerInstance.DeleteUnnessaryFits_UploadComentesTask(orderDetail.StyleId, TaskMode.FitsCommentes_Upload);

                                //-------------------------------------------------END--------------------------------------------------------------------------
                                if (order.ApprovedBySalesBIPL >= 1)
                                {
                                    instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.ORDER_CONFIRMED_SALES, UserId);


                                }
                                if (order.ApprovedByMerchandiserManager >= 1)
                                {
                                    instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.ORDER_CONFIRMED_MERCHANT, UserId);
                                }
                                //if (orderDetail.File1 != "null" || orderDetail.File2 != "null" || orderDetail.File3 != "null" || orderDetail.File4 != "null")
                                //{
                                //  instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.PO_Upload, UserId);
                                //}
                            }


                            int CurrentStatus = WorkflowControllerInstance.Workflow_get_current_Status(order.Style.StyleID, order.OrderID, orderDetail.OrderDetailID);
                            //if (CurrentStatus == 11 || (CurrentStatus >= 25 && CurrentStatus <= 29) || CurrentStatus == 36 || CurrentStatus == 37 || CurrentStatus == 77)
                            if (CurrentStatus == 77)
                            {
                                // bCheckAutoAllocation = OrderDataProviderInstance.AutoAllocation_ReallocationOrder(order.OrderID);
                                bCheckUpdateRepeatOrder = OrderDataProviderInstance.UpdateWorkflow_RepeatOrder(order.OrderID, order.Style.StyleID);
                                int SaveCQD = OrderDataProviderInstance.SaveCQDByOrderId(order.OrderID);
                            }
                        }
                        // Add by Ravi kumar for Auto Allocation and reallocation after split or change order on 24/11/2016
                        bCheckAutoAllocation = OrderDataProviderInstance.Update_AutoAllocationFactoryUnit_InOrder(order.OrderID);

                        // ----------------------Edit By surendra for Split Order and delete split history table-----------------------------------------------------------------//
                        this.WorkflowControllerInstance.SplitOrder_FromOrderID(order.OrderID);
                        //------------------------End---------------------------------------------------------------------------------------------//

                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return success;
            }
        }

        public void schedulerRun(string STYLEID, DateTime FromDate, DateTime ToDate, int ClientID, int DateType, int UserId, int StatusMode, int StatusModeSequence, int OrderBy1, int OrderBy2, int OrderBy3, int OrderBy4, string OrderDetailIds, int BuyingHouseId, int unintID)
        {
            int orderID;
            int Quantity;
            int styleID;
            int costingID;
            DateTime exfactory;
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_orders_get_orders_basic_info_Scheduler_ForNewOrder";
                    // string cmdText = "sp_orders_get_orders_basic_info_Scheduler_ForApprovetoEX";
                    //  string cmdText = "sp_or";
                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 180;
                    DataSet dsorderDetail = new DataSet();
                    SqlParameter param;
                    param = new SqlParameter("@SearchText", SqlDbType.VarChar);
                    param.Value = STYLEID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    param = new SqlParameter("@FromDate", SqlDbType.DateTime);
                    if (FromDate != DateTime.MinValue)
                    {
                        param.Value = FromDate;
                    }
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ToDate", SqlDbType.DateTime);
                    if (ToDate != DateTime.MinValue)
                    {
                        param.Value = ToDate;
                    }

                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@ClientID", SqlDbType.Int);
                    param.Value = ClientID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    // Edit by surendra on 20 may 2013
                    param = new SqlParameter("@UnitId", SqlDbType.Int);
                    param.Value = unintID;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@DateType", SqlDbType.Int);
                    param.Value = DateType;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@UserId", SqlDbType.Int);
                    param.Value = UserId;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StatusMode", SqlDbType.Int);
                    param.Value = StatusMode;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@StatusModeSequence", SqlDbType.Int);
                    param.Value = StatusModeSequence;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderBy1", SqlDbType.Int);
                    param.Value = OrderBy1;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderBy2", SqlDbType.Int);
                    param.Value = OrderBy2;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@OrderBy3", SqlDbType.Int);
                    param.Value = OrderBy3;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@OrderBy4", SqlDbType.Int);
                    param.Value = OrderBy4;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);


                    param = new SqlParameter("@OrderDetailIds", SqlDbType.VarChar);
                    param.Value = OrderDetailIds;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);

                    param = new SqlParameter("@BuyingHouseId", SqlDbType.Int);
                    param.Value = 0;
                    param.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(param);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsorderDetail);
                    cnx.Close();
                    if (dsorderDetail.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt = dsorderDetail.Tables[0];



                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {

                                exfactory = (dr["exfactory"] != DBNull.Value) ? Convert.ToDateTime(dr["exfactory"]) : DateTime.MinValue;
                                styleID = Convert.ToInt32(dr["StyleID"]);
                                costingID = (dr["CostingId"] == DBNull.Value) ? 0 : Convert.ToInt32(dr["CostingId"]);
                                orderID = Convert.ToInt32(dr["OrderID"]);
                                Quantity = Convert.ToInt32(dr["Quantity"]);
                                SqlTransaction transaction = null;
                                string cmdTextinsert = "sp_update_PCDate_ForScheduler";
                                // string cmdTextinsert = "sp_update_PCDate_ForScheduler_AfterApproveToEx";


                                if (cnx.State != ConnectionState.Open)
                                    cnx.Open();

                                SqlCommand cmd1 = new SqlCommand(cmdTextinsert, cnx);

                                cmd1.CommandType = CommandType.StoredProcedure;
                                cmd1.CommandTimeout = 180;
                                cmd1.Transaction = transaction;
                                SqlParameter param1;

                                param1 = new SqlParameter("@styleID", SqlDbType.Int);
                                param1.Value = styleID;

                                param1.Direction = ParameterDirection.Input;
                                cmd1.Parameters.Add(param1);

                                param1 = new SqlParameter("@orderID", SqlDbType.Int);
                                param1.Value = orderID;
                                param1.Direction = ParameterDirection.Input;
                                cmd1.Parameters.Add(param1);

                                param1 = new SqlParameter("@costingID", SqlDbType.Int);
                                param1.Value = costingID;
                                param1.Direction = ParameterDirection.Input;
                                cmd1.Parameters.Add(param1);

                                param1 = new SqlParameter("@exfactory", SqlDbType.DateTime);
                                param1.Value = exfactory;
                                param1.Direction = ParameterDirection.Input;
                                cmd1.Parameters.Add(param1);

                                param1 = new SqlParameter("@Quantity", SqlDbType.Int);
                                param1.Value = Quantity;

                                param1.Direction = ParameterDirection.Input;
                                cmd1.Parameters.Add(param1);

                                cmd1.ExecuteNonQuery();


                            }
                        }
                    }

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

        }

        //public bool AddOrder(Order order)
        //{
        //    if (order.OrderID == -1)
        //    {
        //        bool success = OrderDataProviderInstance.InsertOrder(order);

        //        try
        //        {
        //            if (success)
        //            {
        //                foreach (OrderDetail orderDetail in order.OrderBreakdown)
        //                {
        //                    // Initiate Workflow
        //                    if (orderDetail.OrderDetailID > 0)
        //                    {
        //                        WorkflowInstance instance = WorkflowControllerInstance.CreateWorkflow(order.OrderID, orderDetail.OrderDetailID, order.Style.StyleID, StatusMode.NEWORDER);

        //                        if (instance == null || instance.WorkflowInstanceID == -1)
        //                            continue;

        //                        WorkflowInstanceDetail task = WorkflowControllerInstance.CreateTask(StatusMode.NEWORDER, instance.WorkflowInstanceID, DateTime.Today);
        //                        WorkflowControllerInstance.CompleteTask(task, LoggedInUser.UserData.UserID);

        //                        WorkflowControllerInstance.CreateTask(StatusMode.ORDERCONFIRMED, instance.WorkflowInstanceID, order.OrderDate.AddDays(3));
        //                    }
        //                }

        //                NotificationControllerInstance.SendEmailForPendingBIPLAgreement(order, true);
        //                //this.NotificationControllerInstance.SendEmailForCreateOrder(order, true);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            //NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
        //        }

        //        return success;
        //    }
        //    else
        //    {
        //        bool success = OrderDataProviderInstance.UpdateOrder(order);

        //        try
        //        {
        //            //System.Diagnostics.Debugger.Break();
        //            if (success)
        //            {
        //                foreach (OrderDetail orderDetail in order.OrderBreakdown)
        //                {
        //                    // Update workflow
        //                    WorkflowInstance instance = WorkflowControllerInstance.GetInstance(order.Style.StyleID,
        //                                                                                       order.OrderID,
        //                                                                                       orderDetail.OrderDetailID);

        //                    if (instance == null || instance.WorkflowInstanceID <= 0)
        //                    {
        //                        if (orderDetail.OrderDetailID > 0 && orderDetail.isDeleted == 0)
        //                        {
        //                            // Initiate Workflow
        //                            instance = WorkflowControllerInstance.CreateWorkflow(order.OrderID, orderDetail.OrderDetailID, order.Style.StyleID, StatusMode.NEWORDER);

        //                            if (instance == null || instance.WorkflowInstanceID == -1)
        //                                continue;

        //                            WorkflowInstanceDetail task = WorkflowControllerInstance.CreateTask(StatusMode.NEWORDER, instance.WorkflowInstanceID, DateTime.Today);
        //                            WorkflowControllerInstance.CompleteTask(task, LoggedInUser.UserData.UserID);

        //                            WorkflowControllerInstance.CreateTask(StatusMode.ORDERCONFIRMED, instance.WorkflowInstanceID, order.OrderDate.AddDays(3));
        //                        }
        //                        else
        //                        {
        //                            continue;
        //                        }
        //                    }

        //                    List<WorkflowInstanceDetail> tasks =
        //                        WorkflowControllerInstance.GetCurrentPendingTasks(instance.WorkflowInstanceID);

        //                    foreach (WorkflowInstanceDetail task in tasks)
        //                    {
        //                        if (task.StatusModeID == (int)StatusMode.ORDERCONFIRMED &&
        //                            task.AssignedToDesignation == LoggedInUser.UserData.Designation &&
        //                            ((order.ApprovedByMerchandiserManager >= 1 &&
        //                              LoggedInUser.UserData.Designation == Designation.BIPL_Merchandising_Manager) ||
        //                             (order.ApprovedBySalesBIPL >= 1 &&
        //                              LoggedInUser.UserData.Designation == Designation.BIPL_Sales_Manager)))
        //                        {
        //                            if (tasks.Count == 1)
        //                            {
        //                                WorkflowControllerInstance.CompleteTask(task, LoggedInUser.UserData.UserID);

        //                                WorkflowControllerInstance.CreateTask(StatusMode.WORKINGSCREATED,
        //                                                                      instance.WorkflowInstanceID,
        //                                                                      order.OrderDate.AddDays(3));
        //                            }
        //                            else
        //                            {
        //                                WorkflowInstanceDetail newTask = new WorkflowInstanceDetail();
        //                                newTask.ActionDate = DateTime.Today;
        //                                newTask.AssignedTo = new User();
        //                                newTask.AssignedTo.UserID = LoggedInUser.UserData.UserID;
        //                                newTask.ETA = task.ETA;
        //                                newTask.ActionID = task.ActionID;
        //                                newTask.StatusModeID = task.StatusModeID;
        //                                newTask.WorkflowInstance = new WorkflowInstance();
        //                                newTask.WorkflowInstance.WorkflowInstanceID = instance.WorkflowInstanceID;
        //                                WorkflowControllerInstance.InsertWorkflowInstanceDetail(newTask);
        //                            }
        //                        }
        //                    }

        //                    if (order.Style.StyleID != instance.Style.StyleID)
        //                    {
        //                        instance.Style.StyleID = order.Style.StyleID;
        //                        WorkflowControllerInstance.UpdateWorkflowInstanceByID(instance);
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            //NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
        //        }
        //        return success;
        //    }
        //}

        // update by Ravi kumar for OB and Risk task ON 31/7/2015
        public string AddOrderLimitation(OrderLimitation orderLimitation)
        {
            bool success = OrderDataProviderInstance.InsertOrderLimitation(orderLimitation);
            try
            {
                //System.Diagnostics.Debugger.Break();
                // TODO: Heaving call, avoid it
                if (success)
                {
                    iKandi.Common.Order order = GetOrder(orderLimitation.OrderID);

                    foreach (OrderDetail orderDetail in order.OrderBreakdown)
                    {
                        if (orderDetail.OrderDetailID > 0)
                        {
                            if (Convert.ToBoolean(orderLimitation.AccessoriesApprovedByMgr))
                            {
                                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Limitation_Accessories, this.LoggedInUser.UserData.UserID);
                            }
                            if (Convert.ToBoolean(orderLimitation.FabricApprovedByMgr))
                            {
                                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Limitation_Fabric, this.LoggedInUser.UserData.UserID);
                            }
                        }
                        //// Edit by Nikhil
                        // Update workflow
                        //WorkflowInstance instance = WorkflowControllerInstance.GetInstance(order.Style.StyleID, orderLimitation.OrderID, orderDetail.OrderDetailID);

                        //if (instance == null || instance.WorkflowInstanceID == -1)
                        //  continue;

                        //List<WorkflowInstanceDetail> tasks = WorkflowControllerInstance.GetCurrentPendingTasks(instance.WorkflowInstanceID);

                        //foreach (WorkflowInstanceDetail task in tasks)
                        //{
                        //  if (task.StatusModeID == (int)StatusMode.LIVE && task.ApplicationModule.ApplicationModuleID == (int)AppModule.ORDER_LIMITATION_FORM && task.AssignedToDesignation == LoggedInUser.UserData.Designation && ((task.AssignedToDesignation == Designation.BIPL_Accessory_Manager && orderLimitation.AccessoriesApprovedByMgr >= 1) || (task.AssignedToDesignation == Designation.BIPL_Fabrics_Manager && orderLimitation.FabricApprovedByMgr >= 1) || (task.AssignedToDesignation == Designation.BIPL_Production_Manager && orderLimitation.ProductionApprovedByMgr >= 1) || (task.AssignedToDesignation == Designation.BIPL_Merchandising_Manager && orderLimitation.MerchandisingApprovedByMgr >= 1)))
                        //  {
                        //    if (tasks.Count == 1)
                        //    {
                        //      WorkflowControllerInstance.CompleteTask(task, LoggedInUser.UserData.UserID);
                        //      //this.NotificationControllerInstance.SubOrderStatusModeLive(order, true);

                        //      if (OrderDataProviderInstance.IsOrderSealedOff(orderDetail.OrderDetailID))
                        //      {
                        //        WorkflowInstanceDetail stctask = WorkflowControllerInstance.CreateTask(StatusMode.STCUNALLOCATED, instance.WorkflowInstanceID, orderDetail.STCUnallocated);
                        //        WorkflowControllerInstance.CompleteTask(stctask, LoggedInUser.UserData.UserID);
                        //        instance.CurrentStatus.StatusModeID = (int)StatusMode.STCUNALLOCATED;
                        //        WorkflowControllerInstance.UpdateWorkflowInstance(instance);

                        //        WorkflowControllerInstance.CreateTask(StatusMode.ALLOCATED, instance.WorkflowInstanceID, orderDetail.STCUnallocated.AddDays(3));
                        //        //this.NotificationControllerInstance.StcUnallocated(order,orderDetail, true);
                        //      }
                        //      else
                        //      {
                        //        WorkflowControllerInstance.CreateTask(StatusMode.STCUNALLOCATED, instance.WorkflowInstanceID, orderDetail.STCUnallocated);
                        //      }
                        //    }
                        //    else
                        //    {
                        //      WorkflowInstanceDetail newTask = new WorkflowInstanceDetail();
                        //      newTask.ActionDate = DateTime.Today;
                        //      newTask.AssignedTo = new User();
                        //      newTask.AssignedTo.UserID = LoggedInUser.UserData.UserID;
                        //      newTask.ETA = task.ETA;
                        //      newTask.ActionID = task.ActionID;
                        //      newTask.StatusModeID = task.StatusModeID;
                        //      newTask.WorkflowInstance = new WorkflowInstance();
                        //      newTask.WorkflowInstance.WorkflowInstanceID = instance.WorkflowInstanceID;
                        //      WorkflowControllerInstance.InsertWorkflowInstanceDetail(newTask);
                        //    }
                        //  }
                        //}
                        ////
                    }
                }
            }
            //}
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //  NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
            //}

            return "";
        }

        public string GetSketch(int orderDetailid, string path, int id)
        {
            return OrderDataProviderInstance.GetSketch(orderDetailid, path, id);
        }


        public bool UpdateSketch(int orderDetailid, string path, int id)
        {
            return OrderDataProviderInstance.UpdateSketch(orderDetailid, path, id);
        }
        public bool Update_AccountMangerID(int OrderID)
        {
            return OrderDataProviderInstance.Update_AccountMangerID(OrderID);
        }


        public List<FeedingClass> GetFeeding_Report()
        {
            return OrderDataProviderInstance.GetFeeding_Report();
        }

        public List<FeedingClass> GetUpcomingFeeding_Report(string todate)
        {
            return OrderDataProviderInstance.GetUpcomingFeeding_Report(todate);
        }

        public string InsertFeedingSelection(string extarget, string exactual, string exdelay, string pcdtarget, string pcdactual, string pcddelay, string accbihtarget, string accbihactual, string accbihdelay,
            string fabbihtarget, string fabbihactual, string fabbihdelay, string Toptarget, string Topactual, string Topdelay, string Stctarget, string Stcactual, string Stcdelay,
            string Protarget, string Proactual, string Prodelay, string Apptarget, string Appactual, string Appdelay, string sessionID)
        {
            return OrderDataProviderInstance.InsertFeedingSelection(extarget, exactual, exdelay, pcdtarget, pcdactual, pcddelay, accbihtarget, accbihactual, accbihdelay, fabbihtarget, fabbihactual, fabbihdelay,
                Toptarget, Topactual, Topdelay, Stctarget, Stcactual, Stcdelay, Protarget, Proactual, Prodelay, Apptarget, Appactual, Appdelay, sessionID);
        }

        public string InsertFeedingSelection_UP(string extarget, string exactual, string pcdtarget, string pcdactual, string accbihtarget, string accbihactual, string fabbihtarget, string fabbihactual,
            string Toptarget, string Topactual, string Stctarget, string Stcactual, string Protarget, string Proactual, string Apptarget, string Appactual, string todate, string sessionID)
        {
            return OrderDataProviderInstance.InsertFeedingSelection_UP(extarget, exactual, pcdtarget, pcdactual, accbihtarget, accbihactual, fabbihtarget, fabbihactual,
                 Toptarget, Topactual, Stctarget, Stcactual, Protarget, Proactual, Apptarget, Appactual, todate, sessionID);
        }


        public iKandi.Common.Order GetOrder(int orderID)
        {
            iKandi.Common.Order objOrder = OrderDataProviderInstance.GetOrderById(orderID);
            if (orderID > -1)
                foreach (OrderDetail od in objOrder.OrderBreakdown)
                {
                    od.ExFactoryColor = CommonHelper.GetExFactoryColor(Convert.ToDateTime(od.ExFactory),
                                                                       Convert.ToDateTime(od.DC),
                                                                       Convert.ToInt32(od.Mode));
                    od.ParentOrder.Costing.CurrencySign = objOrder.Costing.CurrencySign;
                }
            return objOrder;
        }

        public iKandi.Common.Order GetOrderById(int orderID)
        {
            return OrderDataProviderInstance.GetOrderById(orderID);
        }

        public int GetAuthenticatCutting(int OrderId)
        {
            return OrderDataProviderInstance.GetAuthenticatCutting(OrderId);
        }

        public iKandi.Common.Order GetOrderOrderForm(int orderId)
        {
            iKandi.Common.Order objOrder = OrderDataProviderInstance.GetOrderByIdOrderForm(orderId);
            if (orderId > -1)
                foreach (OrderDetail od in objOrder.OrderBreakdown)
                {
                    od.ExFactoryColor = CommonHelper.GetExFactoryColor(Convert.ToDateTime(od.ExFactory),
                                                                       Convert.ToDateTime(od.DC),
                                                                       Convert.ToInt32(od.Mode));
                    od.ParentOrder.Costing.CurrencySign = objOrder.Costing.CurrencySign;
                }
            return objOrder;
        }
        public string CheckExistBuyingHouse(int orderId)
        {
            return OrderDataProviderInstance.CheckExistBuyingHouse(orderId);
        }
        public List<OrderDetail> GetOrder(string styleCodeVersion, int deptId)
        {
            return OrderDataProviderInstance.GetOrder(styleCodeVersion, deptId);
        }

        public DataTable GetOrderDetailInfoSimulation(string orderDetailIdList, string orderQuantity, string sortType)
        {
            //simulation on order form currently put on hold Manisha 12th May 
            DataTable dtSplit = null;
            //this.OrderDataProviderInstance.GetOrderDetailInfoSimulation(OrderDetailIDList,OrderQuantity,sortType);
            return dtSplit;
        }

        /// <summary>
        ///   Need not to use these method directlty
        ///   Call GetOrder(int orderID) method to complete data
        /// </summary>
        /// <param name = "orderId"></param>
        /// <returns></returns>
        public List<OrderDetail> GetOrderDetail(int orderId)
        {
            return new List<OrderDetail>();
            // return this.OrderDataProviderInstance.GetOrderDetailById(orderID);
        }
        // create function for getting repeat order's by sushil on date 7/10/2014
        public List<OrderDetail> Getrepeatorder(string styleno)
        {
            return OrderDataProviderInstance.Getrepeatorder(styleno);
        }

        /// <summary>
        ///   Need not to use these method directlty
        ///   Call GetOrder(int orderID) method to complete data
        /// </summary>
        /// <param name="orderDetailId"></param>
        /// <returns></returns>
        public List<OrderDetailSizes> GetOrderDetailSizes(int orderDetailId)
        {
            //return new List<OrderDetailSizes>();
            return OrderDataProviderInstance.GetOrderDetailSize(orderDetailId);
        }

        public List<OrderLimitation> GetOrderLimitation(int orderLimitationId)
        {
            return OrderDataProviderInstance.GetOrderLimitation(orderLimitationId);
        }

        //public bool UpdateOrder(Order order)
        //{
        //    this.OrderDataProviderInstance.UpdateOrder(order);
        //    return true;
        //}

        //public bool UpdateOrderDetail(OrderDetail orderDetail)
        //{
        //    this.OrderDataProviderInstance.UpdateOrderDetail(orderDetail);
        //    return true;
        //}

        // update by Ravi kumar for OB and Risk task ON 31/7/2015
        public string UpdateOrderLimitation(OrderLimitation orderLimitation)
        {

            bool success = OrderDataProviderInstance.UpdateOrderLimitation(orderLimitation);

            try
            {
                if (success)
                {
                    iKandi.Common.Order order = GetOrder(orderLimitation.OrderID);
                    //string OBRiskDone = "";
                    //OBRiskDone = WorkflowControllerInstance.IsOBRiskDone(order.Style.StyleID, orderLimitation.OrderID, "LIMITATION");
                    //if (OBRiskDone == "")
                    //{
                    foreach (OrderDetail orderDetail in order.OrderBreakdown)
                    {
                        if (orderDetail.OrderDetailID > 0)
                        {
                            if (Convert.ToBoolean(orderLimitation.AccessoriesApprovedByMgr))
                            {
                                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Limitation_Accessories, this.LoggedInUser.UserData.UserID);
                                int iResult = WorkflowControllerInstance.Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(order.OrderID, orderDetail.OrderDetailID, TaskMode.LIVE, this.LoggedInUser.UserData.UserID);
                            }
                            if (Convert.ToBoolean(orderLimitation.FabricApprovedByMgr))
                            {
                                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Limitation_Fabric, this.LoggedInUser.UserData.UserID);
                                int iResult = WorkflowControllerInstance.Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(order.OrderID, orderDetail.OrderDetailID, TaskMode.LIVE, this.LoggedInUser.UserData.UserID);
                            }
                        }
                        WorkflowInstance instance1 = WorkflowControllerInstance.GetInstance(order.Style.StyleID, orderLimitation.OrderID,
                                                                                           orderDetail.OrderDetailID);

                        List<WorkflowInstanceDetail> tasks = WorkflowControllerInstance.GetCurrentPendingTasks(instance1.WorkflowInstanceID);
                        foreach (WorkflowInstanceDetail task in tasks)
                        {
                            WorkflowInstanceDetail newTask = new WorkflowInstanceDetail();
                            newTask.ActionDate = DateTime.Today;
                            newTask.AssignedTo = new User();
                            newTask.AssignedTo.UserID = LoggedInUser.UserData.UserID;
                            newTask.ETA = task.ETA;
                            newTask.ActionID = task.ActionID;
                            newTask.StatusModeID = task.StatusModeID;
                            newTask.WorkflowInstance = new WorkflowInstance();
                            newTask.WorkflowInstance.WorkflowInstanceID = instance1.WorkflowInstanceID;
                            WorkflowControllerInstance.InsertWorkflowInstanceDetail(newTask);
                        }
                        //// Edit by Nikhil
                        // Update workflow
                        //WorkflowInstance instance = WorkflowControllerInstance.GetInstance(order.Style.StyleID, orderLimitation.OrderID,
                        //                                                                   orderDetail.OrderDetailID);

                        //if (instance == null || instance.WorkflowInstanceID == -1)
                        //  continue;

                        //List<WorkflowInstanceDetail> tasks =
                        //    WorkflowControllerInstance.GetCurrentPendingTasks(instance.WorkflowInstanceID);

                        //foreach (WorkflowInstanceDetail task in tasks)
                        //{
                        //  if (task.StatusModeID == (int)StatusMode.LIVE &&
                        //      task.ApplicationModule.ApplicationModuleID == (int)AppModule.ORDER_LIMITATION_FORM &&
                        //      task.AssignedToDesignation == LoggedInUser.UserData.Designation
                        //      &&
                        //      ((task.AssignedToDesignation == Designation.BIPL_Accessory_Manager &&
                        //        orderLimitation.AccessoriesApprovedByMgr >= 1) ||
                        //       (task.AssignedToDesignation == Designation.BIPL_Fabrics_Manager &&
                        //        orderLimitation.FabricApprovedByMgr >= 1)
                        //    //||
                        //    //(task.AssignedToDesignation == Designation.BIPL_Production_Manager &&
                        //    // orderLimitation.ProductionApprovedByMgr >= 1) ||
                        //    //(task.AssignedToDesignation == Designation.BIPL_Merchandising_Manager &&
                        //    // orderLimitation.MerchandisingApprovedByMgr >= 1)
                        //      ))
                        //  {
                        //    if (tasks.Count == 2)
                        //    {
                        //      if (OBRiskDone == "")
                        //      {
                        //        WorkflowControllerInstance.CompleteTask(task, LoggedInUser.UserData.UserID);
                        //        //this.NotificationControllerInstance.SubOrderStatusModeLive(order, true);

                        //        if (OrderDataProviderInstance.IsOrderSealedOff(orderDetail.OrderDetailID))
                        //        {
                        //          WorkflowInstanceDetail stctask =
                        //              WorkflowControllerInstance.CreateTask(StatusMode.STCUNALLOCATED,
                        //                                                    instance.WorkflowInstanceID,
                        //                                                    orderDetail.STCUnallocated);
                        //          WorkflowControllerInstance.CompleteTask(stctask, LoggedInUser.UserData.UserID);
                        //          instance.CurrentStatus.StatusModeID = (int)StatusMode.STCUNALLOCATED;
                        //          WorkflowControllerInstance.UpdateWorkflowInstance(instance);
                        //          WorkflowControllerInstance.CreateTask(StatusMode.ALLOCATED,
                        //                                                instance.WorkflowInstanceID,
                        //                                                orderDetail.STCUnallocated.AddDays(3));
                        //          //this.NotificationControllerInstance.StcUnallocated(order,orderDetail, true);
                        //        }
                        //        else
                        //        // changes by surendra on 02/07/2013
                        //        {
                        //          WorkflowControllerInstance.CreateTask(StatusMode.STCUNALLOCATED,
                        //                                                instance.WorkflowInstanceID,
                        //                                                orderDetail.STCUnallocated);
                        //          WorkflowControllerInstance.CreateTask(StatusMode.ALLOCATED,
                        //                                                instance.WorkflowInstanceID,
                        //                                                orderDetail.STCUnallocated);
                        //        }

                        //      }
                        //    }
                        //    else
                        //    {
                        //      WorkflowInstanceDetail newTask = new WorkflowInstanceDetail();
                        //      newTask.ActionDate = DateTime.Today;
                        //      newTask.AssignedTo = new User();
                        //      newTask.AssignedTo.UserID = LoggedInUser.UserData.UserID;
                        //      newTask.ETA = task.ETA;
                        //      newTask.ActionID = task.ActionID;
                        //      newTask.StatusModeID = task.StatusModeID;
                        //      newTask.WorkflowInstance = new WorkflowInstance();
                        //      newTask.WorkflowInstance.WorkflowInstanceID = instance.WorkflowInstanceID;
                        //      WorkflowControllerInstance.InsertWorkflowInstanceDetail(newTask);
                        //    }
                        //  }
                        //}
                        ////
                    }
                    //if (OBRiskDone == "")
                    //{
                    //  int WorkflowDone = WorkflowControllerInstance.WorkflowTask_OB_Risk(order.Style.StyleID, orderLimitation.OrderID, "LIMITATION");
                    //}
                }
            }

            //}
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //  NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
            //}            

            return "";
        }


        //public bool DeleteOrderDetail(OrderDetail orderDetail)
        //{
        //    this.OrderDataProviderInstance.DeleteOrderDetail(orderDetail);
        //    return true;
        //}

        public bool DeleteOrderDetailSizes_new(int OrderDetailSizeID, int OrderDetailID)
        {
            this.OrderDataProviderInstance.DeleteOrderDetailSizes_new(OrderDetailSizeID, OrderDetailID);
            return true;
        }

        public string GetNewSerialNumber(int clientId)
        {
            return OrderDataProviderInstance.GetNewSerialNumber(clientId);
        }
        public string GetNewDescription(int styleid)
        {
            return OrderDataProviderInstance.GetNewDescription(styleid);
        }

        public int GetClientId(string styleNumber)
        {
            return OrderDataProviderInstance.GetClientId(styleNumber);
        }
        public int GetMOQAStatusHistory(string q, string DeptID)
        {
            return this.ReportDataProviderInstance.GetMOQAStatusHistory(q, DeptID);
        }
        public int GetStyleIdByStyleNumber(string StyleNumber)
        {
            return OrderDataProviderInstance.GetStyleIdByStyleNumber(StyleNumber);
        }
        public string GetMessage(int OrderID)
        {
            return OrderDataProviderInstance.GetMessage(OrderID);
        }


        //public int GetQuantityByOrderID(int orderId)
        //{
        //  OrderDataProvider provider = new OrderDataProvider();
        //  return provider.GetQuantityByOrderID(orderId);
        //}

        public int GetCut_Avg(int OrderDetailsID, string CheckInlinecut)
        {
            return OrderDataProviderInstance.GetCut_Avg(OrderDetailsID, CheckInlinecut);
        }

        public iKandi.Common.Order GetInfoByStyleNumber(string styleNumber)
        {
            return OrderDataProviderInstance.GetInfoByStyleNumber(styleNumber);
        }
        public string GetAddressByClientId(int clientId)
        {
            return OrderDataProviderInstance.GetAddressByClientId(clientId);
        }

        public iKandi.Common.Order GetIkandiPriceByMode(string mode, int costingId, string status)
        {
            return OrderDataProviderInstance.GetIkandiPriceByMode(mode, costingId, status);

        }
        public bool UpdateMDA(int OrderDetailsID, string MDA)
        {
            OrderDataProviderInstance.UpdateMDA(OrderDetailsID, MDA);
            return true;
        }
        public bool IsCheckLinePlanStichStart(int LinePlanFrameID)
        {
            OrderDataProviderInstance.IsCheckLinePlanStichStart(LinePlanFrameID);
            return true;
        }

        public bool InsertInHouseHistory(int orderDetailId, int accessoryWorkingDetailId,
                                                            int quantity, int percentInHouse)
        {
            OrderDataProviderInstance.InsertInHouseHistory(orderDetailId, accessoryWorkingDetailId,
                                                                               quantity, percentInHouse);
            return true;
        }
        public bool UpdatePlanneddate(int OrderDetailsID, string Planneddate)
        {
            OrderDataProviderInstance.UpdatePlanneddate(OrderDetailsID, Planneddate);
            return true;
        }
        public bool UpdateAccesoriesApprovedDate(int AccessoryWorkingDetailID, int OrderDetailsID, string ApprovedDate)
        {
            OrderDataProviderInstance.UpdateAccesoriesApprovedDate(AccessoryWorkingDetailID, OrderDetailsID, ApprovedDate);
            return true;
        }
        public bool UpdatePatternSampleDate(int OrderID, int StyleId, string PatternSampleDate, string field, int OrderDetailID)
        {
            OrderDataProviderInstance.UpdatePatternSampleDate(OrderID, StyleId, PatternSampleDate, field, OrderDetailID);
            return true;
        }
        public bool UpdateShipmentOfferDate(int OrderDetailsID, string Shipmentdate, string UserID)
        {
            OrderDataProviderInstance.UpdateShipmentOfferDate(OrderDetailsID, Shipmentdate, UserID);
            CloseTaskforShipmentPending(OrderDetailsID, Shipmentdate, UserID);

            return true;
        }

        public void CloseTaskforShipmentPending(int OrderDetailsID, string Shipmentdate, string UserID)
        {
            DataSet dsshipmentoffDate = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {

                string cmdText = "sp_Get_Shipment_OfferDate";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;

                SqlParameter paramIn;

                paramIn = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                paramIn.Value = OrderDetailsID;
                cmd.Parameters.Add(paramIn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(dsshipmentoffDate);
                if (dsshipmentoffDate.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToDateTime(dsshipmentoffDate.Tables[0].Rows[0]["ShipmentOfferDate"].ToString()) != null && Convert.ToDateTime(dsshipmentoffDate.Tables[0].Rows[0]["ShipmentOfferDate"].ToString()) != DateTime.MinValue)
                    {
                        UserTask task = new UserTask();
                        task.Type = UserTaskType.ShipmentOffer;
                        task.ActionDate = DateTime.Now;

                        task.Style = new Style();
                        task.Style.StyleID = 0;

                        task.OrderDetail = new OrderDetail();
                        task.OrderDetail.OrderDetailID = OrderDetailsID;
                        task.ActionedBy = Convert.ToInt32(UserID);
                        UserTaskDataProviderInstance.UpdateUserTaskShipment(task);
                    }
                }
            }
        }

        public bool UpdateCuttingSheetDate(int OrderID, int StyleId, string CuttingSheetDate, int orderDetails_ID, string field)
        {
            OrderDataProviderInstance.UpdateCuttingSheetDate(OrderID, StyleId, CuttingSheetDate, orderDetails_ID, field);
            return true;
        }
        public bool UpdatePCSStitchPackedEmb(int OrderDetailsID, int StitchingDetailID, int PcsSent, int PcsReceived, int PcsPackedToday, int OverallPcsPacked, int OverallPcsStitched, int Quantity, int TotalPcsStitchedToday, DateTime ExpectedFinishDate, bool IsStitchingComplete)
        {
            if ((OverallPcsStitched * 100) / Quantity >= 50)
            {
                var task = new UserTask();
                task.AssignedToDesigntation = (int)Designation.BIPL_Production_FactoryManager;
                task.CreatedBy = LoggedInUser.UserData.UserID;
                task.CreatedOn = DateTime.Now;
                task.ETA = DateTime.Now.AddDays(3);
                task.Style = new Style();
                task.Style.StyleID = 0;
                task.OrderDetail = new OrderDetail();
                task.OrderDetail.OrderDetailID = OrderDetailsID;
                task.Type = UserTaskType.ShipmentOffer;
                task.IntField3 = 0;
                UserTaskController UserTaskControllerInstance = new UserTaskController();
                UserTaskControllerInstance.InsertUserTaskShipment(task);


            }
            //this.AddManageOrderC
            this.AddStitchingDetails(OrderDetailsID, StitchingDetailID, PcsSent, PcsReceived, PcsPackedToday, OverallPcsPacked, OverallPcsStitched, Quantity, TotalPcsStitchedToday, ExpectedFinishDate, IsStitchingComplete);

            //  OrderDataProviderInstance.UpdateProductionFileDate(OrderID, StyleId, ProductionFileDate);
            return true;
        }
        public int AddStitchingDetails(int OrderDetailsID, int StitchingDetailID, int PcsSent, int PcsReceived, int PcsPackedToday, int OverallPcsPacked, int OverallPcsStitched, int Quantity, int TotalPcsStitchedToday, DateTime ExpectedFinishDate, bool IsStitchingComplete)
        {
            // System.Diagnostics.Debugger.Break();

            int StitchingDetailOutID = 0;

            if (StitchingDetailID <= 0)
            {
                StitchingDetailOutID = OrderDataProviderInstance.InsertStitchingDetails(OrderDetailsID, TotalPcsStitchedToday, OverallPcsStitched, PcsSent, PcsReceived, PcsPackedToday, OverallPcsPacked, ExpectedFinishDate, IsStitchingComplete);

                if (PcsPackedToday > 0)
                {
                    OrderDataProviderInstance.InsertManageOrderPackingHistory(OrderDetailsID,
                                                                              PcsPackedToday,
                                                                              DateTime.Today);
                }
            }
            else
            {
                StitchingDetailOutID = OrderDataProviderInstance.UpdateStitchingDetails(StitchingDetailID, OrderDetailsID, PcsSent, PcsReceived, PcsPackedToday, OverallPcsPacked);
                if (PcsPackedToday > 0)
                {
                    OrderDataProviderInstance.InsertManageOrderPackingHistory(OrderDetailsID,
                                                                              PcsPackedToday,
                                                                              DateTime.Today);
                }
            }

            return StitchingDetailOutID;
        }
        public bool UpdateOnlyPacking(int OrderDetailsID, int Pcspacked, int Packingpercent, int PackingBalance, int TodayPacked)
        {

            //this.AddManageOrderC
            this.AddPackingDetails(OrderDetailsID, Pcspacked, Packingpercent, PackingBalance, TodayPacked);

            //  OrderDataProviderInstance.UpdateProductionFileDate(OrderID, StyleId, ProductionFileDate);
            return true;
        }
        public int AddPackingDetails(int OrderDetailsID, int Pcspacked, int Packingpercent, int PackingBalance, int TodayPacked)
        {
            // System.Diagnostics.Debugger.Break();



            OrderDataProviderInstance.InsertUpdatePackingDetails(OrderDetailsID, TodayPacked, Packingpercent, PackingBalance);
            OrderDataProviderInstance.InsertManageOrderPackingHistory(OrderDetailsID,
                                                                          TodayPacked,
                                                                          DateTime.Today);



            return 1;
        }
        public bool UpdatePCSStitch(int OrderDetailsID, int Allcut, int StitchPicesPercent, int StitchPicesBalance, int StitchToday)
        {

            OrderDataProviderInstance.UpdatePCSStitch(OrderDetailsID, Allcut, StitchPicesPercent, StitchPicesBalance, StitchToday);
            OrderDataProviderInstance.UpdatePCSStitch_history(OrderDetailsID, StitchToday);
            return true;
        }
        public bool UpdateCutIssued(int StyleId, int OrderID, int Quantity, int OrderDetailsID, int CuttingSheetId, int CuttingDetailID, int PcsIssued, int CutPiecesPercent, int CutpiecesBallance, int TodayPcsIssued, int BalanceStitched)
        {
            OrderDataProviderInstance.UpdateCutIssued(StyleId, OrderID, Quantity, OrderDetailsID, CuttingSheetId, CuttingDetailID, PcsIssued, CutPiecesPercent, CutpiecesBallance, TodayPcsIssued, BalanceStitched);
            OrderDataProviderInstance.UpdateCutIssued_History(OrderDetailsID, TodayPcsIssued);

            return true;
        }
        public bool UpdateOnlyEmbPices(int OrderDetailsID, int Embpieces, int EmbPicesPercent, int EmbPicesBalance, int TodayEMB)
        {
            this.UpdateOnlyEmbPices_Pices(OrderDetailsID, TodayEMB, EmbPicesPercent, EmbPicesBalance);
            this.insertEMB_History(OrderDetailsID, TodayEMB);
            return true;
        }
        public bool insertEMB_History(int OrderDetailID, int TodayEMB)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_manage_order_insert_emb_history";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter paramIn;

                paramIn = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                paramIn.Value = OrderDetailID;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@Date", SqlDbType.DateTime);
                paramIn.Value = DateTime.Today;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@TodayEMB", SqlDbType.Int);
                paramIn.Value = TodayEMB;
                cmd.Parameters.Add(paramIn);

                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return true;
        }
        public bool UpdateOnlyEmbPices_Pices(int OrderDetailsID, int Embpieces, int EmbPicesPercent, int EmbPicesBalance)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_Update_Emb_Pices";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter paramIn;

                paramIn = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                paramIn.Value = OrderDetailsID;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@Embpieces", SqlDbType.Int);
                paramIn.Value = Embpieces;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@EmbPicesPercent", SqlDbType.Int);
                paramIn.Value = EmbPicesPercent;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@EmbPicesBalance", SqlDbType.Int);
                paramIn.Value = EmbPicesBalance;
                cmd.Parameters.Add(paramIn);

                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return true;
        }
        public bool UpdateOnlyEmbIssues(int OrderDetailsID, int Embissued, int EmbIssuedPercent, int EmbIssuedBalance, int AllPacked)
        {
            this.UpdateOnlyEmbIssues_Issues(OrderDetailsID, AllPacked, EmbIssuedPercent, EmbIssuedBalance);
            this.insertEMBIssued_History(OrderDetailsID, AllPacked);
            return true;
        }
        public bool insertEMBIssued_History(int OrderDetailID, int AllPacked)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_manage_order_insert_emb_Issued_history";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter paramIn;

                paramIn = new SqlParameter("@OrderDetailID", SqlDbType.Int);
                paramIn.Value = OrderDetailID;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@Date", SqlDbType.DateTime);
                paramIn.Value = DateTime.Today;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@TodayEMBIssued", SqlDbType.Int);
                paramIn.Value = AllPacked;
                cmd.Parameters.Add(paramIn);

                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return true;
        }

        public bool UpdateOnlyEmbIssues_Issues(int OrderDetailsID, int Embissued, int EmbIssuedPercent, int EmbIssuedBalance)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_Update_Emb_Issues";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter paramIn;

                paramIn = new SqlParameter("@OrderDetailsID", SqlDbType.Int);
                paramIn.Value = OrderDetailsID;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@Embissued", SqlDbType.Int);
                paramIn.Value = Embissued;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@EmbIssuedPercent", SqlDbType.Int);
                paramIn.Value = EmbIssuedPercent;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@EmbIssuedBalance", SqlDbType.Int);
                paramIn.Value = EmbIssuedBalance;
                cmd.Parameters.Add(paramIn);

                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return true;
        }
        public iKandi.Common.Order GetOrderAccesories(int orderID)
        {
            iKandi.Common.Order objOrder = OrderDataProviderInstance.GetOrderAccesoriesId(orderID);
            if (objOrder.OrderBreakdown != null)
            {
                if (orderID > -1)
                    foreach (OrderDetail od in objOrder.OrderBreakdown)
                    {
                        od.ExFactoryColor = CommonHelper.GetExFactoryColor(Convert.ToDateTime(od.ExFactory),
                                                                           Convert.ToDateTime(od.DC),
                                                                           Convert.ToInt32(od.Mode));
                        od.ParentOrder.Costing.CurrencySign = objOrder.Costing.CurrencySign;
                    }
            }
            return objOrder;
        }



        public bool UpdateProductionFileDate(int OrderID, int StyleId, string ProductionFileDate)
        {
            OrderDataProviderInstance.UpdateProductionFileDate(OrderID, StyleId, ProductionFileDate);
            return true;
        }
        // Update By Ravi kumar ON 17/12/2014 For MO pcd change on Ex Factory change
        public bool UpdateExFactory(int OrderDetailsID, string ExFactory, string username)
        {
            OrderDataProviderInstance.UpdateExFactory(OrderDetailsID, ExFactory, username);
            return true;
        }
        //Added by shubhendu 2/03/2022
        public bool UpdateBiplPriceMO(int OrderDetailsID, float BiplPrice, int Userid ,string flag)
        {
            OrderDataProviderInstance.UpdateBiplPriceMO(OrderDetailsID, BiplPrice, Userid,flag);
            return true;
        }

        public bool UpdateDC(int OrderDetailsID, string DC, string username)
        {
            OrderDataProviderInstance.UpdateDC(OrderDetailsID, DC, username);
            return true;
        }
        public bool ExfactoryPermission(int UserID, int ExfactoryCoulme)
        {
            return OrderDataProviderInstance.ExfactoryPermission(UserID, ExfactoryCoulme);
        }
        public bool QCUploadFaultsSubmit(int UserID, int UploadFaultSubmit)
        {
            return OrderDataProviderInstance.QCUploadFaultsSubmit(UserID, UploadFaultSubmit);
        }
        public bool USP_GetValidationUniqueEntry(string TotalFilePath, int StyleID)
        {
            return OrderDataProviderInstance.USP_GetValidationUniqueEntry(TotalFilePath, StyleID);
        }
        public bool CheckShippedOrder(int OrderDetailID)
        {
            return OrderDataProviderInstance.CheckShippedOrder(OrderDetailID);
        }
        public bool CheckCutting_QtyAbove90_Percent(int OrderDetailID)
        {
            return OrderDataProviderInstance.CheckCutting_QtyAbove90_Percent(OrderDetailID);
        }

        public bool CheckValidationForCutIssue(int OrderDetailsId, int ReAllocationId, int TdyCutIssueOutHouse)
        {
            OrderDataProviderInstance.CheckValidationForCutIssue(OrderDetailsId, ReAllocationId, TdyCutIssueOutHouse);
            return true;
        }
        // End By Ravi kumar ON 17/12/2014 For MO pcd change on Ex Factory change
        // End By Ravi kumar ON 17/12/2014 For MO pcd change on Ex Factory change

        //Edited abhishek on 16/11/2015
        public bool UpdateCutAvg(int OrderDetailsID, double CutAvg, int CountFabric, int StyleId, string FabricName, string Print, int IsAll, string imagefile, string user, double CutWidth, string Strcomment)
        {
            OrderDataProviderInstance.UpdateCutAvg(OrderDetailsID, CutAvg, CountFabric, StyleId, FabricName, Print, IsAll, imagefile, user, CutWidth, Strcomment);
            return true;
        }
        //end abhishek 
        // edit by surendra on 2-jne-2015
        public bool UpdatePlanningLine(int OrderDetaildidforline, int lValue, int StyleIdforLine, string Remarks)
        {
            OrderDataProviderInstance.UpdatePlanningLine(OrderDetaildidforline, lValue, StyleIdforLine, Remarks);
            return true;
        }
        //end 
        public List<OrderDetail> GetSealerPendingOrders(int pageSize, int pageIndex, out int totalPageCount,
                                                        string searchText, int clientId, int deptId)
        {
            return OrderDataProviderInstance.GetSealerPendingOrders(pageSize, pageIndex, out totalPageCount, searchText,
                                                                    clientId, deptId);
        }


        public List<MOOrderDetails> GetOrdersBasicInfo(string searchText,string FabricName, string years, DateTime FromDate, DateTime ToDate, int clientId,
                                                     int dateType, int userId, double statusMode, double statusModesSequence,
                                                     int orderBy1, int orderBy2, int orderBy3, int orderBy4,
                                                     string orderDetailIds, int buyingHouseId, int unintID, int desigId, int DeptId, int SalesView, string SessionId, int ClientDeptId,
                                                     string DelayOrderDetailIds, int OrderTpes, int StartIndex, out int TotalCount, int AM, int IsUnshipped, int OutHouse, int ClientParentDeptId, int PageSize)
        {
            List<MOOrderDetails> objOrderDetail = OrderDataProviderInstance.GetOrdersBasicInfo(searchText,FabricName, years, FromDate, ToDate,
                                                                                          clientId, dateType, userId,
                                                                                          statusMode,
                                                                                          statusModesSequence,
                                                                                          orderBy1, orderBy2, orderBy3,
                                                                                          orderBy4, orderDetailIds,
                                                                                          buyingHouseId, unintID, desigId, DeptId, SalesView, SessionId, ClientDeptId, DelayOrderDetailIds, OrderTpes, StartIndex, out TotalCount, AM, IsUnshipped, OutHouse, ClientParentDeptId, PageSize
                                                                                          );


            foreach (MOOrderDetails od in objOrderDetail)
            {
                od.ExFactoryColor = CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode);
                // edit by surendra on 14/10/2013
                //od.PCDColor = CommonHelper.GetPCDColor(od.PcDate, od.ParentOrder.CuttingHistory.PcsCut);
                //end

                if (od.bExFactoryRead == true || od.bModeRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        od.ExFactoryColor = "#F9F9FA";
                        od.ExFactoryForeColor = "#807F80";
                    }
                    else
                    {
                        if (od.ExFactory.Date < DateTime.Now.Date)
                        {
                            od.ExFactoryColor = "#ffffff";
                            od.ExFactoryForeColor = "#ff3300";

                        }
                        if (od.ExFactory.Date > DateTime.Now.Date)
                        {
                            od.ExFactoryColor = "#FFFFFF";
                            od.ExFactoryForeColor = "#000000";
                        }
                        if (od.ExFactory.Date == DateTime.Now.Date || od.ExFactory == DateTime.Today.Date.AddDays(1))
                        {
                            od.ExFactoryColor = "#fd9903";
                            od.ExFactoryForeColor = "#000000";
                        }
                    }
                }
                else
                {
                    od.ExFactoryColor = "#FFFFFF";
                    od.ExFactoryForeColor = "#000000";
                }

                //Added By Ashish on 19/02/2015 
                //Added By Ashish on 23/03/2015 
                if (od.FitsPCDRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        od.PCDBackColor = "#F9F9FA";
                        od.PCDForeColor = "#807F80";
                    }
                    else
                    {
                        if (od.PCDDate.Date >= DateTime.Now.Date && od.BulkCuttingTarget.Date == DateTime.MinValue)
                        {
                            od.PCDBackColor = "#FFFFFF";
                            od.PCDForeColor = "#000000";
                        }
                        else if (od.PCDDate.Date < DateTime.Now.Date && od.BulkCuttingTarget.Date == DateTime.MinValue)
                        {
                            od.PCDBackColor = "#ffffff";
                            od.PCDForeColor = "#FF3300";
                        }
                        else if (od.PCDDate.Date >= od.BulkCuttingTarget.Date)
                        {
                            //od.PCDBackColor = "#d7e4bc";
                            od.PCDBackColor = "#00FF70";
                            od.PCDForeColor = "#000000";
                        }
                        else if (od.PCDDate.Date < od.BulkCuttingTarget.Date)
                        {
                            od.PCDBackColor = "#ffffff";
                            od.PCDForeColor = "#FF3300";
                        }
                        else
                        {
                            od.PCDBackColor = "#FFFFFF";
                            od.PCDForeColor = "#000000";
                        }
                    }
                }
                else
                {
                    od.PCDBackColor = "#FFFFFF";
                    od.PCDForeColor = "#000000";
                }
                //END


                //Added By Ravi on 23/04/2015 
                string Fabric1BackColor = "";
                string Fabric2BackColor = "";
                string Fabric3BackColor = "";
                string Fabric4BackColor = "";
                string Fabric5BackColor = "";
                string Fabric6BackColor = "";

                od.FabricAvgColor1 = string.Empty;
                od.FabricAvgColor2 = string.Empty;
                od.FabricAvgColor3 = string.Empty;
                od.FabricAvgColor4 = string.Empty;

                if (od.Fabric1 != "")
                {
                    //if (od.OrderID == Convert.ToInt32("5225"))
                    //{
                    if (od.IsShiped == true)
                    {
                        od.FabricAvgColor1 = "#F9F9FA";
                    }
                    else
                    {
                        od.FabricAvgColor1 = "#f9f9fa";
                    }
                    //}

                    Fabric1BackColor = CommonHelper.GetBIHBackColorCode(od.BulkTarget, od.Fabric1ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.FBIHDateRead);
                    //Fabric1ForColor = CommonHelper.GetBIHForColorCode(od.BulkTarget, od.Fabric1ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped);
                }
                if (od.Fabric2 != "")
                {
                    //if (od.OrderID == Convert.ToInt32("5225"))
                    //{
                    if (od.IsShiped == true)
                    {
                        od.FabricAvgColor2 = "#F9F9FA";
                    }
                    else
                    {
                        od.FabricAvgColor2 = "#f9f9fa";
                    }
                    //}
                    Fabric2BackColor = CommonHelper.GetBIHBackColorCode(od.BulkTarget, od.Fabric2ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.FBIHDateRead);
                    //Fabric2ForColor = CommonHelper.GetBIHForColorCode(od.BulkTarget, od.Fabric2ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped);
                }
                if (od.Fabric3 != "")
                {
                    //if (od.OrderID == Convert.ToInt32("5225"))
                    //{
                    if (od.IsShiped == true)
                    {
                        od.FabricAvgColor3 = "#F9F9FA";
                    }
                    else
                    {
                        od.FabricAvgColor3 = "#f9f9fa";
                    }
                    //}
                    Fabric3BackColor = CommonHelper.GetBIHBackColorCode(od.BulkTarget, od.Fabric3ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.FBIHDateRead);
                    //Fabric3ForColor = CommonHelper.GetBIHForColorCode(od.BulkTarget, od.Fabric3ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped);
                }
                if (od.Fabric4 != "")
                {
                    //if (od.OrderID == Convert.ToInt32("5225"))
                    //{
                    if (od.IsShiped == true)
                    {
                        od.FabricAvgColor4 = "#F9F9FA";
                    }
                    else
                    {
                        od.FabricAvgColor4 = "#f9f9fa";
                    }
                    //}
                    Fabric4BackColor = CommonHelper.GetBIHBackColorCode(od.BulkTarget, od.Fabric4ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.FBIHDateRead);
                    //Fabric4ForColor = CommonHelper.GetBIHForColorCode(od.BulkTarget, od.Fabric4ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped);
                }

                // Red
                if (Fabric1BackColor == "#FF3300")
                    od.BIHBackColor = "#FF3300";

                if (Fabric2BackColor == "#FF3300")
                    od.BIHBackColor = "#FF3300";

                if (Fabric3BackColor == "#FF3300")
                    od.BIHBackColor = "#FF3300";

                if (Fabric4BackColor == "#FF3300")
                    od.BIHBackColor = "#FF3300";

                if (od.Fabric_ModuleDatabase != "")
                {
                    if (Fabric5BackColor == "#FF3300")
                        od.BIHBackColor = "#FF3300";
                    if (Fabric6BackColor == "#FF3300")
                        od.BIHBackColor = "#FF3300";

                }

                // white
                if (Fabric1BackColor == "#FFFFFF")
                    od.BIHBackColor = "#FFFFFF";

                if (Fabric2BackColor == "#FFFFFF")
                    od.BIHBackColor = "#FFFFFF";

                if (Fabric3BackColor == "#FFFFFF")
                    od.BIHBackColor = "#FFFFFF";

                if (Fabric4BackColor == "#FFFFFF")
                    od.BIHBackColor = "#FFFFFF";

                if (od.Fabric_ModuleDatabase != "")
                {
                    if (Fabric5BackColor == "#FFFFFF")
                        od.BIHBackColor = "#FFFFFF";
                    if (Fabric6BackColor == "#FFFFFF")
                        od.BIHBackColor = "#FFFFFF";
                }
                // shipped
                if (Fabric1BackColor == "#F9F9FA")
                    od.BIHBackColor = "#F9F9FA";

                if (Fabric2BackColor == "#F9F9FA")
                    od.BIHBackColor = "#F9F9FA";

                if (Fabric3BackColor == "#F9F9FA")
                    od.BIHBackColor = "#F9F9FA";

                if (Fabric4BackColor == "#F9F9FA")
                    od.BIHBackColor = "#F9F9FA";
                if (od.Fabric_ModuleDatabase != "")
                {
                    if (Fabric5BackColor == "#F9F9FA")
                        od.BIHBackColor = "#F9F9FA";
                    if (Fabric6BackColor == "#F9F9FA")
                        od.BIHBackColor = "#F9F9FA";
                }

                // Final
                //if red
                if (od.BIHBackColor == "#FF3300")
                {
                    od.BIHBackColor = "#FF3300";
                    od.BIHForColor = "#FF3300";
                }
                // if white
                else if (od.BIHBackColor == "#FFFFFF")
                {
                    od.BIHBackColor = "#FFFFFF";
                    od.BIHForColor = "#000000";
                }
                // if shipped
                else if (od.BIHBackColor == "#F9F9FA")
                {
                    od.BIHBackColor = "#F9F9FA";
                    od.BIHForColor = "#807F80";
                }
                // if green
                else
                {
                    od.BIHBackColor = "#00FF70";
                    od.BIHForColor = "#0bcd60";
                }

                //End By Ravi on 23/04/2015    

                //od.StcBackColor = CommonHelper.GetTechnicalBackColor(od.STCDateReqTar, od.ParentOrder.Fits.SealDate, od.IsShiped);
                //od.StcForColor = CommonHelper.GetTechnicalForColor(od.STCDateReqTar, od.ParentOrder.Fits.SealDate, od.IsShiped);

                //od.PatternBackColor = CommonHelper.GetTechnicalBackColor(od.PatternSampleDate, od.STCDateReqTarPattern, od.IsShiped);
                //od.PatternForColor = CommonHelper.GetTechnicalForColor(od.PatternSampleDate, od.STCDateReqTarPattern, od.IsShiped);

                od.StartETA1BackColor = CommonHelper.GetStartETABackColor(od.fabric1ETA, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.BulkTarget, od.FFabStartETARead);
                od.StartETA1ForColor = CommonHelper.GetStartETAForColor(od.fabric1ETA, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.BulkTarget);
                od.ENDETA1BackColor = CommonHelper.GetETABackColor(od.Fabric1ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.BulkTarget, od.FFabEndETAWrite);
                od.ENDETA1ForColor = CommonHelper.GetETAForColor(od.Fabric1ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.BulkTarget);

                od.StartETA2BackColor = CommonHelper.GetStartETABackColor(od.fabric2ETA, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.BulkTarget, od.FFabStartETARead);
                od.StartETA2ForColor = CommonHelper.GetStartETAForColor(od.fabric2ETA, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.BulkTarget);
                od.ENDETA2BackColor = CommonHelper.GetETABackColor(od.Fabric2ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.BulkTarget, od.FFabEndETAWrite);
                od.ENDETA2ForColor = CommonHelper.GetETAForColor(od.Fabric2ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.BulkTarget);

                od.StartETA3BackColor = CommonHelper.GetStartETABackColor(od.fabric3ETA, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.BulkTarget, od.FFabStartETARead);
                od.StartETA3ForColor = CommonHelper.GetStartETAForColor(od.fabric3ETA, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.BulkTarget);
                od.ENDETA3BackColor = CommonHelper.GetETABackColor(od.Fabric3ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.BulkTarget, od.FFabEndETAWrite);
                od.ENDETA3ForColor = CommonHelper.GetETAForColor(od.Fabric3ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.BulkTarget);

                od.StartETA4BackColor = CommonHelper.GetStartETABackColor(od.fabric4ETA, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.BulkTarget, od.FFabStartETARead);
                od.StartETA4ForColor = CommonHelper.GetStartETAForColor(od.fabric4ETA, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.BulkTarget);
                od.ENDETA4BackColor = CommonHelper.GetETABackColor(od.Fabric4ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.BulkTarget, od.FFabEndETAWrite);
                od.ENDETA4ForColor = CommonHelper.GetETAForColor(od.Fabric4ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.BulkTarget);

                od.Fabric1NameBackColor = CommonHelper.GetFabricNameBackColor(od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.BulkTarget, od.FQualityRead);
                od.Fabric1NameForColor = CommonHelper.GetFabricNameForColor(od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.BulkTarget);
                od.Fabric2NameBackColor = CommonHelper.GetFabricNameBackColor(od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.BulkTarget, od.FQualityRead);
                od.Fabric2NameForColor = CommonHelper.GetFabricNameForColor(od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.BulkTarget);
                od.Fabric3NameBackColor = CommonHelper.GetFabricNameBackColor(od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.BulkTarget, od.FQualityRead);
                od.Fabric3NameForColor = CommonHelper.GetFabricNameForColor(od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.BulkTarget);
                od.Fabric4NameBackColor = CommonHelper.GetFabricNameBackColor(od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.BulkTarget, od.FQualityRead);
                od.Fabric4NameForColor = CommonHelper.GetFabricNameForColor(od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.BulkTarget);

                od.BulkApproval1BackColor = CommonHelper.GetBulkSatusBackColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab1ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.FQualityRead);
                od.BulkApproval1ForColor = CommonHelper.GetBulkSatusForeColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab1ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped);
                od.BulkApproval2BackColor = CommonHelper.GetBulkSatusBackColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab2ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.FQualityRead);
                od.BulkApproval2ForColor = CommonHelper.GetBulkSatusForeColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab2ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped);
                od.BulkApproval3BackColor = CommonHelper.GetBulkSatusBackColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab3ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.FQualityRead);
                od.BulkApproval3ForColor = CommonHelper.GetBulkSatusForeColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab3ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped);
                od.BulkApproval4BackColor = CommonHelper.GetBulkSatusBackColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab4ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.FQualityRead);
                od.BulkApproval4ForColor = CommonHelper.GetBulkSatusForeColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab4ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped);

                //
                od.TractStatus1ForColor = CommonHelper.GetTrackingSatusForeColor(od.FabricTrackingTarget1, od.Fabric1actionDate, od.IsShiped);
                od.TractStatus2ForColor = CommonHelper.GetTrackingSatusForeColor(od.FabricTrackingTarget2, od.Fabric2actionDate, od.IsShiped);
                od.TractStatus3ForColor = CommonHelper.GetTrackingSatusForeColor(od.FabricTrackingTarget3, od.Fabric3actionDate, od.IsShiped);
                od.TractStatus4ForColor = CommonHelper.GetTrackingSatusForeColor(od.FabricTrackingTarget4, od.Fabric4actionDate, od.IsShiped);
                //

                od.Percent1BackColor = CommonHelper.GetPercentBackColor(od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.FPerInhouseRead);
                od.Percent1ForColor = CommonHelper.GetPercentForColor(od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped);
                od.Percent2BackColor = CommonHelper.GetPercentBackColor(od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.FPerInhouseRead);
                od.Percent2ForColor = CommonHelper.GetPercentForColor(od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped);
                od.Percent3BackColor = CommonHelper.GetPercentBackColor(od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.FPerInhouseRead);
                od.Percent3ForColor = CommonHelper.GetPercentForColor(od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped);
                od.Percent4BackColor = CommonHelper.GetPercentBackColor(od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.FPerInhouseRead);
                od.Percent4ForColor = CommonHelper.GetPercentForColor(od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped);


                od.LinktypeBackColor = CommonHelper.GetLinktypeBackColor(od.IsShiped);
                od.LinktypeForeColor = CommonHelper.GetLinktypeForeColor(od.IsShiped);
                od.BlackToForeColor = CommonHelper.GetBlackToForeColor(od.IsShiped);

                //Added By Ashish on 29/28/2015
                od.stylenumberColor = CommonHelper.GetstylenumberColor(od.IsShiped, od.IsRiskTask);
                od.SamOBValColor = CommonHelper.GetSamOBValColor(od.IsShiped, od.IsOBCreate, od.IsFinalizeOB);
                //END
                od.PricevariationColor = CommonHelper.GetPricevariationForeColor(od.IsShiped);
                //od.AuditvariationColor = CommonHelper.GetAuditForeColor(od.IsShiped, od.AuditStatus);
                od.CQDForeColor = CommonHelper.CQDForeColor(od.IsShiped);
                od.SummryColor = CommonHelper.GetSummaryForeColor(od.IsShiped);
                // updated  By sushil on 26/3/2015
                od.LinktypeForeColorforfitspending = CommonHelper.GetLinktypeForeColorforfitspending(od.IsShiped, od.IsFitsPending);
                od.FitsPandingColor = CommonHelper.GetFitsPendingBackColor(od.IsFitsPending, od.IsShiped);
                // End updated  By sushil on 26/3/2015
                //Added By Ashish on 9/4/2015
                od.FitsSTCETABackColor = CommonHelper.GetTechnicalETABackColor(od.STCETA, od.IsShiped, od.STCtargetsDate, od.FitsSTCETARead, od.ParentOrder.Fits.SealDate);
                od.FitsSTCETAForColor = CommonHelper.GetTechnicalETAForColor(od.STCETA, od.IsShiped, od.STCtargetsDate, od.FitsSTCETARead, od.ParentOrder.Fits.SealDate);
                od.FitsPatternETABackColor = CommonHelper.GetTechnicalETABackColor(od.PatternSampleDateETA, od.IsShiped, od.PatternSampleTarget, od.FitsPatternETARead, od.PatternSampleDate);
                od.FitsPatternETAForColor = CommonHelper.GetTechnicalETAForColor(od.PatternSampleDateETA, od.IsShiped, od.PatternSampleTarget, od.FitsPatternETARead, od.PatternSampleDate);
                od.FitsCuttingETABackColor = CommonHelper.GetTechnicalETABackColor(od.CuttingReceivedDateETA, od.IsShiped, od.CuttingTarget, od.FitsCuttingETARead, od.CuttingReceivedDate);
                od.FitsCuttingETAForColor = CommonHelper.GetTechnicalETAForColor(od.CuttingReceivedDateETA, od.IsShiped, od.CuttingTarget, od.FitsCuttingETARead, od.CuttingReceivedDate);
                od.FitsProdETABackColor = CommonHelper.GetTechnicalETABackColor(od.ProductionFileDateETA, od.IsShiped, od.ProductionFileTarget, od.FitsProdFileETARead, od.ProductionFileDate);
                od.FitsProdETAForColor = CommonHelper.GetTechnicalETAForColor(od.ProductionFileDateETA, od.IsShiped, od.ProductionFileTarget, od.FitsProdFileETARead, od.ProductionFileDate);
                od.FitsHOPPMETABackColor = CommonHelper.GetTechnicalETABackColor(od.HOPPMETA, od.IsShiped, od.HOPPMTargetETA, od.FitsHOPPMETARead, od.HOPPMActionactualDate);
                od.FitsHOPPMETAForColor = CommonHelper.GetTechnicalETAForColor(od.HOPPMETA, od.IsShiped, od.HOPPMTargetETA, od.FitsHOPPMETARead, od.HOPPMActionactualDate);
                od.FitsTOPSentETABackColor = CommonHelper.GetTechnicalETABackColor(od.TOPETA, od.IsShiped, od.ParentOrder.InlinePPMOrderContract.TopSentTarget, od.FitsTOPSentETARead, od.ParentOrder.InlinePPMOrderContract.TopSentActual);
                od.FitsTOPSentETAForColor = CommonHelper.GetTechnicalETAForColor(od.TOPETA, od.IsShiped, od.ParentOrder.InlinePPMOrderContract.TopSentTarget, od.FitsTOPSentETARead, od.ParentOrder.InlinePPMOrderContract.TopSentActual);
                od.PPSampleSentBackColor = CommonHelper.GetTechnicalETABackColor(od.PPSampleETA, od.IsShiped, od.PPSampleTgtDate, od.FitsProdFileETARead, DateTime.MinValue);
                od.PPSampleSentETABackColor = CommonHelper.GetTechnicalETABackColor(od.PPSampleETA, od.IsShiped, od.PPSampleTgtDate, od.FitsProdFileETARead, DateTime.MinValue);
                // edit by surendra
                od.TestReportsBackColor = CommonHelper.GetTechnicalETABackColor(od.TestReportsDateETA, od.IsShiped, od.TestReportTargetETA, od.FitsHOPPMETARead, od.TestReportsDateActual);
                od.TestReportsForColor = CommonHelper.GetTechnicalETAForColor(od.TestReportsDateETA, od.IsShiped, od.TestReportTargetETA, od.FitsHOPPMETARead, od.TestReportsDateActual);
                od.CDChartBackColor = CommonHelper.GetTechnicalETABackColor(od.CdchartDateETA, od.IsShiped, od.CdchartTargetDateETA, od.FitsHOPPMETARead, od.CdchartActualDateETA);
                od.CDChartForColor = CommonHelper.GetTechnicalETAForColor(od.CdchartDateETA, od.IsShiped, od.CdchartTargetDateETA, od.FitsHOPPMETARead, od.CdchartActualDateETA);
                od.StrikeOfBackColor1 = CommonHelper.StrikeOfBackColor(od.IntialAprd1, od.IsShiped);
                od.StrikeOfBackColor2 = CommonHelper.StrikeOfBackColor(od.IntialAprd2, od.IsShiped);
                od.StrikeOfBackColor3 = CommonHelper.StrikeOfBackColor(od.IntialAprd3, od.IsShiped);
                od.StrikeOfBackColor4 = CommonHelper.StrikeOfBackColor(od.IntialAprd4, od.IsShiped);
                od.StrikeOfForeColor1 = CommonHelper.StrikeOfForeColor(od.IntialAprd1, od.IsShiped);
                od.StrikeOfForeColor2 = CommonHelper.StrikeOfForeColor(od.IntialAprd2, od.IsShiped);
                od.StrikeOfForeColor3 = CommonHelper.StrikeOfForeColor(od.IntialAprd3, od.IsShiped);
                od.StrikeOfForeColor4 = CommonHelper.StrikeOfForeColor(od.IntialAprd4, od.IsShiped);

                if (od.Fabric_ModuleDatabase != "")
                {
                    od.TractStatus5ForColor = CommonHelper.GetTrackingSatusForeColor(od.FabricTrackingTarget5, od.Fabric5actionDate, od.IsShiped);
                    od.TractStatus6ForColor = CommonHelper.GetTrackingSatusForeColor(od.FabricTrackingTarget6, od.Fabric6actionDate, od.IsShiped);
                    od.StartETA5BackColor = CommonHelper.GetStartETABackColor(od.fabric5ETA, od.ParentOrder.FabricInhouseHistory.Fabric5Percent, od.IsShiped, od.BulkTarget, od.FFabStartETARead);
                    od.StartETA5ForColor = CommonHelper.GetStartETAForColor(od.fabric5ETA, od.ParentOrder.FabricInhouseHistory.Fabric5Percent, od.IsShiped, od.BulkTarget);
                    od.StartETA6BackColor = CommonHelper.GetStartETABackColor(od.fabric6ETA, od.ParentOrder.FabricInhouseHistory.Fabric6Percent, od.IsShiped, od.BulkTarget, od.FFabStartETARead);
                    od.StartETA6ForColor = CommonHelper.GetStartETAForColor(od.fabric6ETA, od.ParentOrder.FabricInhouseHistory.Fabric6Percent, od.IsShiped, od.BulkTarget);
                    od.ENDETA5BackColor = CommonHelper.GetETABackColor(od.Fabric5ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric5Percent, od.IsShiped, od.BulkTarget, od.FFabEndETAWrite);
                    od.ENDETA5ForColor = CommonHelper.GetETAForColor(od.Fabric5ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric5Percent, od.IsShiped, od.BulkTarget);
                    od.ENDETA6BackColor = CommonHelper.GetETABackColor(od.Fabric6ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric6Percent, od.IsShiped, od.BulkTarget, od.FFabEndETAWrite);
                    od.ENDETA6ForColor = CommonHelper.GetETAForColor(od.Fabric6ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric6Percent, od.IsShiped, od.BulkTarget);
                    od.Fabric5NameBackColor = CommonHelper.GetFabricNameBackColor(od.ParentOrder.FabricInhouseHistory.Fabric5Percent, od.IsShiped, od.BulkTarget, od.FQualityRead);
                    od.Fabric6NameForColor = CommonHelper.GetFabricNameForColor(od.ParentOrder.FabricInhouseHistory.Fabric6Percent, od.IsShiped, od.BulkTarget);
                    od.BulkApproval5BackColor = CommonHelper.GetBulkSatusBackColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab5ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric5Percent, od.IsShiped, od.FQualityRead);
                    od.BulkApproval5ForColor = CommonHelper.GetBulkSatusForeColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab5ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric5Percent, od.IsShiped);
                    od.BulkApproval6BackColor = CommonHelper.GetBulkSatusBackColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab6ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric6Percent, od.IsShiped, od.FQualityRead);
                    od.BulkApproval6ForColor = CommonHelper.GetBulkSatusForeColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab6ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric6Percent, od.IsShiped);
                    od.Percent5BackColor = CommonHelper.GetPercentBackColor(od.ParentOrder.FabricInhouseHistory.Fabric5Percent, od.IsShiped, od.FPerInhouseRead);
                    od.Percent5ForColor = CommonHelper.GetPercentForColor(od.ParentOrder.FabricInhouseHistory.Fabric5Percent, od.IsShiped);
                    od.Percent6BackColor = CommonHelper.GetPercentBackColor(od.ParentOrder.FabricInhouseHistory.Fabric6Percent, od.IsShiped, od.FPerInhouseRead);
                    od.Percent6ForColor = CommonHelper.GetPercentForColor(od.ParentOrder.FabricInhouseHistory.Fabric6Percent, od.IsShiped);
                    od.StrikeOfBackColor5 = CommonHelper.StrikeOfBackColor(od.IntialAprd5, od.IsShiped);
                    od.StrikeOfBackColor6 = CommonHelper.StrikeOfBackColor(od.IntialAprd6, od.IsShiped);
                    od.StrikeOfForeColor5 = CommonHelper.StrikeOfForeColor(od.IntialAprd5, od.IsShiped);
                    od.StrikeOfForeColor6 = CommonHelper.StrikeOfForeColor(od.IntialAprd6, od.IsShiped);
                    od.Fabric5NameBackColor = CommonHelper.GetFabricNameBackColor(od.ParentOrder.FabricInhouseHistory.Fabric5Percent, od.IsShiped, od.BulkTarget, od.FQualityRead);
                    od.Fabric5NameForColor = CommonHelper.GetFabricNameForColor(od.ParentOrder.FabricInhouseHistory.Fabric5Percent, od.IsShiped, od.BulkTarget);
                    od.Fabric6NameBackColor = CommonHelper.GetFabricNameBackColor(od.ParentOrder.FabricInhouseHistory.Fabric6Percent, od.IsShiped, od.BulkTarget, od.FQualityRead);
                    od.Fabric6NameForColor = CommonHelper.GetFabricNameForColor(od.ParentOrder.FabricInhouseHistory.Fabric6Percent, od.IsShiped, od.BulkTarget);
                    od.FabricAvgColor5 = string.Empty;
                    od.FabricAvgColor6 = string.Empty;
                    if (od.Fabric5 != "")
                    {
                        //if (od.OrderID == Convert.ToInt32("5225"))
                        //{
                        if (od.IsShiped == true)
                        {
                            od.FabricAvgColor5 = "#F9F9FA";
                        }
                        else
                        {
                            od.FabricAvgColor5 = "#f9f9fa";
                        }
                        //}
                        Fabric5BackColor = CommonHelper.GetBIHBackColorCode(od.BulkTarget, od.Fabric5ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric5Percent, od.IsShiped, od.FBIHDateRead);
                        //Fabric4ForColor = CommonHelper.GetBIHForColorCode(od.BulkTarget, od.Fabric4ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped);
                    }
                    if (od.Fabric6 != "")
                    {
                        //if (od.OrderID == Convert.ToInt32("5225"))
                        //{
                        if (od.IsShiped == true)
                        {
                            od.FabricAvgColor6 = "#F9F9FA";
                        }
                        else
                        {
                            od.FabricAvgColor6 = "#f9f9fa";
                        }
                        //}
                        Fabric6BackColor = CommonHelper.GetBIHBackColorCode(od.BulkTarget, od.Fabric6ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric6Percent, od.IsShiped, od.FBIHDateRead);
                        //Fabric4ForColor = CommonHelper.GetBIHForColorCode(od.BulkTarget, od.Fabric4ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped);
                    }
                }
                //-----------------------------------Fits Module-------------------------------------
                od.HandOverETABackColor = CommonHelper.GetTechnicalETABackColor(od.HandOverETADate, od.IsShiped, od.HandOverTargetDate, od.FitsProdFileETARead, od.HandOverActualDate);
                od.PatternReadyETABackColor = CommonHelper.GetTechnicalETABackColor(od.PatternReadyETADate, od.IsShiped, od.PatternReadyTargetDate, od.FitsProdFileETARead, od.PatternReadyActualDate);
                od.SampleSentETABackColor = CommonHelper.GetTechnicalETABackColor(od.SampleSentETADate, od.IsShiped, od.SampleSentTargetDate, od.FitsProdFileETARead, od.SampleSentActualDate);
                od.FitsCommentesETABackColor = CommonHelper.GetTechnicalETABackColor(od.FitsCommentesETADate, od.IsShiped, od.FitsCommentesTargetDate, od.FitsProdFileETARead, od.FitsCommentesActualDate);
                od.HandOverETAForeColor = CommonHelper.GetTechnicalETAForColor(od.HandOverETADate, od.IsShiped, od.HandOverTargetDate, od.FitsProdFileETARead, od.HandOverActualDate);
                od.PatternReadyETAForeColor = CommonHelper.GetTechnicalETAForColor(od.PatternReadyETADate, od.IsShiped, od.PatternReadyTargetDate, od.FitsProdFileETARead, od.PatternReadyActualDate);
                od.SampleSentETAForeColor = CommonHelper.GetTechnicalETAForColor(od.SampleSentETADate, od.IsShiped, od.SampleSentTargetDate, od.FitsProdFileETARead, od.SampleSentActualDate);
                od.FitsCommentesETAForeColor = CommonHelper.GetTechnicalETAForColor(od.FitsCommentesETADate, od.IsShiped, od.FitsCommentesTargetDate, od.FitsProdFileETARead, od.FitsCommentesActualDate);

                //END

            }

            return objOrderDetail;
        }
        public List<MoShippingDetail> GetMoShippingInfo(int styleId)
        {
            List<MoShippingDetail> objOrderDetail = OrderDataProviderInstance.GetMoShippingInfo(styleId);
            foreach (MoShippingDetail od in objOrderDetail)
            {
                //od.ExFactoryColor = CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode);
                if (od.ExFactory.Date < DateTime.Now.Date)
                {
                    od.ExFactoryColor = "#ff3300";
                }
                if (od.ExFactory.Date > DateTime.Now.Date)
                {
                    od.ExFactoryColor = "#FFFFFF";
                }
                if (od.ExFactory.Date == DateTime.Now.Date || od.ExFactory == DateTime.Today.Date.AddDays(1))
                {
                    od.ExFactoryColor = "#fd9903";
                }
            }
            return objOrderDetail;
        }





        //public void UpdateSealerRemarks(int styleID, int clientDepartmentID, string sealerRemarksiKandi, string sealerRemarksBIPL)
        //{
        //    this.OrderDataProviderInstance.UpdateSealerRemarks(styleID, clientDepartmentID, sealerRemarksiKandi, sealerRemarksBIPL);
        //}
        public void UpdateSanjeevRemarks(OrderDetail orderDetails)
        {
            OrderDataProviderInstance.UpdateSanjeevRemarks(orderDetails);
        }

        public void UpdateExFactoryBeforeMO(OrderDetail orderDetails)
        {
            //OrderDataProviderInstance.UpdateExfactory(orderDetails);
        }

        public void UpdateRemarks(int id1, int id2, string remarks, string type, string applicationModuleName)
        {
            OrderDataProviderInstance.UpdateRemarks(id1, id2, remarks, type, applicationModuleName);
        }

        // Update By Ravi kumar ON 2/2/2015 For MO Sanjeev Remark
        public void UpdateRemarksSanjeev(string remarks, string ids, string exFactory, int IsPcDateChanged)
        {
            OrderDataProviderInstance.UpdateRemarksSanjeev(remarks, ids, exFactory, IsPcDateChanged);
        }
        // End By Ravi kumar ON 2/2/2015 For MO Sanjeev Remark
        public bool IscheckShippingPermission(int DesID, int DeptID, int ColId)
        {
            return OrderDataProviderInstance.IscheckShippingPermission(DesID, DeptID, ColId);
        }
        public string GetMoETARemarks(string Flag1, string Flag2, int StyleId, string Val1, string Val2, int OrderDetailId, int accworkingID = 0)
        {
            string objOrderDetail = this.OrderDataProviderInstance.GetMoETARemarks(Flag1, Flag2, StyleId, Val1, Val2, OrderDetailId, accworkingID);
            //foreach (MoShippingDetail od in objOrderDetail)
            //{ 
            //    od.ExFactoryColor = CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode);
            //}
            return objOrderDetail;
        }
        //added by abhishek on 8/9/2015
        public string GetMoETARemarksAll(string Flag1, int OrderDetailId, out int check)
        {
            string objOrderDetail = this.OrderDataProviderInstance.GetMoETARemarksAll(Flag1, OrderDetailId, out check);
            //foreach (MoShippingDetail od in objOrderDetail)
            //{ 
            //    od.ExFactoryColor = CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode);
            //}
            return objOrderDetail;
        }
        //end abhishek 
        public string GetFabricHistory(int FabricQualityID)
        {
            string objOrderDetail = this.OrderDataProviderInstance.GetFabricHistory(FabricQualityID);
            //foreach (MoShippingDetail od in objOrderDetail)
            //{ 
            //    od.ExFactoryColor = CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode);
            //}
            return objOrderDetail;
        }


        public DataTable IscheckShippingPermissionExFactory(int DesID, int DeptID, int ColId)
        {
            return OrderDataProviderInstance.IscheckShippingPermissionExFactory(DesID, DeptID, ColId);
        }


        public bool IscheckShippingRemarksPermission(int DesID, int DeptID, int ColumnId)
        {
            return OrderDataProviderInstance.IscheckShippingRemarksPermission(DesID, DeptID, ColumnId);
        }

        /// <summary>
        ///   Added by Yaten
        /// </summary>
        /// <param name="varOwnerIdS"></param>
        /// <param name="varstatus1"></param>
        /// <param name="targetDate"></param>
        /// <param name = "id1"></param>
        /// <param name = "id2"></param>
        /// <param name = "remarks"></param>
        /// <param name = "type"></param>
        /// <param name = "applicationModuleName"></param>
        //public void UpdateRemarks(string varstatus1, string val1, int Id1, int Id2, string Remarks, string Type, string ApplicationModuleName)
        //{
        //    this.OrderDataProviderInstance.UpdateRemarks(varstatus1, val1, Id1, Id2, Remarks, Type, ApplicationModuleName);
        //}
        public void SaveResolution1(string varOwnerIdS, string varstatus1, string targetDate, int id1, int id2,
                                    string remarks, string type, string applicationModuleName)
        {
            OrderDataProviderInstance.SaveResolution1(varOwnerIdS, varstatus1, targetDate, id1, id2, remarks, type,
                                                      applicationModuleName);
        }

        public void UpdateikandiPrice(int orderDetailId, double ikandiPrice, string history)
        {
            OrderDataProviderInstance.UpdateikandiPrice(orderDetailId, ikandiPrice, history);
        }



        public List<OrderDetail> GetOrdersApprovalBasicInfo(int clientId, string fabric1, int orderid, int styleid,
                                                            string fabricDetails)
        {
            return OrderDataProviderInstance.GetOrdersApprovalBasicInfo(clientId, fabric1, orderid, styleid,
                                                                        fabricDetails);
        }



        public bool UpdateManageOrderAccessoryWorkingDetails(AccessoryWorking objAccessoryWorking)
        {
            return OrderDataProviderInstance.UpdateManageOrderAccessoryWorkingDetails(objAccessoryWorking);
        }

        public bool InsertManageOrderFabricInHouseHistory(int orderDetailId, int fabricType, Double fabricLength, string fabricName, DateTime date, int percentInHouse)
        {
            OrderDataProviderInstance.InsertManageOrderFabricInHouseHistory(orderDetailId, fabricType, fabricLength, fabricName, date, percentInHouse);
            return true;
        }
        public bool InsertManageOrderFabricInHouseHistory_inHouseChecked(int orderDetailId, int fabricType, string fabricName, DateTime date, int percentInHouse, int InhouseQnty)
        {
            OrderDataProviderInstance.InsertManageOrderFabricInHouseHistory_inHouseChecked(orderDetailId, fabricType, fabricName, date, percentInHouse, InhouseQnty);
            return true;
        }

        public bool CheckFabricBIH(int OrderDetailID)
        {
            return OrderDataProviderInstance.CheckFabricBIH(OrderDetailID);
        }

        public bool CheckAccessoryBIH(int OrderDetailID)
        {
            return OrderDataProviderInstance.CheckAccessoryBIH(OrderDetailID);
        }

        /// <summary>
        /// </summary>
        /// <param name="styleNumber"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public string GetStatusofResolution2(string styleNumber, string mode)
        {
            return OrderDataProviderInstance.GetStatusofResolution(styleNumber, mode);
        }

        public bool InsertManageOrderAccessoryInHouseHistory(int orderDetailId, int accessoryWorkingDetailId,
                                                             int quantity, DateTime date, int percentInHouse)
        {
            OrderDataProviderInstance.InsertManageOrderAccessoryInHouseHistory(orderDetailId, accessoryWorkingDetailId,
                                                                               quantity, date, percentInHouse);
            return true;
        }









        public bool CopyManageOrderStitchingHistory(StitchingHistory stitchingHistory)
        {
            return OrderDataProviderInstance.CopyManageOrderStitchingHistory(stitchingHistory);
        }



        public DataSet GetManageOrderFabricPopupDetails(int OrderDetailID)
        {
            return OrderDataProviderInstance.GetManageOrderFabricPopupDetails(OrderDetailID);
        }

        public DataSet GetManageOrderFabricPopupGridDetails(int ClientId, string Fabric, int Fabrictype)
        {
            return OrderDataProviderInstance.GetManageOrderFabricPopupGridDetails(ClientId, Fabric, Fabrictype);
        }

        public DataSet GetManageOrderFabricPopupGridDetails(int ClientId, string Fabric, int Type, string FabricDetails,
                                                            int OrderID)
        {
            return OrderDataProviderInstance.GetManageOrderFabricPopupGridDetails(ClientId, Fabric, Type, FabricDetails,
                                                                                  OrderID);
        }

        public DataSet GetManageOrderAccessoryPopupDetails(int OrderDetailID)
        {
            return OrderDataProviderInstance.GetManageOrderAccessoryPopupDetails(OrderDetailID);
        }

        public DataSet GetManageOrderFabricDates(int OrderDetailID, int OrderID, int ClientID)
        {
            return OrderDataProviderInstance.GetManageOrderFabricDates(OrderDetailID, OrderID, ClientID);
        }





        public List<OrderDetail> GetOrderDetailById(int orderId)
        {
            List<OrderDetail> objOrderDetail = OrderDataProviderInstance.GetOrderDetailById(orderId);

            foreach (OrderDetail od in objOrderDetail)
            {
                od.ExFactoryColor = CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode);
            }

            return objOrderDetail;
        }

        public List<OrderDetail> GetOrderDetailByIdOrderForm(int orderId)
        {
            List<OrderDetail> objOrderDetail = OrderDataProviderInstance.GetOrderDetailByIdOrderForm(orderId);

            foreach (OrderDetail od in objOrderDetail)
            {
                od.ExFactoryColor = CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode);
            }

            return objOrderDetail;
        }

        // start sushil 
        public List<OrderAccDetail> GetOrderAccDetail(int orderId)
        {
            List<OrderAccDetail> objOrderaccDetail = OrderDataProviderInstance.GetOrderAccDetail(orderId);

            return objOrderaccDetail;
        }

        public iKandi.Common.Order GetOrderByIdOrderForm(int OrderID)
        {
            return OrderDataProviderInstance.GetOrderByIdOrderForm(OrderID);
        }
        public OrderDetail[] GetOrderDetailByIdOrderForm_s(int orderId)
        {
            List<OrderDetail> objOrderDetail = OrderDataProviderInstance.GetOrderDetailByIdOrderForm(orderId);

            foreach (OrderDetail od in objOrderDetail)
            {
                od.ExFactoryColor = CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode);
            }

            return objOrderDetail.ToArray();
        }
        //end
        public List<FabricInhouseHistory> GetManageOrderFabicHistory(int orderDetailId)
        {
            return OrderDataProviderInstance.GetManageOrderFabicHistory(orderDetailId);
        }





        public List<OrderDetail> GetManageOrderContractsByPrintNumber(string printNumber, int fabrictype)
        {
            return OrderDataProviderInstance.GetManageOrderContractsByPrintNumber(printNumber, fabrictype);
        }

        public List<AccessoryInHouseHistory> GetStyleFileAccessoryInfo(int orderDetailId)
        {
            return OrderDataProviderInstance.GetStyleFileAccessoryInfo(orderDetailId);
        }

        public List<FitsTrack> StyleFileGetFitsInfo(string styleNumber, Int32 departmentId)
        {
            return OrderDataProviderInstance.StyleFileGetFitsInfo(styleNumber, departmentId);
        }

        public void StyleFileInsertOwnerInfo(int orderDetailId, int fitsOwnerId, int fabricOwnerId, string fitsRemarks,
                                             string fabricRemarks, DateTime plannedDispatchDate, int fitsTrackId)
        {
            OrderDataProviderInstance.StyleFileInsertOwnerInfo(orderDetailId, fitsOwnerId, fabricOwnerId, fitsRemarks,
                                                               fabricRemarks, plannedDispatchDate, fitsTrackId);
        }

        public DataSet GetStyleFileFabricRemarks(int orderDetailId)
        {
            return OrderDataProviderInstance.GetStyleFileFabricRemarks(orderDetailId);
        }

        public DataSet GetStyleFileFitsRemarks(string styleNumber, int departmentId, int orderDetailId)
        {
            return OrderDataProviderInstance.GetStyleFileFitsRemarks(styleNumber, departmentId, orderDetailId);
        }



        public DataSet StyleFileShowStyleImages(string StyleID, int PrintNumber)
        {
            return OrderDataProviderInstance.StyleFileShowStyleImages(StyleID, PrintNumber);
        }

        public DataSet GetManageOrderFabricHistory()
        {
            return OrderDataProviderInstance.GetManageOrderFabricHistory();
        }




        //public bool UpdateInvoiceData(Invoice Invoice)
        //{
        //    return this.OrderDataProviderInstance.UpdateInvoiceData(Invoice);
        //}





        public bool InsertManageOrderAccessoryApprovedDate(AccessoryWorking objAccessoryWorking)
        {
            return OrderDataProviderInstance.InsertManageOrderAccessoryApprovedDate(objAccessoryWorking);
        }

        public DataSet ManageOrderGetFitsInfo(string StyleCodeVersion, int DepartmentID, int OrderDetailID)
        {
            return OrderDataProviderInstance.ManageOrderGetFitsInfo(StyleCodeVersion, DepartmentID, OrderDetailID);
        }



        //public List<User> GetStatusMeetingUserEmailInfo()
        //{
        //    return this.OrderDataProviderInstance.GetStatusMeetingUserEmailInfo();
        //}

        public DataSet GetOrderBasicInfo(int OrderDetailID)
        {
            return OrderDataProviderInstance.GetOrderBasicInfo(OrderDetailID);
        }

        public iKandi.Common.Order GetOrderByOrderDetailId(int OrderDetailID)
        {
            return OrderDataProviderInstance.GetOrderByOrderDetailId(OrderDetailID);
        }

        public List<iKandi.Common.Order> GetOrderByCurrentDate(DateTime CurrentDate, int bCheck)
        {
            return OrderDataProviderInstance.GetOrderByCurrentDate(CurrentDate, bCheck);
        }



        public void UpdateRemarksOperation(string Id1, int Id2, string Remarks, DateTime Date, String Type,
                                           SqlConnection cnx, SqlTransaction transaction)
        {
            OrderDataProviderInstance.UpdateRemarksOperation(Id1, Id2, Remarks, Date, Type, cnx, transaction);
        }

        public DataSet GetExFactoryUnitQuantityReport()
        {
            return OrderDataProviderInstance.GetExFactoryUnitQuantityReport();
        }

        public int CheckExistingSerialNumber(int OrderID, string SerialNumber, int Type)
        {
            return OrderDataProviderInstance.CheckExistingSerialNumber(OrderID, SerialNumber, Type);
        }

        // Liability Specific
        public OrderDetail GetOrderDetailByOrderDetailId(int OrderDetailID)
        {
            return OrderDataProviderInstance.GetOrderDetailByOrderDetailId(OrderDetailID);
        }



        public int FindOrderIDBreakdownByBuyerAndContract(int ClientID, string Contract)
        {
            return OrderDataProviderInstance.FindOrderIDBreakdownByBuyerAndContract(ClientID, Contract);
        }
        public int FindStatus_Modes_Sequence(string StatusModesName, int Type)
        {
            return OrderDataProviderInstance.FindStatus_Modes_Sequence(StatusModesName, Type);
        }



        public DataSet GetOrdersByStyleVariation(string StyleNumber)
        {
            return OrderDataProviderInstance.GetOrdersByStyleVariation(StyleNumber);
        }

        public void UpdateOrderAgreedCosting(string OrderIDs, int CostingID)
        {
            OrderDataProviderInstance.UpdateOrderAgreedCosting(OrderIDs, CostingID);
        }

        //manisha added on 2/24/2011

        //end

        //manisha added on 7/29/2011



        //end





        #region Manisha New Added

        public string GetReminderDetails(string task, int type)
        {
            return OrderDataProviderInstance.GetReminderDetails(task, type);
        }

        public List<Reminders> FetchReminderDetails(int orderId, int userId)
        {
            return OrderDataProviderInstance.FetchReminderDetails(orderId, userId);
        }

        public string SaveReminderDetails(int orderDetailId, int orderId, int taskId, string desc, DateTime dt,
                                          DateTime dt1, int userId)
        {
            return OrderDataProviderInstance.SaveReminderDetails(orderDetailId, orderId, taskId, desc, dt, DateTime.Now,
                                                                 userId);
        }

        public string UpdateReminderDetails(int orderDetailId, int orderId, int taskId, DateTime dt, int userId)
        {
            return OrderDataProviderInstance.UpdateReminderDetails(orderDetailId, orderId, taskId, DateTime.Now, userId);
        }

        //added on 1 march 2011
        public string SaveReminderDetails(string ixml, int userID)
        {
            return OrderDataProviderInstance.SaveReminderDetails(ixml, userID);
        }

        public DataSet OrderChangeRequestIkandi(string MailType, DateTime iReportDate)
        {
            return OrderDataProviderInstance.OrderChangeRequestIkandi(MailType, iReportDate);
        }

        #endregion

        public DataSet GetManageOrderSTCPopupDetails(int OrderID)
        {
            DataSet dsAccessoryPopupDetails = new DataSet();
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                try
                {
                    string cmdText = "sp_manage_order_get_SAM_popup_details";

                    SqlCommand cmd = new SqlCommand(cmdText, cnx);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                    SqlParameter paramIn;

                    paramIn = new SqlParameter("@OrderID", SqlDbType.Int);
                    paramIn.Value = OrderID;
                    cmd.Parameters.Add(paramIn);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dsAccessoryPopupDetails);

                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return dsAccessoryPopupDetails;
        }

        public bool InsertManageOrderSam(int OrderID, int OrderSAM, int STCSAM, string OrderPath, string stcPath, int styleID)
        {
            using (SqlConnection cnx = new SqlConnection(Constants.CONFIGURATION_STRING))
            {
                cnx.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                string cmdText = "sp_order_detail_update_OrderSam_STCSam";
                SqlCommand cmd = new SqlCommand(cmdText, cnx);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = Constants.CONFIGURATION_TimeOut;
                SqlParameter paramIn;

                paramIn = new SqlParameter("@OrderID", SqlDbType.Int);
                paramIn.Value = OrderID;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@OrderSAM", SqlDbType.Int);
                paramIn.Value = OrderSAM;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@STCSam", SqlDbType.Int);
                paramIn.Value = STCSAM;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@OrderPath", SqlDbType.VarChar);
                paramIn.Value = OrderPath;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@stcPath", SqlDbType.VarChar);
                paramIn.Value = stcPath;
                cmd.Parameters.Add(paramIn);

                paramIn = new SqlParameter("@StyleId", SqlDbType.Int);
                paramIn.Value = styleID;
                cmd.Parameters.Add(paramIn);

                cmd.ExecuteNonQuery();
                cnx.Close();

            }
            return true;
        }


        public bool UpdateDescription(int styleid, string Changevalue, string Flag)
        {
            OrderDataProviderInstance.UpdateDescription(styleid, Changevalue, Flag);
            return true;
        }
        public bool UpdateLineNo(int OrderDetailID, string Changevalue, string Flag)
        {
            OrderDataProviderInstance.UpdateLineNo(OrderDetailID, Changevalue, Flag);
            return true;
        }
        public bool UpdateWeight(int styleid, string Changevalue, string Flag)
        {
            OrderDataProviderInstance.UpdateWeight(styleid, Changevalue, Flag);
            return true;
        }
        public bool DeleteSession(string SessionId)
        {
            OrderDataProviderInstance.DeleteSession(SessionId);

            return true;
        }
        public DataSet GetCuttingDetails(int OrderID, string SessionID)
        {
            return OrderDataProviderInstance.GetCuttingDetails(OrderID, SessionID);
        }
        public DataSet GetAccesoriesDetails(int OrderID)
        {
            return OrderDataProviderInstance.GetAccesoriesDetails(OrderID);
        }


        public DataTable GetSizeQuantity(int OrderDetailId, int Option)
        {
            return OrderDataProviderInstance.GetSizeQuantity(OrderDetailId, Option);
        }

        public DataSet GetTotalSizeByContract(string OrderDetailId)
        {
            return OrderDataProviderInstance.GetTotalSizeByContract(OrderDetailId);
        }


        public int IsSizeByOrderDetailsId(int OrderDetailID)
        {
            return OrderDataProviderInstance.IsSizeByOrderDetailsId(OrderDetailID);
        }

        public DataTable GetCDQDA(int OrderdID)
        {
            DataTable dt;
            dt = OrderDataProviderInstance.GetCDQDA(OrderdID);
            return dt;
        }
        public List<OrderDetailSizes> CheckIsSizeByOrderDetailId(int OrderDetailsID)
        {
            return OrderDataProviderInstance.CheckIsSizeByOrderDetailId(OrderDetailsID);
        }

        public List<OrderDetail> GetOrderDetailByOrderId(int OrderID)
        {
            return OrderDataProviderInstance.GetOrderDetailByOrderId(OrderID);
        }

        public List<OrderDetail> GetSizeSetOption(int CientId, int DeptId)
        {
            return OrderDataProviderInstance.GetSizeSetOption(CientId, DeptId);
        }

        public int CheckSizeByOrderId(int OrderId)
        {
            return OrderDataProviderInstance.CheckSizeByOrderId(OrderId);
        }
        public List<OrderDetail> GetMoETAInfo(string Flag1, string Flag2, int StyleId, string Val1, string Val2, int accworkingID = 0)
        {
            List<OrderDetail> objOrderDetail = this.OrderDataProviderInstance.GetMoETAInfo(Flag1, Flag2, StyleId, Val1, Val2, accworkingID);
            //foreach (MoShippingDetail od in objOrderDetail)
            //{ 
            //    od.ExFactoryColor = CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode);
            //}
            return objOrderDetail;
        }
        public void UpdateEtaRemarks(string Flag1, string Flag2, string remarks, string Name, string ids, string SDate, string EDate, string StyleId, string AccessoryWorkingID)
        {
            OrderDataProviderInstance.UpdateEtaRemarks(Flag1, Flag2, remarks, Name, ids, SDate, EDate, StyleId, AccessoryWorkingID);
        }
        //Added By Ravi on 20/1/2015 for Limitation form
        public string[] GetCMTbyOrderID(int OrderID, int BarrierDay)
        {
            return OrderDataProviderInstance.GetCMTbyOrderID(OrderID, BarrierDay);
        }
        //public List<OrderDetail> GetMoETAInfo(string Flag1, string Flag2, int StyleId, string Val1, string Val2)
        //{
        //    List<OrderDetail> objOrderDetail = this.OrderDataProviderInstance.GetMoETAInfo(Flag1, Flag2, StyleId, Val1, Val2);
        //    //foreach (MoShippingDetail od in objOrderDetail)
        //    //{ 
        //    //    od.ExFactoryColor = CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode);
        //    //}
        //    return objOrderDetail;
        //}
        //public void UpdateEtaRemarks(string Flag1, string Flag2, string remarks, string Name, string ids, string SDate, string EDate, string StyleId)
        //{
        //    OrderDataProviderInstance.UpdateEtaRemarks(Flag1, Flag2, remarks, Name, ids, SDate, EDate, StyleId);
        //}
        //public DataTable CheckFabricInCosting(int StyleId, string Fabric1, string Fabric2, string Fabric3, string Fabric4)
        //{
        //    return OrderDataProviderInstance.CheckFabricInCosting(StyleId, Fabric1, Fabric2, Fabric3, Fabric4);

        //}
        //END 

        //Added By Ravi on 3/2/2015 for Sanjeev Remark
        public string Get_SanjeevRemark(int OrderDetailID)
        {
            return OrderDataProviderInstance.Get_SanjeevRemark(OrderDetailID);
        }
        //Added By Ravi kumar on 19/2/15 For Shiped Check box
        public bool UpdateIsShiped(int OrderDetailsID, int IsShiped, DateTime ShippedDate, int ShippedQty)
        {
            OrderDataProviderInstance.UpdateIsShiped(OrderDetailsID, IsShiped, ShippedDate, ShippedQty);
            return true;
        }
        //Added By Gajendra on 24/12/15 
        public bool UpdateIsShiped_For_Current(int OrderDetailsID, int IsShiped, DateTime ShippedDate, int ShippedQty, float ExpressAiringToUK, float CIFAir, float FiftyPercentCIFAir, float AirToMumbai, float InspectionFailandTransport, float TotalPenalty, float ShippedValue, float PenaltyPercentAge, float OrderDiscount, bool Isdicount, string FileName, int ShippingUnit, int userid)
        {
            OrderDataProviderInstance.UpdateIsShiped_For_Current(OrderDetailsID, IsShiped, ShippedDate, ShippedQty, ExpressAiringToUK, CIFAir, FiftyPercentCIFAir, AirToMumbai, InspectionFailandTransport, TotalPenalty, ShippedValue, PenaltyPercentAge, OrderDiscount, Isdicount, FileName, ShippingUnit, userid);
            return true;
        }
        public bool UpdateIsShipedTodayDate(int OrderDetailsID)
        {
            OrderDataProviderInstance.UpdateIsShipedTodayDate(OrderDetailsID);
            return true;
        }

        //Added By Gajendra on 24/12/15 
        public DataSet GetShippedDetailByID(int OrderDetailId, int DesignationID, int Departmentid)
        {
            return OrderDataProviderInstance.GetShippedDetailByID(OrderDetailId, DesignationID, Departmentid);
        }
        //Added By Ravi kumar on 19/2/15 For Shiped Check box
        public bool UpdateIsShiped(int OrderDetailsID, int IsShiped, DateTime ShippedDate)
        {
            OrderDataProviderInstance.UpdateIsShiped(OrderDetailsID, IsShiped, ShippedDate);
            return true;
        }
        // Add By Ravi kumar on 19/2/2015 for Show Order Comment
        public string GetMoOrderComment(int OrderDetailID)
        {
            return OrderDataProviderInstance.GetMoOrderComment(OrderDetailID);
        }
        // Add By Ravi kumar on 3/3/2015 for Accessories ETA
        public bool UpdateAccessEtaRemarks(string remarks, string Name, int OrderDetailId, string EDate, string AccessoryWorkingID, string Quantity)
        {
            return OrderDataProviderInstance.UpdateAccessEtaRemarks(remarks, Name, OrderDetailId, EDate, AccessoryWorkingID, Quantity);
        }
        //Added By Ashish for Filter Permission on 27/3/2015
        public List<MOOrderDetails> GetPermissionFilter(int DeptId, int DesigId)
        {
            List<MOOrderDetails> objOrderDetail = OrderDataProviderInstance.GetPermissionFilter(DeptId, DesigId);
            return objOrderDetail;
        }
        //Add By Ravi kumar on 4/4/2015 for shipment         
        public string[] GetShippedQty(int OrderDetailsID)
        {
            return OrderDataProviderInstance.GetShippedQty(OrderDetailsID);
        }
        public List<OrderDetail> GetMoInfo(int styleid, int ClientID, int DeptId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, int Tab)
        {
            List<OrderDetail> objOrderDetail = this.OrderDataProviderInstance.GetMoInfo(styleid, ClientID, DeptId, CreateNew, NewRef, ReUse, ReUseStyleId, Tab);
            return objOrderDetail;
        }
        public DataTable GetMoInfoOb_new(int styleid, int ClientID, int DeptId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, int Tab)
        {
            return this.OrderDataProviderInstance.GetMoInfoOb_new(styleid, ClientID, DeptId, CreateNew, NewRef, ReUse, ReUseStyleId, Tab);

        }
        public DataTable GetGarmentType()
        {
            return OrderDataProviderInstance.GetGarmentType();
        }

        public DataTable GetOperationById(string TableName1, string TableName2, string Col1, string Col2, string Col3, string Val)
        {
            return OrderDataProviderInstance.GetOperationById(TableName1, TableName2, Col1, Col2, Col3, Val);
        }
        public DataTable GetWorkerTypeById(int Id, string Flag)
        {
            return OrderDataProviderInstance.GetWorkerTypeById(Id, Flag);
        }
        public DataTable GetAttachmentById(int Id)
        {
            return OrderDataProviderInstance.GetAttachmentById(Id);
        }
        public int InsertUpdateFinalCuttingOB(int ClientID, int ClientDepartmentID, string StyleCode, int StyleId, int GarmentTypeID, int Operationcutting, int FactoryWorkSpace, int AttachmentID, string Flag, int FinalOBID, int ReUseStyleId, int IsReUse, int NewRef, int UserId, float Sfactor, int StyleSequence)
        {
            return this.OrderDataProviderInstance.InsertUpdateFinalCuttingOB(ClientID, ClientDepartmentID, StyleCode, StyleId, GarmentTypeID, Operationcutting, FactoryWorkSpace, AttachmentID, Flag, FinalOBID, ReUseStyleId, IsReUse, NewRef, UserId, Sfactor);
        }

        public DataTable GetFinalOBData(string Flag, OBForm obj_OBForm, int StyleId, int ReUseStyleId, int GarmenttypeId, int IsCreated, int IsReuse, int NewRef)
        {
            return OrderDataProviderInstance.GetFinalOBData(Flag, obj_OBForm, StyleId, ReUseStyleId, GarmenttypeId, IsCreated, IsReuse, NewRef);
        }

        public DataTable IsAllreadySave(string TableName, string Col1, string Val1, string Val2, string Val3, string Val4, string Val5, string Val6)
        {
            return OrderDataProviderInstance.IsAllreadySave(TableName, Col1, Val1, Val2, Val3, Val4, Val5, Val6);
        }
        public int UpdateFinalOB(OBForm prm_OBForm, int StyleId, int ReUseStyleId, string IsReuse, int StyleSequence)
        {
            return this.OrderDataProviderInstance.UpdateFinalOB(prm_OBForm, StyleId, ReUseStyleId, IsReuse, StyleSequence);
        }

        public int UpdateFinalOBProxy(int FinalOBID, int NoOfOperation, float Sam, float MachineCount, int FinalCount, string Comments, string Flag, int ClientID, int DeptId, string StyleCode, int StyleId, int ReUseStyleId, string IsReuse, int StyleSequence, float Factor)
        {
            return this.OrderDataProviderInstance.UpdateFinalOBProxy(FinalOBID, NoOfOperation, Sam, MachineCount, FinalCount, Comments, Flag, ClientID, DeptId, StyleCode, StyleId, ReUseStyleId, IsReuse, StyleSequence, Factor);
        }


        public int InsertSection(OBForm prm_OBForm, int StyleID, int ReUse, int ReUseStyleId)
        {
            return this.OrderDataProviderInstance.InsertSection(prm_OBForm, StyleID, ReUse, ReUseStyleId);
        }

        public DataTable GetSectionById(OBForm prm_OBForm, int StyleID, int IsReuse, int IsCreate, int NewRefrence, int ReUseStyleId)
        {
            return OrderDataProviderInstance.GetSectionById(prm_OBForm, StyleID, IsReuse, IsCreate, NewRefrence, ReUseStyleId);
        }

        public DataTable GetStyleCodeOBByCode(string StyleCode)
        {
            return OrderDataProviderInstance.GetStyleCodeOBByCode(StyleCode);
        }

        public DataTable checkIsStyleCodeSave(OBForm prm_OBForm)
        {
            return OrderDataProviderInstance.checkIsStyleCodeSave(prm_OBForm);
        }

        public DataSet GetOBData(string Flag, string StyleCode, int ClientId, int DeptId, int Garment)
        {
            return OrderDataProviderInstance.GetOBData(Flag, StyleCode, ClientId, DeptId, Garment);
        }

        public DataSet GetAllOBData(int StyleId, int GarmenttypeId)
        {
            return OrderDataProviderInstance.GetAllOBData(StyleId, GarmenttypeId);
        }

        public int DeleteStichedOperation(int ClientID, int ClientDepartmentID, int StyleId)
        {
            return OrderDataProviderInstance.DeleteStichedOperation(ClientID, ClientDepartmentID, StyleId);
        }

        public DataTable GetGarmentTypeByStyleId(int StyleId, string styleCode)
        {
            return OrderDataProviderInstance.GetGarmentTypeByStyleId(StyleId, styleCode);
        }

        public int InsertForReuse(OBForm prm_OBForm, int StyleId, string IsStiched, int FlagStiched, int ReUseStyleId, int IsReuse, int NewRef, int GarmentType)
        {
            return this.OrderDataProviderInstance.InsertForReuse(prm_OBForm, StyleId, IsStiched, FlagStiched, ReUseStyleId, IsReuse, NewRef, GarmentType);
        }
        public int UpdateReuseFlag(int StyleId)
        {
            return this.OrderDataProviderInstance.UpdateReuseFlag(StyleId);
        }

        public DataTable GetStichedManPower(OBForm obj_OBForm, int StyleId, int GarmentTypeID)
        {
            return OrderDataProviderInstance.GetStichedManPower(obj_OBForm, StyleId, GarmentTypeID);
        }

        public int UpdaetStichedManPower(double NoOfMachine, double MachinePercentage, int MachineAttachmentId, int GarmentTypeID, OBForm obj_OBForm, int StyleId)
        {
            return OrderDataProviderInstance.UpdaetStichedManPower(NoOfMachine, MachinePercentage, MachineAttachmentId, GarmentTypeID, obj_OBForm, StyleId);
        }

        public DataTable GetFinishedManPower(OBForm obj_OBForm, int GarmentTypeID)
        {
            return OrderDataProviderInstance.GetFinishedManPower(obj_OBForm, GarmentTypeID);
        }

        public int UpdaetFinishedManPower(double NoOfMachine, double MachinePercentage, int MachineAttachmentId, int GarmentTypeID, OBForm obj_OBForm)
        {
            return OrderDataProviderInstance.UpdaetFinishedManPower(NoOfMachine, MachinePercentage, MachineAttachmentId, GarmentTypeID, obj_OBForm);
        }

        public DataTable GetValuefromTable(string TableName, string Cal1, OBForm obj_OBForm, int GarmentTypeID)
        {
            return OrderDataProviderInstance.GetValuefromTable(TableName, Cal1, obj_OBForm, GarmentTypeID);

        }

        public int UpdateCheckbox(int StyleId, bool IsFactoryIE, bool IsProductionGM, bool IsFactoryManager, bool IsIEManager, int UserId)
        {
            return this.OrderDataProviderInstance.UpdateCheckbox(StyleId, IsFactoryIE, IsProductionGM, IsFactoryManager, IsIEManager, UserId);
        }

        public int GetStyleByStyleId(int StyleId)
        {
            return this.OrderDataProviderInstance.GetStyleByStyleId(StyleId);
        }
        public int GetHoppmCompleteByStyleId(int StyleId)
        {
            return this.OrderDataProviderInstance.GetHoppmCompleteByStyleId(StyleId);
        }
        public int GetCreateOBStatus(int StyleId)
        {
            return this.OrderDataProviderInstance.GetCreateOBStatus(StyleId);
        }
        public int GetCheckIsRepeat(int StyleId)
        {
            return this.OrderDataProviderInstance.GetCheckIsRepeat(StyleId);
        }
        //Added By ashish on 2/6/2015
        public int DeleteOBById(int Id, string Flag)
        {
            return OrderDataProviderInstance.DeleteOBById(Id, Flag);
        }
        //END 
        public DataTable GetManPower(int Styleid, int GarmentTypeId, string Flag, string StyleCode, int IsReUse, int ReUseStyleId, int NewRefrence)
        {
            return OrderDataProviderInstance.GetManPower(Styleid, GarmentTypeId, Flag, StyleCode, IsReUse, ReUseStyleId, NewRefrence);
        }

        public DataSet GetOBRemarks(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId)
        {
            return OrderDataProviderInstance.GetOBRemarks(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId);
        }

        public int InsertupdateOBRemarksDetails(string StyleCode, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string FabricRemark, int RiskFabricId, int StyleSequence, int UserId)
        {
            return OrderDataProviderInstance.InsertupdateOBRemarksDetails(StyleCode, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, FabricRemark, RiskFabricId, StyleSequence, UserId);
        }

        public int ReuseOBRemarks(int styleid, int ReUse, int UserId)
        {
            return OrderDataProviderInstance.ReuseOBRemarks(styleid, ReUse, UserId);
        }

        public int DeleteOBRemarkById(int RemarkId)
        {
            return OrderDataProviderInstance.DeleteOBRemarkById(RemarkId);
        }

        public int GetOperationType(int StyleId, int OperationId, int WorkerTypeId, int NoOfOperation, string Flag, int FinalOBID)
        {
            return OrderDataProviderInstance.GetOperationType(StyleId, OperationId, WorkerTypeId, NoOfOperation, Flag, FinalOBID);
        }

        //Added By Abhishek on 15/5/2015
        public int UpdateOrderAvgBAL(int OrderDetailsID, double OrderAvg, int CountFabric, int StyleID, string FabricName, string printDetails, int IsALL)
        {
            return OrderDataProviderInstance.UpdateOrderAvgDAL(OrderDetailsID, OrderAvg, CountFabric, StyleID, FabricName, printDetails, IsALL);
        }
        //END
        public int DeleteStichedRecordById(int ClientID, int ClientDepartmentID, string StyleCode, int styleId, int ReUseStyleId, int newRef, int Flag)
        {
            return OrderDataProviderInstance.DeleteStichedRecordById(ClientID, ClientDepartmentID, StyleCode, styleId, ReUseStyleId, newRef, Flag);
        }
        public int CheckObIsNeededOrNot(int StyleId)
        {
            return this.OrderDataProviderInstance.CheckObIsNeededOrNot(StyleId);
        }

        //Added By Ashish on 14/7/2015
        public DataTable GetOBPermission(int DeptId, int DesigId, int SectionId)
        {
            return OrderDataProviderInstance.GetOBPermission(DeptId, DesigId, SectionId);
        }

        public int DeleteOBRemarkByStyleId(int StyleId)
        {
            return this.OrderDataProviderInstance.DeleteOBRemarkByStyleId(StyleId);
        }

        // Added by ravi kumar on 21/2/18
        public List<MoShippingDetail> GetReAllocationDetails(int styleId, double StatusFrom, double StatusTo)
        {
            List<MoShippingDetail> objOrderDetail = OrderDataProviderInstance.GetReAllocationDetails(styleId, StatusFrom, StatusTo);
            foreach (MoShippingDetail od in objOrderDetail)
            {
                //od.ExFactoryColor = CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode);
                if (od.ExFactory.Date < DateTime.Now.Date)
                {
                    od.ExFactoryColor = "#ff3300";
                }
                if (od.ExFactory.Date > DateTime.Now.Date)
                {
                    od.ExFactoryColor = "#FFFFFF";
                }
                if (od.ExFactory.Date == DateTime.Now.Date || od.ExFactory == DateTime.Today.Date.AddDays(1))
                {
                    od.ExFactoryColor = "#fd9903";
                }
            }
            return objOrderDetail;
        }
        public List<MoShippingDetail> GetQuantity_Allocation_Details(int styleId, double StatusFrom, double StatusTo)
        {
            List<MoShippingDetail> objOrderDetail = OrderDataProviderInstance.GetQuantity_Allocation_Details(styleId, StatusFrom, StatusTo);
            foreach (MoShippingDetail od in objOrderDetail)
            {
                //od.ExFactoryColor = CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode);
                if (od.ExFactory.Date < DateTime.Now.Date)
                {
                    od.ExFactoryColor = "#ff3300";
                }
                if (od.ExFactory.Date > DateTime.Now.Date)
                {
                    od.ExFactoryColor = "#FFFFFF";
                }
                if (od.ExFactory.Date == DateTime.Now.Date || od.ExFactory == DateTime.Today.Date.AddDays(1))
                {
                    od.ExFactoryColor = "#fd9903";
                }
            }
            return objOrderDetail;
        }
        public DataTable CheckCutting_FinishingActive(int ProductionId)
        {
            return OrderDataProviderInstance.CheckCutting_FinishingActive(ProductionId);
        }


        public int SaveReAllocationPartialOrFull(int OrderDetailsId, bool IsPartialOrFull, bool IsRealocationFull)
        {
            return this.OrderDataProviderInstance.SaveReAllocationPartialOrFull(OrderDetailsId, IsPartialOrFull, IsRealocationFull);
        }
        public int SaveVAReAllocationPartialOrFull(int StyleId, int VA_ID, bool IsPartialOrFull, bool IsRealocationFull)
        {
            return this.OrderDataProviderInstance.SaveVAReAllocationPartialOrFull(StyleId, VA_ID, IsPartialOrFull, IsRealocationFull);
        }
        public int updateRescan(ProductionDetail objProduction, int CycleCount, int UserId)
        {
            return this.OrderDataProviderInstance.updateRescan(objProduction, CycleCount, UserId);
        }
        public int SubmitRescan(int Orderdetilaid, string date, int RescanQty, int FailQty, int ManPower, double workingHrs, string BreakDownRemarks, bool IncludedRescan, int UnitId, int CycleNo)
        {
            return this.OrderDataProviderInstance.SubmitRescan(Orderdetilaid, date, RescanQty, FailQty, ManPower, workingHrs, BreakDownRemarks, IncludedRescan, UnitId, CycleNo);
        }
        public int InsertUpdatePartialOrFullAllocation(int OrderDetailsId, int Factory, int Cutting, int Stitching, int Finishing, int ReAllocationId, int TdyCutReady, int TdyCutIssueOutHouse, bool CheckDelete, bool IsOHStitchComplete, string Committed_EndDate, int UserID)
        {
            return this.OrderDataProviderInstance.InsertUpdatePartialOrFullAllocation(OrderDetailsId, Factory, Cutting, Stitching, Finishing, ReAllocationId, TdyCutReady, TdyCutIssueOutHouse, CheckDelete, IsOHStitchComplete, Committed_EndDate, UserID);
        }

        //ADDED BY RAGHVINDER ON 10-09-2020 STARTS
        public int CreateReallocationHistory(int OrderDetailsId, int Factory, int Cutting, int Stitching, int Finishing, int ReAllocationId, int UserID)
        {
            return this.OrderDataProviderInstance.CreateReallocationHistory(OrderDetailsId, Factory, Cutting, Stitching, Finishing, ReAllocationId, UserID);
        }

        public int DeleteReallocationHistory(int OrderDetailsId, int Factory, int UserID)
        {
            return this.OrderDataProviderInstance.DeleteReallocationHistory(OrderDetailsId, Factory, UserID);
        }

        public int UpdateReallocationHistory(int OrderDetailsId, int Factory, int Cutting, int Stitching, int Finishing, int ReAllocationId, int UserID)
        {
            return this.OrderDataProviderInstance.UpdateReallocationHistory(OrderDetailsId, Factory, Cutting, Stitching, Finishing, ReAllocationId, UserID);
        }

        public DataTable GetReallocationPreviousValues(int ReAllocationId)
        {
            return this.OrderDataProviderInstance.GetReallocationPreviousValues(ReAllocationId);
        }
        //ADDED BY RAGHVINDER ON 10-09-2020 ENDS

        public int InsertVA_AllocationDetails(int StyleId, int VA_Id, int SupplierId, int AllocationQty1, int AllocationQty2, int PerDayOutPut, string Committed_EndDate, int orderdetialid)
        {
            return this.OrderDataProviderInstance.InsertVA_AllocationDetails(StyleId, VA_Id, SupplierId, AllocationQty1, AllocationQty2, PerDayOutPut, Committed_EndDate, orderdetialid);
        }
        public int InsertVA_Details(int StyleId, int VA_Id, string SupplierName, bool Finalize, double Rate, double IntialAgreementRate, int RiskSupplierID)
        {
            return this.OrderDataProviderInstance.InsertVA_Details(StyleId, VA_Id, SupplierName, Finalize, Rate, IntialAgreementRate, RiskSupplierID);
        }
        public DataSet GetRescan_History(int OrderDetailID, int CycleNo)
        {
            return this.OrderDataProviderInstance.GetRescan_History(OrderDetailID, CycleNo);
        }
        public DataSet GetFaultType_Rescan(int OrderDetailID, int CycleNo)
        {
            return this.OrderDataProviderInstance.GetFaultType_Rescan(OrderDetailID, CycleNo);
        }
        public bool UpdateSelectCheckBox(string IsCheked, string FaultID, string OrderdetailId, string type, int CreatedBy)
        {
            return this.OrderDataProviderInstance.UpdateSelectCheckBox(IsCheked, FaultID, OrderdetailId, type, CreatedBy);
        }
        public DataSet GetSubFaultType_Rescan(int OrderDetailID)
        {
            return this.OrderDataProviderInstance.GetSubFaultType_Rescan(OrderDetailID);
        }
        public DataTable GetSubFaultType_View(int OrderDetailID)
        {
            return this.OrderDataProviderInstance.GetSubFaultType_View(OrderDetailID);
        }
        public string SubFaultType_Rescan_InstUpdt(int Orderdetailid, string FaultDescription, int CreatedBy)
        {
            return this.OrderDataProviderInstance.SubFaultType_Rescan_InstUpdt(Orderdetailid, FaultDescription, CreatedBy);
        }
        public int SubFaultType_Rescan_Delete(int Id)
        {
            return this.OrderDataProviderInstance.SubFaultType_Rescan_Delete(Id);
        }
        public int UpdateCheckDelete(int StyleId, int OrderDetailsId, int UserID)
        {
            return this.OrderDataProviderInstance.UpdateCheckDelete(StyleId, OrderDetailsId, UserID);
        }

        public int DeleteReallocationEntry(int OrderDetailsId, int Factory, int userID)
        {
            return this.OrderDataProviderInstance.DeleteReallocationEntry(OrderDetailsId, Factory, userID);
        }
        public int DeleteVA_DetailsEntry(string suppliername, int styleid, int VA_Id, int RiskSupplierID)
        {
            return this.OrderDataProviderInstance.DeleteVA_DetailsEntry(suppliername, styleid, VA_Id, RiskSupplierID);
        }
        public int DeleteVA_Quantity_AllocationEntry(int supplierid, int VA_Id)
        {
            return this.OrderDataProviderInstance.DeleteVA_Quantity_AllocationEntry(supplierid, VA_Id);
        }
        public DataSet GetSumAltpluspasspcs(int OrderDetailsId, int unitid)
        {
            return this.OrderDataProviderInstance.GetSumAltpluspasspcs(OrderDetailsId, unitid);
        }
        public DataSet GetReAllocationUnit(int OrderDetailsId, int ReallocationID)
        {
            return this.OrderDataProviderInstance.GetReAllocationUnit(OrderDetailsId, ReallocationID);
        }
        public DataSet GetVADetails(int Styleid, string Suppliername, int ValueAdditionID)
        {
            return this.OrderDataProviderInstance.GetVADetails(Styleid, Suppliername, ValueAdditionID);
        }
        public DataSet GetVADetails()
        {
            return this.OrderDataProviderInstance.GetVADetails();
        }
        public DataSet GetReAllocationDetailsById(int OrderDetailsId, int unitid)
        {
            return this.OrderDataProviderInstance.GetReAllocationDetailsById(OrderDetailsId, unitid);
        }
        public DataSet GetVADetails(int Styleid, int VA_Id)
        {
            return this.OrderDataProviderInstance.GetVADetails(Styleid, VA_Id);
        }
        public DataSet GetRell_VA_Details(int Styleid, int VA_ID, int orderdetailid)
        {
            return this.OrderDataProviderInstance.GetRell_VA_Details(Styleid, VA_ID, orderdetailid);
        }
        public int DeleteReAllocation(int OrderDetailsId)
        {
            return this.OrderDataProviderInstance.DeleteReAllocation(OrderDetailsId);
        }

        public int UpdatelineQty_unitQty(int lineQty, int unitid, int orderdetailid, string type, int lineplanid, int UserId)
        {
            return this.OrderDataProviderInstance.UpdatelineQty_unitQty(lineQty, unitid, orderdetailid, type, lineplanid, UserId);
        }

        public int UpdateCuttingQty(int UnitId, int OrderDetailId, int UnitQty, int UserId)
        {
            return this.OrderDataProviderInstance.UpdateCuttingQty(UnitId, OrderDetailId, UnitQty, UserId);
        }

        public int UpdateFinishingQty(int UnitId, int OrderDetailId, int UnitQty, int UserId)
        {
            return this.OrderDataProviderInstance.UpdateFinishingQty(UnitId, OrderDetailId, UnitQty, UserId);
        }

        // Add by Ravi kumar on 28/10/15 for Line intimation on Limitation form

        public string LineUpdateByLimitation(int OrderId, int DaysDiff)
        {
            return this.OrderDataProviderInstance.LineUpdateByLimitation(OrderId, DaysDiff);
        }

        public double GetDirectRepeatCut_Avg(int Styleid, string FabricName, int countFabric, string PrintDetails, int orderDetailID)
        {
            return this.OrderDataProviderInstance.GetDirectRepeatCut_Avg(Styleid, FabricName, countFabric, PrintDetails, orderDetailID);
        }
        // Add By Ravi kumar for checking Stitched or not
        public int CheckStitched_ByOrderDetailId(int OrderDetailId)
        {
            return OrderDataProviderInstance.CheckStitched_ByOrderDetailId(OrderDetailId);
        }
        //Added by  abhishek on 25/12/2015
        public int UploadTestReportMo(int OrderDetailId, string filepath1, string filepath2, string filepath3, string isCheked)
        {
            return OrderDataProviderInstance.UploadTestReportMo(OrderDetailId, filepath1, filepath2, filepath3, isCheked);
        }

        public DataTable GetTestReportMo(int OrderDetailId)
        {
            return OrderDataProviderInstance.GetTestReportMo(OrderDetailId);
        }

        public int UpdateFabricWorkingETARemarks(int orderID, string fabricDetails, String Flag, string Remarks)
        {
            return OrderDataProviderInstance.UpdateFabricWorkingETARemarks(orderID, fabricDetails, Flag, Remarks);

        }
        public string GetFabricWorkingETARemarks(string Flag, int OrderID)
        {
            string objOrderDetail = this.OrderDataProviderInstance.GetFabricWorkingETARemarks(Flag, OrderID);

            return objOrderDetail;
        }
        public DataSet GetMoFabricETA_Status(string Flag, int OrderDetailsId)
        {
            return this.OrderDataProviderInstance.GetMoFabricETA_Status(Flag, OrderDetailsId);
        }
        // end by abhishek on 25/12/2015

        // Add By Ravi kumar on 1/1/2016 for checking SizeSet_ByOrderDetailId or not
        public int CheckSizeSet_ByOrderDetailId(int OrderDetailId)
        {
            return OrderDataProviderInstance.CheckSizeSet_ByOrderDetailId(OrderDetailId);
        }

        public int Update_cutting_Stitching_Finishing_ByOrderDetailId(int OrderDetailId, string Type, int UnitId, int Value, int UserId)
        {
            return OrderDataProviderInstance.Update_cutting_Stitching_Finishing_ByOrderDetailId(OrderDetailId, Type, UnitId, Value, UserId);

        }
        //adedd by abhishek on 19/1/2016
        public bool UpdatePhotoShot(string Photoshotdate, int IsPicShot, int orderDetails_ID)
        {
            return OrderDataProviderInstance.UpdatePhotoShot(Photoshotdate, IsPicShot, orderDetails_ID);

        }

        public int UploadFilePeekCap(int OrderDeailsId, string fileName)
        {
            return OrderDataProviderInstance.UploadFilePeekCap(OrderDeailsId, fileName);
        }
        public DataTable GetPeekCapacityFile(int OrderDetailsId)
        {
            return this.OrderDataProviderInstance.GetPeekCapacityFile(OrderDetailsId);
        }

        //end by abhishek on 19/1/2016

        // Add By Ravi kumar on 31/3/2016 for CQD Name
        public int SaveCQDByOrderId(int orderid)
        {
            return OrderDataProviderInstance.SaveCQDByOrderId(orderid);
        }
        public List<OrderDetail> GetManageOrderiKandiQuantityByMode(int mode)
        {
            return OrderDataProviderInstance.GetManageOrderiKandiQuantityByMode(mode);
        }
        public int SaveMOOrderDetails(string POUploadFile1Name, string POUploadFile2Name, string POUploadFile3Name, int POorderdetailID)
        {
            return OrderDataProviderInstance.SaveMOOrderDetails(POUploadFile1Name, POUploadFile2Name, POUploadFile3Name, POorderdetailID);
        }
        public int UpdatePOUploadTask(int POorderdetailID, int UserID)
        {
            return OrderDataProviderInstance.UpdatePOUploadTask(POorderdetailID, UserID);
        }
        public int UpdateIC_Check(int OrderID, int orderDetails_ID, int Ischeck)
        {
            return OrderDataProviderInstance.UpdateIC_Check(OrderID, orderDetails_ID, Ischeck);
        }
        public int update_OutHouse(int orderDetails_ID, int OutHouse)
        {
            return OrderDataProviderInstance.update_OutHouse(orderDetails_ID, OutHouse);
        }
        public int DeleteAddFualtDetails(int OrderDetaild, int Cnty, string FaultName, string FlagIsDelete)
        {
            return OrderDataProviderInstance.DeleteAddFualtDetails(OrderDetaild, Cnty, FaultName, FlagIsDelete);
        }
        public bool UpdateAccAppDate(int WorkingAccID, string Date, int OrderDetailsID)
        {
            return OrderDataProviderInstance.UpdateAccAppDate(WorkingAccID, Date, OrderDetailsID);
        }
        public DataSet GetCriticalPathReportNew(int UserID, string ClientDeptID,int FilterBy)//abhishek 5/1/2017
        {
            return OrderDataProviderInstance.GetCriticalPathReportNew(UserID, ClientDeptID, FilterBy);
        }
        public DataSet GetCriticalDepertmentWiseUser(int UserID, string ClientDeptID)//abhishek 5/1/2017
        {
            return OrderDataProviderInstance.GetCriticalDepertmentWiseUser(UserID, ClientDeptID);
        }
        public DataSet GetSampleTrackerDetails(int UserID, string ClinetDeptId,int FilterBy)//shubhendu 5/10/2021
        {
            return OrderDataProviderInstance.GetSampleTrackerDetails(UserID, ClinetDeptId, FilterBy);
        }
        public DataSet GetSampleTrackerWiseUser(int UserID, string ClientDeptID)//abhishek 5/1/2017
        {
            return OrderDataProviderInstance.GetSampleTrackerWiseUser(UserID, ClientDeptID);
        }
        public DataSet GetClientDepartment(int userID)
        {
            return OrderDataProviderInstance.GetClientDepartment(userID);
        }
        public DataSet GetChildDepartment(int ParentDeptID)
        {
            return OrderDataProviderInstance.GetChildDepartment(ParentDeptID);
        }
        public DataSet GetParentDepartment()
        {
            return OrderDataProviderInstance.GetParentDepartment();
        }

        // Add By Ravi kumar on 29/10/16 from M.O filter Permission
        public DataTable GetMO_OrderByFilter(int DeptId, int DesigId)
        {
            return OrderDataProviderInstance.GetMO_OrderByFilter(DeptId, DesigId);
        }
        //abhishek 9/11/16
        public DataTable GetAltAllSum(int OrderDetailID, int UnitID, int LinePlaingID, string Slotdate)
        {
            return OrderDataProviderInstance.GetAltAllSum(OrderDetailID, UnitID, LinePlaingID, Slotdate);
        }
        public int DeleteAddFualtDetails_IStitchedSlotEntry(int LinePlanID, int FaultQnty, int OrderDetailID, string FaultName, string FlagIsDelete, string Startdate)
        {
            return OrderDataProviderInstance.DeleteAddFualtDetails_IStitchedSlotEntry(LinePlanID, FaultQnty, OrderDetailID, FaultName, FlagIsDelete, Startdate);
        }
        public DataSet GetStichedSlotAltSumFaultName(int OrderDetailId, int linePlaningID)
        {
            return OrderDataProviderInstance.GetStichedSlotAltSumFaultName(OrderDetailId, linePlaningID);
        }
        public List<MOOrderDetails> GetOrdersBasicInfoForPrint(string searchText,string FabricName, string years, DateTime FromDate, DateTime ToDate, int clientId,
                                                      int dateType, int userId, int statusMode, int statusModesSequence,
                                                      int orderBy1, int orderBy2, int orderBy3, int orderBy4,
                                                      string orderDetailIds, int buyingHouseId, int unintID, int desigId, int DeptId, int SalesView, string SessionId, int ClientDeptId,
                                                      string DelayOrderDetailIds, int OrderTpes, int IsUnshipped)
        {
            List<MOOrderDetails> objOrderDetail = OrderDataProviderInstance.GetOrdersBasicInfoForPrint(searchText,FabricName ,years, FromDate, ToDate,
                                                                                          clientId, dateType, userId,
                                                                                          statusMode,
                                                                                          statusModesSequence,
                                                                                          orderBy1, orderBy2, orderBy3,
                                                                                          orderBy4, orderDetailIds,
                                                                                          buyingHouseId, unintID, desigId, DeptId, SalesView, SessionId, ClientDeptId, DelayOrderDetailIds, OrderTpes, IsUnshipped
                                                                                          );


            foreach (MOOrderDetails od in objOrderDetail)
            {
                od.ExFactoryColor = CommonHelper.GetExFactoryColor(od.ExFactory, od.DC, od.Mode);
                // edit by surendra on 14/10/2013
                //od.PCDColor = CommonHelper.GetPCDColor(od.PcDate, od.ParentOrder.CuttingHistory.PcsCut);
                //end

                if (od.bExFactoryRead == true || od.bModeRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        od.ExFactoryColor = "#F9F9FA";
                        od.ExFactoryForeColor = "#807F80";
                    }
                    else
                    {
                        if (od.ExFactory.Date < DateTime.Now.Date)
                        {
                            od.ExFactoryColor = "#ff3300";
                            od.ExFactoryForeColor = "#000000";

                        }
                        if (od.ExFactory.Date > DateTime.Now.Date)
                        {
                            od.ExFactoryColor = "#FFFFFF";
                            od.ExFactoryForeColor = "#000000";
                        }
                        if (od.ExFactory.Date == DateTime.Now.Date || od.ExFactory == DateTime.Today.Date.AddDays(1))
                        {
                            od.ExFactoryColor = "#fd9903";
                            od.ExFactoryForeColor = "#000000";
                        }
                    }
                }
                else
                {
                    od.ExFactoryColor = "#FFFFFF";
                    od.ExFactoryForeColor = "#000000";
                }

                //Added By Ashish on 19/02/2015 
                //Added By Ashish on 23/03/2015 
                if (od.FitsPCDRead == true)
                {
                    if (od.IsShiped == true)
                    {
                        od.PCDBackColor = "#F9F9FA";
                        od.PCDForeColor = "#807F80";
                    }
                    else
                    {
                        if (od.PCDDate.Date >= DateTime.Now.Date && od.BulkCuttingTarget.Date == DateTime.MinValue)
                        {
                            od.PCDBackColor = "#FFFFFF";
                            od.PCDForeColor = "#000000";
                        }
                        else if (od.PCDDate.Date < DateTime.Now.Date && od.BulkCuttingTarget.Date == DateTime.MinValue)
                        {
                            od.PCDBackColor = "#FF3300";
                            od.PCDForeColor = "#FFFF96";
                        }
                        else if (od.PCDDate.Date >= od.BulkCuttingTarget.Date)
                        {
                            //od.PCDBackColor = "#d7e4bc";
                            od.PCDBackColor = "#00FF70";
                            od.PCDForeColor = "#000000";
                        }
                        else if (od.PCDDate.Date < od.BulkCuttingTarget.Date)
                        {
                            od.PCDBackColor = "#FF3300";
                            od.PCDForeColor = "#FFFF96";
                        }
                        else
                        {
                            od.PCDBackColor = "#FFFFFF";
                            od.PCDForeColor = "#000000";
                        }
                    }
                }
                else
                {
                    od.PCDBackColor = "#FFFFFF";
                    od.PCDForeColor = "#000000";
                }
                //END


                //Added By Ravi on 23/04/2015 
                string Fabric1BackColor = "";
                string Fabric2BackColor = "";
                string Fabric3BackColor = "";
                string Fabric4BackColor = "";
                string Fabric5BackColor = "";
                string Fabric6BackColor = "";
                od.FabricAvgColor1 = string.Empty;
                od.FabricAvgColor2 = string.Empty;
                od.FabricAvgColor3 = string.Empty;
                od.FabricAvgColor4 = string.Empty;



                if (od.Fabric1 != "")
                {
                    //if (od.OrderID == Convert.ToInt32("5225"))
                    //{
                    if (od.IsShiped == true)
                    {
                        od.FabricAvgColor1 = "#F9F9FA";
                    }
                    else
                    {
                        od.FabricAvgColor1 = "#f9f9fa";
                    }
                    //}

                    Fabric1BackColor = CommonHelper.GetBIHBackColorCode(od.BulkTarget, od.Fabric1ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.FBIHDateRead);
                    //Fabric1ForColor = CommonHelper.GetBIHForColorCode(od.BulkTarget, od.Fabric1ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped);
                }
                if (od.Fabric2 != "")
                {
                    //if (od.OrderID == Convert.ToInt32("5225"))
                    //{
                    if (od.IsShiped == true)
                    {
                        od.FabricAvgColor2 = "#F9F9FA";
                    }
                    else
                    {
                        od.FabricAvgColor2 = "#f9f9fa";
                    }
                    //}
                    Fabric2BackColor = CommonHelper.GetBIHBackColorCode(od.BulkTarget, od.Fabric2ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.FBIHDateRead);
                    //Fabric2ForColor = CommonHelper.GetBIHForColorCode(od.BulkTarget, od.Fabric2ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped);
                }
                if (od.Fabric3 != "")
                {
                    //if (od.OrderID == Convert.ToInt32("5225"))
                    //{
                    if (od.IsShiped == true)
                    {
                        od.FabricAvgColor3 = "#F9F9FA";
                    }
                    else
                    {
                        od.FabricAvgColor3 = "#f9f9fa";
                    }
                    //}
                    Fabric3BackColor = CommonHelper.GetBIHBackColorCode(od.BulkTarget, od.Fabric3ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.FBIHDateRead);
                    //Fabric3ForColor = CommonHelper.GetBIHForColorCode(od.BulkTarget, od.Fabric3ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped);
                }
                if (od.Fabric4 != "")
                {
                    //if (od.OrderID == Convert.ToInt32("5225"))
                    //{
                    if (od.IsShiped == true)
                    {
                        od.FabricAvgColor4 = "#F9F9FA";
                    }
                    else
                    {
                        od.FabricAvgColor4 = "#f9f9fa";
                    }
                    //}
                    Fabric4BackColor = CommonHelper.GetBIHBackColorCode(od.BulkTarget, od.Fabric4ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.FBIHDateRead);
                    //Fabric4ForColor = CommonHelper.GetBIHForColorCode(od.BulkTarget, od.Fabric4ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped);
                }

                // Red
                if (Fabric1BackColor == "#FF3300")
                    od.BIHBackColor = "#FF3300";

                if (Fabric2BackColor == "#FF3300")
                    od.BIHBackColor = "#FF3300";

                if (Fabric3BackColor == "#FF3300")
                    od.BIHBackColor = "#FF3300";

                if (Fabric4BackColor == "#FF3300")
                    od.BIHBackColor = "#FF3300";

                if (od.Fabric_ModuleDatabase != "")
                {
                    if (Fabric5BackColor == "#FF3300")
                        od.BIHBackColor = "#FF3300";
                    if (Fabric6BackColor == "#FF3300")
                        od.BIHBackColor = "#FF3300";
                }
                // white
                if (Fabric1BackColor == "#FFFFFF")
                    od.BIHBackColor = "#FFFFFF";

                if (Fabric2BackColor == "#FFFFFF")
                    od.BIHBackColor = "#FFFFFF";

                if (Fabric3BackColor == "#FFFFFF")
                    od.BIHBackColor = "#FFFFFF";

                if (Fabric4BackColor == "#FFFFFF")
                    od.BIHBackColor = "#FFFFFF";

                if (od.Fabric_ModuleDatabase != "")
                {
                    if (Fabric5BackColor == "#FFFFFF")
                        od.BIHBackColor = "#FFFFFF";
                    if (Fabric6BackColor == "#FFFFFF")
                        od.BIHBackColor = "#FFFFFF";
                }
                // shipped
                if (Fabric1BackColor == "#F9F9FA")
                    od.BIHBackColor = "#F9F9FA";

                if (Fabric2BackColor == "#F9F9FA")
                    od.BIHBackColor = "#F9F9FA";

                if (Fabric3BackColor == "#F9F9FA")
                    od.BIHBackColor = "#F9F9FA";

                if (Fabric4BackColor == "#F9F9FA")
                    od.BIHBackColor = "#F9F9FA";

                if (od.Fabric_ModuleDatabase != "")
                {
                    if (Fabric5BackColor == "#F9F9FA")
                        od.BIHBackColor = "#F9F9FA";
                    if (Fabric6BackColor == "#F9F9FA")
                        od.BIHBackColor = "#F9F9FA";
                }
                // Final
                //if red
                if (od.BIHBackColor == "#FF3300")
                {
                    od.BIHBackColor = "#FF3300";
                    od.BIHForColor = "#FFFF96";
                }
                // if white
                else if (od.BIHBackColor == "#FFFFFF")
                {
                    od.BIHBackColor = "#FFFFFF";
                    od.BIHForColor = "#000000";
                }
                // if shipped
                else if (od.BIHBackColor == "#F9F9FA")
                {
                    od.BIHBackColor = "#F9F9FA";
                    od.BIHForColor = "#807F80";
                }
                // if green
                else
                {
                    od.BIHBackColor = "#00FF70";
                    od.BIHForColor = "#000000";
                }

                //End By Ravi on 23/04/2015    

                //od.StcBackColor = CommonHelper.GetTechnicalBackColor(od.STCDateReqTar, od.ParentOrder.Fits.SealDate, od.IsShiped);
                //od.StcForColor = CommonHelper.GetTechnicalForColor(od.STCDateReqTar, od.ParentOrder.Fits.SealDate, od.IsShiped);

                //od.PatternBackColor = CommonHelper.GetTechnicalBackColor(od.PatternSampleDate, od.STCDateReqTarPattern, od.IsShiped);
                //od.PatternForColor = CommonHelper.GetTechnicalForColor(od.PatternSampleDate, od.STCDateReqTarPattern, od.IsShiped);

                od.StartETA1BackColor = CommonHelper.GetStartETABackColor(od.fabric1ETA, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.BulkTarget, od.FFabStartETARead);
                od.StartETA1ForColor = CommonHelper.GetStartETAForColor(od.fabric1ETA, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.BulkTarget);
                od.ENDETA1BackColor = CommonHelper.GetETABackColor(od.Fabric1ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.BulkTarget, od.FFabEndETAWrite);
                od.ENDETA1ForColor = CommonHelper.GetETAForColor(od.Fabric1ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.BulkTarget);

                od.StartETA2BackColor = CommonHelper.GetStartETABackColor(od.fabric2ETA, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.BulkTarget, od.FFabStartETARead);
                od.StartETA2ForColor = CommonHelper.GetStartETAForColor(od.fabric2ETA, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.BulkTarget);
                od.ENDETA2BackColor = CommonHelper.GetETABackColor(od.Fabric2ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.BulkTarget, od.FFabEndETAWrite);
                od.ENDETA2ForColor = CommonHelper.GetETAForColor(od.Fabric2ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.BulkTarget);

                od.StartETA3BackColor = CommonHelper.GetStartETABackColor(od.fabric3ETA, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.BulkTarget, od.FFabStartETARead);
                od.StartETA3ForColor = CommonHelper.GetStartETAForColor(od.fabric3ETA, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.BulkTarget);
                od.ENDETA3BackColor = CommonHelper.GetETABackColor(od.Fabric3ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.BulkTarget, od.FFabEndETAWrite);
                od.ENDETA3ForColor = CommonHelper.GetETAForColor(od.Fabric3ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.BulkTarget);

                od.StartETA4BackColor = CommonHelper.GetStartETABackColor(od.fabric4ETA, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.BulkTarget, od.FFabStartETARead);
                od.StartETA4ForColor = CommonHelper.GetStartETAForColor(od.fabric4ETA, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.BulkTarget);
                od.ENDETA4BackColor = CommonHelper.GetETABackColor(od.Fabric4ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.BulkTarget, od.FFabEndETAWrite);
                od.ENDETA4ForColor = CommonHelper.GetETAForColor(od.Fabric4ENDETA, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.BulkTarget);

                od.Fabric1NameBackColor = CommonHelper.GetFabricNameBackColor(od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.BulkTarget, od.FQualityRead);
                od.Fabric1NameForColor = CommonHelper.GetFabricNameForColor(od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.BulkTarget);
                od.Fabric2NameBackColor = CommonHelper.GetFabricNameBackColor(od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.BulkTarget, od.FQualityRead);
                od.Fabric2NameForColor = CommonHelper.GetFabricNameForColor(od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.BulkTarget);
                od.Fabric3NameBackColor = CommonHelper.GetFabricNameBackColor(od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.BulkTarget, od.FQualityRead);
                od.Fabric3NameForColor = CommonHelper.GetFabricNameForColor(od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.BulkTarget);
                od.Fabric4NameBackColor = CommonHelper.GetFabricNameBackColor(od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.BulkTarget, od.FQualityRead);
                od.Fabric4NameForColor = CommonHelper.GetFabricNameForColor(od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.BulkTarget);

                od.BulkApproval1BackColor = CommonHelper.GetBulkSatusBackColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab1ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.FQualityRead);
                od.BulkApproval1ForColor = CommonHelper.GetBulkSatusForeColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab1ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped);
                od.BulkApproval2BackColor = CommonHelper.GetBulkSatusBackColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab2ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.FQualityRead);
                od.BulkApproval2ForColor = CommonHelper.GetBulkSatusForeColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab2ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped);
                od.BulkApproval3BackColor = CommonHelper.GetBulkSatusBackColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab3ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.FQualityRead);
                od.BulkApproval3ForColor = CommonHelper.GetBulkSatusForeColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab3ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped);
                od.BulkApproval4BackColor = CommonHelper.GetBulkSatusBackColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab4ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.FQualityRead);
                od.BulkApproval4ForColor = CommonHelper.GetBulkSatusForeColor(od.BulkTarget, od.ParentOrder.FabricApprovalDetails.Fab4ActionDate, od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped);

                //
                od.TractStatus1ForColor = CommonHelper.GetTrackingSatusForeColor(od.FabricTrackingTarget1, od.Fabric1actionDate, od.IsShiped);
                od.TractStatus2ForColor = CommonHelper.GetTrackingSatusForeColor(od.FabricTrackingTarget2, od.Fabric2actionDate, od.IsShiped);
                od.TractStatus3ForColor = CommonHelper.GetTrackingSatusForeColor(od.FabricTrackingTarget3, od.Fabric3actionDate, od.IsShiped);
                od.TractStatus4ForColor = CommonHelper.GetTrackingSatusForeColor(od.FabricTrackingTarget4, od.Fabric4actionDate, od.IsShiped);

                //

                od.Percent1BackColor = CommonHelper.GetPercentBackColor(od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped, od.FPerInhouseRead);
                od.Percent1ForColor = CommonHelper.GetPercentForColor(od.ParentOrder.FabricInhouseHistory.Fabric1Percent, od.IsShiped);
                od.Percent2BackColor = CommonHelper.GetPercentBackColor(od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped, od.FPerInhouseRead);
                od.Percent2ForColor = CommonHelper.GetPercentForColor(od.ParentOrder.FabricInhouseHistory.Fabric2Percent, od.IsShiped);
                od.Percent3BackColor = CommonHelper.GetPercentBackColor(od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped, od.FPerInhouseRead);
                od.Percent3ForColor = CommonHelper.GetPercentForColor(od.ParentOrder.FabricInhouseHistory.Fabric3Percent, od.IsShiped);
                od.Percent4BackColor = CommonHelper.GetPercentBackColor(od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped, od.FPerInhouseRead);
                od.Percent4ForColor = CommonHelper.GetPercentForColor(od.ParentOrder.FabricInhouseHistory.Fabric4Percent, od.IsShiped);



                od.LinktypeBackColor = CommonHelper.GetLinktypeBackColor(od.IsShiped);
                od.LinktypeForeColor = CommonHelper.GetLinktypeForeColor(od.IsShiped);
                od.BlackToForeColor = CommonHelper.GetBlackToForeColor(od.IsShiped);

                //Added By Ashish on 29/28/2015
                od.stylenumberColor = CommonHelper.GetstylenumberColor(od.IsShiped, od.IsRiskTask);
                od.SamOBValColor = CommonHelper.GetSamOBValColor(od.IsShiped, od.IsOBCreate, od.IsFinalizeOB);
                //END
                od.PricevariationColor = CommonHelper.GetPricevariationForeColor(od.IsShiped);
                //od.AuditvariationColor = CommonHelper.GetAuditForeColor(od.IsShiped, od.AuditStatus);
                od.CQDForeColor = CommonHelper.CQDForeColor(od.IsShiped);
                od.SummryColor = CommonHelper.GetSummaryForeColor(od.IsShiped);
                // updated  By sushil on 26/3/2015
                od.LinktypeForeColorforfitspending = CommonHelper.GetLinktypeForeColorforfitspending(od.IsShiped, od.IsFitsPending);
                od.FitsPandingColor = CommonHelper.GetFitsPendingBackColor(od.IsFitsPending, od.IsShiped);
                // End updated  By sushil on 26/3/2015
                //Added By Ashish on 9/4/2015
                od.FitsSTCETABackColor = CommonHelper.GetTechnicalETABackColor(od.STCETA, od.IsShiped, od.STCtargetsDate, od.FitsSTCETARead, od.ParentOrder.Fits.SealDate);
                od.FitsSTCETAForColor = CommonHelper.GetTechnicalETAForColor(od.STCETA, od.IsShiped, od.STCtargetsDate, od.FitsSTCETARead, od.ParentOrder.Fits.SealDate);
                od.FitsPatternETABackColor = CommonHelper.GetTechnicalETABackColor(od.PatternSampleDateETA, od.IsShiped, od.PatternSampleTarget, od.FitsPatternETARead, od.PatternSampleDate);
                od.FitsPatternETAForColor = CommonHelper.GetTechnicalETAForColor(od.PatternSampleDateETA, od.IsShiped, od.PatternSampleTarget, od.FitsPatternETARead, od.PatternSampleDate);
                od.FitsCuttingETABackColor = CommonHelper.GetTechnicalETABackColor(od.CuttingReceivedDateETA, od.IsShiped, od.CuttingTarget, od.FitsCuttingETARead, od.CuttingReceivedDate);
                od.FitsCuttingETAForColor = CommonHelper.GetTechnicalETAForColor(od.CuttingReceivedDateETA, od.IsShiped, od.CuttingTarget, od.FitsCuttingETARead, od.CuttingReceivedDate);
                od.FitsProdETABackColor = CommonHelper.GetTechnicalETABackColor(od.ProductionFileDateETA, od.IsShiped, od.ProductionFileTarget, od.FitsProdFileETARead, od.ProductionFileDate);
                //------------------------------------------Fits Module-------------------------------
                od.HandOverETABackColor = CommonHelper.GetTechnicalETABackColor(od.HandOverETADate, od.IsShiped, od.HandOverTargetDate, od.FitsProdFileETARead, od.HandOverActualDate);
                od.PatternReadyETABackColor = CommonHelper.GetTechnicalETABackColor(od.PatternReadyETADate, od.IsShiped, od.PatternReadyTargetDate, od.FitsProdFileETARead, od.PatternReadyActualDate);
                od.SampleSentETABackColor = CommonHelper.GetTechnicalETABackColor(od.SampleSentETADate, od.IsShiped, od.SampleSentTargetDate, od.FitsProdFileETARead, od.SampleSentActualDate);
                od.FitsCommentesETABackColor = CommonHelper.GetTechnicalETABackColor(od.FitsCommentesETADate, od.IsShiped, od.FitsCommentesTargetDate, od.FitsProdFileETARead, od.FitsCommentesActualDate);
                od.HandOverETAForeColor = CommonHelper.GetTechnicalETAForColor(od.HandOverETADate, od.IsShiped, od.HandOverTargetDate, od.FitsProdFileETARead, od.HandOverActualDate);
                od.PatternReadyETAForeColor = CommonHelper.GetTechnicalETAForColor(od.PatternReadyETADate, od.IsShiped, od.PatternReadyTargetDate, od.FitsProdFileETARead, od.PatternReadyActualDate);
                od.SampleSentETAForeColor = CommonHelper.GetTechnicalETAForColor(od.SampleSentETADate, od.IsShiped, od.SampleSentTargetDate, od.FitsProdFileETARead, od.SampleSentActualDate);
                od.FitsCommentesETAForeColor = CommonHelper.GetTechnicalETAForColor(od.FitsCommentesETADate, od.IsShiped, od.FitsCommentesTargetDate, od.FitsProdFileETARead, od.FitsCommentesActualDate);

                //------------------------------------------end----------------------------------------
                od.FitsProdETAForColor = CommonHelper.GetTechnicalETAForColor(od.ProductionFileDateETA, od.IsShiped, od.ProductionFileTarget, od.FitsProdFileETARead, od.ProductionFileDate);
                od.FitsHOPPMETABackColor = CommonHelper.GetTechnicalETABackColor(od.HOPPMETA, od.IsShiped, od.HOPPMTargetETA, od.FitsHOPPMETARead, od.HOPPMActionactualDate);
                od.FitsHOPPMETAForColor = CommonHelper.GetTechnicalETAForColor(od.HOPPMETA, od.IsShiped, od.HOPPMTargetETA, od.FitsHOPPMETARead, od.HOPPMActionactualDate);
                od.FitsTOPSentETABackColor = CommonHelper.GetTechnicalETABackColor(od.TOPETA, od.IsShiped, od.ParentOrder.InlinePPMOrderContract.TopSentTarget, od.FitsTOPSentETARead, od.ParentOrder.InlinePPMOrderContract.TopSentActual);
                od.FitsTOPSentETAForColor = CommonHelper.GetTechnicalETAForColor(od.TOPETA, od.IsShiped, od.ParentOrder.InlinePPMOrderContract.TopSentTarget, od.FitsTOPSentETARead, od.ParentOrder.InlinePPMOrderContract.TopSentActual);
                // edit by surendra
                od.TestReportsBackColor = CommonHelper.GetTechnicalETABackColor(od.TestReportsDateETA, od.IsShiped, od.TestReportTargetETA, od.FitsHOPPMETARead, od.TestReportsDateActual);
                od.TestReportsForColor = CommonHelper.GetTechnicalETAForColor(od.TestReportsDateETA, od.IsShiped, od.TestReportTargetETA, od.FitsHOPPMETARead, od.TestReportsDateActual);
                od.CDChartBackColor = CommonHelper.GetTechnicalETABackColor(od.CdchartDateETA, od.IsShiped, od.CdchartTargetDateETA, od.FitsHOPPMETARead, od.CdchartActualDateETA);
                od.CDChartForColor = CommonHelper.GetTechnicalETAForColor(od.CdchartDateETA, od.IsShiped, od.CdchartTargetDateETA, od.FitsHOPPMETARead, od.CdchartActualDateETA);
                od.StrikeOfBackColor1 = CommonHelper.StrikeOfBackColor(od.IntialAprd1, od.IsShiped);
                od.StrikeOfBackColor2 = CommonHelper.StrikeOfBackColor(od.IntialAprd2, od.IsShiped);
                od.StrikeOfBackColor3 = CommonHelper.StrikeOfBackColor(od.IntialAprd3, od.IsShiped);
                od.StrikeOfBackColor4 = CommonHelper.StrikeOfBackColor(od.IntialAprd4, od.IsShiped);
                od.StrikeOfForeColor1 = CommonHelper.StrikeOfForeColor(od.IntialAprd1, od.IsShiped);
                od.StrikeOfForeColor2 = CommonHelper.StrikeOfForeColor(od.IntialAprd2, od.IsShiped);
                od.StrikeOfForeColor3 = CommonHelper.StrikeOfForeColor(od.IntialAprd3, od.IsShiped);
                od.StrikeOfForeColor4 = CommonHelper.StrikeOfForeColor(od.IntialAprd4, od.IsShiped);

                //-----------------------------------Fits Module-------------------------------------
                od.HandOverETABackColor = CommonHelper.GetTechnicalETABackColor(od.HandOverETADate, od.IsShiped, od.HandOverTargetDate, od.FitsProdFileETARead, od.HandOverActualDate);
                od.PatternReadyETABackColor = CommonHelper.GetTechnicalETABackColor(od.PatternReadyETADate, od.IsShiped, od.PatternReadyTargetDate, od.FitsProdFileETARead, od.PatternReadyActualDate);
                od.SampleSentETABackColor = CommonHelper.GetTechnicalETABackColor(od.SampleSentETADate, od.IsShiped, od.SampleSentTargetDate, od.FitsProdFileETARead, od.SampleSentActualDate);
                od.FitsCommentesETABackColor = CommonHelper.GetTechnicalETABackColor(od.FitsCommentesETADate, od.IsShiped, od.FitsCommentesTargetDate, od.FitsProdFileETARead, od.FitsCommentesActualDate);
                od.HandOverETAForeColor = CommonHelper.GetTechnicalETAForColor(od.HandOverETADate, od.IsShiped, od.HandOverTargetDate, od.FitsProdFileETARead, od.HandOverActualDate);
                od.PatternReadyETAForeColor = CommonHelper.GetTechnicalETAForColor(od.PatternReadyETADate, od.IsShiped, od.PatternReadyTargetDate, od.FitsProdFileETARead, od.PatternReadyActualDate);
                od.SampleSentETAForeColor = CommonHelper.GetTechnicalETAForColor(od.SampleSentETADate, od.IsShiped, od.SampleSentTargetDate, od.FitsProdFileETARead, od.SampleSentActualDate);
                od.FitsCommentesETAForeColor = CommonHelper.GetTechnicalETAForColor(od.FitsCommentesETADate, od.IsShiped, od.FitsCommentesTargetDate, od.FitsProdFileETARead, od.FitsCommentesActualDate);
                //END
            }

            return objOrderDetail;
        }
        //end--
        //added by abhishek 13/1/2017
        public DataSet GetCutAvgDetails(int OrderDetailId, int styleID, string FabricName, string printdetails, int FabCount)
        {
            return OrderDataProviderInstance.GetCutAvgDetails(OrderDetailId, styleID, FabricName, printdetails, FabCount);
        }
        public DataSet Get_TechPacs(int CostingID)
        {
            return OrderDataProviderInstance.Get_TechPacs(CostingID);
        }
        public DataSet GetOrderContactDetailsByOrderID(int OrderID, int orderdetailid)
        {
            return OrderDataProviderInstance.GetOrderContactDetailsByOrderID(OrderID, orderdetailid);
        }
        //Add By Prabhaker 09-feb-18
        public DataSet GetQcUploadFile(int OrderDetailID, int OrderIDs)
        {
            return OrderDataProviderInstance.GetQcUploadFile(OrderDetailID, OrderIDs);
        }

        public int UpdateQcUploadFile(int OrderDetailID, string File1, string File10, string File50, string FileInline, string FileMidline, string FileFinal, int UserId, DateTime CQDInlieDate, DateTime CQDMidlineDate, DateTime CQDFinalDate, int IsCQDInlie, int IsCQDMidline, int IsCQDFinal, DateTime CQDFirstPcsDate, DateTime CQDFirst10Pcs, DateTime CQDFirst50PcsDate, int IsCQDFirstPcs, int IsCQDFirst10Pcs, int IsCQDFirst50Pcs)
        {
            return this.OrderDataProviderInstance.UpdateQcUploadFile(OrderDetailID, File1, File10, File50, FileInline, FileMidline, FileFinal, UserId, CQDInlieDate, CQDMidlineDate, CQDFinalDate, IsCQDInlie, IsCQDMidline, IsCQDFinal, CQDFirstPcsDate, CQDFirst10Pcs, CQDFirst50PcsDate, IsCQDFirstPcs, IsCQDFirst10Pcs, IsCQDFirst50Pcs);
        }
        //end of code
        public int UpdateFinalCuttingOB(int ClientID, int ClientDepartmentID, string StyleCode, int StyleId, int GarmentTypeID, int Operationcutting, int FactoryWorkSpace, int AttachmentID, string Flag, int FinalOBID, int ReUseStyleId, int IsReUse, int NewRef, int OprationID, int userid, float Sfactor, int StyleSequence)
        {
            return this.OrderDataProviderInstance.UpdateFinalCuttingOB(ClientID, ClientDepartmentID, StyleCode, StyleId, GarmentTypeID, Operationcutting, FactoryWorkSpace, AttachmentID, Flag, FinalOBID, ReUseStyleId, IsReUse, NewRef, OprationID, userid, Sfactor, StyleSequence);
        }
        public bool UpdateTestReportFile(int OrderDetailsID, string FileName, int TestReportCheckBox)
        {
            return OrderDataProviderInstance.UpdateTestReportFile(OrderDetailsID, FileName, TestReportCheckBox);
        }

        //Add by Prabhaker 19/Feb/18
        public bool UpdateCostingPairing(int Styleid, string PairedValue)
        {
            return OrderDataProviderInstance.UpdateCostingPairing(Styleid, PairedValue);
        }

        public DataTable GetCostingPairing(int Styleid)
        {
            return OrderDataProviderInstance.GetCostingPairing(Styleid);
        }
        //End Of Code

        public bool InsertCommentHistory_New(CommentHistory objCommentHistory)
        {
            return OrderDataProviderInstance.InsertCommentHistory_New( objCommentHistory);
        }
        public bool UpdateTechFile(string FileName, int styleid, int Position, int userid, string Flag)
        {
            return OrderDataProviderInstance.UpdateTechFile(FileName, styleid, Position, userid, Flag);
        }
        public bool deletetechPacsFile(int Styleid)
        {
            return OrderDataProviderInstance.deletetechPacsFile(Styleid);
        }
        public DataTable GetReAllocationStyleContactDetails(int StyleID, int type, int OrderDatailsID, double StatusTo)
        {
            return OrderDataProviderInstance.GetReAllocationStyleContactDetails(StyleID, type, OrderDatailsID, StatusTo);
        }
        public DataTable Get_VA_Details(int StyleID)
        {
            return OrderDataProviderInstance.Get_VA_Details(StyleID);
        }
        public int UpdateReAllocationStyleContactDetails(string Valueaddtion1, string Valueaddtion2, decimal Valueaddtion1_rate, decimal Valueaddtion2_rate, decimal stitchRate, string VA_supplier1, string VA_supplier2, string VA_supplier3, decimal IntialAgreementRate1, decimal IntialAgreementRate2, int OrderDetailsID, int IsCheckboxchecked, int StyleID)
        {
            return OrderDataProviderInstance.UpdateReAllocationStyleContactDetails(Valueaddtion1, Valueaddtion2, Valueaddtion1_rate, Valueaddtion2_rate, stitchRate, VA_supplier1, VA_supplier2, VA_supplier3, IntialAgreementRate1, IntialAgreementRate2, OrderDetailsID, IsCheckboxchecked, StyleID);
        }
        public int UpdateReAllocationStyle_stch(string VA_Stch_Supplier, decimal Rate, int RowID, int isFineLineCheck, int OrderDetailsID, int StyleID, decimal VA_Cut_Rate, int IsVaFinelCut, decimal VA_Finished_Rate, int IsVaFinelFinished)
        {
            return OrderDataProviderInstance.UpdateReAllocationStyle_stch(VA_Stch_Supplier, Rate, RowID, isFineLineCheck, OrderDetailsID, StyleID, VA_Cut_Rate, IsVaFinelCut, VA_Finished_Rate, IsVaFinelFinished);
        }
        public int UpdateReAllocationStyle_stch_Check(int RowID, int isFineLineCheck, int OrderDetailsID, int StyleID, int IsCheckboxchecked)
        {
            return OrderDataProviderInstance.UpdateReAllocationStyle_stch_Check(RowID, isFineLineCheck, OrderDetailsID, StyleID, IsCheckboxchecked);
        }
        //end
        //Add By Prabhaker 03/11/17
        public int InsertReAllocationStyle_PerDayQty(int styleid, int qtyallow, string StartDate, int PerdayProduction, int VA)
        {
            return OrderDataProviderInstance.InsertReAllocationStyle_PerDayQty(styleid, qtyallow, StartDate, PerdayProduction, VA);
        }
        public DataTable GetReAllocationStyle_PerDayQty(int StyleId)
        {
            return OrderDataProviderInstance.GetReAllocationStyle_PerDayQty(StyleId);
        }

        //End
        //Abhishek 5/10/2017
        public int DeleteAddFualtDetails_History(int LinePlanID, int FaultQnty, int OrderDetailID, string FaultName, string FlagIsDelete, string Startdate, int FaultID, int SlotWiseFualtID)
        {
            return OrderDataProviderInstance.DeleteAddFualtDetails_History(LinePlanID, FaultQnty, OrderDetailID, FaultName, FlagIsDelete, Startdate, FaultID, SlotWiseFualtID);
        }
        //adedd by abhishek on 17/10/2017
        public string ValidateBnkRefNo(string BnkRefNo, int CurrencyType)
        {
            return OrderDataProviderInstance.ValidateBnkRefNo(BnkRefNo, CurrencyType);

        }
        //abhishek 12/12/2017
        public DataSet GetPOUploadContract(int OrderID, string Flag)
        {
            return OrderDataProviderInstance.GetPOUploadContract(OrderID, Flag);
        }

        public int UpdateQcUploadFile(int OrderDetailID, System.Web.HttpPostedFile httpPostedFile, System.Web.HttpPostedFile httpPostedFile_2)
        {
            throw new NotImplementedException();
        }
        // Added By Ravi kumar on 20/3/18 for Plan date
        public bool Update_PlanDate(int OrderDetailId, int PlanType, DateTime PlanDate)
        {
            return OrderDataProviderInstance.Update_PlanDate(OrderDetailId, PlanType, PlanDate);
        }
        public List<OrderDetailSizes> GetOrderDetailSize_new(int OrderDetailID)
        {
            return OrderDataProviderInstance.GetOrderDetailSize(OrderDetailID);
        }
        public string ValidateSupplierName(string Flag, string SupplierName, string BasicType)
        {
            return OrderDataProviderInstance.ValidateSupplierName(Flag, SupplierName, BasicType);
        }
        //Added By abhishek on 28/8/2018
        public bool UpdateReallocationCommitedDate(int ReallocationID, string commitedDate)
        {
            return OrderDataProviderInstance.UpdateReallocationCommitedDate(ReallocationID, commitedDate);
        }

        public bool CheckQCUploadFile(int OrderDetailID, string File, int FileType)
        {
            return OrderDataProviderInstance.CheckQCUploadFile(OrderDetailID, File, FileType);
        }

        public int SubmitRescan_FaultDetails(int OrderDetailId, string date, int UnitId, int CycleNo, int FaultId, int FailQty)
        {
            return OrderDataProviderInstance.SubmitRescan_FaultDetails(OrderDetailId, date, UnitId, CycleNo, FaultId, FailQty);
        }
        public int Updatecontractholdstatus(int orderDetails_ID, int IsChecked, int UserID)
        {
            return OrderDataProviderInstance.Updatecontractholdstatus(orderDetails_ID, IsChecked, UserID);
        }
        public DataTable GetCuttingSheettabs(string SessionID, int OrderDetailID)
        {
            return OrderDataProviderInstance.GetCuttingSheettabs(SessionID, OrderDetailID);
        }
        //Added by abhishek 27/3/2019
        public string[] GetSupplierRate(string flag, string flagOtion, int FabricQualityID, int SupplierMasterID, string faricdetails, int Styleid)
        {
            return OrderDataProviderInstance.GetSupplierRate(flag, flagOtion, FabricQualityID, SupplierMasterID, faricdetails, Styleid);
        }
        public string[] GetSupplierRateVA(string flag, string flagOtion, int FabricQualityID, int SupplierMasterID, string faricdetails, int Styleid)
        {
            return OrderDataProviderInstance.GetSupplierRateVA(flag, flagOtion, FabricQualityID, SupplierMasterID, faricdetails, Styleid);
        }
        public string[] ValidateRececiedQty(string flag, string flagOtion, int FabricQualityID, int ReceviedQty, string Potype, string PoNumber, int MasterPoID, string fabricdetails)
        {
            return OrderDataProviderInstance.ValidateRececiedQty(flag, flagOtion, FabricQualityID, ReceviedQty, Potype, PoNumber, MasterPoID, fabricdetails);
        }
        public string[] GetSupplierIntialCode(string flag, int SupplierMasterID)
        {
            return OrderDataProviderInstance.GetSupplierIntialCode(flag, SupplierMasterID);
        }
        public int[] GetDeliveryType(string Flag, string FlagOption, int FabricQualityID, int SupplierMasterID, string FabricDetails, int styleida, bool isStyleSpecific)
        {
            return OrderDataProviderInstance.GetDeliveryType(Flag, FlagOption, FabricQualityID, SupplierMasterID, FabricDetails, styleida, isStyleSpecific);
        }
        public string[] ValidateMinReceiveQty(string flag, int SupplierMasterID)
        {
            return OrderDataProviderInstance.ValidateMinReceiveQty(flag, SupplierMasterID);
        }
        public string[] GetSupplierIntialCode2(string flag, int SupplierMasterID, int PoID)
        {
            return OrderDataProviderInstance.GetSupplierIntialCode2(flag, SupplierMasterID, PoID);
        }
        public string Cancel_Close_PO(int SupplierPO_Id, string field)
        {
            return OrderDataProviderInstance.Cancel_Close_PO(SupplierPO_Id, field);
        }

        public DataSet GetDestinationMap(int OrderId, string Type)
        {
            return OrderDataProviderInstance.GetDestinationMap(OrderId, Type);
        }

        public int UpdateDestinationMap(int OrderDetailId, int DestinationCode, int Mode, DateTime DC, DateTime ExFactory)
        {
            return OrderDataProviderInstance.UpdateDestinationMap(OrderDetailId, DestinationCode, Mode, DC, ExFactory);
        }

        public string GetVAPOIdZByRiskVASupplierId(int RiskVASupplierID, string PONumber)
        {
            return OrderDataProviderInstance.GetVAPOIdZByRiskVASupplierId(RiskVASupplierID, PONumber);
        }
        public string Get_Check_RegesteredSupplier(int RiskVASupplierID)
        {
            return OrderDataProviderInstance.Get_Check_RegesteredSupplier(RiskVASupplierID);
        }
        //public string USP_GetStitchOutHousePO(int OrderDetailID, int SeqNo)
        //{
        //    return OrderDataProviderInstance.USP_GetStitchOutHousePO(OrderDetailID, SeqNo);
        //}
        public DataSet USP_GetStitchOutHousePO(int OrderDetailID, int SeqNo)
        {
            return OrderDataProviderInstance.USP_GetStitchOutHousePO(OrderDetailID, SeqNo);
        }
        public string[] GetReceiveQtyBySendQty(string flag, string flagoption, int fabricqualityid, string fabricdetails, int currentstagenumber, int previousstagenumber, int pendingqty, bool IsStyleSpecific, int styleid)
        {
            return OrderDataProviderInstance.GetReceiveQtyBySendQty(flag, flagoption, fabricqualityid, fabricdetails, currentstagenumber, previousstagenumber, pendingqty, IsStyleSpecific, styleid);
        }
    }
}