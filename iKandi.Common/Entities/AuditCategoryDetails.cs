using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    [Serializable]
   public class AuditCategoryDetails
    {
        public int CategoryQuesId
        {
            get;
            set;
        }
        public int CategoryId
        {
            get;
            set;
        }
        public string QuestionName
        {
            get;
            set;
        }
        public int DepartmentId
        {
            get;
            set;
        }
        public int DesignationId
        {
            get;
            set;
        }

        public bool AllDetailsSameCatg
        {
            get;
            set;
        }

        public bool AllCatgAllDetails
        {
            get;
            set;
        }

        public string CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedOn
        {
            get;
            set;
        }
        public string UpdatedBy
        {
            get;
            set;
        }
        public DateTime UpdatedOn
        {
            get;
            set;
        }
    }
}
