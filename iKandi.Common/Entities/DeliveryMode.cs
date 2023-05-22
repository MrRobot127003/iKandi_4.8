using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace iKandi.Common
{
    public class DeliveryMode
    {
        public int Id
        {
            get;
            set;
        }

        public SupplyType SupplyType
        {
            get;
            set;
        }

        public ModeType ModeType
        {
            get;
            set;
        }

        public PackingType PackingType
        {
            get;
            set;
        }

        public Terms Terms
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }
        public string Days
        {
            get;
            set;
        }
        public string ClientMapping
        {
            get;
            set;
        }

        public int SystemExDC
        {
            get;
            set;
        }

        public int ActualExDC
        {
            get;
            set;
        }

        public short GreenRangeStart
        {
            get;
            set;
        }

        public short GreenRangeEnd
        {
            get;
            set;
        }

        public short AmberRangeStart
        {
            get;
            set;
        }

        public short AmberRangeEnd
        {
            get;
            set;
        }

        public short RedRangeStart
        {
            get;
            set;
        }

        public short RedRangeEnd
        {
            get;
            set;
        }

        public string ToolTip
        {
            get;
            set;
        }

        public int IsVisible
        {
            get;
            set;
        }

        public string Color
        {
            get;
            set;
        }

        public int LeadTime
        {
            get;
            set;
        }

        // Added By Yadvendra on 22/10/2019
        public int USSystemEXDC
        {
            get;
            set;
        }

        public int USLeadTime
        {
            get;
            set;
        }

        public int BLSystemEXDC
        {
            get;
            set;
        }

        public int BLLeadTime
        {
            get;
            set;
        }
        //
        // Added By Bharat on 06/12/2019
        public int PLSystemEXDC
        {
            get;
            set;
        }

        public int PLLeadTime
        {
            get;
            set;
        }

        public int KRSystemEXDC
        {
            get;
            set;
        }

        public int KRLeadTime
        {
            get;
            set;
        }
        public int RKSystemEXDC
        {
            get;
            set;
        }

        public int RKLeadTime
        {
            get;
            set;
        }
        //end

        public int OrderPackingType
        {
            get;
            set;
        }

        //abhishek 4 june
        public int INSystemEXDC
        {
            get;
            set;
        }

        public int INLeadTime
        {
            get;
            set;
        }
        public int NSSystemEXDC
        {
            get;
            set;
        }

        public int NSLeadTime
        {
            get;
            set;
        }
        public string IsDeleteing
        {
            get;
            set;
        }
    }

    public class TypeOfPacking
    {
        public int Id
        {
            get;
            set;
        }

        public String Name
        {
            get;
            set;
        }
        public NumberFormatInfo Currency
        {
            get;
            set;
        }
    }
   
}
