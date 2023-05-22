using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iKandi.Web
{
    public partial class POStitchReplica : System.Web.UI.Page
    {
        public int OrderDetailId
        {
            get;
            set;
        }
        public int LocationType
        {
            get;
            set;
        }
        public string SupplierName
        {
            get;
            set;
        }
        public string StyleNumber
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["OrderDetailId"] != null)
            {

                OrderDetailId = Convert.ToInt32(Request.QueryString["OrderDetailId"]);

            }
            else
                OrderDetailId = 33171;

            if (Request.QueryString["LocationType"] != null)
            {
                LocationType = Convert.ToInt32(Request.QueryString["LocationType"]);
            }
            else
                LocationType = 1;

            if (Request.QueryString["SupplierName"] != null)
            {
                SupplierName = Request.QueryString["SupplierName"];
            }
            if (Request.QueryString["StyleNumber"] != null)
            {
                StyleNumber = Request.QueryString["StyleNumber"];
            }
            SupplierNameEmail.InnerText = SupplierName.ToString();

            string WriteFile = "";

            string Attandence_url = "POStitchOutHouse_" + OrderDetailId + "_" + LocationType + ".pdf";
            WriteFile = "http://boutique.in:82/Uploads/Fits/" + Attandence_url;

        }
    }
}