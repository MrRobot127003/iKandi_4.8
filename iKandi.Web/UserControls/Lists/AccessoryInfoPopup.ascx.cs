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
    public partial class AccessoryInfoPopup : BaseUserControl
    {
        #region Properties

        public int AccessoryWorkingDetailID
        {
            get;
            set;
        }



        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                BindControls();
        }

        private void BindControls()
        {
            AccessoryWorkingDetail awd = this.AccessoryWorkingControllerInstance.GetAccessoryWorkingDetailByID(this.AccessoryWorkingDetailID);

            lblType.Text = awd.AccessoryName;
            lblQty.Text = awd.Number.ToString("0.###");
            lblTotalQty.Text = awd.Quantity.ToString("N0");
            lblDetails.Text = awd.Details;
            lblIsDTM.Text = (awd.IsDTM) ? "YES" : "NO";

        }
    }
}