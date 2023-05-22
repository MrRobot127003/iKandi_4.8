using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class Courier
    {
        public int CourierID
        {
            get;
            set;
        }

        public string ContactName
        {
            get;
            set;
        }
        public string Fab1
        {
            get;
            set;
        }
        public string Fab11
        {
            get;
            set;
        }
        public string Fab2
        {
            get;
            set;
        }
        public string Fab3
        {
            get;
            set;
        }
        public string Fab4
        {
            get;
            set;
        }
        public string Fab5
        {
            get;
            set;
        }
        public string Fab6
        {
            get;
            set;
        }
        public string CCGSM1
        {
            get;
            set;
        }
        public string CCGSM2
        {
            get;
            set;
        }
        public string CCGSM3
        {
            get;
            set;
        }
        public string CCGSM4
        {
            get;
            set;
        }

        public string CCGSM5
        {
            get;
            set;
        }
        public string CCGSM6
        {
            get;
            set;
        }

        public string ClientName
        {
            get;
            set;
        }

        public string Department
        {
            get;
            set;
        }
        public bool SampleSent
        {
            get;
            set;
        }

        public string StyleNumber
        {
            get;
            set;
        }

        public string Item
        {
            get;
            set;
        }

        public string Quantity
        {
            get;
            set;
        }

        public string Fabric
        {
            get;
            set;
        }
        public string CCGSM
        {
            get;
            set;
        }
        public string Purpose
        {
            get;
            set;
        }

        public string CourierNumber
        {
            get;
            set;
        }

        public string CourierCompany
        {
            get;
            set;
        }

        public int SentByUserID
        {
            get;
            set;
        }

        public string SentByUserName
        {
            get;
            set;
        }

        public DateTime CourierSentOn
        {
            get;
            set;
        }

        public String CourierSentOnString
        {
            get;
            set;
        }
    }

    public class Couriers : List<Courier>
    { }
}
