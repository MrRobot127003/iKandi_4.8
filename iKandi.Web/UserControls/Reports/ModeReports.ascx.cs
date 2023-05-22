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
    public partial class ModeReports :BaseUserControl
    {
        public Int32 result;
        DataSet ds = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindControls();
            
        }

        private void BindControls()
        { 
            if(!IsPostBack)
              DropdownHelper.BindStatusMode(ddlWorkFlowMode);

            ds = this.ReportControllerInstance.GetModeReports(Convert.ToInt32(ddlWorkFlowMode.SelectedValue));
            grdModeReports.DataSource = ds.Tables[0];
            grdModeReports.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
           BindControls();          
        }

        protected void grdModeReports_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType != DataControlRowType.DataRow)
                return;

            //if(Convert.ToString(ds.Tables[0].Rows[e.Row.RowIndex]["StatusMode"]) == "CANCELLED")
            //    ((HyperLink)e.Row.FindControl("hlkLiability")).NavigateUrl = "/Internal/Sales/Liability.aspx?orderDetailId=" + ds.Tables[0].Rows[e.Row.RowIndex]["OrderDetailID"];

            
        }

    }






}