using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class SubCategory
    {
        public int SubCategoryID
        {
            get;
            set;
        }

        public int CategoryID
        {
            get;
            set;
        }

        public string SubCategoryName
        {
            get;
            set;
        }

        public string SubCategoryCode
        {
            get;
            set;
        }
       
    }
}
