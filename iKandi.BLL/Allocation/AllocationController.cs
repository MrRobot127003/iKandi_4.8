using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using System.Web.Security;
using iKandi.BLL.Security;
using System.Data;

namespace iKandi.BLL
{
    public class AllocationController : BaseController
    {
        #region Ctor

        public AllocationController()
        {
        }

        public AllocationController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public bool SaveProductionUnit(ProductionUnit objProductionUnit)
        {
            return this.AllocationDataProviderInstance.SaveProductionUnit(objProductionUnit);
        }

        public bool DeleteProductionUnit(int productionUnitId)
        {
            return this.AllocationDataProviderInstance.DeleteProductionUnit(productionUnitId);
        }

        public int DeleteProductionUnit_ByUnitId(int productionUnitId)
        {
            return this.AllocationDataProviderInstance.DeleteProductionUnit_ByUnitId(productionUnitId);
        }

        public ProductionUnitCollection GetProductionUnits(string SearchTxt)
        {
            return this.AllocationDataProviderInstance.GetProductionUnits(SearchTxt);
        }

        public AllocationCollection GetAllocationData()
        {
            return this.AllocationDataProviderInstance.GetAllocationData();
        }

        public bool UpdateOrderDetailWithAllocationData(int[] orderDetailIds, int[] productionUnitIds, int[] allocatedIds,
            string[] fabricDetails, string[] accessoriesDetails, string[] cuttingDetails, bool isReallocated)
        {
            bool success = this.AllocationDataProviderInstance.UpdateOrderDetailWithAllocationData(orderDetailIds, productionUnitIds, allocatedIds);

            int i = 0;
            foreach (int orderDetailId in orderDetailIds)
            {
                try
                {
                    iKandi.Common.Order objOrder = this.OrderDataProviderInstance.GetOrderByOrderDetailId(orderDetailIds[0]);

                    OrderDetail orderDetail = objOrder.OrderBreakdown.Find(delegate(OrderDetail od) { return od.OrderDetailID == orderDetailIds[0]; });

                    // Update workflow
                    WorkflowInstance instance = this.WorkflowControllerInstance.GetInstance(-1, -1, orderDetailId);
                    List<WorkflowInstanceDetail> tasks = this.WorkflowControllerInstance.GetUserTasks(this.LoggedInUser.UserData.UserID, instance.WorkflowInstanceID);

                    if (isReallocated)
                        this.NotificationControllerInstance.Allocated(objOrder, orderDetailId, productionUnitIds[i], fabricDetails[i],
                            accessoriesDetails[i], cuttingDetails[i], isReallocated, true);

                    foreach (WorkflowInstanceDetail task in tasks)
                    {
                        if (task.StatusModeID == (int)StatusMode.ALLOCATED && task.ApplicationModule.ApplicationModuleID == (int)AppModule.ALLOCATION_FORM)
                        {
                            this.WorkflowControllerInstance.CompleteTask(task, this.LoggedInUser.UserData.UserID);
                            if (this.WorkflowControllerInstance.IscheckInlinetask((int)StatusMode.STCUNALLOCATED, instance.WorkflowInstanceID) == true)
                            {
                               // this.WorkflowControllerInstance.CreateTask(StatusMode.INLINECUT, instance.WorkflowInstanceID, orderDetail.ExFactory.AddDays(-25));
                            }
                            else
                            {
                                this.WorkflowControllerInstance.OnlyAllocationUpdateTask(task, 0);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.NotificationControllerInstance.SendErrorEmail(ex.Message + "\n" + ex.StackTrace);
                }

                i++;
            }

            return success;
        }

        public AllocationHistoryCollection GetAllocationHistory(int productionUnitId)
        {
            return this.AllocationDataProviderInstance.GetAllocationHistory(productionUnitId);
        }

        public AllocationCollection GetAllocationSummary(DateTime AllocationDate)
        {
            return this.AllocationDataProviderInstance.GetAllocationSummary(AllocationDate);
        }

        public AllocationCollection AllocatedUnitData()
        {
            return this.AllocationDataProviderInstance.AllocatedUnitData();
        }
        
     
        public DataTable GetReAllocation()
        {
            return this.AllocationDataProviderInstance.GetReAllocation();
        }
      
        public int UploadfileProductionUnit(int ProductionID, string fileName,string flag)
        {
            return this.AllocationDataProviderInstance.UploadfileProductionUnit(ProductionID,fileName,flag);
        }

       


        //added by abhishek 4/12/2015
        public int InserUpdateUserProduction(int Unitid, int Linedesignation, int UserId)
        {
            return this.AllocationDataProviderInstance.InserUpdateUserProduction(Unitid, Linedesignation,UserId);
        }
        public DataTable GetSaveProductionDesignation(int unitid,int desigID)
        {
            return this.AllocationDataProviderInstance.GetSaveProductionDesignation(unitid, desigID);
        }
        //end by abhishek 4/12/2015


    }


}
