using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;


namespace iKandi.Common
{
    public class SupplierTables : EntityBasetable
    {
        public List<Po_Type> PoTypes
        {
            get;
            set;
        }

        public List<ProcessAdmin> Processes
        {
            get;
            set;
        }
      

        public List<FabricGroupAdmin> Groups
        {
            get;
            set;
        }

        public List<PaymentAdmin> Days
        {
            get;
            set;
        }

        public List<GradeAdmin> Grades
        {
            get;
            set;
        }

        public SupplierAdmin Supplier
        {
            get;
            set;
        }

        public List<SupplierContact> Contacts
        {
            get;
            set;
        }
      

    }

    public class SupplierAdmin : EntityBasetable
    {
        public string SupplierName
        {
            get;
            set;
        }

        public int ContactId
        {
            get;
            set;
        }

        public string SupplierInitial
        {
            get;
            set;
        }

        public string GroupName
        {
            get;
            set;
        }

        public string GroupInitial
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public long MonthlyCapacity
        {
            get;
            set;
        }

        public string Unit
        {
            get;
            set;
        }

        public string PaymentTerms
        {
            get;
            set;
        }

        public string Grade
        {
            get;
            set;
        }

        public int Leadtime
        {
            get;
            set;
        }

        public int ModifiedBy 
        {
            get;
            set;
        }

        public DateTime ModifiedOn
        {
            get;
            set;
        }
        //
        public string SupplierType
        {
            get;
            set;
        }

    }

    public class SupplierContact : EntityBasetable
    {
        public string Name
        {
            get;
            set;
        }

        public int SupplierId
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Phone
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

    public class SupplierContactJs
    {
        public string Name
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Phone
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

    public class SecurityReceipt : EntityBasetable
    {
        public int PoId
        {
            get;
            set;
        }

        public int SupplierId
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

        public string ItemName
        {
            get;
            set;
        }

        public string GateEntryNo
        {
            get;
            set;
        }

        public string EntryType
        {
            get;
            set;
        }

        public string ReceivedQty
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public string OfficerName
        {
            get;
            set;
        }
    }

    public class SupplierFabricGroupMapping
    {
        public int SupplierId
        {
            get;
            set;
        }

        public int CategoryId
        {
            get;
            set;
        }
    }

    public class SupplierProcessMapping
    {
        public int SupplierId
        {
            get;
            set;
        }

        public int ProcessId
        {
            get;
            set;
        }
    }

    public class SupplierPoMapping
    {
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
    }

    public class SupplierSearch
    {
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

        public int ProcessId
        {
            get;
            set;
        }

        public int CategoryId
        {
            get;
            set;
        }

        public int PaymentTerms
        {
            get;
            set;
        }

        public string BasicSearch
        {
            get;
            set;
        }

        public int SupplierLeadTimeFrom
        {
            get;
            set;
        }

        public int SupplierLeadTimeTo
        {
            get;
            set;
        }

        public int MonthlyCapacityFrom
        {
            get;
            set;
        }


        public int supplierType
        {
            get;
            set;
        }//


        public int MonthlyCapacityTo
        {
            get;
            set;
        }
        public String Unit
        {
            get;
            set;
        }
        public int Grade
        {
            get;
            set;
        }
        public SupplierSearch()
        {
            this.SupplierId = -1;
            this.PoId = -1;
            this.MonthlyCapacityFrom = -1;
            this.CategoryId = -1;
            this.MonthlyCapacityTo = -1;
            this.ProcessId = -1;
            this.PaymentTerms = -1;
            this.SupplierLeadTimeFrom = -1;
            this.SupplierLeadTimeTo = -1;
            this.Grade = -1;
            this.Unit = null;
        }
    }

    public class SupplierList : SupplierAdmin
    {
        public List<SupplierContact> Contacts
        {
            get;
            set;
        }

        public string SupplyTypeDetails
        {
            get;
            set;
        }

        public string ProcessDetails
        {
            get;
            set;
        }

        public string FabricDetails
        {
            get;
            set;
        }

        public string MonthlyCapacityDetail
        {
            get;
            set;
        }

        public string PaymentTermDetail
        {
            get;
            set;
        }

        public string LeadTimeDetail
        {
            get;
            set;
        }
    }

    //created by manisha on 20 Dec 2011
    [Serializable]
    public class Supplier
    {
        public List<SupplierContact> Contacts
        {
            get;
            set;
        }

        public int SupplierID
        {
            get;
            set;
        }

        public string SupplierName
        {
            get;
            set;
        }

        public string SupplierInitials
        {
            get;
            set;
        }

        public string GroupName
        {
            get;
            set;
        }

        public string GroupInitials
        {
            get;
            set;
        } 

        public string SupplierInitial
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string MonthlyCapacity
        {
            get;
            set;
        }
         
        public int MonthCapacity
        {
            get;
            set;
        }


        public string Unit
        {
            get;
            set;
        }
        public string UnitMtr
        {
            get;
            set;
        }

        public string PaymentTerms
        {
            get;
            set;
        }

        public int SupplierLeadTime
        {
            get;
            set;
        }

        public int PaymentTerm 
        {
            get;
            set;
        }

        public string FabricType
        {
            get;
            set; 
        }

        public string Grade
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }

        public DateTime ModifiedOn
        {
            get;
            set;
        }

        //
        public int Id
        {
            get;
            set;
        }
        public string value
        {
            get;
            set;
        }


        public string Ids
        {
            get;
            set;
        }

        public string value2
        {
            get;
            set;
        }

        //

        public List<SupplierContacts> SupplierContacts
        {
            get;
            set;
        }
    }

    [Serializable]
    public class SupplierContacts 
    {
        public int SupplierContactID
        {
            get;
            set;
        }

        public string SupplierContactName
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string PhoneNo
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;
        }

        public int IsActive
        {
            get;
            set;
        }

    }
     
    [Serializable]
    public class EIChallanThanDetail : EntityBasetable
    {
        public int ThanNo
        {
            get; set;
        }

        public double Quantity
        {
            get; set;
        }
    }

    [Serializable]
    public class EiChallanThanList : List<EIChallanThanDetail>
    {
        
    }

    [Serializable]
    public class EiCHallanHeader : EntityBasetable
    {
        public DateTime ChallanDate
        {
            get;
            set;
        }

        public double Quantity
        {
            get;
            set;
        }

        public double StockQuantity
        {
            get;
            set;
        }

        public double RejectedQuantity
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

        private string _poNumber;

        public string PoNumber
        {
            get { return _poNumber; }
            set { _poNumber = value; }
        }

        public int PoId
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

        public string FabricName
        {
            get;
            set;
        }

        public string PrintColor
        {
            get;
            set;
        }

        public string Unit
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public int IsReProcessed
        {
            get;
            set;
        }
    }

    [Serializable]
    public class EiChallan : EiCHallanHeader
    {
        public List<string> Checkers
        {
            get; set;
        }

        public EiChallanThanList ThanList
        {
            get; set;
        }
    }

    [Serializable]
    public class SRCQ : EiChallan
    {
        public int FpId
        {
            get; set;
        }

        public double NullifyQty
        {
            get;
            set;
        }

        public double ReturnedQty
        {
            get;
            set;
        }

        public double RejectedQty
        {
            get;
            set;
        }

        public string Rejection
        {
            get; set;
        }

        public string Remarks
        {
            get; set;
        }



    }
}
