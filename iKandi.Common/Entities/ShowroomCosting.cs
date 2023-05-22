using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class ShowroomCosting
    {
        public Int64 ShippedMaxValue
        {
            get;
            set;
        }

        public int StyleID
        {
            get;
            set;
        }

        public string StyleNumber
        {
            get;
            set;
        }


        public string CCGSM
        {
            get;
            set;
        }


        public int CostingID
        {
            get;
            set;
        }

        public Currency Currency
        {
            get;
            set;
        }

        public decimal Markup
        {
            get;
            set;
        }

        public decimal Commission
        {
            get;
            set;
        }

        public string VersionCode
        {
            get;
            set;
        }

        public string Fabric
        {
            get;
            set;
        }

        public double PriceQuoted
        {
            get;
            set;
        }

        public int Minimums
        {
            get;
            set;
        }

        public string StyleFrontImageURL
        {
            get;
            set;
        }

        public bool IsSelected
        {
            get;
            set;
        }


    }

}
