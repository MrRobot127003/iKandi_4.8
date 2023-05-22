using System.Data;
using iKandi.Common;

namespace iKandi.BLL
{
    public class FinancialController : BaseController
    {
        #region Ctor(s)
        public FinancialController()
        {
        }

        public FinancialController(SessionInfo loggedInUser)
            : base(loggedInUser)
        {
        }
        #endregion

        #region Methods
        public ListFosp GetSupplierGroupDueList()
        {
            return this.FinancialDataProviderInstance.GetSupplierGroupDueList();
        }

        public ListSdl GetSupplierDueList(string supplierGroup, int poType, int fortNight)
        {
            return this.FinancialDataProviderInstance.GetSupplierDueList(supplierGroup, poType, fortNight);
        }

        public ListSrvBill GetSrvBySuppleirGroup(string supplierGroup)
        {
            return this.FinancialDataProviderInstance.GetSrvBySupplierGroup(supplierGroup);
        }

        public int InsertIntoSrvBill(int poid,string suppliergroup,int createdby,string srvids)
        {
            return this.FinancialDataProviderInstance.InsertIntoSrvBill(poid,suppliergroup, createdby, srvids);
        }

        public SrvBillDetail GetSrvListByBillId(int billId)
        {
            return this.FinancialDataProviderInstance.GetSrvListByBillId(billId);
        }

        public DataSet GetSrvDetailBySupplierGroup(string suppliergroup)
        {
            return this.FinancialDataProviderInstance.GetSrvDetailBySupplierGroup(suppliergroup);
        }

        public ListSbDetail GetSBDetailListBySupplierGroup(string supplierGroup,int level)
        {
            return this.FinancialDataProviderInstance.GetSBDetailListBySupplierGroup(supplierGroup, level);
        }

        public void InsertIntoSrvBillManagement(ListSbDetail lsb)
        {
            this.FinancialDataProviderInstance.InsertIntoSrvBillManagement(lsb);
        }

        public void InsertIntoFinancialFop(ListFinancialFop lsb)
        {
             this.FinancialDataProviderInstance.InsertIntoFinancialFop(lsb);
        }

        public SupplierSettleMent GetSsDueList(int fpId)
        {
            return this.FinancialDataProviderInstance.GetSsDueList(fpId);
        }

        public int InsertIntoSupplierMainBill(SSMainBill ssMainBill)
        {
            return this.FinancialDataProviderInstance.InsertIntoSupplierMainBill(ssMainBill);
        }

        public ListSrvBill GetPendingSrvBySrvId(int srvId)
        {
            return this.FinancialDataProviderInstance.GetPendingSrvBySrvId(srvId);
        }

        public string GetSupplierGroupBySrvId(int srvId)
        {
            return this.FinancialDataProviderInstance.GetSupplierGroupBySrvId(srvId);
        }

        public string GetSupplierGroupBySrvBillId(int sbId)
        {
            return this.FinancialDataProviderInstance.GetSupplierGroupBySrvBillId(sbId);
        }

        public ListFosp GetSupplierGroupDueListByLevel(int level)
        {
            return this.FinancialDataProviderInstance.GetSupplierGroupDueListByLevel(level);
        }
        #endregion
      //added by abhishek 2/11/2018
        public DataTable GetFinancialYear()
        {
            return FinancialDataProviderInstance.GetFinancialYear();
        }
        public DataSet GetMonthlyActualCMTValue(string FinancialYear)
        {
            return this.FinancialDataProviderInstance.GetMonthlyActualCMTValue(FinancialYear);
        }

        public int InsertActualCMT(int FinancialID, int MonthNumber, string FinancialYear, double ActualCMT, int CreatedBy)
        {
            return FinancialDataProviderInstance.InsertActualCMT(FinancialID, MonthNumber, FinancialYear, ActualCMT, CreatedBy);
        }

        public DataSet GetBIPLfinancialValue()
        {
          return this.FinancialDataProviderInstance.GetBIPLfinancialValue();
        }
        public int InsertbiplExportrevenue(int p_ID, double BIPLExportValues, double BIPLExportPCS, double IkandiExportValues, double IkandiExportPCS)
        {
          return this.FinancialDataProviderInstance.InsertbiplExportrevenue(p_ID, BIPLExportValues, BIPLExportPCS, IkandiExportValues, IkandiExportPCS);
        }
    }
}
