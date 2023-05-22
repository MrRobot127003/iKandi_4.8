using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Common;
using iKandi.Common.Entities;

namespace iKandi.Web.Internal.OrderProcessing
{
    public partial class OrderProcessPopup : System.Web.UI.Page
    {
        public int styleid
        {
            get;
            set;
        }
        public int Tab
        {
            get;
            set;
        }
        public int strClientId
        {
            get;
            set;
        }
        public int DepartmentId
        {
            get;
            set;
        }

        iKandi.BLL.OrderProcessController obj_ProcessController = new BLL.OrderProcessController();
        iKandi.BLL.OrderController obj_OrderController = new BLL.OrderController();

        protected void Page_Load(object sender, EventArgs e)
        {
            GetQueryString();
            if (!IsPostBack)
            {
                BindDropDown();
            }
        }

        private void GetQueryString()
        {
            if (null != Request.QueryString["styleid"])
            {
                styleid = Convert.ToInt32(Request.QueryString["styleid"].ToString());
            }            
            if (null != Request.QueryString["Tab"])
            {
                Tab = Convert.ToInt32(Request.QueryString["Tab"].ToString());
            }
            if (null != Request.QueryString["ClientId"])
            {
                strClientId = Convert.ToInt32(Request.QueryString["ClientId"].ToString());
            }
            if (null != Request.QueryString["DeptId"])
            {
                DepartmentId = Convert.ToInt32(Request.QueryString["DeptId"].ToString());
            }
        }
        private void BindDropDown()
        {
            hdnTab.Value = Tab.ToString();
            DataSet dsStyle = obj_ProcessController.CheckOrderProcessStyle(styleid, strClientId, DepartmentId, Tab);

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

            //if (hdnTab.Value == "3")
            //{
            //    int IsUpdate = obj_OrderController.UpdateReuseFlag(Convert.ToInt32(NewRefrenceStyleID));
            //    if (ddlNewWithRefrence.SelectedValue != "0")
            //    {

            //        Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "NewWithRefrence(" + NewRefrenceStyleID + ",'" + NewRefrenceStyleNumber + "')", true);
            //    }
            //}
            //else
            //{
               
            //}
        }

        protected void ddlReUse_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ReUseStyleID = ddlReUse.SelectedValue;
            var ReUseStyleNumber = "";


            //
            var strStylenumber = ddlReUse.SelectedItem.Text.Split(',');
            if (strStylenumber.Length > 0)
            {
                 ReUseStyleNumber = strStylenumber[0];
            }
            else
            {
                 ReUseStyleNumber = ddlReUse.SelectedItem.Text;
            }
            //
            
            if (hdnTab.Value == "3")
            {
                int IsUpdate = obj_OrderController.UpdateReuseFlag(Convert.ToInt32(ReUseStyleID));
                if (ddlReUse.SelectedValue != "0")
                {

                    //Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "ReUse(" + ReUseStyleID + ")", true);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "ReUse(" + ReUseStyleID + ",'" + ReUseStyleNumber + "')", true);
                }
            }

            if (ddlReUse.SelectedValue != "0")
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "scr", "ReUse(" + ReUseStyleID + ",'" + ReUseStyleNumber + "')", true);
            }

            //else
            //{
               
           //}
        }
    }
}