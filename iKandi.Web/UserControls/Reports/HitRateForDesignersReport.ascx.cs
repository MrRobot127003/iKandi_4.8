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
using iKandi.Common;


namespace iKandi.Web
{
    public partial class HitRateForDesignersReport : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        public void BindControls()
        {
            int UserId = ApplicationHelper.LoggedInUser.UserData.UserID;
            DataSet ds = this.ReportControllerInstance.GetHitRateForDesigners(UserId);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lbltotalsamplesmadeyear.Text = (ds.Tables[0].Rows[0]["TotalSamplesMadeThisYear"] == DBNull.Value) ? string.Empty : Convert.ToDouble(ds.Tables[0].Rows[0]["TotalSamplesMadeThisYear"]).ToString("N0");
                }
                if (ds.Tables[1].Rows.Count > 0)
                {
                    lbltotalsamplessoldyear.Text = (ds.Tables[1].Rows[0]["TotalSamplesBookedThisYear"] == DBNull.Value) ? string.Empty : Convert.ToDouble(ds.Tables[1].Rows[0]["TotalSamplesBookedThisYear"]).ToString("N0");
                   
                }
                if (ds.Tables[2].Rows.Count > 0)
                {
                    lbltotalsamplesmademonth.Text = (ds.Tables[2].Rows[0]["TotalSamplesMadeThisMonth"] == DBNull.Value) ? string.Empty : Convert.ToDouble(ds.Tables[2].Rows[0]["TotalSamplesMadeThisMonth"]).ToString("N0");
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    lbltotalsamplessoldmonth.Text = (ds.Tables[3].Rows[0]["TotalSamplesBookedThisMonth"] == DBNull.Value) ? string.Empty : Convert.ToDouble(ds.Tables[3].Rows[0]["TotalSamplesBookedThisMonth"]).ToString("N0");
                }
                if(lbltotalsamplesmadeyear.Text != string.Empty &&  Convert.ToInt32(lbltotalsamplesmadeyear.Text) > 0)
                {
                    lbltargetrate.Text = ((Convert.ToInt32(lbltotalsamplessoldyear.Text) * 100) / Convert.ToInt32(lbltotalsamplesmadeyear.Text)).ToString() + "%";
                }
            }
        }
    }
}