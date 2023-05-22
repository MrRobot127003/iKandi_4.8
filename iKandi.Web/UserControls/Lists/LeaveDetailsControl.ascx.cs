using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.Common;


namespace iKandi.Web
{
    public partial class LeaveDetailsControl : BaseUserControl
    {
        public long LeaveID
        {
            get;
            set;
        }

        public string LeaveType { get; set; }
        public string LeaveStatus { get; set; }
        public string FromSession { get; set; }
        public string ToSession { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string DaysOnLeave { get; set; }
        public string Reason { get; set; }
        public string AppliedTo { get; set; }
        public string ContactDetails { get; set; }
        public string Comment { get; set; }
        public string RequestDate { get; set; }
        public string ActionDate { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            long leaveID = this.LeaveID; //Convert.ToInt64(Request.QueryString["id"]);
            Leave currentLeave = this.LeaveControllerInstance.GetLeave(leaveID);
            if (currentLeave != null)
            {
                LeaveType = currentLeave.Type.ToString();
                LeaveStatus = currentLeave.Status.ToString();
                FromSession = currentLeave.FromSession == 0 ? "Morning" : "AfterNoon";
                ToSession = currentLeave.ToSession == 0 ? "Morning" : "AfterNoon";
                FromDate = currentLeave.FromDate != DateTime.MinValue ? currentLeave.FromDate.ToString("dd MMM yy (ddd)") : "";
                ToDate = currentLeave.ToDate != DateTime.MinValue ? currentLeave.ToDate.ToString("dd MMM yy (ddd)") : "";
                RequestDate = currentLeave.RequestDate != DateTime.MinValue ? currentLeave.RequestDate.ToString("dd MMM yy (ddd)") : "";
                ActionDate = currentLeave.ActionDate != DateTime.MinValue ? currentLeave.ActionDate.ToString("dd MMM yy (ddd)") : "";
                DaysOnLeave = currentLeave.NetLeaves.ToString();
                Reason = currentLeave.Reason ?? "";
                ContactDetails = currentLeave.ContactDetails ?? "";
                Comment = "NOT AVAILABLE";
                AppliedTo = currentLeave.AppliedTo.FullName;
            }
        }
    }
}