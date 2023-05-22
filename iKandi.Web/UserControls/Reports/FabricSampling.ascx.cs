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
using iKandi.Web.Components;

namespace iKandi.Web.UserControls.Reports
{
    public partial class FabricSampling :BaseUserControl
    {
        #region Event handler
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }

        # endregion
        #region Private method
        private void BindControls()
        {
            DataSet ds = this.ReportControllerInstance.GetFabricSamplingReport(txtSearchText.Text);
            grdFabricSampling.DataSource = ds.Tables[0];
            grdFabricSampling.DataBind();
        }
        #endregion


    }
}