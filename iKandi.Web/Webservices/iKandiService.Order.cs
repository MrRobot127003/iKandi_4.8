using System;
using System.Web.Services;
using iKandi.BLL;
using System.Collections.Generic;
using iKandi.Common;
using iKandi.Web.Components;
using iKandi.Common.Entities;
using System.Data;
using System.Globalization;
using iKandi.BLL.CmtAdmin;
using iKandi.BLL.Production;


namespace iKandi.Web
{
    public partial class iKandiService
    {
        //Added by Abhishek 25/4/2015


        FabricController fabobj = new FabricController();
        BuyingHouseController objBuyingHouseController = new BuyingHouseController();
        OrderProcessController OrderProcessControllerInstance = new OrderProcessController();
        
        PrintController Objprint = new PrintController();
        OrderProcess onhj = new OrderProcess();
        // END 
        //added by abhishek on 27/8/2015
        CmtAdminController obj_CmtAdmin = new CmtAdminController();
        //end by abhishek on 27/8/2015
        [WebMethod(EnableSession = true)]
        public string GetNewSerialNumber(int clientId)
        {
            return this.OrderControllerInstance.GetNewSerialNumber(clientId);
        }
        [WebMethod(EnableSession = true)]
        public string GetNewDescription(int styleid)
        {
            return this.OrderControllerInstance.GetNewDescription(styleid);
        }


        [WebMethod(EnableSession = true)]
        public List<string> SuggestStyleNumber(string q, int limit)
        {
            List<string> allStyles = SuggestForAutoComplete(q, AutoComplete.Style.ToString(), limit);

            if (ApplicationHelper.LoggedInUser.UserData.Designation != Designation.BIPL_Sales_Manager)
            {
                List<string> styles = new List<string>();

                foreach (string style in allStyles)
                {
                    if (!style.Contains("$"))
                        styles.Add(style);
                }

                return styles;
            }
            return allStyles;
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestStyleNumberCode(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.StyleCode.ToString(), limit);
        }

        /// <summary>
        /// For Autocomplete Story
        /// </summary>
        /// <param name="q"></param>
        /// <param name="limit"></param>
        /// <returns></returns>

        [WebMethod(EnableSession = true)]
        public List<string> SuggestStoryWeb(string q, string limit)
        {
            return SuggestStoryBAL(q);
        }


        [WebMethod(EnableSession = true)]
        public List<string> SuggestSupplierName(string q, string limit)
        {
            return SuggestSupplierNameCommon(q);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="q"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public List<string> SuggestProcessOrder(string q, string limit)
        {
            return SuggestProcessOrderBAL(q);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestForFourPoint(string q, string limit)
        {
            return this.FourPointControllerInstance.GetFourPoint(limit, q);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestGroupName(string q, string limit)
        {
            return this.SupplierControllerInstance.GetGroupNameByName(q);
        }

        [WebMethod(EnableSession = true)]
        public List<FeedingClass> GetFeeding_Report(int StyleNumber)
        {
            return this.OrderControllerInstance.GetFeeding_Report();
        }

        [WebMethod(EnableSession = true)]
        public List<FeedingClass> GetUpcomingFeeding_Report(string todate)
        {
            return this.OrderControllerInstance.GetUpcomingFeeding_Report(todate);
        }


        [WebMethod(EnableSession = true)]
        public string InsertFeedingSelection(string extarget, string exactual, string exdelay, string pcdtarget, string pcdactual, string pcddelay, string accbihtarget, string accbihactual, string accbihdelay,
             string fabbihtarget, string fabbihactual, string fabbihdelay, string Toptarget, string Topactual, string Topdelay, string Stctarget, string Stcactual, string Stcdelay,
             string Protarget, string Proactual, string Prodelay, string Apptarget, string Appactual, string Appdelay)
        {
            return this.OrderControllerInstance.InsertFeedingSelection(extarget, exactual, exdelay, pcdtarget, pcdactual, pcddelay, accbihtarget, accbihactual, accbihdelay, fabbihtarget, fabbihactual,
                fabbihdelay, Toptarget, Topactual, Topdelay, Stctarget, Stcactual, Stcdelay, Protarget, Proactual, Prodelay, Apptarget, Appactual, Appdelay,
                System.Web.HttpContext.Current.Session.SessionID);
        }

        [WebMethod(EnableSession = true)]
        public string InsertFeedingSelection_UP(string extarget, string exactual, string pcdtarget, string pcdactual, string accbihtarget, string accbihactual, string fabbihtarget,
            string fabbihactual, string Toptarget, string Topactual, string Stctarget, string Stcactual, string Protarget, string Proactual, string Apptarget, string Appactual, string todate)
        {
            return this.OrderControllerInstance.InsertFeedingSelection_UP(extarget, exactual, pcdtarget, pcdactual, accbihtarget, accbihactual, fabbihtarget, fabbihactual,
                 Toptarget, Topactual, Stctarget, Stcactual, Protarget, Proactual, Apptarget, Appactual, todate, System.Web.HttpContext.Current.Session.SessionID);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestSupplierpName(string q, string limit)
        {
            return this.SupplierControllerInstance.GetSupplierNameByName(q);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestSupplierpNameWithGroup(string q, string limit)
        {
            return this.SupplierControllerInstance.GetSupplierNameWithGroupByName(q);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateMDA(int OrderDetailsID, string MDA)
        {
            return OrderControllerInstance.UpdateMDA(OrderDetailsID, MDA);
        }
        [WebMethod(EnableSession = true)]

        public bool InsertInHouseHistory(int OrderId, int OrderDetailID, int AccessoryWorkingDetailID, int Quantity, int PercentInHouse)
        {
            if (OrderControllerInstance.InsertInHouseHistory(OrderDetailID, AccessoryWorkingDetailID, Quantity, PercentInHouse) && OrderControllerInstance.CheckAccessoryBIH(OrderDetailID))
            {
                WorkflowController WorkflowControllerInstance = new WorkflowController();
                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(OrderId, OrderDetailID, TaskMode.Accessory_BIH, ApplicationHelper.LoggedInUser.UserData.UserID);
                WorkflowControllerInstance = null;
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateExFactory(int OrderDetailsID, string ExFactory, string usrename)
        {
            return OrderControllerInstance.UpdateExFactory(OrderDetailsID, ExFactory, usrename);
        }
        // Added by shubhendu 2/03/2022
         [WebMethod(EnableSession = true)]
        public bool UpdateBiplPriceMO(int OrderDetailsID, float BiplPrice, int Userid, string flag)
        {
            return OrderControllerInstance.UpdateBiplPriceMO(OrderDetailsID, BiplPrice, Userid, flag);
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateDC(int OrderDetailsID, string DC, string usrename)
        {
            return OrderControllerInstance.UpdateDC(OrderDetailsID, DC, usrename);
        }
        // End By Ravi kumar ON 17/12/2014 For MO pcd change on Ex Factory change
        //[WebMethod(EnableSession = true)]
        //public bool UpdateCutAvg(int OrderDetailsID, double CutAvg, int CountFabric, int StyleId, string FabricName, string Print, int IsAll)
        //{
        //    return OrderControllerInstance.UpdateCutAvg(OrderDetailsID, CutAvg, CountFabric, StyleId, FabricName, Print, IsAll);
        //}

        // edit by surendra on 2-jne-2015
        [WebMethod(EnableSession = true)]
        public bool UpdatePlanningLine(int OrderDetaildidforline, int lValue, int StyleIdforLine, string Remarks)
        {
            return OrderControllerInstance.UpdatePlanningLine(OrderDetaildidforline, lValue, StyleIdforLine, Remarks);
        }
        // end
        [WebMethod(EnableSession = true)]
        public bool UpdatePlanneddate(int OrderDetailsID, string Planneddate)
        {
            return OrderControllerInstance.UpdatePlanneddate(OrderDetailsID, Planneddate);
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateAccesoriesApprovedDate(int AccessoryWorkingDetailID, int OrderDetailsID, string ApprovedDate)
        {
            return OrderControllerInstance.UpdateAccesoriesApprovedDate(AccessoryWorkingDetailID, OrderDetailsID, ApprovedDate);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdatePatternSampleDate(int OrderID, int StyleId, string PatternSampleDate, string field,int OrderDetailID)
        {
          if (OrderControllerInstance.UpdatePatternSampleDate(OrderID, StyleId, PatternSampleDate, field, OrderDetailID) && field == "Pattern")
            {
                int iResult = WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(StyleId, OrderID, TaskMode.Pattern_Sample_Received, ApplicationHelper.LoggedInUser.UserData.UserID);
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateShipmentOfferDate(int OrderDetailsID, string Shipmentdate, string UserID)
        {
            return OrderControllerInstance.UpdateShipmentOfferDate(OrderDetailsID, Shipmentdate, UserID);
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateSelectCheckBox(string IsCheked, string FaultID, string OrderDetailId, string type)
        {
            int CreatedBy = Convert.ToInt32(ApplicationHelper.LoggedInUser.UserData.UserID.ToString());
            return OrderControllerInstance.UpdateSelectCheckBox(IsCheked, FaultID, OrderDetailId, type, CreatedBy);
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateCuttingSheetDate(int OrderID, int StyleId, string CuttingSheetDate, int orderDetails_ID, string field)
        {
            if (OrderControllerInstance.UpdateCuttingSheetDate(OrderID, StyleId, CuttingSheetDate, orderDetails_ID, field) && field == "Production")
            {
                WorkflowController WorkflowControllerInstance = new WorkflowController();
                int result = WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Style_Order_Basis(0, OrderID, TaskMode.Production_File, ApplicationHelper.LoggedInUser.UserData.UserID);
                return true;
            }
            else if (OrderControllerInstance.UpdateCuttingSheetDate(OrderID, StyleId, CuttingSheetDate, orderDetails_ID, field) && field == "Cutting")
            {
                WorkflowController WorkflowControllerInstance = new WorkflowController();
                int result = WorkflowControllerInstance.UpdateWorkflowInstancePostOrder_Only_For_Cutting(orderDetails_ID, OrderID, TaskMode.Cutting_Sheet, ApplicationHelper.LoggedInUser.UserData.UserID);
                return true;
            }
            else if (OrderControllerInstance.UpdateCuttingSheetDate(OrderID, StyleId, CuttingSheetDate, orderDetails_ID, field) && field == "CDChartActual")
            {
                WorkflowController WorkflowControllerInstance = new WorkflowController();
                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(OrderID, orderDetails_ID, TaskMode.CD_Chart, ApplicationHelper.LoggedInUser.UserData.UserID);
                WorkflowControllerInstance = null;
                return true;


            }
            else
            {
                return false;
            }
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateProductionFileDate(int OrderID, int StyleId, string ProductionFileDate)
        {
            return OrderControllerInstance.UpdateProductionFileDate(OrderID, StyleId, ProductionFileDate);
        }
        [WebMethod(EnableSession = true)]
        public int UpdateIC_Check(int OrderID, int orderDetails_ID, int Ischeck)
        {
            return OrderControllerInstance.UpdateIC_Check(OrderID, orderDetails_ID, Ischeck);
        }
        [WebMethod(EnableSession = true)]
        public int update_OutHouse(int orderDetails_ID, int OutHouse)
        {
            return OrderControllerInstance.update_OutHouse(orderDetails_ID, OutHouse);
        }

        [WebMethod(EnableSession = true)]
        public int GetCut_Avg(int OrderDetailsID, string CheckInlinecut)
        {
            return OrderControllerInstance.GetCut_Avg(OrderDetailsID, CheckInlinecut);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateCutIssued(int StyleId, int OrderID, int Quantity, int OrderDetailsID, int CuttingSheetId, int CuttingDetailID, int PcsIssued, int CutPiecesPercent, int CutpiecesBallance, int TodayPcsIssued, int BalanceStitched)
        {
            return OrderControllerInstance.UpdateCutIssued(StyleId, OrderID, Quantity, OrderDetailsID, CuttingSheetId, CuttingDetailID, PcsIssued, CutPiecesPercent, CutpiecesBallance, TodayPcsIssued, BalanceStitched);
        }

        [WebMethod(EnableSession = true)]
        public bool UpdatePCSStitch(int OrderDetailsID, int PcsStitch, int StitchPicesPercent, int StitchPicesBalance, int StitchToday)
        {
            return OrderControllerInstance.UpdatePCSStitch(OrderDetailsID, PcsStitch, StitchPicesPercent, StitchPicesBalance, StitchToday);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdatePCSStitchPackedEmb(int OrderDetailsID, int StitchingDetailID, int PcsSent, int PcsReceived, int PcsPackedToday, int OverallPcsPacked, int OverallPcsStitched, int Quantity, int TotalPcsStitchedToday, DateTime ExpectedFinishDate, bool IsStitchingComplete)
        {
            return OrderControllerInstance.UpdatePCSStitchPackedEmb(OrderDetailsID, StitchingDetailID, PcsSent, PcsReceived, PcsPackedToday, OverallPcsPacked, OverallPcsStitched, Quantity, TotalPcsStitchedToday, ExpectedFinishDate, IsStitchingComplete);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateOnlyPacking(int OrderDetailsID, int Pcspacked, int Packingpercent, int PackingBalance, int TodayPacked)
        {
            return OrderControllerInstance.UpdateOnlyPacking(OrderDetailsID, Pcspacked, Packingpercent, PackingBalance, TodayPacked);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateOnlyEmbPices(int OrderDetailsID, int Embpieces, int EmbPicesPercent, int EmbPicesBalance, int TodayEMB)
        {
            return OrderControllerInstance.UpdateOnlyEmbPices(OrderDetailsID, Embpieces, EmbPicesPercent, EmbPicesBalance, TodayEMB);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateOnlyEmbIssues(int OrderDetailsID, int Embissued, int EmbIssuedPercent, int EmbIssuedBalance, int AllPacked)
        {
            return OrderControllerInstance.UpdateOnlyEmbIssues(OrderDetailsID, Embissued, EmbIssuedPercent, EmbIssuedBalance, AllPacked);
        }

        [WebMethod(EnableSession = true)]
        public List<string> GetPoNumberByName(string q, string limit)
        {
            return this.SRVControllerInstance.GetPoNumberByName(q);
        }

        [WebMethod(EnableSession = true)]
        public List<string> GetChallanNoByName(string q, string limit)
        {
            return this.SRVControllerInstance.GetChallanNoByName(q);
        }

        [WebMethod(EnableSession = true)]
        public List<string> GetDescriptionByName(string q, string limit)
        {
            return this.SRVControllerInstance.GetDescriptionByName(q);
        }

        [WebMethod(EnableSession = true)]
        public List<string> SuggestDescription(string q, int limit)
        {
            return SuggestForAutoComplete(q, AutoComplete.Description.ToString(), limit);
        }

        [WebMethod(EnableSession = true)]
        public int GetClientId(string styleNumber)
        {
            return this.OrderControllerInstance.GetClientId(styleNumber);

        }
        [WebMethod(EnableSession = true)]
        public iKandi.Common.Order GetInfoByStyleNumber(string StyleNumber)
        {
            return this.OrderControllerInstance.GetInfoByStyleNumber(StyleNumber);
        }

        [WebMethod(EnableSession = true)]
        public string GetAddressByClientId(int ClientId)
        {
            return this.OrderControllerInstance.GetAddressByClientId(ClientId);
        }

        [WebMethod(EnableSession = true)]
        public iKandi.Common.Order GetIkandiPriceByMode(string Mode, int CostingID, string status)
        {
            return this.OrderControllerInstance.GetIkandiPriceByMode(Mode, CostingID, status);
        }



        //[WebMethod(EnableSession = true)]
        //public List<OrderDetail> GetAllPendingSTCOrders()
        //{
        //    return this.OrderControllerInstance.GetSealerPendingOrders();
        //}

        [WebMethod(EnableSession = true)]
        public string GetPendingSTCOrders()
        {
            return PageHelper.GetControlHtml("~/UserControls/Lists/SealersPendingList.ascx", null);
        }

        [WebMethod(EnableSession = true)]
        public string GetOrdersBasicInfo(string searchText, DateTime FromDate, DateTime ToDate, int ClientID, int DateType)
        {
            //System.Diagnostics.Debugger.Break();
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("searchText", searchText);
            properties.Add("FromDate", FromDate);
            properties.Add("ToDate", ToDate);
            properties.Add("ClientId", ClientID);
            properties.Add("DateType", DateType);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ManageOrderBasicInfo.ascx", properties);
        }
        [WebMethod(EnableSession = true)]
        public int GetMOQAStatusHistory(string q, string limit)
        {
            return this.ReportControllerInstance.GetMOQAStatusHistory(q, limit);
        }
        [WebMethod(EnableSession = true)]
        public string GetManageOrdersFabric(string searchText, DateTime FromDate, DateTime ToDate, int ClientID, int DateType)
        {

            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("searchText", searchText);
            properties.Add("FromDate", FromDate);
            properties.Add("ToDate", ToDate);
            properties.Add("ClientId", ClientID);
            properties.Add("DateType", DateType);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ManageOrderFabric.ascx", properties);
        }


        [WebMethod(EnableSession = true)]
        public string GetManageOrderCutting(string searchText, DateTime FromDate, DateTime ToDate, int ClientID, int DateType)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("searchText", searchText);
            properties.Add("FromDate", FromDate);
            properties.Add("ToDate", ToDate);
            properties.Add("ClientId", ClientID);
            properties.Add("DateType", DateType);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ManageOrderCutting.ascx", properties);
        }
        [WebMethod(EnableSession = true)]
        public string GetManageOrderStiching(string searchText, DateTime FromDate, DateTime ToDate, int ClientID, int DateType)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("searchText", searchText);
            properties.Add("FromDate", FromDate);
            properties.Add("ToDate", ToDate);
            properties.Add("ClientId", ClientID);
            properties.Add("DateType", DateType);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ManageOrderStitching.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string ShowManageOrderFabricPopup(int OrderDetailID, int TotalQuantity, int OrderID, int FabricNo, int ClientID, string Fabric, string FabricDetails)
        {
            //System.Diagnostics.Debugger.Break();
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("OrderDetailID", OrderDetailID);
            properties.Add("TotalQuantity", TotalQuantity);
            properties.Add("OrderID", OrderID);
            properties.Add("FabricNo", FabricNo);
            properties.Add("clientID", ClientID);
            properties.Add("Fabric", Fabric);
            properties.Add("FabricDetails", FabricDetails);
            return PageHelper.GetControlHtml("~/UserControls/Forms/ManageOrderFabricPopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string ShowManageOrderAccessoryPopup(int OrderDetailID, string AccessoryName, int Quantity)
        {
            //System.Diagnostics.Debugger.Break();
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("OrderDetailID", OrderDetailID);
            properties.Add("AccessoryName", AccessoryName);
            properties.Add("Quantity", Quantity);
            return PageHelper.GetControlHtml("~/UserControls/Forms/ManageOrderAccessoryPopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public bool InsertManageOrderFabricInHouseHistory(int OrderId, int OrderDetailID, int FabricType, Double FabricLength, string FabricName, DateTime date, int PercentInHouse)
        {
            if (OrderControllerInstance.InsertManageOrderFabricInHouseHistory(OrderDetailID, FabricType, FabricLength, FabricName, date, PercentInHouse) && OrderControllerInstance.CheckFabricBIH(OrderDetailID))
            {
                WorkflowController WorkflowControllerInstance = new WorkflowController();
                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(OrderId, OrderDetailID, TaskMode.Fabric_BIH, ApplicationHelper.LoggedInUser.UserData.UserID);
                WorkflowControllerInstance = null;
                return true;
            }
            else
            {
                return false;
            }
        }
        [WebMethod(EnableSession = true)]
        public bool InsertManageOrderFabricInHouseHistory_inHouseChecked(int OrderId, int OrderDetailID, int FabricType, string FabricName, DateTime date, int PercentInHouse, int InhouseQnty)
        {
            return OrderControllerInstance.InsertManageOrderFabricInHouseHistory_inHouseChecked(OrderDetailID, FabricType, FabricName, date, PercentInHouse, InhouseQnty);

            //if (OrderControllerInstance.InsertManageOrderFabricInHouseHistory_inHouseChecked(OrderDetailID, FabricType, FabricName, date, PercentInHouse, InhouseQnty) && OrderControllerInstance.CheckFabricBIH(OrderDetailID))
            //{
            //    WorkflowController WorkflowControllerInstance = new WorkflowController();
            //    WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(OrderId, OrderDetailID, TaskMode.Fabric_BIH, ApplicationHelper.LoggedInUser.UserData.UserID);
            //    WorkflowControllerInstance = null;
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        [WebMethod(EnableSession = true)]
        public bool InsertManageOrderAccessoryInHouseHistory(int OrderDetailID, int AccessoryWorkingDetailID, int Quantity, DateTime date, int PercentInHouse)
        {
            return OrderControllerInstance.InsertManageOrderAccessoryInHouseHistory(OrderDetailID, AccessoryWorkingDetailID, Quantity, date, PercentInHouse);
        }

        [WebMethod(EnableSession = true)]
        public string GetManageOrdersiKandiBasicInfo()
        {
            return PageHelper.GetControlHtml("~/UserControls/Lists/ManageOrderiKandiBasicInfo.ascx", null);
        }

        [WebMethod(EnableSession = true)]
        public string GetManageOrdersiKandiFinancials(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("searchText", searchText);
            properties.Add("FromDate", FromDate);
            properties.Add("ToDate", ToDate);
            properties.Add("ClientId", ClientID);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ManageOrderiKandiFinancials.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetManageOrdersiKandiTechnical(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("searchText", searchText);
            properties.Add("FromDate", FromDate);
            properties.Add("ToDate", ToDate);
            properties.Add("ClientId", ClientID);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ManageOrderiKandiTechnical.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetiKandiViewReportFinancials(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("searchText", searchText);
            properties.Add("FromDate", FromDate);
            properties.Add("ToDate", ToDate);
            properties.Add("ClientId", ClientID);
            return PageHelper.GetControlHtml("~/UserControls/Lists/IkandiViewReportsFinancials.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetiKandiViewReportTechnicals(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("searchText", searchText);
            properties.Add("FromDate", FromDate);
            properties.Add("ToDate", ToDate);
            properties.Add("ClientId", ClientID);
            return PageHelper.GetControlHtml("~/UserControls/Lists/IkandiViewReportsTechnicals.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string ShowManageOrderFabricDatesPopup(int StyleID, int OrderDetailID, int OrderID, int ClientID, string Fabric1, string Fabric2, string Fabric3, string Fabric4,
            string Fabric1Details, string Fabric2Details, string Fabric3Details, string Fabric4Details)
        {
            //System.Diagnostics.Debugger.Break();
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("OrderDetailID", OrderDetailID);
            properties.Add("OrderID", OrderID);
            properties.Add("StyleID", StyleID);
            properties.Add("ClientId", ClientID);
            properties.Add("Fabric1", Fabric1);
            properties.Add("Fabric2", Fabric2);
            properties.Add("Fabric3", Fabric3);
            properties.Add("Fabric4", Fabric4);
            properties.Add("Fabric1Details", Fabric1Details);
            properties.Add("Fabric2Details", Fabric2Details);
            properties.Add("Fabric3Details", Fabric3Details);
            properties.Add("Fabric4Details", Fabric4Details);

            return PageHelper.GetControlHtml("~/UserControls/Lists/ManageOrderFabricDatesPopup.ascx", properties);
        }

        /// <summary>
        /// yaten
        /// </summary>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string GetStatusofResolution(string StyleNumber, string Mode)
        {
            return OrderControllerInstance.GetStatusofResolution2(StyleNumber, Mode);
        }

        [WebMethod(EnableSession = true)]
        public string GetMondayFileTopsInfo()
        {
            return PageHelper.GetControlHtml("~/UserControls/Lists/MondayCompanyReportTopsInfo.ascx", null);
        }

        [WebMethod(EnableSession = true)]
        public string GetMondayFileAccessoriesInfo()
        {
            return PageHelper.GetControlHtml("~/UserControls/Lists/MondayCompanyReportAccessories.ascx", null);
        }

        [WebMethod(EnableSession = true)]
        public string GetMondayFileCuttingInfo()
        {
            return PageHelper.GetControlHtml("~/UserControls/Lists/MondayCompanyReportCutting.ascx", null);
        }

        [WebMethod(EnableSession = true)]
        public string GetMondayFileFabricBulkInfo()
        {
            return PageHelper.GetControlHtml("~/UserControls/Lists/MondayCompanyReportFabricBulk.ascx", null);
        }

        [WebMethod(EnableSession = true)]
        public string GetMondayFileExFactoryInfo()
        {
            return PageHelper.GetControlHtml("~/UserControls/Lists/MondayCompanyReportExFactory.ascx", null);
        }

        [WebMethod(EnableSession = true)]
        public string GetMoShippingInfo(int styleId, string remark, string exfactorydate, string stylenumber)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("styleId", styleId);
            properties.Add("remark", remark);
            properties.Add("exfactorydate", exfactorydate);
            properties.Add("stylenumber", stylenumber);
            return PageHelper.GetControlHtml("~/UserControls/Lists/MoShippingPopUp.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetWorkflowHistoryView(int InstanceID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("InstanceID", InstanceID);

            return PageHelper.GetControlHtml("~/UserControls/Lists/WorkflowHistory.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetWorkflowHistoryView2(int StyleID, int OrderID, int OrderDetailID)
        {
            //System.Diagnostics.Debugger.Break();
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleID", StyleID);
            properties.Add("OrderID", OrderID);
            properties.Add("OrderDetailID", OrderDetailID);

            return PageHelper.GetControlHtml("~/UserControls/Lists/WorkflowHistory.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetMOQAStatus(int StyleID, int OrderDetailID)
        {
            //System.Diagnostics.Debugger.Break();
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleID", StyleID);
            properties.Add("OrderDetailID", OrderDetailID);

            return PageHelper.GetControlHtml("~/UserControls/Lists/QAStatusPopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetShipmentOfferDate()
        {
            //System.Diagnostics.Debugger.Break();
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StatusMode", 0);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ShipmentOfferPopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetSizesPopup(int OrderDetailID)
        {

            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("OrderDetailID", OrderDetailID);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ManageOrderSizePopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string showFabricHistoryPopup(int OrderDetailID)
        {
            //System.Diagnostics.Debugger.Break();
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("OrderDetailID", OrderDetailID);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ManageOrderFabricHistoryPopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string showCuttingHistoryPopup(int OrderDetailID)
        {
            //System.Diagnostics.Debugger.Break();
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("OrderDetailID", OrderDetailID);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ManageOrderCuttingHistoryPopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetManageOrderiKandiQuantityByDept(int DepartmentID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("DepartmentID", DepartmentID);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ManageOrderiKandiQuantityByDeptPopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetManageOrderiKandiQuantityByMode(int Mode)
        {

            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("Mode", Mode);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ManageOrderiKandiQuantityByModePopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetManageOrderContractsByPrintNumber(string PrintNumber, int FabricType)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("PrintNumber", PrintNumber);
            return PageHelper.GetControlHtml("~/UserControls/Forms/ManageOrderContractsByPrintNumberPopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string ShowStyleNumberPlanningFabricDetails(int OrderDetailID, int OrderID, int ClientID, string Fabric1, string Fabric2, string Fabric3, string Fabric4)
        {
            //System.Diagnostics.Debugger.Break();
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("OrderDetailID", OrderDetailID);
            properties.Add("OrderID", OrderID);
            properties.Add("ClientId", ClientID);
            properties.Add("Fabric1", Fabric1);
            properties.Add("Fabric2", Fabric2);
            properties.Add("Fabric3", Fabric3);
            properties.Add("Fabric4", Fabric4);

            return PageHelper.GetControlHtml("~/UserControls/Forms/StyleNumberPlanningFabicDetails.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string ShowStyleNumberPlanningFitsDetails(int StyleNumber, int DepartmentID, int OrderDetailID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleNumber", StyleNumber);
            properties.Add("DepartmentID", DepartmentID);
            properties.Add("OrderDetailID", OrderDetailID);
            return PageHelper.GetControlHtml("~/UserControls/Lists/StyleNumberPlanningFitsInfo.ascx", properties);
        }


        //[WebMethod(EnableSession = true)]
        //public string ManageOrderFitsInfoPopup(string StyleNumber, int DepartmentID, int OrderDetailID)
        //{
        //    Dictionary<string, object> properties = new Dictionary<string, object>();
        //    properties.Add("StyleNumber", StyleNumber);
        //    properties.Add("DepartmentID", DepartmentID);
        //    properties.Add("OrderDetailID", OrderDetailID);
        //    return PageHelper.GetControlHtml("~/UserControls/Lists/ManageOrderFitsInfoPopup.ascx", properties);
        //}

        //Edited by Ashish on 31/7/2015
        [WebMethod(EnableSession = true)]
        public string ManageOrderFitsInfoPopup(string StyleNumber, int DepartmentID, int OrderDetailID, int StyleId, string StyleNo, string FitsStyle, int StrClientId)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleNumber", StyleNumber);
            properties.Add("DepartmentID", DepartmentID);
            properties.Add("OrderDetailID", OrderDetailID);

            properties.Add("StyleId", StyleId);
            properties.Add("StyleNo", StyleNo);
            properties.Add("FitsStyle", FitsStyle);
            properties.Add("StrClientId", StrClientId);
            return PageHelper.GetControlHtml("~/UserControls/Lists/ManageOrderFitsInfoPopup.ascx", properties);
        }
        //END



        [WebMethod(EnableSession = true)]
        public void StyleFileInsertOwnerInfo(int OrderDetailID, int FitsOwnerID, int FabricOwnerID, string FitsRemarks, string FabricRemarks, string PlannedDispatchDate, int FitsTrackID)
        {
            //System.Diagnostics.Debugger.Break();
            DateTime PlannedDate = DateHelper.ParseDate(PlannedDispatchDate.ToString()).Value;
            this.OrderControllerInstance.StyleFileInsertOwnerInfo(OrderDetailID, FitsOwnerID, FabricOwnerID, FitsRemarks, FabricRemarks, PlannedDate, FitsTrackID);
        }

        [WebMethod(EnableSession = true)]
        public string ShowClientSummary(int ClientID)
        {

            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("ClientId", ClientID);

            return PageHelper.GetControlHtml("~/UserControls/Lists/ClientSummary.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string ShowStyleNumberPlanningImages(string StyleID, string PrintNumber)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleID", StyleID);
            properties.Add("PrintNumber", PrintNumber);

            return PageHelper.GetControlHtml("~/UserControls/Lists/StyleNumberPlanningShowImages.ascx", properties);
        }
        [WebMethod(EnableSession = true)]
        public string GetOrdersBasicInfoReport(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("searchText", searchText);
            properties.Add("FromDate", FromDate);
            properties.Add("ToDate", ToDate);
            properties.Add("ClientId", ClientID);
            return PageHelper.GetControlHtml("~/UserControls/Reports/OrderSummary.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetOrdersFabricReport(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("searchText", searchText);
            properties.Add("FromDate", FromDate);
            properties.Add("ToDate", ToDate);
            properties.Add("ClientId", ClientID);
            return PageHelper.GetControlHtml("~/UserControls/Reports/OrderSummaryFabricReport.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetOrderAccessoriesReport(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("searchText", searchText);
            properties.Add("FromDate", FromDate);
            properties.Add("ToDate", ToDate);
            properties.Add("ClientId", ClientID);
            return PageHelper.GetControlHtml("~/UserControls/Reports/OrderSummaryAccessoriesReport.ascx", properties);
        }
        [WebMethod(EnableSession = true)]
        public string GetOrderCuttingReport(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("searchText", searchText);
            properties.Add("FromDate", FromDate);
            properties.Add("ToDate", ToDate);
            properties.Add("ClientId", ClientID);
            return PageHelper.GetControlHtml("~/UserControls/Reports/OrderSummaryCuttingReport.ascx", properties);
        }


        [WebMethod(EnableSession = true)]
        public string GetOrderStichingReport(string searchText, DateTime FromDate, DateTime ToDate, int ClientID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("searchText", searchText);
            properties.Add("FromDate", FromDate);
            properties.Add("ToDate", ToDate);
            properties.Add("ClientId", ClientID);
            return PageHelper.GetControlHtml("~/UserControls/Reports/OrderSummaryStichingReport.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string ShowClientSummaryReport(int ClientID)
        {

            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("ClientId", ClientID);

            return PageHelper.GetControlHtml("~/UserControls/Reports/ClientSummaryReport.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public void UpdateRemarks(int Id1, int Id2, string Remarks, string Type, string ApplicationModuleName)
        {
            //System.Diagnostics.Debugger.Break();
            string userName = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            string dateToday = DateTime.Today.ToString("dd MMM");
            string NewRemarks = Remarks;
            if (NewRemarks.Trim() != string.Empty)
            {
                NewRemarks = userName + " " + "(" + dateToday + ")" + " " + " : " + Remarks + " ";
            }
            else
            {
                NewRemarks = string.Empty;
            }
            // NewRemarks.Replace('"', ' ');
            this.OrderControllerInstance.UpdateRemarks(Id1, Id2, NewRemarks, Type, ApplicationModuleName);
        }

        // Update By Ravi kumar ON 2/2/2015 For MO pcd change on Sanjeev Remark
        [WebMethod(EnableSession = true)]
        public void UpdateRemarksSanjeev(string Remarks, string Ids, string ExFactoryDate, int IsPcDateChanged)
        {
            //System.Diagnostics.Debugger.Break();
            string userName = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            string dateToday = DateTime.Today.ToString("dd MMM");
            string NewRemarks = Remarks.Trim();
            if (NewRemarks.Trim() != string.Empty)
            {
                NewRemarks = userName + " " + "(" + dateToday + ")" + " " + " : " + Remarks + " ";
            }
            else
            {
                NewRemarks = string.Empty;
            }
            // NewRemarks.Replace('"', ' ');
            this.OrderControllerInstance.UpdateRemarksSanjeev(NewRemarks, Ids, ExFactoryDate.Trim(), IsPcDateChanged);
        }

        // End By Ravi kumar ON 17/12/2014 For MO pcd change on shiping remark
        /// <summary>
        /// new by Yaten
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        /// 
        [WebMethod(EnableSession = true)]
        public void SaveResolution(string VarOwnerIdS, string varstatus1, string TargetDate, int Id1, int Id2, string Remarks, string Type, string ApplicationModuleName)
        {
            //System.Diagnostics.Debugger.Break();
            string userName = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            string dateToday = DateTime.Today.ToString("dd MMM");
            string NewRemarks = Remarks;
            if (NewRemarks.Trim() != string.Empty)
            {
                NewRemarks = userName + " " + "(" + dateToday + ")" + " " + " : " + Remarks + " ";
            }
            else
            {
                NewRemarks = string.Empty;
            }
            this.OrderControllerInstance.SaveResolution1(VarOwnerIdS, varstatus1, TargetDate, Id1, Id2, NewRemarks, Type, ApplicationModuleName);
        }

        [WebMethod(EnableSession = true)]
        public int GetDefaultLeadTime(int mode)
        {
            return iKandi.BLL.CommonHelper.GetDefaultLeadTimeById(mode);
        }

        [WebMethod(EnableSession = true)]
        public Boolean SendEmailForEditOrder(string OrderHtml, string Attachments, int ClientID)
        {
            List<string> AttachmentsList = new List<string>();
            if (Attachments != "")
            {
                if (Attachments.IndexOf("--") > -1)
                {
                    string[] delim = { "--" };
                    string[] AttachmentsArray = Attachments.Split(delim, StringSplitOptions.None);
                    for (int i = 0; i < AttachmentsArray.Length; i++)
                    {
                        AttachmentsList.Add(AttachmentsArray[i]);
                    }
                }
                else
                {
                    AttachmentsList.Add(Attachments);
                }
            }

            NotificationController nc = new NotificationController();
            return nc.SendEmailForEditOrder(OrderHtml, "", AttachmentsList, ClientID, true, 2, "");
        }

        [WebMethod(EnableSession = true)]
        public void submitForm(string updatedString)
        {
            //System.Diagnostics.Debugger.Break();

            int OrderDetailID = 0;
            double ikandiPrice = 0;
            string history = "";
            List<string> updatedStringList = new List<string>();
            if (updatedString != "")
            {
                if (updatedString.IndexOf("$$") > -1)
                {
                    string[] delim = { "$$" };
                    string[] updatedStringArray = updatedString.Split(delim, StringSplitOptions.None);
                    for (int i = 0; i < updatedStringArray.Length; i++)
                    {
                        updatedStringList.Add(updatedStringArray[i].Trim());
                    }
                }
                else
                {
                    updatedStringList.Add(updatedString.Trim());
                }

                foreach (string str in updatedStringList)
                {
                    if (str.IndexOf("~") > -1)
                    {
                        string[] delim = { "~" };
                        string[] strArray = str.Split(delim, StringSplitOptions.None);
                        OrderDetailID = Convert.ToInt32(strArray[0].Trim());
                        ikandiPrice = Convert.ToDouble(strArray[1].Trim());
                        double oldikandiPrice = Convert.ToDouble(strArray[2].Trim());
                        string contractNo = strArray[3].Trim();
                        history = DateTime.Now.ToString("dd MMM yy (ddd)") + ": " + contractNo + " : " + "iKandi Price changed by " + ApplicationHelper.LoggedInUser.UserData.FullName.ToUpper() + " " + ikandiPrice + " was " + oldikandiPrice;
                    }

                    this.OrderControllerInstance.UpdateikandiPrice(OrderDetailID, ikandiPrice, history);
                }
            }
        }

        [WebMethod(EnableSession = true)]
        public string showStatusMeeting(int OrderDetailID)
        {

            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("OrderDetailID", OrderDetailID);
            return PageHelper.GetControlHtml("~/UserControls/Lists/StatusMeetingPopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetExfactoryQuantityReport()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            return PageHelper.GetControlHtml("~/UserControls/Reports/ExFactoryQuantity.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetAllOrdersOnStyle(string StyleNumber, string OrderIDList, bool AllOrders)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleNumber", StyleNumber);
            properties.Add("OrderIDList", OrderIDList);
            properties.Add("AllOrders", AllOrders);

            return PageHelper.GetControlHtml("~/UserControls/Reports/AllOrdersOnStyle.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GetBIPLOrderPriceDetails(int StyleId)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleId", StyleId);

            return PageHelper.GetControlHtml("~/UserControls/Forms/BIPLOrderPrice.ascx", properties);
        }
        [WebMethod(EnableSession = true)]
        public string GetIkandiOrderPriceDetails(int StyleId)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleId", StyleId);

            return PageHelper.GetControlHtml("~/UserControls/Forms/IkandiOrderPrice.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public int UpdateBIPLPrice(int OrderId, float AgreedPrice)
        {
            return CostingControllerInstance.UpdateBIPLPrice(OrderId, AgreedPrice);
        }
        [WebMethod(EnableSession = true)]
        public int UpdateIkandiPrice(int OrderId, float AgreedPrice)
        {
            return CostingControllerInstance.UpdateIkandiPrice(OrderId, AgreedPrice);
        }
        [WebMethod(EnableSession = true)]
        public int UpdateFabric_Color_Print(int OrderId)
        {
            return CostingControllerInstance.UpdateFabric_Color_Print(OrderId);
        }

        [WebMethod(EnableSession = true)]
        public int CheckExistingSerialNumber(int OrderID, string SerialNumber, int Type)
        {
            return this.OrderControllerInstance.CheckExistingSerialNumber(OrderID, SerialNumber, Type);
        }




        [WebMethod(EnableSession = true)]
        public Invoice GetBiplInvoiceQuantityByInvoiceID(int InvoiceID)
        {
            //System.Diagnostics.Debugger.Break();
            int totalInvoiceQuantity = 0;
            string invoiceNumber = "";
            string PackingIds = "";
            List<iKandi.Common.Invoice> InvoiceCollection = this.InvoiceControllerInstance.GetBiplInvoiceDataByInvoiceID(InvoiceID);

            InvoiceCollection.ForEach(delegate(Invoice inv) { totalInvoiceQuantity += inv.Quantity; });
            InvoiceCollection.ForEach(delegate(Invoice inv) { invoiceNumber += inv.InvoiceNo; });
            InvoiceCollection.ForEach(delegate(Invoice inv) { PackingIds += inv.PackingIDs; });

            invoiceNumber = invoiceNumber.Remove(invoiceNumber.LastIndexOf(","));
            //PackingIds = PackingIds.Remove(PackingIds.LastIndexOf(","));

            Invoice invoice = new Invoice();
            invoice.Quantity = totalInvoiceQuantity;
            if (InvoiceCollection.Count > 1)
            {
                invoice.InvoiceComments = "Invoice Number " + invoiceNumber + " has been marged ";
                invoice.PackingIDs = PackingIds;
            }
            else
            {
                invoice.InvoiceComments = string.Empty;
                invoice.PackingIDs = PackingIds;
            }
            return invoice;
        }





        [WebMethod(EnableSession = true)]
        public int GetLiabilityByContractNumber(string ContractNumber)
        {
            int OrderDetailID = -1;
            OrderDetailID = this.LiabilityControllerInstance.GetOrderDetailIDByContractNumber(ContractNumber);
            return OrderDetailID;
        }

        [WebMethod(EnableSession = true)]
        public void InsertLiabilityMerchantRemarks(int OrderDetailID, string Remarks, int Option)
        {
            //System.Diagnostics.Debugger.Break();
            if (Option == 1)
            {
                this.LiabilityControllerInstance.InsertLiabilityMerchantRemarks(OrderDetailID, Remarks, 2);
            }
            else
            {
                this.LiabilityControllerInstance.InsertLiabilityMerchantRemarks(OrderDetailID, Remarks, 5);
            }

            if (Option == 1)
            {
                iKandi.Common.Liability liability = this.LiabilityControllerInstance.GetLiabilityData(OrderDetailID, -1);
                //this.NotificationControllerInstance.SendCancelledOrderEmail(OrderDetailID, liability.QuantityCancelled, liability.MerchantRemarks);

                UserTask task = new UserTask();
                task.AssignedToDesigntation = (int)Designation.BIPL_Logistics_Manager;
                task.CreatedBy = ApplicationHelper.LoggedInUser.UserData.UserID;
                task.CreatedOn = DateTime.Now;
                task.ETA = DateTime.Now;
                task.OrderDetail = new iKandi.Common.OrderDetail();
                task.OrderDetail.OrderDetailID = OrderDetailID;
                task.IntField1 = liability.Id;
                task.Type = UserTaskType.OrderCancellation;
                this.UserTaskControllerInstance.InsertUserTask(task);
            }
            else
            {
                iKandi.Common.Liability liability = this.LiabilityControllerInstance.GetLiabilityData(OrderDetailID, -1);
                //this.NotificationControllerInstance.SendCancelledOrderEmail_NoLiability(OrderDetailID, liability.QuantityCancelled, liability.MerchantRemarks);
            }
        }

        [WebMethod(EnableSession = true)]
        public int FindOrderIDBreakdownByBuyerAndContract(int ClientID, string Contract)
        {
            return this.OrderControllerInstance.FindOrderIDBreakdownByBuyerAndContract(ClientID, Contract);
        }

        [WebMethod(EnableSession = true)]
        public string GetOrderBreakdownByBuyerAndContractView(int ClientID, string Contract)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("BuyerID", ClientID);
            properties.Add("Contract", Contract);

            return PageHelper.GetControlHtml("~/UserControls/Lists/OrdersByBuyerAndContract.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string ShowMOCutStitchPackHistoryPopup(int OrderDetailId, int Type)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("OrderDetailId", OrderDetailId);
            properties.Add("Type", Type);

            return PageHelper.GetControlHtml("~/UserControls/Lists/MOCutStitchPackHistoryPopup.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string ShowClientDetailsPopup(int ClientId)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("ClientId", ClientId);

            return PageHelper.GetControlHtml("~/UserControls/View/ClientView.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public bool SetIkandiInvoiceVisible(int InvoiceId, string Details)
        {
            return this.InvoiceControllerInstance.SetIkandiInvoiceVisible(InvoiceId, Details);
        }

        //manisha added on 2/24/2011
        #region Manisha New Methods
        [WebMethod(EnableSession = true)]
        public string GetReminderDetails(string task, int type)
        {
            return this.OrderControllerInstance.GetReminderDetails(task, type);
        }

        [WebMethod(EnableSession = true)]
        public string SaveReminderDetails1(string orderDetailId, string OrderId, string taskId, string desc, string date)
        {
            DateTime dt;

            if (date == "")
            {
                dt = DateTime.MinValue;
            }
            else dt = Convert.ToDateTime(date);

            return this.OrderControllerInstance.SaveReminderDetails(Convert.ToInt32(orderDetailId), Convert.ToInt32(OrderId), Convert.ToInt32(taskId), desc, dt, System.DateTime.Now, ApplicationHelper.LoggedInUser.UserData.UserID);
        }

        [WebMethod(EnableSession = true)]
        public string SaveReminderDetails(string ixml)
        {
            //manisha added on 1 march 2011
            return this.OrderControllerInstance.SaveReminderDetails(ixml, ApplicationHelper.LoggedInUser.UserData.UserID);
        }

        [WebMethod(EnableSession = true)]
        public string UpdateReminderDetails(string orderDetailId, string orderId, string taskId)
        {
            return this.OrderControllerInstance.UpdateReminderDetails(Convert.ToInt32(orderDetailId), Convert.ToInt32(orderId), Convert.ToInt32(taskId), System.DateTime.Now, ApplicationHelper.LoggedInUser.UserData.UserID);
        }

        [WebMethod(EnableSession = true)]
        public List<Reminders> FetchReminderDetails(string orderId)
        {
            return this.OrderControllerInstance.FetchReminderDetails(Convert.ToInt32(orderId), ApplicationHelper.LoggedInUser.UserData.UserID);
        }

        #endregion
        // end

        //Ashish Added on 22/8/2014

        //added by abhishek 26/10/2015
        [WebMethod(EnableSession = true)]
        public int InsertAvailableMin(int CMTId, float Cost, float Hour, int BarrierDays, int hdnUId, float txtpro_availble_mincost, float pro_hours, int maxload, int createobdays, int barrirday)
        {
            iKandi.BLL.CmtAdmin.CmtAdminController obj_CmtAdmin = new BLL.CmtAdmin.CmtAdminController();
            return obj_CmtAdmin.UpdateCMTAdmin(CMTId, Cost, Hour, BarrierDays, hdnUId, txtpro_availble_mincost, pro_hours, maxload, createobdays, barrirday);
        }
        //end by abhishek 26/10/2015

        //added by bharat on 25-july
        [WebMethod(EnableSession = true)]
        public int InsertCRTOrderQty(int textval, int Sr_No,string  Flag)
        {
            iKandi.BLL.CmtAdmin.CmtAdminController obj_CmtAdmin = new BLL.CmtAdmin.CmtAdminController();
            return obj_CmtAdmin.InsertCRTOrderQty(textval, Sr_No, Flag);
        }
      

        //End  

        [WebMethod(EnableSession = true)]
        public bool UpdateLineNo(int OrderDetailID, string Changevalue, string Flag)
        {
            return OrderControllerInstance.UpdateLineNo(OrderDetailID, Changevalue, Flag);
        }

        [WebMethod(EnableSession = true)]
        public bool UpdateDescription(int styleid, string Changevalue, string Flag)
        {
            return OrderControllerInstance.UpdateDescription(styleid, Changevalue, Flag);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateWeight(int styleid, string Changevalue, string Flag)
        {
            return OrderControllerInstance.UpdateWeight(styleid, Changevalue, Flag);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateStyleRemarks(int styleid, string Remarks)
        {
            Remarks = Remarks.Replace("<", " ");
            Remarks = Remarks.Replace(">", " ");
            Remarks = Remarks.Replace("~", " ");
            Remarks = ApplicationHelper.LoggedInUser.UserData.FirstName + " (" + DateTime.Now.ToString("dd MMM") + ") : " + Remarks;
            return StyleControllerInstance.UpdateStyleRemarks(styleid, Remarks);
        }
        [WebMethod(EnableSession = true)]
        public bool sendcontactmail(string name, string email, string phone, string msg)
        {
            NotificationController objemail = new NotificationController();

            return objemail.SendContactusEmail(name, email, phone, msg);
        }

        //Added By Ashish on 14/11/2014
        [WebMethod(EnableSession = true)]
        public List<CMTSizeAdmin> GetSizeSetAdmin()
        {
            iKandi.BLL.CmtAdmin.CmtAdminController obj_CmtAdmin = new BLL.CmtAdmin.CmtAdminController();
            return obj_CmtAdmin.GetSizeSetAdmin();
        }
        [WebMethod(EnableSession = true)]
        public bool DeleteSession(string session)
        {
            return OrderControllerInstance.DeleteSession(System.Web.HttpContext.Current.Session.SessionID);
        }

        [WebMethod(EnableSession = true)]
        public List<CMTSizeAdmin> GetSizeSetById(int Option)
        {
            iKandi.BLL.CmtAdmin.CmtAdminController obj_CmtAdmin = new BLL.CmtAdmin.CmtAdminController();
            return obj_CmtAdmin.GetSizeSetById(Option);
        }

        [WebMethod(EnableSession = true)]
        public List<OrderDetail> GetSizeSetOption(int clientId, int DeptId)
        {
            return OrderControllerInstance.GetSizeSetOption(clientId, DeptId);
        }
        [WebMethod(EnableSession = true)]
        public string showEtaPopup_stitch(string Flag1, string Flag2, int StyleId, string Val1, string Val2, string SDate, string EDate, string remark, string SerialNumber, int ColumnId, string Days = "")
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("Flag1", Flag1);
            properties.Add("Flag2", Flag2);
            properties.Add("StyleId", StyleId);
            properties.Add("Val1", Val1);
            properties.Add("Val2", Val2);
            properties.Add("SDate", SDate);
            properties.Add("EDate", EDate);
            properties.Add("remark", remark);
            properties.Add("SerialNumber", SerialNumber);
            properties.Add("Days", Days);
            properties.Add("ColumnId", ColumnId);

            return PageHelper.GetControlHtml("~/UserControls/Lists/MOEtaPopup.ascx", properties);
        }
        [WebMethod(EnableSession = true)]
        public string showEtaPopup(string Flag1, string Flag2, int StyleId, string Val1, string Val2, string SDate, string EDate, string remark, string SerialNumber, int ColumnId)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("Flag1", Flag1);
            properties.Add("Flag2", Flag2);
            properties.Add("StyleId", StyleId);
            properties.Add("Val1", Val1);
            properties.Add("Val2", Val2);
            properties.Add("SDate", SDate);
            properties.Add("EDate", EDate);
            properties.Add("remark", remark);
            properties.Add("SerialNumber", SerialNumber);
            properties.Add("ColumnId", ColumnId);


            return PageHelper.GetControlHtml("~/UserControls/Lists/MOEtaPopup.ascx", properties);
        }

        //Added By Ravi on 20/1/2015 for Limitation form
        [WebMethod(EnableSession = true)]
        public string[] GetCMTbyOrderID(int OrderID, int BarrierDay)
        {
            return OrderControllerInstance.GetCMTbyOrderID(OrderID, BarrierDay);
        }
        //END By Ravi on 20/1/2015 for Limitation form
        [WebMethod(EnableSession = true)]
        public string UpdateEtaRemarks(string Flag1, string Flag2, string remarks, string Name, string ids, string SDate, string EDate, string StyleId, string AccessoryWorkingID)
        {//abhishek on 7/9/2015
            //System.Diagnostics.Debugger.Break();
            string result;
            string userName = iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData.FirstName;
            string dateToday = DateTime.Today.ToString("dd MMM");
            string strSubSection = "";
            string NewRemarks = remarks;

            //updated by abhishek on 18/12/2015
            if (Flag1 == "Fabric")
            {
                //NewRemarks = "Fabric ETA" + " : " + userName + " " + "(" + dateToday + ")" + " " + Name + " " + " BIH start (" + SDate + ") and BIH End (" + EDate + ")" + " : " + NewRemarks;
                NewRemarks = userName + " : " + "(" + dateToday + ")" + " " + " " + " BIH start (" + SDate + ") and BIH End (" + EDate + ")" + " : " + NewRemarks;
            }
            if (Flag1 == "Access")
            {
                //NewRemarks = "Accessories ETA" + " : " + userName + " " + "(" + dateToday + ")" + " " + Name + " " + "BIH End (" + EDate + ") " + " : " + NewRemarks;
                NewRemarks = userName + " : " + "(" + dateToday + ")" + " " + " " + "BIH End (" + EDate + ") " + " : " + NewRemarks;
            }
            //end by abhishek on 18/12/2015
            if (Flag1 == "Cut Ready")
            {
                strSubSection = "Cut Ready";
                NewRemarks = "Cut Ready ETA" + " : " + userName + " " + "(" + dateToday + ")" + " " + strSubSection + " " + "BIH start (" + SDate + ") and BIH End (" + EDate + ") " + " : " + NewRemarks;
            }
            if (Flag1 == "Stitched")
            {
                strSubSection = "Stitched";
                NewRemarks = "Stitched ETA" + " : " + userName + " " + "(" + dateToday + ")" + " " + strSubSection + " " + "  BIH start (" + SDate + ") and BIH End (" + EDate + ") " + " : " + NewRemarks;
            }
            if (Flag1 == "Packed")
            {
                // NewRemarks = "Packed ETA" + " : " + userName + " " + "(" + dateToday + ")" + " " + Name + " : " + NewRemarks + "  and BIH start (" + SDate + ") and BIH End (" + EDate + ") ";
                strSubSection = "Packed";
                NewRemarks = "Packed ETA" + " : " + userName + " " + "(" + dateToday + ")" + " " + strSubSection + " " + "  BIH start (" + SDate + ")" + " : " + NewRemarks;
            }
            if (Flag1 == "Emb")
            {
                strSubSection = "V.A.";
                NewRemarks = "V.A. ETA" + " : " + userName + " " + "(" + dateToday + ")" + " " + strSubSection + " " + "  BIH start (" + SDate + ") and BIH End (" + EDate + ") " + " : " + NewRemarks;
            }
            if (Flag1 == "STCRequest")
            {
                strSubSection = "STC";
                NewRemarks = "STC ETA" + " : " + userName + " " + "(" + dateToday + ")" + " " + strSubSection + " " + " ETA (" + SDate + ") " + " : " + NewRemarks;
            }
            if (Flag1 == "TOPETA")
            {
                strSubSection = "TOP Sent";
                NewRemarks = "TOP ETA" + " : " + userName + " " + "(" + dateToday + ")" + " " + strSubSection + "" + " ETA (" + SDate + ") " + " : " + NewRemarks;
            }
            if (Flag1 == "STCApprovedETA")
            {
                strSubSection = "STCApproved";
                NewRemarks = "STCApproved ETA" + " : " + userName + " " + "(" + dateToday + ")" + " " + strSubSection + " " + " ETA (" + SDate + ") " + " : " + NewRemarks;
            }
            if (Flag1 == "PatternETA")
            {
                strSubSection = "Pattern Sample";
                NewRemarks = "Pattern ETA" + " : " + userName + " " + "(" + dateToday + ")" + " " + strSubSection + " " + " ETA (" + SDate + ") " + " : " + NewRemarks;
            }
            if (Flag1 == "FitsStatusETA")
            {
                strSubSection = "Fits Status";
                NewRemarks = "Fits ETA" + " : " + userName + " " + "(" + dateToday + ")" + " " + strSubSection + " " + " ETA (" + SDate + ") " + " : " + NewRemarks;
            }
            //}
            //else
            //{
            //    NewRemarks = string.Empty;
            //}
            // NewRemarks.Replace('"', ' ');



            //if (EDate == "")
            //   EDate = SDate;
            DateTime ETASDate = DateTime.Now;
            DateTime ETANdate = DateTime.Now;

            if (SDate != "")
            {
                ETASDate = DateTime.ParseExact(SDate, "dd MMM yy (ddd)", null);
            }
            if (EDate != "")
            {
                ETANdate = DateTime.ParseExact(EDate, "dd MMM yy (ddd)", null);
            }

            //DateTime ETASDate, ETANdate;                 
            //ETASDate = DateTime.ParseExact(SDate, "dd MMM yy (ddd)", null);
            //ETANdate = DateTime.ParseExact(EDate, "dd MMM yy (ddd)", null);
            if (EDate != "")
            {
                if (ETANdate >= ETASDate)
                {
                    this.OrderControllerInstance.UpdateEtaRemarks(Flag1, Flag2, NewRemarks, Name, ids, SDate, EDate, StyleId, AccessoryWorkingID);
                    result = "Remarks have been submitted successfully";
                }
                else
                {
                    result = "0";//"Start Date should be less Or equal End Date Please Check & Try Again !";
                }
            }
            else
            {
                this.OrderControllerInstance.UpdateEtaRemarks(Flag1, Flag2, NewRemarks, Name, ids, SDate, EDate, StyleId, AccessoryWorkingID);
                result = "Remarks have been submitted successfully";
            }


            return result;
        }

        //Added By Ravi on 19/2/2015 for Ship Check box
        [WebMethod(EnableSession = true)]
        public bool UpdateIsShiped(int OrderDetailsID, int IsShiped, string ShippedDate, int ShippedQty)
        {
            if (ShippedDate == "")
            {
                ShippedDate = DateTime.Now.ToString("dd MMM yy (ddd)");
            }
            DateTime Date = DateTime.Now;
            Date = DateTime.ParseExact(ShippedDate, "dd MMM yy (ddd)", null);

            return OrderControllerInstance.UpdateIsShiped(OrderDetailsID, IsShiped, Date, ShippedQty);
        }
        //Add By Ravi kumar on 4/4/2015 for shipment         
        [WebMethod(EnableSession = true)]
        public string[] GetShippedQty(int OrderDetailsID)
        {
            return OrderControllerInstance.GetShippedQty(OrderDetailsID);
        }
        //Add By Ravi kumar on 13/4/2015 for Sales View         
        [WebMethod(EnableSession = true)]
        public string GetWorkingDays(string sFromdate, string sTodate)
        {
            int Days_WithoutSunday = 0;
            DateTime FromDate = new DateTime();
            DateTime ToDate = new DateTime();
            if (sFromdate != "")
            {
                FromDate = Convert.ToDateTime(sFromdate);
            }
            if (sTodate != "")
            {
                ToDate = Convert.ToDateTime(sTodate);
            }

            DateTime TodayDate = DateTime.Now.Date;
            if (TodayDate > ToDate.Date)
            {
                Days_WithoutSunday = 1;
                return Days_WithoutSunday.ToString();
            }

            int DaysThisMonth = 0;
            if (TodayDate >= FromDate.Date)
            {
                DaysThisMonth = Convert.ToInt32((ToDate.Date - TodayDate).TotalDays);
                DaysThisMonth = DaysThisMonth + 1;
            }
            else
            {
                DaysThisMonth = Convert.ToInt32((ToDate.Date - FromDate.Date).TotalDays);
                DaysThisMonth = DaysThisMonth + 1;
            }

            int iSunday = 0;

            for (int i = 1; i < DaysThisMonth + 1; i++)
            {
                if (TodayDate.AddDays(i).DayOfWeek == DayOfWeek.Sunday)
                {
                    iSunday = iSunday + 1;
                }
            }

            Days_WithoutSunday = DaysThisMonth - iSunday;



            return Days_WithoutSunday.ToString();

        }
        //Added By abhishek 25/4/2015
        [WebMethod(EnableSession = true)]
        public List<BuyingHouse> GetBuyingHouselistById(int UserComapanyId, int ddlDateType, string ddlYear)
        {
            return this.objBuyingHouseController.GetBuyingHouselistById(UserComapanyId, ddlDateType, ddlYear);
        }
        [WebMethod(EnableSession = true)]
        public List<BuyingHouse> GetBuyingHouselistById_ForAM(int UserComapanyId, int ddlDateType, string ddlYear, int Ddlam)
        {
            return this.objBuyingHouseController.GetBuyingHouselistById_ForAM(UserComapanyId, ddlDateType, ddlYear, Ddlam);
        }
        [WebMethod(EnableSession = true)]
        public List<Client> GetClientDetailslist(int BuyingHouseId, int ClientId, int DateType, string YearRange, int UserID, int AM)//For fill Client Dropdown
        {
            //return this.objBuyingHouseController.GetBuyingHouselistById(UserComapanyId, ddlDateType, ddlYear);GetAllDeptByClientForManageOrder GetAllClientDetailsForManageOrder
            return this.Objprint.GetAllClientDetailsForManageOrder(BuyingHouseId, ClientId, DateType, YearRange, UserID, AM);
        }
        [WebMethod(EnableSession = true)]
        public List<Client> GetClientDetailslist_ForAM(int BuyingHouseId, int ClientId, int DateType, string YearRange, int UserID, int Ddlam)//For fill Client Dropdown
        {
            //return this.objBuyingHouseController.GetBuyingHouselistById(UserComapanyId, ddlDateType, ddlYear);GetAllDeptByClientForManageOrder GetAllClientDetailsForManageOrder
            return this.Objprint.GetClientDetailslist_ForAM(BuyingHouseId, ClientId, DateType, YearRange, UserID, Ddlam);
        }
        [WebMethod(EnableSession = true)]
        public List<Client> GetAMlist(int DateType, string YearRange)//For AM Fill  Dropdown
        {
            //return this.objBuyingHouseController.GetBuyingHouselistById(UserComapanyId, ddlDateType, ddlYear);GetAllDeptByClientForManageOrder GetAllClientDetailsForManageOrder
            return this.Objprint.GetAllAM(DateType, YearRange);
        }
        [WebMethod(EnableSession = true)]
        public List<Department> Get_Parent_DepartmentDetailslist(int intID, int UserID, bool IsClient, bool IsClientDept, int DateType, string YearRange, int AM)//For fill Department Dropdown
        {

            //return this.objBuyingHouseController.GetBuyingHouselistById(UserComapanyId, ddlDateType, ddlYear);GetAllDeptByClientForManageOrder GetAllClientDetailsForManageOrder
            return this.Objprint.Get_Parent_DepartmentDetailslist(intID, UserID, IsClient, IsClientDept, DateType, YearRange, AM);
        }
        [WebMethod(EnableSession = true)]
        public List<Department> GetDepartmentDetailslist(int intID, int UserID, bool IsClient, bool IsClientDept, int DateType, string YearRange, int AM, int ParentDepartmentID)//For fill Department Dropdown
        {

            //return this.objBuyingHouseController.GetBuyingHouselistById(UserComapanyId, ddlDateType, ddlYear);GetAllDeptByClientForManageOrder GetAllClientDetailsForManageOrder
            return this.Objprint.GetAllDepartmentDetailsbyId(intID, UserID, IsClient, IsClientDept, DateType, YearRange, AM, ParentDepartmentID);
        }
        [WebMethod(EnableSession = true)]
        public List<Department> GetDepartmentDetailslist_ForAM(int intID, int UserID, bool IsClient, bool IsClientDept, int DateType, string YearRange, int Ddlam)//For fill Department Dropdown
        {

            //return this.objBuyingHouseController.GetBuyingHouselistById(UserComapanyId, ddlDateType, ddlYear);GetAllDeptByClientForManageOrder GetAllClientDetailsForManageOrder
            return this.Objprint.GetDepartmentDetailslist_ForAM(intID, UserID, IsClient, IsClientDept, DateType, YearRange, Ddlam);
        }
        // ADD By Ravi
        [WebMethod(EnableSession = true)]
        public List<OrderFlow> CheckOrderProcess(int Styleid, int ClientId, int DeptID, int Whichtab = 1)
        {
            return this.OrderProcessFlowInstance.CheckOrderProcess(Styleid, ClientId, DeptID, Whichtab);
        }

        // For All Section
        //For piping
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBSamAll(int OperationId, string GarmentTypeId, string SamVal, string Flag)
        {
            return AdminControllerInstance.InsertUpdateStichingOBSamAll(OperationId, GarmentTypeId, SamVal, Flag);
        }

        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBALL(int OperationId, string OperationVal, string Flag, string gridFlag)
        {
            return AdminControllerInstance.InsertUpdateStichingOBALL(OperationId, OperationVal, Flag, gridFlag);
        }

        [WebMethod(EnableSession = true)]
        public int InsertOpationStichingAll(string OperationVal, string gridFlag)
        {
            return AdminControllerInstance.InsertOpationStichingAll(OperationVal, gridFlag);
        }


        //END
        //END
        //Added By Ashish on 29/6/2015
        [WebMethod(EnableSession = true)]
        public List<OBCutting> GetFactoryWorkSpaceOB(int OperationId)
        {
            return AdminControllerInstance.GetFactoryWorkSpaceOB(OperationId);
        }
        [WebMethod(EnableSession = true)]
        public List<OBCutting> GetFactoryWorkSpaceFront(int OperationId)
        {
            return AdminControllerInstance.GetFactoryWorkSpaceFront(OperationId);
        }
        [WebMethod(EnableSession = true)]
        public List<OBCutting> GetFactoryWorkSpaceBack(int OperationId)
        {
            return AdminControllerInstance.GetFactoryWorkSpaceBack(OperationId);
        }

        [WebMethod(EnableSession = true)]
        public List<OBCutting> GetFactoryWorkSpacecoller(int OperationId)
        {
            return AdminControllerInstance.GetFactoryWorkSpacecoller(OperationId);
        }
        [WebMethod(EnableSession = true)]
        public List<OBCutting> GetFactoryWorkSpacesleep(int OperationId)
        {
            return AdminControllerInstance.GetFactoryWorkSpacesleep(OperationId);
        }
        //
        [WebMethod(EnableSession = true)]
        public List<OBCutting> GetFactoryWorkSpaceneck(int OperationId)
        {
            return AdminControllerInstance.GetFactoryWorkSpaceneck(OperationId);
        }

        [WebMethod(EnableSession = true)]
        public List<OBCutting> GetFactoryWorkSpaceLining(int OperationId)
        {
            return AdminControllerInstance.GetFactoryWorkSpaceLining(OperationId);
        }

        [WebMethod(EnableSession = true)]
        public List<OBCutting> GetFactoryWorkSpacelower(int OperationId)
        {
            return AdminControllerInstance.GetFactoryWorkSpacelower(OperationId);
        }
        [WebMethod(EnableSession = true)]
        public List<OBCutting> GetFactoryWorkSpacebottom(int OperationId)
        {
            return AdminControllerInstance.GetFactoryWorkSpacebottom(OperationId);
        }
        [WebMethod(EnableSession = true)]
        public List<OBCutting> GetFactoryWorkSpaceassembly(int OperationId)
        {
            return AdminControllerInstance.GetFactoryWorkSpaceassembly(OperationId);
        }
        //
        [WebMethod(EnableSession = true)]
        public List<OBCutting> GetFactoryWorkSpaceStichingAll(int OperationId, string Flag)
        {
            return AdminControllerInstance.GetFactoryWorkSpaceStichingAll(OperationId, Flag);
        }

        [WebMethod(EnableSession = true)]
        public List<OBCutting> GetFactoryWorkSpaceFinishing(int OperationId)
        {
            return AdminControllerInstance.GetFactoryWorkSpaceFinishing(OperationId);
        }

        //Added By Ashish on 29/6/2015

        // For Stiching Neck 
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBSamNeck(int OperationId, string GarmentTypeId, string SamVal)
        {
            return AdminControllerInstance.InsertUpdateStichingOBSamNeck(OperationId, GarmentTypeId, SamVal);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBNeck(int OperationId, string OperationVal, string Flag)
        {
            return AdminControllerInstance.InsertUpdateStichingOBNeck(OperationId, OperationVal, Flag);
        }

        [WebMethod(EnableSession = true)]
        public int UpdateFinalOBProxy(int FinalOBID, int NoOfOperation, float Sam, float MachineCount, int FinalCount, string Comments, string Flag, int ClientID, int DeptId, string StyleCode, int StyleId, int ReUseStyleId, string IsReuse, int StyleSequence, float Factor)
        {
            return OrderControllerInstance.UpdateFinalOBProxy(FinalOBID, NoOfOperation, Sam, MachineCount, FinalCount, Comments, Flag, ClientID, DeptId, StyleCode, StyleId, ReUseStyleId, IsReuse, StyleSequence, Factor);
        }
        //For Cutting
        [WebMethod(EnableSession = true)]
        public int InsertUpdateCuttingOB(int OperationId, string OperationVal, string Flag)
        {
            return AdminControllerInstance.InsertUpdateCuttingOB(OperationId, OperationVal, Flag);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateCuttingOBSam(int OperationId, string GarmentTypeId, string SamVal)
        {
            return AdminControllerInstance.InsertUpdateCuttingOBSam(OperationId, GarmentTypeId, SamVal);
        }
        [WebMethod(EnableSession = true)]
        public int InsertOperation(string OperationVal)
        {
            return AdminControllerInstance.InsertOperation(OperationVal);
        }
        //For Finishing
        [WebMethod(EnableSession = true)]
        public int InsertUpdateFinishingOB(int OperationId, string OperationVal, string Flag)
        {
            return AdminControllerInstance.InsertUpdateFinishingOB(OperationId, OperationVal, Flag);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateFinishingOBSam(int OperationId, string GarmentTypeId, string SamVal)
        {
            return AdminControllerInstance.InsertUpdateFinishingOBSam(OperationId, GarmentTypeId, SamVal);
        }
        [WebMethod(EnableSession = true)]
        public int InsertFinishing(string OperationVal)
        {
            return AdminControllerInstance.InsertFinishing(OperationVal);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOB(int OperationId, string OperationVal, string Flag)
        {
            return AdminControllerInstance.InsertUpdateStichingOB(OperationId, OperationVal, Flag);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBSam(int OperationId, string GarmentTypeId, string SamVal)
        {
            return AdminControllerInstance.InsertUpdateStichingOBSam(OperationId, GarmentTypeId, SamVal);
        }
        [WebMethod(EnableSession = true)]
        public int InsertStichingFont(string OperationVal)
        {
            return AdminControllerInstance.InsertStiching(OperationVal);
        }


        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBBack(int OperationId, string OperationVal, string Flag)
        {
            return AdminControllerInstance.InsertUpdateStichingOBBack(OperationId, OperationVal, Flag);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBSamBack(int OperationId, string GarmentTypeId, string SamVal)
        {
            return AdminControllerInstance.InsertUpdateStichingOBSamBack(OperationId, GarmentTypeId, SamVal);
        }
        [WebMethod(EnableSession = true)]
        public int InsertStichingBack(string OperationVal)
        {
            return AdminControllerInstance.InsertStichingBack(OperationVal);
        }
        [WebMethod(EnableSession = true)]
        public int InsertStichingneck(string OperationVal)
        {
            return AdminControllerInstance.InsertStichingneck(OperationVal);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBSamLining(int OperationId, string GarmentTypeId, string SamVal)
        {
            return AdminControllerInstance.InsertUpdateStichingOBSamLining(OperationId, GarmentTypeId, SamVal);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBLining(int OperationId, string OperationVal, string Flag)
        {
            return AdminControllerInstance.InsertUpdateStichingOBLining(OperationId, OperationVal, Flag);
        }
        [WebMethod(EnableSession = true)]
        public int InsertStichingLining(string OperationVal)
        {
            return AdminControllerInstance.InsertStichingLining(OperationVal);
        }
        // For Stiching Lower
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBSamLower(int OperationId, string GarmentTypeId, string SamVal)
        {
            return AdminControllerInstance.InsertUpdateStichingOBSamLower(OperationId, GarmentTypeId, SamVal);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBLower(int OperationId, string OperationVal, string Flag)
        {
            return AdminControllerInstance.InsertUpdateStichingOBLower(OperationId, OperationVal, Flag);
        }
        [WebMethod(EnableSession = true)]
        public int InsertStichingLower(string OperationVal)
        {
            return AdminControllerInstance.InsertStichingLower(OperationVal);
        }
        // For Stiching bottom
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBSambottom(int OperationId, string GarmentTypeId, string SamVal)
        {
            return AdminControllerInstance.InsertUpdateStichingOBSambottom(OperationId, GarmentTypeId, SamVal);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBbottom(int OperationId, string OperationVal, string Flag)
        {
            return AdminControllerInstance.InsertUpdateStichingOBbottom(OperationId, OperationVal, Flag);
        }
        [WebMethod(EnableSession = true)]
        public int InsertStichingbottm(string OperationVal)
        {
            return AdminControllerInstance.InsertStichingbottm(OperationVal);
        }
        // For Stiching assembly
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBSamassembly(int OperationId, string GarmentTypeId, string SamVal)
        {
            return AdminControllerInstance.InsertUpdateStichingOBSamassembly(OperationId, GarmentTypeId, SamVal);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBassembly(int OperationId, string OperationVal, string Flag)
        {
            return AdminControllerInstance.InsertUpdateStichingOBassembly(OperationId, OperationVal, Flag);
        }
        [WebMethod(EnableSession = true)]
        public int InsertStichingassembly(string OperationVal)
        {
            return AdminControllerInstance.InsertStichingassembly(OperationVal);
        }
        // For Stiching coller 
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBcoller(int OperationId, string OperationVal, string Flag)
        {
            return AdminControllerInstance.InsertUpdateStichingOBcoller(OperationId, OperationVal, Flag);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBSamcoller(int OperationId, string GarmentTypeId, string SamVal)
        {
            return AdminControllerInstance.InsertUpdateStichingOBSamcoller(OperationId, GarmentTypeId, SamVal);
        }
        [WebMethod(EnableSession = true)]
        public int InsertOperationcoller(string OperationVal)
        {
            return AdminControllerInstance.InsertStichingcoller(OperationVal);
        }
        // For Stiching sleep 
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBsleep(int OperationId, string OperationVal, string Flag)
        {
            return AdminControllerInstance.InsertUpdateStichingOBsleep(OperationId, OperationVal, Flag);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBSamsleep(int OperationId, string GarmentTypeId, string SamVal)
        {
            return AdminControllerInstance.InsertUpdateStichingOBSamsleep(OperationId, GarmentTypeId, SamVal);
        }
        [WebMethod(EnableSession = true)]
        public int InsertOperationsleep(string OperationVal)
        {
            return AdminControllerInstance.InsertStichingsleep(OperationVal);
        }

        //Added By Ashish On 17/7/2015

        [WebMethod(EnableSession = true)]
        public int InsertUpdateManpowerWorker(int WorkerCount, int ProductionId, int WorkforceId, int id, int catergoryattdence, string ot_date, int Workinghours)
        {
            return this.AdminControllerInstance.InsertUpdateManpowerWorker(WorkerCount, ProductionId, WorkforceId, id, catergoryattdence, ot_date, Workinghours);
        }


        [WebMethod(EnableSession = true)]
        public int InsertUpdateOTManpower(int WorkerCount, int ProductionId, int WorkforceId, int id, int OTId, string OT_date, int Workinghours)
        {
            return this.AdminControllerInstance.InsertUpdateOTManpower(WorkerCount, ProductionId, WorkforceId, id, OTId, OT_date, Workinghours);
        }

        //Added By Ashish on 18/8/2015

        [WebMethod(EnableSession = true)]
        public List<CommonClass> calcBudget(int WorkforceId, int ProductionUnit, string OTDate, int OTs)
        {
            List<CommonClass> Listdsbudget = new List<CommonClass>();
            try
            {

                DataTable dtbudget = new DataTable();
                dtbudget = AdminControllerInstance.GetManPowerCountByUnitId(WorkforceId, ProductionUnit, OTDate, OTs);
                if (dtbudget.Rows.Count > 0)
                {
                    int count = dtbudget.Rows.Count;
                    for (int i = 0; i <= count - 1; i++)
                    {
                        CommonClass CommonVal = new Common.Entities.CommonClass();
                        CommonVal.val1 = Convert.ToInt32(dtbudget.Rows[i]["TotalBudget"]);
                        CommonVal.val2 = Convert.ToInt32(dtbudget.Rows[i]["Consummed"].ToString());

                        Listdsbudget.Add(CommonVal);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return Listdsbudget;
        }

        //END


        [WebMethod(EnableSession = true)]
        public string IsOBRiskDone(int StyleId, string Flag)
        {
            return this.WorkflowControllerInstance.IsOBRiskDone(StyleId, -1, Flag);
        }



        //added by abhishek on 12/8/2015 for line designation
        [WebMethod(EnableSession = true)]
        public int updateSlot(int DesignationID, int factoryId, int IsAct, int UserId, string Names, int id, int stiching, int finishing, int cutting)
        {
            return AdminControllerInstance.updateSlot(DesignationID, factoryId, IsAct, UserId, Names, id, stiching, finishing, cutting);
        }
        //for loss destribution
        //abhishek on 20/8/2015
        [WebMethod(EnableSession = true)]
        public int UpdateLossDesignation(int Dept_name, int Isactive, int UserId, int id, int stiching, int finishing, int cutting)
        {
            return AdminControllerInstance.UpdateLossDesignation(Dept_name, Isactive, UserId, id, stiching, finishing, cutting);
        }
        //end on 20/8/2015
        //END line Designation
        [WebMethod(EnableSession = true)] //for slot admin 
        public string updateSlotadmin(string SlotName, int TypeOfSlot, string start_HH, string start_MM, string End_HH, string End_MM, int id)
        {
            return AdminControllerInstance.updateSlotadmin(SlotName, TypeOfSlot, start_HH, start_MM, End_HH, End_MM, id);
        }
        //Abhishek 19/10/2015
        [WebMethod(EnableSession = true)]
        public string SlotExistCheck(string SlotName, int SlotID)
        {
            return AdminControllerInstance.SlotExistCheck(SlotName, SlotID);
        }
        //End abhishek 19/10/2015
        //----------------------------------End-------------------------------------------------------------//

        //END 

        //Added By Ashish on 14/8/2015
        [WebMethod(EnableSession = true)]
        public List<FactoryAdmin> GetDesignationnames(int FactoryId, string strId)
        {
            List<FactoryAdmin> ListFactoryAdmin = new List<FactoryAdmin>();

            DataSet dsFactory = new DataSet();
            dsFactory = AdminControllerInstance.GetFactorynames(FactoryId, strId);
            if (dsFactory.Tables[3].Rows.Count > 0)
            {
                int count = dsFactory.Tables[3].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    FactoryAdmin FactoryAdmin = new Common.Entities.FactoryAdmin();
                    FactoryAdmin.Id = Convert.ToInt32(dsFactory.Tables[3].Rows[i]["id"]);
                    FactoryAdmin.Name = dsFactory.Tables[3].Rows[i]["Name"].ToString();
                    FactoryAdmin.DesignationId = dsFactory.Tables[3].Rows[i]["LineDesignationID"].ToString();

                    ListFactoryAdmin.Add(FactoryAdmin);
                }

            }
            return ListFactoryAdmin;
        }


        [WebMethod(EnableSession = true)]
        public List<FactoryAdmin> GetFloorNames(int FactoryId)
        {
            List<FactoryAdmin> ListFactoryAdmin = new List<FactoryAdmin>();

            DataSet dsFactory = new DataSet();
            dsFactory = AdminControllerInstance.GetFactorynames(FactoryId, "");
            if (dsFactory.Tables[1].Rows.Count > 0)
            {
                int count = dsFactory.Tables[1].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    FactoryAdmin FactoryAdmin = new Common.Entities.FactoryAdmin();
                    FactoryAdmin.Id = Convert.ToInt32(dsFactory.Tables[1].Rows[i]["id"]);
                    FactoryAdmin.Name = dsFactory.Tables[1].Rows[i]["Name"].ToString();

                    ListFactoryAdmin.Add(FactoryAdmin);
                }

            }
            return ListFactoryAdmin;
        }

        [WebMethod(EnableSession = true)]
        public List<FactoryAdmin> GetLineNames(int FactoryId)
        {
            List<FactoryAdmin> ListFactoryAdmin = new List<FactoryAdmin>();

            DataSet dsFactory = new DataSet();
            dsFactory = AdminControllerInstance.GetFactorynames(FactoryId, "");
            if (dsFactory.Tables[2].Rows.Count > 0)
            {
                int count = dsFactory.Tables[2].Rows.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    FactoryAdmin FactoryAdmin = new Common.Entities.FactoryAdmin();
                    FactoryAdmin.Id = Convert.ToInt32(dsFactory.Tables[2].Rows[i]["id"]);
                    FactoryAdmin.Name = dsFactory.Tables[2].Rows[i]["Name"].ToString();

                    ListFactoryAdmin.Add(FactoryAdmin);
                }

            }
            return ListFactoryAdmin;
        }

        //Added By Ashish on 19/8/2015
        [WebMethod(EnableSession = true)]
        public int InsertFactoryLine(int Id, int FactoryUnitId, int FloorId, int LineId, string DesignationName, int designationId)
        {
            return AdminControllerInstance.InsertFactoryLine(Id, FactoryUnitId, FloorId, LineId, DesignationName, designationId);
        }

        [WebMethod(EnableSession = true)]
        public int InsertLine(int Id, int FactoryUnitId, int FloorId, int LineId)
        {
            return AdminControllerInstance.InsertLine(Id, FactoryUnitId, FloorId, LineId);
        }

        [WebMethod(EnableSession = true)]
        public List<CommonClass> CheckFacrotyUnit(int FactoryUnitId)
        {
            //
            List<CommonClass> Factory = new List<CommonClass>();
            try
            {

                DataTable dtFactory = new DataTable();
                dtFactory = AdminControllerInstance.CheckFacrotyUnit(FactoryUnitId);
                if (dtFactory.Rows.Count > 0)
                {
                    int count = dtFactory.Rows.Count;
                    for (int i = 0; i <= count - 1; i++)
                    {
                        CommonClass CommonVal = new Common.Entities.CommonClass();
                        CommonVal.Unit1 = Convert.ToInt32(dtFactory.Rows[i]["NumberOfLines"]);
                        CommonVal.Unit2 = Convert.ToInt32(dtFactory.Rows[i]["UnitID"]);
                        Factory.Add(CommonVal);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return Factory;

        }




        [WebMethod(EnableSession = true)]
        public int FactoryisClosed(int Id, string isClose)
        {
            return AdminControllerInstance.FactoryisClosed(Id, isClose);
        }

        [WebMethod(EnableSession = true)]
        public int UpdateLineFloor(int UnitId, int FloorNoId, int LineNoId, int UserId)
        {
            return AdminControllerInstance.UpdateLineFloor(UnitId, FloorNoId, LineNoId, UserId);
        }

        [WebMethod(EnableSession = true)]
        public int UpdateDeparmentActive(int DepartmentId, bool IsActive)
        {
            return AdminControllerInstance.UpdateDeparmentActive(DepartmentId, IsActive);
        }

        [WebMethod(EnableSession = true)]
        public string UpdateRestrictDepartment(int ApplicationModuleId, int DepartmentId, bool IsActive)
        {
            try
            {
                return AdminControllerInstance.UpdateRestrictDepartment(ApplicationModuleId, DepartmentId, IsActive);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod(EnableSession = true)]
        public string UpdateApplicationModuleIsActive(int ApplicationModuleId, bool IsActive)
        {
            try
            {
                return AdminControllerInstance.UpdateApplicationModuleIsActive(ApplicationModuleId, IsActive);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod(EnableSession = true)]
        public int UpdateMenuShowDepartment(int ApplicationModuleId, int DepartmentId)
        {
            return AdminControllerInstance.UpdateMenuShowDepartment(ApplicationModuleId, DepartmentId);
        }

        [WebMethod(EnableSession = true)]
        public string UpdatePermission(int PermissionType, int DepartmentId, int DesignationId, int ApplicationModuleId)
        {
            try
            {
                return AdminControllerInstance.UpdatePermission(PermissionType, DepartmentId, DesignationId, ApplicationModuleId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [WebMethod(EnableSession = true)]
        public int UpdateDefaultLandingPage(int DepartmentId, int DesignationId, int ApplicationModuleId)
        {
            return AdminControllerInstance.UpdateDefaultLandingPage(DepartmentId, DesignationId, ApplicationModuleId);
        }

        [WebMethod(EnableSession = true)]
        public bool CheckIsRestrictDepartmentAvailable(int DepartmentId, int ApplicationModuleId)
        {
            return AdminControllerInstance.CheckIsRestrictDepartmentAvailable(DepartmentId, ApplicationModuleId);
        }

        [WebMethod(EnableSession = true)]
        public int UpdateFromStatus(int StatusId, int FromStatusId)
        {
            return AdminControllerInstance.UpdateFromStatus(StatusId, FromStatusId);
        }

        [WebMethod(EnableSession = true)]
        public int UpdateIsRelevantToNewsLetter(int StatusId, bool IsRelevantToNewsLetter)
        {
            return AdminControllerInstance.UpdateIsRelevantToNewsLetter(StatusId, IsRelevantToNewsLetter);
        }

        [WebMethod(EnableSession = true)]
        public int UpdateIsRelevantToDelays(int StatusId, bool IsRelevantToDelays)
        {
            return AdminControllerInstance.UpdateIsRelevantToDelays(StatusId, IsRelevantToDelays);
        }

        [WebMethod(EnableSession = true)]
        public int UpdateDays(int StatusId, int ClientId, int Days, int UserId)
        {
            return AdminControllerInstance.UpdateDays(StatusId, ClientId, Days, UserId);
        }

        [WebMethod(EnableSession = true)]
        public int UpdateTargetAdminDescription(int StatusId, string Description)
        {
            return AdminControllerInstance.UpdateTargetAdminDescription(StatusId, Description);
        }

        [WebMethod(EnableSession = true)]
        public int UpdateEmailPermission(int EmailId, int ClientId, int PermissionType, int UserId)
        {
            return AdminControllerInstance.UpdateEmailPermission(EmailId, ClientId, PermissionType, UserId);
        }

        [WebMethod(EnableSession = true)]
        public int UpdateEmailPlan(int EmailId, int EmailPlanId)
        {
            return AdminControllerInstance.UpdateEmailPlan(EmailId, EmailPlanId);
        }
        [WebMethod(EnableSession = true)]
        public int UpdateEmailIsGroup(int EmailId, int EmailPlanId)
        {
            return AdminControllerInstance.UpdateEmailIsGroup(EmailId, EmailPlanId);
        }
        [WebMethod(EnableSession = true)]
        public string UpdateEmailPerority(int EmailId, int EmailPlanId)
        {
            string ret = AdminControllerInstance.UpdateEmailPerority(EmailId, EmailPlanId);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            return js.Serialize(ret);
        }
        [WebMethod(EnableSession = true)]
        public int UpdateEmailTime(int EmailId, string Hours, string Min, string Meridian)
        {
            return AdminControllerInstance.UpdateEmailTime(EmailId, Hours, Min, Meridian);
        }

        [WebMethod(EnableSession = true)]
        public int UpdateEmailDays(int EmailId, string Days)
        {
            return AdminControllerInstance.UpdateEmailDays(EmailId, Days);
        }

        public class PermissionType
        {
            public int DepartmentId { get; set; }
            public int DesignationId { get; set; }
            public int ApplicationModuleId { get; set; }
            public int PermissionTypeNo { get; set; }
        }

        public class PermissionValue
        {
            public int DepartmentId { get; set; }
            public int DesignationId { get; set; }
            public int ApplicationModuleId { get; set; }
            public int PermissionTypeNo { get; set; }
        }

        public class DepartmentActive
        {
            public int DepartmentId { get; set; }
            public int DesignationId { get; set; }
            public int ApplicationModuleId { get; set; }
            public int PermissionTypeNo { get; set; }
        }

        public class EmailPlan
        {
            public int EmailId { get; set; }
            public string Email { get; set; }
            public int EmailPlanId { get; set; }
            public string EmailPlanType { get; set; }
            public string Hours { get; set; }
            public string Min { get; set; }
            public string Meridian { get; set; }
            public string Days { get; set; }
        }

        public class BreakedStyleDetails
        {
            public int StyleId { get; set; }
            public int SealedStyleId { get; set; }
            public int BIHStyleId { get; set; }
            public int BIH_SealedStyleId { get; set; }
        }

        [WebMethod]
        public PermissionType[] GetPermissionType(int DepartmentId, int ApplicationModuleId)
        {
            DataTable dtPermissionType = new DataTable();
            List<PermissionType> oPermissionType = new List<PermissionType>();
            dtPermissionType = AdminControllerInstance.GetPermissionType(DepartmentId, ApplicationModuleId);
            foreach (DataRow drPermissionType in dtPermissionType.Rows)
            {
                oPermissionType.Add(new PermissionType()
                {
                    DepartmentId = DepartmentId,
                    DesignationId = Convert.ToInt32(drPermissionType["DesignationID"]),
                    ApplicationModuleId = ApplicationModuleId,
                    PermissionTypeNo = Convert.ToInt32(drPermissionType["PermissionType"])
                });
            }
            return oPermissionType.ToArray();
        }

        [WebMethod]
        public PermissionValue[] GetPermissionValue(int ApplicationModuleId)
        {
            DataTable dtPermissionType = new DataTable();
            List<PermissionValue> oPermissionValue = new List<PermissionValue>();
            dtPermissionType = AdminControllerInstance.GetPermissionType(ApplicationModuleId);
            foreach (DataRow drPermissionType in dtPermissionType.Rows)
            {
                oPermissionValue.Add(new PermissionValue()
                {
                    DepartmentId = Convert.ToInt32(drPermissionType["DepartmentID"]),
                    DesignationId = Convert.ToInt32(drPermissionType["DesignationID"]),
                    ApplicationModuleId = ApplicationModuleId,
                    PermissionTypeNo = Convert.ToInt32(drPermissionType["PermissionType"])
                });
            }
            return oPermissionValue.ToArray();
        }

        [WebMethod]
        public DepartmentActive[] GetDepartmentActive(int DepartmentId)
        {
            DataTable dtDepartmentActive = new DataTable();
            List<DepartmentActive> oDepartmentActive = new List<DepartmentActive>();
            dtDepartmentActive = AdminControllerInstance.GetDepartmentActive(DepartmentId);
            foreach (DataRow drDepartmentActive in dtDepartmentActive.Rows)
            {
                oDepartmentActive.Add(new DepartmentActive()
                {
                    DepartmentId = DepartmentId,
                    DesignationId = Convert.ToInt32(drDepartmentActive["DesignationID"]),
                    ApplicationModuleId = Convert.ToInt32(drDepartmentActive["ApplicationModuleID"]),
                    PermissionTypeNo = Convert.ToInt32(drDepartmentActive["PermissionType"])
                });
            }
            return oDepartmentActive.ToArray();
        }

        [WebMethod]
        public EmailPlan[] GetEmailPlanDetails()
        {
            DataTable dtEmailPlan = new DataTable();
            List<EmailPlan> oEmailPlan = new List<EmailPlan>();
            dtEmailPlan = AdminControllerInstance.GetEmailPlanDetails();
            foreach (DataRow drEmailPlan in dtEmailPlan.Rows)
            {
                oEmailPlan.Add(new EmailPlan()
                {
                    EmailId = Convert.ToInt32(drEmailPlan["EmailId"]),
                    Email = Convert.ToString(drEmailPlan["Email"]),
                    EmailPlanId = Convert.ToInt32(drEmailPlan["EmailPlanId"]),
                    EmailPlanType = Convert.ToString(drEmailPlan["EmailPlan"]),
                    Hours = Convert.ToString(drEmailPlan["Hours"]),
                    Min = Convert.ToString(drEmailPlan["Min"]),
                    Meridian = Convert.ToString(drEmailPlan["Meridian"]),
                    Days = Convert.ToString(drEmailPlan["Days"])
                });
            }
            return oEmailPlan.ToArray();
        }

        [WebMethod]
        public BreakedStyleDetails[] GetBreakedStyleDetails(string CompleteDateRange, string SessionId)
        {
            DataTable dtBreakedStyleDetails = new DataTable();
            List<BreakedStyleDetails> oBreakedStyleDetails = new List<BreakedStyleDetails>();
            dtBreakedStyleDetails = objBuyingHouseController.GetBreakedStyleDetails(CompleteDateRange, SessionId);
            foreach (DataRow drBreakedStyleDetails in dtBreakedStyleDetails.Rows)
            {
                oBreakedStyleDetails.Add(new BreakedStyleDetails()
                {
                    StyleId = Convert.ToInt32(drBreakedStyleDetails["StyleId"]),
                    SealedStyleId = Convert.ToInt32(drBreakedStyleDetails["SealedStyleId"]),
                    BIHStyleId = Convert.ToInt32(drBreakedStyleDetails["BIHStyleId"]),
                    BIH_SealedStyleId = Convert.ToInt32(drBreakedStyleDetails["BIH_SealedStyleId"])
                });
            }
            return oBreakedStyleDetails.ToArray();
        }

        [WebMethod(EnableSession = true)]
        public int UpdateLineIsClosed(int UnitId, int FloorNoId, int LineNoId, bool IsClosed, int UserId)
        {
            return AdminControllerInstance.UpdateLineIsClosed(UnitId, FloorNoId, LineNoId, IsClosed, UserId);
        }

        [WebMethod(EnableSession = true)]
        public int UpdateLineStatusDesignation(int UnitId, int LineNoId, int LineDesignationId, string DesignationName, int UserId)
        {
            return AdminControllerInstance.UpdateLineStatusDesignation(UnitId, LineNoId, LineDesignationId, DesignationName, UserId);
        }


        //
        //added by abhishek on 27//8/2015
        [WebMethod(EnableSession = true)]
        public int Update_getOtCMTdetails(double ot1, double ot2, double ot3, double ot4)
        {
            return obj_CmtAdmin.Update_getOtCMTdetails(ot1, ot2, ot3, ot4);
        }
        [WebMethod(EnableSession = true)]
        public int Update_getProductionPieces(double Stiching, double Finishing)
        {
            return obj_CmtAdmin.Update_getProductionPieces(Stiching, Finishing);
        }
        [WebMethod(EnableSession = true)]
        public int Update_OBCostPerPieces(double CuttingCost, double FactoryOverHead, double OBPerPicesCost, double FinishingCost, double FabricCost, double AccesoriesCost, double LabourBaseSalary, double PFESI, double DiwaliGift, double Gratuity, double WorkingDays, int ActualWorkingDays, double IGST, double CGST, double SGST, int CMTOHSLOT)
        {
            return obj_CmtAdmin.Update_OBCostPerPieces(CuttingCost, FactoryOverHead, OBPerPicesCost, FinishingCost, FabricCost, AccesoriesCost, LabourBaseSalary, PFESI, DiwaliGift, Gratuity, WorkingDays, ActualWorkingDays, IGST, CGST, SGST, CMTOHSLOT);
        }

        //added by raghvinder on 13 feb 2020
        [WebMethod(EnableSession = true)]
        public string[] GetCMTCalcualtor(int Quantity, float SAM1, int OB, float Eff, string StartDate, string flag)
        {
            DateTime InputStartDate;
            InputStartDate = StartDate != "" ? DateTime.ParseExact(StartDate, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture) : DateTime.MinValue;
            return OrderProcessControllerInstance.GetCMTCalcualtor(Quantity, SAM1, OB, Eff, InputStartDate, flag);
        }

        [WebMethod(EnableSession = true)]
        public int Update_FinancialDetail(string MonthFrom, string MonthTo)
        {
            return obj_CmtAdmin.Update_FinancialDetail(MonthFrom, MonthTo);
        }

        //end by abhishek on 27/8/2015

        // Add By Ravi kumar on 1/9/15 for attandance
        [WebMethod(EnableSession = true)]
        public List<CommonClass> Get_DailyManpowerAttandence(int ProductionUnit, int WorkforceId, string OTDate, int OTs)
        {
            List<CommonClass> Listdsbudget = new List<CommonClass>();
            try
            {

                DataTable dtAttandance = new DataTable();
                dtAttandance = AdminControllerInstance.Get_DailyManpowerAttandence(ProductionUnit, WorkforceId, OTDate, OTs);
                if (dtAttandance.Rows.Count > 0)
                {
                    int count = dtAttandance.Rows.Count;
                    for (int i = 0; i <= count - 1; i++)
                    {
                        CommonClass CommonVal = new Common.Entities.CommonClass();
                        CommonVal.val1 = Convert.ToInt32(dtAttandance.Rows[i]["WorkerCount"]);
                        CommonVal.val2 = Convert.ToDouble(dtAttandance.Rows[i]["WorkingHrs"].ToString());

                        Listdsbudget.Add(CommonVal);
                    }

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("Error occur in  Client Registration Email on" + DateTime.Now.ToString("dd MMM yy (ddd)") + "at" + DateTime.Now.ToString("HH:mm:ss tt"));

                System.Diagnostics.Trace.WriteLine(String.Format("{0} - Error:{1} \n\n{2} \n\n", DateTime.Now.ToString(), ex.Message, ex.StackTrace));
            }
            return Listdsbudget;
        }

        [WebMethod(EnableSession = true)]
        public int Check_WorkCount_Attandance(int ProductionUnit, int WorkforceId, string OTDate, int OTs, int WorkerCount)
        {
            return AdminControllerInstance.Check_WorkCount_Attandance(ProductionUnit, WorkforceId, OTDate, OTs, WorkerCount);
        }
        // added by abhishek on 3/9/2015-----------------------------------------------------------------//
        //for new neck section




        [WebMethod(EnableSession = true)]
        public int InsertStichingNeckNew(string OperationVal)//9/9/2015
        {
            return AdminControllerInstance.InsertStichingNeck(OperationVal);
        }

        [WebMethod(EnableSession = true)]
        public int InsertUpdateNecksectionOB(int OperationId, string OperationVal, string Flag)
        {
            return AdminControllerInstance.InsertUpdateNecksectionOB(OperationId, OperationVal, Flag);
        }
        [WebMethod(EnableSession = true)]
        public List<OBCutting> GetFactoryWorkSpaceNeckSection(int OperationId)
        {
            return AdminControllerInstance.GetFactoryWorkSpaceNeckSection(OperationId);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBSamNeck_section(int OperationId, string GarmentTypeId, string SamVal)
        {
            return AdminControllerInstance.InsertUpdateStichingOBSamNeck_section(OperationId, GarmentTypeId, SamVal);
        }
        //end neck section

        //for neck faching section
        [WebMethod(EnableSession = true)]
        public int InsertStichingNeckfaching(string OperationVal)
        {
            return AdminControllerInstance.InsertStichingNeck_faching(OperationVal);
        }

        [WebMethod(EnableSession = true)]
        public int InsertUpdateNeckfaching(int OperationId, string OperationVal, string Flag)
        {
            return AdminControllerInstance.InsertUpdateNecksectionOB_faching(OperationId, OperationVal, Flag);
        }
        [WebMethod(EnableSession = true)]
        public List<OBCutting> GetFactoryWorkSpaceNeckfaching(int OperationId)
        {
            return AdminControllerInstance.GetFactoryWorkSpaceNeckSection_faching(OperationId);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBSamNeckfaching(int OperationId, string GarmentTypeId, string SamVal)
        {
            return AdminControllerInstance.InsertUpdateStichingOBSamNeck_section_faching(OperationId, GarmentTypeId, SamVal);
        }

        //end

        //for front and back section 


        [WebMethod(EnableSession = true)]
        public int InsertStichingNeckfachingfrontback(string OperationVal)
        {
            return AdminControllerInstance.InsertStichingNeck_faching_frontback(OperationVal);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateNeckfachingfrontback(int OperationId, string OperationVal, string Flag)
        {
            return AdminControllerInstance.InsertUpdateNecksectionOB_frontback(OperationId, OperationVal, Flag);
        }
        [WebMethod(EnableSession = true)]
        public List<OBCutting> GetFactoryWorkSpaceNeckfachingfrontback(int OperationId)
        {
            return AdminControllerInstance.GetFactoryWorkSpaceNeckSection_frontback(OperationId);
        }
        [WebMethod(EnableSession = true)]
        public int InsertUpdateStichingOBSamNeckfachingfrontback(int OperationId, string GarmentTypeId, string SamVal)
        {
            return AdminControllerInstance.InsertUpdateStichingOBSamNeck_section_frontback(OperationId, GarmentTypeId, SamVal);
        }

        //end front and back section

        //end by abhishek 3/9/2015------------------------------------------------------------------------//

        //added by abhishek on 26/10/2015

        [WebMethod(EnableSession = true)]
        public int Update_CMT_barrieday(string Colname, int Colval)
        {
            CmtAdminController objcmtadminController = new CmtAdminController();
            return objcmtadminController.Update_CMT_barrieday(Colname, Colval);
        }
        //end by abishek on 26/10/2015

        // Add By Ravi kumar for checking Stitched or not
        [WebMethod(EnableSession = true)]
        public int CheckStitched_ByOrderDetailId(int OrderDetailId)
        {
            return this.OrderControllerInstance.CheckStitched_ByOrderDetailId(OrderDetailId);
        }

        [WebMethod(EnableSession = true)]
        public int UpdateQty(int OrderDetailId, int ValueAddQty, int ValueAdditionId, int UnitId)
        {
            return OrderProcessControllerInstance.UpdateQty(OrderDetailId, ValueAddQty, ValueAdditionId, UnitId);
        }
        [WebMethod(EnableSession = true)]
        public int UpdateQtywithflag(int OrderDetailId, int ValueAddQty, int ValueAdditionId, int UnitId, string flag, string val)
        {
            return OrderProcessControllerInstance.UpdateQtywithflag(OrderDetailId, ValueAddQty, ValueAdditionId, UnitId, flag, val);
        }
        // Add By Ravi kumar on 1/1/2016 for checking SizeSet_ByOrderDetailId or not
        [WebMethod(EnableSession = true)]
        public int CheckSizeSet_ByOrderDetailId(int OrderDetailId)
        {
            return this.OrderControllerInstance.CheckSizeSet_ByOrderDetailId(OrderDetailId);
        }

        [WebMethod(EnableSession = true)]
        public int Update_cutting_Stitching_Finishing_ByOrderDetailId(int OrderDetailId, string Type, int UnitId, int Value)
        {
            return OrderControllerInstance.Update_cutting_Stitching_Finishing_ByOrderDetailId(OrderDetailId, Type, UnitId, Value, ApplicationHelper.LoggedInUser.UserData.UserID);
        }
        //adedd by abhishek on 19/1/2016
        [WebMethod(EnableSession = true)]
        public bool UpdatePhotoShot(string Photoshotdate, int IsPicShot, int orderId, int orderDetails_ID)
        {
            if (OrderControllerInstance.UpdatePhotoShot(Photoshotdate, IsPicShot, orderDetails_ID) && IsPicShot > 0)
            {
                WorkflowController WorkflowControllerInstance = new WorkflowController();
                WorkflowInstance instance = WorkflowControllerInstance.Create_CloseWorkflowPostOrder(orderId, orderDetails_ID, TaskMode.Photo_Shoots, ApplicationHelper.LoggedInUser.UserData.UserID);
                WorkflowControllerInstance = null;
                return true;
            }
            else
            {
                return false;
            }
        }
        //end by abhishek on 19/1/2016
        //added by abhishek on 20/1/2015

        [WebMethod(EnableSession = true)]
        public List<StatusModes> GetAllStatusModesByUserId_New1(int UserId)//For fill Department Dropdown
        {
            return AdminControllerInstance.GetAllStatusModesByUserId(UserId);
        }
        //end by abhishek on 20/1/2016

        // Added By Ravi kumar for autosuggestion fro faults
        [WebMethod(EnableSession = true)]
        public List<string> SuggestNatureOfFaults(string q, int limit)
        {
            return SuggestForAutoCompleteFault(q, AutoComplete.NatureOfFaults.ToString(), limit);
        }
        [WebMethod(EnableSession = true)]
        public string GetNatureOfFaultsValues(string NatureOfFaults)
        {
            return this.QualityControllerInstance.GetNatureOfFaults_Value(NatureOfFaults);
        }
        // Added By Ravi kumar for Inline check
        [WebMethod(EnableSession = true)]
        public string Check_Cut_For_Production(int OrderDetailId, string Type)
        {
            ProductionController objProductionController = new BLL.Production.ProductionController();
            string ss = objProductionController.Check_Cut_For_Production(OrderDetailId, Type);
            return ss;
        }

        [WebMethod(EnableSession = true)]
        public string Check_CuttingAndIssued_Data(int OrderDetailId, string Type, int PcsCut)
        {
            ProductionController objProductionController = new BLL.Production.ProductionController();
            string ss = objProductionController.Check_CuttingAndIssued_Data(OrderDetailId, Type, PcsCut);
            return ss;
        }

        // Add by Ravi kumar on 18/2/2016
        [WebMethod(EnableSession = true)]
        public int SaveProduction_ExtraHrs(int OrderDetailId, string ProdDate, double ExtraHrs, int LinePlanningId, int UnitId)
        {
            ProductionController objProductionController = new ProductionController();
            int Id = objProductionController.SaveProduction_ExtraHrs(OrderDetailId, ProdDate, ExtraHrs, LinePlanningId, UnitId);
            return Id;

        }
        //added by abhishek on 27/7/2016
        [WebMethod(EnableSession = true)]
        public int UpdateWastageValue(int VaID, int WastageID, float Values, string Flag)
        {
            return AdminControllerInstance.UpdateWastageValue(VaID, WastageID, Values, Flag);
        }
        [WebMethod(EnableSession = true)]
        public int UpdateLineManPower(int UnitId, int manPower, int LineNoId, int UserId)
        {
            return AdminControllerInstance.UpdateLineManPower(UnitId, manPower, LineNoId, UserId);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdateAccAppDate(int WorkingAccID, string Date, int OrderDetailsID)
        {
            return OrderControllerInstance.UpdateAccAppDate(WorkingAccID, Date, OrderDetailsID);
        }
        //end by abhishek

        //added by abhishek on 3/2/2017
        [WebMethod(EnableSession = true)]
        public int UpdateLineFloorCluster(int UnitId, int FloorNoId, int LineNoId, int UserId)
        {
            return AdminControllerInstance.UpdateLineFloorCluster(UnitId, FloorNoId, LineNoId, UserId);
        }
        [WebMethod(EnableSession = true)]
        public int UpdateLineIsClosedCluster(int UnitId, int FloorNoId, int LineNoId, bool IsClosed, int UserId)
        {
            return AdminControllerInstance.UpdateLineIsClosedCluster(UnitId, FloorNoId, LineNoId, IsClosed, UserId);
        }
        [WebMethod(EnableSession = true)]
        public int UpdateLineStatusDesignationCluster(int UnitId, int LineNoId, int LineDesignationId, string DesignationName, int UserId)
        {
            return AdminControllerInstance.UpdateLineStatusDesignationCluster(UnitId, LineNoId, LineDesignationId, DesignationName, UserId);
        }
        [WebMethod(EnableSession = true)]
        public int UpdateLineManPowerCluster(int UnitId, int manPower, int LineNoId, int UserId)
        {
            return AdminControllerInstance.UpdateLineManPowerCluster(UnitId, manPower, LineNoId, UserId);
        }
        //Add by prabhaker 14/11/17
        [WebMethod(EnableSession = true)]
        public int UpdateClusterName(int UnitId, string ClusterName, int LineNoId, int UserId)
        {
            return AdminControllerInstance.UpdateClusterName(UnitId, ClusterName, LineNoId, UserId);
        }
        //end

        [WebMethod(EnableSession = true)]
        public string GetSamplingHistory(int StyleId, int MoOpen, int Mode, int PPStatus,int OrderDetailID)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleId", StyleId);
            properties.Add("MoOpen", MoOpen);
            properties.Add("Mode", Mode);
            properties.Add("PPStatus", PPStatus);
            properties.Add("OrderDetailID", OrderDetailID);
            return PageHelper.GetControlHtml("~/UserControls/Lists/SamplingFitsCycleHistory.ascx", properties);
        }
        [WebMethod(EnableSession = true)]
        public string GetSamplingHistory_PreOrder(int StyleId)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleId", StyleId);
            return PageHelper.GetControlHtml("~/UserControls/Lists/SamplingFitsCycleHistory_PreOrder.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string Style_Remarks(int StyleId)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("StyleId", StyleId);
            return PageHelper.GetControlHtml("~/UserControls/Lists/Style_Remarks.ascx", properties);
        }
        [WebMethod(EnableSession = true)]
        public List<Client> BindClientListAgainstMerchant(int UserID, int flag)
        {
            return this.AdminControllerInstance.BindClientListAgainstMerchant(UserID, flag);
        }
        [WebMethod(EnableSession = true)]
        public List<Client> BindDeptListAgainstCliets(int UserID, int ClientID, int FitMerchantID)
        {
            return this.AdminControllerInstance.BindDeptListAgainstCliets(UserID, ClientID, FitMerchantID);
        }
        [WebMethod(EnableSession = true)]
        public List<Client> BindDeptListAgainstParentDept(int UserId, int ClientId, int FitMerchantID, int ParentDeptID)
        {
          return this.AdminControllerInstance.BindDeptListAgainstParentDept(UserId, ClientId, FitMerchantID, ParentDeptID);
        }

        [WebMethod(EnableSession = true)]
        public string GetcadMaster(int styleid, int flagvalue, string Status)
        {
            //System.Diagnostics.Debugger.Break();
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("styleid", styleid);
            properties.Add("flagvalue", flagvalue);
            properties.Add("Status", Status);

            return PageHelper.GetControlHtml("~/Admin/FitsSample/CadManagerMaster.ascx", properties);
            //return PageHelper.GetControlHtml("~/Admin/FitsSample/FrmCadMaster.aspx", properties);
        }
        //adedd by abhishek on 19/1/2016
        [WebMethod(EnableSession = true)]
        public string ValidateBnkRefNo(string BnkRefNo, int CurrencyType)
        {
            return OrderControllerInstance.ValidateBnkRefNo(BnkRefNo, CurrencyType);
        }
        //Added By Ravi kumar to delete Line frame on 8/11/17
        [WebMethod(EnableSession = true)]
        public int DeleteLinePlanFrame(int LinePlanFrameId)
        {
            return AdminControllerInstance.DeleteLinePlanFrame(LinePlanFrameId);
        }
        // Added by MR.A 2/2/2018
        [WebMethod(EnableSession = true)]
        public string ValidateExsitingPlannedDate(DateTime dates, int OrderDetailID, int FabricType)
        {
            return AdminControllerInstance.ValidateExsitingPlannedDate(dates, OrderDetailID, FabricType);
        }
        // Added By Ravi kumar on 20/3/18 for Plan date
        [WebMethod(EnableSession = true)]
        public bool Update_PlanDate(int OrderDetailId, int PlanType, string PlanDate)
        {
            DateTime dtPlanDate = PlanDate == "" ? DateTime.MinValue : DateHelper.ParseDate(PlanDate).Value;
            return OrderControllerInstance.Update_PlanDate(OrderDetailId, PlanType, dtPlanDate);
        }

        [WebMethod(EnableSession = true)]
        public List<Department> GetAllPrintDeptlist(int ClientId)//For fill Department Dropdown
        {
            return ClientControllerInstance.BindAllPrintDept(ClientId);
        }

        // Added By Ravi kumar on 3/4/18 for order form
        [WebMethod(EnableSession = true)]
        public List<OrderDetail> GetOrderDetailByIdOrderForm(int orderId)
        {
            return OrderControllerInstance.GetOrderDetailByIdOrderForm(orderId);
        }

        // Added By Ravi kumar on 18-4-18 for Update sunday working in cmt admin
        [WebMethod(EnableSession = true)]
        public int UpdateSundayWorking(int IsSundayWorking)
        {
            return obj_CmtAdmin.UpdateSundayWorking(IsSundayWorking);
        }
        [WebMethod(EnableSession = true)]
        public int UpdateQcFile(string filename, int orderdetailID, string filetype)
        {
            return AdminControllerInstance.UpdateQcFile(filename, orderdetailID, filetype);
        }
        [WebMethod(EnableSession = true)]
        public List<BottleNeck> GetOB_Operation_ByStyle(int StyleId, string SectionName)
        {
            ProductionController objProductionController = new BLL.Production.ProductionController();
            return objProductionController.GetOB_Operation_ByStyle(StyleId, SectionName);
        }
        [WebMethod(EnableSession = true)]
        public List<string> GetOB_Operation_ByStyle_Autocompl(string q, int limit)
        {

            int styleid = 0;
            string SectionName = "";
            if (Session["user"] != null)
            {
                styleid = Convert.ToInt32(Session["user"].ToString());
            }
            if (Application["StyleIdsession"] != null)
            {
                styleid = Convert.ToInt32(Application["StyleIdsession"].ToString());
            }
            if (Application["oprationsession"] != null)
            {
                SectionName = Application["oprationsession"].ToString();
            }

            ProductionController objProductionController = new BLL.Production.ProductionController();
            List<string> searchResults = objProductionController.GetOB_Operation_ByStyle_Autocompl(styleid, SectionName, q);
            List<string> filteredSearchResults = new List<string>();
            foreach (string result in searchResults)
            {
                //if (result.ToLower().Contains(q.ToLower()))
                //{
                filteredSearchResults.Add(result);
                //}
            }
            filteredSearchResults.Sort();
            return filteredSearchResults;
        }
        ////[WebMethod(EnableSession = true)]
        ////public string  SetSession(string styleid)
        ////{

        ////  Session["StyleIdsession"] = styleid;
        //// //return styleid;
        //// //Session["oprationsession"] = secname;   
        ////}
        [WebMethod(EnableSession = true)]
        public int DeleteLinePlanFrame_new(string styleid, string sec)
        {
            Session["oprationsession"] = sec;
            Session["StyleIdsession"] = styleid;
            return AdminControllerInstance.DeleteLinePlanFrame(-00);
        }
        [WebMethod(EnableSession = true)]
        public string ValidateSupplierName(string Flag, string SupplierName, string BasicType)
        {
            return OrderControllerInstance.ValidateSupplierName(Flag, SupplierName, BasicType);
        }
        [WebMethod(EnableSession = true)]//abhishk
        public string GetSupplierSelectedType(int Supplierid)
        {
          return AdminControllerInstance.GetSupplierSelectedType(Supplierid);
        }
        [WebMethod(EnableSession = true)]
        public int Updatecontractholdstatus(int orderDetails_ID, int IsChecked, int userID)
        {
            return OrderControllerInstance.Updatecontractholdstatus(orderDetails_ID, IsChecked, userID);
        }
        [WebMethod(EnableSession = true)]
        public string[] GetSupplierRate(string flag, string flagOtion, int FabricQualityID, int SupplierMasterID, string faricdetails, int Styleid)
        {
          return OrderControllerInstance.GetSupplierRate(flag, flagOtion, FabricQualityID, SupplierMasterID, faricdetails,  Styleid);
        }
        [WebMethod(EnableSession = true)]
        public string[] GetSupplierRateVA(string flag, string flagOtion, int FabricQualityID, int SupplierMasterID, string faricdetails, int Styleid)
        {
            return OrderControllerInstance.GetSupplierRateVA(flag, flagOtion, FabricQualityID, SupplierMasterID, faricdetails, Styleid);
        }
        [WebMethod(EnableSession = true)]
        public string[] ValidateRececiedQty(string flag, string flagOtion, int FabricQualityID, int ReceviedQty, string Potype, string PoNumber, int MasterPoID, string fabricdetails)
        {
            return OrderControllerInstance.ValidateRececiedQty(flag, flagOtion, FabricQualityID, ReceviedQty, Potype, PoNumber, MasterPoID, fabricdetails);
        }
        [WebMethod(EnableSession = true)]
        public string[] GetSupplierIntialCode(string flag, int SupplierMasterID)
        {
            return OrderControllerInstance.GetSupplierIntialCode(flag, SupplierMasterID);
        }
        [WebMethod(EnableSession = true)]
        public int[] GetDeliveryType(string Flag, string FlagOption, int FabricQualityID, int SupplierMasterID, string FabricDetails, int styleida, bool isStyleSpecific)
        {
            return OrderControllerInstance.GetDeliveryType(Flag, FlagOption, FabricQualityID, SupplierMasterID, FabricDetails, styleida, isStyleSpecific);
        }
        [WebMethod(EnableSession = true)]
        public string[] GetSupplierIntialCode2(string flag, int SupplierMasterID, int PoID)
        {
            return OrderControllerInstance.GetSupplierIntialCode2(flag,SupplierMasterID,PoID);
        }
        [WebMethod(EnableSession = true)]
        public string[] ValidateMinReceiveQty(string flag, int SupplierMasterID)
        {
            return OrderControllerInstance.ValidateMinReceiveQty(flag, SupplierMasterID);
        }
        [WebMethod(EnableSession = true)]
        public string Cancel_Close_PO(int SupplierPO_Id, string flag)
        {
            return OrderControllerInstance.Cancel_Close_PO(SupplierPO_Id, flag);
        }
        [WebMethod(EnableSession = true)]
        public bool UpdareResidualShrinkage(string Flag, string FlagOption, float residualshrinkage, int FabricQualityID, string FabricDetails)
        {
            return fabobj.UpdareResidualShrinkage(Flag, FlagOption, residualshrinkage, FabricQualityID, FabricDetails);
        }
        [WebMethod(EnableSession = true)]
        public string[] Get_Srv_detailsProxy(string PartyBillNo, string Flag, string SrvId)
        {
            return OrderProcessControllerInstance.Get_Srv_detailsProxy(PartyBillNo, Flag, SrvId); 
           
        }
        [WebMethod(EnableSession = true)]
        public string[] GetReceiveQtyBySendQty(string flag, string flagoption, int fabricqualityid, string fabricdetails, int currentstagenumber, int previousstagenumber, int pendingqty, bool IsStyleSpecific, int styleid)
        {
            return OrderControllerInstance.GetReceiveQtyBySendQty(flag, flagoption, fabricqualityid, fabricdetails, currentstagenumber, previousstagenumber, pendingqty,IsStyleSpecific, styleid);
        }
        
        
    }
}