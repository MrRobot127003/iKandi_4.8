using System;

namespace iKandi.Web.Internal.Merchandising
{
    public partial class QualityControlHistory : BasePage
    {
        private const string SIMPLE_MASTER_PAGE_PATH = "/layout/SimpleSecure.Master";

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            MasterPageFile = SIMPLE_MASTER_PAGE_PATH;
        }
    }
}