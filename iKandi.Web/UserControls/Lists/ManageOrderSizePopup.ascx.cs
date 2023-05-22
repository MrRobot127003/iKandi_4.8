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


namespace iKandi.Web
{
    public partial class ManageOrderSizePopup : System.Web.UI.UserControl
    {
        public int OrderDetailID
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
          
            odsBasicInfo.SelectParameters.Add("OrderDetailID", this.OrderDetailID.ToString());

        }
    }
}