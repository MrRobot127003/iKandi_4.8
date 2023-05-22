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


using iKandi.Web.Components;
using iKandi.Common;


namespace iKandi.Web.UserControls.Lists
{
    public partial class PermissionDepartment : System.Web.UI.UserControl
    {
        #region EventHandlers

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
                    //  if(Request.QueryString["did"] != null)
                    ddlDepartment.SelectedValue = Convert.ToString(Request.QueryString["did"]);
                    if (Convert.ToInt32(ddlDepartment.SelectedValue) > -1)
                    {
                        ddlDepartment_SelectedIndexChanged(ddlDepartment, new EventArgs());
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
                URL += "?did=" + ddlDepartment.SelectedValue.ToString();
                URL += "&mid=" + ddlApplicationModuleName.SelectedValue.ToString();
                Response.Redirect(URL);
            }

        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

            ddlApplicationModuleName.Items.Clear();
            DropdownHelper.BindApplicationModuleByDepartment(ddlApplicationModuleName as ListControl, Convert.ToInt32((sender as DropDownList).SelectedValue));

        }

        #endregion

        #region Private Methods

        private void BindControls()
        {
            // DropdownHelper.BindGroups(ddlDepartment as ListControl);
            DropdownHelper.BindGroupsFromDB(ddlDepartment, "group_Name", "DeptId,Name", "IsActive", "=", "1", true);

        }

        #endregion



    }
}

