using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class FabricHistoryDetails
    {
        public List<FabricInhouseHistory> FabricHistory
        {
            get;
            set;
        }
    }

    public class FabricInhouseHistory : BaseEntity
    {

        public int OrderDetailID
        {
            get;
            set;
        }

        public int FabricType
        {
            get;
            set;
        }
        public string CCGSM
        {
            get;
            set;
        }

        public string FabricName
        {
            get;
            set;
        }

        public double FabricLength
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public int PercentInHouse
        {
            get;
            set;
        }

        public int Fabric1Percent
        {
            get;
            set;
        }

        public int Fabric2Percent
        {
            get;
            set;
        }

        public int Fabric3Percent
        {
            get;
            set;
        }

        public int Fabric4Percent
        {
            get;
            set;
        }
        public int Fabric5Percent
        {
            get;
            set;
        }
        public int Fabric6Percent
        {
            get;
            set;
        }

        public DateTime PercentDate1
        {
            get;
            set;
        }

        public DateTime PercentDate2
        {
            get;
            set;
        }

        public DateTime PercentDate3
        {
            get;
            set;
        }

        public DateTime PercentDate4
        {
            get;
            set;
        }

    }
}
