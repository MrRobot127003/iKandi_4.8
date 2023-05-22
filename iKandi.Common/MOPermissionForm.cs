using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class MOPermissionForm
    {
        public int MoSectionCoulmeMappingID
        {
            get;
            set;
        }
        public int DepartmentId
        {
            get;
            set;
        }
        public string DepartmentName  
        {
            get;
            set;
        }

        public int DesignationId
        {
            get;
            set;
        }
        public string DesignationName  
        {
            get;
            set;
        }
        public int SectionId
        {
            get;
            set;  
        }
        public string Section
        {
            get;
            set;
        }
        public string SectionName  
        {
            get;
            set;
        }  
        public int ColumnId
        {
            get;
            set;
        }
        public string Column
        {
            get;
            set;
        }
        public string ColumnName   
        {
            get;
            set;
        }
        public bool Read
        {
            get;
            set;
        }
        public bool Write
        {
            get;
            set;
        }
        public bool AllReadWritePermission
        {
            get;
            set;
        }

        public string Sorting  
        {
            get;
            set;
        }

        public bool SalesView  
        {
            get;
            set;
        }

        public int OrderBy1
        {
            get;
            set;
        }

        public int OrderBy2
        {
            get;
            set;
        }

        public int OrderBy3
        {
            get;
            set;
        }

        public int OrderBy4
        {
            get;
            set;
        }

        public int OrderBy5
        {
            get;
            set;
        }

        public int OrderBy6
        {
            get;
            set;
        }
    }
}
