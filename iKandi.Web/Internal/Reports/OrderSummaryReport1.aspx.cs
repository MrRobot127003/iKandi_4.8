using System;

namespace iKandi.Web
{
    public partial class OrderSummaryReport1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        private void BindControls()
        {
            //DropdownHelper.BindClients(ddlClients as ListControl);
        }
    }
}