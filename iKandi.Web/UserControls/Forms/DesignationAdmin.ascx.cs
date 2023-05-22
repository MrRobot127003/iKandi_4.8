using System;
using System.Collections;
using System.Collections.Generic;
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
using iKandi.Web.Components;
using iKandi.Common;
using System.IO;
using System.Globalization;

namespace iKandi.Web.UserControls.Forms
{
    public partial class DesignationAdmin : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
                bindGrid();
        }
        public void bindGrid()
        {
            AdminController objAdminController = new AdminController();
            DataSet ds = objAdminController.GetClientBAL();
            grdDes.DataSource = ds.Tables[0];
            grdDes.DataBind();
        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {

        }

        protected void grdDes_PageIndexChanged(object sender, EventArgs e)
        {
           // bindGrid(); grdDes.PageIndex = e.NewPageIndex; grdDes.DataBind(); 
        }

        protected void grdDes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           bindGrid(); grdDes.PageIndex = e.NewPageIndex; grdDes.DataBind();
        }
    }
}