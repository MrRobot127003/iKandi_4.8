using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class Partner
    {
        public Int32 PartnerID
        {
            get;
            set;
        }

        public String PartnerName
        {
            get;
            set;
        }

        public String PartnerCode
        {
            get;
            set;
        }

        public String Website
        {
            get;
            set;
        }

        public String Phone
        {
            get;
            set;
        }

        public String Email
        {
            get;
            set;
        }

        public String Address
        {
            get;
            set;
        }

        public PartnerDeliveryMode DeliveryMode
        {
            get;
            set;
        }

        public PartnerType PartnerType
        {
            get;
            set;
        }

        public Int32 UserID
        {
            get;
            set;
        }

        public String UserName
        {
            get;
            set;
        }

        public String Password
        {
            get;
            set;
        }

        public List<PartnerEmail> EmailDetails
        {
            get;
            set;
        }

        public List<PartnerClient> PartnerClient
        {
            get;
            set;
        }

    }
    

    public class PartnerEmail
    {
        public Int32 PartnerEmailId
        {
            get;
            set;
        }

        public Int32 PartnerId
        {
            get;
            set;
        }

        public String Name
        {
            get;
            set;
        }

        public String Email
        {
            get;
            set;
        }

        public PartnerEmailFunction Function
        {
            get;
            set;
        }

        public Boolean IsDeletedContact
        {
            get;
            set;
        }
    }
    public class PartnerClient
    {
        public Client Client
        {
            get;
            set;
        }

        public Partner Partner
        {
            get;
            set;
        }

    }
}
