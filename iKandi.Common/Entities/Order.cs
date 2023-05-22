using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class Order : BaseEntity
    {
        // Add By Ravi kumar on 19/12/2014
        
        public int OrderInsert
        {
            get;
            set;
        }
        public int OrderID
        {
            get;
            set;
        }
        //Added by abhishek on 13/1/2015
        public DateTime LabdipTargetETA
        {
            get;
            set;
        }

        //End by abhishek on 13/1/2015
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
       
        public Client Client
        {
            get;
            set;
        }

        public DateTime OrderDate
        {
            get;
            set;
        }
        //Added By Ashish on 31/10/2014
        public DateTime PatternSampleDate
        {
            get;
            set;
        }
        public DateTime ProductionFileDate
        {
            get;
            set;
        }
        public DateTime StichedStartDate
        {
            get;
            set;
        }
        public DateTime PCDDate
        {
            get;
            set;
        }
        //END

        public string SerialNumber
        {
            get;
            set;
        }
        public double OutHousePrice
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
       
        public string DepartmentName
        {
            get;
            set;
        }

        public int DeptID
        {
            get;
            set;
        }
        public string CompanyName
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public DateTime BIHdate
        {
            get;
            set;
        }

        public string CMT
        {
            get;
            set;
        }
        public DateTime BulkApprTarget
        {
            get;
            set;
        }
        public DateTime InitialApprTarget
        {
            get;
            set;
        }
        public int ProdDays
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

        public string InvoiceLocation
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
        public int CDQDA
        {
            get;
            set;
        }
        public string CQDName
        {
            get;
            set;
        }

        public DateTime BulkETA
        {
            get;
            set;
        }

        public Charges charges
        {
            get;
            set;
        }

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

        public WorkflowInstanceDetail WorkflowInstanceDetail
        {
            get;
            set;
        }

        public ProductionPlanning ProductionPlanning
        {
            get;
            set;
        }


        public LandedCosting LandedCosting
        {
            get;
            set;
        }


        public AccessoryWorking AccessoryWorking
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }

        public int StatusModeSequence
        {
            get;
            set;
        }
        public int ORDER_CONFIRMED_SALES_StatusID
        {
            get;
            set;
        }
        // sushil kumar add property for order process , PCD,IEmgmt

        public List<Orderbasicinfo> Orderbasic
        {
            get;
            set;
        }
        public List<OrderContractinfo> OrderContract
        {
            get;
            set;
        }
        public List<Orderfabricinfo> Orderfabric
        {
            get;
            set;
        }
        public wasteinfo Orderwaste
        { get; set; }
        public List<OrderAccinfo> OrderACC
        {
            get;
            set;
        }

        public List<OrderPCDdata> OrderPCD
        {
            get;
            set;
        }
        public List<OrderProcess> Orderprocess
        {
            get;
            set;
        }

        public List<OrderIEmanagement> OrderIEmgmt
        {
            get;
            set;
        }
        //
        public List<OrderDetail> OrderBreakdown
        {
            get;
            set;
        }

        public List<OrderLimitation> OrderLimitation
        {
            get;
            set;
        }
        public OrderLimitation OrderLimitation1
        {
            get;
            set;
        }

        public CuttingDetail CuttingDetail
        {
            get;
            set;
        }

        public StitchingHistory StitchingHistory
        {
            get;
            set;

        }

        public StitchingDetail StitchingDetail
        {
            get;
            set;

        }
        public InlinePPMOrderContract InlinePPMOrderContract
        {
            get;
            set;
        }

        public FabricInhouseHistory FabricInhouseHistory
        {
            get;
            set;
        }

        public CuttingHistory CuttingHistory
        {
            get;
            set;
        }

        public OrderDetail OrderDetail
        {
            get;
            set;
        }

        public Print Print
        {
            get;
            set;
        }
        public FabricApprovalDetails FabricApprovalDetails
        {
            get;
            set;
        }

        public double BiplPrice
        {
            get;
            set;
        }
        public double TotalOrderPrice
        {
            get;
            set;
        }
        public AccessoryInHouseHistory AccessoryInHouseHistory
        {
            get;
            set;
        }

        public Fits Fits
        {
            get;
            set;
        }

        public FitsTrack FitsTrack
        {
            get;
            set;
        }

        public FabricWorking FabricWorking
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

        public int IsBiplAgreement
        {
            get;
            set;
        }
        public int OrderDetailsID
        {
            get;
            set;
        }
        //Ashish on 9/01/14
        public List<OrderFabhistroy> OrderFabrichistroy
        {
            get;
            set;
        }
        public string MarchantNotes
        {//Ashish on 9/01/14
            get;
            set;
        }
        public string Remarks
        {//Ashish on 9/01/14
            get;
            set;
        }
        public int TypeOfPacking
        {
            get;
            set;
        }

        public int AgreedCostingID
        {
            get;
            set;
        }

        public int IsApproved
        {//manisha on 28th march
            get;
            set;
        }

        public string OrderType
        {//manisha on 28th march
            get;
            set;
        }

        public string StyleNumber_d
        {//manisha on 28th march
            get;
            set;
        }
        public string CompanyName_d
        {//manisha on 28th march
            get;
            set;
        }
        public string Description_d
        {//manisha on 28th march
            get;
            set;
        }
        public string Name_d
        {//manisha on 28th march
            get;
            set;
        }
        public string Comments_d
        {//manisha on 28th march
            get;
            set;
        }
        public int TotalQuantity_d
        {//manisha on 28th march
            get;
            set;
        }
        public DateTime BulkETA_d
        {//manisha on 28th march
            get;
            set;
        }
        public double BiplPrice_d
        {//manisha on 28th march
            get;
            set;
        }
        public int ConvertTo_d
        {//manisha on 28th march
            get;
            set;
        }
        public string CurrencySign_d
        {//manisha on 28th march
            get;
            set;
        }
        public int TypeOfPacking_d
        {//manisha on 28th march
            get;
            set;
        }
        public string TypeOfPackingName
        {//manisha on 4th April
            get;
            set;
        }
        public List<OrderDetail> OrderBreakdown_d
        {//manisha on 28th march
            get;
            set;
        }
        public int BuyingHouseID
        {//manisha on 7th June
            get;
            set;
        }
        public int IsIkandiClient
        {//manisha on 8th June
            get;
            set;
        }
        // Ravi kumar on 11/8/15
        public string BaseStyle
        {
            get;
            set;
        }

        // Sanjeev Vishwkarma on 11/01/2022
        public int IsOldOrder
        {
            get;
            set;
        }
    }

    public class MoShippingDetail : BaseEntity
    {
        public int OrderDetailID
        {
            get;
            set;
        }

        public string ContractNumber
        {
            get;
            set;
        }
        public string IsRepeatstr
        {
          get;
          set;
        }
        public int Quantity
        {
            get;
            set;
        }

        public int OrderID
        {
            get;
            set;
        }

        public int StyleId
        {
          get;
          set;
        }

        public int Mode
        {
            get;
            set;
        }

        public string ModeName
        {
            get;
            set;
        }

        public string hdnMode
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
        public DateTime PcdDate
        {
            get;
            set;
        }
        public DateTime OrderDate
        {
            get;
            set;
        }
        public DateTime PlannedEx
        {
            get;
            set;
        }

        public Int32 IsIkandiClient
        {
            get;
            set;
        }

        public String ExFactoryInString
        {
            get
            {
                return (ExFactory == DateTime.MinValue) ? "" : ExFactory.ToString("dd MMM yy (ddd)");
            }
        }

        public String PlannedExInString
        {
            get
            {
                return (PlannedEx == DateTime.MinValue) ? "" : PlannedEx.ToString("dd MMM yy (ddd)");
            }
        }

        public String DCInString
        {
            get
            {
                return (DC == DateTime.MinValue) ? "" : DC.ToString("dd MMM yy (ddd)");
            }
        }

        public string ExFactoryColor
        {
            get;
            set;
        }

        public string SerialNumber
        {
            get;
            set;
        }
        public string Fabric1Detail
        {
            get;
            set;
        }

        //Added By Ashish on 12/8/2015
        public int LinesNo
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
        public string Remarks
        {
          get;
          set;
        }
        public string Untid
        {
            get;
            set;
        }
        public string From_Status
        {
            get;
            set;
        }
        public string To_Status
        {
            get;
            set;
        }
        public string VA_Name
        {
            get;
            set;
        }
        public string ValueAdditionID
        {
            get;
            set;
        }
        public string IsPartial
        {
            get;
            set;
        }
        public string IsVARellocation
        {
            get;
            set;
        }       
    }

    public class OrderDetail : BaseEntity
    {

        public string ReUseRiskRemark
        {
            get;
            set;
        }
        public string ReUsestylenumber
        {
            get;
            set;
        }

        public int ReusestyleID
        {
            get;
            set;
        }
      
        public string RiskRemark
        {
            get;
            set;
        }
        public string IsRepeatstr
        {
            get;
            set;
        }
        public bool IsApproveRisk
        {
            get;
            set;
        }
        public string StyleCode
        {
            get;
            set;
        }

        public int ClientID
        {
            get;
            set;
        }
        public int DepartmentID
        {
            get;
            set;
        }
        public string ContractQty
        {
            get;
            set;
        }
        public int MissedfaultCount
        {
          get;
          set;
        }
        public int TotalOcuured
        {
          get;
          set;
        }
        public string ContractsCount { get; set; }
        public bool IsShiped
        {
            get;
            set;
        }
        // ADD BY RAVI KUMAR ON 18/12/2014 FOR PCD change
        public int IsPCdateChange
        {
            get;
            set;
        }
        // End BY RAVI KUMAR ON 18/12/2014 FOR PCD change
        // ADD BY RAVI KUMAR ON 2/1/2015 FOR PCD change
        public int AfterUpdation
        {
            get;
            set;
        }
        public string IsFact
        {
            get;
            set;
        }
        public double Fabric1STCAverage
        {
            get;
            set;
        }
        //---------Added By Surendra on 08-jan-2015
        public double Fabric1lblAverage
        {
            get;
            set;
        }
        public double Fabric2lblAverage
        {
            get;
            set;
        }
        public double Fabric3lblAverage
        {
            get;
            set;
        }
        public double Fabric4lblAverage
        {
            get;
            set;
        }
        //
        public double Fabric2STCAverage
        {
            get;
            set;
        }
        public double Fabric3STCAverage
        {
            get;
            set;
        }
        public double Fabric4STCAverage
        {
            get;
            set;
        }

        public string IsCutAvg1
        {
            get;
            set;
        }

        public string IsCutAvg2
        {
            get;
            set;
        }

        public string IsCutAvg3
        {
            get;
            set;
        }

        public string IsCutAvg4
        {
            get;
            set;
        }
        public string IsAckAvg1
        {
            get;
            set;
        }
        public string IsAckAvg2
        {
            get;
            set;
        }
        public string IsAckAvg3
        {
            get;
            set;
        }
        public string IsAckAvg4
        {
            get;
            set;
        }
        public string Fabric1AvgHistory
        {
            get;
            set;
        }
        public string Fabric2AvgHistory
        {
            get;
            set;
        }
        public string Fabric3AvgHistory
        {
            get;
            set;
        }
        public string Fabric4AvgHistory
        {
            get;
            set;
        }

        public string CostAvg
        {
            get;
            set;
        }

        public DateTime CurExFactory
        {
            get;
            set;
        }
        public Int16 UseDBExFactory
        {
            get;
            set;
        }
        public int OrderDetailID
        {
            get;
            set;
        }

        public int IsValid
        {
            get;
            set;
        }

        public string LineItemNumber
        {
            get;
            set;
        }
        public string QA
        {
            get;
            set;
        }

        public int SizeOption
        {
            get;
            set;
        }

        public string Size
        {
            get;
            set;
        }

        public string ContractNumber
        {
            get;
            set;
        }

        public string StyleNumber
        {
            get;
            set;
        }

        public string FabricDetails
        {
            get;
            set;
        }

        public string ExFactoryCutting
        {
            get;
            set;
        }
        public string MDANumber
        {
            get;
            set;
        }

        public Order ParentOrder
        {
            get;
            set;
        }

        public double Business
        {
            get;
            set;

        }

        public string Fabric1
        {
            get;
            set;
        }

        public double PercentageOverallPcsPacked
        {
            get;
            set;
        }

        public string Fabric1Details
        {
            get;
            set;
        }
       
        public string Fabric2
        {
            get;
            set;
        }

        public string Fabric2Details
        {
            get;
            set;
        }

        public string Fabric3
        {
            get;
            set;
        }

        public string Fabric3Details
        {
            get;
            set;
        }

        public string Fabric4
        {
            get;
            set;
        }

        public string Fabric4Details
        {
            get;
            set;
        }
        public string Fabric5
        {
            get;
            set;
        }

        public string Fabric5Details
        {
            get;
            set;
        }
        public string Fabric6
        {
            get;
            set;
        }

        public string Fabric6Details
        {
            get;
            set;
        }

        public DateTime FabricStartETAdate
        {
            get;
            set;
        }
        public DateTime FabricEndETAdate
        {
            get;
            set;
        }

        public DateTime FabricStartETAdate2
        {
            get;
            set;
        }
        public DateTime FabricEndETAdate2
        {
            get;
            set;
        }

        public DateTime FabricStartETAdate3
        {
            get;
            set;
        }
        public DateTime FabricEndETAdate3
        {
            get;
            set;
        }


        public DateTime FabricStartETAdate4
        {
            get;
            set;
        }
        public DateTime FabricEndETAdate4
        {
            get;
            set;
        }
        public DateTime FabricStartETAdate5
        {
            get;
            set;
        }
        public DateTime FabricEndETAdate5
        {
            get;
            set;
        }
        public DateTime FabricStartETAdate6
        {
            get;
            set;
        }
        public DateTime FabricEndETAdate6
        {
            get;
            set;
        }

        public DateTime PCD
        {
            get;
            set;
        }

        public DateTime BIH
        {
            get;
            set;
        }

        public int FabricInHouse1
        {
            get;
            set;
        }

        public int CutPercentInhouse
        {
            get;
            set;
        }


        public int StitchedPercentInhouse
        {
            get;
            set;
        }

        public int PackedPercentInhouse
        {
            get;
            set;
        }

        public int VAPercentInhouse
        {
            get;
            set;
        }

        public DateTime CutStartETA
        {
            get;
            set;
        }

        public DateTime CutEndETA
        {
            get;
            set;
        }

        public DateTime StitchedStartETA
        {
            get;
            set;
        }

        public DateTime StitchedEndETA
        {
            get;
            set;
        }


        public DateTime VAStartETA
        {
            get;
            set;
        }

        public DateTime VAEndETA
        {
            get;
            set;
        }

        public DateTime PackedETA
        {
            get;
            set;
        }
        //Added By Ashish on 4/3/2015
        public DateTime FitsStatusETA
        {
            get;
            set;
        }

        public DateTime STCETA
        {
            get;
            set;
        }

        public DateTime PatternSampleDateETA
        {
            get;
            set;
        }

        public DateTime TOPETA
        {
            get;
            set;
        }

        public int FabricPercent1
        {
            get;
            set;
        }

        public int FabricPercent2
        {
            get;
            set;
        }
        public int FabricPercent3
        {
            get;
            set;
        }
        public int FabricPercent4
        {
            get;
            set;
        }
        public int FabricPercent5
        {
            get;
            set;
        }
        public int FabricPercent6
        {
            get;
            set;
        }

        public int fabric1ETARemarks
        {
            get;
            set;
        }

        public int fabric2ETARemarks
        {
            get;
            set;
        }

        public int fabric3ETARemarks
        {
            get;
            set;
        }

        public int fabric4ETARemarks
        {
            get;
            set;
        }

        public string Fabric1Print
        {
            get;
            set;
        }
        public string Fabric2Print
        {
            get;
            set;
        }
        public string Fabric3Print
        {
            get;
            set;
        }
        public string Fabric4Print
        {
            get;
            set;
        }
        public string TargetDateS
        {
            get;
            set;
        }
      
        public List<AccessoriesDetailsETA> AccessoriesETA
        {
            get;
            set;
        }
        public class AccessoriesDetailsETA
        {
            public int OrderDetailsID
            {
                get;
                set;
            }
            public string AccessoriesName
            {
                get;
                set;
            }
            public double TotalQuantity
            {
                get;
                set;
            }
            public int ApprovedByAccessoryManager
            {
                get;
                set;
            }
            public int ApprovedByAccountManager
            {
                get;
                set;
            }
            public string QnAvail_k
            {
                get;
                set;
            }
            public string QuantityAvail
            {
                get;
                set;
            }
            public string Required
            {
                get;
                set;
            }
            public DateTime ApprovalDate
            {
                get;
                set;
            }
            public DateTime ApprovedByAccessoryManagerOn
            {
                get;
                set;
            }
            public DateTime ApprovedByAccountManagerOn
            {
                get;
                set;
            }

            public DateTime AccesoriesETA
            {
                get;
                set;
            }



            public DateTime UpdatedOn
            {
                get;
                set;
            }
            public int percentInHouse
            {
                get;
                set;
            }
            public DateTime BIHETAAcc
            {
                get;
                set;
            }
            public int AccessoryWorkingDetailID
            {
                get;
                set;
            }
            public string ExtraContractWise
            {
                get;
                set;
            }
            public string ETAPending
            {
                get;
                set;
            }
            public string BIHETARemark
            {
                get;
                set;
            }


        }

        //Added by us
        public string OrderDetailccgsm
        {
            get;
            set;
        }
        //Add new for Order form by Yatendra
        public string CCGSM1
        {
            get;
            set;
        }

        public string CCGSM2
        {
            get;
            set;
        }
        public string CCGSM3
        {
            get;
            set;
        }
        public string CCGSM4
        {
            get;
            set;
        }
        public string CCGSM5
        {
            get;
            set;
        }
        public string CCGSM6
        {
            get;
            set;
        }



        public string FabricApproval1
        {
            get;
            set;
        }

        public string FabricApproval2
        {
            get;
            set;
        }

        public string FabricApproval3
        {
            get;
            set;
        }

        public string FabricApproval4
        {
            get;
            set;
        }
        public string FabricApproval5
        {
            get;
            set;
        }
        public string FabricApproval6
        {
            get;
            set;
        }
        public DateTime ShipmentOffer
        {
            get;
            set;
        }


        public string Fabric
        {
            get
            {
                string FabricTotal = string.Empty;

                if (Fabric1 != null && Fabric1.Length != 0)
                {
                    if (Fabric1Details != null && Fabric1Details.Length != 0)
                    {

                        FabricTotal += Fabric1;
                        FabricTotal += ":" + Fabric1Details + Environment.NewLine;
                    }
                }

                if (Fabric2 != null && Fabric2.Length != 0)
                {
                    if (Fabric2Details != null && Fabric2Details.Length != 0)
                    {
                        FabricTotal += Fabric2;
                        FabricTotal += ":" + Fabric2Details + Environment.NewLine;
                    }
                }

                if (Fabric3 != null && Fabric3.Length != 0)
                {
                    if (Fabric3Details != null && Fabric3Details.Length != 0)
                    {
                        FabricTotal += Fabric3;
                        FabricTotal += ":" + Fabric3Details + Environment.NewLine;
                    }
                }


                if (Fabric4 != null && Fabric4.Length != 0)
                {
                    if (Fabric4Details != null && Fabric4Details.Length != 0)
                    {

                        FabricTotal += Fabric4;
                        FabricTotal += ":" + Fabric4Details + Environment.NewLine;
                    }
                }

                return FabricTotal;
            }

            set { }
        }

        public double Quantity
        {
            get;
            set;
        }
        public double shippingQty
        {
            get;
            set;
        }
        public string CompanyName
        {
            get;
            set;
        }


        public double Bipl_amount
        {
            get;
            set;
        }

        public double ikandi_amount
        {
            get;
            set;
        }

        public int WeekCount
        {
            get;
            set;
        }
        public string Weeklyikandi_amount
        {
            get;
            set;
        }
        public int OrderID
        {
            get;
            set;
        }

        public int Mode
        {
            get;
            set;
        }

        public string ModeName
        {
            get;
            set;
        }
        //Added By Ashish On 19/11/2014 
        public int StyleId
        {
            get;
            set;
        }

        public string SerialNumber
        {
            get;
            set;
        }
        public DateTime StartETAdate
        {
            get;
            set;
        }
        public DateTime EndETAdate
        {
            get;
            set;
        }
        public DateTime CalculatedBIH
        {
            get;
            set;
        }

        public string AccessoryName
        {
            get;
            set;
        }

        public int AccessoryId
        {
            get;
            set;
        }


        public int CutDetailId
        {
            get;
            set;
        }


        public int StitchingDetailID
        {
            get;
            set;
        }


        public int OnlyEmbhistoryID
        {
            get;
            set;
        }
        // edit by surendra on 14/10/2013
        public string StitchPCDColor
        {
            get;
            set;
        }
        public DateTime BulkTargetDept
        {
            get;
            set;
        }


        public string PCDColor
        {
            get;
            set;
        }
        public DateTime StitchPCDate
        {
            get;
            set;
        }

        public DateTime CutPCDate
        {
            get;
            set;
        }

        public double CutLinesNo
        {
            get;
            set;
        }
        public double StitchLinesNo
        {
            get;
            set;
        }
        public string CutPCDateColor
        {
            get;
            set;
        }
        public string HelloLinesColor
        {
            get;
            set;
        }
        public DateTime PCDDate
        {
            get;
            set;
        }
        public int LinesNo
        {
            get;
            set;
        }
        public int HelloLinesNo
        {
            get;
            set;
        }
        public DateTime HelloDate
        {
            get;
            set;
        }
        public DateTime BulkTargetDeptFabric
        {
            get;
            set;
        }


        //end

        public string hdnMode
        {
            get;
            set;

        }

        public string Description
        {
            get;
            set;

        }
        public string File
        {
            get;
            set;

        }

        public string File1
        {
            get;
            set;

        }

        public string File2
        {
            get;
            set;

        }

        public string File3
        {
            get;
            set;

        }

        public string File4
        {
            get;
            set;

        }

        public int hdnCostingId
        {
            get;
            set;

        }

        public double iKandiPrice
        {
            get;
            set;
        }
        public double odBIPLPrice
        {
            get;
            set;
        }
        public double odOldBIPLPrice
        {
            get;
            set;
        }

        public DateTime ExFactory
        {
            get;
            set;
        }
        public DateTime pcdDateOrders
        {
            get;
            set;
        }



        public Int32 IsIkandiClient
        {
            get;
            set;
        }

        public String ExFactoryInString
        {
            get
            {
                return ExFactory.ToString("dd MMM yy (ddd)");
            }

        }
        public String PCDInString
        {
            get
            {
                return PCDDate.ToString("dd MMM yy (ddd)");
            }

        }
        public string ExFactoryColor
        {
            get;
            set;
        }


        public int WeekToEx
        {
            get;
            set;
        }

        public int TotalPackages
        {
            get;
            set;
        }

        public DateTime DC
        {
            get;
            set;
        }


        public DateTime InvoiceDate
        {
            get;
            set;
        }

        public DateTime AWBDate
        {
            get;
            set;
        }

        public String DCInString
        {
            get
            {
                return DC.ToString("dd MMM yy (ddd)");
            }

        }

        public int WeeksToDC
        {
            get;
            set;
        }


        public double Fabric1Average
        {
            get;
            set;
        }

        public double Fabric1Quantity
        {
            get;
            set;
        }

        public double Fabric2Average
        {
            get;
            set;
        }

        public double Fabric2Quantity
        {
            get;
            set;
        }

        public double Fabric3Average
        {
            get;
            set;
        }

        public double Fabric3Quantity
        {
            get;
            set;
        }

        public double Fabric4Average
        {
            get;
            set;
        }
        public double Fabric4OrderAverage
        {
            get;
            set;
        }
        public double Fabric3OrderAverage
        {
            get;
            set;
        }
        public double Fabric2OrderAverage
        {
            get;
            set;
        }
        public double Fabric1OrderAverage
        {
            get;
            set;
        }
        public double Fabric4Quantity
        {
            get;
            set;
        }

        public int isDeleted
        {
            get;
            set;
        }

        public string sortType
        {
            get;
            set;
        }

        public InlinePPM InlinePPM
        {
            get;
            set;
        }

        public List<OrderDetailSizes> OrderSizes
        {
            get;
            set;
        }
        public List<OrderAccDetail> OrderAccDetail
        {
            get;
            set;
        }
        public string SealerRemarksBIPL
        {
            get;
            set;
        }

        public string SealerRemarksiKandi
        {
            get;
            set;
        }

        public string SanjeevRemarks
        {
            get;
            set;
        }

        public string AccessoryHistory
        {
            get;
            set;
        }

        public string MerchantNotes
        {
            get;
            set;
        }

        public int ProductionUnitId
        {
            get;
            set;
        }

        public DateTime AllocationDate
        {
            get;
            set;
        }

        public bool IsAllocated
        {
            get;
            set;
        }

        public DateTime BIHFabric1
        {
            get;
            set;
        }
        public DateTime BIHFabric2
        {
            get;
            set;
        }
        public DateTime BIHFabric3
        {
            get;
            set;
        }
        public DateTime BIHFabric4
        {
            get;
            set;
        }




        public AccessoryWorkingDetail AccessoryWorkingDetail
        {
            get;
            set;

        }

        public DateTime InlineCutDate
        {
            get;
            set;
        }

        public ProductionUnit Unit
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;
        }

        public string AccessoriesRemarks
        {
            get;
            set;
        }

        public string RemarksType
        {
            get;
            set;
        }

        public int RemarksID
        {
            get;
            set;
        }

        public double fab1pl
        {
            get;
            set;
        }
        public double fab2pl
        {
            get;
            set;
        }
        public double fab3pl
        {
            get;
            set;
        }
        public double fab4pl
        {
            get;
            set;
        }

        public double Fabric1rate
        {
            get;
            set;
        }
        public double Fabric2rate
        {
            get;
            set;
        }
        public double Fabric3rate
        {
            get;
            set;
        }
        public double Fabric4rate
        {
            get;
            set;
        }

        public double Fabric1unit
        {
            get;
            set;
        }
        public double Fabric2unit
        {
            get;
            set;
        }
        public double Fabric3unit
        {
            get;
            set;
        }
        public double Fabric4unit
        {
            get;
            set;
        }

        public int Fabric1supplier
        {
            get;
            set;
        }
        public int Fabric2supplier
        {
            get;
            set;
        }
        public int Fabric3supplier
        {
            get;
            set;
        }
        public int Fabric4supplier
        {
            get;
            set;
        }


        public DateTime STCUnallocated
        {
            get;
            set;
        }
        public DateTime PCDTopsInfo
        {
            get;
            set;
        }

        public DateTime PCDAccesories
        {
            get;
            set;
        }
        public DateTime PCDCutting
        {
            get;
            set;
        }


        public DateTime PCDExfactory
        {
            get;
            set;
        }

        public DateTime PCDDATE
        {
            get;
            set;
        }


        public DateTime STCAllocated
        {
            get;
            set;
        }

        public DateTime InlineCut
        {
            get;
            set;
        }

        public DateTime ExFactoryPlanned
        {
            get;
            set;
        }

        public DateTime ApprovedToExFactory
        {
            get;
            set;
        }

        public DateTime CuttingETA
        {
            get;
            set;
        }

        public DateTime SealETA
        {
            get;
            set;
        }

        public DateTime StitchingETA
        {
            get;
            set;
        }

        public DateTime PackingETA
        {
            get;
            set;
        }

        public DateTime BulkTarget
        {
            get;
            set;
        }
        public DateTime PCDFabric
        {
            get;
            set;
        }

        public DateTime BHPlannedMeeting
        {
            get;
            set;
        }

        public Int16 IsBHMeetingCompleted
        {
            get;
            set;
        }


        public String BulkTargetInString
        {
            get
            {
                return BulkTarget.ToString("dd MMM yy (ddd)");
            }
        }

        public DateTime LabDipTarget
        {
            get;
            set;
        }


        public String LabDipTargetInString
        {
            get
            {
                return LabDipTarget.ToString("dd MMM yy (ddd)");
            }
        }

        public DateTime BulkApprovalTarget
        {
            get;
            set;
        }



        public string Status
        {
            get;
            set;
        }
        public string PPSample
        {
            get;
            set;
        }
        public string Cycle
        {
            get;
            set;
        }
        public string PPSampleSentActualDates
        {
            get;
            set;
        }

        public int StatusModeID
        {
            get;
            set;
        }

        public int StatusModeSequence
        {
            get;
            set;
        }
        //Gajendra Order Form
        public int CuttingStatusModeSequence
        {
            get;
            set;
        }
        public int ApprovedToExSequence
        {
            get;
            set;
        }
        public int DELIVERED_StatusModeID
        {
            get;
            set;
        }
        public string FitStatus
        {
            get;
            set;
        }

        public string FitStatusBgColor
        {
            get;
            set;
        }

        public int isQuantityInc
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

        public int parentOrderDetailID
        {
            get;
            set;
        }

        public DateTime PlannedEx
        {
            get;
            set;
        }

        public string FirstPartnerName
        {
            get;
            set;
        }

        public string SecondPartnerName
        {
            get;
            set;
        }

        public Boolean IsAirFabric1
        {
            get;
            set;
        }

        public Boolean IsAirFabric2
        {
            get;
            set;
        }

        public Boolean IsAirFabric3
        {
            get;
            set;
        }

        public Boolean IsAirFabric4
        {
            get;
            set;
        }

        public int Fabric1Origin
        {
            get;
            set;
        }

        public int Fabric2Origin
        {
            get;
            set;
        }

        public int Fabric3Origin
        {
            get;
            set;
        }

        public int Fabric4Origin
        {
            get;
            set;
        }

        public bool IAFabric1
        {
            get;
            set;
        }

        public bool IAFabric2
        {
            get;
            set;
        }

        public bool IAFabric3
        {
            get;
            set;
        }

        public bool IAFabric4
        {
            get;
            set;
        }

        public bool IsSizeFilledUp
        {
            get;
            set;
        }

        public bool IsCuttingFormSaved
        {
            get;
            set;
        }

        public string OrderHistory
        {
            get;
            set;
        }

        //new added
        public string OrderOldHistoryComments
        {
            get;
            set;
        }

        public double Fabric1Price
        {
            get;
            set;
        }

        public double Fabric2Price
        {
            get;
            set;
        }

        public double Fabric3Price
        {
            get;
            set;
        }

        public double Fabric4Price
        {
            get;
            set;
        }

        public string HdnDetailType
        {
            get;
            set;
        }

        public string Fabric1Desc
        {
            get;
            set;
        }

        public string Fabric2Desc
        {
            get;
            set;
        }

        public string Fabric3Desc
        {
            get;
            set;
        }

        public string Fabric4Desc
        {
            get;
            set;
        }

        public string Fabric1waste
        {
            get;
            set;
        }

        public string Fabric2waste
        {
            get;
            set;
        }

        public string Fabric3waste
        {
            get;
            set;
        }

        public string Fabric4waste
        {
            get;
            set;
        }
        public string Adjustment_Amount
        {
            get;
            set;
        }
        #region manisha order change request

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

        public int Mode_d
        {
            get;
            set;
        }

        public string ModeName_d
        {
            get;
            set;
        }

        public string Description_d
        {
            get;
            set;
        }
        public string File_d
        {
            get;
            set;
        }
        public string File1_d
        {
            get;
            set;
        }

        public string File2_d
        {
            get;
            set;
        }
        public string File3_d
        {
            get;
            set;
        }
        public string File4_d
        {
            get;
            set;
        }

        public double iKandiPrice_d
        {
            get;
            set;
        }

        public DateTime ExFactory_d
        {
            get;
            set;
        }

        public String ExFactoryInString_d
        {
            get
            {
                return ExFactory_d.ToString("dd MMM yy (ddd)");
            }

        }

        public String DCInString_d
        {
            get
            {
                return DC_d.ToString("dd MMM yy (ddd)");
            }

        }

        public string Fabric1_d
        {
            get;
            set;
        }

        public string Fabric1Details_d
        {
            get;
            set;
        }

        public string Fabric2_d
        {
            get;
            set;
        }

        public string Fabric2Details_d
        {
            get;
            set;
        }

        public string Fabric3_d
        {
            get;
            set;
        }

        public string Fabric3Details_d
        {
            get;
            set;
        }

        public string Fabric4_d
        {
            get;
            set;
        }

        public string Fabric4Details_d
        {
            get;
            set;
        }

        public bool IAFabric1_d
        {
            get;
            set;
        }

        public bool IAFabric2_d
        {
            get;
            set;
        }

        public bool IAFabric3_d
        {
            get;
            set;
        }

        public bool IAFabric4_d
        {
            get;
            set;
        }

        public string IAFabric1Text_d
        {
            get;
            set;
        }

        public string IAFabric2Text_d
        {
            get;
            set;
        }

        public string IAFabric3Text_d
        {
            get;
            set;
        }

        public string IAFabric4Text_d
        {
            get;
            set;
        }

        public int Quantity_d
        {
            get;
            set;
        }

        public DateTime DC_d
        {
            get;
            set;
        }
        public int WeeksToDC_d
        {
            get;
            set;
        }
        public int WeekToEx_d
        {
            get;
            set;
        }

        public string DepartmentName_d
        {
            get;
            set;
        }

        #endregion

        #region manisha approved to ex
        public bool IsPartShipment
        {
            get;
            set;
        }
        #endregion

        #region Added by Sanjeev for CCGSM on MO

        public string Fabric1CCGSM { get; set; }
        public string Fabric2CCGSM { get; set; }
        public string Fabric3CCGSM { get; set; }
        public string Fabric4CCGSM { get; set; }
        public string Fabric5CCGSM { get; set; }
        public string Fabric6CCGSM { get; set; }

        #endregion

        #region Added by RSB for DeliveryType on Export to excel

        public string DeliveryType { get; set; }

        #endregion
    }
    public class OrderFabhistroy : BaseEntity
    {
        //OrderDetailID
        public int OrderDetailID
        {
            get;
            set;
        }
        public int Fab1histroy
        {
            get;
            set;
        }
        public int Fab2histroy
        {
            get;
            set;
        }

        public int Fab3histroy
        {
            get;
            set;
        }

        public int Fab4histroy
        {
            get;
            set;
        }

        public int Fab1Precent
        {
            get;
            set;
        }
        public int Fab2Precent
        {
            get;
            set;
        }

        public int Fab3Precent
        {
            get;
            set;
        }

        public int Fab4Precent
        {
            get;
            set;
        }

        public string Fab1BulkStatus
        {
            get;
            set;
        }
        public string Fab2BulkStatus
        {
            get;
            set;
        }

        public string Fab3BulkStatus
        {
            get;
            set;
        }

        public string Fab4BulkStatus
        {
            get;
            set;
        }


        public int Fab1Stage
        {
            get;
            set;
        }
        public int Fab2Stage
        {
            get;
            set;
        }

        public int Fab3Stage
        {
            get;
            set;
        }

        public int Fab4Stage
        {
            get;
            set;
        }

    }
    // code add by sushil getting order accessoris 

    public class OrderAccDetail
    {

        public int AccID
        {
            get;
            set;
        }
        public string AccItem
        {
            get;
            set;
        }

        public double Quantity
        {
            get;
            set;
        }

        public double Rate
        {
            get;
            set;
        }
        public double awdQuantity
        {
            get;
            set;
        }

        public double awdRate
        {
            get;
            set;
        }
        public int unitID
        {
            get;
            set;
        }
        public int supplier { get; set; }
    }

    public class OrderAcccontractDetail
    {

        public int orderID { get; set; }
        public string lineno { get; set; }
        public string contract { get; set; }
        public double cutwst { get; set; }
        public double itemwst { get; set; }

        public double Orderqty { get; set; }
        public double PL { get; set; }



    }


    public class Orderbasicinfo
    {

        public DateTime currdate { get; set; }
        public string styleno { get; set; }
        public string sno { get; set; }
        public int totqty { get; set; }
        public int orderID { get; set; }
        public int buyer { get; set; }
        public string dprt { get; set; }
        public int Dpack { get; set; }
        public string accmgr { get; set; }
        public string des { get; set; }
        public float biplprice { get; set; }
        public Byte isreapt { get; set; }




    }

    public class OrderContractinfo
    {
        public int ContractID { get; set; }
        public string lineno { get; set; }
        public string contract { get; set; }
        public int qty { get; set; }
        public int mode { get; set; }
        public float ikandiprice { get; set; }
        public DateTime Exfactory { get; set; }
        public DateTime dcdate { get; set; }
        public int Exweek { get; set; }
        public int Dcweek { get; set; }

    }
    public class Orderfabricinfo
    {
        public int ContractID { get; set; }
        public string lineno { get; set; }
        public string contract { get; set; }
        public int qty { get; set; }
        public string fab1 { get; set; }
        public string fab1colorprint { get; set; }
        public float fab1avg { get; set; }
        public float fab1rate { get; set; }
        public float fab1mtr { get; set; }
        public float fab1pl { get; set; }
        public int fab1unit { get; set; }
        public int fab1supplier { get; set; }
        public string fab2 { get; set; }
        public string fab2colorprint { get; set; }
        public float fab2avg { get; set; }
        public float fab2rate { get; set; }
        public float fab2mtr { get; set; }
        public float fab2pl { get; set; }
        public int fab2unit { get; set; }
        public int fab2supplier { get; set; }
        public string fab3 { get; set; }
        public string fab3colorprint { get; set; }
        public float fab3avg { get; set; }
        public float fab3rate { get; set; }
        public float fab3mtr { get; set; }
        public float fab3pl { get; set; }
        public int fab3unit { get; set; }
        public int fab3supplier { get; set; }
        public string fab4 { get; set; }
        public string fab4colorprint { get; set; }
        public float fab4avg { get; set; }
        public float fab4rate { get; set; }
        public float fab4mtr { get; set; }
        public float fab4pl { get; set; }
        public int fab4unit { get; set; }
        public int fab4supplier { get; set; }

    }

    public class OrderAccinfo
    {
        public int ContractID { get; set; }
        public object[] lineno { get; set; }
        public object[] contract { get; set; }
        public string item { get; set; }
        public int unit { get; set; }
        public float qty { get; set; }
        public float rate { get; set; }
        public object[] cutwst { get; set; }
        public object[] itemwst { get; set; }
        public object[] orderqty { get; set; }
        public object[] pls { get; set; }
        public int supplier { get; set; }

    }

    public class OrderPCDdata
    {

        public DateTime BIHStart { get; set; }
        public DateTime BIHEnd { get; set; }
        public DateTime PCD { get; set; }
        public DateTime Exfactory { get; set; }
        public int ID { get; set; }
        public int Lines { get; set; }
        public float Ach { get; set; }
        public float CMT { get; set; }
        public float ploss { get; set; }

    }

    public class OrderProcess
    {

        public string priprocess { get; set; }
        public int dropdownsuplrname { get; set; }
        public int pritime { get; set; }
        public int priqty { get; set; }
        public int ID { get; set; }
        public string stage { get; set; }
        public float prirate { get; set; }

    }
    public class OrderIEmanagement
    {

        public int txtsam { get; set; }
        public int txtob { get; set; }
        public double txtminuts { get; set; }
        public float txtcmt { get; set; }
        public int ID { get; set; }
        public int txtach { get; set; }
        public float txtIEprofitloss { get; set; }
        public int defaultSAM { get; set; }
        public int defaultOB { get; set; }

    }
    public class fabriccosting
    {
        public int fabriccostingid { get; set; }
        public string Fabric { get; set; }
        public double Average { get; set; }
        public string width { get; set; }
        public double Rate { get; set; }
        public double Waste { get; set; }
        public int transday { get; set; }
    }

    public class wasteinfo
    {
        public int fab1waste { get; set; }
        public int fab1transday { get; set; }
        public int fab2waste { get; set; }
        public int fab2transday { get; set; }
        public int fab3waste { get; set; }
        public int fab3transday { get; set; }
        public int fab4waste { get; set; }
        public int fab4transday { get; set; }

        public decimal fab1orderval { get; set; }
        public decimal fab2orderval { get; set; }
        public decimal fab3orderval { get; set; }
        public decimal fab4orderval { get; set; }
    }

    // end code 

    public class OrderDetailSizes
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
        //added by Manisha on 11th may 2011
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
    }

    public class PartShipmentOrder : OrderDetail
    {
        public int PartShipmentOrderID
        {
            get;
            set;
        }

        public int PartShipmentQuantity
        {
            get;
            set;
        }
    }
    // 1/7/2015 add new class by sushil for feeding report
    public class FeedingClass
    {
        public decimal Targetminut { get; set; }
        public decimal Actualminut { get; set; }
        public decimal Delayminut { get; set; }
        public decimal TargetQTY { get; set; }
        public decimal ActualQTY { get; set; }
        public decimal DelayQTY { get; set; }
        public decimal TargetRev { get; set; }
        public decimal ActualRev { get; set; }
        public decimal DelayRev { get; set; }


    }
}
