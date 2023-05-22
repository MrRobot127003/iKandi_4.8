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


namespace iKandi.Web
{
    public partial class FabricPrices : BaseUserControl
    {
        public DataSet ds;

        #region Event Handler

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

                Bindcontrols();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bindcontrols();
        }

        #endregion


        #region Private Method
        
        private void Bindcontrols()
        {

            if (!string.IsNullOrEmpty(Request.QueryString["PageIndex"]))
            {
                this.HyperLinkPager1.PageIndex = Convert.ToInt32(Request.QueryString["PageIndex"]);
            }
            else
            {
                this.HyperLinkPager1.PageIndex = 0;
            }

            int TotalRowCount = 0;

            ds = this.ReportControllerInstance.GetFabricPrices(HyperLinkPager1.PageSize, (!string.IsNullOrEmpty(Request.QueryString["PageIndex"])) ? Convert.ToInt32(Request.QueryString["PageIndex"]) : 0, out TotalRowCount, Convert.ToString(txtSearchText.Text) , Convert.ToString(txtPriceFrom.Text), Convert.ToString(txtPriceTo.Text));

            grdFabricPrices.DataSource = ds.Tables[0];
            grdFabricPrices.DataBind();

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();
        }
                
        #endregion


    }
}