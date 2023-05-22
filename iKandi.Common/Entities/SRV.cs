using System;
using System.Collections.Generic;

namespace iKandi.Common
{
    public class RCDetail : EntityBasetable
    {
        public int SecurityReceiptId
        {
            get;
            set;
        }

        public string PrintColor
        {
            get;
            set;
        }

        public string CurrencySymbol
        {
            get;
            set;
        }

        public string SupplierName
        {
            get;
            set;
        }

        public int SupplierId
        {
            get;
            set;
        }

        public int PoId
        {
            get;
            set;
        }

        public int SrId
        {
            get;
            set;
        }

        public int StockId
        {
            get;
            set;
        }

        public string ChallanNo
        {
            get;
            set;
        }

        public DateTime ChallanDate
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string GateEntryNo
        {
            get;
            set;
        }

        public string PoNumber
        {
            get;
            set;
        }

        public double Quantity
        {
            get;
            set;
        }

        public double PoQuantity
        {
            get;
            set;
        }

        public double TotalDebited
        {
            get;
            set;
        }

        public double TotalReturned
        {
            get;
            set;
        }

        public double TotalRejected
        {
            get;
            set;
        }

        public string FabricName
        {
            get;
            set;
        }

        public List<string> Checkers
        {
            get;
            set;
        }

        public string Rejection
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;
        }

        public string BillNo
        {
            get;
            set;
        }

        public DateTime BillDate
        {
            get;
            set;
        }

        public string SRVNo
        {
            get;
            set;
        }

        public DateTime SRVDate
        {
            get;
            set;
        }

        public double Value
        {
            get;
            set;
        }

        public double Rate
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }

        public string Unit
        {
            get;
            set;
        }

        public List<ThanQuantity> Thans
        {
            get;
            set;
        }

        public ThanQuantity TotalThans
        {
            get;
            set;
        }
    }

    public class ThanQuantity : EntityBasetable
    {
        public int ThanNo
        {
            get;
            set;
        }

        public double ClaimedQty
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

        public double RejectedQty
        {
            get;
            set;
        }

        public double LshortQty
        {
            get;
            set;
        }

        public double DebitedQty
        {
            get;
            set;
        }

        public double ReturnedQty
        {
            get;
            set;
        }

        public double QtyReturned
        {
            get;
            set;
        }

        public double NullifyQty
        {
            get;
            set;
        }

        public ThanQuantity()
        {
            this.ThanNo = 0;
            this.ClaimedQty = 0;
            this.CheckedQty = 0;
            this.ApprovedQty = 0;
            this.RejectedQty = 0;
            this.LshortQty = 0;
            this.DebitedQty = 0;
            this.ReturnedQty = 0;
            this.NullifyQty = 0;
            this.QtyReturned = 0;
        }
    }
}
