using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iKandi.Common;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Drawing;
using iKandi.BLL;

namespace iKandi.Web.Internal.Fabric
{
    public partial class FabricWrokingRemarks : System.Web.UI.Page
    {
       
        public string OrderID
        {
            get;
            set;
        }

        public string FabricDetails
        {
            get;
            set;
        }      
        public string Flag
        {
            get;
            set;
        }
        public string username
        {
            get;
            set;
        }
        string strRemarks = ""; 
        protected void Page_Load(object sender, EventArgs e)
        {
            GetQueryString();
            if (!IsPostBack)
            {
                BindRemarks();
            }
        }
        
        string dateToday = DateTime.Today.ToString("dd MMM");
        OrderController objcontroller = new OrderController();
        public void GetQueryString()
        {
            if (null != Request.QueryString["OrderID"])
            {
                OrderID = Request.QueryString["OrderID"].ToString();
            }
            if (null != Request.QueryString["FabricDetails"])
            {
                FabricDetails = Request.QueryString["FabricDetails"].ToString();
            }
            if (null != Request.QueryString["Flag"])
            {
                Flag = (Request.QueryString["Flag"]).ToString();
            }
            if (null != Request.QueryString["username"])
            {
                username = (Request.QueryString["username"]).ToString();
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            SaveRemarks();


        }
        public void SaveRemarks()
        {
            string NewRemarks=string.Empty;

            //if (!string.IsNullOrEmpty(OrderID) && !string.IsNullOrEmpty(FabricDetails) && !string.IsNullOrEmpty(username))
            if (!string.IsNullOrEmpty(OrderID) && !string.IsNullOrEmpty(username))
            {

                NewRemarks = username + " : " + "(" + dateToday + ")" + " " + txtremarks.Text.Trim();
                int result = objcontroller.UpdateFabricWorkingETARemarks(Convert.ToInt32(OrderID), FabricDetails, Flag, NewRemarks);
                if (result > 0)
                {
                    ShowAlert("Reamks saved successfully");
                    txtremarks.Text = "";
                    BindRemarks();
 
                }

            }
            else
            {
                ShowAlert("Comment not save please try again.");
                return;
            }
        }
        public void ShowAlert(string stringAlertMsg)
        {
            string myStringVariable = string.Empty;
            myStringVariable = stringAlertMsg;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myalert", "alert('" + myStringVariable + "');", true);
        }
        public void BindRemarks()
        {
            if (!string.IsNullOrEmpty(OrderID)  && !string.IsNullOrEmpty(username))
            {
                strRemarks = objcontroller.GetFabricWorkingETARemarks(Flag,Convert.ToInt32(OrderID));

                if (strRemarks != "")
                {
                    string[] separators = { "`" };
                    string[] words = strRemarks.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        lblShowRemark.Text = lblShowRemark.Text + "</br>" + word;
                    }
                }
            }
        }
    }
}