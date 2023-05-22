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
using iKandi.Common;

namespace iKandi.Web
{
    public partial class Public : System.Web.UI.MasterPage
    {
        #region Proerties

        private string Message
        {
            get
            {
                return Request["message"];
            }
        }

        private string ErrorMessage
        {
            get
            {
                return Request["errorMessage"];
            }
        }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string baseSiteUrl = Constants.BaseSiteUrl.ToUpper().Replace("HTTP://", "").Replace("WWW.", "");
            string siteBaseUrl = Constants.SITE_BASE_URL.ToUpper().Replace("HTTP://", "").Replace("WWW.", "");
            if (baseSiteUrl.Contains(siteBaseUrl))
            {
                boutiquelogo.ImageUrl = "~/App_Themes/ikandi/images/ikandi.gif"; 
                //boutiquelogo.CssClass = "logo";
                Title.Text = "IKANDI FASHION";
                link1.HRef = "/ikand/corporate.html";
                link2.HRef = "/ikand/products.html";
                link3.HRef = "/ikand/presspictures.html";
                link4.HRef = "/ikand/news.html";
                link5.HRef = "/ikand/contact.html";
            }
            else
            {
                boutiquelogo.ImageUrl = "~/App_Themes/ikandi/images/new-boutique-logo.png";
                Title.Text = "Boutique International Pvt. Ltd.";
                link1.HRef = "/bipl/corporate.html";
                link2.HRef = "/bipl/products.html";
                link3.HRef = "/bipl/presspictures.html";
                link4.HRef = "/bipl/news.html";
                link5.HRef = "/bipl/contact.html";
            }
            string script = string.Empty;

            if (null != ErrorMessage)
            {
                script = "ShowHideValidationBox(true, '" + ErrorMessage + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
            }
            else if (null != Message)
            {
                script = "ShowHideMessageBox(true, '" + Message + "');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowMessage", script, true);
            }
            if (Request.Path.ToLower().IndexOf("changepassword.aspx") > -1)
            {
                link1.Visible = false;
                link2.Visible = false;
                link3.Visible = false;
                link4.Visible = false;
                link5.Visible = false;
                LoginStatus1.Visible = false;
            }
        }
    }
}
