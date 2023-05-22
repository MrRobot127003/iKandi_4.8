using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iKandi.Common
{
    public class UserTask
    {
        public int ID { get; set; }
        public DateTime ETA { get; set; }
        public DateTime ActionDate { get; set; }
        public int ActionedBy { get; set; }
        public string ActionedByUsername { get; set; }
        public Style Style { get; set; }
        public Order Order { get; set; }
        public OrderDetail OrderDetail { get; set; }
        public int IntField1 { get; set; }
        public int IntField2 { get; set; }
        public int IntField3 { get; set; }
        public string TextField1 { get; set; }
        public string TextField2 { get; set; }
        public int AssignedToDesigntation { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByUsername { get; set; }
        public DateTime CreatedOn { get; set; }
        public UserTaskType Type { get; set; }
        public Fits Fit { get; set; }

        public DateTime _estBihDate { get; set; }
        public DateTime _BulkTarget { get; set; }


    }


    public class TeamTaskCount
    {
        public string Dept_Name { get; set; }

        public int Task_Count { get; set; }

        public ListUserTask ListUtc { get; set; }
    }

    public class ListTeamTask : List<TeamTaskCount>
    {
        
    }

    public class UserTaskCount
    {
        public int TaskId { get; set; }

        public string Task_Name { get; set; }

        public int Task_Count { get; set; }

        public string Task_Designation { get; set; }

        public string Description { get; set; }
    }

    public class ListUserTask:List<UserTaskCount>
    {
        
    }
}
