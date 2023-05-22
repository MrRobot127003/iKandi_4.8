using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class ApplicationModule
    {
        public int ApplicationModuleID
        {
            get;
            set;
        }

        public string ApplicationModuleName
        {
            get;
            set;
        }

        public PageType Type
        {
            get;
            set;
        }

        public string Path
        {
            get;
            set;
        }

        public int SubPhaseID
        {
            get;
            set;
        }

        public Boolean IncludeInNavigation
        {
            get;
            set;
        }

        public int StatusModeID
        {
            get;
            set;
        }

        public List<ApplicationModuleColumn> Columns
        {
            get;
            set;
        }

    }

    public class ApplicationModuleColumn
    {
        public int ApplicationModuleColumnID
        {
            get;
            set;
        }

        public string ApplicationModuleColumnName
        {
            get;
            set;
        }
    }
    
}
