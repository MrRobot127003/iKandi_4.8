using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace iKandi.Web.Admin.FitsSample
{
    public partial class FitsReUsePopup : System.Web.UI.Page
    {
        iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();
        public int styleid
        {
            get;
            set;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (null != Request.QueryString["styleid"])
            {
                styleid = Convert.ToInt32(Request.QueryString["styleid"].ToString());
            }
            if (!IsPostBack)
            {
                BindDropDown();
            }
        }

        private void BindDropDown()
        {            
            DataSet dsStyle = obj_ProcessController.CheckOrderProcessStyle(styleid, -1, -1, 5);

            if (dsStyle.Tables[0].Rows.Count > 0)
            {
              ddlNewWithRefrence.DataSource = dsStyle.Tables[0];
              ddlNewWithRefrence.DataValueField = "Styleid";
              ddlNewWithRefrence.DataTextField = "StyleNumber";
              ddlNewWithRefrence.DataBind();
              ddlNewWithRefrence.Items.Insert(0, new ListItem("Create New with Refrence", "0"));
            }
            if (dsStyle.Tables[1].Rows.Count > 0)
            {
                ddlReUse.DataSource = dsStyle.Tables[1];
                ddlReUse.DataValueField = "Styleid";
                ddlReUse.DataTextField = "StyleNumber";
                ddlReUse.DataBind();
                ddlReUse.Items.Insert(0, new ListItem("Re-Use", "0"));
            }
        }

        protected void ddlNewWithRefrence_SelectedIndexChanged(object sender, EventArgs e)
        {
          var NewStyleID = ddlNewWithRefrence.SelectedValue;
          var strStylenumber = ddlNewWithRefrence.SelectedItem.Text.Split(',');
          var NewStyleNumber = "";

          if (strStylenumber.Length > 0)
          {
            NewStyleNumber = strStylenumber[0];
          }
          else
          {
            NewStyleNumber = ddlNewWithRefrence.SelectedItem.Text;
          }


          if (ddlNewWithRefrence.SelectedValue != "0")
          {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "NewWithRefrence(" + NewStyleID + ",'" + NewStyleNumber + "')", true);
          }

        }

        protected void ddlReUse_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ReUseStyleID = ddlReUse.SelectedValue;
            var ReUseStyleNumber = "";

            var strStylenumber = ddlReUse.SelectedItem.Text.Split(',');
            if (strStylenumber.Length > 0)
            {
                ReUseStyleNumber = strStylenumber[0];
            }
            else
            {
                ReUseStyleNumber = ddlReUse.SelectedItem.Text;
            }

            if (ddlReUse.SelectedValue != "0")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "ReUse(" + ReUseStyleID + ",'" + ReUseStyleNumber + "')", true);
            }

        }
    }
}