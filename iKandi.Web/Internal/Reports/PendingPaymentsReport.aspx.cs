using System;
using System.Web.UI;

namespace iKandi.Web
{
    public partial class PendingPaymentsReport : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.EnableEventValidation = false;
            //this.EnableViewState = false;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }
    }
}