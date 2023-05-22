using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using iKandi.Common;
using System.Web.UI.HtmlControls;
using iKandi.Web.Components;


namespace iKandi.Web.Internal.OrderProcessing
{
    public partial class OrderProcessFlow : BasePage
    //public partial class OrderProcessFlow : BaseUserControl
    {
        public int styleid
        {
            get;
            set;
        }
        public string stylenumber
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
        public int OrderID
        {
            get;
            set;
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {

              tabRisk.Attributes.Add("style", "display:none");
              tabFit.Attributes.Add("style", "display:none");
              tabHO.Attributes.Add("style", "display:none");

            tabOB.Attributes.Add("style", "display:none");
            
            lnkRisk.Attributes.Add("style", "display:none");
            lnkFit.Attributes.Add("style", "display:none");
            lnkOB.Attributes.Add("style", "display:none");
            lnkHO.Attributes.Add("style", "display:none");

            if (!IsPostBack)
            {
                GetQueryString();
                hdnClientId.Value = strClientId.ToString();
                hdnDeptId.Value = DepartmentId.ToString();
                //Session["PostID"] = "1001";
                //ViewState["PostID"] = Session["PostID"].ToString();

                //IsValidPost();
                int iUserId = 0;
                string Flag = string.Empty;
                string v = Request.QueryString["Emailid"];
                if (v != null && v != "")
                {
                    Flag = v;
                    if (ApplicationHelper.LoggedInUser.UserData != null)

                        iUserId = ApplicationHelper.LoggedInUser.UserData.UserID;

                    UserDetails usd = new UserDetails();


                    SessionInfo sessionInfo = new SessionInfo();

                    iKandi.Common.User user = null;

                    user = this.MembershipControllerInstance.GetUser(Convert.ToInt32(iUserId));
                    ApplicationHelper objApplicationHelper = new ApplicationHelper();
                    DataSet ds = objApplicationHelper.GetNotifactionRemarks(user.DesignationID, Convert.ToInt32(Flag), "Form", iUserId);
                }




            }


        }

        public bool IsValidPost()
        {

            bool istrueorfalse = false;

            if (ViewState["PostID"] != null)
            {
                if (ViewState["PostID"].ToString() == Session["PostID"].ToString())
                {
                    Session["PostID"] =
                    (Convert.ToInt16(Session["PostID"]) + 1).ToString();

                    ViewState["PostID"] = Session["PostID"].ToString();
                    istrueorfalse = true;

                }
                else
                {
                    ViewState["PostID"] = Session["PostID"].ToString();

                    istrueorfalse = false;
                }

                if (Session["id"] != null)
                {
                    istrueorfalse = false;
                }

            }
            return istrueorfalse;
        }

        private void GetQueryString()
        {
            if (null != Request.QueryString["styleid"])
            {
                styleid = Convert.ToInt32(Request.QueryString["styleid"].ToString());
            }
            if (null != Request.QueryString["stylenumber"])
            {
                stylenumber = Request.QueryString["stylenumber"].ToString();
            }
            if (null != Request.QueryString["ClientID"])
            {
                strClientId = Convert.ToInt32(Request.QueryString["ClientID"].ToString());
            }
            if (null != Request.QueryString["DeptId"])
            {
                DepartmentId = Convert.ToInt32(Request.QueryString["DeptId"].ToString());
            }
            if (null != Request.QueryString["showFITSFORM"])
            {
                hdnShowForm.Value = Request.QueryString["showFITSFORM"].ToString() == "Yes" ? "ShowFitsForm" : "0";
            }
            if (null != Request.QueryString["showOBFORM"])
            {
                hdnShowForm.Value = Request.QueryString["showOBFORM"].ToString() == "Yes" ? "ShowOBForm" : "0";
            }
            if (null != Request.QueryString["showRiskFORM"])
            {
                hdnShowForm.Value = Request.QueryString["showRiskFORM"].ToString() == "Yes" ? "ShowRiskForm" : "0";
            }
            if (null != Request.QueryString["showHOPPMFORM"])
            {
                hdnShowForm.Value = Request.QueryString["showHOPPMFORM"].ToString() == "Yes" ? "ShowHOPPMForm" : "0";
            }
            if (null != Request.QueryString["OrderID"])
            {
                OrderID = Convert.ToInt32(Request.QueryString["OrderID"].ToString());
            }
        }

    }
}