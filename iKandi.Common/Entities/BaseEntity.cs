using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    [Serializable]
    public class BaseEntity
    {
        public string CreatedBy
        {
            get;
            set;
        }

        public string UpdatedBy
        {
            get;
            set;
        }

        public DateTime CreatedOn
        {
            get;
            set;
        }

        public DateTime UpdatedOn
        {
            get;
            set;
        }

    }
}
