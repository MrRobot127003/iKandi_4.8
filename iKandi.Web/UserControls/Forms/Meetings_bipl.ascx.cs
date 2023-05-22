using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using iKandi.BLL;
using System.Data;
using iKandi.Common.Entities;

namespace iKandi.Web.UserControls.form
{
    public partial class Meetings_bipl : System.Web.UI.UserControl
    {
        FabricController objfab = new FabricController();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindddl();
            }


        }
        public void Bindddl()
        {

            DataTable dt = objfab.GetEventOccurence();
            //ddlaccurrence.DataSource = dt;
            //ddlaccurrence.DataTextField = "CategoryName";
            //ddlaccurrence.DataValueField="MeetingCategory_Id";
            //ddlaccurrence.DataBind();
            //ddlaccurrence.Items.Insert(0, new ListItem("Select Occurrence", "-1"));

        }
        public void btnAdd_Click(object sender, EventArgs e)
        {
            //SaveBiplMeetingInfo(int MeetingSchedule_Id; int MeetingCategory_Id; string MeetingName; int TimeZone; int Month; int Day; string Time; int IsManual; int Manual_TimeZone; int Manual_Month; int Manual_Day; string Manual_Time; string Participate; string Description)
            //string MeetingName = "";
            //int MeetingCategory_Id; 
            //string MeetingName; int TimeZone; int Month; int Day; string Time; int IsManual; int Manual_TimeZone; int Manual_Month; int Manual_Day; string Manual_Time; string Participate; string Description;

        }
        
    }
}