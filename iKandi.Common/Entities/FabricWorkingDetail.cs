using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common.Entities
{
    public class FabricWorkingDetail
    {
        public Int32 Id
        {
            get;
            set;
        }

        public Int32 FabricWorkingID
        {
            get;
            set;
        }

        public String FabricName
        {
            get;
            set;
        }

        public Decimal Quantity
        {
            get;
            set;
        }
        public String FinalP1
        {
            get;
            set;
        }
        public String FinalCN1
        {
            get;
            set;
        }
        public String FinalFw1
        {
            get;
            set;
        }


        public Int32 TotalQuantity
        {
            get;
            set;
        }

        public String Details
        {
            get;
            set;
        }

        public String FilePath
        {
            get;
            set;
        }

        public Decimal Number
        {
            get;
            set;
        }

        public Boolean IsDTM
        {
            get;
            set;
        }

        public String Swatch
        {
            get;
            set;
        }

        public DateTime ApprovedDate
        {
            get;
            set;
        }
        public DateTime CurrentDate
        {
            get;
            set;
        }

        public DateTime BulkInhouse
        {
            get;
            set;
        }
        public String InHouseHistory
        {
            get;
            set;
        }

        public Boolean IsOld
        {
            get;
            set;
        }
    }

    public class FabricInHouseHistory
    {
        public String FabricName
        {
            get;
            set;
        }

        public Int32 OrderDetailID
        {
            get;
            set;
        }

        public Int32 FabricWorkingDetailID
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public Int32 Quantity
        {
            get;
            set;
        }

        public Int32 PercentInHouse
        {
            get;
            set;
        }

        public DateTime ApprovedDate
        {
            get;
            set;
        }
    }

    public class FabricWorking
    {
        public Int32 Id
        {
            get;
            set;
        }

        public Order Order
        {
            get;
            set;
        }
        public List<FabricWorkingDetail> FabricWorkingDetailCount
        {
            get;
            set;
        }
        public Int32 ApprovedByFabricManager
        {
            get;
            set;
        }

        public DateTime ApprovedByFabricManagerOn
        {
            get;
            set;
        }

        public Int32 ApprovedByAccountManager
        {
            get;
            set;
        }

        public DateTime ApprovedByAccountManagerOn
        {
            get;
            set;
        }

        public String MainLabel
        {
            get;
            set;
        }

        public String Tags
        {
            get;
            set;
        }

        public String WashCare
        {
            get;
            set;
        }

        public String SizeLabel
        {
            get;
            set;
        }

        public String Swatch
        {
            get;
            set;
        }


        public List<FabricWorkingDetail> FabricWorkingDetail
        {
            get;
            set;
        }

        public List<FabricInHouseHistory> FabricHistory
        {
            get;
            set;
        }

        public string History
        {
            get;
            set;
        }
        public List<FabricPending> FabricPendingList
        {
            get;
            set;
        }
    }

    public class Fabric
    {
        public Int32 Id
        {
            get;
            set;
        }

        public String Name
        {
            get;
            set;
        }

        public Decimal Quantity
        {
            get;
            set;
        }

        public int TotalQuantity
        {
            get;
            set;
        }

    }

    public class FabricPending
    {
        public int FabricWorkingDetailId
        {
            get;
            set;
        }
        public int FabricMasterId
        {
            get;
            set;
        }
        public string FabricName
        {
            get;
            set;
        }
        public int FabricQualitySizeId
        {
            get;
            set;
        }
        public int SupplierId
        {
            get;
            set;
        }
        public string Size
        {
            get;
            set;
        }
        public string Color_Print
        {
            get;
            set;
        }
        public string StyleNumber
        {
            get;
            set;
        }
        public string SerialNumber
        {
            get;
            set;
        }
        public int OrderDetailId
        {
            get;
            set;
        }
        public string ContractNumber
        {
            get;
            set;
        }
        public string LineItemNumber
        {
            get;
            set;
        }
        public int ContractQty
        {
            get;
            set;
        }
        public double FabricAvg
        {
            get;
            set;
        }
        public int Stage1
        {
            get;
            set;
        }
        public int Stage2
        {
            get;
            set;
        }
        public double FabricQty
        {
            get;
            set;
        }
        public DateTime OrderDate
        {
            get;
            set;
        }
        public bool IsFabricFinish
        {
            get;
            set;
        }
        public int IsDefaultFabric
        {
            get;
            set;
        }
        public int Shrinkage
        {
            get;
            set;
        }
        public int Wastage
        {
            get;
            set;
        }
        public int QuantityToOrder
        {
            get;
            set;
        }
        public string SupplierName
        {
            get;
            set;
        }
        public int MinimumRate
        {
            get;
            set;
        }
        public int MinimumLeadTime
        {
            get;
            set;
        }
        public double QuotedLandedRate
        {
            get;
            set;
        }
        public double IdealRate
        {
            get;
            set;
        }
        public int QuotedLeadTime
        {
            get;
            set;
        }
        public int BalanceQty
        {
            get;
            set;
        }
        public string SupplierNameWithRate
        {
            get;
            set;
        }
        public int SupplierPoId
        {
            get;
            set;
        }
        public string PoNumber
        {
            get;
            set;
        }
        public double FinalRate
        {
            get;
            set;
        }
        public DateTime PoDate
        {
            get;
            set;
        }
        public DateTime PoEta
        {
            get;
            set;
        }
        public int ReceivedQty
        {
            get;
            set;
        }
        public int SendQty
        {
            get;
            set;
        }
        public int GarmentUnit
        {
            get;
            set;
        }
        public DateTime PoRaisedDate
        {
            get;
            set;
        }
        public string GarmentUnitName
        {
            get;
            set;
        }
        public Boolean IsPartySignature
        {
            get;
            set;
        }
        public Boolean IsAuthorizedSignatory
        {
            get;
            set;
        }
        public string UploadSignature
        {
            get;
            set;
        }
        public DateTime CommitedStartDate
        {
            get;
            set;
        }
        public int TotalQtyRecieved
        {
            get;
            set;
        }
        public int Status
        {
            get;
            set;
        }
        public string FabricType
        {
            get;
            set;
        }
        public int SupplyType
        {
            get;
            set;
        }
        public string BIPLAddress
        {
            get;
            set;
        }
        public int SrvCount
        {
            get;
            set;
        }
        public List<FabricEtaRange> FabricEtaRangeDetail
        {
            get;
            set;
        }
        public List<FabricSRV> FabricSRVlist
        {
            get;
            set;
        }
        public List<FabricDebitNoteCls> FabricDebitNoteClsList
        {
            get;
            set;
        }


    }
    public class FabricEtaRange
    {
        public int SupplierPoEtaId
        {
            get;
            set;
        }
        public int FromQty
        {
            get;
            set;
        }
        public int ToQty
        {
            get;
            set;
        }
        public DateTime POETADate
        {
            get;
            set;
        }
    }

    public class FabricSRV : FabricPending
    {
        public int SRV_Id
        {
            get;
            set;
        }
        public DateTime SRVDate
        {
            get;
            set;
        }
        public string PartyChallanNumber
        {
            get;
            set;
        }
        public int ReceivedUnit
        {
            get;
            set;
        }
        public int GateNo
        {
            get;
            set;
        }
        public string srvRemark
        {
            get;
            set;
        }
        public int PartyBillId
        {
            get;
            set;
        }
        public string PartyBillNumber
        {
            get;
            set;
        }
        public DateTime PartyBillDate
        {
            get;
            set;
        }
        public int Amount
        {
            get;
            set;
        }
        public int Receiving_Voucher_No
        {
            get;
            set;
        }
        public string ReceivedUnitName
        {
            get;
            set;
        }

        public List<Fabric_Srv_Bill> Fabric_Srv_BillList
        {
            get;
            set;
        }

    }

    public class FabricDebitNoteCls : FabricPending
    {
        public int DebitNoteId
        {
            get;
            set;
        }

        public int GST
        {
            get;
            set;
        }
        public int Debptid
        {
            get;
            set;
        }
        //new lines
        public string GSTNo
        {
            get;
            set;
        }
        public string Address
        {
            get;
            set;
        }
        public string DebitNoteNumber
        {
            get;
            set;
        }
        public DateTime DebitNoteDate
        {
            get;
            set;
        }
        public string ReturnChallanNumber
        {
            get;
            set;
        }
        public DateTime ChallanDate
        {
            get;
            set;
        }
        public int PartyBillId
        {
            get;
            set;
        }
        public double IGST
        {
            get;
            set;
        }
        public double CGST
        {
            get;
            set;
        }
        public double SGST
        {
            get;
            set;
        }
        public double TotalAmount
        {
            get;
            set;
        }
        public string PartyBillNumber
        {
            get;
            set;
        }
        public DateTime PartyBillDate
        {
            get;
            set;
        }
        public double Amount
        {
            get;
            set;
        }
        public int QtyCheckedBy
        {
            get;
            set;
        }
        public DateTime QtyCheckedDate 
        {
            get;
            set;
        }
        public decimal ConversionValue
        {
            get;
            set;
        }
        public int ConvertToUnit
        {
            get;
            set;
        }
        public int defualtunit
        {
            get;
            set;
        }
        public int FourPointFailQty
        {
            get;
            set;
        }
        
        public List<FabricDebitNoteParticulars> FabricDebitNoteParticularsList
        {
            get;
            set;
        }
        public List<Fabric_Srv_Bill> Fabric_Srv_BillList
        {
            get;
            set;
        }

        public string QualityName
        {
            get;
            set;
        }
        public string QualityDetails
        {
            get;
            set;
        }      
    }
    public class FabricDebitNoteParticulars : FabricDebitNoteCls
    {
        public int DebitNoteParticularId
        {
            get;
            set;
        }
        public string ParticularName
        {
            get;
            set;
        }
        public int DebitQuantity
        {
            get;
            set;
        }
        public double DebitRate
        {
            get;
            set;
        }
        public int ParticularAmount
        {
            get;
            set;
        }
        public int IsExtraQty
        {
            get;
            set;
        }
        public int Fab_DebitNote_SRVID
        {
            get;
            set;
        }
        public string SRVID
        {
            get;
            set;
        }
   

    }
    public class Fabric_Srv_Bill : FabricSRV
    {
        public string BillDetails
        {
            get;
            set;
        }
        public bool IsChecked
        {
            get;
            set;
        }
        public int srvdebitamount
        {
            get;
            set;
        }
        public int SupplierID 
        {
            get;
            set;
        }
        public int Sequence
        {
            get;
            set;
        }
        public bool isPartyBillOlderThan3Months
        {
            get;
            set;
        }
    }
    public class Un_RagisterFabric 
    {
        public string TradeName
        {
            get;
            set;
        }
        public string Gsm
        {
            get;
            set;
        }
        public string CountConstruction
        {
            get;
            set;
        }
        public decimal CostWidth
        {
            get;
            set;
        }
        public decimal FinishRate
        {
            get;
            set;
        }
        public string Flag
        {
            get;
            set;
        }
    }

}
