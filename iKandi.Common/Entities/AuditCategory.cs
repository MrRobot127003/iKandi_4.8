using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    [Serializable]
    public class AuditCategory
    {
        public int Id
        {
            get;
            set;
        }

        public string InternalAuditCatgName
        {
            get;
            set;
        }

        public int IsActive
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
    }

    [Serializable]
    public class Auditor
    {
        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int CategoryQusId
        {
            get;
            set;
        }
        public int UserId
        {
            get;
            set;
        }
    }

}
