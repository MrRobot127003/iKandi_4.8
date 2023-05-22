using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common.Entities
{
    public class WastageAdmin
    {
        public Int32 ProductionWastage
        { 
            get;
            set;
        }
        public Int32 IntialQty
        {
            get;
            set;
        }
        public Int32 FinalQty
        {
            get;
            set;
        }
        public Int32 CostingWastage
        {
            get;
            set;
        }
        public Int32 OrderWastage
        {
            get;
            set;
        }
        public Int32 IsEdit
        {
            get;
            set;
        }
        
    }
}
