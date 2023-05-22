using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common.Entities
{
    public class FactoryAdmin : BaseEntity
    {
        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set; 
        }
        public string DesignationId   
        {
            get;
            set;
        }
    }

}
