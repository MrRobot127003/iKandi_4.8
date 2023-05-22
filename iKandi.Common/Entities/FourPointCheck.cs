using System;
using System.Collections.Generic;

namespace iKandi.Common
{
    [Serializable]
    public class FourPointCheckAdmin : EntityBasetable
    {
        public string process
        {
            get;
            set;
        }

        public int patta
        {
            get;
            set;
        }

        public int hole
        {
            get;
            set;
        }

        public string sizeUnit
        {
            get;
            set;
        }

        public int minsize
        {
            get;
            set;
        }

        public string maxsize
        {
            get;
            set;
        }

        public int points
        {
            get;
            set;
        }

        public string typeflag
        {
            get;
            set;
        }

        public int sorting
        {
            get;
            set;
        }

        public string ObjectLength
        {
            get;
            set;
        }

        public int Sequence
        {
            get;
            set;
        }
    }
    
    [Serializable]
    public class FourPointDetail:EntityBasetable
    {
        public int StockId
        {
            get;
            set;
        }

        public int OrderDetailId
        {
            get;
            set;
        }

        public int PoTypeId
        {
            get;
            set;
        }

        public int PoId
        {
            get; set;
        }

        public int LevelId
        {
            get;
            set;
        }

        public double CheckedQty
        {
            get;
            set;
        }

        public double ApprovedQty
        {
            get;
            set;
        }

        public double DebitedQty
        {
            get;
            set;
        }

        public double StockQty
        {
            get;
            set;
        }

        public int CheckedBy1
        {
            get;
            set;
        }

        public int CheckedBy2
        {
            get;
            set;
        }

        public DateTime CheckedDate
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;
        }

        public int IsQAApproved
        {
            get;
            set;
        }

        public string QAComments
        {
            get;
            set;
        }

        public int IsFMQAApproved
        {
            get;
            set;
        }

        public string FMQAComments
        {
            get;
            set;
        }

        public int IsFabricMgrApproved
        {
            get;
            set;
        }

        public string FabricMgrComments
        {
            get;
            set;
        }

        public char FabStatus
        {
            get;
            set;
        }

        public double RejectedQty
        {
            get;
            set;
        }

        public double ReturnedQty
        {
            get;
            set;
        }

        public string Fabric
        {
            get; set;
        }

        public string PrintColor
        {
            get; set;
        }

        public int OdId
        {
            get; set;
        }

        public int WashingId
        {
            get;
            set;
        }

        public List<FourPointProcess> Processes
        {
            get; set;
        }

        public List<FourPointCheckAdmin> FpAdmins
        {
            get; set;
        }

        public FourPointSystemHeader FpHeader
        {
            get; set;
        }
    }

    [Serializable]
    public class FourPointProcess : EntityBasetable
    {
        public int FourPointId
        {
            get; set;
        }

        public int RollNo
        {
            get;
            set;
        }

        public string MillDyeLot
        {
            get;
            set;
        }

        public string BIPLDyeLot
        {
            get;
            set;
        }

        public double ActualLength
        {
            get;
            set;
        }

        public double Width_S
        {
            get;
            set;
        }

        public double Width_M
        {
            get;
            set;
        }

        public double Width_E
        {
            get;
            set;
        }

        public int Patta
        {
            get;
            set;
        }

        public int Hole
        {
            get;
            set;
        }

        public char FabStatus
        {
            get;
            set;
        }

        public List<FourPointProcessDetail> Details
        {
            get; set;
        }
    }

    [Serializable]
    public class FourPointProcessDetail : EntityBasetable
    {
        public int Value
        {
            get; set;
        }

        public char FabStatus
        {
            get; set;
        }

        public int FpAdminId
        {
            get;
            set;
        }

        public int FpDetailId
        {
            get;
            set;
        }

        public int FpMainId
        {
            get; set;
        }
    }
    

    [Serializable]
    public class FourPointSystemHeader:EntityBasetable
    {
        public string BuyerName
        {
            get; set;
        }

        public int BuyerId
        {
            get; set;
        }

        public int PoTypeId
        {
            get;
            set;
        }

        public string StyleNo
        {
            get;
            set;
        }

        public int StyleId
        {
            get;
            set;
        }

        public string FabricName
        {
            get;
            set;
        }

        public string StyleNumbers
        {
            get;
            set;
        }

        public string OrderNumbers
        {
            get;
            set;
        }

        public string PrintColor
        {
            get; set;
        }

        public string SupplierName
        {
            get; set;
        }

        public int SupplierId
        {
            get; set;
        }

        public string PoNo
        {
            get; set;
        }

        public int PoId
        {
            get; set;
        }

        public int Checker1
        {
            get; set;
        }

        public int Checker2
        {
            get; set;
        }

        public DateTime Date
        {
            get; set;
        }

        public double PoQty
        {
            get; set;
        }

        public double AvlQuantity
        {
            get;
            set;
        }

        public double StockQuantity
        {
            get;
            set;
        }

        public int AcCriteria
        {
            get;
            set;
        }

        public double CheckedQuantity
        {
            get;
            set;
        }

        public int QtyForCheck
        {
            get; set;
        }

        public int StoreId
        {
            get;
            set;
        }

        public int StockId
        {
            get;
            set;
        }

        public int OrderDetailId
        {
            get;
            set;
        }

        public string Unit
        {
            get; set;
        }
    }

    [Serializable]
    public enum FPAdmin
    {
        All = -1, HP = 1, PR = 2, AC = 3
    }
}
