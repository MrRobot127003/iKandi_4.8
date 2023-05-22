using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
   public class AccessoryQuality
    {
        public int AccessoryQualityID
        {
            get;
            set;
        }
        public string AccTypeReg_UnReg//abhishek 8/6/2017
        {
            get;
            set;
        }
        public string SupplierName
        {
            get;   
            set;
        }

        public string Category
        {
            get;
            set;
        }

        public String Composition
        {
            get;
            set;
        }

        public string AccRef
        {
            get;
            set;
        }

        public int Origin
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;
        }
       
       public int Wastage
        {
            get;
            set;
        }

        public int LeadTime
        {
            get;
            set;
        }

        public string UploadBaseTestFile
        {
            get;
            set;
        }

        public DateTime TestConductedOn
        {
            get;
            set;
        }

        public double MinimumOrderQuality
        {
            get;
            set;
        }

        public string UploadPicture
        {
            get;
            set;
        }

        public int TotalCount
        {
            get;
            set;
        }

        public int CategoryId
        {
            get;
            set;
        }

        public int SubCategoryId
        {
            get;
            set;
        }

        public string Identification
        {
            get;
            set;
        }

        public string TradeName
        {
            get;
            set;
        }

        public string CategoryName
        {
            get;
            set;
        }

        public string SubCategoryName
        {
            get;
            set;
        }

        public string SupplierReference
        {
            get;
            set;
        }
        public string companyname
        {
            get;
            set;
        }

        public string FullAccRef
        {
            get 
            {
                int AccessoryReferenceLength = AccRef.Length;
                for (int i = 0; i < 6 - AccessoryReferenceLength; i++)
                {
                   AccRef = "0" + AccRef;
                }
                return AccRef;
            }

            set {}
        
        }
         


        public List<AccessoryQualityBuyer> Buyers
        {
            get;
            set;
        }
        public List<AccessoryQualityPicture> Pictures
        {
            get;
            set;
        }

        public double Price
        {
            get;
            set;
        }
        public double OldPrice
        {
            get;
            set;
        }
        public bool IsBiplRegistered
        {
            get;
            set;
        }
        //===========G======================
        public string AQMasterID { get;set;}
        public string FilePath { get; set; }
        public int SupplierId { get; set; }
        public int StockUnit   {get;set;}
        public DateTime ApprovedOn { get; set; }
   }
}
