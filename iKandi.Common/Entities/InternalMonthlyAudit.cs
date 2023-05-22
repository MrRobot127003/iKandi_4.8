using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class InternalMonthlyAudit
    {
        public int Id
        {
            get;
            set;
        }
        public int CategoryQuesId
        {
            get;
            set;
        }
        public string MonthlyStatus
        {
            get;
            set;
        }
        public DateTime CapDuration
        {
            get;
            set;
        }
        public string Cap
        {
            get;
            set;
        }
        public string Observation
        {
            get;
            set;
        }

        public int UnitId
        {
            get;
            set;
        }

        public string AuditBy
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
    }
}
