using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace iKandi.Common
{
    public class Costing
    {
        public string FileName { get; set; }

        public int Overhead { get; set; }

        //abhishek
        public int CostingWaste { get; set; }
        public int MinOverHead { get; set; }
        public int MaxOverHead { get; set; }
        public int MinCMT { get; set; }
        public int MinProfit { get; set; }
        public int OHValue_ForPercent { get; set; }
        public int OHPercent { get; set; }
        public bool IsOldOverHead { get; set; }

        public string ApplicableCoffinBox { get; set; }
        public bool isDiffernt { get; set; }
        //end

        public int CostingID { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int StyleID { get; set; }
        public int OrderId { get; set; }
        public int OrderDetailId { get; set; }
        public string StyleNumber { get; set; }
        public int Quantity { get; set; }
        public decimal Weight { get; set; }
        public int ParentCostingID { get; set; }
        public string PrintIds { get; set; }
        public double OverHead { get; set; }
        public double DesignCommission { get; set; }
        //END
        public string MakingType { get; set; }
        public int ExpectedQty { get; set; }
        public int frtUptoport { get; set; }
        public int IsOrderConfirmed { get; set; }
        public int IsCutting { get; set; }
        public double AgreedPrice { get; set; }
        public string CurrencySymbol { get; set; }

        public double PriceQuoted { get; set; }
        public double AllQuantity { get; set; }
        public double iKandiPrice { set; get; }
        public string TargetPriceCurrency { get; set; }
        public double TargetPrice { set; get; }
        public string DesignerName { set; get; }
        public decimal CMT { get; set; }
        public string EndDate { get; set; }
        public double Eff { get; set; }
        public string flag { get; set; }
        public int PcsPerHrs { get; set; }
        public double NoOfDays { get; set; }
        public float SAM1 { get; set; }
        public int PcsPerDay { get; set; }
        public int Holidays { get; set; }


        public double CMTF { get; set; }
        public int CostingTask { get; set; }
        public int OB_WS { get; set; }
        public bool IsVersion { get; set; }
        public int VerifyCosting { get; set; }
        public int Costing_Waste { get; set; }
        public int Achivement { get; set; }
        public double Finish { get; set; }
        public double LBL_TAGS { get; set; }
        public double TEST { get; set; }
        public double Hangers { get; set; }
        public double HANGER_LOOPS { get; set; }
        public double CoffinBox { get; set; }
        public decimal Total_Made { get; set; }
        public int fromvari { get; set; }
        public int tovari { get; set; }
        public List<FabricCosting> FabricCostingItems { get; set; }
        public List<Accessories> AccessoryItems { get; set; }
        public List<DeleteAccessoris> DeleteAccessoriesItem { get; set; }
        public List<Processes> ProcessItems { get; set; }
        public List<CommentHistory> CommetHistoryItems { get; set; }
        public List<Charges> ChargesItems { get; set; }
        public Charges CostingCharges { get; set; }

        public List<LandedCosting> LandedCostingItems { get; set; }
        public FOBPricing FOBPricingItem { get; set; }
        public List<FOBPricing> FOBPricingItemNew { get; set; }
        public string SampleImageURL1 { get; set; }
        public string SampleImageURL2 { get; set; }
        public decimal Discount { get; set; }
        public double FrieghtUptoFinalDestination { get; set; }
        public double FrieghtUptoPort { get; set; }
        public double FincCost { get; set; }
        public double DirectCost { get; set; }
        public int ConvertTo { get; set; }
        public string CurrencySign { get; set; }
        public double MarkupOnUnitCTC { get; set; }
        public double CommisionPercent { get; set; }
        public double DefaultConversionRate { get; set; }
        public double ConversionRate { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public string OverallComments { get; set; }
        public string Comments { get; set; }
        public int CurrentStatusID { get; set; }
        public int PriceQuotedVisibility { get; set; }
        public int Weight_ReadOnly { get; set; }
        public string ActionBy { get; set; }
        public bool CounterComplete { get; set; }
        public bool IsBestSeller { get; set; }
        //added by abhishek 23/5/2017

        public string TeckFileDoc { get; set; }
        public int ParentDepartmentID { get; set; }
        public string ParentDepartment { get; set; }
        public string ParentDepartment_d { get; set; }
        public int DepartmentID { get; set; }
        public double SAM { get; set; }
        public string DepartmentName { get; set; }
        public string BIPlChangesHistory { get; set; }
        public string iKandiChangesHistory { get; set; }
        public string FITsStatus { get; set; }
        public int IsIkandiClient { get; set; }
        //Gajendra New Costing
        [DefaultValue(0.0)]
        public double CostingCutWastage { get; set; }
        [DefaultValue(0.0)]
        public double CostingVAWastage { get; set; }
        //abhishek 18 Sep 2017
        public int WastageID { get; set; }
        public int ExpectedID { get; set; }
        public string WastageQty { get; set; }
        public int IsCostingOpen { get; set; }
    }

    public class FabricCosting
    {
        public int FabricCostingID { get; set; }
        public string FabricType { get; set; }
        public string Fabric { get; set; }
        public string PrintType { get; set; }
        public string FabPrintNumber { get; set; }
        public int IsPrint { get; set; }
        public double Width { get; set; }
        public double Average { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public double Waste { get; set; }
        public double Total { get; set; }
        public int CostingID { get; set; }
        public int SequenceNumber { get; set; }
        public QueryType CostingQueryType { get; set; }
        public bool IsAir { get; set; }
        public string isMultiple { get; set; }
        public string specialFabricDetails { get; set; }
        public string LayFileName { get; set; }
        public string CadFileName { get; set; }
        public string StcFileName { get; set; }
        public string SupplierName { get; set; }
        public double ResidualShrinkage { get; set; }
        public double TotalFabric { get; set; }
        public double TotalPrice { get; set; }
        public double GSM { get; set; }
        public string SupplyType { get; set; }
        public string FabTypeId { get; set; }
        public bool Disabled_Fabric { get; set; }
        public string FabricQualityId { get; set; }
        public double CostWidth { get; set; }
        public double DyedRate { get; set; }
        public double PrintRate { get; set; }
        public double DigitalPrintRate { get; set; }
        public string CountConstruct { get; set; }
        public int ValueAdditionId1 { get; set; }
        public int ValueAdditionId2 { get; set; }
        public double VAWastage1 { get; set; }
        public double VAWastage2 { get; set; }
        public double VARate1 { get; set; }
        public double VARate2 { get; set; }
    }

    public class Accessories
    {
        public int AccessoryID { get; set; }
        public string Item { get; set; }
        public double Quantity { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public int CostingID { get; set; }
        public int SequenceNumber { get; set; }
        public string remarks { get; set; }
        public QueryType CostingQueryType { get; set; }
        public int AccessoryPercent { get; set; }
        public double UnitQty { get; set; }
        public double Wastage { get; set; }
        public string Unit { get; set; }
        [DefaultValue("0")]//Gajendra Costing
        public string AccessoryQualityID { get; set; }
        public bool Disabled_ACC { get; set; }
        public double TotalQuantity { get; set; }
        public double TotalPrice { get; set; }
        public int IsDefaultAccessory { get; set; }
        public int ClientId { get; set; }
        public int ParentDepartmentId { get; set; }
        public int DepartmentId { get; set; }
    }

    public class DeleteAccessoris
    {
        public int AccessoryMasterId { get; set; }
        public string AccessoryName { get; set; }
        public int AccessoryQualitySizeID { get; set; }
    }

    public class Charges
    {
        public int ChargeID { get; set; }
        public string ChargeName { get; set; }
        public Double ChargeValue { get; set; }
        public int CostingID { get; set; }
        public int SequenceNumber { get; set; }
        public QueryType CostingQueryType { get; set; }
    }

    public class LandedCosting
    {
        public int LandedCostingID { get; set; }
        public string Code { get; set; }
        public string Mode { get; set; }
        public int ModeId { get; set; }
        public string FOBBoutique { get; set; }
        public string FOBIkandi { get; set; }
        public string ModeCost { get; set; }
        public int ModeCostID { get; set; }
        public string Duty { get; set; }
        public string Handling { get; set; }
        public string Delivery { get; set; }
        public string Processing { get; set; }
        public int ProcessCostId { get; set; }
        public double Margin { get; set; }
        public double Discount { get; set; }
        public double GrandTotal { get; set; }
        public double QuotedPrice { get; set; }
        public double AgreedPrice { get; set; }
        public int ModeDeliveryTime { get; set; }
        public DateTime ExpectedBookingDate { get; set; }
        public DateTime CalculatedDeliveryDate { get; set; }
        public int SequenceNumber { get; set; }
        public int CostingID { get; set; }
        public QueryType CostingQueryType { get; set; }
        public string ProcessCost { get; set; }
    }

    public class FOBPricing
    {
        public int FOBPricingID { get; set; }
        public int ModeId { get; set; }
        public string FOBDelhi { get; set; }
        public string Code { get; set; }
        public double HaulageCharges { get; set; }
        public double FOBMargin { get; set; }
        public double Discount { get; set; }
        public double GrandTotal { get; set; }
        public double QuotedPrice { get; set; }
        public double AgreedPrice { get; set; }
        public int ModeDelivery { get; set; }
        public DateTime ExpectedBookingDate { get; set; }
        public DateTime CalculatedDeliveryDate { get; set; }
        public int CostingID { get; set; }
        public int SequenceNumber { get; set; }
        public QueryType CostingQueryType { get; set; }
    }

    public class CostingCollection : Collection<Costing>
    {

    }

    public class ClientCostingDefault
    {
        public int ClientID { get; set; }
        public int DepartmentID { get; set; }
        public int ItemID { get; set; }
        public float Value { get; set; }
        public int ID { get; set; }
    }
    public class Processes
    {
        public string ProcessCostingId { get; set; }
        public string ValueAdditionID { get; set; }
        public string Item { get; set; }
        public string FromStatus { get; set; }
        public string ToStatus { get; set; }
        public double Rate { get; set; }
        public double Wastage { get; set; }
        public double Amount { get; set; }
        public int CostingID { get; set; }
        public QueryType CostingQueryType { get; set; }
        public string CostingVAWastage { get; set; }
        public int SeqNo { get; set; }
    }
    public class CommentHistory
    {
        public int CostingID { get; set; }
        public int TypeFlag { get; set; }
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public int UpdatedByUserId { get; set; }
        public string UpdatedOn { get; set; }
        public string DetailDescription { get; set; }
        public bool isBipl { get; set; }
        public bool isPriceQuote { get; set; }
    }

    public class ValueAddition : Costing
    {
        public int ValueAdditionID
        {
            get;
            set;
        }
        public string ValueAdditionName
        {
            get;
            set;
        }
        public double VA_Wastage
        {
            get;
            set;
        }
        public double VA_Rate
        {
            get;
            set;
        }
    }

}
