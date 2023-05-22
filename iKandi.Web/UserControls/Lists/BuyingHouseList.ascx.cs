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
using iKandi.Common;


namespace iKandi.Web.UserControls.Lists
{
    public partial class BuyingHouseList : BaseUserControl
    {
        List<iKandi.Common.BuyingHouse> objbh = new List<iKandi.Common.BuyingHouse>();

        # region Fields
        int TotalRowCount = 0;
        # endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Request.QueryString["btn"]) == "1")
            {
                HtmlInputButton htmbtn = (HtmlInputButton)this.FindControl("btnPrint");
                htmbtn.Attributes.Add("style", "display:none");
            }
            BindControls();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType != DataControlRowType.DataRow)
            //    return;
            //HiddenField hdnBHID = e.Row.FindControl("hdnBHID") as HiddenField;
            //int BHId = Convert.ToInt32(hdnBHID.Value);

            //GridView grd = e.Row.FindControl("grdAssisment") as GridView;
            //grd.DataSource = this.ClientControllerInstance.GetClientListAssismentByClientID(ClientId);
            //grd.DataBind();
        }

        # region Methods
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

            //System.Diagnostics.Debugger.Break();
            objbh = this.BuyingHouseController.GetAllBuyingHouse();

            GridView1.DataSource = objbh;
            GridView1.DataBind();

            this.HyperLinkPager1.TotalRecords = TotalRowCount;
            //this.HyperLinkPager1.PageIndex = 1;
            int TotalPageCount = this.HyperLinkPager1.CalculateTotalPages();

        }
        # endregion

    }
}