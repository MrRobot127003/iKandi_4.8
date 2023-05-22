using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class Client
    {
        public bool IsActive
        {
            get;
            set;
        }

        public int ClientID
        {
            get;
            set;
        }
        public int FPCAcceptanceCriteria
        { get; set; }

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
        public string ClientCode
        {
            get;
            set;
        }

        public int BuyingHouseId
        {
            get;
            set;
        }
        public int IsIkandiClient
        {
            get;
            set;
        }

        public string BuyingHouseName
        {
            get;
            set;
        }
      
        public string SalesPersonName
        {
            get;
            set;
        }

       

        public string DesignerName
        {
            get;
            set;
        }

      

        public string AccountManagerName
        {
            get;
            set;
        }

       
        public string TechnicalManagerName
        {
            get;
            set;
        }

       
        public string FitMerchantName
        {
            get;
            set;
        }
       
        public string SamplingMerchantName
        {
            get;
            set;
        }


      
        public string ExportManagerName
        {
            get;
            set;
        }
       
        public string DeliveryManagerName
        {
            get;
            set;
        }

        public string ClientHeadName
        {
            get;
            set;
        }



        public int ClientFactoryContactID
        {
            get;
            set;
        }

        public string ClientFactoryContactName
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

        public string Fax
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

        public double Aql
        {
            get;
            set;
        }

        public int IsMDARequired
        {
            get;
            set;
        }
        public int IsPPSampleRequired
        {
            get;
            set;
        }

        public decimal Discount
        {
            get;
            set;
        }

        public int PaymentTerms
        {
            get;
            set;
        }

        public Group Group
        {
            get;
            set;
        }

        public int GroupID
        {
            get;
            set;
        }

        public string BillingAddess
        {
            get;
            set;
        }

        public string OfficialName
        {
            get;
            set;
        }

        public List<ClientDepartment> Departments
        {
            get;
            set;
        }


        public List<ClientContact> Contacts
        {
            get;
            set;
        }

        public string CountryCode
        {
            get;
            set;
        }
  
        #region Gajendra Client Form Updates
        // Gajendra Client Form 30-11-2015
        public string DivisionID
        {
            get;
            set;
        }
        //Gajendra Design
        public string DivisionName
        {
            get;
            set;
        }
        #endregion 

        public string ClientColorCode//abhishek
        {
            get;
            set;
        }
    }
    public class ClientDepartment
    {
        public int DeptID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public int UserId
        {
            get;
            set;

        }
        public int ParentId
        {
            get;
            set;

        }
        public int ClientID
        {
            get;
            set;
        }

        public int IsDeletedDept
        {
            get;
            set;
        }

        public int Mon
        {
            get;
            set;

        }

        public int Tue
        {
            get;
            set;
        }

        public int Wed
        {
            get;
            set;
        }

        public int Thu
        {
            get;
            set;
        }

        public int Fri
        {
            get;
            set;
        }

        public Client Client
        {
            get;
            set;
        }

        public List<ClientDepartmentAssociation> ClientDepartmentAssociation
        {
            get;
            set;
        }

        public String SalesManagerIDs
        {
            get;
            set;
        }

        public String SalesManagerNames
        {
            get;
            set;
        }
        public String SalesManagerEmail
        {
            get;
            set;
        }
        public String SalesManagerContact
        {
            get;
            set;
        }

        public String ShippingManagerIDs
        {
            get;
            set;
        }

        public String ShippingManagerNames
        {
            get;
            set;
        }
        public String ShippingManagerEmail
        {
            get;
            set;
        }
        public String ShippingManagerContact
        {
            get;
            set;
        }

        public String DesignerIDs
        {
            get;
            set;
        }

        public String DesignerNames
        {
            get;
            set;
        }
        public String DesignerEmail
        {
            get;
            set;
        }
        public String DesignerContact
        {
            get;
            set;
        }

        public String AccountManagerIDs
        {
            get;
            set;
        }
        public String AccountManagerNames
        {
            get;
            set;
        }
        public String AccountManagerEmail
        {
            get;
            set;
        }
        public String AccountManagerContact
        {
            get;
            set;
        }

        public String TechnologistIDs
        {
            get;
            set;
        }

        public String TechnologistNames
        {
            get;
            set;
        }
        public String TechnologistEmail
        {
            get;
            set;
        }
        public String TechnologistContact
        {
            get;
            set;
        }
       
        public String FITMerchantIDs
        {
            get;
            set;
        }
        public String FITMerchantNames
        {
            get;
            set;
        }
        public String FITMerchantEmail
        {
            get;
            set;
        }
        public String FITMerchantContact
        {
            get;
            set;
        }


        public String SamplingMerchantIDs
        {
            get;
            set;
        }

        public String SamplingMerchantNames
        {
            get;
            set;
        }
        public String SamplingMerchantEmail
        {
            get;
            set;
        }
        public String SamplingMerchantContact
        {
            get;
            set;
        }

        public String DeliveryManagerIDs
        {
            get;
            set;
        }

        public String DeliveryManagerNames
        {
            get;
            set;
        }
        public String DeliveryManagerEmail
        {
            get;
            set;
        }
        public String DeliveryManagerContact
        {
            get;
            set;
        }

        public String ClientHeadIDs
        {
            get;
            set;
        }

        public String ClientHeadNames
        {
            get;
            set;
        }
        public String ClientHeadEmail
        {
            get;
            set;
        }
        public String ClientHeadContact
        {
            get;
            set;
        }
    }


    public class ClientContact
    {
        public int ContactID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Phone
        {
            get;
            set;
        }
        public int ClientID
        {
            get;
            set;
        }
        public int IsDeletedContact
        {
            get;
            set;
        }

    }


    public class Clients : Collection<Client>
    {
    }


    public class ClientDepartmentAssociation
    {
        public int Id
        {
            get;
            set;
        }

        public int DeptID
        {
            get;
            set;
        }

        public int UserId
        {
            get;
            set;
        }

        public int DesignationId
        {
            get;
            set;
        }

    }
}
