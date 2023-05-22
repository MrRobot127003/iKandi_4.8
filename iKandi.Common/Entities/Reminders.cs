using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace iKandi.Common
{
    public class Reminders
    {
            public int ReminderID
            {
                get;
                set;
            }

            public int OrderID
            {
                get;
                set;
            }
            public int OrderDetailID
            {
                get;
                set;
            }

            public int TaskID
            {
                get;
                set;
            }

            public string TaskName
            {
                get;
                set;
            }

            public string TaskShort
            {
                get;
                set;
            }

            public string TaskType
            {
                get;
                set;
            }

            public string TaskDescription
            {
                get;
                set;
            }

            public DateTime TaskDueDate
            {
                get;
                set;
            }

            public int UserID
            {
                get;
                set;
            }

            public string UserName
            {
                get;
                set;
            }


            public DateTime ActionDate
            {
                get;
                set;
            }

            public DateTime ClosedDate
            {
                get;
                set;
            }           

            public int Active
            {
                get;
                set;
            }

            

    }
}
