using System;
using System.Collections.Generic;
using System.Data;
using iKandi.Common;
using System.Data.SqlClient;

namespace iKandi.BLL
{
    public class OrderPlaceController : BaseController
    {
        public OrderPlaceController()
        {
        }
        public OrderPlaceController(SessionInfo loggedInUser)
            : base(loggedInUser)
        {
        }

        public int StyleExistForThisClient(int OrderId, string StyleNumber)
        {
            return OrderPlaceDataProviderInstance.StyleExistForThisClient(OrderId, StyleNumber);
        }

        public OrderPlace GetOrderInfoByStyleNumber(string styleNumber)
        {
            return OrderPlaceDataProviderInstance.GetOrderInfoByStyleNumber(styleNumber);
        }
        public OrderPlace Get_order_by_OrderId_ForOrderPlace(int OrderID, int UserId)
        {
            return OrderPlaceDataProviderInstance.Get_order_by_OrderId_ForOrderPlace(OrderID, UserId);
        }

        public List<OrderPlace> Get_modes_For_OrderPlace(bool IsikandiClient, int CostingId, int ClientId, int DepartmentID, int OrderDetailId)
        {
            return OrderPlaceDataProviderInstance.Get_modes_For_OrderPlace(IsikandiClient, CostingId, ClientId, DepartmentID, OrderDetailId);
        }

        public ContractDetails Get_ModeDetails_ByModeId(bool IsikandiClient, int CostingId, int ClientId, int DepartmentID, int ModeId)
        {
            return OrderPlaceDataProviderInstance.Get_ModeDetails_ByModeId(IsikandiClient, CostingId, ClientId, DepartmentID, ModeId);
        }

        public int OpenOrderForikandi(int OrderId, int IsClose)
        {
            return OrderPlaceDataProviderInstance.OpenOrderForikandi(OrderId, IsClose);
        }

        public string DeleteOrderDetail(int OrderDetailId, int UserId)
        {
            return OrderPlaceDataProviderInstance.DeleteOrderDetail(OrderDetailId, UserId);
        }
        public List<string> GetAllPrintNumber(string searchValue, int ClientId, int PrintCategory)
        {
            return OrderPlaceDataProviderInstance.GetAllPrintNumber(searchValue, ClientId, PrintCategory);
        }

        public int CheckAccessories(string searchValue)
        {
            return OrderPlaceDataProviderInstance.CheckAccessories(searchValue);
        }

        public List<ContractDetailAccessories> Get_Accessories_Section_OrderPlace(int OrderId)
        {
            return OrderPlaceDataProviderInstance.Get_Accessories_Section_OrderPlace(OrderId);
        }

        public bool Delete_Accessories_OrderPlace(Int64 AccId, int UserId)
        {
            return OrderPlaceDataProviderInstance.Delete_Accessories_OrderPlace(AccId, UserId);
        }

        public bool Insert_Update_Accessories(List<ContractDetailAccessories> ContractDetailAccess, int OrderId, int OrderDetailId, int UserId)
        {
            return OrderPlaceDataProviderInstance.Insert_Update_Accessories(ContractDetailAccess, OrderId, OrderDetailId, UserId);
        }

        public List<ContractDetailSize> GetSizeSetDetails(int ClientId, int DeptId, int OptionId, int OrderDetailId)
        {
            DataSet ds = OrderPlaceDataProviderInstance.GetSizeSetDetails(ClientId, DeptId, OptionId, OrderDetailId);
            List<ContractDetailSize> orderDetailSizeCollection = new List<ContractDetailSize>();
            if (OptionId == 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow d in dt.Rows)
                {
                    ContractDetailSize orderDetailSize = new ContractDetailSize();
                    orderDetailSize.SizeOption = d["SizeOption"] == DBNull.Value ? 0 : Convert.ToInt32(d["SizeOption"]);
                    orderDetailSize.OrderSizeOption = d["OrderSizeOption"] == DBNull.Value ? 0 : Convert.ToInt32(d["OrderSizeOption"]);
                    orderDetailSizeCollection.Add(orderDetailSize);
                }
            }
            else if (OptionId > 0)
            {
                DataTable dt = ds.Tables[1];
                foreach (DataRow d in dt.Rows)
                {
                    ContractDetailSize orderDetailSize = new ContractDetailSize();
                    orderDetailSize.SizeOption = d["SizeOption"] == DBNull.Value ? 0 : Convert.ToInt32(d["SizeOption"]);
                    orderDetailSize.Size = d["Size"] == DBNull.Value ? "" : Convert.ToString(d["Size"]);
                    orderDetailSize.OrderDetailSizeID = d["OrderDetailSizeID"] == DBNull.Value ? 0 : Convert.ToInt32(d["OrderDetailSizeID"]);
                    orderDetailSize.Singles = d["Singles"] == DBNull.Value ? 0 : Convert.ToInt32(d["Singles"]);
                    orderDetailSize.Ratio = d["Ratio"] == DBNull.Value ? 0 : Convert.ToInt32(d["Ratio"]);
                    orderDetailSize.RatioPack = d["RatioPack"] == DBNull.Value ? 0 : Convert.ToInt32(d["RatioPack"]);
                    orderDetailSize.Quantity = d["Quantity"] == DBNull.Value ? 0 : Convert.ToInt32(d["Quantity"]);
                    orderDetailSizeCollection.Add(orderDetailSize);
                }
                //orderDetailSizeCollection = orderDetailSizeCollection.FindAll(delegate(ContractDetailSize cds)
                //{
                //    return cds.SizeOption == OptionId;
                //});
            }

            return orderDetailSizeCollection;

        }

        public bool Insert_Update_OrderDetail_Size(ContractDetailSize orderDetailSize, int UserId)
        {
            return OrderPlaceDataProviderInstance.Insert_Update_OrderDetail_Size(orderDetailSize, UserId);
        }

        public List<OrderHistory> Get_Order_History(int OrderId, int Typeflag)
        {
            return OrderPlaceDataProviderInstance.Get_Order_History(OrderId, Typeflag);
        }

        //added by raghvinder on 07-12-2020 start

        public bool IsOldHistoryCommentsValid(int OrderId)
        {
            return OrderPlaceDataProviderInstance.IsOldHistoryCommentsValid(OrderId);
        }

        public List<OrderOldHistoryComments> Get_Old_Order_History(int OrderId, int Typeflag, int Type)
        {
            return OrderPlaceDataProviderInstance.Get_Old_Order_History(OrderId, Typeflag, Type);
        }
        //added by raghvinder on 07-12-2020 end


        public bool Create_Order_Comment(OrderComment ordercomment, int User)
        {
            return OrderPlaceDataProviderInstance.Create_Order_Comment(ordercomment, User);
        }

        public List<OrderComment> Get_Order_Comment(int OrderId, string SerialNo, int Typeflag)
        {
            return OrderPlaceDataProviderInstance.Get_Order_Comment(OrderId, SerialNo, Typeflag);
        }

        public List<ClientCountryCode> GetClientCountryCode(int ClientId)
        {
            return OrderPlaceDataProviderInstance.GetClientCountryCode(ClientId);
        }

        public List<DeliveryMode> GetLeadTime_Days_ByMode(int ModeID, string CountryCode)
        {
            return OrderPlaceDataProviderInstance.GetLeadTime_Days_ByMode(ModeID, CountryCode);
        }

        public List<AccessoryPending> GetOrderAccesoryHistory(int OrderId)
        {
            return this.OrderPlaceDataProviderInstance.GetOrderAccesoryHistory(OrderId);
        }

        public bool AddOrder(iKandi.Common.OrderPlace order, int UserId, ref bool bCheckOrder, ref int NewOrderId, ref int AfterUpdation, int IsRepeatWithChanges)
        {
            bool bCheckAutoAllocation = false;
            bool bCheckUpdateRepeatOrder = false;
            if (order.OrderID == -1)
            {
                bool success = OrderPlaceDataProviderInstance.InsertOrder(order, UserId, ref NewOrderId, IsRepeatWithChanges);
                try
                {
                    if (success)
                    {
                        foreach (ContractDetails orderDetail in order.ContractDetail)
                        {
                            if (orderDetail.OrderDetailId > 0)
                            {
                                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailId, TaskMode.NEW_ORDER, UserId);
                            }
                        }

                        bCheckAutoAllocation = OrderPlaceDataProviderInstance.AutoAllocation_ReallocationOrder(order.OrderID);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
                return success;
            }
            else
            {
                bool success = OrderPlaceDataProviderInstance.UpdateOrder(order, UserId, ref bCheckOrder, ref AfterUpdation);
                int Sno = 0;
                try
                {
                    if (success)
                    {
                        foreach (ContractDetails orderDetail in order.ContractDetail)
                        {
                            if (orderDetail.isSplitted == 1 && orderDetail.isSplit == 0)
                            {
                                Sno = 1;
                                bool success1 = OrderPlaceDataProviderInstance.SplitOrder(order.OrderID, orderDetail.OrderDetailId, orderDetail.OrderDetailId, UserId, orderDetail.sortType, Sno);
                                if (success1 == false)
                                    return false;
                            }
                            if (orderDetail.isSplitted == 1 && orderDetail.isSplit == 1)
                            {
                                Sno += 1;
                                bool success1 = OrderPlaceDataProviderInstance.SplitOrder(order.OrderID, orderDetail.OrderDetailId, orderDetail.OrderDetailId_Ref, UserId, orderDetail.sortType, Sno);
                                if (success1 == false)
                                    return false;
                            }
                            if ((orderDetail.PoUpload1 != "") || (orderDetail.PoUpload2 != ""))
                            {
                                UpdatePOUploadTask(orderDetail.OrderDetailId, UserId);
                            }

                            bCheckAutoAllocation = OrderDataProviderInstance.Update_AutoAllocationFactoryUnit_InOrder(order.OrderID);

                            WorkflowInstance instance = WorkflowControllerInstance.GetInstance(order.StyleID, order.OrderID, orderDetail.OrderDetailId);

                            if (instance == null || instance.WorkflowInstanceID <= 0)
                            {
                                if (orderDetail.OrderDetailId > 0 && orderDetail.isDeleted == 0)
                                {
                                    instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailId, TaskMode.NEW_ORDER, UserId);
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            //this.WorkflowControllerInstance.DeleteUnnessaryFits_UploadComentesTask(order.StyleID, TaskMode.HandOver);
                            this.WorkflowControllerInstance.DeleteUnnessaryFits_UploadComentesTask(order.StyleID, TaskMode.Pattern_Ready);
                            this.WorkflowControllerInstance.DeleteUnnessaryFits_UploadComentesTask(order.StyleID, TaskMode.Fits_SampleSent);
                            this.WorkflowControllerInstance.DeleteUnnessaryFits_UploadComentesTask(order.StyleID, TaskMode.FitsCommentes_Upload);

                            if (order.ApprovedBySalesBIPL >= 1)
                            {
                                instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailId, TaskMode.ORDER_CONFIRMED_SALES, UserId);
                            }
                            if (order.ApprovedByMerchandiserManager >= 1)
                            {
                                instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailId, TaskMode.ORDER_CONFIRMED_MERCHANT, UserId);
                            }
                            if (order.ApprovedByFabricManager >= 1)
                            {
                                instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailId, TaskMode.Fill_Fabric, UserId);
                            }
                            if (order.ApprovedByAccessoryManager >= 1)
                            {
                                instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailId, TaskMode.Fill_Accessories, UserId);
                            }

                            if ((order.ApprovedByAccessoryManager >= 1) && (order.ApprovedByFabricManager >= 1))
                            {
                                WorkflowControllerInstance.Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(order.OrderID, orderDetail.OrderDetailId, TaskMode.WORKINGS_CREATED, UserId);
                            }

                            int CurrentStatus = WorkflowControllerInstance.Workflow_get_current_Status(order.StyleID, order.OrderID, orderDetail.OrderDetailId);
                            if (CurrentStatus == 77)
                            {
                                bCheckUpdateRepeatOrder = OrderDataProviderInstance.UpdateWorkflow_RepeatOrder(order.OrderID, order.StyleID);
                            }
                        }

                        this.WorkflowControllerInstance.SplitOrder_FromOrderID(order.OrderID);

                        //------------------------------ ADD FOR Update Reduce Order Qty -------------------------------------
                        int save = OrderPlaceDataProviderInstance.Update_Accessory_Order_Qty_ByOrderId(order.OrderID);

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

        public int UpdatePOUploadTask(int POorderdetailID, int UserID)
        {
            return OrderDataProviderInstance.UpdatePOUploadTask(POorderdetailID, UserID);
        }

    }
}
