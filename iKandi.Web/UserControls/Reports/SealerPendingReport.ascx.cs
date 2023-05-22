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
    public partial class SealerPendingReport :BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindClients(ddlClients);
                if (ddlClients.Items.Count > 1)
                    ddlClients.SelectedIndex = 1;
            }
        }

        private void BindControls()
        {
          
            DataSet ds = this.ReportControllerInstance.GetSealerPendingOrdersReport(Convert.ToInt32(ddlClients.SelectedValue), txtSearch.Text);
            grdSealerPending.DataSource = ds.Tables[0];
            grdSealerPending.DataBind();
                 
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }
    }
}