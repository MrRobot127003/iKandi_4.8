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
    public partial class ClientSummaryReport : BaseUserControl
    {

        public int ClientId
        {
            get;
            set;
        }

        DataSet ds;

        protected void Page_Load(object sender, EventArgs e)
        {
            ds = this.ReportControllerInstance.GetOrderSummaryReportClientSummary(this.ClientId);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblBuyer.Text = ds.Tables[0].Rows[0]["CompanyName"].ToString();
                    lblTotalQuantity.Text = ds.Tables[0].Rows[0]["TotalQuantity"].ToString();
                    lblTotalOrders.Text = ds.Tables[0].Rows[0]["TotalOrders"].ToString();
                }

                if (ds.Tables[1].Rows.Count > 0)
                {
                    lblQuantity.Text = ds.Tables[1].Rows[0]["Quantity"].ToString();
                    //lblExFactory.Text = ds.Tables[1].Rows[0]["ExFactory"].ToString();
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    basic.Text = ds.Tables[2].Rows[0]["BulkInHouseThisWeek"].ToString();

                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    lblQuantity.Text = ds.Tables[2].Rows[0]["BulkInHouseThisWeek"].ToString();

                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    lblQuantity.Text = ds.Tables[3].Rows[0]["BulkInHouseThisWeek"].ToString();

                }
                if (ds.Tables[4].Rows.Count > 0)
                {
                    lblQuantity.Text = ds.Tables[4].Rows[0]["PcsCutThisWeek"].ToString();

                }
                if (ds.Tables[5].Rows.Count > 0)
                {
                    lblQuantity.Text = ds.Tables[5].Rows[0]["PcsStitchedThisweek"].ToString();

                }

            }

        }
    }
}