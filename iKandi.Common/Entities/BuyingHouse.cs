using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class BuyingHouse
    {


        public int IsActive
        {
            get;
            set;
        }
            public int BuyingHouseID
            {
                get;
                set;
            }

            public string CompanyName
            {
                get;
                set;
            }

            public string Website
            {
                get;
                set;
            }
            public string BHCode
            {
                get;
                set;
            }           

            public string Address
            {
                get;
                set;
            }

            public string Phone
            {
                get;
                set;
            }
             public string Email
            {
                get;
                set;
            }

            public DateTime ClientSince
            {
                get;
                set;
            }

    }

    public class BuyingHouses : Collection<BuyingHouse>
    {
    }
}
