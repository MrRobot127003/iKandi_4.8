using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iKandi.Web.UserControls.Lists
{
    public partial class frmSizePopup : System.Web.UI.UserControl
    {
        public int OrderDetailID
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["OrderDetailID"])
            {
                OrderDetailID = Convert.ToInt32(Request.QueryString["OrderDetailID"]);
            }
            odsBasicInfo.SelectParameters.Add("OrderDetailID", this.OrderDetailID.ToString());
        }
    }
}