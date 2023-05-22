using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using iKandi.Common;
using System.Collections.Generic;
using iKandi.BLL;


namespace iKandi.Web
{
    public partial class _Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Url.OriginalString.Contains("ikandi"))
            {
                //Request.Url.OriginalString.Replace("/Default.aspx", "").ToString();
                Response.Redirect("ikand/index.html");
                return;
            }
            if (Request.Url.OriginalString.Contains("boutique"))
            {
                Response.Redirect("bipl/index.html");
                return;
            }
            Response.Redirect("~/public/login.aspx");
        }
    }
}
