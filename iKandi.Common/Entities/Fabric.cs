using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class FabricGroupAdmin : EntityBasetable
    {
        public string FabricGroupName { get; set; }

        public List<Fabric> FabricGroup { get; set; }
        public List<FabricUnitNameByPoNumber> FabricPoUnits { get; set; }

        public class Fabric
        {
            public string FabName { get; set; }
            public string CC { get; set; }
            public string GSM { get; set; }
            public string Composition { get; set; }
            public string width { get; set; }
            public string Handfeel { get; set; }

        }
        //adedd by abhishek 22/3/2019
        public class FabricDetailsHistory
        {
            public string FabricQualityID { get; set; }
            public string OrderDetailsID { get; set; }
            public string ChallanID { get; set; }
            public string ChallanNumber { get; set; }
            public string IssueQty { get; set; }
            public string IssueDate { get; set; }
            public string FabricDetails { get; set; }
            public string ReturnedChallanQty { get; set; }
            public string PoNumber { get; set; }
            public string SrvQty { get; set; }


        }
        public class FabricDetails
        {
            public string Flag { get; set; }
            public string FlagOption { get; set; }
            public int FabricQualityID { get; set; }
            public string FabricName { get; set; }
            public string ColorPrint { get; set; }
            public string UnitName { get; set; }
            public string CountConstruction { get; set; }
            public string GSM { get; set; }
            public double GreigedShrinkage { get; set; }
            public double ResidualShrinkage { get; set; }
            public int IsGerigeShrinkage { get; set; }
            public int IsResidualShrinkage { get; set; }
            public int stage1 { get; set; }
            public int stage2 { get; set; }
            public int stage3 { get; set; }
            public int stage4 { get; set; }
            public int AdjustmentQty { get; set; }

            public int BalanceQty { get; set; }
            public int QtyToOrder { get; set; }
            public int PendingQtyToOrder { get; set; }
            public int UserID { get; set; }
            public double GreigedResidualShrinkage { get; set; }
            public double width { get; set; }
            public int TotalQtyToSend { get; set; }
            public int PirorStageQty { get; set; }
            public int SendQty { get; set; }
            public int Currentstage { get; set; }
            public int periviousstgae { get; set; }
            public int StyleID { get; set; }
            public bool IsStyleSpecific { get; set; }

           



        }
        public List<FabricDetailsDayed> FabricDetail { get; set; }
        public class FabricDetailsDayed
        {
            public string Flag { get; set; }
            public string FlagOption { get; set; }
            public int FabricQualityID { get; set; }
            public string FabricName { get; set; }
            public string CountConstruction { get; set; }
            public string GSM { get; set; }
            public string FabricColor { get; set; }
            public int FabricQuantity { get; set; }
            public double GreigedShrinkage { get; set; }
            public double ResidualShrinkage { get; set; }
            public int BalanceInHouse { get; set; }
            public int QtyToOrder { get; set; }
            public int UserID { get; set; }
            public int width { get; set; }
            public int BalanceQty { get; set; }
            public int PirorStageQty { get; set; }
            public int TotalSendQtyByFabID { get; set; }
            public int CurrentStage { get; set; }
            public int PeriviousStage { get; set; }
            public bool IsStyleSpecific { get; set; }
            public int StyleID { get; set; }
            public int OrderDetailID { get; set; }
            public string PreviousStageName { get; set; }
            public string adjustmentqty { get; set; }
            public string IsStyleSpecificCaption { get; set; }

            public int stage1 { get; set; }
            public int stage2 { get; set; }
            public int stage3 { get; set; }
            public int stage4 { get; set; }
            public string UnitName { get; set; }
            public int Previousadjustmentqty { get; set; }
        }
        public List<FabricContractDetails> ContractDetails { get; set; }
        public class FabricContractDetails
        {
            public int StyleID { get; set; }
            public string StyleNumber { get; set; }
            public string SerialNumber { get; set; }
            public int FabricQty { get; set; }
            public int FinalFabricQtyToOrder { get; set; }
            public int FabricQualityID { get; set; }
            public decimal CuttingWastage { get; set; }
            public int RequiredQty { get; set; }
        }
        //added by abhishek 29/7/2019


        // Added By sanjeev on 09/30/2021
        public class FabricBasic
        {
            public string Flag { get; set; }
            public string FlagOption { get; set; }
            public int FabricQualityID { get; set; }
            public string FabricName { get; set; }
            public string ColorPrint { get; set; }
            public string UnitName { get; set; }
            public string CountConstruction { get; set; }
            public string GSM { get; set; }
            public double GreigedShrinkage { get; set; }
            public double ResidualShrinkage { get; set; }
            public bool IsGerigeShrinkage { get; set; }
            public bool IsResidualShrinkage { get; set; }
            public int stage1 { get; set; }
            public int stage2 { get; set; }
            public int stage3 { get; set; }
            public int stage4 { get; set; }
            public int AdjustmentQty { get; set; }
            public int BalanceQty { get; set; }
            public int QtyToOrder { get; set; }
            public int PendingQtyToOrder { get; set; }
            public int UserID { get; set; }
            public double GreigedResidualShrinkage { get; set; }
            public double width { get; set; }
            public int TotalQtyToSend { get; set; }
            public int PirorStageQty { get; set; }
            public int SendQty { get; set; }
            public int CurrentStage { get; set; }
            public int PreviousStage { get; set; }
            public int StyleID { get; set; }
            public bool IsStyleSpecific { get; set; }
            public string SQD1Detail { get; set; }
            public string SQD2Detail { get; set; }
            public string SQD3Detail { get; set; }
            public int QutationCount { get; set; }
            public int Previousadjustmentqty { get; set; }
            public string PreviousStageName { get; set; }
            public string IsStyleSpecificCaption { get; set; }

            public string Actual { get; set; }
            public string ShippedButNotIssued { get; set; }
            public string ShippedAndIssued { get; set; }
            public string Total { get; set; }
            public string HSNCode { get; set; }


        }

        public class FabricUnitNameByPoNumber
        {
            public string PoNumber { get; set; }
            public string UnitsID { get; set; }
            public string UnitName { get; set; }
        }

        public class FabricReRaiseDetails
        {
            public int Fabric_QualityID { get; set; }
            public string PrintName { get; set; }
            public string FabricName { get; set; }
            public int stage1 { get; set; }
            public int stage2 { get; set; }
            public int stage3 { get; set; }
            public int stage4 { get; set; }
            public int CurrentStage { get; set; }
            public int PreviousStage { get; set; }
            public int StyleID { get; set; }
            public bool IsStyleSpecific { get; set; }
            public int MasterPO_Id { get; set; }
            public string PO_Number { get; set; }
            public int ReceivedQty { get; set; }
            public string SupplierName { get; set; }
            public int SupplierID { get; set; }
            public int RemaningQty { get; set; }
            public int SendQty { get; set; }
            public int HoldQty { get; set; }
            public int CancelPoQty { get; set; }
            public int PoStatus { get; set; }
            public bool IsJuniorSignatory { get; set; }
            public bool IsAuthorizedSignatory { get; set; }
            public bool IsPartySignature { get; set; }

            public double QtyInArchieve { get; set; }

        }

        public class FabricOrderAllUpdate
        {
            public int Fabric_QualityID { get; set; }
            public string PrintName { get; set; }
            public bool IsResidualShrinkage { get; set; }
            public Double ResidualShrinkage { get; set; }
            public Double GreigedShrinkage { get; set; }
            public int QtyToOrder { get; set; }
            public int PendingQtyToOrder { get; set; }
            public int UserID { get; set; }
            public int SendQty { get; set; }
            public int BallanceInHouse { get; set; }
            public int Stage1 { get; set; }
            public int Stage2 { get; set; }
            public int Stage3 { get; set; }
            public int Stage4 { get; set; }
            public int PrevStageType { get; set; }
            public int CurrentstageNumber { get; set; }
            public bool IsStyleSpecific { get; set; }
            public int StyleId { get; set; }
        }

        public class FabricStyleSerialDetail
        {
            public int Fabric_QualityID { get; set; }
            public string PrintName { get; set; }
            public int StyleID { get; set; }
            public string StyleNumber { get; set; }
            public string SerialNumber { get; set; }
            public int RemainingFabQty { get; set; }
            public int TotalReuiredFabQty { get; set; }
            public Double Residual_Sh { get; set; }
            public Double CuttingWastage { get; set; }
            public int FabricQtyToOrder { get; set; }
            public int FabricRequiredQty { get; set; }
            public int CurrentStage { get; set; }
            public int PreviousStage { get; set; }
        }
    }

    public class FabricInspectSystem
    {
        public int Inspection_Id { get; set; }

        public int SupplierPO_Id { get; set; }

        public int SRV_Id { get; set; }

        public string CheckerName1 { get; set; }

        public string CheckerName2 { get; set; }

        public string CheckerName3 { get; set; }

        public DateTime InspectionDate { get; set; }

        public int TotalQty { get; set; }

        public int UnitId { get; set; }

        public int RecievedQty { get; set; }

        public int ClaimedQty { get; set; }

        public int CheckedQty { get; set; }

        public int PassQty { get; set; }

        public int HoldQty { get; set; }

        public int FailQty { get; set; }

        // public int TotalPcs { get; set; }

        public int CreatedBy { get; set; }

        public string Comments { get; set; }
        public bool IsFabricQA { get; set; }
        public bool IsFabricGM { get; set; }

        public int InternalLabSpeciman { get; set; }
        public int ExternalLabSpeciman { get; set; }

        public bool InternalSentToLab { get; set; }
        public bool ExternalSentToLab { get; set; }

        public bool InternalReceivedInLab { get; set; }
        public bool ExternalReceivedInLab { get; set; }

        public DateTime InternalSentToLabDate { get; set; }
        public DateTime ExternalSentToLabDate { get; set; }

        public DateTime InternalReceivedInLabDate { get; set; }
        public DateTime ExternalReceivedInLabDate { get; set; }

        public string InternalLabReport { get; set; }
        public string ExternalLabReport { get; set; }

        public int FinalDecision { get; set; }
        public DateTime FinalDecisionDate { get; set; }

        public int TotalExternalQty { get; set; }

        public int FailedRaisedDebit { get; set; }
        public int FailedStock { get; set; }
        public int FailedGoodStock { get; set; }
        public string FailedParticular { get; set; }

        public int InspectRaisedDebit { get; set; }
        public int InspectUsableStock { get; set; }
        public string InspectParticular { get; set; }

        public bool IsLabManager { get; set; }

        public DateTime LabManagerApprovedDate { get; set; }
        public DateTime FabricQAUpdatedOn { get; set; }
        public DateTime FabricGMUpdatedOn { get; set; }

        public int FabricQABy { get; set; }
        public int FabricGMBy { get; set; }
        public int LabManagerBy { get; set; }
        public int FabricCheckerBy { get; set; }
        public bool IsFabricChecker { get; set; }
        public DateTime CheckerApprovedDate { get; set; }
        public int LabdecisionInternal { get; set; }
        public int LabDecisionExternal { get; set; }

        public int IsCommercialPass { get; set; }
    }

    public class FabricInspect
    {
        public int InspectionParticular_Id { get; set; }
        public int Inspection_Id { get; set; }

        public int BoxNo { get; set; }
        public int DieLot { get; set; }

        public decimal ClaimedLength { get; set; }

        public decimal ActLength { get; set; }
        public decimal PassQty { get; set; }
        public decimal CheckedQty { get; set; }
        public decimal FailQty { get; set; }
        public decimal HoldQty { get; set; }
        //new properties added start
        public decimal Width_S { get; set; }
        public decimal Width_M { get; set; }
        public decimal Width_E { get; set; }
        public decimal Weaving_1 { get; set; }
        public decimal Weaving_2 { get; set; }
        public decimal Weaving_3 { get; set; }
        public decimal Weaving_4 { get; set; }
        public decimal Patta { get; set; }
        public decimal Hole { get; set; }
        public decimal PrintedDefectes_1 { get; set; }
        public decimal PrintedDefectes_2 { get; set; }
        public decimal PrintedDefectes_3 { get; set; }
        public decimal PrintedDefectes_4 { get; set; }
        public decimal WeaPointsPerSquirdYards { get; set; }
        //new properties added end
        public string Decision { get; set; }
        public int CreatedBy { get; set; }
        public int StockQty { get; set; }
    }
}
