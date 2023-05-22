using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class Leave
    {
        public long Id { get; set; }
        public User Employee { get; set; }
        public User AppliedTo { get; set; }
        public LeaveType Type { get; set; }
        public LeaveStatus Status { get; set; }
        public string Reason { get; set; }
        public string ContactDetails { get; set; }
        public string CC { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int FromSession { get; set; }
        public int ToSession { get; set; }
        public DateTime  RequestDate { get; set; }
        public DateTime  ActionDate { get; set; }
        public double NetLeaves { get; set; }
        public int TotalAllowed { get; set; }

        public double HolidaysLeft
        {
            get;
            set;
        }
    }

    public class LeaveType
    {
        public long LeaveTypeID { get; set; }
        public int MaxAllowed {get;set;}
        public string Name { get; set; }
        public Company CompanyType { get; set; }
        public int CompanyTypeID
        {
            get
            {
                return (int)CompanyType;
            }
            set
            {
                CompanyType = (Company)value;
            }
        }
    }


}
