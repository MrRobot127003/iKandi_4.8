using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    [Serializable]
    public class FabricOutStandingPayments : EntityBasetable
    {
        public int PoType
        {
            get;
            set;
        }

        public string SupplierGroup
        {
            get;
            set;
        }

        public double DAmount
        {
            get;
            set;
        }

        public double CAmount
        {
            get;
            set;
        }

        public double NAmount
        {
            get;
            set;
        }

        public double Delayed
        {
            get;
            set;
        }

        public double CurrentDue
        {
            get;
            set;
        }

        public double NextDue
        {
            get;
            set;
        }

        public double Exposure
        {
            get;
            set;
        }

        public double TotalDue
        {
            get;
            set;
        }

        public double SuggestedAmount
        {
            get;
            set;
        }

        public DateTime SuggestedDate
        {
            get;
            set;
        }

        public double AuthorizedAmount
        {
            get;
            set;
        }

        public DateTime AuthorizedDate
        {
            get;
            set;
        }

        public double PaidAmount
        {
            get;
            set;
        }

        public DateTime PaidDate
        {
            get;
            set;
        }

        public int FF1Id
        {
            get;
            set;
        }

        public double FF1AAmount
        {
            get;
            set;
        }

        public DateTime FF1ADate
        {
            get;
            set;
        }

        public double FF1SAmount
        {
            get;
            set;
        }

        public DateTime FF1SDate
        {
            get;
            set;
        }

        public double FF1PAmount
        {
            get;
            set;
        }

        public DateTime FF1PDate
        {
            get;
            set;
        }

        public int FF2Id
        {
            get;
            set;
        }

        public double FF2AAmount
        {
            get;
            set;
        }

        public DateTime FF2ADate
        {
            get;
            set;
        }

        public double FF2SAmount
        {
            get;
            set;
        }

        public DateTime FF2SDate
        {
            get;
            set;
        }

        public double FF2PAmount
        {
            get;
            set;
        }

        public DateTime FF2PDate
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ListFosp : List<FabricOutStandingPayments>
    {

    }

    [Serializable]
    public class SupplierDueList : EntityBasetable
    {
        public string SupplierName
        {
            get;
            set;
        }

        public string TType
        {
            get;
            set;
        }

        public string BillNo
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }

        public DateTime DueDate
        {
            get;
            set;
        }

        public int SrvId
        {
            get;
            set;
        }

        public int PoId
        {
            get;
            set;
        }

        public int SupplierId
        {
            get;
            set;
        }

        public string SupplierGroup
        {
            get;
            set;
        }

        public DateTime BillDate
        {
            get;
            set;
        }

        public DateTime LeadDate
        {
            get;
            set;
        }

        public int PoType
        {
            get;
            set;
        }

        public int LeadTime
        {
            get;
            set;
        }

        /// <summary>
        /// -1 for prev, 0 for cur, 1 for next
        /// </summary>
        public int FortNight
        {
            get;
            set;
        }

        public double SuggestedAmount
        {
            get;
            set;
        }

        public double ApprovedAmount
        {
            get;
            set;
        }

        public double ClaimedAmount
        {
            get;
            set;
        }

        public string Clearance
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ListSdl : List<SupplierDueList>
    {

    }

    [Serializable]
    public class SrvBill : RCDetail
    {
        public string SupplierGroupName
        {
            get;
            set;
        }

        public int PoType
        {
            get;
            set;
        }

        public int SrvId
        {
            get;
            set;
        }

        public string SrvNo
        {
            get;
            set;
        }

        public DateTime SrvDate
        {
            get;
            set;
        }

        public DateTime BillDate
        {
            get;
            set;
        }

        public double ClaimedQty
        {
            get;
            set;
        }

        public bool Select
        {
            get;
            set;
        }

        public SrvBill()
        {
            Select = false;
        }
    }

    [Serializable]
    public class ListSrvBill : List<SrvBill>
    {

    }

    [Serializable]
    public class SrvBillDetail : SrvBillManagement
    {
        public int PoId
        {
            get;
            set;
        }

        public string SupplierGroup
        {
            get;
            set;
        }

        public int PoType
        {
            get;
            set;
        }

        public int OrderType
        {
            get;
            set;
        }

        public string PoNumber
        {
            get;
            set;
        }

        public string BillNo
        {
            get;
            set;
        }

        public string SrvIds
        {
            get;
            set;
        }

        public string Unit
        {
            get;
            set;
        }

        public int CurrencyUnit
        {
            get;
            set;
        }

        public string CurrencySymbol
        {
            get;
            set;
        }

        public double Rate
        {
            get;
            set;
        }

        public string SrvNos
        {
            get;
            set;
        }

        public double ClaimedQty
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }

        public double TotalAmount
        {
            get;
            set;
        }

        public int PaymentTerms
        {
            get;
            set;
        }

        public string UserName
        {
            get;
            set;
        }

        public string Designation
        {
            get;
            set;
        }

        public ListSrvBill lSrvBill
        {
            get;
            set;
        }
    }

    [Serializable]
    public class SrvBillManagement : EntityBasetable
    {
        public SrvBillManagement()
        {
            IsSample = 0;
        }

        public string SupplierBillNo
        {
            get;
            set;
        }

        public string Instruction
        {
            get;
            set;
        }

        public DateTime SupplierBillDate
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }

        public double ExtraBill
        {
            get;
            set;
        }

        public double ScreenCost
        {
            get;
            set;
        }

        public DateTime DeadLine
        {
            get;
            set;
        }

        public int SrvBillId
        {
            get;
            set;
        }

        public int FabricChecked
        {
            get;
            set;
        }

        public int FinanceChecked
        {
            get;
            set;
        }

        public int FabricDepttId
        {
            get;
            set;
        }

        public int FinanceDepttId
        {
            get;
            set;
        }
        
        public DateTime FabricDate
        {
            get;
            set;
        }

        public DateTime FinanceDate
        {
            get;
            set;
        }

        public int SbmId
        { 
            get; set;
        }

        public int Level
        {
            get;
            set;
        }

        public int IsSample
        {
            get;
            set;
        } 
    }

    [Serializable]
    public class ListSbDetail : List<SrvBillManagement>
    {

    }

    [Serializable]
    public class FinancialFop : EntityBasetable
    {
        public string SupplierGroup
        {
            get;
            set;
        }

        public double DelayAmount
        {
            get;
            set;
        }

        public double CurFortNight
        {
            get;
            set;
        }

        public double NextFortNight
        {
            get;
            set;
        }

        public double SuggestedAmount
        {
            get;
            set;
        }

        public DateTime SuggestedDate
        {
            get;
            set;
        }

        public double AuthorizedAmount
        {
            get;
            set;
        }

        public DateTime AuthorizedDate
        {
            get;
            set;
        }

        public double PaidAmount
        {
            get;
            set;
        }

        public double PaidDate
        {
            get;
            set;
        }

        public int PoTypeId
        {
            get;
            set;
        }

        public int Level
        {
            get;
            set;
        }
    }

    [Serializable]
    public class SupplierSettleMent : FinancialFop
    {
        public ListSdl LSdl
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ListFinancialFop : List<FinancialFop>
    {
        
    }

    [Serializable]
    public class SupplierSettlement : EntityBasetable
    {
        public string SupplierName
        {
            get;
            set;
        }

        public int SupplierId
        {
            get;
            set;
        }

        public string BillNo
        {
            get;
            set;
        }

        public double BillAmount
        {
            get;
            set;
        }

        public DateTime DueDate
        {
            get;
            set;
        }

        public double AmountPay
        {
            get;
            set;
        }

        public string BillClearance
        {
            get;
            set;
        }

        public double DebitAmount
        {
            get;
            set;
        }

        public int Select
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ListSSettlement : List<SupplierSettlement>
    {

    }

    [Serializable]
    public class SSMainBill : EntityBasetable
    {
        public string SupplierGroup
        {
            get;
            set;
        }

        public double AuthorizedAmount
        {
            get;
            set;
        }

        public double TotalPaidAmount
        {
            get;
            set;
        }

        public string BillNo
        {
            get;
            set;
        }

        public int PoType
        {
            get;
            set;
        }

        public int FopId
        {
            get;
            set;
        }

        public List<SSBillCheque> ListCheque
        {
            get;
            set;
        }

        public List<SSBillSupplier> ListSupplier
        {
            get;
            set;
        }
    }

    [Serializable]
    public class SSBillCheque : EntityBasetable
    {
        public int SupplierId
        {
            get;
            set;
        }

        public int SrvId
        {
            get;
            set;
        }

        public double PaidAmount
        {
            get;
            set;
        }

        public double DebitAmount
        {
            get;
            set;
        }

        public string ChequeNo
        {
            get;
            set;
        }

        public DateTime ChequeDate
        {
            get;
            set;
        }

        public int SSMainBillId
        {
            get;
            set;
        }
    }

    [Serializable]
    public class SSBillSupplier : EntityBasetable
    {
        public int SupplierId
        {
            get;
            set;
        }

        public string SupplierBillNo
        {
            get;
            set;
        }

        public string TType
        {
            get;
            set;
        }

        public double BillAmount
        {
            get;
            set;
        }

        public DateTime DueDate
        {
            get;
            set;
        }

        public double AmountPay
        {
            get;
            set;
        }

        public double DebitAmount
        {
            get;
            set;
        }

        public int Status
        {
            get;
            set;
        }

        public int SSBillChequeId
        {
            get;
            set;
        }

        public int SrvId
        {
            get;
            set;
        }
    }
}
