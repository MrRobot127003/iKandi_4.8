using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.DAL;
using iKandi.Common;
using System.Data;
namespace iKandi.BLL
{
    public class AccessoryWorkingController : BaseController
    {
        #region Constructor

        public AccessoryWorkingController()
        {
        }

        public AccessoryWorkingController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public AccessoryWorking InsertAccessoryWorking(iKandi.Common.AccessoryWorking accessoryWorking)
        {
            AccessoryWorking awSheet = this.AccessoryWorkingDataProviderInstance.CreateAccessoryWorking(accessoryWorking);
            if (awSheet.Id > 0)
            {
                iKandi.Common.Order order = this.OrderDataProviderInstance.GetOrderById(accessoryWorking.Order.OrderID);
                foreach (OrderDetail orderDetail in order.OrderBreakdown)
                {
                    if (orderDetail.OrderDetailID > 0)
                    {
                        WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Create_Accessories, this.LoggedInUser.UserData.UserID);
                        if (accessoryWorking.ApprovedByAccountManager > 0)
                            instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Accessory_Approved, this.LoggedInUser.UserData.UserID);
                    }
                }
            }
            return awSheet;
        }

        public AccessoryWorking UpdateAccessoryWorking(iKandi.Common.AccessoryWorking accessoryWorking, string diff)
        {
            AccessoryWorking awSheet = this.AccessoryWorkingDataProviderInstance.UpdateAccessoryWorking(accessoryWorking, diff);
            if (awSheet.Id > 0 && accessoryWorking.ApprovedByAccountManager > 0)
            {
                //TODO: Heaving call, avoid it
                iKandi.Common.Order order = this.OrderDataProviderInstance.GetOrderById(accessoryWorking.Order.OrderID);
                foreach (OrderDetail orderDetail in order.OrderBreakdown)
                {
                    if (orderDetail.OrderDetailID > 0)
                    {
                        WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Accessory_Approved, this.LoggedInUser.UserData.UserID);
                        instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Create_Accessories, this.LoggedInUser.UserData.UserID);
                        int iResult = WorkflowControllerInstance.Usp_UpdateWorkflowTask_PostOrder_WorkingCreated_Live_Approved_toEx(order.OrderID, orderDetail.OrderDetailID, TaskMode.WORKINGS_CREATED, this.LoggedInUser.UserData.UserID);
                    }
                }
            }
            if (accessoryWorking.ApprovedByAccessoryManager > 0)
            {
                //TODO: Heaving call, avoid it
                iKandi.Common.Order order = this.OrderDataProviderInstance.GetOrderById(accessoryWorking.Order.OrderID);
                foreach (OrderDetail orderDetail in order.OrderBreakdown)
                {
                    if (orderDetail.OrderDetailID > 0)
                    {
                        WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Accessory_Approved, this.LoggedInUser.UserData.UserID);
                    }
                }
            }
            return awSheet;
        }

        public List<Accessory> GetAllAccessory(Int32 OrderID)
        {
            return this.AccessoryWorkingDataProviderInstance.GetAllAccessory(OrderID);
        }
        public DataSet GetAllAccessoryDetails(int OrderID, int AccessoriesWorkingId, string session)
        {
            return AccessoryWorkingDataProviderInstance.GetAllAccessory(OrderID, AccessoriesWorkingId, session);
        }

        // add by sushil on date 27/3/2015
        public DataSet Getfabrictooltip(int orderID)
        {
            return AccessoryWorkingDataProviderInstance.Getfabrictooltip(orderID);
        }
        //END  by sushil on date 27/3/2015
        public void GetCountAccesoriesDetails(int OrderID, int AccessoriesWorkingId, int iCount, string session1)
        {
            AccessoryWorkingDataProviderInstance.GetCountAccesoriesDetails(OrderID, AccessoriesWorkingId, iCount, session1);
        }
        public void DropUserSessions(string sessiontable)
        {
            AccessoryWorkingDataProviderInstance.DropUserSessions(sessiontable);
        }
        public DataSet GetAllAccessoryDetailsCompleteData(int orderid, int AccessoriesWorkingId, string session3)
        {
            return AccessoryWorkingDataProviderInstance.GetAllAccessoryDetailsCompleteData(orderid, AccessoriesWorkingId, session3);
        }
        public AccessoryWorking GetAccessoryWorking(Int32 orderID)
        {
            return this.AccessoryWorkingDataProviderInstance.GetAccessoryWorking(orderID);
        }
        public AccessoryWorkingDetail GetAccessoryWorkingDetailByID(int AccessoryWorkingDetailID)
        {
            return this.AccessoryWorkingDataProviderInstance.GetAccessoryWorkingDetailByID(AccessoryWorkingDetailID);
        }
        public DataSet GetOrderQuantity(int orderid)
        {
            return AccessoryWorkingDataProviderInstance.GetOrderQuantity(orderid);
        }

        public List<AccessoryPending> Get_AccessoryPending_Orders(int OrderID, int AccessoryMasterId, string Size, string ColorPrint, string Searchtext)
        {
            return this.AccessoryQualityDataProviderInstance.Get_AccessoryPending_Orders(OrderID, AccessoryMasterId, Size, ColorPrint, Searchtext);
        }

        public AccessoryPending Update_AccessoryPending_Orders(int OrderDetailID, int AccessoryworkingdetailId, int Stage1, int Stage2, int UserId)
        {
            return this.AccessoryQualityDataProviderInstance.Update_AccessoryPending_Orders(OrderDetailID, AccessoryworkingdetailId, Stage1, Stage2, UserId);
        }

        public List<AccessoryPending> GetAccessory_Supplier_Quotation(int UserID, string Searchtxt, int type)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_Supplier_Quotation(UserID, Searchtxt, type);
        }

        public DataSet GetAccessory_Supplier_QuotationDetails(int UserID, string Searchtxt, int type, string SearchType)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_Supplier_QuotationDetails(UserID, Searchtxt, type, SearchType);
        }
        public List<AccessoryPending> GetAccessory_PoDetails_Supplier_Quotation(int SupplierID, int AccessoryMasterId, string Size, string ColorPrint, int type)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_PoDetails_Supplier_Quotation(SupplierID, AccessoryMasterId, Size, ColorPrint, type);
        }
     
        public int Save_Accessory_Supplier_Quotation(int SupplierID, int AccessoryMasterId, string Size, string ColorPrint, double QuotedLandedRate, int UserId, int type)
        {
            return this.AccessoryQualityDataProviderInstance.Save_Accessory_Supplier_Quotation(SupplierID, AccessoryMasterId, Size, ColorPrint, QuotedLandedRate, UserId, type);
        }

        public int UpdateAccessoryRemarks(string Po_Number, string CommentRemarks, int Userid)
        {
            return this.AccessoryQualityDataProviderInstance.UpdateAccessoryRemarks(Po_Number, CommentRemarks, Userid);
        }


        public List<AccessoryPending> GetAccessory_SupplierCode(int AccessoryMasterId, string Size, string ColorPrint, int SupplierId, int AccessoryType)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_SupplierCode(AccessoryMasterId, Size, ColorPrint, SupplierId, AccessoryType);
        }



        public List<AccessoryPending> GetAccessory_OrderPlacement(int UserID, int type, string Searchtxt)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_OrderPlacement(UserID, type, Searchtxt);
        }

        public DataSet GetAccessory_Supplier_OrderPlacement(int AccessoryMasterId, string Size, string ColorPrint, int type)
        {
            return AccessoryQualityDataProviderInstance.GetAccessory_Supplier_OrderPlacement(AccessoryMasterId, Size, ColorPrint, type);
        }
        public List<AccessoryPending> GetAccessory_SupplierDetails(int AccessoryMasterId, string Size, string ColorPrint, int AccessoryType)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_SupplierDetails(AccessoryMasterId, Size, ColorPrint, AccessoryType);
        }
        public List<AccessoryPending> GetAccessory_ListedSupplier(int AccessoryMasterId, string Size, string ColorPrint, int AccessoryType)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_ListedSupplier(AccessoryMasterId, Size, ColorPrint, AccessoryType);
        }
        public List<AccessoryPending> GetAccessory_SupplierPurchaseOrder(int AccessoryMasterId, string Size, string ColorPrint, int SupplierPO_Id, int AccessoryType)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_SupplierPurchaseOrder(AccessoryMasterId, Size, ColorPrint, SupplierPO_Id, AccessoryType);
        }
        //shubhendu
        public DataSet GetAccessoryRemarks(string PO_Number)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessoryRemarks(PO_Number);
        }

        public DataSet GetAccessory_SupplierPurchase_Eta_History(int SupplierPO_Id, int AccessoryType)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_SupplierPurchase_Eta_History(SupplierPO_Id, AccessoryType);
        }
        public int SaveAccessory_PurchaseOrder(AccessoryPending objAccessoryPurchase, int AccessoryType, int UserId)
        {
            return this.AccessoryQualityDataProviderInstance.SaveAccessory_PurchaseOrder(objAccessoryPurchase, AccessoryType, UserId);
        }
        public List<AccessoryPending> GetAccessory_SupplierPO_DETAILS(int AccessoryMasterId, string Size, string ColorPrint, int AccessoryType)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_SupplierPO_DETAILS(AccessoryMasterId, Size, ColorPrint, AccessoryType);
        }
        public int Delete_AccessoryPO(int SupplierPoId)
        {
            return this.AccessoryQualityDataProviderInstance.Delete_AccessoryPO(SupplierPoId);
        }
        public List<AccessoryPending> GetRaisedPO_AccessoryWorking(int SupplierPoId, int OrderDetailid, string Searchtxt, int Status, string type, int DropDownType = 1)
        {
            return this.AccessoryQualityDataProviderInstance.GetRaisedPO_AccessoryWorking(SupplierPoId, OrderDetailid, Searchtxt, type, Status, DropDownType);
        }
        public List<AccessorySRV> GetRaisedPO_SRV_Detail(int SupplierPoId, string type)
        {
            return this.AccessoryQualityDataProviderInstance.GetRaisedPO_SRV_Detail(SupplierPoId, type);
        }
        public AccessorySRV Get_AccessorySRV(int SupplierPoId, int SrvId)
        {
            return this.AccessoryQualityDataProviderInstance.Get_AccessorySRV(SupplierPoId, SrvId);
        }
        public List<Accessory_Srv_Bill> GetAccessory_Srv_BillDetail(int SupplierPoId, int PartyBillId)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_Srv_BillDetail(SupplierPoId, PartyBillId);
        }
        public int SaveAccessory_Srv(AccessorySRV objAccessorySRV, int UserId)
        {
            return this.AccessoryQualityDataProviderInstance.SaveAccessory_Srv(objAccessorySRV, UserId);
        }
        public AccessoryDebitNoteCls Get_AccessoryDebitNote(int SupplierPoId, int DebitNoteId, int PartyBillId)
        {
            return this.AccessoryQualityDataProviderInstance.Get_AccessoryDebitNote(SupplierPoId, DebitNoteId, PartyBillId);
        }
        public List<AccessoryDebitNoteCls> GetAccessoryDebitNoteList(int SupplierPoId, string Searchtxt)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessoryDebitNoteList(SupplierPoId, Searchtxt);
        }
        public List<Accessory_Srv_Bill> GetAccessory_Srv_Bill_DropDownList(int SupplierPoId, int DebitNoteId)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_Srv_Bill_DropDownList(SupplierPoId, DebitNoteId);
        }
        public int Save_Accessory_DebitNote(AccessoryDebitNoteCls objAccessoryDebitNote, int UserId)
        {
            return this.AccessoryQualityDataProviderInstance.Save_Accessory_DebitNote(objAccessoryDebitNote, UserId);
        }
        public int Update_Accessory_DebitNotePartyCulars(AccessoryDebitNoteParticulars objDebitNoteParticulars, int UserId, string type)
        {
            return this.AccessoryQualityDataProviderInstance.Update_Accessory_DebitNotePartyCulars(objDebitNoteParticulars, UserId, type);
        }
        public AccessoryChallanCls Get_AccessoryChallan(int SupplierPoId, int DebitNoteId, int ChallanId)
        {
            return this.AccessoryQualityDataProviderInstance.Get_AccessoryChallan(SupplierPoId, DebitNoteId, ChallanId);
        }
        public List<ChallanProcess> GetChallanProcessList(int ChallanId)
        {
            return this.AccessoryQualityDataProviderInstance.GetChallanProcessList(ChallanId);
        }

        public DataTable GetChallanProcessListForPdf(int ChallanId)
        {
            return this.AccessoryQualityDataProviderInstance.GetChallanProcessListForPdf(ChallanId);
        }

        public List<GroupUnit> GetGroupUnitList()
        {
            return this.AccessoryQualityDataProviderInstance.GetGroupUnitList();
        }
        public int Save_Accessory_Challan(AccessoryChallanCls objAccessoryChallanCls, int UserId)
        {
            return this.AccessoryQualityDataProviderInstance.Save_Accessory_Challan(objAccessoryChallanCls, UserId);
        }






        //To Save Accessory Internal Challan Start : Girish
        public Boolean Save_Accessory_Internal_Challan(SaveAccessoryInternalChallan SaveAccessoryInternalChallan, int UserId)
        {
            return this.AccessoryQualityDataProviderInstance.Save_Accessory_Internal_Challan(SaveAccessoryInternalChallan, UserId);
        }
        //To Save Accessory Internal Challan End


        //To Get ChallanNumber For AccessoryInternalChallan Start: Girish
        public DataTable GetChallanNumberForAccessoryInternalChallan(int OrderID)
        {
            return this.AccessoryQualityDataProviderInstance.GetChallanNumberForAccessoryInternalChallan(OrderID);
        }
        //To Get ChallanNumber For AccessoryInternalChallan End


        //To Get BasicDetails For AccessoryInternal Challan Start:Girish
        public DataTable GetBasicDetailsForAccessoryInternalChallan(string SerialNumber,string ChallanNumber)
        {
            return this.AccessoryQualityDataProviderInstance.GetBasicDetailsForAccessoryInternalChallan(SerialNumber,ChallanNumber);
        }
        //To Get BasicDetails For AccessoryInternal Challan:End


        //GetBasicDetailsForAccessoryInternalChallan Start : Girish
        public DataTable GetDataForAccessoryInternalChallanGrid(string flag,string flagOption,string SerialNumber,string ChallanNumber)
        {
            return this.AccessoryQualityDataProviderInstance.GetDataForAccessoryInternalChallanGrid(flag, flagOption, SerialNumber, ChallanNumber);
        }
        //GetBasicDetailsForAccessoryInternalChallan End









        public int Delete_ChallanBreakDown(int ChallanBreakDownId)
        {
            return this.AccessoryQualityDataProviderInstance.Delete_ChallanBreakDown(ChallanBreakDownId);
        }
        public List<AccessoryCreditNoteCls> GetAccessoryCreditNoteList(int SupplierPoId, string Searchtxt)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessoryCreditNoteList(SupplierPoId, Searchtxt);
        }
        //NEW CODE ADDED 12 JAN 2021 START
        public DataTable Getbipladdress(string Name)
        {
            return this.AccessoryQualityDataProviderInstance.Getbipladdress(Name);
        }
        //NEW CODE ADDED 12 JAN 2021 END
        public List<Accessory_Srv_Bill> GetAccessory_List_Against_Debit_Bill(int SupplierPoId, int CreditNoteId, string type)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_List_Against_Debit_Bill(SupplierPoId, CreditNoteId, type);
        }
        public AccessoryCreditNoteCls Get_AccessoryCreditNote(int SupplierPoId, int CreditNoteId)
        {
            return this.AccessoryQualityDataProviderInstance.Get_AccessoryCreditNote(SupplierPoId, CreditNoteId);
        }
        public int Save_Accessory_CreditNote(AccessoryCreditNoteCls objAccessoryCreditNote, int UserId)
        {
            return this.AccessoryQualityDataProviderInstance.Save_Accessory_CreditNote(objAccessoryCreditNote, UserId);
        }
        public int Update_Accessory_CreditNotePartyCulars(AccessoryCreditNoteParticulars objCreditNoteParticulars, int UserId, string type)
        {
            return this.AccessoryQualityDataProviderInstance.Update_Accessory_CreditNotePartyCulars(objCreditNoteParticulars, UserId, type);
        }
        public DataSet GetAccessoriesInspection(int SupplierPoId, int SrvId)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessoriesInspection(SupplierPoId, SrvId);
        }
        public bool AccessoryCancel_Close_PO(int SupplierPoId, string field)
        {
            return this.AccessoryQualityDataProviderInstance.AccessoryCancel_Close_PO(SupplierPoId, field);
        }
        public AccessoriesInspect SaveAccessoriesInspection(AccessoriesInspectSystem accessoriesInspectSystem)
        {
            return this.AccessoryQualityDataProviderInstance.SaveAccessoriesInspection(accessoriesInspectSystem);
        }
        //Added by Shubhendu ‎November ‎17, ‎2021
        public DataSet FourPointCheckLabFileForAccessory(int type, int srvID, char Action, string FileName)
        {

            return this.AccessoryQualityDataProviderInstance.FourPointCheckLabFileForAccessory(type, srvID, FileName, Action);

        }
        public DataTable LabManagerChecked(int SRV_Id)
        {
            return this.AccessoryQualityDataProviderInstance.LabManagerChecked(SRV_Id);
        }

        public int SaveInspectionParticular(AccessoriesInspect accessoriesInspect)
        {
            return this.AccessoryQualityDataProviderInstance.SaveInspectionParticular(accessoriesInspect);
        }

        public void DeleteInspectionParticular(int id)
        {
            this.AccessoryQualityDataProviderInstance.DeleteInspectionParticular(id);
        }
        public DataSet GetAccessory_AMPerformanceReport(int AccworkingWorkingDetailID, int OrderDetailId)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_AMPerformanceReport(AccworkingWorkingDetailID, OrderDetailId);
        }

        public AccessoryChallanCls Get_AccessoryChallan(int ChallanId, int OrderDetailId, int AccessoryMasterId, string Size, string ColorPrint)
        {
            return this.AccessoryQualityDataProviderInstance.Get_AccessoryChallan(ChallanId, OrderDetailId, AccessoryMasterId, Size, ColorPrint);
        }

        public List<AccessoryQualityIssuing> GetAccessoriesQualityIssuing(string search, bool IsRequestPending, bool IsRequestSend, bool IsCompleteIssue, int OrderID)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessoriesQualityIssuing(search, IsRequestPending, IsRequestSend, IsCompleteIssue, OrderID);
        }

        public List<AccessoryQualityIssuing> GetChallanDetailsByOrderDetailId(int OrderDetailId, int AccessoryMasterId, string Size, string ColorPrint)
        {
            return this.AccessoryQualityDataProviderInstance.GetChallanDetailsByOrderDetailId(OrderDetailId, AccessoryMasterId, Size, ColorPrint);
        }

        public int SaveAccessoryInternalIssueSheet(AccessoryQualityIssuing accessoryIssuing)
        {
            return this.AccessoryQualityDataProviderInstance.SaveAccessoryInternalIssueSheet(accessoryIssuing);
        }

        //added by raghvinder on 23-03-2021 start
        public decimal GetAccessory_ConversionValue(int CurrentUnitId, int PreviousUnitId)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_ConversionValue(CurrentUnitId, PreviousUnitId);
        }
        //added by raghvinder on 23-03-2021 end

        //added by raghvinder on 23-10-2020 start
        public int Save_Accessory_Average(string Type, float Avg, int Unit, int OrderID, int AccWorkingDetailId, bool CheckValue, int CreatedBy)
        {
            return this.AccessoryQualityDataProviderInstance.Save_Accessory_Average(Type, Avg, Unit, OrderID, AccWorkingDetailId, CheckValue, CreatedBy);
        }
        //public int Save_Accessory_Description(string Type, string ComVal)
        //{
        //    return this.AccessoryQualityDataProviderInstance.Save_Accessory_Description(Type, ComVal);
        //}        
        //added by raghvinder on 23-10-2020 end


        public int Update_SupplierPo_PartySignature(int SupplierPoId, int IsPartySignature, int UserId)
        {
            return this.AccessoryQualityDataProviderInstance.Update_SupplierPo_PartySignature(SupplierPoId, IsPartySignature, UserId);
        }

        public AccessoryPending GetAccessory_PoDetails_Liability(int SupplierPoId, int OrderDetailId)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessory_PoDetails_Liability(SupplierPoId, OrderDetailId);
        }
        public int Save_AccessoryLiability(AccessoryPending objAccessoryPending, int UserId)
        {
            return this.AccessoryQualityDataProviderInstance.Save_AccessoryLiability(objAccessoryPending, UserId);
        }
        public DataTable GetSupplier_Type(int UserId)
        {
            return this.AccessoryQualityDataProviderInstance.GetSupplier_Type(UserId);
        }

        public int GetIssueSheetId(int OrderDetailId, int AccessoryMasterId, string ColorPrint, string Size)
        {
            return this.AccessoryQualityDataProviderInstance.GetIssueSheetId(OrderDetailId, AccessoryMasterId, ColorPrint, Size);
        }

        public DataSet GetAccessoryWastage(string flag)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessoryWastage(flag);
        }

        public DataSet GetAccessoryWastageDetails(string flag, int accessoryqualityid)
        {
            return this.AccessoryQualityDataProviderInstance.GetAccessoryWastageDetails(flag, accessoryqualityid);
        }

        public int DeleteWastage(string flag, int AccessoryQualityID, int AccessoryBarrierWastageId)
        {
            return this.AccessoryQualityDataProviderInstance.DeleteWastage(flag, AccessoryQualityID, AccessoryBarrierWastageId);
        }

        public int UpdateAccessoryWastageDetails(string flag, int AccessoryQualityID, int AccessoryBarrierWastage, int fromqty, int toqty, int solid, int print, int createdBy)
        {
            return this.AccessoryQualityDataProviderInstance.UpdateAccessoryWastageDetails(flag, AccessoryQualityID, AccessoryBarrierWastage, fromqty, toqty, solid, print, createdBy);
        }
        public DataTable GetCreditNote(int SupplierPoId, string type)
        {
            return this.AccessoryQualityDataProviderInstance.GetCreditNote(SupplierPoId, type);
        }
        public int SaveQtyLeftInStock(AccessoryQualityIssuing objQualityIssue)
        {
            return this.AccessoryQualityDataProviderInstance.SaveQtyLeftInStock(objQualityIssue);
        }
        public AccessoryChallanCls Get_AccessorySendChallan(int SupplierPoId, int ChallanId, int UserId)
        {
            return this.AccessoryQualityDataProviderInstance.Get_AccessorySendChallan(SupplierPoId, ChallanId, UserId);
        }

        //added by shubhendu on 4/05/2022
        public AccessoryGstRateTotalAmount AccessoryGstRateTotalAmount(int SupplierPoId, int challanId,string Flag)
        {
            return this.AccessoryQualityDataProviderInstance.AccessoryGstRateTotalAmount(SupplierPoId, challanId,Flag);
        }
        public DataTable Get_AccessoryUnit(int AccessoryMasterId)
        {
            return this.AccessoryQualityDataProviderInstance.Get_AccessoryUnit(AccessoryMasterId);
        }

        public DataTable Get_AccessoryUnit_ForOrder(int OrderId, int AccessoryWorkingDetailId)
        {
            return this.AccessoryQualityDataProviderInstance.Get_AccessoryUnit_ForOrder(OrderId, AccessoryWorkingDetailId);
        }
        public DataTable Get_SerailNumber_Against_PO(int MasterPOId)
        {
            return this.AccessoryQualityDataProviderInstance.Get_SerailNumber_Against_PO(MasterPOId);
        }

        //added by raghvinder on 03-11-2020 start
        public DataTable Get_FabricUnit_ForOrder(int OrderDetailID, int FabricQualityID)
        {
            return this.AccessoryQualityDataProviderInstance.Get_FabricUnit_ForOrder(OrderDetailID, FabricQualityID);
        }
        //added by raghvinder on 03-11-2020 end

        public List<AccessoryChallanCls> GetRaisedPO_Challan_Detail(int SupplierPoId, string type)
        {
            return this.AccessoryQualityDataProviderInstance.GetRaisedPO_Challan_Detail(SupplierPoId, type);
        }
        public string CheckChallanNumber(int SupplierPoId, int SRV_Id, string PartyChallanNumber)
        {
            return this.AccessoryQualityDataProviderInstance.CheckChallanNumber(SupplierPoId, SRV_Id, PartyChallanNumber);
        }
        public List<AccessoryPending> GetPOAccesoryHistory(int SupplierPOId)
        {
            return this.AccessoryQualityDataProviderInstance.GetPOAccesoryHistory(SupplierPOId);
        }
        public string Save_Accessory_Description(int OrderDetailId, string ComVal)
        {
            return this.AccessoryQualityDataProviderInstance.Save_Accessory_Description(OrderDetailId, ComVal);
        }
        public string Save_Accessory_AccessoryRemarks(int orderid, string ComVal)
        {
            return this.AccessoryQualityDataProviderInstance.Save_Accessory_AccessoryRemarks(orderid, ComVal);
        }

        public DataTable Get_AccessoryPODetail(int SupplierPoId)
        {
            return this.AccessoryQualityDataProviderInstance.Get_AccessoryPODetail(SupplierPoId);
        }
    }
}
