#region Assembly Reference

using System.Collections.Generic;
using System.Data;
using iKandi.Common;
using iKandi.Common.Entities;
using System;

#endregion

namespace iKandi.BLL
{
    public class FabricController : BaseController
    {
        public FabricController()
        {
        }

        public FabricController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        //Grade Admin Block

        public List<GradeAdmin> GetGradeAdmin(int tableId, int id)
        {
            return FabricDataProviderInstance.GetGradeAdmin(tableId, id);
        }

        public int Insert_UpdateGradeAdmin(GradeAdmin gradeAdmin)
        {
            return FabricDataProviderInstance.Insert_UpdateGradeAdmin(gradeAdmin);
        }

        public void DeleteGradeAdmin(int id, int tableId)
        {
            FabricDataProviderInstance.DeleteGradeAdmin(id, tableId);
        }

        //FACutting Block
        //NEW CODE ADDED 12 JAN 2021 START
        public DataTable Getbipladdress(string Name)
        {
            return this.FabricDataProviderInstance.Getbipladdress(Name);
        }
        //NEW CODE ADDED 12 JAN 2021 END
        public List<FACutting> GetFAForCutting(int id)
        {
            return FabricDataProviderInstance.GetFAForCutting(id);
        }

        public int Insert_UpdateFACutting(FACutting faCutting)
        {
            return FabricDataProviderInstance.Insert_UpdateFACutting(faCutting);
        }

        public void DeleteFACutting(int id)
        {
            FabricDataProviderInstance.DeleteFACutting(id);
        }

        //Four PO Type
        public List<Po_Type> GetPo_Type(int id, int requiredAdmin)
        {
            return FabricDataProviderInstance.GetPo_Type(id, requiredAdmin);
        }

        //Process
        public List<ProcessAdmin> GetProcess(int id)
        {
            return FabricDataProviderInstance.GetProcess(id);
        }

        //Supplier Tables
        public List<GradeAdmin> GetAllDrGrades()
        {
            return FabricDataProviderInstance.GetAllDrGrades();
        }

        public DataSet GetTempTaskAll()
        {
            return FabricDataProviderInstance.GetTempTaskAll();
        }

        public DataTable GetGarmentTypeBAL()
        {
            return FabricDataProviderInstance.GetGarmentType();
        }


        /// <summary>
        ///   yaten : Get FnA Task by Task Id
        /// </summary>
        /// <returns></returns>
        public DataSet GetFnATaskAllByTaskIDBAL(int TaskId)
        {
            return FabricDataProviderInstance.GetFnATaskAllByTaskIDDAL(TaskId, -1, "All");
        }

        public DataSet GetFnATaskAllByTaskIDBAL(int TaskId, int MainTaskID, string TaskName)
        {
            return FabricDataProviderInstance.GetFnATaskAllByTaskIDDAL(TaskId, MainTaskID, TaskName);
        }

        //below added by Girish on 2023-04-28
        public List<string> GetSuggestions(string q, string limit, string timestamp, int DropDownType, int POStatus,string Type)
        {
            return FabricDataProviderInstance.GetSuggestions(q, limit, timestamp, DropDownType, POStatus, Type);
        }

       
        public List<string> GeFabricNameByName(string type)
        {
            return FabricDataProviderInstance.GeFabricNameByName(type);
        }
        //26042023-RajeevS
        public List<string> SuggestFabricSupplier(string type)
        {
            return FabricDataProviderInstance.SuggestFabricSupplier(type);
        }
        public List<string> GetPONumber(string type)
        {
            return FabricDataProviderInstance.GetPONumber(type);
        }
        public List<string> GetColorPrint(string type)
        {
            return FabricDataProviderInstance.GetColorPrint(type);
        }
        //26042023-RajeevS

        public int GetStockUnitByTradeName(string tradeName)
        {
            return FabricDataProviderInstance.GetStockUnitByTradeName(tradeName);
        }

        public User_Task GetFnaTaskInfo(int id)
        {
            return FabricDataProviderInstance.GetFnaTaskInfo(id);
        }
        //Gajendra Costing
        //added by abhishek on 11.1.2018
        public DataSet GetFabricOrderPrint(int orderid, int flag, int seqid = 0, int orderdeatilID = 0)
        {
            return FabricDataProviderInstance.GetFabricOrderPrint(orderid, flag, seqid, orderdeatilID);
        }
        public void UpdateFabricPrintMarchantComments(int orderDetailID, string MarchantComents)
        {
            FabricDataProviderInstance.UpdateFabricPrintMarchantComments(orderDetailID, MarchantComents);
        }
        public DataTable GetFabricCutOrderAvg(int orderid, int flag, int OrderDetailID, int FabQualityID, string FabDetails, int fabcount = 0)
        {
            return FabricDataProviderInstance.GetFabricCutOrderAvg(orderid, flag, OrderDetailID, FabQualityID, FabDetails, fabcount);
        }

        //added by raghvinder on 10-11-2020 start
        public int FabricApproved_History(string Type, int OrderID, int CheckValue, int CreatedBy)
        {
            return this.FabricDataProviderInstance.FabricApproved_History(Type, OrderID, CheckValue, CreatedBy);
        }

        //added by raghvinder on 10-11-2020 end
        public DataSet GetFabricAvg(int OrderDetailID, int flag, int fabcount = 0)
        {
            return FabricDataProviderInstance.GetFabricAvg(OrderDetailID, flag, fabcount);
        }
        public int UpdateFabricCutprint(int OrderDetailsID, int CostingID, decimal CutAvg, string CutAvgfile, decimal OrderAvg, string CostingAvgFile, int FabCount, decimal OrderWidthValue, decimal CostWidthValue, decimal CutWidthValue, int OrderID, int CheckBoxAM, int CutAVgunit, string TextHistory)
        {
            int i = FabricDataProviderInstance.UpdateFabricCutprint(OrderDetailsID, CostingID, CutAvg, CutAvgfile, OrderAvg, CostingAvgFile, FabCount, OrderWidthValue, CostWidthValue, CutWidthValue, CheckBoxAM, CutAVgunit, TextHistory);
            //iKandi.Common.Order order = this.OrderDataProviderInstance.GetOrderById(OrderID);
            //{
            //    foreach (OrderDetail orderDetail in order.OrderBreakdown)
            //        if (orderDetail.OrderDetailID > 0)
            //        {           
            //            //if (WorkflowControllerInstance.bCheck_AllCondition_CreateFabric(orderDetail.OrderDetailID, OrderID, "Fabric_Check") == true)
            //            //{
            //            //    WorkflowControllerInstance.Create_CloseWorkflowPostOrder(OrderID, orderDetail.OrderDetailID, TaskMode.Create_Fabric, UserID);
            //            //}

            //          //  WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Create_Fabric, this.LoggedInUser.UserData.UserID);
            //            if (CheckBoxAM == 1)
            //            {
            //                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fabric_Approved, UserID);
            //                instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(order.OrderID, orderDetail.OrderDetailID, TaskMode.Fill_Fabric, UserID);
            //            }
            //        }
            //}
            return i;
        }
        //added by abhishek Fabric modual
        public DataTable getpendingFabSummary(string flag, string FabricName, string ColorPrint, int OrderID, string fabricqualityname)
        {
            return FabricDataProviderInstance.getpendingFabSummary(flag, FabricName, ColorPrint, OrderID, fabricqualityname);
        }
        public DataSet GetGriegeFabDetails(string flag)
        {
            return FabricDataProviderInstance.GetGriegeFabDetails(flag);
        }
        public DataSet GetFabricWastage(string flag)
        {
            return FabricDataProviderInstance.GetFabricWastage(flag);
        }
        public DataSet GetGriegeFabDetailsUserID(string flag, int UserID, string fabricdetails, string searchtxt, string SearchType)
        {
            return FabricDataProviderInstance.GetGriegeFabDetailsUserID(flag, UserID, fabricdetails, searchtxt, SearchType);
        }
        public DataTable GetGSTByPoNumber(string flag, int supplierpoid, int DebitNoteId)
        {
            return FabricDataProviderInstance.GetGSTByPoNumber(flag, supplierpoid, DebitNoteId);
        }
        public DataSet GetfabricViewdetails(string flag, string flagoption, int FabQualityID = 0, int SupplierCount = 0, string fabricDeatils = "", string searchtxt = "", int SupplierPO = 0, int CurrentStage = 0, int PreviousStage = 0, bool IsStylespecific = false, int StyleID = 0, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            return FabricDataProviderInstance.GetfabricViewdetails(flag, flagoption, FabQualityID, SupplierCount, fabricDeatils, searchtxt, SupplierPO, CurrentStage, PreviousStage, IsStylespecific, StyleID, stage1, stage2, stage3, stage4);
        }
        public bool updatePendingGreigeOrders(FabricGroupAdmin.FabricDetails Fabdet)
        {
            return this.FabricDataProviderInstance.updatePendingGreigeOrders(Fabdet);
        }
        public bool updatePendingGreigeOrdersProxy(string flag, string FlagOption, int QtyToOrder, int PendingQtyToOrder, int FabricQualityID, string FabricDetails)
        {
            return this.FabricDataProviderInstance.updatePendingGreigeOrdersProxy(flag, FlagOption, QtyToOrder, PendingQtyToOrder, FabricQualityID, FabricDetails);
        }
        public bool updateGreigeValue(string Flag, string FlagOption, float GreigedShrinkage, int FabricQualityID, float Isresidualshrnkpplyongerige)
        {
            return this.FabricDataProviderInstance.updateGreigeValue(Flag, FlagOption, GreigedShrinkage, FabricQualityID, Isresidualshrnkpplyongerige);
        }

        //A

        //aaaaa
        public DataSet PopulateRemarks(string po_number)
        {
            return this.FabricDataProviderInstance.PopulateRemarks(po_number);
        }

        public bool UpdateComment_ON_PO(string po_number, string CommentRemarks)
        {
            return this.FabricDataProviderInstance.UpdateComment_ON_PO(po_number, CommentRemarks);
        }
        public DataSet GetFabricpurchasedSupplier(string flag, string flagoption, int FabQualityID = 0, int FabricMasterID = 0, string potype = "", int SuppliermasterID = 0, int MasterPoID = 0, string FabricDetails = "", int CurrentStageNumber = 0, int PreviousstageNumber = 0, int styleid = 0, bool IsStyleSpecific = false, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            return FabricDataProviderInstance.GetFabricpurchasedSupplier(flag, flagoption, FabQualityID, FabricMasterID, potype, SuppliermasterID, MasterPoID, FabricDetails, CurrentStageNumber, PreviousstageNumber, styleid, IsStyleSpecific, stage1, stage2, stage3, stage4);
        }
        public bool UpdateFabricPurchasedDetails(string Flag, string FlagOption, int FabricQualityID, int SuppliermasterID, string Po_Number, System.DateTime Podate, int UserID, int ReceviedQty, float rate, System.DateTime ENDETA, int garmentunits, int sendqty, string colorprintdetail, int IsAuthSign, int IsPartySign, int IsJuniorSign, float gerige, float residual, int Currentstage, int previousstage, bool isstylespecific, int styleid, int stage1, int stage2, int stage3, int stage4, int Converttounit, float conversionvalue, string History, float cutwastage ,int RateType )
        {
            return FabricDataProviderInstance.UpdateFabricPurchasedDetails(Flag, FlagOption, FabricQualityID, SuppliermasterID, Po_Number, Podate, UserID, ReceviedQty, rate, ENDETA, garmentunits, sendqty, colorprintdetail, IsAuthSign, IsPartySign, IsJuniorSign, gerige, residual, Currentstage, previousstage, isstylespecific, styleid, stage1, stage2, stage3, stage4, Converttounit, conversionvalue, History, cutwastage,RateType );
        }
        public bool UpdateFabricPurchasedETA(string Flag, string FlagOption, System.DateTime ETAdate, int UserID, int FromQty, int ToQty, int MasterPoID, string Po_Number, int IsAuthSign, int IsPartySign, int IsJuniorSign)
        {
            return FabricDataProviderInstance.UpdateFabricPurchasedETA(Flag, FlagOption, ETAdate, UserID, FromQty, ToQty, MasterPoID, Po_Number, IsAuthSign, IsPartySign, IsJuniorSign);
        }
        public DataSet GetRaisedPOWorkingDetails(string flag, string flagoption, int SupplierPO_Id = 0, string Searchtxt = "", int status = -1, int orderdetailID = 0,int DropDownType = 1 )
        {
            return FabricDataProviderInstance.GetRaisedPOWorkingDetails(flag, flagoption, SupplierPO_Id, Searchtxt, status, orderdetailID, DropDownType);
        }

        public DataSet GetPOStatus(string flag, int SupplierPO_Id,int SrvID)
        {
            return FabricDataProviderInstance.GetPOStatus(flag,SupplierPO_Id, SrvID);
        }
        //Added by Shubhendu 9/24/2021
        public DataSet GetRaisedPOWorkingDetailsIndex(string flag, string flagoption, int PageNumber, int PageSize, int SupplierPO_Id = 0, string Searchtxt = "", int status = -1, int orderdetailID = 0)
        {
            return FabricDataProviderInstance.GetRaisedPOWorkingDetailsIndex(flag, flagoption, PageNumber, PageSize, SupplierPO_Id, Searchtxt, status, orderdetailID);
        }

        // Added by shubhendu 10/11/2021
        public DataSet FourPointCheckLabFile(int type, int SrvID, string FileName, char Action)
        {
            return FabricDataProviderInstance.FourPointCheckLabFile(type, SrvID, FileName, Action);
        }
        // Added by shubhendu 21/1/2022
        public DataSet FourPointCheckLabFileForAccessory(int type, int SrvID, string FileName, char Action)
        {
            return FabricDataProviderInstance.FourPointCheckLabFileForAccessory(type, SrvID, FileName, Action);
        }
        //Added by shubhendu 26/09/2022
        public int QuantityReallocationFabric_Accessory_FinalSattlement(int FromOrderdetailid, int ToOrderDetailsId, int FabricQualityId, string FrmFabricDetails, string ToFabricDetails, int SupplyType, int StageNumber, int PassQtyToMove, int RequiredQty, int Userid, string Flag, int AccessoryMaster_Id,string Size)
        {

            return FabricDataProviderInstance.QuantityReallocationFabric_Accessory_FinalSattlement(FromOrderdetailid, ToOrderDetailsId, FabricQualityId, FrmFabricDetails, ToFabricDetails, SupplyType, StageNumber, PassQtyToMove, RequiredQty, Userid, Flag, AccessoryMaster_Id, Size);
        }

        //Added By shubhendu 31/08/2022 

        public DataSet BindFromQuantityReallocationAcc(string TradeName, string AccSize, string colorPrint, int stage1, int stage2, int stage3, int stage4, int supplyType, string Flag, string type)
        {
            return FabricDataProviderInstance.BindFromQuantityReallocationAcc(TradeName, AccSize, colorPrint, stage1, stage2, stage3, stage4, supplyType, Flag, type);
        }
        //Added By shubhendu 31/08/2022 
        public DataSet BindFromQuantityReallocation(int FabricQualityId, string colorPrint, int stage1, int stage2, int stage3, int stage4, int supplyType, string Flag, string type)
        {
            return FabricDataProviderInstance.BindFromQuantityReallocation(FabricQualityId, colorPrint, stage1, stage2, stage3, stage4, supplyType, Flag, type);
        }
        //Added by shubhendu 14/09/2022
        public DataSet GetStageForAccFabric(string Flag)
        {
            return FabricDataProviderInstance.GetStageForAccFabric(Flag);
        }
        //Added by shubhendu 14/09/2022
        public List<string>GeFabricNameByName1(string FabricName)
        {
            return FabricDataProviderInstance.GeFabricNameByName1(FabricName);
        }
        // Added by Shubhendu 28/08/2022
        public List<string> SuggestAccessoryByName(string q, string Flag, string TradeName)
        {
            return this.AccessoryQualityDataProviderInstance.SuggestAccessoryByName(q, Flag, TradeName);
        }

        public List<string> SuggestColorPrintName(string ColorPrint, int Qualityid)
        {
            return FabricDataProviderInstance.SuggestColorPrintName(ColorPrint, Qualityid);
        }
        public DataSet GetFabFourPointCheckInsepection(string flag, int SrvID = 0, int SupplierPO_Id = 0, int FourPointCheck_Id = 0,int userid = 0)
        {
            return FabricDataProviderInstance.GetFabFourPointCheckInsepection(flag, SrvID, SupplierPO_Id, FourPointCheck_Id, userid);
        }

        public DataTable LabManagerChecked(int SRV_Id)
        {
            return this.FabricDataProviderInstance.LabManagerChecked(SRV_Id);
        }
        public DataTable Podetailsprint(string flag, string ponumber)
        {
            return this.FabricDataProviderInstance.Podetailsprint(flag, ponumber);
        }
        //public DataTable GetFabFourPointCheckUpdateBasic(int SupplierPoID, int SrvID, System.DateTime FourPointCheckDate, int AllocatedUnit, decimal ReceivedQty, decimal CheckedQty, decimal PassQty, decimal HoldQty, decimal FailQty, int CreatedBy, string Commentes, string CheckerName, int IsFabricQA, int IsCuttingQA, int IsFabricGM, int orderid, int OrderDetailID)
        //public DataTable GetFabFourPointCheckUpdateBasic(int SupplierPoID, int SrvID, System.DateTime FourPointCheckDate, int AllocatedUnit, decimal ReceivedQty, decimal CheckedQty, decimal PassQty, decimal HoldQty, decimal FailQty, int CreatedBy, int orderid, int OrderDetailID, string Commentes, int LabInternalSpecimanCount, bool InternalSentToLab, System.DateTime InternalSentToLabDate, bool InternalReceivedInLab, System.DateTime InternalReceivedInLabDate, string InternalLabReport, int LabExternalSpecimanCount, bool ExternalSentToLab, System.DateTime ExternalSentToLabDate, bool ExternalReceivedInLab, System.DateTime ExternalReceivedInLabDate, string ExternalLabReport, bool FinalDecision, decimal RaiseDebit, decimal FailStock, decimal GoodStock, string FailedParticular, decimal InspectRaiseDebit, decimal InspectUsableDebit, string InspectParticular, string CheckerName1, string CheckerName2, string CheckerName3, bool IsLabManager, bool IsFabricQA, bool IsFabricGM) 
        public DataTable GetFabFourPointCheckUpdateBasic(FabricInspectSystem fabricInspectSystem)
        {
            return this.FabricDataProviderInstance.GetFabFourPointCheckUpdateBasic(fabricInspectSystem);
            //return FabricDataProviderInstance.GetFabFourPointCheckUpdateBasic(SupplierPoID, SrvID, FourPointCheckDate, AllocatedUnit, ReceivedQty, CheckedQty, PassQty, HoldQty, FailQty, CreatedBy, orderid, OrderDetailID, Commentes, LabInternalSpecimanCount, InternalSentToLab, InternalSentToLabDate, InternalReceivedInLab, InternalReceivedInLabDate, InternalLabReport, LabExternalSpecimanCount, ExternalSentToLab, ExternalSentToLabDate, ExternalReceivedInLab, ExternalReceivedInLabDate, ExternalLabReport, FinalDecision, RaiseDebit, FailStock, GoodStock, FailedParticular, InspectRaiseDebit, InspectUsableDebit, InspectParticular, CheckerName1, CheckerName2, CheckerName3, IsLabManager, IsFabricQA, IsFabricGM);
            //return FabricDataProviderInstance.GetFabFourPointCheckUpdateBasic(SupplierPoID, SrvID, FourPointCheckDate, AllocatedUnit, ReceivedQty, CheckedQty, PassQty, HoldQty, FailQty, CreatedBy, Commentes, CheckerName, IsFabricQA, IsCuttingQA, IsFabricGM, orderid, OrderDetailID);
        }
        public DataTable GetFabFourPointCheckUpdateDelete(int FourPointCheck_Id)
        {
            return FabricDataProviderInstance.GetFabFourPointCheckUpdateDelete(FourPointCheck_Id);
        }
        //public DataTable GetFabFourPointCheckUpdateDetails(int FourPointCheck_Id, int RollNumber, int DeitLotNumber, decimal ClaimedLength, decimal ActualLength,decimal CheckedQty,decimal PassQty,decimal HoldQty,decimal FailQty, decimal Width_S, decimal Width_M, decimal Width_E, decimal Weaving_1, decimal Weaving_2, decimal Weaving_3, decimal Weaving_4, decimal Patta, decimal Hole, decimal PrintedDefectes_1, decimal PrintedDefectes_2, decimal PrintedDefectes_3, decimal PrintedDefectes_4, decimal WeaPointsPerSquirdYards, int Status)
        public DataTable GetFabFourPointCheckUpdateDetails(FabricInspect fabricInspect)
        {
            return FabricDataProviderInstance.GetFabFourPointCheckUpdateDetails(fabricInspect);
            //return FabricDataProviderInstance.GetFabFourPointCheckUpdateDetails(FourPointCheck_Id, RollNumber, DeitLotNumber, ClaimedLength, ActualLength, CheckedQty, PassQty, HoldQty, FailQty, Width_S, Width_M, Width_E, Weaving_1, Weaving_2, Weaving_3, Weaving_4, Patta, Hole, PrintedDefectes_1, PrintedDefectes_2, PrintedDefectes_3, PrintedDefectes_4, WeaPointsPerSquirdYards, Status);
        }
        //added by raghvinder on 25-09-2020 start
        public DataTable GetUnit()
        {
            return FabricDataProviderInstance.GetUnit();
        }
        //added by raghvinder on 25-09-2020 end
        public DataSet GetSupplierChallanDetails(string Flag, int SupplierPoID = 0, string ChallanType = "", int ChallanID = 0, string IsNewChallan = "", int Debitnoteid = 0,string ChallanNumber ="")
        {
            return FabricDataProviderInstance.GetSupplierChallanDetails(Flag, SupplierPoID, ChallanType, ChallanID, IsNewChallan, Debitnoteid, ChallanNumber);
        }



        public DataSet UpdateSupplierChallanDetails(string Flag, int SupplierPoID, string ChallanNumber, System.DateTime ChallanDate, string StyleNumber, string BuyerSrNumber, int UnitID, string ChallanDescription, int ThanCount, int ThanUnit, decimal TotalMeters, int IsReceived, System.DateTime ReceivedDate, int IsAuthorized, System.DateTime AuthorizedDate, int ReturnedChallanQty, int LoggedinUserID, int ChallanID, int ChallanType, int IsSendChallanNumber, int SendChallanQty, int debitnoteid, int Orderdetailid, int FabricQualityID, string printdetails, decimal gst, decimal Rate, string HSNCode,string GSTNo)
        {
            return FabricDataProviderInstance.UpdateSupplierChallanDetails(Flag, SupplierPoID, ChallanNumber, ChallanDate, StyleNumber, BuyerSrNumber, UnitID, ChallanDescription, ThanCount, ThanUnit, TotalMeters, IsReceived, ReceivedDate, IsAuthorized, AuthorizedDate, ReturnedChallanQty, LoggedinUserID, ChallanID, ChallanType, IsSendChallanNumber, SendChallanQty, debitnoteid, Orderdetailid, FabricQualityID, printdetails, gst, Rate, HSNCode,GSTNo);
        }

        public bool Update_Foc_Challan(string Flag, string IsNewChallan, string ChallanNumber, int SupplierPoID, DateTime ChallanDate, string ChallanDescription, int SendChallanQty, Decimal FocExtraPercentt, Decimal Rate, int IsReceived, int IsAuthorized, DateTime ReceivedDate, DateTime AuthorizedDate, int LoggedInUserID, int FocId, int ExternalReturnChallanQty, string FOCProcessId, string HSNcode)
        {
            return FabricDataProviderInstance.Update_Foc_Challan(Flag, IsNewChallan, ChallanNumber, SupplierPoID, ChallanDate, ChallanDescription, SendChallanQty, FocExtraPercentt, Rate, IsReceived, IsAuthorized, ReceivedDate, AuthorizedDate, LoggedInUserID, FocId, ExternalReturnChallanQty, FOCProcessId,HSNcode);
        }

        public bool Update_ExtraStockIssue_Challan(string Flag, string IsNewChallan, int SupplierPOId, string ChallanNumber, DateTime ChallanDate, string ChallanDescription, int SendChallanQty,
                                            int IsReceived, int IsAuthorized, DateTime ReceivedDate, DateTime AuthorizedDate, int LoggedInUserID, string StyleNumber, string SerialNumber, int InternalUnit,
                                            int ThanCount, string ColorPrint, int OrderDetailId, int ChallanId, int ReturnedChallanQty, int FabricQualityId, string ProcessId, string GSTNo)
        {
            return FabricDataProviderInstance.Update_ExtraStockIssue_Challan(Flag, IsNewChallan,SupplierPOId, ChallanNumber, ChallanDate, ChallanDescription, SendChallanQty
                                            , IsReceived, IsAuthorized, ReceivedDate, AuthorizedDate, LoggedInUserID, StyleNumber, SerialNumber, InternalUnit
                                            , ThanCount, ColorPrint, OrderDetailId, ChallanId, ReturnedChallanQty, FabricQualityId, ProcessId, GSTNo);
        }

        public DataSet Create_Challan_From_StockQty(string Flag, string IsNewChallan, int OrderDetailId, int FabricQualityId, string FabricDetails, string ChallanType, int ChallanID)
        {
            return FabricDataProviderInstance.Create_Challan_From_StockQty(Flag, IsNewChallan, OrderDetailId, FabricQualityId, FabricDetails, ChallanType, ChallanID);
        }


        public DataSet deletechallan(string Flag, int ChallanID, int ProcessID = 0, int SrNumber = 0, int Meter = 0, int CM = 0)
        {
            return FabricDataProviderInstance.deletechallan(Flag, ChallanID, ProcessID, SrNumber, Meter, CM);
        }


        public int updateChallanProcess(string Flag, int ChallanID, int ProcessID, string SupplierName, string SamplingGstNo, string SamplingSupplierAddress)
        {
            return FabricDataProviderInstance.updateChallanProcess(Flag, ChallanID, ProcessID, SupplierName, SamplingGstNo, SamplingSupplierAddress);
        }
        

        //get selected process for fabric challan pdf start 25-03-2021
        public DataTable GetSelectedProcessForPdf(string Flag, int ChallanID)
        {
            return FabricDataProviderInstance.GetSelectedProcessForPdf(Flag, ChallanID);
        }
        //end 25-03-2021

        public bool deletechallanbool(string Flag, int ChallanID, int ProcessID = 0, int SrNumber = 0, int Meter = 0, int CM = 0, string ChallanNumber = "")
        {
            return FabricDataProviderInstance.deletechallanbool(Flag, ChallanID, ProcessID, SrNumber, Meter, CM, ChallanNumber);
        }
        public List<FabricGroupAdmin.FabricDetailsDayed> GetFabricDayedDetailsFirst(string searchtxt, int SupplierPO = 0, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            return FabricDataProviderInstance.GetFabricDayedDetailsFirst(searchtxt, SupplierPO, stage1, stage2, stage3, stage4);
        }
        public List<FabricGroupAdmin.FabricContractDetails> GetFabricDayedDetails(int FabricQualityID, string fabricdetails, int CurrentStage, int PreviousStage, bool IsStyleSpecific, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0, int Styleid = 0)
        {
            return FabricDataProviderInstance.GetFabricDayedDetails(FabricQualityID, fabricdetails, CurrentStage, PreviousStage, IsStyleSpecific, stage1, stage2, stage3, stage4, Styleid);
        }

        public bool updateDayedValue(string Flag, string FlagOption, float GreigedShrinkage, int FabricQualityID, float ResidualShrinkage)
        {
            return FabricDataProviderInstance.updateDayedValue(Flag, FlagOption, GreigedShrinkage, FabricQualityID, ResidualShrinkage);
        }
        public bool updatePendingDayedOrders(FabricGroupAdmin.FabricDetails Fabdet)
        {
            return FabricDataProviderInstance.updatePendingDayedOrders(Fabdet);
        }
        public List<FabricGroupAdmin.FabricDetailsDayed> GetFabricPrintDetailsFirst(string searchtxt, int SupplierPO = 0, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            return FabricDataProviderInstance.GetFabricPrintDetailsFirst(searchtxt, SupplierPO, stage1, stage2, stage3, stage4);
        }
        public List<FabricGroupAdmin.FabricDetailsDayed> GetFabricRFDDetailsFirst(string searchtxt, int SupplierPO = 0, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            return FabricDataProviderInstance.GetFabricRFDDetailsFirst(searchtxt, SupplierPO, stage1, stage2, stage3, stage4);
        }

        public List<FabricGroupAdmin.FabricDetailsDayed> GetFabricEmbellishmentDetailsFirst(string searchtxt, int SupplierPO = 0, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            return FabricDataProviderInstance.GetFabricEmbellishmentDetailsFirst(searchtxt, SupplierPO, stage1, stage2, stage3, stage4);
        }
        public List<FabricGroupAdmin.FabricDetailsDayed> GetFabricEmbroideryDetailsFirst(string searchtxt, int SupplierPO = 0, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            return FabricDataProviderInstance.GetFabricEmbroideryDetailsFirst(searchtxt, SupplierPO, stage1, stage2, stage3, stage4);
        }
        public List<FabricGroupAdmin.FabricContractDetails> GetFabricPrintDetails(int FabricQualityID, string fabricdetails, int CurrentStage, int PreviousStage, bool IsStyleSpecific, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0, int StyleID = 0)
        {
            return FabricDataProviderInstance.GetFabricPrintDetails(FabricQualityID, fabricdetails, CurrentStage, PreviousStage, IsStyleSpecific, stage1, stage2, stage3, stage4, StyleID);
        }
        public List<FabricGroupAdmin.FabricContractDetails> GetFabricRFDDetails(int FabricQualityID, string fabricdetails, int CurrentStage, int PreviousStage, bool IsStyleSpecific, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0, int StyleID = 0)
        {
            return FabricDataProviderInstance.GetFabricRFDDetails(FabricQualityID, fabricdetails, CurrentStage, PreviousStage, IsStyleSpecific, stage1, stage2, stage3, stage4, StyleID);
        }
        public List<FabricGroupAdmin.FabricContractDetails> GetFabricEmbellishmentDetails(int FabricQualityID, string fabricdetails, int CurrentStage, int PreviousStage, bool IsStyleSpecific, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0, int StyleID = 0)
        {
            return FabricDataProviderInstance.GetFabricEmbellishmentDetails(FabricQualityID, fabricdetails, CurrentStage, PreviousStage, IsStyleSpecific, stage1, stage2, stage3, stage4, StyleID);
        }
        public List<FabricGroupAdmin.FabricContractDetails> GetFabricEmbroideryDetails(int FabricQualityID, string fabricdetails, int CurrentStage, int PreviousStage, bool IsStyleSpecific, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0, int StyleID = 0)
        {
            return FabricDataProviderInstance.GetFabricEmbroideryDetails(FabricQualityID, fabricdetails, CurrentStage, PreviousStage, IsStyleSpecific, stage1, stage2, stage3, stage4, StyleID);
        }
        public DataSet GetFabricIssueDetails(string Flag, int OrderDetailID, int FabQtyID, int Quality_ID, int Orderid, string search = "", string fabricdeatils = "", bool IsRequestPending = false, bool IsIssueRequest = false, bool IsCompleteIssu = false, bool IsSettlementDone = false)
        {
            return FabricDataProviderInstance.GetFabricIssueDetails(Flag, OrderDetailID, FabQtyID, Quality_ID, Orderid, search, fabricdeatils, IsRequestPending, IsIssueRequest, IsCompleteIssu, IsSettlementDone);
        }
        public DataSet GetFabricIssueDetails_report(string Flag, int OrderDetailID, int FabQtyID, int Quality_ID, int orderDetailID, string search = "", string fabricdeatils = "", bool IsRequestPending = false, bool IsIssueRequest = false, bool IsCompleteIssu = false, int selectall = 1)
        {
            return FabricDataProviderInstance.GetFabricIssueDetails_report(Flag, OrderDetailID, FabQtyID, Quality_ID, orderDetailID, search, fabricdeatils, IsRequestPending, IsIssueRequest, IsCompleteIssu, selectall);
        }
        public DataSet GetFabricIssueDetails_Report(string Flag, int selectall, string searcht)
        {
            return FabricDataProviderInstance.GetFabricIssueDetails_Report(Flag, selectall, searcht);
        }
        //end
        public DataSet GetPriorStage(int Quality_ID, int orderDetailID)
        {
            return FabricDataProviderInstance.GetPriorStage(Quality_ID, orderDetailID);
        }
        public int UpdateFabricWastage(int CuttingRequest_IssueSheet_Id, decimal wastage, string flag, int OrderDetailID, int FabQtyID)
        {
            return FabricDataProviderInstance.UpdateFabricWastage(CuttingRequest_IssueSheet_Id, wastage, flag, OrderDetailID, FabQtyID);
        }
        public int UpdateFabricRaise(int IsCheck, string flag, int OrderDetailID, int FabQtyID, string FabricDetails, int Unitid, int UserID)
        {
            return FabricDataProviderInstance.UpdateFabricRaise(IsCheck, flag, OrderDetailID, FabQtyID, FabricDetails, Unitid, UserID);
        }
        public DataSet GetInternalChallanDetails(string Flag, int SupplierPoID = 0, string ChallanType = "", int ChallanID = 0, string IsNewChallan = "", int OrderDetailsID = 0, int FabricQualityID = 0, string fabricdetails = "")
        {
            return FabricDataProviderInstance.GetInternalChallanDetails(Flag, SupplierPoID, ChallanType, ChallanID, IsNewChallan, OrderDetailsID, FabricQualityID, fabricdetails);
        }
        public List<iKandi.Common.FabricGroupAdmin.FabricDetailsHistory> GetFabricHistory(string Flag, int OrderDetailID, int FabQtyID, string FabricDetails)
        {
            return FabricDataProviderInstance.GetFabricHistory(Flag, OrderDetailID, FabQtyID, FabricDetails);
        }
        public List<iKandi.Common.FabricGroupAdmin.FabricDetailsHistory> ListChallan(string Flag, int OrderDetailID, int FabQtyID, string FabricDetails)
        {
            return FabricDataProviderInstance.ListChallan(Flag, OrderDetailID, FabQtyID, FabricDetails);
        }
        public int UpdateStockQty(string flag, int FabQtyID, string FabricDetails, int StockQty, int orderdetailid, int debitqty, string particular, int ResiShrinkQty,int ExtraWastageQty)
        {
            return FabricDataProviderInstance.UpdateStockQty(flag, FabQtyID, FabricDetails, StockQty, orderdetailid, debitqty, particular, ResiShrinkQty, ExtraWastageQty);
        }
        public DataTable CheckStageUpadteValidation(string flag, string ColorPrint, int FabQtyID, int stageval)
        {
            return FabricDataProviderInstance.CheckStageUpadteValidation(flag, ColorPrint, FabQtyID, stageval);
        }
        public DataTable CheckStageUpadteValidationSRVLock(string flag, string ColorPrint, int FabQtyID, int orderdetailsID)
        {
            return FabricDataProviderInstance.CheckStageUpadteValidationSRVLock(flag, ColorPrint, FabQtyID, orderdetailsID);
        }
        public DataSet GetSupplierPoDetails(string flag, int FabQtyID, int fabType, string FabricDetails, int SupplierMasterID)
        {
            return FabricDataProviderInstance.GetSupplierPoDetails(flag, FabQtyID, fabType, FabricDetails, SupplierMasterID);
        }

        //added by raghvinder on 18th feb 2020 start
        public DataSet GetSupplierPoDetails1(string flag, int FabQtyID, int fabType, string FabricDetails, int SupplierMasterID, int styleid, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            return FabricDataProviderInstance.GetSupplierPoDetails1(flag, FabQtyID, fabType, FabricDetails, SupplierMasterID, styleid, stage1, stage2, stage3, stage4);
        }
        //added by raghvinder on 18th feb 2020 end
        public DataSet GETStyleSerialnumberONSupplierQuoatation(int FabQualityID, string FabricDetails, int supplyType)
        {
            return FabricDataProviderInstance.GETStyleSerialnumberONSupplierQuoatation(FabQualityID, FabricDetails, supplyType);
        }
        public bool UpdateCutwastage(string Flag, string Po_Number, decimal cutwastage)
        {
            return FabricDataProviderInstance.UpdateCutwastage(Flag, Po_Number, cutwastage);
        }
        public DataTable GetUnitName()
        {
            return FabricDataProviderInstance.GetUnitName();
        }
        public DataTable Getfabricliability(string flag, string FlagOption, string PoNumber)
        {
            return FabricDataProviderInstance.Getfabricliability(flag, FlagOption, PoNumber);
        }
        public int UpdateFabricLibilityQty(string flag, string FlagOption, string PoNumber, int UserID, int LibilityQty, int OrderDetailID)
        {
            return FabricDataProviderInstance.UpdateFabricLibilityQty(flag, FlagOption, PoNumber, UserID, LibilityQty, OrderDetailID);
        }
        public bool UpdareResidualShrinkage(string Flag, string FlagOption, float residualshrinkage, int FabricQualityID, string FabricDetails)
        {
            return FabricDataProviderInstance.UpdareResidualShrinkage(Flag, FlagOption, residualshrinkage, FabricQualityID, FabricDetails);
        }
        public DataSet GetFabricWastageDetails(string flag, int fabricqtyid)
        {
            return FabricDataProviderInstance.GetFabricWastageDetails(flag, fabricqtyid);
        }
        public int UpdateFabricWastageDetails(string flag, int fabricqtyid, int fabricBarrierWastage, int From_Qty, int To_Qty, int Solid_Barrier, int Print_Barrier, int Dyed_Barrier, int Finished_Barrier, int VA_Barrier)
        {
            return FabricDataProviderInstance.UpdateFabricWastageDetails(flag, fabricqtyid, fabricBarrierWastage, From_Qty, To_Qty, Solid_Barrier, Print_Barrier, Dyed_Barrier, Finished_Barrier, VA_Barrier);
        }
        public int DeleteWastage(string flag, int fabricqtyid, int FabricBarrierWastage)
        {
            return FabricDataProviderInstance.DeleteWastage(flag, fabricqtyid, FabricBarrierWastage);
        }
        public int Save_Fabric_Bill(int SRV_Id, string PartyChallanNumber, bool IsChecked, int SupplierPoId, int PartyBillId, string PartyBillNumber, System.DateTime PartyBillDate, int Amount, int UserId)
        {
            return FabricDataProviderInstance.Save_Fabric_Bill(SRV_Id, PartyChallanNumber, IsChecked, SupplierPoId, PartyBillId, PartyBillNumber, PartyBillDate, Amount, UserId);
        }
        public DataSet GetFabricDebitNoteList(int SupplierPoId)
        {
            return FabricDataProviderInstance.GetFabricDebitNoteList(SupplierPoId);
        }
        public List<Fabric_Srv_Bill> GetAccessory_Srv_Bill_DropDownList(int SupplierPoId, int DebitnoteID)
        {
            return FabricDataProviderInstance.GetAccessory_Srv_Bill_DropDownList(SupplierPoId, DebitnoteID);
        }
        public FabricDebitNoteCls Get_FabricDebitNote(int SupplierPoId, int DebitNoteId, string PartyBillNumber, int srv_id)
        {
            return FabricDataProviderInstance.Get_FabricDebitNote(SupplierPoId, DebitNoteId, PartyBillNumber, srv_id);
        }
        public int Update_Accessory_DebitNotePartyCulars(FabricDebitNoteParticulars objDebitNoteParticulars, int UserId, string type)
        {
            return FabricDataProviderInstance.Update_Accessory_DebitNotePartyCulars(objDebitNoteParticulars, UserId, type);
        }
        public int Save_Accessory_DebitNote(FabricDebitNoteCls objAccessoryDebitNote, int UserId)
        {
            return FabricDataProviderInstance.Save_Accessory_DebitNote(objAccessoryDebitNote, UserId);
        }

        public DataSet GetFabricCreditNoteList(int SupplierPoId)
        {
            return FabricDataProviderInstance.GetFabricCreditNoteList(SupplierPoId);
        }
        public List<Fabric_Srv_Bill> GetFabric_Srv_Bill_DropDownList(int SupplierPoId, int DebitnoteID)
        {
            return FabricDataProviderInstance.GetFabric_Srv_Bill_DropDownList(SupplierPoId, DebitnoteID);
        }
        public List<Fabric_Srv_Bill> GetFabric_Srv_Bill_DropDownList_Creditnote(int SupplierPoId, int DebitnoteID)
        {
            return FabricDataProviderInstance.GetFabric_Srv_Bill_DropDownList_Creditnote(SupplierPoId, DebitnoteID);
        }
        public List<Fabric_Srv_Bill> Get_Credit_Srv_Bill_DropDownList(int SupplierPoId, int DebitnoteID, string flag)
        {
            return FabricDataProviderInstance.Get_Credit_Srv_Bill_DropDownList(SupplierPoId, DebitnoteID, flag);
        }
        public FabricDebitNoteCls Get_FabCreditNote(int SupplierPoId, int DebitNoteId)
        {
            return FabricDataProviderInstance.Get_FabCreditNote(SupplierPoId, DebitNoteId);
        }
        public int Save_Fabric_credit_DebitNote(FabricDebitNoteCls objAccessoryDebitNote, int UserId)
        {
            return FabricDataProviderInstance.Save_Fabric_credit_DebitNote(objAccessoryDebitNote, UserId);
        }
        public int Save_fabric_CreditNote(FabricDebitNoteCls objAccessoryDebitNote, int UserId)
        {
            return FabricDataProviderInstance.Save_fabric_CreditNote(objAccessoryDebitNote, UserId);
        }
        public DataSet Getbills(int SupplierPoId)
        {
            return FabricDataProviderInstance.Getbills(SupplierPoId);
        }
        public DataTable GetEventOccurence()
        {
            return FabricDataProviderInstance.GetEventOccurence();
        }
        public DataTable GetEventOccurenceDetails(int MeetingSchedule_Id)
        {
            return FabricDataProviderInstance.GetEventOccurenceDetails(MeetingSchedule_Id);
        }
        public DataTable SaveBiplMeetingInfo(int MeetingSchedule_Id, int MeetingCategory_Id, string MeetingName, int TimeZone, int Month, int Day, string Time, int IsManual, int Manual_TimeZone, int Manual_Month, int Manual_Day, string Manual_Time, string Participate, string Description, int Years, int UserId)
        {
            return FabricDataProviderInstance.SaveBiplMeetingInfo(MeetingSchedule_Id, MeetingCategory_Id, MeetingName, TimeZone, Month, Day, Time, IsManual, Manual_TimeZone, Manual_Month, Manual_Day, Manual_Time, Participate, Description, Years, UserId);
        }
        public DataTable MeetingNameDuplicateCheck(string flag, int MeetingSchedule_Id, string MeetingName)
        {
            return FabricDataProviderInstance.MeetingNameDuplicateCheck(flag, MeetingSchedule_Id, MeetingName);
        }
        public DataTable MeetingDaily(string flag, int MeetingScheduleId)
        {
            return FabricDataProviderInstance.MeetingDaily(flag, MeetingScheduleId);
        }
        public DataTable MAILUPDATE(string flag, int MeetingSchedule_Id)
        {
            return FabricDataProviderInstance.MAILUPDATE(flag, MeetingSchedule_Id);
        }
        public DataTable MeetingHolidayCheck(string flag, System.DateTime emaildate)
        {
            return FabricDataProviderInstance.MeetingHolidayCheck(flag, emaildate);
        }
        public bool IsCheckPermissionCuttingIssue(int OrderDetailID, int Fabric_QualityID)
        {
            return FabricDataProviderInstance.IsCheckPermissionCuttingIssue(OrderDetailID, Fabric_QualityID);
        }
        //----------
        public int SaveGSAdmin(int GSM, float KgToMeter, int MtrToGrams, string Flag, int UserId)
        {
            return FabricDataProviderInstance.SaveGSAdmin(GSM, KgToMeter, MtrToGrams, Flag, UserId);
        }

        public DataSet GetGSAdmin()
        {
            return FabricDataProviderInstance.GetGSAdmin();
        }

        public int DeleteGSAdmin(int ConvertGSMkgMtrId)
        {
            return FabricDataProviderInstance.DeleteGSAdmin(ConvertGSMkgMtrId);
        }
        public DataSet GetVaSupplierQoutationEmbellishment(string flag, int UserID, string search, string SearchType)
        {
            return FabricDataProviderInstance.GetVaSupplierQoutationEmbellishment(flag, UserID, search, SearchType);
        }
        public DataSet GetVaSupplierQoutationStageDetails(string flag, int UserID, int styleid, int FabricQualityID, string FabricDetails, string VAtypes)
        {
            return FabricDataProviderInstance.GetVaSupplierQoutationStageDetails(flag, UserID, styleid, FabricQualityID, FabricDetails, VAtypes);
        }
        public DataSet GetVaSupplierQoutationStageDetailsStyleVA(string flag, int UserID, int styleid, int FabricQualityID, string FabricDetails, string VAtypes)
        {
            return FabricDataProviderInstance.GetVaSupplierQoutationStageDetailsStyleVA(flag, UserID, styleid, FabricQualityID, FabricDetails, VAtypes);
        }
        public DataSet GetVaSupplierQoutationStageDetailsPrint(string flag, int UserID, int styleid, int FabricQualityID, string FabricDetails, string VAtypes)
        {
            return FabricDataProviderInstance.GetVaSupplierQoutationStageDetailsPrint(flag, UserID, styleid, FabricQualityID, FabricDetails, VAtypes);
        }
        public DataSet GetVaSupplierQoutationStageDetailsdayed(string flag, int UserID, int styleid, int FabricQualityID, string FabricDetails, string VAtypes)
        {
            return FabricDataProviderInstance.GetVaSupplierQoutationStageDetailsdayed(flag, UserID, styleid, FabricQualityID, FabricDetails, VAtypes);
        }
        public DataSet GetVaSupplierQoutationStageDetailsNoneStyleVA(string flag, int UserID, int styleid, int FabricQualityID, string FabricDetails, string VAtypes)
        {
            return FabricDataProviderInstance.GetVaSupplierQoutationStageDetailsNoneStyleVA(flag, UserID, styleid, FabricQualityID, FabricDetails, VAtypes);
        }
        public DataSet GetVaSupplier(string flag, int vaID)
        {
            return FabricDataProviderInstance.GetVaSupplier(flag, vaID);
        }
        public DataSet GetVaSupplierQoutationDayed(string flag, int UserID, string search, string SearchType)
        {
            return FabricDataProviderInstance.GetVaSupplierQoutationDayed(flag, UserID, search, SearchType);
        }
        public DataSet GetVaSupplierQoutationPrint(string flag, int UserID, string search, string SearchType)
        {
            return FabricDataProviderInstance.GetVaSupplierQoutationPrint(flag, UserID, search, SearchType);
        }
        public DataSet GetOtherVaSupplierQoutation(string flag, int UserID, string search, string SearchType)
        {
            return FabricDataProviderInstance.GetOtherVaSupplierQoutation(flag, UserID, search, SearchType);
        }
        public DataSet GetVaSupplierQoutationStyleBasedVA(string flag, int UserID, string search)
        {
            return FabricDataProviderInstance.GetVaSupplierQoutationStyleBasedVA(flag, UserID, search);
        }
        public DataSet GetVaSupplierQoutationStageDetailsstyle(string flag, int UserID, int styleid, int FabricQualityID, string FabricDetails, string VAtypes)
        {
            return FabricDataProviderInstance.GetVaSupplierQoutationStageDetailsstyle(flag, UserID, styleid, FabricQualityID, FabricDetails, VAtypes);
        }
        public DataTable GetFabricWastageDetails(string flag, string flagOption, int FabricQualityID, string FabricDetails)
        {
            return FabricDataProviderInstance.GetFabricWastageDetails(flag, flagOption, FabricQualityID, FabricDetails);
        }       
        public int UpdateFabricWastageShrinkageDetails(string flag, string flagOption, int FabricQualityID, string FabricDetails, int OrderDetailID, int FabType, int VAID, decimal Stage1_Wastage, decimal Stage1_Shrinkage, decimal Stage2_Wastage, decimal Stage2_Shrinkage, decimal Stage3_Wastage, decimal Stage3_Shrinkage, decimal Stage4_Wastage, decimal Stage4_Shrinkage, decimal FabQty, decimal CutWastage, decimal TotalwithCutWastage, decimal hdnavg, decimal CutWastagee)
        {
            return FabricDataProviderInstance.UpdateFabricWastageShrinkageDetails(flag, flagOption, FabricQualityID, FabricDetails, OrderDetailID, FabType, VAID, Stage1_Wastage, Stage1_Shrinkage, Stage2_Wastage, Stage2_Shrinkage, Stage3_Wastage, Stage3_Shrinkage, Stage4_Wastage, Stage4_Shrinkage, FabQty, CutWastage, TotalwithCutWastage, hdnavg, CutWastagee);
        }
        public DataTable GetFabricVAWastage(string flag, string flagOption, int Qty, int VAID)
        {
            return FabricDataProviderInstance.GetFabricVAWastage(flag, flagOption, Qty, VAID);
        }
        //02052023
        public DataTable GetFabricCutWastagePermission( int LoggedInUserDesignationID)
        {
            return FabricDataProviderInstance.GetFabricCutWastagePermission(LoggedInUserDesignationID);
        }
        public DataTable GetMaximumCutwastage()
        {
            return FabricDataProviderInstance.GetMaximumCutwastage();
        }
        public DataTable GetFabricPrintWastageDetails(string flag, string flagOption, int FabricQualityID, string FabricDetails, int CurrentStage, int PreviousStage, bool IsStyleSpecfic, int styleid, int stage1, int stage2, int stage3, int stage4)
        {
            return FabricDataProviderInstance.GetFabricPrintWastageDetails(flag, flagOption, FabricQualityID, FabricDetails, CurrentStage, PreviousStage, IsStyleSpecfic, styleid, stage1, stage2, stage3, stage4);
        }
        public DataSet GetFabricpurchasedSupplierRFD(string flag, string flagoption, int FabQualityID = 0, int FabricMasterID = 0, string potype = "", int SuppliermasterID = 0, int MasterPoID = 0, string FabricDetails = "", int CurrentStageNumber = 0, int PreviousstageNumber = 0, int styleid = 0, bool IsStyleSpecific = false, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0)
        {
            return FabricDataProviderInstance.GetFabricpurchasedSupplierRFD(flag, flagoption, FabQualityID, FabricMasterID, potype, SuppliermasterID, MasterPoID, FabricDetails, CurrentStageNumber, PreviousstageNumber, styleid, IsStyleSpecific, stage1, stage2, stage3, stage4);
        }
        public DataTable getpendingFabsStageValidation(string flag, int FabricQualityID, string FabricDetails, int stage1, int stage2, int stage3, int stage4)
        {
            return FabricDataProviderInstance.getpendingFabsStageValidation(flag, FabricQualityID, FabricDetails, stage1, stage2, stage3, stage4);
        }
        public DataTable GetFabFourPointexcessqty(int SupplierPO_Id, int InspectionID, int Flag, int StockQty)
        {
            return FabricDataProviderInstance.GetFabFourPointexcessqty(SupplierPO_Id, InspectionID, Flag, StockQty);
        }
        //add code by bharat on 9-Sep-20

        public List<Un_RagisterFabric> GetUnRagisterFabQual()
        {
            return FabricDataProviderInstance.GetUnRagisterFabQual();
        }
        public int SaveUnRagisterFabQualityData(Un_RagisterFabric objUnRagFabCo)
        {
            return FabricDataProviderInstance.SaveUnRagisterFabQualityData(objUnRagFabCo);
        }

        // Added by sanjeev 

        public DataSet GetfabricViewdetailsNew(string flag, string flagoption, int FabQualityID = 0, int SupplierCount = 0, string fabricDeatils = "", string searchtxt = "", int SupplierPO = 0, int CurrentStage = 0, int PreviousStage = 0, bool IsStylespecific = false, int StyleID = 0, int stage1 = 0, int stage2 = 0, int stage3 = 0, int stage4 = 0,int SortBy=1)
        {
            return FabricDataProviderInstance.GetfabricViewdetailsNew(flag, flagoption, FabQualityID, SupplierCount, fabricDeatils, searchtxt, SupplierPO, CurrentStage, PreviousStage, IsStylespecific, StyleID, stage1, stage2, stage3, stage4, SortBy);
        }

        public bool FabricOrderAllUpdateToProc(string Flag, string FlagOption, List<FabricGroupAdmin.FabricOrderAllUpdate> Fabdets)
        {
            return this.FabricDataProviderInstance.FabricOrderAllUpdateToProc(Flag, FlagOption, Fabdets);
        }

        //Added
        public string[] GetDetailsForMail(string Po_Number,string flag)
        {
            return this.FabricDataProviderInstance.GetDetailsForMail(Po_Number, flag);
        }
        public string[] GetReturnedChallanQty(string Flag, string ChallanNumber)
        {
            return this.FabricDataProviderInstance.GetReturnedChallanQty(Flag, ChallanNumber);
        }

        public string CheckIfChallanNumberExist(string ChallanNumber, int ReturnQty)
        {
            return this.FabricDataProviderInstance.CheckIfChallanNumberExist(ChallanNumber, ReturnQty);
        }

      
    }
}