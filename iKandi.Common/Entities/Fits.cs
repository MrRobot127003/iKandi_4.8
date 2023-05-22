using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class Fits
    {
        public Int32 Id
        {
            get;
            set;
        }

        public Style Style
        {
            get;
            set;
        }

        ////this is to be commented
        //public int StyleNumber
        //{
        //    get;
        //    set;
        //}

        public string StyleCodeVersion
        {
            get;
            set;
        }

        public string StyleCode
        {
            get;
            set;
        }


        public String SpecsURL
        {
            get;
            set;
        }

        public DateTime SpecsUploadTargetDate
        {
            get;
            set;
        }


        public DateTime SpecsUploadDate
        {
            get;
            set;
        }

        public DateTime SampleTrackingDate
        {
            get;
            set;
        }

        public ClientDepartment Department
        {
            get;
            set;
        }

        public Boolean IsStcApproved
        {
            get;
            set;
        }
       
        // end
        

        public String Comments
        {
            get;
            set;
        }

        public String FilePath
        {
            get;
            set;
        }

        public List<FitsTrack> FitsTrack
        {
            get;
            set;
        }

        public DateTime SealDate
        {
            get;
            set;
        }

        public string FitsStyleCodeDropdownValue
        {
            get;
            set;
        }
        public Boolean IsReUse
        {
            get;
            set;
        }

        public List<SamplePattern> SamplePattern
        {
            get;
            set;
        }
        public string Fitstatus_ManageOrder
        {
            get;
            set;
        }
    }

    public class FitsTrack
    {
        public Int32 Id
        {
            get;
            set;
        }

        public String CommentsSentFor
        {
            get;
            set;
        }

        public DateTime NextPlannedDate
        {
            get;
            set;
        }

        public Boolean RequiredSample
        {
            get;
            set;
        }

        public Boolean AcknowledgeTick
        {
            get;
            set;
        }

        public String FilePath
        {
            get;
            set;
        }

        public String BiplFilePath
        {
            get;
            set;
        }

        public String PlanningFor
        {
            get;
            set;
        }

        public DateTime PlannedDispatchDate
        {
            get;
            set;
        }

        public DateTime ActualDispatchDate
        {
            get;
            set;
        }

        public DateTime SuggestedFitDate
        {
            get;
            set;
        }

        public Fits Fits
        {
            get;
            set;
        }

        public DateTime AckDate
        {
            get;
            set;
        }

        public DateTime fitRequestedOn
        {
            get;
            set;
        }

    }

    public class GarmentTesting
    {
        public Int32 Id
        {
            get;
            set;
        }

        public OrderDetail OrderDetail
        {
            get;
            set;
        }

        public DateTime TestingCompletionDate
        {
            get;
            set;
        }

        public DateTime ReportCompletionDate
        {
            get;
            set;
        }

        public Boolean Status
        {
            get;
            set;
        }

        public List<GarmentTestingUploadedReport> GarmentTestingUploadedReport
        {
            get;
            set;
        }

        public List<BulkTestingUploadedReport> BulkTestingUploadedReport
        {
            get;
            set;
        }

    }

    public class GarmentTestingUploadedReport
    {
        public Int32 Id
        {
            get;
            set;
        }

        public String UploadedReportFilePath
        {
            get;
            set;
        }

        public GarmentTesting GarmentTesting
        {
            get;
            set;
        }
    }

    public class BulkTestingUploadedReport : GarmentTestingUploadedReport
    {
    }

    public class SealerPending
    {
        public Int32 StyleId
        {
            get;
            set;
        }

        public string StyleNumber
        {
            get;
            set;
        }

        public Int32 ClientDepartmentId
        {
            get;
            set;
        }

        public String RemarksBIPL
        {
            get;
            set;
        }

        public String RemarksIKANDI
        {
            get;
            set;
        }
    }

    public class SamplePattern
    {
        public int CADMasterRoleID
        {
            get;
            set;
        }
        public string MasterName
        {
            get;
            set;
        }

        public int Styleid
        {
            get;
            set;
        }
        public string StyleNumber
        {
            get;
            set;
        }

        public DateTime CreatedOn
        {
            get;
            set;
        }

        public string Fabric
        {
            get;
            set;
        }

        public string FabricDetails
        {
            get;
            set;
        }

        public string SketchUrl
        {
            get;
            set;
        }

        public string Status
        {
            get;
            set;
        }
        public string ClientName
        {
            get;
            set;
        }
        public string DeptName
        {
            get;
            set;
        }
        public string PD_MarchentName
        {
            get;
            set;
        }
        public string AcountMgrName
        {
            get;
            set;
        }
        public DateTime FitsCommentDate
        {
            get;
            set;
        }

        public DateTime AllocationDate
        {
            get;
            set;
        }

        public DateTime StcEta
        {
            get;
            set;
        }     

        public DateTime AckDate
        {
            get;
            set;
        } 
      
        public int SequenceId
        {
            get;
            set;
        }
        public int MasterSequence
        {
            get;
            set;
        }
        public int PrevCadMasterId
        {
            get;
            set;
        }
        public int PrevStyleId
        {
            get;
            set;
        }
        public int NextStyleId
        {
            get;
            set;
        }
        public int PrevSequenceId
        {
            get;
            set;
        }
        public int NextSequenceId
        {
            get;
            set;
        }
        public DateTime FromDate
        {
            get;
            set;
        }
        public DateTime ToDate
        {
            get;
            set;
        }
        public bool CrossBarrier
        {
            get;
            set;
        }
        public int ClientId
        {
            get;
            set;
        }
        public int ClientDeptid
        {
            get;
            set;
        }
        public int ClientParentDeptid
        {//abhishek
          get;
          set;
        }
        public int BarrierDays
        {
            get;
            set;
        }

        public DateTime SampleSentDate
        {
            get;
            set;
        }
        public bool IsQCPresent
        {
            get;
            set;
        }
        public int QCMasterId
        {
            get;
            set;
        }
        public int FitsId
        {
            get;
            set;
        }
        public string FitsStatus
        {
            get;
            set;
        }
        public bool ReqRefSample
        {
            get;
            set;
        }
        public string FitsCommentUpload
        {
            get;
            set;
        }
        public string FitsCommentUpload_New
        {
            get;
            set;
        }
        public string PDDecesion
        {
            get;
            set;
        }
        public DateTime FitsETADate
        {
            get;
            set;
        }
        public DateTime FitsActualDate
        {
            get;
            set;
        }
        public bool IsHandOver
        {
            get;
            set;
        }
        public DateTime HandOverEta
        {
            get;
            set;
        }
        public DateTime HandOverActDate
        {
            get;
            set;
        }

        public bool IsPatternReady
        {
            get;
            set;
        }
        public DateTime PatterntEta
        {
            get;
            set;
        }
        public DateTime PatternReadyActualDate
        {
            get;
            set;
        }

        public bool IsSampleSent
        {
            get;
            set;
        }
        public DateTime SampleSentEta
        {
            get;
            set;
        }
        public DateTime SampleSentActualDate
        {
            get;
            set;
        }
        public string SampleUpload
        {
            get;
            set;
        }
        public string SampleUpload_New
        {
            get;
            set;
        }
        public bool StcApproved
        {
            get;
            set;
        }
        public string Commentes
        {
            get;
            set;
        }
        public int CQDId
        {
            get;
            set;
        }
        public string CQDName
        {
            get;
            set;
        }
        public bool IsReUseStyle
        {
            get;
            set;
        }
        public int IsIkandiClient
        {
            get;
            set;
        }
        public int FitsType
        {
            get;
            set;
        }
        public string FitsSentFor
        {
            get;
            set;
        }
        public string FitsPlanningFor
        {
            get;
            set;
        }
        public bool IsOrderExist
        {
            get;
            set;
        }
        public bool FitsRequestDone
        {
            get;
            set;
        }
        public bool FitsApprovedDone
        {
            get;
            set;
        }
        public bool FitsNotRequest
        {
            get;
            set;
        }
        public bool HistoryPresent
        {
            get;
            set;
        }
        public string FitsCommentSentFor
        {
            get;
            set;
        }
        public string BiplFilePath
        {
            get;
            set;
        }
        public DateTime SamplingHandOverEta
        {
            get;
            set;
        }
        public bool IsCostingWithPattern
        {
            get;
            set;
        }

        public string EventDate 
        {
            get;
            set;
        }

        public string nonworkingdaycount
        {
            get;
            set;
        }
        public string RemakeCount//abhishek 6/10/2017
        {
          get;
          set;
        }
        public string HandoverFileUpload//abhishek 6/10/2017
        {
            get;
            set;
        }
         
    }

}
