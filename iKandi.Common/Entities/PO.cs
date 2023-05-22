using System;
using System.Collections.Generic;

namespace iKandi.Common
{
    //created by manisha on 20 Dec 2011
    [Serializable]
    public class MasterPO : BaseEntity
    {
        public int MasterPOID
        {
            get;
            set;
        }

        public string MasterPONumber
        {
            get;
            set;
        }

        public POFabExt Fabric
        {
            get;
            set;
        }
        public string Print
        {
            get;
            set;
        }

        public string PrintName
        {
            get;
            set;
        }

        public string HandFeel
        {
            get;
            set;
        }

        public Client Client
        {
            get;
            set;
        }

        public int IsWashingReq
        {
            get;
            set;
        }

        public int IsActive
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }
        public DateTime MasterPODate
        {
            get;
            set;
        }

        public List<PO> AssociatedPO
        {
            get;
            set;
        }

        public List<POProcess> AssociatedProcess
        {
            get;
            set;
        }

        public List<OrderDetail> AssociatedContracts
        {
            get;
            set;
        }
        public int OrderType
        {
            get;
            set;
        }
        public int POType
        {
            get;
            set;
        }

    }

    [Serializable]
    public class PO : BaseEntity
    {
        public MasterPO MasterPO
        {
            get;
            set;
        }

        public int POID
        {
            get;
            set;
        }

        public string PONumber
        {
            get;
            set;
        }

        public string POType
        {
            get;
            set;
        }

        public POProcess Process
        {
            get;
            set;
        }
        public string POCategory
        {
            get;
            set;
        }
        public double QTY
        {
            get;
            set;
        }
        public double Rate
        {
            get;
            set;
        }
        public string Unit
        {
            get;
            set;
        }
        public double RecievedQty
        {
            get;
            set;
        }
        public double RejectedQty
        {
            get;
            set;
        }
        public double Shrinkage
        {
            get;
            set;
        }
        public Supplier Supplier
        {
            get;
            set;
        }
        public string PORefNo
        {
            get;
            set;
        }
        public int IsActive
        {
            get;
            set;
        }
        public int IsDeleted
        {
            get;
            set;
        }

        public int RelatedPOID
        {
            get;
            set;
        }

        public DateTime PODate
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int SpecificationID
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;
        }
        public string IsStock
        {
            get;
            set;
        }
        public DateTime DeliveryDate
        {
            get;
            set;
        }
        public int CurrencyUnit
        {
            get;
            set;
        }
        public int StockID
        {
            get;
            set;
        }
        public int IsApproved
        {
            get;
            set;
        }
        public int ApprovedBy
        {
            get;
            set;
        }
    }

    [Serializable]
    public class POProcess : BaseEntity
    {
        public int ProcessID
        {
            get;
            set;
        }

        public string ProcessName
        {
            get;
            set;
        }
        public int IsValid
        {
            get;
            set;
        }
    }

    [Serializable]
    public class Po_Type : EntityBasetable
    {
        public string PoType
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }

    public class POFabExt : FabricQuality
    {
        public double StockInHouse
        {
            get;
            set;
        }

        public double StockBooked
        {
            get;
            set;
        }

    }

    [Serializable]
    public class ReprocessPO : PO
    {
        public double QtyReturn
        {
            get;
            set;
        }

        public double QtyDebt
        {
            get;
            set;
        }
        public double QtyNewPO
        {
            get;
            set;
        }
        public double RateDebt
        {
            get;
            set;
        }
        public int IsReuasble
        {
            get;
            set;
        }
        public int IsMovetoInventory
        {
            get;
            set;
        }
        public int BasePOID
        {
            get;
            set;
        }
        public int ReType
        {
            get;
            set;
        }
    }

    [Serializable]
    public class CurrencyMaster : EntityBasetable
    {
        public string CurrencyType
        {
            get;
            set;
        }

        public string CurrencySymbol
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ListCM : List<CurrencyMaster>
    {

    }

    [Serializable]
    public class SInventoryDetail : EntityBasetable
    {
        public string Type
        {
            get;
            set;
        }

        public string ItemName
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public double Qty
        {
            get;
            set;
        }

        public int Unit
        {
            get;
            set;
        }

        public double Rate
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }

        public int ClientId
        {
            get;
            set;
        }

        public int CurrencyUnit
        {
            get;
            set;
        }

        public string SupplierName
        {
            get;
            set;
        }

        public int TaskId
        {
            get;
            set;
        }

        public int SupplierId
        {
            get;
            set;
        }

        public int PoType
        {
            get;
            set;
        }

        public DateTime DeliveryDate
        {
            get;
            set;
        }
    }

    [Serializable]
    public class ListSID : List<SInventoryDetail>
    {

    }

    [Serializable]
    public class SamplingInventory : ListSID
    {
        public string SupplierName
        {
            get;
            set;
        }

        public DateTime PoDate
        {
            get;
            set;
        }

        public DateTime DeliveryDate
        {
            get;
            set;
        }
    }

    [Serializable]
    public class User_Task : EntityBasetable
    {
        public string Url
        {
            get;
            set;
        }

        public string Param
        {
            get;
            set;
        }

        public string Desc
        {
            get;
            set;
        }

        public int IsDone
        {
            get;
            set;
        }

        public int TaskId
        {
            get;
            set;
        }

        public int PoId
        {
            get;
            set;
        }

        public int SrvId
        {
            get;
            set;
        }

        public int SupplierId
        {
            get;
            set;
        }

        public int PoTypeId
        {
            get;
            set;
        }

        public string SupRtnSource
        {
            get;
            set;
        }

        public string IsReProcessing
        {
            get;
            set;
        }

        public DateTime BulkInHouse
        {
            get;
            set;
        }

        public int FpId
        {
            get;
            set;
        }

        public int ChallanId
        {
            get;
            set;
        }
    }

    [Serializable]
    public class PO_Valueaddition
    {
        public int SupplierId
        {
            get;
            set;
        }
        public string SupplierName
        {
            get;
            set;
        }
 
        public string PoNumber
        {
            get;
            set;
        }

        public DateTime DateofIssue
        {
            get;
            set;
        }

        public String SerialNo
        {
            get;
            set;
        }
        public String StyleNo_SerialNo
        {
            get;
            set;
        }
        public string StyleNo
        {
            get;
            set;
        }

        public string SAM
        {
            get;
            set;
        }

        public int AgreedQty
        {
            get;
            set;
        }

        public decimal AgreedRate
        {
            get;
            set;
        }

        public DateTime DeliveryStartDate
        {
            get;
            set;
        }
        public DateTime DeliveryEndDate
        {
            get;
            set;
        }
        public DateTime UserStartDate
        {
            get;
            set;
        }
        public DateTime UserEndDate
        {
            get;
            set;
        }
        public DateTime ActualEndDate
        {
            get;
            set;
        }
        public Decimal DebitforLateDelivery
        {
            get;
            set;
        }
        public decimal DebitforAltration
        {
            get;
            set;
        }
        public int RiskVASupplierid
        {
            get;
            set;
        }
        public Boolean VendorSignature
        {
            get;
            set;
        }
        public Boolean BIPLMngtSignature
        {
            get;
            set;
        }
        public Boolean GMPlanningSignature
        {
            get;
            set;
        }
        public DateTime VendorSignatureDate
        {
            get;
            set;
        }
        public DateTime BIPLMngtSignatureDate
        {
            get;
            set;
        }
        public DateTime GMPlanningSignatureDate
        {
            get;
            set;
        }
        public string job
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }
        public string GMPlanningID
        {
            get;
            set;
        }
        public string Unit { get; set; }

        public int UserId { get; set; }

        public string RateHistory { get; set; }
 
    }


    [Serializable]
    public class PO_StitchCutHouse
    {
        public int StitchSupplierId
        {
            get;
            set;
        }
        public string StitchSupplierName
        {
            get;
            set;
        }

        public string StitchPoNumber
        {
            get;
            set;
        }

        public DateTime StitchDateofIssue
        {
            get;
            set;
        }

        public String StitchSerialNo
        {
            get;
            set;
        }
        public String StitchStyleNo_SerialNo
        {
            get;
            set;
        }
        public string StitchStyleNo
        {
            get;
            set;
        }

        public string StitchSAM
        {
            get;
            set;
        }

        public string FinishSAM
        {
            get;
            set;
        }

        public int StitchAgreedQty
        {
            get;
            set;
        }

        public decimal StitchAgreedRate
        {
            get;
            set;
        }

        public decimal FinishAgreedRate
        {
            get;
            set;
        }

        public DateTime StitchDeliveryStartDate
        {
            get;
            set;
        }
        public DateTime StitchDeliveryEndDate
        {
            get;
            set;
        }
        public DateTime StitchActualEndDate
        {
            get;
            set;
        }
        public Decimal StitchDebitforLateDelivery
        {
            get;
            set;
        }
        public decimal StitchDebitforAltration
        {
            get;
            set;
        }
        public int StitchOrderDetailId
        {
            get;
            set;
        }
        public int StitchLocationType
        {
            get;
            set;
        }
        public Boolean StitchSignature
        {
            get;
            set;
        }
        public Boolean StitchBIPLMngtSignature
        {
            get;
            set;
        }
        public Boolean StitchGMPlanningSignature
        {
            get;
            set;
        }
        public DateTime StitchSignatureDate
        {
            get;
            set;
        }
        public DateTime StitchBIPLMngtSignatureDate
        {
            get;
            set;
        }
        public DateTime StitchGMPlanningSignatureDate
        {
            get;
            set;
        }
        public string Stitchjob
        {
            get;
            set;
        }
        public string StitchRemarks
        {
            get;
            set;
        }
        public string StitchUnit { get; set; }

        public int StitchUserId { get; set; }

    }
   
}
