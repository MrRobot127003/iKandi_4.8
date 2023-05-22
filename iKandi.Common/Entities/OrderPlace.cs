using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    // Created By Ravi kumar on 19-dec-2018
    public class OrderPlace : BaseEntity
    {
        public Style Style
        {
            get;
            set;
        }
        public Costing Costing
        {
            get;
            set;
        }
        public Print Print
        {
            get;
            set;
        }
        public int OrderID
        {
            get;
            set;
        }
        public int StyleID
        {
            get;
            set;
        }
        public int ClientID
        {
            get;
            set;
        }
        public DateTime OrderDate
        {
            get;
            set;
        }
        public string SerialNumber
        {
            get;
            set;
        }
        public int OrderTypes
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public int DepartmentID
        {
            get;
            set;
        }
        public int ParentDepartmentID
        {
            get;
            set;
        }
        public string DepartmentName
        {
            get;
            set;
        }
        public string ParentDepartmentName
        {
            get;
            set;
        }
        public string CompanyName
        {
            get;
            set;
        }
        public string Comments
        {
            get;
            set;
        }
        public int ApprovedBySalesIkandi
        {
            get;
            set;
        }
        public int ApprovedByMerchandiserManager
        {
            get;
            set;
        }
        public DateTime ApprovedBySalesBIPLOn
        {
            get;
            set;
        }
        public DateTime ApprovedByMerchandiserManagerOn
        {
            get;
            set;
        }
        public int ApprovedBySalesBIPL
        {
            get;
            set;
        }
        public string NewSerialNumber
        {
            get;
            set;
        }
        public string AccountManagerName
        {
            get;
            set;
        }
        public int AccountManagerID
        {
            get;
            set;
        }
        public double TotalQuantity
        {
            get;
            set;
        }
        public int StatusModeSequence
        {
            get;
            set;
        }
        public bool IsRepeat
        {
            get;
            set;
        }
        public string History
        {
            get;
            set;
        }
        public int IsApproved
        {
            get;
            set;
        }
        public string OrderType
        {
            get;
            set;
        }
        public int BuyingHouseID
        {
            get;
            set;
        }
        public int IsBiplAgreement
        {
            get;
            set;
        }
        public double TotalOrderPrice
        {
            get;
            set;
        }
        public string BaseStyle
        {
            get;
            set;
        }
        public bool IsIkandiUser
        {
            get;
            set;
        }
        public bool IsIkandiClient
        {
            get;
            set;
        }
        public int OrderDetailId
        {
            get;
            set;
        }
        public Int16 SendProposal
        {
            get;
            set;
        }
        public Int16 AcceptProposal
        {
            get;
            set;
        }
        public int DepartmentID_d
        {
            get;
            set;
        }
        public int ParrentDepartmentID_d
        {
            get;
            set;
        }
        public string Description_d
        {
            get;
            set;
        }
        public int OrderType_d
        {
            get;
            set;
        }
        public int AgreementId
        {
            get;
            set;
        }
        public string DepartmentName_d
        {
            get;
            set;
        }
        public string ParentDepartmentName_d
        {
            get;
            set;
        }
        public int OldStyleId
        {
            get;
            set;
        }
        public DateTime ApprovedByFabricManagerOn
        {
            get;
            set;
        }
        public int ApprovedByFabricManager
        {
            get;
            set;
        }
        public DateTime ApprovedByAccessoryManagerOn
        {
            get;
            set;
        }

        public int ApprovedByAccessoryManager
        {
            get;
            set;
        }
        public int StyleExist
        {
            get;
            set;
        }
        public double ConversionRate
        {
            get;
            set;
        }
        public int ModeId
        {
            get;
            set;
        }
        public string ModeCode
        {
            get;
            set;
        }
        public bool EnableMode
        {
            get;
            set;
        }
        public int SplittedOrderDetailId
        {
            get;
            set;
        }
        public bool IsFabricAvgDone
        {
            get;
            set;
        }
        public bool IsAccessoriesAvgDone
        {
            get;
            set;
        }
        public bool IsOrderHistoryCreated
        {
            get;
            set;
        }
        public string FieldName
        {
            get;
            set;
        }
        public int TypeFlag
        {
            get;
            set;
        }
        public string ParentDept_OldValue
        {
            get;
            set;
        }
        public string ParentDept_NewValue
        {
            get;
            set;
        }
        public bool IsParentDept_Change
        {
            get;
            set;
        }
        public int ParentDept_OldId
        {
            get;
            set;
        }
        public int ParentDept_NewId
        {
            get;
            set;
        }
        public string Dept_OldValue
        {
            get;
            set;
        }
        public string Dept_NewValue
        {
            get;
            set;
        }
        public bool IsDept_Change
        {
            get;
            set;
        }
        public string Description_OldValue
        {
            get;
            set;
        }
        public string Description_NewValue
        {
            get;
            set;
        }
        public bool IsDescription_Change
        {
            get;
            set;
        }
        public string OrderType_OldValue
        {
            get;
            set;
        }
        public string OrderType_NewValue
        {
            get;
            set;
        }
        public bool IsOrderType_Change
        {
            get;
            set;
        }
        public int SplittedContractCount
        {
            get;
            set;
        }
        public int SplitedQuantityTotal
        {
            get;
            set;
        }
        public string SplitedQuantityString
        {
            get;
            set;
        }
        public bool IsBiplManagerChecked
        {
            get;
            set;
        }
        public bool IsAccountManagerChecked
        {
            get;
            set;
        }
        public bool IsFabricManagerChecked
        {
            get;
            set;
        }
        public bool IsAccessoryManagerChecked
        {
            get;
            set;
        }
        public int DeliveryType
        {
            get;
            set;
        }
        public List<ContractDetails> ContractDetail
        {
            get;
            set;
        }
        public List<ContractDetailFabric> ContractFabric
        {
            get;
            set;
        }
        public List<ContractDetailAccessories> ContractAccessories
        {
            get;
            set;
        }
        public List<OrderHistory> OrderHistory
        {
            get;
            set;
        }
        public List<OrderComment> OrderComment
        {
            get;
            set;
        }
    }

    public class ContractDetails : BaseEntity
    {
        public int OrderId
        {
            get;
            set;
        }
        public int OrderDetailId
        {
            get;
            set;
        }
        public int OrderDetailId_Ref
        {
            get;
            set;
        }
        public string LineItemNumber
        {
            get;
            set;
        }
        public string ContractNumber
        {
            get;
            set;
        }
        public string PoUpload1
        {
            get;
            set;
        }
        public string PoUpload2
        {
            get;
            set;
        }
        public int Quantity
        {
            get;
            set;
        }
        public double BiplPrice
        {
            get;
            set;
        }
        public double ikandiPrice
        {
            get;
            set;
        }
        public int DeliveryInstruction
        {
            get;
            set;
        }
        public int ModeId
        {
            get;
            set;
        }
        public string ModeCode
        {
            get;
            set;
        }
        public string PackingType
        {
            get;
            set;
        }
        public int OrderPackingType
        {
            get;
            set;
        }
        public int AmberRangeStart
        {
            get;
            set;
        }
        public int AmberRangeEnd
        {
            get;
            set;
        }
        public int GreenRangeStart
        {
            get;
            set;
        }
        public int GreenRangeEnd
        {
            get;
            set;
        }
        public int RedRangeStart
        {
            get;
            set;
        }
        public int RedRangeEnd
        {
            get;
            set;
        }
        public DateTime ExFactory
        {
            get;
            set;
        }
        public DateTime DC
        {
            get;
            set;
        }
        public string ExFactoryColor
        {
            get;
            set;
        }
        public int typeofpacking
        {
            get;
            set;
        }
        public int ExFactoryWeek
        {
            get;
            set;
        }
        public int DCWeek
        {
            get;
            set;
        }
        public string LineItemNumber_d
        {
            get;
            set;
        }
        public string ContractNumber_d
        {
            get;
            set;
        }
        public string PoUpload1_d
        {
            get;
            set;
        }
        public string PoUpload2_d
        {
            get;
            set;
        }
        public int Quantity_d
        {
            get;
            set;
        }
        public double BiplPrice_d
        {
            get;
            set;
        }
        public double ikandiPrice_d
        {
            get;
            set;
        }
        public int DeliveryInstruction_d
        {
            get;
            set;
        }
        public int ModeId_d
        {
            get;
            set;
        }
        public string ModeCode_d
        {
            get;
            set;
        }
        public DateTime ExFactory_d
        {
            get;
            set;
        }
        public DateTime DC_d
        {
            get;
            set;
        }
        public int typeofpacking_d
        {
            get;
            set;
        }
        public int ExFactoryWeek_d
        {
            get;
            set;
        }
        public int DCWeek_d
        {
            get;
            set;
        }
        public int isDeleted
        {
            get;
            set;
        }
        public int SizeOption
        {
            get;
            set;
        }
        public int SizeQty
        {
            get;
            set;
        }
        public int isSplit
        {
            get;
            set;
        }
        public int isSplitted
        {
            get;
            set;
        }
        public Int16 SendProposal
        {
            get;
            set;
        }
        public Int16 AcceptProposal
        {
            get;
            set;
        }
        public int parentOrderDetailID
        {
            get;
            set;
        }
        public int sortType
        {
            get;
            set;
        }
        public int TypeFlag
        {
            get;
            set;
        }
        public bool IsContractHistoryCreated
        {
            get;
            set;
        }
        public string LineNumber_OldValue
        {
            get;
            set;
        }
        public string LineNumber_NewValue
        {
            get;
            set;
        }
        public bool IsLineNumber_Change
        {
            get;
            set;
        }
        public string ContractNumber_OldValue
        {
            get;
            set;
        }
        public string ContractNumber_NewValue
        {
            get;
            set;
        }
        public bool IsContractNumber_Change
        {
            get;
            set;
        }
        public bool IsQuantity_Change
        {
            get;
            set;
        }
        public string Quantity_OldValue
        {
            get;
            set;
        }
        public string Quantity_NewValue
        {
            get;
            set;
        }
        public string Mode_OldValue
        {
            get;
            set;
        }
        public string Mode_NewValue
        {
            get;
            set;
        }
        public bool IsMode_Change
        {
            get;
            set;
        }
        public string ExFactory_OldValue
        {
            get;
            set;
        }
        public string ExFactory_NewValue
        {
            get;
            set;
        }
        public bool IsExFactory_Change
        {
            get;
            set;
        }
        public string DC_OldValue
        {
            get;
            set;
        }
        public string DC_NewValue
        {
            get;
            set;
        }
        public bool IsDC_Change
        {
            get;
            set;
        }
        public string BIPLPrice_OldValue
        {
            get;
            set;
        }
        public string BIPLPrice_NewValue
        {
            get;
            set;
        }
        public bool IsBIPLPrice_Change
        {
            get;
            set;
        }
        public string IkandiPrice_OldValue
        {
            get;
            set;
        }
        public string IkandiPrice_NewValue
        {
            get;
            set;
        }
        public bool IsIkandiPrice_Change
        {
            get;
            set;
        }
        public string DeliveryInstruct_OldValue
        {
            get;
            set;
        }
        public string DeliveryInstruct_NewValue
        {
            get;
            set;
        }
        public bool IsDeliveryInstruct_Change
        {
            get;
            set;
        }
        public string Typeofpacking_OldValue
        {
            get;
            set;
        }
        public string Typeofpacking_NewValue
        {
            get;
            set;
        }
        public bool IsTypeofpacking_Change
        {
            get;
            set;
        }
        public bool IsSplitContractForHistory
        {
            get;
            set;
        }
        public int CountryCodeId
        {
            get;
            set;
        }
        public string CountryCode
        {
            get;
            set;
        }
        public string CountryCode_d
        {
            get;
            set;
        }
        public string CountryCode_OldValue
        {
            get;
            set;
        }
        public string CountryCode_NewValue
        {
            get;
            set;
        }
        public bool IsCountryCodeChange
        {
            get;
            set;
        }
        public int LeadTime
        {
            get;
            set;
        }
        public int LeadTime_d
        {
            get;
            set;
        }

        public List<ContractDetailFabric> ContractFabric
        {
            get;
            set;
        }
        public List<ContractDetailSize> ContractSize
        {
            get;
            set;
        }
        public List<ContractDetailAccessories> ContractAccessories
        {
            get;
            set;
        }
    }
    public class ContractDetailFabric
    {
        public bool CanChangeColorPrint
        {
            get;
            set;
        }
        public int OrderDetailID
        {
            get;
            set;
        }
        public int StyleId
        {
            get;
            set;
        }
        public int FabricId
        {
            get;
            set;
        }
        public string FabricName
        {
            get;
            set;
        }
        public string FabricDetail
        {
            get;
            set;
        }
        public int SeqId
        {
            get;
            set;
        }
        public double GSM
        {
            get;
            set;
        }
        public double DyedRate
        {
            get;
            set;
        }
        public double PrintRate
        {
            get;
            set;
        }
        public string CountConstruct
        {
            get;
            set;
        }
        public int FabTypeId
        {
            get;
            set;
        }
        public string FabType
        {
            get;
            set;
        }
        public int fabric_qualityID
        {
            get;
            set;
        }
        public Int16 SendProposal
        {
            get;
            set;
        }
        public Int16 AcceptProposal
        {
            get;
            set;
        }
        public int FabTypeID_d
        {
            get;
            set;
        }
        public string FabType_d
        {
            get;
            set;
        }
        public string FabricDetail_d
        {
            get;
            set;
        }
        public bool IsFabricHistoryCreated
        {
            get;
            set;
        }
        public string FabricDetail_OldValue
        {
            get;
            set;
        }
        public string FabricDetail_NewValue
        {
            get;
            set;
        }
        public bool IsFabricDetail_Change
        {
            get;
            set;
        }
        public int FabricDetailSeq
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
        public int Stage3
        {
            get;
            set;
        }
        public int Stage4 { get; set; }
    }
    public class ContractDetailAccessories
    {
        public int OrderDetailID
        {
            get;
            set;
        }
        public int StyleId
        {
            get;
            set;
        }
        public int AccessoriesId
        {
            get;
            set;
        }
        public string AccessoriesName
        {
            get;
            set;
        }
        public string Size
        {
            get;
            set;
        }
        public int SizeId
        {
            get;
            set;
        }
        public int SeqId
        {
            get;
            set;
        }
        public string ColorPrint
        {
            get;
            set;
        }
        public bool IsDtm
        {
            get;
            set;
        }
        public string ColorPrint_d
        {
            get;
            set;
        }
        public string IsDtm_d
        {
            get;
            set;
        }
        public Int16 SendProposal
        {
            get;
            set;
        }
        public Int16 AcceptProposal
        {
            get;
            set;
        }
        public Int64 AccId
        {
            get;
            set;
        }
        public bool IsAccessoryHistoryCreated
        {
            get;
            set;
        }
        public string ColorPrint_OldValue
        {
            get;
            set;
        }
        public string ColorPrint_NewValue
        {
            get;
            set;
        }
        public bool IsColorPrint_Change
        {
            get;
            set;
        }
        public string IsDtm_OldValue
        {
            get;
            set;
        }
        public string IsDtm_NewValue
        {
            get;
            set;
        }
        public bool IsDtm_Change
        {
            get;
            set;
        }
        public int AccessSeq
        {
            get;
            set;
        }
        public bool AfterOrderConfirmation
        {
            get;
            set;
        }
        public bool IsAnyAccessoryAdded
        {
            get;
            set;
        }
        public int IsDefaultAccessory
        {
            get;
            set;
        }
        public int IsSrvReceived
        {

            get;
            set;
        }

    }
    public class ContractDetailSize
    {

        public int OrderDetailID
        {
            get;
            set;
        }
        public int OrderDetailSizeID
        {
            get;
            set;
        }

        public int SizeOption
        {
            get;
            set;
        }

        public int isDeleted
        {
            get;
            set;
        }

        public string Size
        {
            get;
            set;
        }
        public double Quantity
        {
            get;
            set;
        }
        public int? RatioPack
        {
            get;
            set;
        }
        public int? Ratio
        {
            get;
            set;
        }
        public int? Singles
        {
            get;
            set;
        }
        public string RatioPackString
        {
            get;
            set;
        }
        public string RatioString
        {
            get;
            set;
        }
        public string SinglesString
        {
            get;
            set;
        }
        public string QuantityString
        {
            get;
            set;
        }
        public int OrderSizeOption
        {
            get;
            set;
        }
        public bool IsSizeHistoryCreated
        {
            get;
            set;
        }
        public int OldSizeOption
        {
            get;
            set;
        }
        public int NewSizeOption
        {
            get;
            set;
        }
        public string OldSize
        {
            get;
            set;
        }
        public string NewSize
        {
            get;
            set;
        }
        public double OldQuantity
        {
            get;
            set;
        }
        public double NewQuantity
        {
            get;
            set;
        }
        public int? OldSingles
        {
            get;
            set;
        }
        public int? NewSingles
        {
            get;
            set;
        }
        public int? OldRatioPack
        {
            get;
            set;
        }
        public int? NewRatioPack
        {
            get;
            set;
        }
        public int? OldRatio
        {
            get;
            set;
        }
        public int? NewRatio
        {
            get;
            set;
        }

    }
    public class OrderHistory
    {
        public int OrderId
        {
            get;
            set;
        }
        public int OrderDetailId
        {
            get;
            set;
        }
        public int TypeFlag
        {
            get;
            set;
        }
        public string FieldName
        {
            get;
            set;
        }
        public string OldValue
        {
            get;
            set;
        }
        public string NewValue
        {
            get;
            set;
        }
        public string DetailDescription
        {
            get;
            set;
        }
    }

    public class OrderOldHistoryComments
    {

        public string History
        {
            get;
            set;
        }
        public string Comments
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

    public class OrderComment
    {
        public string SerialNumber
        {
            get;
            set;
        }
        public int OrderId
        {
            get;
            set;
        }
        public int TypeFlag
        {
            get;
            set;
        }
        public string FieldName
        {
            get;
            set;
        }
        public string Comment
        {
            get;
            set;
        }
        public string DetailDescription
        {
            get;
            set;
        }
    }

    public class ClientCountryCode
    {
        public int CountryId
        {
            get;
            set;
        }
        public string CountryCode
        {
            get;
            set;
        }
    }
}
