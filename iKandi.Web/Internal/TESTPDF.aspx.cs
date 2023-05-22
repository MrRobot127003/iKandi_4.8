using System;
using System.Web.UI;
using iKandi.BLL;

namespace iKandi.Web.Internal
{
    public partial class TESTPDF : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var pdf = new PDFController();
            //pdf.GeneratePDFCriticalPath("");
        }
    }
}