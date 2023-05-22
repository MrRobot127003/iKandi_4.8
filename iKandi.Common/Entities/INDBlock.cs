using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class INDBlock
    {

        public int BlockID
        {
            get;
            set;
        }

        public string BlockNumber
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

        public string ClientName
        {
            get;
            set;
        }

        public string Brand
        {
            get;
            set;
        }

        public string Reference
        {
            get;
            set;
        }

        public double BlockCost
        {
            get;
            set;
        }

        public DateTime DatePurchased
        {
            get;
            set;
        }

        public Currency BlockCostCurrency
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public string AdditionalImageUrl1
        {
            get;
            set;
        }

        public string AdditionalImageUrl2
        {
            get;
            set;
        }


    }


    public class INDBlocks : Collection<INDBlock>
    {

    }
}
