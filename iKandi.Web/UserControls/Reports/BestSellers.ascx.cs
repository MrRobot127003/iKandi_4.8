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
using iKandi.BLL;
using iKandi.Common;
using iKandi.Web.Components;
using System.Collections.Generic;

namespace iKandi.Web
{
    public partial class BestSellers : BaseUserControl
    {
        DataSet ds = new DataSet();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            BindControls();
        }

        private void BindControls()
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

            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            ds = this.ReportControllerInstance.GetBestSellers(HyperLinkPager1.PageSize, (!string.IsNullOrEmpty(Request.QueryString["PageIndex"])) ? Convert.ToInt32(Request.QueryString["PageIndex"]) : 0, out TotalRowCount, Convert.ToInt32(ddlBest.SelectedValue), Convert.ToInt32(ddlLimit.SelectedValue));
            grdBestsellers.DataSource = ds.Tables[0];
            grdBestsellers.DataBind();

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }

        
    }
}