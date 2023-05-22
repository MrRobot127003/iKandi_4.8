using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    [Serializable]
    public class EntityBasetable : BaseEntity
    {
        // 1 for insert 2 for update
        public int IU
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }

        public int Status
        {
            get; set;
        }

        public int IsFinalize
        {
            get; set;
        }

        public int TaskId
        {
            get; set;
        }
    }
}
