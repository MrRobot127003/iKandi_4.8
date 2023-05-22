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



namespace iKandi.Web
{
    public partial class Pendingimages :BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
            }
        }

        private void BindControls()
        {
            if (!IsPostBack)
            {
                DropdownHelper.BindClients(ddlClients);
                if (ddlClients.Items.Count > 1)
                    ddlClients.SelectedIndex = 1;
            }


            DataSet ds = this.ReportControllerInstance.GetPendingImagesReport(Convert.ToInt32(ddlClients.SelectedValue), txtSearchText.Text);
            grdPendingImages.DataSource = ds.Tables[0];
            grdPendingImages.DataBind();
        
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindControls();
        }


    }
}