using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.DAL;
using System.Web.Security;
using iKandi.BLL.Security;
using iKandi.Common;
using System.Data;

namespace iKandi.BLL
{
    public class BuyingHouseController : BaseController
    {
        #region

        public BuyingHouseController()
        {
        }

        public BuyingHouseController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public iKandi.Common.BuyingHouse SaveBuyingHouse(iKandi.Common.BuyingHouse BHUser)
        {
            if (BHUser.BuyingHouseID == -1)
            {

                int BHID = this.BuyingHouseDataProvider.CreateBuyingHouse(BHUser);
            }
            else
            {
                this.BuyingHouseDataProvider.UpdateBuyingHouse(BHUser);

            }

            return BHUser;
        }

        public iKandi.Common.BuyingHouse GetBHByID(int BHID)
        {
            return this.BuyingHouseDataProvider.GetBHByID(BHID);
        }

        public BuyingHouse GetBHByClientID(int ClientID)
        {
            return this.BuyingHouseDataProvider.GetBHByClientID(ClientID);
        }


        public List<iKandi.Common.Client> GetClientsByBHID(int BHID)
        {
            return this.BuyingHouseDataProvider.GetClientsByBHID(BHID);
        }

        public List<iKandi.Common.BuyingHouse> GetAllBuyingHouse()
        {
            return this.BuyingHouseDataProvider.GetAllBuyingHouse();
        }


        public int GetBuyingHouseStatusBAL(int intBuyingHouseID)
        {
            return this.BuyingHouseDataProvider.GetBuyingHouseStatusDAL(intBuyingHouseID);
        }

        public List<iKandi.Common.BuyingHouse> GetAllBuyingName()
        {
            return this.BuyingHouseDataProvider.GetAllBuyingName();
        }


        public System.Data.DataTable GetFPCAcceptanceCriteria()
        {
            return this.BuyingHouseDataProvider.GetFPCAcceptanceCriteria();
        }


        public int GetBuyingHouseStyleData(int ClientID)
        {
            return this.BuyingHouseDataProvider.GetBuyingHouseStyleData(ClientID);
        }

        public string GetDateInStringFormatBLL(string date)
        {
            return this.BuyingHouseDataProvider.GetDateInStringFormatDAL(date);
        }

        // Add By Ravi kumar on 07-oct-2014

        public DataTable GetAllBuyingHouseBAL(int CompanyId)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetAllBuyingHouseDAL(CompanyId);
            return dt;
        }

        public DataTable GetAllSalesYearBAL()
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetAllSalesYearDAL();
            return dt;
        }

        public DataTable GetWeekByYearBAL(int Year)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetWeekByMonthDAL(Year);
            return dt;
        }

        public DataTable GetBipl_Ikandi_MIS_Report_ProductionUnit_BAL(string year, int FromWeek, int ToWeek, int ClientID, int DateType, int UserId, int StatusMode, int StatusModeSequence, int unintID, int BH, string SessionId)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetBipl_Ikandi_MIS_Report_ProductionUnit_DAL(year, FromWeek, ToWeek, ClientID, DateType, UserId, StatusMode, StatusModeSequence, unintID, BH, SessionId);
            return dt;
        }

        public DataSet GetBipl_Ikandi_MIS_ReportBAL(string year, int FromWeek, int ToWeek, int ClientID, int DateType, int UserId, int StatusMode, int StatusModeSequence, int unintID, int BH, string SessionId, int AM, int DeptID, int ParentDeptID)
        {
            DataSet ds;
            ds = BuyingHouseDataProvider.GetBipl_Ikandi_MIS_Report_DAL(year, FromWeek, ToWeek, ClientID, DateType, UserId, StatusMode, StatusModeSequence, unintID, BH, SessionId, AM, DeptID, ParentDeptID);
            return ds;
        }

        public DataTable GetBiplTotalBreakEvenEffBAL_Budget(int ClientID, int DateType, int StatusMode, int StatusModeSequence, int unitID, int BH, string SessionId)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetBiplTotalBreakEvenEffDAL_Budget(ClientID, DateType, StatusMode, StatusModeSequence, unitID, BH, SessionId);
            return dt;
        }

        public DataTable GetBiplTotalBreakEvenEffBAL(int ClientID, int DateType, int StatusMode, int StatusModeSequence, int unintID, int BH, DateTime StartDate, DateTime EndDate, string SessionId,int AM,int DeptID)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetBiplTotalBreakEvenEffDAL(ClientID, DateType, StatusMode, StatusModeSequence, unintID, BH, StartDate, EndDate, SessionId, AM, DeptID);
            return dt;
        }

        public DataTable GetBipl_Ikandi_MIS_Breaked_ReportBAL(string sDateRangeDetails, string SessionId)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetBipl_Ikandi_MIS_Breaked_ReportDAL(sDateRangeDetails, SessionId);
            return dt;
        }

        public DataTable FillBudgetDetailsBAL()
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.FillBudgetDetailsDAL();
            return dt;
        }

        public DataTable FillDepartmentDetailsBAL()
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.FillDepartmentDetailsDAL();
            return dt;
        }

        public DataTable FillWorkerTypeDetailsBAL(string sStaffDept)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.FillWorkerTypeDetailsDAL(sStaffDept);
            return dt;
        }

        public DataTable GetAttandanceListBAL(string sFactoryName, DateTime dtStartDate, DateTime dtEndDate, string sDept, string sWorkerType)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetAttandanceListDAL(sFactoryName, dtStartDate, dtEndDate, sDept, sWorkerType);
            return dt;
        }

        public DateTime CheckLatestBudgetBAL(DateTime dtAttandanceDate)
        {
            DateTime dt;
            dt = BuyingHouseDataProvider.CheckLatestBudgetDAL(dtAttandanceDate);
            return dt;
        }

        public DataTable GetAttandanceSummaryBAL(string sFactoryName, DateTime dtStartDate, DateTime dtEndDate)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetAttandanceSummaryDAL(sFactoryName, dtStartDate, dtEndDate);
            return dt;
        }

        public DataTable CheckTimeFrameBAL(DateTime dtStartDate, DateTime dtEndDate)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.CheckTimeFrameDAL(dtStartDate, dtEndDate);
            return dt;
        }

        public decimal GetAbsentismBAL(DateTime dtStartDate, DateTime dtEndDate, int iFromWeekNo, int iToWeekNo)
        {
            decimal dAbsentism = 0;
            dAbsentism = BuyingHouseDataProvider.GetAbsentismDAL(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo);
            return dAbsentism;
        }

        public DataTable GetWorkingHoursBAL(DateTime dtStartDate, DateTime dtEndDate, int iFromWeekNo, int iToWeekNo)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetWorkingHoursDAL(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo);
            return dt;
        }

        public DataTable GetBiplAvailMinBAL()
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetBiplAvailMinDAL();
            return dt;
        }

        public DataTable GetBudgetLineFloorDetailsBAL(string sUnitName, DateTime dtStartDate, DateTime dtEndDate)
        {
            return BuyingHouseDataProvider.GetBudgetLineFloorDetailsDAL(sUnitName, dtStartDate, dtEndDate);
        }

        public DataTable GetBiplWorkerTypeBAL()
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetBiplWorkerTypeDAL();
            return dt;
        }

        public DataTable GetBiplAlreadyCreatedBudgetWorkerTypeBAL(DateTime dtStartDate, DateTime dtEndDate, bool IsAlreadyCreatedBudget)
        {
            DataTable dt = BuyingHouseDataProvider.GetBiplAlreadyCreatedBudgetWorkerTypeDAL(dtStartDate, dtEndDate, IsAlreadyCreatedBudget);
            return dt;
        }

        public DataTable GetBiplFactoryDetailsBAL(string sUnitName, DateTime dtStartDate, DateTime dtEndDate, decimal dAbsentism, decimal dWorkingHours, int iFromWeek, int iToWeek, string sFinancialYear, bool IsFinalizeBudget, int iUserId)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetBiplFactoryDetailsDAL(sUnitName, dtStartDate, dtEndDate, dAbsentism, dWorkingHours, iFromWeek, iToWeek, sFinancialYear, IsFinalizeBudget, iUserId);
            return dt;
        }

        public bool CheckIsEnabledBudgetBAL(int iFromWeek, int iToWeek)
        {
            bool IsEnabled = false;
            IsEnabled = BuyingHouseDataProvider.CheckIsEnabledBudgetDAL(iFromWeek, iToWeek);
            return IsEnabled;
        }

        public bool CheckIsFinalizeBudgetBAL(DateTime dtFromWeek, DateTime dtToWeek)
        {
            return BuyingHouseDataProvider.CheckIsFinalizeBudgetDAL(dtFromWeek, dtToWeek);
        }

        public DataTable GetBiplBudgetMMRDetailsBAL(DateTime dtStartDate, DateTime dtEndDate)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetBiplBudgetMMRDetailsDAL(dtStartDate, dtEndDate);
            return dt;
        }

        public DataTable GetBiplBudgetCPAMDetailsBAL(DateTime dtStartDate, DateTime dtEndDate, int iFromWeekNo, int iToWeekNo, decimal dWorkingHours, string sFactoryName)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetBiplBudgetCPAMDetailsDAL(dtStartDate, dtEndDate, iFromWeekNo, iToWeekNo, dWorkingHours, sFactoryName);
            return dt;
        }

        public bool UpdateWorkingHours(int iOrderId, decimal dAbsentism, int iOT1, int iOT2, int iOT3, int iOT4, DateTime dtFromWeek, DateTime dtToWeek, bool IsFinalizeBudget, int iUserId)
        {
            BuyingHouseDataProvider.UpdateWorkingHours(iOrderId, dAbsentism, iOT1, iOT2, iOT3, iOT4, dtFromWeek, dtToWeek, IsFinalizeBudget, iUserId);
            return true;
        }

        public int UpdateBudgetLines_Floor(string UnitName, string Mode, int Cutting, int Stitching, int Finishing, DateTime dtFromWeek, DateTime dtToWeek)
        {
            return BuyingHouseDataProvider.UpdateBudgetLines_Floor(UnitName, Mode, Cutting, Stitching, Finishing, dtFromWeek, dtToWeek);
        }

        public bool UpdateBudgetDetails(int iWorkerTypeId, int iFactoryWorkSpce, int iUnitId, int iFromWeekCountNo, int iToWeekCountNo, int iBudCount, decimal dBudCost, decimal dHrDay, int iModifyBy)
        {
            BuyingHouseDataProvider.UpdateBudgetDetails(iWorkerTypeId, iFactoryWorkSpce, iUnitId, iFromWeekCountNo, iToWeekCountNo, iBudCount, dBudCost, dHrDay, iModifyBy);
            return true;
        }

        public bool InsertSalesView(int Year, int Month, int Week, string SessionId)
        {
            BuyingHouseDataProvider.InsertSalesView(Year, Month, Week, SessionId);
            return true;
        }

        public int InsertSalesView_Styles(DateTime FromDate, DateTime ToDate, int ClientId, int DateType, int FromStatus, int ToStatus, int unitID, int BH, bool IsSTC, bool IsBIH, bool IsBIHSTC, string SessionId)
        {
            return BuyingHouseDataProvider.InsertSalesView_Styles(FromDate, ToDate, ClientId, DateType, FromStatus, ToStatus, unitID, BH, IsSTC, IsBIH, IsBIHSTC, SessionId);
        }

        //public bool DeleteSalesView(string SessionId)
        //{
        //    BuyingHouseDataProvider.DeleteSalesView(SessionId);
        //    return true;
        //}

        public double GetExportConverstionRate()
        {
            return this.BuyingHouseDataProvider.GetExportConverstionRate();
        }
        //Added By Ashish on 14/4/2015
        public DataTable GetBuyingHouseById(int CompanyId, int DateType, string YearRenge)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetBuyingHouseById(CompanyId, DateType, YearRenge);
            return dt;
        }
        public DataTable GetAMList(int DateType, string YearRenge)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetAMList(DateType, YearRenge);
            return dt;
        }
        //END
        //Added By Abhishek on 25/4/2015
        public List<BuyingHouse> GetBuyingHouselistById(int CompanyId, int DateType, string YearRenge)
        {
            return this.BuyingHouseDataProvider.GetBuyingHouselistById(CompanyId, DateType, YearRenge);
        }
        public List<BuyingHouse> GetBuyingHouselistById_ForAM(int CompanyId, int DateType, string YearRenge, int AM)
        {
            return this.BuyingHouseDataProvider.GetBuyingHouselistById_ForAM(CompanyId, DateType, YearRenge, AM);
        }

        public DataTable GetBiplUNITNAMEBAL()
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetBiplUNITNAME_DAL();
            return dt;
        }

        public string GetWorkingDays_BAL()
        {
            return this.BuyingHouseDataProvider.GetWorkingDays_DAL();
        }
        public string GetMMR_WorkingHours_BAL(DateTime dtDateFrom, DateTime dtDateTo)
        {
            return this.BuyingHouseDataProvider.GetMMR_WorkingHours_DAL(dtDateFrom, dtDateTo);
        }

        public DataTable GetMMR_Summary_Daily_BAL(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            DataTable dt;
            dt = ProductionDataProviderInstance.GetMMR_Summary_Daily_DAL(sUnitName, dtDate, sFinancialYear);
            return dt;
        }

        public string GetCostedProductionCost_BAL(DateTime dtDateFrom, DateTime dtDateTo, string FactoryName)
        {
            return this.BuyingHouseDataProvider.GetCostedProductionCost_DAL(dtDateFrom, dtDateTo, FactoryName);
        }

        public DataTable GetMMR_CMT_Report_Daily_BAL(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetMMR_CMT_Report_Daily_DAL(sUnitName, dtDate, sFinancialYear);
            return dt;
        }


        public DataTable GetMMR_CMT_Report_DateRange_BAL(string sUnitName, DateTime dtDateFrom, DateTime dtDateTo, string sFinancialYear)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetMMR_CMT_Report_DateRange_DAL(sUnitName, dtDateFrom, dtDateTo, sFinancialYear);
            return dt;
        }

        public DataTable GetMMR_BudgetSummary_Daily_BAL(string sUnitName, DateTime dtDate, string sFinancialYear)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetMMR_BudgetSummary_Daily_DAL(sUnitName, dtDate, sFinancialYear);
            return dt;
        }

        public DataTable GetMMR_BudgetSummary_DateRange_BAL(string sUnitName, DateTime dtDateFrom, DateTime dtDateTo, string sFinancialYear)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetMMR_BudgetSummary_DateRange_DAL(sUnitName, dtDateFrom, dtDateTo, sFinancialYear);
            return dt;
        }

        public DataTable GetMMR_Summary_DateRange_BAL(string sUnitName, DateTime dtDateFrom, DateTime dtDateTo, string sFinancialYear)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetMMR_Summary_DateRange_DAL(sUnitName, dtDateFrom, dtDateTo, sFinancialYear);
            return dt;
        }

        public DataTable GetDaily_MMR_Report_BAL(string sUnitName, DateTime dtDateFrom, DateTime dtDateTo, string sFinancialYear)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetDaily_MMR_Report_DAL(sUnitName, dtDateFrom, dtDateTo, sFinancialYear);
            return dt;
        }
        //Added by abhishek on 14/10/2015-------------------------------------------------//

        public DataTable GetBuingHouseName()
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetBuingHouseName();
            return dt;
        }
        public DataTable GetDivison_Details(int id)
        {
            DataTable dt;
            dt = BuyingHouseDataProvider.GetDivison_Details(id);
            return dt;
        }
        public string InsertUpdateManage_Divison(string groupName, string DivisonName, bool IsAct, string BuyingHouseID, string domainName, int ID)
        {
            return this.BuyingHouseDataProvider.InsertUpdateManage_Divison(groupName, DivisonName, IsAct, BuyingHouseID, domainName, ID);
        }

        //end by abhishek on 14/10/2015----------------------------------------------------//

        public DataTable GetBreakedStyleDetails(string CompleteDateRange, string SessionId)
        {
            return BuyingHouseDataProvider.GetBreakedStyleDetails(CompleteDateRange, SessionId);
        }
    }
}
