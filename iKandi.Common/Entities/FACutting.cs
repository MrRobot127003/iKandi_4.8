using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class FACutting : EntityBasetable
    {
        public int UnitFrom
        {
            get;
            set;
        }

        public int UnitTo
        {
            get;
            set;
        }

        public int Perc
        {
            get;
            set;
        }

        public string Units
        {
            get;
            set;
        }
    }
}
