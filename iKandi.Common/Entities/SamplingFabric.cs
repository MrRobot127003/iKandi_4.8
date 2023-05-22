using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class SamplingFabric
    {
        public int SamplingFabricID
        {
            get;
            set;
        }

        public int PrintID
        {
            get;
            set;
        }

        public string PrintNumber
        {
            get;
            set;
        }
        public string PrintRefNo
        {
            get;
            set;
        }

        public string MillName
        {
            get;
            set;
        }

        public string MillDesignNumber
        {
            get;
            set;
        }

        public string Fabric
        {
            get;
            set;
        }

        public PrintType PrintType
        {
            get;
            set;
        }

        public int PrintTypeID
        {

            get
            {
                return (int)this.PrintType;
            }
        }

        public PrintTechnology PrintTechnology
        {
            get;
            set;
        }

        public int PrintTechnologyID
        {

            get
            {
                return (int)this.PrintTechnology;
            }
        }

        public int QuantityOrdered
        {
            get;
            set;
        }

        public int QuantityReceived
        {
            get;
            set;
        }

        public Origin Origin
        {
            get;
            set;
        }


        public int OriginID
        {

            get
            {
                return (int)this.Origin;
            }
        }

        public bool IsNew
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;

        }
        public int NumberOfScreens
        {
            get;
            set;
        }

        public double CostPerScreen
        {
            get;
            set;
        }

        public Currency CostCurrency
        {
            get;
            set;
        }

        public int CostCurrencyID
        {
            get
            {
                return (int)this.CostCurrency;
            }
        }

        public bool IsSample
        {
            get;
            set;
        }

        public string Remarks
        {
            get;
            set;
        }

        public DateTime DateOfReceiving
        {
            get;
            set;
        }

        public DateTime ExpectedIssueDate
        {
            get;
            set;
        }

        public DateTime ActualIssueDate
        {
            get;
            set;
        }

        public DateTime ExpectedReceiptDate
        {
            get;
            set;
        }


        public DateTime ActualReceiptDate
        {
            get;
            set;
        }

        public string ClientName
        {
            get;
            set;
        }

        public int ClientID
        {
            get;
            set;

        }
        public string Suffix
        {
            get;
            set;
        }
        public string DesignerName
        {
            get;
            set;
        }

        public string SamplingMerchandiserName
        {
            get;
            set;
        }

        public double TotalAmount
        {
            get
            {
                if (!this.IsSample)
                    return 0;

                return this.CostPerScreen * this.NumberOfScreens;
            }
        }

        public bool ConvertedToOrder
        {
            get
            {
                return !string.IsNullOrEmpty(ClientName);
            }
        }

        public string StatusIssuing
        {
            get
            {
                if (DateTime.Compare(this.ExpectedIssueDate, this.ActualIssueDate) >= 0 && this.ActualIssueDate != DateTime.MinValue)
                {
                    return "SENT ON TIME";
                }
                else if (this.ExpectedIssueDate != DateTime.MinValue && DateTime.Compare(this.ExpectedIssueDate, DateTime.Today) < 0 && this.ActualIssueDate == DateTime.MinValue)
                {
                    return "DELAYED";
                }
                else if (DateTime.Compare(this.ExpectedIssueDate.AddDays(3), this.ActualIssueDate) > 0 && this.ActualIssueDate != DateTime.MinValue)
                {
                    return "SENT WITHIN TOLERANCE";
                }
                else if (DateTime.Compare(this.ExpectedIssueDate.AddDays(3), this.ActualIssueDate) < 0 && this.ActualIssueDate != DateTime.MinValue)
                {
                    return "SENT DELAYED";
                }
                else
                    return "ON SCHEDULE";
               
            }

            set { }
        }


        public string StatusReceving
        {
            get
            {
                if (DateTime.Compare(this.ExpectedReceiptDate, this.ActualReceiptDate) >= 0 && this.ActualReceiptDate != DateTime.MinValue)
                {
                    return "SENT ON TIME";
                }
                else if (this.ExpectedReceiptDate != DateTime.MinValue && DateTime.Compare(this.ExpectedIssueDate, DateTime.Today) < 0 && this.ActualReceiptDate == DateTime.MinValue)
                {
                    return "DELAYED";
                }
                else if (DateTime.Compare(this.ExpectedReceiptDate.AddDays(3), this.ActualReceiptDate) > 0 && this.ActualReceiptDate != DateTime.MinValue)
                {
                    return "SENT WITHIN TOLERANCE";
                }
                else if (DateTime.Compare(this.ExpectedReceiptDate.AddDays(3), this.ActualReceiptDate) < 0 && this.ActualReceiptDate != DateTime.MinValue)
                {
                    return "SENT DELAYED";
                }
                else
                    return "ON SCHEDULE";
               
            }

            set { }
        }

    }
}
