using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class Stitching : BaseEntity
    {
        public List<StitchingHistory> StitchingHistory
        {
            get;
            set;
        }
        public List<StitchingDetail> StitchingDetails
        {
            get;
            set;
        }
        public List<BottleNeck> BottleNeck
        {
            get;
            set;
        }
        public List<StitchQC> StitchQC
        {
            get;
            set;
        }
    }

    public class StitchingHistory : BaseEntity
    {
        public int StitchingHistoryID
        {
            get;
            set;
        }

        public int OrderDetailID
        {
            get;
            set;
        }

        public int Quantity
        {
            get;
            set;
        }

        public int TotalQuantity
        {
            get;
            set;
        }
        public string Floor
        {
            get;
            set;
        }

        public string Line
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }

        public bool IsStitchingComplete
        {
            get;
            set;
        }

        public int PercentagePcsStitched
        {
            get;
            set;
        }

        public DateTime ExpectedFinishDate
        {
            get;
            set;
        }

    }

    public class StitchingDetail : OrderDetail
    {
        public int ID
        {
            get;
            set;
        }

        public int CuttingReceived
        {
            get;
            set;
        }

        public double CuttingPending
        {
            get;
            set;

        }

        public int TotalPcsStitchedToday
        {
            get;
            set;
        }

        public int OverallPcsStitched
        {
            get;
            set;
        }

        public int BalOnMach
        {
            get
            {
                return CuttingReceived - OverallPcsStitched;
            }

        }

        public double OrderQtyBal
        {
            get;
            set;

        }

        public int PcsSent
        {
            get;
            set;
        }

        public int PcsReceived
        {
            get;
            set;
        }

        public int PcsReceivedPack
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

        public double PercentageOverallPcsStitched
        {
            get;
            set;
        }

        public double PercentageOverallPcsPacked
        {
            get;
            set;
        }

        public int BalInPack
        {
            get
            {
                return PcsReceivedPack - OverallPcsPacked;
            }

        }

        public double OrderQtyBalPck
        {
            get;
            set;

        }

        public string ProdRemarks
        {
            get;
            set;
        }
        public DateTime ExpectedFinishDate
        {
            get;
            set;
        }

        public int IsStitchingComplete
        {
            get;
            set;
        }        
        public int SlotId
        {
            get;
            set;
        }
        public string SlotDate
        {
            get;
            set;
        }
        public int LinePlanningID
        {
            get;
            set;
        }
        public int LineNo
        {
            get;
            set;
        }
        public int SlotPass
        {
            get;
            set;
        }
        public int SlotAlt
        {
            get;
            set;
        }
        public int ActualOB
        {
            get;
            set;
        }
        public int cot
        {
            get;
            set;
        }
        public int checkRequiredActualOb
        {
            get;
            set;
        }
        public bool Sequenceframe
        {
            get;
            set;
        }

        public int PeakCapecity
        {
            get;
            set;
        }
        public int PeakOB
        {
            get;
            set;
        }
        public int Efficiency
        {
            get;
            set;
        }
        public int Pcs
        {
            get;
            set;
        }
        public bool IsStitched
        {
            get;
            set;
        }
        public bool IsDayClosed
        {
            get;
            set;
        }
        public bool IsHalfStitch
        {
            get;
            set;
        }
        public double AvailMins
        {
            get;
            set;
        }
        public double TargetEarnedMins
        {
            get;
            set;
        }
        public double LinePlanningSAM
        {
            get;
            set;
        }
        public int IsAnyHalfStitch
        {
            get;
            set;
        }
        public string StitchRemark
        {
            get;
            set;
        }
        public int ZeroProductvity
        {
            get;
            set;
        }
        public int SlotClose
        {
            get;
            set;
        }
        public int FinishingPass
        {
            get;
            set;
        }
        public int FinishingOB
        {
            get;
            set;
        }
        public bool ZeroProductivity_Finish
        {
            get;
            set;
        }
        public bool MarkAsFinishedPacked
        {
            get;
            set;
        }
        public int ActTCOB
        {
            get;
            set;
        }
        public int ActPressOB
        {
            get;
            set;
        }
        public int PeakCapTotal
        {
            get;
            set;
        }
        public int PeakCapTC
        {
            get;
            set;
        }
        public int PeakCapPress
        {
            get;
            set;
        }
        public int PeakOB_Finish
        {
            get;
            set;
        }
        public int PeakTCOB
        {
            get;
            set;
        }
        public int PeakPressOB
        {
            get;
            set;
        }       
        public int ClusterID 
        {
            get;
            set;
        }
        public int FrameStyleId
        {
            get;
            set;
        }
        public int TargetQty
        {
            get;
            set;
        }        
        public int LineManId
        {
            get;
            set;
        }
        public int Slot1Stitch
        {
            get;
            set;
        }       
        public int Slot2Stitch
        {
            get;
            set;
        }
        public int Slot3Stitch
        {
            get;
            set;
        }
        public int Slot4Stitch
        {
            get;
            set;
        }
        public int Slot5Stitch
        {
            get;
            set;
        }
        public int Slot6Stitch
        {
            get;
            set;
        }
        public int Slot7Stitch
        {
            get;
            set;
        }
        public int Slot8Stitch
        {
            get;
            set;
        }
        public int Slot9Stitch
        {
            get;
            set;
        }
        public int Slot10Stitch
        {
            get;
            set;
        }
        public int Slot11Stitch
        {
            get;
            set;
        }
        public int Slot12Stitch
        {
            get;
            set;
        }
        public int Slot1Finish
        {
            get;
            set;
        }        
        public int Slot2Finish
        {
            get;
            set;
        }
        public int Slot3Finish
        {
            get;
            set;
        }
        public int Slot4Finish
        {
            get;
            set;
        }
        public int Slot5Finish
        {
            get;
            set;
        }
        public int Slot6Finish
        {
            get;
            set;
        }
        public int Slot7Finish
        {
            get;
            set;
        }
        public int Slot8Finish
        {
            get;
            set;
        }
        public int Slot9Finish
        {
            get;
            set;
        }
        public int Slot10Finish
        {
            get;
            set;
        }
        public int Slot11Finish
        {
            get;
            set;
        }
        public int Slot12Finish
        {
            get;
            set;
        }

        public bool Slot1ZeroProductivity
        {
            get;
            set;
        }
        public bool Slot2ZeroProductivity
        {
            get;
            set;
        }
        public bool Slot3ZeroProductivity
        {
            get;
            set;
        }
        public bool Slot4ZeroProductivity
        {
            get;
            set;
        }
        public bool Slot5ZeroProductivity
        {
            get;
            set;
        }
        public bool Slot6ZeroProductivity
        {
            get;
            set;
        }
        public bool Slot7ZeroProductivity
        {
            get;
            set;
        }
        public bool Slot8ZeroProductivity
        {
            get;
            set;
        }
        public bool Slot9ZeroProductivity
        {
            get;
            set;
        }
        public bool Slot10ZeroProductivity
        {
            get;
            set;
        }
        public bool Slot11ZeroProductivity
        {
            get;
            set;
        }
        public bool Slot12ZeroProductivity
        {
            get;
            set;
        }
        public DateTime SlotCreateDate
        {
            get;
            set;
        }
        public double StitchSAM
        {
            get;
            set;
        }
        public int QCLineManID
        {
            get;
            set;
        }
    }

    [Serializable]
    public class BottleNeck
    {
        public int OBSectionId
        {
            get;
            set;
        }
        public string OBSectionName
        {
            get;
            set;
        }
        public int OperationId
        {
            get;
            set;
        }
        public string FactoryWorkSpace
        {
            get;
            set;
        }
        public int OrderDetailId
        {
            get;
            set;
        }
        public int LinePlanningId
        {
            get;
            set;
        }
        public bool IsBottleNeck
        {
            get;
            set;
        }
        public int DumpPcs
        {
            get;
            set;
        }
        public int TgtAgrdQuantity
        {
            get;
            set;
        }
        public int PerHrPcs
        {
            get;
            set;
        }
        public int SlotId
        {
            get;
            set;
        }
        public int BottleNeckId
        {
            get;
            set;
        }
        public string FactoryWorkSpace_Auto
        {
          get;
          set;
        }
    }

    public class StitchQC : BottleNeck
    {
        public int PcsChecked
        {
            get;
            set;
        }
        public int PcsFailed
        {
            get;
            set;
        }
        public string FaultCode
        {
            get;
            set;
        }
        public int FaultCount
        {
            get;
            set;
        }
        public int FMFI
        {
            get;
            set;
        }
        public int FMFI_Decision
        {
            get;
            set;
        }
        public int QCId
        {
            get;
            set;
        }
        public string FactoryQCName
        {
            get;
            set;
        }
        public int QCSlotWiseFaultsId
        {
            get;
            set;
        }
        public int ClusterId
        {
            get;
            set;
        }

    }

    public class LinePlan : OrderDetail
    {
        public int UnitId
        {
            get;
            set;
        }
        public int FloorNoId
        {
            get;
            set;
        }
        public int LineNo
        {
            get;
            set;
        }
        public double Sam
        {
            get;
            set;
        }
        public int OB
        {
            get;
            set;
        }
        public int NewOB
        {
            get;
            set;
        }

        public int LinePlanFrameId
        {
            get;
            set;
        }

        public int CombinedFrameId
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get;
            set;
        }

        public int StartSlot
        {
            get;
            set;
        }

        public int ContractQty
        {
            get;
            set;
        }

        public int UnitQty
        {
            get;
            set;
        }
        public int LineQty
        {
            get;
            set;
        }
        public int StichedQty
        {
            get;
            set;
        }
        public bool IsHalfStitched
        {
            get;
            set;
        }
        public int SeqFrameId
        {
            get;
            set;
        }
        public bool IsParallel
        {
            get;
            set;
        }
        public int TotalQty
        {
            get;
            set;
        }
        public int SamStyleId
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }

    }
}
