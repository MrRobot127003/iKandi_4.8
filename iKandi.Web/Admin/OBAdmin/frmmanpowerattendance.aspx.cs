using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace iKandi.Web.Admin.OBAdmin
{
    public partial class frmmanpowerattendance : System.Web.UI.Page
    {

        public string UserId
        {
            get;
            set;
        }
        public string Date
        {
            get;
            set;

        }
        public int OTs
        {
            get;
            set;

        }
        public int FactoryWorkId
        {
            get;
            set;

        }

        public int Edit
        {
            get;
            set;

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (null != Request.QueryString["Date"])
            {
                Date = Request.QueryString["Date"].ToString();
            }
            if (null != Request.QueryString["FactoryWorkId"])
            {
                FactoryWorkId = Convert.ToInt32(Request.QueryString["FactoryWorkId"].ToString());
            }
            if (null != Request.QueryString["OTs"])
            {
                OTs = Convert.ToInt32(Request.QueryString["OTs"].ToString());
            }
            if (null != Request.QueryString["Edit"])
            {
                Edit = Convert.ToInt32(Request.QueryString["Edit"].ToString());
            }


            this.Usermanpowerattendence1.Visible = true;
            this.frmuserOtattendence1.Visible = true;

            if (null != Request.QueryString["Date"])
            {
                
                Usermanpowerattendence1.Date = Request.QueryString["Date"].ToString();
                Usermanpowerattendence1.OTs = Convert.ToInt32(Request.QueryString["OTs"].ToString());
                Usermanpowerattendence1.FactoryWorkId = Convert.ToInt32(Request.QueryString["FactoryWorkId"].ToString());
                Usermanpowerattendence1.Edit = Convert.ToInt32(Request.QueryString["Edit"].ToString());

                frmuserOtattendence1.Date = Request.QueryString["Date"].ToString();
                frmuserOtattendence1.OTs = Convert.ToInt32(Request.QueryString["OTs"].ToString());
                frmuserOtattendence1.FactoryWorkId = Convert.ToInt32(Request.QueryString["FactoryWorkId"].ToString());
                frmuserOtattendence1.Edit = Convert.ToInt32(Request.QueryString["Edit"].ToString());

            }
            else
            {
                this.Usermanpowerattendence1.Visible = true;
                this.frmuserOtattendence1.Visible = true;
            }

        }

        protected void rbtnAtteType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int AttendanceType = Convert.ToInt32(rbtnAtteType.SelectedValue);
            if (AttendanceType == 1)
            {
                this.Usermanpowerattendence1.Visible = true;
                this.frmuserOtattendence1.Visible = false;
            }
            else
            {
                this.Usermanpowerattendence1.Visible = false;
                this.frmuserOtattendence1.Visible = true;

            }
        }
    }
}