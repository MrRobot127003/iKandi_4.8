using System;
using System.Collections.Generic;
using System.Text;
using iKandi.Common;
using System.Data;

namespace iKandi.BLL
{
    /// <summary>
    /// Production Planning, Shipment Planning, Delivery & Processing
    /// </summary>
    public class DeliveryController : BaseController
    {
        #region  Ctor(s)

        public DeliveryController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public List<ProductionPlanning> GetProductionPlanningOrders(int FactoryManagerID, int ClientId, string Search)
        {
            return this.DeliveryDataProviderInstance.GetProductionPlanningOrders(FactoryManagerID, ClientId, Search);
        }

        public List<ProductionPlanning> GetOrdersForShipmentPlanning(int ClientId, string Search,int intId)
        {
            return this.DeliveryDataProviderInstance.GetOrdersForShipmentPlanning(ClientId, Search, intId);
        }

        public List<ShipmentPlanning> GetShipmentPlannedOrders(string stringSearchText, string SearchAdvice, int iClientIdPlaning, int iClientIdAdvise)
        {
            return this.DeliveryDataProviderInstance.GetShipmentPlannedOrders(stringSearchText, SearchAdvice, iClientIdPlaning, iClientIdAdvise);
        }

        public ShipmentPlanning GetShipmentPlanning(int ShipmentID)
        {
            return this.DeliveryDataProviderInstance.GetShipmentPlanning(ShipmentID);
        }

        public List<ShipmentPlanning> GetOrdersForShipmentAdvise()
        {
            return null;
        }

        public List<DeliveryBooking> GetBookingOrders(int ClientId, string Search)
        {
            return this.DeliveryDataProviderInstance.GetBookingOrders(ClientId, Search);
        }

        public List<DeliveryBooking> GetOrdersForProcessing(int PartnerID, int ClientID, string Search)
        {
            return this.DeliveryDataProviderInstance.GetOrdersForProcessing(PartnerID, ClientID, Search);
        }

        public List<DeliveryBooking> GetOrdersForForwarding(int PartnerID, int ClientID, string Search)
        {
            return this.DeliveryDataProviderInstance.GetOrdersForForwarding(PartnerID, ClientID, Search);
        }

        public void UpdateProductionPlanningOrder(ProductionPlanning pp)
        {
            this.DeliveryDataProviderInstance.UpdateProductionPlanningOrder(pp);

            #region Gajendra Commented 18-04-2016
            //if (pp.PlannedEx != DateTime.MinValue && pp.PlannedEx != null)
            //{
            //    try
            //    {
            //        //Gajendra Workflow
            //        Order order = this.OrderDataProviderInstance.GetOrderByOrderDetailId(pp.OrderDetailID);
            //        OrderDetail orderDetail = order.OrderBreakdown.Find(delegate(OrderDetail od) { return od.OrderDetailID == pp.OrderDetailID; });
            //        WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.EXFACTORY_PLANNED, LoggedInUser.UserData.UserID);
            //        //if (pp.IsPartShipment)
            //        //{
            //        //    Order order = this.OrderDataProviderInstance.GetOrderByOrderDetailId(pp.OrderDetailID);
            //        //    OrderDetail orderDetail = order.OrderBreakdown.Find(delegate(OrderDetail od) { return od.OrderDetailID == pp.OrderDetailID; });
            //        //    WorkflowInstance chkInstance = this.WorkflowControllerInstance.GetInstance(pp.ProductionPlanningID);

            //        //    if (chkInstance.WorkflowInstanceID <= 0)
            //        //    {
            //        //        WorkflowInstance newInstance = new WorkflowInstance();
            //        //        newInstance.CurrentStatus = new WorkflowInstanceDetail();
            //        //        newInstance.Style = new Style();
            //        //        newInstance.Order = new Order();
            //        //        newInstance.ProductionPlanningID = pp.ProductionPlanningID;
            //        //        newInstance.CurrentStatus.StatusModeID = (int)StatusMode.EXFACTORYPLANNED;
            //        //        newInstance.Style.StyleID = -1;
            //        //        newInstance.Order.OrderID = orderDetail.OrderID;
            //        //        newInstance.OrderDetailID = orderDetail.OrderDetailID;
            //        //        newInstance = this.WorkflowControllerInstance.InsertWorkflowInstance(newInstance);

            //        //        this.WorkflowControllerInstance.UpdateWorkflowInstanceDetailByOrderDetailID(orderDetail.OrderDetailID);

            //        //        WorkflowInstanceDetail task = this.WorkflowControllerInstance.CreateTask(StatusMode.EXFACTORYPLANNED, newInstance.WorkflowInstanceID, DateTime.Today);
            //        //        this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);

            //        //        this.WorkflowControllerInstance.CreateTask(StatusMode.APPROVEDTOEXFACTORY, newInstance.WorkflowInstanceID, DateTime.Today);
            //        //    }
            //        //}
            //        //else
            //        //{
            //        //    // Update workflow                      
            //        //    WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(-1, -1, pp.OrderDetailID);
            //        //    List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);
            //        //    foreach (WorkflowInstanceDetail task in tasks)
            //        //    {
            //        //        if (task.StatusModeID == (int)StatusMode.EXFACTORYPLANNED && task.ApplicationModule.ApplicationModuleID == (int)AppModule.PRODUCTION_PLANNING_FILE)
            //        //        {
            //        //            this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);
            //        //            //if (!pp.IsPartShipment)
            //        //            this.WorkflowControllerInstance.CreateTask(StatusMode.APPROVEDTOEXFACTORY, instance.WorkflowInstanceID, pp.PlannedEx);
            //        //            //else
            //        //            //    this.WorkflowControllerInstance.CreateTask(StatusMode.PARTEXFACTORIED, instance.WorkflowInstanceID, pp.PlannedEx);
            //        //        }
            //        //    }
            //        //}
            //    }
            //    catch (Exception ex)
            //    {
            //        //this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            //    }
            //}
            #endregion
        }

        public void UpdateProductionPlannedOrder(ProductionPlanning pp)
        {
            this.DeliveryDataProviderInstance.UpdateProductionPlannedOrder(pp);
        }

        public void UpdateShipmentPlanningOrder(ProductionPlanning pp)
        {
            this.DeliveryDataProviderInstance.UpdateShipmentPlanningOrder(pp);
        }

        public void UpdateBookingOrder(DeliveryBooking db)
        {
            this.DeliveryDataProviderInstance.UpdateBookingOrder(db);
        }

        public void UpdateProcessingOrder(DeliveryBooking db)
        {


            this.DeliveryDataProviderInstance.UpdateProcessingOrder(db);

            try
            {
                if (db.DeliveredDate != DateTime.MinValue)
                {
                    iKandi.Common.Order order = this.OrderDataProviderInstance.GetOrderByOrderDetailId(db.OrderDetailID);
                    OrderDetail orderDetail = order.OrderBreakdown.Find(delegate(OrderDetail od) { return od.OrderDetailID == db.OrderDetailID; });
                    WorkflowInstance instance;

                    // Update workflow
                    if (db.IsPartShipment)
                        instance = this.WorkflowControllerInstance.GetInstance(db.ProductionPlanningID);
                    else
                        instance = this.WorkflowControllerInstance.GetInstance(-1, -1, db.OrderDetailID);

                    List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetCurrentPendingTasks(instance.WorkflowInstanceID);

                    foreach (WorkflowInstanceDetail task in tasks)
                    {
                        if (task.StatusModeID == (int)TaskMode.Consolidated )
                        {
                            this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);
                            WorkflowInstanceDetail newtask = this.WorkflowControllerInstance.CreateTask(TaskMode.DELIVERED, instance.WorkflowInstanceID, orderDetail.DC);
                            this.WorkflowControllerInstance.CompleteTask(newtask, this.LoggedInUser.UserData.UserID);
                            this.WorkflowControllerInstance.CreateTask(TaskMode.INVOICED, instance.WorkflowInstanceID, orderDetail.DC.AddDays(3));
                        }
                    }
                    if (db.IsPartShipment)
                    {
                        int isOrderDelivered = this.DeliveryDataProviderInstance.GetIsOrderDelivered(db.OrderDetailID);
                        if (isOrderDelivered == 1)
                        {
                            WorkflowInstance instanceNew = this.WorkflowControllerInstance.GetInstance(-1, -1, db.OrderDetailID);
                            List<WorkflowInstanceDetail> tasksNew = this.WorkflowControllerInstance.GetCurrentPendingTasks(instanceNew.WorkflowInstanceID);
                            foreach (WorkflowInstanceDetail task in tasksNew)
                            {
                                //this.WorkflowControllerInstance.ChangeWorkflowTaskMode(task.WorkflowInstanceDetailID, (int)StatusMode.DELIVERED);
                                this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);
                                this.WorkflowControllerInstance.CreateTask(TaskMode.INVOICED, instanceNew.WorkflowInstanceID, DateTime.Today.AddDays(3));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }

        public void UpdateForwarderOrder(DeliveryBooking db)
        {



            this.DeliveryDataProviderInstance.UpdateForwarderOrder(db);

            try
            {
                if (db.DeliveredDate != DateTime.MinValue && iKandi.BLL.CommonHelper.IsFlatDelivery(db.Mode))
                {
                    iKandi.Common.Order order = this.OrderDataProviderInstance.GetOrderByOrderDetailId(db.OrderDetailID);
                    OrderDetail orderDetail = order.OrderBreakdown.Find(delegate(OrderDetail od) { return od.OrderDetailID == db.OrderDetailID; });
                    WorkflowInstance instance;
                    // Update workflow
                    if (db.IsPartShipment)
                        instance = this.WorkflowControllerInstance.GetInstance(db.ProductionPlanningID);
                    else
                        instance = this.WorkflowControllerInstance.GetInstance(-1, -1, db.OrderDetailID);

                    List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetCurrentPendingTasks(instance.WorkflowInstanceID);

                    foreach (WorkflowInstanceDetail task in tasks)
                    {
                        if (task.StatusModeID == (int)TaskMode.DELIVERED)
                        {
                            this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);

                            //if (db.IsPartShipment)
                            //{
                            //    //WorkflowInstanceDetail newtask = this.WorkflowControllerInstance.CreateTask(StatusMode.DELIVERED, instance.WorkflowInstanceID, orderDetail.DC);
                            //    //this.WorkflowControllerInstance.CompleteTask(newtask, this.LoggedInUser.UserData.UserID);
                            //}
                            //else

                            this.WorkflowControllerInstance.CreateTask(TaskMode.INVOICED, instance.WorkflowInstanceID, orderDetail.DC.AddDays(3));
                        }
                    }

                    if (db.IsPartShipment)
                    {
                        int isOrderDelivered = this.DeliveryDataProviderInstance.GetIsOrderDelivered(db.OrderDetailID);
                        if (isOrderDelivered == 1)
                        {
                            WorkflowInstance instanceNew = this.WorkflowControllerInstance.GetInstance(-1, -1, db.OrderDetailID);
                            List<WorkflowInstanceDetail> tasksNew = this.WorkflowControllerInstance.GetCurrentPendingTasks(instanceNew.WorkflowInstanceID);
                            foreach (WorkflowInstanceDetail task in tasksNew)
                            {
                                // this.WorkflowControllerInstance.ChangeWorkflowTaskMode(task.WorkflowInstanceDetailID, (int)StatusMode.DELIVERED);
                                this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);
                                this.WorkflowControllerInstance.CreateTask(TaskMode.INVOICED, instanceNew.WorkflowInstanceID, DateTime.Today.AddDays(3));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                //this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }
        }


        public void SaveShipmentPlanning(ShipmentPlanning SP)
        {

            if ((SP.Partner == null || SP.Partner2 == null || SP.IndiaPartner == null || SP.Partner.PartnerID <= 0) && SP.ShipmentPlanningOrders.Count > 0 && SP.ShipmentPlanningOrders[0].PackingList != null)
            {
                DataSet dsPartner = this.PartnerDataProviderInstance.GetPatnerIDByMode(SP.ShipmentPlanningOrders[0].ModeId, SP.ShipmentPlanningOrders[0].ClientId);

                SP.Partner = new Partner();
                SP.Partner.PartnerID = (dsPartner.Tables[0].Rows[0]["partnerID1"] == DBNull.Value) ? -1 : Convert.ToInt32(dsPartner.Tables[0].Rows[0]["partnerID1"]);

                SP.Partner2 = new Partner();
                SP.Partner2.PartnerID = (dsPartner.Tables[1].Rows[0]["partnerID2"] == DBNull.Value) ? -1 : Convert.ToInt32(dsPartner.Tables[1].Rows[0]["partnerID2"]);

                SP.IndiaPartner = new Partner();
                SP.IndiaPartner.PartnerID = (dsPartner.Tables[2].Rows[0]["partnerID3"] == DBNull.Value) ? -1 : Convert.ToInt32(dsPartner.Tables[2].Rows[0]["partnerID3"]);
            }

            this.DeliveryDataProviderInstance.SaveShipmentPlanning(SP);
            // System.Diagnostics.Debugger.Break();
            if (SP.ShipmentSentForwarder == null || SP.ShipmentSentForwarder == DateTime.MinValue)
                return;
            try
            {
                List<int> packingIds = new List<int>();

                foreach (ShipmentPlanningOrder shipmentPlaningOrder in SP.ShipmentPlanningOrders)
                {
                    if (shipmentPlaningOrder.IsDelete)
                        continue;
                    if (shipmentPlaningOrder.PackingList.PackingID > -1 && !packingIds.Exists(delegate(int pID) { return pID == shipmentPlaningOrder.PackingList.PackingID; }))
                        packingIds.Add(shipmentPlaningOrder.PackingList.PackingID);

                }

                foreach (int packingID in packingIds)
                {
                    DataTable dt = this.DeliveryDataProviderInstance.GetPackingOrders(packingID);

                    foreach (DataRow row in dt.Rows)
                    {
                        ShipmentPlanningOrder order = SP.ShipmentPlanningOrders.Find(delegate(ShipmentPlanningOrder spOrder)
                        {
                            return spOrder.PackingList.PackingID == packingID;
                        });

                        int productionPlanningID = Convert.ToInt32(row["ProductionPlanningID"]);
                        int orderDetailID = Convert.ToInt32(row["OrderDetailID"]);
                        WorkflowInstance instance;

                        if (productionPlanningID > 0 && order.IsPartShipment)
                            instance = this.WorkflowControllerInstance.GetInstance(productionPlanningID);
                        else
                            instance = this.WorkflowControllerInstance.GetInstance(-1, -1, orderDetailID);

                        List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                        iKandi.Common.Order objOrder = this.OrderDataProviderInstance.GetOrderByOrderDetailId(orderDetailID);
                        OrderDetail orderDetail = objOrder.OrderBreakdown.Find(delegate(OrderDetail od) { return od.OrderDetailID == orderDetailID; });


                        foreach (WorkflowInstanceDetail task in tasks)
                        {
                            if (task.StatusModeID == (int)TaskMode.EXFACTORIED || task.StatusModeID == (int)TaskMode.PART_EX_FACTORIED) 
                            {
                                // Update status mode
                                //if (order.IsPartShipment)
                                //    this.WorkflowControllerInstance.ChangeWorkflowTaskMode(task.WorkflowInstanceDetailID, (int)StatusMode.PARTEXFACTORIED);
                                this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);

                                this.WorkflowControllerInstance.CreateTask(TaskMode.UNDER_CLEARENCE, instance.WorkflowInstanceID, (!iKandi.BLL.CommonHelper.IsFlatDelivery(orderDetail.Mode)) ? orderDetail.DC.AddDays(-8) : orderDetail.DC.AddDays(-4));
                            }
                        }
                        instance = this.WorkflowControllerInstance.GetInstance(-1, -1, orderDetailID);
                        List<WorkflowInstanceDetail> tasksNew = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);
                        int isOrderExfactoried = this.DeliveryDataProviderInstance.GetIsOrderExfactoried(orderDetailID);

                        if (isOrderExfactoried == 1)
                        {
                            // Update workflow
                            foreach (WorkflowInstanceDetail task in tasksNew)
                            {
                                if ((task.StatusModeID == (int)TaskMode.PART_EX_FACTORIED))
                                {
                                    this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);
                                    WorkflowInstanceDetail newtask = this.WorkflowControllerInstance.CreateTask(TaskMode.EXFACTORIED, instance.WorkflowInstanceID, orderDetail.ExFactory);
                                    this.WorkflowControllerInstance.CompleteTask(newtask, this.LoggedInUser.UserData.UserID);
                                    this.WorkflowControllerInstance.CreateTask(TaskMode.DELIVERED, instance.WorkflowInstanceID, orderDetail.ExFactory);
                                }
                                else if ((task.StatusModeID == (int)TaskMode.EXFACTORIED))
                                {
                                    this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);
                                    this.WorkflowControllerInstance.CreateTask(TaskMode.DELIVERED, instance.WorkflowInstanceID, orderDetail.ExFactory);
                                }
                            }
                        }
                        else
                        {
                            // Update workflow
                            foreach (WorkflowInstanceDetail task in tasksNew)
                            {
                                if (task.StatusModeID == (int)TaskMode.PART_EX_FACTORIED )
                                {
                                    this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);

                                    this.WorkflowControllerInstance.CreateTask(TaskMode.EXFACTORIED, instance.WorkflowInstanceID, orderDetail.ExFactory);
                                }
                            }
                         // instance = this.WorkflowControllerInstance.Create_CloseWorkflowPostOrder(orderDetail.OrderID, orderDetail.OrderDetailID, TaskMode.EXFACTORIED, this.LoggedInUser.UserData.UserID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
               // this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
            }

        }

        public void SaveShipmentPlanningAdvise(ShipmentPlanning SP)
        {
            //System.Diagnostics.Debugger.Break();
            this.DeliveryDataProviderInstance.SaveShipmentPlanningAdvise(SP);

            try
            {
                if (!string.IsNullOrEmpty(SP.BLAWBNumber) && !string.IsNullOrEmpty(SP.FlightSailingDetails)
                    && SP.FlightDate != DateTime.MinValue && SP.ExpectedDispatchDate != DateTime.MinValue)
                {
                    DataTable dt = this.DeliveryDataProviderInstance.GetShipmentPlanningOrders(SP.ShipmentID);

                    foreach (DataRow row in dt.Rows)
                    {
                        int orderDetailID = Convert.ToInt32(row["OrderDetailID"]);
                        int productionPlanningID = Convert.ToInt32(row["ProductionPlanningID"]);
                        WorkflowInstance instance;

                        // Update workflow
                        if (Convert.ToInt32(row["IsPartShipment"]) == 1)
                            instance = this.WorkflowControllerInstance.GetInstance(productionPlanningID);
                        else
                            instance = this.WorkflowControllerInstance.GetInstance(-1, -1, orderDetailID);

                        List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetCurrentPendingTasks(instance.WorkflowInstanceID);
                        string modeName = iKandi.BLL.CommonHelper.GetOrderDeliveryMode(Convert.ToInt32(row["Mode"]));

                        foreach (WorkflowInstanceDetail task in tasks)
                        {
                            if (task.StatusModeID == (int)TaskMode.UNDER_CLEARENCE)
                            {
                                if (modeName.ToUpper().IndexOf("D") > -1)
                                {
                                    int isOrderDelivered = this.DeliveryDataProviderInstance.GetIsOrderDelivered(orderDetailID);
                                    this.WorkflowControllerInstance.ChangeWorkflowTaskMode(task.WorkflowInstanceDetailID, (int)TaskMode.DELIVERED);
                                    this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);
                                    this.WorkflowControllerInstance.CreateTask(TaskMode.INVOICED, instance.WorkflowInstanceID, DateTime.Today.AddDays(7));
                                }
                            }
                        }
                        if (modeName.ToUpper().IndexOf("D") > -1 && Convert.ToInt32(row["IsPartShipment"]) == 1)
                        {
                            int isOrderDelivered = this.DeliveryDataProviderInstance.GetIsOrderDelivered(orderDetailID);
                            if (isOrderDelivered == 1)
                            {
                                WorkflowInstance instanceNew = this.WorkflowControllerInstance.GetInstance(-1, -1, orderDetailID);
                                List<WorkflowInstanceDetail> tasksNew = this.WorkflowControllerInstance.GetCurrentPendingTasks(instanceNew.WorkflowInstanceID);
                                foreach (WorkflowInstanceDetail task in tasksNew)
                                {
                                    this.WorkflowControllerInstance.ChangeWorkflowTaskMode(task.WorkflowInstanceDetailID, (int)TaskMode.DELIVERED);
                                    this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);
                                    this.WorkflowControllerInstance.CreateTask(TaskMode.INVOICED, instance.WorkflowInstanceID, DateTime.Today.AddDays(7));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
        }

        public void AddOrderForBooking(DeliveryBooking DB)
        {
            this.DeliveryDataProviderInstance.AddOrderForBooking(DB);
        }

        public DataTable GetPackingOrders(int PackingID)
        {
            return this.DeliveryDataProviderInstance.GetPackingOrders(PackingID);
        }

        public int SavePartShipmentOrder(PartShipmentOrder Order)
        {
            return this.DeliveryDataProviderInstance.SavePartShipmentOrder(Order);
        }

        public DataSet GetOrderDetailByShipmentId(int shipmentId)
        {
            return this.DeliveryDataProviderInstance.GetOrderDetailByShipmentId(shipmentId);
        }

        public void RemoveOrderFromPlannedOrders(int productionPlanningId)
        {
            this.DeliveryDataProviderInstance.RemoveOrderFromPlannedOrders(productionPlanningId);
        }

        public void RemoveOrderFromBookingView(int bookingId)
        {
            this.DeliveryDataProviderInstance.RemoveOrderFromBookingView(bookingId);
        }

        public void UpdateShipmentEmailInfo(int ShipmentID, int ShipmentEmailType)
        {
            this.DeliveryDataProviderInstance.UpdateShipmentEmailInfo(ShipmentID, ShipmentEmailType);
        }

        public void UpdateBookingEmailInfo(int BookingID, bool IsEmailSent)
        {
            this.DeliveryDataProviderInstance.UpdateBookingEmailInfo(BookingID, IsEmailSent);
        }

        #region Packing Methods

        public Packing GetPackingCollection(int orderId, int packingId, int productionUnitManagerId)
        {
            return this.DeliveryDataProviderInstance.GetPackingCollection(orderId, packingId, productionUnitManagerId);
        }

        public bool SavePacking(Packing objPacking)
        {
            bool success = this.DeliveryDataProviderInstance.SavePacking(objPacking);


            return success;
        }

        public string GeneratePackingListExcel(int OrderId, int PackingId, string FileName)
        {          
            iKandi.Common.Packing objPacking = this.InvoiceDataProviderInstance.GetPackingCollection(OrderId, PackingId, -1);
                  
            string ContentStyle = @"<style style='text/css'>  
           <style>
            *
            {
                font-family: Arial, Helvetica, sans-serif;
                font-size: 12px;
                word-wrap: break-word;
                wrap : wrap;
            }
            span
            {
                font-family: Arial, Helvetica, sans-serif;
                font-size: 12px;
                align : right;
            }
            h1
            {
                font-size: 24px;
                color: #333333;
            }
            table,td
            {
                border-collapse: collapse;
                 word-wrap: break-word;
                wrap : wrap;
            }
            table
	        {
                mso-displayed-decimal-separator:""\."";
	            mso-displayed-thousand-separator:""\,"";}
            @page
	        {
            margin:1.0in .75in 1.0in .75in;
	        mso-header-margin:.5in;
	        mso-footer-margin:.5in;
            }
            tr
	        {mso-height-source:auto;}
            col
	        {mso-width-source:auto;}

            .font_A{font-family: Arial !important;}
            .font_V{font-family: Verdana  !important;}
            .font_size_16 {font-size:6.4pt  !important;}
            .font_size_20 {font-size:8pt  !important;}
            .font_size_22 {font-size:8.8pt  !important;}
            .font_size_23 {font-size:9.2pt  !important;}
            .font_size_24 {font-size:9.6pt  !important;}
            .font_size_25 {font-size:10pt  !important;}
            .font_size_26 {font-size:10.4pt !important;}
            .font_size_28 {font-size:11.2pt  !important;}
            .font_size_30 {font-size:12pt  !important;}
            .font_size_36 {font-size:14.4pt  !important;}
           
          </style>";

            int pageNo = 0;
            int pageHeight = 0;

            string expoter = string.Empty;
            string invoiceNumber = string.Empty;
            string invoiceDate = string.Empty;
            string buyerOrderNumber = string.Empty;
            string buyerOrderDate = string.Empty;
            string serialNumber = string.Empty;
            string consignee = objPacking.Consignee;
            string buyerOtherThanConsinee = string.Empty;
            string countryOfOrigin = string.Empty;
            string countryOfFinalDistination = string.Empty;
            string preCarrageBy = string.Empty;
            string placeOfReceivedByPreCarriage = string.Empty;
            string fligthNumber = string.Empty;
            string portOfLoading = string.Empty;
            string portOfDischarge = string.Empty;
            string finalDestination = string.Empty;
            string termsOfDeliveryAndPayment = string.Empty;
            string packingMode = string.Empty;
            string marksAndCounterNumber = string.Empty;
            string descOfGoods = string.Empty;
            string remarks = string.Empty;
            string totalGrossWeight = string.Empty;
            string totalNetWeight = string.Empty;

            string size0 = string.Empty;
            string size1 = string.Empty;
            string size2 = string.Empty;
            string size3 = string.Empty;
            string size4 = string.Empty;
            string size5 = string.Empty;
            string size6 = string.Empty;
            string size7 = string.Empty;
            string size8 = string.Empty;
            string size9 = string.Empty;
            string size10 = string.Empty;
            string size11 = string.Empty;

            string contractNumber = string.Empty;
            string lineNumber = string.Empty;
            string styleNumber = string.Empty;
            string color = string.Empty;
            string item = String.Empty;
            string fabric = string.Empty;
            string totalSingles = string.Empty;
            string totalRatioPack = string.Empty;
            string totalTotal = string.Empty;
            string singles0 = string.Empty;
            string singles1 = string.Empty;
            string singles2 = string.Empty;
            string singles3 = string.Empty;
            string singles4 = string.Empty;
            string singles5 = string.Empty;
            string singles6 = string.Empty;
            string singles7 = string.Empty;
            string singles8 = string.Empty;
            string singles9 = string.Empty;
            string singles10 = string.Empty;
            string singles11 = string.Empty;

            string ratio0 = string.Empty;
            string ratio1 = string.Empty;
            string ratio2 = string.Empty;
            string ratio3 = string.Empty;
            string ratio4 = string.Empty;
            string ratio5 = string.Empty;
            string ratio6 = string.Empty;
            string ratio7 = string.Empty;
            string ratio8 = string.Empty;
            string ratio9 = string.Empty;
            string ratio10 = string.Empty;
            string ratio11 = string.Empty;

            string sizeQuantity0 = string.Empty;
            string sizeQuantity1 = string.Empty;
            string sizeQuantity2 = string.Empty;
            string sizeQuantity3 = string.Empty;
            string sizeQuantity4 = string.Empty;
            string sizeQuantity5 = string.Empty;
            string sizeQuantity6 = string.Empty;
            string sizeQuantity7 = string.Empty;
            string sizeQuantity8 = string.Empty;
            string sizeQuantity9 = string.Empty;
            string sizeQuantity10 = string.Empty;
            string sizeQuantity11 = string.Empty;

            string ratioPack = string.Empty;

            int orderDetailID = 0;
            int productionPlanningId = 0;
            //int packingID = 0;
            int verticalSizeQuantityTotal = 0;

            DataTable dt = new DataTable();

            DataTable dtOrderdetail = new DataTable();
            dtOrderdetail.Columns.Add("ProductionPlanningID");
            dtOrderdetail.Columns.Add("OrderDetailID");
            dtOrderdetail.Columns.Add("TotalSingles0");
            dtOrderdetail.Columns.Add("TotalSingles1");
            dtOrderdetail.Columns.Add("TotalSingles2");
            dtOrderdetail.Columns.Add("TotalSingles3");
            dtOrderdetail.Columns.Add("TotalSingles4");
            dtOrderdetail.Columns.Add("TotalSingles5");
            dtOrderdetail.Columns.Add("TotalSingles6");
            dtOrderdetail.Columns.Add("TotalSingles7");
            dtOrderdetail.Columns.Add("TotalSingles8");
            dtOrderdetail.Columns.Add("TotalSingles9");
            dtOrderdetail.Columns.Add("TotalSingles10");
            dtOrderdetail.Columns.Add("TotalSingles11");
            dtOrderdetail.Columns.Add("TotalRatioPackQuanity");
            dtOrderdetail.Columns.Add("PkgNOFrom");
            dtOrderdetail.Columns.Add("PkgNOTO");

            StringBuilder htmlString = new StringBuilder();
            htmlString.Append(string.Empty);
            StringBuilder htmlTableStart = new StringBuilder();
            htmlTableStart.Append(string.Empty);
            StringBuilder htmlHeader1String = new StringBuilder(); // Exporter SECTION
            htmlHeader1String.Append(string.Empty);
            StringBuilder htmlHeader2String = new StringBuilder(); // Consignee SECTION
            htmlHeader2String.Append(string.Empty);
            StringBuilder htmlHeader3String = new StringBuilder(); // MACKER SECTION
            htmlHeader3String.Append(string.Empty);
            StringBuilder htmlSizesHeader = new StringBuilder();
            htmlSizesHeader.Append(string.Empty);
            StringBuilder htmlSizesBody = new StringBuilder();
            htmlSizesBody.Append(string.Empty);
            StringBuilder htmlSizesFooter = new StringBuilder(); // Sizes total
            htmlSizesFooter.Append(string.Empty);
            StringBuilder htmlSummaryHeader = new StringBuilder();
            htmlSummaryHeader.Append(string.Empty);
            StringBuilder htmlSummaryBody = new StringBuilder();
            htmlSummaryBody.Append(string.Empty);
            StringBuilder htmlSummaryFooter = new StringBuilder(); // Summary total
            htmlSummaryFooter.Append(string.Empty);
            StringBuilder htmlSignature = new StringBuilder();
            htmlSignature.Append(string.Empty);
            StringBuilder htmlDimension = new StringBuilder();
            htmlDimension.Append(string.Empty);
            StringBuilder htmTableEnd = new StringBuilder();
            htmTableEnd.Append("</table><br/><br/>");
            StringBuilder htmlHeader = new StringBuilder();
            htmlHeader.Append(string.Empty);

            if (null != objPacking && PackingId > 0)
            {
                expoter = objPacking.Exporter;
                invoiceNumber = objPacking.InvoiceNumber.ToUpper();
                invoiceDate = objPacking.InvoiceDate.ToString("dd MMM yy (ddd)");
                buyerOrderNumber = objPacking.BuyerOrderNumber.ToUpper();
                buyerOrderDate = objPacking.BuyerOrderDate.ToString("dd MMM yy (ddd)");
                serialNumber = objPacking.SerialNumber.ToUpper();
                consignee = objPacking.Consignee;
                buyerOtherThanConsinee = objPacking.BuyerOtherThanConsignee.ToUpper();
                countryOfOrigin = objPacking.CountryOfOriginOfGoods.ToUpper();
                countryOfFinalDistination = objPacking.CountryOfFinalDestination.ToUpper();
                preCarrageBy = objPacking.PreCarriageBy.ToUpper();
                placeOfReceivedByPreCarriage = objPacking.PlaceOfReceiptByPreCarrier.ToUpper();
                fligthNumber = objPacking.FlightNumber.ToUpper();
                portOfLoading = objPacking.PortOfLoading.ToUpper();
                portOfDischarge = objPacking.PortOfDischarge.ToUpper();
                finalDestination = objPacking.FlightNumber.ToUpper();
                termsOfDeliveryAndPayment = objPacking.TermsOfDeliveryAndPayment.ToUpper();
                marksAndCounterNumber = objPacking.MarksAndContainerNumber.ToUpper();
                descOfGoods = objPacking.DescriptionOfGoods.ToUpper();
                remarks = objPacking.Remarks == null ? "" : objPacking.Remarks.ToUpper();
                totalGrossWeight = objPacking.TotalGrossWeight.ToString();
                totalNetWeight = objPacking.TotalNetWeight.ToString();
            }
            else
            {
                expoter = iKandi.BLL.BLLCache.GetConfigurationKeyValue(Constants.BIPL_ADDRESS);
                invoiceDate = DateTime.Today.ToString("dd MMM yy (ddd)");
                buyerOrderDate = DateTime.Today.ToString();
                consignee = BLLCache.GetConfigurationKeyValue(Constants.IKANDI_ADDRESS);
                countryOfOrigin = "INDIA";
                countryOfFinalDistination = "UNITED KINGDOM";
                placeOfReceivedByPreCarriage = "NEW DELHI";
                portOfLoading = "MUMBAI";
                portOfDischarge = "LONDON";
                finalDestination = "UNITED KINGDOM";
            }

            if (null != objPacking && (PackingId > 0 || OrderId > 0))
            {
                if (objPacking.Distributions != null && objPacking.Distributions.Count > 0)
                {
                    string mode = iKandi.BLL.CommonHelper.GetOrderDeliveryMode(objPacking.Distributions[0].Mode);

                    if (mode.ToLower().EndsWith("/f"))
                        packingMode = "Flat";
                    else if (mode.ToLower().EndsWith("/h"))
                        packingMode = "Hanging";

                    if (mode.ToLower().Contains("a/"))
                    {
                        portOfLoading = "NEW DELHI";
                        portOfDischarge = "LONDON";
                    }
                    else if (mode.ToLower().Contains("s/"))
                    {
                        portOfLoading = "MUMBAI";
                        portOfDischarge = "FELIXTOWE";
                    }

                    if (mode.ToLower().Contains("fob"))
                    {
                        consignee = objPacking.Consignee;
                    }

                    dt = GetDataTableForPacking(objPacking.Distributions, objPacking, PackingId);
                }
            }

            string PageContent = "Continuation Sheet" + pageNo.ToString();

            if (pageNo == 0)
            {
                PageContent = string.Empty;
            }

            #region Table Start            
            htmlTableStart.Append(ContentStyle + @"<table width=""950px"" border=""0"" cellspacing=""0"" cellpadding=""4"" style=""border: 1px solid #333333;"">
                                         <tr> 
                                               <td colspan=""21""  style=""border-bottom:1px solid #333333; font-size : 14.4pt; font-family : Verdana"" class='font_size_36 font_A' height=""100"" align=""Center""><strong>PACKING LIST</strong/></td>
                                          </tr>");
            htmlString.Append(htmlTableStart.ToString());
            #endregion

            #region Header Part 1

            htmlHeader1String.AppendFormat(@"
            <tr>
                <td height=""22"" colspan=""10""  style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Exporter</strong></td>
                <td colspan=""11"" style=""font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Invoice No. &amp; Date</strong></td>
            </tr>
             <tr>
                 <td colspan=""10""  rowspan=""5"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 10.4pt; font-family : Verdana"" class='font_size_26 font_V'><b>{0}</b></td>
                 <td height=""22"" colspan=""11"" style=""border-bottom:1px solid #333333; font-size : 10.4pt; font-family : Verdana"" class='font_size_26 font_V'><b>{1} &nbsp; &nbsp; {2}</b></td>
            </tr>
            <tr>
                <td height=""22"" colspan=""11"" style=""font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Buyer's Order No. &amp; date</strong></td>
            </tr>
            <tr>
                <td height=""22"" colspan=""11"" style=""border-bottom:1px solid #333333; font-size : 10.4pt; font-family : Verdana"" class='font_size_26 font_V'><b>{3} &nbsp; {4} &nbsp; SERIAL NUMBER &nbsp; {5}</b></td>
            </tr>
             <tr>
                 <td height=""22""colspan=""11"" style=""font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Other Reference(s)</strong></td>
            </tr>
            <tr>
                <td colspan=""11"" style=""border-bottom:1px solid #333333; font-size : 10.4pt; font-family : Verdana"" class='font_size_26 font_V'><b>{6} {7}</b></td>
            </tr>",
                  expoter.Replace("/n/r", "<br/>").Replace("/r/n", "<br/>").Replace("\n", "<br/>"),
                  invoiceNumber.ToUpper(),
                  invoiceDate,
                  buyerOrderNumber,
                  buyerOrderDate, serialNumber,
                  objPacking.OtherReferences == null ? string.Empty : objPacking.OtherReferences.ToUpper(),
                  packingMode.ToUpper());

            htmlString.Append(htmlHeader1String.ToString());

            #endregion

            #region Header Part 2

            htmlHeader2String.AppendFormat(@"
            <tr>
                <td height=""28"" colspan=""10"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Consignee</strong></td>
                <td colspan=""11"" style=""font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Buyer ( If other than Consignee )</strong></td>
            </tr>
            <tr>
                <td colspan=""10"" rowspan=""4"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 10.4pt; font-family : Verdana"" class='font_size_26 font_V'><b>{0}</b></td>
                <td colspan=""11"" style=""border-bottom:1px solid #333333; font-size : 10.4pt; font-family : Verdana"" class='font_size_26 font_V'><b>{1}</b></td>
            </tr>
            <tr>
                <td colspan=""6"" style=""font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Country of origin of goods</strong></td>
                <td colspan=""5"" style=""font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Country of Final Destination</strong></td>
            </tr>
            <tr>
                <td colspan=""6"" style=""border-bottom:1px solid #333333; font-size : 10.4pt; font-family : Arial"" class='font_size_26 font_A'><b>{2}</b></td>
                <td colspan=""5"" style=""border-bottom:1px solid #333333; font-size : 10.4pt; font-family : Arial"" class='font_size_26 font_A'><b>{3}</b></td>
            </tr>
            <tr>
                <td height=""26"" colspan=""11"" style=""font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Terms of delivery and payment</strong></td>
            </tr>
        <tr>
            <td colspan=""5"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Pre-carriage by</strong></td>
            <td colspan=""5"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Place of receipt by pre-carrier</strong></td>
            <td colspan=""11"" rowspan=""6"" style=""border-bottom:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><b>{6}</b></td>
        </tr>
        <tr>
            <td colspan=""5"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 11.2pt; font-family : Arial"" class='font_size_28 font_A'><b>{4}</b></td>
            <td colspan=""5"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 11.2pt; font-family : Arial"" class='font_size_28 font_A'><b>{5}</b></td>
        </tr>
        <tr>
            <td colspan=""5"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Vessel/Flight No.</strong></td>
            <td colspan=""5"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Port of loading</strong></td>
        </tr>
        <tr>
            <td colspan=""5"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 11.2pt; font-family : Arial"" class='font_size_28 font_A'><b>{6}</b></td>
            <td colspan=""5"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 11.2pt; font-family : Arial"" class='font_size_28 font_A'><b>{7}</b></td>
        </tr>
        <tr>
            <td colspan=""5"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Port of Discharge</strong></td>
            <td colspan=""5"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Final Destination</strong></td>
        </tr>
        <tr>
             <td colspan=""5"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 11.2pt; font-family : Arial"" class='font_size_28 font_A'><b>{8}</b></td>
             <td colspan=""5"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 11.2pt; font-family : Arial"" class='font_size_28 font_A'><b>{9}</b></td>
        </tr>
         ",
              consignee.Replace("\r\n", "<br/>").Replace("\n\r", "<br/>").Replace("\n", "<br/>").ToUpper(),
              buyerOtherThanConsinee,
              countryOfOrigin,
              countryOfFinalDistination,
              preCarrageBy,
              placeOfReceivedByPreCarriage,
              fligthNumber,
              portOfLoading,
              portOfDischarge,
              objPacking.FinalDestination,
              termsOfDeliveryAndPayment.Replace("\r\n", "<br/>").Replace("\n\r", "<br/>")
             );
             
            htmlString.Append(htmlHeader2String.ToString());

            #endregion

            #region Header Part 3
            htmlHeader3String.AppendFormat(@"
            <tr>
                <td colspan=""4"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Marks &amp; No./Container No.</strong></td>
                <td colspan=""3"" style=""font-size :8.8pt; border-right:1px solid #333333; font-family : Arial"" class='font_size_22 font_A'><strong>No.&amp; kind of Pkgs.</strong></td>
                <td colspan=""3"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Description of goods</strong></td>
                <td colspan=""5"" align=""center"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Quantity</strong></td>
                <td colspan=""6"" align=""center"" style=""font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Remarks</strong></td>
                </tr>
            <tr>
                <td height=""84"" colspan=""4"" style=""border-right:1px solid #333333; font-size : 10.4pt; font-family : Verdana; border-bottom:1px solid #333333;""><span style=""padding-left: 5px;"" class='font_size_26 font_V'><b>{0}</b></span></td>
                <td colspan=""3"" style="" border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 10.4pt; font-family : Verdana""><span style=""padding-left: 5px;"" class='font_size_26 font_V'><b>{1}</b> </span></td>
            <td colspan=""3"" style="" border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 10.4pt; font-family : Verdana"" class='font_size_26 font_V'><b>{2}</b></td>
            <td colspan=""5"" align=""center"" style=""border-right:1px solid #333333; border-bottom:1px solid #333333; font-size : 10.4pt; font-family : Verdana"" class='font_size_26 font_V'><b>{3}</b></td>
            <td colspan=""6"" align=""center"" style=""border-bottom:1px solid #333333; font-size : 10.4pt; font-family : Verdana"" class='font_size_26 font_V'><b>{4}</b></td>
            </tr> ",
              marksAndCounterNumber.ToUpper().Replace("\r\n", "<br/>").Replace("\n\r", "<br/>"),
              descOfGoods.Replace("\r\n", "<br/>").Replace("\n\r", "<br/>"),
              string.Empty,
              string.Empty,
              remarks
                );

            htmlString.Append(htmlHeader3String.ToString());

            #endregion
            
            if (dt != null && dt.Rows.Count > 0)
            {
                int i = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    size0 = GetDataWithObject(dr["Size0"]);
                    size1 = GetDataWithObject(dr["Size1"]);
                    size2 = GetDataWithObject(dr["Size2"]);
                    size3 = GetDataWithObject(dr["Size3"]);
                    size4 = GetDataWithObject(dr["Size4"]);
                    size5 = GetDataWithObject(dr["Size5"]);
                    size6 = GetDataWithObject(dr["Size6"]);
                    size7 = GetDataWithObject(dr["Size7"]);
                    size8 = GetDataWithObject(dr["Size8"]);
                    size9 = GetDataWithObject(dr["Size9"]);
                    size10 = GetDataWithObject(dr["Size10"]);
                    size11 = GetDataWithObject(dr["Size11"]);

                    contractNumber = GetDataWithObject(dr["ContractNumber"]);
                    lineNumber = GetDataWithObject(dr["LineItemNumber"]);
                    styleNumber = GetDataWithObject(dr["StyleNumber"]);
                    color = GetDataWithObject(dr["FabricColor"]);
                    item = GetDataWithObject(dr["Item"]);
                    fabric = GetDataWithObject(dr["Fabric"]);
                    totalSingles = GetDataWithObject(dr["TotalSingles"]);
                    totalRatioPack = GetDataWithObject(dr["TotalRatioPack"]);
                    ratioPack = GetDataWithObject(dr["RatioPack"]);
                    totalTotal = "0";
                    singles0 = GetDataWithObject(dr["Singles0"]);
                    singles1 = GetDataWithObject(dr["Singles1"]);
                    singles2 = GetDataWithObject(dr["Singles2"]);
                    singles3 = GetDataWithObject(dr["Singles3"]);
                    singles4 = GetDataWithObject(dr["Singles4"]);
                    singles5 = GetDataWithObject(dr["Singles5"]);
                    singles6 = GetDataWithObject(dr["Singles6"]);
                    singles7 = GetDataWithObject(dr["Singles7"]);
                    singles8 = GetDataWithObject(dr["Singles8"]);
                    singles9 = GetDataWithObject(dr["Singles9"]);
                    singles10 = GetDataWithObject(dr["Singles10"]);
                    singles11 = GetDataWithObject(dr["Singles11"]);

                    ratio0 = GetDataWithObject(dr["Ratio0"]);
                    ratio1 = GetDataWithObject(dr["Ratio1"]);
                    ratio2 = GetDataWithObject(dr["Ratio2"]);
                    ratio3 = GetDataWithObject(dr["Ratio3"]);
                    ratio4 = GetDataWithObject(dr["Ratio4"]);
                    ratio5 = GetDataWithObject(dr["Ratio5"]);
                    ratio6 = GetDataWithObject(dr["Ratio6"]);
                    ratio7 = GetDataWithObject(dr["Ratio7"]);
                    ratio8 = GetDataWithObject(dr["Ratio8"]);
                    ratio9 = GetDataWithObject(dr["Ratio9"]);
                    ratio10 = GetDataWithObject(dr["Ratio10"]);
                    ratio11 = GetDataWithObject(dr["Ratio11"]);

                    sizeQuantity0 = GetDataWithObject(dr["SizeQuantity0"]);
                    sizeQuantity1 = GetDataWithObject(dr["SizeQuantity1"]);
                    sizeQuantity2 = GetDataWithObject(dr["SizeQuantity2"]);
                    sizeQuantity3 = GetDataWithObject(dr["SizeQuantity3"]);
                    sizeQuantity4 = GetDataWithObject(dr["SizeQuantity4"]);
                    sizeQuantity5 = GetDataWithObject(dr["SizeQuantity5"]);
                    sizeQuantity6 = GetDataWithObject(dr["SizeQuantity6"]);
                    sizeQuantity7 = GetDataWithObject(dr["SizeQuantity7"]);
                    sizeQuantity8 = GetDataWithObject(dr["SizeQuantity8"]);
                    sizeQuantity9 = GetDataWithObject(dr["SizeQuantity9"]);
                    sizeQuantity10 = GetDataWithObject(dr["SizeQuantity10"]);
                    sizeQuantity11 = GetDataWithObject(dr["SizeQuantity11"]);

                    int oProductionPlanningId;
                    if (int.TryParse(GetDataWithObject(dr["ProductionPlanningID"]), out oProductionPlanningId))
                    {
                        productionPlanningId = oProductionPlanningId;
                    }

                    int oOrderDetailId;
                    if (int.TryParse(GetDataWithObject(dr["OrderDetailID"]), out oOrderDetailId))
                    {
                        orderDetailID = oOrderDetailId;
                    }

                    int oPackingId;
                    if (int.TryParse(GetDataWithObject(dr["PackingID"]), out oPackingId))
                    {
                        PackingId = oPackingId;
                    }

                    if (i == 0)
                    {
                        #region Sizes Header

                        htmlSizesHeader.AppendFormat(@"
            <tr>
                <td align=""center"" width=""60"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"">&nbsp;</td>
                <td align=""center"" width=""60"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"">&nbsp;</td>
                <td align=""center"" width=""60"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"">&nbsp;</td>
                <td align=""center"" width=""60"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"">&nbsp;</td>
                <td align=""center"" width=""60"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"">&nbsp;</td>
                <td align=""center"" width=""70"" style=""font-size :8.8pt; font-family : Arial"">&nbsp;</td>
                <td align=""center"" width=""70"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"">&nbsp;</td>
                <td align=""center"" width=""80"" style=""border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"">&nbsp;</td>
                <td align=""center"" width=""660"" align=""center"" style=""border-bottom:1px solid #333333; font-size :8.8pt; font-family : Arial"" colspan=""12"" class='font_size_22 font_A'><u>SIZES</u></td>                
                <td align=""center"" width=""60"" style=""border-bottom:1px solid #333333; font-size :8.8pt; font-family : Arial"">&nbsp;</td>
            </tr>
                <td align=""center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Pkg No</strong></td>
                <td align=""center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Line No.</strong></td>
                <td align=""center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Style No</strong></td>
                <td align=""center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Color</strong></td>
                <td align=""center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Item</strong></td>
                <td align=""center"" colspan=""2"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Fabric</strong></td>
                <td align=""center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>QTY ( Pcs)</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{0}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{1}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{2}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{3}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{4}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{5}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{6}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{7}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{8}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{9}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{10}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{11}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'>&nbsp;</td>
            </tr>",
                                              size0, size1, size2, size3, size4, size5, size6, size7, size8, size9, size10, size11);

                        htmlString.Append(htmlSizesHeader.ToString());
                        htmlHeader.Remove(0, htmlHeader.Length);
                        htmlHeader.Append(htmlSizesHeader.ToString());
                        htmlSizesHeader.Remove(0, htmlSizesHeader.Length);
                        
                        #endregion
                    }

                    #region Size Body

                    if (pageHeight >= 30)
                    {
                        htmlSizesBody.Remove(0, htmlSizesBody.Length);
                        pageHeight = 2;
                        pageNo = pageNo + 1;
                        htmlString.Append(htmTableEnd);
                        htmlString.Append(GetHeader(pageNo)).Append(htmlHeader1String).Append(htmlHeader2String).Append(htmlHeader3String);
                        htmlString.Append(htmlHeader.ToString());
                    }
                    
                    htmlSizesBody.Remove(0, htmlSizesBody.Length);
                    htmlSizesBody.AppendFormat(@"
           <tr>
                <td align=""center"" rowspan=""3"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; border-right:1px solid #333333; font-size : 10pt; font-family : Verdana"" class='font_size_25 font_V'>&nbsp;</td>
                <td align=""center"" rowspan=""3"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; border-right:1px solid #333333; font-size : 9.6pt; font-family : Verdana"" class='font_size_24 font_V'><b>{0} <br/> {1}</b></td>
                <td align=""center"" rowspan=""3"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; border-right:1px solid #333333; font-size : 6.4pt; font-family : Verdana"" class='font_size_16 font_V'><b>{2}</b></td>
                <td align=""center"" rowspan=""3"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; border-right:1px solid #333333; font-size : 8pt; font-family : Verdana"" class='font_size_20 font_V'><b>{3}</b></td>
                <td align=""center"" rowspan=""3"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; border-right:1px solid #333333; border-right:1px solid #333333; font-size : 8pt; font-family : Verdana"" class='font_size_20 font_V'><b>{4}</b></td>
                <td align=""center"" rowspan=""3"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; border-right:1px solid #333333; font-size : 8pt; font-family : Verdana"" class='font_size_20 font_V'><b>{5}</b></td>
                <td align=""center"" rowspan=""3"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; border-right:1px solid #333333; font-size : 8pt; font-family : Verdana"" class='font_size_20 font_V'>&nbsp;</td>                
                <td align=""center"" rowspan=""3"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Verdana"" class='font_size_22 font_V'><b>SINGLES :{6} <br/> RATIO PACK : {7} <br/> TOTAL : {8} </b></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana"" class='font_size_23 font_V'><strong>S {9}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana"" class='font_size_23 font_V'><strong>{10}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{11}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{12}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{13}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{14}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{15}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{16}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana"" class='font_size_23 font_V'><strong>{17}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana"" class='font_size_23 font_V'><strong>{18}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{19}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{20}</strong></td>           
                <td style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'>&nbsp;</td>
           </tr>
             <tr>                
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana"" class='font_size_23 font_V'><strong>R {21}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana"" class='font_size_23 font_V'><strong>{22}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{23}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{24}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{25}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana"" class='font_size_23 font_V' ><strong>{26}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{27}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{28}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana"" class='font_size_23 font_V'><strong>{29}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana"" class='font_size_23 font_V'><strong>{30}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{31}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{32}</strong></td>           
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'>&nbsp;</td>
           </tr>
             <tr>                
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana"" class='font_size_23 font_V'><strong>TOT {33}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana"" class='font_size_23 font_V'><strong>{34}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{35}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{36}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{37}</strong></td>
                <td align='center' align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{38}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{39}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{40}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana"" class='font_size_23 font_V'><strong>{41}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana"" class='font_size_23 font_V'><strong>{42}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{43}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{44}</strong></td>           
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana"" class='font_size_23 font_V' >&nbsp;</td>
           </tr>
          ",
                        contractNumber.ToUpper(),
                        lineNumber.ToUpper(),
                        styleNumber.ToUpper(),
                        color.ToUpper(),
                        item.ToUpper(),
                        fabric.ToUpper(),
                        totalSingles,
                        totalRatioPack,
                        totalTotal,
                        singles0,
                        singles1,
                        singles2,
                        singles3,
                        singles4,
                        singles5,
                        singles6,
                        singles7,
                        singles8,
                        singles9,
                        singles10,
                        singles11,
                        ratio0,
                        ratio1,
                        ratio2,
                        ratio3,
                        ratio4,
                        ratio5,
                        ratio6,
                        ratio7,
                        ratio8,
                        ratio9,
                        ratio10,
                        ratio11,
                        sizeQuantity0,
                        sizeQuantity1,
                        sizeQuantity2,
                        sizeQuantity3,
                        sizeQuantity4,
                        sizeQuantity5,
                        sizeQuantity6,
                        sizeQuantity7,
                        sizeQuantity8,
                        sizeQuantity9,
                        sizeQuantity10,
                        sizeQuantity11
                        );

                    htmlString.Append(htmlSizesBody.ToString());

                    if (PackingId > 0)
                    {
                        List<PackingDistribution> packingDistributionList = objPacking.Distributions.FindAll(delegate(PackingDistribution p) { return (p.OrderDetailID == orderDetailID && p.ProductionPlanningID == productionPlanningId); });

                        if (packingDistributionList.Count > 0)
                        {
                            int[] totalSingel = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                            int totalRatioPackQuanity = 0;

                            DataRow drOrderDetail = dtOrderdetail.NewRow();

                            drOrderDetail["ProductionPlanningID"] = productionPlanningId;
                            drOrderDetail["OrderDetailID"] = orderDetailID;
                            drOrderDetail["PkgNOFrom"] = string.Empty;
                            drOrderDetail["PkgNOTO"] = string.Empty;

                            for (int count = 0; count <= 11; count++)
                            {
                                drOrderDetail["TotalSingles" + count] = totalSingel[count].ToString();
                            }

                            foreach (PackingDistribution packingDistributionItem in packingDistributionList)
                            {
                                int totalSize = 0;
                                string sizeValues = string.Empty;
                                int sizeCounter = 0;

                                totalRatioPackQuanity += packingDistributionItem.RatioPackQtyPerPkg;

                                for (int count = 0; count <= 11; count++)
                                {
                                    totalSingel[count] = 0;
                                }

                                foreach (OrderDetailSizes size in packingDistributionItem.PackingSizes)
                                {
                                    int qty = packingDistributionItem.Sizes[sizeCounter];
                                    if (sizeCounter == 12)
                                    {
                                        break;
                                    }
                                    totalSingel[sizeCounter] += qty;
                                    string txtValue = qty.ToString();

                                    if (packingDistributionItem.IsRatioPack)
                                    {
                                        qty = 0;
                                    }

                                    totalSize += qty;
                                    sizeCounter++;
                                }

                                string qtyPCS = string.Empty;
                                int boxes = 0;

                                if (Convert.ToString(drOrderDetail["PkgNOFrom"]) == string.Empty)
                                {
                                    drOrderDetail["PkgNOFrom"] = packingDistributionItem.PkgNoFrom.ToString();
                                }

                                drOrderDetail["PkgNOTO"] = packingDistributionItem.PkgNoTo.ToString();
                                boxes = (packingDistributionItem.PkgNoTo - packingDistributionItem.PkgNoFrom + 1);

                                for (int count = 0; count <= 11; count++)
                                {
                                    drOrderDetail["TotalSingles" + count] = Convert.ToInt32(drOrderDetail["TotalSingles" + count]) + (totalSingel[count] * boxes);
                                }

                                int rp = 0;
                                int oRatioPack;
                                if (int.TryParse(ratioPack, out oRatioPack))
                                {
                                    rp = oRatioPack;
                                }

                                if (!packingDistributionItem.IsRatioPack)
                                {
                                    qtyPCS = totalSize.ToString() + " X " + boxes + " = " + (totalSize * boxes);
                                    verticalSizeQuantityTotal += (totalSize * boxes);
                                }
                                else
                                {
                                    qtyPCS = ratioPack.ToString() + " X " + packingDistributionItem.RatioPackQtyPerPkg.ToString() + " = " + (rp * packingDistributionItem.RatioPackQtyPerPkg).ToString() + " X " + boxes + " = " + (rp * packingDistributionItem.RatioPackQtyPerPkg * boxes);
                                    verticalSizeQuantityTotal += (rp * packingDistributionItem.RatioPackQtyPerPkg * boxes);
                                }

                                htmlSizesBody.Remove(0, htmlSizesBody.Length);
                                htmlSizesBody.Append("<TR>");
                                
                                string pkgNo = string.Empty;
                                if (boxes == 1)
                                {
                                    pkgNo = packingDistributionItem.PkgNoFrom.ToString();
                                }
                                else
                                {
                                    pkgNo = packingDistributionItem.PkgNoFrom.ToString() + " TO " + packingDistributionItem.PkgNoTo.ToString();
                                }

                                htmlSizesBody.AppendFormat(@" <td align=""center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 10pt; font-family : Verdana""  class='font_size_25 font_V'><b>{0}</b></td>", pkgNo);
                                htmlSizesBody.AppendFormat(@" <td align=""center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.6pt; font-family : Verdana""  class='font_size_24 font_V'><b>{0} <br/> {1}</b></td>", contractNumber.ToUpper(), lineNumber.ToUpper());
                                htmlSizesBody.Append(@" <td align=""center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Verdana""  class='font_size_22 font_V'>--DO--</td>");
                                htmlSizesBody.Append(@" <td align=""center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Verdana""  class='font_size_22 font_V'>--DO--</td>");
                                htmlSizesBody.Append(@" <td align=""center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Verdana""  class='font_size_22 font_V'>--DO--</td>");
                                htmlSizesBody.Append(@" <td align=""Center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Verdana""  class='font_size_22 font_V'>--DO--</td>");
                                htmlSizesBody.Append(@" <td align=""Center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Verdana""  class='font_size_22 font_V'>--DO--</td>");
                                htmlSizesBody.AppendFormat(@" <td align=""center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Verdana""  class='font_size_22 font_V'><b>{0} PCS</b></td>", qtyPCS);

                                if (!packingDistributionItem.IsRatioPack)
                                {
                                    for (int count = 0; count <= 11; count++)
                                    {
                                        string qty = string.Empty;
                                        if (dr["Size" + count].ToString() != string.Empty)
                                        {
                                            qty = (totalSingel[count] == 0) ? "X" : "<b>"+totalSingel[count].ToString()+"</b>";
                                        }
                                        htmlSizesBody.AppendFormat(@" <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{0}</strong></td>", qty);
                                    }
                                    htmlSizesBody.AppendFormat(@" <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong><b>{0}</b></strong></td>", "");
                                }
                                else
                                {
                                    string qty = (packingDistributionItem.RatioPackQtyPerPkg == 0) ? "X" : "<b>"+ packingDistributionItem.RatioPackQtyPerPkg.ToString()+"</b>";
                                    htmlSizesBody.AppendFormat(@" <td align='center' colspan=""12""  style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong>{0}</strong></td>", qty);
                                    htmlSizesBody.AppendFormat(@" <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size : 9.2pt; font-family : Verdana""  class='font_size_23 font_V'><strong><b>{0}</b></strong></td>", "R");
                                }
                                htmlSizesBody.Append("</tr>");
                                htmlString.Append(htmlSizesBody);
                                pageHeight = pageHeight + 1;

                                if (pageHeight >= 30)
                                {
                                    htmlSizesBody.Remove(0, htmlSizesBody.Length);
                                    pageHeight = 0;
                                    pageNo = pageNo + 1;
                                    htmlString.Append(htmTableEnd);
                                    htmlString.Append(GetHeader(pageNo)).Append(htmlHeader1String).Append(htmlHeader2String).Append(htmlHeader3String);
                                    htmlString.Append(htmlHeader.ToString());
                                }
                            }

                            drOrderDetail["TotalRatioPackQuanity"] = totalRatioPackQuanity.ToString();
                            dtOrderdetail.Rows.Add(drOrderDetail);
                        }
                    }

                    #endregion

                    i++;

                }

                #region Sizes Footer
                htmlSizesFooter.Remove(0, htmlSizesFooter.Length);
                htmlSizesFooter.AppendFormat(@"
             <tr>
                <td colspan=""6"" style=""font-size :8.8pt; font-family : Arial"">&nbsp;</td>            
                <td align='center' style=""border-left:1px solid #333333; border-bottom:1px solid #333333; font-size : 12pt; font-family : Arial""  class='font_size_30 font_A'><strong>Total</strong></td>
                <td align='center' style=""border-right:1px solid #333333; border-bottom:1px solid #333333; font-size : 11.2pt; font-family : Arial""  class='font_size_28 font_A'><strong>{0} PCS</strong></td>
                <td colspan=""13"" style=""font-size :8.8pt; font-family : Arial"">&nbsp;</td> 
              </tr>", verticalSizeQuantityTotal.ToString());

                htmlString.Append(htmlSizesFooter.ToString());
                pageHeight = pageHeight + 1;

                #endregion

            }

            if (pageHeight >= 25)
            {
                htmlSizesBody.Remove(0, htmlSizesBody.Length);
                pageHeight = 0;
                pageNo = pageNo + 1;
                htmlString.Append(htmTableEnd);
                htmlString.Append(GetHeader(pageNo)).Append(htmlHeader1String).Append(htmlHeader2String).Append(htmlHeader3String);
            }

            #region Summary Header
            int[] summaryVerticalTOtal = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            if (dt != null && dt.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    size0 = GetDataWithObject(dr["Size0"]);
                    size1 = GetDataWithObject(dr["Size1"]);
                    size2 = GetDataWithObject(dr["Size2"]);
                    size3 = GetDataWithObject(dr["Size3"]);
                    size4 = GetDataWithObject(dr["Size4"]);
                    size5 = GetDataWithObject(dr["Size5"]);
                    size6 = GetDataWithObject(dr["Size6"]);
                    size7 = GetDataWithObject(dr["Size7"]);
                    size8 = GetDataWithObject(dr["Size8"]);
                    size9 = GetDataWithObject(dr["Size9"]);
                    size10 = GetDataWithObject(dr["Size10"]);
                    size11 = GetDataWithObject(dr["Size11"]);

                    ratio0 = GetDataWithObject(dr["Ratio0"]);
                    ratio1 = GetDataWithObject(dr["Ratio1"]);
                    ratio2 = GetDataWithObject(dr["Ratio2"]);
                    ratio3 = GetDataWithObject(dr["Ratio3"]);
                    ratio4 = GetDataWithObject(dr["Ratio4"]);
                    ratio5 = GetDataWithObject(dr["Ratio5"]);
                    ratio6 = GetDataWithObject(dr["Ratio6"]);
                    ratio7 = GetDataWithObject(dr["Ratio7"]);
                    ratio8 = GetDataWithObject(dr["Ratio8"]);
                    ratio9 = GetDataWithObject(dr["Ratio9"]);
                    ratio10 = GetDataWithObject(dr["Ratio10"]);
                    ratio11 = GetDataWithObject(dr["Ratio11"]);

                    contractNumber = GetDataWithObject(dr["ContractNumber"]);
                    lineNumber = GetDataWithObject(dr["LineItemNumber"]);
                    styleNumber = GetDataWithObject(dr["StyleNumber"]);
                    color = GetDataWithObject(dr["FabricColor"]);
                    item = GetDataWithObject(dr["Item"]);
                    fabric = GetDataWithObject(dr["Fabric"]);
                    totalSingles = GetDataWithObject(dr["TotalSingles"]);

                    totalRatioPack = GetDataWithObject(dr["TotalRatioPack"]);
                    ratioPack = GetDataWithObject(dr["RatioPack"]);

                    productionPlanningId = GetIntegerValueFromStringValue(dr["ProductionPlanningID"].ToString());


                    if (i == 0)
                    {
                        htmlSummaryHeader.Remove(0, htmlSummaryHeader.Length);
                        htmlSummaryHeader.AppendFormat(@"
            <tr>
                <td colspan=""8"" style=""border-right:1px solid #333333; border-bottom:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong><u>SUMMARY</u></strong></td>
                <td colspan=""13"" align=""center"" style=""border-right:1px solid #333333; border-bottom:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong><u>SIZES</u></strong></td>
            </tr>
            <tr>
                <td colspan=""2"" align=""center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>Line No.</strong></td>
                <td style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" align=""center"" colspan=""3""  class='font_size_22 font_A'><strong>Color</strong></td>
                <td style=""border-bottom:1px solid #333333; border-right:1px solid #333333;"" align=""center"" colspan=""3""  class='font_size_22 font_A'><strong>Pkg No</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>{0}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>{1}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{2}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{3}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{4}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{5}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{6}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{7}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{8}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{9}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{10}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{11}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>Total</strong></td>
            </tr>",
                            size0, size1, size2, size3, size4, size5, size6, size7, size8, size9, size10, size11);

                        htmlString.Append(htmlSummaryHeader.ToString());
            #endregion
                    }


                    #region Summary Body
                    if (dtOrderdetail != null && dtOrderdetail.Rows.Count > 0)
                    {
                        DataRow[] rows = dtOrderdetail.Select("ProductionPlanningID=" + productionPlanningId.ToString());

                        foreach (DataRow row in rows)
                        {
                            int horizontalRatioTotal = 0;
                            int horizontalSingleTotal = 0;
                            int ratioPackTotal = GetIntegerValueFromStringValue(ratioPack);

                            int totalRatioPackQuantity = GetIntegerValueFromStringValue(totalRatioPack);

                            int ratioHorizontal0 = InilizeRatioForSummary(ratio0, totalRatioPackQuantity, ratioPackTotal);
                            horizontalRatioTotal += ratioHorizontal0;
                            summaryVerticalTOtal[0] += ratioHorizontal0;

                            int ratioHorizontal1 = InilizeRatioForSummary(ratio1, totalRatioPackQuantity, ratioPackTotal);
                            horizontalRatioTotal += ratioHorizontal1;
                            summaryVerticalTOtal[1] += ratioHorizontal1;

                            int ratioHorizontal2 = InilizeRatioForSummary(ratio2, totalRatioPackQuantity, ratioPackTotal);
                            horizontalRatioTotal += ratioHorizontal2;
                            summaryVerticalTOtal[2] += ratioHorizontal2;

                            int ratioHorizontal3 = InilizeRatioForSummary(ratio3, totalRatioPackQuantity, ratioPackTotal);
                            horizontalRatioTotal += ratioHorizontal3;
                            summaryVerticalTOtal[3] += ratioHorizontal3;

                            int ratioHorizontal4 = InilizeRatioForSummary(ratio4, totalRatioPackQuantity, ratioPackTotal);
                            horizontalRatioTotal += ratioHorizontal4;
                            summaryVerticalTOtal[4] += ratioHorizontal4;

                            int ratioHorizontal5 = InilizeRatioForSummary(ratio5, totalRatioPackQuantity, ratioPackTotal);
                            horizontalRatioTotal += ratioHorizontal5;
                            summaryVerticalTOtal[5] += ratioHorizontal5;

                            int ratioHorizontal6 = InilizeRatioForSummary(ratio6, totalRatioPackQuantity, ratioPackTotal);
                            horizontalRatioTotal += ratioHorizontal6;
                            summaryVerticalTOtal[6] += ratioHorizontal6;

                            int ratioHorizontal7 = InilizeRatioForSummary(ratio7, totalRatioPackQuantity, ratioPackTotal);
                            horizontalRatioTotal += ratioHorizontal7;
                            summaryVerticalTOtal[7] += ratioHorizontal7;

                            int ratioHorizontal8 = InilizeRatioForSummary(ratio8, totalRatioPackQuantity, ratioPackTotal);
                            horizontalRatioTotal += ratioHorizontal8;
                            summaryVerticalTOtal[8] += ratioHorizontal8;

                            int ratioHorizontal9 = InilizeRatioForSummary(ratio9, totalRatioPackQuantity, ratioPackTotal);
                            horizontalRatioTotal += ratioHorizontal9;
                            summaryVerticalTOtal[9] += ratioHorizontal9;

                            int ratioHorizontal10 = InilizeRatioForSummary(ratio10, totalRatioPackQuantity, ratioPackTotal);
                            horizontalRatioTotal += ratioHorizontal10;
                            summaryVerticalTOtal[10] += ratioHorizontal10;

                            int ratioHorizontal11 = InilizeRatioForSummary(ratio11, totalRatioPackQuantity, ratioPackTotal);
                            horizontalRatioTotal += ratioHorizontal11;
                            summaryVerticalTOtal[11] += ratioHorizontal11;

                            string single0 = GetDataWithObject(row["TotalSingles0"]);
                            string single1 = GetDataWithObject(row["TotalSingles1"]);
                            string single2 = GetDataWithObject(row["TotalSingles2"]);
                            string single3 = GetDataWithObject(row["TotalSingles3"]);
                            string single4 = GetDataWithObject(row["TotalSingles4"]);
                            string single5 = GetDataWithObject(row["TotalSingles5"]);
                            string single6 = GetDataWithObject(row["TotalSingles6"]);
                            string single7 = GetDataWithObject(row["TotalSingles7"]);
                            string single8 = GetDataWithObject(row["TotalSingles8"]);
                            string single9 = GetDataWithObject(row["TotalSingles9"]);
                            string single10 = GetDataWithObject(row["TotalSingles10"]);
                            string single11 = GetDataWithObject(row["TotalSingles11"]);

                            int singleHorizontal0 = GetIntegerValueFromStringValue(single0);
                            horizontalSingleTotal += singleHorizontal0;
                            summaryVerticalTOtal[0] += singleHorizontal0;

                            int singleHorizontal1 = GetIntegerValueFromStringValue(single1);
                            horizontalSingleTotal += singleHorizontal1;
                            summaryVerticalTOtal[1] += singleHorizontal1;

                            int singleHorizontal2 = GetIntegerValueFromStringValue(single2);
                            horizontalSingleTotal += singleHorizontal2;
                            summaryVerticalTOtal[2] += singleHorizontal2;

                            int singleHorizontal3 = GetIntegerValueFromStringValue(single3);
                            horizontalSingleTotal += singleHorizontal3;
                            summaryVerticalTOtal[3] += singleHorizontal3;

                            int singleHorizontal4 = GetIntegerValueFromStringValue(single4);
                            horizontalSingleTotal += singleHorizontal4;
                            summaryVerticalTOtal[4] += singleHorizontal4;

                            int singleHorizontal5 = GetIntegerValueFromStringValue(single5);
                            horizontalSingleTotal += singleHorizontal5;
                            summaryVerticalTOtal[5] += singleHorizontal5;

                            int singleHorizontal6 = GetIntegerValueFromStringValue(single6);
                            horizontalSingleTotal += singleHorizontal6;
                            summaryVerticalTOtal[6] += singleHorizontal6;

                            int singleHorizontal7 = GetIntegerValueFromStringValue(single7);
                            horizontalSingleTotal += singleHorizontal7;
                            summaryVerticalTOtal[7] += singleHorizontal7;

                            int singleHorizontal8 = GetIntegerValueFromStringValue(single8);
                            horizontalSingleTotal += singleHorizontal8;
                            summaryVerticalTOtal[8] += singleHorizontal8;

                            int singleHorizontal9 = GetIntegerValueFromStringValue(single9);
                            horizontalSingleTotal += singleHorizontal9;
                            summaryVerticalTOtal[9] += singleHorizontal9;

                            int singleHorizontal10 = GetIntegerValueFromStringValue(single10);
                            horizontalSingleTotal += singleHorizontal10;
                            summaryVerticalTOtal[10] += singleHorizontal10;

                            int singleHorizontal11 = GetIntegerValueFromStringValue(single11);
                            horizontalSingleTotal += singleHorizontal11;
                            summaryVerticalTOtal[11] += singleHorizontal11;

                            summaryVerticalTOtal[12] += horizontalSingleTotal + horizontalRatioTotal;

                            string pkgNoFrom = GetDataWithObject(row["PkgNOFrom"]);
                            string pkgNoTo = GetDataWithObject(row["PkgNOTO"]);

                            htmlSummaryBody.Remove(0, htmlSummaryBody.Length);
                            htmlSummaryBody.Append("<tr>");
                            htmlSummaryBody.AppendFormat(@"<td rowspan=""2"" align=""center"" colspan=""2"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>{0} <br/> {1}</strong></td>", contractNumber.ToUpper(), lineNumber.ToUpper());
                            htmlSummaryBody.AppendFormat(@"<td rowspan=""2"" align=""center"" colspan=""3"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>{0} </strong></td>", color.ToUpper());
                            htmlSummaryBody.AppendFormat(@"<td rowspan=""2"" align=""center"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" colspan=""3""  class='font_size_22 font_A'><strong>{0} TO {1}</strong></td>", pkgNoFrom, pkgNoTo);
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(ratioHorizontal0 > 0 ? ratioHorizontal0.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(ratioHorizontal1 > 0 ? ratioHorizontal1.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(ratioHorizontal2 > 0 ? ratioHorizontal2.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(ratioHorizontal3 > 0 ? ratioHorizontal3.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(ratioHorizontal4 > 0 ? ratioHorizontal4.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(ratioHorizontal5 > 0 ? ratioHorizontal5.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(ratioHorizontal6 > 0 ? ratioHorizontal6.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(ratioHorizontal7 > 0 ? ratioHorizontal7.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(ratioHorizontal8 > 0 ? ratioHorizontal8.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(ratioHorizontal9 > 0 ? ratioHorizontal9.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(ratioHorizontal10 > 0 ? ratioHorizontal10.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(ratioHorizontal11 > 0 ? ratioHorizontal11.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(horizontalRatioTotal > 0 ? horizontalRatioTotal.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append("</tr>");
                            htmlSummaryBody.Append("<tr>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(singleHorizontal0 > 0 ? singleHorizontal0.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(singleHorizontal1 > 0 ? singleHorizontal1.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(singleHorizontal2 > 0 ? singleHorizontal2.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(singleHorizontal3 > 0 ? singleHorizontal3.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(singleHorizontal4 > 0 ? singleHorizontal4.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(singleHorizontal5 > 0 ? singleHorizontal5.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(singleHorizontal6 > 0 ? singleHorizontal6.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(singleHorizontal7 > 0 ? singleHorizontal7.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(singleHorizontal8 > 0 ? singleHorizontal8.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(singleHorizontal9 > 0 ? singleHorizontal9.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(singleHorizontal10 > 0 ? singleHorizontal10.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(singleHorizontal11 > 0 ? singleHorizontal11.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append(@"<td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>").Append(horizontalSingleTotal > 0 ? horizontalSingleTotal.ToString() : string.Empty).Append("</strong></td>");
                            htmlSummaryBody.Append("</tr>");

                            htmlString.Append(htmlSummaryBody);                          
                        }
                    }
                    #endregion

                    i++;
                }

                #region Summary Total

                htmlSummaryFooter.AppendFormat(@"
            <tr>
                <td colspan=""8"" style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial text-align : right;""  class='font_size_22 font_A'><strong><strong>TOTAL</strong></strong></td>                
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>{0}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>{1}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{2}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{3}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{4}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{5}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{6}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{7}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{8}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{9}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{10}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{11}</strong></td>
                <td align='center' style=""border-bottom:1px solid #333333; border-right:1px solid #333333; font-size :8.8pt; font-family : Arial"" class='font_size_22 font_A'><strong>{12}</strong></td>
            </tr>",
          summaryVerticalTOtal[0] == 0 ? string.Empty : summaryVerticalTOtal[0].ToString(),
          summaryVerticalTOtal[1] == 0 ? string.Empty : summaryVerticalTOtal[1].ToString(),
          summaryVerticalTOtal[2] == 0 ? string.Empty : summaryVerticalTOtal[2].ToString(),
          summaryVerticalTOtal[3] == 0 ? string.Empty : summaryVerticalTOtal[3].ToString(),
          summaryVerticalTOtal[4] == 0 ? string.Empty : summaryVerticalTOtal[4].ToString(),
          summaryVerticalTOtal[5] == 0 ? string.Empty : summaryVerticalTOtal[5].ToString(),
          summaryVerticalTOtal[6] == 0 ? string.Empty : summaryVerticalTOtal[6].ToString(),
          summaryVerticalTOtal[7] == 0 ? string.Empty : summaryVerticalTOtal[7].ToString(),
          summaryVerticalTOtal[8] == 0 ? string.Empty : summaryVerticalTOtal[8].ToString(),
          summaryVerticalTOtal[9] == 0 ? string.Empty : summaryVerticalTOtal[9].ToString(),
          summaryVerticalTOtal[10] == 0 ? string.Empty : summaryVerticalTOtal[10].ToString(),
          summaryVerticalTOtal[11] == 0 ? string.Empty : summaryVerticalTOtal[11].ToString(),
          summaryVerticalTOtal[12] == 0 ? string.Empty : summaryVerticalTOtal[12].ToString()
          );

                htmlString.Append(htmlSummaryFooter.ToString());                
                #endregion
            }

            #region Signature            
            htmlSignature.AppendFormat(@" 
            <tr>
                <td colspan=""2"" style=""font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>Total Gross Weight in Kgs.</strong></td>
                <td colspan=""8"" align=""left"" style=""font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>{0}</strong></td>
                <td colspan=""11"" rowspan=""2"" style=""font-size :8.8pt; font-family : Arial"">&nbsp;</td>
            </tr>
            <tr>
                <td colspan=""2"" style=""font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>Total Net Weight in Kgs.</strong></td>
                <td colspan=""8"" align=""left"" style=""font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>{1}</strong></td>                
            </tr>
            ", totalGrossWeight, totalNetWeight);

            htmlString.Append(htmlSignature.ToString());

            #endregion

            #region Dimension

            string packingDimension = string.Empty;
            string dims = string.Empty; 

            if (objPacking.Dimensions != null && objPacking.Dimensions.Count > 0)
            {
                foreach (PackingDimension dimension in objPacking.Dimensions)
                {
                    if (packingDimension == string.Empty)
                    {
                        packingDimension = dimension.Dimension + " / " + dimension.Quantity + " BOXES";
                        dims = "DIMS.";
                    }
                    else
                    {
                        packingDimension = packingDimension + "<br/>" + dimension.Dimension + " / " + dimension.Quantity + " BOXES";
                        dims = dims + "<br/>" + "DIMS.";
                    }
                } 
            }

            htmlDimension.AppendFormat(@" 
            <tr>
                <td colspan=""2"" height=""100"" style=""font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>{0}</strong></td>
                <td colspan=""8"" height=""100"" style=""font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>{1}</strong></td>
                <td colspan=""11"" height=""100"" align=""left"" valign=""top"" style=""border-top:1px solid #333333; border-left:1px solid #333333; txt-align : top; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>Signature &amp; Date</strong></td>
            </tr>  
            <tr>     
                <td colspan=""2"" height=""100"" style=""font-size :8.8pt; font-family : Arial""><strong>&nbsp;</strong></td>
                <td colspan=""8"" height=""100"" style=""font-size :8.8pt; font-family : Arial"" ><strong>&nbsp;</td>           
                <td colspan=""11"" height=""100"" style="" border-left:1px solid #333333; font-size :8.8pt; font-family : Arial"">&nbsp;</td>
            </tr>
            <tr>     
                <td colspan=""2"" height=""100"" style=""font-size :8.8pt; font-family : Arial""><strong>&nbsp;</strong></td>
                <td colspan=""8"" height=""100"" style=""font-size :8.8pt; font-family : Arial"" ><strong>&nbsp;</td>           
                <td colspan=""11"" height=""100""  style="" border-left:1px solid #333333; font-size :8.8pt; font-family : Arial"">&nbsp;</td>
            </tr>
            <tr>     
                <td colspan=""2"" height=""100"" style=""font-size :8.8pt; font-family : Arial""><strong>&nbsp;</strong></td>
                <td colspan=""8"" height=""100"" style=""font-size :8.8pt; font-family : Arial"" ><strong>&nbsp;</td>           
                <td colspan=""11"" height=""100""  style="" border-left:1px solid #333333; font-size :8.8pt; font-family : Arial"">&nbsp;</td>
            </tr>          
            ", dims, packingDimension);

            htmlString.Append(htmlDimension.ToString());

            #endregion

            htmlString.Append(htmTableEnd.ToString());

            if (!System.IO.Directory.Exists(Constants.TEMP_FOLDER_PATH))
                System.IO.Directory.CreateDirectory(Constants.TEMP_FOLDER_PATH);

            string fileName = FileName + "_" + objPacking.SerialNumber + "-" + DateTime.Now.ToString("dd MMM yyy hh-mm-ss") + ".xls";

            string FilePath = System.IO.Path.Combine(Constants.TEMP_FOLDER_PATH, fileName);
            
            System.IO.File.WriteAllText(FilePath, htmlString.ToString());

            return fileName;

        }

        private string GetHeader(int pageNumber)
        {
            StringBuilder htmlTableStart = new StringBuilder();
            htmlTableStart.AppendFormat(@"<table width=""950px"" border=""0"" cellspacing=""0"" cellpadding=""4"" style=""border: 1px solid #333333;"">
                                         <tr> 
                                               <td colspan=""21"" height=""80"" align=""center"" style=""font-size : 14.4pt; font-family : Arial""  class='font_size_36 font_A'><strong>PACKING LIST</strong></td>
                                          </tr>
                                             <tr>                                               
                                               <td colspan=""21"" height=""30"" align=""right"" style=""border-bottom:1px solid #333333; font-size :8.8pt; font-family : Arial""  class='font_size_22 font_A'><strong>{0}-{1}</strong></td>             
                                          </tr>", "Continuation Sheet", pageNumber.ToString());
            return htmlTableStart.ToString();
             
        }

        private String GetDataWithObject(object obj)
        {
            string str = string.Empty;
            if (obj != null && !(obj is System.DBNull))
            {
                str = obj.ToString();
            }
            return str;
        }

        private int InilizeRatioForSummary(string Ratio, int RationQuantity, int RatioPack)
        {
            int value = 0;
            if (RatioPack > 0)
            {
                int outputValue;
                if (int.TryParse(Ratio, out outputValue))
                {
                    value = (outputValue * RationQuantity) / RatioPack ;
                }
            }

            return value;
        }

        private int GetIntegerValueFromStringValue(string StrValue)
        {
            int value = 0;
            int outputValue;
            if (int.TryParse(StrValue, out outputValue))
            {
                value = outputValue;
            }

            return value;
        }

        private DataTable GetDataTableForPacking(List<PackingDistribution> objPackingDistributionList, Packing objPacking, int PackingId)
        {
            DataTable dt = new DataTable();
            
            dt.Columns.Add("ProductionPlanningID");
            dt.Columns.Add("OrderDetailID");
            dt.Columns.Add("PackingID");
            dt.Columns.Add("LineItemNumber");
            dt.Columns.Add("ContractNumber");
            dt.Columns.Add("StyleNumber");
            dt.Columns.Add("FabricColor");
            dt.Columns.Add("Item");
            dt.Columns.Add("Fabric");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("ShippingQuantity");
            dt.Columns.Add("Size0");
            dt.Columns.Add("Size1");
            dt.Columns.Add("Size2");
            dt.Columns.Add("Size3");
            dt.Columns.Add("Size4");
            dt.Columns.Add("Size5");
            dt.Columns.Add("Size6");
            dt.Columns.Add("Size7");
            dt.Columns.Add("Size8");
            dt.Columns.Add("Size9");
            dt.Columns.Add("Size10");
            dt.Columns.Add("Size11");

            dt.Columns.Add("SizeQuantity0");
            dt.Columns.Add("SizeQuantity1");
            dt.Columns.Add("SizeQuantity2");
            dt.Columns.Add("SizeQuantity3");
            dt.Columns.Add("SizeQuantity4");
            dt.Columns.Add("SizeQuantity5");
            dt.Columns.Add("SizeQuantity6");
            dt.Columns.Add("SizeQuantity7");
            dt.Columns.Add("SizeQuantity8");
            dt.Columns.Add("SizeQuantity9");
            dt.Columns.Add("SizeQuantity10");
            dt.Columns.Add("SizeQuantity11");

            dt.Columns.Add("Singles0");
            dt.Columns.Add("Singles1");
            dt.Columns.Add("Singles2");
            dt.Columns.Add("Singles3");
            dt.Columns.Add("Singles4");
            dt.Columns.Add("Singles5");
            dt.Columns.Add("Singles6");
            dt.Columns.Add("Singles7");
            dt.Columns.Add("Singles8");
            dt.Columns.Add("Singles9");
            dt.Columns.Add("Singles10");
            dt.Columns.Add("Singles11");

            dt.Columns.Add("Ratio0");
            dt.Columns.Add("Ratio1");
            dt.Columns.Add("Ratio2");
            dt.Columns.Add("Ratio3");
            dt.Columns.Add("Ratio4");
            dt.Columns.Add("Ratio5");
            dt.Columns.Add("Ratio6");
            dt.Columns.Add("Ratio7");
            dt.Columns.Add("Ratio8");
            dt.Columns.Add("Ratio9");
            dt.Columns.Add("Ratio10");
            dt.Columns.Add("Ratio11");

            dt.Columns.Add("RatioPack");
            dt.Columns.Add("TotalSingles");
            dt.Columns.Add("TotalRatioPack");

            List<DataTable> datatableColection = new List<DataTable>();

            dt.PrimaryKey = new DataColumn[] { dt.Columns["ProductionPlanningID"] };

            foreach (PackingDistribution objPackingDistribution in objPackingDistributionList)
            {
                DataRow dr = dt.Rows.Find(objPackingDistribution.ProductionPlanningID);

                if (null == dr)
                {
                    int totalSingles = 0;
                    int totalRatioPack = 0;
                    int ratioPack = 0;

                    dr = dt.NewRow();

                    dr["ProductionPlanningID"] = objPackingDistribution.ProductionPlanningID;
                    dr["OrderDetailID"] = objPackingDistribution.OrderDetailID;
                    dr["PackingID"] = PackingId;
                    dr["LineItemNumber"] = objPackingDistribution.LineItemNumber;
                    dr["ContractNumber"] = objPackingDistribution.ContractNumber;
                    dr["StyleNumber"] = objPackingDistribution.StyleNumber;
                    dr["FabricColor"] = objPackingDistribution.FabricColor;
                    dr["Item"] = objPackingDistribution.Item;
                    dr["Fabric"] = objPackingDistribution.Fabric;
                    dr["Quantity"] = objPackingDistribution.Quantity;
                    dr["ShippingQuantity"] = objPackingDistribution.ShippingQuantity;


                    PackingDistribution objPld = objPacking.Distributions.Find(delegate(PackingDistribution p) { return (p.ProductionPlanningID == objPackingDistribution.ProductionPlanningID); });
                    int counter = 0;

                    foreach (OrderDetailSizes packingSize in objPld.PackingSizes)
                    {
                        if (counter == 12)
                            break;
                        dr["Size" + counter] = packingSize.Size;
                        dr["SizeQuantity" + counter] = packingSize.Quantity;
                        dr["Singles" + counter] = packingSize.Singles.Value;
                        dr["Ratio" + counter] = packingSize.Ratio.Value;

                        ratioPack += packingSize.Ratio.Value;
                        totalSingles += packingSize.Singles.Value;
                        totalRatioPack += packingSize.RatioPack.Value;
                        counter++;
                    }

                    for (int i = 0; i < 12; i++)
                    {
                        if (dr["Size" + i] is System.DBNull)
                        {
                            dr["Size" + i] = string.Empty;
                        }

                        if (dr["SizeQuantity" + i] is System.DBNull)
                        {
                            dr["SizeQuantity" + i] = string.Empty;
                        }

                        if (dr["Singles" + i] is System.DBNull)
                        {
                            dr["Singles" + i] = string.Empty;
                        }
                    }

                    dr["RatioPack"] = ratioPack;
                    dr["TotalSingles"] = totalSingles;
                    dr["TotalRatioPack"] = totalRatioPack;

                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        #endregion
    }
}
