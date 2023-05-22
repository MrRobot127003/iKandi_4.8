using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    [Serializable]
    public class Print
    {
        public int PrintID
        {
            get;
            set;
        }

        public string PrintRefNo
        {
            get;
            set;
        }

        public string PrintNumber
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public int DesignerID
        {
            get;
            set;
        }

        public string DesignerName
        {
            get;
            set;
        }

        public int ClientID
        {
            get;
            set;
        }
        public int DeptID
        {
            get;
            set;
        }
        public int ParentDeptID
        {
            get;
            set;
        }
        public string ClientName
        {
            get;
            set;
        }

        public string DepartmentName
        {
            get;
            set;
        }
        public string SampleMerchandiserName
        {
            get;
            set;
        }

        public string PrintCompany
        {
            get;
            set;
        }

        public string PrintCompanyReference
        {
            get;
            set;
        }

        public double PrintCost
        {
            get;
            set;
        }

        public PrintStatus Status
        {
            get;
            set;
        }

        public DateTime DatePurchased
        {
            get;
            set;
        }

        public Currency PrintCostCurrency
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }
        public string DevelopedImageUrl
        {
            get;
            set;
        }

        public string FabricQuality
        {
            get;
            set;
        }

        public int PrintTypeID
        {
            get;
            set;
        }

        public string PrintType
        {
            get;
            set;
        }


        public bool IsSelected
        {
            get;
            set;
        }
        public int PrintCategory
        {
            get;
            set;
        }
        public string PrintCategoryName
        {
            get;
            set;
        }

    }

    public class Prints : Collection<Print>
    {

    }

    public class PrintHistory
    {
        public int PrintHistoryID
        {
            get;
            set;
        }

        public Print ParentPrint
        {
            get;
            set;
        }

        public int Status
        {
            get;
            set;
        }

        public DateTime TestingDate
        {
            get;
            set;
        }

        public string Comments
        {
            get;
            set;
        }

        public string PDFPath
        {
            get;
            set;
        }

        public bool IsSendCommentsToLimitation
        {
            get;
            set;
        }
    }
}
