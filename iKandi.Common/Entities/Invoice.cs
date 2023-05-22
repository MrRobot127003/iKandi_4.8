using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class Invoice : BaseEntity
    {
        public string ExporterName
        {
            get;
            set;
        }
        public string Totalstr { get; set; }
        public int InvoiceID
        {
            get;
            set;
        }

        public int ModeID
        {
            get;
            set;
        }

        public int IkandiInvoiceID
        {
            get;
            set;
        }

        public string Consignee
        {
            get;
            set;
        }
        public string Notify
        {
            get;
            set;
        }
        public string PreCarriageBy
        {
            get;
            set;
        }

        public string PlaceOfReceptPreCarriage
        {
            get;
            set;
        }

        public string FlightNo
        {
            get;
            set;
        }

        public DateTime FlightDate
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

        public string InvoiceNo
        {
            get;
            set;
        }

        public DateTime InvoiceDate
        {
            get;
            set;
        }

        public DateTime BIPLInvoiceDate
        {
            get;
            set;
        }

        public DateTime IkandiInvoiceDate
        {
            get;
            set;
        }

        public string ExporterRefNo
        {
            get;
            set;
        }

        public string OtherRefrence
        {
            get;
            set;
        }

        public string Buyer
        {
            get;
            set;
        }
        public string CountryOfOriginGoods
        {
            get;
            set;
        }
        public string CountryOfFinalDestination
        {
            get;
            set;
        }
        public string SBNO
        {
            get;
            set;
        }
        public DateTime SBDate
        {
            get;
            set;
        }
        public string MAWBNO
        {
            get;
            set;
        }
        public string HAWBNO
        {
            get;
            set;
        }
        public string MAWBType
        {
            get;
            set;
        }
        public string HAWBType
        {
            get;
            set;
        }
        public DateTime HAWBDate
        {
            get;
            set;
        }
        public string Freight
        {
            get;
            set;
        }
        public string Terms
        {
            get;
            set;
        }
        public string MarkAndNo
        {
            get;
            set;
        }
        public string Description1
        {
            get;
            set;
        }
        public string Description2
        {
            get;
            set;
        }
        public string Description3
        {
            get;
            set;
        }
        public string Description4
        {
            get;
            set;
        }
        public int Quantity
        {
            get;
            set;
        }

        public int BIPLInvoiceQuantity
        {
            get;
            set;
        }
        public int IkandiInvoiceQuantity
        {
            get;
            set;
        }

        public double Rate
        {
            get;
            set;
        }
        public double Amount1
        {
            get;
            set;
        }
        public double Amount2
        {
            get;
            set;
        }
        public double Amount3
        {
            get;
            set;
        }
        public double Total
        {
            get;
            set;
        }
        public double DiscountRate
        {
            get;
            set;
        }
        public double DiscountTotal
        {
            get;
            set;
        }
        public double GrossTotal
        {
            get;
            set;
        }
        public double VatRate
        {
            get;
            set;
        }
        public double VatTotal
        {
            get;
            set;
        }
        public double GrandTotal
        {
            get;
            set;
        }
        public double BiplInvoiceGrandTotal
        {
            get;
            set;
        }
        public double IkandiInvoiceGrandTotal
        {
            get;
            set;
        }

        
        public string PackingDetails
        {
            get;
            set;
        }

        public string InsuranceText
        {
            get;
            set;
        }
        public string DiscountText
        {
            get;
            set;
        }
        public string FreightText
        {
            get;
            set;
        }

        public string AmountInWord
        {
            get;
            set;
        }
        public int InvoiceType
        {
            get;
            set;
        }
        public int PackingID
        {
            get;
            set;
        }

        public String PackingIDs
        {
            get;
            set;
        }

        public string TermsOfDelevery
        {
            get;
            set;
        }
        public string CountryOfOrigin
        {
            get;
            set;
        }
        public string VATNO
        {
            get;
            set;
        }

        public string BuyerOrderNumber
        {
            get;
            set;
        }

        public string DescOfGoods
        {
            get;
            set;
        }

        public string NumberAndKindOfPackages
        {
            get;
            set;
        }

        public DateTime PaymentDueDate
        {
            get;
            set;
        }

        public DateTime PaymentReceivedDate
        {
            get;
            set;
        }

        public double PaymentReceivedAmount
        {
            get;
            set;
        }

        public string BIPLPInvoiceNo
        {
            get;
            set;
        }

        public string LineItemNumber
        {
            get;
            set;
        }
        public string ModeName
        {
            get;
            set;
        }

        public double FreightPrepaid
        {
            get;
            set;
        }

        public double InsurancePrepaid
        {
            get;
            set;
        }

        public double Discount
        {
            get;
            set;
        }

        public DateTime OrderDate
        {
            get;
            set;
        }

        public string AmountMode
        {
            get;
            set;
        }

        public string TotalMode
        {
            get;
            set;
        }

        public double SumOfDueAmount
        {
            get;
            set;
        }

        public int TermsInNumber
        {
            get;
            set;
        }

        public DateTime DC
        {
            get;
            set;
        }

        public int ParentIkandiInvoiceID
        {
            get;
            set;
        }

        public string InvoiceComments
        {
            get;
            set;
        }

        public string AssocaitedBiplInvoicedId
        {
            get;
            set;
        }
        public string AssocaitedBiplInvoicedAmount
        {
            get;
            set;
        }
        public string AssocaitedBiplInvoicedQuantity
        {
            get;
            set;
        }
        public string AssocaitedBiplInvoicedNo
        {
            get;
            set;
        }
        public string IkandiInvoiceNumbers
        {
            get;
            set;
        }
        public string IkandiInvoiceIds
        {
            get;
            set;
        }
        public string IkandiInvoiceDates
        {
            get;
            set;
        }
        public string IkandiInvoiceDetails
        {
            get;
            set;
        }
        public OrderDetail OrderDetail
        {
            get;
            set;
        }
        public string InvoiceDetails
        {
            get;
            set;
        }
        public string Manufacturer
        {
            get;
            set;
        }
        public string Detail1Text
        {
            get;
            set;
        }
        public string Detail2Text
        {
            get;
            set;
        }
        public string Detail3Text
        {
            get;
            set;
        }
        public string Detail4Text
        {
            get;
            set;
        }
        public string Detail5Text
        {
            get;
            set;
        }
        public string Detail6Text
        {
            get;
            set;
        }
        public string Detail7Text
        {
            get;
            set;
        }
        public string Detail8Text
        {
            get;
            set;
        }
        public string Detail9Text
        {
            get;
            set;
        }
        public string Detail10Text
        {
            get;
            set;
        }
        public string Detail11Text
        {
            get;
            set;
        }
        public string Detail1Value
        {
            get;
            set;
        }
        public string Detail2Value
        {
            get;
            set;
        }
        public string Detail3Value
        {
            get;
            set;
        }
        public string Detail4Value
        {
            get;
            set;
        }
        public string PackingData
        {
            get;
            set;
        }
    }


    public class InvoiceOrder : OrderDetail
    {
        public int BillCount
        {
            get;
            set;
        }
        public double TotalBEAmount
        {
            get;
            set;
        }
        public int IsPaid
        {
            get;
            set;
        }
        public string IsMultiple
        {
            get;
            set;
        }
        public string IsSingle
        {
            get;
            set;
        }

        public ProductionPlanning ProductionPlanning
        {
            get;
            set;
        }

        public ShipmentPlanning ShipmentPlanning
        {
            get;
            set;
        }

        public Packing PackingList
        {
            get;
            set;
        }

        public DeliveryBooking DeliveryBooking
        {
            get;
            set;
        }

        public Invoice Invoice
        {
            get;
            set;
        }

        public BoutiqueBilling BoutiqueBilling
        {
            get;
            set;
        }

        public bool IsBoutiqueBilling
        {
            get;
            set;
        }
        public string PaymentHistory
        {
            get;
            set;
        }
    }

    [Serializable]
    public class BoutiqueBilling : BaseEntity
    {
        public int BoutiqueBillingID
        {
            get;
            set;
        }

        public string BENumber
        {
            get;
            set;
        }

        public DateTime BEDate
        {
            get;
            set;
        }

        public DateTime PaymentDueDate
        {
            get;
            set;
        }

        public DateTime PaymentReceivedDate
        {
            get;
            set;
        }

        public double PaymentReceivedAmount
        {
            get;
            set;
        }

        public int tenure
        {
            get;
            set;
        }

        public int InvoiceId
        {
            get;
            set;
        }

        public string IsSingle
        {
            get;
            set;
        }

        public string IsMultiple
        {
            get;
            set;
        }

        public List<BoutiqueBillingOrder> BillingOrders
        {
            get;
            set;
        }

    }

    [Serializable]
    public class BoutiqueBillingOrder
    {
        public int BoutiqueBillingOrderID
        {
            get;
            set;
        }

        public int InvoiceID
        {
            get;
            set;
        }

        public BoutiqueBilling BoutiqueBilling
        {
            get;
            set;
        }

        public bool IsDelete
        {
            get;
            set;
        }
    }

}
