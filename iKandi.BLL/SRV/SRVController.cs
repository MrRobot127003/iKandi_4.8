using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using iKandi.Common;
using iKandi.Common.Entities;
using System.Data.SqlClient;

namespace iKandi.BLL
{
    public class SRVController : BaseController
    {
        #region Ctor(s)
        public SRVController()
        {
        }

        public SRVController(SessionInfo LoggedInUser)
            : base(LoggedInUser)
        {
        }
        #endregion

        #region Methods
        public RCDetail GetDetailForRCBySRId(int srId)
        {
            return this.SRVDataProviderInstance.GetDetailForRCBySRId(srId);
        }

        public int Insert_Update_SRV(RCDetail rcd)
        {
            return this.SRVDataProviderInstance.Insert_Update_SRV(rcd);
        }

        public RCDetail GetRCDetailById(int srvId)
        {
            return this.SRVDataProviderInstance.GetRCDetailById(srvId);
        }

        public List<RCDetail> GetRCDetailList(string ponumber, string suppliername, string fabricname, string challanno)
        {
            return this.SRVDataProviderInstance.GetRCDetailList(ponumber, suppliername, fabricname, challanno);
        }

        public List<string> GetPoNumberByName(string type)
        {
            return this.SRVDataProviderInstance.GetPoNumberByName(type);
        }

        public List<string> GetChallanNoByName(string type)
        {
            return this.SRVDataProviderInstance.GetChallanNoByName(type);
        }

        public List<string> GetDescriptionByName(string type)
        {
            return this.SRVDataProviderInstance.GetDescriptionByName(type);
        }

        public int Insert_Update_SRVReturn(RCDetail rcd)
        {
            return this.SRVDataProviderInstance.Insert_Update_SRVReturn(rcd);
        }

        public EiChallan GetEIChallanHeader(int poid, int stockId)
        {
            return this.SRVDataProviderInstance.GetEIChallanHeader(poid, stockId);
        }

        public int Insert_Update_EIChallan(EiChallan eic)
        {
            return this.SRVDataProviderInstance.Insert_Update_EIChallan(eic);
        }

        public SRCQ GetSRCQHeader(int FpId)
        {
            return this.SRVDataProviderInstance.GetSRCQHeader(FpId);
        }

        public int Insert_Update_SRCQ(SRCQ srcq)
        {
            return this.SRVDataProviderInstance.Insert_Update_SRCQ(srcq);
        }

        public int GetDuplicateSrvByPoId_BillNo(int poId, string billNo, int srvId)
        {
            return this.SRVDataProviderInstance.GetDuplicateSrvByPoId_BillNo(poId, billNo, srvId);
        }

        /// <summary>
        /// yaten:get all DebitCreditNote after Confirmation
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllDebitNoteBAL(int TaskId, string SupName, string PoNumber)
        {
            return this.SRVDataProviderInstance.GetAllDebitNoteDAL(TaskId, SupName, PoNumber);
        }

        /// <summary>
        /// Get PopUp data By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public DataSet DebitNotePopUpBAL(int Id)
        {
            return this.SRVDataProviderInstance.DebitNotePopUpDAL(Id);
        }


        /// <summary>
        /// yaten: Get All DebitCredit Note Information 
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllDebitCreditNoteBAL(string sup, int PoTyp, string Fab, string PoNo, DateTime dtFrom, DateTime dtTo)
        {
            return this.SRVDataProviderInstance.GetAllDebitCreditNoteDAL(sup, PoTyp, Fab, PoNo, dtFrom, dtTo);
            //return this.SRVDataProviderInstance.GetAllDebitCreditNoteDAL(PoTyp);
        }



        public DataSet GetAllDebitCreditNoteDALAfterSave(string sup, int PoTyp, string Fab, string PoNo, DateTime dtFrom, DateTime dtTo, string PoNumber)
        {
            return this.SRVDataProviderInstance.GetAllDebitCreditNoteDALAfterSave(sup, PoTyp, Fab, PoNo, dtFrom, dtTo, PoNumber);
            //return this.SRVDataProviderInstance.GetAllDebitCreditNoteDAL(PoTyp);
        }
        /// <summary>
        /// Yaten: Insert debit Note
        /// </summary>
        /// <param name="XMLDataAQL"></param>
        public string InserCreditNoteBAL(string Qty, double Amount, int intPOID, string XMLData, string stringReason, string SupName)
        {
            return this.SRVDataProviderInstance.InserCreditNoteDAL(Qty, Amount, intPOID, XMLData, stringReason, SupName);
        }

        public void InsertDebitNoteManagmentBAL(double RecValue, int RecType, string Reason, double NetAmount, int FabId, int FinanceId, int Id, int TaskToFinish, int TaskType)
        {
            this.SRVDataProviderInstance.InsertDebitNoteManagmentDAL(RecValue, RecType, Reason, NetAmount, FabId, FinanceId, Id, TaskToFinish, TaskType);
        }



        public DataSet GetAllCreditNoteBAL(string SupplierName, string PoNumber)
        {
            return this.SRVDataProviderInstance.GetAllCreditNoteDAL(SupplierName, PoNumber);
        }


        /// <summary>
        /// yaten : Insert CreditNote
        /// </summary>
        /// <param name="Qty"></param>
        /// <param name="Amount"></param>
        /// <param name="intPOID"></param>
        /// <param name="XMLData"></param>
        /// <param name="stringReason"></param>
        /// <param name="SupName"></param>
        /// <returns></returns>

        public string InsertCreditNoteDetailBAL(string SupName, double Amount, string Remarks, int UserId, string XmlDetail, string XmlPODeiakl)
        {
            return this.SRVDataProviderInstance.InsertCreditNoteDetailDAL(SupName, Amount, Remarks, UserId, XmlDetail, XmlPODeiakl);
        }


        public void InsertCreditNoteManagmentBAL(double RecValue, int RecType, string Reason, double NetAmount, int FabId, int FinanceId, int Id, int TaskToFinish, int TaskType)
        {
            this.SRVDataProviderInstance.InsertCreditNoteManagmentDAL(RecValue, RecType, Reason, NetAmount, FabId, FinanceId, Id, TaskToFinish, TaskType);
        }

        public string GetSRChallanNo(int id,int type)
        {
            return this.SRVDataProviderInstance.GetSRChallanNo(id, type);
        }
        #endregion
    }
}