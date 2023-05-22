using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.BLL;
using System.Data;
using System.Data.SqlClient;
using iKandi.Web.Components;


namespace iKandi.Web
{
    public partial class frmMainMMRReporets : System.Web.UI.Page
    {
        AdminController objAdminController = new AdminController();
        protected void Page_Load(object sender, EventArgs e)
        {
            //getdate.InnerText = DateTime.Now.ToString("dd.MMMM.yyyy");
            bindMMRReportDate();
           
        }
        public void bindMMRReportDate()
        {

            DataSet ds = objAdminController.GetMMRReportDate();
            //getdate.InnerText = ds.Tables[0].Rows[0]["MMRDate"].ToString();
            //getdate.InnerText = DateTime.Parse(ds.Tables[0].Rows[0]["MMRDate"].ToString()).ToLongDateString();


            //new code 

            getdate.InnerText = DateTime.Parse(ds.Tables[0].Rows[0]["MMRDate"].ToString()).ToString("dd MMM yy (ddd)");            
         
            //string MMRDate = ds.Tables[0].Rows[0]["MMRDate"].ToString();
            //getdate.InnerText = DateTime.ParseExact(MMRDate, "dd MMM yy (ddd)", System.Globalization.CultureInfo.InvariantCulture).ToString();
            
        }
    }
}