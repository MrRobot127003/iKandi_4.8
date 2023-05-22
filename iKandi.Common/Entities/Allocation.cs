using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class Allocation : OrderDetail
    {
        public string StyleNumber
        {
            get;
            set;
        }

        public string SerialNumber
        {
            get;
            set;
        }

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


        public string Status
        {
            get;
            set;
        }

        public DateTime SealDate
        {
            get;
            set;
        }

        public double Fabric1Percent
        {
            get;
            set;
        }

        public double Fabric2Percent
        {
            get;
            set;
        }

        public double Fabric3Percent
        {
            get;
            set;
        }

        public double Fabric4Percent
        {
            get;
            set;
        }

        public string Accessories
        {
            get;
            set;
        }

        public bool IsRepeat
        {
            get;
            set;
        }

        public StitchingDetail StitchingData
        {
            get;
            set;
        }

        public int PrevUnitId
        {
            get;
            set;
        }

        public string PrevFactoryCode
        {
            get;
            set;
        }

        public string PrevFactoryName
        {
            get;
            set;
        }

    }    

    public class AllocationCollection : List<Allocation>
    {
    }

    public class AllocationHistory
    {
        public int ProductionUnitId
        {
            get;
            set;
        }

        public int OrderDetailId
        {
            get;
            set;
        }

        public int NumberOfContracts
        {
            get;
            set;
        }

        public int QuantityAll
        {
            get;
            set;
        }

        public int OverAllPcsStitched
        {
            get;
            set;
        }

        public int BalanceOnMachine
        {
            get;
            set;
        }

        public int AvailableAllocation
        {
            get;
            set;
        }

        public string MonthName
        {
            get;
            set;
        }
    }

    public class AllocationHistoryCollection : List<AllocationHistory>
    {
    }
}
