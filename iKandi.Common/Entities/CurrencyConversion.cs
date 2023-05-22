using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common 
{
    public class CurrencyConversion
    {
        public int ID
        {
            get;
            set;
        }

        public Currency From
        {
            get;
            set;
        }

        public Currency To
        {
            get;
            set;
        }

        public double ConversionRate
        {
            get;
            set;
        }

        public double ExportConversionRate
        {
            get;
            set;
        }
    }
}
