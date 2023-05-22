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
    public partial class OrderSummary1 :BaseUserControl
    {
        public string searchText
        {
            get;
            set;
        }

        public DateTime FromDate
        {
            get;
            set;
        }

        public DateTime ToDate
        {
            get;
            set;
        }
        public int ClientId
        {
            get;
            set;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            odsOrderSummaryReport.SelectParameters.Add("searchText",this.searchText);
            odsOrderSummaryReport.SelectParameters.Add("FromDate",this.FromDate.ToString());
            odsOrderSummaryReport.SelectParameters.Add("ToDate",this.ToDate.ToString());
            odsOrderSummaryReport.SelectParameters.Add("ClientID",this.ClientId.ToString());
          
        }




    }
}