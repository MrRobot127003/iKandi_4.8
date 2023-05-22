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
using System.Collections.Generic;
using iKandi.Web.Components;

namespace iKandi.Web.UserControls.Reports
{
    public partial class QuoteTool : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtQuoteTool = Session["quotetool"] as DataTable;

            if (dtQuoteTool == null || dtQuoteTool.Rows.Count == 0)
                dtQuoteTool = this.ReportControllerInstance.GetAllQuoteToolInformation();

            if (dtQuoteTool != null && dtQuoteTool.Rows.Count > 0)
                dtQuoteTool.DefaultView.Sort = "StyleNumber ASC";

            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("QuoteToolDataTable", dtQuoteTool);

            divQuoteTool.InnerHtml = PageHelper.GetControlHtml("~/UserControls/Lists/QuoteToolList.ascx", properties);
        }
    }
}