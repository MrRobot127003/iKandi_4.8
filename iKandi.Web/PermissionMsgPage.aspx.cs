using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iKandi.Web
{
    public partial class PermissionMsgPage : System.Web.UI.Page
    {
        public string Mgs
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["Mgs"])
            {
                lblpagename.Text = Request.QueryString["Mgs"].ToString();
            }

        }
    }
}