using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iKandi.Web
{
    public partial class POValueadditionReplica : System.Web.UI.Page
    {
        public string RiskVA_SupplierId
        {
            get;
            set;
        }
        public string VA_SupplierName
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["RiskVASupplierId"] != null)
            {
                RiskVA_SupplierId = Request.QueryString["RiskVASupplierId"].ToString();
            }

            if (Request.QueryString["VA_SupplierName"] != null)
            {
                VA_SupplierName = Request.QueryString["VA_SupplierName"].ToString();
            }
            SupplierName.InnerText = VA_SupplierName.ToString();
           
            string WriteFile = "";

            string Attandence_url = "POValueaddition_" + RiskVA_SupplierId + ".pdf";
            WriteFile = "http://boutique.in:82/Uploads/Fits/" + Attandence_url;
           // hlkPO.NavigateUrl = WriteFile;
        }
    }
}