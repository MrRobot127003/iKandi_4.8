using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.DAL;
using System.Data;

namespace iKandi.BLL
{
    public class PrintController : BaseController
    {
        #region

        public PrintController()
        {
        }

        public PrintController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }

        #endregion

        public List<Print> GetPrints(int PageSize, int PageIndex, out int TotalPageCount, int ClientId, string SearchText, int PrintTypeID)
        {
            return this.PrintDataProviderInstance.GetAllPrints(PageSize, PageIndex, out TotalPageCount, ClientId, SearchText, PrintTypeID);
        }

        public Print Save(Print FabricPrint)
        {

            if (FabricPrint.PrintID == -1)
            {
                this.PrintDataProviderInstance.InsertPrint(FabricPrint);
            }
            else
            {
                this.PrintDataProviderInstance.UpdatePrint(FabricPrint);
            }

            return FabricPrint;
        }

        public Print GetPrintById(int PrintId)
        {
            return this.PrintDataProviderInstance.GetPrintById(PrintId);
        }
        public List<iKandi.Common.Print> GetAllPrintsNo()
        {
            return this.PrintDataProviderInstance.GetAllPrintsNo();
        }

        public string GetNewPrintNumber()
        {
            return this.PrintDataProviderInstance.GetNewPrintNumber();
        }

        public Print GetPrintByPrintNumber(string PrintNumber)
        {
            return this.PrintDataProviderInstance.GetPrintByPrintNumber(PrintNumber);
        }

        public string GetPrintImageUrlByPrintNumber(string PrintNumber)
        {
            return this.PrintDataProviderInstance.GetPrintImageUrlByPrintNumber(PrintNumber);
        }



        public string GetPrintNumberByRefBAL(string PrintNumber)
        {
            return this.PrintDataProviderInstance.GetPrintNumberByRefBDAL(PrintNumber);
        }





        public List<Print> GetPrintVariations(int PrintId)
        {
            return this.PrintDataProviderInstance.GetPrintVariations(PrintId);
        }

        public List<Print> SearchShowroomPrints(int PageSize, int PageIndex, out int TotalRowCount, string ClientIds, string SearchText, string PrintTypeIDs, DateTime StartDate, DateTime EndDate, int SoldStatus)
        {
            return this.PrintDataProviderInstance.SearchShowroomPrints(PageSize, PageIndex, out  TotalRowCount, ClientIds, SearchText, PrintTypeIDs, StartDate, EndDate, SoldStatus);
        }

        public List<Print> GetShowroomPrintDetails(string PrintIDs)
        {
            return this.PrintDataProviderInstance.GetShowroomPrintDetails(PrintIDs);
        }

        public int InsertPrintTestingHistory(PrintHistory PrintTestingHistory)
        {
            if (PrintTestingHistory.ParentPrint.PrintID != -1)
            {
                return this.PrintDataProviderInstance.SavePrintTestingHistory(PrintTestingHistory);
            }
            else
            {
                return -1;
            }
        }

        public List<PrintHistory> GetPrintTestingHistoryByPrintId(int PrintId)
        {
            return this.PrintDataProviderInstance.GetPrintTestingHistoryByPrintId(PrintId);
        }

        /// <summary>
        /// Yaten : Get All Buying House 31 May
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllBuyingHouseBAL()
        {
            DataTable dt;
            dt = PrintDataProviderInstance.GetAllBuyingHouseDAL();
            return dt;
        }

        public DataTable GetDivisionBy_Designation(string DesignationID)
        {
            DataTable dt;
            dt = PrintDataProviderInstance.GetDivisionBy_Designation(DesignationID);
            return dt;
        }
        #region Gajendra Client Form Updates
        //Gajendra Client Form 26-11-2015
        public DataTable GetDivisionName()
        {
            DataTable dt;
            dt = PrintDataProviderInstance.GetDivisionName();
            return dt;
        }
        //Gajendra Client Form 26-11-2015
        public DataTable GetBuyingHouseByDivision(string DivisionID)
        {
            DataTable dt;
            dt = PrintDataProviderInstance.GetBuyingHouseByDivision(DivisionID);
            return dt;
        }
        #endregion

        public DataTable GetAllAqlStans()
        {
            DataTable dt;
            dt = PrintDataProviderInstance.GetAllAqlStans();
            return dt;
        }
        /// <summary>
        /// Yaten : Get all client according to Buying House 31 May
        /// </summary>
        /// <param name="intID"></param>
        /// <returns></returns>

        public DataTable GetAllClientForBuyingHouseBAL(int intID, int ClientId)
        {
            DataTable dt;
            dt = PrintDataProviderInstance.GetAllClientForBuyingHouseDAL(intID, ClientId);
            return dt;
        }

        public DataTable GetAllDeptForClient(int ClientId)
        {
            DataTable dt;
            dt = PrintDataProviderInstance.GetAllDeptForClient(ClientId);
            return dt;
        }
        // Edit by surendra on 20 may 2013 
        public DataTable GetAllUnitL(int DesignationID, int UserID)
        {
            DataTable dt;
            dt = PrintDataProviderInstance.GetAllUnitL(DesignationID,UserID);
            return dt;
        }
       
        public List<Print> GetAllPrintsBuyingHouseBAL(out int TotalPageCount, int ClientId, string SearchText, int PrintTypeID, int PrintCategory, int intBuyingHouseId, int intDepartmentID, int ChildClientDeptID)
        {
            return this.PrintDataProviderInstance.GetAllPrintsBuyingHouseDAL(out TotalPageCount, ClientId, SearchText, PrintTypeID, PrintCategory, intBuyingHouseId, intDepartmentID, ChildClientDeptID);
        }




        // Add by Ravi kumar on 4/4/2015 for Department on Manage Order
        public DataTable GetAllDeptByClientDAL(int intID, int UserID, bool IsClient, bool IsClientDept)
        {
            DataTable dt;
            dt = PrintDataProviderInstance.GetAllDeptByClientDAL(intID, UserID, IsClient, IsClientDept);
            return dt;
        }
        //Added By Ashish on 14/4/2015
        public DataTable GetAllDeptByClientForManageOrder(int intID, int ClientId, int DateType, string YearRange, int UserId,int AM)
        {
            DataTable dt;
            dt = PrintDataProviderInstance.GetAllDeptByClientForManageOrderDAL(intID, ClientId, DateType, YearRange, UserId,AM);
            return dt;
        }
        //END
        //Added By abhishek 27/4/2015
        public List<Client> GetAllClientDetailsForManageOrder(int BuyingHouseId, int ClientId, int DateType, string YearRange, int UserID,int AM)
        {


            return this.PrintDataProviderInstance.GetAllDeptByClientForManageOrderDAL1(BuyingHouseId, ClientId, DateType, YearRange, UserID,AM);
        }
        public List<Client> GetClientDetailslist_ForAM(int BuyingHouseId, int ClientId, int DateType, string YearRange, int UserID,int AM)
        {


            return this.PrintDataProviderInstance.GetClientDetailslist_ForAM(BuyingHouseId, ClientId, DateType, YearRange, UserID, AM);
        }
        
        public List<Client> GetAllAM(int DateType, string YearRange)
        {


            return this.PrintDataProviderInstance.GetAllAM(DateType, YearRange);
        }
        public List<Department> Get_Parent_DepartmentDetailslist(int intID, int UserID, bool IsClient, bool IsClientDept, int DateType, string YearRange, int AM)
        {


            return this.PrintDataProviderInstance.Get_Parent_DepartmentDetailslist(intID, UserID, IsClient, IsClientDept, DateType, YearRange, AM);
        }
        public List<Department> GetAllDepartmentDetailsbyId(int intID, int UserID, bool IsClient, bool IsClientDept, int DateType, string YearRange,int AM,int ParentDepartmentID)
        {


            return this.PrintDataProviderInstance.GetAllDepartmentDetailsbyId(intID, UserID, IsClient, IsClientDept, DateType, YearRange, AM, ParentDepartmentID);
        }
        public List<Department> GetDepartmentDetailslist_ForAM(int intID, int UserID, bool IsClient, bool IsClientDept, int DateType, string YearRange, int AM)
        {


            return this.PrintDataProviderInstance.GetDepartmentDetailslist_ForAM(intID, UserID, IsClient, IsClientDept, DateType, YearRange,AM);
        }
        
        //Added By Ashish on 16/4/2015
        public DataTable GetAllDeptByClientId(int intID, int UserID, bool IsClient, bool IsClientDept, int DateType, string YearRange, int AM, int ParentDeptID)
        {
            DataTable dt;
            dt = PrintDataProviderInstance.GetAllDeptByClientId(intID, UserID, IsClient, IsClientDept, DateType, YearRange, AM, ParentDeptID);
            return dt;
        }
        public DataTable GetParentDeptID(int intID, int UserID, bool IsClient, bool IsClientDept, int DateType, string YearRange, int AM)
        {
            DataTable dt;
            dt = PrintDataProviderInstance.GetParentDeptID(intID, UserID, IsClient, IsClientDept, DateType, YearRange, AM);
            return dt;
        }
        //added by abhishek on 14/9/2015
        public DataTable GetAllfactoryUnit(int P_id)
        {
            DataTable dt;
            dt = PrintDataProviderInstance.GetAllfactoryUnit(P_id);
            return dt;
        }
        //end by abhishek on 14/9/2015
        public DataSet GetAllPrintsBuyingHouseDALsolddetails()
        {
          return this.PrintDataProviderInstance.GetAllPrintsBuyingHouseDALsolddetails();
        }
        public string GetPrintNumberByRefBAL_New(string PrintNumber)
        {
            return this.PrintDataProviderInstance.GetPrintNumberByRefBDAL_New(PrintNumber);
        }
        public string GetPrintImageUrlByPrintNumber_New(string PrintNumber)
        {
            return this.PrintDataProviderInstance.GetPrintImageUrlByPrintNumber_New(PrintNumber);
        }
        public string CheckPrintAlreadyExists(string PrintNumber, int printId)
        {
          return this.PrintDataProviderInstance.CheckPrintAlreadyExists(PrintNumber,printId);
        }
        //END


        public DataTable CountryCode()
        {
            return this.PrintDataProviderInstance.CountryCode();
        }
    }
}
