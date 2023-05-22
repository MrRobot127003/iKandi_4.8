using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
namespace iKandi.Common
{
    public class MOOrderDetails : BaseEntity
    {
        //new work start : Girish
        public int CuttingStatus
        {
            get;
            set;
        }

        public int IsThreadAverageOptionOnMOVisible
        {
            get;
            set;
        }
        //new work End : Girish



        public string FabricStages1
        {
            get;
            set;
        }
        public string FabricStages2
        {
            get;
            set;
        }
        public string FabricStages3
        {
            get;
            set;
        }
        public string FabricStages4
        {
            get;
            set;
        }
        public string SupplyTypeForFabric1
        {
            get;
            set;
        }
        public string SupplyTypeForFabric2
        {
            get;
            set;
        }
        public string SupplyTypeForFabric3
        {
            get;
            set;
        }
        public string SupplyTypeForFabric4
        {
            get;
            set;
        }
        public string SupplyTypeForFabric5
        {
            get;
            set;
        }
        public string SupplyTypeForFabric6
        {
            get;
            set;
        }
        public string FabricStages5
        {
            get;
            set;
        }
        public string FabricStages6
        {
            get;
            set;
        }
        public string FabricStages1_ToolTip
        {
            get;
            set;
        }
        public string FabricStages2_ToolTip
        {
            get;
            set;
        }
        public string FabricStages3_ToolTip
        {
            get;
            set;
        }
        public string FabricStages4_ToolTip
        {
            get;
            set;
        }
        public string FabricStages5_ToolTip
        {
            get;
            set;
        }
        public string FabricStages6_ToolTip
        {
            get;
            set;
        }
        public string QCNarration
        {
            get;
            set;
        }
        public string InspectionID
        {
            get;
            set;
        }
        public string TotalcutQtyforCTSL
        {
            get;
            set;
        }
        public string IsSingleProduction
        {
            get;
            set;
        }
        public string IsFact
        {
            get;
            set;
        }
        //added by abhishek on 19/1/2016
        public bool IsRepeat
        {
            get;
            set;
        }
        public bool IsRepeatWithChanges
        {
            get;
            set;
        }

        //public int IsIkandiClient
        //{
        //    get;
        //    set;
        //}
        //end by abhishek on 19/1/2015
        //added by abhishek on 25/12/2015
        public string MoTestRepoertFilePath
        {
            get;
            set;
        }
        public string PeekCapacity
        {
            get;
            set;
        }
        //added by abhishek on 19/1/2016
        public bool PhotoShotWrite
        {
            get;
            set;
        }
        public bool CDCharWrite
        {
            get;
            set;
        }


        public bool TestReportWrite
        {
            get;
            set;
        }
        //end by abhishek on 19/1/2015
        public string TestReports
        {
            get;
            set;
        }
        //added by abhishek on 21/1/2016
        public DateTime CdchartTargetDateETA
        {
            get;
            set;
        }
        public DateTime CdchartActualDateETA
        {
            get;
            set;
        }
        public DateTime CdchartDateETA
        {
            get;
            set;
        }
        public int IsTestReportDone
        {
            get;
            set;
        }
        public int IntialAprd1
        {
            get;
            set;
        }
        public int IntialAprd2
        {
            get;
            set;
        }
        public int IntialAprd3
        {
            get;
            set;
        }
        public int IntialAprd4
        {
            get;
            set;
        }
        public int IntialAprd5
        {
            get;
            set;
        }
        public int IntialAprd6
        {
            get;
            set;
        }
        public string IsVaCompleted
        {
            get;
            set;
        }
        public string IsReScan
        {
            get;
            set;
        }
        public double DressPrice
        {
            get;
            set;
        }
        public bool IsCheck
        {
            get;
            set;
        }

        public string OutHouseAll
        {
            get;
            set;
        }
        public string IsICCheckOnDate
        {
            get;
            set;
        }
        public double fab1CheckInHouse
        {
            get;
            set;
        }
        public double fab2CheckInHouse
        {
            get;
            set;
        }
        public double fab3CheckInHouse
        {
            get;
            set;
        }
        public double fab4CheckInHouse
        {
            get;
            set;
        }
        public double fab5CheckInHouse
        {
            get;
            set;
        }
        public double fab6CheckInHouse
        {
            get;
            set;
        }

        public string Fab1InHouseChecked_k
        {
            get;
            set;
        }
        public string Fab2InHouseChecked_k
        {
            get;
            set;
        }
        public string Fab3InHouseChecked_k
        {
            get;
            set;
        }
        public string Fab4InHouseChecked_k
        {
            get;
            set;
        }
        public string Fab5InHouseChecked_k
        {
            get;
            set;
        }
        public string Fab6InHouseChecked_k
        {
            get;
            set;
        }
        // Add by Ravi kumar on 7/12/2016
        public string QualityControl_Prev_Status
        {
            get;
            set;
        }
        public int BIPLAgreementPending
        {
            get;
            set;
        }
        //end by abhishek on 21/1/2016
        public DateTime TestReportsDateActual
        {
            get;
            set;
        }
        public DateTime TestReportsDateETA
        {
            get;
            set;
        }
        public bool FitsTestReportsRead
        {
            get;
            set;
        }
        public bool FitsTestReportsWrite
        {
            get;
            set;
        }
        // added by Ravi kumar on 28/12/2015


        public string LinePlannigStartDate
        {
            get;
            set;
        }
        public string IsLinePlannigStartDate
        {
            get;
            set;
        }
        public DateTime LinePlanningEndDate
        {
            get;
            set;
        }
        public double CMTActual
        {
            get;
            set;
        }
        public double CMTTarget
        {
            get;
            set;
        }
        public double CostedCMT
        {
            get;
            set;
        }
        public double ProfitLoss
        {
            get;
            set;
        }
        public double ActualEff
        {
            get;
            set;
        }
        public double TargetEff
        {
            get;
            set;
        }
        public double BreakEvenEff
        {
            get;
            set;
        }
        public double TotalPenalty
        {
            get;
            set;
        }
        public double PenaltyPercentAge
        {
            get;
            set;
        }
        public DateTime ExpectedDC
        {
            get;
            set;
        }
        public int OrderType
        {
            get;
            set;
        }
        // Added By Ravi kumar for Plan date on 19-3-18
        public DateTime StartDate
        {
            get;
            set;
        }
        public DateTime EndDate
        {
            get;
            set;
        }
        public DateTime PlanDate
        {
            get;
            set;
        }
        public int IsUnPlanned
        {
            get;
            set;
        }
        public int IsPendingStitch
        {
            get;
            set;
        }
        public int PlanType
        {
            get;
            set;
        }
        //abhsihek 24/dec
        public bool Fabric1StageSelect
        {
            get;
            set;
        }
        public bool Fabric2StageSelect
        {
            get;
            set;
        }
        public bool Fabric3StageSelect
        {
            get;
            set;
        }
        public bool Fabric4StageSelect
        {
            get;
            set;
        }
        public bool Fabric5StageSelect
        {
            get;
            set;
        }
        public bool Fabric6StageSelect
        {
            get;
            set;
        }
        public bool MO_BIPL_PRICE_UPDATE
        {
            get;
            set;
        }
        // End Adding for PlanDate

        // end by Ravi kumar on 29/12/2015
        public class AccessoriesApprovedDate
        {
            public int OrderDetailsID
            {
                get;
                set;
            }
            public string ApprovalDate
            {
                get;
                set;
            }
        }

        public class ProductionDetails
        {
            public string IsVAComplete
            {
                get;
                set;
            }

            public int OrderID
            {
                get;
                set;
            }
           
            public int OrderDetailID
            {
                get;
                set;
            }
            public string FactoryName
            {
                get;
                set;
            }
            //abhishek on 2/3/2016
            public string FactoryCodes
            {
                get;
                set;
            }
            public string IsFactoryInOut
            {
                get;
                set;
            }
            //end by abhishek on 2/3/2016
            public int CuttingShare
            {
                get;
                set;
            }
            public int StitchingShare
            {
                get;
                set;
            }
            public int FinishingShare
            {
                get;
                set;
            }
            public int TotalCutPcs
            {
                get;
                set;
            }
            public int TotalCutReady
            {
                get;
                set;
            }
            public int TotalStitched
            {
                get;
                set;
            }
            public int TotalFinished
            {
                get;
                set;
            }
            public int TodayCut
            {
                get;
                set;
            }
            public int TodayCutReady
            {
                get;
                set;
            }
            public string IsSingleProduction
            {
                get;
                set;
            }
            public int TodayStitch
            {
                get;
                set;
            }
            public int TodayFinish
            {
                get;
                set;
            }
            public int FactorySpecification
            {
                get;
                set;
            }
            public int IsShipped
            {
                get;
                set;
            }
            public string StyleNumber
            {
                get;
                set;
            }
            public int UnitId
            {
                get;
                set;
            }
            public int ValueAddedQty
            {
                get;
                set;
            }
            public int ValueAddedQtyToday
            {
                get;
                set;
            }
            public DateTime ExFactory
            {
                get;
                set;
            }
            public string LineNo//abhishek
            {
                get;
                set;
            }
            public string LineNoOut//abhishek
            {
                get;
                set;
            }
            public int StitchQty_OutHouse
            {
                get;
                set;
            }
            public int FinishQty_OutHouse
            {
                get;
                set;
            }
            public int Finishing_InHouse
            {
                get;
                set;
            }
            //abhishek
            public decimal CutIssueQty
            {
                get;
                set;
            }
            public int CutIssueQtyTooltip
            {
                get;
                set;
            }
            public string IsVisibleOutHouse
            {
                get;
                set;
            }
            public int CutIssueQtyTotal
            {
                get;
                set;
            }
            public int IsRescan
            {
                get;
                set;
            }
            public int RescanTotalValue
            {
                get;
                set;
            }
            public int RescanPendingValue
            {
                get;
                set;
            }
            public int OutHouseHalfStitch
            {
                get;
                set;
            }
            public int LinePlanning_StitchQty
            {
                get;
                set;
            }


        }

        public List<ProductionDetails> Production
        {
            get;
            set;
        }

        public class AccessoriesDetails
        {
            public int OrderId { get; set; }
            public int OrderDetailsID { get; set; }
            public int OrderDetailWorkingDetailID { get; set; }
            public string AccessoriesName { get; set; }
            public int AccessoryMasterId { get; set; }
            public string Size { get; set; }
            public string Color_Print { get; set; }
            public string Griege_Finish_Stage { get; set; }
            public string Griege_Finish_Stage_tooltip { get; set; }
            public string Process_Stage { get; set; }
            public string Process_Stage_tooltip { get; set; }
            public int Inhouse_Percent { get; set; }
            public DateTime PoOrder_Date { get; set; }
            public int SRVReceivedQty { get; set; }
            public int IssuedQty { get; set; }
            public double TotalQuantity { get; set; }
            public DateTime SrvEndEta_Date { get; set; }
            public int AccessoryPending_OrderId { get; set; }
            public string GarmentUnit { get; set; }

            public int ApprovedByAccessoryManager { get; set; }
            public int ApprovedByAccountManager { get; set; }

            public string QuantityAvail { get; set; }
            public string QnAvail_k { get; set; }
            public string Required { get; set; }
            public DateTime ApprovalDate { get; set; }
            public DateTime ApprovedByAccessoryManagerOn { get; set; }
            public DateTime ApprovedByAccountManagerOn { get; set; }
            public string AccessETABackColor { get; set; }

            public string AccessETAForColor { get; set; }
            public DateTime AccesoriesETA { get; set; }
            //END

            //Added By Ashish on 23/2/2015
            public string AccessPercentInhouseBackColor { get; set; }

            public string AccessPercentInhouseForColor { get; set; }
            public string AccessPrintForColor { get; set; }
            //END
            public string AccessNameBackColor { get; set; }

            public string AccessNameForColor { get; set; }
            //END
            //Added By Ashish on 24/2/2015
            public string AccessCaptionForColor { get; set; }
            //END

            //Added By Ashish on 26/2/2015 
            public string BIHAccessBackColor { get; set; }
            public string BIHAccessForColor { get; set; }
            //

            public DateTime UpdatedOn { get; set; }
            public int percentInHouse { get; set; }
            public DateTime BIHETAAcc { get; set; }
            public int AccessoryWorkingDetailID { get; set; }
            // Added by shubhendu for stage1 7/10/2021
            public int Stage1 { get; set; }

            //public string ExtraContractWise
            //{
            //    get;
            //    set;
            //}
            //public string ETAPending
            //{
            //    get;
            //    set;
            //}
            public int IsOldOrder { get; set; }

            public bool IsExcludeFromBIH { get; set; }

        }
        //Added By Ashish
        public List<AccessoriesDetails> Accessories
        {
            get;
            set;
        }
        public List<AccessoriesApprovedDate> ApprovedDate
        {
            get;
            set;
        }
        public List<PermissionDetails> MOPermission
        {
            get;
            set;
        }
        //END

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

        public string IsRepeatstr
        {
            get;
            set;
        }
        //added by abhishek on 19/1/2016
        public bool PhotoShoot
        {
            get;
            set;
        }

        public DateTime IsPhotoShoot
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
        public double Weeklyikandi_amount
        {
            get;
            set;
        }
        //end by abhishek on 19/1/2015

        //added by abhishek on 2/2/2016
        public string DelayTask
        {
            get;
            set;
        }
        public string FabricDelayTask
        {
            get;
            set;
        }
        public string AccessoriesDelayTask
        {
            get;
            set;
        }
        public string TechnicalDelayTask
        {
            get;
            set;
        }
        public string ProductionDelayTask
        {
            get;
            set;
        }
        //end by abhishek on 2/2/2016

        //added by abhishek on 31/3/2016
        public string IsTestReportvisible
        {
            get;
            set;
        }
        public string IsCdchartVisible
        {
            get;
            set;
        }
        //end 
        public string LineFacInfo
        {
            get;
            set;
        }

        public string ContractNumber
        {
            get;
            set;
        }

        public string DesinationCode
        {
            get;
            set;
        }

        public string MDANumber
        {
            get;
            set;
        }
        public int PlanningLine
        {
            get;
            set;
        }
        public bool IsFinalCheck
        {
            get;
            set;
        }
        public int LoadLineNo
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
        public double discount
        {
            get;
            set;

        }

        public string Fabric1
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
        public string Fabric5
        {
            get;
            set;
        }
        public string Fabric6
        {
            get;
            set;
        }
        public string Fabric_ModuleDatabase
        {
            get;
            set;
        }

        public string Fabric4Details
        {
            get;
            set;
        }
        public string Fabric5Details
        {
            get;
            set;
        }
        public string Fabric6Details
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
        public string Fabric5Print
        {
            get;
            set;
        }
        public string Fabric6Print
        {
            get;
            set;
        }
        public DateTime FabricTrackingTarget1
        {
            get;
            set;
        }
        public DateTime FabricTrackingTarget2
        {
            get;
            set;
        }
        public DateTime FabricTrackingTarget3
        {
            get;
            set;
        }
        public DateTime FabricTrackingTarget4
        {
            get;
            set;
        }
        public DateTime FabricTrackingTarget5
        {
            get;
            set;
        }
        public DateTime FabricTrackingTarget6
        {
            get;
            set;
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
        public DateTime ShipmentOffer
        {
            get;
            set;
        }
        //added by abhishek on 6 aug
        public int ModesIDByStyleID
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

        public string Samval
        {
            get;
            set;
        }
        public string Samcap
        {
            get;
            set;
        }
        public string OBval
        {
            get;
            set;
        }
        public string OBfile
        {
            get;
            set;
        }
        public string Avalmin
        {
            get;
            set;
        }

        public int OrderedSam
        {
            get;
            set;
        }

        public int STCSam
        {
            get;
            set;
        }
        public int Days
        {
            get;
            set;
        }
        public string POpending
        {
            get;
            set;
        }
        public string Pricevariation
        {
            get;
            set;
        }
        public string AuditStatus
        {
            get;
            set;
        }
        public string CQDA
        {
            get;
            set;
        }

        public int Margin
        {
            get;
            set;
        }
        public int Convertto
        {
            get;
            set;
        }
        public string ProdRemarks
        {
            get;
            set;
        }

        public double shippingQty
        {
            get;
            set;
        }


        public int OrderID
        {
            get;
            set;
        }
        public int Percent1
        {
            get;
            set;
        }
        public int Percent2
        {
            get;
            set;
        }
        public int Percent3
        {
            get;
            set;
        }
        public int Percent4
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
        //Added By Ashish on 4/3/2015
        public DateTime FitsETA
        {
            get;
            set;
        }
        //END
        public DateTime STCTAppActual
        {
            get;
            set;
        }
        public DateTime STCETA
        {
            get;
            set;
        }
        public string STCpending
        {
            get;
            set;
        }

        public DateTime TOPETA
        {
            get;
            set;
        }
        public DateTime STCApprovedETA
        {
            get;
            set;
        }
        public string STCAPPpending
        {
            get;
            set;
        }
        public DateTime PatternSampleDateETA
        {
            get;
            set;
        }
        public string Patternpending
        {
            get;
            set;
        }
        public string Cuttingpending
        {
            get;
            set;
        }
        public string prodfilepending
        {
            get;
            set;
        }

        public string TOPpending
        {
            get;
            set;
        }

        public string Cutreadypending
        {
            get;
            set;
        }
        public string Stitchpending
        {
            get;
            set;
        }
        public string EMBpending
        {
            get;
            set;
        }
        public string Packingpending
        {
            get;
            set;
        }

        public string fab1pending
        {
            get;
            set;
        }

        public string fab2pending
        {
            get;
            set;
        }

        public string fab3pending
        {
            get;
            set;
        }

        public string fab4pending
        {
            get;
            set;
        }

        public DateTime CuttingReceivedDateETA
        {
            get;
            set;
        }
        public DateTime ProductionFileDateETA
        {
            get;
            set;
        }
        public DateTime PPSampleETA
        {
            get;
            set;
        }
        public DateTime HandOverTargetDate
        {
            get;
            set;
        }
        public DateTime ProductionPlanningETA//abhishek 9/9
        {
            get;
            set;
        }
        public DateTime HandOverETADate
        {
            get;
            set;
        }
        public DateTime HandOverActualDate
        {
            get;
            set;
        }
        public DateTime PatternReadyTargetDate
        {
            get;
            set;
        }
        public DateTime PatternReadyETADate
        {
            get;
            set;
        }
        public DateTime PatternReadyActualDate
        {
            get;
            set;
        }
        public DateTime SampleSentTargetDate
        {
            get;
            set;
        }
        public DateTime SampleSentETADate
        {
            get;
            set;
        }
        public DateTime FitsCommentesTargetDate
        {
            get;
            set;
        }
        public DateTime FitsCommentesActualDate
        {
            get;
            set;
        }
        public DateTime FitsCommentesETADate
        {
            get;
            set;
        }
        public DateTime SampleSentActualDate
        {
            get;
            set;
        }
        public string CADMaster
        {
            get;
            set;
        }

        // Add remark sushil
        public DateTime fabETA1
        {
            get;
            set;
        }

        public DateTime fabETA2
        {
            get;
            set;
        }

        public DateTime fabETA3
        {
            get;
            set;
        }

        public DateTime fabETA4
        {
            get;
            set;
        }
        public string STCETARemark
        {
            get;
            set;
        }
        public string TOPETARemark
        {
            get;
            set;
        }
        public string STCApprovedETARemark
        {
            get;
            set;
        }
        public string PatternETARemark
        {
            get;
            set;
        }


        public DateTime STCTRequested
        {
            get;
            set;
        }
        public DateTime PatternSampleDate
        {
            get;
            set;
        }
        public DateTime CuttingReceivedDate
        {
            get;
            set;
        }
        public DateTime ProductionFileDate
        {
            get;
            set;
        }
        public DateTime PlanningDate
        {
            get;
            set;
        }
        public DateTime TopActualAprovel
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
        public DateTime STCDateReqTar
        {
            get;
            set;
        }
        public DateTime STCDateAppTar
        {
            get;
            set;
        }

        public DateTime STCDateReqTarPattern
        {
            get;
            set;
        }

        public DateTime STCDateReqTarCutting
        {
            get;
            set;
        }
        //Added By Ashish  
        public DateTime fabric1ETA
        {
            get;
            set;
        }
        public DateTime Fabric1ENDETA
        {
            get;
            set;
        }
        public DateTime fabric2ETA
        {
            get;
            set;
        }
        public DateTime Fabric2ENDETA
        {
            get;
            set;
        }
        public DateTime fabric3ETA
        {
            get;
            set;
        }
        public DateTime Fabric3ENDETA
        {
            get;
            set;
        }
        public DateTime fabric4ETA
        {
            get;
            set;
        }
        public DateTime fabric5ETA
        {
            get;
            set;
        }
        public DateTime fabric6ETA
        {
            get;
            set;
        }
        public DateTime Fabric4ENDETA
        {
            get;
            set;
        }
        public DateTime Fabric5ENDETA
        {
            get;
            set;
        }
        public DateTime Fabric6ENDETA
        {
            get;
            set;
        }
        public DateTime StrikeOff1ETA
        {
            get;
            set;
        }
        public DateTime StrikeOff2ETA
        {
            get;
            set;
        }
        public DateTime StrikeOff3ETA
        {
            get;
            set;
        }
        public DateTime StrikeOff4ETA
        {
            get;
            set;
        }
        public DateTime StrikeOff5ETA
        {
            get;
            set;
        }
        public DateTime StrikeOff6ETA
        {
            get;
            set;
        }

        //END
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
        public string ActualProfitMargin
        {
            get;
            set;
        }

        public double AgreedPrice
        {
            get;
            set;
        }

        public double ConversionRate
        {
            get;
            set;
        }


        public double BoutiqueBusiness
        {
            get;
            set;
        }

        public DateTime ExFactory
        {
            get;
            set;
        }
        public Decimal WeigtShipCost
        {
            get;
            set;
        }
        public DateTime pcdDateOrders
        {
            get;
            set;
        }
        //--added by surendra
        public DateTime HOPPMTarget
        {
            get;
            set;
        }
        public DateTime HOPPMActionactualDate
        {
            get;
            set;
        }
        public DateTime HOPPMETA
        {
            get;
            set;
        }
        //


        public Int32 IsIkandiClient
        {
            get;
            set;
        }
        public Int32 FabQuality_ID1
        {
            get;
            set;
        }
        public Int32 FabQuality_ID2
        {
            get;
            set;
        }
        public Int32 FabQuality_ID3
        {
            get;
            set;
        }
        public Int32 FabQuality_ID4
        {
            get;
            set;
        }
        public Int32 FabQuality_ID5
        {
            get;
            set;
        }
        public Int32 FabQuality_ID6
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
        public string ExFactoryColor
        {
            get;
            set;
        }

        public string ExFactoryForeColor
        {
            get;
            set;
        }

        public string PCDForeColor
        {
            get;
            set;
        }

        public string PCDBackColor
        {
            get;
            set;
        }
        //Added By Ashish on 26/2/2015
        public string BIHBackColor
        {
            get;
            set;
        }
        public string BIHForColor
        {
            get;
            set;
        }

        public string StcBackColor
        {
            get;
            set;
        }
        public string StcForColor
        {
            get;
            set;
        }
        public string PatternBackColor
        {
            get;
            set;
        }
        public string PatternForColor
        {
            get;
            set;
        }

        //END
        //Added By Ashish  on 20/2/2015 for Color Code on MO

        public string StartETA1BackColor
        {
            get;
            set;
        }


        public string ENDETA1BackColor
        {
            get;
            set;
        }

        public string StartETA2BackColor
        {
            get;
            set;
        }

        public string ENDETA2BackColor
        {
            get;
            set;
        }

        public string StartETA3BackColor
        {
            get;
            set;
        }

        public string ENDETA3BackColor
        {
            get;
            set;
        }

        public string StartETA4BackColor
        {
            get;
            set;
        }
        public string StartETA5BackColor
        {
            get;
            set;
        }
        public string StartETA6BackColor
        {
            get;
            set;
        }
        public string ENDETA4BackColor
        {
            get;
            set;
        }
        public string ENDETA5BackColor
        {
            get;
            set;
        }
        public string ENDETA6BackColor
        {
            get;
            set;
        }


        public string StartETA1ForColor
        {
            get;
            set;
        }

        public string ENDETA1ForColor
        {
            get;
            set;
        }

        public string StartETA2ForColor
        {
            get;
            set;
        }

        public string ENDETA2ForColor
        {
            get;
            set;
        }

        public string StartETA3ForColor
        {
            get;
            set;
        }

        public string ENDETA3ForColor
        {
            get;
            set;
        }

        public string StartETA4ForColor
        {
            get;
            set;
        }
        public string StartETA5ForColor
        {
            get;
            set;
        }
        public string StartETA6ForColor
        {
            get;
            set;
        }

        public string ENDETA4ForColor
        {
            get;
            set;
        }
        public string ENDETA5ForColor
        {
            get;
            set;
        }
        public string ENDETA6ForColor
        {
            get;
            set;
        }

        public string Fabric1NameBackColor
        {
            get;
            set;
        }

        public string Fabric1NameForColor
        {
            get;
            set;
        }

        public string Fabric2NameBackColor
        {
            get;
            set;
        }

        public string Fabric2NameForColor
        {
            get;
            set;
        }

        public string Fabric3NameBackColor
        {
            get;
            set;
        }

        public string Fabric3NameForColor
        {
            get;
            set;
        }

        public string Fabric4NameBackColor
        {
            get;
            set;
        }
        public string Fabric5NameBackColor
        {
            get;
            set;
        }
        public string Fabric6NameBackColor
        {
            get;
            set;
        }
        public string Fabric4NameForColor
        {
            get;
            set;
        }
        public string Fabric5NameForColor
        {
            get;
            set;
        }
        public string Fabric6NameForColor
        {
            get;
            set;
        }

        public string BulkApproval1BackColor
        {
            get;
            set;
        }

        public string BulkApproval1ForColor
        {
            get;
            set;
        }
        public string BulkApproval2BackColor
        {
            get;
            set;
        }

        public string BulkApproval2ForColor
        {
            get;
            set;
        }
        public string BulkApproval3BackColor
        {
            get;
            set;
        }

        public string BulkApproval3ForColor
        {
            get;
            set;
        }
        public string BulkApproval4BackColor
        {
            get;
            set;
        }
        public string BulkApproval5BackColor
        {
            get;
            set;
        }
        public string BulkApproval6BackColor
        {
            get;
            set;
        }

        public string BulkApproval4ForColor
        {
            get;
            set;
        }
        public string BulkApproval5ForColor
        {
            get;
            set;
        }
        public string BulkApproval6ForColor
        {
            get;
            set;
        }
        public string TractStatus1ForColor
        {
            get;
            set;
        }
        public string TractStatus2ForColor
        {
            get;
            set;
        }
        public string TractStatus3ForColor
        {
            get;
            set;
        }

        public string TractStatus4ForColor
        {
            get;
            set;
        }
        public string TractStatus5ForColor
        {
            get;
            set;
        }
        public string TractStatus6ForColor
        {
            get;
            set;
        }
        public string Fabric1actionDate
        {
            get;
            set;
        }
        public string Fabric2actionDate
        {
            get;
            set;
        }
        public string Fabric3actionDate
        {
            get;
            set;
        }
        public string Fabric4actionDate
        {
            get;
            set;
        }
        public string Fabric5actionDate
        {
            get;
            set;
        }
        public string Fabric6actionDate
        {
            get;
            set;
        }

        // edit by surendra
        public string FabricAvgColor1
        {
            get;
            set;
        }
        public string FabricAvgColor2
        {
            get;
            set;
        }
        public string FabricAvgColor3
        {
            get;
            set;
        }
        public string FabricAvgColor4
        {
            get;
            set;
        }
        public string FabricAvgColor5
        {
            get;
            set;
        }
        public string FabricAvgColor6
        {
            get;
            set;
        }
        // end

        //END

        //Added By Ashish on 25/2/2015
        public string Percent1BackColor
        {
            get;
            set;
        }

        public string Percent1ForColor
        {
            get;
            set;
        }
        public string Percent2BackColor
        {
            get;
            set;
        }

        public string Percent2ForColor
        {
            get;
            set;
        }
        public string Percent3BackColor
        {
            get;
            set;
        }

        public string Percent3ForColor
        {
            get;
            set;
        }
        public string Percent4BackColor
        {
            get;
            set;
        }
        public string Percent5BackColor
        {
            get;
            set;
        }
        public string Percent6BackColor
        {
            get;
            set;
        }

        public string Percent4ForColor
        {
            get;
            set;
        }
        public string Percent5ForColor
        {
            get;
            set;
        }
        public string Percent6ForColor
        {
            get;
            set;
        }

        public string LinktypeForeColor
        {
            get;
            set;
        }

        public string LinktypeBackColor
        {
            get;
            set;
        }
        //updated  By sushil on 26/3/2015
        public string FitsPandingColor
        {
            get;
            set;
        }
        public string LinktypeForeColorforfitspending
        {
            get;
            set;
        }
        //Added By Ashish on 9/4/2015
        public string FitsSTCETABackColor
        {
            get;
            set;
        }
        public string FitsSTCETAForColor
        {
            get;
            set;
        }
        public string FitsPatternETABackColor
        {
            get;
            set;
        }
        public string FitsPatternETAForColor
        {
            get;
            set;
        }
        public string FitsCuttingETABackColor
        {
            get;
            set;
        }
        public string FitsCuttingETAForColor
        {
            get;
            set;
        }
        public string FitsProdETABackColor
        {
            get;
            set;
        }
        public string HandOverETABackColor
        {
            get;
            set;
        }
        public string PatternReadyETABackColor
        {
            get;
            set;
        }
        public string SampleSentETABackColor
        {
            get;
            set;
        }
        public string FitsCommentesETABackColor
        {
            get;
            set;
        }
        public string HandOverETAForeColor
        {
            get;
            set;
        }
        public string PatternReadyETAForeColor
        {
            get;
            set;
        }
        public string SampleSentETAForeColor
        {
            get;
            set;
        }
        public string FitsCommentesETAForeColor
        {
            get;
            set;
        }

        public string FitsProdETAForColor
        {
            get;
            set;
        }
        public string FitsHOPPMETABackColor
        {
            get;
            set;
        }
        public string FitsHOPPMETAForColor
        {
            get;
            set;
        }
        public string FitsTOPSentETABackColor
        {
            get;
            set;
        }
        public string FitsTOPSentETAForColor
        {
            get;
            set;
        }
        public string PPSampleSentBackColor
        {
            get;
            set;
        }
        public string PPSampleSentETABackColor
        {
            get;
            set;
        }


        public string TestReportsBackColor
        {
            get;
            set;
        }
        public string StrikeOfBackColor1
        {
            get;
            set;
        }
        public string StrikeOfBackColor2
        {
            get;
            set;
        }
        public string StrikeOfBackColor3
        {
            get;
            set;
        }
        public string StrikeOfBackColor4
        {
            get;
            set;
        }
        public string StrikeOfBackColor5
        {
            get;
            set;
        }
        public string StrikeOfBackColor6
        {
            get;
            set;
        }
        public string StrikeOfForeColor1
        {
            get;
            set;
        }
        public string StrikeOfForeColor2
        {
            get;
            set;
        }
        public string StrikeOfForeColor3
        {
            get;
            set;
        }
        public string StrikeOfForeColor4
        {
            get;
            set;
        }
        public string StrikeOfForeColor5
        {
            get;
            set;
        }
        public string StrikeOfForeColor6
        {
            get;
            set;
        }

        public string TestReportsForColor
        {
            get;
            set;
        }
        public string CDChartBackColor
        {
            get;
            set;
        }
        public string CDChartForColor
        {
            get;
            set;
        }



        //END
        //end updated  By sushil on 26/3/2015
        public string BlackToForeColor
        {
            get;
            set;
        }

        public string PricevariationColor
        {
            get;
            set;
        }
        public string AuditvariationColor
        {
            get;
            set;
        }
        public string CQDForeColor
        {
            get;
            set;
        }
        public string SummryColor
        {
            get;
            set;
        }

        //END
        //Added By Ashish on 29/28/2015
        public string stylenumberColor
        {
            get;
            set;
        }

        public int IsRiskTask
        {
            get;
            set;
        }

        public string SamOBValColor
        {
            get;
            set;
        }

        public int IsOBCreate
        {
            get;
            set;
        }

        public int IsFinalizeOB
        {
            get;
            set;
        }
        public int IsLinePlan
        {
            get;
            set;
        }
        public int LineCount
        {
            get;
            set;
        }

        //END
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



        public double WeeklyIkandi_amount
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
        public double Fabric1OrderAverage
        {
            get;
            set;
        }
        public DateTime OrdAvgDate1
        {
            get;
            set;
        }
        public DateTime OrdAvgDate2
        {
            get;
            set;
        }
        public DateTime OrdAvgDate3
        {
            get;
            set;
        }
        public DateTime OrdAvgDate4
        {
            get;
            set;
        }
        public DateTime OrdAvgDate5
        {
            get;
            set;
        }
        public DateTime OrdAvgDate6
        {
            get;
            set;
        }
        public DateTime CutAverageDate1
        {
            get;
            set;
        }
        public DateTime CutAverageDate2
        {
            get;
            set;
        }
        public DateTime CutAverageDate3
        {
            get;
            set;
        }
        public DateTime CutAverageDate4
        {
            get;
            set;
        }
        public DateTime CutAverageDate5
        {
            get;
            set;
        }
        public DateTime CutAverageDate6
        {
            get;
            set;
        }
        public int UnitOfAverage1
        {
            get;
            set;
        }
        public int UnitOfAverage2
        {
            get;
            set;
        }
        public int UnitOfAverage3
        {
            get;
            set;
        }
        public int UnitOfAverage4
        {
            get;
            set;
        }
        public int UnitOfAverage5
        {
            get;
            set;
        }
        public int UnitOfAverage6
        {
            get;
            set;
        }
        public double Fabric2OrderAverage
        {
            get;
            set;
        }
        public double Fabric1STCAverage
        {
            get;
            set;
        }
        public string FinalOrderFabric1
        {
            get;
            set;
        }
        public string FinalOrderFabric2
        {
            get;
            set;
        }
        public string FinalOrderFabric3
        {
            get;
            set;
        }
        public string FinalOrderFabric4
        {
            get;
            set;
        }
        public string FinalOrderFabric5
        {
            get;
            set;
        }
        public string FinalOrderFabric6
        {
            get;
            set;
        }
        //added by abhishek 21/9/2016
        public string FinalOrderFabric1_k
        {
            get;
            set;
        }
        public string FinalOrderFabric2_k
        {
            get;
            set;
        }
        public string FinalOrderFabric3_k
        {
            get;
            set;
        }
        public string FinalOrderFabric4_k
        {
            get;
            set;
        }
        public string FinalOrderFabric5_k
        {
            get;
            set;
        }
        public string FinalOrderFabric6_k
        {
            get;
            set;
        }





        public string FinalOrderFabric1_total
        {
            get;
            set;
        }
        public string FinalOrderFabric2_total
        {
            get;
            set;
        }
        public string FinalOrderFabric3_total
        {
            get;
            set;
        }
        public string FinalOrderFabric4_total
        {
            get;
            set;
        }

        //end 
        public string QuantityAvl1
        {
            get;
            set;
        }
        public string QuantityAvl2
        {
            get;
            set;
        }
        public string QuantityAvl3
        {
            get;
            set;
        }
        public string QuantityAvl4
        {
            get;
            set;
        }
        public string QuantityAvl5
        {
            get;
            set;
        }
        public string QuantityAvl6
        {
            get;
            set;
        }
        public string Fabric1Required_ToolTip
        {
            get;
            set;
        }
        public string Fabric2Required_ToolTip
        {
            get;
            set;
        }
        public string Fabric3Required_ToolTip
        {
            get;
            set;
        }
        public string Fabric4Required_ToolTip
        {
            get;
            set;
        }
        public string Fabric5Required_ToolTip
        {
            get;
            set;
        }
        public string Fabric6Required_ToolTip
        {
            get;
            set;
        }
        // New properties added here 
        public string Fabric1Required
        {
            get;
            set;
        }
        public string Fabric2Required
        {
            get;
            set;
        }
        public string Fabric3Required
        {
            get;
            set;
        }
        public string Fabric4Required
        {
            get;
            set;
        }
        public string Fabric5Required
        {
            get;
            set;
        }
        public string Fabric6Required
        {
            get;
            set;
        }
        // END
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
        public double Fabric5STCAverage
        {
            get;
            set;
        }
        public double Fabric6STCAverage
        {
            get;
            set;
        }
        public double CutWidth1
        {
            get;
            set;
        }
        public double CutWidth2
        {
            get;
            set;
        }
        public double CutWidth3
        {
            get;
            set;
        }
        public double CutWidth4
        {
            get;
            set;
        }
        public double CutWidth5
        {
            get;
            set;
        }
        public double CutWidth6
        {
            get;
            set;
        }
        public double Fabric3OrderAverage
        {
            get;
            set;
        }
        public double Fabric4OrderAverage
        {
            get;
            set;
        }
        public double Fabric5OrderAverage
        {
            get;
            set;
        }
        public double Fabric6OrderAverage
        {
            get;
            set;
        }

        public double Fabric3Quantity
        {
            get;
            set;
        }
        public string TotalSummary1
        {
            get;
            set;
        }
        public string Caption1
        {
            get;
            set;
        }
        public string Caption2
        {
            get;
            set;
        }
        public string Caption3
        {
            get;
            set;
        }
        public string Caption4
        {
            get;
            set;
        }
        public string Caption5
        {
            get;
            set;
        }
        public string Caption6
        {
            get;
            set;
        }
        public string TotalSummary2
        {
            get;
            set;
        }
        public string TotalSummary3
        {
            get;
            set;
        }
        public string TotalSummary4
        {
            get;
            set;
        }
        public string TotalSummary5
        {
            get;
            set;
        }
        public string TotalSummary6
        {
            get;
            set;
        }
        public double Fabric4Average
        {
            get;
            set;
        }

        public double Fabric4Quantity
        {
            get;
            set;
        }
        public bool ContractStatus
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
        public string FabricRemarks
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
        public string FitRemarks
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
        //Added By Ashish
        public string ProductionUnit
        {
            get;
            set;
        }
        //public int TotalCut
        //{
        //    get;
        //    set;
        //}
        //public string OverallCut
        //{
        //    get;
        //    set;
        //}
        //public int BalanceCut
        //{
        //    get;
        //    set;
        //}
        public int CutAvg
        {
            get;
            set;
        }
        public double DirectRepeat
        {
            get;
            set;
        }
        //public string BalancePercentCut
        //{
        //    get;
        //    set;
        //}
        //public int CuttingsheetID
        //{
        //    get;
        //    set;
        //}
        //public int CuttingDetailID
        //{
        //    get;
        //    set;
        //}
        ////
        //public string TotalCutIssued
        //{
        //    get;
        //    set;
        //}
        //public int overallCutIssued
        //{
        //    get;
        //    set;
        //}
        //public int BalanceCutIssued
        //{
        //    get;
        //    set;
        //}

        //Added By Ashish 

        public DateTime PcsIssuedETA
        {
            get;
            set;
        }

        public DateTime PcsIssuedEndETA
        {
            get;
            set;
        }
        public DateTime StitchStartETA
        {
            get;
            set;
        }
        public DateTime StitchEndETA
        {
            get;
            set;
        }
        public DateTime TempStichedStartETA
        {
            get;
            set;
        }
        public DateTime TempStichedEndETA
        {
            get;
            set;
        }
        //added by abhishek on 10/6/2015------------//
        public DateTime TempCutReadyEndETA
        {
            get;
            set;
        }


        public DateTime TempVAEndETA
        {
            get;
            set;
        }
        public DateTime TempPackedEndETA
        {
            get;
            set;
        }
        //public DateTime PackedStartETA
        //{
        //    get;
        //    set;
        //}


        //end by abhishek 10/6/2015-----------------//

        public DateTime EMBStartETA
        {
            get;
            set;
        }
        public DateTime EMBEndETA
        {
            get;
            set;
        }

        //END

        public string BalancePercentCutIssued
        {
            get;
            set;
        }

        //
        //public int TotalStitched
        //{
        //    get;
        //    set;
        //}
        //public int overallStitched
        //{
        //    get;
        //    set;
        //}
        //public int BalanceStitched
        //{
        //    get;
        //    set;
        //}
        //public int TodayStitched
        //{
        //    get;
        //    set;
        //}
        //change By Ashish on 24/2/2015
        //public string BalancePercentStitched
        //{
        //    get;
        //    set;
        //}

        //public string TotalStitchedIssued
        //{
        //    get;
        //    set;
        //}


        //public string overallStitchedIssued
        //{
        //    get;
        //    set;
        //}
        //public int OverStitchedIssued
        //{
        //    get;
        //    set;
        //}
        //public string BalanceStitchedIssued
        //{
        //    get;
        //    set;
        //}
        ////END
        //public string StitchedIssuedBallance
        //{
        //    get;
        //    set;
        //}

        //public int BalancePercentStitchedIssued
        //{
        //    get;
        //    set;
        //}
        // Added By Ravi kumar on 19/2/15 For ShipCheckbox
        public bool IsShiped
        {
            get;
            set;
        }
        public string CutAvgFile1
        {
            get;
            set;
        }
        public string CutAvgFile2
        {
            get;
            set;
        }
        public string CutAvgFile3
        {
            get;
            set;
        }
        public string CutAvgFile4
        {
            get;
            set;
        }
        public string QaUploadReport
        {
            get;
            set;
        }
        public string PackingListUploadPath
        {
            get;
            set;
        }
        public string ShipmentNo
        {
            get;
            set;
        }
        public string InvoiceNo
        {
            get;
            set;
        }
        public string BankRefNo
        {
            get;
            set;
        }
        public string InvoiceUploadPath
        {
            get;
            set;
        }
        public DateTime PaymentDueDate
        {
            get;
            set;
        }
        public string TotalPayment
        {
            get;
            set;
        }
        public string PendingPayment
        {
            get;
            set;
        }
        public int PPSample_ContractStatus
        {
            get;
            set;
        }




        // Added By Ashish on 12/3/15 For IsShpped Date

        // updated  By sushil on 26/3/2015
        public bool IsFitsPending
        {
            get;
            set;
        }
        //End updated  By sushil on 26/3/2015

        public DateTime IsShipedDate
        {
            get;
            set;
        }
        //END
        public bool IsShipedWrite
        {
            get;
            set;
        }
        public bool IsShipedRead
        {
            get;
            set;
        }
        public int ShippedQty
        {
            get;
            set;
        }
        public int Finish_80
        {
            get;
            set;
        }



        ///change By Ashish on 24/2/2015 for int to string
        public string TotalEmb
        {
            get;
            set;
        }

        public string overallEmb
        {
            get;
            set;
        }

        public string BalanceEmb
        {
            get;
            set;
        }
        //END
        public string BalancePercentEmp
        {
            get;
            set;
        }
        public string BalanceIssuedPercentEmp
        {
            get;
            set;
        }

        //
        public int TotalEmpIssued
        {
            get;
            set;
        }
        public int overallEmpIssued
        {
            get;
            set;
        }
        public int StitchingDetailID
        {
            get;
            set;
        }
        public int PcsPackedToday
        {
            get;
            set;
        }
        public int OverallPcsPacked
        {
            get;
            set;
        }
        public int OverallPcsStitched
        {
            get;
            set;
        }
        public int TotalPcsStitchedToday
        {
            get;
            set;
        }
        public DateTime ExpectedFinishDate
        {
            get;
            set;
        }
        public bool IsStitchingComplete
        {
            get;
            set;
        }

        public int BalanceEmbIssued
        {
            get;
            set;
        }
        public int BalanceEmpPercentIssued
        {
            get;
            set;
        }
        //change By Ashish on 24/2/2015 int to string 
        public string TotalPacked
        {
            get;
            set;
        }
        //END
        public int overallPacked
        {
            get;
            set;
        }
        //change By Ashish on 24/2/2015 int to string 
        public string BalancePacked
        {
            get;
            set;
        }
        //END
        public string BalancePercentPacked
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public string SectionName
        {
            get;
            set;
        }
        public string BasicSection
        {
            get;
            set;
        }
        public string StyleSection
        {
            get;
            set;
        }
        public string QtySection
        {
            get;
            set;
        }

        public string FabricSection
        {
            get;
            set;
        }
        public string AccessoriesSection
        {
            get;
            set;
        }
        public string FitsSection
        {
            get;
            set;
        }
        public string PCDSection
        {
            get;
            set;
        }
        public string ProductionSection
        {
            get;
            set;
        }
        public string DeliverySection
        {
            get;
            set;
        }




        //public string FabricSection
        //{
        //    get;
        //    set;
        //}
        //public string AccessoriesSection
        //{
        //    get;
        //    set;
        //}
        //public string FitsSection
        //{
        //    get;
        //    set;
        //}
        //public string PCDSection
        //{
        //    get;
        //    set;
        //}
        //public string ProductionSection
        //{
        //    get;
        //    set;
        //}
        //public string DeliverySection
        //{
        //    get;
        //    set;
        //}

        public string ColumnName
        {
            get;
            set;
        }
        //Added By Ashish on 27/3/2015
        public bool FilterSearchRead
        {
            get;
            set;
        }
        public bool FilterSearchWrite
        {
            get;
            set;
        }
        public bool FilterSelectioYearRead
        {
            get;
            set;
        }
        public bool FilterSelectioYearWrite
        {
            get;
            set;
        }
        public bool FilterFromRead
        {
            get;
            set;
        }
        public bool FilterFromWrite
        {
            get;
            set;
        }
        public bool FilterToRead
        {
            get;
            set;
        }
        public bool FilterToWrite
        {
            get;
            set;
        }
        public bool FilterGroupRead
        {
            get;
            set;
        }
        public bool FilterGroupWrite
        {
            get;
            set;
        }
        //
        public bool FilterBuyinghouseRead
        {
            get;
            set;
        }
        public bool FilterBuyinghouseWrite
        {
            get;
            set;
        }
        public bool FilterStatusFromRead
        {
            get;
            set;
        }
        public bool FilterStatusFromWrite
        {
            get;
            set;
        }

        public bool FilterStatusToRead
        {
            get;
            set;
        }
        public bool FilterStatusToWrite
        {
            get;
            set;
        }
        public bool FilterSortingRead
        {
            get;
            set;
        }
        public bool FilterSortingWrite
        {
            get;
            set;
        }
        //Added By Ashish on 8/4/2015
        public bool FilterClientRead
        {
            get;
            set;
        }
        public bool FilterClientWrite
        {
            get;
            set;
        }
        public bool FilterDepartmentRead
        {
            get;
            set;
        }
        public bool FilterDepartmentWrite
        {
            get;
            set;
        }
        public bool FilterUnitRead
        {
            get;
            set;
        }
        public bool FilterUnitWrite
        {
            get;
            set;
        }
        public bool FilterSalesViewRead
        {
            get;
            set;
        }
        public bool FilterSalesViewWrite
        {
            get;
            set;
        }
        //END
        //END
        //Added By Ashish on 3/3/2014
        public bool bSerialNo
        {
            get;
            set;
        }
        public bool bSerialNowrite
        {
            get;
            set;
        }

        public bool bStylelNo
        {
            get;
            set;
        }
        public bool bStyleNowrite
        {
            get;
            set;
        }
        public bool bLineNo
        {
            get;
            set;
        }
        public bool bLinewrite
        {
            get;
            set;
        }

        public bool bContractNo
        {
            get;
            set;
        }
        public bool bContractwrite
        {
            get;
            set;
        }
        public bool bCostingWeight
        {
            get;
            set;
        }
        public bool bCostingWeight_Permission
        {
            get;
            set;
        }
        public bool bBIPLPrice
        {
            get;
            set;
        }
        public bool bBIPLPricewrite
        {
            get;
            set;
        }
        public bool bIKANDIPriceGrossRead
        {
            get;
            set;
        }
        public bool bIKANDIPriceGrosswrite
        {
            get;
            set;
        }
        public bool bIKANDIPriceRead
        {
            get;
            set;
        }
        public bool bIKANDIPricewrite
        {
            get;
            set;
        }
        public bool bMarginRead
        {
            get;
            set;
        }
        public bool bMarginwrite
        {
            get;
            set;
        }
        public bool bBusinessRead
        {
            get;
            set;
        }
        public bool bBusinesswrite
        {
            get;
            set;
        }
        public bool bBusinessDescriptionRead
        {
            get;
            set;
        }
        public bool bBusinessDescriptionwrite
        {
            get;
            set;
        }
        public bool bDepartmentRead
        {
            get;
            set;
        }
        public bool bDepartmentwrite
        {
            get;
            set;
        }

        public bool bOrderDateRead
        {
            get;
            set;
        }
        public bool bOrderDatewrite
        {
            get;
            set;
        }
        public bool bQuantityRead
        {
            get;
            set;
        }
        public bool bQuantitywrite
        {
            get;
            set;
        }
        public bool bStatusRead
        {
            get;
            set;
        }
        public bool bLineAllocationRead
        {
            get;
            set;
        }
        public bool bLineAllocationwrite
        {
            get;
            set;
        }
        //abhishek 22/2/2016
        public bool ReadWriteReallocationLink
        {
            get;
            set;
        }
        public bool ReadReallocationLink
        {
            get;
            set;
        }

        // Shipping Module all narration for permission by surendra
        public bool PackingListRead
        {
            get;
            set;
        }
        public bool PackingListWrite
        {
            get;
            set;
        }
        public bool PackingListImageRead
        {
            get;
            set;
        }
        public bool PackingListImageWrite
        {
            get;
            set;
        }
        public bool ShipmentNoRead
        {
            get;
            set;
        }
        public bool ShipmentNoWrite
        {
            get;
            set;
        }
        public bool InvoiceRead
        {
            get;
            set;
        }
        public bool InvoiceWrite
        {
            get;
            set;
        }
        public bool InvoiceImageRead
        {
            get;
            set;
        }
        public bool InvoiceImageWrite
        {
            get;
            set;
        }
        public bool BankRefrenceNoRead
        {
            get;
            set;
        }
        public bool BankRefrenceNoWrite
        {
            get;
            set;
        }
        public bool PendingPaymentNarrationRead
        {
            get;
            set;
        }
        public bool PendingPaymentNarrationWrite
        {
            get;
            set;
        }
        public bool PaymentDueDateRead
        {
            get;
            set;
        }
        public bool OutHouseAllocationRead
        {
            get;
            set;
        }
        public bool bPlanedForDate
        {
            get;
            set;
        }
        public bool bPlanedDropDown
        {
            get;
            set;
        }
        public bool bSharingMode_Change
        {
            get;
            set;
        }
        public bool IsContractHoldWrite
        {
            get;
            set;
        }
        public bool bPlanedDropDown_Permission
        {
            get;
            set;
        }
        public bool bPlanedInputDate
        {
            get;
            set;
        }
        public bool bPlanedInputDate_Permission
        {
            get;
            set;
        }


        public bool OutHouseAllocationWrite
        {
            get;
            set;
        }

        public bool PaymentDueDateWrite
        {
            get;
            set;
        }


        //----------end-----------------------
        //end abhishek 22/2/2016
        public bool ProductionPlanRead
        {
            get;
            set;
        }
        public bool ProductionPlanWrite
        {
            get;
            set;
        }
        public bool bStatuswrite
        {
            get;
            set;
        }
        public bool bExFactoryRead
        {
            get;
            set;
        }
        public bool bExFactorywrite
        {
            get;
            set;
        }
        public bool bShipmentOfferDateRead
        {
            get;
            set;
        }
        public bool bShipmentOfferDatewrite
        {
            get;
            set;
        }
        public bool bPreExFactoryRead
        {
            get;
            set;
        }
        public bool bPreExFactorywrite
        {
            get;
            set;
        }

        public bool bDCDateRead
        {
            get;
            set;
        }
        public bool bDCDatewrite
        {
            get;
            set;
        }
        public bool bModeRead
        {
            get;
            set;
        }
        public bool bModewrite
        {
            get;
            set;
        }
        public bool bMDARead
        {
            get;
            set;
        }
        public bool bMDAwrite
        {
            get;
            set;
        }
        public bool bBasicInfoRemarkRead
        {
            get;
            set;
        }
        public bool bBasicInfoRemarkwrite
        {
            get;
            set;
        }
        //Added By Ashish on 28/3/2015
        public bool bPriceVAriationRead
        {
            get;
            set;
        }
        public bool bPriceVAriationkwrite
        {
            get;
            set;
        }

        public bool bPOPendingRead
        {
            get;
            set;
        }
        public bool bPOPendingkwrite
        {
            get;
            set;
        }

        //

        public bool FBIHDateRead
        {
            get;
            set;
        }
        public bool FBIHDateWrite
        {
            get;
            set;
        }
        public bool FDeptDateRead
        {
            get;
            set;
        }
        public bool FDeptDateWrite
        {
            get;
            set;
        }
        public bool FQualityRead
        {
            get;
            set;
        }
        public bool FQualityWrite
        {
            get;
            set;
        }
        public bool FOrdRead
        {
            get;
            set;
        }

        public bool FOrdWrite
        {
            get;
            set;
        }
        public bool FRecdRead
        {
            get;
            set;
        }
        public bool FRecdWrite
        {
            get;
            set;
        }
        public bool FFabricRemarkRead
        {
            get;
            set;
        }
        public bool FFabricRemarkWrite
        {
            get;
            set;
        }
        public bool FFabricTrackingRead
        {
            get;
            set;
        }
        public bool FsummaryRead
        {
            get;
            set;
        }


        public bool FsummaryWrite
        {
            get;
            set;
        }
        public bool FPerInhouseRead
        {
            get;
            set;
        }
        public bool FPerInhouseWrite
        {
            get;
            set;
        }
        public bool FFabTotalRead
        {
            get;
            set;
        }
        public bool FFabTotalWrite
        {
            get;
            set;
        }
        public bool FFabricTrackingWrite
        {
            get;
            set;
        }
        //Added By Ashish on 20/3/2015
        public bool FFabStartETARead
        {
            get;
            set;
        }
        public bool FFabStartETAWrite
        {
            get;
            set;
        }

        public bool FFabEndETARead
        {
            get;
            set;
        }
        public bool FFabEndETAWrite
        {
            get;
            set;
        }

        public bool FFabSummaryRead
        {
            get;
            set;
        }
        public bool FFabSummaryWrite
        {
            get;
            set;
        }

        //END
        public static bool AccQualityRead
        {
            get;
            set;
        }
        public static bool AccQualityWrite
        {
            get;
            set;
        }
        public static bool AccApprovedOnRead
        {
            get;
            set;
        }
        public static bool AccApprovedOnWrite
        {
            get;
            set;
        }
        public static bool AccRecdRead
        {
            get;
            set;
        }
        public static bool AccRecdWrite
        {
            get;
            set;
        }
        public static bool AccTotalRead
        {
            get;
            set;
        }
        public static bool AccTotalWrite
        {
            get;
            set;
        }
        public static bool AccAvilableOnRead
        {
            get;
            set;
        }
        public static bool AccAvilableOnWrite
        {
            get;
            set;
        }
        public static bool AccRemarkRead
        {
            get;
            set;
        }
        public static bool AccRemarkWrite
        {
            get;
            set;
        }
        //Added By Ashish on 20/3/2015
        public static bool AccessoriesETARead
        {
            get;
            set;
        }
        public static bool AccessoriesETAWrite
        {
            get;
            set;
        }
        //END
        public bool FitsStcRead
        {
            get;
            set;
        }
        public bool FitsStcWrite
        {
            get;
            set;
        }
        public bool FitsTgtPlannedDateRead
        {
            get;
            set;
        }
        public bool FitsTgtPlannedDateWrite
        {
            get;
            set;
        }
        public bool FitsPlannedDateRead
        {
            get;
            set;
        }
        public bool FitsPlannedDateWrite
        {
            get;
            set;
        }
        public bool FitsTgtDateRead
        {
            get;
            set;
        }
        public bool FitsTgtDateWrite
        {
            get;
            set;
        }
        public bool FitsStatusRead
        {
            get;
            set;
        }
        public bool FitsStatusWrite
        {
            get;
            set;
        }
        public bool FitsPCDRead
        {
            get;
            set;
        }
        public bool FitsPCDWrite
        {
            get;
            set;
        }
        public bool FitsSTCSamRead
        {
            get;
            set;
        }
        public bool FitsSTCSamWrite
        {
            get;
            set;
        }
        public bool FitsOrderSamRead
        {
            get;
            set;
        }
        public bool FitsOrderSamWrite
        {
            get;
            set;
        }
        public bool FitsLineRead
        {
            get;
            set;
        }
        public bool FitsLineWrite
        {
            get;
            set;
        }
        public bool FitsDaysRead
        {
            get;
            set;
        }
        public bool FitsDaysWrite
        {
            get;
            set;
        }

        public bool FitsPatternSampleDateRead
        {
            get;
            set;
        }
        public bool FitsPatternSampleDateWrite
        {
            get;
            set;
        }
        public bool FitsCuttingsheetRecvedRead
        {
            get;
            set;
        }
        public bool FitsCuttingsheetRecvedWrite
        {
            get;
            set;
        }
        public bool FitsProductionFileRead
        {
            get;
            set;
        }
        public bool FitsProductionFileWrite
        {
            get;
            set;
        }
        //
        public bool FitsQAStatusRead
        {
            get;
            set;
        }
        public bool FitsQAStatusWrite
        {
            get;
            set;
        }
        public bool FitsRemarkRead
        {
            get;
            set;
        }
        public bool FitsRemarkWrite
        {
            get;
            set;
        }
        //Added By Ashish on 20/3/2015
        public bool FitsPatternRead
        {
            get;
            set;
        }
        public bool FitsPatternkWrite
        {
            get;
            set;
        }
        public bool FitsCuttingkRead
        {
            get;
            set;
        }
        public bool FitsCuttingkWrite
        {
            get;
            set;
        }
        public bool FitsProdFileRead
        {
            get;
            set;
        }
        public bool FitsProdFileWrite
        {
            get;
            set;
        }
        public bool FitsHOPPMRead
        {
            get;
            set;
        }
        public bool FitsHOPPMWrite
        {
            get;
            set;
        }
        public bool FitsTOPSentRead
        {
            get;
            set;
        }
        public bool FitsTOPSentWrite
        {
            get;
            set;
        }
        public bool FitsLKMRead
        {
            get;
            set;
        }
        public bool FitsLKMWrite
        {
            get;
            set;
        }
        public bool FitsOBRead
        {
            get;
            set;
        }
        public bool FitsOBWrite
        {
            get;
            set;
        }

        //
        public bool FitsSTCETARead
        {
            get;
            set;
        }
        public bool FitsSTCETAWrite
        {
            get;
            set;
        }
        public bool FitsPatternETARead
        {
            get;
            set;
        }
        public bool FitsPatternETAWrite
        {
            get;
            set;
        }


        public bool FitsCuttingETARead
        {
            get;
            set;
        }
        public bool FitsCuttingETAWrite
        {
            get;
            set;
        }
        public bool FitsProdFileETARead
        {
            get;
            set;
        }
        public bool FitsProdFileETAWrite
        {
            get;
            set;
        }
        public bool FitsHOPPMETARead
        {
            get;
            set;
        }
        public bool FitsHOPPMETAWrite
        {
            get;
            set;
        }
        public bool FitsTOPSentETARead
        {
            get;
            set;
        }
        public bool FitsTOPSentETAWrite
        {
            get;
            set;
        }


        public bool FitsStcTargetDateRead
        {
            get;
            set;
        }
        public bool FitsStcTargetDateWrite
        {
            get;
            set;
        }
        public bool FitsStcActualDateRead
        {
            get;
            set;
        }
        public bool FitsStcActualDateWrite
        {
            get;
            set;
        }

        public bool FitsPatternTargetDateRead
        {
            get;
            set;
        }
        public bool FitsPatternTargetDateWrite
        {
            get;
            set;
        }
        public bool FitsPatternActualDateRead
        {
            get;
            set;
        }
        public bool FitsPatternActualDateWrite
        {
            get;
            set;
        }

        public bool FitsCuttingTargetDateRead
        {
            get;
            set;
        }
        public bool FitsCuttingTargetDateWrite
        {
            get;
            set;
        }
        public bool FitsCuttingActualDateRead
        {
            get;
            set;
        }
        public bool FitsCuttingActualDateWrite
        {
            get;
            set;
        }
        public bool FitsProdTargetDateRead
        {
            get;
            set;
        }
        public bool FitsProdTargetDateWrite
        {
            get;
            set;
        }
        public bool FitsProdActualDateRead
        {
            get;
            set;
        }
        public bool FitsProdActualDateWrite
        {
            get;
            set;
        }

        public bool FitsHOPPMTargetDateRead
        {
            get;
            set;
        }
        public bool FitsHOPPMTargetDateWrite
        {
            get;
            set;
        }
        public bool FitsHOPPMActualDateRead
        {
            get;
            set;
        }
        public bool FitsHOPPMActualDateWrite
        {
            get;
            set;
        }

        public bool FitsTopSentTargetDateRead
        {
            get;
            set;
        }
        public bool FitsTopSentMTargetDateWrite
        {
            get;
            set;
        }
        public bool FitsTopSentMActualDateRead
        {
            get;
            set;
        }
        public bool FitsTopSentMActualDateWrite
        {
            get;
            set;
        }
        //
        //END
        public bool FitsETADateRead
        {
            get;
            set;
        }
        public bool FitsETADateWrite
        {
            get;
            set;
        }
        public bool FitsCostingSAMRead
        {
            get;
            set;
        }
        public bool FitsCostingSAMWrite
        {
            get;
            set;
        }
        public bool PUnitRead
        {
            get;
            set;
        }
        public bool PUnitWrite
        {
            get;
            set;
        }
        public bool PTotalRead
        {
            get;
            set;
        }
        public bool PTotalWrite
        {
            get;
            set;
        }
        public bool POverallRead
        {
            get;
            set;
        }
        public bool POverallWrite
        {
            get;
            set;
        }
        public bool PBalanceRead
        {
            get;
            set;
        }
        public bool PBalanceWrite
        {
            get;
            set;
        }
        public bool PProductionRemarkRead
        {
            get;
            set;
        }
        public bool PProductionsRemarkWrite
        {
            get;
            set;
        }
        //======================================
        #region Gajendra Production Permission
        public static List<Int64> FactoryID
        {
            get;
            set;
        }
        public static bool PCutTodayRead
        {
            get;
            set;
        }
        public static bool PCutTodayWrite
        {
            get;
            set;
        }
        public static bool PCutReadyTodayRead
        {
            get;
            set;
        }
        public static bool PCutReadyTodayWrite
        {
            get;
            set;
        }
        public static bool PStitchTodayRead
        {
            get;
            set;
        }
        public static bool PStitchTodayWrite
        {
            get;
            set;
        }
        public static bool PFinishTodayRead
        {
            get;
            set;
        }
        public static bool PFinishTodayWrite
        {
            get;
            set;
        }
        public static bool PVATodayRead
        {
            get;
            set;
        }
        public static bool PVATodayWrite
        {
            get;
            set;
        }
        public static bool PCutTotalRead
        {
            get;
            set;
        }
        public static bool PCutTotalWrite
        {
            get;
            set;
        }
        public static bool PCutReadyTotalRead
        {
            get;
            set;
        }
        public static bool PCutReadyTotalWrite
        {
            get;
            set;
        }
        public static bool PStitchTotalRead
        {
            get;
            set;
        }
        public static bool PStitchTotalWrite
        {
            get;
            set;
        }
        public static bool PFinishTotalRead
        {
            get;
            set;
        }
        public static bool PFinishTotalWrite
        {
            get;
            set;
        }
        public static bool PVATotalRead
        {
            get;
            set;
        }
        public static bool PVATotalWrite
        {
            get;
            set;
        }
        public bool PlblCMTActRead
        {
            get;
            set;
        }
        public bool PlblCMTActWrite
        {
            get;
            set;
        }

        public bool PlblCMTTgtRead
        {
            get;
            set;
        }
        public bool PlblCMTTgtWrite
        {
            get;
            set;
        }

        public bool PlblCostedRead
        {
            get;
            set;
        }
        public bool PlblCostedWrite
        {
            get;
            set;
        }
        public bool PlblProfitLossRead
        {
            get;
            set;
        }
        public bool PlblProfitLossWrite
        {
            get;
            set;
        }
        public bool PlblActualEffRead
        {
            get;
            set;
        }
        public bool PlblActualEffWrite
        {
            get;
            set;
        }
        public bool PlblTargetEffRead
        {
            get;
            set;
        }
        public bool PlblTargetEffWrite
        {
            get;
            set;
        }
        public bool PlblBERead
        {
            get;
            set;
        }
        public bool PlblBEWrite
        {
            get;
            set;
        }
        #endregion
        //==========================================
        public bool PCDOrderedSAMRead
        {
            get;
            set;
        }
        public bool PCDOrderedSAMWrite
        {
            get;
            set;
        }
        public bool PCDStcSAMRead
        {
            get;
            set;
        }
        public bool PCDStcSAMWrite
        {
            get;
            set;
        }
        public bool PCDLinesRead
        {
            get;
            set;
        }
        public bool PCDLinesWrite
        {
            get;
            set;
        }
        public bool PCDDaysRead
        {
            get;
            set;
        }
        public bool PCDDaysWrite
        {
            get;
            set;
        }

        //abhishek 
        public bool PeekFileUploadRead
        {
            get;
            set;
        }
        public bool PeekFileUploadWrite
        {
            get;
            set;
        }


        public bool DExFactoryRead
        {
            get;
            set;
        }
        public bool DExFactoryWrite
        {
            get;
            set;
        }
        public bool DShipmentOfferDateRead
        {
            get;
            set;
        }
        public bool DShipmentOfferDateWrite
        {
            get;
            set;
        }
        public bool DdcDateRead
        {
            get;
            set;
        }
        public bool DdcDateWrite
        {
            get;
            set;
        }
        public bool DModeRead
        {
            get;
            set;
        }
        public bool DModeWrite
        {
            get;
            set;
        }
        public bool Qty
        {
            get;
            set;
        }
        public bool Qtywrite
        {
            get;
            set;
        }

        //Added By Ashish on 25/2/14





        public bool PatternSampleRead
        {
            get;
            set;
        }
        public bool PatternSampleWrite
        {
            get;
            set;
        }

        public bool ProductionFileRead
        {
            get;
            set;
        }
        public bool ProductionFileWrite
        {
            get;
            set;
        }
        //END
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
        //Added by abhishek on 8/1/2015
        public DateTime BulkAccsesoryTarget
        {
            get;
            set;
        }

        public DateTime STCtargetsDate
        {
            get;
            set;
        }
        public DateTime PatternSampleTarget
        {
            get;
            set;
        }
        public DateTime CuttingTarget
        {
            get;
            set;
        }
        public DateTime ProductionFileTarget
        {
            get;
            set;
        }
        public DateTime PPSampleTgtDate
        {
            get;
            set;
        }

        public DateTime HOPPMTargetETA
        {
            get;
            set;
        }
        public DateTime TOPTargetETA
        {
            get;
            set;
        }
        public DateTime TestReportTargetETA
        {
            get;
            set;
        }
        public DateTime PCDTargetETA
        {
            get;
            set;
        }
        public DateTime EXFactoryTargetETA
        {
            get;
            set;
        }
        //public DateTime EXFactoryPlannedTargetETA
        //{
        //    get;
        //    set;
        //}
        //End by abhishek on 8/1/2015
        //Added By Ashish on 19/2/2015
        public DateTime BulkCuttingTarget
        {
            get;
            set;
        }



        //END
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

        // Sanjeev Vishwkarma on 11/01/2022
        public int IsOldOrder
        {
            get;
            set;
        }

    }

    public class AccesoriesDetails : BaseEntity
    {
        public int AccesoriesWorkingDetailsID
        {
            get;
            set;
        }
    }
    public class PermissionDetails : MOOrderDetails
    {
        public string Section
        {
            get;
            set;
        }
        public string Column
        {
            get;
            set;
        }
        public bool? PermissionRead
        {
            get;
            set;
        }
        public bool? PermissionWrite
        {
            get;
            set;
        }


    }
}


