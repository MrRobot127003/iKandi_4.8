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


namespace iKandi.Web.UserControls.Lists
{
    public partial class PermissionDesignation : System.Web.UI.UserControl
    {
        #region Event Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Request.QueryString["btn"]) == "1")
            {
                HtmlInputButton htmbtn = (HtmlInputButton)this.FindControl("btnPrint");
                htmbtn.Attributes.Add("style", "display:none");
            }

            if (!IsPostBack)
            {
                BindControls();
                if (Request.QueryString["did"] != "-1")
                {
                    ddlDesignation.SelectedValue = Convert.ToString(Request.QueryString["did"]);
                    if (Convert.ToInt32(ddlDesignation.SelectedValue) > -1)
                    {
                        ddlDesignation_SelectedIndexChanged(ddlDesignation, new EventArgs());
                    }
                }
                if (Request.QueryString["mid"] != "-1")
                {
                    ddlApplicationModuleName.SelectedValue = Convert.ToString(Request.QueryString["mid"]);
                }
            }
            else
            {
                string URL;
                string[] MyVar;
                MyVar = Request.Url.ToString().Split('?');
                URL = MyVar[0];
                URL += "?did=" + ddlDesignation.SelectedValue.ToString();
                URL += "&mid=" + ddlApplicationModuleName.SelectedValue.ToString();
                Response.Redirect(URL);    
            }
        }

        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlApplicationModuleName.Items.Clear();

            DropdownHelper.BindApplicationModuleByDesignation(ddlApplicationModuleName as ListControl, Convert.ToInt32((sender as DropDownList).SelectedValue));
        }

        #endregion

        #region Private methods

        private void BindControls()
        {
           // DropdownHelper.BindDesignations(ddlDesignation as ListControl);

            DropdownHelper.BindDesignationFromDB(ddlDesignation,"Permission_Designation","DesId,Name","IsActive","=","1",true);
        }

        #endregion

    }
}