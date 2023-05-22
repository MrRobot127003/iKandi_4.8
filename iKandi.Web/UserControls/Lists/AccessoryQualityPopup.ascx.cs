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
    public partial class AccessoryQualityPopup : BaseUserControl
    {
        #region Properties

        public int AccessoryQualityID
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
            AccessoryQuality aq = this.AccessoryQualityControllerInstance.GetAccessoryQualityById(this.AccessoryQualityID);

            lblGroup.Text = aq.CategoryName.ToUpper();
            lblSubGroup.Text = aq.SubCategoryName.ToUpper();
            lblDesc.Text = aq.Composition.ToUpper();
            lblWst.Text = aq.Wastage.ToString("N0");
            lblLeadTime.Text = aq.LeadTime.ToString();
            lblPrice.Text = aq.Price.ToString("0.##");

            hypLink.NavigateUrl = ResolveUrl("~/internal/fabric/AccessoryQualityEdit.aspx?accessoryqualityid=" + this.AccessoryQualityID.ToString());

        }
    }
}