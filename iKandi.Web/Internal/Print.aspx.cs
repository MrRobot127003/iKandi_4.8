using System;
using System.Web;
using System.Web.UI;

namespace iKandi.Web
{
    public partial class PrintPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////System.Diagnostics.Debugger.Break();

            if (Session["PRINT_HTML"] == null)
            {
                HttpContext.Current.Response.Write("<script>window.close();</script>");
                return;
            }

            string html = Session["PRINT_HTML"].ToString();

            HttpContext.Current.Response.Write(html);
            HttpContext.Current.Response.Write("<script>window.print();</script>");


            Session.Remove("PRINT_HTML");
        }
    }
}