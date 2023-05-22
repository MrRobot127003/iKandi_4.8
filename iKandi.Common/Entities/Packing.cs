using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class Packing : BaseEntity
    {
        public int PackingID
        {
            get;
            set;
        }

        public int OrderID
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public double TotalGrossWeight
        {
            get;
            set;
        }

        public double TotalNetWeight
        {
            get;
            set;
        }

        public int TotalPackages
        {
            get;
            set;
        }

        public string PackageNumbers
        {
            get;
            set;
        }

        public string Exporter
        {
            get;
            set;
        }

        public string InvoiceNumber
        {
            get;
            set;
        }

        public int InvoiceID
        {
            get;
            set;
        }


        public string BuyerOrderNumber
        {
            get;
            set;
        }

        public string SerialNumber
        {
            get;
            set;
        }

        public DateTime BuyerOrderDate
        {
            get;
            set;
        }

        public string OtherReferences
        {
            get;
            set;
        }

        public string Consignee
        {
            get;
            set;
        }

        public string BuyerOtherThanConsignee
        {
            get;
            set;
        }

        public string CountryOfOriginOfGoods
        {
            get;
            set;
        }

        public string CountryOfFinalDestination
        {
            get;
            set;
        }

        public string PreCarriageBy
        {
            get;
            set;
        }

        public string PlaceOfReceiptByPreCarrier
        {
            get;
            set;
        }

        public string FlightNumber
        {
            get;
            set;
        }

        public string PortOfLoading
        {
            get;
            set;
        }

        public string PortOfDischarge
        {
            get;
            set;
        }

        public string FinalDestination
        {
            get;
            set;
        }

        public string MarksAndContainerNumber
        {
            get;
            set;
        }

        public string NumberAndKindOfPackages
        {
            get;
            set;
        }

        public string DescriptionOfGoods
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;
        }

        public DateTime InvoiceDate
        {
            get;
            set;
        }

        public string TermsOfDeliveryAndPayment
        {
            get;
            set;
        }

        public List<PackingOrders> PackingOrdersCollection
        {
            get;
            set;
        }

        public List<PackingDistribution> Distributions
        {
            get;
            set;
        }

        public List<PackingDimension> Dimensions
        {
            get;
            set;
        }
    }

    public class PackingOrders
    {
        public int PackingID
        {
            get;
            set;
        }

        public int OrderDetailID
        {
            get;
            set;
        }

        public int TotalPackages
        {
            get;
            set;
        }

        public string PackageNumbers
        {
            get;
            set;
        }

        public int ProductionPlanningId
        {
            get;
            set;
        }

        public bool IsSelected
        {
            get;
            set;
        }
    }

    public class PackingDistribution
    {
        public int PackingDistributionID
        {
            get;
            set;
        }

        public int ProductionPlanningID
        {
            get;
            set;
        }

        public int OrderDetailID
        {
            get;
            set;
        }

        public int PackingID
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

        public string StyleNumber
        {
            get;
            set;
        }

        public string FabricColor
        {
            get;
            set;
        }

        public string Item
        {
            get;
            set;
        }

        public string Fabric
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public int ShippingQuantity
        {
            get;
            set;
        }

        public int PkgNoFrom
        {
            get;
            set;
        }

        public int PkgNoTo
        {
            get;
            set;
        }

        public bool IsRatioPack
        {
            get;
            set;
        }

        public int RatioPackQtyPerPkg
        {
            get;
            set;
        }

        public int Mode
        {
            get;
            set;
        }

        public int[] Sizes
        {
            get;
            set;
        }

        public List<OrderDetailSizes> PackingSizes
        {
            get;
            set;
        }
    }

    public class PackingDimension
    {
        public int PackingDimensionID
        {
            get;
            set;
        }

        public int PackingID
        {
            get;
            set;
        }

        public string Dimension
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }
    }
    //addde by abhishek on 4/8/2017
    [Serializable]
    public class PackingDelivery : BaseEntity
    {
        public int OrderDetailsID
        {
            get;
            set;
        }

        public string Flag
        {
            get;
            set;
        }
        public int ConsolidationShippingID
        {
            get;
            set;
        }
        public string LandingETA
        {
            get;
            set;
        }
        public string BIno
        {
            get;
            set;
        }
        public string FlightDetails
        {
            get;
            set;
        }
        public string PackingListFilePath
        {
            get;
            set;
        }
        public string InvoiceFilePath
        {
            get;
            set;
        }
        public string InvoiceNumber
        {
            get;
            set;
        }
        public double InvoiceAmount
        {
            get;
            set;
        }
        public string InvoiceDate
        {
            get;
            set;
        }
        public string SBno
        {
            get;
            set;
        }
        public string SBDate
        {
            get;
            set;
        }
        public string PaymentDueDate
        {
            get;
            set;
        }
        public int LoggedInUserID
        {
            get;
            set;
        }
        public string ShippingNo
        {
            get;
            set;
        }
        public int IsConsolidation 
        {
            get;
            set;
        }
        public string SerialNumber
        {
            get;
            set;
        }
        public string StyleNumber
        {
            get;
            set;
        }
        public double TotalBEAmount
        {
            get;
            set;
        }
        public string BankRefNumber
        {
            get;
            set;
        }
        public string BankRefDate
        {
            get;
            set;
        }
        public string Tenure
        {
            get;
            set;
        }
        public string PaymentReceiveDate
        {
            get;
            set;
        }
        public double PaymentReceiveAmt
        {
            get;
            set;
        }
        public int IsFullPaymentReceive
        {
            get;
            set;
        }
        public int GroupInvoiceBankRefID
        {
            get;
            set;
        }
        public int ConvertTO
        {
            get;
            set;
        }
        public int OrderID
        {
            get;
            set;
        }
        public int BankRefNoCount
        {
            get;
            set;
        }
        public string PaymentClearDate
        {
            get;
            set;
        }
        public int BankRefID
        {
            get;
            set;
        }
        public string IsSingle
        {
            get;
            set;
        }
        
        public double BankPaymentRecAmt
        {
            get;
            set;
        }
        public int IsFullPaymentCleard
        {
            get;
            set;
        }
        public int ShipmentNo__PkID
        {
            get;
            set;
        }
        public int IsAction
        {
            get;
            set;
        }
        public double BankPendingAmt
        {
            get;
            set;
        }
        public List<SplitOrderBillingDetails> SplitDetails
        {
            get;
            set;
        }
        public string OldBnkRefNo
        {
            get;
            set;
        }
        public double InvoiceShipValue
        {
            get;
            set;
        }
        public double FrightCharge 
        {
            get;
            set;
        }
        public double InsuranceAmt
        {
            get;
            set;
        }
        public double DiscountAmt
        {
            get;
            set;
        }
        
    }
    [Serializable]
    public class SplitOrderBillingDetails
    {
        public int SplitShipmentNoID
        {
            get;
            set;
        }

        public string SplitBankRefNumber
        {
            get;
            set;
        }

        public PackingDelivery PackingDelivery
        {
            get;
            set;
        }

        public string SplitPaymentRecDate
        {
            get;
            set;
        }
        public double SplitPaymentReceivedAmount
        {
            get;
            set;
        }
        public int SplitIsCompletePaymentClear
        {
            get;
            set;
        }
    }
    //end
    public class PackingCollection : List<Packing>
    {

    }
}
