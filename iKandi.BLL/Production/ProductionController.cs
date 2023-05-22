using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using System.Data;

namespace iKandi.BLL.Production
{

    public class ProductionController : BaseController
    {

        public DataSet GetSlot_LinePlanning(string StartDate, int Lineno, int SlotId, int ProductionUnit, string Type, int UserId)
        {
            return ProductionDataProviderInstance.GetSlot_LinePlanning(StartDate, Lineno, SlotId, ProductionUnit, Type, UserId);
        }

        public string[] SaveSlot_LinePlanning_Stitching(StitchingDetail objStitching, int UserId)
        {
            return ProductionDataProviderInstance.SaveSlot_LinePlanning_Stitching(objStitching, UserId);
        }
        public string SaveSlot_Cluster_Stitching(StitchingDetail objStitching, int UserId, string Issave = "")
        {
            return ProductionDataProviderInstance.SaveSlot_Cluster_Stitching(objStitching, UserId, Issave);
        }
        public string SaveSlot_Cluster_Delete1(StitchingDetail objStitching, int UserId)
        {
            return ProductionDataProviderInstance.SaveSlot_Cluster_Delete1(objStitching, UserId);
        }
        //Gajendra 11-12-2015 for Order History
        public DataTable GetOredrHistoryDetails(int OrderDetailID, DateTime CreatedDate, string Type, int UnitID)
        {
            return ProductionDataProviderInstance.GetOredrHistoryDetails(OrderDetailID, CreatedDate, Type, UnitID);
        }

        //Gajendra Penalty Metrics
        public DataTable GetCompanyName_Of_ShippedQty()
        {
            return ProductionDataProviderInstance.GetCompanyName_Of_ShippedQty();
        }
        //Gajendra Penalty Metrics 15-07-2016
        public DataSet GetPenaltyMetricsNew()
        {
            return ProductionDataProviderInstance.GetPenaltyMetricsNew();
        }
        //Gajendra Penalty Metrics
        public DataSet GetPenaltyMetrics(string UnitID)
        {
            return ProductionDataProviderInstance.GetPenaltyMetrics(UnitID);
        }
        //Gajendra Penalty Metrics
        public DataSet GetPenaltyMetricsBIPL()
        {
            return ProductionDataProviderInstance.GetPenaltyMetricsBIPL();
        }

        public DataSet GetOrderContract_BySizeOption(int OrderDetailId, int OrderID, string Type, int UnitId)
        {
            return ProductionDataProviderInstance.GetOrderContract_BySizeOption(OrderDetailId, OrderID, Type, UnitId);
        }

        public DataTable GetSizeQuantity_Option(int OrderDetailID, int Option, string Type, int UnitID)
        {
            return ProductionDataProviderInstance.GetSizeQuantity_Option(OrderDetailID, Option, Type, UnitID);
        }

        public int SaveQuantityBySize(int OrderDetailId, string Size1, string Size2, string Size3, string Size4, string Size5, string Size6, string Size7, string Size8, string Size9, string Size10, string Size11, string Size12, string Size13, string Size14, string Size15, int Quantity1, int Quantity2, int Quantity3, int Quantity4, int Quantity5, int Quantity6, int Quantity7, int Quantity8, int Quantity9, int Quantity10, int Quantity11, int Quantity12, int Quantity13, int Quantity14, int Quantity15, int AltVal, string Type, int UnitId)
        {
            return ProductionDataProviderInstance.SaveQuantityBySize(OrderDetailId, Size1, Size2, Size3, Size4, Size5, Size6, Size7, Size8, Size9, Size10, Size11, Size12, Size13, Size14, Size15, Quantity1, Quantity2, Quantity3, Quantity4, Quantity5, Quantity6, Quantity7, Quantity8, Quantity9, Quantity10, Quantity11, Quantity12, Quantity13, Quantity14, Quantity15, AltVal, Type, UnitId);
        }

        public DataTable GetDepartmentLoss(string Type)
        {
            return ProductionDataProviderInstance.GetDepartmentLoss(Type);
        }

        public int SaveSlotWiseDistributionLoss(int SlotWiseFactoryId, int UnitId, int DeprtmentID, int SlotId, int LossDepartmentValue, int UserId, string SlotDate)
        {
            return ProductionDataProviderInstance.SaveSlotWiseDistributionLoss(SlotWiseFactoryId, UnitId, DeprtmentID, SlotId, LossDepartmentValue, UserId, SlotDate);
        }

        public int SaveSlotWiseFactoryId_Ref(string SlotWiseFactoryIdAll, int UnitId, int SlotId, int UserId, string SlotDate)
        {
            return ProductionDataProviderInstance.SaveSlotWiseFactoryId_Ref(SlotWiseFactoryIdAll, UnitId, SlotId, UserId, SlotDate);
        }

        public int SaveSlot_LinePlanning_FactoryIE(int LinePlanningId, int UnitId, int OrderID, int OrderDetailId, int Lineno, int SlotId, string SlotDate, string SlotComment, int UserId)
        {
            return ProductionDataProviderInstance.SaveSlot_LinePlanning_FactoryIE(LinePlanningId, UnitId, OrderID, OrderDetailId, Lineno, SlotId, SlotDate, SlotComment, UserId);
        }
        //added by abhishek on 28/9/2015
        public int InsertUpdateCuttingSlotpass(string SlotDate, int OrderDetailsID, int OrderID, int unitID, int TotaltoCut, bool MarksAsCut, int slotpassVal, int CutReady, int userid, int chkalmostdone)
        {
            return ProductionDataProviderInstance.InsertUpdateCuttingSlotpass(SlotDate, OrderDetailsID, OrderID, unitID, TotaltoCut, MarksAsCut, slotpassVal, CutReady, userid, chkalmostdone);
        }
        public DataSet GetSlot_LinePlanning_cutting(int UnitID, int ClientId, int ClientDeptID, string SearchText)
        {
            return ProductionDataProviderInstance.GetSlot_LinePlanning_cutting(UnitID, ClientId, ClientDeptID, SearchText);
        }
        //End by abhishek 

        //uday
        public int SaveSlot_LinePlanning_FinshingIE(string SlotDate, int LinePlanningID, int OrderDetailId, int OrderID, int unitid, int TotalFinshing, bool MarkAsDayCloseFinished, bool MarkAsFinishedPacked, int Slotpass, int SlotId, int Userid)
        {
            return ProductionDataProviderInstance.SaveSlot_LinePlanning_FinshingIE(SlotDate, LinePlanningID, OrderDetailId, OrderID, unitid, TotalFinshing, MarkAsDayCloseFinished, MarkAsFinishedPacked, Slotpass, SlotId, Userid);
        }
        //End uday
        // Add by Ravi kumar on 5/10/15
        public DataSet GetAllStitchingSlot(int UnitId, string SlotDate, int UserId)
        {
            return ProductionDataProviderInstance.GetAllStitchingSlot(UnitId, SlotDate, UserId);
        }

        // Add by Ravi kumar on 17/02/16
        public DataSet GetAllStitchingFactoryIESlot(int UnitId, string SlotDate)
        {
            return ProductionDataProviderInstance.GetAllStitchingFactoryIESlot(UnitId, SlotDate);
        }

        public string GetFactoryName(int UnitId)
        {
            return ProductionDataProviderInstance.GetFactoryName(UnitId);
        }
        //added by abhishek on 7/10/2015  --this method for insert/updated value addition admin

        public string InsertUpdateValueAddtion(int fromstatus, int tostatus, string VaddtionValue, bool IsAct, int id, decimal Rate)
        {
            return ProductionDataProviderInstance.InsertUpdateValueAddtion(fromstatus, tostatus, VaddtionValue, IsAct, id, Rate);
        }
        public DataTable GetProductionStatus()
        {
            return ProductionDataProviderInstance.GetProductionStatus();
        }


        public DataTable GetAllVaAddtion(int orderid)
        {
            return ProductionDataProviderInstance.GetAllVaAddtion(orderid);
        }

        public int InsertUpdateValueEdttion(int riskvalid, int qty)
        {
            return ProductionDataProviderInstance.InsertUpdateValueEdttion(riskvalid, qty);
        }
        public DataTable GetValueAddtionDetails()
        {
            return ProductionDataProviderInstance.GetValueAddtionDetails();
        }
        //end by abhishek on 7/10/2015
        // Add by Ravi kumar on 12/10/15
        public DataSet GetAllFinishingSlot(int UnitId, string SlotDate, int UserId)
        {
            return ProductionDataProviderInstance.GetAllFinishingSlot(UnitId, SlotDate, UserId);
        }

        public string Check_Cut_For_Production(int OrderDetailId, string Type)
        {
            return ProductionDataProviderInstance.Check_Cut_For_Production(OrderDetailId, Type);
        }
        public string Check_CuttingAndIssued_Data(int OrderDetailId, string Type, int PcsCut)
        {
            return ProductionDataProviderInstance.Check_CuttingAndIssued_Data(OrderDetailId, Type, PcsCut);
        }
        // For task flow
        public bool UpdateCuttingStatus(int StyleId, int OrderID, int Quantity, int OrderDetailsID, int PcsCut, int Today, int UseId)
        {
            if (PcsCut > 0)
            {
                //if (cuttingOutSheetId == -1)
                //{

                //    cuttingOutSheetId = OrderDataProviderInstance.InsertManageOrderCutting(OrderID);
                //    orderOutid = OrderID;

                //    CuttingSheetId = cuttingOutSheetId;
                //}
                //OrderDataProviderInstance.InsertCuttingDetails(cuttingOutSheetId, OrderDetailsID, Today, CutPercent, CutBallence, BCutIssued);
                //OrderDataProviderInstance.UpdateManageOrderInlineCutDate(StyleId);
                //OrderDataProviderInstance.InsertManageOrderCuttingHistory(OrderDetailsID,
                //                                                          Today, DateTime.Today);
                try
                {
                    iKandi.Common.Order order = OrderDataProviderInstance.GetOrderByOrderDetailId(OrderDetailsID);
                    OrderDetail orderDetail =
                                order.OrderBreakdown.Find(
                                    delegate(OrderDetail od) { return od.OrderDetailID == OrderDetailsID; });
                    WorkflowInstance instance =
                                WorkflowControllerInstance.GetInstance(StyleId,
                                                                       OrderID,
                                                                       OrderDetailsID);

                    List<WorkflowInstanceDetail> tasks =
                               WorkflowControllerInstance.GetUserTasks(UseId,
                                                                       instance.WorkflowInstanceID);
                    foreach (WorkflowInstanceDetail task in tasks)
                    {
                        if (task.StatusModeID == (int)StatusMode.INLINECUT && Quantity > 0 &&
                            ((PcsCut * 100) / Quantity) >= 5) //TODO Calc
                        {
                            //WorkflowControllerInstance.CompleteTask(task, UseId);

                            //WorkflowInstanceDetail taskCutting =
                            //    //WorkflowControllerInstance.CreateTask(StatusMode.CUTTING,
                            //    //                                      instance.WorkflowInstanceID,
                            //    //                                      orderDetail.ExFactory.AddDays(-20));

                            ////WorkflowControllerInstance.CompleteTask(taskCutting, UseId);

                            ////WorkflowControllerInstance.CreateTask(StatusMode.STITCHING, instance.WorkflowInstanceID,
                            ////                                      orderDetail.ExFactory.AddDays(-14));
                        }
                        else if (task.StatusModeID == (int)StatusMode.INLINECUT)
                        {
                            WorkflowControllerInstance.CompleteTask(task, UseId);

                            //WorkflowControllerInstance.CreateTask(StatusMode.CUTTING, instance.WorkflowInstanceID,
                            //                                      orderDetail.ExFactory.AddDays(-20));
                        }

                        if (task.StatusModeID == (int)StatusMode.CUTTING && Quantity > 0 &&
                            ((PcsCut * 100) / Quantity) >= 5) //TODO Calc
                        {
                            WorkflowControllerInstance.CompleteTask(task, UseId);


                            //WorkflowControllerInstance.CreateTask(StatusMode.STITCHING, instance.WorkflowInstanceID,
                            //                                      orderDetail.ExFactory.AddDays(-14));
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }

            return true;
        }


        public bool UpdateStitchingStatus(int StyleId, int OrderID, int Quantity, int OrderDetailsID, int PcsStitched, int Today, int UseId, int UnitId)
        {
            if (PcsStitched > 0)
            {
                try
                {
                    iKandi.Common.Order order = OrderDataProviderInstance.GetOrderByOrderDetailId(OrderDetailsID);
                    OrderDetail orderDetail =
                                order.OrderBreakdown.Find(
                                    delegate(OrderDetail od) { return od.OrderDetailID == OrderDetailsID; });


                    int CuttingVal = ProductionDataProviderInstance.CheckCuttingForStitching(OrderDetailsID, UnitId);
                    double CutPercent = 0;

                    if (CuttingVal != 0 && Quantity > 0)
                    {
                        CutPercent = (CuttingVal * 100) / Quantity;
                    }

                    // Update workflow
                    WorkflowInstance instance = WorkflowControllerInstance.GetInstance(-1, -1, OrderDetailsID);

                    List<WorkflowInstanceDetail> tasks =
                        WorkflowControllerInstance.GetUserTasks(UseId, instance.WorkflowInstanceID);


                    foreach (WorkflowInstanceDetail task in tasks)
                    {
                        if (task.StatusModeID == (int)StatusMode.STITCHING && PcsStitched > 0 &&
                            ((PcsStitched * 100) / Quantity) >= 5 &&
                            CutPercent >= 90) //TODO Calc: Get Total Quantity
                        {
                            WorkflowControllerInstance.CompleteTask(task, UseId);

                            //WorkflowControllerInstance.CreateTask(StatusMode.EXFACTORYPLANNED, instance.WorkflowInstanceID,
                            //                                      orderDetail.ExFactory.AddDays(-3));
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));
                    System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
                }
            }
            return true;
        }

        // Hourly Report
        public DataSet GetHourlyStitchingReportUser(string FactoryName, int StyleId, int LineNo, int OrderDetailId, int LinePlanningId, int UnitId, string Type)
        {
            return ProductionDataProviderInstance.GetHourlyStitchingReportUser(FactoryName, StyleId, LineNo, OrderDetailId, LinePlanningId, UnitId, Type);
        }
        public DataSet GetHourlyStitchingReport(string FactoryName, int StyleId, int OrderId, int LineNo, int UnitId, int IsCluster, int ClusterId, string Type)
        {
            return ProductionDataProviderInstance.GetHourlyStitchingReport(FactoryName, StyleId, OrderId, LineNo, UnitId, IsCluster, ClusterId, Type);
        }
        public int UpdateHrlyErrorLog(string ErrorMsg, int ProductionUnit, int SlotID, int LineNo, int StyleId)
        {
            return ProductionDataProviderInstance.UpdateHrlyErrorLog(ErrorMsg, ProductionUnit, SlotID, LineNo, StyleId);
        }
        //added by abhishek on 12/7/2017
        public DataSet GetHourlyStitchingReport_top3fualtsSammury(string FactoryName, int StyleId, int OrderId, int LineNo, int UnitId, string Type)
        {
            return ProductionDataProviderInstance.GetHourlyStitchingReport_top3fualtsSammury(FactoryName, StyleId, OrderId, LineNo, UnitId, Type);
        }
        //end
        public bool bCheckCalenderEvent()
        {
            return ProductionDataProviderInstance.bCheckCalenderEvent();
        }
        public bool bCheckCalenderEvent_ForFits(DateTime date)
        {
            return ProductionDataProviderInstance.bCheckCalenderEvent_ForFits(date);
        }
        public DataSet GetHourlyFinishingReport(string FactoryName, int StyleId, string Type)
        {
            return ProductionDataProviderInstance.GetHourlyFinishingReport(FactoryName, StyleId, Type);
        }

        //public DataSet GetHourlyStitchingReportUser(string FactoryName, int StyleId, int LineNo, int OrderDetailId, string Type)
        //{
        //    return ProductionDataProviderInstance.GetHourlyStitchingReportUser(FactoryName, StyleId, LineNo, OrderDetailId, Type);
        //}

        public DataSet GetHourlyFinishingReportUser(string FactoryName, int StyleId, string Type)
        {
            return ProductionDataProviderInstance.GetHourlyFinishingReportUser(FactoryName, StyleId, Type);
        }

        public DataTable GetBiplUNITNAMEBAL()
        {
            DataTable dt;
            dt = ProductionDataProviderInstance.GetBiplUNITNAME_DAL();
            return dt;
        }
        public DataTable GetMMR_BudgetSummary_Daily_BAL(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            DataTable dt;
            dt = ProductionDataProviderInstance.GetMMR_BudgetSummary_Daily_DAL(sUnitName, dtDate, sFinancialYear);
            return dt;
        }

        public DataTable GetMMR_Summary_Daily_BAL(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            DataTable dt;
            dt = ProductionDataProviderInstance.GetMMR_Summary_Daily_DAL(sUnitName, dtDate, sFinancialYear);
            return dt;
        }

        public string GetMMR_WorkingHours_BAL(DateTime dtDateFrom, DateTime dtDateTo)
        {
            return this.ProductionDataProviderInstance.GetMMR_WorkingHours_DAL(dtDateFrom, dtDateTo);
        }

        public DataTable Get_DailyPerformanceSummery_BAL(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            DataTable dt;
            dt = ProductionDataProviderInstance.Get_DailyPerformanceSummery_DAL(sUnitName, dtDate, sFinancialYear);
            return dt;
        }

        public DataSet GetSlot_LinePlanning_cutting_ByOrderDetailId(int UnitId, int OrderDetailID)
        {
            return ProductionDataProviderInstance.GetSlot_LinePlanning_cutting_ByOrderDetailId(UnitId, OrderDetailID);
        }

        public int Update_Production_Outhouse(int OrderDetailId, int Quantity, int AltPcs, int UnitId, string Type, int UserId)
        {
            return ProductionDataProviderInstance.Update_Production_Outhouse(OrderDetailId, Quantity, AltPcs, UnitId, Type, UserId);
        }

        public int Close_Stitched_FinishTask(StitchingDetail objStitching, int RowCount, int UserId, string Type)
        {
            return ProductionDataProviderInstance.Close_Stitched_FinishTask(objStitching, RowCount, UserId, Type);
        }

        public int SaveHalfStitch_Data(int UnitId, int OrderDetailId, int SlotPass, int SlotAlt, string SlotDate, int Userid)
        {
            return ProductionDataProviderInstance.SaveHalfStitch_Data(UnitId, OrderDetailId, SlotPass, SlotAlt, SlotDate, Userid);
        }

        public DataSet Get_ProductionDetails_History(string OrderDetailID)
        {
            return ProductionDataProviderInstance.Get_ProductionDetails_History(OrderDetailID);
        }

        // Production Matrix work

        public DataSet GetProductionMatrix(int OrderDetailID)
        {
            return ProductionDataProviderInstance.GetProductionMatrix(OrderDetailID);
        }

        //public ProductionMatrixCls GetProductionMatrix(Int32 OrderDetailId)
        //{
        //    return ProductionDataProviderInstance.GetProductionMatrix(OrderDetailId);          
        //}

        public int SaveProduction_ExtraHrs(int OrderDetailId, string ProdDate, double ExtraHrs, int LinePlanningId, int UnitId)
        {
            return ProductionDataProviderInstance.SaveProduction_ExtraHrs(OrderDetailId, ProdDate, ExtraHrs, LinePlanningId, UnitId);
        }

        public DataSet Get_ProductionDateOfMonth()
        {
            return ProductionDataProviderInstance.Get_ProductionDateOfMonth();
        }

        public int SavePeakCapecity_ByProdPlanning(int OrderDetailId, int UsingInPlanning, double CustEfficiency, int CustProdDay, int LinePlanningId, int UnitId, int UserId)
        {
            return ProductionDataProviderInstance.SavePeakCapecity_ByProdPlanning(OrderDetailId, UsingInPlanning, CustEfficiency, CustProdDay, LinePlanningId, UnitId, UserId);
        }

        public DataTable Get_PeakEfficiency(int OrderDetailID, int LinePlanningId, int UnitId)
        {
            return ProductionDataProviderInstance.Get_PeakEfficiency(OrderDetailID, LinePlanningId, UnitId);
        }

        public DataSet GetProductionMatrix_ByLine(int OrderDetailID, out int ExFactoryOld)
        {
            return ProductionDataProviderInstance.GetProductionMatrix_ByLine(OrderDetailID, out ExFactoryOld);
        }

        public int usp_GetLineCount(int OrderDetailId)
        {
            return ProductionDataProviderInstance.GetLineCount(OrderDetailId);
        }
        public DataTable GetClientColorCode(int OrderDetailId)
        {
            return ProductionDataProviderInstance.GetClientColorCode(OrderDetailId);
        }
        public DataSet GetFinshingClusterDetails(string StartDate = "", int Lineno = 0, int SlotId = 0, int ProductionUnit = 0, string Type = "", int UserId = 0)
        {
            return ProductionDataProviderInstance.GetFinshingClusterDetails(StartDate, Lineno, SlotId, ProductionUnit, Type, UserId);
        }
        public DataSet GetFinshingClusterDetailsQcLineMan(string StartDate = "", int Lineno = 0, int SlotId = 0, int ProductionUnit = 0, string Type = "", int UserId = 0)
        {
            return ProductionDataProviderInstance.GetFinshingClusterDetailsQcLineMan(StartDate, Lineno, SlotId, ProductionUnit, Type, UserId);
        }
        public DataSet GetFinshingClusterContarctDetails(string StartDate = "", int SlotId = 0, int ProductionUnit = 0, string Type = "", int UserId = 0, int ClusterID = 0, int @ClusterCounts = 0)
        {
            return ProductionDataProviderInstance.GetFinshingClusterContarctDetails(StartDate, SlotId, ProductionUnit, Type, UserId, ClusterID, @ClusterCounts);
        }
        // Added By Ravi kumar on 6-7-17        
        public DataSet GetStitch_PendingQty_ByStyleCode(string stylecode, int UnitId, int LIneNo, int Days, int TargetQty, int styleid)
        {
            return ProductionDataProviderInstance.GetStitch_PendingQty_ByStyleCode(stylecode, UnitId, LIneNo, Days, TargetQty, styleid);
        }

        // Updated on 26-4-2018
        // Added By Prabhaker on 9-5-18
        public DataSet GetBottleNeck_Operation_OrderID(int OrderID, int UnitId, int LineNo, int slotId, int ClusterId)
        {
            return ProductionDataProviderInstance.GetBottleNeck_Operation_OrderID(OrderID, UnitId, LineNo, slotId, ClusterId);
        }
        // End Prabhaker on 9-5-18

        public DataSet GetUpcomingStyle(string StyleCode, int UnitId, int LineNo)
        {
            return ProductionDataProviderInstance.GetUpcomingStyle(StyleCode, UnitId, LineNo);
        }
        public DataSet GetAllQuantity_ByStyleCode(string stylecode, int OrderDetailId)
        {
            return ProductionDataProviderInstance.GetAllQuantity_ByStyleCode(stylecode, OrderDetailId);
        }
        public DataSet GetSlotId()
        {
            return ProductionDataProviderInstance.GetSlotId();
        }
        public DataSet Production_Matrix_Structure(int OrderDetailId, string stylecode, int FrameNo)
        {
            return ProductionDataProviderInstance.Production_Matrix_Structure(OrderDetailId, stylecode, FrameNo);
        }
        public DataSet Accessory_Fabric_ForMatrix(int OrderDetailId, string stylecode)
        {
            return ProductionDataProviderInstance.Accessory_Fabric_ForMatrix(OrderDetailId, stylecode);
        }

        public string Production_Matrix_Color(int OrderDetailId, string sType, string FabricName, string FabricDetail, string Accessories, int TotalDayStitch)
        {
            return ProductionDataProviderInstance.Production_Matrix_Color(OrderDetailId, sType, FabricName, FabricDetail, Accessories, TotalDayStitch);
        }
        public DataTable GetValueAddtionQty(int OrderDetailID, DateTime CreateDate)
        {
            return ProductionDataProviderInstance.GetValueAddtionQty(OrderDetailID, CreateDate);

        }
        public DataSet GetHalfStitchInOutQty(int Type, int OrderDetailID)
        {
            return ProductionDataProviderInstance.GetHalfStitchInOutQty(Type, OrderDetailID);

        }
        public DataSet GetSlotEntryDetails(DateTime SlotCreateDate)
        {
            return ProductionDataProviderInstance.GetSlotEntryDetails(SlotCreateDate);
        }
        public DataSet GetSlotEntryDetailsBylineID(int UnitId, DateTime SlotCreateDate, int LineplaningID, int OrderDetailId, int ClusterId)
        {
            return ProductionDataProviderInstance.GetSlotEntryDetailsBylineID(UnitId, SlotCreateDate, LineplaningID, OrderDetailId, ClusterId);
        }
        public DataSet GetMaterialLate(Int32 UnitId, string StyleCode, int LinePlanframeId, int type)
        {
            return ProductionDataProviderInstance.GetMaterialLate(UnitId, StyleCode, LinePlanframeId, type);
        }
        public DataSet GetNewsLetterLinePlan(Int32 UnitId, int LineNo, int type)
        {
            return ProductionDataProviderInstance.GetNewsLetterLinePlan(UnitId, LineNo, type);
        }
        public DataSet GetNewsLetterLinePlanSummary(int type)
        {
            return ProductionDataProviderInstance.GetNewsLetterLinePlanSummary(type);
        }

        // Added By Ravi kumar on 23-3-18 for cluster Pending qty     
        public DataSet GetCluster_PendingQty_ByStyleCode(string stylecode, int ClusterId)
        {
            return ProductionDataProviderInstance.GetCluster_PendingQty_ByStyleCode(stylecode, ClusterId);
        }

        // Bottle Neck work on 2-May-18
        public List<BottleNeck> GetOB_Section_ByStyle(Int32 StyleId)
        {
            return ProductionDataProviderInstance.GetOB_Section_ByStyle(StyleId);
        }
        public List<BottleNeck> GetOB_Operation_ByStyle(Int32 StyleId, string SectionName)
        {
            return ProductionDataProviderInstance.GetOB_Operation_ByStyle(StyleId, SectionName);
        }

        public int SaveStitching_BottleNeck(BottleNeck objBottleNeck, string SlotDate, int UserId)
        {
            return ProductionDataProviderInstance.SaveStitching_BottleNeck(objBottleNeck, SlotDate, UserId);
        }

        public DataTable GetStitching_BottleNeck(BottleNeck objBottleNeck)
        {
            return ProductionDataProviderInstance.GetStitching_BottleNeck(objBottleNeck);
        }

        //public int GetResolve_AllBottleNeck(int OrderDetailId, int LinePlanningId, string SlotDate)
        //{
        //    return ProductionDataProviderInstance.GetResolve_AllBottleNeck(OrderDetailId, LinePlanningId, SlotDate);
        //}

        public DataTable GetAllFactory_QC()
        {
            return ProductionDataProviderInstance.GetAllFactory_QC();
        }

        public int SaveStitching_QC(StitchQC objStitchQC, string SlotDate, int UserId, int UnitID, out int QCSlotWiseId)
        {
            return ProductionDataProviderInstance.SaveStitching_QC(objStitchQC, SlotDate, UserId, UnitID, out QCSlotWiseId);
        }

        public int SaveStitching_QC_Faults(StitchQC objStitchQC, string SlotDate, int UserId, int QCSlotWiseId, int flag, int UnitID)
        {
            return ProductionDataProviderInstance.SaveStitching_QC_Faults(objStitchQC, SlotDate, UserId, QCSlotWiseId, flag, UnitID);
        }

        public DataSet GetStitching_QC(StitchQC objStitchQC, string SlotDate, int UnitId)
        {
            return ProductionDataProviderInstance.GetStitching_QC(objStitchQC, SlotDate, UnitId);
        }
        public int Delete_BottleNeck(BottleNeck objBottleNeck)
        {
            return ProductionDataProviderInstance.Delete_BottleNeck(objBottleNeck);
        }

        public int Delete_QC_Faults(StitchQC objStitchQC)
        {
            return ProductionDataProviderInstance.Delete_QC_Faults(objStitchQC);
        }
        public List<string> GetOB_Operation_ByStyle_Autocompl(int StyleId, string SectionName, string q)
        {
            return ProductionDataProviderInstance.GetOB_Operation_ByStyle_Autocompl(StyleId, SectionName, q);
        }
        public DataSet GetHourlyReportStyleCode(string FactoryName, string StyleCode, int LineNo, int UnitId, int IsCluster, int ClusterId, string Type)
        {
            return ProductionDataProviderInstance.GetHourlyReportStyleCode(FactoryName, StyleCode, LineNo, UnitId, IsCluster, ClusterId, Type);
        }

        public DataSet GetBottleNeck_QC_StyleCode_HourlyReport(string StyleCode, int LinePlanFrameId, int UnitId, int slotId, int ClusterId)
        {
            return ProductionDataProviderInstance.GetBottleNeck_QC_StyleCode_HourlyReport(StyleCode, LinePlanFrameId, UnitId, slotId, ClusterId);
        }

        public DataSet GetPending_Stitch_FinishQty_ByStyleCode(string stylecode, int StyleId, int UnitId, int LIneNo, int Days, int TargetQty)
        {
            return ProductionDataProviderInstance.GetPending_Stitch_FinishQty_ByStyleCode(stylecode, StyleId, UnitId, LIneNo, Days, TargetQty);
        }

        public DataSet GetBottleNeck_QC_HourlyReport_ForFactory(int UnitId, int TotalCount, int SlotId)
        {
            return ProductionDataProviderInstance.GetBottleNeck_QC_HourlyReport_ForFactory(UnitId, TotalCount, SlotId);

        }
        public DataTable GetTopFualtDetails(int orderDetailID, DateTime date)
        {
            return ProductionDataProviderInstance.GetTopFualtDetails(orderDetailID, date);
        }
        public DataSet TotalFault_In_Percent(string OrderDetailID)
        {
            return ProductionDataProviderInstance.TotalFault_In_Percent(OrderDetailID);
        }

        public int UpdateSlotWiseEntryDetailsByDate(StitchingDetail objStitchingDetail, int UserId)
        {
            return ProductionDataProviderInstance.UpdateSlotWiseEntryDetailsByDate(objStitchingDetail, UserId);
        }
        public int AddRescanCycle(int OrderDetailId)
        {
            return ProductionDataProviderInstance.AddRescanCycle(OrderDetailId);
        }

        public DataSet GetProduction_SectionFor_HourlyReport(string stylecode, int LinePlanFrameId, int StyleId, int UnitId, int LIneNo, int SlotId, int Days, int TargetQty, int IsCluster, int ClusterId)
        {
            return ProductionDataProviderInstance.GetProduction_SectionFor_HourlyReport(stylecode, LinePlanFrameId, StyleId, UnitId, LIneNo, SlotId, Days, TargetQty, IsCluster, ClusterId);
        }


        public int SaveBIPLGlobalDailyIE(float CutQty_C45_46, float FinishedQty_C45_46, float StitchedQty_C45_46,
                                         float CutQty_C47, float FinishedQty_C47, float StitchedQty_C47,
                                         float CutQty_D169, float FinishedQty_D169, float StitchedQty_D169,
                                         float CutQty, float FinishedQty, float StitchedQty,
                                         float CutRate_C45_46, float FinishedRate_C45_46, float StitchingEfficiency_C45_46, float Achievement_C45_46,
                                         float CutRate_C47, float FinishedRate_C47, float StitchingEfficiency_C47, float Achievement_C47,
                                         float CutRate_D169, float FinishedRate_D169, float StitchingEfficiency_D169, float Achievement_D169,
                                         float CutRate_BIPL, float FinishedRate_BIPL, float StitchingEfficiency_BIPL, float Achievement_BIPL,bool TaskClosed
                                         )
        {
            return ProductionDataProviderInstance.SaveBIPLGlobalDailyIE(CutQty_C45_46, FinishedQty_C45_46, StitchedQty_C45_46,
                                                                        CutQty_C47, FinishedQty_C47, StitchedQty_C47,
                                                                        CutQty_D169, FinishedQty_D169, StitchedQty_D169,
                                                                        CutQty, FinishedQty, StitchedQty,
                                                                        CutRate_C45_46, FinishedRate_C45_46, StitchingEfficiency_C45_46, Achievement_C45_46,
                                                                        CutRate_C47, FinishedRate_C47, StitchingEfficiency_C47, Achievement_C47,
                                                                        CutRate_D169, FinishedRate_D169, StitchingEfficiency_D169, Achievement_D169,
                                                                         CutRate_BIPL, FinishedRate_BIPL, StitchingEfficiency_BIPL, Achievement_BIPL, TaskClosed
                                                                        );
        }
        //added code by bharat on 03-01-20

        public int AddValueAdditonPo(PO_Valueaddition poValueaddition)
        {
            return ProductionDataProviderInstance.AddValueAdditonPo(poValueaddition);
        }
        //Added code by Bharat On 13-jul-20
        public DataTable VAMinRateReport()
        {
            return ProductionDataProviderInstance.VAMinRateReport();
        }
        //public DataTable VendorServiceDetails()
        //{
        //    return ProductionDataProviderInstance.VendorServiceDetails();
        //}
        //End

        public PO_Valueaddition GetValueAdditonPo(int RiskVASupplierId, string PONumber)
        {
            return ProductionDataProviderInstance.GetValueAdditonPo(RiskVASupplierId, PONumber);
        }
        public PO_StitchCutHouse GetStitchHousePo(int OrderDetailId, int LocationType, string PONumber)
        {
            return ProductionDataProviderInstance.GetStitchHousePo(OrderDetailId, LocationType, PONumber);
        }

        public int AddStitchHousePo(PO_StitchCutHouse ObjPoStitchHouse)
        {
            return ProductionDataProviderInstance.AddStitchHousePo(ObjPoStitchHouse);
        }

        public DataTable GetStitchHousePOHistory(int OrderDetailId, int LocationType, string PONumber)
        {
            return ProductionDataProviderInstance.GetStitchHousePOHistory(OrderDetailId, LocationType, PONumber);
        }

        //added by raghvinder on 09-10-2020 start
        public DataTable GetMaterialRequired_Actual_Report()
        {
            return ProductionDataProviderInstance.GetMaterialRequired_Actual_Report();
        }        
        //added by raghvinder on 09-10-2020 end

        //added by raghvinder on 27-07-2020 start
        public DataTable GetSalesOHRevenue()
        {
            return ProductionDataProviderInstance.GetSalesOHRevenue();
        }
        //added by raghvinder on 27-07-2020 end

        //added by raghvinder on 22-07-2020 start
        public DataTable GetFinancialSavingReport()
        {
            return ProductionDataProviderInstance.GetFinancialSavingReport();
        }
        //added by raghvinder on 22-07-2020 end

        //added by raghvinder on 21-07-2020 start
        public DataTable GetMeterRevenueReport()
        {
            return ProductionDataProviderInstance.GetMeterRevenueReport();
        }
        //added by raghvinder on 21-07-2020 end
        public DataSet GetQuarterlyAverageReport()
        {
            return ProductionDataProviderInstance.GetQuarterlyAverageReport();
        }

        public DataSet GetBIPLGlobalDailyIE()
        {
            return ProductionDataProviderInstance.GetBIPLGlobalDailyIE();
        }



        public DataTable GetValueAdditonPOHistory(int RiskVASupplierId, string PONumber)
        {
            return ProductionDataProviderInstance.GetValueAdditonPOHistory(RiskVASupplierId, PONumber);
        }
        public DataTable BindPODropDown()
        {
            return ProductionDataProviderInstance.BindPODropDown();
        }
        public DataSet PO_ValueAdditionName(string JobID)
        {
            return ProductionDataProviderInstance.PO_ValueAdditionName(JobID);
        }

        public DataTable BindSAMDropDown(int OrderDetailId)
        {
            return ProductionDataProviderInstance.BindSAMDropDown(OrderDetailId);
        }

        public DataTable BindFinishSAMDropDown(int OrderDetailId)
        {
            return ProductionDataProviderInstance.BindFinishSAMDropDown(OrderDetailId);
        }

        //Add code by bharat on 12-1-20 
        public DataSet GetDepartmentName()
        {
            return ProductionDataProviderInstance.GetDepartmentName();
        }
        public DataSet GetDepartmentCurrency(int CurrencyValu)
        {
            return ProductionDataProviderInstance.GetDepartmentCurrency(CurrencyValu);
        }
   
        //public List<Client_Department> GetFabricDepartmentName()
        //{
        //    return ProductionDataProviderInstance.GetFabricDepartmentName();
        //}

        public List<Client_Department> GetDesinsPatterns(string FSearchVal, string PareDeparVal, string FabseVal, string FTag, string FCompo, string FColle, string FaMoq, decimal MinValau, decimal MaxValu, int CurrencyVal)
        {
            return ProductionDataProviderInstance.GetDesinsPatterns(FSearchVal, PareDeparVal, FabseVal, FTag, FCompo, FColle, FaMoq, MinValau, MaxValu, CurrencyVal);
        
        }
        public Client_Department GetProductDetails(int ProductNameFro, int ProductCurrency)
        {
            return ProductionDataProviderInstance.GetProductDetails(ProductNameFro, ProductCurrency);
        }

        public DataTable BindCurrencyDropDownList()
        {
            return ProductionDataProviderInstance.BindCurrencyDropDownList();
        }
        //public List<Client_Department> GetLikeCount()
        //{
        //    return ProductionDataProviderInstance.GetLikeCount();
        //}

        //added by Ravishankar for storing actual daily CMT % in 11th slot
        public int InsertDailyActualCMTPercent(double CMTValue, DateTime HrlyDate)
        {
            return this.ProductionDataProviderInstance.InsertDailyActualCMTPercent(CMTValue, HrlyDate);

        }
        // end
    }
}
