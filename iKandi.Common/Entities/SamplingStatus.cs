using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{

    public class SamplingStatus : Style
    {

        public string AllStyleFabric
        {
            get;
            set;
        }
         public string AllSeasonStory
        {
            get;
            set;
        }
        public string FabricCount
        {
            get;
            set;
        }
        public string LastIssue
        {
            get;
            set;
        }
        public string AllIssue
        {
            get;
            set;
        }
        public string WorkFlowLastResolution
        {
            get;
            set;
        }
        public string WorkFlowAllResolution
        {
            get;
            set;
        }
        public string OwnerLastResolution
        {
            get;
            set;
        }
        public string OwnerAllResolution
        {
            get;
            set;
        }
        public string MeterageInHouse
        {
            get;
            set;
        }
        public string Tracking
        {
            get;
            set;
        }
        public string FabRemarks
        {
            get;
            set;
        }
        public string AllFabRemarks
        {
            get;
            set;
        }
        public string NewFabric
        {
            get;
            set;
        }
        public string Assignment
        {
            get;
            set;
        }
        public string SeasonName
        {
            get;
            set;
        }
        public string SamplingMerchandisingManagerName
        {
            get;
            set;
        }

        public string LastStory
        {
            get;
            set;
        }

        public string Story
        {
            get;
            set;
        }
        public string Fabric
        {
            get;
            set;
        }
        public string CCGSM
        {
            get;
            set;
        }
        public string Fab11
        {
            get;
            set;
        }
        public string Fab21
        {
            get;
            set;
        }
        public string Fab31
        {
            get;
            set;
        }
        public string Fab41
        {
            get;
            set;
        }
        public string Fab51
        {
            get;
            set;
        }
        public string Fab61
        {
            get;
            set;
        }
        public string CCGSM11
        {
            get;
            set;
        }
        public string CCGSM21
        {
            get;
            set;
        }
        public string CCGSM31
        {
            get;
            set;
        }
        public string CCGSM41
        {
            get;
            set;
        }

        public string CCGSM51
        {
            get;
            set;
        }

        public string CCGSM61
        {
            get;
            set;
        }

        public DateTime ExpectedDate
        {
            get;
            set;
        }

        public DateTime MerchandiserDispatchDate
        {
            get;
            set;
        }

        public DateTime ReceivedOn
        {
            get;
            set;
        }

        public DateTime SentToiKandiOn
        {
            get;
            set;
        }

        public int FOBPrice
        {
            get;
            set;
        }

        public int CounterComplete
        {
            get;
            set;

        }

        public string Priority
        {
            get
            {
                return Constants.GetSamplingStatusPriority(this.ETA);
            }
        }

        public string SamplingStatusRemarks
        {
            get;
            set;
        }

        public string SamplingStatusRemarksReplace
        {
            get;
            set;
        }
        public string Remarks
        {
            get;
            set;
        }

    }


}
