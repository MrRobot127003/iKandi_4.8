using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class OrderLimitation
    {
        public int OrderLimitationID
        {
            get;
            set;
        }

        public int OrderID
        {
            get;
            set;
        }

        public DateTime FabricBulkETA
        {
            get;
            set;
        }

        public DateTime AccessoriesBulkETA
        {
            get;
            set;
        }

        public DateTime ProductionExDate
        {
            get;
            set;
        }

        public DateTime MerchandisingSealDate
        {
            get;
            set;
        }

        public string FabricComments
        {
            get;
            set;
        }

        public string AccessoriesComments
        {
            get;
            set;
        }

        public string ProductionComments
        {
            get;
            set;
        }

        public string MerchandisingComments
        {
            get;
            set;
        }

        public string IkandiComments
        {
            get;
            set;
        }

        public DateTime FabricLabDipStrikeETA
        {
            get;
            set;
        }

        public DateTime BulkApprovalTarget
        {
            get;
            set;
        }

        public int FabricApprovedByMgr
        {
            get;
            set;
        }

        public DateTime FabricApprovedOn
        {
            get;
            set;
        }

        public int AccessoriesApprovedByMgr
        {
            get;
            set;
        }

        public DateTime AccessoriesApprovedOn
        {
            get;
            set;
        }

        public int ProductionApprovedByMgr
        {
            get;
            set;
        }

        public DateTime ProductionApprovedOn
        {
            get;
            set;
        }

        public int MerchandisingApprovedByMgr
        {
            get;
            set;
        }

        public DateTime MerchandisingApprovedOn
        {
            get;
            set;
        }

        public Order Order
        {
            get;
            set;
        }

        public int IADays
        {
            get;
            set;
        }

        public int BIHDays
        {
            get;
            set;
        }

        public int CalcFabric1Days
        {
            get;
            set;
        }
        public int CalcFabric2Days
        {
            get;
            set;
        }

        public int CalcFabric3Days
        {
            get;
            set;
        }
        public int CalcFabric4Days
        {
            get;
            set;
        }

        public int BasicCMT
        {
            get;
            set;
        }
        public int BarrierDaysCMT
        {
            get;
            set;
        }
        public int BasicBarrierDays
        {
            get;
            set;
        }
        public int CalcBarrierDays
        {
            get;
            set;
        }
    }
}
