using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class Cutting : BaseEntity
    {
        public int Id
        {
            get;
            set;
        }

        public Order order
        {
            get;
            set;
        }

        public string CreatedBy
        {
            get;
            set;
        }

        public DateTime CreatedOn
        {
            get;
            set;
        }

        public string UpdatedBy
        {
            get;
            set;
        }

        public DateTime UpdatedOn
        {
            get;
            set;
        }

        public DateTime DateOfIssue
        {
            get;
            set;
        }

        public int ApprovedByMerchant
        {
            get;
            set;
        }

        public int ApprovedByFabricHead
        {
            get;
            set;
        }

        public int ApprovedByProductionHead
        {
            get;
            set;
        }

        public DateTime ApprovedByMerchantOn
        {
            get;
            set;
        }

        public DateTime ApprovedByFabricHeadOn
        {
            get;
            set;
        }

        public DateTime ApprovedByProductionHeadOn
        {
            get;
            set;
        }

        public List<CuttingDetail> CuttingDetails
        {
            get;
            set;
        }

        public List<CuttingHistory> CuttingHistory
        {
            get;
            set;
        }

    }
    public class CuttingDetail : OrderDetail
    {
        public int ID
        {
            get;
            set;
        }
        public int CuttingSheetID
        {
            get;
            set;
        }

        public int PcsCut
        {
            get;
            set;
        }
        public double PercentagePcsCut 
        {
            get;
            set;

        }
        public double PcsToBeCut
        {
            get;
            set;

        }
        public int PcsIssued
        {
            get;
            set;
        }

        public int BalanceInHouse
        {
            get
            {
                return PcsCut - PcsIssued;
            }

        }
        public DateTime Inline
        {
            get;
            set;
        }

    }

    public class CuttingHistory : CuttingDetail
    {
        public DateTime Date
        {
            get;
            set;
        }

    }
    public class CuttingCheckCalculation : CuttingDetail
    {
        public DateTime Date
        {
            get;
            set;
        }

    }

}
