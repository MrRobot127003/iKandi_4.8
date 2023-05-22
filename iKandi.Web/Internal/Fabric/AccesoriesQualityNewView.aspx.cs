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
using System.Text;
using System.Collections.Generic;
using iKandi.BLL;
using System.Text.RegularExpressions;
using System.Web.Caching;
using iKandi.Common;
using iKandi.Web.Components;
namespace iKandi.Web.Internal.Fabric
{
    public partial class AccesoriesQualityNewView : System.Web.UI.Page
    {
    

        AdminController onjadminCon = new AdminController();
        AccessoryQualityController acccontroler = new AccessoryQualityController();
       

        protected void Page_Load(object sender, EventArgs e)
        {          

            if (iKandi.Web.Components.ApplicationHelper.LoggedInUser == null || iKandi.Web.Components.ApplicationHelper.LoggedInUser.UserData == null)
                Response.Redirect("~/public/Login.aspx");

            if (!Page.IsPostBack)
            {
                BindDdlCatagory(ddlgroupSrach, "ALL");               
                BindUnit(null, ddlunitsearch);
                BindAccQaulityGrd();
            }          
        }
              
        private void BindUnit(DataTable dt, DropDownList ddl)
        {
            if (dt == null)
            {
                dt = acccontroler.GetUnit().Tables[0];
            }
            ddl.DataSource = dt;
            ddl.DataTextField = "UnitName";
            ddl.DataValueField = "GroupUnitID";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("ALL", "-1"));
        }
       
        protected void btn_Go(object sender, EventArgs e)
        {                       
            GrdCatgoryAdd.EditIndex = -1;
            BindAccQaulityGrd();         
           
        }
       
        public void BindDdlCatagory(DropDownList ddlcat, string IsSelect = "")
        {
            DataSet ds = new DataSet();
            DataTable dtcat = new DataTable();
            ds = onjadminCon.GetCatagory(1);
            dtcat = ds.Tables[0];
            ddlcat.DataSource = dtcat;
            ddlcat.DataTextField = "Name";
            ddlcat.DataValueField = "id";
            ddlcat.DataBind();
            if (IsSelect != "NoSelect")
            {
                if (IsSelect == "")
                {
                    ddlcat.Items.Insert(0, new ListItem(IsSelect, "-1"));
                }
                else
                {
                    ddlcat.Items.Insert(0, new ListItem(IsSelect, "-1"));
                }
            }

        }
       
        public void BindAccQaulityGrd()
        {
            DataTable dtcat = new DataTable();
            dtcat = acccontroler.GetAccessoryQualityDetailsByTradeName_New(txtQualitySearch.Text.Trim(), ddlgroupSrach.SelectedValue, ddlunitsearch.SelectedValue, Convert.ToInt32(ddlIsDefault.SelectedValue));
            if (dtcat.Rows.Count > 0)
            {
                GrdCatgoryAdd.DataSource = dtcat;
                GrdCatgoryAdd.DataBind();
            }
            else
            {
                GrdCatgoryAdd.DataSource = null;
                GrdCatgoryAdd.DataBind();
            }
        }
         
                                      }
}