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
using System.IO;

namespace iKandi.Web
{
    public partial class FabricQualities : BaseUserControl
    {
        public DataSet ds;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bindcontrols();
            }
        }

        protected void grdRegistered_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdRegistered.PageIndex = e.NewPageIndex;
            hdnPagesize.Value = grdRegistered.PageSize.ToString();
            hdnPageIndex.Value = grdRegistered.PageIndex.ToString();
            Bindcontrols();
        }

        protected void grdUnRegistered_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdUnRegistered.PageIndex = e.NewPageIndex;
            hdnPagesize.Value = grdUnRegistered.PageSize.ToString();
            hdnPageIndex.Value = grdUnRegistered.PageIndex.ToString();
            Bindcontrols();
        }

        public void grdRegistered_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                HyperLink hlkFabric = e.Row.FindControl("hlkFabric") as HyperLink;
                if(!String.IsNullOrEmpty(ds.Tables[0].Rows[e.Row.RowIndex]["Id"].ToString()) && Convert.ToInt32(ds.Tables[0].Rows[e.Row.RowIndex]["Id"]) > 0)
                hlkFabric.NavigateUrl = "/Internal/Fabric/FabricQualityEdit.aspx?fabricqualityid=" + Convert.ToInt32(ds.Tables[0].Rows[e.Row.RowIndex]["Id"]);
                
               
            }

        }

        private void Bindcontrols()
        {
            hdnPagesize.Value = grdRegistered.PageSize.ToString();
            hdnPageIndex.Value = grdRegistered.PageIndex.ToString();

            hdnPagesize1.Value = grdUnRegistered.PageSize.ToString();
            hdnPageIndex2.Value = grdUnRegistered.PageIndex.ToString();

            ds = this.FabricQualityControllerInstance.GetRegisteredFabrics();

            grdRegistered.DataSource = ds;
            grdRegistered.DataBind();

            grdUnRegistered.DataSource = this.FabricQualityControllerInstance.GetUnRegisteredFabrics();
            grdUnRegistered.DataBind();
        }
    }
}