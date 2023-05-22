using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.Services;
using iKandi.BLL;
using System.Collections.Generic;
using iKandi.Common;
using iKandi.Web.Components;
namespace iKandi.Web
{
    public partial class iKandiService
    {
        [WebMethod(EnableSession = true)]
        public string GenerateDailyOrderSummaryReport(int PageSize, int PageIndex, string SearchText, int ClientId, int SortedBy, int SortedBy2, int SortedBy3, int SortedBy4, int TotalQuantity, int FactoryManagerUserID, int UserId, string FromExDate, string ToExDate)
        {
            //System.Diagnostics.Debugger.Break();
            DateTime fromDate = DateHelper.ParseDate(FromExDate).Value;
            DateTime toDate = DateHelper.ParseDate(ToExDate).Value;
            int totalCount;
            return this.PDFControllerInstance.GenerateDailyOrderSummaryReport(PageSize, PageIndex, out totalCount, SearchText, ClientId, SortedBy, SortedBy2, SortedBy3, SortedBy4, TotalQuantity, FactoryManagerUserID, UserId, fromDate, toDate);
        }

        [WebMethod(EnableSession = true)]
        public string SaveQuoteToolInformation(string styleNumber, int[] modeIdCollection)
        {
            DataTable dtTemp = new DataTable();

            if (string.IsNullOrEmpty(styleNumber) || modeIdCollection.Length == 0)
                return string.Empty;

            DataTable dtQuoteTool = Session["quotetool"] as DataTable;

            if (dtQuoteTool == null || dtQuoteTool.Rows.Count == 0)
            {
                Session["quotetool"] = dtQuoteTool = dtTemp = this.ReportControllerInstance.SaveQuoteToolInformation(styleNumber, modeIdCollection);
            }
            else
            {
                dtTemp = this.ReportControllerInstance.SaveQuoteToolInformation(styleNumber, modeIdCollection);
                dtQuoteTool.Merge(dtTemp);
                Session["quotetool"] = dtQuoteTool;
            }

            if (dtTemp == null || dtTemp.Rows.Count == 0)
            {
                return string.Empty;
            }
            else
            {
                dtQuoteTool.DefaultView.Sort = "StyleNumber ASC";

                Dictionary<string, object> properties = new Dictionary<string, object>();
                properties.Add("QuoteToolDataTable", dtQuoteTool);

                return PageHelper.GetControlHtml("~/UserControls/Lists/QuoteToolList.ascx", properties);
            }
        }

        [WebMethod(EnableSession = true)]
        public bool DeleteQuoteToolInformation()
        {
            Session["quotetool"] = null;
            return this.ReportControllerInstance.DeleteQuoteToolInformation();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="q"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public List<string> SuggestRegisteredClient(string q, int limit)
        {
            //List<string> Results = new List<string>();
            List<string> Results = GetAllClientsNames(q, limit);

            return Results;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="q"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public string SuggestClientSIds(string q)
        {

            //  return this.GetAllClientsIds(q);
            return this.ReportControllerInstance.GetAllClientsId(q);


        }


        [WebMethod(EnableSession = true)]
        public string HandEmbPrice(string FromPrice, string ToPrice)
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("FromPrice", FromPrice);
            properties.Add("ToPrice", ToPrice);

            return PageHelper.GetControlHtml("~/UserControls/Reports/Embellishment.ascx", properties);
        }

        [WebMethod(EnableSession = true)]
        public string GenerateFabricQualityPDF(int PageSize, int PageIndex, string SearchText, int GroupId, int SubGroupId, String GsmFrom, String GsmTo, String WidthFrom, String WidthTo, String PriceFrom, String PriceTo, int IsReg, int Order1, int Order2, int Order3, int Order4)
        {
            // System.Diagnostics.Debugger.Break();
            int TotalPageCount;

            return this.PDFControllerInstance.GenerateFabricQualityList(PageSize, PageIndex, out TotalPageCount, SearchText, GroupId, SubGroupId, GsmFrom, GsmTo, WidthFrom, WidthTo, PriceFrom, PriceTo, IsReg, Order1, Order2, Order3, Order4);
        }
        [WebMethod(EnableSession = true)]
        public string GenerateAccessoryQualityPDF(int PageSize, int PageIndex, string SearchText, int GroupId, int SubGroupId, String PriceFrom, String PriceTo, int IsReg, int Order1, int Order2, int Order3)
        {
            // System.Diagnostics.Debugger.Break();
            int TotalPageCount;

            return this.PDFControllerInstance.GenerateAccessoryQualityList(PageSize, PageIndex, out TotalPageCount, SearchText, GroupId, SubGroupId, PriceFrom, PriceTo, IsReg, Order1, Order2, Order3);
        }
        [WebMethod(EnableSession = true)]
        public string GenerateManageOrderReport(int PageSize, int PageIndex, string SearchText, int ClientId, string Year, int UnitId, int DateType, int StatusMode, int StatusModeSequence, int OrderBy1, int OrderBy2, int OrderBy3, int OrderBy4, string FromDate, string ToDate, int BuyingHouseId, int desigId, int DeptId, int UserId, int SalesView, string SessionId, string BuyingHouseName, string StatusName, string StatusSequenceName, string UnitName, int ClientDeptId, string ClientDeptName, int ordertpye, int IsUnshipped, int TotalCount, int AM, int OutHouse, int ClientParentDeptId, string ParentDeptName) //Gajendra Paging
        {
            //int totalCount;
            //string str  = "Order Summary Report -17 May 2018.pdf";
            //return str;
            return this.PDFControllerInstance.GenerateManageOrderReport(PageSize, PageIndex, SearchText, ClientId, Year, UnitId, DateType, StatusMode, StatusModeSequence, OrderBy1, OrderBy2, OrderBy3, OrderBy4, FromDate, ToDate, BuyingHouseId, desigId, DeptId, UserId, SalesView, SessionId, BuyingHouseName, StatusName, StatusSequenceName, UnitName, ClientDeptId, ClientDeptName, ordertpye, IsUnshipped, TotalCount, AM,OutHouse,ClientParentDeptId,ParentDeptName);//Surendra2
        }
        [WebMethod(EnableSession = true)]
        public string GenerateHoppmReport(string stylenumber, int styleid, int strClientId, int DepartmentId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
        {
            //int totalCount; 
            //return this.PDFControllerInstance.GenerateManageOrderReportPDFTest(100000, 0, "", -1, "2015,2016", -1, 1, 0, 18, 4, 1, 2, 3, -1, "", "", 0, 13, 5, 15, 0, "bh523zivkbekrmeija4pnb45", "ALL", "ALL", "APPROVED TO EX", "ALL", -1, "ALL");
            return this.PDFControllerInstance.GetPrintHoppm(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
            //return this.PDFControllerInstance.GetPrint(stylenumber, styleid, strClientId, DepartmentId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
        }

        [WebMethod(EnableSession = true)]
        public string GenerateRiskReport(string stylenumber, int styleid, int strClientId, int DepartmentId, int OrderId, int CreateNew, int NewRef, int ReUse, int ReUseStyleId, string RemarksType)
        {
            return this.PDFControllerInstance.GetPrintRisk(stylenumber, styleid, strClientId, DepartmentId, OrderId, CreateNew, NewRef, ReUse, ReUseStyleId, RemarksType);
        }


    }
}
