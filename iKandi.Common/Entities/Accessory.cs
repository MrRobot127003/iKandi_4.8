using System;
using System.Collections.Generic;
namespace iKandi.Common
{
    public class AccessoryWorkingDetail
    {
        public Int32 Id
        {
            get;
            set;
        }
        public Int32 AccessoryWorkingID
        {
            get;
            set;
        }
        public String AccessoryName
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
    public class AccessoryInHouseHistory
    {
        public String AccessoryName
        {
            get;
            set;
        }
        public Int32 OrderDetailID
        {
            get;
            set;
        }
        public Int32 AccessoryWorkingDetailID
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
    public class AccessoryWorking
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
        public List<AccessoryWorkingDetail> AccessoryWorkingDetailCount
        {
            get;
            set;
        }
        public Int32 ApprovedByAccessoryManager
        {
            get;
            set;
        }
        public DateTime ApprovedByAccessoryManagerOn
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
        public List<AccessoryWorkingDetail> AccessoryWorkingDetail
        {
            get;
            set;
        }
        public List<AccessoryInHouseHistory> AccessoryHistory
        {
            get;
            set;
        }
        public string History
        {
            get;
            set;
        }
        public List<AccessoryPending> AccessoryPendingList
        {
            get;
            set;
        }
    }
    public class Accessory
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
    public class AccessoryPending
    {
        public int leadday
        {
            get;
            set;
        }
        public int leadrange
        {
            get;
            set;
        }
        public int OrderId
        {
            get;
            set;
        }
        public bool IsQuoted
        {
            get;
            set;
        }
        public int AccessoryWorkingDetailId
        {
            get;
            set;
        }
        public int AccessoryMasterId
        {
            get;
            set;
        }
        public string AccessoryName
        {
            get;
            set;
        }
        public int AccessoryQualitySizeId
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
        public double AccessoryAvg
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
        public double AccessoryQty
        {
            get;
            set;
        }
        public DateTime OrderDate
        {
            get;
            set;
        }
        public bool IsAccessoryFinish
        {
            get;
            set;
        }
        public int IsDefaultAccessory
        {
            get;
            set;
        }
        public double Shrinkage
        {
            get;
            set;
        }
        public double Wastage
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
        public string SupplierGstNo
        {
            get;
            set;
        }
        public string SupplierAddress
        {
            get;
            set;
        }
        public string SupplierEmail
        {
            get;
            set;
        }
        public double MinimumRate
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
        public DateTime QuotedDate
        {
            get;
            set;
        }
        // Updated By RSB
        public decimal BalanceQty
        {
            get;
            set;
        }
        public int Stage1ReverseQty
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
        public double ReceivedQty
        {
            get;
            set;
        }
        public decimal SendQty
        {
            get;
            set;
        }
        public int GarmentUnit
        {
            get;
            set;
        }
        public double Acc_Wastage
        {
            get;
            set;
        }
        public DateTime PoRaisedDate
        {
            get;
            set;
        }
        public int SendChallanId
        {
            get;
            set;
        }
        public string SendChallanNumber
        {
            get;
            set;
        }
        public string GarmentUnitName
        {
            get;
            set;
        }
        public string DefaultGarmentUnitName
        {
            get;
            set;
        }
        public double DefaultRecievedQty
        {
            get;
            set;
        }
        public decimal TotalSendChallanQty
        {
            get;
            set;
        }
        public decimal GreigePassQty
        {
            get;
            set;
        }
        // Change By RSB
        public decimal TotalRecChallanQty
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
        public Boolean IsJuniorSignatory
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
        public decimal TotalQtyRecieved
        {
            get;
            set;
        }
        public int Status
        {
            get;
            set;
        }
        public double SRVQuantity
        {
            get;
            set;
        }
        public int PoQuantity
        {
            get;
            set;
        }
        public int LiabilityQty
        {
            get;
            set;
        }
        public string AccessoryType
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
        public decimal TotalPassQty
        {
            get;
            set;
        }
        public decimal TotalCheckedQty
        {
            get;
            set;
        }
        public decimal TotalFailQty
        {
            get;
            set;
        }
        public decimal TotalHoldQty
        {
            get;
            set;
        }
        public DateTime AuthorizedDate
        {
            get;
            set;
        }
        public string AuthoriseBy
        {
            get;
            set;
        }
        public string AuthSignature
        {
            get;
            set;
        }
        public DateTime ReceivedDate
        {
            get;
            set;
        }
        public string RecievedBy
        {
            get;
            set;
        }
        public string RecievedSignature
        {
            get;
            set;
        }
        public int Stage1SRVReceivedQty
        {
            get;
            set;
        }
        public int Stage2SRVReceivedQty
        {
            get;
            set;
        }
        public DateTime ExFactory
        {
            get;
            set;
        }
        public DateTime IssueCompleteDate
        {
            get;
            set;
        }
        public int IsCompleteIssue
        {
            get;
            set;
        }
        public int New_GarmentUnit
        {
            get;
            set;
        }
        public int New_RecievedQty
        {
            get;
            set;
        }
        public int New_SendQty
        {
            get;
            set;
        }
        public bool UnitChange
        {
            get;
            set;
        }
        public double ConversionValue
        {
            get;
            set;
        }
        public string DetailDescription
        {
            get;
            set;
        }
        public int HistoryExist
        {
            get;
            set;
        }
        public decimal UsableStockQty
        {
            get;
            set;
        }
        public decimal InspectUsableStock
        {
            get;
            set;
        }
        public string AccessoryRemarks
        {
            get;
            set;
        }
        public string ClientCode
        {
            get;
            set;
        }
        public int PartySignatureBy
        {
            get;
            set;
        }
        public int AuthorizedSignatureBy
        {
            get;
            set;
        }
        public int JuniorSignatoryId
        {
            get;
            set;
        }
        public DateTime PartySignatureDate
        {
            get;
            set;
        }
        public DateTime AuthorizedSignatureDate
        {
            get;
            set;
        }
        public DateTime JuniorSignatoryApprovedOn
        {
            get;
            set;
        }
        public List<AccessoryEtaRange> AccessoryEtaRangeDetail
        {
            get;
            set;
        }
        public List<AccessorySRV> AccessorySRVlist
        {
            get;
            set;
        }
        public List<AccessoryDebitNoteCls> AccessoryDebitNoteClsList
        {
            get;
            set;
        }

        public int LeadTime_Drange
        {
            get;
            set;
        }

        public double ActualReceivedQty { get; set; }

        public string HSNCode { get; set; }

        public Boolean IsAccessoryGM { get; set; }
    }
    public class AccessoryEtaRange
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
    public class AccessorySRV : AccessoryPending
    {
        public int SRV_Id
        {
            get;
            set;
        }

        public string IsSigned
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
        public string GateNo
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
        public int InspectionId
        {
            get;
            set;
        }
        public decimal InspectionCheckedQty
        {
            get;
            set;
        }
        public decimal PassQty
        {
            get;
            set;
        }
        public decimal FailQty
        {
            get;
            set;
        }
        public decimal HoldQty
        {
            get;
            set;
        }
        public bool IsFourPointCheckedByGM
        {
            get;
            set;
        }
        public decimal InspectionRaisedDebit
        {
            get;
            set;
        }
        public decimal InspectionUsableStock
        {
            get;
            set;
        }
        public int StoreInchargeId
        {
            get;
            set;
        }
        public int QtyCheckedBy
        {
            get;
            set;
        }
        public DateTime StoreInchargeCheckedDate
        {
            get;
            set;
        }
        public DateTime QtyCheckedDate
        {
            get;
            set;
        }
        public List<Accessory_Srv_Bill> Accessory_Srv_BillList
        {
            get;
            set;
        }
    }
    public class Accessory_Srv_Bill : AccessorySRV
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
    }
    public class AccessoryDebitNoteCls : AccessoryPending
    {
        public int DebitNoteId
        {
            get;
            set;
        }
        public string GSTNo
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
        public int ReturnChallanId
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
        public bool IsDebitNoteSigned
        {
            get;
            set;
        }
        public DateTime DebitNoteSignDate
        {
            get;
            set;
        }
        public string DebitNoteSignedBy
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
        public string AccQualityName
        {
            get;
            set;
        }
        public string AccColor_Print
        {
            get;
            set;
        }
        public List<AccessoryDebitNoteParticulars> AccessoryDebitNoteParticularsList
        {
            get;
            set;
        }
        public List<Accessory_Srv_Bill> Accessory_Srv_BillList
        {
            get;
            set;
        }
        //rajeevS
        public string HSNCode { get; set; }
        //RajeevS
    }
    public class AccessoryDebitNoteParticulars : AccessoryDebitNoteCls
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
        public double DebitQuantity
        {
            get;
            set;
        }
        public double DebitRate
        {
            get;
            set;
        }
        public double ParticularAmount
        {
            get;
            set;
        }
        public int IsExtraQty
        {
            get;
            set;
        }
        public int Acc_DebitNote_SRVID
        {
            get;
            set;
        }
        public string SrvNo
        {
            get;
            set;
        }
    }


    //create by Girish on 2022-12-20 to Save Internal Challan start
    public class SaveAccessoryInternalChallan
    {       
        public string ChallanNumber
        {
            get;
            set;
        }
        public DateTime ChallanDate
        {
            get;
            set;
        }

        public int ProductionUnitId
        {
            get;
            set;
        }
        public Boolean IsPartySignature
        {
            get;
            set;
        }

        public DateTime ReceivedDate
        {
            get;
            set;
        }
        public Boolean IsAuthorizedSignatory
        {
            get;
            set;
        }
        public DateTime AuthorizedDate
        {
            get;
            set;
        }
        public string ProcessIds
        {
            get;
            set;
        }
        public string GSTNo
        {
            get;
            set;
        }

        public List<AccessoryInternalChallanGridData> GridData
        {
            get;
            set;
        }        

    }
    //create by Girish on 2022-12-20 to Save Internal Challan End

    public class AccessoryInternalChallanGridData
    {
        public int AccessoryMasterId
        {
            get;
            set;
        }
        public string Size
        {
            get;
            set;
        }
        public string ColorPrint
        {
            get;
            set;
        }
        public int OrderDetailId
        {
            get;
            set;
        }
        public int NoOfItems
        {
            get;
            set;
        }

        public decimal QtyToIssue
        {
            get;
            set;
        }
        public decimal ReturnedQty
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

    //create by Girish on 2022-12-20 to Save Internal Challan End


    public class AccessoryChallanCls : AccessoryDebitNoteCls
    {
        public Decimal Rate
        {
            get;
            set;
        }
        public int ChallanId
        {
            get;
            set;
        }
        public string ChallanNumber
        {
            get;
            set;
        }
        public int ChallanType
        {
            get;
            set;
        }
        public int ProductionUnitId
        {
            get;
            set;
        }
        public string ChallanDesc
        {
            get;
            set;
        }
        public int AccessoryUnitId
        {
            get;
            set;
        }
        public decimal Remaining_SendQty
        {
            get;
            set;
        }
        public decimal Default_Remaining_SendQty
        {
            get;
            set;
        }
        public decimal SendChallanQty
        {
            get;
            set;
        }
        public decimal Default_SendChallanQty
        {
            get;
            set;
        }
        // Updated by RSB
        public decimal TotalPcs
        {
            get;
            set;
        }
        public bool IsChallanRecieved
        {
            get;
            set;
        }
        public int UnitCount
        {
            get;
            set;
        }
        public List<AccessoryChallanBreakDown> ChallanBreakDownList
        {
            get;
            set;
        }

        public List<AccessoryGstRateTotalAmount> AccessoryGstRateTotalAmount
        {
            get;
            set;
        }


        public List<ChallanProcess> ChallanProcessList
        {
            get;
            set;
        }
        public List<GroupUnit> GroupUnitList
        {
            get;
            set;
        }
        public decimal GST
        {
            get;
            set;
        }
        //rajeevS 13022023
        public string HSNCode { get; set; }
        //rajeevS 12022023
        public bool IsRecieved
        {
            get;
            set;
        }
        public bool IsAuthorized
        {
            get;
            set;
        }


    }


    public class AccessoryGstRateTotalAmount
    {


        public decimal Rate
        {
            get;
            set;
        }


        public decimal TotalAmount
        {
            get;
            set;
        }


        public int Gst
        {
            get;
            set;
        }


        public string GSTno
        {
            get;
            set;
        }


    }
    public class AccessoryChallanBreakDown : AccessoryChallanCls
    {
        public int Challan_BreakDown_Id
        {

            get;
            set;
        }

        public int GroupUnitId
        {
            get;
            set;
        }
        public string GroupUnitName
        {
            get;
            set;
        }
        public int Pcs
        {
            get;
            set;
        }
        public int RowNo
        {
            get;
            set;
        }
    }
    public class ChallanProcess
    {
        public int ChallanProcessId
        {
            get;
            set;
        }
        public string ProcessName
        {
            get;
            set;
        }
        public bool IsChecked
        {
            get;
            set;
        }
    }
    public class GroupUnit
    {
        public int GroupUnitID
        {
            get;
            set;
        }
        public string UnitName
        {
            get;
            set;
        }
    }
    public class AccessoryCreditNoteCls : AccessoryPending
    {
        public int CreditNoteId
        {
            get;
            set;
        }
        public string GSTNo
        {
            get;
            set;
        }
        public string CreditNoteNumber
        {
            get;
            set;
        }
        public DateTime CreditNoteDate
        {
            get;
            set;
        }
        public int DebitNoteId
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
        public bool IsCreditNoteSigned
        {
            get;
            set;
        }
        public DateTime CreditNoteSignDate
        {
            get;
            set;
        }
        public string CreditNoteSignedBy
        {
            get;
            set;
        }
        public List<AccessoryCreditNoteParticulars> AccessoryCreditNoteParticularsList
        {
            get;
            set;
        }
        //rajeevs
        public string HSNCode { get; set; }
        //rajeevs
    }
    public class AccessoryCreditNoteParticulars : AccessoryCreditNoteCls
    {
        public int CreditNoteParticularId
        {
            get;
            set;
        }
        public string ParticularName
        {
            get;
            set;
        }
        public double CreditQuantity
        {
            get;
            set;
        }
        public double CreditRate
        {
            get;
            set;
        }
        public double ParticularAmount
        {
            get;
            set;
        }
    }
    public class AccessoriesInspect
    {
        public int InspectionParticular_Id
        {
            get;
            set;
        }
        public int Inspection_Id
        {
            get;
            set;
        }
        public int BoxNo
        {
            get;
            set;
        }
        public decimal DieLot
        {
            get;
            set;
        }
        public decimal ClaimedLength
        {
            get;
            set;
        }
        public decimal ActLength
        {
            get;
            set;
        }
        public decimal PassQty
        {
            get;
            set;
        }
        public decimal CheckedQty
        {
            get;
            set;
        }
        public decimal FailQty
        {
            get;
            set;
        }
        public decimal HoldQty
        {
            get;
            set;
        }
        public string Decision
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public int StockQty
        {
            get;
            set;
        }
    }
    public class AccessoriesInspectSystem
    {
        public int Inspection_Id
        {
            get;
            set;
        }
        public int SupplierPO_Id
        {
            get;
            set;
        }
        public int SRV_Id
        {
            get;
            set;
        }
        public string CheckerName1
        {
            get;
            set;
        }
        public string CheckerName2
        {
            get;
            set;
        }
        public DateTime InspectionDate
        {
            get;
            set;
        }
        public decimal TotalQty
        {
            get;
            set;
        }
        public int UnitId
        {
            get;
            set;
        }
        public decimal RecievedQty
        {
            get;
            set;
        }
        public decimal ClaimedQty
        {
            get;
            set;
        }
        public decimal CheckedQty
        {
            get;
            set;
        }
        public decimal PassQty
        {
            get;
            set;
        }
        public decimal HoldQty
        {
            get;
            set;
        }
        public decimal FailQty
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public string Comments
        {
            get;
            set;
        }
        public bool IsAccessoryQA
        {
            get;
            set;
        }
        public bool IsAccessoryGM
        {
            get;
            set;
        }
        public int InternalLabSpeciman
        {
            get;
            set;
        }
        public int ExternalLabSpeciman
        {
            get;
            set;
        }
        public bool InternalSentToLab
        {
            get;
            set;
        }
        public bool ExternalSentToLab
        {
            get;
            set;
        }
        public bool InternalReceivedInLab
        {
            get;
            set;
        }
        public bool ExternalReceivedInLab
        {
            get;
            set;
        }
        public DateTime InternalSentToLabDate
        {
            get;
            set;
        }
        public DateTime ExternalSentToLabDate
        {
            get;
            set;
        }
        public DateTime InternalReceivedInLabDate
        {
            get;
            set;
        }
        public DateTime ExternalReceivedInLabDate
        {
            get;
            set;
        }
        public string InternalLabReport
        {
            get;
            set;
        }
        public string ExternalLabReport
        {
            get;
            set;
        }
        public int FinalDecision
        {
            get;
            set;
        }
        public DateTime FinalDecisionDate
        {
            get;
            set;
        }
        public decimal TotalExternalQty
        {
            get;
            set;
        }
        public decimal FailedRaisedDebit
        {
            get;
            set;
        }
        public decimal FailedStock
        {
            get;
            set;
        }
        public decimal FailedGoodStock
        {
            get;
            set;
        }
        public string FailedParticular
        {
            get;
            set;
        }
        public decimal InspectRaisedDebit
        {
            get;
            set;
        }
        public decimal InspectUsableStock
        {
            get;
            set;
        }
        public string InspectParticular
        {
            get;
            set;
        }
        public bool IsLabManager
        {
            get;
            set;
        }
        public DateTime LabManagerApprovedDate
        {
            get;
            set;
        }
        public DateTime QAManagerApprovedDate
        {
            get;
            set;
        }
        public DateTime GMManagerApprovedDate
        {
            get;
            set;
        }
        public int AccessoryQABy
        {
            get;
            set;
        }
        public int AccessoryGMBy
        {
            get;
            set;
        }
        public int LabManagerBy
        {
            get;
            set;
        }
        public int IsCommercialpass
        {
            get;
            set;
        }
        public int InternalLabDec
        {
            get;
            set;
        }
        public int ExternalLabDec
        {
            get;
            set;
        }
    }
    public class AccessoryQualityIssuing : AccessoryPending
    {
        public Boolean CanMakeNewChallan
        {
            get;
            set;
        }
        public decimal ReturnedQty
        {
            get;
            set;
        }
        public int IssueSheetId
        {
            get;
            set;
        }
        public DateTime IssueRequestDate
        {
            get;
            set;
        }
        public int IsIssueRequest
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public decimal totalRequired
        {
            get;
            set;
        }
        public string TradName
        {
            get;
            set;
        }
        public decimal AvailableQtyToIssued
        {
            get;
            set;
        }
        public decimal LeftQuantity
        {
            get;
            set;
        }
        public decimal RequiredQty
        {
            get;
            set;
        }
        public int ChallanId
        {
            get;
            set;
        }
        public string ChallanNumber
        {
            get;
            set;
        }
        public decimal ChallanQty
        {
            get;
            set;
        }
        public string ChallanDateWithFormat
        {
            get;
            set;
        }
        public decimal StockQty
        {
            get;
            set;
        }
        public decimal DebitQty
        {
            get;
            set;
        }
        public string DebitParticulars
        {
            get;
            set;
        }
        public int Unitid
        {
            get;
            set;
        }
    }
}