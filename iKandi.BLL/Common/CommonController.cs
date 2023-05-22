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
    public class CommonController: BaseController
    {
        #region

        public CommonController()
        {
        }

        public CommonController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion
        public List<string> SuggestForAutoComplete(string searchValue, string searchContext)
        {
            //return this.CommonDataProviderInstance.GetFabricList_ByTradeName_New(searchValue);
            return this.CommonDataProviderInstance.SuggestForAutoComplete(searchValue, searchContext);
        }
        //RajeevS 27042023
        public List<string> SuggestForAccAutoComplete(string searchValue, string searchContext)
        {            
            return this.CommonDataProviderInstance.SuggestForAccAutoComplete(searchValue, searchContext);
        }
        //

         public List<string> SuggestForAutoCompleteByunitid(string searchValue, string searchContext,int unitid)
        {
            return this.CommonDataProviderInstance.SuggestForAutoCompleteByunitid(searchValue, searchContext, unitid);
        }
        public List<string> SuggestForAutoComplete1(string searchValue, string str, string searchContext)
        {
            return this.CommonDataProviderInstance.SuggestForAutoComplete1(searchValue, str, searchContext);
        }
        /// <summary>
        /// For Autocomplete Story : Yaten 31 Aug
        /// </summary>
        /// <param name="searchValue"></param>
        /// <param name="searchContext"></param>
        /// <returns></returns>
        public List<string> SuggestStoryBAL(string searchValue)
        {
            return this.CommonDataProviderInstance.SuggestStoryDAL(searchValue);
        }


        public List<string> SuggestSupplierNameBAL(string searchValue)
        {
            return this.CommonDataProviderInstance.SuggestSupplierNameDAL(searchValue);
        }

        public List<string> SuggestProcessOrderBAL(string searchValue)
        {
            return this.CommonDataProviderInstance.SuggestProcessOrderDAL(searchValue);
        }

        


        //public int GetModeDays(int modeValue)
        //{
        //    return this.CommonDataProviderInstance.GetModeDays(modeValue);
        //}

        public double GetZipRate(string zipDetail, ZipRateType zipType, string zipSize)
        {
            return this.CommonDataProviderInstance.GetZipRate(zipDetail, zipType, zipSize);
        }


        public double GetZipRateStyle(string zipDetail, ZipRateType zipType, string zipSize,int StyleId)
        {
            return this.CommonDataProviderInstance.GetZipRateStyle(zipDetail, zipType, zipSize, StyleId);
        }


        public List<ProductionUnit> GetUnitByUserId(int UserId)
        {
            return this.CommonDataProviderInstance.GetUnitByUserId(UserId);
        }

        public List<ProductionUnit> GetUnitReports()
        {
            return this.CommonDataProviderInstance.GetUnitReports();
        }

        public List<string> SuggestForPrintNumberAutoComplete2(string searchValue, string searchContext, int clientId, int PrintCategory)
        {
            return this.CommonDataProviderInstance.SuggestForPrintNumberAutoComplete2(searchValue, searchContext, clientId, PrintCategory);
        }

        // Adding new service for the color suggestion in design form by Bharat veer dated on 22 may 2019
        public List<string> SuggestForColorAutoComplete2(string searchValue, int clientId, int PrintCategory)
        {
            return this.CommonDataProviderInstance.SuggestForColorAutoComplete2(searchValue, clientId, PrintCategory);
        }

        /// <summary>
        /// Yaten : Suggest Registered Client list 18 Apr
        /// </summary>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public List<string> SuggestForRegisteredClient(string searchValue)
        {
            return this.CommonDataProviderInstance.SuggestForRegisteredClient(searchValue);
        }





        /// <summary>
        /// Yaten : Suggest Print Numbers by style Number
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="subCategoryId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<string> SuggestPrintNumbers_ForMultiplePrints2(string searchValue, string searchContext, int clientId, string stno, int PrintCategory)
        {
            return this.CommonDataProviderInstance.SuggestPrintNumbers_ForMultiplePrints2(searchValue, searchContext, clientId, stno, PrintCategory);
        }

        //added on 07 Jan 2021 start
        public List<string> AutoComplete_Fabric_Pending_OrderSummary1(string searchValue, string searchContext, int clientId, string stno, int PrintCategory)
        {
            return this.CommonDataProviderInstance.AutoComplete_Fabric_Pending_OrderSummary1(searchValue, searchContext, clientId, stno, PrintCategory);
        }
        //added on 07 Jan 2021 end

        //added on 27 Jan 2021 start
        public List<string> AutoComplete_Accessory_Pending_OrderSummary1(string searchValue, string searchContext, int clientId, string stno, int PrintCategory)
        {
            return this.CommonDataProviderInstance.AutoComplete_Accessory_Pending_OrderSummary1(searchValue, searchContext, clientId, stno, PrintCategory);
        }
        //added on 27 Jan 2021 end

        public List<string> SuggestPrintNumbers_ForMultiplePrintsStyleNumber2(string searchValue, string searchContext, int clientId, string stno)
        {
            return this.CommonDataProviderInstance.SuggestPrintNumbers_ForMultiplePrintsStyleNumber2(searchValue, searchContext, clientId, stno);
        }
        /// <summary>
        ///Yaten :  For Notification on Dashboard
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="subCategoryId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataTable GetClosedTask(int UserId)
        {
            return this.CommonDataProviderInstance.GetClosedTask(UserId);

        }
        /// <summary>
        ///Yaten : For critical report admin
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable GetCriticalAdminStatus(int intClientId, int intReportId)
        {
            return this.CommonDataProviderInstance.ShowCriticalReportStatus(intClientId, intReportId);

        }
        public DataTable GetClientNamesAndIds()
        {
            return this.CommonDataProviderInstance.GetClientNamesAndIds();

        }



        public string GetIdentification(int categoryId , int subCategoryId , int type)
        {
            return this.CommonDataProviderInstance.GetIdentification(categoryId, subCategoryId, type);
        }

        public List<string> SuggestForRegisteredTradeNamesAutoComplete(string searchValue)
        {
            return this.CommonDataProviderInstance.SuggestForRegisteredTradeNamesAutoComplete(searchValue);
        }


        public List<string> SuggestForRegisteredTradeNamesAutoCompleteForOrder(string searchValue)
        {
            return this.CommonDataProviderInstance.SuggestForRegisteredTradeNamesAutoCompleteForOrder(searchValue);
        }

        //public List<OrderDetail> GetOrdersForExportToExcel(string SearchText, int Client, int Department, int SupplyType, int ModeType, int PackingType, int Terms, DateTime FromDate, DateTime ToDate, short DateType)
        //{
        //    return this.CommonDataProviderInstance.GetOrdersForExportToExcel(SearchText, Client, Department, SupplyType, ModeType, PackingType, Terms, FromDate, ToDate, DateType);
        //}

        public List<ProductionUnit> GetAllUnits()
        {
            return this.CommonDataProviderInstance.GetAllUnits();
        }

        public List<Print> GetAllPrintTypes()
        {
            return this.CommonDataProviderInstance.GetAllPrintTypes();
        }

        public string GetNotificationTask(int id)
        {
            return "test"; //this.LabTestDataProviderInstance.GetNotificationTask(id);
        }
        /// <summary>
        /// Yaten : Update Critical Path Report
        /// </summary>
        /// <param name="stringXml"></param>
        /// <param name="id"></param>
        public void UpdateReportPermissions(string stringXml, int id)
        {
            this.CommonDataProviderInstance.UpdatePermissionsReport(stringXml, id);
        }
        /// <summary>
        /// Yaten : Dashboard F&A Task
        /// </summary>
        /// <returns></returns>
        public DataTable GetFATasksBAL(int iDesignationId)
        {
            return this.CommonDataProviderInstance.GetFATasksDAL(iDesignationId);

        }

        public DataSet GetFATasks(int iDesignationId)
        {
            return this.CommonDataProviderInstance.GetFATasks(iDesignationId);

        }
        //Gajendra New Costing
        public List<string> GetFabricList_ByTradeName(string searchValue)
        {
            return this.CommonDataProviderInstance.GetFabricList_ByTradeName(searchValue);
        }
        //Gajendra New Costing
        public List<string> GetFabricList_ByTradeName_New(string searchValue, string Print_Details, int PrintCategory, string StyleId)
        {
            return this.CommonDataProviderInstance.GetFabricList_ByTradeName_New(searchValue, Print_Details, PrintCategory, StyleId);
        }
        public List<string> GetAccessoryList_ByTradeName(string searchValue, int StyleId, int ClientId, int ParentDeptId, int DeptId)
        {
            return this.CommonDataProviderInstance.GetAccessoryList_ByTradeName(searchValue, StyleId, ClientId, ParentDeptId, DeptId);
        }
        public List<string> GetAccessoryList_ByTradeName_Design(string searchValue)
        {
            return this.CommonDataProviderInstance.GetAccessoryList_ByTradeName_Design(searchValue);
        }
        public DataSet GetAccessory_Size_Rate(string searchValue, int ClientId)
        {
            return this.CommonDataProviderInstance.GetAccessory_Size_Rate(searchValue, ClientId);
        }
        public List<string> GetProcessList_ByName(string searchValue)
        {
            return this.CommonDataProviderInstance.GetProcessList_ByName(searchValue);
        }
        public List<OrderDetail> GetOrdersForExportToExcel_new(string SearchText, string year, DateTime FromDate, DateTime ToDate, int clientid, int unitid, short DateType, int StatusMode, int StatusModeSequence, int BuyingHouseId, int Ordertype)
        {
            return this.CommonDataProviderInstance.GetOrdersForExportToExcel_new(SearchText, year, FromDate, ToDate, clientid, unitid, DateType, StatusMode, StatusModeSequence, BuyingHouseId, Ordertype);
        }
        //abhishek
        public List<string> GetUserNameByDeptID(string searchValue, int Deptid)
        {
            return this.CommonDataProviderInstance.GetUserNameByDeptID(searchValue,Deptid);
        }
        public List<string> SuggestForAutoComplete_supplier(string searchValue, string searchContext)
        {
            return this.CommonDataProviderInstance.SuggestForAutoComplete_supplier(searchValue, searchContext);
        }
        public List<string> SuggestForAutoCompleteByunitidLine(string searchValue, int unitid, int LineNumber, string status)
        {
          return this.CommonDataProviderInstance.SuggestForAutoCompleteByunitidLine(searchValue,unitid,LineNumber,status);
        }
        public int check_for_auto_complete(string searchValue, string searchContext)
        {
            return this.CommonDataProviderInstance.check_for_auto_complete(searchValue, searchContext);
        }
        public int UpdateTaskSupportIssue(string flag, string SerialNo) 
        {
          return this.CommonDataProviderInstance.UpdateTaskSupportIssue(flag, SerialNo);
        }
        public DateTime GetCommonRptDateOnPage()
        {
            return this.CommonDataProviderInstance.GetCommonRptDateOnPage();
        }
        public int UpdateStatus(string po_number, string status,string Flag)
        {
            return this.CommonDataProviderInstance.UpdateStatus(po_number, status, Flag);
        }

    }
}
