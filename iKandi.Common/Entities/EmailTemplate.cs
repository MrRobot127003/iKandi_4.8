using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class EmailTemplate
    {
        public int EmailTemplateID
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Subject
        {
            get;
            set;
        }

        public string Content
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public EmailTemplateType TemplateType
        {
            get;
            set;
        }

        public string DepartmentIDs
        {
            get;
            set;
        }

        public string DesignationIDs
        {
            get;
            set;
        }
    }

    public class EmailSchedule : EmailTemplate
    {
        public long EmailScheduleID
        {
            get;
            set;
        }

        public string Time
        {
            get;
            set;
        }

        public string DayS
        {
            get;
            set;
        }

        public int DayI
        {
            get;
            set;
        }

        public DateTime DateTime
        {
            get;
            set;
        }

        public DayOfWeek DayOfWeek
        {
            get;
            set;
        }
    }
}
