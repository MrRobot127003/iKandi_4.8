using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Web.Components;
using iKandi.Common;
using System.Data;
using iKandi.BLL;
using System.ComponentModel;
using System.Collections;
using System.Configuration;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;

namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricQuality_NewView : System.Web.UI.Page
    {
        FabricQualityController FabricQualityControllerInstance = new FabricQualityController();
        public bool bCount_Construction = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");
            if (!IsPostBack)
            {
                BindCategory(ddlCategory);
                BindUnit(null, DDlUnit);
                BIndGrid();
            }
        }

        #region Bind DropdownList
        private void BindCategory(DropDownList ddlcategory)
        {
            DataTable dt = FabricQualityControllerInstance.GetCetegory().Tables[0];
            ddlcategory.DataSource = dt;
            ddlcategory.DataTextField = "Name";
            ddlcategory.DataValueField = "Id";
            ddlcategory.DataBind();
            ddlcategory.Items.Insert(0, new ListItem("All", "-1"));
        }

        private void BindUnit(DataTable dt, DropDownList ddlunit)
        {
            if (dt == null)
            {
                dt = FabricQualityControllerInstance.GetUnit().Tables[0];
            }
            ddlunit.DataSource = dt;
            ddlunit.DataTextField = "UnitName";
            ddlunit.DataValueField = "GroupUnitID";
            ddlunit.DataBind();
            ddlunit.Items.Insert(0, new ListItem("ALL", "-1"));
        }

        #endregion

        #region Bind Grid
        private void BIndGrid()
        {

            string CategoryID = ddlCategory.SelectedValue;
            string TradeName = txtTrade.Text.Trim();
            string UnitID = DDlUnit.SelectedValue;

            DataTable dt = FabricQualityControllerInstance.GetFabricQualityDetailsByTradeName_New(TradeName, CategoryID, UnitID);
            if (dt.Rows.Count > 0)
            {
                gdvFQMaster.DataSource = dt;
                gdvFQMaster.DataBind();
            }
            else
            {
                gdvFQMaster.DataSource = null;
                gdvFQMaster.DataBind();
            }
        }


        #endregion


        #region Control Event
        protected void lkbGo_Click(object sender, EventArgs e)
        {
            gdvFQMaster.SelectedIndex = -1;
            BIndGrid();
        }

        #endregion

    }
}