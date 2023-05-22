using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;

namespace iKandi.Web
{
    public partial class FabricQualityPopup : BaseUserControl
    {
        #region Properties

        public int FabricQualityID
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
            FabricQuality fq = this.FabricQualityControllerInstance.GetFabricQualityByID(this.FabricQualityID);

            lblGroup.Text = fq.Group.ToUpper();
            lblSubGroup.Text = fq.SubGroup.ToUpper();
            lblCountConstruction.Text = fq.CountConstruction.ToUpper();
            lblComposition.Text = fq.Composition.ToUpper();
            lblGSM.Text = fq.GSM.ToString("0.##");
            lblMinOrderQty.Text = fq.MinimumOrderQuantity.ToString() + (lblGroup.Text.ToLower().Contains("knitted") ? "Kg." : "M.");
            lblLeadTimeDyed.Text = fq.LeadTimeForDyed.ToString();
            lblLeadTimePrinted.Text = fq.LeadTimeForPrinted.ToString();
            lblPriceDyed.Text = (fq.Origin == (int)Origin.India)? ("IN-Rs. " + fq.PriceDyedIndian.ToString("0.##")) :  ("IM(A)-Rs. " + fq.PriceForDyedByAir.ToString("0.##") + ", IM(S)-Rs. " + fq.PriceForDyedBySea.ToString("0.##"));
            lblPricePrinted.Text = (fq.Origin == (int)Origin.India)?  ("IN-Rs. " + fq.PricePrintedIndian.ToString("0.##")): ("IM(A)-Rs. " + fq.PriceForPrintedByAir.ToString("0.##") + ", IM(S)-Rs. " + fq.PriceForPrintedBySea.ToString("0.##"));

            hypLink.NavigateUrl = ResolveUrl("~/internal/fabric/FabricQualityEdit.aspx?fabricqualityid=" + this.FabricQualityID.ToString() );

        }
    }
}