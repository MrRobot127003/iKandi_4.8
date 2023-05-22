using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.Common;
using iKandi.Web.Components;
using System.Collections.Generic;
using iKandi.BLL;
using System.Configuration;
using System;

namespace iKandi.Web.Internal.Merchandising
{
    public partial class frmCMTCalculator : System.Web.UI.Page
    {        
        public static int Quantity
        {
            get;
            set;
        }

        public static int SAM
        {
            get;
            set;
        }
        public static int OrderDetailID
        {
            get;
            set;
        }
        public static int OB
        {
            get;
            set;
        }
        public static int Eff
        {
            get;
            set;
        }
        public static DateTime StartDate
        {
            get;
            set;
        }
        iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            GetQueryString();
            if (!Page.IsPostBack)
            {
                BindCMT();
            }
        }

        
        public void BindCMT()
        {
            DataSet ds = obj_ProcessController.GetCMTInfo(OrderDetailID);            
            DataTable dtCMTCalculator = ds.Tables[0];
            lblCMTSAM.Text = dtCMTCalculator.Rows[0]["SAM"].ToString();
            txtCMTQuantity.Text = dtCMTCalculator.Rows[0]["Quantity"].ToString();
            txtCMTOB.Text = dtCMTCalculator.Rows[0]["OB"].ToString();
            txtCMTEff.Text = dtCMTCalculator.Rows[0]["Eff"].ToString();
            lblCMTPcsPerHour.Text = dtCMTCalculator.Rows[0]["PcsPerHr"].ToString();
            lblCMTPcsPerDay.Text = dtCMTCalculator.Rows[0]["PcsPerDay"].ToString();
            lblCMTNoOfDays.Text = dtCMTCalculator.Rows[0]["NoOfDays"].ToString();
            txtCMTStartDate.Text = Convert.ToDateTime(dtCMTCalculator.Rows[0]["StartDate"]) == DateTime.MinValue ? "" : Convert.ToDateTime(dtCMTCalculator.Rows[0]["StartDate"]).ToString("dd MMM yy (ddd)");

           
            if (dtCMTCalculator.Rows[0]["Holiday"].ToString()!="0")
            {
                lblCMTHolidays.Text = dtCMTCalculator.Rows[0]["Holiday"].ToString();
            }
            lblCMTEndDate.Text = Convert.ToDateTime(dtCMTCalculator.Rows[0]["EndDate"]) == DateTime.MinValue ? "" : Convert.ToDateTime(dtCMTCalculator.Rows[0]["EndDate"]).ToString("dd MMM yy (ddd)");
            if (lblCMTEndDate.Text == "01 Jan 00 (Mon)")
                lblCMTEndDate.Text = txtCMTStartDate.Text;

        }
       

        public void GetQueryString()
        {
         
            if (Request.QueryString["OrderDetailID"] != null)
            {
                OrderDetailID = Convert.ToInt32(Request.QueryString["OrderDetailID"]);
            }
        }
        

        protected void btnResetCMT_Click(object sender, EventArgs e)
        {
            BindCMT();
        }


    }
}