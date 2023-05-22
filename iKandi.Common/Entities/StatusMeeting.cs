using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class StatusMeeting
    {
        public List<StatusDetail> StatusDetails
        {
            get;
            set;
        }
    }

    public class StatusDetail : OrderDetail
    {
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
        public int StatusFileId
        {
            get;
            set;
        }

        public int FabricOwnerID
        {
            get;
            set;
        }

        public string FitsOwnerName
        {
            get;
            set;
        }

        public string FabricOwnerName
        {
            get;
            set;
        }

        public string FitsOwnerEmail
        {
            get;
            set;
        }

        public string FabricOwnerEmail
        {
            get;
            set;
        }

        public int FitsOwnerID
        {
            get;
            set;
        }

        public string FitsResolution
        {
            get;
            set;
        }

        public string FitsRemarks
        {
            get;
            set;
        }

        public string FitsRemarksStatus
        {
            get;
            set;
        }

        public string FabricResolution
        {
            get;
            set;
        }

        public string FabricRemarks
        {
            get;
            set;
        }

        public DateTime PlannedDispatchDate
        {
            get;
            set;
        }

        public DateTime TOPPlannedDispatchDate
        {
            get;
            set;
        }

        public bool FabricIsResolutionPermitted
        {
            get;
            set;
        }

        public bool FitsIsResolutionPermitted
        {
            get;
            set;
        }
        public string FabricOwnerlistIDs
        {
            get;
            set;
        }
        public string FitsOwnerlistIDs
        {
            get;
            set;
        }
        public string FitRemarksOnly
        {
            get;
            set;
        }
        public DateTime SpecUploadDate
        {
            get;
            set;
        }
        public string EmailList
        {
            get;
            set;
        }
    }
}
